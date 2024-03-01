namespace VM_Pro
{
    partial class Frm_GlueRegion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_GlueRegion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiTabControl2 = new Sunny.UI.UITabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btn_clearRegion = new Sunny.UI.UIButton();
            this.lbl_templateStatu = new System.Windows.Forms.Label();
            this.lbl_runResult = new System.Windows.Forms.Label();
            this.lbl_regionNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_saveTemplate = new Sunny.UI.UIButton();
            this.btn_updateImage = new Sunny.UI.UIButton();
            this.btn_glueRegion = new Sunny.UI.UIButton();
            this.nud_dilationSize = new Controls.CNumericUpDown();
            this.ckb_roundnessSelect = new Sunny.UI.UICheckBox();
            this.ckb_colSelect = new Sunny.UI.UICheckBox();
            this.ckb_rowSelect = new Sunny.UI.UICheckBox();
            this.ckb_areaSelect = new Sunny.UI.UICheckBox();
            this.cbx_searchRegionType = new Sunny.UI.UIComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_subRegion = new Sunny.UI.UIButton();
            this.btn_addRegion = new Sunny.UI.UIButton();
            this.btn_followCurPose = new Sunny.UI.UIButton();
            this.label9 = new System.Windows.Forms.Label();
            this.nud_minRoundness = new Controls.CNumericUpDown();
            this.nud_maxRoundness = new Controls.CNumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.nud_minCol = new Controls.CNumericUpDown();
            this.nud_maxCol = new Controls.CNumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.uiLine6 = new Sunny.UI.UILine();
            this.nud_minRow = new Controls.CNumericUpDown();
            this.nud_minArea = new Controls.CNumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nud_maxRow = new Controls.CNumericUpDown();
            this.nud_maxArea = new Controls.CNumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.nud_maxThreshold = new Controls.CNumericUpDown();
            this.nud_minThreshold = new Controls.CNumericUpDown();
            this.tck_maxThreshold = new System.Windows.Forms.TrackBar();
            this.tck_minThreshold = new System.Windows.Forms.TrackBar();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.适应窗体toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.图像信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiLine4 = new Sunny.UI.UILine();
            this.panel1.SuspendLayout();
            this.uiTabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tck_maxThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tck_minThreshold)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.uiTabControl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 487);
            this.panel1.TabIndex = 24;
            // 
            // uiTabControl2
            // 
            this.uiTabControl2.Controls.Add(this.tabPage5);
            this.uiTabControl2.Controls.Add(this.tabPage6);
            this.uiTabControl2.Controls.Add(this.tabPage1);
            this.uiTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl2.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl2.FillColor = System.Drawing.Color.White;
            this.uiTabControl2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl2.ItemSize = new System.Drawing.Size(80, 28);
            this.uiTabControl2.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl2.MainPage = "";
            this.uiTabControl2.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl2.Name = "uiTabControl2";
            this.uiTabControl2.SelectedIndex = 0;
            this.uiTabControl2.Size = new System.Drawing.Size(378, 487);
            this.uiTabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl2.Style = Sunny.UI.UIStyle.Custom;
            this.uiTabControl2.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.uiTabControl2.TabIndex = 108;
            this.uiTabControl2.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiTabControl2.TabUnSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.White;
            this.tabPage5.Controls.Add(this.btn_clearRegion);
            this.tabPage5.Controls.Add(this.lbl_templateStatu);
            this.tabPage5.Controls.Add(this.lbl_runResult);
            this.tabPage5.Controls.Add(this.lbl_regionNum);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.btn_saveTemplate);
            this.tabPage5.Controls.Add(this.btn_updateImage);
            this.tabPage5.Controls.Add(this.btn_glueRegion);
            this.tabPage5.Controls.Add(this.nud_dilationSize);
            this.tabPage5.Controls.Add(this.ckb_roundnessSelect);
            this.tabPage5.Controls.Add(this.ckb_colSelect);
            this.tabPage5.Controls.Add(this.ckb_rowSelect);
            this.tabPage5.Controls.Add(this.ckb_areaSelect);
            this.tabPage5.Controls.Add(this.cbx_searchRegionType);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.btn_subRegion);
            this.tabPage5.Controls.Add(this.btn_addRegion);
            this.tabPage5.Controls.Add(this.btn_followCurPose);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.nud_minRoundness);
            this.tabPage5.Controls.Add(this.nud_maxRoundness);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.nud_minCol);
            this.tabPage5.Controls.Add(this.nud_maxCol);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.uiLine6);
            this.tabPage5.Controls.Add(this.nud_minRow);
            this.tabPage5.Controls.Add(this.nud_minArea);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.nud_maxRow);
            this.tabPage5.Controls.Add(this.nud_maxArea);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.label18);
            this.tabPage5.Controls.Add(this.label124);
            this.tabPage5.Controls.Add(this.nud_maxThreshold);
            this.tabPage5.Controls.Add(this.nud_minThreshold);
            this.tabPage5.Controls.Add(this.tck_maxThreshold);
            this.tabPage5.Controls.Add(this.tck_minThreshold);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.label20);
            this.tabPage5.Location = new System.Drawing.Point(0, 28);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(378, 459);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "参数";
            // 
            // btn_clearRegion
            // 
            this.btn_clearRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clearRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clearRegion.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_clearRegion.Location = new System.Drawing.Point(323, 20);
            this.btn_clearRegion.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_clearRegion.Name = "btn_clearRegion";
            this.btn_clearRegion.Size = new System.Drawing.Size(32, 28);
            this.btn_clearRegion.Style = Sunny.UI.UIStyle.Custom;
            this.btn_clearRegion.TabIndex = 258;
            this.btn_clearRegion.Text = "清";
            this.btn_clearRegion.Click += new System.EventHandler(this.btn_clearRegion_Click);
            // 
            // lbl_templateStatu
            // 
            this.lbl_templateStatu.AutoSize = true;
            this.lbl_templateStatu.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_templateStatu.Location = new System.Drawing.Point(182, 361);
            this.lbl_templateStatu.Name = "lbl_templateStatu";
            this.lbl_templateStatu.Size = new System.Drawing.Size(51, 20);
            this.lbl_templateStatu.TabIndex = 257;
            this.lbl_templateStatu.Text = "未保存";
            // 
            // lbl_runResult
            // 
            this.lbl_runResult.AutoSize = true;
            this.lbl_runResult.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_runResult.Location = new System.Drawing.Point(141, 361);
            this.lbl_runResult.Name = "lbl_runResult";
            this.lbl_runResult.Size = new System.Drawing.Size(51, 20);
            this.lbl_runResult.TabIndex = 256;
            this.lbl_runResult.Text = "模板：";
            // 
            // lbl_regionNum
            // 
            this.lbl_regionNum.AutoSize = true;
            this.lbl_regionNum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_regionNum.Location = new System.Drawing.Point(84, 361);
            this.lbl_regionNum.Name = "lbl_regionNum";
            this.lbl_regionNum.Size = new System.Drawing.Size(35, 20);
            this.lbl_regionNum.TabIndex = 255;
            this.lbl_regionNum.Text = "0 个";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 254;
            this.label3.Text = "胶域数量：";
            // 
            // btn_saveTemplate
            // 
            this.btn_saveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_saveTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_saveTemplate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_saveTemplate.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_saveTemplate.Location = new System.Drawing.Point(186, 414);
            this.btn_saveTemplate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_saveTemplate.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_saveTemplate.Name = "btn_saveTemplate";
            this.btn_saveTemplate.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_saveTemplate.Size = new System.Drawing.Size(75, 32);
            this.btn_saveTemplate.StyleCustomMode = true;
            this.btn_saveTemplate.TabIndex = 253;
            this.btn_saveTemplate.Text = "保存模板";
            this.btn_saveTemplate.Click += new System.EventHandler(this.btn_saveTemplate_Click);
            // 
            // btn_updateImage
            // 
            this.btn_updateImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_updateImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_updateImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_updateImage.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_updateImage.Location = new System.Drawing.Point(103, 414);
            this.btn_updateImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_updateImage.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_updateImage.Name = "btn_updateImage";
            this.btn_updateImage.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_updateImage.Size = new System.Drawing.Size(75, 32);
            this.btn_updateImage.StyleCustomMode = true;
            this.btn_updateImage.TabIndex = 252;
            this.btn_updateImage.Text = "更新图像";
            this.btn_updateImage.Click += new System.EventHandler(this.btn_updateImage_Click);
            // 
            // btn_glueRegion
            // 
            this.btn_glueRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_glueRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_glueRegion.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_glueRegion.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_glueRegion.Location = new System.Drawing.Point(20, 414);
            this.btn_glueRegion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_glueRegion.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_glueRegion.Name = "btn_glueRegion";
            this.btn_glueRegion.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_glueRegion.Size = new System.Drawing.Size(75, 32);
            this.btn_glueRegion.StyleCustomMode = true;
            this.btn_glueRegion.TabIndex = 251;
            this.btn_glueRegion.Text = "分割";
            this.btn_glueRegion.Click += new System.EventHandler(this.btn_glueRegion_Click);
            // 
            // nud_dilationSize
            // 
            this.nud_dilationSize.BackColor = System.Drawing.Color.White;
            this.nud_dilationSize.DecimalPlaces = 0;
            this.nud_dilationSize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_dilationSize.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_dilationSize.Location = new System.Drawing.Point(72, 51);
            this.nud_dilationSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_dilationSize.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_dilationSize.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_dilationSize.MinimumSize = new System.Drawing.Size(60, 26);
            this.nud_dilationSize.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_dilationSize.Name = "nud_dilationSize";
            this.nud_dilationSize.Size = new System.Drawing.Size(109, 26);
            this.nud_dilationSize.TabIndex = 245;
            this.nud_dilationSize.TabStop = false;
            this.nud_dilationSize.Value = 5D;
            this.nud_dilationSize.ValueChanged += new Controls.DValueChanged(this.nud_dilationSize_ValueChanged);
            // 
            // ckb_roundnessSelect
            // 
            this.ckb_roundnessSelect.Checked = true;
            this.ckb_roundnessSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_roundnessSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_roundnessSelect.Location = new System.Drawing.Point(326, 318);
            this.ckb_roundnessSelect.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_roundnessSelect.Name = "ckb_roundnessSelect";
            this.ckb_roundnessSelect.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_roundnessSelect.Size = new System.Drawing.Size(26, 24);
            this.ckb_roundnessSelect.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_roundnessSelect.TabIndex = 250;
            this.ckb_roundnessSelect.Click += new System.EventHandler(this.ckb_roundnessSelect_Click);
            // 
            // ckb_colSelect
            // 
            this.ckb_colSelect.Checked = true;
            this.ckb_colSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_colSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_colSelect.Location = new System.Drawing.Point(326, 287);
            this.ckb_colSelect.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_colSelect.Name = "ckb_colSelect";
            this.ckb_colSelect.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_colSelect.Size = new System.Drawing.Size(26, 24);
            this.ckb_colSelect.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_colSelect.TabIndex = 249;
            this.ckb_colSelect.Click += new System.EventHandler(this.ckb_colSelect_Click);
            // 
            // ckb_rowSelect
            // 
            this.ckb_rowSelect.Checked = true;
            this.ckb_rowSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_rowSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_rowSelect.Location = new System.Drawing.Point(326, 256);
            this.ckb_rowSelect.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_rowSelect.Name = "ckb_rowSelect";
            this.ckb_rowSelect.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_rowSelect.Size = new System.Drawing.Size(26, 24);
            this.ckb_rowSelect.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_rowSelect.TabIndex = 248;
            this.ckb_rowSelect.Click += new System.EventHandler(this.ckb_rowSelect_Click);
            // 
            // ckb_areaSelect
            // 
            this.ckb_areaSelect.Checked = true;
            this.ckb_areaSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_areaSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_areaSelect.Location = new System.Drawing.Point(326, 225);
            this.ckb_areaSelect.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_areaSelect.Name = "ckb_areaSelect";
            this.ckb_areaSelect.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_areaSelect.Size = new System.Drawing.Size(26, 24);
            this.ckb_areaSelect.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_areaSelect.TabIndex = 247;
            this.ckb_areaSelect.Click += new System.EventHandler(this.ckb_areaSelect_Click);
            // 
            // cbx_searchRegionType
            // 
            this.cbx_searchRegionType.DataSource = null;
            this.cbx_searchRegionType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_searchRegionType.DropDownWidth = 106;
            this.cbx_searchRegionType.FillColor = System.Drawing.Color.White;
            this.cbx_searchRegionType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_searchRegionType.Items.AddRange(new object[] {
            "整幅图像",
            "矩形",
            "仿射矩形",
            "圆",
            "输入区域"});
            this.cbx_searchRegionType.Location = new System.Drawing.Point(75, 20);
            this.cbx_searchRegionType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_searchRegionType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_searchRegionType.Name = "cbx_searchRegionType";
            this.cbx_searchRegionType.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_searchRegionType.Radius = 0;
            this.cbx_searchRegionType.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbx_searchRegionType.Size = new System.Drawing.Size(106, 28);
            this.cbx_searchRegionType.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_searchRegionType.TabIndex = 246;
            this.cbx_searchRegionType.Text = "整幅图像";
            this.cbx_searchRegionType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_searchRegionType.SelectedIndexChanged += new System.EventHandler(this.cbx_searchRegionType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 20);
            this.label7.TabIndex = 244;
            this.label7.Text = "膨   胀 ：";
            // 
            // btn_subRegion
            // 
            this.btn_subRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_subRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_subRegion.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_subRegion.Location = new System.Drawing.Point(289, 20);
            this.btn_subRegion.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_subRegion.Name = "btn_subRegion";
            this.btn_subRegion.Size = new System.Drawing.Size(32, 28);
            this.btn_subRegion.Style = Sunny.UI.UIStyle.Custom;
            this.btn_subRegion.TabIndex = 243;
            this.btn_subRegion.Text = "减";
            this.btn_subRegion.Click += new System.EventHandler(this.btn_subRegion_Click);
            // 
            // btn_addRegion
            // 
            this.btn_addRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addRegion.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_addRegion.Location = new System.Drawing.Point(255, 20);
            this.btn_addRegion.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_addRegion.Name = "btn_addRegion";
            this.btn_addRegion.Size = new System.Drawing.Size(32, 28);
            this.btn_addRegion.Style = Sunny.UI.UIStyle.Custom;
            this.btn_addRegion.TabIndex = 242;
            this.btn_addRegion.Text = "加";
            this.btn_addRegion.Click += new System.EventHandler(this.btn_addRegion_Click);
            // 
            // btn_followCurPose
            // 
            this.btn_followCurPose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_followCurPose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_followCurPose.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_followCurPose.Location = new System.Drawing.Point(185, 20);
            this.btn_followCurPose.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_followCurPose.Name = "btn_followCurPose";
            this.btn_followCurPose.Size = new System.Drawing.Size(60, 28);
            this.btn_followCurPose.Style = Sunny.UI.UIStyle.Custom;
            this.btn_followCurPose.TabIndex = 123;
            this.btn_followCurPose.Text = "跟随";
            this.btn_followCurPose.Click += new System.EventHandler(this.btn_followCurPose_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(323, 195);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 20);
            this.label9.TabIndex = 237;
            this.label9.Text = "启用";
            // 
            // nud_minRoundness
            // 
            this.nud_minRoundness.BackColor = System.Drawing.Color.White;
            this.nud_minRoundness.DecimalPlaces = 2;
            this.nud_minRoundness.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_minRoundness.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_minRoundness.Location = new System.Drawing.Point(76, 313);
            this.nud_minRoundness.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_minRoundness.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_minRoundness.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_minRoundness.MinimumSize = new System.Drawing.Size(60, 26);
            this.nud_minRoundness.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_minRoundness.Name = "nud_minRoundness";
            this.nud_minRoundness.Size = new System.Drawing.Size(118, 26);
            this.nud_minRoundness.TabIndex = 230;
            this.nud_minRoundness.TabStop = false;
            this.nud_minRoundness.Value = 0D;
            this.nud_minRoundness.ValueChanged += new Controls.DValueChanged(this.nud_minRoundness_ValueChanged);
            // 
            // nud_maxRoundness
            // 
            this.nud_maxRoundness.BackColor = System.Drawing.Color.White;
            this.nud_maxRoundness.DecimalPlaces = 2;
            this.nud_maxRoundness.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_maxRoundness.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_maxRoundness.Location = new System.Drawing.Point(201, 313);
            this.nud_maxRoundness.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_maxRoundness.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_maxRoundness.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_maxRoundness.MinimumSize = new System.Drawing.Size(60, 26);
            this.nud_maxRoundness.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_maxRoundness.Name = "nud_maxRoundness";
            this.nud_maxRoundness.Size = new System.Drawing.Size(118, 26);
            this.nud_maxRoundness.TabIndex = 229;
            this.nud_maxRoundness.TabStop = false;
            this.nud_maxRoundness.Value = 1D;
            this.nud_maxRoundness.ValueChanged += new Controls.DValueChanged(this.nud_maxRoundness_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 317);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 20);
            this.label16.TabIndex = 228;
            this.label16.Text = "圆   度 ：";
            // 
            // nud_minCol
            // 
            this.nud_minCol.BackColor = System.Drawing.Color.White;
            this.nud_minCol.DecimalPlaces = 0;
            this.nud_minCol.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_minCol.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_minCol.Location = new System.Drawing.Point(76, 282);
            this.nud_minCol.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_minCol.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_minCol.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_minCol.MinimumSize = new System.Drawing.Size(60, 26);
            this.nud_minCol.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_minCol.Name = "nud_minCol";
            this.nud_minCol.Size = new System.Drawing.Size(118, 26);
            this.nud_minCol.TabIndex = 227;
            this.nud_minCol.TabStop = false;
            this.nud_minCol.Value = 0D;
            this.nud_minCol.ValueChanged += new Controls.DValueChanged(this.nud_minCol_ValueChanged);
            // 
            // nud_maxCol
            // 
            this.nud_maxCol.BackColor = System.Drawing.Color.White;
            this.nud_maxCol.DecimalPlaces = 0;
            this.nud_maxCol.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_maxCol.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_maxCol.Location = new System.Drawing.Point(201, 282);
            this.nud_maxCol.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_maxCol.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_maxCol.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_maxCol.MinimumSize = new System.Drawing.Size(60, 26);
            this.nud_maxCol.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_maxCol.Name = "nud_maxCol";
            this.nud_maxCol.Size = new System.Drawing.Size(118, 26);
            this.nud_maxCol.TabIndex = 226;
            this.nud_maxCol.TabStop = false;
            this.nud_maxCol.Value = 10000D;
            this.nud_maxCol.ValueChanged += new Controls.DValueChanged(this.nud_maxCol_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 286);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 20);
            this.label11.TabIndex = 225;
            this.label11.Text = "列坐标 ：";
            // 
            // uiLine6
            // 
            this.uiLine6.FillColor = System.Drawing.Color.White;
            this.uiLine6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uiLine6.Location = new System.Drawing.Point(8, 158);
            this.uiLine6.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine6.Name = "uiLine6";
            this.uiLine6.Size = new System.Drawing.Size(362, 29);
            this.uiLine6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine6.TabIndex = 224;
            this.uiLine6.Text = "筛选";
            this.uiLine6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nud_minRow
            // 
            this.nud_minRow.BackColor = System.Drawing.Color.White;
            this.nud_minRow.DecimalPlaces = 0;
            this.nud_minRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_minRow.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_minRow.Location = new System.Drawing.Point(76, 251);
            this.nud_minRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_minRow.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_minRow.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_minRow.MinimumSize = new System.Drawing.Size(60, 26);
            this.nud_minRow.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_minRow.Name = "nud_minRow";
            this.nud_minRow.Size = new System.Drawing.Size(118, 26);
            this.nud_minRow.TabIndex = 223;
            this.nud_minRow.TabStop = false;
            this.nud_minRow.Value = 0D;
            this.nud_minRow.ValueChanged += new Controls.DValueChanged(this.nud_minRow_ValueChanged);
            // 
            // nud_minArea
            // 
            this.nud_minArea.BackColor = System.Drawing.Color.White;
            this.nud_minArea.DecimalPlaces = 0;
            this.nud_minArea.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_minArea.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_minArea.Location = new System.Drawing.Point(76, 220);
            this.nud_minArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_minArea.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_minArea.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nud_minArea.MinimumSize = new System.Drawing.Size(60, 26);
            this.nud_minArea.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_minArea.Name = "nud_minArea";
            this.nud_minArea.Size = new System.Drawing.Size(118, 26);
            this.nud_minArea.TabIndex = 222;
            this.nud_minArea.TabStop = false;
            this.nud_minArea.Value = 10D;
            this.nud_minArea.ValueChanged += new Controls.DValueChanged(this.nud_minArea_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(204, 195);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 20);
            this.label12.TabIndex = 221;
            this.label12.Text = "上限";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(78, 195);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 20);
            this.label13.TabIndex = 220;
            this.label13.Text = "下限";
            // 
            // nud_maxRow
            // 
            this.nud_maxRow.BackColor = System.Drawing.Color.White;
            this.nud_maxRow.DecimalPlaces = 0;
            this.nud_maxRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_maxRow.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_maxRow.Location = new System.Drawing.Point(201, 251);
            this.nud_maxRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_maxRow.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_maxRow.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_maxRow.MinimumSize = new System.Drawing.Size(60, 26);
            this.nud_maxRow.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_maxRow.Name = "nud_maxRow";
            this.nud_maxRow.Size = new System.Drawing.Size(118, 26);
            this.nud_maxRow.TabIndex = 219;
            this.nud_maxRow.TabStop = false;
            this.nud_maxRow.Value = 10000D;
            this.nud_maxRow.ValueChanged += new Controls.DValueChanged(this.nud_maxRow_ValueChanged);
            // 
            // nud_maxArea
            // 
            this.nud_maxArea.BackColor = System.Drawing.Color.White;
            this.nud_maxArea.DecimalPlaces = 0;
            this.nud_maxArea.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_maxArea.Incremeent = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_maxArea.Location = new System.Drawing.Point(201, 220);
            this.nud_maxArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_maxArea.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_maxArea.MaxValue = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nud_maxArea.MinimumSize = new System.Drawing.Size(60, 26);
            this.nud_maxArea.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_maxArea.Name = "nud_maxArea";
            this.nud_maxArea.Size = new System.Drawing.Size(118, 26);
            this.nud_maxArea.TabIndex = 218;
            this.nud_maxArea.TabStop = false;
            this.nud_maxArea.Value = 100000000D;
            this.nud_maxArea.ValueChanged += new Controls.DValueChanged(this.nud_maxArea_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 255);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 20);
            this.label17.TabIndex = 216;
            this.label17.Text = "行坐标 ：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 224);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 20);
            this.label18.TabIndex = 214;
            this.label18.Text = "面   积 ：";
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label124.Location = new System.Drawing.Point(16, 22);
            this.label124.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(67, 20);
            this.label124.TabIndex = 86;
            this.label124.Text = "区   域 ：";
            // 
            // nud_maxThreshold
            // 
            this.nud_maxThreshold.BackColor = System.Drawing.Color.White;
            this.nud_maxThreshold.DecimalPlaces = 0;
            this.nud_maxThreshold.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_maxThreshold.Incremeent = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_maxThreshold.Location = new System.Drawing.Point(254, 113);
            this.nud_maxThreshold.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nud_maxThreshold.MaximumSize = new System.Drawing.Size(180, 26);
            this.nud_maxThreshold.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_maxThreshold.MinimumSize = new System.Drawing.Size(30, 26);
            this.nud_maxThreshold.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_maxThreshold.Name = "nud_maxThreshold";
            this.nud_maxThreshold.Size = new System.Drawing.Size(100, 26);
            this.nud_maxThreshold.TabIndex = 103;
            this.nud_maxThreshold.TabStop = false;
            this.nud_maxThreshold.Value = 0D;
            this.nud_maxThreshold.ValueChanged += new Controls.DValueChanged(this.nud_maxThreshold_ValueChanged);
            // 
            // nud_minThreshold
            // 
            this.nud_minThreshold.BackColor = System.Drawing.Color.White;
            this.nud_minThreshold.DecimalPlaces = 0;
            this.nud_minThreshold.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_minThreshold.Incremeent = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_minThreshold.Location = new System.Drawing.Point(254, 80);
            this.nud_minThreshold.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nud_minThreshold.MaximumSize = new System.Drawing.Size(180, 26);
            this.nud_minThreshold.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_minThreshold.MinimumSize = new System.Drawing.Size(30, 26);
            this.nud_minThreshold.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_minThreshold.Name = "nud_minThreshold";
            this.nud_minThreshold.Size = new System.Drawing.Size(100, 26);
            this.nud_minThreshold.TabIndex = 102;
            this.nud_minThreshold.TabStop = false;
            this.nud_minThreshold.Value = 0D;
            this.nud_minThreshold.ValueChanged += new Controls.DValueChanged(this.nud_minThreshold_ValueChanged);
            // 
            // tck_maxThreshold
            // 
            this.tck_maxThreshold.AutoSize = false;
            this.tck_maxThreshold.BackColor = System.Drawing.Color.White;
            this.tck_maxThreshold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tck_maxThreshold.Location = new System.Drawing.Point(69, 121);
            this.tck_maxThreshold.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
            this.tck_maxThreshold.Maximum = 255;
            this.tck_maxThreshold.Name = "tck_maxThreshold";
            this.tck_maxThreshold.Size = new System.Drawing.Size(182, 20);
            this.tck_maxThreshold.TabIndex = 97;
            this.tck_maxThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tck_maxThreshold.Value = 100;
            this.tck_maxThreshold.Scroll += new System.EventHandler(this.tck_maxThreshold_Scroll);
            // 
            // tck_minThreshold
            // 
            this.tck_minThreshold.AutoSize = false;
            this.tck_minThreshold.BackColor = System.Drawing.Color.White;
            this.tck_minThreshold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tck_minThreshold.Location = new System.Drawing.Point(69, 88);
            this.tck_minThreshold.Margin = new System.Windows.Forms.Padding(0, 3, 2, 3);
            this.tck_minThreshold.Maximum = 255;
            this.tck_minThreshold.Name = "tck_minThreshold";
            this.tck_minThreshold.Size = new System.Drawing.Size(182, 20);
            this.tck_minThreshold.TabIndex = 95;
            this.tck_minThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tck_minThreshold.Scroll += new System.EventHandler(this.tck_minThreshold_Scroll);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 86);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 20);
            this.label19.TabIndex = 94;
            this.label19.Text = "下   限 ：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 118);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 20);
            this.label20.TabIndex = 96;
            this.label20.Text = "上   限 ：";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.White;
            this.tabPage6.Location = new System.Drawing.Point(0, 28);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(378, 459);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "处理";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.dgv_result);
            this.tabPage1.Location = new System.Drawing.Point(0, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(378, 459);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "结果";
            // 
            // dgv_result
            // 
            this.dgv_result.AllowUserToAddRows = false;
            this.dgv_result.AllowUserToResizeRows = false;
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column18,
            this.Column17,
            this.Column1,
            this.Column2});
            this.dgv_result.Location = new System.Drawing.Point(16, 16);
            this.dgv_result.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.ReadOnly = true;
            this.dgv_result.RowHeadersVisible = false;
            this.dgv_result.RowTemplate.Height = 23;
            this.dgv_result.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_result.Size = new System.Drawing.Size(346, 428);
            this.dgv_result.TabIndex = 93;
            this.dgv_result.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_result_CellClick);
            // 
            // Column18
            // 
            this.Column18.HeaderText = "编号";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 85;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "面积";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 86;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "行";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 86;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "列";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 86;
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
            // 
            // 图像信息ToolStripMenuItem
            // 
            this.图像信息ToolStripMenuItem.AutoSize = false;
            this.图像信息ToolStripMenuItem.Name = "图像信息ToolStripMenuItem";
            this.图像信息ToolStripMenuItem.Size = new System.Drawing.Size(149, 28);
            this.图像信息ToolStripMenuItem.Text = "图像信息";
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
            this.uiLine2.Size = new System.Drawing.Size(2, 487);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 131;
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine3
            // 
            this.uiLine3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine3.LineSize = 2;
            this.uiLine3.Location = new System.Drawing.Point(2, 516);
            this.uiLine3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine3.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(376, 2);
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
            this.uiLine4.Location = new System.Drawing.Point(376, 31);
            this.uiLine4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine4.MinimumSize = new System.Drawing.Size(2, 0);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(2, 485);
            this.uiLine4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine4.TabIndex = 133;
            this.uiLine4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_GlueRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(378, 518);
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
            this.Name = "Frm_GlueRegion";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowIcon = true;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "胶域分割";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.ExtendBoxClick += new System.EventHandler(this.Frm_GlueRegion_ExtendBoxClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_GlueRegion_FormClosing);
            this.panel1.ResumeLayout(false);
            this.uiTabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tck_maxThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tck_minThreshold)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UILine uiLine4;
        internal Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 适应窗体toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 图像信息ToolStripMenuItem;
        internal Sunny.UI.UITabControl uiTabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        public Controls.CNumericUpDown nud_dilationSize;
        private System.Windows.Forms.Label label7;
        internal Sunny.UI.UIButton btn_subRegion;
        internal Sunny.UI.UIButton btn_addRegion;
        internal Sunny.UI.UIButton btn_followCurPose;
        private System.Windows.Forms.Label label9;
        public Controls.CNumericUpDown nud_minRoundness;
        public Controls.CNumericUpDown nud_maxRoundness;
        private System.Windows.Forms.Label label16;
        public Controls.CNumericUpDown nud_minCol;
        public Controls.CNumericUpDown nud_maxCol;
        private System.Windows.Forms.Label label11;
        private Sunny.UI.UILine uiLine6;
        public Controls.CNumericUpDown nud_minRow;
        public Controls.CNumericUpDown nud_minArea;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        public Controls.CNumericUpDown nud_maxRow;
        public Controls.CNumericUpDown nud_maxArea;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label124;
        public Controls.CNumericUpDown nud_maxThreshold;
        public Controls.CNumericUpDown nud_minThreshold;
        public System.Windows.Forms.TrackBar tck_maxThreshold;
        public System.Windows.Forms.TrackBar tck_minThreshold;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.DataGridView dgv_result;
        internal Sunny.UI.UIComboBox cbx_searchRegionType;
        internal Sunny.UI.UICheckBox ckb_roundnessSelect;
        internal Sunny.UI.UICheckBox ckb_colSelect;
        internal Sunny.UI.UICheckBox ckb_rowSelect;
        internal Sunny.UI.UICheckBox ckb_areaSelect;
        private Sunny.UI.UIButton btn_saveTemplate;
        private Sunny.UI.UIButton btn_updateImage;
        private Sunny.UI.UIButton btn_glueRegion;
        public System.Windows.Forms.Label lbl_templateStatu;
        public System.Windows.Forms.Label lbl_runResult;
        public System.Windows.Forms.Label lbl_regionNum;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        internal Sunny.UI.UIButton btn_clearRegion;

    }
}