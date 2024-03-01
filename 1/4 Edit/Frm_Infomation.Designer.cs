namespace VM_Pro
{
    partial class Frm_Infomation
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
            this.components = new System.ComponentModel.Container();
            this.uiLine6 = new Sunny.UI.UILine();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.lbl_ngNum = new Sunny.UI.UILabel();
            this.lbl_okNum = new Sunny.UI.UILabel();
            this.lbl_yield = new Sunny.UI.UILabel();
            this.lbl_totalNum = new Sunny.UI.UILabel();
            this.btn_clearCount = new System.Windows.Forms.Button();
            this.btn_browseHistory = new System.Windows.Forms.Button();
            this.ckb_StartUpload = new Sunny.UI.UICheckBox();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.txt_NGOverrunNum = new Sunny.UI.UITextBox();
            this.txt_UploadTime = new Sunny.UI.UITextBox();
            this.uiRadioButton2 = new Sunny.UI.UIRadioButton();
            this.rad_UploadTime = new Sunny.UI.UIRadioButton();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.tm_Upload = new System.Windows.Forms.Timer(this.components);
            this.ckb_StartTaskCheckout = new Sunny.UI.UICheckBox();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLine6
            // 
            this.uiLine6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiLine6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine6.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine6.Location = new System.Drawing.Point(-5, 12);
            this.uiLine6.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine6.Name = "uiLine6";
            this.uiLine6.Size = new System.Drawing.Size(418, 20);
            this.uiLine6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine6.TabIndex = 59;
            this.uiLine6.Text = "生产统计";
            this.uiLine6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(20, 35);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(99, 24);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 131;
            this.uiLabel1.Text = "总       数：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(20, 63);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(99, 24);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 132;
            this.uiLabel2.Text = "良       率：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(166, 35);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(54, 24);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 133;
            this.uiLabel3.Text = "OK：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(166, 63);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(56, 24);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 134;
            this.uiLabel4.Text = "NG：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_ngNum
            // 
            this.lbl_ngNum.AutoSize = true;
            this.lbl_ngNum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ngNum.Location = new System.Drawing.Point(201, 64);
            this.lbl_ngNum.Name = "lbl_ngNum";
            this.lbl_ngNum.Size = new System.Drawing.Size(21, 24);
            this.lbl_ngNum.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_ngNum.TabIndex = 138;
            this.lbl_ngNum.Text = "0";
            this.lbl_ngNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_ngNum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_okNum
            // 
            this.lbl_okNum.AutoSize = true;
            this.lbl_okNum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_okNum.Location = new System.Drawing.Point(201, 36);
            this.lbl_okNum.Name = "lbl_okNum";
            this.lbl_okNum.Size = new System.Drawing.Size(21, 24);
            this.lbl_okNum.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_okNum.TabIndex = 137;
            this.lbl_okNum.Text = "0";
            this.lbl_okNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_okNum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_yield
            // 
            this.lbl_yield.AutoSize = true;
            this.lbl_yield.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_yield.Location = new System.Drawing.Point(91, 64);
            this.lbl_yield.Name = "lbl_yield";
            this.lbl_yield.Size = new System.Drawing.Size(21, 24);
            this.lbl_yield.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_yield.TabIndex = 136;
            this.lbl_yield.Text = "0";
            this.lbl_yield.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_yield.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_totalNum
            // 
            this.lbl_totalNum.AutoSize = true;
            this.lbl_totalNum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_totalNum.Location = new System.Drawing.Point(91, 36);
            this.lbl_totalNum.Name = "lbl_totalNum";
            this.lbl_totalNum.Size = new System.Drawing.Size(21, 24);
            this.lbl_totalNum.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_totalNum.TabIndex = 135;
            this.lbl_totalNum.Text = "0";
            this.lbl_totalNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_totalNum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_clearCount
            // 
            this.btn_clearCount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_clearCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_clearCount.Location = new System.Drawing.Point(295, 22);
            this.btn_clearCount.Name = "btn_clearCount";
            this.btn_clearCount.Size = new System.Drawing.Size(80, 32);
            this.btn_clearCount.TabIndex = 100073;
            this.btn_clearCount.Text = "统计清零";
            this.btn_clearCount.UseVisualStyleBackColor = true;
            this.btn_clearCount.Click += new System.EventHandler(this.btn_clearCount_Click);
            // 
            // btn_browseHistory
            // 
            this.btn_browseHistory.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_browseHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_browseHistory.Location = new System.Drawing.Point(295, 54);
            this.btn_browseHistory.Name = "btn_browseHistory";
            this.btn_browseHistory.Size = new System.Drawing.Size(80, 32);
            this.btn_browseHistory.TabIndex = 100088;
            this.btn_browseHistory.Text = "查看统计";
            this.btn_browseHistory.UseVisualStyleBackColor = true;
            this.btn_browseHistory.Visible = false;
            this.btn_browseHistory.Click += new System.EventHandler(this.btn_browseHistory_Click);
            // 
            // ckb_StartUpload
            // 
            this.ckb_StartUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.ckb_StartUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_StartUpload.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_StartUpload.Location = new System.Drawing.Point(16, 49);
            this.ckb_StartUpload.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_StartUpload.Name = "ckb_StartUpload";
            this.ckb_StartUpload.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_StartUpload.Size = new System.Drawing.Size(193, 29);
            this.ckb_StartUpload.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_StartUpload.TabIndex = 100089;
            this.ckb_StartUpload.Text = "启用补码上传功能";
            this.ckb_StartUpload.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_StartUpload.Click += new System.EventHandler(this.ckb_StartUpload_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.txt_NGOverrunNum);
            this.uiGroupBox1.Controls.Add(this.txt_UploadTime);
            this.uiGroupBox1.Controls.Add(this.uiRadioButton2);
            this.uiGroupBox1.Controls.Add(this.rad_UploadTime);
            this.uiGroupBox1.Controls.Add(this.uiLabel6);
            this.uiGroupBox1.Controls.Add(this.uiLabel5);
            this.uiGroupBox1.Controls.Add(this.ckb_StartUpload);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(13, 195);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(377, 331);
            this.uiGroupBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox1.TabIndex = 100090;
            this.uiGroupBox1.Text = "补码上传操作";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_NGOverrunNum
            // 
            this.txt_NGOverrunNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_NGOverrunNum.DoubleValue = 5D;
            this.txt_NGOverrunNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_NGOverrunNum.IntValue = 5;
            this.txt_NGOverrunNum.Location = new System.Drawing.Point(195, 207);
            this.txt_NGOverrunNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_NGOverrunNum.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_NGOverrunNum.Name = "txt_NGOverrunNum";
            this.txt_NGOverrunNum.ShowText = false;
            this.txt_NGOverrunNum.Size = new System.Drawing.Size(169, 29);
            this.txt_NGOverrunNum.Style = Sunny.UI.UIStyle.Custom;
            this.txt_NGOverrunNum.TabIndex = 100093;
            this.txt_NGOverrunNum.Text = "5";
            this.txt_NGOverrunNum.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_NGOverrunNum.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_NGOverrunNum.Watermark = "";
            this.txt_NGOverrunNum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_NGOverrunNum.TextChanged += new System.EventHandler(this.txt_NGOverrunNum_TextChanged);
            // 
            // txt_UploadTime
            // 
            this.txt_UploadTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_UploadTime.DoubleValue = 5D;
            this.txt_UploadTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_UploadTime.IntValue = 5;
            this.txt_UploadTime.Location = new System.Drawing.Point(193, 153);
            this.txt_UploadTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_UploadTime.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_UploadTime.Name = "txt_UploadTime";
            this.txt_UploadTime.ShowText = false;
            this.txt_UploadTime.Size = new System.Drawing.Size(169, 29);
            this.txt_UploadTime.Style = Sunny.UI.UIStyle.Custom;
            this.txt_UploadTime.TabIndex = 100093;
            this.txt_UploadTime.Text = "5";
            this.txt_UploadTime.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_UploadTime.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_UploadTime.Watermark = "";
            this.txt_UploadTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_UploadTime.TextChanged += new System.EventHandler(this.txt_UploadTime_TextChanged);
            // 
            // uiRadioButton2
            // 
            this.uiRadioButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiRadioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButton2.Location = new System.Drawing.Point(193, 100);
            this.uiRadioButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton2.Name = "uiRadioButton2";
            this.uiRadioButton2.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiRadioButton2.Size = new System.Drawing.Size(169, 29);
            this.uiRadioButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButton2.TabIndex = 100092;
            this.uiRadioButton2.Text = "补传当天NG";
            this.uiRadioButton2.Visible = false;
            this.uiRadioButton2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rad_UploadTime
            // 
            this.rad_UploadTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.rad_UploadTime.Checked = true;
            this.rad_UploadTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rad_UploadTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rad_UploadTime.Location = new System.Drawing.Point(11, 100);
            this.rad_UploadTime.MinimumSize = new System.Drawing.Size(1, 1);
            this.rad_UploadTime.Name = "rad_UploadTime";
            this.rad_UploadTime.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rad_UploadTime.Size = new System.Drawing.Size(169, 29);
            this.rad_UploadTime.Style = Sunny.UI.UIStyle.Custom;
            this.rad_UploadTime.TabIndex = 100092;
            this.rad_UploadTime.Text = "补传该时段NG";
            this.rad_UploadTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(13, 205);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(196, 32);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 100090;
            this.uiLabel6.Text = "NG超限数量（个）";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(11, 151);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(196, 32);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 100090;
            this.uiLabel5.Text = "间隔上传时间 (分)";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tm_Upload
            // 
            this.tm_Upload.Enabled = true;
            this.tm_Upload.Interval = 1000;
            this.tm_Upload.Tick += new System.EventHandler(this.tm_Upload_Tick);
            // 
            // ckb_StartTaskCheckout
            // 
            this.ckb_StartTaskCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_StartTaskCheckout.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_StartTaskCheckout.Location = new System.Drawing.Point(13, 158);
            this.ckb_StartTaskCheckout.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_StartTaskCheckout.Name = "ckb_StartTaskCheckout";
            this.ckb_StartTaskCheckout.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_StartTaskCheckout.Size = new System.Drawing.Size(262, 29);
            this.ckb_StartTaskCheckout.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_StartTaskCheckout.TabIndex = 100091;
            this.ckb_StartTaskCheckout.Text = "流程启动增加上位机校验";
            this.ckb_StartTaskCheckout.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_StartTaskCheckout.Click += new System.EventHandler(this.ckb_StartTaskCheckout_Click);
            // 
            // Frm_Infomation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(403, 540);
            this.Controls.Add(this.ckb_StartTaskCheckout);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.btn_browseHistory);
            this.Controls.Add(this.btn_clearCount);
            this.Controls.Add(this.lbl_ngNum);
            this.Controls.Add(this.lbl_okNum);
            this.Controls.Add(this.lbl_yield);
            this.Controls.Add(this.lbl_totalNum);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiLine6);
            this.KeyPreview = true;
            this.Name = "Frm_Infomation";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "Frm_Vision";
            this.Load += new System.EventHandler(this.Frm_Infomation_Load);
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILine uiLine6;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        internal System.Windows.Forms.Button btn_clearCount;
        internal Sunny.UI.UILabel lbl_ngNum;
        internal Sunny.UI.UILabel lbl_okNum;
        internal Sunny.UI.UILabel lbl_yield;
        internal Sunny.UI.UILabel lbl_totalNum;
        internal System.Windows.Forms.Button btn_browseHistory;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIRadioButton uiRadioButton2;
        private Sunny.UI.UILabel uiLabel6;
        internal Sunny.UI.UICheckBox ckb_StartUpload;
        internal Sunny.UI.UITextBox txt_UploadTime;
        internal Sunny.UI.UIRadioButton rad_UploadTime;
        internal Sunny.UI.UITextBox txt_NGOverrunNum;
        internal System.Windows.Forms.Timer tm_Upload;
        private Sunny.UI.UICheckBox ckb_StartTaskCheckout;
    }
}