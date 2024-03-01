using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VM_Pro.Properties;

namespace VM_Pro
{
    /// <summary>
    /// 运动控制卡基类
    /// </summary>
    [Serializable]
    internal class CardBase
    {

        internal CardBase()
        {
            for (int i = 0; i < L_axisName.Length; i++)
            {
                L_axisName[i] = "轴 " + (i + 1);
                L_allowOffset[i] = 0.1;
            }
            for (int i = 0; i < 32; i++)
            {
                L_pulseRate[i] = 1;
                L_homeVel[i] = 10;
                L_backLength[i] = 20;
                L_safePos[i] = 10;
                L_NLimit[i] = -10;
                L_PLimit[i] = 20;
            }
            for (int i = 0; i < L_diLogicLevel.Length; i++)
            {
                L_diLogicLevel[i] = true;
            }
            for (int i = 0; i < L_MotorType.Length; i++)
            {
                L_MotorType[i] = true;
            }
        }

        /// <summary>
        /// 板卡类型
        /// </summary>
        internal CardType cardType = CardType.雷赛_DMC1000B;
        /// <summary>
        /// 资源锁
        /// </summary>  
        internal object obj = new object();
        /// <summary>
        /// 已连接
        /// </summary>
        internal bool connected = false;
        /// <summary>
        /// 离线虚拟板卡
        /// </summary>
        internal bool vitualCard = false;
        /// <summary>
        /// 输入逻辑电平
        /// </summary>
        internal bool[] L_diLogicLevel = new bool[100];
        /// <summary>
        /// 输出逻辑电平
        /// </summary>
        internal bool[] L_doLogicLevel = new bool[100];
        /// <summary>
        /// 电机类型   True：伺服电机    False：步进电机
        /// </summary>
        internal bool[] L_MotorType = new bool[32];
        /// <summary>
        /// 轴名称
        /// </summary>
        internal string[] L_axisName = new string[32];
        /// <summary>
        /// 允许偏差
        /// </summary>
        internal double[] L_allowOffset = new double[32];
        /// <summary>
        /// 回零模式
        /// </summary>
        internal HomeMode[] L_homeMode = new HomeMode[32];
        /// <summary>
        /// 回零方向
        /// </summary>
        internal Dir[] L_homeDir = new Dir[32];
        /// <summary>
        /// 脉冲输出方式
        /// </summary>
        internal int[] L_pulseMode = new int[32];
        /// <summary>
        /// 脉冲毫米比
        /// </summary>
        internal double[] L_pulseRate = new double[32];
        /// <summary>
        /// 回零速度
        /// </summary>
        internal double[] L_homeVel = new double[32];
        /// <summary>
        /// 回零回退距离
        /// </summary>
        internal double[] L_backLength = new double[32];
        /// <summary>
        /// 安全位置
        /// </summary>
        internal double[] L_safePos = new double[32];
        /// <summary>
        /// 负软极限
        /// </summary>
        internal double[] L_NLimit = new double[32];
        /// <summary>
        /// 正软极限
        /// </summary>
        internal double[] L_PLimit = new double[32];
        /// <summary>
        /// 原点逻辑电平
        /// </summary>
        internal LogicLevel[] L_OriginLogic = new LogicLevel[32];
        /// <summary>
        /// 正限位逻辑电平
        /// </summary>
        internal LogicLevel[] L_PLimitLogic = new LogicLevel[32];
        /// <summary>
        /// 负限位逻辑电平
        /// </summary>
        internal LogicLevel[] L_NLimitLogic = new LogicLevel[32];


        /// <summary>
        /// 初始化
        /// </summary>
        internal virtual void Init(string name) { }
        /// <summary>
        /// 清除报警
        /// </summary>
        internal virtual void ClearAlarm() { }
        /// <summary>
        /// 设置脉冲输出方式
        /// </summary>
        /// <param name="axisIndex"></param>
        /// <param name="mode"></param>
        internal virtual void SetPulseMode(int axisIndex) { }
        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="axisIndex"></param>
        internal virtual bool Home(int axisIndex, bool testMode = false) { return false; }
        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="axisName">轴枚举</param>
        internal virtual bool Home(Axis axisName) { return false; }



        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="axisIndex"></param>
        internal virtual void HomeByFindNLimit(int axisIndex, bool testMode = false) { }
        /// <summary>
        /// 轴回零
        /// </summary>
        /// <param name="axisName">轴枚举</param>
        internal virtual bool HomeU(Axis axisName) { return false; }



