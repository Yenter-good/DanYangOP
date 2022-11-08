using System;
using System.Collections.Generic;
using CIS.Model;
using CIS.Utility;

namespace App_Template
{
    public partial class FormChildTemplateSaveAs : CIS.Core.BaseForm
    {
        public FormChildTemplateSaveAs()
        {
            InitializeComponent();
        }

        public string XML;
        public string Type;
        public string TypeName;

        private void buttonX1_Click(object sender, EventArgs e)
        {
            OP_SubTemplate lib = new OP_SubTemplate();
            lib.ID = Guid.NewGuid().ToString();
            lib.Name = this.textBoxX1.Text;
            lib.Content = XML;
            lib.NodeType = 1;
            lib.ParentID = (this.comboTree1.SelectedNode.Tag as OP_SubTemplate).ID;
            lib.SpellCode = this.textBoxX1.Text.GetSpell();
            lib.Tag = Type;
            lib.TagName = TypeName;
            lib.Status = 1;
            DBHelper.CIS.Insert<OP_SubTemplate>(lib);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public void InitTree()
        {
            List<OP_SubTemplate> template = DBHelper.CIS.From<OP_SubTemplate>().Where(p => p.NodeType == 0).ToList();
            List<TreeModel1> list = new List<TreeModel1>();
            foreach (OP_SubTemplate item in template)
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.ID.Trim() });
            CIS.Utility.TreeHelper.CreateChildsNode(this.comboTree1.Nodes, "", list, false, null, false);
            this.comboTree1.AdvTree.ExpandAll();
            this.comboTree1.SelectedIndex = 0;
        }
    }
}
