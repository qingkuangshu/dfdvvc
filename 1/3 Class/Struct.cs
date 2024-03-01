using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Pro
{

    [Serializable]
    internal class ToolParBase { }
    [Serializable]
    /// <summary>
    /// 工具输入项
    /// </summary>
    internal struct InputItem
    {
        internal string InputName;
        internal DataType inputType;
        internal string sourceTask;
        internal string sourceTool;
        internal string sourceOutput;
    }
    /// <summary>
    /// 信息类型     提示 警告 错误
    /// </summary>
    internal enum InfoType
    {
        Tip,
        Warn,
        Error,
        Alarm,
    }
    /// <summary>
    /// 任务触发模式      调用触发:调用时触发      启动触发：点击了启动按钮就触发
    /// </summary>
    internal enum TaskTrigMode
    {
        BasedCall,
        BasedStart,
        BasedEthernet,
        BasedCameraHardTrigger,
    }
    /// <summary>
    /// 属性节点移动方向
    /// </summary>
    public enum MoveTreeView
    {
        /// <summary>
        /// 未移动
        /// </summary>
        NoMove = -1,
        /// <summary>
        /// 上传（客户端拖拽到服务端）
        /// </summary>
        ClientToServer = 0,
        /// <summary>
        /// 下载（服务端拖拽到客户端）
        /// </summary>
        ServerToClient = 1
    }
    /// <summary>
    /// 回零方式
    /// </summary>
    public enum HomeMode
    {
        FindOrigin,
        FindNLimit,
        FindPLimit,
    }
    /// <summary>
    /// 日志项
    /// </summary>
    internal struct MsgItem
    {
        internal string time;
        internal string msg;
        internal InfoType infoType;
    }
    [Serializable]
    public class Line
    {
        public Line()
        {
            _起点 = new XY();
            _终点 = new XY();
        }

        private XY _起点;

        public XY 起点
        {
            get { return _起点; }
            set { _起点 = value; }
        }
        private XY _终点;

        public XY 终点
        {
            get { return _终点; }
            set { _终点 = value; }
        }

        private HTuple _方向;
        public double 方向
        {
            get
            {
                HOperatorSet.AngleLx(起点.X, 起点.Y, 终点.X, 终点.Y, out _方向);
                return Math.Round(_方向.D, 3);
            }
        }

        public double GetAngle()
        {
            HTuple angle;
            HOperatorSet.AngleLx(起点.X, 起点.Y, 终点.X, 终点.Y, out angle);
            return angle;
        }
    }
    public class Circle
    {
        /// <summary>
        /// 圆心行坐标
        /// </summary>
        /// <value></value>
        public double X { get; set; }
        /// <summary>
        /// 圆心列坐标
        /// </summary>
        /// <value></value>
        public double Y { get; set; }
        /// <summary>
        /// 圆半径
        /// </summary>
        /// <value></value>
        public double R { get; set; }
    }
    /// <summary>
    /// 画布
    /// </summary>
    internal enum WindowLayout
    {
        OneWindow,
        TwoWindow,
        ForeWindow,
        SixWindow,
        EightWindow,
        NineWindow,
        TwelveWindow,
        SixteenWindow,
    }
    /// <summary>
    /// 窗口类型
    /// </summary>
    public enum FormType
    {
        UserForm,
        VisionForm,
        MotionForm,
        IOForm,
    }
    /// <summary>
    /// 服务页面的当前窗体类型
    /// </summary>
    public enum CurForm
    {
        None,               //无
        Camera,             //相机
        Calibrate,          //相机标定
        Scaner,             //扫码枪
        TCPSever,           //TCP/IP服务端
        TCPClient,          //TCP/IP客户端
        Light,              //光源控制器
        Serial,             //串口
        PLCComm,            //PLC通讯
        Card,               //板卡
        FTPDownload,        //FTP下载服务
    }
    /// <summary>
    /// 控制类型
    /// </summary>
    internal enum ControlType
    {
        StartStopPauseReset,
        StartStop,
        Empty,
    }
    /// <summary>
    /// 数据类型
    /// </summary>
    public enum DataType
    {
        Int,
        Double,
        String,
        XY,
        XYU,
        Line,
        Circle,
        Image,
        Region,
        ListXY,
        ListXYU,
        ListLine,
    }
    [Serializable]
    public class XY
    {
        internal XY() { }
        internal XY(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        private double _x;
        public double X
        {
            get
            {
                return Math.Round(_x, 3);
            }
            set { _x = value; }
        }

        private double _y;
        public double Y
        {
            get
            {
                return Math.Round(_y, 3);
            }
            set { _y = value; }
        }

        /// <summary>
        /// 重写 -
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        /// <returns></returns>
        public static XY operator -(XY p1, XY p2)
        {
            return new XY(p1.X - p2.X, p1.Y - p2.Y);
        }

        /// <summary>
        /// 重写 +
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        /// <returns></returns>
        public static XY operator +(XY p1, XY p2)
        {
            return new XY(p1.X + p2.X, p1.Y + p2.Y);
        }
    }
    /// <summary>
    /// XYU
    /// </summary>
    [Serializable]
    internal class XYU
    {
        public bool temp = false;
        internal XYU()
        {
            _xy = new XY();
            _xy.X = 0;
            _xy.Y = 0;
            _u = 0;
        }
        internal XYU(double x, double y, double u, bool tempp = false)
        {
            _xy = new XY();
            _xy.X = x;
            _xy.Y = y;
            _u = u;
            this.temp = tempp;
        }

        private XY _xy;
        public XY XY
        {
            get { return _xy; }
            set { _xy = value; }
        }

        private double _u;
        public double U
        {
            get
            {
                return Math.Round(_u, 6);
            }
            set { _u = value; }
        }

        /// <summary>
        /// 重写 -
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        /// <returns></returns>
        public static XYU operator -(XYU p1, XYU p2)
        {
            return new XYU(p1.XY.X - p2.XY.X, p1.XY.Y - p2.XY.Y, p1.U - p2.U);
        }

        /// <summary>
        /// 重写 +
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        /// <returns></returns>
        public static XYU operator +(XYU p1, XYU p2)
        {
            return new XYU(p1.XY.X + p2.XY.X, p1.XY.Y + p2.XY.Y, p1.U + p2.U);
        }
    }
    /// <summary>
    /// XYZU
    /// </summary>
    [Serializable]
    internal class XYZU
    {
        internal XYZU() { }
        internal XYZU(double x, double y, double z, double u)
        {
            _x = x;
            _y = y;
            _z = z;
            _u = u;
        }
        private int _index;
        public int index
        {
            get { return _index; }
            set { _index = value; }
        }

        private double _handType;
        public double HandType
        {
            get { return _handType; }
            set { _handType = value; }
        }

        private double _x;
        public double X
        {
            get
            {
                return Math.Round(_x, 3);
            }
            set { _x = value; }
        }

        private double _y;
        public double Y
        {
            get
            {
                return Math.Round(_y, 3);
            }
            set { _y = value; }
        }

        private double _z;
        public double Z
        {
            get
            {
                return Math.Round(_z, 3);
            }
            set { _z = value; }
        }

        private double _u;
        public double U
        {
            get
            {
                return Math.Round(_u, 3);
            }
            set { _u = value; }
        }
    }
    /// <summary>
    /// 区域类型
    /// </summary>
    internal enum RegionType
    {
        整幅图像,
        矩形,
        仿射矩形,
        圆,
        多点,
        椭圆,
        圆环,
        任意,
        输入区域,
    }

    /// <summary>
    ///  OCR字符识别时，字符背景类型枚举
    /// </summary>
    internal enum CharBackType
    {
        白底黑字,
        黑底白字,
    }

    /// <summary>
    /// 图像预处理枚举类型
    /// </summary>
    internal enum YuChuLiType
    { 
        均值滤波,
        中值滤波,
        高斯滤波,
        灰度膨胀,
        灰度腐蚀,
        锐化,
        对比度,
        亮度调节,
        灰度开运算,
        灰度闭运算,
        反色,
        二值化,
        均值二值化,
        彩色二值化,
        彩色转灰度图,
        Tif转灰度图,
        分辨率更改,
    }

    /// <summary>
    /// 相机IO触发类型
    /// </summary>
    internal enum CameraIoOutputType
    { 
        任务运行触发,
        任务成功触发,
        任务失败触发,
    }


    /// <summary>
    /// 通用输入
    /// </summary>
    [Serializable]
    internal struct S_Di
    {
        internal string cardName;
        internal int index;
        internal int actNo;
        internal Di diName;
        internal bool isVitual;
    }
    /// <summary>
    /// 通用输出
    /// </summary>
    [Serializable]
    internal struct S_Do
    {
        internal string cardName;
        internal int index;
        internal int actNo;
        internal Do doName;
        internal bool isVirtual;
    }
    /// <summary>
    /// 轴
    /// </summary>
    [Serializable]
    internal class S_Axis
    {
        internal int index;
        internal int actNo;
        internal string axisName;
        internal bool homeOK;
    }
    /// <summary>
    /// 气缸1
    /// </summary>
    [Serializable]
    internal struct CCylinder1
    {
        internal string cardNameActOutNo1;
        internal string cardNameActOutNo2;
        internal string cardNameActInNo1;
        internal string cardNameActInNo2;
        internal int actOutNo1;
        internal int actOutNo2;
        internal int actInNo1;
        internal int actInNo2;
        internal string name;
    }
    /// <summary>
    /// 气缸1
    /// </summary>
    [Serializable]
    internal struct CCylinder2
    {
        internal string cardNameOutNo1;
        internal string cardNameInNo1;
        internal string cardNameInNo2;
        internal int actOutNo1;
        internal int actInNo1;
        internal int actInNo2;
        internal string name;
    }
    /// <summary>
    /// 真空
    /// </summary>
    [Serializable]
    internal struct Vacuum
    {
        internal string cardNameIn;
        internal string cardNameOut;
        internal string cardNameBlow;
        internal int actOutNo;
        internal int actInNo;
        internal int actOutBlowNo;
        internal string name;
    }
    /// <summary>
    /// 信号开关状态
    /// </summary>
    internal enum OnOff
    {
        On,
        Off,
    }
    /// <summary>
    /// 轴方向
    /// </summary>
    public enum Dir
    {
        N_负方向,
        P_正方向,
    }
    /// <summary>
    /// 运动控制卡类型
    /// </summary>
    public enum CardType
    {
        雷赛_DMC1000B,
        雷赛_IOC0640,
        雷塞_DMC2210,
        雷塞_DMC2410,
        雷赛_DMC3400,
        固高_GTS,
        凌华_AMP204C,
        软赢_WMX,
        安川_MP3100,
        凌臣_M30,
    }
    /// <summary>
    /// 有效电平
    /// </summary>
    internal enum LogicLevel
    {
        高电平有效,
        低电平有效,
    }
    /// <summary>
    /// 设备运行状态
    /// </summary>
    internal enum MachineRunStatu
    {
        WaitReset,      //等待复位
        Stop,           //停止
        Pause,          //暂停
        Homing,         //正在复位
        WaitRun,        //复位完成，等待启动
        Running,        //运行中
        WaitMaterial,   //待料
        Alarm,          //报警中
        HeavyAlarm,     //严重报警，必须大复位
    }
    /// <summary>
    /// 统计数量
    /// </summary>
    [Serializable]
    internal struct Count
    {
        public Int64 OKNum;
        public Int64 NGNum;
        public Int64 TotalNum;
    }

}
