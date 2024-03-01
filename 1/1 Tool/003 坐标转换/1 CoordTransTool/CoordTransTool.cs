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
    /// 引用标定
    /// </summary>
    internal class CoordTransTool : ToolBase
    {
        internal CoordTransTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Calibrate)
                {
                    calibFile = Project.Instance.L_Service[i].name;
                    break;
                }
            }

            //自动连接输入
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.模板匹配)
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
        /// 相机标定名称
        /// </summary>
        internal string calibFile = string.Empty;


        /// <summary>
        /// 复位工具
        /// </summary>
        internal override void ResetTool()
        {
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Calibrate)
                {
                    calibFile = Project.Instance.L_Service[i].name;
                    Frm_CoordTransTool.Instance.cbx_calibFileList.Text = calibFile;
                    break;
                }
            }

            Frm_CoordTransTool.Instance.lbl_runTime.Text = "0 ms";
            Frm_CoordTransTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
            Frm_CoordTransTool.Instance.lbl_toolTip.Text = "暂无提示";
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
                return;
            }

            if (calibFile == string.Empty)
            {
                toolRunStatu = "未指定标定相机";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            bool exist = false;
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == calibFile)
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                toolRunStatu = "所指定的标定相机不存在";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == calibFile)
                {
                    if (((Calibrate)Project.Instance.L_Service[i]).homMat2D == null)
                    {
                        toolRunStatu = "所指定的标定相机未标定";
                        if (!initRun)
                            FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }

                    break;
                }
            }

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == calibFile)
                {
                    ((ToolPar)参数).输出.位置.Clear();
                    for (int j = 0; j < ((ToolPar)参数).输入.位置.Count; j++)
                    {
                        HTuple rowAfterTrans;
                        HTuple colAfterTrans;
                        HOperatorSet.AffineTransPoint2d(((Calibrate)Project.Instance.L_Service[i]).homMat2D, ((ToolPar)参数).输入.位置[j].XY.X, ((ToolPar)参数).输入.位置[j].XY.Y, out rowAfterTrans, out colAfterTrans);

                        XYU xyu = new XYU();
                        xyu.XY.X = rowAfterTrans;
                        xyu.XY.Y = colAfterTrans;
                        xyu.U = ((ToolPar)参数).输入.位置[j].U;
                        xyu.temp = ((ToolPar)参数).输入.位置[j].temp;
                        ((ToolPar)参数).输出.位置.Add(xyu);
                    }

                    break;
                }
            }

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == calibFile)
                {
                    ((ToolPar)参数).输出.点.Clear();
                    for (int j = 0; j < ((ToolPar)参数).输入.点.Count; j++)
                    {
                        HTuple rowAfterTrans;
                        HTuple colAfterTrans;
                        HOperatorSet.AffineTransPoint2d(((Calibrate)Project.Instance.L_Service[i]).homMat2D, ((ToolPar)参数).输入.点[j].X, ((ToolPar)参数).输入.点[j].Y, out rowAfterTrans, out colAfterTrans);

                        XY xy = new XY();
                        xy.X = rowAfterTrans;
                        xy.Y = colAfterTrans;
                        ((ToolPar)参数).输出.点.Add(xy);
                    }

                    break;
                }
            }

            sw.Stop();
            toolRunStatu = "运行成功";
        Exit:
            if (Frm_CoordTransTool.hasShown && Frm_CoordTransTool.taskName == taskName && Frm_CoordTransTool.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_CoordTransTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());

                if (toolRunStatu == "运行成功")
                    Frm_CoordTransTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                else
                    Frm_CoordTransTool.Instance.lbl_toolTip.ForeColor = Color.Red;

                Frm_CoordTransTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
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
            private List<XY> _点 = new List<XY>();
            public List<XY> 点
            {
                get { return _点; }
                set { _点 = value; }
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
            private List<XY> _点 = new List<XY>();
            public List<XY> 点
            {
                get { return _点; }
                set { _点 = value; }
            }
        }
        #endregion

    }
}
