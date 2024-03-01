namespace VM_Pro
{
    partial class Frm_Serial
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
            this.btn_open = new Sunny.UI.UIButton();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.历史记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_send3 = new Sunny.UI.UIButton();
            this.lnk_clearLog = new System.Windows.Forms.LinkLabel();
            this.tbx_msg3 = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiLine2 = new Sunny.UI.UILine();
            this.tbx_msg2 = new Sunny.UI.UITextBox();
            this.btn_send2 = new Sunny.UI.UIButton();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLine4 = new Sunny.UI.UILine();
            this.tbx_msg1 = new Sunny.UI.UITextBox();
            this.btn_send1 = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_receiveNum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_sendNum = new System.Windows.Forms.Label();
            this.tbx_log = new System.Windows.Forms.RichTextBox();
            this.cbx_parityBit = new Sunny.UI.UIComboBox();
            this.cbx_stopBit = new Sunny.UI.UIComboBox();
            this.cbx_baudRate = new Sunny.UI.UIComboBox();
            this.cbx_dataBit = new Sunny.UI.UIComboBox();
            this.cbx_portName = new Sunny.UI.UIComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ckb_hexMode = new Sunny.UI.UICheckBox();
            this.ckb_receiveTimeoutEnable = new Sunny.UI.UICheckBox();
            this.tbx_receiveTimeout = new Sunny.UI.UITextBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.ckb_loopSend = new Sunny.UI.UICheckBox();
            this.tbx_loopSendSpan = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_open
            // 
            this.btn_open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_open.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_open.Location = new System.Drawing.Point(149, 179);
            this.btn_open.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_open.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(70, 30);
            this.btn_open.Style = Sunny.UI.UIStyle.Custom;
            this.btn_open.TabIndex = 169;
            this.btn_open.Text = "打开";
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.AutoSize = false;
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.历史记录ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(153, 28);
            // 
            // 历史记录ToolStripMenuItem
            // 
            this.历史记录ToolStripMenuItem.AutoSize = false;
            this.历史记录ToolStripMenuItem.Name = "历史记录ToolStripMenuItem";
            this.历史记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.历史记录ToolStripMenuItem.Text = "历史记录";
            this.历史记录ToolStripMenuItem.Click += new System.EventHandler(this.历史记录ToolStripMenuItem_Click);
            // 
            // btn_send3
            // 
            this.btn_send3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_send3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_send3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_send3.Location = new System.Drawing.Point(596, 464);
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
            this.lnk_clearLog.Location = new System.Drawing.Point(615, 7);
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
            this.tbx_msg3.Location = new System.Drawing.Point(373, 457);
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
            this.uiLabel1.Location = new System.Drawing.Point(326, 461);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(52, 20);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 187;
            this.uiLabel1.Text = "指令3 :";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine3
            // 
            this.uiLine3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine3.FillColor = System.Drawing.Color.White;
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine3.Location = new System.Drawing.Point(325, 486);
            this.uiLine3.MinimumSize = new System.Drawing.Size(16, 1);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(260, 1);
            this.uiLine3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine3.TabIndex = 192;
            this.uiLine3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiLine2
            // 
            this.uiLine2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine2.FillColor = System.Drawing.Color.White;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.Location = new System.Drawing.Point(325, 457);
            this.uiLine2.MinimumSize = new System.Drawing.Size(16, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(260, 1);
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
            this.tbx_msg2.Location = new System.Drawing.Point(373, 428);
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
            this.btn_send2.Location = new System.Drawing.Point(596, 434);
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
            this.uiLabel4.Location = new System.Drawing.Point(326, 432);
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
            this.uiLine4.Location = new System.Drawing.Point(325, 427);
            this.uiLine4.MinimumSize = new System.Drawing.Size(16, 1);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(260, 1);
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
            this.tbx_msg1.Location = new System.Drawing.Point(373, 398);
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
            this.btn_send1.Location = new System.Drawing.Point(596, 404);
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
            this.uiLabel5.Location = new System.Drawing.Point(326, 402);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(52, 20);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 199;
            this.uiLabel5.Text = "指令1 :";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(322, 7);
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
            this.lbl_receiveNum.Location = new System.Drawing.Point(390, 10);
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
            this.label4.Location = new System.Drawing.Point(443, 7);
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
            this.lbl_sendNum.Location = new System.Drawing.Point(511, 10);
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
            this.tbx_log.ContextMenuStrip = this.uiContextMenuStrip1;
            this.tbx_log.DetectUrls = false;
            this.tbx_log.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_log.Location = new System.Drawing.Point(325, 33);
            this.tbx_log.Name = "tbx_log";
            this.tbx_log.ReadOnly = true;
            this.tbx_log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbx_log.ShortcutsEnabled = false;
            this.tbx_log.Size = new System.Drawing.Size(321, 357);
            this.tbx_log.TabIndex = 206;
            this.tbx_log.TabStop = false;
            this.tbx_log.Text = "";
            // 
            // cbx_parityBit
            // 
            this.cbx_parityBit.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_parityBit.DataSource = null;
            this.cbx_parityBit.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_parityBit.DropDownWidth = 132;
            this.cbx_parityBit.FillColor = System.Drawing.Color.White;
            this.cbx_parityBit.FillDisableColor = System.Drawing.Color.White;
            this.cbx_parityBit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_parityBit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_parityBit.Location = new System.Drawing.Point(87, 143);
            this.cbx_parityBit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_parityBit.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_parityBit.Name = "cbx_parityBit";
            this.cbx_parityBit.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_parityBit.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_parityBit.RectColor = System.Drawing.Color.DimGray;
            this.cbx_parityBit.RectDisableColor = System.Drawing.Color.DimGray;
            this.cbx_parityBit.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_parityBit.Size = new System.Drawing.Size(132, 26);
            this.cbx_parityBit.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_parityBit.TabIndex = 100106;
            this.cbx_parityBit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_parityBit.Watermark = "";
            this.cbx_parityBit.SelectedIndexChanged += new System.EventHandler(this.cbx_parityBit_SelectedIndexChanged);
            // 
            // cbx_stopBit
            // 
            this.cbx_stopBit.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_stopBit.DataSource = null;
            this.cbx_stopBit.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_stopBit.DropDownWidth = 132;
            this.cbx_stopBit.FillColor = System.Drawing.Color.White;
            this.cbx_stopBit.FillDisableColor = System.Drawing.Color.White;
            this.cbx_stopBit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_stopBit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_stopBit.Location = new System.Drawing.Point(87, 111);
            this.cbx_stopBit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_stopBit.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_stopBit.Name = "cbx_stopBit";
            this.cbx_stopBit.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_stopBit.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_stopBit.RectColor = System.Drawing.Color.DimGray;
            this.cbx_stopBit.RectDisableColor = System.Drawing.Color.DimGray;
            this.cbx_stopBit.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_stopBit.Size = new System.Drawing.Size(132, 26);
            this.cbx_stopBit.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_stopBit.TabIndex = 100104;
            this.cbx_stopBit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_stopBit.Watermark = "";
            this.cbx_stopBit.SelectedIndexChanged += new System.EventHandler(this.cbx_stopBit_SelectedIndexChanged);
            // 
            // cbx_baudRate
            // 
            this.cbx_baudRate.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_baudRate.DataSource = null;
            this.cbx_baudRate.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_baudRate.DropDownWidth = 132;
            this.cbx_baudRate.FillColor = System.Drawing.Color.White;
            this.cbx_baudRate.FillDisableColor = System.Drawing.Color.White;
            this.cbx_baudRate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_baudRate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_baudRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "10004",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbx_baudRate.Location = new System.Drawing.Point(87, 47);
            this.cbx_baudRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_baudRate.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_baudRate.Name = "cbx_baudRate";
            this.cbx_baudRate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_baudRate.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_baudRate.RectColor = System.Drawing.Color.DimGray;
            this.cbx_baudRate.RectDisableColor = System.Drawing.Color.DimGray;
            this.cbx_baudRate.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_baudRate.Size = new System.Drawing.Size(132, 26);
            this.cbx_baudRate.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_baudRate.TabIndex = 100105;
            this.cbx_baudRate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_baudRate.Watermark = "";
            this.cbx_baudRate.SelectedIndexChanged += new System.EventHandler(this.cbx_baudRate_SelectedIndexChanged);
            // 
            // cbx_dataBit
            // 
            this.cbx_dataBit.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_dataBit.DataSource = null;
            this.cbx_dataBit.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_dataBit.DropDownWidth = 132;
            this.cbx_dataBit.FillColor = System.Drawing.Color.White;
            this.cbx_dataBit.FillDisableColor = System.Drawing.Color.White;
            this.cbx_dataBit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_dataBit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_dataBit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbx_dataBit.Location = new System.Drawing.Point(87, 79);
            this.cbx_dataBit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_dataBit.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_dataBit.Name = "cbx_dataBit";
            this.cbx_dataBit.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_dataBit.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_dataBit.RectColor = System.Drawing.Color.DimGray;
            this.cbx_dataBit.RectDisableColor = System.Drawing.Color.DimGray;
            this.cbx_dataBit.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_dataBit.Size = new System.Drawing.Size(132, 26);
            this.cbx_dataBit.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_dataBit.TabIndex = 100102;
            this.cbx_dataBit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_dataBit.Watermark = "";
            this.cbx_dataBit.SelectedIndexChanged += new System.EventHandler(this.cbx_dataBit_SelectedIndexChanged);
            // 
            // cbx_portName
            // 
            this.cbx_portName.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_portName.DataSource = null;
            this.cbx_portName.DropDownWidth = 132;
            this.cbx_portName.FillColor = System.Drawing.Color.White;
            this.cbx_portName.FillDisableColor = System.Drawing.Color.White;
            this.cbx_portName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_portName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_portName.Location = new System.Drawing.Point(87, 14);
            this.cbx_portName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_portName.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_portName.Name = "cbx_portName";
            this.cbx_portName.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_portName.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_portName.RectColor = System.Drawing.Color.DimGray;
            this.cbx_portName.RectDisableColor = System.Drawing.Color.DimGray;
            this.cbx_portName.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_portName.Size = new System.Drawing.Size(132, 26);
            this.cbx_portName.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_portName.TabIndex = 100103;
            this.cbx_portName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_portName.Watermark = "";
            this.cbx_portName.TextChanged += new System.EventHandler(this.cbx_portName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 100101;
            this.label6.Text = "停 止 位 ：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.TabIndex = 100100;
            this.label7.Text = "效 验 位 ：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 20);
            this.label14.TabIndex = 100099;
            this.label14.Text = "数 据 位 ：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 20);
            this.label15.TabIndex = 100098;
            this.label15.Text = "波 特 率 ：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 20);
            this.label19.TabIndex = 100097;
            this.label19.Text = "端  口 号：";
            // 
            // ckb_hexMode
            // 
            this.ckb_hexMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_hexMode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_hexMode.Location = new System.Drawing.Point(15, 231);
            this.ckb_hexMode.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_hexMode.Name = "ckb_hexMode";
            this.ckb_hexMode.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_hexMode.Size = new System.Drawing.Size(197, 30);
            this.ckb_hexMode.TabIndex = 188;
            this.ckb_hexMode.Text = "十六进制收发";
            this.ckb_hexMode.CheckedChanged += new System.EventHandler(this.ckb_hexMode_CheckedChanged);
            // 
            // ckb_receiveTimeoutEnable
            // 
            this.ckb_receiveTimeoutEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_receiveTimeoutEnable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_receiveTimeoutEnable.Location = new System.Drawing.Point(15, 259);
            this.ckb_receiveTimeoutEnable.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_receiveTimeoutEnable.Name = "ckb_receiveTimeoutEnable";
            this.ckb_receiveTimeoutEnable.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_receiveTimeoutEnable.Size = new System.Drawing.Size(96, 30);
            this.ckb_receiveTimeoutEnable.TabIndex = 213;
            this.ckb_receiveTimeoutEnable.Text = "接收超时";
            this.ckb_receiveTimeoutEnable.CheckedChanged += new System.EventHandler(this.ckb_receiveTimeoutEnable_CheckedChanged);
            // 
            // tbx_receiveTimeout
            // 
            this.tbx_receiveTimeout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_receiveTimeout.FillColor = System.Drawing.Color.White;
            this.tbx_receiveTimeout.FillDisableColor = System.Drawing.Color.White;
            this.tbx_receiveTimeout.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_receiveTimeout.Location = new System.Drawing.Point(98, 258);
            this.tbx_receiveTimeout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_receiveTimeout.Maximum = 2147483647D;
            this.tbx_receiveTimeout.Minimum = -2147483648D;
            this.tbx_receiveTimeout.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_receiveTimeout.Name = "tbx_receiveTimeout";
            this.tbx_receiveTimeout.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_receiveTimeout.Radius = 0;
            this.tbx_receiveTimeout.RectColor = System.Drawing.Color.White;
            this.tbx_receiveTimeout.RectDisableColor = System.Drawing.Color.White;
            this.tbx_receiveTimeout.RectSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tbx_receiveTimeout.Size = new System.Drawing.Size(80, 29);
            this.tbx_receiveTimeout.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_receiveTimeout.TabIndex = 214;
            this.tbx_receiveTimeout.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbx_receiveTimeout.Watermark = "";
            this.tbx_receiveTimeout.TextChanged += new System.EventHandler(this.tbx_receiveTimeout_TextChanged);
            // 
            // uiLabel8
            // 
            this.uiLabel8.AutoSize = true;
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(184, 262);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(28, 20);
            this.uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel8.TabIndex = 215;
            this.uiLabel8.Text = "ms";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckb_loopSend
            // 
            this.ckb_loopSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_loopSend.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_loopSend.Location = new System.Drawing.Point(15, 287);
            this.ckb_loopSend.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_loopSend.Name = "ckb_loopSend";
            this.ckb_loopSend.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_loopSend.Size = new System.Drawing.Size(96, 30);
            this.ckb_loopSend.TabIndex = 217;
            this.ckb_loopSend.Text = "连续发送";
            this.ckb_loopSend.CheckedChanged += new System.EventHandler(this.ckb_loopSend_CheckedChanged);
            // 
            // tbx_loopSendSpan
            // 
            this.tbx_loopSendSpan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_loopSendSpan.FillColor = System.Drawing.Color.White;
            this.tbx_loopSendSpan.FillDisableColor = System.Drawing.Color.White;
            this.tbx_loopSendSpan.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_loopSendSpan.Location = new System.Drawing.Point(98, 286);
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
            this.tbx_loopSendSpan.TabIndex = 218;
            this.tbx_loopSendSpan.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbx_loopSendSpan.Watermark = "";
            this.tbx_loopSendSpan.TextChanged += new System.EventHandler(this.tbx_loopSendSpan_TextChanged);
            // 
            // uiLabel6
            // 
            this.uiLabel6.AutoSize = true;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(184, 290);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(28, 20);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 219;
            this.uiLabel6.Text = "ms";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_Serial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(656, 549);
            this.Controls.Add(this.cbx_parityBit);
            this.Controls.Add(this.cbx_stopBit);
            this.Controls.Add(this.cbx_baudRate);
            this.Controls.Add(this.cbx_dataBit);
            this.Controls.Add(this.cbx_portName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.tbx_loopSendSpan);
            this.Controls.Add(this.ckb_loopSend);
            this.Controls.Add(this.uiLabel8);
            this.Controls.Add(this.tbx_receiveTimeout);
            this.Controls.Add(this.ckb_receiveTimeoutEnable);
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
            this.Controls.Add(this.ckb_hexMode);
            this.Controls.Add(this.tbx_msg3);
            this.Controls.Add(this.btn_send3);
            this.Controls.Add(this.lnk_clearLog);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.uiLabel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_Serial";
            this.Text = "Frm_Project";
            this.Load += new System.EventHandler(this.Frm_Serial_Load);
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Sunny.UI.UIButton btn_open;
        internal Sunny.UI.UIButton btn_send3;
        private System.Windows.Forms.LinkLabel lnk_clearLog;
        private Sunny.UI.UITextBox tbx_msg3;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UITextBox tbx_msg2;
        internal Sunny.UI.UIButton btn_send2;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILine uiLine4;
        private Sunny.UI.UITextBox tbx_msg1;
        internal Sunny.UI.UIButton btn_send1;
        private Sunny.UI.UILabel uiLabel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label lbl_receiveNum;
        internal System.Windows.Forms.Label lbl_sendNum;
        internal System.Windows.Forms.RichTextBox tbx_log;
        private System.Windows.Forms.ToolStripMenuItem 历史记录ToolStripMenuItem;
        internal Sunny.UI.UIComboBox cbx_parityBit;
        internal Sunny.UI.UIComboBox cbx_stopBit;
        internal Sunny.UI.UIComboBox cbx_baudRate;
        internal Sunny.UI.UIComboBox cbx_dataBit;
        internal Sunny.UI.UIComboBox cbx_portName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        internal Sunny.UI.UICheckBox ckb_hexMode;
        private Sunny.UI.UICheckBox ckb_receiveTimeoutEnable;
        private Sunny.UI.UITextBox tbx_receiveTimeout;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UICheckBox ckb_loopSend;
        private Sunny.UI.UITextBox tbx_loopSendSpan;
        private Sunny.UI.UILabel uiLabel6;

    }
}