namespace VM_Pro
{
    partial class Frm_GlueDetectTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_GlueDetectTool));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.保存toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.复位toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbl_runResult = new System.Windows.Forms.Label();
            this.nud_maxRunArea = new Controls.CNumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_minRunArea = new Controls.CNumericUpDown();
            this.nud_corrosArea = new Controls.CNumericUpDown();
            this.nud_maxDefectArea = new Controls.CNumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_regionNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiLine7 = new Sunny.UI.UILine();
            this.ckb_multiGlueDetect = new Sunny.UI.UICheckBox();
            this.ckb_lackGlueDetect = new Sunny.UI.UICheckBox();
            this.ckb_brokenGlueDetect = new Sunny.UI.UICheckBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.ckb_showDefectType = new Sunny.UI.UICheckBox();
            this.ckb_showCircleMark = new Sunny.UI.UICheckBox();
            this.ckb_showSearchRegion = new Sunny.UI.UICheckBox();
            this.ckb_showDefectMargin = new Sunny.UI.UICheckBox();
            this.ckb_showResultMargin = new Sunny.UI.UICheckBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final2();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.适应窗体toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.图像信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckb_taskFailKeepRun = new Sunny.UI.UICheckBox();
            this.btn_glueRegion = new Sunny.UI.UIButton();
            this.uiLine5 = new Sunny.UI.UILine();
            this.btn_close = new Sunny.UI.UIButton();
            this.btn_runTask = new Sunny.UI.UIButton();
            this.btn_runTool = new Sunny.UI.UIButton();
            this.lbl_toolTip = new Sunny.UI.UILabel();
            this.lbl_runTime = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiLine4 = new Sunny.UI.UILine();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.uiContextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 587);
            this.panel1.TabIndex = 24;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1040, 587);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存toolStripButton1,
            this.复位toolStripButton3});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1040, 30);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.MouseEnter += new System.EventHandler(this.toolStrip1_MouseEnter);
            // 
            // 保存toolStripButton1
            // 
            this.保存toolStripButton1.AutoSize = false;
            this.保存toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.保存toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("保存toolStripButton1.Image")));
            this.保存toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.保存toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存toolStripButton1.Name = "保存toolStripButton1";
            this.保存toolStripButton1.Size = new System.Drawing.Size(34, 25);
            this.保存toolStripButton1.Text = "toolStripButton3";
            this.保存toolStripButton1.ToolTipText = "保存";
            this.保存toolStripButton1.Click += new System.EventHandler(this.保存toolStripButton1_Click);
            // 
            // 复位toolStripButton3
            // 
            this.复位toolStripButton3.AutoSize = false;
            this.复位toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.复位toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("复位toolStripButton3.Image")));
            this.复位toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.复位toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.复位toolStripButton3.Name = "复位toolStripButton3";
            this.复位toolStripButton3.Size = new System.Drawing.Size(34, 25);
            this.复位toolStripButton3.Text = "toolStripButton3";
            this.复位toolStripButton3.ToolTipText = "复位";
            this.复位toolStripButton3.Click += new System.EventHandler(this.复位toolStripButton3_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 662F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.hWindow_Final1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1040, 495);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uiTabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(662, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(378, 495);
            this.panel3.TabIndex = 1;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.tabPage3);
            this.uiTabControl1.Controls.Add(this.tabPage9);
            this.uiTabControl1.Controls.Add(this.tabPage10);
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.FillColor = System.Drawing.Color.White;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(80, 28);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(378, 495);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTabControl1.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.uiTabControl1.TabIndex = 123;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiTabControl1.TabUnSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.lbl_runResult);
            this.tabPage3.Controls.Add(this.nud_maxRunArea);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.nud_minRunArea);
            this.tabPage3.Controls.Add(this.nud_corrosArea);
            this.tabPage3.Controls.Add(this.nud_maxDefectArea);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.lbl_regionNum);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.uiLine1);
            this.tabPage3.Controls.Add(this.uiLine7);
            this.tabPage3.Controls.Add(this.ckb_multiGlueDetect);
            this.tabPage3.Controls.Add(this.ckb_lackGlueDetect);
            this.tabPage3.Controls.Add(this.ckb_brokenGlueDetect);
            this.tabPage3.Location = new System.Drawing.Point(0, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(378, 467);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "参数";
            // 
            // lbl_runResult
            // 
            this.lbl_runResult.AutoSize = true;
            this.lbl_runResult.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_runResult.Location = new System.Drawing.Point(182, 442);
            this.lbl_runResult.Name = "lbl_runResult";
            this.lbl_runResult.Size = new System.Drawing.Size(23, 20);
            this.lbl_runResult.TabIndex = 248;
            this.lbl_runResult.Text = "无";
            // 
            // nud_maxRunArea
            // 
            this.nud_maxRunArea.BackColor = System.Drawing.Color.White;
            this.nud_maxRunArea.DecimalPlaces = 0;
            this.nud_maxRunArea.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_maxRunArea.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_maxRunArea.Location = new System.Drawing.Point(251, 197);
            this.nud_maxRunArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_maxRunArea.MaximumSize = new System.Drawing.Size(300, 28);
            this.nud_maxRunArea.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nud_maxRunArea.MinimumSize = new System.Drawing.Size(54, 28);
            this.nud_maxRunArea.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_maxRunArea.Name = "nud_maxRunArea";
            this.nud_maxRunArea.Size = new System.Drawing.Size(101, 28);
            this.nud_maxRunArea.TabIndex = 245;
            this.nud_maxRunArea.Value = 10000D;
            this.nud_maxRunArea.ValueChanged += new Controls.DValueChanged(this.nud_maxRunArea_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(231, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 20);
            this.label2.TabIndex = 244;
            this.label2.Text = "~";
            // 
            // nud_minRunArea
            // 
            this.nud_minRunArea.BackColor = System.Drawing.Color.White;
            this.nud_minRunArea.DecimalPlaces = 0;
            this.nud_minRunArea.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_minRunArea.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_minRunArea.Location = new System.Drawing.Point(126, 197);
            this.nud_minRunArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_minRunArea.MaximumSize = new System.Drawing.Size(300, 28);
            this.nud_minRunArea.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nud_minRunArea.MinimumSize = new System.Drawing.Size(54, 28);
            this.nud_minRunArea.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_minRunArea.Name = "nud_minRunArea";
            this.nud_minRunArea.Size = new System.Drawing.Size(101, 28);
            this.nud_minRunArea.TabIndex = 242;
            this.nud_minRunArea.Value = 10D;
            this.nud_minRunArea.ValueChanged += new Controls.DValueChanged(this.nud_minRunArea_ValueChanged);
            // 
            // nud_corrosArea
            // 
            this.nud_corrosArea.BackColor = System.Drawing.Color.White;
            this.nud_corrosArea.DecimalPlaces = 0;
            this.nud_corrosArea.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_corrosArea.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_corrosArea.Location = new System.Drawing.Point(126, 167);
            this.nud_corrosArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_corrosArea.MaximumSize = new System.Drawing.Size(300, 28);
            this.nud_corrosArea.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_corrosArea.MinimumSize = new System.Drawing.Size(54, 28);
            this.nud_corrosArea.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_corrosArea.Name = "nud_corrosArea";
            this.nud_corrosArea.Size = new System.Drawing.Size(101, 28);
            this.nud_corrosArea.TabIndex = 240;
            this.nud_corrosArea.Value = 10D;
            this.nud_corrosArea.ValueChanged += new Controls.DValueChanged(this.nud_corrosArea_ValueChanged);
            // 
            // nud_maxDefectArea
            // 
            this.nud_maxDefectArea.BackColor = System.Drawing.Color.White;
            this.nud_maxDefectArea.DecimalPlaces = 0;
            this.nud_maxDefectArea.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_maxDefectArea.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_maxDefectArea.Location = new System.Drawing.Point(126, 137);
            this.nud_maxDefectArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_maxDefectArea.MaximumSize = new System.Drawing.Size(300, 28);
            this.nud_maxDefectArea.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_maxDefectArea.MinimumSize = new System.Drawing.Size(54, 28);
            this.nud_maxDefectArea.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_maxDefectArea.Name = "nud_maxDefectArea";
            this.nud_maxDefectArea.Size = new System.Drawing.Size(101, 28);
            this.nud_maxDefectArea.TabIndex = 238;
            this.nud_maxDefectArea.Value = 1D;
            this.nud_maxDefectArea.ValueChanged += new Controls.DValueChanged(this.nud_maxDefectArea_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(142, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 249;
            this.label5.Text = "结果：";
            // 
            // lbl_regionNum
            // 
            this.lbl_regionNum.AutoSize = true;
            this.lbl_regionNum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_regionNum.Location = new System.Drawing.Point(82, 442);
            this.lbl_regionNum.Name = "lbl_regionNum";
            this.lbl_regionNum.Size = new System.Drawing.Size(35, 20);
            this.lbl_regionNum.TabIndex = 247;
            this.lbl_regionNum.Text = "0 个";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 442);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 246;
            this.label3.Text = "不良数量：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 241;
            this.label1.Text = "胶域筛选 (像素)：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(14, 170);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 20);
            this.label15.TabIndex = 239;
            this.label15.Text = "不良腐蚀 (像素)：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(14, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 20);
            this.label14.TabIndex = 237;
            this.label14.Text = "不良界定 (像素)：";
            // 
            // uiLine1
            // 
            this.uiLine1.FillColor = System.Drawing.Color.White;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(3, 97);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(365, 29);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 227;
            this.uiLine1.Text = "检测条件";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine7
            // 
            this.uiLine7.FillColor = System.Drawing.Color.White;
            this.uiLine7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine7.Location = new System.Drawing.Point(3, 15);
            this.uiLine7.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine7.Name = "uiLine7";
            this.uiLine7.Size = new System.Drawing.Size(365, 29);
            this.uiLine7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine7.TabIndex = 226;
            this.uiLine7.Text = "需检测项";
            this.uiLine7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckb_multiGlueDetect
            // 
            this.ckb_multiGlueDetect.Checked = true;
            this.ckb_multiGlueDetect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_multiGlueDetect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_multiGlueDetect.Location = new System.Drawing.Point(271, 58);
            this.ckb_multiGlueDetect.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_multiGlueDetect.Name = "ckb_multiGlueDetect";
            this.ckb_multiGlueDetect.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_multiGlueDetect.Size = new System.Drawing.Size(105, 24);
            this.ckb_multiGlueDetect.TabIndex = 143;
            this.ckb_multiGlueDetect.Text = "多胶检测";
            this.ckb_multiGlueDetect.Click += new System.EventHandler(this.ckb_multiGlueDetect_Click);
            // 
            // ckb_lackGlueDetect
            // 
            this.ckb_lackGlueDetect.Checked = true;
            this.ckb_lackGlueDetect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_lackGlueDetect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_lackGlueDetect.Location = new System.Drawing.Point(143, 58);
            this.ckb_lackGlueDetect.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_lackGlueDetect.Name = "ckb_lackGlueDetect";
            this.ckb_lackGlueDetect.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_lackGlueDetect.Size = new System.Drawing.Size(105, 24);
            this.ckb_lackGlueDetect.TabIndex = 142;
            this.ckb_lackGlueDetect.Text = "少胶检测";
            this.ckb_lackGlueDetect.Click += new System.EventHandler(this.ckb_lackGlueDetect_Click);
            // 
            // ckb_brokenGlueDetect
            // 
            this.ckb_brokenGlueDetect.Checked = true;
            this.ckb_brokenGlueDetect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_brokenGlueDetect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_brokenGlueDetect.Location = new System.Drawing.Point(15, 58);
            this.ckb_brokenGlueDetect.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_brokenGlueDetect.Name = "ckb_brokenGlueDetect";
            this.ckb_brokenGlueDetect.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_brokenGlueDetect.Size = new System.Drawing.Size(105, 24);
            this.ckb_brokenGlueDetect.TabIndex = 141;
            this.ckb_brokenGlueDetect.Text = "断胶检测";
            this.ckb_brokenGlueDetect.Click += new System.EventHandler(this.ckb_brokenGlueDetect_Click);
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.White;
            this.tabPage9.Controls.Add(this.ckb_showDefectType);
            this.tabPage9.Controls.Add(this.ckb_showCircleMark);
            this.tabPage9.Controls.Add(this.ckb_showSearchRegion);
            this.tabPage9.Controls.Add(this.ckb_showDefectMargin);
            this.tabPage9.Controls.Add(this.ckb_showResultMargin);
            this.tabPage9.Location = new System.Drawing.Point(0, 28);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(378, 467);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "显示";
            // 
            // ckb_showDefectType
            // 
            this.ckb_showDefectType.Checked = true;
            this.ckb_showDefectType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_showDefectType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_showDefectType.Location = new System.Drawing.Point(14, 140);
            this.ckb_showDefectType.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_showDefectType.Name = "ckb_showDefectType";
            this.ckb_showDefectType.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_showDefectType.Size = new System.Drawing.Size(131, 24);
            this.ckb_showDefectType.TabIndex = 142;
            this.ckb_showDefectType.Text = "显示不良类型";
            this.ckb_showDefectType.Click += new System.EventHandler(this.ckb_showDefectType_Click);
            // 
            // ckb_showCircleMark
            // 
            this.ckb_showCircleMark.Checked = true;
            this.ckb_showCircleMark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_showCircleMark.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_showCircleMark.Location = new System.Drawing.Point(14, 110);
            this.ckb_showCircleMark.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_showCircleMark.Name = "ckb_showCircleMark";
            this.ckb_showCircleMark.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_showCircleMark.Size = new System.Drawing.Size(131, 24);
            this.ckb_showCircleMark.TabIndex = 141;
            this.ckb_showCircleMark.Text = "显示圆圈标记";
            this.ckb_showCircleMark.Click += new System.EventHandler(this.ckb_showCircleMark_Click);
            // 
            // ckb_showSearchRegion
            // 
            this.ckb_showSearchRegion.Checked = true;
            this.ckb_showSearchRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_showSearchRegion.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_showSearchRegion.Location = new System.Drawing.Point(14, 80);
            this.ckb_showSearchRegion.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_showSearchRegion.Name = "ckb_showSearchRegion";
            this.ckb_showSearchRegion.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_showSearchRegion.Size = new System.Drawing.Size(131, 24);
            this.ckb_showSearchRegion.TabIndex = 140;
            this.ckb_showSearchRegion.Text = "显示搜索区域";
            this.ckb_showSearchRegion.Click += new System.EventHandler(this.ckb_showSearchRegion_Click);
            // 
            // ckb_showDefectMargin
            // 
            this.ckb_showDefectMargin.Checked = true;
            this.ckb_showDefectMargin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_showDefectMargin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_showDefectMargin.Location = new System.Drawing.Point(14, 50);
            this.ckb_showDefectMargin.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_showDefectMargin.Name = "ckb_showDefectMargin";
            this.ckb_showDefectMargin.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_showDefectMargin.Size = new System.Drawing.Size(131, 24);
            this.ckb_showDefectMargin.TabIndex = 139;
            this.ckb_showDefectMargin.Text = "显示缺陷轮廓";
            this.ckb_showDefectMargin.Click += new System.EventHandler(this.ckb_showDefectMargin_Click);
            // 
            // ckb_showResultMargin
            // 
            this.ckb_showResultMargin.Checked = true;
            this.ckb_showResultMargin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_showResultMargin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_showResultMargin.Location = new System.Drawing.Point(14, 20);
            this.ckb_showResultMargin.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_showResultMargin.Name = "ckb_showResultMargin";
            this.ckb_showResultMargin.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_showResultMargin.Size = new System.Drawing.Size(131, 24);
            this.ckb_showResultMargin.TabIndex = 138;
            this.ckb_showResultMargin.Text = "显示结果轮廓";
            this.ckb_showResultMargin.Click += new System.EventHandler(this.ckb_showResultMargin_Click);
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.White;
            this.tabPage10.Controls.Add(this.dgv_result);
            this.tabPage10.Location = new System.Drawing.Point(0, 28);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(378, 467);
            this.tabPage10.TabIndex = 4;
            this.tabPage10.Text = "结果";
            // 
            // dgv_result
            // 
            this.dgv_result.AllowDrop = true;
            this.dgv_result.AllowUserToAddRows = false;
            this.dgv_result.AllowUserToDeleteRows = false;
            this.dgv_result.AllowUserToResizeRows = false;
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column12});
            this.dgv_result.Location = new System.Drawing.Point(13, 21);
            this.dgv_result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.ReadOnly = true;
            this.dgv_result.RowHeadersVisible = false;
            this.dgv_result.RowTemplate.Height = 23;
            this.dgv_result.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_result.Size = new System.Drawing.Size(346, 441);
            this.dgv_result.TabIndex = 12;
            this.dgv_result.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_result_CellClick);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "编号";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 63;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "类型";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 70;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "面积";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 70;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "行";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 70;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "列";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column12.Width = 70;
            // 
            // hWindow_Final1
            // 
            this.hWindow_Final1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final1.ContextMenuStrip = this.uiContextMenuStrip1;
            this.hWindow_Final1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_Final1.DrawModel = false;
            this.hWindow_Final1.EditModel = true;
            this.hWindow_Final1.Image = null;
            this.hWindow_Final1.Location = new System.Drawing.Point(7, 2);
            this.hWindow_Final1.Margin = new System.Windows.Forms.Padding(7, 2, 5, 5);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(650, 488);
            this.hWindow_Final1.TabIndex = 2;
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.AutoSize = false;
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.适应窗体toolStripMenuItem1,
            this.图像信息ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(150, 60);
            // 
            // 适应窗体toolStripMenuItem1
            // 
            this.适应窗体toolStripMenuItem1.AutoSize = false;
            this.适应窗体toolStripMenuItem1.Name = "适应窗体toolStripMenuItem1";
            this.适应窗体toolStripMenuItem1.Size = new System.Drawing.Size(149, 28);
            this.适应窗体toolStripMenuItem1.Text = "适应窗体";
            this.适应窗体toolStripMenuItem1.Click += new System.EventHandler(this.适应窗体toolStripMenuItem1_Click);
            // 
            // 图像信息ToolStripMenuItem
            // 
            this.图像信息ToolStripMenuItem.AutoSize = false;
            this.图像信息ToolStripMenuItem.Name = "图像信息ToolStripMenuItem";
            this.图像信息ToolStripMenuItem.Size = new System.Drawing.Size(149, 28);
            this.图像信息ToolStripMenuItem.Text = "图像信息";
            this.图像信息ToolStripMenuItem.Click += new System.EventHandler(this.图像信息ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckb_taskFailKeepRun);
            this.panel2.Controls.Add(this.btn_glueRegion);
            this.panel2.Controls.Add(this.uiLine5);
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.btn_runTask);
            this.panel2.Controls.Add(this.btn_runTool);
            this.panel2.Controls.Add(this.lbl_toolTip);
            this.panel2.Controls.Add(this.lbl_runTime);
            this.panel2.Controls.Add(this.uiLabel1);
            this.panel2.Controls.Add(this.uiLabel9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 525);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1040, 62);
            this.panel2.TabIndex = 94;
            // 
            // ckb_taskFailKeepRun
            // 
            this.ckb_taskFailKeepRun.Checked = true;
            this.ckb_taskFailKeepRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_taskFailKeepRun.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_taskFailKeepRun.Location = new System.Drawing.Point(120, 10);
            this.ckb_taskFailKeepRun.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_taskFailKeepRun.Name = "ckb_taskFailKeepRun";
            this.ckb_taskFailKeepRun.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_taskFailKeepRun.Size = new System.Drawing.Size(140, 24);
            this.ckb_taskFailKeepRun.TabIndex = 235;
            this.ckb_taskFailKeepRun.Text = "流程失败仍运行";
            this.ckb_taskFailKeepRun.Click += new System.EventHandler(this.ckb_taskFailKeepRun_Click);
            // 
            // btn_glueRegion
            // 
            this.btn_glueRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_glueRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_glueRegion.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_glueRegion.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_glueRegion.Location = new System.Drawing.Point(558, 15);
            this.btn_glueRegion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_glueRegion.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_glueRegion.Name = "btn_glueRegion";
            this.btn_glueRegion.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_glueRegion.Size = new System.Drawing.Size(75, 32);
            this.btn_glueRegion.StyleCustomMode = true;
            this.btn_glueRegion.TabIndex = 130;
            this.btn_glueRegion.Text = "胶域分割";
            this.btn_glueRegion.Click += new System.EventHandler(this.btn_glueRegion_Click);
            // 
            // uiLine5
            // 
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine5.LineSize = 2;
            this.uiLine5.Location = new System.Drawing.Point(7, 0);
            this.uiLine5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine5.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(1026, 2);
            this.uiLine5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine5.TabIndex = 129;
            this.uiLine5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_close.Location = new System.Drawing.Point(949, 15);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_close.Size = new System.Drawing.Size(75, 32);
            this.btn_close.StyleCustomMode = true;
            this.btn_close.TabIndex = 103;
            this.btn_close.Text = "关闭";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_runTask
            // 
            this.btn_runTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_runTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runTask.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTask.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_runTask.Location = new System.Drawing.Point(765, 15);
            this.btn_runTask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_runTask.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_runTask.Name = "btn_runTask";
            this.btn_runTask.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_runTask.Size = new System.Drawing.Size(75, 32);
            this.btn_runTask.StyleCustomMode = true;
            this.btn_runTask.TabIndex = 102;
            this.btn_runTask.Text = "运行流程";
            this.btn_runTask.Visible = false;
            this.btn_runTask.Click += new System.EventHandler(this.btn_runTask_Click);
            // 
            // btn_runTool
            // 
            this.btn_runTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_runTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runTool.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTool.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_runTool.Location = new System.Drawing.Point(681, 15);
            this.btn_runTool.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_runTool.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_runTool.Name = "btn_runTool";
            this.btn_runTool.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_runTool.Size = new System.Drawing.Size(75, 32);
            this.btn_runTool.StyleCustomMode = true;
            this.btn_runTool.TabIndex = 101;
            this.btn_runTool.Text = "运行工具";
            this.btn_runTool.Click += new System.EventHandler(this.btn_runTool_Click);
            // 
            // lbl_toolTip
            // 
            this.lbl_toolTip.BackColor = System.Drawing.Color.White;
            this.lbl_toolTip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_toolTip.Location = new System.Drawing.Point(47, 29);
            this.lbl_toolTip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_toolTip.Name = "lbl_toolTip";
            this.lbl_toolTip.Size = new System.Drawing.Size(486, 22);
            this.lbl_toolTip.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_toolTip.TabIndex = 97;
            this.lbl_toolTip.Text = "暂无提示";
            this.lbl_toolTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_runTime
            // 
            this.lbl_runTime.BackColor = System.Drawing.Color.White;
            this.lbl_runTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_runTime.Location = new System.Drawing.Point(47, 10);
            this.lbl_runTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_runTime.Name = "lbl_runTime";
            this.lbl_runTime.Size = new System.Drawing.Size(66, 22);
            this.lbl_runTime.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_runTime.TabIndex = 96;
            this.lbl_runTime.Text = "0 ms";
            this.lbl_runTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.White;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(9, 29);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(66, 22);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 95;
            this.uiLabel1.Text = "提示：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.BackColor = System.Drawing.Color.White;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(9, 9);
            this.uiLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(66, 22);
            this.uiLabel9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel9.TabIndex = 94;
            this.uiLabel9.Text = "耗时：";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine2
            // 
            this.uiLine2.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine2.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine2.LineSize = 2;
            this.uiLine2.Location = new System.Drawing.Point(0, 31);
            this.uiLine2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine2.MinimumSize = new System.Drawing.Size(2, 0);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(2, 587);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 131;
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine3
            // 
            this.uiLine3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine3.LineSize = 2;
            this.uiLine3.Location = new System.Drawing.Point(2, 616);
            this.uiLine3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine3.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(1038, 2);
            this.uiLine3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine3.TabIndex = 132;
            this.uiLine3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine4
            // 
            this.uiLine4.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine4.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiLine4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine4.LineSize = 2;
            this.uiLine4.Location = new System.Drawing.Point(1038, 31);
            this.uiLine4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine4.MinimumSize = new System.Drawing.Size(2, 0);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(2, 585);
            this.uiLine4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine4.TabIndex = 133;
            this.uiLine4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_GlueDetectTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 618);
            this.Controls.Add(this.uiLine4);
            this.Controls.Add(this.uiLine3);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.panel1);
            this.ExtendBox = true;
            this.ExtendSymbol = 61475;
            this.ExtendSymbolOffset = new System.Drawing.Point(0, 2);
            this.ExtendSymbolSize = 18;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1040, 618);
            this.MinimumSize = new System.Drawing.Size(1040, 618);
            this.Name = "Frm_GlueDetectTool";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowIcon = true;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "胶路检测";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.TopMost = true;
            this.ExtendBoxClick += new System.EventHandler(this.Frm_ImageTool_ExtendBoxClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_System_FormClosing);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel9;
        private System.Windows.Forms.Panel panel3;
        private Sunny.UI.UIButton btn_close;
        private Sunny.UI.UIButton btn_runTask;
        private Sunny.UI.UIButton btn_runTool;
        private Sunny.UI.UILine uiLine5;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UILine uiLine4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 复位toolStripButton3;
        internal Sunny.UI.UILabel lbl_toolTip;
        internal Sunny.UI.UILabel lbl_runTime;
        internal Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 适应窗体toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 图像信息ToolStripMenuItem;
        internal ChoiceTech.Halcon.Control.HWindow_Final2 hWindow_Final1;
        internal Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage9;
        internal Sunny.UI.UICheckBox ckb_showDefectType;
        internal Sunny.UI.UICheckBox ckb_showCircleMark;
        internal Sunny.UI.UICheckBox ckb_showSearchRegion;
        internal Sunny.UI.UICheckBox ckb_showDefectMargin;
        internal Sunny.UI.UICheckBox ckb_showResultMargin;
        private System.Windows.Forms.TabPage tabPage10;
        internal System.Windows.Forms.DataGridView dgv_result;
        internal Sunny.UI.UICheckBox ckb_multiGlueDetect;
        internal Sunny.UI.UICheckBox ckb_lackGlueDetect;
        internal Sunny.UI.UICheckBox ckb_brokenGlueDetect;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UILine uiLine7;
        public Controls.CNumericUpDown nud_maxRunArea;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public Controls.CNumericUpDown nud_minRunArea;
        public System.Windows.Forms.Label label15;
        public Controls.CNumericUpDown nud_corrosArea;
        public System.Windows.Forms.Label label14;
        public Controls.CNumericUpDown nud_maxDefectArea;
        public System.Windows.Forms.Label lbl_regionNum;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lbl_runResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private Sunny.UI.UIButton btn_glueRegion;
        private System.Windows.Forms.ToolStripButton 保存toolStripButton1;
        internal Sunny.UI.UICheckBox ckb_taskFailKeepRun;

    }
}