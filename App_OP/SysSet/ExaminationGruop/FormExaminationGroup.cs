using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevComponents.AdvTree;
using CIS.Model;
using CIS.Core;
using DevComponents.DotNetBar.SuperGrid;
using Dos.ORM;

namespace App_OP.SysSet.ExaminationGruop
{
    public partial class FormExaminationGroup : Form
    {
        public FormExaminationGroup()
        {
            InitializeComponent();
        }


        List<IView_Inside_ExamineGroup> groupList = new List<IView_Inside_ExamineGroup>();//分类列表
        List<IView_HIS_ExamineItem> itemList = new List<IView_HIS_ExamineItem>();//检验检查项目列表
        List<IView_Inside_ExamineDetail> relList = new List<IView_Inside_ExamineDetail>();//分类关系表

        List<IView_HIS_ExamineItem> jyList = new List<IView_HIS_ExamineItem>();
        List<IView_HIS_ExamineItem> jcList = new List<IView_HIS_ExamineItem>();
        
        
        private void FormExaminationGroup_Shown(object sender, EventArgs e)
        {
            InitData();
            InitUI();
            InitTree(treeJyGroup, "jy");
            InitTree(treeJcGroup, "jc");
        }

        private void InitData()
        {
            groupList = DBHelper.CIS.From<IView_Inside_ExamineGroup>().Where(x => x.GroupLevel < 3).ToList();//只取全院 门诊 住院
            itemList = DBHelper.CIS.From<IView_HIS_ExamineItem>().ToList();
            relList = DBHelper.CIS.From<IView_Inside_ExamineDetail>().ToList();
        }

        private void InitUI()
        {
            jyList = itemList.Where(x => x.ItemType == "jy").ToList();
            this.gridJyList.PrimaryGrid.DataSource = jyList;
            this.gridJyList.PrimaryGrid.AutoGenerateColumns = false;
            jcList = itemList.Where(x => x.ItemType == "jc").ToList();
            this.gridJcList.PrimaryGrid.DataSource = jcList;
            this.gridJcList.PrimaryGrid.AutoGenerateColumns = false;

            this.gridJySubList.PrimaryGrid.AutoGenerateColumns = false;
            this.gridJcSubList.PrimaryGrid.AutoGenerateColumns = false;

            Application.DoEvents();//处理消息队列 清除界面堵塞
            this.gridJyList.PrimaryGrid.ClearSelectedCells();
            this.gridJcList.PrimaryGrid.ClearSelectedCells();
        }


        #region 分类节点相关操作
        private void RefreshGroup()
        {
            groupList = DBHelper.CIS.From<IView_Inside_ExamineGroup>().Where(x => x.GroupLevel < 3).ToList();
        }

        private void RefreshDetail(AdvTree tree, SuperGridControl grid)
        {
            relList = DBHelper.CIS.From<IView_Inside_ExamineDetail>().ToList();
            Node node = tree.SelectedNode;
            if (node == null) 
                return;

            LoadSubItem(grid, node);

        }

        private void LoadSubItem(SuperGridControl grid, Node node)
        {
            IView_Inside_ExamineGroup item = node.Tag as IView_Inside_ExamineGroup;
            List<IView_Inside_ExamineDetail> subList = relList.Where(x => x.GroupID == item.ID).OrderBy((x => x.No)).ToList();
            grid.PrimaryGrid.DataSource = subList;

            Application.DoEvents();//处理消息队列 清除界面堵塞
            grid.PrimaryGrid.ClearSelectedCells();
        }

        private void InitTree(AdvTree tree, string type)
        {
            tree.Nodes.Clear();
            List<IView_Inside_ExamineGroup> rootList = groupList.Where(x => x.GroupType == type && x.ParentID == "0").OrderBy(x => x.No).ToList();
            foreach (IView_Inside_ExamineGroup item in rootList)
            {
                Node node = new Node();
                node.Text = item.Name;
                node.Tag = item;
                tree.Nodes.Add(node);
                CreateChildNode(node, item.ID);
            }
            tree.ExpandAll();
        }

