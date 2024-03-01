using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VM_Pro
{
    /// <summary>
    /// FTP文件下载类
    /// </summary>
    [Serializable]
    internal class FTPDownload : ServiceBase
    {
        internal FTPDownload(string s_name)
        {
            this.name = s_name;
            this.serviceType = ServiceType.FTPDownload;
            FtpWebRequest fre = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAddress));
        }
        /// <summary>
        /// FTP登录的用户名
        /// </summary>
        internal string ftpUser = "test";
        /// <summary>
        /// FTP登录的密码
        /// </summary>
        internal string ftpPassword = "";
        /// <summary>
        /// FTP地址
        /// </summary>
        internal string ftpAddress = "ftp://10.201.88.151";
        /// <summary>
        /// FTP监测的路径
        /// </summary>
        internal string ftpFatherPath = "web/CT-TEST";

        /// <summary>
        /// FTP监测路径是否增加时间文件夹
        /// </summary>
        internal bool isAddTime = true;

        /// <summary>
        /// FTP监测路径增加时间文件夹的格式
        /// </summary>
        internal string addTimeFormat = "yyyyMMdd";
        /// <summary>
        /// 本地下载的路径
        /// </summary>
        internal string localSavePath = "D:\\FTPTEST\\CT-Receive";
        /// <summary>
        /// 是否开启监测
        /// </summary>
        internal bool isStartCheck = true;
        /// <summary>
        /// 图像下载完成后，是否执行任务流程
        /// </summary>
        internal bool isDownloadCompletedRunTask = false;
        /// <summary>
        /// 执行任务的名称
        /// </summary>
        internal string RunTaskName = "";
        private bool _isConnect;
        /// <summary>
        /// 是否连接
        /// </summary>
        internal bool IsConnect
        {
            get
            {
                if (!_isConnect)
                {
                    try
                    {
                        FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAddress + "/" + ftpFatherPath));
                        request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                        request.Method = WebRequestMethods.Ftp.ListDirectory.Trim();
                        request.UseBinary = true;
                        request.UsePassive = true;
                        request.Timeout = 500;
                        using (var response = (FtpWebResponse)request.GetResponse()) { }
                        _isConnect = true;
                    }
                    catch (Exception)
                    {
                        _isConnect = false;
                    }
                }

                return _isConnect;
            }

        }
        /// <summary>
        /// 异常信息
        /// </summary>
        private string _errorMsg = "";


        internal void CheckFTPPath()
        {
            bool isDownloading = false; //是否正在下载中
            while (isStartCheck)
            {
                if (!isDownloading)
                {
                    try
                    {
                        string ftpCheckPath = ""; //ftp扫描的文件夹路径
                        if (isAddTime)
                        {
                            ftpCheckPath = ftpFatherPath + "/" + DateTime.Now.ToString(addTimeFormat);
                        }
                        else
                        {
                            ftpCheckPath = ftpFatherPath;
                        }
                        string[] list = GetAllList(ftpCheckPath + "/", "0");
                        string[] markList = list.Where(t => t.EndsWith("mark")).ToArray();
                        foreach (var v in markList)
                        {
                            string[] vs = v.Split('?');
                            if (vs.Length == 3)
                            {
                                isDownloading = true;
                                string newFilePath = ftpCheckPath + "/" + vs[0] + "/" + vs[1];
                                string[] pictureList = GetFilleList(newFilePath + "/", "0");
                                string dwonloadLocalPath = "";
                                if (isAddTime)
                                {
                                    dwonloadLocalPath = localSavePath + "//" + DateTime.Now.ToString(addTimeFormat) + "//" + vs[1];
                                }
                                else
                                {
                                    dwonloadLocalPath = localSavePath + "//" + DateTime.Now.ToString(addTimeFormat) + "//" + vs[1];
                                }

                                foreach (var i in pictureList)
                                {
                                    DownLoad(dwonloadLocalPath, newFilePath, i);
                                }
                                try
                                {
                                    ((ImageTool)(Task.FindTaskByName(RunTaskName).FindToolByName("采集图像"))).GetDirImgList(dwonloadLocalPath);
                                    ((ImageTool)(Task.FindTaskByName(RunTaskName).FindToolByName("采集图像"))).imageDirectoryPath= dwonloadLocalPath;
                                    ((ImageTool)(Task.FindTaskByName(RunTaskName).FindToolByName("采集图像"))).imageSource = ImageSource.FromDirectory;

                                    bool isRunTask = true;
                                    while (isRunTask)
                                    {
                                        Task.curTask.Run();

                                        //文件夹图像执行一遍后停止循环
                                        for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
                                        {
                                            if (Task.curTask.L_toolList[i].toolType == ToolType.采集图像)
                                            {
                                                if (((ImageTool)Task.curTask.L_toolList[i]).imageSource == ImageSource.FromDirectory)
                                                {
                                                    if (((ImageTool)Task.curTask.L_toolList[i]).currentImageIndex == ((ImageTool)Task.curTask.L_toolList[i]).L_imagePath.Count - 1)
                                                    {
                                                        isRunTask = false;
                                                        break;
                                                    }
                                                }
                                            }
                                        }

                                        Thread.Sleep(Project.Instance.configuration.taskRunSpan);
                                    }













                                    if (DeleteDir(ftpCheckPath + "/" + v))
                                    {
                                        //删除成功
                                    }
                                    else
                                    {
                                        //删除失败
                                    }
                                }
                                catch (Exception ex)
                                {

                                    throw;
                                }


                            }
                        }
                        isDownloading = false;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message != _errorMsg)
                        {
                            _errorMsg = ex.Message;
                            if (ex.Message.Contains("(550) 文件不可用"))
                            {
                                FuncLib.ShowMessageBox("当前FTP路径不存在或无访问权限", InfoType.Error);
                            }
                            else
                            {
                                FuncLib.ShowMessageBox("FTP下载出现异常：" + ex.Message, InfoType.Error);
                            }
                        }

                    }
                }
                Thread.Sleep(500);

            }
        }

        /// <summary>
        /// 获取当前目录下所有文件（包括文件夹）名字
        /// </summary>
        /// <param name="url"></param>
        /// <param name="isUseSsl"></param>
        /// <returns></returns>
        public string[] GetAllList(string url, string isUseSsl)
        {
            List<string> list = new List<string>();
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAddress + "/" + url));
            request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.UseBinary = true;
            request.UsePassive = true;
            if (isUseSsl == "1")
            {
                // 下面4行代码用于支持显示SSL（explicit SSL），.NET2.0中的FtpWebRequest不支持
                //隐式SSL（implicit SSL）。如果不用SSL，注释掉它们即可。

                request.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback =
                              delegate (Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                              { return true; };
            }

            try
            {
                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    using (StreamReader readStream = new StreamReader(response.GetResponseStream()))
                    {
                        string s;
                        while ((s = readStream.ReadLine()) != null)
                        {
                            list.Add(s);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return list.ToArray();
        }

        /// <summary>
        /// 获取所有带“tif”的文件名
        /// </summary>
        /// <param name="url"></param>
        /// <param name="isUseSsl"></param>
        /// <returns></returns>
        public string[] GetFilleList(string url, string isUseSsl)
        {
            try
            {
                StringBuilder list = new StringBuilder();
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAddress + "/" + url));
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                if (isUseSsl == "1")
                {
                    // 下面4行代码用于支持显示SSL（explicit SSL），.NET2.0中的FtpWebRequest不支持
                    //隐式SSL（implicit SSL）。如果不用SSL，注释掉它们即可。

                    request.EnableSsl = true;
                    ServicePointManager.ServerCertificateValidationCallback =
                                  delegate (Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                                  { return true; };
                }

                try
                {
                    using (var response = (FtpWebResponse)request.GetResponse())
                    {
                        using (StreamReader readStream = new StreamReader(response.GetResponseStream()))
                        {
                            string line = readStream.ReadLine();
                            while (line != null)
                            {
                                if (line.IndexOf("DTR") == -1)
                                {
                                    string[] parts = line.Split(' ');
                                    list.Append(parts.First(t => t.Contains("tif")));
                                    list.Append("\n");
                                }
                                line = readStream.ReadLine();
                            }
                            list.Remove(list.ToString().LastIndexOf('\n'), 1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return list.ToString().Split('\n');

            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 从ftp下载文件
        /// </summary>
        /// <param name="filePath"></param>下载到本地的路径
        /// <param name="fileName"></param>保存的文件路径
        /// <param name="localName"></param>下载的文件名称
        public void DownLoad(string filePath, string fileName, string localName)
        {
            try
            {
                //string localPath = Path.Combine(filePath, fileName);
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string newFileName = Path.Combine(filePath, localName);

                using (FileStream outputStream = new FileStream(newFileName, FileMode.Create))
                {
                    FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAddress + "/" + fileName + "/" + localName));
                    request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    request.UseBinary = true;
                    using (var response = (FtpWebResponse)request.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            long length = response.ContentLength;
                            int bufferSize = 2048;
                            int readCount;
                            byte[] buffer = new byte[bufferSize];
                            readCount = stream.Read(buffer, 0, bufferSize);
                            while (readCount > 0)
                            {
                                outputStream.Write(buffer, 0, readCount);
                                readCount = stream.Read(buffer, 0, bufferSize);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// 删除该路径的文件夹
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public bool DeleteDir(string dir)
        {
            bool result = false;
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAddress + "/" + dir));
                request.Method = WebRequestMethods.Ftp.RemoveDirectory;
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

                result = false;
            }
            return result;
        }
    }
}
