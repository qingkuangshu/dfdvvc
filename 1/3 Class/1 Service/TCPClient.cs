using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    /// <summary>
    ///  TCP/IP客户端类
    /// </summary>
    [Serializable]
    internal class TCPClient : ServiceBase
    {
        internal TCPClient(string s_name)
        {
            this.name = s_name;
            this.serviceType = ServiceType.TCPIPClient;

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            L_socket.Add(name, socket);
        }

        /// <summary>
        /// 自行主动断开连接
        /// </summary>
        internal bool disconnectBySelf = false;
        /// <summary>
        /// 服务端IP地址
        /// </summary>
        internal string severIP = "127.0.0.1";
        /// <summary>
        /// 服务端端口号
        /// </summary>
        internal Int32 severPort = 6000;
        /// <summary>  
        /// Socket集合  因Socket类不能被序列化，所以声明一个静态的集合来存储    键：通讯设备名   值：Socket对象
        /// </summary>
        internal static Dictionary<string, Socket> L_socket = new Dictionary<string, Socket>();
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
        /// 以十六进制收发
        /// </summary>
        internal bool hexMode = false;
        /// <summary>
        /// 断开时是否自动连接
        /// </summary>
        public bool autoConnect = true;
        /// <summary>
        /// 连接失败时自动重新连接
        /// </summary>
        internal bool failAutoConnect = false;
        /// <summary>
        /// 是否启用连接超时
        /// </summary>
        internal bool connectTimeoutEnable = true;
        /// <summary>
        /// 是否启用接收超时
        /// </summary>
        internal bool receiveTimeoutEnable = false;
        /// <summary>
        /// 是否循环发送
        /// </summary>
        internal bool loopSend = false;
        /// <summary>
        /// 循环发送间隔
        /// </summary>
        internal int loopSendSpan = 1000;
        /// <summary>
        /// 连接超时时间
        /// </summary>
        internal Int32 connectTimeout = 200;
        /// <summary>
        /// 接收超时时间
        /// </summary>
        internal Int32 receiveTimeout = 3000;
        /// <summary>
        /// 接收到的消息
        /// </summary>
        internal string receivedStr = string.Empty;
        /// <summary>
        /// 发送次数
        /// </summary>
        internal Int64 sendNum = 0;
        /// <summary>
        /// 接收次数
        /// </summary>
        internal Int64 receiveNum = 0;
        /// <summary>
        /// 通讯记录
        /// </summary>
        internal List<string> L_historyMsg = new List<string>();
        /// <summary>
        /// 连接服务端超时
        /// </summary>
        private static ManualResetEvent _timeoutObject = new ManualResetEvent(false);
        /// <summary>
        /// 是否成功连接
        /// </summary>
        private static bool _isConnectSuccessed = false;
        /// <summary>
        /// 通讯文件锁，防止文件冲突
        /// </summary>
        private object _objComm = new object();

        /// <summary>
        /// 通过通讯设备名来查找对应的Socket对象
        /// </summary>
        /// <param name="name">客户端名称</param>
        /// <returns></returns>
        internal static Socket FindClientByName(string name)
        {
            foreach (KeyValuePair<string, Socket> item in L_socket)
            {
                if (item.Key == name)
                    return item.Value;
            }
            return null;
        }
        /// <summary>
        /// 保存通讯日志信息到本地
        /// </summary>
        /// <param name="clientName"></param>
        private void SaveCommLog(string msg, bool isSend)
        {
            lock (_objComm)
            {
                DateTime now = DateTime.Now;
                //string filePath = string.Format("{0}\\{1}\\Log\\Comm\\{2}\\", Project.Instance.configuration.dataPath, now.ToString("yyyy_MM_dd"), name);
                string filePath = string.Format("{0}\\{1}\\{2}\\{3}\\Log\\Comm\\{4}\\",
                    Project.Instance.configuration.dataPath, now.ToString("yyyy"), now.ToString("MMMM"), now.ToString("yyyy_MM_dd"), name);
                string fileName = now.ToString("yyyy_MM_dd HH时") + ".txt";         //每小时创建一个txt，防止通讯数据交换频率高，数据量大，文本文件过大
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                if (!File.Exists(filePath + fileName))
                    File.Create(filePath + fileName).Close();

                File.AppendAllText(filePath + fileName, now.ToString("yyyy/MM/dd HH:mm:ss    ") + (isSend ? "已发送：" : "已接收：") + msg + Environment.NewLine);
            }
        }
        /// <summary>
        /// 连接服务端
        /// </summary>
        internal override bool Connect()
        {
            _timeoutObject.Reset();
            for (int i = 0; i < L_socket.Count; i++)
            {
                if (L_socket.Keys.ToArray()[i] == name)
                    L_socket[L_socket.Keys.ToArray()[i]] = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            IPAddress ip;
            try
            {
                ip = IPAddress.Parse(severIP);
            }
            catch
            {
                FuncLib.ShowMsg(string.Format("TCPIP客户端 [ {0} ] 连接失败！IP地址有误或不合法，IP地址：{1}  端口号：{2}", name, severIP, severPort), InfoType.Error);
                FuncLib.ShowMessageBox(string.Format("TCPIP客户端 [ {0} ] 连接失败！IP地址：{1}  端口号：{2}\r\n       可能原因 : 1、 IP地址有误或不合法", name, severIP, severPort), InfoType.Error);
                return false;
            }
            try
            {
                FindClientByName(name).BeginConnect(severIP, severPort, new AsyncCallback(CallBackMethod), FindClientByName(name));
                if (_timeoutObject.WaitOne(connectTimeoutEnable ? connectTimeout : 8000, false))
                {
                    if (_isConnectSuccessed)
                    {
                        //连接成功
                        FuncLib.ShowMsg(string.Format("客户端 [ {0} ] 已连接到远程服务端", name));
                    }
                    else
                    {
                        ///连接失败则再次连接
                        if (failAutoConnect)
                        {
                            LoopConnect();
                        }
                        else
                        {
                            FuncLib.ShowMsg(string.Format("客户端 [ {0} ] 连接失败！IP地址：{1}  端口号：{2}", name, severIP, severPort), InfoType.Error);
                            //if (FuncLib.ShowConfirmDialog(string.Format("客户端 [ {0} ] 连接失败！IP地址：{1}  端口号：{2}，点击\"是\"自动持续连接，点击\"否\"放弃连接\r\n       可能原因 : 1、 远程服务端未监听", name, severIP, severPort), InfoType.Error) == DialogResult.OK)
                            FuncLib.ShowMessageBox(string.Format("客户端 [ {0} ] 连接失败！IP地址：{1}  端口号：{2}，已启用自动连接 ", name, severIP, severPort), InfoType.Error);
                            LoopConnect();
                        }
                    }
                }
                else
                {
                    ///连接失败则再次连接
                    if (failAutoConnect)
                    {
                        LoopConnect();
                    }
                    else
                    {
                        FuncLib.ShowMsg(string.Format("客户端 [ {0} ] 连接超时！IP地址：{1}  端口号：{2}", name, severIP, severPort), InfoType.Error);
                        //if (FuncLib.ShowConfirmDialog(string.Format("客户端 [ {0} ] 连接超时！IP地址：{1}  端口号：{2}，点击\"是\"自动持续连接，点击\"否\"放弃连接\r\n       可能原因 : 1、 远程服务端未监听\r\n                        2、 超时时间过短", name, severIP, severPort), InfoType.Error) == DialogResult.OK)
                        FuncLib.ShowMessageBox(string.Format("客户端 [ {0} ] 连接失败！IP地址：{1}  端口号：{2}，已启用自动连接 ", name, severIP, severPort), InfoType.Error);
                        LoopConnect();
                    }
                }
            }
            catch
            {
                ///连接失败则再次连接
                if (failAutoConnect)
                {
                    LoopConnect();
                }
                else
                {
                    FuncLib.ShowMsg(string.Format("客户端 [ {0} ] 连接失败！IP地址：{1}  端口号：{2}", name, severIP, severPort), InfoType.Error);
                    //if (FuncLib.ShowConfirmDialog(string.Format("客户端 [ {0} ] 连接失败！IP地址：{1}  端口号：{2}，点击\"是\"放弃连接，点击\"否\"再次连接\r\n       可能原因 : 1、 远程服务端未监听", name, severIP, severPort), InfoType.Error) == DialogResult.OK)
                    FuncLib.ShowMessageBox(string.Format("客户端 [ {0} ] 连接失败！IP地址：{1}  端口号：{2}，已启用自动连接 ", name, severIP, severPort), InfoType.Error);
                    LoopConnect();
                }
            }
            if (receiveTimeoutEnable)
                TCPClient.FindClientByName(name).ReceiveTimeout = receiveTimeout;

            if (FindClientByName(name).Connected)
            {
                Thread th_recieve = new Thread(Recieve);
                th_recieve.IsBackground = true;
                th_recieve.Start();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 循环连接
        /// </summary>
        private void LoopConnect()
        {
            Thread th = new Thread(() =>
            {
                for (int i = 0; i < L_socket.Count; i++)
                {
                    if (L_socket.Keys.ToArray()[i] == name)
                    {
                        L_socket[L_socket.Keys.ToArray()[i]] = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    }
                }
                while (!FindClientByName(name).Connected)
                {
                    IPAddress ip;
                    try
                    {
                        ip = IPAddress.Parse(severIP);
                    }
                    catch
                    {
                        FuncLib.ShowMsg(string.Format("客户端 [{0}] 连接失败！IP地址有误或不合法，IP地址：{1}  端口号：{2}", name, severIP, severPort), InfoType.Error);
                        FuncLib.ShowMessageBox(string.Format("客户端 [{0}] 连接失败！IP地址：{1}  端口号：{2}\r\n       原因 : 1、 IP地址有误或不合法", name, severIP, severPort), InfoType.Error);
                        return;
                    }
                    IPEndPoint point = new IPEndPoint(ip, severPort);
                    try
                    {
                        FindClientByName(name).Connect(point);
                        FuncLib.ShowMsg(string.Format("客户端 [ {0} ] 已自动重新连接到远程服务端", name));
                        Thread th_recieve = new Thread(Recieve);
                        th_recieve.IsBackground = true;
                        th_recieve.Start();
                    }
                    catch { }
                    Thread.Sleep(1000);
                }

                if (Frm_TCPClient.Instance.Visible && Frm_Service.Instance.tvw_serviceList.SelectedNode.Text == name)
                {
                    Frm_TCPClient.Instance.btn_connect.Text = "断开";
                    Frm_Service.Instance.lbl_connectStatu.Text = "已连接";
                    Frm_Service.Instance.lbl_connectStatu.ForeColor = Color.Green;
                    Frm_Service.Instance.tvw_serviceList.SetNodeTipsText(Frm_Service.Instance.tvw_serviceList.SelectedNode, "•", Color.Green, Color.Green);
                }
            });
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg">消息</param>
        internal bool Send(string msg)
        {
            if (!FindClientByName(name).Connected)
                return false;

            byte[] buffer = Encoding.Default.GetBytes(msg);
            FindClientByName(name).Send(buffer);
            sendNum++;

            string curTime = DateTime.Now.ToString("HH:mm:ss");
            if (Frm_TCPClient.Instance.Visible && Frm_Service.Instance.tvw_serviceList.SelectedNode.Text == name)
            {
                if (Frm_TCPClient.Instance.tbx_log.Text != string.Empty)
                    Frm_TCPClient.Instance.tbx_log.AppendText(Environment.NewLine);

                Frm_TCPClient.Instance.tbx_log.SelectionStart = Frm_TCPClient.Instance.tbx_log.Text.Length;
                Frm_TCPClient.Instance.tbx_log.SelectionLength = 0;
                Frm_TCPClient.Instance.tbx_log.SelectionColor = Color.Green;
                Frm_TCPClient.Instance.tbx_log.AppendText(" " + curTime + "  已发送：" + msg);
                Frm_TCPClient.Instance.lbl_sendNum.Text = sendNum.ToString();
                Frm_TCPClient.Instance.tbx_log.ScrollToCaret();
            }
            //添加到历史记录
            L_historyMsg.Add(" " + curTime + "  已发送：" + msg);
            if (L_historyMsg.Count > 200)
                L_historyMsg.RemoveAt(0);

            SaveCommLog(msg, true);
            FuncLib.ShowMsg(string.Format("客户端 [ {0} ] 已发送消息：{1}", name, msg));
            return true;
        }
        /// <summary>
        /// 接收一次消息
        /// </summary>
        internal string RecieveOnce()
        {
            byte[] buffer = new byte[1024];
            int length = 0;
            try
            {
                length = FindClientByName(name).Receive(buffer);
            }
            catch { }
            string result = Encoding.Default.GetString(buffer, 0, length);
            if (length > 0)
            {
                Thread th = new Thread(() =>
                {
                    SaveCommLog(result, false);
                    receiveNum++;

                    //添加到历史记录
                    string curTime = DateTime.Now.ToString("HH:mm:ss");
                    L_historyMsg.Add(" " + curTime + "  已接收：" + result);
                    if (L_historyMsg.Count > 200)
                        L_historyMsg.RemoveAt(0);

                    Frm_TCPClient.Instance.Invoke(new Action(() =>
                    {
                        if (Frm_TCPClient.Instance.Visible && Frm_Service.Instance.tvw_serviceList.SelectedNode.Text == name)
                        {
                            if (Frm_TCPClient.Instance.tbx_log.Text != string.Empty)
                                Frm_TCPClient.Instance.tbx_log.AppendText(Environment.NewLine);
                            Frm_TCPClient.Instance.tbx_log.AppendText(" " + curTime + "  已接收：" + result);
                            Frm_TCPClient.Instance.lbl_receiveNum.Text = receiveNum.ToString();

                            if (Frm_TCPClient.Instance.tbx_log.Lines.Length > 200)
                            {
                                Frm_TCPClient.Instance.tbx_log.Clear();
                                for (int i = 150; i < L_historyMsg.Count; i++)
                                {
                                    if (i != 0)
                                        Frm_TCPClient.Instance.tbx_log.AppendText(Environment.NewLine);

                                    Frm_TCPClient.Instance.tbx_log.SelectionStart = Frm_TCPClient.Instance.tbx_log.Text.Length;
                                    Frm_TCPClient.Instance.tbx_log.SelectionLength = 0;
                                    if (L_historyMsg[i].Substring(11, 3) == "已接收")        //收到的消息显示黑色
                                        Frm_TCPClient.Instance.tbx_log.SelectionColor = Color.FromArgb(48, 48, 48);
                                    else
                                        Frm_TCPClient.Instance.tbx_log.SelectionColor = Color.Green;
                                    Frm_TCPClient.Instance.tbx_log.AppendText(L_historyMsg[i]);                     //发送的消息显示绿色
                                }
                            }
                            Frm_TCPClient.Instance.tbx_log.ScrollToCaret();
                        }
                    }));
                    FuncLib.ShowMsg(string.Format("服务端 [ {0} ] 已收到消息：{1}", name, result));

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

                    receivedStr = result;
                });
                th.IsBackground = true;
                th.Start();
            }
            return result;
        }


        /// <summary>
        /// 接收消息
        /// </summary>
        private void Recieve()
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                int length = 0;
                try
                {
                    length = FindClientByName(name).Receive(buffer);
                }
                catch { }
                string result = Encoding.Default.GetString(buffer, 0, length);
                if (length > 0)
                {
                    Thread th = new Thread(() =>
                    {
                        SaveCommLog(result, false);
                        receiveNum++;

                        //添加到历史记录
                        string curTime = DateTime.Now.ToString("HH:mm:ss");
                        L_historyMsg.Add(" " + curTime + "  已接收：" + result);
                        if (L_historyMsg.Count > 200)
                            L_historyMsg.RemoveAt(0);

                        if (Frm_TCPClient.initLoad) //只有在窗体进行初始化过后，才可以使用Invoke，不然的话则会抛出异常
                        {
                            Frm_TCPClient.Instance.Invoke(new Action(() =>
                            {
                                if (Frm_TCPClient.Instance.Visible && Frm_Service.Instance.tvw_serviceList.SelectedNode.Text == name)
                                {
                                    if (Frm_TCPClient.Instance.tbx_log.Text != string.Empty)
                                        Frm_TCPClient.Instance.tbx_log.AppendText(Environment.NewLine);
                                    Frm_TCPClient.Instance.tbx_log.AppendText(" " + curTime + "  已接收：" + result);
                                    Frm_TCPClient.Instance.lbl_receiveNum.Text = receiveNum.ToString();

                                    if (Frm_TCPClient.Instance.tbx_log.Lines.Length > 200)
                                    {
                                        Frm_TCPClient.Instance.tbx_log.Clear();
                                        for (int i = 150; i < L_historyMsg.Count; i++)
                                        {
                                            if (i != 0)
                                                Frm_TCPClient.Instance.tbx_log.AppendText(Environment.NewLine);

                                            Frm_TCPClient.Instance.tbx_log.SelectionStart = Frm_TCPClient.Instance.tbx_log.Text.Length;
                                            Frm_TCPClient.Instance.tbx_log.SelectionLength = 0;
                                            if (L_historyMsg[i].Substring(11, 3) == "已接收")        //收到的消息显示黑色
                                                Frm_TCPClient.Instance.tbx_log.SelectionColor = Color.FromArgb(48, 48, 48);
                                            else
                                                Frm_TCPClient.Instance.tbx_log.SelectionColor = Color.Green;
                                            Frm_TCPClient.Instance.tbx_log.AppendText(L_historyMsg[i]);                     //发送的消息显示绿色
                                        }
                                    }
                                    Frm_TCPClient.Instance.tbx_log.ScrollToCaret();
                                }
                            }));
                        }

                        FuncLib.ShowMsg(string.Format("客户端 [ {0} ] 已收到消息：{1}", name, result));

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

                        receivedStr = result;
                    });
                    th.IsBackground = true;
                    th.Start();

                    VmainCfg.GetClientInfoUpdate(result);
                }
                else
                {
                    if (receiveTimeoutEnable)       //接收超时
                    {
                        FuncLib.ShowMsg(string.Format("客户端 [ {0} ] 接收消息超时，超时时间：{1} ms", name, receiveTimeout), InfoType.Error);
                        FuncLib.ShowMessageBox(string.Format("客户端 [ {0} ] 接收消息超时，超时时间：{1} ms", name, receiveTimeout), InfoType.Error);
                    }
                    else if (!disconnectBySelf)         //我方被动断开连接
                    {
                        if (FindClientByName(name).Connected)
                        {
                            try
                            {
                                FindClientByName(name).Disconnect(false);   //该行偶发抛出异常，先try起来
                            }
                            catch (Exception ex)
                            {
                                FuncLib.ShowMsg("关闭套接字出现异常：" + ex.Message);
                            }
                        }
                        FindClientByName(name).Close();

                        if (Frm_TCPClient.Instance.Visible && Frm_Service.Instance.tvw_serviceList.SelectedNode.Text == name)
                            Frm_TCPClient.Instance.btn_connect.Text = "连接";

                        if (autoConnect)
                        {
                            LoopConnect();
                            FuncLib.ShowMsg(string.Format("客户端 [ {0} ] 连接已中断，远程服务端主动断开，已启动自动重连", name), InfoType.Error);
                            FuncLib.ShowMessageBox(string.Format("客户端 [ {0} ] 连接已中断，远程服务端主动断开，已启动自动重连", name), InfoType.Error);
                        }
                        else
                        {
                            FuncLib.ShowMsg(string.Format("客户端 [ {0} ] 连接已中断，远程服务端主动断开", name), InfoType.Error);
                            FuncLib.ShowMessageBox(string.Format("客户端 [ {0} ] 连接已中断，远程服务端主动断开", name), InfoType.Error);
                        }
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// 回调
        /// </summary>
        /// <param name="asyncresult"></param>
        private static void CallBackMethod(IAsyncResult asyncresult)
        {
            try
            {
                _isConnectSuccessed = false;
                Socket tcpclient = asyncresult.AsyncState as Socket;

                if (tcpclient.Connected == true)
                {
                    tcpclient.EndConnect(asyncresult);
                    _isConnectSuccessed = true;
                }
            }
            catch
            {
                _isConnectSuccessed = false;
            }
            finally
            {
                _timeoutObject.Set();
            }
        }
        /// <summary>
        /// 与服务端断开连接
        /// </summary>
        internal void Disconect()
        {
            if (FindClientByName(name).Connected)
            {
                disconnectBySelf = true;
                FindClientByName(name).Disconnect(false);
            }
            FindClientByName(name).Close();
            FuncLib.ShowMsg(string.Format("客户端 [ {0} ] 已断开其远程服务端", name));
        }

    }
}
