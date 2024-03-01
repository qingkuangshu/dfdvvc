using HalconDotNet;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewWindow.Model;

namespace VM_Pro
{
    [Serializable]
    /// <summary>
    /// 保存图像
    /// </summary>
    internal class NetworkSendTool : ToolBase
    {
        internal NetworkSendTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;
            L_OutItemType = new List<DataType> { DataType.String };

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.TCPIPSever)
                {
                    ethernetName = Project.Instance.L_Service[i].name;
                    clientName = ((TCPSever)(Project.Instance.L_Service[i])).D_clientIPAndName.Values.ToArray()[0];
                }

                if (Project.Instance.L_Service[i].serviceType == ServiceType.TCPIPClient)
                    ethernetName = Project.Instance.L_Service[i].name;
                break;
            }
        }

        /// <summary>
        /// 工具锁
        /// </summary>
        internal object obj = new object();
        /// <summary>
        /// 任务失败时回复特定指令
        /// </summary>
        internal bool taskFailOtherCmd = true;
        /// <summary>
        /// 任务失败时回复指定指令
        /// </summary>
        internal string cmdStrTaskFail = "NG";
        /// <summary>
        /// 任务失败是否新增当前时间戳回复
        /// </summary>
        internal bool isTaskFailTimeFomat = false;
        /// <summary>
        /// 任务时间回复的时间戳格式
        /// </summary>
        internal string timeFomatCmdTaskFail = "yyyyMMddHHmmssff";

        /// <summary>
        /// 结束符
        /// </summary>
        internal string endChar = string.Empty;
        /// <summary>
        /// 通讯端口名称
        /// </summary>
        internal string ethernetName = string.Empty;
        /// <summary>
        /// 客户端名称
        /// </summary>
        internal string clientName = string.Empty;
        /// <summary>
        /// 命令文本
        /// </summary>
        internal string cmdStr = "T";

        /// <summary>
        /// 复位工具
        /// </summary>
        internal override void ResetTool()
        {
            ethernetName = string.Empty;
            endChar = string.Empty;
            cmdStr = "T";

            Frm_NetworkSendTool.Instance.cbx_ethernetNameList.Text = ethernetName;
            Frm_NetworkSendTool.Instance.tbx_cmd.Text = cmdStr;

            Frm_NetworkSendTool.Instance.btn_endCharNone.BackColor = Color.Gray;
            Frm_NetworkSendTool.Instance.btn_endCharEnter.BackColor = Color.Gainsboro;
        }
        /// <summary>
        /// 运行工具    
        /// </summary>
        /// <param name="initRun">初始化运行</param>
        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
        {
            lock (obj)
            {
                toolRunStatu = "未知原因";
                Stopwatch sw = new Stopwatch();
                sw.Restart();

                if (initRun)
                {
                    参数 = new ToolPar();
                    toolRunStatu = "运行成功";
                    sw.Stop();
                    return;
                }

                if (((ToolPar)参数).输入.文本 == string.Empty && cmdStr == string.Empty)
                {
                    toolRunStatu = "未指定以太网发送指令";
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                    goto Exit;
                }

                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].name == ethernetName)
                    {
                        switch (Project.Instance.L_Service[i].serviceType)
                        {
                            case ServiceType.TCPIPSever:
                                if (TCPSever.FindClientItemByName(ethernetName, clientName) == null)
                                {
                                    toolRunStatu = string.Format("远程客户端 [ {0} ] 未连接到服务器 [ {1} ]", clientName, ethernetName);
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                    goto Exit;
                                }

                                if (Task.FindTaskByName(taskName).taskRunStatu == TaskRunStatu.Succeed || !taskFailOtherCmd)
                                {
                                    if (((ToolPar)参数).输入.文本 == string.Empty)        //如没有指定发送指令输入项，就使用固定指令
                                        ((TCPSever)Project.Instance.L_Service[i]).Send(clientName, cmdStr + endChar);
                                    else
                                        ((TCPSever)Project.Instance.L_Service[i]).Send(clientName, ((ToolPar)参数).输入.文本 + endChar);
                                }
                                else
                                {
                                    ((TCPSever)Project.Instance.L_Service[i]).Send(clientName, cmdStrTaskFail + endChar);
                                }
                                break;
                            case ServiceType.TCPIPClient:
                                string strSentToServer = "";
                                if (!TCPClient.FindClientByName(ethernetName).Connected)
                                {
                                    toolRunStatu = string.Format("客户端 [ {0} ] 未连接到远程服务器", ethernetName);
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                    //((ToolPar)参数).输出.文本 = "连接服务器失败" + ((ToolPar)参数).输入.文本;
                                    ((ToolPar)参数).输出.文本 = DateTime.Now.ToString(timeFomatCmdTaskFail) + "未连接" + ((ToolPar)参数).输入.文本;
                                    goto Exit;
                                }
                                if (taskName != "补传")   //注意，此处是为了应对极片追溯项目，项目完结后，应将其去掉，只留下if内部的东西
                                {
                                    if (Task.FindTaskByName(taskName).taskRunStatu == TaskRunStatu.Succeed || !taskFailOtherCmd)
                                    {
                                        if (((ToolPar)参数).输入.文本 == string.Empty)        //如没有指定发送指令输入项，就使用固定指令
                                            strSentToServer = cmdStr;
                                        else
                                            strSentToServer = ((ToolPar)参数).输入.文本;
                                        ((ToolPar)参数).输出.文本 = strSentToServer;
                                    }
                                    else
                                    {
                                        //客户端失败时发送的信息
                                        if (isTaskFailTimeFomat)    //需要增加时间戳回复
                                        {
                                            ((ToolPar)参数).输出.文本 = DateTime.Now.ToString(timeFomatCmdTaskFail);
                                            strSentToServer = cmdStrTaskFail + "," + ((ToolPar)参数).输出.文本;
                                        }
                                        else    //不需要增加时间戳格式
                                        {
                                            ((ToolPar)参数).输出.文本 = cmdStrTaskFail;
                                            strSentToServer = cmdStrTaskFail;
                                        }
                                    }
                                    ((TCPClient)Project.Instance.L_Service[i]).Send(strSentToServer + endChar);
                                    break;
                                }
                                else     //注意，此处是为了应对极片追溯项目，项目完结后，应将其去掉
                                {
                                    //获取采集图像工具当前图片的名称
                                    string ImgName = ((ImageTool)(Task.FindTaskByName("补传").FindToolByName("采集图像"))).imagePath;
                                    string result = System.IO.Path.GetFileNameWithoutExtension(ImgName);
                                    //获取当前扫码结果
                                    if (((ToolPar)参数).输入.文本 != "")
                                    {
                                        ((ToolPar)参数).输出.文本 = ((ToolPar)参数).输入.文本;
                                        ((TCPClient)Project.Instance.L_Service[i]).Send("BC," + result + "," + ((ToolPar)参数).输入.文本 + endChar);
                                    }
                                    else
                                    {
                                        ((ToolPar)参数).输出.文本 = result;
                                        ((TCPClient)Project.Instance.L_Service[i]).Send("BC," + result + ",fail" + endChar);
                                        Frm_Infomation.Instance.curNGOverrunNum++;
                                    }
                                    //此处需要新增是否需要回复NG超限
                                    if (Frm_Infomation.Instance.isLastUpload)
                                    {
                                        if (Frm_Infomation.Instance.curNGOverrunNum >= Project.Instance.configuration.projectCfg.NGOverrunNum)
                                        {
                                            ((TCPClient)Project.Instance.L_Service[i]).Send("NG数量超限,"
                                                + Project.Instance.configuration.projectCfg.NGOverrunNum + ","
                                                + Frm_Infomation.Instance.curNGOverrunNum + ","
                                                + Project.Instance.configuration.projectCfg.UploadTime + endChar
                                                );
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }

                sw.Stop();
                toolRunStatu = "运行成功";
            Exit:
                if (Frm_SaveImageTool.hasShown && Frm_SaveImageTool.taskName == taskName && Frm_SaveImageTool.toolName == toolName)
                {
                    long time = sw.ElapsedMilliseconds;
                    Frm_SaveImageTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());
                    if (toolRunStatu == "运行成功")
                    {
                        Frm_SaveImageTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                        Frm_SaveImageTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
                    }
                    else
                    {
                        Frm_SaveImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                        Frm_SaveImageTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
                    }
                }
            }
        }

        #region 工具参数

        [Serializable]
        public class ToolPar : ToolParBase
        {
            private P输入 _输入 = new P输入();
            public P输入 输入
            {
                get { return _输入; }
                set { _输入 = value; }
            }

            private P运行 _运行 = new P运行();
            public P运行 运行
            {
                get { return _运行; }
                set { _运行 = value; }
            }

            private P输出 _输出 = new P输出();
            public P输出 输出
            {
                get { return _输出; }
                set { _输出 = value; }
            }
        }
        [Serializable]
        public class P输入
        {
            private string _文本 = string.Empty;
            public string 文本
            {
                get { return _文本; }
                set { _文本 = value; }
            }
        }
        [Serializable]
        public class P运行 { }
        [Serializable]
        internal class P输出
        {
            private string _文本 = string.Empty;
            public string 文本
            {
                get { return _文本; }
                set { _文本 = value; }
            }

        }

        #endregion

    }
}
