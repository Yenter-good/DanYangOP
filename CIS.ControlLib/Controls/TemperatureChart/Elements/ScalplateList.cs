using System;
using System.Collections.Generic;

namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 标尺集合类
    /// </summary>
    [Serializable]
    public class ScaleplateList : List<Scaleplate>, ICloneable
    {
        public object Clone()
        {
            return this.Clone<ScaleplateList>();
        }
    }
}