using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dos.ORM;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;

namespace App_Sys
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    public partial class FormMenuManager : CIS.Core.BaseForm
    {
        private string m_DefaultSelectedMenuCode;//用于加载完菜单后默认选择的菜单项 记住加载完后清空
        public CIS.Model.Sys_App SelectedApp
        {
            get
            {
                if (lbaSystem.SelectedItem != null)
                    return (lbaSystem.SelectedItem as ListBoxItem).Tag as CIS.Model.Sys_App;
                return null;
            }
        }
        //private Timer timer;
        public FormMenuManager()
        {
            InitializeComponent();

            #region 更新删除按钮和编辑按钮状态
            //timer = new Timer();
            //timer.Interval = 500;
            //timer.Tick += SetEditOrDeleteButtonEnable;
            //timer.Enabled = true;
            this.lbaSystem.GotFocus += SetEditOrDeleteButtonEnable;
            this.lbaSystem.LostFocus += SetEditOrDeleteButtonEnable;
            this.lbaSystem.VisibleChanged += SetEditOrDeleteButtonEnable;
            this.lbaSystem.SelectedIndexChanged += SetEditOrDeleteButtonEnable;
            this.superGridControl1.GotFocus += SetEditOrDeleteButtonEnable;
            this.superGridControl1.SelectionChanged += SetEditOrDeleteButtonEnable;
            this.superGridControl1.VisibleChanged += SetEditOrDeleteButtonEnable;
            this.superGridControl1.LostFocus += SetEditOrDeleteButtonEnable;

            #endregion

            this.superGridControl1.RowDoubleClick += superGridControl1_RowDoubleClick;
        }
        /// <summary>
        /// 更新删除按钮和编辑按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetEditOrDeleteButtonEnable(object sender, EventArgs e)
        {
            //this.btnEdit.Enabled =
            //             this.btnDelete.Enabled =
            bool enable = (this.lbaSystem.Focused && this.lbaSystem.Visible && this.lbaSystem.SelectedIndices.Count > 0)
                        ||
                        (this.superGridControl1.Focused && this.superGridControl1.Visible && this.superGridControl1.PrimaryGrid.GetSelectedRows().Count > 0);
            if (enable != this.btnEdit.Enabled)
            {
                this.btnEdit.Enabled = enable;
                this.btnDelete.Enabled = enable;
            }
        }
        /// <summary>
        /// 创建系统项目
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        private ListBoxItem CreateSystemItem(CIS.Model.Sys_App app)
        {
            ListBoxItem item = new ListBoxItem();
            UpdateSystemItem(item, app);
            return item;
        }
        /// <summary>
        /// 通过实体更新系统项目
        /// </summary>
        /// <param name="item"></param>
        /// <param name="app"></param>
        private void UpdateSystemItem(ListBoxItem item, CIS.Model.Sys_App app)
        {
            item.Text = "  <b>{0}</b>".FormatWith(app.Name);
            item.Tag = app;
            item.Name = app.Code;
            item.Image = Properties.Resources.EmptySystemIcon_32x32;

            if (app.Status == 0)
                item.TextColor = Color.Gray;
            else
                item.TextColor = Color.Empty;
        }
        /// <summary>
        /// 加载系统列表
        /// </summary>
        public void LoadSystemsAsync(string selectedSystemCode = null)
        {
            this.pnlTool.Enabled = false;
            this.rbtnSystemAll.Enabled = false;
            this.rbtnSystemValid.Enabled = false;
            bool allOrEnable = this.rbtnSystemAll.Checked;
            CIS.Utility.LoadHelper.LoadAsync<List<CIS.Model.Sys_App>>(this.lbaSystem,
                () =>
                {
                    List<CIS.Model.Sys_App> apps;
                    if (allOrEnable)
                        apps = CIS.Purview.SysAppDal.GetAllApps();
                    else
                        apps = CIS.Purview.SysAppDal.GetValidApps();
                    return apps;
                },
                data =>
                {
                    this.pnlTool.Enabled = true;
                    this.rbtnSystemAll.Enabled = true;
                    this.rbtnSystemValid.Enabled = true;

                    this.lbaSystem.Items.Clear();
                    this.lbaSystem.BeginUpdate();
                    foreach (var item in data)
                    {
                        this.lbaSystem.Items.Add(CreateSystemItem(item));
                    }
                    this.lbaSystem.EndUpdate();

                    if (selectedSystemCode.IsNullOrWhiteSpace()) return;
                    foreach (ListBoxItem item in this.lbaSystem.Items)
                    {
                        var app = item.Tag as CIS.Model.Sys_App;
                        if (app.Code == selectedSystemCode)
                        {
                            this.lbaSystem.SelectedItem = item;
                            break;
                        }
                    }
                });
        }
        /// <summary>
        /// 添加系统
        /// </summary>
        private void AddSystem()
        {
            using (FormSystemEdit dialog = new FormSystemEdit())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var item = this.CreateSystemItem(dialog.App);
                    lbaSystem.Items.Add(item);
                    lbaSystem.SelectedIndex = lbaSystem.Items.Count - 1;
                }
            }

        }
        /// <summary>
        /// 编辑系统
        /// </summary>
        /// <param name="item"></param>
        private void EditSystem(ListBoxItem item)
        {
            if (item == null) return;
            var app = item.Tag as CIS.Model.Sys_App;
            using (FormSystemEdit dialog = new FormSystemEdit(app))
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.UpdateSystemItem(item, app);
                }
            }
        }
        /// <summary>
        /// 删除系统
        /// </summary>
        /// <param name="item"></param>
        private void DeleteSystem(ListBoxItem item)
        {
            if (item == null) return;
            var curApp = item.Tag as CIS.Model.Sys_App;
            if (CIS.Purview.SysAppDal.HasMenus(curApp.Code))
            {
                CIS.Core.MsgBox.OK("系统" + item.Text + "包含有菜单,不允许删除.");
                return;
            }

            if (CIS.Core.MsgBox.OKCancel("确定删除系统{0}?".FormatWith(item.Text))
                 == System.Windows.Forms.DialogResult.Cancel) return;
            if (CIS.Model.DBHelper.CIS.Delete(curApp) <= 0)
            {
                CIS.Core.AlertBox.Error("删除系统失败");
            }
            else
            {
                lbaSystem.Items.Remove(item);
            }
        }
        /// <summary>
        /// 模块实体转换为树节点
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        private List<CIS.Utility.TreeModel> ToTreeModel(List<CIS.Model.Sys_Menu> menus)
        {
            List<CIS.Utility.TreeModel> models = new List<CIS.Utility.TreeModel>();
            foreach (var menu in menus)
            {
                string pname = "";
                var parentModule = menus.Find(m => m.MenuCode == menu.MenuPCode);
                if (parentModule != null)
                    pname = parentModule.Text;
                var model = this.GetTreeModel(menu, pname);
                models.Add(model);
            }
            return models;
        }
        /// <summary>
        /// 通过模块实体和分类名称获取树节点实体
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public CIS.Utility.TreeModel GetTreeModel(CIS.Model.Sys_Menu menu, string category)
        {
            return new CIS.Utility.TreeModel()
            {
                Code = menu.MenuCode
                ,
                Text = menu.Text
                ,
                ParentCode = menu.MenuPCode
                ,
                Cells = new object[] {
                            menu.Text                  // 模块名称
                            ,category                       // 上级名称
                            ,menu.RNO                  // 程序集
                            ,menu.FName                // 命名空间
                            ,menu.No                   // 排序
                            ,menu.GetMenuOpenStyleName()            //显示方式
                            ,menu.Status==1            //是否启用
             }
             ,
                Obj = menu
             ,
                Sort = menu.No.GetValueOrDefault(0)
            };
        }
        /// <summary>
        /// 异步加载菜单信息
        /// </summary>
        public void LoadMenusAsync(string appCode)
        {
            this.btnAddMenu.Enabled = false;
            //禁用控件
            this.pnlTool.Enabled = false;
            bool showAllOrEnable = this.rbtnMenuAll.Checked;
            CIS.Utility.LoadHelper.LoadAsync<GridRow[]>(this.superGridControl1
                , () =>
                {
                    //获取有效的模块信息
                    List<CIS.Model.Sys_Menu> menus;
                    if (showAllOrEnable)
                        menus = CIS.Purview.SysAppDal.GetAllMenus(appCode);
                    else
                        menus = CIS.Purview.SysAppDal.GetValidMenus(appCode);
                    //转换为树节点数据
                    var models = this.ToTreeModel(menus);
                    //返回行集合
                    return CIS.Utility.TreeHelper.CreateGridRows(models, RowFormat);
                }
                , data =>
                {
                    //加载所有行
                    CIS.Utility.TreeHelper.FillGrid(this.superGridControl1.PrimaryGrid, data);
                    this.superGridControl1.PrimaryGrid.ExpandAll();
                    //设置默认项
                    if (!m_DefaultSelectedMenuCode.IsNullOrEmpty())
                    {
                        var gr = CIS.Utility.TreeHelper.FindGridRow(this.superGridControl1.PrimaryGrid.Rows, m_DefaultSelectedMenuCode);
                        if (gr != null)
                        {
                            this.superGridControl1.PrimaryGrid.ClearSelectedRows();
                            if (!gr.IsOnScreen)
                                gr.EnsureVisible();
                            gr.IsSelected = true;
                        }
                        m_DefaultSelectedMenuCode = null;
                    }
                    //启用控件
                    this.pnlTool.Enabled = true;
                    this.btnAddMenu.Enabled = true;
                }
                );
        }
        /// <summary>
        /// 行格式化
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="model"></param>
        private void RowFormat(GridRow gr, CIS.Utility.TreeModel model)
        {
            var m = model.Obj as CIS.Model.Sys_Menu;
            gr.CellStyles.Default.TextColor = m.Status == 1 ? Color.Empty : Color.Gray;
            gr.Cells[0].CellStyles.Default.ImageIndex = 0;
        }

        /// <summary>
        /// 获取当前包含的所有模块的代码
        /// 包含本身
        /// </summary>
        /// <param name="gr"></param>
        /// <returns></returns>
        private List<string> GetAllCodes(GridRow gr)
        {
            if (gr == null) return null;
            var model = (gr.Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Menu;
            if (model == null) return null;
            List<string> codes = new List<string>();
            codes.Add(model.MenuCode);
            foreach (GridRow item in gr.Rows)
            {
                var childCodes = this.GetAllCodes(item);
                if (childCodes != null)
                    codes.AddRange(childCodes);
            }
            return codes;
        }
        /// <summary>
        /// 插入模块
        /// </summary>
        /// <param name="appCode"></param>
        /// <param name="pCode"></param>
        private void AddMenu(string appCode, string pCode)
        {
            if (appCode.IsNullOrWhiteSpace()) return;
            using (FormMenuEdit dialog = new FormMenuEdit(appCode, pCode))
            {
                dialog.OK += (sender, e) =>
                {
                    //如果变更了系统则加载新的系统列表
                    if (appCode != dialog.SysMenu.AppCode)
                    {
                        m_DefaultSelectedMenuCode = dialog.SysMenu.MenuCode;
                        this.lbaSystem.SelectedItem = this.lbaSystem.GetItem(dialog.SysMenu.AppCode);
                        return;
                    }

                    this.superGridControl1.PrimaryGrid.ClearSelectedRows();
                    CIS.Utility.TreeHelper.AddGridRow(this.superGridControl1.PrimaryGrid, this.GetTreeModel(dialog.SysMenu, dialog.PText), RowFormat, true);
                };
                dialog.ShowDialog();
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="gr"></param>
        private void EditMenu(GridRow gr)
        {
            if (gr == null) return;
            var model = (gr.Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Menu;
            if (model == null) return;
            string oldAppCode = model.AppCode;
            using (FormMenuEdit dialog = new FormMenuEdit(model))
            {
                dialog.OK += (sender, e) =>
                {
                    //如果变更了系统则
                    if (oldAppCode != dialog.SysMenu.AppCode)
                    {
                        m_DefaultSelectedMenuCode = dialog.SysMenu.MenuCode;
                        this.lbaSystem.SelectedItem = this.lbaSystem.GetItem(dialog.SysMenu.AppCode);
                        //this.LoadMenusAsync(dialog.SysMenu.AppCode);
                    }
                    else
                    {
                        this.superGridControl1.PrimaryGrid.ClearSelectedRows();
                        var ngr = CIS.Utility.TreeHelper.RefreshGridRow(gr, this.GetTreeModel(dialog.SysMenu, dialog.PText), RowFormat);
                    }
                };
                dialog.ShowDialog();

            }
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="gr"></param>
        private void DeleteMenu(GridRow gr)
        {
            if (gr == null) return;
            var module = (gr.Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Menu;
            if (module == null) return;

            if (gr.Rows.Count > 0)
            {
                if (CIS.Core.MsgBox.YesNo("删除{0},将会连同子数据一起删除,是否继续?".FormatWith(module.Text)) == System.Windows.Forms.DialogResult.No)
                    return;
            }
            else
            {
                if (CIS.Core.MsgBox.YesNo("是否删除{0}?".FormatWith(module.Text)) == System.Windows.Forms.DialogResult.No)
                    return;
            }
            var codes = this.GetAllCodes(gr);
            if (codes == null) return;
            //删除行
            if (CIS.Model.DBHelper.CIS.Delete<CIS.Model.Sys_Menu>(m => m.MenuCode.In(codes)) > 0)
            {
                CIS.Utility.TreeHelper.GridRowDelete(gr);
                CIS.Core.AlertBox.Info("<b>成功</b> 删除成功");
            }
            else
                CIS.Core.AlertBox.Error("<b>错误</b> 删除不成功");

        }
        /// <summary>
        /// 加载所有科室列表
        /// </summary>
        private void LoadDeptAsync()
        {
            CIS.Utility.LoadHelper.LoadAsync<List<Node>>(this.advTree1,
                () =>
                {
                    var depts = CIS.Purview.SysDeptDal.GetValidDepts();
                    var dict = depts.Select(d => new { DeptType = d.GetDeptTypeName(), TModel = new CIS.Utility.TreeModel { Code = d.Code, ParentCode = d.PCode, Text = d.Name, Obj = d } })
                        .GroupBy(d => d.DeptType)
                        .ToDictionary(k => k.Key, v => v.ToList());

                    List<Node> nodes = new List<Node>();
                    foreach (var item in dict)
                    {
                        Node node = new Node(item.Key);
                        node.Tag = "DeptType";
                        node.CheckBoxVisible = true;
                        node.Nodes.AddRange(CIS.Utility.TreeHelper.CreateChildNodes(item.Value.Select(i => i.TModel).ToList(), true, DeptNodeFormat));
                        nodes.Add(node);
                    }
                    return nodes;
                }
                , data =>
                {
                    this.advTree1.BeginUpdate();
                    rootNode.Nodes.Clear();
                    rootNode.Nodes.AddRange(data.ToArray());
                    this.advTree1.EndUpdate();
                    this.advTree1.ExpandAll();
                });
        }
        private void DeptNodeFormat(Node node, CIS.Utility.TreeModel tm)
        {

        }
        /// <summary>
        /// 加载系统对应的科室列表
        /// </summary>
        private void LoadDeptBySystem()
        {
            if (this.SelectedApp == null) return;


            var depts = CIS.Purview.SysAppDal.GetDepts(this.SelectedApp.Code);
            this.LoadDepts(depts);

        }
        /// <summary>
        /// 加载科室列表
        /// </summary>
        /// <param name="depts"></param>
        private void LoadDepts(List<CIS.Model.IView_Dept> depts)
        {
            this.lbaDept.BeginUpdate();
            this.lbaDept.Items.Clear();
            foreach (var dept in depts)
            {
                ListBoxItem item = new ListBoxItem();
                item.Text = dept.Name;
                item.Name = dept.Code;
                item.Tag = dept;
                item.Image = Properties.Resources.DeptIcon_32x32;
                this.lbaDept.Items.Add(item);
            }
            this.lbaDept.EndUpdate();
        }
        /// <summary>
        /// 保存科室
        /// </summary>
        private void SaveDepts()
        {
            if (this.SelectedApp == null) return;
            string appCode = this.SelectedApp.Code;
            if (!CIS.Purview.SysAppDal.SaveDepts(appCode, this.lbaDept.Items
                 .Select(i => ((i as ListBoxItem).Tag as CIS.Model.IView_Dept).Code)
                 .ToList()))
            {
                CIS.Core.AlertBox.Error("<b>错误</b>  保存科室列表失败");
            }
        }
        /// <summary>
        /// 通过当前节点的状态更新父节点状态
        /// </summary>
        /// <param name="node"></param>
        private void UpdateParentNodeState(Node node)
        {
            if (node.Parent != null)
            {
                bool allSame = true;
                bool check = node.Parent.Nodes[0].Checked;
                foreach (Node n in node.Parent.Nodes)
                {
                    if (n.Checked != check)
                    {
                        allSame = false;
                        break;
                    }
                }
                if (allSame)
                {
                    node.Parent.Checked = check;
                }
                else
                    node.Parent.CheckState = CheckState.Indeterminate;
                this.UpdateParentNodeState(node.Parent);
            }
        }
        /// <summary>
        /// 根据当前节点的状态更新子节点状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="updateParent"></param>
        private void UpdateNodeCheck(Node node, bool updateParent)
        {
            if (updateParent)
                this.UpdateParentNodeState(node);
            foreach (Node n in node.Nodes)
            {
                n.Checked = node.Checked;
                UpdateNodeCheck(n, false);
            }
        }
        /// <summary>
        /// 根据dll和类名生成主页预览图
        /// </summary>
        /// <param name="dll"></param>
        /// <param name="className"></param>
        private void LoadHomePage(string dll, string className)
        {
            if (!string.IsNullOrEmpty(dll) && !string.IsNullOrEmpty(className))
            {
                try
                {
                    var ass = System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(Application.StartupPath, dll + ".dll"));
                    var form = ass.CreateInstance(className) as Form;
                    if (form != null)
                    {
                        form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        form.WindowState = FormWindowState.Maximized;
                        form.Opacity = 0;
                        form.Show();

                        Bitmap image = new Bitmap(form.Width, form.Height);
                        form.DrawToBitmap(image, form.ClientRectangle);
                        form.Close();
                        this.pictureBox1.Image = image;
                    }
                }
                catch
                {
                    this.pictureBox1.Image = null;
                }
            }
            else
                this.pictureBox1.Image = null;
        }
        private void FormModuleImport_Load(object sender, EventArgs e)
        {
            this.LoadDeptAsync();
            this.LoadSystemsAsync();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var app = this.SelectedApp;

            this.LoadSystemsAsync(app != null ? app.Code : null);
        }
        private void btnAddSystem_Click(object sender, EventArgs e)
        {
            this.AddSystem();
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            string appCode = "";
            var app = this.SelectedApp;
            if (app != null)
                appCode = app.Code;
            if (appCode.IsNullOrWhiteSpace()) return;

            string pCode = "";
            var selectedRows = this.superGridControl1.GetSelectedRows();
            if (selectedRows != null && selectedRows.Count > 0)
            {
                var model = (selectedRows[0].Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Menu;
                pCode = model.MenuCode;
            }
            this.AddMenu(appCode, pCode);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.lbaSystem.Focused && this.lbaSystem.Visible)
            {
                this.EditSystem(this.lbaSystem.SelectedItem as ListBoxItem);
                return;
            }
            if (this.superGridControl1.Focused && this.superGridControl1.Visible)
            {
                var selectedRows = this.superGridControl1.GetSelectedRows();
                if (selectedRows == null || selectedRows.Count == 0) return;
                this.EditMenu(selectedRows[0] as GridRow);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lbaSystem.Focused && this.lbaSystem.Visible)
            {
                this.DeleteSystem(this.lbaSystem.SelectedItem as ListBoxItem);
                return;
            }
            if (this.superGridControl1.Focused && this.superGridControl1.Visible)
            {
                var selectedRows = this.superGridControl1.GetSelectedRows();
                if (selectedRows == null || selectedRows.Count == 0) return;
                this.DeleteMenu(selectedRows[0] as GridRow);
            }
        }
        /// <summary>
        /// 仅显示有效系统还是全部系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemShowAllOrValid(object sender, EventArgs e)
        {
            var cb = sender as DevComponents.DotNetBar.Controls.CheckBoxX;
            if (this.rbtnSystemAll.Checked != cb.Checked)
                this.LoadSystemsAsync();
        }
        /// <summary>
        /// 加载指定系统的菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbaSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var app = this.SelectedApp;
            if (app != null)
            {
                if (this.superTabControl1.SelectedTab == stabItemMenu)
                {
                    this.LoadMenusAsync(app.Code);
                }
                else if (this.superTabControl1.SelectedTab == stabItemDept)
                {
                    this.LoadDeptBySystem();
                }
                else if (this.superTabControl1.SelectedTab == stabItemHomepage)
                {
                    if (this.SelectedApp == null) return;
                    var homepage = CIS.Purview.SysAppDal.GetHomePage(this.SelectedApp.Code);
                    this.LoadHomePage(homepage.Item1, homepage.Item2);
                }
            }
        }
        /// <summary>
        /// 仅显示有效菜单还是全部菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuShowAllOrValid(object sender, EventArgs e)
        {
            var cb = sender as DevComponents.DotNetBar.Controls.CheckBoxX;
            if (this.rbtnMenuAll.Checked != cb.Checked)
            {
                if (this.SelectedApp != null)
                {
                    this.LoadMenusAsync(this.SelectedApp.Code);
                }
            }
        }

        private void superGridControl1_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            if (e.RowArea == RowArea.InCellExpand)
                return;
            this.EditMenu(this.superGridControl1.PrimaryGrid.GetSelectedRows()[0] as GridRow);
        }

        private void lbaSystem_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            this.EditSystem(this.lbaSystem.SelectedItem as ListBoxItem);
        }

        private void superTabControl1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            if (e.NewValue == this.stabItemDept)
            {
                this.LoadDeptBySystem();
            }
            else if (e.NewValue == this.stabItemMenu)
            {
                if (this.SelectedApp == null) return;
                this.LoadMenusAsync(this.SelectedApp.Code);
            }
            else
            {
                if (this.SelectedApp == null) return;
                var homepage = CIS.Purview.SysAppDal.GetHomePage(this.SelectedApp.Code);
                this.LoadHomePage(homepage.Item1, homepage.Item2);
            }
        }

        private void advTree1_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            if (e.Action == eTreeAction.Code) return;
            var curNode = e.Cell.Parent;
            this.UpdateNodeCheck(curNode, true);

            //设置选中的科室
            var depts = this.advTree1.CheckedNodes
                .Where(n => n.Tag is CIS.Model.IView_Dept)
                .Select(m => m.Tag as CIS.Model.IView_Dept).ToList();
            this.LoadDepts(depts);
            this.SaveDepts();
        }

        private void advTree1_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //防止点击到checkbox
                if (e.X > e.Node.Bounds.X + 10)
                {
                    e.Node.SetChecked(!e.Node.Checked, eTreeAction.Mouse);
                }
            }
        }

        private void lbaDept_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            var item = (this.lbaDept.SelectedItem as ListBoxItem);
            if (item != null)
            {
                var nodes = this.advTree1.Nodes.Find(item.Name, true);
                if (nodes != null && nodes.Length > 0)
                {
                    foreach (Node node in nodes)
                    {
                        node.SetChecked(false, eTreeAction.Mouse);
                    }
                }
            }
        }

        private void btnSetHomePage_Click(object sender, EventArgs e)
        {
            if (this.SelectedApp == null) return;

            using (FormModuleBrowser dialog = new FormModuleBrowser())
            {
                dialog.OnlyModule = true;
                dialog.OK += (x, y) =>
                {
                    if (dialog.Module == null) return;
                    CIS.Purview.SysAppDal.SetHomePage(this.SelectedApp.Code, dialog.Module.RNO, dialog.Module.FName);
                    this.LoadHomePage(dialog.Module.RNO, dialog.Module.FName);
                };
                dialog.ShowDialog();
            }
        }

        private void btnClearHomePage_Click(object sender, EventArgs e)
        {
            if (this.SelectedApp == null) return;
            if (CIS.Purview.SysAppDal.SetHomePage(this.SelectedApp.Code, null, null))
                this.pictureBox1.Image = null;
            else
                CIS.Core.AlertBox.Error("<b>错误</b> 清除不成功");

        }




    }
}
