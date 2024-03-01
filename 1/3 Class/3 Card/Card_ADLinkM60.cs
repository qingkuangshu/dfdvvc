using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csDmc1000;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using lctdevice;

namespace VM_Pro
{
    /// <summary>
    /// 凌臣M60系列运动控制卡控制类
    /// </summary>
    [Serializable]
    internal class Card_ADLinkM60 : CardBase
    {
        internal Card_ADLinkM60()
        {
            cardType = CardType.凌臣_M30;
        }

        /// <summary>
        /// 从站资源
        /// </summary>
        short SlaveNum = 0;  //从站数量
        short AxisNum = 0;   //伺服数量 
        short IoSlaveNum = 0;//IO从站数
        short DiNum = 0;     //Di数量
        short DoNum = 0;     //Do数量
        short AiNum = 0;     //Ai数量
        short AoNum = 0;     //Ao数量


        /// <summary>
        /// 初始化板卡
        /// </summary>
        internal override void Init(string name)
        {
            //关闭轴卡（针对上次没有正常关闭轴卡的情况）
            try
            {
                ecat_motion.M_Close(0);
                Thread.Sleep(100);
            }
            catch { }

            //初始化板卡
            short ret = 0;
            try
            {
                ret = ecat_motion.M_Open(0, 0);//第2个参数为预留参数,无效
            }
            catch
            {
                FuncLib.ShowMsg(string.Format("运动控制卡ADLinkM60 [ {0} ] 连接失败！可能是未安装驱动所致", name), InfoType.Error);
                FuncLib.ShowMessageBox(string.Format("运动控制卡ADLinkM60 [ {0} ] 连接失败！可能是未安装驱动所致", name), InfoType.Error);
                connected = false;
                return;
            }

            if (ret != 0)       //连接失败
            {
                FuncLib.ShowMsg(string.Format("运动控制卡ADLinkM60 [ {0} ] 连接失败！未识别到运动控制卡", name), InfoType.Error);
                FuncLib.ShowMessageBox(string.Format("运动控制卡ADLinkM60 [ {0} ] 连接失败！未识别到运动控制卡", name), InfoType.Error);
                connected = false;
            }
            else
            {
                short senseLevel = 0;//急停极性 → 1:常闭  0：常开
                ecat_motion.M_SetEmgInv(senseLevel, 0);//设置轴卡的急停极性
                ecat_motion.M_ClrEmg(0);

                ret = ecat_motion.M_LoadEni("C:\\Program Files (x86)\\LCT\\PCIe-M60\\Eni\\eni.xml", 0);//加载eni.xml文件，该文件为驱动器和远程IO的配置文件
                if (ret == 0)
                {
                    ecat_motion.M_ResetFpga(0);//重置FPGA芯片
                    Thread.Sleep(500);//延时500ms，该延时必须有
                    ret = ecat_motion.M_ConnectECAT(1, 0);//连接总线（注：连接总线需要一定的时间，所需时间会随着从站数量的增多而变长）
                    if (ret == 0)
                    {
                        Thread.Sleep(500);//延时500ms，该延时必须有
                        ret = ecat_motion.M_LoadParamFromFile("C:\\Program Files (x86)\\LCT\\PCIe-M60\\Motion_Assistant\\AxisParam\\ParamCard0.ini", 0);//从文件加载参数
                        if (ret == 0)
                        {
                            //获取从站资源（此部分可以不执行，如果想核对实际资源和线上资源是否一致，可通过获取从站资源实现）
                            ecat_motion.SL_RES Sl_res = new ecat_motion.SL_RES();  //实例ecat_motion.cs接口中用到的“SL_RES 结构体”
                            ret = ecat_motion.M_GetSlaveResource(out Sl_res, 0);//获取Ethercat网络中的从站资源
                            if (ret == 0)//如果返回值为0，即获取从站资源成功
                            {
                                SlaveNum = (short)Sl_res.SlaveNum;//变量 SlaveNum 接收从站数量
                                AxisNum = (short)Sl_res.AxisNum;//变量 ServoNum 接收轴数量
                                DiNum = (short)Sl_res.DiNum;//变量 DiNum 接收 DI数量
                                DoNum = (short)Sl_res.DoNum;//变量 DoNum 接收 DO数量
                                AiNum = (short)Sl_res.AiNum;//变量 AiNum 接收 AI数量
                                AoNum = (short)Sl_res.AoNum;//变量 AoNum 接收 AO数量
                                IoSlaveNum = (short)Sl_res.IoSlaveNum;//变量 IoSlaveNum 接收 IO从站数量

                                //伺服使能
                                for (int i = 0; i < Project.L_axis.Count; i++)
                                {
                                    MotorOn(i);
                                    ret = ecat_motion.M_SetAxisBand((short)(i + 1), 10, 10, 0);
                                    if (ret != 0)
                                    {
                                        FuncLib.ShowMsg("设置轴到位参数失败，请检查", InfoType.Error);
                                        break;
                                    }
                                }
                                connected = true;
                            }
                        }
                        else
                        {
                            FuncLib.ShowMsg(string.Format("运动控制卡ADLinkM60 [ {0} ] 连接失败！未识别到运动控制卡", name), InfoType.Error);
                            FuncLib.ShowMessageBox(string.Format("运动控制卡ADLinkM60 [ {0} ] 连接失败！未识别到运动控制卡\r\n        可能原因：1、急停已按下", name), InfoType.Error);
                            connected = false;
                        }
                    }
                    else
                    {
                        FuncLib.ShowMsg(string.Format("运动控制卡ADLinkM60 [ {0} ] 连接失败！未识别到运动控制卡", name), InfoType.Error);
                        FuncLib.ShowMessageBox(string.Format("运动控制卡ADLinkM60 [ {0} ] 连接失败！未识别到运动控制卡", name), InfoType.Error);
                        connected = false;
                    }
                }
                else
                {
                    FuncLib.ShowMsg(string.Format("运动控制卡ADLinkM60 [ {0} ] 连接失败！未识别到运动控制卡", name), InfoType.Error);
                    FuncLib.ShowMessageBox(string.Format("运动控制卡ADLinkM60 [ {0} ] 连接失败！未识别到运动控制卡", name), InfoType.Error);
                    connected = false;
                }
            }
        }
        /// <summary>
        /// 设置脉冲输出方式
        /// </summary>
        /// <param name="axisIndex"></param>
        /// <param name="mode"></param>
        internal override void SetPulseMode(int axisIndex)
        {
            //Dmc1000.d1000_set_pls_outmode(axisIndex, L_pulseMode[axisIndex]);
        }
        /// <summary>
        /// 清除报警
        /// </summary>
        /// <param name="axisIndex"></param>
        /// <param name="mode"></param>
        internal override void ClearAlarm()
        {
            ecat_motion.M_ClrEmg(0);
            ecat_motion.M_ClrSts(1, 20, 0);//第2个参数为将要执行的轴的数量
            Thread.Sleep(50);
        }
        /// <summary>
        /// Inp信号
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        /// <returns>是否在原点</returns>
        internal override bool Inp(int axisIndex)
        {
            if (vitualCard)
                return false;

            if (!connected)
                return false;

            if (axisIndex < 0)
                return false;

            int ServoSts = 0;
            ecat_motion.M_GetSts((short)(axisIndex + 1), out ServoSts, 1, 0);//获取轴状态

            if ((ServoSts & 0x800) == 0x800)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="axisIndex"></param>
        internal override bool Home(int axisIndex, bool testMode = false)
        {
            if (vitualCard)
                return false;

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


            MotorOn(axisIndex);
            Thread.Sleep(100);


            switch (L_homeMode[axisIndex])
            {
                case HomeMode.FindOrigin:

                    if (L_homeDir[axisIndex] == Dir.N_负方向)       //向负方向回零
                    {
                        if (!InHome(axisIndex, testMode))       //如果不在原点
                        {
                            if (InNEL(axisIndex))       //如果在负极限
                            {
                                if (testMode)
                                    ShowMsg("02  感应片在负限位，开始向正向回退，直到感应到原点", InfoType.Tip);
                                KeepMove(axisIndex, 1, (int)L_homeVel[axisIndex], false, true);
                                //Dmc1000.d1000_start_tv_move(axisIndex, (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                while (!InHome(axisIndex, testMode))
                                {
                                    Thread.Sleep(10);
                                }
                                DecStop(axisIndex);
                                //Dmc1000.d1000_decel_stop(axisIndex);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    if (testMode)
                                    {
                                        DecStop(axisIndex);
                                        ShowMsg("03  回零失败，运动超时", InfoType.Error);
                                    }
                                    return false;
                                }
                                //KeepMove(axisIndex, 1, (int)L_homeVel[axisIndex], true, true);
                                MoveRel(axisIndex, (int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                                // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    if (testMode)
                                    {
                                        DecStop(axisIndex);
                                        ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                    }
                                    return false;
                                }

                                if (testMode)
                                    ShowMsg("03  回退完成,开始寻找原点", InfoType.Tip);


                                short mode = 6;


                                short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 27, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                                ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                                if (ret != 0)
                                {
                                    if (testMode)
                                        ShowMsg("回零失败！请检查", InfoType.Error);
                                    else
                                        FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                    return false;
                                }






                                ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    if (testMode)
                                    {
                                        DecStop(axisIndex);
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
                                    KeepMove(axisIndex, -1, (int)L_homeVel[axisIndex] * 3, false, true);
                                    //Dmc1000.d1000_start_tv_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] * 5), 0.1);
                                    while (!InHome(axisIndex, testMode))
                                    {
                                        Thread.Sleep(10);
                                    }
                                    DecStop(axisIndex);
                                    if (!WaitMoveDone(axisIndex))
                                    {
                                        if (testMode)
                                        {
                                            DecStop(axisIndex);
                                            ShowMsg("03  回零失败，运动超时", InfoType.Error);
                                        }
                                        return false;
                                    }

                                    if (testMode)
                                        ShowMsg("03  已运动到原点位，开始回退", InfoType.Tip);
                                    MoveRel(axisIndex, (int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                                    // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                    if (!WaitMoveDone(axisIndex))
                                    {
                                        if (testMode)
                                        {
                                            DecStop(axisIndex);
                                            ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                        }
                                        return false;
                                    }

                                    if (testMode)
                                        ShowMsg("04  回退完成,开始寻找原点", InfoType.Tip);



                                    short mode = 6;

                                    short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 27, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                                    ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                                    if (ret != 0)
                                    {
                                        if (testMode)
                                            ShowMsg("回零失败！请检查", InfoType.Error);
                                        else
                                            FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                        return false;
                                    }



                                    ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// Dmc1000.d1000_home_move(axisIndex, -(int)L_homeVel[axisIndex] / 3, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                    if (!WaitMoveDone(axisIndex))
                                    {
                                        if (testMode)
                                        {
                                            DecStop(axisIndex);
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
                                    KeepMove(axisIndex, -1, (int)L_homeVel[axisIndex] * 3, false, true);
                                    // Dmc1000.d1000_start_tv_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] * 5), 0.1);
                                    Stopwatch sw = new Stopwatch();
                                    sw.Start();
                                    while (!InHome(axisIndex, testMode) && !InNEL(axisIndex) && sw.ElapsedMilliseconds < 20000)
                                    {
                                        Thread.Sleep(10);
                                    }
                                    if (!InHome(axisIndex, testMode) && !InNEL(axisIndex))
                                    {
                                        if (testMode)
                                        {
                                            DecStop(axisIndex);
                                            ShowMsg("03  回零失败，运动超时", InfoType.Error);
                                        }
                                        DecStop(axisIndex);
                                        return false;
                                    }

                                    QuickStop(axisIndex);
                                    //Dmc1000.d1000_immediate_stop(axisIndex);

                                    if (InNEL(axisIndex))        //如果在负限位
                                    {
                                        if (testMode)
                                            ShowMsg("03  感应片在负限位，开始向正向回退，直到感应到原点", InfoType.Tip);
                                        KeepMove(axisIndex, 1, (int)L_homeVel[axisIndex], false, true);
                                        //Dmc1000.d1000_start_tv_move(axisIndex, (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                        while (!InHome(axisIndex, testMode))
                                        {
                                            Thread.Sleep(10);
                                        }
                                        DecStop(axisIndex);
                                        //Dmc1000.d1000_decel_stop(axisIndex);
                                        if (!WaitMoveDone(axisIndex))
                                        {
                                            if (testMode)
                                            {
                                                DecStop(axisIndex);
                                                ShowMsg("03  回零失败，运动超时", InfoType.Error);
                                            }
                                            return false;
                                        }
                                        //KeepMove(axisIndex, 1, (int)L_homeVel[axisIndex], true, true);
                                        MoveRel(axisIndex, (int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                                        // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                        if (!WaitMoveDone(axisIndex))
                                        {
                                            if (testMode)
                                            {
                                                DecStop(axisIndex);
                                                ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                            }
                                            return false;
                                        }

                                        if (testMode)
                                            ShowMsg("03  回退完成,开始寻找原点", InfoType.Tip);


                                        short mode = 6;

                                        short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 27, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                                        ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                                        if (ret != 0)
                                        {
                                            if (testMode)
                                                ShowMsg("回零失败！请检查", InfoType.Error);
                                            else
                                                FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                            return false;
                                        }






                                        ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                        if (!WaitMoveDone(axisIndex))
                                        {
                                            if (testMode)
                                            {
                                                DecStop(axisIndex);
                                                ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                            }
                                            return false;
                                        }
                                        if (testMode)
                                            ShowMsg("04  回零完成", InfoType.Warn);
                                    }
                                    else
                                    {
                                        //如果当前处在原点，那么低速重新回原点
                                        if (testMode)
                                            ShowMsg("03  感应片在原点位，开始回退", InfoType.Tip);
                                        MoveRel(axisIndex, (int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                                        // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                        if (!WaitMoveDone(axisIndex))
                                        {
                                            if (testMode)
                                            {
                                                DecStop(axisIndex);
                                                ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                            }
                                            return false;
                                        }

                                        if (testMode)
                                            ShowMsg("04  回退完成,开始寻找原点", InfoType.Tip);



                                        short mode = 6;

                                        short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 27, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                                        ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                                        if (ret != 0)
                                        {
                                            if (testMode)
                                                ShowMsg("回零失败！请检查", InfoType.Error);
                                            else
                                                FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                            return false;
                                        }



                                        ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// Dmc1000.d1000_home_move(axisIndex, -(int)L_homeVel[axisIndex] / 3, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                        if (!WaitMoveDone(axisIndex))
                                        {
                                            if (testMode)
                                            {
                                                DecStop(axisIndex);
                                                ShowMsg("05  回零失败，运动超时", InfoType.Error);
                                            }
                                            return false;
                                        }
                                        if (testMode)
                                            ShowMsg("05  回零完成", InfoType.Warn);
                                    }
                                }
                            }
                        }
                        else        //如果在原点
                        {
                            if (testMode)
                                ShowMsg("02  感应片在原点位，开始回退", InfoType.Tip);
                            MoveRel(axisIndex, (int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                            // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
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




                                short mode = 6;

                                short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 27, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                                ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                                if (ret != 0)
                                {
                                    if (testMode)
                                        ShowMsg("回零失败！请检查", InfoType.Error);
                                    else
                                        FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                    return false;
                                }




                                ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// Dmc1000.d1000_home_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    if (testMode)
                                    {
                                        DecStop(axisIndex);
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
                        if (!InHome(axisIndex, testMode))       //如果不在原点
                        {
                            if (InPEL(axisIndex))       //如果在正极限
                            {
                                if (testMode)
                                    ShowMsg("02  感应片在负限位，开始向正向回退，直到感应到原点", InfoType.Tip);
                                KeepMove(axisIndex, 1, -(int)L_homeVel[axisIndex], false, true);
                                //Dmc1000.d1000_start_tv_move(axisIndex, (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                while (!InHome(axisIndex, testMode))
                                {
                                    Thread.Sleep(10);
                                }
                                DecStop(axisIndex);
                                //Dmc1000.d1000_decel_stop(axisIndex);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    if (testMode)
                                    {
                                        DecStop(axisIndex);
                                        ShowMsg("03  回零失败，运动超时", InfoType.Error);
                                    }
                                    return false;
                                }
                                //KeepMove(axisIndex, 1, (int)L_homeVel[axisIndex], true, true);
                                MoveRel(axisIndex, -(int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                                // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    if (testMode)
                                    {
                                        DecStop(axisIndex);
                                        ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                    }
                                    return false;
                                }

                                if (testMode)
                                    ShowMsg("03  回退完成,开始寻找原点", InfoType.Tip);


                                short mode = 6;


                                short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 23, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                                ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                                if (ret != 0)
                                {
                                    if (testMode)
                                        ShowMsg("回零失败！请检查", InfoType.Error);
                                    else
                                        FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                    return false;
                                }






                                ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    if (testMode)
                                    {
                                        DecStop(axisIndex);
                                        ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                    }
                                    return false;
                                }
                                if (testMode)
                                    ShowMsg("04  回零完成", InfoType.Warn);
                            }
                            else         //如果不在负极限
                            {
                                if (InNEL(axisIndex))       //如果在正极限
                                {
                                    if (testMode)
                                        ShowMsg("02  感应片在正限位，开始向负向高度运行", InfoType.Tip);
                                    KeepMove(axisIndex, -1, -(int)L_homeVel[axisIndex] * 3, false, true);
                                    //Dmc1000.d1000_start_tv_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] * 5), 0.1);
                                    while (!InHome(axisIndex, testMode))
                                    {
                                        Thread.Sleep(10);
                                    }
                                    DecStop(axisIndex);
                                    if (!WaitMoveDone(axisIndex))
                                    {
                                        if (testMode)
                                        {
                                            DecStop(axisIndex);
                                            ShowMsg("03  回零失败，运动超时", InfoType.Error);
                                        }
                                        return false;
                                    }

                                    if (testMode)
                                        ShowMsg("03  已运动到原点位，开始回退", InfoType.Tip);
                                    MoveRel(axisIndex, -(int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                                    // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                    if (!WaitMoveDone(axisIndex))
                                    {
                                        if (testMode)
                                        {
                                            DecStop(axisIndex);
                                            ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                        }
                                        return false;
                                    }

                                    if (testMode)
                                        ShowMsg("04  回退完成,开始寻找原点", InfoType.Tip);



                                    short mode = 6;

                                    short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 23, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                                    ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                                    if (ret != 0)
                                    {
                                        if (testMode)
                                            ShowMsg("回零失败！请检查", InfoType.Error);
                                        else
                                            FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                        return false;
                                    }



                                    ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// Dmc1000.d1000_home_move(axisIndex, -(int)L_homeVel[axisIndex] / 3, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                    if (!WaitMoveDone(axisIndex))
                                    {
                                        if (testMode)
                                        {
                                            DecStop(axisIndex);
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
                                    KeepMove(axisIndex, -1, -(int)L_homeVel[axisIndex] * 3, false, true);
                                    // Dmc1000.d1000_start_tv_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] * 5), 0.1);
                                    Stopwatch sw = new Stopwatch();
                                    sw.Start();
                                    while (!InHome(axisIndex, testMode) && !InNEL(axisIndex) && sw.ElapsedMilliseconds < 20000)
                                    {
                                        Thread.Sleep(10);
                                    }
                                    if (!InHome(axisIndex, testMode) && !InNEL(axisIndex))
                                    {
                                        if (testMode)
                                        {
                                            DecStop(axisIndex);
                                            ShowMsg("03  回零失败，运动超时", InfoType.Error);
                                        }
                                        DecStop(axisIndex);
                                        return false;
                                    }

                                    QuickStop(axisIndex);
                                    //Dmc1000.d1000_immediate_stop(axisIndex);

                                    if (InPEL(axisIndex))        //如果在负限位
                                    {
                                        if (testMode)
                                            ShowMsg("03  感应片在负限位，开始向正向回退，直到感应到原点", InfoType.Tip);
                                        KeepMove(axisIndex, 1, -(int)L_homeVel[axisIndex], false, true);
                                        //Dmc1000.d1000_start_tv_move(axisIndex, (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                        while (!InHome(axisIndex, testMode))
                                        {
                                            Thread.Sleep(10);
                                        }
                                        DecStop(axisIndex);
                                        //Dmc1000.d1000_decel_stop(axisIndex);
                                        if (!WaitMoveDone(axisIndex))
                                        {
                                            if (testMode)
                                            {
                                                DecStop(axisIndex);
                                                ShowMsg("03  回零失败，运动超时", InfoType.Error);
                                            }
                                            return false;
                                        }
                                        //KeepMove(axisIndex, 1, (int)L_homeVel[axisIndex], true, true);
                                        MoveRel(axisIndex, -(int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                                        // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                        if (!WaitMoveDone(axisIndex))
                                        {
                                            if (testMode)
                                            {
                                                DecStop(axisIndex);
                                                ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                            }
                                            return false;
                                        }

                                        if (testMode)
                                            ShowMsg("03  回退完成,开始寻找原点", InfoType.Tip);


                                        short mode = 6;

                                        short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 23, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                                        ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                                        if (ret != 0)
                                        {
                                            if (testMode)
                                                ShowMsg("回零失败！请检查", InfoType.Error);
                                            else
                                                FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                            return false;
                                        }






                                        ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                        if (!WaitMoveDone(axisIndex))
                                        {
                                            if (testMode)
                                            {
                                                DecStop(axisIndex);
                                                ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                            }
                                            return false;
                                        }
                                        if (testMode)
                                            ShowMsg("04  回零完成", InfoType.Warn);
                                    }
                                    else
                                    {
                                        //如果当前处在原点，那么低速重新回原点
                                        if (testMode)
                                            ShowMsg("03  感应片在原点位，开始回退", InfoType.Tip);
                                        MoveRel(axisIndex, -(int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                                        // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                        if (!WaitMoveDone(axisIndex))
                                        {
                                            if (testMode)
                                            {
                                                DecStop(axisIndex);
                                                ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                            }
                                            return false;
                                        }

                                        if (testMode)
                                            ShowMsg("04  回退完成,开始寻找原点", InfoType.Tip);



                                        short mode = 6;

                                        short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 23, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                                        ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                                        if (ret != 0)
                                        {
                                            if (testMode)
                                                ShowMsg("回零失败！请检查", InfoType.Error);
                                            else
                                                FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                            return false;
                                        }



                                        ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// Dmc1000.d1000_home_move(axisIndex, -(int)L_homeVel[axisIndex] / 3, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                        if (!WaitMoveDone(axisIndex))
                                        {
                                            if (testMode)
                                            {
                                                DecStop(axisIndex);
                                                ShowMsg("05  回零失败，运动超时", InfoType.Error);
                                            }
                                            return false;
                                        }
                                        if (testMode)
                                            ShowMsg("05  回零完成", InfoType.Warn);
                                    }
                                }
                            }
                        }
                        else        //如果在原点
                        {
                            if (testMode)
                                ShowMsg("02  感应片在原点位，开始回退", InfoType.Tip);
                            MoveRel(axisIndex, -(int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                            // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
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




                                short mode = 6;

                                short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 23, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                                ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                                if (ret != 0)
                                {
                                    if (testMode)
                                        ShowMsg("回零失败！请检查", InfoType.Error);
                                    else
                                        FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                    return false;
                                }




                                ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// Dmc1000.d1000_home_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                                if (!WaitMoveDone(axisIndex))
                                {
                                    if (testMode)
                                    {
                                        DecStop(axisIndex);
                                        ShowMsg("05  回零失败，运动超时", InfoType.Error);
                                    }
                                    return false;
                                }
                                if (testMode)
                                    ShowMsg("05  回零完成", InfoType.Warn);
                            }
                        }
                    }
                    Thread.Sleep(20);

                    break;
                case HomeMode.FindNLimit:

                    if (L_homeDir[axisIndex] == Dir.N_负方向)       //向负方向回零
                    {
                        if (InNEL(axisIndex))       //如果在负极限
                        {
                            if (testMode)
                                ShowMsg("02  感应片在负限位，开始向正向回退，直到感应到原点", InfoType.Tip);

                            //KeepMove(axisIndex, 1, (int)L_homeVel[axisIndex], true, true);
                            MoveRel(axisIndex, (int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                            // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                            if (!WaitMoveDone(axisIndex))
                            {
                                if (testMode)
                                {
                                    DecStop(axisIndex);
                                    ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                }
                                return false;
                            }

                            if (testMode)
                                ShowMsg("03  回退完成,开始寻找原点", InfoType.Tip);


                            short mode = 6;


                            short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 17, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                            ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                            if (ret != 0)
                            {
                                if (testMode)
                                    ShowMsg("回零失败！请检查", InfoType.Error);
                                else
                                    FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                return false;
                            }






                            ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                            if (!WaitMoveDone(axisIndex))
                            {
                                if (testMode)
                                {
                                    DecStop(axisIndex);
                                    ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                }
                                return false;
                            }
                            if (testMode)
                                ShowMsg("04  回零完成", InfoType.Warn);
                        }
                        else         //如果不在负极限
                        {
                            if (testMode)
                                ShowMsg("02  感应片在正限位，开始向负向高度运行", InfoType.Tip);
                            KeepMove(axisIndex, -1, (int)L_homeVel[axisIndex] * 3, false, true);
                            //Dmc1000.d1000_start_tv_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] * 5), 0.1);
                            while (!InNEL(axisIndex, testMode))
                            {
                                Thread.Sleep(10);
                            }
                            DecStop(axisIndex);
                            if (!WaitMoveDone(axisIndex, 0))
                            {
                                if (testMode)
                                {
                                    DecStop(axisIndex);
                                    ShowMsg("03  回零失败，运动超时", InfoType.Error);
                                }
                                return false;
                            }

                            if (testMode)
                                ShowMsg("03  已运动到原点位，开始回退", InfoType.Tip);
                            MoveRel(axisIndex, (int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                            // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                            if (!WaitMoveDone(axisIndex))
                            {
                                if (testMode)
                                {
                                    DecStop(axisIndex);
                                    ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                }
                                return false;
                            }

                            if (testMode)
                                ShowMsg("04  回退完成,开始寻找原点", InfoType.Tip);



                            short mode = 6;

                            short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 17, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                            ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                            if (ret != 0)
                            {
                                if (testMode)
                                    ShowMsg("回零失败！请检查", InfoType.Error);
                                else
                                    FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                return false;
                            }



                            ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// Dmc1000.d1000_home_move(axisIndex, -(int)L_homeVel[axisIndex] / 3, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                            if (!WaitMoveDone(axisIndex))
                            {
                                if (testMode)
                                {
                                    DecStop(axisIndex);
                                    ShowMsg("05  回零失败，运动超时", InfoType.Error);
                                }
                                return false;
                            }
                            if (testMode)
                                ShowMsg("05  回零完成", InfoType.Warn);

                        }
                    }
                    Thread.Sleep(20);

                    break;
                case HomeMode.FindPLimit:

                    if (L_homeDir[axisIndex] == Dir.P_正方向)       //向负方向回零
                    {
                        if (InPEL(axisIndex))       //如果在正极限
                        {
                            if (testMode)
                                ShowMsg("02  感应片在负限位，开始向正向回退，直到感应到原点", InfoType.Tip);

                            //KeepMove(axisIndex, 1, (int)L_homeVel[axisIndex], true, true);
                            MoveRel(axisIndex, -(int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                            // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                            if (!WaitMoveDone(axisIndex))
                            {
                                if (testMode)
                                {
                                    DecStop(axisIndex);
                                    ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                }
                                return false;
                            }

                            if (testMode)
                                ShowMsg("03  回退完成,开始寻找原点", InfoType.Tip);


                            short mode = 6;


                            short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 18, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                            ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                            if (ret != 0)
                            {
                                if (testMode)
                                    ShowMsg("回零失败！请检查", InfoType.Error);
                                else
                                    FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                return false;
                            }






                            ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// (int)L_homeVel[axisIndex] / 3, (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                            if (!WaitMoveDone(axisIndex))
                            {
                                if (testMode)
                                {
                                    DecStop(axisIndex);
                                    ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                }
                                return false;
                            }
                            if (testMode)
                                ShowMsg("04  回零完成", InfoType.Warn);
                        }
                        else         //如果不在正极限
                        {
                            if (testMode)
                                ShowMsg("02  感应片在正限位，开始向负向高度运行", InfoType.Tip);
                            KeepMove(axisIndex, 1, (int)L_homeVel[axisIndex] * 3, false, true);
                            //Dmc1000.d1000_start_tv_move(axisIndex, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] * 5), 0.1);
                            while (!InPEL(axisIndex, testMode))
                            {
                                Thread.Sleep(10);
                            }
                            DecStop(axisIndex);
                            if (!WaitMoveDone(axisIndex, 0))
                            {
                                ////if (testMode)
                                ////{
                                ////    DecStop(axisIndex);
                                ////    ShowMsg("03  回零失败，运动超时", InfoType.Error);
                                ////}
                                ////return false;
                            }

                            if (testMode)
                                ShowMsg("03  已运动到原点位，开始回退", InfoType.Tip);
                            MoveRel(axisIndex, -(int)(L_backLength[axisIndex]), (int)(L_homeVel[axisIndex]), false, true);
                            // Dmc1000.d1000_start_t_move(axisIndex, (int)(L_backLength[axisIndex] * L_pulseRate[axisIndex]), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), (int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                            if (!WaitMoveDone(axisIndex))
                            {
                                if (testMode)
                                {
                                    DecStop(axisIndex);
                                    ShowMsg("04  回零失败，运动超时", InfoType.Error);
                                }
                                return false;
                            }

                            if (testMode)
                                ShowMsg("04  回退完成,开始寻找原点", InfoType.Tip);



                            short mode = 6;

                            short ret = ecat_motion.M_SetHomingPrm((short)(axisIndex + 1), 18, 0, (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), (uint)(L_homeVel[axisIndex] * L_pulseRate[axisIndex] / 3), 100000, 0);
                            ecat_motion.M_SetHomingMode((short)(axisIndex + 1), mode, 0);
                            if (ret != 0)
                            {
                                if (testMode)
                                    ShowMsg("回零失败！请检查", InfoType.Error);
                                else
                                    FuncLib.ShowMsg("回零失败！请检查", InfoType.Error);
                                return false;
                            }



                            ecat_motion.M_HomingStart((short)(axisIndex + 1), 0);// Dmc1000.d1000_home_move(axisIndex, -(int)L_homeVel[axisIndex] / 3, -(int)(L_homeVel[axisIndex] * L_pulseRate[axisIndex]), 0.1);
                            if (!WaitMoveDone(axisIndex))
                            {
                                if (testMode)
                                {
                                    DecStop(axisIndex);
                                    ShowMsg("05  回零失败，运动超时", InfoType.Error);
                                }
                                return false;
                            }
                            if (testMode)
                                ShowMsg("05  回零完成", InfoType.Warn);

                        }
                    }
                    Thread.Sleep(20);

                    break;
            }

            int currentAxisStatus = 0;
            ecat_motion.M_GetSts((short)(axisIndex + 1), out currentAxisStatus, 1, 0);
            if ((currentAxisStatus & 0x10000) != 0x10000)
            {

                ecat_motion.M_SetHomingMode((short)(axisIndex + 1), 8, 0);
                //Dmc1000.d1000_set_command_pos(axisIndex, 0);
                ecat_motion.M_ClrSts((short)(axisIndex + 1), 1, 0);

                if (!MoveAbs(axisIndex, L_safePos[axisIndex], (int)L_homeVel[axisIndex], true))
                    return false;

                Project.L_axis[axisIndex].homeOK = true;
                return true;
            }
            else
            {
                return false;
            }
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
                FuncLib.ShowMsg("回零失败！运动控制卡未连接", InfoType.Error);
                return false;
            }

            int axisIndex = FindAxisByName(axisName).actNo;

            Home(axisIndex, false);

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
        /// 获取上电状态
        /// </summary>
        /// <param name="axisIndex"></param>
        internal override bool GetMotorStatu(int axisIndex, bool testMode = false)
        {
            if (!connected)
                return true;

            if (axisIndex < 0)
                return false;

            int ServoSts = 0;
            ecat_motion.M_GetSts((short)(axisIndex + 1), out ServoSts, 1, 0);//获取轴状态

            if ((ServoSts & 0x200) == 0x200)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 上电
        /// </summary>
        /// <param name="axisIndex"></param>
        internal override void MotorOn(int axisIndex, bool testMode = false)
        {
            if (vitualCard)
                return;

            try//尝试清除驱动器报警
            {
                ecat_motion.M_ClrSts((short)(axisIndex + 1), 1, 0);
            }
            catch { }

            Thread.Sleep(50);//需要加点延时，否则下面“ecat_motion.M_Servo_On”会执行失败，返回值为1
            ecat_motion.M_Servo_On((short)(axisIndex + 1), 0);//使当前轴上使能
        }
        /// <summary>
        /// 下电
        /// </summary>
        /// <param name="axisIndex"></param>
        internal override void MotorOff(int axisIndex, bool testMode = false)
        {
            if (vitualCard)
                return;

            ecat_motion.M_Servo_Off((short)(axisIndex + 1), 0);
        }
        /// <summary>
        /// 当前是否在原点
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        /// <returns>是否在原点</returns>
        internal override bool InHome(int axisIndex, bool testMode)
        {
            if (vitualCard)
                return false;

            if (!connected)
                return false;

            if (axisIndex < 0)
                return false;

            int ServoSts = 0;
            ecat_motion.M_GetSts((short)(axisIndex + 1), out ServoSts, 1, 0);//获取轴状态

            if (L_OriginLogic[axisIndex] == LogicLevel.高电平有效)
            {
                if ((ServoSts & 0x100000) == 0x100000)
                    return true;
                else
                    return false;
            }
            else
            {
                if ((ServoSts & 0x100000) == 0x100000)
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

            int ServoSts = 0;
            ecat_motion.M_GetSts((short)(axisIndex + 1), out ServoSts, 1, 0);//获取轴状态

            if (L_PLimitLogic[axisIndex] == LogicLevel.高电平有效)
            {
                if ((ServoSts & 0x20) == 0x20)
                    return true;
                else
                    return false;
            }
            else
            {
                if ((ServoSts & 0x20) == 0x20)
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

            int ServoSts = 0;
            ecat_motion.M_GetSts((short)(axisIndex + 1), out ServoSts, 1, 0);//获取轴状态

            if (L_NLimitLogic[axisIndex] == LogicLevel.高电平有效)
            {
                if ((ServoSts & 0x40) == 0x40)
                    return true;
                else
                    return false;
            }
            else
            {
                if ((ServoSts & 0x40) == 0x40)
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

            int ServoSts = 0;
            ecat_motion.M_GetSts((short)(axisIndex + 1), out ServoSts, 1, 0);//获取轴状态

            if ((ServoSts & 0x02) == 0x02)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 获取指定轴运动状态
        /// </summary>
        /// <param name="axisIndex">轴索引</param>
        /// <returns>轴是否运动</returns>
        internal override bool IsMoving(int axisIndex, bool testMode = false)
        {
            if (!connected)
                return false;

            if (axisIndex < 0)
                return false;

            int ServoSts = 0;
            ecat_motion.M_GetSts((short)(axisIndex + 1), out ServoSts, 1, 0);//获取轴状态

            if ((ServoSts & 0x400) == 0x400)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 获取指定轴运动状态
        /// </summary>
        /// <param name="axisIndex">轴索引</param>
        /// <returns>轴是否运动</returns>
        internal override bool IsMoving(Axis axisName)
        {
            if (!connected)
                return false;

            int axisIndex = FindAxisByName(axisName.ToString()).actNo;
            if (axisIndex < 0)
                return false;

            int ServoSts = 0;
            ecat_motion.M_GetSts((short)(axisIndex + 1), out ServoSts, 1, 0);//获取轴状态

            if ((ServoSts & 0x400) == 0x400)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 获取通用输入状态
        /// </summary>
        /// <param name="diName">名称</param>
        /// <returns>状态</returns>
        internal override OnOff GetDiSts(Di diName, bool testMode = false)
        {
            //虚拟输入
            if (Project.D_diVitual[diName] != 0)
            {
                if (Project.D_diVitual[diName] == 1)
                    return OnOff.Off;
                else
                    return OnOff.On;
            }

            if (!connected)
                return OnOff.Off;

            int actIdx = FindDiActIdxByName(diName);
            short value = 0;
            short ret = ecat_motion.M_Get_Digital_Chn_Input((short)actIdx, out value, 0);
            if (ret == 0)
            {
                if (value == 0)
                    return L_diLogicLevel[actIdx - 1] ? OnOff.Off : OnOff.On;
                else
                    return L_diLogicLevel[actIdx - 1] ? OnOff.On : OnOff.Off;
            }
            else
            {
                return OnOff.Off;
            }
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

            short value = 0;
            short ret = ecat_motion.M_Get_Digital_Chn_Input((short)actIdx, out value, 0);
            if (ret == 0)
            {
                if (value == 0)
                    return L_diLogicLevel[actIdx - 1] ? OnOff.Off : OnOff.On;
                else
                    return L_diLogicLevel[actIdx - 1] ? OnOff.On : OnOff.Off;
            }
            else
            {
                return OnOff.Off;
            }
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
            short value = 0;
            int ret = ecat_motion.M_Get_Digital_Chn_Output((short)actIdx, out value, 0);
            if (ret == 0)
            {
                if (value == 0)
                    return L_doLogicLevel[actIdx - 1] ? OnOff.On : OnOff.Off;
                else
                    return L_doLogicLevel[actIdx - 1] ? OnOff.Off : OnOff.On;
            }
            else
            {
                return OnOff.Off;
            }
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

            short value = 0;
            int ret = ecat_motion.M_Get_Digital_Chn_Output((short)actIdx, out value, 0);
            if (ret == 0)
            {
                if (value == 0)
                    return L_doLogicLevel[actIdx - 1] ? OnOff.On : OnOff.Off;
                else
                    return L_doLogicLevel[actIdx - 1] ? OnOff.Off : OnOff.On;
            }
            else
            {
                return OnOff.Off;
            }
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
                ecat_motion.M_Set_Digital_Chn_Output((short)doIdx, (short)(L_doLogicLevel[doIdx - 1] ? 0 : 1), 0);
            else
                ecat_motion.M_Set_Digital_Chn_Output((short)doIdx, (short)(L_doLogicLevel[doIdx - 1] ? 1 : 0), 0);
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
                ecat_motion.M_Set_Digital_Chn_Output((short)actIdx, (short)(L_doLogicLevel[actIdx - 1] ? 0 : 1), 0);
            else
                ecat_motion.M_Set_Digital_Chn_Output((short)actIdx, (short)(L_doLogicLevel[actIdx - 1] ? 1 : 0), 0);
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

            double curPos;
            int axisIndex = (ushort)FindAxisByName(axisName.ToString()).actNo;
            ecat_motion.M_GetCmd((short)(axisIndex + 1), out curPos, 1, 0);//获取轴规划位置
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

            double curPos;

            ecat_motion.M_GetCmd((short)(axisIndex + 1), out curPos, 1, 0);//获取轴规划位置
            return Math.Round(curPos / L_pulseRate[axisIndex], 3);
        }
        /// <summary>
        /// 获取当前编码位置
        /// </summary>
        /// <param name="axisName">轴索引</param>
        /// <returns>当前编码位置</returns>
        internal override double GetEncPos(int axisIndex, bool testMode = false)
        {
            if (!connected)
                return 0;

            if (axisIndex < 0)
                return 0;

            double curPos;

            ecat_motion.M_GetEncPos((short)(axisIndex + 1), out curPos, 1, 0);//获取编码器位置
            return Math.Round(curPos / L_pulseRate[axisIndex], 3);
        }
        /// <summary>
        /// 插补运动
        /// </summary>
        /// <returns></returns>
        internal override bool MoveInterpolate(Axis axis1, Axis axis2, double pos1, double pos2, double acc, double vel)
        {
            short dimension = 2;                //插补维度（参与插补运动轴的数量，最小为2，最大为6）
            int[] LineAllPosition = null;   //参与M_Line_All插补运动目标位置数组
            short[] LineAllAxisArray = null;//参与M_Line_All插补运动轴的轴号数组  
            LineAllAxisArray = new short[dimension];                           //声明参与插补运动的轴数组,其长度等于参与插补运动轴的数量
            LineAllPosition = new int[dimension];                              //声明轴目标位置数组，其长度等于参与LineAll插补运动轴的数量，并且其每个元素和LineAllAxisArray[]里的每个元素相对应

            if (!GetMotorStatu(FindAxisByName(axis1.ToString()).actNo))
            {
                MotorOn(FindAxisByName(axis1.ToString()).actNo);
                Thread.Sleep(200);
            }
            if (!GetMotorStatu(FindAxisByName(axis2.ToString()).actNo))
            {
                MotorOn(FindAxisByName(axis2.ToString()).actNo);
                Thread.Sleep(200);
            }

            LineAllAxisArray[0] = (short)(FindAxisByName(axis1.ToString()).actNo + 1);                     //A轴对应的轴号
            LineAllPosition[0] = (int)(pos1 * L_pulseRate[(short)FindAxisByName(axis1.ToString()).actNo]);                                                          //A轴对应轴号的目标位置
            LineAllAxisArray[1] = (short)(FindAxisByName(axis2.ToString()).actNo + 1);                     //B轴对应的轴号
            LineAllPosition[1] = (int)(pos2 * L_pulseRate[(short)FindAxisByName(axis2.ToString()).actNo]);                                                          //B轴对应轴号的目标位置

            short ret = ecat_motion.M_Line_All(dimension, ref LineAllAxisArray[0], ref LineAllPosition[0], acc, (int)(vel * L_pulseRate[(short)FindAxisByName(axis1.ToString()).actNo]), 0);

            int Sts = 0;
            for (int i = 0; i < dimension; i++)
            {
                do
                {
                    Thread.Sleep(100);
                    ecat_motion.M_GetSts(LineAllAxisArray[i], out Sts, 1, 0);//获取所有参与插补运动轴中的某个轴的轴状态
                } while ((Sts & 0x400) == 0x400);//判断轴是否停止运动，sts的 bit 10 == 1则轴为运动状态，bit 10 == 0 则轴为静止状态
            }
            //////if ((Sts & 0x800) == 0x800)
            //////{
            //////    FuncLib.ShowMsg(string.Format("轴 【{0}】 运动失败！轴未运动到位提前停止", axis1), InfoType.Error);
            //////    return false;
            //////}

            //编码器反馈值位置检查
            if (L_MotorType[FindAxisByName(axis1.ToString()).actNo])
            {
                double encPos = GetEncPos((short)FindAxisByName(axis1.ToString()).actNo);
                if (Math.Abs(encPos - pos1) <= L_allowOffset[FindAxisByName(axis1.ToString()).actNo])
                {


                    if (L_MotorType[FindAxisByName(axis2.ToString()).actNo])
                    {
                        double encPos2 = GetEncPos((short)FindAxisByName(axis2.ToString()).actNo);
                        if (Math.Abs(encPos2 - pos2) <= L_allowOffset[FindAxisByName(axis2.ToString()).actNo])
                        {
                            return true;
                        }
                        else
                        {
                            FuncLib.ShowMsg(string.Format("轴 【{0}】 运动失败！命令位置与反馈位置偏差超过偏差容限，偏差值：{1}   偏差容限：{2}", axis1, Math.Abs(encPos2 - pos2), L_allowOffset[FindAxisByName(axis2.ToString()).actNo]), InfoType.Error);
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }

                }
                else
                {
                    FuncLib.ShowMsg(string.Format("轴 【{0}】 运动失败！命令位置与反馈位置偏差超过偏差容限，偏差值：{1}   偏差容限：{2}", axis1, Math.Abs(encPos - pos1), L_allowOffset[FindAxisByName(axis1.ToString()).actNo]), InfoType.Error);
                    return false;
                }
            }
            else
            {


                if (L_MotorType[FindAxisByName(axis2.ToString()).actNo])
                {
                    double encPos2 = GetEncPos((short)FindAxisByName(axis2.ToString()).actNo);
                    if (Math.Abs(encPos2 - pos2) <= L_allowOffset[FindAxisByName(axis2.ToString()).actNo])
                    {
                        return true;
                    }
                    else
                    {
                        FuncLib.ShowMsg(string.Format("轴 【{0}】 运动失败！命令位置与反馈位置偏差超过偏差容限，偏差值：{1}   偏差容限：{2}", axis1, Math.Abs(encPos2 - pos2), L_allowOffset[FindAxisByName(axis2.ToString()).actNo]), InfoType.Error);
                        return false;
                    }
                }
                else
                {
                    return true;
                }

            }
        }
        /// <summary>
        /// 连续运动
        /// </summary>
        /// <param name="axisName">轴名称</param>
        internal override void KeepMove(Axis axisName, Dir dir, int vel, bool waitDone, bool testMode = false)
        {
            if (vitualCard)
                return;

            if (!connected)
            {
                if (testMode)
                    ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                else
                    FuncLib.ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                return;
            }

            int axisIndex = (ushort)FindAxisByName(axisName.ToString()).actNo;

            if (!GetMotorStatu(axisIndex))
            {
                MotorOn(axisIndex);
                Thread.Sleep(200);
            }

            if (dir == Dir.N_负方向 && InNEL(axisIndex))
            {
                ShowMsg("运动失败！负限触发，无法继续向负向运动", InfoType.Error);
                return;
            }
            if (dir == Dir.P_正方向 && InPEL(axisIndex))
            {
                ShowMsg("运动失败！正限位已触发，无法继续向正向运动", InfoType.Error);
                return;
            }

            ecat_motion.M_Jog((short)(axisIndex + 1), (int)((dir == Dir.P_正方向 ? 1 : -1) * vel * L_pulseRate[axisIndex]), 0);

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

            if (!GetMotorStatu(axisIndex))
            {
                MotorOn(axisIndex);
                Thread.Sleep(200);
            }

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

            ecat_motion.M_Jog((short)(axisIndex + 1), (int)(dir * vel * L_pulseRate[axisIndex]), 0);

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

            if (!GetMotorStatu(axisIndex))
            {
                MotorOn(axisIndex);
                Thread.Sleep(200);
            }

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

            short ret = ecat_motion.M_AbsMove((short)(axisIndex + 1), (int)(targetPos * L_pulseRate[axisIndex]), (int)(vel * L_pulseRate[axisIndex]), 0);

            if (ret == 0)
            {
                if (waitDone)
                    WaitMoveDone(axisIndex);
                return true;
            }
            else
            {
                return false;
            }
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

            if (!GetMotorStatu(axisIndex))
            {
                MotorOn(axisIndex);
                Thread.Sleep(200);
            }

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

            short ret = ecat_motion.M_AbsMove((short)(axisIndex + 1), (int)(targetPos * L_pulseRate[axisIndex]), (int)(vel * L_pulseRate[axisIndex]), 0);

            if (ret == 0)
            {
                if (waitDone)
                    WaitMoveDone(axisIndex);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 绝对位置移动
        /// </summary>
        /// <param name="axisName">轴名称</param>
        /// <param name="targetPos">目标位置</param>
        /// <param name="vel">移动速度</param>
        /// <param name="waitDone">是否等待</param>
        /// <returns></returns>
        internal override bool MoveAbs(int axisIndex, double targetPos, int vel, bool waitDone, bool testMode = false)
        {
            if (vitualCard)
                return true;

            if (!connected)
            {
                if (testMode)
                    ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                else
                    FuncLib.ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                return false;
            }

            if (!GetMotorStatu(axisIndex))
            {
                MotorOn(axisIndex);
                Thread.Sleep(200);
            }

            //限位检查
            if (targetPos < L_NLimit[axisIndex])
            {
                if (testMode)
                    ShowMsg(string.Format("【 {0} 】运动失败！目标位置超出软负极限，目标位置：{1}   软负限位：{2}", FindNameByIndex(axisIndex), targetPos, L_NLimit[axisIndex]), InfoType.Error);
                else
                    FuncLib.ShowMsg(string.Format("【 {0} 】运动失败！目标位置超出软负极限，目标位置：{1}   软负限位：{2}", FindNameByIndex(axisIndex), targetPos, L_NLimit[axisIndex]), InfoType.Error);
                return false;
            }
            if (targetPos > L_PLimit[axisIndex])
            {
                if (testMode)
                    ShowMsg(string.Format("【 {0} 】运动失败！目标位置超出软正极限，目标位置：{1}   软正限位：{2}", FindNameByIndex(axisIndex), targetPos, L_PLimit[axisIndex]), InfoType.Error);
                else
                    FuncLib.ShowMsg(string.Format("【 {0} 】运动失败！目标位置超出软正极限，目标位置：{1}   软正限位：{2}", FindNameByIndex(axisIndex), targetPos, L_PLimit[axisIndex]), InfoType.Error);
                return false;
            }

            ecat_motion.CmdPrm CmdPrm = new ecat_motion.CmdPrm();
            CmdPrm.acc = 5000000;//单轴加速度
            CmdPrm.dec = 5000000;//单轴减速度
            CmdPrm.sTime = (short)0.1;        //单轴加加速时间
            short ret = ecat_motion.M_SetMove((short)(axisIndex + 1), ref CmdPrm, 0);
            if (ret != 0)
            {
                // FuncLib.ShowMsg(string.Format("单轴运动失败！运动参数不合法"), InfoType.Error);
                //return false;
            }

            ret = ecat_motion.M_AbsMove((short)(axisIndex + 1), (int)(targetPos * L_pulseRate[axisIndex]), (int)(vel * L_pulseRate[axisIndex]), 0);

            if (ret == 0)
            {
                if (waitDone)
                    WaitMoveDone(axisIndex);


                //编码器反馈值位置检查
                if (L_MotorType[axisIndex])
                {
                    double encPos = GetEncPos((short)axisIndex);
                    if (Math.Abs(encPos - targetPos) <= L_allowOffset[axisIndex])
                    {
                        return true;
                    }
                    else
                    {
                        if (testMode)
                            ShowMsg(string.Format("轴 【{0}】 运动失败！命令位置与反馈位置偏差超过偏差容限，偏差值：{1}   偏差容限：{2}", FindNameByIndex(axisIndex), Math.Round(Math.Abs(encPos - targetPos), 3), L_allowOffset[axisIndex]), InfoType.Error);
                        else
                            FuncLib.ShowMsg(string.Format("轴 【{0}】 运动失败！命令位置与反馈位置偏差超过偏差容限，偏差值：{1}   偏差容限：{2}", FindNameByIndex(axisIndex), Math.Round(Math.Abs(encPos - targetPos), 3), L_allowOffset[axisIndex]), InfoType.Error);
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
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
            if (vitualCard)
                return true;

            if (!connected)
            {
                if (testMode)
                    ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                else
                    FuncLib.ShowMsg("运动失败！运动控制卡未连接", InfoType.Error);
                return false;
            }

            int axisIndex = FindAxisByName(axisName.ToString()).actNo;

            if (!GetMotorStatu(axisIndex))
            {
                MotorOn(axisIndex);
                Thread.Sleep(200);
            }

            //限位检查
            if (targetPos < L_NLimit[axisIndex])
            {
                if (testMode)
                    ShowMsg(string.Format("【 {0} 】运动失败！目标位置超出软负极限，目标位置：{1}   软负限位：{2}", axisName, targetPos, L_NLimit[axisIndex]), InfoType.Error);
                else
                    FuncLib.ShowMsg(string.Format("【 {0} 】运动失败！目标位置超出软负极限，目标位置：{1}   软负限位：{2}", axisName, targetPos, L_NLimit[axisIndex]), InfoType.Error);
                return false;
            }
            if (targetPos > L_PLimit[axisIndex])
            {
                if (testMode)
                    ShowMsg(string.Format("【 {0} 】运动失败！目标位置超出软正极限，目标位置：{1}   软正限位：{2}", axisName, targetPos, L_PLimit[axisIndex]), InfoType.Error);
                else
                    FuncLib.ShowMsg(string.Format("【 {0} 】运动失败！目标位置超出软正极限，目标位置：{1}   软正限位：{2}", axisName, targetPos, L_PLimit[axisIndex]), InfoType.Error);
                return false;
            }

            ecat_motion.CmdPrm CmdPrm = new ecat_motion.CmdPrm();
            CmdPrm.acc = 5000000;//单轴加速度
            CmdPrm.dec = 5000000;//单轴减速度
            CmdPrm.sTime = (short)0.1;        //单轴加加速时间
            short ret = ecat_motion.M_SetMove((short)(axisIndex + 1), ref CmdPrm, 0);
            if (ret != 0)
            {
                // FuncLib.ShowMsg(string.Format("单轴运动失败！运动参数不合法"), InfoType.Error);
                //return false;
            }

            ret = ecat_motion.M_AbsMove((short)(axisIndex + 1), (int)(targetPos * L_pulseRate[axisIndex]), (int)(vel * L_pulseRate[axisIndex]), 0);

            if (ret == 0)
            {
                if (waitDone)
                    WaitMoveDone(axisIndex);


                //编码器反馈值位置检查
                if (L_MotorType[axisIndex])
                {
                    double encPos = GetEncPos((short)axisIndex);
                    if (Math.Abs(encPos - targetPos) <= L_allowOffset[axisIndex])
                    {
                        return true;
                    }
                    else
                    {
                        if (testMode)
                            ShowMsg(string.Format("轴 【{0}】 运动失败！命令位置与反馈位置偏差超过偏差容限，偏差值：{1}   偏差容限：{2}", axisName, Math.Round(Math.Abs(encPos - targetPos), 3), L_allowOffset[axisIndex]), InfoType.Error);
                        else
                            FuncLib.ShowMsg(string.Format("轴 【{0}】 运动失败！命令位置与反馈位置偏差超过偏差容限，偏差值：{1}   偏差容限：{2}", axisName, Math.Round(Math.Abs(encPos - targetPos), 3), L_allowOffset[axisIndex]), InfoType.Error);
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
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

            ecat_motion.M_StopSingleAxis((short)(axisIndex + 1), 1, 0);//option为停止运动的方式: 0 表示采用平滑减速度停止，1 表示采用急停减速度停止
            WaitMoveDone(axisIndex, 0);
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
            ecat_motion.M_StopSingleAxis((short)(index + 1), 1, 0);//option为停止运动的方式: 0 表示采用平滑减速度停止，1 表示采用急停减速度停止
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

            ecat_motion.M_StopSingleAxis((short)(axisIndex + 1), 0, 0);//option为停止运动的方式: 0 表示采用平滑减速度停止，1 表示采用急停减速度停止
            WaitMoveDone(axisIndex, 0);
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
            ecat_motion.M_StopSingleAxis((short)(index + 1), 0, 0);//option为停止运动的方式: 0 表示采用平滑减速度停止，1 表示采用急停减速度停止
            WaitMoveDone(index, 0);
        }
        /// <summary>
        /// 等待运动完成
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        internal override bool WaitMoveDone(int axisIndex, int checkInp = 1, bool testMode = false)
        {
            if (axisIndex < 0)
                return false;

            Thread.Sleep(100);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int currentAxisStatus = 0;
            do
            {
                ecat_motion.M_GetSts((short)(axisIndex + 1), out currentAxisStatus, 1, 0);
                Thread.Sleep(50);
            } while ((currentAxisStatus & 0x400) == 0x400 && sw.ElapsedMilliseconds < 20000);

            if (sw.ElapsedMilliseconds >= 30000)
            {
                FuncLib.ShowMsg("【{0}】轴运动超时，超时时间：20s，请检查", InfoType.Error);
                return false;
            }
            else
            {
                if ((currentAxisStatus & 0x400) == 0x400)
                {
                    FuncLib.ShowMsg(string.Format("【{0}】轴未正常运动到位，请检查", FindNameByIndex(axisIndex)), InfoType.Error);
                    return false;
                }
                else
                {
                    //////if (checkInp == 1)
                    //////{
                    //////    Thread.Sleep(100);
                    //////    ecat_motion.M_GetSts((short)(axisIndex + 1), out currentAxisStatus, 1, 0);
                    //////    if ((currentAxisStatus & 0x800) != 0x800)
                    //////    {
                    //////        FuncLib.ShowMsg(string.Format("轴 【{0}】 运动失败！轴未运动到位提前停止", FindNameByIndex(axisIndex)), InfoType.Error);
                    //////        return false;
                    //////    }
                    //////    else
                    //////    {
                    //////        return true;
                    //////    }
                    //////}
                    //////else
                    //////{
                    return true;
                    //////}
                }
            }
        }
        /// <summary>
        /// 关闭运动控制卡
        /// </summary>
        internal override void Close()
        {
            if (!connected)
                return;

            try//尝试使所有的轴去使能
            {
                for (short i = 1; i < AxisNum + 1; i++)
                    ecat_motion.M_Servo_Off(i, 0);
                Thread.Sleep(100);
            }
            catch { }

            try//尝试断开EtherCAT总线
            {
                short ret1 = ecat_motion.M_DisconnectECAT(0);//断开总线段
            }
            catch { }

            short ret2 = ecat_motion.M_Close(0);
        }
    }
}
