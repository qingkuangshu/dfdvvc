using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VM_Pro
{
    /// <summary>
    /// 大恒UV光源控制器
    /// </summary>
    [Serializable]
    internal class Light_DaHengUV : LightBase
    {
        internal Light_DaHengUV(string m_serviceName)
        {
            serviceName = m_serviceName;
            brand = "大恒UV";
        }

        /// <summary>
        /// 初始化
        /// </summary>
        internal override bool Open()
        {
            if (basedSerialport)        //串口通讯
            {
                if (!FindSerialPortByName(serviceName).IsOpen)
                {
                    InitSucceed = false;
                    FindSerialPortByName(serviceName).RtsEnable = false;
                    FindSerialPortByName(serviceName).PortName = portName;
                    FindSerialPortByName(serviceName).BaudRate = baudRate;
                    FindSerialPortByName(serviceName).DataBits = dataBit;
                    FindSerialPortByName(serviceName).StopBits = stopBit;
                    FindSerialPortByName(serviceName).Parity = parity;
                    FindSerialPortByName(serviceName).WriteTimeout = 1000;
                    FindSerialPortByName(serviceName).ReadTimeout = 1000;
                    try
                    {
                        FindSerialPortByName(serviceName).Open();
                        InitSucceed = true;
                        return true;
                    }
                    catch
                    {
                        FuncLib.ShowMsg(string.Format("光源控制器 [ {0} ] 连接失败！串口打开异常，串口号：{1}", serviceName, portName), InfoType.Error);
                        FuncLib.ShowMessageBox(string.Format("光源控制器 [ {0} ] 连接失败！串口打开异常，串口号：{1}", serviceName, portName), InfoType.Error);
                        return false;
                    }
                }
                else
                {
                    InitSucceed = true;
                    return true;
                }
            }
            else                        //以太网通讯
            {

                return true;
            }
        }
        /// <summary>
        /// 打开通道
        /// </summary>
        /// <param name="ch">通道索引</param>
        internal override bool OpenCh(int ch)
        {
            if (!InitSucceed)
                return false;

            if (!FindSerialPortByName(serviceName).IsOpen)
            {
                InitSucceed = false;
                return false;
            }

            FindSerialPortByName(serviceName).DiscardInBuffer();
            FindSerialPortByName(serviceName).DiscardOutBuffer();

            string cmd = string.Empty;
            string rtn = string.Empty;
            if (ch == 1)
                cmd = "$1120016";
            else
                cmd = "$1220015";

            FindSerialPortByName(serviceName).Write(cmd);

            if (enableCheck)
            {
                Thread.Sleep(60);
                byte[] buffer = new byte[FindSerialPortByName(serviceName).BytesToRead];
                FindSerialPortByName(serviceName).Read(buffer, 0, buffer.Length);
                if (buffer.Length > 0)
                {
                    return true;
                }
                else
                {
                    FuncLib.ShowMsg(string.Format("光源控制器 [ {0} ] 打开通道 {1} 失败！控制器无应答", serviceName, ch), InfoType.Error);
                    FuncLib.ShowMessageBox(string.Format("光源控制器 [ {0} ] 打开通道 {1} 失败！控制器无应答", serviceName, ch), InfoType.Error);
                    return false; 
                } 
            } 
            else 
            {
                return true; 
            }
        }
        /// <summary>
        /// 关闭通道
        /// </summary>
        /// <param name="ch">通道索引</param>
        internal override bool CloseCh(int ch)
        {
            if (!InitSucceed)
                return false;

            if (!FindSerialPortByName(serviceName).IsOpen)
            {
                InitSucceed = false;
                return false;
            }

            FindSerialPortByName(serviceName).DiscardInBuffer();
            FindSerialPortByName(serviceName).DiscardOutBuffer();

            string cmd = string.Empty;
            string rtn = string.Empty;
            if (ch == 1)
                cmd = "$2120015";
            else
                cmd = "$2220016";

            FindSerialPortByName(serviceName).WriteLine(cmd);

            if (enableCheck)
            {
                Thread.Sleep(60);
                byte[] buffer = new byte[FindSerialPortByName(serviceName).BytesToRead];
                FindSerialPortByName(serviceName).Read(buffer, 0, buffer.Length);
                if (buffer.Length > 0)
                {
                    return true;
                }
                else
                {
                    FuncLib.ShowMsg(string.Format("光源控制器 [ {0} ] 关闭通道 {1} 失败！控制器无应答", serviceName, ch), InfoType.Error);
                    FuncLib.ShowMessageBox(string.Format("光源控制器 [ {0} ] 关闭通道 {1} 失败！控制器无应答", serviceName, ch), InfoType.Error);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 设置通道亮度值
        /// </summary>
        /// <param name="ch">通道索引</param>
        /// <param name="value">亮度值</param>
        internal override bool SetValue(int ch, int value)
        {
            chBrightness[ch - 1] = value;
            if (!InitSucceed)
                return false;

            if (!FindSerialPortByName(serviceName).IsOpen)
            {
                InitSucceed = false;
                return false;
            }

            FindSerialPortByName(serviceName).DiscardInBuffer();
            FindSerialPortByName(serviceName).DiscardOutBuffer();

            string rtn = string.Empty;
            string str1 = "400501001A0" + (ch - 1);
            string str2 = Convert.ToString(value, 16);
            if (str2.Length == 1)
            {
                str2 = "0" + str2;
            }
            string str3 = "6" + (ch - 1);
            int Start = 95 + ch;
            string str4 = Convert.ToString(Start + value, 16);
            if (str4.Length == 3)
            {
                str4 = str4.Substring(1);
            }
            string actionStr = (str1 + str2 + str4).ToUpper();

            string ReceiveData = string.Empty;
            byte[] buffer = new byte[8];
            int length = (actionStr.Length - actionStr.Length % 2) / 2;
            for (int i = 0; i < length; i++)
            {
                buffer[i] = Convert.ToByte(actionStr.Substring(i * 2, 2), 16);
            }

            FindSerialPortByName(serviceName).Write(buffer, 0, length);

            if (enableCheck)
            {
                Thread.Sleep(60);

                buffer = new byte[FindSerialPortByName(serviceName).BytesToRead];
                FindSerialPortByName(serviceName).Read(buffer, 0, buffer.Length);
                string result = string.Empty;
                for (int i = 0; i < buffer.Length; i++)//逐字节变为16进制字符串
                {
                    result += Convert.ToString(buffer[i], 16).PadLeft(2, '0');
                }
                ReceiveData = result.ToUpper();

                if (ReceiveData == "400301000044")
                {
                    return true;
                }
                else
                {
                    FuncLib.ShowMsg(string.Format("光源控制器 [ {0} ] 设置通道 {1} 亮度失败！控制器无应答", serviceName, ch), InfoType.Error);
                    FuncLib.ShowMessageBox(string.Format("光源控制器 [ {0} ] 设置通道 {1} 亮度失败！控制器无应答", serviceName, ch), InfoType.Error);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 获取通道亮度值
        /// </summary>
        /// <param name="ch">通道索引</param>
        /// <returns>亮度值</returns>
        internal override int GetValue(int ch)
        {
            if (!InitSucceed)
                return chBrightness[ch];

            if (!FindSerialPortByName(serviceName).IsOpen)
            {
                InitSucceed = false;
                return 0;
            }

            FindSerialPortByName(serviceName).DiscardInBuffer();
            FindSerialPortByName(serviceName).DiscardOutBuffer();

            string cmd = "40040100310" + (ch - 1) + "7" + (ch + 5);
            string ReceiveData = string.Empty;
            byte[] temp = new byte[8];
            int length = (cmd.Length - cmd.Length % 2) / 2;
            for (int i = 0; i < length; i++)
            {
                temp[i] = Convert.ToByte(cmd.Substring(i * 2, 2), 16);
            }

            FindSerialPortByName(serviceName).Write(temp, 0, length);

            Thread.Sleep(60);
            byte[] buffer = new byte[FindSerialPortByName(serviceName).BytesToRead];
            FindSerialPortByName(serviceName).Read(buffer, 0, buffer.Length);
            string result = string.Empty;
            for (int i = 0; i < buffer.Length; i++)//逐字节变为16进制字符串
            {
                result += Convert.ToString(buffer[i], 16).PadLeft(2, '0');
            }
            ReceiveData = result.ToUpper();

            if (ReceiveData.Contains("400601005B"))
            {
                int value = Convert.ToInt32(ReceiveData.Substring(10, 2), 16);
                return value;
            }
            else
            {
                FuncLib.ShowMsg(string.Format("光源控制器 [ {0} ] 获取通道 {1} 亮度失败！控制器无应答", serviceName, ch), InfoType.Error);
                FuncLib.ShowMessageBox(string.Format("光源控制器 [ {0} ] 获取通道 {1} 亮度失败！控制器无应答", serviceName, ch), InfoType.Error);
                return 0;
            }
        }
        /// <summary>
        /// 获取通道开关状态
        /// </summary>
        /// <param name="ch">通道索引</param>
        /// <returns>亮度值</returns>
        internal override bool GetOnOffState(int ch)
        {
            if (!InitSucceed)
                return false;

            if (!FindSerialPortByName(serviceName).IsOpen)
            {
                InitSucceed = false;
                return false;
            }

            FindSerialPortByName(serviceName).DiscardInBuffer();
            FindSerialPortByName(serviceName).DiscardOutBuffer();

            string rtn = string.Empty;
            string cmd = "40040100310" + (ch - 1) + "7" + (ch + 5);


            string ReceiveData = string.Empty;
            byte[] temp = new byte[8];
            int length = (cmd.Length - cmd.Length % 2) / 2;
            for (int i = 0; i < length; i++)
            {
                temp[i] = Convert.ToByte(cmd.Substring(i * 2, 2), 16);
            }
            FindSerialPortByName(serviceName).Write(temp, 0, length);

            Thread.Sleep(60);
            byte[] a = new byte[FindSerialPortByName(serviceName).BytesToRead];
            FindSerialPortByName(serviceName).Read(a, 0, a.Length);
            string result = string.Empty;
            for (int i = 0; i < a.Length; i++)//逐字节变为16进制字符串
            {
                result += Convert.ToString(a[i], 16).PadLeft(2, '0');
            }
            ReceiveData = result.ToUpper();

            if (ReceiveData.Contains("400601005B") && ReceiveData.Length == 18)
            {
                string value = ReceiveData.Substring(14, 4);
                if (value.ToUpper() == "01A2")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                FuncLib.ShowMsg(string.Format("光源控制器 [ {0} ] 获取通道 {1} 开关状态失败！控制器无应答", serviceName, ch), InfoType.Error);
                FuncLib.ShowMessageBox(string.Format("光源控制器 [ {0} ] 获取通道 {1} 开关状态失败！控制器无应答", serviceName, ch), InfoType.Error);
                return false;
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        internal override void Close()
        {
            if (!InitSucceed)
                return;

            FindSerialPortByName(serviceName).Close();
        }

    }
}
