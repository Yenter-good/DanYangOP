using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevComponents.AdvTree;
using CIS.Model;
using CIS.Core;

namespace App_Template.Common
{
    public partial class ChildTemplateTree : UserControl
    {
        public ChildTemplateTree()
        {
            InitializeComponent();
        }

        public event CellEditEventHandler AfterCellEdit;
        public event TreeNodeMouseEventHandler NodeMouseDown;
        public event TreeNodeMouseEventHandler NodeDragStart;
        public event TreeNodeMouseEventHandler NodeMouseUp;
        public event TreeNodeMouseEventHandler NodeDoubleClick;
        List<OP_SubTemplate> template = new List<OP_SubTemplate>();

        public AdvTree Tree
        { get { return this.advTree1; } private set { } }

        /// <summary>
        /// 增加一个新组
        /// </summary>
        public void AddFolder()
        {
            Node node = new Node("新组");
            node.Image = this.imageList1.Images[0];

            OP_SubTemplate lib = new OP_SubTemplate() { ID = Guid.NewGuid().ToString(), Name = "新组", NodeType = 0, SpellCode = "新组".GetSpell(), WubiCode = "新组".GetWBM() };
            Node Select = this.advTree1.SelectedNode;
            this.advTree1.SelectedNode = null;

            if (Select == null || Select.Tag == null)
            {
                this.advTree1.Nodes[0].Nodes.Add(node);
                lib.ParentID = "";
            }
            else if ((Select.Tag as OP_SubTemplate).NodeType == 0)
            {
                Select.Nodes.Add(node);
                lib.ParentID = (Select.Tag as OP_SubTemplate).ID;
            }
            else
            {
                AlertBox.Info("元素下无法创建内容");
                return;
            }
            node.Tag = lib;
            DBHelper.CIS.Insert<OP_SubTemplate>(lib);
            if (!node.IsDisplayed)
                node.EnsureVisible();
            node.BeginEdit();
        }

        /// <summary>
        /// 添加模板
        /// </summary>
        public void AddTemplate()
        {
            Node node = this.advTree1.SelectedNode;
            this.advTree1.SelectedNode = null;
            //this.templateDesignControl1.XMLText = "";
            if (node == null || node.Tag == null) return;
            Node newNode = new Node("请输入模板名称");
            newNode.Image = this.imageList1.Images[1];
            OP_SubTemplate tmp = new OP_SubTemplate() { ID = Guid.NewGuid().ToString(), Name = "新模板", NodeType = 1, SpellCode = "新模板".GetSpell(), WubiCode = "新模板".GetWBM(), ParentID = (node.Tag as OP_SubTemplate).ID }; ;
            newNode.Tag = tmp;
            if ((node.Tag as OP_SubTemplate).NodeType == 1)
                node.Parent.Nodes.Add(newNode);
            else if ((node.Tag as OP_SubTemplate).NodeType == 0)
                node.Nodes.Add(newNode);
            else
            {
                AlertBox.Info("请在组下添加模板");
                return;
            }
            DBHelper.CIS.Insert<OP_SubTemplate>(tmp);
            this.advTree1.SelectedNode = newNode;
            newNode.BeginEdit();
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        public void DeleteTemplate()
        {
            Node node = this.advTree1.SelectedNode;
            if (node == null) return;
            if (node.Tag.GetType() == typeof(OP_SubTemplate))
            {
                string ID = (node.Tag as OP_SubTemplate).ID;
                DBHelper.CIS.Delete<OP_SubTemplate>(p => p.ID == ID);
                node.Parent.Nodes.Remove(node);
            }
        }

        /// <summary>
        /// 初始化子模板
        /// </summary>
        public void InitTemplate()
        {
            this.advTree1.Nodes[0].Nodes.Clear();
            List<CIS.Utility.TreeModel1> list = new List<CIS.Utility.TreeModel1>();
            template = DBHelper.CIS.From<OP_SubTemplate>().Where(p => p.DTLimit == SysContext.RunSysInfo.currDept.Code).ToList();
            foreach (OP_SubTemplate item in template)
            {
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = (int)item.NodeType });
            }
            CIS.Utility.TreeHelper.CreateChildsNode(this.advTree1.Nodes[0].Nodes, "", list, false, this.imageList1);
            this.advTree1.ExpandAll();
        }

        /// <summary>
        /// 更新模板
        /// </summary>
        /// <param name="node"></param>
        public void UpdateTemplate(Node node, string newText)
        {
            OP_SubTemplate template = node.Tag as OP_SubTemplate;
            template.DTLimit = SysContext.RunSysInfo.currDept.Code;
            template.Name = newText;
            template.No = node.Index;
            template.SpellCode = node.Text.GetSpell();
            template.Status = 1;
            template.WubiCode = node.Text.GetWBM();
            template.ParentID = node.Parent.Tag == null ? "" : (node.Parent.Tag as OP_SubTemplate).ID;
            if (template.ID == null || template.ID == "")
            {
                template.ID = Guid.NewGuid().ToString();
                DBHelper.CIS.Insert<OP_SubTemplate>(template);
            }
            else
            {
                DBHelper.CIS.Update<OP_SubTemplate>(template, p => p.ID == template.ID);
            }
            this.advTree1_NodeDoubleClick(null, new TreeNodeMouseEventArgs(node, System.Windows.Forms.MouseButtons.Left, 2, 0, 0, 0));
        }

        private void advTree1_AfterCellEdit(object sender, CellEditEventArgs e)
        {
            if (this.AfterCellEdit == null) return;
            this.AfterCellEdit(sender, e);
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

        private void 增加组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        private void 增加模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTemplate();
        }

        private void 修改模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTemplate();
        }

        public void EditTemplate()
        {
            Node node = this.advTree1.SelectedNode;
            if (node == null) return;
            FormChildTemplateEdit form = new FormChildTemplateEdit();
            form.SelectNode = node.Tag as OP_SubTemplate;
            form.list = template.Where(p => p.NodeType == 0).ToList();
            if (form.ShowDialog() == DialogResult.OK)
            {
                node.Parent.Nodes.Remove(node);
                if (form.ParentNode.ID == "")
                    this.advTree1.Nodes[0].Nodes.Add(node);
                else
                {
                    Node[] tmp = this.advTree1.Nodes.Find(form.ParentNode.ID, true);
                    if (tmp.Length != 0)
                        tmp[0].Nodes.Add(node);
                }
                node.Text = form.NewName;
            }
        }

        private void 删除模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTemplate();
        }
    }
}
