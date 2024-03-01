using HalconDotNet;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewWindow.Model;

namespace VM_Pro
{
    [Serializable]
    /// <summary>
    /// 模板匹配
    /// </summary>
    internal class UpCamAlignTool : ToolBase
    {
        internal UpCamAlignTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

            D_toolName.Add("工具1", 0);

            L_featurePos.Add(new XYU());
            L_pickPos.Add(new XYU());
            L_pickPosOffset.Add(new XYU());
            L_safetyRange.Add(new XYU(10, 10, 10));

            L_featurePos.Add(new XYU());
            L_pickPos.Add(new XYU());
            L_pickPosOffset.Add(new XYU());
            L_safetyRange.Add(new XYU(10, 10, 10));

            L_featurePos.Add(new XYU());
            L_pickPos.Add(new XYU());
            L_pickPosOffset.Add(new XYU());
            L_safetyRange.Add(new XYU(10, 10, 10));

            L_featurePos.Add(new XYU());
            L_pickPos.Add(new XYU());
            L_pickPosOffset.Add(new XYU());
            L_safetyRange.Add(new XYU(10, 10, 10));

            //自动连接输入
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.引用标定)
                {
                    InputItem inputItem = new InputItem();
                    inputItem.InputName = "位置";
                    inputItem.inputType = DataType.ListXYU;
                    inputItem.sourceTask = taskName;
                    inputItem.sourceTool = Task.curTask.L_toolList[i].toolName;
                    inputItem.sourceOutput = "位置";

                    L_inputItem.Add(inputItem);
                    break;
                }
            }
        }

        /// <summary>
        /// 工具锁
        /// </summary>
        private object obj = new object();
        /// <summary>
        /// 抓取模式
        /// </summary>
        internal PickMode pickMode = PickMode.OneTool;
        /// <summary>
        /// 算法自查
        /// </summary>
        internal bool enableCheckError = false;
        /// <summary>
        /// 工具名称
        /// </summary>
        internal Dictionary<string, int> D_toolName = new Dictionary<string, int>();
        /// <summary>
        /// 当前所使用的工具名称
        /// </summary>
        internal string curToolName = string.Empty;
        /// <summary>
        /// 制作模板时特征点坐标
        /// </summary>
        internal List<XYU> L_featurePos = new List<XYU>();
        /// <summary>
        /// 制作模板时示教的取料位置坐标
        /// </summary>
        internal List<XYU> L_pickPos = new List<XYU>();
        /// <summary>
        /// 模板取料位置补偿值
        /// </summary>
        internal List<XYU> L_pickPosOffset = new List<XYU>();
        /// <summary>
        /// 安全范围
        /// </summary>
        internal List<XYU> L_safetyRange = new List<XYU>();


        /// <summary>
        /// 复位工具
        /// </summary>
        internal override void ResetTool()
        {


            Frm_UpCamAlignTool.Instance.lbl_runTime.Text = "0 ms";
            Frm_UpCamAlignTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
            Frm_UpCamAlignTool.Instance.lbl_toolTip.Text = "暂无提示";
        }
        /// <summary>
        /// 绕点旋转
        /// </summary>
        /// <param name="curPos">当前被旋转的点</param>
        /// <param name="rotateCenter">旋转中心</param>
        /// <param name="rotateAngle">旋转角度</param>
        /// <returns></returns>
        internal XYU RotateAt(XYU curPos, XYU rotateCenter, double rotateAngle)
        {
            double rad = rotateAngle * Math.PI / 180;
            var res = new XYU();
            res.XY.X = rotateCenter.XY.X + (curPos.XY.X - rotateCenter.XY.X) * Math.Cos(rad) - (curPos.XY.Y - rotateCenter.XY.Y) * Math.Sin(rad);
            res.XY.Y = rotateCenter.XY.Y + (curPos.XY.X - rotateCenter.XY.X) * Math.Sin(rad) + (curPos.XY.Y - rotateCenter.XY.Y) * Math.Cos(rad);
            res.U = curPos.U + rotateAngle;

            if (res.U < -180)
            {
                res.U += 360;
            }
            else if (res.U >= 180)
            {
                res.U -= 360;
            }
            return res;
        }
        /// <summary>
        /// 运行工具    
        /// </summary>
        /// <param name="initRun">初始化运行</param>
        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
        {
            toolRunStatu = "未知原因";
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            if (initRun)
            {
                参数 = new ToolPar();
                toolRunStatu = "运行成功";
                sw.Stop();
                return;
            }

            ((ToolPar)参数).输出.位置.Clear();
            if (pickMode == PickMode.MoreTool)
            {
                for (int i = 0; i < ((ToolPar)参数).输入.位置.Count; i++)
                {
                    //首先旋转使角度重合,然后将机械手平移，计算出使本次定位产品和创建模板时的产品重合时机械手的坐标，即取料坐标
                    double offsetU = ((ToolPar)参数).输入.位置[i].U - L_featurePos[D_toolName[curToolName]].U;
                    offsetU = offsetU * 180 / Math.PI;
                    double robotPosAfterRotateU = ((L_pickPos[D_toolName[curToolName]] + L_pickPosOffset[D_toolName[curToolName]]).U) + offsetU;

                    //计算旋转之后模板特征点的XY坐标
                    XYU featurePosAfterRotate = RotateAt(L_featurePos[D_toolName[curToolName]], L_pickPos[D_toolName[curToolName]] + L_pickPosOffset[D_toolName[curToolName]], offsetU);

                    //计算经过旋转的特征点坐标和创建模板时的机械坐标的平移量
                    double offsetX = ((ToolPar)参数).输入.位置[i].XY.X - featurePosAfterRotate.XY.X;
                    double offsetY = ((ToolPar)参数).输入.位置[i].XY.Y - featurePosAfterRotate.XY.Y;

                    //机械手再平移这些量
                    XYU robotPosAfterRotateUAndMoveXY = new XYU();
                    robotPosAfterRotateUAndMoveXY.XY.X = (L_pickPos[D_toolName[curToolName]] + L_pickPosOffset[D_toolName[curToolName]]).XY.X + offsetX;
                    robotPosAfterRotateUAndMoveXY.XY.Y = (L_pickPos[D_toolName[curToolName]] + L_pickPosOffset[D_toolName[curToolName]]).XY.Y + offsetY;
                    robotPosAfterRotateUAndMoveXY.U = robotPosAfterRotateU;

                    ((ToolPar)参数).输出.位置.Add(robotPosAfterRotateUAndMoveXY);

                    if (Frm_UpCamAlignTool.hasShown && Frm_UpCamAlignTool.taskName == taskName && Frm_UpCamAlignTool.toolName == toolName)
                    {
                        Frm_UpCamAlignTool.Instance.lbl_inputPosX.Text = ((ToolPar)参数).输入.位置[0].XY.X.ToString();
                        Frm_UpCamAlignTool.Instance.lbl_inputPosY.Text = ((ToolPar)参数).输入.位置[0].XY.Y.ToString();
                        Frm_UpCamAlignTool.Instance.lbl_inputPosU.Text = ((ToolPar)参数).输入.位置[0].U.ToString();

                        Frm_UpCamAlignTool.Instance.lbl_resultPosX.Text = ((ToolPar)参数).输出.位置[0].XY.X.ToString();
                        Frm_UpCamAlignTool.Instance.lbl_resultPosY.Text = ((ToolPar)参数).输出.位置[0].XY.Y.ToString();
                        Frm_UpCamAlignTool.Instance.lbl_resultPosU.Text = ((ToolPar)参数).输出.位置[0].U.ToString();
                    }

                    //安全管控
                    XYU offset = ((ToolPar)参数).输入.位置[i] - L_featurePos[D_toolName[curToolName]];
                    if (Math.Abs(offset.XY.X) > L_safetyRange[D_toolName[curToolName]].XY.X)
                    {
                        toolRunStatu = string.Format("产品 {0} 的 X 坐标超限，当前差值：{1}  上限差值：{2} mm", i + 1, Math.Abs(offset.XY.X), L_safetyRange[i].XY.X);
                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }
                    else if (Math.Abs(offset.XY.Y) > L_safetyRange[D_toolName[curToolName]].XY.Y)
                    {
                        toolRunStatu = string.Format("产品 {0} 的 Y 坐标超限，当前差值：{1}  上限差值：{2} mm", i + 1, Math.Abs(offset.XY.Y), L_safetyRange[i].XY.Y);
                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }
                    else if (Math.Abs(offset.U) * 180 / Math.PI > L_safetyRange[D_toolName[curToolName]].U)
                    {
                        toolRunStatu = string.Format("产品 {0} 的 U 坐标超限，当前差值：{1}  上限差值：{2} 度", i + 1, Math.Abs(offset.U), L_safetyRange[i].U);
                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ((ToolPar)参数).输入.位置.Count; i++)
                {
                    if (((ToolPar)参数).输入.位置[i].temp)
                        continue;

                    //首先旋转使角度重合,然后将机械手平移，计算出使本次定位产品和创建模板时的产品重合时机械手的坐标，即取料坐标
                    double offsetU = ((ToolPar)参数).输入.位置[i].U - L_featurePos[0].U;
                    offsetU = offsetU * 180 / Math.PI;
                    double robotPosAfterRotateU = ((L_pickPos[0] + L_pickPosOffset[i])).U + offsetU;

                    //计算经过旋转的特征点坐标和创建模板时的机械坐标的平移量
                    double offsetX = ((ToolPar)参数).输入.位置[i].XY.X - L_featurePos[0].XY.X;
                    double offsetY = ((ToolPar)参数).输入.位置[i].XY.Y - L_featurePos[0].XY.Y;

                    //机械手再平移这些量
                    XYU robotPosAfterRotateUAndMoveXY = new XYU();
                    robotPosAfterRotateUAndMoveXY.XY.X = (L_pickPos[0] + L_pickPosOffset[i]).XY.X + offsetX;
                    robotPosAfterRotateUAndMoveXY.XY.Y = (L_pickPos[0] + L_pickPosOffset[i]).XY.Y + offsetY;
                    robotPosAfterRotateUAndMoveXY.U = robotPosAfterRotateU;

                    ((ToolPar)参数).输出.位置.Add(robotPosAfterRotateUAndMoveXY);

                    if (Frm_UpCamAlignTool.hasShown && Frm_UpCamAlignTool.taskName == taskName && Frm_UpCamAlignTool.toolName == toolName)
                    {
                        Frm_UpCamAlignTool.Instance.lbl_inputPosX.Text = ((ToolPar)参数).输入.位置[Frm_UpCamAlignTool.Instance.cbx_toolList.SelectedIndex == -1 ? 0 : Frm_UpCamAlignTool.Instance.cbx_toolList.SelectedIndex].XY.X.ToString();
                        Frm_UpCamAlignTool.Instance.lbl_inputPosY.Text = ((ToolPar)参数).输入.位置[Frm_UpCamAlignTool.Instance.cbx_toolList.SelectedIndex == -1 ? 0 : Frm_UpCamAlignTool.Instance.cbx_toolList.SelectedIndex].XY.Y.ToString();
                        Frm_UpCamAlignTool.Instance.lbl_inputPosU.Text = ((ToolPar)参数).输入.位置[Frm_UpCamAlignTool.Instance.cbx_toolList.SelectedIndex == -1 ? 0 : Frm_UpCamAlignTool.Instance.cbx_toolList.SelectedIndex].U.ToString();

                        Frm_UpCamAlignTool.Instance.lbl_resultPosX.Text = ((ToolPar)参数).输出.位置[Frm_UpCamAlignTool.Instance.cbx_toolList.SelectedIndex == -1 ? 0 : Frm_UpCamAlignTool.Instance.cbx_toolList.SelectedIndex].XY.X.ToString();
                        Frm_UpCamAlignTool.Instance.lbl_resultPosY.Text = ((ToolPar)参数).输出.位置[Frm_UpCamAlignTool.Instance.cbx_toolList.SelectedIndex == -1 ? 0 : Frm_UpCamAlignTool.Instance.cbx_toolList.SelectedIndex].XY.Y.ToString();
                        Frm_UpCamAlignTool.Instance.lbl_resultPosU.Text = ((ToolPar)参数).输出.位置[Frm_UpCamAlignTool.Instance.cbx_toolList.SelectedIndex == -1 ? 0 : Frm_UpCamAlignTool.Instance.cbx_toolList.SelectedIndex].U.ToString();
                    }

                    //安全管控
                    XYU offset = ((ToolPar)参数).输入.位置[i] - L_featurePos[i];
                    if (Math.Abs(offset.XY.X) > L_safetyRange[0].XY.X)
                    {
                        toolRunStatu = string.Format("产品 {0} 的 X 坐标超限，当前差值：{1}  上限差值：{2} mm", i + 1, Math.Abs(offset.XY.X), L_safetyRange[i].XY.X);
                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }
                    else if (Math.Abs(offset.XY.Y) > L_safetyRange[0].XY.Y)
                    {
                        toolRunStatu = string.Format("产品 {0} 的 Y 坐标超限，当前差值：{1}  上限差值：{2} mm", i + 1, Math.Abs(offset.XY.Y), L_safetyRange[i].XY.Y);
                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }
                    else if (Math.Abs(offset.U) * 180 / Math.PI > L_safetyRange[0].U)
                    {
                        toolRunStatu = string.Format("产品 {0} 的 U 坐标超限，当前差值：{1}  上限差值：{2} 度", i + 1, Math.Abs(offset.U), L_safetyRange[i].U);
                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }
                }
            }

            sw.Stop();
            toolRunStatu = "运行成功";
        Exit:
            if (Frm_UpCamAlignTool.hasShown && Frm_UpCamAlignTool.taskName == taskName && Frm_UpCamAlignTool.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_UpCamAlignTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());

                if (toolRunStatu == "运行成功")
                    Frm_UpCamAlignTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                else
                    Frm_UpCamAlignTool.Instance.lbl_toolTip.ForeColor = Color.Red;

                Frm_UpCamAlignTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
            }
        }

        #region 工具参数
        [Serializable]
        public class ToolPar : ToolParBase
        {
            private P输入 _输入 = new P输入();
            public P输入 输入
            {
                get { return _输入; }
                set { _输入 = value; }
            }

            private P运行 _运行 = new P运行();
            public P运行 运行
            {
                get { return _运行; }
                set { _运行 = value; }
            }

            private P输出 _输出 = new P输出();
            public P输出 输出
            {
                get { return _输出; }
                set { _输出 = value; }
            }
        }
        [Serializable]
        public class P输入
        {
            private List<XYU> _位置 = new List<XYU>();
            public List<XYU> 位置
            {
                get { return _位置; }
                set { _位置 = value; }
            }
        }
        [Serializable]
        public class P运行 { }
        [Serializable]
        internal class P输出
        {
            private List<XYU> _位置 = new List<XYU>();
            public List<XYU> 位置
            {
                get { return _位置; }
                set { _位置 = value; }
            }
        }
        #endregion

    }

    /// <summary>
    /// 抓取模式
    /// </summary>
    internal enum PickMode
    {
        OneTool,
        MoreTool,
    }

}
