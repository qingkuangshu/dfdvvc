using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VM_Pro
{
    [Serializable]
    internal class PreconditionTool : ToolBase
    {
        /// <summary>
        /// 类构造器，创建之时自动连接默认输入项
        /// </summary>
        /// <param name="toolName">工具名称</param>
        /// <param name="taskName">所属任务</param>
        /// <param name="toolType">工具类型</param>
        internal PreconditionTool(string toolName, string taskName, ToolType toolType)
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
        /// 用于存放当前工具界面的处理项数据即dgv
        /// </summary>
        internal List<Precondition_Dgv> YuChuLi_lst_dgv = new List<Precondition_Dgv>();

        /// <summary>
        /// 用于记录当前进行图像预处理操作的区域
        /// </summary>
        internal bool IsQuanTu = true;
        /// <summary>
        /// 将最终处理结果的图片显示到Main窗体当中
        /// </summary>
        internal bool ShowResultImg = false;

        /// <summary>
        /// 将最终处理结果的区域显示到Mian窗体当中
        /// </summary>
        internal bool ShowResultRegion = false;

        /// <summary>
        /// 是否显示当前预处理的区域范围
        /// </summary>
        internal bool ShowBeforRegion = false;

        /// <summary>
        /// 是否将处理结果图作为采集图像输出的图像【即原图】
        /// </summary>
        internal bool isOutImgToImgtoolOriginMap = false;

        /// <summary>
        /// 是否实时进行刷新
        /// </summary>
        internal bool isRunRenovate = false;
        /// <summary>
        /// 根据类型以及相应的参数进行界面切换
        /// </summary>
        /// <param name="yuChuLitype">类型</param>
        /// <param name="typeValue">切换的数值，若没有传进来数值的话，则会返回默认显示的数值</param>
        /// <returns>是否切换成功的标志</returns>
        internal bool SwitchYuChuLiForm(YuChuLiType yuChuLitype, ref string typeValue)
        {
            bool B_Switch = true;
            Form _currentShowFrm = null;    //当前所需要显示的参数窗口对象
            switch (yuChuLitype)
            {
                case YuChuLiType.二值化:
                    _currentShowFrm = Frm_Threshold.Instance;
                    if (typeValue != "")
                    {
                        string[] strs = typeValue.Split(',');
                        Frm_Threshold.Instance.TB_Low.Value = Convert.ToInt32(strs[0]);
                        Frm_Threshold.Instance.TB_Hig.Value = Convert.ToInt32(strs[1]);
                        Frm_Threshold.Instance.lb_LowValue.Text = strs[0];
                        Frm_Threshold.Instance.lb_HigValue.Text = strs[1];
                        Frm_Threshold.Instance.Ckb_HeiBai.Checked = strs[2] == "0" ? false : true;
                    }
                    else
                    {
                        Frm_Threshold.Instance.TB_Low.Value = 50;
                        Frm_Threshold.Instance.TB_Hig.Value = 200;
                        Frm_Threshold.Instance.Ckb_HeiBai.Checked = false;
                        typeValue = "50,200,0";
                    }
                    break;

                case YuChuLiType.锐化:
                    _currentShowFrm = Frm_Emphasize.Instance;
                    if (typeValue != "")
                    {
                        string[] strs = typeValue.Split(',');
                        Frm_Emphasize.Instance.TB_Width.Value = Convert.ToInt32(strs[0]);
                        Frm_Emphasize.Instance.TB_Height.Value = Convert.ToInt32(strs[1]);
                        Frm_Emphasize.Instance.TB_Factor.Value = Convert.ToInt32(Convert.ToDouble(strs[2]) * 10);
                    }
                    else
                    {
                        Frm_Emphasize.Instance.TB_Height.Value = 3;
                        Frm_Emphasize.Instance.TB_Width.Value = 3;
                        Frm_Emphasize.Instance.TB_Factor.Value = 3;
                        typeValue = "3,3,0.3";
                    }
                    break;

                case YuChuLiType.彩色转灰度图:
                case YuChuLiType.Tif转灰度图:
                    Frm_PreconditionTool.Instance.Panel_CanShu.Controls.Clear();
                    typeValue = "无";
                    break;
                case YuChuLiType.分辨率更改:
                case YuChuLiType.灰度膨胀:
                case YuChuLiType.灰度腐蚀:
                case YuChuLiType.均值滤波:
                case YuChuLiType.中值滤波:
                case YuChuLiType.灰度开运算:
                case YuChuLiType.灰度闭运算:
                    _currentShowFrm = FrmResolution.Instance;

                    if (typeValue != "")
                    {
                        string[] strs = typeValue.Split(',');
                        FrmResolution.Instance.txt_ImgWidth.Text = strs[0];
                        FrmResolution.Instance.txt_ImgHeight.Text = strs[1];
                    }
                    else
                    {
                        switch (yuChuLitype)
                        {
                            case YuChuLiType.均值滤波:
                                FrmResolution.Instance.txt_ImgWidth.Text = "9";
                                FrmResolution.Instance.txt_ImgHeight.Text = "9";
                                typeValue = "9,9";
                                break;
                            case YuChuLiType.中值滤波:
                                FrmResolution.Instance.txt_ImgWidth.Text = "15";
                                FrmResolution.Instance.txt_ImgHeight.Text = "15";
                                typeValue = "15,15";
                                break;
                            case YuChuLiType.高斯滤波:
                                break;
                            case YuChuLiType.灰度膨胀:
                            case YuChuLiType.灰度腐蚀:
                            case YuChuLiType.灰度开运算:
                            case YuChuLiType.灰度闭运算:
                                FrmResolution.Instance.txt_ImgWidth.Text = "11";
                                FrmResolution.Instance.txt_ImgHeight.Text = "11";
                                typeValue = "11,11";
                                break;
                            case YuChuLiType.对比度:
                                break;
                            case YuChuLiType.亮度调节:
                                break;
                            case YuChuLiType.分辨率更改:
                                FrmResolution.Instance.txt_ImgWidth.Text = "1024";
                                FrmResolution.Instance.txt_ImgHeight.Text = "512";
                                typeValue = "1024,512";
                                break;
                            default:
                                break;
                        }
                        
                    }
                    break;
                default:
                    B_Switch = false;
                    break;
            }
            if (B_Switch)
            {
                if (_currentShowFrm != null)
                {
                    Frm_PreconditionTool.Instance.Panel_CanShu.Controls.Clear();
                    _currentShowFrm.TopLevel = false;
                    _currentShowFrm.Parent = Frm_PreconditionTool.Instance.Panel_CanShu;
                    _currentShowFrm.Dock = DockStyle.Top;
                    _currentShowFrm.Show();
                }
            }

            return B_Switch;

        }


        /// <summary>
        /// 将列表数据填充到dgv控件当中
        /// </summary>
        /// <param name="SelectIndex">当前所需选中的行数索引</param>
        /// <returns>返回是否显示成功的标志</returns>
        internal bool GenLstShowDgvData(int SelectIndex = 0)
        {
            bool ShowDgvSuccess = true;
            try
            {
                Frm_PreconditionTool.Instance.dgv_YuChuLi.Rows.Clear();
                //更新相应的信息
                if (YuChuLi_lst_dgv != null && YuChuLi_lst_dgv.Count > 0)
                {
                    for (int i = 0; i < YuChuLi_lst_dgv.Count; i++)
                    {
                        Frm_PreconditionTool.Instance.dgv_YuChuLi.Rows.Add();
                        Frm_PreconditionTool.Instance.dgv_YuChuLi.Rows[i].Cells[0].Value = YuChuLi_lst_dgv[i].StartUse;
                        Frm_PreconditionTool.Instance.dgv_YuChuLi.Rows[i].Cells[1].Value = YuChuLi_lst_dgv[i].type;
                        Frm_PreconditionTool.Instance.dgv_YuChuLi.Rows[i].Cells[2].Value = YuChuLi_lst_dgv[i].CanShuStr;
                    }
                    ShowDgvSuccess = SwitchYuChuLiForm(YuChuLi_lst_dgv[SelectIndex].type,ref YuChuLi_lst_dgv[SelectIndex].CanShuStr);
                    Frm_PreconditionTool.Instance.dgv_YuChuLi.Rows[SelectIndex].Selected = true;
                    Frm_PreconditionTool.Instance.dgv_YuChuLi.CurrentCell = Frm_PreconditionTool.Instance.dgv_YuChuLi.Rows[SelectIndex].Cells[0];

                    //Frm_PreconditionTool.Instance.dgv_YuChuLi.SelectedIndex = SelectIndex;    //无法获取到是否切换到预处理参数界面，故不采用此方式
                }
            }
            catch (Exception ex)
            {
                FuncLib.ShowMessageBox(ex.Message, InfoType.Error);
                ShowDgvSuccess = false;
            }
            return ShowDgvSuccess;
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
                if (YuChuLi_lst_dgv == null)
                    YuChuLi_lst_dgv = new List<Precondition_Dgv>();
                参数 = new ToolPar();
                toolRunStatu = "运行成功";
                sw.Stop();
                return;
            }

            //若无图像输入，该工具则不进行处理
            if (((ToolPar)参数).输入.图像 == null)
            {
                toolRunStatu = "未指定输入图像";
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            //根据当前处理列表去进行各项图像预处理

            if (YuChuLi_lst_dgv != null && YuChuLi_lst_dgv.Count > 0)
            {
                HObject OutImg = ((ToolPar)参数).输入.图像;
                HObject OutRegion = null;
                //在此处需要截取预处理操作的范围
                //如果是ROI处理的话，则截取当前的ROI所在的图片，否则，则默认是全图Img
                if (!IsQuanTu && ((ToolPar)参数).输入.区域 != null && ((ToolPar)参数).输入.区域.CountObj() > 0)
                {
                    HOperatorSet.ReduceDomain(OutImg, ((ToolPar)参数).输入.区域, out OutImg);
                }
                else if (!IsQuanTu && ((ToolPar)参数).输入.区域 == null)
                {
                    FuncLib.ShowMsg("工具：" + toolName + "— 当前输入区域为空，自动以全局查找", InfoType.Warn);
                }

                try
                {
                    //循环处理当前所有预处理项目
                    for (int i = 0; i < YuChuLi_lst_dgv.Count; i++)
                    {
                        if (!YuChuLi_lst_dgv[i].StartUse)
                        {
                            continue;
                        }
                        string[] strs = YuChuLi_lst_dgv[i].CanShuStr.Split(',');
                        switch (YuChuLi_lst_dgv[i].type)
                        {
                            case YuChuLiType.二值化:
                                if (strs[2] == "1") //说明需要黑白翻转【0，即正常，1翻转】
                                {
                                    HOperatorSet.InvertImage(OutImg, out OutImg);
                                }
                                HOperatorSet.Threshold(OutImg, out OutRegion, Convert.ToInt32(strs[0]), Convert.ToInt32(strs[1]));
                                break;

                            case YuChuLiType.锐化:
                                HOperatorSet.Emphasize(OutImg, out OutImg, Convert.ToInt32(strs[0]), Convert.ToInt32(strs[1]), Convert.ToDouble(strs[2]));
                                break;

                            case YuChuLiType.Tif转灰度图:
                                HOperatorSet.GetDomain(OutImg, out HObject domain);
                                HOperatorSet.MinMaxGray(domain, OutImg, 0, out HTuple min, out HTuple max, out HTuple range);
                                HOperatorSet.ScaleImage(OutImg, out OutImg, 1, 0 - min);
                                HOperatorSet.ScaleImage(OutImg, out OutImg, 255 / (max - min), 0);
                                HOperatorSet.ConvertImageType(OutImg, out OutImg, "byte");
                                break;

                            case YuChuLiType.彩色转灰度图:
                                HOperatorSet.Rgb1ToGray(OutImg, out OutImg);
                                break;

                            case YuChuLiType.分辨率更改:
                                HOperatorSet.ZoomImageSize(OutImg, out OutImg, Convert.ToInt32(strs[0]), Convert.ToInt32(strs[1]), "constant");
                                break;

                            case YuChuLiType.灰度腐蚀:
                                HOperatorSet.GrayErosionRect(OutImg, out OutImg, Convert.ToInt32(strs[0]), Convert.ToInt32(strs[1]));
                                break;

                            case YuChuLiType.灰度膨胀:
                                HOperatorSet.GrayDilationRect(OutImg, out OutImg, Convert.ToInt32(strs[0]), Convert.ToInt32(strs[1]));
                                break;

                            case YuChuLiType.均值滤波:
                                HOperatorSet.MeanImage(OutImg, out OutImg, Convert.ToInt32(strs[0]), Convert.ToInt32(strs[1]));
                                break;

                            case YuChuLiType.中值滤波:
                                HOperatorSet.MedianRect(OutImg, out OutImg, Convert.ToInt32(strs[0]), Convert.ToInt32(strs[1]));
                                break;

                            case YuChuLiType.灰度开运算:
                                HOperatorSet.GrayOpeningRect(OutImg, out OutImg, Convert.ToInt32(strs[0]), Convert.ToInt32(strs[1]));
                                break;

                            case YuChuLiType.灰度闭运算:
                                HOperatorSet.GrayClosingRect(OutImg, out OutImg, Convert.ToInt32(strs[0]), Convert.ToInt32(strs[1]));
                                break;

                            default:
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    FuncLib.ShowExceptionBox("预处理出现错误，请检查参数格式" + ex.Message, InfoType.Error);
                    toolRunStatu = "运行异常";
                    goto Exit;
                }
                ((ToolPar)参数).输出.图像 = OutImg;
                ((ToolPar)参数).输出.区域 = OutRegion;
                //HOperatorSet.WriteImage(OutImg, "png", 0, "d:\\zhangsn");

            }





            //GenlstYuChuLi(((ToolPar)参数).输入.图像, ((ToolPar)参数).输入.区域, out HObject img, out region);

            //((ToolPar)参数).输出.图像 = img;
            //((ToolPar)参数).输出.区域 = region;

            toolRunStatu = "运行成功";
        Exit:
            sw.Stop();

            if (Frm_PreconditionTool.hasShown && Frm_PreconditionTool.taskName == taskName && Frm_PreconditionTool.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_PreconditionTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());

                Frm_PreconditionTool.Instance.hWindow_Final1.viewWindow.ClearWindow();
                if (!ShowResultImg)
                {
                    Frm_PreconditionTool.Instance.hWindow_Final1.viewWindow.displayImage(((ToolPar)参数).输入.图像);
                }
                else
                {
                    if (((ToolPar)参数).输出.图像 !=null)
                    {
                        Frm_PreconditionTool.Instance.hWindow_Final1.viewWindow.displayImage(((ToolPar)参数).输出.图像);
                    }
                }

                if (!IsQuanTu && ((ToolPar)参数).输入.区域 != null && ((ToolPar)参数).输入.区域.CountObj() > 0)
                    Frm_PreconditionTool.Instance.hWindow_Final1.DispObj(((ToolPar)参数).输入.区域, "green");

                HOperatorSet.SetDraw(Frm_PreconditionTool.Instance.hWindow_Final1.HWindowHalconID, "fill");
                Frm_PreconditionTool.Instance.hWindow_Final1.DispObj(((ToolPar)参数).输出.区域, "red", "fill");

                if (toolRunStatu == "运行成功")
                    Frm_PreconditionTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                else
                    Frm_PreconditionTool.Instance.lbl_toolTip.ForeColor = Color.Red;

                Frm_PreconditionTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
            }

            if (isOutImgToImgtoolOriginMap)
            {
                ((ImageTool.ToolPar)Task.FindTaskByName(taskName).FindToolByName("采集图像").参数).输出.图像 = (((ToolPar)参数).输出.图像);
            }

            if (ShowResultImg)
                DispImage((((ToolPar)参数).输出.图像));

            if (ShowBeforRegion && !IsQuanTu && ((ToolPar)参数).输入.区域 != null && ((ToolPar)参数).输入.区域.CountObj() > 0)
                DispObj((((ToolPar)参数).输入.区域), "blue");

            if (ShowResultRegion)
            {
                //DispObj((((ToolPar)参数).输出.区域), "red");
                GetImageWindow().DispObj((((ToolPar)参数).输出.区域), "red", "fill");
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
                get
                {
                    return _图像;
                }
                set
                {
                    _图像 = value;
                }
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
        }
        #endregion


    }




    /// <summary>
    /// 该类用于配合当前工具执行，故类定义于此处
    /// </summary>
    [Serializable]
    internal class Precondition_Dgv
    {
        internal Precondition_Dgv() { }


        internal Precondition_Dgv(bool Check, YuChuLiType _type, string _canShuStr)
        {
            this.StartUse = Check;
            this.type = _type;
            this.CanShuStr = _canShuStr;

        }
        /// <summary>
        /// 当前项是否启用
        /// </summary>
        internal bool StartUse = true;

        /// <summary>
        /// 该项的预处理类型
        /// </summary>
        internal YuChuLiType type = YuChuLiType.二值化;

        /// <summary>
        /// 对应的预处理参数
        /// </summary>
        internal string CanShuStr = "";

    }
}
