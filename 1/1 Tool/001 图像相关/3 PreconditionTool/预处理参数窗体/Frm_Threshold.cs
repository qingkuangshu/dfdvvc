using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_Threshold : Form
    {
        public Frm_Threshold()
        {
            InitializeComponent();
        }


        private static Frm_Threshold _instance;

        internal static Frm_Threshold Instance
        {

            get
            {
                if (_instance == null)
                    _instance = new Frm_Threshold();
                return _instance;
            }
        }

        

        private void Ckb_HeiBai_Click(object sender, EventArgs e)
        {

            Frm_PreconditionTool.Instance.ShowDgvData(TB_Low.Value + "," + TB_Hig.Value + "," + Convert.ToInt32(Ckb_HeiBai.Checked));

        }


        private void TB_Hig_Scroll(object sender, EventArgs e)
        {
            if (TB_Low.Value > TB_Hig.Value)
            {
                TB_Hig.Value = 255;
            }
            lb_HigValue.Text = TB_Hig.Value.ToString();
            Frm_PreconditionTool.Instance.ShowDgvData(TB_Low.Value + "," + TB_Hig.Value + "," + Convert.ToInt32(Ckb_HeiBai.Checked));
        }

        private void TB_Low_Scroll(object sender, EventArgs e)
        {
            if (TB_Low.Value > TB_Hig.Value)
            {
                TB_Low.Value = 1;
            }
            lb_LowValue.Text = TB_Low.Value.ToString();
            Frm_PreconditionTool.Instance.ShowDgvData(TB_Low.Value + "," + TB_Hig.Value + "," + Convert.ToInt32(Ckb_HeiBai.Checked));

        }
    }
}
