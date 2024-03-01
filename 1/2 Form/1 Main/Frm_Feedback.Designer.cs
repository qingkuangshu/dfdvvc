namespace VM_Pro
{
    partial class Frm_Feedback
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
            this.btn_submit = new Sunny.UI.UIButton();
            this.tbx_feedBackMessage = new System.Windows.Forms.TextBox();
            this.tbx_emailAddress = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLine5 = new Sunny.UI.UILine();
            this.SuspendLayout();
            // 
            // btn_submit
            // 
            this.btn_submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_submit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_submit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_submit.Location = new System.Drawing.Point(362, 197);
            this.btn_submit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_submit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(76, 30);
            this.btn_submit.Style = Sunny.UI.UIStyle.Custom;
            this.btn_submit.TabIndex = 129;
            this.btn_submit.Text = "提交";
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // tbx_feedBackMessage
            // 
            this.tbx_feedBackMessage.BackColor = System.Drawing.Color.White;
            this.tbx_feedBackMessage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_feedBackMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_feedBackMessage.Location = new System.Drawing.Point(21, 109);
            this.tbx_feedBackMessage.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tbx_feedBackMessage.Multiline = true;
            this.tbx_feedBackMessage.Name = "tbx_feedBackMessage";
            this.tbx_feedBackMessage.Size = new System.Drawing.Size(417, 79);
            this.tbx_feedBackMessage.TabIndex = 124;
            // 
            // tbx_emailAddress
            // 
            this.tbx_emailAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_emailAddress.FillColor = System.Drawing.Color.White;
            this.tbx_emailAddress.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_emailAddress.Location = new System.Drawing.Point(17, 199);
            this.tbx_emailAddress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbx_emailAddress.Maximum = 2147483647D;
            this.tbx_emailAddress.Minimum = -2147483648D;
            this.tbx_emailAddress.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_emailAddress.Name = "tbx_emailAddress";
            this.tbx_emailAddress.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_emailAddress.Radius = 0;
            this.tbx_emailAddress.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.tbx_emailAddress.Size = new System.Drawing.Size(339, 26);
            this.tbx_emailAddress.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_emailAddress.TabIndex = 127;
            this.tbx_emailAddress.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_emailAddress.Watermark = "可在此输入您的邮箱地址，便于我们回复（可不填）";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(17, 48);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(438, 57);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 131;
            this.uiLabel1.Text = "      感谢您对此产品提出宝贵意见，我们将认真汲取并改进，从而更好的服务用户，请在下面的文本框内填写您的反馈信息后提交。";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine5
            // 
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine5.LineSize = 2;
            this.uiLine5.Location = new System.Drawing.Point(22, 226);
            this.uiLine5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine5.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(330, 1);
            this.uiLine5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine5.TabIndex = 132;
            this.uiLine5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_Feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(458, 250);
            this.Controls.Add(this.uiLine5);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.tbx_emailAddress);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.tbx_feedBackMessage);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1093, 693);
            this.MinimizeBox = false;
            this.Name = "Frm_Feedback";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowInTaskbar = false;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "建议与反馈";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //internal System.Windows.Forms.Label label4;
        //private System.Windows.Forms.PictureBox pictureBox2;
        //internal System.Windows.Forms.Label lbl_legalStatement;
        //internal System.Windows.Forms.Label label2;
        //internal System.Windows.Forms.Label label1;
        //internal System.Windows.Forms.Label lbl_version;
        //internal System.Windows.Forms.Label label3;
        internal Sunny.UI.UIButton btn_submit;
        private System.Windows.Forms.TextBox tbx_feedBackMessage;
        internal Sunny.UI.UITextBox tbx_emailAddress;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILine uiLine5;
    }
}