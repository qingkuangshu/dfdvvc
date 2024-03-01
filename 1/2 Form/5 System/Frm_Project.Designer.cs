namespace VM_Pro
{
    partial class Frm_Project
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
            this.btn_export = new Sunny.UI.UIButton();
            this.btn_inport = new Sunny.UI.UIButton();
            this.lbl_passwordAgain = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.tbx_companyName = new Sunny.UI.UITextBox();
            this.tbx_projectName = new Sunny.UI.UITextBox();
            this.tbx_dataSaveTime = new Sunny.UI.UITextBox();
            this.tbx_dataPath = new Sunny.UI.UITextBox();
            this.rdo_saveDataTimeBasedDay = new Sunny.UI.UIRadioButton();
            this.rdo_saveDataTimeBasedHour = new Sunny.UI.UIRadioButton();
            this.btn_selectDataPath = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // btn_export
            // 
            this.btn_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_export.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_export.Location = new System.Drawing.Point(115, 149);
            this.btn_export.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_export.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(80, 34);
            this.btn_export.TabIndex = 155;
            this.btn_export.Text = "导出项目";
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_inport
            // 
            this.btn_inport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_inport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_inport.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_inport.Location = new System.Drawing.Point(198, 149);
            this.btn_inport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_inport.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_inport.Name = "btn_inport";
            this.btn_inport.Size = new System.Drawing.Size(80, 34);
            this.btn_inport.TabIndex = 154;
            this.btn_inport.Text = "导入项目";
            this.btn_inport.Click += new System.EventHandler(this.btn_inport_Click);
            // 
            // lbl_passwordAgain
            // 
            this.lbl_passwordAgain.AutoSize = true;
            this.lbl_passwordAgain.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_passwordAgain.Location = new System.Drawing.Point(15, 14);
            this.lbl_passwordAgain.Name = "lbl_passwordAgain";
            this.lbl_passwordAgain.Size = new System.Drawing.Size(72, 20);
            this.lbl_passwordAgain.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_passwordAgain.TabIndex = 156;
            this.lbl_passwordAgain.Text = "公司名称 :";
            this.lbl_passwordAgain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(15, 46);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(72, 20);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 157;
            this.uiLabel1.Text = "项目名称 :";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(15, 78);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(72, 20);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 159;
            this.uiLabel3.Text = "数据路径 :";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(15, 110);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(72, 20);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 160;
            this.uiLabel4.Text = "存储时长 :";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_companyName
            // 
            this.tbx_companyName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_companyName.FillColor = System.Drawing.Color.White;
            this.tbx_companyName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_companyName.Location = new System.Drawing.Point(90, 9);
            this.tbx_companyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_companyName.Maximum = 2147483647D;
            this.tbx_companyName.Minimum = -2147483648D;
            this.tbx_companyName.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_companyName.Name = "tbx_companyName";
            this.tbx_companyName.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_companyName.Radius = 0;
            this.tbx_companyName.RectColor = System.Drawing.Color.White;
            this.tbx_companyName.RectSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbx_companyName.Size = new System.Drawing.Size(341, 29);
            this.tbx_companyName.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_companyName.TabIndex = 162;
            this.tbx_companyName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_companyName.Watermark = "请输入公司名称";
            this.tbx_companyName.TextChanged += new System.EventHandler(this.tbx_companyName_TextChanged);
            // 
            // tbx_projectName
            // 
            this.tbx_projectName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_projectName.FillColor = System.Drawing.Color.White;
            this.tbx_projectName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_projectName.Location = new System.Drawing.Point(90, 41);
            this.tbx_projectName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_projectName.Maximum = 2147483647D;
            this.tbx_projectName.Minimum = -2147483648D;
            this.tbx_projectName.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_projectName.Name = "tbx_projectName";
            this.tbx_projectName.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_projectName.Radius = 0;
            this.tbx_projectName.RectColor = System.Drawing.Color.White;
            this.tbx_projectName.Size = new System.Drawing.Size(341, 29);
            this.tbx_projectName.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_projectName.TabIndex = 163;
            this.tbx_projectName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_projectName.Watermark = "请输入项目名称";
            this.tbx_projectName.TextChanged += new System.EventHandler(this.tbx_projectName_TextChanged);
            // 
            // tbx_dataSaveTime
            // 
            this.tbx_dataSaveTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_dataSaveTime.FillColor = System.Drawing.Color.White;
            this.tbx_dataSaveTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_dataSaveTime.Location = new System.Drawing.Point(89, 105);
            this.tbx_dataSaveTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_dataSaveTime.Maximum = 2147483647D;
            this.tbx_dataSaveTime.Minimum = -2147483648D;
            this.tbx_dataSaveTime.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_dataSaveTime.Name = "tbx_dataSaveTime";
            this.tbx_dataSaveTime.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_dataSaveTime.Radius = 0;
            this.tbx_dataSaveTime.RectColor = System.Drawing.Color.White;
            this.tbx_dataSaveTime.Size = new System.Drawing.Size(150, 29);
            this.tbx_dataSaveTime.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_dataSaveTime.TabIndex = 163;
            this.tbx_dataSaveTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_dataSaveTime.Watermark = "请输入数据存储时长";
            this.tbx_dataSaveTime.TextChanged += new System.EventHandler(this.tbx_dataSaveTime_TextChanged);
            // 
            // tbx_dataPath
            // 
            this.tbx_dataPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_dataPath.FillColor = System.Drawing.Color.White;
            this.tbx_dataPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_dataPath.Location = new System.Drawing.Point(90, 73);
            this.tbx_dataPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_dataPath.Maximum = 2147483647D;
            this.tbx_dataPath.Minimum = -2147483648D;
            this.tbx_dataPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_dataPath.Name = "tbx_dataPath";
            this.tbx_dataPath.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_dataPath.Radius = 0;
            this.tbx_dataPath.RectColor = System.Drawing.Color.White;
            this.tbx_dataPath.Size = new System.Drawing.Size(217, 29);
            this.tbx_dataPath.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_dataPath.TabIndex = 163;
            this.tbx_dataPath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_dataPath.Watermark = "请输入数据存储路径";
            this.tbx_dataPath.TextChanged += new System.EventHandler(this.tbx_dataPath_TextChanged);
            // 
            // rdo_saveDataTimeBasedDay
            // 
            this.rdo_saveDataTimeBasedDay.Checked = true;
            this.rdo_saveDataTimeBasedDay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_saveDataTimeBasedDay.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_saveDataTimeBasedDay.Location = new System.Drawing.Point(244, 103);
            this.rdo_saveDataTimeBasedDay.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_saveDataTimeBasedDay.Name = "rdo_saveDataTimeBasedDay";
            this.rdo_saveDataTimeBasedDay.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_saveDataTimeBasedDay.Size = new System.Drawing.Size(65, 35);
            this.rdo_saveDataTimeBasedDay.TabIndex = 164;
            this.rdo_saveDataTimeBasedDay.Text = "天";
            this.rdo_saveDataTimeBasedDay.CheckedChanged += new System.EventHandler(this.rdo_saveDataTimeBasedDay_CheckedChanged);
            // 
            // rdo_saveDataTimeBasedHour
            // 
            this.rdo_saveDataTimeBasedHour.Checked = true;
            this.rdo_saveDataTimeBasedHour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_saveDataTimeBasedHour.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_saveDataTimeBasedHour.Location = new System.Drawing.Point(317, 103);
            this.rdo_saveDataTimeBasedHour.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_saveDataTimeBasedHour.Name = "rdo_saveDataTimeBasedHour";
            this.rdo_saveDataTimeBasedHour.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_saveDataTimeBasedHour.Size = new System.Drawing.Size(65, 35);
            this.rdo_saveDataTimeBasedHour.TabIndex = 165;
            this.rdo_saveDataTimeBasedHour.Text = "时";
            this.rdo_saveDataTimeBasedHour.CheckedChanged += new System.EventHandler(this.rdo_saveDataTimeBasedHour_CheckedChanged);
            // 
            // btn_selectDataPath
            // 
            this.btn_selectDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectDataPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selectDataPath.FillColor = System.Drawing.Color.White;
            this.btn_selectDataPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_selectDataPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btn_selectDataPath.Location = new System.Drawing.Point(412, 79);
            this.btn_selectDataPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_selectDataPath.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_selectDataPath.Name = "btn_selectDataPath";
            this.btn_selectDataPath.Radius = 0;
            this.btn_selectDataPath.RectColor = System.Drawing.Color.White;
            this.btn_selectDataPath.Size = new System.Drawing.Size(25, 20);
            this.btn_selectDataPath.Style = Sunny.UI.UIStyle.Custom;
            this.btn_selectDataPath.TabIndex = 170;
            this.btn_selectDataPath.Text = "...";
            this.btn_selectDataPath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_selectDataPath.Click += new System.EventHandler(this.btn_selectDataPath_Click);
            // 
            // Frm_Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(842, 601);
            this.Controls.Add(this.btn_selectDataPath);
            this.Controls.Add(this.rdo_saveDataTimeBasedHour);
            this.Controls.Add(this.rdo_saveDataTimeBasedDay);
            this.Controls.Add(this.tbx_dataSaveTime);
            this.Controls.Add(this.tbx_dataPath);
            this.Controls.Add(this.tbx_projectName);
            this.Controls.Add(this.tbx_companyName);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.lbl_passwordAgain);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_inport);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_Project";
            this.Text = "Frm_Project";
            this.Load += new System.EventHandler(this.Frm_Project_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Sunny.UI.UIButton btn_export;
        internal Sunny.UI.UIButton btn_inport;
        private Sunny.UI.UILabel lbl_passwordAgain;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox tbx_companyName;
        private Sunny.UI.UITextBox tbx_projectName;
        private Sunny.UI.UITextBox tbx_dataSaveTime;
        private Sunny.UI.UITextBox tbx_dataPath;
        private Sunny.UI.UIRadioButton rdo_saveDataTimeBasedDay;
        private Sunny.UI.UIRadioButton rdo_saveDataTimeBasedHour;
        internal Sunny.UI.UIButton btn_selectDataPath;
    }
}