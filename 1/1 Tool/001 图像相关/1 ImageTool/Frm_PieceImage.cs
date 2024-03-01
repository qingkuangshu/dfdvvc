using HalconDotNet;
using Sunny.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_PieceImage : UIForm
    {
        public Frm_PieceImage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 正在抓图的话就放弃再次抓图
        /// </summary>
        private static bool isGrabing = false;
        /// <summary>
        /// 保存图像的路径
        /// </summary>
        private static string savePath = string.Empty;
        /// <summary>
        /// 工具对象
        /// </summary>
        internal static ImageTool imageTool;
        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static Frm_PieceImage _instance;
        internal static Frm_PieceImage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_PieceImage();
                return _instance;
            }
        }


        /// <summary>
        /// 保存图像到本地
        /// </summary>
        internal void SaveImage()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (savePath == string.Empty)
                savePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            if (Frm_ImageTool.Instance.hWindow_Final1.currentImage == null)
            {
                FuncLib.ShowMessageBox("保存失败，请先采集图像");
                return;
            }

            int index;
            for (index = 1; index < 1000; index++)
            {
                if (!File.Exists(savePath + "\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + index.ToString("00") + ".jpg"))
                    break;
            }
            saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + index.ToString("00");
            saveFileDialog.Title = "请选择图像保存路径";
            saveFileDialog.Filter = "图像文件(*.jpg)|*.jpg|图像文件(*.png)|*.png|图像文件(*.PNG)|*.PNG|图像文件(*.bmp)|*.bmp|图像文件(*.tif)|*.tif";
            saveFileDialog.InitialDirectory = savePath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    HOperatorSet.WriteImage(Frm_ImageTool.Instance.hWindow_Final1.currentImage, "jpg", 0, saveFileDialog.FileName);
                    savePath = Path.GetDirectoryName(saveFileDialog.FileName);
                }
                catch
                {
                    FuncLib.ShowMessageBox("图像文件异常或路径不合法", InfoType.Error);
                }
            }
        }


        private void nud_exposure_ValueChanged(double value)
        {
            if (Frm_ImageTool.openingForm)
                return;

            Application.DoEvents();
            imageTool.exposure = (int)value;
            if (CCamera.FindCamera(imageTool.cameraName).loopGrab)
            {
                CCamera.FindCamera(imageTool.cameraName).SetExposure(imageTool.exposure, imageTool.cameraName);
            }
            else
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
                        imageTool.Run();
                        isGrabing = false;
                        Frm_Loading.Instance.Hide();
                        nud_exposureLeftUp.SelectText();
                        Frm_ImageTool.Instance.Activate();
                    });
                    th.IsBackground = true;
                    th.Start();
                }
            }
        }
        private void btn_grabLoop_Click(object sender, EventArgs e)
        {
            if (imageTool.hardTrig)
            {
                UIMessageTip.ShowWarning("当前处于硬触发模式下，不允许进行相机实时操作..");
                return;
            }
            if (!CCamera.FindCamera(imageTool.cameraName).loopGrab)
            {
                btn_grabLoop.Text = "停止实时";
                CCamera.FindCamera(imageTool.cameraName).loopGrab = true;
                CCamera.FindCamera(imageTool.cameraName).loopGrab = true;
                Thread th = new Thread(() =>
                {
                    CCamera.FindCamera(imageTool.camera1Name).SetAcquisitionMode(0);      //开始连续采集
                    CCamera.FindCamera(imageTool.camera2Name).SetAcquisitionMode(0);      //开始连续采集
                    int num = 0;
                    HTuple row1, col1, row2, col2;
                    HOperatorSet.GetPart(Frm_ImageTool.Instance.hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                    HalconLib.DispText(Frm_ImageTool.Instance.hWindow_Final1.HWindowHalconID, "实时中", 15, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "green", "false");

                    //显示十字架
                    HTuple width, height;
                    HObject line1;
                    HObject lien2;
                    if (Frm_ImageTool.Instance.hWindow_Final1.currentImage != null)
                    {
                        HOperatorSet.GetImageSize(Frm_ImageTool.Instance.hWindow_Final1.currentImage, out width, out height);
                        HOperatorSet.GenContourPolygonXld(out line1, new HTuple(height / 2, height / 2), new HTuple(0, width.I));
                        HOperatorSet.GenContourPolygonXld(out lien2, new HTuple(0, height.I), new HTuple(width / 2, width / 2));
                        Frm_ImageTool.Instance.hWindow_Final1.DispObj(line1, "green");
                        Frm_ImageTool.Instance.hWindow_Final1.DispObj(lien2, "green");
                    }
                    Application.DoEvents();

                    Stopwatch sw = new Stopwatch();
                    HObject image1 = null;
                    HObject image2 = null;
                    HObject imageTotal = null;
                    while (CCamera.FindCamera(imageTool.camera1Name).loopGrab)
                    {
                        isGrabing = true;
                        sw.Restart();

                        CCamera.FindCamera(imageTool.camera1Name).SetGain(((CCamera)Project.FindServiceByName(imageTool.camera1Name)).gain, imageTool.camera1Name);
                        CCamera.FindCamera(imageTool.camera1Name).SetExposure(imageTool.exposure, imageTool.camera1Name);
                        CCamera.FindCamera(imageTool.camera1Name).SetAcqRegion(((CCamera)Project.FindServiceByName(imageTool.camera1Name)).row1, ((CCamera)Project.FindServiceByName(imageTool.camera1Name)).col1, ((CCamera)Project.FindServiceByName(imageTool.camera1Name)).row2, ((CCamera)Project.FindServiceByName(imageTool.camera1Name)).col2, imageTool.camera1Name);
                        image1 = CCamera.FindCamera(imageTool.camera1Name).GrabOneImage(imageTool.camera1Name);

                        CCamera.FindCamera(imageTool.camera2Name).SetGain(((CCamera)Project.FindServiceByName(imageTool.camera2Name)).gain, imageTool.camera2Name);
                        CCamera.FindCamera(imageTool.camera2Name).SetExposure(imageTool.exposure, imageTool.camera2Name);
                        CCamera.FindCamera(imageTool.camera2Name).SetAcqRegion(((CCamera)Project.FindServiceByName(imageTool.camera2Name)).row1, ((CCamera)Project.FindServiceByName(imageTool.camera2Name)).col1, ((CCamera)Project.FindServiceByName(imageTool.camera2Name)).row2, ((CCamera)Project.FindServiceByName(imageTool.camera2Name)).col2, imageTool.camera2Name);
                        image2 = CCamera.FindCamera(imageTool.camera2Name).GrabOneImage(imageTool.camera2Name);

                        //旋转图像
                        if (((CCamera)Project.FindServiceByName(imageTool.camera1Name)).rotateImage)
                            HOperatorSet.RotateImage(image1, out image1, -((CCamera)Project.FindServiceByName(imageTool.camera1Name)).rotateAngle, "constant");

                        //旋转图像
                        if (((CCamera)Project.FindServiceByName(imageTool.camera2Name)).rotateImage)
                            HOperatorSet.RotateImage(image2, out image2, -((CCamera)Project.FindServiceByName(imageTool.camera2Name)).rotateAngle, "constant");

                        //彩色图像转灰度图像
                        if (((CCamera)Project.FindServiceByName(imageTool.camera1Name)).RGBToGray)
                        {
                            HTuple chNum;
                            HOperatorSet.CountChannels(image1, out chNum);
                            if (chNum == 3)
                                HOperatorSet.Rgb1ToGray(image1, out image1);
                        }

                        //彩色图像转灰度图像
                        if (((CCamera)Project.FindServiceByName(imageTool.camera2Name)).RGBToGray)
                        {
                            HTuple chNum;
                            HOperatorSet.CountChannels(image2, out chNum);
                            if (chNum == 3)
                                HOperatorSet.Rgb1ToGray(image2, out image2);
                        }

                        imageTotal = ImageTool.PieceImage(image1, image2, (int)PieceType.TwoImageLR);

                        Frm_ImageTool.Instance.hWindow_Final1.HobjectToHimage(imageTotal);

                        //显示十字架
                        HOperatorSet.GetImageSize(imageTotal, out width, out height);
                        HOperatorSet.GenContourPolygonXld(out line1, new HTuple(height / 2, height / 2), new HTuple(0, width.I));
                        HOperatorSet.GenContourPolygonXld(out lien2, new HTuple(0, height.I), new HTuple(width / 2, width / 2));
                        Frm_ImageTool.Instance.hWindow_Final1.DispObj(line1, "green");
                        Frm_ImageTool.Instance.hWindow_Final1.DispObj(lien2, "green");
                        Application.DoEvents();

                        if (num % 2 == 0 && CCamera.FindCamera(imageTool.cameraName).loopGrab)
                        {
                            HOperatorSet.GetPart(Frm_ImageTool.Instance.hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                            HalconLib.DispText(Frm_ImageTool.Instance.hWindow_Final1.HWindowHalconID, "实时中", 15, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "green", "false");
                            Application.DoEvents();
                        }

                        num++;
                        sw.Stop();
                        Frm_ImageTool.Instance.lbl_runTime.Text = sw.ElapsedMilliseconds + " ms";
                        isGrabing = false;
                        Application.DoEvents();
                        Thread.Sleep(20);
                    }

                    CCamera.FindCamera(imageTool.camera1Name).SetAcquisitionMode(1);      //停止连续采集
                    CCamera.FindCamera(imageTool.camera2Name).SetAcquisitionMode(1);      //停止连续采集
                    Frm_ImageTool.Instance.hWindow_Final1.HobjectToHimage(imageTotal);
                    Frm_ImageTool.Instance.lbl_runTime.Text = sw.ElapsedMilliseconds + " ms";

                    btn_grabLoop.Text = "开始实时";
                });
                th.IsBackground = true;
                th.Start();
            }
            else
            {
                CCamera.FindCamera(imageTool.cameraName).loopGrab = false;
            }
        }
        private void btn_saveImage_Click(object sender, EventArgs e)
        {
            SaveImage();
        }
        private void ckb_hardTrig_CheckedChanged(object sender, EventArgs e)
        {
            imageTool.hardTrig = ckb_hardTrig.Checked;
        }
        private void ckb_pieceImage_Click(object sender, EventArgs e)
        {
            imageTool.pieceImage = ckb_pieceImage.Checked;
            Frm_FromCamera.Instance.ckb_pieceImage.Checked = ckb_pieceImage.Checked;

            Frm_ImageTool.Instance.pnl_formPanel.Controls.Clear();
            if (!imageTool.pieceImage)
            {
                Frm_FromCamera.Instance.TopLevel = false;
                Frm_FromCamera.Instance.Parent = Frm_ImageTool.Instance.pnl_formPanel;
                Frm_FromCamera.Instance.Dock = DockStyle.Top;
                Frm_FromCamera.Instance.Show();
            }
            else
            {
                Instance.TopLevel = false;
                Instance.Parent = Frm_ImageTool.Instance.pnl_formPanel;
                Instance.Dock = DockStyle.Top;
                Instance.Show();
            }
        }

        private void cbx_pieceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            imageTool.pieceType = (PieceType)cbx_pieceType.SelectedIndex;
            switch (imageTool.pieceType)
            {
                case PieceType.TwoImageLR:
                    label4.Visible = false;
                    label5.Visible = false;
                    cbx_leftDown.Visible = false;
                    cbx_rightDown.Visible = false;
                    nud_exposureLeftDown.Visible = false;
                    nud_exposureRightDown.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label2.Text = "左侧相机";
                    label3.Text = "右侧相机";
                    break;

                case PieceType.TwoImageUD:
                    label4.Visible = false;
                    label5.Visible = false;
                    cbx_leftDown.Visible = false;
                    cbx_rightDown.Visible = false;
                    nud_exposureLeftDown.Visible = false;
                    nud_exposureRightDown.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label2.Text = "上侧相机";
                    label3.Text = "下侧相机";
                    break;

                case PieceType.ForeImage:
                    label4.Visible = true;
                    label5.Visible = true;
                    cbx_leftDown.Visible = true;
                    cbx_rightDown.Visible = true;
                    nud_exposureLeftDown.Visible = true;
                    nud_exposureRightDown.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label2.Text = "左上相机";
                    label3.Text = "右上相机";
                    break;
            }
        }

        private void cbx_leftUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageTool.camera1Name = cbx_leftUp.Text;
        }
        private void cbx_rightUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageTool.camera2Name = cbx_rightUp.Text;
        }
        private void cbx_leftDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageTool.camera3Name = cbx_leftDown.Text;
        }
        private void cbx_rightDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageTool.camera4Name = cbx_rightDown.Text;
        }

        private void nud_exposureLeftUp_ValueChanged(double value)
        {
            imageTool.exposure1 = (int)value;
        }
        private void nud_exposureRightUp_ValueChanged(double value)
        {
            imageTool.exposure2 = (int)value;
        }
        private void nud_exposureLeftDown_ValueChanged(double value)
        {
            imageTool.exposure3 = (int)value;
        }
        private void nud_exposureRightDown_ValueChanged(double value)
        {
            imageTool.exposure4 = (int)value;
        }

    }
}
