using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace VM_Pro
{
    public partial class FrmBianLiang : UIForm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LianRuNamesToToolName">将链入列表添加到哪个工具当中</param>
        public FrmBianLiang(string LianRuNamesToToolName)
        {
            InitializeComponent();
            this.toolNameAddInput = LianRuNamesToToolName;
        }


        //private static FrmBianLiang _instance;

        //internal static FrmBianLiang Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new FrmBianLiang();
        //        }
        //        return _instance;

        //    }
        //}

        /// <summary>
        /// 当前窗体是否显示
        /// </summary>
        internal static bool hasShown = false;

        /// <summary>
        /// 将当前链入列表添加到哪个工具当中
        /// </summary>
        internal string toolNameAddInput = "";


        /// <summary>
        /// 将链入的工具列表显示到导航栏节点当中
        /// </summary>
        /// <param name="lstNodeNames"></param>
        internal void ShowNavNodes(List<string> lstNodeNames)
        {
            try
            {
                uiNavMenu1.ClearAll();
                for (int i = 0; i < lstNodeNames.Count; i++)
                {
                    TreeNode treenode = null;
                    try
                    {
                        treenode = uiNavMenu1.Nodes.Add(lstNodeNames[i]);
                    }
                    catch (Exception)
                    {
                    }

                    if (i == 0 && treenode != null)
                    {
                        uiNavMenu1.SelectedNode = treenode;
                    }

                }
                if (lstNodeNames.Count > 0)
                {
                    uiNavMenu1_AfterSelect(null, null);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void FrmBianLiang_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            hasShown = false;
            this.DialogResult = DialogResult.No;

        }

        /// <summary>
        /// 改变选择菜单栏所触发的选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiNavMenu1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (this.TagString == "区域")
                {
                    for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
                    {
                        if (Task.curTask.L_toolList[i].toolName == uiNavMenu1.SelectedNode.Text.Trim())
                        {
                            uiDataGridView1.Rows.Clear();
                            switch (Task.curTask.L_toolList[i].toolType)
                            {
                                case ToolType.模板匹配:
                                    uiDataGridView1.Rows.Add();

                                    uiDataGridView1.Rows[0].Cells[0].Value = "XYU";
                                    uiDataGridView1.Rows[0].Cells[1].Value = "位置";
                                    uiDataGridView1.Rows[0].Cells[2].Value = uiNavMenu1.SelectedNode.Text + " . 输出 . 位置";
                                    break;
                                case ToolType.创建区域:
                                case ToolType.图像预处理:
                                case ToolType.图像脚本:
                                    uiDataGridView1.Rows.Add();

                                    uiDataGridView1.Rows[0].Cells[0].Value = "Region";
                                    uiDataGridView1.Rows[0].Cells[1].Value = "区域";
                                    uiDataGridView1.Rows[0].Cells[2].Value = uiNavMenu1.SelectedNode.Text + " . 输出 . 区域";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    }
                }
                else if (TagString == "图像")
                {
                    for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
                    {
                        if (Task.curTask.L_toolList[i].toolName == uiNavMenu1.SelectedNode.Text.Trim())
                        {
                            uiDataGridView1.Rows.Clear();
                            switch (Task.curTask.L_toolList[i].toolType)
                            {
                                case ToolType.图像预处理:
                                case ToolType.采集图像:
                                case ToolType.推理识别:
                                case ToolType.图像脚本:
                                    uiDataGridView1.Rows.Add();

                                    uiDataGridView1.Rows[0].Cells[0].Value = "Hobject";
                                    uiDataGridView1.Rows[0].Cells[1].Value = "图像";
                                    uiDataGridView1.Rows[0].Cells[2].Value = uiNavMenu1.SelectedNode.Text + " . 输出 . 图像";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    }
                }
                else if (TagString == "HObject")
                {
                    for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
                    {

                        if (Task.curTask.L_toolList[i].toolName == uiNavMenu1.SelectedNode.Text.Trim())
                        {
                            uiDataGridView1.Rows.Clear();
                            switch (Task.curTask.L_toolList[i].toolType)
                            {
                                case ToolType.采集图像:
                                case ToolType.推理识别:
                                    uiDataGridView1.Rows.Add();
                                    uiDataGridView1.Rows[0].Cells[0].Value = "Hobject";
                                    uiDataGridView1.Rows[0].Cells[1].Value = "图像";
                                    uiDataGridView1.Rows[0].Cells[2].Value = uiNavMenu1.SelectedNode.Text + " . 输出 . 图像";
                                    break;
                                case ToolType.图像预处理:
                                    uiDataGridView1.Rows.Add(2);
                                    uiDataGridView1.Rows[0].Cells[0].Value = "Region";
                                    uiDataGridView1.Rows[0].Cells[1].Value = "区域";
                                    uiDataGridView1.Rows[0].Cells[2].Value = uiNavMenu1.SelectedNode.Text + " . 输出 . 区域";
                                    uiDataGridView1.Rows[1].Cells[0].Value = "Hobject";
                                    uiDataGridView1.Rows[1].Cells[1].Value = "图像";
                                    uiDataGridView1.Rows[1].Cells[2].Value = uiNavMenu1.SelectedNode.Text + " . 输出 . 图像";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    }
                }
                else if (TagString == "文本")
                {
                    for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
                    {

                        if (Task.curTask.L_toolList[i].toolName == uiNavMenu1.SelectedNode.Text.Trim())
                        {
                            uiDataGridView1.Rows.Clear();
                            switch (Task.curTask.L_toolList[i].toolType)
                            {
                                case ToolType.码类识别:
                                case ToolType.以太网发:
                                    uiDataGridView1.Rows.Add();
                                    uiDataGridView1.Rows[0].Cells[0].Value = "string";
                                    uiDataGridView1.Rows[0].Cells[1].Value = "文本";
                                    uiDataGridView1.Rows[0].Cells[2].Value = uiNavMenu1.SelectedNode.Text + " . 输出 . 文本";
                                    break;
                                
                                default:
                                    break;
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FuncLib.ShowExceptionBox(ex.Message);
            }
        }

        private void btn_QueDing_Click(object sender, EventArgs e)
        {
            if (uiNavMenu1.SelectedNode == null)
            {
                UIMessageTip.ShowWarning("当前未选中输入项..");
                return;
            }

            LianRuToolInput();

            hasShown = false;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 最新一次变量链入工具的信息，主要是方便外部根据此信息做进一步的操作
        /// </summary>
        internal static InputItem currentSelectInputItem = new InputItem();

        /// <summary>
        /// 最新一次变量链入工具的字符串信息
        /// </summary>
        internal static string currentLianRuInfo = "";

        /// <summary>
        /// 链入图像源任意数据
        /// </summary>
        internal void LianRuToolInput()
        {
            //1、获取当然任务的共有多少个工具
            int toolsCount = Task.curTask.L_toolList.Count;
            string strType = "";
            DataType LianRuType = GetDGVSelectName(out strType);
            //2、遍历找到当前需要链入变量的工具，并根据该工具目前是否有相应输入项进行增加或修改
            for (int i = 0; i < toolsCount; i++)
            {
                if (Task.curTask.L_toolList[i].toolName.Equals(toolNameAddInput.ToString()))    //若当前工具即为要链入的工具
                {
                    //先删除当前需求工具同类型的输入
                    for (int k = 0; k < Task.curTask.L_toolList[i].L_inputItem.Count; k++)
                    {
                        if (Task.curTask.L_toolList[i].L_inputItem[k].inputType == LianRuType)
                        {
                            Task.curTask.L_toolList[i].L_inputItem.RemoveAt(k);
                            break;
                        }
                    }
                    //添加最新输入
                    currentSelectInputItem.InputName = strType;
                    currentSelectInputItem.inputType = LianRuType;
                    currentSelectInputItem.sourceTask = Task.curTask.name;
                    currentSelectInputItem.sourceTool = uiNavMenu1.SelectedNode.Text.Trim(); //被链入的工具名称
                    currentSelectInputItem.sourceOutput = strType;
                    Task.curTask.L_toolList[i].L_inputItem.Add(currentSelectInputItem);
                    currentLianRuInfo = currentSelectInputItem.sourceTool + "." + currentSelectInputItem.InputName;
                    break;
                }

            }
        }

        /// <summary>
        /// 获取当前DGV控件当中选中行的名称的类型
        /// </summary>
        /// <returns></returns>
        private DataType GetDGVSelectName(out string strDataType)
        {
            DataType type = DataType.Image;

            int selectRow = uiDataGridView1.CurrentRow.Index;
            if (selectRow >0)
            {
                strDataType = uiDataGridView1.Rows[selectRow].Cells[1].Value.ToString();
            }
            else
            {
                strDataType = uiDataGridView1.Rows[0].Cells[1].Value.ToString();

            }

            switch (strDataType)
            {
                case "图像":
                    type = DataType.Image;
                    break;
                case "区域":
                    type = DataType.Region;
                    break;
                case "位置":
                    type = DataType.ListXYU;
                    break;
                case "文本":
                    type = DataType.String;
                    break;
                default:

                    break;
            }
            return type;
        }



        private void FrmBianLiang_Load(object sender, EventArgs e)
        {
            hasShown = true;
        }
    }
}
