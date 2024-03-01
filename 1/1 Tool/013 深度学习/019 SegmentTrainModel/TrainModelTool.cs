using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Pro
{
    [Serializable]
    internal class TrainModelTool : ToolBase
    {

        /// <summary>
        /// 类构造器，辅助frm_Inference界面逻辑运算
        /// </summary>
        /// <param name="toolName">工具名称</param>
        /// <param name="taskName">所属任务</param>
        /// <param name="toolType">工具类型</param>
        internal TrainModelTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

            //自动连接输入
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.采集图像)
                {
                    InputItem inputItem = new InputItem();
                    inputItem.InputName = "图像";
                    inputItem.inputType = DataType.Image;
                    inputItem.sourceTask = taskName;
                    inputItem.sourceTool = Task.curTask.L_toolList[i].toolName;
                    inputItem.sourceOutput = "图像";

                    L_inputItem.Add(inputItem);
                    break;
                }
            }
        }

        /// <summary>
        /// 标注文件的路径
        /// </summary>
        internal string dictPath = "";

        [NonSerialized]
        /// <summary>
        /// 标注文件句柄
        /// </summary>
        internal HTuple dictHandle = null;

        /// <summary>
        /// 训练的图片宽度
        /// </summary>
        internal int ImgWidth = 512;

        /// <summary>
        /// 训练的图片高度
        /// </summary>
        internal int ImgHeight = 512;

        /// <summary>
        /// 训练的图片通道数
        /// </summary>
        internal int ImgChannel = 1;

        /// <summary>
        /// 训练的比例
        /// </summary>
        internal int XunLianBi = 70;

        /// <summary>
        /// 训练时验证的比例
        /// </summary>
        internal int YanZhengBi = 15;

        /// <summary>
        /// 缺陷权重大小
        /// </summary>
        internal int QueXianQuanZhong = 1;

        internal int PiChuLi = 1;

        internal int Epochs = 2;

        internal double XueXiLv = 0.00001;

        internal double DongLiang = 0.99;

        internal bool IsCPU = true;


        /// <summary>
        /// 训练的模型路径
        /// </summary>
        internal string ModelPath = "";


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

            sw.Stop();
            toolRunStatu = "运行成功";
        Exit:
            if (Frm_TrainModel.hasShown && Frm_TrainModel.taskName == taskName && Frm_TrainModel.toolName == toolName)
            {
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
            private HObject _图像;
            public HObject 图像
            {
                get
                {
                    return _图像;
                }
                set
                {
                    _图像 = value;
                }
            }

            private List<XYU> _跟随 = new List<XYU>();
            public List<XYU> 跟随
            {
                get { return _跟随; }
                set { _跟随 = value; }
            }

            private HObject _区域;
            public HObject 区域
            {
                get { return _区域; }
                set { _区域 = value; }
            }
        }
        [Serializable]
        public class P运行 { }
        [Serializable]
        internal class P输出
        {
            private HObject _图像;
            public HObject 图像
            {
                get
                {
                    return _图像;
                }
                set { _图像 = value; }
            }

            private int _数量;
            public int 数量
            {
                get { return _数量; }
                set { _数量 = value; }
            }

            private List<String> _文本 = new List<string>();
            public List<String> 文本
            {
                get { return _文本; }
                set { _文本 = value; }
            }
        }
        #endregion
    }
}
