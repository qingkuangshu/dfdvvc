using Ookii.Dialogs.WinForms;
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
    public partial class Frm_FTPDownload : Form
    {
        public Frm_FTPDownload()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private static Frm_FTPDownload _instance;

        internal static Frm_FTPDownload Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Frm_FTPDownload();
                }
                return _instance;
            }
        }

        /// <summary>
        /// FTP客户端实例
        /// </summary>
        internal static FTPDownload ftpdownload = null;

        /// <summary>
        /// 显示参数到界面
        /// </summary>
        /// <param name="tcpClient"></param>
        internal static void ShowPar(ServiceBase serviceBase)
        {
            if (Frm_Service.curForm != CurForm.FTPDownload)
            {
                Frm_Service.curForm = CurForm.FTPDownload;

                Frm_Service.Instance.pnl_seviceBox.Controls.Clear();
                Instance.TopLevel = false;
                Instance.Parent = Frm_Service.Instance.pnl_seviceBox;
                Instance.Dock = DockStyle.Fill;
                Instance.Show();
            }

            ftpdownload = (FTPDownload)serviceBase;

            //更新参数
            if (ftpdownload.IsConnect)
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "停止监测";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
            }
            else
            {
                Frm_Service.Instance.lbl_connectStatu.Text = "开始监测";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
            }

            Instance.txt_UserName.Text = ftpdownload.ftpUser;
            Instance.txt_Password.Text = ftpdownload.ftpPassword;
            Instance.txt_Address.Text = ftpdownload.ftpAddress;
            Instance.txt_FatherPath.Text = ftpdownload.ftpFatherPath;
            Instance.txt_LocalPath.Text = ftpdownload.localSavePath;
            Instance.btn_StartCheck.Text = ftpdownload.IsConnect ? "停止监测" : "开始监测";
            Instance.cmb_dateTimeFormat.Text = ftpdownload.addTimeFormat;
            Instance.ckb_PathAddDate.Checked =
            Instance.cmb_dateTimeFormat.Visible = ftpdownload.isAddTime;
            Instance.ckb_ImgDownloadRunTask.Checked = ftpdownload.isDownloadCompletedRunTask;

        }

        /// <summary>
        ///  双击选择本地存储路径事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_LocalPath_DoubleClick(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog vistaFolderBrowserDialog = new VistaFolderBrowserDialog();
            vistaFolderBrowserDialog.Description = "请选择存储文件夹路径";
            if (vistaFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                ftpdownload.localSavePath = vistaFolderBrowserDialog.SelectedPath;
                Instance.txt_LocalPath.Text = ftpdownload.localSavePath;
            }

        }
        Thread th;
        /// <summary>
        /// 打开监测按钮事件，主要是根据连接状态，开启相应的线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (btn_StartCheck.Text == "开始监测")
            {
                if (ftpdownload.IsConnect)
                {
                    if (th == null || !th.IsAlive)
                    {
                        ftpdownload.isStartCheck = true;
                        th = new Thread(ftpdownload.CheckFTPPath);
                        th.IsBackground = true;
                        th.Start();
                        Frm_Service.Instance.lbl_connectStatu.Text = "已连接";
                        Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
                        btn_StartCheck.Text = "停止监测";
                    }
                }
                else
                {
                    Frm_Service.Instance.lbl_connectStatu.Text = "未连接";
                    Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
                    btn_StartCheck.Text = "开始监测";
                    FuncLib.ShowMessageBox("当前参数或环境可能错误，未连接上FTP服务器，请确认环境后重试...", InfoType.Warn);
                }
            }
            else
            {
                ftpdownload.isStartCheck = false;
                Frm_Service.Instance.lbl_connectStatu.Text = "未连接";
                Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Red;
                btn_StartCheck.Text = "开始监测";
            }
            this.Enabled = true;

        }

        /// <summary>
        /// 从FTP当中下载文件方法
        /// </summary>
        private void th_DownloadFileAction()
        {

        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_FatherPath_DoEnter(object sender, EventArgs e)
        {
            ftpdownload.ftpUser = txt_UserName.Text.Trim().ToString();
            ftpdownload.ftpPassword = txt_Password.Text.Trim().ToString();
            ftpdownload.ftpFatherPath = txt_FatherPath.Text.Trim().ToString();

        }

        private void ckb_PathAddDate_Click(object sender, EventArgs e)
        {
            if (ftpdownload.addTimeFormat == "")
            {
                ftpdownload.addTimeFormat = "yyyyMMdd";
            }
            cmb_dateTimeFormat.Text = ftpdownload.addTimeFormat;
            ftpdownload.isAddTime = ckb_PathAddDate.Checked;
            cmb_dateTimeFormat.Visible = ftpdownload.isAddTime;

        }

        private void cmb_dateTimeFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ftpdownload.addTimeFormat = cmb_dateTimeFormat.Text.Trim();
        }

        private void ckb_ImgDownloadRunTask_Click(object sender, EventArgs e)
        {
            ftpdownload.isDownloadCompletedRunTask = ckb_ImgDownloadRunTask.Checked;
            ftpdownload.RunTaskName = Task.curTask.name;
        }
    }
}
