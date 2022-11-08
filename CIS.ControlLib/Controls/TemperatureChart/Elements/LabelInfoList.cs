using System;
using System.Collections.Generic;


namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 文本标签集合类
    /// </summary>
    [Serializable]
    public class LabelInfoList : List<LabelInfo>,ICloneable
    {

        public object Clone()
        {
            return this.Clone<LabelInfoList>();
        }
    }
}
