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
using System.Threading;
using HalconDotNet;
using System.Diagnostics;

namespace VM_Pro
{
    public partial class Frm_Template : UIForm
    {
        public Frm_Template()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        /// <summary>
        /// 标定对象
        /// </summary>
        internal static Calibrate calibrate;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Template _instance;
        internal static Frm_Template Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Template();
                return _instance;
            }
        }


        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="calibrate"></param>
        internal void ShowPar(Calibrate calibrate)
        {
            Frm_Template.calibrate = calibrate;

            Instance.rdo_basedCircleCenter.Checked = calibrate.basedCircleCenter;
            Instance.rdo_baseLineCross.Checked = !calibrate.basedCircleCenter;

            calibrate.ShowTemplateAtSmallWindow();

            if (Permission.CheckPermission(PermissionGrade.Admin))
            {
                rdo_basedCircleCenter.Enabled = true;
                rdo_baseLineCross.Enabled = true;
            }
            else
            {
                rdo_basedCircleCenter.Enabled = false;
                rdo_baseLineCross.Enabled = false;
            }

            Frm_Calibrate.Instance.hWindow_Final1.viewWindow.displayROI(calibrate.L_regions);
            Frm_Calibrate.Instance.L_regions = calibrate.L_regions;
            Frm_Calibrate.CanNotUpdateImage = false;
            Frm_System.Instance.TopMost = false;
        }
        /// <summary>
        /// 绘制模板区域
        /// </summary>
        /// <param name="regionType">区域类型</param>
        internal void DrawTemplateRegion(RegionType regionType)
        {
            Thread th = new Thread(() =>
            {
                if (Frm_Calibrate.isDrawing)
                {
                    Frm_Calibrate.isDrawing = false;
                    HalconLib.HIOCancelDraw();
                }

                Frm_Calibrate.isDrawing = true;
                if (!calibrate.templateCreated)
                {
                    HObject image = CCamera.FindCamera(calibrate.calibCamera).GrabOneImage(calibrate.calibCamera);
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

                    Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(image);
                    Frm_Calibrate.curImage = image;
                }
                else
                {
                    Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(calibrate.templateImage);
                    Frm_Calibrate.curImage = calibrate.templateImage;
                }

                Frm_Calibrate.Instance.hWindow_Final1.DispObj(calibrate.templateRegion, "green");
                Frm_Calibrate.Instance.hWindow_Final1.Focus();
                HOperatorSet.SetDraw(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "margin");

                HTuple row1, col1, row2, col2;
                HOperatorSet.GetPart(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "请在图像窗口中绘制模板区域，绘制结束后右击图像窗口", 13, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "blue", "false");

                Frm_Calibrate.Instance.hWindow_Final1.ContextMenuStrip = null;
                Frm_Calibrate.Instance.hWindow_Final1.DrawModel = true;
                HOperatorSet.SetColor(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "green");

                HObject region = null;
                switch (regionType)
                {
                    case RegionType.矩形:
                        HTuple row, col, row3, col3;
                        HOperatorSet.DrawRectangle1(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out row3, out col3);
                        if (row.D == 0 && col.D == 0)
                            return;
                        HOperatorSet.GenRectangle1(out region, row, col, row3, col3);
                        break;

                    case RegionType.仿射矩形:
                        HTuple angle, length1, length2;
                        HOperatorSet.DrawRectangle2(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out angle, out length1, out length2);
                        if (row.D == 0 && col.D == 0)
                            return;
                        HOperatorSet.GenRectangle2(out region, row, col, angle, length1, length2);
                        calibrate.templateAngle = angle;
                        break;

                    case RegionType.圆:
                        HTuple radius;
                        HOperatorSet.DrawCircle(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out radius);
                        if (row.D == 0 && col.D == 0)
                            return;
                        HOperatorSet.GenCircle(out region, row, col, radius);
                        break;
                }
                Frm_Calibrate.Instance.hWindow_Final1.DrawModel = false;
                Frm_Calibrate.Instance.hWindow_Final1.ContextMenuStrip = Frm_Calibrate.Instance.uiContextMenuStrip1;

                if (calibrate.templateRegion == null)
                    calibrate.templateRegion = region;
                else
                    HOperatorSet.Union2(calibrate.templateRegion, region, out calibrate.templateRegion);

                if (!calibrate.templateCreated)
                    Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(Frm_Calibrate.Instance.hWindow_Final1.currentImage);
                else
                    Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(calibrate.templateImage);

                HOperatorSet.SetLineStyle(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, new HTuple());
                Frm_Calibrate.Instance.hWindow_Final1.DispObj(calibrate.templateRegion, "green");
                HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "若绘制已完成，请点击训练按钮进行训练模板", 13, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "blue", "false");
                Frm_Calibrate.isDrawing = false;

                Frm_Calibrate.CanNotUpdateImage = false;

                Study();
            });
            th.IsBackground = true;
            th.Start();
        }


        private void btn_resetTemplate_Click(object sender, EventArgs e)
        {
            if (Frm_Calibrate.isDrawing)
            {
                Frm_Calibrate.isDrawing = false;
                HalconLib.HIOCancelDraw();
                Frm_Calibrate.Instance.hWindow_Final1.DrawModel = false;
            }

            HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);

            HObject image = CCamera.FindCamera(calibrate.calibCamera).GrabOneImage(calibrate.calibCamera);
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

            Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(image);
            Frm_Calibrate.curImage = image;

            //清除模板信息
            calibrate.templateCreated = false;
            calibrate.templateRegion = null;
            calibrate.templateImage = null;
        }
        private void Study()
        {
            if (calibrate.templateRegion == null)
            {
                FuncLib.ShowMessageBox("训练失败，请先绘制模板区域", InfoType.Error);
                return;
            }

            this.Invoke(new Action(() =>
            {
                Frm_Loading.Instance.lbl_title.Text = "拼命加载中";
                Frm_Loading.Instance.TopLevel = true;
                Frm_Loading.Instance.TopMost = true;
                Frm_Loading.Instance.Show();
                Application.DoEvents();
            }));

            calibrate.CreateTemplate();
            calibrate.ShowTemplateAtSmallWindow();

            calibrate.RunOnce();
            Frm_Loading.Instance.Hide();
        }
        private void btn_drawCircle_Click(object sender, EventArgs e)
        {
            CCamera.FindCamera(calibrate.calibCamera).loopGrab = false;
            Frm_Calibrate.CanNotUpdateImage = true;
            DrawTemplateRegion(RegionType.圆);
        }
        private void btn_drawRectangle1_Click(object sender, EventArgs e)
        {
            CCamera.FindCamera(calibrate.calibCamera).loopGrab = false;
            Frm_Calibrate.CanNotUpdateImage = true;
            DrawTemplateRegion(RegionType.矩形);
        }
        private void btn_drawRectangle2_Click(object sender, EventArgs e)
        {
            CCamera.FindCamera(calibrate.calibCamera).loopGrab = false;
            Frm_Calibrate.CanNotUpdateImage = true;
            DrawTemplateRegion(RegionType.仿射矩形);
        }
        private void rdo_basedCircleCenter_Click(object sender, EventArgs e)
        {
            calibrate.basedCircleCenter = true;
        }
        private void rdo_baseLineCross_Click(object sender, EventArgs e)
        {
            calibrate.basedCircleCenter = false;
        }
        private void Frm_MorePar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Frm_Calibrate.CanNotUpdateImage = true;
            this.Hide();
            e.Cancel = true;
        }
        private void btn_getBoardPos_Click(object sender, EventArgs e)
        {
            Frm_Calibrate.CanNotUpdateImage = true;
            if (Frm_Calibrate.isDrawing)
            {
                Frm_Calibrate.isDrawing = false;
                HalconLib.HIOCancelDraw();
            }

            Frm_Calibrate.isDrawing = true;
            FuncLib.ShowMessageBox("请在图像上框出标定板的区域，然后鼠标在图像上右击结束框选");

            Frm_Calibrate.Instance.hWindow_Final1.ContextMenuStrip = null;
            Frm_Calibrate.Instance.hWindow_Final1.DrawModel = true;
            HOperatorSet.SetColor(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "green");

            Frm_Calibrate.Instance.hWindow_Final1.Focus();
            HOperatorSet.SetDraw(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "margin");

            Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(Frm_Calibrate.curImage);

            HTuple row, col, phi, length1, length2;
            HOperatorSet.DrawRectangle2(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, out row, out col, out phi, out length1, out length2);
            HObject rect2;
            HOperatorSet.GenRectangle2(out rect2, row, col, phi, length1, length2);
            HObject reducedImage;
            HOperatorSet.ReduceDomain(Frm_Calibrate.curImage, rect2, out reducedImage);
            HObject feature;
            HOperatorSet.Threshold(reducedImage, out feature, 0, 100);
            Frm_Calibrate.Instance.hWindow_Final1.DispObj(feature, "green");
            calibrate.boardPos = feature;

            Frm_Calibrate.Instance.hWindow_Final1.DrawModel = false;
            Frm_Calibrate.Instance.hWindow_Final1.ContextMenuStrip = Frm_Calibrate.Instance.uiContextMenuStrip1;

            Frm_Calibrate.isDrawing = false;
            Frm_Calibrate.CanNotUpdateImage = false;
        }
        private void btn_showBoardPos_Click(object sender, EventArgs e)
        {
            if (!CCamera.FindCamera(calibrate.calibCamera).loopGrab)
            {
                btn_showBoardPos.Text = "停止显示";
                CCamera.FindCamera(calibrate.calibCamera).loopGrab = true;
                Thread th = new Thread(() =>
                {
                    CCamera.FindCamera(calibrate.calibCamera).SetAcquisitionMode(0);      //开始连续采集
                    int num = 0;
                    HTuple row1, col1, row2, col2;
                    HOperatorSet.GetPart(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                    HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "实时中", 15, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "green", "false");

                    //显示十字架
                    HTuple width, height;
                    HObject line1;
                    HObject lien2;
                    if (Frm_Calibrate.Instance.hWindow_Final1.currentImage != null)
                    {
                        HOperatorSet.GetImageSize(Frm_Calibrate.Instance.hWindow_Final1.currentImage, out width, out height);

                        HOperatorSet.GenContourPolygonXld(out line1, new HTuple(height / 2, height / 2), new HTuple(0, width.I));
                        HOperatorSet.GenContourPolygonXld(out lien2, new HTuple(0, height.I), new HTuple(width / 2, width / 2));
                        Frm_Calibrate.Instance.hWindow_Final1.DispObj(line1, "green");
                        Frm_Calibrate.Instance.hWindow_Final1.DispObj(lien2, "green");
                    }
                    Application.DoEvents();

                    Stopwatch sw = new Stopwatch();
                    HObject image = null;
                    while (CCamera.FindCamera(calibrate.calibCamera).loopGrab)
                    {
                        sw.Restart();

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

                        Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(image);

                        //显示十字架
                        HOperatorSet.GetImageSize(image, out width, out height);
                        HOperatorSet.GenContourPolygonXld(out line1, new HTuple(height / 2, height / 2), new HTuple(0, width.I));
                        HOperatorSet.GenContourPolygonXld(out lien2, new HTuple(0, height.I), new HTuple(width / 2, width / 2));
                        Frm_Calibrate.Instance.hWindow_Final1.DispObj(line1, "green");
                        Frm_Calibrate.Instance.hWindow_Final1.DispObj(lien2, "green");
                        Application.DoEvents();

                        if (num % 2 == 0 && CCamera.FindCamera(calibrate.calibCamera).loopGrab)
                        {
                            HOperatorSet.GetPart(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                            HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "实时中", 15, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "green", "false");
                            Application.DoEvents();
                        }

                        //显示标定板位置
                        Frm_Calibrate.Instance.hWindow_Final1.DispObj(calibrate.boardPos, "green");

                        num++;
                        sw.Stop();
                        Application.DoEvents();
                        Thread.Sleep(20);
                    }

                    CCamera.FindCamera(calibrate.calibCamera).SetAcquisitionMode(1);      //停止连续采集
                    Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(image);

                    btn_showBoardPos.Text = "显示标定位";
                });
                th.IsBackground = true;
                th.Start();
            }
            else
            {
                CCamera.FindCamera(calibrate.calibCamera).loopGrab = false;
            }
        }

    }
}
