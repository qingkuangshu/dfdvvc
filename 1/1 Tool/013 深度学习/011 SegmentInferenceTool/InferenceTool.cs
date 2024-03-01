using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using ViewWindow.Model;

namespace VM_Pro
{
    [Serializable]
    internal class InferenceTool : ToolBase
    {
        [NonSerialized]
        /// <summary>
        /// 预处理的字典句柄
        /// </summary>
        internal HTuple YuChuLiHandle = null;
        [NonSerialized]
        /// <summary>
        /// 训练所得的字典句柄
        /// </summary>
        internal HTuple XunLianHandle = null;

        /// <summary>
        /// 搜索区域类型
        /// </summary>
        internal RegionType searchRegionType = RegionType.整幅图像;

        /// <summary>
        /// 搜索区域
        /// </summary>
        internal List<ROI> L_regions = new List<ROI>();

        /// <summary>
        /// 训练模型的文件路径
        /// </summary>
        internal string XunLianPaht = "";

        /// <summary>
        /// True：说明当前是以GPU来运行
        /// False:说明当前是以CPU来运行
        /// </summary>
        internal bool IsRunGPU = false;

        /// <summary>
        /// 是否将最终的判定结果显示于主窗体当中
        /// </summary>
        internal bool RunResultShowFrmMain = false;

        /// <summary>
        /// 是否将模型解析图片显示到主窗体
        /// </summary>
        internal bool RunImgShowFrmMain = true;

        /// <summary>
        /// 是否将缺陷区域显示到主窗体【0默认为背景区域，不做显示】
        /// </summary>
        internal bool RunRegionShowFrmMain = true;

        /// <summary>
        /// 是否将推理检测区域显示到主窗体当中
        /// </summary>
        internal bool RunJianCeRegionShowFrmMain = false;


        /// <summary>
        /// True：该工具的dgv数据来源于frm_Debug的列表数据 
        /// False：工具的dgv数据来源于加载的语义分割文件句柄
        /// </summary>
        internal bool RunDgvDataGetFrmMain = false;

        /// <summary>
        /// 表格参数界面存放数据模型,可能其来源于主页面，也可能来源于模型文件
        /// </summary>
        internal List<LeiBieModel> lstDgvDataModel = new List<LeiBieModel>();


        /// <summary>
        /// 模型文件的参数列表信息
        /// </summary>
        internal List<LeiBieModel> lstClassNameModel = new List<LeiBieModel>();

        /// <summary>
        /// 存放缺陷标签
        /// </summary>
        internal string QueXianClassNames = "";

        /// <summary>
        /// 用于记录当前进行图像预处理操作的区域
        /// </summary>
        internal bool IsQuanTu = true;

        /// <summary>
        /// True:缺陷推理，即会在此工具类推理出相应缺陷区域的面积
        /// False：图像推理，表示该工具更多的作用是推理出最终的图像结果，便于其他工具进一步的处理
        /// </summary>
        internal bool IsQueXianTuiLi = true;

