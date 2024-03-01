namespace VM_Pro
{
    partial class Frm_FromCamera
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
            this.cbx_cameraList = new Sunny.UI.UIComboBox();
            this.nud_exposure = new Controls.CNumericUpDown();
            this.btn_saveImage = new Sunny.UI.UIButton();
            this.btn_grabLoop = new Sunny.UI.UIButton();
            this.label148 = new System.Windows.Forms.Label();
            this.label147 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.ckb_hardTrig = new Sunny.UI.UICheckBox();
            this.ckb_pieceImage = new Sunny.UI.UICheckBox();
            this.ckb_autoLight = new Sunny.UI.UICheckBox();
            this.cbx_lightList = new Sunny.UI.UIComboBox();
            this.SuspendLayout();
            // 
            // cbx_cameraList
            // 
            this.cbx_cameraList.DataSource = null;
            this.cbx_cameraList.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_cameraList.DropDownWidth = 152;
            this.cbx_cameraList.FillColor = System.Drawing.Color.White;
            this.cbx_cameraList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_cameraList.Location = new System.Drawing.Point(76, 11);
            this.cbx_cameraList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_cameraList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_cameraList.Name = "cbx_cameraList";
            this.cbx_cameraList.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_cameraList.Radius = 0;
            this.cbx_cameraList.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbx_cameraList.Size = new System.Drawing.Size(152, 28);
            this.cbx_cameraList.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_cameraList.TabIndex = 215;
            this.cbx_cameraList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_cameraList.Watermark = "";
            this.cbx_cameraList.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_cameraList.SelectedIndexChanged += new System.EventHandler(this.cbx_cameraList_SelectedIndexChanged);
            // 
            // nud_exposure
            // 
            this.nud_exposure.BackColor = System.Drawing.Color.White;
            this.nud_exposure.DecimalPlaces = 0;
            this.nud_exposure.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_exposure.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_exposure.Location = new System.Drawing.Point(74, 46);
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
            this.nud_exposure.Size = new System.Drawing.Size(127, 26);
            this.nud_exposure.TabIndex = 213;
            this.nud_exposure.TabStop = false;
            this.nud_exposure.Value = 1D;
            this.nud_exposure.ValueChanged += new Controls.DValueChanged(this.nud_exposure_ValueChanged);
            // 
            // btn_saveImage
            // 
            this.btn_saveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_saveImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_saveImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_saveImage.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_saveImage.Location = new System.Drawing.Point(91, 87);
            this.btn_saveImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_saveImage.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_saveImage.Name = "btn_saveImage";
            this.btn_saveImage.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_saveImage.Size = new System.Drawing.Size(80, 34);
            this.btn_saveImage.Style = Sunny.UI.UIStyle.Custom;
            this.btn_saveImage.TabIndex = 211;
            this.btn_saveImage.Text = "保存图像";
            this.btn_saveImage.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_saveImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_saveImage.Click += new System.EventHandler(this.btn_saveImage_Click);
            // 
            // btn_grabLoop
            // 
            this.btn_grabLoop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_grabLoop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_grabLoop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_grabLoop.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_grabLoop.Location = new System.Drawing.Point(6, 87);
            this.btn_grabLoop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_grabLoop.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_grabLoop.Name = "btn_grabLoop";
            this.btn_grabLoop.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_grabLoop.Size = new System.Drawing.Size(80, 34);
            this.btn_grabLoop.Style = Sunny.UI.UIStyle.Custom;
            this.btn_grabLoop.TabIndex = 209;
            this.btn_grabLoop.Text = "相机实时";
            this.btn_grabLoop.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_grabLoop.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_grabLoop.Click += new System.EventHandler(this.btn_grabLoop_Click);
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label148.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label148.Location = new System.Drawing.Point(202, 49);
            this.label148.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(40, 24);
            this.label148.TabIndex = 205;
            this.label148.Text = " ms";
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label147.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label147.Location = new System.Drawing.Point(0, 49);
            this.label147.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(100, 24);
            this.label147.TabIndex = 204;
            this.label147.Text = "曝光时间：";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label123.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label123.Location = new System.Drawing.Point(0, 13);
            this.label123.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(100, 24);
            this.label123.TabIndex = 206;
            this.label123.Text = "相机选择：";
            // 
            // ckb_hardTrig
            // 
            this.ckb_hardTrig.Checked = true;
            this.ckb_hardTrig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_hardTrig.Enabled = false;
            this.ckb_hardTrig.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_hardTrig.Location = new System.Drawing.Point(2, 355);
            this.ckb_hardTrig.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_hardTrig.Name = "ckb_hardTrig";
            this.ckb_hardTrig.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_hardTrig.Size = new System.Drawing.Size(334, 24);
            this.ckb_hardTrig.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_hardTrig.TabIndex = 216;
            this.ckb_hardTrig.Text = "勾选：硬触发 | 不勾选：软触发【跟随服务选择】";
            this.ckb_hardTrig.Visible = false;
            this.ckb_hardTrig.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_hardTrig.CheckedChanged += new System.EventHandler(this.ckb_hardTrig_CheckedChanged);
            // 
            // ckb_pieceImage
            // 
            this.ckb_pieceImage.Checked = true;
            this.ckb_pieceImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_pieceImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_pieceImage.Location = new System.Drawing.Point(2, 326);
            this.ckb_pieceImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_pieceImage.Name = "ckb_pieceImage";
            this.ckb_pieceImage.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_pieceImage.Size = new System.Drawing.Size(98, 24);
            this.ckb_pieceImage.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_pieceImage.TabIndex = 233;
            this.ckb_pieceImage.Text = "图像拼接";
            this.ckb_pieceImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_pieceImage.Click += new System.EventHandler(this.ckb_pieceImage_Click);
            // 
            // ckb_autoLight
            // 
            this.ckb_autoLight.Checked = true;
            this.ckb_autoLight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_autoLight.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_autoLight.Location = new System.Drawing.Point(2, 296);
            this.ckb_autoLight.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_autoLight.Name = "ckb_autoLight";
            this.ckb_autoLight.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_autoLight.Size = new System.Drawing.Size(98, 24);
            this.ckb_autoLight.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_autoLight.TabIndex = 234;
            this.ckb_autoLight.Text = "自动开灯";
            this.ckb_autoLight.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_autoLight.Click += new System.EventHandler(this.ckb_autoLight_Click);
            // 
            // cbx_lightList
            // 
            this.cbx_lightList.DataSource = null;
            this.cbx_lightList.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_lightList.DropDownWidth = 152;
            this.cbx_lightList.FillColor = System.Drawing.Color.White;
            this.cbx_lightList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_lightList.Location = new System.Drawing.Point(112, 294);
            this.cbx_lightList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_lightList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_lightList.Name = "cbx_lightList";
            this.cbx_lightList.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_lightList.Radius = 0;
            this.cbx_lightList.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbx_lightList.Size = new System.Drawing.Size(127, 28);
            this.cbx_lightList.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_lightList.TabIndex = 235;
            this.cbx_lightList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_lightList.Watermark = "";
            this.cbx_lightList.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_lightList.SelectedIndexChanged += new System.EventHandler(this.cbx_lightList_SelectedIndexChanged);
            // 
            // Frm_FromCamera
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(348, 379);
            this.Controls.Add(this.cbx_lightList);
            this.Controls.Add(this.ckb_autoLight);
            this.Controls.Add(this.ckb_pieceImage);
            this.Controls.Add(this.ckb_hardTrig);
            this.Controls.Add(this.cbx_cameraList);
            this.Controls.Add(this.nud_exposure);
            this.Controls.Add(this.btn_saveImage);
            this.Controls.Add(this.btn_grabLoop);
            this.Controls.Add(this.label148);
            this.Controls.Add(this.label147);
            this.Controls.Add(this.label123);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_FromCamera";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Sunny.UI.UIComboBox cbx_cameraList;
        private Sunny.UI.UIButton btn_saveImage;
        private System.Windows.Forms.Label label148;
        private System.Windows.Forms.Label label147;
        private System.Windows.Forms.Label label123;
        internal Sunny.UI.UICheckBox ckb_hardTrig;
        internal Controls.CNumericUpDown nud_exposure;
        internal Sunny.UI.UIButton btn_grabLoop;
        internal Sunny.UI.UICheckBox ckb_pieceImage;
        internal Sunny.UI.UICheckBox ckb_autoLight;
        internal Sunny.UI.UIComboBox cbx_lightList;
    }
}