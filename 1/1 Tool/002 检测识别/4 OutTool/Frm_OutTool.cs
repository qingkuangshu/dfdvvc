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
using System.Text.RegularExpressions;

namespace VM_Pro
{
    public partial class Frm_OutTool : UIForm
    {
        public Frm_OutTool()
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
        internal static OutTool outTool;
        /// <summary>
        /// 图像显示区域
        /// </summary>
        internal static List<ViewWindow.Model.ROI> L_regions = new List<ViewWindow.Model.ROI>();
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_OutTool _instance;
        internal static Frm_OutTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_OutTool();
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
            outTool = (OutTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;
            Instance.Show();
            Application.DoEvents();
            hasShown = true;

            Instance.ckb_taskFailKeepRun.Checked = outTool.taskFailKeepRun;

            //显示所有工具
            Instance.tvw_toolList.Nodes.Clear();
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                Instance.tvw_toolList.Nodes.Add(Task.curTask.L_toolList[i].toolName);
            }
            Instance.tvw_toolList.SelectedNode = Instance.tvw_toolList.Nodes[0];

            //显示已添加项
            Instance.tvw_itemAdded.Nodes.Clear();
            for (int i = 0; i < outTool.L_outItem.Count; i++)
            {
                Instance.tvw_itemAdded.Nodes.Add(string.Format("{0} . {1} = {2}", outTool.L_outItem[i].toolName, outTool.L_outItem[i].itemName, "测试"));
            }

            Thread th = new Thread(() =>
            {
                outTool.Run();
            });
            th.IsBackground = true;
            th.Start();

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
            outTool.ResetTool();
        }
        private void Frm_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

        private void btn_runTool_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                this.Invoke(new Action(() =>
                {
                    Frm_Loading.Instance.lbl_title.Text = "拼命加载中";
                    Frm_Loading.Instance.TopLevel = true;
                    Frm_Loading.Instance.TopMost = true;
                    Frm_Loading.Instance.Show();
                }));
                outTool.Run();
                Frm_Loading.Instance.Hide();
            });
            th.IsBackground = true;
            th.Start();
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
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvw_toolList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadPar();
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        internal void LoadPar()
        {
            tvw_itemList.Nodes.Clear();
            switch (Task.curTask.FindToolByName(tvw_toolList.SelectedNode.Text).toolType)
            {
                case ToolType.采集图像:
                    GetValue(((ImageTool)Task.curTask.FindToolByName(tvw_toolList.SelectedNode.Text)).参数);
                    break;
                case ToolType.码类识别:
                    GetValue(((IDTool)Task.curTask.FindToolByName(tvw_toolList.SelectedNode.Text)).参数);
                    break;
                case ToolType.查找圆形:
                    GetValue(((FindCircleTool)Task.curTask.FindToolByName(tvw_toolList.SelectedNode.Text)).参数);
                    break;
                case ToolType.顶部定位:
                    GetValue(((UpCamAlignTool)Task.curTask.FindToolByName(tvw_toolList.SelectedNode.Text)).参数);
                    break;
                case ToolType.对位贴合二:
                    GetValue(((DownCamAlignTool2)Task.curTask.FindToolByName(tvw_toolList.SelectedNode.Text)).参数);
                    break;
            }
        }

        /// <summary>
        /// 解析值
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal object GetValue(object obj)
        {
            PropertyInfo[] dd = obj.GetType().GetProperties();
            foreach (PropertyInfo pi in obj.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                //节点上要显示参数名、参数类型和参数当前值
                string temp = Regex.Split(pi.ToString(), " ")[0];

                if (temp == "P输入" || temp == "P运行")
                {
                    continue;
                }

                TreeNode node = new TreeNode();
                if (temp == "VM_Pro.XYU")
                {
                    tvw_itemList.Nodes.Add(pi.Name);

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
                    tvw_itemList.Nodes.Add(pi.Name);

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
                    tvw_itemList.Nodes.Add(pi.Name);

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
                    tvw_itemList.Nodes.Add(pi.Name);

                    //////node = nodes.Add("", "<集合<文本>>  " + pi.Name);
                    //////node.Tag = DataType.String;
                    //////node.ForeColor = Color.Black;
                }
                else if (temp == "System.Collections.Generic.List`1[VM_Pro.XYU]")
                {
                    tvw_itemList.Nodes.Add(pi.Name);
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

                        GetValue(((List<XYU>)value)[i]);
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

                        GetValue(((List<XY>)value)[i]);
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
                    GetValue(value);
                }
            }
            return new object();
        }

        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            outTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }
        private void tvw_itemList_DoubleClick(object sender, EventArgs e)
        {
            OutItem outItem = new OutItem();
            outItem.toolName = tvw_toolList.SelectedNode.Text;
            outItem.itemName = tvw_itemList.SelectedNode.Text;
            outTool.L_outItem.Add(outItem);

            tvw_itemAdded.Nodes.Add(string.Format("{0} . {1} ：{2}", outItem.toolName, outItem.itemName, "空"));
        }
        private void Frm_OutTool_ExtendBoxClick(object sender, EventArgs e)
        {
            Instance.TopMost = !Instance.TopMost;

            if (Instance.TopMost)
                Instance.ExtendSymbol = 61475;
            else
                Instance.ExtendSymbol = 61758;
        }

    }
}
