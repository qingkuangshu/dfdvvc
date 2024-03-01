namespace RobotControl
{
    partial class Frm_MorePar
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
            this.tbx_robotIP = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_goSafeHeight = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_saveSafeHeight = new System.Windows.Forms.Button();
            this.tbx_safeHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_statu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_robotPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbx_robotIP
            // 
            this.tbx_robotIP.Location = new System.Drawing.Point(74, 12);
            this.tbx_robotIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_robotIP.Name = "tbx_robotIP";
            this.tbx_robotIP.Size = new System.Drawing.Size(106, 23);
            this.tbx_robotIP.TabIndex = 100096;
            this.tbx_robotIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbx_robotIP.TextChanged += new System.EventHandler(this.tbx_robotIP_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 17);
            this.label16.TabIndex = 100095;
            this.label16.Text = "IP   地址：";
            // 
            // btn_goSafeHeight
            // 
            this.btn_goSafeHeight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_goSafeHeight.Location = new System.Drawing.Point(214, 98);
            this.btn_goSafeHeight.Name = "btn_goSafeHeight";
            this.btn_goSafeHeight.Size = new System.Drawing.Size(60, 26);
            this.btn_goSafeHeight.TabIndex = 100117;
            this.btn_goSafeHeight.Text = "前往";
            this.btn_goSafeHeight.UseVisualStyleBackColor = true;
            this.btn_goSafeHeight.Click += new System.EventHandler(this.btn_goSafeHeight_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(180, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 17);
            this.label10.TabIndex = 100119;
            this.label10.Text = "mm";
            // 
            // btn_saveSafeHeight
            // 
            this.btn_saveSafeHeight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_saveSafeHeight.Location = new System.Drawing.Point(276, 98);
            this.btn_saveSafeHeight.Name = "btn_saveSafeHeight";
            this.btn_saveSafeHeight.Size = new System.Drawing.Size(60, 26);
            this.btn_saveSafeHeight.TabIndex = 100118;
            this.btn_saveSafeHeight.Text = "示教";
            this.btn_saveSafeHeight.UseVisualStyleBackColor = true;
            this.btn_saveSafeHeight.Click += new System.EventHandler(this.btn_saveSafeHeight_Click);
            // 
            // tbx_safeHeight
            // 
            this.tbx_safeHeight.Location = new System.Drawing.Point(74, 99);
            this.tbx_safeHeight.Name = "tbx_safeHeight";
            this.tbx_safeHeight.Size = new System.Drawing.Size(106, 23);
            this.tbx_safeHeight.TabIndex = 100116;
            this.tbx_safeHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbx_safeHeight.TextChanged += new System.EventHandler(this.tbx_safeHeight_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 100115;
            this.label1.Text = "安全高度：";
            // 
            // lbl_statu
            // 
            this.lbl_statu.AutoSize = true;
            this.lbl_statu.Location = new System.Drawing.Point(72, 229);
            this.lbl_statu.Name = "lbl_statu";
            this.lbl_statu.Size = new System.Drawing.Size(20, 17);
            this.lbl_statu.TabIndex = 100121;
            this.lbl_statu.Text = "无";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 100120;
            this.label3.Text = "提示信息：";
            // 
            // tbx_robotPort
            // 
            this.tbx_robotPort.Location = new System.Drawing.Point(74, 41);
            this.tbx_robotPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_robotPort.Name = "tbx_robotPort";
            this.tbx_robotPort.Size = new System.Drawing.Size(106, 23);
            this.tbx_robotPort.TabIndex = 100123;
            this.tbx_robotPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbx_robotPort.TextChanged += new System.EventHandler(this.tbx_robotPort_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 100122;
            this.label2.Text = "端 口  号：";
            // 
            // tbx_password
            // 
            this.tbx_password.Location = new System.Drawing.Point(74, 70);
            this.tbx_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.Size = new System.Drawing.Size(106, 23);
            this.tbx_password.TabIndex = 100125;
            this.tbx_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbx_password.TextChanged += new System.EventHandler(this.tbx_password_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 100124;
            this.label4.Text = "登录密码：";
            // 
            // Frm_MorePar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(389, 255);
            this.Controls.Add(this.tbx_password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbx_robotPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_statu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_goSafeHeight);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_saveSafeHeight);
            this.Controls.Add(this.tbx_safeHeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_robotIP);
            this.Controls.Add(this.label16);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_MorePar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更多参数";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_MorePar_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox tbx_robotIP;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_goSafeHeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_saveSafeHeight;
        internal System.Windows.Forms.TextBox tbx_safeHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_statu;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox tbx_robotPort;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox tbx_password;
        private System.Windows.Forms.Label label4;
    }
}