using System;
using System.Xml.Serialization;

namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 警告类
    /// </summary>
    [Serializable]
    public class Caution
    {
        private float _ThresholdValue = TemperatureDocument.NullValue;
        private JudgeType _Judge = JudgeType.GreaterThan;
        private float _CatutionDays = 1;

        [XmlAttribute]
        public string TargetValueFiledName { get; set; }

        [XmlAttribute]
        public JudgeType Judge { get { return this._Judge; } set { this._Judge = value; } }

        [XmlAttribute]
        public float ThresholdValue { get { return this._ThresholdValue; } set { this._ThresholdValue = value; } }

        [XmlAttribute]
        public string KeyCationText { get; set; }

        [XmlAttribute]
        public float CautionDays
        { 
            get
            {
                if(this._CatutionDays<0)
                    this._CatutionDays=0;
                return this._CatutionDays;
            }
            set { this._CatutionDays = value; }
        }

        [XmlIgnore]
        public string[] CautionKeys
        {
            get
            {
                if (string.IsNullOrWhiteSpace(KeyCationText))
                    return new string[0];
                return KeyCationText.Split(',');
            }
        }
        [XmlIgnore]
        public string JudgeString
        {
            get 
            {
                switch (this.Judge)
                {
                    case JudgeType.GreaterThan:
                        return ">";
                    case JudgeType.GreaterThanOrEqual:
                        return ">=";
                    case JudgeType.Equal:
                        return "=";
                    case JudgeType.NotEqual:
                        return "<>";
                    case JudgeType.LessThan:
                        return "<";
                    case JudgeType.LessThanOrEqual:
                        return "<=";
                    default:
                        return ">";
                }
            }
        }


        public Caution()
        {
 
        }

        public bool JudgeThreshold(float value)
        {
            if (TemperatureDocument.IsNaN(this.ThresholdValue)
                || TemperatureDocument.IsNaN(value))
                return false;
            switch (this.Judge)
            {
                case JudgeType.GreaterThan:
                    return value > this.ThresholdValue;
                case JudgeType.GreaterThanOrEqual:
                    return value >= this.ThresholdValue;
                case JudgeType.Equal:
                    return value == this.ThresholdValue;
                case JudgeType.NotEqual:
                    return value != this.ThresholdValue;
                case JudgeType.LessThan:
                    return value < this.ThresholdValue;
                case JudgeType.LessThanOrEqual:
                    return value <= this.ThresholdValue;
                default:
                    return value > this.ThresholdValue;
            }
        }
    }
}
