using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Pro
{
    [Serializable]
    internal class DefineTool : ToolBase
    {


        /// <summary>
        /// 类构造器
        /// </summary>
        /// <param name="toolName">工具名称</param>
        /// <param name="taskName">所属任务</param>
        /// <param name="toolType">工具类型</param>
        internal DefineTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

            ////自动连接输入
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
        /// 因为极耳不是用深度学习推理出来的，故其单独自成一列
        /// </summary>
        internal LeiBieModel I_极耳 = new LeiBieModel();


        HObject defectRegion = null;
        HObject defectImg = null;
        /// <summary>
        /// 运行工具
        /// </summary>
        /// <param name="updateImage">是否刷新图像</param>
        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
        {
            if (Frm_ShowDefect.Instance.hasShown)
            {
                Frm_ShowDefect.Instance.HideHWindow();
            }
            defectRegion = null;
            defectImg = null;
            toolRunStatu = "未知原因";
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            if (initRun)
            {
                参数 = new ToolPar();
                if (I_极耳 == null)
                {
                    I_极耳 = new LeiBieModel();
                    I_极耳.LeiBie = "极耳";
                }
                toolRunStatu = "运行成功";
                sw.Stop();
                return;
            }
            try
            {
                //判定一下是否halcon引擎是否运行NG了，若是的话，则此处直接统计NG，不做其他操作

                List<ToolTerminal> m_listOutputs = ((ImageEngineTool)Task.FindTaskByName(taskName).FindToolByName("图像脚本")).m_listOutputs;
                HObject R_MoQu = null, R_QueXian = null;
                HTuple R_RunResult = new HTuple();
                for (int i = 0; i < m_listOutputs.Count; i++)
                {
                    switch (m_listOutputs[i].Name)
                    {
                        case "R_MoQu":
                            R_MoQu = m_listOutputs[i].Value as HObject;
                            break;
                        case "R_RunQueXian":
                            R_QueXian = m_listOutputs[i].Value as HObject;
                            break;
                        case "RunResult":
                            R_RunResult = m_listOutputs[i].Value as HTuple;
                            break;
                    }
                }
                if (R_RunResult == null || R_RunResult.S.Contains("NG:极耳异常"))
                {
                    Project.Instance.configuration.NGNum++;
                    toolRunStatu = "运行NG，极耳异常";
                    GetImageWindow().DispText("判定NG：极耳异常", "red", "top", "left", 16);
                    goto Exit;
                }
                DispObj(R_MoQu, "green");





                #region 判断当前极耳是否OK

                //if (I_极耳.CheckEnable)
                //{
                //    //获取当前极耳面积
                //    HObject hob = ((PreconditionTool.ToolPar)Task.FindTaskByName(taskName).FindToolByName("图像预处理").参数).输出.区域;
                //    if (hob != null)
                //    {
                //        HOperatorSet.AreaCenter(hob, out HTuple area, out HTuple row, out HTuple col);
                //        I_极耳.BeforArea = area.D;
                //        if (I_极耳.BeforArea > I_极耳.MinArea)
                //        {
                //            I_极耳.CurrentResultOK = true;
                //        }
                //        else
                //        {
                //            I_极耳.CurrentResultOK = false;
                //            I_极耳.NG++;
                //        }
                //    }
                //    else
                //    {
                //        I_极耳.BeforArea = 0;
                //        I_极耳.CurrentResultOK = true;
                //    }
                //}

                #endregion


                #region 将语义分割推理检测识别到的缺陷信息显示到主界面自定义栏上

                //1.先拿到推理工具当中的缺陷列表
                List<LeiBieModel> lstMode = ((InferenceTool)Task.FindTaskByName(taskName).FindToolByName("推理识别")).lstDgvDataModel;

                Project.Instance.configuration.lstLeiBie = lstMode;



                //2.根据拿到的信息显示到主界面当中
                if (lstMode != null && lstMode.Count > 0)
                {
                    //Frm_Debug.Instance.DgvData.Rows.Clear();
                    for (int i = 0; i < lstMode.Count; i++)
                    {
                        Frm_Debug.Instance.DgvData.Rows[i].Cells[2].Value = lstMode[i].BeforArea;
                        if (lstMode[i].CurrentResultOK)
                            Frm_Debug.Instance.DgvData.Rows[i].Cells[2].Style.BackColor = Color.Green;
                        else
                        {
                            Frm_Debug.Instance.DgvData.Rows[i].Cells[2].Style.BackColor = Color.Red;
                            defectRegion = lstMode[i].AllRegionToOne();
                        }
                    }
                }
                //3. 将极耳信息显示到dgv当中
                int JiErIndex = Frm_Debug.Instance.DgvData.Rows.Count - 1;
                if (Frm_Debug.Instance.DgvData.Rows[JiErIndex].Cells[0].Value.ToString() != "极耳")
                {
                    Frm_Debug.Instance.DgvData.Rows.Add("极耳", I_极耳.MinArea, I_极耳.BeforArea, I_极耳.MaxArea, I_极耳.NG, I_极耳.CheckEnable);
                }
                else
                {
                    Frm_Debug.Instance.DgvData.Rows[JiErIndex].Cells[2].Value = I_极耳.BeforArea;
                }
                if (I_极耳.CurrentResultOK)
                    Frm_Debug.Instance.DgvData.Rows[JiErIndex].Cells[2].Style.BackColor = Color.Green;
                else
                    Frm_Debug.Instance.DgvData.Rows[JiErIndex].Cells[2].Style.BackColor = Color.Red;


                #endregion

                #region 更新总结果信息


                string ShowNGDetail = "";
                //1.根据极片以及极耳的检测结果，设置相应的状态
                bool IsOK = true;
                for (int i = 1; i < lstMode.Count; i++)
                {
                    if (lstMode[i].CheckEnable && !lstMode[i].CurrentResultOK)
                    {
                        ShowNGDetail += "\r\n" + lstMode[i].LeiBie + "：" + lstMode[i].BeforArea;
                        IsOK = false;
                        //break;
                    }
                }

                if (I_极耳.CheckEnable && !I_极耳.CurrentResultOK)
                {
                    ShowNGDetail += "\r\n" + "极耳" + "：" + I_极耳.BeforArea;
                }
                if (I_极耳.CheckEnable)
                {
                    IsOK = IsOK && I_极耳.CurrentResultOK;
                }


                if (R_RunResult == null || R_RunResult.S.Contains("NG") || !IsOK)
                {
                    Project.Instance.configuration.NGNum++;
                    toolRunStatu = "存在缺陷";
                    DispObj(R_QueXian, "red");
                    Frm_Main.Instance.lb_RunResult.ForeColor = Color.Red;
                    Frm_Main.Instance.lb_RunResult.Text = "NG";
                    ShowNGDetail += "\r\n" + "判定结果：NG";
                    GetImageWindow().DispText(ShowNGDetail, "red", "top", "left", 16);
                    toolRunStatu = "运行失败";
                }
                else
                {
                    Project.Instance.configuration.OKNum++;
                    Frm_Main.Instance.lb_RunResult.ForeColor = Color.Green;
                    Frm_Main.Instance.lb_RunResult.Text = "OK";
                    ShowNGDetail += "\r\n" + "判定结果：OK";
                    GetImageWindow().DispText(ShowNGDetail, "green", "top", "left", 16);
                    toolRunStatu = "运行成功";
                }


                #endregion

            }
            catch (Exception ex)
            {
                toolRunStatu = ex.Message;
                goto Exit;
            }
            sw.Stop();



        Exit:
            if (Frm_Inference.hasShown && Frm_Inference.taskName == taskName && Frm_Inference.toolName == toolName)
            {

            }
            //3.更新OK，NG信息
            Frm_Debug.Instance.lb_OK.Text = Project.Instance.configuration.OKNum.ToString();
            Frm_Debug.Instance.lb_NG.Text = Project.Instance.configuration.NGNum.ToString();
            Frm_Debug.Instance.lb_AllNum.Text = (Project.Instance.configuration.OKNum + Project.Instance.configuration.NGNum).ToString();
            Frm_Debug.Instance.lb_Lianglv.Text = (Project.Instance.configuration.OKNum * 1.0 / (Project.Instance.configuration.OKNum + Project.Instance.configuration.NGNum) * 100).ToString("F2") + " %";
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
