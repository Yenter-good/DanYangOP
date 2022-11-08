using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Security.Permissions;
using System.ComponentModel;
using CIS.ControlLib.Win32;

namespace CIS.ControlLib.Controls
{
    [ToolboxItem(false)]

    public class PopupControlHost : ToolStripDropDown
    
    {   
        #region 字段

        private ToolStripControlHost _controlHost;
        private Control _targetControl;

        public Control TargetControl
        {
            get { return _targetControl; }
        }
        /// <summary>
        /// 点击该控件将不会导致窗口关闭
        /// </summary>
        public Control IngoreControl { get; set; }
        private bool _changeRegion;
        private bool _openFocused;
        private bool _acceptAlt;
        private bool _resizableTop;
        private bool _resizableLeft;
        private bool _canResize = false;
        private PopupControlHost _ownerPopup;
        private PopupControlHost _childPopup;
        private Color _borderColor = Color.FromArgb(23, 169, 254);

        private bool _autoClose = false;
        private bool m_lockMouseDownState = false;//防止一直鼠标一直按着状态也导致窗体关闭
        private Timer m_timer_mouseposition = null;//监听鼠标是否在窗口外部点击
        #endregion
      
        #region Constructors
        public PopupControlHost(Control control)
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            AutoSize = false;
            base.AutoClose = false;
            Padding = Padding.Empty;
            Margin = Padding.Empty;
            base.SetStyle(ControlStyles.Selectable, false);
            CreateHost(control);

            this.BubbleControlMouseEvents(control);

            //监听鼠标是否点击窗体外部
            this.AutoClose = true;   
        }

        /// <summary>
        /// 冒泡控件的事件都指向PopupControlHost的事件
        /// </summary>
        /// <param name="control"></param>
        private void BubbleControlMouseEvents(Control control)
        {
            if (control == null ) return;
            control.MouseDown += (s, e) => { this.OnMouseDown(e); };
            control.MouseUp += (s, e) => { this.OnMouseUp(e); };
            if (control.HasChildren)
            {
                foreach (Control ctr in control.Controls)
                {
                    this.BubbleControlMouseEvents(ctr);
                }
            }
        }

        void Timer_MousePosition_Tick(object sender, EventArgs e)
        {
            Point mousePosistion = Control.MousePosition;
            //鼠标点击窗体外时关闭窗体
            if (this.Visible
                && !this.Bounds.Contains(mousePosistion)
                && Control.MouseButtons == System.Windows.Forms.MouseButtons.Left
                && !m_lockMouseDownState)
            {
                if ((this.IngoreControl == null || !this.IngoreControl.RectangleToScreen(this.IngoreControl.ClientRectangle).Contains(mousePosistion)))

                Close();
            }
        }
        
