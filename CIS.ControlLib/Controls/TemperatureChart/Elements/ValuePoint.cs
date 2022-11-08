using System;
using System.ComponentModel;
using System.Xml.Serialization;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 数据点类
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
        /// 获取或设置时间点
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
        /// 获取或设置数值
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
        /// 获取或设置数据点的记号
        /// </summary>
        [XmlAttribute]
        public string Token
        {
            get { return _Token; }
            set { _Token = value; }
        }
        /// <summary>
        /// 是否截断数据点
        /// </summary>
        [XmlAttribute]
        public bool CutOff 
        { 
            get { return this._CutOff; } 
            set { this._CutOff = value; }
        }
        ///// <summary>
        ///// 获取或设置灯笼数据的值
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
        ///// 获取或设置阴影数据值
        ///// </summary>
        //[DefaultValue(-10000f), XmlAttribute]
        //public float ShadowValue
        //{
        //    get { return this._ShadowValue; }
        //    set { this._ShadowValue = value; }
        //}
        /// <summary>
        /// 获取或设置显示的文本
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
        /// 获取或设置数据绑定项
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
        /// 获取数据点的描述文本
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