        /// <summary>
        /// 类构造器，辅助frm_Inference界面逻辑运算
        /// </summary>
        /// <param name="toolName">工具名称</param>
        /// <param name="taskName">所属任务</param>
        /// <param name="toolType">工具类型</param>
        internal InferenceTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;
            L_OutItemType = new List<DataType> { DataType.Image, DataType.Region };
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
        /// 运行工具
        /// </summary>
        /// <param name="updateImage">是否刷新图像</param>
        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
        {
            toolRunStatu = "未知原因";
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            HObject SearchRegion = null;    //当前缺陷查找区域

            #region 该工具首次加载时需要提前先进行初始化

            if (initRun)
            {
                参数 = new ToolPar();

                //初始化深度学习推理操作
                try
                {
                    //1、加载训练模型
                    if (XunLianPaht != "")
                    {
                        //加上此行可解决深度学习内存泄漏的问题，需在readdlmodel前执行才有效
                        HOperatorSet.SetSystem("cudnn_deterministic", "true");
                        HOperatorSet.ReadDlModel(XunLianPaht, out XunLianHandle);
                        GetXunLianModelSetYuChuLi(QueXianClassNames, true);
                    }

                    //2、根据当前所选择的运行环境，设置相应的系统参数
                    if (IsRunGPU)
                    {
                        HTuple cudaLoaded = null, cudnnLoaded = null, cublasLoaded = null;
                        HOperatorSet.GetSystem("cuda_loaded", out cudaLoaded);
                        HOperatorSet.GetSystem("cudnn_loaded", out cudnnLoaded);
                        HOperatorSet.GetSystem("cublas_loaded", out cublasLoaded);
                        if (!(cudaLoaded.S == "true" && cudnnLoaded.S == "true" && cublasLoaded.S == "true"))
                        {
                            //
                            FuncLib.ShowMsg("当前环境不支持GPU模式，已自动切换为CPU模式...", InfoType.Error);
                            IsRunGPU = false;
                        }
                    }
                    if (!IsRunGPU && XunLianHandle != null)
                    {
                        try
                        {
                            //此处可能会报没有足够内存的异常，先try起来，以免影响后面设置
                            HOperatorSet.SetDlModelParam(XunLianHandle, "runtime", "cpu");
                        }
                        catch (Exception)
                        {
                            toolRunStatu = "设置CPU出现内存不够异常";

                        }
                    }

                    //3、设置其他的参数
                    if (XunLianHandle != null)
                    {
                        HOperatorSet.SetDlModelParam(XunLianHandle, "batch_size", 1);
                        HOperatorSet.SetDlModelParam(XunLianHandle, "runtime_init", "immediately");
                    }
                }
                catch (Exception ex)
                {
                    //
                    toolRunStatu = "初始化异常:" + ex.Message;
                    sw.Stop();
                    return;
                }

                if (toolRunStatu.Contains("未知原因"))
                {
                    toolRunStatu = "运行成功";
                }
                sw.Stop();
                return;
            }

            #endregion


            #region 推理前输入信息异常管控

            //判断是否有图像输入
            if (((ToolPar)参数).输入.图像 == null)
            {
                toolRunStatu = "未指定输入图像";
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            if (XunLianHandle == null)
            {
                toolRunStatu = "训练模型文件异常";
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            if (YuChuLiHandle == null)
            {
                toolRunStatu = "预处理参数文件异常";
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }



            #endregion


            #region  根据当前读入的图片，进行模型推理

            try
            {
                #region 项目特有：极片追溯项目新增，后续可删除

                if (!IsQuanTu)
                {
                    if (((ToolPar)参数).输入.区域 == null)
                    {
                        toolRunStatu = "运行NG,膜区为空";
                        goto Exit;
                    }
                    HOperatorSet.ZoomImageSize(((ToolPar)参数).输入.图像, out HObject ZoomImg, 1224, 1024, "constant");
                    ((ToolPar)参数).输入.图像 = ZoomImg;
                    HOperatorSet.ZoomRegion(((ToolPar)参数).输入.区域, out HObject rrgion, 0.5, 0.5);
                    HOperatorSet.GetDomain(((ToolPar)参数).输入.图像, out HObject IQuanTu);
                    HOperatorSet.Difference(IQuanTu, rrgion, out HObject RQiTa);
                    HOperatorSet.OverpaintRegion(((ToolPar)参数).输入.图像, RQiTa, 180, "fill");
                }

                #endregion

                #region 获取模型推理缺陷区域集合

                HTuple DLsampleBatch = null, DLResultBatch = null;
                HObject img = ((ToolPar)参数).输入.图像;
                HObject SegmentationImg = null;
                HDevelopExport test = new HDevelopExport();
                //进行图像预处理
                test.gen_dl_samples_from_images(((ToolPar)参数).输入.图像, out DLsampleBatch);
                test.preprocess_dl_samples(DLsampleBatch, YuChuLiHandle);
                //进行图像推理
                HOperatorSet.ApplyDlModel(XunLianHandle, DLsampleBatch, new HTuple("segmentation_image", "segmentation_confidence"), out DLResultBatch);
                //获取预处理图像，类似原图
                HOperatorSet.GetDictObject(out img, DLsampleBatch, "image");
                //获取分割图像，类似于标注图
                HOperatorSet.GetDictObject(out SegmentationImg, DLResultBatch, "segmentation_image");
                DLsampleBatch.Dispose();
                DLResultBatch.Dispose();

                ((ToolPar)参数).输出.图像 = img;
                HTuple allArea = null; HObject QueXianRegions = null; HTuple ClassIDS = null;
                HOperatorSet.GetDlModelParam(XunLianHandle, "class_ids", out ClassIDS);
                //拿到之后，筛选出缺陷类型的区域,即有面积的区域
                HOperatorSet.Threshold(SegmentationImg, out QueXianRegions, ClassIDS, ClassIDS);
                //项目特有：极片缺陷 Start
                HOperatorSet.ZoomRegion(QueXianRegions, out QueXianRegions, 2, 2);
                //End

                HOperatorSet.RegionFeatures(QueXianRegions, "area", out allArea);
                //如果不是缺陷推理的话，那么该工具的目的则是输出推理图像，给到其他工具进一步处理
                if (!IsQueXianTuiLi)
                {
                    ((ToolPar)参数).输出.区域 = QueXianRegions;
                    ((ToolPar)参数).输出.图像 = SegmentationImg;
                    toolRunStatu = "运行成功";
                    goto Exit;
                }

                #endregion

                #region 获取当前所需查找缺陷的区域

                try
                {
                    if (!IsQuanTu)
                    {
                        if (((ToolPar)参数).输入.区域 != null && ((ToolPar)参数).输入.区域.CountObj() > 0)
                        {
                            SearchRegion = ((ToolPar)参数).输入.区域;
                        }
                    }
                    //说明去全图查找或者ROI链接输入为空，那么此时则默认查找区域为全图
                    if (SearchRegion == null)
                    {
                        HOperatorSet.GetDomain(((ToolPar)参数).输入.图像, out SearchRegion);
                        searchRegionType = RegionType.整幅图像;
                    }
                }
                catch (Exception)
                {
                    HOperatorSet.GetDomain(((ToolPar)参数).输入.图像, out SearchRegion);
                    searchRegionType = RegionType.整幅图像;
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, "获取推理区域出现异常，已自动切换为全图推理"), InfoType.Tip);
                }

                #endregion


                //判断数据列表是根据谁来更新的
                if (RunDgvDataGetFrmMain)
                {
                    lstDgvDataModel = Project.Instance.configuration.lstLeiBie;
                }
                else
                {
                    lstDgvDataModel = lstClassNameModel;
                }

                //防止当前推理出来的缺陷种类跟dgv检测缺陷种类对应不上
                int index = QueXianRegions.CountObj();
                if (index > lstDgvDataModel.Count)
                    index = lstDgvDataModel.Count;
                else
                    index = QueXianRegions.CountObj();


                //获取查找区域的边缘，可能后续边缘存在误判，则查找的相关缺陷可以根据查找区域的特征进行数据过滤
                HOperatorSet.RegionFeatures(SearchRegion, "row1", out HTuple SearchRow1);
                HOperatorSet.RegionFeatures(SearchRegion, "column1", out HTuple SearchCol1);
                HOperatorSet.RegionFeatures(SearchRegion, "row2", out HTuple SearchRow2);
                HOperatorSet.RegionFeatures(SearchRegion, "column2", out HTuple SearchCol2);





                //在查找区域当中，求出各种缺陷的交集面积
                for (int i = 0; i < index; i++)
                {
                    if (lstDgvDataModel != null && lstDgvDataModel[i].CheckEnable)
                    {
                        #region 求交集区域
                        //1.拿到当前的缺陷面积
                        HOperatorSet.SelectObj(QueXianRegions, out HObject selectObj, i + 1);  //注意选择的索引是从1开始的
                        HObject JiaoJiRegion = null;
                        HOperatorSet.Intersection(selectObj, SearchRegion, out JiaoJiRegion);
                        #endregion

                        #region 求每个交集区域的面积

                        HOperatorSet.Connection(JiaoJiRegion, out HObject ConnectRegions);

                        HOperatorSet.RegionFeatures(ConnectRegions, "area", out HTuple JiaoRegion);

                        #endregion


                        #region 求出当前缺陷类型的面积

                        //初始化该缺陷类型的当前面积，以及默认为OK，当检测到缺陷时，内部在赋为NG
                        lstDgvDataModel[i].BeforArea = 0;
                        lstDgvDataModel[i].CurrentResultOK = true;
                        if (lstDgvDataModel[i].lst_NGRegion == null)
                        {
                            lstDgvDataModel[i].lst_NGRegion = new List<HObject>();
                        }
                        lstDgvDataModel[i].lst_NGRegion.Clear();    //此地方注意，处理不当可能会造成一定的内存泄漏
                        //int aa = ConnectRegions.CountObj();
                        for (int j = 0; j < ConnectRegions.CountObj(); j++)
                        {
                            HObject IndexObj = null;
                            HOperatorSet.SelectObj(ConnectRegions, out IndexObj, j + 1);  //注意选择的索引是从1开始的

                            //因模型容易误检左下角跟右下角，在此进行过滤
                            HOperatorSet.AreaCenter(IndexObj, out HTuple area, out HTuple CurObjRow, out HTuple CurObjCol);
                            if (area < 400 && CurObjCol + 30 > SearchCol2 && CurObjRow + 30 > SearchRow2) //右下角
                            {
                                continue;
                            }
                            else if (area < 400 && CurObjCol - 30 < SearchCol1 && CurObjRow+30 > SearchRow2)    //左下角
                            {
                                continue;
                            }



                            //注意 i是缺陷类别，J是该缺陷类别的某个区域
                            if (JiaoRegion[j].D >= lstDgvDataModel[i].MinArea && JiaoRegion[j].D <= lstDgvDataModel[i].MaxArea)
                            {
                                lstDgvDataModel[i].BeforArea += JiaoRegion[j].D;    //叠加当前缺陷类型面积
                                lstDgvDataModel[i].CurrentResultOK = false;   //标记为NG
                                lstDgvDataModel[i].lst_NGRegion.Add(IndexObj); //记录NG区域
                                lstDgvDataModel[i].NG++;
                            }
                        }
                        #endregion


                    }
                    else if (!lstDgvDataModel[i].CheckEnable)
                    {
                        lstDgvDataModel[i].CurrentResultOK = true;
                    }
                }
            }
            catch (Exception ex)
            {
                FuncLib.ShowMsg("任务：" + taskName + "，" + toolName + "运行异常：" + ex.Message);
                toolRunStatu = "运行异常:" + ex.Message;
                goto Exit;
            }



            #endregion

            //if (!toolRunStatu.Contains("运行失败"))
            toolRunStatu = "运行成功";

        Exit:
            sw.Stop();
            //若当前工具打开的话，得将相应的处理信息更新到窗体界面当中
            if (Frm_Inference.hasShown && Frm_Inference.taskName == taskName && Frm_Inference.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_Inference.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());
                Frm_Inference.Instance.hWindow_Final1.ClearWindow();
                Frm_Inference.Instance.hWindow_Final1.viewWindow.displayImage(((ToolPar)参数).输入.图像);
                GenLstDgvDataModelShowDgvData(true);    //将检测结果显示于frm_inference当中
                if (toolRunStatu == "运行成功")
                {
                    Frm_Inference.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                    Frm_Inference.Instance.hWindow_Final1.DispText("OK", "green", 200, 200, 20);
                }
                else
                {
                    Frm_Inference.Instance.lbl_toolTip.ForeColor = Color.Red;
                    Frm_Inference.Instance.hWindow_Final1.DispText("NG", "red", 200, 200, 20);
                }
                Frm_Inference.Instance.lbl_toolTip.Text = toolRunStatu.ToString();

                if (!IsQueXianTuiLi)
                {
                    if (((ToolPar)参数).输出.区域 != null)
                    {
                        Frm_Inference.Instance.hWindow_Final1.DispObj(((ToolPar)参数).输出.区域, "yellow");
                    }
                }
            }

