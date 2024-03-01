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
using HalconDotNet;
using System.Threading;
using static VM_Pro.CoordTransTool;

namespace VM_Pro
{
    public partial class Frm_OCRTool : UIForm
    {
        public Frm_OCRTool()
        {
            InitializeComponent();
        }


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
        internal static OCRTool ocrTool;
        /// <summary>
        /// 正在抓图的话就放弃再次抓图
        /// </summary>
        private static bool isGrabing = false;

        private static Frm_OCRTool instance;

        internal static Frm_OCRTool Instance
        {
            get
            {
                if (instance == null)
                    instance = new Frm_OCRTool();
                return instance;
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
            ocrTool = (OCRTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;
            Instance.Show();
            Application.DoEvents();
            hasShown = true;

            ocrTool.UpdateInput();

            //显示图像 
            if (((OCRTool.ToolPar)ocrTool.参数).输入.图像 != null)
            {
                Instance.hWindow_Final1.HobjectToHimage(((OCRTool.ToolPar)ocrTool.参数).输入.图像);

                //////更新相应信息
                Instance.tbxLuJing.Text = ocrTool.OCRFilePath;
                if (ocrTool.AllOCRName != null)
                {
                    Frm_OCRTool.Instance.cmbAllOCR.Items.Clear();
                    Frm_OCRTool.Instance.cmbAllOCR.Items.AddRange(ocrTool.AllOCRName);
                    Frm_OCRTool.Instance.cmbAllOCR.Text = Frm_OCRTool.ocrTool.CurOCRName;
                }
                if (ocrTool.templateRegion != null)
                {
                    Frm_OCRTool.Instance.hWindow_Final1.DispObj(ocrTool.templateRegion, "green");
                }
                Instance.tbx_codeRule.Text = ocrTool.codeRule;
                Instance.cbx_charType.Text = ocrTool.BackType.ToString();

                Instance.HuiDuMin.Text = ocrTool.GrayMin.ToString();
                Instance.HuiDuMax.Text = ocrTool.GrayMax.ToString();
                Instance.AreaMin.Text = ocrTool.AreaMin.ToString();
                Instance.AreaMax.Text = ocrTool.AreaMax.ToString();
                Instance.RadGenSuiQuYu.Checked = ocrTool.IsGenSuiQuYu;
                Instance.cbx_searchRegionType.Text = ocrTool.templateRegonType.ToString();
                Application.DoEvents();
            }


        }


        private void 保存toolStripButton1_Click(object sender, EventArgs e)
        {
            Scheme.SaveCur();
            FuncLib.ShowMsg("保存当前方案成功", InfoType.Tip);
        }


        /// <summary>
        /// 隐藏当前窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗体释放前的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_OCRTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

        private void cbx_searchRegionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (openingForm)
            //    return;
            ocrTool.searchRegionType = (RegionType)Enum.Parse(typeof(RegionType), cbx_searchRegionType.Text);

            //RegionType regionType = (RegionType)Enum.Parse(typeof(RegionType), cbx_searchRegionType.Text);
            //if (ocrTool.searchRegionType != regionType)     //区域类型不变的话就不做任何操作
            //{
            //    ocrTool.SwitchSearchRegionType(regionType);
            //    Thread th = new Thread(() =>
            //    {
            //        ocrTool.Run(true);
            //    });
            //    th.IsBackground = true;
            //    th.Start();
            //}
        }

        private void 适应窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hWindow_Final1.DispImageFit();
        }

