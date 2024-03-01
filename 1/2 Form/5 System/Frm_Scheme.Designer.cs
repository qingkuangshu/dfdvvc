namespace VM_Pro
{
    partial class Frm_Scheme
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
            this.btn_copyScheme = new Sunny.UI.UIButton();
            this.btn_createScheme = new Sunny.UI.UIButton();
            this.btn_exportScheme = new Sunny.UI.UIButton();
            this.btn_inportScheme = new Sunny.UI.UIButton();
            this.btn_deleteScheme = new Sunny.UI.UIButton();
            this.tvw_schemeList = new Sunny.UI.UINavMenu();
            this.btn_moveDownScheme = new Sunny.UI.UIButton();
            this.btn_moveUpScheme = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.lbl_passwordAgain = new Sunny.UI.UILabel();
            this.tbx_schemeName = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // btn_copyScheme
            // 
            this.btn_copyScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_copyScheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_copyScheme.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_copyScheme.Location = new System.Drawing.Point(236, 42);
            this.btn_copyScheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_copyScheme.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_copyScheme.Name = "btn_copyScheme";
            this.btn_copyScheme.Size = new System.Drawing.Size(64, 30);
            this.btn_copyScheme.TabIndex = 155;
            this.btn_copyScheme.Text = "复制";
            this.btn_copyScheme.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_copyScheme.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_copyScheme.Click += new System.EventHandler(this.btn_copyScheme_Click);
            // 
            // btn_createScheme
            // 
            this.btn_createScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_createScheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_createScheme.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_createScheme.Location = new System.Drawing.Point(236, 80);
            this.btn_createScheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_createScheme.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_createScheme.Name = "btn_createScheme";
            this.btn_createScheme.Size = new System.Drawing.Size(64, 30);
            this.btn_createScheme.TabIndex = 154;
            this.btn_createScheme.Text = "新建";
            this.btn_createScheme.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_createScheme.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_createScheme.Click += new System.EventHandler(this.btn_createScheme_Click);
            // 
            // btn_exportScheme
            // 
            this.btn_exportScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exportScheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exportScheme.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_exportScheme.Location = new System.Drawing.Point(236, 156);
            this.btn_exportScheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_exportScheme.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_exportScheme.Name = "btn_exportScheme";
            this.btn_exportScheme.Size = new System.Drawing.Size(64, 30);
            this.btn_exportScheme.TabIndex = 157;
            this.btn_exportScheme.Text = "导出";
            this.btn_exportScheme.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_exportScheme.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_exportScheme.Click += new System.EventHandler(this.btn_exportScheme_Click);
            // 
            // btn_inportScheme
            // 
            this.btn_inportScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_inportScheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_inportScheme.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_inportScheme.Location = new System.Drawing.Point(236, 118);
            this.btn_inportScheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_inportScheme.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_inportScheme.Name = "btn_inportScheme";
            this.btn_inportScheme.Size = new System.Drawing.Size(64, 30);
            this.btn_inportScheme.TabIndex = 156;
            this.btn_inportScheme.Text = "导入";
            this.btn_inportScheme.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_inportScheme.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_inportScheme.Click += new System.EventHandler(this.btn_inportScheme_Click);
            // 
            // btn_deleteScheme
            // 
            this.btn_deleteScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deleteScheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_deleteScheme.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_deleteScheme.Location = new System.Drawing.Point(236, 194);
            this.btn_deleteScheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_deleteScheme.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_deleteScheme.Name = "btn_deleteScheme";
            this.btn_deleteScheme.Size = new System.Drawing.Size(64, 30);
            this.btn_deleteScheme.TabIndex = 158;
            this.btn_deleteScheme.Text = "删除";
            this.btn_deleteScheme.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_deleteScheme.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_deleteScheme.Click += new System.EventHandler(this.btn_deleteScheme_Click);
            // 
            // tvw_schemeList
            // 
            this.tvw_schemeList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_schemeList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvw_schemeList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvw_schemeList.ExpandSelectFirst = false;
            this.tvw_schemeList.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_schemeList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvw_schemeList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tvw_schemeList.FullRowSelect = true;
            this.tvw_schemeList.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tvw_schemeList.Indent = 26;
            this.tvw_schemeList.ItemHeight = 34;
            this.tvw_schemeList.Location = new System.Drawing.Point(9, 42);
            this.tvw_schemeList.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.tvw_schemeList.Name = "tvw_schemeList";
            this.tvw_schemeList.Scrollable = false;
            this.tvw_schemeList.SecondBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tvw_schemeList.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tvw_schemeList.ShowLines = false;
            this.tvw_schemeList.ShowNodeToolTips = true;
            this.tvw_schemeList.ShowOneNode = true;
            this.tvw_schemeList.Size = new System.Drawing.Size(174, 546);
            this.tvw_schemeList.Style = Sunny.UI.UIStyle.Custom;
            this.tvw_schemeList.TabIndex = 173;
            this.tvw_schemeList.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvw_schemeList.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tvw_schemeList.Click += new System.EventHandler(this.tvw_schemeList_Click);
            // 
            // btn_moveDownScheme
            // 
            this.btn_moveDownScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_moveDownScheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_moveDownScheme.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_moveDownScheme.Location = new System.Drawing.Point(236, 270);
            this.btn_moveDownScheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_moveDownScheme.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_moveDownScheme.Name = "btn_moveDownScheme";
            this.btn_moveDownScheme.Size = new System.Drawing.Size(64, 30);
            this.btn_moveDownScheme.TabIndex = 179;
            this.btn_moveDownScheme.Text = "下移";
            this.btn_moveDownScheme.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_moveDownScheme.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_moveDownScheme.Click += new System.EventHandler(this.btn_moveDownScheme_Click);
            // 
            // btn_moveUpScheme
            // 
            this.btn_moveUpScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_moveUpScheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_moveUpScheme.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_moveUpScheme.Location = new System.Drawing.Point(236, 232);
            this.btn_moveUpScheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_moveUpScheme.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_moveUpScheme.Name = "btn_moveUpScheme";
            this.btn_moveUpScheme.Size = new System.Drawing.Size(64, 30);
            this.btn_moveUpScheme.TabIndex = 178;
            this.btn_moveUpScheme.Text = "上移";
            this.btn_moveUpScheme.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_moveUpScheme.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_moveUpScheme.Click += new System.EventHandler(this.btn_moveUpScheme_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(15, 14);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(65, 20);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 180;
            this.uiLabel1.Text = "方案列表";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_passwordAgain
            // 
            this.lbl_passwordAgain.AutoSize = true;
            this.lbl_passwordAgain.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_passwordAgain.Location = new System.Drawing.Point(307, 42);
            this.lbl_passwordAgain.Name = "lbl_passwordAgain";
            this.lbl_passwordAgain.Size = new System.Drawing.Size(72, 20);
            this.lbl_passwordAgain.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_passwordAgain.TabIndex = 174;
            this.lbl_passwordAgain.Text = "方案名称 :";
            this.lbl_passwordAgain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_passwordAgain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tbx_schemeName
            // 
            this.tbx_schemeName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_schemeName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_schemeName.Location = new System.Drawing.Point(382, 37);
            this.tbx_schemeName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_schemeName.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_schemeName.Name = "tbx_schemeName";
            this.tbx_schemeName.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_schemeName.Radius = 0;
            this.tbx_schemeName.RectColor = System.Drawing.Color.White;
            this.tbx_schemeName.RectSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbx_schemeName.ShowText = false;
            this.tbx_schemeName.Size = new System.Drawing.Size(235, 29);
            this.tbx_schemeName.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_schemeName.TabIndex = 176;
            this.tbx_schemeName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_schemeName.Watermark = "请输入方案名称";
            this.tbx_schemeName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tbx_schemeName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_schemeName_KeyPress);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.Green;
            this.uiLabel2.Location = new System.Drawing.Point(626, 42);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(163, 20);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 181;
            this.uiLabel2.Text = "注：修改名称后回车生效";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Frm_Scheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(842, 601);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.btn_moveDownScheme);
            this.Controls.Add(this.btn_moveUpScheme);
            this.Controls.Add(this.tbx_schemeName);
            this.Controls.Add(this.lbl_passwordAgain);
            this.Controls.Add(this.tvw_schemeList);
            this.Controls.Add(this.btn_deleteScheme);
            this.Controls.Add(this.btn_exportScheme);
            this.Controls.Add(this.btn_inportScheme);
            this.Controls.Add(this.btn_copyScheme);
            this.Controls.Add(this.btn_createScheme);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_Scheme";
            this.Text = "Frm_Project";
            this.Load += new System.EventHandler(this.Frm_Project_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Sunny.UI.UIButton btn_copyScheme;
        internal Sunny.UI.UIButton btn_createScheme;
        internal Sunny.UI.UIButton btn_exportScheme;
        internal Sunny.UI.UIButton btn_inportScheme;
        internal Sunny.UI.UIButton btn_deleteScheme;
        internal Sunny.UI.UINavMenu tvw_schemeList;
        internal Sunny.UI.UIButton btn_moveDownScheme;
        internal Sunny.UI.UIButton btn_moveUpScheme;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel lbl_passwordAgain;
        private Sunny.UI.UILabel uiLabel2;
        internal Sunny.UI.UITextBox tbx_schemeName;
    }
}