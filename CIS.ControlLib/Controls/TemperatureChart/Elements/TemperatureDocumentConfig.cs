using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using CIS.Utility;

namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 体温单配置类
    /// </summary>
    [ComVisible(false)]
    [Serializable]
    public class TemperatureDocumentConfig:ICloneable
    {
        private string _Version = "2015.5.26.0";
        private float _SymbolSize = 20f;
        private FontInfo _Font = null;
        private FontInfo _TitleFont = null;
        private Color _ForeColor = Color.Black;
        private Color _BackColor = Color.White;
        private Color _BorderColor = Color.Black;
        private Color _GridLineColor = Color.LightGray;
        private Color _GridVerticalSplitLineColor = Color.DarkGray;
        private bool _DrawGridVerticalSplitLineStart= false;
        private bool _DrawGridVerticalSplitLineEnd=false;
        private bool _AutoIndent = true;
        private float _GridVerticalSplitLineWidth = 2;
        private Color _GridHorizontalSplitLineColor = Color.Transparent;
        private int _GridHorizontalSplitInterval = 0;
        private Color _BigSplitLineColor = Color.Red;
        private int _BigSplitLineThickness = 1;
        private int _GridVerticalSplitNum = 10;
        private int _IntervalCount = 5;
        private int _BorderSize = 2;
        private string _DateFormatString = "yyyy-MM-dd";
        private string _Title = null;
        private float _SpecifyTitleHeight = 300;
        private string _FooterDescription = null;
        private int _NumOfDaysInOnePage = 7;
        private DateTime _SpecifyStartDate = TemperatureDocument.NullDate;
        private bool _IsExactTime = false;
        private float _GridTopPadding = 0;
        private float _GridBottomPadding = 0;
        private string _EndDateKeyword = "出院";
        private float _RightEmptySize = 0f;

        private DocumentPageSettings _PageSettings = null;

        private TickInfoList _Ticks = new TickInfoList();
        private HeaderLabelList _HeaderLabels = new HeaderLabelList();
        private TitleLineList _HeaderLines = new TitleLineList();
        private TitleLineList _FooterLines = new TitleLineList();
        private YAxisInfoList _YAxisInfos = new YAxisInfoList();
        private LabelInfoList _LabelInfos = new LabelInfoList();
        private CautionList _Cautions = new CautionList();
        private TokenList _Tokens = new TokenList();
        private ScaleplateList _Scaleplates = new ScaleplateList();

        /// <summary>
        /// 是否绘制开始垂直分隔线
        /// </summary>
        [DefaultValue(false), XmlAttribute]
        public bool DrawGridVerticalSplitLineStart
        {
            get { return this._DrawGridVerticalSplitLineStart; }
            set { this._DrawGridVerticalSplitLineStart = value; }
        }
        /// <summary>
        /// 是否绘制最后垂直分隔线
        /// </summary>
        [DefaultValue(false), XmlAttribute]
        public bool DrawGridVerticalSplitLineEnd
        {
            get { return this._DrawGridVerticalSplitLineEnd; }
            set { this._DrawGridVerticalSplitLineEnd = value; }
        }
        /// <summary>
        /// 获取或设置结束日期的关键字
        /// 用,分隔
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string EndDateKeyword
        {
            get
            {
                return this._EndDateKeyword;
            }
            set
            {
                this._EndDateKeyword = value;
            }
        }
        [XmlElement]
        public string Version
        {
            get { return this._Version; }
            set { this._Version = value; }
        }
        /// <summary>
        /// 自动缩进
        /// 如第一天4点的点 AutoIndent=True 则绘制在边界内
        /// </summary>
        [XmlAttribute("AutoIndent")]
        public bool AutoIndent
        {
            get { return this._AutoIndent; }
            set { this._AutoIndent = value; }
        }
        /// <summary>
        /// 指定开始时间
        /// </summary>
        [DefaultValue(typeof(DateTime), "1980-1-1"), XmlAttribute("SpecifyStartDate")]
        public DateTime SpecifyStartDate
        {
            get { return this._SpecifyStartDate; }
            set { this._SpecifyStartDate = value; }
        }
        /// <summary>
        /// 获取或设置字体信息
        /// </summary>
        [XmlElement("Font"), DefaultValue(null)]
        public FontInfo Font
        {
            get
            {
                if (this._Font == null)
                    this._Font = new FontInfo();
                return this._Font;
            }
            set { this._Font = value; }
        }
        /// <summary>
        /// 获取或设置标题字体信息
        /// </summary>
        [XmlElement("TitleFont"), DefaultValue(null)]
        public FontInfo TitleFont
        {
            get
            {
                if (this._TitleFont == null)
                    this._TitleFont = new FontInfo(this.Font.Name, this.Font.Size * 3, FontStyle.Bold);
                return this._TitleFont;
            }
            set { this._TitleFont = value; }
        }
        /// <summary>
        /// 获取或设置标题区域高度
        /// </summary>
        [XmlElement("SpecifyTitleHeight"), DefaultValue(300)]
        public float SpecifyTitleHeight
        {
            get { return _SpecifyTitleHeight; }
            set { _SpecifyTitleHeight = value; }
        }
        /// <summary>
        /// 获取或设置页脚描述
        /// </summary>
        [XmlElement("FooterDescription"), DefaultValue(null)]
        public string FooterDescription
        {
            get { return _FooterDescription; }
            set { _FooterDescription = value; }
        }
        /// <summary>
        /// 获取或设置页面设置
        /// </summary>
        [XmlElement("PageSettings")]
        public DocumentPageSettings PageSettings
        {
            get
            {
                if (this._PageSettings == null)
                    this._PageSettings = new DocumentPageSettings();
                return this._PageSettings;
            }
            set
            {
                this._PageSettings = value;
            }
        }
        /// <summary>
        /// 获取或设置符号大小
        /// </summary>
        [DefaultValue(10)]
        public float SymbolSize
        {
            get
            {
                return this._SymbolSize;
            }
            set
            {
                this._SymbolSize = value;
            }
        }
        /// <summary>
        /// 获取或设置网格线颜色
        /// </summary>
        [XmlIgnore]
        public Color GridLineColor
        {
            get { return this._GridLineColor; }
            set { this._GridLineColor = value; }
        }
        /// <summary>
        /// 用于xml序列化 请使用GridLineColor
        /// </summary>
        [DefaultValue(null),XmlAttribute("GridLineColor")]
        public string GridLineColorValue
        {
            get { return ColorTranslator.ToHtml(this.GridLineColor); }
            set {
                try { this.GridLineColor = ColorTranslator.FromHtml(value); }
                catch
                {
                    this.GridLineColor = Color.DarkGray;
                }
            }
        }
        /// <summary>
        /// 获取或设置网格垂直分割线颜色
        /// </summary>
        [XmlIgnore]
        public Color GridVerticalSplitLineColor
        {
            get { return this._GridVerticalSplitLineColor; }
            set { this._GridVerticalSplitLineColor = value; }
        }
        /// <summary>
        /// 用于xml序列化 请使用GridVerticalSplitLineColorValue
        /// </summary>
        [DefaultValue(null), XmlAttribute("GridVerticalSplitLineColor")]
        public string GridVerticalSplitLineColorValue
        {
            get { return ColorTranslator.ToHtml(this.GridVerticalSplitLineColor); }
            set
            {
                try { this.GridVerticalSplitLineColor = ColorTranslator.FromHtml(value); }
                catch
                {
                    this.GridVerticalSplitLineColor = Color.LightGray;
                }
            }
        }
        /// <summary>
        /// 获取或设置网格垂直分割线的粗细
        /// </summary>
        [DefaultValue(2)]
        public float GridVerticalSplitLineWidth
        {
            get { return this._GridVerticalSplitLineWidth; }
            set { this._GridVerticalSplitLineWidth = value; }
        }
        /// <summary>
        /// 获取或设置网格水平分割线颜色
        /// </summary>
        [XmlIgnore]
        public Color GridHorizontalSplitLineColor
        {
            get { return this._GridHorizontalSplitLineColor; }
            set { this._GridHorizontalSplitLineColor = value; }
        }
        /// <summary>
        /// 用于xml序列化 请使用GridHorizontalSplitLineColor
        /// </summary>
        [DefaultValue(null), XmlAttribute("GridHorizontalSplitLineColor")]
        public string GridHorizontalSplitLineColorValue
        {
            get { return ColorTranslator.ToHtml(this.GridHorizontalSplitLineColor); }
            set
            {
                try { this.GridHorizontalSplitLineColor = ColorTranslator.FromHtml(value); }
                catch
                {
                    this.GridHorizontalSplitLineColor = Color.LightGray;
                }
            }
        }
        /// <summary>
        /// 获取或设置网格水平分割线的间隔
        /// </summary>
        [DefaultValue(null), XmlAttribute("GridHorizontalSplitInterval")]
        public int GridHorizontalSplitInterval
        {
            get { return this._GridHorizontalSplitInterval; }
            set { this._GridHorizontalSplitInterval = value; }
        }
        /// <summary>
        /// 获取或设置网格上边距
        /// 单位最小格子数
        /// </summary>
        [XmlAttribute]
        public float GridTopPadding
        {
            get { return _GridTopPadding; }
            set { _GridTopPadding = value; }
        }
        /// <summary>
        /// 获取或设置网格下边距
        /// 单位最小格子数
        /// </summary>
        [XmlAttribute]
        public float GridBottomPadding
        {
            get { return _GridBottomPadding; }
            set { _GridBottomPadding = value; }
        }
        /// <summary>
        /// 获取或设置大分割线粗细
        /// </summary>
        [DefaultValue(1), XmlAttribute("BigSplitLineThickness")]
        public int BigSplitLineThickness
        {
            get { return this._BigSplitLineThickness; }
            set { this._BigSplitLineThickness = value; }
        }
        /// <summary>
        /// 获取或设置大分割线颜色
        /// </summary>
        [XmlIgnore]
        public Color BigSplitLineColor
        {
            get { return this._BigSplitLineColor; }
            set { this._BigSplitLineColor = value; }
        }
        /// <summary>
        /// 用于xml序列化 请使用BigSplitLineColor
        /// </summary>
        [DefaultValue(null), XmlAttribute("BigSplitLineColor")]
        public string BigSplitLineColorValue
        {
            get { return ColorTranslator.ToHtml(this.BigSplitLineColor); }
            set
            {
                try { this.BigSplitLineColor = ColorTranslator.FromHtml(value); }
                catch
                {
                    this.BigSplitLineColor = Color.Red;
                }
            }
        }
        /// <summary>
        /// 获取或设置网格垂直分割数量
        /// </summary>
        [DefaultValue(10),XmlAttribute("GridVerticalSplitNum")]
        public int GridVerticalSplitNum
        {
            get { return this._GridVerticalSplitNum; }
            set { this._GridVerticalSplitNum = value; }
        }
        /// <summary>
        /// 获取或设置网格间隔数量
        /// </summary>
        [DefaultValue(5), XmlAttribute("IntervalCount")]
        public int IntervalCount
        {
            get { return this._IntervalCount; }
            set { this._IntervalCount = value; }
        }
        /// <summary>
        /// 获取或设置前景色
        /// </summary>
        [DefaultValue(typeof(Color), "Black"), XmlIgnore]
        public Color ForeColor
        {
            get { return this._ForeColor; }
            set { this._ForeColor = value; }
        }
        /// <summary>
        /// 用于XML序列化 请使用ForeColor
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
                catch
                {
                    this.ForeColor = Color.White;
                }
            }
        }
        /// <summary>
        /// 获取或设置背景色
        /// </summary>
        [DefaultValue(typeof(Color), "White"), XmlIgnore]
        public Color BackColor
        {
            get
            {
                return this._BackColor;
            }
            set
            {
                this._BackColor = value;
            }
        }
        /// <summary>
        /// 用于XML序列化 请使用BackColor
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
                catch
                {
                    this.BackColor = Color.White;
                }
            }
        }
        /// <summary>
        /// 获取或设置边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Black"), XmlIgnore]
        public Color BorderColor
        {
            get { return this._BorderColor; }
            set { this._BorderColor = value; }
        }
        /// <summary>
        /// 用于xml序列化  请使用BorderColor
        /// </summary>
        [DefaultValue(null), XmlAttribute("BorderColor")]
        public string BorderColorValue
        {
            get { return ColorTranslator.ToHtml(this.BorderColor); }
            set {
                try
                {
                    this.BorderColor = ColorTranslator.FromHtml(value);
                }
                catch {
                    this.BorderColor = Color.Black;
                }
            }
        }
        /// <summary>
        /// 获取或设置边框粗细大小
        /// </summary>
        [DefaultValue(2), XmlAttribute("BorderSize")]
        public int BorderSize
        {
            get { return this._BorderSize; }
            set { this._BorderSize = value; }
        }
        /// <summary>
        /// 获取或设置时间格式字符串
        /// </summary>
        [DefaultValue("yyyy-MM-dd")]
        public string DateFormatString
        {
            get
            {
                return this._DateFormatString;
            }
            set
            {
                this._DateFormatString = value;
            }
        }
        /// <summary>
        /// 是否为精确时间值
        /// </summary>
        [XmlAttribute("IsExactTime")]
        public bool IsExactTime
        {
            get { return this._IsExactTime; }
            set { this._IsExactTime = value; }
        }
        /// <summary>
        /// 获取或设置标题文本
        /// </summary>
        [DefaultValue(null), XmlElement("Title")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }
        /// <summary>
        /// 已过时 兼容以前版本,建议使用Ticks
        /// </summary>
        //public string HourTicksValue
        //{
        //    get
        //    {
        //        if (this.Ticks.Count > 0)
        //        {
        //            return string.Join(",", this.Ticks.Select(t => t.Value).ToArray());
        //        }
        //        else
        //            return null;
        //    }
        //    set
        //    {
        //        if (!string.IsNullOrWhiteSpace(value))
        //        {
        //            string[] values = value.Split(',').Distinct().ToArray();
        //            this._Ticks = new TickInfoList();
        //            foreach (var item in values)
        //            {
        //                this._Ticks.Add(new TickInfo(item, Convert.ToSingle(item)));
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// 获取或设置警告信息
        /// </summary>
        [XmlArrayItem("Caution", typeof(Caution))]
        public CautionList Cautions
        {
            get
            {
                if (this._Cautions == null)
                    this._Cautions = new CautionList();
                return this._Cautions;
            }
            set { this._Cautions = value; }
        }
        /// <summary>
        /// 获取或设置标记信息
        /// </summary>
        [XmlArrayItem("Token",typeof(Token))]
        public TokenList Tokens
        {
            get
            {
                if (this._Tokens == null)
                    this._Tokens = new TokenList();
                return this._Tokens;
            }
            set { this._Tokens = value; }
        }
       
        /// <summary>
        /// 获取或设置标尺集合
        /// </summary>
        [XmlArrayItem("Scalepate", typeof(Scaleplate))]
        public ScaleplateList Scalepates
        {
            get
            {
                if (this._Scaleplates == null)
                    this._Scaleplates = new ScaleplateList();
                return this._Scaleplates;
            }
            set
            {
                this._Scaleplates = value;
            }
        }
        /// <summary>
        /// 获取或设置刻度集合
        /// </summary>
        [XmlArrayItem("Tick", typeof(TickInfo))]
        public TickInfoList Ticks
        {
            get
            {
                if (this._Ticks == null)
                    this._Ticks = new TickInfoList();
                return this._Ticks;
            }
            set
            {
                this._Ticks = value;
            }
        }
        /// <summary>
        /// 获取或设置页眉标签集合
        /// </summary>
        [XmlArrayItem("Label", typeof(HeaderLabel))]
        public HeaderLabelList HeaderLabels
        {
            get
            {
                if (this._HeaderLabels == null)
                {
                    this._HeaderLabels = new HeaderLabelList();
                }
                return this._HeaderLabels;
            }
            set
            {
                this._HeaderLabels = value;
            }
        }
        /// <summary>
        /// 获取或设置单页天数
        /// </summary>
        [DefaultValue(7)]
        public int NumOfDaysInOnePage
        {
            get
            {
                return this._NumOfDaysInOnePage;
            }
            set
            {
                this._NumOfDaysInOnePage = value;
            }
        }
        /// <summary>
        /// 获取或设置页眉数据行集合
        /// </summary>
        [XmlArrayItem("Line", typeof(TitleLine))]
        public TitleLineList HeaderLines
        {
            get
            {
                return this._HeaderLines;
            }
            set
            {
                this._HeaderLines = value;
            }
        }
        /// <summary>
        /// 获取或设置页脚数据行集合
        /// </summary>
        [XmlArrayItem("Line", typeof(TitleLine))]
        public TitleLineList FooterLines
        {
            get
            {
                return this._FooterLines;
            }
            set
            {
                this._FooterLines = value;
            }
        }
        /// <summary>
        /// 获取或设置数据标尺集合
        /// </summary>
        [XmlArrayItem("YAxis", typeof(YAxisInfo))]
        public YAxisInfoList YAxisInfos
        {
            get
            {
                if (this._YAxisInfos == null)
                {
                    this._YAxisInfos = new YAxisInfoList();
                }
                return this._YAxisInfos;
            }
            set
            {
                this._YAxisInfos = value;
            }
        }
        /// <summary>
        /// 获取或设置文本标签集合
        /// </summary>
        [XmlArrayItem("Label", typeof(LabelInfo))]
        public LabelInfoList Labels
        {
            get
            {
                if (this._LabelInfos == null)
                    this._LabelInfos = new LabelInfoList();
                return this._LabelInfos;
            }
            set { this._LabelInfos = value; }
        }
        /// <summary>
        /// 获取或设置右边空白区域大小
        /// </summary>
        [XmlAttribute("RightEmptyPadding")]
        public float RightEmptyPadding
        {
            get
            {
                return _RightEmptySize;
            }

            set
            {
                _RightEmptySize = value;
            }
        }

        public object Clone()
        {
            var config = this.Clone<TemperatureDocumentConfig>();
            foreach (var headerLine in config.HeaderLines)
            {
                headerLine.Values.Clear();
            }
            foreach (var footerLine in config.FooterLines)
            {
                footerLine.Values.Clear();
            }
            foreach (var yAxis in config.YAxisInfos)
            {
                yAxis.Values.Clear();
            }
            return config;
        }
        /// <summary>
        /// 加载xml配置信息生成配置对象
        /// </summary>
        /// <param name="xml">xml配置信息</param>
        /// <returns></returns>
        public static TemperatureDocumentConfig LoadXML(string xml)
        {
            return (TemperatureDocumentConfig)XMLHelper.LoadObjectFromXMLString(typeof(TemperatureDocumentConfig), xml);
        }
        /// <summary>
        /// 保存为xml信息
        /// </summary>
        /// <param name="includeValues">是否包含数据点信息</param>
        /// <returns></returns>
        public string SaveXML(bool includeValues=false)
        {
            if (this == null)
                return null;
            if (includeValues)
            {
                return XMLHelper.SaveObjectToIndentXMLString(this);
            }
            else
            {
                return XMLHelper.SaveObjectToIndentXMLString(this.Clone());
            }

        }

        /// <summary>
        /// 获取指定时间所在的日期
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public DateTime GetDate(DateTime time)
        {
            double dHour = time.Subtract(time.Date).TotalHours;
            if (dHour < this.Ticks[0].Value)
                return time.Date.AddDays(-1).Date;
            return time.Date;
        }
        /// <summary>
        /// 获取指定时间所在日期段的最小时间
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="dateOrTime">true为日期类型 false 为时间类型</param>
        /// <returns></returns>
        public DateTime GetMinTime(DateTime time, bool dateOrTime = false)
        {
            DateTime date = time.Date;
            if (!dateOrTime)
                date = this.GetDate(time);
            return date.AddHours(this.Ticks[0].Value);
        }
        /// <summary>
        /// 获取指定时间所在日期段的最大时间
        /// </summary>
        /// <param name="time"></param>
        /// <param name="dateOrTime">true为日期类型 false 为时间类型</param>
        /// <returns></returns>
        public DateTime GetMaxTime(DateTime time, bool dateOrTime = false)
        {
            DateTime date = time.Date;
            if (!dateOrTime)
                date = this.GetDate(time);
            return date.AddDays(1).AddHours(this.Ticks[0].Value);
        }

        public Tuple<DateTime, DateTime> GetTickRange(DateTime date, int tickIndex)
        {
            if (this.Ticks == null || this.Ticks.Count == 0 || tickIndex < 0 || tickIndex > this.Ticks.Count - 1) return null;
            return Tuple.Create<DateTime, DateTime>(date.Date.AddHours(this.Ticks[tickIndex].Value),
                tickIndex == this.Ticks.Count - 1 ? date.Date.AddDays(1).AddHours(this.Ticks[0].Value) : date.Date.AddHours(this.Ticks[tickIndex + 1].Value));
        }

    }
}
