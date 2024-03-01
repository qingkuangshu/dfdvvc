using HalconDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChoiceTech.Halcon.Control;
using System.Drawing;
using ViewWindow.Model;

namespace VM_Pro
{
    [Serializable]
    /// <summary>
    /// 工具基类
    /// </summary>
    internal class ToolBase
    {

        /// <summary>
        /// 流程失败是否仍然运行工具
        /// </summary>
        internal bool taskFailKeepRun = false;
        /// <summary>
        /// 工具参数
        /// </summary>
        internal ToolParBase 参数 = null;
        /// <summary>
        /// 输入项集合
        /// </summary>
        internal List<InputItem> L_inputItem = new List<InputItem>();
        /// <summary>
        /// 工具输出项类型集合
        /// </summary>
        internal List<DataType> L_OutItemType = new List<DataType>();
        /// <summary>
        /// 工具运行耗时
        /// </summary>
        internal long elapsedTime = 0;
        /// <summary>
        /// 所绑定的图像窗口名称
        /// </summary>
        internal string windowName = "无";
        /// <summary>
        /// 条码规则
        /// </summary>
        internal string codeRule = string.Empty;
        /// <summary>
        /// 被复制的工具
        /// </summary>
        internal static ToolBase toolCopied = null;
        /// <summary>
        /// 工具名
        /// </summary>
        internal string toolName = string.Empty;
        /// <summary>
        /// 任务名
        /// </summary>
        internal string taskName = string.Empty;
        /// <summary>
        /// 工具类型
        /// </summary>
        internal ToolType toolType = ToolType.采集图像;
        /// <summary>
        /// 工具是否启用
        /// </summary>
        internal bool enable = true;
        /// <summary>
        /// 工具运行状态
        /// </summary>
        internal string toolRunStatu = "未运行";

        /// <summary>
        /// 显示图像
        /// </summary>
        /// <param name="image"></param>
        internal void DispImage(HObject image)
        {
            try
            {
                if (image == null)
                    return;
                GetImageWindow().HobjectToHimage(image);

                HTuple row, col, width, height;
                HOperatorSet.GetWindowExtents(GetImageWindowBack(), out row, out col, out width, out height);
                HTuple width1, height1;
                HOperatorSet.GetImageSize(image, out width1, out height1);
                if (width.I != width1.I || height.I != height1.I)
                    HOperatorSet.SetWindowExtents(GetImageWindowBack(), 0, 0, width1, height1);

                HOperatorSet.DispObj(image, GetImageWindowBack());
            }
            catch
            {
                // GetImageWindow().HobjectToHimage(image); 异常待解决
            }
        }
        /// <summary>
        /// 清除图像
        /// </summary>
        internal void ClearWindow()
        {
            GetImageWindow().ClearWindow();

            string totalWindowName = windowName;
            if (totalWindowName == "无")
                totalWindowName = Task.FindTaskByName(taskName).windowName;

            if (Project.D_backImageWindow.ContainsKey(totalWindowName))
                HOperatorSet.ClearWindow(GetImageWindowBack());
        }
        /// <summary>
        /// 设置显示区域
        /// </summary>
        internal void SetPart(HTuple row1, HTuple col1, HTuple row2, HTuple col2)
        {
            HOperatorSet.SetPart(GetImageWindow().HWindowHalconID, row1, col1, row2, col2);
            HOperatorSet.SetPart(GetImageWindowBack(), row1, col1, row2, col2);
        }
        /// <summary>
        /// 显示文本
        /// </summary>
        internal void DispText(HTuple hv_String, int size, HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box, string coordSystem = "image")
        {
            HalconLib.DispText(GetImageWindow().HWindowHalconID, hv_String, size, hv_Row, hv_Column, hv_Color, hv_Box, coordSystem);
            //HalconLib.DispText(GetImageWindowBack(), hv_String, size * 5, hv_Row, hv_Column, hv_Color, hv_Box, coordSystem);
        }


