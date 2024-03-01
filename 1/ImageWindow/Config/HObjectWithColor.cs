using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewROI.Config
{
    /// <summary>
    /// 显示xld和region 带有颜色
    /// </summary>
    class HObjectWithColor
    {
        private HObject hObject;
        private string color;
        private string draw;    //加填充区域

        public HObjectWithColor(HObject _hbj, string _color,string _Draw= "margin") //加填充区域
        {
            hObject = _hbj;
            color = _color;
            draw = _Draw;
        }

        public HObject HObject
        {
            get { return hObject; }
            set { hObject = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public string Draw  //加填充区域
        {
            get { return draw; }
            set { draw = value; }
        }
    }

    class HTextWithColor
    {
        private HTuple hText;
        private HTuple color;
        private HTuple row;
        private HTuple col;
        private HTuple coordSystem;


        public HTextWithColor(HTuple _hText, string _color, HTuple _row, HTuple _col, HTuple _coordSystem, int size, string font, HTuple bold, HTuple slant)
        {
            hText = _hText;
            color = _color;
            row = _row;
            col = _col;
            coordSystem = _coordSystem;
            this.Size = size;
            this.Font = font;
            this.Bold = bold;
            this.Slant = slant;
        }
        public int Size { get; set; }
        public string Font { get; set; }
        public HTuple Bold { get; set; }
        public HTuple Slant { get; set; }

        public HTuple HText
        {
            get { return hText; }
            set { hText = value; }
        }
        public HTuple Row
        {
            get { return row; }
            set { row = value; }
        }
        public HTuple Col
        {
            get { return col; }
            set { col = value; }
        }
        public HTuple Color
        {
            get { return color; }
            set { color = value; }
        }
        public HTuple CoordSystem
        {
            get { return coordSystem; }
            set { coordSystem = value; }
        }
    }
}
