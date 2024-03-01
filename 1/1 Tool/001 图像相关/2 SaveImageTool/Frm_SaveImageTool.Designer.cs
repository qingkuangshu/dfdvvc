namespace VM_Pro
{
    partial class Frm_SaveImageTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_SaveImageTool));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.保存toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.复位toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckb_taskFailKeepRun = new Sunny.UI.UICheckBox();
            this.uiLine5 = new Sunny.UI.UILine();
            this.btn_close = new Sunny.UI.UIButton();
            this.lbl_toolTip = new Sunny.UI.UILabel();
            this.lbl_runTime = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Rad_Hour = new Sunny.UI.UIRadioButton();
            this.Rad_Day = new Sunny.UI.UIRadioButton();
            this.btn_CancelLianRu = new Sunny.UI.UIImageButton();
            this.btn_TxtLianRu = new Sunny.UI.UIImageButton();
            this.tbx_LianRuFileName = new Sunny.UI.UITextBox();
            this.ckb_SaveMasterMapName = new Sunny.UI.UICheckBox();
            this.ckb_ShowMasterMapName = new Sunny.UI.UICheckBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.cbx_format = new Sunny.UI.UIComboBox();
            this.btn_clearImage = new Sunny.UI.UIButton();
            this.btn_openPath = new Sunny.UI.UIButton();
            this.ckb_appendTime = new Sunny.UI.UICheckBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.rdo_fromWindowImage = new Sunny.UI.UIRadioButton();
            this.rdo_fromInputImage = new Sunny.UI.UIRadioButton();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiLine4 = new Sunny.UI.UILine();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CancelLianRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TxtLianRu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 383);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(607, 383);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存toolStripButton1,
            this.复位toolStripButton3});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(607, 30);
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
            this.panel2.Controls.Add(this.lbl_toolTip);
            this.panel2.Controls.Add(this.lbl_runTime);
            this.panel2.Controls.Add(this.uiLabel1);
            this.panel2.Controls.Add(this.uiLabel9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 321);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 62);
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
            this.ckb_taskFailKeepRun.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_taskFailKeepRun.Click += new System.EventHandler(this.ckb_taskFailKeepRun_Click);
            // 
            // uiLine5
            // 
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine5.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine5.LineSize = 2;
            this.uiLine5.Location = new System.Drawing.Point(7, 0);
            this.uiLine5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine5.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(1026, 2);
            this.uiLine5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine5.TabIndex = 129;
            this.uiLine5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_close.Location = new System.Drawing.Point(516, 15);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_close.Size = new System.Drawing.Size(75, 32);
            this.btn_close.Style = Sunny.UI.UIStyle.Custom;
            this.btn_close.StyleCustomMode = true;
            this.btn_close.TabIndex = 103;
            this.btn_close.Text = "关闭";
            this.btn_close.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
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
            this.lbl_toolTip.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.lbl_runTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Rad_Hour);
            this.panel3.Controls.Add(this.Rad_Day);
            this.panel3.Controls.Add(this.btn_CancelLianRu);
            this.panel3.Controls.Add(this.btn_TxtLianRu);
            this.panel3.Controls.Add(this.tbx_LianRuFileName);
            this.panel3.Controls.Add(this.ckb_SaveMasterMapName);
            this.panel3.Controls.Add(this.ckb_ShowMasterMapName);
            this.panel3.Controls.Add(this.uiLabel3);
            this.panel3.Controls.Add(this.cbx_format);
            this.panel3.Controls.Add(this.btn_clearImage);
            this.panel3.Controls.Add(this.btn_openPath);
            this.panel3.Controls.Add(this.ckb_appendTime);
            this.panel3.Controls.Add(this.uiLabel4);
            this.panel3.Controls.Add(this.uiLabel5);
            this.panel3.Controls.Add(this.rdo_fromWindowImage);
            this.panel3.Controls.Add(this.rdo_fromInputImage);
            this.panel3.Controls.Add(this.uiLabel6);
            this.panel3.Controls.Add(this.uiLabel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(601, 285);
            this.panel3.TabIndex = 95;
            // 
            // Rad_Hour
            // 
            this.Rad_Hour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rad_Hour.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rad_Hour.Location = new System.Drawing.Point(265, 103);
            this.Rad_Hour.MinimumSize = new System.Drawing.Size(1, 1);
            this.Rad_Hour.Name = "Rad_Hour";
            this.Rad_Hour.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.Rad_Hour.Size = new System.Drawing.Size(73, 29);
            this.Rad_Hour.TabIndex = 100119;
            this.Rad_Hour.Text = "时";
            this.Rad_Hour.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Rad_Hour.Click += new System.EventHandler(this.Rad_Hour_Click);
            // 
            // Rad_Day
            // 
            this.Rad_Day.Checked = true;
            this.Rad_Day.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rad_Day.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rad_Day.Location = new System.Drawing.Point(108, 97);
            this.Rad_Day.MinimumSize = new System.Drawing.Size(1, 1);
            this.Rad_Day.Name = "Rad_Day";
            this.Rad_Day.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.Rad_Day.Size = new System.Drawing.Size(73, 29);
            this.Rad_Day.TabIndex = 100119;
            this.Rad_Day.Text = "天";
            this.Rad_Day.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Rad_Day.Click += new System.EventHandler(this.Rad_Day_Click);
            // 
            // btn_CancelLianRu
            // 
            this.btn_CancelLianRu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_CancelLianRu.BackgroundImage")));
            this.btn_CancelLianRu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CancelLianRu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CancelLianRu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CancelLianRu.Location = new System.Drawing.Point(326, 172);
            this.btn_CancelLianRu.Name = "btn_CancelLianRu";
            this.btn_CancelLianRu.Size = new System.Drawing.Size(33, 34);
            this.btn_CancelLianRu.TabIndex = 100118;
            this.btn_CancelLianRu.TabStop = false;
            this.btn_CancelLianRu.Text = null;
            this.btn_CancelLianRu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_CancelLianRu.Click += new System.EventHandler(this.btn_CancelLianRu_Click);
            // 
            // btn_TxtLianRu
            // 
            this.btn_TxtLianRu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_TxtLianRu.BackgroundImage")));
            this.btn_TxtLianRu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_TxtLianRu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TxtLianRu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_TxtLianRu.Location = new System.Drawing.Point(281, 172);
            this.btn_TxtLianRu.Name = "btn_TxtLianRu";
            this.btn_TxtLianRu.Size = new System.Drawing.Size(33, 34);
            this.btn_TxtLianRu.TabIndex = 100118;
            this.btn_TxtLianRu.TabStop = false;
            this.btn_TxtLianRu.Text = null;
            this.btn_TxtLianRu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_TxtLianRu.Click += new System.EventHandler(this.btn_TxtLianRu_Click);
            // 
            // tbx_LianRuFileName
            // 
            this.tbx_LianRuFileName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_LianRuFileName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_LianRuFileName.Location = new System.Drawing.Point(109, 172);
            this.tbx_LianRuFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_LianRuFileName.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbx_LianRuFileName.Name = "tbx_LianRuFileName";
            this.tbx_LianRuFileName.ReadOnly = true;
            this.tbx_LianRuFileName.ShowText = false;
            this.tbx_LianRuFileName.Size = new System.Drawing.Size(165, 29);
            this.tbx_LianRuFileName.TabIndex = 100117;
            this.tbx_LianRuFileName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_LianRuFileName.Watermark = "";
            this.tbx_LianRuFileName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ckb_SaveMasterMapName
            // 
            this.ckb_SaveMasterMapName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_SaveMasterMapName.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.ckb_SaveMasterMapName.Location = new System.Drawing.Point(265, 18);
            this.ckb_SaveMasterMapName.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_SaveMasterMapName.Name = "ckb_SaveMasterMapName";
            this.ckb_SaveMasterMapName.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_SaveMasterMapName.Size = new System.Drawing.Size(241, 27);
            this.ckb_SaveMasterMapName.TabIndex = 100116;
            this.ckb_SaveMasterMapName.Text = "跟随图像源路径按名称保存";
            this.ckb_SaveMasterMapName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_SaveMasterMapName.Click += new System.EventHandler(this.ckb_SaveMasterMapName_Click);
            // 
            // ckb_ShowMasterMapName
            // 
            this.ckb_ShowMasterMapName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_ShowMasterMapName.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.ckb_ShowMasterMapName.Location = new System.Drawing.Point(109, 18);
            this.ckb_ShowMasterMapName.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_ShowMasterMapName.Name = "ckb_ShowMasterMapName";
            this.ckb_ShowMasterMapName.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_ShowMasterMapName.Size = new System.Drawing.Size(150, 29);
            this.ckb_ShowMasterMapName.TabIndex = 100116;
            this.ckb_ShowMasterMapName.Text = "显示图像名称";
            this.ckb_ShowMasterMapName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_ShowMasterMapName.Click += new System.EventHandler(this.ckb_ShowMasterMapName_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(10, 16);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiLabel3.TabIndex = 100115;
            this.uiLabel3.Text = "紧耦操作:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbx_format
            // 
            this.cbx_format.DataSource = null;
            this.cbx_format.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_format.DropDownWidth = 106;
            this.cbx_format.FillColor = System.Drawing.Color.White;
            this.cbx_format.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_format.Items.AddRange(new object[] {
            "jpg",
            "tiff",
            "bmp",
            "png"});
            this.cbx_format.Location = new System.Drawing.Point(109, 135);
            this.cbx_format.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_format.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_format.Name = "cbx_format";
            this.cbx_format.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_format.Radius = 0;
            this.cbx_format.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbx_format.Size = new System.Drawing.Size(106, 28);
            this.cbx_format.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_format.TabIndex = 100114;
            this.cbx_format.Text = "jpg";
            this.cbx_format.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_format.Watermark = "";
            this.cbx_format.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_format.SelectedIndexChanged += new System.EventHandler(this.cbx_format_SelectedIndexChanged);
            // 
            // btn_clearImage
            // 
            this.btn_clearImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clearImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clearImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_clearImage.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_clearImage.Location = new System.Drawing.Point(265, 246);
            this.btn_clearImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_clearImage.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_clearImage.Name = "btn_clearImage";
            this.btn_clearImage.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_clearImage.Size = new System.Drawing.Size(70, 30);
            this.btn_clearImage.Style = Sunny.UI.UIStyle.Custom;
            this.btn_clearImage.StyleCustomMode = true;
            this.btn_clearImage.TabIndex = 236;
            this.btn_clearImage.Text = "清空图像";
            this.btn_clearImage.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_clearImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_clearImage.Click += new System.EventHandler(this.btn_clearImage_Click);
            // 
            // btn_openPath
            // 
            this.btn_openPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_openPath.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_openPath.Location = new System.Drawing.Point(168, 246);
            this.btn_openPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_openPath.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_openPath.Name = "btn_openPath";
            this.btn_openPath.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_openPath.Size = new System.Drawing.Size(70, 30);
            this.btn_openPath.Style = Sunny.UI.UIStyle.Custom;
            this.btn_openPath.StyleCustomMode = true;
            this.btn_openPath.TabIndex = 235;
            this.btn_openPath.Text = "查看图像";
            this.btn_openPath.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_openPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_openPath.Click += new System.EventHandler(this.btn_openPath_Click);
            // 
            // ckb_appendTime
            // 
            this.ckb_appendTime.Checked = true;
            this.ckb_appendTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_appendTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_appendTime.Location = new System.Drawing.Point(108, 214);
            this.ckb_appendTime.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_appendTime.Name = "ckb_appendTime";
            this.ckb_appendTime.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_appendTime.Size = new System.Drawing.Size(166, 24);
            this.ckb_appendTime.TabIndex = 234;
            this.ckb_appendTime.Text = "图像名自动追加时间";
            this.ckb_appendTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_appendTime.Click += new System.EventHandler(this.ckb_appendTime_Click);
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.White;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(11, 179);
            this.uiLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(100, 22);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 136;
            this.uiLabel4.Text = "文件名称：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.BackColor = System.Drawing.Color.White;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(14, 135);
            this.uiLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(100, 22);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 136;
            this.uiLabel5.Text = "图像格式：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rdo_fromWindowImage
            // 
            this.rdo_fromWindowImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_fromWindowImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_fromWindowImage.GroupIndex = 2;
            this.rdo_fromWindowImage.Location = new System.Drawing.Point(265, 61);
            this.rdo_fromWindowImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_fromWindowImage.Name = "rdo_fromWindowImage";
            this.rdo_fromWindowImage.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_fromWindowImage.Size = new System.Drawing.Size(130, 35);
            this.rdo_fromWindowImage.TabIndex = 133;
            this.rdo_fromWindowImage.Text = "保存窗口截图";
            this.rdo_fromWindowImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_fromWindowImage.Click += new System.EventHandler(this.rdo_fromWindowImage_Click);
            // 
            // rdo_fromInputImage
            // 
            this.rdo_fromInputImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_fromInputImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_fromInputImage.GroupIndex = 2;
            this.rdo_fromInputImage.Location = new System.Drawing.Point(108, 61);
            this.rdo_fromInputImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_fromInputImage.Name = "rdo_fromInputImage";
            this.rdo_fromInputImage.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_fromInputImage.Size = new System.Drawing.Size(130, 35);
            this.rdo_fromInputImage.TabIndex = 132;
            this.rdo_fromInputImage.Text = "保存输入图像";
            this.rdo_fromInputImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_fromInputImage.Click += new System.EventHandler(this.rdo_fromInputImage_Click);
            // 
            // uiLabel6
            // 
            this.uiLabel6.BackColor = System.Drawing.Color.White;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(14, 99);
            this.uiLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(100, 22);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 130;
            this.uiLabel6.Text = "存储时限：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.White;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(14, 66);
            this.uiLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 22);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 130;
            this.uiLabel2.Text = "图像来源：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine2
            // 
            this.uiLine2.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine2.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine2.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine2.LineSize = 2;
            this.uiLine2.Location = new System.Drawing.Point(0, 31);
            this.uiLine2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine2.MinimumSize = new System.Drawing.Size(2, 0);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(2, 383);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 131;
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine3
            // 
            this.uiLine3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine3.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine3.LineSize = 2;
            this.uiLine3.Location = new System.Drawing.Point(2, 412);
            this.uiLine3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine3.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(605, 2);
            this.uiLine3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine3.TabIndex = 132;
            this.uiLine3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine4
            // 
            this.uiLine4.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine4.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiLine4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine4.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine4.LineSize = 2;
            this.uiLine4.Location = new System.Drawing.Point(605, 31);
            this.uiLine4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine4.MinimumSize = new System.Drawing.Size(2, 0);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(2, 381);
            this.uiLine4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine4.TabIndex = 133;
            this.uiLine4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Frm_SaveImageTool
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(607, 414);
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
            this.MaximumSize = new System.Drawing.Size(607, 414);
            this.MinimumSize = new System.Drawing.Size(607, 414);
            this.Name = "Frm_SaveImageTool";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowRadius = false;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "外部输出";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 607, 414);
            this.ExtendBoxClick += new System.EventHandler(this.Frm_SaveImageTool_ExtendBoxClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_System_FormClosing);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_CancelLianRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TxtLianRu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UIButton btn_close;
        private Sunny.UI.UILine uiLine5;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UILine uiLine4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 复位toolStripButton3;
        internal Sunny.UI.UILabel lbl_toolTip;
        internal Sunny.UI.UILabel lbl_runTime;
        private System.Windows.Forms.Panel panel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel5;
        internal Sunny.UI.UIRadioButton rdo_fromWindowImage;
        internal Sunny.UI.UIRadioButton rdo_fromInputImage;
        private Sunny.UI.UIButton btn_clearImage;
        private Sunny.UI.UIButton btn_openPath;
        internal Sunny.UI.UICheckBox ckb_appendTime;
        internal Sunny.UI.UIComboBox cbx_format;
        private System.Windows.Forms.ToolStripButton 保存toolStripButton1;
        internal Sunny.UI.UICheckBox ckb_taskFailKeepRun;
        private Sunny.UI.UICheckBox ckb_SaveMasterMapName;
        private Sunny.UI.UILabel uiLabel3;
        internal Sunny.UI.UICheckBox ckb_ShowMasterMapName;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox tbx_LianRuFileName;
        private Sunny.UI.UIImageButton btn_TxtLianRu;
        private Sunny.UI.UIImageButton btn_CancelLianRu;
        private Sunny.UI.UIRadioButton Rad_Hour;
        private Sunny.UI.UIRadioButton Rad_Day;
        private Sunny.UI.UILabel uiLabel6;
    }
}