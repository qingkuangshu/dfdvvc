using Microsoft.Win32;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_Serial : Form
    {
        public Frm_Serial()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Serial _instance;
        internal static Frm_Serial Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Serial();
                return _instance;
            }
        }
        /// <summary>
        /// 客户端实例
        /// </summary>
        internal static Serial serial = null;
        ///循环发送
        internal static bool loopSend = false;


        /// <summary>
        /// 显示参数到界面
        /// </summary>
        /// <param name="tcpClient"></param>
        internal static void ShowPar(ServiceBase serviceBase)
        {
            if (Frm_Service.curForm != CurForm.Serial)
            {
                Frm_Service.curForm = CurForm.Serial;

                Frm_Service.Instance.pnl_seviceBox.Controls.Clear();
                Instance.TopLevel = false;
                Instance.Parent = Frm_Service.Instance.pnl_seviceBox;
                Instance.Dock = DockStyle.Fill;
                Instance.Show();
            }

            serial = (Serial)serviceBase;

            //更新参数
            if (Serial.FindSerialPortByName(serviceBase.name).IsOpen)
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "已连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
            }
            else
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "未连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
            }

            Instance.cbx_portName.Text = serial.portName.ToString();
            Instance.cbx_baudRate.Text = serial.baudRate.ToString();
            Instance.cbx_dataBit.Text = serial.dataBit.ToString();
            Instance.cbx_stopBit.Text = serial.stopBit.ToString();
            Instance.cbx_parityBit.Text = serial.parity.ToString();

            Instance.tbx_msg1.Text = serial.sendStr1;
            Instance.tbx_msg2.Text = serial.sendStr2;
            Instance.tbx_msg3.Text = serial.sendStr3;

            Instance.tbx_log.Clear();

            //更新连接状态
            Instance.btn_open.Text = (Serial.FindSerialPortByName(serial.name).IsOpen ? "断开" : "连接");
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (Serial.FindSerialPortByName(serial.name).IsOpen)
                serial.Close();
            else
                serial.Open();

            if (Serial.FindSerialPortByName(serial.name).IsOpen)
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "已连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
                btn_open.Text = "断开";
            }
            else
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "未连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
                btn_open.Text = "连接";
            }
        }
        private void ckb_hexMode_CheckedChanged(object sender, EventArgs e)
        {
            //////m_tcpClient.hexMode = ckb_hexMode.Checked;
        }
        private void ckb_receiveTimeoutEnable_CheckedChanged(object sender, EventArgs e)
        {
            //////m_tcpClient.receiveTimeoutEnable = Instance.ckb_receiveTimeoutEnable.Checked;

            //////tbx_receiveTimeout.Visible = m_tcpClient.receiveTimeoutEnable;
            //////uiLabel8.Visible = m_tcpClient.receiveTimeoutEnable;
        }
        private void tbx_receiveTimeout_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //////m_tcpClient.receiveTimeout = Convert.ToInt32(Instance.tbx_receiveTimeout.Text.Trim());
            }
            catch { }
        }
        private void ckb_loopSend_CheckedChanged(object sender, EventArgs e)
        {
            //////m_tcpClient.loopSend = ckb_loopSend.Checked;

            //////tbx_loopSendSpan.Visible = m_tcpClient.loopSend;
            //////uiLabel6.Visible = m_tcpClient.loopSend;
        }
        private void tbx_loopSendSpan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //////m_tcpClient.loopSendSpan = Convert.ToInt16(tbx_loopSendSpan.Text.Trim());
            }
            catch { }
        }

        private void tbx_msg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (((Sunny.UI.UITextBox)sender).Text == string.Empty)
                    return;

                if (!Serial.FindSerialPortByName(serial.name).IsOpen)
                {
                    FuncLib.ShowMsg("串口未打开，不可发送指令", InfoType.Error);
                    return;
                }

                serial.Send(((Sunny.UI.UITextBox)sender).Text);
            }
        }
        private void tbx_msg1_TextChanged(object sender, EventArgs e)
        {
            serial.sendStr1 = tbx_msg1.Text;
        }
        private void tbx_msg2_TextChanged(object sender, EventArgs e)
        {
            serial.sendStr2 = tbx_msg2.Text;
        }
        private void tbx_msg3_TextChanged(object sender, EventArgs e)
        {
            serial.sendStr3 = tbx_msg3.Text;
        }
        private void btn_send1_Click(object sender, EventArgs e)
        {
            if (tbx_msg1.Text == string.Empty)
                return;

            if (!Serial.FindSerialPortByName(serial.name).IsOpen)
            {
                FuncLib.ShowMsg("串口未打开，不可发送指令", InfoType.Error);
                return;
            }

            if (btn_send1.Text == "发送")
            {
                //////if (!serial.loopSend)
                //////{
                serial.Send(tbx_msg1.Text);
                //////}
                //////else
                //////{
                //////    btn_send1.Text = "停止";
                //////    loopSend = true;
                //////    Thread th = new Thread(() =>
                //////    {
                //////        while (loopSend)
                //////        {
                //////            serial.Send(tbx_msg1.Text);
                //////            Thread.Sleep(serial.loopSendSpan);
                //////        }
                //////    });
                //////    th.IsBackground = true;
                //////    th.Start();
                //////}
            }
            else
            {
                btn_send1.Text = "发送";
                loopSend = false;
            }
        }
        private void btn_send2_Click(object sender, EventArgs e)
        {
            if (tbx_msg2.Text == string.Empty)
                return;

            if (!Serial.FindSerialPortByName(serial.name).IsOpen)
            {
                FuncLib.ShowMsg("串口未打开，不可发送指令", InfoType.Error);
                return;
            }

            if (btn_send2.Text == "发送")
            {
                //////if (!serial.loopSend)
                //////{
                serial.Send(tbx_msg2.Text);
                //////}
                //////else
                //////{
                //////    btn_send2.Text = "停止";
                //////    loopSend = true;
                //////    Thread th = new Thread(() =>
                //////    {
                //////        while (loopSend)
                //////        {
                //////            serial.Send(tbx_msg2.Text);
                //////            Thread.Sleep(serial.loopSendSpan);
                //////        }
                //////    });
                //////    th.IsBackground = true;
                //////    th.Start();
                //////}
            }
            else
            {
                btn_send2.Text = "发送";
                loopSend = false;
            }
        }
        private void btn_send3_Click(object sender, EventArgs e)
        {
            if (tbx_msg3.Text == string.Empty)
                return;

            if (!Serial.FindSerialPortByName(serial.name).IsOpen)
            {
                FuncLib.ShowMsg("串口未打开，不可发送指令", InfoType.Error);
                return;
            }

            if (btn_send3.Text == "发送")
            {
                //////if (!serial.loopSend)
                //////{
                serial.Send(tbx_msg3.Text);
                //////}
                //////else
                //////{
                //////    btn_send3.Text = "停止";
                //////    loopSend = true;
                //////    Thread th = new Thread(() =>
                //////    {
                //////        while (loopSend)
                //////        {
                //////            serial.Send(tbx_msg3.Text);
                //////            Thread.Sleep(serial.loopSendSpan);
                //////        }
                //////    });
                //////    th.IsBackground = true;
                //////    th.Start();
                //////}
            }
            else
            {
                btn_send3.Text = "发送";
                loopSend = false;
            }
        }

        private void 历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuncLib.ShowMessageBox("尚未开发，敬请期待！");
        }
        private void lnk_clearLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbx_log.Clear();
        }
        private void Frm_Serial_Load(object sender, EventArgs e)
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
            serial.portName = cbx_portName.Text;
        }
        private void cbx_baudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            serial.baudRate = Convert.ToInt32(cbx_baudRate.Text);
        }
        private void cbx_dataBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            serial.dataBit = Convert.ToInt16(cbx_dataBit.Text);
        }
        private void cbx_stopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            serial.stopBit = (StopBits)Enum.Parse(typeof(StopBits), cbx_stopBit.Text.Trim());
        }
        private void cbx_parityBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            serial.parity = (Parity)Enum.Parse(typeof(Parity), cbx_parityBit.Text.Trim());
        }

    }
}
