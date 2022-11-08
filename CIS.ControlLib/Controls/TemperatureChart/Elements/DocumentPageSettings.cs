using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Xml.Serialization;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    [Serializable]
    public class DocumentPageSettings 
    {
        private string _PaperSizeName = "A4";
        private int intPaperWidth = 827;
        private int intPaperHeight = 1169;
        private int _LeftMargin = 100;
        private int _TopMargin = 100;
        private int _RightMargin = 100;
        private int _BottomMargin = 100;
        private bool bolLandscape = false;
        [XmlElement("PaperSizeName"), DefaultValue("A4")]
        public string PaperSizeName
        {
            get
            {
                return this._PaperSizeName;
            }
            set
            {
                this._PaperSizeName = value;
            }
        }
        [XmlElement("PaperWidth"), DefaultValue(827)]
        public int PaperWidth
        {
            get
            {
                return this.intPaperWidth;
            }
            set
            {
                this.intPaperWidth = value;
            }
        }
        [XmlElement("PaperHeight"), DefaultValue(1169)]
        public int PaperHeight
        {
            get
            {
                return this.intPaperHeight;
            }
            set
            {
                this.intPaperHeight = value;
            }
        }
        [XmlElement("LeftMargin"), DefaultValue(100)]
        public int LeftMargin
        {
            get
            {
                return this._LeftMargin;
            }
            set
            {
                this._LeftMargin = value;
            }
        }
        [XmlElement("TopMargin"), DefaultValue(100)]
        public int TopMargin
        {
            get
            {
                return this._TopMargin;
            }
            set
            {
                this._TopMargin = value;
            }
        }
        [XmlElement("RightMargin"), DefaultValue(100)]
        public int RightMargin
        {
            get
            {
                return this._RightMargin;
            }
            set
            {
                this._RightMargin = value;
            }
        }
        [XmlElement("BottomMargin"), DefaultValue(100)]
        public int BottomMargin
        {
            get
            {
                return this._BottomMargin;
            }
            set
            {
                this._BottomMargin = value;
            }
        }
        [XmlElement("Landscape"), DefaultValue(false)]
        public bool Landscape
        {
            get
            {
                return this.bolLandscape;
            }
            set
            {
                this.bolLandscape = value;
            }
        }
        [Browsable(false),XmlIgnore]
        public Rectangle Bounds
        {
            get
            {
                Rectangle result;
                if (this.Landscape)
                {
                    result = new Rectangle(0, 0, this.PaperHeight, this.PaperWidth);
                }
                else
                {
                    result = new Rectangle(0, 0, this.PaperWidth, this.PaperHeight);
                }
                return result;
            }
        }
        public void WriteTo(PageSettings ps)
        {
            if (ps != null)
            {
                ps.PaperSize = new PaperSize(this.PaperSizeName, this.PaperWidth, this.PaperHeight);
                ps.Landscape = this.Landscape;
                ps.Margins = new Margins(this.LeftMargin, this.RightMargin, this.TopMargin, this.BottomMargin);
            }
        }
        public void ReadFrom(PageSettings ps)
        {
            if (ps != null)
            {
                this.PaperSizeName = ps.PaperSize.PaperName;
                this.PaperWidth = ps.PaperSize.Width;
                this.PaperHeight = ps.PaperSize.Height;
                this.LeftMargin = ps.Margins.Left;
                this.TopMargin = ps.Margins.Top;
                this.RightMargin = ps.Margins.Right;
                this.BottomMargin = ps.Margins.Bottom;
                this.Landscape = ps.Landscape;
            }
        }
    }
}