        #endregion

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= (int)WindowExStyles.WS_EX_NOACTIVATE;
                return cp;
            }
        }

        #region Properties
    

        public bool ChangeRegion
        {
            get { return _changeRegion; }
            set { _changeRegion = value; }
        }

        public bool OpenFocused
        {
            get { return _openFocused; }
            set { _openFocused = value; }
        }

        public bool AcceptAlt
        {
            get { return _acceptAlt; }
            set { _acceptAlt = value; }
        }

        public bool CanResize
        {
            get { return _canResize; }
            set { _canResize = value; }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }
        /// <summary>
        /// 是否自动关闭窗口
        /// </summary>
        public new bool AutoClose
        {
            get 
            { 
                return _autoClose; }
            set 
            {
                _autoClose = value;
                if (this.IsDesignMode()) return;
                if (value)
                {
                    if (m_timer_mouseposition != null && m_timer_mouseposition.Enabled) return;
                    if (m_timer_mouseposition == null)
                    {
                        m_timer_mouseposition = new Timer();
                        m_timer_mouseposition.Interval = 100;
                        m_timer_mouseposition.Tick += Timer_MousePosition_Tick;
                    }
                    m_timer_mouseposition.Enabled = true;
                }
                else
                {
                    if (m_timer_mouseposition != null && m_timer_mouseposition.Enabled)
                    {
                        m_timer_mouseposition.Enabled = false;
                        m_timer_mouseposition.Dispose();
                        m_timer_mouseposition = null;
                    }
                }
            }
        }

        #endregion
   
        #region Protected Methods
        protected override void OnMouseDown(MouseEventArgs mea)
        {
            if (mea.Button == System.Windows.Forms.MouseButtons.Left)
                m_lockMouseDownState = true;
        }

        protected override void OnMouseUp(MouseEventArgs mea)
        {
            base.OnMouseUp(mea);
            m_lockMouseDownState = false;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (_acceptAlt && ((keyData & Keys.Alt) == Keys.Alt))
            {
                if ((keyData & Keys.F4) != Keys.F4)
                {
                    return false;
                }
                else
                {
                    Close();
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        protected override void OnOpening(CancelEventArgs e)
        {
            if (_targetControl.IsDisposed || _targetControl.Disposing)
            {
                e.Cancel = true;
                base.OnOpening(e);
                return;
            }
            _targetControl.RegionChanged += new EventHandler(PopupControlRegionChanged);
            UpdateRegion();
            base.OnOpening(e);
        }

        protected override void OnOpened(EventArgs e)
        {
            if (_openFocused)
            {
                _targetControl.Focus();
            }
            base.OnOpened(e);
        }

        protected override void OnClosing(ToolStripDropDownClosingEventArgs e)
        {
            _targetControl.RegionChanged -= new EventHandler(PopupControlRegionChanged);
            base.OnClosing(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (_controlHost != null)
            {
                _controlHost.Size = new Size(
                    Width - Padding.Horizontal, Height - Padding.Vertical);
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, 
            Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            if (!ProcessGrip(ref m))
            {
                base.WndProc(ref m);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!_changeRegion)
            {
                ControlPaint.DrawBorder(
                    e.Graphics,
                    ClientRectangle,
                    _borderColor,
                    ButtonBorderStyle.Solid);
            }
        }

        protected void UpdateRegion()
        {
            if(!_changeRegion)
            {
                return;
            }

            if (base.Region != null)
            {
                base.Region.Dispose();
                base.Region = null;
            }
            if (_targetControl.Region != null)
            {
                base.Region = _targetControl.Region.Clone();
            }
        }

        #endregion

        #region Public Methods
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            if (_targetControl != null)
            {
                base.Size = new Size(
               _targetControl.Size.Width + Padding.Horizontal,
               _targetControl.Size.Height + Padding.Vertical);
            }
        }
        public void Show(Control control)
        {
            Show(control,new Rectangle(Point.Empty,new Size(control.Width,control.Height)));
        }

        public void Show(Control control, bool center)
        {
            Show(control, control.ClientRectangle, center);
        }

        public void Show(Control control, Rectangle rect)
        {
            Show(control, rect, false);
        }
        public void Show(Control control, PopupPosition position)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            SetOwnerItem(control);
            if (!_changeRegion)
            {
                Padding = new Padding(1);
            }
            else
            {
                Padding = Padding.Empty;
            }
            Point location = Point.Empty;
            switch (position)
            {
                case PopupPosition.Left:
                    location = new Point(-this.Width,0);
                    break;
                case PopupPosition.Right:
                    location = new Point(this.Width, 0);
                    break;
                case PopupPosition.Top:
                    location = new Point(0, -this.Height);
                    break;
                case PopupPosition.Bottom:
                    location = new Point(0, control.Height);
                    break;
                default:
                    break;
            }
            location.X -= Padding.Right + 2;
            location.Y -= Padding.Top ;
            this.Show(control,location);
        }
        public void Show(Control control, Rectangle rect, bool center)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            SetOwnerItem(control);

             if (!_changeRegion)
            {
                Padding = new Padding(1);
            }
            else
            {
                Padding = Padding.Empty;
            }

            int width = Padding.Horizontal;
            int height = Padding.Vertical;

            base.Size = new Size(
                   _targetControl.Width + width,
                   _targetControl.Height + height);

            _resizableTop = false;
            _resizableLeft = false;
            Point location = control.PointToScreen(
                new Point(rect.Left, rect.Bottom));
            Rectangle screen = Screen.FromControl(control).WorkingArea;
            if (center)
            {
                if (location.X + (rect.Width + Size.Width) / 2 > screen.Right)
                {
                    location.X = screen.Right - Size.Width;
                    _resizableLeft = true;
                }
                else
                {
                    location.X = location.X - (Size.Width - rect.Width) / 2;
                }
            }
            else
            {
                if (location.X + Size.Width > (screen.Left + screen.Width))
                {
                    _resizableLeft = true;
                    location.X = (screen.Left + screen.Width) - Size.Width;
                }
            }

            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                _resizableTop = true;
                location.Y -= Size.Height + rect.Height;
            }

            location = control.PointToClient(location);
            location.X -= Padding.Right;
            location.Y -= Padding.Top + 1;
            Show(control, location, ToolStripDropDownDirection.BelowRight);
        }

        #endregion

        #region Private Methods

        private void SetOwnerItem(Control control)
        {
            if (control == null)
            {
                return;
            }
            if (control is PopupControlHost)
            {
                PopupControlHost popupControl = control as PopupControlHost;
                _ownerPopup = popupControl;
                _ownerPopup._childPopup = this;
                OwnerItem = popupControl.Items[0];
                return;
            }
            if (control.Parent != null)
            {
                SetOwnerItem(control.Parent);
            }
        }

        private void CreateHost(Control control)
        {
            if (control == null)
            {
                throw new ArgumentException("control");
            }

            _targetControl = control;
            _controlHost = new ToolStripControlHost(control, "popupControlHost");
            _controlHost.AutoSize = false;
            _controlHost.Padding = Padding.Empty;
            _controlHost.Margin = Padding.Empty;
            base.Size = new Size(
                control.Size.Width + Padding.Horizontal,
                control.Size.Height + Padding.Vertical);
            base.Items.Add(_controlHost);

            _targetControl.SizeChanged += _targetControl_SizeChanged;
        }

        void _targetControl_SizeChanged(object sender, EventArgs e)
        {
            base.Size = new Size(
                _targetControl.Size.Width + Padding.Horizontal,
                _targetControl.Size.Height + Padding.Vertical);
        }
        private void PopupControlRegionChanged(object sender, EventArgs e)
        {
            UpdateRegion();
        }
        [SecurityPermission(SecurityAction.LinkDemand,
           Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool ProcessGrip(ref Message m)
        {
            if (_canResize && !_changeRegion)
            {
                switch (m.Msg)
                {
                    case (int)WinMsg.WM_NCHITTEST:
                        return OnNcHitTest(ref m);
                    case (int)WinMsg.WM_GETMINMAXINFO:
                        return OnGetMinMaxInfo(ref m);
                }
            }
            return false;
        }

        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool OnGetMinMaxInfo(ref Message m)
        {
            Control hostedControl = _targetControl;
            if (hostedControl != null)
            {
                MINMAXINFO minmax =
                    (MINMAXINFO)Marshal.PtrToStructure(
                    m.LParam, typeof(MINMAXINFO));

                if (hostedControl.MaximumSize.Width != 0)
                {
                    minmax.maxTrackSize.Width = hostedControl.MaximumSize.Width;
                }
                if (hostedControl.MaximumSize.Height != 0)
                {
                    minmax.maxTrackSize.Height = hostedControl.MaximumSize.Height;
                }

                minmax.minTrackSize = new Size(100, 100);
                if (hostedControl.MinimumSize.Width > minmax.minTrackSize.Width)
                {
                    minmax.minTrackSize.Width = 
                        hostedControl.MinimumSize.Width + Padding.Horizontal;
                }
                if (hostedControl.MinimumSize.Height > minmax.minTrackSize.Height)
                {
                    minmax.minTrackSize.Height = 
                        hostedControl.MinimumSize.Height + Padding.Vertical;
                }

                Marshal.StructureToPtr(minmax, m.LParam, false);
            }
            return true;
        }

        private bool OnNcHitTest(ref Message m)
        {
            Point location = PointToClient(new Point(
                UnsafeNativeMethods.LOW_ORDER((int)m.LParam), UnsafeNativeMethods.HIGH_ORDER((int)m.LParam)));
            Rectangle gripRect = Rectangle.Empty;
            if (_canResize && !_changeRegion)
            {
                if (_resizableLeft)
                {
                    if (_resizableTop)
                    {
                        gripRect = new Rectangle(0, 0, 6, 6);
                    }
                    else
                    {
                        gripRect = new Rectangle(
                            0,
                            Height - 6,
                            6,
                            6);
                    }
                }
                else
                {
                    if (_resizableTop)
                    {
                        gripRect = new Rectangle(Width - 6, 0, 6, 6);
                    }
                    else
                    {
                        gripRect = new Rectangle(
                            Width - 6,
                            Height - 6,
                            6,
                            6);
                    }
                }
            }

            if (gripRect.Contains(location))
            {
                if (_resizableLeft)
                {
                    if (_resizableTop)
                    {
                        m.Result = new IntPtr((int)HitTest.HTTOPLEFT);
                        return true;
                    }
                    else
                    {
                        m.Result = new IntPtr((int)HitTest.HTBOTTOMLEFT);
                        return true;
                    }
                }
                else
                {
                    if (_resizableTop)
                    {
                        m.Result = new IntPtr((int)HitTest.HTTOPRIGHT);
                        return true;
                    }
                    else
                    {
                        m.Result = new IntPtr((int)HitTest.HTBOTTOMRIGHT);
                        return true;
                    }
                }
            }
            else
            {
                Rectangle rectClient = ClientRectangle;
                if (location.X > rectClient.Right - 3 &&
                    location.X <= rectClient.Right &&
                    !_resizableLeft)
                {
                    m.Result = new IntPtr((int)HitTest.HTRIGHT);
                    return true;
                }
                else if (location.Y > rectClient.Bottom - 3 &&
                    location.Y <= rectClient.Bottom &&
                    !_resizableTop)
                {
                    m.Result = new IntPtr((int)HitTest.HTBOTTOM);
                    return true;
                }
                else if (location.X > -1 &&
                    location.X < 3 &&
                    _resizableLeft)
                {
                    m.Result = new IntPtr((int)HitTest.HTLEFT);
                    return true;
                }
                else if (location.Y > -1 &&
                    location.Y < 3 &&
                    _resizableTop)
                {
                    m.Result = new IntPtr((int)HitTest.HTTOP);
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}