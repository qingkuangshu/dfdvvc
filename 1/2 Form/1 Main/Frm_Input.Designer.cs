namespace VM_Pro
{
    partial class Frm_Input
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
            this.btn_ok = new Sunny.UI.UIButton();
            this.tbx_input = new Sunny.UI.UITextBox();
            this.uiLine5 = new Sunny.UI.UILine();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ok.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Location = new System.Drawing.Point(259, 99);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ok.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(68, 30);
            this.btn_ok.Style = Sunny.UI.UIStyle.Custom;
            this.btn_ok.TabIndex = 125;
            this.btn_ok.Text = "确定";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // tbx_input
            // 
            this.tbx_input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_input.FillColor = System.Drawing.Color.White;
            this.tbx_input.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_input.Location = new System.Drawing.Point(24, 64);
            this.tbx_input.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_input.Maximum = 2147483647D;
            this.tbx_input.Minimum = -2147483648D;
            this.tbx_input.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_input.Name = "tbx_input";
            this.tbx_input.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_input.Radius = 0;
            this.tbx_input.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.tbx_input.Size = new System.Drawing.Size(293, 26);
            this.tbx_input.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_input.TabIndex = 126;
            this.tbx_input.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_input.Watermark = "水印文字";
            // 
            // uiLine5
            // 
            this.uiLine5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine5.LineSize = 2;
            this.uiLine5.Location = new System.Drawing.Point(0, 138);
            this.uiLine5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine5.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(341, 2);
            this.uiLine5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine5.TabIndex = 129;
            this.uiLine5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_Input
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(341, 140);
            this.Controls.Add(this.uiLine5);
            this.Controls.Add(this.tbx_input);
            this.Controls.Add(this.btn_ok);
            this.ExtendSymbolSize = 20;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.MinimizeBox = false;
            this.Name = "Frm_Input";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowInTaskbar = false;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "文本输入";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_Input_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal Sunny.UI.UIButton btn_ok;
        internal Sunny.UI.UITextBox tbx_input;
        private Sunny.UI.UILine uiLine5;
    }
}