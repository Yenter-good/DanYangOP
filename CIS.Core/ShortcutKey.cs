using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace CIS.Core
{
    public class ShortcutKey
    {
        private Hashtable keys;
        private Dictionary<Shortcut, string> keysDesriptions;

        public ShortcutKey()
        {
            keys = new Hashtable();
            keysDesriptions = new Dictionary<Shortcut, string>();
        }

        /// <summary>
        /// 设置指定控件的快捷键
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="shortcut">快捷键</param>
        /// <param name="description">描述</param>
        public void Set(Control ctl, Shortcut shortcut, string description)
        {
            if (ctl == null) return;
            Action action = new Action(() =>
            {
                if (!ctl.IsHandleCreated) return;
                CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(ctl.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_LBUTTONDOWN, 0, 0);
                CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(ctl.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_LBUTTONUP, 0, 0);
            });
            Set(shortcut, action, description);
        }

        /// <summary>
        /// 设置指定工具项目的快捷键
        /// </summary>
        /// <param name="tsi"></param>
        /// <param name="shortcut">快捷键</param>
        /// <param name="description">描述</param>
        public void Set(ToolStripItem tsi, Shortcut shortcut, string description)
        {
            if (tsi == null) return;
            Action action = new Action(() => { tsi.PerformClick(); });
            Set(shortcut, action, description);
        }

        /// <summary>
        /// 设置指定控件的快捷键
        /// </summary>
        /// <param name="bi"></param>
        /// <param name="shortcut">快捷键</param>
        /// <param name="description">描述</param>
        public void Set(ButtonItem bi, Shortcut shortcut, string description)
        {
            if (bi == null) return;
            Action action = new Action(() => { bi.RaiseClick(); });
            Set(shortcut, action, description);
        }

        /// <summary>
        /// 设置指定功能的快捷键
        /// </summary>
        /// <param name="shortcut">快捷键</param>
        /// <param name="action">行为</param>
        /// <param name="description">描述</param>
        public void Set(Shortcut shortcut, Action action, string description)
        {
            int keyFlag = (int)shortcut;
            if (action == null)
            {
                if (keys.ContainsKey(keyFlag))
                    keys.Remove(action);
                if (keysDesriptions.ContainsKey(shortcut))
                    keysDesriptions.Remove(shortcut);
                return;
            }
            keys[keyFlag] = action;
            keysDesriptions[shortcut] = description;
        }

        /// <summary>
        /// 移除指定快捷键功能
        /// </summary>
        /// <param name="shortcut"></param>
        public void Remove(Shortcut shortcut)
        {
            int keyFlag = (int)shortcut;
            keys.Remove(keyFlag);
        }

        /// <summary>
        /// 判断是否存在指定快捷键
        /// </summary>
        /// <param name="shortcut"></param>
        /// <returns></returns>
        public bool Contains(Shortcut shortcut)
        {
            int keyFlag = (int)shortcut;
            return keys.ContainsKey(keyFlag) && keys[keyFlag] is Action;
        }

        /// <summary>
        /// 触发指定按键对应的功能
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        public bool Raise(Keys keyData)
        {
            int flag = (int)keyData;
            if (Contains((Shortcut)(int)keyData))
            {
                (keys[flag] as Action)();
                return true;
            }
            return false;
        }
    }
}