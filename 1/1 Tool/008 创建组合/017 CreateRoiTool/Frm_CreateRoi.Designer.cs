namespace VM_Pro
{
    partial class Frm_CreateRoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CreateRoi));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_LianRu = new System.Windows.Forms.Panel();
            this.ImgBtn_LianRu = new Sunny.UI.UIImageButton();
            this.txt_LianRu = new Sunny.UI.UITextBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.ckb_RegionResult = new Sunny.UI.UICheckBox();
            this.cbx_searchRegionType = new Sunny.UI.UIComboBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.MoBanPanel = new Sunny.UI.UIPanel();
            this.lb_CurrentMoBanAngle = new Sunny.UI.UILabel();
            this.lb_MoBanAngle = new Sunny.UI.UILabel();
            this.lb_CurrentMoBanPoint = new Sunny.UI.UILabel();
            this.lb_MoBanDian = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.btnJiSuan = new Sunny.UI.UIButton();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.Rdb_MoBan = new Sunny.UI.UIRadioButton();
            this.Rdb_GuDing = new Sunny.UI.UIRadioButton();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final2();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_close = new Sunny.UI.UIButton();
            this.btn_runTask = new Sunny.UI.UIButton();
            this.btn_runTool = new Sunny.UI.UIButton();
            this.ckb_taskFailKeepRun = new Sunny.UI.UICheckBox();
            this.lbl_toolTip = new Sunny.UI.UILabel();
            this.lbl_runTime = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLine1 = new Sunny.UI.UILine();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_LianRu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBtn_LianRu)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.MoBanPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 35);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1040, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(34, 25);
            this.toolStripButton1.Text = "保存";
            this.toolStripButton1.ToolTipText = "保存";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(34, 25);
            this.toolStripButton2.Text = "复位";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(34, 25);
            this.toolStripButton3.Text = "工具帮助";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.hWindow_Final1);
            this.panel1.Location = new System.Drawing.Point(3, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 490);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel_LianRu);
            this.panel2.Controls.Add(this.uiGroupBox1);
            this.panel2.Controls.Add(this.cbx_searchRegionType);
            this.panel2.Controls.Add(this.uiLabel2);
            this.panel2.Controls.Add(this.MoBanPanel);
            this.panel2.Controls.Add(this.Rdb_MoBan);
            this.panel2.Controls.Add(this.Rdb_GuDing);
            this.panel2.Location = new System.Drawing.Point(657, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 484);
            this.panel2.TabIndex = 1;
            // 
            // panel_LianRu
            // 
            this.panel_LianRu.Controls.Add(this.ImgBtn_LianRu);
            this.panel_LianRu.Controls.Add(this.txt_LianRu);
            this.panel_LianRu.Controls.Add(this.uiLabel8);
            this.panel_LianRu.Location = new System.Drawing.Point(10, 78);
            this.panel_LianRu.Name = "panel_LianRu";
            this.panel_LianRu.Size = new System.Drawing.Size(360, 51);
            this.panel_LianRu.TabIndex = 5;
            this.panel_LianRu.Visible = false;
            // 
            // ImgBtn_LianRu
            // 
            this.ImgBtn_LianRu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ImgBtn_LianRu.BackgroundImage")));
            this.ImgBtn_LianRu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ImgBtn_LianRu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImgBtn_LianRu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImgBtn_LianRu.Location = new System.Drawing.Point(294, 10);
            this.ImgBtn_LianRu.Name = "ImgBtn_LianRu";
            this.ImgBtn_LianRu.Size = new System.Drawing.Size(46, 36);
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
            this.txt_LianRu.Location = new System.Drawing.Point(83, 10);
            this.txt_LianRu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_LianRu.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_LianRu.Name = "txt_LianRu";
            this.txt_LianRu.ReadOnly = true;
            this.txt_LianRu.ShowText = false;
            this.txt_LianRu.Size = new System.Drawing.Size(204, 36);
            this.txt_LianRu.TabIndex = 1;
            this.txt_LianRu.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_LianRu.Watermark = "";
            this.txt_LianRu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(11, 17);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(65, 23);
            this.uiLabel8.TabIndex = 0;
            this.uiLabel8.Text = "特征点";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.ckb_RegionResult);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(7, 366);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(363, 113);
            this.uiGroupBox1.TabIndex = 4;
            this.uiGroupBox1.Text = "其他设置";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ckb_RegionResult
            // 
            this.ckb_RegionResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_RegionResult.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_RegionResult.Location = new System.Drawing.Point(10, 35);
            this.ckb_RegionResult.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_RegionResult.Name = "ckb_RegionResult";
            this.ckb_RegionResult.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_RegionResult.Size = new System.Drawing.Size(209, 29);
            this.ckb_RegionResult.TabIndex = 0;
            this.ckb_RegionResult.Text = "将结果区域显示到主窗体";
            this.ckb_RegionResult.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_RegionResult.Click += new System.EventHandler(this.ckb_RegionResult_Click);
            // 
            // cbx_searchRegionType
            // 
            this.cbx_searchRegionType.DataSource = null;
            this.cbx_searchRegionType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_searchRegionType.FillColor = System.Drawing.Color.White;
            this.cbx_searchRegionType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_searchRegionType.Items.AddRange(new object[] {
            "整幅图像",
            "矩形",
            "仿射矩形",
            "圆"});
            this.cbx_searchRegionType.Location = new System.Drawing.Point(91, 8);
            this.cbx_searchRegionType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_searchRegionType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_searchRegionType.Name = "cbx_searchRegionType";
            this.cbx_searchRegionType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_searchRegionType.Size = new System.Drawing.Size(150, 29);
            this.cbx_searchRegionType.TabIndex = 3;
            this.cbx_searchRegionType.Text = "整幅图像";
            this.cbx_searchRegionType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_searchRegionType.Watermark = "";
            this.cbx_searchRegionType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_searchRegionType.SelectedIndexChanged += new System.EventHandler(this.cbx_searchRegionType_SelectedIndexChanged);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(11, 11);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(87, 23);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "区域类型 :";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // MoBanPanel
            // 
            this.MoBanPanel.Controls.Add(this.lb_CurrentMoBanAngle);
            this.MoBanPanel.Controls.Add(this.lb_MoBanAngle);
            this.MoBanPanel.Controls.Add(this.lb_CurrentMoBanPoint);
            this.MoBanPanel.Controls.Add(this.lb_MoBanDian);
            this.MoBanPanel.Controls.Add(this.uiLabel7);
            this.MoBanPanel.Controls.Add(this.uiLabel5);
            this.MoBanPanel.Controls.Add(this.btnJiSuan);
            this.MoBanPanel.Controls.Add(this.uiLabel6);
            this.MoBanPanel.Controls.Add(this.uiLabel4);
            this.MoBanPanel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MoBanPanel.Location = new System.Drawing.Point(7, 137);
            this.MoBanPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MoBanPanel.MinimumSize = new System.Drawing.Size(1, 1);
            this.MoBanPanel.Name = "MoBanPanel";
            this.MoBanPanel.Size = new System.Drawing.Size(366, 219);
            this.MoBanPanel.TabIndex = 1;
            this.MoBanPanel.Text = null;
            this.MoBanPanel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.MoBanPanel.Visible = false;
            this.MoBanPanel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_CurrentMoBanAngle
            // 
            this.lb_CurrentMoBanAngle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_CurrentMoBanAngle.Location = new System.Drawing.Point(145, 183);
            this.lb_CurrentMoBanAngle.Name = "lb_CurrentMoBanAngle";
            this.lb_CurrentMoBanAngle.Size = new System.Drawing.Size(194, 24);
            this.lb_CurrentMoBanAngle.TabIndex = 1;
            this.lb_CurrentMoBanAngle.Text = "0";
            this.lb_CurrentMoBanAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_CurrentMoBanAngle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_MoBanAngle
            // 
            this.lb_MoBanAngle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_MoBanAngle.Location = new System.Drawing.Point(117, 49);
            this.lb_MoBanAngle.Name = "lb_MoBanAngle";
            this.lb_MoBanAngle.Size = new System.Drawing.Size(226, 24);
            this.lb_MoBanAngle.TabIndex = 1;
            this.lb_MoBanAngle.Text = "0";
            this.lb_MoBanAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_MoBanAngle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_CurrentMoBanPoint
            // 
            this.lb_CurrentMoBanPoint.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_CurrentMoBanPoint.Location = new System.Drawing.Point(147, 148);
            this.lb_CurrentMoBanPoint.Name = "lb_CurrentMoBanPoint";
            this.lb_CurrentMoBanPoint.Size = new System.Drawing.Size(209, 24);
            this.lb_CurrentMoBanPoint.TabIndex = 1;
            this.lb_CurrentMoBanPoint.Text = "0 ，0";
            this.lb_CurrentMoBanPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_CurrentMoBanPoint.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_MoBanDian
            // 
            this.lb_MoBanDian.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_MoBanDian.Location = new System.Drawing.Point(117, 13);
            this.lb_MoBanDian.Name = "lb_MoBanDian";
            this.lb_MoBanDian.Size = new System.Drawing.Size(226, 24);
            this.lb_MoBanDian.TabIndex = 1;
            this.lb_MoBanDian.Text = "0 ，0";
            this.lb_MoBanDian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_MoBanDian.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(6, 183);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(133, 23);
            this.uiLabel7.TabIndex = 0;
            this.uiLabel7.Text = "当前模板角度 :";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(10, 49);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(83, 23);
            this.uiLabel5.TabIndex = 0;
            this.uiLabel5.Text = "模板角度 :";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnJiSuan
            // 
            this.btnJiSuan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJiSuan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJiSuan.Location = new System.Drawing.Point(3, 76);
            this.btnJiSuan.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnJiSuan.Name = "btnJiSuan";
            this.btnJiSuan.Size = new System.Drawing.Size(360, 55);
            this.btnJiSuan.TabIndex = 1;
            this.btnJiSuan.Text = "生成跟随关系【更新模板输入点】";
            this.btnJiSuan.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJiSuan.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnJiSuan.Click += new System.EventHandler(this.btnJiSuan_Click);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(6, 148);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(135, 23);
            this.uiLabel6.TabIndex = 0;
            this.uiLabel6.Text = "当前模板特征点 :";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(10, 14);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(100, 23);
            this.uiLabel4.TabIndex = 0;
            this.uiLabel4.Text = "模板特征点 :";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Rdb_MoBan
            // 
            this.Rdb_MoBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rdb_MoBan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rdb_MoBan.Location = new System.Drawing.Point(128, 42);
            this.Rdb_MoBan.MinimumSize = new System.Drawing.Size(1, 1);
            this.Rdb_MoBan.Name = "Rdb_MoBan";
            this.Rdb_MoBan.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.Rdb_MoBan.Size = new System.Drawing.Size(146, 29);
            this.Rdb_MoBan.TabIndex = 0;
            this.Rdb_MoBan.Text = "跟随特征点区域";
            this.Rdb_MoBan.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Rdb_MoBan.Click += new System.EventHandler(this.Rdb_MoBan_Click);
            // 
            // Rdb_GuDing
            // 
            this.Rdb_GuDing.Checked = true;
            this.Rdb_GuDing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rdb_GuDing.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rdb_GuDing.Location = new System.Drawing.Point(8, 42);
            this.Rdb_GuDing.MinimumSize = new System.Drawing.Size(1, 1);
            this.Rdb_GuDing.Name = "Rdb_GuDing";
            this.Rdb_GuDing.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.Rdb_GuDing.Size = new System.Drawing.Size(96, 29);
            this.Rdb_GuDing.TabIndex = 0;
            this.Rdb_GuDing.Text = "固定区域";
            this.Rdb_GuDing.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Rdb_GuDing.Click += new System.EventHandler(this.Rdb_GuDing_Click);
            // 
            // hWindow_Final1
            // 
            this.hWindow_Final1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hWindow_Final1.DrawModel = false;
            this.hWindow_Final1.EditModel = true;
            this.hWindow_Final1.Image = null;
            this.hWindow_Final1.Location = new System.Drawing.Point(4, 0);
            this.hWindow_Final1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(646, 488);
            this.hWindow_Final1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_close);
            this.panel3.Controls.Add(this.btn_runTask);
            this.panel3.Controls.Add(this.btn_runTool);
            this.panel3.Controls.Add(this.ckb_taskFailKeepRun);
            this.panel3.Controls.Add(this.lbl_toolTip);
            this.panel3.Controls.Add(this.lbl_runTime);
            this.panel3.Controls.Add(this.uiLabel3);
            this.panel3.Controls.Add(this.uiLabel1);
            this.panel3.Location = new System.Drawing.Point(3, 562);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1034, 53);
            this.panel3.TabIndex = 2;
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.Location = new System.Drawing.Point(942, 13);
            this.btn_close.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 32);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "关闭";
            this.btn_close.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_runTask
            // 
            this.btn_runTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runTask.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTask.Location = new System.Drawing.Point(727, 13);
            this.btn_runTask.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_runTask.Name = "btn_runTask";
            this.btn_runTask.Size = new System.Drawing.Size(75, 32);
            this.btn_runTask.TabIndex = 2;
            this.btn_runTask.Text = "运行流程";
            this.btn_runTask.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTask.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_runTask.Click += new System.EventHandler(this.btn_runTask_Click);
            // 
            // btn_runTool
            // 
            this.btn_runTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runTool.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTool.Location = new System.Drawing.Point(601, 13);
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
            this.ckb_taskFailKeepRun.Location = new System.Drawing.Point(206, 4);
            this.ckb_taskFailKeepRun.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_taskFailKeepRun.Name = "ckb_taskFailKeepRun";
            this.ckb_taskFailKeepRun.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_taskFailKeepRun.Size = new System.Drawing.Size(150, 29);
            this.ckb_taskFailKeepRun.TabIndex = 1;
            this.ckb_taskFailKeepRun.Text = "流程失败仍运行";
            this.ckb_taskFailKeepRun.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_taskFailKeepRun.Click += new System.EventHandler(this.ckb_taskFailKeepRun_Click);
            // 
            // lbl_toolTip
            // 
            this.lbl_toolTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_toolTip.Location = new System.Drawing.Point(62, 27);
            this.lbl_toolTip.Name = "lbl_toolTip";
            this.lbl_toolTip.Size = new System.Drawing.Size(256, 23);
            this.lbl_toolTip.TabIndex = 0;
            this.lbl_toolTip.Text = "暂无提示";
            this.lbl_toolTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_toolTip.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_runTime
            // 
            this.lbl_runTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_runTime.Location = new System.Drawing.Point(62, 4);
            this.lbl_runTime.Name = "lbl_runTime";
            this.lbl_runTime.Size = new System.Drawing.Size(115, 23);
            this.lbl_runTime.TabIndex = 0;
            this.lbl_runTime.Text = "0 ms";
            this.lbl_runTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_runTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(3, 30);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(53, 23);
            this.uiLabel3.TabIndex = 0;
            this.uiLabel3.Text = "提示 :";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(3, 4);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(53, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "耗时 :";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.LineSize = 2;
            this.uiLine1.Location = new System.Drawing.Point(0, 559);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(1047, 10);
            this.uiLine1.TabIndex = 0;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Frm_CreateRoi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1040, 618);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_CreateRoi";
            this.ShowRadius = false;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.Text = "创建ROI";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_CreateRoi_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel_LianRu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgBtn_LianRu)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.MoBanPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel1;
        internal Sunny.UI.UILabel lbl_toolTip;
        internal Sunny.UI.UILabel lbl_runTime;
        internal Sunny.UI.UICheckBox ckb_taskFailKeepRun;
        private Sunny.UI.UIButton btn_close;
        private Sunny.UI.UIButton btn_runTask;
        private Sunny.UI.UIButton btn_runTool;
        private Sunny.UI.UIRadioButton Rdb_MoBan;
        private Sunny.UI.UIRadioButton Rdb_GuDing;
        private Sunny.UI.UIPanel MoBanPanel;
        internal ChoiceTech.Halcon.Control.HWindow_Final2 hWindow_Final1;
        private Sunny.UI.UILabel uiLabel2;
        internal Sunny.UI.UIComboBox cbx_searchRegionType;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIButton btnJiSuan;
        internal Sunny.UI.UILabel lb_MoBanAngle;
        internal Sunny.UI.UILabel lb_MoBanDian;
        internal Sunny.UI.UILabel lb_CurrentMoBanAngle;
        internal Sunny.UI.UILabel lb_CurrentMoBanPoint;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        internal Sunny.UI.UICheckBox ckb_RegionResult;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        internal System.Windows.Forms.Panel panel_LianRu;
        private Sunny.UI.UILabel uiLabel8;
        internal Sunny.UI.UITextBox txt_LianRu;
        internal Sunny.UI.UIImageButton ImgBtn_LianRu;
    }
}