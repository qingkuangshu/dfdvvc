namespace VM_Pro
{
    partial class Frm_Camera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Camera));
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.btn_grabOne = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final2();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.适应窗体toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.图像信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbx_cameraList = new Sunny.UI.UIComboBox();
            this.btn_grabLoop = new Sunny.UI.UIButton();
            this.btn_focus = new Sunny.UI.UIButton();
            this.btn_saveImage = new Sunny.UI.UIButton();
            this.btn_movePar = new Sunny.UI.UIButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.lbl_elapsedTime = new Sunny.UI.UILabel();
            this.lbl_curValue = new System.Windows.Forms.Label();
            this.lbl_maxValue = new System.Windows.Forms.Label();
            this.nud_exposure = new Controls.CNumericUpDown();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(2, 4);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(75, 28);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 166;
            this.uiLabel2.Text = "相机：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_grabOne
            // 
            this.btn_grabOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_grabOne.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_grabOne.Location = new System.Drawing.Point(580, 516);
            this.btn_grabOne.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_grabOne.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_grabOne.Name = "btn_grabOne";
            this.btn_grabOne.Size = new System.Drawing.Size(70, 30);
            this.btn_grabOne.Style = Sunny.UI.UIStyle.Custom;
            this.btn_grabOne.TabIndex = 169;
            this.btn_grabOne.Text = "采集一张";
            this.btn_grabOne.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_grabOne.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_grabOne.Click += new System.EventHandler(this.btn_grabOne_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel5.AutoSize = true;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(416, 5);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(107, 28);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 199;
            this.uiLabel5.Text = "曝光时间 :";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiLabel5.Click += new System.EventHandler(this.uiLabel5_Click);
            // 
            // hWindow_Final1
            // 
            this.hWindow_Final1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hWindow_Final1.ContextMenuStrip = this.uiContextMenuStrip1;
            this.hWindow_Final1.DrawModel = false;
            this.hWindow_Final1.EditModel = true;
            this.hWindow_Final1.Image = null;
            this.hWindow_Final1.Location = new System.Drawing.Point(15, 33);
            this.hWindow_Final1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(635, 476);
            this.hWindow_Final1.TabIndex = 201;
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
            // cbx_cameraList
            // 
            this.cbx_cameraList.DataSource = null;
            this.cbx_cameraList.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_cameraList.DropDownWidth = 380;
            this.cbx_cameraList.FillColor = System.Drawing.Color.White;
            this.cbx_cameraList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_cameraList.ItemHeight = 23;
            this.cbx_cameraList.Location = new System.Drawing.Point(51, 5);
            this.cbx_cameraList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_cameraList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_cameraList.Name = "cbx_cameraList";
            this.cbx_cameraList.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_cameraList.Radius = 0;
            this.cbx_cameraList.Size = new System.Drawing.Size(362, 26);
            this.cbx_cameraList.TabIndex = 202;
            this.cbx_cameraList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_cameraList.Watermark = "";
            this.cbx_cameraList.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_cameraList.SelectedIndexChanged += new System.EventHandler(this.cbx_cameraList_SelectedIndexChanged);
            // 
            // btn_grabLoop
            // 
            this.btn_grabLoop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_grabLoop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_grabLoop.Location = new System.Drawing.Point(507, 516);
            this.btn_grabLoop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_grabLoop.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_grabLoop.Name = "btn_grabLoop";
            this.btn_grabLoop.Size = new System.Drawing.Size(70, 30);
            this.btn_grabLoop.Style = Sunny.UI.UIStyle.Custom;
            this.btn_grabLoop.TabIndex = 203;
            this.btn_grabLoop.Text = "实时显示";
            this.btn_grabLoop.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_grabLoop.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_grabLoop.Click += new System.EventHandler(this.btn_grabLoop_Click);
            // 
            // btn_focus
            // 
            this.btn_focus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_focus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_focus.Location = new System.Drawing.Point(247, 516);
            this.btn_focus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_focus.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_focus.Name = "btn_focus";
            this.btn_focus.Size = new System.Drawing.Size(70, 30);
            this.btn_focus.Style = Sunny.UI.UIStyle.Custom;
            this.btn_focus.TabIndex = 204;
            this.btn_focus.Text = "对焦";
            this.btn_focus.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_focus.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_focus.Click += new System.EventHandler(this.btn_focus_Click);
            // 
            // btn_saveImage
            // 
            this.btn_saveImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_saveImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_saveImage.Location = new System.Drawing.Point(320, 516);
            this.btn_saveImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_saveImage.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_saveImage.Name = "btn_saveImage";
            this.btn_saveImage.Size = new System.Drawing.Size(70, 30);
            this.btn_saveImage.Style = Sunny.UI.UIStyle.Custom;
            this.btn_saveImage.TabIndex = 205;
            this.btn_saveImage.Text = "保存图像";
            this.btn_saveImage.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_saveImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_saveImage.Click += new System.EventHandler(this.btn_saveImage_Click);
            // 
            // btn_movePar
            // 
            this.btn_movePar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_movePar.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_movePar.Location = new System.Drawing.Point(393, 516);
            this.btn_movePar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_movePar.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_movePar.Name = "btn_movePar";
            this.btn_movePar.Size = new System.Drawing.Size(70, 30);
            this.btn_movePar.Style = Sunny.UI.UIStyle.Custom;
            this.btn_movePar.TabIndex = 206;
            this.btn_movePar.Text = "更多参数";
            this.btn_movePar.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_movePar.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_movePar.Click += new System.EventHandler(this.btn_movePar_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(11, 514);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(65, 28);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 208;
            this.uiLabel3.Text = "耗时 :";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_elapsedTime
            // 
            this.lbl_elapsedTime.AutoSize = true;
            this.lbl_elapsedTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_elapsedTime.Location = new System.Drawing.Point(54, 514);
            this.lbl_elapsedTime.Name = "lbl_elapsedTime";
            this.lbl_elapsedTime.Size = new System.Drawing.Size(60, 28);
            this.lbl_elapsedTime.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_elapsedTime.TabIndex = 209;
            this.lbl_elapsedTime.Text = "0 ms";
            this.lbl_elapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_elapsedTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_curValue
            // 
            this.lbl_curValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_curValue.Location = new System.Drawing.Point(17, 35);
            this.lbl_curValue.Name = "lbl_curValue";
            this.lbl_curValue.Size = new System.Drawing.Size(82, 20);
            this.lbl_curValue.TabIndex = 212;
            this.lbl_curValue.Text = "当前：0";
            this.lbl_curValue.Visible = false;
            // 
            // lbl_maxValue
            // 
            this.lbl_maxValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_maxValue.Location = new System.Drawing.Point(17, 55);
            this.lbl_maxValue.Name = "lbl_maxValue";
            this.lbl_maxValue.Size = new System.Drawing.Size(82, 20);
            this.lbl_maxValue.TabIndex = 213;
            this.lbl_maxValue.Text = "峰值：0";
            this.lbl_maxValue.Visible = false;
            // 
            // nud_exposure
            // 
            this.nud_exposure.BackColor = System.Drawing.Color.White;
            this.nud_exposure.DecimalPlaces = 1;
            this.nud_exposure.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_exposure.Incremeent = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nud_exposure.Location = new System.Drawing.Point(506, 3);
            this.nud_exposure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_exposure.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_exposure.MaxValue = new decimal(new int[] {
            500000,
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
            this.nud_exposure.Size = new System.Drawing.Size(112, 26);
            this.nud_exposure.TabIndex = 214;
            this.nud_exposure.TabStop = false;
            this.nud_exposure.Value = 1D;
            this.nud_exposure.ValueChanged += new Controls.DValueChanged(this.nud_exposure_ValueChanged);
            this.nud_exposure.Load += new System.EventHandler(this.nud_exposure_Load);
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.White;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(627, 6);
            this.uiLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(33, 22);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 215;
            this.uiLabel4.Text = "us";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Frm_Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(656, 549);
            this.Controls.Add(this.nud_exposure);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.lbl_maxValue);
            this.Controls.Add(this.lbl_curValue);
            this.Controls.Add(this.lbl_elapsedTime);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.btn_movePar);
            this.Controls.Add(this.btn_saveImage);
            this.Controls.Add(this.btn_focus);
            this.Controls.Add(this.btn_grabLoop);
            this.Controls.Add(this.cbx_cameraList);
            this.Controls.Add(this.hWindow_Final1);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.btn_grabOne);
            this.Controls.Add(this.uiLabel2);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_Camera";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Frm_Project";
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel uiLabel2;
        internal Sunny.UI.UIButton btn_grabOne;
        private Sunny.UI.UILabel uiLabel5;
        internal Sunny.UI.UIButton btn_grabLoop;
        internal Sunny.UI.UIButton btn_focus;
        internal Sunny.UI.UIButton btn_saveImage;
        internal Sunny.UI.UIButton btn_movePar;
        private Sunny.UI.UILabel uiLabel3;
        internal Sunny.UI.UIComboBox cbx_cameraList;
        internal Sunny.UI.UILabel lbl_elapsedTime;
        internal Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 适应窗体toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 图像信息ToolStripMenuItem;
        internal ChoiceTech.Halcon.Control.HWindow_Final2 hWindow_Final1;
        internal System.Windows.Forms.Label lbl_curValue;
        internal System.Windows.Forms.Label lbl_maxValue;
        internal Controls.CNumericUpDown nud_exposure;
        internal Sunny.UI.UILabel uiLabel4;

    }
}