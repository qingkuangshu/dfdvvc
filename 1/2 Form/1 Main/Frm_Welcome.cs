using Microsoft.Win32;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace VM_Pro
{
    public partial class Frm_Welcome : Form
    {
        /// <summary>
        /// 欢饮界面
        /// </summary>
        public Frm_Welcome()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 线程1加载
        /// </summary>
        internal static bool th1IsLoading = true;
        /// <summary>
        /// 线程2加载
        /// </summary>
        internal static bool th2IsLoading = true;
        /// <summary>
        /// 项目是否已加载完成
        /// </summary>
        private bool projectLoadOK = false;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Welcome _instance;
        internal static Frm_Welcome Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Welcome();
                return _instance;
            }
        }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Welcome_Shown(object sender, EventArgs e)
        {
            try
            {
                Thread th1 = new Thread(() =>
                {
                    th1IsLoading = true;
                    //初始化所有  
                    Application.DoEvents();

                    #region 检查文件目录
                    if (!Directory.Exists(Application.StartupPath + "\\Config\\Project"))
                        Directory.CreateDirectory(Application.StartupPath + "\\Config\\Project");

                    if (!Directory.Exists(Application.StartupPath + "\\Config\\Project\\Scheme"))
                        Directory.CreateDirectory(Application.StartupPath + "\\Config\\Project\\Scheme");

                    if (!Directory.Exists(Application.StartupPath + "\\Resources"))
                        Directory.CreateDirectory(Application.StartupPath + "\\Resources");

                    if (!Directory.Exists(Application.StartupPath + "\\Resources\\Samples"))
                        Directory.CreateDirectory(Application.StartupPath + "\\Resources\\Samples");

                    if (Directory.Exists(Application.StartupPath + "\\MvSdkLog"))
                        Directory.Delete(Application.StartupPath + "\\MvSdkLog", true);
                    #endregion

                    #region 加载项目
                    ShowStep(10);
                    ShowStep("正在加载当前项目");
                    Project.Load();
                    projectLoadOK = true;
                    #endregion

                    #region 布局图像窗口以及页面尺寸
                    //页面可见


                    lbl_companyName.Text = Project.Instance.configuration.companyName;
                    Application.DoEvents();

                    Frm_Vision.Instance.splitContainer2.SplitterDistance = Scheme.curScheme.frm_vison_splitContainer2_splitterDistance;
                    Frm_Vision.Instance.splitContainer1.SplitterDistance = Scheme.curScheme.frm_vison_splitContainer1_splitterDistance;
                    Frm_Task.Instance.splitContainer2.SplitterDistance = Scheme.curScheme.frm_task_splitContainer2_splitterDistance;
                    Frm_Task.Instance.splitContainer1.SplitterDistance = Scheme.curScheme.frm_task_splitContainer1_splitterDistance;

                    //Frm_Vision.UpdateWindowLayout();
                    Frm_Vision.Instance.hWindow_Final1.ReName(Project.Instance.configuration.windowName[0]);
                    Frm_Vision.Instance.hWindow_Final2.ReName(Project.Instance.configuration.windowName[1]);
                    Frm_Vision.Instance.hWindow_Final3.ReName(Project.Instance.configuration.windowName[2]);
                    Frm_Vision.Instance.hWindow_Final4.ReName(Project.Instance.configuration.windowName[3]);
                    Frm_Vision.Instance.hWindow_Final5.ReName(Project.Instance.configuration.windowName[4]);
                    Frm_Vision.Instance.hWindow_Final6.ReName(Project.Instance.configuration.windowName[5]);
                    Frm_Vision.Instance.hWindow_Final7.ReName(Project.Instance.configuration.windowName[6]);
                    Frm_Vision.Instance.hWindow_Final8.ReName(Project.Instance.configuration.windowName[7]);
                    Frm_Vision.Instance.hWindow_Final9.ReName(Project.Instance.configuration.windowName[8]);
                    Frm_Vision.Instance.hWindow_Final10.ReName(Project.Instance.configuration.windowName[9]);
                    Frm_Vision.Instance.hWindow_Final11.ReName(Project.Instance.configuration.windowName[10]);
                    Frm_Vision.Instance.hWindow_Final12.ReName(Project.Instance.configuration.windowName[11]);
                    Frm_Vision.Instance.hWindow_Final13.ReName(Project.Instance.configuration.windowName[12]);
                    Frm_Vision.Instance.hWindow_Final14.ReName(Project.Instance.configuration.windowName[13]);
                    Frm_Vision.Instance.hWindow_Final15.ReName(Project.Instance.configuration.windowName[14]);
                    Frm_Vision.Instance.hWindow_Final16.ReName(Project.Instance.configuration.windowName[15]);


                    Frm_Vision.Instance.label1.Visible =
                    Frm_Vision.Instance.lbl_askMaterial.Visible =
                    Frm_Vision.Instance.lbl_nextAskMaterial.Visible =
                    Frm_Vision.Instance.pic_askMaterial.Visible =
                    Frm_Vision.Instance.pic_nextAskMaterial.Visible = Project.Instance.configuration.onLine;

                    Device.startTime = DateTime.Now;
                    #endregion

                    #region 产量、日志过期清理设置
                    Frm_Msg.Instance.tsb_historyAlarm.Text = string.Format("历史报警({0})", Project.Instance.D_historyAlarm.Count);

                    //显示生产统计信息
                    //Frm_Infomation.Instance.lbl_totalNum.Text = Project.Instance.configuration.totalNum.ToString();
                    //Frm_Infomation.Instance.lbl_ngNum.Text = Project.Instance.configuration.NGNum.ToString();
                    //Frm_Infomation.Instance.lbl_okNum.Text = Project.Instance.configuration.OKNum.ToString();
                    //Frm_Infomation.Instance.lbl_yield.Text = Math.Round((Project.Instance.configuration.OKNum / (Project.Instance.configuration.totalNum * 0.01)), 2).ToString() + "%";
                    //Frm_Infomation.Instance.ckb_StartUpload.Checked = Project.Instance.configuration.projectCfg.isStartBuMa;
                    //Frm_Infomation.Instance.txt_UploadTime.Text = Project.Instance.configuration.projectCfg.UploadTime.ToString();
                    //Frm_Infomation.Instance.txt_NGOverrunNum.Text = Project.Instance.configuration.projectCfg.NGOverrunNum.ToString();


                    //Frm_Debug.Instance.lb_OK.Text = Project.Instance.configuration.OKNum.ToString();
                    //Frm_Debug.Instance.lb_NG.Text = Project.Instance.configuration.NGNum.ToString();
                    //Frm_Debug.Instance.lb_AllNum.Text = (Project.Instance.configuration.OKNum + Project.Instance.configuration.NGNum).ToString();
                    //Frm_Debug.Instance.lb_Lianglv.Text = (Project.Instance.configuration.OKNum * 1.0 / (Project.Instance.configuration.OKNum + Project.Instance.configuration.NGNum) * 100).ToString("F2") + " %";


                    //清除过期缓存数据
                    Thread th3 = new Thread(() =>
                    {
                        if (Directory.Exists(Project.Instance.configuration.dataPath))
                        {
                            DateTime now = DateTime.Now;
                            string NewPath = Project.Instance.configuration.dataPath +"\\"+ now.ToString("yyyy") + "\\" + now.ToString("MMMM");
                            string[] directorys = Directory.GetDirectories(NewPath);
                            for (int i = 0; i < directorys.Length; i++)
                            {
                                DirectoryInfo dir = new DirectoryInfo(directorys[i]);
                                DateTime dt = dir.CreationTime;
                                if (Project.Instance.configuration.dateSaveTimeBasedDay)
                                {
                                    int tep = (now - dt).Days;
                                    if ((now - dt).Days > Project.Instance.configuration.dataSaveTime)
                                    {
                                        try
                                        {
                                            Directory.Delete(directorys[i], true);
                                        }
                                        catch { }
                                    }
                                }
                                else
                                {
                                    int tep = (now - dt).Hours;
                                    if ((now - dt).Hours > Project.Instance.configuration.dataSaveTime)
                                    {
                                        try
                                        {
                                            Directory.Delete(directorys[i], true);
                                        }
                                        catch { }
                                    }
                                }
                            }
                        }
                    });
                    th3.IsBackground = true;
                    th3.Start();

                    #endregion

                    #region  加载点表 【1.运控层面的东西，在系统选项当中选择空型控制的话，应该不用加载运控的相关信息，具体待测】
                    //Frm_Motion.Instance.cbx_tableList.Items.Clear();
                    //for (int i = 0; i < Scheme.curScheme.smartPosTable.L_Table.Count; i++)
                    //{
                    //    Frm_Motion.Instance.cbx_tableList.Items.Add(Scheme.curScheme.smartPosTable.L_Table[i].tableName);
                    //}
                    //if (Frm_Motion.Instance.cbx_tableList.Items.Count > 0)
                    //    Frm_Motion.Instance.cbx_tableList.SelectedIndex = 0;
                    #endregion

                    #region MES登录

                    ////////更新MES地址
                    ////////string date = File.ReadAllText(Application.StartupPath + "\\VM Pro.exe.config");
                    ////////string str1 = Regex.Split(date, "http")[0];
                    ////////string str2 = Regex.Split(date, "asmx")[1];
                    ////////File.WriteAllText(Application.StartupPath + "\\VM Pro.exe.config", str1 + Project.Instance.configuration.MESServiceAddress + str2);

                    ////////if (Project.Instance.configuration.MESEnable)
                    ////////{
                    ////////    Thread.Sleep(200);

                    ////////    if (MainTask.mes == null)
                    ////////        MainTask.mes = new ServiceReference1.MESInterfaceSoapClient();

                    ////////    string rtn = MainTask.mes.CheckUserDo(Project.Instance.configuration.MESUserName, Project.Instance.configuration.MESPassword, Project.Instance.configuration.MESMachineNo);
                    ////////    if (rtn.Length >= 4 && rtn.Substring(0, 4) == "TRUE")
                    ////////    {
                    ////////        Project.mesLoginOK = true;
                    ////////    }
                    ////////    else
                    ////////    {
                    ////////        Project.mesLoginErrr = rtn;
                    ////////        Project.mesLoginOK = false;
                    ////////        FuncLib.ShowMessageBox("MES登录失败");
                    ////////        FuncLib.ShowMsg("MES登录失败，请联系MES或AE人员处理！MES返回值为：" + rtn, InfoType.Error);
                    ////////    }
                    ////////}

                    #endregion

                    //1.主逻辑控制类，根据实际的项目需求，看逻辑卡控类是否需要放置于此处
                    //MainTask.InitAll();   //若当前由点位触发的话，则可考虑用此方式来进行编写

                    //项目自定义

                    #region  1. 项目自定义界面所需显示的信息

                    //Frm_Debug.Instance.DgvData.Rows.Add(7);


                    //显示生产界面当中的表格信息
                    if (Project.Instance.configuration.lstLeiBie != null)
                    {
                        for (int i = 0; i < Project.Instance.configuration.lstLeiBie.Count; i++)
                        {
                            Frm_Debug.Instance.DgvData.Rows.Add();
                            Frm_Debug.Instance.DgvData.Rows[i].Cells[0].Value = Project.Instance.configuration.lstLeiBie[i].LeiBie;
                            Frm_Debug.Instance.DgvData.Rows[i].Cells[1].Value = Project.Instance.configuration.lstLeiBie[i].MinArea;
                            Frm_Debug.Instance.DgvData.Rows[i].Cells[2].Value = Project.Instance.configuration.lstLeiBie[i].BeforArea;
                            Frm_Debug.Instance.DgvData.Rows[i].Cells[3].Value = Project.Instance.configuration.lstLeiBie[i].MaxArea;
                            Frm_Debug.Instance.DgvData.Rows[i].Cells[4].Value = Project.Instance.configuration.lstLeiBie[i].NG;
                            Frm_Debug.Instance.DgvData.Rows[i].Cells[5].Value = Project.Instance.configuration.lstLeiBie[i].CheckEnable;
                        }
                    }


                    #endregion





                    th1IsLoading = false;
                });
                th1.IsBackground = true;
                th1.Start();

                Thread th2 = new Thread(() =>
                {
                    th2IsLoading = true;

                    #region 检查是否注册

                    //////////如果没有注册，则只能使用7天
                    ////////ShowStep(5);
                    ////////ShowStep("正在检查注册状态");
                    ////////Ini ini = new Ini(Application.StartupPath + "\\Config\\SysConfig.ini");
                    ////////string regiestCode = ini.IniReadConfig("RegiestCode");
                    ////////if (Method.GetMD5(Regiest.GetRegiestCode()) != regiestCode)
                    ////////{
                    ////////    //判断是否使用超过7天
                    ////////    DateTime startDate;
                    ////////    try
                    ////////    {
                    ////////        startDate = Convert.ToDateTime(ini.IniReadConfig("StartDate"));
                    ////////        if ((DateTime.Now - startDate).Days > 7 || (startDate - DateTime.Now).Days > 7)   //开始时间必须要在7天之内，如果用户修改配置文件里面的时间，确实是可以使用，但是用户每7天都要修改一次才行
                    ////////        {
                    ////////            Frm_Regiest.hasShown = true;
                    ////////            if (Frm_Regiest.Instance.ShowDialog() != DialogResult.OK)
                    ////////            {
                    ////////                Process.GetCurrentProcess().Kill();         //强制退出
                    ////////            }
                    ////////            else
                    ////////            {
                    ////////                Regiest.regiested = true;
                    ////////            }
                    ////////        }
                    ////////    }
                    ////////    catch       //如果是第一次使用，应该是没有存时间的就会报错，那就存入当前时间
                    ////////    {
                    ////////        ini.IniWriteConfig("StartDate", DateTime.Now.ToString());
                    ////////    }
                    ////////}
                    ////////else
                    ////////{
                    ////////    Regiest.regiested = true;
                    ////////}

                    #endregion

                    while (!projectLoadOK)
                    {
                        Thread.Sleep(200);
                    }

                    #region 初始化相机
                    ShowStep(50);
                    ShowStep("正在初始化相机");
                    if (!Project.Instance.configuration.enableHalconSdk)
                    {
                        //海康相机
                        if (Project.Instance.configuration.enableHikvisionSdk)
                        {
                            ShowStep("正在初始化 海康威视 相机");
                            new SDK_HIKVision(string.Empty).EnumCamera();
                        }
                        ShowStep(55);

                        //大恒相机
                        if (Project.Instance.configuration.enableDaHengSdk)
                        {
                            ShowStep("正在初始化 大恒 相机");            //大恒相机和AVT相机的驱动冲突，AVT相机也枚举以后，大恒相机就无法采图了
                            SDK_DaHeng.Instance.EnumCamera();
                        }
                        ShowStep(60);

                        //AVT相机
                        if (Project.Instance.configuration.enableAVTSdk)
                        {
                            ShowStep("正在初始化 AVT 相机");       //大恒相机和AVT相机的驱动冲突，AVT相机也枚举以后，大恒相机就无法采图了
                            SDK_AVT.Instance.EnumCamera();
                        }
                        ShowStep(65);
                    }
                    else
                    {
                        //////SDK_Halcon.Instance.EnumCamera();
                        ShowStep(65);
                    }
                    #endregion

                    #region 加载服务

                    ShowStep(70);
                    ShowStep("正在初始化服务");
                    //加载TCP/IP服务端
                    for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                    {
                        ShowStep(string.Format("正在初始化 [ {0} ]", Project.Instance.L_Service[i].name));
                        switch (Project.Instance.L_Service[i].serviceType)
                        {
                            case ServiceType.TCPIPSever:
                                TCPSever tcpSever = (TCPSever)Project.Instance.L_Service[i];
                                TreeNode treeNode = Frm_Service.Instance.tvw_serviceList.Nodes.Add(Project.Instance.L_Service[i].name);

                                SeverItem severItem = new SeverItem();
                                severItem.Name = tcpSever.name;
                                severItem.SeverObj = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                severItem.L_clientItem = new List<ClientItem>();
                                TCPSever.L_severList.Add(severItem);

                                bool listenResult = true;
                                if (Project.Instance.L_Service[i].enable && Project.Instance.L_Service[i].autoConnectAfterStart)
                                    listenResult = Project.Instance.L_Service[i].Connect();
                                break;

                            case ServiceType.TCPIPClient:
                                TCPClient tcpClient = (TCPClient)Project.Instance.L_Service[i];
                                treeNode = Frm_Service.Instance.tvw_serviceList.Nodes.Add(Project.Instance.L_Service[i].name);

                                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                TCPClient.L_socket.Add(tcpClient.name, socket);

                                bool connectResult = true;
                                if (Project.Instance.L_Service[i].enable && Project.Instance.L_Service[i].autoConnectAfterStart)
                                    connectResult = Project.Instance.L_Service[i].Connect();
                                break;

                            case ServiceType.Camera:
                                CCamera ccamera = (CCamera)Project.Instance.L_Service[i];
                                CCamera.FindCamera(ccamera.name).loopGrab = false;
                                treeNode = Frm_Service.Instance.tvw_serviceList.Nodes.Add(Project.Instance.L_Service[i].name);

                                if (Project.Instance.L_Service[i].enable && !ccamera.Connected)
                                {
                                    FuncLib.ShowMsg(string.Format("相机 [ {0} ] 连接失败！请检查", ccamera.name), InfoType.Error);
                                    FuncLib.ShowMessageBox(string.Format("相机 [ {0} ] 连接失败！请检查", ccamera.name), InfoType.Error);
                                }
                                break;

                            case ServiceType.Calibrate:
                                Calibrate calibrate = (Calibrate)Project.Instance.L_Service[i];
                                treeNode = Frm_Service.Instance.tvw_serviceList.Nodes.Add(Project.Instance.L_Service[i].name);

                                //创建匹配模板
                                ServiceBase serviceBase = Project.Instance.L_Service[i];
                                Thread th3 = new Thread(() =>
                                {
                                    ((Calibrate)serviceBase).CreateTemplate();
                                });
                                th3.IsBackground = true;
                                th3.Start();
                                break;

                            case ServiceType.Light:
                                LightService lightService = (LightService)Project.Instance.L_Service[i];
                                treeNode = Frm_Service.Instance.tvw_serviceList.Nodes.Add(Project.Instance.L_Service[i].name);
                                LightBase.L_serialPort.Add(lightService.name, new System.IO.Ports.SerialPort());
                                if (Project.Instance.L_Service[i].enable)
                                    lightService.lightBase.Open();

                                #region 1.修复串口光源控制器连接失败还去关闭光源通道
                                ////1.原先
                                ////打开通道并设置亮度
                                //lightService.lightBase.CloseAllCh();

                                //1.更改后
                                if (lightService.lightBase.InitSucceed)
                                    lightService.lightBase.CloseAllCh();
                                #endregion

                                break;

                            case ServiceType.SerialPort:
                                Serial serial = (Serial)Project.Instance.L_Service[i];
                                treeNode = Frm_Service.Instance.tvw_serviceList.Nodes.Add(Project.Instance.L_Service[i].name);
                                Serial.L_serialPort.Add(serial.name, new System.IO.Ports.SerialPort());
                                if (Project.Instance.L_Service[i].enable)
                                    serial.Open();
                                break;
                            case ServiceType.Card:
                                CCard cCard = (CCard)Project.Instance.L_Service[i];
                                treeNode = Frm_Service.Instance.tvw_serviceList.Nodes.Add(Project.Instance.L_Service[i].name);

                                if (Project.Instance.L_Service[i].enable)
                                    ((CCard)Project.Instance.L_Service[i]).cardBase.Init(Project.Instance.L_Service[i].name);

                                if (Project.Instance.L_Service[i].enable && ((CCard)Project.Instance.L_Service[i]).cardBase.vitualCard)
                                    FuncLib.ShowMsg(string.Format("温馨提示：运动控制卡 [ {0} ] 正处于离线虚拟状态，如需正常生产，请关闭虚拟状态", ((CCard)Project.Instance.L_Service[i]).name), InfoType.Warn);

                                Frm_Welcome.Instance.Invoke(new Action(() =>
                                {
                                    Frm_Card.Instance.TopLevel = false;
                                }));
                                break;
                            case ServiceType.FTPDownload:
                                FTPDownload ftpDownload = (FTPDownload)Project.Instance.L_Service[i];
                                treeNode = Frm_Service.Instance.tvw_serviceList.Nodes.Add(Project.Instance.L_Service[i].name);
                                if (Project.Instance.L_Service[i].enable)
                                {
                                    if (ftpDownload.IsConnect)
                                    {
                                        Thread th = new Thread(ftpDownload.CheckFTPPath);
                                        th.IsBackground = true;
                                        th.Start();
                                    }
                                    else
                                    {
                                        FuncLib.ShowMsg("当前FTP服务连接出现失败，请检查参数环境是否正确..", InfoType.Warn);
                                    }
                                }
                                break;
                        }
                    }
                    ShowStep(100);
                    ShowStep("启动成功");
                    #endregion

                    th2IsLoading = false;
                });
                th2.IsBackground = true;
                th2.Start();

                while (th1IsLoading || th2IsLoading)
                {

                    Frm_Welcome.Instance.pictureBox2.Visible = true;
                    Application.DoEvents();
                    if (!th1IsLoading && !th2IsLoading)
                        break;
                    Thread.Sleep(400);
                    Frm_Welcome.Instance.pictureBox2.Visible = false;
                    Application.DoEvents();
                    if (!th1IsLoading && !th2IsLoading)
                        break;
                    Thread.Sleep(400);
                }
                bool b = Frm_Vision.Instance.统计toolStripButton1.Visible;


                Frm_Main.Instance.ShowDialog();
            }
            catch (Exception)
            {
                FuncLib.ShowMessageBox("启动出错！", InfoType.Error);
                //隐藏欢迎窗体，弹出主窗体
                this.Hide();
                Frm_Main.Instance.ShowDialog();
            }
        }


        /// <summary>
        /// 进度条更新进度
        /// </summary>
        /// <param name="stepValue">当前步百分比</param>
        internal static void ShowStep(int stepValue)
        {
            Instance.bar_step.Value = stepValue;
            Application.DoEvents();
        }
        /// <summary>
        /// 进度条更新进度
        /// </summary>
        /// <param name="stepMsg">当前步信息</param>
        internal static void ShowStep(string stepMsg)
        {
            if (stepMsg.Length > 55)
                stepMsg = stepMsg.Substring(0, 55);

            Instance.lbl_step.Text = stepMsg + " ......";
            Application.DoEvents();
        }
        /// <summary>
        /// 开机自启动
        /// </summary>
        /// <param name="isAuto">是否启用</param>
        internal static void AutoRunAfterStartup(bool isAuto)
        {
            try
            {
                if (isAuto == true)
                {
                    RegistryKey R_local = Registry.LocalMachine;        //RegistryKey R_local = Registry.CurrentUser;
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.SetValue("应用名称", Application.ExecutablePath);
                    R_run.Close();
                    R_local.Close();
                }

                else
                {
                    RegistryKey R_local = Registry.LocalMachine;        //RegistryKey R_local = Registry.CurrentUser;
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.DeleteValue("应用名称", false);
                    R_run.Close();
                    R_local.Close();
                }
            }
            catch { }       //需要Try起来，不然在VS中启动时这里会报错
        }


        private void Frm_Welcome_Load(object sender, EventArgs e)
        {
            //显示版本号     版本号根据exe的生成时间自动变化
            string date = File.GetLastWriteTime(Application.StartupPath + "\\VM Pro.exe").ToString("yyyy-MM-dd");
            lbl_version.Text = string.Format("VM Pro {0} {1}", date, ((AssemblyConfigurationAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false))[0]).Configuration);
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
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

            //强制退出
            Process.GetCurrentProcess().Kill();
        }

    }
}
