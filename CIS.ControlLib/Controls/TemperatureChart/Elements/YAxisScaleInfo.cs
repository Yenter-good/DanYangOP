using System;
using System.ComponentModel;
using System.Xml.Serialization;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// ���ݱ�ߵĿ̶�����ֵ��Ϣ��
    /// </summary>
    [Serializable]
    public class YAxisScaleInfo 
    {
        private string _Text = null;
        private float _Value = 0f;
        private float _ScaleRate = 0f;
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
        [DefaultValue(0), XmlAttribute]
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
        [DefaultValue(0f), XmlAttribute]
        public float ScaleRate
        {
            get
            {
                return this._ScaleRate;
            }
            set
            {
                this._ScaleRate = value;
            }
        }
        public YAxisScaleInfo Clone()
        {
            return (YAxisScaleInfo)base.MemberwiseClone();
        }
        public override string ToString()
        {
            return this.Value + "#" + this.ScaleRate;
        }
    }
}
