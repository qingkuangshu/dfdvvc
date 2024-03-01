using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Threading;

namespace VM_Pro
{
    /// <summary>
    /// 相机基类
    /// </summary>
    [Serializable]
    internal class SDK_Base
    {

        /// <summary>
        /// 是否循环采集
        /// </summary>
        internal bool loopGrab = false;
        /// <summary>
        /// 相机信息字符串，相当于每个相机的名字
        /// </summary>
        internal string cameraInfoStr = string.Empty;
        /// <summary>
        /// 等待硬触发采图完成
        /// </summary>
        internal bool waitingHardTrigImageArrived = false;
        /// <summary>
        /// 相机集合
        /// </summary>
        internal static List<SDK_Base> L_SDKCamera = new List<SDK_Base>();
        /// <summary>
        /// 取图回调同步信号
        /// </summary>
        [NonSerialized]
        internal static AutoResetEvent GrabEventWait = new AutoResetEvent(false);

        /// <summary>
        /// 检查相机是否存在，即系统是否识别到此相机
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <returns></returns>
        internal static bool CheckExist(string cameraName)
        {
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == cameraName)
                {
                    return ((CCamera)Project.Instance.L_Service[i]).Connected;
                }
            }
            return false;
        }
        /// <summary>
        /// 枚举相机
        /// </summary>
        /// <returns>是否成功</returns>
        internal virtual bool EnumCamera() { return false; }
        /// <summary>
        /// 抓取一张图像
        /// </summary>
        /// <returns>图像</returns>
        internal virtual HObject GrabOneImage(string cameraName) { return null; }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="exposureTime">曝光时间</param>
        internal virtual void SetExposure(int exposureTime, string cameraName) { }
        /// <summary>
        /// 设置增益
        /// </summary>
        /// <param name="exposure">增益</param>
        internal virtual void SetGain(int gain, string cameraName) { }
        /// <summary>
        /// 设置采集模式
        /// </summary>
        /// <param name="mode">0=连续采集，即异步采集  1=单次采集，即同步采集</param>
        internal virtual void SetAcquisitionMode(int mode) { }
        /// <summary>
        /// 设置采集图像的ROI
        /// </summary>
        internal virtual void SetAcqRegion(int offsetV, int offsetH, int imageH, int imageW, string cameraName) { }

        /// <summary>
        /// 相机IO输出
        /// </summary>
        /// <param name="CameraName">相机名称</param>
        /// <param name="DelayTime">输出保持时间（ms）</param>
        /// <returns>是否输出成功</returns>
        internal virtual bool IoOutout(string CameraName, int DelayTime) { return false; }

        /// <summary>
        /// 关闭所有相机
        /// </summary>
        internal virtual void CloseAll() { }
        /// <summary>
        /// 通过网卡的物理地址获取网卡名
        /// </summary>
        /// <returns>网卡名</returns>
        internal string GetAdapterNameByMacAdd(string MacAdd)
        {
            MacAdd = MacAdd.Replace("-", "");
            NetworkInterface[] networkInterface = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var item in networkInterface)
            {
                string localMacAdd = item.GetPhysicalAddress().ToString();
                if (localMacAdd == MacAdd)
                    return item.Name;
            }
            return string.Empty;
        }

    }
}
