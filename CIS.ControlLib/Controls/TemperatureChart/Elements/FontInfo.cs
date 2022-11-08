using System;
using System.Xml.Serialization;
using System.ComponentModel;

namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 字体格式
    /// </summary>
    [Serializable]
    public class FontInfo
    {
        private string _Name = "宋体";
        private float _Size = 9;
        private System.Drawing.FontStyle _Style = System.Drawing.FontStyle.Regular;
        /// <summary>
        /// 字体大小
        /// </summary>
        [DefaultValue(9), XmlAttribute]
        public float Size
        {
            get { return _Size; }
            set { _Size = value; }
        }
        /// <summary>
        /// 字体名称
        /// </summary>
        [DefaultValue("宋体"), XmlAttribute]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// 获取或设置字体样式
        /// </summary>
        [DefaultValue(System.Drawing.FontStyle.Regular), XmlAttribute]
        public System.Drawing.FontStyle Style
        {
            get
            {
                return _Style;
            }
            set
            {
                _Style = value;
            }
        }
        /// <summary>
        /// 初始化字体信息
        /// </summary>
        public FontInfo()
        {
 
        }
        /// <summary>
        /// 初始化字体信息
        /// </summary>
        /// <param name="fontName">字体名称</param>
        public FontInfo(string fontName)
            :this(fontName,9f, System.Drawing.FontStyle.Regular)
        {
 
        }
        /// <summary>
        /// 初始化字体信息
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontSize">字体大小</param>
        public FontInfo(string fontName, float fontSize)
            :this(fontName,fontSize, System.Drawing.FontStyle.Regular)
        {
           
        }
        /// <summary>
        /// 初始化字体信息
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="fontStyle">字体样式</param>
        public FontInfo(string fontName, float fontSize, System.Drawing.FontStyle fontStyle)
        {
            this._Name = fontName;
            this._Size = fontSize;
            this._Style = fontStyle;
        }
        /// <summary>
        /// 获取字体对象
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Font GetFont()
        {
            return new System.Drawing.Font(this.Name, this.Size, this.Style);
        }
        /// <summary>
        /// 分配字体相关属性
        /// </summary>
        /// <param name="font">字体对象</param>
        public void Assign(System.Drawing.Font font)
        {
            this.Size = font.Size;
            this.Name = font.Name;
            this.Style = font.Style;
        }
    }
}
