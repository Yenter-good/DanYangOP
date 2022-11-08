using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using CIS.Model;
using DevComponents.AdvTree;

namespace App_Sys
{
    public partial class FormUserManager : Form
    {
        List<IView_User> User;  //当前所有用户
        Node SelectNode;    //当前选中的科室节点
        public FormUserManager()
        {
            InitializeComponent();
            InitUI();
        }

        #region 初始化操作
        /// <summary>
        /// 初始化设置按钮
        /// </summary>
        private void InitUI()
        {
            var Dept = this.GridUser.PrimaryGrid.Columns["colEditDept"];
            Dept.EditorType = typeof(MyButton);
            Dept.EditorParams = new object[] { "\uf0b1" };
            GridButtonXEditControl DeptButton = Dept.EditControl as GridButtonXEditControl;
            DeptButton.Click += DeptButton_Click;

            var User = this.GridUser.PrimaryGrid.Columns["colEditUser"];
            User.EditorType = typeof(MyButton);
            User.EditorParams = new object[] { "\uf0f0" };
            GridButtonXEditControl UserButton = User.EditControl as GridButtonXEditControl;
            UserButton.Click += UserButton_Click;

            var Role = this.GridUser.PrimaryGrid.Columns["colEditRole"];
            Role.EditorType = typeof(MyButton);
            Role.EditorParams = new object[] { "\uf0c0" };
            GridButtonXEditControl RoleButton = Role.EditControl as GridButtonXEditControl;
            RoleButton.Click += RoleButton_Click;

            var Job = this.GridUser.PrimaryGrid.Columns["colUserJob"];
            Job.EditorType = typeof(MyComboBox);
            Job.EditorParams = new object[] { DBHelper.CIS.From<Sys_Dic_Details>().Where(p => p.DicCode == "JobTitle").ToList() };

            var Type = this.GridUser.PrimaryGrid.Columns["colUserType"];
            Type.EditorType = typeof(MyComboBox);
            Type.EditorParams = new object[] { DBHelper.CIS.From<Sys_Dic_Details>().Where(p => p.DicCode == "UserType").ToList() };
        }

