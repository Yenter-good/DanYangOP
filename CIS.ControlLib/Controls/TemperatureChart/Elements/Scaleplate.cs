using CIS.ControlLib.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 标尺元素
    /// </summary>
    [Serializable]
    public class Scaleplate:Element
    {
        private ElementHostType _HostType = ElementHostType.Grid;
        private float[] _BigTickThickness = new float[] { 1.5F};
        private DocumentViewMode _SupportViewMode = DocumentViewMode.Page;
        /// <summary>
        /// 支持的视图类型
        /// </summary>
        [XmlAttribute]
        public DocumentViewMode SupportViewMode
        {
            get { return this._SupportViewMode; }
            set { this._SupportViewMode = value; }
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
        [XmlAttribute]
        public float TopMargin { get; set; }
        /// <summary>
        /// 开始高度
        /// </summary>
        [XmlIgnore]
        public float StartHeight
        { get; set; }

        /// <summary>
        /// 大刻度宽度
        /// </summary>
        [XmlAttribute]
        public float BigTickWidth
        { get; set; }

        /// <summary>
        /// 小间隔的宽度
        /// </summary>
        [XmlAttribute]
        public float SmallTickWidth
        { get; set; }

        /// <summary>
        /// 小刻度数量
        /// </summary>
        [XmlAttribute]
        public int SmallTickNum
        { get; set; }

        /// <summary>
        /// 小刻度的间隔高度
        /// </summary>
        [XmlAttribute]
        public float IntervelSize
        { get; set; }
        /// <summary>
        /// 标尺长度
        /// </summary>
        [XmlAttribute]
        public float Length
        { get; set; }
        /// <summary>
        /// 小刻度的间隔高度
        /// </summary>
        [XmlIgnore]
        public float SmallTickIntervel
        { get; set; }

        /// <summary>
        /// 大刻度数量
        /// </summary>
        [XmlAttribute]
        public int BigTickNum
        { get; set; }

        /// <summary>
        /// 大刻度粗细
        /// </summary>
        [XmlAttribute]
        public float[] BigTickThickness
        {
            get {
                if(_BigTickThickness==null)
                    return new float[] { 1.5f };
                return _BigTickThickness; }
            set
            {
                if (value == null || value.Length == 0)
                    _BigTickThickness = new float[] { 1.5f };
                _BigTickThickness = value;
            }
        }

        /// <summary>
        /// 大刻度颜色
        /// </summary>
        [XmlIgnore]
        public Color[] BigTickColor
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.BigTickColorString))
                    return null;
                List<System.Drawing.Color> colors = new List<System.Drawing.Color>();
                foreach (string colorname in BigTickColorString.Split(','))
                {
                    try
                    {
                        colors.Add(System.Drawing.ColorTranslator.FromHtml(colorname));
                    }
                    catch { return null; }
                }
                return colors.ToArray();
            }
        }
        [XmlAttribute("BigTickColor")]
        public string BigTickColorString
        {
            get;set;
        }


        /// <summary>
        /// 文本
        /// </summary>
        [XmlAttribute]
        public String[] Text
        { get; set; }

        /// <summary>
        /// 文本样式
        /// </summary>
        [XmlIgnore]
        public Font TextFont
        { get; set; }
        [XmlElement("TextFont")]
        public FontInfo TextFontInfo
        {
            get
            {
                if (TextFont == null)
                    return new FontInfo();
                return new FontInfo(TextFont.Name, TextFont.Size, TextFont.Style);
            }
            set
            {
                if (value == null)
                    TextFont = new Font("宋体", 9f);
                else
                    TextFont = value.GetFont();
            }

        }
        /// <summary>
        /// 文本颜色
        /// </summary>
        [XmlIgnore]
        public Color[] TextColor
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.TextColorString))
                    return null;
                List<System.Drawing.Color> colors = new List<System.Drawing.Color>();
                foreach (string colorname in TextColorString.Split(','))
                {
                    try
                    {
                        colors.Add(System.Drawing.ColorTranslator.FromHtml(colorname));
                    }
                    catch { return null; }
                }
                return colors.ToArray();
            }
        }
        [XmlAttribute("TextColor")]
        public string TextColorString
        {
            get;set;
        }

        /// <summary>
        /// 刻度的方向
        /// </summary>
        [XmlAttribute]
        public Direction TickDirection { get; set; }
        [XmlElement]
        public BorderStyle TopBorder
        { get; set; }
        [XmlElement]
        public BorderStyle LeftBorder
        { get; set; }
        [XmlElement]
        public BorderStyle BottomBorder
        { get; set; }
        [XmlElement]
        public BorderStyle RightBorder
        { get; set; }

        [XmlAttribute("X")]
        public float X { get; set; }
        [XmlAttribute("Y")]
        public float Y { get; set; }

        public Scaleplate()
        {
            this.TopBorder = BorderStyle.Empty;
            this.BottomBorder = BorderStyle.Empty;
            this.LeftBorder = BorderStyle.Empty;
            this.RightBorder = BorderStyle.Empty;

            this.StartHeight = 10;
            this.Height = 100;
            this.BigTickWidth = 20;
            this.BigTickNum = 5;
            this.TickDirection = Direction.Left;
            this.BigTickColorString = "Black";
            this.BigTickThickness = new float[] { 1.5F };
            this.SmallTickNum = 5;
            this.SmallTickIntervel = 3;
            this.SmallTickWidth = 10;
            this.Text = new string[] { "测试1", "测试2", "测试3" };
            this.TextColorString = "Black";
            this.TextFont = new Font("宋体", 9);
        }

    }
    [XmlRoot("BorderStyle")]
    [Serializable]
    public class BorderStyle
    {
        public static readonly BorderStyle Empty = new BorderStyle("",0);
        [XmlIgnore]
        public Color Color
        {
            get
            {
                if (string.IsNullOrEmpty(ColorString)) return Color.Black;
                try { return ColorTranslator.FromHtml(ColorString); } catch { return Color.Black; }
            }
        }
        [XmlAttribute("Color")]
        public string ColorString { get; set; }
        [XmlAttribute("Thickness")]
        public float Thickness { get; set; }
        public BorderStyle() { }
        public BorderStyle(string color,int thickness)
        {
            this.ColorString = color;
            this.Thickness = thickness;
        }
    }
    public enum Direction
    {
        Left,
        Right
    }
    public class ScaleplateRender
    {

        private float bigTickWidth = 10f;
        private float smallTickWidth = 5f;
        Graphics g;
        Scaleplate element;
        public ScaleplateRender(Graphics graphic, Scaleplate scaleplate)
        {
            g = graphic;
            element = scaleplate;
            bigTickWidth = GraphicsHelper.Convert(element.BigTickWidth, GraphicsUnit.Document, g.PageUnit);
            smallTickWidth = GraphicsHelper.Convert(element.SmallTickWidth, GraphicsUnit.Document, g.PageUnit);
            if (element == null)
                throw new Exception("scaleplate is null.");
        }


        public SizeF TextMaxSize;
        public float MaxWidth;

        public void Draw()
        {
            CalculateWidth();
            DrawTick();
            DrawString();
            DrawBorder();
        }
        /// <summary>
        /// 计算宽度
        /// </summary>
        public void CalculateWidth()
        {
            GetTextMaxWidth();
            GetMaxWidth();
        }

        private void GetTextMaxWidth()
        {
            if (element.Text == null) return;
            foreach (string item in element.Text)
            {
                SizeF TextWidth = g.MeasureString(item, element.TextFont);
                if (TextMaxSize.Width < TextWidth.Width)
                {
                    TextMaxSize.Width = TextWidth.Width;
                    TextMaxSize.Height = TextWidth.Height;
                }
            }
            TextMaxSize.Width = TextMaxSize.Width * 1.1F;
        }

        private void GetMaxWidth()
        {
            if (element.Width != 0)
            { MaxWidth = element.Width; return; }
            MaxWidth = TextMaxSize.Width + 1F +bigTickWidth;
        }

        private void DrawTick()
        {
            for (int i = 0; i < element.BigTickNum; i++)
            {
                float BigTickY = i == 0 ? element.StartHeight : element.StartHeight + i * element.SmallTickIntervel * element.SmallTickNum;
                if (element.TickDirection == Direction.Left)
                {
                    using (Brush brush = new SolidBrush(element.BigTickColor[i % element.BigTickColor.Length]))
                        g.FillRectangle(brush, new RectangleF(new PointF(0, BigTickY), new SizeF(bigTickWidth, element.BigTickThickness[i % element.BigTickThickness.Length])));
                }
                else
                {
                    using (Brush brush = new SolidBrush(element.BigTickColor[i % element.BigTickColor.Length]))
                        g.FillRectangle(brush, new RectangleF(new PointF(MaxWidth - bigTickWidth, BigTickY), new SizeF(bigTickWidth, element.BigTickThickness[i % element.BigTickThickness.Length])));
                }
                    for (int j = 1; j < element.SmallTickNum; j++)
                {
                    if (element.TickDirection == Direction.Left)
                        g.FillRectangle(Brushes.Black, new RectangleF(new PointF(0, j * element.SmallTickIntervel + BigTickY), new SizeF(smallTickWidth, 1)));
                    else
                        g.FillRectangle(Brushes.Black, new RectangleF(new PointF(MaxWidth - smallTickWidth, j * element.SmallTickIntervel + BigTickY), new SizeF(smallTickWidth, 1)));
                }
            }

        }

        private void DrawString()
        {
            if (element.Text == null) return;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            for (int i = 0; i < element.Text.Length; i++)
            {
                if (element.TickDirection == Direction.Left)
                    using (Brush brush = new SolidBrush(element.TextColor[i % element.TextColor.Length]))
                        g.DrawString(element.Text[i], element.TextFont, brush, new PointF(bigTickWidth+ 1.0F, element.StartHeight + i * element.SmallTickNum * element.SmallTickIntervel));
                else
                    using (Brush brush = new SolidBrush(element.TextColor[i % element.TextColor.Length]))
                        g.DrawString(element.Text[i], element.TextFont, brush, new PointF(MaxWidth - TextMaxSize.Width - bigTickWidth - 1.0F, element.StartHeight + i * element.SmallTickNum * element.SmallTickIntervel));
            }
        }

        private void DrawBorder()
        {
            using(Brush brush = new SolidBrush(element.TopBorder.Color))
                g.FillRectangle(brush, new RectangleF(new PointF(0, 0), new SizeF(MaxWidth, element.TopBorder.Thickness)));
            using(Brush brush = new SolidBrush(element.LeftBorder.Color))
                g.FillRectangle(brush, new RectangleF(new PointF(0, 0), new SizeF(element.LeftBorder.Thickness, element.Height)));
            using(Brush brush = new SolidBrush(element.RightBorder.Color))
                g.FillRectangle(brush, new RectangleF(new PointF(MaxWidth, 0), new SizeF(element.RightBorder.Thickness, element.Height)));
            using(Brush brush = new SolidBrush(element.BottomBorder.Color))
                g.FillRectangle(brush, new RectangleF(new PointF(0, element.Height), new SizeF(MaxWidth, element.BottomBorder.Thickness)));
        }
    }
}
