using HalconDotNet;
using Sunny.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_FromCamera : UIPage
    {
        public Frm_FromCamera()
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
        private static Frm_FromCamera _instance;
        internal static Frm_FromCamera Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_FromCamera();
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


        private void cbx_cameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            if (imageTool.cameraName != string.Empty && imageTool.cameraName == cbx_cameraList.Text)        //又切换到了自己，不做任何动作
                return;

            imageTool.cameraName = cbx_cameraList.Text;
            imageTool.hardTrig = CCamera.GetCCamera(imageTool.cameraName).hardTrigServer;
            if (!CCamera.FindCamera(imageTool.cameraName).loopGrab && !isGrabing)
            {
                Thread th = new Thread(() =>
                {
                    isGrabing = true;
                    imageTool.Run();
                    isGrabing = false;
                });
                th.IsBackground = true;
                th.Start();

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
                        nud_exposure.SelectText();
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
                Thread th = new Thread(() =>
                {
                    CCamera.FindCamera(imageTool.cameraName).SetAcquisitionMode(0);      //开始连续采集
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
                    HObject image = null;
                    while (CCamera.FindCamera(imageTool.cameraName).loopGrab)
                    {
                        isGrabing = true;
                        sw.Restart();

                        CCamera.FindCamera(imageTool.cameraName).SetGain(((CCamera)Project.FindServiceByName(imageTool.cameraName)).gain, imageTool.cameraName);
                        CCamera.FindCamera(imageTool.cameraName).SetExposure(imageTool.exposure, imageTool.cameraName);
                        CCamera.FindCamera(imageTool.cameraName).SetAcqRegion(((CCamera)Project.FindServiceByName(imageTool.cameraName)).row1, ((CCamera)Project.FindServiceByName(imageTool.cameraName)).col1, ((CCamera)Project.FindServiceByName(imageTool.cameraName)).row2, ((CCamera)Project.FindServiceByName(imageTool.cameraName)).col2, imageTool.cameraName);
                        image = CCamera.FindCamera(imageTool.cameraName).GrabOneImage(imageTool.cameraName);
                        //1.当采集的图像为空时，继续往下操作的话会引发异常
                        if (image == null)
                        {
                            continue;
                        }
                        //旋转图像
                        if (((CCamera)Project.FindServiceByName(imageTool.cameraName)).rotateImage)
                            HOperatorSet.RotateImage(image, out image, -((CCamera)Project.FindServiceByName(imageTool.cameraName)).rotateAngle, "constant");

                        //彩色图像转灰度图像
                        if (((CCamera)Project.FindServiceByName(imageTool.cameraName)).RGBToGray)
                        {
                            HTuple chNum;
                            HOperatorSet.CountChannels(image, out chNum);
                            if (chNum == 3)
                                HOperatorSet.Rgb1ToGray(image, out image);
                        }

                        Frm_ImageTool.Instance.hWindow_Final1.HobjectToHimage(image);

                        //显示十字架
                        HOperatorSet.GetImageSize(image, out width, out height);
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

                    CCamera.FindCamera(imageTool.cameraName).SetAcquisitionMode(1);      //停止连续采集
                    Frm_ImageTool.Instance.hWindow_Final1.HobjectToHimage(image);
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
            if (Frm_ImageTool.openingForm)
                return;

            imageTool.pieceImage = ckb_pieceImage.Checked;
            Frm_PieceImage.Instance.ckb_pieceImage.Checked = ckb_pieceImage.Checked;

            Frm_ImageTool.Instance.pnl_formPanel.Controls.Clear();
            if (!imageTool.pieceImage)
            {
                Instance.TopLevel = false;
                Instance.Parent = Frm_ImageTool.Instance.pnl_formPanel;
                Instance.Dock = DockStyle.Top;
                Instance.Show();
            }
            else
            {
                Frm_PieceImage.Instance.TopLevel = false;
                Frm_PieceImage.Instance.Parent = Frm_ImageTool.Instance.pnl_formPanel;
                Frm_PieceImage.Instance.ckb_hardTrig.Checked = imageTool.hardTrig;
                Frm_PieceImage.Instance.Dock = DockStyle.Top;
                Frm_PieceImage.Instance.Show();
            }
        }
        private void ckb_autoLight_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            imageTool.autoLight = ckb_autoLight.Checked;
            cbx_lightList.Visible = imageTool.autoLight;
        }
        private void cbx_lightList_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageTool.lightToolName = cbx_lightList.Text;
            Task.curTask.FindToolByName(imageTool.lightToolName).Run();
        }
    }
}
