namespace ChoiceTech.Halcon.Control
{
    partial class HWindow_Final
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
                hv_MenuStrip.Dispose();

                mCtrl_HWindow.HMouseMove -= HWindowControl_HMouseMove;
            }
            if (disposing && hv_image != null)
            {
                hv_image.Dispose();
            }
            if (disposing && hv_window != null)
            {
                hv_window.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HWindow_Final));
            this.m_CtrlHStatusLabelCtrl = new System.Windows.Forms.Label();
            this.m_CtrlImageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.mCtrl_HWindow = new HalconDotNet.HWindowControl();
            this.SuspendLayout();
            // 
            // m_CtrlHStatusLabelCtrl
            // 
            this.m_CtrlHStatusLabelCtrl.AutoSize = true;
            this.m_CtrlHStatusLabelCtrl.BackColor = System.Drawing.Color.White;
            this.m_CtrlHStatusLabelCtrl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_CtrlHStatusLabelCtrl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_CtrlHStatusLabelCtrl.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_CtrlHStatusLabelCtrl.Location = new System.Drawing.Point(0, 331);
            this.m_CtrlHStatusLabelCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.m_CtrlHStatusLabelCtrl.Name = "m_CtrlHStatusLabelCtrl";
            this.m_CtrlHStatusLabelCtrl.Size = new System.Drawing.Size(63, 19);
            this.m_CtrlHStatusLabelCtrl.TabIndex = 1;
            this.m_CtrlHStatusLabelCtrl.Text = "111111";
            // 
            // m_CtrlImageList
            // 
            this.m_CtrlImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_CtrlImageList.ImageStream")));
            this.m_CtrlImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_CtrlImageList.Images.SetKeyName(0, "TableIcon.png");
            this.m_CtrlImageList.Images.SetKeyName(1, "PicturesIcon.png");
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(533, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "图像";
            // 
            // mCtrl_HWindow
            // 
            this.mCtrl_HWindow.BackColor = System.Drawing.Color.Black;
            this.mCtrl_HWindow.BorderColor = System.Drawing.Color.Black;
            this.mCtrl_HWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mCtrl_HWindow.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.mCtrl_HWindow.Location = new System.Drawing.Point(0, 15);
            this.mCtrl_HWindow.Name = "mCtrl_HWindow";
            this.mCtrl_HWindow.Size = new System.Drawing.Size(533, 316);
            this.mCtrl_HWindow.TabIndex = 3;
            this.mCtrl_HWindow.WindowSize = new System.Drawing.Size(533, 316);
            this.mCtrl_HWindow.HMouseMove += new HalconDotNet.HMouseEventHandler(this.HWindowControl_HMouseMove);
            this.mCtrl_HWindow.HMouseDown += new HalconDotNet.HMouseEventHandler(this.mCtrl_HWindow_HMouseDown);
            this.mCtrl_HWindow.Click += new System.EventHandler(this.mCtrl_HWindow_Click);
            this.mCtrl_HWindow.MouseLeave += new System.EventHandler(this.mCtrl_HWindow_MouseLeave);
            // 
            // HWindow_Final
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.mCtrl_HWindow);
            this.Controls.Add(this.m_CtrlHStatusLabelCtrl);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HWindow_Final";
            this.Size = new System.Drawing.Size(533, 350);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList m_CtrlImageList;
        public System.Windows.Forms.Label m_CtrlHStatusLabelCtrl;
        internal System.Windows.Forms.Label label1;
        private HalconDotNet.HWindowControl mCtrl_HWindow;
    }
}
