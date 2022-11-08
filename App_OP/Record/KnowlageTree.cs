using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.AdvTree;
using CIS.Utility;
using CIS.Core;

namespace App_OP
{
    public partial class KnowlageTree : UserControl
    {
        public KnowlageTree()
        {
            InitializeComponent();
        }

        public void InitData()
        {
            nodeAll.Nodes.Clear();
            nodePerson.Nodes.Clear();
            List<TP_WordLIB> wordLIB = DBHelper.CIS.From<TP_WordLIB>().ToList();
            List<TP_WordLIB> personLIB = DBHelper.CIS.FromSql(string.Format("SELECT  B.* FROM TP_WORDLIB_USER A LEFT JOIN TP_WORDLIB B ON A.WORDLIBCODE=B.ID WHERE A.USERCODE='{0}'", SysContext.CurrUser.user.Code)).ToList<TP_WordLIB>();
            List<TreeModel1> list = new List<TreeModel1>();
            foreach (TP_WordLIB item in wordLIB)
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType ?? 0, Sort = item.No ?? 0 });
            CIS.Utility.TreeHelper.CreateChildsNode(nodeAll.Nodes, "", list, false, this.imageList1, true);
            list.Clear();

            foreach (TP_WordLIB item in personLIB)
            {
                Node node = new Node(item.Name);
                node.Image = imageList1.Images[1];
                node.Tag = item;
                nodePerson.Nodes.Add(node);
            }
            this.advTree1.ExpandAll();
        }

        private void 添加到我的词库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node node = this.advTree1.SelectedNode;
            if (node == null || node.Parent == null || node.Parent == nodePerson || node.Tag == null) return;
            TP_WordLIB_User tmp = new TP_WordLIB_User();
            tmp.ID = Guid.NewGuid().ToString();
            tmp.UserCode = SysContext.CurrUser.user.Code;
            tmp.WordLIBCode = (node.Tag as TP_WordLIB).ID;
            DBHelper.CIS.Insert<TP_WordLIB_User>(tmp);

            Node node1 = new Node(node.Text);
            node1.Tag = node.Tag;
            node1.Image = imageList1.Images[1];
            nodePerson.Nodes.Add(node1);
            AlertBox.Info("保存成功");
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitData();
        }

        private void 从我的词库删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node node = this.advTree1.SelectedNode;
            if (node == null || node.Tag == null || node.Parent != nodePerson) return;
            if (node.Parent != null && node.Parent == nodePerson)
            {
                TP_WordLIB tmp = node.Tag as TP_WordLIB;
                DBHelper.CIS.Delete<TP_WordLIB_User>(p => p.WordLIBCode == tmp.ID && p.UserCode == SysContext.CurrUser.user.Code);
                node.Parent.Nodes.Remove(node);
                AlertBox.Info("删除成功");
            }
        }
    }
}
