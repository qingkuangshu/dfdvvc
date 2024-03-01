/*
 * 用户： INI / TXT 文件保存记录类
 * 日期: 2021/11/12
 * 时间: 15:00
 */

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

namespace VM_Pro
{
    /// <summary>
    /// IniFiles的类
    /// </summary>
    public class IniFiles
    {
        public string FileName; //INI文件名

        #region ini文件

        //声明读写INI文件的API函数
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);

        //类的构造函数，传递INI文件名
        public IniFiles(string AFileName)
        {
            // 判断文件是否存在
            var fileInfo = new FileInfo(AFileName);
            //Todo:搞清枚举的用法

            if ((!fileInfo.Exists))
            {
                //            || (FileAttributes.Directory in fileInfo.Attributes))
                //文件不存在，建立文件
                //            var sw = new StreamWriter(AFileName, false, Encoding.Default);
                try
                {
                    //sw.Write("#表格配置档案");
                    //sw.Close();
                }

                catch
                {
                    throw (new ApplicationException("Ini文件不存在"));
                }
            }
            //必须是完全路径，不能是相对路径
            FileName = fileInfo.FullName;
        }

        //写INI文件
        public void WriteString(string Section, string Key, string Value)
        {
            long ln = WritePrivateProfileString(Section, Key, Value, FileName);

            //         if (!WritePrivateProfileString(Section, Key, Value, FileName))
            //{

            //	throw (new ApplicationException("写Ini文件出错"));
            //}
        }

        //读取INI文件指定
        public string ReadString(string Section, string Key, string Default)
        {
            var Buffer = new Byte[65535];
            int bufLen = GetPrivateProfileString(Section, Key, Default, Buffer, Buffer.GetUpperBound(0), FileName);
            //必须设定0（系统默认的代码页）的编码方式，否则无法支持中文
            string s = Encoding.GetEncoding(0).GetString(Buffer);
            s = s.Substring(0, bufLen);
            if (s == "")
            {
                return s = "0000";
            }
            return s.Trim();

        }

