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
using ViewWindow.Model;

namespace VM_Pro
{
    public partial class Frm_GlueDetectTool : UIForm
    {
        public Frm_GlueDetectTool()
        {
            InitializeComponent();
            hWindow_Final1.hWindowControl.MouseUp += Hwindow_MouseUp;
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
        /// 当前工具所属的流程
        /// </summary>
        internal static string taskName = string.Empty;
        /// <summary>
        /// 当前工具名
        /// </summary>
        internal static string toolName = string.Empty;
        /// <summary>
        /// 工具对象
        /// </summary>
        internal static GlueDetectTool glueDetectTool;
        /// <summary>
        /// 搜索区域
        /// </summary>
        internal static List<ViewWindow.Model.ROI> L_regions = new List<ViewWindow.Model.ROI>();
        /// <summary>
        /// 位置跟随后的圆
        /// </summary>
        internal static List<HTuple> newCircleRow = new List<HTuple>(), newCircleCol = new List<HTuple>(), newCircleRadius = new List<HTuple>();
        /// <summary>
        /// 位置跟随后的矩形
        /// </summary>
        internal static List<HTuple> newRectangle1Row1 = new List<HTuple>(), newRectangle1Col1 = new List<HTuple>(), newRectangle1Row2 = new List<HTuple>(), newRectangle1Col2 = new List<HTuple>();
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_GlueDetectTool _instance;
        internal static Frm_GlueDetectTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_GlueDetectTool();
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
            glueDetectTool = (GlueDetectTool)toolBase;
            Frm_GlueRegion.glueDetectTool = (GlueDetectTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;
            Frm_GlueRegion.taskName = toolBase.taskName;
            Frm_GlueRegion.toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;
            Instance.Show();
            Application.DoEvents();
            hasShown = true;

            glueDetectTool.UpdateInput();

            //显示图像
            Frm_GlueDetectTool.Instance.hWindow_Final1.HobjectToHimage(((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.图像);
            Application.DoEvents();

            //更新跟随
            if (glueDetectTool.searchRegionType != RegionType.输入区域)
            {
                if (((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随.Count != 0 && glueDetectTool.followedPose.XY.X == 0 && glueDetectTool.followedPose.XY.Y == 0)
                {
                    glueDetectTool.followedPose.XY.X = ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随[0].XY.X;
                    glueDetectTool.followedPose.XY.Y = ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随[0].XY.Y;
                    glueDetectTool.followedPose.U = ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随[0].U;
                }
            }

            //对圆进行位置跟随
            newCircleRow.Clear();
            newCircleCol.Clear();
            newCircleRadius.Clear();
            //对矩形进行位置跟随
            newRectangle1Row1.Clear();
            newRectangle1Col1.Clear();
            newRectangle1Row2.Clear();
            newRectangle1Col2.Clear();

            //获取旋转后的搜索区域
            HObject searchRegionAfterTransed = new HObject();
            if (((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随.Count == 0)     //无跟随
            {
                switch (glueDetectTool.searchRegionType)
                {
                    case RegionType.圆:

                        newCircleRow.Add(((ROICircle)glueDetectTool.L_regions[0]).Row);
                        newCircleCol.Add(((ROICircle)glueDetectTool.L_regions[0]).Column);
                        newCircleRadius.Add(((ROICircle)glueDetectTool.L_regions[0]).Radius);
                        searchRegionAfterTransed = glueDetectTool.L_regions[0].getRegion();
                        break;

                    case RegionType.矩形:

                        newRectangle1Row1.Add(((ROIRectangle1)glueDetectTool.L_regions[0]).Row1);
                        newRectangle1Col1.Add(((ROIRectangle1)glueDetectTool.L_regions[0]).Column1);
                        newRectangle1Row2.Add(((ROIRectangle1)glueDetectTool.L_regions[0]).Row2);
                        newRectangle1Col2.Add(((ROIRectangle1)glueDetectTool.L_regions[0]).Column2);
                        searchRegionAfterTransed = glueDetectTool.L_regions[0].getRegion();
                        break;

                    case RegionType.输入区域:

                        searchRegionAfterTransed = ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.区域;
                        break;

                    case RegionType.整幅图像:
                        searchRegionAfterTransed = null;
                        break;
                }
            }
            else        //有跟随
            {
                for (int i = 0; i < ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随.Count; i++)
                {
                    HTuple homMat2D;
                    HOperatorSet.VectorAngleToRigid(glueDetectTool.followedPose.XY.X, glueDetectTool.followedPose.XY.Y, glueDetectTool.followedPose.U, ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随[0].XY.X, ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随[0].XY.Y, ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随[0].U, out homMat2D);
                    switch (glueDetectTool.searchRegionType)
                    {
                        case RegionType.圆:          //对预期线的起始点做放射变换

                            HTuple tempR, tempC;
                            HOperatorSet.AffineTransPixel(homMat2D, ((ROICircle)glueDetectTool.L_regions[0]).Row, ((ROICircle)glueDetectTool.L_regions[0]).Column, out tempR, out tempC);
                            newCircleRow.Add(tempR);
                            newCircleCol.Add(tempC);
                            newCircleRadius.Add(((ROICircle)glueDetectTool.L_regions[0]).Radius);
                            break;

                        case RegionType.矩形:     //对预期线的起始点做放射变换

                            //对矩形的跟随不考虑角度，只对XY做跟随，随意矩形一旦考虑角度跟随就变成了仿射矩形，那就不对了
                            HTuple tempR1, tempC1, tempR2, tempC2;
                            HOperatorSet.AffineTransPixel(homMat2D, ((ROIRectangle1)glueDetectTool.L_regions[0]).Row1, ((ROIRectangle1)glueDetectTool.L_regions[0]).Column1, out tempR1, out tempC1);
                            HOperatorSet.AffineTransPixel(homMat2D, ((ROIRectangle1)glueDetectTool.L_regions[0]).Row2, ((ROIRectangle1)glueDetectTool.L_regions[0]).Column2, out tempR2, out tempC2);
                            newRectangle1Row1.Add(tempR1);
                            newRectangle1Col1.Add(tempC1);
                            newRectangle1Row2.Add(tempR2);
                            newRectangle1Col2.Add(tempC2);
                            break;

                        case RegionType.输入区域:
                            HOperatorSet.AffineTransRegion(((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.区域, out searchRegionAfterTransed, homMat2D, "nearest_neighbor");
                            break;

                        case RegionType.整幅图像:
                            searchRegionAfterTransed = null;
                            break;

                    }
                }
            }

            //获取新的可编辑的搜索区域
            if (glueDetectTool.showSearchRegion)
            {
                if (glueDetectTool.searchRegionType != RegionType.整幅图像)
                {
                    switch (glueDetectTool.searchRegionType)
                    {
                        case RegionType.圆:

                            glueDetectTool.L_regions.Clear();
                            Instance.hWindow_Final1.viewWindow.genCircle(newCircleRow[0], newCircleCol[0], newCircleRadius[0], ref glueDetectTool.L_regions);
                            L_regions = glueDetectTool.L_regions;
                            break;

                        case RegionType.矩形:

                            glueDetectTool.L_regions.Clear();
                            Instance.hWindow_Final1.viewWindow.genRect1(newRectangle1Row1[0], newRectangle1Col1[0], newRectangle1Row2[0], newRectangle1Col2[0], ref glueDetectTool.L_regions);
                            L_regions = glueDetectTool.L_regions;
                            break;

                        case RegionType.输入区域:

                            Instance.hWindow_Final1.DispObj(searchRegionAfterTransed, "blue");
                            break;
                    }
                }
            }

            //显示新的搜索区域
            if (glueDetectTool.searchRegionType != RegionType.整幅图像 && glueDetectTool.searchRegionType != RegionType.输入区域)
            {
                Instance.hWindow_Final1.viewWindow.displayROI(glueDetectTool.L_regions);
                L_regions = glueDetectTool.L_regions;
            }

            Instance.ckb_taskFailKeepRun.Checked = glueDetectTool.taskFailKeepRun;
            Instance.ckb_brokenGlueDetect.Checked = glueDetectTool.brokenGlueDetect;
            Instance.ckb_lackGlueDetect.Checked = glueDetectTool.lackGlueDetect;
            Instance.ckb_multiGlueDetect.Checked = glueDetectTool.multiGlueDetect;
            Instance.nud_maxDefectArea.Value = glueDetectTool.maxDefectArea;
            Instance.nud_corrosArea.Value = glueDetectTool.corrosSize;
            Instance.nud_minRunArea.Value = glueDetectTool.minRunArea;
            Instance.nud_maxRunArea.Value = glueDetectTool.maxRunArea;

            Instance.ckb_showResultMargin.Checked = glueDetectTool.showResultRegion;
            Instance.ckb_showDefectMargin.Checked = glueDetectTool.showDefectMargin;
            Instance.ckb_showSearchRegion.Checked = glueDetectTool.showSearchRegion;
            Instance.ckb_showCircleMark.Checked = glueDetectTool.showCircleMark;
            Instance.ckb_showDefectType.Checked = glueDetectTool.showDefectType;

            Frm_GlueRegion.Instance.cbx_searchRegionType.Text = glueDetectTool.searchRegionType.ToString();
            Frm_GlueRegion.Instance.nud_dilationSize.Value = glueDetectTool.dilationSize;
            Frm_GlueRegion.Instance.tck_minThreshold.Value = glueDetectTool.minThreshold;
            Frm_GlueRegion.Instance.tck_maxThreshold.Value = glueDetectTool.maxThreshold;
            Frm_GlueRegion.Instance.nud_minThreshold.Value = glueDetectTool.minThreshold;
            Frm_GlueRegion.Instance.nud_maxThreshold.Value = glueDetectTool.maxThreshold;
            Frm_GlueRegion.Instance.nud_minArea.Value = glueDetectTool.minArea;
            Frm_GlueRegion.Instance.nud_maxArea.Value = glueDetectTool.maxArea;
            Frm_GlueRegion.Instance.nud_minRow.Value = glueDetectTool.minRow;
            Frm_GlueRegion.Instance.nud_maxRow.Value = glueDetectTool.maxRow;
            Frm_GlueRegion.Instance.nud_minCol.Value = glueDetectTool.minCol;
            Frm_GlueRegion.Instance.nud_maxCol.Value = glueDetectTool.maxCol;
            Frm_GlueRegion.Instance.nud_minRoundness.Value = glueDetectTool.minRoundness;
            Frm_GlueRegion.Instance.nud_maxRoundness.Value = glueDetectTool.maxRoundness;
            Frm_GlueRegion.Instance.ckb_areaSelect.Checked = glueDetectTool.areaSelect;
            Frm_GlueRegion.Instance.ckb_rowSelect.Checked = glueDetectTool.rowSelect;
            Frm_GlueRegion.Instance.ckb_colSelect.Checked = glueDetectTool.colSelect;
            Frm_GlueRegion.Instance.ckb_roundnessSelect.Checked = glueDetectTool.roundnessSelect;
            if (glueDetectTool.TemplateRegion == null)
            {
                Frm_GlueRegion.Instance.lbl_templateStatu.ForeColor = Color.Red;
                Frm_GlueRegion.Instance.lbl_templateStatu.Text = "未保存";
            }
            else
            {
                Frm_GlueRegion.Instance.lbl_templateStatu.ForeColor = Color.Green;
                Frm_GlueRegion.Instance.lbl_templateStatu.Text = "已保存";
            }
            Frm_GlueRegion.Instance.dgv_result.Rows.Clear();

            Thread th1 = new Thread(() =>
            {
                glueDetectTool.Run();
            });
            th1.IsBackground = true;
            th1.Start();

            //功能启用
            if (!Permission.CheckPermission(PermissionGrade.Developer))
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
            glueDetectTool.ResetTool();
        }
        private void 适应窗体toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hWindow_Final1.DispImageFit();
        }
        private void 图像信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hWindow_Final1.showStatusBar();
        }
        private void Frm_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            Frm_GlueRegion.Instance.Close();
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

        private void btn_glueRegion_Click(object sender, EventArgs e)
        {
            if (Frm_GlueRegion.tempTemplateImage == null)
                Frm_GlueRegion.tempTemplateImage = ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.图像;
            if (glueDetectTool.TemplateImage == null)
                glueDetectTool.TemplateImage = ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.图像;

            Instance.hWindow_Final1.HobjectToHimage(glueDetectTool.TemplateImage);

            if (glueDetectTool.TemplateRegion == null)
            {
                Frm_GlueRegion.Instance.lbl_templateStatu.ForeColor = Color.Red;
                Frm_GlueRegion.Instance.lbl_templateStatu.Text = "未保存";
            }
            else
            {
                Frm_GlueRegion.Instance.lbl_templateStatu.ForeColor = Color.Green;
                Frm_GlueRegion.Instance.lbl_templateStatu.Text = "已保存";
            }

            this.TopMost = false;
            Frm_GlueRegion.openingForm = true;
            Frm_GlueRegion.Instance.btn_glueRegion_Click(null, null);
            Frm_GlueRegion.Instance.Location = new Point(this.Location.X + 659, this.Location.Y + 33);
            Frm_GlueRegion.Instance.TopMost = true;
            Frm_GlueRegion.Instance.TopLevel = true;
            Frm_GlueRegion.Instance.Show();
            Frm_GlueRegion.openingForm = false;
        }
        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            glueDetectTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }
        internal void btn_runTool_Click(object sender, EventArgs e)
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

                glueDetectTool.Run();

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
        private void Frm_ImageTool_ExtendBoxClick(object sender, EventArgs e)
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

        private void ckb_brokenGlueDetect_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            glueDetectTool.brokenGlueDetect = ckb_brokenGlueDetect.Checked;
        }
        private void ckb_lackGlueDetect_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            glueDetectTool.lackGlueDetect = ckb_lackGlueDetect.Checked;
        }
        private void ckb_multiGlueDetect_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            glueDetectTool.multiGlueDetect = ckb_multiGlueDetect.Checked;
        }
        private void nud_maxDefectArea_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.maxDefectArea = (int)value;
        }

        private void nud_corrosArea_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.corrosSize = (int)value;
        }
        private void nud_minRunArea_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.minRunArea = (int)value;
        }
        private void nud_maxRunArea_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.maxRunArea = (int)value;
        }
        private void ckb_showResultMargin_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            glueDetectTool.showResultRegion = ckb_showResultMargin.Checked;
        }
        private void ckb_showDefectMargin_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            glueDetectTool.showDefectMargin = ckb_showResultMargin.Checked;
        }
        private void ckb_showSearchRegion_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            glueDetectTool.showSearchRegion = ckb_showSearchRegion.Checked;
        }
        private void ckb_showCircleMark_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            glueDetectTool.showCircleMark = ckb_showCircleMark.Checked;
        }
        private void ckb_showDefectType_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            glueDetectTool.showDefectType = ckb_showDefectType.Checked;
        }

        private void dgv_result_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            glueDetectTool.ClickResultDgv(e);
        }

    }
}
