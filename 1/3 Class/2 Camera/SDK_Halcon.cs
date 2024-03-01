using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HalconDotNet;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace VM_Pro
{
    /// <summary>
    /// Halcon采集接口
    /// </summary>
    [Serializable]
    internal class SDK_Halcon : SDK_Base
    {
        internal SDK_Halcon(string cameraInfoStr)
        {
            this.cameraInfoStr = cameraInfoStr;
        }

        /// <summary>
        /// 资源锁
        /// </summary>
        private object obj = new object();

        /// <summary>
        /// 相机集合   键：相机信息字符串  值：相机句柄
        /// </summary>
        private static Dictionary<string, HTuple> D_cameras = new Dictionary<string, HTuple>();
        /// <summary>
        /// 实例对象
        /// </summary>
        private static SDK_Halcon _instance;
        public static SDK_Halcon Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SDK_Halcon(string.Empty);
                return _instance;
            }
        }


        /// <summary>
        /// 枚举相机
        /// </summary>
        /// <returns></returns>
        internal override bool EnumCamera()
        {
            string[] interfaceType = new string[] { "DirectShow", "GigEVision2" };
            //遍历所有接口
            for (int i = 0; i < interfaceType.Length; i++)
            {
                HTuple info, infoValue = new HTuple();
                try
                {
                    HOperatorSet.InfoFramegrabber(new HTuple(interfaceType[i]), new HTuple("device"), out info, out infoValue);
                }
                catch
                {
                    continue;
                }
                for (int j = 0; j < infoValue.Length; j++)
                {
                    string cameraStr = string.Empty;
                    if (i == 0)         //DirectShow接口的直接就是相机字符串
                    {
                        cameraStr = infoValue;
                    }
                    else        //其它接口的需要分割出相机字符串
                    {
                        cameraStr = infoValue.TupleSelect(j).ToString();
                        cameraStr = Regex.Split(cameraStr, "device:")[1];
                        cameraStr = Regex.Split(cameraStr, "unique_name")[0];
                        cameraStr = cameraStr.Substring(0, cameraStr.Length - 3);
                    }

                    //初始化相机
                    HTuple handle;
                    try
                    {
                        HOperatorSet.OpenFramegrabber(new HTuple(interfaceType[i]),
                                                      new HTuple(0),
                                                      new HTuple(0),
                                                      new HTuple(0),
                                                      new HTuple(0),
                                                      new HTuple(0),
                                                      new HTuple(0),
                                                      new HTuple("progressive"),
                                                      new HTuple(-1),
                                                      new HTuple("default"),
                                                      new HTuple(-1),
                                                      new HTuple("false"),
                                                      new HTuple("default"),
                                                      new HTuple(cameraStr),
                                                      new HTuple(0),
                                                      new HTuple(-1),
                                                      out handle
                                                      );
                    }
                    catch
                    {
                        continue;
                    }

                    try
                    {
                        //部分相机不支持自动曝光和自动增益，会报异常
                        HOperatorSet.SetFramegrabberParam(handle, "GainAuto", "Off");
                        HOperatorSet.SetFramegrabberParam(handle, "ExposureAuto", "Off");
                    }
                    catch { }

                    string cameraInfoStr = cameraStr;
                    Frm_Welcome.ShowStep(string.Format("正在初始化相机 {0} ：{1}", i + 1, cameraInfoStr));

                    SDK_Halcon sdk_Halcon = new SDK_Halcon(cameraInfoStr);
                    L_SDKCamera.Add(sdk_Halcon);

                    D_cameras.Add(cameraInfoStr, handle);
                    Frm_Camera.Instance.cbx_cameraList.Items.Add(cameraInfoStr);
                }
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
                foreach (KeyValuePair<string, HTuple> item in D_cameras)
                {
                    if (item.Key == cameraInfoStr)
                    {
                        HOperatorSet.GrabImage(out image, item.Value);
                        break;
                    }
                }
                return image;
            }
        }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="exposure">曝光时间</param>
        internal override void SetExposure(int exposureTime, string cameraName)
        {
            foreach (KeyValuePair<string, HTuple> item in D_cameras)
            {
                if (item.Key == cameraInfoStr)
                {
                    try
                    {
                        HOperatorSet.SetFramegrabberParam(item.Value, "ExposureTimeAbs", exposureTime * 1000);
                    }
                    catch { }
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
            foreach (KeyValuePair<string, HTuple> item in D_cameras)
            {
                if (item.Key == cameraInfoStr)
                {
                    try
                    {
                        HOperatorSet.SetFramegrabberParam(item.Value, "Gain", gain);
                    }
                    catch { }
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
            foreach (KeyValuePair<string, HTuple> item in D_cameras)
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
            foreach (KeyValuePair<string, HTuple> item in D_cameras)
            {
                HOperatorSet.CloseFramegrabber(item.Value);
            }
        }

    }
}
