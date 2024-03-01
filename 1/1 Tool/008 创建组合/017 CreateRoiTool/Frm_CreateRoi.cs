using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using HalconDotNet;

namespace VM_Pro
{
    public partial class Frm_CreateRoi : UIForm
    {
        public Frm_CreateRoi()
        {
            InitializeComponent();
        }

        #region 单例模式

        private static Frm_CreateRoi _instance;

        internal static Frm_CreateRoi Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_CreateRoi();
                return _instance;
            }
        }

        #endregion

        /// <summary>
        /// 是否正在运行
        /// </summary>
        internal bool isRunning = false;
        /// <summary>
        /// 是否启用事件，也就是不执行本次触发的事件
        /// </summary>
        internal static bool openingForm = false;
        /// <summary>
        /// 当前工具名
        /// </summary>
        internal static string toolName = string.Empty;
        /// <summary>
        /// 当前工具所属的流程
        /// </summary>
        internal static string taskName = string.Empty;
        /// <summary>
        /// 窗体是否已显示
        /// </summary>
        internal static bool hasShown = false;
        /// <summary>
        /// 工具对象
        /// </summary>
        internal static CreateRoiTool createROITool;
        /// <summary>
        /// 正在抓图的话就放弃再次抓图
        /// </summary>
        private static bool isGrabing = false;



        /// <summary>
        /// 弹出工具页面
        /// </summary>
        /// <param name="toolBase">工具</param>
        internal static void ShowForm(ToolBase toolBase)
        {
            if (hasShown && taskName == toolBase.taskName && toolName == toolBase.toolName)     //如果当前工具已显示或者最小化了，那就直接显示即可
            {
                Instance.WindowState = FormWindowState.Normal;
                Instance.Activate();
                return;
            }

            openingForm = true;
            Instance.Text = string.Format("{0}    [ {1} . {2} ]", toolBase.toolType, toolBase.taskName, toolBase.toolName);
            createROITool = (CreateRoiTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            Instance.WindowState = FormWindowState.Normal;

            try
            {
                Instance.Show();    //有时会出现创建句柄异常的现象，那么则释放其对象，重新创建一个
            }
            catch (Exception)
            {
                Instance.Close();
                _instance = null;
                UIMessageTip.ShowError("打开工具界面异常，请稍后重试...");
                return;
            }

            hasShown = true;
            createROITool.UpdateInput();
            double ImgWidth=200, ImgHeight=200;
            //显示图像 
            if (((CreateRoiTool.ToolPar)createROITool.参数).输入.图像 != null)
            {
                Instance.hWindow_Final1.ClearWindow();
                Instance.hWindow_Final1.HobjectToHimage(((CreateRoiTool.ToolPar)createROITool.参数).输入.图像);
                HOperatorSet.GetImageSize(((CreateRoiTool.ToolPar)createROITool.参数).输入.图像, out HTuple width, out HTuple height);
                ImgWidth = width.D;
                ImgHeight = height.D;
            }
            Instance.ckb_taskFailKeepRun.Checked = createROITool.taskFailKeepRun;
            Instance.ckb_RegionResult.Checked = createROITool.ShowResultRegionToMain;
            if (createROITool.IsGuDingRegion)
            {
                Instance.Rdb_GuDing.Checked = true;
                Instance.panel_LianRu.Visible = false;

                //if ( createROITool.L_regions ==null || createROITool.L_regions.Count == 0)
                //{
                //    Instance.cbx_searchRegionType.Text = "矩形";
                //    createROITool.searchRegionType = RegionType.矩形;
                //    Instance.hWindow_Final1.viewWindow.genRect1(1, 1, ImgWidth/2, ImgHeight/2, ref createROITool.L_regions);
                //}
                Instance.cbx_searchRegionType.Text = createROITool.searchRegionType.ToString();
                Instance.cbx_searchRegionType.Enabled = true;
            }
            else
            {
                Instance.panel_LianRu.Visible = true;
                for (int i = 0; i < createROITool.L_inputItem.Count; i++)
                {
                    if (createROITool.L_inputItem[i].inputType == DataType.ListXYU)
                    {
                        Instance.txt_LianRu.Text = createROITool.L_inputItem[i].sourceTool + ".位置";
                        break;
                    }
                }
                Instance.MoBanPanel.Visible = true;
                Instance.Rdb_MoBan.Checked = true;
                Instance.cbx_searchRegionType.Text = "仿射矩形";
                if (createROITool.MoBanFeaturePoint != null)
                {
                    Instance.lb_MoBanDian.Text = createROITool.MoBanFeaturePoint.XY.X.ToString("F3") + "，" + createROITool.MoBanFeaturePoint.XY.Y.ToString("F3");
                    Instance.lb_MoBanAngle.Text = createROITool.MoBanFeaturePoint.U.ToString("F3");
                }
            }

            if (createROITool.L_regions!=null && createROITool.L_regions.Count >0)
            {
                //Frm_CreateRoi.Instance.hWindow_Final1.viewWindow.displayROI(createROITool.L_regions);
                Frm_CreateRoi.Instance.hWindow_Final1.DispObj(createROITool.L_regions[0].getRegion(),"green");
                //Frm_CreateRoi.Instance.hWindow_Final1.viewWindow.d
            }
            Thread th1 = new Thread(() =>
            {
                createROITool.Run();
            });
            th1.IsBackground = true;
            th1.Start();

            openingForm = false;


        }

        /// <summary>
        /// 关闭当前工具窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        /// <summary>
        /// 运行当前工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_runTool_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                Thread th = new Thread(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        Frm_Loading.Instance.lbl_title.Text = "拼命加载中";
                        Frm_Loading.Instance.TopLevel = true;
                        Frm_Loading.Instance.TopMost = true;
                        Frm_Loading.Instance.Show();
                    }));

                    isRunning = true;
                    createROITool.Run();
                    isRunning = false;

                    Thread.Sleep(100);
                    Frm_Loading.Instance.Hide();
                });
                th.IsBackground = true;
                th.Start();
            }
        }

        /// <summary>
        /// 运行当前工具所在的任务流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_runTask_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Task.FindTaskByName(taskName).Run();
            });
            th.IsBackground = true;
            th.Start();
        }

        private void Frm_CreateRoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

        private void cbx_searchRegionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (openingForm)
                return;

            RegionType regionType = (RegionType)Enum.Parse(typeof(RegionType), cbx_searchRegionType.Text);
            createROITool.SwitchSearchRegionType(regionType);
        }

        private void Rdb_GuDing_Click(object sender, EventArgs e)
        {
            Instance.cbx_searchRegionType.Enabled = true;
            Instance.MoBanPanel.Visible = false;
            createROITool.IsGuDingRegion = true;
            cbx_searchRegionType_SelectedIndexChanged(null, null);
        }
        


        private void btnJiSuan_Click(object sender, EventArgs e)
        {
            //XYU xxyu = ((CreateRoiTool.ToolPar)createROITool.参数).输入.位置[0];

            ////求出做模板时的特征点，与当前模板特征点的仿射变换关系
            //HOperatorSet.VectorAngleToRigid(R1, C1, A1, xxyu.XY.X, xxyu.XY.Y, -xxyu.U, out HTuple hom2d);
            ////让跟随区域随着当前的仿射变换关系进行变换，即可得到跟随区域
            //HOperatorSet.AffineTransRegion(createROITool.L_regions[0].getRegion(), out HObject affineRegion, hom2d, "nearest_neighbor");
            //Frm_CreateRoi.Instance.hWindow_Final1.DispObj(affineRegion, "blue");

            createROITool.MoBanFeaturePoint = ((CreateRoiTool.ToolPar)createROITool.参数).输入.位置[0];
            Instance.lb_MoBanDian.Text = createROITool.MoBanFeaturePoint.XY.X.ToString("F3") + "，" + createROITool.MoBanFeaturePoint.XY.Y.ToString("F3");
            Instance.lb_MoBanAngle.Text = createROITool.MoBanFeaturePoint.U.ToString("F3");
            Thread th1 = new Thread(() =>
            {
                createROITool.Run();
            });
            th1.IsBackground = true;
            th1.Start();

        }

        private void Rdb_MoBan_Click(object sender, EventArgs e)
        {
            //此处应该有一个操作，如果当前没有输入位置的话，则应该去扫描一下是否可以有输入，如果有的话，则给个默认
            if (((CreateRoiTool.ToolPar)createROITool.参数).输入.位置 == null || ((CreateRoiTool.ToolPar)createROITool.参数).输入.位置.Count == 0)
            {
                ImgBtn_LianRu_Click(null, null);
            }



            //判断当前是否有模板特征点输入，若没有的话，则不允许进行切换
            if (((CreateRoiTool.ToolPar)createROITool.参数).输入.位置.Count > 0)
            {
                Instance.panel_LianRu.Visible = true;
                Instance.cbx_searchRegionType.Enabled = false;
                Instance.cbx_searchRegionType.Text = "仿射矩形";
                Instance.MoBanPanel.Visible = true;
                createROITool.IsGuDingRegion = false;
                cbx_searchRegionType_SelectedIndexChanged(null, null);
                
            }
            else
            {
                Rdb_GuDing.Checked = true;
                UIMessageTip.ShowError("当前未检测到有模板匹配特征点输入，请检查流程任务...");
                Rdb_GuDing_Click(null, null);
                return;
            }

        }

        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_CreateRoi.openingForm)
                return;

            createROITool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }

        private void ckb_RegionResult_Click(object sender, EventArgs e)
        {
            createROITool.ShowResultRegionToMain = ckb_RegionResult.Checked;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FuncLib.ShowTooLHelp(createROITool.toolType);
        }

        private void ImgBtn_LianRu_Click(object sender, EventArgs e)
        {
            FrmBianLiang frm = new FrmBianLiang(toolName);
            frm.TagString = "区域";
            frm.ShowNavNodes(createROITool.LianRuToolNames(DataType.Region));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_LianRu.Text = FrmBianLiang.currentLianRuInfo;
                UIMessageTip.ShowWarning("正在切换区域中，请稍候..");
                createROITool.UpdateInput();
                Thread th1 = new Thread(() =>
                {
                    createROITool.Run();
                });
                th1.IsBackground = true;
                th1.Start();
                //更新当前输入项
            }
        }
    }
}
