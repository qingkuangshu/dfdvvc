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
using System.Runtime.InteropServices;
using System.Threading;
using HalconDotNet;

namespace VM_Pro
{
    public partial class Frm_UpCamAlignTool : UIForm
    {
        public Frm_UpCamAlignTool()
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
        internal static UpCamAlignTool upCamAlignTool;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_UpCamAlignTool _instance;
        internal static Frm_UpCamAlignTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_UpCamAlignTool();
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
            upCamAlignTool = (UpCamAlignTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;
            Instance.Show();
            Application.DoEvents();
            hasShown = true;

            upCamAlignTool.UpdateInput();

            Thread th1 = new Thread(() =>
            {
                upCamAlignTool.Run();
            });
            th1.IsBackground = true;
            th1.Start();

            Instance.ckb_taskFailKeepRun.Checked = upCamAlignTool.taskFailKeepRun;
            Instance.rdo_oneTool.Checked = (upCamAlignTool.pickMode == PickMode.OneTool);
            Instance.rdo_moreTool.Checked = (upCamAlignTool.pickMode == PickMode.MoreTool);
            Instance.cbx_toolList.Items.Clear();
            foreach (KeyValuePair<string, int> item in upCamAlignTool.D_toolName)
            {
                Instance.cbx_toolList.Items.Add(item.Key);
            }
            if (Instance.cbx_toolList.Items.Count > 0 && Instance.cbx_toolList.Text == string.Empty)
                Instance.cbx_toolList.SelectedIndex = 0;
            Instance.ckb_enableCheckError.Checked = upCamAlignTool.enableCheckError;
            if (upCamAlignTool.pickMode == PickMode.MoreTool)
            {
                Instance.uiLabel3.Visible = true;
                Instance.cbx_toolList.Visible = true;
                Instance.btn_addTool.Visible = true;
                Instance.btn_removeTool.Visible = true;
            }
            else
            {
                Instance.uiLabel3.Visible = false;
                Instance.cbx_toolList.Visible = false;
                Instance.btn_addTool.Visible = false;
                Instance.btn_removeTool.Visible = false;
            }

            Instance.tbx_featureX.Value = upCamAlignTool.L_featurePos[Instance.cbx_toolList.SelectedIndex].XY.X.ToString();
            Instance.tbx_featureY.Value = upCamAlignTool.L_featurePos[Instance.cbx_toolList.SelectedIndex].XY.Y.ToString();
            Instance.tbx_featureU.Value = upCamAlignTool.L_featurePos[Instance.cbx_toolList.SelectedIndex].U.ToString();

            Instance.tbx_pickPosX.Value = upCamAlignTool.L_pickPos[Instance.cbx_toolList.SelectedIndex].XY.X.ToString();
            Instance.tbx_pickPosY.Value = upCamAlignTool.L_pickPos[Instance.cbx_toolList.SelectedIndex].XY.Y.ToString();
            Instance.tbx_pickPosU.Value = upCamAlignTool.L_pickPos[Instance.cbx_toolList.SelectedIndex].U.ToString();

            Instance.tbx_pickPosOffsetX.Value = upCamAlignTool.L_pickPosOffset[Instance.cbx_toolList.SelectedIndex].XY.X;
            Instance.tbx_pickPosOffsetY.Value = upCamAlignTool.L_pickPosOffset[Instance.cbx_toolList.SelectedIndex].XY.Y;
            Instance.tbx_pickPosOffsetU.Value = upCamAlignTool.L_pickPosOffset[Instance.cbx_toolList.SelectedIndex].U;

            Instance.tbx_saftyRangeX.Value = upCamAlignTool.L_safetyRange[Instance.cbx_toolList.SelectedIndex].XY.X.ToString();
            Instance.tbx_saftyRangeY.Value = upCamAlignTool.L_safetyRange[Instance.cbx_toolList.SelectedIndex].XY.Y.ToString();
            Instance.tbx_saftyRangeU.Value = upCamAlignTool.L_safetyRange[Instance.cbx_toolList.SelectedIndex].U.ToString();

            if (((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置.Count > 0)
            {
                Instance.lbl_inputPosX.Text = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置[Instance.cbx_toolList.SelectedIndex].XY.X.ToString();
                Instance.lbl_inputPosY.Text = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置[Instance.cbx_toolList.SelectedIndex].XY.Y.ToString();
                Instance.lbl_inputPosU.Text = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置[Instance.cbx_toolList.SelectedIndex].U.ToString("0.000");
            }

            if (((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输出.位置.Count > 0)
            {
                Instance.lbl_resultPosX.Text = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输出.位置[Instance.cbx_toolList.SelectedIndex].XY.X.ToString();
                Instance.lbl_resultPosY.Text = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输出.位置[Instance.cbx_toolList.SelectedIndex].XY.Y.ToString();
                Instance.lbl_resultPosU.Text = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输出.位置[Instance.cbx_toolList.SelectedIndex].U.ToString("0.000");
            }

            //功能启用
            if (!Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                Instance.ckb_enableCheckError.Visible = false;
                Instance.uiLabel2.Visible = false;
                Instance.rdo_oneTool.Visible = false;
                Instance.rdo_moreTool.Visible = false;
            }
            else
            {
                Instance.ckb_enableCheckError.Visible = true;
                Instance.uiLabel2.Visible = true;
                Instance.rdo_oneTool.Visible = true;
                Instance.rdo_moreTool.Visible = true;
            }

            Instance.Activate();
            Instance.btn_runTool.Focus();
            openingForm = false;
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
            upCamAlignTool.ResetTool();
        }
        private void Frm_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            upCamAlignTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }
        private void btn_runTool_Click(object sender, EventArgs e)
        {
            upCamAlignTool.Run();
        }
        private void btn_runTask_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Task.FindTaskByName(taskName).Run();
            });
            th.IsBackground = true;
            th.Start();
        }
        private void Frm_MatchTool_ExtendBoxClick(object sender, EventArgs e)
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

