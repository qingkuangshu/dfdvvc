using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using HalconDotNet;
using MvCamCtrl.NET;
using System.Diagnostics;
using static VM_Pro.ImageTool;
using System.Collections.Concurrent;

namespace VM_Pro
{
    /// <summary>
    /// 海康威视相机
    /// </summary>
    [Serializable]
    internal class SDK_HIKVision : SDK_Base
    {
        internal SDK_HIKVision(string cameraInfoStr)
        {
            this.cameraInfoStr = cameraInfoStr;
        }

        /// <summary>
        /// 资源锁
        /// </summary>
        private object obj = new object();
        /// <summary>
        /// 相机集合   键：相机信息字符串  值：相机对象
        /// </summary>
        internal static Dictionary<string, MyCamera> D_cameras = new Dictionary<string, MyCamera>();

        /// <summary>
        /// 实例对象
        /// </summary>
        private static SDK_HIKVision _instance;
        public static SDK_HIKVision Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SDK_HIKVision(string.Empty);
                return _instance;
            }
        }



        #region 海康威视硬触发回调部分


        /// <summary>
        /// 存放当前类相机的详细信息【跟cameraInfoStr一样，但其非静态字段，无法供静态方法使用】
        /// </summary>
        public static string Cur_cameraInfoStr = string.Empty;


        [NonSerialized]
        /// <summary>
        /// 1.当用户从硬触发切换到软触发之后，当前获取的图像数据仍然是通过回调而来，那么回调获取到的图像即会转为此
        /// </summary>
        internal static HObject callbackImage = null;
        [NonSerialized]
        internal static MyCamera.cbOutputExdelegate ImageCallback = null;    //声明回调类型

        [NonSerialized]
        /// <summary>
        /// 回调任务是否正在执行的标志，若正在执行，这丢弃当前回调图像
        /// </summary>
        internal static bool IsCallBackIng = true;



        #region 极片缺陷检测特定

        [NonSerialized]
        /// <summary>
        /// 相机Io输出功能,因为IO输出是给前一片的结果信号，故采用队列   
        /// </summary>
        internal static ConcurrentQueue<bool> isOutIo = new ConcurrentQueue<bool>();

        [NonSerialized]
        /// <summary>
        /// 信号持续输出时间  单位：ms
        /// </summary>
        internal static int ThreadTimeOut = 50;


        /// <summary>
        /// IO输出阻断器，控制IO输出线程的运行
        /// </summary>
        [NonSerialized]
        internal static AutoResetEvent IOoutEvent = new AutoResetEvent(false);

        /// <summary>
        /// 用于控制任务线程的运行
        /// </summary>
        [NonSerialized]
        internal static AutoResetEvent TaskRunEvent = new AutoResetEvent(false);

        /// <summary>
        /// 是否首次初始化，
        /// </summary>
        [NonSerialized]
        internal static bool isInitRun = false;

        /// <summary>
        /// 开启相机IO输出线程
        /// </summary>
        internal static void StartIOoutTh()
        {
            Thread thIO = new Thread(() =>
            {
                while (true)
                {
                    IOoutEvent.WaitOne();
                    for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                    {
                        if (!CCamera.FindCamera(Project.Instance.L_Service[i].name).IoOutout(((CCamera)Project.Instance.L_Service[i]).cameraInfoStr, ThreadTimeOut))
                        {
                            FuncLib.ShowMessageBox("当前相机IO输出失败");
                        }
                        else
                        {
                            FuncLib.ShowMsg(DateTime.Now.ToString() + "  IO输出成功");
                        }
                    }
                }
            });
            thIO.IsBackground = true;
            thIO.Start();
        }



        #endregion
        [NonSerialized]
        internal static HObject CurImg = null;
        /// <summary>
        /// 海康回调函数
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pFrameInfo"></param>
        /// <param name="pUser"></param>
        public static void ImageCallbackFunc(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {
            if (Frm_Welcome.th1IsLoading || Frm_Welcome.th2IsLoading) //去掉程序还在初始化的时候，相机硬触发信号
                return;
            if (!IsCallBackIng)  //非硬触发直接返回
                return;


            isOutIo.TryDequeue(out bool B);
            if (B)  //单独开个线程，相机IO输出上一次的判定结果
                IOoutEvent.Set();


            IsCallBackIng = false;
            int index = (int)pUser;

            #region 得到回调之后，第一步是先将该图像流数据转换为halcon图片对象

            switch (pFrameInfo.enPixelType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8: //黑白
                    HOperatorSet.GenImage1(out CurImg, "byte", pFrameInfo.nWidth, pFrameInfo.nHeight, pData);
                    break;
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed: //普通格式彩色
                    HOperatorSet.GenImageInterleaved(out CurImg, pData, "rgb", pFrameInfo.nWidth, pFrameInfo.nHeight, -1, "byte",
                                                     pFrameInfo.nWidth, pFrameInfo.nHeight, 0, 0, -1, 0);
                    break;
                default:
                    //如果彩色图像不是RGB8格式，则需要将图像格式转换为RGB8。
                    IntPtr pBufForSaveImage = IntPtr.Zero;
                    if (pBufForSaveImage == IntPtr.Zero)
                    {
                        pBufForSaveImage = Marshal.AllocHGlobal((int)(pFrameInfo.nWidth * pFrameInfo.nHeight * 3 + 2048));
                    }
                    MyCamera.MV_PIXEL_CONVERT_PARAM stConverPixelParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();
                    stConverPixelParam.nWidth = pFrameInfo.nWidth;
                    stConverPixelParam.nHeight = pFrameInfo.nHeight;
                    stConverPixelParam.pSrcData = pData;
                    stConverPixelParam.nSrcDataLen = pFrameInfo.nFrameLen;
                    stConverPixelParam.enSrcPixelType = pFrameInfo.enPixelType;
                    stConverPixelParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;//在此处选择需要转换的目标类型
                    stConverPixelParam.pDstBuffer = pBufForSaveImage;
                    stConverPixelParam.nDstBufferSize = (uint)(pFrameInfo.nWidth * pFrameInfo.nHeight * 3 + 2048);
                    foreach (var item in D_cameras)
                    {
                        if (item.Key.Contains(index.ToString()))
                        {
                            item.Value.MV_CC_ConvertPixelType_NET(ref stConverPixelParam);
                            break;
                        }
                    }
                    HOperatorSet.GenImageInterleaved(out CurImg, pBufForSaveImage, "rgb", (int)pFrameInfo.nWidth, (int)pFrameInfo.nHeight, 0, "byte", (int)pFrameInfo.nWidth, (int)pFrameInfo.nHeight, 0, 0, -1, 0);
                    //释放指针
                    Marshal.FreeHGlobal(pBufForSaveImage);
                    break;
            }

            if (Cur_cameraInfoStr.Contains(index.ToString()))
            {
                callbackImage = CurImg;  //赋值给软触发存放的图片对象
                GrabEventWait.Set();
                Cur_cameraInfoStr = "";
                IsCallBackIng = true;
                return;
            }

            #endregion
             

            CallImgTriggerTask(index, CurImg);  //回调触发任务流程

        }

        /// <summary>
        /// 回调图像是否触发相应任务流程运行
        /// </summary>
        /// <param name="CameraIndex">回调相机的索引</param>
        /// <param name="image">当前回调图像</param>
        internal static void CallImgTriggerTask(int CameraIndex, HObject image)
        {
            if (isInitRun)
            {
                TaskRunEvent.Set();
                return;
            }
            isInitRun = true;
            Task tt = Scheme.curScheme.L_taskList.Find(t => t.taskTrigMode == TaskTrigMode.BasedCameraHardTrigger); //先粗略看下当前方案下是否有任务是相机硬触发的
            if (tt != null)
            {
                foreach (Task tasking in Scheme.curScheme.L_taskList)   //遍历该解决方案下所有任务的集合
                {
                    if (tasking.taskTrigMode == TaskTrigMode.BasedCameraHardTrigger
                        && tasking.L_toolList.Count > 0)   //如果当前任务是硬触发模式，且当前任务下有流程
                    {
                        foreach (ToolBase toolbaseing in tasking.L_toolList)    //遍历当前任务下的所有流程，找到采集图像工具
                        {
                            if (toolbaseing.toolType == ToolType.采集图像)  //如果当前流程是采集图像的话，则判断一下当前的相机服务是否为此时回调的相机
                            {
                                ImageTool imgtool = (ImageTool)toolbaseing;
                                //若当前采集图像工具是硬触发，并且根据该相机的名字，找到其相机详细信息，里面包含着当前序列号句柄的话，则认为当前回调就是此相机
                                if (imgtool.hardTrig && ((CCamera)Project.FindServiceByName(imgtool.cameraName)).cameraInfoStr.Contains(CameraIndex.ToString()))
                                {
                                    if (!tasking.isRunning)  //判断一下当前的任务是否正在执行
                                    {
                                        ////触发运行该流程
                                        Thread thTaskRun = new Thread(() =>
                                        {
                                            while (true)
                                            { 
                                                ((ToolPar)imgtool.参数).输出.图像 = CurImg;    //将图片给到采集图像工具
                                                FuncLib.ShowMsg("相机：H" + CameraIndex + " 回调触发任务流程：" + tasking.name, InfoType.Tip);
                                                tasking.isRunning = true;
                                                tasking.Run();
                                                tasking.isRunning = false;
                                                IsCallBackIng = true;
                                                TaskRunEvent.WaitOne();
                                            }
                                            
                                        });
                                        thTaskRun.IsBackground = true;
                                        thTaskRun.Start();
                                    }
                                    else    //当前任务正在执行中，已默认跳过
                                    {
                                        FuncLib.ShowMsg("任务" + tasking.name + " 正在执行中，已过滤本次回调触发执行该任务", InfoType.Error);
                                    }
                                }
                                break;  //默认流程当中只有一个采图工具是硬触发的
                            }
                        }
                    }
                }
            }

        }

        #endregion

        /// <summary>
        /// 枚举相机
        /// </summary>
        /// <returns>是否成功</returns>
        internal override bool EnumCamera()
        {
            try
            {
                uint temp = MyCamera.MV_CC_GetSDKVersion_NET();     //用于试探是否安装了海康威视相机SDK
            }
            catch
            {
                return false;
            }

            int nRet = MyCamera.MV_OK;
            MyCamera.MV_CC_DEVICE_INFO_LIST stDevList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            //stDevList 枚举GIGE/USB类型的海康相机列表
            nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref stDevList);

            if (MyCamera.MV_OK == nRet)
            {
                MyCamera.MV_CC_DEVICE_INFO stDevInfo;
                for (Int32 i = 0; i < stDevList.nDeviceNum; i++)
                {
                    MyCamera myCamera = new MyCamera();
                    //stDevInfo 获取当前相机的详细信息
                    stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                    if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)   //GIGE接口相机
                    {
                        MyCamera.MV_GIGE_DEVICE_INFO stGigEDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                        string adapterName = GetAdapterNameByMacAdd(stGigEDeviceInfo.nCurrentSubNetMask.ToString());     //有误，获取的不是网卡的物理地址，待更正
                        string sn = stGigEDeviceInfo.chSerialNumber;                                                     //序列号
                        string friendlyName = stGigEDeviceInfo.chModelName;                                              //相机型号
                        string vendorName = stGigEDeviceInfo.chManufacturerName;                                         //厂商

                        if (vendorName != "Hikvision" && vendorName != "Hikrobot" && vendorName != "GEV")      //相应品牌的SDK只允许识别对应品牌的相机，否则采图时会出错
                            continue;

                        stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                        //创建设备【创建句柄】
                        nRet = myCamera.MV_CC_CreateDevice_NET(ref stDevInfo);
                        //开启设备
                        nRet = myCamera.MV_CC_OpenDevice_NET();

                        if (nRet != MyCamera.MV_OK)
                        {
                            FuncLib.ShowMsg("海康威视 相机打开失败，可能是非正常关闭相机导致，正处于保护模式...", InfoType.Error);
                            //FuncLib.ShowMessageBox("海康威视 相机打开失败，可能是非正常关闭相机导致，正处于保护模式...", InfoType.Error);
                            //return false;
                            continue;

                        }


                        //MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
                        //nRet = myCamera.MV_CC_GetIntValue_NET("PayloadSize", ref stParam);
                        //UInt32 nPayloadSize = stParam.nCurValue;
                        //myCamera.MV_CC_SetHeartBeatTimeout_NET(5000);       //设置心跳时间为1秒
                        bool _isSoftTrigger = true;
                        foreach (var itemServer in Project.Instance.L_Service)  //遍历当前程序的所有服务
                        {
                            if (itemServer.serviceType == ServiceType.Camera)   //如果当前服务类型是相机的话
                            {
                                CCamera ccamera = (CCamera)itemServer;

                                //1.创建回调委托对象
                                if (ImageCallback == null)
                                {
                                    //1.当存在多个相机时，此处切记不可多次new，不然上一个new的委托对象就被回收了，这样的话会报调用已回收委托的错误
                                    ImageCallback = new MyCamera.cbOutputExdelegate(ImageCallbackFunc);
                                }
                                //2.给当前相机注册回调，且其识别句柄设置为其Sn码
                                nRet = myCamera.MV_CC_RegisterImageCallBackEx_NET(ImageCallback, (IntPtr)Convert.ToUInt64(sn.Substring(3)));
                                if (MyCamera.MV_OK != nRet)
                                {
                                    //注册回调失败
                                    FuncLib.ShowMsg("枚举 海康威视时注册回调 相机失败:" + nRet, InfoType.Error);
                                    FuncLib.ShowMessageBox("枚举 海康威视时注册回调 相机失败:" + nRet, InfoType.Error);
                                    return false;
                                }

                                //3.根据当前相机所选择触发方式，给其默认设置为相应的模式
                                if (ccamera.hardTrigServer && ccamera.cameraInfoStr.Contains(sn))
                                {
                                    #region 设置硬触发的参数
                                    switch (ccamera.hardLine)
                                    {
                                        case CCamera.EHaridHardLine.Line0:
                                            myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
                                            break;
                                        case CCamera.EHaridHardLine.Line1:
                                            myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE1);
                                            break;
                                        case CCamera.EHaridHardLine.Line2:
                                            myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE2);
                                            break;
                                        default:
                                            myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
                                            break;
                                    }

                                    //设置上升沿触发
                                    myCamera.MV_CC_SetEnumValue_NET("TriggerActivation", 0);
                                    //滤波处理，去除毛刺信号 单位us
                                    myCamera.MV_CC_SetEnumValue_NET("LineSelector", 0);
                                    myCamera.MV_CC_SetIntValue_NET("LineDebouncerTime", 5000);
                                    #endregion
                                    _isSoftTrigger = false;
                                }
                            }
                        }
                        if (_isSoftTrigger)
                        {
                            myCamera.MV_CC_SetEnumValue_NET("TriggerSource", 7);//外触发 - 软触发
                        }
                        myCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);    //设置为外触发模式
                        myCamera.MV_CC_SetEnumValue_NET("AcquisitionMode", 2);  //设置连续采集模式
                        nRet = myCamera.MV_CC_StartGrabbing_NET();//开启流数据




                        string cameraInfoStr = string.Format("{0} | {1} | {2} | {3}", adapterName, sn, friendlyName, vendorName).Trim();
                        Frm_Welcome.ShowStep(string.Format("初始化 海康威视 相机 {0} ：{1}", i + 1, cameraInfoStr));

                        SDK_HIKVision sdk_HIKVision = new SDK_HIKVision(cameraInfoStr);
                        L_SDKCamera.Add(sdk_HIKVision);

                        D_cameras.Add(cameraInfoStr, myCamera);
                        Frm_Camera.Instance.cbx_cameraList.Items.Add(cameraInfoStr);
                    }
                    else if (MyCamera.MV_USB_DEVICE == stDevInfo.nTLayerType) //USB3待完善
                    {
                        MyCamera.MV_USB3_DEVICE_INFO stUsb3DeviceInfo = (MyCamera.MV_USB3_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stUsb3VInfo, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    }
                }
            }
            else
            {
                FuncLib.ShowMsg("枚举 海康威视 相机失败", InfoType.Error);
                FuncLib.ShowMessageBox("枚举 海康威视 相机失败", InfoType.Error);
                return false;
            }
            StartIOoutTh();
            return true;
        }



        /// <summary>
        /// 抓取一张图像
        /// </summary>
        /// <returns>图像</returns>
        internal override HObject GrabOneImage(string cameraName)
        {
            lock (obj)
            {
                HObject image = null;
                Cur_cameraInfoStr = cameraInfoStr;
                callbackImage = null;
                GrabEventWait.Reset();
                D_cameras[cameraInfoStr].MV_CC_SetCommandValue_NET("TriggerSoftware");
                GrabEventWait.WaitOne(8000, false);
                //此处还可以添加取图失败的做法


                return callbackImage;



                foreach (KeyValuePair<string, MyCamera> item in D_cameras)
                {
                    if (item.Key == cameraInfoStr)
                    {
                        //callbackImage = null;

                        //Cur_cameraInfoStr = item.Key;

                        //item.Value.MV_CC_SetCommandValue_NET("TriggerSoftware");

                        //sw.Restart();

                        ////Thread.Sleep(200);
                        //int t = 0;
                        //while (callbackImage == null)
                        //{
                        //    t++;
                        //    Thread.Sleep(2);
                        //    if (t == 1000)
                        //    {
                        //        break;
                        //    }
                        //}

                        //return callbackImage;





                        MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
                        int nRet = item.Value.MV_CC_GetIntValue_NET("PayloadSize", ref stParam);
                        if (MyCamera.MV_OK != nRet)
                        {
                            FuncLib.ShowMessageBox(string.Format("采集图像失败，请检查！相机：{0}", cameraName), InfoType.Error);
                            FuncLib.ShowMsg(string.Format("采集图像失败，请检查！相机：{0}", cameraName), InfoType.Error);
                            break;
                        }
                        UInt32 nPayloadSize = stParam.nCurValue;
                        IntPtr pBufForDriver = Marshal.AllocHGlobal((int)nPayloadSize);
                        IntPtr pBufForSaveImage = IntPtr.Zero;

                        MyCamera.MV_FRAME_OUT_INFO_EX FrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();
                        nRet = item.Value.MV_CC_GetOneFrameTimeout_NET(pBufForDriver, nPayloadSize, ref FrameInfo, 5000);
                        if (MyCamera.MV_OK == nRet)
                        {
                            if (pBufForSaveImage == IntPtr.Zero)
                            {
                                pBufForSaveImage = Marshal.AllocHGlobal((int)(FrameInfo.nHeight * FrameInfo.nWidth * 3 + 2048));
                            }

                            MyCamera.MV_SAVE_IMAGE_PARAM_EX stSaveParam = new MyCamera.MV_SAVE_IMAGE_PARAM_EX();
                            stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Bmp;
                            stSaveParam.enPixelType = FrameInfo.enPixelType;
                            stSaveParam.pData = pBufForDriver;
                            stSaveParam.nDataLen = FrameInfo.nFrameLen;
                            stSaveParam.nHeight = FrameInfo.nHeight;
                            stSaveParam.nWidth = FrameInfo.nWidth;
                            stSaveParam.pImageBuffer = pBufForSaveImage;
                            stSaveParam.nBufferSize = (uint)(FrameInfo.nHeight * FrameInfo.nWidth * 3 + 2048);
                            stSaveParam.nJpgQuality = 80;
                            nRet = item.Value.MV_CC_SaveImageEx_NET(ref stSaveParam);
                            if (MyCamera.MV_OK != nRet)
                            {
                                FuncLib.ShowMessageBox(string.Format("采集图像失败，请检查！相机：{0}\r\n        可能原因 : 1、 相机已掉线\r\n                         2、 网卡不是千兆网卡，带宽不够", cameraName), InfoType.Error);
                                FuncLib.ShowMsg(string.Format("采集图像失败，请检查！相机：{0}", cameraName), InfoType.Error);
                                return null;
                            }
                            byte[] data = new byte[stSaveParam.nImageLen];
                            Marshal.Copy(pBufForSaveImage, data, 0, (int)stSaveParam.nImageLen);

                            //转化成Halcon对象
                            GCHandle hand = GCHandle.Alloc(data, GCHandleType.Pinned);
                            IntPtr pr = hand.AddrOfPinnedObject();
                            HOperatorSet.GenImage1(out image, new HTuple("byte"), stSaveParam.nWidth, stSaveParam.nHeight, pBufForDriver);
                            if (hand.IsAllocated)
                                hand.Free();
                            Marshal.FreeHGlobal(pBufForDriver);
                            Marshal.FreeHGlobal(pBufForSaveImage);
                            break;
                        }
                        else
                        {
                            FuncLib.ShowMessageBox(string.Format("采集图像失败，请检查！相机：{0}\r\n        可能原因 : 1、 相机已掉线\r\n                         2、 网卡不是千兆网卡，带宽不够", cameraName), InfoType.Error);
                            FuncLib.ShowMsg(string.Format("采集图像失败，请检查！相机：{0}", cameraName), InfoType.Error);
                            return null;
                        }
                    }
                }
                return image;
            }
        }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="exposure">曝光时间，单位：us</param>
        internal override void SetExposure(int exposureTime, string cameraName)
        {
            foreach (KeyValuePair<string, MyCamera> item in D_cameras)
            {
                if (item.Key == cameraInfoStr)
                {
                    item.Value.MV_CC_SetFloatValue_NET("ExposureTime", (float)exposureTime);
                    return;
                }
            }
        }
        /// <summary>
        /// 设置增益
        /// </summary>
        /// <param name="gain">增益</param>
        internal override void SetGain(int gain, string cameraName)
        {
            foreach (KeyValuePair<string, MyCamera> item in D_cameras)
            {
                if (item.Key == cameraInfoStr)
                {
                    try
                    {
                        item.Value.MV_CC_SetFloatValue_NET("Gain", (float)gain);
                    }
                    catch
                    {
                        FuncLib.ShowMessageBox(string.Format("设置增益失败，请检查！相机：{0}\r\n        可能原因 : 1、 数值超限", cameraName), InfoType.Error);
                        FuncLib.ShowMsg(string.Format("设置增益失败，请检查！相机：{0}", cameraName), InfoType.Error);
                    }
                    return;
                }
            }
        }
        /// <summary>
        /// 设置采集模式
        /// </summary>
        /// <param name="mode">0=连续采集，即异步采集  1=单次采集，即同步采集</param>
        internal override void SetAcquisitionMode(int mode)
        {
            foreach (KeyValuePair<string, MyCamera> item in D_cameras)
            {
                if (item.Key == cameraInfoStr)
                {
                    //待完善

                    return;
                }
            }
        }
        /// <summary>
        /// 关闭所有相机
        /// </summary>
        internal override void CloseAll()
        {
            foreach (KeyValuePair<string, MyCamera> item in D_cameras)
            {
                if (item.Key == cameraInfoStr)
                {
                    item.Value.MV_CC_StopGrabbing_NET();
                    item.Value.MV_CC_CloseDevice_NET();
                    item.Value.MV_CC_DestroyDevice_NET();
                    return;
                }
            }
        }

        internal override bool IoOutout(string CameraName, int DelayTime)
        {
            if (!D_cameras.Keys.Contains(CameraName))   //若当前相机不存在则直接返回失败
                return false;
            int nRet = 0;
            // IO数字输出
            nRet = D_cameras[CameraName].MV_CC_SetEnumValue_NET("LineSelector", 2);
            nRet += D_cameras[CameraName].MV_CC_SetEnumValue_NET("LineMode", 8);
            nRet += D_cameras[CameraName].MV_CC_SetBoolValue_NET("LineInverter", true);
            Thread.Sleep(50);
            nRet += D_cameras[CameraName].MV_CC_SetBoolValue_NET("LineInverter", false);

            if (nRet == 0)
                return true;
            return false;
        }

        /// <summary>
        /// 1.根据海康威视的序列号，设置其在图像工具当中是硬触发还是软触发，并放回相应的MyCamera对象
        /// </summary>
        /// <param name="CameraOnlyName">根据海康威视的序列号</param>
        /// <param name="IsHardTrigger">TRUE:硬触发  FALSE:软触发</param>
        /// <returns></returns>
        internal static MyCamera GetHiKCamera(string CameraOnlyName, bool IsHardTrigger)
        {
            foreach (Task tasking in Scheme.curScheme.L_taskList)   //遍历该解决方案下所有任务的集合
            {
                //if (tasking.taskTrigMode == TaskTrigMode.BasedCameraHardTrigger
                //    && tasking.L_toolList.Count > 0)   //如果当前任务是硬触发模式，且当前任务下有流程
                {
                    foreach (ToolBase toolbaseing in tasking.L_toolList)    //遍历当前任务下的所有流程，找到采集图像工具
                    {
                        if (toolbaseing.toolType == ToolType.采集图像)  //如果当前流程是采集图像的话，则判断一下当前的相机服务是否为此时回调的相机
                        {
                            ImageTool imgtool = (ImageTool)toolbaseing;
                            if (imgtool.cameraName == Frm_Service.Instance.tvw_serviceList.SelectedNode.Text)
                                imgtool.hardTrig = IsHardTrigger;
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, MyCamera> item in D_cameras)
            {
                if (item.Key == CameraOnlyName)
                {
                    return item.Value;
                }
            }

            return null;
        }

    }
}