            //将推理的图像显示到主窗体当中
            if (RunImgShowFrmMain && (((ToolPar)参数).输出.图像) != null)
                DispImage((((ToolPar)参数).输出.图像));
            //将检测的区域显示到主窗体当中
            if (RunJianCeRegionShowFrmMain)
                if (SearchRegion != null)
                    DispObj(SearchRegion, "green");
            //将推理区域显示到主窗体当中
            if (RunRegionShowFrmMain)
            {
                if (lstDgvDataModel != null)
                {
                    for (int i = 0; i < lstDgvDataModel.Count; i++)
                    {
                        HObject CurrentQueXianRegion = lstDgvDataModel[i].AllRegionToOne();
                        if (CurrentQueXianRegion != null)
                        {
                            DispObj(CurrentQueXianRegion, "red");
                        }
                    }
                }
            }
            //将最直接的判定结果OK or NG打印到主窗体当中
            if (RunResultShowFrmMain)
            {
                if (toolRunStatu.Contains("运行成功"))
                {
                    DispText("OK", 20, 500, 500, "green", "false");
                }
                else
                {
                    DispText("NG", 20, 500, 500, "red", "false");
                }

            }
            GC.Collect();
        }


        #region 辅助方法，需操作窗体控件

        /// <summary>
        /// 根据lstDgvDataModel数据，将其数据填充到dgv控件当中 默认不显示缺陷区域
        /// </summary>
        /// <param name="ShowRunRegion">True：在工具窗体当中显示NG区域</param>
        internal void GenLstDgvDataModelShowDgvData(bool ShowRunRegion = false)
        {
            try
            {
                //将数据显示到表格当中
                if (lstDgvDataModel != null && lstDgvDataModel.Count > 0)
                {
                    Frm_Inference.Instance.DgvHandleData.Rows.Clear();
                    Frm_Inference.Instance.DgvHandleData.Rows.Add(lstDgvDataModel.Count);
                    for (int i = 0; i < lstDgvDataModel.Count; i++)
                    {
                        Frm_Inference.Instance.DgvHandleData.Rows[i].Cells[0].Value = i;
                        Frm_Inference.Instance.DgvHandleData.Rows[i].Cells[1].Value = lstDgvDataModel[i].LeiBie;
                        Frm_Inference.Instance.DgvHandleData.Rows[i].Cells[2].Value = lstDgvDataModel[i].MinArea;
                        Frm_Inference.Instance.DgvHandleData.Rows[i].Cells[3].Value = lstDgvDataModel[i].MaxArea;
                        Frm_Inference.Instance.DgvHandleData.Rows[i].Cells[4].Value = lstDgvDataModel[i].BeforArea;
                        Frm_Inference.Instance.DgvHandleData.Rows[i].Cells[5].Value = lstDgvDataModel[i].CheckEnable;
                        if (lstDgvDataModel[i].CurrentResultOK)
                        {
                            Frm_Inference.Instance.DgvHandleData.Rows[i].Cells[6].Style.BackColor = Color.Green;
                            Frm_Inference.Instance.DgvHandleData.Rows[i].Cells[6].Value = "OK";
                        }
                        else
                        {
                            Frm_Inference.Instance.DgvHandleData.Rows[i].Cells[6].Style.BackColor = Color.Red;
                            Frm_Inference.Instance.DgvHandleData.Rows[i].Cells[6].Value = "NG";
                        }
                        if (ShowRunRegion)
                        {
                            HObject HHobj = lstDgvDataModel[i].AllRegionToOne();
                            if (HHobj != null)
                            {
                                Frm_Inference.Instance.hWindow_Final1.DispObj(HHobj);
                            }
                        }
                    }
                    if (ShowRunRegion)
                    {
                        if (((ToolPar)参数).输入.区域 != null && ((ToolPar)参数).输入.区域.CountObj() > 0)
                        {
                            Frm_Inference.Instance.hWindow_Final1.DispObj(((ToolPar)参数).输入.区域, "green");
                        }

                    }

                }
            }
            catch (Exception)
            {

            }

        }



