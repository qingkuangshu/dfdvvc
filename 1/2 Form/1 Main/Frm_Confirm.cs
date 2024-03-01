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
    public partial class Frm_Confirm : UIForm
    {
        public Frm_Confirm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 是否已显示
        /// </summary>
        internal static bool isShown = false;


        private void btn_no_Click(object sender, EventArgs e)
        {
            isShown = false;
            this.DialogResult = DialogResult.No;
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            isShown = false;
            this.DialogResult = DialogResult.OK;
        }
        private void Frm_Confirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isShown = false;
        }

    }
}
