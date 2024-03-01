using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VM_Pro
{
    [Serializable]
    internal class OCRTool : ToolBase
    {
        /// <summary>
        /// 搜索区域类型
        /// </summary>
        internal RegionType searchRegionType = RegionType.整幅图像;

        /// <summary>
        /// 搜索区域类型
        /// </summary>
        internal CharBackType BackType = CharBackType.白底黑字;
        /// <summary>
        /// 在图像左下角显示条码
        /// </summary>
        internal bool showTextAtLeftDown = true;
        /// <summary>
        /// 是否正在绘制模板
        /// </summary>
        internal static bool isDrawing = false;
        /// <summary>
        /// 模板是否已创建
        /// </summary>
        internal bool templateCreated = false;
        /// <summary>
        /// 做模板时的图像
        /// </summary>
        internal HObject templateImage;
        /// <summary>
        /// 显示搜索区域
        /// </summary>
        internal bool showSearchRegion = true;
        /// <summary>
        /// 模板区域
        /// </summary>
        internal HObject templateRegion;
        /// <summary>
        /// 模板角度
        /// </summary>
        internal double templateAngle = 0;
        /// <summary>
        /// 矩形的起点
        /// </summary>
        internal XY templateShangJiaoDian = new XY();
        /// <summary>
        ///  长与宽的长度
        /// </summary>
        internal XY templateLeng = new XY();

        /// <summary>
        /// 当前字符区域是否跟随模板匹配区域
        /// </summary>
        internal bool IsGenSuiQuYu = false;

        /// <summary>
        /// 最小灰度值
        /// </summary>
        internal int GrayMin = 0;
        /// <summary>
        /// 最大灰度值
        /// </summary>
        internal int GrayMax = 0;
        /// <summary>
        /// 最小面积
        /// </summary>
        internal int AreaMin = 0;
        /// <summary>
        /// 最大面积
        /// </summary>
        internal int AreaMax = 0;


        /// <summary>
        /// 模板区域类型
        /// </summary>
        internal RegionType templateRegonType = RegionType.圆;
        /// <summary>
        /// 感兴趣区域
        /// </summary>
        internal HObject imageReduced;
        /// <summary>
        /// 字符模板句柄
        /// </summary>
        internal HTuple modelID = -1;
        /// <summary>
        /// 字符名称
        /// </summary>
        internal HTuple modelName = "";
        /// <summary>
        /// OCR字符库所在路径文件夹
        /// </summary>
        internal string OCRFilePath = "";
        /// <summary>
        /// 所有的OCR字符训练库
        /// </summary>
        internal string[] AllOCRName = null;
        /// <summary>
        /// 当前使用的OCR字符库字符串
        /// </summary>
        internal string CurOCRName = "";
        internal double ro1 = 0, ro2 = 0, co1 = 0, co2 = 0;

        /// <summary>
        /// CCD的检测时间
        /// </summary>
        internal string CCDTestTime = "";

        /// <summary>
        /// CCD的检测结果
        /// </summary>
        internal string CharResult = "";

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
                    Frm_OCRTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
                else
                    Frm_OCRTool.Instance.hWindow_Final1.HobjectToHimage(templateImage);

                Frm_OCRTool.Instance.hWindow_Final1.DispObj(templateRegion, "green");
                Frm_OCRTool.Instance.hWindow_Final1.Focus();
                HOperatorSet.SetDraw(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, "margin");

                HTuple row1, col1, row2, col2;
                HOperatorSet.GetPart(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                HalconLib.DispText(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, "请在图像窗口中绘制模板区域，绘制结束后右击图像窗口", 13, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "blue", "false");

                if (Frm_OCRTool.Instance.rdo_addRegion.Checked)
                    HOperatorSet.SetColor(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, "green");
                else
                    HOperatorSet.SetColor(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, "coral");
                Frm_OCRTool.Instance.hWindow_Final1.ContextMenuStrip = null;
                Frm_OCRTool.Instance.hWindow_Final1.DrawModel = true;
                //Frm_OCRTool.Instance.btn_studyTemplate.Enabled = false;
                //Frm_OCRTool.Instance.btn_runTool.Enabled = false;

                HObject region = null;
                HTuple row, col, row3, col3;
                switch (regionType)
                {
                    case RegionType.矩形:
                        HOperatorSet.DrawRectangle1(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out row3, out col3);
                        if (row.D == 0 && col.D == 0)
                            return;
                        HOperatorSet.GenRectangle1(out region, row, col, row3, col3);


                        //ro1 = row.D; ro2 = row3.D; co1 = col.D; co2 = col3.D;

                        //判断当前是否选择了模板跟随模式，如果是的话，则需要计算当前区域与模板区域重心的偏移量
                        if (IsGenSuiQuYu)
                        {
                            if (((MatchTool.ToolPar)((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).参数).输出.位置.Count > 0)
                            {
                                //double x = ((MatchTool.ToolPar)((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).参数).输出.位置[0].XY.X;
                                //double y = ((MatchTool.ToolPar)((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).参数).输出.位置[0].XY.Y;
                                //double u = ((MatchTool.ToolPar)((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).参数).输出.位置[0].U;

                                HTuple Mianji, ZhongXinX, ZhongXinY;
                                //获取模板特征点的重心坐标
                                HOperatorSet.AreaCenter(((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).lastRunTemplate, out Mianji, out ZhongXinX, out ZhongXinY);

                                templateShangJiaoDian.X = row - ZhongXinX;
                                templateShangJiaoDian.Y = col - ZhongXinY;
                                templateLeng.X = row3 - ZhongXinX;
                                templateLeng.Y = col3 - ZhongXinY;
                            }
                            else
                            {
                                if (Frm_OCRTool.hasShown)
                                {
                                    Frm_OCRTool.Instance.lbl_toolTip.Text = "未找到当前模板区域，请确认当前流程是否存在模板匹配..";
                                    Frm_OCRTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                                }
                            }

                        }

                        break;

                    case RegionType.仿射矩形:
                        HTuple angle, length1, length2;
                        HOperatorSet.DrawRectangle2(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out angle, out length1, out length2);
                        if (row.D == 0 && col.D == 0)
                            return;
                        HOperatorSet.GenRectangle2(out region, row, col, angle, length1, length2);


                        if (IsGenSuiQuYu)
                        {
                            if (((MatchTool.ToolPar)((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).参数).输出.位置.Count > 0)
                            {
                                double x = ((MatchTool.ToolPar)((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).参数).输出.位置[0].XY.X;
                                double y = ((MatchTool.ToolPar)((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).参数).输出.位置[0].XY.Y;
                                double u = ((MatchTool.ToolPar)((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).参数).输出.位置[0].U;

                                HTuple Mianji, ZhongXinX, ZhongXinY;
                                //获取模板特征点的重心坐标
                                HOperatorSet.AreaCenter(((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).lastRunTemplate, out Mianji, out ZhongXinX, out ZhongXinY);


                                templateAngle = u - angle;
                                templateShangJiaoDian.X = ZhongXinX - row;
                                templateShangJiaoDian.Y = ZhongXinY - col;
                                templateLeng.X = length1;
                                templateLeng.Y = length2;
                            }
                            else
                            {
                                templateAngle = angle;
                                templateShangJiaoDian.X = row;
                                templateShangJiaoDian.Y = col;
                                templateLeng.X = length1;
                                templateLeng.Y = length2;
                                if (Frm_OCRTool.hasShown)
                                {
                                    Frm_OCRTool.Instance.lbl_toolTip.Text = "未找到当前模板区域，请确认当前流程是否存在模板匹配..";
                                    Frm_OCRTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                                }
                            }
                        }

                        break;

                    case RegionType.圆:
                        HTuple radius;
                        HOperatorSet.DrawCircle(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out radius);
                        if (row.D == 0 && col.D == 0)
                            return;
                        HOperatorSet.GenCircle(out region, row, col, radius);
                        break;

                    case RegionType.椭圆:
                        HOperatorSet.DrawEllipse(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out angle, out length1, out length2);
                        if (row.D == 0 && col.D == 0)
                            return;
                        HOperatorSet.GenEllipse(out region, row, col, angle, length1, length2);
                        break;

                    case RegionType.任意:
                        HOperatorSet.DrawRegion(out region, Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID);
                        HTuple R, C, A;
                        HOperatorSet.AreaCenter(region, out R, out C, out A);
                        if (A.D == 0)
                            return;
                        break;
                }
                //Frm_OCRTool.Instance.btn_runTool.Enabled = true;
                //Frm_OCRTool.Instance.btn_studyTemplate.Enabled = true;
                Frm_OCRTool.Instance.hWindow_Final1.DrawModel = false;
                //  Frm_OCRTool.Instance.hWindow_Final1.ContextMenuStrip = Frm_OCRTool.Instance.uiContextMenuStrip1;
                Frm_OCRTool.Instance.hWindow_Final1.DispObj(region, Frm_OCRTool.Instance.rdo_addRegion.Checked ? "green" : "red");

                if (templateRegion == null)
                    templateRegion = region;
                else if (Frm_OCRTool.Instance.rdo_addRegion.Checked)    //增加区域
                    HOperatorSet.Union2(templateRegion, region, out templateRegion);
                else if (Frm_OCRTool.Instance.rdo_subRegion.Checked)    //减少区域
                    HOperatorSet.Difference(templateRegion, region, out templateRegion);
                else if (Frm_OCRTool.Instance.rdo_ClearRegion.Checked)  //重绘区域
                    templateRegion = region;





                if (!templateCreated)
                    Frm_OCRTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
                else
                    Frm_OCRTool.Instance.hWindow_Final1.HobjectToHimage(templateImage);

                templateRegonType = regionType;
                if (Frm_OCRTool.hasShown)
                {
                    Frm_OCRTool.Instance.cbx_searchRegionType.Text = regionType.ToString();
                    Frm_OCRTool.Instance.lbl_toolTip.Text = "运行成功";
                    Frm_OCRTool.Instance.lbl_toolTip.ForeColor = Color.Green;
                }
                HOperatorSet.SetLineStyle(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple());
                Frm_OCRTool.Instance.hWindow_Final1.DispObj(templateRegion, "green");
                //HalconLib.DispText(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, "若绘制已完成，请点击训练按钮进行训练模板", 13, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "blue", "false");
                isDrawing = false;

            });
            th.IsBackground = true;
            th.Start();
        }


        /// <summary>
        /// 类构造器，辅助frm_OCR界面逻辑运算
        /// </summary>
        /// <param name="toolName">工具名称</param>
        /// <param name="taskName">所属任务</param>
        /// <param name="toolType">工具类型</param>
        internal OCRTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

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
        /// 将字符串转化为HTuple类型的数组
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns></returns>
        internal HTuple StringToHTupleList(string str)
        {
            try
            {
                HTuple hv_Len;
                HOperatorSet.TupleStrlen(str, out hv_Len);
                HTuple hv_chararray = new HTuple();
                HTuple end_val6 = hv_Len - 1;
                HTuple step_val6 = 1;
                for (int hv_i = 0; hv_i < str.Length; hv_i++)
                {

                    HTuple hv_Selected;
                    HOperatorSet.TupleStrBitSelect(str, hv_i, out hv_Selected);

                    HTuple
                      ExpTmpLocalVar_chararray = hv_chararray.TupleConcat(
                        hv_Selected);

                    hv_chararray = ExpTmpLocalVar_chararray;
                }
                return hv_chararray;
            }
            catch (Exception ex)
            {
                //  Log.SaveError(ex);
                return new HTuple();
            }
        }


        /// <summary>
        /// 切换搜索区域
        /// </summary>
        internal void SwitchSearchRegionType(RegionType regionType)
        {
            //if (((ToolPar)参数).输入.图像 != null)
            //    Frm_IDTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);

            //HOperatorSet.SetLineStyle(Frm_IDTool.Instance.hWindow_Final1.HWindowHalconID, new HTuple());
            //Frm_IDTool.Instance.hWindow_Final1.Select();

            //HTuple width, height;
            //HOperatorSet.GetImageSize(((ToolPar)参数).输入.图像, out width, out height);
            //this.L_regions.Clear();
            //switch (regionType)
            //{
            //    case RegionType.整幅图像:
            //        break;
            //    case RegionType.矩形:
            //        Frm_IDTool.Instance.hWindow_Final1.viewWindow.genRect1(height * 0.375, width * 0.375, height * 0.625, width * 0.625, ref this.L_regions);
            //        Frm_IDTool.L_regions = this.L_regions;
            //        break;
            //    case RegionType.仿射矩形:
            //        Frm_IDTool.Instance.hWindow_Final1.viewWindow.genRect2(height / 2, width / 2, 0, width * 0.125, height * 0.125, ref this.L_regions);
            //        Frm_IDTool.L_regions = this.L_regions;
            //        break;
            //    case RegionType.圆:
            //        Frm_IDTool.Instance.hWindow_Final1.viewWindow.genCircle(height / 2, width / 2, height / 8, ref this.L_regions);
            //        Frm_IDTool.L_regions = this.L_regions;
            //        break;
            //    default:
            //        Frm_IDTool.Instance.hWindow_Final1.DispObj(((ToolPar)参数).输入.区域);
            //        break;
            //}
            searchRegionType = regionType;
        }


        /// <summary>
        /// 运行工具
        /// </summary>
        /// <param name="updateImage">是否刷新图像</param>
        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
        {
            HObject OCRregion;
            HObject OCRImage, OCRZiTiUnion, OCRZiTiConnect;
            HOperatorSet.GenEmptyObj(out OCRregion);
            HOperatorSet.GenEmptyObj(out OCRZiTiConnect);
            HTuple Mianji, ZhongXinX, ZhongXinY;
            HTuple ZiTiArea, ZiTiRow, ZiTiCol, RegionNumber;
            HObject RectangleRegion; HObject RegionAft;

            toolRunStatu = "未知原因";
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            #region 条件管控

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
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            if (Frm_OCRTool.hasShown && ((ToolPar)参数).输入.图像 != null)
            {
                Frm_OCRTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);
                Application.DoEvents();
            }


            CCDTestTime = DateTime.Now.ToString(); //需要记录当前的时间，后续好存入表格以及生成图片名

            #endregion



            CharResult = "";

            
            //进行字符等操作识别
            try
            {
                RegionAft = RectangleRegion = templateRegion;
                //double dd = ((MatchTool)Task.FindTaskByName(taskName).FindToolByName("找华为标志")).templateAngle;
                //if (dd > 0.5 || dd < -0.5)
                //{
                //    FuncLib.ShowMsg("检测NG,标签方向存在异常");
                //    //DispText("识别结果：" + sss, 24, 300, 300, "green", "true");
                //    DispText("NG：标签贴反", 48, 500, 500, "red", "false");
                //    toolRunStatu = "运行失败，标签贴反";
                //    goto Exit;
                //}

                #region 找到本次字符所在的区域
                
                if (IsGenSuiQuYu)   //当前区域是否为跟随模板区域的模式
                {
                    if (((MatchTool.ToolPar)((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).参数).输出.位置.Count > 0)   //获取当前模板区域的重心坐标 
                    {
                        HTuple MoBanMianji, MoBanZhongXinX, MoBanZhongXinY;     //模板的面积，重心坐标
                        switch (templateRegonType)
                        {
                            case RegionType.矩形:
                                HOperatorSet.AreaCenter(((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).lastRunTemplate, out MoBanMianji, out MoBanZhongXinX, out MoBanZhongXinY);
                                //根据模板重心，画出当前字符区域
                                HOperatorSet.GenRectangle1(out OCRregion, templateShangJiaoDian.X + MoBanZhongXinX, templateShangJiaoDian.Y + MoBanZhongXinY, templateLeng.X + MoBanZhongXinX, templateLeng.Y + MoBanZhongXinY);
                                break;

                            case RegionType.仿射矩形:
                                //获取当前模板对象的角度
                                double U = ((MatchTool.ToolPar)((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).参数).输出.位置[0].U;
                                //获取模板特征点的重心坐标
                                HOperatorSet.AreaCenter(((MatchTool)Task.FindTaskByName(taskName).FindToolByName("模板匹配")).lastRunTemplate, out MoBanMianji, out MoBanZhongXinX, out MoBanZhongXinY);
                                //-------------根据模板匹配特征点，画出本次字符模板区域
                                HOperatorSet.GenRectangle2(out OCRregion, MoBanZhongXinX - templateShangJiaoDian.X, MoBanZhongXinY - templateShangJiaoDian.Y, U - templateAngle, templateLeng.X, templateLeng.Y);
                                break;

                            case RegionType.圆:

                                break;

                            case RegionType.椭圆:

                                break;

                            case RegionType.任意:

                                break;
                        }

                    }
                }
                else    //当前的的区域是根据在工具当中划的图形
                {
                    OCRregion = templateRegion;
                }

                #endregion

                //把每个字符区域扣选出来
                HOperatorSet.ReduceDomain(((ToolPar)参数).输入.图像, OCRregion, out OCRImage);    //抠图
                HOperatorSet.Threshold(OCRImage, out OCRZiTiUnion, GrayMin, GrayMax);     //二值化找黑区域
                HOperatorSet.AreaCenter(OCRZiTiUnion, out ZiTiArea, out ZiTiRow, out ZiTiCol);  //计算区域面积

                //对当前获取到的字符区域进行管控，以免因二值化等各种原因，筛选不到字符进行往下走
                if (ZiTiArea.D < 500)
                {
                    FuncLib.ShowMsg("当前寻找的字体区域有问题，请检查产品摆放位置是否正确...", InfoType.Error);
                    toolRunStatu = "当前寻找的字体区域有问题，请检查产品摆放位置是否正确...";
                    goto Exit;
                }

                //根据面积，过滤非法字符
                HOperatorSet.Connection(OCRZiTiUnion, out OCRZiTiConnect);  //将黑区域打散
                HOperatorSet.SelectShape(OCRZiTiConnect, out OCRZiTiConnect, "area", "and", AreaMin, AreaMax); //过滤掉斜杠字符
                HOperatorSet.CountObj(OCRZiTiConnect, out RegionNumber);    //计算区域个数

                //判断一下当前的图像背景是什么，解析字符信息的时候，需要把图像变成白底黑字
                if (BackType == CharBackType.黑底白字)
                {
                    HOperatorSet.InvertImage(OCRImage, out OCRImage);
                }


                // 对得到的字符进行识别
                HOperatorSet.SortRegion(OCRZiTiConnect, out OCRZiTiConnect, "first_point", "true", "column");   //对区域进行排序
                HTuple CharResults, confidence;
                HOperatorSet.ReadOcrClassMlp(CurOCRName, out modelID);  //获取当前识别库的句柄
                HOperatorSet.DoOcrMultiClassMlp(OCRZiTiConnect, OCRImage, modelID, out CharResults, out confidence); //根据句柄以及图像进行识别
                HOperatorSet.ClearOcrClassMlp(modelID); //清空字符识别句柄

                //获取当前的解析字符，将其转化为字符串
                string sstr = CharResults.ToString();
                if (sstr == "[]")
                {
                    FuncLib.ShowMsg("当前未识别到字符信息，请检查产品摆放位置是否正确", InfoType.Error);
                    toolRunStatu = "未识别到字符信息，请检查产品摆放位置是否正确";
                    goto Exit;
                }
                string[] str = CharResults.SArr;
                foreach (var item in str) CharResult += item;

                //进行规则效验
                bool codeRuleNG = false;
                try
                {
                    if (codeRule == "" || !CharResult.Contains(codeRule))
                    {
                        codeRuleNG = true;
                        DispObj(OCRZiTiConnect, "red");
                        toolRunStatu = "不符规则";
                        goto Exit;
                    }
                    else
                    {
                        toolRunStatu = "运行成功";
                        FuncLib.ShowMsg("当前识别结果OK：【" + CharResult + "】满足规则[" + codeRule + "]", InfoType.Tip);
                        DispObj(OCRZiTiConnect, "green");
                    }
                }
                catch (Exception ex)
                {
                    FuncLib.ShowMsg("解析结果出现异常：" + ex.ToString(), InfoType.Error);
                    codeRuleNG = true;
                }
                if (codeRuleNG)
                {
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                    FuncLib.ShowMessageBox("字符规则验证不通过", InfoType.Error);
                    DispObj(OCRZiTiConnect, "red");
                    DispText("NG", 24, 300, 300, "red", "true");
                    toolRunStatu = "字符规则验证不通过";
                    goto Exit;
                }


                #region  NG的情况会在中途跳出去，走到此说明是OK的

                toolRunStatu = "运行成功";

                #endregion

            }
            catch (Exception ex)
            {
                FuncLib.ShowExceptionBox(ex.ToString(), InfoType.Error);
                toolRunStatu = "未知原因";
            }



            
            Exit:
            if (Frm_OCRTool.hasShown && Frm_OCRTool.taskName == taskName && Frm_OCRTool.toolName == toolName)   //判断下当前的OCR工具是否打开的，如果是的话，则更新当前界面的信息
            {
                long time = sw.ElapsedMilliseconds;
                Frm_OCRTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());
                Frm_OCRTool.Instance.tbxResult.Text = CharResult;
                Frm_OCRTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
                if (toolRunStatu == "运行成功")
                {
                    Frm_OCRTool.Instance.lbl_toolTip.ForeColor = Color.Green;
                    Frm_OCRTool.Instance.hWindow_Final1.DispObj(OCRregion, "green");
                    Frm_OCRTool.Instance.hWindow_Final1.DispObj(OCRZiTiConnect, "green");
                    HalconLib.DispText(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, "OK", 48, 500, 500, "green", "false");
                }
                else
                {
                    Frm_OCRTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                    Frm_OCRTool.Instance.hWindow_Final1.DispObj(OCRregion, "red");
                    Frm_OCRTool.Instance.hWindow_Final1.DispObj(OCRZiTiConnect, "red");
                    HalconLib.DispText(Frm_OCRTool.Instance.hWindow_Final1.HWindowHalconID, "NG", 48, 500, 500, "red", "false");
                }
            }
            if (toolRunStatu.Contains("运行成功"))
            {
                DispText("OK", 48, 500, 500, "green", "false");
                Frm_Main.Instance.IsOK.Text = "OK:" + codeRule;
                Frm_Main.Instance.IsOK.ForeColor = Color.Green;
            }
            else if (toolRunStatu.Contains("不符规则"))
            {
                Frm_Main.Instance.IsOK.Text = "NG:不符规则";
                Frm_Main.Instance.IsOK.ForeColor = Color.Red;
                DispText("NG", 48, 500, 500, "red", "false");
                FuncLib.ShowMsg("当前识别结果NG：【" + CharResult + "】不符合规则[" + codeRule + "]，请检查标签情况...", InfoType.Error);
            }
            else if (toolRunStatu != "运行成功")
            {
                Frm_Main.Instance.IsOK.Text = "NG";
                Frm_Main.Instance.IsOK.ForeColor = Color.Red;
                DispText("NG", 48, 500, 500, "red", "false");
                FuncLib.ShowMsg("当前识别结果NG：" + CharResult, InfoType.Error);
            }



        }


        /// <summary>
        /// 选择路径的OCR字符路径
        /// </summary>
        internal void SelectDirectoryOCR()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择文件夹";
            dialog.SelectedPath = @"C:\Program Files\MVTec\HALCON-17.12-Progress\ocr";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] files = Directory.GetFiles(dialog.SelectedPath);
                    AllOCRName = new string[files.Length];
                    int StartCharIndex = 0;
                    int EndCharIndex = 0;
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i] != null)
                        {
                            StartCharIndex = files[i].LastIndexOf(@"\");
                            EndCharIndex = files[i].LastIndexOf(".");
                            AllOCRName[i] = files[i].Substring(StartCharIndex + 1, EndCharIndex - StartCharIndex - 1);
                        }
                    }

                    Frm_OCRTool.Instance.tbxLuJing.Text = dialog.SelectedPath.Replace(" ", "").ToString();
                    Frm_OCRTool.ocrTool.CurOCRName = Frm_OCRTool.Instance.tbxLuJing.Text;
                    Frm_OCRTool.ocrTool.OCRFilePath = dialog.SelectedPath.Replace(" ", "").ToString();
                    Frm_OCRTool.Instance.cmbAllOCR.Items.Clear();
                    Frm_OCRTool.Instance.cmbAllOCR.Items.AddRange(AllOCRName);
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查找当前字符识别库出现异常：" + ex.ToString());
                }

            }

        }


        /// <summary>
        /// 工具恢复到初始状态
        /// </summary>
        internal override void ResetTool()
        {
            FuncLib.ShowMessageBox("尚未开发，敬请期待！");
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

            private List<String> _文本 = new List<string>();
            public List<String> 文本
            {
                get { return _文本; }
                set { _文本 = value; }
            }
        }
        #endregion

    }
}
