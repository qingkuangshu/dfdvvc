namespace VM_Pro
{
    partial class Frm_UpCamAlignTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_UpCamAlignTool));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.保存toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.复位toolStripButton3 = new System.Windows.Forms.ToolStripButton();
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbx_featureX = new Controls.CNumeric();
            this.label10 = new System.Windows.Forms.Label();
            this.tbx_pickPosOffsetX = new Controls.CNumericUpDown();
            this.tbx_pickPosOffsetY = new Controls.CNumericUpDown();
            this.tbx_pickPosOffsetU = new Controls.CNumericUpDown();
            this.tbx_saftyRangeU = new Controls.CNumeric();
            this.tbx_saftyRangeY = new Controls.CNumeric();
            this.tbx_saftyRangeX = new Controls.CNumeric();
            this.tbx_pickPosU = new Controls.CNumeric();
            this.tbx_pickPosY = new Controls.CNumeric();
            this.tbx_pickPosX = new Controls.CNumeric();
            this.tbx_featureU = new Controls.CNumeric();
            this.tbx_featureY = new Controls.CNumeric();
            this.ckb_enableCheckError = new Sunny.UI.UICheckBox();
            this.cbx_toolList = new Sunny.UI.UIComboBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.btn_removeTool = new System.Windows.Forms.Button();
            this.btn_addTool = new System.Windows.Forms.Button();
            this.btn_touchFeaturePos = new Sunny.UI.UIButton();
            this.btn_touchPickPos = new Sunny.UI.UIButton();
            this.btn_touchToPickPos = new Sunny.UI.UIButton();
            this.uiLine1 = new Sunny.UI.UILine();
            this.lbl_resultPosU = new System.Windows.Forms.TextBox();
            this.lbl_inputPosU = new System.Windows.Forms.TextBox();
            this.lbl_resultPosX = new System.Windows.Forms.TextBox();
            this.uiLine7 = new Sunny.UI.UILine();
            this.lbl_resultPosY = new System.Windows.Forms.TextBox();
            this.lbl_inputPosX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_inputPosY = new System.Windows.Forms.TextBox();
            this.uiLine8 = new Sunny.UI.UILine();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.uiLine9 = new Sunny.UI.UILine();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.uiLine10 = new Sunny.UI.UILine();
            this.label32 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.uiLine6 = new Sunny.UI.UILine();
            this.rdo_moreTool = new Sunny.UI.UIRadioButton();
            this.rdo_oneTool = new Sunny.UI.UIRadioButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiLine4 = new Sunny.UI.UILine();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.tbx_featureX);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.tbx_pickPosOffsetX);
            this.panel3.Controls.Add(this.tbx_pickPosOffsetY);
            this.panel3.Controls.Add(this.tbx_pickPosOffsetU);
            this.panel3.Controls.Add(this.tbx_saftyRangeU);
            this.panel3.Controls.Add(this.tbx_saftyRangeY);
            this.panel3.Controls.Add(this.tbx_saftyRangeX);
            this.panel3.Controls.Add(this.tbx_pickPosU);
            this.panel3.Controls.Add(this.tbx_pickPosY);
            this.panel3.Controls.Add(this.tbx_pickPosX);
            this.panel3.Controls.Add(this.tbx_featureU);
            this.panel3.Controls.Add(this.tbx_featureY);
            this.panel3.Controls.Add(this.ckb_enableCheckError);
            this.panel3.Controls.Add(this.cbx_toolList);
            this.panel3.Controls.Add(this.uiLabel3);
            this.panel3.Controls.Add(this.btn_removeTool);
            this.panel3.Controls.Add(this.btn_addTool);
            this.panel3.Controls.Add(this.btn_touchFeaturePos);
            this.panel3.Controls.Add(this.btn_touchPickPos);
            this.panel3.Controls.Add(this.btn_touchToPickPos);
            this.panel3.Controls.Add(this.uiLine1);
            this.panel3.Controls.Add(this.lbl_resultPosU);
            this.panel3.Controls.Add(this.lbl_inputPosU);
            this.panel3.Controls.Add(this.lbl_resultPosX);
            this.panel3.Controls.Add(this.uiLine7);
            this.panel3.Controls.Add(this.lbl_resultPosY);
            this.panel3.Controls.Add(this.lbl_inputPosX);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lbl_inputPosY);
            this.panel3.Controls.Add(this.uiLine8);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.uiLine9);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.uiLine10);
            this.panel3.Controls.Add(this.label32);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.uiLine6);
            this.panel3.Controls.Add(this.rdo_moreTool);
            this.panel3.Controls.Add(this.rdo_oneTool);
            this.panel3.Controls.Add(this.uiLabel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1034, 489);
            this.panel3.TabIndex = 95;
            // 
            // tbx_featureX
            // 
            this.tbx_featureX.BackColor = System.Drawing.Color.White;
            this.tbx_featureX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_featureX.Location = new System.Drawing.Point(331, 60);
            this.tbx_featureX.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_featureX.Name = "tbx_featureX";
            this.tbx_featureX.Size = new System.Drawing.Size(80, 28);
            this.tbx_featureX.TabIndex = 100108;
            this.tbx_featureX.Value = "000.000";
            this.tbx_featureX.ValueChanged += new Controls.DValueChanged(this.tbx_featureX_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label10.Location = new System.Drawing.Point(655, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 321;
            this.label10.Text = "补偿值";
            // 
            // tbx_pickPosOffsetX
            // 
            this.tbx_pickPosOffsetX.BackColor = System.Drawing.Color.White;
            this.tbx_pickPosOffsetX.DecimalPlaces = 3;
            this.tbx_pickPosOffsetX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_pickPosOffsetX.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tbx_pickPosOffsetX.Location = new System.Drawing.Point(653, 57);
            this.tbx_pickPosOffsetX.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_pickPosOffsetX.MaximumSize = new System.Drawing.Size(343, 33);
            this.tbx_pickPosOffsetX.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tbx_pickPosOffsetX.MinimumSize = new System.Drawing.Size(57, 30);
            this.tbx_pickPosOffsetX.MinValue = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.tbx_pickPosOffsetX.Name = "tbx_pickPosOffsetX";
            this.tbx_pickPosOffsetX.Size = new System.Drawing.Size(100, 30);
            this.tbx_pickPosOffsetX.TabIndex = 100102;
            this.tbx_pickPosOffsetX.Value = 0D;
            this.tbx_pickPosOffsetX.ValueChanged += new Controls.DValueChanged(this.tbx_pickPosOffsetX_ValueChanged);
            // 
            // tbx_pickPosOffsetY
            // 
            this.tbx_pickPosOffsetY.BackColor = System.Drawing.Color.White;
            this.tbx_pickPosOffsetY.DecimalPlaces = 3;
            this.tbx_pickPosOffsetY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_pickPosOffsetY.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tbx_pickPosOffsetY.Location = new System.Drawing.Point(653, 85);
            this.tbx_pickPosOffsetY.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_pickPosOffsetY.MaximumSize = new System.Drawing.Size(343, 33);
            this.tbx_pickPosOffsetY.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tbx_pickPosOffsetY.MinimumSize = new System.Drawing.Size(57, 30);
            this.tbx_pickPosOffsetY.MinValue = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.tbx_pickPosOffsetY.Name = "tbx_pickPosOffsetY";
            this.tbx_pickPosOffsetY.Size = new System.Drawing.Size(100, 30);
            this.tbx_pickPosOffsetY.TabIndex = 100103;
            this.tbx_pickPosOffsetY.Value = 0D;
            this.tbx_pickPosOffsetY.ValueChanged += new Controls.DValueChanged(this.tbx_pickPosOffsetY_ValueChanged);
            // 
            // tbx_pickPosOffsetU
            // 
            this.tbx_pickPosOffsetU.BackColor = System.Drawing.Color.White;
            this.tbx_pickPosOffsetU.DecimalPlaces = 3;
            this.tbx_pickPosOffsetU.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_pickPosOffsetU.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tbx_pickPosOffsetU.Location = new System.Drawing.Point(653, 113);
            this.tbx_pickPosOffsetU.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_pickPosOffsetU.MaximumSize = new System.Drawing.Size(343, 33);
            this.tbx_pickPosOffsetU.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tbx_pickPosOffsetU.MinimumSize = new System.Drawing.Size(57, 30);
            this.tbx_pickPosOffsetU.MinValue = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.tbx_pickPosOffsetU.Name = "tbx_pickPosOffsetU";
            this.tbx_pickPosOffsetU.Size = new System.Drawing.Size(100, 30);
            this.tbx_pickPosOffsetU.TabIndex = 100104;
            this.tbx_pickPosOffsetU.Value = 0D;
            this.tbx_pickPosOffsetU.ValueChanged += new Controls.DValueChanged(this.tbx_pickPosOffsetU_ValueChanged);
            // 
            // tbx_saftyRangeU
            // 
            this.tbx_saftyRangeU.BackColor = System.Drawing.Color.White;
            this.tbx_saftyRangeU.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_saftyRangeU.Location = new System.Drawing.Point(828, 117);
            this.tbx_saftyRangeU.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_saftyRangeU.Name = "tbx_saftyRangeU";
            this.tbx_saftyRangeU.Size = new System.Drawing.Size(80, 28);
            this.tbx_saftyRangeU.TabIndex = 100116;
            this.tbx_saftyRangeU.Value = "3";
            this.tbx_saftyRangeU.ValueChanged += new Controls.DValueChanged(this.tbx_saftyRangeU_ValueChanged);
            // 
            // tbx_saftyRangeY
            // 
            this.tbx_saftyRangeY.BackColor = System.Drawing.Color.White;
            this.tbx_saftyRangeY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_saftyRangeY.Location = new System.Drawing.Point(828, 89);
            this.tbx_saftyRangeY.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_saftyRangeY.Name = "tbx_saftyRangeY";
            this.tbx_saftyRangeY.Size = new System.Drawing.Size(80, 28);
            this.tbx_saftyRangeY.TabIndex = 100115;
            this.tbx_saftyRangeY.Value = "3";
            this.tbx_saftyRangeY.ValueChanged += new Controls.DValueChanged(this.tbx_saftyRangeY_ValueChanged);
            // 
            // tbx_saftyRangeX
            // 
            this.tbx_saftyRangeX.BackColor = System.Drawing.Color.White;
            this.tbx_saftyRangeX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_saftyRangeX.Location = new System.Drawing.Point(828, 61);
            this.tbx_saftyRangeX.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_saftyRangeX.Name = "tbx_saftyRangeX";
            this.tbx_saftyRangeX.Size = new System.Drawing.Size(80, 28);
            this.tbx_saftyRangeX.TabIndex = 100114;
            this.tbx_saftyRangeX.Value = "3";
            this.tbx_saftyRangeX.ValueChanged += new Controls.DValueChanged(this.tbx_saftyRangeX_ValueChanged);
            // 
            // tbx_pickPosU
            // 
            this.tbx_pickPosU.BackColor = System.Drawing.Color.White;
            this.tbx_pickPosU.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_pickPosU.Location = new System.Drawing.Point(570, 116);
            this.tbx_pickPosU.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_pickPosU.Name = "tbx_pickPosU";
            this.tbx_pickPosU.Size = new System.Drawing.Size(80, 28);
            this.tbx_pickPosU.TabIndex = 100113;
            this.tbx_pickPosU.Value = "000.000";
            this.tbx_pickPosU.ValueChanged += new Controls.DValueChanged(this.tbx_pickPosU_ValueChanged);
            // 
            // tbx_pickPosY
            // 
            this.tbx_pickPosY.BackColor = System.Drawing.Color.White;
            this.tbx_pickPosY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_pickPosY.Location = new System.Drawing.Point(570, 88);
            this.tbx_pickPosY.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_pickPosY.Name = "tbx_pickPosY";
            this.tbx_pickPosY.Size = new System.Drawing.Size(80, 28);
            this.tbx_pickPosY.TabIndex = 100112;
            this.tbx_pickPosY.Value = "000.000";
            this.tbx_pickPosY.ValueChanged += new Controls.DValueChanged(this.tbx_pickPosY_ValueChanged);
            // 
            // tbx_pickPosX
            // 
            this.tbx_pickPosX.BackColor = System.Drawing.Color.White;
            this.tbx_pickPosX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_pickPosX.Location = new System.Drawing.Point(570, 60);
            this.tbx_pickPosX.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_pickPosX.Name = "tbx_pickPosX";
            this.tbx_pickPosX.Size = new System.Drawing.Size(80, 28);
            this.tbx_pickPosX.TabIndex = 100111;
            this.tbx_pickPosX.Value = "000.000";
            this.tbx_pickPosX.ValueChanged += new Controls.DValueChanged(this.tbx_pickPosX_ValueChanged);
            // 
            // tbx_featureU
            // 
            this.tbx_featureU.BackColor = System.Drawing.Color.White;
            this.tbx_featureU.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_featureU.Location = new System.Drawing.Point(331, 116);
            this.tbx_featureU.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_featureU.Name = "tbx_featureU";
            this.tbx_featureU.Size = new System.Drawing.Size(80, 28);
            this.tbx_featureU.TabIndex = 100110;
            this.tbx_featureU.Value = "000.000";
            this.tbx_featureU.ValueChanged += new Controls.DValueChanged(this.tbx_featureU_ValueChanged);
            // 
            // tbx_featureY
            // 
            this.tbx_featureY.BackColor = System.Drawing.Color.White;
            this.tbx_featureY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_featureY.Location = new System.Drawing.Point(331, 88);
            this.tbx_featureY.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_featureY.Name = "tbx_featureY";
            this.tbx_featureY.Size = new System.Drawing.Size(80, 28);
            this.tbx_featureY.TabIndex = 100109;
            this.tbx_featureY.Value = "000.000";
            this.tbx_featureY.ValueChanged += new Controls.DValueChanged(this.tbx_featureY_ValueChanged);
            // 
            // ckb_enableCheckError
            // 
            this.ckb_enableCheckError.Checked = true;
            this.ckb_enableCheckError.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_enableCheckError.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_enableCheckError.Location = new System.Drawing.Point(22, 144);
            this.ckb_enableCheckError.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_enableCheckError.Name = "ckb_enableCheckError";
            this.ckb_enableCheckError.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_enableCheckError.Size = new System.Drawing.Size(166, 24);
            this.ckb_enableCheckError.TabIndex = 100100;
            this.ckb_enableCheckError.Text = "开启算法自查";
            this.ckb_enableCheckError.Click += new System.EventHandler(this.ckb_enableCheckError_Click);
            // 
            // cbx_toolList
            // 
            this.cbx_toolList.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_toolList.DataSource = null;
            this.cbx_toolList.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_toolList.DropDownWidth = 92;
            this.cbx_toolList.FillColor = System.Drawing.Color.White;
            this.cbx_toolList.FillDisableColor = System.Drawing.Color.White;
            this.cbx_toolList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_toolList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_toolList.Location = new System.Drawing.Point(97, 63);
            this.cbx_toolList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_toolList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_toolList.Name = "cbx_toolList";
            this.cbx_toolList.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_toolList.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_toolList.RectColor = System.Drawing.Color.DimGray;
            this.cbx_toolList.RectDisableColor = System.Drawing.Color.DimGray;
            this.cbx_toolList.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_toolList.Size = new System.Drawing.Size(145, 26);
            this.cbx_toolList.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_toolList.TabIndex = 100099;
            this.cbx_toolList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_toolList.Watermark = "";
            this.cbx_toolList.SelectedIndexChanged += new System.EventHandler(this.cbx_toolList_SelectedIndexChanged);
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.White;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(20, 63);
            this.uiLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(90, 22);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 100079;
            this.uiLabel3.Text = "工具列表 ：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_removeTool
            // 
            this.btn_removeTool.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_removeTool.Location = new System.Drawing.Point(171, 93);
            this.btn_removeTool.Name = "btn_removeTool";
            this.btn_removeTool.Size = new System.Drawing.Size(72, 30);
            this.btn_removeTool.TabIndex = 100078;
            this.btn_removeTool.Text = "删除";
            this.btn_removeTool.UseVisualStyleBackColor = true;
            this.btn_removeTool.Click += new System.EventHandler(this.btn_removeTool_Click);
            // 
            // btn_addTool
            // 
            this.btn_addTool.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_addTool.Location = new System.Drawing.Point(96, 93);
            this.btn_addTool.Name = "btn_addTool";
            this.btn_addTool.Size = new System.Drawing.Size(72, 30);
            this.btn_addTool.TabIndex = 100077;
            this.btn_addTool.Text = "添加";
            this.btn_addTool.UseVisualStyleBackColor = true;
            this.btn_addTool.Click += new System.EventHandler(this.btn_addTool_Click);
            // 
            // btn_touchFeaturePos
            // 
            this.btn_touchFeaturePos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_touchFeaturePos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_touchFeaturePos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_touchFeaturePos.Location = new System.Drawing.Point(332, 157);
            this.btn_touchFeaturePos.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_touchFeaturePos.Name = "btn_touchFeaturePos";
            this.btn_touchFeaturePos.Size = new System.Drawing.Size(65, 30);
            this.btn_touchFeaturePos.Style = Sunny.UI.UIStyle.Custom;
            this.btn_touchFeaturePos.TabIndex = 323;
            this.btn_touchFeaturePos.Text = "示教";
            this.btn_touchFeaturePos.Visible = false;
            this.btn_touchFeaturePos.Click += new System.EventHandler(this.btn_touchFeaturePos_Click);
            // 
            // btn_touchPickPos
            // 
            this.btn_touchPickPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_touchPickPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_touchPickPos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_touchPickPos.Location = new System.Drawing.Point(572, 157);
            this.btn_touchPickPos.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_touchPickPos.Name = "btn_touchPickPos";
            this.btn_touchPickPos.Size = new System.Drawing.Size(65, 30);
            this.btn_touchPickPos.Style = Sunny.UI.UIStyle.Custom;
            this.btn_touchPickPos.TabIndex = 320;
            this.btn_touchPickPos.Text = "示教";
            this.btn_touchPickPos.Visible = false;
            this.btn_touchPickPos.Click += new System.EventHandler(this.btn_touchPickPos_Click);
            // 
            // btn_touchToPickPos
            // 
            this.btn_touchToPickPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_touchToPickPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_touchToPickPos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_touchToPickPos.Location = new System.Drawing.Point(572, 369);
            this.btn_touchToPickPos.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_touchToPickPos.Name = "btn_touchToPickPos";
            this.btn_touchToPickPos.Size = new System.Drawing.Size(65, 30);
            this.btn_touchToPickPos.Style = Sunny.UI.UIStyle.Custom;
            this.btn_touchToPickPos.TabIndex = 312;
            this.btn_touchToPickPos.Text = "取料坐标";
            this.btn_touchToPickPos.Visible = false;
            this.btn_touchToPickPos.Click += new System.EventHandler(this.btn_touchToPickPos_Click);
            // 
            // uiLine1
            // 
            this.uiLine1.FillColor = System.Drawing.Color.White;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(540, 231);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(220, 29);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 319;
            this.uiLine1.Text = "本次取料点坐标";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_resultPosU
            // 
            this.lbl_resultPosU.BackColor = System.Drawing.Color.White;
            this.lbl_resultPosU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_resultPosU.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_resultPosU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbl_resultPosU.Location = new System.Drawing.Point(572, 334);
            this.lbl_resultPosU.Name = "lbl_resultPosU";
            this.lbl_resultPosU.ReadOnly = true;
            this.lbl_resultPosU.Size = new System.Drawing.Size(76, 19);
            this.lbl_resultPosU.TabIndex = 303;
            this.lbl_resultPosU.TabStop = false;
            this.lbl_resultPosU.Text = "000.000";
            // 
            // lbl_inputPosU
            // 
            this.lbl_inputPosU.BackColor = System.Drawing.Color.White;
            this.lbl_inputPosU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_inputPosU.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_inputPosU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbl_inputPosU.Location = new System.Drawing.Point(332, 332);
            this.lbl_inputPosU.Name = "lbl_inputPosU";
            this.lbl_inputPosU.ReadOnly = true;
            this.lbl_inputPosU.Size = new System.Drawing.Size(84, 19);
            this.lbl_inputPosU.TabIndex = 298;
            this.lbl_inputPosU.TabStop = false;
            this.lbl_inputPosU.Text = "000.000";
            // 
            // lbl_resultPosX
            // 
            this.lbl_resultPosX.BackColor = System.Drawing.Color.White;
            this.lbl_resultPosX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_resultPosX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_resultPosX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbl_resultPosX.Location = new System.Drawing.Point(572, 278);
            this.lbl_resultPosX.Name = "lbl_resultPosX";
            this.lbl_resultPosX.ReadOnly = true;
            this.lbl_resultPosX.Size = new System.Drawing.Size(76, 19);
            this.lbl_resultPosX.TabIndex = 299;
            this.lbl_resultPosX.TabStop = false;
            this.lbl_resultPosX.Text = "000.000";
            // 
            // uiLine7
            // 
            this.uiLine7.FillColor = System.Drawing.Color.White;
            this.uiLine7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine7.Location = new System.Drawing.Point(292, 231);
            this.uiLine7.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine7.Name = "uiLine7";
            this.uiLine7.Size = new System.Drawing.Size(220, 29);
            this.uiLine7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine7.TabIndex = 318;
            this.uiLine7.Text = "本次特征点坐标";
            this.uiLine7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_resultPosY
            // 
            this.lbl_resultPosY.BackColor = System.Drawing.Color.White;
            this.lbl_resultPosY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_resultPosY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_resultPosY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbl_resultPosY.Location = new System.Drawing.Point(572, 306);
            this.lbl_resultPosY.Name = "lbl_resultPosY";
            this.lbl_resultPosY.ReadOnly = true;
            this.lbl_resultPosY.Size = new System.Drawing.Size(76, 19);
            this.lbl_resultPosY.TabIndex = 301;
            this.lbl_resultPosY.TabStop = false;
            this.lbl_resultPosY.Text = "000.000";
            // 
            // lbl_inputPosX
            // 
            this.lbl_inputPosX.BackColor = System.Drawing.Color.White;
            this.lbl_inputPosX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_inputPosX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_inputPosX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbl_inputPosX.Location = new System.Drawing.Point(332, 278);
            this.lbl_inputPosX.Name = "lbl_inputPosX";
            this.lbl_inputPosX.ReadOnly = true;
            this.lbl_inputPosX.Size = new System.Drawing.Size(84, 19);
            this.lbl_inputPosX.TabIndex = 295;
            this.lbl_inputPosX.TabStop = false;
            this.lbl_inputPosX.Text = "000.000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label5.Location = new System.Drawing.Point(544, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 281;
            this.label5.Text = "X ：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label6.Location = new System.Drawing.Point(544, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 283;
            this.label6.Text = "Y ：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label7.Location = new System.Drawing.Point(544, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 20);
            this.label7.TabIndex = 285;
            this.label7.Text = "U ：";
            // 
            // lbl_inputPosY
            // 
            this.lbl_inputPosY.BackColor = System.Drawing.Color.White;
            this.lbl_inputPosY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_inputPosY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_inputPosY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbl_inputPosY.Location = new System.Drawing.Point(332, 305);
            this.lbl_inputPosY.Name = "lbl_inputPosY";
            this.lbl_inputPosY.ReadOnly = true;
            this.lbl_inputPosY.Size = new System.Drawing.Size(84, 19);
            this.lbl_inputPosY.TabIndex = 296;
            this.lbl_inputPosY.TabStop = false;
            this.lbl_inputPosY.Text = "000.000";
            // 
            // uiLine8
            // 
            this.uiLine8.FillColor = System.Drawing.Color.White;
            this.uiLine8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine8.Location = new System.Drawing.Point(790, 15);
            this.uiLine8.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine8.Name = "uiLine8";
            this.uiLine8.Size = new System.Drawing.Size(220, 29);
            this.uiLine8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine8.TabIndex = 317;
            this.uiLine8.Text = "安全管控范围";
            this.uiLine8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label13.Location = new System.Drawing.Point(304, 278);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 20);
            this.label13.TabIndex = 288;
            this.label13.Text = "X ：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label14.Location = new System.Drawing.Point(304, 305);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 20);
            this.label14.TabIndex = 291;
            this.label14.Text = "Y ：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label15.Location = new System.Drawing.Point(304, 332);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 20);
            this.label15.TabIndex = 292;
            this.label15.Text = "U ：";
            // 
            // uiLine9
            // 
            this.uiLine9.FillColor = System.Drawing.Color.White;
            this.uiLine9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine9.Location = new System.Drawing.Point(540, 15);
            this.uiLine9.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine9.Name = "uiLine9";
            this.uiLine9.Size = new System.Drawing.Size(220, 29);
            this.uiLine9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine9.TabIndex = 316;
            this.uiLine9.Text = "模板取料点坐标";
            this.uiLine9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label11.Location = new System.Drawing.Point(801, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 20);
            this.label11.TabIndex = 287;
            this.label11.Text = "X ：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label12.Location = new System.Drawing.Point(801, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 20);
            this.label12.TabIndex = 289;
            this.label12.Text = "Y ：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label16.Location = new System.Drawing.Point(801, 120);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 20);
            this.label16.TabIndex = 293;
            this.label16.Text = "U ：";
            // 
            // uiLine10
            // 
            this.uiLine10.FillColor = System.Drawing.Color.White;
            this.uiLine10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine10.Location = new System.Drawing.Point(292, 15);
            this.uiLine10.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine10.Name = "uiLine10";
            this.uiLine10.Size = new System.Drawing.Size(220, 29);
            this.uiLine10.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine10.TabIndex = 315;
            this.uiLine10.Text = "模板特征点坐标";
            this.uiLine10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(303, 453);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(512, 20);
            this.label32.TabIndex = 297;
            this.label32.Text = "说明：以上坐标均为物理坐标系坐标，且XY坐标单位均为毫米，U坐标单位均为度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(543, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 280;
            this.label2.Text = "X ：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(543, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 282;
            this.label3.Text = "Y ：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(303, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 286;
            this.label1.Text = "X ：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(543, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 284;
            this.label4.Text = "U ：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label8.Location = new System.Drawing.Point(303, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 20);
            this.label8.TabIndex = 290;
            this.label8.Text = "Y ：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label9.Location = new System.Drawing.Point(303, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 20);
            this.label9.TabIndex = 294;
            this.label9.Text = "U ：";
            // 
            // uiLine6
            // 
            this.uiLine6.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine6.FillColor = System.Drawing.Color.White;
            this.uiLine6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uiLine6.Location = new System.Drawing.Point(261, 16);
            this.uiLine6.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine6.Name = "uiLine6";
            this.uiLine6.RadiusSides = ((Sunny.UI.UICornerRadiusSides)(((Sunny.UI.UICornerRadiusSides.RightTop | Sunny.UI.UICornerRadiusSides.RightBottom) 
            | Sunny.UI.UICornerRadiusSides.LeftBottom)));
            this.uiLine6.Size = new System.Drawing.Size(11, 457);
            this.uiLine6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine6.TabIndex = 276;
            this.uiLine6.Text = "安全管控范围";
            this.uiLine6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdo_moreTool
            // 
            this.rdo_moreTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_moreTool.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_moreTool.GroupIndex = 2;
            this.rdo_moreTool.Location = new System.Drawing.Point(176, 16);
            this.rdo_moreTool.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_moreTool.Name = "rdo_moreTool";
            this.rdo_moreTool.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_moreTool.Size = new System.Drawing.Size(78, 27);
            this.rdo_moreTool.TabIndex = 136;
            this.rdo_moreTool.Text = "多工具";
            this.rdo_moreTool.Click += new System.EventHandler(this.rdo_moreTool_Click);
            // 
            // rdo_oneTool
            // 
            this.rdo_oneTool.Checked = true;
            this.rdo_oneTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_oneTool.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_oneTool.GroupIndex = 2;
            this.rdo_oneTool.Location = new System.Drawing.Point(92, 16);
            this.rdo_oneTool.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_oneTool.Name = "rdo_oneTool";
            this.rdo_oneTool.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_oneTool.Size = new System.Drawing.Size(78, 27);
            this.rdo_oneTool.TabIndex = 135;
            this.rdo_oneTool.Text = "单工具";
            this.rdo_oneTool.Click += new System.EventHandler(this.rdo_oneTool_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.White;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(20, 17);
            this.uiLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 22);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 134;
            this.uiLabel2.Text = "场       景 ：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // Frm_UpCamAlignTool
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
            this.Name = "Frm_UpCamAlignTool";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowIcon = true;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "顶部定位";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.ExtendBoxClick += new System.EventHandler(this.Frm_MatchTool_ExtendBoxClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_System_FormClosing);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILine uiLine5;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UILine uiLine4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 复位toolStripButton3;
        internal Sunny.UI.UILabel lbl_toolTip;
        internal Sunny.UI.UILabel lbl_runTime;
        internal Sunny.UI.UIButton btn_close;
        internal Sunny.UI.UIButton btn_runTask;
        internal Sunny.UI.UIButton btn_runTool;
        private System.Windows.Forms.ToolStripButton 保存toolStripButton1;
        private System.Windows.Forms.Panel panel3;
        internal Sunny.UI.UIRadioButton rdo_moreTool;
        internal Sunny.UI.UIRadioButton rdo_oneTool;
        private Sunny.UI.UILabel uiLabel2;
        internal Sunny.UI.UIButton btn_touchFeaturePos;
        private System.Windows.Forms.Label label10;
        internal Sunny.UI.UIButton btn_touchPickPos;
        internal Sunny.UI.UIButton btn_touchToPickPos;
        private Sunny.UI.UILine uiLine1;
        public System.Windows.Forms.TextBox lbl_resultPosU;
        public System.Windows.Forms.TextBox lbl_inputPosU;
        public System.Windows.Forms.TextBox lbl_resultPosX;
        private Sunny.UI.UILine uiLine7;
        public System.Windows.Forms.TextBox lbl_resultPosY;
        public System.Windows.Forms.TextBox lbl_inputPosX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox lbl_inputPosY;
        private Sunny.UI.UILine uiLine8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private Sunny.UI.UILine uiLine9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private Sunny.UI.UILine uiLine10;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Sunny.UI.UILine uiLine6;
        private Sunny.UI.UILabel uiLabel3;
        private System.Windows.Forms.Button btn_removeTool;
        private System.Windows.Forms.Button btn_addTool;
        internal Sunny.UI.UIComboBox cbx_toolList;
        internal Sunny.UI.UICheckBox ckb_enableCheckError;
        public Controls.CNumericUpDown tbx_pickPosOffsetU;
        public Controls.CNumericUpDown tbx_pickPosOffsetY;
        public Controls.CNumericUpDown tbx_pickPosOffsetX;
        private Controls.CNumeric tbx_featureU;
        private Controls.CNumeric tbx_featureY;
        private Controls.CNumeric tbx_featureX;
        private Controls.CNumeric tbx_saftyRangeU;
        private Controls.CNumeric tbx_saftyRangeY;
        private Controls.CNumeric tbx_saftyRangeX;
        private Controls.CNumeric tbx_pickPosU;
        private Controls.CNumeric tbx_pickPosY;
        private Controls.CNumeric tbx_pickPosX;
        internal Sunny.UI.UICheckBox ckb_taskFailKeepRun;

    }
}