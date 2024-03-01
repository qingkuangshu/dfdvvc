using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Tool;
using System.Diagnostics;
using System.Net;
using IMC100APIDLL;

namespace RobotControl
{
    public partial class Robot : UserControl
    {
        public Robot()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 轨道流向
        /// </summary>
        public bool GDRightToLeft = true;
        /// <summary>
        /// 机器人控制对象
        /// </summary>
        public static RobotControl_Base Instance;
        /// <summary>
        /// 实时获取当前位置和机器人状态信息线程
        /// </summary>
        private static Thread th_update;

        public void InitRobot()
        {
            try
            {
                Instance = new RobotControl_INOVANCE();
                Frm_MorePar.robotControl = Instance;
                Instance.velLevel = 40;

                bool result = Instance.Connect();
                if (result)
                    btn_connect.BackColor = Color.Green;
                else
                    btn_connect.BackColor = Color.Red;

                Instance.ClearAlarm();
                result = Instance.MotorOn();
                if (result)
                    btn_motorOn.BackColor = Color.Green;
                else
                    btn_motorOn.BackColor = Color.Red;

                Instance.ReadPar();
                Frm_MorePar.Instance.tbx_safeHeight.Text = Instance.safeHeight.ToString();
                Frm_MorePar.Instance.tbx_robotIP.Text = Instance.robotIP.ToString();
                Frm_MorePar.Instance.tbx_robotPort.Text = Instance.robotPort.ToString();
                Frm_MorePar.Instance.tbx_password.Text = Instance.loginPassword.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 实时刷新
        /// </summary>
        private void UpdateInfo()
        {
            try
            {
                while (!stop)
                {
                    if (this.Visible)
                    {
                        //实时刷新当前位置
                        RobotPos curPos;
                        Instance.GetCurPos(out curPos);
                        lbl_curXPos.Text = curPos.xyzu.X.ToString("000.000");
                        lbl_curYPos.Text = curPos.xyzu.Y.ToString("000.000");
                        lbl_curZPos.Text = curPos.xyzu.Z.ToString("000.000");
                        lbl_curUPos.Text = curPos.xyzu.U.ToString("000.000");

                        //获取当前报警信息

                        //当前运动状态
                        int sts = 0;
                        int ret = IMC100API.IMC100_Get_MotionSts(ref sts, 0);  //运动到位状态判断
                        Application.DoEvents();
                    }
                    Thread.Sleep(50);
                }
            }
            catch { }
        }
        /// <summary>
        /// 锁定
        /// </summary>
        public void Lock()
        {
            this.Enabled = false;
        }
        /// <summary>
        /// 解锁
        /// </summary>
        public void Unlock()
        {
            this.Enabled = true;
        }

        private bool stop = false;
        public void UpdateInfo(bool b)
        {
            if (b)
            {
                stop = false;
                th_update = new Thread(UpdateInfo);
                th_update.IsBackground = true;
                th_update.Start();
            }
            else
            {
                stop = true;
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = Instance.Connect();
                if (result)
                    btn_connect.BackColor = Color.Green;
                else
                    btn_connect.BackColor = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_motorOn_Click(object sender, EventArgs e)
        {
            Instance.ClearAlarm();
            if (btn_motorOn.BackColor == Color.Green)
            {
                bool result = Instance.MotorOff();
                if (result)
                    btn_motorOn.BackColor = Color.LightGray;
                else
                    btn_motorOn.BackColor = Color.Red;
            }
            else
            {
                bool result = Instance.MotorOn();
                if (result)
                    btn_motorOn.BackColor = Color.Green;
                else
                    btn_motorOn.BackColor = Color.Red;
            }
        }
        private void btn_clearAlarm_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = Instance.ClearAlarm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_emgStop_Click(object sender, EventArgs e)
        {
            try
            {
                Instance.EMGStop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_goHome_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Robot.Instance.GetMotorStatu())
                {
                    Instance.MotorOn();
                    Thread.Sleep(500);
                }

                Instance.MoveZToPos(Instance.safeHeight, Robot.Instance.velLevel / 4, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_morePar_Click(object sender, EventArgs e)
        {
            Frm_MorePar.Instance.Show();
            Frm_MorePar.Instance.Activate();
        }

        private void btn_XBackward_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdo_NotJog.Checked)
                {
                    if (!Robot.Instance.GetMotorStatu())
                    {
                        Instance.MotorOn();
                        Thread.Sleep(500);
                    }

                    double distance = 0;
                    try
                    {
                        distance = Convert.ToDouble(tbx_moveDis.Text.Trim());
                    }
                    catch
                    {
                        return;
                    }
                    if (GDRightToLeft)
                        Instance.MoveXBackwardForDistance(distance);
                    else
                        Instance.MoveXForewardForDistance(distance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_XForeward_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdo_NotJog.Checked)
                {
                    if (!Robot.Instance.GetMotorStatu())
                    {
                        Instance.MotorOn();
                        Thread.Sleep(500);
                    }

                    double distance = 0;
                    try
                    {
                        distance = Convert.ToDouble(tbx_moveDis.Text.Trim());
                    }
                    catch
                    {
                        return;
                    }
                    if (GDRightToLeft)
                        Instance.MoveXForewardForDistance(distance);
                    else
                        Instance.MoveXBackwardForDistance(distance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_YBackward_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdo_NotJog.Checked)
                {
                    if (!Robot.Instance.GetMotorStatu())
                    {
                        Instance.MotorOn();
                        Thread.Sleep(500);
                    }

                    double distance = 0;
                    try
                    {
                        distance = Convert.ToDouble(tbx_moveDis.Text.Trim());
                    }
                    catch
                    {
                        return;
                    }
                    if (GDRightToLeft)
                        Instance.MoveYBackwardForDistance(distance);
                    else
                        Instance.MoveYForewardForDistance(distance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_YForeward_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdo_NotJog.Checked)
                {
                    if (!Robot.Instance.GetMotorStatu())
                    {
                        Instance.MotorOn();
                        Thread.Sleep(500);
                    }

                    double distance = 0;
                    try
                    {
                        distance = Convert.ToDouble(tbx_moveDis.Text.Trim());
                    }
                    catch
                    {
                        return;
                    }
                    if (GDRightToLeft)
                        Instance.MoveYForewardForDistance(distance);
                    else
                        Instance.MoveYBackwardForDistance(distance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_ZMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdo_NotJog.Checked)
                {
                    if (!Robot.Instance.GetMotorStatu())
                    {
                        Instance.MotorOn();
                        Thread.Sleep(500);
                    }

                    if (rdo_fastVel.Checked || rdo_midVel.Checked)
                    {
                        rdo_verySlowVel.Checked = true;
                    }

                    double distance = 0;
                    try
                    {
                        distance = Convert.ToDouble(tbx_moveDis.Text.Trim());
                    }
                    catch
                    {
                        return;
                    }
                    Instance.MoveZForewardForDistance(distance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_ZMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdo_NotJog.Checked)
                {
                    if (!Robot.Instance.GetMotorStatu())
                    {
                        Instance.MotorOn();
                        Thread.Sleep(500);
                    }


                    if (rdo_fastVel.Checked || rdo_midVel.Checked)
                    {
                        rdo_verySlowVel.Checked = true;
                    }

                    double distance = 0;
                    try
                    {
                        distance = Convert.ToDouble(tbx_moveDis.Text.Trim());
                    }
                    catch
                    {
                        return;
                    }
                    if (distance > 10)
                    {
                        MessageBox.Show("运动失败，下移点动最大距离不得超过10mm！");
                        return;
                    }
                    Instance.MoveZBackwardForDistance(distance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_UForeward_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdo_NotJog.Checked)
                {
                    if (!Robot.Instance.GetMotorStatu())
                    {
                        Instance.MotorOn();
                        Thread.Sleep(500);
                    }

                    double distance = 0;
                    try
                    {
                        distance = Convert.ToDouble(tbx_moveDis.Text.Trim());
                    }
                    catch
                    {
                        return;
                    }
                    Instance.MoveUForewardForDistance(distance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_UBackward_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdo_NotJog.Checked)
                {
                    if (!Robot.Instance.GetMotorStatu())
                    {
                        Instance.MotorOn();
                        Thread.Sleep(500);
                    }

                    double distance = 0;
                    try
                    {
                        distance = Convert.ToDouble(tbx_moveDis.Text.Trim());
                    }
                    catch
                    {
                        return;
                    }
                    Instance.MoveUBackwardForDistance(distance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_XBackward_MouseDown(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                if (!Robot.Instance.GetMotorStatu())
                {
                    Instance.MotorOn();
                    Thread.Sleep(500);

                }
                if (GDRightToLeft)
                    Instance.MoveXBackward();
                else
                    Instance.MoveXForeward();
            }
        }
        private void btn_XBackward_MouseUp(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                Instance.StopX();
            }
        }
        private void btn_XForeward_MouseDown(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                if (!Robot.Instance.GetMotorStatu())
                {
                    Instance.MotorOn();
                    Thread.Sleep(500);
                }

                if (GDRightToLeft)
                    Instance.MoveXForeward();
                else
                    Instance.MoveXBackward();
            }
        }
        private void btn_XForeward_MouseUp(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                Instance.StopX();
            }
        }
        private void btn_YBackward_MouseDown(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                if (!Robot.Instance.GetMotorStatu())
                {
                    Instance.MotorOn();
                    Thread.Sleep(500);
                }

                if (GDRightToLeft)
                    Instance.MoveYBackward();
                else
                    Instance.MoveYForeward();
            }
        }
        private void btn_YBackward_MouseUp(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                Instance.StopY();
            }
        }
        private void btn_YForeward_MouseDown(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                if (!Robot.Instance.GetMotorStatu())
                {
                    Instance.MotorOn();
                    Thread.Sleep(500);
                }

                if (GDRightToLeft)
                    Instance.MoveYForeward();
                else
                    Instance.MoveYBackward();
            }
        }
        private void btn_YForeward_MouseUp(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                Instance.StopY();
            }
        }
        private void btn_ZMoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                if (!Robot.Instance.GetMotorStatu())
                {
                    Instance.MotorOn();
                    Thread.Sleep(500);
                }

                if (rdo_fastVel.Checked || rdo_midVel.Checked)
                {
                    rdo_verySlowVel.Checked = true;
                }

                Instance.MoveZForeward();
            }
        }
        private void btn_ZMoveUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                Instance.StopZ();
            }
        }
        private void btn_ZMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                if (!Robot.Instance.GetMotorStatu())
                {
                    Instance.MotorOn();
                    Thread.Sleep(500);
                }

                if (rdo_fastVel.Checked || rdo_midVel.Checked)
                {
                    rdo_verySlowVel.Checked = true;
                }

                Instance.MoveZBackward();
            }
        }
        private void btn_ZMoveDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                Instance.StopZ();
            }
        }
        private void btn_UForeward_MouseDown(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                if (!Robot.Instance.GetMotorStatu())
                {
                    Instance.MotorOn();
                    Thread.Sleep(500);
                }

                Instance.MoveUForeward();
            }
        }
        private void btn_UForeward_MouseUp(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                Instance.StopU();
            }
        }
        private void btn_UBackward_MouseDown(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                if (!Robot.Instance.GetMotorStatu())
                {
                    Instance.MotorOn();
                    Thread.Sleep(500);
                }

                Instance.MoveUBackward();
            }
        }
        private void btn_UBackward_MouseUp(object sender, MouseEventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                Instance.StopU();
            }
        }
        private void tbx_moveDis_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(tbx_moveDis.Text.Trim()) > 100)
                    tbx_moveDis.Text = "100";
                if (Convert.ToDouble(tbx_moveDis.Text.Trim()) <= 0)
                    tbx_moveDis.Text = "0.1";
            }
            catch { }
        }

        private void rdo_fastVel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_fastVel.Checked)
            {
                if (rdo_Jog.Checked)
                    Instance.velLevel = 90;
                else
                    Instance.velLevel = 20;
            }
        }
        private void rdo_midVel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_midVel.Checked)
            {
                if (rdo_Jog.Checked)
                    Instance.velLevel = 80;
                else
                    Instance.velLevel = 15;
            }
        }

        private void rdo_slowVel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_slowVel.Checked)
            {
                if (rdo_Jog.Checked)
                    Instance.velLevel = 60;
                else
                    Instance.velLevel = 10;
            }
        }
        private void rdo_verySlowVel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_verySlowVel.Checked)
            {
                if (rdo_Jog.Checked)
                    Instance.velLevel = 40;
                else
                    Instance.velLevel = 5;
            }
        }

        public int GetVel()
        {
            if (rdo_fastVel.Checked)
                return 26;
            if (rdo_midVel.Checked)
                return 20;
            if (rdo_slowVel.Checked)
                return 16;
            if (rdo_verySlowVel.Checked)
                return 8;
            return 26;
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            //Instance.StopRobot();
        }

        private void rdo_Jog_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_Jog.Checked)
            {
                if (rdo_fastVel.Checked)
                {
                    if (rdo_Jog.Checked)
                        Instance.velLevel = 90;
                    else
                        Instance.velLevel = 20;
                }

                if (rdo_midVel.Checked)
                {
                    if (rdo_Jog.Checked)
                        Instance.velLevel = 80;
                    else
                        Instance.velLevel = 15;
                }

                if (rdo_slowVel.Checked)
                {
                    if (rdo_Jog.Checked)
                        Instance.velLevel = 60;
                    else
                        Instance.velLevel = 10;
                }

                if (rdo_verySlowVel.Checked)
                {
                    if (rdo_Jog.Checked)
                        Instance.velLevel = 40;
                    else
                        Instance.velLevel = 5;
                }
            }
        }

        private void rdo_NotJog_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_NotJog.Checked)
            {
                if (rdo_fastVel.Checked)
                {
                    if (rdo_Jog.Checked)
                        Instance.velLevel = 100;
                    else
                        Instance.velLevel = 20;
                }

                if (rdo_midVel.Checked)
                {
                    if (rdo_Jog.Checked)
                        Instance.velLevel = 80;
                    else
                        Instance.velLevel = 15;
                }

                if (rdo_slowVel.Checked)
                {
                    if (rdo_Jog.Checked)
                        Instance.velLevel = 60;
                    else
                        Instance.velLevel = 10;
                }

                if (rdo_verySlowVel.Checked)
                {
                    if (rdo_Jog.Checked)
                        Instance.velLevel = 40;
                    else
                        Instance.velLevel = 5;
                }
            }
        }
    }

    /// <summary>
    /// 机器人控制基类
    /// </summary>
    public class RobotControl_Base
    {


        /// <summary>
        /// 是否已连接
        /// </summary>
        internal bool connected = false;
        /// <summary>
        /// Z安全高度
        /// </summary>
        public double safeHeight = 0;
        /// <summary>
        /// 速度等级    1-100
        /// </summary>
        public int velLevel = 10;
        /// <summary>
        /// 机器人IP地址
        /// </summary>
        internal string robotIP = "192.168.0.1";
        /// <summary>
        /// 机器人端口号
        /// </summary>
        internal Int32 robotPort = 10004;
        /// <summary>
        /// 机器人登录密码
        /// </summary>
        internal string loginPassword = "1234";
        /// <summary>
        /// Ini文件读写对象
        /// </summary>
        private Ini ini = new Ini(Environment.CurrentDirectory + "\\Config\\RobotControl.ini");

        /// <summary>
        /// 从本地读取参数
        /// </summary>
        internal void ReadPar()
        {
            try
            {
                safeHeight = Convert.ToDouble(ini.IniReadConfig("SafeHeight"));
                robotIP = ini.IniReadConfig("RobotIP");
                robotPort = Convert.ToInt32(ini.IniReadConfig("RobotPort"));
                loginPassword = ini.IniReadConfig("LoginPassword");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 写入参数到本地
        /// </summary>
        internal void WritePar()
        {
            try
            {
                ini.IniWriteConfig("SafeHeight", safeHeight.ToString());
                ini.IniWriteConfig("RobotIP", robotIP);
                ini.IniWriteConfig("RobotPort", robotPort.ToString());
                ini.IniWriteConfig("LoginPassword", loginPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 连接机器人
        /// </summary>
        public virtual bool Connect() { return false; }
        /// <summary>
        /// 获取机器人上电状态
        /// </summary>
        /// <returns></returns>
        public virtual bool GetMotorStatu() { return false; }
        /// <summary>
        /// 机器人上电
        /// </summary>
        /// <returns></returns>
        public virtual bool MotorOn() { return false; }
        /// <summary>
        /// 机器人下电
        /// </summary>
        /// <returns></returns>
        public virtual bool MotorOff() { return false; }
        /// <summary>
        /// 设置机器人运行速度  1-100
        /// </summary>
        /// <returns></returns>
        public virtual bool SetSpeed(int speed) { return false; }
        /// <summary>
        /// 获取机器人报警信息
        /// </summary>
        /// <returns></returns>
        public virtual string GetErrInfo() { return string.Empty; }
        /// <summary>
        /// 启动机器人程序
        /// </summary>
        internal virtual bool StartRobot() { return false; }
        /// <summary>
        /// 停止机器人程序
        /// </summary>
        internal virtual bool StopRobot() { return false; }
        /// <summary>
        /// 复位机器人程序
        /// </summary>
        internal virtual bool ResetRobot() { return false; }
        /// <summary>
        /// 机器人紧急停止
        /// </summary>
        /// <returns></returns>
        internal virtual bool EMGStop() { return false; }
        /// <summary>
        /// 机器人报警清除
        /// </summary>
        public virtual bool ClearAlarm() { return false; }
        /// <summary>
        /// 前往指定点位
        /// </summary>
        /// <returns></returns>
        internal virtual bool GoPoint(XYZU xyzu) { return false; }
        /// <summary>
        /// 控制输出
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual bool SetDo(int index, bool value) { return false; }
        /// <summary>
        /// 获取输入状态
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual bool GetDi(int index) { return false; }
        /// <summary>
        /// 获取输出状态
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual bool GetDo(int index) { return false; }
        /// <summary>
        /// 获取机器人当前坐标
        /// </summary>
        /// <returns></returns>
        public virtual bool GetCurPos(out RobotPos curPos) { curPos = new RobotPos(); return false; }
        /// <summary>
        /// 从控制器读取点位信息
        /// </summary>
        /// <returns></returns>
        internal virtual bool ReadPointPos(string pointName, out XYZU pos) { pos = new XYZU(); return false; }
        /// <summary>
        /// 写点位信息到控制器
        /// </summary>
        /// <returns></returns>
        internal virtual bool WritePointPos(string pointName, XYZU pos) { return false; }
        /// <summary>
        /// 等待运动到位
        /// </summary>
        internal virtual void WaitMoveDone() { }
        /// <summary>
        /// 门型移动到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual bool DoorMoveToPos(RobotPos robotPos, int vel, bool XYUmoveTagether = false) { return false; }
        /// <summary>
        /// 门型移动到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual bool DoorMoveToPos(XYZU pos, int vel) { return false; }
        /// <summary>
        /// 直线前往到某点
        /// </summary>
        /// <param name="robotPos"></param>
        /// <param name="vel"></param>
        /// <returns></returns>
        public virtual bool LineMoveToPos(RobotPos robotPos, int vel, bool waitDone) { return false; }
        /// <summary>
        /// 断开机器人
        /// </summary>
        public virtual void Disconnect() { }

        #region 位置控制
        /// <summary>
        /// X正方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveXForeward() { return false; }
        /// <summary>
        /// X负方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveXBackward() { return false; }
        /// <summary>
        /// Y正方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveYForeward() { return false; }
        /// <summary>
        /// Y负方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveYBackward() { return false; }
        /// <summary>
        /// Z正方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveZForeward() { return false; }
        /// <summary>
        /// Z负方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveZBackward() { return false; }
        /// <summary>
        /// U正方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveUForeward() { return false; }
        /// <summary>
        /// U负方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveUBackward() { return false; }
        /// <summary>
        /// 停止X轴移动
        /// </summary>
        /// <returns></returns>
        public virtual bool StopX() { return false; }
        /// <summary>
        /// 停止Y轴移动
        /// </summary>
        /// <returns></returns>
        public virtual bool StopY() { return false; }
        /// <summary>
        /// 停止Z轴移动
        /// </summary>
        /// <returns></returns>
        public virtual bool StopZ() { return false; }
        /// <summary>
        /// 停止U轴移动
        /// </summary>
        /// <returns></returns>
        public virtual bool StopU() { return false; }
        /// <summary>
        /// 停止机器人所有轴
        /// </summary>
        /// <returns></returns>
        public virtual bool StopXYZU() { return false; }
        /// <summary>
        /// X正方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveXForewardForDistance(double distance) { return false; }
        /// <summary>
        /// X负方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveXBackwardForDistance(double distance) { return false; }
        /// <summary>
        /// Y正方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveYForewardForDistance(double distance) { return false; }
        /// <summary>
        /// Y负方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveYBackwardForDistance(double distance) { return false; }
        /// <summary>
        /// Z正方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveZForewardForDistance(double distance) { return false; }
        /// <summary>
        /// Z负方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveZBackwardForDistance(double distance) { return false; }
        /// <summary>
        /// U正方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveUForewardForDistance(double distance) { return false; }
        /// <summary>
        /// U负方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveUBackwardForDistance(double distance) { return false; }
        /// <summary>
        /// 移动X轴到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual bool MoveXToPos(double pos, int vel, bool waitDone) { return false; }
        /// <summary>
        /// 移动Y轴到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual bool MoveYToPos(double pos, int vel, bool waitDone) { return false; }
        /// <summary>
        /// 移动Z轴到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual bool MoveZToPos(double pos, int vel, bool waitDone) { return false; }
        /// <summary>
        /// 移动U轴到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual bool MoveUToPos(double pos, int uRange, int vel, bool waitDone) { return false; }
        /// <summary>
        /// XY轴运行到指定位置
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        /// <param name="waitDone"></param>
        /// <returns></returns>
        public virtual bool MoveXYToPos(XYZU xyzu, int vel, bool waitDone) { return true; }
        /// <summary>
        /// XYU轴运行到指定位置
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        /// <param name="waitDone"></param>
        /// <returns></returns>
        public virtual bool MoveXYUToPos(XYZU xyzu, int vel, bool waitDone) { return true; }
        #endregion

    }

    /// <summary>
    /// 汇川机器人控制类
    /// </summary>
    internal class RobotControl_INOVANCE : RobotControl_Base
    {

        /// <summary>
        /// 连接机器人
        /// </summary>
        public override bool Connect()
        {
            try
            {
                connected = false;
                //首先初始化机器人
                byte[] bytes = IPAddress.Parse("192.168.23.25").GetAddressBytes();
                Array.Reverse(bytes);
                UInt32 IpAddr = BitConverter.ToUInt32(bytes, 0);
                int ret = IMC100API.IMC100_Init_ETH(IpAddr, (ushort)2222, 3000, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人连接失败，可能是刚刚通电，机器人还未完全上电，请尝试关闭程序后重新开启");
                    return false;
                }

                //强制获取控制权
                ret = IMC100API.IMC100_AcqPermit(1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人控制权获取失败");
                    return false;
                }

                //登录到管理员模式
                Int32 type = 2;
                String passwordStr = loginPassword;  //密码与示教器上一致
                Byte[] password = new Byte[8];
                password = System.Text.Encoding.Default.GetBytes("000000");
                ret = IMC100API.IMC100_UserLogin(type, password, 0);  //登陆到管理模式(可依据实际函数需求选择登陆的模式)
                if (ret < 0)
                {
                    MessageBox.Show("机器人控制登陆失败");
                    return false;
                }

                //设置为基坐标系
                ret = IMC100API.IMC100_Set_Coord(2, 0);
                if (ret < 0)
                {
                    MessageBox.Show("设置坐标系失败");
                }

                //开启数据流
                ret = IMC100API.IMC100_DsMode(1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("开启数据流失败");
                }

                connected = true;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 获取机器人上电状态
        /// </summary>
        /// <returns></returns>
        public override bool GetMotorStatu()
        {
            try
            {
                if (!connected)
                    return false;

                int sts = 0;
                Int32 ret = 0;
                ret = IMC100API.IMC100_Get_MotorSts(ref sts, 0);
                if (ret < 0)
                {
                    MessageBox.Show("获取机器人使能状态失败");
                    return false;
                }

                if (sts == 0)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 机器人上电
        /// </summary>
        /// <returns></returns>
        public override bool MotorOn()
        {
            try
            {
                if (!connected)
                    return false;

                ClearAlarm();

                Thread.Sleep(100);

                Int32 cmd = 1;
                Int32 ret = 0;
                ret = IMC100API.IMC100_MotorEnable(cmd, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人开使能失败，可能是急停被按下");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 机器人下电
        /// </summary>
        /// <returns></returns>
        public override bool MotorOff()
        {
            try
            {
                if (!connected)
                    return false;

                Int32 cmd = 0;
                Int32 ret = 0;
                ret = IMC100API.IMC100_MotorEnable(cmd, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人关使能失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 设置机器人运行速度  1-100
        /// </summary>
        /// <returns></returns>
        public override bool SetSpeed(int speed)
        {
            if (!connected)
                return false;

            Int32 ret = 0;
            if (speed < 1 || speed > 100)
            {
                speed = 1;
                MessageBox.Show("机器人速度数值输入错误,请输入数值小于等于100且大于等于1");
                return false;
            }
            ret = IMC100API.IMC100_Set_Vel(speed, 0);
            if (ret < 0)
            {
                MessageBox.Show("机器人设置速度失败");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取机器人报警信息
        /// </summary>
        /// <returns></returns>
        public override string GetErrInfo()
        {
            if (!connected)
                return "";

            Int32 err = 0;
            int ret = IMC100API.IMC100_Get_SysErr(ref err, 0);  //显示机器人故障
            if (ret >= 0)
                return String.Format("{0:x4}", err);
            else
                return "";
        }
        /// <summary>
        /// 启动机器人程序
        /// </summary>
        internal override bool StartRobot()
        {
            try
            {
                if (!connected)
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
        /// 停止机器人程序
        /// </summary>
        internal override bool StopRobot()
        {
            try
            {
                if (!connected)
                    return false;

                if (!StopX())
                    return false;

                if (!StopY())
                    return false;

                if (!StopZ())
                    return false;

                if (!StopU())
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
        /// 复位机器人程序
        /// </summary>
        internal override bool ResetRobot()
        {
            try
            {
                if (!connected)
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
        /// 机器人紧急停止
        /// </summary>
        /// <returns></returns>
        internal override bool EMGStop()
        {
            if (!connected)
                return false;

            Int32 ret = 0;
            ret = IMC100API.IMC100_EmergStop(1, 0);
            if (ret < 0)
            {
                MessageBox.Show("机器人急停操作失败");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 机器人报警清除
        /// </summary>
        public override bool ClearAlarm()
        {
            try
            {
                if (!connected)
                    return false;

                Int32 ret = 0;
                ret = IMC100API.IMC100_EmergStop(0, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人急停操作失败");
                    return false;
                }

                ret = IMC100API.IMC100_ResetErr(0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人报警清除失败");
                    return false;
                }

                //开启数据流
                ret = IMC100API.IMC100_DsMode(1, 0);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 前往指定点位
        /// </summary>
        /// <returns></returns>
        internal override bool GoPoint(XYZU xyzu)
        {
            try
            {
                if (!connected)
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
        /// 控制输出
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public override bool SetDo(int index, bool value)
        {
            try
            {
                if (!connected)
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
        /// 获取输入状态
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool GetDi(int index)
        {
            try
            {
                if (!connected)
                    return false;


                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 获取输出状态
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool GetDo(int index)
        {
            try
            {
                if (!connected)
                    return false;


                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 获取机器人当前坐标
        /// </summary>
        /// <returns></returns>
        public override bool GetCurPos(out RobotPos curPos)
        {
            curPos = new RobotPos();
            try
            {
                if (!connected)
                    return false;

                ROBOT_POS XYZpos = new ROBOT_POS();

                int ret = IMC100API.IMC100_Get_PosHere(ref XYZpos, 0);
                if (ret >= 0)
                {
                    curPos.xyzu.X = Math.Round(XYZpos.pos[0], 3);
                    curPos.xyzu.Y = Math.Round(XYZpos.pos[1], 3);
                    curPos.xyzu.Z = Math.Round(XYZpos.pos[2], 3);
                    curPos.xyzu.U = Math.Round(XYZpos.pos[3], 3);
                    curPos.xyzu.handType = XYZpos.armType[0] == -1 ? "左手系" : "右手系";
                    curPos.Urange = XYZpos.armType[3];
                }
                else
                {
                    MessageBox.Show("机器人设置速度失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 从控制器读取点位信息
        /// </summary>
        /// <returns></returns>
        internal override bool ReadPointPos(string pointName, out XYZU pos)
        {
            pos = new XYZU();
            try
            {
                if (!connected)
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
        /// 写点位信息到控制器
        /// </summary>
        /// <returns></returns>
        internal override bool WritePointPos(string pointName, XYZU pos)
        {
            try
            {
                if (!connected)
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
        /// 等待运动到位
        /// </summary>
        internal override void WaitMoveDone()
        {
            try
            {
                if (!connected)
                    return;

                //等待到位
                Int32 sts = 0;
                int ret = IMC100API.IMC100_Get_MotionSts(ref sts, 0);  //运动到位状态判断
                while (sts != 0)
                {
                    ret = IMC100API.IMC100_Get_MotionSts(ref sts, 0);  //运动到位状态判断
                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 门型移动到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public override bool DoorMoveToPos(RobotPos robotPos, int vel, bool XYUmoveTagether = false)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(vel))
                    return false;

                if (robotPos.xyzu.X == 0 && robotPos.xyzu.Y == 0 && robotPos.xyzu.Z == 0 && robotPos.xyzu.U == 0)
                    return false;


                //首先上升到安全高度
                if (safeHeight > robotPos.xyzu.Z)
                {
                    if (!MoveZToPos(safeHeight, vel, true))
                        return false;
                }
                else
                {
                    if (!MoveZToPos(robotPos.xyzu.Z, vel, true))
                        return false;
                }

                if (XYUmoveTagether)
                {
                    MoveXYUToPos(robotPos.xyzu, vel, true);
                }
                else
                {
                    if (!MoveXYToPos(robotPos.xyzu, vel, true))
                        return false;

                    if (!MoveUToPos(robotPos.xyzu.U, robotPos.Urange, vel, true))
                        return false;
                }

                WaitMoveDone();

                if (!MoveZToPos(robotPos.xyzu.Z, vel, true))
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
        /// 门型移动到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public override bool DoorMoveToPos(XYZU pos, int vel)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(vel))
                    return false;

                //开启数据流
                int ret = IMC100API.IMC100_DsMode(1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("开启数据流失败");
                    return false;
                }

                //首先上升到安全高度
                if (!MoveZToPos(safeHeight, vel, true))
                    return false;

                if (!MoveXYToPos(pos, vel, true))
                    return false;

                if (!MoveZToPos(pos.Z, vel, true))
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
        /// 直线前往到某点
        /// </summary>
        /// <param name="robotPos"></param>
        /// <param name="vel"></param>
        /// <returns></returns>
        public override bool LineMoveToPos(RobotPos robotPos, int vel, bool waitDone)
        {
            try
            {
                if (!connected)
                    return false;

                //开启数据流
                int ret = IMC100API.IMC100_DsMode(1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("开启数据流失败");
                    return false;
                }


                ROBOT_POS pos = new ROBOT_POS();
                pos.pos = new Double[6];
                pos.armType = new Int32[4];

                pos.pos[0] = robotPos.xyzu.X;
                pos.pos[1] = robotPos.xyzu.Y;
                pos.pos[2] = robotPos.xyzu.Z;
                pos.pos[3] = robotPos.xyzu.U;
                pos.pos[4] = 0;
                pos.pos[5] = 0;

                pos.armType[0] = (robotPos.xyzu.handType == "左手系" ? -1 : 1);//-1为左手，1为右手
                pos.armType[1] = 0;
                pos.armType[2] = 0;
                pos.armType[3] = robotPos.Urange;


                pos.coord = 2;//2为XYZ基坐标系
                pos.toolNo = 0;//0无工具坐标系
                pos.userNo = 0;//0无用户坐标系
                ret = IMC100API.IMC100_MovL2(pos, vel, 0, 0);
                if (ret < 0)
                {
                    return false;
                }

                Thread.Sleep(80);
                if (waitDone)
                {
                    Thread.Sleep(20);
                    WaitMoveDone();
                }

                //安全检查，判断是否确实已经运行到了相应位置
                RobotPos curPos = new RobotPos();
                if (!GetCurPos(out curPos))
                {
                    MessageBox.Show("获取当前位置失败");
                    return false;
                }
                if (Math.Abs(curPos.xyzu.X - robotPos.xyzu.X) > 3 || Math.Abs(curPos.xyzu.Y - robotPos.xyzu.Y) > 3 || Math.Abs(curPos.xyzu.Z - robotPos.xyzu.Z) > 3)
                {
                    Thread.Sleep(200);
                    //安全检查，判断是否确实已经运行到了相应位置
                    curPos = new RobotPos();
                    if (!GetCurPos(out curPos))
                    {
                        MessageBox.Show("获取当前位置失败");
                        return false;
                    }
                    if (Math.Abs(curPos.xyzu.X - robotPos.xyzu.X) > 3 || Math.Abs(curPos.xyzu.Y - robotPos.xyzu.Y) > 3 || Math.Abs(curPos.xyzu.Z - robotPos.xyzu.Z) > 3)
                    {


                        Thread.Sleep(300);
                        //安全检查，判断是否确实已经运行到了相应位置
                        curPos = new RobotPos();
                        if (!GetCurPos(out curPos))
                        {
                            MessageBox.Show("获取当前位置失败");
                            return false;
                        }
                        if (Math.Abs(curPos.xyzu.X - robotPos.xyzu.X) > 3 || Math.Abs(curPos.xyzu.Y - robotPos.xyzu.Y) > 3 || Math.Abs(curPos.xyzu.Z - robotPos.xyzu.Z) > 3)
                        {
                            MessageBox.Show(String.Format("运动出错，未运动到位，目标位置：X:{0}   Y:{1}   Z:{2}   ,结果位置：X{3}  Y:{4}  Z:{5}", robotPos.xyzu.X, robotPos.xyzu.Y, robotPos.xyzu.Z, curPos.xyzu.X, curPos.xyzu.Y, curPos.xyzu.Z));
                            return false;
                        }


                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 断开机器人
        /// </summary>
        public override void Disconnect()
        {
            try
            {
                if (!connected)
                    return;

                Int32 ret = 0;
                ret = IMC100API.IMC100_Exit_ETH(0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人断开连接失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region 位置控制
        /// <summary>
        /// X正方向移动
        /// </summary>
        /// <returns></returns>
        public override bool MoveXForeward()
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel + 10))
                    return false;

                IMC100API.IMC100_InchMode(0, 0);

                //关闭数据流
                int ret = IMC100API.IMC100_DsMode(0, 0);
                if (ret < 0)
                {
                    MessageBox.Show("开启数据流失败");
                }

                ret = IMC100API.IMC100_Jog(1, 1, 1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// X负方向移动
        /// </summary>
        /// <returns></returns>
        public override bool MoveXBackward()
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel + 10))
                    return false;

                IMC100API.IMC100_InchMode(0, 0);

                //关闭数据流
                int ret = IMC100API.IMC100_DsMode(0, 0);
                if (ret < 0)
                {
                    MessageBox.Show("开启数据流失败");
                }

                ret = IMC100API.IMC100_Jog(1, 1, -1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Y正方向移动
        /// </summary>
        /// <returns></returns>
        public override bool MoveYForeward()
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel + 10))
                    return false;

                IMC100API.IMC100_InchMode(0, 0);

                //关闭数据流
                int ret = IMC100API.IMC100_DsMode(0, 0);
                if (ret < 0)
                {
                    MessageBox.Show("开启数据流失败");
                }

                ret = IMC100API.IMC100_Jog(1, 2, 1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Y负方向移动
        /// </summary>
        /// <returns></returns>
        public override bool MoveYBackward()
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel + 10))
                    return false;

                IMC100API.IMC100_InchMode(0, 0);

                //关闭数据流
                int ret = IMC100API.IMC100_DsMode(0, 0);
                if (ret < 0)
                {
                    MessageBox.Show("开启数据流失败");
                }

                ret = IMC100API.IMC100_Jog(1, 2, -1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Z正方向移动
        /// </summary>
        /// <returns></returns>
        public override bool MoveZForeward()
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel > 40 ? 40 : velLevel))
                    return false;

                //关闭寸动
                IMC100API.IMC100_InchMode(0, 0);

                //关闭数据流
                int ret = IMC100API.IMC100_DsMode(0, 0);
                if (ret < 0)
                {
                    MessageBox.Show("开启数据流失败");
                }

                ret = IMC100API.IMC100_Jog(1, 3, 1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Z负方向移动
        /// </summary>
        /// <returns></returns>
        public override bool MoveZBackward()
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel > 40 ? 40 : velLevel))
                    return false;

                //关闭寸动
                IMC100API.IMC100_InchMode(0, 0);

                //关闭数据流
                int ret = IMC100API.IMC100_DsMode(0, 0);
                if (ret < 0)
                {
                    MessageBox.Show("开启数据流失败");
                }

                ret = IMC100API.IMC100_Jog(1, 3, -1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// U正方向移动
        /// </summary>
        /// <returns></returns>
        public override bool MoveUForeward()
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel + 10))
                    return false;

                //关闭寸动
                IMC100API.IMC100_InchMode(0, 0);

                //关闭数据流
                int ret = IMC100API.IMC100_DsMode(0, 0);
                if (ret < 0)
                {
                    MessageBox.Show("开启数据流失败");
                }

                ret = IMC100API.IMC100_Jog(1, 4, 1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// U负方向移动
        /// </summary>
        /// <returns></returns>
        public override bool MoveUBackward()
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel + 10))
                    return false;

                //关闭寸动
                IMC100API.IMC100_InchMode(0, 0);

                //关闭数据流
                int ret = IMC100API.IMC100_DsMode(0, 0);
                if (ret < 0)
                {
                    MessageBox.Show("开启数据流失败");
                }

                ret = IMC100API.IMC100_Jog(1, 4, -1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 停止X轴移动
        /// </summary>
        /// <returns></returns>
        public override bool StopX()
        {
            try
            {
                if (!connected)
                    return false;

                ////关闭数据流
                //int ret = IMC100API.IMC100_DsMode(0, 0);
                //if (ret < 0)
                //{
                //    MessageBox.Show("关闭数据流失败");
                //}

                int ret = IMC100API.IMC100_Jog(1, 1, 0, 0);
                if (ret < 0)
                    return false;

                //ret = IMC100API.IMC100_DsMode(1, 0);
                //if (ret < 0)
                //{
                //    MessageBox.Show("关闭数据流失败");
                //}

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 停止Y轴移动
        /// </summary>
        /// <returns></returns>
        public override bool StopY()
        {
            try
            {
                if (!connected)
                    return false;

                ////关闭数据流
                //int ret = IMC100API.IMC100_DsMode(0, 0);
                //if (ret < 0)
                //{
                //    MessageBox.Show("关闭数据流失败");
                //}

                int ret = IMC100API.IMC100_Jog(1, 2, 0, 0);
                if (ret < 0)
                    return false;

                //ret = IMC100API.IMC100_DsMode(1, 0);
                //if (ret < 0)
                //{
                //    MessageBox.Show("关闭数据流失败");
                //}

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 停止Z轴移动
        /// </summary>
        /// <returns></returns>
        public override bool StopZ()
        {
            try
            {
                if (!connected)
                    return false;

                ////关闭数据流
                //int ret = IMC100API.IMC100_DsMode(0, 0);
                //if (ret < 0)
                //{
                //    MessageBox.Show("关闭数据流失败");
                //}

                int ret = IMC100API.IMC100_Jog(1, 3, 0, 0);
                if (ret < 0)
                    return false;

                //ret = IMC100API.IMC100_DsMode(1, 0);
                //if (ret < 0)
                //{
                //    MessageBox.Show("关闭数据流失败");
                //}

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 停止U轴移动
        /// </summary>
        /// <returns></returns>
        public override bool StopU()
        {
            try
            {
                if (!connected)
                    return false;

                ////关闭数据流
                //int ret = IMC100API.IMC100_DsMode(0, 0);
                //if (ret < 0)
                //{
                //    MessageBox.Show("关闭数据流失败");
                //}

                int ret = IMC100API.IMC100_Jog(1, 4, 0, 0);
                if (ret < 0)
                    return false;

                //ret = IMC100API.IMC100_DsMode(1, 0);
                //if (ret < 0)
                //{
                //    MessageBox.Show("关闭数据流失败");
                //}

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 停止机器人所有轴
        /// </summary>
        /// <returns></returns>
        public override bool StopXYZU()
        {
            try
            {
                if (!connected)
                    return false;

                StopX();
                StopY();
                StopZ();
                StopU();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// X正方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public override bool MoveXForewardForDistance(double distance)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel))
                    return false;

                IMC100API.IMC100_Set_StepMotionL((float)distance, 0);
                IMC100API.IMC100_Set_InchStep(4, 0);
                IMC100API.IMC100_InchMode(1, 0);

                int ret = IMC100API.IMC100_Jog(1, 1, 1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// X负方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public override bool MoveXBackwardForDistance(double distance)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel))
                    return false;

                IMC100API.IMC100_Set_StepMotionL((float)distance, 0);
                IMC100API.IMC100_Set_InchStep(4, 0);
                IMC100API.IMC100_InchMode(1, 0);

                int ret = IMC100API.IMC100_Jog(1, 1, -1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Y正方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public override bool MoveYForewardForDistance(double distance)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel))
                    return false;

                IMC100API.IMC100_Set_StepMotionL((float)distance, 0);
                IMC100API.IMC100_Set_InchStep(4, 0);
                IMC100API.IMC100_InchMode(1, 0);

                int ret = IMC100API.IMC100_Jog(1, 2, 1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Y负方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public override bool MoveYBackwardForDistance(double distance)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel))
                    return false;

                IMC100API.IMC100_Set_StepMotionL((float)distance, 0);
                IMC100API.IMC100_Set_InchStep(4, 0);
                IMC100API.IMC100_InchMode(1, 0);

                int ret = IMC100API.IMC100_Jog(1, 2, -1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Z正方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public override bool MoveZForewardForDistance(double distance)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel))
                    return false;

                IMC100API.IMC100_Set_StepMotionL((float)distance, 0);
                IMC100API.IMC100_Set_InchStep(4, 0);
                IMC100API.IMC100_InchMode(1, 0);

                int ret = IMC100API.IMC100_Jog(1, 3, 1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Z负方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public override bool MoveZBackwardForDistance(double distance)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel))
                    return false;

                IMC100API.IMC100_Set_StepMotionL((float)distance, 0);
                IMC100API.IMC100_Set_InchStep(4, 0);
                IMC100API.IMC100_InchMode(1, 0);

                int ret = IMC100API.IMC100_Jog(1, 3, -1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// U正方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public override bool MoveUForewardForDistance(double distance)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel))
                    return false;

                IMC100API.IMC100_Set_StepMotionL((float)distance, 0);
                IMC100API.IMC100_Set_InchStep(4, 0);
                IMC100API.IMC100_InchMode(1, 0);

                int ret = IMC100API.IMC100_Jog(1, 4, 1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// U负方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public override bool MoveUBackwardForDistance(double distance)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(velLevel))
                    return false;

                IMC100API.IMC100_Set_StepMotionL((float)distance, 0);
                IMC100API.IMC100_Set_InchStep(4, 0);
                IMC100API.IMC100_InchMode(1, 0);

                int ret = IMC100API.IMC100_Jog(1, 4, -1, 0);
                if (ret < 0)
                {
                    MessageBox.Show("机器人Job运动失败");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 移动X轴到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public override bool MoveXToPos(double pos, int vel, bool waitDone)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(vel))
                    return false;

                RobotPos curPos;
                if (!GetCurPos(out curPos))
                    return false;

                curPos.xyzu.X = pos;

                LineMoveToPos(curPos, vel, waitDone);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 移动Y轴到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public override bool MoveYToPos(double pos, int vel, bool waitDone)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(vel))
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
        /// 移动Z轴到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public override bool MoveZToPos(double pos, int vel, bool waitDone)
        {
            try
            {
                try
                {
                    if (!connected)
                        return false;

                    if (!SetSpeed(vel))
                        return false;

                    RobotPos curPos;
                    if (!GetCurPos(out curPos))
                        return false;

                    curPos.xyzu.Z = pos;

                    LineMoveToPos(curPos, vel, waitDone);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 移动U轴到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public override bool MoveUToPos(double pos, int uRange, int vel, bool waitDone)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(vel))
                    return false;

                RobotPos curPos;
                if (!GetCurPos(out curPos))
                    return false;

                curPos.xyzu.U = pos;
                curPos.Urange = uRange;

                LineMoveToPos(curPos, vel, waitDone);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// XY轴运行到指定位置
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        /// <param name="waitDone"></param>
        /// <returns></returns>
        public override bool MoveXYToPos(XYZU xyzu, int vel, bool waitDone)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(vel))
                    return false;

                RobotPos curPos;
                if (!GetCurPos(out curPos))
                    return false;

                curPos.xyzu.X = xyzu.X;
                curPos.xyzu.Y = xyzu.Y;

                LineMoveToPos(curPos, vel, waitDone);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// XYU轴运行到指定位置
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        /// <param name="waitDone"></param>
        /// <returns></returns>
        public override bool MoveXYUToPos(XYZU xyzu, int vel, bool waitDone)
        {
            try
            {
                if (!connected)
                    return false;

                if (!SetSpeed(vel))
                    return false;

                RobotPos curPos;
                if (!GetCurPos(out curPos))
                    return false;

                curPos.xyzu.X = xyzu.X;
                curPos.xyzu.Y = xyzu.Y;
                curPos.xyzu.U = xyzu.U;

                LineMoveToPos(curPos, vel, waitDone);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        #endregion

    }

    /// <summary>
    /// 众为兴机器人控制类
    /// </summary>
    internal class RobotControl_ADTECH : RobotControl_Base
    {

        /// <summary>
        /// 连接机器人
        /// </summary>
        public override bool Connect()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 机器人上电
        /// </summary>
        /// <returns></returns>
        public override bool MotorOn()
        {
            try
            {
                if (!connected)
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
        /// 机器人下电
        /// </summary>
        /// <returns></returns>
        public override bool MotorOff()
        {
            try
            {
                if (!connected)
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
        /// 设置机器人运行速度  1-100
        /// </summary>
        /// <returns></returns>
        public override bool SetSpeed(int speed)
        {

            return false;
        }
        /// <summary>
        /// 获取机器人报警信息
        /// </summary>
        /// <returns></returns>
        public override string GetErrInfo() { return string.Empty; }
        /// <summary>
        /// 启动机器人程序
        /// </summary>
        internal override bool StartRobot()
        {
            try
            {
                if (!connected)
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
        /// 停止机器人程序
        /// </summary>
        internal override bool StopRobot()
        {
            try
            {
                if (!connected)
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
        /// 复位机器人程序
        /// </summary>
        internal override bool ResetRobot()
        {
            try
            {
                if (!connected)
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
        /// 机器人紧急停止
        /// </summary>
        /// <returns></returns>
        internal override bool EMGStop()
        {

            return false;
        }
        /// <summary>
        /// 机器人报警清除
        /// </summary>
        public override bool ClearAlarm()
        {
            try
            {
                if (!connected)
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
        /// 前往指定点位
        /// </summary>
        /// <returns></returns>
        internal override bool GoPoint(XYZU xyzu)
        {
            try
            {
                if (!connected)
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
        /// 控制输出
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public override bool SetDo(int index, bool value)
        {
            try
            {
                if (!connected)
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
        /// 获取输入状态
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool GetDi(int index)
        {
            try
            {
                if (!connected)
                    return false;


                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 获取输出状态
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool GetDo(int index)
        {
            try
            {
                if (!connected)
                    return false;


                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 获取机器人当前坐标
        /// </summary>
        /// <returns></returns>
        public override bool GetCurPos(out RobotPos curPos)
        {
            curPos = new RobotPos();
            try
            {
                if (!connected)
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
        /// 从控制器读取点位信息
        /// </summary>
        /// <returns></returns>
        internal override bool ReadPointPos(string pointName, out XYZU pos)
        {
            pos = new XYZU();
            try
            {
                if (!connected)
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
        /// 写点位信息到控制器
        /// </summary>
        /// <returns></returns>
        internal override bool WritePointPos(string pointName, XYZU pos)
        {
            try
            {
                if (!connected)
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
        /// 等待运动到位
        /// </summary>
        internal override void WaitMoveDone()
        {
            try
            {
                Int32 sts = 0;
                do
                {
                    IMC100API.IMC100_Get_MotionSts(ref sts, 0);
                }
                while (sts == 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 门型移动到指定位置
        /// </summary>
        /// <param name="robotPos"></param>
        /// <returns></returns>
        public override bool DoorMoveToPos(RobotPos robotPos, int vel, bool XYUmoveTagether)
        {
            try
            {
                if (!connected)
                    return false;

                //首先上升到安全高度
                if (!MoveZToPos(safeHeight, vel, true))
                    return false;

                if (!MoveXYToPos(robotPos.xyzu, vel, true))
                    return false;

                if (!MoveZToPos(robotPos.xyzu.Z, vel, true))
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
        /// 门型移动到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public override bool DoorMoveToPos(XYZU pos, int vel)
        {

            return false;
        }
        /// <summary>
        /// 断开机器人
        /// </summary>
        public override void Disconnect()
        {
            try
            {
                if (!connected)
                    return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region 位置控制
        /// <summary>
        /// X正方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveXForeward()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// X负方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveXBackward()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Y正方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveYForeward()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Y负方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveYBackward()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Z正方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveZForeward()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Z负方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveZBackward()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// U正方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveUForeward()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// U负方向移动
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveUBackward()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 停止X轴移动
        /// </summary>
        /// <returns></returns>
        public virtual bool StopX()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 停止Y轴移动
        /// </summary>
        /// <returns></returns>
        public virtual bool StopY()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 停止Z轴移动
        /// </summary>
        /// <returns></returns>
        public virtual bool StopZ()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 停止U轴移动
        /// </summary>
        /// <returns></returns>
        public virtual bool StopU()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 停止机器人所有轴
        /// </summary>
        /// <returns></returns>
        public virtual bool StopXYZU()
        {
            try
            {
                if (!StopX())
                    return false;
                if (!StopY())
                    return false;
                if (!StopZ())
                    return false;
                if (!StopU())
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
        /// X正方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveXForewardForDistance(double distance)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// X负方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveXBackwardForDistance(double distance)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Y正方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveYForewardForDistance(double distance)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Y负方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveYBackwardForDistance(double distance)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Z正方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveZForewardForDistance(double distance)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Z负方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveZBackwardForDistance(double distance)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// U正方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveUForewardForDistance(double distance)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// U负方向移动指定距离
        /// </summary>
        /// <returns></returns>
        public virtual bool MoveUBackwardForDistance(double distance)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 移动X轴到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual bool MoveXToPos(double pos, int vel, bool waitDone)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 移动Y轴到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual bool MoveYToPos(double pos, int vel, bool waitDone)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 移动Z轴到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual bool MoveZToPos(double pos, int vel, bool waitDone)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 移动U轴到指定位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual bool MoveUToPos(double pos, int uRange, int vel, bool waitDone)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// XY轴运行到指定位置
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        /// <param name="waitDone"></param>
        /// <returns></returns>
        public virtual bool MoveXYToPos(RobotPos robotPos, int vel, bool waitDone)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        #endregion

    }

    [Serializable]
    public class XYZU
    {
        public int index = 1;
        public XYZU() { }
        public XYZU(double x, double y, double z, double u)
        {
            X = x;
            Y = y;
            Z = z;
            U = u;
        }
        public double X;
        public double Y;
        public double Z;
        public double U;
        public string handType = "左手系";       //手系
    }

    /// <summary>
    /// 机器人点位结构
    /// </summary>
    [Serializable]
    public class RobotPos
    {
        public int index = 0;
        public string name = string.Empty;
        public int vel = 10;
        public XYZU xyzu = new XYZU();
        public string info = string.Empty;
        public int Urange = 0;
    }

}
