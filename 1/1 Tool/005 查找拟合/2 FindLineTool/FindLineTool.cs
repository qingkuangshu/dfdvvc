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
    /// 查找直线
    /// </summary>
    internal class FindLineTool : ToolBase
    {
        internal FindLineTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

            HObject image = null;
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.采集图像)
                {
                    image = ((ImageTool.ToolPar)Task.curTask.L_toolList[i].参数).输出.图像;
                    break;
                }
            }

            if (image != null)
            {
                HTuple width, height;
                HOperatorSet.GetImageSize(image, out width, out height);
                Frm_FindLineTool.Instance.hWindow_Final1.viewWindow.genRect2(height.D / 8.0, width.D / 8.0, 0, height.D / 40, width.D / 12, ref this.L_regions);
                //caliperLength = width.I / 60;
            }
            else
            {
                Frm_FindLineTool.Instance.hWindow_Final1.viewWindow.genRect2(400.0, 500.0, 0, 160, 120, ref this.L_regions);
            }
            Frm_FindLineTool.L_regions = L_regions;

            XYU xyu = new XYU();
            followedPose.Add(xyu);

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

            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.模板匹配)
                {
                    InputItem inputItem = new InputItem();
                    inputItem.InputName = "跟随";
                    inputItem.inputType = DataType.ListXYU;
                    inputItem.sourceTask = taskName;
                    inputItem.sourceTool = Task.curTask.L_toolList[i].toolName;
                    inputItem.sourceOutput = "位置";

                    L_inputItem.Add(inputItem);
                    break;
                }
            }
        }

        /// <summary>
        /// 显示卡尺
        /// </summary>
        internal bool showCaliper = true;
        /// <summary>
        /// 显示特征点
        /// </summary>
        internal bool showFeature = true;
        /// <summary>
        /// 显示线
        /// </summary>
        internal bool showLine = true;
        /// <summary>
        /// 卡尺长度
        /// </summary>
        internal int caliperLength = 30;
        /// <summary>
        /// 卡尺宽度
        /// </summary>
        internal int caliperWidth = 5;
        /// <summary>
        /// 阈值
        /// </summary>
        internal int threshold = 30;
        /// <summary>
        /// 忽略点数
        /// </summary>
        internal int ignorePointNum = 30;
        /// <summary>
        /// 极性
        /// </summary>
        internal string polarity = "positive";
        /// <summary>
        /// 边选择
        /// </summary>
        internal string edgeSelect = "first";
        /// <summary>
        /// 分数
        /// </summary>
        internal double minScore = 0.5;
        /// <summary>
        /// 卡尺数量
        /// </summary>
        internal int cliperNum = 100;
        /// <summary>
        /// 新的跟随姿态变化后的预期线信息
        /// </summary>
        internal List<HTuple> newExpectLineStartRow = new List<HTuple>(), newExpectLineStartCol = new List<HTuple>(), newExpectLineEndRow = new List<HTuple>(), newExpectLineEndCol = new List<HTuple>();
        /// <summary>
        /// 制作模板时的输入位姿
        /// </summary>
        internal List<XYU> followedPose = new List<XYU>();
        /// <summary>
        /// 卡尺区域
        /// </summary>
        internal List<ViewWindow.Model.ROI> L_regions = new List<ROI>();
        /// <summary>
        /// 线的角度
        /// </summary>
        internal HTuple LineAngle = 0;


        /// <summary>
        /// 点拟合线
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        private Line FitLine(double[] X, double[] Y)
        {
            HTuple rows = X[0];
            HTuple cols = Y[0];
            for (int i = 1; i < X.Length; i++)
            {
                rows = rows.TupleConcat(X[i]);
                cols = cols.TupleConcat(Y[i]);
            }

            HObject Contour;
            HOperatorSet.GenContourPolygonXld(out Contour, rows, cols);
            HTuple RowBegin, ColBegin, RowEnd, ColEnd, Nr, Nc, Dist;
            HOperatorSet.FitLineContourXld(Contour, "tukey", -1, 0, 5, 2, out RowBegin, out ColBegin, out RowEnd, out ColEnd, out Nr, out Nc, out Dist);
            Line line = new Line();
            line.起点.X = RowBegin;
            line.起点.Y = ColBegin;
            line.终点.X = RowEnd;
            line.终点.Y = ColEnd;
            return line;
        }
        /// <summary>
        /// 显示特征
        /// </summary>
        /// <param name="showROI"></param>
        /// <param name="followed"></param>
        internal void ShowContour(bool showROI, bool followed = true)
        {
            HObject contours;
            HTuple row, col;

            HTuple newExpectCenterRow = 0, newExpectCenterCol = 0;
            if (((ToolPar)参数).输入.跟随 != null && ((ToolPar)参数).输入.跟随.Count != 0)
            {
                if (followed)
                {
                    newExpectLineStartRow.Clear();
                    newExpectLineStartCol.Clear();
                    newExpectLineEndRow.Clear();
                    newExpectLineEndCol.Clear();
                    HTuple homMat2D;
                    HOperatorSet.VectorAngleToRigid(followedPose[0].XY.X, followedPose[0].XY.Y, followedPose[0].U, ((ToolPar)参数).输入.跟随[0].XY.X, ((ToolPar)参数).输入.跟随[0].XY.Y, ((ToolPar)参数).输入.跟随[0].U, out homMat2D);

                    //对预期线的起始点做放射变换
                    HTuple temp1, temp2, temp3, temp4, temp5, temp6;
                    HOperatorSet.AffineTransPixel(homMat2D, (HTuple)L_regions[0].getRowsData()[7], (HTuple)L_regions[0].getColsData()[7], out temp1, out temp2);
                    HOperatorSet.AffineTransPixel(homMat2D, (HTuple)L_regions[0].getRowsData()[9], (HTuple)L_regions[0].getColsData()[9], out temp3, out temp4);
                    HOperatorSet.AffineTransPixel(homMat2D, (HTuple)L_regions[0].getRowsData()[4], (HTuple)L_regions[0].getColsData()[4], out temp5, out temp6);

                    newExpectLineStartRow.Add(temp1);
                    newExpectLineStartCol.Add(temp2);
                    newExpectLineEndRow.Add(temp3);
                    newExpectLineEndCol.Add(temp4);
                    newExpectCenterRow = temp5;
                    newExpectCenterCol = temp6;
                }
                else
                {
                    newExpectLineStartRow.Clear();
                    newExpectLineStartCol.Clear();
                    newExpectLineEndRow.Clear();
                    newExpectLineEndCol.Clear();
                    newExpectLineStartRow.Add(L_regions[0].getRowsData()[7]);
                    newExpectLineStartCol.Add(L_regions[0].getColsData()[7]);
                    newExpectLineEndRow.Add(L_regions[0].getRowsData()[9]);
                    newExpectLineEndCol.Add(L_regions[0].getColsData()[9]);
                }
            }
            else
            {
                newExpectLineStartRow.Clear();
                newExpectLineStartCol.Clear();
                newExpectLineEndRow.Clear();
                newExpectLineEndCol.Clear();
                newExpectLineStartRow.Add(L_regions[0].getRowsData()[7]);
                newExpectLineStartCol.Add(L_regions[0].getColsData()[7]);
                newExpectLineEndRow.Add(L_regions[0].getRowsData()[9]);
                newExpectLineEndCol.Add(L_regions[0].getColsData()[9]);
            }

            if (((ToolPar)参数).输入.图像 != null)
            {
                HTuple handleID;
                HOperatorSet.CreateMetrologyModel(out handleID);
                HTuple width, height;
                HOperatorSet.GetImageSize(((ToolPar)参数).输入.图像, out width, out height);
                HOperatorSet.SetMetrologyModelImageSize(handleID, width[0], height[0]);
                HTuple index;
                HOperatorSet.AddMetrologyObjectLineMeasure(handleID, newExpectLineStartRow[0], newExpectLineStartCol[0], newExpectLineEndRow[0], newExpectLineEndCol[0], new HTuple(caliperLength), new HTuple(caliperWidth), new HTuple(1), new HTuple(30), new HTuple(), new HTuple(), out index);

                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_transition"), new HTuple(polarity));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("num_measures"), new HTuple(cliperNum));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length1"), new HTuple(caliperLength));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length2"), new HTuple(caliperWidth));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_threshold"), new HTuple(threshold));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_select"), new HTuple(edgeSelect));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("min_score"), new HTuple(minScore));

                HOperatorSet.ApplyMetrologyModel(((ToolPar)参数).输入.图像, handleID);
                HOperatorSet.GetMetrologyObjectMeasures(out contours, handleID, new HTuple("all"), new HTuple("all"), out row, out col);
                HOperatorSet.ClearWindow(Frm_FindLineTool.Instance.hWindow_Final1.HWindowHalconID);
                Frm_FindLineTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
                if (showROI)
                    Frm_FindLineTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
                HOperatorSet.SetColor(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple("blue"));
                HOperatorSet.DispObj(contours, Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID);

                HOperatorSet.ApplyMetrologyModel(((ToolPar)参数).输入.图像, handleID);

                if (showFeature)
                {
                    HTuple row1, col1;
                    HOperatorSet.GetMetrologyObjectMeasures(out contours, handleID, new HTuple("all"), new HTuple("all"), out row1, out col1);
                    HObject cross;
                    HTuple row2, col2, row3, col3;
                    HOperatorSet.GetPart(Frm_FindLineTool.Instance.hWindow_Final1.HWindowHalconID, out row2, out col2, out row3, out col3);
                    HOperatorSet.GenCrossContourXld(out cross, row, col, new HTuple((row3 - row2) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                    HOperatorSet.SetColor(Frm_FindLineTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple("orange"));
                    HOperatorSet.DispObj(cross, Frm_FindLineTool.Instance.hWindow_Final1.HWindowHalconID);
                }

                HObject line;
                HOperatorSet.GetMetrologyObjectResultContour(out line, handleID, new HTuple("all"), new HTuple("all"), new HTuple(1.5));
                HOperatorSet.SetColor(Frm_FindLineTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple("green"));
                HOperatorSet.DispObj(line, Frm_FindLineTool.Instance.hWindow_Final1.HWindowHalconID);

                HOperatorSet.ClearMetrologyModel(handleID);
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

            #region 非法管控

            if (initRun)
            {
                参数 = new ToolPar();
                return;
            }

            if (((ToolPar)参数).输入.图像 == null)
            {
                toolRunStatu = "未指定输入图像";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            if (cliperNum - ignorePointNum < 5)
            {
                toolRunStatu = string.Format("忽略点数占比过大，总点数：{0}  忽略点数：{1}", cliperNum, ignorePointNum);
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            #endregion


            if (Frm_FindLineTool.hasShown && Frm_FindLineTool.taskName == taskName && Frm_FindLineTool.toolName == toolName)
            {
                Frm_FindLineTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
                Frm_FindLineTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
            }


            #region 得到线的大概位置


            newExpectLineStartRow.Clear();
            newExpectLineStartCol.Clear();
            newExpectLineEndRow.Clear();
            newExpectLineEndCol.Clear();
            if (((ToolPar)参数).输入.跟随 != null && ((ToolPar)参数).输入.跟随.Count > 0)
            {
                for (int i = 0; i < ((ToolPar)参数).输入.跟随.Count; i++)
                {
                    HTuple homMat2D;
                    //计算做模板时的特征点位置以及当前模板点的位置，然后得出其2d矩阵，这样的话，线根据该矩阵进行变化即可得到本次线所在的位置
                    HOperatorSet.VectorAngleToRigid(followedPose[0].XY.X, followedPose[0].XY.Y, followedPose[0].U, ((ToolPar)参数).输入.跟随[i].XY.X, ((ToolPar)参数).输入.跟随[i].XY.Y, ((ToolPar)参数).输入.跟随[i].U, out homMat2D);
                    //对预期线的起始点做放射变换
                    HTuple temp11, temp22, temp33, temp44;
                    HOperatorSet.AffineTransPixel(homMat2D, (HTuple)L_regions[0].getRowsData()[7], (HTuple)L_regions[0].getColsData()[7], out temp11, out temp22);
                    HOperatorSet.AffineTransPixel(homMat2D, (HTuple)L_regions[0].getRowsData()[9], (HTuple)L_regions[0].getColsData()[9], out temp33, out temp44);

                    newExpectLineStartRow.Add(temp11);
                    newExpectLineStartCol.Add(temp22);
                    newExpectLineEndRow.Add(temp33);
                    newExpectLineEndCol.Add(temp44);
                }
            }
            else
            {
                newExpectLineStartRow.Add(L_regions[0].getRowsData()[7]);
                newExpectLineStartCol.Add(L_regions[0].getColsData()[7]);
                newExpectLineEndRow.Add(L_regions[0].getRowsData()[9]);
                newExpectLineEndCol.Add(L_regions[0].getColsData()[9]);
            }

            #endregion


            ((ToolPar)参数).输出.线.Clear();
            List<Line> L_lines = new List<Line>();
            for (int i = 0; i < newExpectLineStartRow.Count; i++)
            {
                #region 找实际的线

                //步骤：创建句柄》设置句柄图像大小》将线的信息填充给句柄》设置句柄相关参数》将图像给到句柄，进行推理

                HTuple handleID;
                HOperatorSet.CreateMetrologyModel(out handleID);

                HTuple width, height;
                HOperatorSet.GetImageSize(((ToolPar)参数).输入.图像, out width, out height);
                HOperatorSet.SetMetrologyModelImageSize(handleID, width[0], height[0]);
                HTuple index;
                HOperatorSet.AddMetrologyObjectLineMeasure(handleID, newExpectLineStartRow[i], newExpectLineStartCol[i], newExpectLineEndRow[i], newExpectLineEndCol[i], new HTuple(caliperLength), new HTuple(caliperWidth), new HTuple(1), new HTuple(30), new HTuple(), new HTuple(), out index);

                //参数设置
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_transition"), new HTuple(polarity));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("num_measures"), new HTuple(cliperNum));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length1"), new HTuple(caliperLength));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length2"), new HTuple(caliperWidth));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_threshold"), new HTuple(threshold));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_select"), new HTuple(edgeSelect));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("min_score"), new HTuple(minScore));
                HOperatorSet.ApplyMetrologyModel(((ToolPar)参数).输入.图像, handleID);

                #endregion

                //显示所有卡尺
                if (showCaliper)
                {
                    HObject contours;
                    HTuple row, col;
                    HOperatorSet.GetMetrologyObjectMeasures(out contours, handleID, new HTuple("all"), new HTuple("all"), out row, out col);

                    GetImageWindow().DispObj(contours, "blue");
                    if (Frm_FindLineTool.hasShown && Frm_FindLineTool.taskName == taskName && Frm_FindLineTool.toolName == toolName)
                        Frm_FindLineTool.Instance.hWindow_Final1.DispObj(contours, "blue");
                }

                HTuple parameter;   //即线的信息
                HObject lineContour;
                HOperatorSet.GetMetrologyObjectResult(handleID, new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"), out parameter);
                HOperatorSet.GetMetrologyObjectResultContour(out lineContour, handleID, new HTuple("all"), new HTuple("all"), new HTuple(1.5));

                if (ignorePointNum == 0)//不忽略点
                {
                    if (parameter.Length >= 3)
                    {
                        Line line = new Line();
                        line.起点.X = parameter[0];
                        line.起点.Y = parameter[1];
                        line.终点.X = parameter[2];
                        line.终点.Y = parameter[3];
                        L_lines.Add(line);
                        ((ToolPar)参数).输出.线.Add(line);
                    }

                    //把点显示出来
                    if (showFeature)
                    {
                        HObject features;
                        HTuple row, col;
                        HOperatorSet.GetMetrologyObjectMeasures(out features, handleID, new HTuple("all"), new HTuple("all"), out row, out col);
                        HObject cross;
                        HTuple row1, col1, row2, col2;
                        HOperatorSet.GetPart(GetImageWindow().HWindowHalconID, out row1, out col1, out row2, out col2);
                        HOperatorSet.GenCrossContourXld(out cross, row, col, new HTuple((row2 - row1) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                        GetImageWindow().DispObj(cross, "orange");
                        if (Frm_FindLineTool.hasShown && Frm_FindLineTool.taskName == taskName && Frm_FindLineTool.toolName == toolName)
                        {
                            HOperatorSet.GetPart(Frm_FindLineTool.Instance.hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                            HOperatorSet.GenCrossContourXld(out cross, row, col, new HTuple((row2 - row1) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                            Frm_FindLineTool.Instance.hWindow_Final1.DispObj(cross, "orange");
                        }
                    }

                    HOperatorSet.ClearMetrologyModel(handleID);
                }
                else        //忽略指定点数
                {
                    if (parameter.Length >= 4)      
                    {
                        HTuple rows, cols;
                        HObject contours;
                        HOperatorSet.GetMetrologyObjectMeasures(out contours, handleID, new HTuple("all"), new HTuple("all"), out rows, out cols);
                        List<PosAndDistance> list = new List<PosAndDistance>();
                        for (int j = 0; j < rows.TupleLength(); j++)
                        {
                            HTuple distance1, temp;
                            HOperatorSet.DistancePc(lineContour, rows[j], cols[j], out distance1, out temp);
                            
                            if (distance1.TupleLength() == 0)
                            {
                                toolRunStatu = "未找到线";
                                if (!initRun)
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                goto Exit;
                            }

                            PosAndDistance posAndDistance = new PosAndDistance();
                            posAndDistance.row = rows[j];
                            posAndDistance.col = cols[j];
                            posAndDistance.distance = distance1.D;
                            list.Add(posAndDistance);
                        }

                        //距离排序
                        PosAndDistance temp1;
                        List<PosAndDistance> list3 = new List<PosAndDistance>();
                        for (int j = 0; j < list.Count; j++)
                        {
                            list3.Add(list[j]);
                        }


                        for (int j = 0; j < list3.Count - 1; j++)
                        {
                            for (int k = j + 1; k < list3.Count; k++)
                            {
                                if (list3[j].distance > list3[k].distance)
                                {
                                    temp1 = list3[j];
                                    list3[j] = list3[k];
                                    list3[k] = temp1;
                                }
                            }
                        }

                        if (list3.Count - ignorePointNum < 3)
                        {
                            toolRunStatu = "忽略点数大于找到的点数导致有效点数不足以拟合直线";
                            if (!initRun)
                                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                            goto Exit;
                        }

                        double split = list3[list3.Count - ignorePointNum].distance;

                        List<double> rowOK = new List<double>();
                        List<double> colOK = new List<double>();
                        List<double> rowNG = new List<double>();
                        List<double> colNG = new List<double>();

                        List<double> rowss = new List<double>();
                        List<double> colss = new List<double>();
                        for (int k = 0; k < list.Count; k++)
                        {
                            if (list[k].distance < split)
                            {
                                rowss.Add((float)list[k].row);
                                colss.Add((float)list[k].col);

                                rowOK.Add((float)list[k].row);
                                colOK.Add((float)list[k].col);
                            }
                            else
                            {
                                rowNG.Add((float)list[k].row);
                                colNG.Add((float)list[k].col);
                            }
                        }

                        Line line = FitLine(rowss.ToArray(), colss.ToArray());
                        L_lines.Add(line);
                        ((ToolPar)参数).输出.线.Add(line);

                        //显示合格点
                        //把点显示出来
                        if (showFeature)
                        {
                            HObject cross3;
                            HTuple row3, col3, row4, col4;
                            HOperatorSet.GetPart(GetImageWindow().HWindowHalconID, out row3, out col3, out row4, out col4);
                            HOperatorSet.GenCrossContourXld(out cross3, new HTuple(rowOK.ToArray()), new HTuple(colOK.ToArray()), new HTuple((row4 - row3) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b

                            GetImageWindow().DispObj(cross3, new HTuple("#ffb529"));
                            if (Frm_FindLineTool.hasShown && Frm_FindLineTool.taskName == taskName && Frm_FindLineTool.toolName == toolName)
                            {
                                HOperatorSet.GetPart(Frm_FindLineTool.Instance.hWindow_Final1.HWindowHalconID, out row3, out col3, out row4, out col4);
                                HOperatorSet.GenCrossContourXld(out cross3, new HTuple(rowOK.ToArray()), new HTuple(colOK.ToArray()), new HTuple((row4 - row3) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                                Frm_FindLineTool.Instance.hWindow_Final1.DispObj(cross3, "#ffb529");
                            }

                            //显示被忽略的点
                            HObject cross5;
                            HOperatorSet.GetPart(GetImageWindow().HWindowHalconID, out row3, out col3, out row4, out col4);
                            HOperatorSet.GenCrossContourXld(out cross5, new HTuple(rowNG.ToArray()), new HTuple(colNG.ToArray()), new HTuple((row4 - row3) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b

                            GetImageWindow().DispObj(cross5, new HTuple("red"));
                            if (Frm_FindLineTool.hasShown && Frm_FindLineTool.taskName == taskName && Frm_FindLineTool.toolName == toolName)
                            {
                                HOperatorSet.GetPart(Frm_FindLineTool.Instance.hWindow_Final1.HWindowHalconID, out row3, out col3, out row4, out col4);
                                HOperatorSet.GenCrossContourXld(out cross5, new HTuple(rowNG.ToArray()), new HTuple(colNG.ToArray()), new HTuple((row4 - row3) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                                Frm_FindLineTool.Instance.hWindow_Final1.DispObj(cross5, "red");
                            }
                        }
                    }

                    HOperatorSet.ClearMetrologyModel(handleID);
                }

                //显示线
                if (showLine && L_lines.Count > 0)
                {
                    HObject line;
                    HOperatorSet.GenContourPolygonXld(out line, new HTuple(L_lines[i].起点.X).TupleConcat(L_lines[i].终点.X), new HTuple(L_lines[i].起点.Y).TupleConcat(L_lines[i].终点.Y));
                    HOperatorSet.AngleLx(L_lines[i].起点.X, L_lines[i].起点.Y, L_lines[i].终点.X, L_lines[i].终点.Y, out LineAngle);
                    LineAngle = Math.Round(LineAngle.D, 3);
                    DispObj(line, "green");
                    if (Frm_FindLineTool.hasShown && Frm_FindLineTool.taskName == taskName && Frm_FindLineTool.toolName == toolName)
                        Frm_FindLineTool.Instance.hWindow_Final1.DispObj(line, "green");
                }
            }

            if (Frm_FindLineTool.hasShown && Frm_FindLineTool.taskName == taskName && Frm_FindLineTool.toolName == toolName)
            {
                Frm_FindLineTool.Instance.dgv_result.Rows.Clear();
                for (int i = 0; i < L_lines.Count; i++)
                {
                    int index = Frm_FindLineTool.Instance.dgv_result.Rows.Add();
                    Frm_FindLineTool.Instance.dgv_result.Rows[index].Cells[0].Value = i + 1;
                    Frm_FindLineTool.Instance.dgv_result.Rows[index].Cells[1].Value = Math.Round(L_lines[i].起点.X, 3);
                    Frm_FindLineTool.Instance.dgv_result.Rows[index].Cells[2].Value = Math.Round(L_lines[i].起点.Y, 3);
                    Frm_FindLineTool.Instance.dgv_result.Rows[index].Cells[3].Value = Math.Round(L_lines[i].终点.X, 3);
                    Frm_FindLineTool.Instance.dgv_result.Rows[index].Cells[3].Value = Math.Round(L_lines[i].终点.Y, 3);
                }
            }

            if (((ToolPar)参数).输出.线.Count == 0)
            {
                toolRunStatu = "未查找到线";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            sw.Stop();
            toolRunStatu = "运行成功";
        Exit:
            if (Frm_FindLineTool.hasShown && Frm_FindLineTool.taskName == taskName && Frm_FindLineTool.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_FindLineTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());

                if (toolRunStatu == "运行成功")
                    Frm_FindLineTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                else
                    Frm_FindLineTool.Instance.lbl_toolTip.ForeColor = Color.Red;

                Frm_FindLineTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
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
        }
        [Serializable]
        public class P运行 { }
        [Serializable]
        internal class P输出
        {
            private List<Line> _线 = new List<Line>();
            public List<Line> 线
            {
                get { return _线; }
                set { _线 = value; }
            }
        }
        #endregion

    }
}
