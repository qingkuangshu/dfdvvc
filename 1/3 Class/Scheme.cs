using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using HalconDotNet;

namespace VM_Pro
{
    [Serializable]
    /// <summary>
    /// 方案
    /// </summary>
    internal class Scheme
    {
        internal Scheme(string schemeName)
        {
            this.name = schemeName;
        }

        /// <summary>
        /// 自动运行速度
        /// </summary>
        internal double workVelRate = 0.2;
        /// <summary>
        /// 方案名称
        /// </summary>
        internal string name = string.Empty;
        /// <summary>
        /// 当前方案
        /// </summary>
        internal static Scheme curScheme = null;
        /// <summary>
        /// 图像窗口画布
        /// </summary>
        internal WindowLayout windowLayout = WindowLayout.OneWindow;
        /// <summary>
        /// 页面尺寸
        /// </summary>
        internal int frm_vison_splitContainer1_splitterDistance = 516;
        /// <summary>
        /// 页面尺寸
        /// </summary>
        internal int frm_vison_splitContainer2_splitterDistance = 393;
        /// <summary>
        /// 页面尺寸
        /// </summary>
        internal int frm_task_splitContainer2_splitterDistance = 304;
        /// <summary>
        /// 页面尺寸
        /// </summary>
        internal int frm_task_splitContainer1_splitterDistance = 148;
        /// <summary>
        /// 任务集合
        /// </summary>
        internal List<Task> L_taskList = new List<Task>();
        /// <summary>
        /// 点位表
        /// </summary>
        internal SmartPosTable smartPosTable = new SmartPosTable();

        //[NonSerialized]
        ///// <summary>
        ///// Sn码的条码规则
        ///// </summary>
        //internal string SnCodeRule = string.Empty;
        //[NonSerialized]
        ///// <summary>
        ///// 是否启动校验SN码规则
        ///// </summary>
        //internal bool SnCheackEnable = false;



