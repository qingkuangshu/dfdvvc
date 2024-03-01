namespace VM_Pro
{
    partial class Frm_TCPServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TCPServer));
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.tbx_Port = new Sunny.UI.UITextBox();
            this.btn_listen = new Sunny.UI.UIButton();
            this.ckb_autoListenAfterStart = new Sunny.UI.UICheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.断开连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_send3 = new Sunny.UI.UIButton();
            this.lnk_clearLog = new System.Windows.Forms.LinkLabel();
            this.tbx_msg3 = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.ckb_hexMode = new Sunny.UI.UICheckBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiLine2 = new Sunny.UI.UILine();
            this.tbx_msg2 = new Sunny.UI.UITextBox();
            this.btn_send2 = new Sunny.UI.UIButton();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLine4 = new Sunny.UI.UILine();
            this.tbx_msg1 = new Sunny.UI.UITextBox();
            this.btn_send1 = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.tvw_clientList = new Sunny.UI.UINavMenu();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_receiveNum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_sendNum = new System.Windows.Forms.Label();
            this.tbx_log = new System.Windows.Forms.RichTextBox();
            this.cbx_IP = new Sunny.UI.UIComboBox();
            this.btn_showItem = new System.Windows.Forms.Button();
            this.uiLine9 = new Sunny.UI.UILine();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.tbx_loopSendSpan = new Sunny.UI.UITextBox();
            this.ckb_loopSend = new Sunny.UI.UICheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiContextMenuStrip1.SuspendLayout();
            this.cbx_IP.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(16, 8);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(57, 20);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 166;
            this.uiLabel2.Text = "IP地址 :";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(16, 39);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(58, 20);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 167;
            this.uiLabel3.Text = "端口号 :";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_Port
            // 
            this.tbx_Port.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_Port.FillColor = System.Drawing.Color.White;
            this.tbx_Port.FillDisableColor = System.Drawing.Color.White;
            this.tbx_Port.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_Port.Location = new System.Drawing.Point(72, 35);
            this.tbx_Port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_Port.Maximum = 2147483647D;
            this.tbx_Port.Minimum = -2147483648D;
            this.tbx_Port.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_Port.Name = "tbx_Port";
            this.tbx_Port.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_Port.Radius = 0;
            this.tbx_Port.RectColor = System.Drawing.Color.White;
            this.tbx_Port.RectDisableColor = System.Drawing.Color.White;
            this.tbx_Port.RectSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbx_Port.Size = new System.Drawing.Size(180, 29);
            this.tbx_Port.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_Port.TabIndex = 163;
            this.tbx_Port.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_Port.Watermark = "请输入服务端端口号";
            this.tbx_Port.TextChanged += new System.EventHandler(this.tbx_Port_TextChanged);
            // 
            // btn_listen
            // 
            this.btn_listen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_listen.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_listen.Location = new System.Drawing.Point(72, 74);
            this.btn_listen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_listen.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_listen.Name = "btn_listen";
            this.btn_listen.Size = new System.Drawing.Size(70, 30);
            this.btn_listen.Style = Sunny.UI.UIStyle.Custom;
            this.btn_listen.TabIndex = 169;
            this.btn_listen.Text = "开始监听";
            this.btn_listen.Click += new System.EventHandler(this.btn_listen_Click);
            // 
            // ckb_autoListenAfterStart
            // 
            this.ckb_autoListenAfterStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_autoListenAfterStart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_autoListenAfterStart.Location = new System.Drawing.Point(15, 140);
            this.ckb_autoListenAfterStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_autoListenAfterStart.Name = "ckb_autoListenAfterStart";
            this.ckb_autoListenAfterStart.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_autoListenAfterStart.Size = new System.Drawing.Size(197, 30);
            this.ckb_autoListenAfterStart.TabIndex = 179;
            this.ckb_autoListenAfterStart.Text = "程序启动时自动监听";
            this.ckb_autoListenAfterStart.CheckedChanged += new System.EventHandler(this.ckb_autoListenAfterStart_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(12, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 181;
            this.label1.Text = "客户端列表";
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.AutoSize = false;
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重命名ToolStripMenuItem,
            this.断开连接ToolStripMenuItem,
            this.清空记录ToolStripMenuItem,
            this.历史记录ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(153, 140);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.AutoSize = false;
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名ToolStripMenuItem_Click);
            // 
            // 断开连接ToolStripMenuItem
            // 
            this.断开连接ToolStripMenuItem.AutoSize = false;
            this.断开连接ToolStripMenuItem.Name = "断开连接ToolStripMenuItem";
            this.断开连接ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.断开连接ToolStripMenuItem.Text = "断开连接";
            this.断开连接ToolStripMenuItem.Click += new System.EventHandler(this.断开连接ToolStripMenuItem_Click);
            // 
            // 清空记录ToolStripMenuItem
            // 
            this.清空记录ToolStripMenuItem.AutoSize = false;
            this.清空记录ToolStripMenuItem.Name = "清空记录ToolStripMenuItem";
            this.清空记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.清空记录ToolStripMenuItem.Text = "清空记录";
            this.清空记录ToolStripMenuItem.Click += new System.EventHandler(this.清空记录ToolStripMenuItem_Click);
            // 
            // 历史记录ToolStripMenuItem
            // 
            this.历史记录ToolStripMenuItem.Name = "历史记录ToolStripMenuItem";
            this.历史记录ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.历史记录ToolStripMenuItem.Text = "历史记录";
            this.历史记录ToolStripMenuItem.Click += new System.EventHandler(this.历史记录ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.AutoSize = false;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // btn_send3
            // 
            this.btn_send3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_send3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_send3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_send3.Location = new System.Drawing.Point(599, 520);
            this.btn_send3.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_send3.Name = "btn_send3";
            this.btn_send3.Size = new System.Drawing.Size(50, 24);
            this.btn_send3.Style = Sunny.UI.UIStyle.Custom;
            this.btn_send3.TabIndex = 184;
            this.btn_send3.Text = "发送";
            this.btn_send3.Click += new System.EventHandler(this.btn_send3_Click);
            // 
            // lnk_clearLog
            // 
            this.lnk_clearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk_clearLog.AutoSize = true;
            this.lnk_clearLog.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnk_clearLog.Location = new System.Drawing.Point(618, 9);
            this.lnk_clearLog.Name = "lnk_clearLog";
            this.lnk_clearLog.Size = new System.Drawing.Size(37, 20);
            this.lnk_clearLog.TabIndex = 183;
            this.lnk_clearLog.TabStop = true;
            this.lnk_clearLog.Text = "清空";
            this.lnk_clearLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_clearLog_LinkClicked);
            // 
            // tbx_msg3
            // 
            this.tbx_msg3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_msg3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_msg3.FillColor = System.Drawing.Color.White;
            this.tbx_msg3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_msg3.Location = new System.Drawing.Point(314, 513);
            this.tbx_msg3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_msg3.Maximum = 2147483647D;
            this.tbx_msg3.Minimum = -2147483648D;
            this.tbx_msg3.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_msg3.Name = "tbx_msg3";
            this.tbx_msg3.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_msg3.Radius = 0;
            this.tbx_msg3.RectColor = System.Drawing.Color.White;
            this.tbx_msg3.RectSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbx_msg3.Size = new System.Drawing.Size(200, 29);
            this.tbx_msg3.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_msg3.TabIndex = 185;
            this.tbx_msg3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_msg3.Watermark = "要发送的内容";
            this.tbx_msg3.TextChanged += new System.EventHandler(this.tbx_msg3_TextChanged);
            this.tbx_msg3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_msg_KeyPress);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(267, 517);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(52, 20);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 187;
            this.uiLabel1.Text = "指令3 :";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckb_hexMode
            // 
            this.ckb_hexMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_hexMode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_hexMode.Location = new System.Drawing.Point(15, 167);
            this.ckb_hexMode.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_hexMode.Name = "ckb_hexMode";
            this.ckb_hexMode.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_hexMode.Size = new System.Drawing.Size(197, 30);
            this.ckb_hexMode.TabIndex = 188;
            this.ckb_hexMode.Text = "十六进制收发";
            this.ckb_hexMode.CheckedChanged += new System.EventHandler(this.ckb_hexMode_CheckedChanged);
            // 
            // uiLine1
            // 
            this.uiLine1.FillColor = System.Drawing.Color.White;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(15, 65);
            this.uiLine1.MinimumSize = new System.Drawing.Size(16, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(230, 1);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 190;
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiLine3
            // 
            this.uiLine3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine3.FillColor = System.Drawing.Color.White;
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine3.Location = new System.Drawing.Point(266, 542);
            this.uiLine3.MinimumSize = new System.Drawing.Size(16, 1);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(320, 1);
            this.uiLine3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine3.TabIndex = 192;
            this.uiLine3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiLine2
            // 
            this.uiLine2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine2.FillColor = System.Drawing.Color.White;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.Location = new System.Drawing.Point(266, 513);
            this.uiLine2.MinimumSize = new System.Drawing.Size(16, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(320, 1);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 196;
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbx_msg2
            // 
            this.tbx_msg2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_msg2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_msg2.FillColor = System.Drawing.Color.White;
            this.tbx_msg2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_msg2.Location = new System.Drawing.Point(314, 484);
            this.tbx_msg2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_msg2.Maximum = 2147483647D;
            this.tbx_msg2.Minimum = -2147483648D;
            this.tbx_msg2.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_msg2.Name = "tbx_msg2";
            this.tbx_msg2.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_msg2.Radius = 0;
            this.tbx_msg2.RectColor = System.Drawing.Color.White;
            this.tbx_msg2.RectSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbx_msg2.Size = new System.Drawing.Size(200, 29);
            this.tbx_msg2.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_msg2.TabIndex = 194;
            this.tbx_msg2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_msg2.Watermark = "要发送的内容";
            this.tbx_msg2.TextChanged += new System.EventHandler(this.tbx_msg2_TextChanged);
            this.tbx_msg2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_msg_KeyPress);
            // 
            // btn_send2
            // 
            this.btn_send2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_send2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_send2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_send2.Location = new System.Drawing.Point(599, 490);
            this.btn_send2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_send2.Name = "btn_send2";
            this.btn_send2.Size = new System.Drawing.Size(50, 24);
            this.btn_send2.Style = Sunny.UI.UIStyle.Custom;
            this.btn_send2.TabIndex = 193;
            this.btn_send2.Text = "发送";
            this.btn_send2.Click += new System.EventHandler(this.btn_send2_Click);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(267, 488);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(52, 20);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 195;
            this.uiLabel4.Text = "指令2 :";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine4
            // 
            this.uiLine4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine4.FillColor = System.Drawing.Color.White;
            this.uiLine4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine4.Location = new System.Drawing.Point(266, 483);
            this.uiLine4.MinimumSize = new System.Drawing.Size(16, 1);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(320, 1);
            this.uiLine4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine4.TabIndex = 200;
            this.uiLine4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbx_msg1
            // 
            this.tbx_msg1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_msg1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_msg1.FillColor = System.Drawing.Color.White;
            this.tbx_msg1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_msg1.Location = new System.Drawing.Point(314, 454);
            this.tbx_msg1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_msg1.Maximum = 2147483647D;
            this.tbx_msg1.Minimum = -2147483648D;
            this.tbx_msg1.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_msg1.Name = "tbx_msg1";
            this.tbx_msg1.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_msg1.Radius = 0;
            this.tbx_msg1.RectColor = System.Drawing.Color.White;
            this.tbx_msg1.RectSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbx_msg1.Size = new System.Drawing.Size(200, 29);
            this.tbx_msg1.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_msg1.TabIndex = 198;
            this.tbx_msg1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_msg1.Watermark = "要发送的内容";
            this.tbx_msg1.TextChanged += new System.EventHandler(this.tbx_msg1_TextChanged);
            this.tbx_msg1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_msg_KeyPress);
            // 
            // btn_send1
            // 
            this.btn_send1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_send1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_send1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_send1.Location = new System.Drawing.Point(599, 460);
            this.btn_send1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_send1.Name = "btn_send1";
            this.btn_send1.Size = new System.Drawing.Size(50, 24);
            this.btn_send1.Style = Sunny.UI.UIStyle.Custom;
            this.btn_send1.TabIndex = 197;
            this.btn_send1.Text = "发送";
            this.btn_send1.Click += new System.EventHandler(this.btn_send1_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel5.AutoSize = true;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(267, 458);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(52, 20);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 199;
            this.uiLabel5.Text = "指令1 :";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tvw_clientList
            // 
            this.tvw_clientList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_clientList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvw_clientList.ContextMenuStrip = this.uiContextMenuStrip1;
            this.tvw_clientList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvw_clientList.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_clientList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvw_clientList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tvw_clientList.FullRowSelect = true;
            this.tvw_clientList.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tvw_clientList.Indent = 16;
            this.tvw_clientList.ItemHeight = 30;
            this.tvw_clientList.Location = new System.Drawing.Point(15, 283);
            this.tvw_clientList.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.tvw_clientList.Name = "tvw_clientList";
            this.tvw_clientList.Scrollable = false;
            this.tvw_clientList.SecondBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tvw_clientList.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tvw_clientList.SelectedForeColor = System.Drawing.Color.Green;
            this.tvw_clientList.ShowLines = false;
            this.tvw_clientList.ShowNodeToolTips = true;
            this.tvw_clientList.ShowTips = true;
            this.tvw_clientList.Size = new System.Drawing.Size(255, 261);
            this.tvw_clientList.Style = Sunny.UI.UIStyle.Custom;
            this.tvw_clientList.TabIndex = 201;
            this.tvw_clientList.TabStop = false;
            this.tvw_clientList.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvw_clientList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvw_clientList_AfterSelect);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(261, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 202;
            this.label2.Text = "接收次数：";
            // 
            // lbl_receiveNum
            // 
            this.lbl_receiveNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_receiveNum.AutoSize = true;
            this.lbl_receiveNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_receiveNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbl_receiveNum.Location = new System.Drawing.Point(329, 12);
            this.lbl_receiveNum.Name = "lbl_receiveNum";
            this.lbl_receiveNum.Size = new System.Drawing.Size(15, 17);
            this.lbl_receiveNum.TabIndex = 203;
            this.lbl_receiveNum.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(382, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 204;
            this.label4.Text = "发送次数：";
            // 
            // lbl_sendNum
            // 
            this.lbl_sendNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_sendNum.AutoSize = true;
            this.lbl_sendNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_sendNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbl_sendNum.Location = new System.Drawing.Point(450, 12);
            this.lbl_sendNum.Name = "lbl_sendNum";
            this.lbl_sendNum.Size = new System.Drawing.Size(15, 17);
            this.lbl_sendNum.TabIndex = 205;
            this.lbl_sendNum.Text = "0";
            // 
            // tbx_log
            // 
            this.tbx_log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_log.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbx_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_log.DetectUrls = false;
            this.tbx_log.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_log.Location = new System.Drawing.Point(265, 31);
            this.tbx_log.Name = "tbx_log";
            this.tbx_log.ReadOnly = true;
            this.tbx_log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbx_log.ShortcutsEnabled = false;
            this.tbx_log.Size = new System.Drawing.Size(384, 409);
            this.tbx_log.TabIndex = 206;
            this.tbx_log.TabStop = false;
            this.tbx_log.Text = "";
            // 
            // cbx_IP
            // 
            this.cbx_IP.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_IP.Controls.Add(this.btn_showItem);
            this.cbx_IP.DataSource = null;
            this.cbx_IP.FillColor = System.Drawing.Color.White;
            this.cbx_IP.FillDisableColor = System.Drawing.Color.White;
            this.cbx_IP.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_IP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_IP.Items.AddRange(new object[] {
            "启动 停止 暂停 复位 型",
            "启动 停止 型",
            "空 型"});
            this.cbx_IP.Location = new System.Drawing.Point(78, 4);
            this.cbx_IP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_IP.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_IP.Name = "cbx_IP";
            this.cbx_IP.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_IP.Radius = 0;
            this.cbx_IP.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_IP.RectColor = System.Drawing.Color.White;
            this.cbx_IP.RectDisableColor = System.Drawing.Color.White;
            this.cbx_IP.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_IP.Size = new System.Drawing.Size(150, 29);
            this.cbx_IP.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_IP.TabIndex = 208;
            this.cbx_IP.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_IP.Watermark = "";
            this.cbx_IP.TextChanged += new System.EventHandler(this.cbx_IP_TextChanged);
            // 
            // btn_showItem
            // 
            this.btn_showItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_showItem.BackColor = System.Drawing.Color.White;
            this.btn_showItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_showItem.BackgroundImage")));
            this.btn_showItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_showItem.FlatAppearance.BorderSize = 0;
            this.btn_showItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btn_showItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_showItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_showItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_showItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_showItem.Location = new System.Drawing.Point(129, 7);
            this.btn_showItem.Name = "btn_showItem";
            this.btn_showItem.Size = new System.Drawing.Size(18, 18);
            this.btn_showItem.TabIndex = 100074;
            this.btn_showItem.UseVisualStyleBackColor = false;
            this.btn_showItem.Click += new System.EventHandler(this.btn_showItem_Click);
            // 
            // uiLine9
            // 
            this.uiLine9.FillColor = System.Drawing.Color.White;
            this.uiLine9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine9.Location = new System.Drawing.Point(15, 35);
            this.uiLine9.MinimumSize = new System.Drawing.Size(16, 1);
            this.uiLine9.Name = "uiLine9";
            this.uiLine9.Size = new System.Drawing.Size(230, 1);
            this.uiLine9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine9.TabIndex = 189;
            this.uiLine9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiLabel7
            // 
            this.uiLabel7.AutoSize = true;
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(184, 197);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(28, 20);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 222;
            this.uiLabel7.Text = "ms";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_loopSendSpan
            // 
            this.tbx_loopSendSpan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_loopSendSpan.FillColor = System.Drawing.Color.White;
            this.tbx_loopSendSpan.FillDisableColor = System.Drawing.Color.White;
            this.tbx_loopSendSpan.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_loopSendSpan.Location = new System.Drawing.Point(98, 193);
            this.tbx_loopSendSpan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_loopSendSpan.Maximum = 2147483647D;
            this.tbx_loopSendSpan.Minimum = -2147483648D;
            this.tbx_loopSendSpan.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_loopSendSpan.Name = "tbx_loopSendSpan";
            this.tbx_loopSendSpan.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_loopSendSpan.Radius = 0;
            this.tbx_loopSendSpan.RectColor = System.Drawing.Color.White;
            this.tbx_loopSendSpan.RectDisableColor = System.Drawing.Color.White;
            this.tbx_loopSendSpan.RectSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbx_loopSendSpan.Size = new System.Drawing.Size(80, 29);
            this.tbx_loopSendSpan.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_loopSendSpan.TabIndex = 221;
            this.tbx_loopSendSpan.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbx_loopSendSpan.Watermark = "";
            this.tbx_loopSendSpan.TextChanged += new System.EventHandler(this.tbx_loopSendSpan_TextChanged);
            // 
            // ckb_loopSend
            // 
            this.ckb_loopSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_loopSend.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_loopSend.Location = new System.Drawing.Point(15, 194);
            this.ckb_loopSend.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_loopSend.Name = "ckb_loopSend";
            this.ckb_loopSend.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_loopSend.Size = new System.Drawing.Size(96, 30);
            this.ckb_loopSend.TabIndex = 220;
            this.ckb_loopSend.Text = "连续发送";
            this.ckb_loopSend.CheckedChanged += new System.EventHandler(this.ckb_loopSend_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(242, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 262);
            this.label3.TabIndex = 223;
            // 
            // Frm_TCPServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(656, 549);
            this.Controls.Add(this.uiLabel7);
            this.Controls.Add(this.tbx_loopSendSpan);
            this.Controls.Add(this.ckb_loopSend);
            this.Controls.Add(this.cbx_IP);
            this.Controls.Add(this.tbx_log);
            this.Controls.Add(this.lbl_sendNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_receiveNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiLine4);
            this.Controls.Add(this.tbx_msg1);
            this.Controls.Add(this.btn_send1);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.tbx_msg2);
            this.Controls.Add(this.btn_send2);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLine3);
            this.Controls.Add(this.uiLine9);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.ckb_hexMode);
            this.Controls.Add(this.tbx_msg3);
            this.Controls.Add(this.btn_send3);
            this.Controls.Add(this.lnk_clearLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckb_autoListenAfterStart);
            this.Controls.Add(this.btn_listen);
            this.Controls.Add(this.tbx_Port);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tvw_clientList);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_TCPServer";
            this.Text = "Frm_Project";
            this.Load += new System.EventHandler(this.Frm_TCPServer_Load);
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.cbx_IP.ResumeLayout(false);
            this.cbx_IP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox tbx_Port;
        internal Sunny.UI.UIButton btn_listen;
        private Sunny.UI.UICheckBox ckb_autoListenAfterStart;
        private System.Windows.Forms.Label label1;
        internal Sunny.UI.UIButton btn_send3;
        private System.Windows.Forms.LinkLabel lnk_clearLog;
        private Sunny.UI.UITextBox tbx_msg3;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UICheckBox ckb_hexMode;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 断开连接ToolStripMenuItem;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UITextBox tbx_msg2;
        internal Sunny.UI.UIButton btn_send2;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILine uiLine4;
        private Sunny.UI.UITextBox tbx_msg1;
        internal Sunny.UI.UIButton btn_send1;
        private Sunny.UI.UILabel uiLabel5;
        internal Sunny.UI.UINavMenu tvw_clientList;
        private System.Windows.Forms.ToolStripMenuItem 清空记录ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label lbl_receiveNum;
        internal System.Windows.Forms.Label lbl_sendNum;
        internal System.Windows.Forms.RichTextBox tbx_log;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史记录ToolStripMenuItem;
        internal Sunny.UI.UIComboBox cbx_IP;
        private Sunny.UI.UILine uiLine9;
        internal System.Windows.Forms.Button btn_showItem;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UITextBox tbx_loopSendSpan;
        private Sunny.UI.UICheckBox ckb_loopSend;
        private System.Windows.Forms.Label label3;

    }
}