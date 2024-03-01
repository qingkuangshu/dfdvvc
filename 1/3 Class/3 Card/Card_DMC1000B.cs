using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csDmc1000;
using System.Threading;
using System.Drawing;
using System.Diagnostics;

namespace VM_Pro
{
    /// <summary>
    /// 雷赛DMC1000B系列运动控制卡控制类
    /// </summary>
    [Serializable]
    internal class Card_DMC1000B : CardBase
    {
        internal Card_DMC1000B()
        {
            cardType = CardType.雷赛_DMC1000B;
        }

        /// <summary>
        /// 初始化板卡
        /// </summary>
        internal override void Init(string name)
        {
            //初始化板卡
            int count = 0;
            try
            {
                count = Dmc1000.d1000_board_init();
            }
            catch
            {
                FuncLib.ShowMsg(string.Format("运动控制卡DMC1000B [ {0} ] 连接失败！可能是未安装驱动所致", name), InfoType.Error);
                FuncLib.ShowMessageBox(string.Format("运动控制卡DMC1000B [ {0} ] 连接失败！可能是未安装驱动所致", name), InfoType.Error);
                connected = false;
                return;
            }

            if (count == 0)
            {
                FuncLib.ShowMsg(string.Format("运动控制卡DMC1000B [ {0} ] 连接失败！未识别到运动控制卡", name), InfoType.Error);
                FuncLib.ShowMessageBox(string.Format("运动控制卡DMC1000B [ {0} ] 连接失败！未识别到运动控制卡", name), InfoType.Error);
                connected = false;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    //指定脉冲输出方式
                    Dmc1000.d1000_set_pls_outmode(i, L_pulseMode[i]);
                }

                connected = true;
            }
        }
        /// <summary>
        /// 设置脉冲输出方式
        /// </summary>
        /// <param name="axisIndex"></param>
        /// <param name="mode"></param>
        internal override void SetPulseMode(int axisIndex)
        {
            Dmc1000.d1000_set_pls_outmode(axisIndex, L_pulseMode[axisIndex]);
        }
        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="axisIndex"></param>
        internal override bool Home(int axisIndex, bool testMode = false)
        {
            if (!connected)
            {
                if (testMode)
                    ShowMsg("回零失败！运动控制卡未连接", InfoType.Error);
                else
                    FuncLib.ShowMsg("回零失败！运动控制卡未连接", InfoType.Error);
                return false;
            }

            if (testMode)
                ShowMsg(string.Format("01  轴{0} 开始回零，回零方向：{1}", axisIndex + 1, L_homeDir[axisIndex].ToString()), InfoType.Tip);

            if (L_homeDir[axisIndex] == Dir.N_负方向)       //向负方向回零
            {
                if (!InHome(axisIndex, testMode))       //如果不在原点
                {
                    if (InNEL(axisIndex))       //如果在负极限
                    {
                        if (testMode)
                            ShowMsg("02  感应片在负限位，开始向正向回退，直到感应到原点", InfoType.Tip);
                        Dmc1000.d1000_start_tv_move(axisIndex, (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                        while (!InHome(axisIndex, testMode))
                        {
                            Thread.Sleep(100);
                        }
                        Dmc1000.d1000_decel_stop(axisIndex);
                        if (!WaitMoveDone(axisIndex))
                        {
                            if (testMode)
                            {
                                Dmc1000.d1000_decel_stop(axisIndex);
                                ShowMsg("03  回零失败，运动超时", InfoType.Error);
                            }
                            return false;
                        }
                        Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                        if (!WaitMoveDone(axisIndex))
                        {
                            if (testMode)
                            {
                                Dmc1000.d1000_decel_stop(axisIndex);
                                ShowMsg("04  回零失败，运动超时", InfoType.Error);
                            }
                            return false;
                        }

                        if (testMode)
                            ShowMsg("03  回退完成,开始寻找原点", InfoType.Tip);
                        Dmc1000.d1000_home_move(axisIndex, (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                        if (!WaitMoveDone(axisIndex))
                        {
                            if (testMode)
                            {
                                Dmc1000.d1000_decel_stop(axisIndex);
                                ShowMsg("04  回零失败，运动超时", InfoType.Error);
                            }
                            return false;
                        }
                        if (testMode)
                            ShowMsg("04  回零完成", InfoType.Warn);
                    }
                    else         //如果不在负极限
                    {
                        if (InPEL(axisIndex))       //如果在正极限
                        {
                            if (testMode)
                                ShowMsg("02  感应片在正限位，开始向负向高度运行", InfoType.Tip);
                            Dmc1000.d1000_start_tv_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] * 5), 0.1);
                            while (!InHome(axisIndex, testMode))
                            {
                                Thread.Sleep(100);
                            }
                            Dmc1000.d1000_decel_stop(axisIndex);
                            if (!WaitMoveDone(axisIndex))
                            {
                                if (testMode)
                                {
                                    Dmc1000.d1000_decel_stop(axisIndex);
                                    ShowMsg("03  回零失败，运动超时", InfoType.Error);
                                }
                                return false;
                            }

                            if (testMode)
                                ShowMsg("03  已运动到原点位，开始回退", InfoType.Tip);
                            Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                            if (!WaitMoveDone(axisIndex))
                            {
                                if (testMode)
                                {
                                    Dmc1000.d1000_decel_stop(axisIndex);
                                    ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                }
                                return false;
                            }

                            if (testMode)
                                ShowMsg("04  回退完成,开始寻找原点", InfoType.Tip);
                            Dmc1000.d1000_home_move(axisIndex, -(int)L_homeVel[axisIndex] / 3, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                            if (!WaitMoveDone(axisIndex))
                            {
                                if (testMode)
                                {
                                    Dmc1000.d1000_decel_stop(axisIndex);
                                    ShowMsg("05  回零失败，运动超时", InfoType.Error);
                                }
                                return false;
                            }
                            if (testMode)
                                ShowMsg("05  回零完成", InfoType.Warn);
                        }
                        else         //如果不在正极限
                        {
                            if (testMode)
                                ShowMsg("02  感应片不在原点和正负限位，开始向负向高速运行", InfoType.Tip);
                            Dmc1000.d1000_start_tv_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] * 5), 0.1);
                            Stopwatch sw = new Stopwatch();
                            sw.Start();
                            while (!InHome(axisIndex, testMode) && !InNEL(axisIndex) && sw.ElapsedMilliseconds < 20000)
                            {
                                Thread.Sleep(100);
                            }
                            if (!InHome(axisIndex, testMode) && !InNEL(axisIndex))
                            {
                                if (testMode)
                                {
                                    Dmc1000.d1000_decel_stop(axisIndex);
                                    ShowMsg("03  回零失败，运动超时", InfoType.Error);
                                }
                                Dmc1000.d1000_decel_stop(axisIndex);
                                return false;
                            }

                            Dmc1000.d1000_immediate_stop(axisIndex);

                            if (InNEL(axisIndex))        //如果在负限位
                            {
                                if (testMode)
                                    ShowMsg("03  感应片在负限位，开始向正向回退，直到感应到原点", InfoType.Tip);
                                Dmc1000.d1000_start_tv_move(axisIndex, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                while (!InHome(axisIndex, testMode))
                                {
                                    Thread.Sleep(100);
                                }
                                Dmc1000.d1000_decel_stop(axisIndex);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    if (testMode)
                                    {
                                        Dmc1000.d1000_decel_stop(axisIndex);
                                        ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                    }
                                    return false;
                                }
                                Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    if (testMode)
                                    {
                                        Dmc1000.d1000_decel_stop(axisIndex);
                                        ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                    }
                                    return false;
                                }

                                if (testMode)
                                    ShowMsg("04  回退完成,开始寻找原点", InfoType.Tip);
                                Dmc1000.d1000_home_move(axisIndex, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    if (testMode)
                                        ShowMsg("05  回零失败，运动超时", InfoType.Error);
                                    return false;
                                }
                                if (testMode)
                                    ShowMsg("05  回零完成", InfoType.Warn);
                            }
                            else
                            {
                                //如果当前处在原点，那么低速重新回原点
                                if (testMode)
                                    ShowMsg("03  感应片在原点位，开始回退", InfoType.Tip);
                                Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    if (testMode)
                                    {
                                        Dmc1000.d1000_decel_stop(axisIndex);
                                        ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                    }
                                    return false;
                                }
                                if (InHome(axisIndex, testMode))
                                {
                                    if (testMode)
                                        ShowMsg("04  回零失败，原因：感应宽度数值过小距离不足", InfoType.Error);
                                    return false;
                                }
                                else
                                {
                                    if (testMode)
                                        ShowMsg("05  回退完成，开始寻找原点", InfoType.Tip);
                                    Dmc1000.d1000_home_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                    if (!WaitMoveDone(axisIndex))
                                    {
                                        if (testMode)
                                        {
                                            Dmc1000.d1000_decel_stop(axisIndex);
                                            ShowMsg("05  回零失败，运动超时", InfoType.Error);
                                        }
                                        return false;
                                    }
                                    if (testMode)
                                        ShowMsg("06  回零完成", InfoType.Warn);
                                }
                            }
                        }
                    }
                }
                else        //如果在原点
                {
                    if (testMode)
                        ShowMsg("02  感应片在原点位，开始回退", InfoType.Tip);
                    Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                    WaitMoveDone(axisIndex);
                    if (InHome(axisIndex, testMode))
                    {
                        if (testMode)
                            ShowMsg("03  回零失败，原因：感应宽度数值过小距离不足", InfoType.Error);
                        return false;
                    }
                    else
                    {
                        if (testMode)
                            ShowMsg("04  回退完成，开始寻找原点", InfoType.Tip);
                        Dmc1000.d1000_home_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                        if (!WaitMoveDone(axisIndex))
                        {
                            if (testMode)
                            {
                                Dmc1000.d1000_decel_stop(axisIndex);
                                ShowMsg("05  回零失败，运动超时", InfoType.Error);
                            }
                            return false;
                        }
                        if (testMode)
                            ShowMsg("05  回零完成", InfoType.Warn);
                    }
                }
            }
            else        //向正方向回零
            {
                //尚未完善
            }
            Thread.Sleep(20);
            Dmc1000.d1000_set_command_pos(axisIndex, 0);

            Project.L_axis[axisIndex].homeOK = true;
            return true;
        }
        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="axisName">轴枚举</param>
        internal override bool Home(Axis axisName)
        {
            if (vitualCard)
                return true;

            if (!connected)
            {
                FuncLib.ShowMsg(axisName + " 回零失败！运动控制卡未连接", InfoType.Error);
                return false;
            }

            int axisIndex = FindAxisByName(axisName).actNo;
            if (L_homeDir[axisIndex] == Dir.N_负方向)       //向负方向回零
            {
                if (!InHome(axisIndex, false))       //如果不在原点
                {
                    if (InNEL(axisIndex))       //如果在负极限
                    {
                        Dmc1000.d1000_start_tv_move(axisIndex, (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                        while (!InHome(axisIndex, false))
                        {
                            Thread.Sleep(100);
                        }
                        Dmc1000.d1000_decel_stop(axisIndex);
                        if (!WaitMoveDone(axisIndex))
                        {
                            Dmc1000.d1000_decel_stop(axisIndex);
                            ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                            return false;
                        }
                        Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                        if (!WaitMoveDone(axisIndex))
                        {
                            Dmc1000.d1000_decel_stop(axisIndex);
                            ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                            return false;
                        }

                        Dmc1000.d1000_home_move(axisIndex, (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                        if (!WaitMoveDone(axisIndex))
                        {
                            Dmc1000.d1000_decel_stop(axisIndex);
                            ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                            return false;
                        }
                    }
                    else         //如果不在负极限
                    {
                        if (InPEL(axisIndex))       //如果在正极限
                        {
                            Dmc1000.d1000_start_tv_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] * 5), 0.1);
                            while (!InHome(axisIndex, false))
                            {
                                Thread.Sleep(100);
                            }
                            Dmc1000.d1000_decel_stop(axisIndex);
                            if (!WaitMoveDone(axisIndex))
                            {
                                Dmc1000.d1000_decel_stop(axisIndex);
                                ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                                return false;
                            }

                            Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                            if (!WaitMoveDone(axisIndex))
                            {
                                Dmc1000.d1000_decel_stop(axisIndex);
                                ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                                return false;
                            }

                            Dmc1000.d1000_home_move(axisIndex, -(int)L_homeVel[axisIndex] / 3, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                            if (!WaitMoveDone(axisIndex))
                            {
                                Dmc1000.d1000_decel_stop(axisIndex);
                                ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                                return false;
                            }
                        }
                        else         //如果不在正极限
                        {
                            Dmc1000.d1000_start_tv_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] * 5), 0.1);
                            Stopwatch sw = new Stopwatch();
                            sw.Start();
                            while (!InHome(axisIndex, false) && !InNEL(axisIndex) && sw.ElapsedMilliseconds < 20000)
                            {
                                Thread.Sleep(100);
                            }
                            if (!InHome(axisIndex, false) && !InNEL(axisIndex))
                            {
                                Dmc1000.d1000_decel_stop(axisIndex);
                                ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                                Dmc1000.d1000_decel_stop(axisIndex);
                                return false;
                            }

                            Dmc1000.d1000_immediate_stop(axisIndex);

                            if (InNEL(axisIndex))        //如果在负限位
                            {
                                Dmc1000.d1000_start_tv_move(axisIndex, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                while (!InHome(axisIndex, false))
                                {
                                    Thread.Sleep(100);
                                }
                                Dmc1000.d1000_decel_stop(axisIndex);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    Dmc1000.d1000_decel_stop(axisIndex);
                                    ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                                    return false;
                                }
                                Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    Dmc1000.d1000_decel_stop(axisIndex);
                                    ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                                    return false;
                                }

                                Dmc1000.d1000_home_move(axisIndex, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    Dmc1000.d1000_decel_stop(axisIndex);
                                    ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                                    return false;
                                }
                            }
                            else
                            {
                                //如果当前处在原点，那么低速重新回原点
                                Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    Dmc1000.d1000_decel_stop(axisIndex);
                                    ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                                    return false;
                                }
                                if (InHome(axisIndex, false))
                                {
                                    ShowMsg(string.Format("{0}  回零失败，原因：感应宽度数值过小距离不足", axisName.ToString()), InfoType.Error);
                                    return false;
                                }
                                else
                                {
                                    Dmc1000.d1000_home_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                    if (!WaitMoveDone(axisIndex))
                                    {
                                        Dmc1000.d1000_decel_stop(axisIndex);
                                        ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
                else        //如果在原点
                {
                    Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                    WaitMoveDone(axisIndex);
                    if (InHome(axisIndex, false))
                    {
                        ShowMsg(string.Format("{0}  回零失败，原因：感应宽度数值过小距离不足", axisName.ToString()), InfoType.Error);
                        return false;
                    }
                    else
                    {
                        Dmc1000.d1000_home_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                        if (!WaitMoveDone(axisIndex))
                        {
                            Dmc1000.d1000_decel_stop(axisIndex);
                            ShowMsg(string.Format("{0}  回零失败，运动超时", axisName.ToString()), InfoType.Error);
                            return false;
                        }
                    }
                }
            }
            else        //向正方向回零
            {
                //尚未完善
            }
            Thread.Sleep(20);
            Dmc1000.d1000_set_command_pos(axisIndex, 0);

            for (int i = 0; i < Project.L_axis.Count; i++)
            {
                if (Project.L_axis[i].axisName == axisName.ToString())
                {
                    Project.L_axis[i].homeOK = true;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// 当前是否在原点
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        /// <returns>是否在原点</returns>
        internal override bool InHome(int axisIndex, bool testMode)
        {
            if (!connected)
                return false;

            if (axisIndex < 0)
                return false;

            int statu = Dmc1000.d1000_get_axis_status(axisIndex);
            bool result = GetBit16((ushort)statu, 2);
            if (L_OriginLogic[axisIndex] == LogicLevel.高电平有效)
            {
                if (result)
                    return true;
                else
                    return false;
            }
            else
            {
                if (result)
                    return true;
                else
                    return false;
            }
        }
        /// <summary>
        /// 当前是否在正限位
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        /// <returns>是否在正限位</returns>
        internal override bool InPEL(int axisIndex, bool testMode = false)
        {
            if (!connected)
                return true;

            if (axisIndex < 0)
                return false;

            int temp = Dmc1000.d1000_get_axis_status(axisIndex);
            bool result = GetBit16((ushort)temp, 1);
            if (L_PLimitLogic[axisIndex] == LogicLevel.高电平有效)
            {
                if (result)
                    return true;
                else
                    return false;
            }
            else
            {
                if (result)
                    return false;
                else
                    return true;
            }
        }
        /// <summary>
        /// 当前是否在负限位
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        /// <returns>是否在限位</returns>
        internal override bool InNEL(int axisIndex, bool testMode = false)
        {
            if (!connected)
                return true;

            if (axisIndex < 0)
                return false;

            int temp = Dmc1000.d1000_get_axis_status(axisIndex);
            bool result = GetBit16_1((ushort)temp, 0);
            if (L_NLimitLogic[axisIndex] == LogicLevel.高电平有效)
            {
                if (result)
                    return true;
                else
                    return false;
            }
            else
            {
                if (result)
                    return false;
                else
                    return true;
            }
        }
        /// <summary>
        /// 获取指定轴报警状态
        /// </summary>
        /// <param name="axisIndex">轴索引</param>
        /// <returns>轴是否报警</returns>
        internal override bool IsAlarm(int axisIndex, bool testMode = false)
        {
            if (!connected)
                return false;

            if (axisIndex < 0)
                return false;

            //此款板卡不支持报警输入
            return false;
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
            int value = Dmc1000.d1000_in_bit(actIdx);
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

            if (actIdx < 0)
                return 0;

            int value = Dmc1000.d1000_in_bit(actIdx);
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
            int value = Dmc1000.d1000_get_outbit(actIdx);
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

            if (actIdx < 0)
                return 0;

            int value = Dmc1000.d1000_get_outbit(actIdx);
            if (value == 0)
                return L_doLogicLevel[actIdx - 1] ? OnOff.On : OnOff.Off;
            else
                return L_doLogicLevel[actIdx - 1] ? OnOff.Off : OnOff.On;
        }
        /// <summary>
        /// 通用输出操作
        /// </summary>
        /// <param name="doName">名称</param>
        /// <param name="onOff">电平</param>
        internal override void SetDo(Do doName, OnOff onOff, bool testMode = false)
        {
            if (!connected)
                return;

            int doIdx = FindDoActIdxByName(doName);
            if (onOff == OnOff.On)
                Dmc1000.d1000_out_bit(doIdx, L_doLogicLevel[doIdx - 1] ? 0 : 1);
            else
                Dmc1000.d1000_out_bit(doIdx, L_doLogicLevel[doIdx - 1] ? 1 : 0);
        }
        /// <summary>
        /// 通用输出操作
        /// </summary>
        /// <param name="actIdx">映射号</param>
        /// <param name="onOff">电平</param>
        internal override void SetDo(int actIdx, OnOff onOff, bool testMode = false)
        {
            if (!connected)
                return;

            if (actIdx < 0)
                return;

            if (onOff == OnOff.On)
                Dmc1000.d1000_out_bit(actIdx, L_doLogicLevel[actIdx - 1] ? 0 : 1);
            else
                Dmc1000.d1000_out_bit(actIdx, L_doLogicLevel[actIdx - 1] ? 1 : 0);
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
        /// <summary>
        /// 获取当前命令位置
        /// </summary>
        /// <param name="axisName">名称</param>
        /// <returns>当前命令位置</returns>
        internal override double GetCmdPos(Axis axisName, bool testMode = false)
        {
            if (!connected)
                return 0;

            int curPos;
            int axisIndex = (ushort)FindAxisByName(axisName.ToString()).actNo;
            curPos = Dmc1000.d1000_get_command_pos(axisIndex);
            return Math.Round(curPos / L_pulseRate[axisIndex], 3);
        }
        /// <summary>
        /// 获取当前命令位置
        /// </summary>
        /// <param name="axisName">轴索引</param>
        /// <returns>当前命令位置</returns>
        internal override double GetCmdPos(int axisIndex, bool testMode = false)
        {
            if (!connected)
                return 0;

            if (axisIndex < 0)
                return 0;

            int curPos;
            curPos = Dmc1000.d1000_get_command_pos(axisIndex);
            return Math.Round(curPos / L_pulseRate[axisIndex], 3);
        }
        /// <summary>
        /// 连续运动
        /// </summary>
        /// <param name="axisName">轴名称</param>
        internal override void KeepMove(Axis axisName, Dir dir, int vel, bool waitDone, bool testMode = false)
        {
            if (!connected)
            {
                if (testMode)
                    ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                else
                    FuncLib.ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                return;
            }

            int axisIndex = (ushort)FindAxisByName(axisName.ToString()).actNo;
            if (dir == Dir.N_负方向 && InNEL(axisIndex))
            {
                ShowMsg("运动失败！负限位已触发，无法继续向负向运动", InfoType.Error);
                return;
            }
            if (dir == Dir.P_正方向 && InPEL(axisIndex))
            {
                ShowMsg("运动失败！正限位已触发，无法继续向正向运动", InfoType.Error);
                return;
            }

            Dmc1000.d1000_start_tv_move(axisIndex, (int)(vel * L_pulseRate[axisIndex] / 3), (int)((dir == Dir.P_正方向 ? 1 : -1) * vel * L_pulseRate[axisIndex]), 0.1);

            if (waitDone)
                WaitMoveDone(axisIndex);
        }
        /// <summary>
        /// 连续运动
        /// </summary>
        /// <param name="axisName">轴索引</param>
        internal override void KeepMove(int axisIndex, int dir, int vel, bool waitDone, bool testMode = false)
        {
            if (!connected)
            {
                if (testMode)
                    ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                else
                    FuncLib.ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                return;
            }

            if (axisIndex < 0)
                return;

            if (dir == -1 && InNEL(axisIndex))
            {
                ShowMsg("运动失败！负限位已触发，无法继续向负向运动", InfoType.Error);
                return;
            }
            if (dir == 1 && InPEL(axisIndex))
            {
                ShowMsg("运动失败！正限位已触发，无法继续向正向运动", InfoType.Error);
                return;
            }

            Dmc1000.d1000_start_tv_move(axisIndex, (int)(vel * L_pulseRate[axisIndex] / 3), (int)(dir * vel * L_pulseRate[axisIndex]), 0.1);

            if (waitDone)
                WaitMoveDone(axisIndex);
        }
        /// <summary>
        /// 相对位置移动
        /// </summary>
        /// <param name="axisName">轴名称</param>
        /// <param name="distance">移动距离</param>
        /// <param name="vel">移动速度</param>
        /// <param name="waitDone">是否等待</param>
        /// <returns></returns>
        internal override bool MoveRel(Axis axisName, double distance, int vel, bool waitDone = true, bool testMode = false)
        {
            if (!connected)
            {
                if (testMode)
                    ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                else
                    FuncLib.ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                return false;
            }

            int axisIndex = FindAxisByName(axisName).actNo;

            if (distance < 0 && InNEL(axisIndex))
            {
                ShowMsg("运动失败！负限位已触发，无法继续向负向运动", InfoType.Error);
                return false;
            }
            if (distance > 0 && InPEL(axisIndex))
            {
                ShowMsg("运动失败！正限位已触发，无法继续向正向运动", InfoType.Error);
                return false;
            }

            double targetPos = GetCmdPos(axisIndex) + distance;
            //限位检查
            if (targetPos < L_NLimit[axisIndex])
            {
                if (testMode)
                    ShowMsg(string.Format("运动失败！目标位置超出软负极限，目标位置：{0}   软负限位：{1}", targetPos, L_NLimit[axisIndex]), InfoType.Error);
                else
                    FuncLib.ShowMsg(string.Format("运动失败！目标位置超出软负极限，目标位置：{0}   软负限位：{1}", targetPos, L_NLimit[axisIndex]), InfoType.Error);
                return false;
            }
            if (targetPos > L_PLimit[axisIndex])
            {
                if (testMode)
                    ShowMsg(string.Format("运动失败！目标位置超出软正极限，目标位置：{0}   软正限位：{1}", targetPos, L_PLimit[axisIndex]), InfoType.Error);
                else
                    FuncLib.ShowMsg(string.Format("运动失败！目标位置超出软正极限，目标位置：{0}   软正限位：{1}", targetPos, L_PLimit[axisIndex]), InfoType.Error);
                return false;
            }

            Dmc1000.d1000_start_t_move(axisIndex, (int)(targetPos * L_pulseRate[axisIndex]), (int)(vel * L_pulseRate[axisIndex]) / 3, (int)(vel * L_pulseRate[axisIndex]), 0.1);

            if (waitDone)
                WaitMoveDone(axisIndex);
            return true;
        }
        /// <summary>
        /// 相对位置移动
        /// </summary>
        /// <param name="axisIndex">轴索引</param>
        /// <param name="distance">移动距离</param>
        /// <param name="vel">移动速度</param>
        /// <param name="waitDone">是否等待</param>
        /// <returns></returns>
        internal override bool MoveRel(int axisIndex, double distance, int vel, bool waitDone = true, bool testMode = false)
        {
            if (!connected)
            {
                if (testMode)
                    ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                else
                    FuncLib.ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                return false;
            }

            if (axisIndex < 0)
                return false;

            if (distance < 0 && InNEL(axisIndex))
            {
                ShowMsg("运动失败！负限位已触发，无法继续向负向运动", InfoType.Error);
                return false;
            }
            if (distance > 0 && InPEL(axisIndex))
            {
                ShowMsg("运动失败！正限位已触发，无法继续向正向运动", InfoType.Error);
                return false;
            }

            double targetPos = GetCmdPos(axisIndex) + distance;
            //限位检查
            if (targetPos < L_NLimit[axisIndex])
            {
                if (testMode)
                    ShowMsg(string.Format("运动失败！目标位置超出软负极限，目标位置：{0}   软负限位：{1}", targetPos, L_NLimit[axisIndex]), InfoType.Error);
                else
                    FuncLib.ShowMsg(string.Format("运动失败！目标位置超出软负极限，目标位置：{0}   软负限位：{1}", targetPos, L_NLimit[axisIndex]), InfoType.Error);
                return false;
            }
            if (targetPos > L_PLimit[axisIndex])
            {
                if (testMode)
                    ShowMsg(string.Format("运动失败！目标位置超出软正极限，目标位置：{0}   软正限位：{1}", targetPos, L_PLimit[axisIndex]), InfoType.Error);
                else
                    FuncLib.ShowMsg(string.Format("运动失败！目标位置超出软正极限，目标位置：{0}   软正限位：{1}", targetPos, L_PLimit[axisIndex]), InfoType.Error);
                return false;
            }

            Dmc1000.d1000_start_t_move(axisIndex, (int)(distance * L_pulseRate[axisIndex]), (int)(vel * L_pulseRate[axisIndex]) / 3, (int)(vel * L_pulseRate[axisIndex]), 0.1);

            if (waitDone)
                WaitMoveDone(axisIndex);
            return true;
        }
        /// <summary>
        /// 绝对位置移动
        /// </summary>
        /// <param name="axisName">轴名称</param>
        /// <param name="targetPos">目标位置</param>
        /// <param name="vel">移动速度</param>
        /// <param name="waitDone">是否等待</param>
        /// <returns></returns>
        internal override bool MoveAbs(string axisName, double targetPos, int vel, bool waitDone, bool testMode = false)
        {
            if (!connected)
            {
                if (testMode)
                    ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                else
                    FuncLib.ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                return false;
            }

            int axisIndex = FindAxisByName(axisName.ToString()).actNo;
            //限位检查
            if (targetPos < L_NLimit[axisIndex])
            {
                if (testMode)
                    ShowMsg(string.Format("运动失败！目标位置超出软负极限，目标位置：{0}   软负限位：{1}", targetPos, L_NLimit[axisIndex]), InfoType.Error);
                else
                    FuncLib.ShowMsg(string.Format("运动失败！目标位置超出软负极限，目标位置：{0}   软负限位：{1}", targetPos, L_NLimit[axisIndex]), InfoType.Error);
                return false;
            }
            if (targetPos > L_PLimit[axisIndex])
            {
                if (testMode)
                    ShowMsg(string.Format("运动失败！目标位置超出软正极限，目标位置：{0}   软正限位：{1}", targetPos, L_PLimit[axisIndex]), InfoType.Error);
                else
                    FuncLib.ShowMsg(string.Format("运动失败！目标位置超出软正极限，目标位置：{0}   软正限位：{1}", targetPos, L_PLimit[axisIndex]), InfoType.Error);
                return false;
            }

            Dmc1000.d1000_start_ta_move(axisIndex, (int)(targetPos * L_pulseRate[axisIndex]), (int)(vel * L_pulseRate[axisIndex]) / 3, (int)(vel * L_pulseRate[axisIndex]), 0.1);

            if (waitDone)
                WaitMoveDone(axisIndex);
            return true;
        }
        /// <summary>
        /// 立即停止
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        internal override void QuickStop(int axisIndex, bool testMode = false)
        {
            if (!connected)
                return;

            if (axisIndex < 0)
                return;

            Dmc1000.d1000_immediate_stop(axisIndex);
            WaitMoveDone(axisIndex);
        }
        /// <summary>
        /// 立即停止
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        internal override void QuickStop(Axis axisName)
        {
            if (!connected)
                return;
            int index = FindAxisByName(axisName).actNo;
            Dmc1000.d1000_immediate_stop(index);
            WaitMoveDone(index);
        }
        /// <summary>
        /// 减速停止
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        internal override void DecStop(int axisIndex, bool testMode = false)
        {
            if (!connected)
                return;

            if (axisIndex < 0)
                return;

            Dmc1000.d1000_decel_stop(axisIndex);
            WaitMoveDone(axisIndex);
        }
        /// <summary>
        /// 减速停止
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        internal override void DecStop(Axis axisName)
        {
            if (!connected)
                return;
            int index = FindAxisByName(axisName).actNo;
            Dmc1000.d1000_decel_stop(index);
            WaitMoveDone(index);
        }
        /// <summary>
        /// 等待运动完成
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        internal override bool WaitMoveDone(int axisIndex, int checkInp = 0, bool testMode = false)
        {
            if (axisIndex < 0)
                return false;

            Thread.Sleep(100);
            int statu;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            do
            {
                statu = Dmc1000.d1000_check_done(axisIndex);
                Thread.Sleep(10);
            } while (statu == 0 && sw.ElapsedMilliseconds < 20000);

            if (statu == 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 关闭运动控制卡
        /// </summary>
        internal override void Close()
        {
            if (!connected)
                return;

            Dmc1000.d1000_board_close();
        }
        /// <summary>
        /// 获取位状态(16位版)
        /// </summary>
        /// <param name="vaule">对象值</param>
        /// <param name="position">第几位</param>
        /// <returns></returns>
        public static bool GetBit16(UInt16 vaule, byte position)
        {
            uint pos = 1;
            pos = pos << position;
            return (vaule & (0xffffffff & pos)) > 1;
        }
        /// <summary>
        /// 获取位状态(16位版)
        /// </summary>
        /// <param name="vaule">对象值</param>
        /// <param name="position">第几位</param>
        /// <returns></returns>
        public static bool GetBit16_1(UInt16 vaule, byte position)
        {
            uint pos = 1;
            pos = pos << position;
            return (vaule >> position & 1) == 1;
        }

    }
}
