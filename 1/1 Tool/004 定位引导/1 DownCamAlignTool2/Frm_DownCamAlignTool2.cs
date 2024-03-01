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
    public partial class Frm_DownCamAlignTool2 : UIForm
    {
        public Frm_DownCamAlignTool2()
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
        internal static DownCamAlignTool2 downCamAlignTool2;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_DownCamAlignTool2 _instance;
        internal static Frm_DownCamAlignTool2 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_DownCamAlignTool2();
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
            downCamAlignTool2 = (DownCamAlignTool2)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;
            Instance.Show();
            Application.DoEvents();
            hasShown = true;

            downCamAlignTool2.UpdateInput();

            Thread th1 = new Thread(() =>
            {
                downCamAlignTool2.Run();
            });
            th1.IsBackground = true;
            th1.Start();

            Instance.ckb_taskFailKeepRun.Checked = downCamAlignTool2.taskFailKeepRun;
            Instance.ckb_enableBasedBoard.Checked = downCamAlignTool2.enableBasedBoard;

            Instance.tbx_photoPosX1.Value = downCamAlignTool2.photoPos1.XY.X.ToString();
            Instance.tbx_photoPosY1.Value = downCamAlignTool2.photoPos1.XY.Y.ToString();
            Instance.tbx_photoPosU1.Value = downCamAlignTool2.photoPos1.U.ToString();

            Instance.tbx_photoPosX2.Value = downCamAlignTool2.photoPos2.XY.X.ToString();
            Instance.tbx_photoPosY2.Value = downCamAlignTool2.photoPos2.XY.Y.ToString();
            Instance.tbx_photoPosU2.Value = downCamAlignTool2.photoPos2.U.ToString();

            Instance.tbx_templateFeatureX.Value = downCamAlignTool2.templateFeaturePos.XY.X.ToString();
            Instance.tbx_templateFeatureY.Value = downCamAlignTool2.templateFeaturePos.XY.Y.ToString();
            Instance.tbx_templateFeatureU.Value = downCamAlignTool2.templateFeaturePos.U.ToString();

            Instance.tbx_templatePlacePosX.Value = downCamAlignTool2.templatePlacePos.XY.X.ToString();
            Instance.tbx_templatePlacePosY.Value = downCamAlignTool2.templatePlacePos.XY.Y.ToString();
            Instance.tbx_templatePlacePosU.Value = downCamAlignTool2.templatePlacePos.U.ToString();

            Instance.tbx_templatePlacePosOffsetX.Value = downCamAlignTool2.templatePlacePosOffset.XY.X;
            Instance.tbx_templatePlacePosOffsetY.Value = downCamAlignTool2.templatePlacePosOffset.XY.Y;
            Instance.tbx_templatePlacePosOffsetU.Value = downCamAlignTool2.templatePlacePosOffset.U;

            Instance.tbx_templateBasedBoardPosX.Value = downCamAlignTool2.templateBasedBoardPos.XY.X.ToString();
            Instance.tbx_templateBasedBoardPosY.Value = downCamAlignTool2.templateBasedBoardPos.XY.Y.ToString();
            Instance.tbx_templateBasedBoardPosU.Value = downCamAlignTool2.templateBasedBoardPos.U.ToString();

            Instance.lbl_curFeaturePosX.Text = downCamAlignTool2.curBasedBoardPos.XY.X.ToString();
            Instance.lbl_curFeaturePosY.Text = downCamAlignTool2.curBasedBoardPos.XY.Y.ToString();
            Instance.lbl_curFeaturePosU.Text = downCamAlignTool2.curBasedBoardPos.U.ToString();

            Instance.lbl_curPlacePosX.Text = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输出.位置.XY.X.ToString();
            Instance.lbl_curPlacePosY.Text = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输出.位置.XY.Y.ToString();
            Instance.lbl_curPlacePosU.Text = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输出.位置.U.ToString();

            Instance.tbx_saftyRangeX.Value = downCamAlignTool2.safetyRange.XY.X.ToString();
            Instance.tbx_saftyRangeY.Value = downCamAlignTool2.safetyRange.XY.Y.ToString();
            Instance.tbx_saftyRangeU.Value = downCamAlignTool2.safetyRange.U.ToString();

            //功能启用
            if (!Permission.CheckPermission(PermissionGrade.Developer, false))
            {

            }
            else
            {

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
            downCamAlignTool2.ResetTool();
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

            downCamAlignTool2.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }
        private void btn_runTool_Click(object sender, EventArgs e)
        {
            downCamAlignTool2.Run();
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
        private void Frm_DownCamAlignTool2_ExtendBoxClick(object sender, EventArgs e)
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


        private void ckb_enableBasedBoard_Click(object sender, EventArgs e)
        {
            downCamAlignTool2.enableBasedBoard = ckb_enableBasedBoard.Checked;
        }

        private void tbx_photoPosX1_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.photoPos1.XY.X = value;
            }
            catch { }
        }
        private void tbx_photoPosY1_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.photoPos1.XY.Y = value;
            }
            catch { }
        }
        private void tbx_photoPosU1_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.photoPos1.U = value;
            }
            catch { }
        }
        private void btn_touchPhotoPos1_Click(object sender, EventArgs e)
        {
            //////RobotPos curPos;
            //////if (!Robot.Instance.GetCurPos(out curPos))
            //////{
            //////    FuncLib.ShowMsg("从机器人控制器获取当前坐标出错，请检查", InfoType.Error);
            //////    return;
            //////}
            //////if (taskName == "PCB 贴合" || taskName == "光板 贴合")
            //////{
            //////    if (Math.Abs(curPos.xyzu.Z - ((Calibrate)Project.FindServiceByName("标定_底部相机")).moveCenterPos.xyzu.Z) > 0.1)
            //////    {
            //////        MessageBox.Show("操作失败，PCB拍照位1的Z坐标必须和下相机标定平移位的Z坐标相同，请重新示教PCB拍照位1");
            //////        return;
            //////    }
            //////}

            //////Task.FindTaskByName(taskName).Run(false);

            //////tbx_photoPosX1.Value = curPos.xyzu.X.ToString("0.000");
            //////tbx_photoPosY1.Value = curPos.xyzu.Y.ToString("0.000");
            //////tbx_photoPosU1.Value = curPos.xyzu.U.ToString("0.000");


            //////downCamAlignTool2.templateFeaturePos.XY.X = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.元件Mark1[0].X;
            //////downCamAlignTool2.templateFeaturePos.XY.Y = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.元件Mark1[0].Y;
            //////HTuple temp1;
            //////HOperatorSet.AngleLx(((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.元件Mark1[0].X, ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.元件Mark1[0].Y, ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.元件Mark2[0].X - (downCamAlignTool2.photoPos2.XY.X - downCamAlignTool2.photoPos1.XY.X), ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.元件Mark2[0].Y - (downCamAlignTool2.photoPos2.XY.Y - downCamAlignTool2.photoPos1.XY.Y), out temp1);

            //////downCamAlignTool2.templateFeaturePos.U = temp1;


            //////tbx_templateFeatureX.Value = downCamAlignTool2.templateFeaturePos.XY.X.ToString();
            //////tbx_templateFeatureY.Value = downCamAlignTool2.templateFeaturePos.XY.Y.ToString();
            //////tbx_templateFeatureU.Value = downCamAlignTool2.templateFeaturePos.U.ToString();
        }

        private void tbx_photoPosX2_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.photoPos2.XY.X = value;
            }
            catch { }
        }
        private void tbx_photoPosY2_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.photoPos2.XY.Y = value;
            }
            catch { }
        }
        private void tbx_photoPosU2_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.photoPos2.U = value;
            }
            catch { }
        }
        private void btn_touchPhotoPos2_Click(object sender, EventArgs e)
        {
            //////RobotPos curPos;
            //////if (!Robot.Instance.GetCurPos(out curPos))
            //////{
            //////    FuncLib.ShowMsg("从机器人控制器获取当前坐标出错，请检查", InfoType.Error);
            //////    return;
            //////}
            //////if (taskName == "PCB 贴合" || taskName == "光板 贴合")
            //////{
            //////    if (Math.Abs(curPos.xyzu.Z - ((Calibrate)Project.FindServiceByName("标定_底部相机")).moveCenterPos.xyzu.Z) > 0.1)
            //////    {
            //////        MessageBox.Show("操作失败，PCB拍照位2的Z坐标必须和下相机标定平移位的Z坐标相同，请重新示教PCB拍照位2");
            //////        return;
            //////    }
            //////}

            //////Task.FindTaskByName(taskName).Run(false);

            //////tbx_photoPosX2.Value = curPos.xyzu.X.ToString("0.000");
            //////tbx_photoPosY2.Value = curPos.xyzu.Y.ToString("0.000");
            //////tbx_photoPosU2.Value = curPos.xyzu.U.ToString("0.000");


            //////downCamAlignTool2.templateFeaturePos.XY.X = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.元件Mark1[0].X;
            //////downCamAlignTool2.templateFeaturePos.XY.Y = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.元件Mark1[0].Y;
            //////HTuple temp1;
            //////HOperatorSet.AngleLx(((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.元件Mark1[0].X, ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.元件Mark1[0].Y, ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.元件Mark2[0].X - (downCamAlignTool2.photoPos2.XY.X - downCamAlignTool2.photoPos1.XY.X), ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.元件Mark2[0].Y - (downCamAlignTool2.photoPos2.XY.Y - downCamAlignTool2.photoPos1.XY.Y), out temp1);

            //////downCamAlignTool2.templateFeaturePos.U = temp1;

            //////tbx_templateFeatureX.Value = downCamAlignTool2.templateFeaturePos.XY.X.ToString();
            //////tbx_templateFeatureY.Value = downCamAlignTool2.templateFeaturePos.XY.Y.ToString();
            //////tbx_templateFeatureU.Value = downCamAlignTool2.templateFeaturePos.U.ToString();
        }

        private void tbx_templateFeatureX_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.templateFeaturePos.XY.X = value;
            }
            catch { }
        }
        private void tbx_templateFeatureY_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.templateFeaturePos.XY.Y = value;
            }
            catch { }
        }
        private void tbx_templateFeatureU_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.templateFeaturePos.U = value;
            }
            catch { }
        }
        private void btn_touchTemplateFeaturePos_Click(object sender, EventArgs e)
        {
            //////downCamAlignTool2.templateFeaturePos.Point.X = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.位置[0].Point.X;
            //////downCamAlignTool2.templateFeaturePos.Point.Y = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.位置[0].Point.Y;
            //////downCamAlignTool2.templateFeaturePos.U = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.位置[0].U;

            //////tbx_templateFeatureX.Value = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.位置[0].Point.X.ToString();
            //////tbx_templateFeatureY.Value = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.位置[0].Point.Y.ToString();
            //////tbx_templateFeatureU.Value = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.位置[0].U.ToString();
        }

        private void tbx_templatePlacePosX_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.templatePlacePos.XY.X = value;
            }
            catch { }
        }
        private void tbx_templatePlacePosY_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.templatePlacePos.XY.Y = value;
            }
            catch { }
        }
        private void tbx_templatePlacePosU_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.templatePlacePos.U = value;
            }
            catch { }
        }
        private void btn_touchPlacePos_Click(object sender, EventArgs e)
        {
            //////RobotPos curPos;
            //////if (!Robot.Instance.GetCurPos(out curPos))
            //////{
            //////    FuncLib.ShowMsg("从机器人控制器获取当前坐标出错，请检查", InfoType.Error);
            //////    return;
            //////}

            //////tbx_templatePlacePosX.Value = curPos.xyzu.X.ToString("0.000");
            //////tbx_templatePlacePosY.Value = curPos.xyzu.Y.ToString("0.000");
            //////tbx_templatePlacePosU.Value = curPos.xyzu.U.ToString("0.000");
        }

        private void tbx_templatePlacePosOffsetX_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.templatePlacePosOffset.XY.X = value;
            }
            catch { }
        }
        private void tbx_templatePlacePosOffsetY_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.templatePlacePosOffset.XY.Y = value;
            }
            catch { }
        }
        private void tbx_templatePlacePosOffsetU_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.templatePlacePosOffset.U = value;
            }
            catch { }
        }

        private void tbx_templateBasedBoardPosX_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.templateBasedBoardPos.XY.X = value;
            }
            catch { }
        }
        private void tbx_templateBasedBoardPosY_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.templateBasedBoardPos.XY.Y = value;
            }
            catch { }
        }
        private void tbx_templateBasedBoardPosU_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.templateBasedBoardPos.U = value;
            }
            catch { }
        }
        private void btn_touchTemplateBasedBoardPos_Click(object sender, EventArgs e)
        {
            //////RobotPos curPos;
            //////if (!Robot.Instance.GetCurPos(out curPos))
            //////{
            //////    FuncLib.ShowMsg("从机器人控制器获取当前坐标出错，请检查", InfoType.Error);
            //////    return;
            //////}

            //////if (Math.Abs(Scheme.curScheme.P载具拍照位1.xyzu.Z - ((Calibrate)Project.FindServiceByName("标定_移动相机")).moveCenterPos.xyzu.Z) > 0.1)
            //////{
            //////    MessageBox.Show("操作失败，载具拍照位1的Z坐标必须和移动相机标定位的Z坐标相同，请重新示教载具拍照位1");
            //////    return;
            //////}
            //////if (Math.Abs(Scheme.curScheme.P载具拍照位1.xyzu.U - ((Calibrate)Project.FindServiceByName("标定_移动相机")).moveCenterPos.xyzu.U) > 0.1)
            //////{
            //////    MessageBox.Show("操作失败，载具拍照位1的U坐标必须和移动相机标定位的U坐标相同，请重新示教载具拍照位1");
            //////    return;
            //////}

            //////if (Math.Abs(Scheme.curScheme.P载具拍照位2.xyzu.Z - ((Calibrate)Project.FindServiceByName("标定_移动相机")).moveCenterPos.xyzu.Z) > 0.1)
            //////{
            //////    MessageBox.Show("操作失败，载具拍照位2的Z坐标必须和移动相机标定位的Z坐标相同，请重新示教载具拍照位2");
            //////    return;
            //////}
            //////if (Math.Abs(Scheme.curScheme.P载具拍照位2.xyzu.U - ((Calibrate)Project.FindServiceByName("标定_移动相机")).moveCenterPos.xyzu.U) > 0.1)
            //////{
            //////    MessageBox.Show("操作失败，载具拍照位2的U坐标必须和移动相机标定位的U坐标相同，请重新示教载具拍照位2");
            //////    return;
            //////}

            //////double curCenterX = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.基板Mark1[0].X;
            //////double curCenterY = ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.基板Mark1[0].Y;
            //////HTuple angle = 0;
            //////HOperatorSet.AngleLx(((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.基板Mark1[0].X, ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.基板Mark1[0].Y, ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.基板Mark2[0].X + (Scheme.curScheme.P载具拍照位2.xyzu.X - Scheme.curScheme.P载具拍照位1.xyzu.X), ((DownCamAlignTool2.ToolPar)downCamAlignTool2.参数).输入.基板Mark2[0].Y + (Scheme.curScheme.P载具拍照位2.xyzu.Y - Scheme.curScheme.P载具拍照位1.xyzu.Y), out angle);

            //////if (angle > 0)
            //////    angle = -3.1415 + angle;
            //////angle = Math.Round(angle.D, 6);

            //////tbx_templateBasedBoardPosX.Value = curCenterX.ToString();
            //////tbx_templateBasedBoardPosY.Value = curCenterY.ToString();
            //////tbx_templateBasedBoardPosU.Value = angle.ToString();
        }

        private void tbx_saftyRangeX_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.safetyRange.XY.X = value;
            }
            catch { }
        }
        private void tbx_saftyRangeY_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.safetyRange.XY.Y = value;
            }
            catch { }
        }
        private void tbx_saftyRangeU_ValueChanged(double value)
        {
            try
            {
                downCamAlignTool2.safetyRange.U = value;
            }
            catch { }
        }

    }
}
