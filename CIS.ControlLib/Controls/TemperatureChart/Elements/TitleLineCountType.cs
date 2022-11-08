using System.Runtime.InteropServices;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 获取或设置标题行计数方式
    /// </summary>
    [ComVisible(false)]
    public enum TitleLineCountType
    {
        /// <summary>
        /// 重新计数
        /// </summary>
        Reset,
        /// <summary>
        /// 前一个计数当做分母
        /// </summary>
        PreIsDenominator,
        /// <summary>
        /// 前一个计数当做分子
        /// </summary>
        PreIsNumerator 
    }
}
