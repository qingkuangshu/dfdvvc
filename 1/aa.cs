using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace VM_Pro
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //启动前判断是否已开启了一个实例
                System.Threading.Mutex mutex = new System.Threading.Mutex(false, "ThisShouldOnlyRunOnce");
                bool isRunning = true;
                try
                {
                    isRunning = !mutex.WaitOne(0, false);            //这一句有时候会报错，原因不明，故先Try起来再说
                }
                catch { }

                //如果已经开启了就做出警告
                if (isRunning)
                {
                    if (FuncLib.ShowConfirmDialog("已经运行了一个程序（或旧程序尚未完全关闭），是否再次开启一个程序？", InfoType.Warn) == DialogResult.OK)
                        Application.Run(Frm_Welcome.Instance);
                }
                else
                {
                    Application.Run(Frm_Welcome.Instance);
                }
            }
            catch (Exception ex)
            {
                //弹框提示 启动出错
                MessageBox.Show(ex.ToString());
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            StackFrame tmpSF = new StackTrace(new StackFrame(true)).GetFrame(0);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************** 程序异常！请截图保存并反馈至软件工程师 ******************************");
            sb.AppendLine("异常时间：" + DateTime.Now.ToString());
            if (e.Exception as Exception != null)
            {
                sb.AppendLine("异常行号：" + tmpSF.GetFileLineNumber());
                sb.AppendLine("异常信息：" + (e.Exception as Exception).Message.Trim('。'));
                sb.AppendLine("异常位置：" + (e.Exception as Exception).StackTrace.Trim());
            }
            else
            {
                sb.AppendLine("未知异常");
            }

            FuncLib.ShowExceptionBox(sb.ToString(), InfoType.Error);
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            StackFrame tmpSF = new StackTrace(new StackFrame(true)).GetFrame(0);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************** 程序异常！请截图保存并反馈至软件工程师 ******************************");
            sb.AppendLine("异常时间：" + DateTime.Now.ToString());
            if (e.ExceptionObject as Exception != null)
            {
                sb.AppendLine("异常行号：" + tmpSF.GetFileLineNumber());
                sb.AppendLine("异常信息：" + (e.ExceptionObject as Exception).Message.Trim('。'));
                sb.AppendLine("异常位置：" + (e.ExceptionObject as Exception).StackTrace.Trim());
            }
            else
            {
                sb.AppendLine("未知异常");
            }

            FuncLib.ShowExceptionBox(sb.ToString(), InfoType.Error);
        }


    }
}