        /// <summary>
        /// 显示对象
        /// </summary>
        /// <param name="obj"></param>
        internal void DispObj(HObject obj, string color)
        {
            if (obj == null)
                return;
            GetImageWindow().DispObj(obj, color);
            HOperatorSet.SetColor(GetImageWindowBack(), color);
            HOperatorSet.SetLineWidth(GetImageWindowBack(), 3);
            HOperatorSet.DispObj(obj, GetImageWindowBack());
        }
        /// <summary>
        /// 获取图像窗体句柄
        /// </summary>
        /// <returns></returns>
        internal HWindow_Final GetImageWindow()
        {
            string totalWindowName = windowName;
            if (totalWindowName == "无")
                totalWindowName = Task.FindTaskByName(taskName).windowName;

            if (totalWindowName == Project.Instance.configuration.windowName[0])
                return Frm_Vision.Instance.hWindow_Final1;
            else if (totalWindowName == Project.Instance.configuration.windowName[1])
                return Frm_Vision.Instance.hWindow_Final2;
            else if (totalWindowName == Project.Instance.configuration.windowName[2])
                return Frm_Vision.Instance.hWindow_Final3;
            else if (totalWindowName == Project.Instance.configuration.windowName[3])
                return Frm_Vision.Instance.hWindow_Final4;
            else if (totalWindowName == Project.Instance.configuration.windowName[4])
                return Frm_Vision.Instance.hWindow_Final5;
            else if (totalWindowName == Project.Instance.configuration.windowName[5])
                return Frm_Vision.Instance.hWindow_Final6;
            else if (totalWindowName == Project.Instance.configuration.windowName[6])
                return Frm_Vision.Instance.hWindow_Final7;
            else if (totalWindowName == Project.Instance.configuration.windowName[7])
                return Frm_Vision.Instance.hWindow_Final8;
            else if (totalWindowName == Project.Instance.configuration.windowName[8])
                return Frm_Vision.Instance.hWindow_Final9;
            else if (totalWindowName == Project.Instance.configuration.windowName[9])
                return Frm_Vision.Instance.hWindow_Final10;
            else if (totalWindowName == Project.Instance.configuration.windowName[10])
                return Frm_Vision.Instance.hWindow_Final11;
            else if (totalWindowName == Project.Instance.configuration.windowName[11])
                return Frm_Vision.Instance.hWindow_Final12;
            else if (totalWindowName == Project.Instance.configuration.windowName[12])
                return Frm_Vision.Instance.hWindow_Final13;
            else if (totalWindowName == Project.Instance.configuration.windowName[13])
                return Frm_Vision.Instance.hWindow_Final14;
            else if (totalWindowName == Project.Instance.configuration.windowName[14])
                return Frm_Vision.Instance.hWindow_Final15;
            else if (totalWindowName == Project.Instance.configuration.windowName[15])
                return Frm_Vision.Instance.hWindow_Final16;
            else
            {
                Task.FindTaskByName(taskName).windowName = Project.Instance.configuration.windowName[0];
                return Frm_Vision.Instance.hWindow_Final1;
            }
        }
        /// <summary>
        /// 获取图像窗体句柄
        /// </summary>
        /// <returns></returns>
        internal HTuple GetImageWindowBack()
        {
            string totalWindowName = windowName;
            if (totalWindowName == "无")
                totalWindowName = Task.FindTaskByName(taskName).windowName; //根据当前任务名，找到绑定的窗口名字
            return Project.D_backImageWindow[totalWindowName];
        }
        /// <summary>
        /// 复制工具
        /// </summary>
        /// <typeparam name="Task"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        internal static ToolBase Clone<ToolBase>(ToolBase source)
        {
            if (!typeof(ToolBase).IsSerializable)
            {
                throw new ArgumentException("深拷贝失败", "source");
            }

            if (Object.ReferenceEquals(source, null))
            {
                return default(ToolBase);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (ToolBase)formatter.Deserialize(stream);
            }
        }
        /// <summary>
        /// 复制
        /// </summary>
        internal static void Copy(TreeView treeView)
        {
            if (treeView.SelectedNode == null)
                return;

            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolName == treeView.SelectedNode.Text)
                {
                    toolCopied = ToolBase.Clone(Task.curTask.L_toolList[i]);
                    break;
                }
            }
            FuncLib.ShowMsg(string.Format("工具 {0} 已复制，等待粘贴插入", toolCopied.toolName), InfoType.Tip);
        }
        /// <summary>
        /// 粘贴
        /// </summary>
        internal static void Paste(TreeView treeView)
        {
            if (toolCopied == null)
            {
                FuncLib.ShowMsg("尚未复制，请复制后粘贴", InfoType.Error);
                return;
            }

        //输入新的工具名称
        Again:
            string newToolName = FuncLib.ShowInput("请输入新工具名");
            if (newToolName == string.Empty)
                return;

            //命名查重
            if (Task.CheckToolExist(newToolName))
            {
                FuncLib.ShowMessageBox("已存在此名称的工具，工具名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            // 特殊字符检查
            if (newToolName.Contains(@"\"))
            {
                FuncLib.ShowMessageBox("工具名中不能含有 \\ 特殊字符 ，请重新输入", InfoType.Error);
                goto Again;
            }

            MoveTreeView move = (MoveTreeView)Convert.ToInt32(treeView.Tag);
            TreeNode node = treeView.GetNodeAt(Frm_Task.clickToolPos);

            //修改流程名以及流程中所有工具的名称
            ToolBase toolBase;
            toolBase = ToolBase.Clone(toolCopied);
            toolBase.toolName = newToolName;

            if (node == null)        //在尾部追加
            {
                Task.curTask.L_toolList.Insert(Task.curTask.L_toolList.Count, toolBase);
                treeView.Nodes.Insert(Task.curTask.L_toolList.Count, new TreeNode(newToolName));
            }
            else        //在中间插入
            {
                Task.curTask.L_toolList.Insert(treeView.SelectedNode.Index, toolBase);
                treeView.Nodes.Insert(treeView.SelectedNode.Index, new TreeNode(newToolName));
            }
            FuncLib.ShowMsg(string.Format("工具已粘贴插入，新工具名：{0}", toolCopied.toolName), InfoType.Tip);
        }
        /// <summary>
        /// 删除
        /// </summary>
        internal static void Delete(TreeView treeView)
        {
            if (treeView.SelectedNode == null)
                return;

            if (FuncLib.ShowConfirmDialog(string.Format("确定要删除工具 {0} 吗？", treeView.SelectedNode.Text), InfoType.Warn) == DialogResult.OK)
            {
                for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
                {
                    if (Task.curTask.L_toolList[i].toolName == treeView.SelectedNode.Text)
                    {
                        //移除模板匹配的模板
                        if (Task.curTask.L_toolList[i].toolType == ToolType.模板匹配)
                        {
                            if (MatchTool.D_nccModel.ContainsKey(string.Format("{0}.{1}.{2}", Scheme.curScheme.name, Task.curTask.name, Task.curTask.L_toolList[i].toolName)))
                            {
                                MatchTool.D_nccModel.Remove(string.Format("{0}.{1}.{2}", Scheme.curScheme.name, Task.curTask.name, Task.curTask.L_toolList[i].toolName));
                                //break;    //会导致删除模板匹配工具需要删两次才能去掉
                            }
                            if (MatchTool.D_shapeModel.ContainsKey(string.Format("{0}.{1}.{2}", Scheme.curScheme.name, Task.curTask.name, Task.curTask.L_toolList[i].toolName)))
                            {
                                MatchTool.D_shapeModel.Remove(string.Format("{0}.{1}.{2}", Scheme.curScheme.name, Task.curTask.name, Task.curTask.L_toolList[i].toolName));
                                //break;    //会导致删除模板匹配工具需要删两次才能去掉
                            }
                        }

                        FuncLib.ShowMsg(string.Format("工具 {0} 已删除", treeView.SelectedNode.Text), InfoType.Tip);
                        Task.curTask.L_toolList.RemoveAt(i);
                        treeView.Nodes.RemoveAt(i);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }
                }
            }
        }
        /// <summary>
        /// 重命名
        /// </summary> 
        internal static void Rename(TreeView treeView)
        {
            if (Task.curTask == null)
                return;

            if (Task.curTask.L_toolList.Count == 0)
                return;

            Again:
            string newToolName = FuncLib.ShowInput("请输入新工具名");
            if (newToolName == string.Empty)
                return;

            //命名查重
            if (Task.CheckToolExist(newToolName))
            {
                FuncLib.ShowMessageBox("已存在此名称的工具，工具名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            // 特殊字符检查
            if (newToolName.Contains(@"\"))
            {
                FuncLib.ShowMessageBox("工具名中不能含有 \\ 特殊字符 ，请重新输入", InfoType.Error);
                goto Again;
            }

            //更新工具名称
            string oldToolName = treeView.SelectedNode.Text;
            for (int i = 0; i < Task.curTask.L_toolList.Count; i++)
            {
                if (Task.curTask.L_toolList[i].toolName == oldToolName)
                {
                    treeView.SelectedNode.Text = newToolName;
                    Task.curTask.L_toolList[i].toolName = newToolName;
                    break;
                }
            }

            //更新工具的链入名称，该工具可能作为别的工具输入项，此时也应该把输入项来源更新一下
            for (int j = 0; j < Task.curTask.L_toolList.Count; j++)
            {
                for (int k = 0; k < Task.curTask.L_toolList[j].L_inputItem.Count; k++)
                {
                    if (Task.curTask.L_toolList[j].L_inputItem[k].sourceTool == oldToolName)
                    {
                        InputItem item = Task.curTask.L_toolList[j].L_inputItem[k];
                        item.sourceTool = newToolName;
                        Task.curTask.L_toolList[j].L_inputItem[k] = item;
                    }
                }
            }



            FuncLib.ShowMsg(string.Format("工具 {0} 已成功更名为：{1}", oldToolName, newToolName), InfoType.Tip);
        }
        /// <summary>
        /// 复位工具
        /// </summary>
        internal virtual void ResetTool() { }
        /// <summary>
        /// 刷新输入输出
        /// </summary>
        internal void UpdateInput()
        {
            for (int i = 0; i < L_inputItem.Count; i++)
            {
                object value = Task.GetValue(Task.FindTaskByName(L_inputItem[i].sourceTask).FindToolByName(L_inputItem[i].sourceTool).参数, L_inputItem[i].sourceOutput);
                Task.sssetValue(参数, L_inputItem[i].InputName, value);
            }
        }
        /// <summary>
        /// 运行工具
        /// </summary>
        /// <param name="initRun"></param>
        internal virtual void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1) { }


        #region 工具链接操作

        /// <summary>
        /// 根据当前的工具类型，获取当前工具可以链入的区域工具列表
        /// </summary>
        /// <param name="ToolingName">当前工具名称</param>
        /// <returns></returns>
        internal List<string> LianRuRegionToolNames(string ToolingName)
        {
            List<string> lstToolsName = new List<string>();

            int toolsCount = Task.curTask.L_toolList.Count;
            switch (toolType)
            {
                case ToolType.创建区域:
                    //将可能存在的连入选择打印出来
                    for (int i = 0; i < toolsCount; i++)
                    {
                        if (Task.curTask.L_toolList[i].toolType == ToolType.模板匹配)
                        {
                            lstToolsName.Add(Task.curTask.L_toolList[i].toolName);
                        }
                        else if (Task.curTask.L_toolList[i].toolName == ToolingName)
                        {
                            break;
                        }
                    }
                    break;


                case ToolType.推理识别:
                case ToolType.图像预处理:
                    //将可能存在的连入选择打印出来
                    for (int i = 0; i < toolsCount; i++)
                    {
                        if (Task.curTask.L_toolList[i].toolType == ToolType.创建区域 ||
                            Task.curTask.L_toolList[i].toolType == ToolType.图像预处理)
                        {
                            lstToolsName.Add(Task.curTask.L_toolList[i].toolName);
                        }
                        else if (Task.curTask.L_toolList[i].toolName == ToolingName)
                        {
                            break;
                        }
                    }
                    break;
                case ToolType.码类识别:
                    for (int i = 0; i < toolsCount; i++)
                    {
                        if (Task.curTask.L_toolList[i].toolType == ToolType.创建区域 ||
                            Task.curTask.L_toolList[i].toolType == ToolType.图像预处理 ||
                            Task.curTask.L_toolList[i].toolType == ToolType.图像脚本)
                        {
                            lstToolsName.Add(Task.curTask.L_toolList[i].toolName);
                        }
                        else if (Task.curTask.L_toolList[i].toolName == ToolingName)
                        {
                            break;
                        }
                    }
                    break;
                case ToolType.图像脚本:
                    for (int i = 0; i < toolsCount; i++)
                    {
                        lstToolsName.Add(Task.curTask.L_toolList[i].toolName);
                    }
                    break;
                default:
                    break;
            }


            return lstToolsName;
        }
        /// <summary>
        /// 根据当前的工具类型，获取当前工具可以链入的图像工具列表
        /// </summary>
        /// <param name="ToolingName">当前工具名称</param>
        /// <returns></returns>
        internal List<string> LianRuImgToolNames(string ToolingName)
        {
            List<string> lstToolsName = new List<string>();


            int toolsCount = Task.curTask.L_toolList.Count;
            switch (toolType)
            {
                case ToolType.图像预处理:
                    //将可能存在的连入选择打印出来
                    for (int i = 0; i < toolsCount; i++)
                    {
                        if (Task.curTask.L_toolList[i].toolType == ToolType.采集图像
                          || Task.curTask.L_toolList[i].toolType == ToolType.图像预处理
                          || Task.curTask.L_toolList[i].toolType == ToolType.推理识别)
                        {
                            lstToolsName.Add(Task.curTask.L_toolList[i].toolName);
                        }
                        else if (Task.curTask.L_toolList[i].toolName == ToolingName)
                        {
                            break;
                        }
                    }
                    break;
                case ToolType.码类识别:
                    for (int i = 0; i < toolsCount; i++)
                    {
                        if (Task.curTask.L_toolList[i].toolType == ToolType.采集图像
                          || Task.curTask.L_toolList[i].toolType == ToolType.图像预处理
                          || Task.curTask.L_toolList[i].toolType == ToolType.图像脚本)
                        {
                            lstToolsName.Add(Task.curTask.L_toolList[i].toolName);
                        }
                        else if (Task.curTask.L_toolList[i].toolName == ToolingName)
                        {
                            break;
                        }
                    }
                    break;

                case ToolType.以太网发:
                    for (int i = 0; i < toolsCount; i++)
                    {
                        if (Task.curTask.L_toolList[i].toolType == ToolType.码类识别)
                        {
                            lstToolsName.Add(Task.curTask.L_toolList[i].toolName);
                        }
                        else if (Task.curTask.L_toolList[i].toolName == ToolingName)
                        {
                            break;
                        }
                    }
                    break;
                case ToolType.存储图像:
                    for (int i = 0; i < toolsCount; i++)
                    {
                        if (Task.curTask.L_toolList[i].toolType == ToolType.码类识别
                            || Task.curTask.L_toolList[i].toolType == ToolType.以太网发)
                        {
                            lstToolsName.Add(Task.curTask.L_toolList[i].toolName);
                        }
                        else if (Task.curTask.L_toolList[i].toolName == ToolingName)
                        {
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }


            return lstToolsName;

        }


        /// <summary>
        /// 根据链入的数据类型，获取当前任务下，可能被链入的工具名称集合
        /// </summary>
        /// <param name="currentLianRuType"></param>
        /// <returns></returns>
        internal List<string> LianRuToolNames(params DataType[] currentLianRuType)
        {
            List<string> lstToolsName = new List<string>();
            int toolsCount = Task.curTask.L_toolList.Count;
            for (int i = 0; i < toolsCount; i++)
            {
                if (Task.curTask.L_toolList[i].toolName == toolName)    //只显示在链入工具前可能被链入的工具
                    break;
                for (int j = 0; j < Task.curTask.L_toolList[i].L_OutItemType.Count; j++)  //遍历当前工具的所有输出
                {
                    for (int k = 0; k < currentLianRuType.Length; k++)
                    {
                        if (Task.curTask.L_toolList[i].L_OutItemType[j] == currentLianRuType[k])
                        {
                            lstToolsName.Add(Task.curTask.L_toolList[i].toolName);
                            break;
                        }
                    }
                }
            }
            return lstToolsName;
        }


        /// <summary>
        /// 删除工具的输入项
        /// </summary>
        /// <param name="strType">删除的类型，文本、图像、区域....</param>
        /// <returns></returns>
        internal bool DelToolIO(String strType)
        {
            for (int i = 0; i < L_inputItem.Count; i++)
            {
                if (L_inputItem[i].InputName == "文本")
                {
                    L_inputItem.RemoveAt(i);
                    break;
                }
            }
            return true;
        }

        #endregion

    }

    /// <summary>
    /// 工具类型
    /// </summary>
    public enum ToolType
    {
        采集图像,
        图像处理,
        通道转换,
        存储图像,
        模板匹配,
        尺寸测量,
        斑点分析,
        图像比对,
        图像特征,
        码类识别,
        字符识别,
        字符校验,
        胶路检测,
        排线检测,
        测量标定,
        手眼标定,
        引用标定,
        顶部定位,
        底部定位,
        对位贴合二,
        循环控制,
        条件分支,
        查找直线,
        查找圆形,
        拟合直线,
        拟合圆形,
        两点中点,
        点点距离,
        点线距离,
        线线角度,
        线线距离,
        线线交点,
        创建区域,
        光源控制,
        PLC_通讯,
        以太网收,
        以太网发,
        高度测量,
        外部输出,
        模型训练,
        推理识别,
        自定义处理,
        图像预处理,
        南昌CT,
        生产计数,
        图像脚本,
        相机IO输出,
    }


}
