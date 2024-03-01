namespace VM_Pro
{
    partial class Frm_TaskInfo
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
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.cbx_imageWindow = new Sunny.UI.UIComboBox();
            this.cbx_trigMode = new Sunny.UI.UIComboBox();
            this.tbx_trigCmd = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLine5 = new Sunny.UI.UILine();
            this.cbx_portList = new Sunny.UI.UIComboBox();
            this.ckb_showRunStatu = new Sunny.UI.UICheckBox();
            this.SuspendLayout();
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(16, 55);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(105, 24);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 133;
            this.uiLabel2.Text = "图像窗口 ：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(16, 89);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(105, 24);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 135;
            this.uiLabel3.Text = "触发方式 ：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbx_imageWindow
            // 
            this.cbx_imageWindow.DataSource = null;
            this.cbx_imageWindow.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_imageWindow.FillColor = System.Drawing.Color.White;
            this.cbx_imageWindow.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_imageWindow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_imageWindow.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_imageWindow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_imageWindow.Location = new System.Drawing.Point(92, 52);
            this.cbx_imageWindow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_imageWindow.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_imageWindow.Name = "cbx_imageWindow";
            this.cbx_imageWindow.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_imageWindow.Radius = 0;
            this.cbx_imageWindow.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_imageWindow.RectColor = System.Drawing.Color.Silver;
            this.cbx_imageWindow.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_imageWindow.Size = new System.Drawing.Size(222, 30);
            this.cbx_imageWindow.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_imageWindow.TabIndex = 139;
            this.cbx_imageWindow.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_imageWindow.Watermark = "";
            this.cbx_imageWindow.SelectedIndexChanged += new System.EventHandler(this.cbx_imageWindow_SelectedIndexChanged);
            // 
            // cbx_trigMode
            // 
            this.cbx_trigMode.DataSource = null;
            this.cbx_trigMode.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_trigMode.FillColor = System.Drawing.Color.White;
            this.cbx_trigMode.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_trigMode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_trigMode.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_trigMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_trigMode.Items.AddRange(new object[] {
            "不触发",
            "启动时触发",
            "以太网触发",
            "相机硬触发"});
            this.cbx_trigMode.Location = new System.Drawing.Point(92, 87);
            this.cbx_trigMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_trigMode.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_trigMode.Name = "cbx_trigMode";
            this.cbx_trigMode.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_trigMode.Radius = 0;
            this.cbx_trigMode.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_trigMode.RectColor = System.Drawing.Color.Silver;
            this.cbx_trigMode.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_trigMode.Size = new System.Drawing.Size(112, 30);
            this.cbx_trigMode.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_trigMode.TabIndex = 54;
            this.cbx_trigMode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_trigMode.Watermark = "";
            this.cbx_trigMode.SelectedIndexChanged += new System.EventHandler(this.cbx_trigMode_SelectedIndexChanged);
            // 
            // tbx_trigCmd
            // 
            this.tbx_trigCmd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_trigCmd.FillColor = System.Drawing.Color.White;
            this.tbx_trigCmd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_trigCmd.Location = new System.Drawing.Point(419, 85);
            this.tbx_trigCmd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_trigCmd.Maximum = 2147483647D;
            this.tbx_trigCmd.Minimum = -2147483648D;
            this.tbx_trigCmd.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_trigCmd.Name = "tbx_trigCmd";
            this.tbx_trigCmd.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.tbx_trigCmd.Radius = 0;
            this.tbx_trigCmd.RectColor = System.Drawing.Color.Silver;
            this.tbx_trigCmd.Size = new System.Drawing.Size(136, 31);
            this.tbx_trigCmd.Style = Sunny.UI.UIStyle.Custom;
            this.tbx_trigCmd.TabIndex = 141;
            this.tbx_trigCmd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbx_trigCmd.Watermark = "触发指令";
            this.tbx_trigCmd.TextChanged += new System.EventHandler(this.tbx_trigCmd_TextChanged);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(207, 89);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(69, 24);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 142;
            this.uiLabel1.Text = "端口 ：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(374, 89);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(69, 24);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 143;
            this.uiLabel4.Text = "指令 ：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine5
            // 
            this.uiLine5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine5.LineSize = 2;
            this.uiLine5.Location = new System.Drawing.Point(0, 368);
            this.uiLine5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine5.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(573, 2);
            this.uiLine5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine5.TabIndex = 144;
            this.uiLine5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbx_portList
            // 
            this.cbx_portList.DataSource = null;
            this.cbx_portList.FillColor = System.Drawing.Color.White;
            this.cbx_portList.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_portList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_portList.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_portList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_portList.Location = new System.Drawing.Point(252, 85);
            this.cbx_portList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_portList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_portList.Name = "cbx_portList";
            this.cbx_portList.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_portList.Radius = 0;
            this.cbx_portList.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_portList.RectColor = System.Drawing.Color.Silver;
            this.cbx_portList.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_portList.Size = new System.Drawing.Size(123, 30);
            this.cbx_portList.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_portList.TabIndex = 145;
            this.cbx_portList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_portList.Watermark = "触发端口";
            this.cbx_portList.SelectedIndexChanged += new System.EventHandler(this.cbx_portList_SelectedIndexChanged);
            // 
            // ckb_showRunStatu
            // 
            this.ckb_showRunStatu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_showRunStatu.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_showRunStatu.Location = new System.Drawing.Point(17, 127);
            this.ckb_showRunStatu.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_showRunStatu.Name = "ckb_showRunStatu";
            this.ckb_showRunStatu.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_showRunStatu.Size = new System.Drawing.Size(141, 30);
            this.ckb_showRunStatu.Style = Sunny.UI.UIStyle.Custom;
            this.ckb_showRunStatu.TabIndex = 179;
            this.ckb_showRunStatu.Text = "显示运行状态";
            this.ckb_showRunStatu.CheckedChanged += new System.EventHandler(this.ckb_showRunStatu_CheckedChanged);
            // 
            // Frm_TaskInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(573, 370);
            this.Controls.Add(this.ckb_showRunStatu);
            this.Controls.Add(this.cbx_portList);
            this.Controls.Add(this.uiLine5);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.tbx_trigCmd);
            this.Controls.Add(this.cbx_trigMode);
            this.Controls.Add(this.cbx_imageWindow);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel4);
            this.ExtendSymbolSize = 20;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.MinimizeBox = false;
            this.Name = "Frm_TaskInfo";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowInTaskbar = false;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "任务属性";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.Load += new System.EventHandler(this.Frm_TaskInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        internal Sunny.UI.UIComboBox cbx_imageWindow;
        internal Sunny.UI.UIComboBox cbx_trigMode;
        private Sunny.UI.UITextBox tbx_trigCmd;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILine uiLine5;
        internal Sunny.UI.UIComboBox cbx_portList;
        private Sunny.UI.UICheckBox ckb_showRunStatu;
    }
}