        private void CreateChildNode(Node parentNode, string parentCode)
        {
            List<IView_Inside_ExamineGroup> list = groupList.Where(x => x.ParentID == parentCode).OrderBy(x => x.No).ToList();
            if (list.Count < 1) return;
            foreach (IView_Inside_ExamineGroup item in list)
            {
                Node node = new Node();
                node.Text = item.Name;
                node.Tag = item;
                parentNode.Nodes.Add(node);
                CreateChildNode(node, item.ID);
            }

        }
        //新增节点
        private void GroupAdd(AdvTree tree, string type)
        {
            FormAddGroup form = new FormAddGroup();
            form.status = "add";
            form.type = type;
            Node node = tree.SelectedNode;
            if (node == null)
            {
                form.parentID = "0";
            }
            else
            {
                IView_Inside_ExamineGroup temp = node.Tag as IView_Inside_ExamineGroup;
                if (relList.Where(x => x.GroupID == temp.ID).ToList().Count > 0)
                {
                    AlertBox.Error("该节点下有分类项目不可以再添加子节点！如有必要添加请先删除该节点后重新建立");
                    return;
                }

                form.parentID = temp.ID;
            }
            form.ShowDialog();
            RefreshGroup();
            InitTree(tree, type);
        }
        //编辑节点
        private void GroupEdit(AdvTree tree, string type)
        {
            Node node = tree.SelectedNode;
            if (node == null)
            {
                AlertBox.Error("请选中一个分类");
                return;
            }
            FormAddGroup form = new FormAddGroup();
            form.status = "edit";
            IView_Inside_ExamineGroup temp = node.Tag as IView_Inside_ExamineGroup;
            form.group = temp;
            form.parentID = temp.ID;
            form.ShowDialog();
            RefreshGroup();
            InitTree(tree, type);
        }
        //删除节点
        private void GroupDel(AdvTree tree, string type,SuperGridControl refreshGrid)
        {
            Node node = tree.SelectedNode;
            if (node == null)
            {
                AlertBox.Error("请选中一个分类");
                return;
            }
            if (node.Parent == null)
            {
                AlertBox.Error("该节点不可删除");
                return;
            }

            IView_Inside_ExamineGroup temp = node.Tag as IView_Inside_ExamineGroup;

            DelNodeHasDetail(node);//删除节点下项目明细

            int i = DBHelper.CIS.Delete<IView_Inside_ExamineGroup>(temp);
            if (i > 0) 
                AlertBox.Info("删除成功");
            else
                AlertBox.Error("删除失败");

            RefreshGroup();
            InitTree(tree, type);
            refreshGrid.PrimaryGrid.DataSource = null;


        }

        //删除节点下项目（删除IView_Inside_ExamineGroup_Detail表中数据）
        private void DelNodeHasDetail(Node parentNode)
        {
            IView_Inside_ExamineGroup rootGroup = parentNode.Tag as IView_Inside_ExamineGroup;
            DBHelper.CIS.Delete<IView_Inside_ExamineGroup_Detail>(IView_Inside_ExamineGroup_Detail._.GroupID == rootGroup.ID);

            foreach (Node node in parentNode.Nodes)
            {
                IView_Inside_ExamineGroup temp = node.Tag as IView_Inside_ExamineGroup;
                DBHelper.CIS.Delete<IView_Inside_ExamineGroup_Detail>(IView_Inside_ExamineGroup_Detail._.GroupID == temp.ID);
                DelNodeHasDetail(node);
            }
        }
        //点击树节点
        private void NodeClick(AdvTree tree,SuperGridControl grid)
        {
            Node node = tree.GetNodeAt(tree.PointToClient(MousePosition));
            if (node == null)
            {
                tree.SelectedNode = null;
                return;
            }

            node.Expanded = !node.Expanded;
            LoadSubItem(grid, node);
        }

        #endregion


        #region 分类包含项目相关操作
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tree">左侧正在操作的tree</param>
        /// <param name="grid">正在操作的检验检查项目列表grid</param>
        /// <param name="refreshGrid">需要刷新的grid</param>
        private void ItemAdd(AdvTree tree, SuperGridControl grid,SuperGridControl refreshGrid)
        {
            Node node = tree.SelectedNode;
            IView_Inside_ExamineGroup group = node.Tag as IView_Inside_ExamineGroup;
            if (node == null)
            {
                AlertBox.Error("请选中一个分类");
                return;
            } 
            if (group == null)
            {
                AlertBox.Error("该分类下不允许直接添加明细项目。请新建一个分类！");
                return;
            }
            if (node.Nodes.Count > 0)
            {
                AlertBox.Error("不是最终节点不允许添加明细");
                return;
            }
            SelectedElementCollection rows = grid.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }
            int rowIndex = refreshGrid.PrimaryGrid.Rows.Count + 1;
            int errorNumber=0;
            foreach (GridRow row in rows)
            {
                string code = row[0].Value.ToString();
                if (relList.Where(x => x.GroupID == group.ID && x.Code == code).ToList().Count > 0)
                    continue;

                IView_Inside_ExamineGroup_Detail item = new IView_Inside_ExamineGroup_Detail();
                item.GroupID = group.ID;
                item.ID = Guid.NewGuid().ToString();
                item.ItemID = code;
                item.No = rowIndex;
                rowIndex++;
                int i = DBHelper.CIS.Insert<IView_Inside_ExamineGroup_Detail>(item);
                if (i < 1)
                    errorNumber++;
            }

