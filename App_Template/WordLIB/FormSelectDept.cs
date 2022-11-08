using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.AdvTree;

namespace App_Template.WordLIB
{
    public partial class FormSelectDept : Form
    {
        public FormSelectDept()
        {
            InitializeComponent();
        }

        public List<string> DeptCode = new List<string>();

        private void FormSelectDept_Shown(object sender, EventArgs e)
        {
            List<IView_Dept> dept = CIS.Core.SysContext.CurrUser.deptList;
            foreach (IView_Dept item in dept)
            {
                Node node = new Node(item.Name);
                node.Tag = item;
                node.CheckBoxVisible = true;
                this.advTree1.Nodes.Add(node);
            }
        }
    }
}
