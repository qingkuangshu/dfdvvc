using Microsoft.Win32;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_Else : Form
    {
        public Frm_Else()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Else _instance;
        internal static Frm_Else Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Else();
                return _instance;
            }
        }


        private void Frm_Else_Load(object sender, EventArgs e)
        {
            tbx_taskRunSpan.Text = Project.Instance.configuration.taskRunSpan.ToString();
            ckb_failStop.Checked = Project.Instance.configuration.failStop;
            ckb_endStop.Checked = Project.Instance.configuration.endStop;
        }
        private void tbx_taskRunSpan_ValueChanged(double value)
        {
            Project.Instance.configuration.taskRunSpan = Convert.ToInt32(tbx_taskRunSpan.Text.Trim());
        }
        private void ckb_failStop_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.failStop = ckb_failStop.Checked;
        }
        private void ckb_endStop_Click(object sender, EventArgs e)
        {
            Project.Instance.configuration.endStop = ckb_endStop.Checked;
        }

    }
}
