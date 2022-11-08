using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevComponents.AdvTree;
using CIS.Model;
using CIS.Core;
using DevComponents.DotNetBar.SuperGrid;

namespace App_OP.SysSet.ExaminationGruop
{
    public partial class FormCommonExamination : Form
    {
        public FormCommonExamination()
        {
            InitializeComponent();
        }


        List<IView_Inside_ExamineGroup> groupList = new List<IView_Inside_ExamineGroup>();//分类列表
        List<IView_Inside_ExamineDetail> relList = new List<IView_Inside_ExamineDetail>();//分类关系表
        List<IView_Inside_ExamineDetail> ownerList = new List<IView_Inside_ExamineDetail>();//当前科室或操作人员所拥有的常用项目

        List<IView_Inside_ExamineDetail> relUserList = new List<IView_Inside_ExamineDetail>();
        List<IView_Inside_ExamineDetail> relDeptList = new List<IView_Inside_ExamineDetail>();

        List<IView_Inside_ExamineDetail> currJySubList = new List<IView_Inside_ExamineDetail>();
        List<IView_Inside_ExamineDetail> currJcSubList = new List<IView_Inside_ExamineDetail>();

        IView_Inside_ExamineGroup jyDeptCommon = new IView_Inside_ExamineGroup();//检验科室常用节点
        IView_Inside_ExamineGroup jcDeptCommon = new IView_Inside_ExamineGroup();//检查科室常用节点
        IView_Inside_ExamineGroup jyUserCommon = new IView_Inside_ExamineGroup();//检验个人常用节点
        IView_Inside_ExamineGroup jcUserCommon = new IView_Inside_ExamineGroup();//检查个人常用节点
        

