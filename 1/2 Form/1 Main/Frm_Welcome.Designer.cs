namespace VM_Pro
{
    partial class Frm_Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Welcome));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_step = new System.Windows.Forms.Label();
            this.lbl_version = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lbl_companyName = new System.Windows.Forms.Label();
            this.bar_step = new Sunny.UI.UIProcessBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(518, 237);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_step
            // 
            this.lbl_step.BackColor = System.Drawing.Color.Transparent;
            this.lbl_step.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_step.ForeColor = System.Drawing.Color.White;
            this.lbl_step.Location = new System.Drawing.Point(26, 311);
            this.lbl_step.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_step.Name = "lbl_step";
            this.lbl_step.Size = new System.Drawing.Size(578, 24);
            this.lbl_step.TabIndex = 7;
            this.lbl_step.Text = "正在初始化......";
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.BackColor = System.Drawing.Color.Transparent;
            this.lbl_version.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_version.ForeColor = System.Drawing.Color.White;
            this.lbl_version.Location = new System.Drawing.Point(11, 9);
            this.lbl_version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(71, 22);
            this.lbl_version.TabIndex = 8;
            this.lbl_version.Text = "Version";
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(145)))), ((int)(((byte)(236)))));
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_exit.ForeColor = System.Drawing.Color.White;
            this.btn_exit.Location = new System.Drawing.Point(587, 2);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btn_exit.Size = new System.Drawing.Size(22, 22);
            this.btn_exit.TabIndex = 11;
            this.btn_exit.TabStop = false;
            this.btn_exit.Text = "×";
            this.btn_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lbl_companyName
            // 
            this.lbl_companyName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_companyName.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_companyName.ForeColor = System.Drawing.Color.White;
            this.lbl_companyName.Location = new System.Drawing.Point(59, 112);
            this.lbl_companyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_companyName.Name = "lbl_companyName";
            this.lbl_companyName.Size = new System.Drawing.Size(493, 39);
            this.lbl_companyName.TabIndex = 12;
            this.lbl_companyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bar_step
            // 
            this.bar_step.BackColor = System.Drawing.Color.YellowGreen;
            this.bar_step.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.bar_step.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.bar_step.Location = new System.Drawing.Point(-1, 350);
            this.bar_step.Margin = new System.Windows.Forms.Padding(0);
            this.bar_step.MinimumSize = new System.Drawing.Size(70, 1);
            this.bar_step.Name = "bar_step";
            this.bar_step.Radius = 0;
            this.bar_step.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.bar_step.RectColor = System.Drawing.Color.Green;
            this.bar_step.Size = new System.Drawing.Size(613, 10);
            this.bar_step.Style = Sunny.UI.UIStyle.Custom;
            this.bar_step.TabIndex = 91;
            this.bar_step.Text = "50.0%";
            this.bar_step.Value = 100;
            this.bar_step.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(518, 237);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(62, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 92;
            this.pictureBox2.TabStop = false;
            // 
            // Frm_Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(145)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(611, 359);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbl_companyName);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.lbl_step);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bar_step);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VM Pro";
            this.Load += new System.EventHandler(this.Frm_Welcome_Load);
            this.Shown += new System.EventHandler(this.Frm_Welcome_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label lbl_step;
        internal System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.Button btn_exit;
        public System.Windows.Forms.Label lbl_companyName;
        private Sunny.UI.UIProcessBar bar_step;
        internal System.Windows.Forms.PictureBox pictureBox2;
    }
}