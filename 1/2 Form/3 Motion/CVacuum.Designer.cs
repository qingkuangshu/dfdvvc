namespace VM_Pro
{
    partial class CVacuum
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
            this.lbl_name = new Sunny.UI.UILabel();
            this.pic_vacuumStatu = new Sunny.UI.UIAvatar();
            this.btn_off = new System.Windows.Forms.Button();
            this.btn_on = new System.Windows.Forms.Button();
            this.btn_blow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_name.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_name.Location = new System.Drawing.Point(0, 0);
            this.lbl_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(136, 22);
            this.lbl_name.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_name.TabIndex = 243;
            this.lbl_name.Text = "名称";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_name.DoubleClick += new System.EventHandler(this.lbl_name_DoubleClick);
            // 
            // pic_vacuumStatu
            // 
            this.pic_vacuumStatu.AvatarSize = 100;
            this.pic_vacuumStatu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_vacuumStatu.FillColor = System.Drawing.Color.Gainsboro;
            this.pic_vacuumStatu.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pic_vacuumStatu.ForeColor = System.Drawing.Color.Green;
            this.pic_vacuumStatu.Location = new System.Drawing.Point(111, 38);
            this.pic_vacuumStatu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pic_vacuumStatu.MinimumSize = new System.Drawing.Size(1, 2);
            this.pic_vacuumStatu.Name = "pic_vacuumStatu";
            this.pic_vacuumStatu.Size = new System.Drawing.Size(20, 20);
            this.pic_vacuumStatu.Style = Sunny.UI.UIStyle.Custom;
            this.pic_vacuumStatu.Symbol = 61713;
            this.pic_vacuumStatu.SymbolSize = 18;
            this.pic_vacuumStatu.TabIndex = 244;
            this.pic_vacuumStatu.Text = "uiAvatar1";
            // 
            // btn_off
            // 
            this.btn_off.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_off.Location = new System.Drawing.Point(2, 23);
            this.btn_off.Name = "btn_off";
            this.btn_off.Size = new System.Drawing.Size(33, 33);
            this.btn_off.TabIndex = 100097;
            this.btn_off.Text = "关";
            this.btn_off.UseVisualStyleBackColor = true;
            this.btn_off.Click += new System.EventHandler(this.Btn_off_Click);
            // 
            // btn_on
            // 
            this.btn_on.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_on.Location = new System.Drawing.Point(35, 23);
            this.btn_on.Name = "btn_on";
            this.btn_on.Size = new System.Drawing.Size(33, 33);
            this.btn_on.TabIndex = 100098;
            this.btn_on.Text = "吸";
            this.btn_on.UseVisualStyleBackColor = true;
            this.btn_on.Click += new System.EventHandler(this.Btn_on_Click);
            // 
            // btn_blow
            // 
            this.btn_blow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_blow.Location = new System.Drawing.Point(68, 23);
            this.btn_blow.Name = "btn_blow";
            this.btn_blow.Size = new System.Drawing.Size(33, 33);
            this.btn_blow.TabIndex = 100099;
            this.btn_blow.Text = "破";
            this.btn_blow.UseVisualStyleBackColor = true;
            this.btn_blow.Click += new System.EventHandler(this.Btn_blow_Click);
            // 
            // CVacuum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.btn_blow);
            this.Controls.Add(this.btn_on);
            this.Controls.Add(this.btn_off);
            this.Controls.Add(this.pic_vacuumStatu);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CVacuum";
            this.Size = new System.Drawing.Size(136, 58);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel lbl_name;
        internal Sunny.UI.UIAvatar pic_vacuumStatu;
        internal System.Windows.Forms.Button btn_off;
        internal System.Windows.Forms.Button btn_on;
        internal System.Windows.Forms.Button btn_blow;
    }
}
