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
    public partial class Frm_Help : UIForm
    {
        public Frm_Help()
        {
            InitializeComponent();
        }

        private static Frm_Help _instance;

        public static Frm_Help Instance 
        {
            get 
            {
                if (_instance == null)
                    _instance = new Frm_Help();
                return _instance;
            }
        }

        private void Frm_Help_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
