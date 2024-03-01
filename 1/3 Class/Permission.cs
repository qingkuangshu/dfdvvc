using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace VM_Pro
{
    /// <summary>
    /// 权限类
    /// </summary>
    internal class Permission
    {

        /// <summary>
        /// 当前权限等级
        /// </summary>
        private static PermissionGrade curPermissionGrade = PermissionGrade.NoLogin;
        internal static PermissionGrade CurPermissionGrade
        {
            get { return Permission.curPermissionGrade; }
            set
            {
                Permission.curPermissionGrade = value;

                switch (value)
                {
                    case PermissionGrade.NoLogin:
                        FuncLib.ShowMsg("权限已注销", InfoType.Tip);
                        Frm_Main.Instance.lbl_curPermission.Text = "未登陆";
                        Frm_Main.Instance.pic_loginStatu.ForeColor = Color.FromArgb(240, 240, 240);
                        break;
                    case PermissionGrade.Admin:
                        Frm_Main.Instance.lbl_curPermission.Text = "管理员";
                        Frm_Main.Instance.pic_loginStatu.ForeColor = Project.Instance.configuration.themeColor;
                        break;
                    case PermissionGrade.Developer:
                        Frm_Main.Instance.lbl_curPermission.Text = "开发者";
                        Frm_Main.Instance.pic_loginStatu.ForeColor = Project.Instance.configuration.themeColor;
                        break;
                }
            }
        }


        /// <summary>
        /// 检查权限等级
        /// </summary>
        /// <param name="permission">权限等级</param>
        /// <returns></returns>
        internal static bool CheckPermission(PermissionGrade permissionGrade, bool autoShow = true)
        {
            if (!Project.Instance.configuration.enablePermission)
                return true;

            if ((int)curPermissionGrade < (int)permissionGrade)
            {
                if (autoShow)
                {
                    FuncLib.ShowMsg("权限不足，请登录更高一级权限后重试", InfoType.Tip);
                    new Frm_Login().ShowDialog();
                }

                if ((int)curPermissionGrade < (int)permissionGrade)
                    return false;
                else
                    return true;
            }
            return true;
        }
        /// <summary>
        /// 功能启用
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        internal static void FuncEnable(PermissionGrade permissionGrade)
        {
            switch (permissionGrade)
            {
                case PermissionGrade.NoLogin:

                    Frm_Main.Instance.btn_sevice1.Enabled = false;
                    Frm_Main.Instance.btn_sevice2.Enabled = false;
                    Frm_Main.Instance.btn_sevice3.Enabled = false;
                    Frm_Main.Instance.btn_sevice4.Enabled = false;
                    Frm_Main.Instance.btn_sevice5.Enabled = false;
                    Frm_Main.Instance.btn_sevice6.Enabled = false;
                    Frm_Main.Instance.btn_sevice7.Enabled = false;
                    Frm_Main.Instance.btn_sevice8.Enabled = false;

                    Frm_Vision.Instance.splitContainer1.IsSplitterFixed = true;
                    Frm_Vision.Instance.splitContainer2.IsSplitterFixed = true;

                    Frm_Task.Instance.splitContainer1.IsSplitterFixed = true;
                    Frm_Task.Instance.splitContainer2.IsSplitterFixed = true;

                    Frm_Task.Instance.C_toolBox.AllowDrop = false;
                    Frm_Task.Instance.C_taskList.AllowDrop = false;
                    Frm_Task.Instance.C_toolList.AllowDrop = false;

                    Frm_Vision.Instance.任务toolStripButton2.Visible = false;
                    Frm_Vision.Instance.toolStripSeparator1.Visible = false;
                    Frm_Vision.Instance.任务列表toolStripButton3.Visible = false;
                    Frm_Vision.Instance.任务编辑toolStripButton4.Visible = false;
                    Frm_Vision.Instance.工具箱toolStripButton5.Visible = false;
                    Frm_Vision.Instance.日志toolStripButton8.Visible = false;
                    Frm_Vision.Instance.工具输出toolStripButton7.Visible = false;
                    Frm_Vision.Instance.toolStripSeparator3.Visible = false;
                    Frm_Vision.Instance.所有流程运行一次toolStripButton.Visible = false;
                    Frm_Vision.Instance.当前流程连续运行toolStripButton.Visible = false;
                    Frm_Vision.Instance.所有流程连续运行toolStripButton.Visible = false;
                    Frm_Vision.Instance.画布toolStripButton6.Visible = false;
                    Frm_Vision.Instance.演示模式toolStripButton1.Visible = false;
                    Frm_Vision.Instance.软键盘toolStripButton2.Visible = false;
                    Frm_Vision.Instance.toolStripSeparator2.Visible = false;
                    Frm_Vision.Instance.上一张toolStripButton.Visible = false;
                    Frm_Vision.Instance.停止切换toolStripButton.Visible = false;
                    Frm_Vision.Instance.下一张toolStripButton.Visible = false;
                    Frm_Vision.Instance.全局变量toolStripButton.Visible = false;
                    Frm_Vision.Instance.急速模式toolStripButton.Visible = false;

                    Frm_Vision.Instance.hWindow_Final1.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final2.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final3.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final4.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final5.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final6.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final7.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final8.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final9.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final10.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final11.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final12.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final13.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final14.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final15.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final16.ContextMenuStrip = null;

                    Frm_Task.Instance.C_toolBox.ContextMenuStrip = null;
                    Frm_Task.Instance.C_taskList.ContextMenuStrip = null;
                    Frm_Task.Instance.C_toolList.ContextMenuStrip = null;

                    Frm_Service.Instance.tvw_serviceList.ContextMenuStrip = null;

                    Frm_Msg.Instance.tbx_msg.ContextMenuStrip = null;
                    Frm_Motion.Instance.dgv_pointList.Columns[0].ReadOnly = true;
                    Frm_Motion.Instance.dgv_pointList.Columns[3].ReadOnly = true;
                    Frm_Motion.Instance.dgv_pointList.Columns[4].ReadOnly = true;
                    for (int i = 5; i < Frm_Motion.Instance.dgv_pointList.Columns.Count; i++)
                    {
                        Frm_Motion.Instance.dgv_pointList.Columns[i].ReadOnly = true;
                    }

                    Frm_IO.Instance.dgv_diList.ContextMenuStrip = null;
                    Frm_IO.Instance.dgv_doList.ContextMenuStrip = null;

                    Frm_Motion.Instance.dgv_pointList.AllowUserToAddRows = false;
                    Frm_Motion.Instance.dgv_pointList.ContextMenuStrip = null;
                    break;

                case PermissionGrade.Admin:

                    Frm_Main.Instance.btn_sevice1.Enabled = false;
                    Frm_Main.Instance.btn_sevice2.Enabled = false;
                    Frm_Main.Instance.btn_sevice3.Enabled = false;
                    Frm_Main.Instance.btn_sevice4.Enabled = false;
                    Frm_Main.Instance.btn_sevice5.Enabled = false;
                    Frm_Main.Instance.btn_sevice6.Enabled = false;
                    Frm_Main.Instance.btn_sevice7.Enabled = false;
                    Frm_Main.Instance.btn_sevice8.Enabled = false;

                    Frm_Vision.Instance.splitContainer1.IsSplitterFixed = true;
                    Frm_Vision.Instance.splitContainer2.IsSplitterFixed = true;
                    Frm_Vision.Instance.任务toolStripButton2.Visible = true;
                    Frm_Task.Instance.splitContainer1.IsSplitterFixed = true;
                    Frm_Task.Instance.splitContainer2.IsSplitterFixed = true;

                    Frm_Task.Instance.C_toolBox.AllowDrop = false;
                    Frm_Task.Instance.C_taskList.AllowDrop = false;
                    Frm_Task.Instance.C_toolList.AllowDrop = false;

                    Frm_Vision.Instance.toolStripSeparator1.Visible = false;
                    Frm_Vision.Instance.任务列表toolStripButton3.Visible = false;
                    Frm_Vision.Instance.任务编辑toolStripButton4.Visible = false;
                    Frm_Vision.Instance.工具箱toolStripButton5.Visible = false;
                    Frm_Vision.Instance.日志toolStripButton8.Visible = false;
                    Frm_Vision.Instance.工具输出toolStripButton7.Visible = false;
                    Frm_Vision.Instance.toolStripSeparator3.Visible = false;
                    Frm_Vision.Instance.所有流程运行一次toolStripButton.Visible = false;
                    Frm_Vision.Instance.当前流程连续运行toolStripButton.Visible = false;
                    Frm_Vision.Instance.所有流程连续运行toolStripButton.Visible = false;
                    Frm_Vision.Instance.画布toolStripButton6.Visible = false;
                    Frm_Vision.Instance.演示模式toolStripButton1.Visible = false;
                    Frm_Vision.Instance.软键盘toolStripButton2.Visible = false;
                    Frm_Vision.Instance.toolStripSeparator2.Visible = false;
                    Frm_Vision.Instance.上一张toolStripButton.Visible = false;
                    Frm_Vision.Instance.停止切换toolStripButton.Visible = false;
                    Frm_Vision.Instance.下一张toolStripButton.Visible = false;
                    Frm_Vision.Instance.全局变量toolStripButton.Visible = false;
                    Frm_Vision.Instance.急速模式toolStripButton.Visible = false;

                    Frm_Vision.Instance.hWindow_Final1.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final2.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final3.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final4.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final5.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final6.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final7.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final8.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final9.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final10.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final11.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final12.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final13.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final14.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final15.ContextMenuStrip = null;
                    Frm_Vision.Instance.hWindow_Final16.ContextMenuStrip = null;

                    Frm_Task.Instance.C_toolBox.ContextMenuStrip = null;
                    Frm_Task.Instance.C_taskList.ContextMenuStrip = null;
                    Frm_Task.Instance.C_toolList.ContextMenuStrip = null;

                    Frm_Service.Instance.tvw_serviceList.ContextMenuStrip = null;

                    Frm_Msg.Instance.tbx_msg.ContextMenuStrip = Frm_Msg.Instance.uiContextMenuStrip2;
                    Frm_Motion.Instance.dgv_pointList.Columns[0].ReadOnly = true;
                    Frm_Motion.Instance.dgv_pointList.Columns[3].ReadOnly = true;
                    Frm_Motion.Instance.dgv_pointList.Columns[4].ReadOnly = false;
                    for (int i = 5; i < Frm_Motion.Instance.dgv_pointList.Columns.Count; i++)
                    {
                        Frm_Motion.Instance.dgv_pointList.Columns[i].ReadOnly = false;
                    }

                    Frm_IO.Instance.dgv_diList.ContextMenuStrip = null;
                    Frm_IO.Instance.dgv_doList.ContextMenuStrip = null;

                    Frm_Motion.Instance.dgv_pointList.AllowUserToAddRows = false;
                    Frm_Motion.Instance.dgv_pointList.ContextMenuStrip = Frm_Motion.Instance.uiContextMenuStrip1;
                    break;

                case PermissionGrade.Developer:

                    Frm_Main.Instance.btn_sevice1.Enabled = true;
                    Frm_Main.Instance.btn_sevice2.Enabled = true;
                    Frm_Main.Instance.btn_sevice3.Enabled = true;
                    Frm_Main.Instance.btn_sevice4.Enabled = true;
                    Frm_Main.Instance.btn_sevice5.Enabled = true;
                    Frm_Main.Instance.btn_sevice6.Enabled = true;
                    Frm_Main.Instance.btn_sevice7.Enabled = true;
                    Frm_Main.Instance.btn_sevice8.Enabled = true;

                    Frm_Vision.Instance.splitContainer1.IsSplitterFixed = false;
                    Frm_Vision.Instance.splitContainer2.IsSplitterFixed = false;

                    Frm_Task.Instance.splitContainer1.IsSplitterFixed = false;
                    Frm_Task.Instance.splitContainer2.IsSplitterFixed = false;
                    Frm_Vision.Instance.任务toolStripButton2.Visible = true;
                    Frm_Task.Instance.C_toolBox.AllowDrop = true;
                    Frm_Task.Instance.C_taskList.AllowDrop = true;
                    Frm_Task.Instance.C_toolList.AllowDrop = true;

                    Frm_Vision.Instance.toolStripSeparator1.Visible = true;
                    Frm_Vision.Instance.任务列表toolStripButton3.Visible = true;
                    Frm_Vision.Instance.任务编辑toolStripButton4.Visible = true;
                    Frm_Vision.Instance.工具箱toolStripButton5.Visible = true;
                    Frm_Vision.Instance.日志toolStripButton8.Visible = true;
                    Frm_Vision.Instance.工具输出toolStripButton7.Visible = true;
                    Frm_Vision.Instance.toolStripSeparator3.Visible = true;
                    Frm_Vision.Instance.所有流程运行一次toolStripButton.Visible = true;
                    Frm_Vision.Instance.当前流程连续运行toolStripButton.Visible = true;
                    Frm_Vision.Instance.所有流程连续运行toolStripButton.Visible = true;
                    Frm_Vision.Instance.画布toolStripButton6.Visible = true;
                    Frm_Vision.Instance.演示模式toolStripButton1.Visible = true;
                    Frm_Vision.Instance.软键盘toolStripButton2.Visible = true;
                    Frm_Vision.Instance.toolStripSeparator2.Visible = true;
                    Frm_Vision.Instance.上一张toolStripButton.Visible = true;
                    Frm_Vision.Instance.停止切换toolStripButton.Visible = true;
                    Frm_Vision.Instance.下一张toolStripButton.Visible = true;
                    Frm_Vision.Instance.全局变量toolStripButton.Visible = true;
                    Frm_Vision.Instance.急速模式toolStripButton.Visible = true;
                    Frm_Vision.Instance.急速模式toolStripButton.Checked = Project.Instance.configuration.IsJiSuMoShi;

                    Frm_Vision.Instance.hWindow_Final1.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final2.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final3.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final4.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final5.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final6.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final7.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final8.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final9.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final10.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final11.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final12.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final13.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final14.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final15.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;
                    Frm_Vision.Instance.hWindow_Final16.ContextMenuStrip = Frm_Vision.Instance.uiContextMenuStrip1;

                    Frm_Task.Instance.C_toolBox.ContextMenuStrip = Frm_Task.Instance.uiContextMenuStrip1;
                    Frm_Task.Instance.C_taskList.ContextMenuStrip = Frm_Task.Instance.uiContextMenuStrip2;
                    Frm_Task.Instance.C_toolList.ContextMenuStrip = Frm_Task.Instance.uiContextMenuStrip3;

                    Frm_Service.Instance.tvw_serviceList.ContextMenuStrip = Frm_Service.Instance.uiContextMenuStrip2;

                    Frm_Msg.Instance.tbx_msg.ContextMenuStrip = Frm_Msg.Instance.uiContextMenuStrip2;
                    Frm_Motion.Instance.dgv_pointList.Columns[0].ReadOnly = true;
                    Frm_Motion.Instance.dgv_pointList.Columns[3].ReadOnly = false;
                    Frm_Motion.Instance.dgv_pointList.Columns[4].ReadOnly = false;
                    for (int i = 5; i < Frm_Motion.Instance.dgv_pointList.Columns.Count; i++)
                    {
                        Frm_Motion.Instance.dgv_pointList.Columns[i].ReadOnly = false;
                    }

                    Frm_IO.Instance.dgv_diList.ContextMenuStrip = Frm_IO.Instance.uiContextMenuStrip1;
                    Frm_IO.Instance.dgv_doList.ContextMenuStrip = Frm_IO.Instance.uiContextMenuStrip2;

                    Frm_Motion.Instance.dgv_pointList.AllowUserToAddRows = true;
                    Frm_Motion.Instance.dgv_pointList.ContextMenuStrip = Frm_Motion.Instance.uiContextMenuStrip1;
                    break;
            }
        }

    }

    /// <summary>
    /// 权限等级    NoLogin：如有权限管控，则没有任何操作权限    Operator：只有少部分满足生产需要的权限     Admin：可以修改部分参数      Developer：最高权限，可以进行任何危险操作
    /// </summary>
    internal enum PermissionGrade
    {
        NoLogin,
        Admin,
        Developer,
    }

}
