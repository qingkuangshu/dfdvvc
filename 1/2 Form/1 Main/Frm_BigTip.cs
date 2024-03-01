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

namespace VM_Pro
{
    public partial class Frm_BigTip : UIForm
    {
        public Frm_BigTip()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_BigTip _instance;
        internal static Frm_BigTip Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new Frm_BigTip();
                return _instance;
            }
        }

        private void Frm_BigTip_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                Instance.Close();
            return true;
        }
    }
}
