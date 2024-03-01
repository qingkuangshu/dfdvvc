namespace VM_Pro
{
    partial class Frm_CalibData
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
            this.nud_rotatePointNum = new Controls.CNumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_moveData = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_rotateData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.nud_movePointNum = new Controls.CNumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_moveData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rotateData)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLine5
            // 
            this.uiLine5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine5.LineSize = 2;
            this.uiLine5.Location = new System.Drawing.Point(0, 520);
            this.uiLine5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiLine5.MinimumSize = new System.Drawing.Size(18, 0);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(410, 2);
            this.uiLine5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine5.TabIndex = 129;
            this.uiLine5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nud_rotatePointNum
            // 
            this.nud_rotatePointNum.BackColor = System.Drawing.Color.White;
            this.nud_rotatePointNum.DecimalPlaces = 0;
            this.nud_rotatePointNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_rotatePointNum.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_rotatePointNum.Location = new System.Drawing.Point(156, 329);
            this.nud_rotatePointNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_rotatePointNum.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_rotatePointNum.MaxValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nud_rotatePointNum.MinimumSize = new System.Drawing.Size(50, 26);
            this.nud_rotatePointNum.MinValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nud_rotatePointNum.Name = "nud_rotatePointNum";
            this.nud_rotatePointNum.Size = new System.Drawing.Size(88, 26);
            this.nud_rotatePointNum.TabIndex = 137;
            this.nud_rotatePointNum.Value = 30D;
            this.nud_rotatePointNum.ValueChanged += new Controls.DValueChanged(this.nud_rotatePointNum_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 20);
            this.label8.TabIndex = 131;
            this.label8.Text = "XY  标定";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(117, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 136;
            this.label10.Text = "点数：";
            // 
            // dgv_moveData
            // 
            this.dgv_moveData.AllowUserToAddRows = false;
            this.dgv_moveData.AllowUserToDeleteRows = false;
            this.dgv_moveData.AllowUserToResizeColumns = false;
            this.dgv_moveData.AllowUserToResizeRows = false;
            this.dgv_moveData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_moveData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.Column15,
            this.Column16,
            this.Column13,
            this.Column14});
            this.dgv_moveData.Location = new System.Drawing.Point(16, 73);
            this.dgv_moveData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_moveData.Name = "dgv_moveData";
            this.dgv_moveData.RowHeadersVisible = false;
            this.dgv_moveData.RowTemplate.Height = 23;
            this.dgv_moveData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_moveData.Size = new System.Drawing.Size(378, 237);
            this.dgv_moveData.TabIndex = 130;
            this.dgv_moveData.Tag = "1";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "编号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 75;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "像素 X";
            this.Column15.Name = "Column15";
            this.Column15.Width = 75;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "像素 Y";
            this.Column16.Name = "Column16";
            this.Column16.Width = 75;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "机械 X";
            this.Column13.Name = "Column13";
            this.Column13.Width = 75;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "机械 Y";
            this.Column14.Name = "Column14";
            this.Column14.Width = 75;
            // 
            // dgv_rotateData
            // 
            this.dgv_rotateData.AllowUserToAddRows = false;
            this.dgv_rotateData.AllowUserToDeleteRows = false;
            this.dgv_rotateData.AllowUserToResizeColumns = false;
            this.dgv_rotateData.AllowUserToResizeRows = false;
            this.dgv_rotateData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_rotateData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgv_rotateData.Location = new System.Drawing.Point(16, 360);
            this.dgv_rotateData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_rotateData.Name = "dgv_rotateData";
            this.dgv_rotateData.RowHeadersVisible = false;
            this.dgv_rotateData.RowTemplate.Height = 23;
            this.dgv_rotateData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_rotateData.Size = new System.Drawing.Size(228, 145);
            this.dgv_rotateData.TabIndex = 135;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 75;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "像素 X";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "像素 Y";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 20);
            this.label9.TabIndex = 132;
            this.label9.Text = "U  标定";
            // 
            // nud_movePointNum
            // 
            this.nud_movePointNum.BackColor = System.Drawing.Color.White;
            this.nud_movePointNum.DecimalPlaces = 0;
            this.nud_movePointNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_movePointNum.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_movePointNum.Location = new System.Drawing.Point(158, 42);
            this.nud_movePointNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_movePointNum.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_movePointNum.MaxValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nud_movePointNum.MinimumSize = new System.Drawing.Size(50, 26);
            this.nud_movePointNum.MinValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nud_movePointNum.Name = "nud_movePointNum";
            this.nud_movePointNum.Size = new System.Drawing.Size(88, 26);
            this.nud_movePointNum.TabIndex = 134;
            this.nud_movePointNum.Value = 30D;
            this.nud_movePointNum.ValueChanged += new Controls.DValueChanged(this.nud_movePointNum_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(117, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 20);
            this.label14.TabIndex = 133;
            this.label14.Text = "点数：";
            // 
            // Frm_CalibData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 522);
            this.Controls.Add(this.nud_rotatePointNum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgv_moveData);
            this.Controls.Add(this.dgv_rotateData);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nud_movePointNum);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.uiLine5);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(52, 10);
            this.Name = "Frm_CalibData";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.ShowIcon = true;
            this.ShowInTaskbar = false;
            this.ShowRadius = false;
            this.ShowRect = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "标定数据";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleHeight = 31;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_MorePar_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_moveData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rotateData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILine uiLine5;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label10;
        internal System.Windows.Forms.DataGridView dgv_moveData;
        internal System.Windows.Forms.DataGridView dgv_rotateData;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label14;
        internal Controls.CNumericUpDown nud_rotatePointNum;
        internal Controls.CNumericUpDown nud_movePointNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}