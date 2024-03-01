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
    public partial class Frm_TaskInfo : UIForm
    {
        public Frm_TaskInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_TaskInfo _instance;
        internal static Frm_TaskInfo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_TaskInfo();
                return _instance;
            }
        }


        private void Frm_TaskInfo_Load(object sender, EventArgs e)
        {
            cbx_imageWindow.Items.Clear();
            cbx_imageWindow.Items.Add("无");
            switch (Scheme.curScheme.windowLayout)
            {
                case WindowLayout.OneWindow:
                    for (int i = 0; i < 1; i++)
                    {
                        cbx_imageWindow.Items.Add(Project.Instance.configuration.windowName[i]);
                    }
                    break;
                case WindowLayout.TwoWindow:
                    for (int i = 0; i < 2; i++)
                    {
                        cbx_imageWindow.Items.Add(Project.Instance.configuration.windowName[i]);
                    }
                    break;
                case WindowLayout.ForeWindow:
                    for (int i = 0; i < 4; i++)
                    {
                        cbx_imageWindow.Items.Add(Project.Instance.configuration.windowName[i]);
                    }
                    break;
                case WindowLayout.SixWindow:
                    for (int i = 0; i < 6; i++)
                    {
                        cbx_imageWindow.Items.Add(Project.Instance.configuration.windowName[i]);
                    }
                    break;
                case WindowLayout.EightWindow:
                    for (int i = 0; i < 8; i++)
                    {
                        cbx_imageWindow.Items.Add(Project.Instance.configuration.windowName[i]);
                    }
                    break;
                case WindowLayout.NineWindow:
                    for (int i = 0; i < 9; i++)
                    {
                        cbx_imageWindow.Items.Add(Project.Instance.configuration.windowName[i]);
                    }
                    break;
                case WindowLayout.TwelveWindow:
                    for (int i = 0; i < 12; i++)
                    {
                        cbx_imageWindow.Items.Add(Project.Instance.configuration.windowName[i]);
                    }
                    break;
                case WindowLayout.SixteenWindow:
                    for (int i = 0; i < 16; i++)
                    {
                        cbx_imageWindow.Items.Add(Project.Instance.configuration.windowName[i]);
                    }
                    break;
            }

            cbx_imageWindow.Text = Task.curTask.windowName;
            cbx_trigMode.SelectedIndex = (int)Task.curTask.taskTrigMode;

            cbx_portList.Items.Clear();
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.TCPIPSever || Project.Instance.L_Service[i].serviceType == ServiceType.TCPIPClient)
                    cbx_portList.Items.Add(Project.Instance.L_Service[i].name);
            }

            cbx_portList.Text = Task.curTask.EthernetTrigPort;
            tbx_trigCmd.Text = Task.curTask.ethernetTrigCmd;
            ckb_showRunStatu.Checked = Task.curTask.showRunStatu;
        }
        private void cbx_imageWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            Task.curTask.windowName = cbx_imageWindow.Text.Trim();
        }
        private void cbx_trigMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Task.curTask.taskTrigMode = (TaskTrigMode)cbx_trigMode.SelectedIndex;

            if (cbx_portList.Text == string.Empty && cbx_portList.Items.Count > 0)
                cbx_portList.SelectedIndex = 0;
        }
        private void cbx_portList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Task.curTask.EthernetTrigPort = cbx_portList.Text;
        }
        private void tbx_trigCmd_TextChanged(object sender, EventArgs e)
        {
            Task.curTask.ethernetTrigCmd = tbx_trigCmd.Text.Trim();
        }
        private void ckb_showRunStatu_CheckedChanged(object sender, EventArgs e)
        {
            Task.curTask.showRunStatu = ckb_showRunStatu.Checked;
        }

    }
}
