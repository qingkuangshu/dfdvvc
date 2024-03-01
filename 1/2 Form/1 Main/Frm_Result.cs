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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Pro
{
    public partial class Frm_Result : Form
    {
        public Frm_Result()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_Result _instance;
        internal static Frm_Result Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Result();
                return _instance;
            }
        }

    }
}
