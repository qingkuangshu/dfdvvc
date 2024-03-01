using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using GxIAPINET;
using HalconDotNet;
using System.Diagnostics;

namespace VM_Pro
{
    /// <summary>
    /// 大恒相机
    /// </summary>
    [Serializable]
    internal class SDK_DaHeng : SDK_Base
    {
        internal SDK_DaHeng(string cameraInfoStr)
        {
            this.cameraInfoStr = cameraInfoStr;
        }

        /// <summary>
        /// 资源锁
        /// </summary>
        private object obj = new object();
        /// <summary>
        /// Factory对象
        /// </summary>
        private static IGXFactory m_objIGXFactory = null;
        /// <summary>
        /// 远端设备属性控制器对象
        /// </summary>
        private static IGXFeatureControl m_objIGXFeatureControl = null;
        /// <summary>
        /// 流层属性控制器对象
        /// </summary>
        private static IGXFeatureControl m_objIGXStreamFeatureControl = null;
        /// <summary>
        /// 相机集合   键：相机信息字符串  值：相机对象
        /// </summary>
        private static Dictionary<string, CameraType> D_cameras = new Dictionary<string, CameraType>();
        /// <summary>
        /// 实例对象
        /// </summary>
        private static SDK_DaHeng _instance;
        public static SDK_DaHeng Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SDK_DaHeng(string.Empty);
                return _instance;
            }
        }


        /// <summary>
        /// 枚举相机
        /// </summary>
        /// <returns>是否成功</returns>
        internal override bool EnumCamera()
        {
            IGXStream m_objIGXStream = null;
            m_objIGXFactory = IGXFactory.GetInstance();
            m_objIGXFactory.Init();
            List<IGXDeviceInfo> listGXDeviceInfo = new List<IGXDeviceInfo>();
            m_objIGXFactory.UpdateDeviceList(200, listGXDeviceInfo);

            for (Int32 i = 0; i < listGXDeviceInfo.Count; i++)
            {
                string adapterName = GetAdapterNameByMacAdd(listGXDeviceInfo[i].GetNICMAC().Replace("-", ""));
                string sn = listGXDeviceInfo[i].GetSN();
                string vendorName = listGXDeviceInfo[i].GetVendorName();
                string friendlyName = listGXDeviceInfo[i].GetModelName();

                if (vendorName != "Daheng Imaging")     //相应品牌的SDK只允许识别对应品牌的相机，否则采图时会出错
                    continue;
                vendorName = "DaHeng";

                IGXDevice m_objIGXDevice = m_objIGXFactory.OpenDeviceBySN(listGXDeviceInfo[i].GetSN(), GX_ACCESS_MODE.GX_ACCESS_EXCLUSIVE);
                m_objIGXFeatureControl = m_objIGXDevice.GetRemoteFeatureControl();

                if (null != m_objIGXFeatureControl)
                {
                    //设置采集模式连续采集
                    m_objIGXFeatureControl.GetEnumFeature("AcquisitionMode").SetValue("Continuous");
                    //设置触发模式为开
                    m_objIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");
                    //选择触发源为软触发
                    m_objIGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Software");
                    //设置心跳时间
                    m_objIGXFeatureControl.GetIntFeature("GevHeartbeatTimeout").SetValue(1000);
                }

                //打开流
                if (null != m_objIGXDevice)
                {
                    m_objIGXStream = m_objIGXDevice.OpenStream(0);
                    m_objIGXStreamFeatureControl = m_objIGXStream.GetFeatureControl();
                }

                // 建议用户在打开网络相机之后，根据当前网络环境设置相机的流通道包长值，
                // 以提高网络相机的采集性能,设置方法参考以下代码。
                GX_DEVICE_CLASS_LIST objDeviceClass = m_objIGXDevice.GetDeviceInfo().GetDeviceClass();
                if (GX_DEVICE_CLASS_LIST.GX_DEVICE_CLASS_GEV == objDeviceClass)
                {
                    // 判断设备是否支持流通道数据包功能
                    if (true == m_objIGXFeatureControl.IsImplemented("GevSCPSPacketSize"))
                    {
                        // 获取当前网络环境的最优包长值
                        uint nPacketSize = m_objIGXStream.GetOptimalPacketSize();
                        // 将最优包长值设置为当前设备的流通道包长值
                        m_objIGXFeatureControl.GetIntFeature("GevSCPSPacketSize").SetValue(nPacketSize);
                    }
                }

                if (null != m_objIGXStreamFeatureControl)
                {
                    //设置流层Buffer处理模式为OldestFirst
                    m_objIGXStreamFeatureControl.GetEnumFeature("StreamBufferHandlingMode").SetValue("OldestFirst");
                }

                //开启采集流通道
                if (null != m_objIGXStream)
                {
                    m_objIGXStream.StartGrab();
                }

                //发送开采命令
                if (null != m_objIGXFeatureControl)
                {
                    m_objIGXFeatureControl.GetCommandFeature("AcquisitionStart").Execute();
                }

                string cameraInfoStr = string.Format("{0} | {1} | {2} | {3}", adapterName, sn, friendlyName, vendorName);
                Frm_Welcome.ShowStep(string.Format("初始化 大恒 相机 {0} ：{1}", i + 1, cameraInfoStr));

                SDK_DaHeng sdk_DaHeng = new SDK_DaHeng(cameraInfoStr);
                L_SDKCamera.Add(sdk_DaHeng);

                CameraType cameraType = new CameraType();
                cameraType.m_objIGXDevice = m_objIGXDevice;
                cameraType.m_objIGXStream = m_objIGXStream;

                D_cameras.Add(cameraInfoStr, cameraType);
                Frm_Camera.Instance.cbx_cameraList.Items.Add(cameraInfoStr);
            }
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
                foreach (KeyValuePair<string, CameraType> item in D_cameras)
                {
                    if (item.Key == cameraInfoStr)
                    {
                        //每次发送触发命令之前清空采集输出队列
                        //防止库内部缓存帧，造成本次GXGetImage得到的图像是上次发送触发得到的图
                        if (null != item.Value.m_objIGXStream)
                        {
                            item.Value.m_objIGXStream.FlushQueue();
                        }

                        //发送软触发命令
                        if (item.Value.m_objIGXDevice != null)
                        {
                            item.Value.m_objIGXDevice.GetRemoteFeatureControl().GetCommandFeature("TriggerSoftware").Execute();
                        }

                        //获取图像
                        IImageData objIImageData = null;
                        if (null != item.Value.m_objIGXStream)
                        {
                            byte[] imageBuffer = new byte[3672 * 5496];
                            objIImageData = item.Value.m_objIGXStream.GetImage(5000);
                            int width = (int)objIImageData.GetWidth();
                            int height = (int)objIImageData.GetHeight();
                            IntPtr pImg = objIImageData.GetBuffer();
                            Marshal.Copy(pImg, imageBuffer, 0, width * height);
                            HOperatorSet.GenImage1(out image, "byte", width, height, pImg);
                            Thread.Sleep(100);
                        }
                        if (null != objIImageData)
                            objIImageData.Destroy();
                        break;
                    }
                }
                return image;
            }
        }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="exposure">曝光时间，单位：ms</param>
        internal override void SetExposure(int exposure, string cameraName)
        {
            foreach (KeyValuePair<string, CameraType> item in D_cameras)
            {
                if (item.Key == cameraInfoStr)
                {
                    double minExposure = item.Value.m_objIGXDevice.GetRemoteFeatureControl().GetFloatFeature("ExposureTime").GetMin();
                    double maxExposure = item.Value.m_objIGXDevice.GetRemoteFeatureControl().GetFloatFeature("ExposureTime").GetMax();
                    if (exposure * 1000 < minExposure || exposure * 1000 > maxExposure)
                    {
                        FuncLib.ShowMessageBox(string.Format("设置曝光时间失败，请检查！相机：{0}\r\n        可能原因 : 1、 曝光值不在有效范围：{1} - {2} ms之间", cameraName, Math.Round(minExposure / 1000, 3), Math.Round(maxExposure / 1000, 3)), InfoType.Error);
                        FuncLib.ShowMsg(string.Format("设置曝光时间失败，请检查！相机：{0}\r\n        可能原因 : 1、 曝光值不在有效范围：{1} - {2} ms之间", cameraName, Math.Round(minExposure / 1000, 3), Math.Round(maxExposure / 1000, 3)), InfoType.Error);
                        return;
                    }
                    item.Value.m_objIGXDevice.GetRemoteFeatureControl().GetFloatFeature("ExposureTime").SetValue(exposure * 1000);
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
            foreach (KeyValuePair<string, CameraType> item in D_cameras)
            {
                if (item.Key == cameraInfoStr)
                {
                    double minGain = item.Value.m_objIGXDevice.GetRemoteFeatureControl().GetFloatFeature("Gain").GetMin();
                    double maxGain = item.Value.m_objIGXDevice.GetRemoteFeatureControl().GetFloatFeature("Gain").GetMax();
                    if (gain < minGain || gain > maxGain)
                    {
                        FuncLib.ShowMessageBox(string.Format("设置曝光时间失败，请检查！相机：{0}\r\n        可能原因 : 1、 曝光值不在有效范围：{1} - {2} ms之间", cameraName, Math.Round(minGain / 1000, 3), Math.Round(maxGain / 1000, 3)), InfoType.Error);
                        FuncLib.ShowMsg(string.Format("设置曝光时间失败，请检查！相机：{0}\r\n        可能原因 : 1、 曝光值不在有效范围：{1} - {2} ms之间", cameraName, Math.Round(minGain / 1000, 3), Math.Round(maxGain / 1000, 3)), InfoType.Error);
                        return;
                    }
                    item.Value.m_objIGXDevice.GetRemoteFeatureControl().GetFloatFeature("Gain").SetValue(gain);
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
            foreach (KeyValuePair<string, CameraType> item in D_cameras)
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
            foreach (KeyValuePair<string, CameraType> item in D_cameras)
            {
                item.Value.m_objIGXDevice.GetRemoteFeatureControl().GetCommandFeature("AcquisitionStop").Execute();
                //停止流通道和关闭流
                if (null != item.Value.m_objIGXStream)
                {
                    item.Value.m_objIGXStream.StopGrab();
                    item.Value.m_objIGXStream.Close();
                }
            }
        }

    }

    /// <summary>
    /// 相机类型
    /// </summary>
    public struct CameraType
    {
        public IGXDevice m_objIGXDevice;
        public IGXStream m_objIGXStream;
    }

}
