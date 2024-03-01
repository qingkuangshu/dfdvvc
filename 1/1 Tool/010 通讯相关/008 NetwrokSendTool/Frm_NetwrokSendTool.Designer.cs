namespace VM_Pro
{
    partial class Frm_NetworkSendTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_NetworkSendTool));
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
            this.tbx_taskFailTimeFomat = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.ckb_taskFailTimeFomat = new Sunny.UI.UICheckBox();
            this.btn_CancelLianRu = new Sunny.UI.UIImageButton();
            this.btn_TxtLianRu = new Sunny.UI.UIImageButton();
            this.tbx_taskFailCmd = new Sunny.UI.UITextBox();
            this.ckb_taskFailOtherCmd = new Sunny.UI.UICheckBox();
            this.cbx_clientList = new Sunny.UI.UIComboBox();
            this.cbx_ethernetNameList = new Sunny.UI.UIComboBox();
            this.tbx_cmd = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.btn_endCharEnter = new System.Windows.Forms.Button();
            this.btn_endCharNone = new System.Windows.Forms.Button();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiLine4 = new Sunny.UI.UILine();
            this.uiToolTip1 = new Sunny.UI.UIToolTip(this.components);
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
            this.panel3.Controls.Add(this.tbx_taskFailTimeFomat);
            this.panel3.Controls.Add(this.uiLabel6);
            this.panel3.Controls.Add(this.ckb_taskFailTimeFomat);
            this.panel3.Controls.Add(this.btn_CancelLianRu);
            this.panel3.Controls.Add(this.btn_TxtLianRu);
            this.panel3.Controls.Add(this.tbx_taskFailCmd);
            this.panel3.Controls.Add(this.ckb_taskFailOtherCmd);
            this.panel3.Controls.Add(this.cbx_clientList);
            this.panel3.Controls.Add(this.cbx_ethernetNameList);
            this.panel3.Controls.Add(this.tbx_cmd);
            this.panel3.Controls.Add(this.uiLabel5);
            this.panel3.Controls.Add(this.btn_endCharEnter);
            this.panel3.Controls.Add(this.btn_endCharNone);
            this.panel3.Controls.Add(this.uiLabel4);
            this.panel3.Controls.Add(this.uiLabel3);
            this.panel3.Controls.Add(this.uiLabel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(601, 285);
            this.panel3.TabIndex = 95;
            // 
            // tbx_taskFailTimeFomat
            // 
            this.tbx_taskFailTimeFomat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_taskFailTimeFomat.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tbx_taskFailTimeFomat.Location = new System.Drawing.Point(97, 169);
            this.tbx_taskFailTimeFomat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_taskFailTimeFomat.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbx_taskFailTimeFomat.Name = "tbx_taskFailTimeFomat";
            this.tbx_taskFailTimeFomat.ShowText = false;
            this.tbx_taskFailTimeFomat.Size = new System.Drawing.Size(195, 29);
            this.tbx_taskFailTimeFomat.TabIndex = 240;
            this.tbx_taskFailTimeFomat.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiToolTip1.SetToolTip(this.tbx_taskFailTimeFomat, "注意时间格式，最终回复为：NG回复,时间戳格式+结束符");
            this.tbx_taskFailTimeFomat.Watermark = "yyyyMMddHHmmssff";
            this.tbx_taskFailTimeFomat.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tbx_taskFailTimeFomat.TextChanged += new System.EventHandler(this.tbx_taskFailTimeFomat_TextChanged);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.uiLabel6.Location = new System.Drawing.Point(-5, 169);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(100, 23);
            this.uiLabel6.TabIndex = 239;
            this.uiLabel6.Text = "时间戳格式";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ckb_taskFailTimeFomat
            // 
            this.ckb_taskFailTimeFomat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_taskFailTimeFomat.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.ckb_taskFailTimeFomat.Location = new System.Drawing.Point(308, 169);
            this.ckb_taskFailTimeFomat.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_taskFailTimeFomat.Name = "ckb_taskFailTimeFomat";
            this.ckb_taskFailTimeFomat.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_taskFailTimeFomat.Size = new System.Drawing.Size(198, 29);
            this.ckb_taskFailTimeFomat.TabIndex = 238;
            this.ckb_taskFailTimeFomat.Text = "失败增加时间戳回复";
            this.ckb_taskFailTimeFomat.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_taskFailTimeFomat.Click += new System.EventHandler(this.ckb_taskFailTimeFomat_Click);
            // 
            // btn_CancelLianRu
            // 
            this.btn_CancelLianRu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_CancelLianRu.BackgroundImage")));
            this.btn_CancelLianRu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CancelLianRu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CancelLianRu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CancelLianRu.Location = new System.Drawing.Point(361, 49);
            this.btn_CancelLianRu.Name = "btn_CancelLianRu";
            this.btn_CancelLianRu.Size = new System.Drawing.Size(33, 34);
            this.btn_CancelLianRu.TabIndex = 237;
            this.btn_CancelLianRu.TabStop = false;
            this.btn_CancelLianRu.Text = null;
            this.uiToolTip1.SetToolTip(this.btn_CancelLianRu, "取消变量链入");
            this.btn_CancelLianRu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_CancelLianRu.Click += new System.EventHandler(this.btn_CancelLianRu_Click);
            // 
            // btn_TxtLianRu
            // 
            this.btn_TxtLianRu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_TxtLianRu.BackgroundImage")));
            this.btn_TxtLianRu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_TxtLianRu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TxtLianRu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_TxtLianRu.Location = new System.Drawing.Point(319, 49);
            this.btn_TxtLianRu.Name = "btn_TxtLianRu";
            this.btn_TxtLianRu.Size = new System.Drawing.Size(33, 34);
            this.btn_TxtLianRu.TabIndex = 236;
            this.btn_TxtLianRu.TabStop = false;
            this.btn_TxtLianRu.Text = null;
            this.uiToolTip1.SetToolTip(this.btn_TxtLianRu, "链入工具变量");
            this.btn_TxtLianRu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_TxtLianRu.Click += new System.EventHandler(this.btn_TxtLianRu_Click);
            // 
            // tbx_taskFailCmd
            // 
            this.tbx_taskFailCmd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_taskFailCmd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_taskFailCmd.Location = new System.Drawing.Point(97, 119);
            this.tbx_taskFailCmd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_taskFailCmd.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_taskFailCmd.Name = "tbx_taskFailCmd";
            this.tbx_taskFailCmd.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_taskFailCmd.Radius = 0;
            this.tbx_taskFailCmd.RectColor = System.Drawing.Color.Silver;
            this.tbx_taskFailCmd.ShowText = false;
            this.tbx_taskFailCmd.Size = new System.Drawing.Size(195, 30);
            this.tbx_taskFailCmd.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_taskFailCmd.TabIndex = 235;
            this.tbx_taskFailCmd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_taskFailCmd.Watermark = "流程失败时的指令文本";
            this.tbx_taskFailCmd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tbx_taskFailCmd.TextChanged += new System.EventHandler(this.tbx_taskFailCmd_TextChanged);
            // 
            // ckb_taskFailOtherCmd
            // 
            this.ckb_taskFailOtherCmd.Checked = true;
            this.ckb_taskFailOtherCmd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_taskFailOtherCmd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_taskFailOtherCmd.Location = new System.Drawing.Point(308, 125);
            this.ckb_taskFailOtherCmd.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_taskFailOtherCmd.Name = "ckb_taskFailOtherCmd";
            this.ckb_taskFailOtherCmd.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_taskFailOtherCmd.Size = new System.Drawing.Size(198, 24);
            this.ckb_taskFailOtherCmd.TabIndex = 234;
            this.ckb_taskFailOtherCmd.Text = "任务失败时回复特定指令";
            this.ckb_taskFailOtherCmd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_taskFailOtherCmd.Click += new System.EventHandler(this.ckb_taskFailOtherCmd_Click);
            // 
            // cbx_clientList
            // 
            this.cbx_clientList.DataSource = null;
            this.cbx_clientList.FillColor = System.Drawing.Color.White;
            this.cbx_clientList.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_clientList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_clientList.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_clientList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_clientList.Location = new System.Drawing.Point(308, 11);
            this.cbx_clientList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_clientList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_clientList.Name = "cbx_clientList";
            this.cbx_clientList.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_clientList.Radius = 0;
            this.cbx_clientList.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_clientList.RectColor = System.Drawing.Color.Silver;
            this.cbx_clientList.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_clientList.Size = new System.Drawing.Size(168, 30);
            this.cbx_clientList.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_clientList.TabIndex = 220;
            this.cbx_clientList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_clientList.Watermark = "请选择客户端";
            this.cbx_clientList.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_clientList.SelectedIndexChanged += new System.EventHandler(this.cbx_clientList_SelectedIndexChanged);
            // 
            // cbx_ethernetNameList
            // 
            this.cbx_ethernetNameList.DataSource = null;
            this.cbx_ethernetNameList.FillColor = System.Drawing.Color.White;
            this.cbx_ethernetNameList.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_ethernetNameList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_ethernetNameList.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_ethernetNameList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_ethernetNameList.Location = new System.Drawing.Point(97, 11);
            this.cbx_ethernetNameList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_ethernetNameList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_ethernetNameList.Name = "cbx_ethernetNameList";
            this.cbx_ethernetNameList.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_ethernetNameList.Radius = 0;
            this.cbx_ethernetNameList.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_ethernetNameList.RectColor = System.Drawing.Color.Silver;
            this.cbx_ethernetNameList.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_ethernetNameList.Size = new System.Drawing.Size(195, 30);
            this.cbx_ethernetNameList.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_ethernetNameList.TabIndex = 219;
            this.cbx_ethernetNameList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_ethernetNameList.Watermark = "请选择以太网端口";
            this.cbx_ethernetNameList.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_ethernetNameList.SelectedIndexChanged += new System.EventHandler(this.cbx_ethernetNameList_SelectedIndexChanged);
            // 
            // tbx_cmd
            // 
            this.tbx_cmd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_cmd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_cmd.Location = new System.Drawing.Point(97, 45);
            this.tbx_cmd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_cmd.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_cmd.Name = "tbx_cmd";
            this.tbx_cmd.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_cmd.Radius = 0;
            this.tbx_cmd.RectColor = System.Drawing.Color.Silver;
            this.tbx_cmd.ShowText = false;
            this.tbx_cmd.Size = new System.Drawing.Size(195, 30);
            this.tbx_cmd.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_cmd.TabIndex = 218;
            this.tbx_cmd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_cmd.Watermark = "请输入要发送的文本";
            this.tbx_cmd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tbx_cmd.TextChanged += new System.EventHandler(this.tbx_cmd_TextChanged);
            // 
            // uiLabel5
            // 
            this.uiLabel5.BackColor = System.Drawing.Color.White;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(18, 48);
            this.uiLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(79, 22);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 136;
            this.uiLabel5.Text = "指令文本：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_endCharEnter
            // 
            this.btn_endCharEnter.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_endCharEnter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_endCharEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_endCharEnter.FlatAppearance.BorderSize = 0;
            this.btn_endCharEnter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btn_endCharEnter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btn_endCharEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_endCharEnter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_endCharEnter.ForeColor = System.Drawing.Color.White;
            this.btn_endCharEnter.Location = new System.Drawing.Point(139, 81);
            this.btn_endCharEnter.Name = "btn_endCharEnter";
            this.btn_endCharEnter.Size = new System.Drawing.Size(42, 25);
            this.btn_endCharEnter.TabIndex = 168;
            this.btn_endCharEnter.TabStop = false;
            this.btn_endCharEnter.Text = "\\r\\n";
            this.btn_endCharEnter.UseVisualStyleBackColor = false;
            this.btn_endCharEnter.Click += new System.EventHandler(this.btn_endCharEnter_Click);
            // 
            // btn_endCharNone
            // 
            this.btn_endCharNone.BackColor = System.Drawing.Color.Gray;
            this.btn_endCharNone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_endCharNone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_endCharNone.FlatAppearance.BorderSize = 0;
            this.btn_endCharNone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btn_endCharNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btn_endCharNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_endCharNone.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_endCharNone.ForeColor = System.Drawing.Color.White;
            this.btn_endCharNone.Location = new System.Drawing.Point(97, 81);
            this.btn_endCharNone.Name = "btn_endCharNone";
            this.btn_endCharNone.Size = new System.Drawing.Size(42, 25);
            this.btn_endCharNone.TabIndex = 167;
            this.btn_endCharNone.TabStop = false;
            this.btn_endCharNone.Text = "无";
            this.btn_endCharNone.UseVisualStyleBackColor = false;
            this.btn_endCharNone.Click += new System.EventHandler(this.btn_endCharNone_Click);
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.White;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(6, 125);
            this.uiLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(92, 22);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 137;
            this.uiLabel4.Text = "NG回复 :";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.White;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(18, 81);
            this.uiLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(92, 22);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 137;
            this.uiLabel3.Text = "结束符    :";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.White;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(18, 15);
            this.uiLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(92, 22);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 130;
            this.uiLabel2.Text = "端口选择：";
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
            // uiToolTip1
            // 
            this.uiToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.uiToolTip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.uiToolTip1.IsBalloon = true;
            this.uiToolTip1.OwnerDraw = true;
            // 
            // Frm_NetworkSendTool
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
            this.Name = "Frm_NetworkSendTool";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowRadius = false;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "外部输出";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 607, 414);
            this.ExtendBoxClick += new System.EventHandler(this.Frm_NetworkSendTool_ExtendBoxClick);
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
        private Sunny.UI.UILabel uiLabel3;
        internal System.Windows.Forms.Button btn_endCharEnter;
        internal System.Windows.Forms.Button btn_endCharNone;
        internal Sunny.UI.UIComboBox cbx_ethernetNameList;
        internal Sunny.UI.UITextBox tbx_cmd;
        internal Sunny.UI.UIComboBox cbx_clientList;
        internal Sunny.UI.UITextBox tbx_taskFailCmd;
        internal Sunny.UI.UICheckBox ckb_taskFailOtherCmd;
        private System.Windows.Forms.ToolStripButton 保存toolStripButton1;
        internal Sunny.UI.UICheckBox ckb_taskFailKeepRun;
        private Sunny.UI.UIImageButton btn_TxtLianRu;
        private Sunny.UI.UIImageButton btn_CancelLianRu;
        private Sunny.UI.UIToolTip uiToolTip1;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel6;
        internal Sunny.UI.UICheckBox ckb_taskFailTimeFomat;
        internal Sunny.UI.UITextBox tbx_taskFailTimeFomat;
    }
}