using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    [Serializable]
    internal class ServiceBase
    {
        /// <summary>
        /// 服务端名称
        /// </summary>
        internal string name = string.Empty;
        /// <summary>
        /// 是否启用
        /// </summary>
        internal bool enable = true;
        /// <summary>
        /// 服务类型
        /// </summary>
        internal ServiceType serviceType = ServiceType.TCPIPSever;
        /// <summary>
        /// 程序开启后自动连接
        /// </summary>
        public bool autoConnectAfterStart = true;


        /// <summary>
        /// 命名查重
        /// </summary>
        /// <param name="jobName">服务名</param>
        /// <returns>是否已存在</returns>
        internal static bool CheckExist(string serviceName)
        {
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == serviceName)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 连接服务
        /// </summary>
        internal virtual bool Connect() { return false; }
        /// <summary>
        /// 删除
        /// </summary>
        internal static void Delete(string serviceName)
        {
            if (FuncLib.ShowConfirmDialog(string.Format("确定要删除服务 {0} 吗？", serviceName), InfoType.Warn) == DialogResult.OK)
            {
                for (int i = 0; i < Project.Instance.L_Service.Count; i++)
                {
                    if (Project.Instance.L_Service[i].name == serviceName)
                    {
                        switch (Project.Instance.L_Service[i].serviceType)
                        {
                            case ServiceType.Light:
                                foreach (KeyValuePair<string, SerialPort> item in LightBase.L_serialPort)
                                {
                                    if (item.Key == serviceName)
                                    {
                                        LightBase.L_serialPort.Remove(item.Key);
                                        break;
                                    }
                                }
                                break;
                        }

                        Project.Instance.L_Service.RemoveAt(i);
                        Frm_Service.Instance.tvw_serviceList.Nodes.RemoveAt(i);

                        if (Project.Instance.L_Service.Count > 0)
                        {
                            if (i < Project.Instance.L_Service.Count)
                                Frm_Service.Instance.tvw_serviceList.SelectedNode = Frm_Service.Instance.tvw_serviceList.Nodes[i];
                            else
                                Frm_Service.Instance.tvw_serviceList.SelectedNode = Frm_Service.Instance.tvw_serviceList.Nodes[i - 1];
                        }
                        else
                        {
                            Frm_Service.curForm = CurForm.None;
                            Frm_Service.Instance.pnl_seviceBox.Controls.Clear();
                        }

                        FuncLib.ShowMsg(string.Format("服务 [ {0} ] 已删除", serviceName));
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 上移
        /// </summary>
        internal static void MoveUp(string serviceName)
        {
            //首个不可上移
            if (Project.Instance.L_Service[0].name == serviceName)
                return;

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == serviceName)
                {
                    ServiceBase serviceBase = Project.Instance.L_Service[i];
                    Project.Instance.L_Service.RemoveAt(i);
                    Project.Instance.L_Service.Insert(i - 1, serviceBase);

                    TreeNode treeNode = Frm_Service.Instance.tvw_serviceList.SelectedNode;
                    Frm_Service.Instance.tvw_serviceList.Nodes.RemoveAt(i);
                    Frm_Service.Instance.tvw_serviceList.Nodes.Insert(i - 1, treeNode);

                    Frm_Service.Instance.tvw_serviceList.SelectedNode = treeNode;
                    FuncLib.ShowMsg(string.Format("服务 [ {0} ] 已上移", serviceName));
                    break;
                }
            }
        }
        /// <summary>
        /// 下移
        /// </summary>
        internal static void MoveDown(string serviceName)
        {
            //最后一个不可下移
            if (Project.Instance.L_Service[Project.Instance.L_Service.Count - 1].name == serviceName)
                return;

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == serviceName)
                {
                    ServiceBase serviceBase = Project.Instance.L_Service[i];
                    Project.Instance.L_Service.RemoveAt(i);
                    Project.Instance.L_Service.Insert(i + 1, serviceBase);

                    TreeNode treeNode = Frm_Service.Instance.tvw_serviceList.SelectedNode;
                    Frm_Service.Instance.tvw_serviceList.Nodes.RemoveAt(i);
                    Frm_Service.Instance.tvw_serviceList.Nodes.Insert(i + 1, treeNode);

                    Frm_Service.Instance.tvw_serviceList.SelectedNode = treeNode;
                    FuncLib.ShowMsg(string.Format("服务 [ {0} ] 已下移", serviceName));
                    break;
                }
            }
        }
        /// <summary>
        /// 重命名
        /// </summary>
        internal static void Rename(string serviceName)
        {
        Again:
            string newServiceName = FuncLib.ShowInput("请输入新服务名");
            if (newServiceName == string.Empty)
                return;

            //命名查重
            if (CheckExist(newServiceName))
            {
                FuncLib.ShowMessageBox("已存在此名称的服务，服务名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            // 特殊字符检查
            if (newServiceName.Contains(@"\"))
            {
                FuncLib.ShowMessageBox("服务名中不能含有 \\ 特殊字符 ，请重新输入", InfoType.Error);
                goto Again;
            }

            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].name == serviceName)
                {
                    Frm_Service.Instance.tvw_serviceList.SelectedNode.Text = newServiceName;
                    Project.Instance.L_Service[i].name = newServiceName;

                    FuncLib.ShowMsg(string.Format("服务 {0} 已成功更名为：{1}", serviceName, newServiceName), InfoType.Tip);
                    break;
                }
            }
        }

    }

    /// <summary>
    /// 服务类型    TCPIP服务端
    /// </summary>
    internal enum ServiceType
    {
        TCPIPSever,
        TCPIPClient,
        Camera,
        Calibrate,
        SerialPort,
        Light,
        Card,
        FTPDownload,
    }

}
