using HalconDotNet;
using Sunny.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_Camera : Form
    {
        public Frm_Camera()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 正在加载窗体
        /// </summary>
        internal static bool isLoading = false;
        /// <summary>
        /// 正在抓图的话就放弃再次抓图
        /// </summary>
        internal static bool isGrabing = false;
        /// <summary>
        /// 保存图像的路径
        /// </summary>
        private static string savePath = string.Empty;
        /// <summary>
        /// 指示当前是否正在等待绘制
        /// </summary>
        internal static bool waitDraw = false;
        /// <summary>
        /// 相机实例
        /// </summary>
        internal static CCamera m_ccamera = null;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Camera _instance;
        internal static Frm_Camera Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Camera();
                return _instance;
            }
        }


        /// <summary>
        /// 显示参数到界面
        /// </summary>
        /// <param name="tcpClient"></param>
        internal static void ShowPar(ServiceBase serviceBase)
        {
            isLoading = true;   //把当前状态赋为加载状态
            Instance.btn_grabOne.Focus();   //给采集一张按钮聚焦
            Application.DoEvents();

            if (Frm_Service.curForm != CurForm.Camera)  //显示相机服务界面
            {
                Frm_Service.curForm = CurForm.Camera;

                Frm_Service.Instance.pnl_seviceBox.Controls.Clear();
                Instance.TopLevel = false;
                Instance.Parent = Frm_Service.Instance.pnl_seviceBox;
                Instance.Dock = DockStyle.Fill;
                Instance.Show();
            }

            m_ccamera = (CCamera)serviceBase;

            //设置当前相机连接状态
            if (m_ccamera.Connected)
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "已连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
            }
            else
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "未连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
            }


            //1.该服务对象是刚创建的，没有绑定相机的sn，当目前有枚举相机时，默认绑定第一个相机
            if (m_ccamera.cameraInfoStr == string.Empty && Instance.cbx_cameraList.Items.Count > 0)
                m_ccamera.cameraInfoStr = Instance.cbx_cameraList.Items[0].ToString();

            if (m_ccamera.cameraInfoStr != string.Empty && m_ccamera.Connected && !isGrabing && !m_ccamera.hardTrigServer)
            {
                Thread th = new Thread(() =>
                {
                    lock (m_ccamera.obj)
                    {

                        isGrabing = true;
                        m_ccamera.GetCurCamera().SetExposure(m_ccamera.exposure, m_ccamera.name);
                        m_ccamera.GetCurCamera().SetGain(m_ccamera.gain, m_ccamera.name);
                        m_ccamera.GetCurCamera().SetAcqRegion(m_ccamera.row1, m_ccamera.col1, m_ccamera.row2, m_ccamera.col2, m_ccamera.name);
                        HObject image = m_ccamera.GetCurCamera().GrabOneImage(m_ccamera.name);

                        //旋转图像
                        if (m_ccamera.rotateImage)
                            HOperatorSet.RotateImage(image, out image, -m_ccamera.rotateAngle, "constant");

                        //彩色图像转灰度图像
                        if (m_ccamera.RGBToGray && image != null)
                        {
                            HTuple chNum;
                            HOperatorSet.CountChannels(image, out chNum);
                            if (chNum == 3)
                                HOperatorSet.Rgb1ToGray(image, out image);
                        }
                        Instance.hWindow_Final1.HobjectToHimage(image);
                        isGrabing = false;
                    }
                });
                th.IsBackground = true;
                th.Start();
            }

            Instance.cbx_cameraList.Text = m_ccamera.cameraInfoStr;
            Instance.nud_exposure.Value = m_ccamera.exposure;
            Instance.nud_exposure.Incremeent = (decimal)Math.Ceiling((Instance.nud_exposure.Value / 10.0));
            if (Instance.nud_exposure.Incremeent < 1)
                Instance.nud_exposure.Incremeent = 1;

            if (Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                Instance.cbx_cameraList.Enabled = true;
                Instance.btn_movePar.Enabled = true;
            }
            else
            {
                Instance.cbx_cameraList.Enabled = false;
                Instance.btn_movePar.Enabled = false;
            }

            isLoading = false;
        }
        /// <summary>
        /// 保存图像到本地
        /// </summary>
        internal void SaveImage()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (savePath == string.Empty)
                savePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            if (hWindow_Final1.currentImage == null)
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
                    HOperatorSet.WriteImage(hWindow_Final1.currentImage, "jpg", 0, saveFileDialog.FileName);
                    savePath = Path.GetDirectoryName(saveFileDialog.FileName);
                }
                catch
                {
                    FuncLib.ShowMessageBox("图像文件异常或路径不合法", InfoType.Error);
                }
            }
        }
        /// <summary>
        /// 绘制自动聚焦时的ROI区域
        /// </summary>
        internal void DrawROIRegion(HObject image)
        {
            if (image == null)
                return;

            waitDraw = true;
            HTuple width, height;
            HOperatorSet.GetImageSize(image, out width, out height);
            HalconLib.DispText(hWindow_Final1.HWindowHalconID, "请在图像窗口指定要对焦的目标面，鼠标右击结束绘制", 14, 20, 220, "blue", "false");
            if (m_ccamera.rowFocus.D == 0 && m_ccamera.colFocus.D == 0)     //第一次绘制
            {
                m_ccamera.rowFocus = height / 2;
                m_ccamera.colFocus = width / 2;
                m_ccamera.phiFocus = 0;
                m_ccamera.length1Focus = height / 8;
                m_ccamera.length2Focus = width / 12;
            }
            hWindow_Final1.ContextMenuStrip = null;
            hWindow_Final1.DrawModel = true;
            HOperatorSet.SetColor(hWindow_Final1.HWindowHalconID, "green");
            hWindow_Final1.Select();
            HOperatorSet.DrawRectangle2Mod(hWindow_Final1.HWindowHalconID, m_ccamera.rowFocus, m_ccamera.colFocus, m_ccamera.phiFocus, m_ccamera.length1Focus, m_ccamera.length2Focus, out m_ccamera.rowFocus, out m_ccamera.colFocus, out m_ccamera.phiFocus, out m_ccamera.length1Focus, out m_ccamera.length2Focus);
            HObject rect2;
            HOperatorSet.GenRectangle2(out rect2, m_ccamera.rowFocus, m_ccamera.colFocus, m_ccamera.phiFocus, m_ccamera.length1Focus, m_ccamera.length2Focus);
            hWindow_Final1.DispObj(rect2, "blue");
            hWindow_Final1.DrawModel = false;
            hWindow_Final1.ContextMenuStrip = uiContextMenuStrip1;
            waitDraw = false;
        }


        private void cbx_cameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (m_ccamera.cameraInfoStr != string.Empty && m_ccamera.cameraInfoStr != cbx_cameraList.Text && !isGrabing)
            {
                m_ccamera.cameraInfoStr = cbx_cameraList.Text.Trim();
                if (m_ccamera.GetCurCamera() == null)
                {
                    return;
                }
                Thread th = new Thread(() =>
                {
                    lock (m_ccamera.obj)
                    {
                        isGrabing = true;
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        
                        m_ccamera.GetCurCamera().SetGain(m_ccamera.gain, m_ccamera.name);
                        m_ccamera.GetCurCamera().SetExposure(m_ccamera.exposure, m_ccamera.name);
                        m_ccamera.GetCurCamera().SetAcqRegion(m_ccamera.row1, m_ccamera.col1, m_ccamera.row2, m_ccamera.col2, m_ccamera.name);
                        HObject image = m_ccamera.GetCurCamera().GrabOneImage(m_ccamera.name);

                        //旋转图像
                        if (image != null)
                        {
                            if (m_ccamera.rotateImage)
                                HOperatorSet.RotateImage(image, out image, -m_ccamera.rotateAngle, "constant");

                            //彩色图像转灰度图像
                            if (m_ccamera.RGBToGray)
                            {
                                HTuple chNum;
                                HOperatorSet.CountChannels(image, out chNum);
                                if (chNum == 3)
                                    HOperatorSet.Rgb1ToGray(image, out image);
                            }
                            hWindow_Final1.HobjectToHimage(image);
                        }

                        sw.Stop();
                        lbl_elapsedTime.Text = sw.ElapsedMilliseconds + " ms";
                        isGrabing = false;
                    }
                });
                th.IsBackground = true;
                th.Start();
            }

            FuncLib.ShowMsg(string.Format("参数变更！服务项 [ {0} ] 相机选择变更，变更前：{1}    变更后：{2}", m_ccamera.name, m_ccamera.cameraInfoStr, cbx_cameraList.Text));
            m_ccamera.cameraInfoStr = cbx_cameraList.Text;

            Instance.btn_grabOne.Enabled = true;
            Instance.btn_grabLoop.Enabled = true;
            Instance.btn_movePar.Enabled = true;
            Instance.btn_saveImage.Enabled = true;
            Instance.btn_focus.Enabled = true;
        }
        private void nud_exposure_ValueChanged(double value)
        {
            if (isLoading || m_ccamera.GetCurCamera() == null)
                return;

            m_ccamera.exposure = (int)value;
            m_ccamera.GetCurCamera().SetExposure(m_ccamera.exposure, m_ccamera.name);
            nud_exposure.SelectText();

            if (m_ccamera.cameraInfoStr != string.Empty && !isGrabing && !m_ccamera.hardTrigServer)
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
                    lock (m_ccamera.obj)
                    {
                        isGrabing = true;
                        Stopwatch sw = new Stopwatch();
                        sw.Start();

                        m_ccamera.GetCurCamera().SetGain(m_ccamera.gain, m_ccamera.name);
                        m_ccamera.GetCurCamera().SetAcqRegion(m_ccamera.row1, m_ccamera.col1, m_ccamera.row2, m_ccamera.col2, m_ccamera.name);
                        HObject image = m_ccamera.GetCurCamera().GrabOneImage(m_ccamera.name);

                        if (image != null)
                        {
                            //旋转图像
                            if (m_ccamera.rotateImage)
                                HOperatorSet.RotateImage(image, out image, -m_ccamera.rotateAngle, "constant");

                            //彩色图像转灰度图像
                            if (m_ccamera.RGBToGray)
                            {
                                HTuple chNum;
                                HOperatorSet.CountChannels(image, out chNum);
                                if (chNum == 3)
                                    HOperatorSet.Rgb1ToGray(image, out image);
                            }
                            hWindow_Final1.HobjectToHimage(image);
                        }

                        sw.Stop();
                        lbl_elapsedTime.Text = sw.ElapsedMilliseconds + " ms";
                        isGrabing = false;
                    }
                    Frm_Loading.Instance.Hide();
                    nud_exposure.SelectText();
                    Frm_System.Instance.Activate();
                });
                th.IsBackground = true;
                th.Start();
            }
        }
        private void btn_grabOne_Click(object sender, EventArgs e)
        {
            //当选择硬触发模式时，不允许进行实时显示
            if (m_ccamera.hardTrigServer)
            {
                UIMessageTip.ShowWarning("硬触发模式下，不允许进行手动采集...");
                return;
            }

            if (!isGrabing && m_ccamera.GetCurCamera() != null)
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

                    lock (m_ccamera.obj)
                    {
                        isGrabing = true;
                        Stopwatch swa = new Stopwatch();
                        swa.Start();

                        //相机采集不要每一次都设置，浪费CT
                        //m_ccamera.GetCurCamera().SetGain(m_ccamera.gain, m_ccamera.name);
                        //m_ccamera.GetCurCamera().SetExposure(m_ccamera.exposure, m_ccamera.name);
                        //m_ccamera.GetCurCamera().SetAcqRegion(m_ccamera.row1, m_ccamera.col1, m_ccamera.row2, m_ccamera.col2, m_ccamera.name);
                        HObject image = m_ccamera.GetCurCamera().GrabOneImage(m_ccamera.name);

                        if (image != null)
                        {
                            //旋转图像
                            if (m_ccamera.rotateImage)
                                HOperatorSet.RotateImage(image, out image, -m_ccamera.rotateAngle, "constant");

                            //彩色图像转灰度图像
                            if (m_ccamera.RGBToGray)
                            {
                                HTuple chNum;
                                HOperatorSet.CountChannels(image, out chNum);
                                if (chNum == 3)
                                    HOperatorSet.Rgb1ToGray(image, out image);
                            }

                            hWindow_Final1.HobjectToHimage(image);
                        }
                        swa.Stop();
                        lbl_elapsedTime.Text = swa.ElapsedMilliseconds + " ms";
                        isGrabing = false;
                    }
                    Frm_Loading.Instance.Hide();
                });
                th.IsBackground = true;
                th.Start();
            }
            else
            {
                UIMessageTip.ShowWarning("当前正在采集图像中，请确认采集标记...");
            }
        }
        private void btn_grabLoop_Click(object sender, EventArgs e)
        {
            //当选择硬触发模式时，不允许进行实时显示
            if (m_ccamera.hardTrigServer)
            {
                UIMessageTip.ShowWarning("硬触发模式下，不允许进行实时显示...");
                return;
            }


            if (!CCamera.FindCamera(m_ccamera.name).loopGrab)
            {
                btn_grabLoop.Text = "停止实时";
                btn_focus.Enabled = false;
                CCamera.FindCamera(m_ccamera.name).loopGrab = true;
                Thread th = new Thread(() =>
                {
                    m_ccamera.GetCurCamera().SetAcquisitionMode(0);      //开始连续采集
                    int num = 0;
                    HTuple row1, col1, row2, col2;
                    HOperatorSet.GetPart(hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                    HalconLib.DispText(hWindow_Final1.HWindowHalconID, "实时中", 15, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "green", "false");

                    ////////显示十字架
                    HTuple width, height;
                    HObject line1;
                    HObject lien2;

                    Stopwatch sw = new Stopwatch();
                    HObject image = null;
                    while (CCamera.FindCamera(m_ccamera.name).loopGrab)
                    {
                        isGrabing = true;
                        sw.Restart();
                        //////没必要每次的时候都去设置曝光等参数，影响CT
                        //////m_ccamera.GetCurCamera().SetGain(m_ccamera.gain, m_ccamera.name);
                        //////m_ccamera.GetCurCamera().SetExposure(m_ccamera.exposure, m_ccamera.name);
                        //////m_ccamera.GetCurCamera().SetAcqRegion(m_ccamera.row1, m_ccamera.col1, m_ccamera.row2, m_ccamera.col2, m_ccamera.name);

                        image = m_ccamera.GetCurCamera().GrabOneImage(m_ccamera.name);


                        if (image == null)
                        {
                            continue;
                        }

                        //旋转图像
                        if (m_ccamera.rotateImage)
                            HOperatorSet.RotateImage(image, out image, -m_ccamera.rotateAngle, "constant");

                        //彩色图像转灰度图像
                        if (m_ccamera.RGBToGray)
                        {
                            HTuple chNum;
                            HOperatorSet.CountChannels(image, out chNum);
                            if (chNum == 3)
                                HOperatorSet.Rgb1ToGray(image, out image);
                        }

                        hWindow_Final1.HobjectToHimage(image);

                        //显示十字架
                        HOperatorSet.GetImageSize(image, out width, out height);
                        HOperatorSet.GenContourPolygonXld(out line1, new HTuple(height / 2, height / 2), new HTuple(0, width.I));
                        HOperatorSet.GenContourPolygonXld(out lien2, new HTuple(0, height.I), new HTuple(width / 2, width / 2));
                        hWindow_Final1.DispObj(line1, "green");
                        hWindow_Final1.DispObj(lien2, "green");
                        Application.DoEvents();

                        if (num % 2 == 0 && CCamera.FindCamera(m_ccamera.name).loopGrab)
                        {
                            HOperatorSet.GetPart(hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                            HalconLib.DispText(hWindow_Final1.HWindowHalconID, "实时中", 15, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "green", "false");
                            Application.DoEvents();
                        }

                        num++;
                        sw.Stop();
                        lbl_elapsedTime.Text = sw.ElapsedMilliseconds + " ms";
                        isGrabing = false;
                        Application.DoEvents();
                        Thread.Sleep(20);
                    }

                    m_ccamera.GetCurCamera().SetAcquisitionMode(1);      //停止连续采集
                    hWindow_Final1.HobjectToHimage(image);
                    lbl_elapsedTime.Text = sw.ElapsedMilliseconds + " ms";

                    btn_grabLoop.Text = "开始实时";
                    btn_focus.Enabled = true;
                });
                th.IsBackground = true;
                th.Start();
            }
            else
            {
                CCamera.FindCamera(m_ccamera.name).loopGrab = false;
            }
        }
        private void btn_focus_Click(object sender, EventArgs e)
        {
            if (!CCamera.FindCamera(m_ccamera.name).loopGrab)
            {
                btn_grabLoop.Enabled = false;
                lbl_curValue.Visible = true;
                lbl_maxValue.Visible = true;
                btn_focus.Text = "停止对焦";
                CCamera.FindCamera(m_ccamera.name).loopGrab = true;
                Thread th = new Thread(() =>
                {
                    DrawROIRegion(hWindow_Final1.currentImage);
                    int num = 0;
                    double maxDefinition = 0;       //清晰度最大值

                    m_ccamera.GetCurCamera().SetAcquisitionMode(0);      //开始连续采集
                    Stopwatch sw = new Stopwatch();

                    HObject image = null;
                    while (CCamera.FindCamera(m_ccamera.name).loopGrab)
                    {
                        sw.Restart();
                        image = m_ccamera.GetCurCamera().GrabOneImage(m_ccamera.name);

                        //旋转图像
                        if (m_ccamera.rotateImage)
                            HOperatorSet.RotateImage(image, out image, -m_ccamera.rotateAngle, "constant");

                        //彩色图像转灰度图像
                        if (m_ccamera.RGBToGray)
                        {
                            HTuple chNum;
                            HOperatorSet.CountChannels(image, out chNum);
                            if (chNum == 3)
                                HOperatorSet.Rgb1ToGray(image, out image);
                        }

                        hWindow_Final1.HobjectToHimage(image);

                        //显示清晰度
                        HTuple mean, dev;
                        HObject edgeAmplitude;
                        HOperatorSet.SobelAmp(image, out edgeAmplitude, "sum_abs", 3);
                        HObject rect;
                        HOperatorSet.GenRectangle2(out rect, m_ccamera.rowFocus, m_ccamera.colFocus, m_ccamera.phiFocus, m_ccamera.length1Focus, m_ccamera.length2Focus);
                        hWindow_Final1.DispObj(rect, "blue");
                        HOperatorSet.Intensity(rect, edgeAmplitude, out mean, out dev);
                        mean = Math.Round(mean.D, 1);
                        if (mean > maxDefinition)
                            maxDefinition = mean;

                        Instance.Invoke(new Action(() =>
                        {
                            lbl_curValue.Text = "当前：" + mean.D.ToString();
                            lbl_maxValue.Text = "峰值：" + maxDefinition.ToString();
                            if (Math.Abs(mean.D - maxDefinition) < 0.6)
                            {
                                lbl_curValue.ForeColor = Color.Green;
                                lbl_maxValue.ForeColor = Color.Green;
                            }
                            else
                            {
                                lbl_curValue.ForeColor = Color.Black;
                                lbl_maxValue.ForeColor = Color.Black;
                            }
                        }));

                        num++;
                        long time = sw.ElapsedMilliseconds;
                        lbl_elapsedTime.Text = time + " ms";
                        Application.DoEvents();
                        Thread.Sleep(20);
                    }
                    m_ccamera.GetCurCamera().SetAcquisitionMode(1);      //停止连续采集
                    hWindow_Final1.HobjectToHimage(image);

                    btn_grabLoop.Enabled = true;
                    lbl_curValue.Visible = false;
                    lbl_maxValue.Visible = false;
                    btn_focus.Text = "对焦";
                });
                th.IsBackground = true;
                th.Start();
            }
            else
            {
                CCamera.FindCamera(m_ccamera.name).loopGrab = false;
            }
        }
        private void btn_saveImage_Click(object sender, EventArgs e)
        {
            SaveImage();
        }
        private void btn_movePar_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            Frm_MorePar.ccamera = m_ccamera;
            Frm_MorePar.isLoading = true;
            Frm_MorePar.LoadPara();
            Frm_MorePar.Instance.Show();
            Frm_MorePar.isLoading = false;
        }

        private void 适应窗体toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hWindow_Final1.DispImageFit();
        }
        private void 图像信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hWindow_Final1.m_CtrlHStatusLabelCtrl.Visible)
                hWindow_Final1.m_CtrlHStatusLabelCtrl.Visible = false;
            else
                hWindow_Final1.m_CtrlHStatusLabelCtrl.Visible = true;
        }

        private void uiLabel5_Click(object sender, EventArgs e)
        {

        }

        private void nud_exposure_Load(object sender, EventArgs e)
        {

        }
    }
}
