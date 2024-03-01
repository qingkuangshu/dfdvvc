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
    public partial class Frm_CoordTransTool : UIForm
    {
        public Frm_CoordTransTool()
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
        internal static bool openingForm = false;
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
        internal static CoordTransTool coordTransTool;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_CoordTransTool _instance;
        internal static Frm_CoordTransTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_CoordTransTool();
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
            coordTransTool = (CoordTransTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.cbx_calibFileList.Items.Clear();
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Calibrate)
                    Instance.cbx_calibFileList.Items.Add(Project.Instance.L_Service[i].name);
            }

            Instance.ckb_taskFailKeepRun.Checked = coordTransTool.taskFailKeepRun;
            Instance.cbx_calibFileList.Text = coordTransTool.calibFile;

            //功能启用
            if (!Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                Instance.cbx_calibFileList.Enabled = false;
            }
            else
            {
                Instance.cbx_calibFileList.Enabled = true;
            }

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
            coordTransTool.ResetTool();
        }
        private void cbx_calibFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            coordTransTool.calibFile = cbx_calibFileList.Text;
        }
        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            coordTransTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
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

    }
}
