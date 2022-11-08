
using System;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Drawing;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 页眉标签类
    /// </summary>
    [Serializable]
    public class HeaderLabel : Element
    {
        private string _Title = null;
        private string _DataSourceName = null;
        private string _ValueFieldName = null;
        private string _Value = null;
        private string _Format = null;
        private Color _ForeColor = Color.Blue;
        /// <summary>
        /// 获取或设置标题名称
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
        /// 获取或设置值
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }
        /// <summary>
        /// 获取显示值文本
        /// </summary>
        [XmlIgnore]
        public string Text
        {
            get 
            {
                if (string.IsNullOrWhiteSpace(this.Format))
                    return this.Value;
                else
                {
                    if (this.Value == null)
                        return "";
                    try
                    {
                        DateTime dateValue;
                        if (DateTime.TryParse(this.Value, out dateValue))
                            return string.Format(this.Format, dateValue);
                        decimal decValue = 0;
                        if(Decimal.TryParse(this.Value,out decValue))
                            return string.Format(this.Format, decValue);
                        return string.Format(this.Format, this.Value);

                    }
                    catch { return this.Value; }
                }
            }
        }
        /// <summary>
        /// 获取或设置格式字符串
        /// {0:yyyy-MM-dd}
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string Format
        {
            get
            {
                return this._Format;
            }
            set
            {
                this._Format = value;
            }
        }
        /// <summary>
        /// 获取或设置文本颜色
        /// </summary>
        [DefaultValue(typeof(Color),"Blue"), XmlIgnore]
        public Color ForeColor
        {
            get { return this._ForeColor; }
            set { this._ForeColor = value; }
        }
        /// <summary>
        /// 用于XML序列化 请使用ForeColor
        /// </summary>
        [XmlAttribute("ForeColor")]
        public string ForeColorValue
        {
            get { return ColorTranslator.ToHtml(this.ForeColor); }
            set {
                try
                {
                    this.ForeColor = ColorTranslator.FromHtml(value);
                }
                catch
                {
                    this.ForeColor = Color.Blue;
                }
            }
        }
        /// <summary>
        /// 获取显示的文本
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(this.Format))
                return this.Title + ":" + this.Value;
            else
            {
                return this.Title + ":" + this.Text;
            }
        }

        public HeaderLabel Clone()
        {
            return (HeaderLabel)base.MemberwiseClone();
        }
    }
}
