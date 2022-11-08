using System.Drawing;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace CIS.Core
{
    /// <summary>
    /// 右下角提示框
    /// </summary>
    public static class AlertBox
    {
        /// <summary>
        /// 弹出错误信息
        /// </summary>
        /// <param name="text"></param>
        public static void Error(string text, int second = 2)
        {
            DesktopAlert.Show(text, "\uf071", eSymbolSet.Awesome, Color.Empty, eDesktopAlertColor.Red, eAlertPosition.BottomRight, second, -1, null);
        }

        /// <summary>
        /// 弹出信息
        /// </summary>
        /// <param name="text"></param>
        public static void Info(string text, int second = 2)
        {
            DesktopAlert.Show(text, "\uf06a", eSymbolSet.Awesome, Color.Empty, eDesktopAlertColor.BlueGray, eAlertPosition.BottomRight, second, -1, null);
        }
    }
}