using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VM_Pro
{
    [Serializable]
    internal class NanChangCTTool : ToolBase
    {
        /// <summary>
        /// 南昌CT类构造器
        /// </summary>
        /// <param name="toolName"></param>
        /// <param name="taskName"></param>
        /// <param name="toolType"></param>
        internal NanChangCTTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

            ////自动连接输入
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.采集图像)
                {
                    InputItem inputItem = new InputItem();
                    inputItem.InputName = "原图像";
                    inputItem.inputType = DataType.Image;
                    inputItem.sourceTask = taskName;
                    inputItem.sourceTool = Task.curTask.L_toolList[i].toolName;
                    inputItem.sourceOutput = "图像";

                    L_inputItem.Add(inputItem);
                    //break;
                }
                if (Task.curTask.L_toolList[i].toolType == ToolType.推理识别)
                {
                    InputItem inputItem = new InputItem();
                    inputItem.InputName = "分割图";
                    inputItem.inputType = DataType.Image;
                    inputItem.sourceTask = taskName;
                    inputItem.sourceTool = Task.curTask.L_toolList[i].toolName;
                    inputItem.sourceOutput = "图像";

                    L_inputItem.Add(inputItem);
                }
            }
        }


        internal bool isX = true;

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
            if (((ToolPar)参数).输入.原图像 == null || ((ToolPar)参数).输入.分割图 == null)
            {
                toolRunStatu = "未指定输入图像";
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }
           
            try
            {
                string str = Task.FindTaskByName(taskName).FindToolByName("图像脚本").toolRunStatu;
                if (str != "运行成功")
                {
                    toolRunStatu = "图像脚本运行失败无数据";
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：图像脚本运行失败无数据", taskName, toolName), InfoType.Error);
                    goto Exit;
                }

                ((ToolPar)参数).输入.原图像 = ((PreconditionTool.ToolPar)((PreconditionTool)Task.FindTaskByName(taskName).FindToolByName("图像预处理_1")).参数).输出.图像;

                #region 引擎部署方式结果显示

                int ZJcount = 0;
                int Fjcount = 0;
                HTuple ZJrow = null, ZJcol = null;
                HTuple FJrow = null, FJcol = null;
                string isOKstr = "";
                string yiChangInfo = "";
                string OverHangFanWei = "";
                string OverHangMeanMin = "";
                long[] wrong = null;
                double[] Distance = null;


                #region 获取引擎部署的各项数据

                List<ToolTerminal> m_listOutputs = ((ImageEngineTool)Task.FindTaskByName(taskName).FindToolByName("图像脚本")).m_listOutputs;
                for (int i = 0; i < m_listOutputs.Count; i++)
                {
                    HTuple a = m_listOutputs[i].Value as HTuple;
                    if (a == null || a.Type.ToString() == "EMPTY")
                        continue;
                    switch (m_listOutputs[i].Name)
                    {
                        case "zhengNum":
                            ZJcount = a.I;
                            break;
                        case "fujiNum":
                            Fjcount = a.I;
                            break;
                        case "sorted_row":
                            ZJrow = a.LArr;
                            break;
                        case "sorted_col":
                            ZJcol = a.LArr;
                            break;
                        case "sortfu_row":
                            FJrow = a.LArr;
                            break;
                        case "sortfu_col":
                            FJcol = a.LArr;
                            break;
                        case "Distance11":
                            Distance = a.DArr;
                            break;
                        case "wrong":
                            wrong = a.LArr;
                            break;
                        case "yichang":
                            yiChangInfo = a.S;
                            break;
                        case "O_Result":
                            isOKstr = a.S;
                            break;
                        case "OverHang":
                            OverHangFanWei = a.S;
                            break;
                        case "mean_min":
                            OverHangMeanMin = a.S;
                            break;
                        default:
                            break;
                    }
                }

                #endregion

                #region ①：更改当前窗体图片的大小，给图片加高

                int Width = 1024; int height = 512;
                HOperatorSet.GenImageConst(out HObject iii, "byte", Width, height + 150);   //创建一张高度比原图高300的图像
                HOperatorSet.OverpaintGray(iii, ((ToolPar)参数).输入.原图像);  //把原图覆盖到该图像，可看成就是原图，但高度大了300且填为黑色
                DispImage(iii);

                #endregion

                #region 显示正负极区域
                if (ZJrow != null && ZJcol != null)
                {
                    HOperatorSet.GenRectangle1(out HObject zjregion, ZJrow - 2, ZJcol - 2, ZJrow + 2, ZJcol + 2);
                    GetImageWindow().DispObj(zjregion, "blue", "fill");

                }
                else
                {
                    FuncLib.ShowMessageBox("正极区域点获取数据为空", InfoType.Tip);
                }
                if (FJrow != null && FJcol != null)
                {
                    HOperatorSet.GenRectangle1(out HObject fjregion, FJrow - 2, FJcol - 2, FJrow + 2, FJcol + 2);
                    GetImageWindow().DispObj(fjregion, "green", "fill");
                }
                else
                {
                    FuncLib.ShowMessageBox("负极区域点获取数据为空", InfoType.Tip);
                }


                #endregion

                #region 显示正极区域红色部分

                if (wrong != null && wrong.Length > 0)
                {
                    for (int i = 0; i < wrong.Length; i++)
                    {
                        HOperatorSet.GenRectangle1(out HObject zjregion1, ZJrow[wrong[i]] - 2, ZJcol[wrong[i]] - 2, ZJrow[wrong[i]] + 2, ZJcol[wrong[i]] + 2);
                        GetImageWindow().DispObj(zjregion1, "red", "fill");
                    }
                }


                #endregion

                #region 显示OverHang文字信息
                StringBuilder S_resultJuLi = new StringBuilder();
                int textRow = 0, textCol = 0;
                for (int i = 0; i < (Distance.Length + 1) / 2; i++)
                {
                    textRow = 400 + i % 20 * 15;
                    textCol = 10 + i / 20 * 160;
                    string _currentJuLi = "L" + (i + 1) + ":" + Distance[i * 2].ToString("f2") + "、" + Distance[i * 2 + 1].ToString("f2");
                    S_resultJuLi.Append(_currentJuLi + ",");
                    bool CurrentIsNG = false;
                    //判断当前是否NG
                    if (wrong != null && wrong.Length > 0)
                    {
                        for (int j = 0; j < wrong.Length; j++)
                        {
                            if (i == wrong[j])
                            {
                                CurrentIsNG = true;
                                break;
                            }
                        }
                    }

                    if (CurrentIsNG)
                    {
                        GetImageWindow().DispText(_currentJuLi, "red", textRow, textCol, 14, bold: "true");
                    }
                    else
                    {
                        GetImageWindow().DispText(_currentJuLi, "yellow", textRow, textCol, 14, bold: "true");
                    }

                }

                #endregion

                #region 显示OverHang范围

                GetImageWindow().DispText("OverHang【" + OverHangFanWei + "】", "yellow", 350, 10, 22);
                GetImageWindow().DispText(OverHangMeanMin, "green", 375, 10, 22);

                #endregion

                #region 显示OK/NG
                if (isOKstr.Contains("OK"))
                {
                    GetImageWindow().DispText(isOKstr, "green", "bottom", "right", 24);

                }
                else
                {
                    GetImageWindow().DispText(isOKstr + "-" + yiChangInfo, "red", "bottom", "right", 24);
                    toolRunStatu = "运行失败";
                }
                #endregion

                #region 显示点数

                string ZFcountStr = "\r\n正极点数：" + ZJcount + "\r\n负极点数：" + Fjcount;
                if (ZJcount == 98 && Fjcount == 99)
                {
                    GetImageWindow().DispText(ZFcountStr, "green", "top", "left", 24);
                }
                else
                {
                    GetImageWindow().DispText(ZFcountStr, "red", "top", "left", 24);
                }


                #endregion

                string _currentImgFileName = ((ImageTool)Task.FindTaskByName(taskName).FindToolByName("采集图像")).currentImageName.Split('.')[0];
                GetImageWindow().DispText(_currentImgFileName, "yellow", "top", "left", 24);

                #region 存储CSV数据

                StringBuilder sb_WriteCSV = new StringBuilder();
                sb_WriteCSV.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm") + ",");    //进站时间
                sb_WriteCSV.Append(_currentImgFileName.Split('-')[0].ToString() + "，,");    //电芯编号
                sb_WriteCSV.Append(_currentImgFileName.Split('-')[1] + ",");    //角位
                sb_WriteCSV.Append(_currentImgFileName.Split('-')[2] + ",");    //方向
                sb_WriteCSV.Append(isOKstr + ",");   //结果
                sb_WriteCSV.Append(yiChangInfo + ",");   //NG原因
                sb_WriteCSV.Append(ZJcount > Fjcount ? Fjcount.ToString() + "," : ZJcount.ToString() + ",");  //层数
                sb_WriteCSV.Append(OverHangFanWei + ",");   //检测规格

                sb_WriteCSV.Append(Distance.Min() + ",");        //最小值
                sb_WriteCSV.Append(Distance.Max() + ",");       //最大值
                sb_WriteCSV.Append(Distance.Average() + ",");   //平均值
                                                                //距离信息
                sb_WriteCSV.Append(S_resultJuLi.ToString() + ",");
                IniFiles.WriteCSV(sb_WriteCSV.ToString());
                S_resultJuLi.Clear();
                sb_WriteCSV.Clear();

                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName,ex.Message), InfoType.Error);
                toolRunStatu = "运行异常：" + ex.Message;
                goto Exit;
            }
            if (false)  //屏蔽翻译部署
            {
                //try
                //{
                //    #region 抓取图像名称，输出是X还是Y类型

                //    string _currentImgName = "";
                //    string ClassName = "";
                //    try
                //    {
                //        if (((ImageTool)Task.FindTaskByName(taskName).FindToolByName("采集图像")).imageSource == ImageSource.FromFile)
                //        {
                //            _currentImgName = ((ImageTool)Task.FindTaskByName(taskName).FindToolByName("采集图像")).imagePath;
                //            _currentImgName = Regex.Match(_currentImgName, @".+\\(.+)").Groups[1].Value;
                //        }
                //        else if (((ImageTool)Task.FindTaskByName(taskName).FindToolByName("采集图像")).imageSource == ImageSource.FromDirectory)
                //        {
                //            _currentImgName = ((ImageTool)Task.FindTaskByName(taskName).FindToolByName("采集图像")).currentImageName;
                //        }
                //        else
                //        {
                //            //走到此处说明是勾选了，但图像是通过相机采集的
                //        }

                //        if (_currentImgName.Contains("."))
                //        {
                //            _currentImgName = _currentImgName.Substring(0, _currentImgName.LastIndexOf('.'));
                //        }
                //        ClassName = _currentImgName.Split('-')[1] + _currentImgName.Split('-')[2];
                //    }
                //    catch (Exception)
                //    {
                //        _currentImgName = "异常：未识别到图像名称";
                //    }
                //    if (ClassName.ToUpper() == "1X" || ClassName.ToUpper() == "3X")
                //    {
                //        isX = true;
                //    }
                //    else
                //    {
                //        isX = false;
                //    }
                //    #endregion


                //    #region 一：找正极点位置


                //    #region ①：先对正极区域进行一个处理，强化正极区域的线条特征，输出清晰的正极线条图像

                //    //将正极区域部分扣取出来
                //    HObject ZhengJiRegion, ZhengJiImg;
                //    HOperatorSet.Threshold(((ToolPar)参数).输入.分割图, out ZhengJiRegion, 2, 2);
                //    HOperatorSet.FillUp(ZhengJiRegion, out ZhengJiRegion);
                //    HOperatorSet.ReduceDomain(((ToolPar)参数).输入.原图像, ZhengJiRegion, out ZhengJiImg);

                //    //预处理正极区域部分，凸显线条特征
                //    HObject ImgZJQingXi;
                //    HOperatorSet.MeanImage(ZhengJiImg, out ImgZJQingXi, 3, 3);
                //    HOperatorSet.ScaleImageMax(ImgZJQingXi, out ImgZJQingXi);
                //    HOperatorSet.Emphasize(ImgZJQingXi, out ImgZJQingXi, 12, 12, 100);
                //    HOperatorSet.GrayDilationRect(ImgZJQingXi, out ImgZJQingXi, 4, 1);
                //    HOperatorSet.GrayErosionRect(ImgZJQingXi, out ImgZJQingXi, 15, 1);
                //    HOperatorSet.GrayDilationRect(ImgZJQingXi, out ImgZJQingXi, 17, 1);

                //    #endregion

                //    #region ②：根据清晰的正极线条图像，提取正极线条，并输出线条的行列坐标以及灰度值

                //    //根据线条特征提取线条区域
                //    HObject ZJXianTiaoRegion; HTuple ZJXianTiaoNum;
                //    HOperatorSet.Threshold(ImgZJQingXi, out ZJXianTiaoRegion, 255, 255);
                //    HOperatorSet.Connection(ZJXianTiaoRegion, out HObject ZJXianTiaoRegion1);
                //    HOperatorSet.SelectShape(ZJXianTiaoRegion1, out ZJXianTiaoRegion, "area", "and", 100, 999999);
                //    HOperatorSet.CountObj(ZJXianTiaoRegion, out ZJXianTiaoNum);
                //    if (ZJXianTiaoNum.D > 98)
                //    {
                //        HOperatorSet.SelectShape(ZJXianTiaoRegion1, out ZJXianTiaoRegion, "area", "and", 150, 999999);
                //    }
                //    else if (ZJXianTiaoNum.D < 98)
                //    {
                //        HOperatorSet.SelectShape(ZJXianTiaoRegion1, out ZJXianTiaoRegion, "area", "and", 50, 999999);
                //    }

                //    HOperatorSet.SortRegion(ZJXianTiaoRegion, out ZJXianTiaoRegion, "upper_left", "true", "column");
                //    //获取排序后的线条区域顶点坐标及灰度值
                //    HTuple ZJ_Rows, ZJ_Cols, ZJ_Grays;
                //    GenRegionsGetTopXYGray(true, ZhengJiImg, ZJXianTiaoRegion, out ZJ_Rows, out ZJ_Cols, out ZJ_Grays);

                //    #endregion

                //    #region ③：得到正极点位置之后，过滤可能存在的异常点

                //    int ZJDelNum = 0;
                //    int I_zjNum = ZJ_Rows.Length;
                //    while (I_zjNum > 98 && ZJDelNum < 5)
                //    {
                //        ZJDelNum++;
                //        double ZJminGray = ZJ_Grays.TupleMin();
                //        HOperatorSet.TupleFind(ZJ_Grays, ZJminGray, out HTuple indexes);
                //        HTuple selected;
                //        if (indexes == 0 || indexes == -1)
                //        {
                //            HOperatorSet.TupleSelect(ZJ_Grays, indexes + 2, out selected);
                //            indexes = 0;
                //        }
                //        else
                //            HOperatorSet.TupleSelect(ZJ_Grays, indexes - 1, out selected);
                //        if ((selected.D - ZJminGray) > 20)
                //        {
                //            HOperatorSet.TupleRemove(ZJ_Rows, indexes, out ZJ_Rows);
                //            HOperatorSet.TupleRemove(ZJ_Cols, indexes, out ZJ_Cols);
                //            HOperatorSet.TupleRemove(ZJ_Grays, indexes, out ZJ_Grays);
                //            I_zjNum--;
                //        }
                //        else
                //        {
                //            ZJ_Grays[indexes] = 200;
                //        }
                //    }

                //    if (I_zjNum == 97 || I_zjNum == 96)
                //    {
                //        HOperatorSet.AreaCenter(ZJXianTiaoRegion, out HTuple area, out HTuple row, out HTuple col);
                //        HOperatorSet.TupleMax(area, out HTuple AreaMax);
                //        HOperatorSet.TupleMean(area, out HTuple AreaMean);
                //        HTuple a = AreaMax / AreaMean;
                //        if (a > 1.8)
                //        {
                //            HOperatorSet.TupleFind(area, AreaMax, out HTuple areaMaxIndex);
                //            HTuple addCol = col[areaMaxIndex];
                //            HOperatorSet.SelectObj(ZJXianTiaoRegion, out HObject addLine, areaMaxIndex + 1);
                //            HOperatorSet.GetRegionPoints(addLine, out HTuple lineRows, out HTuple lineCols);
                //            HOperatorSet.GetGrayval(ZhengJiImg, lineRows, lineCols, out HTuple lineGrays);
                //            HOperatorSet.TupleMax(lineRows, out HTuple lineMax);
                //            HOperatorSet.TupleMin(lineRows, out HTuple lineMin);
                //            HOperatorSet.TupleMean(lineGrays, out HTuple addGray);
                //            HTuple addRow = row[areaMaxIndex] - 0.5 * (lineMax - lineMin);

                //            HOperatorSet.TupleInsert(ZJ_Rows, areaMaxIndex, addRow, out ZJ_Rows);
                //            HOperatorSet.TupleInsert(ZJ_Cols, areaMaxIndex, addCol, out ZJ_Cols);
                //            HOperatorSet.TupleInsert(ZJ_Grays, areaMaxIndex, addGray, out ZJ_Grays);
                //            I_zjNum++;
                //        }
                //    }


                //    #endregion


                //    #endregion


                //    #region 二：找负极点位置——大方法1


                //    #region ①：先把负极区域从原图当中抠取出来

                //    //把负极区域所在的区域给扣取出来
                //    HObject FuJiRegion, FuJiImg;
                //    HOperatorSet.Threshold(((ToolPar)参数).输入.分割图, out FuJiRegion, 1, 1);
                //    HOperatorSet.FillUp(FuJiRegion, out FuJiRegion);
                //    HOperatorSet.ReduceDomain(((ToolPar)参数).输入.原图像, FuJiRegion, out FuJiImg);
                //    //HOperatorSet.WriteImage(((ToolPar)参数).输入.分割图, "png", 0, "d:\\test");
                //    #endregion

                //    HObject ImgFJQingXi, FJLines;
                //    HTuple FJXianTiaoNum;

                //    #region ②：对负极区域进行图像预处理，看是否能找到99条

                //    HOperatorSet.Emphasize(FuJiImg, out ImgFJQingXi, 12, 3, 12);
                //    HOperatorSet.GrayDilationRect(ImgFJQingXi, out ImgFJQingXi, 2, 1);
                //    HOperatorSet.GrayErosionRect(ImgFJQingXi, out ImgFJQingXi, 7, 1);
                //    HOperatorSet.GrayDilationRect(ImgFJQingXi, out ImgFJQingXi, 7, 1);
                //    HOperatorSet.LinesGauss(ImgFJQingXi, out FJLines, new HTuple(1.73205), new HTuple(13.3623), new HTuple(25.6967), "light", "false", "parabolic", "true");
                //    HOperatorSet.UnionCollinearContoursXld(FJLines, out FJLines, 20, 1, 2, 0.5, "attr_keep");
                //    HOperatorSet.SelectShapeXld(FJLines, out FJLines, "height", "and", 10, 99999);
                //    HOperatorSet.CountObj(FJLines, out FJXianTiaoNum);

                //    #endregion

                //    if (FJXianTiaoNum.D > 99)
                //    {
                //        #region ③：对负极区域进行方法二的处理

                //        HOperatorSet.HeightWidthRatioXld(FJLines, out HTuple height1, out HTuple width, out HTuple ratio);
                //        HOperatorSet.LinesGauss(ImgFJQingXi, out HObject FJLines1, new HTuple(1.73205), new HTuple(13.3623), new HTuple(25.6967), "light", "false", "parabolic", "true");
                //        HOperatorSet.TupleMin(height1, out HTuple height1Min);
                //        HOperatorSet.TupleRound(height1Min, out height1Min);
                //        HOperatorSet.SelectShapeXld(FJLines1, out FJLines1, "height", "and", height1Min + 2, 99999);
                //        HOperatorSet.CountObj(FJLines1, out HTuple fjline1Num);
                //        if (fjline1Num.D < FJXianTiaoNum.D)
                //        {
                //            FJLines = FJLines1;
                //            HOperatorSet.CountObj(FJLines, out FJXianTiaoNum);
                //        }
                //        #endregion
                //    }

                //    HTuple FJ_Rows, FJ_Cols, FJ_Grays;
                //    //得到最终的负极线条区域，进行排序后，输出相应的负极坐标以及灰度值信息
                //    HOperatorSet.SortContoursXld(FJLines, out FJLines, "upper_left", "true", "column");
                //    GenRegionsGetTopXYGray(false, ((ToolPar)参数).输入.原图像, FJLines, out FJ_Rows, out FJ_Cols, out FJ_Grays);

                //    if (FJXianTiaoNum.D == 100 || FJXianTiaoNum.D == 101)
                //    {
                //        int delnum = 0;
                //        HTuple delFJROWs = new HTuple();
                //        HTuple delFJCols = new HTuple();
                //        HTuple delFJGrays = new HTuple();
                //        int count = 0;
                //        while (FJXianTiaoNum.D > 99 && delnum < 5)
                //        {
                //            HOperatorSet.TupleMin(FJ_Grays, out HTuple delFjGray);
                //            HOperatorSet.TupleFind(FJ_Grays, delFjGray, out HTuple delFjIndex);
                //            if (delFjIndex.D > 1)
                //            {
                //                HOperatorSet.CreateFunct1dArray(FJ_Grays, out HTuple function);
                //                HOperatorSet.DerivateFunct1d(function, "first", out HTuple derivative);
                //                HOperatorSet.TupleAbs(derivative, out derivative);
                //                HOperatorSet.TupleMax(derivative, out HTuple DaoShuMax);
                //                HOperatorSet.TupleFind(derivative, DaoShuMax, out HTuple DaoShuIndex);
                //                delFjIndex = DaoShuIndex - 2;
                //            }
                //            try
                //            {
                //                HOperatorSet.TupleSelect(FJ_Grays, delFjIndex - 1, out HTuple selectedGray);
                //                if (selectedGray - delFjGray > 15)
                //                {
                //                    HOperatorSet.TupleRemove(FJ_Rows, delFjIndex, out delFJROWs);
                //                    HOperatorSet.TupleRemove(FJ_Cols, delFjIndex, out delFJCols);
                //                    HOperatorSet.TupleRemove(FJ_Grays, delFjIndex, out delFJGrays);
                //                    count = delFJROWs.Length;
                //                }
                //                else
                //                {
                //                    FJ_Grays[delFjIndex] = 200;
                //                }
                //            }
                //            catch
                //            {
                //            }
                //            delnum++;
                //        }

                //        if (count == 99)
                //        {
                //            FJ_Rows = delFJROWs;
                //            FJ_Cols = delFJCols;
                //            FJ_Grays = delFJGrays;
                //        }
                //    }


                //    #endregion




                //    #region 找负极点位置——大方法2

                //    if (FJ_Rows.Length != 99)
                //    {
                //        HOperatorSet.Emphasize(FuJiImg, out HObject ImgFJQingXi1, 12, 6, 10);
                //        HOperatorSet.GrayErosionRect(ImgFJQingXi1, out ImgFJQingXi1, 4, 1);
                //        //HOperatorSet.GrayDilationRect(ImgFJQingXi1, out ImgFJQingXi1, 4, 1);
                //        HOperatorSet.ConvolImage(ImgFJQingXi1, out ImgFJQingXi1, new HTuple(3, 3, 1,
                //                                                                        0, 1, 0,
                //                                                                        1, 1, 0,
                //                                                                        0, 1, 0), "mirrored");
                //        HOperatorSet.LinesGauss(ImgFJQingXi1, out FJLines, new HTuple(1.73205), new HTuple(22.6131), new HTuple(26.2107), "light", "false", "parabolic", "true");
                //        HOperatorSet.UnionCollinearContoursXld(FJLines, out FJLines, 10, 1, 2, 0.5, "attr_keep");
                //        HOperatorSet.SelectShapeXld(FJLines, out FJLines, "height", "and", 9, 99999);
                //        HOperatorSet.SortContoursXld(FJLines, out FJLines, "upper_left", "true", "column");
                //        HOperatorSet.CountObj(FJLines, out FJXianTiaoNum);
                //        GenRegionsGetTopXYGray(false, ((ToolPar)参数).输入.原图像, FJLines, out FJ_Rows, out FJ_Cols, out FJ_Grays);

                //        if (FJXianTiaoNum.D > 99)
                //        {
                //            int num = Convert.ToInt32(FJXianTiaoNum.D);
                //            int delnum = 0;
                //            while (num > 99 && delnum < 5)
                //            {
                //                HOperatorSet.TupleMin(FJ_Grays, out HTuple delFjGray);
                //                HOperatorSet.TupleFind(FJ_Grays, delFjGray, out HTuple delFjIndex);
                //                if (delFjIndex.D > 1)
                //                {
                //                    HOperatorSet.CreateFunct1dArray(FJ_Grays, out HTuple function);
                //                    HOperatorSet.DerivateFunct1d(function, "first", out HTuple derivative);
                //                    HOperatorSet.TupleAbs(derivative, out derivative);
                //                    HOperatorSet.TupleMax(derivative, out HTuple DaoShuMax);
                //                    HOperatorSet.TupleFind(derivative, DaoShuMax, out HTuple DaoShuIndex);
                //                    delFjIndex = DaoShuIndex - 2;
                //                }
                //                try
                //                {
                //                    HOperatorSet.TupleSelect(FJ_Grays, delFjIndex - 1, out HTuple selectedGray);
                //                    if (selectedGray - delFjGray > 15)
                //                    {
                //                        HOperatorSet.TupleRemove(FJ_Rows, delFjIndex, out FJ_Rows);
                //                        HOperatorSet.TupleRemove(FJ_Cols, delFjIndex, out FJ_Cols);
                //                        HOperatorSet.TupleRemove(FJ_Grays, delFjIndex, out FJ_Grays);
                //                        num--;
                //                    }
                //                    else
                //                    {
                //                        FJ_Grays[delFjIndex] = 200;
                //                    }
                //                }
                //                catch
                //                {
                //                }
                //                delnum++;
                //            }
                //        }

                //    }



                //    #endregion




                //    #region 三：负极结合正极点位置，对异常点进行过滤


                //    #region ①：根据正负极的位置点，判断一下当前负极是否需要重新采用其他方式找点【负极区域法查找暂未开放】

                //    //1.若负极点数非99但正极点数是98的话，则负极使用区域法进行查找，后续作为选项开放出来
                //    if (FJ_Rows.Length != 99 && ZJ_Rows.Length == 98)
                //    {
                //        #region CT_Neg_Region123

                //        //HOperatorSet.WriteImage(((ToolPar)参数).输入.原图像, "png", 0, "d:\\31ImgMaster");
                //        HObject fjThreeQingXi;
                //        HOperatorSet.Emphasize(FuJiImg, out fjThreeQingXi, 12, 3, 10);
                //        //HOperatorSet.WriteImage(FuJiImg, "png", 0, "d:\\FJjietu");
                //        HOperatorSet.GrayErosionRect(fjThreeQingXi, out fjThreeQingXi, 3, 1);
                //        HOperatorSet.ConvolImage(fjThreeQingXi, out fjThreeQingXi, new HTuple(3, 3, 1,
                //                                                                          0, 1, 0,
                //                                                                          1, 0, 0,
                //                                                                          0, 1, 0), "mirrored");
                //        HOperatorSet.Threshold(fjThreeQingXi, out HObject fjTwoRegion, 255, 255);
                //        HOperatorSet.Connection(fjTwoRegion, out HObject FJLinShiRegion);
                //        HOperatorSet.SelectShape(FJLinShiRegion, out fjTwoRegion, "area", "and", 10, 500);
                //        HOperatorSet.SortRegion(fjTwoRegion, out fjTwoRegion, "upper_left", "true", "column");
                //        HOperatorSet.CountObj(fjTwoRegion, out HTuple num1);
                //        if (num1.D > 99)
                //        {
                //            HOperatorSet.AreaCenter(fjTwoRegion, out HTuple FJ3Areas, out HTuple FJ3Rows, out HTuple FJ3Cols);
                //            HOperatorSet.TupleMin(FJ3Areas, out HTuple FJ3MinArea);
                //            HOperatorSet.TupleMean(FJ3Areas, out HTuple FJ3MeanArea);
                //            if (FJ3MinArea < FJ3MeanArea / 2)
                //            {
                //                HOperatorSet.SelectShape(FJLinShiRegion, out fjTwoRegion, "area", "and", FJ3MinArea.D + 10, 500);
                //                HOperatorSet.CountObj(fjTwoRegion, out num1);
                //                HOperatorSet.SortRegion(fjTwoRegion, out fjTwoRegion, "upper_left", "true", "column");
                //                HOperatorSet.CountObj(fjTwoRegion, out num1);
                //            }
                //        }
                //        GenRegionsGetTopXYGray(true, ((ToolPar)参数).输入.原图像, fjTwoRegion, out FJ_Rows, out FJ_Cols, out FJ_Grays);

                //        #endregion
                //        if (FJ_Rows.Length > 99)
                //        {
                //            #region Filter

                //            int num = Convert.ToInt32(FJ_Rows.Length);
                //            int delnum = 0;
                //            HTuple FJ_Rows3 = FJ_Rows;
                //            HTuple FJ_Cols3 = FJ_Cols;
                //            HTuple FJ_Grays3 = FJ_Grays;
                //            while (num > 99 && delnum < 5)
                //            {
                //                HOperatorSet.TupleMin(FJ_Grays3, out HTuple delFjGray);
                //                HOperatorSet.TupleFind(FJ_Grays3, delFjGray, out HTuple delFjIndex);
                //                if (delFjIndex.Length > 1)
                //                {
                //                    HOperatorSet.CreateFunct1dArray(FJ_Grays3, out HTuple function);
                //                    HOperatorSet.DerivateFunct1d(function, "first", out HTuple derivative);
                //                    HOperatorSet.TupleAbs(derivative, out derivative);
                //                    HOperatorSet.TupleMax(derivative, out HTuple DaoShuMax);
                //                    HOperatorSet.TupleFind(derivative, DaoShuMax, out HTuple DaoShuIndex);
                //                    delFjIndex = DaoShuIndex - 2;
                //                }
                //                try
                //                {
                //                    HOperatorSet.TupleSelect(FJ_Grays3, delFjIndex - 1, out HTuple selectedGray);
                //                    if (selectedGray - delFjGray > 15)
                //                    {
                //                        HOperatorSet.TupleRemove(FJ_Rows3, delFjIndex, out FJ_Rows3);
                //                        HOperatorSet.TupleRemove(FJ_Cols3, delFjIndex, out FJ_Cols3);
                //                        HOperatorSet.TupleRemove(FJ_Grays3, delFjIndex, out FJ_Grays3);
                //                        num--;
                //                    }
                //                    else
                //                    {
                //                        FJ_Grays3[delFjIndex] = 200;
                //                    }
                //                }
                //                catch
                //                {
                //                }
                //                delnum++;
                //            }

                //            #endregion

                //            HOperatorSet.TupleAbs(FJ_Rows3.Length - 99, out HTuple a);
                //            HOperatorSet.TupleAbs(FJ_Rows.Length - 99, out HTuple b);
                //            if (FJ_Rows3.Length == 99 || a <= b)
                //            {
                //                FJ_Rows = FJ_Rows3;
                //                FJ_Cols = FJ_Cols3;
                //                FJ_Grays = FJ_Grays3;
                //            }


                //        }

                //    }






                //    #endregion


                //    #region ②：电芯倾斜、掉片异常检查

                //    if (ZJ_Cols != null && FJ_Cols != null && ZJ_Cols[0] - FJ_Cols[1] > 8)
                //    {
                //        NGInfo = "电芯倾斜";
                //        ZJ_OK = false;
                //    }


                //    HOperatorSet.CreateFunct1dArray(FJ_Cols, out HTuple Function1);
                //    HOperatorSet.DerivateFunct1d(Function1, "first", out HTuple Derivative1);
                //    if (Derivative1.TupleMax() > 20)
                //    {
                //        NGInfo += "|掉片";
                //        ZJ_OK = false;
                //    }
                //    #endregion


                //    #region ③：负极根据当前的信息，进行异常点过滤——已屏蔽


                //    int FJDelNum = 0;

                //    int I_fjNum = FJ_Rows.Length;
                //    if (false)  //暂时屏蔽掉了
                //    {
                //        if (I_fjNum > 99 && FJDelNum < 3)
                //        {
                //            FJDelNum++;
                //            double fjMingray = FJ_Grays.LArr.Min();
                //            HOperatorSet.TupleFind(FJ_Grays, fjMingray, out HTuple indices);
                //            if (indices.I > 1)
                //            {
                //                HOperatorSet.CreateFunct1dArray(FJ_Grays, out HTuple function);
                //                HOperatorSet.DerivateFunct1d(function, "first", out HTuple derivative);
                //                derivative = derivative.TupleAbs(); //取绝对值
                //                HOperatorSet.TupleFind(derivative, derivative.TupleMax(), out HTuple indices5);
                //                indices = indices5 - 2;
                //            }
                //            HTuple selectedgray;
                //            if (indices == 0)
                //                HOperatorSet.TupleSelect(FJ_Grays, indices + 1, out selectedgray);
                //            else
                //                HOperatorSet.TupleSelect(FJ_Grays, indices - 1, out selectedgray);
                //            if ((selectedgray.D - fjMingray) > 30)
                //            {
                //                HOperatorSet.TupleRemove(FJ_Rows, indices, out FJ_Rows);
                //                HOperatorSet.TupleRemove(FJ_Cols, indices, out FJ_Cols);
                //                HOperatorSet.TupleRemove(FJ_Grays, indices, out FJ_Grays);
                //                I_fjNum--;
                //            }
                //            else
                //            {
                //                ZJ_Grays[indices] = 200;
                //            }
                //        }

                //        //最后的防呆，若此时负极点还大于99的话，则直接删点
                //        if (I_fjNum > 99)
                //        {
                //            HOperatorSet.CreateFunct1dArray(FJ_Cols, out HTuple function);
                //            HOperatorSet.DerivateFunct1d(function, "first", out HTuple derivative);
                //            HTuple chaju = derivative.TupleSelectRange(3, 102);
                //            HTuple MinChaJu = chaju.TupleMin();
                //            HOperatorSet.TupleFind(chaju, MinChaJu, out HTuple indexes);
                //            HOperatorSet.TupleRemove(FJ_Cols, indexes, out FJ_Cols);
                //            HOperatorSet.TupleRemove(FJ_Rows, indexes, out FJ_Rows);
                //            HOperatorSet.TupleRemove(FJ_Grays, indexes, out FJ_Grays);
                //            I_fjNum--;
                //            FJDelNum = -1;
                //        }
                //    }

                //    #endregion


                //    #endregion


                //    #region 四：显示


                //    #region ①：更改当前窗体图片的大小，给图片加高

                //    int Width = 1024; int height = 512;
                //    HOperatorSet.GenImageConst(out HObject iii, "byte", Width, height + 150);   //创建一张高度比原图高300的图像
                //    HOperatorSet.OverpaintGray(iii, ((ToolPar)参数).输入.原图像);  //把原图覆盖到该图像，可看成就是原图，但高度大了300且填为黑色
                //    DispImage(iii);

                //    #endregion

                //    #region ②：显示正负极圆点—该点NG的话会在③重复标红
                //    HOperatorSet.TupleRound(FJ_Rows, out HTuple RegionFJ_Rows);
                //    HOperatorSet.TupleRound(ZJ_Rows, out HTuple RegionZJ_Rows);
                //    HOperatorSet.TupleRound(FJ_Cols, out HTuple RegionFJ_Cols);
                //    HOperatorSet.TupleRound(ZJ_Cols, out HTuple RegionZJ_Cols);
                //    //int ForIndex = 0;
                //    //for (ForIndex = 0; ForIndex < FJ_Rows.Length; ForIndex++)
                //    //{
                //    //    HOperatorSet.GenCircle(out HObject FJResultRegion, RegionFJ_Rows[ForIndex], RegionFJ_Cols[ForIndex], 3);
                //    //    GetImageWindow().DispObj(FJResultRegion, "green", "fill");

                //    //}

                //    //for (ForIndex = 0; ForIndex < ZJ_Rows.Length; ForIndex++)
                //    //{
                //    //    HOperatorSet.GenCircle(out HObject ZJResultRegion, RegionZJ_Rows[ForIndex], RegionZJ_Cols[ForIndex], 3);
                //    //    GetImageWindow().DispObj(ZJResultRegion, "blue", "fill");

                //    //}

                //    HOperatorSet.GenRectangle1(out HObject fjregion, RegionFJ_Rows - 2, RegionFJ_Cols - 2, RegionFJ_Rows + 2, RegionFJ_Cols + 2);
                //    HOperatorSet.GenRectangle1(out HObject zjregion, RegionZJ_Rows - 2, RegionZJ_Cols - 2, RegionZJ_Rows + 2, RegionZJ_Cols + 2);
                //    GetImageWindow().DispObj(fjregion, "green", "fill");
                //    GetImageWindow().DispObj(zjregion, "blue", "fill");

                //    #endregion

                //    #region ③：显示文字信息—根据正负极的坐标点，求出正负极的距离，并显示相应的距离信息，判定结果

                //    List<double> JuliArray = new List<double>();
                //    int JuLiNum = 0;
                //    if (I_fjNum < I_zjNum)
                //        JuLiNum = I_fjNum;
                //    else
                //        JuLiNum = I_zjNum;
                //    double ImgBiLi = 1000.0 / 512;    //原图与截取图像的比例
                //    ImgBiLi = Math.Round(ImgBiLi, 2);
                //    HTuple d1, d2 = new HTuple();
                //    List<double> d_Array = new List<double>();
                //    int textRow = 0, textCol = 0;
                //    //HOperatorSet.TupleRound(FJ_Rows, out FJ_Rows);
                //    //HOperatorSet.TupleRound(ZJ_Rows, out ZJ_Rows);
                //    StringBuilder S_resultJuLi = new StringBuilder();
                //    for (int i = 0; i < JuLiNum; i++)
                //    {
                //        d1 = (ZJ_Rows[i] - (int)(double)FJ_Rows[i]) * 0.02 * ImgBiLi;
                //        if (i != JuLiNum - 1 || I_fjNum > I_zjNum) //当正负极点数相同时，最后一层距离d2按前层的算
                //        {
                //            d2 = ((int)(double)ZJ_Rows[i] - (int)(double)FJ_Rows[i + 1]) * 0.02 * ImgBiLi;
                //        }
                //        else
                //        {
                //            //d2 = 上一次数值
                //        }

                //        d_Array.Add(d1);
                //        d_Array.Add(d2);
                //        textRow = 400 + i % 20 * 15;
                //        textCol = 10 + i / 20 * 160;
                //        string _currentJuLi = "L" + (i + 1) + ":" + d1.D.ToString("f2") + "、" + d2.D.ToString("f2");
                //        S_resultJuLi.Append(_currentJuLi + ",");
                //        if (isX)
                //        {
                //            GetImageWindow().DispText("Over Hang【0.75-99】", "yellow", 350, 10, 22);
                //            if (d1 > 0.75 && d1 < 99 && d2 > 0.75 && d2 < 99)
                //            {
                //                GetImageWindow().DispText(_currentJuLi, "yellow", textRow, textCol, 14, bold: "true");
                //            }
                //            else
                //            {
                //                FJ_OK = false;
                //                GetImageWindow().DispText(_currentJuLi, "red", textRow, textCol, 14, bold: "true");
                //                HOperatorSet.GenCircle(out HObject NGCircle, ZJ_Rows[i], ZJ_Cols[i], 3);
                //                GetImageWindow().DispObj(NGCircle, "red", "fill");
                //            }
                //        }
                //        else
                //        {
                //            GetImageWindow().DispText("Over Hang【0.5-99】", "yellow", 350, 10, 22);
                //            if (d1 > 0.5 && d1 < 99 && d2 > 0.5 && d2 < 99)
                //            {
                //                GetImageWindow().DispText(_currentJuLi, "yellow", textRow, textCol, 14, bold: "true");
                //            }
                //            else
                //            {
                //                FJ_OK = false;
                //                GetImageWindow().DispText(_currentJuLi, "red", textRow, textCol, 14, bold: "true");
                //                HOperatorSet.GenCircle(out HObject NGCircle, ZJ_Rows[i], ZJ_Cols[i], 3);
                //                GetImageWindow().DispObj(NGCircle, "red", "fill");
                //                //GetImageWindow().DispText("L" + (i + 1), "red", (int)ZJ_Rows[i], (int)(ZJ_Cols[i] + 10), 12);
                //            }
                //        }
                //    }

                //    string distanceMean = d_Array.Average().ToString("f2");
                //    string distanceMin = d_Array.Min().ToString("f2");
                //    string distanceMax = d_Array.Max().ToString("f2");

                //    StringBuilder S_result = new StringBuilder();
                //    S_result.Append(JuLiNum + ",");
                //    S_result.Append(isX ? "Min-0.75:Max-99" : "Min-0.5:Max-99" + ",");
                //    S_result.Append(distanceMin + ",");
                //    S_result.Append(distanceMax + ",");
                //    S_result.Append(distanceMean);


                //    GetImageWindow().DispText("Mean-Min【" + distanceMean + "-" + distanceMin + "】", "green", 375, 10, 22);


                //    #region 显示正负极点数
                //    string ss = "\r\n正极点数：" + I_zjNum + "\r\n负极点数：" + I_fjNum;

                //    if (I_zjNum != 98 || I_fjNum != 99)
                //    {
                //        ZJ_OK = false;
                //        NGInfo += "点数错误";
                //        GetImageWindow().DispText(ss, "red", "top", "left", 24);

                //    }
                //    else
                //    {
                //        GetImageWindow().DispText(ss, "green", "top", "left", 24);
                //    }
                //    if (!FJ_OK)
                //        NGInfo += "|OverHang";
                //    #endregion


                //    #region 存储csv文件

                //    StringBuilder sb_WriteCSV = new StringBuilder();
                //    sb_WriteCSV.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm") + ",");
                //    sb_WriteCSV.Append(_currentImgName.Split('-')[0].ToString() + "，,");
                //    sb_WriteCSV.Append(_currentImgName.Split('-')[1] + ",");
                //    sb_WriteCSV.Append(_currentImgName.Split('-')[2] + ",");
                //    sb_WriteCSV.Append(ZJ_OK && FJ_OK == true ? "OK" + "," : "NG" + ",");
                //    sb_WriteCSV.Append(NGInfo + ",");
                //    sb_WriteCSV.Append(S_result.ToString() + ",");
                //    sb_WriteCSV.Append(S_resultJuLi.ToString() + ",");
                //    IniFiles.WriteCSV(sb_WriteCSV.ToString());
                //    S_result.Clear();
                //    S_resultJuLi.Clear();
                //    sb_WriteCSV.Clear();

                //    #endregion


                //    #region 显示OK/NG

                //    if (ZJ_OK && FJ_OK)
                //    {
                //        GetImageWindow().DispText("OK", "green", "bottom", "right", 24);
                //    }
                //    else
                //    {
                //        GetImageWindow().DispText("NG:" + NGInfo, "red", "bottom", "right", 24);
                //        toolRunStatu = "运行失败";
                //        goto Exit;
                //    }

                //    #endregion




                //    //GetImageWindow().DispText("OK\r\n", "green", "bottom", "right", 60);
                //    #endregion

                //    #endregion

                //    toolRunStatu = "运行成功";
                //}
                //catch (Exception ex)
                //{
                //    toolRunStatu = "运行异常：" + ex.Message;
                //    FuncLib.ShowMsg("南昌CT工具运行出现异常：" + ex.Message, InfoType.Error);
                //    goto Exit;

                //}
            }
            toolRunStatu = "运行成功";
        Exit:
            sw.Stop();
            if (Frm_NanChangCTTool.hasShown && Frm_NanChangCTTool.taskName == taskName && Frm_NanChangCTTool.toolName == toolName)
            {

            }
        }




        /// <summary>
        /// 根据传进来的区域集合，获取各个区域顶部的坐标值，以及灰度值，返回集合rows,cols,grays
        /// </summary>
        /// <param name="isRegion">true:region false:xld</param>
        /// <param name="Img">区域所在的图像</param>
        /// <param name="LineRegions">线条区域集合</param>
        /// <param name="lstRows">返回的线条区域集合Row</param>
        /// <param name="lstCols">返回的线条区域集合Col</param>
        /// <param name="lstGrays">返回的线条区域集合Gray</param>
        private void GenRegionsGetTopXYGray(bool isRegion, HObject Img, HObject LineRegions, out HTuple lstRows, out HTuple lstCols, out HTuple lstGrays)
        {
            lstRows = new HTuple();
            lstCols = new HTuple();
            lstGrays = new HTuple();
            HTuple Rows, Cols, Grays;
            double r, c;
            int g;
            HOperatorSet.CountObj(LineRegions, out HTuple regionNums);
            if (isRegion)
            {
                HObject currentRegion;
                //region
                for (int i = 1; i <= regionNums.I; i++)
                {
                    HOperatorSet.SelectObj(LineRegions, out currentRegion, i);
                    HOperatorSet.GetRegionPoints(currentRegion, out Rows, out Cols);
                    HOperatorSet.GetGrayval(Img, Rows, Cols, out Grays);
                    HOperatorSet.TupleFind(Rows, Rows.LArr.Min(), out HTuple colIndex);
                    HOperatorSet.TupleSelect(Cols, colIndex, out HTuple ccol);
                    lstRows.Append(Rows.LArr.Min());
                    lstCols.Append(ccol.LArr.Min());
                    lstGrays.Append(Grays.LArr.Average());
                }
            }
            else
            {
                HObject currentXld;
                //xld
                for (int i = 1; i <= regionNums.I; i++)  //z注意索引是1,开始，结束是 ==
                {
                    HOperatorSet.SelectObj(LineRegions, out currentXld, i);
                    HOperatorSet.GetContourXld(currentXld, out Rows, out Cols);
                    HOperatorSet.GetGrayvalContourXld(((ToolPar)参数).输入.原图像, currentXld, "nearest_neighbor", out Grays);
                    HOperatorSet.TupleFind(Rows, Rows.DArr.Min(), out HTuple indices);
                    HOperatorSet.TupleSelect(Cols, indices, out HTuple seleced);
                    lstRows.Append(Rows.DArr.Min());
                    lstCols.Append(seleced.DArr.Min());
                    lstGrays.Append(Grays.LArr.Average());
                }
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
            private HObject _原图像;
            public HObject 原图像
            {
                get
                {
                    return _原图像;
                }
                set
                {
                    _原图像 = value;
                }
            }
            private HObject _分割图;


            public HObject 分割图
            {
                get
                {
                    return _分割图;
                }
                set
                {
                    _分割图 = value;
                }
            }
            //private List<XYU> _跟随 = new List<XYU>();
            //public List<XYU> 跟随
            //{
            //    get { return _跟随; }
            //    set { _跟随 = value; }
            //}

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
            private HObject _图像;
            public HObject 图像
            {
                get
                {
                    return _图像;
                }
                set { _图像 = value; }
            }

            //private int _数量;
            //public int 数量
            //{
            //    get { return _数量; }
            //    set { _数量 = value; }
            //}

            //private List<String> _文本 = new List<string>();
            //public List<String> 文本
            //{
            //    get { return _文本; }
            //    set { _文本 = value; }
            //}
        }

        #endregion


    }


}
