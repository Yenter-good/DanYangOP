using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using CIS.ControlLib.Drawing;

namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 标记对象
    /// </summary>
    [Serializable]
    public class Token:ICloneable
    {
        /// <summary>
        /// 归属 逗号分隔
        /// </summary>
        [XmlAttribute]
        public string Owner { get; set; }
        private SymbolStyle _SymbolStyle = SymbolStyle.Image;
        /// <summary>
        /// 符号样式
        /// </summary>
        [XmlAttribute]
        public SymbolStyle SymbolStyle { get { return _SymbolStyle; } set { _SymbolStyle = value; } }
        /// <summary>
        /// 符号大小
        /// </summary>
        [XmlAttribute]
        public float SymbolSize { get; set; }

        private System.Drawing.Image _Image = null;
        private string _ImageSrc = null;
        /// <summary>
        /// 名称
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }
        /// <summary>
        /// 描述文本
        /// </summary>
        [XmlAttribute]
        public string Text { get; set; }
        /// <summary>
        /// 图片的数据源
        /// </summary>
        [XmlAttribute]
        public string ImageSrc
        {
            get { return this._ImageSrc; }
            set
            {
                if (this._ImageSrc != value)
                    this._Image = null;
                this._ImageSrc = value;
            }
        }
        [XmlIgnore]
        public System.Drawing.Image Image
        {
            get
            {
                if (this._Image != null)
                    return this._Image;
                if (!string.IsNullOrEmpty(this.ImageSrc) && System.IO.File.Exists(this.ImageSrc))
                {
                    using (Image image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, this.ImageSrc)))
                    {
                        this._Image = (Image)image.Clone();
                        return this._Image;
                    }
                }
                return null;
            }
        }

        public override string ToString()
        {
            return this.Text;
        }

        public object Clone()
        {
            Token token = new Token();
            token.Name = this.Name;
            token.ImageSrc = this.ImageSrc;
            return token;
        }
    }
}
