using HalconDotNet;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ViewWindow.Model;

namespace VM_Pro
{

    [Serializable]
    /// <summary>
    /// 采集图像
    /// </summary>
    internal class ImageTool : ToolBase
    {
        internal ImageTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;
            L_OutItemType = new List<DataType> { DataType.Image};

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                {
                    cameraName = Project.Instance.L_Service[i].name;
                    hardTrig = CCamera.GetCCamera(cameraName).hardTrigServer;
                    break;
                }
            }
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolType == ToolType.光源控制)
                {
                    lightToolName = Task.curTask.L_toolList[i].toolName;
                    break;
                }
            }
        }

        internal int subPixel = 100;
        /// <summary>
        /// 相机名称
        /// </summary>
        internal string cameraName = string.Empty;
        /// <summary>
        /// 相机1名称
        /// </summary>
        internal string camera1Name = string.Empty;
        /// <summary>
        /// 相机2名称
        /// </summary>
        internal string camera2Name = string.Empty;
        /// <summary>
        /// 相机3名称
        /// </summary>
        internal string camera3Name = string.Empty;
        /// <summary>
        /// 相机4名称
        /// </summary>
        internal string camera4Name = string.Empty;
        /// <summary>
        /// 图像拼接
        /// </summary>
        internal bool pieceImage = false;
        /// <summary>
        /// 自动开灯
        /// </summary>
        internal bool autoLight = false;
        /// <summary>
        /// 自动开灯时所链接的光源控制工具
        /// </summary>
        internal string lightToolName = string.Empty;
        /// <summary>
        /// 图像拼接形式
        /// </summary>
        internal PieceType pieceType = PieceType.TwoImageLR;
        /// <summary>
        /// 图像来源
        /// </summary>
        internal ImageSource imageSource = ImageSource.FromCamera;
        /// <summary>
        /// 曝光时间
        /// </summary>
        internal int exposure = 100;
        /// <summary>
        /// 相机1曝光时间
        /// </summary>
        internal int exposure1 = 100;
        /// <summary>
        /// 相机2曝光时间
        /// </summary>
        internal int exposure2 = 100;
        /// <summary>
        /// 相机3曝光时间
        /// </summary>
        internal int exposure3 = 100;
        /// <summary>
        /// 相机4曝光时间
        /// </summary>
        internal int exposure4 = 100;
        /// <summary>
        /// 硬触发模式     True：硬触发采集   False：软触发采集
        /// </summary>
        internal bool hardTrig = false;
        /// <summary>
        /// 读取本地图像时文件路径模式   True：绝对路径   False：相对路径
        /// </summary>
        internal bool absPath = true;
        /// <summary>
        /// 相机实时显示线程
        /// </summary>
        internal static Thread th_livePlay = null;
        /// <summary>
        /// 从本地读取图像时旋转图像      True：旋转     False：不旋转
        /// </summary>
        internal bool rotateImageForLocal = false;
        /// <summary>
        /// 从本地读取图像时图像旋转角度
        /// </summary>
        internal int rotateAngleForLocal = 180;
        /// <summary>
        /// 自动运行时是否显示局部图像区域     True：是  False：否
        /// </summary>
        internal bool dispPartImage = false;
        /// <summary>
        /// 只显示局部图像时的ROI区域
        /// </summary>
        internal List<ROI> L_regions = new List<ROI>();
        /// <summary>
        /// 读取文件夹图像时，当前图像的索引
        /// </summary>
        internal int currentImageIndex = 0;
        /// <summary>
        /// 读取文件夹图像时，当前图像的名称
        /// </summary>
        internal string currentImageName = string.Empty;
        /// <summary>
        /// 读取文件夹图像时，图像路径集合
        /// </summary>
        internal List<string> L_imagePath = new List<string>();
        /// <summary>
        /// 读取单张图像时，图像文件路径
        /// </summary>
        internal string imagePath = string.Empty;
        /// <summary>
        /// 读取文件夹图像时，图像文件夹路径
        /// </summary>
        internal string imageDirectoryPath = string.Empty;
        /// <summary>
        /// 保存图像的路径
        /// </summary>
        private static string savePath = string.Empty;
        /// <summary>
        /// 采集区域的左上角行坐标
        /// </summary>
        internal int row1 = 0;
        /// <summary>
        /// 采集区域的左上角列坐标
        /// </summary>
        internal int col1 = 0;
        /// <summary>
        /// 采集区域的右下角行坐标
        /// </summary>
        internal int row2 = 1944;
        /// <summary>
        /// 采集区域的右下角列坐标
        /// </summary>
        internal int col2 = 2592;


        /// <summary>
        /// 复位工具
        /// </summary>
        internal override void ResetTool()
        {
            exposure = 100;
            imagePath = string.Empty;
            imageDirectoryPath = string.Empty;

            if (imageSource != ImageSource.FromCamera)            //避免切换时出现闪烁现象
                SwitchImageSource(ImageSource.FromCamera);

            Frm_ImageTool.Instance.hWindow_Final1.ClearWindow();
            Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
            Frm_ImageTool.Instance.lbl_toolTip.Text = "暂无提示";
            Frm_ImageTool.Instance.lbl_runTime.Text = "0 ms";
            Frm_ImageTool.Instance.ckb_dispPartImage.Checked = false;
            Frm_ImageTool.Instance.rdo_fromCamera.Checked = true;

            Frm_FromCamera.Instance.nud_exposure.Value = 100;
            Frm_FromFile.Instance.tbx_imagePath.Text = string.Empty;
            Frm_FromDirectory.Instance.tbx_imageDirectoryPath.Text = string.Empty;
        }
        /// <summary>
        /// 图像源切换
        /// </summary>
        /// <param name="imageSource">新的图像源</param>
        internal void SwitchImageSource(ImageSource imageSource)
        {
            this.imageSource = imageSource;
            switch (imageSource)
            {
                //选择从相机获取图像
                case ImageSource.FromCamera:
                    Frm_ImageTool.Instance.rdo_fromCamera.ForeColor = Color.FromArgb(80, 160, 255);
                    Frm_ImageTool.Instance.rdo_fromFile.ForeColor = Color.FromArgb(48, 48, 48);
                    Frm_ImageTool.Instance.rdo_fromDirectory.ForeColor = Color.FromArgb(48, 48, 48);

                    Frm_ImageTool.Instance.rdo_fromCamera.Font = new Font(Frm_ImageTool.Instance.rdo_fromCamera.Font.Name, Frm_ImageTool.Instance.rdo_fromCamera.Font.Size, FontStyle.Bold);
                    Frm_ImageTool.Instance.rdo_fromFile.Font = new Font(Frm_ImageTool.Instance.rdo_fromFile.Font.Name, Frm_ImageTool.Instance.rdo_fromFile.Font.Size, FontStyle.Regular);
                    Frm_ImageTool.Instance.rdo_fromDirectory.Font = new Font(Frm_ImageTool.Instance.rdo_fromDirectory.Font.Name, Frm_ImageTool.Instance.rdo_fromDirectory.Font.Size, FontStyle.Regular);

                    Frm_ImageTool.Instance.pnl_formPanel.Controls.Clear();
                    if (!pieceImage)
                    {
                        Frm_FromCamera.Instance.TopLevel = false;
                        Frm_FromCamera.Instance.Parent = Frm_ImageTool.Instance.pnl_formPanel;
                        Frm_FromCamera.Instance.Dock = DockStyle.Top;
                        Frm_FromCamera.Instance.Show();
                    }
                    else
                    {
                        Frm_PieceImage.Instance.TopLevel = false;
                        Frm_PieceImage.Instance.Parent = Frm_ImageTool.Instance.pnl_formPanel;
                        Frm_PieceImage.Instance.Dock = DockStyle.Top;
                        Frm_PieceImage.Instance.Show();
                    }
                    break;
                //选择对应的文件导入图像
                case ImageSource.FromFile:
                    Frm_ImageTool.Instance.rdo_fromCamera.ForeColor = Color.FromArgb(48, 48, 48);
                    Frm_ImageTool.Instance.rdo_fromFile.ForeColor = Color.FromArgb(80, 160, 255);
                    Frm_ImageTool.Instance.rdo_fromDirectory.ForeColor = Color.FromArgb(48, 48, 48);

                    Frm_ImageTool.Instance.rdo_fromCamera.Font = new Font(Frm_ImageTool.Instance.rdo_fromCamera.Font.Name, Frm_ImageTool.Instance.rdo_fromCamera.Font.Size, FontStyle.Regular);
                    Frm_ImageTool.Instance.rdo_fromFile.Font = new Font(Frm_ImageTool.Instance.rdo_fromFile.Font.Name, Frm_ImageTool.Instance.rdo_fromFile.Font.Size, FontStyle.Bold);
                    Frm_ImageTool.Instance.rdo_fromDirectory.Font = new Font(Frm_ImageTool.Instance.rdo_fromDirectory.Font.Name, Frm_ImageTool.Instance.rdo_fromDirectory.Font.Size, FontStyle.Regular);

                    Frm_ImageTool.Instance.pnl_formPanel.Controls.Clear();
                    Frm_FromFile.Instance.TopLevel = false;
                    Frm_FromFile.Instance.Parent = Frm_ImageTool.Instance.pnl_formPanel;
                    Frm_FromFile.Instance.Dock = DockStyle.Top;
                    Frm_FromFile.Instance.Show();

                    Frm_FromFile.Instance.ckb_rotateImage.Checked = rotateImageForLocal;
                    Frm_FromFile.Instance.nud_rotateAngle.Value = rotateAngleForLocal;
                    break;
                //选择对应的文件路径，获取该路径下所有图像
                case ImageSource.FromDirectory:
                    Frm_ImageTool.Instance.rdo_fromCamera.ForeColor = Color.FromArgb(48, 48, 48);
                    Frm_ImageTool.Instance.rdo_fromFile.ForeColor = Color.FromArgb(48, 48, 48);
                    Frm_ImageTool.Instance.rdo_fromDirectory.ForeColor = Color.FromArgb(80, 160, 255);

                    Frm_ImageTool.Instance.rdo_fromCamera.Font = new Font(Frm_ImageTool.Instance.rdo_fromCamera.Font.Name, Frm_ImageTool.Instance.rdo_fromCamera.Font.Size, FontStyle.Regular);
                    Frm_ImageTool.Instance.rdo_fromFile.Font = new Font(Frm_ImageTool.Instance.rdo_fromFile.Font.Name, Frm_ImageTool.Instance.rdo_fromFile.Font.Size, FontStyle.Regular);
                    Frm_ImageTool.Instance.rdo_fromDirectory.Font = new Font(Frm_ImageTool.Instance.rdo_fromDirectory.Font.Name, Frm_ImageTool.Instance.rdo_fromDirectory.Font.Size, FontStyle.Bold);

                    Frm_ImageTool.Instance.pnl_formPanel.Controls.Clear();
                    Frm_FromDirectory.Instance.TopLevel = false;
                    Frm_FromDirectory.Instance.Parent = Frm_ImageTool.Instance.pnl_formPanel;
                    Frm_FromDirectory.Instance.Dock = DockStyle.Top;
                    Frm_FromDirectory.Instance.Show();

                    Frm_FromDirectory.Instance.ckb_rotateImage.Checked = rotateImageForLocal;
                    Frm_FromDirectory.Instance.nud_rotateAngle.Value = rotateAngleForLocal;
                    break;
            }
            Application.DoEvents();
        }
        /// <summary>
        /// 图像拼接
        /// </summary>
        /// <param name="image1"></param>
        /// <param name="image2"></param>
        /// <param name="pieceMode">0：左右拼接      1：上下拼接</param>
        /// <returns></returns>
        internal static HObject PieceImage(HObject image1, HObject image2, int pieceMode)
        {
            HObject imagePieced = new HObject();

            //1.图像拼接的思想，先拿到两张图像，然后分别获取到对应的尺寸信息》根据自己所需创建一张新的图像》将第一张图像写入到创建的新图像当中
            //》将第二张图像先做一个仿射变换，把第二张图像平移到对应的位置当中》将平移后的第二张图片写入到新的图像当中

            //拼接图像
            if (pieceMode == 0)          //左右拼接
            {
                HTuple width1, height1;
                HOperatorSet.GetImageSize(image1, out width1, out height1);
                HTuple width2, height2;
                HOperatorSet.GetImageSize(image2, out width2, out height2);
                HTuple type;
                HOperatorSet.GetImageType(image1, out type);
                HOperatorSet.GenImageConst(out imagePieced, type, width1 + width2, height1);
                HOperatorSet.OverpaintGray(imagePieced, image1);
                HTuple homMat2D;
                HOperatorSet.HomMat2dIdentity(out homMat2D);
                HOperatorSet.HomMat2dTranslate(homMat2D, 0, width1, out homMat2D);
                HObject imageTransed;
                HOperatorSet.AffineTransImage(image2, out imageTransed, homMat2D, "constant", "true");
                HOperatorSet.OverpaintGray(imagePieced, imageTransed);
            }
            else                          //上下拼接
            {
                HTuple width, height;
                HOperatorSet.GetImageSize(image1, out width, out height);
                HTuple type;
                HOperatorSet.GetImageType(image1, out type);
                HOperatorSet.GenImageConst(out imagePieced, type, width * 2, height);
                HOperatorSet.OverpaintGray(imagePieced, image1);
                HTuple homMat2D;
                HOperatorSet.HomMat2dIdentity(out homMat2D);
                HOperatorSet.HomMat2dTranslate(homMat2D, 0, width, out homMat2D);
                HObject imageTransed;
                HOperatorSet.AffineTransImage(image2, out imageTransed, homMat2D, "constant", "true");
                HOperatorSet.OverpaintGray(imagePieced, imageTransed);
            }
            return imagePieced;
        }
        /// <summary>
        /// 选择图像文件
        /// </summary>
        internal void SelectImage()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Title = "请选择图像文件路径";
            if (imagePath == string.Empty)      //如果添加工具后第一次选择图像文件
            {
                if (absPath)      //绝对路径：图像文件的路径是绝对的
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                else                //相对路径：图像文件的路径是相对于程序输出目录的
                    openFileDialog.InitialDirectory = Application.StartupPath;
            }
            else      //如果添加工具后不是第一次选择图像文件，就以上一次选择的路径为默认路径
            {
                if (absPath)
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(imagePath);
                }
                else
                {
                    if (File.Exists(Application.StartupPath + imagePath))
                        openFileDialog.InitialDirectory = Application.StartupPath + imagePath;
                    else
                        openFileDialog.InitialDirectory = Application.StartupPath;
                }
            }
            openFileDialog.Filter = "图像文件(*.*)|*.*|图像文件(*.jpg)|*.jpg|图像文件(*.png)|*.png|图像文件(*.bmp)|*.bmp|图像文件(*.tif)|*.tif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (absPath)
                {
                    imagePath = openFileDialog.FileName;
                }
                else
                {
                    if (openFileDialog.FileName.StartsWith(Application.StartupPath))       //相对路径模式下，只允许选择程序输出目录下的路径
                    {
                        imagePath = openFileDialog.FileName.Substring(Application.StartupPath.Length, openFileDialog.FileName.Length - Application.StartupPath.Length);
                    }
                    else
                    {
                        Frm_ImageTool.Instance.lbl_toolTip.Text = "相对路径模式下只能指定程序输出目录下的路径，路径指定失败";
                        Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                        return;
                    }
                }

                Frm_FromFile.Instance.tbx_imagePath.Text = imagePath;
                Thread th = new Thread(() =>
                {
                    Run();
                });
                th.IsBackground = true;
                th.Start();
            }
        }
        /// <summary>
        /// 选择图像文件夹
        /// </summary>
        internal void SelectDirectory()
        {
            VistaFolderBrowserDialog vistaFolderBrowserDialog = new VistaFolderBrowserDialog();
            if (imageDirectoryPath == string.Empty)
            {
                if (absPath)
                    vistaFolderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                else
                    vistaFolderBrowserDialog.SelectedPath = Application.StartupPath;
            }
            else
            {
                if (absPath)
                {
                    vistaFolderBrowserDialog.SelectedPath = imageDirectoryPath;
                }
                else
                {
                    if (Directory.Exists(Application.StartupPath + imageDirectoryPath))
                        vistaFolderBrowserDialog.SelectedPath = Application.StartupPath + imageDirectoryPath;
                    else
                        vistaFolderBrowserDialog.SelectedPath = Application.StartupPath;
                }
            }
            vistaFolderBrowserDialog.Description = "请选择图像文件夹路径";
            if (vistaFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (absPath)
                {
                    imageDirectoryPath = vistaFolderBrowserDialog.SelectedPath;
                }
                else
                {
                    if (vistaFolderBrowserDialog.SelectedPath.StartsWith(Application.StartupPath))
                    {
                        imageDirectoryPath = vistaFolderBrowserDialog.SelectedPath.Substring(Application.StartupPath.Length, vistaFolderBrowserDialog.SelectedPath.Length - Application.StartupPath.Length);
                    }
                    else
                    {
                        Frm_ImageTool.Instance.lbl_toolTip.Text = "相对路径模式下只能指定程序输出目录下的路径，路径指定失败";
                        Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                        return;
                    }
                }

                Frm_FromDirectory.Instance.tbx_imageDirectoryPath.Text = imageDirectoryPath;

                GetDirImgList(vistaFolderBrowserDialog.SelectedPath);

                currentImageIndex = L_imagePath.Count - 2;
                Thread th = new Thread(() =>
                {
                    Run();
                });
                th.IsBackground = true;
                th.Start();
            }
        }
        /// <summary>
        /// 获取指定路径下的图片文件名
        /// </summary>
        /// <param name="Dir">指定路径</param>
        internal void GetDirImgList(string Dir)
        {
            L_imagePath.Clear();
            string[] files = Directory.GetFiles(Dir);
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(files[i]);
                if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png" || fileInfo.Extension == ".PNG" || fileInfo.Extension == ".bmp" || fileInfo.Extension == ".tif")
                    L_imagePath.Add(files[i]);
            }
        }



        /// <summary>
        /// 读取文件夹中上一张图像
        /// </summary>
        internal void LastImage()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            HObject image;
            HOperatorSet.GenEmptyObj(out image);
            currentImageIndex--;
            if (currentImageIndex < 0)
                currentImageIndex = L_imagePath.Count - 1;
            try
            {
                HOperatorSet.ReadImage(out image, L_imagePath[currentImageIndex]);

                //旋转图像
                if (rotateImageForLocal)
                    HOperatorSet.RotateImage(image, out image, -rotateAngleForLocal, "constant");
            }
            catch
            {
                Frm_ImageTool.Instance.lbl_runTime.Text = "0 ms";
                Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                Frm_ImageTool.Instance.lbl_toolTip.Text = "图像文件异常或路径不合法";
                return;
            }
            currentImageName = Path.GetFileName(L_imagePath[currentImageIndex]);
            Frm_ImageTool.Instance.hWindow_Final1.HobjectToHimage(image);

            long time = sw.ElapsedMilliseconds;
            Frm_ImageTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());
            Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
            Frm_ImageTool.Instance.lbl_toolTip.Text = string.Format("运行成功，当前图像：{0}  ({1})", currentImageName, currentImageIndex + 1 + "/" + L_imagePath.Count);
        }
        /// <summary>
        /// 读取文件夹中下一张图像
        /// </summary>
        internal void NextImage()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            HObject image;
            HOperatorSet.GenEmptyObj(out image);
            currentImageIndex++;
            if (currentImageIndex > L_imagePath.Count - 1)
                currentImageIndex = 0;
            try
            {
                HOperatorSet.ReadImage(out image, L_imagePath[currentImageIndex]);

                //采图转灰度图


                //旋转图像
                if (rotateImageForLocal)
                    HOperatorSet.RotateImage(image, out image, -rotateAngleForLocal, "constant");
            }
            catch
            {
                Frm_ImageTool.Instance.lbl_runTime.Text = "0 ms";
                Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                Frm_ImageTool.Instance.lbl_toolTip.Text = "图像文件异常或路径不合法";
                return;
            }
            Frm_ImageTool.Instance.hWindow_Final1.HobjectToHimage(image);

            long time = sw.ElapsedMilliseconds;
            Frm_ImageTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());
            Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
            Frm_ImageTool.Instance.lbl_toolTip.Text = string.Format("运行成功，当前图像：{0}  ({1})", currentImageName, currentImageIndex + 1 + "/" + L_imagePath.Count);
        }
        /// <summary>
        /// 保存图像到本地
        /// </summary>
        internal void SaveImage()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (savePath == string.Empty)
                savePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            if (((ToolPar)参数).输出.图像 == null)
            {
                Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                Frm_ImageTool.Instance.lbl_toolTip.Text = "未获取到图像，不可保存";
                return;
            }

            int index;
            for (index = 1; index < 1000; index++)
            {
                if (!File.Exists(savePath + "\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + index.ToString("00") + ".jpg"))
                    break;
            }
            saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + index.ToString("00");
            saveFileDialog.Title = "请选择图像保存路径";
            saveFileDialog.Filter = "图像文件(*.jpg)|*.jpg|图像文件(*.png)|*.png|图像文件(*.PNG)|*.PNG|图像文件(*.bmp)|*.bmp|图像文件(*.tif)|*.tif";
            saveFileDialog.InitialDirectory = savePath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    HOperatorSet.WriteImage((HObject)((ToolPar)参数).输出.图像, "jpg", 0, saveFileDialog.FileName);
                    savePath = Path.GetDirectoryName(saveFileDialog.FileName);
                }
                catch
                {
                    Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                    Frm_ImageTool.Instance.lbl_toolTip.Text = "图像文件异常或路径不合法";
                }
            }
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
                参数 = new ToolPar();

            if (!Frm_ImageTool.openingForm && !Frm_Vision.Instance.停止切换toolStripButton.Checked && !hardTrig)//1.hardTrig回调会给图，不能清空
                ((ToolPar)参数).输出.图像 = null;

            HObject image;
            switch (imageSource)
            {
                case ImageSource.FromCamera:

                    #region 从设备采集

                    #region 判断是否为硬触发模式，若是的话，则不需要进行采集图像了

                    if (hardTrig)
                    {
                        //检查当前相机是否存在
                        bool serviceExist = false;
                        for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                        {
                            if (Project.Instance.L_Service[i].name == cameraName && Project.Instance.L_Service[i].serviceType == ServiceType.Camera )
                            {
                                serviceExist = true;
                                break;
                            }
                        }
                        if (!serviceExist)
                        {
                            ClearWindow();
                            toolRunStatu = "相机未创建";
                            if (!initRun)
                                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                            goto Exit;
                        }

                        if (((ToolPar)参数).输出.图像 == null)   //正常情况，此时回调已经给图片了，故无需再去进行取像
                        {
                            toolRunStatu = "回调无返回图像";
                            goto Exit;
                        }
                        else
                        {
                            toolRunStatu = "运行成功";
                        }
                        break;
                    }

                    #endregion


                    if (!pieceImage)               //从单相机采集，不拼接图像
                    {
                        //如未指定相机，则自动指定第一个相机
                        if (cameraName == string.Empty)
                        {
                            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                            {
                                if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                                {
                                    cameraName = Project.Instance.L_Service[i].name;
                                    break;
                                }
                            }

                            if (cameraName == string.Empty)
                            {
                                ClearWindow();
                                toolRunStatu = "未指定相机";
                                if (!initRun)
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                goto Exit;
                            }
                        }

                        //检查当前相机是否存在
                        bool serviceExist = false;
                        for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                        {
                            if (Project.Instance.L_Service[i].name == cameraName && Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                            {
                                serviceExist = true;
                                break;
                            }
                        }
                        if (!serviceExist)
                        {
                            ClearWindow();
                            toolRunStatu = "相机未创建";
                            if (!initRun)
                                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                            goto Exit;
                        }

                        //检查当前相机是否识别，有的时候相机没通电，那么相机就不存在
                        if (!SDK_Base.CheckExist(cameraName))
                        {
                            ClearWindow();
                            toolRunStatu = "相机未识别";
                            if (!initRun)
                                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                            goto Exit;
                        }

                        if (CCamera.FindCamera(cameraName).loopGrab)         //如果正在实时显示，那就停止下来
                        {
                            CCamera.FindCamera(cameraName).loopGrab = false;
                            Thread.Sleep(50);
                        }

                        if ((!Frm_ImageTool.openingForm && !Frm_Vision.Instance.停止切换toolStripButton.Checked) || ((ToolPar)参数).输出.图像 == null)
                        {
                            //不需要每次都设置曝光等时间
                            //////CCamera.FindCamera(cameraName).SetExposure(exposure, cameraName);
                            //////CCamera.FindCamera(cameraName).SetGain(((CCamera)Project.FindServiceByName(cameraName)).gain, cameraName);
                            //////CCamera.FindCamera(cameraName).SetAcqRegion(row1, col1, row2, col2, cameraName);
                            ((ToolPar)参数).输出.图像 = CCamera.FindCamera(cameraName).GrabOneImage(cameraName);
                            if (((ToolPar)参数).输出.图像 == null)
                            {
                                ClearWindow();
                                toolRunStatu = "采集失败";
                                if (!initRun)
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                goto Exit;
                            }
                        }
                    }
                    else            //多相机采集，图像拼接
                    {
                        //如未指定相机，则自动指定相应相机
                        if (camera1Name == string.Empty)
                        {
                            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                            {
                                if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                                {
                                    camera1Name = Project.Instance.L_Service[i].name;
                                    break;
                                }
                            }

                            if (camera1Name == string.Empty)
                            {
                                ClearWindow();
                                toolRunStatu = "未指定相机";
                                if (!initRun)
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                goto Exit;
                            }
                        }
                        if (camera2Name == string.Empty)
                        {
                            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                            {
                                if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                                {
                                    camera2Name = Project.Instance.L_Service[i].name;
                                    break;
                                }
                            }

                            if (camera2Name == string.Empty)
                            {
                                ClearWindow();
                                toolRunStatu = "未指定相机";
                                if (!initRun)
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                goto Exit;
                            }
                        }
                        if (pieceType == PieceType.ForeImage)
                        {
                            if (camera3Name == string.Empty)
                            {
                                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                                {
                                    if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                                    {
                                        camera3Name = Project.Instance.L_Service[i].name;
                                        break;
                                    }
                                }

                                if (camera3Name == string.Empty)
                                {
                                    ClearWindow();
                                    toolRunStatu = "未指定相机";
                                    if (!initRun)
                                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                    goto Exit;
                                }
                            }
                            if (camera4Name == string.Empty)
                            {
                                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                                {
                                    if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                                    {
                                        camera4Name = Project.Instance.L_Service[i].name;
                                        break;
                                    }
                                }

                                if (camera4Name == string.Empty)
                                {
                                    ClearWindow();
                                    toolRunStatu = "未指定相机";
                                    if (!initRun)
                                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                    goto Exit;
                                }
                            }
                        }

                        //检查当前相机是否存在
                        bool service1Exist = false;
                        bool service2Exist = false;
                        bool service3Exist = false;
                        bool service4Exist = false;
                        for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                        {
                            if (Project.Instance.L_Service[i].name == camera1Name && Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                            {
                                service1Exist = true;
                            }
                            if (Project.Instance.L_Service[i].name == camera2Name && Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                            {
                                service2Exist = true;
                            }
                            if (pieceType == PieceType.ForeImage)
                            {
                                if (Project.Instance.L_Service[i].name == camera3Name && Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                                {
                                    service3Exist = true;
                                }
                                if (Project.Instance.L_Service[i].name == camera4Name && Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                                {
                                    service4Exist = true;
                                }
                            }
                        }
                        if (pieceType == PieceType.ForeImage)
                        {
                            if (!service1Exist && !service2Exist && !service3Exist && !service4Exist)
                            {
                                ClearWindow();
                                toolRunStatu = "相机未创建";
                                if (!initRun)
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败！原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                goto Exit;
                            }
                        }
                        else
                        {
                            if (!service1Exist && !service2Exist)
                            {
                                ClearWindow();
                                toolRunStatu = "相机未创建";
                                if (!initRun)
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败！原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                goto Exit;
                            }
                        }

                        //检查当前相机是否识别，有的时候相机没通电，那么相机就不存在
                        if (!SDK_Base.CheckExist(camera1Name))
                        {
                            ClearWindow();
                            toolRunStatu = "相机未识别";
                            if (!initRun)
                                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败！原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                            goto Exit;
                        }
                        if (!SDK_Base.CheckExist(camera2Name))
                        {
                            ClearWindow();
                            toolRunStatu = "相机未识别";
                            if (!initRun)
                                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败！原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                            goto Exit;
                        }
                        if (pieceType == PieceType.ForeImage)
                        {
                            if (!SDK_Base.CheckExist(camera3Name))
                            {
                                ClearWindow();
                                toolRunStatu = "相机未识别";
                                if (!initRun)
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败！原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                goto Exit;
                            }
                            if (!SDK_Base.CheckExist(camera4Name))
                            {
                                ClearWindow();
                                toolRunStatu = "相机未识别";
                                if (!initRun)
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败！原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                goto Exit;
                            }
                        }

                        //如未指定相机，则自动指定第一个相机
                        if (camera1Name == string.Empty)
                        {
                            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                            {
                                if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                                {
                                    camera1Name = Project.Instance.L_Service[i].name;
                                    break;
                                }
                            }

                            if (camera1Name == string.Empty)
                            {
                                ClearWindow();
                                toolRunStatu = "未指定相机";
                                if (!initRun)
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                goto Exit;
                            }
                        }
                        if (camera2Name == string.Empty)
                        {
                            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                            {
                                if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                                {
                                    camera2Name = Project.Instance.L_Service[i].name;
                                    break;
                                }
                            }

                            if (camera2Name == string.Empty)
                            {
                                ClearWindow();
                                toolRunStatu = "未指定相机";
                                if (!initRun)
                                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                goto Exit;
                            }
                        }
                        if (pieceType == PieceType.ForeImage)
                        {
                            if (camera3Name == string.Empty)
                            {
                                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                                {
                                    if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                                    {
                                        camera3Name = Project.Instance.L_Service[i].name;
                                        break;
                                    }
                                }

                                if (camera3Name == string.Empty)
                                {
                                    ClearWindow();
                                    toolRunStatu = "未指定相机";
                                    if (!initRun)
                                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                    goto Exit;
                                }
                            }
                            if (camera4Name == string.Empty)
                            {
                                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                                {
                                    if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                                    {
                                        camera4Name = Project.Instance.L_Service[i].name;
                                        break;
                                    }
                                }

                                if (camera4Name == string.Empty)
                                {
                                    ClearWindow();
                                    toolRunStatu = "未指定相机";
                                    if (!initRun)
                                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                    goto Exit;
                                }
                            }
                        }

                        if (CCamera.FindCamera(camera1Name).loopGrab)         //如果正在实时显示，那就停止下来
                        {
                            CCamera.FindCamera(camera1Name).loopGrab = false;
                            Thread.Sleep(50);
                        }
                        if (CCamera.FindCamera(camera2Name).loopGrab)         //如果正在实时显示，那就停止下来
                        {
                            CCamera.FindCamera(camera2Name).loopGrab = false;
                            Thread.Sleep(50);
                        }
                        if (pieceType == PieceType.ForeImage)
                        {
                            if (CCamera.FindCamera(camera3Name).loopGrab)         //如果正在实时显示，那就停止下来
                            {
                                CCamera.FindCamera(camera3Name).loopGrab = false;
                                Thread.Sleep(50);
                            }
                            if (CCamera.FindCamera(camera4Name).loopGrab)         //如果正在实时显示，那就停止下来
                            {
                                CCamera.FindCamera(camera4Name).loopGrab = false;
                                Thread.Sleep(50);
                            }
                        }

                        if ((!Frm_ImageTool.openingForm && !Frm_Vision.Instance.停止切换toolStripButton.Checked) || ((ToolPar)参数).输出.图像 == null)
                        {
                            HObject image1 = null, image2 = null, image3 = null, image4 = null;

                            CCamera.FindCamera(camera1Name).SetExposure(exposure1, camera1Name);
                            CCamera.FindCamera(camera1Name).SetGain(((CCamera)Project.FindServiceByName(camera1Name)).gain, camera1Name);
                            CCamera.FindCamera(camera1Name).SetAcqRegion(row1, col1, row2, col2, camera1Name);
                            image1 = CCamera.FindCamera(camera1Name).GrabOneImage(camera1Name);

                            CCamera.FindCamera(camera2Name).SetExposure(exposure2, camera2Name);
                            CCamera.FindCamera(camera2Name).SetGain(((CCamera)Project.FindServiceByName(camera2Name)).gain, camera2Name);
                            CCamera.FindCamera(camera2Name).SetAcqRegion(row1, col1, row2, col2, camera2Name);
                            image2 = CCamera.FindCamera(camera2Name).GrabOneImage(camera2Name);

                            if (pieceType == PieceType.ForeImage)
                            {
                                CCamera.FindCamera(camera3Name).SetExposure(exposure3, camera3Name);
                                CCamera.FindCamera(camera3Name).SetGain(((CCamera)Project.FindServiceByName(camera3Name)).gain, camera3Name);
                                CCamera.FindCamera(camera3Name).SetAcqRegion(row1, col1, row2, col2, camera3Name);
                                image3 = CCamera.FindCamera(camera3Name).GrabOneImage(camera3Name);

                                CCamera.FindCamera(camera4Name).SetExposure(exposure4, camera4Name);
                                CCamera.FindCamera(camera4Name).SetGain(((CCamera)Project.FindServiceByName(camera4Name)).gain, camera4Name);
                                CCamera.FindCamera(camera4Name).SetAcqRegion(row1, col1, row2, col2, camera4Name);
                                image4 = CCamera.FindCamera(camera4Name).GrabOneImage(camera4Name);
                            }

                            if (pieceType == PieceType.ForeImage)
                            {
                                if (image1 == null || image2 == null || image3 == null || image4 == null)
                                {
                                    ClearWindow();
                                    toolRunStatu = "采集失败";
                                    if (!initRun)
                                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                    goto Exit;
                                }
                            }
                            else
                            {
                                if (image1 == null || image2 == null)
                                {
                                    ClearWindow();
                                    toolRunStatu = "采集失败";
                                    if (!initRun)
                                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                                    goto Exit;
                                }
                            }

                            //旋转图像
                            if (((CCamera)Project.FindServiceByName(camera1Name)).rotateImage)
                                HOperatorSet.RotateImage(image1, out image1, -((CCamera)Project.FindServiceByName(camera1Name)).rotateAngle, "constant");
                            if (((CCamera)Project.FindServiceByName(camera2Name)).rotateImage)
                                HOperatorSet.RotateImage(image2, out image2, -((CCamera)Project.FindServiceByName(camera2Name)).rotateAngle, "constant");
                            if (pieceType == PieceType.ForeImage)
                            {
                                if (((CCamera)Project.FindServiceByName(camera3Name)).rotateImage)
                                    HOperatorSet.RotateImage(image3, out image3, -((CCamera)Project.FindServiceByName(camera3Name)).rotateAngle, "constant");
                                if (((CCamera)Project.FindServiceByName(camera4Name)).rotateImage)
                                    HOperatorSet.RotateImage(image4, out image4, -((CCamera)Project.FindServiceByName(camera4Name)).rotateAngle, "constant");
                            }

                            //临时添加，对image2进行裁剪
                            HTuple width, height;
                            HOperatorSet.GetImageSize(image2, out width, out height);
                            HOperatorSet.CropPart(image2, out image2, 0, subPixel, width - subPixel, height);

                            //图像拼接
                            ((ToolPar)参数).输出.图像 = PieceImage(image1, image2, 0);
                        }
                    }
                    break;

                #endregion

                case ImageSource.FromFile:

                    #region 从文件读取

                    if (imagePath == string.Empty)
                    {
                        ClearWindow();
                        toolRunStatu = "未指定图像路径";
                        if (!initRun)
                            FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }

                    try
                    {
                        if (absPath)
                            HOperatorSet.ReadImage(out image, imagePath);
                        else
                            HOperatorSet.ReadImage(out image, Application.StartupPath + imagePath);
                    }
                    catch
                    {
                        ClearWindow();
                        toolRunStatu = "图像文件异常或路径不合法";
                        if (!initRun)
                            FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }
                    ((ToolPar)参数).输出.图像 = image;
                    break;

                #endregion

                case ImageSource.FromDirectory:

                    #region 从文件夹读取
                    if (imageDirectoryPath == string.Empty)
                    {
                        ClearWindow();
                        toolRunStatu = "未指定图像路径";
                        if (!initRun)
                            FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }

                    //每运行一次都要重新刷新文件夹下面的图像
                    string[] files = new string[] { };
                    try
                    {
                        if (absPath)
                            files = Directory.GetFiles(imageDirectoryPath);
                        else
                            files = Directory.GetFiles(Application.StartupPath + imageDirectoryPath);
                    }
                    catch
                    {
                        ClearWindow(); 
                        toolRunStatu = "文件夹不存在";
                        if (!initRun)
                            FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }

                    L_imagePath.Clear();
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo fileInfo = new FileInfo(files[i]);
                        if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png" || fileInfo.Extension == ".PNG" || fileInfo.Extension == ".bmp" || fileInfo.Extension == ".tif")
                            L_imagePath.Add(files[i]);
                    }

                    if (L_imagePath.Count == 0)
                    {
                        ClearWindow();
                        toolRunStatu = "文件夹内无有效图像";
                        if (!initRun)
                            FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                        goto Exit;
                    }

                    if (!Frm_Vision.Instance.停止切换toolStripButton.Checked)
                        currentImageIndex++;

                    if (currentImageIndex > L_imagePath.Count - 1)
                        currentImageIndex = 0;

                    if (currentImageIndex < 0)
                        currentImageIndex = 0;
                    try
                    {
                        HOperatorSet.ReadImage(out image, L_imagePath[currentImageIndex]);
                    }
                    catch (Exception ex)
                    {
                        FuncLib.ShowMessageBox("读取图片出现异常，请检查图片是否存在被加密等情况\r\n" + ex.Message, InfoType.Error);
                        toolRunStatu = "文件读取异常";
                        goto Exit;
                    }
                    currentImageName = Path.GetFileName(L_imagePath[currentImageIndex]);


                    ((ToolPar)参数).输出.图像 = image;
                    break;
                    #endregion

            }

            //彩色图像转灰度图像
            if (!pieceImage)
            {
                if (imageSource == ImageSource.FromCamera)
                {
                    if (((CCamera)Project.FindServiceByName(cameraName)).RGBToGray)
                    {
                        HTuple chNum;
                        HOperatorSet.CountChannels((HObject)((ToolPar)参数).输出.图像, out chNum);
                        if (chNum == 3)
                        {
                            HObject image1;
                            HOperatorSet.Rgb1ToGray((HObject)((ToolPar)参数).输出.图像, out image1);
                            ((ToolPar)参数).输出.图像 = image1;
                        }
                    }
                }

                //旋转图像
                if (imageSource == ImageSource.FromCamera)
                {
                    if (((CCamera)Project.FindServiceByName(cameraName)).rotateImage)
                    {
                        HObject image2;
                        HOperatorSet.RotateImage((HObject)((ToolPar)参数).输出.图像, out image2, -((CCamera)Project.FindServiceByName(cameraName)).rotateAngle, "constant");
                        ((ToolPar)参数).输出.图像 = image2;
                    }
                }
                else
                {
                    if (rotateImageForLocal)
                    {
                        HObject image2;
                        HOperatorSet.RotateImage((HObject)((ToolPar)参数).输出.图像, out image2, -rotateAngleForLocal, "constant");
                        ((ToolPar)参数).输出.图像 = image2;
                    }
                }
            }

            #region 临时添加，因为在语义分割训练的时候，将图片进行了压缩，故在此做了一个操作，将获取到的图片压缩为同样的尺寸

            if (dispPartImage)
            {
                HObject img = ((ImageTool.ToolPar)参数).输出.图像;
                HOperatorSet.ReduceDomain(img, L_regions[0].getRegion(), out img);
                HOperatorSet.CropDomain(img, out img);
                ((ImageTool.ToolPar)参数).输出.图像 = img;
            }

            //if (IsFenBianLv)
            //{
            //    HObject img = ((ToolPar)参数).输出.图像;
            //    HOperatorSet.GetImageSize(img, out HTuple w, out HTuple h);
            //    YuanFenBianLv_ImgWidth = w.I;
            //    YuanFenBianLv_Imgheight = h.I;
            //    HOperatorSet.ZoomImageSize(((ToolPar)参数).输出.图像, out img, FenBianLv_ImgWidth, FenBianLv_Imgheight, "constant");
            //    ((ToolPar)参数).输出.图像 = img;
            //}


            #endregion



            if (Frm_ImageTool.hasShown && Frm_ImageTool.taskName == taskName && Frm_ImageTool.toolName == toolName)
            {
                Frm_ImageTool.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输出.图像);
                if (dispPartImage)
                {
                    Frm_ImageTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
                    Frm_ImageTool.L_regions = this.L_regions;
                    SetPart(L_regions[0].getModelData()[0], L_regions[0].getModelData()[1], L_regions[0].getModelData()[2], L_regions[0].getModelData()[3]);
                }
            }

            if (!initRun && !trigedByTool)
                DispImage(((ToolPar)参数).输出.图像);

            //显示“测试图像”标识
            if (!initRun && imageSource != ImageSource.FromCamera)
            {
                HTuple row1, col1, row2, col2;
                //HOperatorSet.GetPart(GetImageWindow().hWindowControl.HalconWindow, out row1, out col1, out row2, out col2);
                HOperatorSet.GetPart(GetImageWindow().HWindowHalconID, out row1, out col1, out row2, out col2);
                HOperatorSet.GetPart(GetImageWindowBack(), out row1, out col1, out row2, out col2);
                if (imageSource == ImageSource.FromFile)
                {
                    if (GetImageWindow().Height > 300)
                    {
                        DispText("测试图像", 14, row1 + (row2 - row1) / 12, col1 + (col2 - col1) / 30, "blue", "false");
                    }
                    else
                    {
                        if (Task.FindTaskByName(taskName).showRunStatu)
                            DispText("测试图像", 14, row1 + (row2 - row1) / 10, col1 + (col2 - col1) / 30, "blue", "false");
                        else
                            DispText("测试图像", 14, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "blue", "false");
                    }
                }
                else
                {
                    if (GetImageWindow().Height > 300)
                    {
                        HalconLib.DispText(GetImageWindow().HWindowHalconID, "测试图像 " + (currentImageIndex + 1) + "/" + L_imagePath.Count, 14, row1 + (row2 - row1) / 12, col1 + (col2 - col1) / 30, "blue", "false");
                        HalconLib.DispText(GetImageWindowBack(), "测试图像 " + (currentImageIndex + 1) + "/" + L_imagePath.Count, 14, row1 + (row2 - row1) / 12, col1 + (col2 - col1) / 30, "blue", "false");
                    }
                    else
                    {
                        if (Task.FindTaskByName(taskName).showRunStatu)
                        {
                            HalconLib.DispText(GetImageWindow().HWindowHalconID, "测试图像 " + (currentImageIndex + 1) + "/" + L_imagePath.Count, 14, row1 + (row2 - row1) / 10, col1 + (col2 - col1) / 30, "blue", "false");
                            HalconLib.DispText(GetImageWindowBack(), "测试图像 " + (currentImageIndex + 1) + "/" + L_imagePath.Count, 14, row1 + (row2 - row1) / 10, col1 + (col2 - col1) / 30, "blue", "false");
                        }
                        else
                        {
                            HalconLib.DispText(GetImageWindow().HWindowHalconID, "测试图像 " + (currentImageIndex + 1) + "/" + L_imagePath.Count, 14, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "blue", "false");
                            HalconLib.DispText(GetImageWindowBack(), "测试图像 " + (currentImageIndex + 1) + "/" + L_imagePath.Count, 14, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "blue", "false");
                        }
                    }
                }
            }

            sw.Stop();
            toolRunStatu = "运行成功";
        Exit:
            if (Frm_ImageTool.hasShown && Frm_ImageTool.taskName == taskName && Frm_ImageTool.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_ImageTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());
                if (toolRunStatu == "运行成功")
                {
                    Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                    if (imageSource == ImageSource.FromDirectory)
                        Frm_ImageTool.Instance.lbl_toolTip.Text = string.Format("运行成功，当前图像：{0}  ({1})", currentImageName, currentImageIndex + 1 + "/" + L_imagePath.Count);
                    else
                        Frm_ImageTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
                }
                else
                {
                    Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                    Frm_ImageTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
                }
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

    /// <summary>
    /// 图像来源  从相机采集 | 读取图像文件 | 读取文件夹图像
    /// </summary>
    internal enum ImageSource
    {
        FromCamera,
        FromFile,
        FromDirectory,
    }
    /// <summary>
    /// 图像拼接形式  双图像拼接（左右拼接） |  双图像拼接（上下拼接） |  四图像拼接
    /// </summary>
    internal enum PieceType
    {
        TwoImageUD,
        TwoImageLR,
        ForeImage
    }

}
