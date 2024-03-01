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

namespace VM_Pro
{
    public partial class Frm_Light : Form
    {
        public Frm_Light()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否正在忙碌
        /// </summary>
        private bool isBusing = false;
        /// <summary>
        /// 当前所选中的通道
        /// </summary>
        private int curSelectedCh = 1;
        /// <summary>
        /// 正在加载窗体
        /// </summary>
        internal static bool isLoading = false;
        /// <summary>
        /// 光源控制器实例
        /// </summary>
        internal static LightService lightService = null;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Light _instance;
        internal static Frm_Light Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Light();
                return _instance;
            }
        }


        /// <summary>
        /// 显示参数到界面
        /// </summary>
        /// <param name="tcpClient"></param>
        internal static void ShowPar(ServiceBase serviceBase)
        {
            isLoading = true;
            Instance.btn_connect.Focus();

            if (Frm_Service.curForm != CurForm.Light)
            {
                Frm_Service.curForm = CurForm.Light;

                Frm_Service.Instance.pnl_seviceBox.Controls.Clear();
                Instance.TopLevel = false;
                Instance.Parent = Frm_Service.Instance.pnl_seviceBox;
                Instance.Dock = DockStyle.Fill;
                Instance.Show();
                Application.DoEvents();
            }

            lightService = (LightService)serviceBase;

            //更新参数
            if (lightService.Connected)
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "已连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;

                Instance.btn_connect.Text = "断开";
            }
            else
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "未连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;

                Instance.btn_connect.Text = "连接";
            }

            Instance.cbx_brand.Text = lightService.lightBase.brand;
            Instance.cbx_chNum.Text = lightService.lightBase.chNum;
            Instance.rdo_basedSerialport.Checked = lightService.lightBase.basedSerialport;
            Instance.rdo_basedNetwork.Checked = !lightService.lightBase.basedSerialport;

            if (lightService.lightBase.basedSerialport)
                Instance.panel1.Visible = false;
            else
                Instance.panel1.Visible = true;

            Instance.cbx_portName.Text = lightService.lightBase.portName.ToString();
            Instance.cbx_baudRate.Text = lightService.lightBase.baudRate.ToString();
            Instance.cbx_dataBit.Text = lightService.lightBase.dataBit.ToString();
            Instance.cbx_stopBit.Text = lightService.lightBase.stopBit.ToString();
            Instance.cbx_parityBit.Text = lightService.lightBase.parity.ToString();

            Instance.ckb_enableCheck.Checked = lightService.lightBase.enableCheck;

            switch (Instance.cbx_chNum.Text)
            {
                case "双通道":
                    Instance.lbl_ch1Name.Visible = true;
                    Instance.lbl_ch2Name.Visible = true;
                    Instance.lbl_ch3Name.Visible = false;
                    Instance.lbl_ch4Name.Visible = false;
                    Instance.lbl_ch5Name.Visible = false;
                    Instance.lbl_ch6Name.Visible = false;
                    Instance.lbl_ch7Name.Visible = false;
                    Instance.lbl_ch8Name.Visible = false;

                    Instance.tck_ch1.Visible = true;
                    Instance.tck_ch2.Visible = true;
                    Instance.tck_ch3.Visible = false;
                    Instance.tck_ch4.Visible = false;
                    Instance.tck_ch5.Visible = false;
                    Instance.tck_ch6.Visible = false;
                    Instance.tck_ch7.Visible = false;
                    Instance.tck_ch8.Visible = false;

                    Instance.nud_valueCh1.Visible = true;
                    Instance.nud_valueCh2.Visible = true;
                    Instance.nud_valueCh3.Visible = false;
                    Instance.nud_valueCh4.Visible = false;
                    Instance.nud_valueCh5.Visible = false;
                    Instance.nud_valueCh6.Visible = false;
                    Instance.nud_valueCh7.Visible = false;
                    Instance.nud_valueCh8.Visible = false;

                    Instance.btn_onOffCh1.Visible = true;
                    Instance.btn_onOffCh2.Visible = true;
                    Instance.btn_onOffCh3.Visible = false;
                    Instance.btn_onOffCh4.Visible = false;
                    Instance.btn_onOffCh5.Visible = false;
                    Instance.btn_onOffCh6.Visible = false;
                    Instance.btn_onOffCh7.Visible = false;
                    Instance.btn_onOffCh8.Visible = false;
                    break;
                case "四通道":
                    Instance.lbl_ch1Name.Visible = true;
                    Instance.lbl_ch2Name.Visible = true;
                    Instance.lbl_ch3Name.Visible = true;
                    Instance.lbl_ch4Name.Visible = true;
                    Instance.lbl_ch5Name.Visible = false;
                    Instance.lbl_ch6Name.Visible = false;
                    Instance.lbl_ch7Name.Visible = false;
                    Instance.lbl_ch8Name.Visible = false;

                    Instance.tck_ch1.Visible = true;
                    Instance.tck_ch2.Visible = true;
                    Instance.tck_ch3.Visible = true;
                    Instance.tck_ch4.Visible = true;
                    Instance.tck_ch5.Visible = false;
                    Instance.tck_ch6.Visible = false;
                    Instance.tck_ch7.Visible = false;
                    Instance.tck_ch8.Visible = false;

                    Instance.nud_valueCh1.Visible = true;
                    Instance.nud_valueCh2.Visible = true;
                    Instance.nud_valueCh3.Visible = true;
                    Instance.nud_valueCh4.Visible = true;
                    Instance.nud_valueCh5.Visible = false;
                    Instance.nud_valueCh6.Visible = false;
                    Instance.nud_valueCh7.Visible = false;
                    Instance.nud_valueCh8.Visible = false;

                    Instance.btn_onOffCh1.Visible = true;
                    Instance.btn_onOffCh2.Visible = true;
                    Instance.btn_onOffCh3.Visible = true;
                    Instance.btn_onOffCh4.Visible = true;
                    Instance.btn_onOffCh5.Visible = false;
                    Instance.btn_onOffCh6.Visible = false;
                    Instance.btn_onOffCh7.Visible = false;
                    Instance.btn_onOffCh8.Visible = false;
                    break;
                case "六通道":
                    Instance.lbl_ch1Name.Visible = true;
                    Instance.lbl_ch2Name.Visible = true;
                    Instance.lbl_ch3Name.Visible = true;
                    Instance.lbl_ch4Name.Visible = true;
                    Instance.lbl_ch5Name.Visible = true;
                    Instance.lbl_ch6Name.Visible = true;
                    Instance.lbl_ch7Name.Visible = false;
                    Instance.lbl_ch8Name.Visible = false;

                    Instance.tck_ch1.Visible = true;
                    Instance.tck_ch2.Visible = true;
                    Instance.tck_ch3.Visible = true;
                    Instance.tck_ch4.Visible = true;
                    Instance.tck_ch5.Visible = true;
                    Instance.tck_ch6.Visible = true;
                    Instance.tck_ch7.Visible = false;
                    Instance.tck_ch8.Visible = false;

                    Instance.nud_valueCh1.Visible = true;
                    Instance.nud_valueCh2.Visible = true;
                    Instance.nud_valueCh3.Visible = true;
                    Instance.nud_valueCh4.Visible = true;
                    Instance.nud_valueCh5.Visible = true;
                    Instance.nud_valueCh6.Visible = true;
                    Instance.nud_valueCh7.Visible = false;
                    Instance.nud_valueCh8.Visible = false;

                    Instance.btn_onOffCh1.Visible = true;
                    Instance.btn_onOffCh2.Visible = true;
                    Instance.btn_onOffCh3.Visible = true;
                    Instance.btn_onOffCh4.Visible = true;
                    Instance.btn_onOffCh5.Visible = true;
                    Instance.btn_onOffCh6.Visible = true;
                    Instance.btn_onOffCh7.Visible = false;
                    Instance.btn_onOffCh8.Visible = false;
                    break;
                case "八通道":
                    Instance.lbl_ch1Name.Visible = true;
                    Instance.lbl_ch2Name.Visible = true;
                    Instance.lbl_ch3Name.Visible = true;
                    Instance.lbl_ch4Name.Visible = true;
                    Instance.lbl_ch5Name.Visible = true;
                    Instance.lbl_ch6Name.Visible = true;
                    Instance.lbl_ch7Name.Visible = true;
                    Instance.lbl_ch8Name.Visible = true;

                    Instance.tck_ch1.Visible = true;
                    Instance.tck_ch2.Visible = true;
                    Instance.tck_ch3.Visible = true;
                    Instance.tck_ch4.Visible = true;
                    Instance.tck_ch5.Visible = true;
                    Instance.tck_ch6.Visible = true;
                    Instance.tck_ch7.Visible = true;
                    Instance.tck_ch8.Visible = true;

                    Instance.nud_valueCh1.Visible = true;
                    Instance.nud_valueCh2.Visible = true;
                    Instance.nud_valueCh3.Visible = true;
                    Instance.nud_valueCh4.Visible = true;
                    Instance.nud_valueCh5.Visible = true;
                    Instance.nud_valueCh6.Visible = true;
                    Instance.nud_valueCh7.Visible = true;
                    Instance.nud_valueCh8.Visible = true;

                    Instance.btn_onOffCh1.Visible = true;
                    Instance.btn_onOffCh2.Visible = true;
                    Instance.btn_onOffCh3.Visible = true;
                    Instance.btn_onOffCh4.Visible = true;
                    Instance.btn_onOffCh5.Visible = true;
                    Instance.btn_onOffCh6.Visible = true;
                    Instance.btn_onOffCh7.Visible = true;
                    Instance.btn_onOffCh8.Visible = true;
                    break;
            }

            Instance.btn_onOffCh1.Enabled = true;
            Instance.btn_onOffCh2.Enabled = true;
            Instance.btn_onOffCh3.Enabled = true;
            Instance.btn_onOffCh4.Enabled = true;
            Instance.btn_onOffCh5.Enabled = true;
            Instance.btn_onOffCh6.Enabled = true;
            Instance.btn_onOffCh7.Enabled = true;
            Instance.btn_onOffCh8.Enabled = true;

            //获取亮度
            Instance.nud_valueCh1.Value = lightService.lightBase.chBrightness[0];
            Instance.nud_valueCh2.Value = lightService.lightBase.chBrightness[1];
            Instance.nud_valueCh3.Value = lightService.lightBase.chBrightness[2];
            Instance.nud_valueCh4.Value = lightService.lightBase.chBrightness[3];
            Instance.nud_valueCh5.Value = lightService.lightBase.chBrightness[4];
            Instance.nud_valueCh6.Value = lightService.lightBase.chBrightness[5];
            Instance.nud_valueCh7.Value = lightService.lightBase.chBrightness[6];
            Instance.nud_valueCh8.Value = lightService.lightBase.chBrightness[7];

            Instance.tck_ch1.Value = lightService.lightBase.chBrightness[0];
            Instance.tck_ch2.Value = lightService.lightBase.chBrightness[1];
            Instance.tck_ch3.Value = lightService.lightBase.chBrightness[2];
            Instance.tck_ch4.Value = lightService.lightBase.chBrightness[3];
            Instance.tck_ch5.Value = lightService.lightBase.chBrightness[4];
            Instance.tck_ch6.Value = lightService.lightBase.chBrightness[5];
            Instance.tck_ch7.Value = lightService.lightBase.chBrightness[6];
            Instance.tck_ch8.Value = lightService.lightBase.chBrightness[7];

            //获取状态
            Instance.btn_onOffCh1.Active = lightService.lightBase.GetOnOffState(1);
            Instance.btn_onOffCh2.Active = lightService.lightBase.GetOnOffState(2);
            if (lightService.lightBase.chNum == "四通道" || lightService.lightBase.chNum == "六通道" || lightService.lightBase.chNum == "八通道")
            {
                Instance.btn_onOffCh3.Active = lightService.lightBase.GetOnOffState(3);
                Instance.btn_onOffCh4.Active = lightService.lightBase.GetOnOffState(4);
            }
            if (lightService.lightBase.chNum == "六通道" || lightService.lightBase.chNum == "八通道")
            {
                Instance.btn_onOffCh5.Active = lightService.lightBase.GetOnOffState(5);
                Instance.btn_onOffCh6.Active = lightService.lightBase.GetOnOffState(6);
            }
            if (lightService.lightBase.chNum == "八通道")
            {
                Instance.btn_onOffCh7.Active = lightService.lightBase.GetOnOffState(7);
                Instance.btn_onOffCh8.Active = lightService.lightBase.GetOnOffState(8);
            }

            Instance.lbl_ch1Name.Text = lightService.lightBase.chName[0];
            Instance.lbl_ch2Name.Text = lightService.lightBase.chName[1];
            Instance.lbl_ch3Name.Text = lightService.lightBase.chName[2];
            Instance.lbl_ch4Name.Text = lightService.lightBase.chName[3];
            Instance.lbl_ch5Name.Text = lightService.lightBase.chName[4];
            Instance.lbl_ch6Name.Text = lightService.lightBase.chName[5];
            Instance.lbl_ch7Name.Text = lightService.lightBase.chName[6];
            Instance.lbl_ch8Name.Text = lightService.lightBase.chName[7];
            isLoading = false;
        }


        private void cbx_brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            lightService.lightBase.brand = cbx_brand.Text;

            switch (cbx_brand.Text)
            {
                case "康视达":
                    lightService.lightBase = new Light_CST(lightService.lightBase.serviceName);
                    break;
                case "大恒":
                    lightService.lightBase = new Light_DaHeng(lightService.lightBase.serviceName);
                    break;
                case "大恒UV":
                    lightService.lightBase = new Light_DaHengUV(lightService.lightBase.serviceName);
                    break;
                case "默然248":
                    lightService.lightBase = new Light_MoRan(lightService.lightBase.serviceName);
                    break;
            }
        }
        private void cbx_chNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            lightService.lightBase.chNum = cbx_chNum.Text;

            switch (cbx_chNum.SelectedIndex)
            {
                case 0:
                    lbl_ch1Name.Visible = true;
                    lbl_ch2Name.Visible = true;
                    lbl_ch3Name.Visible = false;
                    lbl_ch4Name.Visible = false;
                    lbl_ch5Name.Visible = false;
                    lbl_ch6Name.Visible = false;
                    lbl_ch7Name.Visible = false;
                    lbl_ch8Name.Visible = false;

                    tck_ch1.Visible = true;
                    tck_ch2.Visible = true;
                    tck_ch3.Visible = false;
                    tck_ch4.Visible = false;
                    tck_ch5.Visible = false;
                    tck_ch6.Visible = false;
                    tck_ch7.Visible = false;
                    tck_ch8.Visible = false;

                    nud_valueCh1.Visible = true;
                    nud_valueCh2.Visible = true;
                    nud_valueCh3.Visible = false;
                    nud_valueCh4.Visible = false;
                    nud_valueCh5.Visible = false;
                    nud_valueCh6.Visible = false;
                    nud_valueCh7.Visible = false;
                    nud_valueCh8.Visible = false;

                    btn_onOffCh1.Visible = true;
                    btn_onOffCh2.Visible = true;
                    btn_onOffCh3.Visible = false;
                    btn_onOffCh4.Visible = false;
                    btn_onOffCh5.Visible = false;
                    btn_onOffCh6.Visible = false;
                    btn_onOffCh7.Visible = false;
                    btn_onOffCh8.Visible = false;
                    break;
                case 1:
                    lbl_ch1Name.Visible = true;
                    lbl_ch2Name.Visible = true;
                    lbl_ch3Name.Visible = true;
                    lbl_ch4Name.Visible = true;
                    lbl_ch5Name.Visible = false;
                    lbl_ch6Name.Visible = false;
                    lbl_ch7Name.Visible = false;
                    lbl_ch8Name.Visible = false;

                    tck_ch1.Visible = true;
                    tck_ch2.Visible = true;
                    tck_ch3.Visible = true;
                    tck_ch4.Visible = true;
                    tck_ch5.Visible = false;
                    tck_ch6.Visible = false;
                    tck_ch7.Visible = false;
                    tck_ch8.Visible = false;

                    nud_valueCh1.Visible = true;
                    nud_valueCh2.Visible = true;
                    nud_valueCh3.Visible = true;
                    nud_valueCh4.Visible = true;
                    nud_valueCh5.Visible = false;
                    nud_valueCh6.Visible = false;
                    nud_valueCh7.Visible = false;
                    nud_valueCh8.Visible = false;

                    btn_onOffCh1.Visible = true;
                    btn_onOffCh2.Visible = true;
                    btn_onOffCh3.Visible = true;
                    btn_onOffCh4.Visible = true;
                    btn_onOffCh5.Visible = false;
                    btn_onOffCh6.Visible = false;
                    btn_onOffCh7.Visible = false;
                    btn_onOffCh8.Visible = false;
                    break;
                case 2:
                    lbl_ch1Name.Visible = true;
                    lbl_ch2Name.Visible = true;
                    lbl_ch3Name.Visible = true;
                    lbl_ch4Name.Visible = true;
                    lbl_ch5Name.Visible = true;
                    lbl_ch6Name.Visible = true;
                    lbl_ch7Name.Visible = false;
                    lbl_ch8Name.Visible = false;

                    tck_ch1.Visible = true;
                    tck_ch2.Visible = true;
                    tck_ch3.Visible = true;
                    tck_ch4.Visible = true;
                    tck_ch5.Visible = true;
                    tck_ch6.Visible = true;
                    tck_ch7.Visible = false;
                    tck_ch8.Visible = false;

                    nud_valueCh1.Visible = true;
                    nud_valueCh2.Visible = true;
                    nud_valueCh3.Visible = true;
                    nud_valueCh4.Visible = true;
                    nud_valueCh5.Visible = true;
                    nud_valueCh6.Visible = true;
                    nud_valueCh7.Visible = false;
                    nud_valueCh8.Visible = false;

                    btn_onOffCh1.Visible = true;
                    btn_onOffCh2.Visible = true;
                    btn_onOffCh3.Visible = true;
                    btn_onOffCh4.Visible = true;
                    btn_onOffCh5.Visible = true;
                    btn_onOffCh6.Visible = true;
                    btn_onOffCh7.Visible = false;
                    btn_onOffCh8.Visible = false;
                    break;
                case 3:
                    lbl_ch1Name.Visible = true;
                    lbl_ch2Name.Visible = true;
                    lbl_ch3Name.Visible = true;
                    lbl_ch4Name.Visible = true;
                    lbl_ch5Name.Visible = true;
                    lbl_ch6Name.Visible = true;
                    lbl_ch7Name.Visible = true;
                    lbl_ch8Name.Visible = true;

                    tck_ch1.Visible = true;
                    tck_ch2.Visible = true;
                    tck_ch3.Visible = true;
                    tck_ch4.Visible = true;
                    tck_ch5.Visible = true;
                    tck_ch6.Visible = true;
                    tck_ch7.Visible = true;
                    tck_ch8.Visible = true;

                    nud_valueCh1.Visible = true;
                    nud_valueCh2.Visible = true;
                    nud_valueCh3.Visible = true;
                    nud_valueCh4.Visible = true;
                    nud_valueCh5.Visible = true;
                    nud_valueCh6.Visible = true;
                    nud_valueCh7.Visible = true;
                    nud_valueCh8.Visible = true;

                    btn_onOffCh1.Visible = true;
                    btn_onOffCh2.Visible = true;
                    btn_onOffCh3.Visible = true;
                    btn_onOffCh4.Visible = true;
                    btn_onOffCh5.Visible = true;
                    btn_onOffCh6.Visible = true;
                    btn_onOffCh7.Visible = true;
                    btn_onOffCh8.Visible = true;
                    break;
            }
        }
        private void rdo_basedSerialport_Click(object sender, EventArgs e)
        {
            lightService.lightBase.basedSerialport = true;
            panel1.Visible = false;
        }
        private void rdo_basedNetwork_Click(object sender, EventArgs e)
        {
            lightService.lightBase.basedSerialport = false;
            panel1.Visible = true;
        }
        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (lightService.Connected)
                lightService.lightBase.Close();
            else
                lightService.lightBase.Open();

            if (lightService.Connected)
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "已连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
                btn_connect.Text = "断开";
            }
            else
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "未连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
                btn_connect.Text = "连接";
            }
        }
        private void Frm_Light_Load(object sender, EventArgs e)
        {
            cbx_portName.Clear();
            string[] strs = SerialPort.GetPortNames();
            cbx_portName.Items.AddRange(strs);

            cbx_parityBit.Clear();
            foreach (var item in Enum.GetValues(typeof(Parity)))
            {
                cbx_parityBit.Items.Add(item.ToString());
            }

            cbx_stopBit.Clear();
            foreach (var item in Enum.GetValues(typeof(StopBits)))
            {
                cbx_stopBit.Items.Add(item.ToString());
            }
        }
        private void cbx_portName_TextChanged(object sender, EventArgs e)
        {
            lightService.lightBase.portName = cbx_portName.Text;
        }
        private void cbx_baudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            lightService.lightBase.baudRate = Convert.ToInt32(cbx_baudRate.Text);
        }
        private void tbx_dataBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            lightService.lightBase.dataBit = Convert.ToInt16(cbx_dataBit.Text);
        }
        private void cbx_stopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            lightService.lightBase.stopBit = (StopBits)Enum.Parse(typeof(StopBits), cbx_stopBit.Text.Trim());
        }
        private void cbx_parityBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            lightService.lightBase.parity = (Parity)Enum.Parse(typeof(Parity), cbx_parityBit.Text.Trim());
        }

        private void ckb_enableCheck_Click(object sender, EventArgs e)
        {
            lightService.lightBase.enableCheck = ckb_enableCheck.Checked;
        }

        private void btn_onOffCh1_Click(object sender, EventArgs e)
        {
            if (btn_onOffCh1.Active)
            {
                lightService.lightBase.OpenCh(1);
                lightService.lightBase.SetValue(1, (int)nud_valueCh1.Value);
                
            }
            else
            {
                lightService.lightBase.CloseCh(1);
            }
        }
        private void btn_onOffCh2_Click(object sender, EventArgs e)
        {
            if (btn_onOffCh2.Active)
            {
                lightService.lightBase.SetValue(2, (int)nud_valueCh2.Value);
                lightService.lightBase.OpenCh(2);
            }
            else
            {
                lightService.lightBase.CloseCh(2);
            }
        }
        private void btn_onOffCh3_Click(object sender, EventArgs e)
        {
            if (btn_onOffCh3.Active)
            {
                lightService.lightBase.SetValue(3, (int)nud_valueCh3.Value);
                lightService.lightBase.OpenCh(3);
            }
            else
            {
                lightService.lightBase.CloseCh(3);
            }
        }
        private void btn_onOffCh4_Click(object sender, EventArgs e)
        {
            if (btn_onOffCh4.Active)
            {
                lightService.lightBase.SetValue(4, (int)nud_valueCh4.Value);
                lightService.lightBase.OpenCh(4);
            }
            else
            {
                lightService.lightBase.CloseCh(4);
            }
        }
        private void btn_onOffCh5_Click(object sender, EventArgs e)
        {
            if (btn_onOffCh5.Active)
                lightService.lightBase.OpenCh(5);
            else
                lightService.lightBase.CloseCh(5);
        }
        private void btn_onOffCh6_Click(object sender, EventArgs e)
        {
            if (btn_onOffCh6.Active)
                lightService.lightBase.OpenCh(6);
            else
                lightService.lightBase.CloseCh(6);
        }
        private void btn_onOffCh7_Click(object sender, EventArgs e)
        {
            if (btn_onOffCh7.Active)
                lightService.lightBase.OpenCh(7);
            else
                lightService.lightBase.CloseCh(7);
        }
        private void btn_onOffCh8_Click(object sender, EventArgs e)
        {
            if (btn_onOffCh8.Active)
                lightService.lightBase.OpenCh(8);
            else
                lightService.lightBase.CloseCh(8);
        }

        private void nud_valueCh1_ValueChanged(double value)
        {
            if (isLoading)
                return;

            if (!isBusing)
            {
                Thread th = new Thread(() =>
                {
                    isBusing = true;
                    tck_ch1.Value = (int)value;
                    lightService.lightBase.OpenCh(1);
                    lightService.lightBase.SetValue(1, (int)value);
                    isBusing = false;
                });
                th.IsBackground = true;
                th.Start();
            }

            if ((int)value != 0)
                btn_onOffCh1.Active = true;
            else
                btn_onOffCh1.Active = false;
        }
        private void nud_valueCh2_ValueChanged(double value)
        {
            if (isLoading)
                return;

            if (!isBusing)
            {
                Thread th = new Thread(() =>
                {
                    isBusing = true;
                    tck_ch2.Value = (int)value;
                    lightService.lightBase.SetValue(2, (int)value);
                    lightService.lightBase.OpenCh(2);
                    isBusing = false;
                });
                th.IsBackground = true;
                th.Start();
            }

            if ((int)value != 0)
                btn_onOffCh2.Active = true;
            else
                btn_onOffCh2.Active = false;
        }
        private void nud_valueCh3_ValueChanged(double value)
        {
            if (isLoading)
                return;

            if (!isBusing)
            {
                Thread th = new Thread(() =>
                {
                    isBusing = true;
                    tck_ch3.Value = (int)value;
                    lightService.lightBase.SetValue(3, (int)value);
                    lightService.lightBase.OpenCh(3);
                    isBusing = false;
                });
                th.IsBackground = true;
                th.Start();
            }

            if ((int)value != 0)
                btn_onOffCh3.Active = true;
            else
                btn_onOffCh3.Active = false;
        }
        private void nud_valueCh4_ValueChanged(double value)
        {
            if (isLoading)
                return;

            if (!isBusing)
            {
                Thread th = new Thread(() =>
                {
                    isBusing = true;
                    tck_ch4.Value = (int)value;
                    lightService.lightBase.SetValue(4, (int)value);
                    lightService.lightBase.OpenCh(4);
                    isBusing = false;
                });
                th.IsBackground = true;
                th.Start();
            }

            if ((int)value != 0)
                btn_onOffCh4.Active = true;
            else
                btn_onOffCh4.Active = false;
        }
        private void nud_valueCh5_ValueChanged(double value)
        {
            if (isLoading)
                return;

            if (!isBusing)
            {
                Thread th = new Thread(() =>
                {
                    isBusing = true;
                    tck_ch5.Value = (int)value;
                    lightService.lightBase.SetValue(5, (int)value);
                    lightService.lightBase.OpenCh(5);
                    isBusing = false;
                });
                th.IsBackground = true;
                th.Start();
            }

            if ((int)value != 0)
                btn_onOffCh5.Active = true;
            else
                btn_onOffCh5.Active = false;
        }
        private void nud_valueCh6_ValueChanged(double value)
        {
            if (isLoading)
                return;

            if (!isBusing)
            {
                Thread th = new Thread(() =>
                {
                    isBusing = true;
                    tck_ch6.Value = (int)value;
                    lightService.lightBase.SetValue(6, (int)value);
                    lightService.lightBase.OpenCh(6);
                    isBusing = false;
                });
                th.IsBackground = true;
                th.Start();
            }

            if ((int)value != 0)
                btn_onOffCh6.Active = true;
            else
                btn_onOffCh6.Active = false;
        }
        private void nud_valueCh7_ValueChanged(double value)
        {
            if (isLoading)
                return;

            if (!isBusing)
            {
                Thread th = new Thread(() =>
                {
                    isBusing = true;
                    tck_ch7.Value = (int)value;
                    lightService.lightBase.SetValue(7, (int)value);
                    lightService.lightBase.OpenCh(7);
                    isBusing = false;
                });
                th.IsBackground = true;
                th.Start();
            }

            if ((int)value != 0)
                btn_onOffCh7.Active = true;
            else
                btn_onOffCh7.Active = false;
        }
        private void nud_valueCh8_ValueChanged(double value)
        {
            if (isLoading)
                return;

            if (!isBusing)
            {
                Thread th = new Thread(() =>
                {
                    isBusing = true;
                    tck_ch8.Value = (int)value;
                    lightService.lightBase.SetValue(8, (int)value);
                    lightService.lightBase.OpenCh(8);
                    isBusing = false;
                });
                th.IsBackground = true;
                th.Start();
            }

            if ((int)value != 0)
                btn_onOffCh8.Active = true;
            else
                btn_onOffCh8.Active = false;
        }

        private void tck_ch1_Scroll(object sender, EventArgs e)
        {
            nud_valueCh1.Value = tck_ch1.Value;
        }
        private void tck_ch2_Scroll(object sender, EventArgs e)
        {
            nud_valueCh2.Value = tck_ch2.Value;
        }
        private void tck_ch3_Scroll(object sender, EventArgs e)
        {
            nud_valueCh3.Value = tck_ch3.Value;
        }
        private void tck_ch4_Scroll(object sender, EventArgs e)
        {
            nud_valueCh4.Value = tck_ch4.Value;
        }
        private void tck_ch5_Scroll(object sender, EventArgs e)
        {
            nud_valueCh5.Value = tck_ch5.Value;
        }
        private void tck_ch6_Scroll(object sender, EventArgs e)
        {
            nud_valueCh6.Value = tck_ch6.Value;
        }
        private void tck_ch7_Scroll(object sender, EventArgs e)
        {
            nud_valueCh7.Value = tck_ch7.Value;
        }
        private void tck_ch8_Scroll(object sender, EventArgs e)
        {
            nud_valueCh8.Value = tck_ch8.Value;
        }

        private void btn_openAllCh_Click(object sender, EventArgs e)
        {
            lightService.lightBase.OpenAllCh();
            btn_onOffCh1.Active = true;
            btn_onOffCh2.Active = true;
            if (lightService.lightBase.chNum == "四通道" || lightService.lightBase.chNum == "六通道" || lightService.lightBase.chNum == "八通道")
            {
                btn_onOffCh3.Active = true;
                btn_onOffCh4.Active = true;
            }
            if (lightService.lightBase.chNum == "六通道" || lightService.lightBase.chNum == "八通道")
            {
                btn_onOffCh5.Active = true;
                btn_onOffCh6.Active = true;
            }
            if (lightService.lightBase.chNum == "八通道")
            {
                btn_onOffCh7.Active = true;
                btn_onOffCh8.Active = true;
            }
        }
        private void btn_closeAllCh_Click(object sender, EventArgs e)
        {
            lightService.lightBase.CloseAllCh();
            btn_onOffCh1.Active = false;
            btn_onOffCh2.Active = false;
            if (lightService.lightBase.chNum == "四通道" || lightService.lightBase.chNum == "六通道" || lightService.lightBase.chNum == "八通道")
            {
                btn_onOffCh3.Active = false;
                btn_onOffCh4.Active = false;
            }
            if (lightService.lightBase.chNum == "六通道" || lightService.lightBase.chNum == "八通道")
            {
                btn_onOffCh5.Active = false;
                btn_onOffCh6.Active = false;
            }
            if (lightService.lightBase.chNum == "八通道")
            {
                btn_onOffCh7.Active = false;
                btn_onOffCh8.Active = false;
            }
        }

        private void lbl_ch1Name_MouseDown(object sender, MouseEventArgs e)
        {
            curSelectedCh = 1;
        }
        private void lbl_ch2Name_MouseDown(object sender, MouseEventArgs e)
        {
            curSelectedCh = 2;
        }
        private void lbl_ch3Name_MouseDown(object sender, MouseEventArgs e)
        {
            curSelectedCh = 3;
        }
        private void lbl_ch4Name_MouseDown(object sender, MouseEventArgs e)
        {
            curSelectedCh = 4;
        }
        private void lbl_ch5Name_MouseDown(object sender, MouseEventArgs e)
        {
            curSelectedCh = 5;
        }
        private void lbl_ch6Name_MouseDown(object sender, MouseEventArgs e)
        {
            curSelectedCh = 6;
        }
        private void lbl_ch7Name_MouseDown(object sender, MouseEventArgs e)
        {
            curSelectedCh = 7;
        }
        private void lbl_ch8Name_MouseDown(object sender, MouseEventArgs e)
        {
            curSelectedCh = 8;
        }

        private void 通道命名toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string chName = FuncLib.ShowInput("请输入新通道名");
            if (chName == string.Empty)
                return;

            lightService.lightBase.chName[curSelectedCh - 1] = chName + "：";

            lbl_ch1Name.Text = lightService.lightBase.chName[0];
            lbl_ch2Name.Text = lightService.lightBase.chName[1];
            lbl_ch3Name.Text = lightService.lightBase.chName[2];
            lbl_ch4Name.Text = lightService.lightBase.chName[3];
            lbl_ch5Name.Text = lightService.lightBase.chName[4];
            lbl_ch6Name.Text = lightService.lightBase.chName[5];
            lbl_ch7Name.Text = lightService.lightBase.chName[6];
            lbl_ch8Name.Text = lightService.lightBase.chName[7];
        }

    }
}
