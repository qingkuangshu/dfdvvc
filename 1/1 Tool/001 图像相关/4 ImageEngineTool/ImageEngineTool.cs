using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VM_Pro
{
    [Serializable]
    internal class ImageEngineTool : ToolBase
    {
        /// <summary>
        /// 类构造器
        /// </summary>
        /// <param name="toolName">工具名称</param>
        /// <param name="taskName">所属任务</param>
        /// <param name="toolType">工具类型</param>
        internal ImageEngineTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;
            L_OutItemType = new List<DataType> { DataType.Image, DataType.Region };

        }
        [NonSerialized]
        /// <summary>
        /// Halcon主程序
        /// </summary>
        internal HDevProgram m_hProgram = new HDevProgram();
        [NonSerialized]
        /// <summary>
        /// Halcon外部函数
        /// </summary>
        internal HDevProcedure m_hProcedure = new HDevProcedure();
        [NonSerialized]
        /// <summary>
        /// Halcon外部函数回调对象
        /// </summary>
        internal HDevProcedureCall m_hProcedureCall;
        [NonSerialized]
        /// <summary>
        /// Halcon程序XML文档格式
        /// </summary>
        internal XmlDocument m_xmlDoc = new XmlDocument();
        /// <summary>
        /// 当前所选程序的输出项集合
        /// </summary>
        public List<ToolTerminal> m_listOutputs = new List<ToolTerminal>();
        /// <summary>
        /// 当前所选程序的输入项集合
        /// </summary>
        public List<ToolTerminal> m_listInputs = new List<ToolTerminal>();

        /// <summary>
        /// 主程序
        /// </summary>
        private string m_strProgramFile;
        /// <summary>
        /// 加载当前主程序
        /// </summary>
        public string ProgramFile
        {
            get { return m_strProgramFile; }
            set
            {
                if (m_strProgramFile != value)
                {
                    m_strProgramFile = value;


                    InitProgram();
                }
            }
        }

        public void InitProgram()
        {
            try
            {
                //根据当前所选的文件路径，初始化该路径的Halcon程序，以及将该程序以XML的格式加载进来
                m_hProgram.LoadProgram(m_strProgramFile);
                m_xmlDoc.Load(m_strProgramFile);
            }
            catch (Exception ex)
            {
                FuncLib.ShowExceptionBox("加载主程序出现异常:" + ex.Message, InfoType.Error);
            }
        }


        /// <summary>
        /// 选择要保存的程序
        /// </summary>
        private string m_strSelectSaveProcedure;
        /// <summary>
        /// 当前txt选择的程序名称
        /// </summary>
        public string SelectSaveProcedure
        {
            get { return m_strSelectSaveProcedure; }
            set
            {
                if (m_strSelectSaveProcedure != value)
                {
                    m_strSelectSaveProcedure = value;
                }
            }
        }

        /// <summary>
        /// 当前主程序下的所有子程序名称集合
        /// </summary>
        internal List<string> L_producedureNames = new List<string>();

        /// <summary>
        /// 主程序下的子程序名称集合【包含参数】
        /// </summary>
        internal List<string> L_produceNamesAndPar = new List<string>();

        /// <summary>
        /// 选择的运行子程序
        /// </summary>
        private string m_strSelectProcedure;

        /// <summary>
        /// 加载当前所选运行子程序
        /// </summary>
        public string SelectProcedure
        {
            get { return m_strSelectProcedure; }
            set
            {
                if (m_strSelectProcedure != value)
                {
                    m_strSelectProcedure = value;

                    InitProcedure();

                }
            }
        }

        /// <summary>
        /// 初始化所选子程序
        /// </summary>
        /// <param name="init">是否初始化加载，若是的话，则不删除输入输出</param>
        public void InitProcedure(bool init = false)
        {
            try
            {
                //重新添加输入输出
                //加载子程序
                m_hProcedure.LoadProcedure(m_hProgram, m_strSelectProcedure);
                m_hProcedureCall = m_hProcedure.CreateCall();
                if (!init)
                {
                    //删除输入
                    while (m_listInputs.Count > 0)
                    {
                        RemoveInput(m_listInputs[0].Name, true);
                    }

                    //删除输出
                    while (m_listOutputs.Count > 0)
                    {
                        RemoveOutput(m_listOutputs[0].Name, true);
                    }

                    //获取变量以及变量类型
                    int nInputCount = m_hProcedure.GetInputIconicParamCount();
                    for (int i = 1; i <= nInputCount; i++)
                    {
                        AddInput(m_hProcedure.GetInputIconicParamName(i), null, typeof(HObject), true);
                    }

                    nInputCount = m_hProcedure.GetInputCtrlParamCount();
                    for (int i = 1; i <= nInputCount; i++)
                    {
                        AddInput(m_hProcedure.GetInputCtrlParamName(i), null, typeof(HTuple), true);
                    }

                    int nOutputCount = m_hProcedure.GetOutputIconicParamCount();
                    for (int i = 1; i <= nOutputCount; i++)
                    {
                        AddOutput(m_hProcedure.GetOutputIconicParamName(i), null, typeof(HObject), true);
                    }

                    nOutputCount = m_hProcedure.GetOutputCtrlParamCount();
                    for (int i = 1; i <= nOutputCount; i++)
                    {
                        AddOutput(m_hProcedure.GetOutputCtrlParamName(i), null, typeof(HTuple), true);
                    }
                }

            }
            catch (Exception ex)
            {
                FuncLib.ShowExceptionBox("加载外部函数出现异常", InfoType.Error);
            }

        }


        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
        {
            toolRunStatu = "未知原因";
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            if (initRun)
            {
                参数 = new ToolPar();
                toolRunStatu = "运行成功";
                m_hProgram = new HDevProgram();
                m_hProcedure = new HDevProcedure();
                m_xmlDoc = new XmlDocument();

                //进行数据重新加载的操作
                InitProgram();  //加载主程序
                InitProcedure(initRun);    //加载当前所选子程序
                sw.Stop();
                return;
            }
            string RunResult = RunProcedure();
            if (RunResult != "Run Success")
            {
                toolRunStatu = "运行失败：" + RunResult;
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, RunResult), InfoType.Error);
                goto Exit;
            }
            toolRunStatu = "运行成功";

        Exit:
            sw.Stop();
            //若当前工具打开的话，得将相应的处理信息更新到窗体界面当中
            if (Frm_ImageEngineTool.hasShown && Frm_ImageEngineTool.taskName == taskName && Frm_ImageEngineTool.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_ImageEngineTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());
                Frm_ImageEngineTool.Instance.lbl_toolTip.Text = toolRunStatu;
                if (toolRunStatu.Contains("运行成功"))
                {
                    //显示dgv信息
                    Frm_ImageEngineTool.Instance.UpdataDgvOutData();
                }

            }

        }



        #region 操作输入输出项

        /// <summary>
        /// 更新输入项集合，便于Halcon子程序进一步使用
        /// </summary>
        public void UpdataInput()
        {
            for (int i = 0; i < m_listInputs.Count; i++)
            {
                //if (m_listInputs[i].ValueSource != "")
                {
                    if (m_listInputs[i].ValueSource == null && m_listInputs[i].ValueSource != "")
                    {
                        #region // 极片缺陷算法新增，注意去除

                        if (m_listInputs[i].Name == "DownMove")
                        {
                            m_listInputs[i].Value = Project.Instance.configuration.projectCfg.DownPianYi;
                            m_listInputs[i].ValueType = typeof(HTuple);
                            continue;
                        }
                        if (m_listInputs[i].Name == "RightMove")
                        {
                            m_listInputs[i].Value = Project.Instance.configuration.projectCfg.RightPianYi;
                            m_listInputs[i].ValueType = typeof(HTuple);
                            continue;
                        }
                        if (m_listInputs[i].Name == "LeftMove")
                        {
                            m_listInputs[i].Value = Project.Instance.configuration.projectCfg.LeftPianYi;
                            m_listInputs[i].ValueType = typeof(HTuple);
                            continue;
                        }
                        if (m_listInputs[i].Name == "Is_OnlyCheckHuangBiao")
                        {
                            m_listInputs[i].Value = true;
                            m_listInputs[i].ValueType = typeof(bool);
                            continue;
                        }

                        #endregion


                        m_listInputs[i].Value = null;
                        return;
                    }
                    string[] strs = m_listInputs[i].ValueSource.Split('.');
                    if (strs[1] == "图像")
                    {
                        m_listInputs[i].Value = ((ToolPar)参数).输入.图像;
                        m_listInputs[i].ValueType = typeof(HObject);
                    }
                    else if (strs[1] == "区域")
                    {
                        m_listInputs[i].Value = ((ToolPar)参数).输入.区域;
                        m_listInputs[i].ValueType = typeof(HObject);
                    }

                }
            }

        }


        /// <summary>
        /// 获取输入
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public ToolTerminal GetInput(string strName)
        {
            foreach (var item in m_listInputs)
            {
                if (item.Name == strName)
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// 移除输入
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public bool RemoveInput(string strName, bool bNotify = false)
        {
            ToolTerminal terminal = GetInput(strName);

            if (terminal != null)
            {
                m_listInputs.Remove(terminal);
            }

            return true;
        }

        /// <summary>
        /// 添加输入
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string AddInput(string Name, object value, Type type, bool bNotify = false)
        {
            ToolTerminal tm = new ToolTerminal();
            tm.Name = Name;
            tm.Value = value;
            tm.ValueType = type;
            tm.IOFlag = "InputPar";
            m_listInputs.Add(tm);

            return Name;
        }

        /// <summary>
        /// 获取输出
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public ToolTerminal GetOutput(string strName)
        {
            foreach (var item in m_listOutputs)
            {
                if (item.Name == strName)
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// 移除输出
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public bool RemoveOutput(string strName, bool bNotify = false)
        {
            ToolTerminal terminal = GetOutput(strName);

            if (terminal != null)
            {
                m_listOutputs.Remove(terminal);
            }

            return true;
        }

        /// <summary>
        /// 添加输出
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string AddOutput(string Name, object value, Type type, bool bNotify = false)
        {

            ToolTerminal tm = new ToolTerminal();
            tm.Name = Name;
            tm.Value = value;
            tm.ValueType = type;
            tm.IOFlag = "OutputPar";
            m_listOutputs.Add(tm);

            return Name;
        }
        #endregion

        #region 辅助方法

        /// <summary>
        /// 子程序代码SB格式
        /// </summary>
        private StringBuilder m_strBuilderProcedure = new StringBuilder();
        /// <summary>
        /// 子程序代码Str格式
        /// </summary>
        public string ProcedureCode
        {
            get
            {
                return m_strBuilderProcedure.ToString();
            }

            set
            {
                m_strBuilderProcedure = new StringBuilder(value);

                SaveProcedure();
            }
        }
        /// <summary>
        /// 读子程序代码
        /// </summary>
        internal void ReadProcedure(string _strSelectProcedure)
        {
            m_strBuilderProcedure.Clear();

            XmlNodeList xnl = m_xmlDoc.SelectNodes("/hdevelop/procedure");

            foreach (XmlNode xn in xnl)
            {
                XmlElement xe = (XmlElement)xn;

                if (xe.GetAttribute("name") == _strSelectProcedure)
                {
                    //获取body
                    XmlNode body = xe.SelectSingleNode("body");

                    if (body != null)
                    {
                        XmlNodeList codes = body.ChildNodes;

                        foreach (XmlNode code in codes)
                        {
                            m_strBuilderProcedure.AppendLine(code.InnerText);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 保存子程序
        /// </summary>
        /// <param name="SavePath"></param>
        private void SaveProcedure(string SavePath = null)
        {
            try
            {
                XmlNodeList xnl = m_xmlDoc.SelectNodes("/hdevelop/procedure");

                foreach (XmlNode xn in xnl)
                {
                    XmlElement xe = (XmlElement)xn;

                    //if (xe.GetAttribute("name") == m_strSelectProcedure) SelectSaveProcedure
                    if (xe.GetAttribute("name") == SelectSaveProcedure)
                    {
                        //获取body
                        XmlNode body = xe.SelectSingleNode("body");

                        if (body != null)
                        {
                            body.RemoveAll();

                            string[] codes = m_strBuilderProcedure.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (var code in codes)
                            {
                                XmlElement item = m_xmlDoc.CreateElement("l");
                                item.InnerText = code;
                                body.AppendChild(item);
                            }
                        }
                    }
                }
                //存储的思路，先将更新的内容存储为最新临时文件，若该临时文件可被加载的话，则将临时文件替换为最新文件，并删除临时文件，重新初始化子程序
                FileInfo fi = new FileInfo(m_strProgramFile);
                string strTempFile = m_strProgramFile + ".tmp" + fi.Extension;
                m_xmlDoc.Save(strTempFile);
                m_hProgram.LoadProgram(strTempFile);
                File.Copy(strTempFile, m_strProgramFile, true);
                FuncLib.ShowMessageBox("保存成功，正在重新初始化子程序");
            }
            catch (Exception ex)
            {
                //FuncLib.ShowExceptionBox("更新失败,正在为您切换为原文件\r\n" + ex.Message);
                if (FuncLib.ShowConfirmDialog("更新失败，正在为您切换回原文件\r\n" + ex.Message + "\r\n文本信息是否更新回原文件？") == System.Windows.Forms.DialogResult.OK)
                {
                    m_xmlDoc.Load(m_strProgramFile);
                    Frm_ImageEngineTool.Instance.cmb_CurrentTxtProduce_SelectedIndexChanged(null, null);  //让选择txt子程序重新刷新一下，去除编辑部分

                }

            }
            finally
            {
                FileInfo fi = new FileInfo(m_strProgramFile);

                string strTempFile = m_strProgramFile + ".tmp" + fi.Extension;

                if (File.Exists(strTempFile))
                {
                    File.Delete(strTempFile);
                }

                m_hProgram.LoadProgram(m_strProgramFile);

                //加载子程序
                m_hProcedure.LoadProcedure(m_hProgram, m_strSelectProcedure);

                m_hProcedureCall = m_hProcedure.CreateCall();
            }
        }

        /// <summary>
        /// 执行当前所选子程序
        /// </summary>
        /// <returns>返回当前运行结果</returns>
        public string RunProcedure()
        {
            try
            {
                UpdataInput();  //更新输入输出
                if (m_hProcedureCall != null && m_hProcedureCall.IsInitialized())
                {
                    //传递输入
                    foreach (var input in m_listInputs)
                    {
                        if (input.Value == null)
                        {
                            return "当前执行程序输入项为空，已中断运行";
                        }
                        if (input.ValueType == typeof(HObject))
                        {
                            m_hProcedureCall.SetInputIconicParamObject(input.Name, input.Value as HObject);
                        }
                        else if (input.ValueType == typeof(HTuple))
                        {
                            HTuple aa = new HTuple(input.Value);
                            m_hProcedureCall.SetInputCtrlParamTuple(input.Name, aa);
                        }
                        else if (input.ValueType == typeof(bool))
                        {
                            HTuple aa = new HTuple((bool)(input.Value)?true:false);
                            m_hProcedureCall.SetInputCtrlParamTuple(input.Name, aa);
                        }
                    }

                    //等待debug连接
                    m_hProcedureCall.SetWaitForDebugConnection(false);
                    m_hProcedureCall.Execute();

                    //获取输出
                    foreach (var output in m_listOutputs)
                    {
                        if (output.ValueType == typeof(HObject))
                        {
                            HObject a = m_hProcedureCall.GetOutputIconicParamObject(output.Name);
                            if (output.ValueSource != null && output.ValueSource.Contains("区域"))
                            {
                                HOperatorSet.AreaCenter(a, out HTuple area, out HTuple row, out HTuple col);//防止返回的是空区域   
                                if (area < 5)
                                {
                                    ((ToolPar)参数).输出.区域 = null;
                                }
                                else
                                {
                                    ((ToolPar)参数).输出.区域 = a;
                                }
                            }
                            else if (output.ValueSource != null && output.ValueSource.Contains("图像"))
                            {
                                ((ToolPar)参数).输出.图像 = a;
                            }
                            output.Value = a;
                        }
                        else if (output.ValueType == typeof(HTuple))
                        {
                            HTuple a = m_hProcedureCall.GetOutputCtrlParamTuple(output.Name);

                            HOperatorSet.TupleType(a, out HTuple type);
                            if (type.D == 8)    //说明是混合类型，需把它转化为Int类型，便于后续取值转化
                            {
                                HOperatorSet.TupleInt(a, out a);
                            }
                            output.Value = a;
                        }
                    }
                }
                return "Run Success";
            }
            catch (Exception Ex)
            {
                return "运行当前程序出现异常：" + Ex.Message;
            }
        }


        /// <summary>
        /// 获取外部方法名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetProcedureNames()
        {
            L_producedureNames = new List<string>();
            if (m_hProgram.IsInitialized() && m_hProgram.IsLoaded())
            {
                HTuple htProcedures = m_hProgram.GetLocalProcedureNames();
                L_producedureNames = new List<string>(htProcedures.ToSArr());
            }
            return L_producedureNames;
        }

        /// <summary>
        /// 获取外部方法及输入输出
        /// </summary>
        /// <returns></returns>
        public List<string> GetProcedureIO()
        {
            L_produceNamesAndPar = new List<string>();
            if (m_hProgram.IsInitialized() && m_hProgram.IsLoaded())
            {
                HTuple htProcedures = m_hProgram.GetLocalProcedureNames();
                List<string> listProcedures = new List<string>(htProcedures.ToSArr());

                foreach (string str in listProcedures)
                {
                    //加载子程序
                    HDevProcedure _Procedure = new HDevProcedure();
                    _Procedure.LoadProcedure(m_hProgram, str);
                    List<string> _listTemp = new List<string>();

                    //获取变量以及变量类型
                    int nInputCount = _Procedure.GetInputIconicParamCount();
                    for (int i = 1; i <= nInputCount; i++)
                    {
                        if (i == nInputCount)
                        {
                            _listTemp.Add(_Procedure.GetInputIconicParamName(i) + "：");
                        }
                        else
                        {
                            _listTemp.Add(_Procedure.GetInputIconicParamName(i) + ",");
                        }
                    }

                    int nOutputCount = _Procedure.GetOutputIconicParamCount();
                    for (int i = 1; i <= nOutputCount; i++)
                    {
                        if (i == nOutputCount)
                        {
                            _listTemp.Add(_Procedure.GetOutputIconicParamName(i) + "：");
                        }
                        else
                        {
                            _listTemp.Add(_Procedure.GetOutputIconicParamName(i) + ",");
                        }
                    }

                    nInputCount = _Procedure.GetInputCtrlParamCount();
                    for (int i = 1; i <= nInputCount; i++)
                    {
                        if (i == nInputCount)
                        {
                            _listTemp.Add(_Procedure.GetInputCtrlParamName(i) + "：");
                        }
                        else
                        {
                            _listTemp.Add(_Procedure.GetInputCtrlParamName(i) + ",");
                        }
                    }

                    nOutputCount = _Procedure.GetOutputCtrlParamCount();
                    for (int i = 1; i <= nOutputCount; i++)
                    {
                        if (i == nOutputCount)
                        {
                            _listTemp.Add(_Procedure.GetOutputCtrlParamName(i) + "：");
                        }
                        else
                        {
                            _listTemp.Add(_Procedure.GetOutputCtrlParamName(i) + ",");
                        }
                    }

                    string strtemp = "";
                    if (_listTemp.Count > 0)
                    {
                        foreach (string var in _listTemp)
                        {
                            strtemp = strtemp + var;
                        }
                        if (strtemp.EndsWith("："))
                        {
                            strtemp = strtemp.Substring(0, strtemp.Length - 1);
                        }
                        L_produceNamesAndPar.Add(str + "(" + strtemp + ")");
                    }
                    else
                    {
                        L_produceNamesAndPar.Add(str + "(：：：)");
                    }
                }
            }

            return L_produceNamesAndPar;
        }

        #endregion

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

            private HObject _区域;
            public HObject 区域
            {
                get { return _区域; }
                set { _区域 = value; }
            }
        }
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
                set
                {
                    _图像 = value;
                }
            }

            private HObject _区域;
            public HObject 区域
            {
                get { return _区域; }
                set { _区域 = value; }
            }

        }

        #endregion
    }

    [Serializable]
    public class ToolTerminal
    {
        public string IOFlag;
        public string Name;
        [NonSerialized]
        public object Value;
        public Type ValueType;
        public string ValueSource;
    }
}
