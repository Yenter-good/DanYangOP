using System.Windows.Forms;

namespace CIS.Core
{
    public class FormCancelUnenabled : BaseForm
    {
        protected override CreateParams CreateParams
        {
            get
            {
                int CS_NOCLOSE = 0x200;
                CreateParams parameters = base.CreateParams;
                parameters.ClassStyle |= CS_NOCLOSE;
                return parameters;
            }
        }
    }
}
