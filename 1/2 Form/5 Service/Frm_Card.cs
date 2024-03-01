using AVT.VmbAPINET;
using HalconDotNet;
using Microsoft.Win32;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VM_Pro.Properties;

namespace VM_Pro
{
    public partial class Frm_Card : Form
    {
        public Frm_Card()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        /// <summary>
        /// 资源锁
        /// </summary>
        internal static object obj = new object();
        /// <summary>
        /// 正在加载窗体
        /// </summary>
        internal static bool isLoading = false;
        /// <summary>
        /// 光源控制器实例
        /// </summary>
        internal static CCard cCard = null;
        /// <summary>
        /// 持续刷新状态
        /// </summary>
        internal static bool keepUpdate = false;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Card _instance;
        internal static Frm_Card Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Card();
                return _instance;
            }
        }
        /// <summary>
        /// 有信号，绿灯
        /// </summary>
        private static Image On = (Image)Resources.On.Clone();
        /// <summary>
        /// 无信号，灰灯
        /// </summary>
        private static Image Off = (Image)Resources.Off.Clone();
        /// <summary>
        /// 报警信号，红灯
        /// </summary>
        private static Image Err = (Image)Resources.Error.Clone();


        /// <summary>
        /// 显示参数到界面
        /// </summary>
        /// <param name="tcpClient"></param>
        internal static void ShowPar(ServiceBase serviceBase)
        {
            isLoading = true;

            if (Frm_Service.curForm != CurForm.Card)
            {
                Frm_Service.curForm = CurForm.Card;

                Frm_Service.Instance.pnl_seviceBox.Controls.Clear();
                Instance.TopLevel = false;
                Instance.Parent = Frm_Service.Instance.pnl_seviceBox;
                Instance.Dock = DockStyle.Fill;
                Instance.Show();
                Application.DoEvents();
            }

            cCard = (CCard)serviceBase;

            //更新参数
            if (cCard.Connected)
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "已连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
            }
            else
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "未连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
            }

            Instance.cbx_axisList.Items.Clear();
            Instance.cbx_axisList.Items.AddRange(cCard.cardBase.L_axisName);

            Instance.cbx_cardType.Text = cCard.cardBase.cardType.ToString();
            Instance.ckb_vitualCard.Checked = cCard.cardBase.vitualCard;

            Instance.ckb_di1.Checked = !cCard.cardBase.L_diLogicLevel[0];
            Instance.ckb_di2.Checked = !cCard.cardBase.L_diLogicLevel[1];
            Instance.ckb_di3.Checked = !cCard.cardBase.L_diLogicLevel[2];
            Instance.ckb_di4.Checked = !cCard.cardBase.L_diLogicLevel[3];
            Instance.ckb_di5.Checked = !cCard.cardBase.L_diLogicLevel[4];
            Instance.ckb_di6.Checked = !cCard.cardBase.L_diLogicLevel[5];
            Instance.ckb_di7.Checked = !cCard.cardBase.L_diLogicLevel[6];
            Instance.ckb_di8.Checked = !cCard.cardBase.L_diLogicLevel[7];
            Instance.ckb_di9.Checked = !cCard.cardBase.L_diLogicLevel[8];
            Instance.ckb_di10.Checked = !cCard.cardBase.L_diLogicLevel[9];
            Instance.ckb_di11.Checked = !cCard.cardBase.L_diLogicLevel[10];
            Instance.ckb_di12.Checked = !cCard.cardBase.L_diLogicLevel[11];
            Instance.ckb_di13.Checked = !cCard.cardBase.L_diLogicLevel[12];
            Instance.ckb_di14.Checked = !cCard.cardBase.L_diLogicLevel[13];
            Instance.ckb_di15.Checked = !cCard.cardBase.L_diLogicLevel[14];
            Instance.ckb_di16.Checked = !cCard.cardBase.L_diLogicLevel[15];
            Instance.ckb_di17.Checked = !cCard.cardBase.L_diLogicLevel[16];
            Instance.ckb_di18.Checked = !cCard.cardBase.L_diLogicLevel[17];
            Instance.ckb_di19.Checked = !cCard.cardBase.L_diLogicLevel[18];
            Instance.ckb_di20.Checked = !cCard.cardBase.L_diLogicLevel[19];
            Instance.ckb_di21.Checked = !cCard.cardBase.L_diLogicLevel[20];
            Instance.ckb_di22.Checked = !cCard.cardBase.L_diLogicLevel[21];
            Instance.ckb_di23.Checked = !cCard.cardBase.L_diLogicLevel[22];
            Instance.ckb_di24.Checked = !cCard.cardBase.L_diLogicLevel[23];
            Instance.ckb_di25.Checked = !cCard.cardBase.L_diLogicLevel[24];
            Instance.ckb_di26.Checked = !cCard.cardBase.L_diLogicLevel[25];
            Instance.ckb_di27.Checked = !cCard.cardBase.L_diLogicLevel[26];
            Instance.ckb_di28.Checked = !cCard.cardBase.L_diLogicLevel[27];
            Instance.ckb_di29.Checked = !cCard.cardBase.L_diLogicLevel[28];
            Instance.ckb_di30.Checked = !cCard.cardBase.L_diLogicLevel[29];
            Instance.ckb_di31.Checked = !cCard.cardBase.L_diLogicLevel[30];
            Instance.ckb_di32.Checked = !cCard.cardBase.L_diLogicLevel[31];

            Instance.ckb_do1.Checked = cCard.cardBase.L_doLogicLevel[0];
            Instance.ckb_do2.Checked = cCard.cardBase.L_doLogicLevel[1];
            Instance.ckb_do3.Checked = cCard.cardBase.L_doLogicLevel[2];
            Instance.ckb_do4.Checked = cCard.cardBase.L_doLogicLevel[3];
            Instance.ckb_do5.Checked = cCard.cardBase.L_doLogicLevel[4];
            Instance.ckb_do6.Checked = cCard.cardBase.L_doLogicLevel[5];
            Instance.ckb_do7.Checked = cCard.cardBase.L_doLogicLevel[6];
            Instance.ckb_do8.Checked = cCard.cardBase.L_doLogicLevel[7];
            Instance.ckb_do9.Checked = cCard.cardBase.L_doLogicLevel[8];
            Instance.ckb_do10.Checked = cCard.cardBase.L_doLogicLevel[9];
            Instance.ckb_do11.Checked = cCard.cardBase.L_doLogicLevel[10];
            Instance.ckb_do12.Checked = cCard.cardBase.L_doLogicLevel[11];
            Instance.ckb_do13.Checked = cCard.cardBase.L_doLogicLevel[12];
            Instance.ckb_do14.Checked = cCard.cardBase.L_doLogicLevel[13];
            Instance.ckb_do15.Checked = cCard.cardBase.L_doLogicLevel[14];
            Instance.ckb_do16.Checked = cCard.cardBase.L_doLogicLevel[15];
            Instance.ckb_do17.Checked = cCard.cardBase.L_doLogicLevel[16];
            Instance.ckb_do18.Checked = cCard.cardBase.L_doLogicLevel[17];
            Instance.ckb_do19.Checked = cCard.cardBase.L_doLogicLevel[18];
            Instance.ckb_do20.Checked = cCard.cardBase.L_doLogicLevel[19];
            Instance.ckb_do21.Checked = cCard.cardBase.L_doLogicLevel[20];
            Instance.ckb_do22.Checked = cCard.cardBase.L_doLogicLevel[21];
            Instance.ckb_do23.Checked = cCard.cardBase.L_doLogicLevel[22];
            Instance.ckb_do24.Checked = cCard.cardBase.L_doLogicLevel[23];
            Instance.ckb_do25.Checked = cCard.cardBase.L_doLogicLevel[24];
            Instance.ckb_do26.Checked = cCard.cardBase.L_doLogicLevel[25];
            Instance.ckb_do27.Checked = cCard.cardBase.L_doLogicLevel[26];
            Instance.ckb_do28.Checked = cCard.cardBase.L_doLogicLevel[27];
            Instance.ckb_do29.Checked = cCard.cardBase.L_doLogicLevel[28];
            Instance.ckb_do30.Checked = cCard.cardBase.L_doLogicLevel[29];
            Instance.ckb_do31.Checked = cCard.cardBase.L_doLogicLevel[30];
            Instance.ckb_do32.Checked = cCard.cardBase.L_doLogicLevel[31];

            if (Instance.cbx_axisList.SelectedIndex < 0)
                Instance.cbx_axisList.SelectedIndex = 0;

            if (cCard.cardBase.GetMotorStatu(Instance.cbx_axisList.SelectedIndex))
            {
                Instance.btn_motorOn.RectColor = Color.FromArgb(80, 160, 255);
                Instance.btn_motorOn.FillColor = Color.FromArgb(80, 160, 255);
            }
            else
            {
                Instance.btn_motorOn.RectColor = Color.LightGray;
                Instance.btn_motorOn.FillColor = Color.LightGray;
            }

            Instance.cbx_homeMode.Text = Instance.cbx_homeMode.Items[(int)cCard.cardBase.L_homeMode[Instance.cbx_axisList.SelectedIndex]].ToString();
            Instance.cbx_homeDir.Text = cCard.cardBase.L_homeDir[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.tbx_backLength.Text = cCard.cardBase.L_backLength[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.cbx_pulseMode.Text = cCard.cardBase.L_pulseMode[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.tbx_pulseRate.Text = cCard.cardBase.L_pulseRate[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.tbx_homeVel.Text = cCard.cardBase.L_homeVel[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.tbx_safePos.Text = cCard.cardBase.L_safePos[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.cbx_motorType.Text = cCard.cardBase.L_MotorType[Instance.cbx_axisList.SelectedIndex] ? "伺服电机" : "步进电机";
            Instance.tbx_allowOffset.Text = cCard.cardBase.L_allowOffset[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.cbx_originLogic.Text = cCard.cardBase.L_OriginLogic[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.cbx_NLimitLogic.Text = cCard.cardBase.L_NLimitLogic[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.cbx_PLimitLogic.Text = cCard.cardBase.L_PLimitLogic[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.tbx_NLimit.Text = cCard.cardBase.L_NLimit[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.tbx_PLimit.Text = cCard.cardBase.L_PLimit[Instance.cbx_axisList.SelectedIndex].ToString();

            Instance.lbl_homeStatu.Text = Project.L_axis[Instance.cbx_axisList.SelectedIndex].homeOK ? "已回零" : "未回零";
            Instance.lbl_homeStatu.ForeColor = Project.L_axis[Instance.cbx_axisList.SelectedIndex].homeOK ? Color.Green : Color.Red;

            if (Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                Instance.cbx_homeMode.Enabled = true;
                Instance.cbx_homeDir.Enabled = true;
                Instance.tbx_backLength.Enabled = true;
                Instance.cbx_pulseMode.Enabled = true;
                Instance.tbx_pulseRate.Enabled = true;
                Instance.tbx_homeVel.Enabled = true;
                Instance.tbx_safePos.Enabled = true;
                Instance.cbx_motorType.Enabled = true;
                Instance.tbx_allowOffset.Enabled = true;
                Instance.cbx_originLogic.Enabled = true;
                Instance.cbx_NLimitLogic.Enabled = true;
                Instance.cbx_PLimitLogic.Enabled = true;
                Instance.tbx_NLimit.Enabled = true;
                Instance.tbx_PLimit.Enabled = true;
                Instance.btn_touchNLimit.Enabled = true;
                Instance.btn_touchPLimit.Enabled = true;

                Instance.cbx_cardType.Enabled = true;

                Instance.ckb_di1.Enabled = true;
                Instance.ckb_di2.Enabled = true;
                Instance.ckb_di3.Enabled = true;
                Instance.ckb_di4.Enabled = true;
                Instance.ckb_di5.Enabled = true;
                Instance.ckb_di6.Enabled = true;
                Instance.ckb_di7.Enabled = true;
                Instance.ckb_di8.Enabled = true;
                Instance.ckb_di9.Enabled = true;
                Instance.ckb_di10.Enabled = true;
                Instance.ckb_di11.Enabled = true;
                Instance.ckb_di12.Enabled = true;
                Instance.ckb_di13.Enabled = true;
                Instance.ckb_di14.Enabled = true;
                Instance.ckb_di15.Enabled = true;
                Instance.ckb_di16.Enabled = true;
                Instance.ckb_di17.Enabled = true;
                Instance.ckb_di18.Enabled = true;
                Instance.ckb_di19.Enabled = true;
                Instance.ckb_di20.Enabled = true;
                Instance.ckb_di21.Enabled = true;
                Instance.ckb_di22.Enabled = true;
                Instance.ckb_di23.Enabled = true;
                Instance.ckb_di24.Enabled = true;
                Instance.ckb_di25.Enabled = true;
                Instance.ckb_di26.Enabled = true;
                Instance.ckb_di27.Enabled = true;
                Instance.ckb_di28.Enabled = true;
                Instance.ckb_di29.Enabled = true;
                Instance.ckb_di30.Enabled = true;
                Instance.ckb_di31.Enabled = true;
                Instance.ckb_di32.Enabled = true;

                Instance.ckb_do1.Enabled = true;
                Instance.ckb_do2.Enabled = true;
                Instance.ckb_do3.Enabled = true;
                Instance.ckb_do4.Enabled = true;
                Instance.ckb_do5.Enabled = true;
                Instance.ckb_do6.Enabled = true;
                Instance.ckb_do7.Enabled = true;
                Instance.ckb_do8.Enabled = true;
                Instance.ckb_do9.Enabled = true;
                Instance.ckb_do10.Enabled = true;
                Instance.ckb_do11.Enabled = true;
                Instance.ckb_do12.Enabled = true;
                Instance.ckb_do13.Enabled = true;
                Instance.ckb_do14.Enabled = true;
                Instance.ckb_do15.Enabled = true;
                Instance.ckb_do16.Enabled = true;
                Instance.ckb_do17.Enabled = true;
                Instance.ckb_do18.Enabled = true;
                Instance.ckb_do19.Enabled = true;
                Instance.ckb_do20.Enabled = true;
                Instance.ckb_do21.Enabled = true;
                Instance.ckb_do22.Enabled = true;
                Instance.ckb_do23.Enabled = true;
                Instance.ckb_do24.Enabled = true;
                Instance.ckb_do25.Enabled = true;
                Instance.ckb_do26.Enabled = true;
                Instance.ckb_do27.Enabled = true;
                Instance.ckb_do28.Enabled = true;
                Instance.ckb_do29.Enabled = true;
                Instance.ckb_do30.Enabled = true;
                Instance.ckb_do31.Enabled = true;
                Instance.ckb_do32.Enabled = true;
            }
            else
            {
                Instance.cbx_homeMode.Enabled = false;
                Instance.cbx_homeDir.Enabled = false;
                Instance.tbx_backLength.Enabled = false;
                Instance.cbx_pulseMode.Enabled = false;
                Instance.tbx_pulseRate.Enabled = false;
                Instance.tbx_homeVel.Enabled = false;
                Instance.tbx_safePos.Enabled = false;
                Instance.cbx_motorType.Enabled = false;
                Instance.tbx_allowOffset.Enabled = false;
                Instance.cbx_originLogic.Enabled = false;
                Instance.cbx_NLimitLogic.Enabled = false;
                Instance.cbx_PLimitLogic.Enabled = false;
                Instance.tbx_NLimit.Enabled = false;
                Instance.tbx_PLimit.Enabled = false;
                Instance.btn_touchNLimit.Enabled = false;
                Instance.btn_touchPLimit.Enabled = false;

                Instance.cbx_cardType.Enabled = false;

                Instance.ckb_di1.Enabled = false;
                Instance.ckb_di2.Enabled = false;
                Instance.ckb_di3.Enabled = false;
                Instance.ckb_di4.Enabled = false;
                Instance.ckb_di5.Enabled = false;
                Instance.ckb_di6.Enabled = false;
                Instance.ckb_di7.Enabled = false;
                Instance.ckb_di8.Enabled = false;
                Instance.ckb_di9.Enabled = false;
                Instance.ckb_di10.Enabled = false;
                Instance.ckb_di11.Enabled = false;
                Instance.ckb_di12.Enabled = false;
                Instance.ckb_di13.Enabled = false;
                Instance.ckb_di14.Enabled = false;
                Instance.ckb_di15.Enabled = false;
                Instance.ckb_di16.Enabled = false;
                Instance.ckb_di17.Enabled = false;
                Instance.ckb_di18.Enabled = false;
                Instance.ckb_di19.Enabled = false;
                Instance.ckb_di20.Enabled = false;
                Instance.ckb_di21.Enabled = false;
                Instance.ckb_di22.Enabled = false;
                Instance.ckb_di23.Enabled = false;
                Instance.ckb_di24.Enabled = false;
                Instance.ckb_di25.Enabled = false;
                Instance.ckb_di26.Enabled = false;
                Instance.ckb_di27.Enabled = false;
                Instance.ckb_di28.Enabled = false;
                Instance.ckb_di29.Enabled = false;
                Instance.ckb_di30.Enabled = false;
                Instance.ckb_di31.Enabled = false;
                Instance.ckb_di32.Enabled = false;

                Instance.ckb_do1.Enabled = false;
                Instance.ckb_do2.Enabled = false;
                Instance.ckb_do3.Enabled = false;
                Instance.ckb_do4.Enabled = false;
                Instance.ckb_do5.Enabled = false;
                Instance.ckb_do6.Enabled = false;
                Instance.ckb_do7.Enabled = false;
                Instance.ckb_do8.Enabled = false;
                Instance.ckb_do9.Enabled = false;
                Instance.ckb_do10.Enabled = false;
                Instance.ckb_do11.Enabled = false;
                Instance.ckb_do12.Enabled = false;
                Instance.ckb_do13.Enabled = false;
                Instance.ckb_do14.Enabled = false;
                Instance.ckb_do15.Enabled = false;
                Instance.ckb_do16.Enabled = false;
                Instance.ckb_do17.Enabled = false;
                Instance.ckb_do18.Enabled = false;
                Instance.ckb_do19.Enabled = false;
                Instance.ckb_do20.Enabled = false;
                Instance.ckb_do21.Enabled = false;
                Instance.ckb_do22.Enabled = false;
                Instance.ckb_do23.Enabled = false;
                Instance.ckb_do24.Enabled = false;
                Instance.ckb_do25.Enabled = false;
                Instance.ckb_do26.Enabled = false;
                Instance.ckb_do27.Enabled = false;
                Instance.ckb_do28.Enabled = false;
                Instance.ckb_do29.Enabled = false;
                Instance.ckb_do30.Enabled = false;
                Instance.ckb_do31.Enabled = false;
                Instance.ckb_do32.Enabled = false;
            }

            if (Frm_Service.Instance.Visible)
                UpdateAll();

            isLoading = false;
        }
        /// <summary>
        /// 监控板卡
        /// </summary>
        internal static void UpdateAll()
        {
            if (!cCard.cardBase.connected)
                return;

            keepUpdate = true;
            if (Instance.uiTabControl1.SelectedIndex == 0 || Instance.uiTabControl1.SelectedIndex == 1)
            {
                Thread th = new Thread(() =>
                  {
                      lock (obj)
                      {
                          while (keepUpdate)
                          {
                              try
                              {
                                  if (Instance.uiTabControl1.SelectedIndex == 0)
                                  {
                                      Instance.lbl_homeStatu.Text = Project.L_axis[Instance.cbx_axisList.SelectedIndex].homeOK ? "已回零" : "未回零";
                                      Instance.lbl_homeStatu.ForeColor = Project.L_axis[Instance.cbx_axisList.SelectedIndex].homeOK ? Color.Green : Color.Red;
                                      Instance.lbl_cmdPos.Text = cCard.cardBase.GetCmdPos(Instance.cbx_axisList.SelectedIndex).ToString("0.000");
                                      Instance.lbl_encPos.Text = cCard.cardBase.GetCmdPos(Instance.cbx_axisList.SelectedIndex).ToString("0.000");
                                      Instance.pic_P.Image = (cCard.cardBase.InPEL(Instance.cbx_axisList.SelectedIndex) ? (Image)Err.Clone() : (Image)Off.Clone());
                                      Instance.pic_O.Image = (cCard.cardBase.InHome(Instance.cbx_axisList.SelectedIndex) ? (Image)On.Clone() : (Image)Off.Clone());
                                      Instance.pic_N.Image = (cCard.cardBase.InNEL(Instance.cbx_axisList.SelectedIndex) ? (Image)Err.Clone() : (Image)Off.Clone());
                                      Instance.pic_err.Image = (cCard.cardBase.IsAlarm(Instance.cbx_axisList.SelectedIndex) ? (Image)Err.Clone() : (Image)Off.Clone());
                                      Instance.pic_moving.Image = (cCard.cardBase.IsAlarm(Instance.cbx_axisList.SelectedIndex) ? (Image)On.Clone() : (Image)Off.Clone());
                                      Instance.pic_inp.Image = (cCard.cardBase.Inp(Instance.cbx_axisList.SelectedIndex) ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_homeOK.Image = Project.L_axis[Instance.cbx_axisList.SelectedIndex].homeOK ? (Image)Resources.On.Clone() : (Image)Resources.Error.Clone();
                                  }
                                  else
                                  {
                                      Instance.pic_diStatu1.Image = (cCard.cardBase.GetDiSts(1) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu2.Image = (cCard.cardBase.GetDiSts(2) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu3.Image = (cCard.cardBase.GetDiSts(3) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu4.Image = (cCard.cardBase.GetDiSts(4) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu5.Image = (cCard.cardBase.GetDiSts(5) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu6.Image = (cCard.cardBase.GetDiSts(6) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu7.Image = (cCard.cardBase.GetDiSts(7) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu8.Image = (cCard.cardBase.GetDiSts(8) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu9.Image = (cCard.cardBase.GetDiSts(9) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu10.Image = (cCard.cardBase.GetDiSts(10) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu11.Image = (cCard.cardBase.GetDiSts(11) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu12.Image = (cCard.cardBase.GetDiSts(12) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu13.Image = (cCard.cardBase.GetDiSts(13) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu14.Image = (cCard.cardBase.GetDiSts(14) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu15.Image = (cCard.cardBase.GetDiSts(15) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu16.Image = (cCard.cardBase.GetDiSts(16) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu17.Image = (cCard.cardBase.GetDiSts(17) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu18.Image = (cCard.cardBase.GetDiSts(18) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu19.Image = (cCard.cardBase.GetDiSts(19) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu20.Image = (cCard.cardBase.GetDiSts(20) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu21.Image = (cCard.cardBase.GetDiSts(21) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu22.Image = (cCard.cardBase.GetDiSts(22) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu23.Image = (cCard.cardBase.GetDiSts(23) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu24.Image = (cCard.cardBase.GetDiSts(24) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu25.Image = (cCard.cardBase.GetDiSts(25) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu26.Image = (cCard.cardBase.GetDiSts(26) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu27.Image = (cCard.cardBase.GetDiSts(27) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu28.Image = (cCard.cardBase.GetDiSts(28) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu29.Image = (cCard.cardBase.GetDiSts(29) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu30.Image = (cCard.cardBase.GetDiSts(30) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu31.Image = (cCard.cardBase.GetDiSts(31) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());
                                      Instance.pic_diStatu32.Image = (cCard.cardBase.GetDiSts(32) == OnOff.On ? (Image)Resources.On.Clone() : (Image)Resources.Off.Clone());

                                      Instance.btn_do1.BackColor = (cCard.cardBase.GetDoSts(1) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do2.BackColor = (cCard.cardBase.GetDoSts(2) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do3.BackColor = (cCard.cardBase.GetDoSts(3) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do4.BackColor = (cCard.cardBase.GetDoSts(4) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do5.BackColor = (cCard.cardBase.GetDoSts(5) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do6.BackColor = (cCard.cardBase.GetDoSts(6) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do7.BackColor = (cCard.cardBase.GetDoSts(7) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do8.BackColor = (cCard.cardBase.GetDoSts(8) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do9.BackColor = (cCard.cardBase.GetDoSts(9) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do10.BackColor = (cCard.cardBase.GetDoSts(10) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do11.BackColor = (cCard.cardBase.GetDoSts(11) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do12.BackColor = (cCard.cardBase.GetDoSts(12) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do13.BackColor = (cCard.cardBase.GetDoSts(13) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do14.BackColor = (cCard.cardBase.GetDoSts(14) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do15.BackColor = (cCard.cardBase.GetDoSts(15) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do16.BackColor = (cCard.cardBase.GetDoSts(16) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do17.BackColor = (cCard.cardBase.GetDoSts(17) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do18.BackColor = (cCard.cardBase.GetDoSts(18) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do19.BackColor = (cCard.cardBase.GetDoSts(19) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do20.BackColor = (cCard.cardBase.GetDoSts(20) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do21.BackColor = (cCard.cardBase.GetDoSts(21) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do22.BackColor = (cCard.cardBase.GetDoSts(22) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do23.BackColor = (cCard.cardBase.GetDoSts(23) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do24.BackColor = (cCard.cardBase.GetDoSts(24) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do25.BackColor = (cCard.cardBase.GetDoSts(25) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do26.BackColor = (cCard.cardBase.GetDoSts(26) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do27.BackColor = (cCard.cardBase.GetDoSts(27) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do28.BackColor = (cCard.cardBase.GetDoSts(28) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do29.BackColor = (cCard.cardBase.GetDoSts(29) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do30.BackColor = (cCard.cardBase.GetDoSts(30) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do31.BackColor = (cCard.cardBase.GetDoSts(31) == OnOff.On ? Color.Green : Color.Gainsboro);
                                      Instance.btn_do32.BackColor = (cCard.cardBase.GetDoSts(32) == OnOff.On ? Color.Green : Color.Gainsboro);
                                  }

                                  Thread.Sleep(100);
                              }
                              catch { }
                          }
                      }
                  });
                th.IsBackground = true;
                th.Start();
            }
            else
            {
                keepUpdate = false;
            }
        }


        private void cbx_homeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (cbx_homeMode.Items[(int)cCard.cardBase.L_homeMode[cbx_axisList.SelectedIndex]].ToString() == cbx_homeMode.Text)
                return;

            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 回零模式变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cbx_homeMode.Items[(int)cCard.cardBase.L_homeMode[cbx_axisList.SelectedIndex]], cbx_homeMode.Text));
            cCard.cardBase.L_homeMode[cbx_axisList.SelectedIndex] = (HomeMode)cbx_homeMode.SelectedIndex;
        }
        private void cbx_homeDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (cbx_homeDir.Items[(int)cCard.cardBase.L_homeDir[cbx_axisList.SelectedIndex]].ToString() == cbx_homeDir.Text)
                return;

            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 回零方向变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cbx_homeDir.Items[(int)cCard.cardBase.L_homeDir[cbx_axisList.SelectedIndex]], cbx_homeDir.Text));
            cCard.cardBase.L_homeDir[cbx_axisList.SelectedIndex] = (Dir)cbx_homeDir.SelectedIndex;
        }
        private void tbx_backLength_TextChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            try
            {
                FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 回退距离变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cCard.cardBase.L_backLength[cbx_axisList.SelectedIndex], tbx_backLength.Text.Trim()));
                cCard.cardBase.L_backLength[cbx_axisList.SelectedIndex] = Convert.ToDouble(tbx_backLength.Text.Trim());
            }
            catch { }
        }
        private void cbx_pulseMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (cbx_pulseMode.Items[(int)cCard.cardBase.L_pulseMode[cbx_axisList.SelectedIndex]].ToString() == cbx_pulseMode.Text)
                return;

            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 脉冲模式变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cbx_pulseMode.Items[(int)cCard.cardBase.L_pulseMode[cbx_axisList.SelectedIndex]], cbx_pulseMode.Text));
            cCard.cardBase.L_pulseMode[cbx_axisList.SelectedIndex] = cbx_pulseMode.SelectedIndex;

            cCard.cardBase.SetPulseMode(cbx_axisList.SelectedIndex);
        }
        private void tbx_pulseRate_TextChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            try
            {
                FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 脉冲当量变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cCard.cardBase.L_pulseRate[cbx_axisList.SelectedIndex], tbx_pulseRate.Text.Trim()));
                cCard.cardBase.L_pulseRate[cbx_axisList.SelectedIndex] = Convert.ToDouble(tbx_pulseRate.Text.Trim());
            }
            catch { }
        }
        private void tbx_homeVel_TextChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 回零速度变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cCard.cardBase.L_homeVel[cbx_axisList.SelectedIndex], tbx_homeVel.Text.Trim()));
            cCard.cardBase.L_homeVel[cbx_axisList.SelectedIndex] = Convert.ToDouble(tbx_homeVel.Text.Trim());
        }
        private void tbx_safePos_TextChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            try
            {
                FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 安全位置变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cCard.cardBase.L_safePos[cbx_axisList.SelectedIndex], tbx_safePos.Text.Trim()));
                cCard.cardBase.L_safePos[cbx_axisList.SelectedIndex] = Convert.ToDouble(tbx_safePos.Text.Trim());
            }
            catch { }
        }
        private void tbx_allowOffset_TextChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (cbx_axisList.SelectedIndex < 0)
                return;

            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 误差容限变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cCard.cardBase.L_allowOffset[cbx_axisList.SelectedIndex], tbx_allowOffset.Text.Trim()));
            cCard.cardBase.L_allowOffset[cbx_axisList.SelectedIndex] = Convert.ToDouble(tbx_allowOffset.Text.Trim());
        }
        private void cbx_originLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (cbx_originLogic.Items[(int)cCard.cardBase.L_OriginLogic[cbx_axisList.SelectedIndex]].ToString() == cbx_originLogic.Text)
                return;

            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 原点逻辑电平变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cbx_originLogic.Items[(int)cCard.cardBase.L_OriginLogic[cbx_axisList.SelectedIndex]], cbx_originLogic.Text));
            cCard.cardBase.L_OriginLogic[cbx_axisList.SelectedIndex] = (LogicLevel)cbx_originLogic.SelectedIndex;
        }
        private void tbx_NLimitLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (cCard.cardBase.L_NLimitLogic[cbx_axisList.SelectedIndex].ToString() == cbx_NLimitLogic.Text)
                return;

            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 负限逻辑电平变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cbx_NLimitLogic.Items[(int)cCard.cardBase.L_NLimitLogic[cbx_axisList.SelectedIndex]], cbx_NLimitLogic.Text));
            cCard.cardBase.L_NLimitLogic[cbx_axisList.SelectedIndex] = (LogicLevel)cbx_NLimitLogic.SelectedIndex;
        }
        private void tbx_PLimitLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (cbx_NLimitLogic.Items[(int)cCard.cardBase.L_PLimitLogic[cbx_axisList.SelectedIndex]].ToString() == cbx_PLimitLogic.Text)
                return;

            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 正限逻辑电平变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cbx_NLimitLogic.Items[(int)cCard.cardBase.L_PLimitLogic[cbx_axisList.SelectedIndex]], cbx_PLimitLogic.Text));
            cCard.cardBase.L_PLimitLogic[cbx_axisList.SelectedIndex] = (LogicLevel)cbx_PLimitLogic.SelectedIndex;
        }
        private void tbx_NLimit_TextChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            try
            {
                FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 负软限位变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cCard.cardBase.L_NLimit[cbx_axisList.SelectedIndex], tbx_NLimit.Text));
                cCard.cardBase.L_NLimit[cbx_axisList.SelectedIndex] = Convert.ToDouble(tbx_NLimit.Text.Trim());
            }
            catch { }
        }
        private void tbx_PLimit_TextChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            try
            {
                FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 轴 [ {1} ] 正软限位变更，变更前：{2}    变更后：{3}", cCard.name, cbx_axisList.Text, cCard.cardBase.L_PLimit[cbx_axisList.SelectedIndex], tbx_PLimit.Text));
                cCard.cardBase.L_PLimit[cbx_axisList.SelectedIndex] = Convert.ToDouble(tbx_PLimit.Text.Trim());
            }
            catch { }
        }

        private void btn_moveForeward_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                cCard.cardBase.MoveRel(cbx_axisList.SelectedIndex, distance, vel, false, true);
            }
        }
        private void btn_moveForeward_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                cCard.cardBase.KeepMove(cbx_axisList.SelectedIndex, 1, vel, false, true);
            }
        }
        private void btn_moveForeward_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                cCard.cardBase.DecStop(cbx_axisList.SelectedIndex, true);
        }
        private void btn_moveStop_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            cCard.cardBase.DecStop(cbx_axisList.SelectedIndex);

            btn_moveBackward.Enabled = true;
            btn_moveForeward.Enabled = true;
        }
        private void btn_moveBackward_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                cCard.cardBase.MoveRel(cbx_axisList.SelectedIndex, -distance, vel, false, true);
            }
        }
        private void btn_moveBackward_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                cCard.cardBase.KeepMove(cbx_axisList.SelectedIndex, -1, vel, false, true);
            }
        }
        private void btn_moveBackward_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                cCard.cardBase.DecStop(cbx_axisList.SelectedIndex, true);
        }
        private void btn_motorOn_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (cCard.cardBase.GetMotorStatu(cbx_axisList.SelectedIndex))
            {
                btn_motorOn.RectColor = Color.LightGray;
                btn_motorOn.FillColor = Color.LightGray;
                cCard.cardBase.MotorOff(cbx_axisList.SelectedIndex);
            }
            else
            {
                btn_motorOn.RectColor = Color.FromArgb(80, 160, 255);
                btn_motorOn.FillColor = Color.FromArgb(80, 160, 255);
                cCard.cardBase.MotorOn(cbx_axisList.SelectedIndex);
            }
        }
        private void btn_home_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            Thread th = new Thread(() =>
            {
                btn_moveForeward.Enabled = false;
                btn_moveBackward.Enabled = false;
                cCard.cardBase.Home(cbx_axisList.SelectedIndex, true);

                if (Project.L_axis[cbx_axisList.SelectedIndex].homeOK)
                {
                    lbl_homeStatu.Text = "已回零";
                    lbl_homeStatu.ForeColor = Color.Green;
                }

                btn_moveForeward.Enabled = true;
                btn_moveBackward.Enabled = true;
            });
            th.IsBackground = true;
            th.Start();
        }

        private void ckb_di1_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[0] = !ckb_di1.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 1 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di1.Checked ? "高电平" : "低电平", ckb_di1.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di2_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[1] = !ckb_di2.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 2 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di2.Checked ? "高电平" : "低电平", ckb_di2.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di3_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[2] = !ckb_di3.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 3 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di3.Checked ? "高电平" : "低电平", ckb_di3.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di4_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[3] = !ckb_di4.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 4 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di4.Checked ? "高电平" : "低电平", ckb_di4.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di5_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[4] = !ckb_di5.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 5 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di5.Checked ? "高电平" : "低电平", ckb_di5.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di6_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[5] = !ckb_di6.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 6 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di6.Checked ? "高电平" : "低电平", ckb_di6.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di7_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[6] = !ckb_di7.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 7 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di7.Checked ? "高电平" : "低电平", ckb_di7.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di8_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[7] = !ckb_di8.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 8 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di8.Checked ? "高电平" : "低电平", ckb_di8.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di9_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[8] = !ckb_di9.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 9 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di9.Checked ? "高电平" : "低电平", ckb_di9.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di10_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[9] = !ckb_di10.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 10 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di10.Checked ? "高电平" : "低电平", ckb_di10.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di11_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[10] = !ckb_di11.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 11 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di11.Checked ? "高电平" : "低电平", ckb_di11.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di12_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[11] = !ckb_di12.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 12 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di12.Checked ? "高电平" : "低电平", ckb_di12.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di13_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[12] = !ckb_di13.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 13 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di13.Checked ? "高电平" : "低电平", ckb_di13.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di14_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[13] = !ckb_di14.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 14 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di14.Checked ? "高电平" : "低电平", ckb_di14.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di15_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[14] = !ckb_di15.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 15 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di15.Checked ? "高电平" : "低电平", ckb_di15.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di16_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[15] = !ckb_di16.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 16 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di16.Checked ? "高电平" : "低电平", ckb_di16.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di17_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[16] = !ckb_di17.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 17 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di17.Checked ? "高电平" : "低电平", ckb_di17.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di18_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[17] = !ckb_di18.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 18 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di18.Checked ? "高电平" : "低电平", ckb_di18.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di19_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[18] = !ckb_di19.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 19 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di19.Checked ? "高电平" : "低电平", ckb_di19.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di20_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[19] = !ckb_di20.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 20 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di20.Checked ? "高电平" : "低电平", ckb_di20.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di21_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[20] = !ckb_di21.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 21 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di21.Checked ? "高电平" : "低电平", ckb_di21.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di22_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[21] = !ckb_di22.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 22 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di22.Checked ? "高电平" : "低电平", ckb_di22.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di23_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[22] = !ckb_di23.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 23 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di23.Checked ? "高电平" : "低电平", ckb_di23.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di24_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[23] = !ckb_di24.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 24 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di24.Checked ? "高电平" : "低电平", ckb_di24.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di25_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[24] = !ckb_di25.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 25 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di25.Checked ? "高电平" : "低电平", ckb_di25.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di26_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[25] = !ckb_di26.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 26 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di26.Checked ? "高电平" : "低电平", ckb_di3.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di27_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[26] = !ckb_di27.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 27 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di27.Checked ? "高电平" : "低电平", ckb_di27.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di28_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[27] = !ckb_di28.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 28 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di28.Checked ? "高电平" : "低电平", ckb_di28.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di29_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[28] = !ckb_di29.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 29 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di29.Checked ? "高电平" : "低电平", ckb_di29.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di30_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[29] = !ckb_di30.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 30 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di30.Checked ? "高电平" : "低电平", ckb_di30.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di31_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[30] = !ckb_di31.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 31 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di31.Checked ? "高电平" : "低电平", ckb_di31.Checked ? "低电平" : "高电平"));
        }
        private void ckb_di32_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_diLogicLevel[31] = !ckb_di32.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输入点 32 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_di32.Checked ? "高电平" : "低电平", ckb_di32.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do1_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[0] = ckb_do1.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 1 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do1.Checked ? "高电平" : "低电平", ckb_do1.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do2_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[1] = ckb_do2.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 2 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do2.Checked ? "高电平" : "低电平", ckb_do2.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do3_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[2] = ckb_do3.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 3 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do3.Checked ? "高电平" : "低电平", ckb_do3.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do4_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[3] = ckb_do4.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 4 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do4.Checked ? "高电平" : "低电平", ckb_do4.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do5_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[4] = ckb_do5.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 5 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do5.Checked ? "高电平" : "低电平", ckb_do5.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do6_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[5] = ckb_do6.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 6 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do6.Checked ? "高电平" : "低电平", ckb_do6.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do7_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[6] = ckb_do7.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 7 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do7.Checked ? "高电平" : "低电平", ckb_do7.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do8_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[7] = ckb_do8.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 8 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do8.Checked ? "高电平" : "低电平", ckb_do8.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do9_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[8] = ckb_do9.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 9 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do9.Checked ? "高电平" : "低电平", ckb_do9.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do10_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[9] = ckb_do10.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 10 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do10.Checked ? "高电平" : "低电平", ckb_do10.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do11_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[10] = ckb_do11.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 11 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do11.Checked ? "高电平" : "低电平", ckb_do11.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do12_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[11] = ckb_do12.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 12 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do12.Checked ? "高电平" : "低电平", ckb_do12.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do13_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[12] = ckb_do13.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 13 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do13.Checked ? "高电平" : "低电平", ckb_do13.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do14_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[13] = ckb_do14.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 14 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do14.Checked ? "高电平" : "低电平", ckb_do14.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do15_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[14] = ckb_do15.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 15 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do15.Checked ? "高电平" : "低电平", ckb_do15.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do16_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[15] = ckb_do16.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 16 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do16.Checked ? "高电平" : "低电平", ckb_do16.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do17_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[16] = ckb_do17.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 17 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do17.Checked ? "高电平" : "低电平", ckb_do17.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do18_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[17] = ckb_do18.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 18 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do18.Checked ? "高电平" : "低电平", ckb_do18.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do19_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[18] = ckb_do19.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 19 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do19.Checked ? "高电平" : "低电平", ckb_do19.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do20_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[19] = ckb_do20.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 20 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do20.Checked ? "高电平" : "低电平", ckb_do20.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do21_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[20] = ckb_do21.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 21 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do21.Checked ? "高电平" : "低电平", ckb_do21.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do22_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[21] = ckb_do22.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 22 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do22.Checked ? "高电平" : "低电平", ckb_do22.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do23_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[22] = ckb_do23.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 23 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do23.Checked ? "高电平" : "低电平", ckb_do23.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do24_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[23] = ckb_do24.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 24 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do24.Checked ? "高电平" : "低电平", ckb_do24.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do25_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[24] = ckb_do25.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 25 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do25.Checked ? "高电平" : "低电平", ckb_do25.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do26_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[25] = ckb_do26.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 26 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do26.Checked ? "高电平" : "低电平", ckb_do26.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do27_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[26] = ckb_do27.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 27 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do27.Checked ? "高电平" : "低电平", ckb_do27.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do28_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[27] = ckb_do28.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 28 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do28.Checked ? "高电平" : "低电平", ckb_do28.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do29_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[28] = ckb_do29.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 29 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do29.Checked ? "高电平" : "低电平", ckb_do29.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do30_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[29] = ckb_do30.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 30 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do30.Checked ? "高电平" : "低电平", ckb_do30.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do31_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[30] = ckb_do31.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 31 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do31.Checked ? "高电平" : "低电平", ckb_do31.Checked ? "低电平" : "高电平"));
        }
        private void ckb_do32_Click(object sender, EventArgs e)
        {
            cCard.cardBase.L_doLogicLevel[31] = ckb_do32.Checked;
            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 输出点 32 逻辑电平变更，变更前：{1}    变更后：{2}", cCard.name, ckb_do32.Checked ? "高电平" : "低电平", ckb_do32.Checked ? "低电平" : "高电平"));
        }

        private void btn_do1_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(1) == OnOff.On)
                cCard.cardBase.SetDo(1, OnOff.Off);
            else
                cCard.cardBase.SetDo(1, OnOff.On);
        }
        private void btn_do2_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }

            }
            if (cCard.cardBase.GetDoSts(2) == OnOff.On)
                cCard.cardBase.SetDo(2, OnOff.Off);
            else
                cCard.cardBase.SetDo(2, OnOff.On);
        }
        private void btn_do3_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(3) == OnOff.On)
                cCard.cardBase.SetDo(3, OnOff.Off);
            else
                cCard.cardBase.SetDo(3, OnOff.On);
        }
        private void btn_do4_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(4) == OnOff.On)
                cCard.cardBase.SetDo(4, OnOff.Off);
            else
                cCard.cardBase.SetDo(4, OnOff.On);
        }
        private void btn_do5_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(5) == OnOff.On)
                cCard.cardBase.SetDo(5, OnOff.Off);
            else
                cCard.cardBase.SetDo(5, OnOff.On);
        }
        private void btn_do6_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(6) == OnOff.On)
                cCard.cardBase.SetDo(6, OnOff.Off);
            else
                cCard.cardBase.SetDo(6, OnOff.On);
        }
        private void btn_do7_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(7) == OnOff.On)
                cCard.cardBase.SetDo(7, OnOff.Off);
            else
                cCard.cardBase.SetDo(7, OnOff.On);
        }
        private void btn_do8_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(8) == OnOff.On)
                cCard.cardBase.SetDo(8, OnOff.Off);
            else
                cCard.cardBase.SetDo(8, OnOff.On);
        }
        private void btn_do9_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(9) == OnOff.On)
                cCard.cardBase.SetDo(9, OnOff.Off);
            else
                cCard.cardBase.SetDo(9, OnOff.On);
        }
        private void btn_do10_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(10) == OnOff.On)
                cCard.cardBase.SetDo(10, OnOff.Off);
            else
                cCard.cardBase.SetDo(10, OnOff.On);
        }
        private void btn_do11_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(11) == OnOff.On)
                cCard.cardBase.SetDo(11, OnOff.Off);
            else
                cCard.cardBase.SetDo(11, OnOff.On);
        }
        private void btn_do12_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(12) == OnOff.On)
                cCard.cardBase.SetDo(12, OnOff.Off);
            else
                cCard.cardBase.SetDo(12, OnOff.On);
        }
        private void btn_do13_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(13) == OnOff.On)
                cCard.cardBase.SetDo(13, OnOff.Off);
            else
                cCard.cardBase.SetDo(13, OnOff.On);
        }
        private void btn_do14_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(14) == OnOff.On)
                cCard.cardBase.SetDo(14, OnOff.Off);
            else
                cCard.cardBase.SetDo(14, OnOff.On);
        }
        private void btn_do15_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(15) == OnOff.On)
                cCard.cardBase.SetDo(15, OnOff.Off);
            else
                cCard.cardBase.SetDo(15, OnOff.On);
        }
        private void btn_do16_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(16) == OnOff.On)
                cCard.cardBase.SetDo(16, OnOff.Off);
            else
                cCard.cardBase.SetDo(16, OnOff.On);
        }
        private void btn_do17_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(17) == OnOff.On)
                cCard.cardBase.SetDo(17, OnOff.Off);
            else
                cCard.cardBase.SetDo(17, OnOff.On);
        }
        private void btn_do18_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(18) == OnOff.On)
                cCard.cardBase.SetDo(18, OnOff.Off);
            else
                cCard.cardBase.SetDo(18, OnOff.On);
        }
        private void btn_do19_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(19) == OnOff.On)
                cCard.cardBase.SetDo(19, OnOff.Off);
            else
                cCard.cardBase.SetDo(19, OnOff.On);
        }
        private void btn_do20_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(20) == OnOff.On)
                cCard.cardBase.SetDo(20, OnOff.Off);
            else
                cCard.cardBase.SetDo(20, OnOff.On);
        }
        private void btn_do21_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(21) == OnOff.On)
                cCard.cardBase.SetDo(21, OnOff.Off);
            else
                cCard.cardBase.SetDo(21, OnOff.On);
        }
        private void btn_do22_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(22) == OnOff.On)
                cCard.cardBase.SetDo(22, OnOff.Off);
            else
                cCard.cardBase.SetDo(22, OnOff.On);
        }
        private void btn_do23_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(23) == OnOff.On)
                cCard.cardBase.SetDo(23, OnOff.Off);
            else
                cCard.cardBase.SetDo(23, OnOff.On);
        }
        private void btn_do24_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(24) == OnOff.On)
                cCard.cardBase.SetDo(24, OnOff.Off);
            else
                cCard.cardBase.SetDo(24, OnOff.On);
        }
        private void btn_do25_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(25) == OnOff.On)
                cCard.cardBase.SetDo(25, OnOff.Off);
            else
                cCard.cardBase.SetDo(25, OnOff.On);
        }
        private void btn_do26_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(26) == OnOff.On)
                cCard.cardBase.SetDo(26, OnOff.Off);
            else
                cCard.cardBase.SetDo(26, OnOff.On);
        }
        private void btn_do27_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(27) == OnOff.On)
                cCard.cardBase.SetDo(27, OnOff.Off);
            else
                cCard.cardBase.SetDo(27, OnOff.On);
        }
        private void btn_do28_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(28) == OnOff.On)
                cCard.cardBase.SetDo(28, OnOff.Off);
            else
                cCard.cardBase.SetDo(28, OnOff.On);
        }
        private void btn_do29_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(29) == OnOff.On)
                cCard.cardBase.SetDo(29, OnOff.Off);
            else
                cCard.cardBase.SetDo(29, OnOff.On);
        }
        private void btn_do30_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(30) == OnOff.On)
                cCard.cardBase.SetDo(30, OnOff.Off);
            else
                cCard.cardBase.SetDo(30, OnOff.On);
        }
        private void btn_do31_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(31) == OnOff.On)
                cCard.cardBase.SetDo(31, OnOff.Off);
            else
                cCard.cardBase.SetDo(31, OnOff.On);
        }
        private void btn_do32_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                return;
            }
            else
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }

            if (cCard.cardBase.GetDoSts(32) == OnOff.On)
                cCard.cardBase.SetDo(32, OnOff.Off);
            else
                cCard.cardBase.SetDo(32, OnOff.On);
        }

        private void cbx_axisList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cCard.cardBase.GetMotorStatu(Instance.cbx_axisList.SelectedIndex))
            {
                Instance.btn_motorOn.RectColor = Color.FromArgb(80, 160, 255);
                Instance.btn_motorOn.FillColor = Color.FromArgb(80, 160, 255);
            }
            else
            {
                Instance.btn_motorOn.RectColor = Color.LightGray;
                Instance.btn_motorOn.FillColor = Color.LightGray;
            }

            Instance.cbx_homeMode.Text = Instance.cbx_homeMode.Items[(int)cCard.cardBase.L_homeMode[Instance.cbx_axisList.SelectedIndex]].ToString();
            Instance.cbx_homeDir.Text = cCard.cardBase.L_homeDir[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.tbx_backLength.Text = cCard.cardBase.L_backLength[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.cbx_pulseMode.Text = cCard.cardBase.L_pulseMode[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.tbx_pulseRate.Text = cCard.cardBase.L_pulseRate[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.tbx_homeVel.Text = cCard.cardBase.L_homeVel[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.tbx_safePos.Text = cCard.cardBase.L_safePos[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.cbx_motorType.Text = cCard.cardBase.L_MotorType[Instance.cbx_axisList.SelectedIndex] ? "伺服电机" : "步进电机";
            Instance.tbx_allowOffset.Text = cCard.cardBase.L_allowOffset[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.cbx_originLogic.Text = cCard.cardBase.L_OriginLogic[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.cbx_NLimitLogic.Text = cCard.cardBase.L_NLimitLogic[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.cbx_PLimitLogic.Text = cCard.cardBase.L_PLimitLogic[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.tbx_NLimit.Text = cCard.cardBase.L_NLimit[Instance.cbx_axisList.SelectedIndex].ToString();
            Instance.tbx_PLimit.Text = cCard.cardBase.L_PLimit[Instance.cbx_axisList.SelectedIndex].ToString();
        }
        private void btn_touchNLimit_Click(object sender, EventArgs e)
        {
            tbx_NLimit.Text = cCard.cardBase.GetCmdPos(cbx_axisList.SelectedIndex).ToString();
        }
        private void btn_touchPLimit_Click(object sender, EventArgs e)
        {
            tbx_PLimit.Text = cCard.cardBase.GetCmdPos(cbx_axisList.SelectedIndex).ToString();
        }
        private void tbx_log_DoubleClick(object sender, EventArgs e)
        {
            tbx_log.Clear();
        }
        private void rdo_jog_Click(object sender, EventArgs e)
        {
            cbx_distance.Visible = false;
            label22.Visible = false;
        }
        private void rdo_move_Click(object sender, EventArgs e)
        {
            cbx_distance.Visible = true;
            label22.Visible = true;
        }
        private void cbx_motorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cCard.cardBase.L_MotorType[cbx_axisList.SelectedIndex] = Instance.cbx_motorType.SelectedIndex == 0 ? true : false;
        }
        private void 通道命名toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string axisName = FuncLib.ShowInput("请输入轴名称");
            if (axisName == string.Empty)
                return;

            int index = cbx_axisList.SelectedIndex;
            cCard.cardBase.L_axisName[cbx_axisList.SelectedIndex] = axisName;
            Instance.cbx_axisList.Items.Clear();
            Instance.cbx_axisList.Items.AddRange(cCard.cardBase.L_axisName);
            cbx_axisList.SelectedIndex = index;
        }

        private void cbx_cardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbx_cardType.SelectedIndex)
            {
                case 0:
                    cCard.cardBase = new Card_DMC1000B();
                    break;
                case 1:
                    cCard.cardBase = new Card_IOC0640();
                    break;
                case 2:
                    cCard.cardBase = new Card_ADLinkM60();
                    break;
            }
        }

        private void ckb_vitualCard_Click(object sender, EventArgs e)
        {
            cCard.cardBase.vitualCard = ckb_vitualCard.Checked;
        }

        private void Btn_touchSafetyPos_Click(object sender, EventArgs e)
        {
            tbx_safePos.Text = cCard.cardBase.GetCmdPos(cbx_axisList.SelectedIndex).ToString();
        }

        private void Btn_conectCard_Click(object sender, EventArgs e)
        {
            cCard.cardBase.Init(cCard.name);
        }
    }
}
