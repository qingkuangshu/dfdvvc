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
    public partial class Frm_Project : Form
    {
        public Frm_Project()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Project _instance;
        internal static Frm_Project Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Project();
                return _instance;
            }
        }


        private void Frm_Project_Load(object sender, EventArgs e)
        {
            tbx_companyName.Text = Project.Instance.configuration.companyName;
            tbx_projectName.Text = Project.Instance.configuration.projectName;
            tbx_dataPath.Text = Project.Instance.configuration.dataPath;
            tbx_dataSaveTime.Text = Project.Instance.configuration.dataSaveTime.ToString();
            rdo_saveDataTimeBasedDay.Checked = Project.Instance.configuration.dateSaveTimeBasedDay;
            rdo_saveDataTimeBasedHour.Checked = !Project.Instance.configuration.dateSaveTimeBasedDay;
        }
        private void tbx_companyName_TextChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.companyName = tbx_companyName.Text;
            Frm_Main.Instance.Text = string.Format("{0} - {1}", Project.Instance.configuration.companyName, Project.Instance.configuration.projectName);
        }
        private void tbx_projectName_TextChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.projectName = tbx_projectName.Text;
            Frm_Main.Instance.Text = string.Format("{0} - {1}", Project.Instance.configuration.companyName, Project.Instance.configuration.projectName);
        }
        private void tbx_dataPath_TextChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.dataPath = tbx_dataPath.Text;
        }
        private void btn_selectDataPath_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folderBrowseDialog = new VistaFolderBrowserDialog();
            if (Directory.Exists(Project.Instance.configuration.dataPath))
                folderBrowseDialog.SelectedPath = Project.Instance.configuration.dataPath;

            folderBrowseDialog.Description = "请选择数据存储路径";
            if (folderBrowseDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Project.Instance.configuration.dataPath = folderBrowseDialog.SelectedPath;
                tbx_dataPath.Text = folderBrowseDialog.SelectedPath;
            }
        }
        private void tbx_dataSaveTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Project.Instance.configuration.dataSaveTime = Convert.ToInt16(tbx_dataSaveTime.Text);
            }
            catch { }
        }
        private void rdo_saveDataTimeBasedDay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_saveDataTimeBasedDay.Checked)
                Project.Instance.configuration.dateSaveTimeBasedDay = true;
        }
        private void rdo_saveDataTimeBasedHour_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_saveDataTimeBasedHour.Checked)
                Project.Instance.configuration.dateSaveTimeBasedDay = false;
        }
        private void btn_export_Click(object sender, EventArgs e)
        {
            Project.Export();
        }
        private void btn_inport_Click(object sender, EventArgs e)
        {
            Project.Inport();
        }

    }
}
