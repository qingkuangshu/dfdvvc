using HalconDotNet;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using VM_Pro.Properties;

namespace VM_Pro
{
    public partial class Frm_Main : UIHeaderMainFooterFrame
    {
        public Frm_Main()
        {
            InitializeComponent();

            //设置关联
            Header.TabControl = MainTabControl;
        }


        /// <summary>
        /// 计时
        /// </summary>
        public static Stopwatch sw1 = new Stopwatch();
        /// <summary>
        /// 启动按钮按下
        /// </summary>
        private static bool startButtonPressed = false;
        /// <summary>
        /// 复位按钮按下
        /// </summary>
        private static bool resetButtonPressed = false;
        /// <summary>
        /// 急停按钮按下
        /// </summary>
        private static bool emgButtonPressed = false;
        private static bool GuangBanZhouAlarmed = false;
        /// <summary>
        /// 停止按钮按下
        /// </summary>
        private static bool stopButtonPressed = false;
        /// <summary>
        /// 轴报警
        /// </summary>
        private static bool axisAlarmed = false;
        /// <summary>
        /// IO刷新线程
        /// </summary>
        private Thread th_update;
        /// <summary>
        /// 刷新IO状态
        /// </summary>
        private bool updateIO = false;
        /// <summary>
        /// 保存的时候，人们习惯连续快速的点好几下
        /// </summary>
        private bool saving = false;
        /// <summary>
        /// 指示是否已按下Ctrl+E组合键
        /// </summary>
        private bool controlE = false;
        /// <summary>
        /// 停止复位按钮按下计时
        /// </summary>
        public bool isStop = false;
        /// <summary>
        /// 按下复位按钮时长计时
        /// </summary>
        public static Stopwatch sw = new Stopwatch();
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Main _instance;
        internal static Frm_Main Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Main();
                return _instance;
            }
        }


        /// <summary>
        /// 获取可用的服务按钮
        /// </summary>
        /// <returns>按钮对象</returns>
        internal static UISymbolButton GetCanUseServiceButton()
        {
            if (Instance.btn_sevice1.Tag == null)
            {
                Instance.btn_sevice1.FillDisableColor = Color.FromArgb(80, 160, 255);
                Instance.btn_sevice1.RectDisableColor = Color.FromArgb(80, 160, 255);
                return Instance.btn_sevice1;
            }
            if (Instance.btn_sevice2.Tag == null)
            {
                Instance.btn_sevice2.FillDisableColor = Color.FromArgb(80, 160, 255);
                Instance.btn_sevice2.RectDisableColor = Color.FromArgb(80, 160, 255);
                return Instance.btn_sevice2;
            }
            if (Instance.btn_sevice3.Tag == null)
            {
                Instance.btn_sevice3.FillDisableColor = Color.FromArgb(80, 160, 255);
                Instance.btn_sevice3.RectDisableColor = Color.FromArgb(80, 160, 255);
                return Instance.btn_sevice3;
            }
            if (Instance.btn_sevice4.Tag == null)
            {
                Instance.btn_sevice4.FillDisableColor = Color.FromArgb(80, 160, 255);
                Instance.btn_sevice4.RectDisableColor = Color.FromArgb(80, 160, 255);
                return Instance.btn_sevice4;
            }
            if (Instance.btn_sevice5.Tag == null)
            {
                Instance.btn_sevice5.FillDisableColor = Color.FromArgb(80, 160, 255);
                Instance.btn_sevice5.RectDisableColor = Color.FromArgb(80, 160, 255);
                return Instance.btn_sevice5;
            }
            if (Instance.btn_sevice6.Tag == null)
            {
                Instance.btn_sevice6.FillDisableColor = Color.FromArgb(80, 160, 255);
                Instance.btn_sevice6.RectDisableColor = Color.FromArgb(80, 160, 255);
                return Instance.btn_sevice6;
            }
            if (Instance.btn_sevice7.Tag == null)
            {
                Instance.btn_sevice7.FillDisableColor = Color.FromArgb(80, 160, 255);
                Instance.btn_sevice7.RectDisableColor = Color.FromArgb(80, 160, 255);
                return Instance.btn_sevice7;
            }
            if (Instance.btn_sevice8.Tag == null)
            {
                Instance.btn_sevice8.FillDisableColor = Color.FromArgb(80, 160, 255);
                Instance.btn_sevice8.RectDisableColor = Color.FromArgb(80, 160, 255);
                return Instance.btn_sevice8;
            }
            return new UISymbolButton();
        }
        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData & Keys.Control) == Keys.Control)
            {
                if ((keyData & Keys.L) == Keys.L)
                {
                    Frm_Login.Instance.ShowDialog();
                }
                if ((keyData & Keys.K) == Keys.K)
                {
                    Device.sw_autoLock.Stop();
                    Device.sw_autoLock.Reset();
                    Frm_Login.Instance.btn_logout_Click(null, null);
                }
                if ((keyData & Keys.S) == Keys.S)
                {
                    if (!saving)
                    {
                        saving = true;
                        Thread th = new Thread(() =>
                        {
                            Project.Instance.configuration.mainFormHeight = Frm_Main.Instance.Height;
                            Project.Instance.configuration.mainFormWidth = Frm_Main.Instance.Width;

                            //保存页面尺寸信息
                            Scheme.curScheme.frm_vison_splitContainer1_splitterDistance = Frm_Vision.Instance.splitContainer1.SplitterDistance;
                            Scheme.curScheme.frm_vison_splitContainer2_splitterDistance = Frm_Vision.Instance.splitContainer2.SplitterDistance;
                            Scheme.curScheme.frm_task_splitContainer2_splitterDistance = Frm_Task.Instance.splitContainer2.SplitterDistance;
                            Scheme.curScheme.frm_task_splitContainer1_splitterDistance = Frm_Task.Instance.splitContainer1.SplitterDistance;

                            Frm_Motion.Instance.SaveAxisPoint();
                            Project.SaveSysPar();
                            Scheme.SaveCur();

                            FuncLib.ShowMsg("保存当前方案成功", InfoType.Tip);
                            Thread.Sleep(20);
                            saving = false;
                        });
                        th.IsBackground = true;
                        th.Start();
                    }
                }
                if ((keyData & Keys.W) == Keys.W)
                {
                    controlE = true;
                    return true;
                }
            }
            else if (keyData == Keys.Escape)         //ESC退出演示模式
            {
                Frm_Vision.Instance.splitContainer1.Panel1Collapsed = false;
                Frm_Vision.Instance.splitContainer2.Panel2Collapsed = false;
                Frm_Vision.Instance.tableLayoutPanel1.RowStyles[0].Height = 39;
                Frm_Main.Instance.HeaderVisible(true);

                string date = File.GetLastWriteTime(Application.StartupPath + "\\VM Pro.exe").ToString("yyyy-MM-dd");
                Frm_Main.Instance.Text = string.Format("{0} - {1}  V {2}", Project.Instance.configuration.companyName, Project.Instance.configuration.projectName, string.Format("{0} {1}", date, ((AssemblyConfigurationAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false))[0]).Configuration));
            }
            //else if(keyData == Keys.Space)
            //{
            //    Frm_Task.Instance.btn_runOnce_Click(null, null);
            //}
            //else
            //{
            //    Frm_Task.Instance.btn_runOnce_Click(null, null);
            //    Frm_Main.Instance.Focus();
            //    Frm_Main.Instance.Select();
            //}
            controlE = false;
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// 更新窗口选择
        /// </summary>
        /// <param name="initRun">是否第一次加载窗体时调用</param>
        internal static void UpdateForm(bool initRun = false)
        {
            Frm_Main.Instance.Header.Nodes.Clear();
            Frm_Main.Instance.Header.Nodes.Add("首页");
            Frm_Main.Instance.Header.Nodes.Add("视觉");
            Frm_Main.Instance.Header.Nodes.Add("运控");
            Frm_Main.Instance.Header.Nodes.Add("IO监控");

            int userFormIndex = 0;
            int VisionFormIndex = 0;
            int motionFormIndex = 0;
            int ioFormIndex = 0;
            int num = 0;
            if (Project.Instance.configuration.enableUserForm)
            {
                num++;
                Frm_Main.Instance.AddPage(Frm_User.Instance, 1000);
                Frm_Main.Instance.Header.SetNodePageIndex(Frm_Main.Instance.Header.Nodes[0], 1000);
                Frm_Main.Instance.Header.SetNodePageIndex(Frm_Main.Instance.Header.Nodes[0], 1000);
                Frm_Main.Instance.Header.SetNodeSymbol(Frm_Main.Instance.Header.Nodes[0], 362744);
                userFormIndex = num - 1;
            }
            if (Project.Instance.configuration.enableVisionForm)
            {
                num++;
                Frm_Main.Instance.AddPage(Frm_Vision.Instance, 1001);
                Frm_Main.Instance.Header.SetNodePageIndex(Frm_Main.Instance.Header.Nodes[1], 1001);
                Frm_Main.Instance.Header.SetNodePageIndex(Frm_Main.Instance.Header.Nodes[1], 1001);
                Frm_Main.Instance.Header.SetNodeSymbol(Frm_Main.Instance.Header.Nodes[1], 61818);
                VisionFormIndex = num - 1;
            }
            if (Project.Instance.configuration.enableMotionForm)
            {
                num++;
                Frm_Main.Instance.AddPage(Frm_Motion.Instance, 1002);
                Frm_Main.Instance.Header.SetNodePageIndex(Frm_Main.Instance.Header.Nodes[2], 1002);
                Frm_Main.Instance.Header.SetNodePageIndex(Frm_Main.Instance.Header.Nodes[2], 1002);
                Frm_Main.Instance.Header.SetNodeSymbol(Frm_Main.Instance.Header.Nodes[2], 362614);
                motionFormIndex = num - 1;
            }
            if (Project.Instance.configuration.enableIOForm)
            {
                num++;
                Frm_Main.Instance.AddPage(Frm_IO.Instance, 1003);
                Frm_Main.Instance.Header.SetNodePageIndex(Frm_Main.Instance.Header.Nodes[3], 1003);
                Frm_Main.Instance.Header.SetNodePageIndex(Frm_Main.Instance.Header.Nodes[3], 1003);
                Frm_Main.Instance.Header.SetNodeSymbol(Frm_Main.Instance.Header.Nodes[3], 61451);
                ioFormIndex = num - 1;
            }

            //加载默认窗体
            if (initRun)
            {
                switch (Project.Instance.configuration.defaultFormType)
                {
                    case FormType.UserForm:
                        Frm_Main.Instance.Header.SelectedIndex = 0;
                        break;
                    case FormType.VisionForm:
                        Frm_Main.Instance.Header.SelectedIndex = VisionFormIndex;
                        break;
                    case FormType.MotionForm:
                        Frm_Main.Instance.Header.SelectedIndex = 2;
                        break;
                    case FormType.IOForm:
                        Frm_Main.Instance.Header.SelectedIndex = 3;
                        break;
                }
            }

            if (!Project.Instance.configuration.enableIOForm)
                Frm_Main.Instance.Header.Nodes.RemoveAt(3);
            if (!Project.Instance.configuration.enableMotionForm)
                Frm_Main.Instance.Header.Nodes.RemoveAt(2);
            if (!Project.Instance.configuration.enableVisionForm)
                Frm_Main.Instance.Header.Nodes.RemoveAt(1);
            if (!Project.Instance.configuration.enableUserForm)
                Frm_Main.Instance.Header.Nodes.RemoveAt(0);

            if (Frm_Main.Instance.Header.Nodes.Count == 1)
                Frm_Main.Instance.Header.Nodes.RemoveAt(0);

            Frm_Main.Instance.Activate();
            Application.DoEvents();
        }
        /// <summary>
        /// 标题栏隐藏
        /// </summary>
        /// <param name="visible"></param>
        internal void HeaderVisible(bool visible)
        {
            Header.Visible = visible;
        }
        /// <summary>
        /// 复位按钮按下时长计时
        /// </summary>
        private void CountTime()
        {
            while (sw.ElapsedMilliseconds < 8000 && !isStop)
            {
                Thread.Sleep(100);
                btn_reset.Text = string.Format("复位({0})", sw.Elapsed.Seconds + 1);
                Application.DoEvents();
            }
            btn_reset.Text = "复位";
            sw.Stop();
            sw.Reset();
        }

        public static bool LastTrackStaueIsRunning = false;
        public static bool lastYaoBanXinHao = false;
        private void btn_start_Click(object sender, EventArgs e)
        {
            Frm_BigTip.Instance.Close();

            if (Frm_Confirm.isShown)
            {
                FuncLib.ShowMsg("启动失败！请确认弹框后再启动", InfoType.Warn);
                return;
            }

            if (FuncLib.GetDiSts(Di.安全门_C1In04) == OnOff.On)
            {
                FuncLib.ShowMsg("门打开状态不可启动，请先关闭安全门（注意：无论安全门是否启用，启动时，安全门都必须处于关闭状态，如已屏蔽，启动后可开门）", InfoType.Error, false);
                return;
            }

            Frm_Main.Instance.Invoke(new Action(() =>
            {
                if (Device.MachineRunStatu == MachineRunStatu.Running)
                    return;

                btn_pause.Enabled = true;

                btn_start.Text = "已启动";
                btn_start.FillColor = Color.Green;
                btn_start.RectColor = Color.Green;
                btn_stop.Text = "停止";
                btn_reset.Text = "复位";
                btn_pause.Text = "暂停";
                btn_pause.FillColor = Color.FromArgb(80, 160, 255);
                btn_pause.RectColor = Color.FromArgb(80, 160, 255);
                btn_reset.FillColor = Color.FromArgb(80, 160, 255);
                btn_reset.RectColor = Color.FromArgb(80, 160, 255);
                btn_stop.Enabled = true;
                cbx_schemeList.Enabled = false;

                if (Device.MachineRunStatu == MachineRunStatu.Homing)
                {
                    FuncLib.ShowMsg("设备复位中，请复位完成后开始", InfoType.Error);
                    return;
                }
                else if (Device.MachineRunStatu == MachineRunStatu.WaitReset)
                {
                    FuncLib.ShowMsg("设备未复位，请复位成后开始", InfoType.Error);
                    return;
                }
                else
                {
                    FuncLib.ShowMsg("开始运行");
                    Device.MachineRunStatu = MachineRunStatu.Running;

                    MainTask.StartTask();

                    for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
                    {
                        //////if (Scheme.curScheme.L_taskList[i].taskTrigMode  == TaskTrigMode.LoopRunAfterStart) 
                        //////    Scheme.curScheme.L_taskList[i].LoopRun(true);
                    }

                    ButtonEnable(false);

                }


                //项目自定义
                FuncLib.SetDo(Do.启动灯_C1Out00, OnOff.On);
                FuncLib.SetDo(Do.停止灯_C1Out02, OnOff.Off);
                FuncLib.SetDo(Do.复位灯_C1Out01, OnOff.Off);


            }));
        }
        internal void btn_pause_Click(object sender, EventArgs e)
        {
            Device.DevicePause();
            Device.MachineRunStatu = MachineRunStatu.Pause;
        }
        public void ButtonEnable(bool enable)
        {
            //////打开流程ToolStripMenuItem.Enabled = enable;
            //////关闭ToolStripMenuItem.Enabled = enable;
            //////打开ToolStripMenuItem.Enabled = enable;
            //////系统重置ToolStripMenuItem.Enabled = enable;
            //////if (Frm_JobList.Instance.tvw_tools.Nodes.Count > 0)
            //////{
            //////    if (Frm_JobList.Instance.tvw_tools.SelectedNode != null && Job.FindJobByName(Frm_Job.Instance.lbl_jobName.Text).jobRunMode == JobRunMode.LoopRunAfterStart)
            //////    {
            //////        toolStripButton11.Enabled = enable;
            //////        toolStripButton12.Enabled = enable;
            //////        toolStripButton35.Enabled = enable;
            //////        toolStripButton16.Enabled = enable;
            //////    }
            //////}
            //////最近的项目ToolStripMenuItem.Enabled = enable;
            //////删除ToolStripMenuItem.Enabled = enable;
            //////toolStripButton17.Enabled = enable;
            //////toolStripButton18.Enabled = enable;
            //////toolStripButton22.Enabled = enable;
            //////toolStripButton14.Enabled = enable;
            //////toolStripButton15.Enabled = enable;
            //////toolStripButton19.Enabled = enable;
            //////toolStripButton11.Enabled = enable;
            //////toolStripButton12.Enabled = enable;
            //////toolStripButton16.Enabled = enable;
            //////toolStripButton35.Enabled = enable;
            //////toolStripButton20.Enabled = enable;
            //////toolStripButton21.Enabled = enable;
            //////toolStripButton28.Enabled = enable;
            //////toolStripButton29.Enabled = enable;
            //////toolStripButton31.Enabled = enable;
            //////toolStripButton26.Enabled = enable;
            //////toolStripButton30.Enabled = enable;
            //////tsb_stopSwtich.Enabled = enable;
            //////toolStripButton23.Enabled = enable;
            //////toolStripButton24.Enabled = enable;
            //////toolStripButton25.Enabled = enable;
        }
        internal void btn_stop_Click(object sender, EventArgs e)
        {
            MainTask.firstLowVel = true;
            MainTask.stopCurFinished = false;
            lastYaoBanXinHao = false;

            btn_stop.Text = "已停止";
            btn_start.Text = "启动";
            btn_pause.Text = "暂停";
            btn_reset.Text = "复位";
            btn_stop.FillColor = Color.Green;
            btn_stop.RectColor = Color.Green;
            btn_reset.FillColor = Color.FromArgb(80, 160, 255);
            btn_reset.RectColor = Color.FromArgb(80, 160, 255);
            btn_reset.Enabled = true;
            btn_start.Enabled = false;
            btn_pause.Enabled = false;
            cbx_schemeList.Enabled = true;

            Thread th = new Thread(() =>
            {
                Device.StopRun();
                Device.MachineRunStatu = MachineRunStatu.Stop;
            });
            th.IsBackground = true;
            th.Start();

            ButtonEnable(true);

            Thread th1 = new Thread(() =>
            {
                Thread.Sleep(1000);
                //////Configuration.SpeedMode = false;
            });
            th1.IsBackground = true;
            th1.Start();

            //项目自定义
            //////FuncLib.ResetDo(Do.FFU1_C1Out17);
            //////FuncLib.ResetDo(Do.FFU2_C1Out20);

            //////FuncLib.SetDo(Do.启动灯_C1Out00, OnOff.Off);
            //////FuncLib.SetDo(Do.停止灯_C1Out02, OnOff.On);
            //////FuncLib.SetDo(Do.复位灯_C1Out01, OnOff.Off);

            //////FuncLib.SetDo(Do.上光源_C1Out15, OnOff.Off);
            //////FuncLib.SetDo(Do.下光源_C1Out16, OnOff.Off);

            //停止一切运动
            //////FuncLib.DecStop(Axis.X);
            //////FuncLib.DecStop(Axis.Y);
            //////FuncLib.DecStop(Axis.Z);
            //////FuncLib.DecStop(Axis.U);
            //////FuncLib.DecStop(Axis.上胶框轴);
            //////FuncLib.DecStop(Axis.上玻璃片轴);
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            //关闭蜂鸣器
            Device.alarmReseted = true;
            ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.Off);
            Frm_BigTip.Instance.Close();
        }
        private void btn_system_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            Frm_System.Instance.WindowState = FormWindowState.Normal;
            Frm_System.Instance.Show();
            Frm_System.Instance.Activate();



            if (Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                if (Frm_System.Instance.tvw_menu.Nodes.Count == 2)
                {
                    Frm_System.Instance.tvw_menu.Nodes.Add("项目属性");
                    Frm_System.Instance.tvw_menu.Nodes.Add("系统选项");
                    Frm_System.Instance.tvw_menu.Nodes.Add("其它");
                }
            }
            else
            {
                if (Frm_System.Instance.tvw_menu.Nodes.Count > 2)
                {
                    Frm_System.Instance.tvw_menu.Nodes.RemoveAt(4);
                    Frm_System.Instance.tvw_menu.Nodes.RemoveAt(3);
                    Frm_System.Instance.tvw_menu.Nodes.RemoveAt(2);
                }
            }

            if (Frm_Service.Instance.tvw_serviceList.SelectedNode != null)
            {
                if (Project.Instance.L_Service.Count > 0 && Project.FindServiceByName(Frm_Service.Instance.tvw_serviceList.SelectedNode.Text).serviceType == ServiceType.Card)
                    Frm_Card.UpdateAll();
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!saving)
            {
                saving = true;
                Thread th = new Thread(() =>
                {
                    //1.窗体尺寸信息
                    Project.Instance.configuration.mainFormHeight = Frm_Main.Instance.Height;
                    Project.Instance.configuration.mainFormWidth = Frm_Main.Instance.Width;

                    //保存页面尺寸信息
                    Scheme.curScheme.frm_vison_splitContainer1_splitterDistance = Frm_Vision.Instance.splitContainer1.SplitterDistance;
                    Scheme.curScheme.frm_vison_splitContainer2_splitterDistance = Frm_Vision.Instance.splitContainer2.SplitterDistance;
                    Scheme.curScheme.frm_task_splitContainer2_splitterDistance = Frm_Task.Instance.splitContainer2.SplitterDistance;
                    Scheme.curScheme.frm_task_splitContainer1_splitterDistance = Frm_Task.Instance.splitContainer1.SplitterDistance;

                    //1.保存运控层面上的东西
                    Frm_Motion.Instance.SaveAxisPoint();
                    //1.保存当前软件上的所有配置信息
                    Project.SaveSysPar();
                    //1.保存当前解决方案的所有信息
                    Scheme.SaveCur();

                    FuncLib.ShowMsg("保存当前方案成功", InfoType.Tip);
                    Thread.Sleep(20);
                    saving = false;
                });
                th.IsBackground = true;
                th.Start();
            }
        }

        private void pic_loginStatu_MouseEnter(object sender, EventArgs e)
        {
            if ((int)Permission.CurPermissionGrade < (int)PermissionGrade.Admin)
                Frm_Main.Instance.pic_loginStatu.ForeColor = Color.FromArgb(80, 160, 255);
        }
        private void pic_loginStatu_MouseLeave(object sender, EventArgs e)
        {
            if ((int)Permission.CurPermissionGrade < (int)PermissionGrade.Admin)
                Frm_Main.Instance.pic_loginStatu.ForeColor = Color.FromArgb(240, 240, 240);
        }
        private void pic_loginStatu_MouseDown(object sender, MouseEventArgs e)
        {
            Frm_Main.Instance.pic_loginStatu.ForeColor = Color.FromArgb(56, 56, 56);
        }
        private void pic_loginStatu_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CurPermissionGrade == PermissionGrade.NoLogin)
                Frm_Main.Instance.pic_loginStatu.ForeColor = Color.FromArgb(240, 240, 240);
            else
                Frm_Main.Instance.pic_loginStatu.ForeColor = Color.FromArgb(80, 160, 255);
        }
        private void pic_loginStatu_Click(object sender, EventArgs e)
        {
            Frm_Login.Instance.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ////检查是否到期
            //if (!Frm_Regiest.hasShown && !Frm_RegestInfo.hasShown)
            //{
            //    Ini ini = new Ini(Application.StartupPath + "\\Config\\SysConfig.ini");
            //    string startDate = ini.IniReadConfig("StartDate");

            //    //临时添加
            //    if (ini.IniReadConfig("RegiestNum") == string.Empty)
            //        ini.IniWriteConfig("RegiestNum", "0");

            //    int regiestNum = Convert.ToInt16(ini.IniReadConfig("RegiestNum"));
            //    int useDay = 0;
            //    switch (regiestNum)
            //    {
            //        case -1:
            //            useDay = -1;        //永久使用
            //            break;
            //        case 0:
            //            useDay = 90 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
            //            break;
            //        case 1:
            //            useDay = 45 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
            //            break;
            //        case 2:
            //            useDay = 22 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
            //            break;
            //        case 3:
            //            useDay = 11 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
            //            break;
            //        case 4:
            //            useDay = 5 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
            //            break;
            //        case 5:
            //            useDay = 2 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
            //            break;
            //        case 6:
            //            useDay = 1 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
            //            break;
            //    }
            //    if (useDay <= 0)
            //    {
            //        Frm_RegestInfo.hasShown = true;
            //        new Frm_RegestInfo().ShowDialog();
            //    }
            //}
        }
        private void tmr_update_Tick(object sender, EventArgs e)
        {
            if (FuncLib.sw_stopScroll != null)
            {
                if (FuncLib.sw_stopScroll.Elapsed.TotalMinutes > 5)
                {
                    FuncLib.sw_stopScroll.Stop();
                    FuncLib.sw_stopScroll = null;
                }
            }

            if (Project.Instance.configuration.enablePermission)
            {
                if (Device.sw_autoLock.Elapsed.TotalMinutes > 60)
                {
                    FuncLib.ShowMsg("登录时间已达1小时，权限将自动注销");
                    Device.sw_autoLock.Stop();
                    Device.sw_autoLock.Reset();
                    Frm_Login.Instance.btn_logout_Click(null, null);

                    Frm_Msg.Instance.tsb_tip.Checked = false;
                    Frm_Msg.Instance.tsb_warn.Checked = false;
                    Frm_Msg.Instance.tsb_error.Checked = false;
                    Frm_Msg.Instance.tsb_historyAlarm.Checked = false;

                    //定时启用安全门
                    if (!Project.Instance.configuration.SafeDoorEnable)
                    {
                        FuncLib.ShowMsg("登录时间已达1小时，门禁已自动启用");
                        Project.Instance.configuration.SafeDoorEnable = true;
                        if (Project.Instance.configuration.SafeDoorEnable == false)
                            MainTask.saftyDoorTriged = false;
                    }
                }
            }
            Frm_Debug.Instance.lbl_runTime.Text = string.Format("{0} 天 {1} 时 {2} 分 {3} 秒", Device.sw_runTime.Elapsed.Days, Device.sw_runTime.Elapsed.Hours, Device.sw_runTime.Elapsed.Minutes, Device.sw_runTime.Elapsed.Seconds);

            //产能统计
            ////////if (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0 && DateTime.Now.Second <= 1)
            ////////{
            ////////    //临时添加
            ////////    if (Project.Instance.L_count1 == null)
            ////////        Project.Instance.L_count1 = new Dictionary<int, Count>();

            ////////    if (!Project.Instance.L_count1.ContainsKey(DateTime.Now.Day))
            ////////    {
            ////////        Count count = new Count();
            ////////        count.TotalNum = Project.Instance.configuration.curTotalNum;
            ////////        count.OKNum = Project.Instance.configuration.curOKNum;
            ////////        count.NGNum = Project.Instance.configuration.curNGNum;
            ////////        Project.Instance.L_count1.Add(DateTime.Now.Day, count);

            ////////        Project.Instance.configuration.curTotalNum = 0;
            ////////        Project.Instance.configuration.curOKNum = 0;
            ////////        Project.Instance.configuration.curNGNum = 0;
            ////////        Thread.Sleep(2000);
            ////////    }
            ////////}

            ////////Frm_Infomation.Instance.lbl_runTime.Text = string.Format("{0} 天 {1} 时 {2} 分 {3} 秒", Device.sw_runTime.Elapsed.Days, Device.sw_runTime.Elapsed.Hours, Device.sw_runTime.Elapsed.Minutes, Device.sw_runTime.Elapsed.Seconds);
            ////////Frm_Infomation.Instance.lbl_productTime.Text = string.Format("{0} 天 {1} 时 {2} 分 {3} 秒", Device.sw_workTime.Elapsed.Days, Device.sw_workTime.Elapsed.Hours, Device.sw_workTime.Elapsed.Minutes, Device.sw_workTime.Elapsed.Seconds);
            ////////Frm_Infomation.Instance.lbl_waitMaterialTime.Text = string.Format("{0} 天 {1} 时 {2} 分 {3} 秒", Device.sw_waitMaterialTime.Elapsed.Days, Device.sw_waitMaterialTime.Elapsed.Hours, Device.sw_waitMaterialTime.Elapsed.Minutes, Device.sw_waitMaterialTime.Elapsed.Seconds);
            ////////Frm_Infomation.Instance.lbl_alarmTime.Text = string.Format("{0} 天 {1} 时 {2} 分 {3} 秒", Device.sw_alarmTime.Elapsed.Days, Device.sw_alarmTime.Elapsed.Hours, Device.sw_alarmTime.Elapsed.Minutes, Device.sw_alarmTime.Elapsed.Seconds);
        }
        private void Frm_Main_Shown(object sender, EventArgs e)
        {
            try
            {
                tmr_update.Enabled = true;

                //初始化后台图像窗口
                for (int i = 0; i < Project.Instance.configuration.windowName.Length; i++)
                {
                    HTuple window;
                    HOperatorSet.OpenWindow(0, 0, 100, 100, 0, "invisible", "", out window);
                    HOperatorSet.SetDraw(window, "margin");
                    HOperatorSet.SetLineWidth(window, 1);
                    Project.D_backImageWindow.Add(Project.Instance.configuration.windowName[i], window);
                }



                if (Project.Instance.configuration.toolBoxStatu == 1)       //悬浮
                {
                    Frm_ToolBox.Instance.Location = new Point(Frm_Main.Instance.Location.X - 151, Frm_Main.Instance.Location.Y + 172);
                    Frm_ToolBox.Instance.Show();
                }

                //流程列表是否隐藏
                if (!Project.Instance.configuration.taskListVisible)
                {
                    if (Frm_Task.Instance.splitContainer1.Panel1Collapsed)
                        Frm_Task.Instance.splitContainer2.Panel1Collapsed = true;
                    else
                        Frm_Task.Instance.splitContainer1.Panel2Collapsed = true;
                }

                //初始化选中页面
                if (Project.Instance.configuration.productCheck)
                    Frm_Vision.Instance.生产toolStripButton1_Click(null, null);
                if (Project.Instance.configuration.taskCheck)
                    Frm_Vision.Instance.任务toolStripButton2_Click(null, null);
                if (Project.Instance.configuration.infomationCheck)
                    Frm_Vision.Instance.统计toolStripButton1_Click(null, null);

                Frm_Vision.Instance.splitContainer2.SplitterDistance = Scheme.curScheme.frm_vison_splitContainer2_splitterDistance;

                Frm_Task.Instance.splitContainer1.SplitterDistance = Scheme.curScheme.frm_task_splitContainer1_splitterDistance;
                Frm_Task.Instance.splitContainer2.SplitterDistance = Scheme.curScheme.frm_task_splitContainer2_splitterDistance;

                //////FuncLib.SetDo(Project.lightCardName, Project.lightIdx, OnOff.On);
                //////FuncLib.SetDo(Project.buzzerCardName, Project.buzzerIdx, OnOff.Off);

                //////FuncLib.SetDo(Do.上光源_C1Out15, OnOff.Off);
                //////FuncLib.SetDo(Do.下光源_C1Out16, OnOff.Off);
            }
            catch (Exception)
            {

            }
        }
        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Project.Instance.configuration.enablePermission)
            {
                DialogResult dialogResult = FuncLib.ShowConfirmDialog("退出前是否需要保存项目？");
                if (dialogResult == DialogResult.OK)
                {
                    Project.Instance.configuration.mainFormHeight = Frm_Main.Instance.Height;
                    Project.Instance.configuration.mainFormWidth = Frm_Main.Instance.Width;

                    //保存页面尺寸信息
                    Scheme.curScheme.frm_vison_splitContainer1_splitterDistance = Frm_Vision.Instance.splitContainer1.SplitterDistance;
                    Scheme.curScheme.frm_vison_splitContainer2_splitterDistance = Frm_Vision.Instance.splitContainer2.SplitterDistance;
                    Scheme.curScheme.frm_task_splitContainer2_splitterDistance = Frm_Task.Instance.splitContainer2.SplitterDistance;
                    Scheme.curScheme.frm_task_splitContainer1_splitterDistance = Frm_Task.Instance.splitContainer1.SplitterDistance;

                    Frm_Motion.Instance.SaveAxisPoint();
                    Project.SaveSysPar();
                    Scheme.SaveCur();
                }
            }

            if (Device.MachineRunStatu == MachineRunStatu.Running || Device.MachineRunStatu == MachineRunStatu.Pause || Device.MachineRunStatu == MachineRunStatu.WaitMaterial || Device.MachineRunStatu == MachineRunStatu.Alarm || Device.MachineRunStatu == MachineRunStatu.HeavyAlarm)
            {
                if (FuncLib.ShowConfirmDialog("程序运行中，是否立即停止并退出？", InfoType.Warn) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
                Frm_Main.Instance.btn_stop_Click(null, null);
                Thread.Sleep(20);
                return;
            }
            else
            {
                if (FuncLib.ShowConfirmDialog("确定要退出吗？", InfoType.Warn) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }


        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //项目自定义
            //////FuncLib.SetDo(Do.上光源_C1Out15, OnOff.Off);
            //////FuncLib.SetDo(Do.下光源_C1Out16, OnOff.Off);


            //////FuncLib.SetDo(Project.lightCardName, Project.lightIdx, OnOff.Off);

            //关闭虚拟键盘
            if (Frm_Vision.processKeyBoard != null && !Frm_Vision.processKeyBoard.HasExited)
                Frm_Vision.processKeyBoard.Kill();

            this.Hide();

            //释放所有服务
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                switch (Project.Instance.L_Service[i].serviceType)
                {
                    case ServiceType.Light:
                        ((LightService)Project.Instance.L_Service[i]).lightBase.CloseAllCh();
                        ((LightService)Project.Instance.L_Service[i]).lightBase.Close();
                        break;
                    case ServiceType.Camera:
                        CCamera.FindCamera(Project.Instance.L_Service[i].name).CloseAll();
                        break;
                    case ServiceType.Card:
                        ((CCard)Project.Instance.L_Service[i]).cardBase.Close();
                        break;
                    case ServiceType.SerialPort:
                        ((Serial)Project.Instance.L_Service[i]).Close();
                        break;
                    case ServiceType.TCPIPClient:
                        ((TCPClient)Project.Instance.L_Service[i]).Disconect();
                        break;
                    case ServiceType.TCPIPSever:
                        ((TCPSever)Project.Instance.L_Service[i]).Disconect();
                        break;
                }
            }
            this.Dispose();
            Process.GetCurrentProcess().Kill();
        }

        private void 激活ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_RegestInfo.hasShown = true;
            new Frm_RegestInfo().ShowDialog();
        }
        private void 建议与反馈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Feedback.Instance.ShowDialog();
        }
        private void 示例方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            OpenFileDialog dig_openImage = new OpenFileDialog();
            dig_openImage.FileName = "";
            dig_openImage.Title = "请选择示例方案";
            dig_openImage.InitialDirectory = Application.StartupPath + "\\Resources\\Samples";
            dig_openImage.Filter = "方案文件(*.shm)|*.shm";
            if (dig_openImage.ShowDialog() == DialogResult.OK)
            {
                cbx_schemeList.Items.Add(Path.GetFileNameWithoutExtension(dig_openImage.FileName));
                Project.L_schemeList.Add(Scheme.curScheme);
                Scheme.Load(dig_openImage.FileName);
            }
        }
        private void 帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuncLib.ShowMessageBox("尚未开发，敬请期待！");
        }
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_About.Instance.ShowDialog();
        }

        private void cbx_schemeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Scheme.curScheme != null && Scheme.curScheme.name == cbx_schemeList.Text)
                return;

            Scheme.Switch(cbx_schemeList.Text);
            Project.SaveSysPar();

            //切换机械和相关参数
            ////////Frm_Debug.Instance.tbx_pcbOffsetX.Text = ((DownCamAlignTool2)Task.FindTaskByName("对位贴合").FindToolByName("对位贴合二")).templatePlacePosOffset.XY.X.ToString();
            ////////Frm_Debug.Instance.tbx_pcbOffsetY.Text = ((DownCamAlignTool2)Task.FindTaskByName("对位贴合").FindToolByName("对位贴合二")).templatePlacePosOffset.XY.Y.ToString();
            ////////Frm_Debug.Instance.tbx_pcbOffsetU.Text = ((DownCamAlignTool2)Task.FindTaskByName("对位贴合").FindToolByName("对位贴合二")).templatePlacePosOffset.U.ToString();

            ////////Frm_Debug.Instance.textBox2.Text = Scheme.curScheme.offsetZ.ToString();
            ////////Frm_Debug.Instance.textBox13.Text = Scheme.curScheme.pickOffsetZ.ToString();
        }
        private void cbx_schemeList_MouseEnter(object sender, EventArgs e)
        {
            cbx_schemeList.RectColor = Color.FromArgb(173, 178, 181);
        }
        private void cbx_schemeList_MouseLeave(object sender, EventArgs e)
        {
            cbx_schemeList.RectColor = Color.FromArgb(240, 240, 240);
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                Device.sw_runTime.Start();  //启动当前程序运行时间计时
                if (Project.Instance.configuration.toolBoxStatu == 1)       //悬浮
                {
                    Frm_Task.Instance.splitContainer1.Panel1Collapsed = true;
                    Frm_Task.Instance.C_toolBox.Parent = Frm_ToolBox.Instance;
                    Frm_Task.Instance.C_toolBox.Dock = DockStyle.Fill;
                }
                if (Project.Instance.configuration.toolBoxStatu == 2)       //关闭
                {
                    if (Frm_Task.Instance.splitContainer1.Panel2Collapsed)
                        Frm_Task.Instance.splitContainer2.Panel1Collapsed = true;
                    else
                        Frm_Task.Instance.splitContainer1.Panel1Collapsed = true;
                    Frm_ToolBox.Instance.Hide();
                }

                if (Project.Instance.configuration.enablePermission)
                    Permission.FuncEnable(PermissionGrade.NoLogin);

                for (int i = 0; i < Project.L_schemeList.Count; i++)
                {
                    Instance.cbx_schemeList.Items.Add(Project.L_schemeList[i].name);
                }

                //显示信息
                Instance.Text = string.Format("{0}_{1}", Project.Instance.configuration.companyName, Project.Instance.configuration.projectName);
                Instance.cbx_schemeList.Text = Scheme.curScheme.name;

                if (Project.Instance.configuration.disenableResizeForm)
                {
                    Instance.TitleHeight = 31;
                    Instance.ShowDragStretch = false;
                    Instance.MinimumSize = Instance.Size;
                    Instance.MaximumSize = Instance.Size;
                    Instance.MaximizeBox = false;
                }
                else
                {
                    Instance.TitleHeight = 35;
                    Instance.ShowDragStretch = true;
                    Instance.MinimumSize = new Size(300, 200);
                    Instance.MaximumSize = new Size(3000, 2000);
                    Instance.MaximizeBox = true;
                }
                //控制模式
                switch (Project.Instance.configuration.controlType)
                {
                    case ControlType.StartStopPauseReset:
                        Instance.btn_start.Enabled = false;
                        Instance.btn_stop.Enabled = false;
                        Instance.btn_pause.Enabled = false;
                        break;
                    case ControlType.StartStop:
                        Instance.btn_pause.Visible = false;
                        Instance.btn_reset.Visible = false;
                        break;
                    case ControlType.Empty:
                        Instance.btn_start.Visible = false;
                        Instance.btn_stop.Visible = false;
                        Instance.btn_pause.Visible = false;
                        Instance.btn_reset.Visible = false;
                        break;
                }

                Instance.Height = Project.Instance.configuration.mainFormHeight;
                Instance.Width = Project.Instance.configuration.mainFormWidth;

                string date = File.GetLastWriteTime(Application.StartupPath + "\\VM Pro.exe").ToString("yyyy-MM-dd");
                Instance.Text = string.Format("{0} - {1}  V {2}", Project.Instance.configuration.companyName, Project.Instance.configuration.projectName, string.Format("{0} {1}", date, ((AssemblyConfigurationAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false))[0]).Configuration));

                //窗体最大化
                if (Project.Instance.configuration.autoMax)
                    Instance.WindowState = FormWindowState.Maximized;

                //不允许改变窗体大小
                if (Project.Instance.configuration.disenableResizeForm)
                {
                    Instance.MinimumSize = Instance.Size;
                    Instance.MaximumSize = Instance.Size;
                }
                else
                {
                    Instance.MinimumSize = new Size(300, 200);
                    Instance.MaximumSize = new Size(3000, 2000);
                }

                Instance.lbl_CT.ForeColor = Color.White;
                Instance.lbl_deviceStatu.ForeColor = Color.White;
                Instance.uiMarkLabel1.ForeColor = Color.White;

                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    switch (Project.Instance.L_Service[i].serviceType)
                    {
                        case ServiceType.TCPIPSever:
                            TCPSever tcpSever = (TCPSever)Project.Instance.L_Service[i];

                            //状态显示图标
                            UISymbolButton button = GetCanUseServiceButton();
                            button.Visible = true;
                            button.Tag = "1";           //表示已经被使用过了
                            button.Text = tcpSever.name;
                            if (TCPSever.FindSeverByName(tcpSever.name).L_clientItem.Count == tcpSever.D_clientIPAndName.Count)
                            {
                                //button.ForeColor = Color.Green;
                                //button.ForeDisableColor = Color.Green;
                                button.SymbolColor = Color.Green;
                            }
                            else
                            {
                                //button.ForeColor = Color.Red;
                                //button.ForeDisableColor = Color.Red;
                                button.SymbolColor = Color.Red;
                            }
                            Instance.uiToolTip1.SetToolTip(button, "IP     : " + tcpSever.severIP + '\n' + "Port : " + tcpSever.severPort, tcpSever.name, 61530, 32, UIColor.Green);
                            break;

                        case ServiceType.TCPIPClient:
                            TCPClient tcpClient = (TCPClient)Project.Instance.L_Service[i];

                            //状态显示图标
                            button = GetCanUseServiceButton();
                            button.Visible = true;
                            button.Tag = "1";           //表示已经被使用过了
                            button.Text = tcpClient.name;
                            button.SymbolColor = (TCPClient.FindClientByName(tcpClient.name).Connected ? Color.Green : Color.Red);
                            //button.ForeDisableColor = (TCPClient.FindClientByName(tcpClient.name).Connected ? Color.Green : Color.Red);
                            Instance.uiToolTip1.SetToolTip(button, "IP     : " + tcpClient.severIP + '\n' + "Port : " + tcpClient.severPort, tcpClient.name, 61530, 32, UIColor.Green);
                            break;

                        case ServiceType.Camera:
                            CCamera ccamera = (CCamera)Project.Instance.L_Service[i];

                            //状态显示图标
                            button = GetCanUseServiceButton();
                            button.Visible = true;
                            button.Tag = "1";           //表示已经被使用过了
                            button.Text = ccamera.name;
                            button.SymbolColor = ccamera.Connected ? Color.Green : Color.Red;
                            //button.ForeDisableColor = ccamera.Connected ? Color.Green : Color.Red;
                            Instance.uiToolTip1.SetToolTip(button, "相机信息 : " + ccamera.cameraInfoStr, ccamera.name, 61530, 32, UIColor.Green);
                            break;

                        case ServiceType.Light:
                            LightService lightService = (LightService)Project.Instance.L_Service[i];

                            //状态显示图标
                            button = GetCanUseServiceButton();
                            button.Visible = true;
                            button.Tag = "1";           //表示已经被使用过了
                            button.Text = lightService.name;
                            button.SymbolColor = lightService.Connected ? Color.Green : Color.Red;
                            //button.ForeDisableColor = lightService.Connected ? Color.Green : Color.Red;
                            Instance.uiToolTip1.SetToolTip(button, "串口信息 : " + lightService.lightBase.portName, lightService.name, 61530, 32, UIColor.Green);
                            break;

                        case ServiceType.SerialPort:
                            Serial serial = (Serial)Project.Instance.L_Service[i];

                            //状态显示图标
                            button = GetCanUseServiceButton();
                            button.Visible = true;
                            button.Tag = "1";           //表示已经被使用过了
                            button.Text = serial.name;
                            button.SymbolColor = Serial.FindSerialPortByName(serial.name).IsOpen ? Color.Green : Color.Red;
                            //button.ForeDisableColor = Serial.FindSerialPortByName(serial.name).IsOpen ? Color.Green : Color.Red;
                            Instance.uiToolTip1.SetToolTip(button, "相机信息 : ", serial.name, 61530, 32, UIColor.Green);
                            break;
                        case ServiceType.Card:
                            CCard cCard = (CCard)Project.Instance.L_Service[i];

                            //状态显示图标
                            button = GetCanUseServiceButton();
                            button.Visible = true;
                            button.Tag = "1";           //表示已经被使用过了
                            button.Text = cCard.name;
                            button.SymbolColor = cCard.Connected ? Color.Green : Color.Red;
                            //button.ForeDisableColor = cCard.Connected ? Color.Green : Color.Red;
                            Instance.uiToolTip1.SetToolTip(button, "相机信息 : ", cCard.name, 61530, 32, UIColor.Green);
                            break;
                    }
                }

                UpdateForm(true);

                if (Project.Instance.configuration.controlType == ControlType.StartStopPauseReset)
                    Device.MachineRunStatu = MachineRunStatu.WaitReset;




                Frm_Vision.Instance.任务toolStripButton2.Visible = Project.Instance.configuration.taskFormEnable;
                Frm_Vision.Instance.生产toolStripButton1.Visible = Project.Instance.configuration.produceFormEnable;
                Frm_Vision.Instance.统计toolStripButton1.Visible = Project.Instance.configuration.infomationFormEnable;
                if ((Project.Instance.configuration.taskFormEnable && !Project.Instance.configuration.produceFormEnable & !Project.Instance.configuration.infomationFormEnable) ||
                    (!Project.Instance.configuration.taskFormEnable && Project.Instance.configuration.produceFormEnable & !Project.Instance.configuration.infomationFormEnable) ||
                    (!Project.Instance.configuration.taskFormEnable && !Project.Instance.configuration.produceFormEnable & Project.Instance.configuration.infomationFormEnable))
                {
                    Frm_Vision.Instance.任务toolStripButton2.Visible = false;
                    Frm_Vision.Instance.生产toolStripButton1.Visible = false;
                    Frm_Vision.Instance.统计toolStripButton1.Visible = false;
                    Frm_Vision.Instance.toolStripSeparator1.Visible = false;
                }

                //Frm_Task.Instance.splitContainer2.SplitterDistance = Scheme.curScheme.frm_task_splitContainer2_splitterDistance;
                //Frm_Task.Instance.splitContainer1.SplitterDistance = Scheme.curScheme.frm_task_splitContainer1_splitterDistance;
                //更新窗体布局
                Frm_Vision.Instance.splitContainer1.SplitterDistance = Scheme.curScheme.frm_vison_splitContainer1_splitterDistance;
                Frm_Task.Instance.splitContainer1.SplitterDistance = Scheme.curScheme.frm_task_splitContainer1_splitterDistance;
                Frm_Vision.Instance.splitContainer2.SplitterDistance = Scheme.curScheme.frm_vison_splitContainer2_splitterDistance;
                Frm_Task.Instance.splitContainer2.SplitterDistance = Scheme.curScheme.frm_task_splitContainer2_splitterDistance;
                Frm_Welcome.Instance.Hide();
            }
            catch (Exception)
            {
            }
        }
        private void btn_sevice_Click(object sender, EventArgs e)
        {
            //Frm_System.Instance.Show();
            //Frm_System.Instance.Activate();
            //for (int i = 0; i < Frm_Service.Instance.tvw_serviceList.Nodes.Count; i++)
            //{
            //    if (Frm_Service.Instance.tvw_serviceList.Nodes[i].Text == ((UISymbolButton)sender).Text)
            //    {
            //        Frm_Service.Instance.tvw_serviceList.SelectedNode = Frm_Service.Instance.tvw_serviceList.Nodes[i];
            //        break;
            //    }
            //}
            //Frm_Task.Instance.btn_runOnce_Click(null, null);
        }
        private void uiLabel2_DoubleClick(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            Frm_System.Instance.pnl_window.Controls.Clear();
            Frm_Scheme.Instance.TopLevel = false;
            Frm_Scheme.Instance.Parent = Frm_System.Instance.pnl_window;
            Frm_Scheme.Instance.Show();

            Frm_System.Instance.Show();
            Frm_System.Instance.Activate();
        }

        private void Header_NodeMouseClick(TreeNode node, int menuIndex, int pageIndex)
        {
            if (Header.SelectedIndex > 0)
            {
                updateIO = false;
                th_update = new Thread(() =>
                {
                    Thread.Sleep(500);
                    updateIO = true;

                    while (updateIO)
                    {
                        if (Header.SelectedIndex == 1)
                        {

                            CCard card = ((CCard)Project.FindServiceByName(Frm_Motion.Instance.cbx_cardList.Text));
                            if (card == null)
                                continue;

                            if (Frm_Motion.Instance.cbx_axisList.SelectedIndex < 0)
                                continue;

                            if (card.cardBase.GetMotorStatu(Frm_Motion.Instance.cbx_axisList.SelectedIndex))
                            {
                                Frm_Motion.Instance.btn_motorOn.RectColor = Color.FromArgb(80, 160, 255);
                                Frm_Motion.Instance.btn_motorOn.FillColor = Color.FromArgb(80, 160, 255);
                            }
                            else
                            {
                                Frm_Motion.Instance.btn_motorOn.RectColor = Color.LightGray;
                                Frm_Motion.Instance.btn_motorOn.FillColor = Color.LightGray;
                            }

                            try
                            {
                                Frm_Motion.Instance.lbl_cmdPos.Text = card.cardBase.GetCmdPos(Frm_Motion.Instance.cbx_axisList.SelectedIndex).ToString("0.000");
                                Frm_Motion.Instance.lbl_encPos.Text = card.cardBase.GetCmdPos(Frm_Motion.Instance.cbx_axisList.SelectedIndex).ToString("0.000");
                                Frm_Motion.Instance.pic_P.Image = (card.cardBase.InPEL(Frm_Motion.Instance.cbx_axisList.SelectedIndex) ? (Image)Resources.Error.Clone() : (Image)Resources.Off.Clone());
                                Frm_Motion.Instance.pic_O.Image = (card.cardBase.InHome(Frm_Motion.Instance.cbx_axisList.SelectedIndex) ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                Frm_Motion.Instance.pic_N.Image = (card.cardBase.InNEL(Frm_Motion.Instance.cbx_axisList.SelectedIndex) ? (Image)Resources.Error.Clone() : (Image)Resources.Off.Clone());
                                Frm_Motion.Instance.pic_err.Image = (card.cardBase.IsAlarm(Frm_Motion.Instance.cbx_axisList.SelectedIndex) ? (Image)Resources.Error.Clone() : (Image)Resources.Off.Clone());
                                Frm_Motion.Instance.pic_moving.Image = (card.cardBase.IsMoving(Frm_Motion.Instance.cbx_axisList.SelectedIndex) ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                Frm_Motion.Instance.pic_inp.Image = (card.cardBase.Inp(Frm_Motion.Instance.cbx_axisList.SelectedIndex) ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                Frm_Motion.Instance.pic_homeOK.Image = Project.L_axis[Frm_Motion.Instance.cbx_axisList.SelectedIndex].homeOK ? (Image)Resources.On.Clone() : (Image)Resources.Error.Clone();
                            }
                            catch { }
                        }


                        if (Header.SelectedIndex == 2)
                        {


                            for (int i = 0; i < Project.L_di.Count; i++)
                            {
                                if (!Project.L_di[i].isVitual)
                                {
                                    OnOff onOff = ((CCard)Project.FindServiceByName(Project.L_di[i].cardName)).cardBase.GetDiSts(Project.L_di[i].diName);
                                    if (onOff != (OnOff)Frm_IO.Instance.dgv_diList.Rows[Project.L_di[i].index - 1].Cells[3].Tag)
                                    {
                                        Frm_IO.Instance.dgv_diList.Rows[Project.L_di[i].index - 1].Cells[3].Value = (onOff == OnOff.On ? Resources.On : Resources.Off);
                                        Frm_IO.Instance.dgv_diList.Rows[Project.L_di[i].index - 1].Cells[3].Tag = onOff;
                                    }
                                }
                            }

                            for (int i = 0; i < Project.L_do.Count; i++)
                            {
                                if (!Project.L_do[i].isVirtual)
                                {
                                    OnOff onOff = ((CCard)Project.FindServiceByName(Project.L_do[i].cardName)).cardBase.GetDoSts(Project.L_do[i].doName);
                                    if (onOff != (OnOff)Frm_IO.Instance.dgv_doList.Rows[Project.L_do[i].index - 1].Cells[3].Tag)
                                    {
                                        Frm_IO.Instance.dgv_doList.Rows[Project.L_do[i].index - 1].Cells[3].Value = (onOff == OnOff.On ? Resources.On : Resources.Off);
                                        Frm_IO.Instance.dgv_doList.Rows[Project.L_do[i].index - 1].Cells[3].Tag = onOff;
                                    }
                                }
                            }

                            for (int i = 0; i < Project.L_cylinder1.Count; i++)
                            {
                                if (Project.L_cylinder1[i].actOutNo2 != -1)      //双控气缸
                                {
                                    if (((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActOutNo1)).cardBase.GetDoSts(Project.L_cylinder1[i].actOutNo1) == OnOff.Off && ((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActOutNo2)).cardBase.GetDoSts(Project.L_cylinder1[i].actOutNo2) == OnOff.Off)
                                    {
                                        Project.L_cCylinder1[Project.L_cylinder1[i].name].btn_on.BackColor = ((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActInNo1)).cardBase.GetDiSts(Project.L_cylinder1[i].actInNo1) == OnOff.On ? Color.Green : Color.Gainsboro;
                                        Project.L_cCylinder1[Project.L_cylinder1[i].name].btn_off.BackColor = ((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActInNo1)).cardBase.GetDiSts(Project.L_cylinder1[i].actInNo1) == OnOff.On ? Color.Gainsboro : Color.Green;
                                    }
                                    else
                                    {
                                        Project.L_cCylinder1[Project.L_cylinder1[i].name].btn_on.BackColor = ((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActOutNo1)).cardBase.GetDoSts(Project.L_cylinder1[i].actOutNo1) == OnOff.On ? Color.Gainsboro : Color.Green;
                                        Project.L_cCylinder1[Project.L_cylinder1[i].name].btn_off.BackColor = ((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActOutNo1)).cardBase.GetDoSts(Project.L_cylinder1[i].actOutNo1) == OnOff.On ? Color.Green : Color.Gainsboro;
                                    }
                                }
                                else         //单控气缸
                                {
                                    if (((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActOutNo1)).cardBase.GetDoSts(Project.L_cylinder1[i].actOutNo1) == OnOff.Off && ((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActOutNo2)).cardBase.GetDoSts(Project.L_cylinder1[i].actOutNo2) == OnOff.Off)
                                    {
                                        Project.L_cCylinder1[Project.L_cylinder1[i].name].btn_on.BackColor = ((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActInNo1)).cardBase.GetDiSts(Project.L_cylinder1[i].actInNo1) == OnOff.On ? Color.Green : Color.Gainsboro;
                                        Project.L_cCylinder1[Project.L_cylinder1[i].name].btn_off.BackColor = ((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActInNo1)).cardBase.GetDiSts(Project.L_cylinder1[i].actInNo1) == OnOff.On ? Color.Green : Color.Gainsboro;
                                    }
                                    else
                                    {
                                        Project.L_cCylinder1[Project.L_cylinder1[i].name].btn_on.BackColor = ((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActOutNo1)).cardBase.GetDoSts(Project.L_cylinder1[i].actOutNo1) == OnOff.On ? Color.Green : Color.Gainsboro;
                                        Project.L_cCylinder1[Project.L_cylinder1[i].name].btn_off.BackColor = ((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActOutNo1)).cardBase.GetDoSts(Project.L_cylinder1[i].actOutNo1) == OnOff.On ? Color.Gainsboro : Color.Green;
                                    }
                                }

                                Project.L_cCylinder1[Project.L_cylinder1[i].name].pic_originStatu.ForeColor = ((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActInNo1)).cardBase.GetDiSts(Project.L_cylinder1[i].actInNo1) == OnOff.On ? Color.Green : Color.DarkGray;
                                Project.L_cCylinder1[Project.L_cylinder1[i].name].pic_actStatu.ForeColor = ((CCard)Project.FindServiceByName(Project.L_cylinder1[i].cardNameActOutNo1)).cardBase.GetDiSts(Project.L_cylinder1[i].actInNo2) == OnOff.On ? Color.Green : Color.DarkGray;
                            }

                            for (int i = 0; i < Project.L_vacuum.Count; i++)
                            {
                                Project.L_cVacuum[Project.L_vacuum[i].name].btn_on.BackColor = ((CCard)Project.FindServiceByName(Project.L_vacuum[i].cardNameOut)).cardBase.GetDoSts(Project.L_vacuum[i].actOutNo) == OnOff.On ? Color.Green : Color.Gainsboro;
                                if (Project.L_vacuum[i].actOutBlowNo != -1)
                                    Project.L_cVacuum[Project.L_vacuum[i].name].btn_blow.BackColor = ((CCard)Project.FindServiceByName(Project.L_vacuum[i].cardNameBlow)).cardBase.GetDoSts(Project.L_vacuum[i].actOutBlowNo) == OnOff.On ? Color.Green : Color.Gainsboro;
                                else
                                    Project.L_cVacuum[Project.L_vacuum[i].name].btn_blow.Visible = false;
                                Project.L_cVacuum[Project.L_vacuum[i].name].pic_vacuumStatu.ForeColor = ((CCard)Project.FindServiceByName(Project.L_vacuum[i].cardNameIn)).cardBase.GetDiSts(Project.L_vacuum[i].actInNo) == OnOff.On ? Color.Green : Color.DarkGray;
                            }

                        }

                        Thread.Sleep(100);
                    }
                });
                th_update.IsBackground = true;
                th_update.Start();
            }
            else
            {
                updateIO = false;
            }
        }

        private void btn_reset_MouseDown(object sender, MouseEventArgs e)
        {
            isStop = false;
            sw = new Stopwatch();
            sw.Start();
            Thread th = new Thread(CountTime);
            th.IsBackground = true;
            th.Start();
        }
        private void btn_reset_MouseUp(object sender, MouseEventArgs e)
        {
            if (Device.MachineRunStatu == MachineRunStatu.WaitReset || Device.MachineRunStatu == MachineRunStatu.WaitRun || Device.MachineRunStatu == MachineRunStatu.Stop || Device.MachineRunStatu == MachineRunStatu.HeavyAlarm)
            {
                if (sw == null || sw.ElapsedMilliseconds > 1000)
                {
                    if (sw != null)
                    {
                        sw.Stop();
                        isStop = true;
                    }

                    Thread th = new Thread(() =>
                    {
                        Frm_Vision.Instance.hWindow_Final1.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final2.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final3.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final4.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final5.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final6.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final7.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final8.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final9.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final10.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final11.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final12.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final13.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final14.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final15.ClearWindow();
                        Frm_Vision.Instance.hWindow_Final16.ClearWindow();

                        btn_reset.Enabled = false;
                        Device.MachineRunStatu = MachineRunStatu.Stop;
                        Thread.Sleep(100);
                        Device.MachineRunStatu = MachineRunStatu.Homing;
                        isStop = true;

                        btn_start.Text = "启动";
                        btn_start.Enabled = false;
                        btn_stop.Text = "停止";
                        btn_pause.Text = "暂停";
                        btn_reset.Text = "复位";

                        Device.machineHomeResult = 0;
                        MainTask.HomeAll();

                        btn_reset.Enabled = true;
                        Header.SelectedIndex = 0;
                        if (Device.machineHomeResult == 2)
                        {
                            btn_start.Enabled = true;
                            btn_reset.Text = "已复位";
                            btn_reset.FillColor = Color.Green;
                            btn_reset.RectColor = Color.Green;
                            Device.MachineRunStatu = MachineRunStatu.WaitRun;
                        }
                        else
                        {
                            btn_start.Enabled = false;
                            Device.MachineRunStatu = MachineRunStatu.WaitReset;
                        }

                        //检查是否存在虚拟输入
                        foreach (KeyValuePair<Di, int> item in Project.D_diVitual)
                        {
                            if (item.Value != 0)
                            {
                                FuncLib.ShowMessageBox(string.Format("输入信号 {0} 正处于虚拟状态，建议手动关闭后在启动", item.Key), InfoType.Warn);
                                break;
                            }
                        }

                        //项目自定义
                        FuncLib.SetDo(Do.启动灯_C1Out00, OnOff.Off);
                        FuncLib.SetDo(Do.停止灯_C1Out02, OnOff.Off);
                        FuncLib.SetDo(Do.复位灯_C1Out01, OnOff.Off);
                    });
                    th.IsBackground = true;
                    th.Start();
                }
                else
                {
                    FuncLib.ShowMsg("整机复位请长按超过2秒", InfoType.Warn);
                    isStop = true;
                    sw.Stop();
                    sw.Reset();
                    btn_reset.Text = "复位";
                }
            }
            else
            {
                //关闭蜂鸣器
                Device.alarmReseted = true;
                FuncLib.SetDo(Do.蜂鸣器_C1Out06, OnOff.Off);
            }
        }

        /// <summary>
        /// 主题颜色切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 青春自由蓝ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ToolStripItem currentToolStrip = sender as ToolStripItem;
            if (currentToolStrip != null)
            {
                UIStyle style = (UIStyle)Convert.ToInt32(currentToolStrip.Tag);
                StyleManager.Style = style;
            }
        }


    }
}
