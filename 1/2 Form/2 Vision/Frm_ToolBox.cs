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
    public partial class Frm_ToolBox : UIForm
    {
        public Frm_ToolBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_ToolBox _instance;
        internal static Frm_ToolBox Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_ToolBox();
                return _instance;
            }
        }


        private void Frm_ToolBox_DoubleClick(object sender, EventArgs e)
        {
            Project.Instance.configuration.toolBoxStatu = 0;
            Frm_Task.Instance.splitContainer1.Panel1Collapsed = false;
            Frm_Task.Instance.C_toolBox.Parent = Frm_Task.Instance.splitContainer1.Panel1;
            Frm_ToolBox.Instance.Hide();
        }
        private void Frm_ToolBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            Project.Instance.configuration.toolBoxStatu = 2;
            this.Hide();
            e.Cancel = true;
        }

    }
}
