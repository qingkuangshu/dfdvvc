using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using HalconDotNet;
using ViewWindow.Model;
using System.Windows.Forms;

namespace VM_Pro
{
    /// <summary>
    /// 相机标定
    /// </summary>
    [Serializable]
    internal class Calibrate : ServiceBase
    {
        internal Calibrate(string s_name)
        {
            this.name = s_name;
            this.serviceType = ServiceType.Calibrate;

            Frm_Calibrate.Instance.hWindow_Final1.viewWindow.genCircle(400.0, 500.0, 50, ref L_regions);

            //自动指定要标定的相机
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                {
                    calibCamera = Project.Instance.L_Service[i].name;
                    break;
                }
            }
        }

        /// <summary>
        /// 模板匹配句柄
        /// </summary>
        internal HTuple modelID = null;
        /// <summary>
        /// 模板是否已创建
        /// </summary>
        internal bool templateCreated = false;
        /// <summary>
        /// 已标定
        /// </summary>
        internal bool calibrated = false;
        /// <summary>
        /// 标定信息
        /// </summary>
        internal string calibInfo = string.Empty;
        /// <summary>
        /// 标定类型    自动标定|手动标定
        /// </summary>
        internal string calibType = "自动标定";
        /// <summary>
        /// 标定模式    眼在手外|眼在手上
        /// </summary>
        internal string calibMode = "眼在手外";
        /// <summary>
        /// 所标定的相机
        /// </summary>
        internal string calibCamera = string.Empty;
        /// <summary>
        /// 放弃标定
        /// </summary>
        internal static bool giveupCalibrate = false;
        /// <summary>
        /// 平移中心
        /// </summary>
        internal XYZU moveCenterPos = new XYZU();
        /// <summary>
        /// 旋转中心
        /// </summary>
        internal XYZU rotateCenterPos = new XYZU();
        /// <summary>
        /// 平移量
        /// </summary>
        internal double moveSpan = 20;
        /// <summary>
        /// 旋转量
        /// </summary>
        internal double rotateSpan = 10;
        /// <summary>
        /// 平移标定点数
        /// </summary>
        internal int XYPointNum = 9;
        /// <summary>
        /// 旋转标定点数
        /// </summary>
        internal int UPointNum = 5;
        /// <summary>
        /// 特征点基于圆心或基于两线交点
        /// </summary>
        internal bool basedCircleCenter = true;
        /// <summary>
        /// 平移标定像素坐标
        /// </summary>
        internal List<XY> L_XYPixel = new List<XY>();
        /// <summary>
        /// 平移标定机械坐标
        /// </summary>
        internal List<XY> L_XYRobot = new List<XY>();
        /// <summary>
        /// 旋转标定像素坐标
        /// </summary>
        internal List<XY> L_UPixel = new List<XY>();
        /// <summary>
        /// 变换矩阵
        /// </summary>
        internal HTuple homMat2D = null;
        /// <summary>
        /// X方向偏差
        /// </summary>
        internal double offsetX = 0;
        /// <summary>
        /// Y方向偏差
        /// </summary>
        internal double offsetY = 0;
        /// <summary>
        /// 标定结果等级
        /// </summary>
        internal string calibLevel = "未标定";
        /// <summary>
        /// 模板图像
        /// </summary>
        internal HObject templateImage = null;
        /// <summary>
        /// 模板区域
        /// </summary>
        internal HObject templateRegion = null;
        /// <summary>
        /// 模板角度
        /// </summary>
        internal double templateAngle = 0;
        /// <summary>
        /// 搜索区域
        /// </summary>
        internal List<ROI> L_regions = new List<ROI>();
        /// <summary>
        /// 制作模板时的输入位姿
        /// </summary>
        internal XYU followedPose = new XYU();
        /// <summary>
        /// 最后一次匹配位置
        /// </summary>
        internal XYU lastMatchPos = new XYU();
        /// <summary>
        /// 最后一次运行特征点坐标
        /// </summary>
        internal XY lastFeaturePos = new XY();
        /// <summary>
        /// 特征点集合
        /// </summary>
        internal Dictionary<string, XY> D_point = new Dictionary<string, XY>();
        /// <summary>
        /// 标定板位置
        /// </summary>
        internal HObject boardPos = null;


        /// <summary>
        /// 创建模板
        /// </summary>
        internal void CreateTemplate()
        {
            if (!templateCreated)
                templateImage = Frm_Calibrate.curImage;

            if (templateImage == null)
            {
                templateCreated = false;
                return;
            }

            HObject imageReduced;
            HOperatorSet.ReduceDomain(templateImage, templateRegion, out imageReduced);
            try
            {
                HOperatorSet.CreateNccModel(imageReduced,
                                            "auto",
                                            ((HTuple)(-180)).TupleRad(),
                                            ((HTuple)360).TupleRad(),
                                            "auto",
                                            "use_polarity",
                                             out modelID);
                templateCreated = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("#8510:"))      //特征过少，Halcon报错编号8510
                {
                    templateCreated = false;
                    FuncLib.ShowMessageBox("特征过少，无法完成训练，请重新绘制模板区域", InfoType.Error);
                    return;
                }
            }
            HTuple area, row, col;
            HOperatorSet.AreaCenter(templateRegion, out area, out row, out col);
            followedPose.XY.X = row;
            followedPose.XY.Y = col;
            followedPose.U = 0;

