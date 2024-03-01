using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VM_Pro
{
    /// <summary>
    /// 设备相关
    /// </summary>
    internal class Device
    {
        /// <summary>
        /// 急停是否被触发
        /// </summary>
        internal static bool emgHasTriged = false;
        /// <summary>
        /// 是否已复位
        /// </summary>
        internal static bool hasHomed = false;
        /// <summary>
        /// 已复位报警
        /// </summary>
        internal static bool alarmReseted = true;
        /// <summary>
        /// 自动锁定计时
        /// </summary>
        internal static Stopwatch sw_autoLock = new Stopwatch();
        /// <summary>
        /// 开始时间
        /// </summary>
        internal static DateTime startTime = new DateTime();
        /// <summary>
        /// 工作时长
        /// </summary>
        internal static Stopwatch sw_runTime = new Stopwatch();
        /// <summary>
        /// 生产时长
        /// </summary>
        internal static Stopwatch sw_workTime = new Stopwatch();
        /// <summary>
        /// 待料时长
        /// </summary>
        internal static Stopwatch sw_waitMaterialTime = new Stopwatch();
        /// <summary>
        /// 报警时长
        /// </summary>
        internal static Stopwatch sw_alarmTime = new Stopwatch();
        /// <summary>
        /// 整机复位结果      0:未完成复位     1：复位完成，失败     2：复位完成，成功
        /// </summary>
        internal static int machineHomeResult = 0;
        /// <summary>
        /// 设备运行状态
        /// </summary>
        private static MachineRunStatu _machineRunStatu = MachineRunStatu.WaitReset;
        /// <summary>
        /// 设备运行状态，更改其字段时，会相应的更新界面信息
        /// </summary>
        internal static MachineRunStatu MachineRunStatu
        {
            get
            {
                return _machineRunStatu;
            }
            set
            {
                _machineRunStatu = value;
                switch (_machineRunStatu)
                {
                    case MachineRunStatu.WaitReset:
                        sw_workTime.Stop();
                        sw_runTime.Stop();
                        sw_waitMaterialTime.Stop();
                        sw_alarmTime.Stop();
                        ThreeColorLamp.SetAllOff();
                        Frm_Main.Instance.lbl_deviceStatu.Text = "等待复位";
                        Frm_Main.Instance.lbl_deviceStatu.ForeColor = Color.Orange;
                        break;
                    case MachineRunStatu.Stop:
                        sw_workTime.Stop();
                        sw_runTime.Stop();
                        sw_waitMaterialTime.Stop();
                        sw_alarmTime.Stop();
                        ThreeColorLamp.SetYellow(false, false);
                        Frm_Main.Instance.lbl_deviceStatu.Text = "已停止";
                        Frm_Main.Instance.lbl_deviceStatu.ForeColor = Color.Orange;
                        break;
                    case MachineRunStatu.Pause:
                        sw_workTime.Stop();
                        sw_runTime.Start();
                        sw_waitMaterialTime.Stop();
                        sw_alarmTime.Stop();
                        ThreeColorLamp.SetYellow(false, false);
                        Frm_Main.Instance.lbl_deviceStatu.Text = "暂停中";
                        Frm_Main.Instance.lbl_deviceStatu.ForeColor = Color.Orange;
                        break;
                    case MachineRunStatu.Homing:
                        sw_workTime.Stop();
                        sw_runTime.Stop();
                        sw_waitMaterialTime.Stop();
                        sw_alarmTime.Stop();
                        ThreeColorLamp.SetAllOff();
                        Frm_Main.Instance.lbl_deviceStatu.Text = "复位中";
                        Frm_Main.Instance.lbl_deviceStatu.ForeColor = Color.Orange;
                        break;
                    case MachineRunStatu.WaitRun:
                        sw_workTime.Stop();
                        sw_runTime.Stop();
                        sw_waitMaterialTime.Stop();
                        sw_alarmTime.Stop();
                        ThreeColorLamp.SetAllOff();
                        Frm_Main.Instance.lbl_deviceStatu.Text = "等待启动";
                        Frm_Main.Instance.lbl_deviceStatu.ForeColor = Color.Orange;
                        break;
                    case MachineRunStatu.Running:
                        sw_workTime.Start();
                        sw_runTime.Start();
                        sw_waitMaterialTime.Stop();
                        sw_alarmTime.Stop();
                        ThreeColorLamp.SetGreen(false, false);
                        Frm_Main.Instance.lbl_deviceStatu.Text = "运行中";
                        Frm_Main.Instance.lbl_deviceStatu.ForeColor = Color.Green;
                        break;
                    case MachineRunStatu.WaitMaterial:
                        Device.DevicePause();
                        alarmReseted = false;
                        sw_workTime.Stop();
                        sw_runTime.Start();
                        sw_waitMaterialTime.Start();
                        sw_alarmTime.Stop();
                        ThreeColorLamp.SetYellow(false, true);
                        Frm_Main.Instance.lbl_deviceStatu.Text = "待料";
                        Frm_Main.Instance.lbl_deviceStatu.ForeColor = Color.Orange;
                        break;
                    case MachineRunStatu.Alarm:
                        DevicePause();
                        alarmReseted = false;
                        sw_workTime.Stop();
                        sw_runTime.Start();
                        sw_waitMaterialTime.Stop();
                        sw_alarmTime.Start();
                        ThreeColorLamp.SetRed(true, true);
                        Frm_Main.Instance.lbl_deviceStatu.Text = "普通报警";
                        Frm_Main.Instance.lbl_deviceStatu.ForeColor = Color.Red;
                        break;
                    case MachineRunStatu.HeavyAlarm:
                        alarmReseted = false;
                        sw_workTime.Stop();
                        sw_runTime.Start();
                        sw_waitMaterialTime.Stop();
                        sw_alarmTime.Start();
                        //////ThreeColorLamp.SetRed(false, false);
                        Frm_Main.Instance.lbl_deviceStatu.Text = "严重报警";
                        Frm_Main.Instance.lbl_deviceStatu.ForeColor = Color.Red;
                        break;
                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// 设备停止
        /// </summary>
        internal static void DevicePause()
        {
            Frm_Main.Instance.btn_pause.Invoke(new Action(() =>
             {
                 if (Device.MachineRunStatu == MachineRunStatu.Running || Device.MachineRunStatu == MachineRunStatu.WaitMaterial || Device.MachineRunStatu == MachineRunStatu.Alarm)
                 {
                     Frm_Main.Instance.btn_start.Text = "启动";
                     Frm_Main.Instance.btn_start.FillColor = Color.FromArgb(80, 160, 255);
                     Frm_Main.Instance.btn_start.RectColor = Color.FromArgb(80, 160, 255);
                     Frm_Main.Instance.btn_pause.Text = "已暂停";
                     Frm_Main.Instance.btn_pause.FillColor = Color.Green;
                     Frm_Main.Instance.btn_pause.RectColor = Color.Green;
                     Frm_Main.Instance.btn_stop.Text = "停止";
                     Frm_Main.Instance.btn_stop.FillColor = Color.FromArgb(80, 160, 255);
                     Frm_Main.Instance.btn_stop.RectColor = Color.FromArgb(80, 160, 255);
                     FuncLib.ShowMsg("已暂停运行");

                     for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
                     {
                         Scheme.curScheme.L_taskList[i].isLoopRuning = false;
                     }
                 }

                 //项目自定义
                 FuncLib.SetOff(Do.离子风_C1Out67);

             }));
        }
        /// <summary>
        /// 停止自动运行
        /// </summary>
        internal static void StopRun()
        {
            if (MachineRunStatu == MachineRunStatu.Running)
            {

                FuncLib.ShowMsg("停止运行");
                MachineRunStatu = MachineRunStatu.Stop;

                //Frm_UserForm.Instance.Stop();
                for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
                {
                    Scheme.curScheme.L_taskList[i].isLoopRuning = false;
                }

                if (Frm_Task.Instance.C_toolList.Nodes.Count > 0)
                {
                    if (Frm_Task.Instance.C_toolList.SelectedNode != null && Task.curTask.taskTrigMode == TaskTrigMode.BasedCall)
                    {
                        Frm_Task.Instance.btn_runOnce.Enabled = true;
                    }
                }
            }
        }
        /// <summary>
        /// 暂停自动运行
        /// </summary>
        internal static void PauseRun()
        {
            if (MachineRunStatu == MachineRunStatu.Running)
            {

                FuncLib.ShowMsg("暂停运行");
                MachineRunStatu = MachineRunStatu.Pause;

                for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
                {
                    Scheme.curScheme.L_taskList[i].isLoopRuning = false;
                }

                if (Frm_Task.Instance.C_toolList.Nodes.Count > 0)
                {
                    if (Frm_Task.Instance.C_toolList.SelectedNode != null && Task.curTask.taskTrigMode == TaskTrigMode.BasedCall)
                    {
                        Frm_Task.Instance.btn_runOnce.Enabled = true;
                    }
                }
            }
        }
    }
}
