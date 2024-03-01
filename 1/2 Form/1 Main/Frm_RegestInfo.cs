using Sunny.UI;
using System;
using System.Windows.Forms;
using Tool;

namespace VM_Pro
{
    public partial class Frm_RegestInfo : UIForm
    {
        public Frm_RegestInfo()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗体是否已显示
        /// </summary>
        internal static bool hasShown = false;


        private void Frm_RegestInfo_Load(object sender, EventArgs e)
        {
            Ini ini = new Ini(Application.StartupPath + "\\Config\\SysConfig.ini");
            string startDate = ini.IniReadConfig("StartDate");
            int regiestNum = Convert.ToInt16(ini.IniReadConfig("RegiestNum"));
            int useDay = 0;
            switch (regiestNum)
            {
                case -1:
                    useDay = -1;        //永久使用
                    break;
                case 0:
                    useDay = 90 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
                    break;
                case 1:
                    useDay = 45 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
                    break;
                case 2:
                    useDay = 22 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
                    break;
                case 3:
                    useDay = 11 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
                    break;
                case 4:
                    useDay = 5 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
                    break;
                case 5:
                    useDay = 2 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
                    break;
                case 6:
                    useDay = 1 - (DateTime.Now - Convert.ToDateTime(startDate)).Days;
                    break;
            }
            if (useDay == -1)
            {
                linkLabel1.Visible = false;
                lbl_info.Text = string.Format("激活日期：{0}\r\n使用期限：永久使用\r\n说       明：软件已激活！可无限期永久使用", startDate, useDay);
            }
            else
            {
                linkLabel1.Visible = true;
                lbl_info.Text = string.Format("激活日期：{0}\r\n使用期限：剩余 {1} 天\r\n说       明：到期后将影响正常使用，请及时联系厂家处理", startDate, useDay);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Frm_Regiest.hasShown = true;
            new Frm_Regiest().Show();
        }

        private void Frm_RegestInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
        }

    }
}
