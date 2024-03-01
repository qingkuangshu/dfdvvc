using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Sunny.UI;
namespace VM_Pro
{
    public partial class Frm_Task : UIPage
    {
        public Frm_Task()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 用于区别双击和点击
        /// </summary>
        private bool firstClicked = false;
        ///禁用全部工具
        private static bool isIgnoredAll = false;
        /// <summary>
        /// 正在运行流程
        /// </summary>
        internal static bool isRunning = false;
        /// <summary>
        /// 被拖拽的工具节点
        /// </summary>
        internal static TreeNode m_DragNode = null;
        /// <summary>
        /// 节点移动来源
        /// </summary>
        internal static TreeView m_NodeSource = null;
        /// <summary>
        /// 节点移动去向
        /// </summary>
        internal static MoveTreeView m_MoveTo = MoveTreeView.NoMove;
        /// <summary>
        /// 被复制的任务
        /// </summary>
        private static Task taskCopied = null;
        /// <summary>
        /// 记录鼠标点击的时候，鼠标当前的位置，用于后面区分点在了空白区域，还是点在了节点区域
        /// </summary>
        internal static Point clickTaskPos = new Point();
        /// <summary>
        /// 记录鼠标点击的时候，鼠标当前的位置，用于后面区分点在了空白区域，还是点在了节点区域
        /// </summary>
        internal static Point clickToolPos = new Point();


        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Task _instance;
        internal static Frm_Task Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Task();
                return _instance;
            }
        }


        /// <summary>
        /// 通过工具名称查找相应树节点
        /// </summary>
        /// <param name="toolName">工具名称</param>
        /// <returns>对应树节点</returns>
        internal TreeNode FindTreeNodeByToolName(string toolName)
        {
            for (int i = 0; i < C_toolList.Nodes.Count; i++)
            {
                if (C_toolList.Nodes[i].Text == toolName)
                {
                    return C_toolList.Nodes[i];
                }
            }
            return null;
        }
        /// <summary>
        /// 通过任务名称查找相应树节点
        /// </summary>
        /// <param name="taskName">任务名称</param>
        /// <returns>对应树节点</returns>
        internal static TreeNode FindTreeNodeByTaskName(string taskName)
        {
            for (int i = 0; i < Instance.C_taskList.Nodes.Count; i++)
            {
                if (Instance.C_taskList.Nodes[i].Text == taskName)
                {
                    return Instance.C_taskList.Nodes[i];
                }
            }
            return null;
        }


        private void Frm_Task_Load(object sender, EventArgs e)
        {
            if (C_taskList.Nodes.Count > 0)
                C_taskList.SelectedNode = C_taskList.Nodes[0];
        }
        private void Frm_Task_Shown(object sender, EventArgs e)
        {
            //清除工具状态显示
            for (int i = 0; i < C_toolList.Nodes.Count; i++)
            {
                C_toolList.SetNodeTipsText(C_toolList.Nodes[i], "", Color.Green, Color.Green);
                C_toolList.Nodes[i].Tag = "";
            }

            //清除任务状态显示
            for (int i = 0; i < C_taskList.Nodes.Count; i++)
            {
                C_taskList.SetNodeTipsText(C_taskList.Nodes[i], "", Color.Green, Color.Green);
                C_taskList.Nodes[i].Tag = "";
            }
        }
        private void Frm_Task_Resize(object sender, EventArgs e)
        {
            C_toolList.Height = this.Height - 70;
        }

        private void 隐藏页面toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Project.Instance.configuration.toolBoxStatu = 2;
            if (splitContainer1.Panel2Collapsed)
                splitContainer2.Panel1Collapsed = true;
            else
                splitContainer1.Panel1Collapsed = true;
            Frm_ToolBox.Instance.Hide();
        }
        private void 悬浮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_toolBox.Parent != Frm_ToolBox.Instance)
            {
                Project.Instance.configuration.toolBoxStatu = 1;
                splitContainer1.Panel1Collapsed = true;
                C_toolBox.Parent = Frm_ToolBox.Instance;
                C_toolBox.Dock = DockStyle.Fill;
                Frm_ToolBox.Instance.Show();
            }
            else
            {
                Project.Instance.configuration.toolBoxStatu = 0;
                splitContainer1.Panel1Collapsed = false;
                C_toolBox.Parent = splitContainer1.Panel1;
                Frm_ToolBox.Instance.Hide();
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Create();
        }
        private void 复制ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Task.Copy(C_taskList.SelectedNode.Text);
        }
        private void 粘贴插入ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Task.Paste(C_taskList);
        }
        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Inport();
        }
        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Export();
        }
        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Task.Delete();
        }
        private void 重命名ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            Task.Rename();
        }
        private void 隐藏ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (splitContainer1.Panel1Collapsed)
                splitContainer2.Panel1Collapsed = true;
            else
                splitContainer1.Panel2Collapsed = true;

            Project.Instance.configuration.taskListVisible = false;
        }
        private void 配置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (Task.curTask == null)
                return;

            Frm_TaskInfo.Instance.ShowDialog();
        }

        private void 运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            if (Task.curTask == null)
                return;

            if (Task.curTask.L_toolList.Count == 0)
                return;

            Task.curTask.FindToolByName(C_toolList.SelectedNode.Text).Run();
            if (Task.curTask.FindToolByName(C_toolList.SelectedNode.Text).enable)
            {
                if (Task.curTask.FindToolByName(C_toolList.SelectedNode.Text).toolRunStatu == "运行成功")
                    C_toolList.SetNodeTipsText(C_toolList.SelectedNode, " ", Color.Green, Color.Green);
                else
                    C_toolList.SetNodeTipsText(C_toolList.SelectedNode, " ", Color.Red, Color.Red);
            }
            else
            {
                C_toolList.SetNodeTipsText(C_toolList.SelectedNode, " ", Color.LightGray, Color.LightGray);
            }
        }
        private void 终端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            Frm_ToolIO.Instance.cbx_toolList.Items.Clear();
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                Frm_ToolIO.Instance.cbx_toolList.Items.Add(Task.curTask.L_toolList[i].toolName);
            }
            if (Frm_ToolIO.Instance.cbx_toolList.Items.Count > 0)
                Frm_ToolIO.Instance.cbx_toolList.SelectedIndex = C_toolList.SelectedNode.Index;

            Frm_ToolIO.toolBase = Task.curTask.L_toolList[C_toolList.SelectedNode.Index];
            Frm_ToolIO.Instance.LoadPar();
            Frm_ToolIO.Instance.Show();
        }
        private void 禁用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            if (Task.curTask == null)
                return;

            if (Task.curTask.L_toolList.Count == 0)
                return;

            Task.curTask.FindToolByName(C_toolList.SelectedNode.Text).enable = !Task.curTask.FindToolByName(C_toolList.SelectedNode.Text).enable;
            if (!Task.curTask.FindToolByName(C_toolList.SelectedNode.Text).enable)      //禁用状态显示深灰色
            {
                C_toolList.SetNodeTipsText(C_toolList.SelectedNode, "    ×", Color.FromArgb(240, 240, 240), Color.DarkGray);
            }
            else        //启用状态显示最后一次运行的结果状态
            {
                if (Task.curTask.FindToolByName(C_toolList.SelectedNode.Text).toolRunStatu == "运行成功")
                    C_toolList.SetNodeTipsText(C_toolList.SelectedNode, Task.FormatTime(Task.curTask.L_toolList[C_toolList.SelectedNode.Index].elapsedTime), Color.FromArgb(240, 240, 240), Color.Green);
                else
                    C_toolList.SetNodeTipsText(C_toolList.SelectedNode, "    ×", Color.FromArgb(240, 240, 240), Color.Red);
            }
        }
        private void 禁用全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            if (Task.curTask == null)
                return;

            if (Task.curTask.L_toolList.Count == 0)
                return;

            if (isIgnoredAll)
            {
                isIgnoredAll = false;
                for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
                {
                    Task.curTask.L_toolList[i].enable = true;
                    if (Task.curTask.L_toolList[i].toolRunStatu == "运行成功")
                        C_toolList.SetNodeTipsText(C_toolList.Nodes[i], " ", Color.Green, Color.Green);
                    else
                        C_toolList.SetNodeTipsText(C_toolList.Nodes[i], " ", Color.Red, Color.Red);
                }
            }
            else
            {
                isIgnoredAll = true;
                for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
                {
                    Task.curTask.L_toolList[i].enable = false;
                    C_toolList.SetNodeTipsText(C_toolList.Nodes[i], " ", Color.LightGray, Color.LightGray);
                }
            }
        }
        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            ToolBase.Copy(C_toolList);
        }
        private void 粘贴插入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            ToolBase.Paste(C_toolList);
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            ToolBase.Delete(C_toolList);
        }
        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            ToolBase.Rename(C_toolList);
        }
        private void 隐藏页面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (splitContainer2.Panel1Collapsed)
                Frm_Vision.Instance.splitContainer1.Panel1Collapsed = true;
            else
                splitContainer2.Panel2Collapsed = true;
        }

        private void C_taskList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Task.Switch(C_taskList.SelectedNode.Text);

            //switch (Scheme.curScheme.name)
            //{
            //    case "胶框 左侧Mark":
            //        btn_manualInBoard.Visible = true;
            //        button1.Visible = true;
            //        break;

            //    case "胶框 右侧Mark":
            //        btn_manualInBoard.Visible = true;
            //        button1.Visible = true;
            //        break;

            //    case "玻璃片 左侧Mark":
            //        btn_manualInBoard.Visible = true;
            //        button1.Visible = true;
            //        break;

            //    case "玻璃片 右侧Mark":
            //        btn_manualInBoard.Visible = true;
            //        button1.Visible = true;
            //        break;

            //    case "对位贴合":
            //        btn_manualInBoard.Visible = false;
            //        button1.Visible = false;
            //        break;
            //}
        }
        private void C_toolBox_DoubleClick(object sender, EventArgs e)
        {
            if (C_toolBox.SelectedNode.Level == 0)
                return;

            if (Task.curTask == null)
            {
                FuncLib.ShowMessageBox("当前未添加任何任务，请先新建任务");

                //新建任务
                if (Task.Create())
                    return;
            }

            if (Task.curTask.isRunning)
            {
                FuncLib.ShowMessageBox("当前任务正在运行，请停止后添加");
                return;
            }

            //此处注意，因为枚举类型中不能有空格，所以下面两行代码转枚举前先替换掉空格，然后再替换回空格
            ToolType toolType = (ToolType)Enum.Parse(typeof(ToolType), C_toolBox.SelectedNode.Text.Replace(" ", "_"));  //1.拿到工具类型
            string toolName = Task.curTask.CreateNewToolName(toolType); //1.此处根据实际的情况，生成一个默认的工具名称

            ToolBase toolBase = null;
            switch (toolType)
            {
                case ToolType.采集图像:
                    toolBase = new ImageTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.存储图像:
                    toolBase = new SaveImageTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.模板匹配:
                    toolBase = new MatchTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.引用标定:
                    toolBase = new CoordTransTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.顶部定位:
                    toolBase = new UpCamAlignTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.对位贴合二:
                    toolBase = new DownCamAlignTool2(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.码类识别:
                    toolBase = new IDTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.字符识别:
                    toolBase = new OCRTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.胶路检测:
                    toolBase = new GlueDetectTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.查找直线:
                    toolBase = new FindLineTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.查找圆形:
                    toolBase = new FindCircleTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.线线交点:
                    toolBase = new LLIntersectTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.以太网发:
                    toolBase = new NetworkSendTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.光源控制:
                    toolBase = new LightTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.外部输出:
                    toolBase = new OutTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.推理识别:
                    toolBase = new InferenceTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.自定义处理:
                    toolBase = new DefineTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.创建区域:
                    toolBase = new CreateRoiTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.图像预处理:
                    toolBase = new PreconditionTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.模型训练:
                    toolBase = new TrainModelTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.南昌CT:
                    toolBase = new NanChangCTTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.生产计数:
                    toolBase = new CapacityCount(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.图像脚本:
                    toolBase = new ImageEngineTool(toolName, Task.curTask.name, toolType);
                    break;
                case ToolType.相机IO输出:
                    toolBase = new CameraIOOut(toolName, Task.curTask.name, toolType);
                    break;
                default:
                    FuncLib.ShowMessageBox("尚未开发，敬请期待！");
                    return;
            }
            Task.curTask.L_toolList.Add(toolBase);
            TreeNode treeNode = C_toolList.Nodes.Add(toolName);

            //滚动至最后一个工具
            C_toolList.SelectedNode = treeNode;
        }

        internal void btn_runOnce_Click(object sender, EventArgs e)
        {
            //if (!Permission.CheckPermission(PermissionGrade.Admin))
            //    return;


            if (Task.curTask == null)
                return;

            if (!isRunning)
            {
                Thread th = new Thread(() =>
                {
                    try
                    {
                        this.Invoke(new Action(() =>
                        {
                            Frm_Loading.Instance.lbl_title.Text = "拼命加载中";
                            Frm_Loading.Instance.TopLevel = true;
                            Frm_Loading.Instance.TopMost = true;
                            Frm_Loading.Instance.Show();
                        }));
                    }
                    catch (Exception)
                    {
                        Frm_Loading.Instance.lbl_title.Text = "拼命加载中";
                        Frm_Loading.Instance.TopLevel = true;
                        Frm_Loading.Instance.TopMost = true;
                        Frm_Loading.Instance.Show();
                    }

                    isRunning = true;
                    Task.curTask.Run();
                    isRunning = false;


                    Thread.Sleep(100);
                    Frm_Loading.Instance.Hide();
                    Application.DoEvents();

                });
                //th.Priority = ThreadPriority.Highest; 
                th.IsBackground = true;
                th.Start();
            }
        }


        private void C_taskList_DoubleClick(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                return;

            Task.curTask.Run();
            ////1.选择硬触发的话，执行一次设置为不允许操作状态
            //if (Task.curTask.taskTrigMode == TaskTrigMode.BasedCameraHardTrigger)   
            //{
            //    Frm_Task.Instance.btn_runOnce.Enabled = false;
            //}
            //else
            //{
            //Frm_Task.Instance.btn_runOnce.Enabled = true;

            //}
        }
        private void C_toolList_Click(object sender, EventArgs e)
        {
            firstClicked = true;
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
                return;

            Thread th = new Thread(() =>
            {
                Thread.Sleep(500);
                if (!firstClicked)
                    return;

                if (C_toolList.SelectedNode == null)
                    return;

                ToolBase toolBase = Task.curTask.L_toolList[C_toolList.SelectedNode.Index];
                switch (toolBase.toolType)
                {
                    case ToolType.采集图像:
                        ImageTool acqImageTool = (ImageTool)toolBase;
                        if (((ImageTool.ToolPar)acqImageTool.参数).输出.图像 != null)
                            Task.curTask.GetImageWindow().HobjectToHimage(((ImageTool.ToolPar)acqImageTool.参数).输出.图像);
                        break;
                    case ToolType.码类识别:
                        //刷新图像
                        if (Task.curTask.GetImageWindow().currentImage != null)
                            Task.curTask.GetImageWindow().HobjectToHimage(Task.curTask.GetImageWindow().currentImage);

                        IDTool idTool = (IDTool)toolBase;
                        //////Task.curTask.GetImageWindow().HobjectToHimage(((IDTool.ToolPar)idTool.参数).输出.图像);
                        break;
                    case ToolType.模板匹配:
                        //刷新图像
                        if (Task.curTask.GetImageWindow().currentImage != null)
                            Task.curTask.GetImageWindow().HobjectToHimage(Task.curTask.GetImageWindow().currentImage);

                        MatchTool matchTool = (MatchTool)toolBase;

                        if (matchTool.showTemplate)
                            Task.curTask.GetImageWindow().DispObj(matchTool.lastRunTemplate, "green");
                        if (matchTool.showCross)
                            Task.curTask.GetImageWindow().DispObj(matchTool.lastRunCross, "green");
                        //////if (matchTool.showIndex)
                        //////    HalconLib.DispText(Task.curTask.GetImageWindow().HWindowHalconID, matchTool.showScore ? string.Format("{0}  {1}", i + 1, L_result[i].Socre) : (i + 1).ToString(), 12, L_result[i].Row - firstTemplateCenter.X + row + 20, L_result[i].Col - firstTemplateCenter.Y + col + 20, "blue", "false");
                        break;
                }
            });
            th.IsBackground = true;
            th.Start();
        }
        private void C_toolList_DoubleClick(object sender, EventArgs e)
        {
            firstClicked = false;
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            switch (Task.curTask.L_toolList[C_toolList.SelectedNode.Index].toolType)
            {
                case ToolType.图像脚本:
                    Frm_ImageEngineTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.采集图像:
                    Frm_ImageTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.存储图像:
                    Frm_SaveImageTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.模板匹配:
                    Frm_MatchTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.引用标定:
                    Frm_CoordTransTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.顶部定位:
                    Frm_UpCamAlignTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.对位贴合二:
                    Frm_DownCamAlignTool2.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.码类识别:
                    Frm_IDTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.字符识别:
                    Frm_OCRTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.胶路检测:
                    Frm_GlueDetectTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.查找直线:
                    Frm_FindLineTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.查找圆形:
                    Frm_FindCircleTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.光源控制:
                    Frm_LightTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.以太网发:
                    Frm_NetworkSendTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.外部输出:
                    Frm_OutTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.推理识别:
                    Frm_Inference.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.自定义处理:
                    Frm_DefineTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.创建区域:
                    Frm_CreateRoi.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.图像预处理:
                    Frm_PreconditionTool.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.模型训练:
                    Frm_TrainModel.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                case ToolType.相机IO输出:
                    FrmCameraIoOut.ShowForm(Task.curTask.L_toolList[C_toolList.SelectedNode.Index]);
                    break;
                default:
                    FuncLib.ShowMessageBox("当前工具无参数界面");
                    break;
            }
        }

        private void C_toolBox_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //工具分类不可拖动
            if (C_toolBox.SelectedNode == null || C_toolBox.SelectedNode.Level == 0)
                return;

            if (e.Item is TreeNode && e.Button == MouseButtons.Left && e.Item != null && sender is TreeView)
            {
                TreeView treeView = sender as TreeView;
                TreeNode node = e.Item as TreeNode;
                int value = Convert.ToInt32(treeView.Tag);
                m_MoveTo = (MoveTreeView)value;
                m_DragNode = node;
                m_NodeSource = treeView;
                treeView.DoDragDrop(node, DragDropEffects.Move);
            }
        }
        private void C_toolBox_DragEnter(object sender, DragEventArgs e)
        {
            if (C_toolBox.SelectedNode.Level == 0)
                e.Effect = DragDropEffects.Move;
        }
        private void C_taskList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (((TreeView)sender).SelectedNode != null)
            {
                if (e.Button == MouseButtons.Left)
                    C_taskList.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }
        private void C_taskList_DragDrop(object sender, DragEventArgs e)
        {
            //如果是流程编辑拖过来的则直接返回
            TreeNode moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            if (C_toolList.Nodes.Contains(moveNode))
                return;

            //获得拖放中的节点  
            moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            //根据鼠标坐标确定要移动到的目标节点  
            System.Drawing.Point pt;
            TreeNode targeNode;
            pt = ((TreeView)(sender)).PointToClient(new System.Drawing.Point(e.X, e.Y));
            targeNode = C_taskList.GetNodeAt(pt);
            //如果目标节点无子节点则添加为同级节点,反之添加到下级节点的未端  

            if (moveNode == targeNode)       //若是把自己拖放到自己，不可，返回
                return;

            if (moveNode.Level == 0)        //被拖动的是子节点，也就是工具节点
            {
                TreeView treeView = sender as TreeView;
                MoveTreeView move = (MoveTreeView)Convert.ToInt32(treeView.Tag);
                System.Drawing.Point p = treeView.PointToClient(new System.Drawing.Point(e.X, e.Y));
                TreeNode node = treeView.GetNodeAt(p);

                if (p.Y > ((TreeView)sender).Nodes[((TreeView)sender).Nodes.Count - 1].Bounds.Y + ((TreeView)sender).Nodes[0].Bounds.Height)        //在尾部追加
                {
                    moveNode.Remove();
                    C_taskList.Nodes.Insert(Scheme.curScheme.L_taskList.Count, moveNode);

                    //移动工具
                    Task task;
                    for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
                    {
                        if (Scheme.curScheme.L_taskList[i].name == moveNode.Text)
                        {
                            task = Scheme.curScheme.L_taskList[i];
                            Scheme.curScheme.L_taskList.RemoveAt(i);
                            Scheme.curScheme.L_taskList.Insert(Scheme.curScheme.L_taskList.Count, task);
                            break;
                        }
                    }
                }
                else        //在中间插入
                {
                    moveNode.Remove();
                    C_taskList.Nodes.Insert(targeNode.Index, moveNode);

                    //移动工具
                    Task task;
                    for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
                    {
                        if (Scheme.curScheme.L_taskList[i].name == moveNode.Text)
                        {
                            task = Scheme.curScheme.L_taskList[i];
                            Scheme.curScheme.L_taskList.RemoveAt(i);
                            Scheme.curScheme.L_taskList.Insert(targeNode.Index - 1, task);
                            break;
                        }
                    }
                }
                C_taskList.SelectedNode = moveNode;     //选中被移动节点
            }
        }
        private void C_taskList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        private void C_taskList_MouseDown(object sender, MouseEventArgs e)
        {
            clickTaskPos.X = e.X;
            clickTaskPos.Y = e.Y;
        }
        private void C_toolList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            m_DragNode = null;
            if (((TreeView)sender).SelectedNode != null)
            {
                if (e.Button == MouseButtons.Left)
                    C_toolList.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }
        private void C_toolList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        private void C_toolList_DragDrop(object sender, DragEventArgs e)
        {
            //首先判断是不是从任务列表拖过来的，任务不可以被拖动到任务编辑，故直接返回
            TreeNode moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            if (C_taskList.Nodes.Contains(moveNode))
                return;

            //需要辨别是工具箱拖过来的，还是流程间内部拖拽，此处只要流程间一旦有拖动动作，就给DragNode变量赋null，所以此处通过判断ToolBox中的DragNode是否为null来判断属于哪种拖动
            if (m_DragNode != null && m_DragNode.Level != 0)
            {
                if (sender != null && sender is TreeView)
                {
                    TreeView treeView = sender as TreeView;
                    MoveTreeView move = (MoveTreeView)Convert.ToInt32(treeView.Tag);
                    System.Drawing.Point p = treeView.PointToClient(new System.Drawing.Point(e.X, e.Y));
                    TreeNode node = treeView.GetNodeAt(p);

                    ToolType toolType = (ToolType)Enum.Parse(typeof(ToolType), m_DragNode.Text.Replace(" ", "_"));
                    string toolName = Task.curTask.CreateNewToolName(toolType);

                    #region 1.修复因拖放工具类型对应不上更改部分，以及将新工具增加到流程中间出现的异常问题
                    //1.原先
                    //Task.curTask.L_toolList.Insert(Task.curTask.L_toolList.Count, new ImageTool(toolName, Task.curTask.name, toolType)); 
                    //////if (p.Y > ((TreeView)sender).Nodes[((TreeView)sender).Nodes.Count - 1].Bounds.Y + ((TreeView)sender).Nodes[0].Bounds.Height)        //在尾部追加
                    //////    C_toolList.Nodes.Insert(Task.curTask.L_toolList.Count, toolName);
                    //////else        //在中间插入
                    //////    C_toolList.Nodes.Insert(node.Index, toolName);
                    //////return;

                    //1.更改之后
                    ToolBase toolBase = null;
                    switch (toolType)
                    {
                        case ToolType.采集图像:
                            toolBase = new ImageTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.存储图像:
                            toolBase = new SaveImageTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.模板匹配:
                            toolBase = new MatchTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.引用标定:
                            toolBase = new CoordTransTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.顶部定位:
                            toolBase = new UpCamAlignTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.对位贴合二:
                            toolBase = new DownCamAlignTool2(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.码类识别:
                            toolBase = new IDTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.字符识别:
                            toolBase = new OCRTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.胶路检测:
                            toolBase = new GlueDetectTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.查找直线:
                            toolBase = new FindLineTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.查找圆形:
                            toolBase = new FindCircleTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.线线交点:
                            toolBase = new LLIntersectTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.以太网发:
                            toolBase = new NetworkSendTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.光源控制:
                            toolBase = new LightTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.外部输出:
                            toolBase = new OutTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.自定义处理:
                            toolBase = new DefineTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.创建区域:
                            toolBase = new CreateRoiTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.模型训练:
                            toolBase = new TrainModelTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.推理识别:
                            toolBase = new InferenceTool(toolName, Task.curTask.name, toolType);
                            break;
                        case ToolType.图像预处理:
                            toolBase = new PreconditionTool(toolName, Task.curTask.name, toolType);
                            break;
                        default:
                            FuncLib.ShowMessageBox("尚未开发，敬请期待！");
                            return;
                    }

                    //1.根据获取到的工具类型，以及放在流程当中的位置，将其加到对应的工具列表当中
                    if (p.Y > ((TreeView)sender).Nodes[((TreeView)sender).Nodes.Count - 1].Bounds.Y + ((TreeView)sender).Nodes[0].Bounds.Height)//在尾部追加
                    {
                        C_toolList.Nodes.Insert(Task.curTask.L_toolList.Count, toolName);
                        Task.curTask.L_toolList.Insert(Task.curTask.L_toolList.Count, toolBase);
                    }
                    else        //在中间插入
                    {
                        C_toolList.Nodes.Insert(node.Index, toolName);
                        Task.curTask.L_toolList.Insert(node.Index, toolBase);
                    }
                    return;

                    #endregion


                }
            }


            //获得被拖放的节点  
            moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            //根据鼠标坐标确定要移动到的目标节点  
            System.Drawing.Point pt;
            TreeNode targeNode;
            pt = ((TreeView)(sender)).PointToClient(new System.Drawing.Point(e.X, e.Y));
            targeNode = C_toolList.GetNodeAt(pt);

            if (targeNode == null)       //目标节点为null，就是把节点拖到了空白区域，则表示要把节点拖到末尾
            {
                moveNode.Remove();
                C_toolList.Nodes.Insert(Task.curTask.L_toolList.Count, moveNode);

                ToolBase toolBase = new ToolBase();
                for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
                {
                    if (Task.curTask.L_toolList[i].toolName == moveNode.Text)
                    {
                        toolBase = Task.curTask.L_toolList[i];
                        Task.curTask.L_toolList.RemoveAt(i);
                        Task.curTask.L_toolList.Insert(Task.curTask.L_toolList.Count, toolBase);
                        break;
                    }
                }
                //选中当前拖动的节点选择  
                C_toolList.SelectedNode = moveNode;
                return;
            }
            else
            {
                moveNode.Remove();
                C_toolList.Nodes.Insert(targeNode.Index, moveNode);

                ToolBase toolBase = new ToolBase();
                for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
                {
                    if (Task.curTask.L_toolList[i].toolName == moveNode.Text)
                    {
                        toolBase = Task.curTask.L_toolList[i];
                        Task.curTask.L_toolList.RemoveAt(i);
                        Task.curTask.L_toolList.Insert(targeNode.Index - 1, toolBase);
                        break;
                    }
                }
            }

            //选中当前拖动的节点
            C_toolList.SelectedNode = moveNode;
        }
        private void C_toolList_MouseDown(object sender, MouseEventArgs e)
        {
            clickToolPos.X = e.X;
            clickToolPos.Y = e.Y;
        }
        private void uiContextMenuStrip3_Paint(object sender, PaintEventArgs e)
        {
            if (C_toolList.SelectedNode != null)
            {
                if (Task.curTask.FindToolByName(C_toolList.SelectedNode.Text).enable)
                    禁用ToolStripMenuItem.Text = "禁用";
                else
                    禁用ToolStripMenuItem.Text = "启用";
            }

            if (!isIgnoredAll)
                禁用全部ToolStripMenuItem.Text = "禁用全部";
            else
                禁用全部ToolStripMenuItem.Text = "启用全部";
        }
        private void uiContextMenuStrip1_Paint(object sender, PaintEventArgs e)
        {
            if (C_toolBox.Parent == Frm_ToolBox.Instance)
                悬浮ToolStripMenuItem.Text = "嵌入";
            else
                悬浮ToolStripMenuItem.Text = "悬浮";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////实现把form1窗体谈弹出来
            //Form1.Instance.Show();
        }
    }
}
