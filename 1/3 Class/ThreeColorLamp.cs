using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Diagnostics;

namespace VM_Pro
{
    /// <summary>
    /// 三色灯控制类
    /// </summary>
    internal class ThreeColorLamp
    {

        /// <summary>
        /// 保持闪烁
        /// </summary>
        private static bool KeepShine = false;


        /// <summary>
        /// 关闭三色灯
        /// </summary>
        internal static void SetAllOff()
        {
            if (Project.FindServiceByName(Project.lightGreenCardName) != null)
            {
                ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.Off);
                ((CCard)Project.FindServiceByName(Project.lightRedCardName)).cardBase.SetDo(Project.lightRedIdx, OnOff.Off);
                ((CCard)Project.FindServiceByName(Project.lightYellowCardName)).cardBase.SetDo(Project.lightYellowIdx, OnOff.Off);
            }
        }
        /// <summary>
        /// 三色灯亮绿色
        /// </summary>
        /// <param name="shine">是否闪烁</param>
        internal static void SetGreen(bool colorShine, bool buzzerShine)
        {
            KeepShine = false;
            Thread.Sleep(600);

            if (!colorShine && !buzzerShine)
            {
                ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.On);
                ((CCard)Project.FindServiceByName(Project.lightRedCardName)).cardBase.SetDo(Project.lightRedIdx, OnOff.Off);
                ((CCard)Project.FindServiceByName(Project.lightYellowCardName)).cardBase.SetDo(Project.lightYellowIdx, OnOff.Off);
                ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.Off);
                Frm_Main.Instance.lbl_red.BackColor = Color.LightGray;
                Frm_Main.Instance.lbl_yellow.BackColor = Color.LightGray;
                Frm_Main.Instance.lbl_green.BackColor = Color.Green;
            }
            else if (colorShine && !buzzerShine)
            {
                KeepShine = true;
                Thread th = new Thread(() =>
                {
                    ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.Off);
                    ((CCard)Project.FindServiceByName(Project.lightRedCardName)).cardBase.SetDo(Project.lightRedIdx, OnOff.Off);
                    ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.Off);
                    Frm_Main.Instance.lbl_red.BackColor = Color.LightGray;
                    Frm_Main.Instance.lbl_yellow.BackColor = Color.LightGray;
                    Frm_Main.Instance.lbl_green.BackColor = Color.LightGray;
                    while (KeepShine)
                    {
                        ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.On);
                        Frm_Main.Instance.lbl_green.BackColor = Color.Green;
                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                        ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.Off);
                        Frm_Main.Instance.lbl_green.BackColor = Color.LightGray;
                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                    }
                });
                th.IsBackground = true;
                th.Start();
            }
            else if (colorShine && buzzerShine)
            {
                KeepShine = true;
                Thread th = new Thread(() =>
                {
                    ((CCard)Project.FindServiceByName(Project.lightYellowCardName)).cardBase.SetDo(Project.lightYellowIdx, OnOff.Off);
                    ((CCard)Project.FindServiceByName(Project.lightRedCardName)).cardBase.SetDo(Project.lightRedIdx, OnOff.Off);
                    ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.On);
                    Frm_Main.Instance.lbl_red.BackColor = Color.LightGray;
                    Frm_Main.Instance.lbl_yellow.BackColor = Color.LightGray;
                    Frm_Main.Instance.lbl_green.BackColor = Color.LightGray;
                    while (KeepShine)
                    {
                        ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.On);
                        Frm_Main.Instance.lbl_green.BackColor = Color.Green;
                        if (!Device.alarmReseted && Project.Instance.configuration.BuzzerEnable)
                            ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.On);
                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                        ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.Off);
                        Frm_Main.Instance.lbl_green.BackColor = Color.LightGray;
                        if (!Device.alarmReseted && Project.Instance.configuration.BuzzerEnable)
                            ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.Off);
                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                    }
                });
                th.IsBackground = true;
                th.Start();
            }
        }
        /// <summary>
        /// 三色灯亮黄色
        /// </summary>
        /// <param name="shine">是否闪烁</param>
        internal static void SetYellow(bool colorShine, bool buzzerShine)
        {
            KeepShine = false;
            Thread.Sleep(600);

            if (!colorShine && !buzzerShine)
            {
                ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.Off);
                ((CCard)Project.FindServiceByName(Project.lightRedCardName)).cardBase.SetDo(Project.lightRedIdx, OnOff.Off);
                ((CCard)Project.FindServiceByName(Project.lightYellowCardName)).cardBase.SetDo(Project.lightYellowIdx, OnOff.On);
                ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.Off);
                Frm_Main.Instance.lbl_red.BackColor = Color.LightGray;
                Frm_Main.Instance.lbl_yellow.BackColor = Color.Orange;
                Frm_Main.Instance.lbl_green.BackColor = Color.LightGray;
            }
            else if (colorShine && !buzzerShine)
            {
                KeepShine = true;
                Thread th = new Thread(() =>
                {
                    ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.Off);
                    ((CCard)Project.FindServiceByName(Project.lightRedCardName)).cardBase.SetDo(Project.lightRedIdx, OnOff.Off);
                    ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.Off);
                    Frm_Main.Instance.lbl_red.BackColor = Color.LightGray;
                    Frm_Main.Instance.lbl_yellow.BackColor = Color.LightGray;
                    Frm_Main.Instance.lbl_green.BackColor = Color.LightGray;
                    while (KeepShine)
                    {
                        ((CCard)Project.FindServiceByName(Project.lightYellowCardName)).cardBase.SetDo(Project.lightYellowIdx, OnOff.On);
                        Frm_Main.Instance.lbl_yellow.BackColor = Color.Orange;
                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                        ((CCard)Project.FindServiceByName(Project.lightYellowCardName)).cardBase.SetDo(Project.lightYellowIdx, OnOff.Off);
                        Frm_Main.Instance.lbl_yellow.BackColor = Color.LightGray;
                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                    }
                });
                th.IsBackground = true;
                th.Start();
            }
            else if (colorShine && buzzerShine)
            {
                KeepShine = true;
                Thread th = new Thread(() =>
                {
                    ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.Off);
                    ((CCard)Project.FindServiceByName(Project.lightRedCardName)).cardBase.SetDo(Project.lightRedIdx, OnOff.Off);
                    Frm_Main.Instance.lbl_red.BackColor = Color.LightGray;
                    Frm_Main.Instance.lbl_green.BackColor = Color.LightGray;
                    while (KeepShine)
                    {
                        ((CCard)Project.FindServiceByName(Project.lightYellowCardName)).cardBase.SetDo(Project.lightYellowIdx, OnOff.On);
                        Frm_Main.Instance.lbl_yellow.BackColor = Color.Orange;
                        if (!Device.alarmReseted && Project.Instance.configuration.BuzzerEnable)
                            ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.On);
                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                        ((CCard)Project.FindServiceByName(Project.lightYellowCardName)).cardBase.SetDo(Project.lightYellowIdx, OnOff.Off);
                        Frm_Main.Instance.lbl_yellow.BackColor = Color.LightGray;
                        ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.Off);
                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                    }
                });
                th.IsBackground = true;
                th.Start();
            }
            else if (!colorShine && buzzerShine)
            {
                KeepShine = true;
                Thread th = new Thread(() =>
                {
                    ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.Off);
                    ((CCard)Project.FindServiceByName(Project.lightRedCardName)).cardBase.SetDo(Project.lightRedIdx, OnOff.Off);
                    ((CCard)Project.FindServiceByName(Project.lightYellowCardName)).cardBase.SetDo(Project.lightYellowIdx, OnOff.On);
                    ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.Off);
                    Frm_Main.Instance.lbl_red.BackColor = Color.LightGray;
                    Frm_Main.Instance.lbl_yellow.BackColor = Color.Orange;
                    Frm_Main.Instance.lbl_green.BackColor = Color.LightGray;
                    while (KeepShine)
                    {
                        if (!Device.alarmReseted && Project.Instance.configuration.BuzzerEnable)
                            ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.On);
                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                        ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.Off);
                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                    }
                });
                th.IsBackground = true;
                th.Start();
            }
        }
        /// <summary>
        /// 三色灯亮红灯
        /// </summary>
        /// <param name="shine">是否闪烁</param>
        internal static void SetRed(bool colorShine, bool buzzerShine)
        {
            KeepShine = false;
            Thread.Sleep(600);

            if (!colorShine && !buzzerShine)
            {
                ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.Off);
                ((CCard)Project.FindServiceByName(Project.lightRedCardName)).cardBase.SetDo(Project.lightRedIdx, OnOff.On);
                ((CCard)Project.FindServiceByName(Project.lightYellowCardName)).cardBase.SetDo(Project.lightYellowIdx, OnOff.Off);
                if (!Device.alarmReseted && Project.Instance.configuration.BuzzerEnable)
                    ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.On);
                Frm_Main.Instance.lbl_red.BackColor = Color.Red;
                Frm_Main.Instance.lbl_yellow.BackColor = Color.LightGray;
                Frm_Main.Instance.lbl_green.BackColor = Color.LightGray;
            }
            else if (colorShine && !buzzerShine)
            {
                KeepShine = true;
                Thread th = new Thread(() =>
                {
                    ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.Off);
                    ((CCard)Project.FindServiceByName(Project.lightYellowCardName)).cardBase.SetDo(Project.lightYellowIdx, OnOff.Off);
                    ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.Off);
                    Frm_Main.Instance.lbl_red.BackColor = Color.LightGray;
                    Frm_Main.Instance.lbl_yellow.BackColor = Color.LightGray;
                    Frm_Main.Instance.lbl_green.BackColor = Color.LightGray;
                    while (KeepShine)
                    {
                        ((CCard)Project.FindServiceByName(Project.lightRedCardName)).cardBase.SetDo(Project.lightRedIdx, OnOff.On);
                        Frm_Main.Instance.lbl_red.BackColor = Color.Red;
                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                        ((CCard)Project.FindServiceByName(Project.lightRedCardName)).cardBase.SetDo(Project.lightRedIdx, OnOff.Off);
                        Frm_Main.Instance.lbl_red.BackColor = Color.LightGray;
                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                    }
                });
                th.IsBackground = true;
                th.Start();
            }
            else if (colorShine && buzzerShine)
            {
                KeepShine = true;
                Thread th = new Thread(() =>
                {
                    ServiceBase card = Project.FindServiceByName(Project.lightGreenCardName);
                    if (card != null)
                        ((CCard)card).cardBase.SetDo(Project.lightGreenIdx, OnOff.Off);

                    card = Project.FindServiceByName(Project.lightYellowCardName);
                    if (card != null)
                        ((CCard)card).cardBase.SetDo(Project.lightYellowIdx, OnOff.Off);

                    Frm_Main.Instance.lbl_yellow.BackColor = Color.LightGray;
                    Frm_Main.Instance.lbl_green.BackColor = Color.LightGray;
                    while (KeepShine)
                    {
                        card = Project.FindServiceByName(Project.lightRedCardName);
                        if (card != null)
                            ((CCard)card).cardBase.SetDo(Project.lightRedIdx, OnOff.On);

                        Frm_Main.Instance.lbl_red.BackColor = Color.Red;

                        card = Project.FindServiceByName(Project.buzzerCardName);
                        if (card != null && !Device.alarmReseted && Project.Instance.configuration.BuzzerEnable)
                            ((CCard)card).cardBase.SetDo(Project.buzzerIdx, OnOff.On);

                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);

                        card = Project.FindServiceByName(Project.lightRedCardName);
                        if (card != null)
                            ((CCard)card).cardBase.SetDo(Project.lightRedIdx, OnOff.Off);

                        Frm_Main.Instance.lbl_red.BackColor = Color.LightGray;

                        card = Project.FindServiceByName(Project.buzzerCardName);
                        if (card != null)
                            ((CCard)card).cardBase.SetDo(Project.buzzerIdx, OnOff.Off);

                        if (!KeepShine)
                            break;
                        Thread.Sleep(500);
                    }
                });
                th.IsBackground = true;
                th.Start();
            }
        }
        internal static void CloseAllLight()
        {
            KeepShine = false;
            ((CCard)Project.FindServiceByName(Project.lightRedCardName)).cardBase.SetDo(Project.lightRedIdx, OnOff.Off);
            ((CCard)Project.FindServiceByName(Project.lightGreenCardName)).cardBase.SetDo(Project.lightGreenIdx, OnOff.Off);
            ((CCard)Project.FindServiceByName(Project.lightYellowCardName)).cardBase.SetDo(Project.lightYellowIdx, OnOff.Off);
            ((CCard)Project.FindServiceByName(Project.buzzerCardName)).cardBase.SetDo(Project.buzzerIdx, OnOff.Off);
            Frm_Main.Instance.lbl_red.BackColor = Color.LightGray;
            Frm_Main.Instance.lbl_yellow.BackColor = Color.LightGray;
            Frm_Main.Instance.lbl_green.BackColor = Color.LightGray;
        }
    }
}
