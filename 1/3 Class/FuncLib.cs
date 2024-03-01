using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using VM_Pro.Properties;
using System.Diagnostics;
using Sunny.UI;

namespace VM_Pro
{
    /// <summary>
    /// 常用功能方法库
    /// </summary>
    internal class FuncLib
    {

        /// <summary>
        /// 日志信息暂停滚动3分钟计时
        /// </summary>
        internal static Stopwatch sw_stopScroll = null;
        /// <summary>
        /// 日志输出锁
        /// </summary>
        private static object logObj = new object();
        /// <summary>
        /// 最后一条日志记录
        /// </summary>
        private static string lastMsg = string.Empty;

        /// <summary>
        /// 保存日志信息到本地
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="infoType"></param>
        private static void SaveOperateLog(string msg, InfoType infoType)
        {
            lock (logObj)
            {
                DateTime now = DateTime.Now;
                //string filePath = string.Format("{0}\\{1}\\Info\\Operate\\", Project.Instance.configuration.dataPath, now.ToString("yyyy_MM_dd"));
                string filePath = string.Format("{0}\\{1}\\{2}\\{3}\\Info\\Operate\\",
                    Project.Instance.configuration.dataPath, now.ToString("yyyy"), now.ToString("MMMM"), now.ToString("yyyy_MM_dd"));

                string fileName = now.ToString("yyyy_MM_dd HH时") + ".txt";         //每小时创建一个txt，防止通讯数据交换频率高，数据量大，文本文件过大
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                if (!File.Exists(filePath + fileName))
                    File.Create(filePath + fileName).Close();

                string temp = string.Empty;
                switch (infoType)
                {
                    case InfoType.Alarm:
                        temp = "Alarm";
                        break;
                    case InfoType.Error:
                        temp = "Error ";
                        break;
                    case InfoType.Tip:
                        temp = "Tip    ";
                        break;
                    case InfoType.Warn:
                        temp = "Warn ";
                        break;
                }

                string temp1 = string.Empty;
                switch (Permission.CurPermissionGrade)
                {
                    case PermissionGrade.NoLogin:
                        temp1 = "NoLogin  ";
                        break;
                    case PermissionGrade.Admin:
                        temp1 = "Admin     ";
                        break;
                    case PermissionGrade.Developer:
                        temp1 = "Developer";
                        break;
                }

                File.AppendAllText(filePath + fileName, string.Format("{0}    {1}    {2}    {3}{4}", now.ToString("yyyy/MM/dd HH:mm:ss"), temp1, temp, msg, Environment.NewLine));
            }
        }
        /// <summary>
        /// 显示大提示
        /// </summary>
        internal static void ShowBigTip(string tipInfo)
        {
            Frm_BigTip.Instance.lbl_info.Text = "       " + tipInfo;
            Frm_BigTip.Instance.TopMost = true;
            Frm_BigTip.Instance.TopLevel = true;
            Frm_BigTip.Instance.Show();
        }
        /// <summary>
        /// 日志信息输出
        /// </summary>
        /// <param name="msg">信息内容</param>
        /// <param name="infoType">信息类型：提示 警告 错误</param>
        /// <param name="alarm">是否报警停机</param>
        internal static void ShowMsg(string msg, InfoType infoType = InfoType.Tip, bool isAlarm = true)
        {
            if ((lastMsg == msg && Frm_Msg.Instance.tbx_msg.Text != string.Empty) && infoType != InfoType.Tip)         //重复提示不显示
                return;
            lastMsg = msg;

            if (infoType == InfoType.Error && Device.MachineRunStatu == MachineRunStatu.Running && isAlarm)
                Device.MachineRunStatu = MachineRunStatu.Alarm;
            if (infoType == InfoType.Error && Device.MachineRunStatu == MachineRunStatu.Running && !isAlarm)
                Device.MachineRunStatu = MachineRunStatu.Pause;
            if (infoType == InfoType.Alarm && Device.MachineRunStatu == MachineRunStatu.Running)
                Device.MachineRunStatu = MachineRunStatu.HeavyAlarm;

            SaveOperateLog(msg, infoType);

            //当多个线程高速访问操作此控件，则会出现控件空对象
            Frm_Welcome.Instance.Invoke(new Action(() =>
            {
                switch (infoType)
                {
                    case InfoType.Tip:
                        Project.tipNum++;
                        break;
                    case InfoType.Warn:
                        Project.warnNum++;
                        break;
                    case InfoType.Error:
                        Project.errorNum++;
                        //保存到报警历史
                        if (msg != "安全门已打开，设备暂停运行")
                        {
                            if (isAlarm)
                            {
                                Thread.Sleep(20);       //放置同一时刻有两条信息，那么键值对集合就会报错
                                Project.Instance.D_historyAlarm.Add(DateTime.Now, msg);
                                if (Project.Instance.D_historyAlarm.Count > 1000)
                                    Project.Instance.D_historyAlarm.Remove(Project.Instance.D_historyAlarm.Keys.ToArray()[0]);

                                Project.SaveAlarmHistory();
                            }
                        }
                        break;
                }
                DateTime curTime = DateTime.Now;

                MsgItem msgItem = new MsgItem();
                msgItem.time = curTime.ToString("HH:mm:ss:ff");
                msgItem.msg = msg;
                msgItem.infoType = infoType;
                Project.L_msgItem.Add(msgItem);

                Frm_Msg.Instance.tbx_msg.SelectionStart = Frm_Msg.Instance.tbx_msg.Text.Length;
                Frm_Msg.Instance.tbx_msg.SelectionLength = 0;
                if ((!Frm_Msg.Instance.tsb_warn.Checked && !Frm_Msg.Instance.tsb_error.Checked && !Frm_Msg.Instance.tsb_historyAlarm.Checked) && infoType == InfoType.Tip)
                {
                    Frm_Msg.Instance.tbx_msg.SelectionColor = Color.FromArgb(48, 48, 48);

                    if (Frm_Msg.Instance.tbx_msg.Text == string.Empty)
                        Frm_Msg.Instance.tbx_msg.AppendText(curTime.ToString("HH:mm:ss:ff") + "   " + msg);
                    else
                        Frm_Msg.Instance.tbx_msg.AppendText(Environment.NewLine + curTime.ToString("HH:mm:ss:ff") + "   " + msg);

                    if (!Frm_Msg.Instance.tsb_tip.Checked && !Frm_Msg.Instance.tsb_error.Checked && !Frm_Msg.Instance.tsb_historyAlarm.Checked)
                    {
                        if (sw_stopScroll == null)
                            Frm_Msg.Instance.tbx_msg.ScrollToCaret();
                    }
                }
                if ((!Frm_Msg.Instance.tsb_tip.Checked && !Frm_Msg.Instance.tsb_error.Checked && !Frm_Msg.Instance.tsb_historyAlarm.Checked) && infoType == InfoType.Warn)
                {
                    Frm_Msg.Instance.tbx_msg.SelectionColor = Color.Orange;

                    if (Frm_Msg.Instance.tbx_msg.Text == string.Empty)
                        Frm_Msg.Instance.tbx_msg.AppendText(curTime.ToString("HH:mm:ss:ff") + "   " + msg);
                    else
                        Frm_Msg.Instance.tbx_msg.AppendText(Environment.NewLine + curTime.ToString("HH:mm:ss:ff") + "   " + msg);

                    if (!Frm_Msg.Instance.tsb_tip.Checked && !Frm_Msg.Instance.tsb_error.Checked && !Frm_Msg.Instance.tsb_historyAlarm.Checked)
                    {
                        if (sw_stopScroll == null)
                            Frm_Msg.Instance.tbx_msg.ScrollToCaret();
                    }
                }
                if ((!Frm_Msg.Instance.tsb_tip.Checked && !Frm_Msg.Instance.tsb_warn.Checked) && infoType == InfoType.Error)
                {
                    Frm_Msg.Instance.tbx_msg.SelectionColor = Color.Red;

                    if (Frm_Msg.Instance.tsb_historyAlarm.Checked)
                    {
                        if (Frm_Msg.Instance.tbx_msg.Text == string.Empty)
                            Frm_Msg.Instance.tbx_msg.AppendText(curTime.ToString("HH:mm:ss:ff") + "   " + msg);
                        else
                            Frm_Msg.Instance.tbx_msg.AppendText(Environment.NewLine + curTime.ToString("yyyy_MM_dd HH:mm:ss") + "   " + msg);
                    }
                    else
                    {
                        if (Frm_Msg.Instance.tbx_msg.Text == string.Empty)
                            Frm_Msg.Instance.tbx_msg.AppendText(curTime.ToString("HH:mm:ss:ff") + "   " + msg);
                        else
                            Frm_Msg.Instance.tbx_msg.AppendText(Environment.NewLine + curTime.ToString("HH:mm:ss:ff") + "   " + msg);
                    }

                    if (!Frm_Msg.Instance.tsb_tip.Checked && !Frm_Msg.Instance.tsb_error.Checked && !Frm_Msg.Instance.tsb_historyAlarm.Checked)
                    {
                        if (sw_stopScroll == null)
                            Frm_Msg.Instance.tbx_msg.ScrollToCaret();
                    }
                }

                //满了10000条就清除前9000条，留下最后1000条
                if (Project.L_msgItem.Count == 1000)
                {
                    Project.L_msgItem.RemoveRange(0, 900);
                    Project.tipNum = 0;
                    Project.warnNum = 0;
                    Project.errorNum = 0;
                    Frm_Msg.Instance.tbx_msg.Clear();
                    for (int i = 0; i < Project.L_msgItem.Count; i++)
                    {
                        Frm_Msg.Instance.tbx_msg.SelectionStart = Frm_Msg.Instance.tbx_msg.Text.Length;
                        Frm_Msg.Instance.tbx_msg.SelectionLength = 0;
                        switch (Project.L_msgItem[i].infoType)
                        {
                            case InfoType.Tip:
                                Frm_Msg.Instance.tbx_msg.SelectionColor = Color.FromArgb(48, 48, 48);
                                Project.tipNum++;
                                break;
                            case InfoType.Warn:
                                Frm_Msg.Instance.tbx_msg.SelectionColor = Color.Orange;
                                Project.warnNum++;
                                break;
                            case InfoType.Error:
                                Frm_Msg.Instance.tbx_msg.SelectionColor = Color.Red;
                                Project.errorNum++;
                                break;
                        }

                        if (Frm_Msg.Instance.tbx_msg.Text == string.Empty)
                            Frm_Msg.Instance.tbx_msg.AppendText(curTime + "   " + msg);
                        else
                            Frm_Msg.Instance.tbx_msg.AppendText(Environment.NewLine + curTime + "   " + msg);
                    }

                    if (!Frm_Msg.Instance.tsb_tip.Checked && !Frm_Msg.Instance.tsb_error.Checked && !Frm_Msg.Instance.tsb_historyAlarm.Checked)
                    {
                        if (sw_stopScroll == null)
                            Frm_Msg.Instance.tbx_msg.ScrollToCaret();
                    }
                }

                Frm_Msg.Instance.tsb_tip.Text = string.Format("提示({0})", Project.tipNum);
                Frm_Msg.Instance.tsb_warn.Text = string.Format("警告({0})", Project.warnNum);
                Frm_Msg.Instance.tsb_error.Text = string.Format("错误({0})", Project.errorNum);
                Frm_Msg.Instance.tsb_historyAlarm.Text = string.Format("历史报警({0})", Project.Instance.D_historyAlarm.Count);
                Application.DoEvents();
            }));
        }
        /// <summary>
        /// 弹出选择窗体
        /// </summary>
        /// <param name="msg">要确认的信息</param>
        /// <param name="infoType">窗体类型 提示|警告|错误</param>
        /// <returns></returns>
        internal static DialogResult ShowConfirmDialog(string msg, InfoType infoType = InfoType.Tip)
        {
            Frm_Confirm frm_Confirm = new Frm_Confirm();
            frm_Confirm.lbl_info.Text = "       " + msg;     //首行空出两个字
            switch (infoType)
            {
                case InfoType.Tip:
                    frm_Confirm.Text = "提示";
                    frm_Confirm.TitleColor = Color.Green;
                    break;
                case InfoType.Warn:
                    frm_Confirm.Text = "警告";
                    frm_Confirm.TitleColor = Color.Orange;
                    break;
                case InfoType.Error:
                    frm_Confirm.Text = "错误";
                    frm_Confirm.TitleColor = Color.Red;
                    break;
            }
            frm_Confirm.TopMost = true;
            frm_Confirm.TopLevel = true;
            Frm_Confirm.isShown = true;
            return frm_Confirm.ShowDialog();
        }
        /// <summary>
        /// 弹出确认窗体 已修改为右下角自动弹出，无需确认
        /// </summary>
        /// <param name="msg">要确认的信息</param>
        /// <param name="infoType">窗体类型 提示|警告|错误</param>
        /// <returns></returns>
        internal static void ShowMessageBox(string msg, InfoType infoType = InfoType.Tip)
        {
            UIPage uiPage = new UIPage();
            //uiPage.ShowErrorNotifier("提示错误信息", timeout: 5000);
            switch (infoType)
            {
                case InfoType.Tip:
                    uiPage.ShowInfoTip(msg, 6000);
                    break;
                case InfoType.Warn:
                    uiPage.ShowWarningNotifier(msg, timeout: 6000);
                    break;
                case InfoType.Error:
                    uiPage.ShowErrorNotifier(msg, timeout: 6000);
                    break;
            }
            ShowMsg(msg, infoType);

            #region 旧方法

            ////确认窗体和选择窗体的区别只是没有否选项，所以直接用选择窗体显示
            //Frm_Confirm frm_Confirm = new Frm_Confirm();
            //frm_Confirm.lbl_info.Text = "        " + msg;     //首行空出两个字
            //switch (infoType)
            //{
            //    case InfoType.Tip:
            //        frm_Confirm.Text = "提示";
            //        frm_Confirm.TitleColor = Color.Green;
            //        break;
            //    case InfoType.Warn:
            //        frm_Confirm.Text = "警告";
            //        frm_Confirm.TitleColor = Color.Orange;
            //        break;
            //    case InfoType.Error:
            //        frm_Confirm.Text = "错误";
            //        frm_Confirm.TitleColor = Color.Red;
            //        break;
            //}
            //frm_Confirm.btn_ok.Location = new Point(342, 147);
            //frm_Confirm.btn_no.Visible = false;
            //frm_Confirm.TopMost = true;
            //frm_Confirm.TopLevel = true;
            ////此处在软件初始化时，会偶发用户未点击确认之后，窗体被隐藏，导致软件出现假死现象
            //frm_Confirm.ShowDialog();

            #endregion

        }

