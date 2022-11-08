using System;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;
using System.Windows.Forms;
using CIS.ControlLib.Drawing;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// Y轴数据标尺类
    /// </summary>
    [Serializable]
    public class YAxisInfo:Element
    {
        private string _Name = null;
        private string _Title = null;
        private Orientation _TitleTextDirection = Orientation.Horizontal;
        private Color _TitleBackColor = Color.Transparent;
        private float _SpecifyTitleWidth = 0f;
        private string _BottomTitle = null;
        private Orientation _BottomTitleTextDirection = Orientation.Horizontal;
        private int _YSplitNum = 8;
        private bool _TextFlagMode = false;
        private float _MaxValue = 100f;
        private float _MinValue = 0f;
        private string _RedLineValue = null;
        private string _SymbolText = null;
        private Image _SymbolImage = null;
        private string _SymbolImagePath = null;
        private SymbolStyle _SymbolStyle = SymbolStyle.SolidCicle;
        private Color _SymbolColor = Color.Red;
        private string _DataSourceName = null;
        private string _ValueFieldName = null;
        private string _LanternValueFieldName = null;
        private string _ShadowValueFieldName = null;
        private string _TimeFieldName = null;
        private ValuePointList _Values = new ValuePointList();
        private YAxisScaleInfoList _Scales = null;
        private bool _Visible = true;
        private bool _ValueVisible = true;
        private bool _RuleSymbolVisble = true;
        private bool _IsMarginVisble = true;
        private float _SymbolSize = 20f;
        private float _Position = -10000f;
        private Color _TextBackColor = Color.Transparent;
        private bool _AllowCutOff = false;
        private bool _ClickVisible = true;
        private int _Ditgits = 0;
        private bool _EnableLanternValue = false;

        /// <summary>
        /// 获取或设置名称
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
        /// 获取或设置标题
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
        /// 获取或设置标题文本的方向
        /// </summary>
        [XmlAttribute]
        public Orientation TitleTextDirection
        {
            get { return _TitleTextDirection; }
            set { _TitleTextDirection = value; }
        }
      
        /// <summary>
        /// 获取或设置底部标题
        /// </summary>
        [DefaultValue(null),XmlAttribute]
        public string BottomTitle
        {
            get { return this._BottomTitle; }
            set { this._BottomTitle = value; }
        }
        /// <summary>
        /// 获取或设置底部标题文本的方向
        /// </summary>
        [XmlAttribute]
        public Orientation BottomTitleTextDirection
        {
            get { return _BottomTitleTextDirection; }
            set { _BottomTitleTextDirection = value; }
        }
        /// <summary>
        /// 是否点击即隐藏数据点
        /// </summary>
        [XmlAttribute]
        public bool ClickVisible
        {
            get { return this._ClickVisible; }
            set { this._ClickVisible = value; }
        }
        /// <summary>
        /// 如果为true,会在刻度区起始与结尾添加空白
        /// </summary>
        [DefaultValue(true), XmlAttribute]
        public bool IsMarginVisible
        {
            get { return this._IsMarginVisble; }
            set { this._IsMarginVisble = value; }
        }
        /// <summary>
        /// 获取或设置标题的宽度
        /// </summary>
        [DefaultValue(null), XmlAttribute("TitleWidth")]
        public float SpecifyTitleWidth
        {
            get { return this._SpecifyTitleWidth; }
            set { this._SpecifyTitleWidth = value; }
        }
        /// <summary>
        /// 获取或设置是否允许断点
        /// </summary>
        [XmlAttribute]
        public bool AllowCutOff { get { return this._AllowCutOff; } set { this._AllowCutOff = value; } }
        /// <summary>
        /// 获取或设置符号大小
        /// </summary>
        [XmlAttribute("SymbolSize")]
        public float SymbolSize
        {
            get { return this._SymbolSize; }
            set { this._SymbolSize = value; }
        }
        /// <summary>
        /// 获取或设置标题栏背景色
        /// </summary>
        public Color TitleBackColor
        {
            get { return this._TitleBackColor; }
            set { this._TitleBackColor = value; }
        }
        /// <summary>
        /// 用于XML序列化 请使用TitleBackColor
        /// </summary>
        [DefaultValue(null), XmlAttribute("TitleBackColor")]
        public string TitleBackColorValue
        {
            get { return ColorTranslator.ToHtml(this.TitleBackColor); }
            set 
            {
                try
                {
                    this.TitleBackColor = ColorTranslator.FromHtml(value);
                }
                catch { this.TitleBackColor = Color.Transparent; }
            }
        }
        /// <summary>
        /// 获取或设置文本背景色
        /// </summary>
        [XmlIgnore]
        public Color TextBackColor
        {
            get { return this._TextBackColor; }
            set { this._TextBackColor = value; }
        }
        /// <summary>
        /// 用于XML序列化 请使用TextBackColor
        /// </summary>
        [XmlAttribute("TextBackColor")]
        public string TextBackColorValue
        {
            get { return ColorTranslator.ToHtml(this.TextBackColor); }
            set
            {
                try
                {
                    this.TextBackColor = ColorTranslator.FromHtml(value);
                }
                catch { this.TextBackColor = Color.Transparent; }
            }
        }

        /// <summary>
        /// 获取或设置是否可见
        /// </summary>
        [DefaultValue(true), XmlAttribute]
        public bool Visible
        {
            get
            {
                return this._Visible;
            }
            set
            {
                this._Visible = value;
            }
        }
        /// <summary>
        //  获取或设置数值是否可见
        /// </summary>
        [DefaultValue(true), XmlAttribute]
        public bool ValueVisible
        {
            get { return _ValueVisible; }
            set { _ValueVisible = value; }
        }
        /// <summary>
        /// 获取或设置数据标尺中的符号是否显示
        /// </summary>
        [DefaultValue(true), XmlAttribute]
        public bool RuleSymbolVisible
        {
            get { return this._RuleSymbolVisble; }
            set { this._RuleSymbolVisble = value; }
        }
        /// <summary>
        /// 获取或设置警告线对应的值
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string RedLineValue
        {
            get
            {
                return this._RedLineValue;
            }
            set
            {
                float redValue = float.NaN;
                if (float.TryParse(value, out redValue))
                {
                    this._RedLineValue = value;
                }
                else
                    this._RedLineValue = null;
            }
        }
        /// <summary>
        /// 获取或设置分割数
        /// </summary>
        [DefaultValue(8), XmlAttribute]
        public int YSplitNum
        {
            get
            {
                return this._YSplitNum;
            }
            set
            {
                this._YSplitNum = value;
            }
        }
        /// <summary>
        /// 获取或设置是否为文本模式
        /// </summary>
        [DefaultValue(false), XmlAttribute]
        public bool TextFlagMode
        {
            get
            {
                return this._TextFlagMode;
            }
            set
            {
                this._TextFlagMode = value;
            }
        }
        /// <summary>
        /// 获取或设置最大值
        /// </summary>
        [DefaultValue(100f), XmlAttribute]
        public float MaxValue
        {
            get
            {
                return this._MaxValue;
            }
            set
            {
                this._MaxValue = value;
            }
        }
        /// <summary>
        /// 获取或设置最小值
        /// </summary>
        [DefaultValue(0f), XmlAttribute]
        public float MinValue
        {
            get
            {
                return this._MinValue;
            }
            set
            {
                this._MinValue = value;
            }
        }
        /// <summary>
        /// 符号文本
        /// </summary>
        [XmlAttribute]
        public string SymbolText
        {
            get { return _SymbolText; }
            set { _SymbolText = value; }
        }
        /// <summary>
        /// 符号图片的路径
        /// </summary>
        [XmlAttribute]
        public string SymbolImagePath
        {
            get { return _SymbolImagePath; }
            set { _SymbolImagePath = value;
                this._SymbolImage = null;
            }
        }
        /// <summary>
        /// 符号图片
        /// </summary>
        [XmlIgnore]
        public Image SymbolImage
        {
            get 
            {
                if (this._SymbolImage != null)
                    return this._SymbolImage;
                if (string.IsNullOrEmpty(this.SymbolImagePath))
                    return null;
                string filename = System.IO.Path.Combine(Application.StartupPath, this.SymbolImagePath);
                if (System.IO.File.Exists(filename))
                {
                    using (Image image = Image.FromFile(filename))
                    {
                        this._SymbolImage = (Image)image.Clone();
                        return this._SymbolImage;
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// 获取或设置图例样式
        /// </summary>
        [DefaultValue(SymbolStyle.SolidCicle), XmlAttribute]
        public SymbolStyle SymbolStyle
        {
            get
            {
                return this._SymbolStyle;
            }
            set
            {
                this._SymbolStyle = value;
            }
        }
        /// <summary>
        /// 获取或设置图例颜色
        /// </summary>
        [XmlIgnore]
        public Color SymbolColor
        {
            get
            {
                return this._SymbolColor;
            }
            set
            {
                this._SymbolColor = value;
            }
        }
        /// <summary>
        /// 用于XML序列化用  请使用SymbolColor
        /// </summary>
        [Browsable(false), DefaultValue("Red"), XmlAttribute]
        public string SymbolColorValue
        {
            get
            {
                return ColorTranslator.ToHtml(this.SymbolColor);
            }
            set
            {
                this.SymbolColor = ColorTranslator.FromHtml(value);
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
        /// 获取或设置灯笼数值字段名称
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string LanternValueFieldName
        {
            get
            {
                return this._LanternValueFieldName;
            }
            set
            {
                this._LanternValueFieldName = value;
            }
        }
        /// <summary>
        /// 是否启用灯笼数据
        /// </summary>
        [XmlAttribute]
        public bool EnableLanternValue
        {
            get { return this._EnableLanternValue; }
            set { this._EnableLanternValue = value; }
        }
        /// <summary>
        /// 获取或设置起始位置
        /// 仅针对文本类
        /// </summary>
        [DefaultValue(-10000), XmlAttribute]
        public float Position
        {
            get { return this._Position; }
            set { this._Position = value; }
        }
        /// <summary>
        /// 获取或设置阴影数值字段名称
        /// </summary>
        [DefaultValue(null),XmlAttribute]
        public string ShadowValueFieldName
        {
            get { return this._ShadowValueFieldName; }
            set { this._ShadowValueFieldName = value; }
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
        /// 获取或设置数据点集合
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
        /// 获取或设置数值的精确度
        /// </summary>
        [XmlAttribute]
        public int Ditgits
        {
            get { return this._Ditgits; }
            set { this._Ditgits = value; }
        }
        /// <summary>
        /// 获取或设置刻度值的缩放
        /// </summary>
        [DefaultValue(null), XmlArrayItem("Scale", typeof(YAxisScaleInfo))]
        public YAxisScaleInfoList Scales
        {
            get
            {
                if (this._Scales == null)
                {
                    this._Scales = new YAxisScaleInfoList();
                }
                return this._Scales;
            }
            set
            {
                this._Scales = value;
            }
        }
        /// <summary>
        /// 判断是否具有缩放信息
        /// </summary>
        internal bool HasScales
        {
            get
            {
                return this._Scales != null && this._Scales.Count > 2;
            }
        }

        /// <summary>
        /// 获取当前值所在刻度的比例
        /// </summary>
        /// <param name="value">刻度值</param>
        /// <returns></returns>
        internal float GetTickRate(float value)
        {
            float result;
            if (TemperatureDocument.IsNaN(value))
            {
                result = float.NaN;
            }
            else
            {
                if (this.HasScales)
                {
                    for (int i = 1; i < this.Scales.Count; i++)
                    {
                        YAxisScaleInfo yAxisScaleInfo = this.Scales[i];
                        if (value >= yAxisScaleInfo.Value)
                        {
                            YAxisScaleInfo preYAxisScaleInfo = this.Scales[i - 1];
                            float num;
                            if (value > preYAxisScaleInfo.Value)
                            {
                                num = preYAxisScaleInfo.ScaleRate;
                            }
                            else
                            {
                                num = yAxisScaleInfo.ScaleRate + (preYAxisScaleInfo.ScaleRate - yAxisScaleInfo.ScaleRate) * ((value - yAxisScaleInfo.Value) / (preYAxisScaleInfo.Value - yAxisScaleInfo.Value));
                            }
                            result = num;
                            return result;
                        }
                    }
                    result = 0f;
                }
                else
                {
                    result = (value - this.MinValue) / (this.MaxValue - this.MinValue);
                }
            }
            return result;
        }
        /// <summary>
        /// 克隆对象
        /// </summary>
        /// <param name="cloneValues">是否克隆数值</param>
        /// <returns></returns>
        public YAxisInfo Clone(bool cloneValues)
        {
            YAxisInfo yAxisInfo = this.Clone<YAxisInfo>(); ;
            if (cloneValues)
            {
                if (this._Values != null)
                {
                    yAxisInfo._Values = this._Values.Clone();
                }
            }
            else
            {
                yAxisInfo._Values = null;
            }
            if (this._Scales != null)
            {
                yAxisInfo._Scales = new YAxisScaleInfoList();
                foreach (YAxisScaleInfo current in this._Scales)
                {
                    yAxisInfo._Scales.Add(current);
                }
            }
            return yAxisInfo;
        }
    }
}