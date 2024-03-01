namespace VM_Pro
{
    partial class Frm_Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("首页");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("视觉");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("运控");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("IO监控");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.pic_loginStatu = new Sunny.UI.UIAvatar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_start = new Sunny.UI.UISymbolButton();
            this.btn_pause = new Sunny.UI.UISymbolButton();
            this.btn_stop = new Sunny.UI.UISymbolButton();
            this.btn_reset = new Sunny.UI.UISymbolButton();
            this.lbl_curPermission = new Sunny.UI.UILabel();
            this.btn_save = new Sunny.UI.UISymbolButton();
            this.btn_system = new Sunny.UI.UISymbolButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.cbx_schemeList = new Sunny.UI.UIComboBox();
            this.lb_RunResult = new Sunny.UI.UILabel();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.激活ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.建议与反馈ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.示例项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助文档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.主题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生机盎然绿ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.青春自由蓝ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.热血澎湃红ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.橙ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.灰ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.墨绿ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_deviceStatu = new Sunny.UI.UIMarkLabel();
            this.lbl_CT = new Sunny.UI.UIMarkLabel();
            this.tmr_update = new System.Windows.Forms.Timer(this.components);
            this.btn_sevice1 = new Sunny.UI.UISymbolButton();
            this.btn_sevice2 = new Sunny.UI.UISymbolButton();
            this.btn_sevice4 = new Sunny.UI.UISymbolButton();
            this.btn_sevice3 = new Sunny.UI.UISymbolButton();
            this.btn_sevice5 = new Sunny.UI.UISymbolButton();
            this.btn_sevice7 = new Sunny.UI.UISymbolButton();
            this.btn_sevice6 = new Sunny.UI.UISymbolButton();
            this.btn_sevice8 = new Sunny.UI.UISymbolButton();
            this.uiToolTip1 = new Sunny.UI.UIToolTip(this.components);
            this.lbl_red = new Sunny.UI.UIMarkLabel();
            this.lbl_yellow = new Sunny.UI.UIMarkLabel();
            this.lbl_green = new Sunny.UI.UIMarkLabel();
            this.uiMarkLabel1 = new Sunny.UI.UIMarkLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.IsOK = new System.Windows.Forms.Label();
            this.生机盎然toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.StyleManager = new Sunny.UI.UIStyleManager(this.components);
            this.Footer.SuspendLayout();
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Footer
            // 
            this.Footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Footer.Controls.Add(this.lbl_green);
            this.Footer.Controls.Add(this.lbl_yellow);
            this.Footer.Controls.Add(this.lbl_red);
            this.Footer.Controls.Add(this.btn_sevice8);
            this.Footer.Controls.Add(this.btn_sevice7);
            this.Footer.Controls.Add(this.btn_sevice6);
            this.Footer.Controls.Add(this.btn_sevice5);
            this.Footer.Controls.Add(this.btn_sevice3);
            this.Footer.Controls.Add(this.btn_sevice4);
            this.Footer.Controls.Add(this.btn_sevice2);
            this.Footer.Controls.Add(this.btn_sevice1);
            this.Footer.Controls.Add(this.lbl_CT);
            this.Footer.Controls.Add(this.lbl_deviceStatu);
            this.Footer.Controls.Add(this.uiMarkLabel1);
            this.Footer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Footer.Location = new System.Drawing.Point(2, 693);
            this.Footer.Size = new System.Drawing.Size(1083, 25);
            this.Footer.Style = Sunny.UI.UIStyle.Custom;
            // 
            // Header
            // 
            this.Header.Controls.Add(this.IsOK);
            this.Header.Controls.Add(this.lb_RunResult);
            this.Header.Controls.Add(this.cbx_schemeList);
            this.Header.Controls.Add(this.uiLabel2);
            this.Header.Controls.Add(this.btn_save);
            this.Header.Controls.Add(this.btn_system);
            this.Header.Controls.Add(this.lbl_curPermission);
            this.Header.Controls.Add(this.btn_reset);
            this.Header.Controls.Add(this.btn_stop);
            this.Header.Controls.Add(this.btn_pause);
            this.Header.Controls.Add(this.btn_start);
            this.Header.Controls.Add(this.pictureBox1);
            this.Header.Controls.Add(this.pic_loginStatu);
            this.Header.Location = new System.Drawing.Point(2, 36);
            this.Header.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Header.NodeInterval = 84;
            treeNode1.Name = "节点0";
            treeNode1.Text = "首页";
            treeNode2.Name = "节点0";
            treeNode2.Text = "视觉";
            treeNode3.Name = "节点1";
            treeNode3.Text = "运控";
            treeNode4.Name = "节点0";
            treeNode4.Text = "IO监控";
            this.Header.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.Header.NodeSize = new System.Drawing.Size(110, 45);
            this.Header.Size = new System.Drawing.Size(1083, 83);
            this.Header.NodeMouseClick += new Sunny.UI.UINavBar.OnNodeMouseClick(this.Header_NodeMouseClick);
            // 
            // pic_loginStatu
            // 
            this.pic_loginStatu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_loginStatu.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pic_loginStatu.Location = new System.Drawing.Point(1007, -2);
            this.pic_loginStatu.MinimumSize = new System.Drawing.Size(1, 1);
            this.pic_loginStatu.Name = "pic_loginStatu";
            this.pic_loginStatu.Size = new System.Drawing.Size(66, 70);
            this.pic_loginStatu.SymbolSize = 50;
            this.pic_loginStatu.TabIndex = 5;
            this.pic_loginStatu.Text = "uiAvatar1";
            this.pic_loginStatu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.pic_loginStatu.Click += new System.EventHandler(this.pic_loginStatu_Click);
            this.pic_loginStatu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_loginStatu_MouseDown);
            this.pic_loginStatu.MouseEnter += new System.EventHandler(this.pic_loginStatu_MouseEnter);
            this.pic_loginStatu.MouseLeave += new System.EventHandler(this.pic_loginStatu_MouseLeave);
            this.pic_loginStatu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_loginStatu_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btn_start
            // 
            this.btn_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_start.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_start.Location = new System.Drawing.Point(316, 44);
            this.btn_start.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_start.Name = "btn_start";
            this.btn_start.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.btn_start.Size = new System.Drawing.Size(80, 32);
            this.btn_start.Symbol = 61515;
            this.btn_start.SymbolSize = 18;
            this.btn_start.TabIndex = 32;
            this.btn_start.Text = "启动";
            this.btn_start.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_start.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pause.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_pause.Location = new System.Drawing.Point(347, 45);
            this.btn_pause.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.btn_pause.Size = new System.Drawing.Size(80, 32);
            this.btn_pause.Symbol = 61516;
            this.btn_pause.SymbolSize = 18;
            this.btn_pause.TabIndex = 33;
            this.btn_pause.Text = "暂停";
            this.btn_pause.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_pause.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_stop.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_stop.Location = new System.Drawing.Point(382, 44);
            this.btn_stop.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.btn_stop.Size = new System.Drawing.Size(80, 32);
            this.btn_stop.Symbol = 61517;
            this.btn_stop.SymbolSize = 18;
            this.btn_stop.TabIndex = 34;
            this.btn_stop.Text = "停止";
            this.btn_stop.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_stop.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_reset.Location = new System.Drawing.Point(417, 44);
            this.btn_reset.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.btn_reset.Size = new System.Drawing.Size(80, 32);
            this.btn_reset.Symbol = 61522;
            this.btn_reset.SymbolSize = 20;
            this.btn_reset.TabIndex = 35;
            this.btn_reset.Text = "复位";
            this.btn_reset.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_reset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            this.btn_reset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_reset_MouseDown);
            this.btn_reset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_reset_MouseUp);
            // 
            // lbl_curPermission
            // 
            this.lbl_curPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_curPermission.AutoSize = true;
            this.lbl_curPermission.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_curPermission.Location = new System.Drawing.Point(1020, 65);
            this.lbl_curPermission.Name = "lbl_curPermission";
            this.lbl_curPermission.Size = new System.Drawing.Size(54, 20);
            this.lbl_curPermission.TabIndex = 45;
            this.lbl_curPermission.Text = "未登陆";
            this.lbl_curPermission.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_curPermission.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_save
            // 
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_save.Location = new System.Drawing.Point(123, 44);
            this.btn_save.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_save.Name = "btn_save";
            this.btn_save.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.btn_save.Size = new System.Drawing.Size(80, 32);
            this.btn_save.Symbol = 361639;
            this.btn_save.SymbolSize = 22;
            this.btn_save.TabIndex = 47;
            this.btn_save.Text = "保存";
            this.btn_save.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_save.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_system
            // 
            this.btn_system.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_system.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_system.Location = new System.Drawing.Point(206, 44);
            this.btn_system.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_system.Name = "btn_system";
            this.btn_system.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.btn_system.Size = new System.Drawing.Size(80, 32);
            this.btn_system.Symbol = 61573;
            this.btn_system.TabIndex = 46;
            this.btn_system.Text = "系统";
            this.btn_system.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_system.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_system.Click += new System.EventHandler(this.btn_system_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(119, 11);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(112, 27);
            this.uiLabel2.TabIndex = 48;
            this.uiLabel2.Text = "当前方案：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiLabel2.DoubleClick += new System.EventHandler(this.uiLabel2_DoubleClick);
            // 
            // cbx_schemeList
            // 
            this.cbx_schemeList.DataSource = null;
            this.cbx_schemeList.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_schemeList.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_schemeList.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cbx_schemeList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_schemeList.Location = new System.Drawing.Point(203, 8);
            this.cbx_schemeList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_schemeList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_schemeList.Name = "cbx_schemeList";
            this.cbx_schemeList.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_schemeList.Radius = 0;
            this.cbx_schemeList.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_schemeList.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_schemeList.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_schemeList.Size = new System.Drawing.Size(273, 28);
            this.cbx_schemeList.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_schemeList.TabIndex = 53;
            this.cbx_schemeList.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.cbx_schemeList.Watermark = "";
            this.cbx_schemeList.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_schemeList.SelectedIndexChanged += new System.EventHandler(this.cbx_schemeList_SelectedIndexChanged);
            this.cbx_schemeList.MouseEnter += new System.EventHandler(this.cbx_schemeList_MouseEnter);
            this.cbx_schemeList.MouseLeave += new System.EventHandler(this.cbx_schemeList_MouseLeave);
            // 
            // lb_RunResult
            // 
            this.lb_RunResult.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_RunResult.Location = new System.Drawing.Point(334, 5);
            this.lb_RunResult.Name = "lb_RunResult";
            this.lb_RunResult.Size = new System.Drawing.Size(20, 29);
            this.lb_RunResult.Style = Sunny.UI.UIStyle.Custom;
            this.lb_RunResult.TabIndex = 1;
            this.lb_RunResult.Text = "OK";
            this.lb_RunResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_RunResult.Visible = false;
            this.lb_RunResult.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip1.IsScaled = true;
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.激活ToolStripMenuItem,
            this.建议与反馈ToolStripMenuItem,
            this.示例项目ToolStripMenuItem,
            this.帮助文档ToolStripMenuItem,
            this.关于ToolStripMenuItem,
            this.主题ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(169, 180);
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // 激活ToolStripMenuItem
            // 
            this.激活ToolStripMenuItem.AutoSize = false;
            this.激活ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.激活ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.激活ToolStripMenuItem.Name = "激活ToolStripMenuItem";
            this.激活ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.激活ToolStripMenuItem.Text = "激活";
            this.激活ToolStripMenuItem.Click += new System.EventHandler(this.激活ToolStripMenuItem_Click);
            // 
            // 建议与反馈ToolStripMenuItem
            // 
            this.建议与反馈ToolStripMenuItem.AutoSize = false;
            this.建议与反馈ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.建议与反馈ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.建议与反馈ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.建议与反馈ToolStripMenuItem.Name = "建议与反馈ToolStripMenuItem";
            this.建议与反馈ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.建议与反馈ToolStripMenuItem.Text = "建议与反馈";
            this.建议与反馈ToolStripMenuItem.Click += new System.EventHandler(this.建议与反馈ToolStripMenuItem_Click);
            // 
            // 示例项目ToolStripMenuItem
            // 
            this.示例项目ToolStripMenuItem.AutoSize = false;
            this.示例项目ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.示例项目ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.示例项目ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.示例项目ToolStripMenuItem.Name = "示例项目ToolStripMenuItem";
            this.示例项目ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.示例项目ToolStripMenuItem.Text = "示例方案";
            this.示例项目ToolStripMenuItem.Click += new System.EventHandler(this.示例方案ToolStripMenuItem_Click);
            // 
            // 帮助文档ToolStripMenuItem
            // 
            this.帮助文档ToolStripMenuItem.AutoSize = false;
            this.帮助文档ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.帮助文档ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.帮助文档ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.帮助文档ToolStripMenuItem.Name = "帮助文档ToolStripMenuItem";
            this.帮助文档ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.帮助文档ToolStripMenuItem.Text = "帮助文档";
            this.帮助文档ToolStripMenuItem.Click += new System.EventHandler(this.帮助文档ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.AutoSize = false;
            this.关于ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.关于ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 主题ToolStripMenuItem
            // 
            this.主题ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生机盎然绿ToolStripMenuItem,
            this.青春自由蓝ToolStripMenuItem,
            this.热血澎湃红ToolStripMenuItem,
            this.橙ToolStripMenuItem,
            this.灰ToolStripMenuItem,
            this.墨绿ToolStripMenuItem});
            this.主题ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.主题ToolStripMenuItem.Name = "主题ToolStripMenuItem";
            this.主题ToolStripMenuItem.Size = new System.Drawing.Size(168, 28);
            this.主题ToolStripMenuItem.Text = "主题";
            // 
            // 生机盎然绿ToolStripMenuItem
            // 
            this.生机盎然绿ToolStripMenuItem.Name = "生机盎然绿ToolStripMenuItem";
            this.生机盎然绿ToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.生机盎然绿ToolStripMenuItem.Tag = "2";
            this.生机盎然绿ToolStripMenuItem.Text = "生机盎然绿";
            this.生机盎然绿ToolStripMenuItem.Click += new System.EventHandler(this.青春自由蓝ToolStripMenuItem_Click_1);
            // 
            // 青春自由蓝ToolStripMenuItem
            // 
            this.青春自由蓝ToolStripMenuItem.Name = "青春自由蓝ToolStripMenuItem";
            this.青春自由蓝ToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.青春自由蓝ToolStripMenuItem.Tag = "1";
            this.青春自由蓝ToolStripMenuItem.Text = "青春自由蓝";
            this.青春自由蓝ToolStripMenuItem.Click += new System.EventHandler(this.青春自由蓝ToolStripMenuItem_Click_1);
            // 
            // 热血澎湃红ToolStripMenuItem
            // 
            this.热血澎湃红ToolStripMenuItem.Name = "热血澎湃红ToolStripMenuItem";
            this.热血澎湃红ToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.热血澎湃红ToolStripMenuItem.Tag = "4";
            this.热血澎湃红ToolStripMenuItem.Text = "热血澎湃红";
            this.热血澎湃红ToolStripMenuItem.Click += new System.EventHandler(this.青春自由蓝ToolStripMenuItem_Click_1);
            // 
            // 橙ToolStripMenuItem
            // 
            this.橙ToolStripMenuItem.Name = "橙ToolStripMenuItem";
            this.橙ToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.橙ToolStripMenuItem.Tag = "3";
            this.橙ToolStripMenuItem.Text = "橙";
            this.橙ToolStripMenuItem.Click += new System.EventHandler(this.青春自由蓝ToolStripMenuItem_Click_1);
            // 
            // 灰ToolStripMenuItem
            // 
            this.灰ToolStripMenuItem.Name = "灰ToolStripMenuItem";
            this.灰ToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.灰ToolStripMenuItem.Tag = "5";
            this.灰ToolStripMenuItem.Text = "灰";
            this.灰ToolStripMenuItem.Click += new System.EventHandler(this.青春自由蓝ToolStripMenuItem_Click_1);
            // 
            // 墨绿ToolStripMenuItem
            // 
            this.墨绿ToolStripMenuItem.Name = "墨绿ToolStripMenuItem";
            this.墨绿ToolStripMenuItem.Size = new System.Drawing.Size(184, 28);
            this.墨绿ToolStripMenuItem.Tag = "7";
            this.墨绿ToolStripMenuItem.Text = "墨绿";
            this.墨绿ToolStripMenuItem.Click += new System.EventHandler(this.青春自由蓝ToolStripMenuItem_Click_1);
            // 
            // lbl_deviceStatu
            // 
            this.lbl_deviceStatu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_deviceStatu.AutoSize = true;
            this.lbl_deviceStatu.BackColor = System.Drawing.Color.Transparent;
            this.lbl_deviceStatu.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_deviceStatu.Location = new System.Drawing.Point(987, 3);
            this.lbl_deviceStatu.MarkSize = 2;
            this.lbl_deviceStatu.Name = "lbl_deviceStatu";
            this.lbl_deviceStatu.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lbl_deviceStatu.Size = new System.Drawing.Size(78, 22);
            this.lbl_deviceStatu.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_deviceStatu.TabIndex = 52;
            this.lbl_deviceStatu.Text = "等待复位";
            this.lbl_deviceStatu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_deviceStatu.Visible = false;
            this.lbl_deviceStatu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_CT
            // 
            this.lbl_CT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_CT.AutoSize = true;
            this.lbl_CT.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CT.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_CT.Location = new System.Drawing.Point(839, 3);
            this.lbl_CT.MarkSize = 2;
            this.lbl_CT.Name = "lbl_CT";
            this.lbl_CT.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lbl_CT.Size = new System.Drawing.Size(79, 22);
            this.lbl_CT.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_CT.TabIndex = 53;
            this.lbl_CT.Text = "CT ：0 s";
            this.lbl_CT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_CT.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tmr_update
            // 
            this.tmr_update.Interval = 60;
            this.tmr_update.Tick += new System.EventHandler(this.tmr_update_Tick);
            // 
            // btn_sevice1
            // 
            this.btn_sevice1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sevice1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sevice1.Location = new System.Drawing.Point(1, 2);
            this.btn_sevice1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_sevice1.Name = "btn_sevice1";
            this.btn_sevice1.Padding = new System.Windows.Forms.Padding(18, 0, 10, 0);
            this.btn_sevice1.Radius = 0;
            this.btn_sevice1.ShowTips = true;
            this.btn_sevice1.Size = new System.Drawing.Size(86, 22);
            this.btn_sevice1.Style = Sunny.UI.UIStyle.Custom;
            this.btn_sevice1.Symbol = 61713;
            this.btn_sevice1.SymbolOffset = new System.Drawing.Point(-34, 0);
            this.btn_sevice1.SymbolSize = 18;
            this.btn_sevice1.TabIndex = 54;
            this.btn_sevice1.Text = "服务";
            this.btn_sevice1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sevice1.TipsColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_sevice1.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sevice1.TipsForeColor = System.Drawing.Color.Green;
            this.btn_sevice1.Visible = false;
            this.btn_sevice1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_sevice1.Click += new System.EventHandler(this.btn_sevice_Click);
            // 
            // btn_sevice2
            // 
            this.btn_sevice2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sevice2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sevice2.Location = new System.Drawing.Point(90, 2);
            this.btn_sevice2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_sevice2.Name = "btn_sevice2";
            this.btn_sevice2.Padding = new System.Windows.Forms.Padding(18, 0, 10, 0);
            this.btn_sevice2.Radius = 0;
            this.btn_sevice2.ShowTips = true;
            this.btn_sevice2.Size = new System.Drawing.Size(86, 22);
            this.btn_sevice2.Style = Sunny.UI.UIStyle.Custom;
            this.btn_sevice2.Symbol = 61713;
            this.btn_sevice2.SymbolOffset = new System.Drawing.Point(-34, 0);
            this.btn_sevice2.SymbolSize = 18;
            this.btn_sevice2.TabIndex = 55;
            this.btn_sevice2.Text = "服务";
            this.btn_sevice2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sevice2.TipsColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_sevice2.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sevice2.TipsForeColor = System.Drawing.Color.Green;
            this.btn_sevice2.Visible = false;
            this.btn_sevice2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_sevice2.Click += new System.EventHandler(this.btn_sevice_Click);
            // 
            // btn_sevice4
            // 
            this.btn_sevice4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sevice4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sevice4.Location = new System.Drawing.Point(268, 2);
            this.btn_sevice4.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_sevice4.Name = "btn_sevice4";
            this.btn_sevice4.Padding = new System.Windows.Forms.Padding(18, 0, 10, 0);
            this.btn_sevice4.Radius = 0;
            this.btn_sevice4.ShowTips = true;
            this.btn_sevice4.Size = new System.Drawing.Size(86, 22);
            this.btn_sevice4.Style = Sunny.UI.UIStyle.Custom;
            this.btn_sevice4.Symbol = 61713;
            this.btn_sevice4.SymbolOffset = new System.Drawing.Point(-34, 0);
            this.btn_sevice4.SymbolSize = 18;
            this.btn_sevice4.TabIndex = 56;
            this.btn_sevice4.Text = "服务";
            this.btn_sevice4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sevice4.TipsColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_sevice4.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sevice4.TipsForeColor = System.Drawing.Color.Green;
            this.btn_sevice4.Visible = false;
            this.btn_sevice4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_sevice4.Click += new System.EventHandler(this.btn_sevice_Click);
            // 
            // btn_sevice3
            // 
            this.btn_sevice3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sevice3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sevice3.Location = new System.Drawing.Point(179, 2);
            this.btn_sevice3.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_sevice3.Name = "btn_sevice3";
            this.btn_sevice3.Padding = new System.Windows.Forms.Padding(18, 0, 10, 0);
            this.btn_sevice3.Radius = 0;
            this.btn_sevice3.ShowTips = true;
            this.btn_sevice3.Size = new System.Drawing.Size(86, 22);
            this.btn_sevice3.Style = Sunny.UI.UIStyle.Custom;
            this.btn_sevice3.Symbol = 61713;
            this.btn_sevice3.SymbolOffset = new System.Drawing.Point(-34, 0);
            this.btn_sevice3.SymbolSize = 18;
            this.btn_sevice3.TabIndex = 57;
            this.btn_sevice3.Text = "服务";
            this.btn_sevice3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sevice3.TipsColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_sevice3.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sevice3.TipsForeColor = System.Drawing.Color.Green;
            this.btn_sevice3.Visible = false;
            this.btn_sevice3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_sevice3.Click += new System.EventHandler(this.btn_sevice_Click);
            // 
            // btn_sevice5
            // 
            this.btn_sevice5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sevice5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sevice5.Location = new System.Drawing.Point(357, 2);
            this.btn_sevice5.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_sevice5.Name = "btn_sevice5";
            this.btn_sevice5.Padding = new System.Windows.Forms.Padding(18, 0, 10, 0);
            this.btn_sevice5.Radius = 0;
            this.btn_sevice5.ShowTips = true;
            this.btn_sevice5.Size = new System.Drawing.Size(86, 22);
            this.btn_sevice5.Style = Sunny.UI.UIStyle.Custom;
            this.btn_sevice5.Symbol = 61713;
            this.btn_sevice5.SymbolOffset = new System.Drawing.Point(-34, 0);
            this.btn_sevice5.SymbolSize = 18;
            this.btn_sevice5.TabIndex = 58;
            this.btn_sevice5.Text = "服务";
            this.btn_sevice5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sevice5.TipsColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_sevice5.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sevice5.TipsForeColor = System.Drawing.Color.Green;
            this.btn_sevice5.Visible = false;
            this.btn_sevice5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_sevice5.Click += new System.EventHandler(this.btn_sevice_Click);
            // 
            // btn_sevice7
            // 
            this.btn_sevice7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sevice7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sevice7.Location = new System.Drawing.Point(535, 2);
            this.btn_sevice7.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_sevice7.Name = "btn_sevice7";
            this.btn_sevice7.Padding = new System.Windows.Forms.Padding(18, 0, 10, 0);
            this.btn_sevice7.Radius = 0;
            this.btn_sevice7.ShowTips = true;
            this.btn_sevice7.Size = new System.Drawing.Size(86, 22);
            this.btn_sevice7.Style = Sunny.UI.UIStyle.Custom;
            this.btn_sevice7.Symbol = 61713;
            this.btn_sevice7.SymbolOffset = new System.Drawing.Point(-34, 0);
            this.btn_sevice7.SymbolSize = 18;
            this.btn_sevice7.TabIndex = 60;
            this.btn_sevice7.Text = "服务";
            this.btn_sevice7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sevice7.TipsColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_sevice7.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sevice7.TipsForeColor = System.Drawing.Color.Green;
            this.btn_sevice7.Visible = false;
            this.btn_sevice7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_sevice7.Click += new System.EventHandler(this.btn_sevice_Click);
            // 
            // btn_sevice6
            // 
            this.btn_sevice6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sevice6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sevice6.Location = new System.Drawing.Point(446, 2);
            this.btn_sevice6.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_sevice6.Name = "btn_sevice6";
            this.btn_sevice6.Padding = new System.Windows.Forms.Padding(18, 0, 10, 0);
            this.btn_sevice6.Radius = 0;
            this.btn_sevice6.ShowTips = true;
            this.btn_sevice6.Size = new System.Drawing.Size(86, 22);
            this.btn_sevice6.Style = Sunny.UI.UIStyle.Custom;
            this.btn_sevice6.Symbol = 61713;
            this.btn_sevice6.SymbolOffset = new System.Drawing.Point(-34, 0);
            this.btn_sevice6.SymbolSize = 18;
            this.btn_sevice6.TabIndex = 59;
            this.btn_sevice6.Text = "服务";
            this.btn_sevice6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sevice6.TipsColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_sevice6.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sevice6.TipsForeColor = System.Drawing.Color.Green;
            this.btn_sevice6.Visible = false;
            this.btn_sevice6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_sevice6.Click += new System.EventHandler(this.btn_sevice_Click);
            // 
            // btn_sevice8
            // 
            this.btn_sevice8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sevice8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sevice8.Location = new System.Drawing.Point(624, 2);
            this.btn_sevice8.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_sevice8.Name = "btn_sevice8";
            this.btn_sevice8.Padding = new System.Windows.Forms.Padding(18, 0, 10, 0);
            this.btn_sevice8.Radius = 0;
            this.btn_sevice8.ShowTips = true;
            this.btn_sevice8.Size = new System.Drawing.Size(86, 22);
            this.btn_sevice8.Style = Sunny.UI.UIStyle.Custom;
            this.btn_sevice8.Symbol = 61713;
            this.btn_sevice8.SymbolOffset = new System.Drawing.Point(-34, 0);
            this.btn_sevice8.SymbolSize = 18;
            this.btn_sevice8.TabIndex = 61;
            this.btn_sevice8.Text = "服务";
            this.btn_sevice8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sevice8.TipsColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_sevice8.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sevice8.TipsForeColor = System.Drawing.Color.Green;
            this.btn_sevice8.Visible = false;
            this.btn_sevice8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_sevice8.Click += new System.EventHandler(this.btn_sevice_Click);
            // 
            // uiToolTip1
            // 
            this.uiToolTip1.AutomaticDelay = 0;
            this.uiToolTip1.AutoPopDelay = 100000;
            this.uiToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.uiToolTip1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiToolTip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.uiToolTip1.InitialDelay = 0;
            this.uiToolTip1.OwnerDraw = true;
            this.uiToolTip1.ReshowDelay = 0;
            this.uiToolTip1.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // lbl_red
            // 
            this.lbl_red.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_red.BackColor = System.Drawing.Color.LightGray;
            this.lbl_red.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_red.Location = new System.Drawing.Point(1065, 2);
            this.lbl_red.MarkSize = 2;
            this.lbl_red.Name = "lbl_red";
            this.lbl_red.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lbl_red.Size = new System.Drawing.Size(13, 6);
            this.lbl_red.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_red.TabIndex = 62;
            this.lbl_red.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_red.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_yellow
            // 
            this.lbl_yellow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_yellow.BackColor = System.Drawing.Color.LightGray;
            this.lbl_yellow.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_yellow.Location = new System.Drawing.Point(1065, 9);
            this.lbl_yellow.MarkSize = 2;
            this.lbl_yellow.Name = "lbl_yellow";
            this.lbl_yellow.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lbl_yellow.Size = new System.Drawing.Size(13, 6);
            this.lbl_yellow.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_yellow.TabIndex = 63;
            this.lbl_yellow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_yellow.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_green
            // 
            this.lbl_green.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_green.BackColor = System.Drawing.Color.LightGray;
            this.lbl_green.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_green.Location = new System.Drawing.Point(1065, 16);
            this.lbl_green.MarkSize = 2;
            this.lbl_green.Name = "lbl_green";
            this.lbl_green.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lbl_green.Size = new System.Drawing.Size(13, 6);
            this.lbl_green.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_green.TabIndex = 64;
            this.lbl_green.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_green.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiMarkLabel1
            // 
            this.uiMarkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiMarkLabel1.AutoSize = true;
            this.uiMarkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiMarkLabel1.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.uiMarkLabel1.Location = new System.Drawing.Point(945, 3);
            this.uiMarkLabel1.MarkSize = 2;
            this.uiMarkLabel1.Name = "uiMarkLabel1";
            this.uiMarkLabel1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.uiMarkLabel1.Size = new System.Drawing.Size(61, 22);
            this.uiMarkLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiMarkLabel1.TabIndex = 65;
            this.uiMarkLabel1.Text = "状态 : ";
            this.uiMarkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiMarkLabel1.Visible = false;
            this.uiMarkLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // IsOK
            // 
            this.IsOK.AutoSize = true;
            this.IsOK.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsOK.Location = new System.Drawing.Point(486, 5);
            this.IsOK.Name = "IsOK";
            this.IsOK.Size = new System.Drawing.Size(0, 90);
            this.IsOK.TabIndex = 54;
            // 
            // 生机盎然toolStripMenuItem1
            // 
            this.生机盎然toolStripMenuItem1.Name = "生机盎然toolStripMenuItem1";
            this.生机盎然toolStripMenuItem1.Size = new System.Drawing.Size(241, 26);
            this.生机盎然toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // StyleManager
            // 
            this.StyleManager.DPIScale = true;
            // 
            // Frm_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1087, 720);
            this.ExtendBox = true;
            this.ExtendMenu = this.uiContextMenuStrip1;
            this.ExtendSymbol = 61641;
            this.ExtendSymbolOffset = new System.Drawing.Point(0, 2);
            this.ExtendSymbolSize = 20;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1024, 720);
            this.Name = "Frm_Main";
            this.Padding = new System.Windows.Forms.Padding(2, 36, 2, 2);
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.ShowShadow = true;
            this.Text = "VM Pro";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, -21, 1087, 720);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Main_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.Shown += new System.EventHandler(this.Frm_Main_Shown);
            this.Controls.SetChildIndex(this.Footer, 0);
            this.Controls.SetChildIndex(this.Header, 0);
            this.Footer.ResumeLayout(false);
            this.Footer.PerformLayout();
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UISymbolButton btn_save;
        private Sunny.UI.UISymbolButton btn_system;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 激活ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 建议与反馈ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 示例项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助文档ToolStripMenuItem;
        private System.Windows.Forms.Timer tmr_update;
        internal Sunny.UI.UILabel lbl_curPermission;
        internal Sunny.UI.UIAvatar pic_loginStatu;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        internal Sunny.UI.UIComboBox cbx_schemeList;
        internal Sunny.UI.UISymbolButton btn_sevice1;
        internal Sunny.UI.UISymbolButton btn_sevice5;
        internal Sunny.UI.UISymbolButton btn_sevice3;
        internal Sunny.UI.UISymbolButton btn_sevice4;
        internal Sunny.UI.UISymbolButton btn_sevice2;
        internal Sunny.UI.UISymbolButton btn_sevice8;
        internal Sunny.UI.UISymbolButton btn_sevice7;
        internal Sunny.UI.UISymbolButton btn_sevice6;
        internal Sunny.UI.UIToolTip uiToolTip1;
        internal Sunny.UI.UISymbolButton btn_stop;
        internal Sunny.UI.UISymbolButton btn_pause;
        internal Sunny.UI.UISymbolButton btn_start;
        internal Sunny.UI.UISymbolButton btn_reset;
        internal Sunny.UI.UIMarkLabel lbl_CT;
        internal Sunny.UI.UIMarkLabel lbl_green;
        internal Sunny.UI.UIMarkLabel lbl_yellow;
        internal Sunny.UI.UIMarkLabel lbl_red;
        internal Sunny.UI.UIMarkLabel lbl_deviceStatu;
        internal Sunny.UI.UIMarkLabel uiMarkLabel1;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label IsOK;
        internal Sunny.UI.UILabel lb_RunResult;
        private System.Windows.Forms.ToolStripMenuItem 主题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生机盎然绿ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 青春自由蓝ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生机盎然toolStripMenuItem1;
        private Sunny.UI.UIStyleManager StyleManager;
        private System.Windows.Forms.ToolStripMenuItem 热血澎湃红ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 橙ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 灰ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 墨绿ToolStripMenuItem;
    }
}