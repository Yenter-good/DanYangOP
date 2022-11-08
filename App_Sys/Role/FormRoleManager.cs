using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.AdvTree;
using Dos.ORM;
using CIS.Model;
using CIS.Purview;
using CIS.Core;

namespace App_Sys
{
    public partial class FormRoleManager : Form, IContext
    {
        public FormRoleManager()
        {
            InitializeComponent();
        }
        List<Sys_App> appList = new List<Sys_App>();//系统列表
        List<Sys_Role> roleList = new List<Sys_Role>();//角色列表
        List<IView_User> userList = new List<IView_User>();//所有用户
        List<Sys_User_Role> user_roleList = new List<Sys_User_Role>();//用户与角色关系列表
        List<IView_User> roleHaveUserList = new List<IView_User>();//角色权限内的用户
        List<Sys_Menu> menuList = new List<Sys_Menu>();//菜单列表
        List<Sys_Role_Menu> role_menuList = new List<Sys_Role_Menu>();//角色和菜单关系列表
        List<Sys_Menu> roleHaveMenuList = new List<Sys_Menu>();//角色权限内的菜单列表
        List<Sys_Role_Menu> checkedMenus = new List<Sys_Role_Menu>();//保存时选中的菜单

        string currRoleCode = "";

        private void FormRoleManager_Shown(object sender, EventArgs e)
        {
            InitData();
            InitTree();//因为为了在grid中选中第一行并触发相关操作  用到了Application.DoEvents(); 所以先把InitTree() 操作处理后再进行InitUI()
            InitUI();
        }

        private void InitUI()
        {
            this.gridAllUser.PrimaryGrid.AutoGenerateColumns = false;
            this.gridRole.PrimaryGrid.AutoGenerateColumns = false;
            this.gridCurrUser.PrimaryGrid.AutoGenerateColumns = false;

            this.gridRole.PrimaryGrid.DataSource = roleList;
            this.gridAllUser.PrimaryGrid.DataSource = userList;

            Application.DoEvents();//处理消息队列 清除界面堵塞
            this.gridAllUser.PrimaryGrid.SetSelectedRows(0, 1, true);
            this.gridRole.PrimaryGrid.SetSelectedRows(0, 1, true);
            gridRole_CellClick(null, null);

        }

        private void InitData()
        {
            appList = DBHelper.CIS.From<Sys_App>().ToList();
            roleList = DBHelper.CIS.From<Sys_Role>().ToList();
            userList = Purview.GetUserList();
            menuList = DBHelper.CIS.From<Sys_Menu>().ToList();
            user_roleList = DBHelper.CIS.From<Sys_User_Role>().ToList();
            role_menuList = DBHelper.CIS.From<Sys_Role_Menu>().ToList();
        }
        /// <summary>
        /// 构建树
        /// </summary>
        private void InitTree()
        {
            foreach (Sys_App app in appList)
            {
                Node node = new Node();
                node.Tag = app;
                node.Text = app.Name;
                node.Name = app.Name;
                node.CheckBoxVisible = true;
                //添加子节点
                menuTree.Nodes.Add(node);

                List<Sys_Menu> appHasMenuList = menuList.Where(x => x.AppCode == app.Code).ToList();
                CreateChildsNode(node, "0", appHasMenuList);
            }

            this.menuTree.ExpandAll();

        }
        /// <summary>
        /// 构建树节点的子集
        /// </summary>
        /// <param name="ParentNode"></param>
        /// <param name="ParentCode"></param>
        /// <param name="Source"></param>
        private void CreateChildsNode(Node parentNode, string parentCode, List<Sys_Menu> Source)
        {
            List<Sys_Menu> tmp = Source.Where(p => p.MenuPCode == parentCode).ToList();
            if (tmp.Count == 0)  //递归终止，区域不包含子区域时
            {
                return;
            }

            foreach (Sys_Menu item in tmp)
            {
                Node node = new Node();
                node.Tag = item;
                node.Text = item.Text;
                node.Name = item.Text;
                node.ImageIndex = Convert.ToInt32(item.IconCls);
                node.CheckBoxVisible = true;
                //添加子节点
                parentNode.Nodes.Add(node);
                //递归
                CreateChildsNode(node, item.MenuCode, Source);
            }
        }

        private void CheckRoleHasMenu(List<Sys_Role_Menu> list)
        {
            foreach (Node node in this.menuTree.Nodes)
            {
                foreach (Node menuNode in node.Nodes)
                {
                    CheckChildsNode(node, list);
                }
            }
        }

        /// <summary>
        /// 递归选中子节点
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="list"></param>
        private void CheckChildsNode(Node parentNode, List<Sys_Role_Menu> list)
        {
            foreach (Node node in parentNode.Nodes)
            {
                node.Checked = false;
                Sys_Menu menu = node.Tag as Sys_Menu;
                if (menu == null) continue;
                bool f = list.Where(x => x.MenuID == menu.ID).ToList().Count < 1;//关系表中没有 就为flase 不选中
                node.Checked = !f;
                if (node.HasChildNodes)
                {
                    CheckChildsNode(node, list);
                }
            }
        }


