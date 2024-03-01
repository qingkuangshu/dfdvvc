using AVT.VmbAPINET;
using HalconDotNet;
using Microsoft.Win32;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewWindow.Model;

namespace VM_Pro
{
    public partial class Frm_Calibrate : Form
    {
        public Frm_Calibrate()
        {
            InitializeComponent();
            hWindow_Final1.hWindowControl.MouseUp += Hwindow_MouseUp;
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
        /// 是否正在标定
        /// </summary>
        internal static bool CanNotUpdateImage = true;
        /// <summary>
        /// 当前图像
        /// </summary>
        internal static HObject curImage = null;
        /// <summary>
        /// 是否正在绘制模板
        /// </summary>
        internal static bool isDrawing = false;
        /// <summary>
        /// 标定对象
        /// </summary>
        internal static Calibrate calibrate;
        /// <summary>
        /// 搜索区域
        /// </summary>
        internal List<ROI> L_regions = new List<ROI>();
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Calibrate _instance;
        internal static Frm_Calibrate Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Calibrate();
                return _instance;
            }
        }


        /// <summary>
        /// 显示参数到界面
        /// </summary>
        /// <param name="tcpClient"></param>
        internal static void ShowPar(ServiceBase serviceBase)
        {
            if (Frm_Service.curForm != CurForm.Calibrate)
            {
                Frm_Service.curForm = CurForm.Calibrate;

                Frm_Service.Instance.pnl_seviceBox.Controls.Clear();
                Instance.TopLevel = false;
                Instance.Parent = Frm_Service.Instance.pnl_seviceBox;
                Instance.Dock = DockStyle.Fill;
                Instance.Show();
            }

            calibrate = (Calibrate)serviceBase;

            //更新参数
            if (calibrate.calibrated)
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "已标定";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
            }
            else
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "未标定";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
            }

            Thread th = new Thread(() =>
            {
                Instance.nud_exposure.Value = ((CCamera)Project.FindServiceByName(calibrate.calibCamera)).exposure;
                CCamera.FindCamera(calibrate.calibCamera).SetExposure(((CCamera)Project.FindServiceByName(calibrate.calibCamera)).exposure, calibrate.calibCamera);
                HObject image = CCamera.FindCamera(calibrate.calibCamera).GrabOneImage(calibrate.calibCamera);
                if (image != null)
                {
                    if (((CCamera)Project.FindServiceByName(calibrate.calibCamera)).RGBToGray)
                    {
                        HTuple chNum;
                        HOperatorSet.CountChannels(image, out chNum);
                        if (chNum == 3)
                        {
                            HObject image1;
                            HOperatorSet.Rgb1ToGray(image, out image1);
                            image = image1;
                        }
                    }

                    if (((CCamera)Project.FindServiceByName(calibrate.calibCamera)).rotateImage)
                    {
                        HObject image2;
                        HOperatorSet.RotateImage(image, out image2, -((CCamera)Project.FindServiceByName(calibrate.calibCamera)).rotateAngle, "constant");
                        image = image2;
                    }

                    Instance.hWindow_Final1.HobjectToHimage(image);
                    curImage = image;
                }

                foreach (KeyValuePair<string, XY> item in calibrate.D_point)
                {
                    HObject cross;
                    HOperatorSet.GenCrossContourXld(out cross, item.Value.X, item.Value.Y, 30, new HTuple(0));
                    Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross, "green");
                    HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, item.Key, 15, item.Value.X + 10, item.Value.Y + 10, "green", "false");
                }
            });
            th.IsBackground = true;
            th.Start();

            Instance.tbx_log.Text = calibrate.calibInfo;
            Frm_Calibrate.Instance.tbx_log.SelectionStart = Frm_Calibrate.Instance.tbx_log.Text.Length;
            Frm_Calibrate.Instance.tbx_log.SelectionLength = 0;
            Instance.tbx_log.ScrollToCaret();
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

            if (!CanNotUpdateImage)
            {
                hWindow_Final1.HobjectToHimage(hWindow_Final1.currentImage);
                //显示卡尺
                HTuple newExpecCircleRow = new HTuple(), newExpectCircleCol = new HTuple(), newExpectCircleRadius = new HTuple();
                HTuple _homMat2D;
                HOperatorSet.VectorAngleToRigid(calibrate.followedPose.XY.X, calibrate.followedPose.XY.Y, calibrate.followedPose.U, calibrate.lastMatchPos.XY.X, calibrate.lastMatchPos.XY.Y, calibrate.lastMatchPos.U, out _homMat2D);
                HTuple tempR, tempC;
                HOperatorSet.AffineTransPixel(_homMat2D, (HTuple)L_regions[0].getModelData()[0], (HTuple)L_regions[0].getModelData()[1], out tempR, out tempC);
                newExpecCircleRow = tempR;
                newExpectCircleCol = tempC;
                newExpectCircleRadius = L_regions[0].getModelData()[2].D;

                HTuple index1;
                HTuple handleID;
                HOperatorSet.CreateMetrologyModel(out handleID);
                HTuple width, height;
                HOperatorSet.GetImageSize(curImage, out width, out height);
                HOperatorSet.SetMetrologyModelImageSize(handleID, width[0], height[0]);
                HOperatorSet.AddMetrologyObjectCircleMeasure(handleID, newExpecCircleRow, newExpectCircleCol, newExpectCircleRadius, new HTuple(30), new HTuple(5), new HTuple(1), new HTuple(30), new HTuple(), new HTuple(), out index1);

                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_transition"), new HTuple("positive"));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("num_measures"), new HTuple(30));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length1"), new HTuple(10));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length2"), new HTuple(5));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_threshold"), new HTuple(20));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_select"), new HTuple("first"));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("min_score"), new HTuple(0.3));
                HOperatorSet.ApplyMetrologyModel(curImage, handleID);

                HObject contours;
                HTuple row3, col3;
                HOperatorSet.GetMetrologyObjectMeasures(out contours, handleID, new HTuple("all"), new HTuple("all"), out row3, out col3);

                HTuple parameter;
                HObject circle;
                HOperatorSet.GetMetrologyObjectResult(handleID, new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"), out parameter);
                HOperatorSet.GetMetrologyObjectResultContour(out circle, handleID, new HTuple("all"), new HTuple("all"), new HTuple(1.5));
                if (parameter.Length >= 3)
                {
                    //Frm_Calibrate.Instance.hWindow_Final1.DispObj(contours, "blue");

                    //显示圆
                    HObject circle1;
                    HOperatorSet.GenCircle(out circle1, parameter[0], parameter[1], parameter[2]);
                    HOperatorSet.SetDraw(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "margin");
                    Frm_Calibrate.Instance.hWindow_Final1.DispObj(circle1, "green");
                }
                else
                {
                    //Frm_Calibrate.Instance.hWindow_Final1.DispObj(contours, "red");
                }

                Frm_Calibrate.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
                Frm_Calibrate.Instance.L_regions = L_regions;
            }
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
        private void btn_template_Click(object sender, EventArgs e)
        {
            Frm_CalibType.Instance.Close();
            Frm_CalibData.Instance.Close();
            Frm_CalibResult.Instance.Close();

            Frm_Template.Instance.Location = new Point(Frm_System.Instance.Location.X - 86, Frm_System.Instance.Location.Y + 35);
            Frm_Template.Instance.ShowPar(calibrate);
            Frm_Template.Instance.Show();
        }
        private void btn_calibType_Click(object sender, EventArgs e)
        {
            Frm_CalibData.Instance.Close();
            Frm_CalibResult.Instance.Close();
            Frm_Template.Instance.Close();

            Frm_CalibType.Instance.Location = new Point(Frm_System.Instance.Location.X - 86, Frm_System.Instance.Location.Y + 35);
            Frm_CalibType.Instance.ShowPar(calibrate);
            Frm_CalibType.Instance.Show();
            Frm_CalibType.hasShown = true;
        }
        private void btn_calibData_Click(object sender, EventArgs e)
        {
            Frm_CalibType.Instance.Close();
            Frm_CalibResult.Instance.Close();
            Frm_Template.Instance.Close();

            Frm_CalibData.Instance.Location = new Point(Frm_System.Instance.Location.X - 86, Frm_System.Instance.Location.Y + 35);
            Frm_CalibData.Instance.ShowPar(calibrate);
            Frm_CalibData.Instance.Show();
            Frm_CalibData.hasShown = true;
        }
        private void btn_calibResult_Click(object sender, EventArgs e)
        {
            Frm_CalibType.Instance.Close();
            Frm_CalibData.Instance.Close();
            Frm_Template.Instance.Close();

            Frm_CalibResult.Instance.Location = new Point(Frm_System.Instance.Location.X - 86, Frm_System.Instance.Location.Y + 35);
            Frm_CalibResult.Instance.ShowPar(calibrate);
            Frm_CalibResult.Instance.Show();
            Frm_CalibResult.hasShown = true;
        }
        private void btn_photoPos_Click(object sender, EventArgs e)
        {
            FuncLib.ShowMessageBox("尚未开发，敬请期待！");
        }
        private void btn_grabLoop_Click(object sender, EventArgs e)
        {
            //////switch (calibrate.calibCamera)
            //////{
            //////    case "底部相机":
            //////        FuncLib.SetDo(Do.下光源_红_E1Out11, OnOff.On);
            //////        FuncLib.SetDo(Do.下光源_蓝_E2Out1, OnOff.On);
            //////        FuncLib.SetDo(Do.下光源_绿_E1Out12, OnOff.On);
            //////        break;
            //////    case "顶部相机":
            //////        FuncLib.SetDo(Do.托盘拍照条光1_E1Out9, OnOff.On);
            //////        FuncLib.SetDo(Do.托盘拍照条光2_E1Out10, OnOff.On);
            //////        break;
            //////    case "移动相机":
            //////        FuncLib.SetDo(Do.机械手环形光源_E2Out2, OnOff.On);
            //////        FuncLib.SetDo(Do.机械手条形光源_E2Out3, OnOff.On);
            //////        break;
            //////}

            if (!CCamera.FindCamera(calibrate.calibCamera).loopGrab)
            {
                btn_grabLoop.Text = "停止实时";
                CCamera.FindCamera(calibrate.calibCamera).loopGrab = true;
                Thread th = new Thread(() =>
                {
                    CCamera.FindCamera(calibrate.calibCamera).SetAcquisitionMode(0);      //开始连续采集
                    int num = 0;
                    HTuple row1, col1, row2, col2;
                    HOperatorSet.GetPart(hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                    HalconLib.DispText(hWindow_Final1.HWindowHalconID, "实时中", 15, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "green", "false");

                    //显示十字架
                    HTuple width, height;
                    HObject line1;
                    HObject lien2;
                    if (hWindow_Final1.currentImage != null)
                    {
                        HOperatorSet.GetImageSize(hWindow_Final1.currentImage, out width, out height);

                        HOperatorSet.GenContourPolygonXld(out line1, new HTuple(height / 2, height / 2), new HTuple(0, width.I));
                        HOperatorSet.GenContourPolygonXld(out lien2, new HTuple(0, height.I), new HTuple(width / 2, width / 2));
                        hWindow_Final1.DispObj(line1, "green");
                        hWindow_Final1.DispObj(lien2, "green");
                    }
                    Application.DoEvents();

                    Stopwatch sw = new Stopwatch();
                    HObject image = null;
                    while (CCamera.FindCamera(calibrate.calibCamera).loopGrab)
                    {
                        sw.Restart();

                        CCamera.FindCamera(calibrate.calibCamera).SetExposure(((CCamera)Project.FindServiceByName(calibrate.calibCamera)).exposure, calibrate.calibCamera);
                        image = CCamera.FindCamera(calibrate.calibCamera).GrabOneImage(calibrate.calibCamera);

                        //旋转图像
                        if (CCamera.GetCCamera(calibrate.calibCamera).rotateImage)
                            HOperatorSet.RotateImage(image, out image, -CCamera.GetCCamera(calibrate.calibCamera).rotateAngle, "constant");

                        //彩色图像转灰度图像
                        if (CCamera.GetCCamera(calibrate.calibCamera).RGBToGray)
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

                        if (num % 2 == 0 && CCamera.FindCamera(calibrate.calibCamera).loopGrab)
                        {
                            HOperatorSet.GetPart(hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                            HalconLib.DispText(hWindow_Final1.HWindowHalconID, "实时中", 15, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "green", "false");
                            Application.DoEvents();
                        }

                        num++;
                        sw.Stop();
                        Application.DoEvents();
                        Thread.Sleep(20);
                    }

                    CCamera.FindCamera(calibrate.calibCamera).SetAcquisitionMode(1);      //停止连续采集
                    hWindow_Final1.HobjectToHimage(image);

                    btn_grabLoop.Text = "相机实时";
                });
                th.IsBackground = true;
                th.Start();
            }
            else
            {
                CCamera.FindCamera(calibrate.calibCamera).loopGrab = false;
            }
        }
        private void btn_test_Click(object sender, EventArgs e)
        {
            btn_test.Enabled = false;
            this.Invoke(new Action(() =>
            {
                Frm_Loading.Instance.lbl_title.Text = "拼命加载中";
                Frm_Loading.Instance.TopLevel = true;
                Frm_Loading.Instance.TopMost = true;
                Frm_Loading.Instance.Show();
            }));
            switch (calibrate.calibCamera)
            {
                case "底部相机":
                    //////FuncLib.SetDo(Do.下光源_红_E1Out11, OnOff.On);
                    //////FuncLib.SetDo(Do.下光源_蓝_E2Out1, OnOff.On);
                    //////FuncLib.SetDo(Do.下光源_绿_E1Out12, OnOff.On);
                    break;
                case "顶部相机":
                    //////FuncLib.SetDo(Do.托盘拍照条光1_E1Out9, OnOff.On);
                    //////FuncLib.SetDo(Do.托盘拍照条光2_E1Out10, OnOff.On);
                    break;
                case "移动相机":
                    //////FuncLib.SetDo(Do.机械手环形光源_E2Out2, OnOff.On);
                    //////FuncLib.SetDo(Do.机械手条形光源_E2Out3, OnOff.On);
                    break;
            }

            calibrate.RunOnce();
            Frm_Loading.Instance.Hide();
            btn_test.Enabled = true;
        }
        private void btn_calibrate_Click(object sender, EventArgs e)
        {
            if (btn_calibrate.Text == "执行标定")
            {
                Frm_Calibrate.Instance.btn_calibrate.Text = "标定中...";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.Green;
                Application.DoEvents();

                hWindow_Final1.DispImageFit();
                calibrate.StartCalibrate();

                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                Application.DoEvents();
            }
            else
            {
                Calibrate.giveupCalibrate = true;
            }
        }
        private void nud_exposure_ValueChanged(double value)
        {
            if (isLoading)
                return;

            ((CCamera)Project.FindServiceByName(calibrate.calibCamera)).exposure = (int)value;
            CCamera.FindCamera(calibrate.calibCamera).SetExposure((int)value, calibrate.calibCamera);
            nud_exposure.SelectText();

            if (((CCamera)Project.FindServiceByName(calibrate.calibCamera)).cameraInfoStr != string.Empty && !isGrabing)
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
                    lock (((CCamera)Project.FindServiceByName(calibrate.calibCamera)).obj)
                    {
                        isGrabing = true;

                        CCamera.FindCamera(calibrate.calibCamera).SetGain(((CCamera)Project.FindServiceByName(calibrate.calibCamera)).gain, ((CCamera)Project.FindServiceByName(calibrate.calibCamera)).name);
                        CCamera.FindCamera(calibrate.calibCamera).SetAcqRegion(((CCamera)Project.FindServiceByName(calibrate.calibCamera)).row1, ((CCamera)Project.FindServiceByName(calibrate.calibCamera)).col1, ((CCamera)Project.FindServiceByName(calibrate.calibCamera)).row2, ((CCamera)Project.FindServiceByName(calibrate.calibCamera)).col2, ((CCamera)Project.FindServiceByName(calibrate.calibCamera)).name);
                        HObject image = CCamera.FindCamera(calibrate.calibCamera).GrabOneImage(calibrate.calibCamera);

                        //旋转图像
                        if (image != null)
                        {
                            if (((CCamera)Project.FindServiceByName(calibrate.calibCamera)).rotateImage)
                                HOperatorSet.RotateImage(image, out image, -((CCamera)Project.FindServiceByName(calibrate.calibCamera)).rotateAngle, "constant");

                            //彩色图像转灰度图像
                            if (((CCamera)Project.FindServiceByName(calibrate.calibCamera)).RGBToGray)
                            {
                                HTuple chNum;
                                HOperatorSet.CountChannels(image, out chNum);
                                if (chNum == 3)
                                    HOperatorSet.Rgb1ToGray(image, out image);
                            }
                            hWindow_Final1.HobjectToHimage(image);
                        }

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

    }
}
