using System.Collections.Generic;

namespace CIS.Core
{
    /// <summary>
    /// 资源管理
    /// </summary>
    public class ResourceMananger
    {
        private static System.Collections.Hashtable m_Resource = new System.Collections.Hashtable();
        private static bool m_Loaded = false;

        /// <summary>
        /// 加载资源
        /// </summary>
        /// <param name="forceUpdate">是否强制更新</param>
        public static void LoadResources(bool forceUpdate = false)
        {
            if (m_Loaded && !forceUpdate) return;
            m_Resource.Clear();
            foreach (var icon in GetAppIcons())
            {
                m_Resource["APP*" + icon.Key] = icon.Value;
            }
        }

        public static System.Drawing.Image ReadAppIcon(string iconCls)
        {
            string appIconKey = "APP*" + iconCls;
            if (m_Loaded && m_Resource.ContainsKey(appIconKey))
                return (System.Drawing.Image)m_Resource[appIconKey];
            return GetAppIcon(iconCls);
        }

        /// <summary>
        /// 获取系统图片列表
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, System.Drawing.Image> GetAppIcons()
        {
            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="iconCls"></param>
        /// <returns></returns>
        private static System.Drawing.Image GetAppIcon(string iconCls)
        {
            return null;
        }
    }
}