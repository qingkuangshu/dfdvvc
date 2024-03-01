using HalconDotNet;
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
    public partial class Frm_Scheme : Form
    {
        public Frm_Scheme()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Scheme _instance;
        internal static Frm_Scheme Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Scheme();
                return _instance;
            }
        }


        private void Frm_Project_Load(object sender, EventArgs e)
        {
            tvw_schemeList.Nodes.Clear();
            for (int i = 0; i < Project.Instance.L_schemeName.Count; i++)
            {
                tvw_schemeList.Nodes.Add(Project.Instance.L_schemeName[i]);
            }

            if (tvw_schemeList.Nodes.Count > 0)
            {
                tvw_schemeList.SelectedNode = tvw_schemeList.Nodes[0];
                tbx_schemeName.Text = tvw_schemeList.Nodes[0].Text;
            }
        }
        private void tvw_schemeList_Click(object sender, EventArgs e)
        {
            tbx_schemeName.Text = tvw_schemeList.SelectedNode.Text;
        }

        private void btn_copyScheme_Click(object sender, EventArgs e)
        {
            if (tvw_schemeList.SelectedNode.Text == "直通方案")
            {
                FuncLib.ShowMsg("直通方案不可复制，建议从示例方案复制");
                return;
            }
            Scheme.Copy();
        }
        private void btn_createScheme_Click(object sender, EventArgs e)
        {
            Scheme.Create();
        }
        private void btn_inportScheme_Click(object sender, EventArgs e)
        {
            Scheme.Inport();
        }
        private void btn_exportScheme_Click(object sender, EventArgs e)
        {
            Scheme.Export();
        }
        private void btn_deleteScheme_Click(object sender, EventArgs e)
        {
            if (tvw_schemeList.SelectedNode.Text == "示例方案")
            {
                FuncLib.ShowMsg("示例方案不可删除");
                return;
            }
            if (tvw_schemeList.SelectedNode.Text == "直通方案")
            {
                FuncLib.ShowMsg("直通方案不可删除");
                return;
            }
            Scheme.Delete();
        }
        private void btn_moveUpScheme_Click(object sender, EventArgs e)
        {
            Scheme.MoveUp();
        }
        private void btn_moveDownScheme_Click(object sender, EventArgs e)
        {
            Scheme.MoveDown();
        }
        private void tbx_schemeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                string oldSchemeName = tvw_schemeList.SelectedNode.Text;
                //检查是否含有特殊符号
                if (tbx_schemeName.Text.Contains("\\") || tbx_schemeName.Text.Contains("/"))
                {
                    FuncLib.ShowMessageBox("修改失败！方案名不能包含 \\ / 等特殊字符", InfoType.Error);
                    return;
                }

                //删除原方案
                if (File.Exists(string.Format("{0}\\Config\\Project\\Scheme\\{1}.shm", Application.StartupPath, oldSchemeName)))
                {
                    File.SetAttributes(string.Format("{0}\\Config\\Project\\Scheme\\{1}.shm", Application.StartupPath, oldSchemeName), FileAttributes.Normal);
                    new FileInfo(string.Format("{0}\\Config\\Project\\Scheme\\{1}.shm", Application.StartupPath, oldSchemeName)).Attributes = FileAttributes.Normal;
                    File.Delete(string.Format("{0}\\Config\\Project\\Scheme\\{1}.shm", Application.StartupPath, oldSchemeName));
                }
                //更改方案列表当中的方案名
                for (int i = 0; i < Project.Instance.L_schemeName.Count; i++)
                {
                    if (Project.Instance.L_schemeName[i] == oldSchemeName)
                    {
                        Project.Instance.L_schemeName[i] = tbx_schemeName.Text.Trim();
                        break;
                    }
                }

                //更改项目配置的当前方案名
                if (Project.Instance.configuration.curSchemeName == oldSchemeName)
                    Project.Instance.configuration.curSchemeName = tbx_schemeName.Text.Trim();

                //更改当前方案下的工具内绑定的方案名称
                for (int i = 0; i < Project.L_schemeList.Count; i++)
                {
                    if (Project.L_schemeList[i].name == oldSchemeName)
                    {
                        //解决因重命名方案名，导致模板匹配模型句柄无更新方案名称出现问题
                        for (int j = 0; j < Project.L_schemeList[i].L_taskList.Count; j++)  //遍历当前方案下的所有的任务
                        {
                            for (int k = 0; k < Project.L_schemeList[i].L_taskList[j].L_toolList.Count; k++)  //遍历当前任务下的所有工具流程
                            {
                                ToolBase tool = Project.L_schemeList[i].L_taskList[j].L_toolList[k];
                                switch (tool.toolType)
                                {
                                    case ToolType.模板匹配:
                                        MatchTool.D_nccModel = MatchTool.D_nccModel.ToDictionary(item1 => item1.Key.Contains(oldSchemeName) ? item1.Key.Replace(oldSchemeName, tbx_schemeName.Text.Trim()) : item1.Key, item1 => item1.Value);
                                        MatchTool.D_shapeModel = MatchTool.D_shapeModel.ToDictionary(item2 => item2.Key.Contains(oldSchemeName) ? item2.Key.Replace(oldSchemeName, tbx_schemeName.Text.Trim()) : item2.Key, item2 => item2.Value);

                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        Project.L_schemeList[i].name = tbx_schemeName.Text.Trim();
                        break;
                    }
                }

                //将当前方案名称替换为最新的方案名称
                if (Scheme.curScheme.name == oldSchemeName)
                    Scheme.curScheme.name = tbx_schemeName.Text.Trim();

                tvw_schemeList.SelectedNode.Text = tbx_schemeName.Text.Trim();
                Frm_Main.Instance.cbx_schemeList.Items[tvw_schemeList.SelectedNode.Index] = tbx_schemeName.Text.Trim();

                if (Frm_Main.Instance.cbx_schemeList.Text == string.Empty || Frm_Main.Instance.cbx_schemeList.Text == oldSchemeName)
                    Frm_Main.Instance.cbx_schemeList.Text = tbx_schemeName.Text.Trim();

                //保存被修改名称的方案
                Thread th = new Thread(() =>
                {
                    for (int i = 0; i < Project.Instance.L_schemeName.Count; i++)
                    {
                        if (Project.L_schemeList[i].name == tbx_schemeName.Text.Trim())
                        {
                            //序列化方案
                            IFormatter formatter = new BinaryFormatter();
                            Stream stream = new FileStream(string.Format(Application.StartupPath + "\\Temp.shm"), FileMode.OpenOrCreate, FileAccess.Write, FileShare.Delete);
                            try
                            {
                                formatter.Serialize(stream, Project.L_schemeList[i]);
                                stream.Close();

                                //移动方案
                                File.Move(Application.StartupPath + "\\Temp.shm", string.Format(Application.StartupPath + "\\Config\\Project\\Scheme\\{0}.shm", tbx_schemeName.Text.Trim()));
                            }
                            catch
                            {
                                stream.Close();
                                FuncLib.ShowMessageBox("修改失败！原因：未知", InfoType.Error);
                            }
                            break;
                        }
                    }
                });
                th.IsBackground = true;
                th.Start();
            }
        }

    }
}
