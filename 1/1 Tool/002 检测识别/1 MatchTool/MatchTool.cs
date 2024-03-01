using HalconDotNet;
using Ookii.Dialogs.WinForms;
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

namespace VM_Pro
{
    [Serializable]
    /// <summary>
    /// 模板匹配
    /// </summary>
    internal class MatchTool : ToolBase
    {
        internal MatchTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

            HOperatorSet.GenEmptyObj(out templateRegion);

            //自动连接输入
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.采集图像)
                {
                    InputItem inputItem = new InputItem();
                    inputItem.InputName = "图像";
                    inputItem.inputType = DataType.Image;
                    //属于当前工具定义的信息
                    inputItem.sourceTask = taskName;
                    inputItem.sourceTool = Task.curTask.L_toolList[i].toolName;
                    inputItem.sourceOutput = "图像";

                    L_inputItem.Add(inputItem);
                    break;
                }
            }
        }



        /// <summary>
        /// 安全范围
        /// </summary>
        internal HObject safetyRegion;
        /// <summary>
        /// 最后一次运行的模板轮廓
        /// </summary>
        internal HObject lastRunTemplate;
        /// <summary>
        /// 最后一次运行的模板中心
        /// </summary>
        internal HObject lastRunCross;
        /// <summary>
        /// 最后一次运行的索引
        /// </summary>
        internal string lastRunIndex;
        /// <summary>
        /// 模板角度
        /// </summary>
        internal double templateAngle = 0;
        /// <summary>
        /// 模板原点
        /// </summary>
        internal XY firstTemplateCenter = new XY();
        /// <summary>
        /// 是否正在绘制模板
        /// </summary>
        internal static bool isDrawing = false;
        /// <summary>
        /// 工具锁
        /// </summary>
        private object obj = new object();
        /// <summary>
        /// 模板是否已创建
        /// </summary>
        internal bool templateCreated = false;
        /// <summary>
        /// 匹配模式
        /// </summary>
        internal MatchMode matchMode = MatchMode.BasedGray;
        /// <summary>
        /// 最小匹配分数
        /// </summary>
        internal double minScore = 0.5;
        /// <summary>
        /// 匹配个数
        /// </summary>
        internal int matchNum = 1;
        /// <summary>
        /// 搜索区域类型
        /// </summary>
        internal RegionType searchRegionType = RegionType.整幅图像;
        /// <summary>
        /// 模板区域类型
        /// </summary>
        internal RegionType templateRegonType = RegionType.圆;
        /// <summary>
        /// 是否启用匹配结果安全管控范围
        /// </summary>
        internal bool enableSafetyRange = false;
        /// <summary>
        /// 匹配结果安全管控范围
        /// </summary>
        internal int safetyRange = 100;
        /// <summary>
        /// 做模板时的图像
        /// </summary>
        internal HObject templateImage;
        /// <summary>
        /// 最小缩放
        /// </summary>
        internal double minScale = 0.8;
        /// <summary>
        /// 最大缩放
        /// </summary>
        internal double maxScale = 1.2;
        /// <summary>
        /// 是否显示匹配到的模板
        /// </summary>
        internal bool showTemplate = true;
        /// <summary>
        /// 是否显示特征
        /// </summary>
        internal bool showFeature = true;
        /// <summary>
        /// 是否显示搜索区域
        /// </summary>
        internal bool showSearchRegion = true;
        /// <summary>
        /// 是否显示中心十字架
        /// </summary>
        internal bool showCross = true;
        /// <summary>
        /// 显示结果序号
        /// </summary>
        internal bool showIndex = true;
        /// <summary>
        /// 是否显示分数
        /// </summary>
        internal bool showScore = true;
        /// <summary>
        /// 排序模式
        /// </summary>
        internal MatchSortMode sortMode = MatchSortMode.分数;
        /// <summary>
        /// 角度范围
        /// </summary>
        internal int angleRange = 30;
        /// <summary>
        /// 角度步长
        /// </summary>
        internal int angleStep = 1;
        /// <summary>
        /// 对比度
        /// </summary>
        internal int contrast = 30;
        /// <summary>
        /// 极性
        /// </summary>
        internal string polarity = "use_polarity";
        /// <summary>
        /// 模板区域
        /// </summary>
        internal HObject templateRegion;
        /// <summary>
        /// 基于灰度匹配的模板句柄集合
        /// </summary>
        internal static Dictionary<string, HTuple> D_nccModel = new Dictionary<string, HTuple>();
        /// <summary>
        /// 基于轮廓匹配的模板句柄集合
        /// </summary>
        internal static Dictionary<string, HTuple> D_shapeModel = new Dictionary<string, HTuple>();
        /// <summary>
        /// 搜索区域
        /// </summary>
        internal List<ViewWindow.Model.ROI> L_regions = new List<ROI>();
        /// <summary>
        /// 匹配结果
        /// </summary>
        internal List<MatchResult> L_result = new List<MatchResult>();
        /// <summary>
        /// 模板中心坐标
        /// </summary>
        public List<XYU> L_templateCenter = new List<XYU>();


        /// <summary>
        /// 复位工具
        /// </summary>
        internal override void ResetTool()
        {
            templateCreated = false;
            templateRegion = null;
            templateRegion = null;
            templateImage = null;
            L_regions = new List<ROI>();

            matchMode = MatchMode.BasedGray;
            minScore = 0.6;
            matchNum = 1;
            searchRegionType = RegionType.整幅图像;
            enableSafetyRange = false;
            safetyRange = 100;
            showTemplate = true;
            showFeature = true;
            showSearchRegion = true;
            showCross = true;
            showIndex = false;
            sortMode = MatchSortMode.从上至下且从左至右;

            HOperatorSet.ClearWindow(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID);
            HOperatorSet.ClearWindow(Frm_MatchTool.Instance.hWindowControl1.HalconWindow);
            Frm_MatchTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
            Frm_MatchTool.Instance.hWindow_Final1.DispImageFit();

            HTuple handle = FindModelHandle();
            if (handle != -1)
            {
                if (matchMode == MatchMode.BasedGray)
                    HOperatorSet.ClearNccModel(handle);
                else
                    HOperatorSet.ClearShapeModel(handle);
            }
            RemoveModelHandle();

            Frm_MatchTool.Instance.uiTabControl1.SelectedIndex = 0;
            Frm_MatchTool.Instance.cbx_templateLibrary.Items.Clear();
            Frm_MatchTool.Instance.cbx_templateLibrary.Items.Add("模板1");
            Frm_MatchTool.Instance.cbx_templateLibrary.SelectedIndex = 0;
            Frm_MatchTool.Instance.rdo_basedGray.Checked = true;
            Frm_MatchTool.Instance.rdo_addTemplateRegion.Checked = true;
            Frm_MatchTool.Instance.nud_matchScore.Value = 0.6;
            Frm_MatchTool.Instance.nud_matchNum.Value = 1;
            Frm_MatchTool.Instance.cbx_searchRegionType.SelectedIndex = 0;
            Frm_MatchTool.Instance.ckb_safetyRange.Checked = false;
            Frm_MatchTool.Instance.nud_safetyRange.Value = 100;
            Frm_MatchTool.Instance.ckb_showTemplateContour.Checked = true;
            Frm_MatchTool.Instance.ckb_showFeature.Checked = true;
            Frm_MatchTool.Instance.ckb_showSearchRegion.Checked = true;
            Frm_MatchTool.Instance.ckb_showCross.Checked = true;
            Frm_MatchTool.Instance.ckb_showIndex.Checked = false;
            Frm_MatchTool.Instance.cbx_sortMode.SelectedIndex = 0;
            Frm_MatchTool.Instance.dgv_result.Rows.Clear();

            Frm_MatchTool.Instance.lbl_runTime.Text = "0 ms";
            Frm_MatchTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
            Frm_MatchTool.Instance.lbl_toolTip.Text = "暂无提示";
        }
        /// <summary>
        /// 查找模板句柄
        /// </summary>
        /// <returns></returns>
        internal HTuple FindModelHandle()
        {
            if (matchMode == MatchMode.BasedGray)
            {
                foreach (KeyValuePair<string, HTuple> item in D_nccModel)
                {
                    if (item.Key == string.Format("{0}.{1}.{2}", Scheme.curScheme.name, taskName, toolName))
                    {
                        return item.Value;
                    }

                }
            }
            else
            {
                foreach (KeyValuePair<string, HTuple> item in D_shapeModel)
                {
                    //if (item.Key == string.Format("{0}.{1}.{2}", Scheme.curScheme, taskName, toolName))
                    //string ss = string.Format("{0}.{1}" ,taskName,toolName);
                    if (item.Key == string.Format("{0}.{1}", taskName, toolName))
                        return item.Value;
                }
            }
            return null;
        }
        /// <summary>
        /// 移除模板
        /// </summary>
        internal void RemoveModelHandle()
        {
            if (matchMode == MatchMode.BasedGray)
            {
                foreach (KeyValuePair<string, HTuple> item in D_nccModel)
                {
                    if (item.Key == string.Format("{0}.{1}.{2}", Scheme.curScheme.name, taskName, toolName))
                    {
                        D_nccModel.Remove(item.Key);
                        break;
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<string, HTuple> item in D_shapeModel)
                {
                    if (item.Key == string.Format("{0}.{1}", taskName, toolName))
                    {
                        D_shapeModel.Remove(item.Key);
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 创建模板
        /// </summary>
        internal void CreateTemplate(bool showTemplate = true)
        {
            if (!templateCreated)
                templateImage = ((ToolPar)参数).输入.图像;

            if (templateImage == null)
            {
                templateCreated = false;
                return;
            }

            HObject imageReduced;
            HOperatorSet.ReduceDomain(templateImage, templateRegion, out imageReduced);
            HTuple modelID = null;

            try
            {
                if (matchMode == MatchMode.BasedShape)
                {

                    HOperatorSet.CreateScaledShapeModel(imageReduced,
                                                       "auto",
                                                       ((HTuple)(-angleRange / 2)).TupleRad(),
                                                       ((HTuple)angleRange).TupleRad(),
                                                       "auto",
                                                        minScale,
                                                        maxScale,
                                                       "auto",
                                                       "auto",
                                                        polarity,
                                                       "auto",
                                                       "auto",
                                                  out modelID);
                    if (D_shapeModel.ContainsKey(string.Format("{0}.{1}", taskName, toolName)))
                        D_shapeModel[string.Format("{0}.{1}", taskName, toolName)] = modelID;
                    else
                        D_shapeModel.Add(string.Format("{0}.{1}", taskName, toolName), modelID);
                }
                else
                {
                    HOperatorSet.CreateNccModel(imageReduced,
                                                "auto",
                                                ((HTuple)(-angleRange / 2)).TupleRad(),
                                                ((HTuple)angleRange).TupleRad(),
                                                "auto",
                                                "use_polarity",
                                                 out modelID);
                    if (D_nccModel.ContainsKey(string.Format("{0}.{1}.{2}", Scheme.curScheme.name, taskName, toolName)))
                        D_nccModel[string.Format("{0}.{1}.{2}", Scheme.curScheme.name, taskName, toolName)] = modelID;
                    else
                        D_nccModel.Add(string.Format("{0}.{1}.{2}", Scheme.curScheme.name, taskName, toolName), modelID);
                }
                templateCreated = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("#8510:"))      //特征过少，Halcon报错编号8510
                {
                    templateCreated = false;
                    Frm_MatchTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                    Frm_MatchTool.Instance.lbl_toolTip.Text = "特征过少，无法完成训练，请重新绘制模板区域";
                    return;
                }
            }

            //指定模板原点
            HTuple row, col, area;
            HOperatorSet.AreaCenter(templateRegion, out area, out row, out col);

            //此处需对row跟col做异常防呆，不然当为空时，会出现异常
            if (row.Length <= 0 || col.Length <= 0)
            {
                FuncLib.ShowMessageBox("当前模板区域为空，请重新绘制区域", InfoType.Error);
                return;
            }


            if (firstTemplateCenter.X == 0 && firstTemplateCenter.Y == 0)
            {
                firstTemplateCenter = new XY(row, col);
            }
            else
            {
                if (matchMode == MatchMode.BasedGray)
                    HOperatorSet.SetNccModelOrigin(FindModelHandle(), firstTemplateCenter.X - row, firstTemplateCenter.Y - col);
                else
                    HOperatorSet.SetShapeModelOrigin(FindModelHandle(), row + firstTemplateCenter.X, col + firstTemplateCenter.Y);
            }
            if (matchMode == MatchMode.BasedShape)
            {
                HOperatorSet.GetShapeModelOrigin(FindModelHandle(), out row, out col);
            }
            else
            {
                HOperatorSet.GetNccModelOrigin(FindModelHandle(), out row, out col);
            }
            if (matchMode == MatchMode.BasedShape)
            {
                HObject contour;
                HOperatorSet.GetShapeModelContours(out contour, FindModelHandle(), 1);
                HOperatorSet.AreaCenter(templateRegion, out area, out row, out col);

                HTuple homMat2D;
                HOperatorSet.HomMat2dIdentity(out homMat2D);
                HOperatorSet.HomMat2dTranslate(homMat2D, row, col, out homMat2D);
                HOperatorSet.AffineTransContourXld(contour, out contour, homMat2D);
            }

            if (showTemplate)
                ShowTemplateAtSmallWindow();
            HOperatorSet.SetSystem("flush_graphic", "false");
        }
        /// <summary>
        /// 在模板窗口显示模板
        /// </summary>
        internal void ShowTemplateAtSmallWindow()
        {
            if (!templateCreated)
            {
                HOperatorSet.ClearWindow(Frm_MatchTool.Instance.hWindowControl1.HalconWindow);
                return;
            }

            HTuple row1, col1, row2, col2;
            HOperatorSet.SmallestRectangle1(templateRegion, out row1, out col1, out row2, out col2);
            HObject rect;
            HOperatorSet.GenRectangle1(out rect, row1 - (templateRegonType == RegionType.仿射矩形 ? 60 : 20), col1 - (templateRegonType == RegionType.仿射矩形 ? 60 : 20), row2 + (templateRegonType == RegionType.仿射矩形 ? 60 : 20), col2 + (templateRegonType == RegionType.仿射矩形 ? 60 : 20));


            HTuple ROW11 = row1 - (templateRegonType == RegionType.仿射矩形 ? 60 : 20);
            HTuple COLL1 = col1 - (templateRegonType == RegionType.仿射矩形 ? 60 : 20);
            HTuple ROWW2 = col2 - col1 + (templateRegonType == RegionType.仿射矩形 ? 120 : 40);
            HTuple COLL2 = row2 - row1 + (templateRegonType == RegionType.仿射矩形 ? 120 : 40);
            if (ROW11.D < 0)
            {
                ROW11 = ROW11 * -1;
            }
            //HOperatorSet.CropPart(templateImage, out rect, row1 - (templateRegonType == RegionType.仿射矩形 ? 60 : 20), col1 - (templateRegonType == RegionType.仿射矩形 ? 60 : 20), col2 - col1 + (templateRegonType == RegionType.仿射矩形 ? 120 : 40), row2 - row1 + (templateRegonType == RegionType.仿射矩形 ? 120 : 40));
            HOperatorSet.CropPart(templateImage, out rect, ROW11, COLL1, ROWW2, COLL2);

            HOperatorSet.ClearWindow(Frm_MatchTool.Instance.hWindowControl1.HalconWindow);

            double rate = (row2 - row1) / (col2 - col1);
            double value = 0;
            if (rate > 0.75)
                value = (row2 - row1 + (searchRegionType == RegionType.仿射矩形 ? 120 : 40)) / 148.0;
            else
                value = (col2 - col1 + (searchRegionType == RegionType.仿射矩形 ? 120 : 40)) / 198.0;
            HOperatorSet.SetPart(Frm_MatchTool.Instance.hWindowControl1.HalconWindow, -(148 * value - (row2 - row1 + (templateRegonType == RegionType.仿射矩形 ? 120 : 40))) / 2, -(198 * value - (col2 - col1 + (templateRegonType == RegionType.仿射矩形 ? 120 : 40))) / 2, 148 * value - (148 * value - (row2 - row1 + (templateRegonType == RegionType.仿射矩形 ? 120 : 40))) / 2, 198 * value - (198 * value - (col2 - col1 + (templateRegonType == RegionType.仿射矩形 ? 120 : 40))) / 2);
            HOperatorSet.DispObj(rect, Frm_MatchTool.Instance.hWindowControl1.HalconWindow);

            HOperatorSet.SetDraw(Frm_MatchTool.Instance.hWindowControl1.HalconWindow, new HTuple("margin"));
            HOperatorSet.SetColor(Frm_MatchTool.Instance.hWindowControl1.HalconWindow, new HTuple("green"));
            HOperatorSet.SetLineStyle(Frm_MatchTool.Instance.hWindowControl1.HalconWindow, new HTuple());
            HObject tempTemplateRegion;
            HOperatorSet.MoveRegion(templateRegion, out tempTemplateRegion, -(row1 - (templateRegonType == RegionType.仿射矩形 ? 60 : 20)), -(col1 - (templateRegonType == RegionType.仿射矩形 ? 60 : 20)));

            //挖去内部区域
            HObject tempRegion1 = null;
            HOperatorSet.FillUp(tempTemplateRegion, out tempRegion1);
            HObject tempRegion2 = null;
            HOperatorSet.Difference(tempRegion1, tempTemplateRegion, out tempRegion2);
            HOperatorSet.GenContourRegionXld(tempRegion2, out tempRegion2, "border");

            HOperatorSet.DispObj(tempRegion1, Frm_MatchTool.Instance.hWindowControl1.HalconWindow);
            HOperatorSet.SetColor(Frm_MatchTool.Instance.hWindowControl1.HalconWindow, "coral");
            HOperatorSet.SetLineStyle(Frm_MatchTool.Instance.hWindowControl1.HalconWindow, new HTuple(16, 7, 3, 7));
            HOperatorSet.DispObj(tempRegion2, Frm_MatchTool.Instance.hWindowControl1.HalconWindow);

            //显示模板原点
            HTuple row11, col11, row22, col22;
            HOperatorSet.SmallestRectangle1(templateRegion, out row11, out col11, out row22, out col22);
            HObject cross;
            HOperatorSet.GenCrossContourXld(out cross, firstTemplateCenter.X - (row11 - (templateRegonType == RegionType.仿射矩形 ? 60 : 20)), firstTemplateCenter.Y - (col11 - (templateRegonType == RegionType.仿射矩形 ? 60 : 20)), (row2 - row1) / 20, 0);
            HOperatorSet.SetDraw(Frm_MatchTool.Instance.hWindowControl1.HalconWindow, "margin");
            HOperatorSet.SetColor(Frm_MatchTool.Instance.hWindowControl1.HalconWindow, "green");
            HOperatorSet.SetLineStyle(Frm_MatchTool.Instance.hWindowControl1.HalconWindow, new HTuple());
            HOperatorSet.DispObj(cross, Frm_MatchTool.Instance.hWindowControl1.HalconWindow);

            if (matchMode == MatchMode.BasedShape)
            {
                HObject contour;
                HOperatorSet.GetShapeModelContours(out contour, FindModelHandle(), 1);

                HTuple area, row, col;
                HOperatorSet.AreaCenter(templateRegion, out area, out row, out col);

                HTuple homMat2D;
                HOperatorSet.HomMat2dIdentity(out homMat2D);
                HOperatorSet.HomMat2dTranslate(homMat2D, row, col, out homMat2D);
                HOperatorSet.AffineTransContourXld(contour, out contour, homMat2D);
                HOperatorSet.SetColor(Frm_MatchTool.Instance.hWindowControl1.HalconWindow, new HTuple("orange"));
                HOperatorSet.DispObj(contour, Frm_MatchTool.Instance.hWindowControl1.HalconWindow);
            }
        }
        /// <summary>
        /// 绘制模板区域
        /// </summary>
        /// <param name="regionType">区域类型</param>
        internal void DrawTemplateRegion(RegionType regionType)
        {
            Thread th = new Thread(() =>
            {
                if (isDrawing)
                {
                    isDrawing = false;
                    HalconLib.HIOCancelDraw();
                }

                isDrawing = true;
                if (!templateCreated)
                    Frm_MatchTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
                else
                    Frm_MatchTool.Instance.hWindow_Final1.HobjectToHimage(templateImage);

                Frm_MatchTool.Instance.hWindow_Final1.DispObj(templateRegion, "green");
                Frm_MatchTool.Instance.hWindow_Final1.Focus();
                HOperatorSet.SetDraw(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, "margin");

                HTuple row1, col1, row2, col2;
                HOperatorSet.GetPart(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                HalconLib.DispText(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, "请在图像窗口中绘制模板区域，绘制结束后右击图像窗口", 13, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "blue", "false");

                if (Frm_MatchTool.Instance.rdo_addTemplateRegion.Checked)
                    HOperatorSet.SetColor(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, "green");
                else
                    HOperatorSet.SetColor(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, "coral");
                Frm_MatchTool.Instance.hWindow_Final1.ContextMenuStrip = null;
                Frm_MatchTool.Instance.hWindow_Final1.DrawModel = true;
                Frm_MatchTool.Instance.btn_studyTemplate.Enabled = false;
                Frm_MatchTool.Instance.btn_runTool.Enabled = false;

                HObject region = null;
                switch (regionType)
                {
                    case RegionType.矩形:
                        HTuple row, col, row3, col3;
                        HOperatorSet.DrawRectangle1(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out row3, out col3);
                        if (row.D == 0 && col.D == 0)
                            return;
                        HOperatorSet.GenRectangle1(out region, row, col, row3, col3);
                        break;

                    case RegionType.仿射矩形:
                        HTuple angle, length1, length2;
                        HOperatorSet.DrawRectangle2(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out angle, out length1, out length2);
                        if (row.D == 0 && col.D == 0)
                            return;
                        HOperatorSet.GenRectangle2(out region, row, col, angle, length1, length2);
                        templateAngle = angle;
                        break;

                    case RegionType.圆:
                        HTuple radius;
                        HOperatorSet.DrawCircle(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out radius);
                        if (row.D == 0 && col.D == 0)
                            return;
                        HOperatorSet.GenCircle(out region, row, col, radius);
                        break;

                    case RegionType.椭圆:
                        HOperatorSet.DrawEllipse(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out angle, out length1, out length2);
                        if (row.D == 0 && col.D == 0)
                            return;
                        HOperatorSet.GenEllipse(out region, row, col, angle, length1, length2);
                        break;

                    case RegionType.任意:
                        HOperatorSet.DrawRegion(out region, Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID);
                        HTuple R, C, A;
                        HOperatorSet.AreaCenter(region, out R, out C, out A);
                        if (A.D == 0)
                            return;
                        break;
                }
                Frm_MatchTool.Instance.btn_runTool.Enabled = true;
                Frm_MatchTool.Instance.btn_studyTemplate.Enabled = true;
                Frm_MatchTool.Instance.hWindow_Final1.DrawModel = false;
                Frm_MatchTool.Instance.hWindow_Final1.ContextMenuStrip = Frm_MatchTool.Instance.uiContextMenuStrip1;
                Frm_MatchTool.Instance.hWindow_Final1.DispObj(region, Frm_MatchTool.Instance.rdo_addTemplateRegion.Checked ? "green" : "red");

                if (templateRegion == null)
                    templateRegion = region;
                else if (Frm_MatchTool.Instance.rdo_addTemplateRegion.Checked)
                    HOperatorSet.Union2(templateRegion, region, out templateRegion);
                else if (Frm_MatchTool.Instance.rdo_subTemplateRegion.Checked)
                    HOperatorSet.Difference(templateRegion, region, out templateRegion);

                if (!templateCreated)
                    Frm_MatchTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
                else
                    Frm_MatchTool.Instance.hWindow_Final1.HobjectToHimage(templateImage);

                templateRegonType = regionType;
                HOperatorSet.SetLineStyle(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple());
                Frm_MatchTool.Instance.hWindow_Final1.DispObj(templateRegion, "green");
                HalconLib.DispText(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, "若绘制已完成，请点击训练按钮进行训练模板", 13, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "blue", "false");
                isDrawing = false;
            });
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 切换搜索区域
        /// </summary>
        internal void SwitchSearchRegion(RegionType regionType)
        {
            HOperatorSet.ClearWindow(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID);
            Frm_MatchTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
            Frm_MatchTool.Instance.hWindow_Final1.DrawModel = true;

            switch (regionType)
            {
                case RegionType.矩形:
                    if (searchRegionType == RegionType.矩形)
                    {
                        Frm_MatchTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
                    }
                    else
                    {
                        this.L_regions.Clear();
                        Frm_MatchTool.Instance.hWindow_Final1.viewWindow.genRect1(200.0, 200.0, 600.0, 800.0, ref this.L_regions);
                    }
                    searchRegionType = RegionType.矩形;
                    break;
                case RegionType.仿射矩形:
                    if (searchRegionType == RegionType.仿射矩形)
                    {
                        Frm_MatchTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
                    }
                    else
                    {
                        this.L_regions.Clear();
                        Frm_MatchTool.Instance.hWindow_Final1.viewWindow.genRect2(400.0, 500.0, 0, 300.0, 200.0, ref this.L_regions);
                    }
                    searchRegionType = RegionType.仿射矩形;
                    break;
                case RegionType.圆:
                    if (searchRegionType == RegionType.圆)
                    {
                        Frm_MatchTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
                    }
                    else
                    {
                        this.L_regions.Clear();
                        Frm_MatchTool.Instance.hWindow_Final1.viewWindow.genCircle(400.0, 500.0, 200.0, ref this.L_regions);
                    }
                    searchRegionType = RegionType.圆;
                    break;

                case RegionType.多点:
                    HTuple row, col, row1, col1;
                    HOperatorSet.GetPart(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out row1, out col1);
                    HalconLib.DispText(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, "请在图像窗口中连续左击绘制多点区域，右击绘制结束", 12, row + (row1 - row) / 30, col + (col1 - col) / 30, "blue", "false");
                    if (searchRegionType == RegionType.多点)
                    {
                        Frm_MatchTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
                    }
                    else
                    {
                        this.L_regions.Clear();
                        HObject ho_ContOut1;
                        HTuple rows, cols, weights;
                        HOperatorSet.DrawNurbs(out ho_ContOut1, Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, "true", "true", "true", "true", 3, out rows, out cols, out weights);
                        Frm_MatchTool.Instance.hWindow_Final1.viewWindow.genNurbs(rows, cols, ref this.L_regions);
                    }
                    searchRegionType = RegionType.多点;
                    break;
                default:
                    L_regions.Clear();
                    searchRegionType = RegionType.整幅图像;
                    break;
            }
            Frm_MatchTool.Instance.hWindow_Final1.DrawModel = false;
            Frm_MatchTool.L_regions = this.L_regions;
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
            HOperatorSet.GenEmptyObj(out lastRunTemplate);
            HOperatorSet.GenEmptyObj(out lastRunCross);
            lastRunIndex = string.Empty;

            if (initRun)
            {
                参数 = new ToolPar();
                CreateTemplate(false);
            }

            if (((ToolPar)参数).输入.图像 == null)
            {
                toolRunStatu = "未指定输入图像";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            if (FindModelHandle() == null)
            {
                templateCreated = false;
                HOperatorSet.GenEmptyObj(out templateRegion);
                toolRunStatu = "未创建模板";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            HObject searchRegion = null;
            HObject reducedImage = null;
            if (searchRegionType == RegionType.整幅图像)
            {
                reducedImage = ((ToolPar)参数).输入.图像;
            }
            else
            {
                searchRegion = L_regions[0].getRegion();
                HOperatorSet.ReduceDomain(((ToolPar)参数).输入.图像, searchRegion, out reducedImage);
            }

            HTuple rows, cols, angles, scores;
            try
            {

                if (matchMode == MatchMode.BasedShape)  ////基于形状
                {
                    HTuple temp;
                    HOperatorSet.FindScaledShapeModel(reducedImage,
                                                     FindModelHandle(),
                                                     ((HTuple)(-angleRange / 2)).TupleRad(),
                                                     ((HTuple)angleRange).TupleRad(),
                                                      minScale,
                                                      maxScale,
                                                      minScore,
                                                      matchNum,
                                                      0.5,
                                                      "least_squares",
                                                      0,
                                                      0.9,
                                                      out rows,
                                                      out cols,
                                                      out angles,
                                                      out temp,
                                                      out scores);
                }
                else
                {
                    HOperatorSet.FindNccModel(reducedImage,
                                             (HTuple)FindModelHandle(),
                                             ((HTuple)(-angleRange / 2)).TupleRad(),
                                             ((HTuple)angleRange).TupleRad(),
                                             (HTuple)minScore,
                                             (HTuple)matchNum,
                                             (HTuple)0.5,
                                             (HTuple)"true",
                                             (HTuple)0,
                                              out rows,
                                              out cols,
                                              out angles,
                                              out scores);
                }

                if (initRun)
                {
                    sw.Stop();
                    toolRunStatu = "运行成功";
                    return;
                }

                //刷新图像
                if (trigedByTool)
                {
                    GetImageWindow().HobjectToHimage(((ToolPar)参数).输入.图像);
                    HOperatorSet.DispObj(((ToolPar)参数).输入.图像, GetImageWindowBack());
                }
                if (Frm_MatchTool.hasShown && Frm_MatchTool.taskName == taskName && Frm_MatchTool.toolName == toolName)
                {
                    Frm_MatchTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
                    Frm_MatchTool.Instance.dgv_result.Rows.Clear();
                }

                L_result.Clear();
                if (rows.TupleLength() > 0)
                {
                    for (int i = 0; i < rows.TupleLength(); i++)
                    {
                        MatchResult matchResult = new MatchResult();
                        matchResult.Row = Math.Round((double)rows[i], 3);
                        matchResult.Col = Math.Round((double)cols[i], 3);
                        matchResult.Angle = Math.Round((double)angles[i], 3);
                        matchResult.Socre = Math.Round((double)scores[i], 2);
                        L_result.Add(matchResult);
                    }

                    //以下代码对结果依据分数进行排序
                    MatchResult temp;
                    switch (sortMode)
                    {
                        case MatchSortMode.从上至下且从左至右:
                            for (int i = 0; i < L_result.Count; i++)
                            {
                                for (int j = i + 1; j < L_result.Count; j++)
                                {
                                    if (L_result[i].Row - L_result[j].Row > 200 / 2)
                                    {
                                        temp = L_result[i];
                                        L_result[i] = L_result[j];
                                        L_result[j] = temp;
                                    }
                                }
                            }
                            for (int i = 0; i < L_result.Count; i++)
                            {
                                for (int j = i + 1; j < L_result.Count; j++)
                                {
                                    if ((L_result[i].Col - L_result[j].Col > 200 / 2) && (Math.Abs(L_result[i].Row - L_result[j].Row) < 200 / 2))
                                    {
                                        temp = L_result[i];
                                        L_result[i] = L_result[j];
                                        L_result[j] = temp;
                                    }
                                }
                            }
                            break;

                        case MatchSortMode.从上至下且从右至左:
                            for (int i = 0; i < L_result.Count; i++)
                            {
                                for (int j = i + 1; j < L_result.Count; j++)
                                {
                                    if (L_result[i].Row - L_result[j].Row > 200 / 2)
                                    {
                                        temp = L_result[i];
                                        L_result[i] = L_result[j];
                                        L_result[j] = temp;
                                    }
                                }
                            }
                            for (int i = 0; i < L_result.Count; i++)
                            {
                                for (int j = i + 1; j < L_result.Count; j++)
                                {
                                    if ((L_result[i].Col - L_result[j].Col < 200 / 2) && (Math.Abs(L_result[i].Row - L_result[j].Row) < 200 / 2))
                                    {
                                        temp = L_result[i];
                                        L_result[i] = L_result[j];
                                        L_result[j] = temp;
                                    }
                                }
                            }
                            break;

                        default:
                            for (int i = 0; i < L_result.Count - 1; i++)
                            {
                                for (int j = i + 1; j < L_result.Count; j++)
                                {
                                    if (L_result[i].Socre < L_result[j].Socre)
                                    {
                                        temp = L_result[i];
                                        L_result[i] = L_result[j];
                                        L_result[j] = temp;
                                    }
                                }
                            }
                            break;
                    }
                }

                if (showSearchRegion && searchRegion != null)
                {
                    if (!initRun)
                    {
                        HOperatorSet.SetLineStyle(GetImageWindow().HWindowHalconID, new HTuple());
                        DispObj(L_regions[0].getRegion(), "blue");
                        HOperatorSet.DispObj(L_regions[0].getRegion(), GetImageWindowBack());

                        if (Frm_MatchTool.hasShown && Frm_MatchTool.taskName == taskName && Frm_MatchTool.toolName == toolName)
                        {
                            HOperatorSet.SetColor(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, "blue");
                            Frm_MatchTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
                        }
                    }
                }

                if (!initRun)
                {
                    if (Frm_MatchTool.hasShown && Frm_MatchTool.taskName == taskName && Frm_MatchTool.toolName == toolName)
                        Frm_MatchTool.Instance.dgv_result.Rows.Clear();

                    for (int i = 0; i < L_result.Count; i++)
                    {
                        //显示匹配特征
                        if (showFeature && matchMode == MatchMode.BasedShape)
                        {
                            HObject countor;
                            HOperatorSet.GetShapeModelContours(out countor, FindModelHandle(), new HTuple(1));
                            HTuple homMat2D;
                            HOperatorSet.HomMat2dIdentity(out homMat2D);
                            HOperatorSet.HomMat2dTranslate(homMat2D, L_result[i].Row, L_result[i].Col, out homMat2D);
                            HOperatorSet.HomMat2dRotate(homMat2D, (HTuple)L_result[i].Angle, (HTuple)L_result[i].Row, (HTuple)L_result[i].Col, out homMat2D);
                            HObject countorAfterTrans;
                            HOperatorSet.AffineTransContourXld(countor, out countorAfterTrans, homMat2D);

                            GetImageWindow().DispObj(countorAfterTrans, "orange");
                            HOperatorSet.DispObj(countorAfterTrans, GetImageWindowBack());
                            if (Frm_MatchTool.hasShown && Frm_MatchTool.taskName == taskName && Frm_MatchTool.toolName == toolName)
                                Frm_MatchTool.Instance.hWindow_Final1.DispObj(countorAfterTrans, "orange");
                        }

                        //显示结果
                        if (Frm_MatchTool.hasShown && Frm_MatchTool.taskName == taskName && Frm_MatchTool.toolName == toolName)
                        {
                            int index = Frm_MatchTool.Instance.dgv_result.Rows.Add();
                            Frm_MatchTool.Instance.dgv_result.Rows[index].Cells[0].Value = i + 1;
                            Frm_MatchTool.Instance.dgv_result.Rows[index].Cells[1].Value = Math.Round((double)L_result[i].Socre, 3);
                            Frm_MatchTool.Instance.dgv_result.Rows[index].Cells[2].Value = Math.Round((double)L_result[i].Row, 3);
                            Frm_MatchTool.Instance.dgv_result.Rows[index].Cells[3].Value = Math.Round((double)L_result[i].Col, 3);
                            Frm_MatchTool.Instance.dgv_result.Rows[index].Cells[4].Value = Math.Round((double)L_result[i].Angle, 3);
                        }

                        HTuple area, row, col;
                        if (showTemplate)
                        {
                            HOperatorSet.AreaCenter(templateRegion, out area, out row, out col);
                            HTuple homMat2D;
                            HOperatorSet.HomMat2dIdentity(out homMat2D);
                            HOperatorSet.HomMat2dTranslate(homMat2D, -firstTemplateCenter.X, -firstTemplateCenter.Y, out homMat2D);
                            double angle = Math.Round(L_result[i].Angle, 3);
                            HOperatorSet.HomMat2dRotate(homMat2D, angle, 0, 0, out homMat2D);
                            HObject templateRegionAfterTrans;
                            HOperatorSet.HomMat2dTranslate(homMat2D, L_result[i].Row, L_result[i].Col, out homMat2D);
                            HOperatorSet.AffineTransRegion(templateRegion, out templateRegionAfterTrans, homMat2D, "nearest_neighbor");

                            //挖去内部区域
                            HObject tempRegion1 = null;
                            HOperatorSet.FillUp(templateRegionAfterTrans, out tempRegion1);
                            HObject tempRegion2 = null;
                            HOperatorSet.Difference(tempRegion1, templateRegionAfterTrans, out tempRegion2);
                            HOperatorSet.GenContourRegionXld(tempRegion2, out tempRegion2, "border");

                            HOperatorSet.SetLineStyle(GetImageWindow().HWindowHalconID, new HTuple());
                            lastRunTemplate = tempRegion1;

                            if (enableSafetyRange && safetyRegion != null)
                            {
                                HTuple index;
                                HObject tempj;
                                HOperatorSet.GenRegionContourXld(safetyRegion, out tempj, "filled");
                                HOperatorSet.GetRegionIndex(tempj, (int)L_result[i].Row, (int)L_result[i].Col, out index);
                                if (index.Length == 0)
                                {
                                    GetImageWindow().DispObj(tempRegion1, "red");
                                    HOperatorSet.SetLineStyle(GetImageWindow().HWindowHalconID, new HTuple(16, 7, 3, 7));
                                    GetImageWindow().DispObj(tempRegion2, "coral");
                                }
                                else
                                {
                                    GetImageWindow().DispObj(tempRegion1, "green");
                                    HOperatorSet.SetLineStyle(GetImageWindow().HWindowHalconID, new HTuple(16, 7, 3, 7));
                                    GetImageWindow().DispObj(tempRegion2, "coral");
                                }
                            }
                            else
                            {
                                DispObj(tempRegion1, "green");
                                HOperatorSet.SetLineStyle(GetImageWindow().HWindowHalconID, new HTuple(16, 7, 3, 7));
                                DispObj(tempRegion2, "coral");
                            }

                            if (Frm_MatchTool.hasShown && Frm_MatchTool.taskName == taskName && Frm_MatchTool.toolName == toolName)
                            {
                                HOperatorSet.SetDraw(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, "margin");
                                if (enableSafetyRange && safetyRegion != null)
                                {
                                    HTuple index;
                                    HObject tempj;
                                    HOperatorSet.GenRegionContourXld(safetyRegion, out tempj, "filled");
                                    HOperatorSet.GetRegionIndex(tempj, (int)L_result[i].Row, (int)L_result[i].Col, out index);
                                    if (index.Length == 0)
                                    {
                                        Frm_MatchTool.Instance.hWindow_Final1.DispObj(tempRegion1, "red");
                                        HOperatorSet.SetLineStyle(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple(16, 7, 3, 7));
                                        Frm_MatchTool.Instance.hWindow_Final1.DispObj(tempRegion2, "coral");
                                    }
                                    else
                                    {
                                        Frm_MatchTool.Instance.hWindow_Final1.DispObj(tempRegion1, "green");
                                        HOperatorSet.SetLineStyle(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple(16, 7, 3, 7));
                                        Frm_MatchTool.Instance.hWindow_Final1.DispObj(tempRegion2, "coral");
                                    }
                                }
                                else
                                {
                                    Frm_MatchTool.Instance.hWindow_Final1.DispObj(tempRegion1, "green");
                                    HOperatorSet.SetLineStyle(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple(16, 7, 3, 7));
                                    Frm_MatchTool.Instance.hWindow_Final1.DispObj(tempRegion2, "coral");
                                }
                            }
                        }

                        HOperatorSet.AreaCenter(templateRegion, out area, out row, out col);
                        HObject cross1;
                        HTuple row11, col11, row22, col22;
                        HOperatorSet.GetPart(GetImageWindow().HWindowHalconID, out row11, out col11, out row22, out col22);
                        HOperatorSet.GenCrossContourXld(out cross1, L_result[i].Row, L_result[i].Col, new HTuple((row22 - row11) / 30.0), new HTuple(L_result[i].Angle + templateAngle));

                        //显示中心十字架
                        if (showCross)
                        {
                            HOperatorSet.SetLineStyle(GetImageWindow().HWindowHalconID, new HTuple());
                            DispObj(cross1, "green");
                            //////HOperatorSet.Union2(lastRunResult, cross1, out lastRunResult);
                            if (Frm_MatchTool.hasShown && Frm_MatchTool.taskName == taskName && Frm_MatchTool.toolName == toolName)
                            {
                                HObject cross2;
                                HOperatorSet.GetPart(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, out row11, out col11, out row22, out col22);
                                HOperatorSet.GenCrossContourXld(out cross2, L_result[i].Row, L_result[i].Col, new HTuple((row22 - row11) / 60.0), new HTuple(L_result[i].Angle + templateAngle));
                                HOperatorSet.SetLineStyle(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple());
                                Frm_MatchTool.Instance.hWindow_Final1.DispObj(cross2, "green");
                            }
                        }
                        //序号
                        if (showIndex)
                        {
                            DispText(showScore ? string.Format("{0}  {1}", i + 1, L_result[i].Socre) : (i + 1).ToString(), 12, L_result[i].Row - firstTemplateCenter.X + row + 20, L_result[i].Col - firstTemplateCenter.Y + col + 20, "blue", "false");
                            if (Frm_MatchTool.hasShown && Frm_MatchTool.taskName == taskName && Frm_MatchTool.toolName == toolName)
                                HalconLib.DispText(Frm_MatchTool.Instance.hWindow_Final1.HWindowHalconID, showScore ? string.Format("{0}  {1}", i + 1, L_result[i].Socre) : (i + 1).ToString(), 12, L_result[i].Row - firstTemplateCenter.X + row + 20, L_result[i].Col - firstTemplateCenter.Y + col + 20, "blue", "false");
                        }
                    }
                }

            ((ToolPar)参数).输出.数量 = L_result.Count;
                ((ToolPar)参数).输出.位置.Clear();
                for (int i = 0; i < L_result.Count; i++)
                {
                    XYU xyu = new XYU();
                    xyu.XY.X = L_result[i].Row;
                    xyu.XY.Y = L_result[i].Col;
                    xyu.U = L_result[i].Angle;
                    ((ToolPar)参数).输出.位置.Add(xyu);
                }

                if (!showCross && !showFeature && !showTemplate)
                    FuncLib.ShowMsg(string.Format("温馨提示：工具 [ {0} . {1} ] 的所有显示特征全部被禁用", taskName, toolName), InfoType.Warn);

                if (L_result.Count == 0)
                {
                    toolRunStatu = "未匹配到模板";
                    if (!initRun && alarm == 1)
                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                    goto Exit;
                }

                //////if (L_result.Count != matchNum)
                //////{
                //////    toolRunStatu = "匹配数量不足";
                //////    if (!initRun && alarm == 1)
                //////        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                //////    goto Exit;
                //////}

                //安全范围管控
                if (enableSafetyRange && safetyRegion != null)
                {
                    GetImageWindow().DispObj(safetyRegion, "yellow");
                    HOperatorSet.DispObj(safetyRegion, GetImageWindowBack());
                    if (Frm_MatchTool.hasShown && Frm_MatchTool.taskName == taskName && Frm_MatchTool.toolName == toolName)
                        Frm_MatchTool.Instance.hWindow_Final1.DispObj(safetyRegion, "yellow");

                    for (int i = 0; i < ((ToolPar)参数).输出.位置.Count; i++)
                    {
                        HTuple index;
                        HObject tempj;
                        HOperatorSet.GenRegionContourXld(safetyRegion, out tempj, "filled");
                        HOperatorSet.GetRegionIndex(tempj, (int)((ToolPar)参数).输出.位置[i].XY.X, (int)((ToolPar)参数).输出.位置[i].XY.Y, out index);
                        if (index.Length == 0)
                        {
                            toolRunStatu = "匹配结果超出管控范围";
                            if (!initRun)
                                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                            goto Exit;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                toolRunStatu = "异常：" + ex.Message;
                FuncLib.ShowMsg("工具：" + toolName + "—运行出现异常：" + ex.Message, InfoType.Error);
                goto Exit;
            }
            sw.Stop();
            toolRunStatu = "运行成功";
        Exit:
            if (Frm_MatchTool.hasShown && Frm_MatchTool.taskName == taskName && Frm_MatchTool.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_MatchTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());

                if (toolRunStatu == "运行成功")
                    Frm_MatchTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                else
                    Frm_MatchTool.Instance.lbl_toolTip.ForeColor = Color.Red;

                Frm_MatchTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
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
                set
                {
                    _图像 = value;
                }
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

            private List<XYU> _位置 = new List<XYU>();
            public List<XYU> 位置
            {
                get { return _位置; }
                set { _位置 = value; }
            }
        }
        #endregion

    }

    /// <summary>
    /// 匹配模式
    /// </summary>
    internal enum MatchMode
    {
        BasedGray,          //基于灰度
        BasedShape,         //基于形状
    }
    /// <summary>
    /// 匹配结果
    /// </summary>
    [Serializable]
    internal struct MatchResult
    {
        internal double Row;        //行坐标
        internal double Col;        //列坐标
        internal double Angle;      //角度
        internal double Socre;      //分数
    }
    /// <summary>
    /// 匹配结果排序方式
    /// </summary>
    internal enum MatchSortMode
    {
        分数,
        从上至下且从左至右,
        从左至右且从上至下,
        从上至下且从右至左,
        从左至右且从下至上,
    }

}
