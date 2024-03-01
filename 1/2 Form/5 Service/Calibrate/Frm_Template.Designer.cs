namespace VM_Pro
{
    partial class Frm_Template
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.btn_resetTemplate = new Sunny.UI.UIButton();
            this.btn_drawCircle = new Sunny.UI.UIButton();
            this.btn_drawRectangle2 = new Sunny.UI.UIButton();
            this.rdo_baseLineCross = new Sunny.UI.UIRadioButton();
            this.rdo_basedCircleCenter = new Sunny.UI.UIRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_drawRectangle1 = new Sunny.UI.UIButton();
            this.btn_getBoardPos = new Sunny.UI.UIButton();
            this.btn_showBoardPos = new Sunny.UI.UIButton();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine1 = new Sunny.UI.UILine();
            this.panel4.SuspendLayout();
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
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.hWindowControl1);
            this.panel4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(173, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(223, 174);
            this.panel4.TabIndex = 100102;
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(221, 172);
            this.hWindowControl1.TabIndex = 0;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(221, 172);
            // 
            // btn_resetTemplate
            // 
            this.btn_resetTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_resetTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_resetTemplate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_resetTemplate.Location = new System.Drawing.Point(92, 196);
            this.btn_resetTemplate.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_resetTemplate.Name = "btn_resetTemplate";
            this.btn_resetTemplate.Size = new System.Drawing.Size(70, 30);
            this.btn_resetTemplate.Style = Sunny.UI.UIStyle.Custom;
            this.btn_resetTemplate.TabIndex = 100107;
            this.btn_resetTemplate.Text = "复位";
            this.btn_resetTemplate.Click += new System.EventHandler(this.btn_resetTemplate_Click);
            // 
            // btn_drawCircle
            // 
            this.btn_drawCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_drawCircle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_drawCircle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_drawCircle.Location = new System.Drawing.Point(19, 266);
            this.btn_drawCircle.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_drawCircle.Name = "btn_drawCircle";
            this.btn_drawCircle.Size = new System.Drawing.Size(70, 30);
            this.btn_drawCircle.Style = Sunny.UI.UIStyle.Custom;
            this.btn_drawCircle.TabIndex = 100104;
            this.btn_drawCircle.Text = "圆";
            this.btn_drawCircle.Click += new System.EventHandler(this.btn_drawCircle_Click);
            // 
            // btn_drawRectangle2
            // 
            this.btn_drawRectangle2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_drawRectangle2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_drawRectangle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_drawRectangle2.Location = new System.Drawing.Point(165, 266);
            this.btn_drawRectangle2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_drawRectangle2.Name = "btn_drawRectangle2";
            this.btn_drawRectangle2.Size = new System.Drawing.Size(70, 30);
            this.btn_drawRectangle2.Style = Sunny.UI.UIStyle.Custom;
            this.btn_drawRectangle2.TabIndex = 100103;
            this.btn_drawRectangle2.Text = "仿矩";
            this.btn_drawRectangle2.Click += new System.EventHandler(this.btn_drawRectangle2_Click);
            // 
            // rdo_baseLineCross
            // 
            this.rdo_baseLineCross.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_baseLineCross.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_baseLineCross.GroupIndex = 2;
            this.rdo_baseLineCross.Location = new System.Drawing.Point(106, 72);
            this.rdo_baseLineCross.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_baseLineCross.Name = "rdo_baseLineCross";
            this.rdo_baseLineCross.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_baseLineCross.Size = new System.Drawing.Size(64, 27);
            this.rdo_baseLineCross.Style = Sunny.UI.UIStyle.Custom;
            this.rdo_baseLineCross.TabIndex = 100118;
            this.rdo_baseLineCross.Text = "交点";
            this.rdo_baseLineCross.Click += new System.EventHandler(this.rdo_baseLineCross_Click);
            // 
            // rdo_basedCircleCenter
            // 
            this.rdo_basedCircleCenter.Checked = true;
            this.rdo_basedCircleCenter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_basedCircleCenter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_basedCircleCenter.GroupIndex = 2;
            this.rdo_basedCircleCenter.Location = new System.Drawing.Point(16, 72);
            this.rdo_basedCircleCenter.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_basedCircleCenter.Name = "rdo_basedCircleCenter";
            this.rdo_basedCircleCenter.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_basedCircleCenter.Size = new System.Drawing.Size(64, 27);
            this.rdo_basedCircleCenter.Style = Sunny.UI.UIStyle.Custom;
            this.rdo_basedCircleCenter.TabIndex = 100119;
            this.rdo_basedCircleCenter.Text = "圆心";
            this.rdo_basedCircleCenter.Click += new System.EventHandler(this.rdo_basedCircleCenter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 100121;
            this.label1.Text = "特征点 :";
            // 
            // btn_drawRectangle1
            // 
            this.btn_drawRectangle1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_drawRectangle1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_drawRectangle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_drawRectangle1.Location = new System.Drawing.Point(92, 266);
            this.btn_drawRectangle1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_drawRectangle1.Name = "btn_drawRectangle1";
            this.btn_drawRectangle1.Size = new System.Drawing.Size(70, 30);
            this.btn_drawRectangle1.Style = Sunny.UI.UIStyle.Custom;
            this.btn_drawRectangle1.TabIndex = 100128;
            this.btn_drawRectangle1.Text = "矩形";
            this.btn_drawRectangle1.Click += new System.EventHandler(this.btn_drawRectangle1_Click);
            // 
            // btn_getBoardPos
            // 
            this.btn_getBoardPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_getBoardPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_getBoardPos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_getBoardPos.Location = new System.Drawing.Point(19, 401);
            this.btn_getBoardPos.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_getBoardPos.Name = "btn_getBoardPos";
            this.btn_getBoardPos.Size = new System.Drawing.Size(95, 40);
            this.btn_getBoardPos.Style = Sunny.UI.UIStyle.Custom;
            this.btn_getBoardPos.TabIndex = 100129;
            this.btn_getBoardPos.Text = "记录标定位";
            this.btn_getBoardPos.Click += new System.EventHandler(this.btn_getBoardPos_Click);
            // 
            // btn_showBoardPos
            // 
            this.btn_showBoardPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_showBoardPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_showBoardPos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_showBoardPos.Location = new System.Drawing.Point(19, 444);
            this.btn_showBoardPos.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_showBoardPos.Name = "btn_showBoardPos";
            this.btn_showBoardPos.Size = new System.Drawing.Size(95, 40);
            this.btn_showBoardPos.Style = Sunny.UI.UIStyle.Custom;
            this.btn_showBoardPos.TabIndex = 100130;
            this.btn_showBoardPos.Text = "显示标定位";
            this.btn_showBoardPos.Click += new System.EventHandler(this.btn_showBoardPos_Click);
            // 
            // uiLine2
            // 
            this.uiLine2.FillColor = System.Drawing.Color.White;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uiLine2.Location = new System.Drawing.Point(19, 233);
            this.uiLine2.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(246, 29);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 100131;
            this.uiLine2.Text = "模板类型";
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine1
            // 
            this.uiLine1.FillColor = System.Drawing.Color.White;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uiLine1.Location = new System.Drawing.Point(16, 366);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(246, 29);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 100132;
            this.uiLine1.Text = "标定板";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 522);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.btn_showBoardPos);
            this.Controls.Add(this.btn_getBoardPos);
            this.Controls.Add(this.btn_drawRectangle1);
            this.Controls.Add(this.rdo_basedCircleCenter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btn_resetTemplate);
            this.Controls.Add(this.btn_drawCircle);
            this.Controls.Add(this.btn_drawRectangle2);
            this.Controls.Add(this.uiLine5);
            this.Controls.Add(this.rdo_baseLineCross);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(52, 10);
            this.Name = "Frm_Template";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowIcon = true;
            this.ShowInTaskbar = false;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "模板相关";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_MorePar_FormClosing);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILine uiLine5;
        private System.Windows.Forms.Panel panel4;
        internal HalconDotNet.HWindowControl hWindowControl1;
        internal Sunny.UI.UIButton btn_resetTemplate;
        internal Sunny.UI.UIButton btn_drawCircle;
        internal Sunny.UI.UIButton btn_drawRectangle2;
        internal Sunny.UI.UIRadioButton rdo_baseLineCross;
        internal Sunny.UI.UIRadioButton rdo_basedCircleCenter;
        private System.Windows.Forms.Label label1;
        internal Sunny.UI.UIButton btn_drawRectangle1;
        internal Sunny.UI.UIButton btn_getBoardPos;
        internal Sunny.UI.UIButton btn_showBoardPos;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine1;
    }
}