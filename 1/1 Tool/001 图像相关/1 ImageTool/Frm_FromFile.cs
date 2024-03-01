using System;
using System.Threading;
using System.Windows.Forms;
using Sunny.UI;
namespace VM_Pro
{
    public partial class Frm_FromFile : UIPage
    {
        public Frm_FromFile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 工具对象
        /// </summary>
        internal static ImageTool acqImageTool;
        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static Frm_FromFile _instance;
        internal static Frm_FromFile Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_FromFile();
                return _instance;
            }
        }

        private void tbx_imagePath_TextChanged(object sender, EventArgs e)
        {
            acqImageTool.imagePath = this.tbx_imagePath.Text.Trim();
        }

        private void tbx_imagePath_KeyUp(object sender, KeyEventArgs e)
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
        private void btn_loopGrab_Click(object sender, EventArgs e)
        {
            acqImageTool.SelectImage();
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