        private void 图像信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hWindow_Final1.showStatusBar();
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
                    ocrTool.Run();
                    isGrabing = false;
                    Frm_Loading.Instance.Hide();
                });
                th.IsBackground = true;
                th.Start();
            }
        }

        private void btn_drawRectangle1_Click(object sender, EventArgs e)
        {
            ocrTool.DrawTemplateRegion(RegionType.矩形);
        }

        private void btn_drawRectangle2_Click(object sender, EventArgs e)
        {
            ocrTool.DrawTemplateRegion(RegionType.仿射矩形);

        }

        private void btn_drawCircle_Click(object sender, EventArgs e)
        {
            ocrTool.DrawTemplateRegion(RegionType.圆);

        }

        private void btn_drawEllipse_Click(object sender, EventArgs e)
        {
            ocrTool.DrawTemplateRegion(RegionType.椭圆);

        }

        private void btn_drawRing_Click(object sender, EventArgs e)
        {
            ocrTool.DrawTemplateRegion(RegionType.圆环);

        }

        private void btn_drawAny_Click(object sender, EventArgs e)
        {
            ocrTool.DrawTemplateRegion(RegionType.任意);

        }


        private void tbxLuJing_DoubleClick(object sender, EventArgs e)
        {
            ocrTool.SelectDirectoryOCR();
        }

        private void cmbAllOCR_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //string path = Instance.tbxLuJing.Text + "\\" + cmbAllOCR.Text + ".omc";
                string path = "C://Program Files//MVTec//HALCON-20.11-Steady//ocr//" + cmbAllOCR.Text + ".omc";
                HOperatorSet.ReadOcrClassMlp(path, out ocrTool.modelID);
                Frm_OCRTool.ocrTool.CurOCRName = cmbAllOCR.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建字符句柄出现异常：" + ex.ToString());
            }

        }

        private void 复位toolStripButton3_Click(object sender, EventArgs e)
        {
            ocrTool.ResetTool();
        }

        private void cbx_charType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ocrTool.BackType = (CharBackType)Enum.Parse(typeof(CharBackType), cbx_charType.Text);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Frm_OCRTool.Instance.hWindow_Final1.ClearWindow();

            //先确认当前是否有图像，以及图像的是否为灰色
            //判断是否有图像输入
            //显示图像 
            if (((OCRTool.ToolPar)ocrTool.参数).输入.图像 == null)
            {
                Frm_OCRTool.Instance.lstInfo.Items.Add("未检测到当前有图像源输入，请检查！");
                return;
            }
            HTuple ImgChannel;
            //检查当前图像是否为灰度图像
            HOperatorSet.CountChannels(((OCRTool.ToolPar)ocrTool.参数).输入.图像, out ImgChannel);
            if (ImgChannel.D == 3)
            {
                Frm_OCRTool.Instance.lstInfo.Items.Add("检测到当前图像为彩色图像，请先转至灰度图后重试. \r\n");
                return;
            }
            Frm_OCRTool.Instance.lstInfo.Items.Add("当前图像为灰度图，正在处理中... \r\n");
            HObject Region, DaSanRegion, SelectAreaRegion, ShowRegion;

            #region 灰度区域数值选择的处理

            if (Convert.ToInt32(HuiDuMin.Text) > Convert.ToInt32(HuiDuMax.Text))
            {
                Frm_OCRTool.Instance.lstInfo.Items.Add("当前灰度最小值 > 最大值，已置换大小 \r\n");
                string ss = "";
                ss = HuiDuMin.Text;
                HuiDuMin.Text = HuiDuMax.Text;
                HuiDuMax.Text = ss;
            }
            #endregion

            #region 面积数值的处理

            if (Convert.ToInt32(AreaMin.Text) > Convert.ToInt32(AreaMax.Text))
            {
                Frm_OCRTool.Instance.lstInfo.Items.Add("当前面积最小值 > 最大值，已置换大小 \r\n");
                string ss = "";
                ss = AreaMin.Text;
                AreaMin.Text = AreaMax.Text;
                AreaMax.Text = ss;
            }

            #endregion


            ocrTool.GrayMin = Instance.HuiDuMin.Text.ToInt();
            ocrTool.GrayMax = Instance.HuiDuMax.Text.ToInt();
            ocrTool.AreaMin = Instance.AreaMin.Text.ToInt();
            ocrTool.AreaMax = Instance.AreaMax.Text.ToInt();


            //判断下当前选择的是图片还是相应的区域
            if (ocrTool.searchRegionType == RegionType.整幅图像)
            {
                //整幅图像查找
                HOperatorSet.Threshold(((OCRTool.ToolPar)ocrTool.参数).输入.图像, out Region, new HTuple(Convert.ToInt32(HuiDuMin.Text)), Convert.ToInt32(HuiDuMax.Text));
                HOperatorSet.Connection(Region, out DaSanRegion);
                HOperatorSet.SelectShape(DaSanRegion, out SelectAreaRegion, "area", "and", new HTuple(Convert.ToInt32(AreaMin.Text)), new HTuple(Convert.ToInt32(AreaMax.Text)));
                ShowRegion = SelectAreaRegion;
            }
            else
            {
                if (ocrTool.templateRegion == null)
                {
                    Frm_OCRTool.Instance.lstInfo.Items.Add("当前模板区域为空，无法进行细化区域的查找... \r\n");
                    return;
                }
                HObject ImgReduce = null;
                HOperatorSet.ReduceDomain(((OCRTool.ToolPar)ocrTool.参数).输入.图像, ocrTool.templateRegion, out ImgReduce);
                //区域查找
                HOperatorSet.Threshold(ImgReduce, out Region, new HTuple(Convert.ToInt32(HuiDuMin.Text)), new HTuple(Convert.ToInt32(HuiDuMax.Text)));
                HOperatorSet.Connection(Region, out DaSanRegion);
                HOperatorSet.SelectShape(DaSanRegion, out SelectAreaRegion, "area", "and", new HTuple(Convert.ToInt32(AreaMin.Text)), new HTuple(Convert.ToInt32(AreaMax.Text)));
                ShowRegion = SelectAreaRegion;
            }

            HObject InvertImage = null;
            //进行字符识别
            Frm_OCRTool.Instance.hWindow_Final1.DispObj(ShowRegion);
            if (ocrTool.BackType == CharBackType.黑底白字)
            {
                HOperatorSet.InvertImage(((OCRTool.ToolPar)ocrTool.参数).输入.图像, out InvertImage);
            }
            HTuple OCRID, StringResult, confidence;
            HOperatorSet.SortRegion(ShowRegion, out ShowRegion, "first_point", "true", "column");
            HOperatorSet.ReadOcrClassMlp(cmbAllOCR.Text, out OCRID);
            HOperatorSet.DoOcrMultiClassMlp(ShowRegion, InvertImage == null ? ((OCRTool.ToolPar)ocrTool.参数).输入.图像 : InvertImage, OCRID, out StringResult, out confidence);
            Instance.tbxResult.Text = StringResult.ToString();
            Frm_OCRTool.Instance.hWindow_Final1.HobjectToHimage(InvertImage == null ? ((OCRTool.ToolPar)ocrTool.参数).输入.图像 : InvertImage);
            Frm_OCRTool.instance.hWindow_Final1.DispObj(ShowRegion, "green");
            Frm_OCRTool.instance.hWindow_Final1.DispObj(ocrTool.templateRegion, "green");
        }

        private void tbx_codeRule_TextChanged(object sender, EventArgs e)
        {
            ocrTool.codeRule = tbx_codeRule.Text.Trim();
        }

        private void RadGenSuiQuYu_Click(object sender, EventArgs e)
        {
            ocrTool.IsGenSuiQuYu = RadGenSuiQuYu.Checked;
        }

        private void RadQuYu_Click(object sender, EventArgs e)
        {
            ocrTool.IsGenSuiQuYu = !RadQuYu.Checked;

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
    }
}
