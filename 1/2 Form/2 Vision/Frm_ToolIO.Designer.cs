namespace VM_Pro
{
    partial class Frm_ToolIO
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
            this.cbx_toolList = new Sunny.UI.UIComboBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.btn_nextOne = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.tvw_paraTree = new System.Windows.Forms.TreeView();
            this.tvw_inputItemList = new Sunny.UI.UINavMenu();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.删除toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.悬浮ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiContextMenuStrip1.SuspendLayout();
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
            // cbx_toolList
            // 
            this.cbx_toolList.DataSource = null;
            this.cbx_toolList.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_toolList.FillColor = System.Drawing.Color.White;
            this.cbx_toolList.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_toolList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_toolList.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbx_toolList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_toolList.Location = new System.Drawing.Point(66, 48);
            this.cbx_toolList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_toolList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_toolList.Name = "cbx_toolList";
            this.cbx_toolList.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_toolList.Radius = 0;
            this.cbx_toolList.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbx_toolList.RectColor = System.Drawing.Color.Silver;
            this.cbx_toolList.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.cbx_toolList.Size = new System.Drawing.Size(180, 28);
            this.cbx_toolList.Style = Sunny.UI.UIStyle.Custom;
            this.cbx_toolList.TabIndex = 146;
            this.cbx_toolList.Text = "测试";
            this.cbx_toolList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_toolList.Watermark = "";
            this.cbx_toolList.SelectedIndexChanged += new System.EventHandler(this.cbx_toolList_SelectedIndexChanged);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(16, 50);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(55, 20);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 145;
            this.uiLabel2.Text = "工具 ：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_nextOne
            // 
            this.btn_nextOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_nextOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_nextOne.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_nextOne.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btn_nextOne.Location = new System.Drawing.Point(259, 48);
            this.btn_nextOne.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_nextOne.MinimumSize = new System.Drawing.Size(1, 2);
            this.btn_nextOne.Name = "btn_nextOne";
            this.btn_nextOne.RectSelectedColor = System.Drawing.Color.Empty;
            this.btn_nextOne.Size = new System.Drawing.Size(70, 28);
            this.btn_nextOne.Style = Sunny.UI.UIStyle.Custom;
            this.btn_nextOne.StyleCustomMode = true;
            this.btn_nextOne.TabIndex = 147;
            this.btn_nextOne.Text = "下一个";
            this.btn_nextOne.TipsText = "100";
            this.btn_nextOne.Click += new System.EventHandler(this.btn_nextOne_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(584, 50);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(65, 20);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 152;
            this.uiLabel1.Text = "已添加项";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tvw_paraTree
            // 
            this.tvw_paraTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_paraTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvw_paraTree.FullRowSelect = true;
            this.tvw_paraTree.Location = new System.Drawing.Point(20, 82);
            this.tvw_paraTree.Name = "tvw_paraTree";
            this.tvw_paraTree.Size = new System.Drawing.Size(309, 384);
            this.tvw_paraTree.TabIndex = 153;
            this.tvw_paraTree.DoubleClick += new System.EventHandler(this.tvw_paraTree_DoubleClick);
            // 
            // tvw_inputItemList
            // 
            this.tvw_inputItemList.AllowDrop = true;
            this.tvw_inputItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvw_inputItemList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_inputItemList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvw_inputItemList.ContextMenuStrip = this.uiContextMenuStrip1;
            this.tvw_inputItemList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvw_inputItemList.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvw_inputItemList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvw_inputItemList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tvw_inputItemList.FullRowSelect = true;
            this.tvw_inputItemList.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tvw_inputItemList.ItemHeight = 32;
            this.tvw_inputItemList.Location = new System.Drawing.Point(335, 82);
            this.tvw_inputItemList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tvw_inputItemList.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.tvw_inputItemList.Name = "tvw_inputItemList";
            this.tvw_inputItemList.SecondBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tvw_inputItemList.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tvw_inputItemList.ShowLines = false;
            this.tvw_inputItemList.ShowNodeToolTips = true;
            this.tvw_inputItemList.ShowOneNode = true;
            this.tvw_inputItemList.ShowSecondBackColor = true;
            this.tvw_inputItemList.ShowTips = true;
            this.tvw_inputItemList.Size = new System.Drawing.Size(309, 384);
            this.tvw_inputItemList.Style = Sunny.UI.UIStyle.Custom;
            this.tvw_inputItemList.TabIndex = 154;
            this.tvw_inputItemList.TabStop = false;
            this.tvw_inputItemList.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvw_inputItemList.DoubleClick += new System.EventHandler(this.tvw_inputItemList_DoubleClick);
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.AutoSize = false;
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除toolStripMenuItem1,
            this.悬浮ToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(150, 60);
            // 
            // 删除toolStripMenuItem1
            // 
            this.删除toolStripMenuItem1.AutoSize = false;
            this.删除toolStripMenuItem1.Name = "删除toolStripMenuItem1";
            this.删除toolStripMenuItem1.Size = new System.Drawing.Size(149, 28);
            this.删除toolStripMenuItem1.Text = "删除";
            this.删除toolStripMenuItem1.Click += new System.EventHandler(this.删除toolStripMenuItem1_Click);
            // 
            // 悬浮ToolStripMenuItem
            // 
            this.悬浮ToolStripMenuItem.AutoSize = false;
            this.悬浮ToolStripMenuItem.Name = "悬浮ToolStripMenuItem";
            this.悬浮ToolStripMenuItem.Size = new System.Drawing.Size(149, 28);
            this.悬浮ToolStripMenuItem.Text = "备用";
            // 
            // Frm_ToolIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 486);
            this.Controls.Add(this.tvw_inputItemList);
            this.Controls.Add(this.tvw_paraTree);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.btn_nextOne);
            this.Controls.Add(this.cbx_toolList);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLine5);
            this.ExtendSymbolSize = 20;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(664, 486);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(664, 486);
            this.Name = "Frm_ToolIO";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowInTaskbar = false;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "工具终端配置";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ToolIO_FormClosing);
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILine uiLine5;
        internal Sunny.UI.UIComboBox cbx_toolList;
        private Sunny.UI.UILabel uiLabel2;
        internal Sunny.UI.UIButton btn_nextOne;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.TreeView tvw_paraTree;
        internal Sunny.UI.UINavMenu tvw_inputItemList;
        internal Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 悬浮ToolStripMenuItem;
    }
}