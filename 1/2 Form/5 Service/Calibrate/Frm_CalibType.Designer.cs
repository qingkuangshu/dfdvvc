namespace VM_Pro
{
    partial class Frm_CalibType
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
            this.uiLine5 = new Sunny.UI.UILine();
            this.label1 = new System.Windows.Forms.Label();
            this.label147 = new System.Windows.Forms.Label();
            this.cbx_calibType = new Sunny.UI.UIComboBox();
            this.cbx_calibMode = new Sunny.UI.UIComboBox();
            this.cbx_cameraList = new Sunny.UI.UIComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_rotateSpan = new Sunny.UI.UITextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_rotateY = new Sunny.UI.UITextBox();
            this.tbx_rotateX = new Sunny.UI.UITextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_moveSpan = new Sunny.UI.UITextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_moveY = new Sunny.UI.UITextBox();
            this.tbx_moveX = new Sunny.UI.UITextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine1 = new Sunny.UI.UILine();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_touchMovePos = new Sunny.UI.UIButton();
            this.btn_touchRotatePos = new Sunny.UI.UIButton();
            this.btn_goMovePos = new Sunny.UI.UIButton();
            this.btn_goRotatePos = new Sunny.UI.UIButton();
            this.tbx_moveU = new Sunny.UI.UITextBox();
            this.tbx_moveZ = new Sunny.UI.UITextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbx_rotateU = new Sunny.UI.UITextBox();
            this.tbx_rotateZ = new Sunny.UI.UITextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiLine5
            // 
            this.uiLine5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine5.LineSize = 2;
            this.uiLine5.Location = new System.Drawing.Point(0, 520);
            this.uiLine5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine5.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(410, 2);
            this.uiLine5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine5.TabIndex = 129;
            this.uiLine5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 232;
            this.label1.Text = "场  景 ：";
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label147.Location = new System.Drawing.Point(17, 55);
            this.label147.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(63, 20);
            this.label147.TabIndex = 231;
            this.label147.Text = "类  型 ：";
            // 
            // cbx_calibType
            // 
            this.cbx_calibType.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_calibType.DataSource = null;
            this.cbx_calibType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_calibType.DropDownWidth = 120;
            this.cbx_calibType.FillColor = System.Drawing.Color.White;
            this.cbx_calibType.FillDisableColor = System.Drawing.Color.White;
            this.cbx_calibType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_calibType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_calibType.Items.AddRange(new object[] {
            "自动标定",
            "手动标定"});
            this.cbx_calibType.Location = new System.Drawing.Point(72, 54);
            this.cbx_calibType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_calibType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_calibType.Name = "cbx_calibType";
            this.cbx_calibType.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_calibType.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_calibType.RectColor = System.Drawing.Color.DimGray;
            this.cbx_calibType.RectDisableColor = System.Drawing.Color.DimGray;
            this.cbx_calibType.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_calibType.Size = new System.Drawing.Size(120, 26);
            this.cbx_calibType.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_calibType.TabIndex = 100093;
            this.cbx_calibType.Text = "自动标定";
            this.cbx_calibType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_calibType.Watermark = "";
            this.cbx_calibType.SelectedIndexChanged += new System.EventHandler(this.cbx_calibType_SelectedIndexChanged);
            // 
            // cbx_calibMode
            // 
            this.cbx_calibMode.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_calibMode.DataSource = null;
            this.cbx_calibMode.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_calibMode.DropDownWidth = 120;
            this.cbx_calibMode.FillColor = System.Drawing.Color.White;
            this.cbx_calibMode.FillDisableColor = System.Drawing.Color.White;
            this.cbx_calibMode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_calibMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_calibMode.Items.AddRange(new object[] {
            "眼在手外",
            "眼在手上"});
            this.cbx_calibMode.Location = new System.Drawing.Point(72, 85);
            this.cbx_calibMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_calibMode.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_calibMode.Name = "cbx_calibMode";
            this.cbx_calibMode.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_calibMode.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_calibMode.RectColor = System.Drawing.Color.DimGray;
            this.cbx_calibMode.RectDisableColor = System.Drawing.Color.DimGray;
            this.cbx_calibMode.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_calibMode.Size = new System.Drawing.Size(120, 26);
            this.cbx_calibMode.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_calibMode.TabIndex = 100094;
            this.cbx_calibMode.Text = "眼在手外";
            this.cbx_calibMode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_calibMode.Watermark = "";
            this.cbx_calibMode.SelectedIndexChanged += new System.EventHandler(this.cbx_calibMode_SelectedIndexChanged);
            // 
            // cbx_cameraList
            // 
            this.cbx_cameraList.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_cameraList.DataSource = null;
            this.cbx_cameraList.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_cameraList.DropDownWidth = 120;
            this.cbx_cameraList.FillColor = System.Drawing.Color.White;
            this.cbx_cameraList.FillDisableColor = System.Drawing.Color.White;
            this.cbx_cameraList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_cameraList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_cameraList.Location = new System.Drawing.Point(72, 116);
            this.cbx_cameraList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_cameraList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_cameraList.Name = "cbx_cameraList";
            this.cbx_cameraList.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_cameraList.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_cameraList.RectColor = System.Drawing.Color.DimGray;
            this.cbx_cameraList.RectDisableColor = System.Drawing.Color.DimGray;
            this.cbx_cameraList.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_cameraList.Size = new System.Drawing.Size(120, 26);
            this.cbx_cameraList.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_cameraList.TabIndex = 100096;
            this.cbx_cameraList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_cameraList.Watermark = "";
            this.cbx_cameraList.SelectedIndexChanged += new System.EventHandler(this.cbx_cameraList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 100095;
            this.label2.Text = "相  机 ：";
            // 
            // tbx_rotateSpan
            // 
            this.tbx_rotateSpan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_rotateSpan.FillColor = System.Drawing.Color.White;
            this.tbx_rotateSpan.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_rotateSpan.Location = new System.Drawing.Point(77, 472);
            this.tbx_rotateSpan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_rotateSpan.Maximum = 2147483647D;
            this.tbx_rotateSpan.Minimum = -2147483648D;
            this.tbx_rotateSpan.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_rotateSpan.Name = "tbx_rotateSpan";
            this.tbx_rotateSpan.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_rotateSpan.Radius = 0;
            this.tbx_rotateSpan.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_rotateSpan.Size = new System.Drawing.Size(75, 27);
            this.tbx_rotateSpan.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_rotateSpan.TabIndex = 100110;
            this.tbx_rotateSpan.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_rotateSpan.Watermark = "";
            this.tbx_rotateSpan.TextChanged += new System.EventHandler(this.tbx_rotateSpan_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(19, 476);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 100109;
            this.label5.Text = "旋转量 :";
            // 
            // tbx_rotateY
            // 
            this.tbx_rotateY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_rotateY.FillColor = System.Drawing.Color.White;
            this.tbx_rotateY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_rotateY.Location = new System.Drawing.Point(46, 382);
            this.tbx_rotateY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_rotateY.Maximum = 2147483647D;
            this.tbx_rotateY.Minimum = -2147483648D;
            this.tbx_rotateY.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_rotateY.Name = "tbx_rotateY";
            this.tbx_rotateY.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_rotateY.Radius = 0;
            this.tbx_rotateY.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_rotateY.Size = new System.Drawing.Size(75, 27);
            this.tbx_rotateY.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_rotateY.TabIndex = 100108;
            this.tbx_rotateY.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_rotateY.Watermark = "";
            this.tbx_rotateY.TextChanged += new System.EventHandler(this.tbx_rotateY_TextChanged);
            // 
            // tbx_rotateX
            // 
            this.tbx_rotateX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_rotateX.FillColor = System.Drawing.Color.White;
            this.tbx_rotateX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_rotateX.Location = new System.Drawing.Point(46, 353);
            this.tbx_rotateX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_rotateX.Maximum = 2147483647D;
            this.tbx_rotateX.Minimum = -2147483648D;
            this.tbx_rotateX.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_rotateX.Name = "tbx_rotateX";
            this.tbx_rotateX.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_rotateX.Radius = 0;
            this.tbx_rotateX.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_rotateX.Size = new System.Drawing.Size(75, 27);
            this.tbx_rotateX.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_rotateX.TabIndex = 100107;
            this.tbx_rotateX.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_rotateX.Watermark = "";
            this.tbx_rotateX.TextChanged += new System.EventHandler(this.tbx_rotateX_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(19, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 20);
            this.label6.TabIndex = 100106;
            this.label6.Text = "Y :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(19, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 20);
            this.label7.TabIndex = 100105;
            this.label7.Text = "X :";
            // 
            // tbx_moveSpan
            // 
            this.tbx_moveSpan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_moveSpan.FillColor = System.Drawing.Color.White;
            this.tbx_moveSpan.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_moveSpan.Location = new System.Drawing.Point(280, 473);
            this.tbx_moveSpan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_moveSpan.Maximum = 2147483647D;
            this.tbx_moveSpan.Minimum = -2147483648D;
            this.tbx_moveSpan.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_moveSpan.Name = "tbx_moveSpan";
            this.tbx_moveSpan.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_moveSpan.Radius = 0;
            this.tbx_moveSpan.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_moveSpan.Size = new System.Drawing.Size(75, 27);
            this.tbx_moveSpan.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_moveSpan.TabIndex = 100104;
            this.tbx_moveSpan.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_moveSpan.Watermark = "";
            this.tbx_moveSpan.TextChanged += new System.EventHandler(this.tbx_moveSpan_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(222, 477);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 100103;
            this.label4.Text = "平移量 :";
            // 
            // tbx_moveY
            // 
            this.tbx_moveY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_moveY.FillColor = System.Drawing.Color.White;
            this.tbx_moveY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_moveY.Location = new System.Drawing.Point(249, 383);
            this.tbx_moveY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_moveY.Maximum = 2147483647D;
            this.tbx_moveY.Minimum = -2147483648D;
            this.tbx_moveY.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_moveY.Name = "tbx_moveY";
            this.tbx_moveY.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_moveY.Radius = 0;
            this.tbx_moveY.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_moveY.Size = new System.Drawing.Size(75, 27);
            this.tbx_moveY.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_moveY.TabIndex = 100102;
            this.tbx_moveY.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_moveY.Watermark = "";
            this.tbx_moveY.TextChanged += new System.EventHandler(this.tbx_moveY_TextChanged);
            // 
            // tbx_moveX
            // 
            this.tbx_moveX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_moveX.FillColor = System.Drawing.Color.White;
            this.tbx_moveX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_moveX.Location = new System.Drawing.Point(249, 354);
            this.tbx_moveX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_moveX.Maximum = 2147483647D;
            this.tbx_moveX.Minimum = -2147483648D;
            this.tbx_moveX.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_moveX.Name = "tbx_moveX";
            this.tbx_moveX.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_moveX.Radius = 0;
            this.tbx_moveX.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_moveX.Size = new System.Drawing.Size(75, 27);
            this.tbx_moveX.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_moveX.TabIndex = 100101;
            this.tbx_moveX.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_moveX.Watermark = "";
            this.tbx_moveX.TextChanged += new System.EventHandler(this.tbx_moveX_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(222, 387);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 20);
            this.label8.TabIndex = 100100;
            this.label8.Text = "Y :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(222, 358);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 20);
            this.label9.TabIndex = 100099;
            this.label9.Text = "X :";
            // 
            // uiLine2
            // 
            this.uiLine2.FillColor = System.Drawing.Color.White;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uiLine2.Location = new System.Drawing.Point(220, 316);
            this.uiLine2.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(173, 29);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 100123;
            this.uiLine2.Text = "标定平移位";
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine1
            // 
            this.uiLine1.FillColor = System.Drawing.Color.White;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uiLine1.Location = new System.Drawing.Point(17, 316);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(173, 29);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 100124;
            this.uiLine1.Text = "标定旋转位";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(358, 477);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 20);
            this.label10.TabIndex = 100128;
            this.label10.Text = "mm";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(155, 476);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 20);
            this.label15.TabIndex = 100131;
            this.label15.Text = "度";
            // 
            // btn_touchMovePos
            // 
            this.btn_touchMovePos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_touchMovePos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_touchMovePos.Location = new System.Drawing.Point(333, 354);
            this.btn_touchMovePos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_touchMovePos.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_touchMovePos.Name = "btn_touchMovePos";
            this.btn_touchMovePos.Size = new System.Drawing.Size(60, 30);
            this.btn_touchMovePos.Style = Sunny.UI.UIStyle.Custom;
            this.btn_touchMovePos.TabIndex = 100134;
            this.btn_touchMovePos.Text = "示教";
            this.btn_touchMovePos.Click += new System.EventHandler(this.btn_touchMovePos_Click);
            // 
            // btn_touchRotatePos
            // 
            this.btn_touchRotatePos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_touchRotatePos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_touchRotatePos.Location = new System.Drawing.Point(130, 353);
            this.btn_touchRotatePos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_touchRotatePos.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_touchRotatePos.Name = "btn_touchRotatePos";
            this.btn_touchRotatePos.Size = new System.Drawing.Size(60, 30);
            this.btn_touchRotatePos.Style = Sunny.UI.UIStyle.Custom;
            this.btn_touchRotatePos.TabIndex = 100135;
            this.btn_touchRotatePos.Text = "示教";
            this.btn_touchRotatePos.Click += new System.EventHandler(this.btn_touchRotatePos_Click);
            // 
            // btn_goMovePos
            // 
            this.btn_goMovePos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_goMovePos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_goMovePos.Location = new System.Drawing.Point(333, 389);
            this.btn_goMovePos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_goMovePos.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_goMovePos.Name = "btn_goMovePos";
            this.btn_goMovePos.Size = new System.Drawing.Size(60, 30);
            this.btn_goMovePos.Style = Sunny.UI.UIStyle.Custom;
            this.btn_goMovePos.TabIndex = 100137;
            this.btn_goMovePos.Text = "Go";
            this.btn_goMovePos.Click += new System.EventHandler(this.btn_goMovePos_Click);
            // 
            // btn_goRotatePos
            // 
            this.btn_goRotatePos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_goRotatePos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_goRotatePos.Location = new System.Drawing.Point(130, 388);
            this.btn_goRotatePos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_goRotatePos.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_goRotatePos.Name = "btn_goRotatePos";
            this.btn_goRotatePos.Size = new System.Drawing.Size(60, 30);
            this.btn_goRotatePos.Style = Sunny.UI.UIStyle.Custom;
            this.btn_goRotatePos.TabIndex = 100138;
            this.btn_goRotatePos.Text = "Go";
            this.btn_goRotatePos.Click += new System.EventHandler(this.btn_goRotatePos_Click);
            // 
            // tbx_moveU
            // 
            this.tbx_moveU.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_moveU.FillColor = System.Drawing.Color.White;
            this.tbx_moveU.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_moveU.Location = new System.Drawing.Point(249, 441);
            this.tbx_moveU.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_moveU.Maximum = 2147483647D;
            this.tbx_moveU.Minimum = -2147483648D;
            this.tbx_moveU.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_moveU.Name = "tbx_moveU";
            this.tbx_moveU.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_moveU.Radius = 0;
            this.tbx_moveU.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_moveU.Size = new System.Drawing.Size(75, 27);
            this.tbx_moveU.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_moveU.TabIndex = 100143;
            this.tbx_moveU.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_moveU.Watermark = "";
            this.tbx_moveU.TextChanged += new System.EventHandler(this.tbx_moveU_TextChanged);
            // 
            // tbx_moveZ
            // 
            this.tbx_moveZ.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_moveZ.FillColor = System.Drawing.Color.White;
            this.tbx_moveZ.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_moveZ.Location = new System.Drawing.Point(249, 412);
            this.tbx_moveZ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_moveZ.Maximum = 2147483647D;
            this.tbx_moveZ.Minimum = -2147483648D;
            this.tbx_moveZ.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_moveZ.Name = "tbx_moveZ";
            this.tbx_moveZ.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_moveZ.Radius = 0;
            this.tbx_moveZ.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_moveZ.Size = new System.Drawing.Size(75, 27);
            this.tbx_moveZ.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_moveZ.TabIndex = 100142;
            this.tbx_moveZ.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_moveZ.Watermark = "";
            this.tbx_moveZ.TextChanged += new System.EventHandler(this.tbx_moveZ_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(222, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 20);
            this.label3.TabIndex = 100141;
            this.label3.Text = "U :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(222, 416);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 20);
            this.label13.TabIndex = 100140;
            this.label13.Text = "Z :";
            // 
            // tbx_rotateU
            // 
            this.tbx_rotateU.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_rotateU.FillColor = System.Drawing.Color.White;
            this.tbx_rotateU.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_rotateU.Location = new System.Drawing.Point(46, 440);
            this.tbx_rotateU.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_rotateU.Maximum = 2147483647D;
            this.tbx_rotateU.Minimum = -2147483648D;
            this.tbx_rotateU.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_rotateU.Name = "tbx_rotateU";
            this.tbx_rotateU.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_rotateU.Radius = 0;
            this.tbx_rotateU.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_rotateU.Size = new System.Drawing.Size(75, 27);
            this.tbx_rotateU.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_rotateU.TabIndex = 100147;
            this.tbx_rotateU.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_rotateU.Watermark = "";
            this.tbx_rotateU.TextChanged += new System.EventHandler(this.tbx_rotateU_TextChanged);
            // 
            // tbx_rotateZ
            // 
            this.tbx_rotateZ.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_rotateZ.FillColor = System.Drawing.Color.White;
            this.tbx_rotateZ.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_rotateZ.Location = new System.Drawing.Point(46, 411);
            this.tbx_rotateZ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_rotateZ.Maximum = 2147483647D;
            this.tbx_rotateZ.Minimum = -2147483648D;
            this.tbx_rotateZ.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_rotateZ.Name = "tbx_rotateZ";
            this.tbx_rotateZ.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_rotateZ.Radius = 0;
            this.tbx_rotateZ.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_rotateZ.Size = new System.Drawing.Size(75, 27);
            this.tbx_rotateZ.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_rotateZ.TabIndex = 100146;
            this.tbx_rotateZ.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_rotateZ.Watermark = "";
            this.tbx_rotateZ.TextChanged += new System.EventHandler(this.tbx_rotateZ_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(19, 444);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 20);
            this.label14.TabIndex = 100145;
            this.label14.Text = "U :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(19, 415);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 20);
            this.label16.TabIndex = 100144;
            this.label16.Text = "Z :";
            // 
            // Frm_CalibType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 522);
            this.Controls.Add(this.tbx_rotateU);
            this.Controls.Add(this.tbx_rotateZ);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tbx_moveU);
            this.Controls.Add(this.tbx_moveZ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn_goRotatePos);
            this.Controls.Add(this.btn_goMovePos);
            this.Controls.Add(this.btn_touchRotatePos);
            this.Controls.Add(this.btn_touchMovePos);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.tbx_rotateSpan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbx_rotateY);
            this.Controls.Add(this.tbx_rotateX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbx_moveSpan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbx_moveY);
            this.Controls.Add(this.tbx_moveX);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbx_cameraList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_calibMode);
            this.Controls.Add(this.cbx_calibType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label147);
            this.Controls.Add(this.uiLine5);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.MinimizeBox = false;
            this.Name = "Frm_CalibType";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowIcon = true;
            this.ShowInTaskbar = false;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "标定场景";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_MorePar_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILine uiLine5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label147;
        internal Sunny.UI.UIComboBox cbx_calibType;
        internal Sunny.UI.UIComboBox cbx_calibMode;
        internal Sunny.UI.UIComboBox cbx_cameraList;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UITextBox tbx_rotateSpan;
        public System.Windows.Forms.Label label5;
        private Sunny.UI.UITextBox tbx_rotateY;
        private Sunny.UI.UITextBox tbx_rotateX;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        private Sunny.UI.UITextBox tbx_moveSpan;
        public System.Windows.Forms.Label label4;
        private Sunny.UI.UITextBox tbx_moveY;
        private Sunny.UI.UITextBox tbx_moveX;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine1;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label15;
        internal Sunny.UI.UIButton btn_touchMovePos;
        internal Sunny.UI.UIButton btn_touchRotatePos;
        internal Sunny.UI.UIButton btn_goMovePos;
        internal Sunny.UI.UIButton btn_goRotatePos;
        private Sunny.UI.UITextBox tbx_moveU;
        private Sunny.UI.UITextBox tbx_moveZ;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label13;
        private Sunny.UI.UITextBox tbx_rotateU;
        private Sunny.UI.UITextBox tbx_rotateZ;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label16;
    }
}