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

namespace VM_Pro
{
    public partial class Frm_Par : UIForm
    {
        public Frm_Par()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否正在运行
        /// </summary>
        internal bool isRunning = false;
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
        internal static MatchTool matchTool;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Par _instance;
        internal static Frm_Par Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Par();
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
            matchTool = (MatchTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;
            Instance.Show();
            Application.DoEvents();
            hasShown = true;

            if (((MatchTool.ToolPar)matchTool.参数).输入.图像 == null)
                Instance.hWindow_Final1.ClearWindow();
            else
                Instance.hWindow_Final1.HobjectToHimage(((MatchTool.ToolPar)matchTool.参数).输入.图像);

            if (matchTool.searchRegionType != RegionType.整幅图像 && matchTool.searchRegionType != RegionType.任意 && matchTool.searchRegionType != RegionType.输入区域)
                Instance.hWindow_Final1.viewWindow.displayROI(matchTool.L_regions);

            Instance.nud_matchScore.Value = matchTool.angleRange;

            Instance.Activate();
            Instance.btn_runTool.Focus();
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
            matchTool.ResetTool();
        }
        private void Frm_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

        private void 适应窗体toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hWindow_Final1.DispImageFit();
        }
        private void 图像信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hWindow_Final1.showStatusBar();
        }

        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            matchTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }
        private void btn_runTool_Click(object sender, EventArgs e)
        {
            if (!isRunning)
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

                    isRunning = true;
                    matchTool.Run();
                    isRunning = false;

                    Thread.Sleep(100);
                    Frm_Loading.Instance.Hide();
                });
                th.IsBackground = true;
                th.Start();
            }
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
        private void Frm_MatchTool_ExtendBoxClick(object sender, EventArgs e)
        {
            Instance.TopMost = !Instance.TopMost;

            if (Instance.TopMost)
                Instance.ExtendSymbol = 61475;
            else
                Instance.ExtendSymbol = 61758;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            if (MatchTool.isDrawing)
            {
                MatchTool.isDrawing = false;
                HalconLib.HIOCancelDraw();
                Frm_MatchTool.Instance.hWindow_Final1.DrawModel = false;
                Frm_MatchTool.Instance.hWindow_Final1.ContextMenuStrip = Frm_MatchTool.Instance.uiContextMenuStrip1;
            }

            this.Close();
        }

        private void nud_matchScore_ValueChanged(double value)
        {
            matchTool.angleRange = (int)value;
        }
    }
}
