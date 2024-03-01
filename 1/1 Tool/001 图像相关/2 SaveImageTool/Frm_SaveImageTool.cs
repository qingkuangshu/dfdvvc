using Sunny.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_SaveImageTool : UIForm
    {
        public Frm_SaveImageTool()
        {
            InitializeComponent();
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
        internal static SaveImageTool saveImageTool;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_SaveImageTool _instance;
        internal static Frm_SaveImageTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_SaveImageTool();
                return _instance;
            }
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
            saveImageTool = (SaveImageTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;
            Instance.Show();
            Application.DoEvents();
            hasShown = true;
            Instance.ckb_SaveMasterMapName.Checked = saveImageTool.isSaveMasterMapName;
            Instance.ckb_ShowMasterMapName.Checked = saveImageTool.isShowMasterMapName;
            Instance.ckb_taskFailKeepRun.Checked = saveImageTool.taskFailKeepRun;
            Instance.rdo_fromInputImage.Checked = saveImageTool.saveImageSource == SaveImageSource.InputImage ? true : false;
            Instance.rdo_fromWindowImage.Checked = saveImageTool.saveImageSource == SaveImageSource.InputImage ? false : true;
            Instance.cbx_format.Text = saveImageTool.format;
            Instance.ckb_appendTime.Checked = saveImageTool.appendTime;
            Instance.Rad_Day.Checked = saveImageTool.Is_SaveTypeDay;
            Instance.Rad_Hour.Checked = !saveImageTool.Is_SaveTypeDay;
            for (int i = 0; i < saveImageTool.L_inputItem.Count; i++)
            {
                if (saveImageTool.L_inputItem[i].inputType == DataType.String)
                {
                    Instance.tbx_LianRuFileName.Text = saveImageTool.L_inputItem[i].sourceTool + ".文本";
                    break;
                }
            }
            Instance.Activate();
            openingForm = false;
        }


        private void rdo_fromInputImage_Click(object sender, EventArgs e)
        {
            saveImageTool.saveImageSource = SaveImageSource.InputImage;
        }
        private void rdo_fromWindowImage_Click(object sender, EventArgs e)
        {
            saveImageTool.saveImageSource = SaveImageSource.WindowImage;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cbx_format.ShowDropDown();
        }
        private void cbx_format_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveImageTool.format = cbx_format.Text;
        }
        private void ckb_appendTime_Click(object sender, EventArgs e)
        {
            saveImageTool.appendTime = ckb_appendTime.Checked;
        }
        private void btn_openPath_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string path = string.Format("{0}\\{1}\\{2}\\{3}\\Image\\{4}\\{5}\\",
                    Project.Instance.configuration.dataPath, dt.ToString("yyyy"), dt.ToString("MMMM"), dt.ToString("yyyy_MM_dd"), taskName, toolName);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            Instance.TopMost = false;
            Process.Start(path);
        }
        private void btn_clearImage_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string path = string.Format("{0}\\{1}\\{2}\\{3}\\Image\\{4}\\{5}\\",
                    Project.Instance.configuration.dataPath, dt.ToString("yyyy"), dt.ToString("MMMM"), dt.ToString("yyyy_MM_dd"), taskName, toolName);

            if (Directory.Exists(path))
                Directory.Delete(path, true);

            lbl_toolTip.Text = "图像清除成功";
            lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
        }

        private void toolStrip1_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }
        private void 保存toolStripButton1_Click(object sender, EventArgs e)
        {
            Scheme.SaveCur();
            FuncLib.ShowMsg("保存当前方案成功", InfoType.Tip);
        }
        private void 复位toolStripButton3_Click(object sender, EventArgs e)
        {
            saveImageTool.ResetTool();
        }
        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            saveImageTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }
        private void Frm_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }
        private void Frm_SaveImageTool_ExtendBoxClick(object sender, EventArgs e)
        {
            Instance.TopMost = !Instance.TopMost;

            if (Instance.TopMost)
                Instance.ExtendSymbol = 61475;
            else
                Instance.ExtendSymbol = 61758;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 是否选择在HW当中显示原图像的名称，该操作属于紧耦合操作，必须存在采集图像才行。因未开放脚本操作，此属于无奈之举
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckb_ShowMasterMapName_Click(object sender, EventArgs e)
        {
            saveImageTool.isShowMasterMapName = ckb_ShowMasterMapName.Checked;
        }

        private void ckb_SaveMasterMapName_Click(object sender, EventArgs e)
        {
            saveImageTool.isSaveMasterMapName = ckb_SaveMasterMapName.Checked;
        }

        private void btn_TxtLianRu_Click(object sender, EventArgs e)
        {
            FrmBianLiang frm = new FrmBianLiang(toolName);
            frm.TagString = "文本";
            //frm.ShowNavNodes(saveImageTool.LianRuImgToolNames(toolName));
            frm.ShowNavNodes(saveImageTool.LianRuToolNames(DataType.String));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                tbx_LianRuFileName.ReadOnly = true;
                tbx_LianRuFileName.Text = FrmBianLiang.currentLianRuInfo;
                UIMessageTip.ShowOk("成功切换文本链入项");
                saveImageTool.UpdateInput();
            }
        }

        private void btn_CancelLianRu_Click(object sender, EventArgs e)
        {
            if (saveImageTool.DelToolIO("文本"))
            {
                tbx_LianRuFileName.ReadOnly = false;
                tbx_LianRuFileName.Text = "";
                UIMessageTip.ShowOk("移除当前链入成功");
            }
        }

        private void Rad_Hour_Click(object sender, EventArgs e)
        {
            saveImageTool.Is_SaveTypeDay = false;
        }

        private void Rad_Day_Click(object sender, EventArgs e)
        {
            saveImageTool.Is_SaveTypeDay = true;
        }
    }
}
