using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// ������Ԫ����
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

        private string _KeyDateString = "����,II-0,III-0";
        private int _AllowKeyDateDays = 14;
        private TitleLineCountType _CountType = TitleLineCountType.PreIsDenominator;
        private int _TickStep = 6;
        private TitleLineUpDownType _UpDownType = TitleLineUpDownType.None;
        private string _CircleText = null;
        private string _SeparatorChar = ",";
        private bool _ShowSeparatorLine = false;
        //ֵ����Ϊnone ����Loop������Բ���Ч 
        private string[] _loopText = new string[] { "����,����" }; //ѭ���ı�
        private System.Drawing.Color[] _loopForeColor = null; //ѭ���ı�ǰ��ɫ
        private System.Drawing.Color[] _loopBackgroundColor = null; //ѭ���ı�����ɫ

        /// <summary>
        /// �Ƿ��ۼƹؼ��ʴ���
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
        /// ѭ��ǰ��ɫ
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
        /// ѭ������ɫ
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
        /// �������Ŀ��
        /// </summary>
        internal float TitleWidth = 0;
        /// <summary>
        /// ��ȡ�����÷ָ�����
        /// </summary>
        [XmlAttribute]
        public string SeparatorChar
        {
            get { return this._SeparatorChar; }
            set { this._SeparatorChar = value; }
        }
        /// <summary>
        /// �Ƿ������С����Ӧ
        /// </summary>
        [XmlAttribute]
        public bool SizeToFit
        {
            get { return this._SizeToFit; }
            set { this._SizeToFit = value; }
        }
        /// <summary>
        /// ��ȡ�������Ƿ���ʾ�ָ���
        /// </summary>
        [XmlAttribute]
        public bool ShowSeparatorLine
        {
            get { return this._ShowSeparatorLine; }
            set { this._ShowSeparatorLine = value; }
        }
        /// <summary>
        /// ��ȡ�����ñ����е�����
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
        /// ��ȡ�����ñ����еı���
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
        /// ��ȡ�����ñ������Ķ��뷽ʽ
        /// </summary>
        [DefaultValue(System.Drawing.ContentAlignment.MiddleCenter), XmlAttribute]
        public System.Drawing.ContentAlignment TitleTextAlign
        {
            get { return this._TitleTextAlign; }
            set { this._TitleTextAlign = value; }
        }
        /// <summary>
        /// ��ȡ�����ñ�������
        /// </summary>
        [XmlElement("TitleFont")]
        public FontInfo TitleFont
        {
            get { return this._TitleFont; }
            set { this._TitleFont = value; }
        }
        /// <summary>
        /// ��ȡ�����ñ���������ɫ
        /// </summary>
        [XmlIgnore]
        public System.Drawing.Color TitleForeColor
        {
            get { return this._TitleForeColor; }
            set { this._TitleForeColor = value; }
        }
        /// <summary>
        /// ����xml���л� ��ʹ��TitleForeColor
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
        /// ��ȡ�����ñ���������ɫ��ɫ
        /// </summary>
        [XmlIgnore]
        public System.Drawing.Color TitleBackColor
        {
            get { return this._TitleBackColor; }
            set { this._TitleBackColor = value; }
        }
        /// <summary>
        /// ����xml���л� ��ʹ��TitleBackColor
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
        /// ��ȡ�����ÿ̶Ȳ���
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
        /// ��ȡ�������ı����½�������
        /// </summary>
        [XmlAttribute("UpDownType")]
        public TitleLineUpDownType UpDownType
        {
            get { return this._UpDownType; }
            set { this._UpDownType = value; }
        }
        /// <summary>
        /// ��ȡ������ԲȦ�ı�
        /// </summary>
        [XmlAttribute("CircleText")]
        public string CircleText
        {
            get { return _CircleText; }
            set { this._CircleText = value; }
        }
        /// <summary>
        /// ��ȡ�����÷��������
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string Group
        {
            get { return this._Group; }
            set { this._Group = value; }
        }
        /// <summary>
        /// ��ȡ�����þ���Ĺؼ��� ��,�ָ�
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
        /// ��ȡ�����úϲ���
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
        /// ��ȡ�����ÿ�ʼʱ��
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
        /// ��ȡ���������ڵĹؼ���
        /// ��,�ָ�
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
        /// ��ȡ�����ô������ڹؼ��ֵ�����ʾ���ı� 
        /// ��,�ָ� 
        /// </summary>
        [XmlAttribute("KeyDateString")]
        public string KeyDateString
        {
            get { return this._KeyDateString; }
            set { this._KeyDateString = value; }
        }
        /// <summary>
        /// �ؼ������ڼ�����ʽ
        /// </summary>
        [XmlAttribute("CountType")]
        public TitleLineCountType CountType
        {
            get { return this._CountType; }
            set { this._CountType = value; }
        }

        /// <summary>
        /// ��ȡ�������������ڹؼ��ֺ�������ʾ������
        /// </summary>
        [XmlAttribute("AllowKeyDateDays")]
        public int AllowKeyDateDays
        {
            get { return this._AllowKeyDateDays; }
            set { this._AllowKeyDateDays = value; }
        }

        /// <summary>
        /// ��ȡ������
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
        /// ��ȡ�����ò�������
        /// </summary>
        [DefaultValue(TitleLineLayoutType.Normal), XmlAttribute]
        public TitleLineLayoutType LayoutType
        {
            get { return this._LoayoutType; }
            set { this._LoayoutType = value; }
        }
        /// <summary>
        /// ��ȡ������ֵ������
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
        /// ��ȡ����������Դ����
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
        /// ��ȡ������ֵ�ֶ�����
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
        /// ��ȡ������ʱ���ֶ�����
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
        /// ��ȡ���������ݼ�
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
        /// ��ȡ�������ı���ɫ
        /// 
        /// </summary>
        [XmlIgnore]
        public System.Drawing.Color TextColor
        {
            get { return this._TextColor; }
            set { this._TextColor = value; }
        }
        /// <summary>
        ///����XML���л� ��ʹ��TextColor 
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
        /// ��ȡ������ָ���ı������Ŀ��
        /// </summary>
        [XmlAttribute("TitleWidth"),DefaultValue(0)]
        public float SpecifyTitleWidth
        {
            get { return this._SpecifyTitleWidth; }
            set { this._SpecifyTitleWidth = value; }
        }
        /// <summary>
        /// ��ȡ������ָ���ĸ߶�
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
        /// ��ȡ�������ı߽�
        /// </summary>
        /// <returns></returns>
        public System.Drawing.RectangleF GetTitleBound()
        {
            return new System.Drawing.RectangleF(this.Left, this.Top
                , TitleWidth
                , this.SpecifyHeight > 0 ? this.SpecifyHeight : this.Height);
        }
        /// <summary>
        /// ��ȡ�����еı߽�
        /// </summary>
        /// <returns></returns>
        public override System.Drawing.RectangleF GetBound()
        {
            return new System.Drawing.RectangleF(this.Left, this.Top, this.Width, this.SpecifyHeight > 0 ? this.SpecifyHeight : this.Height);
        }

        /// <summary>
        /// ��¡����
        /// </summary>
        /// <param name="cloneValues">�Ƿ��¡���������ݼ�</param>
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
