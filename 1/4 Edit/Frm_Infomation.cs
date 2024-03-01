using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Frm_Infomation : UIPage
    {
        public Frm_Infomation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Infomation _instance;
        internal static Frm_Infomation Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Infomation();
                return _instance;
            }
        }

        private void btn_loginTest_Click(object sender, EventArgs e)
        {
            Frm_Loading.Instance.lbl_title.Text = "拼命加载中";
            Frm_Loading.Instance.TopLevel = true;
            Frm_Loading.Instance.TopMost = true;
            Frm_Loading.Instance.Show();

            Thread th = new Thread(() =>
           {
               //////if (MainTask.mes == null)
               //////    MainTask.mes = new ServiceReference1.MESInterfaceSoapClient();

               //////string rtn = MainTask.mes.CheckUserDo(Project.Instance.configuration.MESUserName, Project.Instance.configuration.MESPassword, Project.Instance.configuration.MESMachineNo);
               //////if (rtn.Length >= 4 && rtn.Substring(0, 4) == "TRUE")
               //////{
               //////    Project.mesLoginOK = true;
               //////    FuncLib.ShowMessageBox("登录成功！MES连接正常", InfoType.Tip);
               //////}
               //////else
               //////{
               //////    Project.mesLoginErrr = rtn;
               //////    Project.mesLoginOK = false;
               //////    FuncLib.ShowMsg("MES登录失败，请联系MES或AE人员处理！MES返回值为：" + rtn, InfoType.Error);
               //////    FuncLib.ShowMessageBox("MES登录失败", InfoType.Error);
               //////}
               Frm_Loading.Instance.Hide();
           });
            th.IsBackground = true;
            th.Start();
        }
        private void btn_clearCount_Click(object sender, EventArgs e)
        {
            if (UIMessageBox.ShowAsk("请确定是否将当前产量清零"))
            {
                Project.Instance.configuration.totalNum = 0;
                Project.Instance.configuration.OKNum = 0;
                Project.Instance.configuration.NGNum = 0;

                lbl_totalNum.Text = "0";
                lbl_okNum.Text = "0";
                lbl_ngNum.Text = "0";
                lbl_yield.Text = "100%";

                Project.SaveSysPar();
            }

        }
        private void btn_browseHistory_Click(object sender, EventArgs e)
        {
            Frm_ProductCount.Instance.ShowDialog();
        }

        private void ckb_StartUpload_Click(object sender, EventArgs e)
        {
            Project.Instance.configuration.projectCfg.isStartBuMa = ckb_StartUpload.Checked;
            tm_Upload.Enabled = ckb_StartUpload.Checked;
            tm_Upload.Interval = 1000;
            _isChangeInterval = true;
        }

        private void txt_UploadTime_TextChanged(object sender, EventArgs e)
        {
            if (txt_UploadTime.Focused && txt_UploadTime.Text != "")
            {
                Project.Instance.configuration.projectCfg.UploadTime = Convert.ToInt32(txt_UploadTime.Text.Trim());
                tm_Upload.Interval = Project.Instance.configuration.projectCfg.UploadTime * 1000 * 60;
            }

        }

        private void txt_NGOverrunNum_TextChanged(object sender, EventArgs e)
        {
            Project.Instance.configuration.projectCfg.NGOverrunNum = Convert.ToInt32(txt_NGOverrunNum.Text.Trim());
        }

        private void Frm_Infomation_Load(object sender, EventArgs e)
        {
            Frm_Infomation.Instance.lbl_totalNum.Text = Project.Instance.configuration.totalNum.ToString();
            Frm_Infomation.Instance.lbl_ngNum.Text = Project.Instance.configuration.NGNum.ToString();
            Frm_Infomation.Instance.lbl_okNum.Text = Project.Instance.configuration.OKNum.ToString();
            Frm_Infomation.Instance.lbl_yield.Text = Math.Round((Project.Instance.configuration.OKNum / (Project.Instance.configuration.totalNum * 0.01)), 2).ToString() + "%";
            Frm_Infomation.Instance.tm_Upload.Enabled = Frm_Infomation.Instance.ckb_StartUpload.Checked = Project.Instance.configuration.projectCfg.isStartBuMa;
            Frm_Infomation.Instance.ckb_StartTaskCheckout.Checked = Project.Instance.configuration.projectCfg.isStartTaskCheckout;
            Frm_Infomation.Instance.txt_UploadTime.Text = Project.Instance.configuration.projectCfg.UploadTime.ToString();
            Frm_Infomation.Instance.txt_NGOverrunNum.Text = Project.Instance.configuration.projectCfg.NGOverrunNum.ToString();
        }
        private bool _isChangeInterval = true;
        /// <summary>
        /// 本次补传后的NG数
        /// </summary>
        internal int curNGOverrunNum = 0;
        /// <summary>
        /// 是否为最后一次补传，该标志作为发送NG超限的标志
        /// </summary>
        internal bool isLastUpload = false;
        private void tm_Upload_Tick(object sender, EventArgs e)
        {
            DateTime dtNowTime = DateTime.Now;
            if (_isChangeInterval)   //校验补传时间
            {
                tm_Upload.Interval = Project.Instance.configuration.projectCfg.UploadTime * 1000 * 60;
                _isChangeInterval = false;
                tm_Upload.Enabled = Project.Instance.configuration.projectCfg.isStartBuMa;
            }
            try
            {
                FuncLib.ShowMsg("当前触发补传时间：" + dtNowTime.ToString());
                List<string> lstAllNGPath = new List<string>();

                #region 读取文件夹的NG图片

                //当前跨天了，且需要上传昨天的部分图片，那么先读取昨天所有NG图
                if ((dtNowTime - dtNowTime.Date).TotalMinutes < Project.Instance.configuration.projectCfg.UploadTime)
                {
                    //上相机图片
                    try
                    {
                        string yesterdayPath = string.Format("{0}\\{1}\\{2}\\{3}\\Image\\上相机\\存储图像\\NG\\",
                                                               Project.Instance.configuration.dataPath,
                                                               dtNowTime.ToString("yyyy"),
                                                               dtNowTime.ToString("MMMM"),
                                                               dtNowTime.AddDays(-1).ToString("yyyy_MM_dd"));
                        string[] yesterdayFiles = Directory.GetFiles(yesterdayPath);
                        for (int i = 0; i < yesterdayFiles.Length; i++)
                        {
                            FileInfo fileInfo = new FileInfo(yesterdayFiles[i]);
                            if (fileInfo.Extension == ".jpg" ||
                                fileInfo.Extension == ".png" ||
                                fileInfo.Extension == ".PNG" ||
                                fileInfo.Extension == ".bmp" ||
                                fileInfo.Extension == ".tif")
                            {
                                lstAllNGPath.Add(yesterdayFiles[i]);
                            }
                        }
                    }
                    catch
                    {
                    }
                    //下相机图片
                    try
                    {
                        string yesterdayPath = string.Format("{0}\\{1}\\{2}\\{3}\\Image\\下相机\\存储图像\\NG\\",
                                                               Project.Instance.configuration.dataPath,
                                                               dtNowTime.ToString("yyyy"),
                                                               dtNowTime.ToString("MMMM"),
                                                               dtNowTime.AddDays(-1).ToString("yyyy_MM_dd"));
                        string[] yesterdayFiles = Directory.GetFiles(yesterdayPath);
                        for (int i = 0; i < yesterdayFiles.Length; i++)
                        {
                            FileInfo fileInfo = new FileInfo(yesterdayFiles[i]);
                            if (fileInfo.Extension == ".jpg" ||
                                fileInfo.Extension == ".png" ||
                                fileInfo.Extension == ".PNG" ||
                                fileInfo.Extension == ".bmp" ||
                                fileInfo.Extension == ".tif")
                            {
                                lstAllNGPath.Add(yesterdayFiles[i]);
                            }
                        }
                    }
                    catch
                    {
                    }
                }

                //上相机当天文件夹图片
                try
                {
                    string path = string.Format("{0}\\{1}\\{2}\\{3}\\Image\\上相机\\存储图像\\NG\\",
                                            Project.Instance.configuration.dataPath,
                                            dtNowTime.ToString("yyyy"),
                                            dtNowTime.ToString("MMMM"),
                                            dtNowTime.ToString("yyyy_MM_dd"));
                    string[] files = Directory.GetFiles(path);
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo fileInfo = new FileInfo(files[i]);
                        if (fileInfo.Extension == ".jpg" ||
                            fileInfo.Extension == ".png" ||
                            fileInfo.Extension == ".PNG" ||
                            fileInfo.Extension == ".bmp" ||
                            fileInfo.Extension == ".tif")
                        {
                            lstAllNGPath.Add(files[i]);
                        }
                    }
                }
                catch
                {
                }

                //下相机当天文件夹图片
                try
                {
                    string path = string.Format("{0}\\{1}\\{2}\\{3}\\Image\\下相机\\存储图像\\NG\\",
                                            Project.Instance.configuration.dataPath,
                                            dtNowTime.ToString("yyyy"),
                                            dtNowTime.ToString("MMMM"),
                                            dtNowTime.ToString("yyyy_MM_dd"));
                    string[] files = Directory.GetFiles(path);
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo fileInfo = new FileInfo(files[i]);
                        if (fileInfo.Extension == ".jpg" ||
                            fileInfo.Extension == ".png" ||
                            fileInfo.Extension == ".PNG" ||
                            fileInfo.Extension == ".bmp" ||
                            fileInfo.Extension == ".tif")
                        {
                            lstAllNGPath.Add(files[i]);
                        }
                    }
                }
                catch
                {
                }
                #endregion

                if (lstAllNGPath.Count < 0)   //没有NG图片则直接结束
                {
                    return;
                }

                List<string> delAfterLst = new List<string>();
                //过滤掉一些不符合该时间段上传的图片
                for (int i = 0; i < lstAllNGPath.Count; i++)
                {
                    try
                    {
                        DateTime dt1 = strToDateTime(lstAllNGPath[i].Substring(lstAllNGPath[i].LastIndexOf('\\') + 1, 16));
                        TimeSpan ts = DateTime.Now - dt1;
                        if (ts.TotalMinutes < Project.Instance.configuration.projectCfg.UploadTime)
                        {
                            delAfterLst.Add(lstAllNGPath[i]);
                        }
                    }
                    catch   //说明转换异常，为防止漏传，则默认补上
                    {
                        delAfterLst.Add(lstAllNGPath[i]);
                    }
                }
                lstAllNGPath.Clear();
                curNGOverrunNum = 0;
                isLastUpload = false;
                ((ImageTool)(Task.FindTaskByName("补传").FindToolByName("采集图像"))).imageSource = ImageSource.FromFile;
                Thread th = new Thread(() =>
                {
                    for (int i = 0; i < delAfterLst.Count; i++)
                    {
                        ((ImageTool)(Task.FindTaskByName("补传").FindToolByName("采集图像"))).imagePath = delAfterLst[i];
                        if (i == delAfterLst.Count - 1) //置位标志位，目的是进一步看是否需要回复NG超限
                        {
                            isLastUpload = true;
                        }
                        Task.FindTaskByName("补传").Run();
                    }
                });
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception ex)
            {
                FuncLib.ShowMsg("定时器异常：" + ex.Message);
            }

        }



        /// <summary>
        /// 将日期字符串转化为日期：2023033108342055，注意转换失败会抛出异常
        /// </summary>
        /// <param name="strdate">格式：yyyyMMddHHmmssff</param>
        /// <returns></returns>
        private DateTime strToDateTime(string strdate)
        {
            try
            {
                DateTime dt = new DateTime();
                if (strdate != "" && strdate.Length > 14)
                {
                    dt = new DateTime(Convert.ToInt32(strdate.Substring(0, 4)),
                        Convert.ToInt32(strdate.Substring(4, 2)),
                        Convert.ToInt32(strdate.Substring(6, 2)),
                        Convert.ToInt32(strdate.Substring(8, 2)),
                        Convert.ToInt32(strdate.Substring(10, 2)),
                        Convert.ToInt32(strdate.Substring(12, 2)));
                }
                else
                {
                    throw new Exception("输入字符串异常");
                }
                return dt;
            }
            catch
            {
                throw;
            }

        }

        private void ckb_StartTaskCheckout_Click(object sender, EventArgs e)
        {
            Project.Instance.configuration.projectCfg.isStartTaskCheckout = ckb_StartTaskCheckout.Checked;
        }
    }
}
