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
    public partial class Frm_Input : UIForm
    {
        public Frm_Input()
        {
            InitializeComponent();
        }

        private void Frm_Input_Load(object sender, EventArgs e)
        {
            tbx_input.Select();
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}
