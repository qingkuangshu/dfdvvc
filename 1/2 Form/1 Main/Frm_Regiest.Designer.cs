namespace VM_Pro
{
    partial class Frm_Regiest
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_machineCode = new System.Windows.Forms.TextBox();
            this.btn_regiest = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_regiestCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(14, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(387, 60);
            this.label4.TabIndex = 21;
            this.label4.Text = "       软件未激活，请联系厂商或作者，并将下面的机器码发给\r\n对方兑换激活码，输入激活码激活后方能正常无限期使用。作\r\n者QQ：1070645289";
            // 
            // tbx_machineCode
            // 
            this.tbx_machineCode.Location = new System.Drawing.Point(71, 120);
            this.tbx_machineCode.Name = "tbx_machineCode";
            this.tbx_machineCode.ReadOnly = true;
            this.tbx_machineCode.Size = new System.Drawing.Size(330, 26);
            this.tbx_machineCode.TabIndex = 100;
            this.tbx_machineCode.TabStop = false;
            // 
            // btn_regiest
            // 
            this.btn_regiest.Location = new System.Drawing.Point(331, 181);
            this.btn_regiest.Name = "btn_regiest";
            this.btn_regiest.Size = new System.Drawing.Size(70, 30);
            this.btn_regiest.TabIndex = 26;
            this.btn_regiest.Text = "激活";
            this.btn_regiest.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_regiest.UseVisualStyleBackColor = true;
            this.btn_regiest.Click += new System.EventHandler(this.btn_regiest_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(14, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "机器码：";
            // 
            // tbx_regiestCode
            // 
            this.tbx_regiestCode.Location = new System.Drawing.Point(71, 149);
            this.tbx_regiestCode.Name = "tbx_regiestCode";
            this.tbx_regiestCode.PasswordChar = '*';
            this.tbx_regiestCode.Size = new System.Drawing.Size(330, 26);
            this.tbx_regiestCode.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(14, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "激活码：";
            // 
            // Frm_Regiest
            // 
            this.AcceptButton = this.btn_regiest;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(422, 229);
            this.Controls.Add(this.tbx_machineCode);
            this.Controls.Add(this.btn_regiest);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbx_regiestCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.ExtendSymbolSize = 20;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.MinimizeBox = false;
            this.Name = "Frm_Regiest";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowInTaskbar = false;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "激活";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Regiest_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Regiest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_machineCode;
        private System.Windows.Forms.Button btn_regiest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbx_regiestCode;
        private System.Windows.Forms.Label label5;

    }
}