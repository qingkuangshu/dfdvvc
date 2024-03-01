using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using Sunny.UI;

namespace VM_Pro
{
    public partial class Frm_Inference : UIForm
    {
        public Frm_Inference()
        {
            InitializeComponent();
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
        internal static InferenceTool inferenceTool;
        /// <summary>
        /// 正在抓图的话就放弃再次抓图
        /// </summary>
        private static bool isGrabing = false;

        #region 单例模式


        private static Frm_Inference _instance;

        internal static Frm_Inference Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Inference();
                return _instance;
            }
        }

        #endregion


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
            inferenceTool = (InferenceTool)toolBase;

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
                UIMessageTip.ShowError("打开异常，请稍后重试...");
                return;
            }

            Application.DoEvents();
            hasShown = true;

            inferenceTool.UpdateInput();


            //显示图像 
            if (((InferenceTool.ToolPar)inferenceTool.参数).输入.图像 != null)
            {
                Instance.hWindow_Final1.ClearWindow();
                //Instance.hWindow_Final1.HobjectToHimage(((InferenceTool.ToolPar)inferenceTool.参数).输入.图像);
                Instance.hWindow_Final1.viewWindow.displayImage(((InferenceTool.ToolPar)inferenceTool.参数).输入.图像);
                inferenceTool.GetImageWindow().viewWindow.displayImage(((InferenceTool.ToolPar)inferenceTool.参数).输入.图像);
            }



            //区域设置界面
            if (inferenceTool.IsQuanTu)
                Instance.rad_IsQuanTu.Checked = true;
            else
            {
                Instance.rad_IsQuYu.Checked = true;
                Instance.Pan_ROI.Visible = true;
                for (int i = 0; i < inferenceTool.L_inputItem.Count; i++)
                {
                    if (inferenceTool.L_inputItem[i].inputType == DataType.Region)
                    {
                        Instance.txt_LianRu.Text = inferenceTool.L_inputItem[i].sourceTool + ".区域";
                        break;
                    }
                }
                if (((InferenceTool.ToolPar)inferenceTool.参数).输入.区域 != null && ((InferenceTool.ToolPar)inferenceTool.参数).输入.区域.CountObj() > 0)
                {
                    Instance.hWindow_Final1.DispObj(((InferenceTool.ToolPar)inferenceTool.参数).输入.区域, "green");
                }
            }



            Instance.txtClassNames.Text = inferenceTool.QueXianClassNames;
            Instance.txt_XunLianHdl.Text = inferenceTool.XunLianPaht;

            //显示页
            Instance.Ckb_ShowResult.Checked = inferenceTool.RunResultShowFrmMain;
            Instance.Ckb_RunImgShowFrm.Checked = inferenceTool.RunImgShowFrmMain;
            Instance.Ckb_RunRegionShowFrm.Checked = inferenceTool.RunRegionShowFrmMain;
            Instance.Ckb_ShowDgvData.Checked = inferenceTool.RunDgvDataGetFrmMain;
            Instance.ckb_taskFailKeepRun.Checked = inferenceTool.taskFailKeepRun;
            Instance.ckb_JianCeRegionToMain.Checked = inferenceTool.RunJianCeRegionShowFrmMain;
            //参数页
            if (inferenceTool.IsRunGPU)
                Frm_Inference.Instance.Rdb_GPU.Checked = true;
            else
                Frm_Inference.Instance.Rdb_CPU.Checked = true;
            if (inferenceTool.IsQueXianTuiLi)
                Frm_Inference.Instance.IsQueXian.Checked = true;
            else
                Frm_Inference.Instance.IsTuXiang.Checked = true;

            if (!inferenceTool.RunDgvDataGetFrmMain)
                inferenceTool.lstDgvDataModel = inferenceTool.lstClassNameModel;
            inferenceTool.GenLstDgvDataModelShowDgvData();  //更新表格数据

            if (!inferenceTool.toolRunStatu.Contains("运行成功"))
            {
                Frm_Inference.Instance.lbl_toolTip.ForeColor = Color.Red;
            }
            Frm_Inference.Instance.lbl_toolTip.Text = inferenceTool.toolRunStatu;
            Thread th1 = new Thread(() =>
            {
                inferenceTool.Run();
            });
            th1.IsBackground = true;
            th1.Start();
            openingForm = false;
            Application.DoEvents();
        }

        private void Frm_Inference_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 隐藏当前窗体
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
            if (!isGrabing)
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
                    isGrabing = true;
                    inferenceTool.Run();
                    isGrabing = false;
                    Frm_Loading.Instance.Hide();
                });
                th.IsBackground = true;
                th.Start();
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


        private void txt_XunLianHdl_DoubleClick(object sender, EventArgs e)
        {
            if (txtClassNames.Text == "")
            {
                UIMessageTip.ShowWarning("请先设置检测标签参数后再导入训练模型...");
                return;
            }

            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择训练模型文件";
            dialog.Filter = "HDl文件(*.hdl)|*.hdl";
            dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                UIMessageTip.ShowWarning("正在加载模型数据中，请稍候...");
                try
                {

                    if (inferenceTool.XunLianHandle != null)
                    {
                        inferenceTool.XunLianHandle.Dispose();
                    }
                    //加上此行可解决深度学习内存泄漏的问题，需在readdlmodel前执行才有效
                    HOperatorSet.SetSystem("cudnn_deterministic", "true");  
                    HOperatorSet.ReadDlModel(dialog.FileName, out inferenceTool.XunLianHandle);
                    //此处后续需要对该句柄进行校验，防止用户导错文件导致的处理异常问题


                    //2、根据当前所选择的运行环境，设置相应的系统参数
                    if (inferenceTool.IsRunGPU)
                    {
                        HTuple cudaLoaded = null, cudnnLoaded = null, cublasLoaded = null;
                        HOperatorSet.GetSystem("cuda_loaded", out cudaLoaded);
                        HOperatorSet.GetSystem("cudnn_loaded", out cudnnLoaded);
                        HOperatorSet.GetSystem("cublas_loaded", out cublasLoaded);
                        if (!(cudaLoaded.S == "true" && cudnnLoaded.S == "true" && cublasLoaded.S == "true"))
                        {
                            //
                            FuncLib.ShowMsg("当前环境不支持GPU模式，已自动切换为CPU模式...", InfoType.Error);
                            inferenceTool.IsRunGPU = false;
                        }
                    }
                    if (!inferenceTool.IsRunGPU && inferenceTool.XunLianHandle != null)
                    {
                        try
                        {
                            //此处可能会报没有足够内存的异常，先try起来，以免影响后面设置
                            HOperatorSet.SetDlModelParam(inferenceTool.XunLianHandle, "runtime", "cpu");

                        }
                        catch (Exception ex)
                        {
                            FuncLib.ShowMsg("内存不足：" + ex.Message, InfoType.Error);
                        }
                    }

                    HOperatorSet.SetDlModelParam(inferenceTool.XunLianHandle, "batch_size", 1);
                    HOperatorSet.SetDlModelParam(inferenceTool.XunLianHandle, "runtime_init", "immediately");

                    //重新初始化预处理句柄，并生成新的dgv列表
                    inferenceTool.GetXunLianModelSetYuChuLi(txtClassNames.Text.Trim());


                    inferenceTool.QueXianClassNames = txtClassNames.Text.Trim();
                    inferenceTool.XunLianPaht = dialog.FileName;
                    txt_XunLianHdl.Text = inferenceTool.XunLianPaht;
                    UIMessageTip.ShowOk("成功加载当前模型...");
                }
                catch (Exception ex)
                {
                    FuncLib.ShowMessageBox(ex.Message, InfoType.Error);
                }
            }
        }


        private void Rdb_GPU_Click(object sender, EventArgs e)
        {
            try
            {
                UIMessageTip.ShowOk("正在快速切换GPU模式...");
                inferenceTool.IsRunGPU = Rdb_GPU.Checked;
                HTuple cudaLoaded = null, cudnnLoaded = null, cublasLoaded = null;
                HOperatorSet.GetSystem("cuda_loaded", out cudaLoaded);
                HOperatorSet.GetSystem("cudnn_loaded", out cudnnLoaded);
                HOperatorSet.GetSystem("cublas_loaded", out cublasLoaded);
                if (cudaLoaded.S == "true" && cudnnLoaded.S == "true" && cublasLoaded.S == "true")
                {
                    HOperatorSet.SetDlModelParam(inferenceTool.XunLianHandle, "runtime", "gpu");
                    UIMessageTip.ShowOk("成功切换GPU模式...");
                }
                else
                {
                    UIMessageTip.ShowError("当前环境不支持GPU模式，已为您切回CPU模式");
                    Rdb_CPU.Checked = true;
                }
            }
            catch (Exception ex)
            {
                FuncLib.ShowMsg("当前切换GPU模式出现异常，可能是显存不够：" + ex.Message, InfoType.Error);
            }

        }

        private void Rdb_CPU_Click(object sender, EventArgs e)
        {
            try
            {
                inferenceTool.IsRunGPU = Rdb_GPU.Checked;
                if (inferenceTool.XunLianHandle != null)
                {
                    HOperatorSet.SetDlModelParam(inferenceTool.XunLianHandle, "runtime", "cpu");

                }
            }
            catch (Exception)
            {
                //
            }
        }


        private void Ckb_ShowResult_Click(object sender, EventArgs e)
        {
            inferenceTool.RunResultShowFrmMain = Ckb_ShowResult.Checked;
        }

        private void Ckb_RunImgShowFrm_Click(object sender, EventArgs e)
        {
            inferenceTool.RunImgShowFrmMain = Ckb_RunImgShowFrm.Checked;
        }

        private void Ckb_RunRegionShowFrm_Click(object sender, EventArgs e)
        {
            inferenceTool.RunRegionShowFrmMain = Ckb_RunRegionShowFrm.Checked;
        }


        private void Ckb_ShowDgvData_Click(object sender, EventArgs e)
        {
            try
            {
                Ckb_ShowDgvData.Enabled = false;
                //若当前选择为true，则说明表格参数需跟随主界面。 false则说明需要根据句柄文件而来
                if (Ckb_ShowDgvData.Checked)
                {
                    inferenceTool.RunDgvDataGetFrmMain = true;
                    //根据生产界面的表格而来
                    inferenceTool.lstDgvDataModel = Project.Instance.configuration.lstLeiBie;
                    UIMessageTip.ShowOk("已将当前Dgv数据来源切换为根据主界面输入");
                }
                else
                {
                    inferenceTool.RunDgvDataGetFrmMain = false;
                    inferenceTool.lstDgvDataModel = inferenceTool.lstClassNameModel;
                    UIMessageTip.ShowOk("已将当前Dgv数据来源切换为根据语义分割文件");
                }
                inferenceTool.GenLstDgvDataModelShowDgvData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Ckb_ShowDgvData.Enabled = true;

        }




        private void DgvHandleData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_Inference.openingForm)
                return;

            inferenceTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }

        private void 保存更新_Click(object sender, EventArgs e)
        {
            try
            {
                List<LeiBieModel> lstlb = new List<LeiBieModel>();
                //获取当前列表当中的所有数据
                for (int i = 0; i < Instance.DgvHandleData.Rows.Count; i++)
                {
                    LeiBieModel item = new LeiBieModel();
                    item.LeiBie = Instance.DgvHandleData.Rows[i].Cells[1].Value.ToString();
                    item.MinArea = Convert.ToDouble(Instance.DgvHandleData.Rows[i].Cells[2].Value);
                    item.MaxArea = Convert.ToDouble(Instance.DgvHandleData.Rows[i].Cells[3].Value);
                    //item.BeforArea = Convert.ToDouble(DgvHandleData.Rows[i].Cells[4].Value);
                    item.CheckEnable = Convert.ToBoolean(Instance.DgvHandleData.Rows[i].Cells[5].Value);
                    lstlb.Add(item);
                }
                bool bb = Convert.ToBoolean(Instance.DgvHandleData.Rows[2].Cells[5].Value);

                //判断一下当前表格的数据来源于谁
                if (inferenceTool.RunDgvDataGetFrmMain)
                {
                    //此处需要清空列表当中的区域，手动进行释放，不然的话可能会造成内存溢出


                    inferenceTool.lstDgvDataModel.Clear();
                    inferenceTool.lstDgvDataModel = lstlb;
                }
                else
                {
                    inferenceTool.lstClassNameModel.Clear();
                    inferenceTool.lstClassNameModel = lstlb;
                }
                UIMessageTip.ShowOk("已将表格数据更新为最新...");

            }
            catch (Exception ex)
            {
                FuncLib.ShowMessageBox("保存出现异常：" + ex.Message, InfoType.Error);
            }
        }

        private void DgvHandleData_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void rad_IsQuanTu_Click(object sender, EventArgs e)
        {
            inferenceTool.IsQuanTu = rad_IsQuanTu.Checked;
            Pan_ROI.Visible = !inferenceTool.IsQuanTu;
        }

        private void ImgBtn_LianRu_Click(object sender, EventArgs e)
        {
            FrmBianLiang frm = new FrmBianLiang(toolName);
            frm.TagString = "区域";
            frm.ShowNavNodes(inferenceTool.LianRuToolNames(DataType.Region));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_LianRu.Text = FrmBianLiang.currentLianRuInfo;
                UIMessageTip.ShowWarning("正在切换区域中，请稍候..");
                //更新当前输入项
                inferenceTool.UpdateInput();
                Thread th1 = new Thread(() =>
                {
                    inferenceTool.Run();
                });
                th1.IsBackground = true;
                th1.Start();
            }
        }

        private void ckb_JianCeRegionToMain_Click(object sender, EventArgs e)
        {
            inferenceTool.RunJianCeRegionShowFrmMain = ckb_JianCeRegionToMain.Checked;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FuncLib.ShowTooLHelp(inferenceTool.toolType);
        }

        private void IsQueXian_Click(object sender, EventArgs e)
        {
            inferenceTool.IsQueXianTuiLi = IsQueXian.Checked;
        }
    }
}
