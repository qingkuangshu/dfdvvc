using HalconDotNet;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace VM_Pro
{
    [Serializable]
    /// <summary>
    /// 光源控制
    /// </summary>
    internal class LightTool : ToolBase
    {
        internal LightTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

            //自动连接输入
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.采集图像)
                {
                    cameraName = Task.curTask.L_toolList[i].toolName;
                    break;
                }
            }

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Light)
                {
                    light1Controller = Project.Instance.L_Service[i].name;
                    light2Controller = Project.Instance.L_Service[i].name;
                    light3Controller = Project.Instance.L_Service[i].name;
                    light4Controller = Project.Instance.L_Service[i].name;
                    break;
                }
            }
        }

        /// <summary>
        /// 光源1启用
        /// </summary>
        internal bool light1Enable = true;
        /// <summary>
        /// 光源2启用
        /// </summary>
        internal bool light2Enable = false;
        /// <summary>
        /// 光源3启用
        /// </summary>
        internal bool light3Enable = false;
        /// <summary>
        /// 光源4启用
        /// </summary>
        internal bool light4Enable = false;
        /// <summary>
        /// 相机名称
        /// </summary>
        internal string cameraName = string.Empty;
        /// <summary>
        /// 光源1控制器
        /// </summary>
        internal string light1Controller = string.Empty;
        /// <summary>
        /// 光源1通道
        /// </summary>
        internal string light1Ch = "1";
        /// <summary>
        /// 光源1亮度
        /// </summary>
        internal int light1Brightness = 200;
        /// <summary>
        /// 光源1控制器
        /// </summary>
        internal string light2Controller = string.Empty;
        /// <summary>
        /// 光源1通道
        /// </summary>
        internal string light2Ch = "2";
        /// <summary>
        /// 光源1亮度
        /// </summary>
        internal int light2Brightness = 200;
        /// <summary>
        /// 光源1控制器
        /// </summary>
        internal string light3Controller = string.Empty;
        /// <summary>
        /// 光源1通道
        /// </summary>
        internal string light3Ch = "3";
        /// <summary>
        /// 光源1亮度
        /// </summary>
        internal int light3Brightness = 200;
        /// <summary>
        /// 光源1控制器
        /// </summary>
        internal string light4Controller = string.Empty;
        /// <summary>
        /// 光源1通道
        /// </summary>
        internal string light4Ch = "4";
        /// <summary>
        /// 光源1亮度
        /// </summary>
        internal int light4Brightness = 200;
        /// <summary>
        /// 相机实时显示线程
        /// </summary>
        internal static Thread th_livePlay = null;


        /// <summary>
        /// 复位工具
        /// </summary>
        internal override void ResetTool()
        {
            light1Enable = true;
            light2Enable = false;
            light3Enable = false;
            light4Enable = false;
            cameraName = string.Empty;
            light1Controller = string.Empty;
            light1Ch = "1";
            light1Brightness = 200;
            light2Controller = string.Empty;
            light2Ch = "2";
            light2Brightness = 200;
            light3Controller = string.Empty;
            light3Ch = "3";
            light3Brightness = 200;
            light4Controller = string.Empty;
            light4Ch = "4";
            light4Brightness = 200;

            Frm_LightTool.Instance.ckb_enableLight1.Checked = true;
            Frm_LightTool.Instance.ckb_enableLight2.Checked = false;
            Frm_LightTool.Instance.ckb_enableLight3.Checked = false;
            Frm_LightTool.Instance.ckb_enableLight4.Checked = false;
            Frm_LightTool.Instance.cbx_camerList.SelectedIndex = 0;
            Frm_LightTool.Instance.cbx_light1Controller.SelectedIndex = 0;
            Frm_LightTool.Instance.cbx_light2Controller.SelectedIndex = 0;
            Frm_LightTool.Instance.cbx_light3Controller.SelectedIndex = 0;
            Frm_LightTool.Instance.cbx_light4Controller.SelectedIndex = 0;
            Frm_LightTool.Instance.cbx_light1Ch.Text = "1";
            Frm_LightTool.Instance.cbx_light2Ch.Text = "2";
            Frm_LightTool.Instance.cbx_light3Ch.Text = "3";
            Frm_LightTool.Instance.cbx_light4Ch.Text = "4";
            Frm_LightTool.Instance.tck_light1Value.Value = 200;
            Frm_LightTool.Instance.tck_light2Value.Value = 200;
            Frm_LightTool.Instance.tck_light3Value.Value = 200;
            Frm_LightTool.Instance.tck_light4Value.Value = 200;
            Frm_LightTool.Instance.tbx_light1Value.Text = "200";
            Frm_LightTool.Instance.tbx_light2Value.Text = "200";
            Frm_LightTool.Instance.tbx_light3Value.Text = "200";
            Frm_LightTool.Instance.tbx_light4Value.Text = "200";
            Frm_LightTool.Instance.btn_light1OnOff.Active = false;
            Frm_LightTool.Instance.btn_light2OnOff.Active = false;
            Frm_LightTool.Instance.btn_light3OnOff.Active = false;
            Frm_LightTool.Instance.btn_light4OnOff.Active = false;
            Frm_LightTool.Instance.pnl_light2.Visible = false;
            Frm_LightTool.Instance.pnl_light3.Visible = false;
            Frm_LightTool.Instance.pnl_light4.Visible = false;
        }
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
            {
                参数 = new ToolPar();
                toolRunStatu = "运行成功";
                sw.Stop();
                return;
            }

            if (light1Enable)
            {
                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].name == light1Controller)
                    {
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(light1Ch), light1Brightness);
                    }
                }
            }

            if (light2Enable)
            {
                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].name == light2Controller)
                    {
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(light2Ch), light2Brightness);
                    }
                }
            }

            if (light3Enable)
            {
                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].name == light3Controller)
                    {
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(light3Ch), light3Brightness);
                    }
                }
            }

            if (light4Enable)
            {
                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].name == light4Controller)
                    {
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(light4Ch), light4Brightness);
                    }
                }
            }

            sw.Stop();
            toolRunStatu = "运行成功";
        Exit:
            if (Frm_LightTool.hasShown && Frm_LightTool.taskName == taskName && Frm_LightTool.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_LightTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());

                if (toolRunStatu == "运行成功")
                    Frm_IDTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                else
                    Frm_LightTool.Instance.lbl_toolTip.ForeColor = Color.Red;

                Frm_LightTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
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
            private HObject _图像;
            public HObject 图像
            {
                get
                {
                    return _图像;
                }
                set { _图像 = value; }
            }
        }
        #endregion

    }
}
