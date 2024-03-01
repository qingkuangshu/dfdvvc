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
    /// 线线交点
    /// </summary>
    internal class LLIntersectTool : ToolBase
    {
        internal LLIntersectTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

            //自动连接输入
            bool firstOK = false;
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.查找直线 && !firstOK)
                {
                    InputItem inputItem = new InputItem();
                    inputItem.InputName = "线1";
                    inputItem.inputType = DataType.ListLine;
                    inputItem.sourceTask = taskName;
                    inputItem.sourceTool = Task.curTask.L_toolList[i].toolName;
                    inputItem.sourceOutput = "线";

                    L_inputItem.Add(inputItem);
                    firstOK = true;
                    continue;
                }

                if (Task.curTask.L_toolList[i].toolType == ToolType.查找直线)
                {
                    InputItem inputItem = new InputItem();
                    inputItem.InputName = "线2";
                    inputItem.inputType = DataType.ListLine;
                    inputItem.sourceTask = taskName;
                    inputItem.sourceTool = Task.curTask.L_toolList[i].toolName;
                    inputItem.sourceOutput = "线";

                    L_inputItem.Add(inputItem);
                    break;
                }
            }
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

            if (((ToolPar)参数).输入.线1 == null)
            {
                toolRunStatu = "未指定输入线1";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                return;
            }

            if (((ToolPar)参数).输入.线2 == null)
            {
                toolRunStatu = "未指定输入线2";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                return;
            }

            if (((ToolPar)参数).输入.线1.Count == 0)
            {
                toolRunStatu = "输入线1未查找到线";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                return;
            }

            if (((ToolPar)参数).输入.线2.Count == 0)
            {
                toolRunStatu = "输入线2未查找到线";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                return;
            }

            //检测是否为平行线
            HTuple angle = 0;
            HOperatorSet.AngleLl(((ToolPar)参数).输入.线1[0].起点.X,
                                           ((ToolPar)参数).输入.线1[0].起点.Y,
                                          ((ToolPar)参数).输入.线1[0].终点.X,
                                           ((ToolPar)参数).输入.线1[0].终点.Y,
                                           ((ToolPar)参数).输入.线2[0].起点.X,
                                           ((ToolPar)参数).输入.线2[0].起点.Y,
                                          ((ToolPar)参数).输入.线2[0].终点.X,
                                           ((ToolPar)参数).输入.线2[0].终点.Y,
                                           out angle);
            angle = angle * 180 / Math.PI;
            if (Math.Abs(angle.D) < 10)
            {
                toolRunStatu = "两条线夹角过小，接近平行，无法求交点";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                return;
            }

            HTuple row, col, temp1;
            HOperatorSet.IntersectionLines(((ToolPar)参数).输入.线1[0].起点.X,
                                           ((ToolPar)参数).输入.线1[0].起点.Y,
                                          ((ToolPar)参数).输入.线1[0].终点.X,
                                           ((ToolPar)参数).输入.线1[0].终点.Y,
                                           ((ToolPar)参数).输入.线2[0].起点.X,
                                           ((ToolPar)参数).输入.线2[0].起点.Y,
                                          ((ToolPar)参数).输入.线2[0].终点.X,
                                           ((ToolPar)参数).输入.线2[0].终点.Y,
                                           out row,
                                           out col,
                                           out temp1);

            HObject cross;
            HOperatorSet.GenCrossContourXld(out cross, row, col, new HTuple(50), new HTuple(0));
            HObject circle;
            HOperatorSet.GenCircle(out circle, row, col, 15);
            DispObj(cross, "green");
            DispObj(circle, "green");
            ((ToolPar)参数).输出.点.Clear();
            ((ToolPar)参数).输出.点.Add(new XY(row, col));

            sw.Stop();
            toolRunStatu = "运行成功";
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
            private List<Line> _线1 = new List<Line>();
            public List<Line> 线1
            {
                get { return _线1; }
                set { _线1 = value; }
            }

            private List<Line> _线2 = new List<Line>();
            public List<Line> 线2
            {
                get { return _线2; }
                set { _线2 = value; }
            }
        }
        [Serializable]
        public class P运行 { }
        [Serializable]
        internal class P输出
        {
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
