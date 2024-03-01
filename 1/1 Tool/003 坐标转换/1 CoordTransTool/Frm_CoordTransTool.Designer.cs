namespace VM_Pro
{
    partial class Frm_CoordTransTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CoordTransTool));
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
            this.cbx_calibFileList = new Sunny.UI.UIComboBox();
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
            this.btn_close.Location = new System.Drawing.Point(516, 15);
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
            this.panel3.Controls.Add(this.cbx_calibFileList);
            this.panel3.Controls.Add(this.uiLabel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(601, 285);
            this.panel3.TabIndex = 95;
            // 
            // cbx_calibFileList
            // 
            this.cbx_calibFileList.DataSource = null;
            this.cbx_calibFileList.FillColor = System.Drawing.Color.White;
            this.cbx_calibFileList.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_calibFileList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_calibFileList.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_calibFileList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_calibFileList.Location = new System.Drawing.Point(89, 11);
            this.cbx_calibFileList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_calibFileList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_calibFileList.Name = "cbx_calibFileList";
            this.cbx_calibFileList.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_calibFileList.Radius = 0;
            this.cbx_calibFileList.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_calibFileList.RectColor = System.Drawing.Color.Silver;
            this.cbx_calibFileList.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_calibFileList.Size = new System.Drawing.Size(168, 30);
            this.cbx_calibFileList.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_calibFileList.TabIndex = 219;
            this.cbx_calibFileList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_calibFileList.Watermark = "请选择相机标定";
            this.cbx_calibFileList.SelectedIndexChanged += new System.EventHandler(this.cbx_calibFileList_SelectedIndexChanged);
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
            this.uiLabel2.Text = "标定选择：";
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
            this.uiLine2.Size = new System.Drawing.Size(2, 383);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 131;
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine3
            // 
            this.uiLine3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine3.LineSize = 2;
            this.uiLine3.Location = new System.Drawing.Point(2, 412);
            this.uiLine3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine3.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(605, 2);
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
            this.uiLine4.Location = new System.Drawing.Point(605, 31);
            this.uiLine4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine4.MinimumSize = new System.Drawing.Size(2, 0);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(2, 381);
            this.uiLine4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine4.TabIndex = 133;
            this.uiLine4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_CoordTransTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "Frm_CoordTransTool";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowIcon = true;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "引用标定";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.ExtendBoxClick += new System.EventHandler(this.Frm_NetworkSendTool_ExtendBoxClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_System_FormClosing);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
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
        internal Sunny.UI.UIComboBox cbx_calibFileList;
        private System.Windows.Forms.ToolStripButton 保存toolStripButton1;
        internal Sunny.UI.UICheckBox ckb_taskFailKeepRun;

    }
}