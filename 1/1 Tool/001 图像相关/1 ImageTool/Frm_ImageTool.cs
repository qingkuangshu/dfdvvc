using HalconDotNet;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_ImageTool : UIForm
    {
        public Frm_ImageTool()
        {
            InitializeComponent();
            hWindow_Final1.hWindowControl.MouseUp += Hwindow_MouseUp;
        }

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
        internal static ImageTool imageTool;
        /// <summary>
        /// 图像显示区域
        /// </summary>
        internal static List<ViewWindow.Model.ROI> L_regions = new List<ViewWindow.Model.ROI>();
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_ImageTool _instance;
        internal static Frm_ImageTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_ImageTool();
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
            imageTool = (ImageTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;
            imageTool.UpdateInput();
            Frm_FromCamera.imageTool = imageTool;
            Frm_FromFile.acqImageTool = imageTool;
            Frm_FromDirectory.acqImageTool = imageTool;
            Frm_PieceImage.imageTool = imageTool;
            try
            {
                Instance.Show();

            }
            catch (Exception)
            {
                Instance.Close();
                _instance = null;
                UIMessageTip.ShowError("打开异常，请稍后重试...");
                return;
            }
            Instance.WindowState = FormWindowState.Normal;
            Instance.Text = string.Format("{0}    [ {1} . {2} ]", toolBase.toolType, toolBase.taskName, toolBase.toolName);
            Application.DoEvents();
            hasShown = true;

            switch (imageTool.imageSource)
            {
                case ImageSource.FromCamera:
                    Frm_ImageTool.Instance.rdo_fromCamera.Checked = true;
                    break;
                case ImageSource.FromFile:
                    Frm_ImageTool.Instance.rdo_fromFile.Checked = true;
                    break;
                case ImageSource.FromDirectory:
                    Frm_ImageTool.Instance.rdo_fromDirectory.Checked = true;
                    break;
            }

            //当前图像显示
            if (((ImageTool.ToolPar)imageTool.参数).输出.图像 == null)
                Instance.hWindow_Final1.ClearWindow();
            else
                Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)(imageTool.参数)).输出.图像);

            if (imageTool.dispPartImage)
            {
                Instance.hWindow_Final1.viewWindow.displayROI(imageTool.L_regions);
                L_regions = imageTool.L_regions;
            }

            imageTool.SwitchImageSource(imageTool.imageSource);

            //如未指定相机，则自动指定第一个相机
            if (imageTool.cameraName == string.Empty)
            {
                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                    {
                        imageTool.cameraName = Project.Instance.L_Service[i].name;
                        imageTool.hardTrig = CCamera.GetCCamera(imageTool.cameraName).hardTrigServer;
                        Frm_FromCamera.Instance.cbx_cameraList.Text = imageTool.cameraName;
                        if (imageTool.imageSource == ImageSource.FromCamera)
                        {
                            Thread th = new Thread(() =>
                            {
                                imageTool.Run(true);
                            });
                            th.IsBackground = true;
                            th.Start();
                        }
                        break;
                    }
                }
            }
            if (imageTool.cameraName == string.Empty)
            {
                Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                Frm_ImageTool.Instance.lbl_toolTip.Text = "未指定相机";
            }

            //刷新相机列表
            Frm_FromCamera.Instance.cbx_cameraList.Items.Clear();
            Frm_PieceImage.Instance.cbx_leftUp.Items.Clear();
            Frm_PieceImage.Instance.cbx_rightUp.Items.Clear();
            Frm_PieceImage.Instance.cbx_leftDown.Items.Clear();
            Frm_PieceImage.Instance.cbx_rightDown.Items.Clear();
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                {
                    Frm_FromCamera.Instance.cbx_cameraList.Items.Add(Project.Instance.L_Service[i].name);
                    Frm_PieceImage.Instance.cbx_leftUp.Items.Add(Project.Instance.L_Service[i].name);
                    Frm_PieceImage.Instance.cbx_rightUp.Items.Add(Project.Instance.L_Service[i].name);
                    Frm_PieceImage.Instance.cbx_leftDown.Items.Add(Project.Instance.L_Service[i].name);
                    Frm_PieceImage.Instance.cbx_rightDown.Items.Add(Project.Instance.L_Service[i].name);
                }
            }

            if (imageTool.cameraName != null)
                Frm_FromCamera.Instance.cbx_cameraList.Text = imageTool.cameraName;

            Instance.ckb_taskFailKeepRun.Checked = imageTool.taskFailKeepRun;

            Frm_FromCamera.Instance.nud_exposure.Value = imageTool.exposure;
            Instance.textBox1.Text = imageTool.subPixel.ToString();

            Frm_FromCamera.Instance.cbx_lightList.Visible = imageTool.autoLight;

            Instance.ckb_dispPartImage.Checked = imageTool.dispPartImage;
            Frm_FromFile.Instance.ckb_absPath.Checked = imageTool.absPath;
            Frm_FromFile.Instance.ckb_rotateImage.Checked = imageTool.rotateImageForLocal;
            Frm_FromFile.Instance.nud_rotateAngle.Value = imageTool.rotateAngleForLocal;
            Frm_FromDirectory.Instance.ckb_absPath.Checked = imageTool.absPath;
            Frm_FromDirectory.Instance.ckb_rotateImage.Checked = imageTool.rotateImageForLocal;
            Frm_FromDirectory.Instance.nud_rotateAngle.Value = imageTool.rotateAngleForLocal;
            Frm_FromCamera.Instance.ckb_hardTrig.Checked = imageTool.hardTrig;
            Frm_FromCamera.Instance.ckb_pieceImage.Checked = imageTool.pieceImage;
            Frm_PieceImage.Instance.ckb_pieceImage.Checked = imageTool.pieceImage;
            Frm_FromCamera.Instance.nud_exposure.Incremeent = (decimal)Math.Ceiling(Frm_FromCamera.Instance.nud_exposure.Value / 10);
            Frm_PieceImage.Instance.cbx_pieceType.SelectedIndex = (int)imageTool.pieceType;
            Frm_PieceImage.Instance.cbx_leftUp.Text = imageTool.camera1Name;
            Frm_PieceImage.Instance.cbx_rightUp.Text = imageTool.camera2Name;
            Frm_PieceImage.Instance.cbx_leftDown.Text = imageTool.camera3Name;
            Frm_PieceImage.Instance.cbx_rightDown.Text = imageTool.camera4Name;
            Frm_PieceImage.Instance.nud_exposureLeftUp.Value = imageTool.exposure1;
            Frm_PieceImage.Instance.nud_exposureRightUp.Value = imageTool.exposure2;
            Frm_PieceImage.Instance.nud_exposureLeftDown.Value = imageTool.exposure3;
            Frm_PieceImage.Instance.nud_exposureRightDown.Value = imageTool.exposure4;

            Frm_FromFile.Instance.tbx_imagePath.Text = imageTool.imagePath;
            Frm_FromDirectory.Instance.tbx_imageDirectoryPath.Text = imageTool.imageDirectoryPath;

            //if (imageTool.IsFenBianLv)
            //{
            //    Instance.ckb_FenBianLv.Checked = true;
            //    Instance.ckb_FenBianLv.Visible = true;
            //    Instance.txt_ImgWidth.Text = imageTool.FenBianLv_ImgWidth.ToString();
            //    Instance.txt_ImgHeight.Text = imageTool.FenBianLv_Imgheight.ToString();
            //}
            //else
            //{
            //    Instance.ckb_FenBianLv.Checked = Instance.panel_FenBianLv.Visible = false;
            //}


            //自动开灯
            Frm_FromCamera.Instance.ckb_autoLight.Checked = imageTool.autoLight;
            Frm_FromCamera.Instance.cbx_lightList.Visible = imageTool.autoLight;
            if (imageTool.imageSource == ImageSource.FromCamera)
            {
                Frm_FromCamera.Instance.cbx_lightList.Items.Clear();
                for (int i = 0; i < Task.FindTaskByName(taskName).L_toolList.Count; i++)
                {
                    if (Task.FindTaskByName(taskName).L_toolList[i].toolType == ToolType.光源控制)
                    {
                        Frm_FromCamera.Instance.cbx_lightList.Items.Add(Task.FindTaskByName(taskName).L_toolList[i].toolName);
                    }
                }
            }
            Frm_FromCamera.Instance.cbx_lightList.Text = imageTool.lightToolName;
            if (imageTool.autoLight && imageTool.lightToolName != null && imageTool.lightToolName != string.Empty)
            {
                ////// Task.curTask.FindToolByName(imageTool.lightToolName).Run();
                //////if (taskName == "玻璃片  左侧Mark")
                //////    FuncLib.SetDo(Do.上光源_C1Out15, OnOff.On);
                //////else
                //////    FuncLib.SetDo(Do.下光源_C1Out16, OnOff.On);
            }

            switch (imageTool.pieceType)
            {
                case PieceType.TwoImageLR:
                    Frm_PieceImage.Instance.label4.Visible = false;
                    Frm_PieceImage.Instance.label5.Visible = false;
                    Frm_PieceImage.Instance.cbx_leftDown.Visible = false;
                    Frm_PieceImage.Instance.cbx_rightDown.Visible = false;
                    Frm_PieceImage.Instance.nud_exposureLeftDown.Visible = false;
                    Frm_PieceImage.Instance.nud_exposureRightDown.Visible = false;
                    Frm_PieceImage.Instance.label7.Visible = false;
                    Frm_PieceImage.Instance.label8.Visible = false;
                    Frm_PieceImage.Instance.label2.Text = "左侧相机";
                    Frm_PieceImage.Instance.label3.Text = "右侧相机";
                    break;

                case PieceType.TwoImageUD:
                    Frm_PieceImage.Instance.label4.Visible = false;
                    Frm_PieceImage.Instance.label5.Visible = false;
                    Frm_PieceImage.Instance.cbx_leftDown.Visible = false;
                    Frm_PieceImage.Instance.cbx_rightDown.Visible = false;
                    Frm_PieceImage.Instance.nud_exposureLeftDown.Visible = false;
                    Frm_PieceImage.Instance.nud_exposureRightDown.Visible = false;
                    Frm_PieceImage.Instance.label7.Visible = false;
                    Frm_PieceImage.Instance.label8.Visible = false;
                    Frm_PieceImage.Instance.label2.Text = "上侧相机";
                    Frm_PieceImage.Instance.label3.Text = "下侧相机";
                    break;

                case PieceType.ForeImage:
                    Frm_PieceImage.Instance.label4.Visible = true;
                    Frm_PieceImage.Instance.label5.Visible = true;
                    Frm_PieceImage.Instance.cbx_leftDown.Visible = true;
                    Frm_PieceImage.Instance.cbx_rightDown.Visible = true;
                    Frm_PieceImage.Instance.nud_exposureLeftDown.Visible = true;
                    Frm_PieceImage.Instance.nud_exposureRightDown.Visible = true;
                    Frm_PieceImage.Instance.label7.Visible = true;
                    Frm_PieceImage.Instance.label8.Visible = true;
                    Frm_PieceImage.Instance.label2.Text = "左上相机";
                    Frm_PieceImage.Instance.label3.Text = "右上相机";
                    break;
            }

            if (imageTool.imageSource == ImageSource.FromDirectory)
                imageTool.currentImageIndex--;

            Thread th1 = new Thread(() =>
            {
                imageTool.Run();
            });
            th1.IsBackground = true;
            th1.Start();
            Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)imageTool.参数).输出.图像);

            //功能启用
            if (!Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                Instance.ckb_dispPartImage.Visible = false;
                Frm_FromCamera.Instance.ckb_hardTrig.Visible = false;
                Frm_FromCamera.Instance.ckb_pieceImage.Visible = false;
                Frm_FromDirectory.Instance.ckb_absPath.Visible = false;
                Frm_FromDirectory.Instance.ckb_rotateImage.Visible = false;
                Frm_FromDirectory.Instance.nud_rotateAngle.Visible = false;
                Frm_FromFile.Instance.ckb_absPath.Visible = false;
                Frm_FromFile.Instance.ckb_rotateImage.Visible = false;
                Frm_FromFile.Instance.nud_rotateAngle.Visible = false;
            }
            else
            {
                Instance.ckb_dispPartImage.Visible = true;
                Frm_FromCamera.Instance.ckb_hardTrig.Visible = true;
                Frm_FromCamera.Instance.ckb_pieceImage.Visible = true;
                Frm_FromDirectory.Instance.ckb_absPath.Visible = true;
                Frm_FromDirectory.Instance.ckb_rotateImage.Visible = true;
                Frm_FromDirectory.Instance.nud_rotateAngle.Visible = true;
                Frm_FromFile.Instance.ckb_absPath.Visible = true;
                Frm_FromFile.Instance.ckb_rotateImage.Visible = true;
                Frm_FromFile.Instance.nud_rotateAngle.Visible = true;
            }

            Instance.Activate();
            Instance.btn_runTool.Focus();
            openingForm = false;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData & Keys.Control) == Keys.Control)
            {
                if ((keyData & Keys.S) == Keys.S)       //保存图像
                {
                    imageTool.SaveImage();
                }
            }
            else
            {
                if (keyData == Keys.F5)         //工具运行一次
                {
                    Thread th = new Thread(() =>
                    {
                        imageTool.Run();
                    });
                    th.IsBackground = true;
                    th.Start();
                }
                else if (keyData == Keys.Up)        //曝光时间增加
                {
                    if (imageTool.imageSource == ImageSource.FromCamera)
                        Frm_FromCamera.Instance.nud_exposure.Value += 100;
                }
                else if (keyData == Keys.Down)        //曝光时间减小
                {
                    if (imageTool.imageSource == ImageSource.FromCamera)
                        Frm_FromCamera.Instance.nud_exposure.Value -= 100;
                }
                else if (keyData == Keys.Enter)        //让参数生效
                {
                    try
                    {
                        this.Focus();
                        if (Frm_FromCamera.Instance.Visible)
                            Frm_FromCamera.Instance.nud_exposure.SelectText();
                    }
                    catch { }
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            return true;
        }
        private void Hwindow_MouseUp(object sender, MouseEventArgs e)
        {
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
            imageTool.ResetTool();
        }
        private void 适应窗体toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hWindow_Final1.DispImageFit();
        }
        private void 图像信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hWindow_Final1.showStatusBar();
        }
        private void Frm_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            //退出窗体时自动停止相机实时
            try
            {
                if (CCamera.FindCamera(imageTool.cameraName).loopGrab)
                {
                    CCamera.FindCamera(imageTool.cameraName).loopGrab = false;
                }
            }
            catch { }       //相机未创建时会报错

            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

        private void rdo_fromCamera_CheckedChanged(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            if (rdo_fromCamera.Checked)
            {
                imageTool.SwitchImageSource(ImageSource.FromCamera);
                Thread th = new Thread(() =>
                {
                    imageTool.Run();
                });
                th.IsBackground = true;
                th.Start();
            }
        }
        private void rdo_fromFile_CheckedChanged(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            //退出窗体时自动停止相机实时
            try
            {
                if (CCamera.FindCamera(imageTool.cameraName).loopGrab)
                    CCamera.FindCamera(imageTool.cameraName).loopGrab = false;
            }
            catch { }       //相机未创建时会报错

            if (rdo_fromFile.Checked)
            {
                imageTool.SwitchImageSource(ImageSource.FromFile);
                Thread th = new Thread(() =>
                {
                    imageTool.Run();
                });
                th.IsBackground = true;
                th.Start();
            }
        }
        private void rdo_fromDirectory_CheckedChanged(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            //退出窗体时自动停止相机实时
            try
            {
                if (CCamera.FindCamera(imageTool.cameraName).loopGrab)
                    CCamera.FindCamera(imageTool.cameraName).loopGrab = false;
            }
            catch { }       //相机未创建时会报错

            if (rdo_fromDirectory.Checked)
            {
                imageTool.SwitchImageSource(ImageSource.FromDirectory);
                Thread th = new Thread(() =>
                {
                    imageTool.Run();
                });
                th.IsBackground = true;
                th.Start();
            }
        }

        private void ckb_dispPartImage_CheckedChanged(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            imageTool.dispPartImage = ckb_dispPartImage.Checked;
            if (imageTool.dispPartImage && ((ImageTool.ToolPar)imageTool.参数).输出.图像 != null)
            {
                if (imageTool.L_regions.Count == 0)
                {
                    HTuple width, height;
                    HOperatorSet.GetImageSize(((ImageTool.ToolPar)imageTool.参数).输出.图像, out width, out height);
                    hWindow_Final1.viewWindow.genRect1(height * 0.25, width * 0.25, height * 0.75, width * 0.75, ref imageTool.L_regions);
                }
                else
                {
                    Frm_ImageTool.Instance.hWindow_Final1.viewWindow.displayROI(imageTool.L_regions);
                }
                L_regions = imageTool.L_regions;
            }
            else
            {
                hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)imageTool.参数).输出.图像);
            }
        }

        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            imageTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
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
                        Frm_Loading.Instance.Show();
                    }));

                    isGrabing = true;
                    imageTool.Run();
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
        private void Frm_ImageTool_ExtendBoxClick(object sender, EventArgs e)
        {
            Instance.TopMost = !Instance.TopMost;

            if (Instance.TopMost)
                Instance.ExtendSymbol = 61475;
            else
                Instance.ExtendSymbol = 61758;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            imageTool.subPixel = Convert.ToInt16(textBox1.Text.Trim());
        }

    }
}
