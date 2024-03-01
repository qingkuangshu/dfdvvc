namespace VM_Pro
{
    partial class Frm_Inference
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inference));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.保存toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.复位toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.JieGuo = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DgvHandleData = new Sunny.UI.UIDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.保存更新 = new System.Windows.Forms.ToolStripMenuItem();
            this.QuYu = new System.Windows.Forms.TabPage();
            this.Pan_ROI = new System.Windows.Forms.Panel();
            this.ImgBtn_LianRu = new Sunny.UI.UIImageButton();
            this.txt_LianRu = new Sunny.UI.UITextBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.rad_IsQuYu = new Sunny.UI.UIRadioButton();
            this.rad_IsQuanTu = new Sunny.UI.UIRadioButton();
            this.JiaZai = new System.Windows.Forms.TabPage();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.Rdb_GPU = new Sunny.UI.UIRadioButton();
            this.Rdb_CPU = new Sunny.UI.UIRadioButton();
            this.txt_XunLianHdl = new Sunny.UI.UITextBox();
            this.txtClassNames = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.SheZhi = new System.Windows.Forms.TabPage();
            this.ckb_JianCeRegionToMain = new Sunny.UI.UICheckBox();
            this.Ckb_ShowDgvData = new Sunny.UI.UICheckBox();
            this.Ckb_RunRegionShowFrm = new Sunny.UI.UICheckBox();
            this.Ckb_RunImgShowFrm = new Sunny.UI.UICheckBox();
            this.Ckb_ShowResult = new Sunny.UI.UICheckBox();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final2();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_close = new Sunny.UI.UIButton();
            this.ckb_taskFailKeepRun = new Sunny.UI.UICheckBox();
            this.btn_runTask = new Sunny.UI.UIButton();
            this.btn_runTool = new Sunny.UI.UIButton();
            this.lbl_toolTip = new Sunny.UI.UILabel();
            this.lbl_runTime = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.IsQueXian = new Sunny.UI.UIRadioButton();
            this.IsTuXiang = new Sunny.UI.UIRadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.JieGuo.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHandleData)).BeginInit();
            this.uiContextMenuStrip1.SuspendLayout();
            this.QuYu.SuspendLayout();
            this.Pan_ROI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBtn_LianRu)).BeginInit();
            this.JiaZai.SuspendLayout();
            this.SheZhi.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存toolStripButton1,
            this.复位toolStripButton3,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 35);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1040, 30);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            this.保存toolStripButton1.Text = "toolStripButton1";
            this.保存toolStripButton1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.保存toolStripButton1.ToolTipText = "保存";
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
            this.复位toolStripButton3.Text = "toolStripButton2";
            this.复位toolStripButton3.ToolTipText = "复位";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(34, 25);
            this.toolStripButton1.Text = "工具帮助";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.hWindow_Final1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 547);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uiTabControl1);
            this.panel3.Location = new System.Drawing.Point(657, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 486);
            this.panel3.TabIndex = 2;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.AutoClosePage = false;
            this.uiTabControl1.Controls.Add(this.JieGuo);
            this.uiTabControl1.Controls.Add(this.QuYu);
            this.uiTabControl1.Controls.Add(this.JiaZai);
            this.uiTabControl1.Controls.Add(this.SheZhi);
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTabControl1.Frame = null;
            this.uiTabControl1.ItemSize = new System.Drawing.Size(80, 28);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(381, 483);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTabControl1.TabBackColor = System.Drawing.Color.White;
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.White;
            this.uiTabControl1.TabUnSelectedForeColor = System.Drawing.Color.Black;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // JieGuo
            // 
            this.JieGuo.Controls.Add(this.panel4);
            this.JieGuo.Location = new System.Drawing.Point(0, 28);
            this.JieGuo.Name = "JieGuo";
            this.JieGuo.Size = new System.Drawing.Size(381, 455);
            this.JieGuo.TabIndex = 0;
            this.JieGuo.Text = "推理结果";
            this.JieGuo.ToolTipText = "运行查找结果";
            this.JieGuo.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.DgvHandleData);
            this.panel4.Location = new System.Drawing.Point(5, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(371, 447);
            this.panel4.TabIndex = 1;
            // 
            // DgvHandleData
            // 
            this.DgvHandleData.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.DgvHandleData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvHandleData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.DgvHandleData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvHandleData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvHandleData.ColumnHeadersHeight = 50;
            this.DgvHandleData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvHandleData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.DgvHandleData.ContextMenuStrip = this.uiContextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvHandleData.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvHandleData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvHandleData.EnableHeadersVisualStyles = false;
            this.DgvHandleData.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.DgvHandleData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.DgvHandleData.Location = new System.Drawing.Point(0, 0);
            this.DgvHandleData.Name = "DgvHandleData";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvHandleData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvHandleData.RowHeadersVisible = false;
            this.DgvHandleData.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.DgvHandleData.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvHandleData.RowTemplate.Height = 28;
            this.DgvHandleData.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DgvHandleData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvHandleData.SelectedIndex = -1;
            this.DgvHandleData.Size = new System.Drawing.Size(371, 447);
            this.DgvHandleData.Style = Sunny.UI.UIStyle.Custom;
            this.DgvHandleData.TabIndex = 0;
            this.DgvHandleData.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.DgvHandleData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvHandleData_DataError);
            this.DgvHandleData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvHandleData_KeyDown);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 53.40609F;
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 41;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 107.999F;
            this.Column2.HeaderText = "类别";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 55;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 107.999F;
            this.Column3.HeaderText = "最小面积";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 54;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 107.999F;
            this.Column4.HeaderText = "最大面积";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 55;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 107.999F;
            this.Column5.HeaderText = "当前面积";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 54;
            // 
            // Column6
            // 
            this.Column6.FalseValue = "false";
            this.Column6.FillWeight = 106.599F;
            this.Column6.HeaderText = "是否启用";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column6.TrueValue = "true";
            this.Column6.Width = 54;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 107.999F;
            this.Column7.HeaderText = "判定结果";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 55;
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存更新});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(265, 36);
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // 保存更新
            // 
            this.保存更新.Name = "保存更新";
            this.保存更新.Size = new System.Drawing.Size(264, 32);
            this.保存更新.Text = "将列表数据更新使用";
            this.保存更新.Click += new System.EventHandler(this.保存更新_Click);
            // 
            // QuYu
            // 
            this.QuYu.Controls.Add(this.Pan_ROI);
            this.QuYu.Controls.Add(this.rad_IsQuYu);
            this.QuYu.Controls.Add(this.rad_IsQuanTu);
            this.QuYu.Location = new System.Drawing.Point(0, 28);
            this.QuYu.Name = "QuYu";
            this.QuYu.Size = new System.Drawing.Size(381, 455);
            this.QuYu.TabIndex = 3;
            this.QuYu.Text = "检测区域";
            this.QuYu.UseVisualStyleBackColor = true;
            // 
            // Pan_ROI
            // 
            this.Pan_ROI.Controls.Add(this.ImgBtn_LianRu);
            this.Pan_ROI.Controls.Add(this.txt_LianRu);
            this.Pan_ROI.Controls.Add(this.uiLabel7);
            this.Pan_ROI.Location = new System.Drawing.Point(20, 158);
            this.Pan_ROI.Name = "Pan_ROI";
            this.Pan_ROI.Size = new System.Drawing.Size(300, 109);
            this.Pan_ROI.TabIndex = 2;
            this.Pan_ROI.Visible = false;
            // 
            // ImgBtn_LianRu
            // 
            this.ImgBtn_LianRu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ImgBtn_LianRu.BackgroundImage")));
            this.ImgBtn_LianRu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ImgBtn_LianRu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImgBtn_LianRu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImgBtn_LianRu.Location = new System.Drawing.Point(207, 37);
            this.ImgBtn_LianRu.Name = "ImgBtn_LianRu";
            this.ImgBtn_LianRu.Size = new System.Drawing.Size(29, 29);
            this.ImgBtn_LianRu.Style = Sunny.UI.UIStyle.Custom;
            this.ImgBtn_LianRu.TabIndex = 2;
            this.ImgBtn_LianRu.TabStop = false;
            this.ImgBtn_LianRu.Text = null;
            this.ImgBtn_LianRu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ImgBtn_LianRu.Click += new System.EventHandler(this.ImgBtn_LianRu_Click);
            // 
            // txt_LianRu
            // 
            this.txt_LianRu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_LianRu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_LianRu.Location = new System.Drawing.Point(50, 37);
            this.txt_LianRu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_LianRu.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_LianRu.Name = "txt_LianRu";
            this.txt_LianRu.ReadOnly = true;
            this.txt_LianRu.ShowText = false;
            this.txt_LianRu.Size = new System.Drawing.Size(150, 29);
            this.txt_LianRu.Style = Sunny.UI.UIStyle.Custom;
            this.txt_LianRu.TabIndex = 1;
            this.txt_LianRu.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_LianRu.Watermark = "";
            this.txt_LianRu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(7, 37);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(45, 23);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 0;
            this.uiLabel7.Text = "ROI";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rad_IsQuYu
            // 
            this.rad_IsQuYu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rad_IsQuYu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rad_IsQuYu.Location = new System.Drawing.Point(31, 112);
            this.rad_IsQuYu.MinimumSize = new System.Drawing.Size(1, 1);
            this.rad_IsQuYu.Name = "rad_IsQuYu";
            this.rad_IsQuYu.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rad_IsQuYu.Size = new System.Drawing.Size(280, 29);
            this.rad_IsQuYu.Style = Sunny.UI.UIStyle.Custom;
            this.rad_IsQuYu.TabIndex = 1;
            this.rad_IsQuYu.Text = "ROI链接【若区域为空会默认全图】";
            this.rad_IsQuYu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rad_IsQuYu.Click += new System.EventHandler(this.rad_IsQuanTu_Click);
            // 
            // rad_IsQuanTu
            // 
            this.rad_IsQuanTu.Checked = true;
            this.rad_IsQuanTu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rad_IsQuanTu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rad_IsQuanTu.Location = new System.Drawing.Point(31, 52);
            this.rad_IsQuanTu.MinimumSize = new System.Drawing.Size(1, 1);
            this.rad_IsQuanTu.Name = "rad_IsQuanTu";
            this.rad_IsQuanTu.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rad_IsQuanTu.Size = new System.Drawing.Size(150, 29);
            this.rad_IsQuanTu.Style = Sunny.UI.UIStyle.Custom;
            this.rad_IsQuanTu.TabIndex = 0;
            this.rad_IsQuanTu.Text = "全图";
            this.rad_IsQuanTu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rad_IsQuanTu.Click += new System.EventHandler(this.rad_IsQuanTu_Click);
            // 
            // JiaZai
            // 
            this.JiaZai.Controls.Add(this.panel5);
            this.JiaZai.Controls.Add(this.uiLabel8);
            this.JiaZai.Controls.Add(this.uiLabel6);
            this.JiaZai.Controls.Add(this.Rdb_GPU);
            this.JiaZai.Controls.Add(this.Rdb_CPU);
            this.JiaZai.Controls.Add(this.txt_XunLianHdl);
            this.JiaZai.Controls.Add(this.txtClassNames);
            this.JiaZai.Controls.Add(this.uiLabel4);
            this.JiaZai.Controls.Add(this.uiLabel2);
            this.JiaZai.Controls.Add(this.uiLabel5);
            this.JiaZai.Location = new System.Drawing.Point(0, 28);
            this.JiaZai.Name = "JiaZai";
            this.JiaZai.Size = new System.Drawing.Size(381, 455);
            this.JiaZai.TabIndex = 1;
            this.JiaZai.Text = "模型加载";
            this.JiaZai.ToolTipText = "模型加载";
            this.JiaZai.UseVisualStyleBackColor = true;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(13, 404);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(310, 41);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 5;
            this.uiLabel6.Text = "注：导入模型前请先设置相关参数";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Rdb_GPU
            // 
            this.Rdb_GPU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rdb_GPU.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rdb_GPU.Location = new System.Drawing.Point(235, 27);
            this.Rdb_GPU.MinimumSize = new System.Drawing.Size(1, 1);
            this.Rdb_GPU.Name = "Rdb_GPU";
            this.Rdb_GPU.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.Rdb_GPU.Size = new System.Drawing.Size(72, 29);
            this.Rdb_GPU.Style = Sunny.UI.UIStyle.Custom;
            this.Rdb_GPU.TabIndex = 0;
            this.Rdb_GPU.Text = "GPU";
            this.Rdb_GPU.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Rdb_GPU.Click += new System.EventHandler(this.Rdb_GPU_Click);
            // 
            // Rdb_CPU
            // 
            this.Rdb_CPU.Checked = true;
            this.Rdb_CPU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rdb_CPU.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rdb_CPU.Location = new System.Drawing.Point(122, 27);
            this.Rdb_CPU.MinimumSize = new System.Drawing.Size(1, 1);
            this.Rdb_CPU.Name = "Rdb_CPU";
            this.Rdb_CPU.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.Rdb_CPU.Size = new System.Drawing.Size(77, 29);
            this.Rdb_CPU.Style = Sunny.UI.UIStyle.Custom;
            this.Rdb_CPU.TabIndex = 0;
            this.Rdb_CPU.Text = "CPU";
            this.Rdb_CPU.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Rdb_CPU.Click += new System.EventHandler(this.Rdb_CPU_Click);
            // 
            // txt_XunLianHdl
            // 
            this.txt_XunLianHdl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_XunLianHdl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_XunLianHdl.Location = new System.Drawing.Point(7, 309);
            this.txt_XunLianHdl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_XunLianHdl.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_XunLianHdl.Multiline = true;
            this.txt_XunLianHdl.Name = "txt_XunLianHdl";
            this.txt_XunLianHdl.ShowText = false;
            this.txt_XunLianHdl.Size = new System.Drawing.Size(364, 80);
            this.txt_XunLianHdl.Style = Sunny.UI.UIStyle.Custom;
            this.txt_XunLianHdl.TabIndex = 3;
            this.txt_XunLianHdl.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_XunLianHdl.Watermark = "请输入训练模型，一般为训练的最优模型";
            this.txt_XunLianHdl.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_XunLianHdl.DoubleClick += new System.EventHandler(this.txt_XunLianHdl_DoubleClick);
            // 
            // txtClassNames
            // 
            this.txtClassNames.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClassNames.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClassNames.Location = new System.Drawing.Point(8, 177);
            this.txtClassNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClassNames.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtClassNames.Multiline = true;
            this.txtClassNames.Name = "txtClassNames";
            this.txtClassNames.ShowText = false;
            this.txtClassNames.Size = new System.Drawing.Size(364, 80);
            this.txtClassNames.Style = Sunny.UI.UIStyle.Custom;
            this.txtClassNames.TabIndex = 3;
            this.txtClassNames.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtClassNames.Watermark = "背景,NG1,NG2....";
            this.txtClassNames.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(14, 24);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(102, 32);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 0;
            this.uiLabel4.Text = "运行模式 ：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(14, 140);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(141, 32);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 0;
            this.uiLabel2.Text = "检测标签参数";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(14, 272);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(141, 32);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 0;
            this.uiLabel5.Text = "训练模型文件";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // SheZhi
            // 
            this.SheZhi.Controls.Add(this.ckb_JianCeRegionToMain);
            this.SheZhi.Controls.Add(this.Ckb_ShowDgvData);
            this.SheZhi.Controls.Add(this.Ckb_RunRegionShowFrm);
            this.SheZhi.Controls.Add(this.Ckb_RunImgShowFrm);
            this.SheZhi.Controls.Add(this.Ckb_ShowResult);
            this.SheZhi.Location = new System.Drawing.Point(0, 28);
            this.SheZhi.Name = "SheZhi";
            this.SheZhi.Size = new System.Drawing.Size(381, 455);
            this.SheZhi.TabIndex = 2;
            this.SheZhi.Text = "显示设置";
            this.SheZhi.ToolTipText = "显示设置";
            this.SheZhi.UseVisualStyleBackColor = true;
            // 
            // ckb_JianCeRegionToMain
            // 
            this.ckb_JianCeRegionToMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_JianCeRegionToMain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_JianCeRegionToMain.Location = new System.Drawing.Point(16, 119);
            this.ckb_JianCeRegionToMain.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_JianCeRegionToMain.Name = "ckb_JianCeRegionToMain";
            this.ckb_JianCeRegionToMain.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_JianCeRegionToMain.Size = new System.Drawing.Size(196, 29);
            this.ckb_JianCeRegionToMain.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_JianCeRegionToMain.TabIndex = 3;
            this.ckb_JianCeRegionToMain.Text = "检测区域显示到主窗体";
            this.ckb_JianCeRegionToMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_JianCeRegionToMain.Click += new System.EventHandler(this.ckb_JianCeRegionToMain_Click);
            // 
            // Ckb_ShowDgvData
            // 
            this.Ckb_ShowDgvData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ckb_ShowDgvData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Ckb_ShowDgvData.Location = new System.Drawing.Point(16, 152);
            this.Ckb_ShowDgvData.MinimumSize = new System.Drawing.Size(1, 1);
            this.Ckb_ShowDgvData.Name = "Ckb_ShowDgvData";
            this.Ckb_ShowDgvData.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.Ckb_ShowDgvData.Size = new System.Drawing.Size(356, 29);
            this.Ckb_ShowDgvData.Style = Sunny.UI.UIStyle.Custom;
            this.Ckb_ShowDgvData.TabIndex = 2;
            this.Ckb_ShowDgvData.Text = "参数界面数据跟随主界面 [False：跟随文件]";
            this.Ckb_ShowDgvData.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Ckb_ShowDgvData.Click += new System.EventHandler(this.Ckb_ShowDgvData_Click);
            // 
            // Ckb_RunRegionShowFrm
            // 
            this.Ckb_RunRegionShowFrm.Checked = true;
            this.Ckb_RunRegionShowFrm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ckb_RunRegionShowFrm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Ckb_RunRegionShowFrm.Location = new System.Drawing.Point(16, 86);
            this.Ckb_RunRegionShowFrm.MinimumSize = new System.Drawing.Size(1, 1);
            this.Ckb_RunRegionShowFrm.Name = "Ckb_RunRegionShowFrm";
            this.Ckb_RunRegionShowFrm.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.Ckb_RunRegionShowFrm.Size = new System.Drawing.Size(196, 29);
            this.Ckb_RunRegionShowFrm.Style = Sunny.UI.UIStyle.Custom;
            this.Ckb_RunRegionShowFrm.TabIndex = 1;
            this.Ckb_RunRegionShowFrm.Text = "缺陷区域显示到主窗体";
            this.Ckb_RunRegionShowFrm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Ckb_RunRegionShowFrm.Click += new System.EventHandler(this.Ckb_RunRegionShowFrm_Click);
            // 
            // Ckb_RunImgShowFrm
            // 
            this.Ckb_RunImgShowFrm.Checked = true;
            this.Ckb_RunImgShowFrm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ckb_RunImgShowFrm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Ckb_RunImgShowFrm.Location = new System.Drawing.Point(16, 53);
            this.Ckb_RunImgShowFrm.MinimumSize = new System.Drawing.Size(1, 1);
            this.Ckb_RunImgShowFrm.Name = "Ckb_RunImgShowFrm";
            this.Ckb_RunImgShowFrm.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.Ckb_RunImgShowFrm.Size = new System.Drawing.Size(287, 29);
            this.Ckb_RunImgShowFrm.Style = Sunny.UI.UIStyle.Custom;
            this.Ckb_RunImgShowFrm.TabIndex = 0;
            this.Ckb_RunImgShowFrm.Text = "主窗体图像替换为模型处理后图片";
            this.Ckb_RunImgShowFrm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Ckb_RunImgShowFrm.Click += new System.EventHandler(this.Ckb_RunImgShowFrm_Click);
            // 
            // Ckb_ShowResult
            // 
            this.Ckb_ShowResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ckb_ShowResult.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Ckb_ShowResult.Location = new System.Drawing.Point(16, 20);
            this.Ckb_ShowResult.MinimumSize = new System.Drawing.Size(1, 1);
            this.Ckb_ShowResult.Name = "Ckb_ShowResult";
            this.Ckb_ShowResult.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.Ckb_ShowResult.Size = new System.Drawing.Size(174, 29);
            this.Ckb_ShowResult.Style = Sunny.UI.UIStyle.Custom;
            this.Ckb_ShowResult.TabIndex = 0;
            this.Ckb_ShowResult.Text = "判定结果打印主窗体";
            this.Ckb_ShowResult.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Ckb_ShowResult.Click += new System.EventHandler(this.Ckb_ShowResult_Click);
            // 
            // hWindow_Final1
            // 
            this.hWindow_Final1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hWindow_Final1.DrawModel = false;
            this.hWindow_Final1.EditModel = true;
            this.hWindow_Final1.Image = null;
            this.hWindow_Final1.Location = new System.Drawing.Point(3, 2);
            this.hWindow_Final1.Margin = new System.Windows.Forms.Padding(5);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(650, 488);
            this.hWindow_Final1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.ckb_taskFailKeepRun);
            this.panel2.Controls.Add(this.btn_runTask);
            this.panel2.Controls.Add(this.btn_runTool);
            this.panel2.Controls.Add(this.lbl_toolTip);
            this.panel2.Controls.Add(this.lbl_runTime);
            this.panel2.Controls.Add(this.uiLabel3);
            this.panel2.Controls.Add(this.uiLabel1);
            this.panel2.Controls.Add(this.uiLine1);
            this.panel2.Location = new System.Drawing.Point(3, 487);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1037, 59);
            this.panel2.TabIndex = 0;
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_close.Location = new System.Drawing.Point(951, 21);
            this.btn_close.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 32);
            this.btn_close.Style = Sunny.UI.UIStyle.Custom;
            this.btn_close.TabIndex = 15;
            this.btn_close.Text = "关闭";
            this.btn_close.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // ckb_taskFailKeepRun
            // 
            this.ckb_taskFailKeepRun.Checked = true;
            this.ckb_taskFailKeepRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_taskFailKeepRun.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ckb_taskFailKeepRun.Location = new System.Drawing.Point(162, 11);
            this.ckb_taskFailKeepRun.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_taskFailKeepRun.Name = "ckb_taskFailKeepRun";
            this.ckb_taskFailKeepRun.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_taskFailKeepRun.Size = new System.Drawing.Size(150, 29);
            this.ckb_taskFailKeepRun.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_taskFailKeepRun.TabIndex = 10;
            this.ckb_taskFailKeepRun.Text = "流程失败仍运行";
            this.ckb_taskFailKeepRun.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_taskFailKeepRun.Click += new System.EventHandler(this.ckb_taskFailKeepRun_Click);
            // 
            // btn_runTask
            // 
            this.btn_runTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runTask.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_runTask.Location = new System.Drawing.Point(791, 21);
            this.btn_runTask.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_runTask.Name = "btn_runTask";
            this.btn_runTask.Size = new System.Drawing.Size(75, 32);
            this.btn_runTask.Style = Sunny.UI.UIStyle.Custom;
            this.btn_runTask.TabIndex = 16;
            this.btn_runTask.Text = "运行流程";
            this.btn_runTask.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTask.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_runTask.Click += new System.EventHandler(this.btn_runTask_Click);
            // 
            // btn_runTool
            // 
            this.btn_runTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runTool.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_runTool.Location = new System.Drawing.Point(708, 21);
            this.btn_runTool.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_runTool.Name = "btn_runTool";
            this.btn_runTool.Size = new System.Drawing.Size(75, 32);
            this.btn_runTool.Style = Sunny.UI.UIStyle.Custom;
            this.btn_runTool.TabIndex = 17;
            this.btn_runTool.Text = "运行工具";
            this.btn_runTool.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTool.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_runTool.Click += new System.EventHandler(this.btn_runTool_Click);
            // 
            // lbl_toolTip
            // 
            this.lbl_toolTip.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_toolTip.Location = new System.Drawing.Point(62, 38);
            this.lbl_toolTip.Name = "lbl_toolTip";
            this.lbl_toolTip.Size = new System.Drawing.Size(383, 23);
            this.lbl_toolTip.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_toolTip.TabIndex = 6;
            this.lbl_toolTip.Text = "暂无提示";
            this.lbl_toolTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_toolTip.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_runTime
            // 
            this.lbl_runTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_runTime.Location = new System.Drawing.Point(62, 12);
            this.lbl_runTime.Name = "lbl_runTime";
            this.lbl_runTime.Size = new System.Drawing.Size(93, 23);
            this.lbl_runTime.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_runTime.TabIndex = 7;
            this.lbl_runTime.Text = "0 ms";
            this.lbl_runTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_runTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(8, 37);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(58, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 8;
            this.uiLabel3.Text = "提示：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(8, 12);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(58, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 9;
            this.uiLabel1.Text = "耗时：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.LineSize = 2;
            this.uiLine1.Location = new System.Drawing.Point(-2, 5);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(1040, 10);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 5;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(16, 85);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(100, 23);
            this.uiLabel8.TabIndex = 6;
            this.uiLabel8.Text = "推理模式";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // IsQueXian
            // 
            this.IsQueXian.Checked = true;
            this.IsQueXian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IsQueXian.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsQueXian.Location = new System.Drawing.Point(10, 3);
            this.IsQueXian.MinimumSize = new System.Drawing.Size(1, 1);
            this.IsQueXian.Name = "IsQueXian";
            this.IsQueXian.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.IsQueXian.Size = new System.Drawing.Size(110, 29);
            this.IsQueXian.TabIndex = 7;
            this.IsQueXian.Text = "缺陷推理";
            this.IsQueXian.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.IsQueXian.Click += new System.EventHandler(this.IsQueXian_Click);
            // 
            // IsTuXiang
            // 
            this.IsTuXiang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IsTuXiang.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsTuXiang.Location = new System.Drawing.Point(139, 3);
            this.IsTuXiang.MinimumSize = new System.Drawing.Size(1, 1);
            this.IsTuXiang.Name = "IsTuXiang";
            this.IsTuXiang.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.IsTuXiang.Size = new System.Drawing.Size(110, 29);
            this.IsTuXiang.TabIndex = 7;
            this.IsTuXiang.Text = "图像推理";
            this.IsTuXiang.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.IsTuXiang.Click += new System.EventHandler(this.IsQueXian_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.IsTuXiang);
            this.panel5.Controls.Add(this.IsQueXian);
            this.panel5.Location = new System.Drawing.Point(117, 85);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(256, 39);
            this.panel5.TabIndex = 8;
            // 
            // Frm_Inference
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1040, 618);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.ExtendBox = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Inference";
            this.ShowRadius = false;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "语义分割——推理识别";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 1040, 618);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Inference_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.uiTabControl1.ResumeLayout(false);
            this.JieGuo.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHandleData)).EndInit();
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.QuYu.ResumeLayout(false);
            this.Pan_ROI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgBtn_LianRu)).EndInit();
            this.JiaZai.ResumeLayout(false);
            this.SheZhi.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 保存toolStripButton1;
        private System.Windows.Forms.ToolStripButton 复位toolStripButton3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILine uiLine1;
        private System.Windows.Forms.Panel panel3;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage JieGuo;
        private System.Windows.Forms.TabPage JiaZai;
        private System.Windows.Forms.TabPage SheZhi;
        private Sunny.UI.UIButton btn_close;
        private Sunny.UI.UIButton btn_runTask;
        private Sunny.UI.UIButton btn_runTool;
        private System.Windows.Forms.Panel panel4;
        public Sunny.UI.UIDataGridView DgvHandleData;
        internal ChoiceTech.Halcon.Control.HWindow_Final2 hWindow_Final1;
        internal Sunny.UI.UICheckBox ckb_taskFailKeepRun;
        internal Sunny.UI.UILabel lbl_toolTip;
        internal Sunny.UI.UILabel lbl_runTime;
        internal Sunny.UI.UICheckBox Ckb_RunImgShowFrm;
        internal Sunny.UI.UICheckBox Ckb_ShowResult;
        internal Sunny.UI.UICheckBox Ckb_RunRegionShowFrm;
        internal Sunny.UI.UICheckBox Ckb_ShowDgvData;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存更新;
        internal Sunny.UI.UITextBox txt_XunLianHdl;
        internal Sunny.UI.UITextBox txtClassNames;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIRadioButton Rdb_GPU;
        private Sunny.UI.UIRadioButton Rdb_CPU;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.TabPage QuYu;
        private Sunny.UI.UIRadioButton rad_IsQuYu;
        private Sunny.UI.UIRadioButton rad_IsQuanTu;
        private System.Windows.Forms.Panel Pan_ROI;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIImageButton ImgBtn_LianRu;
        internal Sunny.UI.UITextBox txt_LianRu;
        private Sunny.UI.UICheckBox ckb_JianCeRegionToMain;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Sunny.UI.UILabel uiLabel8;
        internal Sunny.UI.UIRadioButton IsQueXian;
        internal Sunny.UI.UIRadioButton IsTuXiang;
        private System.Windows.Forms.Panel panel5;
    }
}