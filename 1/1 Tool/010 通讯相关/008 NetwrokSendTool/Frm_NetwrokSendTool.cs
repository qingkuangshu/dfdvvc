using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using HalconDotNet;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace VM_Pro
{
    public partial class Frm_NetworkSendTool : UIForm
    {
        public Frm_NetworkSendTool()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体是否已显示
        /// </summary>
        internal static bool hasShown = false;
        /// <summary>
        /// 是否启用事件，也就是不执行本次触发的事件
        /// </summary>
        internal static bool openingForm = false ;
        /// <summary>
        /// 当前工具名
        /// </summary>
        internal static string toolName = string.Empty;
        /// <summary>
        /// 当前工具所属的流程
        /// </summary>
        internal static string taskName = string.Empty;
        /// <summary>
        /// 工具对象
        /// </summary>
        internal static NetworkSendTool networkSendTool;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_NetworkSendTool _instance;
        internal static Frm_NetworkSendTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_NetworkSendTool();
                return _instance;
            }
        }


        /// <summary>
        /// 弹出工具页面
        /// </summary>
        /// <param name="toolBase">工具</param>
        internal static void ShowForm(ToolBase toolBase)
        {
            if (hasShown && taskName == toolBase.taskName && toolName == toolBase.toolName)     //如果当前工具已显示或者最小化了，那就直接显示即可
            {
                Instance.WindowState = FormWindowState.Normal;
                Instance.Activate();
                return;
            }

            openingForm = true;
            Instance.Text = string.Format("{0}    [ {1} . {2} ]", toolBase.toolType, toolBase.taskName, toolBase.toolName);
            networkSendTool = (NetworkSendTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.cbx_ethernetNameList.Items.Clear();
            Instance.cbx_clientList.Items.Clear();
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.TCPIPSever || Project.Instance.L_Service[i].serviceType == ServiceType.TCPIPClient)
                    Instance.cbx_ethernetNameList.Items.Add(Project.Instance.L_Service[i].name);
            }
            
            Instance.ckb_taskFailKeepRun.Checked = networkSendTool.taskFailKeepRun;
            Instance.cbx_ethernetNameList.Text = networkSendTool.ethernetName;
            Instance.cbx_clientList.Text = networkSendTool.clientName;
            Instance.tbx_cmd.Text = networkSendTool.cmdStr;
            Instance.tbx_taskFailCmd.Text = networkSendTool.cmdStrTaskFail;
            if (networkSendTool.endChar == string.Empty)
            {
                Instance.btn_endCharNone.BackColor = Color.Gray;
                Instance.btn_endCharEnter.BackColor = Color.Gainsboro;
            }
            else
            {
                Instance.btn_endCharNone.BackColor = Color.Gainsboro;
                Instance.btn_endCharEnter.BackColor = Color.Gray;
            }
            Instance.ckb_taskFailOtherCmd.Checked = networkSendTool.taskFailOtherCmd;
            Instance.tbx_taskFailCmd.Visible = networkSendTool.taskFailOtherCmd;

            Instance.tbx_taskFailTimeFomat.Text = networkSendTool.timeFomatCmdTaskFail;
            Instance.ckb_taskFailTimeFomat.Checked = networkSendTool.isTaskFailTimeFomat;
            Instance.tbx_taskFailTimeFomat.Visible = networkSendTool.isTaskFailTimeFomat;

            Instance.WindowState = FormWindowState.Normal;
            Instance.Show();
            Application.DoEvents();
            hasShown = true;

            Instance.Activate();
            openingForm = false;
        }


        private void toolStrip1_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }
        private void 保存toolStripButton1_Click(object sender, EventArgs e)
        {
            Scheme.SaveCur();
            FuncLib.ShowMsg("保存当前方案成功", InfoType.Tip);
        }
        private void 复位toolStripButton3_Click(object sender, EventArgs e)
        {
            networkSendTool.ResetTool();
        }
        private void cbx_ethernetNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Frm_NetworkSendTool.openingForm)    //否则Showform会清空列表，触发该事件
                return;
            networkSendTool.ethernetName = cbx_ethernetNameList.Text;

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == networkSendTool.ethernetName)
                {
                    if (Project.Instance.L_Service[i].serviceType == ServiceType.TCPIPSever)
                    {
                        cbx_clientList.Items.Clear();
                        foreach (KeyValuePair<string, string> item in ((TCPSever)Project.Instance.L_Service[i]).D_clientIPAndName)
                        {
                            cbx_clientList.Items.Add(item.Value);
                        }

                        if (cbx_clientList.Items.Count > 0)
                            cbx_clientList.SelectedIndex = 0;
                        break;
                    }
                }
            }
        }
        private void cbx_clientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            networkSendTool.clientName = cbx_clientList.Text;
        }
        private void tbx_cmd_TextChanged(object sender, EventArgs e)
        {
            networkSendTool.cmdStr = tbx_cmd.Text;
        }
        private void tbx_taskFailCmd_TextChanged(object sender, EventArgs e)
        {
            networkSendTool.cmdStrTaskFail = tbx_taskFailCmd.Text;
        }
        private void btn_endCharNone_Click(object sender, EventArgs e)
        {
            networkSendTool.endChar = string.Empty;
            btn_endCharNone.BackColor = Color.Gray;
            btn_endCharEnter.BackColor = Color.Gainsboro;
        }
        private void btn_endCharEnter_Click(object sender, EventArgs e)
        {
            networkSendTool.endChar = "\r\n";
            btn_endCharNone.BackColor = Color.Gainsboro;
            btn_endCharEnter.BackColor = Color.Gray;
        }
        private void ckb_taskFailOtherCmd_Click(object sender, EventArgs e)
        {
            networkSendTool.taskFailOtherCmd = ckb_taskFailOtherCmd.Checked;
            tbx_taskFailCmd.Visible = networkSendTool.taskFailOtherCmd;
        }
        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            networkSendTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }
        private void Frm_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }
        private void Frm_NetworkSendTool_ExtendBoxClick(object sender, EventArgs e)
        {
            Instance.TopMost = !Instance.TopMost;

            if (Instance.TopMost)
                Instance.ExtendSymbol = 61475;
            else
                Instance.ExtendSymbol = 61758;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_TxtLianRu_Click(object sender, EventArgs e)
        {
            FrmBianLiang frm = new FrmBianLiang(toolName);
            frm.TagString = "文本";
            frm.ShowNavNodes(networkSendTool.LianRuToolNames(DataType.String));

            if (frm.ShowDialog() == DialogResult.OK)
            {
                tbx_cmd.Text = FrmBianLiang.currentLianRuInfo;
                UIMessageTip.ShowOk("成功切换文本链入项");
                networkSendTool.UpdateInput();
                tbx_cmd.ReadOnly = true;
                //Thread th1 = new Thread(() =>
                //{
                //    networkSendTool.Run();
                //});
                //th1.IsBackground = true;
                //th1.Start();
                ////更新当前输入项
            }
        }

        private void btn_CancelLianRu_Click(object sender, EventArgs e)
        {
            if (networkSendTool.DelToolIO("文本"))
            {
                tbx_cmd.ReadOnly = false;
                tbx_cmd.Text = "T";
                UIMessageTip.ShowOk("移除当前链入成功");
            }
        }

        private void tbx_taskFailTimeFomat_TextChanged(object sender, EventArgs e)
        {
            networkSendTool.timeFomatCmdTaskFail = tbx_taskFailTimeFomat.Text;
        }

        private void ckb_taskFailTimeFomat_Click(object sender, EventArgs e)
        {
            networkSendTool.isTaskFailTimeFomat = ckb_taskFailTimeFomat.Checked;
            tbx_taskFailTimeFomat.Visible = networkSendTool.isTaskFailTimeFomat;
        }
    }
}
