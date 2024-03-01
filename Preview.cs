using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreviewDemo
{
    public partial class Preview : Form
    {
        private uint iLastErr = 0;
        private Int32 m_lUserID = -1;
        private bool m_bInitSDK = false;
        private bool m_bRecord = false;
        private Int32 m_lRealHandle = -1;
        private string str;

        CHCNetSDK.REALDATACALLBACK RealData = null;
        CHCNetSDK.LOGINRESULTCALLBACK LoginCallBack = null;
        public CHCNetSDK.NET_DVR_USER_LOGIN_INFO struLogInfo;
        public CHCNetSDK.NET_DVR_DEVICEINFO_V40 DeviceInfo;

        private Int32 m_lAbnormalRealHandle = -1;
        private int abnormalRecordCount = 0;       
        private List<DateTime> abnormalButtonClickTimes = new List<DateTime>(); // 用于存储异常按钮点击时间点
        List<DateTime> modifiedClickTimes = new List<DateTime>();

        TimeSpan fixedTime = new TimeSpan(0, 1, 32);
        TimeSpan fixedTime1 = new TimeSpan(0, 0, 5);
        private string sVideoFileNametanchuang;
        private DateTime starttime;


        public delegate void UpdateTextStatusCallback(string strLogStatus, IntPtr lpDeviceInfo);

        public Preview()
        {
            InitializeComponent();
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            else
            {
                //保存SDK日志 To save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, "D:\\Users\\2307245383\\Desktop\\海康摄像机\\报警功能\\SdkLog\\", true);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        //public void UpdateClientList(string strLogStatus, IntPtr lpDeviceInfo)
        //{
        //    //列表新增报警信息
        //    labelLogin.Text = "登录状态（异步）：" + strLogStatus;
        //}

        public void cbLoginCallBack(int lUserID, int dwResult, IntPtr lpDeviceInfo, IntPtr pUser)
        {
            string strLoginCallBack = "登录设备，lUserID：" + lUserID + "，dwResult：" + dwResult;

            if (dwResult == 0)
            {
                uint iErrCode = CHCNetSDK.NET_DVR_GetLastError();
                strLoginCallBack = strLoginCallBack + "，错误号:" + iErrCode;
            }

            //下面代码注释掉也会崩溃
            if (InvokeRequired)
            {
                object[] paras = new object[2];
                paras[0] = strLoginCallBack;
                paras[1] = lpDeviceInfo;
                // labelLogin.BeginInvoke(new UpdateTextStatusCallback(UpdateClientList), paras);
            }
            //else
            //{
            //    //创建该控件的主线程直接更新信息列表 
            //    UpdateClientList(strLoginCallBack, lpDeviceInfo);
            //}

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textBoxIP.Text == "" || textBoxPort.Text == "" ||
                textBoxUserName.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Please input IP, Port, User name and Password!");
                return;
            }
            if (m_lUserID < 0)
            {
                //存储与用户登录相关的信息
                struLogInfo = new CHCNetSDK.NET_DVR_USER_LOGIN_INFO();

                //设备IP地址或者域名
                byte[] byIP = System.Text.Encoding.Default.GetBytes(textBoxIP.Text);
                struLogInfo.sDeviceAddress = new byte[129];
                byIP.CopyTo(struLogInfo.sDeviceAddress, 0);

                //设备用户名
                byte[] byUserName = System.Text.Encoding.Default.GetBytes(textBoxUserName.Text);
                struLogInfo.sUserName = new byte[64];
                byUserName.CopyTo(struLogInfo.sUserName, 0);

                //设备密码
                byte[] byPassword = System.Text.Encoding.Default.GetBytes(textBoxPassword.Text);
                struLogInfo.sPassword = new byte[64];
                byPassword.CopyTo(struLogInfo.sPassword, 0);

                struLogInfo.wPort = ushort.Parse(textBoxPort.Text);//设备服务端口号

                if (LoginCallBack == null)
                {
                    LoginCallBack = new CHCNetSDK.LOGINRESULTCALLBACK(cbLoginCallBack);//注册回调函数                    
                }
                struLogInfo.cbLoginResult = LoginCallBack;
                struLogInfo.bUseAsynLogin = false; //是否异步登录：0- 否，1- 是 

                DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V40();

                //登录设备 Login the device
                m_lUserID = CHCNetSDK.NET_DVR_Login_V40(ref struLogInfo, ref DeviceInfo);
                if (m_lUserID < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_Login_V40 failed, error code= " + iLastErr; //登录失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    //登录成功
                    MessageBox.Show("Login Success!");
                    btnLogin.Text = "Logout";
                }

            }
            else
            {
                //注销登录 Logout the device
                if (m_lRealHandle >= 0)
                {
                    MessageBox.Show("Please stop live view firstly");
                    return;
                }

                if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_Logout failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                m_lUserID = -1;
                btnLogin.Text = "Login";
            }
            return;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (m_lUserID < 0)
            {
                MessageBox.Show("Please login the device firstly");
                return;
            }

            if (m_lRealHandle < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                lpPreviewInfo.hPlayWnd = RealPlayWnd.Handle;//预览窗口
                //lpPreviewInfo.lChannel = Int16.Parse(textBoxChannel.Text);//预te览的设备通道
                lpPreviewInfo.lChannel = 1; // 设置默认通道号
                lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                lpPreviewInfo.dwDisplayBufNum = 1; //播放库播放缓冲区最大缓冲帧数
                lpPreviewInfo.byProtoType = 0;
                lpPreviewInfo.byPreviewMode = 0;

                //if (textBoxID.Text != "")
                //{
                //    lpPreviewInfo.lChannel = -1;
                //    byte[] byStreamID = System.Text.Encoding.Default.GetBytes(textBoxID.Text);
                //    lpPreviewInfo.byStreamID = new byte[32];
                //    byStreamID.CopyTo(lpPreviewInfo.byStreamID, 0);
                //}               

                if (RealData == null)
                {
                    RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
                }

                //IntPtr pUser = new IntPtr();//用户数据
                IntPtr pUser = IntPtr.Zero; // 用户数据

                //打开预览 Start live view 
                m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                if (m_lRealHandle < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    //预览成功
                    btnPreview.Text = "Stop Live View";
                }
            }
            else
            {
                //停止预览 Stop live view 
                if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                m_lRealHandle = -1;
                btnPreview.Text = "Live View";

            }
            return;
        }
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            if (dwBufSize > 0)
            {
                byte[] sData = new byte[dwBufSize];
                Marshal.Copy(pBuffer, sData, 0, (Int32)dwBufSize);

                string str = "实时流数据.ps";
                FileStream fs = new FileStream(str, FileMode.Create);
                int iLen = (int)dwBufSize;
                fs.Write(sData, 0, iLen);
                fs.Close();
            }
        }

        private void btnBMP_Click(object sender, EventArgs e)
        {
            //图片保存路径和文件名 
            string folderPath = "D:\\Users\\2307245383\\Desktop\\海康摄像机\\报警功能\\bin\\x64\\Release\\BMP_Capture\\"; // 文件夹路径
            string sBmpPicFileName = Path.Combine(folderPath, "BMP_test_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bmp");
            // 检查文件夹是否存在，如果不存在则创建
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            //BMP抓图 Capture a BMP picture
            if (!CHCNetSDK.NET_DVR_CapturePicture(m_lRealHandle, sBmpPicFileName))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_CapturePicture failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
            else
            {
                str = "Successful to capture the BMP file and the saved file is " + sBmpPicFileName;
                MessageBox.Show(str);
            }
            return;
        }

        private void btnJPEG_Click(object sender, EventArgs e)
        {
            //图片保存路径和文件名 
            string folderPath = "D:\\Users\\2307245383\\Desktop\\海康摄像机\\报警功能\\bin\\x64\\Release\\JPEG_Capture\\"; // 文件夹路径
            string sJpegPicFileName = Path.Combine(folderPath, "JPEG_test_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg");
            // 检查文件夹是否存在，如果不存在则创建
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            //int lChannel = Int16.Parse(textBoxChannel.Text); //通道号 Channel number
            int lChannel = 1;

            CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
            lpJpegPara.wPicQuality = 0; //图像质量 Image quality
            lpJpegPara.wPicSize = 0xff; //抓图分辨率 Picture size: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档

            //JPEG抓图 Capture a JPEG picture
            if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(m_lUserID, lChannel, ref lpJpegPara, sJpegPicFileName))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_CaptureJPEGPicture failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
            else
            {
                str = "Successful to capture the JPEG file and the saved file is " + sJpegPicFileName;
                MessageBox.Show(str);
            }
            return;
        }
        
        private void btnRecord_Click(object sender, EventArgs e)
        {
            //录像保存路径和文件名
            string folderPath = "D:\\Users\\2307245383\\Desktop\\海康摄像机\\报警功能\\bin\\x64\\Release\\Video_Capture\\"; 
            // 创建一个DateTime对象表示当前时间
            DateTime currentTime = DateTime.Now;
            // 将fixedTime添加到当前时间
            DateTime newTime = currentTime.Add(fixedTime);
            // 使用ToString()方法将结果转换为所需的格式
            string formattedTime = newTime.ToString("yyyyMMddHHmmss");
            // 创建视频文件名
            string sVideoFileName = Path.Combine(folderPath, $"Record_test_{formattedTime}.mp4");

            //string sVideoFileName = Path.Combine(folderPath, "Record_test_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".mp4");
            // 检查文件夹是否存在，如果不存在则创建
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            if (m_bRecord == false)
            {
                //强制I帧 Make a I frame
                int lChannel = 1; //通道号 Channel number
                CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID, lChannel);

                //记录正常开始录像时间
                //normalRecordStartTime = DateTime.Now;
               

                //开始录像 Start recording
                if (!CHCNetSDK.NET_DVR_SaveRealData(m_lRealHandle, sVideoFileName))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_SaveRealData failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    btnRecord.Text = "Stop Record";
                    m_bRecord = true;
                    // 将sVideoFileName赋值给停止时弹窗
                    sVideoFileNametanchuang = sVideoFileName;
                    starttime = DateTime.ParseExact(formattedTime, "yyyyMMddHHmmss", null);//开始时间
                }
            }
            else
            {
                //停止录像 Stop recording
                if (!CHCNetSDK.NET_DVR_StopSaveRealData(m_lRealHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopSaveRealData failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    //str = "Successful to stop recording and the saved file is " + sVideoFileNametanchuang;
                    //MessageBox.Show(str);
                    btnRecord.Text = "Start Record";
                    m_bRecord = false;
                   
                }               
                // 在停止录制后执行其他操作
                btnStopRecord_Click(sender, e);
            }

            return;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //停止预览 Stop live view 
            if (m_lRealHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle);
                m_lRealHandle = -1;
            }

            //注销登录 Logout the device
            if (m_lUserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
                m_lUserID = -1;
            }

            CHCNetSDK.NET_DVR_Cleanup();

            Application.Exit();
        }

        private void btnabnor_Click(object sender, EventArgs e)
        {
            // 计数自增
            abnormalRecordCount++;

            // 禁用异常按钮
            btnabnor.Enabled = false;

            // 开始异常录像
            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo.hPlayWnd = IntPtr.Zero; // 由于是异常录像，不需要显示窗口
            lpPreviewInfo.lChannel = 1; // 使用相同的通道号
            lpPreviewInfo.dwStreamType = 0;
            lpPreviewInfo.dwLinkMode = 0;
            lpPreviewInfo.bBlocked = true;
            lpPreviewInfo.dwDisplayBufNum = 1;
            lpPreviewInfo.byProtoType = 0;
            lpPreviewInfo.byPreviewMode = 0;

            IntPtr pUser = IntPtr.Zero;

            string folderPath = "D:\\Users\\2307245383\\Desktop\\海康摄像机\\报警功能\\bin\\x64\\Release\\Abnormal_Video\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            DateTime currentTime = DateTime.Now;
            // 将fixedTime添加到当前时间
            DateTime newTime = currentTime.Add(fixedTime);
            // 使用ToString()方法将结果转换为所需的格式
            string formattedTime = newTime.ToString("yyyyMMddHHmmss");
            // 创建视频文件名
            string abnormalVideoFileName = Path.Combine(folderPath, $"Abnormal_Record_{formattedTime}.mp4");
            //string abnormalVideoFileName = Path.Combine(folderPath, "Abnormal_Record_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".mp4");

            m_lAbnormalRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null, pUser);
            if (m_lAbnormalRealHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr;
                MessageBox.Show(str);
                EnableAbnormalButton();
                return;
            }

            // 开始录像
            if (!CHCNetSDK.NET_DVR_SaveRealData(m_lAbnormalRealHandle, abnormalVideoFileName))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_SaveRealData failed, error code= " + iLastErr;
                MessageBox.Show(str);
                EnableAbnormalButton();
                return;
            }

            // 记录异常按钮点击时间点
            abnormalButtonClickTimes.Add(DateTime.Now);

            // 等待10秒钟，此期间进行异常录像
            Thread.Sleep(10000);

            // 停止录像
            if (!CHCNetSDK.NET_DVR_StopSaveRealData(m_lAbnormalRealHandle))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_StopSaveRealData failed, error code= " + iLastErr;
                MessageBox.Show(str);
                EnableAbnormalButton();
                return;
            }


            // 保存异常录像
            folderPath = abnormalVideoFileName;

            // 在UI线程上执行UI更新操作
            this.Invoke((MethodInvoker)delegate
            {
                // 异常录像结束提示
                //MessageBox.Show("Abnormal Recording Stopped!");
                // 使异常按钮可再次点击
                EnableAbnormalButton();
            });
        }


        // 启用异常按钮
        private void EnableAbnormalButton()
        {
            if (btnabnor.InvokeRequired)
            {
                btnabnor.Invoke((MethodInvoker)delegate { btnabnor.Enabled = true; });
            }
            else
            {
                btnabnor.Enabled = true;
            }
        }
        private void btnStopRecord_Click(object sender, EventArgs e)
        {
                  
            //MessageBox.Show($"Normal Video File Name: {sVideoFileNametanchuang}");

            // 根据异常按钮点击时间点，在正常视频中裁剪每个时间点前5秒的视频，并保存在一个新的文件夹中
            string cutVideosFolderPath = "D:\\Users\\2307245383\\Desktop\\海康摄像机\\报警功能\\bin\\x64\\Release\\Cut_Videos\\";
            if (!Directory.Exists(cutVideosFolderPath))
            {
                Directory.CreateDirectory(cutVideosFolderPath);
            }

            foreach (DateTime clickTime in abnormalButtonClickTimes)
            {
                
                // 加上 fixedTime 并添加到新的列表中
                DateTime modifiedClickTime = clickTime + fixedTime;
                DateTime modifiedClickTime1 = modifiedClickTime - fixedTime1;
                modifiedClickTimes.Add(modifiedClickTime1);

                //MessageBox.Show($"modifiedClickTime1: {modifiedClickTime1.ToString("yyyy-MM-dd HH:mm:ss")}\nstarttime: {starttime.ToString("yyyy-MM-dd HH:mm:ss")}");
                TimeSpan cutStartTime = modifiedClickTime1 - starttime;
               // MessageBox.Show($"Normal Video File Name: {cutStartTime}");

                
                string modifiedClickTime2 = modifiedClickTime1.ToString("yyyyMMddHHmmss");
                // 创建视频文件名
                string cutVideoFileName = Path.Combine(cutVideosFolderPath, $"Cut_Video_{modifiedClickTime2}.mp4");
                //string cutVideoFileName = Path.Combine(cutVideosFolderPath, "Cut_Video_" + clickTime.ToString("yyyyMMddHHmmss") + ".mp4");
                string arguments = $"-ss {cutStartTime.ToString("hh\\:mm\\:ss")} -i {sVideoFileNametanchuang } -t 5 -c copy {cutVideoFileName}";

                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "D:\\Users\\2307245383\\Desktop\\ffmpeg-6.1.1-essentials_build\\bin\\ffmpeg.exe"; // ffmpeg的可执行文件路径
                    startInfo.Arguments = arguments;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();

                    // 检查ffmpeg进程的退出代码
                    if (process.ExitCode != 0)
                    {
                        MessageBox.Show($"Failed to execute ffmpeg command. Exit code: {process.ExitCode}");
                    }
                    else
                    {
                       // MessageBox.Show("Video cut successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while executing ffmpeg command: {ex.Message}");
                }
            }
            // 调用CombineVideos方法进行视频合并
            CombineVideos();
        }
        private void CombineVideos()
        {
            // 获取Cut_Videos文件夹中的所有视频文件
            string[] cutVideoFiles = Directory.GetFiles("D:\\Users\\2307245383\\Desktop\\海康摄像机\\报警功能\\bin\\x64\\Release\\Cut_Videos\\", "*.mp4");

            // 获取Abnormal_Video文件夹中的所有视频文件
            string[] abnormalVideoFiles = Directory.GetFiles("D:\\Users\\2307245383\\Desktop\\海康摄像机\\报警功能\\bin\\x64\\Release\\Abnormal_Video\\", "*.mp4");

            // 检查两个文件夹中是否有足够的视频文件
            if (cutVideoFiles.Length < 1 || abnormalVideoFiles.Length < 1)
            {
                MessageBox.Show("Not enough video files to combine.");
                return;
            }

            // 确保输出文件夹存在
            string outputFolderPath = "D:\\Users\\2307245383\\Desktop\\海康摄像机\\报警功能\\bin\\x64\\Release\\Combined_Videos\\";
            if (!Directory.Exists(outputFolderPath))
            {
                Directory.CreateDirectory(outputFolderPath);
            }

            // 计算两个文件夹中视频的最小数量，以确保两两合并
            int minVideoCount = Math.Min(cutVideoFiles.Length, abnormalVideoFiles.Length);

            // 设置进度条的最大值为最小视频数量
            progressBar1.Maximum = minVideoCount;
            progressBar1.Value = 0;

            // 遍历两个文件夹中的视频文件，并按顺序两两合并
            for (int i = 0; i < minVideoCount; i++)
            {
                // 创建输出文件名
                string outputFileName = Path.Combine(outputFolderPath, $"Combined_Video_{i}.mp4");

                // 创建ffmpeg命令行参数，将当前遍历到的两个视频文件合并为一个输出文件
                string arguments = $"-i \"{cutVideoFiles[i]}\" -i \"{abnormalVideoFiles[i]}\" -filter_complex \"[0:v][1:v]concat=n=2:v=1:a=0[outv]\" -map \"[outv]\" -c:v libx264 -crf 23 \"{outputFileName}\"";

                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "D:\\Users\\2307245383\\Desktop\\ffmpeg-6.1.1-essentials_build\\bin\\ffmpeg.exe";
                    startInfo.Arguments = arguments;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();

                    // 检查ffmpeg进程的退出代码
                    if (process.ExitCode != 0)
                    {
                        MessageBox.Show($"Failed to execute ffmpeg command. Exit code: {process.ExitCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while executing ffmpeg command: {ex.Message}");
                }

                // 更新进度条的值
                progressBar1.Value++;
            }

            // 所有视频合并完成后显示成功消息
            //MessageBox.Show("All videos combined successfully!");
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
