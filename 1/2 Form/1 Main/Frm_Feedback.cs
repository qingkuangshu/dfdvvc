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
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Net;

namespace VM_Pro
{
    public partial class Frm_Feedback : UIForm
    {
        public Frm_Feedback()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 判断网络连接状态的方法,返回值true为已连接，false为未连接 
        /// </summary>
        /// <param name="conState"></param>
        /// <param name="reder"></param>
        /// <returns></returns>
        [DllImport("wininet")]
        public extern static bool InternetGetConnectedState(out int conState, int reder);
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Feedback _instance;
        internal static Frm_Feedback Instance
        {
            get
            {
                return new Frm_Feedback();
            }
        }


        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="EPSModel"></param>
        /// <returns></returns>
        public bool MailSend(EmailParameter EPSModel)
        {
            try
            {
                //确定smtp服务器端的地址，实列化一个客户端smtp 
                System.Net.Mail.SmtpClient sendSmtpClient = new System.Net.Mail.SmtpClient(EPSModel.SendSetSmtp);
                //创建一个发件的人的地址，发件人的邮件地址和收件人的标题、编码
                System.Net.Mail.MailAddress sendMailAddress = new MailAddress(EPSModel.SendEmail, EPSModel.ConsigneeHand, Encoding.UTF8);
                //创建一个收件的人的地址，收件人的邮件地址和收件人的名称 和编码
                System.Net.Mail.MailAddress consigneeMailAddress = new MailAddress(EPSModel.ConsigneeAddress, EPSModel.ConsigneeName, Encoding.UTF8);
                //创建一个Email对象，发件地址和收件地址
                System.Net.Mail.MailMessage mailMessage = new MailMessage(sendMailAddress, consigneeMailAddress);
                //邮件的主题
                mailMessage.Subject = EPSModel.ConsigneeTheme;
                //编码
                mailMessage.BodyEncoding = Encoding.UTF8;
                //编码
                mailMessage.SubjectEncoding = Encoding.UTF8;
                //发件内容
                mailMessage.Body = EPSModel.SendContent;
                //获取或者设置指定邮件正文是否为html
                mailMessage.IsBodyHtml = false;
                //设置邮件信息 (指定如何处理待发的电子邮件)，指定如何发邮件 是以网络来发
                sendSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //服务器支持安全接连，安全则为true
                sendSmtpClient.EnableSsl = false;
                //是否随着请求一起发
                sendSmtpClient.UseDefaultCredentials = false;
                //用户登录信息
                NetworkCredential myCredential = new NetworkCredential(EPSModel.SendEmail, EPSModel.SendPwd);
                //登录
                sendSmtpClient.Credentials = myCredential;
                //发邮件
                sendSmtpClient.Send(mailMessage);

                btn_submit.Text = "提交";
                btn_submit.Enabled = true;
                return true;//发送成功
            }
            catch
            {
                return false;//发送失败
            }
        }


        private void btn_submit_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if ((InternetGetConnectedState(out temp, 0) != true))
            {
                FuncLib.ShowMessageBox("提交失败！原因：本机网络不可用", InfoType.Error);
                tbx_feedBackMessage.Focus();
                return;
            }

            if (tbx_feedBackMessage.Text.Trim() == string.Empty)
            {
                FuncLib.ShowMessageBox("反馈信息不能为空", InfoType.Error);
                tbx_feedBackMessage.Focus();
                return;
            }

            btn_submit.Enabled = false;
            btn_submit.Text = "提交中......";
            Application.DoEvents();
            EmailParameter model = new EmailParameter();
            model.SendEmail = "m13532686244@163.com";
            //密码
            model.SendPwd = "1008611likang1";
            //发送的SMTP服务地址 ，每个邮箱的是不一样的。。根据发件人的邮箱来定
            model.SendSetSmtp = "smtp.163.com";
            model.ConsigneeAddress = "1070645289@qq.com";
            model.ConsigneeTheme = "您收到一条来自用户对VM Pro的反馈信息";
            model.ConsigneeHand = "VM_Pro信息反馈";
            model.ConsigneeName = "作者";
            model.SendContent = (tbx_emailAddress.Text.Trim() == "" ? tbx_feedBackMessage.Text : tbx_feedBackMessage.Text.Trim() + Environment.NewLine + "用户邮箱：" + tbx_emailAddress.Text.Trim());

            if (MailSend(model) == true)
                FuncLib.ShowMessageBox("提交成功！");
            else
                FuncLib.ShowMessageBox("提交失败！可能原因：未知", InfoType.Error);
            btn_submit.Enabled = true;
            btn_submit.Text = "提交";
            tbx_feedBackMessage.Focus();
        }

    }

    /// <summary>
    /// 邮件参数
    /// </summary>
    public class EmailParameter
    {
        /// <summary>
        /// 收件人的邮件地址 
        /// </summary>
        public string ConsigneeAddress { get; set; }
        /// <summary>
        /// 收件人的名称
        /// </summary>
        public string ConsigneeName { get; set; }
        /// <summary>
        /// 收件人标题
        /// </summary>
        public string ConsigneeHand { get; set; }
        /// <summary>
        /// 收件人的主题
        /// </summary>
        public string ConsigneeTheme { get; set; }
        /// <summary>
        /// 发件邮件服务器的Smtp设置
        /// </summary>
        public string SendSetSmtp { get; set; }
        /// <summary>
        /// 发件人的邮件
        /// </summary>
        public string SendEmail { get; set; }
        /// <summary>
        /// 发件人的邮件密码
        /// </summary>
        public string SendPwd { get; set; }
        /// <summary>
        /// 发件内容
        /// </summary>
        public string SendContent { get; set; }
    }

}
