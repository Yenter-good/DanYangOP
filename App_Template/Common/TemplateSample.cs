using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.AdvTree;

namespace App_Template.Common
{
    public partial class TemplateSample : UserControl
    {
        public TemplateSample()
        {
            InitializeComponent();
        }

        public event TreeNodeMouseEventHandler NodeMouseDown;
        public event TreeNodeMouseEventHandler NodeDragStart;
        public event TreeNodeMouseEventHandler NodeMouseUp;
        public event TreeNodeMouseEventHandler NodeDoubleClick;
        public event TreeNodeMouseEventHandler NodeClick;
        public event CellEditEventHandler AfterEdit;
        public event TreeDragDropEventHandler BeforeDrop;

        public AdvTree Tree
        { get { return this.advTree1; } private set { } }

        public ContextMenu ContextMenu
        { get; set; }

        /// <summary>
        /// 初始化范文
        /// </summary>
        public void InitSample()
        {
            this.advTree1.Nodes[0].Nodes.Clear();
            this.advTree1.Nodes[1].Nodes.Clear();
            List<CIS.Utility.TreeModel1> list = new List<CIS.Utility.TreeModel1>();
            List<OP_TemplateSample> PersonTemplate = DBHelper.CIS.From<OP_TemplateSample>().Where(p => p.UserID == CIS.Core.SysContext.CurrUser.user.Code && p.DeptCode == "").ToList();
            List<OP_TemplateSample> OfficeTemplate = DBHelper.CIS.From<OP_TemplateSample>().Where(p => p.DeptCode == CIS.Core.SysContext.RunSysInfo.currDept.Code && p.UserID == "").ToList();
            foreach (OP_TemplateSample item in PersonTemplate)
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.SampleName.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType ?? 0, Sort = item.Index.AsInt(9999) });
            CIS.Utility.TreeHelper.CreateChildsNode(this.advTree1.Nodes[1].Nodes, "", list, false, this.imageList1, true);

            list.Clear();

