namespace VM_Pro
{
    partial class Frm_Else
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
            this.lbl_passwordAgain = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.tbx_taskRunSpan = new Controls.CNumericUpDown();
            this.ckb_failStop = new Sunny.UI.UICheckBox();
            this.ckb_endStop = new Sunny.UI.UICheckBox();
            this.SuspendLayout();
            // 
            // lbl_passwordAgain
            // 
            this.lbl_passwordAgain.AutoSize = true;
            this.lbl_passwordAgain.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_passwordAgain.Location = new System.Drawing.Point(15, 14);
            this.lbl_passwordAgain.Name = "lbl_passwordAgain";
            this.lbl_passwordAgain.Size = new System.Drawing.Size(163, 20);
            this.lbl_passwordAgain.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_passwordAgain.TabIndex = 179;
            this.lbl_passwordAgain.Text = "任务循环运行间隔时间：";
            this.lbl_passwordAgain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(299, 14);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(28, 20);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 181;
            this.uiLabel1.Text = "ms";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_taskRunSpan
            // 
            this.tbx_taskRunSpan.BackColor = System.Drawing.Color.White;
            this.tbx_taskRunSpan.DecimalPlaces = 0;
            this.tbx_taskRunSpan.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_taskRunSpan.Incremeent = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tbx_taskRunSpan.Location = new System.Drawing.Point(169, 11);
            this.tbx_taskRunSpan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_taskRunSpan.MaximumSize = new System.Drawing.Size(300, 26);
            this.tbx_taskRunSpan.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tbx_taskRunSpan.MinimumSize = new System.Drawing.Size(50, 26);
            this.tbx_taskRunSpan.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbx_taskRunSpan.Name = "tbx_taskRunSpan";
            this.tbx_taskRunSpan.Size = new System.Drawing.Size(127, 26);
            this.tbx_taskRunSpan.TabIndex = 215;
            this.tbx_taskRunSpan.TabStop = false;
            this.tbx_taskRunSpan.Value = 100D;
            this.tbx_taskRunSpan.ValueChanged += new Controls.DValueChanged(this.tbx_taskRunSpan_ValueChanged);
            // 
            // ckb_failStop
            // 
            this.ckb_failStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_failStop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_failStop.Location = new System.Drawing.Point(16, 46);
            this.ckb_failStop.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_failStop.Name = "ckb_failStop";
            this.ckb_failStop.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_failStop.Size = new System.Drawing.Size(197, 30);
            this.ckb_failStop.TabIndex = 216;
            this.ckb_failStop.Text = "任务失败时停止循环";
            this.ckb_failStop.CheckedChanged += new System.EventHandler(this.ckb_failStop_CheckedChanged);
            // 
            // ckb_endStop
            // 
            this.ckb_endStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_endStop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_endStop.Location = new System.Drawing.Point(16, 77);
            this.ckb_endStop.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_endStop.Name = "ckb_endStop";
            this.ckb_endStop.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_endStop.Size = new System.Drawing.Size(197, 30);
            this.ckb_endStop.TabIndex = 217;
            this.ckb_endStop.Text = "遍历完成后停止循环";
            this.ckb_endStop.Click += new System.EventHandler(this.ckb_endStop_Click);
            // 
            // Frm_Else
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(842, 601);
            this.Controls.Add(this.ckb_endStop);
            this.Controls.Add(this.ckb_failStop);
            this.Controls.Add(this.tbx_taskRunSpan);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.lbl_passwordAgain);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_Else";
            this.Text = "Frm_Project";
            this.Load += new System.EventHandler(this.Frm_Else_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel lbl_passwordAgain;
        private Sunny.UI.UILabel uiLabel1;
        internal Controls.CNumericUpDown tbx_taskRunSpan;
        private Sunny.UI.UICheckBox ckb_failStop;
        private Sunny.UI.UICheckBox ckb_endStop;
    }
}