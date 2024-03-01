namespace VM_Pro
{
    partial class Frm_Debug
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvData = new Sunny.UI.UIDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生产清零ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复位信号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置踢料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckb_Start = new Sunny.UI.UICheckBox();
            this.btn_QueRen = new Sunny.UI.UIButton();
            this.txt_Right = new Sunny.UI.UITextBox();
            this.txt_Down = new Sunny.UI.UITextBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.lbl_runTime = new System.Windows.Forms.Label();
            this.ckb_ShowDefect = new Sunny.UI.UICheckBox();
            this.lb_Lianglv = new Sunny.UI.UILabel();
            this.lb_AllNum = new Sunny.UI.UILabel();
            this.lb_NG = new Sunny.UI.UILabel();
            this.lb_OK = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.txt_Left = new Sunny.UI.UITextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).BeginInit();
            this.uiContextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvData
            // 
            this.DgvData.AllowUserToAddRows = false;
            this.DgvData.AllowUserToDeleteRows = false;
            this.DgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgvData.BackgroundColor = System.Drawing.Color.White;
            this.DgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvData.ColumnHeadersHeight = 50;
            this.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvData.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvData.Enabled = false;
            this.DgvData.EnableHeadersVisualStyles = false;
            this.DgvData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DgvData.Location = new System.Drawing.Point(0, 0);
            this.DgvData.Name = "DgvData";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvData.RowHeadersVisible = false;
            this.DgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DgvData.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvData.RowTemplate.Height = 23;
            this.DgvData.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DgvData.SelectedIndex = -1;
            this.DgvData.Size = new System.Drawing.Size(381, 540);
            this.DgvData.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DgvData.Style = Sunny.UI.UIStyle.Custom;
            this.DgvData.TabIndex = 0;
            this.DgvData.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.DgvData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvData_DataError);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "类别";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 63;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "最小面积";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 63;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "当前面积";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 63;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "最大面积";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 63;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "NG数";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 63;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "启用";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 63;
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem,
            this.更改ToolStripMenuItem,
            this.生产清零ToolStripMenuItem,
            this.复位信号ToolStripMenuItem,
            this.设置踢料ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(165, 164);
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 更改ToolStripMenuItem
            // 
            this.更改ToolStripMenuItem.Name = "更改ToolStripMenuItem";
            this.更改ToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.更改ToolStripMenuItem.Text = "更改";
            this.更改ToolStripMenuItem.Click += new System.EventHandler(this.更改ToolStripMenuItem_Click);
            // 
            // 生产清零ToolStripMenuItem
            // 
            this.生产清零ToolStripMenuItem.Name = "生产清零ToolStripMenuItem";
            this.生产清零ToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.生产清零ToolStripMenuItem.Text = "生产清零";
            this.生产清零ToolStripMenuItem.Click += new System.EventHandler(this.生产清零ToolStripMenuItem_Click);
            // 
            // 复位信号ToolStripMenuItem
            // 
            this.复位信号ToolStripMenuItem.Name = "复位信号ToolStripMenuItem";
            this.复位信号ToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.复位信号ToolStripMenuItem.Text = "复位信号";
            this.复位信号ToolStripMenuItem.Click += new System.EventHandler(this.复位信号ToolStripMenuItem_Click);
            // 
            // 设置踢料ToolStripMenuItem
            // 
            this.设置踢料ToolStripMenuItem.Name = "设置踢料ToolStripMenuItem";
            this.设置踢料ToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.设置踢料ToolStripMenuItem.Text = "设置踢料";
            this.设置踢料ToolStripMenuItem.Click += new System.EventHandler(this.设置踢料ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_Left);
            this.panel1.Controls.Add(this.ckb_Start);
            this.panel1.Controls.Add(this.btn_QueRen);
            this.panel1.Controls.Add(this.txt_Right);
            this.panel1.Controls.Add(this.txt_Down);
            this.panel1.Controls.Add(this.uiLabel8);
            this.panel1.Controls.Add(this.uiLabel7);
            this.panel1.Controls.Add(this.uiLabel6);
            this.panel1.Controls.Add(this.lbl_runTime);
            this.panel1.Controls.Add(this.ckb_ShowDefect);
            this.panel1.Controls.Add(this.lb_Lianglv);
            this.panel1.Controls.Add(this.lb_AllNum);
            this.panel1.Controls.Add(this.lb_NG);
            this.panel1.Controls.Add(this.lb_OK);
            this.panel1.Controls.Add(this.uiLabel4);
            this.panel1.Controls.Add(this.uiLabel5);
            this.panel1.Controls.Add(this.uiLabel3);
            this.panel1.Controls.Add(this.uiLabel2);
            this.panel1.Controls.Add(this.uiLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 284);
            this.panel1.TabIndex = 3;
            // 
            // ckb_Start
            // 
            this.ckb_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_Start.Enabled = false;
            this.ckb_Start.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_Start.Location = new System.Drawing.Point(11, 137);
            this.ckb_Start.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_Start.Name = "ckb_Start";
            this.ckb_Start.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_Start.Size = new System.Drawing.Size(114, 29);
            this.ckb_Start.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_Start.TabIndex = 15;
            this.ckb_Start.Text = "启用踢料";
            this.ckb_Start.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_Start.Click += new System.EventHandler(this.ckb_Start_Click);
            // 
            // btn_QueRen
            // 
            this.btn_QueRen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_QueRen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_QueRen.Location = new System.Drawing.Point(269, 16);
            this.btn_QueRen.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_QueRen.Name = "btn_QueRen";
            this.btn_QueRen.Size = new System.Drawing.Size(100, 71);
            this.btn_QueRen.Style = Sunny.UI.UIStyle.Custom;
            this.btn_QueRen.TabIndex = 14;
            this.btn_QueRen.Text = "确认";
            this.btn_QueRen.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_QueRen.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_QueRen.Click += new System.EventHandler(this.btn_QueRen_Click);
            // 
            // txt_Right
            // 
            this.txt_Right.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Right.DoubleValue = 200D;
            this.txt_Right.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Right.IntValue = 200;
            this.txt_Right.Location = new System.Drawing.Point(134, 87);
            this.txt_Right.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Right.Maximum = 3000D;
            this.txt_Right.Minimum = 0D;
            this.txt_Right.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Right.Name = "txt_Right";
            this.txt_Right.ShowText = false;
            this.txt_Right.Size = new System.Drawing.Size(117, 29);
            this.txt_Right.Style = Sunny.UI.UIStyle.Custom;
            this.txt_Right.TabIndex = 13;
            this.txt_Right.Text = "200";
            this.txt_Right.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_Right.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_Right.Watermark = "";
            this.txt_Right.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_Down
            // 
            this.txt_Down.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Down.DoubleValue = 800D;
            this.txt_Down.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Down.IntValue = 800;
            this.txt_Down.Location = new System.Drawing.Point(134, 16);
            this.txt_Down.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Down.Maximum = 2000D;
            this.txt_Down.Minimum = 0D;
            this.txt_Down.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Down.Name = "txt_Down";
            this.txt_Down.ShowText = false;
            this.txt_Down.Size = new System.Drawing.Size(117, 29);
            this.txt_Down.Style = Sunny.UI.UIStyle.Custom;
            this.txt_Down.TabIndex = 13;
            this.txt_Down.Text = "800";
            this.txt_Down.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_Down.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_Down.Watermark = "";
            this.txt_Down.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(13, 87);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(114, 23);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 12;
            this.uiLabel7.Text = "右边界偏量";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(13, 16);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(114, 23);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 12;
            this.uiLabel6.Text = "下边界偏量";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_runTime
            // 
            this.lbl_runTime.AutoSize = true;
            this.lbl_runTime.Location = new System.Drawing.Point(99, 251);
            this.lbl_runTime.Name = "lbl_runTime";
            this.lbl_runTime.Size = new System.Drawing.Size(132, 27);
            this.lbl_runTime.TabIndex = 11;
            this.lbl_runTime.Text = "程序运行时间";
            // 
            // ckb_ShowDefect
            // 
            this.ckb_ShowDefect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_ShowDefect.Enabled = false;
            this.ckb_ShowDefect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_ShowDefect.Location = new System.Drawing.Point(212, 137);
            this.ckb_ShowDefect.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_ShowDefect.Name = "ckb_ShowDefect";
            this.ckb_ShowDefect.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_ShowDefect.Size = new System.Drawing.Size(150, 29);
            this.ckb_ShowDefect.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_ShowDefect.TabIndex = 4;
            this.ckb_ShowDefect.Text = "显示缺陷详情";
            this.ckb_ShowDefect.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_ShowDefect.Click += new System.EventHandler(this.ckb_ShowDefect_Click);
            // 
            // lb_Lianglv
            // 
            this.lb_Lianglv.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Lianglv.Location = new System.Drawing.Point(90, 205);
            this.lb_Lianglv.Name = "lb_Lianglv";
            this.lb_Lianglv.Size = new System.Drawing.Size(100, 23);
            this.lb_Lianglv.Style = Sunny.UI.UIStyle.Custom;
            this.lb_Lianglv.TabIndex = 7;
            this.lb_Lianglv.Text = "0.00 %";
            this.lb_Lianglv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Lianglv.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_AllNum
            // 
            this.lb_AllNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_AllNum.Location = new System.Drawing.Point(257, 205);
            this.lb_AllNum.Name = "lb_AllNum";
            this.lb_AllNum.Size = new System.Drawing.Size(100, 23);
            this.lb_AllNum.Style = Sunny.UI.UIStyle.Custom;
            this.lb_AllNum.TabIndex = 8;
            this.lb_AllNum.Text = "0";
            this.lb_AllNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_AllNum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_NG
            // 
            this.lb_NG.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_NG.Location = new System.Drawing.Point(255, 169);
            this.lb_NG.Name = "lb_NG";
            this.lb_NG.Size = new System.Drawing.Size(100, 23);
            this.lb_NG.Style = Sunny.UI.UIStyle.Custom;
            this.lb_NG.TabIndex = 9;
            this.lb_NG.Text = "0";
            this.lb_NG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_NG.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_OK
            // 
            this.lb_OK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_OK.Location = new System.Drawing.Point(90, 168);
            this.lb_OK.Name = "lb_OK";
            this.lb_OK.Size = new System.Drawing.Size(100, 23);
            this.lb_OK.Style = Sunny.UI.UIStyle.Custom;
            this.lb_OK.TabIndex = 10;
            this.lb_OK.Text = "0";
            this.lb_OK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_OK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(196, 205);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(55, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 3;
            this.uiLabel4.Text = "总数 :";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(8, 251);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(96, 23);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 4;
            this.uiLabel5.Text = "已运行：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(17, 205);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(55, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "良率 :";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.Red;
            this.uiLabel2.Location = new System.Drawing.Point(207, 168);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(55, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 5;
            this.uiLabel2.Text = "NG :";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.LimeGreen;
            this.uiLabel1.Location = new System.Drawing.Point(29, 168);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(55, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 6;
            this.uiLabel1.Text = "OK :";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(13, 53);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(114, 23);
            this.uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel8.TabIndex = 12;
            this.uiLabel8.Text = "左边界偏量";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_Left
            // 
            this.txt_Left.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Left.DoubleValue = 510D;
            this.txt_Left.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Left.IntValue = 510;
            this.txt_Left.Location = new System.Drawing.Point(134, 53);
            this.txt_Left.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Left.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Left.Name = "txt_Left";
            this.txt_Left.ShowText = false;
            this.txt_Left.Size = new System.Drawing.Size(117, 29);
            this.txt_Left.TabIndex = 16;
            this.txt_Left.Text = "510";
            this.txt_Left.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_Left.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_Left.Watermark = "";
            this.txt_Left.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Frm_Debug
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(381, 540);
            this.ContextMenuStrip = this.uiContextMenuStrip1;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DgvData);
            this.Name = "Frm_Debug";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "Frm_Vision";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Load += new System.EventHandler(this.Frm_Debug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion
        internal Sunny.UI.UIDataGridView DgvData;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更改ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.Panel panel1;
        internal Sunny.UI.UILabel lb_Lianglv;
        internal Sunny.UI.UILabel lb_AllNum;
        internal Sunny.UI.UILabel lb_NG;
        internal Sunny.UI.UILabel lb_OK;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.ToolStripMenuItem 生产清零ToolStripMenuItem;
        internal Sunny.UI.UICheckBox ckb_ShowDefect;
        internal System.Windows.Forms.Label lbl_runTime;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIButton btn_QueRen;
        private Sunny.UI.UITextBox txt_Right;
        private Sunny.UI.UITextBox txt_Down;
        private Sunny.UI.UICheckBox ckb_Start;
        private System.Windows.Forms.ToolStripMenuItem 复位信号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置踢料ToolStripMenuItem;
        private Sunny.UI.UITextBox txt_Left;
        private Sunny.UI.UILabel uiLabel8;
    }
}