using HalconDotNet;
using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    /// <summary>
    /// 相机服务类
    /// </summary>
    [Serializable]
    internal class CCamera : ServiceBase
    {
        internal CCamera(string s_name)
        {
            this.name = s_name;
            this.serviceType = ServiceType.Camera;
        }

        /// <summary>
        /// 相机对象锁
        /// </summary>
        internal object obj = new object();
        /// <summary>
        /// 是否已连接
        /// </summary>
        internal bool Connected
        {
            get
            {
                for (int i = 0; i < SDK_Base.L_SDKCamera.Count; i++)
                {
                    if (SDK_Base.L_SDKCamera[i].cameraInfoStr == cameraInfoStr)
                        return true;
                }
                return false;
            }
        }
        /// <summary>
        /// 采集区域的左上角行坐标
        /// </summary>
        internal int row1 = 0;
        /// <summary>
        /// 采集区域的左上角列坐标
        /// </summary>
        internal int col1 = 0;
        /// <summary>
        /// 采集区域的右下角行坐标
        /// </summary>
        internal int row2 = 1944;
        /// <summary>
        /// 采集区域的右下角列坐标
        /// </summary>
        internal int col2 = 2592;
        /// <summary>
        /// 是否将彩色图像转化成灰度图像      True：转化     False：不转化
        /// </summary>
        internal bool RGBToGray = true;
        /// <summary>
        /// 从相机采集图像时是否旋转图像      True：旋转     False：不旋转
        /// </summary>
        internal bool rotateImage = false;

        /// <summary>
        /// 硬触发模式     True：硬触发采集   False：软触发采集
        /// </summary>
        internal bool hardTrigServer = false;

        /// <summary>
        /// 默认的硬触发线型为Line0
        /// </summary>
        internal EHaridHardLine hardLine = EHaridHardLine.Line0;

        /// <summary>
        /// 从相机采集图像时图像旋转角度
        /// </summary>
        internal int rotateAngle = 180;
        /// <summary>
        /// 相机信息字符串，相当于每个相机的名字
        /// </summary>
        internal string cameraInfoStr = string.Empty;
        /// <summary>
        /// 曝光时间
        /// </summary>
        internal Int32 exposure = 100;
        /// <summary>
        /// 增益倍数
        /// </summary>
        internal int gain = 0;
        /// <summary>
        /// 对焦时的ROI区域
        /// </summary>
        internal HTuple rowFocus = 0, colFocus = 0, phiFocus = 0, length1Focus = 0, length2Focus = 0;


        /// <summary>
        /// 获取相机对象
        /// </summary>
        /// <returns></returns>
        internal SDK_Base GetCurCamera()
        {

            //for (int i = 0; i < SDK_Base.L_SDKCamera.Count; i++)
            //{

            //    if (SDK_Base.L_SDKCamera[i].cameraInfoStr == cameraInfoStr)
            //        return SDK_Base.L_SDKCamera[i];
            //}

            //return new SDK_Base();
            return SDK_Base.L_SDKCamera.Find(t => t.cameraInfoStr == cameraInfoStr);
        }

        /// <summary>
        /// 查找相机对象
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <returns></returns>
        internal static SDK_Base FindCamera(string cameraName)
        {
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == cameraName)
                {
                    for (int j = 0; j < SDK_Base.L_SDKCamera.Count; j++)
                    {
                        if (SDK_Base.L_SDKCamera[j].cameraInfoStr == ((CCamera)Project.Instance.L_Service[i]).cameraInfoStr)
                        {
                            return SDK_Base.L_SDKCamera[j];
                        }
                    }
                }
            }
            return new SDK_Base();
        }
        internal static CCamera GetCCamera(string cameraName)
        {
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == cameraName)
                {
                    return (CCamera)Project.Instance.L_Service[i];
                }
            }
            return null;
        }

        /// <summary>
        /// 硬触发线型选择
        /// </summary>
        internal enum EHaridHardLine
        { 
            Line0,
            Line1,
            Line2,
        }

    }
}
