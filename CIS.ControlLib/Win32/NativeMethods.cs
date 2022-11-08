using System;
using System.Runtime.InteropServices;
using CIS.ControlLib.Win32;
using System.Windows.Forms;
using System.Drawing;

namespace CIS.ControlLib
{
    /// <summary>
    /// 封装Win32API的一些常用方法
    /// </summary>
    public class NativeMethods
    {
        /// <summary>
        /// 用于辅助监听控件消息,更改消息导致鼠标可以拖拉控件大小
        /// </summary>
        private class ResizeNativeWindow : NativeWindow
        {
            private int dragrange = 5;
            private Control owner = null;
            public ResizeNativeWindow(Control ctrl)
            {
                owner = ctrl;
                if(ctrl.IsHandleCreated)
                    this.AssignHandle(ctrl.Handle);
                else
                    ctrl.HandleCreated += ctrl_HandleCreated;
                ctrl.HandleDestroyed += ctrl_HandleDestroyed;
            }

            void ctrl_HandleDestroyed(object sender, EventArgs e)
            {
                this.DestroyHandle();
            }

            void ctrl_HandleCreated(object sender, EventArgs e)
            {
                this.AssignHandle((sender as Control).Handle);
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                switch (m.Msg)
                {
                    case (int)WinMsg.WM_NCHITTEST:
                        Point vPoint = new Point((int)m.LParam & 0xFFFF,
                            (int)m.LParam >> 16 & 0xFFFF);
                        vPoint = owner.PointToClient(vPoint);
                        if (vPoint.X <= dragrange)
                            if (vPoint.Y <= dragrange)
                                m.Result = new IntPtr((int) HitTest.HTTOPLEFT);
                            else if (vPoint.Y >= owner.ClientSize.Height - dragrange)
                                m.Result = new IntPtr((int) HitTest.HTBOTTOMLEFT);
                            else m.Result = new IntPtr((int)HitTest.HTLEFT);
                        else if (vPoint.X >= owner.ClientSize.Width - dragrange)
                            if (vPoint.Y <= dragrange)
                                m.Result = new IntPtr((int)HitTest.HTTOPRIGHT);
                            else if (vPoint.Y >= owner.ClientSize.Height - dragrange)
                                m.Result = new IntPtr((int)HitTest.HTBOTTOMRIGHT);
                            else m.Result =  new IntPtr((int)HitTest.HTRIGHT);
                        else if (vPoint.Y <= dragrange)
                            m.Result =  new IntPtr((int)HitTest.HTTOP);
                        else if (vPoint.Y >= owner.ClientSize.Height - dragrange)
                            m.Result =  new IntPtr((int)HitTest.HTBOTTOM);
                        break;
                }
            }
        }
        /// <summary>
        /// 鼠标移动窗体或者控件（在鼠标按下事件里调用该方法，来实现鼠标移动窗体或者控件）
        /// </summary>
        /// <param name="handle">窗体或者控件句柄</param>
        public static void MouseToMoveControl(IntPtr handle)
        {
            UnsafeNativeMethods.ReleaseCapture();
            UnsafeNativeMethods.SendMessage(handle,(int) WinMsg.WM_SYSCOMMAND, (int)SysCmd.SC_MOVE + (int)HitTest.HTCAPTION, 0);
        }

        /// <summary>
        /// 鼠标拖拉窗体或者控件（只需调用一次,不需要拖拉功能时通过返回值的对象释放ReleaseHandle）
        /// </summary>
        /// <param name="ctr"></param>
        public static NativeWindow MouseToResizeControl(Control ctr)
        {
            return new ResizeNativeWindow(ctr);
        }
        /// <summary>
        /// 获取系统中最后一次操作的时间间隔
        /// </summary>
        /// <returns></returns>
        public static long GetLastInputTime()
        {
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            if (!UnsafeNativeMethods.GetLastInputInfo(ref vLastInputInfo)) return 0;
            return Environment.TickCount - (long)vLastInputInfo.dwTime;
        }
    }
}
