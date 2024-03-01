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
    public partial class Frm_GlueRegion : UIForm
    {
        public Frm_GlueRegion()
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
        internal static bool openingForm = true;
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
        internal static GlueDetectTool glueDetectTool = null;
        /// <summary>
        /// 临时标准图像
        /// </summary>
        internal static HObject tempTemplateImage = null;
        /// <summary>
        /// 搜索区域
        /// </summary>
        internal static List<ViewWindow.Model.ROI> L_regions = new List<ViewWindow.Model.ROI>();
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_GlueRegion _instance;
        internal static Frm_GlueRegion Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_GlueRegion();
                return _instance;
            }
        }


        private void Frm_GlueRegion_ExtendBoxClick(object sender, EventArgs e)
        {
            Instance.TopMost = !Instance.TopMost;

            if (Instance.TopMost)
                Instance.ExtendSymbol = 61475;
            else
                Instance.ExtendSymbol = 61758;
        }
        private void Frm_GlueRegion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Frm_GlueRegion.openingForm = false;
            this.Hide();
            e.Cancel = true;
        }

        private void cbx_searchRegionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            RegionType regionType = (RegionType)Enum.Parse(typeof(RegionType), cbx_searchRegionType.Text);
            if (glueDetectTool.searchRegionType != regionType)     //区域类型不变的话就不做任何操作
                glueDetectTool.SwitchSearchRegion(regionType);
            btn_glueRegion_Click(null, null);
        }
        private void btn_followCurPose_Click(object sender, EventArgs e)
        {
            if (((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随.Count > 0)
            {
                glueDetectTool.followedPose.XY.X = ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随[0].XY.X;
                glueDetectTool.followedPose.XY.Y = ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随[0].XY.Y;
                glueDetectTool.followedPose.U = ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.跟随[0].U;
            }
            btn_glueRegion_Click(null, null);
        }
        private void btn_addRegion_Click(object sender, EventArgs e)
        {
            btn_addRegion.Enabled = false;
            btn_subRegion.Enabled = false;
            Frm_GlueDetectTool.Instance.hWindow_Final1.DrawModel = true;
            Frm_GlueDetectTool.Instance.hWindow_Final1.ContextMenuStrip = null;

            HObject region = null;
            HOperatorSet.SetColor(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, "blue");
            HOperatorSet.SetLineWidth(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, 1);
            HOperatorSet.DrawRegion(out region, Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID);
            Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(region, "blue");
            HOperatorSet.Union2(region, glueDetectTool.extraRegionAdd, out glueDetectTool.extraRegionAdd);
            HOperatorSet.Difference(glueDetectTool.extraRegionSub, glueDetectTool.extraRegionAdd, out glueDetectTool.extraRegionSub);

            Frm_GlueDetectTool.Instance.hWindow_Final1.DrawModel = false;
            Frm_GlueDetectTool.Instance.hWindow_Final1.ContextMenuStrip = Frm_GlueDetectTool.Instance.uiContextMenuStrip1;
            btn_addRegion.Enabled = true;
            btn_subRegion.Enabled = true;
            btn_glueRegion_Click(null, null);
        }
        private void btn_subRegion_Click(object sender, EventArgs e)
        {
            btn_addRegion.Enabled = false;
            btn_subRegion.Enabled = false;
            Frm_GlueDetectTool.Instance.hWindow_Final1.DrawModel = true;
            Frm_GlueDetectTool.Instance.hWindow_Final1.ContextMenuStrip = null;

            HObject region = null;
            HOperatorSet.SetColor(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, "blue");
            HOperatorSet.SetLineWidth(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, 1);
            HOperatorSet.DrawRegion(out region, Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID);
            Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(region, "blue");
            HOperatorSet.Union2(glueDetectTool.extraRegionSub, region, out glueDetectTool.extraRegionSub);
            HOperatorSet.Difference(glueDetectTool.extraRegionAdd, glueDetectTool.extraRegionSub, out glueDetectTool.extraRegionAdd);

            Frm_GlueDetectTool.Instance.hWindow_Final1.DrawModel = false;
            Frm_GlueDetectTool.Instance.hWindow_Final1.ContextMenuStrip = Frm_GlueDetectTool.Instance.uiContextMenuStrip1;
            btn_addRegion.Enabled = true;
            btn_subRegion.Enabled = true;
            btn_glueRegion_Click(null, null);
        }
        private void btn_clearRegion_Click(object sender, EventArgs e)
        {
            HOperatorSet.GenEmptyObj(out glueDetectTool.extraRegionAdd);
            HOperatorSet.GenEmptyObj(out glueDetectTool.extraRegionSub);
            btn_glueRegion_Click(null, null);
        }
        private void nud_dilationSize_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.dilationSize = (int)value;
            btn_glueRegion_Click(null, null);
        }
        private void tck_minThreshold_Scroll(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            nud_minThreshold.Value = tck_minThreshold.Value;
        }
        private void tck_maxThreshold_Scroll(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            nud_maxThreshold.Value = tck_maxThreshold.Value;
        }
        private void nud_minThreshold_ValueChanged(double value)
        {
            if (openingForm)
                return;

            if (value > tck_maxThreshold.Value)         //阈值下限不能大于阈值上限
                nud_minThreshold.Value = tck_maxThreshold.Value;

            glueDetectTool.minThreshold = (int)nud_minThreshold.Value;
            tck_minThreshold.Value = glueDetectTool.minThreshold;
            btn_glueRegion_Click(null, null);
        }
        private void nud_maxThreshold_ValueChanged(double value)
        {
            if (openingForm)
                return;

            if (value < tck_minThreshold.Value)         //阈值上限不能大于阈值下限
                nud_maxThreshold.Value = nud_minThreshold.Value;

            glueDetectTool.maxThreshold = (int)nud_maxThreshold.Value;
            tck_maxThreshold.Value = glueDetectTool.maxThreshold;
            btn_glueRegion_Click(null, null);
        }

        private void nud_minArea_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.minArea = (int)value;
            glueDetectTool.areaSelect = true;
            ckb_areaSelect.Checked = true;
            btn_glueRegion_Click(null, null);
        }
        private void nud_maxArea_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.maxArea = (int)value;
            glueDetectTool.areaSelect = true;
            ckb_areaSelect.Checked = true;
            btn_glueRegion_Click(null, null);
        }
        private void nud_minRow_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.minRow = (int)value;
            glueDetectTool.rowSelect = true;
            ckb_rowSelect.Checked = true;
            btn_glueRegion_Click(null, null);
        }
        private void nud_maxRow_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.maxRow = (int)value;
            glueDetectTool.rowSelect = true;
            ckb_rowSelect.Checked = true;
            btn_glueRegion_Click(null, null);
        }
        private void nud_minCol_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.minCol = (int)value;
            glueDetectTool.colSelect = true;
            ckb_colSelect.Checked = true;
            btn_glueRegion_Click(null, null);
        }
        private void nud_maxCol_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.maxCol = (int)value;
            glueDetectTool.colSelect = true;
            ckb_colSelect.Checked = true;
            btn_glueRegion_Click(null, null);
        }
        private void nud_minRoundness_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.minRoundness = (int)value;
            glueDetectTool.roundnessSelect = true;
            ckb_roundnessSelect.Checked = true;
            btn_glueRegion_Click(null, null);
        }
        private void nud_maxRoundness_ValueChanged(double value)
        {
            if (openingForm)
                return;

            glueDetectTool.maxRoundness = (int)value;
            glueDetectTool.roundnessSelect = true;
            ckb_roundnessSelect.Checked = true;
            btn_glueRegion_Click(null, null);
        }
        private void ckb_areaSelect_Click(object sender, EventArgs e)
        {
            glueDetectTool.areaSelect = ckb_areaSelect.Checked;
            btn_glueRegion_Click(null, null);
        }
        private void ckb_rowSelect_Click(object sender, EventArgs e)
        {
            glueDetectTool.rowSelect = ckb_rowSelect.Checked;
            btn_glueRegion_Click(null, null);
        }
        private void ckb_colSelect_Click(object sender, EventArgs e)
        {
            glueDetectTool.colSelect = ckb_colSelect.Checked;
            btn_glueRegion_Click(null, null);
        }
        private void ckb_roundnessSelect_Click(object sender, EventArgs e)
        {
            glueDetectTool.roundnessSelect = ckb_roundnessSelect.Checked;
            btn_glueRegion_Click(null, null);
        }

        internal void btn_glueRegion_Click(object sender, EventArgs e)
        {
            glueDetectTool.SegmentGlueRegion();

            //显示搜索区域
            if (((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.区域 != null)
            {
                HObject searchRegionDilated = null;
                HOperatorSet.DilationCircle(((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.区域, out searchRegionDilated, glueDetectTool.dilationSize);
                Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(searchRegionDilated, "blue");
            }
        }
        private void btn_updateImage_Click(object sender, EventArgs e)
        {
            tempTemplateImage = ((GlueDetectTool.ToolPar)glueDetectTool.参数).输入.图像;
            Frm_GlueDetectTool.Instance.hWindow_Final1.HobjectToHimage(tempTemplateImage);
            btn_glueRegion_Click(null, null);
        }
        private void btn_saveTemplate_Click(object sender, EventArgs e)
        {
            glueDetectTool.TemplateImage = tempTemplateImage;
            glueDetectTool.TemplateRegion = ((GlueDetectTool.ToolPar)glueDetectTool.参数).输出.区域;

            lbl_templateStatu.ForeColor = Color.Green;
            lbl_templateStatu.Text = "已保存";
        }
        private void dgv_result_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            glueDetectTool.ClickResultList(dgv_result, e);
        }

    }
}
