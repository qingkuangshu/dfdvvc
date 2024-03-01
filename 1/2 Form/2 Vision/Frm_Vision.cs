using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChoiceTech.Halcon.Control;
using System.IO;
using HalconDotNet;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace VM_Pro
{
    public partial class Frm_Vision : UIPage
    {
        public Frm_Vision()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 连续运行所有流程
        /// </summary>
        private bool loopRun = false;
        /// <summary>
        /// 当前窗体类型      0：任务    1：生产    2：统计
        /// </summary>
        internal static int curForm = 0;
        /// <summary>
        /// 当前窗体    True：信息输出窗体     False：工具输出窗体
        /// </summary>
        private bool curMsgForm = true;
        /// <summary>
        /// 虚拟键盘进程
        /// </summary>
        internal static Process processKeyBoard;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Vision _instance;
        internal static Frm_Vision Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Vision();
                return _instance;
            }
        }


        /// <summary>
        /// 更新图像窗口布局
        /// </summary>
        internal static void UpdateWindowLayout()
        {
            switch (Scheme.curScheme.windowLayout)
            {
                case WindowLayout.OneWindow:
                    Frm_Vision.Instance.tableLayoutPanel2.RowCount = 1;
                    Frm_Vision.Instance.tableLayoutPanel2.ColumnCount = 1;

                    Frm_Vision.Instance.hWindow_Final1.Visible = true;
                    Frm_Vision.Instance.hWindow_Final2.Visible = false;
                    Frm_Vision.Instance.hWindow_Final3.Visible = false;
                    Frm_Vision.Instance.hWindow_Final4.Visible = false;
                    Frm_Vision.Instance.hWindow_Final5.Visible = false;
                    Frm_Vision.Instance.hWindow_Final6.Visible = false;
                    Frm_Vision.Instance.hWindow_Final7.Visible = false;
                    Frm_Vision.Instance.hWindow_Final8.Visible = false;
                    Frm_Vision.Instance.hWindow_Final9.Visible = false;
                    Frm_Vision.Instance.hWindow_Final10.Visible = false;
                    Frm_Vision.Instance.hWindow_Final11.Visible = false;
                    Frm_Vision.Instance.hWindow_Final12.Visible = false;
                    Frm_Vision.Instance.hWindow_Final13.Visible = false;
                    Frm_Vision.Instance.hWindow_Final14.Visible = false;
                    Frm_Vision.Instance.hWindow_Final15.Visible = false;
                    Frm_Vision.Instance.hWindow_Final16.Visible = false;

                    break;
                case WindowLayout.TwoWindow:
                    Frm_Vision.Instance.tableLayoutPanel2.RowCount = 1;
                    Frm_Vision.Instance.tableLayoutPanel2.ColumnCount = 2;

                    Frm_Vision.Instance.hWindow_Final1.Visible = true;
                    Frm_Vision.Instance.hWindow_Final2.Visible = true;
                    Frm_Vision.Instance.hWindow_Final3.Visible = false;
                    Frm_Vision.Instance.hWindow_Final4.Visible = false;
                    Frm_Vision.Instance.hWindow_Final5.Visible = false;
                    Frm_Vision.Instance.hWindow_Final6.Visible = false;
                    Frm_Vision.Instance.hWindow_Final7.Visible = false;
                    Frm_Vision.Instance.hWindow_Final8.Visible = false;
                    Frm_Vision.Instance.hWindow_Final9.Visible = false;
                    Frm_Vision.Instance.hWindow_Final10.Visible = false;
                    Frm_Vision.Instance.hWindow_Final11.Visible = false;
                    Frm_Vision.Instance.hWindow_Final12.Visible = false;
                    Frm_Vision.Instance.hWindow_Final13.Visible = false;
                    Frm_Vision.Instance.hWindow_Final14.Visible = false;
                    Frm_Vision.Instance.hWindow_Final15.Visible = false;
                    Frm_Vision.Instance.hWindow_Final16.Visible = false;

                    break;
                case WindowLayout.ForeWindow:
                    Frm_Vision.Instance.tableLayoutPanel2.RowCount = 2;
                    Frm_Vision.Instance.tableLayoutPanel2.ColumnCount = 2;

                    Frm_Vision.Instance.hWindow_Final1.Visible = true;
                    Frm_Vision.Instance.hWindow_Final2.Visible = true;
                    Frm_Vision.Instance.hWindow_Final3.Visible = true;
                    Frm_Vision.Instance.hWindow_Final4.Visible = true;
                    Frm_Vision.Instance.hWindow_Final5.Visible = false;
                    Frm_Vision.Instance.hWindow_Final6.Visible = false;
                    Frm_Vision.Instance.hWindow_Final7.Visible = false;
                    Frm_Vision.Instance.hWindow_Final8.Visible = false;
                    Frm_Vision.Instance.hWindow_Final9.Visible = false;
                    Frm_Vision.Instance.hWindow_Final10.Visible = false;
                    Frm_Vision.Instance.hWindow_Final11.Visible = false;
                    Frm_Vision.Instance.hWindow_Final12.Visible = false;
                    Frm_Vision.Instance.hWindow_Final13.Visible = false;
                    Frm_Vision.Instance.hWindow_Final14.Visible = false;
                    Frm_Vision.Instance.hWindow_Final15.Visible = false;
                    Frm_Vision.Instance.hWindow_Final16.Visible = false;

                    break;
                case WindowLayout.SixWindow:
                    Frm_Vision.Instance.tableLayoutPanel2.RowCount = 2;
                    Frm_Vision.Instance.tableLayoutPanel2.ColumnCount = 3;

                    Frm_Vision.Instance.hWindow_Final1.Visible = true;
                    Frm_Vision.Instance.hWindow_Final2.Visible = true;
                    Frm_Vision.Instance.hWindow_Final3.Visible = true;
                    Frm_Vision.Instance.hWindow_Final4.Visible = true;
                    Frm_Vision.Instance.hWindow_Final5.Visible = true;
                    Frm_Vision.Instance.hWindow_Final6.Visible = true;
                    Frm_Vision.Instance.hWindow_Final7.Visible = false;
                    Frm_Vision.Instance.hWindow_Final8.Visible = false;
                    Frm_Vision.Instance.hWindow_Final9.Visible = false;
                    Frm_Vision.Instance.hWindow_Final10.Visible = false;
                    Frm_Vision.Instance.hWindow_Final11.Visible = false;
                    Frm_Vision.Instance.hWindow_Final12.Visible = false;
                    Frm_Vision.Instance.hWindow_Final13.Visible = false;
                    Frm_Vision.Instance.hWindow_Final14.Visible = false;
                    Frm_Vision.Instance.hWindow_Final15.Visible = false;
                    Frm_Vision.Instance.hWindow_Final16.Visible = false;

                    break;
                case WindowLayout.EightWindow:
                    Frm_Vision.Instance.tableLayoutPanel2.RowCount = 2;
                    Frm_Vision.Instance.tableLayoutPanel2.ColumnCount = 4;

                    Frm_Vision.Instance.hWindow_Final1.Visible = true;
                    Frm_Vision.Instance.hWindow_Final2.Visible = true;
                    Frm_Vision.Instance.hWindow_Final3.Visible = true;
                    Frm_Vision.Instance.hWindow_Final4.Visible = true;
                    Frm_Vision.Instance.hWindow_Final5.Visible = true;
                    Frm_Vision.Instance.hWindow_Final6.Visible = true;
                    Frm_Vision.Instance.hWindow_Final7.Visible = true;
                    Frm_Vision.Instance.hWindow_Final8.Visible = true;
                    Frm_Vision.Instance.hWindow_Final9.Visible = false;
                    Frm_Vision.Instance.hWindow_Final10.Visible = false;
                    Frm_Vision.Instance.hWindow_Final11.Visible = false;
                    Frm_Vision.Instance.hWindow_Final12.Visible = false;
                    Frm_Vision.Instance.hWindow_Final13.Visible = false;
                    Frm_Vision.Instance.hWindow_Final14.Visible = false;
                    Frm_Vision.Instance.hWindow_Final15.Visible = false;
                    Frm_Vision.Instance.hWindow_Final16.Visible = false;

                    break;
                case WindowLayout.NineWindow:
                    Frm_Vision.Instance.tableLayoutPanel2.RowCount = 3;
                    Frm_Vision.Instance.tableLayoutPanel2.ColumnCount = 3;

                    Frm_Vision.Instance.hWindow_Final1.Visible = true;
                    Frm_Vision.Instance.hWindow_Final2.Visible = true;
                    Frm_Vision.Instance.hWindow_Final3.Visible = true;
                    Frm_Vision.Instance.hWindow_Final4.Visible = true;
                    Frm_Vision.Instance.hWindow_Final5.Visible = true;
                    Frm_Vision.Instance.hWindow_Final6.Visible = true;
                    Frm_Vision.Instance.hWindow_Final7.Visible = true;
                    Frm_Vision.Instance.hWindow_Final8.Visible = true;
                    Frm_Vision.Instance.hWindow_Final9.Visible = true;
                    Frm_Vision.Instance.hWindow_Final10.Visible = false;
                    Frm_Vision.Instance.hWindow_Final11.Visible = false;
                    Frm_Vision.Instance.hWindow_Final12.Visible = false;
                    Frm_Vision.Instance.hWindow_Final13.Visible = false;
                    Frm_Vision.Instance.hWindow_Final14.Visible = false;
                    Frm_Vision.Instance.hWindow_Final15.Visible = false;
                    Frm_Vision.Instance.hWindow_Final16.Visible = false;

                    break;
                case WindowLayout.TwelveWindow:
                    Frm_Vision.Instance.tableLayoutPanel2.RowCount = 3;
                    Frm_Vision.Instance.tableLayoutPanel2.ColumnCount = 4;

                    Frm_Vision.Instance.hWindow_Final1.Visible = true;
                    Frm_Vision.Instance.hWindow_Final2.Visible = true;
                    Frm_Vision.Instance.hWindow_Final3.Visible = true;
                    Frm_Vision.Instance.hWindow_Final4.Visible = true;
                    Frm_Vision.Instance.hWindow_Final5.Visible = true;
                    Frm_Vision.Instance.hWindow_Final6.Visible = true;
                    Frm_Vision.Instance.hWindow_Final7.Visible = true;
                    Frm_Vision.Instance.hWindow_Final8.Visible = true;
                    Frm_Vision.Instance.hWindow_Final9.Visible = true;
                    Frm_Vision.Instance.hWindow_Final10.Visible = true;
                    Frm_Vision.Instance.hWindow_Final11.Visible = true;
                    Frm_Vision.Instance.hWindow_Final12.Visible = true;
                    Frm_Vision.Instance.hWindow_Final13.Visible = false;
                    Frm_Vision.Instance.hWindow_Final14.Visible = false;
                    Frm_Vision.Instance.hWindow_Final15.Visible = false;
                    Frm_Vision.Instance.hWindow_Final16.Visible = false;

                    break;
                case WindowLayout.SixteenWindow:
                    Frm_Vision.Instance.tableLayoutPanel2.RowCount = 4;
                    Frm_Vision.Instance.tableLayoutPanel2.ColumnCount = 4;

                    Frm_Vision.Instance.hWindow_Final1.Visible = true;
                    Frm_Vision.Instance.hWindow_Final2.Visible = true;
                    Frm_Vision.Instance.hWindow_Final3.Visible = true;
                    Frm_Vision.Instance.hWindow_Final4.Visible = true;
                    Frm_Vision.Instance.hWindow_Final5.Visible = true;
                    Frm_Vision.Instance.hWindow_Final6.Visible = true;
                    Frm_Vision.Instance.hWindow_Final7.Visible = true;
                    Frm_Vision.Instance.hWindow_Final8.Visible = true;
                    Frm_Vision.Instance.hWindow_Final9.Visible = true;
                    Frm_Vision.Instance.hWindow_Final10.Visible = true;
                    Frm_Vision.Instance.hWindow_Final11.Visible = true;
                    Frm_Vision.Instance.hWindow_Final12.Visible = true;
                    Frm_Vision.Instance.hWindow_Final13.Visible = true;
                    Frm_Vision.Instance.hWindow_Final14.Visible = true;
                    Frm_Vision.Instance.hWindow_Final15.Visible = true;
                    Frm_Vision.Instance.hWindow_Final16.Visible = true;

                    break;
            }
        }


        private void Frm_Vision_Load(object sender, EventArgs e)
        {
            if (curForm == 0)
            {
                splitContainer2.Panel2.Controls.Clear();
                Frm_Msg.Instance.TopLevel = false;
                Frm_Msg.Instance.Parent = splitContainer2.Panel2;
                Frm_Msg.Instance.Dock = DockStyle.Fill;
                Frm_Msg.Instance.Show();
            }
            Frm_Vision.UpdateWindowLayout();
            //splitContainer2.Panel2.Controls.Clear();
            //Frm_Msg.Instance.TopLevel = false;
            //Frm_Msg.Instance.Parent = splitContainer2.Panel2;
            //Frm_Msg.Instance.Dock = DockStyle.Fill;
            //Frm_Msg.Instance.Show();
        }

        private void 清除窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((HWindow_Final)uiContextMenuStrip1.SourceControl).ClearWindow();
        }
        private void 保存原始图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string imageSavePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            HObject image = ((HWindow_Final)uiContextMenuStrip1.SourceControl).currentImage;
            if (image == null)
                return;

            if (!Directory.Exists(imageSavePath))
                Directory.CreateDirectory(imageSavePath);

            System.Windows.Forms.SaveFileDialog dig_saveImage = new System.Windows.Forms.SaveFileDialog();
            int index;
            for (index = 1; index < 1000; index++)
            {
                if (!File.Exists(imageSavePath + "\\" + DateTime.Now.ToString("yyyy_MM_dd") + "_" + index + ".tif"))
                    break;
            }
            dig_saveImage.FileName = DateTime.Now.ToString("yyyy_MM_dd") + "_" + index;
            dig_saveImage.Title = "请选择图像保存路径";
            dig_saveImage.Filter = "Image File|*.tif|Image File(*.*)|*.*|Image File(*.png)|*.txt|Image File(*.jpg)|*.jpg|Image File(*.bmp)|*.bmp";
            dig_saveImage.InitialDirectory = imageSavePath;
            if (dig_saveImage.ShowDialog() == DialogResult.OK)
            {
                string fileName = dig_saveImage.FileName;
                imageSavePath = Path.GetDirectoryName(dig_saveImage.FileName);
                HOperatorSet.WriteImage(image, "tiff", 0, dig_saveImage.FileName);
                FuncLib.ShowMsg("原始图像保存成功");
            }
        }
        private void 保存结果图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HObject image = ((HWindow_Final)uiContextMenuStrip1.SourceControl).currentImage;
            if (image == null)
                return;

            HOperatorSet.DumpWindowImage(out image, ((HWindow_Final)uiContextMenuStrip1.SourceControl).HWindowHalconID);
            string imageSavePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            if (!Directory.Exists(imageSavePath))
                Directory.CreateDirectory(imageSavePath);

            System.Windows.Forms.SaveFileDialog dig_saveImage = new System.Windows.Forms.SaveFileDialog();
            int index;
            for (index = 1; index < 1000; index++)
            {
                if (!File.Exists(imageSavePath + "\\" + DateTime.Now.ToString("yyyy_MM_dd") + "_" + index + ".tif"))
                    break;
            }
            dig_saveImage.FileName = DateTime.Now.ToString("yyyy_MM_dd") + "_" + index;
            dig_saveImage.Title = "请选择图像保存路径";
            dig_saveImage.Filter = "Image File|*.tif|Image File(*.*)|*.*|Image File(*.png)|*.txt|Image File(*.jpg)|*.jpg|Image File(*.bmp)|*.bmp";
            dig_saveImage.InitialDirectory = imageSavePath;
            if (dig_saveImage.ShowDialog() == DialogResult.OK)
            {
                string fileName = dig_saveImage.FileName;
                imageSavePath = Path.GetDirectoryName(dig_saveImage.FileName);
                HOperatorSet.WriteImage(image, "tiff", 0, dig_saveImage.FileName);
                FuncLib.ShowMsg("结果图像保存成功");
            }
        }
        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            Again:
            string newWindowName = FuncLib.ShowInput("请输入新窗体名");
            if (newWindowName == string.Empty)
                return;

            //命名查重
            for (int i = 0; i < Project.Instance.configuration.windowName.Length; i++)
            {
                if (Project.Instance.configuration.windowName[i] == newWindowName)
                {
                    FuncLib.ShowMessageBox("已存在此名称的窗体，窗体名不可重复，请重新输入", InfoType.Error);
                    goto Again;
                }
            }

            // 特殊字符检查
            if (newWindowName.Contains(@"\"))
            {
                FuncLib.ShowMessageBox("窗体名中不能含有 \\ 特殊字符 ，请重新输入", InfoType.Error);
                goto Again;
            }

            //更新窗体名称
            string oldWindowName = ((HWindow_Final)uiContextMenuStrip1.SourceControl).GetName();
            ((HWindow_Final)uiContextMenuStrip1.SourceControl).ReName(newWindowName);
            for (int i = 0; i < Project.Instance.configuration.windowName.Length; i++)
            {
                if (Project.Instance.configuration.windowName[i] == oldWindowName)
                {
                    Dictionary<string, HTuple> AA = new Dictionary<string, HTuple>();
                    Project.Instance.configuration.windowName[i] = newWindowName;
                    //在对显示窗体重命名的时候，也需要对后台窗体信息重命名，不然会导致找不到窗体的现象，从而出现异常
                    Project.D_backImageWindow = Project.D_backImageWindow.ToDictionary(k => k.Key == oldWindowName ? newWindowName : k.Key, k => k.Value);
                    break;
                }
            }

            FuncLib.ShowMsg(string.Format("参数变更！图像窗口名称已变更，变更前：{0}    变更后：{1}", oldWindowName, newWindowName));
        }
        private void 显示信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((HWindow_Final)uiContextMenuStrip1.SourceControl).m_CtrlHStatusLabelCtrl.Visible)
                ((HWindow_Final)uiContextMenuStrip1.SourceControl).m_CtrlHStatusLabelCtrl.Visible = false;
            else
                ((HWindow_Final)uiContextMenuStrip1.SourceControl).m_CtrlHStatusLabelCtrl.Visible = true;
        }

        internal void 任务toolStripButton2_Click(object sender, EventArgs e)
        {
            if (curForm != 0 || sender == null) //sender==null则说明当前是属于首次加载
            {
                curForm = 0;

                splitContainer1.Panel1.Controls.Clear();
                Frm_Task.Instance.TopLevel = false;
                Frm_Task.Instance.Parent = splitContainer1.Panel1;
                Frm_Task.Instance.Dock = DockStyle.Fill;
                Frm_Task.Instance.Show();
            }
        }
        internal void 生产toolStripButton1_Click(object sender, EventArgs e)
        {
            if (curForm != 1)
            {
                curForm = 1;

                splitContainer1.Panel1.Controls.Clear();
                Frm_Debug.Instance.TopLevel = false;
                Frm_Debug.Instance.Parent = splitContainer1.Panel1;
                Frm_Debug.Instance.Show();
            }
        }
        internal void 统计toolStripButton1_Click(object sender, EventArgs e)
        {
            if (curForm != 2)
            {
                curForm = 2;

                splitContainer1.Panel1.Controls.Clear();
                Frm_Infomation.Instance.TopLevel = false;
                Frm_Infomation.Instance.Parent = splitContainer1.Panel1;
                Frm_Infomation.Instance.Dock = DockStyle.Fill;
                Frm_Infomation.Instance.Show();
            }
        }

        private void 任务列表toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            if (Frm_Task.Instance.splitContainer2.Panel1Collapsed)
            {
                Frm_Task.Instance.splitContainer1.Panel2Collapsed = false;
                Frm_Task.Instance.splitContainer2.Panel1Collapsed = false;
            }
            else
            {
                Frm_Task.Instance.splitContainer1.Panel2Collapsed = false;
                Frm_Task.Instance.splitContainer2.Panel1Collapsed = false;
            }
            Project.Instance.configuration.taskListVisible = true;
        }
        private void 任务编辑toolStripButton4_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            Frm_Task.Instance.splitContainer2.Panel2Collapsed = false;
        }
        private void 工具箱toolStripButton5_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (Frm_Task.Instance.splitContainer2.Panel1Collapsed)
            {
                Frm_Task.Instance.splitContainer1.Panel1Collapsed = false;
                Frm_Task.Instance.splitContainer2.Panel1Collapsed = false;
                Frm_Task.Instance.splitContainer2.Panel2Collapsed = true;
            }
            else
            {
                Project.Instance.configuration.toolBoxStatu = 1;
                Frm_Task.Instance.splitContainer1.Panel1Collapsed = true;
                Frm_Task.Instance.C_toolBox.Parent = Frm_ToolBox.Instance;
                Frm_Task.Instance.C_toolBox.Dock = DockStyle.Fill;
                Frm_ToolBox.Instance.Location = new Point(Frm_Main.Instance.Location.X - 151, Frm_Main.Instance.Location.Y + 152);
                Frm_ToolBox.Instance.Show();
            }
        }
        private void 日志toolStripButton8_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (!curMsgForm)
            {
                curMsgForm = true;
                splitContainer2.Panel2.Controls.Clear();
                Frm_Msg.Instance.TopLevel = false;
                Frm_Msg.Instance.Parent = splitContainer2.Panel2;
                Frm_Msg.Instance.Dock = DockStyle.Fill;
                Frm_Msg.Instance.Show();
            }
        }
        private void 工具输出toolStripButton7_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (curMsgForm)
            {
                curMsgForm = false;
                splitContainer2.Panel2.Controls.Clear();
                Frm_Result.Instance.TopLevel = false;
                Frm_Result.Instance.Parent = splitContainer2.Panel2;
                Frm_Result.Instance.Dock = DockStyle.Fill;
                Frm_Result.Instance.Show();
            }
        }

        private void 画布toolStripButton6_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            Frm_Layout.Instance.ShowDialog();
            Frm_Vision.UpdateWindowLayout();
        }
        private void 演示模式toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            splitContainer1.Panel1Collapsed = true;
            splitContainer2.Panel2Collapsed = true;
            tableLayoutPanel1.RowStyles[0].Height = 0;
            Frm_Main.Instance.HeaderVisible(false);

            string date = File.GetLastAccessTime(Application.StartupPath + "\\VM Pro.exe").ToString("yyyy-MM-dd");
            Frm_Main.Instance.Text = string.Format("{0} - {1}  V {2}         演示模式(ESC退出)", Project.Instance.configuration.companyName, Project.Instance.configuration.projectName, string.Format("{0} {1}", date, ((AssemblyConfigurationAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false))[0]).Configuration));
        }
        private void 软键盘toolStripButton2_Click(object sender, EventArgs e)
        {
            processKeyBoard = System.Diagnostics.Process.Start("osk.exe");
        }

        private void 所有流程运行一次toolStripButton_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (Scheme.curScheme == null)
                return;

            Thread th = new Thread(() =>
            {
                for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
                {
                    Scheme.curScheme.L_taskList[i].Run();
                }
            });
            th.IsBackground = true;
            th.Start();
        }

        private void 当前流程连续运行toolStripButton_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (Task.curTask == null)
                return;

            if (!Task.curTask.isLoopRuning)
            {
                Task.curTask.isLoopRuning = true;
                Frm_Task.Instance.btn_runOnce.Enabled = false;
                Task.curTask.LoopRun();
            }
            else
            {
                Task.curTask.isLoopRuning = false;
                Frm_Task.Instance.btn_runOnce.Enabled = true;
            }
        }

        private void 所有流程连续运行toolStripButton_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (Scheme.curScheme == null)
                return;

            if (!loopRun)
            {
                Thread th = new Thread(() =>
                {
                    loopRun = true;
                    while (loopRun)
                    {
                        for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
                        {
                            Scheme.curScheme.L_taskList[i].Run();
                        }
                        Thread.Sleep(200);
                    }
                });
                th.IsBackground = true;
                th.Start();
            }
            else
            {
                loopRun = false;
            }
        }

        private void 全局变量toolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void 急速模式toolStripButton_Click(object sender, EventArgs e)
        {
            Project.Instance.configuration.IsJiSuMoShi = 急速模式toolStripButton.Checked;
            if (急速模式toolStripButton.Checked)
            {
                //清除运行状态——占用CT，先注销
                for (int i = 0; i < Frm_Task.Instance.C_toolList.Nodes.Count; i++)
                {
                    Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.Nodes[i], "急", Color.FromArgb(250, 250, 250), Color.DarkGray);
                }
                //Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.SelectedNode, "d", Color.FromArgb(250, 250, 250), Color.DarkGray);
            }

        }

        private void 任务toolStripButton2_MouseEnter(object sender, EventArgs e)
        {
            toolStrip1.Focus();
        }
        private void 生产toolStripButton1_MouseEnter(object sender, EventArgs e)
        {
            toolStrip1.Focus();
        }
        private void 统计toolStripButton1_MouseEnter(object sender, EventArgs e)
        {
            toolStrip1.Focus();
        }

        private void shishiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
            {
                for (int j = 0; j < Scheme.curScheme.L_taskList[i].L_toolList.Count; j++)
                {
                    if (Scheme.curScheme.L_taskList[i].L_toolList[j].toolType == ToolType.采集图像)
                    {

                        break;
                    }
                }
            }
        }

        private void pic_loginStatu_DoubleClick(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                FuncLib.ShowMsg("权限不足，请登录更高一级权限后重试", InfoType.Tip);
                return;
            }

            if (FuncLib.GetDoSts(Project.askMaterialCardName, Project.askMaterialIdx) == OnOff.On)
            {
                FuncLib.SetDo(Project.askMaterialCardName, Project.askMaterialIdx, OnOff.Off);
                FuncLib.ShowMsg("向上机要料信号已关闭");
            }
            else
            {
                FuncLib.SetDo(Project.askMaterialCardName, Project.askMaterialIdx, OnOff.On);
                FuncLib.ShowMsg("向上机要料信号已开启");
            }
        }
        private void lbl_askMaterial_DoubleClick(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                FuncLib.ShowMsg("权限不足，请登录更高一级权限后重试", InfoType.Tip);
                return;
            }

            if (FuncLib.GetDoSts(Project.askMaterialCardName, Project.askMaterialIdx) == OnOff.On)
            {
                FuncLib.SetDo(Project.askMaterialCardName, Project.askMaterialIdx, OnOff.Off);
                FuncLib.ShowMsg("向上机要料信号已关闭");
            }
            else
            {
                FuncLib.SetDo(Project.askMaterialCardName, Project.askMaterialIdx, OnOff.On);
                FuncLib.ShowMsg("向上机要料信号已开启");
            }
        }

        private void Frm_Vision_Shown(object sender, EventArgs e)
        {
            Frm_Vision.UpdateWindowLayout();
        }
    }
}
