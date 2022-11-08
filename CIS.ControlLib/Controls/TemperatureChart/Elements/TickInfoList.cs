using System.Collections.Generic;
using System;

namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 刻度信息集合类
    /// </summary>
    [Serializable]
    public class TickInfoList : List<TickInfo>,ICloneable
    {
        /// <summary>
        /// 刻度信息比较器
        /// </summary>
        private class TickInfoComparer : IComparer<TickInfo>
        {
            public int Compare(TickInfo tickInfo1, TickInfo tickInfo2)
            {
                if (tickInfo1.Value > tickInfo2.Value)
                    return 1;
                else if (tickInfo1.Value == tickInfo2.Value)
                    return 0;
                else
                    return -1;
            }
        }
        /// <summary>
        /// 添加刻度信息
        /// </summary>
        /// <param name="text">刻度显示文本</param>
        /// <param name="value">刻度值 单位小时</param>
        public void Add(string text, float value)
        {
            this.Add(new TickInfo(text, value));
        }
        public void Add(string text, float value, System.Drawing.Color color)
        {
            this.Add(new TickInfo(text,value,color));
        }
        /// <summary>
        /// 通过刻度值升序
        /// </summary>
        public void SortByValue()
        {
            base.Sort(new TickInfoList.TickInfoComparer());
        }


        public object Clone()
        {
            return this.Clone<TickInfoList>();
        }
    }
}
