using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Linq;
using CIS.ControlLib.Helper;
using CIS.ControlLib.Drawing;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 体温单绘制类
    /// </summary>
    [Serializable]
    public class TemperatureDocument 
    {
        public const string NullDateString = "1980-1-1";
        public const float NullValue = -10000f;
        public static DateTime NullDate = new DateTime(1980, 1, 1);

        private GraphicsUnit _PageUnit = GraphicsUnit.Pixel;
        //记录网格区域的边界范围
        private RectangleF _GirdRectangle = RectangleF.Empty;
        //缓存用于绘制的对象 画刷 字体 画笔等
        private Hashtable _DrawingCache = new Hashtable();
        private float _Left = 0f;
        private float _Top = 0f;
        private float _Width = 750f;
        private float _Height = 1020f;
        private DocumentViewMode _ViewMode = DocumentViewMode.Page;
        private int _PageIndex = 0;
        internal int _NumOfPages = 0;
        private int _Days = 0;
        [NonSerialized]
        private Hashtable _DataSources = new Hashtable();
        private TemperatureDocumentConfig _Config = null;
        private bool _Modified = false;
        private float draw_LeftContentWidth = 0F;

        [XmlIgnore]
        public RectangleF GridRectangle
        {
            get { return this._GirdRectangle; }
        }
        /// <summary>
        /// 获取或设置右边空白区域大小
        /// </summary>
        [XmlIgnore]
        public float RightEmptyPadding
        {
            get { return this.Config.RightEmptyPadding; }
            set { this.Config.RightEmptyPadding = value; }
        }
        /// <summary>
        /// 获取或设置是否自动缩进
        /// </summary>
        [XmlIgnore]
        public bool AutoIndent
        {
            get { return this.Config.AutoIndent; }
            set { this.Config.AutoIndent = value; }
        }
        /// <summary>
        /// 是否绘制开始垂直分隔线
        /// </summary>
        [DefaultValue(false), XmlIgnore]
        public bool DrawGridVerticalSplitLineStart
        {
            get { return this.Config.DrawGridVerticalSplitLineStart; }
            set { this.Config.DrawGridVerticalSplitLineStart = value; }
        }
        /// <summary>
        /// 是否绘制最后垂直分隔线
        /// </summary>
        [DefaultValue(false), XmlIgnore]
        public bool DrawGridVerticalSplitLineEnd
        {
            get { return this.Config.DrawGridVerticalSplitLineEnd; }
            set { this.Config.DrawGridVerticalSplitLineEnd = value; }
        }
        /// <summary>
        /// 获取或设置上边距
        /// </summary>
        [DefaultValue(0), XmlIgnore]
        public float Top
        {
            get
            {
                return this._Top;
            }
            set
            {
                this._Top = value;
            }
        }
        /// <summary>
        ///获取或设置下边距
        /// </summary>
        [Browsable(false), XmlIgnore]
        public float Bottom
        {
            get
            {
                return this._Top + this._Height;
            }
        }
        /// <summary>
        /// 获取或设置左边距
        /// </summary>
        [DefaultValue(0f), XmlIgnore]
        public float Left
        {
            get
            {
                return this._Left;
            }
            set
            {
                this._Left = value;
            }
        }
        /// <summary>
        /// 获取或设置右边距
        /// </summary>
        [Browsable(false), XmlIgnore]
        public float Right
        {
            get
            {
                return this._Left + this._Width;
            }
        }
        /// <summary>
        /// 获取或设置页面宽度
        /// </summary>
        [DefaultValue(750), XmlIgnore]
        public float Width
        {
            get
            {
                return this._Width;
            }
            set
            {
                this._Width = value;
            }
        }
        /// <summary>
        /// 获取或设置页面高度
        /// </summary>
        [DefaultValue(1020), XmlIgnore]
        public float Height
        {
            get
            {
                return this._Height;
            }
            set
            {
                this._Height = value;
            }
        }
        /// <summary>
        /// 获取或设置边界
        /// </summary>
        [Browsable(false), XmlIgnore]
        public RectangleF Bounds
        {
            get
            {
                return new RectangleF(this._Left, this._Top, this._Width, this._Height);
            }
            set
            {
                this._Left = value.Left;
                this._Top = value.Top;
                this._Width = value.Width;
                this._Height = value.Height;
            }
        }
        /// <summary>
        /// 获取或设置视图模式
        /// </summary>
        [Category("Layout"), DefaultValue(DocumentViewMode.Page), XmlIgnore]
        public DocumentViewMode ViewMode
        {
            get
            {
                return this._ViewMode;
            }
            set
            {
                this._ViewMode = value;
            }
        }
        /// <summary>
        /// 获取或设置当前页码
        /// </summary>
        [Browsable(false), XmlIgnore]
        public int PageIndex
        {
            get
            {
                return this._PageIndex;
            }
            set
            {
                this._PageIndex = value;
            }
        }
        /// <summary>
        /// 获取或设置运行时页码
        /// </summary>
        private int RuntimePageIndex
        {
            get
            {
                int result;
                if (this.ViewMode .HasFlag( DocumentViewMode.Widely))
                {
                    result = 0;
                }
                else
                {
                    if (this._PageIndex < 0)
                    {
                        result = 0;
                    }
                    else
                    {
                        if (this._PageIndex >= this.NumOfPages)
                        {
                            result = this.NumOfPages - 1;
                        }
                        else
                        {
                            result = this._PageIndex;
                        }
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// 获取总页数
        /// </summary>
        [Browsable(false)]
        public int NumOfPages
        {
            get
            {
                return this._NumOfPages;
            }
        }
        /// <summary>
        /// 获取或设置每页显示的天数
        /// </summary>
        [DefaultValue(7),XmlIgnore]
        public int NumOfDaysInOnePage
        {
            get
            {
                return this.Config.NumOfDaysInOnePage;
            }
            set
            {
                this.Config.NumOfDaysInOnePage = value;
            }
        }
        /// <summary>
        /// 获取运行时每页显示的天的数量
        /// </summary>
        internal int RuntimeNumOfDaysInOnePage
        {
            get
            {
                int result;
                if (this.ViewMode .HasFlag( DocumentViewMode.Widely))
                {
                    if (this.Days <= 0)
                    {
                        result = this.NumOfDaysInOnePage;
                    }
                    else
                    {
                        result = this.Days;
                    }
                }
                else
                {
                    result = this.NumOfDaysInOnePage;
                }
                return result;
            }
        }
        /// <summary>
        /// 获取总的天数
        /// </summary>
        public int Days
        {
            get
            {
                return this._Days;
            }
        }
        /// <summary>
        /// 指定开始日期
        /// </summary>
        [XmlIgnore]
        public DateTime SpecifyStartDate
        {
            get { return this.Config.SpecifyStartDate; }
            set { this.Config.SpecifyStartDate = value; }
        }
        /// <summary>
        /// 指定结束日期
        /// </summary>
        [XmlIgnore]
        public DateTime? SpecifyEndDate
        {
            get;
            set;
        }
        /// <summary>
        /// 获取运行时的开始日期的起始时间
        /// </summary>
        [XmlIgnore]
        public DateTime RuntimeStartTime
        {
            get
            {
                if (this.SpecifyStartDate <= TemperatureDocument.NullDate || this.SpecifyStartDate == DateTime.MinValue)
                {
                    DateTime minDate = DateTime.MinValue;
                    DateTime maxDate = DateTime.MaxValue;
                    this.UpdateNumOfPage(ref maxDate, ref minDate);
                    return this.GetMinTime(minDate);
                }
                else
                    return this.SpecifyStartDate.Date.AddHours(this.Ticks[0].Value);
            }
        }
        /// <summary>
        /// 获取或设置字体
        /// </summary>
        [XmlIgnore]
        public Font Font
        {
            get { return this.Config.Font.GetFont(); }
            set { this.Config.Font.Assign(value); }
        }
        /// <summary>
        /// 获取或设置前景色
        /// </summary>
        [DefaultValue(typeof(Color), "Black"), XmlIgnore]
        public Color ForeColor
        {
            get { return this.Config.ForeColor; }
            set { this.Config.ForeColor = value; }
        }
        /// <summary>
        /// 获取或设置背景色
        /// </summary>
        [DefaultValue(typeof(Color), "White"), XmlIgnore]
        public Color BackColor
        {
            get
            {
                return this.Config.BackColor;
            }
            set
            {
                this.Config.BackColor = value;
            }
        }
        /// <summary>
        /// 获取或设置边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Black"), XmlIgnore]
        public Color BorderColor
        {
            get { return this.Config.BorderColor; }
            set { this.Config.BorderColor = value; }
        }
        /// <summary>
        /// 获取或设置边框粗细大小
        /// </summary>
        [DefaultValue(2), XmlIgnore]
        public int BorderSize
        {
            get { return this.Config.BorderSize; }
            set { this.Config.BorderSize = value; }
        }
        /// <summary>
        /// 获取或设置符号大小
        /// </summary>
        [DefaultValue(10)]
        [XmlIgnore]
        public float SymbolSize
        {
            get
            {
                return this.Config.SymbolSize;
            }
            set
            {
                this.Config.SymbolSize = value;
            }
        }
        /// <summary>
        /// 获取或设置垂直网格分割数
        /// </summary>
        [DefaultValue(10)]
        [XmlIgnore]
        public int GridVerticalSplitNum
        {
            get { return this.Config.GridVerticalSplitNum; }
            set { this.Config.GridVerticalSplitNum = value; }
        }
        /// <summary>
        /// 获取或设置网格的上边距
        /// 单位最小格子数
        /// </summary>
        [XmlIgnore]
        public float GridTopPadding
        {
            get { return this.Config.GridTopPadding; }
            set { this.Config.GridTopPadding = value; }
        }
        /// <summary>
        /// 获取或设置网格的下边距
        /// 单位最小格子数
        /// </summary>
        [XmlIgnore]
        public float GridBottomPadding
        {
            get { return this.Config.GridBottomPadding; }
            set { this.Config.GridBottomPadding = value; }
        }
        /// <summary>
        /// 获取或设置结束日期关键词
        /// </summary>
        [XmlIgnore]
        public string EndDateKeyword
        {
            get { return this.Config.EndDateKeyword; }
            set { this.Config.EndDateKeyword = value; }
        }
        /// <summary>
        /// 获取或设置网格间隔数量
        /// </summary>
        [DefaultValue(5)]
        [XmlIgnore]
        public int IntervalCount
        {
            get { return this.Config.IntervalCount; }
            set { this.Config.IntervalCount = value; }
        }
        /// <summary>
        /// 获取或设置网格线颜色
        /// </summary>
        [XmlIgnore]
        public Color GridLineColor
        {
            get { return this.Config.GridLineColor; }
            set { this.Config.GridLineColor = value; }
        }
        /// <summary>
        /// 获取或设置网格垂直分割线颜色
        /// </summary>
        [XmlIgnore]
        public Color GridVerticalSplitLineColor
        {
            get { return this.Config.GridVerticalSplitLineColor; }
            set { this.Config.GridVerticalSplitLineColor = value; }
        }
        /// <summary>
        /// 获取或设置大垂直分割线粗细
        /// </summary>
        [XmlIgnore]
        public int BigSplitLineThickness
        {
            get { return this.Config.BigSplitLineThickness; }
            set { this.Config.BigSplitLineThickness = value; }
        }
        /// <summary>
        /// 获取或设置大垂直分割线颜色
        /// </summary>
        [XmlIgnore]
        public Color BigSplitLineColor
        {
            get { return this.Config.BigSplitLineColor; }
            set { this.Config.BigSplitLineColor = value; }
        }
        /// <summary>
        /// 获取或设置网格水平分割线颜色
        /// </summary>
        [XmlIgnore]
        public Color GridHorizontalSplitLineColor
        {
            get { return this.Config.GridHorizontalSplitLineColor; }
            set { this.Config.GridHorizontalSplitLineColor = value; }
        }
        /// <summary>
        /// 获取或设置网格的水平分割线间隔
        /// </summary>
        [XmlIgnore]
        public int GridHorizontalSplitInterval
        {
            get { return this.Config.GridHorizontalSplitInterval; }
            set { this.Config.GridHorizontalSplitInterval = value; }
        }
        /// <summary>
        /// 获取或设置网格垂直分割线的粗细
        /// </summary>
        [XmlIgnore]
        public float GridVerticalSplitLineWidth
        {
            get { return this.Config.GridVerticalSplitLineWidth; }
            set { this.Config.GridVerticalSplitLineWidth = value; }
        }

        /// <summary>
        /// 获取或设置时间格式字符串
        /// </summary>
        [DefaultValue("yyyy-MM-dd"), XmlIgnore]
        public string DateFormatString
        {
            get
            {
                return this.Config.DateFormatString;
            }
            set
            {
                this.Config.DateFormatString = value;
            }
        }
        /// <summary>
        /// 获取或设置页面标题
        /// </summary>
        [XmlIgnore]
        public string Title
        {
            get
            {
                return this.Config.Title;
            }
            set
            {
                this.Config.Title = value;
            }
        }
        /// <summary>
        /// 获取或设置标题字体
        /// </summary>
        [XmlIgnore]
        public Font TitleFont
        {
            get { return this.Config.TitleFont.GetFont(); }
            set { this.Config.TitleFont.Assign(value); }
        }
        /// <summary>
        /// 获取或设置标题区占用的高度
        /// </summary>
        [XmlIgnore]
        public float SpecifyTitleHeight
        {
            get { return this.Config.SpecifyTitleHeight; }
            set { this.Config.SpecifyTitleHeight = value; }
        }

        /// <summary>
        /// 获取或设置页脚注释
        /// </summary>
        [DefaultValue(null), XmlIgnore]
        public string FooterDescription
        {
            get { return this.Config.FooterDescription; }
            set { this.Config.FooterDescription = value; }
        }

        /// <summary>
        /// 获取或设置刻度集合
        /// </summary>
        [XmlIgnore]
        public TickInfoList Ticks
        {
            get
            {
                return this.Config.Ticks;
            }
            set { this.Config.Ticks = value; }
        }
        /// <summary>
        /// 获取或设置标记集合
        /// </summary>
        [XmlIgnore]
        public TokenList Tokens
        {
            get { return this.Config.Tokens; }
            set { this.Config.Tokens = value; }
        }
        /// <summary>
        /// 获取或设置文本标签集合
        /// </summary>
        [XmlIgnore]
        public LabelInfoList Labels
        {
            get
            {
                return this.Config.Labels;
            }
            set { this.Config.Labels = value; }
        }
        /// <summary>
        /// 获取或设置页眉标签集合
        /// </summary>
        [XmlIgnore]
        public HeaderLabelList HeaderLabels
        {
            get
            {
                return this.Config.HeaderLabels;
            }
            set
            {
                this.Config.HeaderLabels = value;
            }
        }
        /// <summary>
        /// 获取或设置页眉标签集合
        /// </summary>
        [XmlIgnore]
        public ScaleplateList Scalepaltes
        {
            get
            {
                return this.Config.Scalepates;
            }
            set
            {
                this.Config.Scalepates = value;
            }
        }

        /// <summary>
        /// 获取或设置页眉数据行集合
        /// </summary>
        [XmlIgnore]
        public TitleLineList HeaderLines
        {
            get
            {
                return this.Config.HeaderLines;
            }
            set
            {
                this.Config.HeaderLines = value;
            }
        }
        /// <summary>
        /// 获取或设置页脚数据行集合
        /// </summary>
        [XmlIgnore]
        public TitleLineList FooterLines
        {
            get
            {
                return this.Config.FooterLines;
            }
            set
            {
                this.Config.FooterLines = value;
            }
        }
        /// <summary>
        /// 获取或设置数据标尺集合
        /// </summary>
        [XmlIgnore]
        public YAxisInfoList YAxisInfos
        {
            get
            {
                return this.Config.YAxisInfos;
            }
            set
            {
                this.Config.YAxisInfos = value;
            }
        }
        /// <summary>
        /// 是否设置为精确时间点
        /// </summary>
        [XmlIgnore]
        public bool IsExactTime
        {
            get { return this.Config.IsExactTime; }
            set { this.Config.IsExactTime = value; }
        }
        /// <summary>
        /// 获取或设置配置信息
        /// </summary>
        [XmlIgnore]
        public string ConfigXml
        {
            get
            {
                return this.Config.SaveXML(false);
            }
            set
            {
                TemperatureDocumentConfig temperatureDocumentConfig = TemperatureDocumentConfig.LoadXML(value);
                if (temperatureDocumentConfig != null)
                {
                    this.Config = temperatureDocumentConfig;
                }
            }
        }
        /// <summary>
        /// 获取或设置配置对象
        /// </summary>
        public TemperatureDocumentConfig Config
        {
            get
            {
                if (_Config == null)
                {
                    _Config = new TemperatureDocumentConfig();

                    Graphics g = Graphics.FromHwnd(IntPtr.Zero);
                    PageSettings settings = new PageSettings();
                    _Config.PageSettings.WriteTo(settings);
                    this.SetBoundsCore(g, settings);
                }
                if (this._Config.Ticks.Count == 0)
                {
                    this._Config.Ticks.Add("2", 2, Color.Red);
                    this._Config.Ticks.Add("6", 6);
                    this._Config.Ticks.Add("10", 10);
                    this._Config.Ticks.Add("14", 14);
                    this._Config.Ticks.Add("18", 18, Color.Red);
                    this._Config.Ticks.Add("22", 22, Color.Red);
                }
                return _Config;
            }
            set
            {
                _Config = value;
                if (_Config != null)
                {
                    Graphics g = Graphics.FromHwnd(IntPtr.Zero);
                    PageSettings settings = new PageSettings();
                    _Config.PageSettings.WriteTo(settings);
                    this.SetBoundsCore(g, settings);
                }
            }
        }
        /// <summary>
        /// 获取数据源
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), XmlIgnore]
        public Hashtable DataSources
        {
            get
            {
                if (this._DataSources == null)
                {
                    this._DataSources = new Hashtable();
                }
                return this._DataSources;
            }
        }
        /// <summary>
        /// 获取数据标尺
        /// 【不包含文本类型 灯笼数据标尺 与阴影数据标尺】
        /// </summary>
        [XmlIgnore]
        public YAxisInfoList Rules
        {
            get
            {
                YAxisInfoList rules = new YAxisInfoList();
                //获取所有灯笼的字段
                string[] lanternFieldNames = this.YAxisInfos.Where(y => !string.IsNullOrWhiteSpace(y.LanternValueFieldName))
                    .Select(y => y.LanternValueFieldName).Distinct().ToArray();
                //获取所有的阴影字段名称
                string[] shadowFieldNames = this.YAxisInfos.Where(y => !string.IsNullOrWhiteSpace(y.ShadowValueFieldName))
                .Select(y => y.ShadowValueFieldName).Distinct().ToArray();
                rules.AddRange(this.YAxisInfos.Where(y => !y.TextFlagMode
                     && ((shadowFieldNames != null && !shadowFieldNames.Contains(y.ValueFieldName)) || shadowFieldNames == null)
                     && ((lanternFieldNames != null && !lanternFieldNames.Contains(y.ValueFieldName)) || lanternFieldNames == null)));
                return rules;
            }
        }
        [XmlIgnore]
        public bool Modified { get { return _Modified; } set { this._Modified = value; } }
        /// <summary>
        /// 清除无效数据
        /// </summary>
        public void ClearInvalidData()
        {
            //用于清除重复数据
            var list =new List<DateTime>();
            //去除空数据
            foreach (var item in this.HeaderLines)
            {
                for (int i = item.Values.Count-1; i >-1 ; i--)
                {
                    if (string.IsNullOrEmpty(item.Values[i].Text))
                    {
                        item.Values.RemoveAt(i);
                        continue;
                    }
                    DateTime time = item.Values[i].Time;
                    if (list.Contains(time))
                    {
                        item.Values.RemoveAt(i);
                        continue;
                    }
                    list.Add(time);
                }
                list.Clear();
            }
            list.Clear();
            foreach (var item in this.FooterLines)
            {
                for (int i = item.Values.Count - 1; i > -1; i--)
                {
                    if (string.IsNullOrEmpty(item.Values[i].Text))
                    { item.Values.RemoveAt(i);
                        continue;
                    }
                    DateTime time = item.Values[i].Time;
                    if (list.Contains(time))
                    {
                        item.Values.RemoveAt(i);
                        continue;
                    }
                    list.Add(time);
                }
                list.Clear();
            }
            list.Clear();
            //去除无效数据
            foreach (var item in this.YAxisInfos)
            {
                for (int i = item.Values.Count - 1; i > -1; i--)
                {
                    if (item.TextFlagMode)
                    {
                        if (string.IsNullOrEmpty(item.Values[i].Text))
                        {
                            item.Values.RemoveAt(i);
                            continue;
                        }
                    }
                    else
                    {
                        if (TemperatureDocument.IsNaN(item.Values[i].Value))
                        {
                            item.Values.RemoveAt(i);
                            continue;
                        }
                    }
                    DateTime time = item.Values[i].Time;
                    if (list.Contains(time))
                    {
                        item.Values.RemoveAt(i);
                        continue;
                    }
                    list.Add(time);
                }
                list.Clear();
            }

        }
        /// <summary>
        /// 移除指定时间范围内的数据
        /// </summary>
        /// <param name="minTime"></param>
        /// <param name="maxTime"></param>
        public void RemoveValuePoints(DateTime minTime, DateTime maxTime)
        {
            foreach (var item in this.HeaderLines)
            {
                item.Values.RemoveAll(r => r.Time >= minTime && r.Time <= maxTime);
            }
            foreach (var item in this.FooterLines)
            {
                item.Values.RemoveAll(r => r.Time >= minTime && r.Time <= maxTime);
            }
            foreach (var item in this.YAxisInfos)
            {
                item.Values.RemoveAll(r => r.Time >= minTime && r.Time <= maxTime);
            }
            this.ClearInvalidData();
        }

        public void CancelModifies()
        {
            this.RefreshDataSource();
        }
        /// <summary>
        /// 加载体温单
        /// </summary>
        /// <param name="stream">体温单数据流</param>
        /// <returns></returns>
        public bool Load(Stream stream)
        {
            this._Modified = false;
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            XmlSerializer xmlSerializer = new XmlSerializer(base.GetType());
            TemperatureDocument temperatureDocument = (TemperatureDocument)xmlSerializer.Deserialize(stream);
            bool result;
            if (temperatureDocument != null)
            {
                this.Config = temperatureDocument.Config;
                this._NumOfPages = temperatureDocument._NumOfPages;
                this._Left = temperatureDocument._Left;
                this._Top = temperatureDocument._Top;
                this._Width = temperatureDocument._Width;
                this._Height = temperatureDocument._Height;
                this._PageIndex = temperatureDocument._PageIndex;
                this._ViewMode = temperatureDocument._ViewMode;
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 把体温单转换完数据流
        /// </summary>
        /// <param name="stream"></param>
        public void Save(Stream stream)
        {
            this._Modified = false;
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            XmlSerializer xmlSerializer = new XmlSerializer(base.GetType());
            xmlSerializer.Serialize(stream, this);
        }
        /// <summary>
        /// 获取指定页的图片
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public Bitmap CreatePageBmp(int pageIndex)
        {

            PageSettings pageSettings = new PageSettings();
            Bitmap bitmap = new Bitmap((int)((double)pageSettings.Bounds.Width * 96.0 / 100.0), (int)((double)pageSettings.Bounds.Height * 96.0 / 100.0));
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                this.SetBoundsCore(graphics, pageSettings);
                DocumentViewMode viewMode = this.ViewMode;
                this.ViewMode = DocumentViewMode.Page;
                this.PageIndex = pageIndex;
                this.Draw(graphics, new RectangleF(0f, 0f, this.Right, this.Bottom));
                this.ViewMode = viewMode;
            }
            return bitmap;
        }
        /// <summary>
        /// 设置体温单边距和大小
        /// </summary>
        /// <param name="g">绘制对象</param>
        /// <param name="pageSettings">打印页面设置</param>
        /// <returns></returns>
        internal RectangleF SetBoundsCore(Graphics g, PageSettings pageSettings)
        {
            RectangleF result = new Rectangle(0, 0, (int)(g.DpiX * (float)pageSettings.Bounds.Width / 100f), (int)(g.DpiY * (float)pageSettings.Bounds.Height / 100f));
            this.Left = result.X + (float)((int)((float)pageSettings.Margins.Left * g.DpiX / 100f));
            this.Top = result.Y + (float)((int)((float)pageSettings.Margins.Top * g.DpiY / 100f));
            this.Width = result.Right - (float)((int)((float)pageSettings.Margins.Right * g.DpiX / 100f)) - this.Left;
            this.Height = result.Bottom - (float)((int)((float)pageSettings.Margins.Bottom * g.DpiY / 100f)) - this.Top;
            return result;
        }

        /// <summary>
        /// 判断数字是否为非法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNaN(float value)
        {
            return float.IsNaN(value) || value == -10000f;
        }
        public TitleLine GetTitleLineInfoByName(string name)
        {
            TitleLine itemByName = this.HeaderLines.GetItemByName(name);
            if (itemByName == null)
            {
                itemByName = this.FooterLines.GetItemByName(name);
            }
            return itemByName;
        }
        public YAxisInfo GetYAxisInfoByName(string name)
        {
            return this.YAxisInfos.GetItemByName(name);
        }
        public ValuePointList GetValuePointsByName(string name)
        {
            YAxisInfo itemByName = this.YAxisInfos.GetItemByName(name);
            ValuePointList result;
            if (itemByName != null)
            {
                result = itemByName.Values;
            }
            else
            {
                TitleLine itemByName2 = this.HeaderLines.GetItemByName(name);
                if (itemByName2 != null)
                {
                    result = itemByName2.Values;
                }
                else
                {
                    itemByName2 = this.FooterLines.GetItemByName(name);
                    if (itemByName2 != null)
                    {
                        result = itemByName2.Values;
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            return result;
        }
        public ValuePoint GetValuePointByXY(float x, float y,out YAxisInfo rule)
        {
            foreach (var yAxis in this.YAxisInfos.Where(y1=>y1.ValueVisible))
            {
                foreach (var value in yAxis.Values)
                {
                    if (value.GetBound().Contains(x, y))
                    {
                        rule = yAxis;
                        return value;
                    }
                }
            }
            rule = null;
            return null;
        }
        public ValuePoint GetValuePointByXY(float x, float y, TitleLine line)
        {
            if (line.GetBound().Contains(x, y) && !line.GetTitleBound().Contains(x,y))
            {
                DateTime startDate = this.GetDate(this.RuntimeStartTime);
                DateTime time = this.GetTimeByX(x,startDate);
                int dayIndex = this.GetDayIndex(time, startDate);
                int tickIndex = this.GetTickIndex(time);
                int stepIndex =tickIndex/ line.TickStep;
                var point = line.Values.Find(v => this.GetDayIndex(v.Time, startDate) == dayIndex && this.GetTickIndex(v.Time)/line.TickStep == stepIndex);
                if (point == null)
                    return new ValuePoint() { Time = time, Text = "" };
                else
                    return point;
            }
            return null;
        }
        #region 暂时无用 已更改为一个刻度只能存在一个值

        //public void AddPointByTimeValue(YAxisInfo rule, DateTime time, float value)
        //{
        //    this._Modified = true;
        //    var valuePoint = rule.Values.Find(v => v.Time == time);
        //    if (valuePoint == null)
        //    {
        //        valuePoint = new ValuePoint();
        //        valuePoint.Time = time;
        //        valuePoint.Value = value;
        //        rule.Values.Add(valuePoint);
        //    }
        //    this.UpdatePointByTimeValue(rule, time, time, value);
        //}
        //public void AddPointByTimeText(YAxisInfo rule, DateTime time, string text)
        //{
        //    this._Modified = true;
        //    var valuePoint = rule.Values.Find(v => v.Time == time);
        //    if (valuePoint != null)
        //        valuePoint.Text = text;
        //    else
        //    {
        //        valuePoint = new ValuePoint();
        //        valuePoint.Time = time;
        //        valuePoint.Text = text;
        //        rule.Values.Add(valuePoint);
        //    }
        //}
        //public void RemovePointByTime(YAxisInfo rule, DateTime time)
        //{
        //    this._Modified = true;
        //    if (!rule.Values.Exists(v => v.Time == time))
        //        return;
        //    if (!rule.TextFlagMode)
        //    {
        //        if (this.IsLanternRule(rule.ValueFieldName))
        //        {
        //            foreach (var lanternRule in this.YAxisInfos.Where(y => y.LanternValueFieldName == rule.ValueFieldName))
        //            {
        //                foreach (var lanternParentPoint in lanternRule.Values.Where(v => v.Time == time))
        //                {
        //                    lanternParentPoint.LanternValue = TemperatureDocument.NullValue;
        //                }
        //            }
        //        }
        //        if (this.IsShadowRule(rule.ValueFieldName))
        //        {
        //            foreach (var shadowRule in this.YAxisInfos.Where(y => y.ShadowValueFieldName == rule.ValueFieldName))
        //            {
        //                foreach (var shadowParentPoint in shadowRule.Values.Where(v => v.Time == time))
        //                {
        //                    shadowParentPoint.ShadowValue = TemperatureDocument.NullValue;
        //                }
        //            }
        //        }
        //    }
        //    rule.Values.RemoveAll(v => v.Time == time);
        //}
        //public void UpdatePointByTimeValue(YAxisInfo rule,DateTime oldTime, DateTime newTime, float value)
        //{
        //    this._Modified = true;
        //    ValuePoint valuePoint = rule.Values.Find(v => v.Time == oldTime);
        //    if (valuePoint == null)
        //    {
        //        return;
        //    }
        //    valuePoint.Time = newTime;
        //    valuePoint.Value = value;
        //    if (!string.IsNullOrEmpty(rule.LanternValueFieldName))
        //    {
        //       var lanternRule = this.YAxisInfos.Find(y => y.ValueFieldName == rule.LanternValueFieldName);
        //       if (lanternRule == null)
        //           valuePoint.LanternValue = TemperatureDocument.NullValue;
        //       else
        //       {
        //          var lanternPoint = lanternRule.Values.Find(v => v.Time == valuePoint.Time);
        //          if (lanternPoint == null)
        //              valuePoint.LanternValue = TemperatureDocument.NullValue;
        //          else
        //              valuePoint.LanternValue = lanternPoint.Value;
        //       }
        //    }
        //    if (!string.IsNullOrEmpty(rule.ShadowValueFieldName))
        //    {
        //        var shadowRule = this.YAxisInfos.Find(y => y.ValueFieldName == rule.ShadowValueFieldName);
        //        if (shadowRule == null)
        //            valuePoint.ShadowValue = TemperatureDocument.NullValue;
        //        else
        //        {
        //            var shadowPoint = shadowRule.Values.Find(v => v.Time == valuePoint.Time);
        //            if (shadowPoint == null)
        //                valuePoint.ShadowValue = TemperatureDocument.NullValue;
        //            else
        //                valuePoint.ShadowValue = shadowPoint.Value;
        //        }
        //    }
        //    if (this.IsLanternRule(rule.ValueFieldName))
        //    {
        //        foreach (var lanternParentRule in this.YAxisInfos.Where(y=>y.LanternValueFieldName==rule.ValueFieldName))
        //        {
        //            foreach (var lanternParentOldPoint in lanternParentRule.Values.Where(l => l.Time == oldTime))
        //            {
        //                if (oldTime != newTime)
        //                    lanternParentOldPoint.LanternValue = TemperatureDocument.NullValue;
        //                else
        //                    lanternParentOldPoint.LanternValue = valuePoint.Value;
        //            }
        //            if (oldTime != newTime)
        //            {
        //                foreach (var lanternParentPoint in lanternParentRule.Values.Where(l => l.Time == newTime))
        //                {
        //                    lanternParentPoint.LanternValue = valuePoint.Value;
        //                }
        //            }
        //        }
        //    }
        //    if (this.IsShadowRule(rule.ValueFieldName))
        //    {
        //        foreach (var shadowParentRule in this.YAxisInfos.Where(y => y.ShadowValueFieldName == rule.ValueFieldName))
        //        {
        //            foreach (var shadowParentOldPoint in shadowParentRule.Values.Where(l => l.Time == oldTime))
        //            {
        //                if (oldTime != newTime)
        //                    shadowParentOldPoint.ShadowValue = TemperatureDocument.NullValue;
        //                else
        //                    shadowParentOldPoint.ShadowValue = valuePoint.Value;
        //            }
        //            if (oldTime != newTime)
        //            {
        //                foreach (var shadowParentPoint in shadowParentRule.Values.Where(l => l.Time == newTime))
        //                {
        //                    shadowParentPoint.ShadowValue = valuePoint.Value;
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion
        public void DeletePointByTime(YAxisInfo rule, DateTime time)
        {
            this._Modified = true;
            DateTime startDate = this.GetDate(this.RuntimeStartTime);
            int tickIndex = this.GetTickIndex(time);
            int dayIndex = this.GetDayIndex(time, startDate);
            rule.Values.RemoveAll(v => this.GetDayIndex(v.Time) == dayIndex && this.GetTickIndex(v.Time) == tickIndex);
        }
        public void SetPointByTimeValue(TitleLine line, DateTime time, string value)
        {
            this._Modified = true;
            DateTime startDate = this.GetDate(this.RuntimeStartTime);
            int dayIndex = this.GetDayIndex(time, startDate);
            int tickIndex = this.GetTickIndex(time);
            int stepIndex = tickIndex / line.TickStep;
            ValuePoint point = null;
            point = line.Values.Find(v => this.GetDayIndex(v.Time, startDate) == dayIndex && this.GetTickIndex(v.Time)/line.TickStep == stepIndex);

            if (point == null)
            {
                line.Values.AddByTimeText(time, value);
            }
            else
            {
                point.Time = time;
                point.Text = value;
            }
        }
        public void SetPointByTimeValue(YAxisInfo rule, DateTime time, float value,string token=null,bool cutOff=false)
        {
            if (rule.TextFlagMode)
                return;
            this._Modified = true;
            DateTime startDate = this.GetDate(this.RuntimeStartTime);
            int tickIndex = this.GetTickIndex(time);
            int dayIndex = this.GetDayIndex(time, startDate);
            rule.Values.RemoveAll(v=>this.GetDayIndex(v.Time)==dayIndex && this.GetTickIndex(v.Time)==tickIndex);
            rule.Values.AddByTimeValue(time, value,token,cutOff);
        }
        public void SetPointByTimeText(YAxisInfo rule, DateTime time, string text)
        {
            if (!rule.TextFlagMode)
                return;
            this._Modified = true;
            DateTime startDate = this.GetDate(this.RuntimeStartTime);
            int tickIndex = this.GetTickIndex(time);
            int dayIndex = this.GetDayIndex(time, startDate);
            rule.Values.RemoveAll(v => this.GetDayIndex(v.Time) == dayIndex && this.GetTickIndex(v.Time) == tickIndex);
            rule.Values.AddByTimeText(time, text);
        }

        #region 辅助方法


        /// <summary>
        /// 获取指定时间所在刻度的索引
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int GetTickIndex(DateTime time)
        {
            float dHours = (float)time.Subtract(time.Date).TotalHours;
            for (int i = 0; i < this.Ticks.Count; i++)
            {
                if (i != this.Ticks.Count - 1)
                {
                    if (dHours >= this.Ticks[i].Value && dHours < this.Ticks[i + 1].Value)
                        return i;
                }
                else
                {
                    if (dHours >= this.Ticks[i].Value || dHours < this.Ticks[0].Value)
                        return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 获取指定索引刻度包含几个小时
        /// </summary>
        /// <param name="tickIndex">刻度索引</param>
        /// <returns></returns>
        public float GetTickHours(int tickIndex)
        {
            if (tickIndex < 0 || tickIndex > this.Ticks.Count - 1)
                return float.NaN;
            if (tickIndex == this.Ticks.Count-1)
                return 24 - this.Ticks.Last().Value + this.Ticks[0].Value;
            return this.Ticks[tickIndex + 1].Value - this.Ticks[tickIndex].Value;
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
        /// <summary>
        /// 获取时间范围
        /// item1 最小时间 item2 最大时间
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="days">总共天数(包含开始日期)</param>
        /// <returns></returns>
        public Tuple<DateTime, DateTime> GetDateTimeRange(DateTime startDate, int days)
        {
            if (this.Ticks.Count == 0)
                return null;
            return Tuple.Create<DateTime, DateTime>
                (
                    this.GetMinTime(startDate, true)
                    , this.GetMaxTime(startDate.Date.AddDays(days - 1), true)
                );
        }
        /// <summary>
        /// 判断指定时间是否在指定的日期范围内
        /// </summary>
        /// <param name="time">指定时间</param>
        /// <param name="date">指定日期</param>
        /// <param name="days">总共天数(包含指定日期 由指定日期开始累加)</param>
        /// <returns></returns>
        public bool IsInDateRange(DateTime time, DateTime date, int days = 1)
        {
            Tuple<DateTime, DateTime> timeRange = this.GetDateTimeRange(date, days);
            if (timeRange == null)
                return false;
            return time >= timeRange.Item1 && time < timeRange.Item2;
        }

        #endregion

        /// <summary>
        /// 判断是否是灯笼轴
        /// </summary>
        /// <param name="valueFieldName"></param>
        /// <returns></returns>
        private bool IsLanternRule(string valueFieldName)
        {
            var lanternValueFieldNams = this.YAxisInfos.Where(y => !string.IsNullOrEmpty(y.LanternValueFieldName)).Select(y => y.LanternValueFieldName).Distinct();
            return lanternValueFieldNams.Contains(valueFieldName);
        }
        /// <summary>
        /// 判断是否是阴影轴
        /// </summary>
        /// <param name="valueFieldName"></param>
        /// <returns></returns>
        private bool IsShadowRule(string valueFieldName)
        {
            var lanternValueFieldNams = this.YAxisInfos.Where(y => !string.IsNullOrEmpty(y.ShadowValueFieldName)).Select(y => y.ShadowValueFieldName).Distinct();
            return lanternValueFieldNams.Contains(valueFieldName);
        }
        private ValuePointList GetAllValuePointList()
        {
            ValuePointList valuePointList = new ValuePointList();
            foreach (YAxisInfo current in this.YAxisInfos)
            {
                valuePointList.AddRange(current.Values);
            }
            foreach (TitleLine current in this.HeaderLines)
            {
                if (current.ValueType == TitleLineValueType.Text)
                {
                    valuePointList.AddRange(current.Values);
                }
            }
            foreach (TitleLine current in this.FooterLines)
            {
                if (current.ValueType == TitleLineValueType.Text)
                {
                    valuePointList.AddRange(current.Values);
                }
            }
            return valuePointList;
        }
        /// <summary>
        /// 更新页数
        /// </summary>
        public void UpdateNumOfPage()
        {
            DateTime maxValue = DateTime.MinValue;
            DateTime minValue = DateTime.MinValue;
            this.UpdateNumOfPage(ref maxValue, ref minValue);
        }
        /// <summary>
        /// 更新页数
        /// 返回最新时间与最大时间
        /// </summary>
        /// <param name="maxTime"></param>
        /// <param name="minTime"></param>
        public void UpdateNumOfPage(ref DateTime maxTime, ref DateTime minTime)
        {
            //maxTime = TemperatureDocument.NullDate;
            //minTime = TemperatureDocument.NullDate;
            if (this.SpecifyStartDate > TemperatureDocument.NullDate && this.SpecifyStartDate != DateTime.MinValue)
                minTime = this.SpecifyStartDate.Date.AddHours(this.Ticks[0].Value);
            if (this.SpecifyEndDate.HasValue)
                maxTime = this.SpecifyEndDate.Value;
            ValuePointList valuePointList = this.GetAllValuePointList();
            if (valuePointList.Count > 0)
            {
                foreach (ValuePoint current in valuePointList)
                {
                    if (maxTime == TemperatureDocument.NullDate || maxTime < current.Time)
                    {
                        maxTime = current.Time;
                    }
                    if (minTime == TemperatureDocument.NullDate || minTime > current.Time)
                    {
                        minTime = current.Time;
                    }
                }
                
            }
            if (maxTime == DateTime.MinValue || minTime == DateTime.MinValue)
            {
                var times = this.GetDateTimeRange(DateTime.Now, this.NumOfDaysInOnePage);
                maxTime = times.Item2;
                minTime = times.Item1;
                this._NumOfPages = 1;
                this.PageIndex = 0;
                this._Days = 7;
            }
            else
            {
                maxTime = this.GetMaxTime(maxTime);
                minTime = this.GetMinTime(minTime);
                TimeSpan timeSpan = maxTime.AddDays(1).Subtract(minTime);
                this._Days = timeSpan.Days;
                this._NumOfPages = (int)Math.Ceiling((double)timeSpan.Days / (double)this.NumOfDaysInOnePage);
                if (this._NumOfPages == 0)
                {
                    this._NumOfPages = 1;
                }
                if (this.PageIndex >= this.NumOfPages)
                {
                    this.PageIndex = this.NumOfPages - 1;
                }
                if (this.PageIndex < 0)
                {
                    this.PageIndex = 0;
                }
            }

        }
        /// <summary>
        /// 刷新数据源
        /// </summary>
        public void RefreshDataSource()
        {
            this._Modified = false;
            foreach (HeaderLabel current in this.HeaderLabels)
            {
                if (!string.IsNullOrEmpty(current.DataSourceName))
                {
                    object obj = this.DataSources[current.DataSourceName];
                    if (obj != null)
                    {
                        string value = obj.ToString();
                        if (!string.IsNullOrEmpty(current.ValueFieldName))
                        {
                            CIS.ControlLib.Controls.TemperatureChart.Data.DCSingleDataSource dCSingleDataSource = new CIS.ControlLib.Controls.TemperatureChart.Data.DCSingleDataSource(obj);
                            value = Convert.ToString(dCSingleDataSource.ReadValue(current.ValueFieldName));
                        }
                        current.Value = value;
                    }
                }
            }
            foreach (YAxisInfo rule in this.YAxisInfos)
            {
                if (!string.IsNullOrEmpty(rule.DataSourceName))
                {
                    object obj = this.DataSources[rule.DataSourceName];
                    if (obj != null)
                    {
                        rule.Values.DataBind(obj, rule.TimeFieldName, rule.ValueFieldName, rule.TextFlagMode);
                        rule.Values.SortByTime();
                    }
                    else
                        rule.Values.Clear();
                }
            }
            foreach (TitleLine line in this.FooterLines)
            {
                if (!string.IsNullOrEmpty(line.DataSourceName))
                {
                    object obj = this.DataSources[line.DataSourceName];
                    if (obj != null)
                    {
                        line.Values.DataBind(obj, line.TimeFieldName, line.ValueFieldName, true);
                        line.Values.SortByTime();
                    }
                    else
                        line.Values.Clear();
                }
            }
            foreach (TitleLine line in this.HeaderLines)
            {
                if (!string.IsNullOrEmpty(line.DataSourceName))
                {
                    object obj = this.DataSources[line.DataSourceName];
                    if (obj != null)
                    {
                        line.Values.DataBind(obj, line.TimeFieldName, line.ValueFieldName, true);
                        line.Values.SortByTime();
                    }
                    else
                        line.Values.Clear();
                }
            }
        }
        /// <summary>
        /// 绘制体温单
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect">剪辑区域</param>
        public void Draw(Graphics g, RectangleF clipRect)
        {
            //clipRectangle.Inflate(2f, 2f);
            this.UpdateElementsLayout(g);
            this.DrawFrame(g, clipRect);
            this.DrawContent(g, clipRect);
            this.ClearDrawCache();
        }
        /// <summary>
        /// 判断字符串中存在相关关键字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="key">关键字 ,分隔</param>
        /// <param name="isEqual">true 则以关键字想等 false 则字符串中包含关键字</param>
        /// <returns></returns>
        public bool ExistsKey(string str, string key,bool isEqual=false)
        {
            if (string.IsNullOrEmpty(key))
                return false;
            string[] Key = key.Split(',');
            for (int i = 0; i < Key.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(Key[i]))
                    continue;
                if (isEqual)
                {
                    if (str.ToUpper() == Key[i].ToUpper())
                        return true;
                }
                else
                {
                    if (str.ToUpper().IndexOf(Key[i].ToUpper()) > -1) //存在关键字
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #region 计算出体温单各个元素的边界范围...

        /// <summary>
        /// 计算出最优的大小
        /// </summary>
        /// <param name="originalSizes">原来的大小</param>
        /// <param name="totalSize">总大小</param>
        /// <param name="excepts"></param>
        private void CalculateBetterSize(List<float> originalSizes, float totalSize, List<int> excepts = null)
        {
            int count = originalSizes.Count;
            if (excepts != null)
                count -= excepts.Count;
            if (count == 0)
                return;
            float avg = totalSize / count;
            bool flag = true;
            int i = 0;
            foreach (var item in originalSizes)
            {
                if (excepts != null && excepts.Contains(i))
                {
                    i++;
                    continue;
                }
                if (avg < item)
                {
                    flag = false;
                    if (excepts == null)
                        excepts = new List<int>();
                    excepts.Add(i);
                    CalculateBetterSize(originalSizes, totalSize - item, excepts);
                    break;
                }
                i++;
            }
            if (flag)
            {
                for (int j = 0; j < originalSizes.Count; j++)
                {
                    if (excepts != null && excepts.Contains(j))
                        continue;
                    originalSizes[j] = avg;
                }
            }
        }
        /// <summary>
        /// 计算出网格区域的大小
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        private SizeF CalculateGridSize(Graphics g)
        {
            float gridWidth = this.Width - draw_LeftContentWidth - this.GetSpecifySizeByDocumentUnit(g, this.RightEmptyPadding);
            float gridHeight = this.CacluateGridHeight(g);
            return new SizeF(gridWidth, gridHeight);
        }
        /// <summary>
        /// 计算出左边内容区域的宽度
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        private float CacluateLeftContenWidth(Graphics g)
        {
            float maxWidth = 0;
            //比较出页眉数据行中的宽度
            foreach (var headerLine in this.HeaderLines)
            {
                //判断是否指定了宽度
                if (headerLine.SpecifyTitleWidth > 0)
                    maxWidth = Math.Max(maxWidth, this.GetSpecifySizeByDocumentUnit(g,headerLine.SpecifyTitleWidth));
                else
                {
                    float width = g.MeasureString(headerLine.Title, headerLine.TitleFont == null ? this.Font : headerLine.TitleFont.GetFont()).Width * 1.1f;
                    if (!string.IsNullOrEmpty(headerLine.Group))
                        width += g.MeasureString("嚓", headerLine.TitleFont == null ? this.Font : headerLine.TitleFont.GetFont()).Width * 1.5f;
                    maxWidth = Math.Max(maxWidth, width);
                }
            }
            //比较出数据标尺中的宽度
            float ruleTotalWidth = 0;
            foreach (var yAxis in this.Rules.Where(r=>r.Visible))
            {
                float ruleWidth = 0;

                //判断是否指定了宽度
                if (yAxis.SpecifyTitleWidth > 0)
                    ruleWidth =this.GetSpecifySizeByDocumentUnit(g, yAxis.SpecifyTitleWidth);
                else
                {
                    if (!string.IsNullOrEmpty(yAxis.Title))
                    {
                        if(yAxis.TitleTextDirection== Orientation.Horizontal)
                            ruleWidth = Math.Max(g.MeasureString(yAxis.Title, this.Font).Width * 1.1f, ruleWidth);
                        else
                            ruleWidth = Math.Max(g.MeasureString("嚓", this.Font).Width * 1.1f, ruleWidth);
                    }
                    if (!string.IsNullOrEmpty(yAxis.BottomTitle))
                    {
                        if (yAxis.BottomTitleTextDirection == Orientation.Horizontal)
                            ruleWidth = Math.Max(g.MeasureString(yAxis.BottomTitle, this.Font).Width * 1.1f, ruleWidth);
                        else
                            ruleWidth = Math.Max(g.MeasureString("嚓", this.Font).Width * 1.1f, ruleWidth);
                    }
                    if (yAxis.RuleSymbolVisible)
                        ruleWidth = Math.Max(ruleWidth, this.GetSpecifySizeByDocumentUnit(g,this.SymbolSize));
                    if (yAxis.Values.Count > 0)
                        ruleWidth = Math.Max(ruleWidth, g.MeasureString(yAxis.MaxValue.ToString(), this.Font).Width * 1.1f);
                    if (yAxis.HasScales)
                    {
                        string maxValue = yAxis.Scales.Max(c => c.Value).ToString();
                        if (yAxis.Scales.Exists(y => !string.IsNullOrWhiteSpace(y.Text)))
                        {
                            maxValue = yAxis.Scales.Find(y => y.Text != null && y.Text.Length == yAxis.Scales.Max(s => string.IsNullOrWhiteSpace(s.Text) ? 0 : s.Text.Length)).Text;
                        }


                        ruleWidth = Math.Max(ruleWidth, g.MeasureString(maxValue, this.Font).Width * 1.1f);
                    }
                }
                ruleTotalWidth += ruleWidth;
            }
            maxWidth = Math.Max(ruleTotalWidth, maxWidth);
            //比较出页脚数据行中的宽度
            foreach (var footerLine in this.FooterLines)
            {
                if (footerLine.SpecifyTitleWidth > 0)
                    maxWidth = Math.Max(maxWidth, this.GetSpecifySizeByDocumentUnit(g,footerLine.SpecifyTitleWidth));
                else
                {
                    float width = g.MeasureString(footerLine.Title, footerLine.TitleFont == null ? this.Font : footerLine.TitleFont.GetFont()).Width * 1.1f;
                    if (!string.IsNullOrEmpty(footerLine.Group))
                        width += g.MeasureString("嚓", footerLine.TitleFont == null ? this.Font : footerLine.TitleFont.GetFont()).Width * 1.5f;
                    maxWidth = Math.Max(maxWidth, width);
                }
            }

            draw_LeftContentWidth = maxWidth;
            //最终获取到左边内容区需要的宽度
            return maxWidth;
        }
        /// <summary>
        /// 计算出网格区域高度
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        private float CacluateGridHeight(Graphics g)
        {
            //获取标题区域高度
            float titleHeight = 0;
            if (this.ViewMode .HasFlag( DocumentViewMode.Page))
            {
                if (this.SpecifyTitleHeight > 0)
                    titleHeight = this.GetSpecifySizeByDocumentUnit(g, this.SpecifyTitleHeight);
                else
                    titleHeight = this.GetFontHeight(g, this.TitleFont) * 1.5f;
            }

            //获取页眉区域高度
            float labelHeight = this.GetFontHeight(g,this.Font) * 1.5f;
            //获取数据行总高度
            float linesHeight = this.GetTitleLinesHeight(g, this.HeaderLines);
            linesHeight += this.GetTitleLinesHeight(g, this.FooterLines);
            RectangleF footerDecriptionRectangle = this.GetFooterDescriptionRectangle(g);
            return this.Height - (titleHeight + labelHeight + linesHeight) -footerDecriptionRectangle.Height;
        }
        /// <summary>
        /// 获取绘制数据行集合所需要的高度
        /// </summary>
        /// <param name="g"></param>
        /// <param name="titleLines"></param>
        /// <returns></returns>
        private float GetTitleLinesHeight(Graphics g, TitleLineList titleLines)
        {
            StringFormat vCenterFormat = null;
            //默认一行所占的高度
            float defalutLineHeight = 0;
            if (titleLines.Exists(t => !string.IsNullOrWhiteSpace(t.Group)))
            {
                //垂直居中
                vCenterFormat = new StringFormat();
                vCenterFormat.LineAlignment = StringAlignment.Center;
                vCenterFormat.Alignment = StringAlignment.Center;
                vCenterFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                defalutLineHeight = this.GetFontHeight(g,this.Font) * 1.5f;
            }
            //记录总共高度
            float totalHeight = 0;

            for (int i = 0; i < titleLines.Count; i++)
            {
                string group = titleLines[i].Group;
                //判断是否有组头
                if (!string.IsNullOrWhiteSpace(group))
                {
                    //计算组文本最少需要占的高度
                    float groupHeight = g.MeasureString(group
                        , (titleLines[i].TitleFont == null ? this.Font : titleLines[i].TitleFont.GetFont())
                        , Point.Empty, vCenterFormat).Height * 1.1f;
                    //组包含的实际行有多大
                    float height = this.GetTitleLineHeight(g,titleLines[i]);
                    for (int j = i + 1; j < titleLines.Count; j++)
                    {
                        if (group == titleLines[j].Group)
                        {
                            height += this.GetTitleLineHeight(g,titleLines[j]);
                        }
                        else
                        {
                            i = j - 1;
                            break;
                        }
                    }
                    //判断实际行总高是否大于组文本需要的最小高度
                    //是则 不需要添加虚拟行凑数
                    //否添加虚拟行高补充
                    if (height > groupHeight)
                        totalHeight += height;
                    else
                    {
                        totalHeight += (float)Math.Ceiling(((groupHeight - height) / defalutLineHeight)) * defalutLineHeight
                            +  height;
                    }
                }
                else
                {
                    totalHeight += this.GetTitleLineHeight(g,titleLines[i]);
                }
            }
            if (vCenterFormat != null)
            {
                vCenterFormat.Dispose();
                vCenterFormat = null;
            }
            return totalHeight;
        }
        /// <summary>
        /// 获取指定数据行的行高
        /// 不包含组头高度
        /// </summary>
        /// <param name="titleLine"></param>
        /// <returns></returns>
        private float GetTitleLineHeight(Graphics g, TitleLine titleLine)
        {
            if (titleLine.SpecifyHeight > 0)
                return this.GetSpecifySizeByDocumentUnit(g, titleLine.SpecifyHeight);
            if (titleLine.TitleFont == null)
                return this.GetFontHeight(g,this.Font) * 1.5f;
            return this.GetFontHeight(g, titleLine.TitleFont.GetFont()) * 1.5f;
        }
        /// <summary>
        /// 计算出每个页眉标签的边界区域
        /// </summary>
        /// <param name="g"></param>
        /// <param name="leftTopLocation">左上角起始坐标</param>
        private void CalculateHeaderLabelsBound(Graphics g, ref PointF leftTopLocation)
        {
            List<float> originalWidths = new List<float>();
            float space = 0;//间距
            float labelHeight = this.GetFontHeight(g,this.Font) * 1.5f; //标签高度
            float left = leftTopLocation.X;//记录起始的左端坐标
            //获取每个标签文本需要显示最少需要的宽度
            foreach (var headerLabel in this.HeaderLabels)
            {
                originalWidths.Add(g.MeasureString(headerLabel.ToString(), this.Font).Width * 1.1f);
            }
            if (this.ViewMode .HasFlag( DocumentViewMode.Page))
            {
                //在分页模式下 标签的宽度将会使用最优的宽度
                this.CalculateBetterSize(originalWidths, this.Width);
            }
            else
            {
                //非分页模式下 每个标签文本之间会添加固定大小的间距
                space = 20;
            }
            for (int i = 0; i < originalWidths.Count; i++)
            {
                this.HeaderLabels[i].SetBoundCore(leftTopLocation.X, leftTopLocation.Y, originalWidths[i], labelHeight);
                leftTopLocation.X += originalWidths[i] + space;
            }
            leftTopLocation.X = left;
            leftTopLocation.Y += labelHeight;
        }
        /// <summary>
        /// 计算出数据行的边界区域
        /// </summary>
        /// <param name="g"></param>
        /// <param name="titleLines"></param>
        /// <param name="leftTopLocation"></param>
        /// <param name="leftContentWidth"></param>
        private void CalculateTitleLinesBound(Graphics g, TitleLineList titleLines, ref PointF leftTopLocation, float leftContentWidth)
        {
            float rightEmptyPadding = this.GetSpecifySizeByDocumentUnit(g, this.RightEmptyPadding);
            //计算出页眉数据行的边界范围;
            StringFormat vCenterFormat = null;
            float groupWidth = 0;
            //默认一行所占的高度
            float defalutLineHeight = 0;
            if (titleLines.Exists(t => !string.IsNullOrWhiteSpace(t.Group)))
            {
                //垂直居中
                vCenterFormat = new StringFormat();
                vCenterFormat.LineAlignment = StringAlignment.Center;
                vCenterFormat.Alignment = StringAlignment.Center;
                vCenterFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                groupWidth = g.MeasureString("嚓", this.Font).Width * 1.5f;
                defalutLineHeight = this.GetFontHeight(g,this.Font) * 1.5f;
            }

            for (int i = 0; i < titleLines.Count; i++)
            {
                string group = titleLines[i].Group;
                //判断是否有组头
                if (!string.IsNullOrWhiteSpace(group))
                {
                    //计算组文本最少需要占的高度
                    float groupHeight = g.MeasureString(group
                        , this.Font
                        , Point.Empty, vCenterFormat).Height * 1.1f;
                    //组包含的实际行有多大
                    float height = this.GetTitleLineHeight(g,titleLines[i]);
                    titleLines[i].TitleWidth = leftContentWidth - groupWidth;
                    titleLines[i].SetBoundCore(leftTopLocation.X + groupWidth, leftTopLocation.Y, this.Width - groupWidth-rightEmptyPadding, height);
                    leftTopLocation.Y += titleLines[i].Height;
                    for (int j = i + 1; j < titleLines.Count; j++)
                    {
                        if (group == titleLines[j].Group)
                        {
                            titleLines[j].SetBoundCore(leftTopLocation.X + groupWidth, leftTopLocation.Y, this.Width - groupWidth - rightEmptyPadding, this.GetTitleLineHeight(g,titleLines[j]));
                            titleLines[j].TitleWidth = leftContentWidth - groupWidth;
                            height += titleLines[j].Height;
                            leftTopLocation.Y += titleLines[j].Height;
                        }
                        else
                        {
                            i = j - 1;
                            break;
                        }
                    }
                    //判断实际行总高是否大于组文本需要的最小高度
                    //是则 不需要添加虚拟行凑数
                    //否添加虚拟行高补充
                    if (height < groupHeight)
                    {
                        //leftTopLocation.Y -= titleLines[i].Height;
                        leftTopLocation.Y += (float)Math.Ceiling(((groupHeight - height) / defalutLineHeight)) * defalutLineHeight;
                    }
                }
                else
                {
                    titleLines[i].SetBoundCore(leftTopLocation.X, leftTopLocation.Y, this.Width-rightEmptyPadding, this.GetTitleLineHeight(g,titleLines[i]));
                    titleLines[i].TitleWidth = leftContentWidth;
                    leftTopLocation.Y += titleLines[i].Height;
                }
            }
            if (vCenterFormat != null)
            {
                vCenterFormat.Dispose();
                vCenterFormat = null;
            }

        }
        /// <summary>
        /// 计算出数据标尺的边界范围
        /// </summary>
        /// <param name="g"></param>
        /// <param name="leftTopLocation"></param>
        /// <param name="leftContentWidth"></param>
        /// <param name="gridHeight"></param>
        private void CalculateYAxisInfosBound(Graphics g, ref PointF leftTopLocation, float leftContentWidth, float gridHeight)
        {
            float left = leftTopLocation.X;//记录左端起始坐标
            //记录数据标尺的最佳宽度
            List<float> orignalWidths = new List<float>();
            foreach (var yAxis in this.Rules.Where(r=>r.Visible))
            {
                if (yAxis.SpecifyTitleWidth > 0)
                    orignalWidths.Add(this.GetSpecifySizeByDocumentUnit(g, yAxis.SpecifyTitleWidth));
                else
                {
                    float ruleWidth = 0;
                    if (!string.IsNullOrEmpty(yAxis.Title))
                    {
                        if (yAxis.TitleTextDirection == Orientation.Horizontal)
                            ruleWidth = Math.Max(g.MeasureString(yAxis.Title, this.Font).Width * 1.1f, ruleWidth);
                        else
                            ruleWidth = Math.Max(g.MeasureString("嚓", this.Font).Width * 1.1f, ruleWidth);
                    
                    }
                    if (!string.IsNullOrEmpty(yAxis.BottomTitle))
                    {
                        if (yAxis.BottomTitleTextDirection == Orientation.Horizontal)
                            ruleWidth = Math.Max(g.MeasureString(yAxis.BottomTitle, this.Font).Width * 1.1f, ruleWidth);
                        else
                            ruleWidth = Math.Max(g.MeasureString("嚓", this.Font).Width * 1.1f, ruleWidth);
                    
                    }
                     if (yAxis.RuleSymbolVisible)
                        ruleWidth = Math.Max(ruleWidth, this.SymbolSize);
                    if (yAxis.Values.Count > 0)
                        ruleWidth = Math.Max(ruleWidth, g.MeasureString(yAxis.MaxValue.ToString(), this.Font).Width * 1.1f);
                    if (yAxis.HasScales)
                    {
                        string maxValue = yAxis.Scales.Max(c => c.Value).ToString();
                        if (yAxis.Scales.Exists(y => !string.IsNullOrWhiteSpace(y.Text)))
                        {
                            maxValue = yAxis.Scales.Find(y => y.Text != null && y.Text.Length == yAxis.Scales.Max(s => string.IsNullOrWhiteSpace(s.Text) ? 0 : s.Text.Length)).Text;
                        }
                        

                        ruleWidth = Math.Max(ruleWidth,g.MeasureString(maxValue, this.Font).Width * 1.1f);
                    }
                    orignalWidths.Add(ruleWidth);
                }
            }
            this.CalculateBetterSize(orignalWidths, leftContentWidth);
            //设置数据标尺的边界范围
            int index = 0;
            this.YAxisInfos.Reset();
            foreach (var yAxis in this.Rules.Where(r => r.Visible))
            {

                yAxis.SetBoundCore(leftTopLocation.X, leftTopLocation.Y, orignalWidths[index], gridHeight);
                leftTopLocation.X += orignalWidths[index];
                index++;
            }
            leftTopLocation.X = left;
            leftTopLocation.Y += gridHeight;
        }
        
        /// <summary>
        /// 更新体温单的各个元素的布局
        /// </summary>
        /// <param name="g"></param>
        private void UpdateElementsLayout(Graphics g)
        {
            PointF location = new PointF(this.Left, this.Top);
            //当视图模式为页面模式时需要计算出标题区的高度
            if (this.ViewMode .HasFlag( DocumentViewMode.Page))
            {
                float titleHeight = 0;
                if (this.SpecifyTitleHeight > 0)
                    titleHeight = this.GetSpecifySizeByDocumentUnit(g, this.SpecifyTitleHeight);
                else
                    titleHeight = this.GetFontHeight(g, this.TitleFont) * 1.5f;
                location.Y += titleHeight;
            }
            //计算出页眉标签的边界范围
            this.CalculateHeaderLabelsBound(g, ref location);
            //计算出左边区域大行头区域大小
            this.CacluateLeftContenWidth(g);
            //计算出页眉数据行的边界范围
            this.CalculateTitleLinesBound(g, this.HeaderLines, ref location, draw_LeftContentWidth);
            //获取网格区域的大小
            SizeF gridSize = this.CalculateGridSize(g);
            //更新网格区域的边界
            this._GirdRectangle = new RectangleF(location.X + draw_LeftContentWidth, location.Y, gridSize.Width, gridSize.Height);
            //计算出数据标尺区域的边界范围
            this.CalculateYAxisInfosBound(g, ref location, draw_LeftContentWidth, gridSize.Height);
            //计算出页脚数据行的边界范围
            this.CalculateTitleLinesBound(g, this.FooterLines, ref location, draw_LeftContentWidth);
        }

        #endregion
        /// <summary>
        /// 获取当前画布单位的指定大小
        /// </summary>
        /// <param name="g"></param>
        /// <param name="specifySize"></param>
        /// <returns></returns>
        private float GetSpecifySizeByDocumentUnit(Graphics g, float specifySize)
        {
            return GraphicsHelper.Convert(specifySize, GraphicsUnit.Document, g.PageUnit);
        }
        /// <summary>
        /// 获取当前画布单位的指定大小
        /// </summary>
        /// <param name="g"></param>
        /// <param name="specifySize"></param>
        /// <returns></returns>
        private float GetSpecifySizeByPixelUnit(Graphics g, float specifySize)
        {
            return GraphicsHelper.Convert(specifySize, GraphicsUnit.Pixel, g.PageUnit);
        }

        #region 绘制

        /// <summary>
        /// 获取主体区域边界
        /// </summary>
        /// <returns></returns>
        private RectangleF GetBodyRectangle(Graphics g)
        {
            float left = this.Left;
            float top = this.Top;
            float width = this.Width;
            float height = this.Height;
            RectangleF footerDecriptionRectangle = this.GetFooterDescriptionRectangle(g);
            height -= footerDecriptionRectangle.Height;
            if (this.HeaderLabels.Count > 0)
            {
                top = this.HeaderLabels[0].Bottom;
            }
            else
            {
                if (this.HeaderLines.Count > 0)
                    top = this.HeaderLines[0].Top;
                else
                    if (this.YAxisInfos.Count(y => !y.TextFlagMode && y.Visible) > 0)
                        top = this.YAxisInfos.First(y => !y.TextFlagMode && y.Visible).Top;
                    else
                        if (this.FooterLines.Count > 0)
                            top = this.FooterLines[0].Top;
                        else
                            top = this.Top;
            }
            return new RectangleF(left, top, width, height - top + this.Top);
        }
        /// <summary>
        /// 获取页脚注释边界范围
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        private RectangleF GetFooterDescriptionRectangle(Graphics g)
        {
            if (!this.ViewMode .HasFlag( DocumentViewMode.Page))
                return RectangleF.Empty;
            if (string.IsNullOrWhiteSpace(this.FooterDescription))
                return RectangleF.Empty;
            float footerDescriptionHeight = this.GetFontHeight(g,this.Font) * 1.5f;
            return new RectangleF(this.Left, this.Top + this.Height - footerDescriptionHeight, this.Width, footerDescriptionHeight);
        }

        public void DrawFrame(Graphics g, RectangleF clipRect)
        {
            this.DrawTitle(g, clipRect);
            this.DrawHeaderLabels(g, clipRect);
         
            this.DrawTitleLinesFrame(g, clipRect, this.HeaderLines);
            this.DrawYAxisInfosFrame(g, clipRect);
            RectangleF gridRect = this._GirdRectangle;
            this.DrawGrid(g, clipRect, gridRect);
            this.DrawTitleLinesFrame(g, clipRect, this.FooterLines);

            //绘制警戒线
            foreach (var yAxis in this.YAxisInfos.Where(y=>!string.IsNullOrEmpty(y.RedLineValue)))
            {
                float redLineY = this.GetY(yAxis, Convert.ToSingle(yAxis.RedLineValue));
                if (TemperatureDocument.IsNaN(redLineY))
                    continue;
                RectangleF redLineRect = new RectangleF(gridRect.Left, redLineY, gridRect.Width, this.GetSpecifySizeByPixelUnit(g, this.GridVerticalSplitLineWidth));
                if(this.NeedDraw(clipRect,redLineRect))
                    g.FillRectangle(Brushes.Red, redLineRect);
            }

            RectangleF bodyBound = this.GetBodyRectangle(g);
            //绘制大垂直分割线
            float splitWidth = gridRect.Width / this.RuntimeNumOfDaysInOnePage;
            float splitLeft = gridRect.Left + splitWidth;
            for (int i = 0; i < this.RuntimeNumOfDaysInOnePage ; i++)
            {
                RectangleF lineRect = new RectangleF(splitLeft, bodyBound.Top, this.BigSplitLineThickness, bodyBound.Height);
                if (this.NeedDraw(clipRect, lineRect))
                {
                    g.FillRectangle(this.GetBrush(this.BigSplitLineColor), lineRect);
                }
                splitLeft += splitWidth;
            }

            RectangleF leftSplitLine = new RectangleF(this.Left + draw_LeftContentWidth, bodyBound.Top, 1, bodyBound.Height);
            //绘制左内容区域的分割线
            if (this.NeedDraw(clipRect, leftSplitLine))
                g.FillRectangle(this.GetBrush(this.ForeColor), leftSplitLine);
            //绘制外边框
            Pen borderPen = null;
            if (this.BorderSize > 0 && this.BorderColor.A != 0)
            {
                borderPen = new Pen(this.BorderColor, this.GetSpecifySizeByPixelUnit(g, this.BorderSize));
            }
            else
            {
                borderPen = new Pen(this.ForeColor, 1);
            }
            g.DrawRectangle(borderPen, bodyBound.X, bodyBound.Y, bodyBound.Width, bodyBound.Height);
            borderPen.Dispose();
            //绘制页脚注释文本
            if (!string.IsNullOrWhiteSpace(this.FooterDescription))
            {
                RectangleF footerDescriptionRectangle =this.GetFooterDescriptionRectangle(g);
                if(this.NeedDraw(clipRect,footerDescriptionRectangle))
                    g.DrawString(this.FooterDescription, this.Font, this.GetBrush(this.ForeColor), footerDescriptionRectangle, this.GetStringFromat(ContentAlignment.MiddleLeft));
            }
        }

        public void DrawContent(Graphics g, RectangleF clipRect)
        {
            this.DrawTitleLinesContent(g, clipRect, this.HeaderLines);
            this.DrawYAxisesContent(g, clipRect);
            this.DrawTitleLinesContent(g, clipRect, this.FooterLines);
            this.DrawScaleplateContent(g, clipRect, this.Scalepaltes);
            foreach (var label in this.Labels)
            {
                this.DrawLabel(g, clipRect, label);
            }
        }

        private void DrawScaleplateContent(Graphics g, RectangleF clip, ScaleplateList scalepaltes)
        {

            foreach (var item in scalepaltes)
            {
                switch (item.HostType)
                {
                    case ElementHostType.Document:
                        break;
                    case ElementHostType.Yaxis:
                        break;
                    case ElementHostType.LineHeader:
                        break;
                    case ElementHostType.Grid:
                        this.DrawScaleplateByGridHost(g, clip, item);
                        break;
                    default:
                        break;
                }
            }
        }
        private void DrawScaleplateByGridHost(Graphics g,RectangleF clip,Scaleplate scaleplate)
        {
            if (!scaleplate.SupportViewMode.HasFlag(this.ViewMode))
                return;
            float cellWidth = this.GridRectangle.Width / (this.Ticks.Count * this.RuntimeNumOfDaysInOnePage);
            float cellHeight = this.GridRectangle.Height / (this.IntervalCount * this.GridVerticalSplitNum + this.GridTopPadding + this.GridBottomPadding);
            float offset_x = this.GridRectangle.Left;
            float offset_y = this.GridRectangle.Top + (cellHeight * this.GridTopPadding);
            offset_x += cellWidth * scaleplate.X;
            offset_y += cellHeight * scaleplate.Y;
            g.TranslateTransform(offset_x, offset_y);
            scaleplate.StartHeight = scaleplate.TopMargin * cellHeight;
            scaleplate.Height = scaleplate.Length * cellHeight;
            scaleplate.SmallTickIntervel = scaleplate.IntervelSize * cellHeight;
            new ScaleplateRender(g, scaleplate).Draw();
            g.TranslateTransform(-offset_x, -offset_y);
        }

        /// <summary>
        /// 绘制标题
        /// </summary>
        /// <param name="g">绘制对象</param>
        /// <param name="clipRect">剪辑区域</param>
        /// <param name="drawPosition">绘制的起始位置</param>
        private void DrawTitle(Graphics g, RectangleF clipRect)
        {
            //仅当视图模式为页面模式才绘制标题
            if (this.ViewMode .HasFlag( DocumentViewMode.Page))
            {
                float titleHeight = 0;
                if (this.SpecifyTitleHeight > 0)
                    titleHeight = this.GetSpecifySizeByDocumentUnit(g, this.SpecifyTitleHeight);
                else
                    titleHeight = this.GetFontHeight(g,this.TitleFont) * 1.5f;
                //获取标题区域
                RectangleF titleRect = new RectangleF(this.Left, this.Top, this.Width, titleHeight);
                if (this.NeedDraw(clipRect, titleRect))
                {
                    //文本对齐方式为顶端居中对齐
                    g.DrawString(this.Title, this.TitleFont, this.GetBrush(this.ForeColor), titleRect, this.GetStringFromat(ContentAlignment.TopCenter,false));
                }
            }

        }
        /// <summary>
        /// 绘制页眉标签
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        private void DrawHeaderLabels(Graphics g, RectangleF clipRect)
        {
            foreach (var headerLabel in HeaderLabels)
            {
                RectangleF drawRect = headerLabel.GetBound();
                if (this.NeedDraw(clipRect, drawRect))
                {
                    float titleWidth = 0;
                    if (!string.IsNullOrWhiteSpace(headerLabel.Title))
                    {
                        if (!this.ForeColor.IsEmpty && this.ForeColor.A != 0)
                            g.DrawString(headerLabel.Title, this.Font, this.GetBrush(this.ForeColor), drawRect.Location);
                        titleWidth = g.MeasureString(headerLabel.Title, this.Font).Width;
                    }
                    if (headerLabel.ForeColor.A != 0)
                        g.DrawString(headerLabel.Text, this.Font, this.GetBrush(headerLabel.ForeColor), new PointF(drawRect.Location.X + titleWidth, drawRect.Y));
                }
            }
        }
        #region 绘制体温单框架....

        /// <summary>
        /// 绘制数据行集合框架
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="titleLines"></param>
        private void DrawTitleLinesFrame(Graphics g, RectangleF clipRect, TitleLineList titleLines)
        {
            StringFormat vCenterFormat = null;
            //默认一行所占的高度
            float defalutLineHeight = 0;
            float groupWidth = 0;
            if (titleLines.Exists(t => !string.IsNullOrWhiteSpace(t.Group)))
            {
                //垂直居中
                vCenterFormat = new StringFormat();
                vCenterFormat.LineAlignment = StringAlignment.Center;
                vCenterFormat.Alignment = StringAlignment.Center;
                vCenterFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                groupWidth = g.MeasureString("嚓", this.Font).Width * 1.5f;

                defalutLineHeight = this.GetFontHeight(g,this.Font) *1.5f;
            }

            for (int i = 0; i < titleLines.Count; i++)
            {
                string group = titleLines[i].Group;
                //判断是否有组头
                if (!string.IsNullOrWhiteSpace(group))
                {
                    int firstIndex = i;
                    this.DrawTitleLineTitle(g, clipRect, titleLines[i]);
                    //计算组文本最少需要占的高度
                    float groupHeight = g.MeasureString(group
                        , (titleLines[i].TitleFont == null ? this.Font : titleLines[i].TitleFont.GetFont())
                        , Point.Empty, vCenterFormat).Height * 1.1f;
                    //组包含的实际行有多大
                    float height = titleLines[i].Height;

                    for (int j = i + 1; j < titleLines.Count; j++)
                    {
                        if (group == titleLines[j].Group)
                        {
                            height += titleLines[j].Height;
                            this.DrawTitleLineTitle(g, clipRect, titleLines[j]);
                        }
                        else
                        {
                            i = j - 1;
                            break;
                        }
                    }
                    //判断实际行总高是否大于组文本需要的最小高度
                    //是则 不需要添加虚拟行凑数
                    //否添加虚拟行高补充
                    if (height < groupHeight)
                    {
                        //绘制虚拟行
                        int inventedLineCount = (int)Math.Ceiling(((groupHeight - height) / defalutLineHeight));
                        for (int index = 0; index < inventedLineCount; index++)
                        {
                            RectangleF topLine=new RectangleF(titleLines[i].Left
                                    , titleLines[i].Top + titleLines[i].Height + (index) * defalutLineHeight
                                    , titleLines[i].Width
                                    , 1);
                            //绘制上边框线
                            if (this.NeedDraw(clipRect, topLine))
                                g.FillRectangle(this.GetBrush(this.ForeColor), topLine);
                            height += defalutLineHeight;
                        }

                    }
                    RectangleF splitLine =new RectangleF(titleLines[firstIndex].Left, titleLines[firstIndex].Top, 1, height);

                    //绘制左边的垂直分割线
                    if(this.NeedDraw(clipRect,splitLine))
                        g.FillRectangle(this.GetBrush(this.ForeColor), splitLine);
                    splitLine = new RectangleF(titleLines[firstIndex].Left - groupWidth, titleLines[firstIndex].Top, groupWidth, 1);
                    //绘制组头的上边框
                    if(this.NeedDraw(clipRect,splitLine))
                        g.FillRectangle(this.GetBrush(this.ForeColor), splitLine);
                    RectangleF groupRect =new RectangleF(titleLines[firstIndex].Left - groupWidth, titleLines[firstIndex].Top, groupWidth, height);
                    //绘制组名称
                    if (this.NeedDraw(clipRect, groupRect))
                        g.DrawString(group, this.Font, this.GetBrush(this.ForeColor), groupRect, vCenterFormat);
                    splitLine = new RectangleF(titleLines[firstIndex].Left - groupWidth, titleLines[firstIndex].Top + height, groupWidth, 1);
                    //绘制组头的下边框
                    if (this.NeedDraw(clipRect, groupRect))
                        g.FillRectangle(this.GetBrush(this.ForeColor), splitLine);
                     
                }
                else
                {
                    this.DrawTitleLineTitle(g, clipRect, titleLines[i]);
                }
            }
            if (vCenterFormat != null)
            {
                vCenterFormat.Dispose();
                vCenterFormat = null;
            }
        }
        /// <summary>
        /// 绘制数据行标题栏
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="titleLine"></param>
        private void DrawTitleLineTitle(Graphics g, RectangleF clipRect, TitleLine titleLine)
        {
            RectangleF titleLineBound = titleLine.GetBound();
            if (this.NeedDraw(clipRect, titleLineBound))
            {
                RectangleF splitLine = new RectangleF(titleLineBound.X, titleLineBound.Y, titleLineBound.Width, 1);
                //绘制上边距线条
                if(this.NeedDraw(clipRect,splitLine))
                    g.FillRectangle(this.GetBrush(this.ForeColor), splitLine);

                #region 绘制标题栏区域...

                //获取标题栏区域
                RectangleF titleBound = titleLine.GetTitleBound();
                //判断是否需要要绘制标题栏区域
                if (this.NeedDraw(clipRect, titleBound))
                {
                    //绘制标题栏背景色
                    if (!titleLine.TitleBackColor.IsEmpty
                        && titleLine.TitleBackColor.A != 0
                        && !titleLine.TitleBackColor.Equals(this.BackColor))
                    {
                        //仅当背景色不为透明 且背景色不为页面背景色时 会填充自己本身的背景色
                        g.FillRectangle(this.GetBrush(titleLine.TitleBackColor), titleBound);
                    }
                    //获取标题栏字体
                    Font titleFont = this.Font;
                    if (titleLine.TitleFont != null)
                        titleFont = titleLine.TitleFont.GetFont();
                    //获取标题栏前景色
                    Color titleForeColor = titleLine.TitleForeColor;
                    if (titleLine.TitleForeColor.IsEmpty)
                        titleForeColor = this.ForeColor;
                    if (!string.IsNullOrWhiteSpace(titleLine.Title)
                        && titleForeColor.A != 0)
                    {
                        if (titleLine.ShowSeparatorLine && !string.IsNullOrEmpty(titleLine.SeparatorChar))
                        {
                            var titles= titleLine.Title.Split(titleLine.SeparatorChar[0]);
                            float cellWidth = titleBound.Width / titles.Length;
                            for (int i = 0; i < titles.Length; i++)
                            {
                                g.DrawString(titles[i], titleFont, this.GetBrush(titleForeColor), new RectangleF(titleBound.Left + cellWidth * i, titleBound.Top, cellWidth, titleBound.Height), this.GetStringFromat(titleLine.TitleTextAlign));
                                if (i < titles.Length )
                                {
                                    //绘制分割线
                                    g.FillRectangle(this.GetBrush(this.ForeColor), new RectangleF(titleBound.Left + cellWidth * (i + 1), titleBound.Top, 1, titleBound.Height));
                                }
                            }
                       
                        }
                        else
                            g.DrawString(titleLine.Title, titleFont, this.GetBrush(titleForeColor), titleBound, this.GetStringFromat(titleLine.TitleTextAlign));
                    }
                }

                #endregion

            }

        }
        /// <summary>
        /// 绘制数据标尺
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        private void DrawYAxisInfosFrame(Graphics g, RectangleF clipRect)
        {
            foreach (var yAxis in this.Rules.Where(r=>r.Visible))
            {
                this.DrawRule(g, clipRect, yAxis);
            }
        }
        /// <summary>
        /// 绘制数据标尺
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="yAxis"></param>
        private void DrawRule(Graphics g, RectangleF clipRect, YAxisInfo yAxis)
        {
            float titleHeight =0;
           
            RectangleF ruleRect = yAxis.GetBound();
            if (this.NeedDraw(clipRect, ruleRect))
            {
                //绘制标尺区域的背景色
                if (yAxis.ClickVisible && !yAxis.ValueVisible)
                {
                    g.FillRectangle(this.GetBrush(SystemColors.Highlight), ruleRect);
                }
                else if (!yAxis.TitleBackColor.IsEmpty && yAxis.TitleBackColor.A != 0)
                {
                    g.FillRectangle(this.GetBrush(yAxis.TitleBackColor), ruleRect);
                }
                RectangleF splitLine =new RectangleF(ruleRect.Left, ruleRect.Top, ruleRect.Width, 1);
                //绘制上分割线
                if (this.NeedDraw(clipRect, splitLine))
                    g.FillRectangle(this.GetBrush(this.ForeColor), splitLine);
                //标尺区域标题
                if (!string.IsNullOrWhiteSpace(yAxis.Title) && this.ForeColor.A != 0)
                {
                    if (yAxis.TitleTextDirection == Orientation.Horizontal)
                        titleHeight = this.GetFontHeight(g, this.Font) * 1.1f;
                    else
                        titleHeight = g.MeasureString(yAxis.Title,this.Font,PointF.Empty,this.GetStringFromat(ContentAlignment.MiddleCenter,false,true)).Height*1.1f;
                    RectangleF titleRect = new RectangleF(ruleRect.Left, ruleRect.Top, ruleRect.Width, titleHeight);
                    //if(yAxis.)
                    if (this.NeedDraw(clipRect, titleRect))
                    {
                        g.DrawString(yAxis.Title, this.Font, this.GetBrush(this.ForeColor), titleRect, this.GetStringFromat(yAxis.TitleTextDirection == Orientation.Vertical?ContentAlignment.MiddleLeft: ContentAlignment.MiddleCenter, false, yAxis.TitleTextDirection == Orientation.Vertical));
                    }
                }
                //绘制标尺符号
                if (yAxis.RuleSymbolVisible && yAxis.SymbolStyle != SymbolStyle.None)
                {
                    this.DrawSymbol(g, clipRect, ruleRect.Left + ruleRect.Width/2f, ruleRect.Top + titleHeight+this.SymbolSize/2f, yAxis.SymbolStyle, yAxis.SymbolColor,this.GetSpecifySizeByDocumentUnit(g,this.SymbolSize),yAxis.SymbolText,this.Font,yAxis.SymbolImage);
                }
                //绘制刻度值
                this.DrawRuleTick(g, clipRect, yAxis);
                //标尺区域底部标题
                if (!string.IsNullOrWhiteSpace(yAxis.BottomTitle) && this.ForeColor.A != 0)
                {
                    if (yAxis.BottomTitleTextDirection == Orientation.Horizontal)
                        titleHeight = this.GetFontHeight(g, this.Font) * 1.1f;
                    else
                        titleHeight = g.MeasureString(yAxis.BottomTitle, this.Font, PointF.Empty, this.GetStringFromat(ContentAlignment.MiddleCenter, false, true)).Height * 1.1f;
                    
                    RectangleF titleRect = new RectangleF(ruleRect.Left, ruleRect.Top +yAxis.Height-titleHeight, ruleRect.Width, titleHeight);
                    if (this.NeedDraw(clipRect, titleRect))
                    {
                        g.DrawString(yAxis.BottomTitle, this.Font, this.GetBrush(this.ForeColor), titleRect, this.GetStringFromat(yAxis.BottomTitleTextDirection == Orientation.Vertical? ContentAlignment.MiddleRight:ContentAlignment.MiddleCenter, false, yAxis.BottomTitleTextDirection == Orientation.Vertical));
                    }
                }
                splitLine=new RectangleF(ruleRect.Right, ruleRect.Top, 1, ruleRect.Height);
                //绘制右分割线
                if (this.NeedDraw(clipRect, splitLine))
                    g.FillRectangle(this.GetBrush(this.ForeColor), splitLine);

            }
        }
        /// <summary>
        /// 绘制标尺的刻度
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="yAxis"></param>
        private void DrawRuleTick(Graphics g, RectangleF clipRect, YAxisInfo yAxis)
        {
            //显示的刻度数量
            int tickCount = yAxis.YSplitNum +1;
            if (yAxis.HasScales)
            {
                tickCount = yAxis.Scales.Count;
                yAxis.Scales.SortByValue();
                yAxis.Scales.Reverse();
            }
            float gridTopPadding = this.GetGridTopPadding();
            float gridBottomPadding = this.GetGridBottomPadding();
            //刻度总长度
            float tickTotalLength = yAxis.Height - gridBottomPadding - gridTopPadding;
            //上边空白边距
            float topPadding = 0;
            //最大最小之差
            float dValue = yAxis.MaxValue - yAxis.MinValue;
            if (yAxis.IsMarginVisible)
            {
                topPadding = tickTotalLength / (yAxis.YSplitNum + 2);
                tickTotalLength = tickTotalLength - 2 * topPadding;
            }
            topPadding += gridTopPadding;
            //单个刻度的长度
            float tickLength = tickTotalLength / yAxis.YSplitNum;
            //刻度区域
            RectangleF tickRect = new RectangleF(yAxis.Left, yAxis.Top + topPadding, yAxis.Width, this.Font.GetHeight(g));
            for (int i = 0; i < tickCount; i++)
            {
                float value = yAxis.MaxValue - dValue * i / (float)yAxis.YSplitNum;
                string tickText =value.ToString();
                if (yAxis.HasScales)
                {
                    var yAxisScale = yAxis.Scales[i];
                    if (!string.IsNullOrWhiteSpace(yAxisScale.Text))
                        tickText = yAxisScale.Text;
                    else
                        tickText = yAxisScale.Value.ToString();
                    tickRect.Y = yAxis.Top + topPadding + tickTotalLength * (1f - yAxisScale.ScaleRate);
                }
                RectangleF drawRect = new RectangleF(tickRect.Left, tickRect.Top - tickRect.Height / 2, tickRect.Width, tickRect.Height);
                if (this.NeedDraw(clipRect, drawRect))
                {
                    g.DrawString(tickText, this.Font, this.GetBrush(this.ForeColor), drawRect, this.GetStringFromat(ContentAlignment.MiddleCenter));
                }
                tickRect.Y += tickLength;
            }
        }

        /// <summary>
        /// 获取指定轴上指定刻度值对应的Y轴坐标
        /// </summary>
        /// <param name="yAxis"></param>
        /// <param name="tickValue"></param>
        /// <returns></returns>
        internal float GetY(YAxisInfo yAxis,float tickValue)
        {
            float gridTopPadding = this.GetGridTopPadding();
            float gridBottomPadding = this.GetGridBottomPadding();
            //上边空白边距
            float topPadding = 0;
            //刻度总长度
            float tickTotalLength = this._GirdRectangle.Height - gridBottomPadding - gridTopPadding;
            //最大最小之差
            float dValue = yAxis.MaxValue - yAxis.MinValue;
            if (yAxis.IsMarginVisible)
            {
                topPadding = tickTotalLength / (yAxis.YSplitNum + 2);
                tickTotalLength = tickTotalLength - 2 * topPadding;
            }
            topPadding += gridTopPadding;
            if (yAxis.HasScales)
            {
                yAxis.Scales.SortByValue();
                yAxis.Scales.Reverse();
                int index = -1;
                for (int i = 0; i < yAxis.Scales.Count; i++)
                {
                    if (yAxis.Scales[i].Value <= tickValue)
                    {
                        index = i;
                        break;
                    }
                }
                if (index == -1)
                    index = yAxis.Scales.Count - 1;
                if (index == 0 || yAxis.Scales.Count==1)
                {
                    float currentValue =yAxis.Scales[index].Value;
                    float currentRate =yAxis.Scales[index].ScaleRate;
                    float nextValue = 0;
                    float nextScaleRate = 0;

                    if (yAxis.Scales.Count >1)
                    {
                        nextValue = yAxis.Scales[index + 1].Value;
                        nextScaleRate = yAxis.Scales[index + 1].ScaleRate;
                    }
                    float dvalue = currentValue - nextValue;
                    float dscaleRate = currentRate - nextScaleRate;
                    float dlength = tickTotalLength * dscaleRate;

                    return this._GirdRectangle.Top + topPadding + tickTotalLength * (1f - currentRate)
                        - dlength / dvalue * (tickValue - currentValue);
                }
                else
                {
                   
                    float currentValue = yAxis.Scales[index].Value;
                    float currentRate = yAxis.Scales[index].ScaleRate;
                    float preValue = yAxis.Scales[index - 1].Value;
                    float preScaleRate = yAxis.Scales[index - 1].ScaleRate;
                    float dvalue = preValue - currentValue;
                    float dscaleRate = preScaleRate - currentRate;
                    float dlength = tickTotalLength * dscaleRate;

                    return this._GirdRectangle.Top + topPadding + tickTotalLength * (1f - preScaleRate)
                        + dlength / dvalue * (preValue - tickValue);
                }
            }
            else
            {
                return this._GirdRectangle.Top + topPadding + tickTotalLength - (tickValue - yAxis.MinValue) / dValue * tickTotalLength;
            }

        }
        /// <summary>
        /// 通过时间获取x坐标
        /// </summary>
        /// <param name="time"></param>
        /// <param name="startDate">起始日期</param>
        /// <returns></returns>
        private float GetX(DateTime time, DateTime? startDate = null)
        {
            int dayIndex = this.GetDayIndex(time, startDate);
            int tickIndex = this.GetTickIndex(time);
            float dayWidth = this.GetDayWidth();
            float tickWidth = this.GetTickWidth();
            if (!this.IsExactTime)
            {
                return this.GridRectangle.Left
                    + dayIndex * dayWidth
                    + tickIndex * tickWidth + tickWidth / 2f;
            }
            else
            {
                float dHour = (float) time.Subtract(time.Date).TotalHours;
                DateTime date = this.GetDate(time);
                if (time.Date != date)
                    dHour = 24 + dHour - this.Ticks[tickIndex].Value;
                else
                    dHour = dHour - this.Ticks[tickIndex].Value;
                float tickHours = this.GetTickHours(tickIndex);
                return this.GridRectangle.Left+ dayIndex * dayWidth + tickIndex * tickWidth + tickWidth / tickHours * dHour;
            }
        }

        /// <summary>
        /// 通过x轴坐标获取坐标对应的时间
        /// </summary>
        /// <param name="x"></param>
        /// <param name="startDate">起始日期</param>
        /// <returns></returns>
        public DateTime GetTimeByX(float x, DateTime? startDate = null)
        {
            DateTime startTime;
            if (!startDate.HasValue)
                startTime = this.RuntimeStartTime;
            else
                startTime = this.GetMinTime(startDate.Value.Date, true);

            DateTime pageStartDate = startTime.AddDays(this.RuntimePageIndex * this.RuntimeNumOfDaysInOnePage);

            float dLength = x - this._GirdRectangle.Left;
            float dayWidth = this.GetDayWidth();
            float tickWidth = this.GetTickWidth();
            if (dayWidth == 0 || tickWidth == 0)
                return TemperatureDocument.NullDate;

            int days = (int)Math.Floor(dLength / dayWidth);
            int tickCount = (int) Math.Floor((dLength - days * dayWidth) / tickWidth);
            float dTickLength = dLength - tickCount * tickWidth - dayWidth * days;

            float dHour = this.GetTickHours(tickCount);
            DateTime time = pageStartDate.Date.AddDays(days).AddHours(this.Ticks[tickCount].Value + (dHour / tickWidth) * dTickLength);
            return new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, 0);
            //return pageStartDate.Date.AddDays(days).AddHours(this.Ticks[tickCount].Value + (dHour / tickWidth) * dTickLength);
        }
        /// <summary>
        /// 通过Y轴坐标获取坐标对应指定数据标尺的值
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public float GetValueByY(YAxisInfo rule, float y)
        {
            float gridTopPadding = this.GetGridTopPadding();
            float gridBottomPadding = this.GetGridBottomPadding();
            float value = float.NaN;
            float ruleLength = this.GridRectangle.Height - gridTopPadding -gridBottomPadding;
            float padding=0;
            if (rule.IsMarginVisible)
            {
                 padding=ruleLength / (rule.YSplitNum + 2);
                 ruleLength = ruleLength - 2 * padding;
            }
            padding += gridTopPadding;
            if (!rule.HasScales)
            {
                float dValue = rule.MaxValue - rule.MinValue;
                float maxValueY = this.GridRectangle.Top + padding;
                if (maxValueY < y)
                {
                    value= rule.MaxValue - dValue / ruleLength * (y - maxValueY);
                }
                else
                {
                    value= dValue / ruleLength * (maxValueY - y) + rule.MaxValue;
                }
            }
            else 
            {
                rule.Scales.SortByValue();
                rule.Scales.Reverse();

                float maxValueY = ruleLength * (1f - rule.Scales[0].ScaleRate) + padding + this.GridRectangle.Top;
                float minValueY = ruleLength * (1f - rule.Scales.Last().ScaleRate) + padding + this.GridRectangle.Top;

                if (y < maxValueY)
                {
                    float dValue = rule.Scales[0].Value;
                    float dLength = ruleLength;
                    if (rule.Scales.Count > 1)
                    {
                        dValue = rule.Scales[0].Value - rule.Scales[1].Value;
                        dLength = (rule.Scales[0].ScaleRate - rule.Scales[1].ScaleRate) * ruleLength;
                    }
                    value= rule.Scales[0].Value + dValue / dLength * (maxValueY - y);
                }
                else if (y >= maxValueY && y <= minValueY)
                {
                    for (int i = 0; i < rule.Scales.Count; i++)
                    {
                        float currentY = ruleLength * (1f - rule.Scales[i].ScaleRate) + padding + this.GridRectangle.Top;
                        if (y <= currentY)
                        {
                            if (y == currentY)
                                value = rule.Scales[i].Value;
                            else
                            {
                                float dValue = rule.Scales[i].Value - rule.Scales[i - 1].Value;
                                float dLength = (rule.Scales[i - 1].ScaleRate - rule.Scales[i].ScaleRate) * ruleLength;
                                value = rule.Scales[i].Value - dValue / dLength * (currentY-y);
                            }
                        }
                    }
                }
                else
                {
                    float dValue = rule.Scales.Last().Value;
                    float dLength = rule.Scales.Last().ScaleRate * ruleLength;
                    if (rule.Scales.Count > 1)
                    {
                        dValue = rule.Scales[rule.Scales.Count - 2].Value - rule.Scales.Last().Value;
                        dLength = (rule.Scales[rule.Scales.Count - 2].ScaleRate - rule.Scales.Last().ScaleRate) * ruleLength;
                    }
                    value = rule.Scales.Last().Value - dValue / dLength * (y-minValueY);
                }
            }

            return (float)Math.Round(value, rule.Ditgits) ;
        }
        /// <summary>
        /// 获取指定时间所在的日期索引
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="startDate">开始日期</param>
        /// <returns></returns>
        private int GetDayIndex(DateTime time, DateTime? startDate=null)
        {
            DateTime startTime;
            if (startDate == null)
                startTime = this.RuntimeStartTime;
            else
                startTime = this.GetMinTime(startDate.Value,true);
            DateTime pageStartDate = startTime.AddDays(this.RuntimeNumOfDaysInOnePage * this.RuntimePageIndex);
            TimeSpan dTimeSpan = time.Subtract(pageStartDate);
            return (int)Math.Floor(dTimeSpan.TotalDays);
        }
        /// <summary>
        /// 获取刻度的宽度
        /// </summary>
        /// <returns></returns>
        private float GetTickWidth()
        {
            float tickWidth = 0f;
            if (this.ViewMode .HasFlag( DocumentViewMode.Widely))
            {
                return GraphicsHelper.Convert(22, GraphicsUnit.Pixel, this._PageUnit);
            }
            else
            {
                tickWidth = this._GirdRectangle.Width / this.RuntimeNumOfDaysInOnePage / this.Ticks.Count;
            }
            return tickWidth;
        }
        /// <summary>
        /// 获取天数格子的宽度
        /// </summary>
        /// <returns></returns>
        private float GetDayWidth()
        {
            if (this.ViewMode .HasFlag( DocumentViewMode.Widely))
            {
                return this.GetTickWidth() * this.Ticks.Count;
            }
            else
            {
                return this._GirdRectangle.Width / this.RuntimeNumOfDaysInOnePage;
            }
        }
        /// <summary>
        /// 获取结束日期
        /// </summary>
        /// <returns></returns>
        private DateTime? GetSpecityEndDate()
        {
            DateTime? specifyEndDate = this.SpecifyEndDate;
            if (!string.IsNullOrEmpty(EndDateKeyword))
            {
                foreach (var item in this.YAxisInfos.Where(y => y.TextFlagMode))
                {
                    foreach (var valuePoint in item.Values)
                    {
                        if (!string.IsNullOrEmpty(valuePoint.Text) && this.ExistsKey(valuePoint.Text, this.EndDateKeyword))
                        {
                            if (!specifyEndDate.HasValue || specifyEndDate.Value > this.GetDate(valuePoint.Time))
                            {
                                specifyEndDate = this.GetDate(valuePoint.Time);
                            }
                        }
                    }
                }
            }
            return specifyEndDate;
        }
        private float GetGridTopPadding()
        {
            float cellHeight = this.GridRectangle.Height / (this.IntervalCount * this.GridVerticalSplitNum + this.GridBottomPadding + this.GridTopPadding);
            return this.GridTopPadding * cellHeight;
        }
        private float GetGridBottomPadding()
        {
            float cellHeight = this.GridRectangle.Height / (this.IntervalCount * this.GridVerticalSplitNum + this.GridBottomPadding + this.GridTopPadding);
            return this.GridBottomPadding * cellHeight;
        }
       /// <summary>
       /// 绘制网格
       /// </summary>
       /// <param name="g"></param>
       /// <param name="clipRect"></param>
       /// <param name="gridRect">网格边界</param>
        private void DrawGrid(Graphics g,RectangleF clipRect,RectangleF gridRect)
        {
            if (this.NeedDraw(clipRect, gridRect))
            {
                //float splitLength = gridRect.Height / this.GridVerticalSplitNum;
                //float cellHeight = splitLength / this.IntervalCount;
                float cellHeight = gridRect.Height / (this.IntervalCount * this.GridVerticalSplitNum + this.GridBottomPadding + this.GridTopPadding);
                float splitLength = (gridRect.Height - (cellHeight * (this.GridTopPadding + this.GridBottomPadding))) / this.GridVerticalSplitNum;

                float topPadding = this.GridTopPadding * cellHeight;
                float drawPosition = topPadding + gridRect.Top;
                //绘制上边距内的行
                for (float i = drawPosition; i > gridRect.Top; i-=cellHeight)
                {
                    if (drawPosition < gridRect.Bottom)
                    {
                        RectangleF line = new RectangleF(gridRect.Left, i, gridRect.Width, 1);
                        if (this.NeedDraw(clipRect, line))
                        {
                            g.FillRectangle(this.GetBrush(this.GridLineColor), line);
                        }
                    }
                }
                drawPosition = topPadding + gridRect.Top;

                //float cellTop = gridRect.Top + cellHeight;
                float cellTop = drawPosition + cellHeight;
                float cellCount =this.IntervalCount * this.GridVerticalSplitNum - 1;
                for (int i = 0; i < cellCount; i++)
                {
                    RectangleF lineRect =  new RectangleF(gridRect.Left, cellTop, gridRect.Width, 1);
                    if (this.NeedDraw(clipRect, lineRect))
                    {
                        //绘制单元格横线
                        g.FillRectangle(this.GetBrush(this.GridLineColor), lineRect);
                    }
                    cellTop += cellHeight;
                }

                cellCount = this.Ticks.Count * this.RuntimeNumOfDaysInOnePage ;
                float cellWidth = gridRect.Width / cellCount;
                float cellLeft = gridRect.Left + cellWidth;
                for (int i = 0; i < cellCount -1; i++)
                {
                    RectangleF lineRect = new RectangleF(cellLeft, gridRect.Top, 1, gridRect.Height);
                    if (this.NeedDraw(clipRect, lineRect))
                    {
                        if (this.GridHorizontalSplitInterval > 0 && this.GridHorizontalSplitLineColor.A != 0
                            && (i + 1) % this.GridHorizontalSplitInterval == 0)
                        {
                            g.FillRectangle(this.GetBrush(this.GridHorizontalSplitLineColor), lineRect);
                        }
                        else
                        {
                            //绘制单元格竖线
                            g.FillRectangle(this.GetBrush(this.GridLineColor), lineRect);
                        }
                    }
                    cellLeft += cellWidth;
                }


                //float splitTop = gridRect.Top + splitLength;
                float splitTop = drawPosition + (this.DrawGridVerticalSplitLineStart?0:splitLength);
                int gridVertical = this.GridVerticalSplitNum - (this.DrawGridVerticalSplitLineEnd?0:1);
                for (int i = 0; i <= gridVertical; i++)
                {
                    RectangleF lineRect = new RectangleF(gridRect.Left, splitTop, gridRect.Width, this.GetSpecifySizeByPixelUnit(g, this.GridVerticalSplitLineWidth));
                    if (this.NeedDraw(clipRect, lineRect))
                    {
                        //绘制大横线
                        g.FillRectangle(this.GetBrush(this.GridVerticalSplitLineColor), lineRect);
                    }
                    splitTop += splitLength;
                }

                //绘制下边距行
                drawPosition = gridRect.Height - this.GridBottomPadding * cellHeight + gridRect.Top;
                for (float i = drawPosition; i < gridRect.Bottom; i+=cellHeight)
                {
                    if (drawPosition > gridRect.Top)
                    {
                        RectangleF line = new RectangleF(gridRect.Left, i, gridRect.Width, 1);
                        if (this.NeedDraw(clipRect, line))
                        {
                            g.FillRectangle(this.GetBrush(this.GridLineColor), line);
                        }
                    }
                }

                RectangleF topLine =new RectangleF(gridRect.Left, gridRect.Top, gridRect.Width, 1);
                //绘制上边框线
                if(this.NeedDraw(clipRect,topLine))
                    g.FillRectangle(this.GetBrush(this.ForeColor), topLine);
            }
        }

        #endregion

        #region 绘制体温单内容...

        /// <summary>
        /// 获取数据行每日的数据边界
        /// </summary>
        /// <param name="titleLine">数据行</param>
        /// <param name="startDate">起始日期</param>
        /// <param name="date">指定日期</param>
        /// <returns></returns>
        private RectangleF GetTitleLineDayBound(TitleLine titleLine,DateTime startDate, DateTime date)
        {
            int dayIndex=this.GetDayIndex(this.GetMinTime(date, true),(DateTime?) startDate);
            return this.GetTitleLineDayBound(titleLine, dayIndex);
        }
        /// <summary>
        /// 获取数据行每日的数据边界
        /// </summary>
        /// <param name="titleLine">数据行</param>
        /// <param name="startDate">天数的索引</param>
        /// <returns></returns>
        private RectangleF GetTitleLineDayBound(TitleLine titleLine, int dayIndex)
        {
            if (dayIndex < 0)
                return RectangleF.Empty;
            float width =this.GetDayWidth();
            return new RectangleF(this.GridRectangle.Left + dayIndex*width, titleLine.Top
                ,width
                ,titleLine.Height);
        }
        /// <summary>
        /// 获取符合数据关键开始时间数据
        /// KEY 关键字开始时间 VALUE 第几次关键字开始时间 
        /// 次数重1开始
        /// </summary>
        /// <param name="titleLine">数据行</param>
        /// <returns></returns>
        private Dictionary<DateTime, int> GetKeyDates(TitleLine titleLine)
        {
            //判断数据行的开始时间关键字是否为空
            if (string.IsNullOrEmpty(titleLine.StartDateKeyword))
                return null;
            //获取包含开始时间关键字的时间 按升序排序
            List<DateTime> keyDates = new List<DateTime>();
            var query = this.YAxisInfos.Where(y => y.TextFlagMode && y.Values.Exists(v => this.ExistsKey(v.Text, titleLine.StartDateKeyword)));
            foreach (var yAxis in query)
            {
                keyDates.AddRange(yAxis.Values.Where(v=>this.ExistsKey(v.Text,titleLine.StartDateKeyword)).Select(v=>this.GetDate(v.Time)).Distinct());
            }
            keyDates = keyDates.Distinct().ToList();
            keyDates.Sort();
            //key 关键字开始时间 value 第几次关键字时间  必须在前一个关键时间还未结束之前才会累加1
            Dictionary<DateTime, int> keyDateDict = new Dictionary<DateTime, int>();
            for (int i = 0; i < keyDates.Count; i++)
            {
                //判断是否为累计模式
                if (titleLine.AddUpMode)
                {
                    keyDateDict.Add(keyDates[i].Date, i + 1);
                    continue;
                }
                if (i == 0)
                {
                    keyDateDict.Add(keyDates[i].Date, 1);
                }
                else
                {
                    if (keyDates[i].Date.Subtract(keyDates[i - 1].Date).Days <= titleLine.AllowKeyDateDays)
                        keyDateDict.Add(keyDates[i].Date, keyDateDict[keyDates[i - 1].Date] + 1);
                    else
                        keyDateDict.Add(keyDates[i], 1);
                }
            }
            return keyDateDict;
        }
        /// <summary>
        /// 获取dayindex类型的标题行指定日期的显示文本
        /// </summary>
        /// <param name="titleLine"></param>
        /// <param name="keyDates"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        private string GetDayIndexText(TitleLine titleLine, Dictionary<DateTime, int> keyDates, DateTime date)
        {
            if (keyDates == null || keyDates.Count == 0)
                return string.Empty;
            bool exists = false;
            foreach (var item in keyDates)
            {
                if (date.Date >= item.Key && date.Date <= item.Key.AddDays(titleLine.AllowKeyDateDays))
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
                return string.Empty;
            string text = string.Empty;
            DateTime startKey = keyDates.Where(k => k.Key <= date.Date).Max(k => k.Key);
            if (keyDates.ContainsKey(date.Date))
            {
                if (!string.IsNullOrEmpty(titleLine.KeyDateString))
                {
                    var keyStrings = titleLine.KeyDateString.Split(',');
                    if (keyStrings != null && keyStrings.Length >= keyDates[date.Date])
                    {
                        text = keyStrings[keyDates[date.Date] - 1];
                    }
                }
            }
            else
            {
                text = date.Date.Subtract(startKey).Days.ToString();
            }
            if (titleLine.CountType != TitleLineCountType.Reset)
            {
                int count = keyDates[startKey];

                for (int i = count; i > 1; i--)
                {
                    startKey = keyDates.Where(k => k.Key < startKey).Max(k=>k.Key);
                    int days = date.Date.Subtract(startKey).Days;
                    if (days > titleLine.AllowKeyDateDays)
                        continue;
                    if (string.IsNullOrEmpty(text))
                        text = days.ToString();
                    else
                        if (titleLine.CountType == TitleLineCountType.PreIsDenominator)
                        {
                            text += "/" + days;
                        }
                        else
                            text = days + "/" + text;
                }
            }

            return text;
        }

        /// <summary>
        /// 获取数据行的内容区前景色
        /// </summary>
        /// <param name="titleLine"></param>
        /// <returns></returns>
        private Color GetTitleLineContentForeColor(TitleLine titleLine)
        {
            Color foreColor = this.ForeColor;
            if (!titleLine.TextColor.IsEmpty)
                foreColor = titleLine.TextColor;
            return foreColor;
        }

        /// <summary>
        /// 绘制数据行中的内容 日期
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="titleLine">数据行</param>
        /// <param name="startDate">起始日期</param>
        private void DrawTitleLineContentBySerialDate(Graphics g, RectangleF clipRect, TitleLine titleLine, DateTime startDate)
        {
            if (titleLine.ValueType != TitleLineValueType.SerialDate)
                return;
            //默认为当前页的起始日期
            DateTime date = startDate.Date.AddDays(this.RuntimeNumOfDaysInOnePage*this.RuntimePageIndex);
            DateTime? specifyEndDate = this.GetSpecityEndDate();

            int dayCount = this.RuntimeNumOfDaysInOnePage;
            for (int i = 0; i < dayCount; i++)
            {
                //超过了指定结束日期就不需要在绘制日期
                if (specifyEndDate.HasValue && date > specifyEndDate.Value.Date)
                    break;
                RectangleF textRect = this.GetTitleLineDayBound(titleLine,startDate, date);
                if (this.NeedDraw(clipRect, textRect))
                {
                    string text = "";
                    //满足每页第一天必须是年月日 或跨年也必须是年月日
                    if (i == 0 || date.Year != date.AddDays(-1).Year)
                    {
                        text = date.ToString(this.DateFormatString);
                    }
                    else
                    {
                        //如果跨月必须是月日
                        if (date.Month != date.AddDays(-1).Month)
                        {
                            text = date.ToString("MM-dd");
                        }
                        else
                        {
                            //否则只显示天数
                            text = date.Day.ToString();
                        }
                    }
                    g.DrawString(text, this.Font, this.GetBrush(this.GetTitleLineContentForeColor(titleLine)), textRect, this.GetStringFromat(ContentAlignment.MiddleCenter));
                }
                date = date.AddDays(1);
            }
        }
        /// <summary>
        /// 绘制数据行中内容 天数
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="titleLine"></param>
        /// <param name="startDate"></param>
        private void DrawTitleLineContentByInDayIndex(Graphics g, RectangleF clipRect, TitleLine titleLine, DateTime startDate)
        {
            if (titleLine.ValueType != TitleLineValueType.InDayIndex)
                return;
            //默认为当前页的起始日期
            DateTime date = startDate.Date.AddDays(this.RuntimePageIndex*this.RuntimeNumOfDaysInOnePage);
            DateTime? specifyEndDate = this.GetSpecityEndDate();
            int dayCount = this.RuntimeNumOfDaysInOnePage;
            for (int i = 0; i < dayCount; i++)
            {
                //超过了指定结束日期就不需要在绘制住院天数
                if (specifyEndDate.HasValue && date > specifyEndDate.Value.Date)
                    break;
                RectangleF textRect = this.GetTitleLineDayBound(titleLine, startDate, date);
                if (this.NeedDraw(clipRect, textRect))
                {
                    string text = (date.Subtract(startDate).Days + 1).ToString();
                    g.DrawString(text, this.Font, this.GetBrush(this.GetTitleLineContentForeColor(titleLine)), textRect, this.GetStringFromat(ContentAlignment.MiddleCenter));
                }
                date = date.AddDays(1);
            }
        }
        /// <summary>
        /// 绘制数据行中内容 关键字后天数
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="titleLine"></param>
        /// <param name="startDate"></param>
        private void DrawTitleLineContentByDayIndex(Graphics g, RectangleF clipRect, TitleLine titleLine,DateTime startDate)
        {
            if (string.IsNullOrWhiteSpace(titleLine.StartDateKeyword))
                return;
            if (!this.YAxisInfos.Exists(y => y.TextFlagMode && y.Values.Exists(v =>this.ExistsKey(v.Text,titleLine.StartDateKeyword))))
                return;
            var keyDates = this.GetKeyDates(titleLine);
            DateTime? specifyEndDate = this.GetSpecityEndDate();
            DateTime date =startDate.AddDays(this.RuntimeNumOfDaysInOnePage*this.RuntimePageIndex);
            for (int i = 0; i < this.RuntimeNumOfDaysInOnePage; i++)
            {
                //超过了指定结束日期就不需要在绘制日期
                if (specifyEndDate.HasValue && date > specifyEndDate.Value.Date)
                    break;
                RectangleF textRect = this.GetTitleLineDayBound(titleLine, startDate, date);
                if (this.NeedDraw(clipRect, textRect))
                {
                    string text =this.GetDayIndexText(titleLine,keyDates,date);
                    if (!string.IsNullOrWhiteSpace(text))
                        g.DrawString(text, this.Font, this.GetBrush(this.GetTitleLineContentForeColor(titleLine)), textRect, this.GetStringFromat(ContentAlignment.MiddleCenter));
                }
                date = date.AddDays(1);
            }
        }
        /// <summary>
        /// 绘制数据行中内容 时刻
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="titleLine"></param>
        private void DrawTitleLineContentByHourTick(Graphics g, RectangleF clipRect, TitleLine titleLine)
        {
            RectangleF dayRect = this.GetTitleLineDayBound(titleLine, 0);
            float width = this.GetTickWidth();
            Font tickFont =(Font) this.Font.Clone();
            float fontWidth = g.MeasureString("12", this.Font).Width;
            if (width < fontWidth)
            {
                tickFont = new Font(this.Font.Name, this.Font.Size * 0.8f);
                fontWidth = g.MeasureString("12", tickFont).Width;
            }
            for (int i = 0; i < this.RuntimeNumOfDaysInOnePage; i++)
            {
                dayRect = this.GetTitleLineDayBound(titleLine, i);
                
                if (this.NeedDraw(clipRect, dayRect))
                {
                    RectangleF drawRect = new RectangleF(dayRect.Left, dayRect.Top, fontWidth, dayRect.Height);
                    foreach (var tick in this.Ticks)
                    {
                        if (this.NeedDraw(clipRect, drawRect))
                        {
                            g.DrawString(tick.Text, tickFont, this.GetBrush(tick.ForeColor), drawRect, this.GetStringFromat(ContentAlignment.MiddleCenter, false));
                            if (tick != this.Ticks.Last())
                                g.FillRectangle(this.GetBrush(this.ForeColor), new RectangleF(drawRect.X + width, drawRect.Top, 1, drawRect.Height));
                        }
                        drawRect.X += width;
                    }
                }
            }
            tickFont.Dispose();
        }
        /// <summary>
        /// 绘制数据中内容 文本
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="titleLine"></param>
        private void DrawTitleLineContentByText(Graphics g, RectangleF clipRect, TitleLine titleLine, DateTime startDate)
        {
            DateTime pageStartDate = startDate.Date.AddDays(this.RuntimeNumOfDaysInOnePage * this.RuntimePageIndex);
            float tickWidth = this.GetTickWidth();
            float left = titleLine.Left + titleLine.TitleWidth; 
            //绘制分割线
            if (titleLine.TickStep != this.Ticks.Count)
            {
                float splitLineX = left;
                for (int i = 0; i < this.RuntimeNumOfDaysInOnePage * this.Ticks.Count; i += titleLine.TickStep)
                {
                    if (i % this.Ticks.Count != 0)
                    {
                        RectangleF splitLine = new RectangleF(left + i * tickWidth, titleLine.Top, 1, titleLine.Height);
                        if (this.NeedDraw(clipRect, splitLine))
                        {
                           
                            g.FillRectangle(this.GetBrush(this.ForeColor), splitLine);
                        }
                    }
                }
            }
            //绘制文本
            Brush foreBrush = this.GetBrush(this.GetTitleLineContentForeColor(titleLine));

            int tickCount = 0; //记录已经绘制的刻度数
            DateTime currentDate = pageStartDate; //记录当前绘制的日期
            ContentAlignment align = ContentAlignment.MiddleCenter;//控制文本的对齐方式
            while (tickCount < this.RuntimeNumOfDaysInOnePage * this.Ticks.Count)
            {
                int day = tickCount / this.Ticks.Count;//记录已经绘制了几天
                int tickIndex = tickCount % this.Ticks.Count;
                //获取当前绘制区域中允许的最小时间与最大时间
                DateTime minDate = pageStartDate.AddDays(day).AddHours(this.Ticks[tickIndex].Value);
                day = (tickCount + titleLine.TickStep) / this.Ticks.Count;
                tickIndex = (tickCount + titleLine.TickStep) % this.Ticks.Count;
                DateTime maxDate = pageStartDate.AddDays(day).AddHours(this.Ticks[tickIndex].Value);
                day = tickCount / this.Ticks.Count;//记录已经绘制了几天
                //获取当前绘制区域的值对象
                var valuePoint = titleLine.Values.Find(v => v.Time >= minDate && v.Time < maxDate && !string.IsNullOrEmpty(v.Text));
                //判断当前数据行的上下交替类型是否为UpDown DayUpDown
                //是否则交替变更文本的对其方式
                if (titleLine.UpDownType == TitleLineUpDownType.UpDown
                    || titleLine.UpDownType == TitleLineUpDownType.DayUpDown)
                {
                    if (align == ContentAlignment.MiddleCenter)
                        align = ContentAlignment.TopCenter;
                    else
                        if (align == ContentAlignment.TopCenter)
                            align = ContentAlignment.BottomCenter;
                        else
                            align = ContentAlignment.TopCenter;
                }
                //判断当前绘制区域是否日期已改变
                if (currentDate.Date != pageStartDate.AddDays(day).Date)
                {
                    currentDate = pageStartDate.AddDays(day);
                    //如果当前数据行的交替类型为DayUpDown 
                    //则每变更日期 将重置 文本的对齐方式
                    if (titleLine.UpDownType == TitleLineUpDownType.DayUpDown)
                        align = ContentAlignment.TopCenter;
                }
                if (valuePoint != null && !string.IsNullOrWhiteSpace(valuePoint.Text))
                {
                    //获取当前绘制的区域
                    RectangleF tickRect = new RectangleF(left + tickCount * tickWidth, titleLine.Top, tickWidth * titleLine.TickStep, titleLine.Height);

                    //如果当前数据行的上下交替类型累空
                    //则使对齐方式为居中
                    if (titleLine.UpDownType == TitleLineUpDownType.None)
                    {
                        align = ContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        //如果当前数据行的上下交替类型为GolbalUpDown
                        //则变更上下交替类型
                        if (titleLine.UpDownType == TitleLineUpDownType.GolbalUpDown 
                            || titleLine.UpDownType== TitleLineUpDownType.GolbalDayUpDown)
                        {
                            if (align == ContentAlignment.MiddleCenter)
                                align = ContentAlignment.TopCenter;
                            else
                                if (align == ContentAlignment.TopCenter)
                                    align = ContentAlignment.BottomCenter;
                                else
                                    align = ContentAlignment.TopCenter;
                            //设置当天第一次录入必须为上
                            if (titleLine.UpDownType == TitleLineUpDownType.GolbalDayUpDown)
                            {
                                DateTime date = this.GetDate(valuePoint.Time);
                                int minTickIndex = titleLine.Values.Where(v => this.GetDate(v.Time) == date).Min(v1 => this.GetTickIndex(v1.Time));
                                if (this.GetTickIndex(valuePoint.Time) == minTickIndex)
                                    align = ContentAlignment.TopCenter;
                            }
                        }
                    }
                    Brush textBrush = (Brush)foreBrush.Clone();
                    if (this.ExistsKey(valuePoint.Text, titleLine.WarnKeyWords))
                        textBrush = new SolidBrush(Color.Red);
                    //如果当前文本为指定的圆圈文本则绘制圆圈文本
                    if (this.ExistsKey(valuePoint.Text, titleLine.CircleText, true))
                    {
                        this.DrawCricleText(g, clipRect, valuePoint.Text, tickRect, textBrush, align);
                    }
                    else
                    {
                        this.DrawTextEx(g, clipRect, valuePoint.Text, tickRect, textBrush, align,titleLine.SizeToFit);
                    }
                    textBrush.Dispose();
                }
                tickCount += titleLine.TickStep;

            }


        }
        /// <summary>
        /// 绘制内容 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="titleLine"></param>
        private void DrawTitleLineContentByNone(Graphics g, RectangleF clipRect, TitleLine titleLine, DateTime startDate)
        {
            int runtimeNumOfDaysInOnePage = this.RuntimeNumOfDaysInOnePage;
            DateTime pageStartDate = startDate.Date.AddDays(runtimeNumOfDaysInOnePage * this.RuntimePageIndex);
            float tickWidth = this.GetTickWidth();
            float left = titleLine.Left + titleLine.TitleWidth;
            Color[] loopForeColors = titleLine.LoopForeColors;
            Color[] loopbackColors = titleLine.LoopBackgroundColors;
            string[] loopTexts = titleLine.LoopText;
            bool needDrawBackColor = loopbackColors != null && loopbackColors.Length > 0;
            bool needDrawText = loopTexts != null && loopTexts.Length > 0;

            for (int i = 0; i < this.RuntimeNumOfDaysInOnePage * this.Ticks.Count; i += titleLine.TickStep)
            {
                //填充背景色 所有的缩小1 防止覆盖边框线
                RectangleF backRect = new RectangleF(left + i * tickWidth +1, titleLine.Top + 1, titleLine.TickStep * tickWidth -1, titleLine.Height -1);
                //防止覆盖外围边框
                if (backRect.Right > titleLine.Right - this.BorderSize)
                    backRect.Width -= (backRect.Right - this.BorderSize);
                if (needDrawBackColor && this.NeedDraw(clipRect, backRect))
                {
                    g.FillRectangle(this.GetBrush(loopbackColors[(i / titleLine.TickStep) % loopbackColors.Length]), backRect);
                }
                //绘制分割线
                if (i % this.Ticks.Count != 0)
                {
                    RectangleF splitLine = new RectangleF(left + i * tickWidth, titleLine.Top, 1, titleLine.Height);
                    if (this.NeedDraw(clipRect, splitLine))
                    {

                        g.FillRectangle(this.GetBrush(this.ForeColor), splitLine);
                    }
                }
                //绘制文本
                if (needDrawText && this.NeedDraw(clipRect, backRect))
                {
                    Brush foreBrush ;
                    if (loopForeColors != null && loopForeColors.Length > 0)
                        foreBrush = this.GetBrush(loopForeColors[(i / titleLine.TickStep) % loopForeColors.Length]);
                    else
                        foreBrush = this.GetBrush(this.ForeColor);
                    this.DrawTextEx(g, clipRect, loopTexts[(i / titleLine.TickStep) % loopTexts.Length], backRect, foreBrush, ContentAlignment.MiddleCenter,false);
                }
            }

        }
        /// <summary>
        /// 绘制圆圈文本
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="text"></param>
        /// <param name="bound"></param>
        /// <param name="foreColor"></param>
        /// <param name="align"></param>
        private void DrawCricleText(Graphics g, RectangleF clipRect, string text, RectangleF bound, Brush foreBrush, ContentAlignment align)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;
            if (!this.NeedDraw(clipRect, bound))
                return;
            SizeF textSize = g.MeasureString(text, this.Font);
            float circleWidth = Math.Max(textSize.Width, textSize.Height);

            if (align == ContentAlignment.BottomCenter || align == ContentAlignment.TopCenter || align == ContentAlignment.MiddleCenter)
            {
                if (textSize.Width > bound.Width)
                {
                    bound.Width = textSize.Width;
                    bound.X -= (textSize.Width - bound.Width) / 2f;
                }
            }
            if (align == ContentAlignment.MiddleLeft || align == ContentAlignment.MiddleRight || align == ContentAlignment.MiddleCenter)
            {
                if (textSize.Height > bound.Height)
                {
                    bound.Height = textSize.Height;
                    bound.Y -= (textSize.Height - bound.Height) / 2f;
                }
            }


            g.DrawString(text, this.Font, foreBrush, bound, this.GetStringFromat(align));
            PointF circlePoint = bound.Location;
            switch (align)
            {
                case ContentAlignment.BottomCenter:
                    circlePoint = new PointF(bound.X - (circleWidth - bound.Width) / 2f, bound.Bottom - circleWidth);
                    break;
                case ContentAlignment.BottomLeft:
                    circlePoint = new PointF(bound.X, bound.Bottom - circleWidth);
                    break;
                case ContentAlignment.BottomRight:
                    circlePoint = new PointF(bound.Right - bound.Width, bound.Bottom - circleWidth);
                    break;
                case ContentAlignment.MiddleCenter:
                    circlePoint = new PointF(bound.X - (circleWidth - bound.Width) / 2f, bound.Y - (circleWidth - bound.Height) / 2f);
                    break;
                case ContentAlignment.MiddleLeft:
                    circlePoint = new PointF(bound.X, bound.Y - (circleWidth - bound.Height) / 2f);
                    break;
                case ContentAlignment.MiddleRight:
                    circlePoint = new PointF(bound.Right - bound.Width, bound.Y - (circleWidth - bound.Height) / 2f);
                    break;
                case ContentAlignment.TopCenter:
                    circlePoint = new PointF(bound.X - (circleWidth - bound.Width) / 2f, bound.Y);
                    break;
                case ContentAlignment.TopRight:
                    circlePoint = new PointF(bound.Right, bound.Y);
                    break;
                case ContentAlignment.TopLeft:
                default:
                    circlePoint = bound.Location;
                    break;
            }
            var smoothMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawEllipse(new Pen(foreBrush), circlePoint.X, circlePoint.Y, circleWidth, circleWidth);
            g.SmoothingMode = smoothMode;
        }
        /// <summary>
        /// 绘制文本
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="text"></param>
        /// <param name="bound"></param>
        /// <param name="foreColor"></param>
        /// <param name="align"></param>
        /// <param name="sizeToFit"></param>
        private void DrawTextEx(Graphics g, RectangleF clipRect, string text, RectangleF bound, Brush foreBrush, ContentAlignment align,bool sizeToFit)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;
            if (!this.NeedDraw(clipRect, bound))
                return;
            SizeF limitSize =bound.Size;
            if (!sizeToFit)
            {
                SizeF textSize = g.MeasureString(text, this.Font);
                if (align == ContentAlignment.BottomCenter || align == ContentAlignment.TopCenter || align == ContentAlignment.MiddleCenter)
                {
                    if (textSize.Width > bound.Width)
                    {
                        bound.Width = textSize.Width;
                        bound.X -= (textSize.Width - bound.Width) / 2f;
                    }
                }
                if (align == ContentAlignment.MiddleLeft || align == ContentAlignment.MiddleRight || align == ContentAlignment.MiddleCenter)
                {
                    if (textSize.Height > bound.Height)
                    {
                        bound.Height = textSize.Height;
                        bound.Y -= (textSize.Height - bound.Height) / 2f;
                    }
                }
            }
            var textRenderingHint = g.TextRenderingHint;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.DrawString(text
                , sizeToFit?GraphicsHelper.GetBestFont(g,this.Font,text,limitSize,false): this.Font
                , foreBrush, bound, this.GetStringFromat(align));
            g.TextRenderingHint = textRenderingHint;
        }

        private void DrawTitleLinesContent(Graphics g, RectangleF clipRect, TitleLineList titleLines)
        {
            DateTime startDate =this.GetDate(this.RuntimeStartTime);
            foreach (var titleLine in titleLines)
            {
                switch (titleLine.ValueType)
                {
                    case TitleLineValueType.SerialDate:
                        this.DrawTitleLineContentBySerialDate(g, clipRect, titleLine, startDate);
                        break;
                    case TitleLineValueType.InDayIndex:
                        this.DrawTitleLineContentByInDayIndex(g, clipRect, titleLine, startDate);
                        break;
                    case TitleLineValueType.DayIndex:
                        DrawTitleLineContentByDayIndex(g, clipRect, titleLine, startDate);
                        break;
                    case TitleLineValueType.HourTick:
                        this.DrawTitleLineContentByHourTick(g, clipRect, titleLine);
                        break;
                    case TitleLineValueType.Text:
                        this.DrawTitleLineContentByText(g, clipRect, titleLine,startDate);                        
                        break;
                    case TitleLineValueType.Data:
                        break;
                    case TitleLineValueType.None:
                        this.DrawTitleLineContentByNone(g, clipRect, titleLine, startDate);
                        break;
                    default:
                        break;
                }
                   
            }
        }

        private Token GetToken(ValuePoint vp)
        {
            if (vp == null)
                return null;
            if (string.IsNullOrWhiteSpace(vp.Token))
                return null;
            var token = this.Tokens.GetItemByName(vp.Token);
            return token;
        }

        private void DrawYAxisesContent(Graphics g, RectangleF clipRect)
        {
            DateTime startDate = this.RuntimeStartTime;
            DateTime minDate = startDate.AddDays(this.RuntimePageIndex * this.RuntimeNumOfDaysInOnePage);
            DateTime maxDate = minDate.AddDays(this.RuntimeNumOfDaysInOnePage);
            startDate = this.GetDate(startDate);
            //绘制值类型的数据点
            foreach (var rule in this.Rules.Where(r=>r.ValueVisible))
            {
                List<PointF?> points = new List<PointF?>();
                List<Tuple<float, float, float>> shadowPoints = new List<Tuple<float, float, float>>();
                foreach (var valuePoint in rule.Values.Where(v =>v.Time >= minDate && v.Time < maxDate).OrderBy(v=>v.Time))
                {
                    if (TemperatureDocument.IsNaN(valuePoint.Value))
                        continue;
                    PointF symbolPoint = this.GetValuePoint(g, rule, valuePoint.Time,valuePoint.Value, startDate);
                    float symbolSize = this.GetSpecifySizeByDocumentUnit(g,rule.SymbolSize);
                    this.DrawSymbol(g, clipRect, symbolPoint.X, symbolPoint.Y, rule.SymbolStyle, rule.SymbolColor, symbolSize, rule.SymbolText, this.Font, rule.SymbolImage, this.GetToken(valuePoint));
                    points.Add(symbolPoint);
                    //添加断点数据
                    if (rule.AllowCutOff && valuePoint.CutOff)
                        points.Add(null);
                    //设置点的边界范围
                    valuePoint.SetBoundCore(symbolPoint.X - symbolSize / 2, symbolPoint.Y - symbolSize / 2, symbolSize, symbolSize);

                    int symbolPointDayIndex = this.GetDayIndex(valuePoint.Time, startDate);
                    int symbolPointTickIndex = this.GetTickIndex(valuePoint.Time);
                    #region 绘制灯笼数据点...

                    //判断是否存在有效的灯笼数据
                    if (!string.IsNullOrWhiteSpace(rule.LanternValueFieldName)
                        && rule.EnableLanternValue
                        //&& valuePoint.LanternValue!=valuePoint.Value
                        && this.YAxisInfos.Exists(y => y.ValueFieldName == rule.LanternValueFieldName))
                    {
                        var lanternYAxis = this.YAxisInfos.Find(y => y.ValueFieldName == rule.LanternValueFieldName);



                        var lanternValuePoint = lanternYAxis.Values.Find(v => this.GetDayIndex(v.Time, startDate) == symbolPointDayIndex && this.GetTickIndex(v.Time) == symbolPointTickIndex && !TemperatureDocument.IsNaN(v.Value));
                        if (lanternValuePoint != null && !TemperatureDocument.IsNaN(lanternValuePoint.Value))
                        {
                            PointF lanternSymbolPoint = new PointF(symbolPoint.X,this.GetY(lanternYAxis,lanternValuePoint.Value));
                            Color lanternSymbolColor;
                            //if (lanternSymbolPoint.Y < symbolPoint.Y)
                            //    lanternSymbolColor = Color.Blue;
                            //else
                                lanternSymbolColor = Color.Red;
                            float lanternSymbolSize = this.GetSpecifySizeByDocumentUnit(g, lanternYAxis.SymbolSize);
                            this.DrawSymbol(g, clipRect, lanternSymbolPoint.X, lanternSymbolPoint.Y, lanternYAxis.SymbolStyle, lanternSymbolColor, lanternSymbolSize,lanternYAxis.SymbolText,this.Font,lanternYAxis.SymbolImage,this.GetToken(lanternValuePoint));
                            //设置灯笼数据点的边界范围

                            lanternValuePoint.SetBoundCore(lanternSymbolPoint.X - lanternSymbolSize / 2, lanternSymbolPoint.Y - lanternSymbolSize / 2, lanternSymbolSize, lanternSymbolSize);

                            using (Pen pen = new Pen(lanternSymbolColor, this.GetSpecifySizeByPixelUnit(g, 1f)))
                            {
                                pen.DashStyle = DashStyle.Dash;
                                g.DrawLine(pen, symbolPoint, lanternSymbolPoint);
                            }
                        }

                    }

                    #endregion

                    #region 绘制脉搏短促类似的阴影数据 (满足条件必须是同一时间阴影数据大于当前节点数据)...
                    bool drawShadow = true;
                    if (
                        //!TemperatureDocument.IsNaN(valuePoint.ShadowValue)
                        //&& 
                        !string.IsNullOrWhiteSpace(rule.ShadowValueFieldName)
                        && this.YAxisInfos.Exists(y => y.ValueFieldName == rule.ShadowValueFieldName)
                        )
                    {
                        var shadowYAxis = this.YAxisInfos.Find(y => y.ValueFieldName == rule.ShadowValueFieldName);
                        //获取阴影数据点
                        var shadowValuePoint = shadowYAxis.Values.Find(v => this.GetDayIndex(v.Time, startDate) == symbolPointDayIndex && this.GetTickIndex(v.Time) == symbolPointTickIndex && !TemperatureDocument.IsNaN(v.Value));
                        if (shadowValuePoint != null && !TemperatureDocument.IsNaN(shadowValuePoint.Value))
                        {
                            drawShadow = false;
                            float shadowPointY = this.GetY(shadowYAxis, shadowValuePoint.Value);
                            float shadowSymbolSize = this.GetSpecifySizeByDocumentUnit(g, shadowYAxis.SymbolSize);
                            this.DrawSymbol(g, clipRect, symbolPoint.X, shadowPointY, shadowYAxis.SymbolStyle, rule.SymbolColor, shadowSymbolSize, shadowYAxis.SymbolText, this.Font, shadowYAxis.SymbolImage, this.GetToken(shadowValuePoint));

                            shadowValuePoint.SetBoundCore(symbolPoint.X - shadowSymbolSize / 2, shadowPointY - shadowSymbolSize / 2, shadowSymbolSize, shadowSymbolSize);

                            shadowPoints.Add(Tuple.Create<float, float, float>(symbolPoint.X, symbolPoint.Y, shadowPointY));
                        }
                    }
                    if (drawShadow)
                    {
                        this.DrawShadow(g, rule.SymbolColor, shadowPoints);
                        shadowPoints.Clear();
                    }

                    #endregion
                }
                //连接每个数据节点
                if (points.Count > 1)
                {
                    using (Pen pen = new Pen(this.GetBrush(rule.SymbolColor), this.GetSpecifySizeByPixelUnit(g,1f)))
                    {
                        SmoothingMode smoothingMode = g.SmoothingMode;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        for (int i = 0; i < points.Count; i++)
                        {
                            if (!points[i].HasValue)
                                continue;
                            if (i + 1 < points.Count)
                            {
                                if (!points[i + 1].HasValue)
                                    continue;
                                g.DrawLine(pen, points[i].Value, points[i + 1].Value);
                            }
                        }
                        //g.DrawLines(pen, points.ToArray());
                        g.SmoothingMode = smoothingMode;
                    }
                }
                this.DrawShadow(g, rule.SymbolColor, shadowPoints);
                shadowPoints.Clear();
            }
            #region 绘制文本值...

            foreach (var yAxis in this.YAxisInfos.Where(y => y.TextFlagMode && y.ValueVisible))
            {
                //获取文本的起始顶点坐标
                float position = this.GetY(yAxis, TemperatureDocument.IsNaN(yAxis.Position) ? yAxis.MaxValue : yAxis.Position);
                foreach (var valuePointGroup in yAxis.Values.Where(y => y.Time >= minDate && y.Time < maxDate).GroupBy(yg => new { DayIndex = this.GetDayIndex(yg.Time,(DateTime?) startDate), TickIndex = this.GetTickIndex(yg.Time) }))
                {
                    //获取文本的X轴坐标
                    float x =this._GirdRectangle.Left + this.GetTickWidth() * valuePointGroup.Key.TickIndex + this.GetDayWidth() * valuePointGroup.Key.DayIndex;
                    float y = position;
                    foreach (var valuePoint in valuePointGroup.OrderBy(v=>v.Time))
                    {
                        if (!string.IsNullOrEmpty(valuePoint.Text))
                        {
                            StringBuilder drawTextBuilder = new StringBuilder();
                            char preChar=valuePoint.Text[0];
                            for (int i = 0; i < valuePoint.Text.Length; i++)
                            {
                                drawTextBuilder.Append(valuePoint.Text[i].ToString());
                                if (i != valuePoint.Text.Length - 1 && !Char.IsNumber(valuePoint.Text[i]))
                                {
                                    drawTextBuilder.AppendLine();
                                    continue;
                                }
                                if (i != valuePoint.Text.Length - 1 && Char.IsNumber(valuePoint.Text[i]) && !Char.IsNumber(valuePoint.Text[i + 1]))
                                {
                                    drawTextBuilder.AppendLine();
                                    continue;
                                }
                            }

                            string drawText = drawTextBuilder.ToString();
                            drawText.TrimEnd('\n');
                            drawText = drawText.Replace('-', '|');
                            drawText = drawText.Replace('—', '|');
                            //获取文本的大小 
                            SizeF textSize = g.MeasureString(drawText, this.Font, new PointF(x, y), this.GetStringFromat(ContentAlignment.TopLeft, false, false));
                            RectangleF textRect = new RectangleF(x, y, textSize.Width, textSize.Height);
                            //绘制背景色
                            if (yAxis.TextBackColor.A != 0 && !yAxis.TextBackColor.IsEmpty)
                            {
                                g.FillRectangle(this.GetBrush(yAxis.TextBackColor), textRect);
                            }
                            valuePoint.SetBoundCore(textRect.X, textRect.Y, textRect.Width, textRect.Height);
                            //string drawText = valuePoint.Text;
                            //drawText = drawText.Replace("|", "—");
                            //drawText = drawText.Replace("-", "—");
                            //绘制文本
                            g.DrawString(drawText, this.Font, this.GetBrush(yAxis.SymbolColor), new PointF(x, y), this.GetStringFromat(ContentAlignment.TopLeft, false, false));
                            y += textSize.Height;
                            y += 5;
                        }
                    }
                }
            }

            #endregion

        }

        private void DrawLabel(Graphics g, RectangleF clipRect,LabelInfo label)
        {
            if (label.BackColor.A == 0 && label.ForeColor.A == 0)
                return;
            if (label.LabelWidth == 0 || label.LabelHeight == 0)
                return;
            if (!label.SupportViewMode.HasFlag(this.ViewMode))
                return;
            label.ConverToBound(g,this);
            RectangleF labelRect = label.GetBound();
            if (!this.NeedDraw(clipRect, labelRect))
                return;
            Font labelFont =null;
            if(label.Font!=null)
            {
                labelFont=label.Font.GetFont();
            }
            else
            {
                labelFont=this.Font;
            }
            if (label.BackColor.A != 0)
            {
                g.FillRectangle(this.GetBrush(label.BackColor), labelRect);
            }
            if (!string.IsNullOrEmpty(label.Text) && label.ForeColor.A != 0)
            {
                string text = label.Text;
                if (label.Text.Contains("{PageIndex}"))
                {
                    text = label.Text.Replace("{PageIndex}", (this.PageIndex+1).ToString());
                }
                this.DrawTextEx(g, clipRect, text, labelRect, this.GetBrush(label.ForeColor), label.TextAlign, true);
                //g.DrawString(text, labelFont, this.GetBrush(label.ForeColor), labelRect, this.GetStringFromat(label.TextAlign, label.IsMultiLine));
            }
            if (label.Image != null)
            {
                g.DrawImage(label.Image, new PointF(labelRect.X,labelRect.Y+(labelRect.Height-(float)label.Image.Height)/2));
            }
            if (this.BorderColor.A != 0)
            {
                if (label.BorderWidth.Top > 0)
                {
                    g.FillRectangle(this.GetBrush(this.BorderColor), new RectangleF(labelRect.Left, label.Top, label.Width, label.BorderWidth.Top));
                }
                if (label.BorderWidth.Left > 0)
                {
                    g.FillRectangle(this.GetBrush(this.BorderColor), new RectangleF(labelRect.Left, label.Top, label.BorderWidth.Left, label.Height));
                }
                if (label.BorderWidth.Right > 0)
                {
                    g.FillRectangle(this.GetBrush(this.BorderColor), new RectangleF(labelRect.Right, label.Top, label.BorderWidth.Right, label.Height));
                }
                if (label.BorderWidth.Bottom > 0)
                {
                    g.FillRectangle(this.GetBrush(this.BorderColor), new RectangleF(labelRect.Left, label.Bottom, label.Width, label.BorderWidth.Bottom));
                }
            }
        }

        private void DrawShadow(Graphics g, Color color, List<Tuple<float, float, float>> shadowPoints)
        {
            if (shadowPoints.Count > 1)
            {
                List<PointF> posList1 = new List<PointF>();
                List<PointF> posList2 = new List<PointF>();
                for (int i = 0; i < shadowPoints.Count; i++)
                {
                    posList1.Add(new PointF(shadowPoints[i].Item1, shadowPoints[i].Item2));
                    posList2.Add(new PointF(shadowPoints[i].Item1, shadowPoints[i].Item3));
                }

                SmoothingMode smoothingMode = g.SmoothingMode;
                g.SmoothingMode = SmoothingMode.HighQuality;
                List<PointF> outLinePoints = new List<PointF>();
                outLinePoints.Add(posList1[0]);
                outLinePoints.AddRange(posList2);
                outLinePoints.Add(posList1.Last());
                using (Pen pen = new Pen(color, this.GetSpecifySizeByPixelUnit(g,1f)))
                {
                    g.DrawLines(pen, outLinePoints.ToArray());
                }

                posList2.Reverse();

                g.FillPolygon(this.GetShadowBrush(color), posList1.ToArray().Concat(posList2.ToArray()).ToArray());
                g.SmoothingMode = smoothingMode;

            }
        }
        /// <summary>
        /// 获取指定数据点的坐标
        /// </summary>
        /// <param name="g"></param>
        /// <param name="yAxis"></param>
        /// <param name="valuePoint"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        private PointF GetValuePoint(Graphics g, YAxisInfo yAxis, DateTime pointTime,float pointValue,DateTime startDate)
        {
            if (TemperatureDocument.IsNaN(pointValue))
                return PointF.Empty;
            float centerX = this.GetX(pointTime, startDate);
            float centerY = this.GetY(yAxis, pointValue);
            float symbolSize = this.GetSpecifySizeByDocumentUnit(g, yAxis.SymbolSize);
            RectangleF symbolRect = new RectangleF(centerX - symbolSize / 2f, centerY - symbolSize / 2f, symbolSize, symbolSize);
            //是否自动缩进边界符号
            if (this.AutoIndent && this._GirdRectangle.IntersectsWith(symbolRect))
            {
                if (symbolRect.X < this._GirdRectangle.X)
                    symbolRect.X = this._GirdRectangle.X;
                if (symbolRect.Right > this._GirdRectangle.Right)
                    symbolRect.X = this._GirdRectangle.Right - symbolSize;
            }
            centerX = symbolRect.X + symbolRect.Width / 2f;
            centerY = symbolRect.Y + symbolRect.Width / 2f;
            return new PointF(centerX, centerY);
        }
        #endregion
        /// <summary>
        /// 绘制符号
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="centerX">中心X坐标</param>
        /// <param name="centerY">中心Y坐标</param>
        /// <param name="style">符号样式</param>
        /// <param name="color">符号颜色</param>
        /// <param name="symbolSize">符号大小</param>
        private void DrawSymbol(Graphics g, RectangleF clipRect, float centerX, float centerY, SymbolStyle style, Color color, float symbolSize,string symbolText=null,Font symbolFont=null,Image sysmboImage=null,Token specifyToken=null)
        {
            if (style == SymbolStyle.None)
                return;
            RectangleF symbolRect = new RectangleF(centerX - symbolSize / 2f, centerY - symbolSize / 2f, symbolSize, symbolSize);
            if (specifyToken != null)
            {
                style = specifyToken.SymbolStyle;
                sysmboImage = specifyToken.Image;
                symbolText = specifyToken.Text;
                if(specifyToken.SymbolSize> 0)
                    symbolSize = specifyToken.SymbolSize;
            }
            if (style == SymbolStyle.Image )
            {
                if (sysmboImage == null)
                    return;
                float imageWidth = this.GetSpecifySizeByPixelUnit(g, sysmboImage.Width);
                float imageHeight = this.GetSpecifySizeByPixelUnit(g, sysmboImage.Height);
                symbolRect = new RectangleF(centerX - imageWidth / 2f, centerY - imageHeight / 2f, imageWidth, imageHeight);
                if (this.NeedDraw(clipRect, symbolRect))
                {
                    var interpolationMode = g.InterpolationMode;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(sysmboImage, symbolRect);
                    g.InterpolationMode = interpolationMode;
                }
                return;
            }
           
            if (style == SymbolStyle.Text)
            {
                if (string.IsNullOrEmpty(symbolText))
                    return;
                if (symbolFont == null)
                    symbolFont = new Font("微软雅黑", 9f);
               SizeF sizeF  = g.MeasureString(symbolText, symbolFont);
               symbolRect = new RectangleF(centerX-sizeF.Width/2f,centerY-sizeF.Height/2f,sizeF.Width,sizeF.Height);
               if (this.NeedDraw(clipRect, symbolRect))
               {
                   var textRenderingHint = g.TextRenderingHint;
                   g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                   g.DrawString(symbolText, symbolFont,this.GetBrush(color), symbolRect);
                   g.TextRenderingHint = textRenderingHint;
               }
               return;
            }
            
            if (this.NeedDraw(clipRect, symbolRect))
            {
                SmoothingMode smoothingMode = g.SmoothingMode;
                g.SmoothingMode = SmoothingMode.HighQuality;
                GraphicsHelper.DrawSymbol(g, centerX, centerY, style, color, symbolSize);
                g.SmoothingMode = smoothingMode;
            }

        }

        private StringFormat ContentAlignmentToStringFormat(ContentAlignment contentAlignment, bool wrap = true, bool isDirectionVertical=false)
        {
            StringFormat format = new StringFormat();
            switch (contentAlignment)
            {
                case ContentAlignment.BottomCenter:
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomLeft:
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomRight:
                    format.Alignment = StringAlignment.Far;
                    format.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleCenter:
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleRight:
                    format.Alignment = StringAlignment.Far;
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopCenter:
                    if (isDirectionVertical)
                    {
                        format.Alignment = StringAlignment.Near;
                        format.LineAlignment = StringAlignment.Center;
                    }
                    else
                    {
                        format.Alignment = StringAlignment.Center;
                        format.LineAlignment = StringAlignment.Near;
                    }
                    break;
                case ContentAlignment.TopLeft:
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Far;
                    break;
                default:
                    break;
            }
            format.FormatFlags = StringFormatFlags.NoClip;
            if (!wrap)
                format.FormatFlags |= StringFormatFlags.NoWrap;
            if (isDirectionVertical)
                format.FormatFlags |= StringFormatFlags.DirectionVertical;
            return format;
            //StringFormat cFormat = new StringFormat();
            //Int32 lNum = (Int32)Math.Log((Double)contentAlignment, 2);
            //cFormat.LineAlignment = (StringAlignment)(lNum / 4);
            //cFormat.Alignment = (StringAlignment)(lNum % 4);
            //cFormat.FormatFlags = StringFormatFlags.NoClip;
            //if (!wrap)
            //    cFormat.FormatFlags |= StringFormatFlags.NoWrap;
            //return cFormat;
        }

        #endregion

        #region 画笔 画刷等绘制对象的获取

        private Brush GetBrush(Color color)
        {
            if (this._DrawingCache == null)
                this._DrawingCache = new Hashtable();
            if (!this._DrawingCache.ContainsKey(color))
                this._DrawingCache.Add(color, new SolidBrush(color));
            return (Brush)this._DrawingCache[color];
        }

        private HatchBrush GetShadowBrush(Color color)
        {
            if (this._DrawingCache == null)
                this._DrawingCache = new Hashtable();
            string key = string.Format("{0} Shadow", color.ToArgb());
            if (!this._DrawingCache.ContainsKey(key))
            {
                HatchBrush hactchBrush = new HatchBrush(HatchStyle.LightUpwardDiagonal, color, Color.Transparent);

                this._DrawingCache.Add(key, hactchBrush);

            }
            return (HatchBrush)this._DrawingCache[key];
        }

        private float GetFontHeight(Graphics g, Font font)
        {
            if (this._DrawingCache == null)
                this._DrawingCache = new Hashtable();
            string key = string.Format("{0} {1} {2}",font.Name,font.Size,font.Bold?1:0);
            if (!this._DrawingCache.ContainsKey(key))
                this._DrawingCache.Add((key), font.GetHeight(g));
            return (float)this._DrawingCache[key];
        }

        private StringFormat GetStringFromat(ContentAlignment align, bool wrap = true, bool isDirectionVertical = false)
        {
            if (this._DrawingCache == null)
                this._DrawingCache = new Hashtable();
            string key = string.Format("{0} {1} {2}", align.ToString(), wrap ? 1 : 0, isDirectionVertical?1:0);
            if (!this._DrawingCache.ContainsKey(key))
            {
                this._DrawingCache.Add(key, this.ContentAlignmentToStringFormat(align, wrap, isDirectionVertical));
            }
            return (StringFormat)this._DrawingCache[key];
        }

        private void ClearDrawCache()
        {
            if (this._DrawingCache != null)
            {
                foreach (DictionaryEntry item in this._DrawingCache)
                {
                    if (item.Value is Brush)
                    {
                        (item.Value as Brush).Dispose();
                    }
                    if (item.Value is StringFormat)
                    {
                        (item.Value as StringFormat).Dispose();
                    }
                }
                this._DrawingCache.Clear();
                this._DrawingCache = null;
            }
        }
        #endregion

        /// <summary>
        /// 判断是否需要绘制
        /// </summary>
        /// <param name="clipRect">剪辑区域</param>
        /// <param name="drawRect">绘制区域</param>
        /// <returns></returns>
        private bool NeedDraw(RectangleF clipRect, RectangleF drawRect)
        {
            return clipRect.IsEmpty || clipRect.IntersectsWith(drawRect);
        }
       
        public TemperatureDocument Clone()
        {
            return this.Clone<TemperatureDocument>();
        }
    }
}