using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Pro
{
    /// <summary>
    /// 光源控制器基类
    /// </summary>
    [Serializable]
    class LightBase
    {
        internal string serviceName = string.Empty;
        /// <summary>
        /// 串口号
        /// </summary>
        internal string portName = "COM1";
        /// <summary>
        /// 波特率
        /// </summary>
        internal int baudRate = 19200;
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
        internal Parity parity = (Parity)Enum.Parse(typeof(Parity), "None");
        /// <summary>  
        /// SerialPort集合  因SerialPort类不能被序列化，所以声明一个静态的集合来存储    键：服务名   值：SerialPort对象
        /// </summary>
        internal static Dictionary<string, SerialPort> L_serialPort = new Dictionary<string, SerialPort>();
        /// <summary>
        /// 各通道名称
        /// </summary>
        internal string[] chName = new string[] { "通道 1：", "通道 2：", "通道 3：", "通道 4：", "通道 5：", "通道 6：", "通道 7：", "通道 8：" };

        /// <summary>
        /// 光源控制器IP
        /// </summary>
        internal string IP = "192.168.0.1";

        /// <summary>
        /// 是否初始化成功
        /// </summary>
        internal bool InitSucceed = false;
        /// <summary>
        /// 品牌
        /// </summary>
        internal string brand = "大恒";
        /// <summary>
        /// 通道数
        /// </summary>
        internal string chNum = "四通道";
        /// <summary>
        /// 控制方式    True：串口     False：以太网
        /// </summary>
        internal bool basedSerialport = true;
        /// <summary>
        /// 八个端口的亮度值
        /// </summary>
        internal int[] chBrightness = new int[] { 200, 200, 200, 200, 200, 200, 200, 200 };
        /// <summary>
        /// 八个通道的开关状态
        /// </summary>
        internal bool[] chState = new bool[8];
        /// <summary>
        /// 是否检验返回值
        /// </summary>
        internal bool enableCheck = true;


        /// <summary>
        /// 初始化控制器
        /// </summary>
        internal virtual bool Open() { return true; }
        /// <summary>
        /// 关闭控制器
        /// </summary>
        internal virtual void Close() { }
        /// <summary>
        /// 打开通道
        /// </summary>
        internal virtual bool OpenCh(int ch) { return true; }
        /// <summary>
        /// 关闭通道
        /// </summary>
        /// <param name="ch">通道索引</param>
        internal virtual bool CloseCh(int ch) { return true; }
        /// <summary>
        /// 设置通道亮度值
        /// </summary>
        /// <param name="ch">通道索引</param>
        /// <param name="value">亮度值</param>
        internal virtual bool SetValue(int ch, int value) { return true; }
        /// <summary>
        /// 获取通道亮度值
        /// </summary>
        /// <param name="ch">通道索引</param>
        /// <returns>亮度值</returns>
        internal virtual int GetValue(int ch) { return 0; }
        /// <summary>
        /// 获取通道开关状态
        /// </summary>
        /// <returns></returns>
        internal virtual bool GetOnOffState(int ch) { return false; }
        /// <summary>
        /// 打开所有通道
        /// </summary>
        internal virtual void OpenAllCh()
        {
            switch (chNum)
            {
                case "双通道":
                    for (int i = 0; i < 2; i++)
                    {
                        OpenCh(i + 1);
                    }
                    break;
                case "四通道":
                    for (int i = 0; i < 4; i++)
                    {
                        OpenCh(i + 1);
                    }
                    break;
                case "六通道":
                    for (int i = 0; i < 6; i++)
                    {
                        OpenCh(i + 1);
                    }
                    break;
                case "八通道":
                    for (int i = 0; i < 8; i++)
                    {
                        OpenCh(i + 1);
                    }
                    break;
            }
        }
        /// <summary>
        /// 关闭所有通道
        /// </summary>
        internal virtual void CloseAllCh()
        {
            switch (chNum)
            {
                case "双通道":
                    for (int i = 0; i < 2; i++)
                    {
                        CloseCh(i + 1);
                    }
                    break;
                case "四通道":
                    for (int i = 0; i < 4; i++)
                    {
                        CloseCh(i + 1);
                    }
                    break;
                case "六通道":
                    for (int i = 0; i < 6; i++)
                    {
                        CloseCh(i + 1);
                    }
                    break;
                case "八通道":
                    for (int i = 0; i < 8; i++)
                    {
                        CloseCh(i + 1);
                    }
                    break;
            }
        }
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
        /// bcc异或校验字
        /// </summary>
        /// <param name="cmdString">所需校验的字符串</param>
        /// <returns>返回的校验位</returns>
        public static string BCC_CRC(string cmdString)
        {
            try
            {
                byte[] asc = Encoding.ASCII.GetBytes(cmdString);


                byte CheckCode = 0;
                int len = asc.Length;
                for (int i = 0; i < len; i++)
                {
                    CheckCode ^= asc[i];
                }
                return Convert.ToString(CheckCode, 16);
            }
            catch
            {
                throw;
            }
        }
    }
}
