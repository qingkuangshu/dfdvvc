using Microsoft.Win32;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
    public partial class Frm_TCPClient : Form
    {
        public Frm_TCPClient()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_TCPClient _instance;
        internal static Frm_TCPClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_TCPClient();
                return _instance;
            }
        }
        /// <summary>
        /// 客户端实例
        /// </summary>
        internal static TCPClient m_tcpClient = null;
        ///循环发送
        internal static bool loopSend = false;

        /// <summary>
        /// 当前窗体是否初始化过
        /// </summary>
        internal static bool initLoad=false;

        /// <summary>
        /// 显示参数到界面
        /// </summary>
        /// <param name="tcpClient"></param>
        internal static void ShowPar(ServiceBase serviceBase)
        {
            if (Frm_Service.curForm != CurForm.TCPClient)
            {
                Frm_Service.curForm = CurForm.TCPClient;

                Frm_Service.Instance.pnl_seviceBox.Controls.Clear();
                Instance.TopLevel = false;
                Instance.Parent = Frm_Service.Instance.pnl_seviceBox;
                Instance.Dock = DockStyle.Fill;
                Instance.Show();
            }

            m_tcpClient = (TCPClient)serviceBase;

            //更新参数
            if (TCPClient.FindClientByName(serviceBase.name).Connected)
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "已连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
            }
            else
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "未连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
            }

            Instance.cbx_IP.Text = m_tcpClient.severIP;
            Instance.tbx_Port.Text = m_tcpClient.severPort.ToString();
            Instance.ckb_autoListenAfterStart.Checked = m_tcpClient.autoConnectAfterStart;
            Instance.ckb_hexMode.Checked = m_tcpClient.hexMode;
            Instance.ckb_autoConnect.Checked = m_tcpClient.autoConnect;
            Instance.ckb_failAutoConnect.Checked = m_tcpClient.failAutoConnect;
            Instance.ckb_connectTimeoutEnable.Checked = m_tcpClient.connectTimeoutEnable;
            Instance.tbx_connectTimeout.Text = m_tcpClient.connectTimeout.ToString();
            Instance.ckb_receiveTimeoutEnable.Checked = m_tcpClient.receiveTimeoutEnable;
            Instance.tbx_receiveTimeout.Text = m_tcpClient.receiveTimeout.ToString();
            Instance.ckb_loopSend.Checked = m_tcpClient.loopSend;
            Instance.tbx_loopSendSpan.Text = m_tcpClient.loopSendSpan.ToString();
            Instance.tbx_loopSendSpan.Visible = m_tcpClient.loopSend;
            Instance.uiLabel6.Visible = m_tcpClient.loopSend;

            Instance.tbx_msg1.Text = m_tcpClient.sendStr1;
            Instance.tbx_msg2.Text = m_tcpClient.sendStr2;
            Instance.tbx_msg3.Text = m_tcpClient.sendStr3;

            Instance.tbx_connectTimeout.Visible = m_tcpClient.connectTimeoutEnable;
            Instance.uiLabel7.Visible = m_tcpClient.connectTimeoutEnable;
            Instance.tbx_receiveTimeout.Visible = m_tcpClient.receiveTimeoutEnable;
            Instance.uiLabel8.Visible = m_tcpClient.receiveTimeoutEnable;

            Instance.tbx_log.Clear();

            //更新连接状态
            Instance.btn_connect.Text = (TCPClient.FindClientByName(m_tcpClient.name).Connected ? "断开" : "连接");
            Instance.cbx_IP.Enabled = (TCPClient.FindClientByName(m_tcpClient.name).Connected ? false : true);
            Instance.tbx_Port.Enabled = (TCPClient.FindClientByName(m_tcpClient.name).Connected ? false : true);
        }
        /// <summary>
        /// 客户端命名查重
        /// </summary>
        /// <param name="jobName">客户端名</param>
        /// <returns>是否已存在</returns>
        internal static bool CheckExist(string name)
        {
            foreach (KeyValuePair<string, Socket> item in TCPClient.L_socket)
            {
                if (item.Key == name)
                    return true;
            }
            return false;
        }


        private void Frm_TCPServer_Load(object sender, EventArgs e)
        {
            initLoad = true;
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);

            cbx_IP.Items.Clear();
            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    cbx_IP.Items.Add(ipa.ToString());
            }
        }

        private void cbx_IP_TextChanged(object sender, EventArgs e)
        {
            m_tcpClient.severIP = cbx_IP.Text.Trim();
        }
        private void btn_showItem_Click(object sender, EventArgs e)
        {
            cbx_IP.ShowDropDown();
        }
        private void tbx_Port_TextChanged(object sender, EventArgs e)
        {
            try
            {
                m_tcpClient.severPort = Convert.ToInt32(tbx_Port.Text.Trim());
            }
            catch { }
        }
        /// <summary>
        /// 断开与连接的按钮操作，大致的逻辑是，进行断开或连接后，然后在去判断当前的连接状态，做相应的显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (TCPClient.FindClientByName(m_tcpClient.name).Connected)
                m_tcpClient.Disconect();
            else
                m_tcpClient.Connect();

            if (TCPClient.FindClientByName(m_tcpClient.name).Connected)
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "已连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
                btn_connect.Text = "断开";

                cbx_IP.Enabled = false;
                tbx_Port.Enabled = false;
                m_tcpClient.disconnectBySelf = false;
            }
            else
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "未连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
                btn_connect.Text = "连接";

                cbx_IP.Enabled = true;
                tbx_Port.Enabled = true;
            }
        }
        private void ckb_autoListenAfterStart_CheckedChanged(object sender, EventArgs e)
        {
            m_tcpClient.autoConnectAfterStart = ckb_autoListenAfterStart.Checked;
        }
        private void ckb_hexMode_CheckedChanged(object sender, EventArgs e)
        {
            m_tcpClient.hexMode = ckb_hexMode.Checked;
        }
        private void ckb_autoConnect_CheckedChanged(object sender, EventArgs e)
        {
            m_tcpClient.autoConnect = ckb_autoConnect.Checked;
        }
        private void ckb_failAutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            m_tcpClient.failAutoConnect = ckb_failAutoConnect.Checked;
        }
        private void ckb_connectTimeoutEnable_CheckedChanged(object sender, EventArgs e)
        {
            m_tcpClient.connectTimeoutEnable = ckb_connectTimeoutEnable.Checked;

            tbx_connectTimeout.Visible = m_tcpClient.connectTimeoutEnable;
            uiLabel7.Visible = m_tcpClient.connectTimeoutEnable;
        }
        private void tbx_connectTimeout_TextChanged(object sender, EventArgs e)
        {
            try
            {
                m_tcpClient.connectTimeout = Convert.ToInt32(tbx_connectTimeout.Text.Trim());
            }
            catch { }
        }
        private void ckb_receiveTimeoutEnable_CheckedChanged(object sender, EventArgs e)
        {
            m_tcpClient.receiveTimeoutEnable = Instance.ckb_receiveTimeoutEnable.Checked;

            tbx_receiveTimeout.Visible = m_tcpClient.receiveTimeoutEnable;
            uiLabel8.Visible = m_tcpClient.receiveTimeoutEnable;
        }
        private void tbx_receiveTimeout_TextChanged(object sender, EventArgs e)
        {
            try
            {
                m_tcpClient.receiveTimeout = Convert.ToInt32(Instance.tbx_receiveTimeout.Text.Trim());
            }
            catch { }
        }
        private void ckb_loopSend_CheckedChanged(object sender, EventArgs e)
        {
            m_tcpClient.loopSend = ckb_loopSend.Checked;

            tbx_loopSendSpan.Visible = m_tcpClient.loopSend;
            uiLabel6.Visible = m_tcpClient.loopSend;
        }
        private void tbx_loopSendSpan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                m_tcpClient.loopSendSpan = Convert.ToInt16(tbx_loopSendSpan.Text.Trim());
            }
            catch { }
        }

        private void tbx_msg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (((Sunny.UI.UITextBox)sender).Text == string.Empty)
                    return;

                if (!TCPClient.FindClientByName(m_tcpClient.name).Connected)
                {
                    FuncLib.ShowMsg("当前客户端没有连接到服务端，不可发送消息", InfoType.Error);
                    return;
                }

                m_tcpClient.Send(((Sunny.UI.UITextBox)sender).Text);
            }
        }
        private void tbx_msg1_TextChanged(object sender, EventArgs e)
        {
            m_tcpClient.sendStr1 = tbx_msg1.Text;
        }
        private void tbx_msg2_TextChanged(object sender, EventArgs e)
        {
            m_tcpClient.sendStr2 = tbx_msg2.Text;
        }
        private void tbx_msg3_TextChanged(object sender, EventArgs e)
        {
            m_tcpClient.sendStr3 = tbx_msg3.Text;
        }
        private void btn_send1_Click(object sender, EventArgs e)
        {
            if (tbx_msg1.Text == string.Empty)
                return;

            if (!TCPClient.FindClientByName(m_tcpClient.name).Connected)
            {
                FuncLib.ShowMsg("客户端没有连接到服务端，不可发送消息", InfoType.Error);
                return;
            }

            if (btn_send1.Text == "发送")
            {
                if (!m_tcpClient.loopSend)
                {
                    m_tcpClient.Send(tbx_msg1.Text);
                }
                else
                {
                    btn_send1.Text = "停止";
                    loopSend = true;
                    Thread th = new Thread(() =>
                    {
                        while (loopSend)
                        {
                            m_tcpClient.Send(tbx_msg1.Text);
                            Thread.Sleep(m_tcpClient.loopSendSpan);
                        }
                    });
                    th.IsBackground = true;
                    th.Start();
                }
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

            if (!TCPClient.FindClientByName(m_tcpClient.name).Connected)
            {
                FuncLib.ShowMsg("客户端没有连接到服务端，不可发送消息", InfoType.Error);
                return;
            }

            if (btn_send2.Text == "发送")
            {
                if (!m_tcpClient.loopSend)
                {
                    m_tcpClient.Send(tbx_msg2.Text);
                }
                else
                {
                    btn_send2.Text = "停止";
                    loopSend = true;
                    Thread th = new Thread(() =>
                    {
                        while (loopSend)
                        {
                            m_tcpClient.Send(tbx_msg2.Text);
                            Thread.Sleep(m_tcpClient.loopSendSpan);
                        }
                    });
                    th.IsBackground = true;
                    th.Start();
                }
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

            if (!TCPClient.FindClientByName(m_tcpClient.name).Connected)
            {
                FuncLib.ShowMsg("客户端没有连接到服务端，不可发送消息", InfoType.Error);
                return;
            }

            if (btn_send3.Text == "发送")
            {
                if (!m_tcpClient.loopSend)
                {
                    m_tcpClient.Send(tbx_msg3.Text);
                }
                else
                {
                    btn_send3.Text = "停止";
                    loopSend = true;
                    Thread th = new Thread(() =>
                    {
                        while (loopSend)
                        {
                            m_tcpClient.Send(tbx_msg3.Text);
                            Thread.Sleep(m_tcpClient.loopSendSpan);
                        }
                    });
                    th.IsBackground = true;
                    th.Start();
                }
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

    }
}
