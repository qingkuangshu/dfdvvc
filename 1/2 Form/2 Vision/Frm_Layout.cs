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
    public partial class Frm_Layout : UIForm
    {
        public Frm_Layout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Layout _instance;
        internal static Frm_Layout Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Layout();
                return _instance;
            }
        }


        private void Frm_Layout_Load(object sender, EventArgs e)
        {
            switch (Scheme.curScheme.windowLayout)
            {
                case WindowLayout.OneWindow:
                    rdo_one.Checked = true;
                    uiPanel1.FillColor = Color.DimGray;
                    break;
                case WindowLayout.TwoWindow:
                    rdo_two.Checked = true;
                    uiPanel2.FillColor = Color.DimGray;
                    break;
                case WindowLayout.ForeWindow:
                    rdo_fore.Checked = true;
                    uiPanel3.FillColor = Color.DimGray;
                    break;
                case WindowLayout.SixWindow:
                    rdo_six.Checked = true;
                    uiPanel4.FillColor = Color.DimGray;
                    break;
                case WindowLayout.EightWindow:
                    rdo_eight.Checked = true;
                    uiPanel5.FillColor = Color.DimGray;
                    break;
                case WindowLayout.NineWindow:
                    rdo_nine.Checked = true;
                    uiPanel6.FillColor = Color.DimGray;
                    break;
                case WindowLayout.TwelveWindow:
                    rdo_twelve.Checked = true;
                    uiPanel7.FillColor = Color.DimGray;
                    break;
                case WindowLayout.SixteenWindow:
                    rdo_Sixteen.Checked = true;
                    uiPanel8.FillColor = Color.DimGray;
                    break;
            }
        }
        private void rdo_one_CheckedChanged(object sender, EventArgs e)
        {
            Scheme.curScheme.windowLayout = WindowLayout.OneWindow;
            uiPanel1.FillColor = Color.DimGray;
            uiPanel2.FillColor = Color.WhiteSmoke;
            uiPanel3.FillColor = Color.WhiteSmoke;
            uiPanel4.FillColor = Color.WhiteSmoke;
            uiPanel5.FillColor = Color.WhiteSmoke;
            uiPanel6.FillColor = Color.WhiteSmoke;
            uiPanel7.FillColor = Color.WhiteSmoke;
            uiPanel8.FillColor = Color.WhiteSmoke;
        }
        private void rdo_two_CheckedChanged(object sender, EventArgs e)
        {
            Scheme.curScheme.windowLayout = WindowLayout.TwoWindow;
            uiPanel1.FillColor = Color.WhiteSmoke;
            uiPanel2.FillColor = Color.DimGray;
            uiPanel3.FillColor = Color.WhiteSmoke;
            uiPanel4.FillColor = Color.WhiteSmoke;
            uiPanel5.FillColor = Color.WhiteSmoke;
            uiPanel6.FillColor = Color.WhiteSmoke;
            uiPanel7.FillColor = Color.WhiteSmoke;
            uiPanel8.FillColor = Color.WhiteSmoke;
        }
        private void rdo_fore_CheckedChanged(object sender, EventArgs e)
        {
            Scheme.curScheme.windowLayout = WindowLayout.ForeWindow;
            uiPanel1.FillColor = Color.WhiteSmoke;
            uiPanel2.FillColor = Color.WhiteSmoke;
            uiPanel3.FillColor = Color.DimGray;
            uiPanel4.FillColor = Color.WhiteSmoke;
            uiPanel5.FillColor = Color.WhiteSmoke;
            uiPanel6.FillColor = Color.WhiteSmoke;
            uiPanel7.FillColor = Color.WhiteSmoke;
            uiPanel8.FillColor = Color.WhiteSmoke;
        }
        private void rdo_six_CheckedChanged(object sender, EventArgs e)
        {
            Scheme.curScheme.windowLayout = WindowLayout.SixWindow;
            uiPanel1.FillColor = Color.WhiteSmoke;
            uiPanel2.FillColor = Color.WhiteSmoke;
            uiPanel3.FillColor = Color.WhiteSmoke;
            uiPanel4.FillColor = Color.DimGray;
            uiPanel5.FillColor = Color.WhiteSmoke;
            uiPanel6.FillColor = Color.WhiteSmoke;
            uiPanel7.FillColor = Color.WhiteSmoke;
            uiPanel8.FillColor = Color.WhiteSmoke;
        }
        private void rdo_eight_CheckedChanged(object sender, EventArgs e)
        {
            Scheme.curScheme.windowLayout = WindowLayout.EightWindow;
            uiPanel1.FillColor = Color.WhiteSmoke;
            uiPanel2.FillColor = Color.WhiteSmoke;
            uiPanel3.FillColor = Color.WhiteSmoke;
            uiPanel4.FillColor = Color.WhiteSmoke;
            uiPanel5.FillColor = Color.DimGray;
            uiPanel6.FillColor = Color.WhiteSmoke;
            uiPanel7.FillColor = Color.WhiteSmoke;
            uiPanel8.FillColor = Color.WhiteSmoke;
        }
        private void rdo_nine_CheckedChanged(object sender, EventArgs e)
        {
            Scheme.curScheme.windowLayout = WindowLayout.NineWindow;
            uiPanel1.FillColor = Color.WhiteSmoke;
            uiPanel2.FillColor = Color.WhiteSmoke;
            uiPanel3.FillColor = Color.WhiteSmoke;
            uiPanel4.FillColor = Color.WhiteSmoke;
            uiPanel5.FillColor = Color.WhiteSmoke;
            uiPanel6.FillColor = Color.DimGray;
            uiPanel7.FillColor = Color.WhiteSmoke;
            uiPanel8.FillColor = Color.WhiteSmoke;
        }
        private void rdo_twelve_CheckedChanged(object sender, EventArgs e)
        {
            Scheme.curScheme.windowLayout = WindowLayout.TwelveWindow;
            uiPanel1.FillColor = Color.WhiteSmoke;
            uiPanel2.FillColor = Color.WhiteSmoke;
            uiPanel3.FillColor = Color.WhiteSmoke;
            uiPanel4.FillColor = Color.WhiteSmoke;
            uiPanel5.FillColor = Color.WhiteSmoke;
            uiPanel6.FillColor = Color.WhiteSmoke;
            uiPanel7.FillColor = Color.DimGray;
            uiPanel8.FillColor = Color.WhiteSmoke;
        }
        private void rdo_Sixteen_CheckedChanged(object sender, EventArgs e)
        {
            Scheme.curScheme.windowLayout = WindowLayout.SixteenWindow;
            uiPanel1.FillColor = Color.WhiteSmoke;
            uiPanel2.FillColor = Color.WhiteSmoke;
            uiPanel3.FillColor = Color.WhiteSmoke;
            uiPanel4.FillColor = Color.WhiteSmoke;
            uiPanel5.FillColor = Color.WhiteSmoke;
            uiPanel6.FillColor = Color.WhiteSmoke;
            uiPanel7.FillColor = Color.WhiteSmoke;
            uiPanel8.FillColor = Color.DimGray;
        }
        private void Frm_Layout_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {
            rdo_one.Checked = true;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            rdo_one.Checked = true;
        }
        private void uiPanel2_Click(object sender, EventArgs e)
        {
            rdo_two.Checked = true;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            rdo_two.Checked = true;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            rdo_two.Checked = true;
        }
        private void uiPanel3_Click(object sender, EventArgs e)
        {
            rdo_fore.Checked = true;
        }
        private void label4_Click(object sender, EventArgs e)
        {
            rdo_fore.Checked = true;
        }
        private void label5_Click(object sender, EventArgs e)
        {
            rdo_fore.Checked = true;
        }
        private void label7_Click(object sender, EventArgs e)
        {
            rdo_fore.Checked = true;
        }
        private void label6_Click(object sender, EventArgs e)
        {
            rdo_fore.Checked = true;
        }
        private void uiPanel4_Click(object sender, EventArgs e)
        {
            rdo_six.Checked = true;
        }
        private void label11_Click(object sender, EventArgs e)
        {
            rdo_six.Checked = true;
        }
        private void label10_Click(object sender, EventArgs e)
        {
            rdo_six.Checked = true;
        }
        private void label13_Click(object sender, EventArgs e)
        {
            rdo_six.Checked = true;
        }
        private void label8_Click(object sender, EventArgs e)
        {
            rdo_six.Checked = true;
        }
        private void label9_Click(object sender, EventArgs e)
        {
            rdo_six.Checked = true;
        }
        private void label12_Click(object sender, EventArgs e)
        {
            rdo_six.Checked = true;
        }
        private void uiPanel5_Click(object sender, EventArgs e)
        {
            rdo_eight.Checked = true;
        }
        private void label19_Click(object sender, EventArgs e)
        {
            rdo_eight.Checked = true;
        }
        private void label18_Click(object sender, EventArgs e)
        {
            rdo_eight.Checked = true;
        }
        private void label15_Click(object sender, EventArgs e)
        {
            rdo_eight.Checked = true;
        }
        private void label21_Click(object sender, EventArgs e)
        {
            rdo_eight.Checked = true;
        }
        private void label16_Click(object sender, EventArgs e)
        {
            rdo_eight.Checked = true;
        }
        private void label17_Click(object sender, EventArgs e)
        {
            rdo_eight.Checked = true;
        }
        private void label14_Click(object sender, EventArgs e)
        {
            rdo_eight.Checked = true;
        }
        private void label20_Click(object sender, EventArgs e)
        {
            rdo_eight.Checked = true;
        }
        private void uiPanel6_Click(object sender, EventArgs e)
        {
            rdo_nine.Checked = true;
        }
        private void label29_Click(object sender, EventArgs e)
        {
            rdo_nine.Checked = true;
        }
        private void label28_Click(object sender, EventArgs e)
        {
            rdo_nine.Checked = true;
        }
        private void label25_Click(object sender, EventArgs e)
        {
            rdo_nine.Checked = true;
        }
        private void label26_Click(object sender, EventArgs e)
        {
            rdo_nine.Checked = true;
        }
        private void label27_Click(object sender, EventArgs e)
        {
            rdo_nine.Checked = true;
        }
        private void label24_Click(object sender, EventArgs e)
        {
            rdo_nine.Checked = true;
        }
        private void label32_Click(object sender, EventArgs e)
        {
            rdo_nine.Checked = true;
        }
        private void label33_Click(object sender, EventArgs e)
        {
            rdo_nine.Checked = true;
        }
        private void label31_Click(object sender, EventArgs e)
        {
            rdo_nine.Checked = true;
        }
        private void uiPanel7_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void label38_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void label37_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void label34_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void label23_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void label35_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void label36_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void label30_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void label22_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void label41_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void label42_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void label40_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void label39_Click(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
        }
        private void uiPanel8_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label54_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label53_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label50_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label48_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label51_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label52_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label49_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label47_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label45_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label46_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label44_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label43_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label57_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label58_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label56_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void label55_Click(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
        }
        private void uiPanel1_DoubleClick(object sender, EventArgs e)
        {
            rdo_one.Checked = true;
            this.Close();
        }
        private void label3_DoubleClick(object sender, EventArgs e)
        {
            rdo_two.Checked = true;
            this.Close();
        }
        private void label7_DoubleClick(object sender, EventArgs e)
        {
            rdo_fore.Checked = true;
            this.Close();
        }
        private void label12_DoubleClick(object sender, EventArgs e)
        {
            rdo_six.Checked = true;
            this.Close();
        }
        private void label20_DoubleClick(object sender, EventArgs e)
        {
            rdo_eight.Checked = true;
            this.Close();
        }
        private void label31_DoubleClick(object sender, EventArgs e)
        {
            rdo_nine.Checked = true;
            this.Close();
        }
        private void label39_DoubleClick(object sender, EventArgs e)
        {
            rdo_twelve.Checked = true;
            this.Close();
        }
        private void label55_DoubleClick(object sender, EventArgs e)
        {
            rdo_Sixteen.Checked = true;
            this.Close();
        }

    }
}
