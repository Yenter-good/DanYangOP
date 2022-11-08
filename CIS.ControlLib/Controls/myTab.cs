using System.Windows.Forms;

namespace CIS.ControlLib.Controls
{
    public partial class myTab : UserControl
    {
        public myTab()
        {
            InitializeComponent();
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl2.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl3.PrimaryGrid.AutoGenerateColumns = false;
        }

        public object XYDataSource
        { get { return this.superGridControl1.PrimaryGrid.DataSource; } set { this.superGridControl1.PrimaryGrid.DataSource = value; } }

        public object CYDataSource
        { get { return this.superGridControl2.PrimaryGrid.DataSource; } set { this.superGridControl2.PrimaryGrid.DataSource = value; } }

        public object ZLDataSource
        { get { return this.superGridControl3.PrimaryGrid.DataSource; } set { this.superGridControl3.PrimaryGrid.DataSource = value; } }
    }
}
