using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChoiceTech.Halcon.Control;
using System.Drawing;

namespace VM_Pro
{
    [Serializable]
    internal class Configuration
    {


        //项目自定义
        /// <summary>
        /// 安全高度
        /// </summary>
        internal double filmsafetyHeight = 0;
        internal double carrySafetyHeight = 0;


        /// <summary>
        /// 当班产能
        /// </summary>
        internal Int64 curTotalNum = 0;
        /// <summary>
        /// 当班OK数量
        /// </summary>
        internal Int64 curOKNum = 0;
        /// <summary>
        /// 当班NG数量
        /// </summary>
        internal Int64 curNGNum = 0;
        /// <summary>
        /// 生产总数
        /// </summary>
        internal Int64 totalNum = 0;
        /// <summary>
        /// 生产OK数量
        /// </summary>
        internal Int64 OKNum = 0;
        /// <summary>
        /// 生产NG数量
        /// </summary>
        internal Int64 NGNum = 0;

        /// <summary>
        /// 任务运行失败时停止循环
        /// </summary>
        internal bool failStop = true;
        /// <summary>
        /// 文件夹内图像循环完毕停止
        /// </summary>
        internal bool endStop = true;
        /// <summary>
        /// 任务运行间隔时间
        /// </summary>
        internal int taskRunSpan = 200;
        /// <summary>
        /// 任务运行失败时停止循环
        /// </summary>
        internal bool taskFailStop = true;
        /// <summary>
        /// 是否启用联机信号
        /// </summary>
        internal bool onLine = true;
        /// <summary>
        /// 显示所有IO信号（这里的所有和非所有的区别在于包括或不包括气缸和真空的输入信号）
        /// </summary>
        internal bool showAllSignal = true;
        /// <summary>
        /// 基于SDK采集接口或基于Halcon采集接口
        /// </summary>
        internal bool basedSDKInterface = true;
        /// <summary>
        /// 开机程序自启动
        /// </summary>
        internal bool autoRunAfterStartup = true;
        /// <summary>
        /// 启动后程序自动开始
        /// </summary>
        internal bool autoStartAfterRun = false;
        /// <summary>
        /// 启动后主窗体最大化
        /// </summary>
        internal bool autoMax = false;
        /// <summary>
        /// 不允许改变窗体大小
        /// </summary>
        internal bool disenableResizeForm = true;
        /// <summary>
        /// 启用权限管控
        /// </summary>
        internal bool enablePermission = false;
        /// <summary>
        /// 是否启用首页界面
        /// </summary>
        internal bool enableUserForm = false;
        /// <summary>
        /// 是否启用视觉页面
        /// </summary>
        internal bool enableVisionForm = true;
        /// <summary>
        /// 是否启用运控页面
        /// </summary>
        internal bool enableMotionForm = true;
        /// <summary>
        /// 是否启用IO监控页面
        /// </summary>
        internal bool enableIOForm = true;
        /// <summary>
        /// 默认页面
        /// </summary>
        internal FormType defaultFormType = FormType.VisionForm;
        /// <summary>
        /// 数据存储时间
        /// </summary>
        internal int dataSaveTime = 7;
        /// <summary>
        /// 数据存储时间  True:天  False:时
        /// </summary>
        internal bool dateSaveTimeBasedDay = true;
        /// <summary>
        /// 数据存储路径
        /// </summary>
        internal string dataPath = "D:\\Sun\\Log";
        /// <summary>
        /// 公司名称
        /// </summary>
        internal string companyName = "致一";
        /// <summary>
        /// 项目名称
        /// </summary>
        internal string projectName = "未命名";
        /// <summary>
        /// 当前方案名称
        /// </summary>
        internal string curSchemeName = "示例方案";
        /// <summary>
        /// 管理员密码
        /// </summary>
        internal string adminPassword = "21232f297a57a5a743894a0e4a801fc3";        //默认密码为admin
        /// <summary>
        /// 开发者密码
        /// </summary>
        internal string developerPassword = "95fc6be00264a94959afb8d8ec6704fc";        //密码默认为likang
        /// <summary>
        /// 图像窗口名称
        /// </summary>
        internal string[] windowName = new string[] { "图像1", "图像2", "图像3", "图像4", "图像5", "图像6", "图像7", "图像8", "图像9", "图像10", "图像11", "图像12", "图像13", "图像14", "图像15", "图像16" };
        /// <summary>
        /// 任务列表页面是否隐藏
        /// </summary>
        internal bool taskListVisible = true;
        /// <summary>
        /// 工具箱显示状态         0：嵌入   1：悬浮    2：隐藏
        /// </summary>
        internal int toolBoxStatu = 0;
        /// <summary>
        /// 主题颜色
        /// </summary>
        internal Color themeColor = Color.Green;
        /// <summary>
        /// 生产页面选中
        /// </summary>
        internal bool productCheck = false;
        /// <summary>
        /// 任务页面选中
        /// </summary>
        internal bool taskCheck = true;
        /// <summary>
        /// 统计页面选中
        /// </summary>
        internal bool infomationCheck = false;
        /// <summary>
        /// 任务页面启用
        /// </summary>
        internal bool taskFormEnable = true;
        /// <summary>
        /// 生产页面启用
        /// </summary>
        internal bool produceFormEnable = false;
        /// <summary>
        /// 统计页面启用
        /// </summary>
        internal bool infomationFormEnable = false;
        /// <summary>
        /// 当前程序是否开启加速模式
        /// </summary>
        internal bool IsJiSuMoShi = false;

        /// <summary>
        /// 控制类型
        /// </summary>
        internal ControlType controlType = ControlType.Empty;
        /// <summary>
        /// 主窗体长
        /// </summary>
        internal int mainFormHeight = 720;
        /// <summary>
        /// 主窗体宽
        /// </summary>
        internal int mainFormWidth = 1087;
        /// <summary>
        /// 启用海康威视SDK
        /// </summary>
        internal bool enableHikvisionSdk = false;
        /// <summary>
        /// 启用大恒SDK
        /// </summary>
        internal bool enableDaHengSdk = false;
        /// <summary>
        /// 启用AVT SDK
        /// </summary>
        internal bool enableAVTSdk = false;
        /// <summary>
        /// 启用Halcon SDK
        /// </summary>
        internal bool enableHalconSdk = true;
        /// <summary>
        /// 启用联机信号
        /// </summary>
        internal bool enableLianJi = false;
        /// <summary>
        /// 启用蜂鸣器
        /// </summary>
        internal bool BuzzerEnable = false;
        /// <summary>
        /// 启用安全门
        /// </summary>
        internal bool SafeDoorEnable = false;

        /// <summary>
        /// 是否启用MES
        /// </summary>
        internal bool MESEnable = false;
        /// <summary>
        /// 服务器地址
        /// </summary>
        internal string MESServiceAddress = string.Empty;
        /// <summary>
        /// MES登录用户名
        /// </summary>
        internal string MESUserName = string.Empty;
        /// <summary>
        /// MES登录密码
        /// </summary>
        internal string MESPassword = string.Empty;

        /// <summary>
        /// 用于存放当前所有缺陷的表格信息
        /// </summary>
        internal List<LeiBieModel> lstLeiBie = new List<LeiBieModel>();

        /// <summary>
        /// 当前项目的特殊配置字段
        /// </summary>
        internal VmainCfg projectCfg = new VmainCfg();

        
    }
}
