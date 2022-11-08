using System;
using System.Collections.Generic;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 标题行集合类
    /// </summary>
    [Serializable]
    public class TitleLineList : List<TitleLine>, ICloneable
    {
        /// <summary>
        /// 通过名称获取指定的标题行
        /// </summary>
        /// <param name="name">标题行名称</param>
        /// <returns></returns>
        public TitleLine GetItemByName(string name)
        {
            foreach (TitleLine current in this)
            {
                if (current.Name == name)
                {
                    return current;
                }
            }
            return null;
        }

        private TitleLineList Clone(bool cloneValues)
        {
            if (this == null)
                return null;
            TitleLineList titleLineInfoList = new TitleLineList();
            foreach (var titleLineInfo in titleLineInfoList)
            {
                titleLineInfoList.Add(titleLineInfo.Clone(cloneValues));
            }
            return titleLineInfoList;
        }
        /// <summary>
        /// 深度克隆
        /// 包含value值
        /// </summary>
        /// <returns></returns>
        public TitleLineList DeeplyClone()
        {
            return this.Clone(true);
        }
        
        /// <summary>
        /// 克隆
        /// 不包含values
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.Clone(false);
        }
    }
}
