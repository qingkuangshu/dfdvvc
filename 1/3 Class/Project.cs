using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    [Serializable]
    /// <summary>
    /// 项目
    /// </summary>
    internal class Project
    {
        /// <summary>
        /// 服务端集合
        /// </summary>
        internal List<ServiceBase> L_Service = new List<ServiceBase>();
        /// <summary>
        /// 方案列表
        /// </summary>
        internal static List<Scheme> L_schemeList = new List<Scheme>();
        /// <summary>
        /// 方案名称集合
        /// </summary>
        internal List<string> L_schemeName = new List<string>();
        /// <summary>
        /// 系统参数
        /// </summary>
        internal Configuration configuration = new Configuration();
        /// <summary>
        /// 每日统计数量
        /// </summary>
        internal Dictionary<int, Count> L_count1 = new Dictionary<int, Count>();
        /// <summary>
        /// 每日统计数量
        /// </summary>
        internal List<Count> L_count = new List<Count>();
        /// <summary>
        /// 后台图像窗口
        /// </summary>
        internal static Dictionary<string, HTuple> D_backImageWindow = new Dictionary<string, HTuple>();
        /// <summary>
        /// 启动信号卡名绑定
        /// </summary>
        internal static string startSignalCardName = string.Empty;
        /// <summary>
        /// 停止信号卡名绑定
        /// </summary>
        internal static string stopSignalCardName = string.Empty;
        /// <summary>
        /// 复位信号卡名绑定
        /// </summary>
        internal static string resetSignalCardName = string.Empty;
        /// <summary>
        /// 急停信号卡名绑定
        /// </summary>
        internal static string emgSignalCardName = string.Empty;
        /// <summary>
        /// 三色灯红卡名
        /// </summary>
        internal static string lightRedCardName = string.Empty;
        /// <summary>
        /// 三色灯绿卡名
        /// </summary>
        internal static string lightGreenCardName = string.Empty;
        /// <summary>
        /// 三色灯黄卡名
        /// </summary>
        internal static string lightYellowCardName = string.Empty;
        /// <summary>
        /// 蜂鸣卡名
        /// </summary>
        internal static string buzzerCardName = string.Empty;
        /// <summary>
        /// 照明卡名
        /// </summary>
        internal static string lightCardName = string.Empty;
        /// <summary>
        /// 安全门卡名
        /// </summary>
        internal static string safeDoorCardName = string.Empty;
        /// <summary>
        /// 下机要板信号卡名
        /// </summary>
        internal static string nextAskMaterialCardName = string.Empty;
        /// <summary>
        /// 本机要板信号卡名
        /// </summary>
        internal static string askMaterialCardName = string.Empty;
        /// <summary>
        /// 启动信号点号绑定
        /// </summary>
        internal static int startSignalIdx = -1;
        /// <summary>
        /// 停止信号点号绑定
        /// </summary>
        internal static int stopSignalIdx = -1;
        /// <summary>
        /// 复位信号点号绑定
        /// </summary>
        internal static int resetSignalIdx = -1;
        /// <summary>
        /// 急停信号点号绑定
        /// </summary>
        internal static int emgSignalIdx = -1;
        /// <summary>
        /// 三色灯红点号
        /// </summary>
        internal static int lightRedIdx = -1;
        /// <summary>
        /// 三色灯绿点号
        /// </summary>
        internal static int lightGreenIdx = -1;
        /// <summary>
        /// 三色灯黄点号
        /// </summary>
        internal static int lightYellowIdx = -1;
        /// <summary>
        /// 下机要板信号点号
        /// </summary>
        internal static int nextAskMaterialIdx = -1;
        /// <summary>
        /// 本机要板信号点号
        /// </summary>
        internal static int askMaterialIdx = -1;
        /// <summary>
        /// 蜂鸣点号
        /// </summary>
        internal static int buzzerIdx = -1;
        /// <summary>
        /// 照明点号
        /// </summary>
        internal static int lightIdx = -1;
        /// <summary>
        /// 安全门点号
        /// </summary>
        internal static int safeDoorIdx = -1;
        /// <summary>
        /// 输入点集合
        /// </summary>
        internal static List<S_Di> L_di = new List<S_Di>();
        /// <summary>
        /// 输入点板卡名称
        /// </summary>
        internal static Dictionary<Di, string> D_diCardName = new Dictionary<Di, string>();
        /// <summary>
        /// 输入点集合
        /// </summary>
        internal static Dictionary<Di, int> D_diVitual = new Dictionary<Di, int>();
        /// <summary>
        /// 输出点集合
        /// </summary>
        internal static List<S_Do> L_do = new List<S_Do>();
        /// <summary>
        /// 输出点板卡名称
        /// </summary>
        internal static Dictionary<Do, string> D_doCardName = new Dictionary<Do, string>();
        /// <summary>
        /// 轴集合
        /// </summary>
        internal static List<S_Axis> L_axis = new List<S_Axis>();
        /// <summary>
        /// 轴板卡名称
        /// </summary>
        internal static Dictionary<Axis, string> D_AxisCardName = new Dictionary<Axis, string>();
        /// <summary>
        /// 气缸1集合
        /// </summary>
        internal static List<CCylinder1> L_cylinder1 = new List<CCylinder1>();
        /// <summary>
        /// 气缸2集合
        /// </summary>
        internal static List<CCylinder2> L_cylinder2 = new List<CCylinder2>();
        /// <summary>
        /// 真空集合
        /// </summary>
        internal static List<Vacuum> L_vacuum = new List<Vacuum>();
        /// <summary>
        /// 气缸1集合
        /// </summary>
        internal static Dictionary<string, Cylinder1> L_cCylinder1 = new Dictionary<string, Cylinder1>();
        /// <summary>
        /// 真空集合
        /// </summary>
        internal static Dictionary<string, CVacuum> L_cVacuum = new Dictionary<string, CVacuum>();
        /// <summary>
        /// 设备报警历史
        /// </summary>
        internal Dictionary<DateTime, string> D_historyAlarm = new Dictionary<DateTime, string>();
        /// <summary>
        /// 输出日志集合
        /// </summary>
        internal static List<MsgItem> L_msgItem = new List<MsgItem>();
        /// <summary>
        /// 输出日志中的提示项数量
        /// </summary>
        internal static int tipNum = 0;
        /// <summary>
        /// 输出日志中的警告项数量
        /// </summary>
        internal static int warnNum = 0;
        /// <summary>
        /// 输出日志中的错误项数量
        /// </summary>
        internal static int errorNum = 0;
        /// <summary>
        /// MES是否登录成功
        /// </summary>
        internal static bool mesLoginOK = false;
        /// <summary>
        /// MES登录失败的返回值
        /// </summary>
        internal static string mesLoginErrr = string.Empty;

        /// <summary>
        /// 显示缺陷细节模板图片
        /// </summary>
        internal string HuangJiaoPath = "";
        internal string HeiDianPath = "";
        internal string PoDongPath = "";
        internal string LouTongPath = "";
        internal string ZhiBianPath = "";
        internal string HuaHenPath = "";
        internal string ZheZhouPath = "";



        /// <summary>
        /// 项目实例
        /// </summary>
        private static Project _instance;
        internal static Project Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Project();
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }


        /// <summary>
        /// 保存项目
        /// </summary>
        internal static void SaveSysPar()
        {
            //当项目比较大的时候保存耗时较长，这个时候如果异常断电，那么序列化不成功，再次开启程序时所有项目文件会全部丢失，为解决此问题：先序列化一个临时项目文件，序列化成功后再移动替换原文件
            //首先删除原项目
            string[] files = Directory.GetFiles(Application.StartupPath);
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].EndsWith(".sys"))
                    File.Delete(files[i]);
            }
            //序列化项目
            using (Stream stream = new FileStream(string.Format(Application.StartupPath + "\\{0}.sys", Project.Instance.configuration.projectName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.Delete))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Project.Instance);
                stream.Close();
            }
            try
            {


                //删除实际的项目配置文件
                string[] files1 = Directory.GetFiles(Application.StartupPath + "\\Config\\Project");
                for (int i = 0; i < files1.Length; i++)
                {
                    if (files1[i].EndsWith(".sys"))
                    {
                        File.SetAttributes(files1[i], FileAttributes.Normal);
                        new FileInfo(files1[i]).Attributes = FileAttributes.Normal;
                        File.Delete(files1[i]);
                    }
                }

                //移动项目
                File.Copy(string.Format(Application.StartupPath + "\\{0}.sys", Project.Instance.configuration.projectName), string.Format(Application.StartupPath + "\\Config\\Project\\{0}.sys", Project.Instance.configuration.projectName));
            }
            catch (Exception ex)
            {

            }
        }

        private static object lockobj = new object();

        /// <summary>
        /// 保存项目
        /// </summary>
        internal static void SaveAlarmHistory()
        {
            lock (lockobj)
            {

                //当项目比较大的时候保存耗时较长，这个时候如果异常断电，那么序列化不成功，再次开启程序时所有项目文件会全部丢失，为解决此问题：先序列化一个临时项目文件，序列化成功后再移动替换原文件
                //序列化项目
                using (FileStream stream = new FileStream(string.Format(Application.StartupPath + "\\{0}.alm", Project.Instance.configuration.projectName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.Delete))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, Project.Instance.D_historyAlarm);
                    stream.Close();
                }
                try
                {
                    //删除项目
                    string[] files = Directory.GetFiles(Application.StartupPath + "\\Config\\Project");
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].EndsWith(".alm"))
                        {
                            File.SetAttributes(files[i], FileAttributes.Normal);
                            new FileInfo(files[i]).Attributes = FileAttributes.Normal;
                            File.Delete(files[i]);
                        }
                    }

                    //移动项目
                    File.Copy(string.Format(Application.StartupPath + "\\{0}.alm", Project.Instance.configuration.projectName), string.Format(Application.StartupPath + "\\Config\\Project\\{0}.alm", Project.Instance.configuration.projectName));

                }
                catch (Exception ex)
                {

                }
            }
        }
        /// <summary>
        /// 根据服务端名称查找服务端
        /// </summary>
        /// <param name="severName">服务端名称</param>
        /// <returns></returns>
        internal static ServiceBase FindServiceByName(string severName)
        {
            for (int i = 0; i < Instance.L_Service.Count; i++)
            {
                if (Instance.L_Service[i].name == severName)
                    return Instance.L_Service[i];
            }
            return null;
        }
        /// <summary>
        /// 加载项目【1.配置文件，报警记录，以及解决方案】
        /// </summary>
        internal static void Load()
        {
            //如果本地有项目文件就反序列化，如果没有没有文件那就直接new一个
            string[] files = Directory.GetFiles(Application.StartupPath + "\\Config\\Project");
            string sysFileName = string.Empty;
            string almFileName = string.Empty;

            if (files.Length > 0)
            {
                if (files[0].EndsWith(".sys"))
                    sysFileName = files[0];
                if (files[0].EndsWith(".alm"))
                    almFileName = files[0];

                if (files.Length > 1 && files[1].EndsWith(".sys"))
                    sysFileName = files[1];
                if (files.Length > 1 && files[1].EndsWith(".alm"))
                    almFileName = files[1];

                //序列化项目
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(sysFileName, FileMode.Open, FileAccess.Read, FileShare.None);
                try
                {
                    Project.Instance = (Project)formatter.Deserialize(stream);
                    stream.Close();
                }
                catch (Exception)     //如果反序列化失败，要释放流，否则文件会被占用
                {
                    stream.Close();

                    //删除项目
                    string[] files1 = Directory.GetFiles(Application.StartupPath + "\\Config\\Project");
                    for (int i = 0; i < files1.Length; i++)
                    {
                        File.SetAttributes(files1[i], FileAttributes.Normal);
                        new FileInfo(files1[i]).Attributes = FileAttributes.Normal;
                        File.Delete(files1[i]);
                    }

                    //自动恢复
                    string ss = string.Format(Application.StartupPath + "\\{0}.sys", Path.GetFileNameWithoutExtension(files[0]));
                    File.Copy(ss, files[0]);

                    string ss1 = string.Format(Application.StartupPath + "\\{0}.sys", Path.GetFileNameWithoutExtension(sysFileName));
                    File.Copy(ss1, sysFileName);


                    //反序列化项目
                    formatter = new BinaryFormatter();
                    stream = new FileStream(sysFileName, FileMode.Open, FileAccess.Read, FileShare.None);
                    try
                    {
                        Project.Instance = (Project)formatter.Deserialize(stream);
                        stream.Close();
                        FuncLib.ShowMsg("加载项目失败！文件损坏，已自动从备份文件正常恢复", InfoType.Warn);
                    }
                    catch      //如果反序列化失败，要释放流，否则文件会被占用
                    {
                        stream.Close();
                        FuncLib.ShowMessageBox("加载项目失败！系统参数已损坏且无法恢复", InfoType.Error);
                        return;
                    }
                }

                //加载历史报警记录
                if (almFileName != string.Empty)
                {
                    IFormatter formatter1 = new BinaryFormatter();
                    Stream stream1 = new FileStream(almFileName, FileMode.Open, FileAccess.Read, FileShare.None);
                    try
                    {
                        Project.Instance.D_historyAlarm = (Dictionary<DateTime, string>)formatter1.Deserialize(stream1);
                        stream1.Close();
                    }
                    catch      //如果反序列化失败，要释放流，否则文件会被占用
                    {
                        stream1.Close();
                    }
                }
            }
            else
            {
                Project.Instance = new Project();

                Scheme scheme = new Scheme("示例方案");
                Scheme.curScheme = scheme;
                Project.Instance.L_schemeName.Add("示例方案");
                Scheme.SaveCur();
                SaveSysPar();
                Thread.Sleep(20);
            }

            //加载当前方案
            Scheme.Load(string.Format(Application.StartupPath + "\\Config\\Project\\Scheme\\{0}.shm", Instance.configuration.curSchemeName));

            //加载原有方案
            Thread th = new Thread(() =>
            {
                #region 1.加载Scheme文件夹下的文件，并根据每个文件的创建时间，做相应的排序【此步只是做文件名称排序而已】

                string[] strs = Directory.GetFiles(Application.StartupPath + "\\Config\\Project\\Scheme");
                //根据时间先后排一下顺序
                string tempStr = string.Empty;
                for (int i = 0; i < strs.Length; i++)
                {
                    for (int j = i + 1; j < strs.Length; j++)
                    {
                        DateTime time1 = File.GetCreationTime(strs[i]);
                        DateTime time2 = File.GetCreationTime(strs[j]);
                        if (time1 > time2)
                        {
                            tempStr = strs[i];
                            strs[i] = strs[j];
                            strs[j] = tempStr;
                        }
                    }
                }

                Project.Instance.L_schemeName.Clear();
                for (int i = 0; i < strs.Length; i++)
                {
                    Project.Instance.L_schemeName.Add(Path.GetFileNameWithoutExtension(strs[i]));
                }

                #endregion

                #region 1.根据相应的方案名字，加载为方案文件，并将其实质的对象加入到方案列表当中

                for (int i = 0; i < Project.Instance.L_schemeName.Count; i++)
                {
                    bool exist = false;
                    for (int j = 0; j < strs.Length; j++)
                    {
                        string schemeName = Path.GetFileNameWithoutExtension(strs[j]);
                        if (schemeName == Project.Instance.L_schemeName[i])
                        {
                            IFormatter formatter = new BinaryFormatter();
                            Stream stream = new FileStream(strs[i], FileMode.Open, FileAccess.Read, FileShare.None);
                            Scheme scheme = (Scheme)formatter.Deserialize(stream);
                            stream.Close();

                            Project.L_schemeList.Add(scheme);
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                        Project.Instance.L_schemeName.RemoveAt(i);
                }

                //识别手动放进去的方案
                for (int i = 0; i < strs.Length; i++)
                {
                    string schemeName = Path.GetFileNameWithoutExtension(strs[i]);
                    if (!Project.Instance.L_schemeName.Contains(schemeName))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        Stream stream = new FileStream(strs[i], FileMode.Open, FileAccess.Read, FileShare.None);
                        Scheme scheme = (Scheme)formatter.Deserialize(stream);
                        stream.Close();

                        Project.L_schemeList.Add(scheme);
                        Project.Instance.L_schemeName.Add(scheme.name);
                        FuncLib.ShowMsg(string.Format("发现新方案 [ {0} ] 并已成功导入到当前项目", scheme.name));
                    }
                }


                #endregion


                //用当前方案覆盖集合中的对应方案，这样做了变化都会同步进去【1.用了引用类型的特性】
                for (int i = 0; i < Project.L_schemeList.Count; i++)
                {
                    if (Project.L_schemeList[i].name == Scheme.curScheme.name)
                        Project.L_schemeList[i] = Scheme.curScheme;
                }
            });
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 导入项目
        /// </summary>
        internal static void Inport()
        {
            System.Windows.Forms.OpenFileDialog dig_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            dig_openFileDialog.Title = "请指定系统参数";
            dig_openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            dig_openFileDialog.Filter = "系统参数(*.sys)|*.sys";
            if (dig_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(dig_openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                Project.Instance = (Project)formatter.Deserialize(stream);
                stream.Close();

                //更新当前方案
                Scheme.curScheme = null;
                //如果新的项目中也有同名方案，那就赋值为当前方案
                for (int i = 0; i < Project.L_schemeList.Count; i++)
                {
                    if (Project.L_schemeList[i].name == Project.Instance.configuration.curSchemeName)
                    {
                        Scheme.curScheme = Project.L_schemeList[i];
                        break;
                    }
                }
                //如果新的项目中没有同名方案，那就将第一个方案赋值为当前方案
                if (Scheme.curScheme == null)
                    Scheme.curScheme = Project.L_schemeList[0];

                //加载所有方案
                Frm_Main.Instance.cbx_schemeList.Items.Clear();
                for (int i = 0; i < Project.L_schemeList.Count; i++)
                {
                    Frm_Main.Instance.cbx_schemeList.Items.Add(Project.L_schemeList[i].name);
                }

                //加载当前方案
                Scheme.LoadCur();

                //清除工具状态显示
                for (int i = 0; i < Frm_Task.Instance.C_toolList.Nodes.Count; i++)
                {
                    Frm_Task.Instance.C_toolList.SetNodeTipsText(Frm_Task.Instance.C_toolList.Nodes[i], "", Color.Green, Color.Green);
                }

                FuncLib.ShowMsg("项目导入成功", InfoType.Tip);
            }
        }
        /// <summary>
        /// 导出项目
        /// </summary>
        internal static void Export()
        {
            System.Windows.Forms.SaveFileDialog dig_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            dig_saveFileDialog.FileName = Project.Instance.configuration.projectName;
            dig_saveFileDialog.Title = "请指定系统参数导出路径";
            dig_saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            dig_saveFileDialog.Filter = "系统参数|*.sys";
            if (dig_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(dig_saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, Project.Instance);
                stream.Close();

                FuncLib.ShowMsg("系统参数导出成功", InfoType.Tip);
            }
        }

    }
}