        //读整数
        public int ReadInteger(string Section, string Key, int Default)
        {
            string intStr = ReadString(Section, Key, Convert.ToString(Default));
            try
            {
                return Convert.ToInt32(intStr);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        //写整数
        public void WriteInteger(string Section, string Key, int Value)
        {
            WriteString(Section, Key, Value.ToString());
        }

        //读布尔
        public bool ReadBool(string Section, string Key, bool Default)
        {
            try
            {
                return Convert.ToBoolean(ReadString(Section, Key, Convert.ToString(Default)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        //写Bool
        public void WriteBool(string Section, string Key, bool Value)
        {
            WriteString(Section, Key, Convert.ToString(Value));
        }

        private void GetStringsFromBuffer(Byte[] Buffer, int bufLen, StringCollection Strings)
        {
            Strings.Clear();
            if (bufLen != 0)
            {
                int start = 0;
                for (int i = 0; i < bufLen; i++)
                {
                    if ((Buffer[i] == 0) && ((i - start) > 0))
                    {
                        String s = Encoding.GetEncoding(0).GetString(Buffer, start, i - start);
                        Strings.Add(s);
                        start = i + 1;
                    }
                }
            }
        }


        //从Ini文件中，将指定的Section名称中的所有Key添加到列表中
        public void ReadSection(string Section, StringCollection Keys)
        {
            var Buffer = new Byte[16384];
            //Keys.Clear();

            int bufLen = GetPrivateProfileString(Section, null, null, Buffer, Buffer.GetUpperBound(0),
                                                 FileName);
            //对Section进行解析
            GetStringsFromBuffer(Buffer, bufLen, Keys);
        }

        //从Ini文件中，读取所有的Sections的名称
        public void ReadSections(StringCollection SectionList)
        {
            //Note:必须得用Bytes来实现，StringBuilder只能取到第一个Section
            var Buffer = new byte[65535];
            int bufLen = 0;
            bufLen = GetPrivateProfileString(null, null, null, Buffer,
                                             Buffer.GetUpperBound(0), FileName);
            GetStringsFromBuffer(Buffer, bufLen, SectionList);
        }

        //Note:对于Win9X，来说需要实现UpdateFile方法将缓冲中的数据写入文件
        //在Win NT, 2000和XP上，都是直接写文件，没有缓冲，所以，无须实现UpdateFile
        //执行完对Ini文件的修改之后，应该调用本方法更新缓冲区。
        public void UpdateFile()
        {
            WritePrivateProfileString(null, null, null, FileName);
        }

        //检查某个Section下的某个键值是否存在
        public bool ValueExists(string Section, string Key)
        {
            var Keys = new StringCollection();
            ReadSection(Section, Keys);
            return Keys.IndexOf(Key) > -1;
        }

        //确保资源的释放,析构函数
        ~IniFiles()
        {
            UpdateFile();
        }


        #endregion

        #region txt文件

        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="input"></param>
        public static void WriteLogFile(string input)
        {
            /**/
            ///指定日志文件的目录
            string fname = Directory.GetCurrentDirectory() + "\\程序日志";
            Directory.CreateDirectory(fname);
            fname = Directory.GetCurrentDirectory() + "\\程序日志" + "\\LogFile.txt";
            /**/
            ///定义文件信息对象

            FileInfo finfo = new FileInfo(fname);

            if (!finfo.Exists)
            {
                //FileStream fs;
                //fs = File.Create(fname);
                //fs.Close();
                //finfo = new FileInfo(fname);

                FileStream fs = new FileStream(fname, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(input);
                sw.Close();
            }

            /**/
            ///判断文件是否存在以及是否大于2K
            if (finfo.Length > 1024 * 1024 * 10)
            {
                /**/
                ///文件超过10MB则重命名

                //  File.Move(Directory.GetCurrentDirectory() + "\\LogFile.txt", Directory.GetCurrentDirectory() + DateTime.Now.TimeOfDay + "\\LogFile.txt");
                File.Move(Directory.GetCurrentDirectory() + "\\LogFile.txt", Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "LogFile.txt");

                /**/
                ///删除该文件
                //finfo.Delete();
            }
            //finfo.AppendText();
            /**/
            ///创建只写文件流

            using (FileStream fs = finfo.OpenWrite())
            {
                /**/
                ///根据上面创建的文件流创建写数据流
                StreamWriter w = new StreamWriter(fs);

                /**/
                ///设置写数据流的起始位置为文件流的末尾
                w.BaseStream.Seek(0, SeekOrigin.End);

                /**/
                ///写入当前系统时间并换行
                w.Write("{0} {1} \n\r", DateTime.Now.ToLongDateString(),
                    DateTime.Now.ToLongTimeString());

                /**/
                ///写入日志内容并换行
                w.Write(input + "\n\r");


                /**/
                ///清空缓冲区内容，并把缓冲区内容写入基础流
                w.Flush();

                /**/
                ///关闭写数据流
                w.Close();
            }

        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="input"></param>
        public static void WriteLogException(string input)
        {
            try
            {
                string FileName = DateTime.Now.ToString("yyyyMMdd");
                //////string LogPath = "D:\\参数" + "\\" + FileName + ".txt";
                string WenJianJiaPath = Application.StartupPath + "\\异常日志\\";
                string LogPath = WenJianJiaPath + FileName + ".txt";
                FileInfo fi = new FileInfo(LogPath);
                if (!fi.Exists)
                {
                    Directory.CreateDirectory(WenJianJiaPath);
                }
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                string str = currentTime.ToString() + "  " + input;

                FileStream fs = new FileStream(LogPath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(str);
                sw.Close();//写入
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入文本数据出现异常：" + ex.ToString());
            }
        }

        /// <summary>
        /// 将选择的参数存放到txt文件当中
        /// </summary>
        /// <param name="input">选择的参数字符串</param>
        public static void WriteParamsFile(string input)
        {
            string LogPath = Directory.GetCurrentDirectory() + "\\ParamsFile.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(LogPath))
                {
                    sw.WriteLine(input);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLogException(ex.ToString());
            }
        }
        private static object obtxt = new object();

        /// <summary>
        /// 将程序与Plc的交互写入到日志文件当中
        /// </summary>
        /// <param name="data"></param>
        public static void WritePlcLog(string data)
        {
            try
            {
                string FileName = DateTime.Now.ToString("yyyyMMdd");
                //////string LogPath = "D:\\参数" + "\\" + FileName + ".txt";
                string WenJianJiaPath = "D:\\SoftWareData" + "\\Plc\\";
                string LogPath = WenJianJiaPath + FileName + ".txt";
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                string str = currentTime.ToString() + "  " + data;
                FileInfo fi = new FileInfo(LogPath);
                if (!fi.Exists)
                {
                    Directory.CreateDirectory(WenJianJiaPath);
                }
                FileStream fs = new FileStream(LogPath, FileMode.Append);

                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(str);
                sw.Close();//写入
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入plc交互数据出现异常：" + ex.ToString());
            }

        }

        #endregion

        #region csv



        private static StringBuilder _waitWrite = new StringBuilder();
        /// <summary>
        /// 将数据写入CSV文件当中
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        internal static bool WriteCSV(string str)
        {
            string WenJianPath = string.Format("{0}\\{1}\\Data\\", Project.Instance.configuration.dataPath, DateTime.Now.ToString("yyyy_MM_dd"));
            //string WenJianPath = Application.StartupPath + @"\\点检数据\\" + DateTime.Now.ToString("yyyy-MM");
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
            string path = WenJianPath + "\\" + fileName;
            FileInfo fi = new FileInfo(path);
            if (!fi.Exists)
            {
                Directory.CreateDirectory(WenJianPath);
                StreamWriter st = new StreamWriter(path, true, Encoding.Default);
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i < 100; i++)
                {
                    sb.Append("L" + i + ",");
                }
                st.WriteLine("进站时间,电芯编号,角位,方向,结果,NG原因,层数,检测规格,最小值(mm),最大值(mm),平均值(mm)," + sb.ToString());
                st.Close();
            }
            try
            {
                StreamWriter sw = new StreamWriter(path, true, Encoding.Default);
                if (_waitWrite.ToString().Contains("待"))
                {
                    string[] strs = _waitWrite.ToString().Split('待');
                    for (int i = 0; i < strs.Length-1; i++)
                    {
                        sw.WriteLine(strs[i]);
                    }
                    _waitWrite.Clear();
                }
                sw.WriteLine(str);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                FuncLib.ShowExceptionBox("写入csv文件出错，可能是当前文件被打开，文件关闭后将自动重新写入\r\n" + ex.ToString(), InfoType.Error);
                //MessageBox.Show("写入csv文件出错，可能是当前文件被打开，文件关闭后将自动重新写入：" + ex.ToString());
                _waitWrite.Append(str + "待");
                return false;
            }

        }



        /// <summary>
        /// 读取本地Csv文件
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        internal static string[] ReadCsv(string FileName)
        {
            string csvInfo;
            if (File.Exists(FileName))
            {
                try
                {
                    csvInfo = File.ReadAllText(FileName, Encoding.Default);  //读取文件的所有信息
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.ToString());
                }

                Regex regex = new Regex(@"\r\n");   //获得该文件的所有列名
                string[] infoLines = regex.Split(csvInfo);  //infoLines存储着所有行的数据

                return infoLines;
            }
            else
            {
                throw new ArgumentException("未找到相应的报警文件清单" + FileName);
            }
        }

        #endregion

    }


    /// <summary>
    /// txt文本日志输出类
    /// </summary>
    internal class txtLog
    {

        /// <summary>
        /// 将数据写入到日志文件当中,路径"D:\\SoftWareData" + "\\程序日志\\Debug";
        /// </summary>
        /// <param name="data"></param>
        internal static void Debug(string data)
        {
            try
            {
                string FileName = DateTime.Now.ToString("yyyyMMdd");
                //////string LogPath = "D:\\参数" + "\\" + FileName + ".txt";
                string WenJianJiaPath = "D:\\SoftWareData" + "\\程序日志\\Debug";

                string LogPath = WenJianJiaPath + FileName + ".txt";
                FileInfo fi = new FileInfo(LogPath);
                if (!fi.Exists)
                {
                    Directory.CreateDirectory(WenJianJiaPath);
                }
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                string str = currentTime.ToString() + "  " + data;

                FileStream fs = new FileStream(LogPath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(str);
                sw.Close();//写入
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入文本数据出现异常：" + ex.ToString());
            }
        }


        /// <summary>
        /// 将数据写入到日志文件当中,路径"D:\\SoftWareData" + "\\程序日志\\MES";
        /// </summary>
        /// <param name="data"></param>
        internal static void MES(string shou, string fa)
        {
            try
            {
                string FileName = DateTime.Now.ToString("yyyyMMdd");
                //////string LogPath = "D:\\参数" + "\\" + FileName + ".txt";
                string WenJianJiaPath = "D:\\SoftWareData" + "\\程序日志\\MES\\";
                string LogPath = WenJianJiaPath + FileName + ".txt";
                FileInfo fi = new FileInfo(LogPath);
                if (!fi.Exists)
                {
                    Directory.CreateDirectory(WenJianJiaPath);
                }
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                string str = currentTime.ToString() + "  " + shou + "\r\n" + currentTime.ToString() + "   " + fa;
                FileStream fs = new FileStream(LogPath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(str);
                sw.Close();//写入
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入文本数据出现异常：" + ex.ToString());
            }

        }


        /// <summary>
        /// 将数据写入到日志文件当中,路径"D:\\SoftWareData" + "\\程序日志\\Warn";
        /// </summary>
        /// <param name="data"></param>
        internal static void Warn(string data)
        {
            try
            {
                string FileName = DateTime.Now.ToString("yyyyMMdd");
                //////string LogPath = "D:\\参数" + "\\" + FileName + ".txt";
                string WenJianJiaPath = "D:\\SoftWareData" + "\\程序日志\\Warn";
                string LogPath = WenJianJiaPath + FileName + ".txt";
                FileInfo fi = new FileInfo(LogPath);
                if (!fi.Exists)
                {
                    Directory.CreateDirectory(WenJianJiaPath);
                }
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                string str = currentTime.ToString() + "  " + data;
                FileStream fs = new FileStream(LogPath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(str);
                sw.Close();//写入
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入文本数据出现异常：" + ex.ToString());
            }

        }

        /// <summary>
        /// 将数据写入到日志文件当中,路径"D:\\SoftWareData" + "\\程序日志\\Error";
        /// </summary>
        /// <param name="data"></param>
        internal static void Error(string data)
        {
            try
            {
                string FileName = DateTime.Now.ToString("yyyyMMdd");
                //////string LogPath = "D:\\参数" + "\\" + FileName + ".txt";
                string WenJianJiaPath = "D:\\SoftWareData" + "\\程序日志\\Error";
                string LogPath = WenJianJiaPath + FileName + ".txt";
                FileInfo fi = new FileInfo(LogPath);
                if (!fi.Exists)
                {
                    Directory.CreateDirectory(WenJianJiaPath);
                }
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                string str = currentTime.ToString() + "  " + data;
                FileStream fs = new FileStream(LogPath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(str);
                sw.Close();//写入
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入文本数据出现异常：" + ex.ToString());
            }

        }

        /// <summary>
        /// 在指定目录下，删除30天前的文件. 异常：Exception
        /// </summary>
        internal static void Del30DayFiles()
        {
            try
            {
                //文件夹路径
                string strFolderPath = "D:\\SoftWareData" + "\\PlcBaoJing\\";
                DirectoryInfo dyInfo = new DirectoryInfo(strFolderPath);
                //获取文件夹下所有的文件
                foreach (FileInfo feInfo in dyInfo.GetFiles())
                {
                    //判断文件日期最后一次写入的时间是否为30天前，是则删除
                    //DateTime dt = DateTime.Today.AddDays(-30);
                    if (feInfo.CreationTime < DateTime.Today.AddDays(-30))
                        feInfo.Delete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }
}
