using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
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
    ///  串口通讯类
    /// </summary>
    [Serializable]
    internal class Serial : ServiceBase
    {
        internal Serial(string s_name)
        {
            this.name = s_name;
            this.serviceType = ServiceType.SerialPort;

            SerialPort serialPort = new SerialPort();
            L_serialPort.Add(name, serialPort);
        }

        /// <summary>
        /// 串口号
        /// </summary>
        internal string portName = "COM1";
        /// <summary>
        /// 波特率
        /// </summary>
        internal int baudRate = 9600;
        /// <summary>
        /// 数据位
        /// </summary>
        internal int dataBit = 8;
        /// <summary>
        /// 停止位
        /// </summary>
        internal StopBits stopBit = (StopBits)Enum.Parse(typeof(StopBits), "One");
        /// <summary>
        /// 奇偶效验位
        /// </summary>
        internal Parity parity = (Parity)Enum.Parse(typeof(Parity), "Odd");
        /// <summary>  
        /// SerialPort集合  因SerialPort类不能被序列化，所以声明一个静态的集合来存储    键：服务名   值：SerialPort对象
        /// </summary>
        internal static Dictionary<string, SerialPort> L_serialPort = new Dictionary<string, SerialPort>();
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
        /// 通过服务名来查找对应的SerialPort对象
        /// </summary>
        /// <param name="name">SerialPort对象</param>
        /// <returns></returns>
        internal static SerialPort FindSerialPortByName(string name)
        {
            foreach (KeyValuePair<string, SerialPort> item in L_serialPort)
            {
                if (item.Key == name)
                    return item.Value;
            }
            return null;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        internal bool Open()
        {
            if (!FindSerialPortByName(name).IsOpen)
            {
                FindSerialPortByName(name).RtsEnable = false;
                FindSerialPortByName(name).PortName = portName;
                FindSerialPortByName(name).BaudRate = baudRate;
                FindSerialPortByName(name).DataBits = dataBit;
                FindSerialPortByName(name).StopBits = stopBit;
                FindSerialPortByName(name).Parity = parity;
                FindSerialPortByName(name).WriteTimeout = 1000;
                FindSerialPortByName(name).ReadTimeout = 1000;
                try
                {
                    FindSerialPortByName(name).Open();

                    //临时添加
                    //////FindSerialPortByName(name).DataReceived += new SerialDataReceivedEventHandler(SCM_PortReceived);

                    return true;
                }
                catch
                {
                    FuncLib.ShowMsg(string.Format("串口通讯 [ {0} ] 连接失败！串口打开异常，串口号：{1}", name, portName), InfoType.Error);
                    FuncLib.ShowMessageBox(string.Format("串口通讯 [ {0} ] 连接失败！串口打开异常，串口号：{1}", name, portName), InfoType.Error);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        void SCM_PortReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(30);
            try
            {

                byte[] a = new byte[FindSerialPortByName(name).BytesToRead];

                FindSerialPortByName(name).Read(a, 0, a.Length);
                string comReceivedStr = Encoding.ASCII.GetString(a);
                if (comReceivedStr != string.Empty)
                {
                    Project.SaveSysPar();
                }
            }
            catch
            {
                Console.WriteLine("接收失败！");
            }
        }
        /// <summary>
        /// /// 发送命令
        /// </summary>
        /// <param name="cmd">指令内容</param>
        /// <returns></returns>
        internal string Send(string cmd)
        {
            if (!FindSerialPortByName(name).IsOpen)
                return string.Empty;

            FindSerialPortByName(name).DiscardInBuffer();
            FindSerialPortByName(name).DiscardOutBuffer();

            FindSerialPortByName(name).WriteLine(cmd);

            Thread.Sleep(20);
            string result = FindSerialPortByName(name).ReadExisting();
            if (result != string.Empty)
            {
                return result;
            }
            else
            {
                //////FuncLib.ShowMsg(string.Format("串口通讯 [ {0} ] 已发送命令： {1} ！控制器无应答", name, cmd), InfoType.Error);
                //////FuncLib.ShowMessageBox(string.Format("串口通讯 [ {0} ] 打开通道 {1} 失败！控制器无应答", name, cmd), InfoType.Error);
                return string.Empty;
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        internal void Close()
        {
            if (!FindSerialPortByName(name).IsOpen)
                return;

            FindSerialPortByName(name).Close();
        }

    }
}
