using HalconDotNet;
using SaomiaoTest2;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_Debug : UIPage
    {
        public Frm_Debug()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Debug _instance;
        internal static Frm_Debug Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Debug();
                return _instance;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<LeiBieModel> lst = new List<LeiBieModel>();
            for (int i = 0; i < DgvData.RowCount; i++)
            {
                LeiBieModel item = new LeiBieModel();
                item.LeiBie = DgvData.Rows[i].Cells[0].Value.ToString();
                item.MinArea = Convert.ToDouble(DgvData.Rows[i].Cells[1].Value);
                item.BeforArea = Convert.ToDouble(DgvData.Rows[i].Cells[2].Value);
                item.MaxArea = Convert.ToDouble(DgvData.Rows[i].Cells[3].Value);
                item.NG = Convert.ToInt32(DgvData.Rows[i].Cells[4].Value);
                item.CheckEnable = Convert.ToBoolean(DgvData.Rows[i].Cells[5].Value);
                if (i == DgvData.RowCount - 1 && item.LeiBie == "极耳")
                {
                    ((DefineTool)Task.FindTaskByName(Task.curTask.name).FindToolByName("自定义处理")).I_极耳 = item;
                }
                else
                {
                    lst.Add(item);
                }
            }
            DgvData.Enabled = false;
            Project.Instance.configuration.lstLeiBie = lst;
            UIMessageTip.ShowOk("如确认，请保存当前方案信息...");
        }

        private void 更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DgvData.Enabled = true;
        }

        private void Frm_Debug_Load(object sender, EventArgs e)
        {
            Instance.lb_OK.Text = Project.Instance.configuration.OKNum.ToString();
            Instance.lb_NG.Text = Project.Instance.configuration.NGNum.ToString();
            Instance.lb_AllNum.Text = (Project.Instance.configuration.OKNum + Project.Instance.configuration.NGNum).ToString();
            Instance.lb_Lianglv.Text = (Project.Instance.configuration.OKNum * 1.0 / (Project.Instance.configuration.OKNum + Project.Instance.configuration.NGNum) * 100).ToString("F2") + " %";
            Instance.txt_Down.Text = Project.Instance.configuration.projectCfg.DownPianYi.ToString();
            Instance.txt_Right.Text = Project.Instance.configuration.projectCfg.RightPianYi.ToString();
            Instance.txt_Left.Text = Project.Instance.configuration.projectCfg.LeftPianYi.ToString();

            Instance.ckb_Start.Checked = Project.Instance.configuration.projectCfg.Is_StartAlgo;

        }

        private void DgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void 生产清零ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == FuncLib.ShowConfirmDialog("是否清空当前生产计数", InfoType.Tip))
            {
                Project.Instance.configuration.OKNum = 0;
                Project.Instance.configuration.NGNum = 0;
                Instance.lb_OK.Text = Project.Instance.configuration.OKNum.ToString();
                Instance.lb_NG.Text = Project.Instance.configuration.NGNum.ToString();
                Instance.lb_AllNum.Text = (Project.Instance.configuration.OKNum + Project.Instance.configuration.NGNum).ToString();
                Instance.lb_Lianglv.Text = "100 %";
            }
        }

        private void ckb_ShowDefect_Click(object sender, EventArgs e)
        {
            Frm_ShowDefect.Instance.hasShown = ckb_ShowDefect.Checked;
            if (ckb_ShowDefect.Checked)
            {
                Frm_ShowDefect.Instance.TopMost = true;
                Frm_ShowDefect.Instance.Show();
            }
            else
            {
                Frm_ShowDefect.Instance.Hide();
            }
        }

        private void ckb_Start_Click(object sender, EventArgs e)
        {
            Project.Instance.configuration.projectCfg.Is_StartAlgo = ckb_Start.Checked;
        }

        private void btn_QueRen_Click(object sender, EventArgs e)
        {
            try
            {
                Project.Instance.configuration.projectCfg.DownPianYi = Convert.ToInt32(txt_Down.Text);
                Project.Instance.configuration.projectCfg.RightPianYi = Convert.ToInt32(txt_Right.Text);
                Project.Instance.configuration.projectCfg.LeftPianYi = Convert.ToInt32(txt_Left.Text);
                //获取当前图像
                HObject CurImg = ((ImageTool.ToolPar)Task.FindTaskByName("jee").FindToolByName("采集图像").参数).输出.图像;
                if (CurImg == null)
                {
                    FuncLib.ShowMessageBox("当前未检测到图像，禁止操作...", InfoType.Error);
                    return;
                }
                //找出当前极耳位置
                HOperatorSet.Threshold(CurImg, out HObject Region, 200, 255);
                HOperatorSet.Connection(Region, out Region);
                HOperatorSet.ShapeTrans(Region, out Region, "convex");
                HOperatorSet.SelectShape(Region, out Region, new HTuple("area", "height", "width","column"), "and", new HTuple(40000, 140, 250,600), new HTuple(85000, 280, 400,2000));
                HOperatorSet.CountObj(Region, out HTuple JiErnum);
                if (JiErnum.D != 1)
                {
                    FuncLib.ShowMessageBox("当前未找到极耳区域，请确认图像是否正常...");
                    return;
                }
                HOperatorSet.GenContourRegionXld(Region, out HObject XLD, "border");
                HOperatorSet.SegmentContoursXld(XLD, out XLD, "lines_circles", 5, 4, 2);
                HOperatorSet.FitLineContourXld(XLD, "tukey", -1, 0, 5, 2, out HTuple rowBegin, out HTuple colBegion,
                    out HTuple rowEnd, out HTuple colEnd, out HTuple nr, out HTuple nc, out HTuple dist);
                HOperatorSet.SelectShapeXld(XLD, out HObject xldLines, new HTuple("height", "width"), "and", new HTuple(0, 250), new HTuple(30, 350));
                HOperatorSet.SelectObj(xldLines, out HObject xldLine, 1);
                HOperatorSet.FitLineContourXld(xldLine, "tukey", -1, 0, 5, 2, out rowBegin, out colBegion,
                    out rowEnd, out colEnd, out nr, out nc, out dist);
                HOperatorSet.AngleLl(rowBegin, colBegion, rowEnd, colEnd, rowBegin - 50, colBegion, rowEnd - 50, colEnd, out HTuple Angle);
                HOperatorSet.HomMat2dIdentity(out HTuple hom2d);
                HOperatorSet.VectorAngleToRigid(0, 0, 0, 0, 0, Angle, out HTuple homRotate);
                HOperatorSet.AffineTransImage(CurImg, out HObject RotateImg, homRotate, "constant", "false");
                HOperatorSet.AffineTransRegion(Region, out HObject RotateJiEr, homRotate, "nearest_neighbor");
                // 去除下边界干扰
                HOperatorSet.DilationRectangle1(RotateJiEr, out HObject DownRegion, 2000, 35);
                HOperatorSet.MoveRegion(DownRegion, out DownRegion, Project.Instance.configuration.projectCfg.DownPianYi, 30);
                //HOperatorSet.OverpaintRegion(CurImg, DownRegion, 150, "fill");
                // 去除右边界的干扰
                HOperatorSet.DilationRectangle1(RotateJiEr, out HObject RightRegion, 10, 4600);
                HOperatorSet.MoveRegion(RightRegion, out RightRegion, 0, Project.Instance.configuration.projectCfg.RightPianYi);
                //HOperatorSet.OverpaintRegion(CurImg, RightRegion, 150, "fill");
                // 去除左边界的干扰
                HOperatorSet.DilationRectangle1(RotateJiEr, out HObject LeftRegion, 10, 4600);
                HOperatorSet.MoveRegion(LeftRegion, out LeftRegion, 0, Project.Instance.configuration.projectCfg.LeftPianYi);
                //HOperatorSet.OverpaintRegion(CurImg, RightRegion, 150, "fill");


                Frm_Vision.Instance.hWindow_Final1.viewWindow.displayImage(CurImg);
                Frm_Vision.Instance.hWindow_Final1.DispObj(DownRegion, "green");
                Frm_Vision.Instance.hWindow_Final1.DispObj(RightRegion, "green");
                Frm_Vision.Instance.hWindow_Final1.DispObj(LeftRegion, "green");
            }
            catch (Exception ex)
            {
                FuncLib.ShowMessageBox("当前操作出现异常：" + ex.Message, InfoType.Error);
            }
        }



        private void 复位信号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SDK_HIKVision.IsCallBackIng = true;
                Task.FindTaskByName("jee").isRunning = false;
            }
            catch (Exception ex)
            {
                FuncLib.ShowMessageBox(ex.Message, InfoType.Error);
            }
        }

        private void 设置踢料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ckb_Start.Enabled = !ckb_Start.Enabled;
        }


    }
}
