namespace VM_Pro
{
    partial class Frm_Calibrate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Calibrate));
            this.btn_calibData = new Sunny.UI.UIButton();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final2();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.适应窗体toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.图像信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_calibType = new Sunny.UI.UIButton();
            this.tbx_log = new System.Windows.Forms.RichTextBox();
            this.btn_calibrate = new Sunny.UI.UIButton();
            this.btn_calibResult = new Sunny.UI.UIButton();
            this.btn_photoPos = new Sunny.UI.UIButton();
            this.btn_grabLoop = new Sunny.UI.UIButton();
            this.btn_template = new Sunny.UI.UIButton();
            this.btn_test = new Sunny.UI.UIButton();
            this.nud_exposure = new Controls.CNumericUpDown();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_calibData
            // 
            this.btn_calibData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_calibData.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_calibData.Location = new System.Drawing.Point(556, 97);
            this.btn_calibData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_calibData.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_calibData.Name = "btn_calibData";
            this.btn_calibData.Size = new System.Drawing.Size(95, 40);
            this.btn_calibData.Style = Sunny.UI.UIStyle.Custom;
            this.btn_calibData.TabIndex = 169;
            this.btn_calibData.Text = "标定数据";
            this.btn_calibData.Click += new System.EventHandler(this.btn_calibData_Click);
            // 
            // hWindow_Final1
            // 
            this.hWindow_Final1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final1.ContextMenuStrip = this.uiContextMenuStrip1;
            this.hWindow_Final1.DrawModel = false;
            this.hWindow_Final1.EditModel = true;
            this.hWindow_Final1.Image = null;
            this.hWindow_Final1.Location = new System.Drawing.Point(15, 9);
            this.hWindow_Final1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(536, 402);
            this.hWindow_Final1.TabIndex = 201;
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.AutoSize = false;
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.适应窗体toolStripMenuItem1,
            this.图像信息ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(150, 60);
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
            // btn_calibType
            // 
            this.btn_calibType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_calibType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_calibType.Location = new System.Drawing.Point(556, 9);
            this.btn_calibType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_calibType.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_calibType.Name = "btn_calibType";
            this.btn_calibType.Size = new System.Drawing.Size(95, 40);
            this.btn_calibType.Style = Sunny.UI.UIStyle.Custom;
            this.btn_calibType.TabIndex = 203;
            this.btn_calibType.Text = "场景设置";
            this.btn_calibType.Click += new System.EventHandler(this.btn_calibType_Click);
            // 
            // tbx_log
            // 
            this.tbx_log.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbx_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_log.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_log.DetectUrls = false;
            this.tbx_log.EnableAutoDragDrop = true;
            this.tbx_log.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_log.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbx_log.Location = new System.Drawing.Point(15, 417);
            this.tbx_log.Margin = new System.Windows.Forms.Padding(3, 60, 3, 3);
            this.tbx_log.Name = "tbx_log";
            this.tbx_log.ReadOnly = true;
            this.tbx_log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbx_log.Size = new System.Drawing.Size(636, 127);
            this.tbx_log.TabIndex = 210;
            this.tbx_log.TabStop = false;
            this.tbx_log.Text = "";
            // 
            // btn_calibrate
            // 
            this.btn_calibrate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_calibrate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_calibrate.Location = new System.Drawing.Point(556, 371);
            this.btn_calibrate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_calibrate.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_calibrate.Name = "btn_calibrate";
            this.btn_calibrate.Size = new System.Drawing.Size(95, 40);
            this.btn_calibrate.Style = Sunny.UI.UIStyle.Custom;
            this.btn_calibrate.TabIndex = 212;
            this.btn_calibrate.Text = "执行标定";
            this.btn_calibrate.Click += new System.EventHandler(this.btn_calibrate_Click);
            // 
            // btn_calibResult
            // 
            this.btn_calibResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_calibResult.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_calibResult.Location = new System.Drawing.Point(556, 141);
            this.btn_calibResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_calibResult.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_calibResult.Name = "btn_calibResult";
            this.btn_calibResult.Size = new System.Drawing.Size(95, 40);
            this.btn_calibResult.Style = Sunny.UI.UIStyle.Custom;
            this.btn_calibResult.TabIndex = 211;
            this.btn_calibResult.Text = "标定结果";
            this.btn_calibResult.Click += new System.EventHandler(this.btn_calibResult_Click);
            // 
            // btn_photoPos
            // 
            this.btn_photoPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_photoPos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_photoPos.Location = new System.Drawing.Point(556, 185);
            this.btn_photoPos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_photoPos.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_photoPos.Name = "btn_photoPos";
            this.btn_photoPos.Size = new System.Drawing.Size(95, 40);
            this.btn_photoPos.Style = Sunny.UI.UIStyle.Custom;
            this.btn_photoPos.TabIndex = 214;
            this.btn_photoPos.Text = "多拍照位";
            this.btn_photoPos.Click += new System.EventHandler(this.btn_photoPos_Click);
            // 
            // btn_grabLoop
            // 
            this.btn_grabLoop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_grabLoop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_grabLoop.Location = new System.Drawing.Point(556, 229);
            this.btn_grabLoop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_grabLoop.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_grabLoop.Name = "btn_grabLoop";
            this.btn_grabLoop.Size = new System.Drawing.Size(95, 40);
            this.btn_grabLoop.Style = Sunny.UI.UIStyle.Custom;
            this.btn_grabLoop.TabIndex = 215;
            this.btn_grabLoop.Text = "相机实时";
            this.btn_grabLoop.Click += new System.EventHandler(this.btn_grabLoop_Click);
            // 
            // btn_template
            // 
            this.btn_template.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_template.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_template.Location = new System.Drawing.Point(556, 53);
            this.btn_template.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_template.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_template.Name = "btn_template";
            this.btn_template.Size = new System.Drawing.Size(95, 40);
            this.btn_template.Style = Sunny.UI.UIStyle.Custom;
            this.btn_template.TabIndex = 216;
            this.btn_template.Text = "模板相关";
            this.btn_template.Click += new System.EventHandler(this.btn_template_Click);
            // 
            // btn_test
            // 
            this.btn_test.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_test.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_test.Location = new System.Drawing.Point(556, 327);
            this.btn_test.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_test.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(95, 40);
            this.btn_test.Style = Sunny.UI.UIStyle.Custom;
            this.btn_test.TabIndex = 217;
            this.btn_test.Text = "识别测试";
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // nud_exposure
            // 
            this.nud_exposure.BackColor = System.Drawing.Color.White;
            this.nud_exposure.DecimalPlaces = 1;
            this.nud_exposure.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_exposure.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_exposure.Location = new System.Drawing.Point(556, 275);
            this.nud_exposure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_exposure.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_exposure.MaxValue = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nud_exposure.MinimumSize = new System.Drawing.Size(50, 26);
            this.nud_exposure.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_exposure.Name = "nud_exposure";
            this.nud_exposure.Size = new System.Drawing.Size(95, 26);
            this.nud_exposure.TabIndex = 218;
            this.nud_exposure.TabStop = false;
            this.nud_exposure.Value = 1D;
            this.nud_exposure.ValueChanged += new Controls.DValueChanged(this.nud_exposure_ValueChanged);
            // 
            // Frm_Calibrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(656, 549);
            this.Controls.Add(this.nud_exposure);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.btn_template);
            this.Controls.Add(this.btn_grabLoop);
            this.Controls.Add(this.btn_photoPos);
            this.Controls.Add(this.btn_calibrate);
            this.Controls.Add(this.btn_calibResult);
            this.Controls.Add(this.tbx_log);
            this.Controls.Add(this.btn_calibType);
            this.Controls.Add(this.hWindow_Final1);
            this.Controls.Add(this.btn_calibData);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_Calibrate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Frm_Project";
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Sunny.UI.UIButton btn_calibData;
        internal Sunny.UI.UIButton btn_calibType;
        internal Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 适应窗体toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 图像信息ToolStripMenuItem;
        internal ChoiceTech.Halcon.Control.HWindow_Final2 hWindow_Final1;
        internal System.Windows.Forms.RichTextBox tbx_log;
        internal Sunny.UI.UIButton btn_calibrate;
        internal Sunny.UI.UIButton btn_calibResult;
        internal Sunny.UI.UIButton btn_photoPos;
        internal Sunny.UI.UIButton btn_grabLoop;
        internal Sunny.UI.UIButton btn_template;
        internal Sunny.UI.UIButton btn_test;
        internal Controls.CNumericUpDown nud_exposure;

    }
}