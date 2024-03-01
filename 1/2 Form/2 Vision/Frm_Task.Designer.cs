namespace VM_Pro
{
    partial class Frm_Task
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("采集图像");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("图像拼接");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("存储图像");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("图像预处理");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("图像脚本");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("相机IO输出");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("图像相关", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("模板匹配");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("码类识别");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("字符识别");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("胶路检测");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("检测识别", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("引用标定");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("坐标转换", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("顶部定位");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("对位贴合二");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("定位引导", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("查找直线");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("查找圆形");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("查找拟合", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("线线交点");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("运算几何", new System.Windows.Forms.TreeNode[] {
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("逻辑控制");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("创建区域");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("创建组合", new System.Windows.Forms.TreeNode[] {
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("光源控制");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("仪表仪器", new System.Windows.Forms.TreeNode[] {
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("以太网发");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("通讯相关", new System.Windows.Forms.TreeNode[] {
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("3D  检测");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("外部输出");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("其它相关", new System.Windows.Forms.TreeNode[] {
            treeNode31});
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("推理识别");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("语义分割", new System.Windows.Forms.TreeNode[] {
            treeNode33});
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("深度学习", new System.Windows.Forms.TreeNode[] {
            treeNode34});
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("自定义处理");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("生产计数");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("项目自定义工具", new System.Windows.Forms.TreeNode[] {
            treeNode36,
            treeNode37});
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("南昌CT");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("CT", new System.Windows.Forms.TreeNode[] {
            treeNode39});
            this.btn_runOnce = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiContextMenuStrip2 = new Sunny.UI.UIContextMenuStrip();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.隐藏页面toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.悬浮ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.C_toolList = new Sunny.UI.UINavMenu();
            this.uiContextMenuStrip3 = new Sunny.UI.UIContextMenuStrip();
            this.终端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.禁用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.禁用全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏页面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.C_toolBox = new Sunny.UI.UINavMenu();
            this.C_taskList = new Sunny.UI.UINavMenu();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.uiContextMenuStrip2.SuspendLayout();
            this.uiContextMenuStrip1.SuspendLayout();
            this.uiContextMenuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_runOnce
            // 
            this.btn_runOnce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runOnce.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_runOnce.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runOnce.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_runOnce.Location = new System.Drawing.Point(0, 497);
            this.btn_runOnce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_runOnce.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_runOnce.Name = "btn_runOnce";
            this.btn_runOnce.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_runOnce.Size = new System.Drawing.Size(208, 102);
            this.btn_runOnce.Style = Sunny.UI.UIStyle.Custom;
            this.btn_runOnce.TabIndex = 77;
            this.btn_runOnce.Text = "执行一次";
            this.btn_runOnce.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runOnce.TipsText = "100";
            this.btn_runOnce.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_runOnce.Click += new System.EventHandler(this.btn_runOnce_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(0, 0);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(146, 30);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 71;
            this.uiLabel1.Text = "工具箱";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(0, 0);
            this.uiLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(208, 30);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 73;
            this.uiLabel2.Text = "任务编辑";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiContextMenuStrip2
            // 
            this.uiContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip2.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.复制ToolStripMenuItem1,
            this.粘贴ToolStripMenuItem1,
            this.导入ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.删除ToolStripMenuItem1,
            this.重命名ToolStripMenuItem1,
            this.隐藏ToolStripMenuItem2,
            this.配置ToolStripMenuItem});
            this.uiContextMenuStrip2.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip2.Size = new System.Drawing.Size(216, 256);
            this.uiContextMenuStrip2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.AutoSize = false;
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(183, 28);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem1
            // 
            this.复制ToolStripMenuItem1.AutoSize = false;
            this.复制ToolStripMenuItem1.Name = "复制ToolStripMenuItem1";
            this.复制ToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.复制ToolStripMenuItem1.Size = new System.Drawing.Size(183, 28);
            this.复制ToolStripMenuItem1.Text = "复制";
            this.复制ToolStripMenuItem1.Click += new System.EventHandler(this.复制ToolStripMenuItem1_Click);
            // 
            // 粘贴ToolStripMenuItem1
            // 
            this.粘贴ToolStripMenuItem1.AutoSize = false;
            this.粘贴ToolStripMenuItem1.Name = "粘贴ToolStripMenuItem1";
            this.粘贴ToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.粘贴ToolStripMenuItem1.Size = new System.Drawing.Size(183, 28);
            this.粘贴ToolStripMenuItem1.Text = "粘贴插入";
            this.粘贴ToolStripMenuItem1.Click += new System.EventHandler(this.粘贴插入ToolStripMenuItem1_Click);
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.AutoSize = false;
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(183, 28);
            this.导入ToolStripMenuItem.Text = "导入";
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.导入ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.AutoSize = false;
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(183, 28);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem1
            // 
            this.删除ToolStripMenuItem1.AutoSize = false;
            this.删除ToolStripMenuItem1.Name = "删除ToolStripMenuItem1";
            this.删除ToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.删除ToolStripMenuItem1.Size = new System.Drawing.Size(183, 28);
            this.删除ToolStripMenuItem1.Text = "删除";
            this.删除ToolStripMenuItem1.Click += new System.EventHandler(this.删除ToolStripMenuItem1_Click);
            // 
            // 重命名ToolStripMenuItem1
            // 
            this.重命名ToolStripMenuItem1.AutoSize = false;
            this.重命名ToolStripMenuItem1.Name = "重命名ToolStripMenuItem1";
            this.重命名ToolStripMenuItem1.Size = new System.Drawing.Size(183, 28);
            this.重命名ToolStripMenuItem1.Text = "重命名";
            this.重命名ToolStripMenuItem1.Click += new System.EventHandler(this.重命名ToolStripMenuItem1_Click);
            // 
            // 隐藏ToolStripMenuItem2
            // 
            this.隐藏ToolStripMenuItem2.AutoSize = false;
            this.隐藏ToolStripMenuItem2.Name = "隐藏ToolStripMenuItem2";
            this.隐藏ToolStripMenuItem2.Size = new System.Drawing.Size(183, 28);
            this.隐藏ToolStripMenuItem2.Text = "隐藏页面";
            this.隐藏ToolStripMenuItem2.Click += new System.EventHandler(this.隐藏ToolStripMenuItem2_Click);
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.AutoSize = false;
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(183, 28);
            this.配置ToolStripMenuItem.Text = "配置";
            this.配置ToolStripMenuItem.Click += new System.EventHandler(this.配置ToolStripMenuItem1_Click);
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.AutoSize = false;
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.隐藏页面toolStripMenuItem1,
            this.悬浮ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(150, 60);
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiContextMenuStrip1.Paint += new System.Windows.Forms.PaintEventHandler(this.uiContextMenuStrip1_Paint);
            // 
            // 隐藏页面toolStripMenuItem1
            // 
            this.隐藏页面toolStripMenuItem1.AutoSize = false;
            this.隐藏页面toolStripMenuItem1.Name = "隐藏页面toolStripMenuItem1";
            this.隐藏页面toolStripMenuItem1.Size = new System.Drawing.Size(149, 28);
            this.隐藏页面toolStripMenuItem1.Text = "隐藏页面";
            this.隐藏页面toolStripMenuItem1.Click += new System.EventHandler(this.隐藏页面toolStripMenuItem1_Click);
            // 
            // 悬浮ToolStripMenuItem
            // 
            this.悬浮ToolStripMenuItem.AutoSize = false;
            this.悬浮ToolStripMenuItem.Name = "悬浮ToolStripMenuItem";
            this.悬浮ToolStripMenuItem.Size = new System.Drawing.Size(149, 28);
            this.悬浮ToolStripMenuItem.Text = "悬浮";
            this.悬浮ToolStripMenuItem.Click += new System.EventHandler(this.悬浮ToolStripMenuItem_Click);
            // 
            // C_toolList
            // 
            this.C_toolList.AllowDrop = true;
            this.C_toolList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.C_toolList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.C_toolList.ContextMenuStrip = this.uiContextMenuStrip3;
            this.C_toolList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.C_toolList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.C_toolList.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.C_toolList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C_toolList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.C_toolList.FullRowSelect = true;
            this.C_toolList.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.C_toolList.ItemHeight = 35;
            this.C_toolList.Location = new System.Drawing.Point(0, 30);
            this.C_toolList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.C_toolList.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.C_toolList.Name = "C_toolList";
            this.C_toolList.SecondBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.C_toolList.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.C_toolList.ShowLines = false;
            this.C_toolList.ShowNodeToolTips = true;
            this.C_toolList.ShowOneNode = true;
            this.C_toolList.ShowSecondBackColor = true;
            this.C_toolList.ShowTips = true;
            this.C_toolList.Size = new System.Drawing.Size(208, 569);
            this.C_toolList.Style = Sunny.UI.UIStyle.Custom;
            this.C_toolList.TabIndex = 70;
            this.C_toolList.TabStop = false;
            this.C_toolList.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.C_toolList.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C_toolList.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.C_toolList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.C_toolList_ItemDrag);
            this.C_toolList.Click += new System.EventHandler(this.C_toolList_Click);
            this.C_toolList.DragDrop += new System.Windows.Forms.DragEventHandler(this.C_toolList_DragDrop);
            this.C_toolList.DragEnter += new System.Windows.Forms.DragEventHandler(this.C_toolList_DragEnter);
            this.C_toolList.DoubleClick += new System.EventHandler(this.C_toolList_DoubleClick);
            this.C_toolList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.C_toolList_MouseDown);
            // 
            // uiContextMenuStrip3
            // 
            this.uiContextMenuStrip3.AutoSize = false;
            this.uiContextMenuStrip3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip3.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.终端ToolStripMenuItem,
            this.运行ToolStripMenuItem,
            this.禁用ToolStripMenuItem,
            this.禁用全部ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.重命名ToolStripMenuItem,
            this.隐藏页面ToolStripMenuItem});
            this.uiContextMenuStrip3.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip3.Size = new System.Drawing.Size(184, 256);
            this.uiContextMenuStrip3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiContextMenuStrip3.Paint += new System.Windows.Forms.PaintEventHandler(this.uiContextMenuStrip3_Paint);
            // 
            // 终端ToolStripMenuItem
            // 
            this.终端ToolStripMenuItem.Name = "终端ToolStripMenuItem";
            this.终端ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.终端ToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.终端ToolStripMenuItem.Text = "终端";
            this.终端ToolStripMenuItem.Click += new System.EventHandler(this.终端ToolStripMenuItem_Click);
            // 
            // 运行ToolStripMenuItem
            // 
            this.运行ToolStripMenuItem.Name = "运行ToolStripMenuItem";
            this.运行ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.运行ToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.运行ToolStripMenuItem.Text = "运行";
            this.运行ToolStripMenuItem.Click += new System.EventHandler(this.运行ToolStripMenuItem_Click);
            // 
            // 禁用ToolStripMenuItem
            // 
            this.禁用ToolStripMenuItem.Name = "禁用ToolStripMenuItem";
            this.禁用ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.禁用ToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.禁用ToolStripMenuItem.Text = "禁用";
            this.禁用ToolStripMenuItem.Click += new System.EventHandler(this.禁用ToolStripMenuItem_Click);
            // 
            // 禁用全部ToolStripMenuItem
            // 
            this.禁用全部ToolStripMenuItem.AutoSize = false;
            this.禁用全部ToolStripMenuItem.Name = "禁用全部ToolStripMenuItem";
            this.禁用全部ToolStripMenuItem.Size = new System.Drawing.Size(183, 28);
            this.禁用全部ToolStripMenuItem.Text = "禁用全部";
            this.禁用全部ToolStripMenuItem.Click += new System.EventHandler(this.禁用全部ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.复制ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.粘贴ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.粘贴ToolStripMenuItem.Text = "粘贴插入";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴插入ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.删除ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名ToolStripMenuItem_Click);
            // 
            // 隐藏页面ToolStripMenuItem
            // 
            this.隐藏页面ToolStripMenuItem.AutoSize = false;
            this.隐藏页面ToolStripMenuItem.Name = "隐藏页面ToolStripMenuItem";
            this.隐藏页面ToolStripMenuItem.Size = new System.Drawing.Size(183, 28);
            this.隐藏页面ToolStripMenuItem.Text = "隐藏页面";
            this.隐藏页面ToolStripMenuItem.Click += new System.EventHandler(this.隐藏页面ToolStripMenuItem_Click);
            // 
            // uiLabel9
            // 
            this.uiLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiLabel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(0, 0);
            this.uiLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(152, 30);
            this.uiLabel9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel9.TabIndex = 75;
            this.uiLabel9.Text = "任务列表";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.C_toolBox);
            this.splitContainer1.Panel1.Controls.Add(this.uiLabel1);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.C_taskList);
            this.splitContainer1.Panel2.Controls.Add(this.uiLabel9);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(301, 599);
            this.splitContainer1.SplitterDistance = 146;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 81;
            // 
            // C_toolBox
            // 
            this.C_toolBox.AllowDrop = true;
            this.C_toolBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.C_toolBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.C_toolBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.C_toolBox.ContextMenuStrip = this.uiContextMenuStrip1;
            this.C_toolBox.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.C_toolBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.C_toolBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C_toolBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.C_toolBox.FullRowSelect = true;
            this.C_toolBox.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.C_toolBox.ItemHeight = 35;
            this.C_toolBox.Location = new System.Drawing.Point(0, 25);
            this.C_toolBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.C_toolBox.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.C_toolBox.Name = "C_toolBox";
            treeNode1.Name = "节点14";
            treeNode1.Text = "采集图像";
            treeNode2.Name = "节点0";
            treeNode2.Text = "图像拼接";
            treeNode3.Name = "节点15";
            treeNode3.Text = "存储图像";
            treeNode4.Name = "节点0";
            treeNode4.Text = "图像预处理";
            treeNode5.Name = "节点0";
            treeNode5.Text = "图像脚本";
            treeNode5.ToolTipText = "图像引擎脚本";
            treeNode6.Name = "节点0";
            treeNode6.Text = "相机IO输出";
            treeNode7.ImageIndex = 0;
            treeNode7.Name = "节点0";
            treeNode7.Text = "图像相关";
            treeNode8.Name = "节点16";
            treeNode8.Text = "模板匹配";
            treeNode9.Name = "节点21";
            treeNode9.Text = "码类识别";
            treeNode10.Name = "节点22";
            treeNode10.Text = "字符识别";
            treeNode11.Name = "节点24";
            treeNode11.Text = "胶路检测";
            treeNode12.Name = "节点0";
            treeNode12.Text = "检测识别";
            treeNode13.Name = "节点3";
            treeNode13.Text = "引用标定";
            treeNode14.Name = "节点1";
            treeNode14.Text = "坐标转换";
            treeNode15.Name = "节点4";
            treeNode15.Text = "顶部定位";
            treeNode16.Name = "节点6";
            treeNode16.Text = "对位贴合二";
            treeNode17.Name = "节点2";
            treeNode17.Text = "定位引导";
            treeNode18.Name = "节点9";
            treeNode18.Text = "查找直线";
            treeNode19.Name = "节点10";
            treeNode19.Text = "查找圆形";
            treeNode20.Name = "节点4";
            treeNode20.Text = "查找拟合";
            treeNode21.Name = "节点1";
            treeNode21.Text = "线线交点";
            treeNode22.Name = "节点5";
            treeNode22.Text = "运算几何";
            treeNode23.Name = "节点3";
            treeNode23.Text = "逻辑控制";
            treeNode24.Name = "节点22";
            treeNode24.Text = "创建区域";
            treeNode25.Name = "节点6";
            treeNode25.Text = "创建组合";
            treeNode26.Name = "节点17";
            treeNode26.Text = "光源控制";
            treeNode27.Name = "节点7";
            treeNode27.Text = "仪表仪器";
            treeNode28.Name = "节点20";
            treeNode28.Text = "以太网发";
            treeNode29.Name = "节点8";
            treeNode29.Text = "通讯相关";
            treeNode30.Name = "节点9";
            treeNode30.Text = "3D  检测";
            treeNode31.Name = "节点21";
            treeNode31.Text = "外部输出";
            treeNode32.Name = "节点10";
            treeNode32.Text = "其它相关";
            treeNode33.Name = "节点9";
            treeNode33.Text = "推理识别";
            treeNode34.Name = "节点5";
            treeNode34.Text = "语义分割";
            treeNode35.Name = "节点0";
            treeNode35.Text = "深度学习";
            treeNode36.Name = "节点11";
            treeNode36.Text = "自定义处理";
            treeNode37.Name = "节点1";
            treeNode37.Text = "生产计数";
            treeNode38.Name = "节点10";
            treeNode38.Text = "项目自定义工具";
            treeNode39.Name = "节点1";
            treeNode39.Text = "南昌CT";
            treeNode40.Name = "节点0";
            treeNode40.Text = "CT";
            this.C_toolBox.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode12,
            treeNode14,
            treeNode17,
            treeNode20,
            treeNode22,
            treeNode23,
            treeNode25,
            treeNode27,
            treeNode29,
            treeNode30,
            treeNode32,
            treeNode35,
            treeNode38,
            treeNode40});
            this.C_toolBox.SecondBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.C_toolBox.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.C_toolBox.ShowLines = false;
            this.C_toolBox.ShowOneNode = true;
            this.C_toolBox.ShowSecondBackColor = true;
            this.C_toolBox.Size = new System.Drawing.Size(146, 571);
            this.C_toolBox.Style = Sunny.UI.UIStyle.Custom;
            this.C_toolBox.TabIndex = 79;
            this.C_toolBox.TabStop = false;
            this.C_toolBox.TagString = "";
            this.C_toolBox.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C_toolBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.C_toolBox.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.C_toolBox_ItemDrag);
            this.C_toolBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.C_toolBox_DragEnter);
            this.C_toolBox.DoubleClick += new System.EventHandler(this.C_toolBox_DoubleClick);
            // 
            // C_taskList
            // 
            this.C_taskList.AllowDrop = true;
            this.C_taskList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.C_taskList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.C_taskList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.C_taskList.ContextMenuStrip = this.uiContextMenuStrip2;
            this.C_taskList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.C_taskList.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.C_taskList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.C_taskList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.C_taskList.FullRowSelect = true;
            this.C_taskList.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.C_taskList.ItemHeight = 35;
            this.C_taskList.Location = new System.Drawing.Point(0, 30);
            this.C_taskList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.C_taskList.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.C_taskList.Name = "C_taskList";
            this.C_taskList.SecondBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.C_taskList.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.C_taskList.ShowLines = false;
            this.C_taskList.ShowNodeToolTips = true;
            this.C_taskList.ShowOneNode = true;
            this.C_taskList.ShowSecondBackColor = true;
            this.C_taskList.ShowTips = true;
            this.C_taskList.Size = new System.Drawing.Size(206, 569);
            this.C_taskList.Style = Sunny.UI.UIStyle.Custom;
            this.C_taskList.TabIndex = 78;
            this.C_taskList.TabStop = false;
            this.C_taskList.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C_taskList.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.C_taskList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.C_taskList_ItemDrag);
            this.C_taskList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.C_taskList_AfterSelect);
            this.C_taskList.DragDrop += new System.Windows.Forms.DragEventHandler(this.C_taskList_DragDrop);
            this.C_taskList.DragEnter += new System.Windows.Forms.DragEventHandler(this.C_taskList_DragEnter);
            this.C_taskList.DoubleClick += new System.EventHandler(this.C_taskList_DoubleClick);
            this.C_taskList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.C_taskList_MouseDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel1MinSize = 0;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btn_runOnce);
            this.splitContainer2.Panel2.Controls.Add(this.C_toolList);
            this.splitContainer2.Panel2.Controls.Add(this.uiLabel2);
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(512, 599);
            this.splitContainer2.SplitterDistance = 301;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 82;
            // 
            // Frm_Task
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(512, 599);
            this.Controls.Add(this.splitContainer2);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_Task";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "Frm5_Task";
            this.Load += new System.EventHandler(this.Frm_Task_Load);
            this.Shown += new System.EventHandler(this.Frm_Task_Shown);
            this.Resize += new System.EventHandler(this.Frm_Task_Resize);
            this.uiContextMenuStrip2.ResumeLayout(false);
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.uiContextMenuStrip3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel9;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隐藏ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 终端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 禁用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隐藏页面toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 隐藏页面ToolStripMenuItem;
        internal Sunny.UI.UINavMenu C_toolList;
        internal System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 悬浮ToolStripMenuItem;
        internal Sunny.UI.UINavMenu C_toolBox;
        internal Sunny.UI.UIContextMenuStrip uiContextMenuStrip2;
        internal Sunny.UI.UIContextMenuStrip uiContextMenuStrip3;
        internal Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        internal Sunny.UI.UINavMenu C_taskList;
        internal Sunny.UI.UIButton btn_runOnce;
        private System.Windows.Forms.ToolStripMenuItem 禁用全部ToolStripMenuItem;
    }
}