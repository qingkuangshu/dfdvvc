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
using MvCamCtrl.NET;

namespace VM_Pro
{
    public partial class Frm_MorePar : UIForm
    {
        public Frm_MorePar()
        {
            InitializeComponent();
            this.TopMost = true;

        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_MorePar _instance;
        internal static Frm_MorePar Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_MorePar();
                return _instance;
            }
        }
        /// <summary>
        /// 相机对象
        /// </summary>
        internal static CCamera ccamera;
        /// <summary>
        /// 正在加载窗体
        /// </summary>
        internal static bool isLoading = false;


        /// <summary>
        /// 加载参数
        /// </summary>
        internal static void LoadPara()
        {
            Instance.tbx_row1.Value = ccamera.row1;
            Instance.tbx_col1.Value = ccamera.col1;
            Instance.tbx_row2.Value = ccamera.row2;
            Instance.tbx_col2.Value = ccamera.col2;
            Instance.nud_gain.Value = ccamera.gain;
            Instance.ckb_rotateImage.Checked = ccamera.rotateImage;
            Instance.nud_rotateAngle.Value = ccamera.rotateAngle;
            Instance.ckb_RGBToGray.Checked = ccamera.RGBToGray;
            //判断一下当前相机是否为海康相机，如果是的话，则把硬触发模式显示出来
            if (ccamera.cameraInfoStr.Contains("MV"))
            {
                Instance.ckb_hardTrigServer.Visible = true;
                Instance.pan_HardLineSelect.Visible = Instance.ckb_hardTrigServer.Checked = ccamera.hardTrigServer;
                //线型复现选择
                switch (ccamera.hardLine)
                {
                    case CCamera.EHaridHardLine.Line0:
                        Instance.rad_line0.Checked = true;
                        break;
                    case CCamera.EHaridHardLine.Line1:
                        Instance.rad_line1.Checked = true;
                        break;
                    case CCamera.EHaridHardLine.Line2:
                        Instance.rad_line2.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Instance.ckb_hardTrigServer.Visible = false;
            }
        }


        private void tbx_row1_ValueChanged(double value)
        {
            ccamera.row1 = (int)value;
        }
        private void tbx_col1_ValueChanged(double value)
        {
            ccamera.col1 = (int)value;
        }
        private void tbx_row2_ValueChanged(double value)
        {
            ccamera.row2 = (int)value;
        }
        private void tbx_col2_ValueChanged(double value)
        {
            ccamera.col2 = (int)value;
        }
        private void nud_gain_ValueChanged(double value)
        {
            ccamera.gain = (int)value;
        }
        private void ckb_rotateImage_CheckedChanged(object sender, EventArgs e)
        {
            ccamera.rotateImage = ckb_rotateImage.Checked;

            nud_rotateAngle.Visible = ccamera.rotateImage;
            uiLabel2.Visible = ccamera.rotateImage;
        }
        private void nud_rotateAngle_ValueChanged(double value)
        {
            if (isLoading)
                return;

            ccamera.rotateAngle = (int)nud_rotateAngle.Value;

            if (!ccamera.Connected)
                return;

            if (!Frm_Camera.isGrabing)
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

                    lock (ccamera.obj)
                    {
                        Frm_Camera.isGrabing = true;
                        Stopwatch sw = new Stopwatch();
                        sw.Start();

                        ccamera.GetCurCamera().SetGain(ccamera.gain, ccamera.name);
                        ccamera.GetCurCamera().SetExposure(ccamera.exposure, ccamera.name);
                        ccamera.GetCurCamera().SetAcqRegion(ccamera.row1, ccamera.col1, ccamera.row2, ccamera.col2, ccamera.name);
                        HObject image = ccamera.GetCurCamera().GrabOneImage(ccamera.name);

                        //旋转图像
                        if (ccamera.rotateImage)
                            HOperatorSet.RotateImage(image, out image, -ccamera.rotateAngle, "constant");

                        //彩色图像转灰度图像
                        if (ccamera.RGBToGray)
                        {
                            HTuple chNum;
                            HOperatorSet.CountChannels(image, out chNum);
                            if (chNum == 3)
                                HOperatorSet.Rgb1ToGray(image, out image);
                        }

                        Frm_Camera.Instance.hWindow_Final1.HobjectToHimage(image);

                        sw.Stop();
                        Frm_Camera.Instance.lbl_elapsedTime.Text = sw.ElapsedMilliseconds + " ms";
                        Frm_Camera.isGrabing = false;
                    }
                    Frm_Loading.Instance.Hide();
                    nud_rotateAngle.SelectText();
                });
                th.IsBackground = true;
                th.Start();
            }
        }
        private void ckb_RGBToGray_CheckedChanged(object sender, EventArgs e)
        {
            ccamera.RGBToGray = ckb_RGBToGray.Checked;
        }
        private void Frm_MorePar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void ckb_rotateImage_Click(object sender, EventArgs e)
        {
            if (!ccamera.Connected)
                return;

            if (!Frm_Camera.isGrabing)
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

                    lock (ccamera.obj)
                    {
                        Frm_Camera.isGrabing = true;
                        Stopwatch sw = new Stopwatch();
                        sw.Start();

                        ccamera.GetCurCamera().SetGain(ccamera.gain, ccamera.name);
                        ccamera.GetCurCamera().SetExposure(ccamera.exposure, ccamera.name);
                        ccamera.GetCurCamera().SetAcqRegion(ccamera.row1, ccamera.col1, ccamera.row2, ccamera.col2, ccamera.name);
                        HObject image = ccamera.GetCurCamera().GrabOneImage(ccamera.name);

                        //旋转图像
                        if (ccamera.rotateImage)
                            HOperatorSet.RotateImage(image, out image, -ccamera.rotateAngle, "constant");

                        //彩色图像转灰度图像
                        if (ccamera.RGBToGray)
                        {
                            HTuple chNum;
                            HOperatorSet.CountChannels(image, out chNum);
                            if (chNum == 3)
                                HOperatorSet.Rgb1ToGray(image, out image);
                        }

                        Frm_Camera.Instance.hWindow_Final1.HobjectToHimage(image);

                        sw.Stop();
                        Frm_Camera.Instance.lbl_elapsedTime.Text = sw.ElapsedMilliseconds + " ms";
                        Frm_Camera.isGrabing = false;
                    }
                    Frm_Loading.Instance.Hide();
                });
                th.IsBackground = true;
                th.Start();
            }
        }

        private void ckb_hardTrigServer_CheckedChanged(object sender, EventArgs e)
        {
            ccamera.hardTrigServer = ckb_hardTrigServer.Checked;
            MyCamera my_camera = SDK_HIKVision.GetHiKCamera(ccamera.cameraInfoStr, ckb_hardTrigServer.Checked);
            if (my_camera == null)
            {
                UIMessageTip.ShowError("找不到当前海康相机，请检查其名称是否正确...");
                return;
            }
            if (ccamera.hardTrigServer)   //如果是选择了硬触发模式的话
            {
                this.pan_HardLineSelect.Visible = true;     //显示硬触发线型选择
                my_camera.MV_CC_SetEnumValue_NET("AcquisitionMode", 2);

                //先设置硬触发的参数，然后再注册回调函数
                my_camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);    //设置为外触发模式
                switch (ccamera.hardLine)
                {
                    case CCamera.EHaridHardLine.Line0:
                        my_camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
                        break;
                    case CCamera.EHaridHardLine.Line1:
                        my_camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE1);
                        break;
                    case CCamera.EHaridHardLine.Line2:
                        my_camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE2);
                        break;
                    default:
                        my_camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
                        break;
                }
                //设置上升沿触发
                my_camera.MV_CC_SetEnumValue_NET("TriggerActivation", 0);
                //滤波处理，去除毛刺信号 单位us
                my_camera.MV_CC_SetEnumValue_NET("LineSelector", 0);
                my_camera.MV_CC_SetIntValue_NET("LineDebouncerTime", 5000);
            }
            else
            {
                this.pan_HardLineSelect.Visible = false;    //隐藏硬触发线型选择
                //将当前相机更改为软触发模式
                my_camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
            }
        }

        private void rad_line0_Click(object sender, EventArgs e)
        {
            UIRadioButton rad = sender as UIRadioButton;
            if (rad != null)
            {
                switch (rad.Name)
                {
                    case "rad_line0":
                        ccamera.hardLine = CCamera.EHaridHardLine.Line0;
                        //此处还要将海康的线触发信号改为Line0
                        break;
                    case "rad_line1":
                        ccamera.hardLine = CCamera.EHaridHardLine.Line1;
                        break;
                    case "rad_line2":
                        ccamera.hardLine = CCamera.EHaridHardLine.Line2;
                        break;
                }
                ckb_hardTrigServer_CheckedChanged(null, null);
            }
        }
    }
}
