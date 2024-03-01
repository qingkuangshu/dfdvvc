using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_Msg : Form
    {
        public Frm_Msg()
        {
            InitializeComponent();
            DoubleBuffered = true;      //注册双缓冲技术，减少刷新压力
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Msg _instance;
        internal static Frm_Msg Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Msg();
                return _instance;
            }
            
        }


        private void tsb_tip_Click(object sender, EventArgs e)
        {
            if (tsb_tip.Checked)
            {
                tsb_warn.Checked = false;
                tsb_error.Checked = false;
                tsb_historyAlarm.Checked = false;

                tbx_msg.Clear();
                tbx_msg.ForeColor = Color.FromArgb(48, 48, 48);
                for (int i = 0; i < Project.L_msgItem.Count; i++)
                {
                    if (Project.L_msgItem[i].infoType == InfoType.Tip)
                    {
                        if (tbx_msg.Text == string.Empty)
                            tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                        else
                            tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                    }
                }
            }
            else
            {
                tbx_msg.Clear();
                for (int i = 0; i < Project.L_msgItem.Count; i++)
                {
                    Frm_Msg.Instance.tbx_msg.SelectionStart = Frm_Msg.Instance.tbx_msg.Text.Length;
                    Frm_Msg.Instance.tbx_msg.SelectionLength = 0;

                    switch (Project.L_msgItem[i].infoType)
                    {
                        case InfoType.Tip:
                            Frm_Msg.Instance.tbx_msg.SelectionColor = Color.FromArgb(48, 48, 48);

                            if (tbx_msg.Text == string.Empty)
                                tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            else
                                tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            break;
                        case InfoType.Warn:
                            Frm_Msg.Instance.tbx_msg.SelectionColor = Color.Orange;

                            if (tbx_msg.Text == string.Empty)
                                tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            else
                                tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            break;
                        case InfoType.Error:
                            Frm_Msg.Instance.tbx_msg.SelectionColor = Color.Red;

                            if (tbx_msg.Text == string.Empty)
                                tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            else
                                tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            break;
                    }
                }
            }
            tbx_msg.ScrollToCaret();
        }
        private void tsb_warn_Click(object sender, EventArgs e)
        {
            if (tsb_warn.Checked)
            {
                tsb_tip.Checked = false;
                tsb_error.Checked = false;
                tsb_historyAlarm.Checked = false;

                tbx_msg.Clear();
                tbx_msg.ForeColor = Color.Orange;
                for (int i = 0; i < Project.L_msgItem.Count; i++)
                {
                    if (Project.L_msgItem[i].infoType == InfoType.Warn)
                    {
                        if (tbx_msg.Text == string.Empty)
                            tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                        else
                            tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                    }
                }
            }
            else
            {
                tbx_msg.Clear();
                for (int i = 0; i < Project.L_msgItem.Count; i++)
                {
                    Frm_Msg.Instance.tbx_msg.SelectionStart = Frm_Msg.Instance.tbx_msg.Text.Length;
                    Frm_Msg.Instance.tbx_msg.SelectionLength = 0;

                    switch (Project.L_msgItem[i].infoType)
                    {
                        case InfoType.Tip:
                            Frm_Msg.Instance.tbx_msg.SelectionColor = Color.FromArgb(48, 48, 48);

                            if (tbx_msg.Text == string.Empty)
                                tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            else
                                tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            break;
                        case InfoType.Warn:
                            Frm_Msg.Instance.tbx_msg.SelectionColor = Color.Orange;

                            if (tbx_msg.Text == string.Empty)
                                tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            else
                                tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            break;
                        case InfoType.Error:
                            Frm_Msg.Instance.tbx_msg.SelectionColor = Color.Red;

                            if (tbx_msg.Text == string.Empty)
                                tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            else
                                tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            break;
                    }
                }
            }
            tbx_msg.ScrollToCaret();
        }
        private void tsb_error_Click(object sender, EventArgs e)
        {
            if (tsb_error.Checked)
            {
                tsb_tip.Checked = false;
                tsb_warn.Checked = false;
                tsb_historyAlarm.Checked = false;

                tbx_msg.Clear();
                tbx_msg.ForeColor = Color.Red;
                for (int i = 0; i < Project.L_msgItem.Count; i++)
                {
                    if (Project.L_msgItem[i].infoType == InfoType.Error)
                    {
                        if (tbx_msg.Text == string.Empty)
                            tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                        else
                            tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                    }
                }
            }
            else
            {
                tbx_msg.Clear();
                for (int i = 0; i < Project.L_msgItem.Count; i++)
                {
                    Frm_Msg.Instance.tbx_msg.SelectionStart = Frm_Msg.Instance.tbx_msg.Text.Length;
                    Frm_Msg.Instance.tbx_msg.SelectionLength = 0;

                    switch (Project.L_msgItem[i].infoType)
                    {
                        case InfoType.Tip:
                            Frm_Msg.Instance.tbx_msg.SelectionColor = Color.FromArgb(48, 48, 48);

                            if (tbx_msg.Text == string.Empty)
                                tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            else
                                tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            break;
                        case InfoType.Warn:
                            Frm_Msg.Instance.tbx_msg.SelectionColor = Color.Orange;

                            if (tbx_msg.Text == string.Empty)
                                tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            else
                                tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            break;
                        case InfoType.Error:
                            Frm_Msg.Instance.tbx_msg.SelectionColor = Color.Red;

                            if (tbx_msg.Text == string.Empty)
                                tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            else
                                tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            break;
                    }
                }
            }
            tbx_msg.ScrollToCaret();
        }
        private void tsb_historyAlarm_Click(object sender, EventArgs e)
        {
            if (tsb_historyAlarm.Checked)
            {
                tsb_tip.Checked = false;
                tsb_warn.Checked = false;
                tsb_error.Checked = false;

                tbx_msg.Clear();
                tbx_msg.ForeColor = Color.Red;
                foreach (KeyValuePair<DateTime, string> item in Project.Instance.D_historyAlarm)
                {
                    if (tbx_msg.Text == string.Empty)
                        tbx_msg.AppendText(item.Key.ToString("yyyy_MM_dd HH:mm:ss") + "   " + item.Value);
                    else
                        tbx_msg.AppendText(Environment.NewLine + item.Key.ToString("yyyy_MM_dd HH:mm:ss") + "   " + item.Value);
                }
            }
            else
            {
                tbx_msg.Clear();
                for (int i = 0; i < Project.L_msgItem.Count; i++)
                {
                    Frm_Msg.Instance.tbx_msg.SelectionStart = Frm_Msg.Instance.tbx_msg.Text.Length;
                    Frm_Msg.Instance.tbx_msg.SelectionLength = 0;

                    switch (Project.L_msgItem[i].infoType)
                    {
                        case InfoType.Tip:
                            Frm_Msg.Instance.tbx_msg.SelectionColor = Color.FromArgb(48, 48, 48);

                            if (tbx_msg.Text == string.Empty)
                                tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            else
                                tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            break;
                        case InfoType.Warn:
                            Frm_Msg.Instance.tbx_msg.SelectionColor = Color.Orange;

                            if (tbx_msg.Text == string.Empty)
                                tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            else
                                tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            break;
                        case InfoType.Error:
                            Frm_Msg.Instance.tbx_msg.SelectionColor = Color.Red;

                            if (tbx_msg.Text == string.Empty)
                                tbx_msg.AppendText(Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            else
                                tbx_msg.AppendText(Environment.NewLine + Project.L_msgItem[i].time + "   " + Project.L_msgItem[i].msg);
                            break;
                    }
                }
            }
            tbx_msg.ScrollToCaret();
        }


        private void 清除ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Project.tipNum = 0;
            Project.warnNum = 0;
            Project.errorNum = 0;
            Project.L_msgItem.Clear();
            tbx_msg.Clear();
            tsb_tip.Text = string.Format("提示({0})", Project.tipNum);
            tsb_warn.Text = string.Format("警告({0})", Project.warnNum);
            tsb_error.Text = string.Format("错误({0})", Project.errorNum);
        }
        private void 清除历史报警ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project.Instance.D_historyAlarm.Clear();
            tsb_historyAlarm.Text = string.Format("历史报警({0})", Project.Instance.D_historyAlarm.Count);
            if (tsb_historyAlarm.Checked)
                tbx_msg.Clear();

            //保存
            //当项目比较大的时候保存耗时较长，这个时候如果异常断电，那么序列化不成功，再次开启程序时所有项目文件会全部丢失，为解决此问题：先序列化一个临时项目文件，序列化成功后再移动替换原文件
            //序列化项目
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Format(Application.StartupPath + "\\Temp.sys"), FileMode.OpenOrCreate, FileAccess.Write, FileShare.Delete);
            formatter.Serialize(stream, Project.Instance);
            stream.Close();

            //删除项目
            string[] files = Directory.GetFiles(Application.StartupPath + "\\Config\\Project");
            for (int i = 0; i < files.Length; i++)
            {
                File.SetAttributes(files[i], FileAttributes.Normal);
                new FileInfo(files[i]).Attributes = FileAttributes.Normal;
                File.Delete(files[i]);
            }

            //移动项目
            File.Move(Application.StartupPath + "\\Temp.sys", string.Format(Application.StartupPath + "\\Config\\Project\\{0}.sys", Project.Instance.configuration.projectName));
        }
        private void 暂停滚动3分钟toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FuncLib.sw_stopScroll = new Stopwatch();
            FuncLib.sw_stopScroll.Restart();
        }
        private void tbx_msg_DoubleClick(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Admin, false))
                return;

            Project.tipNum = 0;
            Project.warnNum = 0;
            Project.errorNum = 0;
            Project.L_msgItem.Clear();
            tbx_msg.Clear();
            tsb_tip.Text = string.Format("提示({0})", Project.tipNum);
            tsb_warn.Text = string.Format("警告({0})", Project.warnNum);
            tsb_error.Text = string.Format("错误({0})", Project.errorNum);
        }

    }
}
