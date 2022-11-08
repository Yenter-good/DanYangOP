using System;

namespace CIS.Model
{
    partial class Sys_Menu
    {
        /// <summary>
        /// 菜单打开样式
        /// </summary>
        public MenuOpenStyle? MenuOpenStyle
        {
            get
            {
                MenuOpenStyle style;
                return Enum.TryParse<MenuOpenStyle>(this.OpenStyle, out style) ? (MenuOpenStyle?)style : null;
            }
        }
        /// <summary>
        /// 获取打开样式名称
        /// </summary>
        /// <returns></returns>
        public string GetMenuOpenStyleName()
        {
            if (!this.MenuOpenStyle.HasValue) return "";
            switch (this.MenuOpenStyle.Value)
            {
                case CIS.Model.MenuOpenStyle.Tab:
                    return "选项卡模式";
                case CIS.Model.MenuOpenStyle.Dialog:
                    return "对话框模式";
                case CIS.Model.MenuOpenStyle.Window:
                    return "窗口模式";
                default:
                    return "";
            }
        }
    }
}
