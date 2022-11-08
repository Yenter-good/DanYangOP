using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.AdvTree;

namespace App_Sys
{
    public partial class FormAddUserDept : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public string UserID;

        public FormAddUserDept()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void FormAddUserDept_Shown(object sender, EventArgs e)
        {
            List<IView_Dept> SelectDept = new List<IView_Dept>();
            List<IView_Dept> dept = DBHelper.CIS.From<IView_Dept>().ToList();
            List<Sys_User_Dept> user_dept = DBHelper.CIS.From<Sys_User_Dept>().Where(p => p.UserID == UserID).ToList();
            List<CIS.Utility.TreeModel1> list = new List<CIS.Utility.TreeModel1>();
            foreach (IView_Dept item in dept)
            {
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.Code ?? "").Trim(), ParentCode = (item.PCode ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.Code.Trim() });
            }
            CIS.Utility.TreeHelper.CreateChildsNode(this.treeDept.Nodes, "", list, true, null);
            this.treeDept.ExpandAll();
            foreach (Sys_User_Dept item in user_dept)
            {
                Node[] nodes = this.treeDept.Nodes.Find(item.DepartCode.Trim(), true);
                if (nodes.Length < 1)
                    continue;
                nodes[0].Checked = true;
                //SetParentNodeChecked(nodes[0]);
                SelectDept.Add(nodes[0].Tag as IView_Dept);
            }
            this.listUserDept.DataSource = SelectDept;
        }

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
                //SetParentNodeChecked(node.Parent);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<Node> GetCheckNodes(NodeCollection parentNode)
        {
            List<Node> result = new List<Node>();
            foreach (Node item in parentNode)
            {
                if (item.Nodes.Count != 0)
                    result.AddRange(GetCheckNodes(item.Nodes));
                if (item.Checked)
                    result.Add(item);
            }
            return result;
        }

        private void treeDept_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.X > e.Node.Bounds.X + 10)
            {
                e.Node.Checked = !e.Node.Checked;
            }
            //SetParentNodeChecked(e.Node);
            //SetNodeChecked(e.Node, e.Node.Checked);


            this.listUserDept.DataSource = GetCheckNodes(this.treeDept.Nodes)
                                                       .Select(n => n.Tag as IView_Dept)
                                                       .ToList();

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

        private void listBoxAdv1_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            IView_Dept dept = this.listUserDept.SelectedItem as IView_Dept;
            if (dept == null) return;
            Node[] nodes = this.treeDept.Nodes.Find(dept.Code, true);
            if (nodes.Length > 0)
            {
                nodes[0].Checked = false;
                //SetParentNodeChecked(nodes[0]);
            }
            this.listUserDept.DataSource = this.treeDept.CheckedNodes
                                           .Select(n => n.Tag as IView_Dept)
                                           .ToList();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DBHelper.CIS.Delete<Sys_User_Dept>(p => p.UserID == UserID);
            List<IView_Dept> list = this.listUserDept.DataSource as List<IView_Dept>;
            foreach (IView_Dept item in list)
            {
                Sys_User_Dept user_dept = new Sys_User_Dept();
                user_dept.UserID = UserID;
                user_dept.DepartCode = item.Code;
                DBHelper.CIS.Insert<Sys_User_Dept>(user_dept);
            }
            CIS.Core.AlertBox.Info("保存成功");
            this.Close();
        }
    }
}
