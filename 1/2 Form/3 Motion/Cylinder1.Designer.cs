namespace VM_Pro
{
    partial class Cylinder1
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
            this.pic_originStatu = new Sunny.UI.UIAvatar();
            this.pic_actStatu = new Sunny.UI.UIAvatar();
            this.btn_on = new System.Windows.Forms.Button();
            this.btn_off = new System.Windows.Forms.Button();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
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
            // pic_originStatu
            // 
            this.pic_originStatu.AvatarSize = 100;
            this.pic_originStatu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_originStatu.FillColor = System.Drawing.Color.Gainsboro;
            this.pic_originStatu.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pic_originStatu.ForeColor = System.Drawing.Color.Green;
            this.pic_originStatu.Location = new System.Drawing.Point(114, 20);
            this.pic_originStatu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pic_originStatu.MinimumSize = new System.Drawing.Size(1, 2);
            this.pic_originStatu.Name = "pic_originStatu";
            this.pic_originStatu.Size = new System.Drawing.Size(20, 20);
            this.pic_originStatu.Style = Sunny.UI.UIStyle.Custom;
            this.pic_originStatu.Symbol = 61713;
            this.pic_originStatu.SymbolSize = 18;
            this.pic_originStatu.TabIndex = 244;
            this.pic_originStatu.Text = "uiAvatar1";
            // 
            // pic_actStatu
            // 
            this.pic_actStatu.AvatarSize = 100;
            this.pic_actStatu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_actStatu.FillColor = System.Drawing.Color.Gainsboro;
            this.pic_actStatu.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pic_actStatu.ForeColor = System.Drawing.Color.Green;
            this.pic_actStatu.Location = new System.Drawing.Point(114, 38);
            this.pic_actStatu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pic_actStatu.MinimumSize = new System.Drawing.Size(1, 2);
            this.pic_actStatu.Name = "pic_actStatu";
            this.pic_actStatu.Size = new System.Drawing.Size(20, 20);
            this.pic_actStatu.Style = Sunny.UI.UIStyle.Custom;
            this.pic_actStatu.Symbol = 61713;
            this.pic_actStatu.SymbolSize = 18;
            this.pic_actStatu.TabIndex = 245;
            this.pic_actStatu.Text = "uiAvatar1";
            // 
            // btn_on
            // 
            this.btn_on.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_on.Location = new System.Drawing.Point(37, 23);
            this.btn_on.Name = "btn_on";
            this.btn_on.Size = new System.Drawing.Size(33, 33);
            this.btn_on.TabIndex = 100100;
            this.btn_on.Text = "动";
            this.btn_on.UseVisualStyleBackColor = true;
            this.btn_on.Click += new System.EventHandler(this.Btn_on_Click);
            // 
            // btn_off
            // 
            this.btn_off.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_off.Location = new System.Drawing.Point(4, 23);
            this.btn_off.Name = "btn_off";
            this.btn_off.Size = new System.Drawing.Size(33, 33);
            this.btn_off.TabIndex = 100099;
            this.btn_off.Text = "原";
            this.btn_off.UseVisualStyleBackColor = true;
            this.btn_off.Click += new System.EventHandler(this.Btn_off_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(76, 39);
            this.uiLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(39, 17);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 247;
            this.uiLabel3.Text = "动位 :";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(76, 22);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(39, 17);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 246;
            this.uiLabel1.Text = "原位 :";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cylinder1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.btn_on);
            this.Controls.Add(this.btn_off);
            this.Controls.Add(this.pic_actStatu);
            this.Controls.Add(this.pic_originStatu);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Cylinder1";
            this.Size = new System.Drawing.Size(136, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel lbl_name;
        internal Sunny.UI.UIAvatar pic_originStatu;
        internal Sunny.UI.UIAvatar pic_actStatu;
        internal System.Windows.Forms.Button btn_on;
        internal System.Windows.Forms.Button btn_off;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel1;
    }
}
