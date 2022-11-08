using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace CIS.ControlLib.Controls
{
    /// <summary>
    /// 弹出框窗体
    /// </summary>
    public class PopupForm:Form
    {
        private MethodInfo setControlStyleMethod;
        private object[] setControlStyleArgs = new object[] { ControlStyles.Selectable, false };
        private bool canResize = false;
        private NativeWindow resizeNativeWindow = null;
        /// <summary>
        /// 是否可以移动窗体
        /// </summary>
        public bool CanMove { get; set; }
        /// <summary>
        /// 是否可以拉动窗体
        /// </summary>
        public bool CanResize
        {
            get { return canResize; }
            set
            {
                if (resizeNativeWindow == null && value)
                    resizeNativeWindow = NativeMethods.MouseToResizeControl(this);
                if (!value && resizeNativeWindow != null)
                {
                    resizeNativeWindow.ReleaseHandle();
                    resizeNativeWindow = null;
                }
                canResize = value;
            }
        }
        /// <summary>
        /// 显示时不获得焦点
        /// </summary>
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        } 
        public PopupForm()
        {
            this.InitializeComponent();

            setControlStyleMethod = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.Instance);

            if (!this.IsDesignMode())
            {
                //监听鼠标是否点击窗体外部
                Timer t = new Timer();
                t.Interval = 100;
                t.Tick += new EventHandler(T_Tick);
                t.Enabled = true;
            }
        }
        void T_Tick(object sender, EventArgs e)
        {
            //鼠标点击窗体外时关闭窗体
            if (!this.Bounds.Contains(Control.MousePosition)
                && Control.MouseButtons == MouseButtons.Left)
                Close();
        }
        private void SetControlNoFocus(Control ctrl)
        {
            setControlStyleMethod.Invoke(ctrl, setControlStyleArgs);
            SetChildControlNoFocus(ctrl);

        }
        private void SetChildControlNoFocus(Control ctrl)
        {
            if (ctrl.HasChildren)
                foreach (Control c in ctrl.Controls)
                {
                    SetControlNoFocus(c);
                }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PopupForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopupForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopupForm_MouseDown);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// 防止鼠标点击导致窗体获得焦点
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)Win32.WinMsg.WM_MOUSEACTIVATE)
            {
                m.Result = new IntPtr((int)Win32.MouseActivateFlags.MA_NOACTIVATE);
                return;
            }
            if (m.Msg == (int)Win32.WinMsg.WM_NCACTIVATE)
            {
                if (this.Owner != null)
                    this.Owner.Activate();
            }
            base.WndProc(ref m);
        }
        public void Show(Control control)
        {
            Show(control, control.ClientRectangle);
        }

        public void Show(Control control, bool center)
        {
            Show(control, control.ClientRectangle, center);
        }

        public void Show(Control control, Rectangle area)
        {
            Show(control, area, false);
        }

        public void Show(Control control, Rectangle area, bool center)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            Rectangle screen = Screen.FromControl(control).WorkingArea;
            if (center)
            {
                if (location.X + (area.Width + Size.Width) / 2 > screen.Right)
                {
                    location.X = screen.Right - Size.Width;
                }
                else
                {
                    location.X = location.X - (Size.Width - area.Width) / 2;
                }
            }
            else
            {
                if (location.X + Size.Width > (screen.Left + screen.Width))
                {
                    location.X = (screen.Left + screen.Width) - Size.Width;
                }
            }

            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                location.Y -= Size.Height + area.Height;
            }
            this.Location = location;
            this.Show();
        }

        private void PopupForm_MouseDown(object sender, MouseEventArgs e)
        {
            //移动窗体
            if(this.CanMove && e.Clicks < 2)
                NativeMethods.MouseToMoveControl(this.Handle);
        }

    }
}