        /// <summary>
        /// 获取训练模型重新初始化设置预处理句柄，并生成新的结果列表
        /// </summary>
        /// <param name="QueXianLable">缺陷类别标签</param>
        /// <param name="initRun">当前是否为工具初始化 True：则不更新控件列表</param>
        /// <returns>是否执行成功</returns>
        internal bool GetXunLianModelSetYuChuLi(string QueXianLable, bool initRun = false)
        {
            bool RunOk = true;
            try
            {
                //获取预处理参数，然后创建一个新的预处理模型句柄出来， 因此处省去了一个预处理文件的导入，故在训练模型此抽取预处理句柄参数出来形成一个新的句柄，模拟预处理文件的导入
                HOperatorSet.GetDlModelParam(XunLianHandle, "class_ids", out HTuple ClassIDs);
                HOperatorSet.GetDlModelParam(XunLianHandle, "type", out HTuple DLPreprocess_Type);
                HOperatorSet.GetDlModelParam(XunLianHandle, "image_width", out HTuple DLPreprocessImage_width);
                HOperatorSet.GetDlModelParam(XunLianHandle, "image_height", out HTuple DLPreprocessImage_height);
                HOperatorSet.GetDlModelParam(XunLianHandle, "image_num_channels", out HTuple DLPreprocessImage_num_channels);
                HOperatorSet.GetDlModelParam(XunLianHandle, "image_range_min", out HTuple DLPreprocessImage_range_min);
                HOperatorSet.GetDlModelParam(XunLianHandle, "image_range_max", out HTuple DLPreprocessImage_range_max);
                HOperatorSet.GetDlModelParam(XunLianHandle, "ignore_class_ids", out HTuple DLPreprocessIgnore_class_ids);

                //创建预处理参数句柄，推理的时候需要
                if (YuChuLiHandle != null)
                    YuChuLiHandle.Dispose();  //释放资源
                HOperatorSet.CreateDict(out YuChuLiHandle);
                HOperatorSet.SetDictTuple(YuChuLiHandle, "model_type", DLPreprocess_Type);
                HOperatorSet.SetDictTuple(YuChuLiHandle, "image_width", DLPreprocessImage_width);
                HOperatorSet.SetDictTuple(YuChuLiHandle, "image_height", DLPreprocessImage_height);
                HOperatorSet.SetDictTuple(YuChuLiHandle, "image_num_channels", DLPreprocessImage_num_channels);
                HOperatorSet.SetDictTuple(YuChuLiHandle, "image_range_min", DLPreprocessImage_range_min);
                HOperatorSet.SetDictTuple(YuChuLiHandle, "image_range_max", DLPreprocessImage_range_max);
                HOperatorSet.SetDictTuple(YuChuLiHandle, "ignore_class_ids", DLPreprocessIgnore_class_ids);
                HOperatorSet.SetDictTuple(YuChuLiHandle, "normalization_type", "none");
                HOperatorSet.SetDictTuple(YuChuLiHandle, "domain_handling", "full_domain");
                HOperatorSet.SetDictTuple(YuChuLiHandle, "set_background_id", null);
                HOperatorSet.SetDictTuple(YuChuLiHandle, "class_ids_background", null);



                if (!initRun)   //工具在初始化的时候不能更新控件信息，因为此时窗体还没有创立的
                {
                    //生成新的检测列表
                    string[] ClassNameStrs = QueXianLable.Replace("\"", "").Replace("，", ",").Split(',');
                    int length = 0;  //若缺陷类别与ID的长度不一致，则取短的来算
                    if (ClassNameStrs.Length < ClassIDs.Length)
                    {
                        length = ClassNameStrs.Length;
                        FuncLib.ShowMessageBox("当前模型的ClassIDs大于输入标签个数，请检查模型是否正确...", InfoType.Warn);
                    }
                    else
                        length = ClassIDs.Length;
                    if (lstClassNameModel == null)
                        lstClassNameModel = new List<LeiBieModel>();
                    lstClassNameModel.Clear();
                    //填充文件类别列表
                    for (int i = 0; i < length; i++)
                    {
                        LeiBieModel item = new LeiBieModel();
                        item.LeiBie = ClassNameStrs[i];
                        lstClassNameModel.Add(item);
                    }
                    if (!RunDgvDataGetFrmMain)
                    {
                        lstDgvDataModel = lstClassNameModel;
                    }
                    GenLstDgvDataModelShowDgvData();
                }
            }
            catch (Exception ex)
            {
                RunOk = false;
                FuncLib.ShowMessageBox("初始化预处理句柄出现异常：" + ex.Message, InfoType.Error);
            }
            return RunOk;
        }

        #endregion

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
                set
                {
                    _图像 = value;
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

            private HObject _区域;
            public HObject 区域
            {
                get { return _区域; }
                set { _区域 = value; }
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