        /// <summary>
        /// 弹出异常窗体
        /// </summary>
        /// <param name="msg">要确认的信息</param>
        /// <param name="infoType">窗体类型 提示|警告|错误</param>
        /// <returns></returns>
        internal static void ShowExceptionBox(string msg, InfoType infoType = InfoType.Tip)
        {
            //确认窗体和选择窗体的区别只是没有否选项，所以直接用选择窗体显示
            Frm_Exception Frm_exception = new Frm_Exception();
            Frm_exception.lbl_info.Text = msg;     //首行空出两个字
            Frm_exception.TopMost = true;
            Frm_exception.ShowDialog();
        }
        /// <summary>
        /// 弹出信息输入框
        /// </summary>
        /// <param name="waterMark">提示内容</param>
        /// <returns>输入的文本</returns>
        internal static string ShowInput(string waterMark, string defaultText = "")
        {
            Frm_Input frm_Input = new Frm_Input();
            frm_Input.tbx_input.Watermark = waterMark;
            frm_Input.tbx_input.Text = defaultText;
            frm_Input.Text = waterMark;
            if (frm_Input.ShowDialog() == DialogResult.OK)
                return frm_Input.tbx_input.Text.Trim();
            return string.Empty;
        }

        /// <summary>
        /// 弹窗工具帮助提示信息框
        /// </summary>
        /// <param name="type"></param>
        internal static void ShowTooLHelp(ToolType type)
        {

            StringBuilder sb = new StringBuilder();
            switch (type)
            {
                case ToolType.采集图像:
                    break;
                case ToolType.图像处理:
                    break;
                case ToolType.通道转换:
                    break;
                case ToolType.存储图像:
                    break;
                case ToolType.模板匹配:
                    sb.Append("工具名称：模板匹配\r\n");
                    sb.Append("工具输入：图像(自动链入) \r\n");
                    sb.Append("工具输出：位置点\r\n");
                    sb.Append("输出介绍：输出当前模板匹配找到的特征点信息，若存在多个模板，则会输出多个位置点\r\n");
                    sb.Append("结果显示：根据显示页面勾选的内容，在主窗体当中显示相应的提示信息\r\n");
                    sb.Append("注意事项：若当前特征点存在角度的偏差，则应该绘制完区域之后，点击更多输入相应的角度参数，然后再点击训练按钮\r");
                    break;
                case ToolType.创建区域:
                    sb.Append("工具名称：创建区域\r\n");
                    sb.Append("工具输入：图像(自动链入) + XYU点(即模板特征点，若无特征点，则只能绘制固定区域)\r\n");
                    sb.Append("工具输出：区域 + \r\n");
                    sb.Append("输出介绍：若选择固定区域，则表示不同的图像，每次扣选的都是同个位置的区域，即区域与图像是绝对关系\r\n");
                    sb.Append("若选择跟随区域，则表示区域会与输入的特征点位置进行绑定。即区域与图像是相对关系\r\n" +
                        "此方式适合特征区域不断变化的情况。在框选完区域后，记得" +
                        "点击生成跟随关系按钮，更新最新的模板位置\r\n");
                    sb.Append("结果显示：根据需求勾选是否将当前区域显示到主窗体当中\r\n");
                    sb.Append("注意事项：当前工具非法管控能力待完善，删除模板匹配工具时，记得清空该工具输入项链接\r");
                    break;
                case ToolType.光源控制:
                    break;
                case ToolType.PLC_通讯:
                    break;
                case ToolType.以太网收:
                    break;
                case ToolType.以太网发:
                    break;
                case ToolType.高度测量:
                    break;
                case ToolType.外部输出:
                    break;
                case ToolType.推理识别:
                    sb.Append("工具名称：语义分割 - 推理识别\r\n");
                    sb.Append("工具输入：图像(自动链入) + 区域(创建区域 or 图像预处理区域)\r\n");
                    sb.Append("工具输出：推理图像【推理结果图像】 \r\n");
                    sb.Append("参数介绍：缺陷推理——该工具最终输出相应的缺陷面积信息。图像推理——将语义分割的图像结果给到其他工具进一步处理\r\n");
                    sb.Append("输出介绍：推理结果暂时以字段的方式进行交互，暂未列入到输出项当中\r\n");
                    sb.Append("结果显示：根据需求勾选是否将相应的处理区域显示到主窗体当中,参数界面数据跟随主界面，该选项的意义在于" +
                        "与主界面显示列表联合开发，后续项目有相应的需求也可参照此方式\r\n");
                    sb.Append("注意事项：导入模型时，需要输入检测标签参数，与模型文件。该工具容易Halcon Error #6001内存不够的异常" +
                        "暂无较好的解决办法，目前导入模型时，内存大概会占到4500M左右\r");
                    break;
                case ToolType.自定义处理:
                    sb.Append("工具名称：自定义处理（项目自定义处理工具）\r\n");
                    sb.Append("工具输入：图像(自动链入) \r\n");
                    sb.Append("工具输出：暂无 \r\n");
                    sb.Append("注意事项：输入输出以及相应的逻辑全部根据自定义开发，后续此部分可能作为脚本开放出来\r");
                    break;
                case ToolType.图像预处理:
                    sb.Append("工具名称：传统算法 - 图像预处理\r\n");
                    sb.Append("工具输入：图像(自动链入) + 区域(创建区域 or 图像预处理区域)\r\n");
                    sb.Append("工具输出：图像 + 区域  \r\n");
                    sb.Append("输出介绍：输出预处理后的图像，区域\r\n");
                    sb.Append("结果显示：若当前处理结果需要显示到主窗体时，则根据需要在显示当中勾选相应的选项\r\n");
                    sb.Append("注意事项：当前只开发了阈值分割，其他选项暂未开发，敬请期待！\r");
                    break;
                case ToolType.模型训练:
                    break;
                default:
                    break;
            }
            Frm_Help.Instance.txt_InfoHelp.Text = sb.ToString();
            Frm_Help.Instance.TopMost = true;
            Frm_Help.Instance.TopLevel = true;
            Frm_Help.Instance.Show();
        }


