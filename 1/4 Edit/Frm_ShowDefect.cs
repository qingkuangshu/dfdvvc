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
using HalconDotNet;

namespace VM_Pro
{
    public partial class Frm_ShowDefect : UIForm
    {
        public Frm_ShowDefect()
        {
            InitializeComponent();
        }

        private static Frm_ShowDefect instance;

        internal static Frm_ShowDefect Instance
        {

            get
            {
                if (instance == null)
                    instance = new Frm_ShowDefect();
                return instance;
            }
        }

        internal bool hasShown = false;
        private void Frm_ShowDefect_FormClosing(object sender, FormClosingEventArgs e)
        {
            hasShown = false;
            this.Hide();
            Frm_Debug.Instance.ckb_ShowDefect.Checked = false;
            e.Cancel = true;
        }



        /// <summary>
        /// 根据传入的缺陷名称，以及图片显示到空闲的HW控件当中
        /// </summary>
        /// <param name="defectName"></param>
        /// <param name="defectImg"></param>
        internal void ShowDefect(string defectName, HObject region, HObject defectImg)
        {
            HOperatorSet.ReadImage(out HObject img, "d:\\a.jpg");
            if (!Instance.hWindow_Final21.Visible)
            {
                Instance.hWindow_Final25.Visible = true;
                Instance.hWindow_Final21.Visible = true;

                //显示实时缺陷
                hWindow_Final21.viewWindow.displayImage(img);
                hWindow_Final21.DispText(defectName, "red", "top", "left", 16);
                hWindow_Final21.DispImageFit();
                hWindow_Final21.Select();


                //模板缺陷
                ShowMuBanDefect(defectName, hWindow_Final25);
            }
            else if (!Instance.hWindow_Final22.Visible)
            {
                Instance.hWindow_Final22.Visible = true;
                Instance.hWindow_Final26.Visible = true;

                //显示实时缺陷
                hWindow_Final22.viewWindow.displayImage(img);
                hWindow_Final22.DispText(defectName, "red", "top", "left", 16);
                hWindow_Final22.DispImageFit();
                //hWindow_Final21.viewWindow.displayImage(defectImg);

                //模板缺陷
                ShowMuBanDefect(defectName, hWindow_Final26);

            }

        }


        /// <summary>
        /// 显示模板缺陷
        /// </summary>
        /// <param name="defectName"></param>
        /// <param name="hw"></param>
        internal void ShowMuBanDefect(string defectName, ChoiceTech.Halcon.Control.HWindow_Final2 hw)
        {
            if (ckb_NoShuaXin.Checked)
                return;
            switch (defectName)
            {
                case "黑点":
                    hw.viewWindow.displayImage(HeiDian);
                    break;
                case "划痕":
                    hw.viewWindow.displayImage(HuaHen);
                    break;
                case "漏铜":
                    hw.viewWindow.displayImage(LouTong);
                    break;
                case "破洞":
                    hw.viewWindow.displayImage(PoDong);
                    break;
                case "黄胶黄标":
                    hw.viewWindow.displayImage(HuangJiao);
                    break;
                case "直边余料":
                    hw.viewWindow.displayImage(ZhiBian);
                    break;
                case "褶皱":
                    hw.viewWindow.displayImage(ZheZhou);
                    break;
                default:
                    break;
            }
            hw.DispText(defectName, "red", "top", "left", 16);
            hw.DispImageFit();
        }


        /// <summary>
        /// 隐藏窗体
        /// </summary>
        internal void HideHWindow()
        {
            if (hWindow_Final21.Visible)
            {
                hWindow_Final21.ClearWindow();
                hWindow_Final21.Visible = false;
            }
            if (hWindow_Final22.Visible)
            {
                hWindow_Final22.ClearWindow();
                hWindow_Final22.Visible = false;
            }
            if (hWindow_Final23.Visible)
            {
                hWindow_Final23.ClearWindow();
                hWindow_Final23.Visible = false;
            }
            if (hWindow_Final24.Visible)
            {
                hWindow_Final24.ClearWindow();
                hWindow_Final24.Visible = false;
            }
            if (!ckb_NoShuaXin.Checked)
            {
                if (hWindow_Final25.Visible)
                {
                    hWindow_Final25.ClearWindow();
                    hWindow_Final25.Visible = false;
                }
                if (hWindow_Final26.Visible)
                {
                    hWindow_Final26.ClearWindow();
                    hWindow_Final26.Visible = false;
                }
                if (hWindow_Final27.Visible)
                {
                    hWindow_Final27.ClearWindow();
                    hWindow_Final27.Visible = false;
                }
                if (hWindow_Final28.Visible)
                {
                    hWindow_Final28.ClearWindow();
                    hWindow_Final28.Visible = false;
                }
            }
        }

