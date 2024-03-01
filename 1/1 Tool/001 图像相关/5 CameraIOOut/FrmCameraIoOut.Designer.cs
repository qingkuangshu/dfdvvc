namespace VM_Pro
{
    partial class FrmCameraIoOut
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
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.btn_close = new Sunny.UI.UIButton();
            this.ckb_taskFailKeepRun = new Sunny.UI.UICheckBox();
            this.btn_runTool = new Sunny.UI.UIButton();
            this.lbl_toolTip = new Sunny.UI.UILabel();
            this.lbl_runTime = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txt_TimeOut = new Sunny.UI.UITextBox();
            this.uiComboBox1 = new Sunny.UI.UIComboBox();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.rad_Trigger = new Sunny.UI.UIRadioButton();
            this.rad_SuccessTrigger = new Sunny.UI.UIRadioButton();
            this.rad_FailTrigger = new Sunny.UI.UIRadioButton();
            this.uiPanel1.SuspendLayout();
            this.uiPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.btn_close);
            this.uiPanel1.Controls.Add(this.ckb_taskFailKeepRun);
            this.uiPanel1.Controls.Add(this.btn_runTool);
            this.uiPanel1.Controls.Add(this.lbl_toolTip);
            this.uiPanel1.Controls.Add(this.lbl_runTime);
            this.uiPanel1.Controls.Add(this.uiLabel9);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(0, 305);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(589, 62);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.Location = new System.Drawing.Point(499, 11);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 32);
            this.btn_close.TabIndex = 106;
            this.btn_close.Text = "关闭";
            this.btn_close.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // ckb_taskFailKeepRun
            // 
            this.ckb_taskFailKeepRun.Checked = true;
            this.ckb_taskFailKeepRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_taskFailKeepRun.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_taskFailKeepRun.Location = new System.Drawing.Point(164, 11);
            this.ckb_taskFailKeepRun.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_taskFailKeepRun.Name = "ckb_taskFailKeepRun";
            this.ckb_taskFailKeepRun.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_taskFailKeepRun.Size = new System.Drawing.Size(140, 24);
            this.ckb_taskFailKeepRun.TabIndex = 239;
            this.ckb_taskFailKeepRun.Text = "流程失败仍运行";
            this.ckb_taskFailKeepRun.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_taskFailKeepRun.Click += new System.EventHandler(this.ckb_taskFailKeepRun_Click);
            // 
            // btn_runTool
            // 
            this.btn_runTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_runTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runTool.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTool.Location = new System.Drawing.Point(386, 11);
            this.btn_runTool.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_runTool.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_runTool.Name = "btn_runTool";
            this.btn_runTool.Size = new System.Drawing.Size(75, 32);
            this.btn_runTool.TabIndex = 104;
            this.btn_runTool.Text = "运行工具";
            this.btn_runTool.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTool.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_runTool.Click += new System.EventHandler(this.btn_runTool_Click);
            // 
            // lbl_toolTip
            // 
            this.lbl_toolTip.BackColor = System.Drawing.Color.White;
            this.lbl_toolTip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_toolTip.Location = new System.Drawing.Point(15, 33);
            this.lbl_toolTip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_toolTip.Name = "lbl_toolTip";
            this.lbl_toolTip.Size = new System.Drawing.Size(322, 22);
            this.lbl_toolTip.TabIndex = 238;
            this.lbl_toolTip.Text = "暂无提示";
            this.lbl_toolTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_toolTip.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_runTime
            // 
            this.lbl_runTime.BackColor = System.Drawing.Color.White;
            this.lbl_runTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_runTime.Location = new System.Drawing.Point(70, 11);
            this.lbl_runTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_runTime.Name = "lbl_runTime";
            this.lbl_runTime.Size = new System.Drawing.Size(66, 22);
            this.lbl_runTime.TabIndex = 237;
            this.lbl_runTime.Text = "0 ms";
            this.lbl_runTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_runTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel9
            // 
            this.uiLabel9.BackColor = System.Drawing.Color.White;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(15, 10);
            this.uiLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(66, 22);
            this.uiLabel9.TabIndex = 236;
            this.uiLabel9.Text = "耗时：";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(86, 124);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(226, 23);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "UserOutputSelector：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(86, 170);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(209, 23);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "信号保存时间（ms）:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_TimeOut
            // 
            this.txt_TimeOut.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TimeOut.DoubleValue = 50D;
            this.txt_TimeOut.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_TimeOut.IntValue = 50;
            this.txt_TimeOut.Location = new System.Drawing.Point(298, 170);
            this.txt_TimeOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_TimeOut.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_TimeOut.Name = "txt_TimeOut";
            this.txt_TimeOut.ShowText = false;
            this.txt_TimeOut.Size = new System.Drawing.Size(181, 29);
            this.txt_TimeOut.TabIndex = 2;
            this.txt_TimeOut.Text = "50";
            this.txt_TimeOut.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_TimeOut.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_TimeOut.Watermark = "";
            this.txt_TimeOut.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiComboBox1
            // 
            this.uiComboBox1.DataSource = null;
            this.uiComboBox1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox1.FillColor = System.Drawing.Color.White;
            this.uiComboBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBox1.Items.AddRange(new object[] {
            "UserOutput2"});
            this.uiComboBox1.Location = new System.Drawing.Point(298, 124);
            this.uiComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox1.Size = new System.Drawing.Size(181, 29);
            this.uiComboBox1.TabIndex = 3;
            this.uiComboBox1.Text = "UserOutput2";
            this.uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox1.Watermark = "";
            this.uiComboBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.rad_FailTrigger);
            this.uiPanel2.Controls.Add(this.rad_SuccessTrigger);
            this.uiPanel2.Controls.Add(this.rad_Trigger);
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel2.Location = new System.Drawing.Point(19, 209);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(555, 68);
            this.uiPanel2.TabIndex = 4;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rad_Trigger
            // 
            this.rad_Trigger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rad_Trigger.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rad_Trigger.Location = new System.Drawing.Point(28, 26);
            this.rad_Trigger.MinimumSize = new System.Drawing.Size(1, 1);
            this.rad_Trigger.Name = "rad_Trigger";
            this.rad_Trigger.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rad_Trigger.Size = new System.Drawing.Size(155, 29);
            this.rad_Trigger.TabIndex = 0;
            this.rad_Trigger.TagString = "任务运行触发";
            this.rad_Trigger.Text = "任务运行触发";
            this.rad_Trigger.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rad_Trigger.Click += new System.EventHandler(this.uiRadioButton3_Click);
            // 
            // rad_SuccessTrigger
            // 
            this.rad_SuccessTrigger.Checked = true;
            this.rad_SuccessTrigger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rad_SuccessTrigger.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rad_SuccessTrigger.Location = new System.Drawing.Point(199, 26);
            this.rad_SuccessTrigger.MinimumSize = new System.Drawing.Size(1, 1);
            this.rad_SuccessTrigger.Name = "rad_SuccessTrigger";
            this.rad_SuccessTrigger.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rad_SuccessTrigger.Size = new System.Drawing.Size(155, 29);
            this.rad_SuccessTrigger.TabIndex = 0;
            this.rad_SuccessTrigger.TagString = "任务成功触发";
            this.rad_SuccessTrigger.Text = "任务成功触发";
            this.rad_SuccessTrigger.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rad_SuccessTrigger.Click += new System.EventHandler(this.uiRadioButton3_Click);
            // 
            // rad_FailTrigger
            // 
            this.rad_FailTrigger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rad_FailTrigger.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rad_FailTrigger.Location = new System.Drawing.Point(384, 26);
            this.rad_FailTrigger.MinimumSize = new System.Drawing.Size(1, 1);
            this.rad_FailTrigger.Name = "rad_FailTrigger";
            this.rad_FailTrigger.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rad_FailTrigger.Size = new System.Drawing.Size(155, 29);
            this.rad_FailTrigger.TabIndex = 0;
            this.rad_FailTrigger.TagString = "任务失败触发";
            this.rad_FailTrigger.Text = "任务失败触发";
            this.rad_FailTrigger.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rad_FailTrigger.Click += new System.EventHandler(this.uiRadioButton3_Click);
            // 
            // FrmCameraIoOut
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(589, 367);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiComboBox1);
            this.Controls.Add(this.txt_TimeOut);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCameraIoOut";
            this.Text = "相机IO输出";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 589, 367);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCameraIoOut_FormClosing);
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        internal Sunny.UI.UICheckBox ckb_taskFailKeepRun;
        internal Sunny.UI.UILabel lbl_toolTip;
        internal Sunny.UI.UILabel lbl_runTime;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UIButton btn_close;
        private Sunny.UI.UIButton btn_runTool;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UIRadioButton rad_FailTrigger;
        private Sunny.UI.UIRadioButton rad_SuccessTrigger;
        private Sunny.UI.UIRadioButton rad_Trigger;
        internal Sunny.UI.UITextBox txt_TimeOut;
    }
}