using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csIOC0640;
using System.Windows;
using System.Diagnostics;
using System.Threading;

namespace VM_Pro
{
    /// <summary>
    /// 雷赛IOC0640系列IO卡
    /// </summary>
    [Serializable]
    internal class Card_IOC0640 : CardBase
    {
        internal Card_IOC0640()
        {
            cardType = CardType.雷赛_IOC0640 ;
        }

        /// <summary>
        /// 初始化板卡
        /// </summary>
        internal override void Init(string name)
        {
            int count = 0;
            try
            {

                count = IOC0640.ioc_board_init(); 

            } 
            catch 
            { 
                FuncLib.ShowMsg(string.Format("IO卡IOC0640 [ {0} ] 连接失败！可能是未安装驱动所致", name), InfoType.Error); 
                FuncLib.ShowMessageBox(string.Format("IO卡IOC0640 [ {0} ] 连接失败！可能是未安装驱动所致", name), InfoType.Error); 
                connected = false; 
                return; 
            } 
             
            if (count == 0) 
            { 
                FuncLib.ShowMsg(string.Format("IO卡IOC0640 [ {0} ] 连接失败！未识别到运动控制卡", name), InfoType.Error); 
                FuncLib.ShowMessageBox(string.Format("IO卡IOC0640 [ {0} ] 连接失败！未识别到运动控制卡", name), InfoType.Error); 
                connected = false; 
            } 
            else 
            { 
                connected = true; 
            } 
        }
        /// <summary>
        /// 获取通用输入状态
        /// </summary>
        /// <param name="diName">名称</param>
        /// <returns>状态</returns>
        internal override OnOff GetDiSts(Di diName, bool testMode = false)
        {
            if (!connected)
                return OnOff.Off;

            //虚拟输入
            if (Project.D_diVitual[diName] != 0)
            {
                if (Project.D_diVitual[diName] == 1)
                    return OnOff.Off;
                else
                    return OnOff.On;
            }

            int actIdx = FindDiActIdxByName(diName);
            int value = IOC0640.ioc_read_inbit((ushort)0, Convert.ToUInt16(actIdx));
            if (value == 0)
                return L_diLogicLevel[actIdx - 1] ? OnOff.Off : OnOff.On;
            else
                return L_diLogicLevel[actIdx - 1] ? OnOff.On : OnOff.Off;
        }
        /// <summary>
        /// 获取通用输入状态
        /// </summary>
        /// <param name="actIdx">映射号</param>
        /// <returns>状态</returns>
        internal override OnOff GetDiSts(int actIdx, bool testMode = false)
        {
            if (!connected) 
                return OnOff.Off; 

            if (actIdx < 1) 
                return OnOff.Off; 

            int value = IOC0640.ioc_read_inbit((ushort)0, Convert.ToUInt16(actIdx));
            if (value == 0)
                return L_diLogicLevel[actIdx - 1] ? OnOff.Off : OnOff.On;
            else
                return L_diLogicLevel[actIdx - 1] ? OnOff.On : OnOff.Off;
        }
        /// <summary>
        /// 获取通用输出状态
        /// </summary>
        /// <param name="diName">名称</param>
        /// <returns>状态</returns>
        internal override OnOff GetDoSts(Do doName, bool testMode = false)
        { 
            if (!connected) 
                return OnOff.Off; 

            int actIdx = FindDoActIdxByName(doName); 
            int value = IOC0640.ioc_read_outbit((ushort)0, Convert.ToUInt16(actIdx)); 
            if (value == 0) 
                return L_doLogicLevel[actIdx - 1] ? OnOff.On : OnOff.Off; 
            else 
                return L_doLogicLevel[actIdx - 1] ? OnOff.Off : OnOff.On; 
        } 
        /// <summary>
        /// 获取通用输出状态
        /// </summary>
        /// <param name="actIdx">映射号</param>
        /// <returns>状态</returns>
        internal override OnOff GetDoSts(int actIdx, bool testMode = false)
        {
            if (!connected)
                return OnOff.Off;

            if (actIdx < 1)
                return OnOff.Off;

            int value = IOC0640.ioc_read_outbit((ushort)0, Convert.ToUInt16(actIdx));
            if (value == 0)
                return L_doLogicLevel[actIdx - 1] ? OnOff.On : OnOff.Off;
            else
                return L_doLogicLevel[actIdx - 1] ? OnOff.Off : OnOff.On;
        }
        /// <summary>
        /// 通用输出操作
        /// </summary>
        /// <param name="doName">名称</param>
        /// <param name="level">电平</param>
        internal override void SetDo(Do doName, OnOff onOff, bool testMode = false)
        {
            if (!connected)
                return;

            int doIdx = FindDoActIdxByName(doName);
            if (onOff == OnOff.On)
                IOC0640.ioc_write_outbit(0, Convert.ToUInt16(doIdx), L_doLogicLevel[doIdx - 1] ? 0 : 1);
            else
                IOC0640.ioc_write_outbit(0, Convert.ToUInt16(doIdx), L_doLogicLevel[doIdx - 1] ? 1 : 0);
        }
        /// <summary>
        /// 通用输出操作
        /// </summary>
        /// <param name="actIdx">映射号</param>
        /// <param name="level">电平</param>
        internal override void SetDo(int actIdx, OnOff onOff, bool testMode = false)
        {
            if (!connected)
                return;

            if (actIdx < 1)
                return;

            if (onOff == OnOff.On)
                IOC0640.ioc_write_outbit(0, Convert.ToUInt16(actIdx), L_doLogicLevel[actIdx - 1] ? 0 : 1);
            else
                IOC0640.ioc_write_outbit(0, Convert.ToUInt16(actIdx), L_doLogicLevel[actIdx - 1] ? 1 : 0);
        }
        /// <summary>
        /// 等待信号到达
        /// </summary>
        /// <param name="diName">输入点名称</param>
        /// <param name="level">高低电平</param>
        internal override void WaitDi(Di diName, OnOff onOff, bool testMode = false)
        {
            if (!connected)
                return;

            OnOff statu;
            do
            {
                statu = GetDiSts(diName);
                Thread.Sleep(10);
            }
            while (statu != onOff);
        }

    }
}
