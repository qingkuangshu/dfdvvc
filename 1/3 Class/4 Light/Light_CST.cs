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
    /// 康视达光源控制器
    /// </summary>
    [Serializable]
    internal class Light_CST : LightBase
    {
        internal Light_CST(string m_serviceName)
        {
            serviceName = m_serviceName;
            brand = "康视达";
        }

        /// <summary>
        /// 控制器对象
        /// </summary>
        private CSTControllerAPI mController = null;


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
                    try
                    {
                        int testbuf = 0;
                        mController = new CSTControllerAPI();
                        testbuf = mController.CreateSerialPort(Convert.ToInt16(portName.Substring(3, 1)));

                        if (testbuf == 10000)
                        {
                            InitSucceed = true;
                            return true;
                        }
                        else
                        {
                            FuncLib.ShowMsg(string.Format("光源控制器 [ {0} ] 连接失败！串口打开异常，串口号：{1}", serviceName, portName), InfoType.Error);
                            FuncLib.ShowMessageBox(string.Format("光源控制器 [ {0} ] 连接失败！串口打开异常，串口号：{1}", serviceName, portName), InfoType.Error);
                            return false;
                        }
                    }
                    catch (Exception ex)
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

            int testbuf = 0;
            testbuf = mController.SetDigitalValue(ch, chBrightness[ch - 1]);

            if (enableCheck)
            {
                if (testbuf == 10008)
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
        /// 关闭通道
        /// </summary>
        /// <param name="ch">通道索引</param>
        internal override bool CloseCh(int ch)
        {
            if (!InitSucceed)
                return false;

            int testbuf = 0;
            testbuf = mController.SetDigitalValue(ch, 0);

            if (enableCheck)
            {
                if (testbuf == 10008)
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
        /// 设置通道亮度值
        /// </summary>
        /// <param name="ch">通道索引</param>
        /// <param name="value">亮度值</param>
        internal override bool SetValue(int ch, int value)
        {
            chBrightness[ch - 1] = value;
            if (!InitSucceed)
                return false;

            int testbuf = 0;
            testbuf = mController.SetDigitalValue(ch, value);

            if (enableCheck)
            {
                if (testbuf == 10008)
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

            int value = chBrightness[ch];
            int result = mController.GetDigitalValue(ch, ref value);
            if (result != -1)
            {
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

            int value = GetValue(ch);
            if (value == 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        internal override void Close()
        {
            if (!InitSucceed)
                return;

            mController.ReleaseSerialPort();
        }

    }
}
