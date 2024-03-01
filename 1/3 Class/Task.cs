using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    [Serializable]
    internal class Task
    {
        internal Task(string taskName)
        {
            this.name = taskName;
        }

        /// <summary>
        /// 任务名
        /// </summary>
        internal string name = string.Empty;
        /// <summary>
        /// 工具集合
        /// </summary>
        internal List<ToolBase> L_toolList = new List<ToolBase>();
        /// <summary>
        /// 任务所绑定的图像窗口名称
        /// </summary>
        internal string windowName = "图像1";
        /// <summary>
        /// 任务是否正在运行
        /// </summary>
        internal bool isRunning = false;
        /// <summary>
        /// 是否正在循环执行
        /// </summary>
        internal bool isLoopRuning = false;
        /// <summary>
        /// 任务运行结果
        /// </summary>
        internal TaskRunStatu taskRunStatu = TaskRunStatu.Fail;
        /// <summary>
        /// 任务触发方式
        /// </summary>
        internal TaskTrigMode taskTrigMode = TaskTrigMode.BasedCall;
        /// <summary>
        /// 当前选中的任务
        /// </summary>
        internal static Task curTask = null;
        /// <summary>
        /// 已复制的任务
        /// </summary>
        internal static Task taskCopied;
        /// <summary>
        /// 以太网触发端口
        /// </summary>
        internal string EthernetTrigPort = string.Empty;
        /// <summary>
        /// 以太网触发指令
        /// </summary>
        internal string ethernetTrigCmd = "T";
        /// <summary>
        /// 显示运行状态【True：测试 False：实际运行】
        /// </summary>
        internal bool showRunStatu = true;


        internal List<object> L_result = new List<object>();
        /// <summary>
        /// 解析值
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static object GetValue(object obj, string name)
        {
            PropertyInfo[] dd = obj.GetType().GetProperties();
            foreach (PropertyInfo pi in obj.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                //节点上要显示参数名、参数类型和参数当前值
                string temp = Regex.Split(pi.ToString(), " ")[0];

                if (temp == "P输入" || temp == "P运行")
                    continue;

                if (pi.Name == name)
                {
                    object ddd = pi.GetValue(obj);
                    return ddd;
                }

                TreeNode node = new TreeNode();
                if (temp == "VMPro.XYU")
                {
                    //////node = nodes.Add("", "<集合<XYU>>  " + pi.Name);
                    //////node.Tag = DataType.XYU;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "HalconDotNet.HObject")
                {
                    //////node = nodes.Add("", "<图像>  " + pi.Name);
                    //////node.Tag = DataType.Image;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "VMPro.XY")
                {
                    //////node = nodes.Add("", "<XY>  " + pi.Name);
                    //////node.Tag = DataType.XY;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "System.Object")
                {
                    //////node = nodes.Add("", "<XY>  " + pi.Name);
                    //////node.Tag = DataType.Image;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "VMPro.Line")
                {
                    //////node = nodes.Add("", "<线>  " + pi.Name);
                    //////node.Tag = DataType.Line;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "Double")
                {
                    //////node = nodes.Add("", "<小数>  " + pi.Name + "=" + pi.GetValue(obj, null));
                    //////node.Tag = DataType.String;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "System.String")
                {
                    //////node = nodes.Add("", "<文本>  " + pi.Name + "=" + pi.GetValue(obj, null));
                    //////node.Tag = DataType.String;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "HalconDotNet.HRegion")
                {
                    //////node = nodes.Add("", "<区域>  " + pi.Name);
                    //////node.Tag = DataType.Region;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "Int32")
                {
                    //////node = nodes.Add("", "<整数>  " + pi.Name + "=" + pi.GetValue(obj, null));
                    //////node.Tag = DataType.String;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "System.Collections.Generic.List`1[VM_Pro.XY]")
                {
                    //////node = nodes.Add("", "<集合<XY>>  " + pi.Name);
                    //////node.Tag = DataType.XY;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "System.Collections.Generic.List`1[System.Double]")
                {
                    //////node = nodes.Add("", "<集合<小数>>  " + pi.Name);
                    //////node.Tag = DataType.String;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "System.Collections.Generic.List`1[System.String]")
                {
                    //////node = nodes.Add("", "<集合<文本>>  " + pi.Name);
                    //////node.Tag = DataType.String;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "System.Collections.Generic.List`1[VM_Pro.XYU]")
                {
                    //////node = nodes.Add("", "<集合<XYU>>  " + pi.Name);
                    //////node.Tag = DataType.XYU;
                    //////node.ForeColor = Color.Black;
                }
                else
                {
                    //////node = nodes.Add("", pi.Name);
                    //////node.ForeColor = Color.DarkGray;
                }


                object value = pi.GetValue(obj, null);
                if (value == null || value.ToString() == "HalconDotNet.HObject" || value.ToString() == "HalconDotNet.HRegion")
                    continue;

                if (pi.PropertyType.IsValueType || pi.PropertyType.Name.StartsWith("String"))
                {
                }
                else if (pi.ToString().Contains("System.Collections.Generic.List`1[VM_Pro.XYU]"))
                {
                    for (int i = 0; i < ((List<XYU>)value).Count; i++)
                    {
                        TreeNode treeNode = new TreeNode();
                        treeNode = node.Nodes.Add("", "<XYU>  " + "成员" + (i + 1));
                        treeNode.Tag = DataType.String;
                        treeNode.ForeColor = Color.Black;

                        //////GetValue(treeNode.Nodes, ((List<XYU>)value)[i]);
                    }
                }
                else if (pi.ToString().Contains("System.Collections.Generic.List`1[VM_Pro.XY]"))
                {
                    for (int i = 0; i < ((List<XY>)value).Count; i++)
                    {
                        TreeNode treeNode = new TreeNode();
                        treeNode = node.Nodes.Add("", "<XY>  " + "成员" + (i + 1));
                        treeNode.Tag = DataType.XY;
                        treeNode.ForeColor = Color.Black;

                        //////GetValue(treeNode.Nodes, ((List<XY>)value)[i]);
                    }
                }
                else if (pi.ToString().Contains("System.Collections.Generic.List`1[System.Double]"))
                {
                    for (int j = 0; j < ((List<double>)value).Count; j++)
                    {

                        double str = ((List<double>)value)[j];
                        str = Math.Round(str, 3);

                        TreeNode treeNode = new TreeNode();
                        treeNode = node.Nodes.Add("", "<小数>  " + "成员" + (j + 1) + "=" + str);
                        treeNode.Tag = DataType.String;
                        treeNode.ForeColor = Color.Black;
                    }
                }
                else if (pi.ToString().Contains("System.Collections.Generic.List`1[System.String]"))
                {
                    for (int j = 0; j < ((List<string>)value).Count; j++)
                    {
                        string str = ((List<string>)value)[j];

                        TreeNode treeNode = new TreeNode();
                        treeNode = node.Nodes.Add("", "<文本>  " + "成员" + (j + 1) + "=" + str);
                        treeNode.Tag = DataType.String;
                        treeNode.ForeColor = Color.Black;
                    }
                }
                else if (pi.ToString().Contains("System.Collections.Generic.List`1[System.String]"))
                {
                    for (int j = 0; j < ((List<string>)value).Count; j++)
                    {
                        string str = ((List<string>)value)[j];

                        TreeNode treeNode = new TreeNode();
                        treeNode = node.Nodes.Add("", "<文本>  " + "成员" + (j + 1) + "=" + str);
                        treeNode.Tag = DataType.String;
                        treeNode.ForeColor = Color.Black;
                    }
                }
                else
                {
                    object objdd = GetValue(value, name);
                    if (objdd != null)
                        return objdd;
                }
            }
            return null;
        }
        /// <summary>
        /// 解析值
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static void sssetValue(object obj, string name, object value22)
        {
            PropertyInfo[] dd = obj.GetType().GetProperties();  //此处出空对象可能是工具时间加载太长，还未初始化完成进而去点击执行引发的，启动后稍微等一下即可
            foreach (PropertyInfo pi in obj.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                //节点上要显示参数名、参数类型和参数当前值
                string temp = Regex.Split(pi.ToString(), " ")[0];

                if (temp != "P运行" && temp != "P输出")
                {
                    if (pi.Name == name)
                    {
                        pi.SetValue(obj, value22);
                        return;
                    }

                    TreeNode node = new TreeNode();
                    if (temp == "VMPro.XYU")
                    {
                        //////node = nodes.Add("", "<集合<XYU>>  " + pi.Name);
                        //////node.Tag = DataType.XYU;
                        //////node.ForeColor = Color.Black;
                    }
                    else if (temp == "HalconDotNet.HObject")
                    {
                        //////node = nodes.Add("", "<图像>  " + pi.Name);
                        //////node.Tag = DataType.Image;
                        //////node.ForeColor = Color.Black;
                    }
                    else if (temp == "VMPro.XY")
                    {
                        //////node = nodes.Add("", "<XY>  " + pi.Name);
                        //////node.Tag = DataType.XY;
                        //////node.ForeColor = Color.Black;
                    }
                    else if (temp == "System.Object")
                    {
                        //////node = nodes.Add("", "<XY>  " + pi.Name);
                        //////node.Tag = DataType.Image;
                        //////node.ForeColor = Color.Black;
                    }
                    else if (temp == "VMPro.Line")
                    {
                        //////node = nodes.Add("", "<线>  " + pi.Name);
                        //////node.Tag = DataType.Line;
                        //////node.ForeColor = Color.Black;
                    }
                    else if (temp == "Double")
                    {
                        //////node = nodes.Add("", "<小数>  " + pi.Name + "=" + pi.GetValue(obj, null));
                        //////node.Tag = DataType.String;
                        //////node.ForeColor = Color.Black;
                    }
                    else if (temp == "System.String")
                    {
                        //////node = nodes.Add("", "<文本>  " + pi.Name + "=" + pi.GetValue(obj, null));
                        //////node.Tag = DataType.String;
                        //////node.ForeColor = Color.Black;
                    }
                    else if (temp == "HalconDotNet.HRegion")
                    {
                        //////node = nodes.Add("", "<区域>  " + pi.Name);
                        //////node.Tag = DataType.Region;
                        //////node.ForeColor = Color.Black;
                    }
                    else if (temp == "Int32")
                    {
                        //////node = nodes.Add("", "<整数>  " + pi.Name + "=" + pi.GetValue(obj, null));
                        //////node.Tag = DataType.String;
                        //////node.ForeColor = Color.Black;
                    }
                    else if (temp == "System.Collections.Generic.List`1[VM_Pro.XY]")
                    {
                        //////node = nodes.Add("", "<集合<XY>>  " + pi.Name);
                        //////node.Tag = DataType.XY;
                        //////node.ForeColor = Color.Black;
                    }
                    else if (temp == "System.Collections.Generic.List`1[System.Double]")
                    {
                        //////node = nodes.Add("", "<集合<小数>>  " + pi.Name);
                        //////node.Tag = DataType.String;
                        //////node.ForeColor = Color.Black;
                    }
                    else if (temp == "System.Collections.Generic.List`1[System.String]")
                    {
                        //////node = nodes.Add("", "<集合<文本>>  " + pi.Name);
                        //////node.Tag = DataType.String;
                        //////node.ForeColor = Color.Black;
                    }
                    else if (temp == "System.Collections.Generic.List`1[VM_Pro.XYU]")
                    {
                        //////node = nodes.Add("", "<集合<XYU>>  " + pi.Name);
                        //////node.Tag = DataType.XYU;
                        //////node.ForeColor = Color.Black;
                    }
                    else
                    {
                        //////node = nodes.Add("", pi.Name);
                        //////node.ForeColor = Color.DarkGray;
                    }


                    object value = pi.GetValue(obj, null);
                    if (value == null || value.ToString() == "HalconDotNet.HObject" || value.ToString() == "HalconDotNet.HRegion")
                        continue;

                    if (pi.PropertyType.IsValueType || pi.PropertyType.Name.StartsWith("String"))
                    {
                        for (int j = 0; j < ((List<double>)value).Count; j++)
                        {

                            double str = ((List<double>)value)[j];
                            str = Math.Round(str, 3);

                            TreeNode treeNode = new TreeNode();
                            treeNode = node.Nodes.Add("", "<小数>  " + "成员" + (j + 1) + "=" + str);
                            treeNode.Tag = DataType.String;
                            treeNode.ForeColor = Color.Black;
                        }

                    }
                    else if (pi.ToString().Contains("System.Collections.Generic.List`1[VM_Pro.XYU]"))
                    {
                        for (int i = 0; i < ((List<XYU>)value).Count; i++)
                        {
                            TreeNode treeNode = new TreeNode();
                            treeNode = node.Nodes.Add("", "<XYU>  " + "成员" + (i + 1));
                            treeNode.Tag = DataType.String;
                            treeNode.ForeColor = Color.Black;

                            //////GetValue(treeNode.Nodes, ((List<XYU>)value)[i]);
                        }
                    }
                    else if (pi.ToString().Contains("System.Collections.Generic.List`1[VM_Pro.XY]"))
                    {
                        for (int i = 0; i < ((List<XY>)value).Count; i++)
                        {
                            TreeNode treeNode = new TreeNode();
                            treeNode = node.Nodes.Add("", "<XY>  " + "成员" + (i + 1));
                            treeNode.Tag = DataType.XY;
                            treeNode.ForeColor = Color.Black;

                            //////GetValue(treeNode.Nodes, ((List<XY>)value)[i]);
                        }
                    }
                    else if (pi.ToString().Contains("System.Collections.Generic.List`1[System.Double]"))
                    {
                        for (int j = 0; j < ((List<double>)value).Count; j++)
                        {

                            double str = ((List<double>)value)[j];
                            str = Math.Round(str, 3);

                            TreeNode treeNode = new TreeNode();
                            treeNode = node.Nodes.Add("", "<小数>  " + "成员" + (j + 1) + "=" + str);
                            treeNode.Tag = DataType.String;
                            treeNode.ForeColor = Color.Black;
                        }
                    }
                    else if (pi.ToString().Contains("System.Collections.Generic.List`1[System.String]"))
                    {
                        for (int j = 0; j < ((List<string>)value).Count; j++)
                        {
                            string str = ((List<string>)value)[j];

                            TreeNode treeNode = new TreeNode();
                            treeNode = node.Nodes.Add("", "<文本>  " + "成员" + (j + 1) + "=" + str);
                            treeNode.Tag = DataType.String;
                            treeNode.ForeColor = Color.Black;
                        }
                    }
                    else if (pi.ToString().Contains("System.Collections.Generic.List`1[VM_Pro.Line]"))
                    {
                        for (int j = 0; j < ((List<Line>)value).Count; j++)
                        {
                            Line line = ((List<Line>)value)[j];

                            TreeNode treeNode = new TreeNode();
                            treeNode = node.Nodes.Add("", "<线>  " + "成员" + (j + 1) + "=" + line.ToString());
                            treeNode.Tag = DataType.Line;
                            treeNode.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        sssetValue(value, name, value22);
                    }
                }
            }
        }

        private void SetValue(string tool, string tooled, string name, string nameed)
        {
            object valule = null;
            for (int i = 0; i < L_toolList.Count; i++)
            {
                if (L_toolList[i].toolName == tool)
                {
                    valule = GetValue(L_toolList[i].参数, name);

                    for (int j = 0; j < L_toolList.Count; j++)
                    {
                        if (L_toolList[j].toolName == tooled)
                        {
                            sssetValue(L_toolList[j].参数, nameed, valule);
                            break;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 获取图像窗体句柄
        /// </summary>
        /// <returns></returns>
        internal HWindow_Final GetImageWindow()
        {
            string totalWindowName = windowName;
            if (totalWindowName == "无")
                totalWindowName = Task.FindTaskByName(name).windowName;

            if (totalWindowName == Project.Instance.configuration.windowName[0])
                return Frm_Vision.Instance.hWindow_Final1;
            else if (totalWindowName == Project.Instance.configuration.windowName[1])
                return Frm_Vision.Instance.hWindow_Final2;
            else if (totalWindowName == Project.Instance.configuration.windowName[2])
                return Frm_Vision.Instance.hWindow_Final3;
            else if (totalWindowName == Project.Instance.configuration.windowName[3])
                return Frm_Vision.Instance.hWindow_Final4;
            else if (totalWindowName == Project.Instance.configuration.windowName[4])
                return Frm_Vision.Instance.hWindow_Final5;
            else if (totalWindowName == Project.Instance.configuration.windowName[5])
                return Frm_Vision.Instance.hWindow_Final6;
            else if (totalWindowName == Project.Instance.configuration.windowName[6])
                return Frm_Vision.Instance.hWindow_Final7;
            else if (totalWindowName == Project.Instance.configuration.windowName[7])
                return Frm_Vision.Instance.hWindow_Final8;
            else if (totalWindowName == Project.Instance.configuration.windowName[8])
                return Frm_Vision.Instance.hWindow_Final9;
            else if (totalWindowName == Project.Instance.configuration.windowName[9])
                return Frm_Vision.Instance.hWindow_Final10;
            else if (totalWindowName == Project.Instance.configuration.windowName[10])
                return Frm_Vision.Instance.hWindow_Final11;
            else if (totalWindowName == Project.Instance.configuration.windowName[11])
                return Frm_Vision.Instance.hWindow_Final12;
            else if (totalWindowName == Project.Instance.configuration.windowName[12])
                return Frm_Vision.Instance.hWindow_Final13;
            else if (totalWindowName == Project.Instance.configuration.windowName[13])
                return Frm_Vision.Instance.hWindow_Final14;
            else if (totalWindowName == Project.Instance.configuration.windowName[14])
                return Frm_Vision.Instance.hWindow_Final15;
            else if (totalWindowName == Project.Instance.configuration.windowName[15])
                return Frm_Vision.Instance.hWindow_Final16;
            else
                return new HWindow_Final();
        }
        /// <summary>
        /// 时间显示格式化
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        internal static string FormatTime(long time)
        {
            if (time == 0)
                time = 1;

            if (time < 10)
                return "      " + time;
            else if (time < 100)
                return "    " + time;
            else
                return time.ToString();
        }
        /// <summary>
        /// 任务命名查重
        /// </summary>
        /// <param name="jobName">任务名</param>
        /// <returns>是否已存在</returns>
        internal static bool CheckTaskExist(string taskName)
        {
            for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
            {
                if (Scheme.curScheme.L_taskList[i].name == taskName)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 工具命名查重
        /// </summary>
        /// <param name="jobName">工具名</param>
        /// <returns>是否已存在</returns>
        internal static bool CheckToolExist(string toolName)
        {
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolName == toolName)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 生成新工具的名称
        /// </summary>
        /// <param name="toolName">工具类型</param>
        /// <returns>工具名称</returns>
        internal string CreateNewToolName(ToolType toolType)
        {
            bool existFirst = false;
            for (int i = 0; i < L_toolList.Count; i++)
            {
                if (L_toolList[i].toolName == toolType.ToString().Replace("_", " "))
                {
                    existFirst = true;
                    break;
                }
            }

            if (!existFirst)
            {
                return toolType.ToString().Replace("_", " ");
            }
            else
            {
                for (int i = 1; i < 10000; i++)
                {
                    bool exist = false;
                    for (int j = 0; j < L_toolList.Count; j++)
                    {
                        if (L_toolList[j].toolName == string.Format("{0}_{1}", toolType.ToString().Replace("_", " "), i))
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                        return string.Format("{0}_{1}", toolType.ToString().Replace("_", " "), i);
                }
            }
            return "Error";
        }
        /// <summary>
        /// 通过任务名查找对应任务
        /// </summary>
        /// <param name="jobName">任务名</param>
        /// <returns>任务</returns>
        internal static Task FindTaskByName(string taskName)
        {
            for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
            {
                if ((Scheme.curScheme.L_taskList[i]).name == taskName)
                    return Scheme.curScheme.L_taskList[i];
            }
            FuncLib.ShowMsg(string.Format("未找到名为 {0} 的任务", taskName), InfoType.Error);
            return null;
        }
        /// <summary>
        /// 通过工具名查找对应工具
        /// </summary>
        /// <param name="jobName">工具名</param>
        /// <returns>工具</returns>
        internal ToolBase FindToolByName(string toolName)
        {
            for (int i = 0; i < L_toolList.Count; i++)
            {
                if ((L_toolList[i]).toolName == toolName)
                    return L_toolList[i];
            }
            FuncLib.ShowMsg(string.Format("未找到名为{0}的工具", toolName), InfoType.Error);
            return null;
        }
        /// <summary>
        /// 切换任务
        /// </summary>
        internal static void Switch(string taskName)
        {
            //切换任务
            bool exist = false;
            for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
            {
                if (Scheme.curScheme.L_taskList[i].name == taskName)
                {
                    curTask = Scheme.curScheme.L_taskList[i];
                    exist = true;
                    break;
                }
            }

            if (!exist)
            {
                FuncLib.ShowMessageBox(string.Format("切换失败，未查询到名为 {0} 的任务", taskName), InfoType.Error);
                return;
            }

            //刷新界面
            Frm_Task.Instance.C_toolList.Nodes.Clear();
            for (int i = 0; i < curTask.L_toolList.Count; i++)
            {
                //添加工具节点
                TreeNode treeNode = Frm_Task.Instance.C_toolList.Nodes.Add(curTask.L_toolList[i].toolName);

                //更新工具运行状态
                for (int j = 0; j < curTask.L_toolList.Count; j++)
                {
                    if (curTask.L_toolList[j].enable)
                    {
                        if (curTask.L_toolList[j].toolRunStatu == "运行成功")
                            Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.FindTreeNodeByToolName(curTask.L_toolList[j].toolName), FormatTime(curTask.L_toolList[j].elapsedTime), Color.FromArgb(240, 240, 240), Color.Green);
                        else
                            Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.FindTreeNodeByToolName(Task.curTask.L_toolList[j].toolName), "    ×", Color.FromArgb(240, 240, 240), Color.Red);
                    }
                    else
                    {
                        Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.FindTreeNodeByToolName(curTask.L_toolList[j].toolName), "    ×", Color.FromArgb(240, 240, 240), Color.DarkGray);
                    }
                }
            }
        }
        /// <summary>
        /// 复制任务对象
        /// </summary>
        /// <typeparam name="Task"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        internal static Task Clone<Task>(Task source)
        {
            if (!typeof(Task).IsSerializable)
            {
                throw new ArgumentException("深拷贝失败", "source");
            }

            if (Object.ReferenceEquals(source, null))
            {
                return default(Task);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (Task)formatter.Deserialize(stream);
            }
        }
        /// <summary>
        /// 新建任务
        /// </summary>
        internal static bool Create()
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return false;

            Again:
            string taskName = FuncLib.ShowInput("请输入新任务名");
            if (taskName == string.Empty)
                return false;

            //命名查重
            if (CheckTaskExist(taskName))
            {
                FuncLib.ShowMessageBox("已存在此名称的任务，任务名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            // 特殊字符检查
            if (taskName.Contains(@"\"))
            {
                FuncLib.ShowMessageBox("任务名中不能含有 \\ 特殊字符 ，请重新输入", InfoType.Error);
                goto Again;
            }

            Task task = new Task(taskName);
            //需将新建的任务默认为是当前任务，在给当前任务默认添加一个采集图像的工具，不然的话，在后面默认添加采集图像工具的时候，会出现当前任务为空的异常
            if (Task.curTask == null)
            {
                Task.curTask = task;
            }
            task.windowName = Project.Instance.configuration.windowName[0];
            Scheme.curScheme.L_taskList.Add(task);
            TreeNode treeNode = Frm_Task.Instance.C_taskList.Nodes.Add(taskName);
            treeNode.Tag = "";
            Frm_Task.Instance.C_taskList.SelectedNode = treeNode;

            //默认添加采集图像工具
            ToolType toolType = (ToolType)Enum.Parse(typeof(ToolType), "采集图像");
            string toolName = task.CreateNewToolName(toolType);
            task.L_toolList.Add(new ImageTool(toolName, task.name, toolType));
            Frm_Task.Instance.C_toolList.Nodes.Add(toolName);

            Switch(taskName);
            curTask = task;
            FuncLib.ShowMsg(string.Format("创建了新任务，任务名为：{0}", taskName), InfoType.Tip);
            return true;
        }
        /// <summary>
        /// 复制任务
        /// </summary>
        internal static void Copy(string nameCopied)
        {

            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (Task.curTask == null)
                return;

            for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
            {
                if (Scheme.curScheme.L_taskList[i].name == nameCopied)
                {
                    taskCopied = Task.Clone(Scheme.curScheme.L_taskList[i]);
                    break;
                }
            }
            FuncLib.ShowMsg(string.Format("任务 {0} 已复制，等待粘贴插入", taskCopied.name), InfoType.Tip);
        }
        /// <summary>
        /// 粘贴
        /// </summary>
        /// <param name="treeView"></param>
        internal static void Paste(TreeView treeView)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (taskCopied == null)
            {
                FuncLib.ShowMsg("尚未复制，请复制后粘贴", InfoType.Error);
                return;
            }

        //输入新的任务名称
        Again:
            string newTaskName = FuncLib.ShowInput("请输入新任务名");
            if (newTaskName == string.Empty)
                return;

            //命名查重
            if (CheckTaskExist(newTaskName))
            {
                FuncLib.ShowMessageBox("已存在此名称的任务，任务名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            // 特殊字符检查
            if (newTaskName.Contains(@"\"))
            {
                FuncLib.ShowMessageBox("任务名中不能含有 \\ 特殊字符 ，请重新输入", InfoType.Error);
                goto Again;
            }

            MoveTreeView move = (MoveTreeView)Convert.ToInt32(treeView.Tag);
            System.Drawing.Point p = treeView.PointToClient(new System.Drawing.Point(Frm_Task.clickTaskPos.X, Frm_Task.clickTaskPos.Y));
            TreeNode node = treeView.GetNodeAt(Frm_Task.clickTaskPos);

            //修改流程名以及流程中所有工具的名称
            Task task;
            task = ToolBase.Clone(taskCopied);
            task.name = newTaskName;
            for (int i = 0; i < task.L_toolList.Count; i++)
            {
                task.L_toolList[i].taskName = newTaskName;
                //修改输入项的源流程
                for (int j = 0; j < task.L_toolList[i].L_inputItem.Count; j++)
                {
                    InputItem inputItem = task.L_toolList[i].L_inputItem[j];
                    inputItem.sourceTask = newTaskName;
                    task.L_toolList[i].L_inputItem.RemoveAt(j);
                    task.L_toolList[i].L_inputItem.Insert(j, inputItem);
                }
            }

            if (node == null)        //在尾部追加
            {
                Scheme.curScheme.L_taskList.Insert(Scheme.curScheme.L_taskList.Count, task);
                treeView.Nodes.Insert(Scheme.curScheme.L_taskList.Count, new TreeNode(newTaskName));
            }
            else        //在中间插入
            {
                Scheme.curScheme.L_taskList.Insert(treeView.SelectedNode.Index, task);
                treeView.Nodes.Insert(treeView.SelectedNode.Index, new TreeNode(newTaskName));
            }
            FuncLib.ShowMsg(string.Format("任务已粘贴插入，新任务名：{0}", taskCopied.name), InfoType.Tip);
        }
        /// <summary>
        /// 导入
        /// </summary>
        internal static void Inport()
        {
            if (Scheme.curScheme == null)
                return;

            System.Windows.Forms.OpenFileDialog dig_openImage = new System.Windows.Forms.OpenFileDialog();
            dig_openImage.FileName = "";
            dig_openImage.Title = "请选择任务文件";
            dig_openImage.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            dig_openImage.Filter = "任务文件(*.tsk)|*.tsk";
            if (dig_openImage.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(string.Format(dig_openImage.FileName), FileMode.Open, FileAccess.Read, FileShare.None);
                try
                {
                    curTask = (Task)formatter.Deserialize(stream);
                    stream.Close();
                }
                catch      //如果反序列化失败，要释放流，否则文件会被占用
                {
                    stream.Close();
                    FuncLib.ShowMessageBox("导入任务失败", InfoType.Error);
                }

                MoveTreeView move = (MoveTreeView)Convert.ToInt32(Frm_Task.Instance.C_taskList.Tag);
                System.Drawing.Point p = Frm_Task.Instance.C_taskList.PointToClient(new System.Drawing.Point(Frm_Task.clickTaskPos.X, Frm_Task.clickTaskPos.Y));
                TreeNode node = Frm_Task.Instance.C_taskList.GetNodeAt(Frm_Task.clickTaskPos);

                //名称查重
                if (CheckTaskExist(curTask.name))
                {
                    DialogResult result = FuncLib.ShowConfirmDialog(string.Format("已经存在名为 {0} 的任务，任务名不可重复，点击 是 覆盖同名任务，点击 否 重新命名导入的任务", curTask.name), InfoType.Error);
                    switch (result)
                    {
                        case DialogResult.OK:
                            for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
                            {
                                if (Scheme.curScheme.L_taskList[i].name == curTask.name)
                                {
                                    Scheme.curScheme.L_taskList.RemoveAt(i);
                                    Scheme.curScheme.L_taskList.Insert(i, curTask);
                                    Frm_Task.Instance.C_taskList.SelectedNode = Frm_Task.Instance.C_taskList.Nodes[i];

                                    FuncLib.ShowMsg(string.Format("任务导入成功，原同名任务已被覆盖，任务名为：{0}", curTask.name), InfoType.Tip);
                                    return;
                                }
                            }
                            break;
                        case DialogResult.No:
                        Again:
                            string newTaskName = FuncLib.ShowInput("请输入新任务名");
                            if (newTaskName == string.Empty)
                                return;

                            //命名查重
                            if (CheckTaskExist(newTaskName))
                            {
                                FuncLib.ShowMessageBox("已存在此名称的任务，任务名不可重复，请重新输入", InfoType.Error);
                                goto Again;
                            }

                            // 特殊字符检查
                            if (newTaskName.Contains(@"\"))
                            {
                                FuncLib.ShowMessageBox("任务名中不能含有 \\ 特殊字符 ，请重新输入", InfoType.Error);
                                goto Again;
                            }

                            curTask.name = newTaskName;
                            for (int i = 0; i < curTask.L_toolList.Count; i++)
                            {
                                curTask.L_toolList[i].taskName = newTaskName;
                            }

                            if (node == null)        //在尾部追加
                            {
                                Scheme.curScheme.L_taskList.Insert(Frm_Task.Instance.C_taskList.Nodes.Count, curTask);
                                TreeNode treeNode1 = Frm_Task.Instance.C_taskList.Nodes.Insert(Frm_Task.Instance.C_taskList.Nodes.Count, curTask.name);
                                Frm_Task.Instance.C_taskList.SelectedNode = treeNode1;
                            }
                            else        //在中间插入
                            {
                                Scheme.curScheme.L_taskList.Insert(Frm_Task.Instance.C_taskList.SelectedNode.Index, curTask);
                                TreeNode treeNode1 = Frm_Task.Instance.C_taskList.Nodes.Insert(Frm_Task.Instance.C_taskList.SelectedNode.Index, curTask.name);
                                Frm_Task.Instance.C_taskList.SelectedNode = treeNode1;
                            }

                            FuncLib.ShowMsg(string.Format("任务导入成功，任务名为：{0}", curTask.name), InfoType.Tip);
                            return;
                        case DialogResult.Cancel:

                            FuncLib.ShowMsg(string.Format("任务 {0} 已放弃导入", curTask.name), InfoType.Tip);
                            return;
                    }
                }

                if (node == null)        //在尾部追加
                {
                    Scheme.curScheme.L_taskList.Insert(Frm_Task.Instance.C_taskList.Nodes.Count, curTask);
                    TreeNode treeNode1 = Frm_Task.Instance.C_taskList.Nodes.Insert(Frm_Task.Instance.C_taskList.Nodes.Count, curTask.name);
                    Frm_Task.Instance.C_taskList.SelectedNode = treeNode1;
                }
                else        //在中间插入
                {
                    Scheme.curScheme.L_taskList.Insert(Frm_Task.Instance.C_taskList.SelectedNode.Index, curTask);
                    TreeNode treeNode1 = Frm_Task.Instance.C_taskList.Nodes.Insert(Frm_Task.Instance.C_taskList.SelectedNode.Index, curTask.name);
                    Frm_Task.Instance.C_taskList.SelectedNode = treeNode1;
                }

                FuncLib.ShowMsg(string.Format("任务导入成功，任务名为：{0}", curTask.name), InfoType.Tip);
            }
        }
        /// <summary>
        /// 导出
        /// </summary>
        internal static void Export()
        {
            if (curTask == null)
                return;

            System.Windows.Forms.SaveFileDialog dig_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            dig_saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            dig_saveFileDialog.FileName = Frm_Task.Instance.C_taskList.SelectedNode.Text;
            dig_saveFileDialog.Title = "请选择任务保存路径";
            dig_saveFileDialog.Filter = "任务文件(*.tsk)|*.tsk";
            if (dig_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(dig_saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, Task.curTask);
                stream.Close();

                FuncLib.ShowMsg(string.Format("任务导出成功，任务名为：{0}", curTask.name), InfoType.Tip);
            }
        }
        /// <summary>
        /// 重命名任务
        /// </summary>
        internal static void Rename()
        {
            if (curTask == null)
                return;

            Again:
            string newTaskName = FuncLib.ShowInput("请输入新任务名");
            if (newTaskName == string.Empty)
                return;

            //命名查重
            if (CheckTaskExist(newTaskName))
            {
                FuncLib.ShowMessageBox("已存在此名称的任务，任务名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            // 特殊字符检查
            if (newTaskName.Contains(@"\"))
            {
                FuncLib.ShowMessageBox("任务名中不能含有 \\ 特殊字符 ，请重新输入", InfoType.Error);
                goto Again;
            }

            string oldTaskName = Frm_Task.Instance.C_taskList.SelectedNode.Text;
            for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
            {
                if (Scheme.curScheme.L_taskList[i].name == oldTaskName)
                {
                    Frm_Task.Instance.C_taskList.SelectedNode.Text = newTaskName;
                    Scheme.curScheme.L_taskList[i].name = newTaskName;
                    //1.需要将当前任务下的所有工具对应的任务名称也改掉，不然后续操作工具会找不到相应的任务
                    for (int j = 0; j < Scheme.curScheme.L_taskList[i].L_toolList.Count; j++)
                    {
                        Scheme.curScheme.L_taskList[i].L_toolList[j].taskName = newTaskName;
                        //2.需要将工具的输入输出项来源工具名称也改掉，不然会出现链入输入数据的时候，出现找不到对应任务的异常
                        for (int k = 0; k < Scheme.curScheme.L_taskList[i].L_toolList[j].L_inputItem.Count; k++)
                        {
                            if (Scheme.curScheme.L_taskList[i].L_toolList[j].L_inputItem[k].sourceTask == oldTaskName)
                            {
                                //此行会报错，结构体在list当中不能单独改变某个item的成员变量，必须以item来改动，故由以下方式来实现
                                //Scheme.curScheme.L_taskList[i].L_toolList[j].L_inputItem[k].sourceTask = newTaskName; 
                                InputItem item = Scheme.curScheme.L_taskList[i].L_toolList[j].L_inputItem[k];
                                item.sourceTask = newTaskName;
                                Scheme.curScheme.L_taskList[i].L_toolList[j].L_inputItem[k] = item;
                            }
                        }
                    }


                    break;
                }
            }
            //特殊部分，模板匹配句柄是静态的，可整个程序使用,又因为其句柄与任务名称有绑定关系，故更改时，也应该一块更新
            if (MatchTool.D_nccModel != null && MatchTool.D_nccModel.Count > 0)
            {
                MatchTool.D_nccModel = MatchTool.D_nccModel.ToDictionary(item1 => item1.Key.Contains(oldTaskName) ? item1.Key.Replace(oldTaskName, newTaskName) : item1.Key, item1 => item1.Value);
            }
            if (MatchTool.D_shapeModel != null && MatchTool.D_shapeModel.Count > 0)
            {
                MatchTool.D_shapeModel = MatchTool.D_shapeModel.ToDictionary(item2 => item2.Key.Contains(oldTaskName) ? item2.Key.Replace(oldTaskName, newTaskName) : item2.Key, item2 => item2.Value);

            }
            FuncLib.ShowMsg(string.Format("任务 {0} 已成功更名为：{1}", oldTaskName, newTaskName), InfoType.Tip);
        }
        /// <summary>
        /// 删除任务
        /// </summary>
        internal static void Delete()
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (Task.curTask == null)
                return;

            string taskName = Frm_Task.Instance.C_taskList.SelectedNode.Text;
            if (FuncLib.ShowConfirmDialog(string.Format("确定要删除任务 {0} 吗？", taskName), InfoType.Warn) == DialogResult.OK)
            {
                for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
                {
                    if (Scheme.curScheme.L_taskList[i].name == taskName)
                    {
                        Frm_Task.Instance.C_taskList.Nodes.RemoveAt(i);
                        Scheme.curScheme.L_taskList.RemoveAt(i);
                        break;
                    }
                }

                FuncLib.ShowMsg(string.Format("任务 {0} 删除成功", taskName), InfoType.Tip);

                //删除最后一个任务时，工具列表需要清空一下，不然不会自动清空
                if (Scheme.curScheme.L_taskList.Count == 0)
                    Frm_Task.Instance.C_toolList.Nodes.Clear();
            }

            //如果没有流程了，那就把当前流程置为null
            if (Scheme.curScheme.L_taskList.Count == 0)
                Task.curTask = null;
        }
        /// <summary>
        /// 循环执行
        /// </summary>
        public void LoopRun()
        {
            Thread th = new Thread(() =>
            {
                while (isLoopRuning)
                {
                    Run();

                    //运行失败停止循环
                    if (taskRunStatu == TaskRunStatu.Fail && Project.Instance.configuration.failStop)
                    {
                        FuncLib.ShowMsg("流程运行失败，停止循环");
                        Frm_Task.Instance.btn_runOnce.Enabled = true;
                        return;
                    }

                    //文件夹图像执行一遍后停止循环
                    if (Project.Instance.configuration.endStop)
                    {
                        for (int i = 0; i < L_toolList.Count; i++)
                        {
                            if (L_toolList[i].toolType == ToolType.采集图像)
                            {
                                if (((ImageTool)L_toolList[i]).imageSource == ImageSource.FromDirectory)
                                {
                                    if (((ImageTool)L_toolList[i]).currentImageIndex == ((ImageTool)L_toolList[i]).L_imagePath.Count - 1)
                                    {
                                        FuncLib.ShowMsg("文件夹图像已遍历，停止循环");
                                        Frm_Task.Instance.btn_runOnce.Enabled = true;
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    Thread.Sleep(Project.Instance.configuration.taskRunSpan);
                }
            });
            th.IsBackground = true;
            th.Start();
        }
        [NonSerialized]
        StringBuilder sb = new StringBuilder("运行统计：");
        /// <summary>
        /// 运行任务
        /// </summary>
        /// <param name="initRun">程序加载时的第一次运行，初始化</param>
        /// <returns></returns>
        public List<object> Run(bool initRun = false, int alarm = 1)
        {
            //sb.Clear();
            //string[] str = sb.ToString().Split(',');
            //int min = 1000;
            //int max = 0;
            //int avg = 0;
            //int sum = 0;
            //int cur = 0;
            //for (int i = 2; i < str.Length - 1; i++)
            //{
            //    cur = Convert.ToInt32(str[i]);
            //    if (min > cur)
            //        min = cur;
            //    if (max < cur)
            //        max = cur;
            //    sum += cur;
            //}
            //avg = sum / str.Length;

            taskRunStatu = TaskRunStatu.Succeed;
            Stopwatch sw_task = new Stopwatch();
            sw_task.Start();
            Stopwatch sw_tool = new Stopwatch();
            //清除运行状态
            if (!Project.Instance.configuration.IsJiSuMoShi && Device.MachineRunStatu != MachineRunStatu.Running)
            {
                if (!initRun && Frm_Task.Instance.C_taskList.SelectedNode != null && Frm_Task.Instance.C_taskList.SelectedNode.Text == name) //判断当前所选任务
                {
                    for (int i = 0; i < L_toolList.Count; i++)
                    {
                        if (L_toolList[i].enable)
                        {
                            if (L_toolList[i].toolRunStatu == "运行成功")
                                Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.Nodes[i], "", Color.FromArgb(240, 240, 240), Color.Green);
                            else
                                Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.Nodes[i], "", Color.FromArgb(240, 240, 240), Color.Red);
                        }
                        else
                        {
                            Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.Nodes[i], "", Color.FromArgb(240, 240, 240), Color.DarkGray);
                        }
                    }
                    Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.SelectedNode, "", Color.FromArgb(250, 250, 250), Color.DarkGray);
                }
            }

            for (int i = 0; i < L_toolList.Count; i++)
            {
                if (L_toolList[i].enable || initRun)
                {
                    if (!L_toolList[i].taskFailKeepRun && taskRunStatu == TaskRunStatu.Fail && !initRun)
                        continue;
                    sw_tool.Restart();
                    //获取输入项的值
                    if (!initRun)
                        L_toolList[i].UpdateInput();
                    //显示运行状态
                    if (!Project.Instance.configuration.IsJiSuMoShi && !initRun && Frm_Task.Instance.C_taskList.SelectedNode != null && Frm_Task.Instance.C_taskList.SelectedNode.Text == name)
                    {
                        try
                        {
                            if (Frm_Task.Instance.C_toolList.SelectedNode != null && Frm_Task.Instance.C_toolList.SelectedNode.Text == L_toolList[i].toolName)
                                Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.Nodes[i], "•••", Color.FromArgb(250, 250, 250), Color.Green);
                            else
                                Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.Nodes[i], "•••", Color.FromArgb(240, 240, 240), Color.Green);
                        }
                        catch { }
                    }

                    L_toolList[i].Run(false, initRun, alarm);

                    sw_tool.Stop();
                    L_toolList[i].elapsedTime = sw_tool.ElapsedMilliseconds;
                    if (L_toolList[i].toolRunStatu != "运行成功")
                    {
                        //////Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.Nodes[i], "    ×", (Frm_Task.Instance.C_toolList.SelectedNode != null && Frm_Task.Instance.C_toolList.SelectedNode.Text == L_toolList[i].toolName) ? Color.FromArgb(250, 250, 250) : Color.FromArgb(240, 240, 240), Color.Red);
                        taskRunStatu = TaskRunStatu.Fail;
                        //////break;
                    }

                    //显示运行时长   ——占用运行时间，先注销
                    if (!Project.Instance.configuration.IsJiSuMoShi && Device.MachineRunStatu != MachineRunStatu.Running)
                    {
                        if (!initRun && Frm_Task.Instance.C_taskList.SelectedNode != null && Frm_Task.Instance.C_taskList.SelectedNode.Text == name)
                        {
                            if (L_toolList[i].enable)
                            {
                                if (L_toolList[i].toolRunStatu == "运行成功")
                                    Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.Nodes[i], FormatTime(L_toolList[i].elapsedTime), (Frm_Task.Instance.C_toolList.SelectedNode != null && Frm_Task.Instance.C_toolList.SelectedNode.Text == L_toolList[i].toolName) ? Color.FromArgb(250, 250, 250) : Color.FromArgb(240, 240, 240), Color.Green);
                                else
                                    Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.Nodes[i], FormatTime(L_toolList[i].elapsedTime), (Frm_Task.Instance.C_toolList.SelectedNode != null && Frm_Task.Instance.C_toolList.SelectedNode.Text == L_toolList[i].toolName) ? Color.FromArgb(250, 250, 250) : Color.FromArgb(240, 240, 240), Color.Red);
                            }
                            else
                            {
                                Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.Nodes[i], "    ×", (Frm_Task.Instance.C_toolList.SelectedNode != null && Frm_Task.Instance.C_toolList.SelectedNode.Text == L_toolList[i].toolName) ? Color.FromArgb(250, 250, 250) : Color.FromArgb(240, 240, 240), Color.DarkGray);
                            }
                        }
                    }

                }
                else
                {
                    if (Frm_Task.Instance.C_toolList.Nodes.Count >= i)
                    {
                        try
                        {
                            Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.Nodes[i], "    ×", (Frm_Task.Instance.C_toolList.SelectedNode != null && Frm_Task.Instance.C_toolList.SelectedNode.Text == L_toolList[i].toolName) ? Color.FromArgb(250, 250, 250) : Color.FromArgb(240, 240, 240), Color.DarkGray);
                        }
                        catch { }
                    }
                }
            }

            //显示任务运行状态
            if (!Project.Instance.configuration.IsJiSuMoShi && !initRun && showRunStatu)
            {
                HTuple row, col, row1, col1;

                //HOperatorSet.GetPart(Frm_Vision.Instance.hWindow_Final1.hWindowControl.HalconWindow, out row, out col, out row1, out col1);

                HOperatorSet.GetPart(GetImageWindow().HWindowHalconID, out row, out col, out row1, out col1);
                if (taskRunStatu == TaskRunStatu.Succeed)
                    HalconLib.DispText(GetImageWindow().HWindowHalconID, "运行成功", 14, row + (row1 - row) / 10, col + (col1 - col) / 30, "green", "false");
                else
                    HalconLib.DispText(GetImageWindow().HWindowHalconID, "运行失败", 14, row + (row1 - row) / 10, col + (col1 - col) / 30, "red", "false");
            }

            if (!Project.Instance.configuration.IsJiSuMoShi && Device.MachineRunStatu != MachineRunStatu.Running)
            {
                if (Task.curTask.name == name && Frm_Task.Instance.C_toolList.Visible)
                {
                    if (Frm_Task.Instance.C_toolList.SelectedNode != null)
                    {
                        if (L_toolList[Frm_Task.Instance.C_toolList.SelectedNode.Index].enable)
                        {
                            if (L_toolList[Frm_Task.Instance.C_toolList.SelectedNode.Index].toolRunStatu == "运行成功")
                                Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.SelectedNode, FormatTime(L_toolList[Frm_Task.Instance.C_toolList.SelectedNode.Index].elapsedTime), Color.FromArgb(250, 250, 250), Color.Green);
                            else
                                Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.SelectedNode, FormatTime(L_toolList[Frm_Task.Instance.C_toolList.SelectedNode.Index].elapsedTime), Color.FromArgb(250, 250, 250), Color.Red);
                            //Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.SelectedNode, "    ×", Color.FromArgb(250, 250, 250), Color.Red);
                        }
                        else
                        {
                            Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.SelectedNode, FormatTime(L_toolList[Frm_Task.Instance.C_toolList.SelectedNode.Index].elapsedTime), Color.FromArgb(250, 250, 250), Color.DarkGray);
                        }
                    }
                }
            }

            sw_task.Stop();
            //Frm_Main.Instance.lbl_CT.Text = name + " 总运行CT：" + sw_task.ElapsedMilliseconds + " ms"; //如果窗体未加载，首次初始化执行此处的话，Showdialog()会出现创建句柄失败的异常

            if (!initRun && !Project.Instance.configuration.IsJiSuMoShi)       //启动不更新，不然的话界面刷新可能会出现异常
            {
                //更新任务运行状态
                if (taskRunStatu == TaskRunStatu.Succeed)
                {
                    if (Frm_Task.FindTreeNodeByTaskName(name) != null)
                    {
                        if (Frm_Task.FindTreeNodeByTaskName(name).Tag == null || Frm_Task.FindTreeNodeByTaskName(name).Tag.ToString() != "G")
                        {
                            Frm_Task.Instance.C_taskList.SetNodeTipsText(Frm_Task.FindTreeNodeByTaskName(name), " ", Color.Green, Color.Green);
                            Frm_Task.FindTreeNodeByTaskName(name).Tag = "G";
                        }
                    }
                }
                else
                {
                    if (Frm_Task.FindTreeNodeByTaskName(name) != null)
                    {
                        if (Frm_Task.FindTreeNodeByTaskName(name).Tag == null || Frm_Task.FindTreeNodeByTaskName(name).Tag.ToString() != "R")
                        {
                            Frm_Task.Instance.C_taskList.SetNodeTipsText(Frm_Task.FindTreeNodeByTaskName(name), " ", Color.Red, Color.Red);
                            Frm_Task.FindTreeNodeByTaskName(name).Tag = "R";
                        }
                    }
                }

                if (taskRunStatu == TaskRunStatu.Succeed)
                    Frm_Main.Instance.lbl_CT.ForeColor = Color.Green;
                else
                    Frm_Main.Instance.lbl_CT.ForeColor = Color.Red;
                Frm_Main.Instance.lbl_CT.Text = name + " 总运行CT：" + sw_task.ElapsedMilliseconds + " ms"; //如果窗体未加载，首次初始化执行此处的话，Showdialog()会出现创建句柄失败的异常
                if (sb == null)
                {
                    sb = new StringBuilder();
                }
                sb.Append(sw_task.ElapsedMilliseconds + ",");
            }

            GC.Collect();
            //GC.WaitForPendingFinalizers();  //此行存在一定的可能会挂起导致任务卡住
            return L_result;
        }
    }

    /// <summary>
    /// 任务运行结果  成功|失败
    /// </summary>
    public enum TaskRunStatu
    {
        Succeed,
        Fail,
    }

}
