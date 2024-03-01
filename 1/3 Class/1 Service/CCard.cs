using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    /// <summary>
    /// 运动控制卡
    /// </summary>
    [Serializable]
    internal class CCard : ServiceBase
    {
        internal CCard(string s_name)
        {
            this.name = s_name;
            this.serviceType = ServiceType.Card;

            cardBase = new Card_DMC1000B();
        }


        /// <summary>
        /// 板卡对象
        /// </summary>
        internal CardBase cardBase;


        /// <summary>
        /// 是否已连接
        /// </summary>
        internal bool Connected
        {
            get
            {
                return cardBase.connected;
            }
        }


    }
}
