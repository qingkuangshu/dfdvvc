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
    /// 大恒光源控制器
    /// </summary>
    [Serializable]
    internal class Light_DaHeng : LightBase
    {
        internal Light_DaHeng(string m_serviceName)
        {
            serviceName = m_serviceName;
            brand = "大恒";
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
            switch (ch)
            {
                case 1:
                    cmd = "SA" + chBrightness[ch - 1].ToString("0000") + "#";
                    rtn = "A";
                    break;
                case 2:
                    cmd = "SB" + chBrightness[ch - 1].ToString("0000") + "#";
                    rtn = "B";
                    break;
                case 3:
                    cmd = "SC" + chBrightness[ch - 1].ToString("0000") + "#";
                    rtn = "C";
                    break;
                case 4:
                    cmd = "SD" + chBrightness[ch - 1].ToString("0000") + "#";
                    rtn = "D";
                    break;
            }
            FindSerialPortByName(serviceName).WriteLine(cmd);

            if (enableCheck)
            {
                Thread.Sleep(10);
                string result = FindSerialPortByName(serviceName).ReadExisting();
                if (result != string.Empty)
                {
                    if (result == rtn)
                        return true;
                    else
                        return false;
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
            switch (ch)
            {
                case 1:
                    cmd = "SA" + "0000#";
                    rtn = "A";
                    break;
                case 2:
                    cmd = "SB" + "0000#";
                    rtn = "B";
                    break;
                case 3:
                    cmd = "SC" + "0000#";
                    rtn = "C";
                    break;
                case 4:
                    cmd = "SD" + "0000#";
                    rtn = "D";
                    break;
            }
            FindSerialPortByName(serviceName).WriteLine(cmd);

            if (enableCheck)
            {
                Thread.Sleep(10);
                string result = FindSerialPortByName(serviceName).ReadExisting();
                if (result != string.Empty)
                {
                    if (result == rtn)
                        return true;
                    else
                        return false;
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

            string cmd = string.Empty;
            string rtn = string.Empty;
            switch (ch)
            {
                case 1:
                    cmd = "SA" + value.ToString("0000") + "#";
                    rtn = "A";
                    break;
                case 2:
                    cmd = "SB" + value.ToString("0000") + "#";
                    rtn = "B";
                    break;
                case 3:
                    cmd = "SC" + value.ToString("0000") + "#";
                    rtn = "C";
                    break;
                case 4:
                    cmd = "SD" + value.ToString("0000") + "#";
                    rtn = "D";
                    break;
            }
            FindSerialPortByName(serviceName).WriteLine(cmd);

            if (enableCheck)
            {
                Thread.Sleep(10);
                string result = FindSerialPortByName(serviceName).ReadExisting();
                if (result != string.Empty)
                {
                    if (result == rtn)
                        return true;
                    else
                        return false;
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

            string cmd = string.Empty;
            string rtn = string.Empty;
            switch (ch)
            {
                case 1:
                    cmd = "SA#";
                    rtn = "A";
                    break;
                case 2:
                    cmd = "SB#";
                    rtn = "B";
                    break;
                case 3:
                    cmd = "SC#";
                    rtn = "C";
                    break;
                case 4:
                    cmd = "SD#";
                    rtn = "D";
                    break;
            }
            FindSerialPortByName(serviceName).WriteLine(cmd);

            Thread.Sleep(10);
            string result = FindSerialPortByName(serviceName).ReadExisting();
            if (result != string.Empty)
            {
                if (result.Substring(0, 1) == rtn)
                    return Convert.ToInt16(result.Substring(1, 4));
                else
                    return 0;
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

            string cmd = string.Empty;
            string rtn = string.Empty;
            switch (ch)
            {
                case 1:
                    cmd = "SA#";
                    rtn = "A";
                    break;
                case 2:
                    cmd = "SB#";
                    rtn = "B";
                    break;
                case 3:
                    cmd = "SC#";
                    rtn = "C";
                    break;
                case 4:
                    cmd = "SD#";
                    rtn = "D";
                    break;
            }
            FindSerialPortByName(serviceName).WriteLine(cmd);

            Thread.Sleep(10);
            string result = FindSerialPortByName(serviceName).ReadExisting();
            if (result != string.Empty)
            {
                if (result.Substring(0, 1).ToUpper() == rtn)
                {
                    if (Convert.ToInt16(result.Substring(1, 4)) == 0)
                        return false;
                    else
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
