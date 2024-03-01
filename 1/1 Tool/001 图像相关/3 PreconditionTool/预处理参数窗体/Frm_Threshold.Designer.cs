namespace VM_Pro
{
    partial class Frm_Threshold
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.lb_LowValue = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.lb_HigValue = new Sunny.UI.UILabel();
            this.Ckb_HeiBai = new Sunny.UI.UICheckBox();
            this.TB_Low = new System.Windows.Forms.TrackBar();
            this.TB_Hig = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Low)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Hig)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(13, 24);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(72, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "低阈值 :";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_LowValue
            // 
            this.lb_LowValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_LowValue.Location = new System.Drawing.Point(310, 24);
            this.lb_LowValue.Name = "lb_LowValue";
            this.lb_LowValue.Size = new System.Drawing.Size(46, 23);
            this.lb_LowValue.TabIndex = 0;
            this.lb_LowValue.Text = "50";
            this.lb_LowValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_LowValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(13, 59);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(72, 23);
            this.uiLabel3.TabIndex = 0;
            this.uiLabel3.Text = "高阈值 :";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_HigValue
            // 
            this.lb_HigValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_HigValue.Location = new System.Drawing.Point(306, 59);
            this.lb_HigValue.Name = "lb_HigValue";
            this.lb_HigValue.Size = new System.Drawing.Size(50, 23);
            this.lb_HigValue.TabIndex = 0;
            this.lb_HigValue.Text = "200";
            this.lb_HigValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_HigValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Ckb_HeiBai
            // 
            this.Ckb_HeiBai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ckb_HeiBai.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Ckb_HeiBai.Location = new System.Drawing.Point(137, 101);
            this.Ckb_HeiBai.MinimumSize = new System.Drawing.Size(1, 1);
            this.Ckb_HeiBai.Name = "Ckb_HeiBai";
            this.Ckb_HeiBai.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.Ckb_HeiBai.Size = new System.Drawing.Size(104, 29);
            this.Ckb_HeiBai.TabIndex = 2;
            this.Ckb_HeiBai.Text = "黑白翻转";
            this.Ckb_HeiBai.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Ckb_HeiBai.Click += new System.EventHandler(this.Ckb_HeiBai_Click);
            // 
            // TB_Low
            // 
            this.TB_Low.AutoSize = false;
            this.TB_Low.Location = new System.Drawing.Point(91, 25);
            this.TB_Low.Maximum = 254;
            this.TB_Low.Minimum = 1;
            this.TB_Low.Name = "TB_Low";
            this.TB_Low.Size = new System.Drawing.Size(219, 22);
            this.TB_Low.TabIndex = 3;
            this.TB_Low.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TB_Low.Value = 1;
            this.TB_Low.Scroll += new System.EventHandler(this.TB_Low_Scroll);
            // 
            // TB_Hig
            // 
            this.TB_Hig.AutoSize = false;
            this.TB_Hig.Location = new System.Drawing.Point(91, 60);
            this.TB_Hig.Maximum = 255;
            this.TB_Hig.Minimum = 1;
            this.TB_Hig.Name = "TB_Hig";
            this.TB_Hig.Size = new System.Drawing.Size(219, 22);
            this.TB_Hig.TabIndex = 3;
            this.TB_Hig.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TB_Hig.Value = 1;
            this.TB_Hig.Scroll += new System.EventHandler(this.TB_Hig_Scroll);
            // 
            // Frm_Threshold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 140);
            this.Controls.Add(this.TB_Hig);
            this.Controls.Add(this.TB_Low);
            this.Controls.Add(this.Ckb_HeiBai);
            this.Controls.Add(this.lb_HigValue);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.lb_LowValue);
            this.Controls.Add(this.uiLabel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Frm_Threshold";
            this.Text = "Frm_Threshold";
            ((System.ComponentModel.ISupportInitialize)(this.TB_Low)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Hig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel3;
        internal Sunny.UI.UICheckBox Ckb_HeiBai;
        internal System.Windows.Forms.TrackBar TB_Low;
        internal System.Windows.Forms.TrackBar TB_Hig;
        internal Sunny.UI.UILabel lb_LowValue;
        internal Sunny.UI.UILabel lb_HigValue;
    }
}