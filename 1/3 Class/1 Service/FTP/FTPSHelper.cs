using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace VM_Pro
{
    public class FTPSHelper
    {
        private string ftpUser = string.Empty;
        private string ftpPassword = string.Empty;
        private string ftpUri = string.Empty;
        public FTPSHelper(string user, string passWord, string uri)
        {
            this.ftpUser = user;
            this.ftpPassword = passWord;
            this.ftpUri = uri;
        }
        private static int sleepTime;
        private static int bytenum;
        public static string sudu
        {
            set
            {
                if (value == "1Mbps")
                {
                    sleepTime = 1;
                    bytenum = 2048;
                }
                else if (value == "2Mbps")
                {
                    sleepTime = 1;
                    bytenum = 4096;
                }
                else if (value == "4Mbps")
                {
                    sleepTime = 1;
                    bytenum = 8092;
                }
                else if (value == "8Mbps")
                {
                    sleepTime = 1;
                    bytenum = 16184;
                }
                else if (value == "16Mbps")
                {
                    sleepTime = 0;
                    bytenum = 2048;
                }

            }
        }

        public string FtpFileUploadAsync(string fileFullName, out string useTime, string uri, string isUseSsl)
        {
            string ret = "failed";
            try
            {
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                byte[] data = File.ReadAllBytes(fileFullName);
                FileInfo fi = new FileInfo(fileFullName);
                Uri serverUri = new Uri(this.ftpUri + "/" + uri);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri + "/" + fi.Name);
                request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.KeepAlive = false;
                request.Proxy = null;
                request.UseBinary = true;
                request.Timeout = 60000;
                request.ContentLength = data.Length;
                // 下面4行代码用于支持显示SSL（explicit SSL），.NET2.0中的FtpWebRequest不支持
                //隐式SSL（implicit SSL）。如果不用SSL，注释掉它们即可。
                if (isUseSsl == "1")
                {
                    request.EnableSsl = true;
                    ServicePointManager.ServerCertificateValidationCallback =
                                  delegate (Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                                  { return true; };
                }

                using (Stream requestStream = request.GetRequestStream())
                {
                    // requestStream.Write(data, 0, data.Length);
                    using (FileStream fileStream = fi.OpenRead())
                    {
                        byte[] buffer = new byte[bytenum];
                        int contentLen = fileStream.Read(buffer, 0, bytenum);
                        while (contentLen != 0)
                        {
                            Thread.Sleep(sleepTime);
                            requestStream.Write(buffer, 0, contentLen);
                            contentLen = fileStream.Read(buffer, 0, contentLen);
                        }
                    }
                }
                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    using (StreamReader readStream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                    {
                        ret = readStream.ReadToEnd();
                    }
                }
                sw.Stop();
                useTime = sw.ElapsedMilliseconds.ToString();
            }
            catch (Exception ex)
            {
                useTime = "error";
                return ret;
            }
            return ret;
        }

        private void MakeOneDir(string uri, string isUseSsl)
        {
            FtpWebRequest request;
            try
            {
                request = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpUri + "/" + uri));
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(ftpUser, ftpPassword);

                if (isUseSsl == "1")
                {
                    request.EnableSsl = true;
                    ServicePointManager.ServerCertificateValidationCallback =
                             delegate (Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                             { return true; };
                }

                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    using (StreamReader readStream = new StreamReader(response.GetResponseStream()))
                    {
                        var ret = readStream.ReadToEnd();
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
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
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpUri + "/" + url));
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
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpUri + "/" + url));
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

        public bool FtpDirExist(string newUri, string fileName, string isUseSsl)
        {
            string[] list = GetAllList(newUri, isUseSsl);
            if (list.Count() > 0)
            {
                foreach (string s in list)
                {
                    if (s == fileName)
                    {
                        return true;
                    }
                }
                return false;

            }
            return false;
        }
        public bool MakeDir(string fullName, string isUseSsl)
        {
            try
            {
                // string fullDir= fullName.Substring(0, fullName.LastIndexOf('/'));
                string[] files = fullName.Split('/');
                string currentDir = "";
                for (int i = 0; i < files.Length; i++)
                {
                    string dir = files[i];
                    if (dir != null && dir.Length > 0)
                    {
                        if (FtpDirExist(currentDir, dir, isUseSsl))
                        {
                            currentDir += dir + "/";
                            continue;
                        }
                        else
                        {
                            currentDir += dir + "/";
                            MakeOneDir(currentDir, isUseSsl);
                        }

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public long GetFileSize(string filename)
        {
            long fileSize = 0;
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpUri + "/" + filename));
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    using (StreamReader readStream = new StreamReader(response.GetResponseStream()))
                    {
                        var ret = readStream.ReadToEnd();
                        fileSize = response.ContentLength;
                    }
                }
                return fileSize;
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

                string localPath = Path.Combine(filePath, fileName);
                if (!Directory.Exists(filePath + "\\" + fileName))
                {
                    Directory.CreateDirectory(filePath + "\\" + fileName);
                }
                string newFileName = Path.Combine(localPath, localName);

                using (FileStream outputStream = new FileStream(newFileName, FileMode.Create))
                {
                    FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpUri + "/" + fileName + "/" + localName));
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
        public bool deleteDir(string dir)
        {
            bool result = false;
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpUri + "/" + dir));
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
