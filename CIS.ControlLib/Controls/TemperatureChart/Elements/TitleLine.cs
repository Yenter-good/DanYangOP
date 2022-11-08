using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 标题行元素类
    /// </summary>
    [Serializable]
    public class TitleLine : Element
    {
        private string _Name = null;
        private string _Title = null;
        private System.Drawing.ContentAlignment _TitleTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        private DateTime _StartDate = TemperatureDocument.NullDate;
        private string _StartDateKeyword = null;
        private DateTime _RuntimeStartDate = TemperatureDocument.NullDate;
        private TitleLineValueType _ValueType = TitleLineValueType.SerialDate;
        private TitleLineLayoutType _LoayoutType = TitleLineLayoutType.Normal;
        private bool _SizeToFit = false;

        private bool _AddUpMode = false;
        private string _DataSourceName = null;
        private string _ValueFieldName = null;
        private string _TimeFieldName = null;
        private string _Union = null;
        private string _WarnKeyWords = null;
        private string _Group = null;
        private ValuePointList _Values = new ValuePointList();
        private FontInfo _TitleFont = null;
        private float _SpecifyTitleWidth = 0;
        private float _SpecifyHeight = 0;
        private System.Drawing.Color _TitleForeColor = System.Drawing.Color.Empty;
        private System.Drawing.Color _TitleBackColor = System.Drawing.Color.Empty;
        private System.Drawing.Color _TextColor = System.Drawing.Color.Empty;

        private string _KeyDateString = "术日,II-0,III-0";
        private int _AllowKeyDateDays = 14;
        private TitleLineCountType _CountType = TitleLineCountType.PreIsDenominator;
        private int _TickStep = 6;
        private TitleLineUpDownType _UpDownType = TitleLineUpDownType.None;
        private string _CircleText = null;
        private string _SeparatorChar = ",";
        private bool _ShowSeparatorLine = false;
        //值类型为none 设置Loop相关属性才有效 
        private string[] _loopText = new string[] { "上午,下午" }; //循环文本
        private System.Drawing.Color[] _loopForeColor = null; //循环文本前景色
        private System.Drawing.Color[] _loopBackgroundColor = null; //循环文本背景色

        /// <summary>
        /// 是否累计关键词次数
        /// </summary>
        [XmlAttribute("AddUpMode")]
        public bool AddUpMode
        {
            get { return _AddUpMode; }
            set { _AddUpMode = value; }
        }
        [XmlIgnore]
        public string[] LoopText
        {
            get { return this.LoopTextString.AsNotNullString().Split(','); }
        }
        [XmlAttribute("LoopText")]
        public string LoopTextString { get; set; }
        /// <summary>
        /// 循环前景色
        /// </summary>
        [XmlIgnore]
        public System.Drawing.Color[] LoopForeColors
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.LoopForeColorString))
                    return null;
                List<System.Drawing.Color> colors = new List<System.Drawing.Color>();
                foreach (string colorname in LoopForeColorString.Split(','))
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
        [XmlAttribute("LoopForeColors")]
        public string LoopForeColorString { get; set; }
        /// <summary>
        /// 循环背景色
        /// </summary>
        [XmlIgnore]
        public System.Drawing.Color[] LoopBackgroundColors
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.LoopBackgroundColorString))
                    return null;
                List<System.Drawing.Color> colors = new List<System.Drawing.Color>();
                foreach (string colorname in LoopBackgroundColorString.Split(','))
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
        [XmlAttribute("LoopBackgroundColors")]
        public string LoopBackgroundColorString { get; set; }
        /// <summary>
        /// 标题区的宽度
        /// </summary>
        internal float TitleWidth = 0;
        /// <summary>
        /// 获取或设置分隔符号
        /// </summary>
        [XmlAttribute]
        public string SeparatorChar
        {
            get { return this._SeparatorChar; }
            set { this._SeparatorChar = value; }
        }
        /// <summary>
        /// 是否字体大小自适应
        /// </summary>
        [XmlAttribute]
        public bool SizeToFit
        {
            get { return this._SizeToFit; }
            set { this._SizeToFit = value; }
        }
        /// <summary>
        /// 获取或设置是否显示分隔线
        /// </summary>
        [XmlAttribute]
        public bool ShowSeparatorLine
        {
            get { return this._ShowSeparatorLine; }
            set { this._ShowSeparatorLine = value; }
        }
        /// <summary>
        /// 获取或设置标题行的名称
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }
        /// <summary>
        /// 获取或设置标题行的标题
        /// </summary>
        [DefaultValue(null), XmlAttribute]
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
        /// 获取或设置标题栏的对齐方式
        /// </summary>
        [DefaultValue(System.Drawing.ContentAlignment.MiddleCenter), XmlAttribute]
        public System.Drawing.ContentAlignment TitleTextAlign
        {
            get { return this._TitleTextAlign; }
            set { this._TitleTextAlign = value; }
        }
        /// <summary>
        /// 获取或设置标题字体
        /// </summary>
        [XmlElement("TitleFont")]
        public FontInfo TitleFont
        {
            get { return this._TitleFont; }
            set { this._TitleFont = value; }
        }
        /// <summary>
        /// 获取或设置标题字体颜色
        /// </summary>
        [XmlIgnore]
        public System.Drawing.Color TitleForeColor
        {
            get { return this._TitleForeColor; }
            set { this._TitleForeColor = value; }
        }
        /// <summary>
        /// 用于xml序列化 请使用TitleForeColor
        /// </summary>
        [XmlAttribute("TitleForeColor"),DefaultValue(null)]
        public string TitleForeColorValue
        {
            get { return System.Drawing.ColorTranslator.ToHtml(this._TitleForeColor); }
            set
            {
                try
                {
                    this._TitleForeColor = System.Drawing.ColorTranslator.FromHtml(value);
                }
                catch { this._TitleForeColor = System.Drawing.Color.Empty; }
            }
        }
        /// <summary>
        /// 获取或设置标题区背景色颜色
        /// </summary>
        [XmlIgnore]
        public System.Drawing.Color TitleBackColor
        {
            get { return this._TitleBackColor; }
            set { this._TitleBackColor = value; }
        }
        /// <summary>
        /// 用于xml序列化 请使用TitleBackColor
        /// </summary>
        [XmlAttribute("TitleBackColor"), DefaultValue(null)]
        public string TitleBackColorValue
        {
            get { return System.Drawing.ColorTranslator.ToHtml(this._TitleBackColor); }
            set
            {
                try
                {
                    this._TitleBackColor = System.Drawing.ColorTranslator.FromHtml(value);
                }
                catch { this._TitleBackColor = System.Drawing.Color.Empty; }
            }
        }
        /// <summary>
        /// 获取或设置刻度步长
        /// </summary>
        [XmlAttribute("TickStep")]
        public int TickStep
        {
            get
            {
                if (this._TickStep < 1)
                    this._TickStep = 1;
                return this._TickStep;
            }
            set { this._TickStep = value; }
        }
        /// <summary>
        /// 获取或设置文本上下交错类型
        /// </summary>
        [XmlAttribute("UpDownType")]
        public TitleLineUpDownType UpDownType
        {
            get { return this._UpDownType; }
            set { this._UpDownType = value; }
        }
        /// <summary>
        /// 获取或设置圆圈文本
        /// </summary>
        [XmlAttribute("CircleText")]
        public string CircleText
        {
            get { return _CircleText; }
            set { this._CircleText = value; }
        }
        /// <summary>
        /// 获取或设置分组的名称
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string Group
        {
            get { return this._Group; }
            set { this._Group = value; }
        }
        /// <summary>
        /// 获取或设置警告的关键词 用,分割
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string WarnKeyWords
        {
            get
            {
                return this._WarnKeyWords;
            }
            set
            {
                this._WarnKeyWords = value;
            }
        }
        /// <summary>
        /// 获取或设置合并组
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string Union
        {
            get
            {
                return this._Union;
            }
            set
            {
                this._Union = value;
            }
        }
        /// <summary>
        /// 获取或设置开始时间
        /// </summary>
        [DefaultValue(typeof(DateTime), "1980-1-1"), XmlAttribute]
        public DateTime StartDate
        {
            get
            {
                return this._StartDate;
            }
            set
            {
                this._StartDate = value;
            }
        }
        /// <summary>
        /// 获取或设置日期的关键字
        /// 用,分隔
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string StartDateKeyword
        {
            get
            {
                return this._StartDateKeyword;
            }
            set
            {
                this._StartDateKeyword = value;
            }
        }
        
        /// <summary>
        /// 获取或设置触发日期关键字当日显示的文本 
        /// 用,分隔 
        /// </summary>
        [XmlAttribute("KeyDateString")]
        public string KeyDateString
        {
            get { return this._KeyDateString; }
            set { this._KeyDateString = value; }
        }
        /// <summary>
        /// 关键字日期计数方式
        /// </summary>
        [XmlAttribute("CountType")]
        public TitleLineCountType CountType
        {
            get { return this._CountType; }
            set { this._CountType = value; }
        }

        /// <summary>
        /// 获取或设置运行日期关键字后连续显示多少天
        /// </summary>
        [XmlAttribute("AllowKeyDateDays")]
        public int AllowKeyDateDays
        {
            get { return this._AllowKeyDateDays; }
            set { this._AllowKeyDateDays = value; }
        }

        /// <summary>
        /// 获取或设置
        /// </summary>
        [Browsable(false), XmlIgnore]
        public DateTime RuntimeStartDate
        {
            get
            {
                return this._RuntimeStartDate;
            }
            set
            {
                this._RuntimeStartDate = value;
            }
        }
        /// <summary>
        /// 获取或设置布局类型
        /// </summary>
        [DefaultValue(TitleLineLayoutType.Normal), XmlAttribute]
        public TitleLineLayoutType LayoutType
        {
            get { return this._LoayoutType; }
            set { this._LoayoutType = value; }
        }
        /// <summary>
        /// 获取或设置值的类型
        /// </summary>
        [DefaultValue(TitleLineValueType.SerialDate), XmlAttribute]
        public TitleLineValueType ValueType
        {
            get
            {
                return this._ValueType;
            }
            set
            {
                this._ValueType = value;
            }
        }
        /// <summary>
        /// 获取或设置数据源名称
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string DataSourceName
        {
            get
            {
                return this._DataSourceName;
            }
            set
            {
                this._DataSourceName = value;
            }
        }
        /// <summary>
        /// 获取或设置值字段名称
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string ValueFieldName
        {
            get
            {
                return this._ValueFieldName;
            }
            set
            {
                this._ValueFieldName = value;
            }
        }
        /// <summary>
        /// 获取或设置时间字段名称
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string TimeFieldName
        {
            get
            {
                return this._TimeFieldName;
            }
            set
            {
                this._TimeFieldName = value;
            }
        }
        /// <summary>
        /// 获取或设置数据集
        /// </summary>
        [XmlArrayItem("Value", typeof(ValuePoint))]
        public ValuePointList Values
        {
            get
            {
                if (this._Values == null)
                {
                    this._Values = new ValuePointList();
                }
                return this._Values;
            }
            set
            {
                this._Values = value;
            }
        }
        /// <summary>
        /// 获取或设置文本颜色
        /// 
        /// </summary>
        [XmlIgnore]
        public System.Drawing.Color TextColor
        {
            get { return this._TextColor; }
            set { this._TextColor = value; }
        }
        /// <summary>
        ///用于XML序列化 请使用TextColor 
        /// </summary>
        [XmlAttribute("TextColor"),DefaultValue(null)]
        public string TextColorValue
        {
            get { return System.Drawing.ColorTranslator.ToHtml(this._TextColor); }
            set {
                try { this._TextColor = System.Drawing.ColorTranslator.FromHtml(value); }
                catch { this._TextColor = System.Drawing.Color.Empty; }
            }
        }
        /// <summary>
        /// 获取或设置指定的标题区的宽度
        /// </summary>
        [XmlAttribute("TitleWidth"),DefaultValue(0)]
        public float SpecifyTitleWidth
        {
            get { return this._SpecifyTitleWidth; }
            set { this._SpecifyTitleWidth = value; }
        }
        /// <summary>
        /// 获取或设置指定的高度
        /// </summary>
        [XmlAttribute("Height"),DefaultValue(0)]
        public float SpecifyHeight
        {
            get { return this._SpecifyHeight; }
            set
            {
                this._SpecifyHeight = value;
            }
        }

        /// <summary>
        /// 获取标题区的边界
        /// </summary>
        /// <returns></returns>
        public System.Drawing.RectangleF GetTitleBound()
        {
            return new System.Drawing.RectangleF(this.Left, this.Top
                , TitleWidth
                , this.SpecifyHeight > 0 ? this.SpecifyHeight : this.Height);
        }
        /// <summary>
        /// 获取标题行的边界
        /// </summary>
        /// <returns></returns>
        public override System.Drawing.RectangleF GetBound()
        {
            return new System.Drawing.RectangleF(this.Left, this.Top, this.Width, this.SpecifyHeight > 0 ? this.SpecifyHeight : this.Height);
        }

        /// <summary>
        /// 克隆对象
        /// </summary>
        /// <param name="cloneValues">是否克隆标题行数据集</param>
        /// <returns></returns>
        public TitleLine Clone(bool cloneValues)
        {
            TitleLine titleLineInfo = this.Clone<TitleLine>(); 
            if (cloneValues)
            {
                if (this._Values != null)
                {
                    titleLineInfo._Values = this._Values.Clone();
                }
            }
            else
            {
                titleLineInfo._Values = null;
            }
            return titleLineInfo;
        }
    }
}
