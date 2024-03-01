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
using Tool;

namespace VM_Pro
{
    public partial class Frm_Login : UIForm
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        internal static Frm_Login Instance
        {
            get
            {
                return new Frm_Login();
            }
        }


        private void Frm_Login_Load(object sender, EventArgs e)
        {
            lbl_companyName.Text = Project.Instance.configuration.companyName;
            tbx_password.Select();
        }
        private void cbx_userName_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbx_password.Clear();
            tbx_password.Select();
            tbx_password.Focus();
        }
        internal void btn_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Permission.CurPermissionGrade = PermissionGrade.NoLogin;
            Device.sw_autoLock.Stop();
            Device.sw_autoLock.Reset();
            Permission.FuncEnable(PermissionGrade.NoLogin);

            //项目自定义
            
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string curPassword = Method.GetMD5(tbx_password.Text.Trim());
            if (btn_login.Text == "登录")         //登录
            {
                if (cbx_userName.Text == " 开发人员")       //开发人员登录
                {
                    if (curPassword == Project.Instance.configuration.developerPassword)
                    {
                        Permission.CurPermissionGrade = PermissionGrade.Developer;
                        Device.sw_autoLock.Restart();

                        Permission.FuncEnable(PermissionGrade.Developer);

                        //项目自定义


                        tbx_password.Watermark = "请输入密码";
                        tbx_password.WatermarkColor = Color.Gray;
                        FuncLib.ShowMsg("登录成功，当前用户：开发者", InfoType.Tip);
                        this.Hide();
                    }
                    else
                    {
                        tbx_password.Watermark = "密码错误";
                        tbx_password.WatermarkColor = Color.Red;
                        tbx_password.Text = string.Empty;
                        tbx_password.Focus();
                    }
                }
                else        //管理员登录
                {
                    if (curPassword == Project.Instance.configuration.adminPassword)
                    {
                        Permission.CurPermissionGrade = PermissionGrade.Admin;
                        Device.sw_autoLock.Restart();

                        Permission.FuncEnable(PermissionGrade.Admin);

                        //项目自定义


                        tbx_password.Watermark = "请输入密码";
                        tbx_password.WatermarkColor = Color.Gray;
                        FuncLib.ShowMsg("登录成功，当前用户：管理员", InfoType.Tip);
                        this.Hide();
                    }
                    else if (curPassword == Project.Instance.configuration.developerPassword)
                    {
                        Permission.CurPermissionGrade = PermissionGrade.Developer;
                        Device.sw_autoLock.Restart();

                        Permission.FuncEnable(PermissionGrade.Developer);

                        //项目自定义


                        tbx_password.Watermark = "请输入密码";
                        tbx_password.WatermarkColor = Color.Gray;
                        FuncLib.ShowMsg("登录成功，当前用户：开发者", InfoType.Tip);
                        this.Hide();
                    }
                    else
                    {
                        tbx_password.Watermark = "密码错误";
                        tbx_password.WatermarkColor = Color.Red;
                        tbx_password.Text = string.Empty;
                        tbx_password.Focus();
                    }
                }
            }
            else        //密码修改
            {
                if (cbx_userName.Text == " 开发人员")       //开发人员密码修改
                {
                    if (curPassword == Project.Instance.configuration.developerPassword)
                    {
                        Project.Instance.configuration.developerPassword = Method.GetMD5(tbx_newPassword.Text.Trim());
                        tbx_password.Watermark = "请输入密码";
                        tbx_password.WatermarkColor = Color.Gray;
                        tbx_password.Clear();
                        tbx_newPassword.Clear();
                        FuncLib.ShowMsg("密码修改成功", InfoType.Tip);
                    }
                    else
                    {
                        tbx_password.Watermark = "密码错误";
                        tbx_password.WatermarkColor = Color.Red;
                        tbx_password.Text = string.Empty;
                        tbx_password.Focus();
                    }
                }
                else        //管理员密码修改
                {
                    if (curPassword == Project.Instance.configuration.adminPassword || curPassword == Project.Instance.configuration.developerPassword)
                    {
                        Project.Instance.configuration.adminPassword = Method.GetMD5(tbx_newPassword.Text.Trim());

                        tbx_password.Watermark = "请输入密码";
                        tbx_password.WatermarkColor = Color.Gray;
                        tbx_password.Clear();
                        tbx_newPassword.Clear();
                        FuncLib.ShowMsg("密码修改成功", InfoType.Tip);
                    }
                    else
                    {
                        tbx_password.Watermark = "密码错误";
                        tbx_password.WatermarkColor = Color.Red;
                        tbx_password.Text = string.Empty;
                        tbx_password.Focus();
                    }
                }
            }
        }
        private void lnk_switchLoginOrModify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lnk_switchLoginOrModify.Text == "点击修改密码")
            {
                lnk_switchLoginOrModify.Text = "点击登录";
                lbl_passwordAgain.Visible = true;
                tbx_newPassword.Visible = true;
                btn_logout.Visible = false;
                lbl_password.Text = "原始密码：";
                btn_login.Text = "修改";
                tbx_password.Focus();
            }
            else
            {
                lnk_switchLoginOrModify.Text = "点击修改密码";
                lbl_passwordAgain.Visible = false;
                tbx_newPassword.Visible = false;
                btn_logout.Visible = true;

                lbl_password.Text = "密       码：";
                btn_login.Text = "登录";
                tbx_password.Focus();
            }
        }

    }
}
