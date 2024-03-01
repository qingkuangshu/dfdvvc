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
    public partial class Frm_System : UIForm
    {
        public Frm_System()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_System _instance;
        internal static Frm_System Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_System();
                return _instance;
            }
        }


        private void tvw_menu_Click(object sender, EventArgs e)
        {
            switch (tvw_menu.SelectedNode.Text)
            {
                case "项目属性":
                    pnl_window.Controls.Clear();
                    Frm_Project.Instance.TopLevel = false;
                    Frm_Project.Instance.Parent = pnl_window;
                    Frm_Project.Instance.Show();
                    break;
                case "方案管理":
                    if (Permission.CheckPermission(PermissionGrade.Developer, false))
                    {
                        Frm_Scheme.Instance.btn_createScheme.Enabled = true;
                    }
                    else
                    {
                        Frm_Scheme.Instance.btn_createScheme.Enabled = false;
                    }

                    pnl_window.Controls.Clear();
                    Frm_Scheme.Instance.TopLevel = false;
                    Frm_Scheme.Instance.Parent = pnl_window;
                    Frm_Scheme.Instance.Show();
                    break;
                case "服务列表":
                    pnl_window.Controls.Clear();
                    Frm_Service.Instance.TopLevel = false;
                    Frm_Service.Instance.Parent = pnl_window;
                    Frm_Service.Instance.Show();
                    break;
                case "系统选项":
                    pnl_window.Controls.Clear();
                    Frm_Environment.Instance.TopLevel = false;
                    Frm_Environment.Instance.Parent = pnl_window;
                    Frm_Environment.Instance.Show();
                    break;
                case "其它":
                    pnl_window.Controls.Clear();
                    Frm_Else.Instance.TopLevel = false;
                    Frm_Else.Instance.Parent = pnl_window;
                    Frm_Else.Instance.Show();
                    break;
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            Project.SaveSysPar();
        }
        private void Frm_System_Load(object sender, EventArgs e)
        {
            pnl_window.Controls.Clear();
            Frm_Service.Instance.TopLevel = false;
            Frm_Service.Instance.Parent = pnl_window;
            Frm_Service.Instance.Show();
        }
        private void Frm_System_Shown(object sender, EventArgs e)
        {
            tvw_menu.CollapseAll();
            tvw_menu.SelectedNode = tvw_menu.Nodes[0];
        }
        private void Frm_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止所有相机的时实
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                    CCamera.FindCamera(Project.Instance.L_Service[i].name).loopGrab = false;
            }

            //停止绘制
            if (Frm_Camera.waitDraw)
                HalconLib.HIOCancelDraw();

            //停止监控板卡
            Frm_Card.keepUpdate = false;

            this.Hide();
            e.Cancel = true;
        }

    }
}
