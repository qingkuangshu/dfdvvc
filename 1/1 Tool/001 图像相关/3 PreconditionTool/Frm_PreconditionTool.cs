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

namespace VM_Pro
{
    public partial class Frm_PreconditionTool : UIForm
    {
        public Frm_PreconditionTool()
        {
            InitializeComponent();
        }

        private static Frm_PreconditionTool _instance;

        internal static Frm_PreconditionTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_PreconditionTool();
                return _instance;
            }
        }

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
        internal static PreconditionTool preconditionTool;
        /// <summary>
        /// 正在抓图的话就放弃再次抓图
        /// </summary>
        private static bool isGrabing = false;

        private void Frm_PreconditionTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }


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
            preconditionTool = (PreconditionTool)toolBase;

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
                UIMessageTip.ShowError("打开工具界面出现异常，请稍后重试...");
                return;
            }


            Application.DoEvents();
            hasShown = true;

            preconditionTool.UpdateInput();

            //显示图像
            if (((PreconditionTool.ToolPar)preconditionTool.参数).输入.图像 != null)
            {
                Instance.hWindow_Final1.HobjectToHimage(((PreconditionTool.ToolPar)preconditionTool.参数).输入.图像);
                Application.DoEvents();
            }

            //区域设置界面
            if (preconditionTool.IsQuanTu)
                Instance.rad_IsQuanTu.Checked = true;
            else
            {
                Instance.rad_IsQuYu.Checked = true;
                Instance.Pan_ROI.Visible = true;
                for (int i = 0; i < preconditionTool.L_inputItem.Count; i++)
                {
                    if (preconditionTool.L_inputItem[i].inputType == DataType.Region)
                    {
                        Instance.txt_ROILianRu.Text = preconditionTool.L_inputItem[i].sourceTool + ".区域";
                        break;
                    }
                }
                if (((PreconditionTool.ToolPar)preconditionTool.参数).输入.区域 != null && ((PreconditionTool.ToolPar)preconditionTool.参数).输入.区域.CountObj() > 0)
                {
                    Instance.hWindow_Final1.DispObj(((PreconditionTool.ToolPar)preconditionTool.参数).输入.区域, "green");
                }
            }
            //显示链入图像源
            for (int i = 0; i < preconditionTool.L_inputItem.Count; i++)
            {
                if (preconditionTool.L_inputItem[i].inputType == DataType.Image)
                {
                    Instance.txt_ImgLianRu.Text = preconditionTool.L_inputItem[i].sourceTool + ".图像";
                    break;
                }
            }


            Instance.ckb_ShowResultImg.Checked = preconditionTool.ShowResultImg;
            Instance.ckb_ShowResultRegion.Checked = preconditionTool.ShowResultRegion;
            Instance.ckb_ShowBeforRegion.Checked = preconditionTool.ShowBeforRegion;
            Instance.ckb_OutImgToImgtoolOriginMap.Checked = preconditionTool.isOutImgToImgtoolOriginMap;
            Instance.ckb_IsRunRenovate.Checked = preconditionTool.isRunRenovate;
            Instance.Panel_CanShu.Controls.Clear();
            preconditionTool.GenLstShowDgvData();   //将数组列表信息显示到Dgv控件当中


            Thread th1 = new Thread(() =>
            {
                preconditionTool.Run();
            });
            th1.IsBackground = true;
            th1.Start();






            openingForm = false;

        }


        /// <summary>
        /// 当更改参数数据之后，需要将信息更新到dgv
        /// </summary>
        /// <param name="data"></param>
        internal void ShowDgvData(string data)
        {
            try
            {
                if (Frm_PreconditionTool.Instance.B_showdgvdata)    //当更改Frm_PreconditionTool的dgv数据，所触发此方法是不需要进行修改的
                {
                    if (Frm_PreconditionTool.Instance.dgv_YuChuLi.CurrentRow == null)
                        return;     //没有选中哪一行，然后触发了此处，是因为初始化赋值的时候，触发了
                    //先获取到当前预处理界面的dgv控件选中的行数
                    int index = Frm_PreconditionTool.Instance.dgv_YuChuLi.CurrentRow.Index;
                    Frm_PreconditionTool.preconditionTool.YuChuLi_lst_dgv[index].CanShuStr = data;
                    Frm_PreconditionTool.Instance.dgv_YuChuLi.Rows[index].Cells[2].Value = data;
                    if (preconditionTool.isRunRenovate)
                    {
                        Frm_PreconditionTool.Instance.btn_runTool_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }



        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            btn_Add.ShowContextMenuStrip(uiContextMenuStrip1, 0, btn_Add.Height);
        }

        private void You_Click(object sender, EventArgs e)
        {
            if (sender == null)
                return;
            bool is_Switch = false;
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            YuChuLiType eType = YuChuLiType.二值化;
            string TypeValue = "";
            try
            {
                eType = (YuChuLiType)Enum.Parse(typeof(YuChuLiType), item.Name);
                is_Switch = preconditionTool.SwitchYuChuLiForm(eType, ref TypeValue);
            }
            catch (Exception ex)
            {
                FuncLib.ShowMessageBox("新增预处理操作出现异常：" + ex.Message, InfoType.Error);
                return;
            }

            if (!is_Switch)    //获取当前添加类型的数据
            {
                UIMessageTip.ShowError("当前点击了：" + item.Name + " 但切换失败，可能是类别处理未开放..");
                return;
            }
            //可以添加当前操作项，则先加入到列表当前，然后统一由更新UI方法去进行数据刷新显示
            preconditionTool.YuChuLi_lst_dgv.Add(new Precondition_Dgv(true, eType, TypeValue));
            //更新UI
            preconditionTool.GenLstShowDgvData(preconditionTool.YuChuLi_lst_dgv.Count - 1);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void btn_runTool_Click(object sender, EventArgs e)
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

                preconditionTool.Run();

                Thread.Sleep(100);
                Frm_Loading.Instance.Hide();
            });
            th.IsBackground = true;
            th.Start();
        }

        private void dgv_YuChuLi_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        /// <summary>
        /// 在更改dgv行的时候，不用再去做dgv数据更新的操作
        /// </summary>
        internal bool B_showdgvdata = true;

        private void dgv_YuChuLi_SelectIndexChange(object sender, int index)
        {
            try
            {
                if (Instance.dgv_YuChuLi.Rows[index].Cells[1].Value == null)    //防呆，首次加载界面的时候，会触发此方法，但不想执行内部逻辑
                    return;
                B_showdgvdata = false;
                //获取到当前选中行的类型以及所需展示的数据
                string typeStr = Instance.dgv_YuChuLi.Rows[index].Cells[1].Value.ToString();
                string Value = Instance.dgv_YuChuLi.Rows[index].Cells[2].Value.ToString();
                YuChuLiType type = (YuChuLiType)Enum.Parse(typeof(YuChuLiType), typeStr);
                preconditionTool.SwitchYuChuLiForm(type,ref Value);
                B_showdgvdata = true;
            }
            catch (Exception ex)
            {
                FuncLib.ShowMessageBox("更改dgv行操作出现异常：" + ex.Message, InfoType.Error);
            }

        }

        /// <summary>
        /// 选择是否全图预处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rad_IsQuanTu_Click(object sender, EventArgs e)
        {
            preconditionTool.IsQuanTu = rad_IsQuanTu.Checked;
            Pan_ROI.Visible = !preconditionTool.IsQuanTu;

        }

        private void ckb_ShowResultImg_Click(object sender, EventArgs e)
        {
            preconditionTool.ShowResultImg = ckb_ShowResultImg.Checked;
        }

        private void ckb_ShowResultRegion_Click(object sender, EventArgs e)
        {
            preconditionTool.ShowResultRegion = ckb_ShowResultRegion.Checked;
        }

        /// <summary>
        /// 删除当前选择的预处理操作项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Sub_Click(object sender, EventArgs e)
        {
            try
            {
                int DeledSelectIndex = -1;
                //拿到当前所需删掉的行数信息
                int index = Instance.dgv_YuChuLi.SelectedIndex;


                preconditionTool.YuChuLi_lst_dgv.RemoveAt(index);

                preconditionTool.GenLstShowDgvData();

                UIMessageTip.ShowOk("成功移除当前预处理操作项", 3000);
            }
            catch (Exception ex)
            {
                FuncLib.ShowMessageBox(ex.Message, InfoType.Error);
            }
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            try
            {
                //获取当前需要上移的行数
                int index = Instance.dgv_YuChuLi.SelectedIndex;
                if (index < 0)
                {
                    UIMessageTip.ShowError("未检测到当前选择表格行数，请重新确认是否存在选中行");
                }
                else if (index == 0)
                {
                    //DataGridViewRow dgvr = Instance.dgv_YuChuLi.Rows 
                    UIMessageTip.ShowWarning("当前已处于顶行，请稍后操作", 3000);
                }
                else
                {

                    Precondition_Dgv item = preconditionTool.YuChuLi_lst_dgv[index];
                    Precondition_Dgv item1 = preconditionTool.YuChuLi_lst_dgv[index - 1];
                    preconditionTool.YuChuLi_lst_dgv[index] = item1;
                    preconditionTool.YuChuLi_lst_dgv[index - 1] = item;
                    preconditionTool.GenLstShowDgvData(index - 1);

                }
            }
            catch (Exception ex)
            {
                FuncLib.ShowMessageBox(ex.Message, InfoType.Error);
            }
        }

        private void dgv_YuChuLi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (openingForm || e.RowIndex == -1)
                return;
            if (e.ColumnIndex == 0)
            {
                preconditionTool.YuChuLi_lst_dgv[e.RowIndex].StartUse = Convert.ToBoolean(Instance.dgv_YuChuLi.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            try
            {
                //获取当前需要上移的行数
                int index = Instance.dgv_YuChuLi.SelectedIndex;
                if (index < 0)
                {
                    UIMessageTip.ShowError("未检测到当前选择表格行数，请重新确认是否存在选中行");
                }
                else if (index == Instance.dgv_YuChuLi.RowCount - 1)
                {
                    //DataGridViewRow dgvr = Instance.dgv_YuChuLi.Rows 
                    UIMessageTip.ShowWarning("当前已处于底行，请稍后操作", 3000);
                }
                else
                {

                    Precondition_Dgv item = preconditionTool.YuChuLi_lst_dgv[index];
                    Precondition_Dgv item1 = preconditionTool.YuChuLi_lst_dgv[index + 1];
                    preconditionTool.YuChuLi_lst_dgv[index] = item1;
                    preconditionTool.YuChuLi_lst_dgv[index + 1] = item;
                    preconditionTool.GenLstShowDgvData(index + 1);

                }
            }
            catch (Exception ex)
            {
                FuncLib.ShowMessageBox(ex.Message, InfoType.Error);
            }
        }

        private void btn_runTask_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Task.FindTaskByName(taskName).Run();
            });
            th.IsBackground = true;
            th.Start();
        }

        private void ImgBtn_LianRu_Click(object sender, EventArgs e)
        {
            FrmBianLiang frm = new FrmBianLiang(toolName);
            frm.TagString = "区域";
            frm.ShowNavNodes(preconditionTool.LianRuToolNames(DataType.Region));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_ROILianRu.Text = FrmBianLiang.currentLianRuInfo;
                UIMessageTip.ShowWarning("正在切换区域中，请稍候..");
                preconditionTool.UpdateInput();
                Thread th1 = new Thread(() =>
                {
                    preconditionTool.Run();
                });
                th1.IsBackground = true;
                th1.Start();
            }
        }

        private void ckb_ShowBeforRegion_Click(object sender, EventArgs e)
        {
            preconditionTool.ShowBeforRegion = ckb_ShowBeforRegion.Checked;
        }

        private void ckb_OutImgToImgtoolOriginMap_Click(object sender, EventArgs e)
        {
            preconditionTool.isOutImgToImgtoolOriginMap = ckb_OutImgToImgtoolOriginMap.Checked;
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FuncLib.ShowTooLHelp(preconditionTool.toolType);
        }

        private void btn_DuiBiImg_MouseDown(object sender, MouseEventArgs e)
        {
            if (((PreconditionTool.ToolPar)preconditionTool.参数).输出.图像 != null)
            {
                hWindow_Final1.viewWindow.displayImage(((PreconditionTool.ToolPar)preconditionTool.参数).输出.图像);
            }
        }

        private void btn_DuiBiImg_MouseUp(object sender, MouseEventArgs e)
        {
            if (((PreconditionTool.ToolPar)preconditionTool.参数).输入.图像 != null)
            {
                hWindow_Final1.viewWindow.displayImage(((PreconditionTool.ToolPar)preconditionTool.参数).输入.图像);
            }
        }

        private void ckb_IsRunRenovate_Click(object sender, EventArgs e)
        {
            preconditionTool.isRunRenovate = ckb_IsRunRenovate.Checked;
            if (preconditionTool.isRunRenovate)
            {
                Frm_PreconditionTool.Instance.btn_runTool_Click(null, null);
            }
        }

        private void ImgBtn_ImgLianRu_Click(object sender, EventArgs e)
        {
            FrmBianLiang frm = new FrmBianLiang(toolName);
            frm.TagString = "图像";
            //frm.ShowNavNodes(preconditionTool.LianRuImgToolNames(toolName));
            frm.ShowNavNodes(preconditionTool.LianRuToolNames(DataType.Image));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_ImgLianRu.Text = FrmBianLiang.currentLianRuInfo;
                UIMessageTip.ShowWarning("正在切换图像源，请稍候..");
                preconditionTool.UpdateInput();
                Thread th1 = new Thread(() =>
                {
                    preconditionTool.Run();
                });
                th1.IsBackground = true;
                th1.Start();
                //更新当前输入项
            }
        }
    }
}
