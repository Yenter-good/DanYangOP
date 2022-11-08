using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.AdvTree;

namespace App_Sys
{
    public partial class FormAddAuthority : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FormAddAuthority()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        public string RoleCode;

        #region 节点操作
        private void SetParentNodeChecked(Node node)
        {
            if (node.Parent != null)
            {
                foreach (Node item in node.Parent.Nodes)
                {
                    if (item.Checked)
                    {
                        node.Parent.Checked = true;
                        return;
                    }
                }
                node.Parent.Checked = false;
            }
        }

        private void SetNodeChecked(Node node, bool Checked)
        {
            foreach (Node item in node.Nodes)
            {
                if (item.Nodes.Count > 0)
                    SetNodeChecked(item, Checked);
                else
                    item.Checked = Checked;
            }
        }
        #endregion

        #region 窗体事件
        private void listBoxAdv1_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            Sys_AuthorityCode dept = this.listUserParameter.SelectedItem as Sys_AuthorityCode;
            if (dept == null) return;
            Node[] nodes = this.treeAuthority.Nodes.Find(dept.Code, true);
            if (nodes.Length > 0)
            {
                nodes[0].Checked = false;
                SetParentNodeChecked(nodes[0]);
            }
            this.listUserParameter.DataSource = this.treeAuthority.CheckedNodes
                                           .Select(n => n.Tag as Sys_AuthorityCode)
                                           .ToList();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DBHelper.CIS.Delete<Sys_Role_AuthorityCode>(p => p.RoleCode == RoleCode);
            List<Sys_AuthorityCode> list = this.listUserParameter.DataSource as List<Sys_AuthorityCode>;
            foreach (Sys_AuthorityCode item in list)
            {
                Sys_Role_AuthorityCode role_authority = new Sys_Role_AuthorityCode();
                role_authority.RoleCode = RoleCode;
                role_authority.AuthorityCode = item.Code;
                DBHelper.CIS.Insert<Sys_Role_AuthorityCode>(role_authority);
            }
            CIS.Core.AlertBox.Info("保存成功");
        }

        private void treeDept_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.X > e.Node.Bounds.X + 10)
            {
                e.Node.Checked = !e.Node.Checked;
            }
            SetParentNodeChecked(e.Node);
            SetNodeChecked(e.Node, e.Node.Checked);

            this.listUserParameter.DataSource = this.treeAuthority.CheckedNodes
                                                       .Select(n => n.Tag as Sys_AuthorityCode)
                                                       .ToList();

        }

        private void FormAddUserDept_Shown(object sender, EventArgs e)
        {
            List<Sys_AuthorityCode> SelectAuthority = new List<Sys_AuthorityCode>();
            List<Sys_Role_AuthorityCode> user_authority = DBHelper.CIS.From<Sys_Role_AuthorityCode>().Where(p => p.RoleCode == RoleCode).ToList();
            List<Sys_AuthorityCode> authority = DBHelper.CIS.From<Sys_AuthorityCode>().ToList();
            foreach (Sys_AuthorityCode item in authority)
            {
                Node[] nodes = this.treeAuthority.Nodes.Find(item.Category, false);
                Node node = new Node(item.Name);
                node.CheckBoxVisible = true;
                node.Tag = item;
                node.Name = item.Code;
                if (nodes.Length > 0)
                    nodes[0].Nodes.Add(node);
                else
                {
                    Node ParentNode = new Node(item.Category);
                    ParentNode.CheckBoxVisible = true;
                    ParentNode.Name = item.Category;
                    ParentNode.Nodes.Add(node);
                    this.treeAuthority.Nodes.Add(ParentNode);
                }
            }

            this.treeAuthority.ExpandAll();
            foreach (Sys_Role_AuthorityCode item in user_authority)
            {
                Node[] nodes = this.treeAuthority.Nodes.Find(item.AuthorityCode, true);
                if (nodes.Length < 1)
                    continue;
                nodes[0].Checked = true;
                SetParentNodeChecked(nodes[0]);
                SelectAuthority.Add(nodes[0].Tag as Sys_AuthorityCode);
            }
            this.listUserParameter.DataSource = SelectAuthority;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
     
    }
}
