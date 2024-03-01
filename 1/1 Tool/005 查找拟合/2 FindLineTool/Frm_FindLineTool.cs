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
    public partial class Frm_FindLineTool : UIForm
    {
        public Frm_FindLineTool()
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
        internal static FindLineTool findLineTool;
        /// <summary>
        /// 搜索区域
        /// </summary>
        internal static List<ViewWindow.Model.ROI> L_regions = new List<ViewWindow.Model.ROI>();
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_FindLineTool _instance;
        internal static Frm_FindLineTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_FindLineTool();
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
            findLineTool = (FindLineTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;
            Instance.Show();
            Application.DoEvents();
            hasShown = true;

            findLineTool.UpdateInput();

            HTuple newExpectLineStartRow, newExpectLineStartCol, newExpectLineEndRow, newExpectLineEndCol, newExpectCenterRow = 0, newExpectCenterCol = 0;
            if (((FindLineTool.ToolPar)findLineTool.参数).输入.跟随 != null && ((FindLineTool.ToolPar)findLineTool.参数).输入.跟随.Count != 0)
            {
                HTuple _homMat2D;
                HOperatorSet.VectorAngleToRigid(findLineTool.followedPose[0].XY.X, findLineTool.followedPose[0].XY.Y, findLineTool.followedPose[0].U, ((FindLineTool.ToolPar)findLineTool.参数).输入.跟随[0].XY.X, ((FindLineTool.ToolPar)findLineTool.参数).输入.跟随[0].XY.Y, ((FindLineTool.ToolPar)findLineTool.参数).输入.跟随[0].U, out _homMat2D);
                //对预期线的起始点做放射变换
                HTuple temp1, temp2, temp3, temp4, temp5, temp6;
                HOperatorSet.AffineTransPixel(_homMat2D, (HTuple)findLineTool.L_regions[0].getRowsData()[7], (HTuple)findLineTool.L_regions[0].getColsData()[7], out temp1, out temp2);
                HOperatorSet.AffineTransPixel(_homMat2D, (HTuple)findLineTool.L_regions[0].getRowsData()[9], (HTuple)findLineTool.L_regions[0].getColsData()[9], out temp3, out temp4);
                HOperatorSet.AffineTransPixel(_homMat2D, (HTuple)findLineTool.L_regions[0].getRowsData()[4], (HTuple)findLineTool.L_regions[0].getColsData()[4], out temp5, out temp6);

                newExpectLineStartRow = temp1;
                newExpectLineStartCol = temp2;
                newExpectLineEndRow = temp3;
                newExpectLineEndCol = temp4;
                newExpectCenterRow = temp5;
                newExpectCenterCol = temp6;
            }
            else
            {
                newExpectLineStartRow = findLineTool.L_regions[0].getRowsData()[7];
                newExpectLineStartCol = findLineTool.L_regions[0].getColsData()[7];
                newExpectLineEndRow = findLineTool.L_regions[0].getRowsData()[9];
                newExpectLineEndCol = findLineTool.L_regions[0].getColsData()[9];
            }

            if (((FindLineTool.ToolPar)findLineTool.参数).输入.图像 == null)
            {
                Instance.hWindow_Final1.ClearWindow();
            }
            else
            {
                HTuple width, height;
                HOperatorSet.GetImageSize(((FindLineTool.ToolPar)findLineTool.参数).输入.图像, out width, out height);
                HOperatorSet.SetPart(Frm_FindLineTool.Instance.hWindow_Final1.HWindowHalconID, 0, 0, height - 1, width - 1);
                Frm_FindLineTool.Instance.hWindow_Final1.ClearWindow();
                Instance.hWindow_Final1.HobjectToHimage(((FindLineTool.ToolPar)findLineTool.参数).输入.图像);
                if (findLineTool.L_regions.Count == 0)
                {
                    Frm_FindLineTool.Instance.hWindow_Final1.viewWindow.genRect2(newExpectCenterRow, newExpectCenterCol, findLineTool.L_regions[0].getModelData()[2], findLineTool.L_regions[0].getModelData()[3], findLineTool.L_regions[0].getModelData()[4], ref findLineTool.L_regions);
                    Frm_FindLineTool.L_regions = findLineTool.L_regions;
                }
                else
                {
                    HTuple temp1, temp2, temp3;
                    newExpectCenterRow = findLineTool.L_regions[0].getModelData()[0];
                    newExpectCenterCol = findLineTool.L_regions[0].getModelData()[1];
                    temp1 = findLineTool.L_regions[0].getModelData()[2];
                    temp2 = findLineTool.L_regions[0].getModelData()[3];
                    temp3 = findLineTool.L_regions[0].getModelData()[4];
                    findLineTool.L_regions.Clear();
                    Frm_FindLineTool.Instance.hWindow_Final1.viewWindow.genRect2(newExpectCenterRow, newExpectCenterCol, temp1, temp2, temp3, ref findLineTool.L_regions);
                    Frm_FindLineTool.L_regions = findLineTool.L_regions;
                }
            }

            if (((FindLineTool.ToolPar)findLineTool.参数).输入.跟随 != null && ((FindLineTool.ToolPar)findLineTool.参数).输入.跟随.Count > 0)
            {
                findLineTool.followedPose.Clear();
                XYU xyu = new XYU();
                xyu.XY.X = ((FindLineTool.ToolPar)findLineTool.参数).输入.跟随[0].XY.X;
                xyu.XY.Y = ((FindLineTool.ToolPar)findLineTool.参数).输入.跟随[0].XY.Y;
                xyu.U = ((FindLineTool.ToolPar)findLineTool.参数).输入.跟随[0].U;
                findLineTool.followedPose.Add(xyu);
            }

            Instance.ckb_taskFailKeepRun.Checked = findLineTool.taskFailKeepRun;
            Instance.tkb_threshold.Value = findLineTool.threshold;
            Instance.tkb_caliperNum.Value = findLineTool.cliperNum;
            Instance.tkb_ignorePointNum.Value = findLineTool.ignorePointNum;
            Instance.tkb_caliperLength.Value = findLineTool.caliperLength;
            Instance.tkb_caliperWidth.Value = findLineTool.caliperWidth;
            Instance.tkb_minScore.Value = (int)(findLineTool.minScore * 100);
            Instance.cbx_polarity.Text = (findLineTool.polarity == "positive" ? "从明到暗" : "从暗到明");
            Instance.ckb_showFeature.Checked = findLineTool.showFeature;
            switch (findLineTool.edgeSelect)
            {
                case "first":
                    Instance.cbx_edgeSelect.SelectedIndex = 0;
                    break;
                case "last":
                    Instance.cbx_edgeSelect.SelectedIndex = 1;
                    break;
                case "all":
                    Instance.cbx_edgeSelect.SelectedIndex = 2;
                    break;
            }

            Instance.nud_threshold.Value = findLineTool.threshold;
            Instance.nud_caliperNum.Value = findLineTool.cliperNum;
            Instance.nud_ignorePointNum.Value = findLineTool.ignorePointNum;
            Instance.nud_caliperLength.Value = findLineTool.caliperLength;
            Instance.nud_caliperWidth.Value = findLineTool.caliperWidth;
            Instance.nud_minScore.Value = findLineTool.minScore;

            Instance.ckb_showCaliper.Checked = findLineTool.showCaliper;
            Instance.ckb_showFeature.Checked = findLineTool.showFeature;
            Instance.ckb_showLine.Checked = findLineTool.showLine;

            Thread th1 = new Thread(() =>
            {
                findLineTool.Run();
            });
            th1.IsBackground = true;
            th1.Start();

            Frm_FindLineTool.Instance.hWindow_Final1.viewWindow.displayROI(findLineTool.L_regions);

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
            findLineTool.ShowContour(true);
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
            findLineTool.ResetTool();
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

            findLineTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
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

                findLineTool.Run();

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
        private void Frm_FindLineTool_ExtendBoxClick(object sender, EventArgs e)
        {
            Instance.TopMost = !Instance.TopMost;

            if (Instance.TopMost)
                Instance.ExtendSymbol = 61475;
            else
                Instance.ExtendSymbol = 61758;
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
            nud_minScore.Value = (double)tkb_minScore.Value/100;
        }

        private void nud_threshold_ValueChanged(double value)
        {
            findLineTool.threshold = (int)value;
            tkb_threshold.Value = (int)value;
            findLineTool.ShowContour(false, true);
        }
        private void nud_caliperNum_ValueChanged(double value)
        {
            findLineTool.cliperNum = (int)value;
            tkb_caliperNum.Value = (int)value;
            findLineTool.ShowContour(false, true);
        }
        private void nud_ignorePointNum_ValueChanged(double value)
        {
            findLineTool.ignorePointNum = (int)value;
            tkb_ignorePointNum.Value = (int)value;
            findLineTool.ShowContour(false, true);
        }
        private void nud_caliperLength_ValueChanged(double value)
        {
            findLineTool.caliperLength = (int)value;
            tkb_caliperLength.Value = (int)value;
            findLineTool.ShowContour(false, true);
        }
        private void nud_caliperWidth_ValueChanged(double value)
        {
            findLineTool.caliperWidth = (int)value;
            tkb_caliperWidth.Value = (int)value;
            findLineTool.ShowContour(false, true);
        }
        private void nud_minScore_ValueChanged(double value)
        {
            findLineTool.minScore = value;
            tkb_minScore.Value = (int)(value*100);
        }

        private void cbx_polarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            findLineTool.polarity = (cbx_polarity.SelectedIndex == 0 ? "positive" : "negative");
        }
        private void cbx_edgeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbx_edgeSelect.SelectedIndex)
            {
                case 0:
                    findLineTool.edgeSelect = "first";
                    break;
                case 1:
                    findLineTool.edgeSelect = "last";
                    break;
                case 2:
                    findLineTool.edgeSelect = "all";
                    break;
            }
            findLineTool.ShowContour(false, true);
        }
        private void btn_switchPolarity_Click(object sender, EventArgs e)
        {
            if (cbx_polarity.Text == "从明到暗")
                cbx_polarity.SelectedIndex = 1;
            else
                cbx_polarity.SelectedIndex = 0;

            findLineTool.polarity = (cbx_polarity.SelectedIndex == 0 ? "positive" : "negative");
            findLineTool.ShowContour(false);
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

            findLineTool.showCaliper = ckb_showCaliper.Checked;
            findLineTool.Run(true);
        }
        private void ckb_showFeature_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            findLineTool.showFeature = ckb_showFeature.Checked;
            findLineTool.Run(true);
        }
        private void ckb_showLine_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            findLineTool.showLine = ckb_showLine.Checked;
            findLineTool.Run(true);
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