        /// <summary>
        /// OK数量加1
        /// </summary>
        internal static void AddOK()
        {
            Project.Instance.configuration.totalNum++;
            Project.Instance.configuration.OKNum++;
            //Project.SaveSysPar();

            Frm_Infomation.Instance.lbl_totalNum.Text = Project.Instance.configuration.totalNum.ToString();
            Frm_Infomation.Instance.lbl_okNum.Text = Project.Instance.configuration.OKNum.ToString();
            Frm_Infomation.Instance.lbl_yield.Text = Math.Round((Project.Instance.configuration.OKNum / (Project.Instance.configuration.totalNum * 0.01)), 2).ToString() + "%";
            //Application.DoEvents();
        }
        /// <summary>
        /// NG数量加1
        /// </summary>
        internal static void AddNG()
        {
            Project.Instance.configuration.totalNum++;
            Project.Instance.configuration.NGNum++;

            Frm_Infomation.Instance.lbl_totalNum.Text = Project.Instance.configuration.totalNum.ToString();
            Frm_Infomation.Instance.lbl_ngNum.Text = Project.Instance.configuration.NGNum.ToString();
            Frm_Infomation.Instance.lbl_yield.Text = Math.Round((Project.Instance.configuration.OKNum / (Project.Instance.configuration.totalNum * 0.01)), 2).ToString() + "%";
            //Application.DoEvents();
        }
        /// <summary>
        /// 添加通用输入
        /// </summary>
        /// <param name="idx">IO编号</param>
        /// <param name="actNo">映射号</param>
        /// <param name="diName">输入名称</param>
        internal static void AddDi(string cardName, int actNo, Di diName)
        {
            ServiceBase serviceBase = Project.FindServiceByName(cardName);
            if (serviceBase == null)
                return;

            S_Di di = new S_Di();
            di.cardName = cardName;
            di.index = Frm_IO.Instance.dgv_diList.Rows.Count + 1;
            di.actNo = actNo;
            di.diName = diName;
            di.isVitual = false;
            Project.L_di.Add(di);
            Project.D_diVitual.Add(diName, 0);
            Project.D_diCardName.Add(diName, cardName);

            //获取卡号
            int num = 0;
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Card)
                {
                    num++;
                    if (Project.Instance.L_Service[i].name == cardName)
                        break;
                }
            }