            HOperatorSet.SetSystem("flush_graphic", "false");
        }
        /// <summary>
        /// 在模板窗口显示模板
        /// </summary>
        internal void ShowTemplateAtSmallWindow()
        {
            if (!templateCreated)
            {
                HOperatorSet.ClearWindow(Frm_Template.Instance.hWindowControl1.HalconWindow);
                return;
            }

            HTuple row1, col1, row2, col2;
            HOperatorSet.SmallestRectangle1(templateRegion, out row1, out col1, out row2, out col2);
            HObject rect;
            HOperatorSet.GenRectangle1(out rect, row1 - 20, col1 - 20, row2 + 20, col2 + 20);
            HObject imageReduced;
            HOperatorSet.ReduceDomain(templateImage, rect, out imageReduced);
            HOperatorSet.CropDomain(imageReduced, out imageReduced);
            HOperatorSet.ClearWindow(Frm_Template.Instance.hWindowControl1.HalconWindow);

            double rate = (row2 - row1) / (col2 - col1);
            double value = 0;
            if (rate > 0.75)
                value = (row2 - row1 + 40) / 148.0;
            else
                value = (col2 - col1 + 100) / 198.0;
            HOperatorSet.SetPart(Frm_Template.Instance.hWindowControl1.HalconWindow, -(148 * value - (row2 - row1 + 40)) / 2, -(198 * value - (col2 - col1 + 40)) / 2, 148 * value - (148 * value - (row2 - row1 + 40)) / 2, 198 * value - (198 * value - (col2 - col1 + 40)) / 2);
            HOperatorSet.DispObj(imageReduced, Frm_Template.Instance.hWindowControl1.HalconWindow);

            HOperatorSet.SetDraw(Frm_Template.Instance.hWindowControl1.HalconWindow, new HTuple("margin"));
            HOperatorSet.SetColor(Frm_Template.Instance.hWindowControl1.HalconWindow, new HTuple("green"));
            HOperatorSet.SetLineStyle(Frm_Template.Instance.hWindowControl1.HalconWindow, new HTuple());
            HObject tempTemplateRegion;
            HOperatorSet.MoveRegion(templateRegion, out tempTemplateRegion, -(row1 - 20), -(col1 - 20));
            HOperatorSet.DispObj(tempTemplateRegion, Frm_Template.Instance.hWindowControl1.HalconWindow);

            //显示模板原点
            HTuple area, row, col;
            HOperatorSet.AreaCenter(tempTemplateRegion, out area, out row, out col);
            HObject cross;
            HOperatorSet.GenCrossContourXld(out cross, row, col, (row2 - row1) / 20, 0);
            HOperatorSet.DispObj(cross, Frm_Template.Instance.hWindowControl1.HalconWindow);
        }
        /// <summary>
        /// 运行一次
        /// </summary>
        internal bool RunOnce()
        {
            if (!templateCreated)
            {
                ShowMsg("识别失败，未创建模板", InfoType.Error);
                return false;
            }

            CCamera.FindCamera(calibCamera).SetExposure(((CCamera)Project.FindServiceByName(calibCamera)).exposure, calibCamera);
            HObject image = CCamera.FindCamera(calibCamera).GrabOneImage(calibCamera);
            if (((CCamera)Project.FindServiceByName(calibCamera)).RGBToGray)
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

            if (((CCamera)Project.FindServiceByName(calibCamera)).rotateImage)
            {
                HObject image2;
                HOperatorSet.RotateImage(image, out image2, -((CCamera)Project.FindServiceByName(calibCamera)).rotateAngle, "constant");
                image = image2;
            }

            Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(image);
            Frm_Calibrate.curImage = image;

            HTuple rows, cols, angles, scores;
            HOperatorSet.FindNccModel(Frm_Calibrate.curImage,
                                        modelID,
                                        ((HTuple)(-180)).TupleRad(),
                                        ((HTuple)360).TupleRad(),
                                        (HTuple)0.3,
                                        (HTuple)1,
                                        (HTuple)0.5,
                                        (HTuple)"true",
                                        (HTuple)0,
                                         out rows,
                                         out cols,
                                         out angles,
                                         out scores);

            if (rows.Length > 0)
            {
                lastMatchPos.XY.X = rows[0].D;
                lastMatchPos.XY.Y = cols[0].D;
                lastMatchPos.U = angles[0].D;

                HTuple area, row, col;
                HOperatorSet.AreaCenter(templateRegion, out area, out row, out col);

                //显示模板
                HTuple homMat2D;
                HOperatorSet.HomMat2dIdentity(out homMat2D);
                HOperatorSet.HomMat2dTranslate(homMat2D, -row, -col, out homMat2D);
                HOperatorSet.HomMat2dRotate(homMat2D, angles[0], 0, 0, out homMat2D);
                HOperatorSet.HomMat2dTranslate(homMat2D, rows[0], cols[0], out homMat2D);

                HObject templateRegionAfterTrans;
                HOperatorSet.AffineTransRegion(templateRegion, out templateRegionAfterTrans, homMat2D, "nearest_neighbor");
                Frm_Calibrate.Instance.hWindow_Final1.DispObj(templateRegionAfterTrans, "orange");

                //显示中心十字架
                HObject cross;
                HTuple row1, col1, row2, col2;
                HOperatorSet.GetWindowExtents(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, out row1, out col1, out row2, out col2);
                HOperatorSet.GenCrossContourXld(out cross, rows[0], cols[0], new HTuple((row2 - row1) / 40), new HTuple(angles[0] + templateAngle));

                HOperatorSet.SetDraw(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "margin");
                HOperatorSet.SetLineStyle(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, new HTuple());
                Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross, "orange");

                //查找圆
                HTuple newExpecCircleRow = new HTuple(), newExpectCircleCol = new HTuple(), newExpectCircleRadius = new HTuple();

                //对预期线的起始点做放射变换
                HTuple _homMat2D;
                HOperatorSet.VectorAngleToRigid(followedPose.XY.X, followedPose.XY.Y, followedPose.U, rows[0], cols[0], angles[0], out _homMat2D);
                HTuple tempR, tempC;
                HOperatorSet.AffineTransPixel(_homMat2D, (HTuple)L_regions[0].getModelData()[0], (HTuple)L_regions[0].getModelData()[1], out tempR, out tempC);
                newExpecCircleRow = tempR;
                newExpectCircleCol = tempC;
                newExpectCircleRadius = L_regions[0].getModelData()[2].D;


                List<Circle> L_circles = new List<Circle>();

                HTuple handleID;
                HOperatorSet.CreateMetrologyModel(out handleID);
                HTuple width, height;
                HOperatorSet.GetImageSize(image, out width, out height);
                HOperatorSet.SetMetrologyModelImageSize(handleID, width[0], height[0]);
                HTuple index;
                HOperatorSet.AddMetrologyObjectCircleMeasure(handleID, newExpecCircleRow, newExpectCircleCol, newExpectCircleRadius, new HTuple(30), new HTuple(5), new HTuple(1), new HTuple(30), new HTuple(), new HTuple(), out index);

                //参数设置
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_transition"), new HTuple("positive"));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("num_measures"), new HTuple(30));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length1"), calibCamera == "顶部相机" ? new HTuple(10) : new HTuple(50));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length2"), new HTuple(5));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_threshold"), new HTuple(20));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_select"), new HTuple("last"));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("min_score"), new HTuple(0.3));
                HOperatorSet.ApplyMetrologyModel(image, handleID);

                //显示卡尺
                HObject contours;
                HTuple row3, col3;
                HOperatorSet.GetMetrologyObjectMeasures(out contours, handleID, new HTuple("all"), new HTuple("all"), out row3, out col3);

                HTuple parameter;
                HObject circle;
                HOperatorSet.GetMetrologyObjectResult(handleID, new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"), out parameter);
                HOperatorSet.GetMetrologyObjectResultContour(out circle, handleID, new HTuple("all"), new HTuple("all"), new HTuple(1.5));

                if (Frm_Template.Instance.Visible)
                {
                    Frm_Calibrate.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
                    Frm_Calibrate.Instance.L_regions = L_regions;
                }
                if (parameter.Length >= 3)
                {
                    lastFeaturePos.X = parameter[0];
                    lastFeaturePos.Y = parameter[1];

                    //把点显示出来
                    HObject features;
                    HTuple row4, col4;
                    HOperatorSet.GetMetrologyObjectMeasures(out features, handleID, new HTuple("all"), new HTuple("all"), out row4, out col4);
                    HObject crosses;
                    HTuple row11, col11, row22, col22;
                    HOperatorSet.GetWindowExtents(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, out row11, out col11, out row22, out col22);
                    HOperatorSet.GenCrossContourXld(out crosses, row4, col4, new HTuple((row22 - row11) / 200 + 1), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                    Frm_Calibrate.Instance.hWindow_Final1.DispObj(crosses, "orange");

                    //显示圆
                    HObject circle1;
                    HOperatorSet.GenCircle(out circle1, parameter[0], parameter[1], parameter[2]);
                    HOperatorSet.SetDraw(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "margin");
                    Frm_Calibrate.Instance.hWindow_Final1.DispObj(circle1, "green");

                    //显示圆心
                    HObject cross2;
                    HTuple row6, col6, row7, col7;
                    HOperatorSet.GetWindowExtents(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, out row6, out col6, out row7, out col7);
                    HOperatorSet.GenCrossContourXld(out cross2, parameter[0], parameter[1], new HTuple((row7 - row6) / 5), new HTuple(0));        //小细节：我们要想使无论图像像素多大，显示的十字大小都是一样的，就需要得出y=kx+b中的k和b
                    Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross2, "green");
                }
                else
                {
                    Frm_Calibrate.Instance.hWindow_Final1.DispObj(contours, "red");
                    return false;
                }

                HOperatorSet.ClearMetrologyModel(handleID);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 执行标定
        /// </summary>
        internal void StartCalibrate()
        {
            Thread th = new Thread(() =>
            {
                if (CCamera.FindCamera(calibCamera).loopGrab)
                    CCamera.FindCamera(calibCamera).loopGrab = false;

                giveupCalibrate = false;
                Frm_Calibrate.Instance.tbx_log.Clear();
                ShowMsg("01  开始标定", InfoType.Tip);
                if (calibType == "自动标定")
                {
                    if (calibMode == "眼在手外")
                    {
                        #region 自动标定 眼在手外

                        Calibrate1();

                        #endregion
                    }
                    else
                    {
                        #region 自动标定 眼在手上

                        Calibrate2();

                        #endregion
                    }
                }
                else
                {
                    if (calibMode == "眼在手外")
                    {
                        #region 手动标定 眼在手外



                        #endregion
                    }
                    else
                    {
                        #region 手动标定 眼在手上



                        #endregion
                    }
                }
            });
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 自动标定 眼在手外
        /// </summary>
        private void Calibrate1()
        {
            //检查模板是否已创建
            if (!templateCreated)
            {
                ShowMsg(string.Format("01  标定失败，未创建标定模板，请检查"), InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            if (Frm_Template.Instance.Visible)
                Frm_Template.Instance.Close();

            Frm_Calibrate.Instance.hWindow_Final1.ClearWindow();
            D_point.Clear();
            L_XYPixel.Clear();
            L_XYRobot.Clear();
            L_UPixel.Clear();
            for (int i = 0; i < XYPointNum; i++)
            {
                switch (i)
                {
                    case 0:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X, moveCenterPos.Y));
                        break;
                    case 1:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X + moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X + moveSpan;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X + moveSpan, moveCenterPos.Y));
                        break;
                    case 2:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X + moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y + moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X + moveSpan;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y + moveSpan;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X + moveSpan, moveCenterPos.Y + moveSpan));
                        break;
                    case 3:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y + moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y + moveSpan;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X, moveCenterPos.Y + moveSpan));
                        break;
                    case 4:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X - moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y + moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X - moveSpan;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y + moveSpan;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X - moveSpan, moveCenterPos.Y + moveSpan));
                        break;
                    case 5:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X - moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X - moveSpan;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X - moveSpan, moveCenterPos.Y));
                        break;
                    case 6:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X - moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y - moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X - moveSpan;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y - moveSpan;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X - moveSpan, moveCenterPos.Y - moveSpan));
                        break;
                    case 7:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y - moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y - moveSpan;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X, moveCenterPos.Y - moveSpan));
                        break;
                    case 8:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X + moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y - moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X + moveSpan;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y - moveSpan;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X + moveSpan, moveCenterPos.Y - moveSpan));
                        break;
                }

                if (giveupCalibrate)
                {
                    ShowMsg(string.Format("{0}  标定已停止", (2 + i).ToString("00")), InfoType.Tip);
                    Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                    Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                    return;
                }

                if (!RunOnce())
                {
                    ShowMsg(string.Format("{0}  标定失败，XY标定点 C{1} 特征点识别失败，请检查", (2 + i).ToString("00"), i + 1), InfoType.Error);
                    Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                    Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                    return;
                }

                if (giveupCalibrate)
                {
                    ShowMsg(string.Format("{0}  标定已停止", (2 + i).ToString("00")), InfoType.Tip);
                    Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                    Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                    return;
                }

                XY pixelPos = new XY();
                pixelPos.X = lastFeaturePos.X;
                pixelPos.Y = lastFeaturePos.Y;

                //添加到点集合，并显示点
                Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(Frm_Calibrate.Instance.hWindow_Final1.currentImage);
                D_point.Add("C" + (i + 1), new XY((float)pixelPos.X, (float)pixelPos.Y));
                foreach (KeyValuePair<string, XY> item in D_point)
                {
                    HObject cross;
                    HOperatorSet.GenCrossContourXld(out cross, item.Value.X, item.Value.Y, 60, new HTuple(0));
                    Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross, "blue");
                    HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, item.Key, 15, item.Value.X + 10, item.Value.Y + 10, "blue", "false");
                }
                HObject cross2;
                HOperatorSet.GenCrossContourXld(out cross2, pixelPos.X, pixelPos.Y, 60, new HTuple(0));
                Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross2, "green");
                HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "C" + (i + 1), 15, pixelPos.X + 10, pixelPos.Y + 10, "green", "false");


                if (Frm_CalibData.hasShown)
                {
                    Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[0].Value = pixelPos.X.ToString("0000.000");
                    Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[1].Value = pixelPos.Y.ToString("0000.000");
                }
                L_XYPixel.Add(new XY(pixelPos.X, pixelPos.Y));
                ShowMsg(string.Format("{0}  运动机构已到达XY标定点 C{1} ，当前像素坐标为：{2} , {3}", (2 + i).ToString("00"), i + 1, pixelPos.X, pixelPos.Y), InfoType.Tip);
            }

            //检查识别到的九个像素点是否构成阵列，不是阵列的话说明识别出错
            if (true)
            {
                ShowMsg((XYPointNum + 2) + "  平移标定过程阵列检查已通过", InfoType.Tip);
            }
            else
            {
                ShowMsg((XYPointNum + 2) + "  标定失败，平移标定过程阵列检查不通过，请检查", InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            //执行第一次标定
            HTuple tempHomMat2D;
            List<double> L_pixelRow = new List<double>();
            List<double> L_pixelCol = new List<double>();
            List<double> L_MechanicalX = new List<double>();
            List<double> L_MechanicalY = new List<double>();

            for (int i = 0; i < L_XYPixel.Count; i++)
            {
                L_pixelRow.Add(L_XYPixel[i].X);
                L_pixelCol.Add(L_XYPixel[i].Y);
                L_MechanicalX.Add(L_XYRobot[i].X);
                L_MechanicalY.Add(L_XYRobot[i].Y);
            }

            HTuple pixelRow = new HTuple(L_pixelRow.ToArray());
            HTuple pixelCol = new HTuple(L_pixelCol.ToArray());
            HTuple mechanicalX = new HTuple(L_MechanicalX.ToArray());
            HTuple mechanicalY = new HTuple(L_MechanicalY.ToArray());

            try
            {
                HOperatorSet.VectorToHomMat2d(pixelRow, pixelCol, mechanicalX, mechanicalY, out tempHomMat2D);
            }
            catch
            {
                ShowMsg((XYPointNum + 3) + "  标定失败，标定数据无法确定仿射变换关系，请检查", InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            //开始角度标定
            //三点定圆
            List<XY> points = new List<XY>();
            for (int i = 0; i < UPointNum; i++)
            {
                switch (i)
                {
                    case 0:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, rotateCenterPos.X, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, rotateCenterPos.Y, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, rotateCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, rotateCenterPos.U, 10, true);
                        break;
                    case 1:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, rotateCenterPos.X, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, rotateCenterPos.Y, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, rotateCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, rotateCenterPos.U - 2 * rotateSpan, 10, true);
                        break;
                    case 2:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, rotateCenterPos.X, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, rotateCenterPos.Y, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, rotateCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, rotateCenterPos.U - rotateSpan, 10, true);
                        break;
                    case 3:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, rotateCenterPos.X, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, rotateCenterPos.Y, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, rotateCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, rotateCenterPos.U + rotateSpan, 10, true);
                        break;
                    case 4:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, rotateCenterPos.X, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, rotateCenterPos.Y, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, rotateCenterPos.Z, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, rotateCenterPos.U + 2 * rotateSpan, 10, true);
                        break;
                }

                if (giveupCalibrate)
                {
                    ShowMsg(string.Format("{0}  标定已停止", (2 + i).ToString("00")), InfoType.Tip);
                    Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                    Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                    return;
                }

                if (!RunOnce())
                {
                    ShowMsg(string.Format("{0}  标定失败，U标定点 CT{1} 特征点识别失败，请检查", (3 + XYPointNum + i).ToString("00"), i + 1), InfoType.Error);
                    Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                    Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                    return;
                }

                if (giveupCalibrate)
                {
                    ShowMsg(string.Format("{0}  标定已停止", (2 + i).ToString("00")), InfoType.Tip);
                    Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                    Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                    return;
                }

                XY pixelPos = new XY();
                pixelPos.X = lastFeaturePos.X;
                pixelPos.Y = lastFeaturePos.Y;
                points.Add(new XY(pixelPos.X, pixelPos.Y));

                //添加到点集合，并显示点
                Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(Frm_Calibrate.Instance.hWindow_Final1.currentImage);
                D_point.Add("CT" + (i + 1), new XY(pixelPos.X, pixelPos.Y));
                foreach (KeyValuePair<string, XY> item in D_point)
                {
                    HObject cross;
                    HOperatorSet.GenCrossContourXld(out cross, item.Value.X, item.Value.Y, 60, new HTuple(0));
                    Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross, "blue");
                    HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, item.Key, 15, item.Value.X + 10, item.Value.Y + 10, "blue", "false");
                }
                HObject cross2;
                HOperatorSet.GenCrossContourXld(out cross2, pixelPos.X, pixelPos.Y, 60, new HTuple(0));
                Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross2, "green");
                HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "CT" + (i + 1), 15, pixelPos.X + 10, pixelPos.Y + 10, "green", "false");

                if (Frm_CalibData.hasShown)
                {
                    Frm_CalibData.Instance.dgv_rotateData.Rows[i].Cells[0].Value = pixelPos.X.ToString("0000.000");
                    Frm_CalibData.Instance.dgv_rotateData.Rows[i].Cells[1].Value = pixelPos.Y.ToString("0000.000");
                }
                L_UPixel.Add(new XY(pixelPos.X, pixelPos.Y));
                ShowMsg(string.Format("{0}  运动机构已到达U标定点 CT{1} ，当前像素坐标为：{2} , {3}", (3 + XYPointNum + i).ToString("00"), i + 1, pixelPos.X, pixelPos.Y), InfoType.Tip);
            }

            //多点求圆心
            XY center = FitCenter(points);
            HObject cross1;
            HOperatorSet.GenCrossContourXld(out cross1, center.X, center.Y, 50, new HTuple(0));
            Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross1, "blue");

            //如果是多余3点的拟合，可以判断一下圆度，不够圆就说明可以识别出错
            if (true)
            {
                ShowMsg((XYPointNum + UPointNum + 3) + "  旋转标定过程圆度检查已通过", InfoType.Tip);
            }
            else
            {
                ShowMsg((XYPointNum + UPointNum + 3) + "  标定失败，旋转标定过程圆度检查不通过，请检查", InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            HTuple rowAfterTrans, colAfterTrans;
            HOperatorSet.AffineTransPoint2d(tempHomMat2D, center.X, center.Y, out rowAfterTrans, out colAfterTrans);

            double spanX = rotateCenterPos.X - rowAfterTrans.D;
            double spanY = rotateCenterPos.Y - colAfterTrans.D;

            //执行第二次标定
            L_pixelRow.Clear();
            L_pixelCol.Clear();
            L_MechanicalX.Clear();
            L_MechanicalY.Clear();
            for (int i = 0; i < XYPointNum; i++)
            {
                L_pixelRow.Add(L_XYPixel[i].X);
                L_pixelCol.Add(L_XYPixel[i].Y);
                L_MechanicalX.Add(L_XYRobot[i].X + spanX);
                L_MechanicalY.Add(L_XYRobot[i].Y + spanY);
            }

            try
            {
                pixelRow = new HTuple(L_pixelRow.ToArray());
                pixelCol = new HTuple(L_pixelCol.ToArray());
                mechanicalX = new HTuple(L_MechanicalX.ToArray());
                mechanicalY = new HTuple(L_MechanicalY.ToArray());

                HOperatorSet.VectorToHomMat2d(pixelRow, pixelCol, mechanicalX, mechanicalY, out homMat2D);
            }
            catch
            {
                ShowMsg((XYPointNum + UPointNum + 4) + "  标定失败，标定数据无法确定仿射变换关系，请检查", InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            HTuple scanX, scanY, rotation, theta, translateX, translateY;
            try
            {
                HOperatorSet.HomMat2dToAffinePar(homMat2D, out scanX, out scanY, out rotation, out theta, out translateX, out translateY);
            }
            catch
            {
                ShowMsg((XYPointNum + UPointNum + 4) + "  标定失败，标定数据无法确定仿射变换关系，请检查", InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            if (Frm_CalibResult.hasShown)
            {
                Frm_CalibResult.Instance.lbl_scaleX.Text = (scanX.D).ToString("0.000");
                Frm_CalibResult.Instance.lbl_scaleY.Text = (scanY.D).ToString("0.000");
                Frm_CalibResult.Instance.lbl_rotate.Text = (rotation.D).ToString("0.000");
                Frm_CalibResult.Instance.lbl_theta.Text = (theta.D).ToString("0.000");
                Frm_CalibResult.Instance.lbl_moveX.Text = (translateX.D).ToString("0.000");
                Frm_CalibResult.Instance.lbl_moveY.Text = (translateY.D).ToString("0.000");
            }

            //检查标定结果是否正常
            if (Math.Abs(scanX.D - scanY.D) > 0.02)
            {
                ShowMsg((XYPointNum + UPointNum + 4) + "  标定失败，标定结果XY方向缩放比例相差太大，这并不正常，请检查", InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);

                if (!Frm_CalibResult.hasShown)
                {
                    Frm_CalibResult.hasShown = true;
                    Frm_CalibResult.Instance.Location = new Point(Frm_System.Instance.Location.X - 86, Frm_System.Instance.Location.Y + 35);
                    Frm_CalibResult.Instance.ShowPar(this);
                    Frm_CalibResult.Instance.Show();
                }

                return;
            }

            //执行精度测试过程
            XYZU testPos = new XYZU();
            testPos.X = moveCenterPos.X;
            testPos.Y = moveCenterPos.Y;
            testPos.Z = moveCenterPos.Z;
            testPos.U = moveCenterPos.U;

            //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
            //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X, 10, true);
            //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y, 10, true);
            //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);
            //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);

            if (giveupCalibrate)
            {
                ShowMsg(string.Format("{0}  标定已停止", (2).ToString("00")), InfoType.Tip);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            if (!RunOnce())
            {
                ShowMsg(string.Format("{0}  标定失败，标定测试点特征点识别失败，请检查", (XYPointNum + UPointNum + 4).ToString("00")), InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            if (giveupCalibrate)
            {
                ShowMsg(string.Format("{0}  标定已停止", (2).ToString("00")), InfoType.Tip);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            XY pixelPos1 = new XY();
            pixelPos1.X = lastFeaturePos.X;
            pixelPos1.Y = lastFeaturePos.Y;

            //添加到点集合，并显示点
            Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(Frm_Calibrate.Instance.hWindow_Final1.currentImage);
            D_point.Add("CTT" + (XYPointNum + UPointNum + 4), new XY(pixelPos1.X, pixelPos1.Y));
            foreach (KeyValuePair<string, XY> item in D_point)
            {
                HObject cross;
                HOperatorSet.GenCrossContourXld(out cross, item.Value.X, item.Value.Y, 60, new HTuple(0));
                Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross, "green");
                HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, item.Key, 15, item.Value.X + 10, item.Value.Y + 10, "green", "false");
            }
            HObject cross3;
            HOperatorSet.GenCrossContourXld(out cross3, pixelPos1.X, pixelPos1.Y, 60, new HTuple(0));
            Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross3, "green");
            HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "CTT" + (XYPointNum + UPointNum + 4), 15, pixelPos1.X + 10, pixelPos1.Y + 10, "green", "false");
            ShowMsg(string.Format("{0}  运动机构已到达标定测试点 CTT ，当前像素坐标为：{1} , {2}", (XYPointNum + UPointNum + 4).ToString("00"), pixelPos1.X, pixelPos1.Y), InfoType.Tip);

            HOperatorSet.AffineTransPoint2d(homMat2D, (HTuple)pixelPos1.X, (HTuple)pixelPos1.Y, out rowAfterTrans, out colAfterTrans);
            offsetX = Math.Round((rowAfterTrans.D - testPos.X) - spanX, 3);
            offsetY = Math.Round((colAfterTrans.D - testPos.Y) - spanY, 3);

            calibrated = true;

            ShowMsg("标定完成，报告如下：", InfoType.Tip);
            ShowMsg("标定日期：" + DateTime.Now.ToString(), InfoType.Tip);
            ShowMsg("标定人员：" + Permission.CurPermissionGrade.ToString(), InfoType.Tip);
            if (Math.Abs(offsetX) < 0.05 && Math.Abs(offsetY) < 0.05)
            {
                calibLevel = "A 级(精度极好)";
                ShowMsg("标定误差：X 误差：" + offsetX + " mm    Y 误差：" + offsetY + " mm", InfoType.Warn);
                ShowMsg("精度等级：A 级(精度极好)", InfoType.Warn);
            }
            else
            {
                if (Math.Abs(offsetX) < 0.1 && Math.Abs(offsetY) < 0.1)
                {
                    calibLevel = "B 级(精度一般)";
                    ShowMsg("标定误差：X 误差：" + offsetX + " mm    Y 误差：" + offsetY + " mm", InfoType.Warn);
                    ShowMsg("精度等级：B 级(精度较好)", InfoType.Warn);
                }
                else
                {
                    if (Math.Abs(offsetX) < 0.15 && Math.Abs(offsetY) < 0.15)
                    {
                        calibLevel = "C 级(精度较差)";
                        ShowMsg("标定误差：X 误差：" + offsetX + " mm    Y 误差：" + offsetY + " mm", InfoType.Warn);
                        ShowMsg("精度等级：C 级(精度一般)", InfoType.Warn);
                    }
                    else
                    {
                        if (Math.Abs(offsetX) < 0.2 && Math.Abs(offsetY) < 0.2)
                        {
                            calibLevel = "D 级(精度极差)";
                            ShowMsg("标定误差：X 误差：" + offsetX + " mm    Y 误差：" + offsetY + " mm", InfoType.Error);
                            ShowMsg("精度等级：D 级(精度较差)", InfoType.Error);
                        }
                        else
                        {
                            calibLevel = "精度不通过";
                            ShowMsg("标定误差：X 误差：" + offsetX + " mm    Y 误差：" + offsetY + " mm", InfoType.Error);
                            ShowMsg("精度等级：精度不通过", InfoType.Error);
                        }
                    }
                }
            }

            Frm_CalibType.Instance.Close();
            Frm_CalibData.Instance.Close();
            Frm_Template.Instance.Close();

            Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
            Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
        }
        /// <summary>
        /// 自动标定 眼在手上
        /// </summary>
        private void Calibrate2()
        {
            //检查模板是否已创建
            if (!templateCreated)
            {
                ShowMsg(string.Format("{0}  标定失败，未创建标定模板，请检查", 0), InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            if (Frm_Template.Instance.Visible)
                Frm_Template.Instance.Close();

            Frm_Calibrate.Instance.hWindow_Final1.ClearWindow();
            D_point.Clear();
            L_XYPixel.Clear();
            L_XYRobot.Clear();
            L_UPixel.Clear();
            Frm_CalibData.Instance.dgv_moveData.Rows.Clear();
            Frm_CalibData.Instance.dgv_moveData.Rows.Add(XYPointNum);
            for (int i = 0; i < XYPointNum; i++)
            {
                //控制机器人依次前往标定点
                switch (i)
                {
                    case 0:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X + moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y + moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X + moveSpan, moveCenterPos.Y + moveSpan));
                        break;
                    case 1:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X + moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y - moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X + moveSpan;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y - moveSpan;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X + moveSpan, moveCenterPos.Y - moveSpan));
                        break;
                    case 2:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X - moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y + moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X - moveSpan;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y + moveSpan;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X - moveSpan, moveCenterPos.Y + moveSpan));
                        break;
                    case 3:
                        //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                        //////FuncLib.MoveAbs(Axis.X, moveCenterPos.X - moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.Y, moveCenterPos.Y - moveSpan, 10, true);
                        //////FuncLib.MoveAbs(Axis.U, moveCenterPos.U, 10, true);
                        //////FuncLib.MoveAbs(Axis.Z, moveCenterPos.Z, 10, true);

                        if (Frm_CalibData.hasShown)
                        {
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[2].Value = moveCenterPos.X - moveSpan;
                            Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[3].Value = moveCenterPos.Y + moveSpan;
                        }
                        L_XYRobot.Add(new XY(moveCenterPos.X - moveSpan, moveCenterPos.Y - moveSpan));
                        break;
                }

                if (giveupCalibrate)
                {
                    ShowMsg(string.Format("{0}  标定已停止", (2 + i).ToString("00")), InfoType.Tip);
                    Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                    Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                    return;
                }

                if (!RunOnce())
                {
                    ShowMsg(string.Format("{0}  标定失败，XY标定点 C{1} 特征点识别失败，请检查", (2 + i).ToString("00"), i + 1), InfoType.Error);
                    Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                    Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                    return;
                }

                if (giveupCalibrate)
                {
                    ShowMsg(string.Format("{0}  标定已停止", (2 + i).ToString("00")), InfoType.Tip);
                    Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                    Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                    return;
                }

                XY pixelPos = new XY();
                pixelPos.X = lastFeaturePos.X;
                pixelPos.Y = lastFeaturePos.Y;

                //添加到点集合，并显示点
                Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(Frm_Calibrate.Instance.hWindow_Final1.currentImage);
                D_point.Add("C" + (i + 1), new XY((float)pixelPos.X, (float)pixelPos.Y));
                HObject cross;
                foreach (KeyValuePair<string, XY> item in D_point)
                {
                    HOperatorSet.GenCrossContourXld(out cross, item.Value.X, item.Value.Y, 60, new HTuple(0));
                    Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross, "green");
                    HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, item.Key, 15, item.Value.X + 10, item.Value.Y + 10, "blue", "false");
                }
                HOperatorSet.GenCrossContourXld(out cross, pixelPos.X, pixelPos.Y, 60, new HTuple(0));
                Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross, "green");
                HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "C" + (i + 1), 15, pixelPos.X + 10, pixelPos.Y + 10, "blue", "false");

                HObject cross2;
                HOperatorSet.GenCrossContourXld(out cross2, pixelPos.X, pixelPos.Y, 60, new HTuple(0));
                Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross2, "green");
                HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "C" + (i + 1), 15, pixelPos.X + 10, pixelPos.Y + 10, "green", "false");

                if (Frm_CalibData.hasShown)
                {
                    Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[0].Value = pixelPos.X.ToString("0000.000");
                    Frm_CalibData.Instance.dgv_moveData.Rows[i].Cells[1].Value = pixelPos.Y.ToString("0000.000");
                }
                L_XYPixel.Add(new XY(pixelPos.X, pixelPos.Y));
                ShowMsg(string.Format("{0}  运动机构已到达XY标定点 C{1} ，当前像素坐标为：{2} , {3}", (2 + i).ToString("00"), i + 1, pixelPos.X, pixelPos.Y), InfoType.Tip);
            }

            //检查识别到的九个像素点是否构成阵列，不是阵列的话说明识别出错
            if (true)
            {
                ShowMsg((XYPointNum + 2).ToString("00") + "  平移标定过程阵列检查已通过", InfoType.Tip);
            }
            else
            {
                ShowMsg((XYPointNum + 2).ToString("00") + "  标定失败，平移标定过程阵列检查不通过，请检查", InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            //执行标定
            HTuple tempHomMat2D;
            List<double> L_pixelRow = new List<double>();
            List<double> L_pixelCol = new List<double>();
            List<double> L_MechanicalX = new List<double>();
            List<double> L_MechanicalY = new List<double>();

            double baseX = Convert.ToDouble(L_XYRobot[0].X);
            double baseY = Convert.ToDouble(L_XYRobot[0].Y);
            for (int i = 0; i < L_XYPixel.Count; i++)
            {
                L_pixelRow.Add(L_XYPixel[i].X);
                L_pixelCol.Add(L_XYPixel[i].Y);
                L_MechanicalX.Add(baseX - (L_XYRobot[i].X - baseX));
                L_MechanicalY.Add(baseY - (L_XYRobot[i].Y - baseY));
            }

            HTuple pixelRow = new HTuple(L_pixelRow.ToArray());
            HTuple pixelCol = new HTuple(L_pixelCol.ToArray());
            HTuple mechanicalX = new HTuple(L_MechanicalX.ToArray());
            HTuple mechanicalY = new HTuple(L_MechanicalY.ToArray());

            try
            {
                HOperatorSet.VectorToHomMat2d(pixelRow, pixelCol, mechanicalX, mechanicalY, out tempHomMat2D);
            }
            catch
            {
                ShowMsg((XYPointNum + 3).ToString("00") + "  标定失败，标定数据无法确定仿射变换关系，请检查", InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            HTuple scanX, scanY, rotation, theta, translateX, translateY;
            try
            {
                HOperatorSet.HomMat2dToAffinePar(tempHomMat2D, out scanX, out scanY, out rotation, out theta, out translateX, out translateY);
            }
            catch
            {
                ShowMsg((XYPointNum + 3).ToString("00") + "  标定失败，标定数据无法确定仿射变换关系，请检查", InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            Frm_CalibResult.Instance.lbl_scaleX.Text = (scanX.D).ToString("0.000");
            Frm_CalibResult.Instance.lbl_scaleY.Text = (scanY.D).ToString("0.000");
            Frm_CalibResult.Instance.lbl_rotate.Text = (rotation.D).ToString("0.000");
            Frm_CalibResult.Instance.lbl_theta.Text = (theta.D).ToString("0.000");
            Frm_CalibResult.Instance.lbl_moveX.Text = (translateX.D).ToString("0.000");
            Frm_CalibResult.Instance.lbl_moveY.Text = (translateY.D).ToString("0.000");

            //检查标定结果是否正常
            if (Math.Abs(scanX.D - scanY.D) > 0.02)
            {
                ShowMsg((XYPointNum + 4).ToString("00") + "  标定失败，标定结果XY方向缩放比例相差太大，这并不正常，请检查", InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);

                if (!Frm_CalibResult.Instance.Visible)
                {
                    Frm_CalibType.Instance.Close();
                    Frm_CalibData.Instance.Close();
                    Frm_Template.Instance.Close();

                    Frm_CalibResult.Instance.Location = new Point(Frm_System.Instance.Location.X - 86, Frm_System.Instance.Location.Y + 35);
                    Frm_CalibResult.Instance.ShowPar(this);
                    Frm_CalibResult.Instance.ShowDialog();
                }

                return;
            }

            //执行精度测试过程
            XYZU testPos = new XYZU();
            testPos.X = moveCenterPos.X;
            testPos.Y = moveCenterPos.Y;
            testPos.Z = moveCenterPos.Z;
            testPos.U = moveCenterPos.U;

            //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
            //////FuncLib.MoveAbs(Axis.X, testPos.X, 10, true);
            //////FuncLib.MoveAbs(Axis.Y, testPos.Y, 10, true);
            //////FuncLib.MoveAbs(Axis.U, testPos.U, 10, true);
            //////FuncLib.MoveAbs(Axis.Z, testPos.Z, 10, true);

            if (giveupCalibrate)
            {
                ShowMsg(string.Format("{0}  标定已停止", (2).ToString("00")), InfoType.Tip);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            if (!RunOnce())
            {
                ShowMsg(string.Format("{0}  标定失败，标定测试点特征点识别失败，请检查", (XYPointNum + 4).ToString("00")), InfoType.Error);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            if (giveupCalibrate)
            {
                ShowMsg(string.Format("{0}  标定已停止", (2).ToString("00")), InfoType.Tip);
                Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
                Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
                return;
            }

            XY pixelPos1 = new XY();
            pixelPos1.X = lastFeaturePos.X;
            pixelPos1.Y = lastFeaturePos.Y;

            //添加到点集合，并显示点
            Frm_Calibrate.Instance.hWindow_Final1.HobjectToHimage(Frm_Calibrate.Instance.hWindow_Final1.currentImage);
            D_point.Add("CTT" + (XYPointNum + 4), new XY(pixelPos1.X, pixelPos1.Y));
            HObject cross4;
            foreach (KeyValuePair<string, XY> item in D_point)
            {
                HOperatorSet.GenCrossContourXld(out cross4, item.Value.X, item.Value.Y, 60, new HTuple(0));
                Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross4, "green");
                HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, item.Key, 15, item.Value.X + 10, item.Value.Y + 10, "green", "false");
            }
            HOperatorSet.GenCrossContourXld(out cross4, pixelPos1.X, pixelPos1.Y, 60, new HTuple(0));
            Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross4, "green");
            HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "CTT" + (XYPointNum + 4), 15, pixelPos1.X + 10, pixelPos1.Y + 10, "blue", "false");

            HObject cross3;
            HOperatorSet.GenCrossContourXld(out cross3, pixelPos1.X, pixelPos1.Y, 60, new HTuple(0));
            Frm_Calibrate.Instance.hWindow_Final1.DispObj(cross3, "green");
            HalconLib.DispText(Frm_Calibrate.Instance.hWindow_Final1.HWindowHalconID, "CTT" + (XYPointNum + 4), 15, pixelPos1.X + 10, pixelPos1.Y + 10, "green", "false");

            ShowMsg(string.Format("{0}  运动机构已到达标定测试点 CTT ，当前像素坐标为：{1} , {2}", (XYPointNum + 4).ToString("00"), pixelPos1.X, pixelPos1.Y), InfoType.Tip);

            HTuple rowAfterTrans, colAfterTrans;
            HOperatorSet.AffineTransPoint2d(tempHomMat2D, (HTuple)pixelPos1.X, (HTuple)pixelPos1.Y, out rowAfterTrans, out colAfterTrans);
            offsetX = Math.Round((rowAfterTrans.D - testPos.X) / 2 - moveSpan, 3);
            offsetY = Math.Round((colAfterTrans.D - testPos.Y) / 2 - moveSpan, 3);

            homMat2D = tempHomMat2D;
            calibrated = true;

            ShowMsg("标定完成，报告如下：", InfoType.Tip);
            ShowMsg("标定日期：" + DateTime.Now.ToString(), InfoType.Tip);
            ShowMsg("标定人员：" + Permission.CurPermissionGrade.ToString(), InfoType.Tip);
            if (Math.Abs(offsetX) < 0.02 && Math.Abs(offsetY) < 0.02)
            {
                calibLevel = "A 级(精度极好)";
                ShowMsg("标定误差：X 误差：" + offsetX + " mm    Y 误差：" + offsetY + " mm", InfoType.Warn);
                ShowMsg("精度等级：A 级(精度极好)", InfoType.Warn);
            }
            else
            {
                if (Math.Abs(offsetX) < 0.05 && Math.Abs(offsetY) < 0.04)
                {
                    calibLevel = "B 级(精度一般)";
                    ShowMsg("标定误差：X 误差：" + offsetX + " mm    Y 误差：" + offsetY + " mm", InfoType.Warn);
                    ShowMsg("精度等级：B 级(精度较好)", InfoType.Warn);
                }
                else
                {
                    if (Math.Abs(offsetX) < 0.08 && Math.Abs(offsetY) < 0.08)
                    {
                        calibLevel = "C 级(精度较差)";
                        ShowMsg("标定误差：X 误差：" + offsetX + " mm    Y 误差：" + offsetY + " mm", InfoType.Warn);
                        ShowMsg("精度等级：C 级(精度一般)", InfoType.Warn);
                    }
                    else
                    {
                        if (Math.Abs(offsetX) < 0.12 && Math.Abs(offsetY) < 0.12)
                        {
                            calibLevel = "D 级(精度极差)";
                            ShowMsg("标定误差：X 误差：" + offsetX + " mm    Y 误差：" + offsetY + " mm", InfoType.Error);
                            ShowMsg("精度等级：D 级(精度较差)", InfoType.Error);
                        }
                        else
                        {
                            calibLevel = "精度不通过";
                            ShowMsg("标定误差：X 误差：" + offsetX + " mm    Y 误差：" + offsetY + " mm", InfoType.Error);
                            ShowMsg("精度等级：精度不通过", InfoType.Error);
                        }
                    }
                }
            }

            Frm_CalibType.Instance.Close();
            Frm_CalibData.Instance.Close();
            Frm_Template.Instance.Close();

            Frm_Calibrate.Instance.btn_calibrate.Text = "执行标定";
            Frm_Calibrate.Instance.btn_calibrate.FillColor = Color.FromArgb(80, 160, 255);
        }
        /// <summary>
        /// 多点拟合圆
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public static XY FitCenter(List<XY> pts, double epsilon = 0.1)
        {
            double totalX = 0, totalY = 0;
            int setCount = 0;

            for (int i = 0; i < pts.Count; i++)
            {
                for (int j = 1; j < pts.Count; j++)
                {
                    for (int k = 2; k < pts.Count; k++)
                    {
                        double delta = (pts[k].X - pts[j].X) * (pts[j].Y - pts[i].Y) - (pts[j].X - pts[i].X) * (pts[k].Y - pts[j].Y);

                        if (Math.Abs(delta) > epsilon)
                        {
                            double ii = Math.Pow(pts[i].X, 2) + Math.Pow(pts[i].Y, 2);
                            double jj = Math.Pow(pts[j].X, 2) + Math.Pow(pts[j].Y, 2);
                            double kk = Math.Pow(pts[k].X, 2) + Math.Pow(pts[k].Y, 2);

                            double cx = ((pts[k].Y - pts[j].Y) * ii + (pts[i].Y - pts[k].Y) * jj + (pts[j].Y - pts[i].Y) * kk) / (2 * delta);
                            double cy = -((pts[k].X - pts[j].X) * ii + (pts[i].X - pts[k].X) * jj + (pts[j].X - pts[i].X) * kk) / (2 * delta);

                            totalX += cx;
                            totalY += cy;

                            setCount++;
                        }
                    }
                }
            }

            if (setCount == 0)
            {
                return new XY();
            }

            return new XY((float)totalX / setCount, (float)totalY / setCount);
        }
        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="infoType"></param>
        internal void ShowMsg(string msg, InfoType infoType)
        {
            Frm_Calibrate.Instance.tbx_log.SelectionStart = Frm_Calibrate.Instance.tbx_log.Text.Length;
            Frm_Calibrate.Instance.tbx_log.SelectionLength = 0;
            switch (infoType)
            {
                case InfoType.Tip:
                    Frm_Calibrate.Instance.tbx_log.SelectionColor = Color.FromArgb(48, 48, 48);
                    Project.tipNum++;
                    break;
                case InfoType.Warn:
                    Frm_Calibrate.Instance.tbx_log.SelectionColor = Color.Green;
                    Project.warnNum++;
                    break;
                case InfoType.Error:
                    Frm_Calibrate.Instance.tbx_log.SelectionColor = Color.Red;
                    Project.errorNum++;
                    break;
            }

            if (Frm_Calibrate.Instance.tbx_log.Text == string.Empty)
                Frm_Calibrate.Instance.tbx_log.AppendText("  " + msg);
            else
                Frm_Calibrate.Instance.tbx_log.AppendText(Environment.NewLine + "  " + msg);
            Frm_Calibrate.Instance.tbx_log.ScrollToCaret();
            calibInfo = Frm_Calibrate.Instance.tbx_log.Text;
        }
    }
}
