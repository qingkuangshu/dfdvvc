using HalconDotNet;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewWindow.Model;

namespace VM_Pro
{
    [Serializable]
    /// <summary>
    /// 采集图像
    /// </summary>
    internal class OutTool : ToolBase
    {
        internal OutTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;
        }

        /// <summary>
        /// 解析值
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal object GetValue(object obj, string name)
        {
            PropertyInfo[] dd = obj.GetType().GetProperties();
            foreach (PropertyInfo pi in obj.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                //节点上要显示参数名、参数类型和参数当前值
                string temp = Regex.Split(pi.ToString(), " ")[0];


                if (temp.ToString() == "P输入")
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

            Task.FindTaskByName(taskName).L_result.Clear();
            for (int i = 0; i < L_outItem.Count; i++)
            {
                object obj = GetValue(Task.FindTaskByName(taskName).FindToolByName(L_outItem[i].toolName).参数, L_outItem[i].itemName);
                Task.FindTaskByName(taskName).L_result.Add(obj);
            } 

            sw.Stop(); 
            toolRunStatu = "运行成功";
        Exit:
            if (Frm_OutTool.hasShown && Frm_OutTool.taskName == taskName && Frm_OutTool.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_OutTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString()); 
                if (toolRunStatu == "运行成功")
                {
                    Frm_OutTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                    Frm_OutTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
                }
                else
                {
                    Frm_OutTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                    Frm_OutTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
                }
            }
        }

        /// <summary>
        /// 输出项集合
        /// </summary>
        internal List<OutItem> L_outItem = new List<OutItem>();

        /// <summary>
        /// 复位工具
        /// </summary>
        internal override void ResetTool()
        {
            Frm_OutTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
            Frm_OutTool.Instance.lbl_toolTip.Text = "暂无提示";
            Frm_OutTool.Instance.lbl_runTime.Text = "0 ms";

            Frm_FromCamera.Instance.nud_exposure.Value = 100;
            Frm_FromFile.Instance.tbx_imagePath.Text = string.Empty;
            Frm_FromDirectory.Instance.tbx_imageDirectoryPath.Text = string.Empty;
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
        public class P输入 { }
        [Serializable]
        public class P运行 { }
        [Serializable]
        internal class P输出 { }

        #endregion

    }

    /// <summary>
    /// 输出项
    /// </summary>
    [Serializable]
    internal struct OutItem
    {
        internal string toolName;
        internal string itemName;
    }

}
