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
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Net;

namespace VM_Pro
{
    public partial class Frm_ProductCount : UIForm
    {
        public Frm_ProductCount()
        {
            InitializeComponent();

            UILineOption option = new UILineOption();
            option.ToolTip.Visible = true;
            option.Title = new UITitle();
            option.Title.Text = "产能统计";
            option.Title.SubText = string.Format("{0} 年{1} 月", DateTime.Now.Year, DateTime.Now.Month);
            option.XAxisType = UIAxisType.DateTime;

            //生产总数曲线
            var series1 = option.AddSeries(new UILineSeries("Line1"));
            for (int i = 1; i < DateTime.Now.Day; i++)
            {
                if (Project.Instance.L_count1.ContainsKey(i - 1))
                    series1.Add(i + "日", Project.Instance.L_count[i - 1].TotalNum);
                else
                    series1.Add(i + "日", -1);
            }
            series1.Symbol = UILinePointSymbol.Square;
            series1.SymbolSize = 4;
            series1.SymbolLineWidth = 2;
            series1.SymbolColor = Color.Blue;

            //OK总数曲线
            var series2 = option.AddSeries(new UILineSeries("Line1"));
            for (int i = 1; i < DateTime.Now.Day; i++)
            {
                if (Project.Instance.L_count1.ContainsKey(i - 1))
                    series2.Add(i + "日", Project.Instance.L_count[i - 1].OKNum);
                else
                    series2.Add(i + "日", -1);
            }
            series2.Symbol = UILinePointSymbol.Square;
            series2.SymbolSize = 4;
            series2.SymbolLineWidth = 2;
            series2.SymbolColor = Color.Green;

            //OK总数曲线
            var series3 = option.AddSeries(new UILineSeries("Line1"));
            for (int i = 1; i < DateTime.Now.Day; i++)
            {
                if (Project.Instance.L_count1.ContainsKey(i - 1))
                    series3.Add(i + "日", Project.Instance.L_count[i - 1].NGNum);
                else
                    series3.Add(i + "日", -1);
            }
            series3.Symbol = UILinePointSymbol.Square;
            series3.SymbolSize = 4;
            series3.SymbolLineWidth = 2;
            series3.SymbolColor = Color.Red;

            //////series = option.AddSeries(new UILineSeries("Line2", Color.Lime));
            //////series.Add(dt.AddHours(3), 3.3);
            //////series.Add(dt.AddHours(4), 2.3);
            //////series.Add(dt.AddHours(5), 2.3);
            //////series.Add(dt.AddHours(6), 1.3);
            //////series.Add(dt.AddHours(7), 2.3);
            //////series.Add(dt.AddHours(8), 4.3);
            //////series.Symbol = UILinePointSymbol.Star;
            //////series.SymbolSize = 4;
            //////series.SymbolLineWidth = 2;
            //////series.SymbolColor = Color.Red;
            //////series.Smooth = true;

            //////option.GreaterWarningArea = new UILineWarningArea(3.5);
            //////option.LessWarningArea = new UILineWarningArea(2.2, Color.Gold);

            //////option.YAxisScaleLines.Add(new UIScaleLine() { Color = Color.Red, Name = "上限", Value = 3.5 });
            //////option.YAxisScaleLines.Add(new UIScaleLine() { Color = Color.Gold, Name = "下限", Value = 2.2 });

            //////option.XAxis.Name = "日期";
            //////option.YAxis.Name = "数值";
            //////option.XAxis.AxisLabel.DateTimeFormat = "yyyy-MM-dd HH:mm";
            //////option.XAxis.AxisLabel.AutoFormat = false;
            //////option.YAxis.AxisLabel.DecimalCount = 1;
            //////option.YAxis.AxisLabel.AutoFormat = false;

            //////option.XAxisScaleLines.Add(new UIScaleLine() { Color = Color.Red, Name = dt.AddHours(3).DateTimeString(), Value = new DateTimeInt64(dt.AddHours(3)) });
            //////option.XAxisScaleLines.Add(new UIScaleLine() { Color = Color.Red, Name = dt.AddHours(6).DateTimeString(), Value = new DateTimeInt64(dt.AddHours(6)) });

            LineChart.SetOption(option);
        }

        /// <summary>
        /// 窗体实例
        /// </summary>
        private static Frm_ProductCount _instance;
        internal static Frm_ProductCount Instance
        {
            get
            {
                return new Frm_ProductCount();
            }
        }

    }
}
