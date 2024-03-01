namespace VM_Pro
{
    partial class Frm_PieceImage
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
            this.cbx_pieceType = new Sunny.UI.UIComboBox();
            this.btn_saveImage = new Sunny.UI.UIButton();
            this.btn_grabLoop = new Sunny.UI.UIButton();
            this.label147 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.ckb_hardTrig = new Sunny.UI.UICheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_leftUp = new Sunny.UI.UIComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_rightUp = new Sunny.UI.UIComboBox();
            this.cbx_leftDown = new Sunny.UI.UIComboBox();
            this.cbx_rightDown = new Sunny.UI.UIComboBox();
            this.nud_exposureLeftUp = new Controls.CNumericUpDown();
            this.label148 = new System.Windows.Forms.Label();
            this.nud_exposureRightUp = new Controls.CNumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_exposureLeftDown = new Controls.CNumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nud_exposureRightDown = new Controls.CNumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.ckb_pieceImage = new Sunny.UI.UICheckBox();
            this.SuspendLayout();
            // 
            // cbx_pieceType
            // 
            this.cbx_pieceType.DataSource = null;
            this.cbx_pieceType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_pieceType.DropDownWidth = 155;
            this.cbx_pieceType.FillColor = System.Drawing.Color.White;
            this.cbx_pieceType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_pieceType.Items.AddRange(new object[] {
            "双相机拼接（上下拼接）",
            "双相机拼接（左右拼接）",
            "四相机拼接"});
            this.cbx_pieceType.Location = new System.Drawing.Point(71, 35);
            this.cbx_pieceType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_pieceType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_pieceType.Name = "cbx_pieceType";
            this.cbx_pieceType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_pieceType.Radius = 0;
            this.cbx_pieceType.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbx_pieceType.Size = new System.Drawing.Size(221, 28);
            this.cbx_pieceType.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_pieceType.TabIndex = 215;
            this.cbx_pieceType.Text = "双相机拼接（上下拼接）";
            this.cbx_pieceType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_pieceType.Watermark = "";
            this.cbx_pieceType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_pieceType.SelectedIndexChanged += new System.EventHandler(this.cbx_pieceType_SelectedIndexChanged);
            // 
            // btn_saveImage
            // 
            this.btn_saveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_saveImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_saveImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_saveImage.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_saveImage.Location = new System.Drawing.Point(91, 233);
            this.btn_saveImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_saveImage.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_saveImage.Name = "btn_saveImage";
            this.btn_saveImage.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_saveImage.Size = new System.Drawing.Size(80, 34);
            this.btn_saveImage.Style = Sunny.UI.UIStyle.Custom;
            this.btn_saveImage.TabIndex = 211;
            this.btn_saveImage.Text = "保存图像";
            this.btn_saveImage.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_saveImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_saveImage.Click += new System.EventHandler(this.btn_saveImage_Click);
            // 
            // btn_grabLoop
            // 
            this.btn_grabLoop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_grabLoop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_grabLoop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_grabLoop.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_grabLoop.Location = new System.Drawing.Point(6, 233);
            this.btn_grabLoop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_grabLoop.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_grabLoop.Name = "btn_grabLoop";
            this.btn_grabLoop.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_grabLoop.Size = new System.Drawing.Size(80, 34);
            this.btn_grabLoop.Style = Sunny.UI.UIStyle.Custom;
            this.btn_grabLoop.TabIndex = 209;
            this.btn_grabLoop.Text = "相机实时";
            this.btn_grabLoop.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_grabLoop.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_grabLoop.Click += new System.EventHandler(this.btn_grabLoop_Click);
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label147.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label147.Location = new System.Drawing.Point(72, 64);
            this.label147.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(82, 24);
            this.label147.TabIndex = 204;
            this.label147.Text = "相机选择";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label123.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label123.Location = new System.Drawing.Point(0, 35);
            this.label123.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(100, 24);
            this.label123.TabIndex = 206;
            this.label123.Text = "拼接模式：";
            // 
            // ckb_hardTrig
            // 
            this.ckb_hardTrig.Checked = true;
            this.ckb_hardTrig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_hardTrig.Enabled = false;
            this.ckb_hardTrig.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_hardTrig.Location = new System.Drawing.Point(4, 355);
            this.ckb_hardTrig.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_hardTrig.Name = "ckb_hardTrig";
            this.ckb_hardTrig.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_hardTrig.Size = new System.Drawing.Size(334, 24);
            this.ckb_hardTrig.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_hardTrig.TabIndex = 216;
            this.ckb_hardTrig.Text = "勾选：硬触发 | 不勾选：软触发【跟随服务选择】";
            this.ckb_hardTrig.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_hardTrig.CheckedChanged += new System.EventHandler(this.ckb_hardTrig_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(192, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 217;
            this.label1.Text = "曝光时间";
            // 
            // cbx_leftUp
            // 
            this.cbx_leftUp.DataSource = null;
            this.cbx_leftUp.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_leftUp.DropDownWidth = 115;
            this.cbx_leftUp.FillColor = System.Drawing.Color.White;
            this.cbx_leftUp.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_leftUp.Location = new System.Drawing.Point(71, 90);
            this.cbx_leftUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_leftUp.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_leftUp.Name = "cbx_leftUp";
            this.cbx_leftUp.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_leftUp.Radius = 0;
            this.cbx_leftUp.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbx_leftUp.Size = new System.Drawing.Size(115, 28);
            this.cbx_leftUp.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_leftUp.TabIndex = 218;
            this.cbx_leftUp.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_leftUp.Watermark = "";
            this.cbx_leftUp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_leftUp.SelectedIndexChanged += new System.EventHandler(this.cbx_leftUp_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(0, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 219;
            this.label2.Text = "左上相机：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(0, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 220;
            this.label3.Text = "右上相机：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(0, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 221;
            this.label4.Text = "左下相机：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label5.Location = new System.Drawing.Point(0, 195);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 24);
            this.label5.TabIndex = 222;
            this.label5.Text = "右下相机：";
            // 
            // cbx_rightUp
            // 
            this.cbx_rightUp.DataSource = null;
            this.cbx_rightUp.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_rightUp.DropDownWidth = 115;
            this.cbx_rightUp.FillColor = System.Drawing.Color.White;
            this.cbx_rightUp.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_rightUp.Location = new System.Drawing.Point(71, 125);
            this.cbx_rightUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_rightUp.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_rightUp.Name = "cbx_rightUp";
            this.cbx_rightUp.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_rightUp.Radius = 0;
            this.cbx_rightUp.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbx_rightUp.Size = new System.Drawing.Size(115, 28);
            this.cbx_rightUp.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_rightUp.TabIndex = 223;
            this.cbx_rightUp.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_rightUp.Watermark = "";
            this.cbx_rightUp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_rightUp.SelectedIndexChanged += new System.EventHandler(this.cbx_rightUp_SelectedIndexChanged);
            // 
            // cbx_leftDown
            // 
            this.cbx_leftDown.DataSource = null;
            this.cbx_leftDown.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_leftDown.DropDownWidth = 115;
            this.cbx_leftDown.FillColor = System.Drawing.Color.White;
            this.cbx_leftDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_leftDown.Location = new System.Drawing.Point(71, 159);
            this.cbx_leftDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_leftDown.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_leftDown.Name = "cbx_leftDown";
            this.cbx_leftDown.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_leftDown.Radius = 0;
            this.cbx_leftDown.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbx_leftDown.Size = new System.Drawing.Size(115, 28);
            this.cbx_leftDown.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_leftDown.TabIndex = 219;
            this.cbx_leftDown.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_leftDown.Watermark = "";
            this.cbx_leftDown.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_leftDown.SelectedIndexChanged += new System.EventHandler(this.cbx_leftDown_SelectedIndexChanged);
            // 
            // cbx_rightDown
            // 
            this.cbx_rightDown.DataSource = null;
            this.cbx_rightDown.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_rightDown.DropDownWidth = 115;
            this.cbx_rightDown.FillColor = System.Drawing.Color.White;
            this.cbx_rightDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_rightDown.Location = new System.Drawing.Point(71, 193);
            this.cbx_rightDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_rightDown.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_rightDown.Name = "cbx_rightDown";
            this.cbx_rightDown.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_rightDown.Radius = 0;
            this.cbx_rightDown.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbx_rightDown.Size = new System.Drawing.Size(115, 28);
            this.cbx_rightDown.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_rightDown.TabIndex = 219;
            this.cbx_rightDown.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_rightDown.Watermark = "";
            this.cbx_rightDown.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_rightDown.SelectedIndexChanged += new System.EventHandler(this.cbx_rightDown_SelectedIndexChanged);
            // 
            // nud_exposureLeftUp
            // 
            this.nud_exposureLeftUp.BackColor = System.Drawing.Color.White;
            this.nud_exposureLeftUp.DecimalPlaces = 0;
            this.nud_exposureLeftUp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_exposureLeftUp.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_exposureLeftUp.Location = new System.Drawing.Point(189, 88);
            this.nud_exposureLeftUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_exposureLeftUp.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_exposureLeftUp.MaxValue = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nud_exposureLeftUp.MinimumSize = new System.Drawing.Size(50, 26);
            this.nud_exposureLeftUp.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_exposureLeftUp.Name = "nud_exposureLeftUp";
            this.nud_exposureLeftUp.Size = new System.Drawing.Size(103, 26);
            this.nud_exposureLeftUp.TabIndex = 225;
            this.nud_exposureLeftUp.TabStop = false;
            this.nud_exposureLeftUp.Value = 1D;
            this.nud_exposureLeftUp.ValueChanged += new Controls.DValueChanged(this.nud_exposureLeftUp_ValueChanged);
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label148.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label148.Location = new System.Drawing.Point(292, 99);
            this.label148.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(40, 24);
            this.label148.TabIndex = 224;
            this.label148.Text = " ms";
            // 
            // nud_exposureRightUp
            // 
            this.nud_exposureRightUp.BackColor = System.Drawing.Color.White;
            this.nud_exposureRightUp.DecimalPlaces = 0;
            this.nud_exposureRightUp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_exposureRightUp.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_exposureRightUp.Location = new System.Drawing.Point(189, 124);
            this.nud_exposureRightUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_exposureRightUp.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_exposureRightUp.MaxValue = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nud_exposureRightUp.MinimumSize = new System.Drawing.Size(50, 26);
            this.nud_exposureRightUp.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_exposureRightUp.Name = "nud_exposureRightUp";
            this.nud_exposureRightUp.Size = new System.Drawing.Size(103, 26);
            this.nud_exposureRightUp.TabIndex = 227;
            this.nud_exposureRightUp.TabStop = false;
            this.nud_exposureRightUp.Value = 1D;
            this.nud_exposureRightUp.ValueChanged += new Controls.DValueChanged(this.nud_exposureRightUp_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label6.Location = new System.Drawing.Point(292, 131);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 24);
            this.label6.TabIndex = 226;
            this.label6.Text = " ms";
            // 
            // nud_exposureLeftDown
            // 
            this.nud_exposureLeftDown.BackColor = System.Drawing.Color.White;
            this.nud_exposureLeftDown.DecimalPlaces = 0;
            this.nud_exposureLeftDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_exposureLeftDown.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_exposureLeftDown.Location = new System.Drawing.Point(189, 158);
            this.nud_exposureLeftDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_exposureLeftDown.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_exposureLeftDown.MaxValue = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nud_exposureLeftDown.MinimumSize = new System.Drawing.Size(50, 26);
            this.nud_exposureLeftDown.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_exposureLeftDown.Name = "nud_exposureLeftDown";
            this.nud_exposureLeftDown.Size = new System.Drawing.Size(103, 26);
            this.nud_exposureLeftDown.TabIndex = 229;
            this.nud_exposureLeftDown.TabStop = false;
            this.nud_exposureLeftDown.Value = 1D;
            this.nud_exposureLeftDown.ValueChanged += new Controls.DValueChanged(this.nud_exposureLeftDown_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label7.Location = new System.Drawing.Point(292, 163);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 24);
            this.label7.TabIndex = 228;
            this.label7.Text = " ms";
            // 
            // nud_exposureRightDown
            // 
            this.nud_exposureRightDown.BackColor = System.Drawing.Color.White;
            this.nud_exposureRightDown.DecimalPlaces = 0;
            this.nud_exposureRightDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_exposureRightDown.Incremeent = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_exposureRightDown.Location = new System.Drawing.Point(189, 192);
            this.nud_exposureRightDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_exposureRightDown.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_exposureRightDown.MaxValue = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nud_exposureRightDown.MinimumSize = new System.Drawing.Size(50, 26);
            this.nud_exposureRightDown.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_exposureRightDown.Name = "nud_exposureRightDown";
            this.nud_exposureRightDown.Size = new System.Drawing.Size(103, 26);
            this.nud_exposureRightDown.TabIndex = 231;
            this.nud_exposureRightDown.TabStop = false;
            this.nud_exposureRightDown.Value = 1D;
            this.nud_exposureRightDown.ValueChanged += new Controls.DValueChanged(this.nud_exposureRightDown_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label8.Location = new System.Drawing.Point(292, 195);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 24);
            this.label8.TabIndex = 230;
            this.label8.Text = " ms";
            // 
            // ckb_pieceImage
            // 
            this.ckb_pieceImage.Checked = true;
            this.ckb_pieceImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_pieceImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_pieceImage.Location = new System.Drawing.Point(4, 326);
            this.ckb_pieceImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_pieceImage.Name = "ckb_pieceImage";
            this.ckb_pieceImage.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_pieceImage.Size = new System.Drawing.Size(98, 24);
            this.ckb_pieceImage.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_pieceImage.TabIndex = 232;
            this.ckb_pieceImage.Text = "图像拼接";
            this.ckb_pieceImage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_pieceImage.Click += new System.EventHandler(this.ckb_pieceImage_Click);
            // 
            // Frm_PieceImage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(348, 379);
            this.Controls.Add(this.ckb_pieceImage);
            this.Controls.Add(this.nud_exposureRightDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nud_exposureLeftDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nud_exposureRightUp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nud_exposureLeftUp);
            this.Controls.Add(this.label148);
            this.Controls.Add(this.cbx_rightDown);
            this.Controls.Add(this.cbx_leftDown);
            this.Controls.Add(this.cbx_rightUp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_leftUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckb_hardTrig);
            this.Controls.Add(this.cbx_pieceType);
            this.Controls.Add(this.btn_saveImage);
            this.Controls.Add(this.btn_grabLoop);
            this.Controls.Add(this.label147);
            this.Controls.Add(this.label123);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_PieceImage";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "Form1";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 348, 379);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Sunny.UI.UIComboBox cbx_pieceType;
        private Sunny.UI.UIButton btn_saveImage;
        private System.Windows.Forms.Label label147;
        private System.Windows.Forms.Label label123;
        internal Sunny.UI.UICheckBox ckb_hardTrig;
        internal Sunny.UI.UIButton btn_grabLoop;
        private System.Windows.Forms.Label label1;
        internal Sunny.UI.UIComboBox cbx_leftUp;
        internal Sunny.UI.UIComboBox cbx_rightUp;
        internal Sunny.UI.UIComboBox cbx_leftDown;
        internal Sunny.UI.UIComboBox cbx_rightDown;
        internal Controls.CNumericUpDown nud_exposureLeftUp;
        private System.Windows.Forms.Label label148;
        internal Controls.CNumericUpDown nud_exposureRightUp;
        private System.Windows.Forms.Label label6;
        internal Controls.CNumericUpDown nud_exposureLeftDown;
        internal Controls.CNumericUpDown nud_exposureRightDown;
        internal Sunny.UI.UICheckBox ckb_pieceImage;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
    }
}