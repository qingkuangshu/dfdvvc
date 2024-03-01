using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChoiceTech.Halcon.Control;
using System.IO;
using HalconDotNet;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace VM_Pro
{
    public partial class Frm_Motion : UIPage
    {
        public Frm_Motion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 修改前的值
        /// </summary>
        private static string valueBeforeEdit = string.Empty;
        /// <summary>
        /// 初始化点位表
        /// </summary>
        internal static bool initPointList = true;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Motion _instance;
        internal static Frm_Motion Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Motion();
                return _instance;
            }
        }


        internal void SaveAxisPoint()
        {
            Scheme.curScheme.smartPosTable.FindTable(cbx_tableList.Text).L_pos.Clear();

            if (Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                for (int i = 0; i < dgv_pointList.Rows.Count - 1; i++)
                {
                    //检查速度是否超过80
                    if (cbx_tableList.Text == "横移轴")
                    {
                        if (Convert.ToInt16(dgv_pointList.Rows[i].Cells[4].Value) > 80)
                            dgv_pointList.Rows[i].Cells[4].Value = "80";
                    }

                    List<double> point = new List<double>();
                    for (int j = 5; j < dgv_pointList.Columns.Count; j++)
                    {
                        point.Add(Convert.ToDouble(dgv_pointList.Rows[i].Cells[j].Value));
                    }

                    string posName = (dgv_pointList.Rows[i].Cells[3].Value == null ? "" : dgv_pointList.Rows[i].Cells[3].Value.ToString());
                    int vel = (dgv_pointList.Rows[i].Cells[4].Value == null ? 10 : Convert.ToInt32(dgv_pointList.Rows[i].Cells[4].Value));
                    Pos pos = new Pos(posName, vel, point);

                    ////检查点位命名是否重复
                    //List<Pos> list = Scheme.curScheme.smartPosTable.FindTable(cbx_tableList.Text).L_pos;
                    //for (int j = 0; j < list.Count; j++)
                    //{
                    //    if (list[j].posName == posName)
                    //    {
                    //        dgv_pointList.Rows[i].Selected = true;
                    //        FuncLib.ShowMsg(string.Format("\r\n      当前点位表中存在两个名为 {0} 的点位，点位名称不可重复，请修改", posName), InfoType.Error);
                    //    }
                    //}

                    Scheme.curScheme.smartPosTable.FindTable(cbx_tableList.Text).L_pos.Add(pos);
                }
            }
            else
            {
                for (int i = 0; i < dgv_pointList.Rows.Count; i++)
                {
                    //检查速度是否超过80
                    if (cbx_tableList.Text == "横移轴")
                    {
                        if (Convert.ToInt16(dgv_pointList.Rows[i].Cells[4].Value) > 80)
                            dgv_pointList.Rows[i].Cells[4].Value = "80";
                    }

                    List<double> point = new List<double>();
                    for (int j = 5; j < dgv_pointList.Columns.Count; j++)
                    {
                        point.Add(Convert.ToDouble(dgv_pointList.Rows[i].Cells[j].Value));
                    }

                    string posName = (dgv_pointList.Rows[i].Cells[3].Value == null ? "" : dgv_pointList.Rows[i].Cells[3].Value.ToString());
                    int vel = (dgv_pointList.Rows[i].Cells[4].Value == null ? 10 : Convert.ToInt32(dgv_pointList.Rows[i].Cells[4].Value));
                    Pos pos = new Pos(posName, vel, point);

                    //检查点位命名是否重复
                    //List<Pos> list = Scheme.curScheme.smartPosTable.FindTable(cbx_tableList.Text).L_pos;
                    //for (int j = 0; j < list.Count; j++)
                    //{
                    //    if (list[j].posName == posName)
                    //    {
                    //        dgv_pointList.Rows[i].Selected = true;
                    //        FuncLib.ShowMsg(string.Format("      当前点位表中存在两个名为 {0} 的点位，点位名称不可重复，请修改", posName), InfoType.Error);
                    //    }
                    //}

                    Scheme.curScheme.smartPosTable.FindTable(cbx_tableList.Text).L_pos.Add(pos);
                }
            }
        }
        private void Frm_Vision_Load(object sender, EventArgs e)
        {
            cbx_cardList.Items.Clear();
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Card)
                {
                    cbx_cardList.Items.Add(Project.Instance.L_Service[i].name);
                    cbx_axisList.Items.Clear();
                    cbx_axisList.Items.AddRange(((CCard)Project.Instance.L_Service[i]).cardBase.L_axisName.ToArray());
                    break;
                }
            }

            if (cbx_cardList.Items.Count > 0)
                cbx_cardList.Text = cbx_cardList.Items[0].ToString();
            if (cbx_axisList.Items.Count > 0)
                cbx_axisList.Text = cbx_axisList.Items[0].ToString();
            cbx_axisList.SelectedIndex = selectedIndex;

            if (dgv_pointList.Rows.Count == 1)
            {
                dgv_pointList.Rows[0].Cells[0].Value = 1;
                dgv_pointList.Rows[0].Cells[1].Value = "示教";
                dgv_pointList.Rows[0].Cells[2].Value = "Go";
                dgv_pointList.Rows[0].Cells[3].Value = 10;
                dgv_pointList.Rows[0].Cells[4].Value = "备用";
            }
        }
        private void 工具箱toolStripButton5_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            if (Frm_Task.Instance.splitContainer2.Panel1Collapsed)
            {
                Frm_Task.Instance.splitContainer1.Panel1Collapsed = false;
                Frm_Task.Instance.splitContainer2.Panel1Collapsed = false;
                Frm_Task.Instance.splitContainer2.Panel2Collapsed = true;
            }
            else
            {
                Project.Instance.configuration.toolBoxStatu = 1;
                Frm_Task.Instance.splitContainer1.Panel1Collapsed = true;
                Frm_Task.Instance.C_toolBox.Parent = Frm_ToolBox.Instance;
                Frm_Task.Instance.C_toolBox.Dock = DockStyle.Fill;
                Frm_ToolBox.Instance.Location = new Point(Frm_Main.Instance.Location.X - 151, Frm_Main.Instance.Location.Y + 172);
                Frm_ToolBox.Instance.Show();
            }
        }

        private void rdo_jog_Click(object sender, EventArgs e)
        {
            cbx_distance.Visible = false;
            label22.Visible = false;
        }
        private void rdo_move_Click(object sender, EventArgs e)
        {
            cbx_distance.Visible = true;
            label22.Visible = true;
        }

        private void btn_moveForeward_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                ((CCard)Project.FindServiceByName(cbx_cardList.Text)).cardBase.MoveRel(cbx_axisList.SelectedIndex, distance, vel, false, true);
            }
        }
        private void btn_moveForeward_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                ((CCard)Project.FindServiceByName(cbx_cardList.Text)).cardBase.KeepMove(cbx_axisList.SelectedIndex, 1, vel, false, true);
            }
        }
        private void btn_moveForeward_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                ((CCard)Project.FindServiceByName(cbx_cardList.Text)).cardBase.DecStop(cbx_axisList.SelectedIndex, true);
        }
        private void btn_moveStop_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            ((CCard)Project.FindServiceByName(cbx_cardList.Text)).cardBase.DecStop(cbx_axisList.SelectedIndex);
        }
        private void btn_moveBackward_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                ((CCard)Project.FindServiceByName(cbx_cardList.Text)).cardBase.MoveRel(cbx_axisList.SelectedIndex, -distance, vel, false, true);
            }
        }
        private void btn_moveBackward_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                ((CCard)Project.FindServiceByName(cbx_cardList.Text)).cardBase.KeepMove(cbx_axisList.SelectedIndex, -1, vel, false, true);
            }
        }
        private void btn_moveBackward_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                ((CCard)Project.FindServiceByName(cbx_cardList.Text)).cardBase.DecStop(cbx_axisList.SelectedIndex, true);
        }
        private void btn_home_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            Thread th = new Thread(() =>
            {
                btn_moveBackward.Enabled = false;
                btn_moveForeward.Enabled = false;
                ((CCard)Project.FindServiceByName(cbx_cardList.Text)).cardBase.Home((Axis)Enum.Parse(typeof(Axis), cbx_axisList.Text));
                btn_moveBackward.Enabled = true;
                btn_moveForeward.Enabled = true;
            });
            th.IsBackground = true;
            th.Start();
        }

        private void dgv_pointList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (this.Visible && !initPointList && dgv_pointList.Rows.Count > 1)
            {
                dgv_pointList.Rows[dgv_pointList.Rows.Count - 2].Cells[1].Value = "示教";
                dgv_pointList.Rows[dgv_pointList.Rows.Count - 2].Cells[2].Value = "Go";

                dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[0].Value = dgv_pointList.Rows.Count;
                dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[1].Value = "示教";
                dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[2].Value = "Go";
                dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[3].Value = "备用";
                dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[4].Value = "10";
                if (dgv_pointList.Rows[dgv_pointList.Rows.Count - 2].Cells[3].Value == null)
                    dgv_pointList.Rows[dgv_pointList.Rows.Count - 2].Cells[3].Value = 10;
                for (int i = 5; i < dgv_pointList.Columns.Count; i++)
                {
                    if (dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[i].Value == null)
                        dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[i].Value = 0;
                }
            }
        }

        private void Frm_Motion_Shown(object sender, EventArgs e)
        {
            initPointList = false;
        }

        private void dgv_pointList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (Permission.CurPermissionGrade == PermissionGrade.Developer)
            {
                if (e.RowIndex == dgv_pointList.Rows.Count - 1)
                    return;
            }

            if (e.ColumnIndex == 1)
            {
                if (!Permission.CheckPermission(PermissionGrade.Admin, false))
                {
                    FuncLib.ShowMsg("权限不足，请登录更高一级权限后重试", InfoType.Tip);
                    return;
                }

                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu == MachineRunStatu.Homing || Device.MachineRunStatu == MachineRunStatu.Running)
                    {
                        FuncLib.ShowMessageBox("操作失败！自动运行过程中非开发者权限禁止操作轴", InfoType.Error);
                        return;
                    }
                }

                bool isZero = false;
                for (int i = 5; i < dgv_pointList.Columns.Count; i++)
                {
                    if (dgv_pointList.Rows[e.RowIndex].Cells[i].Value.ToString() == "0" || dgv_pointList.Rows[e.RowIndex].Cells[i].Value.ToString() == "0" || dgv_pointList.Rows[e.RowIndex].Cells[i].Value.ToString() == "0")
                    {
                        isZero = true;
                        break;
                    }
                }
                if (!isZero)
                {
                    if (FuncLib.ShowConfirmDialog("此点位位置信息已存在，确定要覆盖吗？") != DialogResult.OK)
                        return;
                }

                int selectRow = dgv_pointList.SelectedRows[0].Index;
                for (int i = 5; i < dgv_pointList.Columns.Count; i++)
                {
                    //未回零不让示教位置
                    for (int j = 0; j < Project.L_axis.Count; j++)
                    {
                        //////if (Project.L_axis[j].axisName == dgv_pointList.Columns[j].HeaderText && !Project.L_axis[j].homeOK)
                        //////{
                        //////    FuncLib.ShowMsg(string.Format("{0} 坐标示教失败，原因：轴未回零", Project.L_axis[j].axisName), InfoType.Error);
                        //////    return;
                        //////}
                    }

                    double curPos = ((CCard)Project.FindServiceByName("运动控制卡")).cardBase.GetCmdPos((Axis)Enum.Parse(typeof(Axis), dgv_pointList.Columns[i].HeaderText));
                    for (int j = 0; j < Project.L_axis.Count; j++)
                    {
                        if (Project.L_axis[j].axisName == dgv_pointList.Columns[i].HeaderText)
                        {
                            if (curPos > ((CCard)Project.FindServiceByName("运动控制卡")).cardBase.L_PLimit[j])
                            {
                                FuncLib.ShowMessageBox(string.Format("示教失败！【{0}】的当前位置超出正限位，当前位置：{1}  正限位：{2}", dgv_pointList.Columns[i].HeaderText, curPos, ((CCard)Project.FindServiceByName("运动控制卡")).cardBase.L_PLimit[j]));
                                return;
                            }
                        }
                    }

                    FuncLib.ShowMsg(string.Format("参数变更！点位表 [ {0} ] 中的点位 [ {1} ] 中的项 [ {2} ] 点位数据变更，变更前：{3}    变更后：{4}", cbx_tableList.Text, dgv_pointList.Rows[selectRow].Cells[3].Value, dgv_pointList.Columns[5].HeaderText, dgv_pointList.Rows[selectRow].Cells[i].Value, curPos));
                    dgv_pointList.Rows[selectRow].Cells[i].Value = curPos;
                }
                SaveAxisPoint();
            }
            if (e.ColumnIndex == 2)
            {
                if (!Permission.CheckPermission(PermissionGrade.Admin, false))
                {
                    FuncLib.ShowMsg("权限不足，请登录更高一级权限后重试", InfoType.Tip);
                    return;
                }

                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu == MachineRunStatu.Homing || Device.MachineRunStatu == MachineRunStatu.Running)
                    {
                        FuncLib.ShowMessageBox("操作失败！自动运行过程中非开发者权限禁止操作轴", InfoType.Error);
                        return;
                    }
                }

                if (dgv_pointList.SelectedRows[0].Index != -1)
                {
                    Thread th = new Thread(() =>
                    {
                        //////if (cbx_tableList.Text == "XYZU")
                        //////    FuncLib.DoorMoveTo(cbx_tableList.Text, dgv_pointList.SelectedRows[0].Cells[3].Value.ToString());
                        //////else
                        SmartPosTable.GoPos(cbx_tableList.SelectedIndex, e.RowIndex);
                    });
                    th.IsBackground = true;
                    th.Start();
                }
            }
        }

        private void 点位表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            Frm_PosTableEdit.Instance.Show();
            Frm_PosTableEdit.Instance.comboBox2.Items.Clear();
            for (int i = 0; i < Project.L_axis.Count; i++)
            {
                Frm_PosTableEdit.Instance.comboBox2.Items.Add(Project.L_axis[i].axisName);
            }
        }

        private void cbx_tableList_DropDown(object sender, EventArgs e)
        {
            SaveAxisPoint();
        }

        private void cbx_tableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Scheme.curScheme.smartPosTable.LoadData(dgv_pointList, cbx_tableList.Text);

            if (Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[0].Value = dgv_pointList.Rows.Count;
                dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[1].Value = "示教";
                dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[2].Value = "Go";
                dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[3].Value = "备用";
                dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[4].Value = 10;
                for (int i = 5; i < dgv_pointList.Columns.Count; i++)
                {
                    if (dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[i].Value == null)
                        dgv_pointList.Rows[dgv_pointList.Rows.Count - 1].Cells[i].Value = 0;
                }
            }

            for (int i = 0; i < Project.L_axis.Count; i++)
            {
                if (Project.L_axis[i].axisName == dgv_pointList.Columns[5].HeaderText)
                {
                    Frm_Motion.Instance.cbx_axisList.SelectedIndex = i;
                    Frm_Motion.Instance.cbx_axisList.Text = Project.L_axis[i].axisName;
                    break;
                }
            }
        }

        private bool stopCheck = false;
        private void btn_motorOn_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }


            if (((CCard)Project.FindServiceByName(cbx_cardList.Text)).cardBase.GetMotorStatu(cbx_axisList.SelectedIndex))
            {
                ((CCard)Project.FindServiceByName(cbx_cardList.Text)).cardBase.MotorOff(cbx_axisList.SelectedIndex);
                btn_motorOn.RectColor = Color.LightGray;
                btn_motorOn.FillColor = Color.LightGray;
            }
            else
            {
                ((CCard)Project.FindServiceByName(cbx_cardList.Text)).cardBase.MotorOn(cbx_axisList.SelectedIndex);
                btn_motorOn.RectColor = Color.FromArgb(80, 160, 255);
                btn_motorOn.FillColor = Color.FromArgb(80, 160, 255);
            }
        }

        private void dgv_pointList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
                FuncLib.ShowMsg(string.Format("参数变更！点位表 [ {0} ] 中的点位 [ {1} ] 中的项 [ {2} ] 点位数据变更，变更前：{3}    变更后：{4}", cbx_tableList.Text, valueBeforeEdit, dgv_pointList.Columns[e.ColumnIndex].HeaderText, valueBeforeEdit, dgv_pointList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
            else
                FuncLib.ShowMsg(string.Format("参数变更！点位表 [ {0} ] 中的点位 [ {1} ] 中的项 [ {2} ] 点位数据变更，变更前：{3}    变更后：{4}", cbx_tableList.Text, dgv_pointList.Rows[e.RowIndex].Cells[3].Value, dgv_pointList.Columns[e.ColumnIndex].HeaderText, valueBeforeEdit, dgv_pointList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));

            SaveAxisPoint();
        }

        private void dgv_pointList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            valueBeforeEdit = dgv_pointList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!Device.hasHomed)
            {
                FuncLib.ShowMessageBox("设备未复位！，请复制后操作");
                return;
            }

            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            //////FuncLib.DoorMoveTo("XYZU", "安全位");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!Device.hasHomed)
            {
                FuncLib.ShowMessageBox("设备未复位！，请复制后操作");
                return;
            }

            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            //////FuncLib.MoveAbs(Axis.Z, Project.Instance.configuration.safetyHeight, 50, true);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            OnOff onOff = FuncLib.GetSts(Do.贴膜吸真空_C1Out27);
            if (onOff == OnOff.On)
            {
                FuncLib.SetDo(Do.贴膜吸真空_C1Out27, OnOff.Off);
            }
            else
            {
                FuncLib.SetDo(Do.贴膜吸真空_C1Out27, OnOff.On);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            OnOff onOff = FuncLib.GetSts(Do.中转平台吸真空1_C1Out45);
            if (onOff == OnOff.On)
            {
                FuncLib.SetDo(Do.中转平台吸真空1_C1Out45, OnOff.Off);
                FuncLib.SetDo(Do.中转平台吸真空2_C1Out46, OnOff.Off);
                FuncLib.SetDo(Do.中转平台吸真空3_C1Out47, OnOff.Off);
                FuncLib.SetDo(Do.中转平台吸真空4_C1Out50, OnOff.Off);
                FuncLib.SetDo(Do.中转平台吸真空5_C1Out51, OnOff.Off);
                FuncLib.SetDo(Do.中转平台吸真空6_C1Out52, OnOff.Off);
            }
            else
            {
                FuncLib.SetDo(Do.中转平台吸真空1_C1Out45, OnOff.On);
                FuncLib.SetDo(Do.中转平台吸真空2_C1Out46, OnOff.On);
                FuncLib.SetDo(Do.中转平台吸真空3_C1Out47, OnOff.On);
                FuncLib.SetDo(Do.中转平台吸真空4_C1Out50, OnOff.On);
                FuncLib.SetDo(Do.中转平台吸真空5_C1Out51, OnOff.On);
                FuncLib.SetDo(Do.中转平台吸真空6_C1Out52, OnOff.On);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            FuncLib.DecStop(Axis.X1);
            FuncLib.DecStop(Axis.Y1);
            FuncLib.DecStop(Axis.Z1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.Y1, -distance, vel, false, true);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.Y1, distance, vel, false, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.X1, -distance, vel, false, true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.X1, distance, vel, false, true);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                //////FuncLib.MoveRel(Axis.U, -distance, vel, false, true);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                //////FuncLib.MoveRel(Axis.U, distance, vel, false, true);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.Z1, -distance, vel, false, true);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.Z1, distance, vel, false, true);
            }
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.Y1);
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.Y1);
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.X1);
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.X1);
        }

        private void button12_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            //////if (rdo_jog.Checked)
            //////    FuncLib.DecStop(Axis.U);
        }

        private void button11_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            //////if (rdo_jog.Checked)
            //////    FuncLib.DecStop(Axis.U);
        }

        private void button10_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.Z1);
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.Z1);
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Y1, Dir.N_负方向, vel, false, true);
            }
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Y1, Dir.P_正方向, vel, false, true);
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.X1, Dir.N_负方向, vel, false, true);
            }
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.X1, Dir.P_正方向, vel, false, true);
            }
        }

        private void button12_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                //////FuncLib.KeepMove(Axis.U, Dir.N_负方向, vel, false, true);
            }
        }

        private void button11_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                //////FuncLib.KeepMove(Axis.U, Dir.P_正方向, vel, false, true);
            }
        }

        private void button10_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Z1, Dir.N_负方向, vel, false, true);
            }
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Z1, Dir.P_正方向, vel, false, true);
            }
        }

        private void btn_manualInBoard_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveInterpolateRel(Axis.X1, Axis.Y1, -distance * 0.707, -distance * 0.707, 100000, vel);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveInterpolateRel(Axis.X1, Axis.Y1, distance * 0.707, -distance * 0.707, 100000, vel);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveInterpolateRel(Axis.X1, Axis.Y1, -distance * 0.707, distance * 0.707, 100000, vel);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveInterpolateRel(Axis.X1, Axis.Y1, distance * 0.707, distance * 0.707, 100000, vel);
            }
        }

        private void btn_manualInBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                FuncLib.DecStop(Axis.X1);
                FuncLib.DecStop(Axis.Y1);
            }
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                FuncLib.DecStop(Axis.X1);
                FuncLib.DecStop(Axis.Y1);
            }
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                FuncLib.DecStop(Axis.X1);
                FuncLib.DecStop(Axis.Y1);
            }
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                FuncLib.DecStop(Axis.X1);
                FuncLib.DecStop(Axis.Y1);
            }
        }

        private void btn_manualInBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.X1, Dir.N_负方向, vel, false, true);
                FuncLib.KeepMove(Axis.Y1, Dir.N_负方向, vel, false, true);
            }
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Y1, Dir.N_负方向, vel, false, true);
                FuncLib.KeepMove(Axis.X1, Dir.P_正方向, vel, false, true);
            }
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Y1, Dir.P_正方向, vel, false, true);
                FuncLib.KeepMove(Axis.X1, Dir.N_负方向, vel, false, true);
            }
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Y1, Dir.P_正方向, vel, false, true);
                FuncLib.KeepMove(Axis.X1, Dir.P_正方向, vel, false, true);
            }
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            OnOff onOff = FuncLib.GetSts(Do.取膜破真空1_C1Out42);
            if (onOff == OnOff.On)
            {
                FuncLib.SetDo(Do.取膜破真空1_C1Out42, OnOff.Off);
                FuncLib.SetDo(Do.取膜破真空2_C1Out43, OnOff.Off);
                FuncLib.SetDo(Do.取膜破真空3_C1Out44, OnOff.Off);
            }
            else
            {
                FuncLib.SetDo(Do.取膜破真空1_C1Out42, OnOff.On);
                FuncLib.SetDo(Do.取膜破真空2_C1Out43, OnOff.On);
                FuncLib.SetDo(Do.取膜破真空3_C1Out44, OnOff.On);
            }
        }
        private int selectedIndex = 0;
        private void Cbx_axisList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = cbx_axisList.SelectedIndex;
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.X2, -distance, vel, false, true);
            }
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.X2, distance, vel, false, true);
            }
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.Y2, -distance, vel, false, true);
            }
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.Y2, distance, vel, false, true);
            }
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveInterpolateRel(Axis.X2, Axis.Y2, -distance * 0.707, -distance * 0.707, 100000, vel);
            }
        }

        private void Button25_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveInterpolateRel(Axis.X2, Axis.Y2, -distance * 0.707, distance * 0.707, 100000, vel);
            }
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveInterpolateRel(Axis.X2, Axis.Y2, distance * 0.707, -distance * 0.707, 100000, vel);
            }
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveInterpolateRel(Axis.X2, Axis.Y2, distance * 0.707, distance * 0.707, 100000, vel);
            }
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            FuncLib.DecStop(Axis.X2);
            FuncLib.DecStop(Axis.Y2);
            FuncLib.DecStop(Axis.Z2);
        }

        private void Button18_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.X2, Dir.N_负方向, vel, false, true);
                FuncLib.KeepMove(Axis.Y2, Dir.N_负方向, vel, false, true);
            }
        }

        private void Button25_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Y2, Dir.P_正方向, vel, false, true);
                FuncLib.KeepMove(Axis.X2, Dir.N_负方向, vel, false, true);
            }
        }

        private void Button22_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Y2, Dir.N_负方向, vel, false, true);
                FuncLib.KeepMove(Axis.X2, Dir.P_正方向, vel, false, true);
            }
        }

        private void Button29_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Y2, Dir.P_正方向, vel, false, true);
                FuncLib.KeepMove(Axis.X2, Dir.P_正方向, vel, false, true);
            }
        }

        private void Button18_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                FuncLib.DecStop(Axis.X2);
                FuncLib.DecStop(Axis.Y2);
            }
        }

        private void Button25_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                FuncLib.DecStop(Axis.X2);
                FuncLib.DecStop(Axis.Y2);
            }
        }

        private void Button22_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                FuncLib.DecStop(Axis.X2);
                FuncLib.DecStop(Axis.Y2);
            }
        }

        private void Button29_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                FuncLib.DecStop(Axis.X2);
                FuncLib.DecStop(Axis.Y2);
            }
        }

        private void Button30_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.Z2, -distance, vel, false, true);
            }
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.Z2, distance, vel, false, true);
            }
        }

        private void Button30_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Z2, Dir.N_负方向, vel, false, true);
            }
        }

        private void Button28_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Z2, Dir.P_正方向, vel, false, true);
            }
        }

        private void Button30_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.Z2);
        }

        private void Button28_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.Z2);
        }

        private void Button19_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.X2, Dir.N_负方向, vel, false, true);
            }
        }

        private void Button19_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.X2);
        }

        private void Button23_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.X2, Dir.P_正方向, vel, false, true);
            }
        }

        private void Button23_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.X2);
        }

        private void Button20_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Y2, Dir.N_负方向, vel, false, true);
            }
        }

        private void Button20_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.Y2);
        }

        private void Button27_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.Y2, Dir.P_正方向, vel, false, true);
            }
        }

        private void Button27_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.Y2);
        }

        private void Button34_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            FuncLib.DecStop(Axis.贴合X);
            FuncLib.DecStop(Axis.贴合Z);
            FuncLib.DecStop(Axis.贴合R);
        }

        private void Button32_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.贴合X, -distance, vel, false, true);
            }
        }

        private void Button36_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.贴合X, distance, vel, false, true);
            }
        }

        private void Button33_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                //FuncLib.MoveRel(Axis., -distance, vel, false, true);
            }
        }

        private void Button32_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.贴合X, Dir.N_负方向, vel, false, true);
            }
        }

        private void Button32_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.贴合X);
        }

        private void Button36_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.贴合X, Dir.P_正方向, vel, false, true);
            }
        }

        private void Button36_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.贴合X);
        }

        private void Button39_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.贴合R, distance, vel, false, true);
            }
        }

        private void Button39_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.贴合R, Dir.P_正方向, vel, false, true);
            }
        }

        private void Button39_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.贴合R);
        }

        private void Button37_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.贴合R, Dir.N_负方向, vel, false, true);
            }
        }

        private void Button37_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.贴合R);
        }

        private void Button43_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.贴合Z, -distance, vel, false, true);
            }
        }

        private void Button41_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.贴合Z, distance, vel, false, true);
            }
        }

        private void Button43_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.贴合Z, Dir.N_负方向, vel, false, true);
            }
        }

        private void Button43_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.贴合Z);
        }

        private void Button41_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.贴合Z, Dir.P_正方向, vel, false, true);
            }
        }

        private void Button41_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.贴合Z);
        }

        private void Button37_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.贴合R, -distance, vel, false, true);
            }
        }

        private void Button47_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            FuncLib.DecStop(Axis.搬运Z);
            FuncLib.DecStop(Axis.搬运Y);
        }

        private void Button46_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.搬运Y, distance, vel, false, true);
            }
        }

        private void Button53_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.搬运Y, -distance, vel, false, true);
            }
        }

        private void Button52_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                //FuncLib.MoveRel(Axis.搬运Y , -distance, vel, false, true);
            }
        }

        private void Button56_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.搬运Z, -distance, vel, false, true);
            }
        }

        private void Button54_Click(object sender, EventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_move.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                double distance = Convert.ToDouble(cbx_distance.Text.Trim());

                FuncLib.MoveRel(Axis.搬运Z, distance, vel, false, true);
            }
        }

        private void Button46_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.搬运Y, Dir.P_正方向, vel, false, true);
            }
        }

        private void Button46_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.搬运Y);
        }

        private void Button53_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.搬运Y, Dir.N_负方向, vel, false, true);
            }
        }

        private void Button53_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.搬运Y);
        }

        private void Button56_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.搬运Z, Dir.N_负方向, vel, false, true);
            }
        }

        private void Button56_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.搬运Z);
        }

        private void Button54_MouseDown(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        FuncLib.ShowMessageBox("操作失败！运行状态禁止进行此操作", InfoType.Error);
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
            {
                int vel = 50;
                if (rdo_highVel.Checked)
                    vel = 150;
                else if (rdo_middleVel.Checked)
                    vel = 100;
                else if (rdo_lowVel.Checked)
                    vel = 50;
                else
                    vel = 10;

                FuncLib.KeepMove(Axis.搬运Z, Dir.P_正方向, vel, false, true);
            }
        }

        private void Button54_MouseUp(object sender, MouseEventArgs e)
        {
            if (Permission.CheckPermission(PermissionGrade.Admin, false))
            {
                if (!Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Stop && Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.WaitRun)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (rdo_jog.Checked)
                FuncLib.DecStop(Axis.搬运Z);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
