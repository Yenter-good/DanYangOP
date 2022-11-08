using System.Collections.Generic;
using System.Data;
using System.Linq;
using CIS.Model;

namespace App_Template
{
    public partial class FormInsertListFromDocument : CIS.Core.BaseForm
    {
        public FormInsertListFromDocument()
        {
            InitializeComponent();
        }

        public List<OP_Dic_TemplateNode> templateNode = new List<OP_Dic_TemplateNode>();

        private void Process()
        {
            string[] str = this.textBoxX4.Text.Split('\n');
            foreach (var item in str)
            {
                string TypeName = item.Substring(0, item.IndexOf('：'));
                string Type = templateNode.Where(p => p.Name == TypeName).First().Code;
            }
        }
    }
}
