using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    /// <summary>
    /// TCP/IP服务端类
    /// </summary>
    [Serializable]
    internal class TCPSever : ServiceBase
    {
        internal TCPSever(string s_name)
        {
            this.name = s_name;
            this.serviceType = ServiceType.TCPIPSever;

            SeverItem severInfo = new SeverItem();
            severInfo.Name = s_name;
            severInfo.SeverObj = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            severInfo.L_clientItem = new List<ClientItem>();
            L_severList.Add(severInfo);
        }

        /// <summary>
        /// 客户端的名称和IP地址
        /// </summary>
        internal Dictionary<string, string> D_clientIPAndName = new Dictionary<string, string>();
        /// <summary>
        /// 测试文本1
        /// </summary>
        internal string sendStr1 = "Test1";
        /// <summary>
        /// 测试文本2
        /// </summary>
        internal string sendStr2 = "Test2";
        /// <summary>
        /// 测试文本3
        /// </summary>
        internal string sendStr3 = "Test3";
        /// <summary>
        /// 是否循环发送
        /// </summary>
        internal bool loopSend = false;
        /// <summary>
        /// 循环发送间隔
        /// </summary>
        internal int loopSendSpan = 1000;
        /// <summary>
        /// 以十六进制收发
        /// </summary>
        internal bool hexMode = false;
        /// <summary>
        /// 接收到的消息
        /// </summary>
        internal string receivedStr = string.Empty;
        /// <summary>
        /// 服务端IP地址
        /// </summary>
        internal string severIP = "127.0.0.1";
        /// <summary>
        /// 服务端端口号
        /// </summary>
        internal Int32 severPort = 6000;
        /// <summary>  
        /// Socket集合  因Socket类不能被序列化，所以声明一个静态的集合来存储    键：服务端名称   值：Socket对象
        /// </summary>
        internal static List<SeverItem> L_severList = new List<SeverItem>();
        /// <summary>
        /// 通讯文件锁，防止文件冲突
        /// </summary>
        private object objComm = new object();
        /// <summary>
        /// 通过服务端名称来查找对应的Socket对象
        /// </summary>
        /// <param name="severName">服务端名称</param>
        /// <returns></returns>
        internal static SeverItem FindSeverByName(string severName)
        {
            for (int i = 0; i < L_severList.Count; i++)
            {
                if (L_severList[i].Name == severName)
                    return L_severList[i];
            }
            return new SeverItem();
        }
        /// <summary>
        /// 通过服务端名称和客户端名称查询指定服务端中的指定客户端
        /// </summary>
        /// <param name="severName"></param>
        /// <param name="clientName"></param>
        /// <returns></returns>
        internal static ClientItem FindClientItemByName(string severName, string clientName)
        {
            for (int i = 0; i < L_severList.Count; i++)
            {
                if (L_severList[i].Name == severName)
                {
                    foreach (ClientItem item in L_severList[i].L_clientItem)
                    {
                        if (item.name == clientName)
                            return item;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 客户端命名查重
        /// </summary>
        /// <param name="jobName">客户端名</param>
        /// <returns>是否已存在</returns>
        internal bool CheckClientExist(string clientName)
        {
            for (int i = 0; i < FindSeverByName(name).L_clientItem.Count; i++)
            {
                if (FindSeverByName(name).L_clientItem[i].name == clientName)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 创建客户端名称
        /// </summary>
        /// <returns></returns>
        internal string CreateClientName(string ip)
        {
            foreach (KeyValuePair<string, string> item in D_clientIPAndName)
            {
                if (item.Key == ip)
                {
                    bool exist = false;
                    for (int i = 0; i < TCPSever.FindSeverByName(name).L_clientItem.Count; i++)
                    {
                        if (TCPSever.FindSeverByName(name).L_clientItem[i].name == item.Value)
                        {
                            exist = true;
                            break;
                        }
                    }

                    if (!exist)
                        return item.Value;
                }
            }

            for (int i = 1; i < 100; i++)
            {
                bool exist = false;
                for (int j = 0; j < FindSeverByName(name).L_clientItem.Count; j++)
                {
                    if (FindSeverByName(name).L_clientItem[j].name == "未命名_" + i)
                    {
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                    return "未命名_" + i;
            }
            return string.Empty;
        }
        /// <summary>
        /// 手动设置客户端名称
        /// </summary>
        internal void SetClientName(string oldName)
        {
        Again:
            string newClientName = FuncLib.ShowInput("请输入新远程客户端名");
            if (newClientName == string.Empty)
                return;

            //命名查重
            if (CheckClientExist(newClientName))
            {
                FuncLib.ShowMessageBox("已存在此名称的服务，远程客户端名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            // 特殊字符检查
            if (newClientName.Contains(@"\"))
            {
                FuncLib.ShowMessageBox("远程客户端名中不能含有 \\ 特殊字符 ，请重新输入", InfoType.Error);
                goto Again;
            }

            for (int i = 0; i < TCPSever.FindSeverByName(name).L_clientItem.Count; i++)
            {
                if (TCPSever.FindSeverByName(name).L_clientItem[i].name + "  " + TCPSever.FindSeverByName(name).L_clientItem[i].IP == oldName)
                {
                    //改变实例名称
                    ClientItem clientItem = TCPSever.FindSeverByName(name).L_clientItem[i];
                    clientItem.name = newClientName;
                    TCPSever.FindSeverByName(name).L_clientItem.RemoveAt(i);
                    TCPSever.FindSeverByName(name).L_clientItem.Insert(i, clientItem);

                    //改变显示列表名称
                    Frm_TCPServer.Instance.tvw_clientList.Nodes[i].Text = newClientName + "  " + TCPSever.FindSeverByName(name).L_clientItem[i].IP;

                    D_clientIPAndName[Regex.Split(TCPSever.FindSeverByName(name).L_clientItem[i].IP, ":")[0]] = newClientName;

                    FuncLib.ShowMsg(string.Format("远程客户端 [ {0} ] 已成功更名为：{1}", Regex.Split(oldName, "  ")[0], newClientName), InfoType.Tip);
                    break;
                }
            }
        }
        /// <summary>
        /// 自动设置客户端名称
        /// </summary>
        internal void SetClientName(string oldName, string newName)
        {
            //命名查重
            if (CheckClientExist(newName))
            {
                FuncLib.ShowMessageBox("已存在此名称的服务，远程客户端名不可重复，请重新输入", InfoType.Error);
                return;
            }

            // 特殊字符检查
            if (newName.Contains(@"\"))
            {
                FuncLib.ShowMessageBox("远程客户端名中不能含有 \\ 特殊字符 ，请重新输入", InfoType.Error);
                return;
            }

            for (int i = 0; i < TCPSever.FindSeverByName(name).L_clientItem.Count; i++)
            {
                if (TCPSever.FindSeverByName(name).L_clientItem[i].name == oldName)
                {
                    //改变实例名称
                    ClientItem clientItem = TCPSever.FindSeverByName(name).L_clientItem[i];
                    clientItem.name = newName;
                    TCPSever.FindSeverByName(name).L_clientItem.RemoveAt(i);
                    TCPSever.FindSeverByName(name).L_clientItem.Insert(i, clientItem);

                    //改变显示列表名称
                    Frm_TCPServer.Instance.tvw_clientList.Nodes[i].Text = newName + "  " + TCPSever.FindSeverByName(name).L_clientItem[i].IP;

                    D_clientIPAndName[Regex.Split(TCPSever.FindSeverByName(name).L_clientItem[i].IP, ":")[0]] = newName;

                    FuncLib.ShowMsg(string.Format("远程客户端 [ {0} ] 已成功更名为：{1}", oldName, newName), InfoType.Tip);
                    break;
                }
            }
        }
        /// <summary>
        /// 保存通讯日志信息到本地
        /// </summary>
        /// <param name="clientName"></param>
        private void SaveCommLog(string clientName, string msg, bool isSend)
        {
            lock (objComm)
            {
                DateTime now = DateTime.Now;
                //string filePath = string.Format("{0}\\{1}\\Log\\Comm\\{2}\\{3}\\", Project.Instance.configuration.dataPath, now.ToString("yyyyMMdd"), name, clientName);
                string filePath = string.Format("{0}\\{1}\\{2}\\{3}\\Log\\Comm\\{4}\\{5}\\",
                    Project.Instance.configuration.dataPath, now.ToString("yyyy"), now.ToString("MMMM"), now.ToString("yyyy_MM_dd"), name, clientName);
                string fileName = now.ToString("yyyy_MM_dd HH时") + ".txt";         //每小时创建一个txt，防止通讯数据交换频率高，数据量大，文本文件过大
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                if (!File.Exists(filePath + fileName))
                    File.Create(filePath + fileName).Close();

                File.AppendAllText(filePath + fileName, now.ToString("yyyy/MM/dd HH:mm:ss    ") + (isSend ? "已发送：" : "已接收：") + msg + Environment.NewLine);
            }
        }
        /// <summary>
        /// 服务端监听
        /// </summary>
        internal override bool Connect()
        {
            Socket socket = FindSeverByName(name).SeverObj;
            try
            {
                //监听状态置False
                for (int i = 0; i < L_severList.Count; i++)
                {
                    if (L_severList[i].Name == name)
                    {
                        SeverItem severItem = L_severList[i];
                        severItem.listend = false;
                        L_severList.RemoveAt(i);
                        L_severList.Insert(i, severItem);
                        break;
                    }
                }

                IPAddress ip = IPAddress.Parse(severIP);
                IPEndPoint point = new IPEndPoint(ip, severPort);
                socket.Bind(point);
                socket.Listen(10);
                FuncLib.ShowMsg(string.Format("TCPIP服务端 [ {0} ] 已启动监听", name));

                //监听状态置True
                for (int i = 0; i < L_severList.Count; i++)
                {
                    if (L_severList[i].Name == name)
                    {
                        SeverItem severItem = L_severList[i];
                        severItem.listend = true;
                        L_severList.RemoveAt(i);
                        L_severList.Insert(i, severItem);
                        break;
                    }
                }
            }
            catch
            {
                FuncLib.ShowMsg(string.Format("TCPIP服务端 [ {0} ] 监听失败！IP地址：{1}  端口号：{2}", name, severIP, severPort), InfoType.Error);
                FuncLib.ShowMessageBox(string.Format("TCPIP服务端 [ {0} ] 监听失败！IP地址：{1}  端口号：{2}\r\n        可能原因 : 1、 IP地址有误或不合法\r\n                         2、 该IP地址和端口号重复监听", name, severIP, severPort), InfoType.Error);
                return false;
            }

            //循环接收客户端连接
            Thread th = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        Socket socket1 = FindSeverByName(name).SeverObj.Accept();

                        ClientItem clientItem = new ClientItem();
                        clientItem.name = CreateClientName(Regex.Split(socket1.RemoteEndPoint.ToString(), ":")[0]);
                        clientItem.IP = Regex.Split(socket1.RemoteEndPoint.ToString(), ":")[0];
                        clientItem.obj = socket1;
                        clientItem.L_historyMsg = new List<string>();

                        FuncLib.ShowMsg(string.Format("服务端 [ {0} ] 已有远程客户端成功连接，客户端信息： {1}", name, socket1.RemoteEndPoint.ToString()), InfoType.Tip);
                        Frm_TCPServer.Instance.Invoke(new Action(() =>
                        {
                            if (Frm_TCPServer.Instance.Visible && Frm_Service.Instance.tvw_serviceList.SelectedNode.Text == name)
                            {
                                bool exist = false;
                                string text = clientItem.name + "  " + Regex.Split(socket1.RemoteEndPoint.ToString(), ":")[0];
                                for (int i = 0; i < Frm_TCPServer.Instance.tvw_clientList.Nodes.Count; i++)
                                {
                                    if (Regex.Split(Frm_TCPServer.Instance.tvw_clientList.Nodes[i].Text, ":")[0] == text)
                                    {
                                        bool addNew = true;
                                        int index = 0;
                                        for (int j = 0; j < Frm_TCPServer.Instance.tvw_clientList.Nodes.Count; j++)
                                        {
                                            if (Regex.Split(Frm_TCPServer.Instance.tvw_clientList.Nodes[j].Text, "  ")[1] == Regex.Split(socket1.RemoteEndPoint.ToString(), ":")[0] && Frm_TCPServer.Instance.tvw_clientList.Nodes[j].Tag.ToString() != "T")
                                            {
                                                addNew = false;
                                                index = j;
                                                break;
                                            }
                                        }
                                        if (addNew)
                                        {
                                            TreeNode treeNode = Frm_TCPServer.Instance.tvw_clientList.Nodes.Add(clientItem.name + "  " + clientItem.IP);
                                            Frm_TCPServer.Instance.tvw_clientList.SetNodeTipsText(treeNode, " ", Color.Green, Color.Green);
                                            treeNode.Tag = "T";

                                            D_clientIPAndName.Add(Regex.Split(socket1.RemoteEndPoint.ToString(), ":")[0], clientItem.name);
                                        }
                                        else
                                        {
                                            Frm_TCPServer.Instance.tvw_clientList.SetNodeTipsText(Frm_TCPServer.Instance.tvw_clientList.Nodes[i], " ", Color.Green, Color.Green);
                                            Frm_TCPServer.Instance.tvw_clientList.Nodes[i].Tag = "T";
                                        }

                                        exist = true;
                                        break;
                                    }
                                }

                                if (!exist)
                                {
                                    TreeNode treeNode = Frm_TCPServer.Instance.tvw_clientList.Nodes.Add(clientItem.name + "  " + clientItem.IP);
                                    Frm_TCPServer.Instance.tvw_clientList.SetNodeTipsText(treeNode, " ", Color.Green, Color.Green);

                                    if (!D_clientIPAndName.ContainsKey(Regex.Split(socket1.RemoteEndPoint.ToString(), ":")[0]))
                                        D_clientIPAndName.Add(Regex.Split(socket1.RemoteEndPoint.ToString(), ":")[0], clientItem.name);
                                }
                            }

                            FindSeverByName(name).L_clientItem.Add(clientItem);

                            if (Frm_TCPServer.Instance.tvw_clientList.SelectedNode == null && Frm_TCPServer.Instance.tvw_clientList.Nodes.Count > 0)
                                Frm_TCPServer.Instance.tvw_clientList.SelectedNode = Frm_TCPServer.Instance.tvw_clientList.Nodes[0];

                            //呼吸灯状态显示
                            if (TCPSever.FindSeverByName(name).L_clientItem.Count == D_clientIPAndName.Count)
                            {
                                if (Frm_Main.Instance.btn_sevice1.Text == name)
                                {
                                    Frm_Main.Instance.btn_sevice1.ForeColor = Color.Green;
                                    Frm_Main.Instance.btn_sevice1.ForeDisableColor = Color.Green;
                                }

                                if (Frm_Main.Instance.btn_sevice2.Text == name)
                                {
                                    Frm_Main.Instance.btn_sevice2.ForeColor = Color.Green;
                                    Frm_Main.Instance.btn_sevice2.ForeDisableColor = Color.Green;
                                }

                                if (Frm_Main.Instance.btn_sevice3.Text == name)
                                {
                                    Frm_Main.Instance.btn_sevice3.ForeColor = Color.Green;
                                    Frm_Main.Instance.btn_sevice3.ForeDisableColor = Color.Green;
                                }

                                if (Frm_Main.Instance.btn_sevice4.Text == name)
                                {
                                    Frm_Main.Instance.btn_sevice4.ForeColor = Color.Green;
                                    Frm_Main.Instance.btn_sevice4.ForeDisableColor = Color.Green;
                                }

                                if (Frm_Main.Instance.btn_sevice5.Text == name)
                                {
                                    Frm_Main.Instance.btn_sevice5.ForeColor = Color.Green;
                                    Frm_Main.Instance.btn_sevice5.ForeDisableColor = Color.Green;
                                }

                                if (Frm_Main.Instance.btn_sevice6.Text == name)
                                {
                                    Frm_Main.Instance.btn_sevice6.ForeColor = Color.Green;
                                    Frm_Main.Instance.btn_sevice6.ForeDisableColor = Color.Green;
                                }

                                if (Frm_Main.Instance.btn_sevice7.Text == name)
                                {
                                    Frm_Main.Instance.btn_sevice7.ForeColor = Color.Green;
                                    Frm_Main.Instance.btn_sevice7.ForeDisableColor = Color.Green;
                                }

                                if (Frm_Main.Instance.btn_sevice8.Text == name)
                                {
                                    Frm_Main.Instance.btn_sevice8.ForeColor = Color.Green;
                                    Frm_Main.Instance.btn_sevice8.ForeDisableColor = Color.Green;
                                }
                            }

                        }));

                        Thread th_receive = new Thread(Recieve);
                        th_receive.IsBackground = true;
                        th_receive.Start(clientItem);
                    }
                    catch
                    {
                        //服务端已停止监听
                        return;
                    }
                }
            });
            th.IsBackground = true;
            th.Start();

            return true;
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="clientName">客户端名称</param>
        /// <param name="msg"></param>
        internal bool Send(string clientName, string msg)
        {
            if (!FindClientItemByName(name, clientName).obj.Connected)
                return false;

            //发送
            byte[] buffer = Encoding.Default.GetBytes(msg);
            FindClientItemByName(name, clientName).obj.Send(buffer);
            FindClientItemByName(name, clientName).sendNum++;

            //显示
            string curTime = DateTime.Now.ToString("HH:mm:ss");
            if (Frm_TCPServer.Instance.Visible && Frm_Service.Instance.tvw_serviceList.SelectedNode.Text == name)
            {
                if (Frm_TCPServer.Instance.tbx_log.Text != string.Empty)
                    Frm_TCPServer.Instance.tbx_log.AppendText(Environment.NewLine);

                Frm_TCPServer.Instance.tbx_log.SelectionStart = Frm_TCPServer.Instance.tbx_log.Text.Length;
                Frm_TCPServer.Instance.tbx_log.SelectionLength = 0;
                Frm_TCPServer.Instance.tbx_log.SelectionColor = Color.Green;
                Frm_TCPServer.Instance.tbx_log.AppendText(" " + curTime + "  已发送：" + msg);
                Frm_TCPServer.Instance.lbl_sendNum.Text = FindClientItemByName(name, clientName).sendNum.ToString();
                Frm_TCPServer.Instance.tbx_log.ScrollToCaret();
            }
            //添加到历史记录
            FindClientItemByName(name, clientName).L_historyMsg.Add(" " + curTime + "  已发送：" + msg);
            if (FindClientItemByName(name, clientName).L_historyMsg.Count > 200)
                FindClientItemByName(name, clientName).L_historyMsg.RemoveAt(0);

            SaveCommLog(clientName, msg, true);
            FuncLib.ShowMsg(string.Format("服务端 [ {0} ] 发送至其客户端 [ {1} ] 消息：{2}", name, clientName, msg));
            return true;
        }
        /// <summary>
        /// 接收消息
        /// </summary>
        private void Recieve(Object obj)
        {
            byte[] buffer = new byte[1024];
            Socket socket = (Socket)((ClientItem)obj).obj;
            while (true)
            {
                int length = 0;
                try
                {
                    length = socket.Receive(buffer);
                }
                catch { }
                string result = Encoding.Default.GetString(buffer, 0, length);
                if (length > 0)
                {
                    Thread th = new Thread(() =>
                    {
                        SaveCommLog(((ClientItem)obj).name, result, true);
                        FindClientItemByName(name, ((ClientItem)obj).name).receiveNum++;

                        //添加到历史记录
                        string curTime = DateTime.Now.ToString("HH:mm:ss");
                        FindClientItemByName(name, ((ClientItem)obj).name).L_historyMsg.Add(" " + curTime + "  已接收：" + result);
                        if (FindClientItemByName(name, ((ClientItem)obj).name).L_historyMsg.Count > 200)
                            FindClientItemByName(name, ((ClientItem)obj).name).L_historyMsg.RemoveAt(0);

                        Frm_TCPServer.Instance.Invoke(new Action(() =>
                        {
                            if (Frm_TCPServer.Instance.Visible && Frm_Service.Instance.tvw_serviceList.SelectedNode.Text == name && Regex.Split(Frm_TCPServer.Instance.tvw_clientList.SelectedNode.Text, "  ")[0] == ((ClientItem)obj).name)
                            {
                                if (Frm_TCPServer.Instance.tbx_log.Text != string.Empty)
                                    Frm_TCPServer.Instance.tbx_log.AppendText(Environment.NewLine);
                                Frm_TCPServer.Instance.tbx_log.AppendText(" " + curTime + "  已接收：" + result);
                                Frm_TCPServer.Instance.lbl_receiveNum.Text = FindClientItemByName(name, ((ClientItem)obj).name).receiveNum.ToString();

                                if (Frm_TCPServer.Instance.tbx_log.Lines.Length > 200)
                                {
                                    Frm_TCPServer.Instance.tbx_log.Clear();
                                    for (int i = 150; i < FindClientItemByName(name, ((ClientItem)obj).name).L_historyMsg.Count; i++)
                                    {
                                        if (i != 0)
                                            Frm_TCPServer.Instance.tbx_log.AppendText(Environment.NewLine);

                                        Frm_TCPServer.Instance.tbx_log.SelectionStart = Frm_TCPServer.Instance.tbx_log.Text.Length;
                                        Frm_TCPServer.Instance.tbx_log.SelectionLength = 0;
                                        if (TCPSever.FindClientItemByName(name, ((ClientItem)obj).name).L_historyMsg[i].Substring(11, 3) == "已接收")        //收到的消息显示黑色
                                            Frm_TCPServer.Instance.tbx_log.SelectionColor = Color.FromArgb(48, 48, 48);
                                        else
                                            Frm_TCPServer.Instance.tbx_log.SelectionColor = Color.Green;
                                        Frm_TCPServer.Instance.tbx_log.AppendText(TCPSever.FindClientItemByName(name, ((ClientItem)obj).name).L_historyMsg[i]);                     //发送的消息显示绿色
                                    }
                                }
                                Frm_TCPServer.Instance.tbx_log.ScrollToCaret();
                            }
                        }));
                        FuncLib.ShowMsg(string.Format("服务端 [ {0} ] 收到自其客户端 [ {1} ] 消息：{2}", name, ((ClientItem)obj).name, result));

                        //流程触发
                        for (int i = 0; i < Scheme.curScheme.L_taskList.Count; i++)
                        {
                            if (Scheme.curScheme.L_taskList[i].taskTrigMode == TaskTrigMode.BasedEthernet)
                            {
                                if (Scheme.curScheme.L_taskList[i].EthernetTrigPort == name && Scheme.curScheme.L_taskList[i].ethernetTrigCmd == result)
                                {
                                    FuncLib.ShowMsg(string.Format("任务 [ {0} ] 已被远程以太网触发", Scheme.curScheme.L_taskList[i].name));
                                    Scheme.curScheme.L_taskList[i].Run();
                                }
                            }
                        }

                        if (result.StartsWith("name"))         //专用指令name   用于对远程客户端重命名，因为当我方做服务端，对方有多个客户端连接时，且我方为主动方时，将无法确定对方哪个是哪个，故需要对方连接上之后立马发送  nameXXX  这样我方就可以知道每个客户端分别是谁了
                        {
                            for (int i = 0; i < FindSeverByName(name).L_clientItem.Count; i++)
                            {
                                if (FindSeverByName(name).L_clientItem[i].name == ((ClientItem)obj).name)
                                {
                                    SetClientName(((ClientItem)obj).name, result.Substring(4, result.Length - 4));
                                    break;
                                }
                            }
                        }
                        else        //自定义指令
                        {
                            receivedStr = result;
                        }
                    });
                    th.IsBackground = true;
                    th.Start();
                }
                else        //远程客户端断开连接
                {
                    string clientIP = string.Empty;
                    try
                    {
                        clientIP = Regex.Split(socket.RemoteEndPoint.ToString(), ":")[0];
                    }
                    catch      //如果是我方服务端主动断开，那么上面这一行会报错，所以需要Try起来
                    {
                        return;
                    }


                    for (int i = 0; i < FindSeverByName(name).L_clientItem.Count; i++)
                    {
                        if (FindSeverByName(name).L_clientItem[i].obj == socket)
                        {
                            FindSeverByName(name).L_clientItem.RemoveAt(i);
                            if (Frm_TCPServer.Instance.Visible && Frm_Service.Instance.tvw_serviceList.SelectedNode.Text == name)
                            {
                                Frm_TCPServer.Instance.tvw_clientList.SetNodeTipsText(Frm_TCPServer.Instance.tvw_clientList.Nodes[i], " ", Color.Red, Color.Red);
                                Frm_TCPServer.Instance.tvw_clientList.Nodes[i].Tag = "F";
                            }
                            break;
                        }
                    }

                    //呼吸灯状态显示
                    if (TCPSever.FindSeverByName(name).L_clientItem.Count != D_clientIPAndName.Count)
                    {
                        if (Frm_Main.Instance.btn_sevice1.Text == name)
                        {
                            Frm_Main.Instance.btn_sevice1.ForeColor = Color.Red;
                            Frm_Main.Instance.btn_sevice1.ForeDisableColor = Color.Red;
                        }

                        if (Frm_Main.Instance.btn_sevice2.Text == name)
                        {
                            Frm_Main.Instance.btn_sevice2.ForeColor = Color.Red;
                            Frm_Main.Instance.btn_sevice2.ForeDisableColor = Color.Red;
                        }

                        if (Frm_Main.Instance.btn_sevice3.Text == name)
                        {
                            Frm_Main.Instance.btn_sevice3.ForeColor = Color.Red;
                            Frm_Main.Instance.btn_sevice3.ForeDisableColor = Color.Red;
                        }

                        if (Frm_Main.Instance.btn_sevice4.Text == name)
                        {
                            Frm_Main.Instance.btn_sevice4.ForeColor = Color.Red;
                            Frm_Main.Instance.btn_sevice4.ForeDisableColor = Color.Red;
                        }

                        if (Frm_Main.Instance.btn_sevice5.Text == name)
                        {
                            Frm_Main.Instance.btn_sevice5.ForeColor = Color.Red;
                            Frm_Main.Instance.btn_sevice5.ForeDisableColor = Color.Red;
                        }

                        if (Frm_Main.Instance.btn_sevice6.Text == name)
                        {
                            Frm_Main.Instance.btn_sevice6.ForeColor = Color.Red;
                            Frm_Main.Instance.btn_sevice6.ForeDisableColor = Color.Red;
                        }

                        if (Frm_Main.Instance.btn_sevice7.Text == name)
                        {
                            Frm_Main.Instance.btn_sevice7.ForeColor = Color.Red;
                            Frm_Main.Instance.btn_sevice7.ForeDisableColor = Color.Red;
                        }

                        if (Frm_Main.Instance.btn_sevice8.Text == name)
                        {
                            Frm_Main.Instance.btn_sevice8.ForeColor = Color.Red;
                            Frm_Main.Instance.btn_sevice8.ForeDisableColor = Color.Red;
                        }
                    }

                    FuncLib.ShowMsg(string.Format("服务端 [ {0} ] 的远程客户端已主动断开连接，客户端信息：{1}", name, socket.RemoteEndPoint.ToString()), InfoType.Error);
                    FuncLib.ShowMessageBox(string.Format("服务端 [ {0} ] 的远程客户端已主动断开连接，客户端信息：{1}", name, socket.RemoteEndPoint.ToString()), InfoType.Error);
                    return;
                }
            }
        }
        /// <summary>
        /// 关闭服务端
        /// </summary>
        internal void Disconect()
        {
            for (int i = 0; i < L_severList.Count; i++)
            {
                if (L_severList[i].Name == name)
                {
                    //断开所有客户端
                    foreach (ClientItem item in L_severList[i].L_clientItem)
                    {
                        if (item.obj.Connected)
                            item.obj.Disconnect(false);
                        item.obj.Close();
                    }

                    //断开服务端
                    if (L_severList[i].SeverObj.Connected)
                        L_severList[i].SeverObj.Disconnect(true);

                    L_severList[i].SeverObj.Close();

                    //移除原对象并重新添加
                    SeverItem severItem = L_severList[i];
                    severItem.SeverObj = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    severItem.L_clientItem.Clear();
                    severItem.listend = false;
                    L_severList.RemoveAt(i);
                    L_severList.Insert(i, severItem);

                    FuncLib.ShowMsg(string.Format("服务端 [ {0} ] 已停止监听", name));
                }
            }
        }
        /// <summary>
        /// 关闭所有服务端
        /// </summary>
        internal static void DisconnectAll()
        {
            for (int i = 0; i < L_severList.Count; i++)
            {
                //断开所有客户端
                foreach (ClientItem item in L_severList[i].L_clientItem)
                {
                    if (item.obj.Connected)
                        item.obj.Disconnect(false);
                    item.obj.Close();
                }

                //断开服务端
                if (L_severList[i].SeverObj.Connected)
                    L_severList[i].SeverObj.Disconnect(false);
                L_severList[i].SeverObj.Close();
            }
        }
    }

    /// <summary>
    /// 服务端类型
    /// </summary>
    internal struct SeverItem
    {
        /// <summary>
        /// 服务端名称
        /// </summary>
        internal string Name;
        /// <summary>
        /// 是否已监听
        /// </summary>
        internal bool listend;
        /// <summary>
        /// Socket对象
        /// </summary>
        internal Socket SeverObj;
        /// <summary>
        /// 连接到此服务端的客户端集合
        /// </summary>
        internal List<ClientItem> L_clientItem;
    }
    /// <summary>
    /// 客户端 名称 端口号 Socket对象
    /// </summary>
    internal class ClientItem
    {
        /// <summary>
        /// 客户端名称
        /// </summary>
        internal string name;
        /// <summary>
        /// 客户端IP
        /// </summary>
        internal string IP;
        /// <summary>
        /// 客户端通讯对象
        /// </summary>
        internal Socket obj;
        /// <summary>
        /// 通讯记录
        /// </summary>
        internal List<string> L_historyMsg;
        /// <summary>
        /// 发送次数
        /// </summary>
        internal Int64 sendNum = 0;
        /// <summary>
        /// 接收次数
        /// </summary>
        internal Int64 receiveNum = 0;
    }

}
