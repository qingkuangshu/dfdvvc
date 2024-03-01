using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Sunny.UI;

namespace VM_Pro
{
    public partial class Frm_FromDirectory : UIPage
    {
        public Frm_FromDirectory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 保存图像的路径
        /// </summary>
        private static string savePath = string.Empty;
        /// <summary>
        /// 工具对象
        /// </summary>
        internal static ImageTool acqImageTool;
        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static Frm_FromDirectory _instance;
        internal static Frm_FromDirectory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_FromDirectory();
                return _instance;
            }
        }

        private void tbx_imageDirectoryPath_TextChanged(object sender, EventArgs e)
        {
            acqImageTool.imageDirectoryPath = tbx_imageDirectoryPath.Text.Trim();
        }
        private void tbx_imageDirectoryPath_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                if (Clipboard.ContainsText())
                {
                    ((TextBox)sender).Text = Clipboard.GetText().Trim();
                }
            }

            if (e.KeyData == (Keys.Control | Keys.C))
            {
                Clipboard.SetDataObject(((TextBox)sender).Text);
            }
        }
        private void btn_lastOne_Click(object sender, EventArgs e)
        {
            acqImageTool.LastImage();
        }
        private void btn_nextOne_Click(object sender, EventArgs e)
        {
            acqImageTool.NextImage();
        }
        private void btn_selectDirectory_Click(object sender, EventArgs e)
        {
            acqImageTool.SelectDirectory();
        }
        private void btn_retureToFirst_Click(object sender, EventArgs e)
        {
            acqImageTool.currentImageIndex = acqImageTool.L_imagePath.Count - 1;
            Thread th = new Thread(() =>
            {
                acqImageTool.Run();
            });
            th.IsBackground = true;
            th.Start();
        }
        private void btn_removeCurrent_Click(object sender, EventArgs e)
        {
            File.Delete(acqImageTool.L_imagePath[acqImageTool.currentImageIndex]);
            acqImageTool.currentImageIndex--;
            Thread th = new Thread(() =>
            {
                acqImageTool.Run();
            });
            th.IsBackground = true;
            th.Start();
        }
        private void btn_browseImage_Click(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            if (Directory.Exists(acqImageTool.imageDirectoryPath))
            {
                Frm_ImageTool.Instance.TopMost = false;
                Process.Start(acqImageTool.imageDirectoryPath);
            }
            else
            {
                Frm_ImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                Frm_ImageTool.Instance.lbl_toolTip.Text = "请先指定图像目录路径";
            }
        }
        private void ckb_absPath_CheckedChanged(object sender, EventArgs e)
        {
            acqImageTool.absPath = ckb_absPath.Checked;
        }
        private void ckb_rotateImage_CheckedChanged(object sender, EventArgs e)
        {
            if (Frm_ImageTool.openingForm)
                return;

            acqImageTool.rotateImageForLocal = ckb_rotateImage.Checked;
            acqImageTool.currentImageIndex--;
            Thread th = new Thread(() =>
            {
                acqImageTool.Run();
            });
            th.IsBackground = true;
            th.Start();

            nud_rotateAngle.Visible = acqImageTool.rotateImageForLocal;
            uiLabel2.Visible = acqImageTool.rotateImageForLocal;
        }
        private void nud_rotateAngle_ValueChanged(double value)
        {
            acqImageTool.rotateAngleForLocal = (int)value;
        }

    }
}
