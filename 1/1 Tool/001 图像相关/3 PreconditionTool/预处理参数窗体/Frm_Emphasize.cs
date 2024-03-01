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
    public partial class Frm_Emphasize : Form
    {
        public Frm_Emphasize()
        {
            InitializeComponent();
        }
        private static Frm_Emphasize _instance;

        internal static Frm_Emphasize Instance
        {

            get
            {
                if (_instance == null)
                    _instance = new Frm_Emphasize();
                return _instance;
            }
        }

        private void TB_Width_Scroll(object sender, EventArgs e)
        {
            lb_width.Text = TB_Width.Value.ToString();
            Frm_PreconditionTool.Instance.ShowDgvData(TB_Width.Value + "," + TB_Height.Value + "," + (TB_Factor.Value / 10.0));
        }

        private void TB_Height_Scroll(object sender, EventArgs e)
        {
            lb_height.Text = TB_Height.Value.ToString();
            Frm_PreconditionTool.Instance.ShowDgvData(TB_Width.Value + "," + TB_Height.Value + "," + (TB_Factor.Value / 10.0));
        }

        private void TB_Factor_Scroll(object sender, EventArgs e)
        {
            lb_factor.Text = (TB_Factor.Value / 10.0).ToString();
            Frm_PreconditionTool.Instance.ShowDgvData(TB_Width.Value + "," + TB_Height.Value + "," + (TB_Factor.Value / 10.0));
        }
    }
}
