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

namespace VM_Pro
{
    public partial class Frm_About : UIForm
    {
        public Frm_About()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_About _instance;
        internal static Frm_About Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_About();
                return _instance;
            }
        }


        private void Frm_About_Load(object sender, EventArgs e)
        {
            //显示版本号     版本号根据exe的生成时间自动变化
            string date = File.GetLastWriteTime(Application.StartupPath + "\\VM Pro.exe").ToString("yyyy-MM-dd");
            lbl_version.Text = string.Format("版         本 :  VM Pro {0} {1} 开发版", date, ((AssemblyConfigurationAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false))[0]).Configuration);
            lbl_regiestStatu.Text = (Regiest.regiested ? "已激活" : "未激活");
            lbl_regiestStatu.ForeColor = (Regiest.regiested ? Color.Green : Color.Red);
        }

    }
}