            foreach (OP_TemplateSample item in OfficeTemplate)
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.SampleName.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType ?? 0, Sort = item.Index.AsInt(9999) });
            CIS.Utility.TreeHelper.CreateChildsNode(this.advTree1.Nodes[0].Nodes, "", list, false, this.imageList1, true);

            this.advTree1.ExpandAll();
        }

        private void advTree1_NodeMouseDown(object sender, TreeNodeMouseEventArgs e)
        {
            if (this.NodeMouseDown == null) return;
            this.NodeMouseDown(sender, e);
        }

        private void advTree1_NodeMouseUp(object sender, TreeNodeMouseEventArgs e)
        {
            if (this.NodeMouseUp == null) return;
            this.NodeMouseUp(sender, e);
        }

        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (this.NodeDoubleClick == null) return;
            this.NodeDoubleClick(sender, e);
        }

        private void advTree1_NodeDragStart(object sender, EventArgs e)
        {
            if (this.NodeDragStart == null) return;
            this.NodeDragStart(sender, new TreeNodeMouseEventArgs(this.advTree1.SelectedNode, MouseButtons.Left, 1, 1, 0, 0));
        }

        public void DeleteTemplateSample()
        {
            Node node = this.advTree1.SelectedNode;
            if (node.Tag != null)
            {
                OP_TemplateSample tmp = node.Tag as OP_TemplateSample;
                string ID = tmp.ID;
                DBHelper.CIS.Delete<OP_TemplateSample>(p => p.ID == ID);
                node.Parent.Nodes.Remove(node);
                CIS.Core.AlertBox.Info("删除成功");
            }
        }

        private void advTree1_AfterCellEdit(object sender, CellEditEventArgs e)
        {
            if (this.AfterEdit == null) return;
            this.AfterEdit(sender, e);
        }

        /// <summary>
        /// 增加一个组
        /// </summary>
        public void AddFolder()
        {
            Node SelectNode = this.advTree1.SelectedNode;
            Node newNode = new Node("新组");
            OP_TemplateSample tmp = new OP_TemplateSample();
            tmp.ID = Guid.NewGuid().ToString();
            tmp.SampleName = "新组";
            tmp.NodeType = 0;
            if (SelectNode == null)
            {
                CIS.Core.AlertBox.Info("未选中任何节点,无法添加组");
                return;
            }
            if (SelectNode.Tag == null)
            {
                SelectNode.Nodes.Add(newNode);
                tmp.ParentID = "";
                if (SelectNode.Index == 0)
                {
                    tmp.DeptCode = CIS.Core.SysContext.RunSysInfo.currDept.Code;
                    tmp.UserID = "";
                }
                else
                {
                    tmp.UserID = CIS.Core.SysContext.CurrUser.user.Code;
                    tmp.DeptCode = "";
                }

            }
            else
            {
                OP_TemplateSample selectNode = SelectNode.Tag as OP_TemplateSample;
                if (selectNode.NodeType == 1)
                {
                    SelectNode.Parent.Nodes.Add(newNode);
                    tmp.ParentID = selectNode.ParentID;
                }
                else
                {
                    SelectNode.Nodes.Add(newNode);
                    tmp.ParentID = selectNode.ID;
                }
                tmp.DeptCode = selectNode.DeptCode;
                tmp.UserID = selectNode.UserID;
            }
            this.advTree1.SelectedNode = newNode;
            newNode.BeginEdit();
            newNode.Image = this.imageList1.Images[0];
            newNode.Tag = tmp;
            DBHelper.CIS.Insert<OP_TemplateSample>(tmp);
        }

        /// <summary>
        /// 增加一个模板
        /// </summary>
        public void AddTemplate()
        {
            OP_TemplateSample sample = new OP_TemplateSample();
            Node SelectNode = this.advTree1.SelectedNode;
            Node newNode = new Node("新模板");
            OP_TemplateSample tmp = new OP_TemplateSample();
            tmp.ID = Guid.NewGuid().ToString();
            tmp.SampleName = "新模板";
            tmp.NodeType = 1;
            if (SelectNode == null)
            {
                CIS.Core.AlertBox.Info("未选中任何节点,无法添加模板");
                return;
            }
            if (SelectNode.Tag == null)
            {
                SelectNode.Nodes.Add(newNode);
                tmp.ParentID = "";
                if (SelectNode.Index == 0)
                {
                    tmp.DeptCode = CIS.Core.SysContext.RunSysInfo.currDept.Code;
                    tmp.UserID = "";
                }
                else
                {
                    tmp.UserID = CIS.Core.SysContext.CurrUser.user.Code;
                    tmp.DeptCode = "";
                }

            }
            else
            {
                OP_TemplateSample selectNode = SelectNode.Tag as OP_TemplateSample;
                if (selectNode.NodeType == 1)
                {
                    SelectNode.Parent.Nodes.Add(newNode);
                    tmp.ParentID = selectNode.ParentID;
                }
                else
                {
                    SelectNode.Nodes.Add(newNode);
                    tmp.ParentID = selectNode.ID;
                }
                tmp.DeptCode = selectNode.DeptCode;
                tmp.UserID = selectNode.UserID;
            }
            this.advTree1.SelectedNode = newNode;
            newNode.BeginEdit();
            newNode.Image = this.imageList1.Images[1];
            newNode.Tag = tmp;
            DBHelper.CIS.Insert<OP_TemplateSample>(tmp);
        }



        private void advTree1_BeforeNodeDrop(object sender, TreeDragDropEventArgs e)
        {

            if (this.BeforeDrop == null) return;
            this.BeforeDrop(sender, e);
        }

        private void advTree1_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (this.NodeClick == null) return;
            this.NodeClick(sender, e);
        }

        private void advTree1_AfterNodeDrop(object sender, TreeDragDropEventArgs e)
        {
            Node parent = e.NewParentNode;
            for (int i = 0; i < parent.Nodes.Count; i++)
            {
                OP_TemplateSample sample = parent.Nodes[i].Tag as OP_TemplateSample;
                sample.Index = i;
                DBHelper.CIS.Update<OP_TemplateSample>(sample);
            }
        }
    }
}
