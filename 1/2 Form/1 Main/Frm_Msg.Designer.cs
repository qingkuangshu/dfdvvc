namespace VM_Pro
{
    partial class Frm_Msg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Msg));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsb_tip = new System.Windows.Forms.ToolStripButton();
            this.tsb_warn = new System.Windows.Forms.ToolStripButton();
            this.tsb_error = new System.Windows.Forms.ToolStripButton();
            this.tsb_historyAlarm = new System.Windows.Forms.ToolStripButton();
            this.tbx_msg = new System.Windows.Forms.RichTextBox();
            this.uiContextMenuStrip2 = new Sunny.UI.UIContextMenuStrip();
            this.清除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.清除历史报警ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停滚动3分钟toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2.SuspendLayout();
            this.uiContextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.White;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_tip,
            this.tsb_warn,
            this.tsb_error,
            this.tsb_historyAlarm});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(715, 31);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsb_tip
            // 
            this.tsb_tip.AutoToolTip = false;
            this.tsb_tip.CheckOnClick = true;
            this.tsb_tip.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tip.Image")));
            this.tsb_tip.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsb_tip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tip.Name = "tsb_tip";
            this.tsb_tip.Size = new System.Drawing.Size(82, 28);
            this.tsb_tip.Text = "提示(0)";
            this.tsb_tip.Click += new System.EventHandler(this.tsb_tip_Click);
            // 
            // tsb_warn
            // 
            this.tsb_warn.AutoToolTip = false;
            this.tsb_warn.CheckOnClick = true;
            this.tsb_warn.Image = ((System.Drawing.Image)(resources.GetObject("tsb_warn.Image")));
            this.tsb_warn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsb_warn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_warn.Name = "tsb_warn";
            this.tsb_warn.Size = new System.Drawing.Size(82, 28);
            this.tsb_warn.Text = "警告(0)";
            this.tsb_warn.Click += new System.EventHandler(this.tsb_warn_Click);
            // 
            // tsb_error
            // 
            this.tsb_error.AutoToolTip = false;
            this.tsb_error.CheckOnClick = true;
            this.tsb_error.Image = ((System.Drawing.Image)(resources.GetObject("tsb_error.Image")));
            this.tsb_error.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsb_error.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_error.Name = "tsb_error";
            this.tsb_error.Size = new System.Drawing.Size(82, 28);
            this.tsb_error.Text = "错误(0)";
            this.tsb_error.Click += new System.EventHandler(this.tsb_error_Click);
            // 
            // tsb_historyAlarm
            // 
            this.tsb_historyAlarm.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_historyAlarm.AutoToolTip = false;
            this.tsb_historyAlarm.CheckOnClick = true;
            this.tsb_historyAlarm.Image = ((System.Drawing.Image)(resources.GetObject("tsb_historyAlarm.Image")));
            this.tsb_historyAlarm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsb_historyAlarm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_historyAlarm.Name = "tsb_historyAlarm";
            this.tsb_historyAlarm.Size = new System.Drawing.Size(112, 28);
            this.tsb_historyAlarm.Text = "历史报警(0)";
            this.tsb_historyAlarm.Click += new System.EventHandler(this.tsb_historyAlarm_Click);
            // 
            // tbx_msg
            // 
            this.tbx_msg.BackColor = System.Drawing.Color.White;
            this.tbx_msg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_msg.ContextMenuStrip = this.uiContextMenuStrip2;
            this.tbx_msg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_msg.DetectUrls = false;
            this.tbx_msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_msg.EnableAutoDragDrop = true;
            this.tbx_msg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_msg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tbx_msg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbx_msg.Location = new System.Drawing.Point(0, 31);
            this.tbx_msg.Margin = new System.Windows.Forms.Padding(4, 75, 4, 4);
            this.tbx_msg.Name = "tbx_msg";
            this.tbx_msg.ReadOnly = true;
            this.tbx_msg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbx_msg.Size = new System.Drawing.Size(715, 115);
            this.tbx_msg.TabIndex = 4;
            this.tbx_msg.TabStop = false;
            this.tbx_msg.Text = "";
            this.tbx_msg.DoubleClick += new System.EventHandler(this.tbx_msg_DoubleClick);
            // 
            // uiContextMenuStrip2
            // 
            this.uiContextMenuStrip2.AutoSize = false;
            this.uiContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除ToolStripMenuItem1,
            this.清除历史报警ToolStripMenuItem1,
            this.暂停滚动3分钟toolStripMenuItem1});
            this.uiContextMenuStrip2.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip2.Size = new System.Drawing.Size(153, 88);
            this.uiContextMenuStrip2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // 清除ToolStripMenuItem1
            // 
            this.清除ToolStripMenuItem1.AutoSize = false;
            this.清除ToolStripMenuItem1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F);
            this.清除ToolStripMenuItem1.Name = "清除ToolStripMenuItem1";
            this.清除ToolStripMenuItem1.Size = new System.Drawing.Size(152, 28);
            this.清除ToolStripMenuItem1.Text = "清除";
            this.清除ToolStripMenuItem1.Click += new System.EventHandler(this.清除ToolStripMenuItem_Click_1);
            // 
            // 清除历史报警ToolStripMenuItem1
            // 
            this.清除历史报警ToolStripMenuItem1.AutoSize = false;
            this.清除历史报警ToolStripMenuItem1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F);
            this.清除历史报警ToolStripMenuItem1.Name = "清除历史报警ToolStripMenuItem1";
            this.清除历史报警ToolStripMenuItem1.Size = new System.Drawing.Size(152, 28);
            this.清除历史报警ToolStripMenuItem1.Text = "清除历史报警";
            this.清除历史报警ToolStripMenuItem1.Click += new System.EventHandler(this.清除历史报警ToolStripMenuItem_Click);
            // 
            // 暂停滚动3分钟toolStripMenuItem1
            // 
            this.暂停滚动3分钟toolStripMenuItem1.AutoSize = false;
            this.暂停滚动3分钟toolStripMenuItem1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F);
            this.暂停滚动3分钟toolStripMenuItem1.Name = "暂停滚动3分钟toolStripMenuItem1";
            this.暂停滚动3分钟toolStripMenuItem1.Size = new System.Drawing.Size(152, 28);
            this.暂停滚动3分钟toolStripMenuItem1.Text = "暂停滚动5分钟";
            this.暂停滚动3分钟toolStripMenuItem1.Click += new System.EventHandler(this.暂停滚动3分钟toolStripMenuItem1_Click);
            // 
            // Frm_Msg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 146);
            this.Controls.Add(this.tbx_msg);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Msg";
            this.Text = "Frm_Msg";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.uiContextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        internal System.Windows.Forms.ToolStripButton tsb_tip;
        internal System.Windows.Forms.ToolStripButton tsb_warn;
        internal System.Windows.Forms.ToolStripButton tsb_error;
        internal System.Windows.Forms.ToolStripButton tsb_historyAlarm;
        internal System.Windows.Forms.RichTextBox tbx_msg;
        private System.Windows.Forms.ToolStripMenuItem 清除ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 清除历史报警ToolStripMenuItem1;
        internal Sunny.UI.UIContextMenuStrip uiContextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 暂停滚动3分钟toolStripMenuItem1;
    }
}