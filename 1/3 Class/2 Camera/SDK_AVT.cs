using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using AVT.VmbAPINET;
using HalconDotNet;
using ChoiceTech;
using System.Windows.Forms;

namespace VM_Pro
{
    /// <summary>
    /// AVT相机
    /// </summary>
    [Serializable]
    internal class SDK_AVT : SDK_Base
    {
        internal SDK_AVT(string cameraInfoStr)
        {
            this.cameraInfoStr = cameraInfoStr;
        }

        /// <summary>
        /// 资源锁
        /// </summary>
        private object obj = new object();

        /// <summary>
        /// 相机集合   键：相机信息字符串  值：相机对象
        /// </summary>
        private static Dictionary<string, Camera> D_cameras = new Dictionary<string, Camera>();
        /// <summary>
        /// 实例对象
        /// </summary>
        private static SDK_AVT _instance;
        public static SDK_AVT Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SDK_AVT(string.Empty);
                return _instance;
            }
        }


        /// <summary>
        /// 枚举相机
        /// </summary>
        /// <returns>是否成功</returns>
        internal override bool EnumCamera()
        {
            Vimba sys = new Vimba();
            CameraCollection cameras = null;
            sys.Startup();
            cameras = sys.Cameras;

            for (int i = 0; i < cameras.Count; i++)
            {
                string adapterName = cameras[i].InterfaceID;
                string sn = cameras[i].SerialNumber;
                string friendlyName = cameras[i].Model;
                string vendorName = "Allied";

                if (vendorName != "Allied")     //相应品牌的SDK只允许识别对应品牌的相机，否则采图时会出错
                    continue;

                string cameraInfoStr = string.Format(" {0} | {1} | {2} | {3}", adapterName, sn, friendlyName, vendorName);

                try
                {
                    cameras[i].Open(VmbAccessModeType.VmbAccessModeFull);
                }
                catch
                {
                    FuncLib.ShowMsg(string.Format("AVT相机 {0} 初始化失败！相机信息：{1}", i + 1, cameraInfoStr), InfoType.Error);
                    FuncLib.ShowMessageBox(string.Format("AVT相机 {0} 初始化失败！相机信息：{1} \r\n        可能原因 : 1、 其它程序已经占用了此相机", i + 1, cameraInfoStr), InfoType.Error);
                    continue;
                }

                //临时添加，相机分辨率变了的时候要改一下
                try
                {
                    FeatureCollection features = null;
                    Feature feature = null;
                    features = cameras[i].Features;
                    feature = features["Width"];
                    feature.IntValue = 4112;
                    feature = features["Height"];
                    feature.IntValue = 2176;
                }
                catch { }

                Frm_Welcome.ShowStep(string.Format("初始化 AVT 相机 {0} ：{1}", i + 1, cameraInfoStr));

                SDK_AVT sdk_AVT = new SDK_AVT(cameraInfoStr);
                L_SDKCamera.Add(sdk_AVT);

                D_cameras.Add(cameraInfoStr, cameras[i]);
                Frm_Camera.Instance.cbx_cameraList.Items.Add(cameraInfoStr);
            }
            return true;
        }
        /// <summary>
        /// 抓取一张图像
        /// </summary>
        /// <returns>图像</returns>
        internal override HObject GrabOneImage(string cameraName)
        {
            lock (obj)
            {
                HObject image = null;
                foreach (KeyValuePair<string, Camera> item in D_cameras)
                {
                    if (item.Key == cameraInfoStr)
                    {
                        try
                        {
                            item.Value.Features["GVSPAdjustPacketSize"].RunCommand();
                            while (false == item.Value.Features["GVSPAdjustPacketSize"].IsCommandDone()) { }
                        }
                        catch { }

                        Frame frame = null;
                        do
                        {
                            try
                            {
                                AdjustPixelFormat(item.Value);
                                item.Value.AcquireSingleImage(ref frame, 5000);
                            }
                            catch
                            {
                                FuncLib.ShowMessageBox(string.Format("采集图像失败，请检查！相机：{0}\r\n        可能原因 : 1、 相机已掉线\r\n                         2、 网卡不是千兆网卡，带宽不够", cameraName), InfoType.Error);
                                FuncLib.ShowMsg(string.Format("采集图像失败，请检查！相机：{0}", cameraName), InfoType.Error);
                                return null;
                            }
                        }
                        while (frame.PixelFormat == 0);

                        image = ConvertFrame(frame);
                        break;
                    }
                }
                return image;
            }
        }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="exposure">曝光时间，单位：ms</param>
        internal override void SetExposure(int exposureTime, string cameraName)
        {
            foreach (KeyValuePair<string, Camera> item in D_cameras)
            {
                if (item.Key == cameraInfoStr)
                {
                    FeatureCollection features = null;
                    Feature feature = null;
                    features = item.Value.Features;
                    feature = features["ExposureTimeAbs"];
                    feature.FloatValue = exposureTime * 1000;
                    return;
                }
            }
        }
        /// <summary>
        /// 设置增益
        /// </summary>
        /// <param name="gain">增益</param>
        internal override void SetGain(int  gain, string cameraName)
        {
            foreach (KeyValuePair<string, Camera> item in D_cameras)
            {
                if (item.Key == cameraInfoStr)
                {
                    try
                    {
                        FeatureCollection features = null;
                        Feature feature = null;
                        features = item.Value.Features;
                        feature = features["Gain"];
                        feature.FloatValue = gain;
                    }
                    catch
                    {
                        FuncLib.ShowMessageBox(string.Format("设置增益失败，请检查！相机：{0}\r\n        可能原因 : 1、 数值超限", cameraName), InfoType.Error);
                        FuncLib.ShowMsg(string.Format("设置增益失败，请检查！相机：{0}", cameraName), InfoType.Error);
                    }
                    return;
                }
            }
        }
        /// <summary>
        /// 设置采集模式
        /// </summary>
        /// <param name="mode">0=连续采集，即异步采集  1=单次采集，即同步采集</param>
        internal override void SetAcquisitionMode(int mode)
        {
            foreach (KeyValuePair<string, Camera> item in D_cameras)
            {
                if (item.Key == cameraInfoStr)
                {
                    //待完善

                    return;
                }
            }
        }
        /// <summary>
        /// 设置采集图像的ROI
        /// </summary>
        internal override void SetAcqRegion(int offsetV, int offsetH, int imageH, int imageW, string cameraName)
        {
            foreach (KeyValuePair<string, Camera> item in D_cameras)
            {
                if (item.Key == cameraInfoStr)
                {
                    try
                    {
                        FeatureCollection features = null;
                        Feature feature = null;
                        features = item.Value.Features;

                        feature = features["OffsetX"];
                        feature.IntValue = offsetH;
                        feature = features["OffsetY"];
                        feature.IntValue = offsetV;

                        feature = features["Width"];
                        feature.IntValue = imageW;
                        feature = features["Height"];
                        feature.IntValue = imageH;
                    }
                    catch
                    {
                        FuncLib.ShowMessageBox(string.Format("设置采集区域失败，请检查！相机信息：{0}\r\n        可能原因 : 1、 区域信息不合法", cameraName), InfoType.Error);
                        FuncLib.ShowMsg(string.Format("设置采集区域失败，请检查！相机信息：{0}", cameraName), InfoType.Error);
                    }
                    return;
                }
            }
        }
        /// <summary>
        /// 关闭所有相机
        /// </summary>
        internal override void CloseAll()
        {
            foreach (KeyValuePair<string, Camera> item in D_cameras)
            {
                item.Value.Close();
            }
        }
        /// <summary>
        /// 图像格式转换
        /// </summary>
        /// <param name="camera"></param>
        private void AdjustPixelFormat(Camera camera)
        {
            if (null == camera)
            {
                throw new ArgumentNullException("camera");
            }

            string[] supportedPixelFormats = new string[] { "BGR8Packed", "Mono8" };
            //Check for compatible pixel format
            Feature pixelFormatFeature = camera.Features["PixelFormat"];

            //Determine current pixel format
            string currentPixelFormat = pixelFormatFeature.EnumValue;

            //Check if current pixel format is supported
            bool currentPixelFormatSupported = false;
            foreach (string supportedPixelFormat in supportedPixelFormats)
            {
                if (string.Compare(currentPixelFormat, supportedPixelFormat, StringComparison.Ordinal) == 0)
                {
                    currentPixelFormatSupported = true;
                    break;
                }
            }

            //Only adjust pixel format if we not already have a compatible one.
            if (false == currentPixelFormatSupported)
            {
                //Determine available pixel formats
                string[] availablePixelFormats = pixelFormatFeature.EnumValues;

                //Check if there is a supported pixel format
                bool pixelFormatSet = false;
                foreach (string supportedPixelFormat in supportedPixelFormats)
                {
                    foreach (string availablePixelFormat in availablePixelFormats)
                    {
                        if ((string.Compare(supportedPixelFormat, availablePixelFormat, StringComparison.Ordinal) == 0)
                            && (pixelFormatFeature.IsEnumValueAvailable(supportedPixelFormat) == true))
                        {
                            //Set the found pixel format
                            pixelFormatFeature.EnumValue = supportedPixelFormat;
                            pixelFormatSet = true;
                            break;
                        }
                    }

                    if (true == pixelFormatSet)
                    {
                        break;
                    }
                }

                if (false == pixelFormatSet)
                {
                    throw new Exception("None of the pixel formats that are supported by this example (Mono8 and BRG8Packed) can be set in the camera.");
                }
            }
        }
        /// <summary>
        /// 帧转换
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        private static HObject ConvertFrame(Frame frame)
        {
            Bitmap image = null;
            try
            {
                switch (frame.PixelFormat)
                {
                    case VmbPixelFormatType.VmbPixelFormatMono8:
                        {
                            Bitmap bitmap = new Bitmap((int)frame.Width, (int)frame.Height, PixelFormat.Format8bppIndexed);

                            //Set greyscale palette
                            ColorPalette palette = bitmap.Palette;
                            for (int i = 0; i < palette.Entries.Length; i++)
                            {
                                palette.Entries[i] = Color.FromArgb(i, i, i);
                            }
                            bitmap.Palette = palette;

                            //Copy image data
                            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0,
                                                                                        0,
                                                                                        (int)frame.Width,
                                                                                        (int)frame.Height),
                                                                        ImageLockMode.WriteOnly,
                                                                        PixelFormat.Format8bppIndexed);
                            try
                            {
                                //Copy image data line by line
                                for (int y = 0; y < (int)frame.Height; y++)
                                {
                                    System.Runtime.InteropServices.Marshal.Copy(frame.Buffer,
                                                                                    y * (int)frame.Width,
                                                                                    new IntPtr(bitmapData.Scan0.ToInt64() + y * bitmapData.Stride),
                                                                                    (int)frame.Width);
                                }
                            }
                            finally
                            {
                                bitmap.UnlockBits(bitmapData);
                            }

                            image = bitmap;
                        }
                        break;

                    case VmbPixelFormatType.VmbPixelFormatBgr8:
                        {
                            Bitmap bitmap = new Bitmap((int)frame.Width, (int)frame.Height, PixelFormat.Format24bppRgb);

                            //Copy image data
                            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0,
                                                                                        0,
                                                                                        (int)frame.Width,
                                                                                        (int)frame.Height),
                                                                        ImageLockMode.WriteOnly,
                                                                        PixelFormat.Format24bppRgb);
                            try
                            {
                                //Copy image data line by line
                                for (int y = 0; y < (int)frame.Height; y++)
                                {
                                    System.Runtime.InteropServices.Marshal.Copy(frame.Buffer,
                                                                                    y * ((int)frame.Width) * 3,
                                                                                    new IntPtr(bitmapData.Scan0.ToInt64() + y * bitmapData.Stride),
                                                                                    ((int)(frame.Width) * 3));
                                }
                            }
                            finally
                            {
                                bitmap.UnlockBits(bitmapData);
                            }

                            image = bitmap;
                        }
                        break;

                    default:
                        throw new Exception("Current pixel format is not supported by this example (only Mono8 and BRG8Packed are supported).");
                }
            }
            catch { }

            HObject image1 = null;

            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData srcBmpData = image.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            HOperatorSet.GenImageInterleaved(out image1, srcBmpData.Scan0, "bgr", image.Width, image.Height, 0, "byte", 0, 0, 0, 0, -1, 0);
            image.UnlockBits(srcBmpData);

            return image1;
        }

    }
}
