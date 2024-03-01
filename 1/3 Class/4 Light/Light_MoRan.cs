using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VM_Pro
{
    //by：风云
    //*************注意事项************
    //1.默然光源的默认波特率是：38400
    //2.当前该类的延迟不可过低，发现频率过快的话会反应不过来
    //3.当前只支持248常亮光源控制器

    /// <summary>
    /// 默然光源控制
    /// </summary>
    [Serializable]
    internal class Light_MoRan : LightBase
    {
        internal Light_MoRan(string m_serviceName)
        {
            serviceName = m_serviceName;
            brand = "默然248";
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

            string cmd = "#1"+ch+"064";
            cmd += LightBase.BCC_CRC(cmd);
            string rtn = "#";

            FindSerialPortByName(serviceName).WriteLine(cmd);
            Thread.Sleep(50);

            if (enableCheck)
            {
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

            string cmd = "#2"+ch+"029";
            cmd += LightBase.BCC_CRC(cmd).ToUpper();
            string rtn = "#";

            FindSerialPortByName(serviceName).WriteLine(cmd);
            Thread.Sleep(50);

            if (enableCheck)
            {
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
            string ss = Convert.ToString(value, 16).ToUpper();
            //ss = Convert.ToInt32(ss).ToString("000");
            if (ss.Length == 2)
                ss = "0" + ss;
            else
                ss = "00" + ss;
            string cmd = "#3" + ch + ss;
            cmd += LightBase.BCC_CRC(cmd).ToUpper();
            string rtn = "#";




            FindSerialPortByName(serviceName).WriteLine(cmd);
            Thread.Sleep(50);

            if (enableCheck)
            {
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

            string cmd = "#4"+ch+"064";
            cmd += LightBase.BCC_CRC(cmd);
            string rtn = "#4";

            FindSerialPortByName(serviceName).WriteLine(cmd);

            Thread.Sleep(30);
            string result = FindSerialPortByName(serviceName).ReadExisting();
            if (result != string.Empty)
            {
                if (result.Substring(0, 2) == rtn)
                    return Convert.ToInt16(result.Substring(2, 3));
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

        ///// <summary>
        ///// 获取通道开关状态
        ///// </summary>
        ///// <param name="ch">通道索引</param>
        ///// <returns>亮度值</returns>
        //internal override bool GetOnOffState(int ch)
        //{
        //    if (!InitSucceed)
        //        return false;

        //    if (!FindSerialPortByName(serviceName).IsOpen)
        //    {
        //        InitSucceed = false;
        //        return false;
        //    }

        //    FindSerialPortByName(serviceName).DiscardInBuffer();
        //    FindSerialPortByName(serviceName).DiscardOutBuffer();

        //    string cmd = string.Empty;
        //    string rtn = string.Empty;
        //    switch (ch)
        //    {
        //        case 1:
        //            cmd = "SA#";
        //            rtn = "A";
        //            break;
        //        case 2:
        //            cmd = "SB#";
        //            rtn = "B";
        //            break;
        //        case 3:
        //            cmd = "SC#";
        //            rtn = "C";
        //            break;
        //        case 4:
        //            cmd = "SD#";
        //            rtn = "D";
        //            break;
        //    }
        //    FindSerialPortByName(serviceName).WriteLine(cmd);

        //    Thread.Sleep(10);
        //    string result = FindSerialPortByName(serviceName).ReadExisting();
        //    if (result != string.Empty)
        //    {
        //        if (result.Substring(0, 1).ToUpper() == rtn)
        //        {
        //            if (Convert.ToInt16(result.Substring(1, 4)) == 0)
        //                return false;
        //            else
        //                return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        FuncLib.ShowMsg(string.Format("光源控制器 [ {0} ] 获取通道 {1} 开关状态失败！控制器无应答", serviceName, ch), InfoType.Error);
        //        FuncLib.ShowMessageBox(string.Format("光源控制器 [ {0} ] 获取通道 {1} 开关状态失败！控制器无应答", serviceName, ch), InfoType.Error);
        //        return false;
        //    }
        //}
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