        private void FormCommonExamination_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SysContext.RunSysInfo.user.ID) || string.IsNullOrWhiteSpace(SysContext.RunSysInfo.currDept.Code))
            {
                MsgBox.OK("系统未加载到当前科室或当前操作员请联系管理员！");
                return;
            }

            InitData();
            InitUI();
            InitTree(treeJyGroup, "jy");
            InitTree(treeJcGroup, "jc");
        }

        #region 加载界面及数据
        private void InitData()
        {
            List<IView_Inside_ExamineGroup> allGroupList =  DBHelper.CIS.From<IView_Inside_ExamineGroup>().ToList();//所有分类包含个人和科室
            groupList = allGroupList.Where(x => x.GroupLevel < 3).ToList();//只取全院 门诊 住院
            relList = DBHelper.CIS.From<IView_Inside_ExamineDetail>().Where(x => x.Owner == null).ToList();
            jyDeptCommon = allGroupList.Where(x=>x.ID=="1000001").ToList()[0];
            jyUserCommon = allGroupList.Where(x=>x.ID=="1000002").ToList()[0];
            jcDeptCommon = allGroupList.Where(x=>x.ID=="1000003").ToList()[0];
            jcUserCommon = allGroupList.Where(x=>x.ID=="1000004").ToList()[0];
            ownerList = DBHelper.CIS.From<IView_Inside_ExamineDetail>().Where(x => x.Owner == SysContext.RunSysInfo.currDept.Code || x.Owner == SysContext.RunSysInfo.user.ID).ToList();
            relUserList = ownerList.Where(x => x.Owner == SysContext.RunSysInfo.user.ID).ToList();
            relDeptList = ownerList.Where(x => x.Owner == SysContext.RunSysInfo.currDept.Code).ToList();
        }
        private void InitUI()
        {
            gridJySubList_D.PrimaryGrid.DataSource = relDeptList.Where(x => x.ItemType == "jy").ToList();
            gridJcSubList_D.PrimaryGrid.DataSource = relDeptList.Where(x => x.ItemType == "jc").ToList();
            gridJySubList_P.PrimaryGrid.DataSource = relUserList.Where(x => x.ItemType == "jy").ToList();
            gridJcSubList_P.PrimaryGrid.DataSource = relUserList.Where(x => x.ItemType == "jc").ToList();
           
            gridJySubList_D.PrimaryGrid.AutoGenerateColumns = false;
            gridJcSubList_D.PrimaryGrid.AutoGenerateColumns = false;

            gridJySubList_P.PrimaryGrid.AutoGenerateColumns = false;
            gridJcSubList_P.PrimaryGrid.AutoGenerateColumns = false;
           
            gridJyList.PrimaryGrid.AutoGenerateColumns = false;
            gridJcList.PrimaryGrid.AutoGenerateColumns = false;

            Application.DoEvents();//处理消息队列 清除界面堵塞
            gridJySubList_D.PrimaryGrid.ClearSelectedCells();
            gridJcSubList_D.PrimaryGrid.ClearSelectedCells();
            gridJySubList_P.PrimaryGrid.ClearSelectedCells();
            gridJcSubList_P.PrimaryGrid.ClearSelectedCells();
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
        private void NodeSelect(Node node, SuperGridControl grid, List<IView_Inside_ExamineDetail> list, string type)
        {
            IView_Inside_ExamineGroup group = node.Tag as IView_Inside_ExamineGroup;
            List<IView_Inside_ExamineDetail> subList = list.Where(x => x.GroupID == group.ID).ToList();
            grid.PrimaryGrid.DataSource = subList;
            grid.PrimaryGrid.AutoGenerateColumns = false;

            if (type == "jy")
            {
                this.currJySubList = subList;
            }
            else
            {
                this.currJcSubList = subList;
            }
            Application.DoEvents();//处理消息队列 清除界面堵塞
            grid.PrimaryGrid.ClearSelectedCells();
        }
     


        #endregion

        #region 添加删除明细
        private void RefreshSubList()
        {
            ownerList = DBHelper.CIS.From<IView_Inside_ExamineDetail>().Where(x => x.Owner == SysContext.RunSysInfo.currDept.Code || x.Owner == SysContext.RunSysInfo.user.ID).ToList();
            relUserList = ownerList.Where(x => x.Owner == SysContext.RunSysInfo.user.ID).ToList();
            relDeptList = ownerList.Where(x => x.Owner == SysContext.RunSysInfo.currDept.Code).ToList();

            gridJySubList_D.PrimaryGrid.DataSource = relDeptList.Where(x => x.ItemType == "jy").ToList();
            gridJcSubList_D.PrimaryGrid.DataSource = relDeptList.Where(x => x.ItemType == "jc").ToList();
            gridJySubList_P.PrimaryGrid.DataSource = relUserList.Where(x => x.ItemType == "jy").ToList();
            gridJcSubList_P.PrimaryGrid.DataSource = relUserList.Where(x => x.ItemType == "jc").ToList();

            Application.DoEvents();//处理消息队列 清除界面堵塞
            gridJySubList_D.PrimaryGrid.ClearSelectedCells();
            gridJcSubList_D.PrimaryGrid.ClearSelectedCells();
            gridJySubList_P.PrimaryGrid.ClearSelectedCells();
            gridJcSubList_P.PrimaryGrid.ClearSelectedCells();

        }

        private void ItemAdd(SuperGridControl grid,IView_Inside_ExamineGroup group)
        {
            SelectedElementCollection rows = grid.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }
            int errorNumber = 0;
            foreach (GridRow row in rows)
            {
                string code = row[0].Value.ToString();
                if (relList.Where(x => x.GroupID == group.ID && x.Code == code).ToList().Count > 0)
                    continue;
                IView_Inside_ExamineGroup_Detail item = new IView_Inside_ExamineGroup_Detail();
                item.GroupID = group.ID;
                item.ID = Guid.NewGuid().ToString();
                item.ItemID = code;
                if (group.GroupLevel == 3)
                {
                    item.Owner = SysContext.RunSysInfo.currDept.Code;
                }
                if (group.GroupLevel == 4)
                {
                    item.Owner = SysContext.RunSysInfo.user.ID;
                }
                int i = DBHelper.CIS.Insert<IView_Inside_ExamineGroup_Detail>(item);
                if (i < 1)
                    errorNumber++;
            }

            if (errorNumber == 0)
                AlertBox.Info("保存成功");
            else
                AlertBox.Error(errorNumber + "条记录保存失败");

            RefreshSubList();
        }
        private void ItemDel(SuperGridControl grid)
        {
            SelectedElementCollection rows = grid.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }

            int errorNumber = 0;
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

            RefreshSubList();
        }
        private void treeJyGroup_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            NodeSelect(e.Node, gridJyList, relList, "jy");
        }

        private void treeJcGroup_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            NodeSelect(e.Node, gridJcList, relList,"jc");
        }

        private void btnJyAdd_D_Click(object sender, EventArgs e)
        {
            ItemAdd(gridJyList, jyDeptCommon);
        }
        private void btnJyAdd_P_Click(object sender, EventArgs e)
        {
            ItemAdd(gridJyList, jyUserCommon);
        }
        private void btnJcAdd_D_Click(object sender, EventArgs e)
        {
            ItemAdd(gridJcList, jcDeptCommon);
        }
        private void btnJcAdd_P_Click(object sender, EventArgs e)
        {
            ItemAdd(gridJcList, jcUserCommon);
        }
        private void btnJyDel_D_Click(object sender, EventArgs e)
        {
            ItemDel(gridJySubList_D);
        }
        private void btnJyDel_P_Click(object sender, EventArgs e)
        {
            ItemDel(gridJySubList_P);
        }
        private void btnJcDel_D_Click(object sender, EventArgs e)
        {
            ItemDel(gridJcSubList_D);
        }
        private void btnJcDel_P_Click(object sender, EventArgs e)
        {
            ItemDel(gridJcSubList_P);
        }
        private void SearchItemList(string text, Node node, SuperGridControl grid, List<IView_Inside_ExamineDetail> list)
        {
            if (text.Trim().Length < 1)
                grid.PrimaryGrid.DataSource = list;
            IView_Inside_ExamineGroup group = node.Tag as IView_Inside_ExamineGroup;
            List<IView_Inside_ExamineDetail> subList = list.Where(x => x.GroupID == group.ID && x.SearchCode.AsNotNullString().ToUpper().Contains(text.ToUpper()) || x.WubiCode.AsNotNullString().ToUpper().Contains(text.ToUpper())).ToList();
            grid.PrimaryGrid.DataSource = subList;
        }
        private void tbxJySearch_TextChanged(object sender, EventArgs e)
        {
            SearchItemList(tbxJySearch.Text, treeJyGroup.SelectedNode, gridJyList, currJySubList);
        }

        private void tbxJcSearch_TextChanged(object sender, EventArgs e)
        {
            SearchItemList(tbxJcSearch.Text, treeJcGroup.SelectedNode, gridJcList, currJcSubList);
        }

        #endregion

        #region 右键菜单

        private void btnAdd_D_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabItem1"])
                ItemAdd(gridJyList, jyDeptCommon);
            else
                ItemAdd(gridJcList, jcDeptCommon);

        }

        private void btnAdd_P_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabItem1"])
                ItemAdd(gridJyList, jyUserCommon);
            else
                ItemAdd(gridJcList, jcUserCommon);
        }

        private void btnDel_D_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabItem1"])
                ItemDel(gridJySubList_D);
            else
                ItemDel(gridJcSubList_D);
            
        }

        private void btnDel_P_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabItem1"])
                ItemDel(gridJySubList_P);
            else
                ItemDel(gridJcSubList_P);
        }

        #endregion

        private void gridJySubList_D_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            ItemDel(gridJySubList_D);
        }

        private void gridJySubList_P_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            ItemDel(gridJySubList_P);
        }

        private void gridJcSubList_D_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            ItemDel(gridJcSubList_D);
        }

        private void gridJcSubList_P_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            ItemDel(gridJcSubList_P);
        }


    }
}
