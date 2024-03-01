namespace VM_Pro
{
    partial class FrmResolution
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
            this.txt_ImgWidth = new Sunny.UI.UITextBox();
            this.lbImgHeight = new Sunny.UI.UILabel();
            this.txt_ImgHeight = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(42, 20);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "宽度";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_ImgWidth
            // 
            this.txt_ImgWidth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ImgWidth.DoubleValue = 1024D;
            this.txt_ImgWidth.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ImgWidth.IntValue = 1024;
            this.txt_ImgWidth.Location = new System.Drawing.Point(156, 18);
            this.txt_ImgWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_ImgWidth.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_ImgWidth.Name = "txt_ImgWidth";
            this.txt_ImgWidth.ShowText = false;
            this.txt_ImgWidth.Size = new System.Drawing.Size(150, 29);
            this.txt_ImgWidth.TabIndex = 1;
            this.txt_ImgWidth.Text = "1024";
            this.txt_ImgWidth.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_ImgWidth.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_ImgWidth.Watermark = "";
            this.txt_ImgWidth.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_ImgWidth.TextChanged += new System.EventHandler(this.txt_ImgHeight_TextChanged);
            this.txt_ImgWidth.DoEnter += new System.EventHandler(this.txt_ImgHeight_DoEnter);
            // 
            // lbImgHeight
            // 
            this.lbImgHeight.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbImgHeight.Location = new System.Drawing.Point(42, 68);
            this.lbImgHeight.Name = "lbImgHeight";
            this.lbImgHeight.Size = new System.Drawing.Size(100, 23);
            this.lbImgHeight.TabIndex = 0;
            this.lbImgHeight.Text = "高度";
            this.lbImgHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbImgHeight.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_ImgHeight
            // 
            this.txt_ImgHeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ImgHeight.DoubleValue = 512D;
            this.txt_ImgHeight.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ImgHeight.IntValue = 512;
            this.txt_ImgHeight.Location = new System.Drawing.Point(156, 66);
            this.txt_ImgHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_ImgHeight.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_ImgHeight.Name = "txt_ImgHeight";
            this.txt_ImgHeight.ShowText = false;
            this.txt_ImgHeight.Size = new System.Drawing.Size(150, 29);
            this.txt_ImgHeight.TabIndex = 1;
            this.txt_ImgHeight.Text = "512";
            this.txt_ImgHeight.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_ImgHeight.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_ImgHeight.Watermark = "";
            this.txt_ImgHeight.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_ImgHeight.TextChanged += new System.EventHandler(this.txt_ImgHeight_TextChanged);
            this.txt_ImgHeight.DoEnter += new System.EventHandler(this.txt_ImgHeight_DoEnter);
            // 
            // FrmResolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 140);
            this.Controls.Add(this.txt_ImgHeight);
            this.Controls.Add(this.lbImgHeight);
            this.Controls.Add(this.txt_ImgWidth);
            this.Controls.Add(this.uiLabel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmResolution";
            this.Text = "FrmResolution";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel lbImgHeight;
        internal Sunny.UI.UITextBox txt_ImgWidth;
        internal Sunny.UI.UITextBox txt_ImgHeight;
    }
}