        /// <summary>
        /// 刷新角色列表
        /// </summary>
        private void RefreshRole()
        {
            roleList = DBHelper.CIS.From<Sys_Role>().ToList();
            this.gridRole.PrimaryGrid.DataSource = roleList;
            currRoleCode = "";
        }

        /// <summary>
        /// 刷新角色下用户
        /// </summary>
        /// <param name="code"></param>
        private void RefreshRoleHas(string code)
        {
            user_roleList = DBHelper.CIS.From<Sys_User_Role>().ToList();
            roleHaveUserList = userList.Where(u => user_roleList.Exists(p => p.UserID == u.ID && p.RoleCode == code)).ToList();
            this.gridCurrUser.PrimaryGrid.DataSource = roleHaveUserList;
            CheckRoleHasMenu(new List<Sys_Role_Menu>());


        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRole_Click(object sender, EventArgs e)
        {
            FormAddRole form = new FormAddRole();
            form.ShowDialog();
            RefreshRole();
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelRole_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows = this.gridRole.GetSelectedRows();
            if (rows.Count == 0) return;
            GridRow row = (GridRow)rows[0];
            string code = row["gridRole_Code"].Value.ToString();
            if (code == "admin")
            {
                AlertBox.Info("管理员权限无法删除,无法删除,无法删除" + Environment.NewLine + "重要的事说三遍");
                return;
            }
            try
            {
                int i = DBHelper.CIS.Delete<Sys_Role>(Sys_Role._.Code == code);
                if (i > 0)
                {
                    AlertBox.Info("删除角色成功");
                    DBHelper.CIS.Delete<Sys_Role_Menu>(Sys_Role_Menu._.RoleCode == code);//删除关系表Sys_Role_Menu 中数据
                    DBHelper.CIS.Delete<Sys_User_Role>(Sys_User_Role._.RoleCode == code);//删除关系表Sys_User_Role 中数据
                    DBHelper.CIS.Delete<Sys_Role_AuthorityCode>(Sys_Role_AuthorityCode._.RoleCode == code);//删除关系表Sys_Role_AuthorityCode 中数据
                    RefreshRole();
                }
                else
                {
                    AlertBox.Info("删除失败，请刷新后再操作");
                }
            }
            catch (Exception ex)
            {
                AlertBox.Error(ex.Message);
            }

        }
        /// <summary>
        /// 单击角色 加载角色下用户和右侧菜单树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridRole_CellClick(object sender, DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs e)
        {
            SelectedElementCollection rows = this.gridRole.GetSelectedRows();
            if (rows.Count == 0)
            {
                currRoleCode = "";
                return;
            }
            GridRow row = (GridRow)rows[0];
            string code = row["gridRole_Code"].Value.ToString();
            currRoleCode = code;
            roleHaveUserList = userList.Where(u => user_roleList.Exists(p => u.ID == p.UserID && p.RoleCode == code)).ToList();
            this.gridCurrUser.PrimaryGrid.DataSource = roleHaveUserList;

            Application.DoEvents();
            this.gridCurrUser.PrimaryGrid.SetSelectedRows(0, 1, true);

            List<Sys_Role_Menu> roleHaveMenuList = role_menuList.Where(r => r.RoleCode == code).ToList();
            CheckRoleHasMenu(roleHaveMenuList);

        }

        /// <summary>
        /// 角色当前用户过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxCurrUser_TextChanged(object sender, EventArgs e)
        {
            string text = tbxCurrUser.Text.Trim();
            if (text.Length == 0)
            {
                this.gridCurrUser.PrimaryGrid.DataSource = roleHaveUserList;
            }
            else
            {
                List<IView_User> tempList = roleHaveUserList.Where(u => u.Name.GetSpell().AsNotNullString().Contains(text) || u.Code.Contains(text) || u.SearchCode.AsNotNullString().Contains(text)).ToList();
                this.gridCurrUser.PrimaryGrid.DataSource = tempList;
            }
        }

        /// <summary>
        /// 所有用户过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxAllUser_TextChanged(object sender, EventArgs e)
        {
            string text = tbxAllUser.Text.Trim();
            if (text.Length == 0)
            {
                this.gridAllUser.PrimaryGrid.DataSource = userList;
            }
            else
            {
                List<IView_User> tempList = userList.Where(u => u.Name.GetSpell().AsNotNullString().Contains(text.ToUpper()) || u.Code.AsNotNullString().Contains(text.ToUpper()) || u.SearchCode.AsNotNullString().Contains(text.ToUpper())).ToList();
                this.gridAllUser.PrimaryGrid.DataSource = tempList;
            }
        }

        private void btnRefreshRole_Click(object sender, EventArgs e)
        {
            InitData();
            InitUI();
        }


        private void menuTree_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            Node node = e.Node;
            int x = e.Node.Bounds.X;
            if (e.X > x + 10)
                e.Node.Checked = !e.Node.Checked;

            if (node.Parent != null)
            {
                node.Parent.Checked = true;
            }

            if (node.Nodes.Count > 0)
            {
                MenuTreeCheckNodes(node, node.Checked);
            }


        }
        private void MenuTreeCheckNodes(Node node, bool f)
        {
            if (node.Nodes.Count < 1) return;
            foreach (Node childNode in node.Nodes)
            {
                childNode.Checked = f;
                if (childNode.Nodes.Count > 0)
                {
                    MenuTreeCheckNodes(childNode, f);
                }
            }

        }
        private void btnSet_Click(object sender, EventArgs e)
        {
            if (currRoleCode == "")
            {
                AlertBox.Error("请选择一个角色");
                return;
            }
            FormAddAuthority form = new FormAddAuthority();
            form.RoleCode = currRoleCode;
            form.ShowDialog();
        }

