using System.Reflection;
using System.Windows.Forms;

namespace CIS.ControlLib.Helper
{
    class ControlHelper
    {
        private static MethodInfo setControlStyleMethod;
        private static object[] setControlStyleArgs = new object[] { ControlStyles.Selectable, false };

        public static void SetControlNoFocus(Control ctrl)
        {
            if (setControlStyleMethod==null)
                setControlStyleMethod = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.Instance);

            setControlStyleMethod.Invoke(ctrl, setControlStyleArgs);
            SetChildControlNoFocus(ctrl);

        }
        private static void SetChildControlNoFocus(Control ctrl)
        {
            if (ctrl.HasChildren)
                foreach (Control c in ctrl.Controls)
                {
                    SetControlNoFocus(c);
                }
        }
      
    }

}
