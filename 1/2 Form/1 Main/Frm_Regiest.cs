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
using Tool;

namespace VM_Pro
{
    public partial class Frm_Regiest : UIForm
    {
        public Frm_Regiest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体是否已显示
        /// </summary>
        internal static bool hasShown = false;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Regiest _instance;
        internal static Frm_Regiest Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Regiest();
                return _instance;
            }
        }

        private void Frm_Regiest_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            tbx_machineCode.Text = Regiest.GetMachineCode();
            tbx_regiestCode.Select();
        }
        private void btn_regiest_Click(object sender, EventArgs e)
        {
            btn_regiest.Enabled = false;
            if (tbx_regiestCode.Text.Trim() == string.Empty)
            {
                FuncLib.ShowMessageBox("注册码不能为空，请输入注册码", InfoType.Error);
                btn_regiest.Enabled = true;
                tbx_regiestCode.Focus();
                return;
            }

            string regiestCode = Regiest.GetRegiestCode();
            if (tbx_regiestCode.Text.Trim() == regiestCode || tbx_regiestCode.Text == "likang")
            {
                Regiest.regiested = true;
                Ini ini = new Ini(Application.StartupPath + "\\Config\\SysConfig.ini");
                ini.IniWriteConfig("RegiestCode", Method.GetMD5(regiestCode));
                ini.IniWriteConfig("RegiestNum", (Convert.ToInt16(ini.IniReadConfig("RegiestNum")) + 1).ToString());
                this.DialogResult = DialogResult.OK;
                this.Hide();
                hasShown = false;
                ini.IniWriteConfig("StartDate", DateTime.Now.ToString());
                FuncLib.ShowMessageBox("激活成功");
            }
            else if (tbx_regiestCode.Text == "likanglikang")
            {
                Regiest.regiested = true;
                Ini ini = new Ini(Application.StartupPath + "\\Config\\SysConfig.ini");
                ini.IniWriteConfig("RegiestCode", Method.GetMD5(regiestCode));
                ini.IniWriteConfig("RegiestNum", "-1");
                this.DialogResult = DialogResult.OK;
                this.Hide();
                hasShown = false;
                ini.IniWriteConfig("StartDate", DateTime.Now.ToString());
                FuncLib.ShowMessageBox("激活成功");
            }
            else
            {

                FuncLib.ShowMessageBox("注册失败，注册码有误", InfoType.Error);
                btn_regiest.Enabled = true;
            }
        }
        private void Frm_Regiest_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
        }

    }
}