            if (errorNumber == 0)
                AlertBox.Info("保存成功");
            else
                AlertBox.Error("有" + errorNumber + "条记录保存失败");
            RefreshDetail(tree, refreshGrid);

        }

        private void ItemDel(AdvTree tree, SuperGridControl grid)
        {
            SelectedElementCollection rows = grid.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }
            
            int errorNumber=0;
            foreach (GridRow row in rows)
            {
                string ID = row[0].Value.ToString();
                int i = DBHelper.CIS.Delete<IView_Inside_ExamineGroup_Detail>(IView_Inside_ExamineGroup_Detail._.ID == ID);

                if (i < 1)
                    errorNumber++;
            }

            if (errorNumber == 0)
                AlertBox.Info("删除成功");
            else
                AlertBox.Error(errorNumber + "条记录删除失败");
            RefreshDetail(tree, grid);
        }
        #endregion

        #region 检验
        private void btnJyAddGroup_Click(object sender, EventArgs e)
        {
            GroupAdd(treeJyGroup,"jy");
        }
        private void btnJyEdit_Click(object sender, EventArgs e)
        {
            GroupEdit(treeJyGroup,"jy");
        }
        private void btnJyDelGroup_Click(object sender, EventArgs e)
        {
            GroupDel(treeJyGroup, "jy",gridJySubList);
        }
        private void treeJyGroup_Click(object sender, EventArgs e)
        {
            NodeClick(treeJyGroup,gridJySubList);
        }
        private void btnJyAdd_Click(object sender, EventArgs e)
        {
            ItemAdd(treeJyGroup, gridJyList,gridJySubList);
        }

        private void btnJyDel_Click(object sender, EventArgs e)
        {
            ItemDel(treeJyGroup,gridJySubList);
        }
        private void tbxJySearch_TextChanged(object sender, EventArgs e)
        {
            string text = tbxJySearch.Text.Trim();
            if (text.Length == 0)
                gridJyList.PrimaryGrid.DataSource = jyList;
            else
                gridJyList.PrimaryGrid.DataSource = jyList.Where(x => x.SearchCode.AsNotNullString().ToUpper().Contains(text.ToUpper()) ||
                    x.Name.AsNotNullString().Contains(text) ||
                    x.WubiCode.AsNotNullString().ToUpper().Contains(text.ToUpper())).ToList();
            Application.DoEvents();//处理消息队列 清除界面堵塞
            gridJyList.PrimaryGrid.ClearSelectedCells();
        }

        private void treeJyGroup_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            GroupEdit(treeJyGroup, "jy");
        }

        #endregion

        #region 检查
        private void btnJcAddGroup_Click(object sender, EventArgs e)
        {
            GroupAdd(treeJcGroup, "jc");
        }
        private void btnJcEdit_Click(object sender, EventArgs e)
        {
            GroupEdit(treeJcGroup, "jc");
        }

        private void btnJcDelGroup_Click(object sender, EventArgs e)
        {
            GroupDel(treeJcGroup, "jc",gridJcSubList);
        }
        private void treeJcGroup_Click(object sender, EventArgs e)
        {
            NodeClick(treeJcGroup,gridJcSubList);
        }


        private void txtJcSearch_TextChanged(object sender, EventArgs e)
        {
            string text = tbxJcSearch.Text.Trim();
            if (text.Length == 0)
                gridJcList.PrimaryGrid.DataSource = jcList;
            else
                gridJcList.PrimaryGrid.DataSource = jcList.Where(x => x.SearchCode.AsNotNullString().ToUpper().Contains(text.ToUpper()) || x.Name.AsNotNullString().Contains(text)).ToList();
            Application.DoEvents();//处理消息队列 清除界面堵塞
            gridJcList.PrimaryGrid.ClearSelectedCells();
        }
        private void btnJcDel_Click(object sender, EventArgs e)
        {
            ItemDel(treeJcGroup,gridJcSubList);
        }

        private void btnJcAdd_Click(object sender, EventArgs e)
        {
            ItemAdd(treeJcGroup, gridJcList,gridJcSubList);
        }
        private void treeJcGroup_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            GroupEdit(treeJcGroup, "jc");
        }

        #endregion

        #region 右键菜单
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabItem1"])
                GroupAdd(treeJyGroup, "jy");
            else
                GroupAdd(treeJcGroup, "jc");
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabItem1"])
                GroupEdit(treeJyGroup, "jy");
            else
                GroupEdit(treeJcGroup, "jc");
        }
        private void btnDelGroup_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabItem1"])
                GroupDel(treeJyGroup, "jy", gridJySubList);
            else
                GroupDel(treeJcGroup, "jc", gridJcSubList);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabItem1"])
                ItemAdd(treeJyGroup, gridJyList, gridJySubList);
            else
                ItemAdd(treeJcGroup, gridJcList, gridJcSubList);
        }

        private void btnDelItem_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabItem1"])
                ItemDel(treeJyGroup, gridJySubList);
            else
                ItemDel(treeJcGroup, gridJcSubList);
        }

        private void btnUp_R_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabItem1"])
                ItemMove(treeJyGroup, gridJySubList, "Up");
            else
                ItemMove(treeJcGroup, gridJcSubList, "Up");
        }

        private void btnDown_R_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabItem1"])
                ItemMove(treeJyGroup, gridJySubList, "Down");
            else
                ItemMove(treeJcGroup, gridJcSubList, "Down");
        }

        #endregion
        private void btnJyUp_Click(object sender, EventArgs e)
        {
            ItemMove(treeJyGroup, gridJySubList, "Up");
        }

        private void btnJyDown_Click(object sender, EventArgs e)
        {
            ItemMove(treeJyGroup, gridJySubList, "Down");
        }
        
        private void btnJcUp_Click(object sender, EventArgs e)
        {
            ItemMove(treeJcGroup, gridJcSubList, "Up");
        }

        private void btnJcDown_Click(object sender, EventArgs e)
        {
            ItemMove(treeJcGroup, gridJcSubList, "Down");
        }

       

        

        private void ItemMove(AdvTree tree, SuperGridControl grid,string type)
        {
            SelectedElementCollection rows = grid.GetSelectedRows();
            if (rows.Count != 1)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }

            int move = type == "Up" ? -1 : 1;//移动方向 Up 时-1 Down 时 +1

            GridRow row = rows[0] as GridRow;
            IView_Inside_ExamineDetail item = row.DataItem as IView_Inside_ExamineDetail;

            if (type == "Up" && row.RowIndex == 0) return;
            if (type == "Down" && row.RowIndex == row.GridPanel.Rows.Count - 1) return;

            GridRow otherRow = row.GridPanel.Rows[row.RowIndex + move] as GridRow;
            IView_Inside_ExamineDetail otherItem = otherRow.DataItem as IView_Inside_ExamineDetail;
            //用事务进行操作
            var tran = DBHelper.CIS.BeginTransaction();
            DBHelper.CIS.ExecuteTransaction(tran,d =>
            {
                tran.Update<IView_Inside_ExamineGroup_Detail>(IView_Inside_ExamineGroup_Detail._.No, item.No + move, IView_Inside_ExamineGroup_Detail._.ID == item.ID);
                tran.Update<IView_Inside_ExamineGroup_Detail>(IView_Inside_ExamineGroup_Detail._.No, otherItem.No - move, IView_Inside_ExamineGroup_Detail._.ID == otherItem.ID);
               
            });

            RefreshDetail(tree,grid);

            Application.DoEvents();
            grid.PrimaryGrid.SetSelectedRows(row.RowIndex + move, 1, true);
        }

        private void gridJySubList_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            ItemDel(treeJyGroup, gridJySubList);
        }

        private void gridJcSubList_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            ItemDel(treeJcGroup, gridJcSubList);
        }

        private void gridJyList_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            ItemAdd(treeJyGroup, gridJyList, gridJySubList);
        }

        private void gridJcList_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            ItemAdd(treeJcGroup, gridJcList, gridJcSubList);
        }


       















    }
}
