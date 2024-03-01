using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using HalconDotNet;

namespace VM_Pro
{
    public partial class Frm_LightTool : UIForm
    {
        public Frm_LightTool()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 正在忙碌
        /// </summary>
        private static bool isBusying = false;
        /// <summary>
        /// 是否启用事件，也就是不执行本次触发的事件
        /// </summary>
        internal static bool openingForm = false;
        /// <summary>
        /// 当前工具名
        /// </summary>
        internal static string toolName = string.Empty;
        /// <summary>
        /// 当前工具所属的流程
        /// </summary>
        internal static string taskName = string.Empty;
        /// <summary>
        /// 窗体是否已显示
        /// </summary>
        internal static bool hasShown = false;
        /// <summary>
        /// 工具对象
        /// </summary>
        internal static LightTool lightTool;
        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_LightTool _instance;
        internal static Frm_LightTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_LightTool();
                return _instance;
            }
        }


        /// <summary>
        /// 弹出工具页面
        /// </summary>
        /// <param name="toolBase">工具</param>
        internal static void ShowForm(ToolBase toolBase)
        {
            if (hasShown && taskName == toolBase.taskName && toolName == toolBase.toolName)     //如果当前工具已显示或者最小化了，那就直接显示即可
            {
                Instance.WindowState = FormWindowState.Normal;
                Instance.Activate();
                return;
            }

            openingForm = true;
            Instance.Text = string.Format("{0}    [ {1} . {2} ]", toolBase.toolType, toolBase.taskName, toolBase.toolName);
            lightTool = (LightTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;
            Instance.Show();
            Application.DoEvents();
            hasShown = true;

            //刷新相机列表
            Instance.cbx_camerList.Items.Clear();
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.采集图像)
                    Instance.cbx_camerList.Items.Add(Task.curTask.L_toolList[i].toolName);
            }

            Instance.ckb_taskFailKeepRun.Checked = lightTool.taskFailKeepRun;
            Instance.pnl_light1.Visible = lightTool.light1Enable;
            Instance.pnl_light2.Visible = lightTool.light2Enable;
            Instance.pnl_light3.Visible = lightTool.light3Enable;
            Instance.pnl_light4.Visible = lightTool.light4Enable;

            Instance.ckb_enableLight1.Checked = lightTool.light1Enable;
            Instance.ckb_enableLight2.Checked = lightTool.light2Enable;
            Instance.ckb_enableLight3.Checked = lightTool.light3Enable;
            Instance.ckb_enableLight4.Checked = lightTool.light4Enable;

            Instance.cbx_camerList.Text = lightTool.cameraName;

            Instance.tck_light1Value.Value = lightTool.light1Brightness;
            Instance.tck_light2Value.Value = lightTool.light2Brightness;
            Instance.tck_light3Value.Value = lightTool.light3Brightness;
            Instance.tck_light4Value.Value = lightTool.light4Brightness;

            Instance.tbx_light1Value.Text = lightTool.light1Brightness.ToString();
            Instance.tbx_light2Value.Text = lightTool.light2Brightness.ToString();
            Instance.tbx_light3Value.Text = lightTool.light3Brightness.ToString();
            Instance.tbx_light4Value.Text = lightTool.light4Brightness.ToString();

            Instance.cbx_light1Controller.Items.Clear();
            Instance.cbx_light2Controller.Items.Clear();
            Instance.cbx_light3Controller.Items.Clear();
            Instance.cbx_light4Controller.Items.Clear();
            Instance.cbx_light1Ch.Items.Clear();
            Instance.cbx_light2Ch.Items.Clear();
            Instance.cbx_light3Ch.Items.Clear();
            Instance.cbx_light4Ch.Items.Clear();
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Light)
                {
                    //刷新控制器列表
                    Instance.cbx_light1Controller.Items.Add(Project.Instance.L_Service[i].name);
                    Instance.cbx_light2Controller.Items.Add(Project.Instance.L_Service[i].name);
                    Instance.cbx_light3Controller.Items.Add(Project.Instance.L_Service[i].name);
                    Instance.cbx_light4Controller.Items.Add(Project.Instance.L_Service[i].name);

                    //获取通道开关状态
                    if (((LightService)Project.Instance.L_Service[i]).name == lightTool.light1Controller)
                    {
                        Instance.btn_light1OnOff.Active = ((LightService)Project.Instance.L_Service[i]).lightBase.GetOnOffState(Convert.ToInt16(lightTool.light1Ch));

                        //刷新通道
                        switch (((LightService)Project.Instance.L_Service[i]).lightBase.chNum)
                        {
                            case "双通道":
                                Instance.cbx_light1Ch.Items.Add(1);
                                Instance.cbx_light1Ch.Items.Add(2);
                                break;
                            case "四通道":
                                Instance.cbx_light1Ch.Items.Add(1);
                                Instance.cbx_light1Ch.Items.Add(2);
                                Instance.cbx_light1Ch.Items.Add(3);
                                Instance.cbx_light1Ch.Items.Add(4);
                                break;
                            case "六通道":
                                Instance.cbx_light1Ch.Items.Add(1);
                                Instance.cbx_light1Ch.Items.Add(2);
                                Instance.cbx_light1Ch.Items.Add(3);
                                Instance.cbx_light1Ch.Items.Add(4);
                                Instance.cbx_light1Ch.Items.Add(5);
                                Instance.cbx_light1Ch.Items.Add(6);
                                break;
                            case "八通道":
                                Instance.cbx_light1Ch.Items.Add(1);
                                Instance.cbx_light1Ch.Items.Add(2);
                                Instance.cbx_light1Ch.Items.Add(3);
                                Instance.cbx_light1Ch.Items.Add(4);
                                Instance.cbx_light1Ch.Items.Add(5);
                                Instance.cbx_light1Ch.Items.Add(6);
                                Instance.cbx_light1Ch.Items.Add(7);
                                Instance.cbx_light1Ch.Items.Add(8);
                                break;
                        }
                    }
                    if (((LightService)Project.Instance.L_Service[i]).name == lightTool.light2Controller)
                    {
                        Instance.btn_light1OnOff.Active = ((LightService)Project.Instance.L_Service[i]).lightBase.GetOnOffState(Convert.ToInt16(lightTool.light2Ch));

                        //刷新通道
                        switch (((LightService)Project.Instance.L_Service[i]).lightBase.chNum)
                        {
                            case "双通道":
                                Instance.cbx_light2Ch.Items.Add(1);
                                Instance.cbx_light2Ch.Items.Add(2);
                                break;
                            case "四通道":
                                Instance.cbx_light2Ch.Items.Add(1);
                                Instance.cbx_light2Ch.Items.Add(2);
                                Instance.cbx_light2Ch.Items.Add(3);
                                Instance.cbx_light2Ch.Items.Add(4);
                                break;
                            case "六通道":
                                Instance.cbx_light2Ch.Items.Add(1);
                                Instance.cbx_light2Ch.Items.Add(2);
                                Instance.cbx_light2Ch.Items.Add(3);
                                Instance.cbx_light2Ch.Items.Add(4);
                                Instance.cbx_light2Ch.Items.Add(5);
                                Instance.cbx_light2Ch.Items.Add(6);
                                break;
                            case "八通道":
                                Instance.cbx_light2Ch.Items.Add(1);
                                Instance.cbx_light2Ch.Items.Add(2);
                                Instance.cbx_light2Ch.Items.Add(3);
                                Instance.cbx_light2Ch.Items.Add(4);
                                Instance.cbx_light2Ch.Items.Add(5);
                                Instance.cbx_light2Ch.Items.Add(6);
                                Instance.cbx_light2Ch.Items.Add(7);
                                Instance.cbx_light2Ch.Items.Add(8);
                                break;
                        }
                    }
                    if (((LightService)Project.Instance.L_Service[i]).name == lightTool.light3Controller)
                    {
                        Instance.btn_light1OnOff.Active = ((LightService)Project.Instance.L_Service[i]).lightBase.GetOnOffState(Convert.ToInt16(lightTool.light3Ch));

                        //刷新通道
                        switch (((LightService)Project.Instance.L_Service[i]).lightBase.chNum)
                        {
                            case "双通道":
                                Instance.cbx_light3Ch.Items.Add(1);
                                Instance.cbx_light3Ch.Items.Add(2);
                                break;
                            case "四通道":
                                Instance.cbx_light3Ch.Items.Add(1);
                                Instance.cbx_light3Ch.Items.Add(2);
                                Instance.cbx_light3Ch.Items.Add(3);
                                Instance.cbx_light3Ch.Items.Add(4);
                                break;
                            case "六通道":
                                Instance.cbx_light3Ch.Items.Add(1);
                                Instance.cbx_light3Ch.Items.Add(2);
                                Instance.cbx_light3Ch.Items.Add(3);
                                Instance.cbx_light3Ch.Items.Add(4);
                                Instance.cbx_light3Ch.Items.Add(5);
                                Instance.cbx_light3Ch.Items.Add(6);
                                break;
                            case "八通道":
                                Instance.cbx_light3Ch.Items.Add(1);
                                Instance.cbx_light3Ch.Items.Add(2);
                                Instance.cbx_light3Ch.Items.Add(3);
                                Instance.cbx_light3Ch.Items.Add(4);
                                Instance.cbx_light3Ch.Items.Add(5);
                                Instance.cbx_light3Ch.Items.Add(6);
                                Instance.cbx_light3Ch.Items.Add(7);
                                Instance.cbx_light3Ch.Items.Add(8);
                                break;
                        }
                    }
                    if (((LightService)Project.Instance.L_Service[i]).name == lightTool.light4Controller)
                    {
                        Instance.btn_light1OnOff.Active = ((LightService)Project.Instance.L_Service[i]).lightBase.GetOnOffState(Convert.ToInt16(lightTool.light4Ch));

                        //刷新通道
                        switch (((LightService)Project.Instance.L_Service[i]).lightBase.chNum)
                        {
                            case "双通道":
                                Instance.cbx_light4Ch.Items.Add(1);
                                Instance.cbx_light4Ch.Items.Add(2);
                                break;
                            case "四通道":
                                Instance.cbx_light4Ch.Items.Add(1);
                                Instance.cbx_light4Ch.Items.Add(2);
                                Instance.cbx_light4Ch.Items.Add(3);
                                Instance.cbx_light4Ch.Items.Add(4);
                                break;
                            case "六通道":
                                Instance.cbx_light4Ch.Items.Add(1);
                                Instance.cbx_light4Ch.Items.Add(2);
                                Instance.cbx_light4Ch.Items.Add(3);
                                Instance.cbx_light4Ch.Items.Add(4);
                                Instance.cbx_light4Ch.Items.Add(5);
                                Instance.cbx_light4Ch.Items.Add(6);
                                break;
                            case "八通道":
                                Instance.cbx_light4Ch.Items.Add(1);
                                Instance.cbx_light4Ch.Items.Add(2);
                                Instance.cbx_light4Ch.Items.Add(3);
                                Instance.cbx_light4Ch.Items.Add(4);
                                Instance.cbx_light4Ch.Items.Add(5);
                                Instance.cbx_light4Ch.Items.Add(6);
                                Instance.cbx_light4Ch.Items.Add(7);
                                Instance.cbx_light4Ch.Items.Add(8);
                                break;
                        }
                    }
                }
            }

            Instance.cbx_light1Controller.Text = lightTool.light1Controller;
            Instance.cbx_light2Controller.Text = lightTool.light2Controller;
            Instance.cbx_light3Controller.Text = lightTool.light3Controller;
            Instance.cbx_light4Controller.Text = lightTool.light4Controller;

            Instance.cbx_light1Ch.Text = lightTool.light1Ch;
            Instance.cbx_light2Ch.Text = lightTool.light2Ch;
            Instance.cbx_light3Ch.Text = lightTool.light3Ch;
            Instance.cbx_light4Ch.Text = lightTool.light4Ch;

            if (!isBusying)
            {
                Thread th1 = new Thread(() =>
                {
                    isBusying = true;
                    ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                    if (((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像 != null)
                        Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                    isBusying = false;
                });
                th1.IsBackground = true;
                th1.Start();
            }

            Instance.Activate();
            Instance.btn_runTool.Focus();
            openingForm = false;
        }


        private void toolStrip1_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }
        private void 保存toolStripButton1_Click(object sender, EventArgs e)
        {
            Scheme.SaveCur();
            FuncLib.ShowMsg("保存当前方案成功", InfoType.Tip);
        }
        private void 复位toolStripButton3_Click(object sender, EventArgs e)
        {
            lightTool.ResetTool();
        }
        private void Frm_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

        private void btn_runTool_Click(object sender, EventArgs e)
        {
            if (!isBusying)
            {
                Thread th = new Thread(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        Frm_Loading.Instance.lbl_title.Text = "拼命加载中";
                        Frm_Loading.Instance.TopLevel = true;
                        Frm_Loading.Instance.TopMost = true;
                        Frm_Loading.Instance.Show();
                    }));
                    isBusying = true;
                    lightTool.Run();
                    isBusying = false;
                    Frm_Loading.Instance.Hide();
                });
                th.IsBackground = true;
                th.Start();
            }
        }
        private void btn_runTask_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Task.FindTaskByName(taskName).Run();
            });
            th.IsBackground = true;
            th.Start();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckb_enableLight1_Click(object sender, EventArgs e)
        {
            lightTool.light1Enable = ckb_enableLight1.Checked;
            pnl_light1.Visible = lightTool.light1Enable;
        }
        private void ckb_enableLight2_Click(object sender, EventArgs e)
        {
            lightTool.light2Enable = ckb_enableLight2.Checked;
            pnl_light2.Visible = lightTool.light2Enable;
        }
        private void ckb_enableLight3_Click(object sender, EventArgs e)
        {
            lightTool.light3Enable = ckb_enableLight3.Checked;
            pnl_light3.Visible = lightTool.light3Enable;
        }
        private void ckb_enableLight4_Click(object sender, EventArgs e)
        {
            lightTool.light4Enable = ckb_enableLight4.Checked;
            pnl_light4.Visible = lightTool.light4Enable;
        }

        private void cbx_camerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lightTool.cameraName = cbx_camerList.Text;
        }

        private void cbx_light1Controller_SelectedIndexChanged(object sender, EventArgs e)
        {
            lightTool.light1Controller = cbx_light1Controller.Text;
        }
        private void cbx_light1Ch_SelectedIndexChanged(object sender, EventArgs e)
        {
            lightTool.light1Ch = cbx_light1Ch.Text;
        }

        private void tck_light1Value_Scroll(object sender, EventArgs e)
        {
            Instance.tbx_light1Value.Text = tck_light1Value.Value.ToString();
            if ((int)tck_light1Value.Value != 0)
                btn_light1OnOff.Active = true;
            else
                btn_light1OnOff.Active = false;

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == lightTool.light1Controller)
                {
                    ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light1Ch), lightTool.light1Brightness);
                    break;
                }
            }

            if (!isBusying)
            {
                Thread th1 = new Thread(() =>
                {
                    isBusying = true;
                    ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                    Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                    isBusying = false;
                });
                th1.IsBackground = true;
                th1.Start();
            }
        }
        private void tck_light2Value_Scroll(object sender, EventArgs e)
        {
            Instance.tbx_light2Value.Text = tck_light2Value.Value.ToString();
            if ((int)tck_light2Value.Value != 0)
                btn_light2OnOff.Active = true;
            else
                btn_light2OnOff.Active = false;

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == lightTool.light1Controller)
                {
                    ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light1Ch), lightTool.light1Brightness);
                    break;
                }
            }

            if (!isBusying)
            {
                Thread th1 = new Thread(() =>
                {
                    isBusying = true;
                    ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                    Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                    isBusying = false;
                });
                th1.IsBackground = true;
                th1.Start();
            }
        }
        private void tck_light3Value_Scroll(object sender, EventArgs e)
        {
            Instance.tbx_light3Value.Text = tck_light3Value.Value.ToString();
            if ((int)tck_light3Value.Value != 0)
                btn_light3OnOff.Active = true;
            else
                btn_light3OnOff.Active = false;

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == lightTool.light1Controller)
                {
                    ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light1Ch), lightTool.light1Brightness);
                    break;
                }
            }

            if (!isBusying)
            {
                Thread th1 = new Thread(() =>
                {
                    isBusying = true;
                    ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                    Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                    isBusying = false;
                });
                th1.IsBackground = true;
                th1.Start();
            }
        }
        private void tck_light4Value_Scroll(object sender, EventArgs e)
        {
            Instance.tbx_light4Value.Text = tck_light4Value.Value.ToString();
            if ((int)tck_light4Value.Value != 0)
                btn_light4OnOff.Active = true;
            else
                btn_light4OnOff.Active = false;

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == lightTool.light1Controller)
                {
                    ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light1Ch), lightTool.light1Brightness);
                    break;
                }
            }

            if (!isBusying)
            {
                Thread th1 = new Thread(() =>
                {
                    isBusying = true;
                    ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                    Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                    isBusying = false;
                });
                th1.IsBackground = true;
                th1.Start();
            }
        }

        private void tbx_light1Value_TextChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            try
            {
                lightTool.light1Brightness = Convert.ToInt16(tbx_light1Value.Text.Trim());
            }
            catch { }
        }
        private void tbx_light2Value_TextChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            try
            {
                lightTool.light2Brightness = Convert.ToInt16(tbx_light2Value.Text.Trim());
            }
            catch { }
        }
        private void tbx_light3Value_TextChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            try
            {
                lightTool.light3Brightness = Convert.ToInt16(tbx_light3Value.Text.Trim());
            }
            catch { }
        }
        private void tbx_light4Value_TextChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            try
            {
                lightTool.light4Brightness = Convert.ToInt16(tbx_light4Value.Text.Trim());
            }
            catch { }
        }

        private void tbx_light1Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                try
                {
                    if (Convert.ToInt16(tbx_light1Value.Text) > 255)
                        tbx_light1Value.Text = "255";
                    if (Convert.ToInt16(tbx_light1Value.Text) < 0)
                        tbx_light1Value.Text = "0";

                    tck_light1Value.Value = Convert.ToInt16(tbx_light1Value.Text.Trim());
                    lightTool.light1Brightness = Convert.ToInt16(tbx_light1Value.Text.Trim());
                }
                catch { }

                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].name == lightTool.light1Controller)
                    {
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light1Ch), lightTool.light1Brightness);
                        break;
                    }
                }

                if (!isBusying)
                {
                    Thread th1 = new Thread(() =>
                    {
                        isBusying = true;
                        ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                        if (((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像 != null)
                            Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                        isBusying = false;
                    });
                    th1.IsBackground = true;
                    th1.Start();
                }
            }
        }
        private void tbx_light2Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                try
                {
                    if (Convert.ToInt16(tbx_light2Value.Text) > 255)
                        tbx_light2Value.Text = "255";
                    if (Convert.ToInt16(tbx_light2Value.Text) < 0)
                        tbx_light2Value.Text = "0";

                    tck_light2Value.Value = Convert.ToInt16(tbx_light2Value.Text.Trim());
                    lightTool.light2Brightness = Convert.ToInt16(tbx_light2Value.Text.Trim());
                }
                catch { }

                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].name == lightTool.light2Controller)
                    {
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light2Ch), lightTool.light2Brightness);
                        break;
                    }
                }

                if (!isBusying)
                {
                    Thread th1 = new Thread(() =>
                    {
                        isBusying = true;
                        ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                        Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                        isBusying = false;
                    });
                    th1.IsBackground = true;
                    th1.Start();
                }
            }
        }
        private void tbx_light3Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                try
                {
                    if (Convert.ToInt16(tbx_light3Value.Text) > 255)
                        tbx_light3Value.Text = "255";
                    if (Convert.ToInt16(tbx_light3Value.Text) < 0)
                        tbx_light3Value.Text = "0";

                    tck_light3Value.Value = Convert.ToInt16(tbx_light3Value.Text.Trim());
                    lightTool.light3Brightness = Convert.ToInt16(tbx_light3Value.Text.Trim());
                }
                catch { }

                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].name == lightTool.light3Controller)
                    {
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light3Ch), lightTool.light3Brightness);
                        break;
                    }
                }

                if (!isBusying)
                {
                    Thread th1 = new Thread(() =>
                    {
                        isBusying = true;
                        ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                        Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                        isBusying = false;
                    });
                    th1.IsBackground = true;
                    th1.Start();
                }
            }
        }
        private void tbx_light4Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                try
                {
                    if (Convert.ToInt16(tbx_light4Value.Text) > 255)
                        tbx_light4Value.Text = "255";
                    if (Convert.ToInt16(tbx_light4Value.Text) < 0)
                        tbx_light4Value.Text = "0";

                    tck_light4Value.Value = Convert.ToInt16(tbx_light4Value.Text.Trim());
                    lightTool.light4Brightness = Convert.ToInt16(tbx_light4Value.Text.Trim());
                }
                catch { }

                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].name == lightTool.light4Controller)
                    {
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light4Ch), lightTool.light4Brightness);
                        break;
                    }
                }

                if (!isBusying)
                {
                    Thread th1 = new Thread(() =>
                    {
                        isBusying = true;
                        ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                        Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                        isBusying = false;
                    });
                    th1.IsBackground = true;
                    th1.Start();
                }
            }
        }

        private void btn_light1OnOff_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == lightTool.light1Controller)
                {
                    if (btn_light1OnOff.Active)
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light1Ch), lightTool.light1Brightness);
                    else
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light1Ch), 0);

                    break;
                }
            }

            if (!isBusying)
            {
                Thread th1 = new Thread(() =>
                {
                    isBusying = true;
                    ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                    Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                    isBusying = false;
                });
                th1.IsBackground = true;
                th1.Start();
            }
        }
        private void btn_light2OnOff_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == lightTool.light2Controller)
                {
                    if (btn_light1OnOff.Active)
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light2Ch), lightTool.light2Brightness);
                    else
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light2Ch), 0);

                    break;
                }
            }

            if (!isBusying)
            {
                Thread th1 = new Thread(() =>
                {
                    isBusying = true;
                    ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                    Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                    isBusying = false;
                });
                th1.IsBackground = true;
                th1.Start();
            }
        }
        private void btn_light3OnOff_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == lightTool.light3Controller)
                {
                    if (btn_light1OnOff.Active)
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light3Ch), lightTool.light3Brightness);
                    else
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light3Ch), 0);

                    break;
                }
            }

            if (!isBusying)
            {
                Thread th1 = new Thread(() =>
                {
                    isBusying = true;
                    ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                    Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                    isBusying = false;
                });
                th1.IsBackground = true;
                th1.Start();
            }
        }
        private void btn_light4OnOff_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == lightTool.light4Controller)
                {
                    if (btn_light1OnOff.Active)
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light4Ch), lightTool.light4Brightness);
                    else
                        ((LightService)Project.Instance.L_Service[i]).lightBase.SetValue(Convert.ToInt16(lightTool.light4Ch), 0);

                    break;
                }
            }

            if (!isBusying)
            {
                Thread th1 = new Thread(() =>
                {
                    isBusying = true;
                    ((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).Run();
                    Instance.hWindow_Final1.HobjectToHimage(((ImageTool.ToolPar)((ImageTool)Task.curTask.FindToolByName(lightTool.cameraName)).参数).输出.图像);
                    isBusying = false;
                });
                th1.IsBackground = true;
                th1.Start();
            }
        }
        private void Frm_LightTool_ExtendBoxClick(object sender, EventArgs e)
        {
            Instance.TopMost = !Instance.TopMost;

            if (Instance.TopMost)
                Instance.ExtendSymbol = 61475;
            else
                Instance.ExtendSymbol = 61758;
        }
        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            lightTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }
    }
}
