using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CIS.ControlLib.Helper;

namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 标签文本类
    /// </summary>
    [Serializable]
    public class LabelInfo : Element, ICloneable
    {
        private System.Drawing.ContentAlignment _TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        private bool _IsMultiLine = true;
        private string _Text = "标签文本";
        private System.Drawing.Color _ForeColor = System.Drawing.Color.Black;
        private System.Drawing.Color _BackColor = System.Drawing.Color.Transparent;
        private Padding _BorderWidth = new Padding(0, 0, 0, 0);
        private Color _BorderColor = Color.Transparent;
        private FontInfo _Font = null;
        private DocumentViewMode _SupportViewMode = DocumentViewMode.Page;
        private ElementHostType _HostType = ElementHostType.Document;
        private string _HostValueFieldName = null;
        private string _ImagePath = null;
        private Image _Image = null;
        /// <summary>
        /// 图片路径
        /// </summary>
        [XmlAttribute()]
        public string ImageSrc
        {
            get { return _ImagePath; }
            set
            {
                _ImagePath = value;
                _Image = null;
            }
        }
        [XmlIgnore]
        public Image Image
        {
           get
            {
                if (this._Image != null)
                    return this._Image;
                if (string.IsNullOrEmpty(this.ImageSrc))
                    return null;
                string filename = System.IO.Path.Combine(Application.StartupPath, this.ImageSrc);
                if (System.IO.File.Exists(filename))
                {
                    using (Image image = Image.FromFile(filename))
                    {
                        this._Image = (Image)image.Clone();
                        return this._Image;
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// 获取或设置边框的大小
        /// </summary>
        [XmlIgnore]
        public Padding BorderWidth
        {
            get { return _BorderWidth; }
            set { _BorderWidth = value; }
        }
        [XmlAttribute("BorderWidth")]
        public string BorderWidthValue
        {
            get { return string.Format("{0},{1},{2},{3}",this.BorderWidth.Left,this.BorderWidth.Top,this.BorderWidth.Right,this.BorderWidth.Bottom); }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.BorderWidth = Padding.Empty;
                }
                else
                {
                    try
                    {
                        var returnValues = value.Split(',');
                        if (returnValues.Length == 1)
                            this.BorderWidth = new Padding(int.Parse(returnValues[0]));
                        else
                            if (returnValues.Length == 2)
                                this.BorderWidth = new Padding(int.Parse(returnValues[0]), int.Parse(returnValues[1]), int.Parse(returnValues[0]), int.Parse(returnValues[1]));
                            else
                                if (returnValues.Length == 4)
                                    this.BorderWidth = new Padding(int.Parse(returnValues[0]), int.Parse(returnValues[1]), int.Parse(returnValues[2]), int.Parse(returnValues[3]));
                    }
                    catch { this.BorderWidth = Padding.Empty; }
                }
            }
        }
        /// <summary>
        /// 获取或设置边框颜色
        /// </summary>
        [XmlIgnore]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; }
        }
        /// <summary>
        /// 用于xml序列化 请使用BackColor获取前景色
        /// </summary>
        [DefaultValue(null), XmlAttribute("BorderColor")]
        public string BorderColorValue
        {
            get { return ColorTranslator.ToHtml(this.BorderColor); }
            set
            {
                try
                {
                    this.BorderColor = ColorTranslator.FromHtml(value);
                }
                catch { this.BorderColor = Color.Black; }
            }
        }
        /// <summary>
        ///  获取或设置指定宿主字段名称
        ///  如果宿主类型为Yaxis 将会参照Y轴刻度值，当做label的Y轴坐标值
        ///  
        /// </summary>
        [XmlAttribute]
        public string HostValueFieldName 
        {
            get { return this._HostValueFieldName; }
            set { this._HostValueFieldName = value; }
        }
       
        /// <summary>
        /// 宿主类型
        /// </summary>
        [XmlAttribute]
        public ElementHostType HostType
        {
            get { return this._HostType; }
            set { this._HostType = value; }
        }
        /// <summary>
        /// 获取或设置文本对齐方式
        /// </summary>
        [DefaultValue(System.Drawing.ContentAlignment.MiddleCenter), XmlAttribute]
        public System.Drawing.ContentAlignment TextAlign
        {
            get
            {
                return _TextAlign;
            }
            set
            {
                _TextAlign = value;
            }
        }
        /// <summary>
        /// 获取或设置是否多行文本
        /// </summary>
        [DefaultValue(true), XmlAttribute]
        public bool IsMultiLine
        {
            get
            {
                return _IsMultiLine ;
            }
            set
            {
                _IsMultiLine = value;
            }
        }
        /// <summary>
        /// 获取或设置标签文本
        /// </summary>
        [DefaultValue("标签文本"), XmlAttribute]
        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }
        /// <summary>
        /// 获取或设置文本颜色
        /// </summary>
        [DefaultValue(typeof(System.Drawing.Color), "Black"), XmlIgnore]
        public System.Drawing.Color ForeColor
        {
            get
            {
                return _ForeColor;
            }
            set
            {
                _ForeColor = value;
            }
        }
        /// <summary>
        /// 用于xml序列化 请使用ForeColor获取前景色
        /// </summary>
        [DefaultValue(null), XmlAttribute("ForeColor")]
        public string ForeColorValue
        {
            get { return ColorTranslator.ToHtml(this.ForeColor); }
            set
            {
                try
                {
                    this.ForeColor = ColorTranslator.FromHtml(value);
                }
                catch { this.ForeColor = Color.Black; }
            }
        }
        /// <summary>
        /// 获取或设置背景色
        /// </summary>
        [DefaultValue(typeof(System.Drawing.Color), "Transparent"), XmlIgnore]
        public System.Drawing.Color BackColor
        {
            get
            {
                return _BackColor;
            }
            set
            {
                _BackColor = value;
            }
        }
        /// <summary>
        /// 用于xml序列化 请使用BackColor获取前景色
        /// </summary>
        [DefaultValue(null), XmlAttribute("BackColor")]
        public string BackColorValue
        {
            get { return ColorTranslator.ToHtml(this.BackColor); }
            set
            {
                try
                {
                    this.BackColor = ColorTranslator.FromHtml(value);
                }
                catch { this.BackColor = Color.Black; }
            }
        }
        /// <summary>
        /// 获取或设置字体
        /// </summary>
        [DefaultValue(null), XmlElement]
        public FontInfo Font
        {
            get
            {
                return _Font;
            }
            set
            {
                _Font = value;
            }
        }
        /// <summary>
        /// 获取或设置标签支持的视图模式
        /// </summary>
        [XmlAttribute]
        public DocumentViewMode SupportViewMode
        {
            get { return this._SupportViewMode; }
            set { this._SupportViewMode = value; }
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }
        [XmlAttribute]
        public float X
        {
            get;
            set;
        }

        [XmlAttribute]
        public float Y
        {
            get;
            set;
        }


        [XmlAttribute]
        public float LabelWidth
        {
            get;
            set;
        }

        [XmlAttribute]
        public float LabelHeight
        {
            get;
            set;
        }

        public void ConverToBound(Graphics g,TemperatureDocument document)
        {
            if (this.HostType == ElementHostType.Document)
            {
                base.Left = document.Left + GraphicsHelper.Convert(this.X, GraphicsUnit.Document, g.PageUnit);
                base.Top = document.Top + GraphicsHelper.Convert(this.Y, GraphicsUnit.Document, g.PageUnit);
                base.Width = GraphicsHelper.Convert(this.LabelWidth, GraphicsUnit.Document, g.PageUnit);
                base.Height = GraphicsHelper.Convert(this.LabelHeight, GraphicsUnit.Document, g.PageUnit);
            }
            else
            {
                if (this.HostType == ElementHostType.Grid)
                {
                    float cellWidth = document.GridRectangle.Width / (document.Ticks.Count * document.RuntimeNumOfDaysInOnePage);
                    float cellHeight = document.GridRectangle.Height / (document.IntervalCount * document.GridVerticalSplitNum + document.GridTopPadding + document.GridBottomPadding);
                    base.Left = document.GridRectangle.Left;
                    base.Top = document.GridRectangle.Top + (cellHeight * document.GridTopPadding);
                    base.Left += cellWidth * this.X;
                    base.Top += cellHeight * this.Y;
                    base.Height = cellHeight * this.LabelHeight;
                    base.Width = this.LabelWidth * cellWidth;
                    return;
                }
                if (!string.IsNullOrEmpty(this.HostValueFieldName))
                {
                    if (this.HostType == ElementHostType.Yaxis && document.YAxisInfos.Exists(y => y.ValueFieldName == this.HostValueFieldName))
                    {
                        var yaxis = document.YAxisInfos.Find(y => y.ValueFieldName == this.HostValueFieldName);
                        base.Top = document.GetY(yaxis, this.Y);
                        base.Left = yaxis.Left;
                        base.Width = yaxis.Width * this.LabelWidth;
                        base.Height = document.GetY(yaxis, this.Y - this.LabelHeight) - base.Top;
                        return;
                    }
                    if (this.HostType == ElementHostType.LineHeader)
                    {
                        TitleLine line = null;
                        if (document.HeaderLines.Exists(h => h.ValueFieldName == this.HostValueFieldName))
                        {
                            line = document.HeaderLines.Find(h => h.ValueFieldName == this.HostValueFieldName);
                        }
                        if (document.FooterLines.Exists(f => f.ValueFieldName == this.HostValueFieldName))
                        {
                            line = document.FooterLines.Find(f => f.ValueFieldName == this.HostValueFieldName);
                        }
                        if (line != null)
                        {
                            var bound = line.GetTitleBound();
                            base.Top = this.Y * bound.Height + bound.Top;
                            base.Left = this.X * bound.Width + bound.Left;
                            base.Height = this.LabelHeight * bound.Height;
                            base.Width = this.LabelWidth * bound.Width;
                            return;
                        }
                    }
                }


                base.Height = 0;

            }
        }
    }
}
