using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    [Serializable]
    public class SmartPosTable
    {
        public double velPer = 0.2;
        public List<Table> L_Table = new List<Table>();
        internal Table FindTable(string tableName)
        {
            for (int i = 0; i < L_Table.Count; i++)
            {
                if (L_Table[i].tableName == tableName)
                    return L_Table[i];
            }
            return new Table("");
        }

        internal bool TableExist(string tableName)
        {
            for (int i = 0; i < L_Table.Count; i++)
            {
                if (L_Table[i].tableName == tableName)
                    return true;
            }
            return false;
        }
        internal static bool IsNearPoint(string tableName, string posName, double curPos)
        {
            try
            {
                for (int i = 0; i < Scheme.curScheme.smartPosTable.L_Table.Count; i++)
                {
                    if (Scheme.curScheme.smartPosTable.L_Table[i].tableName == tableName)
                    {
                        for (int j = 0; j < Scheme.curScheme.smartPosTable.L_Table[i].L_pos.Count; j++)
                        {
                            if (Scheme.curScheme.smartPosTable.L_Table[i].L_pos[j].posName == posName)
                            {
                                for (int k = 0; k < Scheme.curScheme.smartPosTable.L_Table[i].L_pos[j].L_point.Count; k++)
                                {
                                    if (Math.Abs(Scheme.curScheme.smartPosTable.L_Table[i].L_pos[j].L_point[k] - curPos) > 0.2)
                                        return false;
                                    else
                                        return true;
                                }
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        private static object obj = new object();
        internal static bool GoPos(string tableName, string posName, bool waitDone = true, double rate = 1)
        {
            try
            {
                bool notFind = true;
                for (int i = 0; i < Scheme.curScheme.smartPosTable.L_Table.Count; i++)
                {
                    if (Scheme.curScheme.smartPosTable.L_Table[i].tableName == tableName)
                    {
                        for (int j = 0; j < Scheme.curScheme.smartPosTable.L_Table[i].L_pos.Count; j++)
                        {
                            if (Scheme.curScheme.smartPosTable.L_Table[i].L_pos[j].posName == posName)
                            {
                                notFind = false;
                                for (int k = 0; k < Scheme.curScheme.smartPosTable.L_Table[i].L_pos[j].L_point.Count; k++)
                                {
                                    if (!((CCard)Project.FindServiceByName("运动控制卡")).cardBase.MoveAbs(Scheme.curScheme.smartPosTable.L_Table[i].L_axis[k], (int)(Scheme.curScheme.smartPosTable.L_Table[i].L_pos[j].L_point[k]), (int)(Scheme.curScheme.smartPosTable.L_Table[i].L_pos[j].vel * rate), waitDone))
                                        return false;
                                }
                            }
                        }
                    }
                }
                if (notFind)
                {
                    FuncLib.ShowMsg(string.Format("点位表中未查询到表名称为【{0}】点名称为【{1}】的点位，请检查", tableName, posName), InfoType.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        internal static bool GoPos(int tableIndex, int posIndex)
        {
            try
            {
                for (int i = 0; i < Scheme.curScheme.smartPosTable.L_Table[tableIndex].L_pos[posIndex].L_point.Count; i++)
                {
                    if (!((CCard)Project.FindServiceByName("运动控制卡")).cardBase.MoveAbs(Scheme.curScheme.smartPosTable.L_Table[tableIndex].L_axis[i], (Scheme.curScheme.smartPosTable.L_Table[tableIndex].L_pos[posIndex].L_point[i]), (int)(Scheme.curScheme.smartPosTable.L_Table[tableIndex].L_pos[posIndex].vel / 2), true))
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        internal void LoadData(DataGridView dgv_pointList, string tableName)
        {
            Frm_Motion.initPointList = true;
            dgv_pointList.Rows.Clear();
            dgv_pointList.Columns.Clear();
            int index = dgv_pointList.Columns.Add("", "  编号");
            dgv_pointList.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_pointList.Columns[index].Width = 62;
            dgv_pointList.Columns[index].ReadOnly = true;
            dgv_pointList.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = "  示教";
            column.Text = "示教";
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.Width = 62;
            dgv_pointList.Columns.Add(column);

            DataGridViewButtonColumn column2 = new DataGridViewButtonColumn();
            column2.HeaderText = "  前往";
            column2.Text = "Go";
            column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            column2.Width = 62;
            dgv_pointList.Columns.Add(column2);

            index = dgv_pointList.Columns.Add("", "名称");
            dgv_pointList.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_pointList.Columns[index].Width = 190;
            if (Permission.CurPermissionGrade == PermissionGrade.Developer)
                dgv_pointList.Columns[index].ReadOnly = false;
            else
                dgv_pointList.Columns[index].ReadOnly = true;

            index = dgv_pointList.Columns.Add("", "  速度");
            dgv_pointList.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_pointList.Columns[index].Width = 62;
            dgv_pointList.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
                dgv_pointList.Columns[index].ReadOnly = false;
            else
                dgv_pointList.Columns[index].ReadOnly = true;

            for (int i = 0; i < Scheme.curScheme.smartPosTable.FindTable(tableName).L_axis.Count; i++)
            {
                int temp = dgv_pointList.Columns.Add("", Scheme.curScheme.smartPosTable.FindTable(tableName).L_axis[i]);
                dgv_pointList.Columns[temp].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv_pointList.Columns[temp].Width = 80;
                dgv_pointList.Columns[temp].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (Permission.CheckPermission(PermissionGrade.Admin, false))
                    dgv_pointList.Columns[temp].ReadOnly = false;
                else
                    dgv_pointList.Columns[temp].ReadOnly = true;
            }


            for (int i = 0; i < Scheme.curScheme.smartPosTable.FindTable(tableName).L_pos.Count; i++)
            {
                int idx = dgv_pointList.Rows.Add();
                dgv_pointList.Rows[idx].Cells[0].Value = idx + 1;
                dgv_pointList.Rows[idx].Cells[1].Value = "示教";
                dgv_pointList.Rows[idx].Cells[2].Value = "Go";
                dgv_pointList.Rows[idx].Cells[3].Value = Scheme.curScheme.smartPosTable.FindTable(tableName).L_pos[i].posName;
                dgv_pointList.Rows[idx].Cells[4].Value = Scheme.curScheme.smartPosTable.FindTable(tableName).L_pos[i].vel;
                for (int j = 0; j < Scheme.curScheme.smartPosTable.FindTable(tableName).L_pos[i].L_point.Count; j++)
                {
                    dgv_pointList.Rows[idx].Cells[5 + j].Value = Scheme.curScheme.smartPosTable.FindTable(tableName).L_pos[i].L_point[j];
                }
            }
            
            Frm_Motion.initPointList = false;
        }
    }

    [Serializable]
    public class Table
    {
        internal Table(string tableName)
        {
            this.tableName = tableName;
        }
        internal string tableName = string.Empty;
        internal List<string> L_axis = new List<string>();
        internal List<Pos> L_pos = new List<Pos>();
    }

    [Serializable]
    public class Pos
    {
        internal Pos(string posName, int vel, List<double> point)
        {
            this.posName = posName;
            this.vel = vel;
            this.L_point = point;
        }
        internal string posName;
        internal int vel;
        internal List<double> L_point;
    }
}
