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

namespace VM_Pro
{
    public partial class Frm_NanChangCTTool : UIForm
    {
        public Frm_NanChangCTTool()
        {
            InitializeComponent();

        }

        private static Frm_NanChangCTTool instance;

        public static Frm_NanChangCTTool Instance
        {
            get
            {
                if (instance==null)
                    instance = new Frm_NanChangCTTool();
                return instance;
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
        internal static NanChangCTTool nanChangCTTool;

    }
}
