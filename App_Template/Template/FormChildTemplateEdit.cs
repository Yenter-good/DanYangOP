using System;
using System.Collections.Generic;
using CIS.Model;

namespace App_Template
{
    public partial class FormChildTemplateEdit : CIS.Core.BaseForm
    {
        public FormChildTemplateEdit()
        {
            InitializeComponent();
        }

        public OP_SubTemplate SelectNode = new OP_SubTemplate();
        public List<OP_SubTemplate> list = new List<OP_SubTemplate>();
        public OP_SubTemplate ParentNode = new OP_SubTemplate();
        public string NewName;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormChildTemplateEdit_Shown(object sender, EventArgs e)
        {
            this.textBox1.Text = SelectNode.Name;
            list = DBHelper.CIS.From<OP_SubTemplate>().Where(p => p.NodeType == 0).ToList();
            OP_SubTemplate temp = new OP_SubTemplate();
            temp.ID = "";
            temp.ParentID = "1";
            temp.Name = "门诊子模板";
            list.Insert(0, temp);

            List<CIS.Utility.TreeModel1> list1 = new List<CIS.Utility.TreeModel1>();
            foreach (OP_SubTemplate item in list)
            {
                list1.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.ID.Trim() });
            }
            CIS.Utility.TreeHelper.CreateChildsNode(this.comboTree1.AdvTree.Nodes, "1", list1, false);
            this.comboTree1.AdvTree.ExpandAll();
            DevComponents.AdvTree.Node[] pNode = this.comboTree1.AdvTree.Nodes.Find(SelectNode.ParentID, true);
            if (pNode.Length != 0)
                this.comboTree1.AdvTree.SelectedNode = pNode[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OP_SubTemplate node = this.comboTree1.AdvTree.SelectedNode.Tag as OP_SubTemplate;
            SelectNode.Name = this.textBox1.Text;
            SelectNode.ParentID = node.ID.ToString();
            NewName = this.textBox1.Text;
            ParentNode = node;
            DBHelper.CIS.Update<OP_SubTemplate>(SelectNode, p => p.ID == SelectNode.ID);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
