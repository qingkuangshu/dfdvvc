namespace VM_Pro
{
    partial class Frm_OCRTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_OCRTool));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.保存toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.复位toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RadQuYu = new Sunny.UI.UIRadioButton();
            this.RadGenSuiQuYu = new Sunny.UI.UIRadioButton();
            this.HuiDuMax = new Sunny.UI.UITextBox();
            this.AreaMax = new Sunny.UI.UITextBox();
            this.AreaMin = new Sunny.UI.UITextBox();
            this.HuiDuMin = new Sunny.UI.UITextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_drawAny = new Sunny.UI.UIButton();
            this.btn_drawCircle = new Sunny.UI.UIButton();
            this.btn_drawRing = new Sunny.UI.UIButton();
            this.btn_drawRectangle2 = new Sunny.UI.UIButton();
            this.btn_drawEllipse = new Sunny.UI.UIButton();
            this.btn_drawRectangle1 = new Sunny.UI.UIButton();
            this.rdo_ClearRegion = new Sunny.UI.UIRadioButton();
            this.rdo_subRegion = new Sunny.UI.UIRadioButton();
            this.rdo_addRegion = new Sunny.UI.UIRadioButton();
            this.uiLine2 = new Sunny.UI.UILine();
            this.cbx_charType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_searchRegionType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_codeRule = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbxLuJing = new System.Windows.Forms.TextBox();
            this.cmbAllOCR = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.uiCheckBox2 = new Sunny.UI.UICheckBox();
            this.uiCheckBox1 = new Sunny.UI.UICheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.lstInfo = new System.Windows.Forms.ListBox();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final2();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.适应窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckb_taskFailKeepRun = new Sunny.UI.UICheckBox();
            this.btn_close = new Sunny.UI.UIButton();
            this.uiLine1 = new Sunny.UI.UILine();
            this.btn_runTask = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.btn_runTool = new Sunny.UI.UIButton();
            this.lbl_runTime = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.lbl_toolTip = new Sunny.UI.UILabel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.uiContextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存toolStripButton1,
            this.复位toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 35);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
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
            this.复位toolStripButton3.Text = "toolStripButton2";
            this.复位toolStripButton3.ToolTipText = "复位";
            this.复位toolStripButton3.Click += new System.EventHandler(this.复位toolStripButton3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.hWindow_Final1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 547);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uiTabControl1);
            this.panel3.Location = new System.Drawing.Point(656, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(381, 483);
            this.panel3.TabIndex = 17;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.Controls.Add(this.tabPage3);
            this.uiTabControl1.Controls.Add(this.tabPage4);
            this.uiTabControl1.Controls.Add(this.tabPage5);
            this.uiTabControl1.Controls.Add(this.tabPage6);
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTabControl1.ItemSize = new System.Drawing.Size(60, 28);
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
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.RadQuYu);
            this.tabPage1.Controls.Add(this.RadGenSuiQuYu);
            this.tabPage1.Controls.Add(this.HuiDuMax);
            this.tabPage1.Controls.Add(this.AreaMax);
            this.tabPage1.Controls.Add(this.AreaMin);
            this.tabPage1.Controls.Add(this.HuiDuMin);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.tbxResult);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.cbx_charType);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbx_searchRegionType);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbx_codeRule);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(0, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(381, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "参数";
            // 
            // RadQuYu
            // 
            this.RadQuYu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RadQuYu.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.RadQuYu.Location = new System.Drawing.Point(35, 271);
            this.RadQuYu.MinimumSize = new System.Drawing.Size(1, 1);
            this.RadQuYu.Name = "RadQuYu";
            this.RadQuYu.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.RadQuYu.Size = new System.Drawing.Size(91, 29);
            this.RadQuYu.Style = Sunny.UI.UIStyle.Custom;
            this.RadQuYu.TabIndex = 10;
            this.RadQuYu.Text = "自区域";
            this.RadQuYu.Click += new System.EventHandler(this.RadQuYu_Click);
            // 
            // RadGenSuiQuYu
            // 
            this.RadGenSuiQuYu.Checked = true;
            this.RadGenSuiQuYu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RadGenSuiQuYu.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.RadGenSuiQuYu.Location = new System.Drawing.Point(35, 236);
            this.RadGenSuiQuYu.MinimumSize = new System.Drawing.Size(1, 1);
            this.RadGenSuiQuYu.Name = "RadGenSuiQuYu";
            this.RadGenSuiQuYu.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.RadGenSuiQuYu.Size = new System.Drawing.Size(150, 29);
            this.RadGenSuiQuYu.Style = Sunny.UI.UIStyle.Custom;
            this.RadGenSuiQuYu.TabIndex = 10;
            this.RadGenSuiQuYu.Text = "跟随模板区域";
            this.RadGenSuiQuYu.Click += new System.EventHandler(this.RadGenSuiQuYu_Click);
            // 
            // HuiDuMax
            // 
            this.HuiDuMax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.HuiDuMax.DoubleValue = 150D;
            this.HuiDuMax.FillColor = System.Drawing.Color.White;
            this.HuiDuMax.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.HuiDuMax.IntValue = 150;
            this.HuiDuMax.Location = new System.Drawing.Point(237, 162);
            this.HuiDuMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HuiDuMax.Maximum = 2147483647D;
            this.HuiDuMax.Minimum = -2147483648D;
            this.HuiDuMax.MinimumSize = new System.Drawing.Size(1, 1);
            this.HuiDuMax.Name = "HuiDuMax";
            this.HuiDuMax.Size = new System.Drawing.Size(100, 29);
            this.HuiDuMax.Style = Sunny.UI.UIStyle.Custom;
            this.HuiDuMax.TabIndex = 9;
            this.HuiDuMax.Text = "150";
            this.HuiDuMax.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.HuiDuMax.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            // 
            // AreaMax
            // 
            this.AreaMax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AreaMax.DoubleValue = 1500D;
            this.AreaMax.FillColor = System.Drawing.Color.White;
            this.AreaMax.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.AreaMax.IntValue = 1500;
            this.AreaMax.Location = new System.Drawing.Point(237, 199);
            this.AreaMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AreaMax.Maximum = 2147483647D;
            this.AreaMax.Minimum = -2147483648D;
            this.AreaMax.MinimumSize = new System.Drawing.Size(1, 1);
            this.AreaMax.Name = "AreaMax";
            this.AreaMax.Size = new System.Drawing.Size(100, 29);
            this.AreaMax.Style = Sunny.UI.UIStyle.Custom;
            this.AreaMax.TabIndex = 9;
            this.AreaMax.Text = "1500";
            this.AreaMax.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.AreaMax.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            // 
            // AreaMin
            // 
            this.AreaMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AreaMin.FillColor = System.Drawing.Color.White;
            this.AreaMin.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.AreaMin.Location = new System.Drawing.Point(98, 199);
            this.AreaMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AreaMin.Maximum = 2147483647D;
            this.AreaMin.Minimum = -2147483648D;
            this.AreaMin.MinimumSize = new System.Drawing.Size(1, 1);
            this.AreaMin.Name = "AreaMin";
            this.AreaMin.Size = new System.Drawing.Size(100, 29);
            this.AreaMin.Style = Sunny.UI.UIStyle.Custom;
            this.AreaMin.TabIndex = 9;
            this.AreaMin.Text = "0";
            this.AreaMin.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.AreaMin.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            // 
            // HuiDuMin
            // 
            this.HuiDuMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.HuiDuMin.FillColor = System.Drawing.Color.White;
            this.HuiDuMin.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.HuiDuMin.Location = new System.Drawing.Point(98, 162);
            this.HuiDuMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HuiDuMin.Maximum = 2147483647D;
            this.HuiDuMin.Minimum = -2147483648D;
            this.HuiDuMin.MinimumSize = new System.Drawing.Size(1, 1);
            this.HuiDuMin.Name = "HuiDuMin";
            this.HuiDuMin.Size = new System.Drawing.Size(100, 29);
            this.HuiDuMin.Style = Sunny.UI.UIStyle.Custom;
            this.HuiDuMin.TabIndex = 9;
            this.HuiDuMin.Text = "0";
            this.HuiDuMin.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.HuiDuMin.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 71);
            this.button1.TabIndex = 8;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxResult
            // 
            this.tbxResult.Location = new System.Drawing.Point(88, 123);
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.Size = new System.Drawing.Size(281, 29);
            this.tbxResult.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(204, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 21);
            this.label10.TabIndex = 5;
            this.label10.Text = "—";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 21);
            this.label8.TabIndex = 5;
            this.label8.Text = "面积选择 :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 21);
            this.label9.TabIndex = 5;
            this.label9.Text = "—";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "灰度选择 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "识别结果 :";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_drawAny);
            this.panel4.Controls.Add(this.btn_drawCircle);
            this.panel4.Controls.Add(this.btn_drawRing);
            this.panel4.Controls.Add(this.btn_drawRectangle2);
            this.panel4.Controls.Add(this.btn_drawEllipse);
            this.panel4.Controls.Add(this.btn_drawRectangle1);
            this.panel4.Controls.Add(this.rdo_ClearRegion);
            this.panel4.Controls.Add(this.rdo_subRegion);
            this.panel4.Controls.Add(this.rdo_addRegion);
            this.panel4.Controls.Add(this.uiLine2);
            this.panel4.Location = new System.Drawing.Point(0, 313);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(378, 139);
            this.panel4.TabIndex = 4;
            // 
            // btn_drawAny
            // 
            this.btn_drawAny.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_drawAny.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_drawAny.Location = new System.Drawing.Point(231, 101);
            this.btn_drawAny.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_drawAny.Name = "btn_drawAny";
            this.btn_drawAny.Size = new System.Drawing.Size(70, 32);
            this.btn_drawAny.Style = Sunny.UI.UIStyle.Custom;
            this.btn_drawAny.TabIndex = 2;
            this.btn_drawAny.Text = "任意";
            this.btn_drawAny.Click += new System.EventHandler(this.btn_drawAny_Click);
            // 
            // btn_drawCircle
            // 
            this.btn_drawCircle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_drawCircle.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_drawCircle.Location = new System.Drawing.Point(231, 63);
            this.btn_drawCircle.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_drawCircle.Name = "btn_drawCircle";
            this.btn_drawCircle.Size = new System.Drawing.Size(70, 32);
            this.btn_drawCircle.Style = Sunny.UI.UIStyle.Custom;
            this.btn_drawCircle.TabIndex = 2;
            this.btn_drawCircle.Text = "圆";
            this.btn_drawCircle.Click += new System.EventHandler(this.btn_drawCircle_Click);
            // 
            // btn_drawRing
            // 
            this.btn_drawRing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_drawRing.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_drawRing.Location = new System.Drawing.Point(139, 101);
            this.btn_drawRing.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_drawRing.Name = "btn_drawRing";
            this.btn_drawRing.Size = new System.Drawing.Size(70, 32);
            this.btn_drawRing.Style = Sunny.UI.UIStyle.Custom;
            this.btn_drawRing.TabIndex = 2;
            this.btn_drawRing.Text = "圆环";
            this.btn_drawRing.Click += new System.EventHandler(this.btn_drawRing_Click);
            // 
            // btn_drawRectangle2
            // 
            this.btn_drawRectangle2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_drawRectangle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_drawRectangle2.Location = new System.Drawing.Point(139, 63);
            this.btn_drawRectangle2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_drawRectangle2.Name = "btn_drawRectangle2";
            this.btn_drawRectangle2.Size = new System.Drawing.Size(70, 32);
            this.btn_drawRectangle2.Style = Sunny.UI.UIStyle.Custom;
            this.btn_drawRectangle2.TabIndex = 2;
            this.btn_drawRectangle2.Text = "仿矩";
            this.btn_drawRectangle2.Click += new System.EventHandler(this.btn_drawRectangle2_Click);
            // 
            // btn_drawEllipse
            // 
            this.btn_drawEllipse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_drawEllipse.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_drawEllipse.Location = new System.Drawing.Point(51, 101);
            this.btn_drawEllipse.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_drawEllipse.Name = "btn_drawEllipse";
            this.btn_drawEllipse.Size = new System.Drawing.Size(70, 32);
            this.btn_drawEllipse.Style = Sunny.UI.UIStyle.Custom;
            this.btn_drawEllipse.TabIndex = 2;
            this.btn_drawEllipse.Text = "椭圆";
            this.btn_drawEllipse.Click += new System.EventHandler(this.btn_drawEllipse_Click);
            // 
            // btn_drawRectangle1
            // 
            this.btn_drawRectangle1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_drawRectangle1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_drawRectangle1.Location = new System.Drawing.Point(51, 63);
            this.btn_drawRectangle1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_drawRectangle1.Name = "btn_drawRectangle1";
            this.btn_drawRectangle1.Size = new System.Drawing.Size(70, 32);
            this.btn_drawRectangle1.Style = Sunny.UI.UIStyle.Custom;
            this.btn_drawRectangle1.TabIndex = 2;
            this.btn_drawRectangle1.Text = "矩形";
            this.btn_drawRectangle1.Click += new System.EventHandler(this.btn_drawRectangle1_Click);
            // 
            // rdo_ClearRegion
            // 
            this.rdo_ClearRegion.Checked = true;
            this.rdo_ClearRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_ClearRegion.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rdo_ClearRegion.Location = new System.Drawing.Point(231, 28);
            this.rdo_ClearRegion.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_ClearRegion.Name = "rdo_ClearRegion";
            this.rdo_ClearRegion.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_ClearRegion.Size = new System.Drawing.Size(96, 29);
            this.rdo_ClearRegion.Style = Sunny.UI.UIStyle.Custom;
            this.rdo_ClearRegion.TabIndex = 1;
            this.rdo_ClearRegion.Text = "重新绘制";
            // 
            // rdo_subRegion
            // 
            this.rdo_subRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_subRegion.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rdo_subRegion.Location = new System.Drawing.Point(119, 28);
            this.rdo_subRegion.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_subRegion.Name = "rdo_subRegion";
            this.rdo_subRegion.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_subRegion.Size = new System.Drawing.Size(96, 29);
            this.rdo_subRegion.Style = Sunny.UI.UIStyle.Custom;
            this.rdo_subRegion.TabIndex = 1;
            this.rdo_subRegion.Text = "减少区域";
            // 
            // rdo_addRegion
            // 
            this.rdo_addRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_addRegion.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rdo_addRegion.Location = new System.Drawing.Point(7, 28);
            this.rdo_addRegion.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_addRegion.Name = "rdo_addRegion";
            this.rdo_addRegion.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_addRegion.Size = new System.Drawing.Size(96, 29);
            this.rdo_addRegion.Style = Sunny.UI.UIStyle.Custom;
            this.rdo_addRegion.TabIndex = 1;
            this.rdo_addRegion.Text = "增加区域";
            // 
            // uiLine2
            // 
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine2.Location = new System.Drawing.Point(0, 3);
            this.uiLine2.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(375, 29);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 0;
            this.uiLine2.Text = "绘制区域";
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbx_charType
            // 
            this.cbx_charType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_charType.FormattingEnabled = true;
            this.cbx_charType.Items.AddRange(new object[] {
            "白底黑字",
            "黑底白字"});
            this.cbx_charType.Location = new System.Drawing.Point(88, 52);
            this.cbx_charType.Name = "cbx_charType";
            this.cbx_charType.Size = new System.Drawing.Size(202, 29);
            this.cbx_charType.TabIndex = 3;
            this.cbx_charType.SelectedIndexChanged += new System.EventHandler(this.cbx_charType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "文本类型 :";
            // 
            // cbx_searchRegionType
            // 
            this.cbx_searchRegionType.BackColor = System.Drawing.SystemColors.Window;
            this.cbx_searchRegionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_searchRegionType.Enabled = false;
            this.cbx_searchRegionType.FormattingEnabled = true;
            this.cbx_searchRegionType.Items.AddRange(new object[] {
            "整幅图像",
            "矩形",
            "仿射矩形",
            "圆"});
            this.cbx_searchRegionType.Location = new System.Drawing.Point(88, 17);
            this.cbx_searchRegionType.Name = "cbx_searchRegionType";
            this.cbx_searchRegionType.Size = new System.Drawing.Size(202, 29);
            this.cbx_searchRegionType.TabIndex = 3;
            this.cbx_searchRegionType.SelectedIndexChanged += new System.EventHandler(this.cbx_searchRegionType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "绘制类型 :";
            // 
            // tbx_codeRule
            // 
            this.tbx_codeRule.Location = new System.Drawing.Point(88, 88);
            this.tbx_codeRule.Name = "tbx_codeRule";
            this.tbx_codeRule.Size = new System.Drawing.Size(202, 29);
            this.tbx_codeRule.TabIndex = 2;
            this.tbx_codeRule.TextChanged += new System.EventHandler(this.tbx_codeRule_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "规则 :";
            // 
            // tabPage2
            // 
            this.tabPage2.ForeColor = System.Drawing.Color.Black;
            this.tabPage2.Location = new System.Drawing.Point(0, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(381, 455);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "训练";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbxLuJing);
            this.tabPage3.Controls.Add(this.cmbAllOCR);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.ForeColor = System.Drawing.Color.Black;
            this.tabPage3.Location = new System.Drawing.Point(0, 28);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(381, 455);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "模板";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbxLuJing
            // 
            this.tbxLuJing.Location = new System.Drawing.Point(41, 3);
            this.tbxLuJing.Multiline = true;
            this.tbxLuJing.Name = "tbxLuJing";
            this.tbxLuJing.Size = new System.Drawing.Size(328, 87);
            this.tbxLuJing.TabIndex = 3;
            this.tbxLuJing.DoubleClick += new System.EventHandler(this.tbxLuJing_DoubleClick);
            // 
            // cmbAllOCR
            // 
            this.cmbAllOCR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllOCR.FormattingEnabled = true;
            this.cmbAllOCR.Location = new System.Drawing.Point(134, 122);
            this.cmbAllOCR.Name = "cmbAllOCR";
            this.cmbAllOCR.Size = new System.Drawing.Size(244, 29);
            this.cmbAllOCR.TabIndex = 1;
            this.cmbAllOCR.SelectedIndexChanged += new System.EventHandler(this.cmbAllOCR_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "路径";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "当前所有OCR库 :";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.uiCheckBox2);
            this.tabPage4.Controls.Add(this.uiCheckBox1);
            this.tabPage4.ForeColor = System.Drawing.Color.Black;
            this.tabPage4.Location = new System.Drawing.Point(0, 28);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(381, 455);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "显示";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // uiCheckBox2
            // 
            this.uiCheckBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiCheckBox2.Location = new System.Drawing.Point(7, 71);
            this.uiCheckBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox2.Name = "uiCheckBox2";
            this.uiCheckBox2.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox2.Size = new System.Drawing.Size(96, 29);
            this.uiCheckBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiCheckBox2.TabIndex = 0;
            this.uiCheckBox2.Text = "显示特征";
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiCheckBox1.Location = new System.Drawing.Point(7, 36);
            this.uiCheckBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox1.Size = new System.Drawing.Size(150, 29);
            this.uiCheckBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiCheckBox1.TabIndex = 0;
            this.uiCheckBox1.Text = "显示中心十字架";
            // 
            // tabPage5
            // 
            this.tabPage5.ForeColor = System.Drawing.Color.Black;
            this.tabPage5.Location = new System.Drawing.Point(0, 28);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(381, 455);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "结果";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.lstInfo);
            this.tabPage6.Location = new System.Drawing.Point(0, 28);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(381, 455);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "执行日志";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // lstInfo
            // 
            this.lstInfo.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lstInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInfo.ForeColor = System.Drawing.SystemColors.Window;
            this.lstInfo.FormattingEnabled = true;
            this.lstInfo.ItemHeight = 21;
            this.lstInfo.Items.AddRange(new object[] {
            "相关功能正在开发中"});
            this.lstInfo.Location = new System.Drawing.Point(0, 0);
            this.lstInfo.Name = "lstInfo";
            this.lstInfo.Size = new System.Drawing.Size(381, 455);
            this.lstInfo.TabIndex = 0;
            // 
            // hWindow_Final1
            // 
            this.hWindow_Final1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final1.ContextMenuStrip = this.uiContextMenuStrip1;
            this.hWindow_Final1.DrawModel = false;
            this.hWindow_Final1.EditModel = true;
            this.hWindow_Final1.Image = null;
            this.hWindow_Final1.Location = new System.Drawing.Point(5, -2);
            this.hWindow_Final1.Margin = new System.Windows.Forms.Padding(5);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(650, 488);
            this.hWindow_Final1.TabIndex = 16;
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.适应窗体ToolStripMenuItem,
            this.图像信息ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(145, 56);
            // 
            // 适应窗体ToolStripMenuItem
            // 
            this.适应窗体ToolStripMenuItem.Name = "适应窗体ToolStripMenuItem";
            this.适应窗体ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.适应窗体ToolStripMenuItem.Text = "适应窗体";
            this.适应窗体ToolStripMenuItem.Click += new System.EventHandler(this.适应窗体ToolStripMenuItem_Click);
            // 
            // 图像信息ToolStripMenuItem
            // 
            this.图像信息ToolStripMenuItem.Name = "图像信息ToolStripMenuItem";
            this.图像信息ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.图像信息ToolStripMenuItem.Text = "图像信息";
            this.图像信息ToolStripMenuItem.Click += new System.EventHandler(this.图像信息ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckb_taskFailKeepRun);
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.uiLine1);
            this.panel2.Controls.Add(this.btn_runTask);
            this.panel2.Controls.Add(this.uiLabel1);
            this.panel2.Controls.Add(this.btn_runTool);
            this.panel2.Controls.Add(this.lbl_runTime);
            this.panel2.Controls.Add(this.uiLabel2);
            this.panel2.Controls.Add(this.lbl_toolTip);
            this.panel2.Location = new System.Drawing.Point(3, 487);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1040, 57);
            this.panel2.TabIndex = 15;
            // 
            // ckb_taskFailKeepRun
            // 
            this.ckb_taskFailKeepRun.Checked = true;
            this.ckb_taskFailKeepRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_taskFailKeepRun.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ckb_taskFailKeepRun.Location = new System.Drawing.Point(168, 9);
            this.ckb_taskFailKeepRun.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_taskFailKeepRun.Name = "ckb_taskFailKeepRun";
            this.ckb_taskFailKeepRun.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_taskFailKeepRun.Size = new System.Drawing.Size(150, 29);
            this.ckb_taskFailKeepRun.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_taskFailKeepRun.TabIndex = 11;
            this.ckb_taskFailKeepRun.Text = "流程失败仍运行";
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_close.Location = new System.Drawing.Point(947, 19);
            this.btn_close.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 32);
            this.btn_close.Style = Sunny.UI.UIStyle.Custom;
            this.btn_close.TabIndex = 12;
            this.btn_close.Text = "关闭";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.LineSize = 2;
            this.uiLine1.Location = new System.Drawing.Point(2, 2);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(1032, 10);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 6;
            // 
            // btn_runTask
            // 
            this.btn_runTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runTask.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_runTask.Location = new System.Drawing.Point(787, 19);
            this.btn_runTask.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_runTask.Name = "btn_runTask";
            this.btn_runTask.Size = new System.Drawing.Size(75, 32);
            this.btn_runTask.Style = Sunny.UI.UIStyle.Custom;
            this.btn_runTask.TabIndex = 13;
            this.btn_runTask.Text = "运行流程";
            this.btn_runTask.Click += new System.EventHandler(this.btn_runTask_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(3, 9);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(53, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 10;
            this.uiLabel1.Text = "耗时 :";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_runTool
            // 
            this.btn_runTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runTool.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_runTool.Location = new System.Drawing.Point(704, 19);
            this.btn_runTool.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_runTool.Name = "btn_runTool";
            this.btn_runTool.Size = new System.Drawing.Size(75, 32);
            this.btn_runTool.Style = Sunny.UI.UIStyle.Custom;
            this.btn_runTool.TabIndex = 14;
            this.btn_runTool.Text = "运行工具";
            this.btn_runTool.Click += new System.EventHandler(this.btn_runTool_Click);
            // 
            // lbl_runTime
            // 
            this.lbl_runTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_runTime.Location = new System.Drawing.Point(62, 9);
            this.lbl_runTime.Name = "lbl_runTime";
            this.lbl_runTime.Size = new System.Drawing.Size(100, 23);
            this.lbl_runTime.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_runTime.TabIndex = 9;
            this.lbl_runTime.Text = "0 ms";
            this.lbl_runTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(3, 35);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(53, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 8;
            this.uiLabel2.Text = "提示 :";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_toolTip
            // 
            this.lbl_toolTip.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_toolTip.Location = new System.Drawing.Point(62, 35);
            this.lbl_toolTip.Name = "lbl_toolTip";
            this.lbl_toolTip.Size = new System.Drawing.Size(605, 23);
            this.lbl_toolTip.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_toolTip.TabIndex = 7;
            this.lbl_toolTip.Text = "暂无提示";
            this.lbl_toolTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_OCRTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 618);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.ExtendBox = true;
            this.MaximizeBox = false;
            this.Name = "Frm_OCRTool";
            this.ShowIcon = true;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "OCR字符识别";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_OCRTool_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 保存toolStripButton1;
        private System.Windows.Forms.ToolStripButton 复位toolStripButton3;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UIButton btn_close;
        private Sunny.UI.UIButton btn_runTask;
        private Sunny.UI.UIButton btn_runTool;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILine uiLine1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal ChoiceTech.Halcon.Control.HWindow_Final2 hWindow_Final1;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 适应窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像信息ToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private Sunny.UI.UILine uiLine2;
        internal Sunny.UI.UIRadioButton rdo_addRegion;
        internal Sunny.UI.UIRadioButton rdo_subRegion;
        internal Sunny.UI.UIButton btn_drawRectangle1;
        internal Sunny.UI.UIButton btn_drawAny;
        internal Sunny.UI.UIButton btn_drawCircle;
        internal Sunny.UI.UIButton btn_drawRing;
        internal Sunny.UI.UIButton btn_drawRectangle2;
        internal Sunny.UI.UIButton btn_drawEllipse;
        internal Sunny.UI.UIRadioButton rdo_ClearRegion;
        private Sunny.UI.UICheckBox uiCheckBox2;
        private Sunny.UI.UICheckBox uiCheckBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cmbAllOCR;
        internal System.Windows.Forms.TextBox tbxLuJing;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        internal Sunny.UI.UICheckBox ckb_taskFailKeepRun;
        internal Sunny.UI.UILabel lbl_toolTip;
        internal Sunny.UI.UILabel lbl_runTime;
        internal System.Windows.Forms.ComboBox cbx_searchRegionType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ListBox lstInfo;
        internal System.Windows.Forms.TextBox tbx_codeRule;
        private Sunny.UI.UITextBox HuiDuMax;
        private Sunny.UI.UITextBox AreaMax;
        private Sunny.UI.UITextBox AreaMin;
        private Sunny.UI.UITextBox HuiDuMin;
        private Sunny.UI.UIRadioButton RadQuYu;
        private Sunny.UI.UIRadioButton RadGenSuiQuYu;
        internal System.Windows.Forms.ComboBox cbx_charType;
    }
}