        private void btnRoleSetSave_Click(object sender, EventArgs e)
        {
            if (currRoleCode == "")
            {
                AlertBox.Error("请选中一个角色");
                return;
            }
            if (this.menuTree.CheckedNodes.Count < 1) return;

            this.btnRoleSetSave.Enabled = false;//禁用保存按钮 防止多次操作造成堵塞

            DbBatch batch = DBHelper.CIS.BeginBatchConnection();

            DBHelper.CIS.Delete<Sys_Role_Menu>(Sys_Role_Menu._.RoleCode == currRoleCode);
            GetCheckNodes();//获取当前选中的按钮集合
            try
            {
                foreach (Sys_Role_Menu rel in checkedMenus)
                {
                    batch.Insert<Sys_Role_Menu>(rel);
                }
            }
            catch (Exception ex)
            {
                AlertBox.Error(ex.Message);
            }
            finally
            {
                batch.Close();
                AlertBox.Info("保存成功");
                role_menuList = DBHelper.CIS.From<Sys_Role_Menu>().ToList();
                this.btnRoleSetSave.Enabled = true;//完成操作后启用按钮

            }
        }


        private void GetCheckNodes()
        {
            this.checkedMenus.Clear();
            foreach (Node root in menuTree.Nodes)
            {
                GetAllCheckNodes(root);
            }
        }

        private void GetAllCheckNodes(Node root)
        {
            foreach (Node node in root.Nodes)
            {
                if (!node.Checked) continue;
                Sys_Menu menu = node.Tag as Sys_Menu;
                Sys_Role_Menu rel = new Sys_Role_Menu();
                rel.MenuID = menu.ID;
                rel.RoleCode = currRoleCode;
                checkedMenus.Add(rel);
                if (node.Nodes.Count > 0)
                {
                    GetAllCheckNodes(node);
                }
            }
        }

        private void gridCurrUser_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            SelectedElementCollection userRows = this.gridCurrUser.GetSelectedRows();
            if (userRows.Count == 0)
            {
                AlertBox.Info("请选择一个用户");
                return;
            }
            GridRow userRow = (GridRow)userRows[0];
            string userID = userRow["gridCurrUser_ID"].Value.ToString();
            if (userID == "9999")
            {
                AlertBox.Info("管理员工号无法删除,无法删除,无法删除" + Environment.NewLine + "重要的事说三遍");
                return;
            }
            try
            {
                int i = DBHelper.CIS.Delete<Sys_User_Role>(Sys_User_Role._.RoleCode == currRoleCode && Sys_User_Role._.UserID == userID);
                if (i > 0)
                {
                    RefreshRoleHas(currRoleCode);
                    AlertBox.Info("删除成功");
                }
                else
                {
                    AlertBox.Info("删除失败");
                }
            }
            catch (Exception ex)
            {
                AlertBox.Error(ex.Message);
            }
        }

        private void gridAllUser_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            SelectedElementCollection roleRows = this.gridRole.GetSelectedRows();
            SelectedElementCollection userRows = this.gridAllUser.GetSelectedRows();
            if (roleRows.Count == 0 || userRows.Count == 0)
            {
                AlertBox.Info("请选择一个角色和用户");
                return;
            }
            GridRow roleRow = (GridRow)roleRows[0];
            string roleCode = roleRow["gridRole_Code"].Value.ToString();
            GridRow userRow = (GridRow)userRows[0];
            string userID = userRow["gridAllUser_ID"].Value.ToString();
            if (user_roleList.Where(x => x.UserID == userID && x.RoleCode == roleCode).ToList().Count > 0)
            {
                AlertBox.Info("该用户已经添加");
                return;
            }
            Sys_User_Role model = new Sys_User_Role();
            model.RoleCode = roleCode;
            model.UserID = userID;
            try
            {
                DBHelper.CIS.Insert<Sys_User_Role>(model);
                RefreshRoleHas(roleCode);
                AlertBox.Info("保存成功");
            }
            catch (Exception ex)
            {
                AlertBox.Error(ex.Message);
            }
        }


        public CIS.Purview.ViewModel.Session Session
        {
            get;
            set;
        }
    }
}
