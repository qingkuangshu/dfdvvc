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

namespace VM_Pro
{
    internal partial class Frm_ToolIO : UIForm
    {
        internal Frm_ToolIO()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 工具对象
        /// </summary>
        internal static ToolBase toolBase;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_ToolIO _instance;
        internal static Frm_ToolIO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_ToolIO();
                return _instance;
            }
        }


        /// <summary>
        /// 加载参数
        /// </summary>
        internal void LoadPar()
        {
            tvw_paraTree.Nodes.Clear();
            switch (toolBase.toolType)
            {
                case ToolType.推理识别:
                    GetValue(tvw_paraTree.Nodes, ((InferenceTool)toolBase).参数);
                    break;
                case ToolType.图像预处理:
                    GetValue(tvw_paraTree.Nodes, ((PreconditionTool)toolBase).参数);
                    break;
                case ToolType.创建区域:
                    GetValue(tvw_paraTree.Nodes, ((CreateRoiTool)toolBase).参数);
                    break;
                case ToolType.采集图像:
                    GetValue(tvw_paraTree.Nodes, ((ImageTool)toolBase).参数);
                    break;
                case ToolType.存储图像:
                    GetValue(tvw_paraTree.Nodes, ((SaveImageTool)toolBase).参数);
                    break;
                case ToolType.模板匹配:
                    GetValue(tvw_paraTree.Nodes, ((MatchTool)toolBase).参数);
                    break;
                case ToolType.引用标定:
                    GetValue(tvw_paraTree.Nodes, ((CoordTransTool)toolBase).参数);
                    break;
                case ToolType.顶部定位:
                    GetValue(tvw_paraTree.Nodes, ((UpCamAlignTool)toolBase).参数);
                    break;
                case ToolType.对位贴合二:
                    GetValue(tvw_paraTree.Nodes, ((DownCamAlignTool2)toolBase).参数);
                    break;
                case ToolType.码类识别:
                    GetValue(tvw_paraTree.Nodes, ((IDTool)toolBase).参数);
                    break;
                case ToolType.字符识别:
                    GetValue(tvw_paraTree.Nodes, ((OCRTool)toolBase).参数);
                    break;
                case ToolType.胶路检测:
                    GetValue(tvw_paraTree.Nodes, ((GlueDetectTool)toolBase).参数);
                    break;
                case ToolType.查找直线:
                    GetValue(tvw_paraTree.Nodes, ((FindLineTool)toolBase).参数);
                    break;
                case ToolType.查找圆形:
                    GetValue(tvw_paraTree.Nodes, ((FindCircleTool)toolBase).参数);
                    break;
                case ToolType.线线交点:
                    GetValue(tvw_paraTree.Nodes, ((LLIntersectTool)toolBase).参数);
                    break;
                case ToolType.以太网发:
                    GetValue(tvw_paraTree.Nodes, ((NetworkSendTool)toolBase).参数);
                    break;
                case ToolType.外部输出:
                    GetValue(tvw_paraTree.Nodes, ((OutTool)toolBase).参数);
                    break;
                default:
                    return;
            }
            DisenableNode(tvw_paraTree.Nodes[1]);
            DisenableNode(tvw_paraTree.Nodes[2]);
            tvw_paraTree.ExpandAll();

            //显示已添加输入项
            tvw_inputItemList.Nodes.Clear();
            for (int i = 0; i < toolBase.L_inputItem.Count; i++)
            {
                TreeNode treeNode = tvw_inputItemList.Nodes.Add(string.Format("{0} = {1} . {2}", toolBase.L_inputItem[i].InputName, toolBase.L_inputItem[i].sourceTool, toolBase.L_inputItem[i].sourceOutput));
                treeNode.Tag = toolBase.L_inputItem[i].inputType;
            }
        }
        /// <summary>
        /// 节点不启用
        /// </summary>
        /// <param name="node"></param>
        private void DisenableNode(TreeNode node)
        {
            node.ForeColor = Color.DarkGray;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                DisenableNode(node.Nodes[i]);
            }
        }
        /// <summary>
        /// 解析值
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal object GetValue(TreeNodeCollection nodes, object obj)
        {
            PropertyInfo[] dd = obj.GetType().GetProperties();
            foreach (PropertyInfo pi in obj.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                //节点上要显示参数名、参数类型和参数当前值
                string temp = Regex.Split(pi.ToString(), " ")[0];

                TreeNode node = new TreeNode();
                if (temp == "VMPro.XYU")
                {
                    node = nodes.Add("", "<XYU>  " + pi.Name);
                    node.Tag = DataType.XYU;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "HalconDotNet.HObject")
                {
                    node = nodes.Add("", "<Image>  " + pi.Name);
                    node.Tag = DataType.Image;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "VMPro.XY")
                {
                    node = nodes.Add("", "<XY>  " + pi.Name);
                    node.Tag = DataType.XY;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "System.Object")
                {
                    node = nodes.Add("", "<XY>  " + pi.Name);
                    node.Tag = DataType.Image;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "VM_Pro.Line")
                {
                    node = nodes.Add("", "<Line>  " + pi.Name);
                    node.Tag = DataType.Line;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "Double")
                {
                    node = nodes.Add("", "<Double>  " + pi.Name + "=" + pi.GetValue(obj, null));
                    node.Tag = DataType.String;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "System.String")
                {
                    node = nodes.Add("", "<String>  " + pi.Name + "=" + pi.GetValue(obj, null));
                    node.Tag = DataType.String;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "HalconDotNet.HRegion")
                {
                    node = nodes.Add("", "<Region>  " + pi.Name);
                    node.Tag = DataType.Region;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "Int32")
                {
                    node = nodes.Add("", "<Int>  " + pi.Name + "=" + pi.GetValue(obj, null));
                    node.Tag = DataType.String;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "System.Collections.Generic.List`1[VM_Pro.XY]")
                {
                    node = nodes.Add("", "<List<XY>>  " + pi.Name);
                    node.Tag = DataType.ListXY;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "System.Collections.Generic.List`1[System.Double]")
                {
                    node = nodes.Add("", "<List<Double>>  " + pi.Name);
                    node.Tag = DataType.String;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "System.Collections.Generic.List`1[System.String]")
                {
                    node = nodes.Add("", "<List<String>>  " + pi.Name);
                    node.Tag = DataType.String;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "System.Collections.Generic.List`1[VM_Pro.XYU]")
                {
                    node = nodes.Add("", "<List<XYU>>  " + pi.Name);
                    node.Tag = DataType.ListXYU;
                    node.ForeColor = Color.Black;
                }
                else if (temp == "System.Collections.Generic.List`1[VM_Pro.Line]")
                {
                    node = nodes.Add("", "<List<Line>>  " + pi.Name);
                    node.Tag = DataType.ListLine;
                    node.ForeColor = Color.Black;
                }
                else
                {
                    node = nodes.Add("", pi.Name);
                    node.ForeColor = Color.DarkGray;
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

                        GetValue(treeNode.Nodes, ((List<XYU>)value)[i]);
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

                        GetValue(treeNode.Nodes, ((List<XY>)value)[i]);
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
                        Line str = ((List<Line>)value)[j];

                        TreeNode treeNode = new TreeNode();
                        treeNode = node.Nodes.Add("", "<线>  " + "成员" + (j + 1) + "=" + str);
                        treeNode.Tag = DataType.Line;
                        treeNode.ForeColor = Color.Black;
                    }
                }
                else
                {
                    GetValue(node.Nodes, value);
                }
            }
            return new object();
        }


        private void cbx_toolList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolBase == null)
                return;

            toolBase = Task.curTask.L_toolList[cbx_toolList.SelectedIndex];
            LoadPar();
        }
        private void btn_nextOne_Click(object sender, EventArgs e)
        {
            if (cbx_toolList.SelectedIndex == cbx_toolList.Items.Count - 1)
                return;

            cbx_toolList.SelectedIndex = cbx_toolList.SelectedIndex + 1;
            toolBase = Task.curTask.L_toolList[cbx_toolList.SelectedIndex];

            LoadPar();
            Show();
        }
        private void tvw_paraTree_DoubleClick(object sender, EventArgs e)
        {
            InputItem inputItem = new InputItem();

            string text = Regex.Split(tvw_paraTree.SelectedNode.Text, "  ")[1];
            if (text.Contains("="))
                text = Regex.Split(text, "=")[0];
            inputItem.InputName = text;

            //查重
            for (int i = 0; i < Task.curTask.FindToolByName(cbx_toolList.Text).L_inputItem.Count; i++)
            {
                if (Task.curTask.FindToolByName(cbx_toolList.Text).L_inputItem[i].InputName == inputItem.InputName)
                    return;
            }

            inputItem.inputType = (DataType)tvw_paraTree.SelectedNode.Tag;
            inputItem.sourceTask = string.Empty;
            inputItem.sourceTool = string.Empty;
            inputItem.sourceOutput = string.Empty;

            Task.curTask.FindToolByName(cbx_toolList.Text).L_inputItem.Add(inputItem);
            TreeNode treeNode = tvw_inputItemList.Nodes.Add(inputItem.InputName);
            treeNode.Tag = tvw_paraTree.SelectedNode.Tag;
        }
        private void tvw_inputItemList_DoubleClick(object sender, EventArgs e)
        {
            Frm_ConnectSource.Instance.Show();
            Frm_ConnectSource.LoadPara();
        }
        private void 删除toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Task.curTask.FindToolByName(cbx_toolList.Text).L_inputItem.RemoveAt(tvw_inputItemList.SelectedNode.Index);
            tvw_inputItemList.Nodes.RemoveAt(tvw_inputItemList.SelectedNode.Index);
        }
        private void Frm_ToolIO_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

    }
}
