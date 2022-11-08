using System;
using System.Windows.Forms;

namespace CIS
{
    public partial class Entrance : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public Entrance()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SystemManager_Click(object sender, EventArgs e)
        {
        }

        private void Entrance_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //this.Left = MousePosition.X - e.X;
                //this.Top = MousePosition.Y - e.Y;
            }
        }
    }
}