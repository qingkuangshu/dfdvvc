using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    internal partial class CVacuum : UserControl
    {
        internal CVacuum(CardBase m_cardBase, Vacuum m_vacuum)
        {
            InitializeComponent();

            cardBase = m_cardBase;
            vacuum = m_vacuum;

            lbl_name.Text = m_vacuum.name;
        }

        /// <summary>
        /// 真空对象
        /// </summary>
        private Vacuum vacuum;
        /// <summary>
        /// 控制卡对象
        /// </summary>
        private CardBase cardBase;


        private void btn_onOff_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            if (!((CCard)(Project.FindServiceByName(vacuum.cardNameOut))).cardBase.connected)
                return;

            if ((Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.Stop) && !Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                FuncLib.ShowMessageBox("操作失败！自动运行过程中非开发者权限禁止操作吸真空", InfoType.Error);
                return;
            }

            if (cardBase.GetDoSts(vacuum.actOutNo) == OnOff.On)
                cardBase.SetDo(vacuum.actOutNo, OnOff.Off);
            else
                cardBase.SetDo(vacuum.actOutNo, OnOff.On);
        }
        private void lbl_name_DoubleClick(object sender, EventArgs e)
        {
            Frm_CylinderInfo.LoadPara(vacuum.name, vacuum.cardNameOut, "无", vacuum.cardNameIn, "无", vacuum.actOutNo, -1, vacuum.actInNo, -1);
            Frm_CylinderInfo.Instance.ShowDialog();
        }





        private void Btn_off_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            if (!((CCard)(Project.FindServiceByName(vacuum.cardNameOut))).cardBase.connected)
                return;

            if ((Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.Stop) && !Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                FuncLib.ShowMessageBox("操作失败！自动运行过程中非开发者权限禁止操作吸真空", InfoType.Error);
                return;
            }

            cardBase.SetDo(vacuum.actOutNo, OnOff.Off);
            cardBase.SetDo(vacuum.actOutBlowNo, OnOff.Off);
        }

        private void Btn_on_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            if (!((CCard)(Project.FindServiceByName(vacuum.cardNameOut))).cardBase.connected)
                return;

            if ((Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.Stop) && !Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                FuncLib.ShowMessageBox("操作失败！自动运行过程中非开发者权限禁止操作吸真空", InfoType.Error);
                return;
            }

            cardBase.SetDo(vacuum.actOutBlowNo, OnOff.Off);
            if (cardBase.GetDoSts(vacuum.actOutNo) == OnOff.Off)
                cardBase.SetDo(vacuum.actOutNo, OnOff.On);
            else
                cardBase.SetDo(vacuum.actOutNo, OnOff.Off);
        }

        private void Btn_blow_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            if (!((CCard)(Project.FindServiceByName(vacuum.cardNameOut))).cardBase.connected)
                return;

            if ((Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.Stop) && !Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                FuncLib.ShowMessageBox("操作失败！自动运行过程中非开发者权限禁止操作吸真空", InfoType.Error);
                return;
            }

            cardBase.SetDo(vacuum.actOutNo, OnOff.Off);
            if (cardBase.GetDoSts(vacuum.actOutBlowNo) == OnOff.Off)
                cardBase.SetDo(vacuum.actOutBlowNo, OnOff.On);
            else
                cardBase.SetDo(vacuum.actOutBlowNo, OnOff.Off);
        }
    }
}
