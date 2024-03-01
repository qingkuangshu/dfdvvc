using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Pro
{
    [Serializable]
    internal class CameraIOOut : ToolBase
    {
        internal CameraIOOut(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

        }

        /// <summary>
        /// 信号持续输出时间  单位：ms
        /// </summary>
        internal int ThreadTimeOut = 50;

        /// <summary>
        /// 触发输出类型
        /// </summary>
        internal CameraIoOutputType OutputType = CameraIoOutputType.任务成功触发;

        [NonSerialized]
        /// <summary>
        /// 当前是否执行输出，主要用于单点测试
        /// </summary>
        internal bool CurRun = false;

        /// <summary>
        /// 运行工具    
        /// </summary>
        /// <param name="initRun">初始化运行</param>
        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
        {
            toolRunStatu = "未知原因";
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            if (initRun)
                参数 = new ToolPar();

            bool IsRunSuccess = false;

            if ((Task.FindTaskByName(taskName).taskRunStatu == TaskRunStatu.Succeed && OutputType == CameraIoOutputType.任务成功触发)
                || (Task.FindTaskByName(taskName).taskRunStatu == TaskRunStatu.Fail && OutputType == CameraIoOutputType.任务失败触发)
                || OutputType == CameraIoOutputType.任务运行触发)
            {
                if (!Project.Instance.configuration.projectCfg.Is_StartAlgo)   //项目特有：极片缺陷可开启是否踢料
                {
                    toolRunStatu = "IO屏蔽输出";
                    goto Exit;
                }

                if (CurRun)
                {
                    for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                    {
                        if (Project.Instance.L_Service[i].name == ((ImageTool)Task.FindTaskByName(taskName).FindToolByName("采集图像")).cameraName &&
                            Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                        {
                            CurRun = false;
                            if (CCamera.FindCamera(Project.Instance.L_Service[i].name).IoOutout(((CCamera)Project.Instance.L_Service[i]).cameraInfoStr, ThreadTimeOut))
                            {
                                IsRunSuccess = true;
                                break;
                            }
                            else
                            {
                                toolRunStatu = "IO输出失败";
                                goto Exit;
                            }
                        }
                    }
                }
                else        //相机回调的时候在给予信号触发
                {
                    SDK_HIKVision.isOutIo.Enqueue(true);
                    SDK_HIKVision.ThreadTimeOut = ThreadTimeOut;
                }
            }
            IsRunSuccess = true;
            toolRunStatu = "运行成功";

        Exit:
            if (FrmCameraIoOut.hasShown)
            {
                FrmCameraIoOut.Instance.lbl_runTime.Text = sw.ElapsedMilliseconds.ToString();
                FrmCameraIoOut.Instance.lbl_toolTip.Text = IsRunSuccess ? "运行成功" : "运行失败";
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
        public class P输入 { }
        [Serializable]
        public class P运行 { }
        [Serializable]
        internal class P输出
        {
            private bool _runResult;
            public bool RunResult
            {
                get
                {
                    return _runResult;
                }
                set { _runResult = value; }
            }
        }
        #endregion
    }
}
