using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows;

namespace VM_Pro
{
    /// <summary>
    /// 注册类  
    /// </summary>
    internal class Regiest
    {

        /// <summary>
        /// 是否已激活
        /// </summary>
        internal static bool regiested = false;
        /// <summary>
        /// 存储密钥
        /// </summary>
        private static int[] intCode = new int[127];
        /// <summary>
        /// 存机器码的Ascii值
        /// </summary>
        private static int[] intNumber = new int[25];
        /// <summary>
        /// 存储机器码字
        /// </summary>
        private static char[] Charcode = new char[25];


        /// <summary>
        /// 获取硬盘序列号
        /// </summary>
        /// <returns></returns>
        private static string GetDiskSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }
        /// <summary>
        /// 获取CPU序列号
        /// </summary>
        /// <returns></returns>
        private static string GetCpuSerialNumber()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }
        /// <summary>
        /// 获取本机序列号
        /// </summary>
        /// <returns></returns>
        internal static string GetMachineCode()
        {
            string strNum = GetCpuSerialNumber() + GetDiskSerialNumber();
            string strMNum = strNum.Substring(0, 24);
            return strMNum;
        }
        /// <summary>
        /// 获取本机注册码
        /// </summary>
        /// <returns>注册码</returns>
        internal static string GetRegiestCode()
        {
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i % 9;
            }

            string MNum = GetMachineCode();
            for (int i = 1; i < Charcode.Length; i++)
            {
                Charcode[i] = Convert.ToChar(MNum.Substring(i - 1, 1));
            }
            for (int j = 1; j < intNumber.Length; j++)
            {
                intNumber[j] = intCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);
            }
            string strAsciiName = "";
            for (int j = 1; j < intNumber.Length; j++)
            {
                if (intNumber[j] >= 48 && intNumber[j] <= 57)
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 65 && intNumber[j] <= 90)
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 97 && intNumber[j] <= 122)
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else
                {
                    if (intNumber[j] > 122)
                    {
                        strAsciiName += Convert.ToChar(intNumber[j] - 10).ToString();
                    }
                    else
                    {
                        strAsciiName += Convert.ToChar(intNumber[j] - 9).ToString();
                    }
                }
            }
            return strAsciiName;
        }
        /// <summary>
        /// 根据机器码生成注册码
        /// </summary>
        /// <param name="machineCode">机器码</param>
        /// <returns>注册码</returns>
        internal static string GetRegiestCodeByMachineCode(string machineCode)
        {
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i % 9;
            }

            string MNum = machineCode;
            for (int i = 1; i < Charcode.Length; i++)
            {
                Charcode[i] = Convert.ToChar(MNum.Substring(i - 1, 1));
            }
            for (int j = 1; j < intNumber.Length; j++)
            {
                intNumber[j] = intCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);
            }
            string strAsciiName = "";
            for (int j = 1; j < intNumber.Length; j++)
            {
                if (intNumber[j] >= 48 && intNumber[j] <= 57)
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 65 && intNumber[j] <= 90)
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 97 && intNumber[j] <= 122)
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else
                {
                    if (intNumber[j] > 122)
                    {
                        strAsciiName += Convert.ToChar(intNumber[j] - 10).ToString();
                    }
                    else
                    {
                        strAsciiName += Convert.ToChar(intNumber[j] - 9).ToString();
                    }
                }
            }
            return strAsciiName;
        }

    }
}
