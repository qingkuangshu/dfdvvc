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
    public partial class Frm_TCPServer : Form
    {
        public Frm_TCPServer()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_TCPServer _instance;
        internal static Frm_TCPServer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_TCPServer();
                return _instance;
            }
        }
        /// <summary>
        /// 服务端实例
        /// </summary>
        internal static TCPSever m_tcpSever = null;
        ///循环发送
        internal static bool loopSend = false;


        /// <summary>
        /// 显示参数到界面
        /// </summary>
        /// <param name="tcpClient"></param>
        internal static void ShowPar(ServiceBase serviceBase)
        {
            if (Frm_Service.curForm != CurForm.TCPSever)
            {
                Frm_Service.curForm = CurForm.TCPSever;

                Frm_Service.Instance.pnl_seviceBox.Controls.Clear();
                Instance.TopLevel = false;
                Instance.Parent = Frm_Service.Instance.pnl_seviceBox;
                Instance.Dock = DockStyle.Fill;
                Instance.Show();
            }

            m_tcpSever = (TCPSever)serviceBase;

            //更新参数
            if (TCPSever.FindSeverByName(serviceBase.name).listend)
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "已监听";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
            }
            else
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "未监听";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
            }

            Instance.cbx_IP.Text = m_tcpSever.severIP;
            Instance.tbx_Port.Text = m_tcpSever.severPort.ToString();
            Instance.ckb_autoListenAfterStart.Checked = m_tcpSever.autoConnectAfterStart;
            Instance.ckb_hexMode.Checked = m_tcpSever.hexMode;
            Instance.ckb_loopSend.Checked = m_tcpSever.loopSend;
            Instance.tbx_loopSendSpan.Text = m_tcpSever.loopSendSpan.ToString();

            Instance.tbx_msg1.Text = m_tcpSever.sendStr1;
            Instance.tbx_msg2.Text = m_tcpSever.sendStr2;
            Instance.tbx_msg3.Text = m_tcpSever.sendStr3;

            Instance.tbx_log.Clear();

            //更新已连接客户端列表
            Instance.tvw_clientList.Nodes.Clear();
            foreach (KeyValuePair<string, string> item in m_tcpSever.D_clientIPAndName)
            {
                bool exist = false;
                int index = 0;
                for (int i = 0; i < TCPSever.FindSeverByName(m_tcpSever.name).L_clientItem.Count; i++)
                {
                    if (TCPSever.FindSeverByName(m_tcpSever.name).L_clientItem[i].name == item.Value)
                    {
                        exist = true;
                        index = i;
                        break;
                    }
                }

                if (exist)
                {
                    TreeNode treeNode = Instance.tvw_clientList.Nodes.Add(item.Value + "  " + TCPSever.FindSeverByName(m_tcpSever.name).L_clientItem[index].IP);
                    Instance.tvw_clientList.SetNodeTipsText(treeNode, " ", Color.Green, Color.Green);
                    treeNode.Tag = "T";
                }
                else
                {
                    TreeNode treeNode = Instance.tvw_clientList.Nodes.Add(item.Value + "  " + item.Key);
                    Instance.tvw_clientList.SetNodeTipsText(treeNode, " ", Color.Red, Color.Red);
                    treeNode.Tag = "F";
                }
            }

            //更新连接状态
            Instance.btn_listen.Text = (TCPSever.FindSeverByName(m_tcpSever.name).listend ? "停止监听" : "开始监听");
            Instance.cbx_IP.Enabled = (TCPSever.FindSeverByName(m_tcpSever.name).listend ? false : true);
            Instance.tbx_Port.Enabled = (TCPSever.FindSeverByName(m_tcpSever.name).listend ? false : true);

            if (TCPSever.FindSeverByName(m_tcpSever.name).L_clientItem.Count > 0)
                Instance.tvw_clientList.SelectedNode = Instance.tvw_clientList.Nodes[0];

            if (Instance.tvw_clientList.SelectedNode != null)
            {
                Instance.lbl_receiveNum.Text = TCPSever.FindClientItemByName(m_tcpSever.name, Regex.Split(Instance.tvw_clientList.SelectedNode.Text, "  ")[0]).receiveNum.ToString();
                Instance.lbl_sendNum.Text = TCPSever.FindClientItemByName(m_tcpSever.name, Regex.Split(Instance.tvw_clientList.SelectedNode.Text, "  ")[0]).sendNum.ToString();
            }
        }
        /// <summary>
        /// 远程客户端命名查重
        /// </summary>
        /// <param name="jobName">远程客户端名</param>
        /// <returns>是否已存在</returns>
        internal static bool CheckExist(string clientName)
        {
            for (int i = 0; i < TCPSever.FindSeverByName(m_tcpSever.name).L_clientItem.Count; i++)
            {
                if (TCPSever.FindSeverByName(m_tcpSever.name).L_clientItem[i].name == clientName)
                    return true;
            }
            return false;
        }


        private void Frm_TCPServer_Load(object sender, EventArgs e)
        {
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
            m_tcpSever.severIP = cbx_IP.Text.Trim();
        }
        private void btn_showItem_Click(object sender, EventArgs e)
        {
            cbx_IP.ShowDropDown();
        }
        private void tbx_Port_TextChanged(object sender, EventArgs e)
        {
            try
            {
                m_tcpSever.severPort = Convert.ToInt32(tbx_Port.Text.Trim());
            }
            catch { }
        }
        private void btn_listen_Click(object sender, EventArgs e)
        {
            if (TCPSever.FindSeverByName(m_tcpSever.name).listend)
                m_tcpSever.Disconect();
            else
                m_tcpSever.Connect();

            if (TCPSever.FindSeverByName(m_tcpSever.name).listend)
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "已监听";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
                btn_listen.Text = "停止监听";

                cbx_IP.Enabled = false;
                tbx_Port.Enabled = false;
            }
            else
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "未监听";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
                btn_listen.Text = "开始监听";

                cbx_IP.Enabled = true;
                tbx_Port.Enabled = true;
            }

            //更新远程客户端连接状态
            for (int i = 0; i < tvw_clientList.Nodes.Count; i++)
            {
                Instance.tvw_clientList.SetNodeTipsText(tvw_clientList.Nodes[i], " ", Color.Red, Color.Red);
                tvw_clientList.Nodes[i].Tag = "F";
            }
        }
        private void ckb_autoListenAfterStart_CheckedChanged(object sender, EventArgs e)
        {
            m_tcpSever.autoConnectAfterStart = ckb_autoListenAfterStart.Checked;
        }
        private void ckb_hexMode_CheckedChanged(object sender, EventArgs e)
        {
            m_tcpSever.hexMode = ckb_hexMode.Checked;
        }
        private void ckb_loopSend_CheckedChanged(object sender, EventArgs e)
        {
            m_tcpSever.loopSend = ckb_loopSend.Checked;

            tbx_loopSendSpan.Visible = m_tcpSever.loopSend;
            uiLabel7.Visible = m_tcpSever.loopSend;
        }
        private void tbx_loopSendSpan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                m_tcpSever.loopSendSpan = Convert.ToInt16(tbx_loopSendSpan.Text.Trim());
            }
            catch { }
        }
        private void tvw_clientList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tbx_log.Clear();

            //检查是否已连接
            bool exist = false;
            for (int i = 0; i < TCPSever.FindSeverByName(m_tcpSever.name).L_clientItem.Count; i++)
            {
                if (TCPSever.FindSeverByName(m_tcpSever.name).L_clientItem[i].name == Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0])
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
                return;

            for (int i = 0; i < TCPSever.FindClientItemByName(m_tcpSever.name, Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0]).L_historyMsg.Count; i++)
            {
                if (i != 0)
                    tbx_log.AppendText(Environment.NewLine);

                tbx_log.SelectionStart = Frm_TCPServer.Instance.tbx_log.Text.Length;
                tbx_log.SelectionLength = 0;
                if (TCPSever.FindClientItemByName(m_tcpSever.name, Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0]).L_historyMsg[i].Substring(11, 3) == "已接收")        //收到的消息显示黑色
                    tbx_log.SelectionColor = Color.FromArgb(48, 48, 48);
                else
                    tbx_log.SelectionColor = Color.Green;
                tbx_log.AppendText(TCPSever.FindClientItemByName(m_tcpSever.name, Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0]).L_historyMsg[i]);                     //发送的消息显示绿色
            }
            tbx_log.ScrollToCaret();

            Instance.lbl_receiveNum.Text = TCPSever.FindClientItemByName(m_tcpSever.name, Regex.Split(Instance.tvw_clientList.SelectedNode.Text, "  ")[0]).receiveNum.ToString();
            Instance.lbl_sendNum.Text = TCPSever.FindClientItemByName(m_tcpSever.name, Regex.Split(Instance.tvw_clientList.SelectedNode.Text, "  ")[0]).sendNum.ToString();
        }

        private void tbx_msg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (((Sunny.UI.UITextBox)sender).Text == string.Empty)
                    return;

                if (TCPSever.FindSeverByName(m_tcpSever.name).L_clientItem.Count == 0)
                {
                    FuncLib.ShowMsg("当前服务端没有客户端连接，不可发送消息", InfoType.Error);
                    return;
                }

                m_tcpSever.Send(tvw_clientList.SelectedNode.Text, ((Sunny.UI.UITextBox)sender).Text);
            }
        }
        private void tbx_msg1_TextChanged(object sender, EventArgs e)
        {
            m_tcpSever.sendStr1 = tbx_msg1.Text;
        }
        private void tbx_msg2_TextChanged(object sender, EventArgs e)
        {
            m_tcpSever.sendStr2 = tbx_msg2.Text;
        }
        private void tbx_msg3_TextChanged(object sender, EventArgs e)
        {
            m_tcpSever.sendStr3 = tbx_msg3.Text;
        }
        private void btn_send1_Click(object sender, EventArgs e)
        {
            if (tbx_msg1.Text == string.Empty)
                return;

            if (TCPSever.FindSeverByName(m_tcpSever.name).L_clientItem.Count == 0)
            {
                FuncLib.ShowMsg("当前服务端没有客户端连接，不可发送消息", InfoType.Error);
                return;
            }

            if (btn_send1.Text == "发送")
            {
                if (!m_tcpSever.loopSend)
                {

                    m_tcpSever.Send(Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0], tbx_msg1.Text);
                }
                else
                {
                    btn_send1.Text = "停止";
                    loopSend = true;
                    Thread th = new Thread(() =>
                    {
                        while (loopSend)
                        {
                            m_tcpSever.Send(Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0], tbx_msg1.Text);
                            Thread.Sleep(m_tcpSever.loopSendSpan);
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

            if (TCPSever.FindSeverByName(m_tcpSever.name).L_clientItem.Count == 0)
            {
                FuncLib.ShowMsg("当前服务端没有客户端连接，不可发送消息", InfoType.Error);
                return;
            }

            if (btn_send2.Text == "发送")
            {
                if (!m_tcpSever.loopSend)
                {

                    m_tcpSever.Send(Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0], tbx_msg2.Text);
                }
                else
                {
                    btn_send2.Text = "停止";
                    loopSend = true;
                    Thread th = new Thread(() =>
                    {
                        while (loopSend)
                        {
                            m_tcpSever.Send(Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0], tbx_msg2.Text);
                            Thread.Sleep(m_tcpSever.loopSendSpan);
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

            if (TCPSever.FindSeverByName(m_tcpSever.name).L_clientItem.Count == 0)
            {
                FuncLib.ShowMsg("当前服务端没有客户端连接，不可发送消息", InfoType.Error);
                return;
            }

            if (btn_send3.Text == "发送")
            {
                if (!m_tcpSever.loopSend)
                {

                    m_tcpSever.Send(Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0], tbx_msg3.Text);
                }
                else
                {
                    btn_send3.Text = "停止";
                    loopSend = true;
                    Thread th = new Thread(() =>
                    {
                        while (loopSend)
                        {
                            m_tcpSever.Send(Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0], tbx_msg3.Text);
                            Thread.Sleep(m_tcpSever.loopSendSpan);
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

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_tcpSever.SetClientName(tvw_clientList.SelectedNode.Text);
        }
        private void 断开连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuncLib.ShowMessageBox("尚未开发，敬请期待！");
        }
        private void 清空记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TCPSever.FindClientItemByName(m_tcpSever.name, Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0]).L_historyMsg.Clear();
            TCPSever.FindClientItemByName(m_tcpSever.name, Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0]).sendNum = 0;
            TCPSever.FindClientItemByName(m_tcpSever.name, Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[0]).receiveNum = 0;
            lbl_receiveNum.Text = "0";
            lbl_sendNum.Text = "0";
            tbx_log.Clear();
        }
        private void 历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuncLib.ShowMessageBox("尚未开发，敬请期待！");
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_tcpSever.D_clientIPAndName.Remove(Regex.Split(tvw_clientList.SelectedNode.Text, "  ")[1]);
            if (tvw_clientList.SelectedNode.Tag.ToString() != "T")
            {
                tvw_clientList.Nodes.Remove(tvw_clientList.SelectedNode);
            }
        }

        private void lnk_clearLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbx_log.Clear();
        }

    }
}