        private void rdo_oneTool_Click(object sender, EventArgs e)
        {
            upCamAlignTool.pickMode = PickMode.OneTool;

            if (upCamAlignTool.pickMode == PickMode.MoreTool)
            {
                uiLabel3.Visible = true;
                cbx_toolList.Visible = true;
                btn_addTool.Visible = true;
                btn_removeTool.Visible = true;
            }
            else
            {
                uiLabel3.Visible = false;
                cbx_toolList.Visible = false;
                btn_addTool.Visible = false;
                btn_removeTool.Visible = false;
            }
        }
        private void rdo_moreTool_Click(object sender, EventArgs e)
        {
            upCamAlignTool.pickMode = PickMode.MoreTool;
        }
        private void cbx_toolList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Instance.tbx_featureX.Value = upCamAlignTool.L_featurePos[Instance.cbx_toolList.SelectedIndex].XY.X.ToString();
            Instance.tbx_featureY.Value = upCamAlignTool.L_featurePos[Instance.cbx_toolList.SelectedIndex].XY.Y.ToString();
            Instance.tbx_featureU.Value = upCamAlignTool.L_featurePos[Instance.cbx_toolList.SelectedIndex].U.ToString();

            Instance.tbx_pickPosX.Value = upCamAlignTool.L_pickPos[Instance.cbx_toolList.SelectedIndex].XY.X.ToString();
            Instance.tbx_pickPosY.Value = upCamAlignTool.L_pickPos[Instance.cbx_toolList.SelectedIndex].XY.Y.ToString();
            Instance.tbx_pickPosU.Value = upCamAlignTool.L_pickPos[Instance.cbx_toolList.SelectedIndex].U.ToString();

            Instance.tbx_pickPosOffsetX.Value = upCamAlignTool.L_pickPosOffset[Instance.cbx_toolList.SelectedIndex].XY.X;
            Instance.tbx_pickPosOffsetY.Value = upCamAlignTool.L_pickPosOffset[Instance.cbx_toolList.SelectedIndex].XY.Y;
            Instance.tbx_pickPosOffsetU.Value = upCamAlignTool.L_pickPosOffset[Instance.cbx_toolList.SelectedIndex].U;

            Instance.tbx_saftyRangeX.Value = upCamAlignTool.L_safetyRange[Instance.cbx_toolList.SelectedIndex].XY.X.ToString();
            Instance.tbx_saftyRangeY.Value = upCamAlignTool.L_safetyRange[Instance.cbx_toolList.SelectedIndex].XY.Y.ToString();
            Instance.tbx_saftyRangeU.Value = upCamAlignTool.L_safetyRange[Instance.cbx_toolList.SelectedIndex].U.ToString();

