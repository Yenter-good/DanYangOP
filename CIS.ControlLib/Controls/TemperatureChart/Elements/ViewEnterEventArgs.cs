using System;
using System.Runtime.InteropServices;

namespace CIS.ControlLib.Controls.TemperatureChart
{

    [ComVisible(true)]
    public class ViewEventArgs : EventArgs
    {

        public ViewEventArgs(ViewParts part)
        {
            this.Part = part;
            this.Element = null;
        }
        public ViewEventArgs(ViewParts part, Element element)
        {
            this.Part = part;
            this.Element = element;
        }
        /// <summary>
        /// 视图部位
        /// </summary>
        public ViewParts Part { get;private set; }
        /// <summary>
        /// 关联的元素
        /// </summary>
        public Element Element { get; private set; }
    }
}