        /// <summary>
        /// 上电
        /// </summary>
        /// <param name="axisIndex"></param>
        internal virtual void MotorOn(int axisIndex, bool testMode = false) { }
        /// <summary>
        /// 下电
        /// </summary>
        /// <param name="axisIndex"></param>
        internal virtual void MotorOff(int axisIndex, bool testMode = false) { }
        /// <summary>
        /// 获取上电状态
        /// </summary>
        /// <param name="axisIndex"></param>
        internal virtual bool GetMotorStatu(int axisIndex, bool testMode = false) { return false; }
        /// <summary>
        /// 当前是否在原点
        /// </summary>
        /// <param name="axisIndex"></param>
        /// <returns></returns>
        internal virtual bool InHome(int axisIndex, bool testMode = false) { return false; }
        /// <summary>
        /// 当前是否在负限位
        /// </summary>
        /// <param name="axisIndex"></param>
        /// <returns></returns>
        internal virtual bool InPEL(int axisIndex, bool testMode = false) { return false; }
        /// <summary>
        /// 是否运动到位
        /// </summary>
        /// <param name="axisIndex"></param>
        /// <returns></returns>
        internal virtual bool Inp(int axisIndex) { return false; }
        /// <summary>
        /// 当前是否在正限位
        /// </summary>
        /// <param name="axisIndex"></param>
        /// <returns></returns>
        internal virtual bool InNEL(int axisIndex, bool testMode = false) { return false; }
        /// <summary>
        /// 获取指定轴报警状态
        /// </summary>
        /// <param name="axisIndex">轴索引</param>
        /// <returns>轴是否报警</returns>
        internal virtual bool IsAlarm(int axisIndex, bool testMode = false) { return false; }
        /// <summary>
        /// 获取指定轴运动状态
        /// </summary>
        /// <param name="axisIndex">轴索引</param>
        /// <returns>轴是否运动</returns>
        internal virtual bool IsMoving(int axisIndex, bool testMode = false) { return false; }
        /// <summary>
        /// 获取通用输入状态
        /// </summary>
        /// <param name="doName"></param>
        /// <returns></returns>
        internal virtual OnOff GetDiSts(Di diName, bool testMode = false) { return OnOff.Off; }
        /// <summary>
        /// 获取通用输入状态
        /// </summary>
        /// <param actIdx="doName"></param>
        /// <returns></returns>
        internal virtual OnOff GetDiSts(int actIdx, bool testMode = false) { return OnOff.Off; }
        /// <summary>
        /// 获取通用输出状态
        /// </summary>
        /// <param name="doName"></param>
        /// <returns></returns>
        internal virtual OnOff GetDoSts(Do doName, bool testMode = false) { return OnOff.Off; }
        /// <summary>
        /// 获取通用输出状态
        /// </summary>
        /// <param name="actIdx"></param>
        /// <returns></returns>
        internal virtual OnOff GetDoSts(int actIdx, bool testMode = false) { return OnOff.Off; }
        /// <summary>
        /// 操作通用输出
        /// </summary>
        /// <param name="doName"></param>
        /// <param name="onOff"></param>
        internal virtual void SetDo(Do doName, OnOff onOff, bool testMode = false) { }
        /// <summary>
        /// 操作通用输出
        /// </summary>
        /// <param actIdx="doName"></param>
        /// <param name="onOff"></param>
        internal virtual void SetDo(int actIdx, OnOff onOff, bool testMode = false) { }
        /// <summary>
        /// 等待输入信号到达某状态
        /// </summary>
        /// <param name="diName"></param>
        /// <param name="onOff"></param>
        internal virtual void WaitDi(Di diName, OnOff level, bool testMode = false) { }
        /// <summary>
        /// 获取当前命令位置
        /// </summary>
        /// <param name="axisName">名称</param>
        /// <returns>当前命令位置</returns>
        internal virtual double GetCmdPos(Axis axisName, bool testMode = false) { return 0; }
        /// <summary>
        /// 获取当前命令位置
        /// </summary>
        /// <param name="axisName">名称</param>
        /// <returns>当前命令位置</returns>
        internal virtual double GetCmdPos(int axisIndex, bool testMode = false) { return 0; }
        /// <summary>
        /// 获取当前编码位置
        /// </summary>
        /// <param name="axisName">名称</param>
        /// <returns>当前编码位置</returns>
        internal virtual double GetEncPos(int axisIndex, bool testMode = false) { return 0; }
        /// <summary>
        /// 连续运动
        /// </summary>
        /// <param name="axisName">轴名称</param>
        internal virtual void KeepMove(Axis axisName, Dir dir, int vel, bool waitDone, bool testMode = false) { }
        /// <summary>
        /// 连续运动
        /// </summary>
        /// <param name="axisName">轴索引</param>
        internal virtual void KeepMove(int axisIndex, int dir, int vel, bool waitDone, bool testMode = false) { }
        /// <summary>
        /// 相对位置移动
        /// </summary>
        /// <param name="axisName">轴名称</param>
        /// <param name="distance">移动距离</param>
        /// <param name="vel">移动速度</param>
        /// <param name="waitDone">是否等待</param>
        /// <returns></returns>
        internal virtual bool MoveRel(Axis axisName, double distance, int vel, bool waitDone = true, bool testMode = false) { return false; }
        /// <summary>
        /// 相对位置移动
        /// </summary>
        /// <param name="axisName">轴名称</param>
        /// <param name="distance">移动距离</param>
        /// <param name="vel">移动速度</param>
        /// <param name="waitDone">是否等待</param>
        /// <returns></returns>
        internal virtual bool MoveRel(int axisIndex, double distance, int vel, bool waitDone = true, bool testMode = false) { return false; }
        /// <summary>
        /// 插补运动
        /// </summary>
        /// <returns></returns>
        internal virtual bool MoveInterpolate(Axis axis1, Axis axis2, double pos1, double pos2, double acc, double vel) { return true; }
        /// <summary>
        /// 绝对位置移动
        /// </summary>
        /// <param name="axisName">轴名称</param>
        /// <param name="targetPos">目标位置</param>
        /// <param name="vel">移动速度</param>
        /// <param name="waitDone">是否等待</param>
        /// <returns></returns>
        internal virtual bool MoveAbs(int axixIndex, double targetPos, int vel, bool waitDone, bool testMode = false) { return false; }
        /// <summary>
        /// 绝对位置移动
        /// </summary>
        /// <param name="axisName">轴名称</param>
        /// <param name="targetPos">目标位置</param>
        /// <param name="vel">移动速度</param>
        /// <param name="waitDone">是否等待</param>
        /// <returns></returns>
        internal virtual bool MoveAbs(string axisName, double targetPos, int vel, bool waitDone, bool testMode = false) { return false; }
        /// <summary>
        /// 减速停止
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        internal virtual void DecStop(int axisIndex, bool testMode = false) { }
        /// <summary>
        /// 减速停止
        /// </summary>
        /// <param name="axisName">轴枚举</param>
        internal virtual void DecStop(Axis axisName) { }
        /// <summary>
        /// 立即停止
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        internal virtual void QuickStop(int axisIndex, bool testMode = false) { }
        /// <summary>
        /// 立即停止
        /// </summary>
        /// <param name="axisName">轴枚举</param>
        internal virtual void QuickStop(Axis axisName) { }
        /// <summary>
        /// 等待运动完成
        /// </summary>
        /// <param name="axisIndex">轴索引号</param>
        internal virtual bool WaitMoveDone(int axisIndex, int checkInp = 0, bool testMode = false) { return false; }
        /// <summary>
        /// 轴是否正在运动
        /// </summary>
        /// <param name="axisName"></param>
        /// <returns></returns>
        internal virtual bool IsMoving(Axis axisName) { return true; }
        /// <summary>
        /// 关闭运动控制卡
        /// </summary>
        internal virtual void Close() { }
        /// <summary>
        /// 通过输入点名称获取输入点映射号
        /// </summary>
        /// <param name="diName">名称</param>
        /// <returns>映射号</returns>
        internal static int FindDiActIdxByName(Di diName)
        {
            for (int i = 0; i < Project.L_di.Count; i++)
            {
                if (Project.L_di[i].diName == diName)
                    return Project.L_di[i].actNo;
            }
            FuncLib.ShowMsg(string.Format("未查找到名为 {0} 的输入点，请检查", diName), InfoType.Error);
            FuncLib.ShowMessageBox(string.Format("未查找到名为 {0} 的输入点，请检查", diName), InfoType.Error);
            return -1;
        }
        /// <summary>
        /// 通过输出点名称获取输出点映射号
        /// </summary>
        /// <param name="doName">名称</param>
        /// <returns>映射号</returns>
        internal static int FindDoActIdxByName(Do doName)
        {
            for (int i = 0; i < Project.L_do.Count; i++)
            {
                if (Project.L_do[i].doName == doName)
                    return Project.L_do[i].actNo;
            }
            FuncLib.ShowMsg(string.Format("未查找到名为 {0} 的输出点，请检查", doName), InfoType.Error);
            FuncLib.ShowMessageBox(string.Format("未查找到名为 {0} 的输出点，请检查", doName), InfoType.Error);
            return -1;
        }
        /// <summary>
        /// 通过轴名称获取轴映射号
        /// </summary>
        /// <param name="axisName">名称</param>
        /// <returns>轴映射号</returns>
        internal S_Axis FindAxisByName(object axisName)
        {
            for (int i = 0; i < Project.L_axis.Count; i++)
            {
                if (Project.L_axis[i].axisName == axisName.ToString())
                    return Project.L_axis[i];
            }
            FuncLib.ShowMsg(string.Format("未查找到名为 {0} 的轴，请检查", axisName), InfoType.Error);
            FuncLib.ShowMessageBox(string.Format("未查找到名为 {0} 的轴，请检查", axisName), InfoType.Error);
            return new S_Axis();
        }
        /// <summary>
        /// 通过轴索引获取轴名称
        /// </summary>
        /// <param name="axisIndex">名称</param>
        /// <returns>轴映射号</returns>
        internal string FindNameByIndex(int axisIndex)
        {
            for (int i = 0; i < Project.L_axis.Count; i++)
            {
                if (Project.L_axis[i].actNo == axisIndex)
                    return Project.L_axis[i].axisName;
            }
            FuncLib.ShowMsg(string.Format("未查找到索引为 {0} 的轴，请检查", axisIndex), InfoType.Error);
            FuncLib.ShowMessageBox(string.Format("未查找到索引为 {0} 的轴，请检查", axisIndex), InfoType.Error);
            return string.Empty;
        }
        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="infoType"></param>
        internal void ShowMsg(string msg, InfoType infoType)
        {
            Frm_Card.Instance.tbx_log.SelectionStart = Frm_Card.Instance.tbx_log.Text.Length;
            Frm_Card.Instance.tbx_log.SelectionLength = 0;
            switch (infoType)
            {
                case InfoType.Tip:
                    Frm_Card.Instance.tbx_log.SelectionColor = Color.FromArgb(48, 48, 48);
                    Project.tipNum++;
                    break;
                case InfoType.Warn:
                    Frm_Card.Instance.tbx_log.SelectionColor = Color.Green;
                    Project.warnNum++;
                    break;
                case InfoType.Error:
                    Frm_Card.Instance.tbx_log.SelectionColor = Color.Red;
                    Project.errorNum++;
                    break;
            }

            if (Frm_Card.Instance.tbx_log.Text == string.Empty)
                Frm_Card.Instance.tbx_log.AppendText("  " + msg);
            else
                Frm_Card.Instance.tbx_log.AppendText(Environment.NewLine + "  " + msg);
            Frm_Card.Instance.tbx_log.ScrollToCaret();
            Application.DoEvents();
        }

    }
}