            int index = Frm_IO.Instance.dgv_diList.Rows.Add();
            Frm_IO.Instance.dgv_diList.Rows[index].Cells[0].Value = Frm_IO.Instance.dgv_diList.Rows.Count;
            Frm_IO.Instance.dgv_diList.Rows[index].Cells[1].Value = num + "_" + actNo.ToString("00");
            Frm_IO.Instance.dgv_diList.Rows[index].Cells[3].Value = Resources.Off;
            Frm_IO.Instance.dgv_diList.Rows[index].Cells[3].Tag = OnOff.Off;
            Frm_IO.Instance.dgv_diList.Rows[index].Cells[4].Value = diName;
            Frm_IO.Instance.dgv_diList.Rows[index].Tag = cardName;
        }
        /// <summary>
        /// 添加通用输入
        /// </summary>
        /// <param name="idx">IO编号</param>
        /// <param name="actNo">映射号</param>
        /// <param name="diName">输入名称</param>
        internal static void AddDiVitual(string cardName, int actNo, Di diName)
        {
            if (Project.Instance.configuration.showAllSignal)
            {
                ServiceBase serviceBase = Project.FindServiceByName(cardName);
                if (serviceBase == null)
                    return;

                S_Di di = new S_Di();
                di.cardName = cardName;
                di.index = Frm_IO.Instance.dgv_diList.Rows.Count + 1;
                di.actNo = actNo;
                di.diName = diName;
                di.isVitual = false;
                Project.L_di.Add(di);
                Project.D_diVitual.Add(diName, 0);
                Project.D_diCardName.Add(diName, cardName);

                //获取卡号
                int num = 0;
                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].serviceType == ServiceType.Card)
                    {
                        num++;
                        if (Project.Instance.L_Service[i].name == cardName)
                            break;
                    }
                }

                int index = Frm_IO.Instance.dgv_diList.Rows.Add();
                Frm_IO.Instance.dgv_diList.Rows[index].Cells[0].Value = Frm_IO.Instance.dgv_diList.Rows.Count;
                Frm_IO.Instance.dgv_diList.Rows[index].Cells[1].Value = num + "_" + actNo.ToString("00");
                Frm_IO.Instance.dgv_diList.Rows[index].Cells[3].Value = Resources.Off;
                Frm_IO.Instance.dgv_diList.Rows[index].Cells[3].Tag = OnOff.Off;
                Frm_IO.Instance.dgv_diList.Rows[index].Cells[4].Value = diName;

                Frm_IO.Instance.dgv_diList.Rows[index].Tag = cardName;
            }
            else
            {
                ServiceBase serviceBase = Project.FindServiceByName(cardName);
                if (serviceBase == null)
                    return;

                S_Di di = new S_Di();
                di.cardName = cardName;
                di.index = Frm_IO.Instance.dgv_diList.Rows.Count + 1;
                di.actNo = actNo;
                di.diName = diName;
                di.isVitual = true;
                Project.L_di.Add(di);
                Project.D_diVitual.Add(diName, 0);
                Project.D_diCardName.Add(diName, cardName);
            }
        }
        /// <summary>
        /// 添加通用输出
        /// </summary>
        /// <param name="idx">IO编号</param>
        /// <param name="actNo">映射号</param>
        /// <param name="doName">输出名称</param>
        internal static void AddDo(string cardName, int actNo, Do doName)
        {
            ServiceBase serviceBase = Project.FindServiceByName(cardName);
            if (serviceBase == null)
                return;

            S_Do do1 = new S_Do();
            do1.cardName = cardName;
            do1.index = Frm_IO.Instance.dgv_doList.Rows.Count + 1;
            do1.actNo = actNo;
            do1.doName = doName;
            do1.isVirtual = false;
            Project.L_do.Add(do1);
            Project.D_doCardName.Add(doName, cardName);

            //获取卡号
            int num = 0;
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Card)
                {
                    num++;
                    if (Project.Instance.L_Service[i].name == cardName)
                        break;
                }
            }

            int index = Frm_IO.Instance.dgv_doList.Rows.Add();
            Frm_IO.Instance.dgv_doList.Rows[index].Cells[0].Value = Frm_IO.Instance.dgv_doList.Rows.Count;
            Frm_IO.Instance.dgv_doList.Rows[index].Cells[1].Value = num + "_" + actNo.ToString("00");
            Frm_IO.Instance.dgv_doList.Rows[index].Cells[3].Value = Resources.Off;
            Frm_IO.Instance.dgv_doList.Rows[index].Cells[3].Tag = OnOff.Off;
            Frm_IO.Instance.dgv_doList.Rows[index].Cells[4].Value = doName;

            Frm_IO.Instance.dgv_doList.Rows[index].Tag = cardName;
        }
        /// <summary>
        /// 添加通用输出
        /// </summary>
        /// <param name="idx">IO编号</param>
        /// <param name="actNo">映射号</param>
        /// <param name="doName">输出名称</param>
        internal static void AddDoVitual(string cardName, int actNo, Do doName)
        {
            if (Project.Instance.configuration.showAllSignal)
            {
                ServiceBase serviceBase = Project.FindServiceByName(cardName);
                if (serviceBase == null)
                    return;

                S_Do do1 = new S_Do();
                do1.cardName = cardName;
                do1.index = Frm_IO.Instance.dgv_doList.Rows.Count + 1;
                do1.actNo = actNo;
                do1.doName = doName;
                do1.isVirtual = false;
                Project.L_do.Add(do1);
                Project.D_doCardName.Add(doName, cardName);

                //获取卡号
                int num = 0;
                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].serviceType == ServiceType.Card)
                    {
                        num++;
                        if (Project.Instance.L_Service[i].name == cardName)
                            break;
                    }
                }

                int index = Frm_IO.Instance.dgv_doList.Rows.Add();
                Frm_IO.Instance.dgv_doList.Rows[index].Cells[0].Value = Frm_IO.Instance.dgv_doList.Rows.Count;
                Frm_IO.Instance.dgv_doList.Rows[index].Cells[1].Value = num + "_" + actNo.ToString("00");
                Frm_IO.Instance.dgv_doList.Rows[index].Cells[3].Value = Resources.Off;
                Frm_IO.Instance.dgv_doList.Rows[index].Cells[3].Tag = OnOff.Off;
                Frm_IO.Instance.dgv_doList.Rows[index].Cells[4].Value = doName;

                Frm_IO.Instance.dgv_doList.Rows[index].Tag = cardName;
            }
            else
            {
                ServiceBase serviceBase = Project.FindServiceByName(cardName);
                if (serviceBase == null)
                    return;

                S_Do do1 = new S_Do();
                do1.cardName = cardName;
                do1.index = Frm_IO.Instance.dgv_doList.Rows.Count + 1;
                do1.actNo = actNo;
                do1.doName = doName;
                do1.isVirtual = true;
                Project.L_do.Add(do1);
                Project.D_doCardName.Add(doName, cardName);
            }
        }
        /// <summary>
        /// 添加气缸
        /// </summary>
        /// <param name="idx">IO编号</param>
        /// <param name="actOutNo">映射号</param>
        /// <param name="name">气缸名称</param>
        internal static void AddCylinder1(string cardNameActOutNo1, string cardNameActOutNo2, string cardNameActInNo1, string cardNameActInNo2, int actOutNo1, int actOutNo2, int actInNo1, int actInNo2, string cylinderName)
        {
            ServiceBase serviceBase = Project.FindServiceByName(cardNameActOutNo1);
            if (serviceBase == null)
                return;

            CCylinder1 cylinder = new CCylinder1();
            cylinder.cardNameActOutNo1 = cardNameActOutNo1;
            cylinder.cardNameActOutNo2 = cardNameActOutNo2;
            cylinder.cardNameActInNo1 = cardNameActInNo1;
            cylinder.cardNameActInNo2 = cardNameActInNo2;
            cylinder.actOutNo1 = actOutNo1;
            cylinder.actOutNo2 = actOutNo2;
            cylinder.actInNo1 = actInNo1;
            cylinder.actInNo2 = actInNo2;
            cylinder.name = cylinderName;
            Project.L_cylinder1.Add(cylinder);

            Cylinder1 cylinder1 = new Cylinder1(((CCard)serviceBase).cardBase, cylinder);
            Frm_IO.Instance.flowLayoutPanel1.Controls.Add(cylinder1);
            Project.L_cCylinder1.Add(cylinderName, cylinder1);
        }
        /// <summary>
        /// 添加气缸
        /// </summary>
        /// <param name="idx">IO编号</param>
        /// <param name="actOutNo">映射号</param>
        /// <param name="name">气缸名称</param>
        internal static void AddVacuum(string cardNameOut, string cardNameBlow, string cardNameIn, int actOutNo, int actOutBlow, int actInNo, string vacuumName)
        {
            ServiceBase serviceBase = Project.FindServiceByName(cardNameOut);
            if (serviceBase == null)
                return;

            Vacuum vacuum = new Vacuum();
            vacuum.cardNameOut = cardNameOut;
            vacuum.cardNameIn = cardNameIn;
            vacuum.cardNameBlow = cardNameBlow;
            vacuum.actOutNo = actOutNo;
            vacuum.actOutBlowNo = actOutBlow;
            vacuum.actInNo = actInNo;
            vacuum.name = vacuumName;
            Project.L_vacuum.Add(vacuum);

            CVacuum cVacuum = new CVacuum(((CCard)serviceBase).cardBase, vacuum);
            Frm_IO.Instance.flowLayoutPanel2.Controls.Add(cVacuum);
            Project.L_cVacuum.Add(vacuumName, cVacuum);
        }
        /// <summary>
        /// 绑定轴
        /// </summary>
        /// <param name="actNo">轴映射号</param>
        /// <param name="axisName">轴名称</param>
        internal static void AddAxis(string cardName, ushort actNo, Axis axisName)
        {
            S_Axis axis = new S_Axis();
            axis.actNo = actNo;
            axis.axisName = axisName.ToString();
            Project.L_axis.Add(axis);
            Project.D_AxisCardName.Add(axisName, cardName);
        }
        /// <summary>
        /// 操作通用输出
        /// </summary>
        /// <param name="doName"></param>
        /// <param name="onOff"></param>
        internal static void SetDo(Do doName, OnOff onOff)
        {
            if (Project.D_doCardName.ContainsKey(doName))
                ((CCard)Project.FindServiceByName(Project.D_doCardName[doName])).cardBase.SetDo(doName, onOff);
        }
        /// <summary>
        /// 操作通用输出
        /// </summary>
        /// <param name="doName"></param>
        /// <param name="onOff"></param>
        internal static void SetOn(Do doName)
        {
            if (Project.D_doCardName.ContainsKey(doName))
                ((CCard)Project.FindServiceByName(Project.D_doCardName[doName])).cardBase.SetDo(doName, OnOff.On);
        }
        /// <summary>
        /// 操作通用输出
        /// </summary>
        /// <param name="doName"></param>
        /// <param name="onOff"></param>
        internal static void SetOff(Do doName)
        {
            if (Project.D_doCardName.ContainsKey(doName))
                ((CCard)Project.FindServiceByName(Project.D_doCardName[doName])).cardBase.SetDo(doName, OnOff.Off);
        }
        /// <summary>
        /// 操作通用输出
        /// </summary>
        /// <param name="doName"></param>
        /// <param name="onOff"></param>
        internal static void ResetDo(Do doName, OnOff onOff)
        {
            if (Project.D_doCardName.ContainsKey(doName))
                ((CCard)Project.FindServiceByName(Project.D_doCardName[doName])).cardBase.SetDo(doName, OnOff.Off);
        }
        /// <summary>
        /// 操作通用输出
        /// </summary>
        /// <param name="doName"></param>
        /// <param name="onOff"></param>
        internal static void SetDo(string cardName, int doIdx, OnOff onOff)
        {
            ((CCard)Project.FindServiceByName(cardName)).cardBase.SetDo(doIdx, onOff);
        }
        /// <summary>
        /// 获取通用输入状态
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        internal static OnOff GetDiSts(Di diName)
        {
            if (Project.D_diCardName.ContainsKey(diName))
                return ((CCard)Project.FindServiceByName(Project.D_diCardName[diName])).cardBase.GetDiSts(diName);
            else
                return OnOff.Off;
        }
        /// <summary>
        /// 获取通用输出状态
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        internal static OnOff GetSts(Do doName)
        {
            if (Project.D_doCardName.ContainsKey(doName))
                return ((CCard)Project.FindServiceByName(Project.D_doCardName[doName])).cardBase.GetDoSts(doName);
            else
                return OnOff.Off;
        }
        /// <summary>
        /// 获取通用输入状态
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        internal static OnOff GetSts(string cardName, int diIdx)
        {
            if (Project.FindServiceByName(cardName) != null)
                return ((CCard)Project.FindServiceByName(cardName)).cardBase.GetDiSts(diIdx);
            else
                return OnOff.Off;
        }
        /// <summary>
        /// 获取通用输出状态
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        internal static OnOff GetDoSts(string cardName, int doIdx)
        {
            return ((CCard)Project.FindServiceByName(cardName)).cardBase.GetDoSts(doIdx);
        }
        /// <summary>
        /// 绑定启动信号
        /// </summary>
        /// <param name="doName">启动信号</param>
        internal static void BindStart(string cardName, int doIdx)
        {
            Project.startSignalCardName = cardName;
            Project.startSignalIdx = doIdx;
        }
        /// <summary>
        /// 绑定停止信号
        /// </summary>
        /// <param name="doName">停止信号</param>
        internal static void BindStop(string cardName, int doIdx)
        {
            Project.stopSignalCardName = cardName;
            Project.stopSignalIdx = doIdx;
        }
        /// <summary>
        /// 绑定复位信号
        /// </summary>
        /// <param name="doName">复位信号</param>
        internal static void BindReset(string cardName, int doIdx)
        {
            Project.resetSignalCardName = cardName;
            Project.resetSignalIdx = doIdx;
        }
        /// <summary>
        /// 绑定急停信号
        /// </summary>
        /// <param name="doName">急停信号</param>
        internal static void BindEMG(string cardName, int doIdx)
        {
            Project.emgSignalCardName = cardName;
            Project.emgSignalIdx = doIdx;
        }
        /// <summary>
        /// 绑定三色灯红灯信号
        /// </summary>
        /// <param name="doName">红灯信号</param>
        internal static void BindLightRed(string cardName, int doIdx)
        {
            Project.lightRedCardName = cardName;
            Project.lightRedIdx = doIdx;
        }
        /// <summary>
        /// 绑定三色灯红灯信号
        /// </summary>
        /// <param name="doName">绿灯信号</param>
        internal static void BindLightGreen(string cardName, int doIdx)
        {
            Project.lightGreenCardName = cardName;
            Project.lightGreenIdx = doIdx;
        }
        /// <summary>
        /// 绑定三色灯黄灯信号
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="doIdx"></param>
        internal static void BindLightYellow(string cardName, int doIdx)
        {
            Project.lightYellowCardName = cardName;
            Project.lightYellowIdx = doIdx;
        }
        /// <summary>
        /// 绑定蜂鸣器信号
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="doIdx"></param>
        internal static void BindBuzzer(string cardName, int doIdx)
        {
            Project.buzzerCardName = cardName;
            Project.buzzerIdx = doIdx;
        }
        /// <summary>
        /// 绑定照明灯信号
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="doIdx"></param>
        internal static void BindLight(string cardName, int doIdx)
        {
            Project.lightCardName = cardName;
            Project.lightIdx = doIdx;
        }
        /// <summary>
        /// 绑定安全门信号
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="doIdx"></param>
        internal static void BindSafeDoor(string cardName, int doIdx)
        {
            Project.safeDoorCardName = cardName;
            Project.safeDoorIdx = doIdx;
        }
        /// <summary>
        /// 绑定本机要板信号
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="doIdx"></param>
        internal static void BindAskMaterial(string cardName, int doIdx)
        {
            Project.askMaterialCardName = cardName;
            Project.askMaterialIdx = doIdx;
        }
        /// <summary>
        /// 绑定下机要板信号
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="doIdx"></param>
        internal static void BindNextAskMaterial(string cardName, int doIdx)
        {
            Project.nextAskMaterialCardName = cardName;
            Project.nextAskMaterialIdx = doIdx;
        }
        /// <summary>
        /// 轴是否正在运动
        /// </summary>
        /// <param name="axisName"></param>
        /// <returns></returns>
        internal static bool axisIsMoving(Axis axisName)
        {
            if (Project.D_AxisCardName.ContainsKey(axisName))
                return ((CCard)Project.FindServiceByName(Project.D_AxisCardName[axisName])).cardBase.IsMoving(axisName);
            else
                return false;
        }
        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="axisName"></param>
        /// <returns></returns>
        internal static bool Home(Axis axisName)
        {
            if (Project.D_AxisCardName.ContainsKey(axisName))
                return ((CCard)Project.FindServiceByName(Project.D_AxisCardName[axisName])).cardBase.Home(axisName);
            else
                return false;
        }
        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="axisName"></param>
        /// <returns></returns>
        internal static bool HomeU(Axis axisName)
        {
            if (Project.D_AxisCardName.ContainsKey(axisName))
                return ((CCard)Project.FindServiceByName(Project.D_AxisCardName[axisName])).cardBase.HomeU(axisName);
            else
                return false;
        }
        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="axisName"></param>
        /// <returns></returns>
        internal static double GetCmdPos(Axis axisName)
        {
            if (Project.D_AxisCardName.ContainsKey(axisName))
                return ((CCard)Project.FindServiceByName(Project.D_AxisCardName[axisName])).cardBase.GetCmdPos(axisName);
            else
                return 0;
        }
        /// <summary>
        /// 轴减速停止
        /// </summary>
        /// <param name="axisName"></param>
        /// <returns></returns>
        internal static void DecStop(Axis axisName)
        {
            if (Project.D_AxisCardName.ContainsKey(axisName))
                ((CCard)Project.FindServiceByName(Project.D_AxisCardName[axisName])).cardBase.DecStop(axisName);
        }
        /// <summary>
        /// 轴立即停止
        /// </summary>
        /// <param name="axisName"></param>
        /// <returns></returns>
        internal static void QuickStop(Axis axisName)
        {
            if (Project.D_AxisCardName.ContainsKey(axisName))
                ((CCard)Project.FindServiceByName(Project.D_AxisCardName[axisName])).cardBase.QuickStop(axisName);
        }
        /// <summary>
        /// 轴连续运动
        /// </summary>
        /// <param name="axisName"></param>
        /// <returns></returns>
        internal static void KeepMove(Axis axisName, Dir dir, int vel, bool waitDone, bool testMode = false)
        {
            if (Project.D_AxisCardName.ContainsKey(axisName))
                ((CCard)Project.FindServiceByName(Project.D_AxisCardName[axisName])).cardBase.KeepMove(axisName, dir, vel, waitDone, testMode);
        }
        /// <summary>
        /// 指定轴移动到指定位置
        /// </summary>
        /// <param name="axisName"></param>
        /// <param name="dir"></param>
        /// <param name="vel"></param>
        /// <param name="waitDone"></param>
        /// <param name="testMode"></param>
        internal static bool MoveAbs(Axis axisName, double pos, int vel, bool waitDone, bool testMode = false)
        {
            if (Project.D_AxisCardName.ContainsKey(axisName))
                return ((CCard)Project.FindServiceByName(Project.D_AxisCardName[axisName])).cardBase.MoveAbs(axisName.ToString(), pos, vel, waitDone, testMode);
            else
                return false;
        }
        /// <summary>
        /// 相对位置移动
        /// </summary>
        /// <param name="axisName"></param>
        /// <param name="dir"></param>
        /// <param name="vel"></param>
        /// <param name="waitDone"></param>
        /// <param name="testMode"></param>
        internal static void MoveRel(Axis axisName, double pos, int vel, bool waitDone, bool testMode = false)
        {
            if (Project.D_AxisCardName.ContainsKey(axisName))
                ((CCard)Project.FindServiceByName(Project.D_AxisCardName[axisName])).cardBase.MoveRel(axisName, pos, vel, waitDone, testMode);
        }
        /// <summary>
        /// 插补运动
        /// </summary>
        /// <returns></returns>
        internal static bool MoveInterpolateAbs(Axis axis1, Axis axis2, double pos1, double pos2, double acc, double vel)
        {
            if (Project.D_AxisCardName.ContainsKey(axis1) && Project.D_AxisCardName.ContainsKey(axis2))
                return ((CCard)Project.FindServiceByName(Project.D_AxisCardName[axis1])).cardBase.MoveInterpolate(axis1, axis2, pos1, pos2, acc, vel);
            else
                return false;
        }
        /// <summary>
        /// 插补运动
        /// </summary>
        /// <returns></returns>
        internal static void MoveInterpolateRel(Axis axis1, Axis axis2, double spanPos1, double spanPos2, double acc, double vel)
        {
            if (Project.D_AxisCardName.ContainsKey(axis1) && Project.D_AxisCardName.ContainsKey(axis2))
            {
                double pos1 = GetCmdPos(axis1) + spanPos1;
                double pos2 = GetCmdPos(axis2) + spanPos2;

                ((CCard)Project.FindServiceByName(Project.D_AxisCardName[axis1])).cardBase.MoveInterpolate(axis1, axis2, pos1, pos2, acc, vel);
            }
        }
        /// <summary>
        /// 前往指定点
        /// </summary>
        /// <param name="posTableName"></param>
        /// <param name="posName"></param>
        internal static bool GoToPos(string posTableName, string posName)
        {
            return SmartPosTable.GoPos(posTableName, posName, true, MainTask.GetRunVel());
        }
        /// <summary>
        /// 门型移动到某点位
        /// </summary>
        /// <returns></returns>
        internal static bool CarryRobotDoorMoveTo(string posTableName, string posName)
        {
            Pos pos = FindPosByName(posTableName, posName);

            if (!FuncLib.MoveAbs(Axis.搬运Z, Project.Instance.configuration.carrySafetyHeight, (int)(pos.vel * MainTask.GetRunVel()), true))
            {
                FuncLib.ShowMsg(string.Format("运动机构前往表【{0}】中的点【{1}】失败，请检查", posTableName, posName), InfoType.Error);
                return false;
            }
            if (!FuncLib.MoveAbs(Axis.搬运Y, pos.L_point[0], (int)(pos.vel * MainTask.GetRunVel()), true))
            {
                FuncLib.ShowMsg(string.Format("运动机构前往表【{0}】中的点【{1}】失败，请检查", posTableName, posName), InfoType.Error);
                return false;
            }
            if (!FuncLib.MoveAbs(Axis.搬运Z, pos.L_point[1], (int)(pos.vel * MainTask.GetRunVel()), true))
            {
                FuncLib.ShowMsg(string.Format("运动机构前往表【{0}】中的点【{1}】失败，请检查", posTableName, posName), InfoType.Error);
                return false;
            }

            FuncLib.ShowMsg(string.Format("运动机构前往表【{0}】中的点【{1}】成功", posTableName, posName));
            return true;
        }
        /// <summary>
        /// 门型移动到某点位
        /// </summary>
        /// <returns></returns>
        internal static bool FilmRobotDoorMoveTo(string posTableName, string posName)
        {
            Pos pos = FindPosByName(posTableName, posName);

            if (!FuncLib.MoveAbs(Axis.贴合Z, Project.Instance.configuration.filmsafetyHeight, (int)(pos.vel * MainTask.GetRunVel()), true))
            {
                FuncLib.ShowMsg(string.Format("运动机构前往表【{0}】中的点【{1}】失败，请检查", posTableName, posName), InfoType.Error);
                return false;
            }
            if (!FuncLib.MoveAbs(Axis.贴合X, pos.L_point[0], (int)(pos.vel * MainTask.GetRunVel()), true))
            {
                FuncLib.ShowMsg(string.Format("运动机构前往表【{0}】中的点【{1}】失败，请检查", posTableName, posName), InfoType.Error);
                return false;
            }
            if (!FuncLib.MoveAbs(Axis.贴合R, pos.L_point[2], (int)(pos.vel * MainTask.GetRunVel()), true))
            {
                FuncLib.ShowMsg(string.Format("运动机构前往表【{0}】中的点【{1}】失败，请检查", posTableName, posName), InfoType.Error);
                return false;
            }
            if (!FuncLib.MoveAbs(Axis.贴合Z, pos.L_point[1], (int)(pos.vel * MainTask.GetRunVel()), true))
            {
                FuncLib.ShowMsg(string.Format("运动机构前往表【{0}】中的点【{1}】失败，请检查", posTableName, posName), InfoType.Error);
                return false;
            }

            FuncLib.ShowMsg(string.Format("运动机构前往表【{0}】中的点【{1}】成功", posTableName, posName));
            return true;
        }
        /// <summary>
        /// 通过点位名称寻找对应点位
        /// </summary>
        /// <param name="posTableName"></param>
        /// <param name="posName"></param>
        /// <returns></returns>
        internal static Pos FindPosByName(string posTableName, string posName)
        {
            for (int i = 0; i < Scheme.curScheme.smartPosTable.L_Table.Count; i++)
            {
                if (Scheme.curScheme.smartPosTable.L_Table[i].tableName == posTableName)
                {
                    for (int j = 0; j < Scheme.curScheme.smartPosTable.L_Table[i].L_pos.Count; j++)
                    {
                        if (Scheme.curScheme.smartPosTable.L_Table[i].L_pos[j].posName == posName)
                        {
                            return Scheme.curScheme.smartPosTable.L_Table[i].L_pos[j];
                        }
                    }
                }
            }
            return null;
        }

    }
}
