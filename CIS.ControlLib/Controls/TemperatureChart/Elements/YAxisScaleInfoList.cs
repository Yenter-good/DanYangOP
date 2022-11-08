using System;
using System.Collections.Generic;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 刻度缩放信息集合类
    /// </summary>
    [Serializable]
    public class YAxisScaleInfoList : List<YAxisScaleInfo>
    {
        private class YAxisScaleInfoCompare : IComparer<YAxisScaleInfo>
        {
            public int Compare(YAxisScaleInfo y1, YAxisScaleInfo y2)
            {
                int result;
                if (y1.Value == y2.Value)
                {
                    result = 0;
                }
                else
                {
                    if (y1.Value > y2.Value)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = -1;
                    }
                }
                return result;
            }
        }
        public void AddItem(float Value, float scaleRate)
        {
            base.Add(new YAxisScaleInfo
            {
                Value = Value,
                ScaleRate = scaleRate
            });
        }
        public void SortByValue()
        {
            base.Sort(new YAxisScaleInfoList.YAxisScaleInfoCompare());
        }
    }
}
