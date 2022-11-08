using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace CIS.ControlLib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetControlStyleMethod = typeof(Button).GetMethod("SetStyle",
BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod);
            SetChildControlNoFocus(this);
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.Selectable, false);
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowIcon = false;
        }

        #region 设置窗口不允许有焦点
        private const int WM_MOUSEACTIVATE = 0x21;
        private const int MA_NOACTIVATE = 3;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = new IntPtr(MA_NOACTIVATE); return;
            } base.WndProc(ref m);
        }
        protected override bool ShowWithoutActivation { get { return false; } }

        void SetChildControlNoFocus(Control ctrl)
        {
            if (ctrl.HasChildren)
                foreach (Control c in ctrl.Controls) { SetControlNoFocus(c); }
        }
        MethodInfo SetControlStyleMethod;
        object[] SetControlStyleArgs = new object[] { ControlStyles.Selectable, false };
        private void SetControlNoFocus(Control ctrl)
        {
            SetControlStyleMethod.Invoke(ctrl, SetControlStyleArgs);
            SetChildControlNoFocus(ctrl);
        }
        #endregion

        Point MouseDownPoint;

        private void picSwitchType_MouseUp(object sender, MouseEventArgs e)
        {
            int index = e.X / 85;
            if (index == 0)
                this.picSwitchType.Image = Properties.Resources._2;
            else if (index == 1)
                this.picSwitchType.Image = Properties.Resources._3;
            else
                this.picSwitchType.Image = Properties.Resources._4;
        }

        #region 移动窗体
        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownPoint = MousePosition;
        }

        private void pnlTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left += MousePosition.X - MouseDownPoint.X;
                this.Top += MousePosition.Y - MouseDownPoint.Y;
                MouseDownPoint = MousePosition;
            }
        }
        #endregion

        private void picCancel_MouseEnter(object sender, EventArgs e)
        {

        }

    }
}
