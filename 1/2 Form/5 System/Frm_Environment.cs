using Microsoft.Win32;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_Environment : Form
    {
        public Frm_Environment()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Environment _instance;
        internal static Frm_Environment Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Environment();
                return _instance;
            }
        }


        /// <summary>
        /// 开启开机自启动
        /// </summary>
        private void SetThisAppAutoStartup()
        {
            try
            {
                string strPathAndAppName = Application.StartupPath + "\\VM Pro.exe";
                if (!File.Exists(strPathAndAppName))
                    return;
                string strAppName = strPathAndAppName.Substring(strPathAndAppName.LastIndexOf("\\") + 1);
                strAppName = strAppName.Replace(".exe", "");
                strAppName = strAppName.Replace(".EXE", "");
                RegistryKey RKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (RKey == null)
                    RKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                RKey.SetValue(strAppName, strPathAndAppName);
                RKey.Close();
            }
            catch { }
        }
        /// <summary>
        /// 关闭开机自启动
        /// </summary>
        private void DelThisAppAutoStartup()
        {
            try
            {
                string strPathAndAppName = Application.ExecutablePath;
                if (!File.Exists(strPathAndAppName))
                    return;
                string strAppName = strPathAndAppName.Substring(strPathAndAppName.LastIndexOf("\\") + 1);//
                strAppName = strAppName.Replace(".exe", "");
                strAppName = strAppName.Replace(".EXE", "");
                RegistryKey RKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (RKey == null)
                    RKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                RKey.SetValue(strAppName, false);//取消开机运行
                RKey.DeleteSubKey(strAppName, false);//取消开机运行
                RKey.Close();
            }
            catch { }
        }


        private void Frm_Project_Load(object sender, EventArgs e)
        {
            ckb_userForm.Checked = Project.Instance.configuration.enableUserForm;
            rdo_visionForm.Checked = Project.Instance.configuration.enableVisionForm;
            rdo_motionForm.Checked = Project.Instance.configuration.enableMotionForm;
            rdo_ioForm.Checked = Project.Instance.configuration.enableIOForm;

            switch (Project.Instance.configuration.defaultFormType)
            {
                case FormType.UserForm:
                    rdo_defaultUserForm.Checked = true;
                    break;
                case FormType.VisionForm:
                    rdo_defaultVisionForm.Checked = true;
                    break;
                case FormType.MotionForm:
                    rdo_defaultMotionForm.Checked = true;
                    break;
                case FormType.IOForm:
                    rdo_defaultIOForm.Checked = true;
                    break;
            }

            rdo_product.Checked = Project.Instance.configuration.productCheck;
            rdo_task.Checked = Project.Instance.configuration.taskCheck;
            rdo_infomation.Checked = Project.Instance.configuration.infomationCheck;

            ckb_taskFormEnable.Checked = Project.Instance.configuration.taskFormEnable;
            ckb_produceFormEnable.Checked = Project.Instance.configuration.produceFormEnable;
            ckb_infomationFormEnable.Checked = Project.Instance.configuration.infomationFormEnable;

            ckb_autoRunAfterStartup.Checked = Project.Instance.configuration.autoRunAfterStartup;
            ckb_autoStartAfterRun.Checked = Project.Instance.configuration.autoStartAfterRun;
            ckb_autoMax.Checked = Project.Instance.configuration.autoMax;
            ckb_disenableResizeForm.Checked = Project.Instance.configuration.disenableResizeForm;
            ckb_enablePermission.Checked = Project.Instance.configuration.enablePermission;
            ckb_taskFailStop.Checked = Project.Instance.configuration.taskFailStop;
            ckb_onLine.Checked = Project.Instance.configuration.onLine;
            ckb_showAllSignal.Checked = Project.Instance.configuration.showAllSignal;

            ckb_enableHikvisionSdk.Checked = Project.Instance.configuration.enableHikvisionSdk;
            ckb_enableDaHengSdk.Checked = Project.Instance.configuration.enableDaHengSdk;
            ckb_enableAVTSdk.Checked = Project.Instance.configuration.enableAVTSdk;
            ckb_enableHalconSdk.Checked = Project.Instance.configuration.enableHalconSdk;

            cbx_controlType.SelectedIndex = (int)Project.Instance.configuration.controlType;
        }

        private void ckb_userForm_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.enableUserForm = ckb_userForm.Checked;
        }
        private void ckb_visionForm_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.enableVisionForm = rdo_visionForm.Checked;
        }
        private void ckb_motionForm_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.enableMotionForm = rdo_motionForm.Checked;
        }
        private void ckb_ioForm_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.enableIOForm = rdo_ioForm.Checked;
        }
        private void rdo_defaultUserForm_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_defaultUserForm.Checked)
                Project.Instance.configuration.defaultFormType = FormType.UserForm;
        }
        private void rdo_defaultVisionForm_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_defaultVisionForm.Checked)
                Project.Instance.configuration.defaultFormType = FormType.VisionForm;
        }
        private void rdo_defaultMotionForm_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_defaultMotionForm.Checked)
                Project.Instance.configuration.defaultFormType = FormType.MotionForm;
        }
        private void rdo_defaultIOForm_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_defaultIOForm.Checked)
                Project.Instance.configuration.defaultFormType = FormType.IOForm;
        }

        private void ckb_autoRunAfterStartup_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.autoRunAfterStartup = ckb_autoRunAfterStartup.Checked;

            if (Project.Instance.configuration.autoRunAfterStartup)
                SetThisAppAutoStartup();
            else
                DelThisAppAutoStartup();
        }
        private void ckb_autoStartAfterRun_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.autoStartAfterRun = ckb_autoStartAfterRun.Checked;
        }
        private void ckb_autoMax_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.autoMax = ckb_autoMax.Checked;
        }
        private void ckb_disenableResizeForm_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.disenableResizeForm = ckb_disenableResizeForm.Checked;
            if (Project.Instance.configuration.disenableResizeForm)
            {
                Frm_Main.Instance.TitleHeight = 31;
                Frm_Main.Instance.ShowDragStretch = false;
                Frm_Main.Instance.MinimumSize = Frm_Main.Instance.Size;
                Frm_Main.Instance.MaximumSize = Frm_Main.Instance.Size;
                Frm_Main.Instance.MaximizeBox = false;
            }
            else
            {
                Frm_Main.Instance.TitleHeight = 35;
                Frm_Main.Instance.ShowDragStretch = true;
                Frm_Main.Instance.MinimumSize = new Size(300, 200);
                Frm_Main.Instance.MaximumSize = new Size(3000, 2000);
                Frm_Main.Instance.MaximizeBox = true;

            }
        }
        private void ckb_enablePermission_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.enablePermission = ckb_enablePermission.Checked;
        }
        private void ckb_taskFailStop_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.taskFailStop = ckb_taskFailStop.Checked;
        }
        private void ckb_onLine_Click(object sender, EventArgs e)
        {
            Project.Instance.configuration.onLine = ckb_onLine.Checked;

            Frm_Vision.Instance.label1.Visible = Project.Instance.configuration.onLine;
            Frm_Vision.Instance.lbl_askMaterial.Visible = Project.Instance.configuration.onLine;
            Frm_Vision.Instance.lbl_nextAskMaterial.Visible = Project.Instance.configuration.onLine;
            Frm_Vision.Instance.pic_askMaterial.Visible = Project.Instance.configuration.onLine;
            Frm_Vision.Instance.pic_nextAskMaterial.Visible = Project.Instance.configuration.onLine;
        }

        private void ckb_enableHikvisionSdk_Click(object sender, EventArgs e)
        {
            Project.Instance.configuration.enableHikvisionSdk = ckb_enableHikvisionSdk.Checked;

            if (Project.Instance.configuration.enableHikvisionSdk)
            {
                ckb_enableHalconSdk.Checked = false;
                Project.Instance.configuration.enableHalconSdk = false;
            }
        }
        private void ckb_enableDaHengSdk_Click(object sender, EventArgs e)
        {
            Project.Instance.configuration.enableDaHengSdk = ckb_enableDaHengSdk.Checked;

            if (Project.Instance.configuration.enableDaHengSdk)
            {
                ckb_enableHalconSdk.Checked = false;
                Project.Instance.configuration.enableHalconSdk = false;

                ckb_enableAVTSdk.Checked = false;
                Project.Instance.configuration.enableAVTSdk = false;
            }
        }
        private void ckb_enableAVTSdk_Click(object sender, EventArgs e)
        {
            Project.Instance.configuration.enableAVTSdk = ckb_enableAVTSdk.Checked;

            if (Project.Instance.configuration.enableAVTSdk)
            {
                ckb_enableHalconSdk.Checked = false;
                Project.Instance.configuration.enableHalconSdk = false;

                ckb_enableDaHengSdk.Checked = false;
                Project.Instance.configuration.enableDaHengSdk = false;
            }
        }
        private void ckb_enableHalconSdk_Click(object sender, EventArgs e)
        {
            Project.Instance.configuration.enableHalconSdk = ckb_enableHalconSdk.Checked;

            if (Project.Instance.configuration.enableHalconSdk)
            {
                ckb_enableHikvisionSdk.Checked = false;
                ckb_enableDaHengSdk.Checked = false;
                ckb_enableAVTSdk.Checked = false;
                Project.Instance.configuration.enableHikvisionSdk = false;
                Project.Instance.configuration.enableDaHengSdk = false;
                Project.Instance.configuration.enableAVTSdk = false;
            }
        }

        private void rdo_product_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_product.Checked)
            {
                Project.Instance.configuration.productCheck = true;
                Project.Instance.configuration.taskCheck = false;
                Project.Instance.configuration.infomationCheck = false;
            }
        }
        private void rdo_task_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_task.Checked)
            {
                Project.Instance.configuration.taskCheck = true;
                Project.Instance.configuration.productCheck = false;
                Project.Instance.configuration.infomationCheck = false;
            }
        }
        private void rdo_infomation_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_infomation.Checked)
            {
                Project.Instance.configuration.infomationCheck = true;
                Project.Instance.configuration.taskCheck = false;
                Project.Instance.configuration.productCheck = false;
            }
        }

        private void ckb_taskFormEnable_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.taskFormEnable = ckb_taskFormEnable.Checked;
            Frm_Vision.Instance.任务toolStripButton2.Visible = ckb_taskFormEnable.Checked;

        }
        private void ckb_produceFormEnable_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.produceFormEnable = ckb_produceFormEnable.Checked;
            Frm_Vision.Instance.生产toolStripButton1.Visible = ckb_produceFormEnable.Checked;

        }
        private void ckb_infomationFormEnable_CheckedChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.infomationFormEnable = ckb_infomationFormEnable.Checked;
            Frm_Vision.Instance.统计toolStripButton1.Visible = ckb_infomationFormEnable.Checked;
        }
        private void cbx_controlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.controlType = (ControlType)cbx_controlType.SelectedIndex;
        }

        private void btn_systemFormat_Click(object sender, EventArgs e)
        {
            if (FuncLib.ShowConfirmDialog("确定要将程序恢复到初始状态吗？这将清除所有配置及流程文件，使程序恢复到安装完毕时的初始状态！", InfoType.Warn) == DialogResult.OK)
            {
                //删除所有配置文件
                if (Directory.Exists(Application.StartupPath + "\\Config\\Project"))
                    Directory.Delete(Application.StartupPath + "\\Config\\Project", true);

                FuncLib.ShowMessageBox("重置成功!（重启后生效，确定后程序将自动关闭）", InfoType.Tip);
                Process.GetCurrentProcess().Kill();
            }
        }

        private void btn_calibrationFormat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Calibrate)
                {
                    ((Calibrate)Project.Instance.L_Service[i]).calibrated = false;
                    ((Calibrate)Project.Instance.L_Service[i]).calibInfo = string.Empty;
                }
            }
        }

        private void ckb_showAllSignal_Click(object sender, EventArgs e)
        {
            Project.Instance.configuration.showAllSignal = ckb_showAllSignal.Checked;
        }
    }
}
