namespace VM_Pro
{
    partial class Frm_Emphasize
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
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.lb_width = new Sunny.UI.UILabel();
            this.lb_height = new Sunny.UI.UILabel();
            this.lb_factor = new Sunny.UI.UILabel();
            this.TB_Width = new System.Windows.Forms.TrackBar();
            this.TB_Height = new System.Windows.Forms.TrackBar();
            this.TB_Factor = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Factor)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(33, 9);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(67, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "宽度 :";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(33, 60);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(64, 23);
            this.uiLabel2.TabIndex = 0;
            this.uiLabel2.Text = "高度 :";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(-6, 108);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(106, 23);
            this.uiLabel3.TabIndex = 0;
            this.uiLabel3.Text = "对比因子 :";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_width
            // 
            this.lb_width.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_width.Location = new System.Drawing.Point(305, 9);
            this.lb_width.Name = "lb_width";
            this.lb_width.Size = new System.Drawing.Size(54, 23);
            this.lb_width.TabIndex = 0;
            this.lb_width.Text = "3";
            this.lb_width.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_width.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_height
            // 
            this.lb_height.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_height.Location = new System.Drawing.Point(305, 60);
            this.lb_height.Name = "lb_height";
            this.lb_height.Size = new System.Drawing.Size(54, 23);
            this.lb_height.TabIndex = 0;
            this.lb_height.Text = "3";
            this.lb_height.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_height.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_factor
            // 
            this.lb_factor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_factor.Location = new System.Drawing.Point(305, 108);
            this.lb_factor.Name = "lb_factor";
            this.lb_factor.Size = new System.Drawing.Size(54, 23);
            this.lb_factor.TabIndex = 0;
            this.lb_factor.Text = "0.3";
            this.lb_factor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_factor.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // TB_Width
            // 
            this.TB_Width.AutoSize = false;
            this.TB_Width.Location = new System.Drawing.Point(97, 12);
            this.TB_Width.Maximum = 201;
            this.TB_Width.Minimum = 3;
            this.TB_Width.Name = "TB_Width";
            this.TB_Width.Size = new System.Drawing.Size(202, 27);
            this.TB_Width.TabIndex = 1;
            this.TB_Width.Value = 3;
            this.TB_Width.Scroll += new System.EventHandler(this.TB_Width_Scroll);
            // 
            // TB_Height
            // 
            this.TB_Height.AutoSize = false;
            this.TB_Height.Location = new System.Drawing.Point(97, 60);
            this.TB_Height.Maximum = 201;
            this.TB_Height.Minimum = 3;
            this.TB_Height.Name = "TB_Height";
            this.TB_Height.Size = new System.Drawing.Size(202, 27);
            this.TB_Height.TabIndex = 1;
            this.TB_Height.Value = 3;
            this.TB_Height.Scroll += new System.EventHandler(this.TB_Height_Scroll);
            // 
            // TB_Factor
            // 
            this.TB_Factor.AutoSize = false;
            this.TB_Factor.Location = new System.Drawing.Point(97, 108);
            this.TB_Factor.Maximum = 200;
            this.TB_Factor.Minimum = 3;
            this.TB_Factor.Name = "TB_Factor";
            this.TB_Factor.Size = new System.Drawing.Size(202, 27);
            this.TB_Factor.TabIndex = 1;
            this.TB_Factor.Value = 3;
            this.TB_Factor.Scroll += new System.EventHandler(this.TB_Factor_Scroll);
            // 
            // Frm_Emphasize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 140);
            this.Controls.Add(this.TB_Factor);
            this.Controls.Add(this.TB_Height);
            this.Controls.Add(this.TB_Width);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.lb_factor);
            this.Controls.Add(this.lb_height);
            this.Controls.Add(this.lb_width);
            this.Controls.Add(this.uiLabel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Frm_Emphasize";
            this.Text = "Frm_Emphasize";
            ((System.ComponentModel.ISupportInitialize)(this.TB_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Factor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel lb_width;
        private Sunny.UI.UILabel lb_height;
        private Sunny.UI.UILabel lb_factor;
        internal System.Windows.Forms.TrackBar TB_Width;
        internal System.Windows.Forms.TrackBar TB_Height;
        internal System.Windows.Forms.TrackBar TB_Factor;
    }
}