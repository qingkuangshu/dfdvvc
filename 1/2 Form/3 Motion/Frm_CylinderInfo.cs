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
using System.Threading;
using HalconDotNet;
using System.Diagnostics;

namespace VM_Pro
{
    public partial class Frm_CylinderInfo : UIForm
    {
        public Frm_CylinderInfo()
        {
            InitializeComponent();
            this.TopMost = true;

        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_CylinderInfo _instance;
        internal static Frm_CylinderInfo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_CylinderInfo();
                return _instance;
            }
        }


        /// <summary>
        /// 加载参数
        /// </summary>
        internal static void LoadPara(string cylinderName, string cardName1, string cardName2, string cardName3, string cardName4, int originOut, int actOut, int originIn, int actIn)
        {
            Instance.lbl_cylinderName.Text = cylinderName;
            Instance .lbl_controlType .Text =(actOut ==-1?"单控":"双控");
            Instance.lbl_originOut.Text = string.Format("{0} . {1}", cardName1, originOut.ToString());
            Instance.lbl_ActOut.Text = string.Format("{0} . {1}", cardName2, actOut.ToString());
            Instance.lbl_originIn.Text = string.Format("{0} . {1}", cardName3, originIn.ToString());
            Instance.lbl_actIn.Text = string.Format("{0} . {1}", cardName4, actIn.ToString());
        }


        private void Frm_MorePar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

    }
}