        HObject HuangJiao, HeiDian, PoDong, LouTong, ZhiBian, HuaHen, ZheZhou;

        /// <summary>
        /// 是否勾选当前模板不刷新选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckb_NoShuaXin_Click(object sender, EventArgs e)
        {
            if (ckb_NoShuaXin.Checked)
            {
                hWindow_Final25.Visible = hWindow_Final26.Visible = hWindow_Final27.Visible = hWindow_Final28.Visible = true;
                hWindow_Final25.viewWindow.displayImage(LouTong);
                hWindow_Final25.DispText("漏金属", "red", "top", "left", 16);
                hWindow_Final25.DispImageFit();

                hWindow_Final26.viewWindow.displayImage(HeiDian);
                hWindow_Final26.DispText("黑点", "red", "top", "left", 16);
                hWindow_Final26.DispImageFit();

                hWindow_Final27.viewWindow.displayImage(PoDong);
                hWindow_Final27.DispText("破洞", "red", "top", "left", 16);
                hWindow_Final27.DispImageFit();

                hWindow_Final28.viewWindow.displayImage(ZheZhou);
                hWindow_Final28.DispText("褶皱", "red", "top", "left", 16);
                hWindow_Final28.DispImageFit();
            }
        }

        /// <summary>
        /// 双击文本框导入对应的图片信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiTextBox7_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                UITextBox txt = (UITextBox)sender;

                System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                openFileDialog.Title = "请选择图像文件路径";
                openFileDialog.Filter = "图像文件(*.*)|*.*|图像文件(*.jpg)|*.jpg|图像文件(*.png)|*.png|图像文件(*.bmp)|*.bmp|图像文件(*.tif)|*.tif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    switch (txt.TagString)
                    {
                        case "黄胶黄标":
                            HOperatorSet.ReadImage(out HuangJiao, openFileDialog.FileName);
                            Project.Instance.HuangJiaoPath = openFileDialog.FileName;
                            break;
                        case "黑点":
                            HOperatorSet.ReadImage(out HeiDian, openFileDialog.FileName);
                            Project.Instance.HeiDianPath = openFileDialog.FileName;
                            break;
                        case "破洞":
                            HOperatorSet.ReadImage(out PoDong, openFileDialog.FileName);
                            Project.Instance.PoDongPath = openFileDialog.FileName;
                            break;
                        case "漏金属":
                            HOperatorSet.ReadImage(out LouTong, openFileDialog.FileName);
                            Project.Instance.LouTongPath = openFileDialog.FileName;
                            break;
                        case "直边余料":
                            HOperatorSet.ReadImage(out ZhiBian, openFileDialog.FileName);
                            Project.Instance.ZhiBianPath = openFileDialog.FileName;
                            break;
                        case "划痕":
                            HOperatorSet.ReadImage(out HuaHen, openFileDialog.FileName);
                            Project.Instance.HuaHenPath = openFileDialog.FileName;
                            break;
                        case "褶皱":
                            HOperatorSet.ReadImage(out ZheZhou, openFileDialog.FileName);
                            Project.Instance.ZheZhouPath = openFileDialog.FileName;
                            break;
                        default:
                            UIMessageTip.ShowError("未找到该类：" + txt.TagString);
                            return;
                    }
                    txt.Text = openFileDialog.FileName;
                    UIMessageTip.ShowOk("导入成功");
                }

            }
            catch (Exception ex)
            {
                FuncLib.ShowMessageBox("导入链接出现异常：" + ex.Message);
            }
        }

        private void Frm_ShowDefect_Load(object sender, EventArgs e)
        {
            uiTextBox1.Text = Project.Instance.HuangJiaoPath;
            uiTextBox2.Text = Project.Instance.HeiDianPath;
            uiTextBox3.Text = Project.Instance.PoDongPath;
            uiTextBox4.Text = Project.Instance.LouTongPath;
            uiTextBox5.Text = Project.Instance.ZhiBianPath;
            uiTextBox6.Text = Project.Instance.HuaHenPath;
            uiTextBox7.Text = Project.Instance.ZheZhouPath;

            HOperatorSet.ReadImage(out HuangJiao, Project.Instance.HuangJiaoPath);
            HOperatorSet.ReadImage(out HeiDian, Project.Instance.HeiDianPath);
            HOperatorSet.ReadImage(out PoDong, Project.Instance.PoDongPath);
            HOperatorSet.ReadImage(out LouTong, Project.Instance.LouTongPath);
            HOperatorSet.ReadImage(out ZhiBian, Project.Instance.ZhiBianPath);
            HOperatorSet.ReadImage(out HuaHen, Project.Instance.HuaHenPath);
            HOperatorSet.ReadImage(out ZheZhou, Project.Instance.ZheZhouPath);
        }
    }
}
