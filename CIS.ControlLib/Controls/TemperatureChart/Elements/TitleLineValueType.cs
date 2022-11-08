using System.Runtime.InteropServices;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 获取或设置标题行数据类型
    /// </summary>
	[ComVisible(false)]
	public enum TitleLineValueType
	{
        /// <summary>
        /// 日期
        /// </summary>
		SerialDate,
        /// <summary>
        /// 天数
        /// </summary>
		InDayIndex,
        /// <summary>
        /// 关键开始日期天数
        /// </summary>
		DayIndex,
        /// <summary>
        /// 刻度
        /// </summary>
		HourTick,
        /// <summary>
        /// 文本
        /// </summary>
		Text,
        /// <summary>
        /// 数据类型
        /// </summary>
		Data,
        /// <summary>
        /// 无  非数据类型
        /// </summary>
        None
	}
}
