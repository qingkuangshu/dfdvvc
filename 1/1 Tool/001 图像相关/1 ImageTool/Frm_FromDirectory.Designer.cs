namespace VM_Pro
{
    partial class Frm_FromDirectory
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
            this.btn_browseImage = new Sunny.UI.UIButton();
            this.btn_retureToFirst = new Sunny.UI.UIButton();
            this.btn_lastOne = new Sunny.UI.UIButton();
            this.btn_selectDirectory = new Sunny.UI.UIButton();
            this.btn_removeCurrent = new Sunny.UI.UIButton();
            this.btn_nextOne = new Sunny.UI.UIButton();
            this.tbx_imageDirectoryPath = new System.Windows.Forms.TextBox();
            this.nud_rotateAngle = new Controls.CNumericUpDown();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.ckb_rotateImage = new Sunny.UI.UICheckBox();
            this.ckb_absPath = new Sunny.UI.UICheckBox();
            this.SuspendLayout();
            // 
            // btn_browseImage
            // 
            this.btn_browseImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_browseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_browseImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_browseImage.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_browseImage.Location = new System.Drawing.Point(7, 184);
            this.btn_browseImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_browseImage.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_browseImage.Name = "btn_browseImage";
            this.btn_browseImage.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_browseImage.Size = new System.Drawing.Size(80, 34);
            this.btn_browseImage.Style = Sunny.UI.UIStyle.Custom;
            this.btn_browseImage.TabIndex = 227;
            this.btn_browseImage.Text = "查看图像";
            this.btn_browseImage.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_browseImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_browseImage.Click += new System.EventHandler(this.btn_browseImage_Click);
            // 
            // btn_retureToFirst
            // 
            this.btn_retureToFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_retureToFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_retureToFirst.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_retureToFirst.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_retureToFirst.Location = new System.Drawing.Point(7, 145);
            this.btn_retureToFirst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_retureToFirst.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_retureToFirst.Name = "btn_retureToFirst";
            this.btn_retureToFirst.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_retureToFirst.Size = new System.Drawing.Size(80, 34);
            this.btn_retureToFirst.Style = Sunny.UI.UIStyle.Custom;
            this.btn_retureToFirst.TabIndex = 226;
            this.btn_retureToFirst.Text = "回到首张";
            this.btn_retureToFirst.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_retureToFirst.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_retureToFirst.Click += new System.EventHandler(this.btn_retureToFirst_Click);
            // 
            // btn_lastOne
            // 
            this.btn_lastOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_lastOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_lastOne.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_lastOne.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_lastOne.Location = new System.Drawing.Point(7, 106);
            this.btn_lastOne.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_lastOne.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_lastOne.Name = "btn_lastOne";
            this.btn_lastOne.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_lastOne.Size = new System.Drawing.Size(80, 34);
            this.btn_lastOne.Style = Sunny.UI.UIStyle.Custom;
            this.btn_lastOne.TabIndex = 225;
            this.btn_lastOne.Text = "上一张";
            this.btn_lastOne.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_lastOne.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_lastOne.Click += new System.EventHandler(this.btn_lastOne_Click);
            // 
            // btn_selectDirectory
            // 
            this.btn_selectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selectDirectory.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_selectDirectory.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_selectDirectory.Location = new System.Drawing.Point(255, 106);
            this.btn_selectDirectory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_selectDirectory.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_selectDirectory.Name = "btn_selectDirectory";
            this.btn_selectDirectory.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_selectDirectory.Size = new System.Drawing.Size(80, 34);
            this.btn_selectDirectory.Style = Sunny.UI.UIStyle.Custom;
            this.btn_selectDirectory.TabIndex = 224;
            this.btn_selectDirectory.Text = "选择路径";
            this.btn_selectDirectory.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_selectDirectory.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_selectDirectory.Click += new System.EventHandler(this.btn_selectDirectory_Click);
            // 
            // btn_removeCurrent
            // 
            this.btn_removeCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_removeCurrent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_removeCurrent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_removeCurrent.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_removeCurrent.Location = new System.Drawing.Point(92, 145);
            this.btn_removeCurrent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_removeCurrent.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_removeCurrent.Name = "btn_removeCurrent";
            this.btn_removeCurrent.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_removeCurrent.Size = new System.Drawing.Size(80, 34);
            this.btn_removeCurrent.Style = Sunny.UI.UIStyle.Custom;
            this.btn_removeCurrent.TabIndex = 223;
            this.btn_removeCurrent.Text = "移除当前";
            this.btn_removeCurrent.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_removeCurrent.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_removeCurrent.Click += new System.EventHandler(this.btn_removeCurrent_Click);
            // 
            // btn_nextOne
            // 
            this.btn_nextOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_nextOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_nextOne.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_nextOne.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_nextOne.Location = new System.Drawing.Point(92, 106);
            this.btn_nextOne.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_nextOne.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_nextOne.Name = "btn_nextOne";
            this.btn_nextOne.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_nextOne.Size = new System.Drawing.Size(80, 34);
            this.btn_nextOne.Style = Sunny.UI.UIStyle.Custom;
            this.btn_nextOne.TabIndex = 222;
            this.btn_nextOne.Text = "下一张";
            this.btn_nextOne.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_nextOne.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_nextOne.Click += new System.EventHandler(this.btn_nextOne_Click);
            // 
            // tbx_imageDirectoryPath
            // 
            this.tbx_imageDirectoryPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_imageDirectoryPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_imageDirectoryPath.Location = new System.Drawing.Point(1, 9);
            this.tbx_imageDirectoryPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_imageDirectoryPath.Multiline = true;
            this.tbx_imageDirectoryPath.Name = "tbx_imageDirectoryPath";
            this.tbx_imageDirectoryPath.Size = new System.Drawing.Size(345, 88);
            this.tbx_imageDirectoryPath.TabIndex = 221;
            this.tbx_imageDirectoryPath.TabStop = false;
            this.tbx_imageDirectoryPath.TextChanged += new System.EventHandler(this.tbx_imageDirectoryPath_TextChanged);
            this.tbx_imageDirectoryPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_imageDirectoryPath_KeyUp);
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
            this.nud_rotateAngle.Location = new System.Drawing.Point(90, 352);
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
            this.nud_rotateAngle.TabIndex = 218;
            this.nud_rotateAngle.TabStop = false;
            this.nud_rotateAngle.Value = 0D;
            this.nud_rotateAngle.ValueChanged += new Controls.DValueChanged(this.nud_rotateAngle_ValueChanged);
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.White;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(200, 356);
            this.uiLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(33, 22);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 220;
            this.uiLabel2.Text = "度";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ckb_rotateImage
            // 
            this.ckb_rotateImage.Checked = true;
            this.ckb_rotateImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_rotateImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_rotateImage.Location = new System.Drawing.Point(2, 354);
            this.ckb_rotateImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_rotateImage.Name = "ckb_rotateImage";
            this.ckb_rotateImage.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_rotateImage.Size = new System.Drawing.Size(82, 24);
            this.ckb_rotateImage.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_rotateImage.TabIndex = 219;
            this.ckb_rotateImage.Text = "旋转图像";
            this.ckb_rotateImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_rotateImage.CheckedChanged += new System.EventHandler(this.ckb_rotateImage_CheckedChanged);
            // 
            // ckb_absPath
            // 
            this.ckb_absPath.Checked = true;
            this.ckb_absPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_absPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_absPath.Location = new System.Drawing.Point(2, 325);
            this.ckb_absPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_absPath.Name = "ckb_absPath";
            this.ckb_absPath.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_absPath.Size = new System.Drawing.Size(276, 24);
            this.ckb_absPath.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_absPath.TabIndex = 217;
            this.ckb_absPath.Text = "勾选：绝对路径 | 不勾选：相对路径";
            this.ckb_absPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_absPath.CheckedChanged += new System.EventHandler(this.ckb_absPath_CheckedChanged);
            // 
            // Frm_FromDirectory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(348, 379);
            this.Controls.Add(this.btn_browseImage);
            this.Controls.Add(this.btn_retureToFirst);
            this.Controls.Add(this.btn_lastOne);
            this.Controls.Add(this.btn_selectDirectory);
            this.Controls.Add(this.btn_removeCurrent);
            this.Controls.Add(this.btn_nextOne);
            this.Controls.Add(this.tbx_imageDirectoryPath);
            this.Controls.Add(this.nud_rotateAngle);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.ckb_rotateImage);
            this.Controls.Add(this.ckb_absPath);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_FromDirectory";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UIButton btn_browseImage;
        private Sunny.UI.UIButton btn_retureToFirst;
        private Sunny.UI.UIButton btn_lastOne;
        private Sunny.UI.UIButton btn_selectDirectory;
        private Sunny.UI.UIButton btn_removeCurrent;
        private Sunny.UI.UIButton btn_nextOne;
        internal System.Windows.Forms.TextBox tbx_imageDirectoryPath;
        internal Controls.CNumericUpDown nud_rotateAngle;
        internal Sunny.UI.UILabel uiLabel2;
        internal Sunny.UI.UICheckBox ckb_rotateImage;
        internal Sunny.UI.UICheckBox ckb_absPath;
    }
}