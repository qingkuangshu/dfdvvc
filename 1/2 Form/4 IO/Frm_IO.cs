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

namespace VM_Pro
{
    public partial class Frm_IO : UIPage
    {
        public Frm_IO()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_IO _instance;
        internal static Frm_IO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_IO();
                return _instance;
            }
        }

        private void dgv_diList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 2)
            {
                if (!Permission.CheckPermission(PermissionGrade.Admin, false))
                {
                    FuncLib.ShowMessageBox("权限不足，请登录更高一级权限后重试", InfoType.Warn);
                    return;
                }

                if ((Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.Stop) && !Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    FuncLib.ShowMessageBox("操作失败！自动运行过程中非开发者权限禁止操作IO", InfoType.Error);
                    return;
                }

                if (Project.D_diVitual[(Di)Enum.Parse(typeof(Di), dgv_diList.Rows[e.RowIndex].Cells[4].Value.ToString())] == 0)
                {
                    dgv_diList.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Yellow;
                    ((DataGridViewButtonCell)dgv_diList.Rows[e.RowIndex].Cells[2]).Value = "虚拟中";
                    if (((CCard)Project.FindServiceByName(dgv_diList.Rows[e.RowIndex].Tag.ToString())).cardBase.GetDiSts((Di)Enum.Parse(typeof(Di), dgv_diList.Rows[e.RowIndex].Cells[4].Value.ToString())) == OnOff.On)
                        Project.D_diVitual[(Di)Enum.Parse(typeof(Di), dgv_diList.Rows[e.RowIndex].Cells[4].Value.ToString())] = 1;
                    else
                        Project.D_diVitual[(Di)Enum.Parse(typeof(Di), dgv_diList.Rows[e.RowIndex].Cells[4].Value.ToString())] = 2;
                }
                else
                {
                    dgv_diList.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.White;
                    ((DataGridViewButtonCell)dgv_diList.Rows[e.RowIndex].Cells[2]).Value = "虚拟";
                    Project.D_diVitual[(Di)Enum.Parse(typeof(Di), dgv_diList.Rows[e.RowIndex].Cells[4].Value.ToString())] = 0;
                }
            }
        }
        private void dgv_doList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 2)
            {
                if (!Permission.CheckPermission(PermissionGrade.Admin, false))
                {
                    FuncLib.ShowMessageBox("权限不足，请登录更高一级权限后重试", InfoType.Warn);
                    return;
                }

                if ((Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.Stop) && !Permission.CheckPermission(PermissionGrade.Developer, false))
                {
                    FuncLib.ShowMessageBox("操作失败！自动运行过程中非开发者权限禁止操作IO", InfoType.Error);
                    return;
                }

                if (((CCard)Project.FindServiceByName(dgv_doList.Rows[e.RowIndex].Tag.ToString())).cardBase.GetDoSts((Do)Enum.Parse(typeof(Do), dgv_doList.Rows[e.RowIndex].Cells[4].Value.ToString())) == OnOff.Off)
                    ((CCard)Project.FindServiceByName(dgv_doList.Rows[e.RowIndex].Tag.ToString())).cardBase.SetDo((Do)Enum.Parse(typeof(Do), dgv_doList.Rows[e.RowIndex].Cells[4].Value.ToString()), OnOff.On);
                else
                    ((CCard)Project.FindServiceByName(dgv_doList.Rows[e.RowIndex].Tag.ToString())).cardBase.SetDo((Do)Enum.Parse(typeof(Do), dgv_doList.Rows[e.RowIndex].Cells[4].Value.ToString()), OnOff.Off);
            }
        }

        private void 切换高低有效电平toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Card)
                {
                    ((CCard)Project.Instance.L_Service[i]).cardBase.L_diLogicLevel[Convert.ToInt16(dgv_diList.Rows[dgv_diList.SelectedRows[0].Index].Cells[0].Value) - 1] = !((CCard)Project.Instance.L_Service[i]).cardBase.L_diLogicLevel[Convert.ToInt16(dgv_diList.Rows[dgv_diList.SelectedRows[0].Index].Cells[0].Value) - 1];
                    return;
                }
            }
        }
        private void 切换高低有效电平toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Card)
                {
                    ((CCard)Project.Instance.L_Service[i]).cardBase.L_doLogicLevel[Convert.ToInt16(dgv_doList.Rows[dgv_doList.SelectedRows[0].Index].Cells[0].Value) - 1] = !((CCard)Project.Instance.L_Service[i]).cardBase.L_doLogicLevel[Convert.ToInt16(dgv_doList.Rows[dgv_doList.SelectedRows[0].Index].Cells[0].Value) - 1];

                    if (((CCard)Project.FindServiceByName(dgv_doList.Rows[dgv_doList.SelectedRows[0].Index].Tag.ToString())).cardBase.GetDoSts((Do)Enum.Parse(typeof(Do), dgv_doList.Rows[dgv_doList.SelectedRows[0].Index].Cells[4].Value.ToString())) == OnOff.Off)
                        ((CCard)Project.FindServiceByName(dgv_doList.Rows[dgv_doList.SelectedRows[0].Index].Tag.ToString())).cardBase.SetDo((Do)Enum.Parse(typeof(Do), dgv_doList.Rows[dgv_doList.SelectedRows[0].Index].Cells[4].Value.ToString()), OnOff.On);
                    else
                        ((CCard)Project.FindServiceByName(dgv_doList.Rows[dgv_doList.SelectedRows[0].Index].Tag.ToString())).cardBase.SetDo((Do)Enum.Parse(typeof(Do), dgv_doList.Rows[dgv_doList.SelectedRows[0].Index].Cells[4].Value.ToString()), OnOff.Off);
                    return;
                }
            }
        }

    }
}
