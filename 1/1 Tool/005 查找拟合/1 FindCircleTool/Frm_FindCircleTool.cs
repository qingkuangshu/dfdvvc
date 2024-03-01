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
    public partial class Frm_FindCircleTool : UIForm
    {
        public Frm_FindCircleTool()
        {
            InitializeComponent();
            hWindow_Final1.hWindowControl.MouseUp += Hwindow_MouseUp;
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
        internal static FindCircleTool findCircleTool;
        /// <summary>
        /// 搜索区域
        /// </summary>
        internal static List<ViewWindow.Model.ROI> L_regions = new List<ViewWindow.Model.ROI>();
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_FindCircleTool _instance;
        internal static Frm_FindCircleTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_FindCircleTool();
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
            findCircleTool = (FindCircleTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;
            Instance.Show();
            Application.DoEvents();
            hasShown = true;

            findCircleTool.UpdateInput();

            HTuple newExpecCircleRow = new HTuple();
            HTuple newExpectCircleCol = new HTuple();
            HTuple newExpectCircleRadius = new HTuple();
            if (((FindCircleTool.ToolPar)findCircleTool.参数).输入.跟随 != null && ((FindCircleTool.ToolPar)findCircleTool.参数).输入.跟随.Count != 0)
            {
                HTuple _homMat2D;
                HOperatorSet.VectorAngleToRigid(findCircleTool.followedPose[0].XY.X, findCircleTool.followedPose[0].XY.Y, findCircleTool.followedPose[0].U, ((FindCircleTool.ToolPar)findCircleTool.参数).输入.跟随[0].XY.X, ((FindCircleTool.ToolPar)findCircleTool.参数).输入.跟随[0].XY.Y, ((FindCircleTool.ToolPar)findCircleTool.参数).输入.跟随[0].U, out _homMat2D);
                //对预期线的起始点做放射变换
                HTuple tempR, tempC;
                HOperatorSet.AffineTransPixel(_homMat2D, (HTuple)findCircleTool.L_regions[0].getModelData()[0], (HTuple)findCircleTool.L_regions[0].getModelData()[1], out tempR, out tempC);
                newExpecCircleRow = tempR;
                newExpectCircleCol = tempC;
                newExpectCircleRadius = findCircleTool.L_regions[0].getModelData()[2].D;
            }
            else
            {
                newExpecCircleRow = findCircleTool.L_regions[0].getModelData()[0];
                newExpectCircleCol = findCircleTool.L_regions[0].getModelData()[1];
                newExpectCircleRadius = findCircleTool.L_regions[0].getModelData()[2];
            }

            if (((FindCircleTool.ToolPar)findCircleTool.参数).输入.图像 == null)
            {
                Instance.hWindow_Final1.ClearWindow();
            }
            else
            {
                HTuple width, height;
                HOperatorSet.GetImageSize(((FindCircleTool.ToolPar)findCircleTool.参数).输入.图像, out width, out height);
                HOperatorSet.SetPart(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID, 0, 0, height - 1, width - 1);
                Frm_FindCircleTool.Instance.hWindow_Final1.ClearWindow();
                Instance.hWindow_Final1.HobjectToHimage(((FindCircleTool.ToolPar)findCircleTool.参数).输入.图像);
                if (findCircleTool.L_regions.Count == 0)
                {
                    Frm_FindCircleTool.Instance.hWindow_Final1.viewWindow.genCircle(newExpecCircleRow, newExpectCircleCol, newExpectCircleRadius, ref findCircleTool.L_regions);
                    Frm_FindCircleTool.L_regions = findCircleTool.L_regions;
                }
                else
                {
                    findCircleTool.L_regions.Clear();
                    Frm_FindCircleTool.Instance.hWindow_Final1.viewWindow.genCircle(newExpecCircleRow, newExpectCircleCol, newExpectCircleRadius, ref findCircleTool.L_regions);
                    Frm_FindCircleTool.L_regions = findCircleTool.L_regions;
                }
            }

            if (((FindCircleTool.ToolPar)findCircleTool.参数).输入.跟随 != null && ((FindCircleTool.ToolPar)findCircleTool.参数).输入.跟随.Count > 0)
            {
                findCircleTool.followedPose.Clear();
                XYU xyu = new XYU();
                xyu.XY.X = ((FindCircleTool.ToolPar)findCircleTool.参数).输入.跟随[0].XY.X;
                xyu.XY.Y = ((FindCircleTool.ToolPar)findCircleTool.参数).输入.跟随[0].XY.Y;
                xyu.U = ((FindCircleTool.ToolPar)findCircleTool.参数).输入.跟随[0].U;
                findCircleTool.followedPose.Add(xyu);
            }

            Instance.ckb_taskFailKeepRun.Checked = findCircleTool.taskFailKeepRun;
            Instance.tkb_threshold.Value = findCircleTool.threshold;
            Instance.tkb_caliperNum.Value = findCircleTool.cliperNum;
            Instance.tkb_ignorePointNum.Value = findCircleTool.ignorePointNum;
            Instance.tkb_caliperLength.Value = findCircleTool.caliperLength;
            Instance.tkb_caliperWidth.Value = findCircleTool.caliperWidth;
            Instance.tkb_minScore.Value = (int)(findCircleTool.minScore * 10);
            Instance.cbx_polarity.Text = (findCircleTool.polarity == "positive" ? "从暗到明" : "从明到暗");
            Instance.ckb_showFeature.Checked = findCircleTool.showFeature;
            switch (findCircleTool.edgeSelect)
            {
                case "first":
                    Frm_FindCircleTool.Instance.cbx_edgeSelect.SelectedIndex = 0;
                    break;
                case "last":
                    Frm_FindCircleTool.Instance.cbx_edgeSelect.SelectedIndex = 1;
                    break;
                case "all":
                    Frm_FindCircleTool.Instance.cbx_edgeSelect.SelectedIndex = 2;
                    break;
            }

            Instance.nud_threshold.Value = findCircleTool.threshold;
            Instance.nud_caliperNum.Value = findCircleTool.cliperNum;
            Instance.nud_ignorePointNum.Value = findCircleTool.ignorePointNum;
            Instance.nud_caliperLength.Value = findCircleTool.caliperLength;
            Instance.nud_caliperWidth.Value = findCircleTool.caliperWidth;
            Instance.nud_minScore.Value = findCircleTool.minScore;

            Instance.ckb_showCaliper.Checked = findCircleTool.showCaliper;
            Instance.ckb_showFeature.Checked = findCircleTool.showFeature;
            Instance.ckb_showCircle.Checked = findCircleTool.showCircle;
            Instance.ckb_showCross.Checked = findCircleTool.showCross;

            Thread th1 = new Thread(() =>
            {
                findCircleTool.Run();
            });
            th1.IsBackground = true;
            th1.Start();

            //功能启用
            if (!Permission.CheckPermission(PermissionGrade.Developer, false))
            {

            }
            else
            {

            }

            Instance.Activate();
            Instance.btn_runTool.Focus();
            openingForm = false;
        }
        private void Hwindow_MouseUp(object sender, MouseEventArgs e)
        {
            int index;
            List<double> data;
            ViewWindow.Model.ROI roi = hWindow_Final1.viewWindow.smallestActiveROI(out data, out index);
            if (index > -1)
            {
                string name = roi.GetType().Name;
                L_regions[index] = roi;
            }
            findCircleTool.ShowContour(true);
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
            findCircleTool.ResetTool();
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
        private void dgv_result_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            findCircleTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }
        private void btn_runTool_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                this.Invoke(new Action(() =>
                {
                    Frm_Loading.Instance.TopLevel = true;
                    Frm_Loading.Instance.TopMost = true;
                    Frm_Loading.Instance.Show();
                }));

                findCircleTool.Run();

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
            this.Close();
        }

        private void tkb_threshold_Scroll(object sender, EventArgs e)
        {
            nud_threshold.Value = tkb_threshold.Value;
        }
        private void tkb_caliperNum_Scroll(object sender, EventArgs e)
        {
            nud_caliperNum.Value = tkb_caliperNum.Value;
        }
        private void tkb_ignorePointNum_Scroll(object sender, EventArgs e)
        {
            nud_ignorePointNum.Value = tkb_ignorePointNum.Value;
        }
        private void tkb_caliperLength_Scroll(object sender, EventArgs e)
        {
            nud_caliperLength.Value = tkb_caliperLength.Value;
        }
        private void tkb_caliperWidth_Scroll(object sender, EventArgs e)
        {
            nud_caliperWidth.Value = tkb_caliperWidth.Value;
        }
        private void tkb_minScore_Scroll(object sender, EventArgs e)
        {
            nud_minScore.Value = tkb_minScore.Value / 10.0;
        }

        private void nud_threshold_ValueChanged(double value)
        {
            findCircleTool.threshold = (int)value;
            tkb_threshold.Value = (int)value;
            findCircleTool.ShowContour(false, true);
        }
        private void nud_caliperNum_ValueChanged(double value)
        {
            findCircleTool.cliperNum = (int)value;
            tkb_caliperNum.Value = (int)value;
            findCircleTool.ShowContour(false, true);
        }
        private void nud_ignorePointNum_ValueChanged(double value)
        {
            findCircleTool.ignorePointNum = (int)value;
            tkb_ignorePointNum.Value = (int)value;
            findCircleTool.ShowContour(false, true);
        }
        private void nud_caliperLength_ValueChanged(double value)
        {
            findCircleTool.caliperLength = (int)value;
            tkb_caliperLength.Value = (int)value;
            findCircleTool.ShowContour(false, true);
        }
        private void nud_caliperWidth_ValueChanged(double value)
        {
            findCircleTool.caliperWidth = (int)value;
            tkb_caliperWidth.Value = (int)value;
            findCircleTool.ShowContour(false, true);
        }
        private void nud_minScore_ValueChanged(double value)
        {
            findCircleTool.minScore = value;
            tkb_minScore.Value = (int)(value*10);
        }

        private void cbx_polarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            findCircleTool.polarity = (cbx_polarity.SelectedIndex == 1 ? "positive" : "negative");
        }
        private void cbx_edgeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            switch (cbx_edgeSelect.SelectedIndex)
            {
                case 0:
                    findCircleTool.edgeSelect = "first";
                    break;
                case 1:
                    findCircleTool.edgeSelect = "last";
                    break;
                case 2:
                    findCircleTool.edgeSelect = "all";
                    break;
            }
            findCircleTool.ShowContour(false, true);
        }
        private void btn_switchPolarity_Click(object sender, EventArgs e)
        {
            if (cbx_polarity.SelectedIndex == 0)
                cbx_polarity.SelectedIndex = 1;
            else
                cbx_polarity.SelectedIndex = 0;

            findCircleTool.polarity = (cbx_polarity.SelectedIndex == 1 ? "positive" : "negative");
            findCircleTool.ShowContour(false);
        }
        private void btn_switchEdge_Click(object sender, EventArgs e)
        {
            switch (cbx_edgeSelect.SelectedIndex)
            {
                case 0:
                    cbx_edgeSelect.SelectedIndex = 1;
                    break;
                case 1:
                    cbx_edgeSelect.SelectedIndex = 2;
                    break;
                case 2:
                    cbx_edgeSelect.SelectedIndex = 0;
                    break;
            }
        }

        private void ckb_showCaliper_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            findCircleTool.showCaliper = ckb_showCaliper.Checked;
            findCircleTool.Run(true);
        }
        private void ckb_showFeature_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            findCircleTool.showFeature = ckb_showFeature.Checked;
            findCircleTool.Run(true);
        }
        private void ckb_showCircle_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            findCircleTool.showCircle = ckb_showCircle.Checked;
            findCircleTool.Run(true);
        }
        private void ckb_showCross_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            findCircleTool.showCross = ckb_showCross.Checked;
            findCircleTool.Run(true);
        }

    }
}
