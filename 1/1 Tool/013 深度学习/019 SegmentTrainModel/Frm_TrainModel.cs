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
using HalconDotNet;


namespace VM_Pro
{
    public partial class Frm_TrainModel : UIForm
    {
        public Frm_TrainModel()
        {
            InitializeComponent();
        }

        private static Frm_TrainModel _instance;

        internal static Frm_TrainModel Instance
        {
            get {
                if (_instance == null)
                    _instance = new Frm_TrainModel();
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
        internal static TrainModelTool trainModelTool;

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
            trainModelTool = (TrainModelTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;


            try
            {
                Instance.Show();    //有时会出现创建句柄异常的现象，那么则释放其对象，重新创建一个

            }
            catch (Exception ex)
            {
                Instance.Close();
                _instance = null;
                UIMessageTip.ShowError("打开异常，请稍后重试...");
                return;
            }

            Application.DoEvents();
            hasShown = true;

            //TrainModelTool.UpdateInput();


            openingForm = false;
            Application.DoEvents();
        }

        private void Frm_TrainModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_hdictPath_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择DL工具导出的hdict文件";
            dialog.Filter = "hdict文件(*.hdict)|*.hdict";
            dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                HOperatorSet.ReadDict(dialog.FileName, "[]", "[]",out trainModelTool.dictHandle);
            
            }
        }

        private void txt_ModelPath_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
