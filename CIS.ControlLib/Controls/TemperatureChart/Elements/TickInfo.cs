using System;
using System.Drawing;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 刻度信息类
    /// </summary>
    [Serializable]
    public class TickInfo :ICloneable
    {
        private float _Value = 0;
        private string _Text = null;
        private Color _ForeColor = Color.Black;
        private Color _BackColor = Color.Transparent;
        /// <summary>
        /// 获取或设置刻度的值 
        /// 单位小时
        /// </summary>
        [DefaultValue(0), XmlAttribute]
        public float Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        /// <summary>
        /// 获取或设置刻度的显示文本
        /// </summary>
        [DefaultValue(null), XmlAttribute]
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        /// <summary>
        /// 获取或设置前景色
        /// </summary>
        [DefaultValue(typeof(Color), "Black"), XmlIgnore]
        public Color ForeColor
        {
            get
            {
                return _ForeColor;
            }
            set
            {
                _ForeColor = value;
            }
        }
        /// <summary>
        /// 用于xml序列化 请使用ForeColor获取前景色
        /// </summary>
        [DefaultValue(null),XmlAttribute("ForeColor")]
        public string ForeColorValue
        {
            get { return ColorTranslator.ToHtml(this.ForeColor); }
            set
            {
                try
                {
                    this.ForeColor = ColorTranslator.FromHtml(value);
                }
                catch { this.ForeColor = Color.Black; }
            }
        }
        /// <summary>
        /// 获取或设置背景色
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent"), XmlIgnore]
        public Color BackColor
        {
            get
            {
                return _BackColor;
            }
            set
            {
                _BackColor = value;
            }
        }
        /// <summary>
        /// 用于xml序列化 请使用BackColor获取前景色
        /// </summary>
        [DefaultValue(null),XmlAttribute("BackColor")]
        public string BackColorValue
        {
            get { return ColorTranslator.ToHtml(this.BackColor); }
            set
            {
                try
                {
                    this.BackColor = ColorTranslator.FromHtml(value);
                }
                catch { this.BackColor = Color.Black; }
            }
        }

        public TickInfo()
        {
 
        }
        public TickInfo(string text, float value)
        {
            _Text = text;
            _Value = value;
        }
        /// <summary>
        /// 初始化刻度对象
        /// </summary>
        /// <param name="text">显示文本</param>
        /// <param name="value">刻度值</param>
        /// <param name="backColor">文本颜色</param>
        public TickInfo(string text, float value, Color foreColor)
        {
            _Text = text;
            _Value = value;
            _ForeColor = foreColor;
        }

        public object Clone()
        {
            return this.Clone<TickInfo>();
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
