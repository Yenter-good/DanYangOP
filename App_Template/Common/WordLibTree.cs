using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Model;
using CIS.Utility;
using DevComponents.AdvTree;

namespace App_Template
{
    public partial class WordLibTree : UserControl
    {
        public WordLibTree()
        {
            InitializeComponent();
        }

        public event TreeNodeMouseEventHandler NodeMouseDown;
        public event TreeNodeMouseEventHandler NodeDoubleClick;
        public event TreeNodeMouseEventHandler NodeDragStart;
        public AdvTree Tree
        { get { return this.advTree1; } private set { } }

        public void InitTree()
        {
            this.nodePerson.Nodes.Clear();
            List<TP_WordLIB> person = DBHelper.CIS.From<TP_WordLIB>().ToList();

            List<TreeModel1> list = new List<TreeModel1>();
            foreach (TP_WordLIB item in person)
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType ?? 0, Sort = item.No ?? 0 });
            CIS.Utility.TreeHelper.CreateChildsNode(nodePerson.Nodes, "", list, false, this.imageList1, true);
            list.Clear();
            this.advTree1.ExpandAll();
        }

        private void advTree1_NodeMouseDown(object sender, TreeNodeMouseEventArgs e)
        {
            if (NodeMouseDown != null)
                NodeMouseDown(sender, e);
        }

        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (NodeDoubleClick != null)
                NodeDoubleClick(sender, e);
        }

        private void advTree1_NodeDragStart(object sender, EventArgs e)
        {
            if (this.NodeDragStart == null) return;
            this.NodeDragStart(sender, new TreeNodeMouseEventArgs(this.advTree1.SelectedNode, MouseButtons.Left, 1, 1, 0, 0));
        }

        private void advTree1_AfterNodeDrop(object sender, TreeDragDropEventArgs e)
        {
          
        }

        private void advTree1_BeforeNodeDrop(object sender, TreeDragDropEventArgs e)
        {

        }

    }
}
