namespace VM_Pro
{
    partial class Frm_Service
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Service));
            this.tvw_serviceList = new Sunny.UI.UINavMenu();
            this.uiContextMenuStrip2 = new Sunny.UI.UIContextMenuStrip();
            this.启用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.运动控制卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相机标定toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPIP服务端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPIP客户端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口通讯ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.扫码枪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLC通讯ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.光源控制器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.位移传感器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.压力床干起ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fTP下载服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_add = new Sunny.UI.UISymbolButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.pnl_seviceBox = new System.Windows.Forms.Panel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.lbl_connectStatu = new Sunny.UI.UILabel();
            this.uiLine9 = new Sunny.UI.UILine();
            this.uiContextMenuStrip2.SuspendLayout();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvw_serviceList
            // 
            this.tvw_serviceList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_serviceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvw_serviceList.ContextMenuStrip = this.uiContextMenuStrip2;
            this.tvw_serviceList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvw_serviceList.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_serviceList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvw_serviceList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tvw_serviceList.FullRowSelect = true;
            this.tvw_serviceList.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tvw_serviceList.ImageIndex = 0;
            this.tvw_serviceList.ImageList = this.imageList1;
            this.tvw_serviceList.Indent = 26;
            this.tvw_serviceList.ItemHeight = 34;
            this.tvw_serviceList.Location = new System.Drawing.Point(9, 45);
            this.tvw_serviceList.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.tvw_serviceList.Name = "tvw_serviceList";
            this.tvw_serviceList.Scrollable = false;
            this.tvw_serviceList.SecondBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tvw_serviceList.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tvw_serviceList.SelectedImageIndex = 0;
            this.tvw_serviceList.ShowLines = false;
            this.tvw_serviceList.ShowNodeToolTips = true;
            this.tvw_serviceList.ShowTips = true;
            this.tvw_serviceList.Size = new System.Drawing.Size(195, 544);
            this.tvw_serviceList.Style = Sunny.UI.UIStyle.Custom;
            this.tvw_serviceList.TabIndex = 23;
            this.tvw_serviceList.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvw_serviceList.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tvw_serviceList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvw_serviceList_AfterSelect);
            // 
            // uiContextMenuStrip2
            // 
            this.uiContextMenuStrip2.AutoSize = false;
            this.uiContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip2.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启用ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.上移ToolStripMenuItem,
            this.下移ToolStripMenuItem,
            this.重命名ToolStripMenuItem});
            this.uiContextMenuStrip2.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip2.Size = new System.Drawing.Size(153, 144);
            this.uiContextMenuStrip2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiContextMenuStrip2.Paint += new System.Windows.Forms.PaintEventHandler(this.uiContextMenuStrip2_Paint);
            // 
            // 启用ToolStripMenuItem
            // 
            this.启用ToolStripMenuItem.AutoSize = false;
            this.启用ToolStripMenuItem.Name = "启用ToolStripMenuItem";
            this.启用ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.启用ToolStripMenuItem.Text = "启用";
            this.启用ToolStripMenuItem.Click += new System.EventHandler(this.启用ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.AutoSize = false;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 上移ToolStripMenuItem
            // 
            this.上移ToolStripMenuItem.AutoSize = false;
            this.上移ToolStripMenuItem.Name = "上移ToolStripMenuItem";
            this.上移ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.上移ToolStripMenuItem.Text = "上移";
            this.上移ToolStripMenuItem.Click += new System.EventHandler(this.上移ToolStripMenuItem_Click);
            // 
            // 下移ToolStripMenuItem
            // 
            this.下移ToolStripMenuItem.AutoSize = false;
            this.下移ToolStripMenuItem.Name = "下移ToolStripMenuItem";
            this.下移ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.下移ToolStripMenuItem.Text = "下移";
            this.下移ToolStripMenuItem.Click += new System.EventHandler(this.下移ToolStripMenuItem_Click);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.AutoSize = false;
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "镜头.png");
            this.imageList1.Images.SetKeyName(1, "物理网卡.png");
            this.imageList1.Images.SetKeyName(2, "阵列.png");
            this.imageList1.Images.SetKeyName(3, "服务器.png");
            this.imageList1.Images.SetKeyName(4, "客户端工具.png");
            this.imageList1.Images.SetKeyName(5, "WangLele串口.png");
            this.imageList1.Images.SetKeyName(6, "风机控制箱（对应表里的控制柜）.png");
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.运动控制卡ToolStripMenuItem,
            this.相机ToolStripMenuItem,
            this.相机标定toolStripMenuItem,
            this.tCPIP服务端ToolStripMenuItem,
            this.tCPIP客户端ToolStripMenuItem,
            this.串口通讯ToolStripMenuItem,
            this.扫码枪ToolStripMenuItem,
            this.pLC通讯ToolStripMenuItem,
            this.光源控制器ToolStripMenuItem,
            this.位移传感器ToolStripMenuItem,
            this.压力床干起ToolStripMenuItem,
            this.fTP下载服务ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(195, 340);
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // 运动控制卡ToolStripMenuItem
            // 
            this.运动控制卡ToolStripMenuItem.AutoSize = false;
            this.运动控制卡ToolStripMenuItem.Name = "运动控制卡ToolStripMenuItem";
            this.运动控制卡ToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.运动控制卡ToolStripMenuItem.Text = "运动控制卡";
            this.运动控制卡ToolStripMenuItem.Click += new System.EventHandler(this.运动控制卡ToolStripMenuItem_Click);
            // 
            // 相机ToolStripMenuItem
            // 
            this.相机ToolStripMenuItem.AutoSize = false;
            this.相机ToolStripMenuItem.Name = "相机ToolStripMenuItem";
            this.相机ToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.相机ToolStripMenuItem.Text = "相机";
            this.相机ToolStripMenuItem.Click += new System.EventHandler(this.相机ToolStripMenuItem_Click);
            // 
            // 相机标定toolStripMenuItem
            // 
            this.相机标定toolStripMenuItem.AutoSize = false;
            this.相机标定toolStripMenuItem.Name = "相机标定toolStripMenuItem";
            this.相机标定toolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.相机标定toolStripMenuItem.Text = "相机标定";
            this.相机标定toolStripMenuItem.Click += new System.EventHandler(this.相机标定toolStripMenuItem_Click);
            // 
            // tCPIP服务端ToolStripMenuItem
            // 
            this.tCPIP服务端ToolStripMenuItem.AutoSize = false;
            this.tCPIP服务端ToolStripMenuItem.Name = "tCPIP服务端ToolStripMenuItem";
            this.tCPIP服务端ToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.tCPIP服务端ToolStripMenuItem.Text = "TCP/IP 服务端";
            this.tCPIP服务端ToolStripMenuItem.Click += new System.EventHandler(this.tCPIP服务端ToolStripMenuItem_Click);
            // 
            // tCPIP客户端ToolStripMenuItem
            // 
            this.tCPIP客户端ToolStripMenuItem.AutoSize = false;
            this.tCPIP客户端ToolStripMenuItem.Name = "tCPIP客户端ToolStripMenuItem";
            this.tCPIP客户端ToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.tCPIP客户端ToolStripMenuItem.Text = "TCP/IP 客户端";
            this.tCPIP客户端ToolStripMenuItem.Click += new System.EventHandler(this.tCPIP客户端ToolStripMenuItem_Click);
            // 
            // 串口通讯ToolStripMenuItem
            // 
            this.串口通讯ToolStripMenuItem.AutoSize = false;
            this.串口通讯ToolStripMenuItem.Name = "串口通讯ToolStripMenuItem";
            this.串口通讯ToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.串口通讯ToolStripMenuItem.Text = "串口通讯";
            this.串口通讯ToolStripMenuItem.Click += new System.EventHandler(this.串口通讯ToolStripMenuItem_Click);
            // 
            // 扫码枪ToolStripMenuItem
            // 
            this.扫码枪ToolStripMenuItem.AutoSize = false;
            this.扫码枪ToolStripMenuItem.Name = "扫码枪ToolStripMenuItem";
            this.扫码枪ToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.扫码枪ToolStripMenuItem.Text = "扫码枪";
            // 
            // pLC通讯ToolStripMenuItem
            // 
            this.pLC通讯ToolStripMenuItem.AutoSize = false;
            this.pLC通讯ToolStripMenuItem.Name = "pLC通讯ToolStripMenuItem";
            this.pLC通讯ToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.pLC通讯ToolStripMenuItem.Text = "PLC 通讯";
            // 
            // 光源控制器ToolStripMenuItem
            // 
            this.光源控制器ToolStripMenuItem.AutoSize = false;
            this.光源控制器ToolStripMenuItem.Name = "光源控制器ToolStripMenuItem";
            this.光源控制器ToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.光源控制器ToolStripMenuItem.Text = "光源控制器";
            this.光源控制器ToolStripMenuItem.Click += new System.EventHandler(this.光源控制器ToolStripMenuItem_Click);
            // 
            // 位移传感器ToolStripMenuItem
            // 
            this.位移传感器ToolStripMenuItem.AutoSize = false;
            this.位移传感器ToolStripMenuItem.Name = "位移传感器ToolStripMenuItem";
            this.位移传感器ToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.位移传感器ToolStripMenuItem.Text = "位移传感器";
            // 
            // 压力床干起ToolStripMenuItem
            // 
            this.压力床干起ToolStripMenuItem.AutoSize = false;
            this.压力床干起ToolStripMenuItem.Name = "压力床干起ToolStripMenuItem";
            this.压力床干起ToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.压力床干起ToolStripMenuItem.Text = "压力传感器";
            // 
            // fTP下载服务ToolStripMenuItem
            // 
            this.fTP下载服务ToolStripMenuItem.Name = "fTP下载服务ToolStripMenuItem";
            this.fTP下载服务ToolStripMenuItem.Size = new System.Drawing.Size(194, 28);
            this.fTP下载服务ToolStripMenuItem.Text = "FTP下载服务";
            this.fTP下载服务ToolStripMenuItem.Click += new System.EventHandler(this.fTP下载服务ToolStripMenuItem_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btn_add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_add.BackgroundImage")));
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.FillColor = System.Drawing.Color.Transparent;
            this.btn_add.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_add.Location = new System.Drawing.Point(102, 543);
            this.btn_add.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_add.Name = "btn_add";
            this.btn_add.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.btn_add.RectColor = System.Drawing.Color.Transparent;
            this.btn_add.Size = new System.Drawing.Size(35, 35);
            this.btn_add.Style = Sunny.UI.UIStyle.Custom;
            this.btn_add.Symbol = 0;
            this.btn_add.SymbolSize = 42;
            this.btn_add.TabIndex = 174;
            this.btn_add.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_add.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(15, 14);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(82, 24);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 181;
            this.uiLabel1.Text = "服务列表";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnl_seviceBox
            // 
            this.pnl_seviceBox.Location = new System.Drawing.Point(200, 45);
            this.pnl_seviceBox.Name = "pnl_seviceBox";
            this.pnl_seviceBox.Size = new System.Drawing.Size(637, 549);
            this.pnl_seviceBox.TabIndex = 182;
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(722, 13);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(84, 24);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 185;
            this.uiLabel3.Text = "状    态：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_connectStatu
            // 
            this.lbl_connectStatu.AutoSize = true;
            this.lbl_connectStatu.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_connectStatu.Location = new System.Drawing.Point(780, 13);
            this.lbl_connectStatu.Name = "lbl_connectStatu";
            this.lbl_connectStatu.Size = new System.Drawing.Size(28, 24);
            this.lbl_connectStatu.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_connectStatu.TabIndex = 186;
            this.lbl_connectStatu.Text = "无";
            this.lbl_connectStatu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_connectStatu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine9
            // 
            this.uiLine9.FillColor = System.Drawing.Color.White;
            this.uiLine9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine9.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine9.Location = new System.Drawing.Point(6, 38);
            this.uiLine9.MinimumSize = new System.Drawing.Size(16, 1);
            this.uiLine9.Name = "uiLine9";
            this.uiLine9.Size = new System.Drawing.Size(823, 1);
            this.uiLine9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine9.TabIndex = 20;
            this.uiLine9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.uiLine9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Frm_Service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(842, 601);
            this.Controls.Add(this.uiLine9);
            this.Controls.Add(this.lbl_connectStatu);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.pnl_seviceBox);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.tvw_serviceList);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximumSize = new System.Drawing.Size(842, 601);
            this.Name = "Frm_Service";
            this.ShowInTaskbar = false;
            this.Text = "系统配置";
            this.Load += new System.EventHandler(this.Frm_Service_Load);
            this.uiContextMenuStrip2.ResumeLayout(false);
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tCPIP服务端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCPIP客户端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 串口通讯ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 扫码枪ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLC通讯ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 光源控制器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 位移传感器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 压力床干起ToolStripMenuItem;
        private Sunny.UI.UISymbolButton btn_add;
        private System.Windows.Forms.ToolStripMenuItem 相机ToolStripMenuItem;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.ToolStripMenuItem 运动控制卡ToolStripMenuItem;
        internal System.Windows.Forms.Panel pnl_seviceBox;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILine uiLine9;
        private System.Windows.Forms.ToolStripMenuItem 启用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上移ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下移ToolStripMenuItem;
        internal Sunny.UI.UILabel lbl_connectStatu;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        internal Sunny.UI.UINavMenu tvw_serviceList;
        private System.Windows.Forms.ToolStripMenuItem 相机标定toolStripMenuItem;
        internal Sunny.UI.UIContextMenuStrip uiContextMenuStrip2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem fTP下载服务ToolStripMenuItem;
    }
}