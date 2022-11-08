using System;
using System.Collections.Generic;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// �����м�����
    /// </summary>
    [Serializable]
    public class TitleLineList : List<TitleLine>, ICloneable
    {
        /// <summary>
        /// ͨ�����ƻ�ȡָ���ı�����
        /// </summary>
        /// <param name="name">����������</param>
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
        /// ��ȿ�¡
        /// ����valueֵ
        /// </summary>
        /// <returns></returns>
        public TitleLineList DeeplyClone()
        {
            return this.Clone(true);
        }
        
        /// <summary>
        /// ��¡
        /// ������values
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.Clone(false);
        }
    }
}
