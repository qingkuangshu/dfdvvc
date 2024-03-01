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
using System.Reflection;
using System.Text.RegularExpressions;
using HalconDotNet;

namespace VM_Pro
{
    internal partial class Frm_ConnectSource : UIForm
    {
        internal Frm_ConnectSource()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否存在可用值
        /// </summary>
        private static bool existCanUsePara = false;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_ConnectSource _instance;
        internal static Frm_ConnectSource Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_ConnectSource();
                return _instance;
            }
        }


        /// <summary>
        /// 加载参数
        /// </summary>
        internal static void LoadPara()
        {
            try
            {
                Instance.lbl_toolName.Text = string.Format("{0} . {1}", Task.curTask.name, Frm_ToolIO.Instance.cbx_toolList.Text);
                Instance.lbl_inputName.Text = Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Text;

                Instance.tvw_toolList.Nodes.Clear();
                for (int j = 0; j < Task.curTask.L_toolList.Count; j++)
                {
                    existCanUsePara = false;
                    switch (Task.curTask.L_toolList[j].toolType)
                    {
                        case ToolType.采集图像:
                            ShowData(((ImageTool.ToolPar)(Task.curTask.L_toolList[j]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                            break;
                        case ToolType.模板匹配:
                            ShowData(((MatchTool.ToolPar)(Task.curTask.L_toolList[j]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                            break;
                        case ToolType.查找圆形:
                            ShowData(((FindCircleTool.ToolPar)(Task.curTask.L_toolList[j]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                            break;
                        case ToolType.线线交点:
                            ShowData(((LLIntersectTool.ToolPar)(Task.curTask.L_toolList[j]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                            break;
                        case ToolType.引用标定:
                            ShowData(((CoordTransTool.ToolPar)(Task.curTask.L_toolList[j]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                            break;
                    }

                    if (existCanUsePara)
                    {
                        Frm_ToolIO.Instance.Invoke(new Action(() =>
                        {
                            Instance.tvw_toolList.Nodes.Add(string.Format("{0} . {1}", Task.curTask.name, Task.curTask.L_toolList[j].toolName));
                        }));
                    }
                }

                for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
                {
                    if (Scheme.curScheme.L_taskList[i].name != Task.curTask.name)
                    {
                        for (int j = 0; j < Scheme.curScheme.L_taskList[i].L_toolList.Count; j++)
                        {
                            existCanUsePara = false;
                            switch (Scheme.curScheme.L_taskList[i].L_toolList[j].toolType)
                            {
                                case ToolType.采集图像:
                                    ShowData(((ImageTool.ToolPar)(Scheme.curScheme.L_taskList[i].L_toolList[j]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                                    break;
                                case ToolType.模板匹配:
                                    ShowData(((MatchTool.ToolPar)(Scheme.curScheme.L_taskList[i].L_toolList[j]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                                    break;
                                case ToolType.查找圆形:
                                    ShowData(((FindCircleTool.ToolPar)(Scheme.curScheme.L_taskList[i].L_toolList[j]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                                    break;
                                case ToolType.引用标定:
                                    ShowData(((CoordTransTool.ToolPar)(Scheme.curScheme.L_taskList[i].L_toolList[j]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                                    break;
                            }

                            if (existCanUsePara)
                            {
                                Frm_ToolIO.Instance.Invoke(new Action(() =>
                                {
                                    Instance.tvw_toolList.Nodes.Add(string.Format("{0} . {1}", Scheme.curScheme.L_taskList[i].name, Scheme.curScheme.L_taskList[i].L_toolList[j].toolName));
                                }));
                            }
                        }
                    }
                }

                if (Instance.tvw_toolList.Nodes.Count > 0)
                    Instance.tvw_toolList.SelectedNode = Instance.tvw_toolList.Nodes[0];
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 解析值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static object ShowData(object obj, DataType dataType)
        {
            PropertyInfo[] dd = obj.GetType().GetProperties();
            foreach (PropertyInfo pi in obj.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                //节点上要显示参数名、参数类型和参数当前值
                string temp = Regex.Split(pi.ToString(), " ")[0];

                TreeNode node = new TreeNode();
                if (temp == "VMPro.XYU")
                {
                    //////node = nodes.Add("", "<集合<XYU>>  " + pi.Name);
                    //////node.Tag = DataType.XYU;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "HalconDotNet.HObject" && dataType == DataType.Image)
                {
                    existCanUsePara = true;
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
                else if (temp == "System.Collections.Generic.List`1[VM_Pro.XY]" && dataType == DataType.ListXY)
                {
                    existCanUsePara = true;
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
                else if (temp == "System.Collections.Generic.List`1[VM_Pro.XYU]" && dataType == DataType.ListXYU)
                {
                    existCanUsePara = true;
                    //////node = nodes.Add("", "<集合<XYU>>  " + pi.Name);
                    //////node.Tag = DataType.XYU;
                    //////node.ForeColor = Color.Black;
                }
                else
                {
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
                else
                {
                    ShowData(value, dataType);
                }
            }
            return new object();
        }
        /// <summary>
        /// 解析值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static object ShowData2(object obj, DataType dataType)
        {
            PropertyInfo[] dd = obj.GetType().GetProperties();
            foreach (PropertyInfo pi in obj.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                //节点上要显示参数名、参数类型和参数当前值
                string temp = Regex.Split(pi.ToString(), " ")[0];

                TreeNode node = new TreeNode();
                if (temp == "VMPro.XYU")
                {
                    //////node = nodes.Add("", "<集合<XYU>>  " + pi.Name);
                    //////node.Tag = DataType.XYU;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "HalconDotNet.HObject" && dataType == DataType.Image)
                {
                    node = Instance.tvw_itemList.Nodes.Add(pi.Name);
                    node.Tag = dataType;
                }
                else if (temp == "VMPro.XY")
                {
                    //////node = nodes.Add("", "<XY>  " + pi.Name);
                    //////node.Tag = DataType.XY;
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
                    node = Instance.tvw_itemList.Nodes.Add(pi.Name);
                    node.Tag = dataType;
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
                    node = Instance.tvw_itemList.Nodes.Add(pi.Name);
                    node.Tag = dataType;
                }
                else
                {
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

                        ShowData2(pi.GetValue(obj), dataType);
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
                else
                {
                    ShowData(value, dataType);
                }
            }
            return new object();
        }


        private void tvw_toolList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvw_toolList.SelectedNode == null)
                return;

            tvw_itemList.Nodes.Clear();
            switch (Task.FindTaskByName(Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[0]).FindToolByName(Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[1]).toolType)
            {
                case ToolType.采集图像:
                    ShowData2(((ImageTool.ToolPar)Task.FindTaskByName(Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[0]).FindToolByName(Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[1]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                    break;
                case ToolType.模板匹配:
                    ShowData2(((MatchTool.ToolPar)Task.FindTaskByName(Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[0]).FindToolByName(Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[1]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                    break;
                case ToolType.查找圆形:
                    ShowData2(((FindCircleTool.ToolPar)Task.FindTaskByName(Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[0]).FindToolByName(Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[1]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                    break;
                case ToolType.线线交点:
                    ShowData2(((LLIntersectTool.ToolPar)Task.FindTaskByName(Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[0]).FindToolByName(Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[1]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                    break;
                case ToolType.引用标定:
                    ShowData2(((CoordTransTool.ToolPar)Task.FindTaskByName(Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[0]).FindToolByName(Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[1]).参数).输出, (DataType)Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Tag);
                    break;
            }

            if (tvw_itemList.Nodes.Count > 0)
                tvw_itemList.SelectedNode = tvw_itemList.Nodes[0];
        }
        private void tvw_itemList_DoubleClick(object sender, EventArgs e)
        {
            string inputItemName = Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Text;
            if (inputItemName.Contains(" . "))
                inputItemName = Regex.Split(inputItemName, " . ")[0];

            for (int i = 0; i < Frm_ToolIO.toolBase.L_inputItem.Count; i++)
            {
                if (Frm_ToolIO.toolBase.L_inputItem[i].InputName == inputItemName)
                {
                    InputItem inputItem = new InputItem();
                    inputItem.InputName = Frm_ToolIO.toolBase.L_inputItem[i].InputName;
                    inputItem.sourceTask = Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[0];
                    inputItem.sourceTool = Regex.Split(tvw_toolList.SelectedNode.Text, " . ")[1];
                    inputItem.sourceOutput = tvw_itemList.SelectedNode.Text;
                    inputItem.inputType = (DataType)tvw_itemList.SelectedNode.Tag;

                    Frm_ToolIO.Instance.tvw_inputItemList.SelectedNode.Text = string.Format("{0} = {1} . {2} . {3}", inputItem.InputName, inputItem.sourceTask, inputItem.sourceTool, inputItem.sourceOutput);

                    Frm_ToolIO.toolBase.L_inputItem.RemoveAt(i);
                    Frm_ToolIO.toolBase.L_inputItem.Insert(i, inputItem);
                    this.Close();
                    break;
                }
            }
            this.Close();
        }
        private void Frm_ToolIO_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

    }
}
