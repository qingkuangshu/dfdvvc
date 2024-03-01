using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 每个项目都会有部分需要保存的信息，原先该部分直接保存早Project里面，在Project违反了开闭原则，故单独开辟此类，后续不同项目所需保存的信息在此更改即可
/// </summary>
namespace VM_Pro
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    internal class VmainCfg
    {
        #region 极片追溯项目

        /// <summary>
        /// 是否开启任务校验 TRUE：会绑定上位机接收信号
        /// </summary>
        internal bool isStartTaskCheckout = false;

        /// <summary>
        /// 是否开启补码上传
        /// </summary>
        internal bool isStartBuMa = false;
        /// <summary>
        /// 是否选择补传当前时段模式
        /// </summary>
        internal bool isBuTimeStage = true;
        /// <summary>
        /// 补传设定时间
        /// </summary>
        internal int UploadTime = 5;
        /// <summary>
        /// NG超限数量
        /// </summary>
        internal int NGOverrunNum = 5;

        [NonSerialized]
        /// <summary>
        /// 该信号用于上位机与光纤信号联合触发任务流程，属于极片追溯项目特有
        /// </summary>
        internal static bool isTCPandCameraRunTask = false;


        /// <summary>
        /// 根据客户端的信息，进行相应的更改
        /// </summary>
        /// <param name="ClientInfo">客户端接收信息</param>
        internal static void GetClientInfoUpdate(string ClientInfo)
        {
            if (ClientInfo == "abc")
            {
                isTCPandCameraRunTask = true;
                //Thread.Sleep(30000);
            }
            if (ClientInfo.ToUpper().Contains("V:"))
            {
                if (double.TryParse(ClientInfo.Substring(2), out double spit))
                {
                    double CameraDelay = 0.08 * 60 * 1000 / spit; //ms单位
                    //下一步，给相机相应的延时
                    try
                    {
                        foreach (var item in SDK_HIKVision.D_cameras)
                        {
                            float TriggerUs = (float)CameraDelay * 1000;
                            FuncLib.ShowMsg("已将当前相机触发延时更改为：" + (int)TriggerUs + " us");
                            item.Value.MV_CC_SetTriggerDelay_NET(TriggerUs);
                        }
                    }
                    catch (Exception ex)
                    {
                        FuncLib.ShowMessageBox("当前设置相机触发延时出现错误：" + ex.Message, InfoType.Error);
                    }
                    
                }
            }
        }

        #endregion

        #region 极片缺陷检测项目

        /// <summary>
        /// 是否启用算法
        /// </summary>
        internal bool Is_StartAlgo = true;

        /// <summary>
        /// 辅助膜区定位下边界偏移量
        /// </summary>
        internal int DownPianYi = 800;

        /// <summary>
        /// 辅助膜区定位右边界偏移量
        /// </summary>
        internal int RightPianYi = 200;

        /// <summary>
        /// 辅助牧区定位左边界偏移量
        /// </summary>
        internal int LeftPianYi = -500;

        #endregion

    }
}
