using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewWindow.Model;
using HalconDotNet;

namespace VM_Pro
{
    [Serializable]
    /// <summary>
    /// 胶路检测
    /// </summary>
    internal class GlueDetectTool : ToolBase
    {
        internal GlueDetectTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

            HOperatorSet.GenEmptyRegion(out extraRegionAdd);
            HOperatorSet.GenEmptyRegion(out extraRegionSub);
            HOperatorSet.GenEmptyRegion(out searchRegionAfterTransed);

            //自动连接输入
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.采集图像)
                {
                    InputItem inputItem = new InputItem();
                    inputItem.InputName = "图像";
                    inputItem.inputType = DataType.Image;
                    inputItem.sourceTask = taskName;
                    inputItem.sourceTool = Task.curTask.L_toolList[i].toolName;
                    inputItem.sourceOutput = "图像";

                    L_inputItem.Add(inputItem);
                    break;
                }
            }
        }

        /// <summary>
        /// 断胶检测
        /// </summary>
        internal bool brokenGlueDetect = true;
        /// <summary>
        /// 少胶检测
        /// </summary>
        internal bool lackGlueDetect = true;
        /// <summary>
        /// 多胶检测
        /// </summary>
        internal bool multiGlueDetect = false;
        /// <summary>
        /// 不良界定
        /// </summary>
        internal int maxDefectArea = 30;
        /// <summary>
        /// 不良腐蚀
        /// </summary>
        internal int corrosSize = 3;
        /// <summary>
        /// 运行面积筛选下限
        /// </summary>
        internal int minRunArea = 10;
        /// <summary>
        /// 运行面积筛选上限
        /// </summary>
        internal int maxRunArea = 100000000;
        /// <summary>
        /// 是否显示结果区域
        /// </summary>
        internal bool showResultRegion = true;
        /// <summary>
        /// 显示缺陷轮廓
        /// </summary>
        internal bool showDefectMargin = true;
        /// <summary>
        /// 是否显示搜索区域
        /// </summary>
        internal bool showSearchRegion = true;
        /// <summary>
        /// 显示圆圈标记
        /// </summary>
        internal bool showCircleMark = true;
        /// <summary>
        /// 显示不良类型
        /// </summary>
        internal bool showDefectType = true;
        /// <summary>
        /// 搜索区域类型
        /// </summary>
        internal RegionType searchRegionType = RegionType.整幅图像;
        /// <summary>
        /// 检测区域膨胀大小
        /// </summary>
        internal int dilationSize = 5;
        /// <summary>
        /// 阈值下限
        /// </summary>
        internal int minThreshold = 128;
        /// <summary>
        /// 阈值上限
        /// </summary>
        internal int maxThreshold = 255;
        /// <summary>
        /// 是否启用面积筛选
        /// </summary>
        internal bool areaSelect = false;
        /// <summary>
        /// 面积筛选下限
        /// </summary>
        internal int minArea = 10;
        /// <summary>
        /// 面积筛选上限
        /// </summary>
        internal int maxArea = 1000000;
        /// <summary>
        /// 是否启用行坐标筛选
        /// </summary>
        internal bool rowSelect = false;
        /// <summary>
        /// 行坐标筛选下限
        /// </summary>
        internal int minRow = 0;
        /// <summary>
        /// 行坐标筛选上限
        /// </summary>
        internal int maxRow = 10000;
        /// <summary>
        /// 是否启用列坐标筛选
        /// </summary>
        internal bool colSelect = false;
        /// <summary>
        /// 列坐标筛选下限
        /// </summary>
        internal int minCol = 0;
        /// <summary>
        /// 列坐标筛选上限
        /// </summary>
        internal int maxCol = 10000;
        /// <summary>
        /// 是否启用圆度筛选
        /// </summary>
        internal bool roundnessSelect = false;
        /// <summary>
        /// 圆度筛选下限
        /// </summary>
        internal int minRoundness = 0;
        /// <summary>
        /// 圆度筛选上限
        /// </summary>
        internal int maxRoundness = 1;
        /// <summary>
        /// 斑点结果排序模式
        /// </summary>
        internal SortMode sortMode = SortMode.面积;
        /// <summary>
        /// 行列间隔像素数
        /// </summary>
        internal int spacing = 100;
        /// <summary>
        /// 模板图像
        /// </summary>
        internal HObject TemplateImage = null;
        /// <summary>
        /// 模板区域
        /// </summary>
        internal HObject TemplateRegion = null;
        /// <summary>
        /// 模板位姿
        /// </summary>
        internal XYU followedPose = new XYU();
        /// <summary>
        /// 区域处理操作集合
        /// </summary>
        internal List<Processing> L_processing = new List<Processing>();
        /// <summary>
        /// 除搜索区域外额外增加的区域
        /// </summary>
        internal HObject extraRegionAdd = null;
        /// <summary>
        /// 除搜索区域外额外减去的区域
        /// </summary>
        internal HObject extraRegionSub = null;
        /// <summary>
        /// 位置跟随后的搜索区域
        /// </summary>
        internal HObject searchRegionAfterTransed = null;
        /// <summary>
        /// 位置跟随后的搜索区域
        /// </summary>
        internal HObject standardRegionAfterTransed = null;
        /// <summary>
        /// 斑点结果集合
        /// </summary>
        internal List<BlobResult> L_blobResult = new List<BlobResult>();
        /// <summary>
        /// 不良结果集合
        /// </summary>
        internal List<DefectResult> L_defectResult = new List<DefectResult>();
        /// <summary>
        /// 搜索区域
        /// </summary>
        internal List<ViewWindow.Model.ROI> L_regions = new List<ViewWindow.Model.ROI>();


        /// <summary>
        /// 复位工具
        /// </summary>
        internal override void ResetTool()
        {
            brokenGlueDetect = true;
            lackGlueDetect = true;
            multiGlueDetect = true;
            maxDefectArea = 30;
            corrosSize = 3;
            minRunArea = 10;
            maxRunArea = 100000000;

            showResultRegion = true;
            showDefectMargin = true;
            showSearchRegion = true;
            showCircleMark = true;
            showDefectType = true;
            L_processing.Clear();
            L_regions.Clear();

            searchRegionType = RegionType.整幅图像;
            dilationSize = 5;
            minThreshold = 128;
            maxThreshold = 255;
            minArea = 10;
            maxArea = 1000000;
            minRow = 0;
            maxRow = 10000;
            minCol = 0;
            maxCol = 10000;
            minRoundness = 0;
            maxRoundness = 1;
            areaSelect = false;
            rowSelect = false;
            colSelect = false;
            roundnessSelect = false;
            TemplateRegion = null;

            Frm_GlueDetectTool.Instance.ckb_brokenGlueDetect.Checked = true;
            Frm_GlueDetectTool.Instance.ckb_lackGlueDetect.Checked = true;
            Frm_GlueDetectTool.Instance.ckb_multiGlueDetect.Checked = true;
            Frm_GlueDetectTool.Instance.nud_maxDefectArea.Value = maxDefectArea;
            Frm_GlueDetectTool.Instance.nud_corrosArea.Value = corrosSize;
            Frm_GlueDetectTool.Instance.nud_minRunArea.Value = minRunArea;
            Frm_GlueDetectTool.Instance.nud_maxRunArea.Value = maxRunArea;

            Frm_GlueDetectTool.Instance.ckb_showResultMargin.Checked = true;
            Frm_GlueDetectTool.Instance.ckb_showDefectMargin.Checked = true;
            Frm_GlueDetectTool.Instance.ckb_showSearchRegion.Checked = true;
            Frm_GlueDetectTool.Instance.ckb_showCircleMark.Checked = true;
            Frm_GlueDetectTool.Instance.ckb_showDefectType.Checked = true;
            Frm_GlueDetectTool.Instance.dgv_result.Rows.Clear();

            Frm_GlueRegion.Instance.cbx_searchRegionType.Text = searchRegionType.ToString();
            Frm_GlueRegion.Instance.nud_dilationSize.Value = dilationSize;
            Frm_GlueRegion.Instance.tck_minThreshold.Value = minThreshold;
            Frm_GlueRegion.Instance.tck_maxThreshold.Value = maxThreshold;
            Frm_GlueRegion.Instance.nud_minThreshold.Value = minThreshold;
            Frm_GlueRegion.Instance.nud_maxThreshold.Value = maxThreshold;
            Frm_GlueRegion.Instance.nud_minArea.Value = minArea;
            Frm_GlueRegion.Instance.nud_maxArea.Value = maxArea;
            Frm_GlueRegion.Instance.nud_minRow.Value = minRow;
            Frm_GlueRegion.Instance.nud_maxRow.Value = maxRow;
            Frm_GlueRegion.Instance.nud_minCol.Value = minCol;
            Frm_GlueRegion.Instance.nud_maxCol.Value = maxCol;
            Frm_GlueRegion.Instance.nud_minRoundness.Value = minRoundness;
            Frm_GlueRegion.Instance.nud_maxRoundness.Value = maxRoundness;
            Frm_GlueRegion.Instance.ckb_areaSelect.Checked = areaSelect;
            Frm_GlueRegion.Instance.ckb_rowSelect.Checked = rowSelect;
            Frm_GlueRegion.Instance.ckb_colSelect.Checked = colSelect;
            Frm_GlueRegion.Instance.ckb_roundnessSelect.Checked = roundnessSelect;
            if (TemplateRegion == null)
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

            Frm_GlueDetectTool.Instance.lbl_runTime.Text = "0 ms";
            Frm_GlueDetectTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
            Frm_GlueDetectTool.Instance.lbl_toolTip.Text = "暂无提示";
        }
        /// <summary>
        /// 结果列表点击事件
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="e"></param>
        internal void ClickResultDgv(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (((ToolPar)参数).输入.图像 != null)
                Frm_GlueDetectTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
            else
                Frm_GlueDetectTool.Instance.hWindow_Final1.ClearWindow();

            //显示搜索区域
            HObject searchRegionDilated = null;
            HOperatorSet.DilationCircle(TemplateRegion, out searchRegionDilated, dilationSize);
            Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(searchRegionDilated, "blue");

            //显示胶路区域
            if (showResultRegion)
                Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(((ToolPar)参数).输出.区域, "green");

            //显示异常区域
            if (showResultRegion)
                Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(L_defectResult[e.RowIndex].region, "red");

            //显示红色圈圈
            HObject circle;
            HOperatorSet.GenCircle(out circle, L_defectResult[e.RowIndex].Row, L_defectResult[e.RowIndex].Col, L_defectResult[e.RowIndex].radius + 10 > 40 ? L_defectResult[e.RowIndex].radius + 10 : 40);
            Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(circle, "orange");
            switch (L_defectResult[e.RowIndex].defectType)
            {
                case DefectType.断胶:
                    HalconLib.DispText(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, "断胶", 12, L_defectResult[e.RowIndex].Row + L_defectResult[e.RowIndex].radius + 40, L_defectResult[e.RowIndex].Col - 38, "red", "false");
                    break;
                case DefectType.少胶:
                    HalconLib.DispText(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, "少胶", 12, L_defectResult[e.RowIndex].Row + L_defectResult[e.RowIndex].radius + 20, L_defectResult[e.RowIndex].Col - 38, "red", "false");
                    break;
                case DefectType.多胶:
                    HalconLib.DispText(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, "多胶", 12, L_defectResult[e.RowIndex].Row + L_defectResult[e.RowIndex].radius + 40, L_defectResult[e.RowIndex].Col - 38, "red", "false");
                    break;
            }
        }
        /// <summary>
        /// 结果列表点击事件
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="e"></param>
        internal void ClickResultList(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (((ToolPar)参数).输入.图像 != null)
                Frm_GlueDetectTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
            else
                Frm_GlueDetectTool.Instance.hWindow_Final1.ClearWindow();

            //显示搜索区域
            if (searchRegionType != RegionType.整幅图像)
            {
                if (searchRegionType == RegionType.输入区域)
                    Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(searchRegionAfterTransed, "blue");
                else
                    Frm_GlueDetectTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
            }

            //显示结果区域
            if (showResultRegion)
                Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(L_blobResult[e.RowIndex].region, "green");
        }
        /// <summary>
        /// 切换搜索区域
        /// </summary>
        internal void SwitchSearchRegion(RegionType regionType)
        {
            if (((ToolPar)参数).输入.图像 != null)
                Frm_GlueDetectTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);

            HOperatorSet.SetLineStyle(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple());
            Frm_GlueDetectTool.Instance.hWindow_Final1.Select();

            HTuple width, height;
            HOperatorSet.GetImageSize(((ToolPar)参数).输入.图像, out width, out height);
            this.L_regions.Clear();
            switch (regionType)
            {
                case RegionType.整幅图像:
                    break;
                case RegionType.矩形:
                    Frm_GlueDetectTool.Instance.hWindow_Final1.viewWindow.genRect1(height * 0.375, width * 0.375, height * 0.625, width * 0.625, ref this.L_regions);
                    Frm_GlueDetectTool.L_regions = this.L_regions;
                    break;
                case RegionType.仿射矩形:
                    Frm_GlueDetectTool.Instance.hWindow_Final1.viewWindow.genRect2(height / 2, width / 2, 0, width * 0.125, height * 0.125, ref this.L_regions);
                    Frm_GlueDetectTool.L_regions = this.L_regions;
                    break;
                case RegionType.圆:
                    Frm_GlueDetectTool.Instance.hWindow_Final1.viewWindow.genCircle(height / 2, width / 2, height / 8, ref this.L_regions);
                    Frm_GlueDetectTool.L_regions = this.L_regions;
                    break;
                default:
                    Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(((ToolPar)参数).输入.区域);
                    break;
            }
            searchRegionType = regionType;
        }
        /// <summary>
        /// 识别分割胶水区域
        /// </summary>
        internal void SegmentGlueRegion()
        {
            //判断是否有图像输入
            if (Frm_GlueRegion.tempTemplateImage == null)
            {
                Frm_GlueDetectTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                Frm_GlueDetectTool.Instance.lbl_toolTip.Text = "分割失败，未指定输入图像";
                return;
            }

            //如果搜索区域是外部输入，判断区域是否有为空
            if (searchRegionType == RegionType.输入区域 && ((GlueDetectTool.ToolPar)参数).输入.区域 == null)
            {
                Frm_GlueDetectTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                Frm_GlueDetectTool.Instance.lbl_toolTip.Text = "分割失败，未指定输入搜索区域";
                return;
            }

            //刷新图像
            Frm_GlueDetectTool.Instance.hWindow_Final1.HobjectToHimage(Frm_GlueRegion.tempTemplateImage);

            //阈值下限不得大于阈值上限
            if (minThreshold >= maxThreshold)
            {
                Frm_GlueDetectTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                Frm_GlueDetectTool.Instance.lbl_toolTip.Text = "分割失败，阈值下限不得大于阈值上限";
                return;
            }

            switch (searchRegionType)
            {
                case RegionType.输入区域:
                    searchRegionAfterTransed = ((ToolPar)参数).输入.区域;
                    break;
                case RegionType.整幅图像:
                    HTuple width, height;
                    HOperatorSet.GetImageSize(((ToolPar)参数).输入.图像, out width, out height);
                    HOperatorSet.GenRectangle1(out searchRegionAfterTransed, 0, 0, height, width);
                    break;
                default:
                    searchRegionAfterTransed = L_regions[0].getRegion();
                    break;
            }

            //获取新的可编辑的搜索区域
            if (showSearchRegion && searchRegionType != RegionType.整幅图像)
            {
                //更新跟随
                if (searchRegionType != RegionType.输入区域)
                {
                    if (((ToolPar)参数).输入.跟随.Count > 0)
                    {
                        followedPose.XY.X = ((ToolPar)参数).输入.跟随[0].XY.X;
                        followedPose.XY.Y = ((ToolPar)参数).输入.跟随[0].XY.Y;
                        followedPose.U = ((ToolPar)参数).输入.跟随[0].U;
                    }
                }
            }

            //更新一下加减后的区域
            HOperatorSet.Union2(searchRegionAfterTransed, extraRegionAdd, out searchRegionAfterTransed);
            HOperatorSet.Difference(searchRegionAfterTransed, extraRegionSub, out searchRegionAfterTransed);
            HObject imageReduced;
            HOperatorSet.ReduceDomain(Frm_GlueRegion.tempTemplateImage, searchRegionAfterTransed, out  imageReduced);

            //获取旋转后的搜索区域的图像
            HObject searchImageAfterTransed;
            if (searchRegionType != RegionType.整幅图像)
                HOperatorSet.ReduceDomain(imageReduced, searchRegionAfterTransed, out   searchImageAfterTransed);
            else
                searchImageAfterTransed = imageReduced;

            //开始阈值分割
            HObject resultRegion;
            HOperatorSet.Threshold(searchImageAfterTransed, out resultRegion, minThreshold, maxThreshold);
            HOperatorSet.Connection(resultRegion, out resultRegion);
            HTuple num = 0;
            HOperatorSet.CountObj(resultRegion, out num);
            if (num > 100000)
            {
                Frm_GlueDetectTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                Frm_GlueDetectTool.Instance.lbl_toolTip.Text = "分割失败，区域数量过多";
                return;
            }

            //斑点结果处理
            for (int i = 0; i < L_processing.Count; i++)
            {
                if (L_processing[i].enable == false)     //未启用
                    continue;

                switch (L_processing[i].processingType)
                {
                    case "开运算":
                        HOperatorSet.OpeningCircle(resultRegion, out resultRegion, L_processing[i].elementSize);
                        break;
                    case "闭运算":
                        HOperatorSet.ClosingCircle(resultRegion, out resultRegion, L_processing[i].elementSize);
                        break;
                    case "腐蚀":      //此处对面积在一定范围内的斑点进行腐蚀
                        HOperatorSet.CountObj(resultRegion, out num);
                        HObject tempRegion;
                        HOperatorSet.GenEmptyRegion(out tempRegion);
                        for (int j = 0; j < num; j++)
                        {
                            HObject region;
                            HOperatorSet.SelectObj(resultRegion, out region, new HTuple(j + 1));
                            HTuple area, row, col;
                            HOperatorSet.AreaCenter(region, out area, out row, out col);
                            if (L_processing[i].minArea < area.I && area.I < L_processing[i].maxArea)
                                HOperatorSet.ErosionCircle(region, out region, new HTuple(L_processing[i].elementSize));
                            HOperatorSet.Union2(tempRegion, region, out tempRegion);
                        }
                        resultRegion = tempRegion;
                        HOperatorSet.Connection(resultRegion, out resultRegion);
                        break;
                    case "膨胀":      //此处对面积在一定范围内的斑点进行膨胀
                        HOperatorSet.Connection(resultRegion, out resultRegion);
                        HOperatorSet.CountObj(resultRegion, out num);
                        HOperatorSet.GenEmptyRegion(out tempRegion);
                        for (int j = 0; j < num; j++)
                        {
                            HObject region;
                            HOperatorSet.SelectObj(resultRegion, out region, new HTuple(j + 1));
                            HTuple area, row, col;
                            HOperatorSet.AreaCenter(region, out area, out row, out col);
                            if (L_processing[i].minArea < area.I && area.I < L_processing[i].maxArea)
                                HOperatorSet.DilationCircle(region, out region, new HTuple(L_processing[i].elementSize));
                            HOperatorSet.Union2(tempRegion, region, out tempRegion);
                        }
                        resultRegion = tempRegion;
                        HOperatorSet.Connection(resultRegion, out resultRegion);
                        break;
                    case "填充":
                        HOperatorSet.FillUp(resultRegion, out resultRegion);
                        break;
                    case "填凹":
                        HOperatorSet.ShapeTrans(resultRegion, out resultRegion, "convex");
                        break;
                }
            }
            HOperatorSet.Connection(resultRegion, out resultRegion);

            //显示搜索区域
            if (showSearchRegion)
            {
                if (searchRegionType != RegionType.整幅图像)
                {
                    if (Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
                    {
                        if (searchRegionType == RegionType.输入区域)
                            Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(searchRegionAfterTransed, "blue");
                        else
                            Frm_GlueDetectTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);

                        HOperatorSet.SetLineStyle(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple());
                        HOperatorSet.SetDraw(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, "margin");
                        HObject temp1;
                        HOperatorSet.FillUp(extraRegionAdd, out temp1);
                        Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(temp1, "blue");
                        HOperatorSet.SetLineStyle(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple(16, 7, 3, 7));
                        Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(extraRegionSub, "blue");
                        HOperatorSet.SetLineStyle(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple());

                    }
                    GetImageWindow().DispObj(searchRegionAfterTransed, "blue");
                }
            }

            //结果区域联合
            HOperatorSet.Union1(resultRegion, out  resultRegion);
            HOperatorSet.Connection(resultRegion, out resultRegion);

            //把结果区域和搜索区域取一下交集，保证结果区域都在搜索区域之内，防止因膨胀导致结果区域超出搜索区域的情况
            if (searchRegionType != RegionType.整幅图像)
            {
                HOperatorSet.Intersection(resultRegion, searchRegionAfterTransed, out resultRegion);
                HOperatorSet.Connection(resultRegion, out resultRegion);
            }

            //当没有一个结果区域时它也会显示有一个结果，面积是0，所有我们需要过滤一下，把这个结果过滤掉
            HOperatorSet.SelectShape(resultRegion, out resultRegion, "area", "and", 1, 100000000);

            //斑点筛选
            if (areaSelect)
                HOperatorSet.SelectShape(resultRegion, out resultRegion, "area", "and", minArea, maxArea);
            if (rowSelect)
                HOperatorSet.SelectShape(resultRegion, out resultRegion, "row", "and", minRow, maxRow);
            if (colSelect)
                HOperatorSet.SelectShape(resultRegion, out resultRegion, "column", "and", minCol, maxCol);
            if (roundnessSelect)
                HOperatorSet.SelectShape(resultRegion, out resultRegion, "roundness", "and", minRoundness, maxRoundness);

            HOperatorSet.Connection(resultRegion, out resultRegion);
            HOperatorSet.Union1(resultRegion, out  resultRegion);
            HOperatorSet.Connection(resultRegion, out resultRegion);

            ((ToolPar)参数).输出.区域 = resultRegion;

            //显示结果区域
            if (showResultRegion)
            {
                GetImageWindow().DispObj(resultRegion, "green");
                if (Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
                    Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(resultRegion, "green");
            }

            //显示相关辅助图像
            HTuple blobNum = 0;
            HOperatorSet.CountObj(resultRegion, out blobNum);

            L_blobResult.Clear();
            ((ToolPar)参数).输出.位置.Clear();
            for (int i = 0; i < blobNum; i++)
            {
                HObject region;
                HOperatorSet.SelectObj(resultRegion, out region, new HTuple(i + 1));

                HTuple area3, row3, col3, radius3;
                HOperatorSet.AreaCenter(region, out area3, out row3, out col3);
                HOperatorSet.SmallestCircle(region, out row3, out col3, out radius3);

                BlobResult blobResult = new BlobResult();
                blobResult.Row = Math.Round(row3.D, 2);
                blobResult.Col = Math.Round(col3.D, 2);
                blobResult.Area = Math.Round(area3.D, 2);
                blobResult.CircumcircleRadius = Math.Round(radius3.D, 2);
                blobResult.region = region;
                L_blobResult.Add(blobResult);

                XY xy = new XY();
                xy.X = L_blobResult[i].Row;
                xy.Y = L_blobResult[i].Col;
                ((ToolPar)参数).输出.位置.Add(xy);
            }

            //排序
            BlobResult temp;
            switch (sortMode)
            {
                case SortMode.面积:

                    for (int i = 0; i < L_blobResult.Count - 1; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if (L_blobResult[i].Area < L_blobResult[j].Area)
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }
                    break;

                case SortMode.从上至下且从左至右:

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if (L_blobResult[i].Row - L_blobResult[j].Row > spacing / 2)
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if ((L_blobResult[i].Col - L_blobResult[j].Col > spacing / 2) && (Math.Abs(L_blobResult[i].Row - L_blobResult[j].Row) < spacing / 2))
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }
                    break;

                case SortMode.从左至右且从上至下:

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if (L_blobResult[i].Col - L_blobResult[j].Col > spacing / 2)
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if ((L_blobResult[i].Row - L_blobResult[j].Row > spacing / 2) && (Math.Abs(L_blobResult[i].Col - L_blobResult[j].Col) < spacing / 2))
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }
                    break;

                case SortMode.从上至下且从右至左:

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if (L_blobResult[i].Row - L_blobResult[j].Row > spacing / 2)
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if ((L_blobResult[i].Col - L_blobResult[j].Col < spacing / 2) && (Math.Abs(L_blobResult[i].Row - L_blobResult[j].Row) < spacing / 2))
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }
                    break;

                case SortMode.从左至右且从下至上:

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if (L_blobResult[i].Col - L_blobResult[j].Col < spacing / 2)
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if ((L_blobResult[i].Row - L_blobResult[j].Row > spacing / 2) && (Math.Abs(L_blobResult[i].Col - L_blobResult[j].Col) < spacing / 2))
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }
                    break;

            }

            Frm_GlueRegion.Instance.lbl_regionNum.Text = L_blobResult.Count + " 个";

            //在界面显示斑点结果
            Frm_GlueRegion.Instance.dgv_result.Rows.Clear();
            for (int i = 0; i < L_blobResult.Count; i++)
            {
                int index = Frm_GlueRegion.Instance.dgv_result.Rows.Add();
                Frm_GlueRegion.Instance.dgv_result.Rows[index].Cells[0].Value = i + 1;
                Frm_GlueRegion.Instance.dgv_result.Rows[index].Cells[1].Value = L_blobResult[i].Area;
                Frm_GlueRegion.Instance.dgv_result.Rows[index].Cells[2].Value = L_blobResult[i].Row;
                Frm_GlueRegion.Instance.dgv_result.Rows[index].Cells[3].Value = L_blobResult[i].Col;
            }
        }
        /// <summary>
        /// 运行工具    
        /// </summary>
        /// <param name="initRun">初始化运行</param>
        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
        {
            toolRunStatu = "未知原因";
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            if (initRun)
            {
                参数 = new ToolPar();
                toolRunStatu = "运行成功";
                sw.Stop();
                return;
            }

            //判断是否有图像输入
            if (((ToolPar)参数).输入.图像 == null)
            {
                toolRunStatu = "未指定输入图像";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            //阈值下限不得大于阈值上限
            if (minThreshold >= maxThreshold)
            {
                toolRunStatu = "阈值下限不得大于阈值上限";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            //刷新图像
            GetImageWindow().HobjectToHimage(((ToolPar)参数).输入.图像);
            if (Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
                Frm_GlueDetectTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);

            //判断是否已指定检测区域
            if (TemplateRegion == null)
            {
                toolRunStatu = "未指定胶水检测区域";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            //获取旋转后的搜索区域
            if (((ToolPar)参数).输入.跟随.Count == 0)     //无跟随
            {
                HOperatorSet.Union1(TemplateRegion, out  TemplateRegion);
                HOperatorSet.Connection(TemplateRegion, out TemplateRegion);
                HOperatorSet.DilationCircle(TemplateRegion, out searchRegionAfterTransed, dilationSize);
                if (showSearchRegion)
                {
                    if (Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
                        Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(searchRegionAfterTransed, "blue");
                    GetImageWindow().DispObj(searchRegionAfterTransed, "blue");
                }
            }
            else        //有跟随
            {
                for (int i = 0; i < ((GlueDetectTool.ToolPar)参数).输入.跟随.Count; i++)
                {
                    HTuple homMat2D;
                    HOperatorSet.DilationCircle(TemplateRegion, out searchRegionAfterTransed, dilationSize);
                    HOperatorSet.VectorAngleToRigid(followedPose.XY.X, followedPose.XY.Y, followedPose.U, ((ToolPar)参数).输入.跟随[i].XY.X, ((ToolPar)参数).输入.跟随[i].XY.Y, ((ToolPar)参数).输入.跟随[i].U, out homMat2D);
                    HOperatorSet.AffineTransRegion(searchRegionAfterTransed, out searchRegionAfterTransed, homMat2D, "nearest_neighbor");
                    HOperatorSet.AffineTransRegion(TemplateRegion, out standardRegionAfterTransed, homMat2D, "nearest_neighbor");
                }
            }

            //获取新的可编辑的搜索区域
            if (showSearchRegion && trigedByTool && Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
            {
                GetImageWindow().DispObj(searchRegionAfterTransed, "blue");
                Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(searchRegionAfterTransed, "blue");

                //更新跟随
                if (searchRegionType != RegionType.输入区域)
                {
                    if (((ToolPar)参数).输入.跟随.Count > 0)
                    {
                        followedPose.XY.X = ((ToolPar)参数).输入.跟随[0].XY.X;
                        followedPose.XY.Y = ((ToolPar)参数).输入.跟随[0].XY.Y;
                        followedPose.U = ((ToolPar)参数).输入.跟随[0].U;
                    }
                }
            }

            //获取旋转后的搜索区域的图像
            HObject searchImageAfterTransed;
            HOperatorSet.Union1(searchRegionAfterTransed, out searchRegionAfterTransed);
            HOperatorSet.ReduceDomain(((ToolPar)参数).输入.图像, searchRegionAfterTransed, out   searchImageAfterTransed);

            //开始阈值分割
            HObject resultRegion;
            HOperatorSet.Threshold(searchImageAfterTransed, out resultRegion, minThreshold, maxThreshold);

            HOperatorSet.Connection(resultRegion, out resultRegion);
            HTuple num = 0;
            HOperatorSet.CountObj(resultRegion, out num);
            if (num > 10000)
            {
                toolRunStatu = "不良区域过多";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            //斑点结果处理
            for (int i = 0; i < L_processing.Count; i++)
            {
                if (L_processing[i].enable == false)     //未启用
                    continue;

                switch (L_processing[i].processingType)
                {
                    case "开运算":
                        HOperatorSet.OpeningCircle(resultRegion, out resultRegion, L_processing[i].elementSize);
                        break;
                    case "闭运算":
                        HOperatorSet.ClosingCircle(resultRegion, out resultRegion, L_processing[i].elementSize);
                        break;
                    case "腐蚀":      //此处对面积在一定范围内的斑点进行腐蚀
                        HOperatorSet.CountObj(resultRegion, out num);
                        HObject tempRegion;
                        HOperatorSet.GenEmptyRegion(out tempRegion);
                        for (int j = 0; j < num; j++)
                        {
                            HObject region;
                            HOperatorSet.SelectObj(resultRegion, out region, new HTuple(j + 1));
                            HTuple area, row, col;
                            HOperatorSet.AreaCenter(region, out area, out row, out col);
                            if (L_processing[i].minArea < area.I && area.I < L_processing[i].maxArea)
                                HOperatorSet.ErosionCircle(region, out region, new HTuple(L_processing[i].elementSize));
                            HOperatorSet.Union2(tempRegion, region, out tempRegion);
                        }
                        resultRegion = tempRegion;
                        HOperatorSet.Connection(resultRegion, out resultRegion);
                        break;
                    case "膨胀":      //此处对面积在一定范围内的斑点进行膨胀
                        HOperatorSet.Connection(resultRegion, out resultRegion);
                        HOperatorSet.CountObj(resultRegion, out num);
                        HOperatorSet.GenEmptyRegion(out tempRegion);
                        for (int j = 0; j < num; j++)
                        {
                            HObject region;
                            HOperatorSet.SelectObj(resultRegion, out region, new HTuple(j + 1));
                            HTuple area, row, col;
                            HOperatorSet.AreaCenter(region, out area, out row, out col);
                            if (L_processing[i].minArea < area.I && area.I < L_processing[i].maxArea)
                                HOperatorSet.DilationCircle(region, out region, new HTuple(L_processing[i].elementSize));
                            HOperatorSet.Union2(tempRegion, region, out tempRegion);
                        }
                        resultRegion = tempRegion;
                        HOperatorSet.Connection(resultRegion, out resultRegion);
                        break;
                    case "填充":
                        HOperatorSet.FillUp(resultRegion, out resultRegion);
                        break;
                    case "填凹":
                        HOperatorSet.ShapeTrans(resultRegion, out resultRegion, "convex");
                        break;
                }
            }
            HOperatorSet.Connection(resultRegion, out resultRegion);

            //结果区域联合
            HOperatorSet.Union1(resultRegion, out  resultRegion);
            HOperatorSet.Connection(resultRegion, out resultRegion);

            //把结果区域和搜索区域取一下交集，保证结果区域都在搜索区域之内，防止因膨胀导致结果区域超出搜索区域的情况
            if (searchRegionType != RegionType.整幅图像)
            {
                HOperatorSet.Intersection(resultRegion, searchRegionAfterTransed, out resultRegion);
                HOperatorSet.Connection(resultRegion, out resultRegion);
            }

            //当没有一个结果区域时它也会显示有一个结果，面积是0，所有我们需要过滤一下，把这个结果过滤掉
            HOperatorSet.SelectShape(resultRegion, out resultRegion, "area", "and", 1, 100000000);

            //斑点筛选
            if (areaSelect)
                HOperatorSet.SelectShape(resultRegion, out resultRegion, "area", "and", minRunArea, maxRunArea);
            if (roundnessSelect)
                HOperatorSet.SelectShape(resultRegion, out resultRegion, "roundness", "and", minRoundness, maxRoundness);

            HOperatorSet.Connection(resultRegion, out resultRegion);
            ((ToolPar)参数).输出.区域 = resultRegion;

            //显示结果区域
            if (showResultRegion)
            {
                GetImageWindow().DispObj(resultRegion, "green");
                if (Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
                {
                    HOperatorSet.SetDraw(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, "margin");
                    Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(resultRegion, "green");
                }
            }

            //显示相关辅助图像
            HTuple blobNum = 0;
            HOperatorSet.CountObj(resultRegion, out blobNum);

            L_blobResult.Clear();
            ((ToolPar)参数).输出.位置.Clear();
            for (int i = 0; i < blobNum; i++)
            {
                HObject region;
                HOperatorSet.SelectObj(resultRegion, out region, new HTuple(i + 1));

                HTuple area3, row3, col3, radius3;
                HOperatorSet.AreaCenter(region, out area3, out row3, out col3);
                HOperatorSet.SmallestCircle(region, out row3, out col3, out radius3);

                BlobResult blobResult = new BlobResult();
                blobResult.Row = Math.Round(row3.D, 2);
                blobResult.Col = Math.Round(col3.D, 2);
                blobResult.Area = Math.Round(area3.D, 2);
                blobResult.CircumcircleRadius = Math.Round(radius3.D, 2);
                blobResult.region = region;
                L_blobResult.Add(blobResult);

                XY xy = new XY();
                xy.X = L_blobResult[i].Row;
                xy.Y = L_blobResult[i].Col;
                ((ToolPar)参数).输出.位置.Add(xy);
            }

            //排序
            BlobResult temp;
            SortMode sortMode = SortMode.面积;
            switch (sortMode)
            {
                case SortMode.面积:

                    for (int i = 0; i < L_blobResult.Count - 1; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if (L_blobResult[i].Area < L_blobResult[j].Area)
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }
                    break;

                case SortMode.从上至下且从左至右:

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if (L_blobResult[i].Row - L_blobResult[j].Row > spacing / 2)
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if ((L_blobResult[i].Col - L_blobResult[j].Col > spacing / 2) && (Math.Abs(L_blobResult[i].Row - L_blobResult[j].Row) < spacing / 2))
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }
                    break;

                case SortMode.从左至右且从上至下:

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if (L_blobResult[i].Col - L_blobResult[j].Col > spacing / 2)
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if ((L_blobResult[i].Row - L_blobResult[j].Row > spacing / 2) && (Math.Abs(L_blobResult[i].Col - L_blobResult[j].Col) < spacing / 2))
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }
                    break;

                case SortMode.从上至下且从右至左:

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if (L_blobResult[i].Row - L_blobResult[j].Row > spacing / 2)
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if ((L_blobResult[i].Col - L_blobResult[j].Col < spacing / 2) && (Math.Abs(L_blobResult[i].Row - L_blobResult[j].Row) < spacing / 2))
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }
                    break;

                case SortMode.从左至右且从下至上:

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if (L_blobResult[i].Col - L_blobResult[j].Col < spacing / 2)
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }

                    for (int i = 0; i < L_blobResult.Count; i++)
                    {
                        for (int j = i + 1; j < L_blobResult.Count; j++)
                        {
                            if ((L_blobResult[i].Row - L_blobResult[j].Row > spacing / 2) && (Math.Abs(L_blobResult[i].Col - L_blobResult[j].Col) < spacing / 2))
                            {
                                temp = L_blobResult[i];
                                L_blobResult[i] = L_blobResult[j];
                                L_blobResult[j] = temp;
                            }
                        }
                    }
                    break;

            }

            //开始做区域比较
            HObject defectRegion = null;
            HOperatorSet.GenEmptyRegion(out defectRegion);
            L_defectResult.Clear();

            //断胶和少胶检测
            HObject brokenGlueRegion = null;
            HObject lackGlueRegion = null;
            HOperatorSet.GenEmptyRegion(out brokenGlueRegion);
            HOperatorSet.GenEmptyRegion(out lackGlueRegion);
            int brokenGlueNum = 0, lackGlueNum = 0;

            if (lackGlueDetect)
            {
                HOperatorSet.Difference(standardRegionAfterTransed, resultRegion, out lackGlueRegion);

                //连通
                HOperatorSet.Connection(lackGlueRegion, out lackGlueRegion);

                HOperatorSet.ErosionRectangle1(lackGlueRegion, out lackGlueRegion, corrosSize, corrosSize);
                HOperatorSet.Connection(lackGlueRegion, out lackGlueRegion);

                //筛选出面积大于指定值的缺陷区域
                HOperatorSet.SelectShape(lackGlueRegion, out lackGlueRegion, "area", "and", maxDefectArea, 1000000);

                //显示缺陷
                for (int i = 0; i < lackGlueRegion.CountObj(); i++)
                {
                    HObject region;
                    HOperatorSet.SelectObj(lackGlueRegion, out region, i + 1);
                    HTuple row, col, radius;
                    HOperatorSet.SmallestCircle(region, out row, out col, out radius);
                    HObject circle;
                    HOperatorSet.GenCircle(out circle, row, col, radius + 10 > 40 ? radius + 40 : (HTuple)60);
                    HTuple row4, col4, area4;
                    HOperatorSet.AreaCenter(region, out area4, out row4, out col4);

                    //区分断胶和少胶，原理：其实断胶也属于是少胶的一类，断胶和少胶的区别在于，断胶区域如果加上少的这块区域则总的区域会减少一个，少胶区域加上少的这块总的区域不会减少，我们就可以从这个区别上入手做判定
                    HTuple regionNum;
                    HOperatorSet.CountObj(resultRegion, out regionNum);

                    HObject tempResultRegion = null;
                    HOperatorSet.GenEmptyRegion(out tempResultRegion);
                    HOperatorSet.Union2(region, resultRegion, out tempResultRegion);
                    HOperatorSet.DilationRectangle1(tempResultRegion, out tempResultRegion, corrosSize, corrosSize);
                    HOperatorSet.Connection(tempResultRegion, out tempResultRegion);

                    HTuple regionNumAfterFill;
                    HOperatorSet.CountObj(tempResultRegion, out regionNumAfterFill);
                    if (regionNumAfterFill.I + 1 == regionNum.I)
                    {
                        brokenGlueNum++;
                        if (trigedByTool && Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
                        {
                            if (showCircleMark)
                                Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(circle, "orange");
                            HalconLib.DispText(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, "断胶", 12, row + radius + 40, col - 38, "red", "false");
                        }
                        if (showCircleMark && Frm_MatchTool.hasShown && Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
                            Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(circle, "orange");
                        GetImageWindow().DispObj(circle, "orange");
                        HalconLib.DispText(GetImageWindow().HWindowHalconID, "断胶", 12, row + radius + 40, col - 38, "red", "false");

                        DefectResult defectResult = new DefectResult();
                        defectResult.defectType = DefectType.断胶;
                        defectResult.Area = area4;
                        defectResult.Row = row4;
                        defectResult.Col = col4;
                        defectResult.radius = radius;
                        defectResult.region = region;
                        L_defectResult.Add(defectResult);
                    }
                    else
                    {
                        lackGlueNum++;
                        if (Frm_MatchTool.hasShown && Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
                        {
                            Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(circle, "orange");
                            HalconLib.DispText(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, "少胶", 12, row + radius + 20, col - 38, "red", "false");
                        }
                        GetImageWindow().DispObj(circle, "orange");
                        HalconLib.DispText(GetImageWindow().HWindowHalconID, "少胶", 12, row + radius + 20, col - 38, "red", "false");

                        DefectResult defectResult = new DefectResult();
                        defectResult.defectType = DefectType.少胶;
                        defectResult.Area = area4;
                        defectResult.Row = row4;
                        defectResult.Col = col4;
                        defectResult.radius = radius;
                        defectResult.region = region;
                        L_defectResult.Add(defectResult);
                    }

                }
            }

            //多胶检测
            HObject multiGlueRegion = null;
            HOperatorSet.GenEmptyRegion(out multiGlueRegion);
            int multiGlueNum = 0;

            if (multiGlueDetect)
            {
                HOperatorSet.Difference(TemplateRegion, resultRegion, out multiGlueRegion);

                //连通
                HOperatorSet.Connection(multiGlueRegion, out multiGlueRegion);

                //筛选出面积大于指定值的缺陷区域
                HOperatorSet.SelectShape(multiGlueRegion, out multiGlueRegion, "area", "and", maxDefectArea, 1000000);

                //显示缺陷
                for (int i = 0; i < multiGlueRegion.CountObj(); i++)
                {
                    multiGlueNum++;
                    HObject region;
                    HOperatorSet.SelectObj(multiGlueRegion, out region, i + 1);
                    HTuple row, col, radius;
                    HOperatorSet.SmallestCircle(region, out row, out col, out radius);
                    HObject circle;
                    HOperatorSet.GenCircle(out circle, row, col, radius + 10 > 100 ? radius + 10 : (HTuple)100);
                    if (trigedByTool && Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
                    {
                        Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(circle, "red");
                        HalconLib.DispText(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, "少胶", 10, row + radius + 20, col - 38, "red", "false");
                    }
                }
            }

            HOperatorSet.Union2(brokenGlueRegion, lackGlueRegion, out lackGlueRegion);
            HOperatorSet.Union2(lackGlueRegion, multiGlueRegion, out defectRegion);

            if (showDefectMargin)
            {
                GetImageWindow().DispObj(defectRegion, "red");
                if (trigedByTool && Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
                    Frm_GlueDetectTool.Instance.hWindow_Final1.DispObj(defectRegion, "red");
            }

            //赋值到输出参数
            ((ToolPar)参数).输出.数量 = brokenGlueNum + lackGlueNum + multiGlueNum;

            if (((ToolPar)参数).输出.数量 == 0)
                ((ToolPar)参数).输出.结果 = "OK";
            else
                ((ToolPar)参数).输出.结果 = "NG";

            //在界面显示斑点结果
            HTuple width, height;
            HOperatorSet.GetImageSize(((ToolPar)参数).输入.图像, out width, out height);
            if ( Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
            {
                Frm_GlueDetectTool.Instance.dgv_result.Rows.Clear();
                for (int i = 0; i < L_defectResult.Count; i++)
                {
                    int index = Frm_GlueDetectTool.Instance.dgv_result.Rows.Add();
                    Frm_GlueDetectTool.Instance.dgv_result.Rows[index].Cells[0].Value = i + 1;
                    Frm_GlueDetectTool.Instance.dgv_result.Rows[index].Cells[1].Value = L_defectResult[i].defectType;
                    Frm_GlueDetectTool.Instance.dgv_result.Rows[index].Cells[2].Value = Math.Round(L_defectResult[i].Area, 2);
                    Frm_GlueDetectTool.Instance.dgv_result.Rows[index].Cells[3].Value = Math.Round(L_defectResult[i].Row, 2);
                    Frm_GlueDetectTool.Instance.dgv_result.Rows[index].Cells[4].Value = Math.Round(L_defectResult[i].Col, 2);
                }
                Frm_GlueDetectTool.Instance.lbl_regionNum.Text = ((ToolPar)参数).输出.数量.ToString() + " 个";
                Frm_GlueDetectTool.Instance.lbl_runResult.Text = ((ToolPar)参数).输出.结果;
                HalconLib.DispText(Frm_GlueDetectTool.Instance.hWindow_Final1.HWindowHalconID, ((ToolPar)参数).输出.结果, 40, height - 150, 40, ((ToolPar)参数).输出.结果 == "OK" ? "green" : "red", "false");
            }
            HalconLib.DispText(GetImageWindow().HWindowHalconID, ((ToolPar)参数).输出.结果, 40, height - 300, 40, ((ToolPar)参数).输出.结果 == "OK" ? "green" : "red", "false");






            //临时添加
            if (taskName == "左侧工位")
                ((ToolPar)参数).输出.结果 += "L";
            else
                ((ToolPar)参数).输出.结果 += "R";

            if (((ToolPar)参数).输出.结果.Substring(0, 2) == "NG")
            {
                toolRunStatu = "检测NG";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }




            sw.Stop();
            toolRunStatu = "运行成功";
        Exit:
            if (Frm_MatchTool.hasShown && Frm_GlueDetectTool.hasShown && Frm_GlueDetectTool.taskName == taskName && Frm_GlueDetectTool.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_GlueDetectTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());

                if (toolRunStatu == "运行成功")
                    Frm_GlueDetectTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                else
                    Frm_GlueDetectTool.Instance.lbl_toolTip.ForeColor = Color.Red;

                Frm_GlueDetectTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
            }
        }

        #region 工具参数
        [Serializable]
        public class ToolPar : ToolParBase
        {
            private P输入 _输入 = new P输入();
            public P输入 输入
            {
                get { return _输入; }
                set { _输入 = value; }
            }

            private P运行 _运行 = new P运行();
            public P运行 运行
            {
                get { return _运行; }
                set { _运行 = value; }
            }

            private P输出 _输出 = new P输出();
            public P输出 输出
            {
                get { return _输出; }
                set { _输出 = value; }
            }
        }
        [Serializable]
        public class P输入
        {
            private HObject _图像;
            public HObject 图像
            {
                get { return _图像; }
                set { _图像 = value; }
            }

            private List<XYU> _跟随 = new List<XYU>();
            public List<XYU> 跟随
            {
                get { return _跟随; }
                set { _跟随 = value; }
            }
            private HObject _区域;
            public HObject 区域
            {
                get { return _区域; }
                set { _区域 = value; }
            }

        }
        [Serializable]
        public class P运行 { }
        [Serializable]
        internal class P输出
        {
            private int _数量;
            public int 数量
            {
                get { return _数量; }
                set { _数量 = value; }
            }

            private List<XY> _位置 = new List<XY>();
            public List<XY> 位置
            {
                get { return _位置; }
                set { _位置 = value; }
            }

            private HObject _区域;
            public HObject 区域
            {
                get { return _区域; }
                set { _区域 = value; }
            }
            private string _结果 = string.Empty;
            public string 结果
            {
                get { return _结果; }
                set { _结果 = value; }
            }
        }
        #endregion

    }
    /// <summary>
    /// 不良结果
    /// </summary>
    [Serializable]
    internal struct DefectResult
    {
        internal DefectType defectType;
        internal double Area;
        internal double Row;
        internal double Col;
        internal double radius;
        internal HObject region;
    }
    /// <summary>
    /// 预处理项
    /// </summary>
    [Serializable]
    internal class Processing
    {
        internal string processingType;
        internal string elementType;
        internal Int32 elementSize;
        internal Int32 minArea;
        internal Int32 maxArea;
        internal bool enable;
    }
    /// <summary>
    /// 斑点分析工具结果
    /// </summary>
    [Serializable]
    internal struct BlobResult
    {
        internal double Row;
        internal double Col;
        internal double Area;
        internal double CircumcircleRadius;
        internal HObject region;
    }
    /// <summary>
    /// 不良类型    断胶|少胶|多胶
    /// </summary>
    public enum DefectType
    {
        断胶,
        少胶,
        多胶,
    }
}
