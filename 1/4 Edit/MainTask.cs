using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Tool;


namespace VM_Pro
{
    /// <summary>
    /// 主逻辑类，用户按照此类编写自己具体项目的主逻辑
    /// </summary>
    internal class MainTask
    {

        #region 相关变量

        /// <summary>
        /// 上次贴合的工位
        /// </summary>
        internal static bool lastAssemblyIsLeftStation = false;
        /// <summary>
        /// 首次低速运行
        /// </summary>
        internal static bool firstLowVel = true;
        /// <summary>
        /// 当前产品加工完毕后停止
        /// </summary>
        internal static bool stopCurFinished = false;
        /// <summary>
        /// 统计信息读写Ini
        /// </summary>
        private static Ini ini = new Ini(System.Windows.Forms.Application.StartupPath + "\\Count.ini");
        /// <summary>
        /// CT时间
        /// </summary>
        internal static double CT = 0;
        /// <summary>
        /// CT统计
        /// </summary>
        internal static Stopwatch sw_ct = new Stopwatch();
        /// <summary>
        /// 安全开关是否被触发
        /// </summary>
        internal static bool saftyDoorTriged = false;
        /// <summary>
        /// 急停按下
        /// </summary>
        internal static bool EMGTriged = false;

        #endregion

        #region 相关方法

