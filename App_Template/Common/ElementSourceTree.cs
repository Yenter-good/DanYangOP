using System.Windows.Forms;
using DCSoft.Writer.Dom;

namespace App_Template.Common
{
    public partial class ElementSourceTree : UserControl
    {
        public ElementSourceTree()
        {
            InitializeComponent();
        }

        public XTextElement CreateElement()
        {

            return new XTextInputFieldElement();
        }
    }
}
