using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using HalconDotNet;
using Sunny.UI;

namespace VM_Pro
{
    public partial class Frm_ImageEngineTool : UIForm
    {
        public Frm_ImageEngineTool()
        {
            InitializeComponent();
        }

        private static Frm_ImageEngineTool _instance;

        public static Frm_ImageEngineTool Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Frm_ImageEngineTool();
                }
                return _instance;
            }

        }

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
        internal static ImageEngineTool imageEngineTool;


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
            imageEngineTool = (ImageEngineTool)toolBase;

            taskName = toolBase.taskName;
            toolName = toolBase.toolName;

            //显示相应的数据
            Instance.txt_FileName.Text = imageEngineTool.ProgramFile;
            Instance.ckb_taskFailKeepRun.Checked = imageEngineTool.taskFailKeepRun;
            Instance.lbl_toolTip.Text = imageEngineTool.toolRunStatu;
            //输入dgv
            if (imageEngineTool.m_listInputs.Count > 0)
            {
                //Instance.Dgv_Input
            }
            for (int i = 0; i < imageEngineTool.L_producedureNames.Count; i++)
            {
                Instance.cmb_CurrentProduce.Items.Add(imageEngineTool.L_producedureNames[i]);
                if (imageEngineTool.L_producedureNames[i] == imageEngineTool.SelectProcedure)
                {
                    Instance.cmb_CurrentProduce.SelectedIndex = i;
                }
            }
            for (int i = 0; i < imageEngineTool.L_produceNamesAndPar.Count; i++)
            {
                Instance.cmb_CurrentTxtProduce.Items.Add(imageEngineTool.L_produceNamesAndPar[i]);

                if (imageEngineTool.L_produceNamesAndPar[i].Split('(')[0] == imageEngineTool.SelectSaveProcedure)
                {
                    Instance.cmb_CurrentTxtProduce.SelectedIndex = i;
                }
            }
            //Instance.cmb_CurrentProduce.Text = imageEngineTool.SelectProcedure;
            //Instance.cmb_CurrentTxtProduce.Text = imageEngineTool.SelectSaveProcedure;

            Instance.Show();
            hasShown = true;
        }

        private void Frm_ImageEngineTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            e.Cancel = true;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            //获取程序路径
            OpenFileDialog Program_path = new OpenFileDialog();
            //设定允许单选
            Program_path.Multiselect = false;
            //选择框限定文件类型
            Program_path.Filter = "hdev files(*.hdev)|*.hdev|All files(*.*)|*.*";
            //限定成功读取路径
            if (Program_path.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cmb_CurrentProduce.Items.Clear();
                cmb_CurrentProduce.Text = "";
                txt_FileName.Text = Program_path.FileName;
                imageEngineTool.ProgramFile = Program_path.FileName;

                List<string> str = imageEngineTool.GetProcedureNames();
                List<string> str2 = imageEngineTool.GetProcedureIO();

                InitCMBProduceNames(str.ToArray());
                InitComboxMain(str2.ToArray());
            }
        }

        /// <summary>
        /// 初始化当前运行程序下拉选项
        /// </summary>
        /// <param name="items"></param>
        private void InitCMBProduceNames(string[] items)
        {
            if (items == null)
                return;
            cmb_CurrentProduce.Items.Clear();
            int index = -1;
            foreach (var item in items)
            {
                index++;
                cmb_CurrentProduce.Items.Add(item);
            }
            cmb_CurrentProduce.SelectedIndex = index;
        }

        /// <summary>
        /// 初始化查看函数下拉选项
        /// </summary>
        /// <param name="items"></param>
        private void InitComboxMain(string[] items)
        {
            if (items == null)
                return;
            cmb_CurrentTxtProduce.Items.Clear();
            cmb_CurrentTxtProduce.Items.Add("main(:::)");
            int index = -1;
            foreach (var item in items)
            {
                index++;
                cmb_CurrentTxtProduce.Items.Add(item);
            }
            cmb_CurrentTxtProduce.SelectedIndex = index;
        }

        internal void cmb_CurrentTxtProduce_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = cmb_CurrentTxtProduce.Text.ToString();
            string[] strarray = str.Split('(');

            imageEngineTool.ReadProcedure(strarray[0]);

            imageEngineTool.SelectSaveProcedure = strarray[0];

            fastColoredTextBox_Source.Text = imageEngineTool.ProcedureCode;
        }

        private void btn_RunCurrentProcedure_Click(object sender, EventArgs e)
        {
            if (imageEngineTool.SelectProcedure != "" && imageEngineTool.m_hProcedureCall != null && imageEngineTool.m_hProcedureCall.IsInitialized())
            {
                string RunResult = imageEngineTool.RunProcedure();
                if (RunResult != "Run Success")
                {
                    FuncLib.ShowExceptionBox("运行当前程序失败：" + RunResult, InfoType.Error);
                }
                else
                {
                    UIMessageTip.ShowOk("当前程序执行成功", 3000);
                    UpdataDgvOutData();
                }
            }
            else
            {
                FuncLib.ShowMessageBox("当前所选程序存在异常，请确认");
            }
        }


        private void cmb_CurrentProduce_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageEngineTool.SelectProcedure = cmb_CurrentProduce.Text.ToString();

            //更新输入输出项
            UpdateDgvIOData();
        }


        /// <summary>
        /// 更新输出表格数据
        /// </summary>
        internal void UpdataDgvOutData()
        {
            try
            {
                for (int i = 0; i < imageEngineTool.m_listOutputs.Count; i++)
                {
                    if (imageEngineTool.m_listOutputs[i].ValueType.Name == "HTuple")
                    {
                        HTuple a = imageEngineTool.m_listOutputs[i].Value as HTuple;
                        if (a == null || a.Type.ToString() == "EMPTY")
                            continue;
                        if (a.Length > 1)
                        {
                            Instance.Dgv_Output.Rows[i].Cells[2].Value = "Count:" + a.Length + "  " + imageEngineTool.m_listOutputs[i].Value;   //多一个长度显示
                        }
                        else
                        {
                            Instance.Dgv_Output.Rows[i].Cells[2].Value = imageEngineTool.m_listOutputs[i].Value;
                        }
                    }
                    else if (imageEngineTool.m_listOutputs[i].ValueType.Name == "HObject")
                    {
                        Instance.Dgv_Output.Rows[i].Cells[2].Value = imageEngineTool.m_listOutputs[i].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }




        /// <summary>
        /// 更新表格的输入输出项
        /// </summary>
        private void UpdateDgvIOData()
        {
            //输入集合表格
            Dgv_Input.ClearRows();
            for (int i = 0; i < imageEngineTool.m_listInputs.Count; i++)
            {
                Instance.Dgv_Input.Rows.Add();
                Instance.Dgv_Input.Rows[i].Cells[0].Value = imageEngineTool.m_listInputs[i].Name;
                if (imageEngineTool.m_listInputs[i].ValueSource != null)
                {
                    Instance.Dgv_Input.Rows[i].Cells[1].Value = imageEngineTool.m_listInputs[i].ValueSource;
                }
            }

            //输出集合表格
            Dgv_Output.ClearRows();
            for (int i = 0; i < imageEngineTool.m_listOutputs.Count; i++)
            {
                Instance.Dgv_Output.Rows.Add();
                Instance.Dgv_Output.Rows[i].Cells[0].Value = imageEngineTool.m_listOutputs[i].Name;
                if (imageEngineTool.m_listOutputs[i].ValueSource != null)
                {
                    Instance.Dgv_Output.Rows[i].Cells[1].Value = imageEngineTool.m_listOutputs[i].ValueSource;
                }
            }

            //如果存在输出项的话，则允许进行类型选择
            if (Instance.Dgv_Output.Rows.Count > 0)
            {
                Instance.cmb_OutDataType.Enabled = true;
            }
            else
            {
                Instance.cmb_OutDataType.Enabled = false;
            }

        }

        private void Dgv_Input_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1 || e.RowIndex < 0)   //非法点击
                return;

            FrmBianLiang frm = new FrmBianLiang(toolName);
            //frm.TagString = "任意";
            //frm.ShowNavNodes(imageEngineTool.LianRuRegionToolNames(toolName));

            string valueType = imageEngineTool.m_listInputs[e.RowIndex].ValueType.Name;
            if (valueType == "HObject")
            {
                frm.TagString = "HObject";
                frm.ShowNavNodes(imageEngineTool.LianRuToolNames(DataType.Image,DataType.Region));
            }
            else
            {
                frm.TagString = "文本";
                frm.ShowNavNodes(imageEngineTool.LianRuToolNames(DataType.String));
            }
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Dgv_Input.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = FrmBianLiang.currentLianRuInfo;
                imageEngineTool.m_listInputs[e.RowIndex].ValueSource = FrmBianLiang.currentLianRuInfo;
            }
        }

        #region   改变字体
        //styles
        TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
        TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
        TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));
        #endregion

        private void fastColoredTextBox_Source_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            fastColoredTextBox_Source.LeftBracket = '(';
            fastColoredTextBox_Source.RightBracket = ')';
            fastColoredTextBox_Source.LeftBracket2 = '\x0';
            fastColoredTextBox_Source.RightBracket2 = '\x0';
            //clear style of changed range
            e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle);

            //string highlighting
            e.ChangedRange.SetStyle(BrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //comment highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);
            //number highlighting
            e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            //attribute highlighting
            e.ChangedRange.SetStyle(GrayStyle, @"^\*(?<range>\[.+?\])\*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GrayStyle, @"\*.*$", RegexOptions.Multiline);


            //class name highlighting
            e.ChangedRange.SetStyle(BoldStyle, @"\b(class|struct|enum|interface)\s+(?<range>\w+?)\b");
            //keyword highlighting
            e.ChangedRange.SetStyle(BrownStyle, @"\b(abstract|as|base|bool|break|byte|case|endif|endfor|by|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b");

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            e.ChangedRange.SetFoldingMarkers("{", "}");//allow to collapse brackets block
            e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");//allow to collapse #region blocks
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");//allow to collapse comment block
        }


        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Source.ReadOnly = !fastColoredTextBox_Source.ReadOnly;

            if (!fastColoredTextBox_Source.ReadOnly)
            {
                this.编辑ToolStripMenuItem.Text = "锁定";
            }
            else
            {
                this.编辑ToolStripMenuItem.Text = "编辑";
            }
        }

        private void 保存更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //保存的时候，先判断当前运行程序以及所选程序一致不



            imageEngineTool.ProcedureCode = fastColoredTextBox_Source.Text.Trim();

            Instance.编辑ToolStripMenuItem.Text = "编辑";
            Instance.fastColoredTextBox_Source.ReadOnly = true;

        }


        private void ckb_taskFailKeepRun_Click(object sender, EventArgs e)
        {
            if (Frm_Inference.openingForm)
                return;

            imageEngineTool.taskFailKeepRun = ckb_taskFailKeepRun.Checked;
        }

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
                    imageEngineTool.Run();
                    isRunning = false;
                    Frm_Loading.Instance.Hide();
                });
                th.IsBackground = true;
                th.Start();
            }
        }

        private void cmb_OutDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dgvSelectIndex = -1;
            dgvSelectIndex = Instance.Dgv_Output.SelectedIndex;
            if (dgvSelectIndex > -1)
            {
                Instance.Dgv_Output.Rows[dgvSelectIndex].Cells[1].Value = cmb_OutDataType.Text;
                imageEngineTool.m_listOutputs[dgvSelectIndex].ValueSource = cmb_OutDataType.Text;
            }

        }
    }
}
