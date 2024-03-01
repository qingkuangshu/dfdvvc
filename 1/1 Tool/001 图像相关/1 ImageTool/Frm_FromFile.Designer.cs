namespace VM_Pro
{
    partial class Frm_FromFile
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
            this.btn_loopGrab = new Sunny.UI.UIButton();
            this.tbx_imagePath = new System.Windows.Forms.TextBox();
            this.nud_rotateAngle = new Controls.CNumericUpDown();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.ckb_rotateImage = new Sunny.UI.UICheckBox();
            this.ckb_absPath = new Sunny.UI.UICheckBox();
            this.SuspendLayout();
            // 
            // btn_loopGrab
            // 
            this.btn_loopGrab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_loopGrab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_loopGrab.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_loopGrab.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_loopGrab.Location = new System.Drawing.Point(268, 88);
            this.btn_loopGrab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_loopGrab.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_loopGrab.Name = "btn_loopGrab";
            this.btn_loopGrab.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_loopGrab.Size = new System.Drawing.Size(80, 34);
            this.btn_loopGrab.Style = Sunny.UI.UIStyle.Custom;
            this.btn_loopGrab.TabIndex = 216;
            this.btn_loopGrab.Text = "选择图像";
            this.btn_loopGrab.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_loopGrab.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_loopGrab.Click += new System.EventHandler(this.btn_loopGrab_Click);
            // 
            // tbx_imagePath
            // 
            this.tbx_imagePath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_imagePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_imagePath.Location = new System.Drawing.Point(1, 9);
            this.tbx_imagePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_imagePath.Multiline = true;
            this.tbx_imagePath.Name = "tbx_imagePath";
            this.tbx_imagePath.Size = new System.Drawing.Size(345, 88);
            this.tbx_imagePath.TabIndex = 215;
            this.tbx_imagePath.TextChanged += new System.EventHandler(this.tbx_imagePath_TextChanged);
            this.tbx_imagePath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_imagePath_KeyUp);
            // 
            // nud_rotateAngle
            // 
            this.nud_rotateAngle.BackColor = System.Drawing.Color.White;
            this.nud_rotateAngle.DecimalPlaces = 0;
            this.nud_rotateAngle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_rotateAngle.Incremeent = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nud_rotateAngle.Location = new System.Drawing.Point(89, 353);
            this.nud_rotateAngle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_rotateAngle.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_rotateAngle.MaxValue = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nud_rotateAngle.MinimumSize = new System.Drawing.Size(50, 26);
            this.nud_rotateAngle.MinValue = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nud_rotateAngle.Name = "nud_rotateAngle";
            this.nud_rotateAngle.Size = new System.Drawing.Size(103, 26);
            this.nud_rotateAngle.TabIndex = 212;
            this.nud_rotateAngle.TabStop = false;
            this.nud_rotateAngle.Value = 0D;
            this.nud_rotateAngle.ValueChanged += new Controls.DValueChanged(this.nud_rotateAngle_ValueChanged);
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.White;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(199, 357);
            this.uiLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(33, 22);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 214;
            this.uiLabel2.Text = "度";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ckb_rotateImage
            // 
            this.ckb_rotateImage.Checked = true;
            this.ckb_rotateImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_rotateImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_rotateImage.Location = new System.Drawing.Point(1, 355);
            this.ckb_rotateImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_rotateImage.Name = "ckb_rotateImage";
            this.ckb_rotateImage.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_rotateImage.Size = new System.Drawing.Size(82, 24);
            this.ckb_rotateImage.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_rotateImage.TabIndex = 213;
            this.ckb_rotateImage.Text = "旋转图像";
            this.ckb_rotateImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_rotateImage.CheckedChanged += new System.EventHandler(this.ckb_rotateImage_CheckedChanged);
            // 
            // ckb_absPath
            // 
            this.ckb_absPath.Checked = true;
            this.ckb_absPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_absPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_absPath.Location = new System.Drawing.Point(1, 326);
            this.ckb_absPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_absPath.Name = "ckb_absPath";
            this.ckb_absPath.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_absPath.Size = new System.Drawing.Size(276, 24);
            this.ckb_absPath.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_absPath.TabIndex = 211;
            this.ckb_absPath.Text = "勾选：绝对路径 | 不勾选：相对路径";
            this.ckb_absPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_absPath.CheckedChanged += new System.EventHandler(this.ckb_absPath_CheckedChanged);
            // 
            // Frm_FromFile
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(348, 379);
            this.Controls.Add(this.btn_loopGrab);
            this.Controls.Add(this.tbx_imagePath);
            this.Controls.Add(this.nud_rotateAngle);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.ckb_rotateImage);
            this.Controls.Add(this.ckb_absPath);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_FromFile";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UIButton btn_loopGrab;
        internal System.Windows.Forms.TextBox tbx_imagePath;
        internal Controls.CNumericUpDown nud_rotateAngle;
        internal Sunny.UI.UILabel uiLabel2;
        internal Sunny.UI.UICheckBox ckb_rotateImage;
        internal Sunny.UI.UICheckBox ckb_absPath;
    }
}