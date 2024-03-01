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
using System.IO.Ports;

namespace VM_Pro
{
    /// <summary>
    /// 光源控制类
    /// </summary>
    [Serializable]
    internal class LightService : ServiceBase
    {
        internal LightService(string s_name)
        {
            this.name = s_name;
            this.serviceType = ServiceType.Light;

            lightBase = new Light_DaHeng(s_name);
            LightBase.L_serialPort.Add(s_name, new SerialPort());
        }

        /// <summary>
        /// 光源控制器对象
        /// </summary>
        internal LightBase lightBase;


        /// <summary>
        /// 是否已连接
        /// </summary>
        internal bool Connected
        {
            get
            {
                if (lightBase.basedSerialport)
                    return LightBase.FindSerialPortByName(name).IsOpen;
                else
                    return true;
            }
        }

    }
}
