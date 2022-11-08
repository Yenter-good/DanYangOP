using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.AdvTree;
using CIS.Utility;

namespace App_Template
{
    public partial class ElementTree : UserControl
    {
        public ElementTree()
        {
            InitializeComponent();
        }

        private List<TP_ElementLIB> ElementLIB = new List<TP_ElementLIB>();
        public event TreeNodeMouseEventHandler NodeMouseDown;
        public event TreeNodeMouseEventHandler NodeDoubleClick;

        public void DeleteSelectionNode()
        {
            TP_ElementLIB lib = new TP_ElementLIB();
            Node Select = this.advTree1.SelectedNode;
            if (Select == null) return;
            if (Select.Tag != null)
            {
                lib = Select.Tag as TP_ElementLIB;
                DBHelper.CIS.Delete<TP_ElementLIB>(p => p.ID == lib.ID);
                DBHelper.CIS.Delete<TP_ElementLIB>(p => p.ParentID == lib.ID);
            }
            if (Select.Parent == null)
                this.advTree1.Nodes.Remove(Select);
            else
                Select.Parent.Nodes.Remove(Select);
        }

        public void AddFolder()
        {
            Node node = new Node("新组");
            node.ImageIndex = 0;

            TP_ElementLIB lib = new TP_ElementLIB() { ID = Guid.NewGuid().ToString(), Name = "新组", NodeType = 0, SpellCode = "新组".GetSpell(), WubiCode = "新组".GetWBM(), UpdateTime = DateTime.Now, UpdatorID = CIS.Core.SysContext.CurrUser.user.ID };
            node.Tag = lib;
            DBHelper.CIS.Insert<TP_ElementLIB>(lib);
            Node Select = this.advTree1.SelectedNode;
            if (Select == null)
                this.advTree1.Nodes.Add(node);
            else if ((Select.Tag as TP_ElementLIB).NodeType == 0)
                Select.Nodes.Add(node);
            else
            {
                CIS.Core.AlertBox.Info("元素下无法创建内容");
                return;
            }
            if (!node.IsDisplayed)
                node.EnsureVisible();
        }

        public void AddElement()
        {
            Node node = new Node("新元素");
            node.ImageIndex = 1;
            TP_ElementLIB lib = new TP_ElementLIB() { ID = Guid.NewGuid().ToString(), Name = "新元素", NodeType = 1, SpellCode = "新元素".GetSpell(), WubiCode = "新元素".GetWBM() };
            node.Tag = lib;
            DBHelper.CIS.Insert<TP_ElementLIB>(lib);
            Node Select = this.advTree1.SelectedNode;
            if (Select != null && (Select.Tag as TP_ElementLIB).NodeType == 0)
                Select.Nodes.Add(node);
            else
            {
                CIS.Core.AlertBox.Info("请将元素添加到组内");
                return;
            }
            if (!node.IsDisplayed)
                node.EnsureVisible();
        }

        public void ShowTree()
        {
            ElementLIB = DBHelper.CIS.From<TP_ElementLIB>().ToList();
            InitTree();
        }

        private void InitTree()
        {
            this.advTree1.Nodes.Clear();
            List<TreeModel1> list = new List<TreeModel1>();
            foreach (TP_ElementLIB item in ElementLIB)
            {
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType, Sort = item.No ?? 0 });
            }
            CIS.Utility.TreeHelper.CreateChildsNode(this.advTree1.Nodes, "", list, false, this.imageList1, true);
            this.advTree1.ExpandAll();
        }

        private void advTree1_NodeMouseDown(object sender, TreeNodeMouseEventArgs e)
        {
            NodeMouseDown(sender, e);
        }

        public DevComponents.AdvTree.AdvTree Tree
        { get { return this.advTree1; } private set { } }

        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            NodeDoubleClick(sender, e);
        }
    }
}
