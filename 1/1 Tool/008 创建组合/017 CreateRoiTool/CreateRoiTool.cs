using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewWindow.Model;

namespace VM_Pro
{
    [Serializable]
    internal class CreateRoiTool : ToolBase
    {
        internal CreateRoiTool(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;
            L_OutItemType = new List<DataType> { DataType.Region };

            //自动链接输入
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
                    continue;
                    //break;
                }

                //////模板匹配的输出点

                ////if (Task.curTask.L_toolList[i].toolType == ToolType.模板匹配)
                ////{
                ////    InputItem inputItem = new InputItem();
                ////    inputItem.InputName = "位置";
                ////    inputItem.inputType = DataType.ListXYU;
                ////    inputItem.sourceTask = taskName;
                ////    inputItem.sourceTool = Task.curTask.L_toolList[i].toolName;
                ////    inputItem.sourceOutput = "位置";

                ////    L_inputItem.Add(inputItem);
                ////    continue;
                ////    //break;
                ////}
            }


        }


        /// <summary>
        /// True：固定区域类型 False：跟随模板区域类型
        /// </summary>
        internal bool IsGuDingRegion = true;

        /// <summary>
        /// 搜索区域类型
        /// </summary>
        internal RegionType searchRegionType = RegionType.整幅图像;

        /// <summary>
        /// 搜索区域
        /// </summary>
        internal List<ROI> L_regions = new List<ROI>();

        /// <summary>
        /// 选择跟随模板模式的话，需记录做模板时的特征点坐标
        /// </summary>
        internal XYU MoBanFeaturePoint = new XYU();

        /// <summary>
        /// 是否将获取到的区域信息显示到主窗体当中
        /// </summary>
        internal bool ShowResultRegionToMain = true;

        [NonSerialized]
        HObject affineRegion = null;

        /// <summary>
        /// 运行工具
        /// </summary>
        /// <param name="updateImage">是否刷新图像</param>
        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
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
            try
            {
                if (IsGuDingRegion) //固定区域
                {
                    if (L_regions.Count ==0)    //全图
                    {
                         HOperatorSet.GetDomain(((CreateRoiTool.ToolPar)参数).输入.图像, out affineRegion);
                    }
                    else
                    {
                        affineRegion = L_regions[0].getRegion();
                    }
                }
                else    //跟随区域
                {
                    if (((ToolPar)参数).输入 == null || ((ToolPar)参数).输入.位置.Count <= 0)
                    {
                        toolRunStatu = "未检测到特征点输入";
                        goto Exit;
                    }
                    XYU CurrentMoBanDian = ((ToolPar)参数).输入.位置[0];
                    //求出做模板时的特征点，与当前模板特征点的仿射变换关系
                    HOperatorSet.VectorAngleToRigid(MoBanFeaturePoint.XY.X, MoBanFeaturePoint.XY.Y, MoBanFeaturePoint.U, CurrentMoBanDian.XY.X, CurrentMoBanDian.XY.Y, CurrentMoBanDian.U, out HTuple hom2d);
                    //让跟随区域随着当前的仿射变换关系进行变换，即可得到跟随区域
                    HOperatorSet.AffineTransRegion(L_regions[0].getRegion(), out affineRegion, hom2d, "nearest_neighbor");
                }
            }
            catch (Exception ex)
            {
                toolRunStatu = "运行异常：" + ex.Message;
                FuncLib.ShowMsg("工具-" + toolName + "-运行出现异常-" + ex.Message, InfoType.Error);
                goto Exit;
            }
            ((ToolPar)参数).输出.区域 = affineRegion;
            toolRunStatu = "运行成功";
            sw.Stop();
        Exit:
            //当前工具窗体打开运行更新项
            if (Frm_CreateRoi.hasShown && Frm_CreateRoi.taskName == taskName && Frm_CreateRoi.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_CreateRoi.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());
                Frm_CreateRoi.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
                Frm_CreateRoi.Instance.hWindow_Final1.viewWindow.displayImage(((ToolPar)参数).输入.图像);
                Frm_CreateRoi.Instance.hWindow_Final1.DispObj(((ToolPar)参数).输出.区域, "blue");
                if (toolRunStatu == "运行成功")
                {
                    Frm_CreateRoi.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                    HalconLib.DispText(Frm_CreateRoi.Instance.hWindow_Final1.HWindowHalconID, "OK", 20, 200, 200, "green", "false");
                }
                else
                {
                    Frm_CreateRoi.Instance.lbl_toolTip.ForeColor = Color.Red;
                    HalconLib.DispText(Frm_CreateRoi.Instance.hWindow_Final1.HWindowHalconID, "NG", 20, 100, 100, "red", "false");
                }
                if (!IsGuDingRegion && ((ToolPar)参数).输入.位置.Count > 0)
                {
                    Frm_CreateRoi.Instance.lb_CurrentMoBanPoint.Text = ((ToolPar)参数).输入.位置[0].XY.X.ToString("F3") + "，" + ((ToolPar)参数).输入.位置[0].XY.Y.ToString("F3");
                    Frm_CreateRoi.Instance.lb_CurrentMoBanAngle.Text = ((ToolPar)参数).输入.位置[0].U.ToString("F3");
                }
            }
            if (ShowResultRegionToMain)
            {
                DispObj(((ToolPar)参数).输出.区域, "blue");
            }
        }


        /// <summary>
        /// 切换搜索区域
        /// </summary>
        internal void SwitchSearchRegionType(RegionType regionType)
        {
            if (((ToolPar)参数).输入.图像 != null)
                Frm_CreateRoi.Instance.hWindow_Final1.HobjectToHimage(((ToolPar)参数).输入.图像);


            HOperatorSet.SetLineStyle(Frm_CreateRoi.Instance.hWindow_Final1.HWindowHalconID, new HTuple());
            Frm_CreateRoi.Instance.hWindow_Final1.Select();

            HTuple width, height;
            HOperatorSet.GetImageSize(((ToolPar)参数).输入.图像, out width, out height);
            if (L_regions != null)
            {
                this.L_regions.Clear();
            }
            HalconLib.ShowRegion(Frm_CreateRoi.Instance.hWindow_Final1, regionType, height, width, ref this.L_regions);

            searchRegionType = regionType;
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
                get
                {

                    return _图像;
                }
                set
                {
                    _图像 = value;
                }
            }

            private List<XYU> _位置 = new List<XYU>();
            public List<XYU> 位置
            {
                get { return _位置; }
                set { _位置 = value; }
            }

        }
        [Serializable]
        public class P运行 { }
        [Serializable]
        internal class P输出
        {
            //private int _数量;
            //public int 数量
            //{
            //    get { return _数量; }
            //    set { _数量 = value; }
            //}

            private HObject _区域;
            public HObject 区域
            {
                get
                {

                    return _区域;
                }
                set
                {
                    _区域 = value;
                }
            }
        }
        #endregion
    }
}