        /// <summary>
        /// 初始化所有轴和IO
        /// </summary>
        public static void InitAll()
        {
            FuncLib.AddDi("运动控制卡", 1, Di.启动_C1In00);
            FuncLib.AddDi("运动控制卡", 2, Di.复位_C1In01);
            FuncLib.AddDi("运动控制卡", 3, Di.停止_C1In02);
            FuncLib.AddDi("运动控制卡", 4, Di.急停_C1In03);
            FuncLib.AddDi("运动控制卡", 5, Di.安全门_C1In04);
            FuncLib.AddDi("运动控制卡", 6, Di.总气压表_C1In05);
            FuncLib.AddDi("运动控制卡", 7, Di.备用1_C1In06);
            FuncLib.AddDi("运动控制卡", 8, Di.备用2_C1In07);

            FuncLib.AddDi("运动控制卡", 9, Di.左启动_C1In10);
            FuncLib.AddDi("运动控制卡", 10, Di.启动_C1In11);
            FuncLib.AddDi("运动控制卡", 11, Di.右启动_C1In12);
            FuncLib.AddDiVitual("运动控制卡", 12, Di.左工位真空检_C1In13);
            FuncLib.AddDiVitual("运动控制卡", 13, Di.右工位真空检_C1In14);
            FuncLib.AddDiVitual("运动控制卡", 14, Di.贴膜吸真空检_C1In15);
            FuncLib.AddDiVitual("运动控制卡", 15, Di.贴膜压边气缸上位检_C1In16);
            FuncLib.AddDiVitual("运动控制卡", 16, Di.贴膜压边气缸下位检_C1In17);

            FuncLib.AddDiVitual("运动控制卡", 17, Di.吸膜抖料气缸1上位检_E1In20);
            FuncLib.AddDiVitual("运动控制卡", 18, Di.吸膜抖料气缸1下位检_E1In21);
            FuncLib.AddDiVitual("运动控制卡", 19, Di.吸膜抖料气缸2上位检_E1In22);
            FuncLib.AddDiVitual("运动控制卡", 20, Di.吸膜抖料气缸2下位检_E1In23);
            FuncLib.AddDi("运动控制卡", 21, Di.色标传感器_E1In24);
            FuncLib.AddDi("运动控制卡", 22, Di.检测膜传感器_E1In25);
            FuncLib.AddDi("运动控制卡", 23, Di.膜片有无检测_E1In26);
            FuncLib.AddDi("运动控制卡", 24, Di.膜片上升到位传感器_E1In27);

            FuncLib.AddDiVitual("运动控制卡", 25, Di.中转平台吸真空检1_E1In30);
            FuncLib.AddDiVitual("运动控制卡", 26, Di.中转平台吸真空检2_E1In31);
            FuncLib.AddDiVitual("运动控制卡", 27, Di.中转平台吸真空检3_E1In32);
            FuncLib.AddDiVitual("运动控制卡", 28, Di.中转平台吸真空检4_E1In33);
            FuncLib.AddDiVitual("运动控制卡", 29, Di.中转平台吸真空检5_E1In34);
            FuncLib.AddDiVitual("运动控制卡", 30, Di.中转平台吸真空检6_E1In35);
            FuncLib.AddDiVitual("运动控制卡", 31, Di.取膜吸真空检1_E1In36);
            FuncLib.AddDiVitual("运动控制卡", 32, Di.取膜吸真空检2_E1In37);

            FuncLib.AddDiVitual("运动控制卡", 33, Di.取膜吸真空检3_E1In40);
            FuncLib.AddDi("运动控制卡", 34, Di.备用3_E1In41);
            FuncLib.AddDi("运动控制卡", 35, Di.备用4_E1In42);
            FuncLib.AddDi("运动控制卡", 36, Di.左胶量检测_E1In43);
            FuncLib.AddDi("运动控制卡", 37, Di.右胶量检测_E1In44);
            FuncLib.AddDiVitual("运动控制卡", 38, Di.撕膜固定气缸上位检1_E1In45);
            FuncLib.AddDiVitual("运动控制卡", 39, Di.撕膜固定气缸下位检1_E1In46);
            FuncLib.AddDiVitual("运动控制卡", 40, Di.撕膜固定气缸上位检2_E1In47);

            FuncLib.AddDiVitual("运动控制卡", 41, Di.撕膜固定气缸下位检2_E1In50);
            FuncLib.AddDiVitual("运动控制卡", 42, Di.撕膜气缸上位检1_E1In51);
            FuncLib.AddDiVitual("运动控制卡", 43, Di.撕膜气缸下位检1_E1In52);
            FuncLib.AddDiVitual("运动控制卡", 44, Di.撕膜气缸上位检2_E1In53);
            FuncLib.AddDiVitual("运动控制卡", 45, Di.撕膜气缸下位检2_E1In54);
            FuncLib.AddDiVitual("运动控制卡", 46, Di.左工位吸胶真空检_E1In55);
            FuncLib.AddDiVitual("运动控制卡", 47, Di.右工位吸胶真空检_E1In56);
            FuncLib.AddDi("运动控制卡", 48, Di.备用5_E1In57);

            FuncLib.AddDi("运动控制卡", 49, Di.左安全光栅_E1In60);
            FuncLib.AddDi("运动控制卡", 50, Di.右安全光栅_E1In61);
            FuncLib.AddDi("运动控制卡", 51, Di.搬运光栅_E1In62);


            FuncLib.AddDo("运动控制卡", 1, Do.启动灯_C1Out00);
            FuncLib.AddDo("运动控制卡", 2, Do.复位灯_C1Out01);
            FuncLib.AddDo("运动控制卡", 3, Do.停止灯_C1Out02);
            FuncLib.AddDo("运动控制卡", 4, Do.三色灯_黄_C1Out03);
            FuncLib.AddDo("运动控制卡", 5, Do.三色灯_绿_C1Out04);
            FuncLib.AddDo("运动控制卡", 6, Do.三色灯_红_C1Out05);
            FuncLib.AddDo("运动控制卡", 7, Do.蜂鸣器_C1Out06);
            FuncLib.AddDo("运动控制卡", 8, Do.照明灯_C1Out07);

            FuncLib.AddDoVitual("运动控制卡", 9, Do.左工位吸真空_C1Out10);
            FuncLib.AddDoVitual("运动控制卡", 10, Do.左工位破真空_C1Out11);
            FuncLib.AddDoVitual("运动控制卡", 11, Do.右工位吸真空_C1Out12);
            FuncLib.AddDoVitual("运动控制卡", 12, Do.右工位破真空_C1Out13);
            FuncLib.AddDo("运动控制卡", 13, Do.左点胶上光源_C1Out14);
            FuncLib.AddDo("运动控制卡", 14, Do.右点胶开始_C1Out15);
            FuncLib.AddDo("运动控制卡", 15, Do.左点胶结束_C1Out16);
            FuncLib.AddDo("运动控制卡", 16, Do.备用1_C1Out17);

            FuncLib.AddDo("运动控制卡", 17, Do.右点胶上光源_C1Out20);
            FuncLib.AddDo("运动控制卡", 18, Do.左点胶开始_C1Out21);
            FuncLib.AddDo("运动控制卡", 19, Do.右点胶结束_C1Out22);
            FuncLib.AddDo("运动控制卡", 20, Do.备用2_C1Out23);
            FuncLib.AddDo("运动控制卡", 21, Do.上光源_C1Out24);
            FuncLib.AddDoVitual("运动控制卡", 22, Do.贴膜压边气缸上_C1Out25);
            FuncLib.AddDoVitual("运动控制卡", 23, Do.贴膜压边气缸下_C1Out26);
            FuncLib.AddDoVitual("运动控制卡", 24, Do.贴膜吸真空_C1Out27);

            FuncLib.AddDoVitual("运动控制卡", 25, Do.贴膜破真空_C1Out30);
            FuncLib.AddDoVitual("运动控制卡", 26, Do.吸膜抖料气缸1_C1Out31);
            FuncLib.AddDoVitual("运动控制卡", 27, Do.吸膜抖料气缸2_C1Out32);
            FuncLib.AddDo("运动控制卡", 28, Do.下光源_C1Out33);
            FuncLib.AddDo("运动控制卡", 29, Do.备用3_C1Out34);
            FuncLib.AddDo("运动控制卡", 30, Do.备用4_C1Out35);
            FuncLib.AddDo("运动控制卡", 31, Do.备用5_C1Out36);
            FuncLib.AddDoVitual("运动控制卡", 32, Do.取膜吸真空1_C1Out37);

            FuncLib.AddDoVitual("运动控制卡", 33, Do.取膜吸真空2_C1Out40);
            FuncLib.AddDoVitual("运动控制卡", 34, Do.取膜吸真空3_C1Out41);
            FuncLib.AddDoVitual("运动控制卡", 35, Do.取膜破真空1_C1Out42);
            FuncLib.AddDoVitual("运动控制卡", 36, Do.取膜破真空2_C1Out43);
            FuncLib.AddDoVitual("运动控制卡", 37, Do.取膜破真空3_C1Out44);
            FuncLib.AddDoVitual("运动控制卡", 38, Do.中转平台吸真空1_C1Out45);
            FuncLib.AddDoVitual("运动控制卡", 39, Do.中转平台吸真空2_C1Out46);
            FuncLib.AddDoVitual("运动控制卡", 40, Do.中转平台吸真空3_C1Out47);

            FuncLib.AddDoVitual("运动控制卡", 41, Do.中转平台吸真空4_C1Out50);
            FuncLib.AddDoVitual("运动控制卡", 42, Do.中转平台吸真空5_C1Out51);
            FuncLib.AddDoVitual("运动控制卡", 43, Do.中转平台吸真空6_C1Out52);
            FuncLib.AddDoVitual("运动控制卡", 44, Do.中转平台破真空1_C1Out53);
            FuncLib.AddDoVitual("运动控制卡", 45, Do.中转平台破真空2_C1Out54);
            FuncLib.AddDoVitual("运动控制卡", 46, Do.中转平台破真空3_C1Out55);
            FuncLib.AddDoVitual("运动控制卡", 47, Do.中转平台破真空4_C1Out56);
            FuncLib.AddDoVitual("运动控制卡", 48, Do.中转平台破真空5_C1Out57);

            FuncLib.AddDoVitual("运动控制卡", 49, Do.中转平台破真空6_C1Out60);
            FuncLib.AddDoVitual("运动控制卡", 50, Do.左点胶吸胶_C1Out61);
            FuncLib.AddDoVitual("运动控制卡", 51, Do.右点胶吸胶_C1Out62);
            FuncLib.AddDoVitual("运动控制卡", 52, Do.撕膜固定气缸上_C1Out63);
            FuncLib.AddDoVitual("运动控制卡", 53, Do.撕膜固定气缸下_C1Out64);
            FuncLib.AddDoVitual("运动控制卡", 54, Do.撕膜气缸上_C1Out65);
            FuncLib.AddDoVitual("运动控制卡", 55, Do.撕膜气缸下_C1Out66);
            FuncLib.AddDo("运动控制卡", 56, Do.离子风_C1Out67);


            FuncLib.BindStart("运动控制卡", 1);
            FuncLib.BindStop("运动控制卡", 3);
            FuncLib.BindReset("运动控制卡", 2);
            FuncLib.BindEMG("运动控制卡", 4);
            FuncLib.BindSafeDoor("运动控制卡", 5);
            FuncLib.BindLightRed("运动控制卡", 6);
            FuncLib.BindLightYellow("运动控制卡", 5);
            FuncLib.BindLightGreen("运动控制卡", 4);
            FuncLib.BindBuzzer("运动控制卡", 7);
            FuncLib.BindLight("运动控制卡", 8);

            FuncLib.AddCylinder1("运动控制卡", "运动控制卡", "运动控制卡", "运动控制卡", 22, 23, 15, 16, "贴膜压边气缸");
            FuncLib.AddCylinder1("运动控制卡", "运动控制卡", "运动控制卡", "运动控制卡", 26, -1, 17, 18, "吸膜抖料气缸1");
            FuncLib.AddCylinder1("运动控制卡", "运动控制卡", "运动控制卡", "运动控制卡", 27, -1, 19, 20, "吸膜抖料气缸2");

            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 24, -1, 14, "贴膜吸真空");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 9, -1, 12, "左工位吸真空");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 11, -1, 13, "右工位吸真空");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 50, -1, 46, "左工位吸胶");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 51, -1, 47, "右工位吸胶");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 38, 44, 25, "中转平台吸真空1");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 39, 45, 26, "中转平台吸真空2");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 40, 46, 27, "中转平台吸真空3");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 41, 47, 28, "中转平台吸真空4");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 42, 48, 39, "中转平台吸真空5");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 43, 49, 30, "中转平台吸真空6");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 32, 35, 31, "搬运真空1");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 33, 36, 32, "搬运真空2");
            FuncLib.AddVacuum("运动控制卡", "运动控制卡", "运动控制卡", 34, 37, 33, "搬运真空3");


            FuncLib.AddAxis("运动控制卡", 0, Axis.X1);
            FuncLib.AddAxis("运动控制卡", 1, Axis.X2);
            FuncLib.AddAxis("运动控制卡", 2, Axis.Z1);
            FuncLib.AddAxis("运动控制卡", 3, Axis.Z2);
            FuncLib.AddAxis("运动控制卡", 4, Axis.Y1);
            FuncLib.AddAxis("运动控制卡", 5, Axis.Y2);
            FuncLib.AddAxis("运动控制卡", 6, Axis.贴合X);
            FuncLib.AddAxis("运动控制卡", 7, Axis.贴合Z);
            FuncLib.AddAxis("运动控制卡", 8, Axis.贴合R);
            FuncLib.AddAxis("运动控制卡", 9, Axis.搬运Y);
            FuncLib.AddAxis("运动控制卡", 10, Axis.搬运Z);
            FuncLib.AddAxis("运动控制卡", 11, Axis.相机移动轴);
            FuncLib.AddAxis("运动控制卡", 12, Axis.上料Z);
        }
        /// <summary>
        /// 复位所有任务
        /// </summary>
        public static void HomeAll()
        {
            try
            {
                statu_leftFeedGlassTask = LeftFeedGlassTaskStatu.Init;
                statu_rightFeedGlassTask = RightFeedGlassTaskStatu.Init;
                statu_carryFilmTask = CarryFilmTaskStatu.Init;
                statu_loadFilmTask = LoadFilmTaskStatu.Init;
                if (Device.emgHasTriged)
                {
                    Device.emgHasTriged = false;
                    FuncLib.ShowMsg("急停已触发，总线正在重新连接，请稍后......");
                    ((CCard)Project.FindServiceByName("运动控制卡")).cardBase.Init("运动控制卡");
                    Thread.Sleep(200);
                }

                if (th_feedGlassLeftTask != null && th_feedGlassLeftTask.IsAlive)
                {
                    FuncLib.ShowMsg("左工位上玻璃片任务状态异常，请检查", InfoType.Error);
                    Device.machineHomeResult = 1;
                    return;
                }
                if (th_feedGlassRightTask != null && th_feedGlassRightTask.IsAlive)
                {
                    FuncLib.ShowMsg("右工位上玻璃片任务状态异常，请检查", InfoType.Error);
                    Device.machineHomeResult = 1;
                    return;
                }
                if (th_leftGlueTask != null && th_leftGlueTask.IsAlive)
                {
                    FuncLib.ShowMsg("左工位点胶任务状态异常，请检查", InfoType.Error);
                    Device.machineHomeResult = 1;
                    return;
                }
                if (th_rightGlueTask != null && th_rightGlueTask.IsAlive)
                {
                    FuncLib.ShowMsg("右工位点胶任务状态异常，请检查", InfoType.Error);
                    Device.machineHomeResult = 1;
                    return;
                }
                if (th_loadFilmTask != null && th_loadFilmTask.IsAlive)
                {
                    FuncLib.ShowMsg("玻璃片顶升任务状态异常，请检查", InfoType.Error);
                    Device.machineHomeResult = 1;
                    return;
                }
                if (th_carryFilmTask != null && th_carryFilmTask.IsAlive)
                {
                    FuncLib.ShowMsg("搬运玻璃片任务状态异常，请检查", InfoType.Error);
                    Device.machineHomeResult = 1;
                    return;
                }
                if (th_filmRobotTask != null && th_filmRobotTask.IsAlive)
                {
                    FuncLib.ShowMsg("机械手任务状态异常，请检查", InfoType.Error);
                    Device.machineHomeResult = 1;
                    return;
                }

                //检测急停按钮是否被按下
                if (FuncLib.GetDiSts(Di.急停_C1In03) == OnOff.Off)
                {
                    FuncLib.ShowMsg("系统检测到急停已按下，请松开急停", InfoType.Error);
                    Device.machineHomeResult = 1;
                    return;
                }

                //光源关
                FuncLib.SetDo(Do.左点胶上光源_C1Out14, OnOff.Off);
                FuncLib.SetDo(Do.右点胶上光源_C1Out20, OnOff.Off);
                FuncLib.SetDo(Do.下光源_C1Out33, OnOff.Off);
                FuncLib.SetDo(Do.上光源_C1Out24, OnOff.Off);

                //停止一切运动
                FuncLib.DecStop(Axis.X1);
                FuncLib.DecStop(Axis.X2);
                FuncLib.DecStop(Axis.Y1);
                FuncLib.DecStop(Axis.Y2);
                FuncLib.DecStop(Axis.Z1);
                FuncLib.DecStop(Axis.Z2);
                FuncLib.DecStop(Axis.贴合X);
                FuncLib.DecStop(Axis.贴合Z);
                FuncLib.DecStop(Axis.贴合R);
                FuncLib.DecStop(Axis.搬运Y);
                FuncLib.DecStop(Axis.搬运Z);
                FuncLib.DecStop(Axis.相机移动轴);
                FuncLib.DecStop(Axis.上料Z);

                //任务初始化
                step_feedGlassLeftTask = 0;
                step_feedGlassRightTask = 0;
                step_leftGlueTask = 0;
                step_rightGlueTask = 0;
                step_filmTobotTask = 0;
                step_carryFilmTask = 0;
                step_loadFilmTask = 0;


                #region 左工位点胶任务复位
                Thread th_leftGlueTaskHome = new Thread(() =>
              {
                  home_leftGlueTask = 0;
                  FuncLib.ShowMsg("[ 左工位点胶任务 ] 开始复位");

                  if (!FuncLib.Home(Axis.Z1))
                  {
                      home_leftGlueTask = 1;
                      FuncLib.ShowMsg("[ 左工位点胶任务 ] 左工位点胶Z轴回零失败，请检查！", InfoType.Error);
                      return;
                  }

                  if (!FuncLib.Home(Axis.X1))
                  {
                      home_leftGlueTask = 1;
                      FuncLib.ShowMsg("[ 左工位点胶任务 ] 左工位点胶X轴回零失败，请检查！", InfoType.Error);
                      return;
                  }

                  #region 贴膜机械手任务复位
                  Thread th_filmRobotTaskHome = new Thread(() =>
                  {
                      home_filmRobotTask = 0;
                      FuncLib.ShowMsg("[ 贴膜机械手任务 ] 开始复位");

                      //检测机械手人当前是否吸的有膜片，如有膜片，要求人为拿下来，如没有膜片，那就关闭机械手吸盘真空
                      if (FuncLib.GetDiSts(Di.贴膜吸真空检_C1In15) == OnOff.On)
                      {
                          home_filmRobotTask = 1;
                          FuncLib.ShowMsg("[ 贴膜机械手任务 ] 检测到机械手上已吸取膜片，请手动取下", InfoType.Error);
                          return;
                      }

                      FuncLib.SetDo(Do.贴膜破真空_C1Out30, OnOff.Off);
                      FuncLib.SetDo(Do.贴膜吸真空_C1Out27, OnOff.Off);


                      if (!FuncLib.Home(Axis.贴合Z))
                      {
                          home_filmRobotTask = 1;
                          FuncLib.ShowMsg("[ 贴膜机械手任务 ]贴合Z回安全位失败，请检查！", InfoType.Error);
                          return;
                      }


                      #region 左工位上玻璃片任务复位
                      Thread th_feedGlassLeftTaskHome = new Thread(() =>
                      {
                          home_feedGlassLeftTask = 0;
                          FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 开始复位");

                          //检查组装平台是否有玻璃片
                          FuncLib.SetDo(Do.左工位破真空_C1Out11, OnOff.Off);
                          FuncLib.SetDo(Do.左工位吸真空_C1Out10, OnOff.On);
                          Thread.Sleep(200);
                          if (FuncLib.GetDiSts(Di.左工位真空检_C1In13) == OnOff.On)
                          {
                              FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 产品组装工作台存在玻璃片，请手动取走！", InfoType.Warn);
                              FuncLib.ShowBigTip("左工位上料工作台存在玻璃片，请手动取走！");
                              FuncLib.GoToPos("YL", "上料位");
                              FuncLib.SetDo(Do.左工位吸真空_C1Out10, OnOff.Off);
                          }
                          FuncLib.SetDo(Do.左工位吸真空_C1Out10, OnOff.Off);

                          if (!FuncLib.Home(Axis.Y1))
                          {
                              home_feedGlassLeftTask = 1;
                              FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 左工位上玻璃片轴回零失败，请检查！", InfoType.Error);
                              return;
                          }

                          home_feedGlassLeftTask = 2;
                      });
                      th_feedGlassLeftTaskHome.IsBackground = true;
                      th_feedGlassLeftTaskHome.Start();
                      #endregion

                      #region 右工位上玻璃片任务复位
                      Thread th_feedGlassRightTaskHome = new Thread(() =>
                      {
                          home_feedGlassRightTask = 0;
                          FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 开始复位");

                          //检查组装平台是否有玻璃片
                          FuncLib.SetDo(Do.右工位破真空_C1Out13, OnOff.Off);
                          FuncLib.SetDo(Do.右工位吸真空_C1Out12, OnOff.On);
                          Thread.Sleep(200);
                          if (FuncLib.GetDiSts(Di.右工位真空检_C1In14) == OnOff.On)
                          {
                              FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 产品组装工作台存在玻璃片，请手动取走！", InfoType.Warn);
                              FuncLib.ShowBigTip("右工位上料工作台存在玻璃片，请手动取走！");
                              FuncLib.GoToPos("YR", "上料位");
                              FuncLib.SetDo(Do.右工位吸真空_C1Out12, OnOff.Off);
                          }
                          FuncLib.SetDo(Do.右工位吸真空_C1Out12, OnOff.Off);

                          if (!FuncLib.Home(Axis.Y2))
                          {
                              home_feedGlassRightTask = 1;
                              FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 右工位上玻璃片轴回零失败，请检查！", InfoType.Error);
                              return;
                          }

                          home_feedGlassRightTask = 2;
                      });
                      th_feedGlassRightTaskHome.IsBackground = true;
                      th_feedGlassRightTaskHome.Start();
                      #endregion


                      if (!FuncLib.Home(Axis.贴合R))
                      {
                          home_filmRobotTask = 1;
                          FuncLib.ShowMsg("[ 贴膜机械手任务 ]贴合R回安全位失败，请检查！", InfoType.Error);
                          return;
                      }

                      if (!FuncLib.Home(Axis.贴合X))
                      {
                          home_filmRobotTask = 1;
                          FuncLib.ShowMsg("[ 贴膜机械手任务 ]贴合X回安全位失败，请检查！", InfoType.Error);
                          return;
                      }

                      if (!FuncLib.GoToPos("贴合机械手", "安全位"))
                      {
                          home_filmRobotTask = 1;
                          FuncLib.ShowMsg("[ 贴膜机械手任务 ] 贴膜机械手前往安全位失败，请检查！", InfoType.Error);
                          return;
                      }
                      filmRobotInSafetyRegion = true;

                      home_filmRobotTask = 2;
                  });
                  th_filmRobotTaskHome.IsBackground = true;
                  th_filmRobotTaskHome.Start();
                  #endregion

                  home_leftGlueTask = 2;
              });
                th_leftGlueTaskHome.IsBackground = true;
                th_leftGlueTaskHome.Start();
                #endregion

                #region 右工位点胶任务复位
                Thread th_rightGlueTaskHome = new Thread(() =>
                {
                    home_rightGlueTask = 0;
                    FuncLib.ShowMsg("[ 右工位点胶任务 ] 开始复位");

                    if (!FuncLib.Home(Axis.Z2))
                    {
                        home_rightGlueTask = 1;
                        FuncLib.ShowMsg("[ 右工位点胶任务 ] 右工位点胶Z轴回零失败，请检查！", InfoType.Error);
                        return;
                    }

                    if (!FuncLib.Home(Axis.X2))
                    {
                        home_rightGlueTask = 1;
                        FuncLib.ShowMsg("[ 右工位点胶任务 ] 右工位点胶X轴回零失败，请检查！", InfoType.Error);
                        return;
                    }

                    home_rightGlueTask = 2;
                });
                th_rightGlueTaskHome.IsBackground = true;
                th_rightGlueTaskHome.Start();
                #endregion

                #region 膜片搬运任务
                Thread th_carryFilmTaskHome = new Thread(() =>
                {
                    home_carryFilmTask = 0;
                    FuncLib.ShowMsg("[ 膜片搬运任务 ] 开始复位");

                    FuncLib.SetOff(Do.离子风_C1Out67);

                    //检查中转平台是否有膜片
                    FuncLib.SetDo(Do.中转平台破真空1_C1Out53, OnOff.Off);
                    FuncLib.SetDo(Do.中转平台破真空2_C1Out54, OnOff.Off);
                    FuncLib.SetDo(Do.中转平台破真空3_C1Out55, OnOff.Off);
                    FuncLib.SetDo(Do.中转平台破真空4_C1Out56, OnOff.Off);
                    FuncLib.SetDo(Do.中转平台破真空5_C1Out57, OnOff.Off);
                    FuncLib.SetDo(Do.中转平台破真空6_C1Out60, OnOff.Off);

                    FuncLib.SetDo(Do.中转平台吸真空1_C1Out45, OnOff.On);
                    FuncLib.SetDo(Do.中转平台吸真空2_C1Out46, OnOff.On);
                    FuncLib.SetDo(Do.中转平台吸真空3_C1Out47, OnOff.On);
                    FuncLib.SetDo(Do.中转平台吸真空4_C1Out50, OnOff.On);
                    FuncLib.SetDo(Do.中转平台吸真空5_C1Out51, OnOff.On);
                    FuncLib.SetDo(Do.中转平台吸真空6_C1Out52, OnOff.On);
                    Thread.Sleep(200);
                    if (FuncLib.GetDiSts(Di.中转平台吸真空检1_E1In30) == OnOff.On || FuncLib.GetDiSts(Di.中转平台吸真空检2_E1In31) == OnOff.On || FuncLib.GetDiSts(Di.中转平台吸真空检3_E1In32) == OnOff.On || FuncLib.GetDiSts(Di.中转平台吸真空检4_E1In33) == OnOff.On || FuncLib.GetDiSts(Di.中转平台吸真空检5_E1In34) == OnOff.On || FuncLib.GetDiSts(Di.中转平台吸真空检6_E1In35) == OnOff.On)
                    {
                        home_carryFilmTask = 1;
                        FuncLib.SetDo(Do.中转平台吸真空1_C1Out45, OnOff.Off);
                        FuncLib.SetDo(Do.中转平台吸真空2_C1Out46, OnOff.Off);
                        FuncLib.SetDo(Do.中转平台吸真空3_C1Out47, OnOff.Off);
                        FuncLib.SetDo(Do.中转平台吸真空4_C1Out50, OnOff.Off);
                        FuncLib.SetDo(Do.中转平台吸真空5_C1Out51, OnOff.Off);
                        FuncLib.SetDo(Do.中转平台吸真空6_C1Out52, OnOff.Off);
                        FuncLib.ShowMsg("[ 膜片搬运任务 ]中转平台存膜片，请手动取走！", InfoType.Error);
                        FuncLib.ShowBigTip("中转平台存膜片，请手动取走！");
                        return;
                    }
                    FuncLib.SetDo(Do.中转平台吸真空1_C1Out45, OnOff.Off);
                    FuncLib.SetDo(Do.中转平台吸真空2_C1Out46, OnOff.Off);
                    FuncLib.SetDo(Do.中转平台吸真空3_C1Out47, OnOff.Off);
                    FuncLib.SetDo(Do.中转平台吸真空4_C1Out50, OnOff.Off);
                    FuncLib.SetDo(Do.中转平台吸真空5_C1Out51, OnOff.Off);
                    FuncLib.SetDo(Do.中转平台吸真空6_C1Out52, OnOff.Off);

                    //检测膜片搬运机械手人当前是否吸的有膜片，如有膜片，要求人为拿下来，如没有膜片，那就关闭机械手吸盘真空
                    if (FuncLib.GetDiSts(Di.取膜吸真空检1_E1In36) == OnOff.On || FuncLib.GetDiSts(Di.取膜吸真空检2_E1In37) == OnOff.On || FuncLib.GetDiSts(Di.取膜吸真空检3_E1In40) == OnOff.On)
                    {
                        home_carryFilmTask = 1;
                        FuncLib.ShowMsg("[ 膜片搬运任务 ] 启动前检测到机械手上已吸取膜片，请手动取下", InfoType.Error);
                        return;
                    }

                    FuncLib.SetDo(Do.取膜破真空1_C1Out42, OnOff.Off);
                    FuncLib.SetDo(Do.取膜破真空2_C1Out43, OnOff.Off);
                    FuncLib.SetDo(Do.取膜破真空3_C1Out44, OnOff.Off);

                    FuncLib.SetDo(Do.取膜吸真空1_C1Out37, OnOff.Off);
                    FuncLib.SetDo(Do.取膜吸真空2_C1Out40, OnOff.Off);
                    FuncLib.SetDo(Do.取膜吸真空3_C1Out41, OnOff.Off);

                    //机械手回安全位
                    if (!CarryRobotGoSafetyPos())
                    {
                        home_carryFilmTask = 1;
                        FuncLib.ShowMsg("[ 膜片搬运任务 ] 启动前机械手回安全位失败，请检查！", InfoType.Error);
                        return;
                    }
                    carryRobotInSafetyRegion = true;

                    home_carryFilmTask = 2;
                });
                th_carryFilmTaskHome.IsBackground = true;
                th_carryFilmTaskHome.Start();
                #endregion

                #region 膜片升降任务
                Thread th_loadFilmTaskHome = new Thread(() =>
                {
                    home_loadFilmTask = 0;
                    FuncLib.ShowMsg("[ 膜片升降任务 ] 开始复位");

                    if (!FuncLib.Home(Axis.上料Z))
                    {
                        home_loadFilmTask = 1;
                        FuncLib.ShowMsg("[ 膜片升降任务 ] 膜片升降轴回零失败，请检查！", InfoType.Error);
                        return;
                    }

                    if (!FuncLib.Home(Axis.相机移动轴))
                    {
                        home_loadFilmTask = 1;
                        FuncLib.ShowMsg("[ 膜片升降任务 ] 相机移动轴回零失败，请检查！", InfoType.Error);
                        return;
                    }

                    home_loadFilmTask = 2;
                });
                th_loadFilmTaskHome.IsBackground = true;
                th_loadFilmTaskHome.Start();
                #endregion

                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (home_feedGlassLeftTask == 0 || home_feedGlassRightTask == 0 || home_leftGlueTask == 0 || home_rightGlueTask == 0 || home_filmRobotTask == 0 || home_loadFilmTask == 0 || home_carryFilmTask == 0)
                {
                    Thread.Sleep(100);


                    if (home_feedGlassLeftTask == 1)
                    {
                        FuncLib.ShowMsg("左工位上玻璃片任务回零失败！请检查", InfoType.Error, false);
                        break;
                    }

                    if (home_feedGlassRightTask == 1)
                    {
                        FuncLib.ShowMsg("右工位上玻璃片任务回零失败！请检查", InfoType.Error, false);
                        break;
                    }

                    if (home_leftGlueTask == 1)
                    {
                        FuncLib.ShowMsg("左工位点胶任务回零失败！请检查", InfoType.Error, false);
                        break;
                    }

                    if (home_rightGlueTask == 1)
                    {
                        FuncLib.ShowMsg("右工位点胶任务回零失败！请检查", InfoType.Error, false);
                        break;
                    }

                    if (home_filmRobotTask == 1)
                    {
                        FuncLib.ShowMsg("贴膜机械手任务回零失败！请检查", InfoType.Error, false);
                        break;
                    }

                    if (home_loadFilmTask == 1)
                    {
                        FuncLib.ShowMsg("膜片升降任务回零失败！请检查", InfoType.Error, false);
                        break;
                    }

                    if (home_carryFilmTask == 1)
                    {
                        FuncLib.ShowMsg("膜片搬运任务回零失败！请检查", InfoType.Error, false);
                        break;
                    }


                    if (sw.Elapsed.TotalSeconds > 40)
                    {
                        FuncLib.ShowMsg("整机复位超时！请检查", InfoType.Error, false);
                        sw.Stop();
                        break;
                    }
                }

                if (home_feedGlassLeftTask == 2 && home_feedGlassRightTask == 2 && home_leftGlueTask == 2 && home_rightGlueTask == 2 && home_filmRobotTask == 2 && home_loadFilmTask == 2 && home_carryFilmTask == 2)
                {
                    FuncLib.ShowMsg(string.Format("整机复位成功，耗时：{0} 秒", (int)sw.Elapsed.TotalSeconds));
                    Device.machineHomeResult = 2;
                }
                else
                {
                    FuncLib.ShowMsg("整机复位失败", InfoType.Error);
                    Device.machineHomeResult = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 开始所有任务
        /// </summary>
        public static void StartTask()
        {
            try
            {
                //    //检测急停按钮是否被按下
                //    if (FuncLib.GetDiSts(Di.急停_C1In03) == OnOff.Off)
                //    {
                //        FuncLib.ShowMsg("系统检测到急停已按下，请松开急停", InfoType.Error);
                //        return;
                //    }

                //    if (th_feedGlassLeftTask == null || !th_feedGlassLeftTask.IsAlive)
                //    {
                //        th_feedGlassLeftTask = new Thread(FeedGlassLeftTask);
                //        th_feedGlassLeftTask.IsBackground = true;
                //        th_feedGlassLeftTask.Start();
                //    }
                //    if (th_feedGlassRightTask == null || !th_feedGlassRightTask.IsAlive)
                //    {
                //        th_feedGlassRightTask = new Thread(FeedGlassRightTask);
                //        th_feedGlassRightTask.IsBackground = true;
                //        th_feedGlassRightTask.Start();
                //    }
                //    if (th_leftGlueTask == null || !th_leftGlueTask.IsAlive)
                //    {
                //        th_leftGlueTask = new Thread(LeftGlueTask);
                //        th_leftGlueTask.IsBackground = true;
                //        th_leftGlueTask.Start();
                //    }
                //    if (th_rightGlueTask == null || !th_rightGlueTask.IsAlive)
                //    {
                //        th_rightGlueTask = new Thread(RightGlueTask);
                //        th_rightGlueTask.IsBackground = true;
                //        th_rightGlueTask.Start();
                //    }
                //    if (th_filmRobotTask == null || !th_filmRobotTask.IsAlive)
                //    {
                //        th_filmRobotTask = new Thread(FilmRobotTask);
                //        th_filmRobotTask.IsBackground = true;
                //        th_filmRobotTask.Start();
                //    }
                //    if (th_loadFilmTask == null || !th_loadFilmTask.IsAlive)
                //    {
                //        th_loadFilmTask = new Thread(LoadFilmTask);
                //        th_loadFilmTask.IsBackground = true;
                //        th_loadFilmTask.Start();
                //    }
                //    if (th_carryFilmTask == null || !th_carryFilmTask.IsAlive)
                //    {
                //        th_carryFilmTask = new Thread(CarryFilmTask);
                //        th_carryFilmTask.IsBackground = true;
                //        th_carryFilmTask.Start();
                //    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 机械手前往安全位
        /// </summary>
        private static bool CarryRobotGoSafetyPos()
        {
            try
            {
                if (!FuncLib.Home(Axis.搬运Z))
                    return false;

                if (!FuncLib.Home(Axis.搬运Y))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 获取运行速度
        /// </summary>
        /// <returns></returns>
        internal static double GetRunVel()
        {
            return (firstLowVel && Scheme.curScheme.workVelRate > 0.4) ? 0.4 : Scheme.curScheme.workVelRate;
        }

        #endregion
        
        #region 左工位上玻璃片任务

        /// <summary>
        /// 左工位上产品任务计时
        /// </summary>
        private static Stopwatch sw_feedGlassLeftTask = new Stopwatch();
        /// <summary>
        /// 左工位上玻璃片任务
        /// </summary>
        private static Thread th_feedGlassLeftTask;
        /// <summary>
        /// 左工位上玻璃片任务步
        /// </summary>
        private static int step_feedGlassLeftTask = 0;
        /// <summary>
        /// 左工位上玻璃片任务是否复位成功  0:未复位   1:复位结束，失败   2:复位结束，成功
        /// </summary>
        private static int home_feedGlassLeftTask = 0;
        /// <summary>
        /// 左工位上玻璃片任务状态
        /// </summary>
        private static LeftFeedGlassTaskStatu statu_leftFeedGlassTask = LeftFeedGlassTaskStatu.Init;

        /// <summary>
        ///  左工位上玻璃片任务
        /// </summary>
        private static void FeedGlassLeftTask()
        {
            try
            {
                //左工位上玻璃片任务初始化
                step_feedGlassLeftTask = 0;
                statu_leftFeedGlassTask = LeftFeedGlassTaskStatu.Init;

                #region 相关检查

                //检查组装平台是否有玻璃片
                FuncLib.SetDo(Do.左工位破真空_C1Out11, OnOff.Off);
                FuncLib.SetDo(Do.左工位吸真空_C1Out10, OnOff.On);
                Thread.Sleep(200);
                if (FuncLib.GetDiSts(Di.左工位真空检_C1In13) == OnOff.On)
                {
                    FuncLib.ShowMsg("[ 左工位上产品任务 ] 左工位上料工作台存在玻璃片，请手动取走！", InfoType.Error);
                    FuncLib.ShowBigTip("左工位上料工作台存在玻璃片，请手动取走！");
                    FuncLib.GoToPos("YL", "上料位");
                    FuncLib.SetDo(Do.左工位吸真空_C1Out10, OnOff.Off);
                    return;
                }
                FuncLib.SetDo(Do.左工位吸真空_C1Out10, OnOff.Off);

                #endregion

                while (Device.MachineRunStatu != MachineRunStatu.Stop && !EMGTriged)     //非停止状态且急停未触发
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Pause && Device.MachineRunStatu != MachineRunStatu.WaitMaterial && Device.MachineRunStatu != MachineRunStatu.Alarm && !saftyDoorTriged)
                    {
                        switch (step_feedGlassLeftTask)
                        {

                            #region 0：开始
                            case 0:

                                statu_leftFeedGlassTask = LeftFeedGlassTaskStatu.Init;
                                step_feedGlassLeftTask = 10;

                                break;
                            #endregion

                            #region 10：前往上料位
                            case 10:

                                if (!SmartPosTable.GoPos("YL", "上料位"))
                                {
                                    FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 机器人前往【上料位】失败，请检查", InfoType.Error);
                                    break;
                                }
                                FuncLib.SetDo(Do.左工位吸真空_C1Out10, OnOff.Off);
                                FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 左工位上玻璃片轴已运动到【上料位】，等待人工上玻璃片");
                                step_feedGlassLeftTask = 20;

                                break;
                            #endregion

                            #region 20：等待人工上玻璃片完成
                            case 20:

                                if (FuncLib.GetDiSts(Di.左启动_C1In10) == OnOff.On && FuncLib.GetDiSts(Di.启动_C1In11) == OnOff.On)
                                {
                                    FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 左工位人工上玻璃片已完成");
                                    step_feedGlassLeftTask = 30;

                                    sw_ct.Stop();
                                    Frm_Main.Instance.lbl_CT.Text = "CT：" + (sw_ct.ElapsedMilliseconds / 1000.0).ToString("0.00") + " s";
                                    sw_ct.Restart();
                                }

                                break;
                            #endregion

                            #region 30：吸真空并检测真空
                            case 30:

                                FuncLib.SetDo(Do.左工位吸真空_C1Out10, OnOff.On);
                                Thread.Sleep(200);
                                if (FuncLib.GetDiSts(Di.左工位真空检_C1In13) == OnOff.On)
                                {
                                    FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 左工位人工上玻璃片已完成");
                                    step_feedGlassLeftTask = 40;
                                }
                                else
                                {
                                    FuncLib.SetDo(Do.左工位吸真空_C1Out10, OnOff.Off);
                                    FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 左工位玻璃片吸真空异常，请检查", InfoType.Error);
                                }

                                break;
                            #endregion

                            #region 40：前往点胶位
                            case 40:

                                if (!SmartPosTable.GoPos("YL", "点胶位"))
                                {
                                    FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 机器人前往【点胶位】贴膜位，请检查", InfoType.Error);
                                    break;
                                }
                                FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 左工位上玻璃片轴已运动到【点胶位】");
                                step_feedGlassLeftTask = 41;

                                break;
                            #endregion

                            #region 41：给出可点胶信号
                            case 41:

                                statu_leftFeedGlassTask = LeftFeedGlassTaskStatu.CanGlue;
                                FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 左工位已准备就绪，等待机械手点胶");
                                step_feedGlassLeftTask = 42;

                                break;
                            #endregion

                            #region 42：等待点胶完成信号
                            case 42:

                                if (statu_leftFeedGlassTask == LeftFeedGlassTaskStatu.GlueDone)
                                {
                                    FuncLib.ShowMsg("[ 左工位上产品任务 ] 左工位机械手贴点胶完成");
                                    step_feedGlassLeftTask = 43;

                                    sw_ct.Stop();
                                    Frm_Main.Instance.lbl_CT.Text = "CT: " + (sw_ct.ElapsedMilliseconds / 1000.0).ToString("0.00") + " S";
                                }

                                break;
                            #endregion

                            #region 43：前往贴膜位
                            case 43:

                                if (!SmartPosTable.GoPos("YL", "贴膜位"))
                                {
                                    FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 机器人前往【上料位】贴膜位，请检查", InfoType.Error);
                                    break;
                                }
                                FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 左工位上玻璃片轴已运动到贴膜位");
                                step_feedGlassLeftTask = 50;

                                break;
                            #endregion

                            #region 50：给出可贴膜信号
                            case 50:

                                statu_leftFeedGlassTask = LeftFeedGlassTaskStatu.CanAssembly;
                                FuncLib.ShowMsg("[ 左工位上玻璃片任务 ] 左工位已准备就绪，等待机械手贴膜");
                                step_feedGlassLeftTask = 60;

                                break;
                            #endregion

                            #region 60：等待组装完成信号
                            case 60:

                                if (statu_leftFeedGlassTask == LeftFeedGlassTaskStatu.AssemblyDone)
                                {
                                    FuncLib.ShowMsg("[ 左工位上产品任务 ] 左工位机械手贴膜完成");
                                    step_feedGlassLeftTask = 70;

                                    sw_ct.Stop();
                                    Frm_Main.Instance.lbl_CT.Text = "左CT: " + (sw_ct.ElapsedMilliseconds / 1000.0).ToString("0.00") + " S";
                                }

                                break;
                            #endregion

                            #region 70：结束
                            case 70:

                                step_feedGlassLeftTask = 0;

                                break;
                                #endregion

                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("左工位上玻璃片任务中出现程序异常，异常信息如下：\r\n" + ex.ToString());
                Frm_Main.Instance.btn_stop_Click(null, null);
            }
        }

        #endregion

        #region 右工位上玻璃片任务

        /// <summary>
        /// 右工位上玻璃片任务计时
        /// </summary>
        private static Stopwatch sw_feedGlassRightTask = new Stopwatch();
        /// <summary>
        /// 右工位上玻璃片任务
        /// </summary>
        private static Thread th_feedGlassRightTask;
        /// <summary>
        /// 右工位上玻璃片任务步
        /// </summary>
        private static int step_feedGlassRightTask = 0;
        /// <summary>
        /// 右工位上玻璃片任务是否复位成功  0:未复位   1:复位结束，失败   2:复位结束，成功
        /// </summary>
        private static int home_feedGlassRightTask = 0;
        /// <summary>
        /// 右工位上玻璃片任务状态
        /// </summary>
        private static RightFeedGlassTaskStatu statu_rightFeedGlassTask = RightFeedGlassTaskStatu.Init;

        /// <summary>
        /// 右工位上玻璃片任务
        /// </summary>
        private static void FeedGlassRightTask()
        {
            try
            {
                //右工位上玻璃片任务初始化
                step_feedGlassRightTask = 0;
                statu_rightFeedGlassTask = RightFeedGlassTaskStatu.Init;

                #region 相关检查

                //检查组装平台是否有玻璃片
                FuncLib.SetDo(Do.右工位破真空_C1Out13, OnOff.Off);
                FuncLib.SetDo(Do.右工位吸真空_C1Out12, OnOff.On);
                Thread.Sleep(200);
                if (FuncLib.GetDiSts(Di.右工位真空检_C1In14) == OnOff.On)
                {
                    FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 右工位上料工作台存在玻璃片，请手动取走！", InfoType.Error);
                    FuncLib.ShowBigTip("右工位上料工作台存在玻璃片，请手动取走！");
                    FuncLib.GoToPos("YR", "上料位");
                    FuncLib.SetDo(Do.右工位吸真空_C1Out12, OnOff.Off);
                    return;
                }
                FuncLib.SetDo(Do.右工位吸真空_C1Out12, OnOff.Off);

                #endregion

                while (Device.MachineRunStatu != MachineRunStatu.Stop && !EMGTriged)     //非停止状态且急停未触发
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Pause && Device.MachineRunStatu != MachineRunStatu.WaitMaterial && Device.MachineRunStatu != MachineRunStatu.Alarm && !saftyDoorTriged)
                    {
                        switch (step_feedGlassRightTask)
                        {

                            #region 0：开始
                            case 0:

                                statu_rightFeedGlassTask = RightFeedGlassTaskStatu.Init;
                                step_feedGlassRightTask = 10;

                                break;
                            #endregion

                            #region 10：前往上料位
                            case 10:

                                if (!SmartPosTable.GoPos("YR", "上料位"))
                                {
                                    FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 机器人前往【上料位】失败，请检查", InfoType.Error);
                                    break;
                                }
                                FuncLib.SetDo(Do.右工位吸真空_C1Out12, OnOff.Off);
                                FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 右工位上玻璃片轴已运动到上料位，等待人工上玻璃片");
                                step_feedGlassRightTask = 20;

                                break;
                            #endregion

                            #region 20：等待人工上玻璃片完成
                            case 20:

                                if (FuncLib.GetDiSts(Di.右启动_C1In12) == OnOff.On && FuncLib.GetDiSts(Di.启动_C1In11) == OnOff.On)
                                {
                                    FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 右工位人工上玻璃片已完成");
                                    step_feedGlassRightTask = 30;
                                }

                                break;
                            #endregion

                            #region 30：吸真空并检测真空
                            case 30:

                                FuncLib.SetDo(Do.右工位吸真空_C1Out12, OnOff.On);
                                Thread.Sleep(200);
                                if (FuncLib.GetDiSts(Di.右工位真空检_C1In14) == OnOff.On)
                                {
                                    FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 右工位人工上玻璃片已完成");
                                    step_feedGlassRightTask = 40;
                                }
                                else
                                {
                                    FuncLib.SetDo(Do.右工位吸真空_C1Out12, OnOff.Off);
                                    FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 右工位玻璃片吸真空异常，请检查", InfoType.Error);
                                }

                                break;
                            #endregion

                            #region 40：前往点胶位
                            case 40:

                                if (!SmartPosTable.GoPos("YR", "点胶位"))
                                {
                                    FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 机器人前往【点胶位】贴膜位，请检查", InfoType.Error);
                                    break;
                                }
                                FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 右工位上玻璃片轴已运动到【点胶位】");
                                step_feedGlassRightTask = 41;

                                break;
                            #endregion

                            #region 41：给出可点胶信号
                            case 41:

                                statu_rightFeedGlassTask = RightFeedGlassTaskStatu.CanGlue;
                                FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 右工位已准备就绪，等待机械手点胶");
                                step_feedGlassRightTask = 42;

                                break;
                            #endregion

                            #region 42：等待点胶完成信号
                            case 42:

                                if (statu_rightFeedGlassTask == RightFeedGlassTaskStatu.GlueDone)
                                {
                                    FuncLib.ShowMsg("[ 右工位上产品任务 ] 右工位机械手贴点胶完成");
                                    step_feedGlassRightTask = 43;

                                    sw_ct.Stop();
                                    Frm_Main.Instance.lbl_CT.Text = "CT: " + (sw_ct.ElapsedMilliseconds / 1000.0).ToString("0.00") + " S";
                                }

                                break;
                            #endregion

                            #region 43：前往贴膜位
                            case 43:

                                if (!SmartPosTable.GoPos("YR", "贴膜位"))
                                {
                                    FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 机器人前往【贴膜位】贴膜位，请检查", InfoType.Error);
                                    break;
                                }
                                FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 右工位上玻璃片轴已运动到贴膜位");
                                step_feedGlassRightTask = 50;

                                break;
                            #endregion

                            #region 50：给出可贴膜信号
                            case 50:

                                statu_rightFeedGlassTask = RightFeedGlassTaskStatu.CanAssembly;
                                FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 左工位已准备就绪，等待机械手贴膜");
                                step_feedGlassRightTask = 60;

                                break;
                            #endregion

                            #region 60：等待组装完成信号
                            case 60:

                                if (statu_rightFeedGlassTask == RightFeedGlassTaskStatu.AssemblyDone)
                                {
                                    FuncLib.ShowMsg("[ 右工位上玻璃片任务 ] 左工位机械手组装完成");
                                    step_feedGlassRightTask = 70;
                                }

                                break;
                            #endregion

                            #region 70：结束
                            case 70:

                                step_feedGlassRightTask = 0;

                                break;
                                #endregion

                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("右工位上玻璃片任务中出现程序异常，异常信息如下：\r\n" + ex.ToString());
                Frm_Main.Instance.btn_stop_Click(null, null);
            }
        }

        #endregion

        #region 左工位点胶任务

        /// <summary>
        /// 左工位点胶任务计时
        /// </summary>
        private static Stopwatch sw_leftGlueTask = new Stopwatch();
        /// <summary>
        /// 左工位点胶任务
        /// </summary>
        private static Thread th_leftGlueTask;
        /// <summary>
        /// 左工位点胶任务步
        /// </summary>
        private static int step_leftGlueTask = 0;
        /// <summary>
        /// 左工位点胶任务是否复位成功  0:未复位   1:复位结束，失败   2:复位结束，成功
        /// </summary>
        private static int home_leftGlueTask = 0;

        /// <summary>
        ///  左工位点胶任务
        /// </summary>
        private static void LeftGlueTask()
        {
            try
            {
                //左工位点胶任务初始化
                step_leftGlueTask = 0;

                #region 相关检查



                #endregion

                while (Device.MachineRunStatu != MachineRunStatu.Stop && !EMGTriged)     //非停止状态且急停未触发
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Pause && Device.MachineRunStatu != MachineRunStatu.WaitMaterial && Device.MachineRunStatu != MachineRunStatu.Alarm && !saftyDoorTriged)
                    {
                        switch (step_leftGlueTask)
                        {

                            #region 0：开始
                            case 0:

                                step_leftGlueTask = 10;

                                break;
                            #endregion

                            #region 10：前往点胶等待位
                            case 10:

                                if (!FuncLib.MoveAbs(Axis.X1, FuncLib.FindPosByName("左工位点胶", "点胶等待位").L_point[0], 50, true))
                                {
                                    FuncLib.ShowMsg("[ 左工位点胶 ] 机器人前往【点胶等待位】贴膜位，请检查", InfoType.Error);
                                    break;
                                }
                                if (!FuncLib.MoveAbs(Axis.Z1, FuncLib.FindPosByName("左工位点胶", "点胶等待位").L_point[2], 50, true))
                                {
                                    FuncLib.ShowMsg("[ 左工位点胶 ] 机器人前往【点胶等待位】贴膜位，请检查", InfoType.Error);
                                    break;
                                }
                                FuncLib.ShowMsg("[ 左工位点胶 ] 左工位点胶机械手已运动至【点胶等待位】，等待玻璃片准备就绪");
                                step_leftGlueTask = 20;

                                break;
                            #endregion

                            #region 20：等待玻璃片准备就绪
                            case 20:

                                if (statu_leftFeedGlassTask == LeftFeedGlassTaskStatu.CanGlue)
                                {
                                    FuncLib.ShowMsg("[ 左工位点胶 ] 左工位玻璃片已准备就绪");
                                    step_leftGlueTask = 30;
                                }

                                break;
                            #endregion

                            #region 30：执行点胶过程
                            case 30:

                                //点胶过程必须一次性完成，不可中断
                                FuncLib.GoToPos("左工位点胶", "点胶位1");
                                FuncLib.GoToPos("左工位点胶", "点胶位2");

                                step_leftGlueTask = 40;

                                break;
                            #endregion

                            #region 40：给出点胶完成信号
                            case 40:

                                statu_leftFeedGlassTask = LeftFeedGlassTaskStatu.GlueDone;
                                FuncLib.ShowMsg("[ 左工位上产品任务 ] 左工位点胶已完成");
                                step_leftGlueTask = 50;

                                break;
                            #endregion

                            #region 50：结束
                            case 50:

                                step_leftGlueTask = 0;

                                break;
                                #endregion

                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("左工位点胶任务中出现程序异常，异常信息如下：\r\n" + ex.ToString());
                Frm_Main.Instance.btn_stop_Click(null, null);
            }
        }

        #endregion

        #region 右工位点胶任务

        /// <summary>
        /// 右工位点胶任务计时
        /// </summary>
        private static Stopwatch sw_rightGlueTask = new Stopwatch();
        /// <summary>
        /// 右工位点胶任务
        /// </summary>
        private static Thread th_rightGlueTask;
        /// <summary>
        /// 右工位点胶任务步
        /// </summary>
        private static int step_rightGlueTask = 0;
        /// <summary>
        /// 右工位点胶任务是否复位成功  0:未复位   1:复位结束，失败   2:复位结束，成功
        /// </summary>
        private static int home_rightGlueTask = 0;

        /// <summary>
        ///  右工位点胶任务
        /// </summary>
        private static void RightGlueTask()
        {
            try
            {
                //右工位点胶任务初始化
                step_rightGlueTask = 0;

                #region 相关检查



                #endregion

                while (Device.MachineRunStatu != MachineRunStatu.Stop && !EMGTriged)     //非停止状态且急停未触发
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Pause && Device.MachineRunStatu != MachineRunStatu.WaitMaterial && Device.MachineRunStatu != MachineRunStatu.Alarm && !saftyDoorTriged)
                    {
                        switch (step_rightGlueTask)
                        {

                            #region 0：开始
                            case 0:

                                step_rightGlueTask = 10;

                                break;
                            #endregion

                            #region 10：前往点胶等待位
                            case 10:

                                if (!FuncLib.MoveAbs(Axis.X2, FuncLib.FindPosByName("右工位点胶", "点胶等待位").L_point[0], 50, true))
                                {
                                    FuncLib.ShowMsg("[ 右工位点胶 ] 机器人前往【点胶等待位】贴膜位，请检查", InfoType.Error);
                                    break;
                                }
                                if (!FuncLib.MoveAbs(Axis.Z2, FuncLib.FindPosByName("右工位点胶", "点胶等待位").L_point[2], 50, true))
                                {
                                    FuncLib.ShowMsg("[ 右工位点胶 ] 机器人前往【点胶等待位】贴膜位，请检查", InfoType.Error);
                                    break;
                                }
                                FuncLib.ShowMsg("[ 右工位点胶 ] 右工位点胶机械手已运动至【点胶等待位】，等待玻璃片准备就绪");
                                step_rightGlueTask = 20;

                                break;
                            #endregion

                            #region 20：等待玻璃片准备就绪
                            case 20:

                                if (statu_rightFeedGlassTask == RightFeedGlassTaskStatu.CanGlue)
                                {
                                    FuncLib.ShowMsg("[ 右工位点胶 ] 右工位玻璃片已准备就绪");
                                    step_rightGlueTask = 30;
                                }

                                break;
                            #endregion

                            #region 30：执行点胶过程
                            case 30:

                                //点胶过程必须一次性完成，不可中断
                                FuncLib.GoToPos("右工位点胶", "点胶位1");
                                FuncLib.GoToPos("右工位点胶", "点胶位2");

                                step_rightGlueTask = 40;

                                break;
                            #endregion

                            #region 40：给出点胶完成信号
                            case 40:

                                statu_rightFeedGlassTask = RightFeedGlassTaskStatu.GlueDone;
                                FuncLib.ShowMsg("[ 右工位上产品任务 ] 右工位点胶已完成");
                                step_rightGlueTask = 50;

                                break;
                            #endregion

                            #region 50：结束
                            case 50:

                                step_rightGlueTask = 0;

                                break;
                                #endregion

                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("左工位点胶任务中出现程序异常，异常信息如下：\r\n" + ex.ToString());
                Frm_Main.Instance.btn_stop_Click(null, null);
            }
        }

        #endregion

        #region 贴膜机械手任务

        /// <summary>
        /// 贴膜机械手是否在安全位
        /// </summary>
        private static bool filmRobotInSafetyRegion = false;
        /// <summary>
        /// 贴膜机械手任务计时
        /// </summary>
        private static Stopwatch sw_filmRobotTask = new Stopwatch();
        /// <summary>
        /// 贴膜机械手任务
        /// </summary>
        private static Thread th_filmRobotTask;
        /// <summary>
        /// 贴膜机械手任务步
        /// </summary>
        private static Int32 step_filmTobotTask = 0;
        /// <summary>
        /// 贴膜机械手任务是否复位成功  0:未复位   1:复位结束，失败   2:复位结束，成功
        /// </summary>
        private static int home_filmRobotTask = 0;

        /// <summary>
        /// 贴膜机械手任务
        /// </summary>
        private static void FilmRobotTask()
        {
            try
            {
                //贴膜机械手任务初始化
                step_filmTobotTask = 0;

                #region 相关检查

                //检测机械手人当前是否吸的有膜片，如有膜片，要求人为拿下来，如没有膜片，那就关闭机械手吸盘真空
                if (FuncLib.GetDiSts(Di.贴膜吸真空检_C1In15) == OnOff.On)
                {
                    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 启动前检测到贴膜机械手上已吸取膜片，请手动取下", InfoType.Error);
                    return;
                }

                FuncLib.SetDo(Do.贴膜破真空_C1Out30, OnOff.Off);
                FuncLib.SetDo(Do.贴膜吸真空_C1Out27, OnOff.Off);

                //机械手回安全位
                if (!FuncLib.GoToPos("贴合机械手", "安全位"))
                {
                    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 机械手前往【安全位】失败，请检查", InfoType.Error);
                    return;
                }
                filmRobotInSafetyRegion = true;

                //关闭光源
                FuncLib.SetDo(Do.上光源_C1Out24, OnOff.Off);

                #endregion

                while (Device.MachineRunStatu != MachineRunStatu.Stop && !EMGTriged)     //非停止状态且急停未触发
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Pause && Device.MachineRunStatu != MachineRunStatu.WaitMaterial && Device.MachineRunStatu != MachineRunStatu.Alarm && !saftyDoorTriged)
                    {
                        switch (step_filmTobotTask)
                        {

                            #region 0：开始
                            case 0:

                                step_filmTobotTask = 10;
                                FuncLib.ShowMsg("[ 贴膜机械手任务 ] 等待膜片搬运任务准备就绪");

                                break;
                            #endregion

                            #region 10：等待膜片搬运机械手放膜完成
                            case 10:

                                if (statu_carryFilmTask == CarryFilmTaskStatu.CanPick)
                                {
                                    step_filmTobotTask = 20;
                                    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 膜片搬运任务已准备就绪");
                                    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 等待膜片搬运机械手处在安全区域");
                                }

                                break;
                            #endregion

                            #region 20：等待膜片搬运机械手处在安全区域
                            case 20:

                                if (carryRobotInSafetyRegion)
                                {
                                    filmRobotInSafetyRegion = false;
                                    step_filmTobotTask = 30;
                                    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 膜片搬运机械手已处在安全区域");
                                }

                                break;
                            #endregion

                            #region 30：前往取膜上升位
                            case 30:

                                if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "取膜上升位"))
                                    break;

                                step_filmTobotTask = 40;

                                break;
                            #endregion

                            #region 40：前往取膜片下降位
                            case 40:

                                if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "取膜下降位"))
                                    break;

                                FuncLib.SetOff(Do.中转平台吸真空1_C1Out45);
                                FuncLib.SetOff(Do.中转平台吸真空2_C1Out46);
                                FuncLib.SetOff(Do.中转平台吸真空3_C1Out47);
                                FuncLib.SetOff(Do.中转平台吸真空4_C1Out50);
                                FuncLib.SetOff(Do.中转平台吸真空5_C1Out51);
                                FuncLib.SetOff(Do.中转平台吸真空6_C1Out52);

                                FuncLib.SetOn(Do.中转平台破真空1_C1Out53);
                                FuncLib.SetOn(Do.中转平台破真空2_C1Out54);
                                FuncLib.SetOn(Do.中转平台破真空3_C1Out55);
                                FuncLib.SetOn(Do.中转平台破真空4_C1Out56);
                                FuncLib.SetOn(Do.中转平台破真空5_C1Out57);
                                FuncLib.SetOn(Do.中转平台破真空6_C1Out60);
                                step_filmTobotTask = 50;

                                break;
                            #endregion

                            #region 50：吸真空
                            case 50:

                                FuncLib.SetDo(Do.贴膜破真空_C1Out30, OnOff.Off);
                                FuncLib.SetDo(Do.贴膜吸真空_C1Out27, OnOff.On);
                                FuncLib.ShowMsg("[ 贴膜机械手任务 ] 吸膜片真空已开启");
                                sw_filmRobotTask.Restart();
                                step_filmTobotTask = 60;

                                break;
                            #endregion

                            #region 60：等待真空达到
                            case 60:

                                if (FuncLib.GetDiSts(Di.贴膜吸真空检_C1In15) == OnOff.On)
                                {
                                    Thread.Sleep(20);
                                    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 吸膜片真空已达到");
                                    step_filmTobotTask = 70;
                                }
                                else        //真空达不到就报警
                                {
                                    if (sw_filmRobotTask.ElapsedMilliseconds > 2000)
                                    {
                                        FuncLib.ShowMsg("[ 贴膜机械手任务 ] 取膜片真空未达到，请检查", InfoType.Error);
                                        step_filmTobotTask = 50;    //返回去开始重新计时
                                        break;
                                    }
                                }

                                break;
                            #endregion

                            #region 70：前往取膜片上升位
                            case 70:

                                if (!FuncLib.MoveAbs(Axis.贴合Z, FuncLib.FindPosByName("贴合机械手", "取膜上升位").L_point[1], 30, true))
                                    break;

                                step_filmTobotTask = 80;

                                break;
                            #endregion

                            #region 80：检查是否取起膜片
                            case 80:

                                if (FuncLib.GetDiSts(Di.贴膜吸真空检_C1In15) == OnOff.On)
                                {
                                    step_filmTobotTask = 90;
                                }
                                else
                                {
                                    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 膜片未正常取起，请检查", InfoType.Error);
                                    step_filmTobotTask = 40;
                                }

                                break;
                            #endregion

                            #region 90：前往膜片拍照位
                            case 90:

                                if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "膜片拍照位"))
                                {
                                    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 机械手前往【膜片拍照位】失败，请检查", InfoType.Error);
                                    break;
                                }
                                FuncLib.ShowMsg("[ 贴膜机械手任务 ] 机械手已到达【膜片拍照位】");
                                step_filmTobotTask = 100;

                                break;
                            #endregion

                            #region 100：膜片Mark1识别
                            case 100:

                                if (!FuncLib.GoToPos("相机移动轴", "近端位置"))
                                    break;

                                FuncLib.SetDo(Do.下光源_C1Out33, OnOff.On);
                                Thread.Sleep(200);
                                Task task = Task.FindTaskByName("膜片Mark1");
                                task.Run();
                                if (task.taskRunStatu == TaskRunStatu.Succeed)
                                {
                                    FuncLib.ShowMsg("[ 机器人任务 ] 膜片Mark1 识别成功");
                                    step_filmTobotTask = 110;
                                }
                                else
                                {
                                    FuncLib.ShowMsg("[ 机器人任务 ] 膜片Mark1 识别失败，请检查", InfoType.Error);
                                }

                                break;
                            #endregion

                            #region 110：膜片Mark2识别
                            case 110:

                                if (!FuncLib.GoToPos("相机移动轴", "远端位置"))
                                    break;

                                FuncLib.SetDo(Do.下光源_C1Out33, OnOff.On);
                                Thread.Sleep(200);
                                task = Task.FindTaskByName("膜片Mark2");
                                task.Run();
                                if (task.taskRunStatu == TaskRunStatu.Succeed)
                                {
                                    FuncLib.SetDo(Do.下光源_C1Out33, OnOff.Off);
                                    FuncLib.ShowMsg("[ 机器人任务 ] 膜片Mark2 识别成功");
                                    step_filmTobotTask = 120;

                                    Thread th = new Thread(() =>
                                    {
                                        FuncLib.GoToPos("相机移动轴", "近端位置");
                                    });
                                    th.IsBackground = true;
                                    th.Start();
                                }
                                else
                                {
                                    FuncLib.ShowMsg("[ 机器人任务 ] 膜片Mark2 识别失败，请检查", InfoType.Error);
                                }

                                break;
                            #endregion

                            #region 120：前往对应工位Mark1拍照位
                            case 120:

                                if (statu_leftFeedGlassTask == LeftFeedGlassTaskStatu.CanAssembly && !lastAssemblyIsLeftStation)
                                {
                                    if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "左侧产品Mark1拍照位"))
                                        break;
                                }
                                else if (statu_rightFeedGlassTask == RightFeedGlassTaskStatu.CanAssembly && lastAssemblyIsLeftStation)
                                {
                                    if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "右侧产品Mark1拍照位"))
                                        break;
                                }
                                else
                                {
                                    if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "右侧产品Mark1拍照位"))
                                        break;
                                }
                                step_filmTobotTask = 130;

                                break;
                            #endregion

                            #region 130：判断左右贴合工位
                            case 130:

                                //因上一工位是点胶工位，所以我们要左右工位轮流切换贴合，防止干胶
                                if (!lastAssemblyIsLeftStation)         //如果上一次贴合是右工位，那么本次优先贴左工位
                                {
                                    if (statu_leftFeedGlassTask == LeftFeedGlassTaskStatu.CanAssembly)
                                    {
                                        step_filmTobotTask = 1000;
                                        lastAssemblyIsLeftStation = true;
                                    }
                                    else if (statu_rightFeedGlassTask == RightFeedGlassTaskStatu.CanAssembly)
                                    {
                                        step_filmTobotTask = 2000;
                                        lastAssemblyIsLeftStation = false;
                                    }
                                }
                                else if (lastAssemblyIsLeftStation)         //如果上一次贴合是右工位，那么本次优先贴左工位
                                {
                                    if (statu_rightFeedGlassTask == RightFeedGlassTaskStatu.CanAssembly)
                                    {
                                        step_filmTobotTask = 2000;
                                        lastAssemblyIsLeftStation = false;
                                    }
                                    else if (statu_leftFeedGlassTask == LeftFeedGlassTaskStatu.CanAssembly)
                                    {
                                        step_filmTobotTask = 1000;
                                        lastAssemblyIsLeftStation = true;
                                    }
                                }

                                break;
                            #endregion

                            #region 1000-1150 左工位贴膜

                            #region 1000：前往玻璃片Mark1拍照位
                            case 1000:

                                if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "左侧产品Mark1拍照位"))
                                    break;
                                statu_carryFilmTask = CarryFilmTaskStatu.PickDone;
                                filmRobotInSafetyRegion = true;
                                step_filmTobotTask = 1111;

                                break;
                            #endregion

                            #region 1111：玻璃片Mark1识别
                            case 1111:

                                FuncLib.SetDo(Do.上光源_C1Out24, OnOff.On);
                                Thread.Sleep(200);
                                task = Task.FindTaskByName("贴合左工位  产品Mark1");
                                task.Run();
                                if (task.taskRunStatu == TaskRunStatu.Succeed)
                                {
                                    FuncLib.ShowMsg("[ 机器人任务 ] 贴合左工位  产品Mark1 识别成功");
                                    step_filmTobotTask = 1110;
                                }
                                else
                                {
                                    FuncLib.ShowMsg("[ 机器人任务 ] 贴合左工位  产品Mark1 识别失败，请检查", InfoType.Error);
                                }

                                break;
                            #endregion

                            #region 1110：前往玻璃片Mark2拍照位
                            case 1110:

                                if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "左侧产品Mark2拍照位"))
                                    break;
                                step_filmTobotTask = 1121;

                                break;
                            #endregion

                            #region 1121：玻璃片Mark1识别
                            case 1121:

                                Thread.Sleep(200);
                                task = Task.FindTaskByName("贴合左工位  产品Mark2");
                                task.Run();
                                if (task.taskRunStatu == TaskRunStatu.Succeed)
                                {
                                    FuncLib.SetOff(Do.上光源_C1Out24);
                                    FuncLib.ShowMsg("[ 机器人任务 ] 贴合左工位  产品Mark2 识别成功");
                                    step_filmTobotTask = 1120;
                                }
                                else
                                {
                                    FuncLib.ShowMsg("[ 机器人任务 ] 贴合左工位  产品Mark2 识别失败，请检查", InfoType.Error);
                                }

                                break;
                            #endregion

                            #region 1120：前往贴合上升位
                            case 1120:

                                task = Task.FindTaskByName("贴合左工位");
                                List<object> list = task.Run(false);
                                //////if (task.taskRunStatu != TaskRunStatu.Succeed)
                                //////{
                                //////    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 贴膜位置计算失败，请检查", InfoType.Error);
                                //////    break;
                                //////}
                                //////else
                                //////{
                                //////    XYZU assemblyPos = new XYZU();
                                //////    assemblyPos.X = ((XYU)list[0]).XY.X;
                                //////    assemblyPos.Y = ((XYU)list[0]).XY.Y;
                                //////    assemblyPos.Z = 0;//注意安全 FuncLib.FindPosByName("贴膜机械手", "贴膜上升位").L_point[1];
                                //////    assemblyPos.U = ((XYU)list[0]).U;

                                //////    //前往组装位
                                //////    FuncLib.MoveAbs(Axis.贴合Z, Project.Instance.configuration.safetyHeight, 10, true);
                                //////    FuncLib.MoveInterpolateAbs(Axis.贴合X, Axis.Y1, assemblyPos.X, assemblyPos.Y, 0.1, 10);
                                //////    FuncLib.MoveAbs(Axis.贴合R, assemblyPos.U, 10, true);
                                //////    FuncLib.MoveAbs(Axis.贴合Z, assemblyPos.Z, 10, true);
                                //////    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 已到达贴膜上升位");

                                //////    //掉模片检测
                                //////    if (FuncLib.GetDiSts(Di.中转平台吸真空检1_E1In30) == OnOff.Off)
                                //////    {
                                //////        FuncLib.ShowMsg("[ 贴膜机械手任务 ] 检测到真空未达到，怀疑膜片已掉落，请人工取走后整体复位程序", InfoType.Error);
                                //////        break;
                                //////    }
                                if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "左工位临时贴膜上升位"))
                                    break;
                                step_filmTobotTask = 1130;
                                //////}

                                break;
                            #endregion

                            #region 1130：前往贴膜下降位
                            case 1130:

                                //////if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "贴膜下降位"))
                                //////{
                                //////    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 机械手前往【贴膜下降位】失败，请检查", InfoType.Error);
                                //////    break;
                                //////}
                                if (!FuncLib.GoToPos("贴合机械手", "左工位临时贴膜下降位"))
                                    break;
                                step_filmTobotTask = 1140;

                                break;
                            #endregion

                            #region 1140：关真空并开启破真空
                            case 1140:

                                FuncLib.SetDo(Do.贴膜吸真空_C1Out27, OnOff.Off);
                                FuncLib.SetDo(Do.贴膜破真空_C1Out30, OnOff.On);
                                Thread.Sleep(100);
                                step_filmTobotTask = 1150;

                                break;
                            #endregion

                            #region 1150：前往贴膜上升位
                            case 1150:

                                if (!FuncLib.GoToPos("贴合机械手", "左工位临时贴膜上升位"))
                                    break;
                                FuncLib.SetDo(Do.贴膜破真空_C1Out30, OnOff.Off);
                                statu_leftFeedGlassTask = LeftFeedGlassTaskStatu.AssemblyDone;
                                step_filmTobotTask = 0;

                                break;
                            #endregion

                            #endregion

                            #region 2000-2050 右工位贴膜

                            #region 2000：前往玻璃片Mark1拍照位
                            case 2000:

                                if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "右侧产品Mark1拍照位"))
                                    break;
                                step_filmTobotTask = 2011;

                                break;
                            #endregion

                            #region 2011：玻璃片Mark1识别
                            case 2011:

                                FuncLib.SetDo(Do.上光源_C1Out24, OnOff.On);
                                Thread.Sleep(200);
                                task = Task.FindTaskByName("贴合右工位  产品Mark1");
                                task.Run();
                                if (task.taskRunStatu == TaskRunStatu.Succeed)
                                {
                                    FuncLib.ShowMsg("[ 机器人任务 ] 贴合右工位  产品Mark1 识别成功");
                                    step_filmTobotTask = 2010;
                                }
                                else
                                {
                                    FuncLib.ShowMsg("[ 机器人任务 ] 贴合右工位  产品Mark1 识别失败，请检查", InfoType.Error);
                                }

                                break;
                            #endregion

                            #region 2010：前往玻璃片Mark2拍照位
                            case 2010:

                                if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "右侧产品Mark2拍照位"))
                                    break;
                                step_filmTobotTask = 2021;

                                break;
                            #endregion

                            #region 2021：玻璃片Mark1识别
                            case 2021:

                                FuncLib.SetDo(Do.上光源_C1Out24, OnOff.On);
                                Thread.Sleep(200);
                                task = Task.FindTaskByName("贴合右工位  产品Mark2");
                                task.Run();
                                if (task.taskRunStatu == TaskRunStatu.Succeed)
                                {
                                    FuncLib.ShowMsg("[ 机器人任务 ] 贴合右工位  产品Mark2 识别成功");
                                    step_filmTobotTask = 2020;
                                }
                                else
                                {
                                    FuncLib.ShowMsg("[ 机器人任务 ] 贴合右工位  产品Mark2 识别失败，请检查", InfoType.Error);
                                }

                                break;
                            #endregion

                            #region 2020：前往贴合上升位
                            case 2020:

                                task = Task.FindTaskByName("贴合右工位");
                                list = task.Run(false);
                                //////if (task.taskRunStatu != TaskRunStatu.Succeed)
                                //////{
                                //////    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 贴膜位置计算失败，请检查", InfoType.Error);
                                //////    break;
                                //////}
                                //////else
                                //////{
                                //////    XYZU assemblyPos = new XYZU();
                                //////    assemblyPos.X = ((XYU)list[0]).XY.X;
                                //////    assemblyPos.Y = ((XYU)list[0]).XY.Y;
                                //////    assemblyPos.Z = 0;//注意安全 FuncLib.FindPosByName("贴膜机械手", "左工位贴膜上升位").L_point[1];
                                //////    assemblyPos.U = ((XYU)list[0]).U;

                                //////    //前往组装位
                                //////    FuncLib.MoveAbs(Axis.贴合Z, Project.Instance.configuration.safetyHeight, 10, true);
                                //////    FuncLib.MoveInterpolateAbs(Axis.贴合X, Axis.Y1, assemblyPos.X, assemblyPos.Y, 0.1, 10);
                                //////    FuncLib.MoveAbs(Axis.贴合R, assemblyPos.U, 10, true);
                                //////    FuncLib.MoveAbs(Axis.贴合Z, assemblyPos.Z, 10, true);
                                //////    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 已到达贴膜上升位");

                                //////    //掉模片检测
                                //////    if (FuncLib.GetDiSts(Di.中转平台吸真空检1_E1In30) == OnOff.Off)
                                //////    {
                                //////        FuncLib.ShowMsg("[ 贴膜机械手任务 ] 检测到真空未达到，怀疑膜片已掉落，请人工取走后整体复位程序", InfoType.Error);
                                //////        break;
                                //////    }
                                if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "右工位临时贴膜上升位"))
                                {
                                    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 机械手前往【左侧产品Mark1拍照位】失败，请检查", InfoType.Error);
                                    break;
                                }
                                step_filmTobotTask = 2030;
                                statu_carryFilmTask = CarryFilmTaskStatu.PickDone;
                                filmRobotInSafetyRegion = true;
                                //////}

                                break;
                            #endregion

                            #region 2030：前往贴膜下降位
                            case 2030:

                                //////if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "贴膜下降位"))
                                //////{
                                //////    FuncLib.ShowMsg("[ 贴膜机械手任务 ] 机械手前往【贴膜下降位】失败，请检查", InfoType.Error);
                                //////    break;
                                //////}
                                if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "右工位临时贴膜下降位"))
                                    break;
                                step_filmTobotTask = 2040;

                                break;
                            #endregion

                            #region 2040：关真空并开启破真空
                            case 2040:

                                FuncLib.SetDo(Do.贴膜吸真空_C1Out27, OnOff.Off);
                                FuncLib.SetDo(Do.贴膜破真空_C1Out30, OnOff.On);
                                Thread.Sleep(100);
                                step_filmTobotTask = 2050;

                                break;
                            #endregion

                            #region 2050：前往贴膜上升位
                            case 2050:

                                if (!FuncLib.FilmRobotDoorMoveTo("贴合机械手", "右工位临时贴膜上升位"))
                                    break;
                                FuncLib.SetDo(Do.贴膜破真空_C1Out30, OnOff.Off);
                                statu_rightFeedGlassTask = RightFeedGlassTaskStatu.AssemblyDone;
                                step_filmTobotTask = 0;

                                break;
                            #endregion

                            #endregion

                            #region 300：结束
                            case 300:

                                step_filmTobotTask = 0;

                                break;
                                #endregion

                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("贴膜机械手任务中出现程序异常，异常信息如下：\r\n" + ex.ToString());
                Frm_Main.Instance.btn_stop_Click(null, null);
            }
        }

        #endregion

        #region 膜片搬运任务

        /// <summary>
        /// 是否为启动后第一次搬运
        /// </summary>
        private static bool firstCarry = true;
        /// <summary>
        /// 指示是膜片还是隔片
        /// </summary>
        private static bool isFilm = true;
        /// <summary>
        /// 膜片搬运机械手是否在安全位
        /// </summary>
        private static bool carryRobotInSafetyRegion = false;
        /// <summary>
        /// 膜片搬运任务计时
        /// </summary>
        private static Stopwatch sw_carryFilmTask = new Stopwatch();
        /// <summary>
        /// 膜片搬运任务
        /// </summary>
        private static Thread th_carryFilmTask;
        /// <summary>
        /// 膜片搬运任务步
        /// </summary>
        private static Int32 step_carryFilmTask = 0;
        /// <summary>
        /// 膜片搬运任务是否复位成功  0:未复位   1:复位结束，失败   2:复位结束，成功
        /// </summary>
        private static int home_carryFilmTask = 0;
        /// <summary>
        /// 膜片搬运任务状态
        /// </summary>
        private static CarryFilmTaskStatu statu_carryFilmTask = CarryFilmTaskStatu.Init;

        /// <summary>
        /// 膜片搬运任务
        /// </summary>
        private static void CarryFilmTask()
        {
            try
            {
                //膜片搬运任务初始化
                step_carryFilmTask = 0;
                statu_carryFilmTask = CarryFilmTaskStatu.Init;

                #region 相关检查

                //检测膜片搬运机械手人当前是否吸的有膜片，如有膜片，要求人为拿下来，如没有膜片，那就关闭机械手吸盘真空
                if (FuncLib.GetDiSts(Di.贴膜吸真空检_C1In15) == OnOff.On)
                {
                    FuncLib.ShowMsg("[ 膜片搬运任务 ] 启动前检测到机械手上已吸取膜片，请手动取下", InfoType.Error);
                    return;
                }

                FuncLib.SetDo(Do.贴膜破真空_C1Out30, OnOff.Off);
                FuncLib.SetDo(Do.贴膜吸真空_C1Out27, OnOff.Off);

                //机械手回安全位
                if (!FuncLib.GoToPos("搬运机械手", "安全位"))
                {
                    FuncLib.ShowMsg("[ 膜片搬运任务 ] 启动前机械手回安全位失败，请检查！", InfoType.Error);
                    return;
                }
                carryRobotInSafetyRegion = true;

                #endregion

                while (Device.MachineRunStatu != MachineRunStatu.Stop && !EMGTriged)     //非停止状态且急停未触发
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Pause && Device.MachineRunStatu != MachineRunStatu.WaitMaterial && Device.MachineRunStatu != MachineRunStatu.Alarm && !saftyDoorTriged)
                    {
                        switch (step_carryFilmTask)
                        {

                            #region 0：开始
                            case 0:

                                step_carryFilmTask = 10;
                                statu_carryFilmTask = CarryFilmTaskStatu.Init;
                                FuncLib.ShowMsg("[ 膜片搬运任务 ] 等待膜片升降任务准备就绪");

                                break;
                            #endregion

                            #region 10：前往取膜上升位
                            case 10:

                                if (!FuncLib.CarryRobotDoorMoveTo("搬运机械手", "取膜片上升位"))
                                    break;
                                carryRobotInSafetyRegion = true;
                                step_carryFilmTask = 20;

                                break;
                            #endregion

                            #region 20：等待膜片顶升工位准备就绪
                            case 20:

                                if (statu_loadFilmTask == LoadFilmTaskStatu.CanPick)
                                {
                                    step_carryFilmTask = 30;
                                    FuncLib.ShowMsg("[ 膜片搬运任务 ] 膜片升降任务已准备就绪");
                                }

                                break;
                            #endregion

                            #region 30：前往取膜片下降位
                            case 30:

                                //////FuncLib.SetDo(Do.离子风_C1Out67);
                                if (!FuncLib.CarryRobotDoorMoveTo("搬运机械手", "取膜片下降位"))
                                    break;
                                step_carryFilmTask = 40;

                                break;
                            #endregion

                            #region 40：吸真空
                            case 40:

                                FuncLib.SetDo(Do.取膜破真空1_C1Out42, OnOff.Off);
                                FuncLib.SetDo(Do.取膜破真空2_C1Out43, OnOff.Off);
                                FuncLib.SetDo(Do.取膜破真空3_C1Out44, OnOff.Off);
                                FuncLib.SetDo(Do.取膜吸真空1_C1Out37, OnOff.On);
                                FuncLib.SetDo(Do.取膜吸真空2_C1Out40, OnOff.On);
                                FuncLib.SetDo(Do.取膜吸真空3_C1Out41, OnOff.On);
                                Thread.Sleep(100);
                                FuncLib.ShowMsg("[ 膜片搬运任务 ] 吸膜片真空已开启");
                                sw_carryFilmTask.Restart();
                                step_carryFilmTask = 50;

                                break;
                            #endregion

                            #region 50：等待真空达到
                            case 50:

                                if (FuncLib.GetDiSts(Di.取膜吸真空检1_E1In36) == OnOff.On && FuncLib.GetDiSts(Di.取膜吸真空检2_E1In37) == OnOff.On && FuncLib.GetDiSts(Di.取膜吸真空检3_E1In40) == OnOff.On)
                                {
                                    sw_carryFilmTask.Stop();
                                    Thread.Sleep(20);
                                    FuncLib.ShowMsg("[ 膜片搬运任务 ] 吸膜片真空已达到");
                                    step_carryFilmTask = 60;
                                }
                                else        //真空达不到就报警
                                {
                                    if (sw_carryFilmTask.ElapsedMilliseconds > 2000)
                                    {
                                        sw_carryFilmTask.Stop();
                                        FuncLib.ShowMsg("[ 膜片搬运任务 ] 取膜片真空未达到，请检查", InfoType.Error);
                                        step_carryFilmTask = 40;    //返回去开始重新计时
                                        break;
                                    }
                                }

                                break;
                            #endregion

                            #region 60：前往取膜片上升位
                            case 60:

                                if (!FuncLib.CarryRobotDoorMoveTo("搬运机械手", "取膜片上升位"))
                                    break;
                                FuncLib.SetOff(Do.离子风_C1Out67);
                                step_carryFilmTask = 70;

                                break;
                            #endregion

                            #region 70：检查是否正常吸起膜片
                            case 70:

                                if (FuncLib.GetDiSts(Di.取膜吸真空检1_E1In36) == OnOff.On && FuncLib.GetDiSts(Di.取膜吸真空检2_E1In37) == OnOff.On && FuncLib.GetDiSts(Di.取膜吸真空检3_E1In40) == OnOff.On)
                                {
                                    statu_loadFilmTask = LoadFilmTaskStatu.PickDone;
                                    step_carryFilmTask = 80;
                                    FuncLib.ShowMsg("[ 膜片搬运任务 ] 等待贴膜机械手取走膜片");
                                }
                                else
                                {
                                    FuncLib.ShowMsg("[ 膜片搬运任务 ] 膜片未正常吸起，请检查", InfoType.Error);
                                    step_carryFilmTask = 30;
                                }

                                break;
                            #endregion

                            #region 80：前往膜片隔板识别位
                            case 80:

                                if (!FuncLib.CarryRobotDoorMoveTo("搬运机械手", "识别位"))
                                    break;
                                step_carryFilmTask = 90;

                                break;
                            #endregion

                            #region 90：获取识别结果
                            case 90:

                                //////if (FuncLib.GetDiSts(Di.色标传感器_E1In24) == OnOff.On)
                                step_carryFilmTask = 100;
                                //////else
                                //////    step_carryFilmTask = 200;

                                break;
                            #endregion

                            #region 100-160 膜片搬运

                            #region 100：等待膜片被取走
                            case 100:

                                if (statu_carryFilmTask == CarryFilmTaskStatu.PickDone || firstCarry)
                                {
                                    firstCarry = false;
                                    FuncLib.ShowMsg("[ 膜片搬运任务 ] 等待贴膜机械手处在安全区域");
                                    step_carryFilmTask = 110;
                                }

                                break;
                            #endregion

                            #region 110：等待贴膜机械手处在安全区域
                            case 110:

                                if (filmRobotInSafetyRegion)
                                {
                                    carryRobotInSafetyRegion = false;
                                    FuncLib.ShowMsg("[ 膜片搬运任务 ] 检测到贴膜机械手已处在安全区域");
                                    step_carryFilmTask = 120;
                                }

                                break;
                            #endregion

                            #region 120：前往放膜片上升位
                            case 120:

                                if (!FuncLib.CarryRobotDoorMoveTo("搬运机械手", "放膜片上升位"))
                                    break;
                                step_carryFilmTask = 130;

                                break;
                            #endregion

                            #region 130：前往放膜片下降位
                            case 130:

                                if (!FuncLib.CarryRobotDoorMoveTo("搬运机械手", "放膜片下降位"))
                                    break;
                                step_carryFilmTask = 140;

                                break;
                            #endregion

                            #region 140：关真空并破真空
                            case 140:

                                FuncLib.SetDo(Do.取膜吸真空1_C1Out37, OnOff.Off);
                                FuncLib.SetDo(Do.取膜吸真空2_C1Out40, OnOff.Off);
                                FuncLib.SetDo(Do.取膜吸真空3_C1Out41, OnOff.Off);
                                FuncLib.SetDo(Do.取膜破真空1_C1Out42, OnOff.On);
                                FuncLib.SetDo(Do.取膜破真空2_C1Out43, OnOff.On);
                                FuncLib.SetDo(Do.取膜破真空3_C1Out44, OnOff.On);
                                Thread.Sleep(200);
                                FuncLib.SetOff(Do.中转平台破真空1_C1Out53);
                                FuncLib.SetOff(Do.中转平台破真空2_C1Out54);
                                FuncLib.SetOff(Do.中转平台破真空3_C1Out55);
                                FuncLib.SetOff(Do.中转平台破真空4_C1Out56);
                                FuncLib.SetOff(Do.中转平台破真空5_C1Out57);
                                FuncLib.SetOff(Do.中转平台破真空6_C1Out60);

                                FuncLib.SetOn(Do.中转平台吸真空1_C1Out45);
                                FuncLib.SetOn(Do.中转平台吸真空2_C1Out46);
                                FuncLib.SetOn(Do.中转平台吸真空3_C1Out47);
                                FuncLib.SetOn(Do.中转平台吸真空4_C1Out50);
                                FuncLib.SetOn(Do.中转平台吸真空5_C1Out51);
                                FuncLib.SetOn(Do.中转平台吸真空6_C1Out52);
                                FuncLib.ShowMsg("[ 膜片搬运任务 ] 真空已关闭");
                                step_carryFilmTask = 150;

                                break;
                            #endregion

                            #region 150：前往放膜片上升位
                            case 150:

                                if (!FuncLib.CarryRobotDoorMoveTo("搬运机械手", "放膜片上升位"))
                                    break;
                                FuncLib.SetDo(Do.取膜破真空1_C1Out42, OnOff.Off);
                                FuncLib.SetDo(Do.取膜破真空2_C1Out43, OnOff.Off);
                                FuncLib.SetDo(Do.取膜破真空3_C1Out44, OnOff.Off);
                                step_carryFilmTask = 160;

                                break;
                            #endregion

                            #region 160：前往取膜上升位
                            case 160:

                                if (!FuncLib.CarryRobotDoorMoveTo("搬运机械手", "取膜片上升位"))
                                    break;
                                carryRobotInSafetyRegion = true;
                                statu_carryFilmTask = CarryFilmTaskStatu.CanPick;
                                step_carryFilmTask = 300;

                                break;
                            #endregion

                            #endregion

                            #region 200-120 隔片搬运

                            #region 200：前往放隔板上升位
                            case 200:

                                if (!FuncLib.CarryRobotDoorMoveTo("膜片搬运机械手", "放隔板上升位"))
                                    break;
                                step_carryFilmTask = 210;

                                break;
                            #endregion

                            #region 1000：前往放隔板下降位
                            case 1000:

                                if (!FuncLib.CarryRobotDoorMoveTo("膜片搬运机械手", "前往放隔板下降位"))
                                    break;
                                step_carryFilmTask = 1100;

                                break;
                            #endregion

                            #region 1100：关真空并破真空
                            case 1100:

                                FuncLib.SetDo(Do.贴膜吸真空_C1Out27, OnOff.Off);
                                FuncLib.SetDo(Do.贴膜破真空_C1Out30, OnOff.On);
                                Thread.Sleep(200);
                                FuncLib.ShowMsg("[ 膜片搬运任务 ] 真空已关闭");
                                step_carryFilmTask = 1200;

                                break;
                            #endregion

                            #region 1200：前往放隔板上升位
                            case 1200:

                                if (!FuncLib.CarryRobotDoorMoveTo("膜片搬运机械手", "放隔板上升位"))
                                    break;
                                step_carryFilmTask = 300;

                                break;
                            #endregion

                            #endregion

                            #region 300：结束
                            case 300:

                                step_carryFilmTask = 0;

                                break;
                                #endregion

                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("膜片搬运任务中出现程序异常，异常信息如下：\r\n" + ex.ToString());
                Frm_Main.Instance.btn_stop_Click(null, null);
            }
        }

        #endregion

        #region 膜片升降任务

        /// <summary>
        /// 膜片升降任务计时
        /// </summary>
        private static Stopwatch sw_loadFilmTask = new Stopwatch();
        /// <summary>
        /// 膜片升降任务
        /// </summary>
        private static Thread th_loadFilmTask;
        /// <summary>
        /// 膜片升降任务步
        /// </summary>
        private static int step_loadFilmTask = 0;
        /// <summary>
        /// 膜片升降任务是否复位成功  0:未复位   1:复位结束，失败   2:复位结束，成功
        /// </summary>
        private static int home_loadFilmTask = 0;
        /// <summary>
        /// 膜片升降任务状态
        /// </summary>
        private static LoadFilmTaskStatu statu_loadFilmTask = LoadFilmTaskStatu.Init;

        /// <summary>
        /// 膜片升降任务
        /// </summary>
        private static void LoadFilmTask()
        {
            try
            {
                //膜片顶升任务初始化
                step_loadFilmTask = 0;
                statu_loadFilmTask = LoadFilmTaskStatu.Init;

                while (Device.MachineRunStatu != MachineRunStatu.Stop && !EMGTriged)     //非停止状态且急停未触发
                {
                    if (Device.MachineRunStatu != MachineRunStatu.Pause && Device.MachineRunStatu != MachineRunStatu.WaitMaterial && Device.MachineRunStatu != MachineRunStatu.Alarm && !saftyDoorTriged)
                    {
                        switch (step_loadFilmTask)
                        {

                            #region 0：开始
                            case 0:

                                statu_loadFilmTask = LoadFilmTaskStatu.Init;
                                step_loadFilmTask = 10;

                                break;
                            #endregion

                            #region 10：判断膜片是否缺料
                            case 10:

                                if (FuncLib.GetDiSts(Di.膜片有无检测_E1In26) == OnOff.Off)
                                {
                                    FuncLib.ShowMsg("[ 膜片升降任务 ] 检测到膜片缺料");
                                    step_loadFilmTask = 20;
                                }
                                else
                                {
                                    FuncLib.ShowMsg("[ 膜片升降任务 ] 检测到膜片有料");
                                    step_loadFilmTask = 40;
                                }

                                break;
                            #endregion

                            #region 20-30 膜片缺料处理

                            #region 下降到上料位
                            case 20:

                                if (!FuncLib.GoToPos("升降轴", "上料位"))
                                {
                                    FuncLib.ShowMsg("[ 膜片升降任务 ] 前往【上料位】失败，请检查！", InfoType.Error);
                                    break;
                                }

                                FuncLib.ShowMsg("[ 膜片升降任务 ] 已运动至【上料位】");
                                FuncLib.ShowMsg("[ 膜片升降任务 ] 膜片料尽，设备已暂停，请人工上料", InfoType.Warn);
                                Device.MachineRunStatu = MachineRunStatu.WaitMaterial;
                               
                                step_loadFilmTask = 30;

                                break;
                            #endregion

                            #region 判断是否已上膜片
                            case 30:

                                if (FuncLib.GetDiSts(Di.膜片有无检测_E1In26) == OnOff.Off)
                                {
                                    Thread.Sleep(1000);
                                    FuncLib.ShowMsg("[ 膜片升降任务 ] 膜片料尽，设备已暂停，请人工上料", InfoType.Warn);
                                    Device.MachineRunStatu = MachineRunStatu.WaitMaterial;
                                  
                                    break;
                                }
                                else
                                {
                                   
                                    FuncLib.ShowMsg("[ 膜片升降任务 ] 检测到膜片已上料");
                                    step_loadFilmTask = 40;
                                }

                                break;
                            #endregion

                            #endregion

                            #region 40：下降到感应器以下
                            case 40:

                                //降到感应器以下，防止人工中途放料超出到位感应器以上导致压料
                                FuncLib.ShowMsg("[ 膜片升降任务 ] 膜片顶升轴开始下降");
                                FuncLib.KeepMove(Axis.上料Z, Dir.N_负方向, 30, false);
                                sw_loadFilmTask.Restart();
                                while (true)
                                {
                                    if (FuncLib.GetDiSts(Di.膜片上升到位传感器_E1In27) == OnOff.Off)
                                    {
                                        sw_loadFilmTask.Stop();
                                        //200ms后停止下降
                                        Thread.Sleep(200);
                                        FuncLib.DecStop(Axis.上料Z);
                                        FuncLib.ShowMsg("[ 膜片升降任务 ] 膜片顶升轴已下降到位");
                                        step_loadFilmTask = 50;
                                        break;
                                    }

                                    if (sw_loadFilmTask.Elapsed.Seconds > 10)
                                    {
                                        sw_loadFilmTask.Stop();
                                        FuncLib.DecStop(Axis.上料Z);
                                        FuncLib.ShowMsg("[ 膜片升降任务 ] 膜片顶升轴向下运动超过10秒后到位信号仍未消失，请检查！", InfoType.Error);
                                        break;
                                    }

                                    Thread.Sleep(50);
                                }

                                break;
                            #endregion

                            #region 50：开始上升
                            case 50:

                               
                                FuncLib.ShowMsg("[ 膜片升降任务 ] 膜片顶升轴开始上升");
                                FuncLib.KeepMove(Axis.上料Z, Dir.P_正方向, 30, false);
                                sw_loadFilmTask.Restart();
                                while (true)
                                {
                                    if (FuncLib.GetDiSts(Di.膜片上升到位传感器_E1In27) == OnOff.On)
                                    {
                                        sw_loadFilmTask.Stop();
                                        FuncLib.ShowMsg("[ 膜片升降任务 ] 膜片顶升轴上升已到位");
                                        FuncLib.DecStop(Axis.上料Z);
                                        step_loadFilmTask = 60;
                                        break;
                                    }

                                    if (sw_loadFilmTask.Elapsed.Seconds > 10)
                                    {
                                        sw_loadFilmTask.Stop();
                                        FuncLib.DecStop(Axis.上料Z);
                                        FuncLib.ShowMsg("[ 膜片顶膜片升降任务升任务 ] 膜片顶升轴向上运动超过10秒到位信号仍未感应到，请检查！", InfoType.Error);
                                        break;
                                    }

                                    Thread.Sleep(50);
                                }

                                break;
                            #endregion

                            #region 60：给出可取膜片信号
                            case 60:

                                statu_loadFilmTask = LoadFilmTaskStatu.CanPick;
                                FuncLib.ShowMsg("[ 膜片升降任务 ] 膜片顶升工位已准备就绪，等待机械手取膜片");
                                step_loadFilmTask = 70;

                                break;
                            #endregion

                            #region 70：等待取膜片完成信号
                            case 70:

                                if (statu_loadFilmTask == LoadFilmTaskStatu.PickDone)
                                {
                                    FuncLib.ShowMsg("[ 膜片升降任务 ] 机械手取膜片完成");
                                    step_loadFilmTask = 80;
                                }

                                break;
                            #endregion

                            #region 80：结束
                            case 80:

                                firstLowVel = false;
                                step_loadFilmTask = 0;

                                break;
                                #endregion

                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("膜片升降任务中出现程序异常，异常信息如下：\r\n" + ex.ToString());
                Frm_Main.Instance.btn_stop_Click(null, null);
            }
        }

        #endregion

    }


    /// <summary>
    /// 膜片上料模式
    /// </summary>
    public enum LoadFileMode
    {
        M_自动上料不撕膜,
        M_膜片加隔片,
        M_手动上料撕膜,
        M_自动上料撕膜,
    }

    /// <summary>
    /// 左工位上玻璃片任务
    /// </summary>
    public enum LeftFeedGlassTaskStatu
    {
        Init,
        CanGlue,
        GlueDone,
        CanAssembly,
        AssemblyDone,
    }

    /// <summary>
    /// 右工位上玻璃片任务
    /// </summary>
    public enum RightFeedGlassTaskStatu
    {
        Init,
        CanGlue,
        GlueDone,
        CanAssembly,
        AssemblyDone,
    }

    /// <summary>
    /// 膜片搬运任务状态
    /// </summary>
    public enum CarryFilmTaskStatu
    {
        Init,
        CanPick,
        PickDone,
    }

    /// <summary>
    /// 膜片顶升任务状态
    /// </summary>
    public enum LoadFilmTaskStatu
    {
        Init,
        CanPick,
        PickDone,
    }

    /// <summary>
    /// 输入信号
    /// </summary>
    public enum Di
    {
        启动_C1In00,
        复位_C1In01,
        停止_C1In02,
        急停_C1In03,
        安全门_C1In04,
        总气压表_C1In05,
        备用1_C1In06,
        备用2_C1In07,

        左启动_C1In10,
        启动_C1In11,
        右启动_C1In12,
        左工位真空检_C1In13,
        右工位真空检_C1In14,
        贴膜吸真空检_C1In15,
        贴膜压边气缸上位检_C1In16,
        贴膜压边气缸下位检_C1In17,

        吸膜抖料气缸1上位检_E1In20,
        吸膜抖料气缸1下位检_E1In21,
        吸膜抖料气缸2上位检_E1In22,
        吸膜抖料气缸2下位检_E1In23,
        色标传感器_E1In24,
        检测膜传感器_E1In25,
        膜片有无检测_E1In26,
        膜片上升到位传感器_E1In27,

        中转平台吸真空检1_E1In30,
        中转平台吸真空检2_E1In31,
        中转平台吸真空检3_E1In32,
        中转平台吸真空检4_E1In33,
        中转平台吸真空检5_E1In34,
        中转平台吸真空检6_E1In35,
        取膜吸真空检1_E1In36,
        取膜吸真空检2_E1In37,

        取膜吸真空检3_E1In40,
        备用3_E1In41,
        备用4_E1In42,
        左胶量检测_E1In43,
        右胶量检测_E1In44,
        撕膜固定气缸上位检1_E1In45,
        撕膜固定气缸下位检1_E1In46,
        撕膜固定气缸上位检2_E1In47,

        撕膜固定气缸下位检2_E1In50,
        撕膜气缸上位检1_E1In51,
        撕膜气缸下位检1_E1In52,
        撕膜气缸上位检2_E1In53,
        撕膜气缸下位检2_E1In54,
        左工位吸胶真空检_E1In55,
        右工位吸胶真空检_E1In56,
        备用5_E1In57,

        左安全光栅_E1In60,
        右安全光栅_E1In61,
        搬运光栅_E1In62,
        备用6_E1In63,
        备用7_E1In64,
        备用8_E1In65,
        备用9_E1In66,
        备用10_E1In67,
    }

    /// <summary>
    /// 输出信号
    /// </summary>
    public enum Do
    {
        启动灯_C1Out00,
        复位灯_C1Out01,
        停止灯_C1Out02,
        三色灯_黄_C1Out03,
        三色灯_绿_C1Out04,
        三色灯_红_C1Out05,
        蜂鸣器_C1Out06,
        照明灯_C1Out07,

        左工位吸真空_C1Out10,
        左工位破真空_C1Out11,
        右工位吸真空_C1Out12,
        右工位破真空_C1Out13,
        左点胶上光源_C1Out14,
        右点胶开始_C1Out15,
        左点胶结束_C1Out16,
        备用1_C1Out17,

        右点胶上光源_C1Out20,
        左点胶开始_C1Out21,
        右点胶结束_C1Out22,
        备用2_C1Out23,
        上光源_C1Out24,
        贴膜压边气缸上_C1Out25,
        贴膜压边气缸下_C1Out26,
        贴膜吸真空_C1Out27,

        贴膜破真空_C1Out30,
        吸膜抖料气缸1_C1Out31,
        吸膜抖料气缸2_C1Out32,
        下光源_C1Out33,
        备用3_C1Out34,
        备用4_C1Out35,
        备用5_C1Out36,
        取膜吸真空1_C1Out37,

        取膜吸真空2_C1Out40,
        取膜吸真空3_C1Out41,
        取膜破真空1_C1Out42,
        取膜破真空2_C1Out43,
        取膜破真空3_C1Out44,
        中转平台吸真空1_C1Out45,
        中转平台吸真空2_C1Out46,
        中转平台吸真空3_C1Out47,

        中转平台吸真空4_C1Out50,
        中转平台吸真空5_C1Out51,
        中转平台吸真空6_C1Out52,
        中转平台破真空1_C1Out53,
        中转平台破真空2_C1Out54,
        中转平台破真空3_C1Out55,
        中转平台破真空4_C1Out56,
        中转平台破真空5_C1Out57,

        中转平台破真空6_C1Out60,
        左点胶吸胶_C1Out61,
        右点胶吸胶_C1Out62,
        撕膜固定气缸上_C1Out63,
        撕膜固定气缸下_C1Out64,
        撕膜气缸上_C1Out65,
        撕膜气缸下_C1Out66,
        离子风_C1Out67,
    }

    /// <summary>
    /// 轴
    /// </summary>
    public enum Axis
    {
        X1,
        X2,
        Y1,
        Y2,
        Z1,
        Z2,
        贴合X,
        贴合Z,
        贴合R,
        搬运Y,
        搬运Z,
        相机移动轴,
        上料Z,
    }

}
