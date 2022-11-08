using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIS.ControlLib.Controls
{
    public class ColorTextBox : System.Windows.Forms.TextBox
    {
        public ColorTextBox()
        {
            base.GotFocus += ColorTextBox_GotFocus;
            base.LostFocus += ColorTextBox_LostFocus;
        }

        private void ColorTextBox_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
        }

        private void ColorTextBox_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(128, 255, 255);
        }
    }
}
