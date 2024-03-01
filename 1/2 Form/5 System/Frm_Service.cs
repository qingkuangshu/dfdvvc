using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using System.IO;
using System.Reflection;
using MvCamCtrl.NET;

namespace VM_Pro
{
    public partial class Frm_Service : Form
    {
        public Frm_Service()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Service _instance;
        internal static Frm_Service Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Service();
                return _instance;
            }
        }
        /// <summary>
        /// 当前窗体类型
        /// </summary>
        internal static CurForm curForm = CurForm.None;


        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!Permission.CheckPermission(PermissionGrade.Developer))
                return;

            btn_add.ShowContextMenuStrip(uiContextMenuStrip1, 0, btn_add.Height);
        }

        private void 运动控制卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Again:
            string name = FuncLib.ShowInput("请定义一个 控制卡 的名称", "运动控制卡");
            if (name == string.Empty)
                return;

            //命名查重
            if (ServiceBase.CheckExist(name))
            {
                FuncLib.ShowMessageBox("已存在此名称的服务，服务名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            CCard cCard = new CCard(name);
            Project.Instance.L_Service.Add(cCard);

            TreeNode treeNode = tvw_serviceList.Nodes.Add(name);
            tvw_serviceList.SelectedNode = treeNode;
            tvw_serviceList.SetNodeTipsText(treeNode, " ", cCard.Connected ? Color.Green : Color.Red, cCard.Connected ? Color.Green : Color.Red);
            treeNode.ImageIndex = 1;
        }






        private void 相机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Again:
            string name = FuncLib.ShowInput("请定义一个 相机 的名称", "");
            if (name == string.Empty)
                return;

            //命名查重
            if (ServiceBase.CheckExist(name))
            {
                FuncLib.ShowMessageBox("已存在此名称的服务，服务名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            CCamera camera = new CCamera(name);
            Project.Instance.L_Service.Add(camera);


            TreeNode treeNode = tvw_serviceList.Nodes.Add(name);
            tvw_serviceList.SelectedNode = treeNode;
            tvw_serviceList.SetNodeTipsText(treeNode, " ", camera.Connected ? Color.Green : Color.Red, camera.Connected ? Color.Green : Color.Red);
            treeNode.ImageIndex = 0;
        }
        private void 相机标定toolStripMenuItem_Click(object sender, EventArgs e)
        {
        Again:
            string name = FuncLib.ShowInput("请定义一个 相机标定 的名称");
            if (name == string.Empty)
                return;

            //命名查重
            if (ServiceBase.CheckExist(name))
            {
                FuncLib.ShowMessageBox("已存在此名称的服务，服务名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            Calibrate calibrate = new Calibrate(name);
            Project.Instance.L_Service.Add(calibrate);

            Frm_Calibrate.ShowPar(calibrate);
            TreeNode treeNode = tvw_serviceList.Nodes.Add(name);
            tvw_serviceList.SelectedNode = treeNode;
            tvw_serviceList.SetNodeTipsText(treeNode, " ", Color.Red, Color.Red);
            treeNode.ImageIndex = 2;
        }
        private void tCPIP服务端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Again:
            string name = FuncLib.ShowInput("请定义一个 TCP/IP 服务端的名称");
            if (name == string.Empty)
                return;

            //命名查重
            if (ServiceBase.CheckExist(name))
            {
                FuncLib.ShowMessageBox("已存在此名称的服务，服务名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            TCPSever tcpSever = new TCPSever(name);
            Project.Instance.L_Service.Add(tcpSever);

            Frm_TCPServer.ShowPar(tcpSever);
            TreeNode treeNode = tvw_serviceList.Nodes.Add(name);
            tvw_serviceList.SelectedNode = treeNode;
            tvw_serviceList.SetNodeTipsText(treeNode, " ", Color.Red, Color.Red);
            treeNode.ImageIndex = 3;
        }

        private void tvw_serviceList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //停止刷新板卡状态
            Frm_Card.keepUpdate = false;

            //停止相机实时
            for (int i = 0; i < Project.Instance.L_Service.Count; i++)
            {
                if (Project.Instance.L_Service[i].serviceType == ServiceType.Camera)
                    CCamera.FindCamera(Project.Instance.L_Service[i].name).loopGrab = false;
            }

            switch (Project.FindServiceByName(tvw_serviceList.SelectedNode.Text).serviceType)
            {
                case ServiceType.TCPIPSever:
                    Frm_TCPServer.ShowPar(Project.FindServiceByName(tvw_serviceList.SelectedNode.Text));
                    break;
                case ServiceType.TCPIPClient:
                    Frm_TCPClient.ShowPar(Project.FindServiceByName(tvw_serviceList.SelectedNode.Text));
                    break;
                case ServiceType.Camera:
                    Frm_Camera.ShowPar(Project.FindServiceByName(tvw_serviceList.SelectedNode.Text));
                    break;
                case ServiceType.Calibrate:
                    Frm_Calibrate.ShowPar(Project.FindServiceByName(tvw_serviceList.SelectedNode.Text));
                    break;
                case ServiceType.SerialPort:
                    Frm_Serial.ShowPar(Project.FindServiceByName(tvw_serviceList.SelectedNode.Text));
                    break;
                case ServiceType.Light:
                    Frm_Light.ShowPar(Project.FindServiceByName(tvw_serviceList.SelectedNode.Text));
                    break;
                case ServiceType.Card:
                    Frm_Card.ShowPar(Project.FindServiceByName(tvw_serviceList.SelectedNode.Text));
                    break;
                case ServiceType.FTPDownload:
                    Frm_FTPDownload.ShowPar(Project.FindServiceByName(tvw_serviceList.SelectedNode.Text));
                    break;
            }
        }
        private void Frm_Service_Load(object sender, EventArgs e)
        {
            if (tvw_serviceList.SelectedNode == null && tvw_serviceList.Nodes.Count > 0)
                tvw_serviceList.SelectedNode = tvw_serviceList.Nodes[0];

            //显示状态
            for (int i = 0; i < tvw_serviceList.Nodes.Count; i++)
            {
                switch (Project.FindServiceByName(tvw_serviceList.Nodes[i].Text).serviceType)
                {
                    case ServiceType.TCPIPSever:
                        if (Project.FindServiceByName(tvw_serviceList.Nodes[i].Text).enable)
                        {
                            if (TCPSever.FindSeverByName(tvw_serviceList.Nodes[i].Text).listend)
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Green, Color.Green);
                            else
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Red, Color.Red);
                        }
                        else
                        {
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.LightGray, Color.LightGray);
                        }
                        tvw_serviceList.Nodes[i].ImageIndex = 3;
                        break;
                    case ServiceType.TCPIPClient:
                        if (Project.FindServiceByName(tvw_serviceList.Nodes[i].Text).enable)
                        {
                            if (TCPClient.FindClientByName(tvw_serviceList.Nodes[i].Text).Connected)
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Green, Color.Green);
                            else
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Red, Color.Red);
                        }
                        else
                        {
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.LightGray, Color.LightGray);
                        }
                        tvw_serviceList.Nodes[i].ImageIndex = 4;
                        break;
                    case ServiceType.Camera:
                        if (Project.FindServiceByName(tvw_serviceList.Nodes[i].Text).enable)
                        {
                            if (((CCamera)Project.FindServiceByName(tvw_serviceList.Nodes[i].Text)).Connected)
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Green, Color.Green);
                            else
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Red, Color.Red);
                        }
                        else
                        {
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.LightGray, Color.LightGray);
                        }
                        tvw_serviceList.Nodes[i].ImageIndex = 0;
                        break;
                    case ServiceType.Calibrate:
                        if (Project.FindServiceByName(tvw_serviceList.Nodes[i].Text).enable)
                        {
                            if (((Calibrate)Project.FindServiceByName(tvw_serviceList.Nodes[i].Text)).calibrated)
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Green, Color.Green);
                            else
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Red, Color.Red);
                        }
                        else
                        {
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.LightGray, Color.LightGray);
                        }
                        tvw_serviceList.Nodes[i].ImageIndex = 2;
                        break;
                    case ServiceType.Light:
                        if (Project.FindServiceByName(tvw_serviceList.Nodes[i].Text).enable)
                        {
                            if (((LightService)Project.FindServiceByName(tvw_serviceList.Nodes[i].Text)).Connected)
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Green, Color.Green);
                            else
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Red, Color.Red);
                        }
                        else
                        {
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.LightGray, Color.LightGray);
                        }
                        tvw_serviceList.Nodes[i].ImageIndex = 6;
                        break;
                    case ServiceType.Card:
                        if (Project.FindServiceByName(tvw_serviceList.Nodes[i].Text).enable)
                        {
                            if (((CCard)Project.FindServiceByName(tvw_serviceList.Nodes[i].Text)).Connected)
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Green, Color.Green);
                            else
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Red, Color.Red);
                        }
                        else
                        {
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.LightGray, Color.LightGray);
                        }
                        tvw_serviceList.Nodes[i].ImageIndex = 1;
                        break;
                    case ServiceType.SerialPort:
                        if (Project.FindServiceByName(tvw_serviceList.Nodes[i].Text).enable)
                        {
                            //////if (((Serial)Project.FindServiceByName(tvw_serviceList.Nodes[i].Text)))
                            //////    tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Green, Color.Green);
                            //////else
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Red, Color.Red);
                        }
                        else
                        {
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.LightGray, Color.LightGray);
                        }
                        tvw_serviceList.Nodes[i].ImageIndex = 5;
                        break;
                    case ServiceType.FTPDownload:
                        if (Project.FindServiceByName(tvw_serviceList.Nodes[i].Text).enable)
                        {
                            if (((FTPDownload)Project.FindServiceByName(tvw_serviceList.Nodes[i].Text)).IsConnect)
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Green, Color.Green);
                            else
                                tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.Red, Color.Red);
                        }
                        else
                        {
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.Nodes[i], " ", Color.LightGray, Color.LightGray);
                        }
                        tvw_serviceList.Nodes[i].ImageIndex = 5;
                        break;
                }
            }
        }
        private void 启用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project.FindServiceByName(tvw_serviceList.SelectedNode.Text).enable = !Project.FindServiceByName(tvw_serviceList.SelectedNode.Text).enable;

            //显示状态
            if (Project.FindServiceByName(tvw_serviceList.SelectedNode.Text).enable)
            {
                switch (Project.FindServiceByName(tvw_serviceList.SelectedNode.Text).serviceType)
                {
                    case ServiceType.TCPIPSever:
                        if (TCPSever.FindSeverByName(tvw_serviceList.SelectedNode.Text).listend)
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.SelectedNode, " ", Color.Green, Color.Green);
                        else
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.SelectedNode, " ", Color.Red, Color.Red);
                        break;
                    case ServiceType.TCPIPClient:
                        if (TCPClient.FindClientByName(tvw_serviceList.SelectedNode.Text).Connected)
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.SelectedNode, " ", Color.Green, Color.Green);
                        else
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.SelectedNode, " ", Color.Red, Color.Red);
                        break;
                    case ServiceType.Camera:
                        if (((CCamera)Project.FindServiceByName(tvw_serviceList.SelectedNode.Text)).Connected)
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.SelectedNode, " ", Color.Green, Color.Green);
                        else
                            tvw_serviceList.SetNodeTipsText(tvw_serviceList.SelectedNode, " ", Color.Red, Color.Red);
                        break;
                }
            }
            else
            {
                tvw_serviceList.SetNodeTipsText(tvw_serviceList.SelectedNode, " ", Color.LightGray, Color.LightGray);
            }
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceBase.Delete(tvw_serviceList.SelectedNode.Text);
        }
        private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceBase.MoveUp(tvw_serviceList.SelectedNode.Text);
        }
        private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceBase.MoveDown(tvw_serviceList.SelectedNode.Text);
        }
        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceBase.Rename(tvw_serviceList.SelectedNode.Text);
        }
        private void uiContextMenuStrip2_Paint(object sender, PaintEventArgs e)
        {
            if (Project.FindServiceByName(tvw_serviceList.SelectedNode.Text).enable)
                启用ToolStripMenuItem.Text = "禁用";
            else
                启用ToolStripMenuItem.Text = "启用";
        }
        private void tCPIP客户端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Again:
            string name = FuncLib.ShowInput("请定义一个 TCP/IP 客户端的名称");
            if (name == string.Empty)
                return;

            //命名查重
            if (ServiceBase.CheckExist(name))
            {
                FuncLib.ShowMessageBox("已存在此名称的服务，服务名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            TCPClient tcpClient = new TCPClient(name);
            Project.Instance.L_Service.Add(tcpClient);

            Frm_TCPClient.ShowPar(tcpClient);
            TreeNode treeNode = tvw_serviceList.Nodes.Add(name);
            tvw_serviceList.SelectedNode = treeNode;
            tvw_serviceList.SetNodeTipsText(treeNode, " ", Color.Red, Color.Red);
            treeNode.ImageIndex = 4;
        }
        private void 串口通讯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Again:
            string name = FuncLib.ShowInput("请定义一个串口通讯的名称", "测试串口");
            if (name == string.Empty)
                return;

            //命名查重
            if (ServiceBase.CheckExist(name))
            {
                FuncLib.ShowMessageBox("已存在此名称的服务，服务名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            Serial serialPort = new Serial(name);
            Project.Instance.L_Service.Add(serialPort);

            Frm_Serial.ShowPar(serialPort);
            TreeNode treeNode = tvw_serviceList.Nodes.Add(name);
            tvw_serviceList.SelectedNode = treeNode;
            tvw_serviceList.SetNodeTipsText(treeNode, " ", Color.Red, Color.Red);
            treeNode.ImageIndex = 5;
        }
        private void 光源控制器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Again:
            string name = FuncLib.ShowInput("请定义一个 光源控制器 的名称", "光源控制器");
            if (name == string.Empty)
                return;

            //命名查重
            if (ServiceBase.CheckExist(name))
            {
                FuncLib.ShowMessageBox("已存在此名称的服务，服务名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            LightService lightService = new LightService(name);
            Project.Instance.L_Service.Add(lightService);

            TreeNode treeNode = tvw_serviceList.Nodes.Add(name);
            tvw_serviceList.SelectedNode = treeNode;
            tvw_serviceList.SetNodeTipsText(treeNode, " ", lightService.Connected ? Color.Green : Color.Red, lightService.Connected ? Color.Green : Color.Red);
            treeNode.ImageIndex = 6;
        }
        private void fTP下载服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Again:
            string name = FuncLib.ShowInput("请定义一个FTP下载服务的名称", "FTP");
            if (name == string.Empty)
                return;

            //命名查重
            if (ServiceBase.CheckExist(name))
            {
                FuncLib.ShowMessageBox("已存在此名称的服务，服务名不可重复，请重新输入", InfoType.Error);
                goto Again;
            }

            FTPDownload ftpDownload = new FTPDownload(name);
            Project.Instance.L_Service.Add(ftpDownload);

            Frm_FTPDownload.ShowPar(ftpDownload);
            TreeNode treeNode = tvw_serviceList.Nodes.Add(name);
            tvw_serviceList.SelectedNode = treeNode;
            tvw_serviceList.SetNodeTipsText(treeNode, " ", Color.Red, Color.Red);
            treeNode.ImageIndex = 5;
        }
    }
}
