
using System;
using System.Collections.Generic;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    [Serializable]
	public class HeaderLabelList : List<HeaderLabel>,ICloneable
	{
		public HeaderLabel AddItemByDataSourceName(string title, string dataSourceName)
		{
			HeaderLabel headerLabelInfo = new HeaderLabel();
			headerLabelInfo.Title = title;
			headerLabelInfo.DataSourceName = dataSourceName;
			base.Add(headerLabelInfo);
			return headerLabelInfo;
		}
		public HeaderLabel AddItemByValue(string title, string Value)
		{
			HeaderLabel headerLabelInfo = new HeaderLabel();
			headerLabelInfo.Title = title;
			headerLabelInfo.Value = Value;
			base.Add(headerLabelInfo);
			return headerLabelInfo;
		}
		public HeaderLabelList Clone()
		{
            return (HeaderLabelList)((ICloneable)this).Clone();
		}

        object ICloneable.Clone()
        {
            return this.Clone<HeaderLabelList>();
        }
    }
}
