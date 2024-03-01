namespace VM_Pro
{
    partial class Frm_Environment
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
            this.lbl_passwordAgain = new Sunny.UI.UILabel();
            this.ckb_userForm = new Sunny.UI.UICheckBox();
            this.rdo_visionForm = new Sunny.UI.UICheckBox();
            this.rdo_motionForm = new Sunny.UI.UICheckBox();
            this.rdo_ioForm = new Sunny.UI.UICheckBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.rdo_defaultUserForm = new Sunny.UI.UIRadioButton();
            this.rdo_defaultVisionForm = new Sunny.UI.UIRadioButton();
            this.rdo_defaultMotionForm = new Sunny.UI.UIRadioButton();
            this.rdo_defaultIOForm = new Sunny.UI.UIRadioButton();
            this.ckb_autoRunAfterStartup = new Sunny.UI.UICheckBox();
            this.ckb_autoStartAfterRun = new Sunny.UI.UICheckBox();
            this.ckb_autoMax = new Sunny.UI.UICheckBox();
            this.ckb_disenableResizeForm = new Sunny.UI.UICheckBox();
            this.ckb_enablePermission = new Sunny.UI.UICheckBox();
            this.ckb_taskFailStop = new Sunny.UI.UICheckBox();
            this.rdo_infomation = new Sunny.UI.UIRadioButton();
            this.rdo_task = new Sunny.UI.UIRadioButton();
            this.rdo_product = new Sunny.UI.UIRadioButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.ckb_infomationFormEnable = new Sunny.UI.UICheckBox();
            this.ckb_produceFormEnable = new Sunny.UI.UICheckBox();
            this.ckb_taskFormEnable = new Sunny.UI.UICheckBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.cbx_controlType = new Sunny.UI.UIComboBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.btn_systemFormat = new Sunny.UI.UIButton();
            this.ckb_enableHalconSdk = new Sunny.UI.UICheckBox();
            this.ckb_enableHikvisionSdk = new Sunny.UI.UICheckBox();
            this.ckb_enableDaHengSdk = new Sunny.UI.UICheckBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.ckb_enableAVTSdk = new Sunny.UI.UICheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckb_onLine = new Sunny.UI.UICheckBox();
            this.ckb_showAllSignal = new Sunny.UI.UICheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_passwordAgain
            // 
            this.lbl_passwordAgain.AutoSize = true;
            this.lbl_passwordAgain.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_passwordAgain.Location = new System.Drawing.Point(15, 74);
            this.lbl_passwordAgain.Name = "lbl_passwordAgain";
            this.lbl_passwordAgain.Size = new System.Drawing.Size(91, 24);
            this.lbl_passwordAgain.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_passwordAgain.TabIndex = 156;
            this.lbl_passwordAgain.Text = "页面启用 :";
            this.lbl_passwordAgain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_passwordAgain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ckb_userForm
            // 
            this.ckb_userForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_userForm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_userForm.Location = new System.Drawing.Point(98, 70);
            this.ckb_userForm.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_userForm.Name = "ckb_userForm";
            this.ckb_userForm.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_userForm.Size = new System.Drawing.Size(94, 30);
            this.ckb_userForm.TabIndex = 160;
            this.ckb_userForm.Text = "首页";
            this.ckb_userForm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_userForm.CheckedChanged += new System.EventHandler(this.ckb_userForm_CheckedChanged);
            // 
            // rdo_visionForm
            // 
            this.rdo_visionForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_visionForm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_visionForm.Location = new System.Drawing.Point(192, 70);
            this.rdo_visionForm.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_visionForm.Name = "rdo_visionForm";
            this.rdo_visionForm.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_visionForm.Size = new System.Drawing.Size(94, 30);
            this.rdo_visionForm.TabIndex = 161;
            this.rdo_visionForm.Text = "视觉";
            this.rdo_visionForm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_visionForm.CheckedChanged += new System.EventHandler(this.ckb_visionForm_CheckedChanged);
            // 
            // rdo_motionForm
            // 
            this.rdo_motionForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_motionForm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_motionForm.Location = new System.Drawing.Point(286, 70);
            this.rdo_motionForm.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_motionForm.Name = "rdo_motionForm";
            this.rdo_motionForm.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_motionForm.Size = new System.Drawing.Size(94, 30);
            this.rdo_motionForm.TabIndex = 162;
            this.rdo_motionForm.Text = "运控";
            this.rdo_motionForm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_motionForm.CheckedChanged += new System.EventHandler(this.ckb_motionForm_CheckedChanged);
            // 
            // rdo_ioForm
            // 
            this.rdo_ioForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_ioForm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_ioForm.Location = new System.Drawing.Point(380, 70);
            this.rdo_ioForm.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_ioForm.Name = "rdo_ioForm";
            this.rdo_ioForm.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_ioForm.Size = new System.Drawing.Size(94, 30);
            this.rdo_ioForm.TabIndex = 163;
            this.rdo_ioForm.Text = "IO监控";
            this.rdo_ioForm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_ioForm.CheckedChanged += new System.EventHandler(this.ckb_ioForm_CheckedChanged);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(15, 103);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(91, 24);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 164;
            this.uiLabel1.Text = "默认页面 :";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rdo_defaultUserForm
            // 
            this.rdo_defaultUserForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_defaultUserForm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_defaultUserForm.Location = new System.Drawing.Point(98, 99);
            this.rdo_defaultUserForm.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_defaultUserForm.Name = "rdo_defaultUserForm";
            this.rdo_defaultUserForm.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_defaultUserForm.Size = new System.Drawing.Size(94, 30);
            this.rdo_defaultUserForm.TabIndex = 169;
            this.rdo_defaultUserForm.Text = "首页";
            this.rdo_defaultUserForm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_defaultUserForm.CheckedChanged += new System.EventHandler(this.rdo_defaultUserForm_CheckedChanged);
            // 
            // rdo_defaultVisionForm
            // 
            this.rdo_defaultVisionForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_defaultVisionForm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_defaultVisionForm.Location = new System.Drawing.Point(192, 99);
            this.rdo_defaultVisionForm.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_defaultVisionForm.Name = "rdo_defaultVisionForm";
            this.rdo_defaultVisionForm.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_defaultVisionForm.Size = new System.Drawing.Size(94, 30);
            this.rdo_defaultVisionForm.TabIndex = 170;
            this.rdo_defaultVisionForm.Text = "视觉";
            this.rdo_defaultVisionForm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_defaultVisionForm.CheckedChanged += new System.EventHandler(this.rdo_defaultVisionForm_CheckedChanged);
            // 
            // rdo_defaultMotionForm
            // 
            this.rdo_defaultMotionForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_defaultMotionForm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_defaultMotionForm.Location = new System.Drawing.Point(286, 99);
            this.rdo_defaultMotionForm.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_defaultMotionForm.Name = "rdo_defaultMotionForm";
            this.rdo_defaultMotionForm.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_defaultMotionForm.Size = new System.Drawing.Size(94, 30);
            this.rdo_defaultMotionForm.TabIndex = 171;
            this.rdo_defaultMotionForm.Text = "运控";
            this.rdo_defaultMotionForm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_defaultMotionForm.CheckedChanged += new System.EventHandler(this.rdo_defaultMotionForm_CheckedChanged);
            // 
            // rdo_defaultIOForm
            // 
            this.rdo_defaultIOForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_defaultIOForm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_defaultIOForm.Location = new System.Drawing.Point(380, 99);
            this.rdo_defaultIOForm.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_defaultIOForm.Name = "rdo_defaultIOForm";
            this.rdo_defaultIOForm.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_defaultIOForm.Size = new System.Drawing.Size(82, 30);
            this.rdo_defaultIOForm.TabIndex = 172;
            this.rdo_defaultIOForm.Text = "IO监控";
            this.rdo_defaultIOForm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_defaultIOForm.CheckedChanged += new System.EventHandler(this.rdo_defaultIOForm_CheckedChanged);
            // 
            // ckb_autoRunAfterStartup
            // 
            this.ckb_autoRunAfterStartup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_autoRunAfterStartup.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_autoRunAfterStartup.Location = new System.Drawing.Point(98, 230);
            this.ckb_autoRunAfterStartup.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_autoRunAfterStartup.Name = "ckb_autoRunAfterStartup";
            this.ckb_autoRunAfterStartup.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_autoRunAfterStartup.Size = new System.Drawing.Size(197, 30);
            this.ckb_autoRunAfterStartup.TabIndex = 178;
            this.ckb_autoRunAfterStartup.Text = "开机后程序自启动";
            this.ckb_autoRunAfterStartup.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_autoRunAfterStartup.CheckedChanged += new System.EventHandler(this.ckb_autoRunAfterStartup_CheckedChanged);
            // 
            // ckb_autoStartAfterRun
            // 
            this.ckb_autoStartAfterRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_autoStartAfterRun.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_autoStartAfterRun.Location = new System.Drawing.Point(98, 262);
            this.ckb_autoStartAfterRun.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_autoStartAfterRun.Name = "ckb_autoStartAfterRun";
            this.ckb_autoStartAfterRun.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_autoStartAfterRun.Size = new System.Drawing.Size(197, 30);
            this.ckb_autoStartAfterRun.TabIndex = 179;
            this.ckb_autoStartAfterRun.Text = "程序启动后自动开始";
            this.ckb_autoStartAfterRun.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_autoStartAfterRun.CheckedChanged += new System.EventHandler(this.ckb_autoStartAfterRun_CheckedChanged);
            // 
            // ckb_autoMax
            // 
            this.ckb_autoMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_autoMax.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_autoMax.Location = new System.Drawing.Point(98, 294);
            this.ckb_autoMax.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_autoMax.Name = "ckb_autoMax";
            this.ckb_autoMax.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_autoMax.Size = new System.Drawing.Size(197, 30);
            this.ckb_autoMax.TabIndex = 180;
            this.ckb_autoMax.Text = "程序开启后自动最大化";
            this.ckb_autoMax.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_autoMax.CheckedChanged += new System.EventHandler(this.ckb_autoMax_CheckedChanged);
            // 
            // ckb_disenableResizeForm
            // 
            this.ckb_disenableResizeForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_disenableResizeForm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_disenableResizeForm.Location = new System.Drawing.Point(98, 326);
            this.ckb_disenableResizeForm.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_disenableResizeForm.Name = "ckb_disenableResizeForm";
            this.ckb_disenableResizeForm.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_disenableResizeForm.Size = new System.Drawing.Size(197, 30);
            this.ckb_disenableResizeForm.TabIndex = 181;
            this.ckb_disenableResizeForm.Text = "不允许改变主窗体大小";
            this.ckb_disenableResizeForm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_disenableResizeForm.CheckedChanged += new System.EventHandler(this.ckb_disenableResizeForm_CheckedChanged);
            // 
            // ckb_enablePermission
            // 
            this.ckb_enablePermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_enablePermission.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_enablePermission.Location = new System.Drawing.Point(98, 358);
            this.ckb_enablePermission.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_enablePermission.Name = "ckb_enablePermission";
            this.ckb_enablePermission.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_enablePermission.Size = new System.Drawing.Size(197, 30);
            this.ckb_enablePermission.TabIndex = 182;
            this.ckb_enablePermission.Text = "开启权限管控";
            this.ckb_enablePermission.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_enablePermission.CheckedChanged += new System.EventHandler(this.ckb_enablePermission_CheckedChanged);
            // 
            // ckb_taskFailStop
            // 
            this.ckb_taskFailStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_taskFailStop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_taskFailStop.Location = new System.Drawing.Point(98, 390);
            this.ckb_taskFailStop.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_taskFailStop.Name = "ckb_taskFailStop";
            this.ckb_taskFailStop.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_taskFailStop.Size = new System.Drawing.Size(197, 30);
            this.ckb_taskFailStop.TabIndex = 183;
            this.ckb_taskFailStop.Text = "任务失败时停止循环";
            this.ckb_taskFailStop.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_taskFailStop.CheckedChanged += new System.EventHandler(this.ckb_taskFailStop_CheckedChanged);
            // 
            // rdo_infomation
            // 
            this.rdo_infomation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_infomation.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_infomation.Location = new System.Drawing.Point(188, 3);
            this.rdo_infomation.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_infomation.Name = "rdo_infomation";
            this.rdo_infomation.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_infomation.Size = new System.Drawing.Size(94, 30);
            this.rdo_infomation.TabIndex = 187;
            this.rdo_infomation.Text = "统计";
            this.rdo_infomation.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_infomation.CheckedChanged += new System.EventHandler(this.rdo_infomation_CheckedChanged);
            // 
            // rdo_task
            // 
            this.rdo_task.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_task.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_task.Location = new System.Drawing.Point(0, 3);
            this.rdo_task.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_task.Name = "rdo_task";
            this.rdo_task.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_task.Size = new System.Drawing.Size(94, 30);
            this.rdo_task.TabIndex = 186;
            this.rdo_task.Text = "任务";
            this.rdo_task.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_task.CheckedChanged += new System.EventHandler(this.rdo_task_CheckedChanged);
            // 
            // rdo_product
            // 
            this.rdo_product.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_product.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_product.Location = new System.Drawing.Point(94, 3);
            this.rdo_product.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdo_product.Name = "rdo_product";
            this.rdo_product.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdo_product.Size = new System.Drawing.Size(94, 30);
            this.rdo_product.TabIndex = 185;
            this.rdo_product.Text = "生产";
            this.rdo_product.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdo_product.CheckedChanged += new System.EventHandler(this.rdo_product_CheckedChanged);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(15, 161);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(91, 24);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 184;
            this.uiLabel2.Text = "默认页面 :";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ckb_infomationFormEnable
            // 
            this.ckb_infomationFormEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_infomationFormEnable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_infomationFormEnable.Location = new System.Drawing.Point(286, 128);
            this.ckb_infomationFormEnable.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_infomationFormEnable.Name = "ckb_infomationFormEnable";
            this.ckb_infomationFormEnable.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_infomationFormEnable.Size = new System.Drawing.Size(94, 30);
            this.ckb_infomationFormEnable.TabIndex = 191;
            this.ckb_infomationFormEnable.Text = "统计";
            this.ckb_infomationFormEnable.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_infomationFormEnable.CheckedChanged += new System.EventHandler(this.ckb_infomationFormEnable_CheckedChanged);
            // 
            // ckb_produceFormEnable
            // 
            this.ckb_produceFormEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_produceFormEnable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_produceFormEnable.Location = new System.Drawing.Point(192, 128);
            this.ckb_produceFormEnable.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_produceFormEnable.Name = "ckb_produceFormEnable";
            this.ckb_produceFormEnable.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_produceFormEnable.Size = new System.Drawing.Size(94, 30);
            this.ckb_produceFormEnable.TabIndex = 190;
            this.ckb_produceFormEnable.Text = "生产";
            this.ckb_produceFormEnable.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_produceFormEnable.CheckedChanged += new System.EventHandler(this.ckb_produceFormEnable_CheckedChanged);
            // 
            // ckb_taskFormEnable
            // 
            this.ckb_taskFormEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_taskFormEnable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_taskFormEnable.Location = new System.Drawing.Point(98, 128);
            this.ckb_taskFormEnable.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_taskFormEnable.Name = "ckb_taskFormEnable";
            this.ckb_taskFormEnable.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_taskFormEnable.Size = new System.Drawing.Size(94, 30);
            this.ckb_taskFormEnable.TabIndex = 189;
            this.ckb_taskFormEnable.Text = "任务";
            this.ckb_taskFormEnable.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_taskFormEnable.CheckedChanged += new System.EventHandler(this.ckb_taskFormEnable_CheckedChanged);
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(15, 132);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(91, 24);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 188;
            this.uiLabel3.Text = "页面启用 :";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbx_controlType
            // 
            this.cbx_controlType.BackColor = System.Drawing.Color.LightGray;
            this.cbx_controlType.DataSource = null;
            this.cbx_controlType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_controlType.Enabled = false;
            this.cbx_controlType.FillColor = System.Drawing.Color.LightGray;
            this.cbx_controlType.FillDisableColor = System.Drawing.Color.LightGray;
            this.cbx_controlType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_controlType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_controlType.Items.AddRange(new object[] {
            "启动 停止 暂停 复位 型",
            "启动 停止 型",
            "空 型"});
            this.cbx_controlType.Location = new System.Drawing.Point(102, 27);
            this.cbx_controlType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_controlType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_controlType.Name = "cbx_controlType";
            this.cbx_controlType.Padding = new System.Windows.Forms.Padding(3, 0, 30, 2);
            this.cbx_controlType.Radius = 0;
            this.cbx_controlType.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_controlType.RectColor = System.Drawing.Color.White;
            this.cbx_controlType.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_controlType.Size = new System.Drawing.Size(193, 29);
            this.cbx_controlType.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_controlType.TabIndex = 193;
            this.cbx_controlType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_controlType.Watermark = "";
            this.cbx_controlType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbx_controlType.SelectedIndexChanged += new System.EventHandler(this.cbx_controlType_SelectedIndexChanged);
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(15, 29);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(100, 24);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 192;
            this.uiLabel4.Text = "控制类型：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_systemFormat
            // 
            this.btn_systemFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_systemFormat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_systemFormat.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_systemFormat.Location = new System.Drawing.Point(128, 492);
            this.btn_systemFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_systemFormat.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_systemFormat.Name = "btn_systemFormat";
            this.btn_systemFormat.Size = new System.Drawing.Size(90, 34);
            this.btn_systemFormat.TabIndex = 194;
            this.btn_systemFormat.Text = "系统格式化";
            this.btn_systemFormat.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_systemFormat.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_systemFormat.Click += new System.EventHandler(this.btn_systemFormat_Click);
            // 
            // ckb_enableHalconSdk
            // 
            this.ckb_enableHalconSdk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_enableHalconSdk.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_enableHalconSdk.Location = new System.Drawing.Point(380, 186);
            this.ckb_enableHalconSdk.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_enableHalconSdk.Name = "ckb_enableHalconSdk";
            this.ckb_enableHalconSdk.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_enableHalconSdk.Size = new System.Drawing.Size(94, 30);
            this.ckb_enableHalconSdk.TabIndex = 199;
            this.ckb_enableHalconSdk.Text = "Halcon";
            this.ckb_enableHalconSdk.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_enableHalconSdk.Click += new System.EventHandler(this.ckb_enableHalconSdk_Click);
            // 
            // ckb_enableHikvisionSdk
            // 
            this.ckb_enableHikvisionSdk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_enableHikvisionSdk.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_enableHikvisionSdk.Location = new System.Drawing.Point(98, 186);
            this.ckb_enableHikvisionSdk.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_enableHikvisionSdk.Name = "ckb_enableHikvisionSdk";
            this.ckb_enableHikvisionSdk.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_enableHikvisionSdk.Size = new System.Drawing.Size(94, 30);
            this.ckb_enableHikvisionSdk.TabIndex = 198;
            this.ckb_enableHikvisionSdk.Text = "海康威视";
            this.ckb_enableHikvisionSdk.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_enableHikvisionSdk.Click += new System.EventHandler(this.ckb_enableHikvisionSdk_Click);
            // 
            // ckb_enableDaHengSdk
            // 
            this.ckb_enableDaHengSdk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_enableDaHengSdk.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_enableDaHengSdk.Location = new System.Drawing.Point(192, 186);
            this.ckb_enableDaHengSdk.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_enableDaHengSdk.Name = "ckb_enableDaHengSdk";
            this.ckb_enableDaHengSdk.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_enableDaHengSdk.Size = new System.Drawing.Size(94, 30);
            this.ckb_enableDaHengSdk.TabIndex = 197;
            this.ckb_enableDaHengSdk.Text = "大恒";
            this.ckb_enableDaHengSdk.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_enableDaHengSdk.Click += new System.EventHandler(this.ckb_enableDaHengSdk_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.AutoSize = true;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(15, 190);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(91, 24);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 196;
            this.uiLabel5.Text = "相机启用 :";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ckb_enableAVTSdk
            // 
            this.ckb_enableAVTSdk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_enableAVTSdk.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_enableAVTSdk.Location = new System.Drawing.Point(286, 186);
            this.ckb_enableAVTSdk.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_enableAVTSdk.Name = "ckb_enableAVTSdk";
            this.ckb_enableAVTSdk.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_enableAVTSdk.Size = new System.Drawing.Size(94, 30);
            this.ckb_enableAVTSdk.TabIndex = 200;
            this.ckb_enableAVTSdk.Text = "AVT";
            this.ckb_enableAVTSdk.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_enableAVTSdk.Click += new System.EventHandler(this.ckb_enableAVTSdk_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdo_task);
            this.panel1.Controls.Add(this.rdo_product);
            this.panel1.Controls.Add(this.rdo_infomation);
            this.panel1.Location = new System.Drawing.Point(98, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 35);
            this.panel1.TabIndex = 201;
            // 
            // ckb_onLine
            // 
            this.ckb_onLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_onLine.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_onLine.Location = new System.Drawing.Point(98, 422);
            this.ckb_onLine.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_onLine.Name = "ckb_onLine";
            this.ckb_onLine.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_onLine.Size = new System.Drawing.Size(197, 30);
            this.ckb_onLine.TabIndex = 204;
            this.ckb_onLine.Text = "显示连机信号";
            this.ckb_onLine.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_onLine.Click += new System.EventHandler(this.ckb_onLine_Click);
            // 
            // ckb_showAllSignal
            // 
            this.ckb_showAllSignal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_showAllSignal.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_showAllSignal.Location = new System.Drawing.Point(98, 454);
            this.ckb_showAllSignal.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckb_showAllSignal.Name = "ckb_showAllSignal";
            this.ckb_showAllSignal.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckb_showAllSignal.Size = new System.Drawing.Size(197, 30);
            this.ckb_showAllSignal.TabIndex = 205;
            this.ckb_showAllSignal.Text = "显示所有IO信号";
            this.ckb_showAllSignal.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckb_showAllSignal.Click += new System.EventHandler(this.ckb_showAllSignal_Click);
            // 
            // Frm_Environment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(842, 601);
            this.Controls.Add(this.ckb_showAllSignal);
            this.Controls.Add(this.ckb_onLine);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ckb_enableAVTSdk);
            this.Controls.Add(this.ckb_enableHalconSdk);
            this.Controls.Add(this.ckb_enableHikvisionSdk);
            this.Controls.Add(this.ckb_enableDaHengSdk);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.btn_systemFormat);
            this.Controls.Add(this.cbx_controlType);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.ckb_infomationFormEnable);
            this.Controls.Add(this.ckb_produceFormEnable);
            this.Controls.Add(this.ckb_taskFormEnable);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.ckb_taskFailStop);
            this.Controls.Add(this.ckb_enablePermission);
            this.Controls.Add(this.ckb_disenableResizeForm);
            this.Controls.Add(this.ckb_autoMax);
            this.Controls.Add(this.ckb_autoStartAfterRun);
            this.Controls.Add(this.ckb_autoRunAfterStartup);
            this.Controls.Add(this.rdo_defaultIOForm);
            this.Controls.Add(this.rdo_defaultMotionForm);
            this.Controls.Add(this.rdo_defaultVisionForm);
            this.Controls.Add(this.rdo_defaultUserForm);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.rdo_ioForm);
            this.Controls.Add(this.rdo_motionForm);
            this.Controls.Add(this.rdo_visionForm);
            this.Controls.Add(this.ckb_userForm);
            this.Controls.Add(this.lbl_passwordAgain);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_Environment";
            this.Text = "Frm_Project";
            this.Load += new System.EventHandler(this.Frm_Project_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel lbl_passwordAgain;
        private Sunny.UI.UICheckBox ckb_userForm;
        private Sunny.UI.UICheckBox rdo_visionForm;
        private Sunny.UI.UICheckBox rdo_motionForm;
        private Sunny.UI.UICheckBox rdo_ioForm;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIRadioButton rdo_defaultUserForm;
        private Sunny.UI.UIRadioButton rdo_defaultVisionForm;
        private Sunny.UI.UIRadioButton rdo_defaultMotionForm;
        private Sunny.UI.UIRadioButton rdo_defaultIOForm;
        private Sunny.UI.UICheckBox ckb_autoRunAfterStartup;
        private Sunny.UI.UICheckBox ckb_autoStartAfterRun;
        private Sunny.UI.UICheckBox ckb_autoMax;
        private Sunny.UI.UICheckBox ckb_disenableResizeForm;
        private Sunny.UI.UICheckBox ckb_enablePermission;
        private Sunny.UI.UICheckBox ckb_taskFailStop;
        private Sunny.UI.UIRadioButton rdo_infomation;
        private Sunny.UI.UIRadioButton rdo_task;
        private Sunny.UI.UIRadioButton rdo_product;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UICheckBox ckb_infomationFormEnable;
        private Sunny.UI.UICheckBox ckb_produceFormEnable;
        private Sunny.UI.UICheckBox ckb_taskFormEnable;
        private Sunny.UI.UILabel uiLabel3;
        internal Sunny.UI.UIComboBox cbx_controlType;
        private Sunny.UI.UILabel uiLabel4;
        internal Sunny.UI.UIButton btn_systemFormat;
        private Sunny.UI.UICheckBox ckb_enableHalconSdk;
        private Sunny.UI.UICheckBox ckb_enableHikvisionSdk;
        private Sunny.UI.UICheckBox ckb_enableDaHengSdk;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UICheckBox ckb_enableAVTSdk;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UICheckBox ckb_onLine;
        private Sunny.UI.UICheckBox ckb_showAllSignal;
    }
}