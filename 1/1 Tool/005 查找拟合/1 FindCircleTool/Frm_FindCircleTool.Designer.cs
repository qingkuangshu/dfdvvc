namespace VM_Pro
{
    partial class Frm_FindCircleTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_FindCircleTool));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.保存toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.复位toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbx_polarity = new Sunny.UI.UIComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_switchEdge = new Sunny.UI.UIButton();
            this.btn_switchPolarity = new Sunny.UI.UIButton();
            this.cbx_edgeSelect = new Sunny.UI.UIComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tkb_caliperLength = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.nud_caliperLength = new Controls.CNumericUpDown();
            this.tkb_minScore = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_minScore = new Controls.CNumericUpDown();
            this.tkb_caliperWidth = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_caliperWidth = new Controls.CNumericUpDown();
            this.tkb_ignorePointNum = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_ignorePointNum = new Controls.CNumericUpDown();
            this.nud_threshold = new Controls.CNumericUpDown();
            this.tkb_caliperNum = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_caliperNum = new Controls.CNumericUpDown();
            this.tkb_threshold = new System.Windows.Forms.TrackBar();
            this.uiLine1 = new Sunny.UI.UILine();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.ckb_showCross = new Sunny.UI.UICheckBox();
            this.ckb_showCircle = new Sunny.UI.UICheckBox();
            this.ckb_showFeature = new Sunny.UI.UICheckBox();
            this.ckb_showCaliper = new Sunny.UI.UICheckBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final2();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.适应窗体toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.图像信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckb_taskFailKeepRun = new Sunny.UI.UICheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.tkb_caliperLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_minScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_caliperWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_ignorePointNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_caliperNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_threshold)).BeginInit();
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
            this.uiTabControl1.TabIndex = 122;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiTabControl1.TabUnSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.cbx_polarity);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.btn_switchEdge);
            this.tabPage3.Controls.Add(this.btn_switchPolarity);
            this.tabPage3.Controls.Add(this.cbx_edgeSelect);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.tkb_caliperLength);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.nud_caliperLength);
            this.tabPage3.Controls.Add(this.tkb_minScore);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.nud_minScore);
            this.tabPage3.Controls.Add(this.tkb_caliperWidth);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.nud_caliperWidth);
            this.tabPage3.Controls.Add(this.tkb_ignorePointNum);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.nud_ignorePointNum);
            this.tabPage3.Controls.Add(this.nud_threshold);
            this.tabPage3.Controls.Add(this.tkb_caliperNum);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.nud_caliperNum);
            this.tabPage3.Controls.Add(this.tkb_threshold);
            this.tabPage3.Controls.Add(this.uiLine1);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Location = new System.Drawing.Point(0, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(378, 467);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "参数";
            // 
            // cbx_polarity
            // 
            this.cbx_polarity.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_polarity.DataSource = null;
            this.cbx_polarity.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_polarity.DropDownWidth = 132;
            this.cbx_polarity.FillColor = System.Drawing.Color.White;
            this.cbx_polarity.FillDisableColor = System.Drawing.Color.White;
            this.cbx_polarity.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_polarity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_polarity.Items.AddRange(new object[] {
            "从明到暗",
            "从暗到明"});
            this.cbx_polarity.Location = new System.Drawing.Point(94, 265);
            this.cbx_polarity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_polarity.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_polarity.Name = "cbx_polarity";
            this.cbx_polarity.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_polarity.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_polarity.RectColor = System.Drawing.Color.DimGray;
            this.cbx_polarity.RectDisableColor = System.Drawing.Color.DimGray;
            this.cbx_polarity.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_polarity.Size = new System.Drawing.Size(151, 26);
            this.cbx_polarity.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_polarity.TabIndex = 100111;
            this.cbx_polarity.Text = "从明到暗";
            this.cbx_polarity.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_polarity.Watermark = "";
            this.cbx_polarity.SelectedIndexChanged += new System.EventHandler(this.cbx_polarity_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(18, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 20);
            this.label9.TabIndex = 100109;
            this.label9.Text = "极       性 ：";
            // 
            // btn_switchEdge
            // 
            this.btn_switchEdge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_switchEdge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_switchEdge.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_switchEdge.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_switchEdge.Location = new System.Drawing.Point(255, 298);
            this.btn_switchEdge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_switchEdge.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_switchEdge.Name = "btn_switchEdge";
            this.btn_switchEdge.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_switchEdge.Size = new System.Drawing.Size(60, 28);
            this.btn_switchEdge.StyleCustomMode = true;
            this.btn_switchEdge.TabIndex = 100113;
            this.btn_switchEdge.Text = "切换";
            this.btn_switchEdge.Click += new System.EventHandler(this.btn_switchEdge_Click);
            // 
            // btn_switchPolarity
            // 
            this.btn_switchPolarity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_switchPolarity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_switchPolarity.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_switchPolarity.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_switchPolarity.Location = new System.Drawing.Point(255, 264);
            this.btn_switchPolarity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_switchPolarity.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_switchPolarity.Name = "btn_switchPolarity";
            this.btn_switchPolarity.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_switchPolarity.Size = new System.Drawing.Size(60, 28);
            this.btn_switchPolarity.StyleCustomMode = true;
            this.btn_switchPolarity.TabIndex = 100112;
            this.btn_switchPolarity.Text = "切换";
            this.btn_switchPolarity.Click += new System.EventHandler(this.btn_switchPolarity_Click);
            // 
            // cbx_edgeSelect
            // 
            this.cbx_edgeSelect.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_edgeSelect.DataSource = null;
            this.cbx_edgeSelect.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_edgeSelect.DropDownWidth = 132;
            this.cbx_edgeSelect.FillColor = System.Drawing.Color.White;
            this.cbx_edgeSelect.FillDisableColor = System.Drawing.Color.White;
            this.cbx_edgeSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_edgeSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_edgeSelect.Items.AddRange(new object[] {
            "内测圆",
            "外侧圆",
            "最优圆"});
            this.cbx_edgeSelect.Location = new System.Drawing.Point(94, 299);
            this.cbx_edgeSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_edgeSelect.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_edgeSelect.Name = "cbx_edgeSelect";
            this.cbx_edgeSelect.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_edgeSelect.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_edgeSelect.RectColor = System.Drawing.Color.DimGray;
            this.cbx_edgeSelect.RectDisableColor = System.Drawing.Color.DimGray;
            this.cbx_edgeSelect.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_edgeSelect.Size = new System.Drawing.Size(151, 26);
            this.cbx_edgeSelect.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_edgeSelect.TabIndex = 100094;
            this.cbx_edgeSelect.Text = "内测圆";
            this.cbx_edgeSelect.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_edgeSelect.Watermark = "";
            this.cbx_edgeSelect.SelectedIndexChanged += new System.EventHandler(this.cbx_edgeSelect_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(18, 299);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 100110;
            this.label7.Text = "边缘选择 ：";
            // 
            // tkb_caliperLength
            // 
            this.tkb_caliperLength.AutoSize = false;
            this.tkb_caliperLength.BackColor = System.Drawing.Color.White;
            this.tkb_caliperLength.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tkb_caliperLength.Location = new System.Drawing.Point(87, 161);
            this.tkb_caliperLength.Margin = new System.Windows.Forms.Padding(2);
            this.tkb_caliperLength.Maximum = 100;
            this.tkb_caliperLength.Minimum = 2;
            this.tkb_caliperLength.Name = "tkb_caliperLength";
            this.tkb_caliperLength.Size = new System.Drawing.Size(165, 19);
            this.tkb_caliperLength.TabIndex = 100108;
            this.tkb_caliperLength.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkb_caliperLength.Value = 2;
            this.tkb_caliperLength.Scroll += new System.EventHandler(this.tkb_caliperLength_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(18, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 100106;
            this.label5.Text = "卡尺长度 ：";
            // 
            // nud_caliperLength
            // 
            this.nud_caliperLength.BackColor = System.Drawing.Color.White;
            this.nud_caliperLength.DecimalPlaces = 0;
            this.nud_caliperLength.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_caliperLength.Incremeent = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_caliperLength.Location = new System.Drawing.Point(251, 153);
            this.nud_caliperLength.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_caliperLength.MaximumSize = new System.Drawing.Size(300, 28);
            this.nud_caliperLength.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_caliperLength.MinimumSize = new System.Drawing.Size(50, 28);
            this.nud_caliperLength.MinValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_caliperLength.Name = "nud_caliperLength";
            this.nud_caliperLength.Size = new System.Drawing.Size(101, 28);
            this.nud_caliperLength.TabIndex = 100107;
            this.nud_caliperLength.Value = 10D;
            this.nud_caliperLength.ValueChanged += new Controls.DValueChanged(this.nud_caliperLength_ValueChanged);
            // 
            // tkb_minScore
            // 
            this.tkb_minScore.AutoSize = false;
            this.tkb_minScore.BackColor = System.Drawing.Color.White;
            this.tkb_minScore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tkb_minScore.Location = new System.Drawing.Point(87, 229);
            this.tkb_minScore.Margin = new System.Windows.Forms.Padding(2);
            this.tkb_minScore.Name = "tkb_minScore";
            this.tkb_minScore.Size = new System.Drawing.Size(165, 19);
            this.tkb_minScore.SmallChange = 10;
            this.tkb_minScore.TabIndex = 100105;
            this.tkb_minScore.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkb_minScore.Value = 10;
            this.tkb_minScore.Scroll += new System.EventHandler(this.tkb_minScore_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(18, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 100103;
            this.label6.Text = "分       数 ：";
            // 
            // nud_minScore
            // 
            this.nud_minScore.BackColor = System.Drawing.Color.White;
            this.nud_minScore.DecimalPlaces = 1;
            this.nud_minScore.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_minScore.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_minScore.Location = new System.Drawing.Point(251, 221);
            this.nud_minScore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_minScore.MaximumSize = new System.Drawing.Size(300, 28);
            this.nud_minScore.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_minScore.MinimumSize = new System.Drawing.Size(50, 28);
            this.nud_minScore.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_minScore.Name = "nud_minScore";
            this.nud_minScore.Size = new System.Drawing.Size(101, 28);
            this.nud_minScore.TabIndex = 100104;
            this.nud_minScore.Value = 0.5D;
            this.nud_minScore.ValueChanged += new Controls.DValueChanged(this.nud_minScore_ValueChanged);
            // 
            // tkb_caliperWidth
            // 
            this.tkb_caliperWidth.AutoSize = false;
            this.tkb_caliperWidth.BackColor = System.Drawing.Color.White;
            this.tkb_caliperWidth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tkb_caliperWidth.Location = new System.Drawing.Point(87, 195);
            this.tkb_caliperWidth.Margin = new System.Windows.Forms.Padding(2);
            this.tkb_caliperWidth.Maximum = 100;
            this.tkb_caliperWidth.Minimum = 2;
            this.tkb_caliperWidth.Name = "tkb_caliperWidth";
            this.tkb_caliperWidth.Size = new System.Drawing.Size(165, 19);
            this.tkb_caliperWidth.TabIndex = 100102;
            this.tkb_caliperWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkb_caliperWidth.Value = 2;
            this.tkb_caliperWidth.Scroll += new System.EventHandler(this.tkb_caliperWidth_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(18, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 100100;
            this.label4.Text = "卡尺宽度 ：";
            // 
            // nud_caliperWidth
            // 
            this.nud_caliperWidth.BackColor = System.Drawing.Color.White;
            this.nud_caliperWidth.DecimalPlaces = 0;
            this.nud_caliperWidth.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_caliperWidth.Incremeent = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_caliperWidth.Location = new System.Drawing.Point(251, 187);
            this.nud_caliperWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_caliperWidth.MaximumSize = new System.Drawing.Size(300, 28);
            this.nud_caliperWidth.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_caliperWidth.MinimumSize = new System.Drawing.Size(50, 28);
            this.nud_caliperWidth.MinValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_caliperWidth.Name = "nud_caliperWidth";
            this.nud_caliperWidth.Size = new System.Drawing.Size(101, 28);
            this.nud_caliperWidth.TabIndex = 100101;
            this.nud_caliperWidth.Value = 10D;
            this.nud_caliperWidth.ValueChanged += new Controls.DValueChanged(this.nud_caliperWidth_ValueChanged);
            // 
            // tkb_ignorePointNum
            // 
            this.tkb_ignorePointNum.AutoSize = false;
            this.tkb_ignorePointNum.BackColor = System.Drawing.Color.White;
            this.tkb_ignorePointNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tkb_ignorePointNum.Location = new System.Drawing.Point(87, 127);
            this.tkb_ignorePointNum.Margin = new System.Windows.Forms.Padding(2);
            this.tkb_ignorePointNum.Maximum = 200;
            this.tkb_ignorePointNum.Name = "tkb_ignorePointNum";
            this.tkb_ignorePointNum.Size = new System.Drawing.Size(165, 19);
            this.tkb_ignorePointNum.TabIndex = 100099;
            this.tkb_ignorePointNum.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkb_ignorePointNum.Scroll += new System.EventHandler(this.tkb_ignorePointNum_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(18, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 100097;
            this.label3.Text = "剔除点数 ：";
            // 
            // nud_ignorePointNum
            // 
            this.nud_ignorePointNum.BackColor = System.Drawing.Color.White;
            this.nud_ignorePointNum.DecimalPlaces = 0;
            this.nud_ignorePointNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_ignorePointNum.Incremeent = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_ignorePointNum.Location = new System.Drawing.Point(251, 119);
            this.nud_ignorePointNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_ignorePointNum.MaximumSize = new System.Drawing.Size(300, 28);
            this.nud_ignorePointNum.MaxValue = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nud_ignorePointNum.MinimumSize = new System.Drawing.Size(50, 28);
            this.nud_ignorePointNum.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_ignorePointNum.Name = "nud_ignorePointNum";
            this.nud_ignorePointNum.Size = new System.Drawing.Size(101, 28);
            this.nud_ignorePointNum.TabIndex = 100098;
            this.nud_ignorePointNum.Value = 30D;
            this.nud_ignorePointNum.ValueChanged += new Controls.DValueChanged(this.nud_ignorePointNum_ValueChanged);
            // 
            // nud_threshold
            // 
            this.nud_threshold.BackColor = System.Drawing.Color.White;
            this.nud_threshold.DecimalPlaces = 0;
            this.nud_threshold.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_threshold.Incremeent = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_threshold.Location = new System.Drawing.Point(251, 51);
            this.nud_threshold.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_threshold.MaximumSize = new System.Drawing.Size(300, 28);
            this.nud_threshold.MaxValue = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.nud_threshold.MinimumSize = new System.Drawing.Size(50, 28);
            this.nud_threshold.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_threshold.Name = "nud_threshold";
            this.nud_threshold.Size = new System.Drawing.Size(101, 28);
            this.nud_threshold.TabIndex = 100096;
            this.nud_threshold.Value = 30D;
            this.nud_threshold.ValueChanged += new Controls.DValueChanged(this.nud_threshold_ValueChanged);
            // 
            // tkb_caliperNum
            // 
            this.tkb_caliperNum.AutoSize = false;
            this.tkb_caliperNum.BackColor = System.Drawing.Color.White;
            this.tkb_caliperNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tkb_caliperNum.Location = new System.Drawing.Point(87, 93);
            this.tkb_caliperNum.Margin = new System.Windows.Forms.Padding(2);
            this.tkb_caliperNum.Maximum = 200;
            this.tkb_caliperNum.Minimum = 3;
            this.tkb_caliperNum.Name = "tkb_caliperNum";
            this.tkb_caliperNum.Size = new System.Drawing.Size(165, 19);
            this.tkb_caliperNum.SmallChange = 5;
            this.tkb_caliperNum.TabIndex = 100095;
            this.tkb_caliperNum.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkb_caliperNum.Value = 3;
            this.tkb_caliperNum.Scroll += new System.EventHandler(this.tkb_caliperNum_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 100093;
            this.label1.Text = "卡尺数量 ：";
            // 
            // nud_caliperNum
            // 
            this.nud_caliperNum.BackColor = System.Drawing.Color.White;
            this.nud_caliperNum.DecimalPlaces = 0;
            this.nud_caliperNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_caliperNum.Incremeent = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_caliperNum.Location = new System.Drawing.Point(251, 85);
            this.nud_caliperNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_caliperNum.MaximumSize = new System.Drawing.Size(300, 28);
            this.nud_caliperNum.MaxValue = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nud_caliperNum.MinimumSize = new System.Drawing.Size(50, 28);
            this.nud_caliperNum.MinValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nud_caliperNum.Name = "nud_caliperNum";
            this.nud_caliperNum.Size = new System.Drawing.Size(101, 28);
            this.nud_caliperNum.TabIndex = 100094;
            this.nud_caliperNum.Value = 100D;
            this.nud_caliperNum.ValueChanged += new Controls.DValueChanged(this.nud_caliperNum_ValueChanged);
            // 
            // tkb_threshold
            // 
            this.tkb_threshold.AutoSize = false;
            this.tkb_threshold.BackColor = System.Drawing.Color.White;
            this.tkb_threshold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tkb_threshold.Location = new System.Drawing.Point(87, 59);
            this.tkb_threshold.Margin = new System.Windows.Forms.Padding(2);
            this.tkb_threshold.Maximum = 254;
            this.tkb_threshold.Minimum = 1;
            this.tkb_threshold.Name = "tkb_threshold";
            this.tkb_threshold.Size = new System.Drawing.Size(165, 19);
            this.tkb_threshold.SmallChange = 5;
            this.tkb_threshold.TabIndex = 100092;
            this.tkb_threshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkb_threshold.Value = 1;
            this.tkb_threshold.Scroll += new System.EventHandler(this.tkb_threshold_Scroll);
            // 
            // uiLine1
            // 
            this.uiLine1.FillColor = System.Drawing.Color.White;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(8, 18);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(356, 29);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 100091;
            this.uiLine1.Text = "匹配参数";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(18, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 20);
            this.label14.TabIndex = 10;
            this.label14.Text = "阈       值 ：";
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.White;
            this.tabPage9.Controls.Add(this.ckb_showCross);
            this.tabPage9.Controls.Add(this.ckb_showCircle);
            this.tabPage9.Controls.Add(this.ckb_showFeature);
            this.tabPage9.Controls.Add(this.ckb_showCaliper);
            this.tabPage9.Location = new System.Drawing.Point(0, 28);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(378, 467);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "显示";
            // 
            // ckb_showCross
            // 
            this.ckb_showCross.Checked = true;
            this.ckb_showCross.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_showCross.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_showCross.Location = new System.Drawing.Point(14, 110);
            this.ckb_showCross.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_showCross.Name = "ckb_showCross";
            this.ckb_showCross.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_showCross.Size = new System.Drawing.Size(131, 24);
            this.ckb_showCross.TabIndex = 141;
            this.ckb_showCross.Text = "显示圆心";
            this.ckb_showCross.Click += new System.EventHandler(this.ckb_showCross_Click);
            // 
            // ckb_showCircle
            // 
            this.ckb_showCircle.Checked = true;
            this.ckb_showCircle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_showCircle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_showCircle.Location = new System.Drawing.Point(14, 80);
            this.ckb_showCircle.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_showCircle.Name = "ckb_showCircle";
            this.ckb_showCircle.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_showCircle.Size = new System.Drawing.Size(131, 24);
            this.ckb_showCircle.TabIndex = 140;
            this.ckb_showCircle.Text = "显示圆";
            this.ckb_showCircle.Click += new System.EventHandler(this.ckb_showCircle_Click);
            // 
            // ckb_showFeature
            // 
            this.ckb_showFeature.Checked = true;
            this.ckb_showFeature.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_showFeature.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_showFeature.Location = new System.Drawing.Point(14, 50);
            this.ckb_showFeature.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_showFeature.Name = "ckb_showFeature";
            this.ckb_showFeature.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_showFeature.Size = new System.Drawing.Size(131, 24);
            this.ckb_showFeature.TabIndex = 139;
            this.ckb_showFeature.Text = "显示特征点";
            this.ckb_showFeature.Click += new System.EventHandler(this.ckb_showFeature_Click);
            // 
            // ckb_showCaliper
            // 
            this.ckb_showCaliper.Checked = true;
            this.ckb_showCaliper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_showCaliper.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_showCaliper.Location = new System.Drawing.Point(14, 20);
            this.ckb_showCaliper.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_showCaliper.Name = "ckb_showCaliper";
            this.ckb_showCaliper.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_showCaliper.Size = new System.Drawing.Size(131, 24);
            this.ckb_showCaliper.TabIndex = 138;
            this.ckb_showCaliper.Text = "显示卡尺";
            this.ckb_showCaliper.Click += new System.EventHandler(this.ckb_showCaliper_Click);
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
            this.dgv_result.BackgroundColor = System.Drawing.Color.White;
            this.dgv_result.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column9,
            this.Column10,
            this.Column12});
            this.dgv_result.Location = new System.Drawing.Point(13, 18);
            this.dgv_result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.ReadOnly = true;
            this.dgv_result.RowHeadersVisible = false;
            this.dgv_result.RowTemplate.Height = 23;
            this.dgv_result.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_result.Size = new System.Drawing.Size(346, 444);
            this.dgv_result.TabIndex = 12;
            this.dgv_result.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_result_CellClick);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "编号";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 85;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "行";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 86;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "列";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 86;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "半径";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column12.Width = 86;
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
            // Frm_FindCircleTool
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
            this.ExtendSymbol = 61758;
            this.ExtendSymbolOffset = new System.Drawing.Point(0, 2);
            this.ExtendSymbolSize = 18;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1040, 618);
            this.MinimumSize = new System.Drawing.Size(1040, 618);
            this.Name = "Frm_FindCircleTool";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowIcon = true;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "查找圆形";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.ExtendBoxClick += new System.EventHandler(this.Frm_MatchTool_ExtendBoxClick);
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
            ((System.ComponentModel.ISupportInitialize)(this.tkb_caliperLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_minScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_caliperWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_ignorePointNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_caliperNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_threshold)).EndInit();
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
        private System.Windows.Forms.TabPage tabPage10;
        internal System.Windows.Forms.DataGridView dgv_result;
        internal Sunny.UI.UICheckBox ckb_showCross;
        internal Sunny.UI.UICheckBox ckb_showCircle;
        internal Sunny.UI.UICheckBox ckb_showFeature;
        internal Sunny.UI.UICheckBox ckb_showCaliper;
        internal Sunny.UI.UIButton btn_close;
        internal Sunny.UI.UIButton btn_runTask;
        internal Sunny.UI.UIButton btn_runTool;
        private System.Windows.Forms.ToolStripButton 保存toolStripButton1;
        internal System.Windows.Forms.TrackBar tkb_threshold;
        private Sunny.UI.UILine uiLine1;
        public System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TrackBar tkb_caliperWidth;
        public System.Windows.Forms.Label label4;
        public Controls.CNumericUpDown nud_caliperWidth;
        internal System.Windows.Forms.TrackBar tkb_ignorePointNum;
        public System.Windows.Forms.Label label3;
        public Controls.CNumericUpDown nud_ignorePointNum;
        public Controls.CNumericUpDown nud_threshold;
        internal System.Windows.Forms.TrackBar tkb_caliperNum;
        public System.Windows.Forms.Label label1;
        public Controls.CNumericUpDown nud_caliperNum;
        internal System.Windows.Forms.TrackBar tkb_caliperLength;
        public System.Windows.Forms.Label label5;
        public Controls.CNumericUpDown nud_caliperLength;
        internal System.Windows.Forms.TrackBar tkb_minScore;
        public System.Windows.Forms.Label label6;
        public Controls.CNumericUpDown nud_minScore;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label9;
        internal Sunny.UI.UIButton btn_switchEdge;
        internal Sunny.UI.UIButton btn_switchPolarity;
        internal Sunny.UI.UIComboBox cbx_edgeSelect;
        internal Sunny.UI.UIComboBox cbx_polarity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        internal Sunny.UI.UICheckBox ckb_taskFailKeepRun;

    }
}