

using System;
using System.Xml.Serialization;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 体温单元素类
    /// </summary>
    [Serializable]
    public class Element 
    {
        private float _Top = 0;
        private float _Left = 0;
        private float _Width = 0;
        private float _Height = 0;

        /// <summary>
        /// 获取或设置顶端位置
        /// </summary>
        [XmlIgnore]
        public virtual float Top 
        { 
            get 
            {
                return this._Top; 
            }
            set { this._Top = value; }
        }
        /// <summary>
        /// 获取或设置左端位置
        /// </summary>
        [XmlIgnore]
        public virtual float Left
        {
            get { return this._Left; }
            set { this._Left = value; }
        }
        [XmlIgnore]
        public float Right
        {
            get { return this.Left + this.Width; }
        }
        [XmlIgnore]
        public float Bottom
        {
            get { return this.Top + this.Height; }
        }
        /// <summary>
        /// 获取或设置宽度
        /// </summary>
        [XmlIgnore]
        public virtual float Width
        {
            get { return this._Width; }
            set { this._Width = value; }
        }
        /// <summary>
        /// 获取或设置高度
        /// </summary>
        [XmlIgnore]
        public virtual float Height
        {
            get { return this._Height; }
            set { this._Height = value; }
        }
        /// <summary>
        /// 获取或设置元素的边界
        /// </summary>
        /// <returns></returns>
        public virtual System.Drawing.RectangleF GetBound()
        {
            return new System.Drawing.RectangleF(this.Left, this.Top, this.Width, this.Height);
        }
        /// <summary>
        /// 设置元素的边界
        /// </summary>
        /// <param name="left">左端位置</param>
        /// <param name="top">顶端位置</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public virtual void SetBoundCore(float left,float top,float width,float height)
        {
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
        }
    }
}
