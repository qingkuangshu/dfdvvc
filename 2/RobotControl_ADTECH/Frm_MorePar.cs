using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotControl
{
    public partial class Frm_MorePar : Form
    {
        public Frm_MorePar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 机器人控制对象
        /// </summary>
        internal static RobotControl_Base robotControl;
        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static Frm_MorePar _instance;
        public static Frm_MorePar Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new Frm_MorePar();
                return _instance;
            }
        }

        private void btn_goSafeHeight_Click(object sender, EventArgs e)
        {
            if (!robotControl.MoveZToPos(robotControl.safeHeight, robotControl.velLevel / 2, true))
            {
                lbl_statu.Text = "运动失败";
                lbl_statu.ForeColor = Color.Red;
            }
            else
            {
                lbl_statu.Text = "正常";
                lbl_statu.ForeColor = Color.Green;
            }
        }
        private void btn_saveSafeHeight_Click(object sender, EventArgs e)
        {
            RobotPos curPos;
            if (!robotControl.GetCurPos(out curPos))
            {
                lbl_statu.Text = "示教失败";
                lbl_statu.ForeColor = Color.Red;
                return;
            }
            robotControl.safeHeight = curPos.xyzu.Z;
            tbx_safeHeight.Text = curPos.xyzu.Z.ToString();
            robotControl.WritePar();
        }
        private void tbx_robotIP_TextChanged(object sender, EventArgs e)
        {
            robotControl.robotIP = tbx_robotIP.Text.Trim();
            robotControl.WritePar();
        }
        private void tbx_robotPort_TextChanged(object sender, EventArgs e)
        {
            try
            {
                robotControl.robotPort = Convert.ToInt32(tbx_robotPort.Text.Trim());
                robotControl.WritePar();
            }
            catch { }
        }
        private void tbx_password_TextChanged(object sender, EventArgs e)
        {
            robotControl.loginPassword = tbx_password.Text.Trim();
            robotControl.WritePar();
        }
        private void tbx_safeHeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                robotControl.safeHeight = Convert.ToDouble(tbx_safeHeight.Text.Trim());
                robotControl.WritePar();
            }
            catch { }
        }
        private void Frm_MorePar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

    }
}
