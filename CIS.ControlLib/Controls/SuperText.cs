using DevComponents.DotNetBar.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIS.ControlLib.Controls
{
    public class SuperText : TextBoxX
    {
        Timer T = new Timer();
        int DelayIndex = 0;
        bool draw;
        SolidBrush brush = new SolidBrush(Color.FromArgb(200, Color.Gray));

        public SuperText()
        {
            T.Interval = 20;
            T.Tick += T_Tick;
        }

        void T_Tick(object sender, EventArgs e)
        {
            if (DelayIndex > DelayTime / 20)
            {
                T.Enabled = false;
                base.OnTextChanged(new EventArgs());
            }
            DelayIndex += 1;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            DelayIndex = 0;
            if (DelayTime == 0)
            {
                base.OnTextChanged(new EventArgs());
                return;
            }
            T.Enabled = true;
        }

        [Description("获取或设置此文本框延时触发文本改变的时间"), Category("自定义属性"), DefaultValue(0)]
        public int DelayTime
        { get; set; }

        string _MarkString;
        [Description("获取或设置此文本框显示的水印内容"), Category("自定义属性"), DefaultValue("")]
        public string MarkString
        { get { return _MarkString; } set { _MarkString = value; draw = true; this.Invalidate(); } }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            const int WM_PAINT = 15;
            if (m.Msg == WM_PAINT)
            {
                PaintEventArgs e = new PaintEventArgs(Graphics.FromHwnd(this.Handle), this.Bounds);
                this.OnPaint(e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (draw)
            {
                if (this.Text == "" && _MarkString != "")
                {
                    e.Graphics.DrawString(_MarkString, this.Font, brush, new Point(1, 1));
                }
                else
                    if (this.Text == "" && _MarkString != "")
                    {
                        e.Graphics.Clear(this.BackColor);
                    }
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            draw = false;
            this.Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            draw = true;
            this.Invalidate();
            base.OnLeave(e);
        }
    }
}
