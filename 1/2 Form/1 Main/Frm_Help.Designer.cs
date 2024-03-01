namespace VM_Pro
{
    partial class Frm_Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Help));
            this.txt_InfoHelp = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // txt_InfoHelp
            // 
            this.txt_InfoHelp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_InfoHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_InfoHelp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_InfoHelp.Location = new System.Drawing.Point(0, 35);
            this.txt_InfoHelp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_InfoHelp.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_InfoHelp.Multiline = true;
            this.txt_InfoHelp.Name = "txt_InfoHelp";
            this.txt_InfoHelp.ReadOnly = true;
            this.txt_InfoHelp.RectColor = System.Drawing.Color.Green;
            this.txt_InfoHelp.ScrollBarColor = System.Drawing.Color.Green;
            this.txt_InfoHelp.ShowText = false;
            this.txt_InfoHelp.Size = new System.Drawing.Size(800, 415);
            this.txt_InfoHelp.Style = Sunny.UI.UIStyle.Custom;
            this.txt_InfoHelp.TabIndex = 0;
            this.txt_InfoHelp.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_InfoHelp.Watermark = "";
            this.txt_InfoHelp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Frm_Help
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_InfoHelp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Help";
            this.RectColor = System.Drawing.Color.Green;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "工具帮助说明";
            this.TitleColor = System.Drawing.Color.Green;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Help_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        internal Sunny.UI.UITextBox txt_InfoHelp;
    }
}