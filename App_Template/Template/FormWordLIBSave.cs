using System;
using System.Collections.Generic;
using CIS.Model;
using CIS.Utility;

namespace App_Template
{
    public partial class FormWordLIBSave : CIS.Core.BaseForm
    {
        public FormWordLIBSave()
        {
            InitializeComponent();
        }

        public string XML;

        private void FormWordLIBSave_Shown(object sender, EventArgs e)
        {
            InitTree();
        }

        private void InitTree()
        {
            List<TP_WordLIB> person = DBHelper.CIS.From<TP_WordLIB>().Where(p => p.NodeType == 0).ToList();
            List<TreeModel1> list = new List<TreeModel1>();
            foreach (TP_WordLIB item in person)
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType ?? 0, Sort = item.No ?? 0 });
            CIS.Utility.TreeHelper.CreateChildsNode(this.comboTree1.Nodes, "", list, false, null, false);
            list.Clear();
            this.comboTree1.AdvTree.ExpandAll();
            this.comboTree1.SelectedIndex = 0;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            TP_WordLIB lib = new TP_WordLIB();
            lib.ID = Guid.NewGuid().ToString();
            lib.Name = this.textBoxX1.Text;
            lib.Content = XML;
            lib.NodeType = 1;
            lib.ParentID = (this.comboTree1.SelectedNode.Tag as TP_WordLIB).ID;
            lib.SpellCode = this.textBoxX1.Text.GetSpell();
            lib.Status = 1;
            DBHelper.CIS.Insert<TP_WordLIB>(lib);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

    }
}
