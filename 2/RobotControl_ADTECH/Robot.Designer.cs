namespace RobotControl
{
    partial class Robot
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Robot));
            this.lbl_curUPos = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lbl_curZPos = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lbl_curYPos = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lbl_curXPos = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tbx_moveDis = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rdo_verySlowVel = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.rdo_slowVel = new System.Windows.Forms.RadioButton();
            this.rdo_midVel = new System.Windows.Forms.RadioButton();
            this.rdo_fastVel = new System.Windows.Forms.RadioButton();
            this.rdo_NotJog = new System.Windows.Forms.RadioButton();
            this.rdo_Jog = new System.Windows.Forms.RadioButton();
            this.btn_goHome = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_suck = new System.Windows.Forms.Button();
            this.btn_XForeward = new System.Windows.Forms.Button();
            this.btn_XBackward = new System.Windows.Forms.Button();
            this.btn_YForeward = new System.Windows.Forms.Button();
            this.btn_YBackward = new System.Windows.Forms.Button();
            this.btn_ZMoveUp = new System.Windows.Forms.Button();
            this.btn_UBackward = new System.Windows.Forms.Button();
            this.btn_UForeward = new System.Windows.Forms.Button();
            this.btn_ZMoveDown = new System.Windows.Forms.Button();
            this.btn_motorOn = new System.Windows.Forms.Button();
            this.btn_clearAlarm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_emgStop = new System.Windows.Forms.Button();
            this.btn_morePar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_curUPos
            // 
            this.lbl_curUPos.AutoSize = true;
            this.lbl_curUPos.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_curUPos.Location = new System.Drawing.Point(276, 273);
            this.lbl_curUPos.Name = "lbl_curUPos";
            this.lbl_curUPos.Size = new System.Drawing.Size(15, 17);
            this.lbl_curUPos.TabIndex = 100122;
            this.lbl_curUPos.Text = "0";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(258, 273);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(29, 17);
            this.label35.TabIndex = 100121;
            this.label35.Text = "U：";
            // 
            // lbl_curZPos
            // 
            this.lbl_curZPos.AutoSize = true;
            this.lbl_curZPos.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_curZPos.Location = new System.Drawing.Point(276, 252);
            this.lbl_curZPos.Name = "lbl_curZPos";
            this.lbl_curZPos.Size = new System.Drawing.Size(15, 17);
            this.lbl_curZPos.TabIndex = 100120;
            this.lbl_curZPos.Text = "0";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(258, 252);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(27, 17);
            this.label33.TabIndex = 100119;
            this.label33.Text = "Z：";
            // 
            // lbl_curYPos
            // 
            this.lbl_curYPos.AutoSize = true;
            this.lbl_curYPos.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_curYPos.Location = new System.Drawing.Point(276, 231);
            this.lbl_curYPos.Name = "lbl_curYPos";
            this.lbl_curYPos.Size = new System.Drawing.Size(15, 17);
            this.lbl_curYPos.TabIndex = 100118;
            this.lbl_curYPos.Text = "0";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(258, 231);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(27, 17);
            this.label31.TabIndex = 100117;
            this.label31.Text = "Y：";
            // 
            // lbl_curXPos
            // 
            this.lbl_curXPos.AutoSize = true;
            this.lbl_curXPos.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_curXPos.Location = new System.Drawing.Point(276, 210);
            this.lbl_curXPos.Name = "lbl_curXPos";
            this.lbl_curXPos.Size = new System.Drawing.Size(15, 17);
            this.lbl_curXPos.TabIndex = 100116;
            this.lbl_curXPos.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(258, 210);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(28, 17);
            this.label27.TabIndex = 100115;
            this.label27.Text = "X：";
            // 
            // tbx_moveDis
            // 
            this.tbx_moveDis.Location = new System.Drawing.Point(249, 127);
            this.tbx_moveDis.Name = "tbx_moveDis";
            this.tbx_moveDis.Size = new System.Drawing.Size(50, 23);
            this.tbx_moveDis.TabIndex = 100107;
            this.tbx_moveDis.Text = "1";
            this.tbx_moveDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbx_moveDis.TextChanged += new System.EventHandler(this.tbx_moveDis_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 100113;
            this.label7.Text = "mm";
            // 
            // rdo_verySlowVel
            // 
            this.rdo_verySlowVel.AutoSize = true;
            this.rdo_verySlowVel.Checked = true;
            this.rdo_verySlowVel.Location = new System.Drawing.Point(281, 155);
            this.rdo_verySlowVel.Name = "rdo_verySlowVel";
            this.rdo_verySlowVel.Size = new System.Drawing.Size(50, 21);
            this.rdo_verySlowVel.TabIndex = 100112;
            this.rdo_verySlowVel.TabStop = true;
            this.rdo_verySlowVel.Text = "特慢";
            this.rdo_verySlowVel.UseVisualStyleBackColor = true;
            this.rdo_verySlowVel.CheckedChanged += new System.EventHandler(this.rdo_verySlowVel_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(211, 129);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 17);
            this.label19.TabIndex = 100106;
            this.label19.Text = "距离：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 157);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 17);
            this.label17.TabIndex = 100105;
            this.label17.Text = "速度等级：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 129);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 17);
            this.label18.TabIndex = 100104;
            this.label18.Text = "控制模式：";
            // 
            // rdo_slowVel
            // 
            this.rdo_slowVel.AutoSize = true;
            this.rdo_slowVel.Location = new System.Drawing.Point(216, 155);
            this.rdo_slowVel.Name = "rdo_slowVel";
            this.rdo_slowVel.Size = new System.Drawing.Size(50, 21);
            this.rdo_slowVel.TabIndex = 100103;
            this.rdo_slowVel.Text = "慢速";
            this.rdo_slowVel.UseVisualStyleBackColor = true;
            this.rdo_slowVel.CheckedChanged += new System.EventHandler(this.rdo_slowVel_CheckedChanged);
            // 
            // rdo_midVel
            // 
            this.rdo_midVel.AutoSize = true;
            this.rdo_midVel.Location = new System.Drawing.Point(149, 155);
            this.rdo_midVel.Name = "rdo_midVel";
            this.rdo_midVel.Size = new System.Drawing.Size(50, 21);
            this.rdo_midVel.TabIndex = 100102;
            this.rdo_midVel.Text = "中速";
            this.rdo_midVel.UseVisualStyleBackColor = true;
            this.rdo_midVel.CheckedChanged += new System.EventHandler(this.rdo_midVel_CheckedChanged);
            // 
            // rdo_fastVel
            // 
            this.rdo_fastVel.AutoSize = true;
            this.rdo_fastVel.Location = new System.Drawing.Point(82, 155);
            this.rdo_fastVel.Name = "rdo_fastVel";
            this.rdo_fastVel.Size = new System.Drawing.Size(50, 21);
            this.rdo_fastVel.TabIndex = 100101;
            this.rdo_fastVel.Text = "快速";
            this.rdo_fastVel.UseVisualStyleBackColor = true;
            this.rdo_fastVel.CheckedChanged += new System.EventHandler(this.rdo_fastVel_CheckedChanged);
            // 
            // rdo_NotJog
            // 
            this.rdo_NotJog.AutoSize = true;
            this.rdo_NotJog.Location = new System.Drawing.Point(80, 3);
            this.rdo_NotJog.Name = "rdo_NotJog";
            this.rdo_NotJog.Size = new System.Drawing.Size(50, 21);
            this.rdo_NotJog.TabIndex = 100100;
            this.rdo_NotJog.Text = "寸动";
            this.rdo_NotJog.UseVisualStyleBackColor = true;
            this.rdo_NotJog.CheckedChanged += new System.EventHandler(this.rdo_NotJog_CheckedChanged);
            // 
            // rdo_Jog
            // 
            this.rdo_Jog.AutoSize = true;
            this.rdo_Jog.Checked = true;
            this.rdo_Jog.Location = new System.Drawing.Point(13, 3);
            this.rdo_Jog.Name = "rdo_Jog";
            this.rdo_Jog.Size = new System.Drawing.Size(47, 21);
            this.rdo_Jog.TabIndex = 100099;
            this.rdo_Jog.TabStop = true;
            this.rdo_Jog.Text = "Jog";
            this.rdo_Jog.UseVisualStyleBackColor = true;
            this.rdo_Jog.CheckedChanged += new System.EventHandler(this.rdo_Jog_CheckedChanged);
            // 
            // btn_goHome
            // 
            this.btn_goHome.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_goHome.Location = new System.Drawing.Point(9, 52);
            this.btn_goHome.Name = "btn_goHome";
            this.btn_goHome.Size = new System.Drawing.Size(80, 40);
            this.btn_goHome.TabIndex = 100098;
            this.btn_goHome.Text = "安全高度";
            this.btn_goHome.UseVisualStyleBackColor = true;
            this.btn_goHome.Click += new System.EventHandler(this.btn_goHome_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_connect.Location = new System.Drawing.Point(9, 12);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(80, 40);
            this.btn_connect.TabIndex = 100097;
            this.btn_connect.Text = "连接";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_stop.Location = new System.Drawing.Point(89, 52);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(80, 40);
            this.btn_stop.TabIndex = 100096;
            this.btn_stop.Text = "备用";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_suck
            // 
            this.btn_suck.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_suck.Location = new System.Drawing.Point(249, 52);
            this.btn_suck.Name = "btn_suck";
            this.btn_suck.Size = new System.Drawing.Size(80, 40);
            this.btn_suck.TabIndex = 100095;
            this.btn_suck.Text = "备用";
            this.btn_suck.UseVisualStyleBackColor = true;
            // 
            // btn_XForeward
            // 
            this.btn_XForeward.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_XForeward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_XForeward.Image = ((System.Drawing.Image)(resources.GetObject("btn_XForeward.Image")));
            this.btn_XForeward.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_XForeward.Location = new System.Drawing.Point(114, 241);
            this.btn_XForeward.Name = "btn_XForeward";
            this.btn_XForeward.Size = new System.Drawing.Size(50, 50);
            this.btn_XForeward.TabIndex = 100088;
            this.btn_XForeward.Text = "右";
            this.btn_XForeward.UseVisualStyleBackColor = false;
            this.btn_XForeward.Click += new System.EventHandler(this.btn_XForeward_Click);
            this.btn_XForeward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_XForeward_MouseDown);
            this.btn_XForeward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_XForeward_MouseUp);
            // 
            // btn_XBackward
            // 
            this.btn_XBackward.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_XBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_XBackward.Image = ((System.Drawing.Image)(resources.GetObject("btn_XBackward.Image")));
            this.btn_XBackward.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_XBackward.Location = new System.Drawing.Point(10, 241);
            this.btn_XBackward.Name = "btn_XBackward";
            this.btn_XBackward.Size = new System.Drawing.Size(50, 50);
            this.btn_XBackward.TabIndex = 100087;
            this.btn_XBackward.Text = "左";
            this.btn_XBackward.UseVisualStyleBackColor = false;
            this.btn_XBackward.Click += new System.EventHandler(this.btn_XBackward_Click);
            this.btn_XBackward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_XBackward_MouseDown);
            this.btn_XBackward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_XBackward_MouseUp);
            // 
            // btn_YForeward
            // 
            this.btn_YForeward.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_YForeward.Image = ((System.Drawing.Image)(resources.GetObject("btn_YForeward.Image")));
            this.btn_YForeward.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_YForeward.Location = new System.Drawing.Point(62, 190);
            this.btn_YForeward.Name = "btn_YForeward";
            this.btn_YForeward.Size = new System.Drawing.Size(50, 50);
            this.btn_YForeward.TabIndex = 100081;
            this.btn_YForeward.Text = "前";
            this.btn_YForeward.UseVisualStyleBackColor = false;
            this.btn_YForeward.Click += new System.EventHandler(this.btn_YForeward_Click);
            this.btn_YForeward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_YForeward_MouseDown);
            this.btn_YForeward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_YForeward_MouseUp);
            // 
            // btn_YBackward
            // 
            this.btn_YBackward.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_YBackward.Image = ((System.Drawing.Image)(resources.GetObject("btn_YBackward.Image")));
            this.btn_YBackward.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_YBackward.Location = new System.Drawing.Point(62, 292);
            this.btn_YBackward.Name = "btn_YBackward";
            this.btn_YBackward.Size = new System.Drawing.Size(50, 50);
            this.btn_YBackward.TabIndex = 100082;
            this.btn_YBackward.Text = "后";
            this.btn_YBackward.UseVisualStyleBackColor = false;
            this.btn_YBackward.Click += new System.EventHandler(this.btn_YBackward_Click);
            this.btn_YBackward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_YBackward_MouseDown);
            this.btn_YBackward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_YBackward_MouseUp);
            // 
            // btn_ZMoveUp
            // 
            this.btn_ZMoveUp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_ZMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("btn_ZMoveUp.Image")));
            this.btn_ZMoveUp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ZMoveUp.Location = new System.Drawing.Point(175, 190);
            this.btn_ZMoveUp.Name = "btn_ZMoveUp";
            this.btn_ZMoveUp.Size = new System.Drawing.Size(70, 34);
            this.btn_ZMoveUp.TabIndex = 100083;
            this.btn_ZMoveUp.Text = "上";
            this.btn_ZMoveUp.UseVisualStyleBackColor = false;
            this.btn_ZMoveUp.Click += new System.EventHandler(this.btn_ZMoveUp_Click);
            this.btn_ZMoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_ZMoveUp_MouseDown);
            this.btn_ZMoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_ZMoveUp_MouseUp);
            // 
            // btn_UBackward
            // 
            this.btn_UBackward.Image = ((System.Drawing.Image)(resources.GetObject("btn_UBackward.Image")));
            this.btn_UBackward.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_UBackward.Location = new System.Drawing.Point(175, 308);
            this.btn_UBackward.Name = "btn_UBackward";
            this.btn_UBackward.Size = new System.Drawing.Size(70, 34);
            this.btn_UBackward.TabIndex = 100085;
            this.btn_UBackward.Text = "反转";
            this.btn_UBackward.UseVisualStyleBackColor = true;
            this.btn_UBackward.Click += new System.EventHandler(this.btn_UBackward_Click);
            this.btn_UBackward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_UBackward_MouseDown);
            this.btn_UBackward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_UBackward_MouseUp);
            // 
            // btn_UForeward
            // 
            this.btn_UForeward.Image = ((System.Drawing.Image)(resources.GetObject("btn_UForeward.Image")));
            this.btn_UForeward.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_UForeward.Location = new System.Drawing.Point(175, 272);
            this.btn_UForeward.Name = "btn_UForeward";
            this.btn_UForeward.Size = new System.Drawing.Size(70, 34);
            this.btn_UForeward.TabIndex = 100086;
            this.btn_UForeward.Text = "正转";
            this.btn_UForeward.UseVisualStyleBackColor = true;
            this.btn_UForeward.Click += new System.EventHandler(this.btn_UForeward_Click);
            this.btn_UForeward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_UForeward_MouseDown);
            this.btn_UForeward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_UForeward_MouseUp);
            // 
            // btn_ZMoveDown
            // 
            this.btn_ZMoveDown.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_ZMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btn_ZMoveDown.Image")));
            this.btn_ZMoveDown.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ZMoveDown.Location = new System.Drawing.Point(175, 226);
            this.btn_ZMoveDown.Name = "btn_ZMoveDown";
            this.btn_ZMoveDown.Size = new System.Drawing.Size(70, 34);
            this.btn_ZMoveDown.TabIndex = 100084;
            this.btn_ZMoveDown.Text = "下";
            this.btn_ZMoveDown.UseVisualStyleBackColor = false;
            this.btn_ZMoveDown.Click += new System.EventHandler(this.btn_ZMoveDown_Click);
            this.btn_ZMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_ZMoveDown_MouseDown);
            this.btn_ZMoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_ZMoveDown_MouseUp);
            // 
            // btn_motorOn
            // 
            this.btn_motorOn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_motorOn.Location = new System.Drawing.Point(89, 12);
            this.btn_motorOn.Name = "btn_motorOn";
            this.btn_motorOn.Size = new System.Drawing.Size(80, 40);
            this.btn_motorOn.TabIndex = 100079;
            this.btn_motorOn.Text = "使能";
            this.btn_motorOn.UseVisualStyleBackColor = true;
            this.btn_motorOn.Click += new System.EventHandler(this.btn_motorOn_Click);
            // 
            // btn_clearAlarm
            // 
            this.btn_clearAlarm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_clearAlarm.Location = new System.Drawing.Point(169, 12);
            this.btn_clearAlarm.Name = "btn_clearAlarm";
            this.btn_clearAlarm.Size = new System.Drawing.Size(80, 40);
            this.btn_clearAlarm.TabIndex = 100131;
            this.btn_clearAlarm.Text = "报警清除";
            this.btn_clearAlarm.UseVisualStyleBackColor = true;
            this.btn_clearAlarm.Click += new System.EventHandler(this.btn_clearAlarm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdo_Jog);
            this.panel1.Controls.Add(this.rdo_NotJog);
            this.panel1.Location = new System.Drawing.Point(69, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 26);
            this.panel1.TabIndex = 100133;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(258, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 100136;
            this.label5.Text = "当前坐标";
            // 
            // btn_emgStop
            // 
            this.btn_emgStop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_emgStop.Location = new System.Drawing.Point(249, 12);
            this.btn_emgStop.Name = "btn_emgStop";
            this.btn_emgStop.Size = new System.Drawing.Size(80, 40);
            this.btn_emgStop.TabIndex = 100140;
            this.btn_emgStop.Text = "急停";
            this.btn_emgStop.UseVisualStyleBackColor = true;
            this.btn_emgStop.Click += new System.EventHandler(this.btn_emgStop_Click);
            // 
            // btn_morePar
            // 
            this.btn_morePar.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_morePar.Location = new System.Drawing.Point(169, 52);
            this.btn_morePar.Name = "btn_morePar";
            this.btn_morePar.Size = new System.Drawing.Size(80, 40);
            this.btn_morePar.TabIndex = 100137;
            this.btn_morePar.Text = "更多";
            this.btn_morePar.UseVisualStyleBackColor = true;
            this.btn_morePar.Click += new System.EventHandler(this.btn_morePar_Click);
            // 
            // Robot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_emgStop);
            this.Controls.Add(this.btn_morePar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_clearAlarm);
            this.Controls.Add(this.lbl_curUPos);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.lbl_curZPos);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.lbl_curYPos);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.lbl_curXPos);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.tbx_moveDis);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rdo_verySlowVel);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.rdo_slowVel);
            this.Controls.Add(this.rdo_midVel);
            this.Controls.Add(this.rdo_fastVel);
            this.Controls.Add(this.btn_goHome);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_suck);
            this.Controls.Add(this.btn_XForeward);
            this.Controls.Add(this.btn_XBackward);
            this.Controls.Add(this.btn_YForeward);
            this.Controls.Add(this.btn_YBackward);
            this.Controls.Add(this.btn_ZMoveUp);
            this.Controls.Add(this.btn_UBackward);
            this.Controls.Add(this.btn_UForeward);
            this.Controls.Add(this.btn_ZMoveDown);
            this.Controls.Add(this.btn_motorOn);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Robot";
            this.Size = new System.Drawing.Size(341, 355);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lbl_curUPos;
        private System.Windows.Forms.Label label35;
        internal System.Windows.Forms.Label lbl_curZPos;
        private System.Windows.Forms.Label label33;
        internal System.Windows.Forms.Label lbl_curYPos;
        private System.Windows.Forms.Label label31;
        internal System.Windows.Forms.Label lbl_curXPos;
        private System.Windows.Forms.Label label27;
        internal System.Windows.Forms.TextBox tbx_moveDis;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton rdo_NotJog;
        private System.Windows.Forms.RadioButton rdo_Jog;
        internal System.Windows.Forms.Button btn_goHome;
        internal System.Windows.Forms.Button btn_connect;
        internal System.Windows.Forms.Button btn_stop;
        internal System.Windows.Forms.Button btn_suck;
        private System.Windows.Forms.Button btn_XForeward;
        private System.Windows.Forms.Button btn_XBackward;
        private System.Windows.Forms.Button btn_YForeward;
        private System.Windows.Forms.Button btn_YBackward;
        private System.Windows.Forms.Button btn_ZMoveUp;
        internal System.Windows.Forms.Button btn_UBackward;
        internal System.Windows.Forms.Button btn_UForeward;
        private System.Windows.Forms.Button btn_ZMoveDown;
        internal System.Windows.Forms.Button btn_motorOn;
        internal System.Windows.Forms.Button btn_clearAlarm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Button btn_emgStop;
        internal System.Windows.Forms.Button btn_morePar;
        internal System.Windows.Forms.RadioButton rdo_verySlowVel;
        internal System.Windows.Forms.RadioButton rdo_midVel;
        public System.Windows.Forms.RadioButton rdo_slowVel;
        public System.Windows.Forms.RadioButton rdo_fastVel;
    }
}
