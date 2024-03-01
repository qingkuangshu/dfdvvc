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
    public partial class Frm_IDTool : UIForm
    {
        public Frm_IDTool()
        {
            InitializeComponent();
            hWindow_Final1.hWindowControl.MouseUp += Hwindow_MouseUp;
        }

        /// <summary>
        /// 开始指定左上角
        /// </summary>
        private static bool startSelectLeftUpPoint = false;
        /// <summary>
        /// 开始指定右下角
        /// </summary>
        private static bool startSelectRightDownPoint = false;
        /// <summary>
        /// 正在抓图的话就放弃再次抓图
        /// </summary>
        private static bool isGrabing = false;
        /// <summary>
        /// 是否启用事件，也就是不执行本次触发的事件
        /// </summary>
        internal static bool openingForm = false;
        /// <summary>
        /// 当前工具名
        /// </summary>
        internal static string toolName = string.Empty;
        /// <summary>
        /// 当前工具所属的流程
        /// </summary>
        internal static string taskName = string.Empty;
        /// <summary>
        /// 窗体是否已显示
        /// </summary>
        internal static bool hasShown = false;
        /// <summary>
        /// 工具对象
        /// </summary>
        internal static IDTool idTool;
        /// <summary>
        /// 搜索区域
        /// </summary>
        internal static List<ViewWindow.Model.ROI> L_regions = new List<ViewWindow.Model.ROI>();

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_IDTool _instance;
        internal static Frm_IDTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_IDTool();
                return _instance;
            }
        }


        /// <summary>
        /// 弹出工具页面
        /// </summary>
        /// <param name="toolBase">工具</param>
        internal static void ShowForm(ToolBase toolBase)
        {
            if (hasShown && taskName == toolBase.taskName && toolName == toolBase.toolName)     //如果当前工具已显示或者最小化了，那就直接显示即可
            {
                Instance.WindowState = FormWindowState.Normal;
                Instance.Activate();
                return;
            }

            openingForm = true;
            Instance.Text = string.Format("{0}    [ {1} . {2} ]", toolBase.toolType, toolBase.taskName, toolBase.toolName);
            idTool = (IDTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;

            try
            {
                Instance.Show();    //有时会出现创建句柄异常的现象，那么则释放其对象，重新创建一个

            }
            catch (Exception)
            {
                Instance.Close();
                _instance = null;
                UIMessageTip.ShowError("打开工具界面异常，请稍后重试...");
                return;
            }



            hasShown = true;

            idTool.UpdateInput();

            //显示图像
            if (((IDTool.ToolPar)idTool.参数).输入.图像 != null)
            {
                Instance.hWindow_Final1.HobjectToHimage(((IDTool.ToolPar)idTool.参数).输入.图像);
                Application.DoEvents();
            }

            //显示新的搜索区域
            if (!idTool.enableArraySearchRegion)
            {
                Instance.hWindow_Final1.DispObj(((IDTool.ToolPar)idTool.参数).输入.区域, "green");
            }
            else
            {
                HObject allRegion = idTool.CreateArrayRegion();
                Instance.hWindow_Final1.DispObj(allRegion, "blue");
            }



            //显示区域页面
            for (int i = 0; i < idTool.L_inputItem.Count; i++)
            {
                if (idTool.L_inputItem[i].inputType == DataType.Region)
                {
                    Instance.txt_ROILianRu.Text = idTool.L_inputItem[i].sourceTool + ".区域";
                }
                else if (idTool.L_inputItem[i].inputType == DataType.Image)
                {
                    Instance.txt_ImgLianRu.Text = idTool.L_inputItem[i].sourceTool + ".图像";
                }
            }
            Instance.ckb_isVP.Checked = idTool.isVP;
            Instance.rad_IsQuanTu.Checked = idTool.isQuanTu;
            Instance.rad_IsQuYu.Checked = !idTool.isQuanTu;

            Instance.ckb_taskFailKeepRun.Checked = idTool.taskFailKeepRun;
            Instance.cbx_codeType.SelectedIndex = (int)idTool.codeType;
            Instance.cbx_qrCodeType.Text = idTool.qrCodeType;
            Instance.tbx_codeRule.Text = idTool.codeRule;
            Instance.nud_minLength.Value = idTool.minLength;
            Instance.nud_maxLength.Value = idTool.maxLength;
            Instance.nud_findNum.Value = idTool.findNum;
            Instance.nud_threshold.Value = idTool.threshold;
            Instance.nud_timeout.Value = idTool.timeout;


            Instance.ckb_showTextAtLeftDown.Checked = idTool.showTextAtLeftDown;
            Instance.ckb_showTextAtCodeRegion.Checked = idTool.showTextAtCodeRegion;
            Instance.ckb_showSearchRegion.Checked = idTool.showSearchRegion;

            Instance.cbx_sortMode.SelectedIndex = (int)idTool.sortMode;
            Instance.nud_spacing.Value = idTool.spacing;

            Instance.ckb_arraySearchRegion.Checked = idTool.enableArraySearchRegion;
            Instance.nud_rowNum.Value = idTool.arrayRowNum;
            Instance.nud_colNum.Value = idTool.arrayColNum;
            Instance.nud_arraySizeWidth.Value = idTool.arraySizeWidth;
            Instance.nud_arraySizeHeight.Value = idTool.arraySizeHeight;

            if (idTool.enableArraySearchRegion)
            {
                Instance.label11.Visible = true;
                Instance.label14.Visible = true;
                Instance.nud_rowNum.Visible = true;
                Instance.nud_colNum.Visible = true;
                Instance.label16.Visible = true;
                Instance.label15.Visible = true;
                Instance.btn_selectLeftUpPoint.Visible = true;
                Instance.btn_selectRightDownPoint.Visible = true;
                Instance.label17.Visible = true;
                Instance.label18.Visible = true;
                Instance.label19.Visible = true;
                Instance.nud_arraySizeWidth.Visible = true;
                Instance.label20.Visible = true;
                Instance.nud_arraySizeHeight.Visible = true;
            }
            else
            {
                Instance.label11.Visible = false;
                Instance.label14.Visible = false;
                Instance.nud_rowNum.Visible = false;
                Instance.nud_colNum.Visible = false;
                Instance.label16.Visible = false;
                Instance.label15.Visible = false;
                Instance.btn_selectLeftUpPoint.Visible = false;
                Instance.btn_selectRightDownPoint.Visible = false;
                Instance.label17.Visible = false;
                Instance.label18.Visible = false;
                Instance.label19.Visible = false;
                Instance.nud_arraySizeWidth.Visible = false;
                Instance.label20.Visible = false;
                Instance.nud_arraySizeHeight.Visible = false;
            }
            Instance.label17.Text = string.Format("({0},{1})", idTool.arrayLeftUpPoint.X, idTool.arrayLeftUpPoint.Y);
            Instance.label18.Text = string.Format("({0},{1})", idTool.arrayRightDownPoint.X, idTool.arrayRightDownPoint.Y);

            //////Thread th1 = new Thread(() =>
            //////{
            //////    idTool.Run();
            //////});
            //////th1.IsBackground = true;
            //////th1.Start();

            Instance.Activate();
            Instance.btn_runTool.Focus();
            openingForm = false;
        }
        private void Hwindow_MouseUp(object sender, MouseEventArgs e)
        {
            if (startSelectLeftUpPoint)
            {
                Frm_IDTool.Instance.hWindow_Final1.HobjectToHimage(((IDTool.ToolPar)idTool.参数).输入.图像);
                startSelectLeftUpPoint = false;
                HTuple row, col, button;
                HOperatorSet.GetMposition(hWindow_Final1.HWindowHalconID, out row, out col, out button);
                idTool.arrayLeftUpPoint.X = row;
                idTool.arrayLeftUpPoint.Y = col;

                HObject cross;
                HOperatorSet.GenCrossContourXld(out cross, row, col, 50, 0);
                hWindow_Final1.DispObj(cross, "green");
                label17.Text = string.Format("( {0} , {1} )", idTool.arrayLeftUpPoint.X.ToString("0000"), idTool.arrayLeftUpPoint.Y.ToString("0000"));

                if (idTool.arrayRightDownPoint.X != 0 && idTool.arrayRightDownPoint.Y != 0)
                    Frm_IDTool.Instance.hWindow_Final1.DispObj(idTool.CreateArrayRegion(), "blue");
            }

            if (startSelectRightDownPoint)
            {
                Frm_IDTool.Instance.hWindow_Final1.HobjectToHimage(((IDTool.ToolPar)idTool.参数).输入.图像);
                startSelectRightDownPoint = false;
                HTuple row, col, button;
                HOperatorSet.GetMposition(hWindow_Final1.HWindowHalconID, out row, out col, out button);
                idTool.arrayRightDownPoint.X = row;
                idTool.arrayRightDownPoint.Y = col;

                HObject cross;
                HOperatorSet.GenCrossContourXld(out cross, row, col, 50, 0);
                hWindow_Final1.DispObj(cross, "green");
                label18.Text = string.Format("( {0} , {1} )", idTool.arrayRightDownPoint.X.ToString("0000"), idTool.arrayRightDownPoint.Y.ToString("0000"));

                Frm_IDTool.Instance.hWindow_Final1.DispObj(idTool.CreateArrayRegion(), "blue");
            }

            int index;
            List<double> data;
            ViewWindow.Model.ROI roi = hWindow_Final1.viewWindow.smallestActiveROI(out data, out index);
            if (index > -1)
            {
                string name = roi.GetType().Name;
                L_regions[index] = roi;
            }
        }


        private void toolStrip1_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }
        private void 保存toolStripButton1_Click(object sender, EventArgs e)
        {
            Scheme.SaveCur();
            FuncLib.ShowMsg("保存当前方案成功", InfoType.Tip);
        }
        private void 复位toolStripButton3_Click(object sender, EventArgs e)
        {
            idTool.ResetTool();
        }
        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            idTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }
        private void Frm_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }
        private void btn_runTool_Click(object sender, EventArgs e)
        {
            if (!isGrabing)
            {
                Thread th = new Thread(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        Frm_Loading.Instance.lbl_title.Text = "拼命加载中";
                        Frm_Loading.Instance.TopLevel = true;
                        Frm_Loading.Instance.TopMost = true;
                        Frm_Loading.Instance.Show();
                    }));
                    isGrabing = true;
                    idTool.Run();
                    isGrabing = false;
                    Frm_Loading.Instance.Hide();
                });
                th.IsBackground = true;
                th.Start();
            }
        }
        private void btn_runTask_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Task.FindTaskByName(taskName).Run();
            });
            th.IsBackground = true;
            th.Start();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbx_codeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            idTool.codeType = (CodeType)cbx_codeType.SelectedIndex;
            if (cbx_codeType.SelectedIndex != 1)
            {
                label1.Visible = true;
                cbx_qrCodeType.Visible = true;
                btn_autoSelect.Visible = true;
            }
            else
            {
                label1.Visible = false;
                cbx_qrCodeType.Visible = false;
                btn_autoSelect.Visible = false;
            }

            Thread th = new Thread(() =>
            {
                idTool.Run(true);
            });
            th.IsBackground = true;
            th.Start();
        }
        private void cbx_qrCodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            idTool.qrCodeType = cbx_qrCodeType.Text;

            Thread th = new Thread(() =>
            {
                idTool.Run(true);
            });
            th.IsBackground = true;
            th.Start();
        }
        private void tbx_codeRule_TextChanged(object sender, EventArgs e)
        {
            idTool.codeRule = tbx_codeRule.Text.Trim();
        }
        private void btn_autoSelect_Click(object sender, EventArgs e)
        {
            btn_autoSelect.FillColor = Color.Green;
            btn_autoSelect.Text = "识别中...";

            idTool.AutoSelectQRType();

            btn_autoSelect.FillColor = Color.FromArgb(80, 160, 255);
            btn_autoSelect.Text = "自动识别";
        }
        private void nud_minLength_ValueChanged(double value)
        {
            if (openingForm)
                return;

            idTool.minLength = (int)value;
        }
        private void nud_maxLength_ValueChanged(double value)
        {
            if (openingForm)
                return;

            idTool.maxLength = (int)value;
        }
        private void nud_findNum_ValueChanged(double value)
        {
            if (openingForm)
                return;

            idTool.findNum = (int)value;
        }
        private void nud_threshold_ValueChanged(double value)
        {
            if (openingForm)
                return;

            idTool.threshold = (int)value;
        }
        private void nud_timeout_ValueChanged(double value)
        {
            if (openingForm)
                return;

            idTool.timeout = (int)value;
        }
        private void ckb_showTextAtLeftDown_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            idTool.showTextAtLeftDown = ckb_showTextAtLeftDown.Checked;

            Thread th = new Thread(() =>
            {
                idTool.Run(true);
            });
            th.IsBackground = true;
            th.Start();
        }
        private void ckb_showTextAtCodeRegion_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            idTool.showTextAtCodeRegion = ckb_showTextAtCodeRegion.Checked;

            Thread th = new Thread(() =>
            {
                idTool.Run(true);
            });
            th.IsBackground = true;
            th.Start();
        }
        private void ckb_showSearchRegion_Click(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            idTool.showSearchRegion = ckb_showSearchRegion.Checked;

            Thread th = new Thread(() =>
            {
                idTool.Run(true);
            });
            th.IsBackground = true;
            th.Start();
        }
        private void cbx_sortMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            idTool.sortMode = (SortMode)cbx_sortMode.SelectedIndex;

            Thread th = new Thread(() =>
            {
                idTool.Run(true);
            });
            th.IsBackground = true;
            th.Start();
        }
        private void nud_spacing_ValueChanged(double value)
        {
            if (openingForm)
                return;

            idTool.spacing = (int)value;

            Thread th = new Thread(() =>
            {
                idTool.Run(true);
            });
            th.IsBackground = true;
            th.Start();
        }
        private void dgv_result_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //////if (e.RowIndex < 0)
            //////    return;

            //////if (idTool.toolPar.InputPar.图像 != null)
            //////    Instance.hWindow_Final1.HobjectToHimage(idTool.toolPar.InputPar.图像);
            //////else
            //////    Instance.hWindow_Final1.ClearWindow();

            ////////显示搜索区域
            //////if (idTool.searchRegionType != RegionType.整幅图像 )
            //////{
            //////    if (idTool.searchRegionType == (RegionType.输入区域 )
            //////        Instance.hWindow_Final1.DispObj(idTool.searchRegionAfterTransed, "blue");
            //////    else
            //////        Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
            //////}

            ////////显示条码区域
            //////Instance.hWindow_Final1.DispObj(idTool.L_result[e.RowIndex].Region, "green");

            ////////在图像左上角显示文本
            //////if (idTool.showTextAtLeftDown) 
            //////    HalconLib.DispText (Instance.hWindow_Final1.HWindowHalconID, (HTuple)idTool.L_result[e.RowIndex].ResultStr, "image", 40, 40, "blue", "true");

            ////////在条码处显示文本
            //////if (idTool.showTextAtCodeRegion)
            //////    HalconLib.DispText(Instance.hWindow_Final1.HWindowHalconID, (HTuple)idTool.L_result[e.RowIndex].ResultStr, "image", (HTuple)idTool.L_result[e.RowIndex].Row + 5, (HTuple)idTool.L_result[e.RowIndex].Col, "blue", "true");
        }

        private void ckb_arraySearchRegion_Click(object sender, EventArgs e)
        {
            idTool.enableArraySearchRegion = ckb_arraySearchRegion.Checked;

            if (idTool.enableArraySearchRegion)
            {
                label11.Visible = true;
                label14.Visible = true;
                nud_rowNum.Visible = true;
                nud_colNum.Visible = true;
                label16.Visible = true;
                label15.Visible = true;
                btn_selectLeftUpPoint.Visible = true;
                btn_selectRightDownPoint.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                nud_arraySizeWidth.Visible = true;
                label20.Visible = true;
                nud_arraySizeHeight.Visible = true;
            }
            else
            {
                label11.Visible = false;
                label14.Visible = false;
                nud_rowNum.Visible = false;
                nud_colNum.Visible = false;
                label16.Visible = false;
                label15.Visible = false;
                btn_selectLeftUpPoint.Visible = false;
                btn_selectRightDownPoint.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                nud_arraySizeWidth.Visible = false;
                label20.Visible = false;
                nud_arraySizeHeight.Visible = false;
            }
        }
        private void nud_rowNum_ValueChanged(double value)
        {
            if (openingForm)
                return;

            idTool.arrayRowNum = (int)value;
            Frm_IDTool.Instance.hWindow_Final1.HobjectToHimage(((IDTool.ToolPar)idTool.参数).输入.图像);
            Frm_IDTool.Instance.hWindow_Final1.DispObj(idTool.CreateArrayRegion(), "blue");
        }
        private void nud_colNum_ValueChanged(double value)
        {
            if (openingForm)
                return;

            idTool.arrayColNum = (int)value;
            Frm_IDTool.Instance.hWindow_Final1.HobjectToHimage(((IDTool.ToolPar)idTool.参数).输入.图像);
            Frm_IDTool.Instance.hWindow_Final1.DispObj(idTool.CreateArrayRegion(), "blue");
        }
        private void nud_arraySizeWidth_ValueChanged(double value)
        {
            if (openingForm)
                return;

            idTool.arraySizeWidth = (int)value;
            Frm_IDTool.Instance.hWindow_Final1.HobjectToHimage(((IDTool.ToolPar)idTool.参数).输入.图像);

            Frm_IDTool.Instance.hWindow_Final1.DispObj(idTool.CreateArrayRegion(), "blue");
        }
        private void nud_arraySizeHeight_ValueChanged(double value)
        {
            if (openingForm)
                return;

            idTool.arraySizeHeight = (int)value;
            Frm_IDTool.Instance.hWindow_Final1.HobjectToHimage(((IDTool.ToolPar)idTool.参数).输入.图像);

            Frm_IDTool.Instance.hWindow_Final1.DispObj(idTool.CreateArrayRegion(), "blue");
        }
        private void btn_selectLeftUpPoint_Click(object sender, EventArgs e)
        {
            startSelectLeftUpPoint = true;
            Frm_IDTool.Instance.hWindow_Final1.HobjectToHimage(((IDTool.ToolPar)idTool.参数).输入.图像);
        }
        private void btn_selectRightDownPoint_Click(object sender, EventArgs e)
        {
            startSelectRightDownPoint = true;
        }
        private void Frm_IDTool_ExtendBoxClick(object sender, EventArgs e)
        {
            Instance.TopMost = !Instance.TopMost;

            if (Instance.TopMost)
                Instance.ExtendSymbol = 61475;
            else
                Instance.ExtendSymbol = 61758;
        }

        /// <summary>
        /// 链入区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgBtn_ROILianRu_Click(object sender, EventArgs e)
        {
            if (!rad_IsQuYu.Checked)
            {
                UIMessageTip.ShowWarning("请先选择输入区域模式后在点击此按钮");
                return;
            }
            FrmBianLiang frm = new FrmBianLiang(toolName);
            frm.TagString = "区域";
            //frm.ShowNavNodes(idTool.LianRuRegionToolNames(toolName));
            frm.ShowNavNodes(idTool.LianRuToolNames(DataType.Region));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_ROILianRu.Text = FrmBianLiang.currentLianRuInfo;
                UIMessageTip.ShowWarning("正在切换区域中，请稍候..");
                idTool.UpdateInput();
                Thread th1 = new Thread(() =>
                {
                    idTool.Run();
                });
                th1.IsBackground = true;
                th1.Start();
            }
        }

        private void ImgBtn_ImgLianRu_Click(object sender, EventArgs e)
        {
            FrmBianLiang frm = new FrmBianLiang(toolName);
            frm.TagString = "图像";
            //frm.ShowNavNodes(idTool.LianRuImgToolNames(toolName));
            frm.ShowNavNodes(idTool.LianRuToolNames(DataType.Image));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_ImgLianRu.Text = FrmBianLiang.currentLianRuInfo;
                UIMessageTip.ShowWarning("正在切换图像源，请稍候..");
                idTool.UpdateInput();
                Thread th1 = new Thread(() =>
                {
                    idTool.Run();
                });
                th1.IsBackground = true;
                th1.Start();
                //更新当前输入项
            }
        }

        private void rad_IsQuYu_Click(object sender, EventArgs e)
        {
            idTool.isQuanTu = !rad_IsQuYu.Checked;
        }

        private void ckb_isVP_Click(object sender, EventArgs e)
        {
            idTool.isVP = ckb_isVP.Checked;
        }

        /// <summary>
        /// 训练当前二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_TrainCode_Click(object sender, EventArgs e)
        {
            //CogIDTool cogIdTool = new CogIDTool();
            //cogIdTool.RunParams.NumToFind = 5;
            //cogIdTool.RunParams.DisableAll1DCodes();
            ////VP解析二维码只允许一次识别同一种二维码，故先下此操作，实际并不严谨，可能是PDF417
            //if (cbx_qrCodeType.Text.Trim() == "Data Matrix ECC 200")
            //{
            //    cogIdTool.RunParams.DataMatrix.Enabled = true;
            //    cogIdTool.RunParams.QRCode.Enabled = false;
            //}
            //else
            //{
            //    cogIdTool.RunParams.DataMatrix.Enabled = false;
            //    cogIdTool.RunParams.QRCode.Enabled = true;
            //}

            //cogIdTool.InputImage = IDTool.HObjectToCogImage8Grey2(((IDTool.ToolPar)idTool.参数).输入.图像);
            ////cogIdTool.RunParams.Train(HObjectToCogImage8Grey2(((ToolPar)参数).输入.图像), null);
            //cogIdTool.Run();

            //ICogRunStatus status = cogIdTool.RunStatus;
            //if (status.Result == CogToolResultConstants.Accept && cogIdTool.Results.Count != 0)
            //{
            //    cogIdTool.RunParams.Untrain();
            //    cogIdTool.RunParams.Train(IDTool.HObjectToCogImage8Grey2(((IDTool.ToolPar)idTool.参数).输入.图像), null);
            //    FuncLib.ShowMessageBox("训练成功", InfoType.Tip);
            //}
            //else
            //{
            //    FuncLib.ShowMessageBox("当前图像未识别到条码信息，训练失败", InfoType.Error);
            //}
        }
    }
}
