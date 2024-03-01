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
    /// 码类识别
    /// </summary>
    internal class IDTool : ToolBase
    {
        internal IDTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;
            L_OutItemType = new List<DataType> { DataType.Int, DataType.String };

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
        /// 失败是否开启VP模式解码
        /// </summary>
        internal bool isVP = false;
        /// <summary>
        /// 用于记录当前进行图像预处理操作的区域
        /// </summary>
        internal bool isQuanTu = true;
        /// <summary>
        /// 最后一次运行结果
        /// </summary>
        internal HObject lastObj;
        /// <summary>
        /// 阵列条码是否识别完成
        /// </summary>
        private bool[] finished;
        /// <summary>
        /// 阵列区域中心集合
        /// </summary>
        internal List<XY> L_arrayRegionCenter = new List<XY>();
        /// <summary>
        /// 是否启用阵列区域
        /// </summary>
        internal bool enableArraySearchRegion = false;
        /// <summary>
        /// 阵列区域行数
        /// </summary>
        internal int arrayRowNum = 2;
        /// <summary>
        /// 阵列区域列数
        /// </summary>
        internal int arrayColNum = 2;
        /// <summary>
        /// 阵列单元宽度
        /// </summary>
        internal int arraySizeWidth = 100;
        /// <summary>
        /// 阵列单元高度
        /// </summary>
        internal int arraySizeHeight = 100;
        /// <summary>
        /// 阵列区域左上点坐标
        /// </summary>
        internal XY arrayLeftUpPoint = new XY();
        /// <summary>
        /// 阵列区域右下角坐标
        /// </summary>
        internal XY arrayRightDownPoint = new XY();
        /// <summary>
        /// 码的类型
        /// </summary>
        internal CodeType codeType = CodeType.All;
        /// <summary>
        /// 二维码类型
        /// </summary>
        internal string qrCodeType = "Auto";
        /// <summary>
        /// 最小条码文本集合长度
        /// </summary>
        internal int minLength = 1;
        /// <summary>
        /// 最大条码长度
        /// </summary>
        internal int maxLength = 100;
        /// <summary>
        /// 要查找的条码数量
        /// </summary>
        internal int findNum = 1;
        /// <summary>
        /// 阈值
        /// </summary>
        internal int threshold = 30;
        /// <summary>
        /// 超时时间
        /// </summary>
        internal int timeout = 3000;
        /// <summary>
        /// 在图像左下角显示条码
        /// </summary>
        internal bool showTextAtLeftDown = true;
        /// <summary>
        /// 在条码处显示字符串信息
        /// </summary>
        internal bool showTextAtCodeRegion = false;
        /// <summary>
        /// 主页显示搜索区域
        /// </summary>
        internal bool showSearchRegion = true;
        [NonSerialized]
        /// <summary>
        /// 搜索区域
        /// </summary>
        internal HObject SearchRegion = null;
        /// <summary>
        /// 条码排序
        /// </summary>
        internal SortMode sortMode = SortMode.从上至下且从左至右;
        /// <summary>
        /// 间距
        /// </summary>
        internal int spacing = 200;
        /// <summary>
        /// 识别结果
        /// </summary>
        internal List<CodeResult> L_result = new List<CodeResult>();
        /// <summary>
        /// 用于存放查找结果和结果对应的区域
        /// </summary>
        internal Dictionary<string, HObject> D_textAndRegion = new Dictionary<string, HObject>();


        /// <summary>
        /// 复位工具
        /// </summary>
        internal override void ResetTool()
        {
            if (((ToolPar)参数).输入.图像 != null)
                Frm_IDTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);

            codeType = CodeType.All;
            qrCodeType = "Auto";
            minLength = 1;
            maxLength = 100;
            findNum = 1;
            threshold = 30;
            timeout = 3000;

            isQuanTu = true;

            showTextAtLeftDown = true;
            showTextAtCodeRegion = false;
            showSearchRegion = true;

            sortMode = SortMode.从上至下且从右至左;
            spacing = 200;

            SearchRegion = null;
            L_result = new List<CodeResult>();
            D_textAndRegion = new Dictionary<string, HObject>();

            Frm_IDTool.Instance.cbx_codeType.SelectedIndex = (int)codeType;
            Frm_IDTool.Instance.cbx_qrCodeType.SelectedIndex = 0;
            Frm_IDTool.Instance.nud_minLength.Value = minLength;
            Frm_IDTool.Instance.nud_maxLength.Value = maxLength;
            Frm_IDTool.Instance.nud_findNum.Value = findNum;
            Frm_IDTool.Instance.nud_threshold.Value = threshold;
            Frm_IDTool.Instance.nud_timeout.Value = timeout;

            Frm_IDTool.Instance.lbl_codeNum.Text = "0 个";
            Frm_IDTool.Instance.lbl_resultStr.Text = "无";


            Frm_IDTool.Instance.ckb_showTextAtLeftDown.Checked = showTextAtLeftDown;
            Frm_IDTool.Instance.ckb_showTextAtCodeRegion.Checked = showTextAtCodeRegion;
            Frm_IDTool.Instance.ckb_showSearchRegion.Checked = showSearchRegion;

            Frm_IDTool.Instance.cbx_sortMode.SelectedIndex = 0;
            Frm_IDTool.Instance.nud_spacing.Value = spacing;
            Frm_IDTool.Instance.dgv_result.Rows.Clear();

            Frm_IDTool.Instance.lbl_runTime.Text = "0 ms";
            Frm_IDTool.Instance.lbl_toolTip.Text = "暂无提示";
        }
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="qrCodeType"></param>
        /// <param name="index"></param>
        /// <param name="initRun"></param>
        private void Decode(string qrCodeType, int index, bool initRun)
        {
            Thread th = new Thread(() =>
            {
                HTuple handle;
                HObject resultDLDs = new HObject();
                HTuple resultStr = new HTuple();
                HTuple resultHandles = new HTuple();
                HOperatorSet.CreateDataCode2dModel(qrCodeType, "default_parameters", "maximum_recognition", out handle);
                HOperatorSet.SetDataCode2dParam(handle, new string[] { "module_gap_min", "module_gap_max" }, new string[] { "no", "big" });
                HOperatorSet.SetDataCode2dParam(handle, "timeout", timeout);
                HObject rect;
                HObject rectImage;
                HOperatorSet.GenRectangle2(out rect, L_arrayRegionCenter[index].X, L_arrayRegionCenter[index].Y, 0, arraySizeHeight, arraySizeWidth);
                HOperatorSet.ReduceDomain(((ToolPar)参数).输入.图像, rect, out rectImage);
                HOperatorSet.FindDataCode2d(rectImage, out resultDLDs, handle, new HTuple("stop_after_result_num"), new HTuple(1), out resultHandles, out resultStr);
                for (int i = 0; i < resultStr.Length; i++)
                {
                    CodeResult codeResult = new CodeResult();

                    HTuple area, row, column;
                    HObject temp1;
                    HObject temp2;
                    HOperatorSet.GenRegionContourXld(resultDLDs[i + 1], out temp1, "filled");
                    HOperatorSet.AreaCenter(temp1, out area, out row, out column);
                    HOperatorSet.SelectObj(resultDLDs, out temp2, i + 1);

                    codeResult.Text = resultStr[i];
                    codeResult.Region = temp2;
                    codeResult.Row = row;
                    codeResult.Col = column;
                    codeResult.Angle = 0;
                    codeResult.BarcodeType = "QR Code";

                    L_result.Add(codeResult);
                    ((ToolPar)参数).输出.文本集合.Add(resultStr[i]);
                }

                if (resultStr.Length == 0)
                {
                    if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
                        Frm_IDTool.Instance.hWindow_Final1.DispObj(rect, "red");
                    if (!initRun)
                        GetImageWindow().DispObj(rect, "red");
                }

                //显示解码区域
                if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
                    Frm_IDTool.Instance.hWindow_Final1.DispObj(resultDLDs, "green");
                if (!initRun)
                    GetImageWindow().DispObj(resultDLDs, "green");
                HOperatorSet.ClearDataCode2dModel(handle);
                finished[index] = true;
            });
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 生成阵列区域
        /// </summary>
        internal HObject CreateArrayRegion()
        {
            int rowSpan = 0;
            if (arrayRowNum != 1)
                rowSpan = Convert.ToInt16((arrayRightDownPoint.X - arrayLeftUpPoint.X) / (arrayRowNum - 1));

            int colSpan = 0;
            if (arrayColNum != 1)
                colSpan = Convert.ToInt16((arrayRightDownPoint.Y - arrayLeftUpPoint.Y) / (arrayColNum - 1));

            HObject allRegion;
            HOperatorSet.GenEmptyObj(out allRegion);
            L_arrayRegionCenter.Clear();
            for (int i = 0; i < arrayRowNum; i++)
            {
                for (int j = 0; j < arrayColNum; j++)
                {
                    HObject rec;
                    HOperatorSet.GenRectangle2(out rec, arrayLeftUpPoint.X + rowSpan * i, arrayLeftUpPoint.Y + colSpan * j, 0, arraySizeHeight, arraySizeWidth);
                    HOperatorSet.ReduceDomain(((ToolPar)参数).输入.图像, rec, out rec);
                    L_arrayRegionCenter.Add(new XY(arrayLeftUpPoint.X + rowSpan * i, arrayLeftUpPoint.Y + colSpan * j));
                    HOperatorSet.Union2(allRegion, rec, out allRegion);
                }
            }

            return allRegion;
        }
        /// <summary>
        /// 自动识别二维码的类型
        /// </summary>
        internal void AutoSelectQRType()
        {
            Thread th = new Thread(() =>
            {
                for (int i = 1; i < Frm_IDTool.Instance.cbx_qrCodeType.Items.Count; i++)
                {
                    qrCodeType = Frm_IDTool.Instance.cbx_qrCodeType.Items[i].ToString();
                    if (qrCodeType == "PDF417")
                    {
                        //是PDF的话，运行此行会提示参数错误：HOperatorSet.SetDataCode2dParam(handleIDForQRCode, new string[] { "module_gap_min", "module_gap_max" }, new string[] { "no", "big" });
                        continue;   
                    }
                    Run(true);
                    if (((ToolPar)参数).输出.数量 > 0)
                    {
                        Frm_IDTool.Instance.cbx_qrCodeType.Text = qrCodeType;
                        Frm_IDTool.Instance.lbl_runTime.Text = "0 ms";
                        Frm_IDTool.Instance.lbl_toolTip.ForeColor = Color.Black;
                        Frm_IDTool.Instance.lbl_toolTip.Text = "二维码类型识别成功，类型：" + Frm_IDTool.Instance.cbx_qrCodeType.Text;
                        break;
                    }
                    if (i == Frm_IDTool.Instance.cbx_qrCodeType.Items.Count - 1)
                    {
                        Frm_IDTool.Instance.lbl_runTime.Text = "0 ms";
                        Frm_IDTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                        Frm_IDTool.Instance.lbl_toolTip.Text = "未查找到任何二维码，类型识别失败";
                    }
                }
            });
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 运行工具
        /// </summary>
        /// <param name="initRun">初始化运行</param>
        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
        {
            SearchRegion = null;
            L_result.Clear();
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

            HOperatorSet.GenEmptyObj(out lastObj);

            #region 非法输入过滤

            //判断是否有图像输入
            if (((ToolPar)参数).输入.图像 == null)
            {
                toolRunStatu = "未指定输入图像";
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            //如果搜索区域是外部输入，判断区域是否有为空
            if (!isQuanTu && ((ToolPar)参数).输入.区域 == null)
            {
                toolRunStatu = "未指定输入搜索区域";
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            #endregion

            SearchRegion = ((ToolPar)参数).输入.区域;

            //获取截取区域后的图像
            HObject ReduceImg = ((ToolPar)参数).输入.图像;

            if (!enableArraySearchRegion && !isQuanTu)  //链入区域
            {
                HOperatorSet.ReduceDomain(((ToolPar)参数).输入.图像, SearchRegion, out ReduceImg);
                //HOperatorSet.CropDomain(ReduceImg, out ReduceImg);
                //HOperatorSet.WriteImage(ReduceImg, "png", 0, "d:\\ReduceImg");
            }
            else if (enableArraySearchRegion)   //阵列区域
            {
                HObject allArrayRegion = CreateArrayRegion();
                HOperatorSet.ReduceDomain(((ToolPar)参数).输入.图像, allArrayRegion, out ReduceImg);
            }

            #region //显示搜索区域 已注销

            //if (showSearchRegion)
            //{
            //    if (!enableArraySearchRegion)
            //    {
            //        if (searchRegionType != RegionType.整幅图像)
            //        {
            //            if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
            //            {
            //                if (searchRegionType == RegionType.输入区域)
            //                    Frm_IDTool.Instance.hWindow_Final1.DispObj(searchRegionAfterTransed, "blue");
            //            }
            //            if (!initRun)
            //            {
            //                DispObj(searchRegionAfterTransed, "blue");
            //                HOperatorSet.Union2(lastObj, searchRegionAfterTransed, out lastObj);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
            //            Frm_IDTool.Instance.hWindow_Final1.DispObj(allArrayRegion, "blue");
            //        if (!initRun)
            //            GetImageWindow().DispObj(allArrayRegion, "blue");

            //        //高和宽过大防呆检测
            //        int rowSpan = 0;
            //        if (arrayRowNum != 1)
            //            rowSpan = Convert.ToInt16((arrayRightDownPoint.X - arrayLeftUpPoint.X) / (arrayRowNum - 1));
            //        if (arraySizeWidth > rowSpan / 2)
            //        {
            //            toolRunStatu = "单元区域高度过大";
            //            FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
            //            goto Exit;
            //        }

            //        int colSpan = 0;
            //        if (arrayColNum != 1)
            //            colSpan = Convert.ToInt16((arrayRightDownPoint.Y - arrayLeftUpPoint.Y) / (arrayColNum - 1));
            //        if (arraySizeHeight > colSpan / 2)
            //        {
            //            toolRunStatu = "单元区域宽度过大";
            //            FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
            //            goto Exit;
            //        }
            //    }
            //}
            #endregion

            //识别二维码
            ((ToolPar)参数).输出.文本集合.Clear();
            HTuple resultStr = new HTuple();
            HObject resultRegion = new HObject();
            HTuple resultType = new HTuple();
            HTuple resultAngle = new HTuple();
            HObject resultDLDs = new HObject();
            HTuple resultHandles = new HTuple();
            HTuple handleIDForQRCode = new HTuple();
            if (codeType == CodeType.All || codeType == CodeType.QRCode)    //此处判断有点歧义，其是想表述选择二维码的话
            {
                if (qrCodeType == "Auto")       //自动识别所有类型的二维码
                {
                    string[] QRCodeTypeList = new string[] { "Data Matrix ECC 200", "QR Code", "Micro QR Code", "Aztec Code", "GS1 DataMatrix", "GS1 QR Code", "GS1 Aztec Code" };
                    for (int i = 0; i < QRCodeTypeList.Length; i++)
                    {
                        if (!enableArraySearchRegion)
                        {
                            HOperatorSet.CreateDataCode2dModel(QRCodeTypeList[i], "default_parameters", "maximum_recognition", out handleIDForQRCode);
                            HOperatorSet.SetDataCode2dParam(handleIDForQRCode, new string[] { "module_gap_min", "module_gap_max" }, new string[] { "no", "big" });
                            HOperatorSet.SetDataCode2dParam(handleIDForQRCode, "timeout", timeout);
                            HOperatorSet.FindDataCode2d(ReduceImg, out resultDLDs, handleIDForQRCode, new HTuple("stop_after_result_num"), new HTuple(findNum), out resultHandles, out resultStr);
                            HOperatorSet.ClearDataCode2dModel(handleIDForQRCode);
                            for (int j = 0; j < resultStr.Length; j++)
                            {
                                CodeResult codeResult = new CodeResult();

                                HTuple area, row, column;
                                HObject temp1;
                                HObject temp2;
                                HOperatorSet.GenRegionContourXld(resultDLDs[j + 1], out temp1, "filled");
                                HOperatorSet.AreaCenter(temp1, out area, out row, out column);
                                HOperatorSet.SelectObj(resultDLDs, out temp2, j + 1);

                                //显示中心十字架
                                HTuple row1, col1, phi1, length1, length2;
                                HObject temp3;
                                HOperatorSet.GenRegionContourXld(temp2, out temp3, "filled");
                                HOperatorSet.SmallestRectangle2(temp3, out row1, out col1, out phi1, out length1, out length2);
                                HObject cross;
                                HOperatorSet.GenCrossContourXld(out cross, row, column, 20, phi1);
                                if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
                                    Frm_IDTool.Instance.hWindow_Final1.DispObj(cross, "green");
                                GetImageWindow().DispObj(cross, "green");

                                codeResult.Text = resultStr[j];
                                codeResult.Region = temp2;
                                codeResult.Row = row;
                                codeResult.Col = column;
                                codeResult.Angle = 0;
                                codeResult.BarcodeType = QRCodeTypeList[i];

                                L_result.Add(codeResult);
                                ((ToolPar)参数).输出.文本集合.Add(resultStr[j]);
                            }

                            if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
                                Frm_IDTool.Instance.hWindow_Final1.DispObj(resultDLDs, "green");
                            if (!initRun)
                                DispObj(resultDLDs, "green");

                            if (L_result.Count >= findNum)
                                break;
                        }
                        else
                        {
                            //异步识别
                            finished = new bool[L_arrayRegionCenter.Count];
                            for (int k = 0; k < L_arrayRegionCenter.Count; k++)
                            {
                                Decode(qrCodeType, k, initRun);
                            }
                            while (true)
                            {
                                bool allFinished = true;
                                for (int j = 0; j < finished.Length; j++)
                                {
                                    allFinished = allFinished & finished[j];
                                }
                                if (allFinished)
                                    break;
                            }
                        }
                    }
                }
                else        //单独识别指定类型的二维码
                {
                    HOperatorSet.CreateDataCode2dModel(qrCodeType, "default_parameters", "maximum_recognition", out handleIDForQRCode);
                    //By：风云 PDF类型时，此行会爆8831参数无效的错误，版本20.11，外部已做管控
                    HOperatorSet.SetDataCode2dParam(handleIDForQRCode, new string[] { "module_gap_min", "module_gap_max" }, new string[] { "no", "big" });
                    HOperatorSet.SetDataCode2dParam(handleIDForQRCode, "timeout", timeout);
                    HOperatorSet.FindDataCode2d(ReduceImg, out resultDLDs, handleIDForQRCode, new HTuple("stop_after_result_num"), new HTuple(findNum), out resultHandles, out resultStr);
                    HOperatorSet.ClearDataCode2dModel(handleIDForQRCode);

                    for (int i = 0; i < resultStr.Length; i++)
                    {
                        CodeResult codeResult = new CodeResult();
                        HTuple area, row, column;
                        HObject temp1;
                        HObject temp2;
                        HOperatorSet.GenRegionContourXld(resultDLDs[i + 1], out temp1, "filled");
                        HOperatorSet.AreaCenter(temp1, out area, out row, out column);
                        HOperatorSet.SelectObj(resultDLDs, out temp2, i + 1);

                        //显示中心十字架
                        HTuple row1, col1, phi1, length1, length2;
                        HObject temp3;
                        HOperatorSet.GenRegionContourXld(temp2, out temp3, "filled");
                        HOperatorSet.SmallestRectangle2(temp3, out row1, out col1, out phi1, out length1, out length2);
                        HObject cross;
                        HOperatorSet.GenCrossContourXld(out cross, row, column, 20, phi1);
                        //if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
                        //    Frm_IDTool.Instance.hWindow_Final1.DispObj(cross, "green");
                        //DispObj(cross, "green");
                        //if (enableArraySearchRegion)    //阵列区域选择
                        {
                            HOperatorSet.GenRegionContourXld(cross, out cross, "filled");
                            HOperatorSet.Union2(lastObj, cross, out lastObj);
                        }
                        codeResult.Text = resultStr[i];
                        codeResult.Region = temp2;
                        codeResult.Row = row;
                        codeResult.Col = column;
                        codeResult.Angle = 0;
                        codeResult.BarcodeType = qrCodeType;

                        L_result.Add(codeResult);
                        ((ToolPar)参数).输出.文本集合.Add(resultStr[i]);
                    }
                }
            }

            //识别一维码
            HTuple handleIDForBarcode = new HTuple();
            if ((codeType == CodeType.All || codeType == CodeType.BarCode) && L_result.Count < findNum)
            {
                HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out handleIDForBarcode);
                HOperatorSet.SetBarCodeParam(handleIDForBarcode, "timeout", timeout);
                HOperatorSet.SetBarCodeParam(handleIDForBarcode, "meas_thresh", 0.2);
                HOperatorSet.SetBarCodeParam(handleIDForBarcode, "element_size_min", 1);
                HOperatorSet.FindBarCode(ReduceImg, out resultRegion, handleIDForBarcode, new HTuple("auto"), out resultStr);
                HOperatorSet.GetBarCodeResult(handleIDForBarcode, "all", "decoded_types", out resultType);
                HOperatorSet.GetBarCodeResult(handleIDForBarcode, "all", "orientation", out resultAngle);
                HOperatorSet.ClearBarCodeModel(handleIDForBarcode);
                for (int i = 0; i < resultStr.Length; i++)
                {
                    CodeResult codeResult = new CodeResult();
                    codeResult.Text = resultStr[i];
                    HOperatorSet.SelectObj(resultRegion, out codeResult.Region, i + 1);
                    HTuple area, row, column;
                    HOperatorSet.AreaCenter(codeResult.Region, out area, out row, out column);
                    codeResult.Row = row;
                    codeResult.Col = column;
                    codeResult.BarcodeType = resultType;
                    HTuple tempAngle;
                    HOperatorSet.TupleSelect(resultAngle, i, out tempAngle);
                    codeResult.Angle = tempAngle;

                    //显示中心十字架
                    HObject cross;
                    HOperatorSet.GenCrossContourXld(out cross, row, column, 20, tempAngle);
                    if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
                        Frm_IDTool.Instance.hWindow_Final1.DispObj(cross, "green");
                    GetImageWindow().DispObj(cross, "green");

                    L_result.Add(codeResult);
                    ((ToolPar)参数).输出.文本集合.Add(resultStr[i]);
                }
                if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
                    Frm_IDTool.Instance.hWindow_Final1.DispObj(resultRegion, "green");
                if (!initRun)
                    GetImageWindow().DispObj(resultRegion, "green");
            }

            //findNum != resultStr.Length && 
            //if (isVP)   //说明解码失败，并选择了采用VP解码
            //{
            //    CogIDTool cogIdTool = new CogIDTool();
            //    cogIdTool.RunParams.NumToFind = 5;
            //    cogIdTool.RunParams.DisableAll1DCodes();
            //    //VP解析二维码只允许一次识别同一种二维码，故先下此操作，实际并不严谨，可能是PDF417
            //    if (qrCodeType == "Data Matrix ECC 200")    
            //    {
            //        cogIdTool.RunParams.DataMatrix.Enabled = true;
            //        cogIdTool.RunParams.QRCode.Enabled = false;
            //    }
            //    else
            //    {
            //        cogIdTool.RunParams.DataMatrix.Enabled = false;
            //        cogIdTool.RunParams.QRCode.Enabled = true;
            //    }
                
            //    cogIdTool.InputImage = HObjectToCogImage8Grey2(ReduceImg);

            //    cogIdTool.Run();
            //    if (cogIdTool.Results.Count >0)
            //    {
            //        L_result.Clear();
            //        for (int i = 0; i < cogIdTool.Results.Count; i++)
            //        {
            //            CodeResult codeResult = new CodeResult();
            //            codeResult.Text = cogIdTool.Results[0].DecodedData.DecodedString;
            //            codeResult.Region = null;
            //            codeResult.Row = cogIdTool.Results[0].CenterY;
            //            codeResult.Col = cogIdTool.Results[0].CenterX;
            //            codeResult.Angle = 0;
            //            codeResult.BarcodeType = qrCodeType;
            //        }
            //        //FuncLib.ShowMessageBox("识别成功");
            //    }
            //    else
            //    {
            //        FuncLib.ShowMessageBox("VP识别失败");
            //    }
            //}




            //临时添加，用VP识别不能识别的码
            int count = 0;
            if (showSearchRegion)
            {
                //for (int i = 0; i < L_arrayRegionCenter.Count; i++)
                //{
                //    bool exist = false;

                //    HObject rect;
                //    HOperatorSet.GenRectangle2(out rect, L_arrayRegionCenter[i].X, L_arrayRegionCenter[i].Y, 0, arraySizeHeight, arraySizeWidth);
                //    for (int j = 0; j < L_result.Count; j++)
                //    {
                //        HTuple index;
                //        HOperatorSet.GetRegionIndex(rect, (int)L_result[j].Row, (int)L_result[j].Col, out index);
                //        if (index.Length != 0)
                //        {
                //            exist = true;
                //            break;
                //        }
                //    }

                //    if (!exist)     //如未被识别，则使用VP重新识别一次
                //    {
                //        if (cogIdTool == null)
                //        {
                //            cogIdTool = new CogIDTool();
                //            cogIdTool.RunParams.NumToFind = 5;
                //            cogIdTool.RunParams.DisableAll1DCodes();
                //            cogIdTool.RunParams.DataMatrix.Enabled = true;
                //            cogIdTool.RunParams.QRCode.Enabled = false;
                //            //cogIdTool.InputImage = HObjectToCogImage8Grey2(((ToolPar)参数).输入.图像);
                //            //for (int j = 0; j < L_arrayRegionCenter.Count; j++)
                //            //{
                //            //    CogRectangleAffine rec = new CogRectangleAffine();
                //            //    //矩形框的中心坐标
                //            //    double centerX = L_arrayRegionCenter[j].Y;
                //            //    double centerY = L_arrayRegionCenter[j].X;
                //            //    rec.SetCenterLengthsRotationSkew(centerX, centerY, arraySizeHeight * 2, arraySizeWidth * 2, 0, 0);
                //            //    cogIdTool.Region = rec;
                //            //    cogIdTool.Run();
                //            //    ICogRunStatus status = cogIdTool.RunStatus;
                //            //    if (status.Result == CogToolResultConstants.Accept && cogIdTool.Results.Count != 0)
                //            //    {
                //            //        cogIdTool.RunParams.Untrain();
                //            //        cogIdTool.RunParams.Train(HObjectToCogImage8Grey2(((ToolPar)参数).输入.图像), null);
                //            //        break;
                //            //    }
                //            //}
                //        }



                //        cogIdTool.InputImage = HObjectToCogImage8Grey2(((ToolPar)参数).输入.图像);
                //        CogRectangleAffine rec11 = new CogRectangleAffine();
                //        //矩形框的中心坐标
                //        double centerX1 = L_arrayRegionCenter[i].Y;
                //        double centerY1 = L_arrayRegionCenter[i].X;
                //        rec11.SetCenterLengthsRotationSkew(centerX1, centerY1, arraySizeHeight * 2, arraySizeWidth * 2, 0, 0);
                //        cogIdTool.Region = rec11;
                //        cogIdTool.Run();
                //        ICogRunStatus status1 = cogIdTool.RunStatus;
                //        if (status1.Result == CogToolResultConstants.Accept && cogIdTool.Results.Count != 0)
                //        {
                //            CodeResult codeResult = new CodeResult();

                //            //显示中心十字架
                //            HObject cross;
                //            HOperatorSet.GenCrossContourXld(out cross, cogIdTool.Results[0].CenterY, cogIdTool.Results[0].CenterX, 20, 0);
                //            if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
                //                Frm_IDTool.Instance.hWindow_Final1.DispObj(cross, "green");
                //            GetImageWindow().DispObj(cross, "green");

                //            codeResult.Text = cogIdTool.Results[0].DecodedData.DecodedString;
                //            codeResult.Region = null;
                //            codeResult.Row = cogIdTool.Results[0].CenterY;
                //            codeResult.Col = cogIdTool.Results[0].CenterX;
                //            codeResult.Angle = 0;
                //            codeResult.BarcodeType = "QR Code";

                //            //////    if (i <= L_result.Count)
                //            //////    {
                //            //////        L_result.Insert(i, codeResult);
                //            //////        ((ToolPar)参数).输出.文本集合.Insert(i, cogIdTool.Results[0].DecodedData.DecodedString);
                //            //////    }
                //            //////    else
                //            //////    {
                //            //////        L_result.Add(codeResult);
                //            //////        ((ToolPar)参数).输出.文本集合.Add(cogIdTool.Results[0].DecodedData.DecodedString);
                //            //////    }

                //            //////    //显示解码区域
                //            //////    HObject rect1;
                //            //////    HOperatorSet.GenRectangle2(out rect1, codeResult.Row, codeResult.Col, 0, 25, 25);
                //            //////    if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
                //            //////        Frm_IDTool.Instance.hWindow_Final1.DispObj(rect1, "green");
                //            //////    if (!initRun)
                //            //////        GetImageWindow().DispObj(rect1, "green");
                //            //////}
                //            //////else
                //            //////{
                //            //////    if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
                //            //////        Frm_IDTool.Instance.hWindow_Final1.DispObj(rect, "red");
                //            //////    if (!initRun)
                //            //////        GetImageWindow().DispObj(rect, "red");

                //            //////    //显示行列
                //            //////    count++;
                //            //////    int row, col;
                //            //////    row = (i + 1) / arrayColNum;
                //            //////    col = (i + 1) % arrayColNum;
                //            //////    if (col == 0)
                //            //////    {
                //            //////        row--;
                //            //////        col = arrayColNum;
                //            //////    }
                //            //////    FuncLib.ShowMsg(string.Format("产品 {0} 二维码无法识别，位置： {1} 行 {2} 列", count, row + 1, col), InfoType.Error);
                //            //////}
                //        }
                //    }
                //}
            }
            //排序
            List<CodeResult> L_temp = new List<CodeResult>();
            L_temp.AddRange(L_result.ToArray());

            if (enableArraySearchRegion && L_temp.Count == findNum)
            {
                L_result.Clear();
                for (int i = 0; i < L_arrayRegionCenter.Count; i++)
                {
                    HObject rect;
                    HOperatorSet.GenRectangle2(out rect, L_arrayRegionCenter[i].X, L_arrayRegionCenter[i].Y, 0, arraySizeHeight, arraySizeWidth);

                    for (int j = 0; j < L_temp.Count; j++)
                    {
                        HTuple index;
                        HOperatorSet.GetRegionIndex(rect, (int)L_temp[j].Row, (int)L_temp[j].Col, out index);
                        if (index.Length != 0)
                        {
                            L_result.Add(L_temp[j]);
                            break;
                        }
                    }
                }
            }




            ((ToolPar)参数).输出.文本集合.Clear();
            for (int i = 0; i < L_result.Count; i++)
            {
                ((ToolPar)参数).输出.文本集合.Add(L_result[i].Text);
            }

            ((ToolPar)参数).输出.数量 = L_result.Count;
            if (((ToolPar)参数).输出.数量 == 0)
            {
                toolRunStatu = "未识别到条码";
                if (alarm == 1)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            if (L_result[0].Text.Length < minLength || L_result[0].Text.Length > maxLength)
            {
                toolRunStatu = string.Format("识别到的条码长度与设定长度不符，识别长度：{0} 设定长度：{1}~{2}", L_result[0].Text.Length, minLength, maxLength);
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            //验证条码规则
            bool codeRuleNG = false;
            if (codeRule != string.Empty)
            {
                for (int i = 0; i < L_result.Count; i++)
                {
                    for (int j = 0; j < codeRule.Length; j++)
                    {
                        if (codeRule[j] != '*')
                        {
                            if (L_result[i].Text.ToCharArray()[j] != codeRule[j])
                            {
                                codeRuleNG = true;
                                HObject circle;
                                HOperatorSet.GenCircle(out circle, L_result[i].Row, L_result[i].Col, 200);
                                GetImageWindow().DispObj(circle, "red");

                                FuncLib.ShowMsg(string.Format("条码 {0} 规则验证不通过，条码为：{1}  规则为：{2}", i + 1, L_result[i].Text, codeRule), InfoType.Error);
                            }
                        }
                    }
                }
            }
            if (codeRuleNG)
            {
                toolRunStatu = "条码规则验证不通过";
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                FuncLib.ShowMessageBox("条码规则验证不通过", InfoType.Error);
                goto Exit;
            }

            if (L_result.Count != findNum)
            {
                toolRunStatu = string.Format("识别到的条码数量与设定数量不符，识别数量：{0} 设定数量：{1}", L_result.Count, findNum);
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            toolRunStatu = "运行成功";
        Exit:
            sw.Stop();
            long time = sw.ElapsedMilliseconds;
            if (Frm_IDTool.hasShown && Frm_IDTool.taskName == taskName && Frm_IDTool.toolName == toolName)
            {
                Frm_IDTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());
                Frm_IDTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);    //显示链入图像
                Frm_IDTool.Instance.hWindow_Final1.DispObj(SearchRegion, "blue");   //显示查找区域
                Frm_IDTool.Instance.hWindow_Final1.DispObj(lastObj, "green");   //显示条码中心十字架

                //显示条码结果
                //显示结果
                Frm_IDTool.Instance.dgv_result.Rows.Clear();
                for (int i = 0; i < L_result.Count; i++)
                {
                    Frm_IDTool.Instance.dgv_result.Rows.Add();
                    Frm_IDTool.Instance.dgv_result.Rows[i].Cells[0].Value = i + 1;
                    Frm_IDTool.Instance.dgv_result.Rows[i].Cells[1].Value = L_result[i].Text;
                    Frm_IDTool.Instance.dgv_result.Rows[i].Cells[2].Value = L_result[i].BarcodeType.ToString();
                    Frm_IDTool.Instance.dgv_result.Rows[i].Cells[3].Value = L_result[i].Text.Length;
                    Frm_IDTool.Instance.dgv_result.Rows[i].Cells[4].Value = L_result[i].Row.ToString("0.00");
                    Frm_IDTool.Instance.dgv_result.Rows[i].Cells[5].Value = L_result[i].Col.ToString("0.00");
                    Frm_IDTool.Instance.dgv_result.Rows[i].Cells[6].Value = L_result[i].Angle.ToString("0.00");
                    Frm_IDTool.Instance.hWindow_Final1.DispObj(L_result[i].Region, "green");
                    //在图像左上角显示文本集合
                    if (showTextAtLeftDown)
                    {
                        HTuple row1, col1, row2, col2;
                        HOperatorSet.GetPart(Frm_IDTool.Instance.hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                        double height = row2 - row1;
                        HalconLib.DispText(Frm_IDTool.Instance.hWindow_Final1.HWindowHalconID, (HTuple)L_result[i].Text, 12, height - (height / 14) - (200 * i), 40, "blue", "true");
                    }
                }


                Frm_IDTool.Instance.lbl_codeNum.Text = L_result.Count.ToString() + " 个";
                if (L_result.Count > 0)
                    Frm_IDTool.Instance.lbl_resultStr.Text = L_result[0].Text;
                else
                    Frm_IDTool.Instance.lbl_resultStr.Text = "无";
                if (toolRunStatu == "运行成功")
                    Frm_IDTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                else
                    Frm_IDTool.Instance.lbl_toolTip.ForeColor = Color.Red;

                Frm_IDTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
            }
            if (showSearchRegion)
                DispObj(SearchRegion, "green");
            for (int i = 0; i < L_result.Count; i++)
            {
                if (showTextAtLeftDown)
                {
                    HTuple row1, col1, row2, col2;
                    HOperatorSet.GetWindowExtents(GetImageWindow().HWindowHalconID, out row1, out col1, out row2, out col2);
                    DispText((HTuple)("识别结果：" + L_result[i].Text + "\n" + "识别时间：" + time.ToString() + " ms"), 12, 10, 2, "green", "false", "window");
                }
                if (showTextAtCodeRegion)
                    HalconLib.DispText(GetImageWindow().HWindowHalconID, (HTuple)L_result[i].Text, 16, (HTuple)L_result[i].Row, (HTuple)L_result[i].Col, "blue", "true");
                if (showSearchRegion)
                    DispObj(L_result[i].Region, "green");
            }
        }

        ////////static CogIDTool cogIdTool;
        ///// <summary>
        ///// Halcon图像转为Cognex图像
        ///// </summary>
        ///// <param name="hObject"></param>
        ///// <returns></returns>
        //public static CogImage8Grey HObjectToCogImage8Grey2(HObject hObject)
        //{
        //    try
        //    {
        //        HImage grayImage = new HImage(hObject);
        //        string type;//接收图像类型
        //        int width, height;//接收图像尺寸
        //        IntPtr pointer = grayImage.GetImagePointer1(out type, out width, out height);
        //        System.Drawing.Imaging.ColorPalette palette = null;
        //        System.Drawing.Bitmap bitmap = null;
        //        System.Drawing.Bitmap curBitmap = new System.Drawing.Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
        //        System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
        //        System.Drawing.Imaging.BitmapData imageData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, curBitmap.PixelFormat);
        //        int PixelSize = System.Drawing.Bitmap.GetPixelFormatSize(imageData.PixelFormat) / 8;
        //        //定义用于存储图像数据的Buffer
        //        byte[] buffer = new byte[curBitmap.Width * curBitmap.Height];
        //        //将图像数据复制到Buffer内
        //        System.Runtime.InteropServices.Marshal.Copy(pointer, buffer, 0, buffer.Length);
        //        unsafe
        //        {
        //            //使用不安全代码
        //            fixed (byte* bytePointer = buffer)
        //            {
        //                bitmap = new System.Drawing.Bitmap(curBitmap.Width, curBitmap.Height, curBitmap.Width, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, new IntPtr(bytePointer));
        //                palette = bitmap.Palette;
        //                for (int Index = 0; Index <= byte.MaxValue; Index++)
        //                {
        //                    palette.Entries[Index] = System.Drawing.Color.FromArgb(byte.MaxValue, Index, Index, Index);
        //                }
        //                bitmap.Palette = palette;
        //            }
        //        }

        //        // 定义处理区域
        //        Rectangle rect111 = new Rectangle(0, 0, bitmap.Width, bitmap.Height);


        //        // 获取像素数据

        //        System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(rect111, System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);


        //        // 获取像素数据指针

        //        IntPtr IntPtrPixelData = bmpData.Scan0;

        //        // 定义Buffer

        //        byte[] PixelDataBuffer = new byte[bitmap.Width * bitmap.Height];

        //        // 拷贝Bitmap的像素数据的到Buffer

        //        System.Runtime.InteropServices.Marshal.Copy(IntPtrPixelData, PixelDataBuffer, 0, PixelDataBuffer.Length);

        //        CogImage8Grey cogImage8Grey = new CogImage8Grey((Bitmap)bitmap.Clone());


        //        return cogImage8Grey;


        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }


        //}

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
                get
                {
                    return _图像;
                }
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

            private List<String> _文本集合 = new List<string>();
            public List<String> 文本集合
            {
                get { return _文本集合; }
                set { _文本集合 = value; }
            }

            /// <summary>
            /// 勿删：取文本集合的第一个，此字段供外部工具调用，内部工具还是只管赋值给文本集合
            /// </summary>
            public string 文本
            {
                get {
                    if (_文本集合 !=null && _文本集合.Count>0)
                    {
                        return _文本集合[0];
                    }
                    return ""; 
                }
                //set { 文本 = value; }

            }
        }
        #endregion

    }

    /// <summary>
    /// 码的类型
    /// </summary>
    public enum CodeType
    {
        All,        //一维码和二维码
        BarCode,    //仅一维码
        QRCode,     //仅二维吗
    }
    /// <summary>
    /// 条码排序方式
    /// </summary>
    public enum SortMode
    {
        面积,
        从上至下且从左至右,
        从上至下且从右至左,
        从左至右且从下至上,
        从左至右且从上至下,
    }
    /// <summary>
    /// 结果类型
    /// </summary>
    [Serializable]
    internal struct CodeResult
    {
        internal string Text;               //解码字符串
        internal string BarcodeType;        //码类型
        internal HObject Region;            //码区域
        internal double Row;                //行坐标
        internal double Col;                //列坐标
        internal double Angle;              //角度
    }

    

}
