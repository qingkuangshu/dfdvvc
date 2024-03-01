using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using System.IO;
using System.Reflection;

namespace VM_Pro
{
    public partial class Frm_PosTableEdit : UIForm
    {
        public Frm_PosTableEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_PosTableEdit _instance;
        internal static Frm_PosTableEdit Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_PosTableEdit();
                return _instance;
            }
        }


        private void Frm_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            string pointFormName = FuncLib.ShowInput("请输入表名称");
            if (pointFormName == "")
                return;

            //查重
            if (Scheme.curScheme.smartPosTable.TableExist(pointFormName))
            {
                FuncLib.ShowMessageBox(string.Format("\r\n点表中已存在名为{0}的表，请勿重复添加", pointFormName), InfoType.Error);
                return;
            }

            Frm_Motion.Instance.cbx_tableList.Items.Add(pointFormName);
            Scheme.curScheme.smartPosTable.L_Table.Add(new Table(pointFormName));


            if (Frm_Motion.Instance.cbx_tableList.Text == string.Empty)
                Frm_Motion.Instance.cbx_tableList.SelectedIndex = 0;

            int idx = dataGridView1.Rows.Add();
            dataGridView1.Rows[idx].Cells[0].Value = dataGridView1.Rows.Count + 1;
            dataGridView1.Rows[idx].Cells[1].Value = pointFormName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idx = dataGridView1.SelectedRows[0].Index;
            if (idx < 0)
                return;

            if (idx == 0)
                return;

            Table temp = Scheme.curScheme.smartPosTable.L_Table[idx - 1];
            Scheme.curScheme.smartPosTable.L_Table[idx - 1] = Scheme.curScheme.smartPosTable.L_Table[idx];
            Scheme.curScheme.smartPosTable.L_Table[idx] = temp;

            string obj = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index - 1].Cells[1].Value.ToString();
            dataGridView1.Rows[dataGridView1.SelectedRows[0].Index - 1].Cells[1].Value = dataGridView1.SelectedRows[0].Cells[1].Value;
            dataGridView1.SelectedRows[0].Cells[1].Value = obj;

            dataGridView1.Rows[idx - 1].Selected = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idx = dataGridView1.SelectedRows[0].Index;
            if (idx < 0)
                return;

            if (idx == dataGridView1.Rows.Count - 1)
                return;

            Table temp = Scheme.curScheme.smartPosTable.L_Table[idx + 1];
            Scheme.curScheme.smartPosTable.L_Table[idx + 1] = Scheme.curScheme.smartPosTable.L_Table[idx];
            Scheme.curScheme.smartPosTable.L_Table[idx] = temp;

            string obj = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index + 1].Cells[1].Value.ToString();
            dataGridView1.Rows[dataGridView1.SelectedRows[0].Index + 1].Cells[1].Value = dataGridView1.SelectedRows[0].Cells[1].Value;
            dataGridView1.SelectedRows[0].Cells[1].Value = obj;

            dataGridView1.Rows[idx + 1].Selected = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int idx = dataGridView1.SelectedRows[0].Index;
            dataGridView1.Rows.RemoveAt(idx);
            Scheme.curScheme.smartPosTable.L_Table.RemoveAt(idx);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //查重
            if (Scheme.curScheme.smartPosTable.FindTable(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).L_axis.Contains(comboBox2.Text))
            {
                FuncLib.ShowMessageBox(string.Format("\r\n此表中已存在{0}轴，请勿重复添加", comboBox2.Text), InfoType.Error);
                return;
            }

            if (Frm_Motion.Instance.cbx_tableList.Text == dataGridView1.SelectedRows[0].Cells[1].Value.ToString())
            {
                int idx = Frm_Motion.Instance.dgv_pointList.Columns.Add("", comboBox2.Text);
                Frm_Motion.Instance.dgv_pointList.Columns[idx].Width = 70;
            }
            Scheme.curScheme.smartPosTable.FindTable(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).L_axis.Add(comboBox2.Text);

            int idx1 = dataGridView2.Rows.Add();
            dataGridView2.Rows[idx1].Cells[0].Value = dataGridView1.Rows.Count + 1;
            dataGridView2.Rows[idx1].Cells[1].Value = comboBox2.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int idx = dataGridView2.SelectedRows[0].Index;
            if (idx < 0)
                return;

            if (idx == 0)
                return;

            string temp = Scheme.curScheme.smartPosTable.FindTable(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).L_axis[idx - 1];
            Scheme.curScheme.smartPosTable.FindTable(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).L_axis[idx - 1] = Scheme.curScheme.smartPosTable.FindTable(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).L_axis[idx];
            Scheme.curScheme.smartPosTable.FindTable(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).L_axis[idx] = temp;

            string obj = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index - 1].Cells[1].Value.ToString();
            dataGridView2.Rows[dataGridView2.SelectedRows[0].Index - 1].Cells[1].Value = dataGridView2.SelectedRows[0].Cells[1].Value;
            dataGridView2.SelectedRows[0].Cells[1].Value = obj;

            Scheme.curScheme.smartPosTable.LoadData(Frm_Motion.Instance.dgv_pointList, Frm_Motion.Instance.cbx_tableList.Text);

            dataGridView2.Rows[idx - 1].Selected = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int idx = dataGridView2.SelectedRows[0].Index;
            if (idx < 0)
                return;

            if (idx == dataGridView2.Rows.Count - 1)
                return;

            string temp = Scheme.curScheme.smartPosTable.FindTable(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).L_axis[idx + 1];
            Scheme.curScheme.smartPosTable.FindTable(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).L_axis[idx + 1] = Scheme.curScheme.smartPosTable.FindTable(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).L_axis[idx];
            Scheme.curScheme.smartPosTable.FindTable(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).L_axis[idx] = temp;

            string obj = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index + 1].Cells[1].Value.ToString();
            dataGridView2.Rows[dataGridView2.SelectedRows[0].Index + 1].Cells[1].Value = dataGridView2.SelectedRows[0].Cells[1].Value;
            dataGridView2.SelectedRows[0].Cells[1].Value = obj;

            Scheme.curScheme.smartPosTable.LoadData(Frm_Motion.Instance.dgv_pointList, Frm_Motion.Instance.cbx_tableList.Text);

            dataGridView2.Rows[idx + 1].Selected = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Scheme.curScheme.smartPosTable.FindTable(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()).L_axis.RemoveAt(dataGridView2.SelectedRows[0].Index);
            dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
            Frm_Motion.Instance.dgv_pointList.Columns.RemoveAt(dataGridView2.SelectedRows[0].Index + 3);
        }

        private void Frm_PosTableEdit_Load(object sender, EventArgs e)
        {
            Frm_PosTableEdit.Instance.dataGridView1.Rows.Clear();
            for (int i = 0; i < Scheme.curScheme.smartPosTable.L_Table.Count; i++)
            {
                int idx = Frm_PosTableEdit.Instance.dataGridView1.Rows.Add();
                Frm_PosTableEdit.Instance.dataGridView1.Rows[idx].Cells[0].Value = i + 1;
                Frm_PosTableEdit.Instance.dataGridView1.Rows[idx].Cells[1].Value = Scheme.curScheme.smartPosTable.L_Table[i].tableName;
            }
        }

    }
}
