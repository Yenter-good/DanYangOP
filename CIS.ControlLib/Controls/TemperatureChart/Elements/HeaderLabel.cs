
using System;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Drawing;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// ҳü��ǩ��
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
        /// ��ȡ�����ñ�������
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
        /// ��ȡ������ֵ
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
        /// ��ȡ��ʾֵ�ı�
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
        /// ��ȡ�����ø�ʽ�ַ���
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
        /// ��ȡ�������ı���ɫ
        /// </summary>
        [DefaultValue(typeof(Color),"Blue"), XmlIgnore]
        public Color ForeColor
        {
            get { return this._ForeColor; }
            set { this._ForeColor = value; }
        }
        /// <summary>
        /// ����XML���л� ��ʹ��ForeColor
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
        /// ��ȡ��ʾ���ı�
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