        /// <summary>
        /// 初始化科室信息
        /// </summary>
        private void InitDept()
        {
            this.treeDept.Nodes.Clear();
            List<IView_Dept> Dept = CIS.Purview.Purview.GetDeptList();
            List<CIS.Utility.TreeModel1> list = new List<CIS.Utility.TreeModel1>();
            foreach (IView_Dept item in Dept)
            {
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.Code ?? "").Trim(), ParentCode = (item.PCode ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.Code.Trim() });
            }
            CIS.Utility.TreeHelper.CreateChildsNode(this.treeDept.Nodes, "", list, false, null);
            this.treeDept.ExpandAll();
        }

        /// <summary>
        /// 初始化用户信息
        /// </summary>
        private void InitUser()
        {
            User = CIS.Purview.Purview.GetUserList();
            foreach (IView_User item in User)
            {
                item.Status = item.Status == 1 ? 0 : 1;
            }
        }
        #endregion

        #region 窗体事件
        void RoleButton_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows = this.GridUser.GetSelectedRows();
            if (rows.Count == 0) return;
            GridRow row = rows[0] as GridRow;
            FormAddUserRole form = new FormAddUserRole();
            form.userID = row.Cells["colUserID"].Value.ToString();
            form.labelX1.Text = row.Cells["colUserName"].Value.ToString();
            form.ShowDialog();
        }

        void UserButton_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows = this.GridUser.GetSelectedRows();
            if (rows.Count == 0) return;
            GridRow row = rows[0] as GridRow;
            FormAddUserParameter form = new FormAddUserParameter();
            form.labelX1.Text = row.Cells["colUserName"].Value.ToString();
            form.UserID = row.Cells["colUserID"].Value.ToString();
            form.ShowDialog();
        }

        void DeptButton_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows = this.GridUser.GetSelectedRows();
            if (rows.Count == 0) return;
            GridRow row = rows[0] as GridRow;
            FormAddUserDept form = new FormAddUserDept();
            form.labelX1.Text = row.Cells["colUserName"].Value.ToString();
            form.UserID = row.Cells["colUserID"].Value.ToString();
            form.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddUser form = new FormAddUser();
            form.btnAddOrUpdate.Text = "新增";
            if (SelectNode != null)
                form.Dept_Code = (SelectNode.Tag as IView_Dept).Code;
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitUser();
                ShowUserInfo(this.checkBoxItem1.Checked);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormAddUser form = new FormAddUser();
            form.btnAddOrUpdate.Text = "保存";
            SelectedElementCollection SelectRows = this.GridUser.GetSelectedRows();
            if (SelectRows.Count < 1) return;
            if ((SelectRows[0] as GridRow)["colStatus"].Value.AsBoolean())
            {
                MessageBox.Show("停用的用户无法修改详细信息");
                return;
            }
            form.UserID = (SelectRows[0] as GridRow)["colUserID"].Value.ToString();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitUser();
                ShowUserInfo(this.checkBoxItem1.Checked);
            }
        }

        private void FormUserManager_Shown(object sender, EventArgs e)
        {
            InitDept();
            InitUser();
        }

        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            SelectNode = e.Node;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ShowUserInfo(this.checkBoxItem1.Checked);
            }
            //else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            //    this.contextMenuStrip1.Show(MousePosition);
        }

        private void checkBoxItem1_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            ShowUserInfo(this.checkBoxItem1.Checked);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitUI();
            InitUser();
            InitDept();
            ShowUserInfo(this.checkBoxItem1.Checked);
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows = this.GridUser.GetSelectedRows();
            if (rows.Count == 0) return;
            List<string> list = new List<string>();
            foreach (GridRow item in rows)
            {
                bool Status = item.Cells["colStatus"].Value.AsBoolean();
                string Code = item.Cells["colUserCode"].Value.ToString();
                string ID = item.Cells["colUserID"].Value.ToString();
                bool Continue = false;
                if (Status)
                {
                    List<IView_User> User = DBHelper.CIS.From<IView_User>().Where(p => p.Code == Code).ToList();
                    foreach (IView_User item1 in User)
                    {
                        if (item1.Status == 1)
                        {
                            list.Add("姓名：" + item.Cells["colUserName"].Value.ToString() + "  工号：" + item.Cells["colUserCode"].Value.ToString() + "  已经存在并且最少有一个处于正在使用状态,无法启用当前账户");
                            Continue = true;
                        }
                    }
                }
                if (Continue) continue;
                DBHelper.CIS.Update<IView_User>(IView_User._.Status, Status ? 1 : 0, IView_User._.ID == ID);
            }
            if (list.Count > 0)
                MessageBox.Show(string.Join(Environment.NewLine, list.ToArray()));
            InitUser();
            ShowUserInfo(this.checkBoxItem1.Checked);
        }

        private void GridUser_RowClick(object sender, GridRowClickEventArgs e)
        {
            SelectedElementCollection rows = this.GridUser.GetSelectedRows();
            if (rows.Count == 0) return;
            GridRow row = rows[0] as GridRow;
            bool Status = row.Cells["colStatus"].Value.AsBoolean();
            if (Status)
                this.btnStatus.Text = "启用";
            else
                this.btnStatus.Text = "停用";
        }
        #endregion

        /// <summary>
        /// 显示当前科室节点下的用户
        /// </summary>
        private void ShowUserInfo(bool Status, bool Select = false)
        {
            if (SelectNode == null) return;
            IView_Dept Dept = SelectNode.Tag as IView_Dept;
            string Dept_Code = Dept.Code;
            if (User == null) return;
            List<IView_User> tmp;
            if (!Status)
                tmp = User.Where(p => p.Dept_Code == Dept_Code).ToList();
            else
                tmp = User.Where(p => p.Dept_Code == Dept_Code && p.Status == 0).ToList();

            if (this.checkBoxItem1.Checked)
                tmp = tmp.Where(p => p.Status == 0).ToList();
            this.GridUser.PrimaryGrid.DataSource = tmp;
            Application.DoEvents();
            //GridUser_RowClick(null, null);
            this.GridUser.PrimaryGrid.ClearSelectedRows();
            if (Select)
            {
                foreach (GridRow item in this.GridUser.PrimaryGrid.Rows)
                {
                    if (item.Cells["colUserSearchCode"].Value.ToString().Trim() == this.superText1.Text.ToUpper() || item.Cells["colUserName"].Value.ToString().Trim() == this.superText1.Text)
                        this.GridUser.PrimaryGrid.SetSelectedRows(item.Index, 1, true);
                }
            }
            else
                this.GridUser.PrimaryGrid.SetSelectedRows(0, 1, true);

        }

        private void 增加科室ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddDept form = new FormAddDept();
            Node node;
            if ((SelectNode.Tag as IView_Dept).PCode.Trim() == "")
                node = SelectNode;
            else
                node = SelectNode.Parent;
            form.ParentCode = node;
            form.ShowDialog();
            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                InitDept();
        }

        private void GridUser_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void 删除科室ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectNode.Nodes.Count != 0)
            {
                DialogResult result = MessageBox.Show("当前分类下有多个科室,是否全部删除", "系统提示", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                    return;
            }
            foreach (Node item in SelectNode.Nodes)
            {
                DBHelper.CIS.Delete<IView_Dept>(p => p.Code == (item.Tag as IView_Dept).Code);
            }
            DBHelper.CIS.Delete<IView_Dept>(p => p.Code == (SelectNode.Tag as IView_Dept).Code);
            InitDept();
        }

        private void 编辑科室ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddDept form = new FormAddDept();
            form.ParentCode = SelectNode;
            form.IsEdit = true;
            form.ShowDialog();
            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                InitDept();
        }

        private void FormUserManager_Load(object sender, EventArgs e)
        {

        }

        private void superText1_TextChanged(object sender, EventArgs e)
        {
            searchUser = new List<IView_User>();
        }

        List<IView_User> searchUser = new List<IView_User>();
        int searchIndex = 0;
        string searchText = "";

        private void superText1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.superText1.Text != searchText)
                {
                    searchText = this.superText1.Text;
                    searchIndex = 0;
                    searchUser = new List<IView_User>();
                }
                if (searchUser.Count == 0)
                    searchUser = User.Where(p => p.SearchCode.Trim() == this.superText1.Text.ToUpper() || p.Name.Trim() == this.superText1.Text || p.Code == this.superText1.Text).ToList();
                if (searchUser.Count > 0)
                {
                    string deptCode = searchUser[searchIndex].Dept_Code;
                    Node[] nodes = this.treeDept.Nodes.Find(deptCode, true);
                    if (nodes.Length > 0)
                    {
                        this.treeDept.SelectedNode = nodes[0];
                        SelectNode = nodes[0];
                        ShowUserInfo(this.checkBoxItem1.Checked, true);
                    }
                    searchIndex++;
                    if (searchIndex >= searchUser.Count)
                        searchIndex = 0;
                }
            }
        }

    }
    public class MyButton : GridButtonXEditControl
    {
        public MyButton(string Symbol)
        {
            base.Symbol = Symbol;
        }
    }

    public class MyComboBox : GridComboBoxExEditControl
    {
        public MyComboBox(object Source)
        {
            this.DisplayMember = "Value";
            this.ValueMember = "Code";
            this.DataSource = Source;
        }

    }
}
