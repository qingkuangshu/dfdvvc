using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace VM_Pro
{
    internal partial class Cylinder1 : UserControl
    {
        internal Cylinder1(CardBase m_cardBase, CCylinder1 m_cCylinder)
        {
            InitializeComponent();

            cardBase = m_cardBase;
            cCylinder = m_cCylinder;

            lbl_name.Text = m_cCylinder.name;
        }

        /// <summary>
        /// 名称
        /// </summary>
        private CCylinder1 cCylinder;
        /// <summary>
        /// 控制卡对象
        /// </summary>
        private CardBase cardBase;


        private void btn_onOff_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            if (!((CCard)(Project.FindServiceByName(cCylinder.cardNameActInNo1))).cardBase.connected)
                return;

            if ((Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.Stop) && !Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                FuncLib.ShowMessageBox("操作失败！自动运行过程中非开发者权限禁止操作气缸", InfoType.Error);
                return;
            }

            if (cCylinder.actOutNo2 != -1)    //双控气缸
            {
                //感应器检测
                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.On && cardBase.GetDoSts(cCylinder.actOutNo2) == OnOff.Off)
                {
                    Thread th = new Thread(() =>
                    {
                        if (cardBase.GetDiSts(cCylinder.actInNo1) != OnOff.On)
                            FuncLib.ShowMessageBox("异常！气缸在原位，但原位输入感应器未感应到，请检查", InfoType.Error);
                    });
                    th.IsBackground = true;
                    th.Start();
                }
                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.Off && cardBase.GetDoSts(cCylinder.actOutNo2) == OnOff.On)
                {
                    Thread th = new Thread(() =>
                    {
                        if (cardBase.GetDiSts(cCylinder.actInNo2) != OnOff.On)
                            FuncLib.ShowMessageBox("异常！气缸在动位，但动位输入感应器未感应到，请检查", InfoType.Error);
                    });
                    th.IsBackground = true;
                    th.Start();
                }

                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.Off && cardBase.GetDoSts(cCylinder.actOutNo2) == OnOff.Off)
                {
                    if (cardBase.GetDiSts(cCylinder.actInNo1) == OnOff.On)
                    {
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.Off);
                        cardBase.SetDo(cCylinder.actOutNo2, OnOff.On);
                    }
                    else
                    {
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.On);
                        cardBase.SetDo(cCylinder.actOutNo2, OnOff.Off);
                    }
                }
                else
                {
                    if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.On)
                    {
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.Off);
                        cardBase.SetDo(cCylinder.actOutNo2, OnOff.On);
                    }
                    else
                    {
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.On);
                        cardBase.SetDo(cCylinder.actOutNo2, OnOff.Off);
                    }
                }
            }
            else        //单控气缸
            {
                //感应器检测
                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.On)
                {
                    if (cardBase.GetDiSts(cCylinder.actInNo2) != OnOff.On)
                        FuncLib.ShowMessageBox("异常！气缸在原位，但原位输入感应器未感应到，请检查", InfoType.Error);
                }
                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.Off)
                {
                    if (cardBase.GetDiSts(cCylinder.actInNo1) != OnOff.On)
                        FuncLib.ShowMessageBox("异常！气缸在动位，但动位输入感应器未感应到，请检查", InfoType.Error);
                }

                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.Off && cardBase.GetDoSts(cCylinder.actOutNo2) == OnOff.Off)
                {
                    if (cardBase.GetDiSts(cCylinder.actInNo1) == OnOff.On)
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.On);
                    else
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.Off);
                }
                else
                {
                    if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.On)
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.Off);
                    else
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.On);
                }
            }
        }
        private void lbl_name_DoubleClick(object sender, EventArgs e)
        {
            Frm_CylinderInfo.LoadPara(cCylinder.name, cCylinder.cardNameActOutNo1, cCylinder.cardNameActOutNo2, cCylinder.cardNameActInNo1, cCylinder.cardNameActInNo2, cCylinder.actOutNo1, cCylinder.actOutNo2, cCylinder.actInNo1, cCylinder.actInNo2);
            Frm_CylinderInfo.Instance.ShowDialog();
        }

        private void Btn_off_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            if (!((CCard)(Project.FindServiceByName(cCylinder.cardNameActInNo1))).cardBase.connected)
                return;

            if ((Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.Stop) && !Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                FuncLib.ShowMessageBox("操作失败！自动运行过程中非开发者权限禁止操作气缸", InfoType.Error);
                return;
            }

            if (cCylinder.actOutNo2 != -1)    //双控气缸
            {
                //感应器检测
                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.On && cardBase.GetDoSts(cCylinder.actOutNo2) == OnOff.Off)
                {
                    Thread th = new Thread(() =>
                    {
                        if (cardBase.GetDiSts(cCylinder.actInNo1) != OnOff.On)
                            FuncLib.ShowMessageBox("异常！气缸在原位，但原位输入感应器未感应到，请检查", InfoType.Error);
                    });
                    th.IsBackground = true;
                    th.Start();
                }
                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.Off && cardBase.GetDoSts(cCylinder.actOutNo2) == OnOff.On)
                {
                    Thread th = new Thread(() =>
                    {
                        if (cardBase.GetDiSts(cCylinder.actInNo2) != OnOff.On)
                            FuncLib.ShowMessageBox("异常！气缸在动位，但动位输入感应器未感应到，请检查", InfoType.Error);
                    });
                    th.IsBackground = true;
                    th.Start();
                }

                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.Off && cardBase.GetDoSts(cCylinder.actOutNo2) == OnOff.Off)
                {
                    if (cardBase.GetDiSts(cCylinder.actInNo1) == OnOff.On)
                    {
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.Off);
                        cardBase.SetDo(cCylinder.actOutNo2, OnOff.On);
                    }
                    else
                    {
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.On);
                        cardBase.SetDo(cCylinder.actOutNo2, OnOff.Off);
                    }
                }
                else
                {
                    if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.On)
                    {
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.Off);
                        cardBase.SetDo(cCylinder.actOutNo2, OnOff.On);
                    }
                    else
                    {
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.On);
                        cardBase.SetDo(cCylinder.actOutNo2, OnOff.Off);
                    }
                }
            }
            else        //单控气缸
            {
                //感应器检测
                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.On)
                {
                    if (cardBase.GetDiSts(cCylinder.actInNo2) != OnOff.On)
                        FuncLib.ShowMessageBox("异常！气缸在原位，但原位输入感应器未感应到，请检查", InfoType.Error);
                }
                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.Off)
                {
                    if (cardBase.GetDiSts(cCylinder.actInNo1) != OnOff.On)
                        FuncLib.ShowMessageBox("异常！气缸在动位，但动位输入感应器未感应到，请检查", InfoType.Error);
                }

                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.Off && cardBase.GetDoSts(cCylinder.actOutNo2) == OnOff.Off)
                {
                    if (cardBase.GetDiSts(cCylinder.actInNo1) == OnOff.On)
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.On);
                    else
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.Off);
                }
                else
                {
                    if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.On)
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.Off);
                    else
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.On);
                }
            }
        }

        private void Btn_on_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin))
                return;

            if (!((CCard)(Project.FindServiceByName(cCylinder.cardNameActInNo1))).cardBase.connected)
                return;

            if ((Device.MachineRunStatu != MachineRunStatu.WaitReset && Device.MachineRunStatu != MachineRunStatu.Stop) && !Permission.CheckPermission(PermissionGrade.Developer, false))
            {
                FuncLib.ShowMessageBox("操作失败！自动运行过程中非开发者权限禁止操作气缸", InfoType.Error);
                return;
            }

            if (cCylinder.actOutNo2 != -1)    //双控气缸
            {
                //感应器检测
                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.On && cardBase.GetDoSts(cCylinder.actOutNo2) == OnOff.Off)
                {
                    Thread th = new Thread(() =>
                    {
                        if (cardBase.GetDiSts(cCylinder.actInNo1) != OnOff.On)
                            FuncLib.ShowMessageBox("异常！气缸在原位，但原位输入感应器未感应到，请检查", InfoType.Error);
                    });
                    th.IsBackground = true;
                    th.Start();
                }
                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.Off && cardBase.GetDoSts(cCylinder.actOutNo2) == OnOff.On)
                {
                    Thread th = new Thread(() =>
                    {
                        if (cardBase.GetDiSts(cCylinder.actInNo2) != OnOff.On)
                            FuncLib.ShowMessageBox("异常！气缸在动位，但动位输入感应器未感应到，请检查", InfoType.Error);
                    });
                    th.IsBackground = true;
                    th.Start();
                }

                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.Off && cardBase.GetDoSts(cCylinder.actOutNo2) == OnOff.Off)
                {
                    if (cardBase.GetDiSts(cCylinder.actInNo1) == OnOff.On)
                    {
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.Off);
                        cardBase.SetDo(cCylinder.actOutNo2, OnOff.On);
                    }
                    else
                    {
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.On);
                        cardBase.SetDo(cCylinder.actOutNo2, OnOff.Off);
                    }
                }
                else
                {
                    if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.On)
                    {
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.Off);
                        cardBase.SetDo(cCylinder.actOutNo2, OnOff.On);
                    }
                    else
                    {
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.On);
                        cardBase.SetDo(cCylinder.actOutNo2, OnOff.Off);
                    }
                }
            }
            else        //单控气缸
            {
                //感应器检测
                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.On)
                {
                    if (cardBase.GetDiSts(cCylinder.actInNo2) != OnOff.On)
                        FuncLib.ShowMessageBox("异常！气缸在原位，但原位输入感应器未感应到，请检查", InfoType.Error);
                }
                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.Off)
                {
                    if (cardBase.GetDiSts(cCylinder.actInNo1) != OnOff.On)
                        FuncLib.ShowMessageBox("异常！气缸在动位，但动位输入感应器未感应到，请检查", InfoType.Error);
                }

                if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.Off && cardBase.GetDoSts(cCylinder.actOutNo2) == OnOff.Off)
                {
                    if (cardBase.GetDiSts(cCylinder.actInNo1) == OnOff.On)
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.On);
                    else
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.Off);
                }
                else
                {
                    if (cardBase.GetDoSts(cCylinder.actOutNo1) == OnOff.On)
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.Off);
                    else
                        cardBase.SetDo(cCylinder.actOutNo1, OnOff.On);
                }
            }
        }
    }
}
