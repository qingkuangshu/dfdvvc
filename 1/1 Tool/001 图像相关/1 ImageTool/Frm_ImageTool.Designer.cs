﻿namespace VM_Pro
{
    partial class Frm_ImageTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ImageTool));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.保存toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.复位toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnl_formPanel = new System.Windows.Forms.Panel();
            this.rdo_fromDirectory = new Sunny.UI.UIRadioButton();
            this.ckb_dispPartImage = new Sunny.UI.UICheckBox();
            this.rdo_fromFile = new Sunny.UI.UIRadioButton();
            this.uiLine1 = new Sunny.UI.UILine();
            this.rdo_fromCamera = new Sunny.UI.UIRadioButton();
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
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.pnl_formPanel);
            this.panel3.Controls.Add(this.rdo_fromDirectory);
            this.panel3.Controls.Add(this.ckb_dispPartImage);
            this.panel3.Controls.Add(this.rdo_fromFile);
            this.panel3.Controls.Add(this.uiLine1);
            this.panel3.Controls.Add(this.rdo_fromCamera);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(662, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(378, 495);
            this.panel3.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(180, 437);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 31);
            this.textBox1.TabIndex = 138;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pnl_formPanel
            // 
            this.pnl_formPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_formPanel.BackColor = System.Drawing.Color.White;
            this.pnl_formPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnl_formPanel.Location = new System.Drawing.Point(14, 54);
            this.pnl_formPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnl_formPanel.Name = "pnl_formPanel";
            this.pnl_formPanel.Size = new System.Drawing.Size(348, 379);
            this.pnl_formPanel.TabIndex = 133;
            // 
            // rdo_fromDirectory
            // 
            this.rdo_fromDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_fromDirectory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_fromDirectory.GroupIndex = 2;
            this.rdo_fromDirectory.Location = new System.Drawing.Point(242, 7);
            this.rdo_fromDirectory.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_fromDirectory.Name = "rdo_fromDirectory";
            this.rdo_fromDirectory.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_fromDirectory.Size = new System.Drawing.Size(84, 35);
            this.rdo_fromDirectory.TabIndex = 132;
            this.rdo_fromDirectory.Text = "目录";
            this.rdo_fromDirectory.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_fromDirectory.CheckedChanged += new System.EventHandler(this.rdo_fromDirectory_CheckedChanged);
            // 
            // ckb_dispPartImage
            // 
            this.ckb_dispPartImage.Checked = true;
            this.ckb_dispPartImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_dispPartImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_dispPartImage.Location = new System.Drawing.Point(14, 439);
            this.ckb_dispPartImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_dispPartImage.Name = "ckb_dispPartImage";
            this.ckb_dispPartImage.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_dispPartImage.Size = new System.Drawing.Size(131, 24);
            this.ckb_dispPartImage.TabIndex = 137;
            this.ckb_dispPartImage.Text = "显示局部图像";
            this.ckb_dispPartImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_dispPartImage.CheckedChanged += new System.EventHandler(this.ckb_dispPartImage_CheckedChanged);
            // 
            // rdo_fromFile
            // 
            this.rdo_fromFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_fromFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_fromFile.GroupIndex = 2;
            this.rdo_fromFile.Location = new System.Drawing.Point(159, 7);
            this.rdo_fromFile.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_fromFile.Name = "rdo_fromFile";
            this.rdo_fromFile.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_fromFile.Size = new System.Drawing.Size(84, 35);
            this.rdo_fromFile.TabIndex = 131;
            this.rdo_fromFile.Text = "文件";
            this.rdo_fromFile.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_fromFile.CheckedChanged += new System.EventHandler(this.rdo_fromFile_CheckedChanged);
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine1.LineSize = 2;
            this.uiLine1.Location = new System.Drawing.Point(11, 42);
            this.uiLine1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine1.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(350, 5);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 130;
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rdo_fromCamera
            // 
            this.rdo_fromCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_fromCamera.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_fromCamera.GroupIndex = 2;
            this.rdo_fromCamera.Location = new System.Drawing.Point(65, 7);
            this.rdo_fromCamera.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_fromCamera.Name = "rdo_fromCamera";
            this.rdo_fromCamera.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_fromCamera.Size = new System.Drawing.Size(84, 35);
            this.rdo_fromCamera.TabIndex = 77;
            this.rdo_fromCamera.Text = "相机";
            this.rdo_fromCamera.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_fromCamera.CheckedChanged += new System.EventHandler(this.rdo_fromCamera_CheckedChanged);
            // 
            // hWindow_Final1
            // 
            this.hWindow_Final1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.适应窗体toolStripMenuItem1,
            this.图像信息ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(150, 60);
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.ckb_taskFailKeepRun.TabIndex = 234;
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
            this.btn_close.Location = new System.Drawing.Point(949, 15);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_close.Size = new System.Drawing.Size(75, 32);
            this.btn_close.Style = Sunny.UI.UIStyle.Custom;
            this.btn_close.TabIndex = 103;
            this.btn_close.Text = "关闭";
            this.btn_close.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.btn_runTask.Style = Sunny.UI.UIStyle.Custom;
            this.btn_runTask.TabIndex = 102;
            this.btn_runTask.Text = "运行流程";
            this.btn_runTask.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTask.Visible = false;
            this.btn_runTask.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.btn_runTool.Style = Sunny.UI.UIStyle.Custom;
            this.btn_runTool.TabIndex = 101;
            this.btn_runTool.Text = "运行工具";
            this.btn_runTool.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTool.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.uiLine2.Size = new System.Drawing.Size(2, 587);
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
            this.uiLine3.Location = new System.Drawing.Point(2, 616);
            this.uiLine3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine3.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(1038, 2);
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
            this.uiLine4.Location = new System.Drawing.Point(1038, 31);
            this.uiLine4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine4.MinimumSize = new System.Drawing.Size(2, 0);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(2, 585);
            this.uiLine4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine4.TabIndex = 133;
            this.uiLine4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Frm_ImageTool
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
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
            this.Name = "Frm_ImageTool";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowRadius = false;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "采集图像";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 1040, 618);
            this.ExtendBoxClick += new System.EventHandler(this.Frm_ImageTool_ExtendBoxClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_System_FormClosing);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        public System.Windows.Forms.Panel pnl_formPanel;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UILine uiLine4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 复位toolStripButton3;
        internal Sunny.UI.UILabel lbl_toolTip;
        internal Sunny.UI.UILabel lbl_runTime;
        internal Sunny.UI.UIRadioButton rdo_fromDirectory;
        internal Sunny.UI.UIRadioButton rdo_fromFile;
        internal Sunny.UI.UIRadioButton rdo_fromCamera;
        internal Sunny.UI.UICheckBox ckb_dispPartImage;
        internal Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 适应窗体toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 图像信息ToolStripMenuItem;
        internal ChoiceTech.Halcon.Control.HWindow_Final2 hWindow_Final1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripButton 保存toolStripButton1;
        internal Sunny.UI.UICheckBox ckb_taskFailKeepRun;
    }
}