using System;
using System.ComponentModel;
using System.Xml.Serialization;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// ���ݵ���
    /// </summary>
    [Serializable]
    public class ValuePoint : Element
    {
        private DateTime _Time = DateTime.MinValue;
        private float _Value = -10000f;
        //private float _LanternValue = -10000f;
        //private float _ShadowValue = -10000f;
        private string _Text = null;
        private string _Token = null;
        private bool _CutOff = false;
        [NonSerialized]
        private object _DataBoundItem = null;
        /// <summary>
        /// ��ȡ������ʱ���
        /// </summary>
        [XmlAttribute]
        public DateTime Time
        {
            get
            {
                return this._Time;
            }
            set
            {
                this._Time = value;
            }
        }
        /// <summary>
        /// ��ȡ��������ֵ
        /// </summary>
        [DefaultValue(-10000f), XmlAttribute]
        public float Value
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
        /// ��ȡ���������ݵ�ļǺ�
        /// </summary>
        [XmlAttribute]
        public string Token
        {
            get { return _Token; }
            set { _Token = value; }
        }
        /// <summary>
        /// �Ƿ�ض����ݵ�
        /// </summary>
        [XmlAttribute]
        public bool CutOff 
        { 
            get { return this._CutOff; } 
            set { this._CutOff = value; }
        }
        ///// <summary>
        ///// ��ȡ�����õ������ݵ�ֵ
        ///// </summary>
        //[DefaultValue(-10000f), XmlAttribute]
        //public float LanternValue
        //{
        //    get
        //    {
        //        return this._LanternValue;
        //    }
        //    set
        //    {
        //        this._LanternValue = value;
        //    }
        //}
        ///// <summary>
        ///// ��ȡ��������Ӱ����ֵ
        ///// </summary>
        //[DefaultValue(-10000f), XmlAttribute]
        //public float ShadowValue
        //{
        //    get { return this._ShadowValue; }
        //    set { this._ShadowValue = value; }
        //}
        /// <summary>
        /// ��ȡ��������ʾ���ı�
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this._Text = value;
            }
        }
        /// <summary>
        /// ��ȡ���������ݰ���
        /// </summary>
        [Browsable(false), XmlIgnore]
        public object DataBoundItem
        {
            get
            {
                return this._DataBoundItem;
            }
            set
            {
                this._DataBoundItem = value;
            }
        }
        /// <summary>
        /// ��ȡ���ݵ�������ı�
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Time.ToString("yyyy-MM-dd HH:mm:ss") + "#" + this.Value;
        }
        public ValuePoint Clone()
        {
            return (ValuePoint)base.MemberwiseClone();
        }
    }
}
