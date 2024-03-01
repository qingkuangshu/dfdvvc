namespace VM_Pro
{
    partial class Frm_DefineTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DefineTool));
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiLine1 = new Sunny.UI.UILine();
            this.btn_close = new Sunny.UI.UIButton();
            this.btn_runTask = new Sunny.UI.UIButton();
            this.btn_runTool = new Sunny.UI.UIButton();
            this.ckb_taskFailKeepRun = new Sunny.UI.UICheckBox();
            this.lbl_toolTip = new Sunny.UI.UILabel();
            this.lbl_runTime = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.ckb_JiEr = new Sunny.UI.UICheckBox();
            this.txt_MinArea = new Sunny.UI.UITextBox();
            this.txt_BeforArea = new Sunny.UI.UITextBox();
            this.txt_MaxArea = new Sunny.UI.UITextBox();
            this.txt_NGNum = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(314, 221);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(355, 41);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "该工具为不同项目逻辑自定义开发工具";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiLine1);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_runTask);
            this.panel1.Controls.Add(this.btn_runTool);
            this.panel1.Controls.Add(this.ckb_taskFailKeepRun);
            this.panel1.Controls.Add(this.lbl_toolTip);
            this.panel1.Controls.Add(this.lbl_runTime);
            this.panel1.Controls.Add(this.uiLabel4);
            this.panel1.Controls.Add(this.uiLabel2);
            this.panel1.Location = new System.Drawing.Point(2, 556);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 62);
            this.panel1.TabIndex = 1;
            // 
            // uiLine1
            // 
            this.uiLine1.FillColor = System.Drawing.Color.White;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(0, 0);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(1062, 10);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 3;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_close
            // 
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.Location = new System.Drawing.Point(944, 14);
            this.btn_close.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 32);
            this.btn_close.Style = Sunny.UI.UIStyle.Custom;
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
            this.btn_runTask.Location = new System.Drawing.Point(784, 14);
            this.btn_runTask.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_runTask.Name = "btn_runTask";
            this.btn_runTask.Size = new System.Drawing.Size(75, 32);
            this.btn_runTask.Style = Sunny.UI.UIStyle.Custom;
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
            this.btn_runTool.Location = new System.Drawing.Point(689, 14);
            this.btn_runTool.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_runTool.Name = "btn_runTool";
            this.btn_runTool.Size = new System.Drawing.Size(75, 32);
            this.btn_runTool.Style = Sunny.UI.UIStyle.Custom;
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
            this.ckb_taskFailKeepRun.Location = new System.Drawing.Point(181, 7);
            this.ckb_taskFailKeepRun.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_taskFailKeepRun.Name = "ckb_taskFailKeepRun";
            this.ckb_taskFailKeepRun.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_taskFailKeepRun.Size = new System.Drawing.Size(150, 29);
            this.ckb_taskFailKeepRun.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_taskFailKeepRun.TabIndex = 1;
            this.ckb_taskFailKeepRun.Text = "流程失败仍运行";
            this.ckb_taskFailKeepRun.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_taskFailKeepRun.Click += new System.EventHandler(this.ckb_taskFailKeepRun_Click);
            // 
            // lbl_toolTip
            // 
            this.lbl_toolTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_toolTip.Location = new System.Drawing.Point(61, 35);
            this.lbl_toolTip.Name = "lbl_toolTip";
            this.lbl_toolTip.Size = new System.Drawing.Size(250, 23);
            this.lbl_toolTip.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_toolTip.TabIndex = 0;
            this.lbl_toolTip.Text = "暂无提示";
            this.lbl_toolTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_toolTip.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_runTime
            // 
            this.lbl_runTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_runTime.Location = new System.Drawing.Point(61, 7);
            this.lbl_runTime.Name = "lbl_runTime";
            this.lbl_runTime.Size = new System.Drawing.Size(114, 23);
            this.lbl_runTime.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_runTime.TabIndex = 0;
            this.lbl_runTime.Text = "0 ms";
            this.lbl_runTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_runTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(3, 35);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(52, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 0;
            this.uiLabel4.Text = "提示 :";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(3, 7);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(52, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 0;
            this.uiLabel2.Text = "耗时 :";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ckb_JiEr
            // 
            this.ckb_JiEr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_JiEr.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_JiEr.Location = new System.Drawing.Point(68, 150);
            this.ckb_JiEr.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_JiEr.Name = "ckb_JiEr";
            this.ckb_JiEr.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_JiEr.Size = new System.Drawing.Size(98, 29);
            this.ckb_JiEr.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_JiEr.TabIndex = 2;
            this.ckb_JiEr.Text = "极耳判定";
            this.ckb_JiEr.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_JiEr.Click += new System.EventHandler(this.ckb_JiEr_Click);
            // 
            // txt_MinArea
            // 
            this.txt_MinArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MinArea.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MinArea.Location = new System.Drawing.Point(198, 149);
            this.txt_MinArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_MinArea.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_MinArea.Name = "txt_MinArea";
            this.txt_MinArea.ShowText = false;
            this.txt_MinArea.Size = new System.Drawing.Size(150, 29);
            this.txt_MinArea.Style = Sunny.UI.UIStyle.Custom;
            this.txt_MinArea.TabIndex = 3;
            this.txt_MinArea.Text = "0.00";
            this.txt_MinArea.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_MinArea.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txt_MinArea.Watermark = "";
            this.txt_MinArea.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_MinArea.TextChanged += new System.EventHandler(this.txt_MinArea_TextChanged);
            // 
            // txt_BeforArea
            // 
            this.txt_BeforArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_BeforArea.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_BeforArea.Location = new System.Drawing.Point(366, 150);
            this.txt_BeforArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_BeforArea.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_BeforArea.Name = "txt_BeforArea";
            this.txt_BeforArea.ReadOnly = true;
            this.txt_BeforArea.ShowText = false;
            this.txt_BeforArea.Size = new System.Drawing.Size(150, 29);
            this.txt_BeforArea.Style = Sunny.UI.UIStyle.Custom;
            this.txt_BeforArea.TabIndex = 3;
            this.txt_BeforArea.Text = "0.00";
            this.txt_BeforArea.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_BeforArea.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txt_BeforArea.Watermark = "";
            this.txt_BeforArea.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_MaxArea
            // 
            this.txt_MaxArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MaxArea.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MaxArea.Location = new System.Drawing.Point(543, 150);
            this.txt_MaxArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_MaxArea.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_MaxArea.Name = "txt_MaxArea";
            this.txt_MaxArea.ShowText = false;
            this.txt_MaxArea.Size = new System.Drawing.Size(150, 29);
            this.txt_MaxArea.Style = Sunny.UI.UIStyle.Custom;
            this.txt_MaxArea.TabIndex = 3;
            this.txt_MaxArea.Text = "0.00";
            this.txt_MaxArea.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_MaxArea.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txt_MaxArea.Watermark = "";
            this.txt_MaxArea.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_MaxArea.TextChanged += new System.EventHandler(this.txt_MaxArea_TextChanged);
            // 
            // txt_NGNum
            // 
            this.txt_NGNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_NGNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_NGNum.Location = new System.Drawing.Point(725, 150);
            this.txt_NGNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_NGNum.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_NGNum.Name = "txt_NGNum";
            this.txt_NGNum.ReadOnly = true;
            this.txt_NGNum.ShowText = false;
            this.txt_NGNum.Size = new System.Drawing.Size(150, 29);
            this.txt_NGNum.Style = Sunny.UI.UIStyle.Custom;
            this.txt_NGNum.TabIndex = 3;
            this.txt_NGNum.Text = "0";
            this.txt_NGNum.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_NGNum.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_NGNum.Watermark = "";
            this.txt_NGNum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(233, 122);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "最小面积";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(396, 122);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(100, 23);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 4;
            this.uiLabel5.Text = "当前面积";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(561, 122);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(100, 23);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 4;
            this.uiLabel6.Text = "uiLabel3";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(561, 122);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(100, 23);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 4;
            this.uiLabel7.Text = "最大面积";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(741, 122);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(100, 23);
            this.uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel8.TabIndex = 4;
            this.uiLabel8.Text = "NG数";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 31);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1040, 31);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
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
            // Frm_DefineTool
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 618);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.uiLabel8);
            this.Controls.Add(this.uiLabel7);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.txt_NGNum);
            this.Controls.Add(this.txt_MaxArea);
            this.Controls.Add(this.txt_BeforArea);
            this.Controls.Add(this.txt_MinArea);
            this.Controls.Add(this.ckb_JiEr);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uiLabel1);
            this.ExtendBox = true;
            this.ExtendSymbol = 61758;
            this.ExtendSymbolOffset = new System.Drawing.Point(0, 2);
            this.ExtendSymbolSize = 18;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_DefineTool";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowRadius = false;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "自定义逻辑开发工具";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_DefineTool_FormClosing);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UILabel lbl_toolTip;
        private Sunny.UI.UILabel lbl_runTime;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UICheckBox ckb_taskFailKeepRun;
        private Sunny.UI.UIButton btn_runTool;
        private Sunny.UI.UIButton btn_close;
        private Sunny.UI.UIButton btn_runTask;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UICheckBox ckb_JiEr;
        private Sunny.UI.UITextBox txt_MinArea;
        private Sunny.UI.UITextBox txt_BeforArea;
        private Sunny.UI.UITextBox txt_MaxArea;
        private Sunny.UI.UITextBox txt_NGNum;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel8;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}