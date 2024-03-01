using ChoiceTech.Halcon.Control;
using HalconDotNet;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewWindow.Model;

namespace VM_Pro
{
    [Serializable]
    /// <summary>
    /// 保存图像
    /// </summary>
    internal class SaveImageTool : ToolBase
    {
        internal SaveImageTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;
            L_OutItemType = new List<DataType> { DataType.Image, DataType.String };

            //自动连接输入
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.采集图像)
                {
                    InputItem inputItem = new InputItem();
                    inputItem.InputName = "图像";
                    inputItem.inputType = DataType.Image;
                    inputItem.sourceTask = taskName;
                    inputItem.sourceTool = Task.curTask.L_toolList[i].toolName;
                    inputItem.sourceOutput = "图像";

                    L_inputItem.Add(inputItem);
                    break;
                }
            }
        }

        /// <summary>
        /// 锁
        /// </summary>
        private object obj = new object();
        /// <summary>
        /// 保存图片
        /// </summary>
        private static bool save = false;
        /// <summary>
        /// 磁盘是否已满
        /// </summary>
        private static bool isFull = false;
        /// <summary>
        /// 格式
        /// </summary>
        internal string format = "jpg";
        /// <summary>
        /// 流程运行成功图像路径
        /// </summary>
        internal string okImagePath = string.Empty;
        /// <summary>
        /// 流程运行失败图像路径
        /// </summary>
        internal string ngImagePath = string.Empty;
        /// <summary>
        /// 图像名自动追加时间
        /// </summary>
        internal bool appendTime = true;
        /// <summary>
        /// 保存图片线程
        /// </summary>
        internal static Thread th_saveImage = null;
        /// <summary>
        /// 图像来源
        /// </summary>
        internal SaveImageSource saveImageSource = SaveImageSource.InputImage;
        /// <summary>
        /// 图像数据是否按天存储
        /// </summary>
        internal bool Is_SaveTypeDay = true;
        /// <summary>
        /// 图像队列,支持多线程
        /// </summary>
        private static ConcurrentQueue<SImage> queue = new ConcurrentQueue<SImage>();
        /// <summary>
        /// 是否显示来源图像的文件名名称
        /// </summary>
        internal bool isShowMasterMapName = false;

        /// <summary>
        /// 是否根据原图名称进行保存
        /// </summary>
        internal bool isSaveMasterMapName = false;

        /// <summary>
        /// 复位工具
        /// </summary>
        internal override void ResetTool()
        {
            format = "jpg";
            saveImageSource = SaveImageSource.InputImage;
            appendTime = true;

            Frm_SaveImageTool.Instance.rdo_fromInputImage.Checked = true;
            Frm_SaveImageTool.Instance.cbx_format.Text = format;
            Frm_SaveImageTool.Instance.ckb_appendTime.Checked = appendTime;
        }
        /// <summary>
        /// 清除过期图片
        /// </summary>
        private void ClearOldImage()
        {
            DateTime now = DateTime.Now;
            string path = string.Format("{0}\\{1}\\{2}\\{3}\\Image",
                    Project.Instance.configuration.dataPath, now.ToString("yyyy"), now.ToString("MMMM"), now.ToString("yyyy_MM_dd"));
            if (!Directory.Exists(path))
            {
                return; //若当前路径不存在的话，则不需要进行任何操作
            }

            string[] fileList = Directory.GetDirectories(path);
            for (int i = 0; i < fileList.Length; i++)
            {
                DirectoryInfo dir = new System.IO.DirectoryInfo(fileList[i]);
                DateTime dt = dir.CreationTime;
                if (Project.Instance.configuration.dateSaveTimeBasedDay)
                {
                    int tep = (now - dt).Days;
                    if ((now - dt).Days > Project.Instance.configuration.dataSaveTime)
                    {
                        try
                        {
                            Directory.Delete(fileList[i], true);
                        }
                        catch { }
                    }
                }
                else
                {
                    int tep = (now - dt).Hours;
                    if ((now - dt).Hours > Project.Instance.configuration.dataSaveTime)
                    {
                        try
                        {
                            Directory.Delete(fileList[i], true);
                        }
                        catch { }
                    }
                }
            }
        }
        [NonSerialized]
        internal static object obj_SaveImg = new object();

        /// <summary>
        /// 保存图片
        /// </summary>
        private void SaveNewImage()
        {
            while (save)
            {
                lock (obj_SaveImg)
                {

                    if (queue.TryDequeue(out SImage image))
                    {
                        try
                        {
                            if (image.image != null && image.image.IsInitialized())
                            {
                                HOperatorSet.WriteImage(image.image, image.format, 0, image.path);
                            }
                        }
                        catch (Exception ex)
                        {
                            //isFull = true;
                            //FuncLib.ShowMessageBox(string.Format("\r\n工具 [ {0} . {1} ] 保存图像失败！可能原因：\r\n①电脑磁盘存储空间已满，请尝试清理电脑磁盘空间，然后重启程序", taskName, toolName), InfoType.Error);
                            //break;
                            FuncLib.ShowMsg("图片存储失败：" + ex.Message, InfoType.Error);
                            //queue.Clear();
                            break;
                        }
                        Thread.Sleep(10);

                    }

                    else
                    {
                        save = false;
                        break;
                    }
                }

            }
        }
        /// <summary>
        /// 运行工具    
        /// </summary>
        /// <param name="initRun">初始化运行</param>
        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
        {
            try
            {
                lock (obj)
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

                    //检验输入图像是否指定
                    if (saveImageSource == SaveImageSource.InputImage && ((ToolPar)参数).输入.图像 == null)
                    {
                        toolRunStatu = "未指定输入图像";
                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }
                    string _currentImgName = "";

                    //紧耦合操作，看实际的勾选情况
                    if (isShowMasterMapName || isSaveMasterMapName)
                    {
                        try
                        {
                            if (((ImageTool)Task.FindTaskByName(taskName).FindToolByName("采集图像")).imageSource == ImageSource.FromFile)
                            {
                                _currentImgName = ((ImageTool)Task.FindTaskByName(taskName).FindToolByName("采集图像")).imagePath;
                                _currentImgName = Regex.Match(_currentImgName, @".+\\(.+)").Groups[1].Value;
                            }
                            else if (((ImageTool)Task.FindTaskByName(taskName).FindToolByName("采集图像")).imageSource == ImageSource.FromDirectory)
                            {
                                _currentImgName = ((ImageTool)Task.FindTaskByName(taskName).FindToolByName("采集图像")).currentImageName;
                            }
                            else
                            {
                                //走到此处说明是勾选了，但图像是通过相机采集的
                            }

                            if (_currentImgName.Contains("."))
                            {
                                _currentImgName = _currentImgName.Substring(0, _currentImgName.LastIndexOf('.'));
                            }
                        }
                        catch (Exception)
                        {
                            _currentImgName = "异常：未识别到图像名称";
                        }

                        if (isShowMasterMapName)
                        {
                            GetImageWindow().DispText(_currentImgName.ToUpper().Replace("-NG", "").Replace("-OK", ""), "yellow", "top", "left", 20);
                        }
                    }


                    DateTime curTime = DateTime.Now;
                    //if (isSaveMasterMapName)
                    //{
                    //    okImagePath = string.Format("{0}\\{1}\\Image\\{2}\\{3}\\OK\\{4}\\", Project.Instance.configuration.dataPath, curTime.ToString("yyyy_MM_dd"), taskName, toolName, _currentImgName.Split('-')[0]);
                    //    ngImagePath = string.Format("{0}\\{1}\\Image\\{2}\\{3}\\NG\\{4}\\", Project.Instance.configuration.dataPath, curTime.ToString("yyyy_MM_dd"), taskName, toolName, _currentImgName.Split('-')[0]);
                    //}
                    //else
                    //{
                    if (Is_SaveTypeDay)
                    {
                        okImagePath = string.Format("{0}\\{1}\\{2}\\{3}\\Image\\{4}\\{5}\\OK\\",
                        Project.Instance.configuration.dataPath, curTime.ToString("yyyy"), curTime.ToString("MMMM"), curTime.ToString("yyyy_MM_dd"), taskName, toolName);
                        ngImagePath = string.Format("{0}\\{1}\\{2}\\{3}\\Image\\{4}\\{5}\\NG\\",
                            Project.Instance.configuration.dataPath, curTime.ToString("yyyy"), curTime.ToString("MMMM"), curTime.ToString("yyyy_MM_dd"), taskName, toolName);
                    }
                    else
                    {
                        okImagePath = string.Format("{0}\\{1}\\{2}\\{3}\\{4}\\Image\\{5}\\{6}\\OK\\",
                        Project.Instance.configuration.dataPath, curTime.ToString("yyyy"), curTime.ToString("MMMM"), curTime.ToString("yyyy_MM_dd"), curTime.ToString("HH"), taskName, toolName);
                        ngImagePath = string.Format("{0}\\{1}\\{2}\\{3}\\{4}\\Image\\{5}\\{6}\\NG\\",
                            Project.Instance.configuration.dataPath, curTime.ToString("yyyy"), curTime.ToString("MMMM"), curTime.ToString("yyyy_MM_dd"), curTime.ToString("HH"), taskName, toolName);
                    }
                    //}

                    
                    string fileName = string.Empty;
                    if (appendTime)
                        fileName = string.Format("{0}{1}.{2}", ((ToolPar)参数).输入.文本 == string.Empty ? string.Empty : ((ToolPar)参数).输入.文本 + "-  ", DateTime.Now.ToString("HH时mm分ss秒ff毫秒"), format);
                    else
                        fileName = string.Format("{0}.{1}", ((ToolPar)参数).输入.文本 == string.Empty ? string.Empty : ((ToolPar)参数).输入.文本, format);


                    #region CT项目特有，让识别图像与原图存储的路径跟导入的文件夹路径相同

                    if (isSaveMasterMapName)
                    {
                        okImagePath = ngImagePath = ((ImageTool)Task.FindTaskByName(taskName).FindToolByName("采集图像")).imageDirectoryPath + "-IME\\";
                        if (isSaveMasterMapName)
                        {
                            if (Task.FindTaskByName(taskName).taskRunStatu == TaskRunStatu.Succeed)
                            {
                                fileName = _currentImgName + "—OK";
                            }
                            else
                            {
                                fileName = _currentImgName + "—NG";
                            }
                        }
                        else
                        {
                            fileName = ((ImageTool)Task.FindTaskByName(taskName).FindToolByName("采集图像")).currentImageName;
                        }
                    }

                    #endregion


                    if (!Directory.Exists(okImagePath))
                        Directory.CreateDirectory(okImagePath);

                    if (!Directory.Exists(ngImagePath))
                        Directory.CreateDirectory(ngImagePath);


                    string imagePath = string.Empty;
                    if (Task.FindTaskByName(taskName).taskRunStatu == TaskRunStatu.Succeed)
                        imagePath = okImagePath + fileName;
                    else
                        imagePath = ngImagePath + fileName;
                    SImage sImage = null;
                    if (saveImageSource == SaveImageSource.InputImage) //原图像保存
                    {
                        //此处使用队列来存储凸显，因为直接存储图像的话，连续存储两张图像之间必须间隔1秒以上，否则部分图像就没有被正常存储，只能出此下册
                        sImage = new SImage(((ToolPar)参数).输入.图像, format, imagePath);
                    }
                    else //处理图像保存
                    {
                        #region 1.修改保存窗体图片时，窗体图片变得很小的原因

                        HOperatorSet.DumpWindowImage(out HObject image, GetImageWindow().HWindowHalconID);
                        //1.此处保存的图像分辨率会根据当前窗体大小的来，但我们是想根据原图像分辨率来的，那么需做以下操作
                        HOperatorSet.GetImageSize(((ToolPar)参数).输入.图像, out HTuple width, out HTuple height);
                        HOperatorSet.ZoomImageSize(image, out HObject imageZOOM, width, height, "constant");
                        //删除注意
                        //HOperatorSet.ZoomImageSize(image, out HObject imageZOOM, 1400, 1300, "constant");

                        #endregion

                        sImage = new SImage(imageZOOM, format, imagePath);
                    }


                    queue.Enqueue(sImage);
                    save = true;
                    if (!isFull)        //磁盘有空间的前提下保存图片
                    {
                        if (th_saveImage == null || !th_saveImage.IsAlive)
                        {
                            th_saveImage = new Thread(SaveNewImage);
                            th_saveImage.IsBackground = true;
                            th_saveImage.Start();
                        }
                    }


                    //清除过期图片
                    Thread th = new Thread(ClearOldImage);
                    th.IsBackground = true;
                    th.Start();

                    sw.Stop();
                    toolRunStatu = "运行成功";
                Exit:
                    if (Frm_SaveImageTool.hasShown && Frm_SaveImageTool.taskName == taskName && Frm_SaveImageTool.toolName == toolName)
                    {
                        long time = sw.ElapsedMilliseconds;
                        Frm_SaveImageTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());
                        if (toolRunStatu == "运行成功")
                        {
                            Frm_SaveImageTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                            Frm_SaveImageTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
                        }
                        else
                        {
                            Frm_SaveImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                            Frm_SaveImageTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FuncLib.ShowMsg("存储图像工具异常：" + ex.Message);
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
        public class P输入
        {
            private HObject _图像;
            public HObject 图像
            {
                get { return _图像; }
                set { _图像 = value; }
            }

            private string _文本 = string.Empty;
            public string 文本
            {
                get { return _文本; }
                set { _文本 = value; }
            }
        }
        [Serializable]
        public class P运行 { }
        [Serializable]
        internal class P输出 { }
        #endregion

    }

    /// <summary>
    /// 图像结构
    /// </summary>
    [Serializable]
    internal class SImage
    {
        internal SImage(HObject image, string format, string path)
        {
            this.image = image;
            this.format = format;
            this.path = path;
        }
        internal HObject image;         //图像
        internal string format;         //格式
        internal string path;           //路径
    }
    /// <summary>
    /// 图像来源
    /// </summary>
    internal enum SaveImageSource
    {
        InputImage,             //输入图像
        WindowImage,            //窗口图像
    }

}