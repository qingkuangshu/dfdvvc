namespace VM_Pro
{
    partial class Frm_ImageEngineTool
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ImageEngineTool));
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_FileName = new Sunny.UI.UITextBox();
            this.cmb_CurrentProduce = new Sunny.UI.UIComboBox();
            this.btn_RunCurrentProcedure = new Sunny.UI.UIButton();
            this.btn_Export = new Sunny.UI.UIButton();
            this.btn_Import = new Sunny.UI.UIButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.Dgv_Input = new Sunny.UI.UIDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            this.cmb_OutDataType = new Sunny.UI.UIComboBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.Dgv_Output = new Sunny.UI.UIDataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Pannel_Left = new Sunny.UI.UIPanel();
            this.Panel_Right = new Sunny.UI.UIPanel();
            this.fastColoredTextBox_Source = new FastColoredTextBoxNS.FastColoredTextBox();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存更改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmb_CurrentTxtProduce = new Sunny.UI.UIComboBox();
            this.Panel_Bottom = new Sunny.UI.UIPanel();
            this.btn_Close = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.btn_runTool = new Sunny.UI.UIButton();
            this.ckb_taskFailKeepRun = new Sunny.UI.UICheckBox();
            this.lbl_toolTip = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.lbl_runTime = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.uiTitlePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Input)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.uiTitlePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Output)).BeginInit();
            this.Pannel_Left.SuspendLayout();
            this.Panel_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_Source)).BeginInit();
            this.uiContextMenuStrip1.SuspendLayout();
            this.Panel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.AutoClosePage = false;
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.Controls.Add(this.tabPage3);
            this.uiTabControl1.Controls.Add(this.tabPage4);
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.Frame = null;
            this.uiTabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(416, 508);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiTabControl1.TabUnSelectedForeColor = System.Drawing.Color.Black;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.TipsForeColor = System.Drawing.Color.Black;
            this.uiTabControl1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Controls.Add(this.txt_FileName);
            this.tabPage1.Controls.Add(this.cmb_CurrentProduce);
            this.tabPage1.Controls.Add(this.btn_RunCurrentProcedure);
            this.tabPage1.Controls.Add(this.btn_Export);
            this.tabPage1.Controls.Add(this.btn_Import);
            this.tabPage1.ForeColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(0, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(416, 478);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本参数";
            // 
            // txt_FileName
            // 
            this.txt_FileName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_FileName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_FileName.Location = new System.Drawing.Point(12, 72);
            this.txt_FileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_FileName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_FileName.Multiline = true;
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.ReadOnly = true;
            this.txt_FileName.ShowText = false;
            this.txt_FileName.Size = new System.Drawing.Size(386, 64);
            this.txt_FileName.TabIndex = 2;
            this.txt_FileName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_FileName.Watermark = "";
            this.txt_FileName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cmb_CurrentProduce
            // 
            this.cmb_CurrentProduce.DataSource = null;
            this.cmb_CurrentProduce.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmb_CurrentProduce.FillColor = System.Drawing.Color.White;
            this.cmb_CurrentProduce.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_CurrentProduce.Location = new System.Drawing.Point(12, 311);
            this.cmb_CurrentProduce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_CurrentProduce.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_CurrentProduce.Name = "cmb_CurrentProduce";
            this.cmb_CurrentProduce.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_CurrentProduce.Size = new System.Drawing.Size(386, 52);
            this.cmb_CurrentProduce.TabIndex = 1;
            this.cmb_CurrentProduce.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cmb_CurrentProduce.Watermark = "";
            this.cmb_CurrentProduce.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cmb_CurrentProduce.SelectedIndexChanged += new System.EventHandler(this.cmb_CurrentProduce_SelectedIndexChanged);
            // 
            // btn_RunCurrentProcedure
            // 
            this.btn_RunCurrentProcedure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RunCurrentProcedure.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RunCurrentProcedure.Location = new System.Drawing.Point(12, 371);
            this.btn_RunCurrentProcedure.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_RunCurrentProcedure.Name = "btn_RunCurrentProcedure";
            this.btn_RunCurrentProcedure.Size = new System.Drawing.Size(386, 57);
            this.btn_RunCurrentProcedure.TabIndex = 0;
            this.btn_RunCurrentProcedure.Text = "运行当前所选程序";
            this.btn_RunCurrentProcedure.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RunCurrentProcedure.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_RunCurrentProcedure.Click += new System.EventHandler(this.btn_RunCurrentProcedure_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Export.Location = new System.Drawing.Point(12, 148);
            this.btn_Export.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(386, 57);
            this.btn_Export.TabIndex = 0;
            this.btn_Export.Text = "导出";
            this.btn_Export.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Export.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_Import
            // 
            this.btn_Import.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Import.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Import.Location = new System.Drawing.Point(12, 1);
            this.btn_Import.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(386, 57);
            this.btn_Import.TabIndex = 0;
            this.btn_Import.Text = "导入";
            this.btn_Import.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Import.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage2.Controls.Add(this.uiTitlePanel1);
            this.tabPage2.ForeColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(0, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(416, 478);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "输入链接";
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.Dgv_Input);
            this.uiTitlePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.Size = new System.Drawing.Size(416, 478);
            this.uiTitlePanel1.TabIndex = 0;
            this.uiTitlePanel1.Text = "输入变量设置";
            this.uiTitlePanel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Dgv_Input
            // 
            this.Dgv_Input.AllowUserToAddRows = false;
            this.Dgv_Input.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Dgv_Input.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Input.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Dgv_Input.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Input.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_Input.ColumnHeadersHeight = 32;
            this.Dgv_Input.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_Input.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Input.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_Input.EnableHeadersVisualStyles = false;
            this.Dgv_Input.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dgv_Input.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Dgv_Input.Location = new System.Drawing.Point(0, 35);
            this.Dgv_Input.Name = "Dgv_Input";
            this.Dgv_Input.ReadOnly = true;
            this.Dgv_Input.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Input.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv_Input.RowHeadersVisible = false;
            this.Dgv_Input.RowHeadersWidth = 35;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dgv_Input.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv_Input.RowTemplate.Height = 27;
            this.Dgv_Input.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Dgv_Input.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Dgv_Input.SelectedIndex = -1;
            this.Dgv_Input.Size = new System.Drawing.Size(416, 443);
            this.Dgv_Input.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Dgv_Input.Style = Sunny.UI.UIStyle.Custom;
            this.Dgv_Input.StyleCustomMode = true;
            this.Dgv_Input.TabIndex = 0;
            this.Dgv_Input.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Dgv_Input.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Input_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.FillWeight = 6.417114F;
            this.Column1.HeaderText = "名称";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 180;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.FillWeight = 193.5829F;
            this.Column2.HeaderText = "变量链接";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 300;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage3.Controls.Add(this.uiTitlePanel2);
            this.tabPage3.ForeColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(0, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(416, 478);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "输出变量";
            // 
            // uiTitlePanel2
            // 
            this.uiTitlePanel2.Controls.Add(this.cmb_OutDataType);
            this.uiTitlePanel2.Controls.Add(this.uiLabel3);
            this.uiTitlePanel2.Controls.Add(this.Dgv_Output);
            this.uiTitlePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiTitlePanel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel2.Location = new System.Drawing.Point(0, 0);
            this.uiTitlePanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel2.Name = "uiTitlePanel2";
            this.uiTitlePanel2.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel2.ShowText = false;
            this.uiTitlePanel2.Size = new System.Drawing.Size(416, 478);
            this.uiTitlePanel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiTitlePanel2.StyleCustomMode = true;
            this.uiTitlePanel2.TabIndex = 0;
            this.uiTitlePanel2.Text = "输出变量展示";
            this.uiTitlePanel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cmb_OutDataType
            // 
            this.cmb_OutDataType.DataSource = null;
            this.cmb_OutDataType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmb_OutDataType.FillColor = System.Drawing.Color.White;
            this.cmb_OutDataType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_OutDataType.Items.AddRange(new object[] {
            "None",
            "Bool",
            "Int",
            "Int数组",
            "Double",
            "String",
            "点云",
            "String数组",
            "图像",
            "区域"});
            this.cmb_OutDataType.Location = new System.Drawing.Point(150, 49);
            this.cmb_OutDataType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_OutDataType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_OutDataType.Name = "cmb_OutDataType";
            this.cmb_OutDataType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_OutDataType.Size = new System.Drawing.Size(248, 33);
            this.cmb_OutDataType.Style = Sunny.UI.UIStyle.Custom;
            this.cmb_OutDataType.TabIndex = 2;
            this.cmb_OutDataType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmb_OutDataType.Watermark = "";
            this.cmb_OutDataType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cmb_OutDataType.SelectedIndexChanged += new System.EventHandler(this.cmb_OutDataType_SelectedIndexChanged);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.White;
            this.uiLabel3.Location = new System.Drawing.Point(32, 49);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(111, 33);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.StyleCustomMode = true;
            this.uiLabel3.TabIndex = 1;
            this.uiLabel3.Text = "类型选择 :";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Dgv_Output
            // 
            this.Dgv_Output.AllowUserToAddRows = false;
            this.Dgv_Output.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Dgv_Output.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv_Output.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Output.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Dgv_Output.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Output.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.Dgv_Output.ColumnHeadersHeight = 32;
            this.Dgv_Output.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_Output.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Output.DefaultCellStyle = dataGridViewCellStyle8;
            this.Dgv_Output.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Dgv_Output.EnableHeadersVisualStyles = false;
            this.Dgv_Output.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dgv_Output.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Dgv_Output.Location = new System.Drawing.Point(0, 90);
            this.Dgv_Output.Name = "Dgv_Output";
            this.Dgv_Output.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Output.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.Dgv_Output.RowHeadersVisible = false;
            this.Dgv_Output.RowHeadersWidth = 51;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dgv_Output.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.Dgv_Output.RowTemplate.Height = 27;
            this.Dgv_Output.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Dgv_Output.SelectedIndex = -1;
            this.Dgv_Output.Size = new System.Drawing.Size(416, 388);
            this.Dgv_Output.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Dgv_Output.Style = Sunny.UI.UIStyle.Custom;
            this.Dgv_Output.StyleCustomMode = true;
            this.Dgv_Output.TabIndex = 0;
            this.Dgv_Output.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Column3
            // 
            this.Column3.FillWeight = 80.21391F;
            this.Column3.HeaderText = "名称";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 109.8931F;
            this.Column4.HeaderText = "变量类型";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 109.8931F;
            this.Column5.HeaderText = "数值";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage4.ForeColor = System.Drawing.Color.White;
            this.tabPage4.Location = new System.Drawing.Point(0, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(416, 478);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "其他选项";
            // 
            // Pannel_Left
            // 
            this.Pannel_Left.Controls.Add(this.uiTabControl1);
            this.Pannel_Left.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pannel_Left.Location = new System.Drawing.Point(4, 40);
            this.Pannel_Left.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Pannel_Left.MinimumSize = new System.Drawing.Size(1, 1);
            this.Pannel_Left.Name = "Pannel_Left";
            this.Pannel_Left.Size = new System.Drawing.Size(416, 508);
            this.Pannel_Left.TabIndex = 2;
            this.Pannel_Left.Text = null;
            this.Pannel_Left.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Pannel_Left.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Panel_Right
            // 
            this.Panel_Right.Controls.Add(this.fastColoredTextBox_Source);
            this.Panel_Right.Controls.Add(this.cmb_CurrentTxtProduce);
            this.Panel_Right.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Panel_Right.Location = new System.Drawing.Point(428, 40);
            this.Panel_Right.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel_Right.MinimumSize = new System.Drawing.Size(1, 1);
            this.Panel_Right.Name = "Panel_Right";
            this.Panel_Right.Size = new System.Drawing.Size(608, 508);
            this.Panel_Right.TabIndex = 3;
            this.Panel_Right.Text = null;
            this.Panel_Right.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Panel_Right.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // fastColoredTextBox_Source
            // 
            this.fastColoredTextBox_Source.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox_Source.AutoScrollMinSize = new System.Drawing.Size(31, 18);
            this.fastColoredTextBox_Source.BackBrush = null;
            this.fastColoredTextBox_Source.CharCnWidth = 21;
            this.fastColoredTextBox_Source.CharHeight = 18;
            this.fastColoredTextBox_Source.CharWidth = 10;
            this.fastColoredTextBox_Source.ContextMenuStrip = this.uiContextMenuStrip1;
            this.fastColoredTextBox_Source.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox_Source.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox_Source.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBox_Source.ForeColor = System.Drawing.SystemColors.Highlight;
            this.fastColoredTextBox_Source.IsReplaceMode = false;
            this.fastColoredTextBox_Source.Location = new System.Drawing.Point(0, 53);
            this.fastColoredTextBox_Source.Name = "fastColoredTextBox_Source";
            this.fastColoredTextBox_Source.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox_Source.ReadOnly = true;
            this.fastColoredTextBox_Source.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox_Source.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox_Source.ServiceColors")));
            this.fastColoredTextBox_Source.Size = new System.Drawing.Size(608, 455);
            this.fastColoredTextBox_Source.TabIndex = 1;
            this.fastColoredTextBox_Source.Zoom = 100;
            this.fastColoredTextBox_Source.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fastColoredTextBox_Source_TextChangedDelayed);
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem,
            this.保存更改ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(165, 68);
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 保存更改ToolStripMenuItem
            // 
            this.保存更改ToolStripMenuItem.Name = "保存更改ToolStripMenuItem";
            this.保存更改ToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.保存更改ToolStripMenuItem.Text = "保存更改";
            this.保存更改ToolStripMenuItem.Click += new System.EventHandler(this.保存更改ToolStripMenuItem_Click);
            // 
            // cmb_CurrentTxtProduce
            // 
            this.cmb_CurrentTxtProduce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmb_CurrentTxtProduce.DataSource = null;
            this.cmb_CurrentTxtProduce.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmb_CurrentTxtProduce.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmb_CurrentTxtProduce.FillColor = System.Drawing.Color.White;
            this.cmb_CurrentTxtProduce.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_CurrentTxtProduce.Location = new System.Drawing.Point(0, 0);
            this.cmb_CurrentTxtProduce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_CurrentTxtProduce.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_CurrentTxtProduce.Name = "cmb_CurrentTxtProduce";
            this.cmb_CurrentTxtProduce.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_CurrentTxtProduce.Size = new System.Drawing.Size(608, 53);
            this.cmb_CurrentTxtProduce.TabIndex = 0;
            this.cmb_CurrentTxtProduce.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cmb_CurrentTxtProduce.Watermark = "";
            this.cmb_CurrentTxtProduce.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cmb_CurrentTxtProduce.SelectedIndexChanged += new System.EventHandler(this.cmb_CurrentTxtProduce_SelectedIndexChanged);
            // 
            // Panel_Bottom
            // 
            this.Panel_Bottom.Controls.Add(this.btn_Close);
            this.Panel_Bottom.Controls.Add(this.uiButton2);
            this.Panel_Bottom.Controls.Add(this.btn_runTool);
            this.Panel_Bottom.Controls.Add(this.ckb_taskFailKeepRun);
            this.Panel_Bottom.Controls.Add(this.lbl_toolTip);
            this.Panel_Bottom.Controls.Add(this.uiLabel2);
            this.Panel_Bottom.Controls.Add(this.lbl_runTime);
            this.Panel_Bottom.Controls.Add(this.uiLabel1);
            this.Panel_Bottom.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Panel_Bottom.Location = new System.Drawing.Point(4, 552);
            this.Panel_Bottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel_Bottom.MinimumSize = new System.Drawing.Size(1, 1);
            this.Panel_Bottom.Name = "Panel_Bottom";
            this.Panel_Bottom.Size = new System.Drawing.Size(1032, 62);
            this.Panel_Bottom.TabIndex = 4;
            this.Panel_Bottom.Text = null;
            this.Panel_Bottom.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Panel_Bottom.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_Close
            // 
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.Location = new System.Drawing.Point(926, 18);
            this.btn_Close.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 32);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "关闭";
            this.btn_Close.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(658, 18);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(75, 32);
            this.uiButton2.TabIndex = 2;
            this.uiButton2.Text = "运行流程";
            this.uiButton2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_runTool
            // 
            this.btn_runTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runTool.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTool.Location = new System.Drawing.Point(568, 18);
            this.btn_runTool.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_runTool.Name = "btn_runTool";
            this.btn_runTool.Size = new System.Drawing.Size(75, 32);
            this.btn_runTool.TabIndex = 2;
            this.btn_runTool.Text = "运行工具";
            this.btn_runTool.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTool.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_runTool.Click += new System.EventHandler(this.btn_runTool_Click);
            // 
            // ckb_taskFailKeepRun
            // 
            this.ckb_taskFailKeepRun.Checked = true;
            this.ckb_taskFailKeepRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_taskFailKeepRun.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_taskFailKeepRun.Location = new System.Drawing.Point(229, 9);
            this.ckb_taskFailKeepRun.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_taskFailKeepRun.Name = "ckb_taskFailKeepRun";
            this.ckb_taskFailKeepRun.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_taskFailKeepRun.Size = new System.Drawing.Size(169, 30);
            this.ckb_taskFailKeepRun.TabIndex = 1;
            this.ckb_taskFailKeepRun.Text = "流程失败仍运行";
            this.ckb_taskFailKeepRun.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_taskFailKeepRun.Click += new System.EventHandler(this.ckb_taskFailKeepRun_Click);
            // 
            // lbl_toolTip
            // 
            this.lbl_toolTip.AutoSize = true;
            this.lbl_toolTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_toolTip.Location = new System.Drawing.Point(85, 32);
            this.lbl_toolTip.Name = "lbl_toolTip";
            this.lbl_toolTip.Size = new System.Drawing.Size(92, 27);
            this.lbl_toolTip.TabIndex = 0;
            this.lbl_toolTip.Text = "暂无提示";
            this.lbl_toolTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_toolTip.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(13, 32);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(66, 23);
            this.uiLabel2.TabIndex = 0;
            this.uiLabel2.Text = "提示 :";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_runTime
            // 
            this.lbl_runTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_runTime.Location = new System.Drawing.Point(85, 9);
            this.lbl_runTime.Name = "lbl_runTime";
            this.lbl_runTime.Size = new System.Drawing.Size(110, 23);
            this.lbl_runTime.TabIndex = 0;
            this.lbl_runTime.Text = "0 ms";
            this.lbl_runTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_runTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(13, 9);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(66, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "耗时 :";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Frm_ImageEngineTool
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1040, 618);
            this.Controls.Add(this.Panel_Bottom);
            this.Controls.Add(this.Panel_Right);
            this.Controls.Add(this.Pannel_Left);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_ImageEngineTool";
            this.ShowTitleIcon = true;
            this.Text = "图像脚本";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ImageEngineTool_FormClosing);
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.uiTitlePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Input)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.uiTitlePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Output)).EndInit();
            this.Pannel_Left.ResumeLayout(false);
            this.Panel_Right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_Source)).EndInit();
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.Panel_Bottom.ResumeLayout(false);
            this.Panel_Bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private Sunny.UI.UIPanel Pannel_Left;
        private Sunny.UI.UIPanel Panel_Right;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox_Source;
        private Sunny.UI.UIComboBox cmb_CurrentTxtProduce;
        private Sunny.UI.UIPanel Panel_Bottom;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton btn_runTool;
        private Sunny.UI.UIButton btn_Close;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIComboBox cmb_CurrentProduce;
        private Sunny.UI.UIButton btn_RunCurrentProcedure;
        private Sunny.UI.UIButton btn_Export;
        private Sunny.UI.UIButton btn_Import;
        private Sunny.UI.UITextBox txt_FileName;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UIDataGridView Dgv_Input;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private Sunny.UI.UIComboBox cmb_OutDataType;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIDataGridView Dgv_Output;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存更改ToolStripMenuItem;
        internal Sunny.UI.UILabel lbl_toolTip;
        internal Sunny.UI.UILabel lbl_runTime;
        internal Sunny.UI.UICheckBox ckb_taskFailKeepRun;
    }
}