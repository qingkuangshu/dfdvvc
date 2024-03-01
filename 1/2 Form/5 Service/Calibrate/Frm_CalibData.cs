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
    public partial class Frm_CalibData : UIForm
    {
        public Frm_CalibData()
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
        private static Frm_CalibData _instance;
        internal static Frm_CalibData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_CalibData();
                return _instance;
            }
        }


        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="calibrate"></param>
        internal void ShowPar(Calibrate calibrate)
        {
            Frm_CalibData.calibrate = calibrate;

            Instance.nud_movePointNum.Value = calibrate.XYPointNum;
            Instance.nud_rotatePointNum.Value = calibrate.UPointNum;

            if (calibrate.L_XYPixel.Count == calibrate.XYPointNum)
            {
                for (int i = 0; i < calibrate.XYPointNum; i++)
                {
                    dgv_moveData.Rows[i].Cells[0].Value = i + 1;
                    dgv_moveData.Rows[i].Cells[1].Value = calibrate.L_XYPixel[i].X.ToString("000.000");
                    dgv_moveData.Rows[i].Cells[2].Value = calibrate.L_XYPixel[i].Y.ToString("000.000");
                    dgv_moveData.Rows[i].Cells[3].Value = calibrate.L_XYRobot[i].X.ToString("000.000");
                    dgv_moveData.Rows[i].Cells[4].Value = calibrate.L_XYRobot[i].Y.ToString("000.000");
                }
            }

            if (calibrate.L_UPixel.Count == calibrate.UPointNum && calibrate.calibMode == "眼在手外")
            {
                for (int i = 0; i < calibrate.UPointNum; i++)
                {
                    dgv_rotateData.Rows[i].Cells[0].Value = i + 1;
                    dgv_rotateData.Rows[i].Cells[1].Value = calibrate.L_UPixel[i].X.ToString("000.000");
                    dgv_rotateData.Rows[i].Cells[2].Value = calibrate.L_UPixel[i].Y.ToString("000.000");
                }
            }

            if (calibrate.calibMode == "眼在手上")
            {
                label9.Visible = false;
                label10.Visible = false;
                nud_rotatePointNum.Visible = false;
                dgv_rotateData.Visible = false;
            }
            else
            {
                label9.Visible = true;
                label10.Visible = true;
                nud_rotatePointNum.Visible = true;
                dgv_rotateData.Visible = true;
            }
            Frm_System.Instance.TopMost = false;
        }


        private void nud_movePointNum_ValueChanged(double value)
        {
            if (dgv_moveData.Rows.Count < (int)value)
            {
                dgv_moveData.Rows.Add((int)value - dgv_moveData.Rows.Count);
            }
            else
            {
                while (dgv_moveData.Rows.Count > (int)value)
                {
                    dgv_moveData.Rows.RemoveAt(dgv_moveData.Rows.Count - 1);
                }
            }
            calibrate.XYPointNum = (int)value;
        }
        private void nud_rotatePointNum_ValueChanged(double value)
        {
            if (dgv_rotateData.Rows.Count < (int)value)
            {
                dgv_rotateData.Rows.Add((int)value - dgv_rotateData.Rows.Count);
            }
            else
            {
                while (dgv_rotateData.Rows.Count > (int)value)
                {
                    dgv_rotateData.Rows.RemoveAt(dgv_rotateData.Rows.Count - 1);
                }
            }
            calibrate.UPointNum = (int)value;
        }
        private void Frm_MorePar_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

    }
}
