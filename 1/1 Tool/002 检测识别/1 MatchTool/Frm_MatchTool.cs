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
    public partial class Frm_MatchTool : UIForm
    {
        public Frm_MatchTool()
        {
            InitializeComponent();
            hWindow_Final1.hWindowControl.MouseUp += Hwindow_MouseUp;
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
        /// 搜索区域
        /// </summary>
        internal static List<ViewWindow.Model.ROI> L_regions = new List<ViewWindow.Model.ROI>();
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_MatchTool _instance;
        internal static Frm_MatchTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_MatchTool();
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

            matchTool.UpdateInput();

            if (((MatchTool.ToolPar)matchTool.参数).输入.图像 == null)
                Instance.hWindow_Final1.ClearWindow();
            else
                Instance.hWindow_Final1.HobjectToHimage(((MatchTool.ToolPar)matchTool.参数).输入.图像);

            if (matchTool.searchRegionType != RegionType.整幅图像 && matchTool.searchRegionType != RegionType.任意 && matchTool.searchRegionType != RegionType.输入区域)
            {
                Instance.hWindow_Final1.viewWindow.displayROI(matchTool.L_regions);
                L_regions = matchTool.L_regions;
            }

            Instance.ckb_taskFailKeepRun.Checked = matchTool.taskFailKeepRun;
            Instance.rdo_basedGray.Checked = (matchTool.matchMode == MatchMode.BasedGray);
            Instance.rdo_addTemplateRegion.Checked = true;
            Instance.nud_matchScore.Value = matchTool.minScore;
            Instance.nud_matchNum.Value = matchTool.matchNum;
            Instance.cbx_searchRegionType.SelectedIndex = (int)matchTool.searchRegionType;
            Instance.ckb_safetyRange.Checked = matchTool.enableSafetyRange;
            Instance.nud_safetyRange.Value = matchTool.safetyRange;
            Instance.ckb_showTemplateContour.Checked = matchTool.showTemplate;
            Instance.ckb_showFeature.Checked = matchTool.showFeature;
            Instance.ckb_showSearchRegion.Checked = matchTool.showSearchRegion;
            Instance.ckb_showCross.Checked = matchTool.showCross;
            Instance.ckb_showIndex.Checked = matchTool.showIndex;
            Instance.ckb_showScore.Checked = matchTool.showScore;
            Instance.cbx_sortMode.SelectedIndex = (int)matchTool.sortMode;
            if (matchTool.enableSafetyRange)
            {
                Instance.label3.Visible = true;
                Instance.nud_safetyRange.Visible = true;
                Instance.btn_updateControlRegion.Visible = true;
            }
            else
            {
                Instance.label3.Visible = false;
                Instance.nud_safetyRange.Visible = false;
                Instance.btn_updateControlRegion.Visible = false;
            }

            matchTool.ShowTemplateAtSmallWindow();

            Thread th1 = new Thread(() =>
            {
                matchTool.Run();
            });
            th1.IsBackground = true;
            th1.Start();

            //功能启用
            if (!Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                Instance.ckb_safetyRange.Enabled = false;
                Instance.nud_safetyRange.Enabled = false;
            }
            else
            {
                Instance.ckb_safetyRange.Enabled = true;
                Instance.nud_safetyRange.Enabled = true;
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
        private void btn_resetTemplate_Click(object sender, EventArgs e)
        {
            if (MatchTool.isDrawing)
            {
                MatchTool.isDrawing = false;
                HalconLib.HIOCancelDraw();
                Frm_MatchTool.Instance.hWindow_Final1.DrawModel = false;
                Frm_MatchTool.Instance.hWindow_Final1.ContextMenuStrip = Frm_MatchTool.Instance.uiContextMenuStrip1;
            }

            hWindow_Final1.ClearWindow();
            HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
            hWindow_Final1.HobjectToHimage(((MatchTool.ToolPar)matchTool.参数).输入.图像);

            //清除模板信息
            matchTool.templateCreated = false;
            matchTool.templateRegion = null;
            matchTool.templateImage = null;

            //移除模板
            if (matchTool.templateCreated)
            {
                if (matchTool.matchMode == MatchMode.BasedShape)
                    HOperatorSet.ClearShapeModel(matchTool.FindModelHandle());
                else
                    HOperatorSet.ClearNccModel(matchTool.FindModelHandle());
            }
            matchTool.RemoveModelHandle();

            dgv_result.Rows.Clear();
            rdo_addTemplateRegion.Checked = true;
        }
        private void btn_studyTemplate_Click(object sender, EventArgs e)
        {
            if (matchTool.templateRegion == null)
            {
                lbl_toolTip.ForeColor = Color.Red;
                lbl_toolTip.Text = "训练失败，请先绘制模板区域";
                return;
            }

            if (MatchTool.isDrawing)
            {
                lbl_toolTip.ForeColor = Color.Red;
                lbl_toolTip.Text = "训练失败，请先完成模板区域绘制";
                return;
            }

            Thread th = new Thread(() =>
            {
                btn_studyTemplate.Enabled = false;
                matchTool.CreateTemplate();
                btn_studyTemplate.Enabled = true;

                //自动移动搜索框中心
                HTuple row, col, area;
                HOperatorSet.AreaCenter(matchTool.templateRegion, out area, out row, out col);
                if (row.Length <= 0 || col.Length <= 0)
                {
                    btn_resetTemplate_Click(null, null);    //复位，清除模板区域
                    Frm_Loading.Instance.Hide();
                    return;
                }
                switch (matchTool.searchRegionType)
                {
                    case RegionType.矩形:
                        HTuple temp = Frm_MatchTool.L_regions[0].getModelData();
                        HTuple height = temp[2] - temp[0];
                        HTuple width = temp[3] - temp[1];

                        Frm_MatchTool.L_regions.Clear();
                        Frm_MatchTool.Instance.hWindow_Final1.viewWindow.genRect1(row - height / 2, col - width / 2, row + height / 2, col + width / 2, ref Frm_MatchTool.L_regions);
                        break;
                    case RegionType.仿射矩形:
                        Frm_MatchTool.L_regions.Clear();
                        Frm_MatchTool.Instance.hWindow_Final1.viewWindow.genRect2(row, col, 0, 300.0, 200.0, ref Frm_MatchTool.L_regions);
                        break;
                    case RegionType.圆:
                        Frm_MatchTool.L_regions.Clear();
                        Frm_MatchTool.Instance.hWindow_Final1.viewWindow.genCircle(row, col, 200.0, ref Frm_MatchTool.L_regions);
                        break;
                }
                Frm_MatchTool.Instance.hWindow_Final1.HobjectToHimage(((MatchTool.ToolPar)matchTool.参数).输入.图像);
                Frm_MatchTool.Instance.hWindow_Final1.viewWindow.displayROI(matchTool.L_regions);

                btn_runTool_Click(null, null);
                Frm_Loading.Instance.Hide();
            });
            th.IsBackground = true;
            th.Start();

            Frm_Loading.Instance.lbl_title.Text = "拼命加载中";
            Frm_Loading.Instance.TopLevel = true;
            Frm_Loading.Instance.TopMost = true;
            Frm_Loading.Instance.ShowDialog();
        }
        private void btn_morePar_Click(object sender, EventArgs e)
        {
            Frm_Par.ShowForm(matchTool);
        }
        private void btn_resetOrigion_Click(object sender, EventArgs e)
        {
            HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);

            HTuple row, col, area, angle;
            HOperatorSet.AreaCenter(matchTool.templateRegion, out area, out row, out col);
            HOperatorSet.OrientationRegion(matchTool.templateRegion, out angle);
            if (matchTool.matchMode == MatchMode.BasedGray)
                HOperatorSet.SetNccModelOrigin(matchTool.FindModelHandle(), row, col);
            else
                HOperatorSet.SetShapeModelOrigin(matchTool.FindModelHandle(), row, col);
            matchTool.firstTemplateCenter = new XY(row, col);

            HTuple row1, col1, row2, col2;
            HOperatorSet.SmallestRectangle1(matchTool.templateRegion, out row1, out col1, out row2, out col2);
            HObject cross;
            HOperatorSet.GenCrossContourXld(out cross, row, col, (row2 - row1) / 20, 0);
            HOperatorSet.GenRegionContourXld(cross, out cross, "margin");
            HOperatorSet.MoveRegion(cross, out cross, -(row1 - 20), -(col1 - 20));
            HOperatorSet.SetDraw(Instance.hWindowControl1.HalconWindow, "fill");
            HOperatorSet.DispObj(cross, Frm_MatchTool.Instance.hWindowControl1.HalconWindow);


            matchTool.firstTemplateCenter = new XY(row, col);
            HOperatorSet.SetNccModelOrigin(matchTool.FindModelHandle(), 0, 0);

            matchTool.ShowTemplateAtSmallWindow();

            btn_runTool_Click(null, null);
        }
        private void rdo_basedGray_Click(object sender, EventArgs e)
        {
            matchTool.matchMode = MatchMode.BasedGray;
        }
        private void rdo_baseContour_Click(object sender, EventArgs e)
        {
            matchTool.matchMode = MatchMode.BasedShape;
        }
        private void btn_drawRectangle1_Click(object sender, EventArgs e)
        {
            matchTool.DrawTemplateRegion(RegionType.矩形);
        }
        private void btn_drawRectangle2_Click(object sender, EventArgs e)
        {
            matchTool.DrawTemplateRegion(RegionType.仿射矩形);
        }
        private void btn_drawCircle_Click(object sender, EventArgs e)
        {
            matchTool.DrawTemplateRegion(RegionType.圆);
        }
        private void btn_drawEllipse_Click(object sender, EventArgs e)
        {
            matchTool.DrawTemplateRegion(RegionType.椭圆);
        }
        private void btn_drawRing_Click(object sender, EventArgs e)
        {
            FuncLib.ShowMessageBox("尚未开发，敬请期待！");
        }
        private void btn_drawAny_Click(object sender, EventArgs e)
        {
            matchTool.DrawTemplateRegion(RegionType.任意);
        }
        private void nud_matchScore_ValueChanged(double value)
        {
            if (openingForm)
                return;

            matchTool.minScore = value;
        }
        private void nud_matchNum_ValueChanged(double value)
        {
            if (openingForm)
                return;

            matchTool.matchNum = (int)value;
        }
        private void cbx_searchRegionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            matchTool.SwitchSearchRegion((RegionType)cbx_searchRegionType.SelectedIndex);
        }
        private void ckb_safetyRange_Click(object sender, EventArgs e)
        {
            matchTool.enableSafetyRange = ckb_safetyRange.Checked;
            if (matchTool.enableSafetyRange)
            {
                Instance.label3.Visible = true;
                Instance.nud_safetyRange.Visible = true;
                Instance.btn_updateControlRegion.Visible = true;
            }
            else
            {
                Instance.label3.Visible = false;
                Instance.nud_safetyRange.Visible = false;
                Instance.btn_updateControlRegion.Visible = false;
            }

            HOperatorSet.GenEmptyRegion(out matchTool.safetyRegion);
            for (int i = 0; i < matchTool.matchNum; i++)
            {
                HObject tempRegion;
                HOperatorSet.GenRectangle2(out tempRegion, ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].XY.X, ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].XY.Y, 0, matchTool.safetyRange, matchTool.safetyRange);
                HOperatorSet.Union2(matchTool.safetyRegion, tempRegion, out matchTool.safetyRegion);
            }
            HOperatorSet.Connection(matchTool.safetyRegion, out matchTool.safetyRegion);
            HOperatorSet.GenContourRegionXld(matchTool.safetyRegion, out matchTool.safetyRegion, "border");

            btn_runTool_Click(null, null);

            matchTool.L_templateCenter.Clear();
            for (int i = 0; i < ((MatchTool.ToolPar)matchTool.参数).输出.位置.Count; i++)
            {
                XYU xyu = new XYU();
                xyu.XY.X = ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].XY.X;
                xyu.XY.Y = ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].XY.Y;
                xyu.U = ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].U;

                matchTool.L_templateCenter.Add(xyu);
            }
        }
        private void nud_safetyRange_ValueChanged(double value)
        {
            if (openingForm)
                return;

            matchTool.safetyRange = (int)value;

            HOperatorSet.GenEmptyRegion(out matchTool.safetyRegion);
            for (int i = 0; i < matchTool.matchNum; i++)
            {
                HObject tempRegion;
                HOperatorSet.GenRectangle2(out tempRegion, ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].XY.X, ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].XY.Y, 0, matchTool.safetyRange, matchTool.safetyRange);
                HOperatorSet.Union2(matchTool.safetyRegion, tempRegion, out matchTool.safetyRegion);
            }
            HOperatorSet.Connection(matchTool.safetyRegion, out matchTool.safetyRegion);
            HOperatorSet.GenContourRegionXld(matchTool.safetyRegion, out matchTool.safetyRegion, "border");

            btn_runTool_Click(null, null);

            matchTool.L_templateCenter.Clear();
            for (int i = 0; i < ((MatchTool.ToolPar)matchTool.参数).输出.位置.Count; i++)
            {
                XYU xyu = new XYU();
                xyu.XY.X = ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].XY.X;
                xyu.XY.Y = ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].XY.Y;
                xyu.U = ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].U;

                matchTool.L_templateCenter.Add(xyu);
            }
        }
        private void btn_updateControlRegion_Click(object sender, EventArgs e)
        {
            matchTool.safetyRange = (int)nud_safetyRange.Value;

            //检查匹配数量
            if (((MatchTool.ToolPar)matchTool.参数).输出.位置.Count != matchTool.matchNum)
            {
                FuncLib.ShowMessageBox("更新失败！目标未全部匹配", InfoType.Error);
                return;
            }

            HOperatorSet.GenEmptyRegion(out matchTool.safetyRegion);
            for (int i = 0; i < matchTool.matchNum; i++)
            {
                HObject tempRegion;
                HOperatorSet.GenRectangle2(out tempRegion, ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].XY.X, ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].XY.Y, 0, matchTool.safetyRange, matchTool.safetyRange);
                HOperatorSet.Union2(matchTool.safetyRegion, tempRegion, out matchTool.safetyRegion);
            }
            HOperatorSet.Connection(matchTool.safetyRegion, out matchTool.safetyRegion);
            HOperatorSet.GenContourRegionXld(matchTool.safetyRegion, out matchTool.safetyRegion, "border");

            btn_runTool_Click(null, null);

            matchTool.L_templateCenter.Clear();
            for (int i = 0; i < ((MatchTool.ToolPar)matchTool.参数).输出.位置.Count; i++)
            {
                XYU xyu = new XYU();
                xyu.XY.X = ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].XY.X;
                xyu.XY.Y = ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].XY.Y;
                xyu.U = ((MatchTool.ToolPar)matchTool.参数).输出.位置[i].U;

                matchTool.L_templateCenter.Add(xyu);
            }
        }
        private void ckb_showTemplateContour_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            matchTool.showTemplate = ckb_showTemplateContour.Checked;
        }
        private void ckb_showFeature_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            matchTool.showFeature = ckb_showFeature.Checked;
        }
        private void ckb_showSearchRegion_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            matchTool.showSearchRegion = ckb_showSearchRegion.Checked;
        }
        private void ckb_showCross_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            matchTool.showCross = ckb_showCross.Checked;
        }
        private void ckb_showIndex_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            matchTool.showIndex = ckb_showIndex.Checked;
        }
        private void ckb_showScore_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            matchTool.showScore = ckb_showScore.Checked;
        }
        private void cbx_sortMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            matchTool.sortMode = (MatchSortMode)cbx_sortMode.SelectedIndex;
        }
        private void dgv_result_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            Frm_MatchTool.Instance.hWindow_Final1.HobjectToHimage(((MatchTool.ToolPar)matchTool.参数).输入.图像);
            int rowIndex = e.RowIndex;
            string index = Instance.dgv_result.Rows[rowIndex].Cells[0].Value.ToString();
            double score = Convert.ToDouble(Instance.dgv_result.Rows[rowIndex].Cells[1].Value);
            double row = Convert.ToDouble(Instance.dgv_result.Rows[rowIndex].Cells[2].Value);
            double col = Convert.ToDouble(Instance.dgv_result.Rows[rowIndex].Cells[3].Value);
            double angle = Convert.ToDouble(Instance.dgv_result.Rows[rowIndex].Cells[4].Value);

            //显示匹配特征
            if (matchTool.showFeature && matchTool.matchMode == MatchMode.BasedShape)
            {
                HObject countor;
                HOperatorSet.GetShapeModelContours(out countor, matchTool.FindModelHandle(), new HTuple(1));
                HTuple homMat2D;
                HOperatorSet.HomMat2dIdentity(out homMat2D);
                HOperatorSet.HomMat2dTranslate(homMat2D, row, col, out homMat2D);
                HOperatorSet.HomMat2dRotate(homMat2D, angle, row, col, out homMat2D);
                HObject countorAfterTrans;
                HOperatorSet.AffineTransContourXld(countor, out countorAfterTrans, homMat2D);

                Instance.hWindow_Final1.DispObj(countorAfterTrans, "orange");
            }

            if (matchTool.showTemplate)
            {
                HTuple homMat2D;
                HOperatorSet.HomMat2dIdentity(out homMat2D);
                HOperatorSet.HomMat2dTranslate(homMat2D, -matchTool.firstTemplateCenter.X, -matchTool.firstTemplateCenter.Y, out homMat2D);
                HOperatorSet.HomMat2dRotate(homMat2D, angle, 0, 0, out homMat2D);
                HObject templateRegionAfterTrans;
                HOperatorSet.HomMat2dTranslate(homMat2D, row, col, out homMat2D);
                HOperatorSet.AffineTransRegion(matchTool.templateRegion, out templateRegionAfterTrans, homMat2D, "nearest_neighbor");

                Instance.hWindow_Final1.DispObj(templateRegionAfterTrans, "green");
            }

            //显示中心十字架和序号
            if (matchTool.showCross || matchTool.showIndex)
            {
                HTuple area1, row1, col1;
                HOperatorSet.AreaCenter(matchTool.templateRegion, out area1, out row1, out col1);

                HObject cross1;
                HTuple row11, col11, row22, col22;
                HOperatorSet.GetPart(matchTool.GetImageWindow().HWindowHalconID, out row11, out col11, out row22, out col22);
                HOperatorSet.GenCrossContourXld(out cross1, row, col, new HTuple((row22 - row11) / 54.0), new HTuple(angle + matchTool.templateAngle));

                if (matchTool.showCross)
                    Instance.hWindow_Final1.DispObj(cross1, "green");

                if (matchTool.showIndex)
                    HalconLib.DispText(Instance.hWindow_Final1.HWindowHalconID, matchTool.showScore ? string.Format("{0}  {1}", index, score) : index, 12, row - matchTool.firstTemplateCenter.X + row1 + 20, col - matchTool.firstTemplateCenter.Y + col1 + 20, "blue", "false");
            }
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

        private void dgv_result_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FuncLib.ShowTooLHelp(matchTool.toolType);
        }

    }
}
