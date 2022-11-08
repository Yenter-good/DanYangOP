using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.AdvTree;

namespace App_Sys
{
    public partial class FormAddUserParameter : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public string UserID;

        public FormAddUserParameter()
            : base()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        #region 节点操作
        private void SetParentNodeChecked(Node node)
        {
            if (node.Parent != null)
            {
                int sum = 0;
                foreach (Node item in node.Parent.Nodes)
                {
                    if (item.CheckState == CheckState.Checked)
                        sum++;
                }
                if (sum == node.Parent.Nodes.Count)
                    node.Parent.CheckState = CheckState.Checked;
                else if (sum == 0)
                    node.Parent.CheckState = CheckState.Unchecked;
                else
                    node.Parent.CheckState = CheckState.Indeterminate;
                SetParentNodeChecked(node.Parent);
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
            DBHelper.CIS.Delete<Sys_User_AuthorityCode>(p => p.UserID == UserID);
            List<Sys_AuthorityCode> list = this.listUserParameter.DataSource as List<Sys_AuthorityCode>;
            foreach (Sys_AuthorityCode item in list)
            {
                Sys_User_AuthorityCode user_dept = new Sys_User_AuthorityCode();
                user_dept.UserID = UserID;
                user_dept.AuthorityCode = item.Code;
                DBHelper.CIS.Insert<Sys_User_AuthorityCode>(user_dept);
            }
            CIS.Core.AlertBox.Info("保存成功");
            this.Close();
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
            List<Sys_User_AuthorityCode> user_authority = DBHelper.CIS.From<Sys_User_AuthorityCode>().Where(p => p.UserID == UserID).ToList();
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
            foreach (Sys_User_AuthorityCode item in user_authority)
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
