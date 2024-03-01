using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace VM_Pro
{
    public partial class Frm_DefineTool : UIForm
    {
        public Frm_DefineTool()
        {
            InitializeComponent();
        }

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
        /// 窗体是否已显示
        /// </summary>
        internal static bool hasShown = false;
        /// <summary>
        /// 工具对象
        /// </summary>
        internal static DefineTool defineTool;

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_DefineTool _instance;
        internal static Frm_DefineTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_DefineTool();
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
            defineTool = (DefineTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.ckb_JiEr.Checked = defineTool.I_极耳.CheckEnable;
            Instance.txt_MinArea.Text = defineTool.I_极耳.MinArea.ToString();
            Instance.txt_BeforArea.Text = defineTool.I_极耳.BeforArea.ToString();
            Instance.txt_MaxArea.Text = defineTool.I_极耳.MaxArea.ToString();
            Instance.txt_NGNum.Text = defineTool.I_极耳.NG.ToString();

            Instance.WindowState = FormWindowState.Normal;
            Instance.Show();
            Instance.ckb_taskFailKeepRun.Checked = defineTool.taskFailKeepRun;

            Application.DoEvents();
            hasShown = true;
            openingForm = false;
        }

        private void Frm_DefineTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btn_runTool_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                this.Invoke(new Action(() =>
                {
                    Frm_Loading.Instance.lbl_title.Text = "拼命加载中";
                    Frm_Loading.Instance.TopLevel = true;
                    Frm_Loading.Instance.TopMost = true;
                    Frm_Loading.Instance.Show();
                }));

                defineTool.Run();

                Thread.Sleep(100);
                Frm_Loading.Instance.Hide();
            });
            th.IsBackground = true;
            th.Start();
        }

        private void btn_runTask_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Task.FindTaskByName(taskName).Run();
            });
            th.IsBackground = true;
            th.Start();
        }

        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_DefineTool.openingForm)
                return;
            defineTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }

        private void ckb_JiEr_Click(object sender, EventArgs e)
        {
            defineTool.I_极耳.CheckEnable = ckb_JiEr.Checked;
        }

        private void txt_MinArea_TextChanged(object sender, EventArgs e)
        {
            defineTool.I_极耳.MinArea = Convert.ToDouble(txt_MinArea.Text.Trim());
        }

        private void txt_MaxArea_TextChanged(object sender, EventArgs e)
        {
            defineTool.I_极耳.MaxArea = Convert.ToDouble(txt_MaxArea.Text.Trim());

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FuncLib.ShowTooLHelp(defineTool.toolType);
        }
    }
}
