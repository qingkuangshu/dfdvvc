using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_User : UIPage
    {
        public Frm_User()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_User _instance;
        internal static Frm_User Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_User();
                return _instance;
            }
        }

    }
}
