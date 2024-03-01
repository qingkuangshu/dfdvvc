namespace VM_Pro
{
    partial class Frm_FTPDownload
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
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.txt_UserName = new Sunny.UI.UITextBox();
            this.txt_Password = new Sunny.UI.UITextBox();
            this.txt_Address = new Sunny.UI.UITextBox();
            this.txt_FatherPath = new Sunny.UI.UITextBox();
            this.btn_StartCheck = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.txt_LocalPath = new Sunny.UI.UITextBox();
            this.ckb_PathAddDate = new Sunny.UI.UICheckBox();
            this.cmb_dateTimeFormat = new Sunny.UI.UIComboBox();
            this.ckb_ImgDownloadRunTask = new Sunny.UI.UICheckBox();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(48, 33);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "账号：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(48, 73);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 0;
            this.uiLabel2.Text = "密码：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(30, 107);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(118, 34);
            this.uiLabel3.TabIndex = 0;
            this.uiLabel3.Text = "FTP地址：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(13, 155);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(139, 34);
            this.uiLabel4.TabIndex = 0;
            this.uiLabel4.Text = "监测父路径：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_UserName
            // 
            this.txt_UserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_UserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_UserName.Location = new System.Drawing.Point(143, 33);
            this.txt_UserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_UserName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.ShowText = false;
            this.txt_UserName.Size = new System.Drawing.Size(215, 29);
            this.txt_UserName.TabIndex = 1;
            this.txt_UserName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_UserName.Watermark = "";
            this.txt_UserName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_UserName.TextChanged += new System.EventHandler(this.txt_UserName_TextChanged);
            this.txt_UserName.DoEnter += new System.EventHandler(this.txt_FatherPath_DoEnter);
            // 
            // txt_Password
            // 
            this.txt_Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Password.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Password.Location = new System.Drawing.Point(143, 73);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Password.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.ShowText = false;
            this.txt_Password.Size = new System.Drawing.Size(215, 29);
            this.txt_Password.TabIndex = 1;
            this.txt_Password.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Password.Watermark = "";
            this.txt_Password.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_Password.TextChanged += new System.EventHandler(this.txt_Password_TextChanged);
            this.txt_Password.DoEnter += new System.EventHandler(this.txt_FatherPath_DoEnter);
            // 
            // txt_Address
            // 
            this.txt_Address.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Address.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Address.Location = new System.Drawing.Point(143, 112);
            this.txt_Address.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Address.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.ShowText = false;
            this.txt_Address.Size = new System.Drawing.Size(215, 29);
            this.txt_Address.TabIndex = 1;
            this.txt_Address.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Address.Watermark = "";
            this.txt_Address.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_Address.DoEnter += new System.EventHandler(this.txt_FatherPath_DoEnter);
            // 
            // txt_FatherPath
            // 
            this.txt_FatherPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_FatherPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_FatherPath.Location = new System.Drawing.Point(143, 160);
            this.txt_FatherPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_FatherPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_FatherPath.Name = "txt_FatherPath";
            this.txt_FatherPath.ShowText = false;
            this.txt_FatherPath.Size = new System.Drawing.Size(215, 29);
            this.txt_FatherPath.TabIndex = 1;
            this.txt_FatherPath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_FatherPath.Watermark = "";
            this.txt_FatherPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_FatherPath.DoEnter += new System.EventHandler(this.txt_FatherPath_DoEnter);
            // 
            // btn_StartCheck
            // 
            this.btn_StartCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_StartCheck.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_StartCheck.Location = new System.Drawing.Point(213, 263);
            this.btn_StartCheck.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_StartCheck.Name = "btn_StartCheck";
            this.btn_StartCheck.Size = new System.Drawing.Size(145, 35);
            this.btn_StartCheck.TabIndex = 2;
            this.btn_StartCheck.Text = "开始监测";
            this.btn_StartCheck.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_StartCheck.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_StartCheck.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(-1, 205);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(153, 32);
            this.uiLabel5.TabIndex = 3;
            this.uiLabel5.Text = "本地存储路径：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_LocalPath
            // 
            this.txt_LocalPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_LocalPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_LocalPath.Location = new System.Drawing.Point(143, 207);
            this.txt_LocalPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_LocalPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_LocalPath.Name = "txt_LocalPath";
            this.txt_LocalPath.ReadOnly = true;
            this.txt_LocalPath.ShowText = false;
            this.txt_LocalPath.Size = new System.Drawing.Size(215, 29);
            this.txt_LocalPath.TabIndex = 4;
            this.txt_LocalPath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_LocalPath.Watermark = "";
            this.txt_LocalPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_LocalPath.DoubleClick += new System.EventHandler(this.txt_LocalPath_DoubleClick);
            // 
            // ckb_PathAddDate
            // 
            this.ckb_PathAddDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_PathAddDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_PathAddDate.Location = new System.Drawing.Point(365, 160);
            this.ckb_PathAddDate.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_PathAddDate.Name = "ckb_PathAddDate";
            this.ckb_PathAddDate.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_PathAddDate.Size = new System.Drawing.Size(95, 29);
            this.ckb_PathAddDate.TabIndex = 5;
            this.ckb_PathAddDate.Text = "加日期";
            this.ckb_PathAddDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_PathAddDate.Click += new System.EventHandler(this.ckb_PathAddDate_Click);
            // 
            // cmb_dateTimeFormat
            // 
            this.cmb_dateTimeFormat.DataSource = null;
            this.cmb_dateTimeFormat.FillColor = System.Drawing.Color.White;
            this.cmb_dateTimeFormat.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_dateTimeFormat.Items.AddRange(new object[] {
            "yyyyMMdd",
            "yyyy MM dd",
            "yyyy-MM-dd"});
            this.cmb_dateTimeFormat.Location = new System.Drawing.Point(463, 160);
            this.cmb_dateTimeFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_dateTimeFormat.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_dateTimeFormat.Name = "cmb_dateTimeFormat";
            this.cmb_dateTimeFormat.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_dateTimeFormat.Size = new System.Drawing.Size(180, 29);
            this.cmb_dateTimeFormat.TabIndex = 6;
            this.cmb_dateTimeFormat.Text = "yyyyMMdd";
            this.cmb_dateTimeFormat.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cmb_dateTimeFormat.Visible = false;
            this.cmb_dateTimeFormat.Watermark = "";
            this.cmb_dateTimeFormat.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cmb_dateTimeFormat.SelectedIndexChanged += new System.EventHandler(this.cmb_dateTimeFormat_SelectedIndexChanged);
            this.cmb_dateTimeFormat.DoEnter += new System.EventHandler(this.cmb_dateTimeFormat_SelectedIndexChanged);
            // 
            // ckb_ImgDownloadRunTask
            // 
            this.ckb_ImgDownloadRunTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_ImgDownloadRunTask.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_ImgDownloadRunTask.Location = new System.Drawing.Point(365, 33);
            this.ckb_ImgDownloadRunTask.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_ImgDownloadRunTask.Name = "ckb_ImgDownloadRunTask";
            this.ckb_ImgDownloadRunTask.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_ImgDownloadRunTask.Size = new System.Drawing.Size(295, 29);
            this.ckb_ImgDownloadRunTask.TabIndex = 7;
            this.ckb_ImgDownloadRunTask.Text = "图像下载后自动执行流程检测";
            this.ckb_ImgDownloadRunTask.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_ImgDownloadRunTask.Click += new System.EventHandler(this.ckb_ImgDownloadRunTask_Click);
            // 
            // Frm_FTPDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(656, 549);
            this.Controls.Add(this.ckb_ImgDownloadRunTask);
            this.Controls.Add(this.cmb_dateTimeFormat);
            this.Controls.Add(this.ckb_PathAddDate);
            this.Controls.Add(this.txt_LocalPath);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.btn_StartCheck);
            this.Controls.Add(this.txt_FatherPath);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_FTPDownload";
            this.Text = "Frm_FTPDownload";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txt_UserName;
        private Sunny.UI.UITextBox txt_Password;
        private Sunny.UI.UITextBox txt_Address;
        private Sunny.UI.UITextBox txt_FatherPath;
        private Sunny.UI.UIButton btn_StartCheck;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txt_LocalPath;
        private Sunny.UI.UICheckBox ckb_PathAddDate;
        private Sunny.UI.UIComboBox cmb_dateTimeFormat;
        private Sunny.UI.UICheckBox ckb_ImgDownloadRunTask;
    }
}