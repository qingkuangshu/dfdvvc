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
    public partial class Frm_CalibResult : UIForm
    {
        public Frm_CalibResult()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        /// <summary>
        /// 窗体是否处于显示状态
        /// </summary>
        internal static bool hasShown = false;
        /// <summary>
        /// 标定对象
        /// </summary>
        internal static Calibrate calibrate;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_CalibResult _instance;
        internal static Frm_CalibResult Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new Frm_CalibResult();
                return _instance;
            }
        }


        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="calibrate"></param>
        internal void ShowPar(Calibrate calibrate)
        {
            Frm_CalibResult.calibrate = calibrate;

            if (calibrate.homMat2D != null)
            {
                HTuple scanX, scanY, rotation, theta, translateX, translateY;
                HOperatorSet.HomMat2dToAffinePar(calibrate.homMat2D, out scanX, out scanY, out rotation, out theta, out translateX, out translateY);

                lbl_moveX.Text = translateX.D.ToString("0.000");
                lbl_moveY.Text = translateY.D.ToString("0.000");
                lbl_scaleX.Text = scanX.D.ToString("0.000");
                lbl_scaleY.Text = scanY.D.ToString("0.000");
                lbl_rotate.Text = rotation.D.ToString("0.000");
                lbl_theta.Text = theta.D.ToString("0.000");
            }
            else
            {
                lbl_moveX.Text = "0.000";
                lbl_moveY.Text = "0.000";
                lbl_scaleX.Text = "0.000";
                lbl_scaleY.Text = "0.000";
                lbl_rotate.Text = "0.000";
                lbl_theta.Text = "0.000";
            }
            lbl_accuracyX.Text = calibrate.offsetX.ToString("0.000");
            lbl_accuracyY.Text = calibrate.offsetY.ToString("0.000");
            lbl_accuracyLevel.Text = calibrate.calibLevel;
            switch (calibrate.calibLevel)
            {
                case "A 级(极好)":
                case "B 级(较好)":
                case "C 级(一般)":
                    lbl_accuracyLevel.ForeColor = Color.Green;
                    break;
                case "D 级(较差)":
                case "E 级(极差)":
                case "标定不通过":
                case "未标定":
                    lbl_accuracyLevel.ForeColor = Color.Red;
                    break;
            }
            Frm_System.Instance.TopMost = false;
        }
        private void Frm_CalibResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
        }


    }
}
