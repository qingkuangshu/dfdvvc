using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class FrmResolution : Form
    {
        public FrmResolution()
        {
            InitializeComponent();
        }

        private static FrmResolution _instance;

        public static FrmResolution Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new FrmResolution();
                }
                return _instance;
            }
        
        }

        private void txt_ImgHeight_DoEnter(object sender, EventArgs e)
        {
            Frm_PreconditionTool.Instance.ShowDgvData(txt_ImgWidth.Text.ToString() + "," + txt_ImgHeight.Text.ToString());
        }

        private void txt_ImgHeight_TextChanged(object sender, EventArgs e)
        {
            if (txt_ImgHeight.Focused && txt_ImgWidth.Text.ToString() !="" && txt_ImgHeight.Text.ToString() !="")
            {
                Frm_PreconditionTool.Instance.ShowDgvData(txt_ImgWidth.Text.ToString() + "," + txt_ImgHeight.Text.ToString());
            }
        }
    }
}
