namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 上下交替文本类型
    /// </summary>
    public enum TitleLineUpDownType
    {
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// 相邻文本上下交错
        /// </summary>
        UpDown,
        /// <summary>
        /// 在日单元中上下交错
        /// </summary>
        DayUpDown,
        /// <summary>
        /// 全局日单元上下交错
        /// </summary>
        GolbalDayUpDown,
        /// <summary>
        /// 全局的两两文本上下交错
        /// </summary>
        GolbalUpDown

    }
}
