namespace VM_Pro
{
    partial class Frm_ConnectSource
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
            this.tvw_itemList = new Sunny.UI.UINavMenu();
            this.label1 = new Sunny.UI.UILabel();
            this.tvw_toolList = new Sunny.UI.UINavMenu();
            this.lbl_toolName = new Sunny.UI.UILabel();
            this.lbl_inputName = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // uiLine5
            // 
            this.uiLine5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine5.LineSize = 2;
            this.uiLine5.Location = new System.Drawing.Point(0, 484);
            this.uiLine5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine5.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(664, 2);
            this.uiLine5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine5.TabIndex = 144;
            this.uiLine5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tvw_itemList
            // 
            this.tvw_itemList.AllowDrop = true;
            this.tvw_itemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvw_itemList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_itemList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvw_itemList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvw_itemList.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_itemList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvw_itemList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tvw_itemList.FullRowSelect = true;
            this.tvw_itemList.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tvw_itemList.ItemHeight = 35;
            this.tvw_itemList.Location = new System.Drawing.Point(233, 74);
            this.tvw_itemList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tvw_itemList.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.tvw_itemList.Name = "tvw_itemList";
            this.tvw_itemList.SecondBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tvw_itemList.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tvw_itemList.ShowItemsArrow = false;
            this.tvw_itemList.ShowLines = false;
            this.tvw_itemList.ShowNodeToolTips = true;
            this.tvw_itemList.ShowOneNode = true;
            this.tvw_itemList.ShowSecondBackColor = true;
            this.tvw_itemList.ShowTips = true;
            this.tvw_itemList.Size = new System.Drawing.Size(411, 392);
            this.tvw_itemList.Style = Sunny.UI.UIStyle.Custom;
            this.tvw_itemList.TabIndex = 154;
            this.tvw_itemList.TabStop = false;
            this.tvw_itemList.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvw_itemList.DoubleClick += new System.EventHandler(this.tvw_itemList_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.Style = Sunny.UI.UIStyle.Custom;
            this.label1.TabIndex = 155;
            this.label1.Text = "工具：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tvw_toolList
            // 
            this.tvw_toolList.AllowDrop = true;
            this.tvw_toolList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvw_toolList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_toolList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvw_toolList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvw_toolList.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_toolList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvw_toolList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tvw_toolList.FullRowSelect = true;
            this.tvw_toolList.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tvw_toolList.ItemHeight = 35;
            this.tvw_toolList.Location = new System.Drawing.Point(20, 74);
            this.tvw_toolList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tvw_toolList.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.tvw_toolList.Name = "tvw_toolList";
            this.tvw_toolList.SecondBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tvw_toolList.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tvw_toolList.ShowLines = false;
            this.tvw_toolList.ShowNodeToolTips = true;
            this.tvw_toolList.ShowOneNode = true;
            this.tvw_toolList.ShowSecondBackColor = true;
            this.tvw_toolList.ShowTips = true;
            this.tvw_toolList.Size = new System.Drawing.Size(205, 392);
            this.tvw_toolList.Style = Sunny.UI.UIStyle.Custom;
            this.tvw_toolList.TabIndex = 156;
            this.tvw_toolList.TabStop = false;
            this.tvw_toolList.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvw_toolList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvw_toolList_AfterSelect);
            // 
            // lbl_toolName
            // 
            this.lbl_toolName.AutoSize = true;
            this.lbl_toolName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_toolName.Location = new System.Drawing.Point(56, 48);
            this.lbl_toolName.Name = "lbl_toolName";
            this.lbl_toolName.Size = new System.Drawing.Size(23, 20);
            this.lbl_toolName.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_toolName.TabIndex = 157;
            this.lbl_toolName.Text = "值";
            this.lbl_toolName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_inputName
            // 
            this.lbl_inputName.AutoSize = true;
            this.lbl_inputName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_inputName.Location = new System.Drawing.Point(228, 48);
            this.lbl_inputName.Name = "lbl_inputName";
            this.lbl_inputName.Size = new System.Drawing.Size(51, 20);
            this.lbl_inputName.Style = Sunny.UI.UIStyle.Custom;
            this.lbl_inputName.TabIndex = 159;
            this.lbl_inputName.Text = "输入项";
            this.lbl_inputName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_ConnectSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 486);
            this.Controls.Add(this.lbl_inputName);
            this.Controls.Add(this.lbl_toolName);
            this.Controls.Add(this.tvw_toolList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvw_itemList);
            this.Controls.Add(this.uiLine5);
            this.ExtendSymbolSize = 20;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(664, 486);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(664, 486);
            this.Name = "Frm_ConnectSource";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowInTaskbar = false;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "连接源";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ToolIO_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILine uiLine5;
        internal Sunny.UI.UINavMenu tvw_itemList;
        private Sunny.UI.UILabel label1;
        internal Sunny.UI.UINavMenu tvw_toolList;
        internal Sunny.UI.UILabel lbl_toolName;
        internal Sunny.UI.UILabel lbl_inputName;
    }
}