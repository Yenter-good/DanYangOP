using DevComponents.DotNetBar.SuperGrid;

namespace CIS.ControlLib.Controls
{
    public class MyComboBox : GridComboBoxExEditControl
    {
        public MyComboBox(object Source, string DisplayMember, string ValueMember)
        {
            this.DisplayMember = DisplayMember;
            this.ValueMember = ValueMember;
            this.DataSource = Source;
            this.DropDownStyle =  System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

    }
}
