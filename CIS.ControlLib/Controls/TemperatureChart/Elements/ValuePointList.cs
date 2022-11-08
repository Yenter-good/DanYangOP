using System;
using System.Collections.Generic;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// ���ݵ㼯����
    /// </summary>
    [Serializable]
    public class ValuePointList : List<ValuePoint>
    {
        /// <summary>
        /// ���ݵ�Ƚ���
        /// </summary>
        private class ValuePointComparer : IComparer<ValuePoint>
        {
            public int Compare(ValuePoint vp1, ValuePoint vp2)
            {
                return DateTime.Compare(vp1.Time, vp2.Time);
            }
        }
        /// <summary>
        /// �����ֵ�����ݵ�
        /// </summary>
        /// <param name="time">ʱ���</param>
        /// <param name="value">��ֵ</param>
        /// <returns></returns>
        public ValuePoint AddByTimeValue(DateTime time, float value,string token=null,bool cutOff=false)
        {
            ValuePoint valuePoint = new ValuePoint();
            valuePoint.Time = time;
            valuePoint.Value = value;
            valuePoint.Token = token;
            valuePoint.CutOff = cutOff;
            base.Add(valuePoint);
            return valuePoint;
        }
        /// <summary>
        /// ����ı������ݵ�
        /// </summary>
        /// <param name="time">ʱ���</param>
        /// <param name="text">�ı�</param>
        /// <returns></returns>
        public ValuePoint AddByTimeText(DateTime time, string text)
        {
            ValuePoint valuePoint = new ValuePoint();
            valuePoint.Time = time;
            valuePoint.Text = text;
            base.Add(valuePoint);
            return valuePoint;
        }
        /// <summary>
        /// ��Ӹ���������ֵ�����ݵ�
        /// </summary>
        /// <param name="time">ʱ���</param>
        /// <param name="value">��ֵ</param>
        /// <param name="landernValue">��Ӧ�ĵ�����ֵ</param>
        /// <returns></returns>
        public ValuePoint AddByTimeValueLandernValue(DateTime time, float value, float landernValue)
        {
            ValuePoint valuePoint = new ValuePoint();
            valuePoint.Time = time;
            valuePoint.Value = value;
            //valuePoint.LanternValue = landernValue;
            base.Add(valuePoint);
            return valuePoint;
        }
        /// <summary>
        /// ���ݰ�
        /// </summary>
        /// <param name="dateSource">����Դ</param>
        /// <param name="timeFieldName">ʱ����ֶ���</param>
        /// <param name="valueFieldName">ֵ�ֶ���</param>
        /// <param name="isTextFlagMode">�Ƿ�Ϊ�ı�ģʽ</param>
        internal void DataBind(object dateSource, string timeFieldName, string valueFieldName, bool isTextFlagMode)
        {
            if (this.IsSpecifyDataSource(dateSource))
            {
                this.DataBind(dateSource as System.Data.DataTable, valueFieldName, isTextFlagMode);
                return;
            }
            base.Clear();
            if (dateSource != null && !string.IsNullOrEmpty(timeFieldName) && !string.IsNullOrEmpty(valueFieldName))
            {
                CIS.ControlLib.Controls.TemperatureChart.Data.DCDataSource dCDataSource = new CIS.ControlLib.Controls.TemperatureChart.Data.DCDataSource(dateSource);
              
                dCDataSource.Start();
                while (dCDataSource.MoveNext())
                {
                    ValuePoint valuePoint = new ValuePoint();
                    valuePoint.Value = float.NaN;
                    valuePoint.Time = Convert.ToDateTime(dCDataSource.ReadValue(timeFieldName));
                    valuePoint.DataBoundItem = dCDataSource.Current;
                    if (isTextFlagMode)
                    {
                        try
                        {
                            valuePoint.Text = Convert.ToString(dCDataSource.ReadValue(valueFieldName));
                        }
                        catch { valuePoint.Text = null; }
                    }
                    else
                    {
                        try
                        {
                            valuePoint.Value = this.ToSingleValue(dCDataSource.ReadValue(valueFieldName));
                        }
                        catch { valuePoint.Value = -10000; }
                    }
                    //if (!string.IsNullOrEmpty(lanternValueFieldName))
                    //{
                    //    try
                    //    {
                    //        valuePoint.LanternValue = this.ToSingleValue(dCDataSource.ReadValue(lanternValueFieldName));
                    //    }
                    //    catch { valuePoint.LanternValue = -10000; }
                    //}
                    //if (!string.IsNullOrEmpty(shadowValueFieldName))
                    //{
                    //    try
                    //    {
                    //        valuePoint.ShadowValue = this.ToSingleValue(dCDataSource.ReadValue(shadowValueFieldName));

                    //    }
                    //    catch { valuePoint.ShadowValue = -10000; }
                    //}
                    base.Add(valuePoint);
                }
            }
        }
        /// <summary>
        /// �Ƿ�Ϊָ��������Դ
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool IsSpecifyDataSource(object obj)
        {
            if (obj is System.Data.DataTable)
            {
                var dt = obj as System.Data.DataTable;
                return dt.Columns.Contains("TimeField")
                    && dt.Columns.Contains("ValueField")
                    && dt.Columns.Contains("Value")
                    && dt.Columns.Contains("Token")
                    && dt.Columns.Contains("CutOff");
            }
                return false;
        }
        private void DataBind(System.Data.DataTable dataSource, string valueField, bool textFlagMode)
        {
            base.Clear();
            var drs = dataSource.Select("ValueField = '" + valueField + "'");
            if (drs != null && drs.Length > 0)
            {
                foreach (var dr in drs)
                {
                    var vp = new ValuePoint();
                    vp.Value = float.NaN;
                    vp.Text = null;
                    vp.DataBoundItem = null;
                    vp.Time = Convert.ToDateTime(dr["TimeField"]);
                    if (textFlagMode)
                        vp.Text = Convert.ToString(dr["Value"]);
                    else
                        vp.Value = ToSingleValue(dr["Value"]);
                    vp.CutOff = dr["CutOff"] == DBNull.Value || dr["CutOff"] ==null? false : (bool)dr["CutOff"];
                    vp.Token = Convert.ToString(dr["Token"]);
                    base.Add(vp);
                }
            }
        }
        /// <summary>
        /// ��ָ������ת���ض��ĸ�����ֵ
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private float ToSingleValue(object value)
        {
            float result;
            if (value == null || DBNull.Value.Equals(value))
            {
                result = -10000f;
            }
            else
            {
                try
                {
                    float num = Convert.ToSingle(value);
                    if (float.IsNaN(num))
                    {
                        result = -10000f;
                    }
                    else
                    {
                        result = num;
                    }
                }
                catch
                {
                    result = -10000f;
                }
            }
            return result;
        }
        /// <summary>
        /// ͨ��ʱ������
        /// </summary>
        public void SortByTime()
        {
            base.Sort(new ValuePointList.ValuePointComparer());
        }
        /// <summary>
        /// ��¡����
        /// </summary>
        /// <returns></returns>
        public ValuePointList Clone()
        {
            return this.Clone<ValuePointList>();
        }
    }
}