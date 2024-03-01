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
using Sunny.UI;

namespace VM_Pro
{
    public partial class FrmCameraIoOut : UIForm
    {
        public FrmCameraIoOut()
        {
            InitializeComponent();
        }

        private static FrmCameraIoOut _instance;

        internal static FrmCameraIoOut Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FrmCameraIoOut();
                }
                return _instance;
            }
        }



        /// <summary>
        /// 是否启用事件，也就是不执行本次触发的事件
        /// </summary>
        internal static bool openingForm = false;
        /// <summary>
        /// 当前工具名
        /// </summary>
        internal static string toolName = string.Empty;
        /// <summary>
        /// 当前工具所属的流程
        /// </summary>
        internal static string taskName = string.Empty;
        /// <summary>
        /// 窗体是否已显示
        /// </summary>
        internal static bool hasShown = false;
        /// <summary>
        /// 工具对象
        /// </summary>
        internal static CameraIOOut cameraIOOut;


        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 弹出工具页面
        /// </summary>
        /// <param name="toolBase">工具</param>
        internal static void ShowForm(ToolBase toolBase)
        {
            if (hasShown && taskName == toolBase.taskName && toolName == toolBase.toolName)     //如果当前工具已显示或者最小化了，那就直接显示即可
            {
                Instance.WindowState = FormWindowState.Normal;
                Instance.Activate();
                return;
            }

            openingForm = true;
            Instance.Text = string.Format("{0}    [ {1} . {2} ]", toolBase.toolType, toolBase.taskName, toolBase.toolName);
            cameraIOOut = (CameraIOOut)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            FrmCameraIoOut.Instance.txt_TimeOut.Text = cameraIOOut.ThreadTimeOut.ToString();
            FrmCameraIoOut.Instance.ckb_taskFailKeepRun.Checked = cameraIOOut.taskFailKeepRun;
            if (cameraIOOut.OutputType == CameraIoOutputType.任务运行触发)
            {
                FrmCameraIoOut.Instance.rad_Trigger.Checked = true;
            }
            else if (cameraIOOut.OutputType == CameraIoOutputType.任务成功触发)
            {
                FrmCameraIoOut.Instance.rad_SuccessTrigger.Checked = true;
            }
            else if (cameraIOOut.OutputType == CameraIoOutputType.任务失败触发)
            {
                FrmCameraIoOut.Instance.rad_FailTrigger.Checked = true;
            }
            

            Instance.WindowState = FormWindowState.Normal;

            Instance.Show();
            hasShown = true;

            openingForm = false;
            Application.DoEvents();
        }

        private void btn_runTool_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                this.Invoke(new Action(() =>
                {
                    Frm_Loading.Instance.lbl_title.Text = "拼命加载中";
                    Frm_Loading.Instance.Show();
                }));
                cameraIOOut.CurRun = true;
                cameraIOOut.Run();

                Frm_Loading.Instance.Hide();
            });
            th.IsBackground = true;
            th.Start();
        }

        private void FrmCameraIoOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
            
        }

        private void uiRadioButton3_Click(object sender, EventArgs e)
        {
            UIRadioButton rad = sender as UIRadioButton;
            cameraIOOut.OutputType = (CameraIoOutputType)Enum.Parse(typeof(CameraIoOutputType), rad.TagString);
        }

        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            cameraIOOut.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }
    }
}