        /// <summary>
        /// 命名查重
        /// </summary>
        /// <param name="jobName">方案名</param>
        /// <returns>是否已存在</returns>
        internal static bool CheckSchemeExist(string schemeName)
        {
            for (int i = 0; i < Project.L_schemeList.Count; i++)
            {
                if (Project.L_schemeList[i].name == schemeName)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 新建
        /// </summary>
        internal static void Create()
        {
        //输入新的方案名称
        Again:
            string schemeName = FuncLib.ShowInput("请输入新方案名");
            if (schemeName == string.Empty)
                return;

            //命名查重
            if (CheckSchemeExist(schemeName))
            {
                FuncLib.ShowMessageBox("已存在此名称的方案，方案名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            // 特殊字符检查
            if (schemeName.Contains(@"\"))
            {
                FuncLib.ShowMessageBox("方案名中不能含有 \\ 特殊字符 ，请重新输入", InfoType.Error);
                goto Again;
            }

            Scheme scheme = new Scheme(schemeName);
            Project.L_schemeList.Add(scheme);
            Project.Instance.L_schemeName.Add(schemeName);
            Frm_Scheme.Instance.tvw_schemeList.Nodes.Add(new TreeNode(schemeName));
            Frm_Main.Instance.cbx_schemeList.Items.Add(schemeName);
            FuncLib.ShowMsg(string.Format("方案已新建，新方案名：{0}", schemeName), InfoType.Tip);

            //保存所有方案
            SaveAll();
        }
        /// <summary>
        /// 切换
        /// </summary>
        internal static void Switch(string schemeName)
        {
            Frm_Loading.Instance.lbl_title.Text = "拼命切换中";
            Frm_Loading.Instance.TopLevel = true;
            Frm_Loading.Instance.TopMost = true;

            Thread th = new Thread(() =>
            {
                Application.DoEvents();
                Scheme.DeleteSchemeNeiCun(curScheme);
                //清除工具栏
                Frm_Task.Instance.C_toolList.Nodes.Clear();
                Scheme oldSchemeName = curScheme;
                //切换方案
                for (int i = 0; i < Project.L_schemeList.Count; i++)
                {
                    if (Project.L_schemeList[i].name == schemeName)
                    {
                        curScheme = Project.L_schemeList[i];
                        Project.Instance.configuration.curSchemeName = curScheme.name;
                        break;
                    }
                }

                if (curScheme.name != "直通方案")
                {
                    for (int i = 0; i < curScheme.L_taskList.Count; i++)
                    {
                        Task.curTask = curScheme.L_taskList[i]; //新增，不然会在方案空任务中切换方案中有任务的时候出现当前任务异常
                        curScheme.L_taskList[i].Run(true);
                    }
                }

                Frm_Main.Instance.Invoke(new Action(() =>
                {
                    //刷新界面
                    Frm_Task.Instance.C_taskList.Nodes.Clear();
                    for (int i = 0; i < curScheme.L_taskList.Count; i++)
                    {
                        //添加工具节点
                        TreeNode treeNode = Frm_Task.Instance.C_taskList.Nodes.Add(curScheme.L_taskList[i].name);
                    }

                    //选中第一个节点
                    if (curScheme.L_taskList.Count > 0)
                    {
                        Frm_Task.Instance.C_taskList.SelectedNode = Frm_Task.Instance.C_taskList.Nodes[0];
                    }

                }));
                
                //更新图像窗口布局
                Frm_Vision.UpdateWindowLayout();

                //清空所有窗口图像
                Frm_Vision.Instance.hWindow_Final1.ClearWindow();
                Frm_Vision.Instance.hWindow_Final2.ClearWindow();
                Frm_Vision.Instance.hWindow_Final3.ClearWindow();
                Frm_Vision.Instance.hWindow_Final4.ClearWindow();
                Frm_Vision.Instance.hWindow_Final5.ClearWindow();
                Frm_Vision.Instance.hWindow_Final6.ClearWindow();
                Frm_Vision.Instance.hWindow_Final7.ClearWindow();
                Frm_Vision.Instance.hWindow_Final8.ClearWindow();
                Frm_Vision.Instance.hWindow_Final9.ClearWindow();

                //更新窗体布局
                Frm_Vision.Instance.splitContainer1.SplitterDistance = Scheme.curScheme.frm_vison_splitContainer1_splitterDistance;
                Frm_Task.Instance.splitContainer1.SplitterDistance = Scheme.curScheme.frm_task_splitContainer1_splitterDistance;
                Frm_Vision.Instance.splitContainer2.SplitterDistance = Scheme.curScheme.frm_vison_splitContainer2_splitterDistance;
                Frm_Task.Instance.splitContainer2.SplitterDistance = Scheme.curScheme.frm_task_splitContainer2_splitterDistance;

                //更新点位数据
                Scheme.curScheme.smartPosTable.LoadData(Frm_Motion.Instance.dgv_pointList, Frm_Motion.Instance.cbx_tableList.Text);

                Frm_Loading.Instance.Hide();
            });
            th.IsBackground = true;
            th.Start();
            Frm_Loading.Instance.ShowDialog();
        }
        /// <summary>
        /// 复制
        /// </summary>
        internal static void Copy()
        {
        //输入新的方案名称
        Again:
            string newSchemeName = FuncLib.ShowInput("请输入新方案名");
            if (newSchemeName == string.Empty)
                return;

            //命名查重
            if (CheckSchemeExist(newSchemeName))
            {
                FuncLib.ShowMessageBox("已存在此名称的方案，方案名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            // 特殊字符检查
            if (newSchemeName.Contains(@"\") || newSchemeName.Contains(@"/"))
            {
                FuncLib.ShowMessageBox("方案名中不能含有 \\ / 等特殊字符 ，请重新输入", InfoType.Error);
                goto Again;
            }

            //在主页面的方案栏中添加
            Frm_Main.Instance.cbx_schemeList.Items.Add(newSchemeName);

            //修改方案名
            for (int i = 0; i < Project.L_schemeList.Count; i++)
            {
                if (Project.L_schemeList[i].name == Frm_Scheme.Instance.tvw_schemeList.SelectedNode.Text)
                {
                    Scheme scheme = ToolBase.Clone(Project.L_schemeList[i]);
                    scheme.name = newSchemeName;

                    Project.L_schemeList.Add(scheme);
                    Project.Instance.L_schemeName.Add(newSchemeName);
                    Frm_Scheme.Instance.tvw_schemeList.Nodes.Add(new TreeNode(newSchemeName));
                    FuncLib.ShowMsg(string.Format("方案已复制，新方案名：{0}", newSchemeName), InfoType.Tip);
                    break;
                }
            }
            Frm_Scheme.Instance.tbx_schemeName.Text = newSchemeName;
            Frm_Main.Instance.cbx_schemeList.Text = newSchemeName;
            Scheme.Switch(newSchemeName);

            Project.SaveSysPar();

            Thread th = new Thread(() =>
            {
                //保存所有方案
                SaveCur();
            });
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 加载当前
        /// </summary>
        internal static void LoadCur()
        {
            //指定当前任务
            if (curScheme.L_taskList.Count > 0)
                Task.Switch(curScheme.L_taskList[0].name);

            //运行一遍各任务并添加到显示列表
            Frm_Task.Instance.C_taskList.Nodes.Clear();
            for (int i = 0; i < curScheme.L_taskList.Count; i++)
            {
                TreeNode treeNode = Frm_Task.Instance.C_taskList.Nodes.Add(curScheme.L_taskList[i].name);
                treeNode.Tag = "";
                Frm_Task.Instance.btn_runOnce.Enabled = false;
                curScheme.L_taskList[i].Run(true);
                Frm_Task.Instance.btn_runOnce.Enabled = true;   //此操作目的是防止初始化时某个工具占时较长，导致后续的工具还没有进行初始化，而人为去点击

            }
            Frm_Task.Instance.C_taskList.SelectedNode = Frm_Task.Instance.C_taskList.Nodes[0];

            //显示信息
            Frm_Main.Instance.Text = string.Format("{0}_{1}", Project.Instance.configuration.companyName, Project.Instance.configuration.projectName);
            Frm_Main.Instance.cbx_schemeList.Text = curScheme.name;
        }
        /// <summary>
        /// 加载指定
        /// </summary>
        internal static void Load(string schemePath)
        {
            //如果本地有方案文件就反序列化，如果没有没有文件那就直接new一个
            if (File.Exists(schemePath))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(string.Format(schemePath), FileMode.Open, FileAccess.Read, FileShare.None);
                try
                {
                    curScheme = (Scheme)formatter.Deserialize(stream);
                    stream.Close();
                }
                catch      //如果反序列化失败，要释放流，否则文件会被占用
                {
                    stream.Close();
                    FuncLib.ShowMessageBox("加载当前方案失败", InfoType.Error);
                }
            }
            else
            {
                curScheme = new Scheme("示例方案");
                Project.L_schemeList.Add(curScheme);
                Frm_Main.Instance.cbx_schemeList.Items.Add(curScheme.name);
                Project.Instance.L_schemeName.Add(curScheme.name);
            }

            //指定当前任务
            if (curScheme.L_taskList.Count > 0)
                Task.Switch(curScheme.L_taskList[0].name);

            //运行一遍各任务并添加到显示列表
            Thread th = new Thread(() =>
            {
                Frm_Task.Instance.C_taskList.Nodes.Clear();
                for (int i = 0; i < curScheme.L_taskList.Count; i++)
                {
                    Frm_Welcome.Instance.Invoke(new Action(() =>
                    {
                        TreeNode treeNode = Frm_Task.Instance.C_taskList.Nodes.Add(curScheme.L_taskList[i].name);
                        treeNode.Tag = "";
                    }));
                    curScheme.L_taskList[i].Run(true);
                }
            });
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 保存当前
        /// </summary
        internal static void SaveCur()
        {
            //清除相关图像，减小体积
            Scheme temp = ToolBase.Clone(curScheme);

            for (int i = 0; i < temp.L_taskList.Count; i++)
            {
                for (int j = 0; j < temp.L_taskList[i].L_toolList.Count; j++)
                {
                    temp.L_taskList[i].L_toolList[j].参数 = null;
                    switch (temp.L_taskList[i].L_toolList[j].toolType)
                    {
                        case ToolType.模板匹配:
                            ((MatchTool)temp.L_taskList[i].L_toolList[j]).lastRunCross = null;
                            ((MatchTool)temp.L_taskList[i].L_toolList[j]).lastRunTemplate = null;
                            break;
                        case ToolType.码类识别:
                            ((IDTool)temp.L_taskList[i].L_toolList[j]).L_result = new List<CodeResult>();
                            break;
                        case ToolType.胶路检测:
                            ((GlueDetectTool)temp.L_taskList[i].L_toolList[j]).searchRegionAfterTransed = null;
                            break;
                    }
                }
            }

            //序列化项目
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Format(Application.StartupPath + "\\Temp.shm"), FileMode.OpenOrCreate, FileAccess.Write, FileShare.Delete);
            try
            {
                formatter.Serialize(stream, temp);
                stream.Close();

                //删除项目
                if (File.Exists(string.Format("{0}\\Config\\Project\\Scheme\\{1}.shm", Application.StartupPath, temp.name)))
                {
                    File.SetAttributes(string.Format("{0}\\Config\\Project\\Scheme\\{1}.shm", Application.StartupPath, temp.name), FileAttributes.Normal);
                    new FileInfo(string.Format("{0}\\Config\\Project\\Scheme\\{1}.shm", Application.StartupPath, temp.name)).Attributes = FileAttributes.Normal;
                    File.Delete(string.Format("{0}\\Config\\Project\\Scheme\\{1}.shm", Application.StartupPath, temp.name));
                }


                //移动项目
                File.Move(Application.StartupPath + "\\Temp.shm", string.Format(Application.StartupPath + "\\Config\\Project\\Scheme\\{0}.shm", temp.name));
            }
            catch
            {
                stream.Close();
                FuncLib.ShowMessageBox("保存失败！原因：未知", InfoType.Error);
            }
        }
        /// <summary>
        /// 保存所有
        /// </summary>
        internal static void SaveAll()
        {
            for (int i = 0; i < Project.L_schemeList.Count; i++)
            {
                Scheme tempScheme = ToolBase.Clone(Project.L_schemeList[i]);
                //清除相关图像，减小体积
                for (int j = 0; j < tempScheme.L_taskList.Count; j++)
                {
                    for (int k = 0; k < tempScheme.L_taskList[j].L_toolList.Count; k++)
                    {
                        tempScheme.L_taskList[j].L_toolList[k].参数 = null;
                        switch (tempScheme.L_taskList[j].L_toolList[k].toolType)
                        {
                            case ToolType.码类识别:
                                ((IDTool)tempScheme.L_taskList[j].L_toolList[k]).L_result = new List<CodeResult>();
                                break;
                            case ToolType.胶路检测:
                                ((GlueDetectTool)tempScheme.L_taskList[j].L_toolList[k]).searchRegionAfterTransed = null;
                                break;
                        }
                    }
                }

                //序列化方案
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(string.Format(Application.StartupPath + "\\Temp.shm"), FileMode.OpenOrCreate, FileAccess.Write, FileShare.Delete);
                try
                {
                    formatter.Serialize(stream, tempScheme);
                    stream.Close();

                    //删除方案
                    if (File.Exists(string.Format("{0}\\Config\\Project\\Scheme\\{1}.shm", Application.StartupPath, tempScheme.name)))
                    {
                        File.SetAttributes(string.Format("{0}\\Config\\Project\\Scheme\\{1}.shm", Application.StartupPath, tempScheme.name), FileAttributes.Normal);
                        new FileInfo(string.Format("{0}\\Config\\Project\\Scheme\\{1}.shm", Application.StartupPath, tempScheme.name)).Attributes = FileAttributes.Normal;
                        File.Delete(string.Format("{0}\\Config\\Project\\Scheme\\{1}.shm", Application.StartupPath, tempScheme.name));
                    }

                    //移动方案
                    File.Move(Application.StartupPath + "\\Temp.shm", string.Format(Application.StartupPath + "\\Config\\Project\\Scheme\\{0}.shm", tempScheme.name));
                }
                catch
                {
                    stream.Close();
                    FuncLib.ShowMessageBox("保存！原因：未知", InfoType.Error);
                }
            }
        }
        /// <summary>
        /// 导入
        /// </summary>
        internal static void Inport()
        {
            System.Windows.Forms.OpenFileDialog dig_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            dig_openFileDialog.Title = "请选择方案文件";
            dig_openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            dig_openFileDialog.Filter = "方案文件(*.shm)|*.shm";
            if (dig_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(dig_openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                Scheme scheme = (Scheme)formatter.Deserialize(stream);
                stream.Close();

                //命名查重
                if (CheckSchemeExist(scheme.name))
                {
                    if (FuncLib.ShowConfirmDialog("导入失败，方案列表中已经存在和当前方案重名的方案，点击\"是\"则重新命名当前方案，点击\"否\"则放弃导入", InfoType.Error) == DialogResult.OK)
                    {
                    //重命名
                    //输入新的方案名称
                    Again:
                        string newSchemeName = FuncLib.ShowInput("请输入新方案名");
                        if (newSchemeName == string.Empty)
                            return;

                        //命名查重
                        if (CheckSchemeExist(newSchemeName))
                        {
                            FuncLib.ShowMessageBox("已存在此名称的方案，方案名不可重复，请重新输入", InfoType.Error);
                            goto Again;
                        }

                        // 特殊字符检查
                        if (newSchemeName.Contains(@"\"))
                        {
                            FuncLib.ShowMessageBox("方案名中不能含有 \\ 特殊字符 ，请重新输入", InfoType.Error);
                            goto Again;
                        }

                        scheme.name = newSchemeName;
                        Project.L_schemeList.Add(scheme);
                        Switch(newSchemeName);

                        Frm_Main.Instance.cbx_schemeList.Items.Add(curScheme.name);
                        Frm_Main.Instance.cbx_schemeList.Text = curScheme.name;
                        TreeNode treeNode = Frm_Scheme.Instance.tvw_schemeList.Nodes.Add(curScheme.name);

                        Frm_Scheme.Instance.tvw_schemeList.SelectedNode = treeNode;
                        FuncLib.ShowMsg("方导入案成功", InfoType.Tip);
                    }
                    else
                    {
                        //放弃导入
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// 导出
        /// </summary>
        internal static void Export()
        {
            System.Windows.Forms.SaveFileDialog dig_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            dig_saveFileDialog.FileName = Frm_Scheme.Instance.tvw_schemeList.SelectedNode.Text;
            dig_saveFileDialog.Title = "请选择方案保存路径";
            dig_saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            dig_saveFileDialog.Filter = "方案文件(*.shm)|*.shm";
            if (dig_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < Project.L_schemeList.Count; i++)
                {
                    if (Project.L_schemeList[i].name == Frm_Scheme.Instance.tvw_schemeList.SelectedNode.Text)
                    {
                        IFormatter formatter = new BinaryFormatter();
                        Stream stream = new FileStream(dig_saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                        formatter.Serialize(stream, Project.L_schemeList[i]);
                        stream.Close();

                        FuncLib.ShowMsg("导出方案成功", InfoType.Tip);
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// 上移
        /// </summary>
        internal static void MoveUp()
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (Frm_Scheme.Instance.tvw_schemeList.SelectedNode.Index == 0)
                return;

            string schemeName = Frm_Scheme.Instance.tvw_schemeList.SelectedNode.Text;
            for (int i = 0; i < Project.L_schemeList.Count; i++)
            {
                if (Project.L_schemeList[i].name == schemeName)
                {
                    var scheme = Project.L_schemeList[i];
                    Project.L_schemeList.RemoveAt(i);
                    Project.L_schemeList.Insert(i - 1, scheme);

                    var treeNode = Frm_Scheme.Instance.tvw_schemeList.SelectedNode;
                    Frm_Scheme.Instance.tvw_schemeList.Nodes.Remove(treeNode);
                    Frm_Scheme.Instance.tvw_schemeList.Nodes.Insert(i - 1, treeNode);

                    var item = Frm_Main.Instance.cbx_schemeList.Items[i];
                    Frm_Main.Instance.cbx_schemeList.Items.RemoveAt(i);
                    Frm_Main.Instance.cbx_schemeList.Items.Insert(i - 1, item);

                    var name = Project.Instance.L_schemeName[i];
                    Project.Instance.L_schemeName.RemoveAt(i);
                    Project.Instance.L_schemeName.Insert(i - 1, name);

                    Frm_Scheme.Instance.tvw_schemeList.SelectedNode = treeNode;
                    FuncLib.ShowMsg(string.Format("方案 {0} 上移成功", schemeName), InfoType.Tip);
                    break;
                }
            }
        }
        /// <summary>
        /// 下移
        /// </summary>
        internal static void MoveDown()
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (Frm_Scheme.Instance.tvw_schemeList.SelectedNode.Index == Frm_Scheme.Instance.tvw_schemeList.Nodes.Count - 1)
                return;

            string schemeName = Frm_Scheme.Instance.tvw_schemeList.SelectedNode.Text;
            for (int i = 0; i < Project.L_schemeList.Count; i++)
            {
                if (Project.L_schemeList[i].name == schemeName)
                {
                    var scheme = Project.L_schemeList[i];
                    Project.L_schemeList.RemoveAt(i);
                    Project.L_schemeList.Insert(i + 1, scheme);

                    var treeNode = Frm_Scheme.Instance.tvw_schemeList.SelectedNode;
                    Frm_Scheme.Instance.tvw_schemeList.Nodes.Remove(treeNode);
                    Frm_Scheme.Instance.tvw_schemeList.Nodes.Insert(i + 1, treeNode);

                    var item = Frm_Main.Instance.cbx_schemeList.Items[i];
                    Frm_Main.Instance.cbx_schemeList.Items.RemoveAt(i);
                    Frm_Main.Instance.cbx_schemeList.Items.Insert(i + 1, item);

                    var name = Project.Instance.L_schemeName[i];
                    Project.Instance.L_schemeName.RemoveAt(i);
                    Project.Instance.L_schemeName.Insert(i + 1, name);

                    Frm_Scheme.Instance.tvw_schemeList.SelectedNode = treeNode;
                    FuncLib.ShowMsg(string.Format("方案 {0} 上移成功", schemeName), InfoType.Tip);
                    break;
                }
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        internal static void Delete()
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            if (Project.L_schemeList.Count == 1)
            {
                FuncLib.ShowMessageBox("删除失败，方案不可全部删除，应至少保留一个", InfoType.Error);
                return;
            }

            string schemeName = Frm_Scheme.Instance.tvw_schemeList.SelectedNode.Text;
            int nodeIndex = 0;
            if (FuncLib.ShowConfirmDialog(string.Format("确定要删除方案 {0} 吗？", schemeName), InfoType.Warn) == DialogResult.OK)
            {
                if (File.Exists(string.Format(Application.StartupPath + "\\Config\\Project\\Scheme\\{0}.shm", schemeName)))
                    File.Delete(string.Format(Application.StartupPath + "\\Config\\Project\\Scheme\\{0}.shm", schemeName));
                if (Project.Instance.L_schemeName.Contains(schemeName))
                    Project.Instance.L_schemeName.Remove(schemeName);

                Frm_Scheme.Instance.tvw_schemeList.Nodes.Remove(Frm_Scheme.Instance.tvw_schemeList.SelectedNode);

                for (int i = 0; i < Project.L_schemeList.Count; i++)
                {
                    if (Project.L_schemeList[i].name == schemeName)
                    {
                        Frm_Main.Instance.cbx_schemeList.Items.RemoveAt(i);
                        Project.L_schemeList.RemoveAt(i);
                        nodeIndex = i;
                        break;
                    }
                }
                FuncLib.ShowMsg(string.Format("方案 {0} 删除成功", schemeName), InfoType.Tip);

                //选中上一个方案
                if (Project.L_schemeList.Count > 0)
                {
                    Frm_Main.Instance.cbx_schemeList.SelectedIndex = Project.L_schemeList.Count - 1;
                    Frm_Scheme.Instance.tvw_schemeList.SelectedNode = Frm_Scheme.Instance.tvw_schemeList.Nodes[nodeIndex == 0 ? 0 : nodeIndex - 1];
                    Frm_Scheme.Instance.tbx_schemeName.Text = Frm_Scheme.Instance.tvw_schemeList.SelectedNode.Text;
                }
            }
        }

        /// <summary>
        /// 清空具体方案下所占的内存
        /// </summary>
        internal static void DeleteSchemeNeiCun(Scheme ClearScheme)
        {
            for (int i = 0; i < ClearScheme.L_taskList.Count; i++)
            {
                for (int j = 0; j < ClearScheme.L_taskList[i].L_toolList.Count; j++)
                {
                    switch (ClearScheme.L_taskList[i].L_toolList[j].toolType)
                    {
                        case ToolType.推理识别:
                            HOperatorSet.ClearDlModel(((InferenceTool)ClearScheme.L_taskList[i].L_toolList[j]).XunLianHandle);
                            break;
                        case ToolType.自定义处理:
                            break;
                        case ToolType.图像预处理:
                            break;
                        default:
                            break;
                    }
                }
            }

        }

    }
}