            if (((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置.Count > 0)
            {
                Instance.lbl_inputPosX.Text = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置[Instance.cbx_toolList.SelectedIndex].XY.X.ToString();
                Instance.lbl_inputPosY.Text = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置[Instance.cbx_toolList.SelectedIndex].XY.Y.ToString();
                Instance.lbl_inputPosU.Text = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置[Instance.cbx_toolList.SelectedIndex].U.ToString();
            }

            if (((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输出.位置.Count > 0)
            {
                Instance.lbl_resultPosX.Text = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输出.位置[Instance.cbx_toolList.SelectedIndex].XY.X.ToString();
                Instance.lbl_resultPosY.Text = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输出.位置[Instance.cbx_toolList.SelectedIndex].XY.Y.ToString();
                Instance.lbl_resultPosU.Text = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输出.位置[Instance.cbx_toolList.SelectedIndex].U.ToString();
            }
        }
        private void btn_addTool_Click(object sender, EventArgs e)
        {
            cbx_toolList.Items.Add("工具" + upCamAlignTool.D_toolName.Count + 1);
            upCamAlignTool.D_toolName.Add("工具" + upCamAlignTool.D_toolName.Count + 1, upCamAlignTool.D_toolName.Count);
        }
        private void btn_removeTool_Click(object sender, EventArgs e)
        {

        }
        private void ckb_enableCheckError_Click(object sender, EventArgs e)
        {
            upCamAlignTool.enableCheckError = ckb_enableCheckError.Checked;
        }
        private void tbx_featureX_ValueChanged(double value)
        {
            try
            {
                upCamAlignTool.L_featurePos[cbx_toolList.SelectedIndex].XY.X = value;
            }
            catch { }
        }
        private void tbx_featureY_ValueChanged(double value)
        {
            try
            {
                upCamAlignTool.L_featurePos[cbx_toolList.SelectedIndex].XY.Y = value;
            }
            catch { }
        }
        private void tbx_featureU_ValueChanged(double value)
        {
            try
            {
                upCamAlignTool.L_featurePos[cbx_toolList.SelectedIndex].U = value;
            }
            catch { }
        }
        private void btn_touchFeaturePos_Click(object sender, EventArgs e)
        {
            upCamAlignTool.L_featurePos.Clear();
            for (int i = 0; i < ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置.Count; i++)
            {
                upCamAlignTool.L_featurePos.Add(new XYU(((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置[i].XY.X, ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置[i].XY.Y, ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置[i].U));
            }

            tbx_featureX.Value = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置[cbx_toolList.SelectedIndex].XY.X.ToString();
            tbx_featureY.Value = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置[cbx_toolList.SelectedIndex].XY.Y.ToString();
            tbx_featureU.Value = ((UpCamAlignTool.ToolPar)upCamAlignTool.参数).输入.位置[cbx_toolList.SelectedIndex].U.ToString();
        }
        private void tbx_pickPosX_ValueChanged(double value)
        {
            try
            {
                upCamAlignTool.L_pickPos[cbx_toolList.SelectedIndex].XY.X = value;
            }
            catch { }
        }
        private void tbx_pickPosY_ValueChanged(double value)
        {
            try
            {
                upCamAlignTool.L_pickPos[cbx_toolList.SelectedIndex].XY.Y = value;
            }
            catch { }
        }
        private void tbx_pickPosU_ValueChanged(double value)
        {
            try
            {
                upCamAlignTool.L_pickPos[cbx_toolList.SelectedIndex].U = value;
            }
            catch { }
        }
        private void tbx_pickPosOffsetX_ValueChanged(double value)
        {
            try
            {
                upCamAlignTool.L_pickPosOffset[cbx_toolList.SelectedIndex].XY.X = value;
            }
            catch { }
        }
        private void tbx_pickPosOffsetY_ValueChanged(double value)
        {
            try
            {
                upCamAlignTool.L_pickPosOffset[cbx_toolList.SelectedIndex].XY.Y = value;
            }
            catch { }
        }
        private void tbx_pickPosOffsetU_ValueChanged(double value)
        {
            try
            {
                upCamAlignTool.L_pickPosOffset[cbx_toolList.SelectedIndex].U = value;
            }
            catch { }
        }
        private void tbx_saftyRangeX_ValueChanged(double value)
        {
            try
            {
                upCamAlignTool.L_safetyRange[cbx_toolList.SelectedIndex].XY.X = value;
            }
            catch { }
        }
        private void tbx_saftyRangeY_ValueChanged(double value)
        {
            try
            {
                upCamAlignTool.L_safetyRange[cbx_toolList.SelectedIndex].XY.Y = value;
            }
            catch { }
        }
        private void tbx_saftyRangeU_ValueChanged(double value)
        {
            try
            {
                upCamAlignTool.L_safetyRange[cbx_toolList.SelectedIndex].U = value;
            }
            catch { }
        }
        private void btn_touchToPickPos_Click(object sender, EventArgs e)
        {

        }

        private void btn_touchPickPos_Click(object sender, EventArgs e)
        {
            XYZU curPos;
            //////if (!Robot.Instance.GetCurPos(out curPos))
            //////{
            //////    lbl_toolTip.ForeColor = Color.Red;
            //////    lbl_toolTip.Text = "从机器人控制器获取当前坐标出错，请检查";
            //////    return;
            //////}

            //////tbx_pickPosX.Value = curPos.X.ToString("0.000");
            //////tbx_pickPosY.Value = curPos.Y.ToString("0.000");
            //////tbx_pickPosU.Value = curPos.U.ToString("0.000");
        }

    }
}
