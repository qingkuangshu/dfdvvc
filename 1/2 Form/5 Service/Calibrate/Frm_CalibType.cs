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
    public partial class Frm_CalibType : UIForm
    {
        public Frm_CalibType()
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
        private static Frm_CalibType _instance;
        internal static Frm_CalibType Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_CalibType();
                return _instance;
            }
        }


        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="calibrate"></param>
        internal void ShowPar(Calibrate calibrate)
        {
            //加载相机
            cbx_cameraList.Items.Clear();
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                    cbx_cameraList.Items.Add(Project.Instance.L_Service[i].name);
            }

            Frm_CalibType.calibrate = calibrate;
            cbx_calibType.Text = calibrate.calibType;
            cbx_calibMode.Text = calibrate.calibMode;
            cbx_cameraList.Text = calibrate.calibCamera;

            if (cbx_calibType.Text == "自动标定")
            {
                Instance.uiLine1.Visible = true;
                Instance.uiLine2.Visible = true;

                Instance.label4.Visible = true;
                Instance.label8.Visible = true;
                Instance.label9.Visible = true;

                Instance.tbx_moveX.Visible = true;
                Instance.tbx_moveY.Visible = true;
                Instance.tbx_moveSpan.Visible = true;

                Instance.label10.Visible = true;
                Instance.label13.Visible = true;
                Instance.label14.Visible = true;

                Instance.label5.Visible = true;
                Instance.label6.Visible = true;
                Instance.label7.Visible = true;

                Instance.tbx_rotateX.Visible = true;
                Instance.tbx_rotateY.Visible = true;
                Instance.tbx_rotateSpan.Visible = true;

                Instance.label15.Visible = true;
                Instance.label16.Visible = true;
            }
            else
            {
                Instance.uiLine1.Visible = false;
                Instance.uiLine2.Visible = false;

                Instance.label4.Visible = false;
                Instance.label8.Visible = false;
                Instance.label9.Visible = false;

                Instance.tbx_moveX.Visible = false;
                Instance.tbx_moveY.Visible = false;
                Instance.tbx_moveSpan.Visible = false;

                Instance.label10.Visible = false;
                Instance.label13.Visible = false;
                Instance.label14.Visible = false;

                Instance.label5.Visible = false;
                Instance.label6.Visible = false;
                Instance.label7.Visible = false;

                Instance.tbx_rotateX.Visible = false;
                Instance.tbx_rotateY.Visible = false;
                Instance.tbx_rotateSpan.Visible = false;

                Instance.label15.Visible = false;
                Instance.label16.Visible = false;
            }

            if (calibrate.calibMode == "眼在手上")
            {
                uiLine1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                tbx_rotateX.Visible = false;
                tbx_rotateY.Visible = false;
                tbx_rotateSpan.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                btn_touchRotatePos.Visible = false;
                btn_goRotatePos.Visible = false;
                label14.Visible = false;
                tbx_rotateZ.Visible = false;
                tbx_rotateU.Visible = false;
            }
            else
            {
                uiLine1.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                tbx_rotateX.Visible = true;
                tbx_rotateY.Visible = true;
                tbx_rotateSpan.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                btn_touchRotatePos.Visible = true;
                btn_goRotatePos.Visible = true;
                label14.Visible = true;
                tbx_rotateZ.Visible = true;
                tbx_rotateU.Visible = true;
            }

            tbx_moveX.Text = calibrate.moveCenterPos.X.ToString();
            tbx_moveY.Text = calibrate.moveCenterPos.Y.ToString();
            tbx_moveZ.Text = calibrate.moveCenterPos.Z.ToString();
            tbx_moveU.Text = calibrate.moveCenterPos.U.ToString();
            tbx_moveSpan.Text = calibrate.moveSpan.ToString();

            tbx_rotateX.Text = calibrate.rotateCenterPos.X.ToString();
            tbx_rotateY.Text = calibrate.rotateCenterPos.Y.ToString();
            tbx_rotateZ.Text = calibrate.rotateCenterPos.Z.ToString();
            tbx_rotateU.Text = calibrate.rotateCenterPos.U.ToString();
            tbx_rotateSpan.Text = calibrate.rotateSpan.ToString();

            Frm_Template.Instance.rdo_basedCircleCenter.Checked = calibrate.basedCircleCenter;
            Frm_Template.Instance.rdo_baseLineCross.Checked = !calibrate.basedCircleCenter;

            if (Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                label1.Visible = true;
                label2.Visible = true;
                label147.Visible = true;
                cbx_calibMode.Visible = true;
                cbx_calibType.Visible = true;
                cbx_cameraList.Visible = true;
                label4.Visible = true;
                label10.Visible = true;
                tbx_moveSpan.Visible = true;
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;
                label147.Visible = false;
                cbx_calibMode.Visible = false;
                cbx_calibType.Visible = false;
                cbx_cameraList.Visible = false;
                label5.Visible = false;
                label15.Visible = false;
                tbx_rotateSpan.Visible = false;
                label4.Visible = false;
                label10.Visible = false;
                tbx_moveSpan.Visible = false;
            }

            Frm_System.Instance.TopMost = false;
        }


        private void cbx_calibType_SelectedIndexChanged(object sender, EventArgs e)
        {
            calibrate.calibType = cbx_calibType.Text;

            if (cbx_calibType.SelectedIndex == 0)
            {
                Instance.uiLine1.Visible = true;
                Instance.uiLine2.Visible = true;

                Instance.label4.Visible = true;
                Instance.label8.Visible = true;
                Instance.label9.Visible = true;

                Instance.tbx_moveX.Visible = true;
                Instance.tbx_moveY.Visible = true;
                Instance.tbx_moveSpan.Visible = true;

                Instance.label10.Visible = true;
                Instance.label13.Visible = true;
                Instance.label14.Visible = true;

                Instance.label5.Visible = true;
                Instance.label6.Visible = true;
                Instance.label7.Visible = true;

                Instance.tbx_rotateX.Visible = true;
                Instance.tbx_rotateY.Visible = true;
                Instance.tbx_rotateSpan.Visible = true;

                Instance.label15.Visible = true;
                Instance.label16.Visible = true;
            }
            else
            {
                Instance.uiLine1.Visible = false;
                Instance.uiLine2.Visible = false;

                Instance.label4.Visible = false;
                Instance.label8.Visible = false;
                Instance.label9.Visible = false;

                Instance.tbx_moveX.Visible = false;
                Instance.tbx_moveY.Visible = false;
                Instance.tbx_moveSpan.Visible = false;

                Instance.label10.Visible = false;
                Instance.label13.Visible = false;
                Instance.label14.Visible = false;

                Instance.label5.Visible = false;
                Instance.label6.Visible = false;
                Instance.label7.Visible = false;

                Instance.tbx_rotateX.Visible = false;
                Instance.tbx_rotateY.Visible = false;
                Instance.tbx_rotateSpan.Visible = false;

                Instance.label15.Visible = false;
                Instance.label16.Visible = false;
            }
        }
        private void cbx_calibMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            calibrate.calibMode = cbx_calibMode.Text;

            if (calibrate.calibMode == "眼在手上")
            {
                calibrate.XYPointNum = 4;

                uiLine1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                tbx_rotateX.Visible = false;
                tbx_rotateY.Visible = false;
                tbx_rotateSpan.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                btn_touchRotatePos.Visible = false;
                btn_goRotatePos.Visible = false;
                label14.Visible = false;
                tbx_rotateZ.Visible = false;
                tbx_rotateU.Visible = false;
            }
            else
            {
                calibrate.XYPointNum = 9;

                uiLine1.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                tbx_rotateX.Visible = true;
                tbx_rotateY.Visible = true;
                tbx_rotateSpan.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                btn_touchRotatePos.Visible = true;
                btn_goRotatePos.Visible = true;
                label14.Visible = true;
                tbx_rotateZ.Visible = true;
                tbx_rotateU.Visible = true;
            }
        }
        private void cbx_cameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            calibrate.calibCamera = cbx_cameraList.Text;
        }

        private void tbx_moveX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calibrate.moveCenterPos.X = Convert.ToDouble(tbx_moveX.Text.Trim());
            }
            catch { }
        }
        private void tbx_moveY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calibrate.moveCenterPos.Y = Convert.ToDouble(tbx_moveY.Text.Trim());
            }
            catch { }
        }
        private void tbx_moveSpan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(tbx_moveSpan.Text.Trim()) > 200)
                {
                    FuncLib.ShowMessageBox("写入失败！平移量过大，这可能不安全");
                    return;
                }

                calibrate.moveSpan = Convert.ToDouble(tbx_moveSpan.Text.Trim());
            }
            catch { }
        }
        private void tbx_moveZ_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calibrate.moveCenterPos.Z = Convert.ToDouble(tbx_moveZ.Text.Trim());
            }
            catch { }
        }
        private void tbx_moveU_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calibrate.moveCenterPos.U = Convert.ToDouble(tbx_moveU.Text.Trim());
            }
            catch { }
        }
        private void btn_touchMovePos_Click(object sender, EventArgs e)
        {
            //////tbx_moveX.Text = FuncLib.GetCmdPos(Axis.X).ToString();
            //////tbx_moveY.Text = FuncLib.GetCmdPos(Axis.Y).ToString();
            //////tbx_moveZ.Text = FuncLib.GetCmdPos(Axis.Z).ToString();
            //////tbx_moveU.Text = FuncLib.GetCmdPos(Axis.U).ToString();
        }
        private void btn_goMovePos_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                //前往目标点
                btn_goMovePos.Enabled = false;

                //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                //////FuncLib.MoveAbs(Axis.X, calibrate.moveCenterPos.X, 10, true);
                //////FuncLib.MoveAbs(Axis.Y, calibrate.moveCenterPos.Y, 10, true);
                //////FuncLib.MoveAbs(Axis.U, calibrate.moveCenterPos.U, 10, true);
                //////FuncLib.MoveAbs(Axis.Z, calibrate.moveCenterPos.Z, 10, true);

                btn_goMovePos.Enabled = true;

            });
            th.IsBackground = true;
            th.Start();
        }

        private void tbx_rotateX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calibrate.rotateCenterPos.X = Convert.ToDouble(tbx_rotateX.Text.Trim());
            }
            catch { }
        }
        private void tbx_rotateY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calibrate.rotateCenterPos.Y = Convert.ToDouble(tbx_rotateY.Text.Trim());
            }
            catch { }
        }
        private void tbx_rotateZ_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calibrate.rotateCenterPos.Z = Convert.ToDouble(tbx_rotateZ.Text.Trim());
            }
            catch { }
        }
        private void tbx_rotateU_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calibrate.rotateCenterPos.U = Convert.ToDouble(tbx_rotateU.Text.Trim());
            }
            catch { }
        }
        private void tbx_rotateSpan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(tbx_rotateSpan.Text.Trim()) > 60)
                {
                    FuncLib.ShowMessageBox("写入失败！旋转量过大，这可能不安全");
                    return;
                }

                calibrate.rotateSpan = Convert.ToDouble(tbx_rotateSpan.Text.Trim());
            }
            catch { }
        }
        private void btn_touchRotatePos_Click(object sender, EventArgs e)
        {
            //////tbx_rotateX.Text = FuncLib.GetCmdPos(Axis.X).ToString();
            //////tbx_rotateY.Text = FuncLib.GetCmdPos(Axis.Y).ToString();
            //////tbx_rotateZ.Text = FuncLib.GetCmdPos(Axis.Z).ToString();
            //////tbx_rotateU.Text = FuncLib.GetCmdPos(Axis.U).ToString();
        }
        private void btn_goRotatePos_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                //前往目标点
                btn_goRotatePos.Enabled = false;

                //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 10, true);
                //////FuncLib.MoveAbs(Axis.X, calibrate.rotateCenterPos.X, 10, true);
                //////FuncLib.MoveAbs(Axis.Y, calibrate.rotateCenterPos.Y, 10, true);
                //////FuncLib.MoveAbs(Axis.Z, calibrate.rotateCenterPos.Z, 10, true);
                //////FuncLib.MoveAbs(Axis.U, calibrate.rotateCenterPos.U, 10, true);

                btn_goRotatePos.Enabled = true;

            });
            th.IsBackground = true;
            th.Start();
        }

        private void Frm_MorePar_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

    }
}
