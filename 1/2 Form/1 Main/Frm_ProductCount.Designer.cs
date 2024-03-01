namespace VM_Pro
{
    partial class Frm_ProductCount
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
            this.LineChart = new Sunny.UI.UILineChart();
            this.SuspendLayout();
            // 
            // LineChart
            // 
            this.LineChart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.LineChart.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.LineChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.LineChart.Location = new System.Drawing.Point(21, 54);
            this.LineChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.LineChart.Name = "LineChart";
            this.LineChart.Size = new System.Drawing.Size(936, 539);
            this.LineChart.Style = Sunny.UI.UIStyle.Custom;
            this.LineChart.TabIndex = 36;
            this.LineChart.Text = "uiLineChart1";
            // 
            // Frm_ProductCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(978, 613);
            this.Controls.Add(this.LineChart);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1093, 693);
            this.MinimizeBox = false;
            this.Name = "Frm_ProductCount";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowInTaskbar = false;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "产能统计";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.ResumeLayout(false);

        }

        #endregion

        //internal System.Windows.Forms.Label label4;
        //private System.Windows.Forms.PictureBox pictureBox2;
        //internal System.Windows.Forms.Label lbl_legalStatement;
        //internal System.Windows.Forms.Label label2;
        //internal System.Windows.Forms.Label label1;
        //internal System.Windows.Forms.Label lbl_version;
        //internal System.Windows.Forms.Label label3;
        private Sunny.UI.UILineChart LineChart;
    }
}