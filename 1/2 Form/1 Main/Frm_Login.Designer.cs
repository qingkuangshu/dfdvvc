namespace VM_Pro
{
    partial class Frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.btn_logout = new Sunny.UI.UIButton();
            this.btn_login = new Sunny.UI.UIButton();
            this.uiLine5 = new Sunny.UI.UILine();
            this.cbx_userName = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.lbl_password = new Sunny.UI.UILabel();
            this.tbx_password = new Sunny.UI.UITextBox();
            this.lbl_companyName = new Sunny.UI.UILabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbx_newPassword = new Sunny.UI.UITextBox();
            this.lbl_passwordAgain = new Sunny.UI.UILabel();
            this.lnk_switchLoginOrModify = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_logout
            // 
            this.btn_logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_logout.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_logout.Location = new System.Drawing.Point(245, 168);
            this.btn_logout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_logout.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(68, 30);
            this.btn_logout.Style = Sunny.UI.UIStyle.Custom;
            this.btn_logout.TabIndex = 126;
            this.btn_logout.Text = "注销";
            this.btn_logout.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_logout.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_login
            // 
            this.btn_login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_login.Location = new System.Drawing.Point(327, 168);
            this.btn_login.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_login.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(68, 30);
            this.btn_login.Style = Sunny.UI.UIStyle.Custom;
            this.btn_login.TabIndex = 125;
            this.btn_login.Text = "登录";
            this.btn_login.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_login.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // uiLine5
            // 
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine5.Location = new System.Drawing.Point(12, 221);
            this.uiLine5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine5.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(398, 5);
            this.uiLine5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine5.TabIndex = 128;
            this.uiLine5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbx_userName
            // 
            this.cbx_userName.DataSource = null;
            this.cbx_userName.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_userName.FillColor = System.Drawing.Color.White;
            this.cbx_userName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_userName.Items.AddRange(new object[] {
            " 开发人员",
            " 管理员"});
            this.cbx_userName.Location = new System.Drawing.Point(245, 69);
            this.cbx_userName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_userName.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_userName.Name = "cbx_userName";
            this.cbx_userName.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_userName.Radius = 0;
            this.cbx_userName.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_userName.Size = new System.Drawing.Size(150, 29);
            this.cbx_userName.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_userName.TabIndex = 129;
            this.cbx_userName.Text = " 管理员";
            this.cbx_userName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_userName.Watermark = "";
            this.cbx_userName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_userName.SelectedIndexChanged += new System.EventHandler(this.cbx_userName_SelectedIndexChanged);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(172, 71);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(79, 20);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 130;
            this.uiLabel1.Text = "用       户：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_password.Location = new System.Drawing.Point(172, 104);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(79, 20);
            this.lbl_password.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_password.TabIndex = 132;
            this.lbl_password.Text = "密       码：";
            this.lbl_password.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_password.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tbx_password
            // 
            this.tbx_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_password.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_password.Location = new System.Drawing.Point(245, 102);
            this.tbx_password.Margin = new System.Windows.Forms.Padding(3, 5, 4, 5);
            this.tbx_password.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.Padding = new System.Windows.Forms.Padding(7, 5, 5, 5);
            this.tbx_password.PasswordChar = '*';
            this.tbx_password.Radius = 0;
            this.tbx_password.ShowText = false;
            this.tbx_password.Size = new System.Drawing.Size(150, 29);
            this.tbx_password.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_password.TabIndex = 133;
            this.tbx_password.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_password.Watermark = "请输入密码";
            this.tbx_password.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_companyName
            // 
            this.lbl_companyName.AutoSize = true;
            this.lbl_companyName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_companyName.Location = new System.Drawing.Point(22, 227);
            this.lbl_companyName.Name = "lbl_companyName";
            this.lbl_companyName.Size = new System.Drawing.Size(107, 20);
            this.lbl_companyName.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_companyName.TabIndex = 134;
            this.lbl_companyName.Text = "小太阳智能科技";
            this.lbl_companyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_companyName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 135;
            this.pictureBox1.TabStop = false;
            // 
            // tbx_newPassword
            // 
            this.tbx_newPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_newPassword.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_newPassword.Location = new System.Drawing.Point(245, 135);
            this.tbx_newPassword.Margin = new System.Windows.Forms.Padding(3, 5, 4, 5);
            this.tbx_newPassword.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_newPassword.Name = "tbx_newPassword";
            this.tbx_newPassword.Padding = new System.Windows.Forms.Padding(7, 5, 5, 5);
            this.tbx_newPassword.PasswordChar = '*';
            this.tbx_newPassword.Radius = 0;
            this.tbx_newPassword.ShowText = false;
            this.tbx_newPassword.Size = new System.Drawing.Size(150, 29);
            this.tbx_newPassword.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_newPassword.TabIndex = 137;
            this.tbx_newPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_newPassword.Visible = false;
            this.tbx_newPassword.Watermark = "请输入新密码";
            this.tbx_newPassword.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_passwordAgain
            // 
            this.lbl_passwordAgain.AutoSize = true;
            this.lbl_passwordAgain.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_passwordAgain.Location = new System.Drawing.Point(172, 137);
            this.lbl_passwordAgain.Name = "lbl_passwordAgain";
            this.lbl_passwordAgain.Size = new System.Drawing.Size(70, 20);
            this.lbl_passwordAgain.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_passwordAgain.TabIndex = 136;
            this.lbl_passwordAgain.Text = "新  密 码 :";
            this.lbl_passwordAgain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_passwordAgain.Visible = false;
            this.lbl_passwordAgain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lnk_switchLoginOrModify
            // 
            this.lnk_switchLoginOrModify.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.lnk_switchLoginOrModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk_switchLoginOrModify.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.lnk_switchLoginOrModify.Location = new System.Drawing.Point(317, 227);
            this.lnk_switchLoginOrModify.Name = "lnk_switchLoginOrModify";
            this.lnk_switchLoginOrModify.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lnk_switchLoginOrModify.Size = new System.Drawing.Size(93, 20);
            this.lnk_switchLoginOrModify.TabIndex = 1399;
            this.lnk_switchLoginOrModify.TabStop = true;
            this.lnk_switchLoginOrModify.Text = "点击修改密码";
            this.lnk_switchLoginOrModify.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_switchLoginOrModify_LinkClicked);
            // 
            // Frm_Login
            // 
            this.AcceptButton = this.btn_login;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(422, 262);
            this.Controls.Add(this.tbx_newPassword);
            this.Controls.Add(this.lnk_switchLoginOrModify);
            this.Controls.Add(this.lbl_passwordAgain);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbx_password);
            this.Controls.Add(this.cbx_userName);
            this.Controls.Add(this.lbl_companyName);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiLine5);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_login);
            this.ExtendSymbolSize = 20;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.MinimizeBox = false;
            this.Name = "Frm_Login";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowInTaskbar = false;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "登录";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.TopMost = true;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 422, 262);
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Sunny.UI.UIButton btn_logout;
        internal Sunny.UI.UIButton btn_login;
        private Sunny.UI.UILine uiLine5;
        private Sunny.UI.UIComboBox cbx_userName;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel lbl_password;
        private Sunny.UI.UITextBox tbx_password;
        private Sunny.UI.UILabel lbl_companyName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UITextBox tbx_newPassword;
        private Sunny.UI.UILabel lbl_passwordAgain;
        private System.Windows.Forms.LinkLabel lnk_switchLoginOrModify;
    }
}