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
    /// 查找圆形
    /// </summary>
    internal class FindCircleTool : ToolBase
    {
        internal FindCircleTool(string toolName, string taskName, ToolType toolType)
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
                Frm_FindCircleTool.Instance.hWindow_Final1.viewWindow.genCircle(width.D / 8.0, height.D / 6.0, width.D / 18.0, ref L_regions);
                caliperLength = width.I / 60;
            }
            else
            {
                Frm_FindCircleTool.Instance.hWindow_Final1.viewWindow.genCircle(400.0, 500.0, 160, ref L_regions);
            }
            Frm_FindCircleTool.L_regions = L_regions;

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
        /// 显示圆
        /// </summary>
        internal bool showCircle = true;
        /// <summary>
        /// 显示圆心
        /// </summary>
        internal bool showCross = true;
        /// <summary>
        /// 期望圆圆心行坐标
        /// </summary>
        internal HTuple expectCircleRow = 300;
        /// <summary>
        /// 期望圆圆心列坐标
        /// </summary>
        internal HTuple expectCircleCol = 300;
        /// <summary>
        /// 期望圆半径
        /// </summary>
        internal HTuple expectCircleRadius = 200;
        /// <summary>
        /// 卡尺长度
        /// </summary>
        internal int caliperLength = 200;
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
        /// 新的跟随姿态变化后的预期圆信息
        /// </summary>
        internal List<HTuple> newExpecCircleRow = new List<HTuple>(), newExpectCircleCol = new List<HTuple>(), newExpectCircleRadius = new List<HTuple>();
        /// <summary>
        /// 制作模板时的输入位姿
        /// </summary>
        internal List<XYU> followedPose = new List<XYU>();
        /// <summary>
        /// 搜索区域
        /// </summary>
        internal List<ViewWindow.Model.ROI> L_regions = new List<ROI>();


        /// <summary>
        /// 点拟合圆
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public Circle LeastSquaresFit(double[] X, double[] Y)
        {
            if (X.Length < 3)
            {
                return null;
            }
            double cent_x = 0.0,
                cent_y = 0.0,
                radius = 0.0;
            double sum_x = 0.0f, sum_y = 0.0f;
            double sum_x2 = 0.0f, sum_y2 = 0.0f;
            double sum_x3 = 0.0f, sum_y3 = 0.0f;
            double sum_xy = 0.0f, sum_x1y2 = 0.0f, sum_x2y1 = 0.0f;
            int N = X.Length;
            double x, y, x2, y2;
            for (int i = 0; i < N; i++)
            {
                x = X[i];
                y = Y[i];
                x2 = x * x;
                y2 = y * y;
                sum_x += x;
                sum_y += y;
                sum_x2 += x2;
                sum_y2 += y2;
                sum_x3 += x2 * x;
                sum_y3 += y2 * y;
                sum_xy += x * y;
                sum_x1y2 += x * y2;
                sum_x2y1 += x2 * y;
            }
            double C, D, E, G, H;
            double a, b, c;
            C = N * sum_x2 - sum_x * sum_x;
            D = N * sum_xy - sum_x * sum_y;
            E = N * sum_x3 + N * sum_x1y2 - (sum_x2 + sum_y2) * sum_x;
            G = N * sum_y2 - sum_y * sum_y;
            H = N * sum_x2y1 + N * sum_y3 - (sum_x2 + sum_y2) * sum_y;
            a = (H * D - E * G) / (C * G - D * D);
            b = (H * C - E * D) / (D * D - G * C);
            c = -(a * sum_x + b * sum_y + sum_x2 + sum_y2) / N;
            cent_x = a / (-2);
            cent_y = b / (-2);
            radius = Math.Sqrt(a * a + b * b - 4 * c) / 2;
            var result = new Circle();
            result.X = cent_x;
            result.Y = cent_y;
            result.R = radius;
            return result;
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
            if (((ToolPar)参数).输入.跟随 != null && ((ToolPar)参数).输入.跟随.Count != 0)
            {
                if (followed)
                {
                    newExpecCircleRow.Clear();
                    newExpectCircleCol.Clear();
                    newExpectCircleRadius.Clear();
                    HTuple _homMat2D;
                    HOperatorSet.VectorAngleToRigid(followedPose[0].XY.X, followedPose[0].XY.Y, followedPose[0].U, ((ToolPar)参数).输入.跟随[0].XY.X, ((ToolPar)参数).输入.跟随[0].XY.Y, ((ToolPar)参数).输入.跟随[0].U, out _homMat2D);
                    //对预期线的起始点做放射变换
                    HTuple tempR, tempC;
                    HOperatorSet.AffineTransPixel(_homMat2D, (HTuple)L_regions[0].getModelData()[0], (HTuple)L_regions[0].getModelData()[1], out tempR, out tempC);
                    newExpecCircleRow.Add(tempR);
                    newExpectCircleCol.Add(tempC);
                    newExpectCircleRadius.Add(L_regions[0].getModelData()[2].D);
                }
                else
                {
                    newExpecCircleRow.Clear();
                    newExpectCircleCol.Clear();
                    newExpectCircleRadius.Clear();
                    newExpecCircleRow.Add(L_regions[0].getModelData()[0]);
                    newExpectCircleCol.Add(L_regions[0].getModelData()[1]);
                    newExpectCircleRadius.Add(L_regions[0].getModelData()[2]);
                }
            }
            else
            {
                newExpecCircleRow.Clear();
                newExpectCircleCol.Clear();
                newExpectCircleRadius.Clear();
                newExpecCircleRow.Add(L_regions[0].getModelData()[0]);
                newExpectCircleCol.Add(L_regions[0].getModelData()[1]);
                newExpectCircleRadius.Add(L_regions[0].getModelData()[2]);
            }

            HTuple handleID;
            HOperatorSet.CreateMetrologyModel(out handleID);
            HTuple width, height;
            HOperatorSet.GetImageSize(((ToolPar)参数).输入.图像, out width, out height);
            HOperatorSet.SetMetrologyModelImageSize(handleID, width[0], height[0]);
            HTuple index;
            HOperatorSet.AddMetrologyObjectCircleMeasure(handleID, newExpecCircleRow[0], newExpectCircleCol[0], newExpectCircleRadius[0], new HTuple(caliperLength), new HTuple(5), new HTuple(1), new HTuple(30), new HTuple(), new HTuple(), out index);

            HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_transition"), new HTuple(polarity));
            HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("num_measures"), new HTuple(cliperNum));
            HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length1"), new HTuple(caliperLength));
            HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length2"), new HTuple(caliperWidth));
            HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_threshold"), new HTuple(threshold));
            HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_select"), new HTuple(edgeSelect));
            HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("min_score"), new HTuple(minScore));

            HOperatorSet.ApplyMetrologyModel(((ToolPar)参数).输入.图像, handleID);
            HOperatorSet.GetMetrologyObjectMeasures(out contours, handleID, new HTuple("all"), new HTuple("all"), out row, out col);
            HOperatorSet.ClearWindow(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID);
            Frm_FindCircleTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
            if (showROI)
                Frm_FindCircleTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
            HOperatorSet.SetColor(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple("blue"));
            //HOperatorSet.DispObj(contours, Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID);

            HOperatorSet.ApplyMetrologyModel(((ToolPar)参数).输入.图像, handleID);

            if (showFeature)
            {
                HTuple row1, col1;
                HOperatorSet.GetMetrologyObjectMeasures(out contours, handleID, new HTuple("all"), new HTuple("all"), out row1, out col1);
                HObject cross;
                HTuple row2, col2, row3, col3;
                HOperatorSet.GetPart(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID, out row2, out col2, out row3, out col3);
                HOperatorSet.GenCrossContourXld(out cross, row, col, new HTuple((row3 - row2) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                HOperatorSet.SetColor(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple("orange"));
                HOperatorSet.DispObj(cross, Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID);
            }

            HObject circle;
            HOperatorSet.GetMetrologyObjectResultContour(out circle, handleID, new HTuple("all"), new HTuple("all"), new HTuple(1.5));
            HOperatorSet.SetColor(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple("green"));
            HOperatorSet.DispObj(circle, Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID);

            HOperatorSet.ClearMetrologyModel(handleID);
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
                参数 = new ToolPar();

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

            if (Frm_FindCircleTool.hasShown && Frm_FindCircleTool.taskName == taskName && Frm_FindCircleTool.toolName == toolName)
            {
                Frm_FindCircleTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
                Frm_FindCircleTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
            }

            newExpecCircleRow.Clear();
            newExpectCircleCol.Clear();
            newExpectCircleRadius.Clear();
            if (((ToolPar)参数).输入.跟随 != null)
            {
                for (int i = 0; i < ((ToolPar)参数).输入.跟随.Count; i++)
                {
                    HTuple _homMat2D;
                    HOperatorSet.VectorAngleToRigid(followedPose[0].XY.X, followedPose[0].XY.Y, followedPose[0].U, ((ToolPar)参数).输入.跟随[i].XY.X, ((ToolPar)参数).输入.跟随[i].XY.Y, ((ToolPar)参数).输入.跟随[i].U, out _homMat2D);
                    //对预期线的起始点做放射变换
                    HTuple tempR, tempC;
                    HOperatorSet.AffineTransPixel(_homMat2D, (HTuple)L_regions[0].getModelData()[0], (HTuple)L_regions[0].getModelData()[1], out tempR, out tempC);
                    newExpecCircleRow.Add(tempR);
                    newExpectCircleCol.Add(tempC);
                    newExpectCircleRadius.Add(L_regions[0].getModelData()[2].D);
                }
            }
            else
            {
                newExpecCircleRow.Add(L_regions[0].getModelData()[0]);
                newExpectCircleCol.Add(L_regions[0].getModelData()[1]);
                newExpectCircleRadius.Add(L_regions[0].getModelData()[2]);
            }

            ((ToolPar)参数).输出.圆心.Clear();
            List<Circle> L_circles = new List<Circle>();
            for (int i = 0; i < newExpectCircleCol.Count; i++)
            {
                HTuple handleID;
                HOperatorSet.CreateMetrologyModel(out handleID);

                HTuple width, height;
                HOperatorSet.GetImageSize(((ToolPar)参数).输入.图像, out width, out height);
                HOperatorSet.SetMetrologyModelImageSize(handleID, width[0], height[0]);
                HTuple index;
                HOperatorSet.AddMetrologyObjectCircleMeasure(handleID, newExpecCircleRow[i], newExpectCircleCol[i], newExpectCircleRadius[i], new HTuple(caliperLength), new HTuple(5), new HTuple(1), new HTuple(30), new HTuple(), new HTuple(), out index);

                //参数设置
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_transition"), new HTuple(polarity));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("num_measures"), new HTuple(cliperNum));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length1"), new HTuple(caliperLength));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length2"), new HTuple(caliperWidth));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_threshold"), new HTuple(threshold));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_select"), new HTuple(edgeSelect));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("min_score"), new HTuple(minScore));
                HOperatorSet.ApplyMetrologyModel(((ToolPar)参数).输入.图像, handleID);

                //显示所有卡尺
                if (showCaliper)
                {
                    HObject contours;
                    HTuple row, col;
                    HOperatorSet.GetMetrologyObjectMeasures(out contours, handleID, new HTuple("all"), new HTuple("all"), out row, out col);

                    GetImageWindow().DispObj(contours, "blue");
                    if (Frm_FindCircleTool.hasShown && Frm_FindCircleTool.taskName == taskName && Frm_FindCircleTool.toolName == toolName)
                        Frm_FindCircleTool.Instance.hWindow_Final1.DispObj(contours, "blue");
                }

                HTuple parameter;
                HObject circle;
                HOperatorSet.GetMetrologyObjectResult(handleID, new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"), out parameter);
                HOperatorSet.GetMetrologyObjectResultContour(out circle, handleID, new HTuple("all"), new HTuple("all"), new HTuple(1.5));

                if (ignorePointNum == 0)        //不忽略点
                {
                    if (parameter.Length >= 3)
                    {
                        ((ToolPar)参数).输出.圆心.Add(new XY(parameter[0], parameter[1]));
                        Circle circle1 = new Circle();
                        circle1.X = parameter[0];
                        circle1.Y = parameter[1];
                        circle1.R = parameter[2];
                        L_circles.Add(circle1);
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
                        if (Frm_FindCircleTool.hasShown && Frm_FindCircleTool.taskName == taskName && Frm_FindCircleTool.toolName == toolName)
                        {
                            HOperatorSet.GetPart(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                            HOperatorSet.GenCrossContourXld(out cross, row, col, new HTuple((row2 - row1) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                            Frm_FindCircleTool.Instance.hWindow_Final1.DispObj(cross, "orange");
                        }
                    }

                    HOperatorSet.ClearMetrologyModel(handleID);
                }
                else        //忽略指定点数
                {
                    if (parameter.Length >= 3)
                    {
                        HObject cross;
                        HTuple row1, col1, row2, col2;

                        HOperatorSet.GetPart(GetImageWindow().HWindowHalconID, out row1, out col1, out row2, out col2);
                        HOperatorSet.GenCrossContourXld(out cross, parameter[0], parameter[1], new HTuple((row2 - row1) / 90.0 + 1), new HTuple(0));                 //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                        if (Frm_FindCircleTool.hasShown && Frm_FindCircleTool.taskName == taskName && Frm_FindCircleTool.toolName == toolName)
                        {
                            HOperatorSet.GetPart(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                            HOperatorSet.GenCrossContourXld(out cross, parameter[0], parameter[1], new HTuple((row2 - row1) / 90.0 + 1), new HTuple(0));             //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                            Frm_FindCircleTool.Instance.hWindow_Final1.DispObj(cross, "green");
                        }

                        HTuple rows, cols;
                        HObject contours;
                        HOperatorSet.GetMetrologyObjectMeasures(out contours, handleID, new HTuple("all"), new HTuple("all"), out rows, out cols);
                        List<PosAndDistance> list = new List<PosAndDistance>();
                        for (int j = 0; j < rows.TupleLength(); j++)
                        {
                            HTuple distance1, temp;
                            HOperatorSet.DistancePc(circle, rows[j], cols[j], out distance1, out temp);
                            PosAndDistance posAndDistance = new PosAndDistance();
                            posAndDistance.row = rows[j];
                            posAndDistance.col = cols[j];
                            posAndDistance.distance = distance1.D;
                            list.Add(posAndDistance);
                        }

                        //距离排序
                        PosAndDistance temp1;
                        for (int j = 0; j < list.Count - 1; j++)
                        {
                            for (int k = j + 1; k < list.Count; k++)
                            {
                                if (list[j].distance > list[k].distance)
                                {
                                    temp1 = list[j];
                                    list[j] = list[k];
                                    list[k] = temp1;
                                }
                            }
                        }

                        if (list.Count - ignorePointNum < 3)
                        {
                            toolRunStatu = "忽略点数大于找到的点数导致有效点数不足以拟合圆";
                            if (!initRun)
                                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                            goto Exit;
                        }

                        double[] rows1 = new double[list.Count - ignorePointNum];
                        double[] cols1 = new double[list.Count - ignorePointNum];
                        List<PointF> list1 = new List<PointF>();
                        for (int k = 0; k < list.Count - ignorePointNum; k++)
                        {
                            PointF ppp = new PointF();
                            ppp.X = (float)list[k].row;
                            ppp.Y = (float)list[k].col;
                            rows1[k] = (float)list[k].row;
                            cols1[k] = (float)list[k].col;
                            list1.Add(ppp);
                        }
                        L_circles.Add(LeastSquaresFit(rows1, cols1));

                        ((ToolPar)参数).输出.圆心.Add(new XY(L_circles[i].X, L_circles[i].Y));

                        //显示合格点
                        //把点显示出来
                        if (showFeature)
                        {
                            HTuple rows2 = new HTuple();
                            HTuple cols2 = new HTuple();
                            for (int j = 0; j < list.Count - ignorePointNum; j++)
                            {
                                rows2[j] = (list[j].row);
                                cols2[j] = (list[j].col);
                            }

                            HObject cross3;
                            HTuple row3, col3, row4, col4;
                            HOperatorSet.GetPart(GetImageWindow().HWindowHalconID, out row3, out col3, out row4, out col4);
                            HOperatorSet.GenCrossContourXld(out cross3, rows2, cols2, new HTuple((row4 - row3) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b

                            GetImageWindow().DispObj(cross3, new HTuple("#ffb529"));
                            if (Frm_FindCircleTool.hasShown && Frm_FindCircleTool.taskName == taskName && Frm_FindCircleTool.toolName == toolName)
                            {
                                HOperatorSet.GetPart(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID, out row3, out col3, out row4, out col4);
                                HOperatorSet.GenCrossContourXld(out cross3, rows2, cols2, new HTuple((row4 - row3) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                                Frm_FindCircleTool.Instance.hWindow_Final1.DispObj(cross3, "#ffb529");
                            }

                            //显示被忽略的点
                            HObject cross5;
                            HTuple rows5 = new HTuple();
                            HTuple cols5 = new HTuple();
                            for (int j = list.Count - ignorePointNum; j < list.Count; j++)
                            {
                                rows5[j] = (list[j].row);
                                cols5[j] = (list[j].col);
                            }
                            HOperatorSet.GetPart(GetImageWindow().HWindowHalconID, out row3, out col3, out row4, out col4);
                            HOperatorSet.GenCrossContourXld(out cross5, rows5, cols5, new HTuple((row4 - row3) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b

                            GetImageWindow().DispObj(cross5, new HTuple("red"));
                            if (Frm_FindCircleTool.hasShown && Frm_FindCircleTool.taskName == taskName && Frm_FindCircleTool.toolName == toolName)
                            {
                                HOperatorSet.GetPart(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID, out row3, out col3, out row4, out col4);
                                HOperatorSet.GenCrossContourXld(out cross5, rows5, cols5, new HTuple((row4 - row3) / 90.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                                Frm_FindCircleTool.Instance.hWindow_Final1.DispObj(cross5, "red");
                            }
                        }
                    }

                    HOperatorSet.ClearMetrologyModel(handleID);
                }

                //显示圆
                if (showCircle && L_circles.Count > 0)
                {
                    HObject circle1;
                    HOperatorSet.GenCircle(out circle1, L_circles[i].X, L_circles[i].Y, L_circles[i].R);
                    DispObj(circle1, new HTuple("green"));
                    if (Frm_FindCircleTool.hasShown && Frm_FindCircleTool.taskName == taskName && Frm_FindCircleTool.toolName == toolName)
                    {
                        HOperatorSet.SetDraw(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID, "margin");
                        Frm_FindCircleTool.Instance.hWindow_Final1.DispObj(circle1, "green");
                    }
                }

                //显示圆心
                if (showCross && L_circles.Count > 0)
                {
                    HObject cross;
                    HTuple row6, col6, row7, col7;
                    HOperatorSet.GetPart(GetImageWindow().HWindowHalconID, out row6, out col6, out row7, out col7);
                    HOperatorSet.GenCrossContourXld(out cross, L_circles[i].X, L_circles[i].Y, new HTuple((row7 - row6) / 20.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                    DispObj(cross, new HTuple("green"));
                    if (Frm_MatchTool.hasShown && Frm_MatchTool.taskName == taskName && Frm_MatchTool.toolName == toolName)
                    {
                        HOperatorSet.GetPart(Frm_FindCircleTool.Instance.hWindow_Final1.HWindowHalconID, out row6, out col6, out row7, out col7);
                        HOperatorSet.GenCrossContourXld(out cross, L_circles[i].X, L_circles[i].Y, new HTuple((row7 - row6) / 20.0 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                        Frm_FindCircleTool.Instance.hWindow_Final1.DispObj(cross, "green");
                    }
                }
            }

            if (Frm_FindCircleTool.hasShown && Frm_FindCircleTool.taskName == taskName && Frm_FindCircleTool.toolName == toolName)
            {
                Frm_FindCircleTool.Instance.dgv_result.Rows.Clear();
                for (int i = 0; i < L_circles.Count; i++)
                {
                    int index = Frm_FindCircleTool.Instance.dgv_result.Rows.Add();
                    Frm_FindCircleTool.Instance.dgv_result.Rows[index].Cells[0].Value = i + 1;
                    Frm_FindCircleTool.Instance.dgv_result.Rows[index].Cells[1].Value = Math.Round(L_circles[i].X, 3);
                    Frm_FindCircleTool.Instance.dgv_result.Rows[index].Cells[2].Value = Math.Round(L_circles[i].Y, 3);
                    Frm_FindCircleTool.Instance.dgv_result.Rows[index].Cells[3].Value = Math.Round(L_circles[i].R, 3);
                }
            }

            if (((ToolPar)参数).输出.圆心.Count == 0)
            {
                toolRunStatu = "未查找到圆";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            sw.Stop();
            toolRunStatu = "运行成功";
        Exit:
            if (Frm_FindCircleTool.hasShown && Frm_FindCircleTool.taskName == taskName && Frm_FindCircleTool.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_FindCircleTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());

                if (toolRunStatu == "运行成功")
                    Frm_FindCircleTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                else
                    Frm_FindCircleTool.Instance.lbl_toolTip.ForeColor = Color.Red;

                Frm_FindCircleTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
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
        }
        [Serializable]
        public class P运行 { }
        [Serializable]
        internal class P输出
        {
            private List<XY> _圆心 = new List<XY>();
            public List<XY> 圆心
            {
                get { return _圆心; }
                set { _圆心 = value; }
            }
        }
        #endregion

    }

    public struct PosAndDistance
    {
        public double row;
        public double col;
        public double distance;
    }

}
