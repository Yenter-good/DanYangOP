
using System;
using System.Collections.Generic;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    [Serializable]
    public class YAxisInfoList : List<YAxisInfo>, ICloneable
    {
        public YAxisInfo GetItemByName(string name)
        {
            YAxisInfo result;
            foreach (YAxisInfo current in this)
            {
                if (current.Name == name)
                {
                    result = current;
                    return result;
                }
            }
            result = null;
            return result;
        }
        public YAxisInfoList DeeplyClone()
        {
            if (this == null)
                return null;
            YAxisInfoList yAxisInfoList = new YAxisInfoList();
            foreach (YAxisInfo current in this)
            {
                yAxisInfoList.Add(current.Clone(true));
            }
            return yAxisInfoList;
        }
        public void Reset()
        {
            foreach (var yAxis in this)
            {
                yAxis.SetBoundCore(-1, -1, 0, 0);
            }
        }
        public object Clone()
        {
            if (this == null)
                return null;
            YAxisInfoList yAxisInfoList = new YAxisInfoList();
            foreach (YAxisInfo current in this)
            {
                yAxisInfoList.Add(current.Clone(false));
            }
            return yAxisInfoList;
        }
    }
}
