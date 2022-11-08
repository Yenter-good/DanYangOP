using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevComponents.AdvTree;
using CIS.Model;
using CIS.Core;
using DevComponents.DotNetBar.SuperGrid;
using Dos.ORM;

namespace App_OP.SysSet.DearWithGroup
{
    public partial class FormDearWithGroup : Form
    {
        public FormDearWithGroup()
        {
            InitializeComponent();
        }


        List<OP_DearWithGroup> groupList = new List<OP_DearWithGroup>();//分类列表
        List<IView_HIS_DealWithItem> itemList = new List<IView_HIS_DealWithItem>();//项目列表
        List<IView_Inside_DealWithItem> relList = new List<IView_Inside_DealWithItem>();//分类关系表

        private void FormDearWithGroup_Shown(object sender, EventArgs e)
        {
            InitData();
            InitUI();
            InitTree();
        }
        private void InitData()
        {
            groupList = DBHelper.CIS.From<OP_DearWithGroup>().Where(x => x.Owner == SysContext.RunSysInfo.user.ID || x.Owner == SysContext.RunSysInfo.currDept.Code).OrderBy(p => p.No).ToList();
            itemList = DBHelper.CIS.From<IView_HIS_DealWithItem>().ToList();
            relList = DBHelper.CIS.FromSql("select * from IView_Inside_DealWithItem where GroupID in ( select ID from OP_DearWithGroup where Owner ='" +
                SysContext.RunSysInfo.currDept.Code + "' or Owner ='" + SysContext.RunSysInfo.user.ID + "') ORDER BY NO").ToList<IView_Inside_DealWithItem>();
        }

        private void RefreshGroup()
        {
            groupList = DBHelper.CIS.From<OP_DearWithGroup>().Where(x => x.Owner == SysContext.RunSysInfo.user.ID || x.Owner == SysContext.RunSysInfo.currDept.Code).OrderBy(p => p.No).ToList();
        }
        private void InitUI()
        {
            this.gridList.PrimaryGrid.DataSource = itemList;
            this.gridList.PrimaryGrid.AutoGenerateColumns = false;
            this.gridSubList.PrimaryGrid.AutoGenerateColumns = false;

            Application.DoEvents();//处理消息队列 清除界面堵塞
            this.gridList.PrimaryGrid.ClearSelectedCells();
        }

        private void InitTree()
        {
            foreach (Node node in treeGroup.Nodes)
            {
                node.Nodes.Clear();
            }
            List<OP_DearWithGroup> rootList = groupList.Where(x => x.ParentID == "0").OrderBy(x => x.No).ToList();
            foreach (OP_DearWithGroup item in rootList)
            {
                Node node = new Node();
                node.Text = item.Name;
                node.Tag = item;
                if (item.GroupType == 1)
                {
                    nodeDept.Nodes.Add(node);
                }
                else
                {
                    nodeUser.Nodes.Add(node);
                }

                CreateChildNode(node, item.ID);
            }
            treeGroup.ExpandAll();
        }

        private void CreateChildNode(Node parentNode, string parentCode)
        {
            List<OP_DearWithGroup> list = groupList.Where(x => x.ParentID == parentCode).OrderBy(x => x.No).ToList();
            if (list.Count < 1) return;
            foreach (OP_DearWithGroup item in list)
            {
                Node node = new Node();
                node.Text = item.Name;
                node.Tag = item;
                parentNode.Nodes.Add(node);
                CreateChildNode(node, item.ID);
            }

        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            GroupAdd();
        }

        private void GroupAdd()
        {
            FormAddGroup form = new FormAddGroup();
            form.status = "add";
            Node node = treeGroup.SelectedNode;
            if (node == null)
            {
                AlertBox.Error("请选中一个分类");
                return;
            }
            else if (node.TagString == "科室套餐" || node.TagString == "个人套餐")
            {
                form.parentID = "0";
                form.type = node.TagString == "科室套餐" ? 1 : 2;
            }
            else
            {
                OP_DearWithGroup temp = node.Tag as OP_DearWithGroup;
                if (relList.Where(x => x.GroupID == temp.ID).ToList().Count > 0)
                {
                    AlertBox.Error("该节点下有分类项目不可以再添加子节点！如有必要添加请先删除该节点后重新建立");
                    return;
                }

                form.parentID = temp.ID;
                form.type = (int)temp.GroupType;

            }
            form.ShowDialog();
            RefreshGroup();
            InitTree();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GroupEdit();
        }

        private void GroupEdit()
        {
            Node node = treeGroup.SelectedNode;
            if (node == null)
            {
                AlertBox.Error("请选中一个分类");
                return;
            }
            FormAddGroup form = new FormAddGroup();
            form.status = "edit";
            OP_DearWithGroup temp = node.Tag as OP_DearWithGroup;
            form.group = temp;
            form.parentID = temp.ID;
            form.ShowDialog();
            RefreshGroup();
            InitTree();
        }

        private void treeGroup_Click(object sender, EventArgs e)
        {
            Node node = treeGroup.GetNodeAt(treeGroup.PointToClient(MousePosition));
            if (node == null)
            {
                treeGroup.SelectedNode = null;
                return;
            }
            if (node.Tag == null || node.Tag.GetType() != typeof(OP_DearWithGroup)) return;

            //if (node.Nodes.Count > 0)
            //    node.Expanded = !node.Expanded;
            else
            {
                OP_DearWithGroup item = node.Tag as OP_DearWithGroup;
                List<IView_Inside_DealWithItem> subList = relList.Where(x => x.GroupID == item.ID).OrderBy((x => x.No)).ToList();
                gridSubList.PrimaryGrid.DataSource = subList;

                Application.DoEvents();//处理消息队列 清除界面堵塞
                foreach (GridRow item1 in this.gridSubList.PrimaryGrid.Rows)
                {
                    if (item1.Cells["gridSubList_Price"].Value.AsFloat(0) == 0)
                    {
                        item1.Cells["gridSubList_Price"].ReadOnly = false;
                        item1.Cells["gridSubList_Price"].CellStyles.Default.Background.Color1 = Color.FromArgb(255, 255, 255);
                        item1.Cells["gridSubList_Price"].CellStyles.Default.Background.Color2 = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        item1.Cells["gridSubList_Price"].ReadOnly = true;
                        item1.Cells["gridSubList_Price"].CellStyles.Default.Background.Color1 = Color.FromArgb(244, 244, 244);
                        item1.Cells["gridSubList_Price"].CellStyles.Default.Background.Color2 = Color.FromArgb(244, 244, 244);
                    }
                }
                gridSubList.PrimaryGrid.ClearSelectedCells();
            }
        }

        private void btnDelGroup_Click(object sender, EventArgs e)
        {
            GroupDel();
        }

        private void GroupDel()
        {
            Node node = treeGroup.SelectedNode;
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
            OP_DearWithGroup temp = node.Tag as OP_DearWithGroup;

            DelNodeHasDetail(node);//删除节点下项目明细

            int i = DBHelper.CIS.Delete<OP_DearWithGroup>(temp);

            if (i > 0)
                AlertBox.Info("删除成功");
            else
                AlertBox.Error("删除失败");

            RefreshGroup();
            InitTree();
            gridSubList.PrimaryGrid.DataSource = null;
        }
        private void DelNodeHasDetail(Node parentNode)
        {
            OP_DearWithGroup rootGroup = parentNode.Tag as OP_DearWithGroup;
            DBHelper.CIS.Delete<OP_DearWithGroup_Detail>(OP_DearWithGroup_Detail._.GroupID == rootGroup.ID);

            foreach (Node node in parentNode.Nodes)
            {
                OP_DearWithGroup temp = node.Tag as OP_DearWithGroup;
                DBHelper.CIS.Delete<OP_DearWithGroup_Detail>(OP_DearWithGroup_Detail._.GroupID == temp.ID);
                DelNodeHasDetail(node);
            }
        }

        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            ItemAdd();
        }

        private void ItemAdd()
        {
            Node node = treeGroup.SelectedNode;
            if (node == null)
            {
                AlertBox.Error("请选中一个分类");
                return;
            }
            OP_DearWithGroup group = node.Tag as OP_DearWithGroup;
         
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

            SelectedElementCollection rows = gridList.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }
            int errorNumber = 0;
            int rowIndex = gridSubList.PrimaryGrid.Rows.Count + 1;
            foreach (GridRow row in rows)
            {
                string code = row[0].Value.ToString();
                //float price = row[2].Value.AsFloat(0);
                if (relList.Where(x => x.GroupID == group.ID && x.Code == code).ToList().Count > 0)
                    continue;

                OP_DearWithGroup_Detail item = new OP_DearWithGroup_Detail();
                item.GroupID = group.ID;
                item.ID = Guid.NewGuid().ToString();
                item.ItemID = code;
                item.Number = Convert.ToInt32(tbxNumber.Text);
                item.No = rowIndex;
                //item.Price = price;
                item.Owner = group.GroupType == 1 ? SysContext.RunSysInfo.currDept.Code : SysContext.RunSysInfo.user.ID;
                int i = DBHelper.CIS.Insert<OP_DearWithGroup_Detail>(item);
                if (i < 1)
                    errorNumber++;

                rowIndex++;
            }

            if (errorNumber == 0)
                AlertBox.Info("保存成功");
            else
                AlertBox.Error("有" + errorNumber + "条记录保存失败");
            tbxNumber.Text = "1";
            RefreshDetail();
        }

        private void btnItemDel_Click(object sender, EventArgs e)
        {
            ItemDel();
        }

        private void ItemDel()
        {
            SelectedElementCollection rows = gridSubList.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }

            int errorNumber = 0;
            foreach (GridRow row in rows)
            {
                string ID = row[0].Value.ToString();
                int i = DBHelper.CIS.Delete<OP_DearWithGroup_Detail>(OP_DearWithGroup_Detail._.ID == ID);

                if (i < 1)
                    errorNumber++;
            }

            if (errorNumber == 0)
                AlertBox.Info("删除成功");
            else
                AlertBox.Error(errorNumber + "条记录删除失败");
            RefreshDetail();
        }
        private void RefreshDetail()
        {
            relList = DBHelper.CIS.From<IView_Inside_DealWithItem>().ToList();
            Node node = treeGroup.SelectedNode;
            if (node == null)
                return;
            OP_DearWithGroup item = node.Tag as OP_DearWithGroup;
            relList = DBHelper.CIS.FromSql("select * from IView_Inside_DealWithItem where GroupID in ( select ID from OP_DearWithGroup where Owner ='" +
               SysContext.RunSysInfo.currDept.Code + "' or Owner ='" + SysContext.RunSysInfo.user.ID + "')").ToList<IView_Inside_DealWithItem>();
            gridSubList.PrimaryGrid.DataSource = relList.Where(x => x.GroupID == item.ID).OrderBy((x => x.No)).ToList();

            Application.DoEvents();//处理消息队列 清除界面堵塞
            this.gridSubList.PrimaryGrid.ClearSelectedCells();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GroupAdd();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            GroupEdit();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            GroupDel();
        }

        private void btnAddItem_R_Click(object sender, EventArgs e)
        {
            ItemAdd();
        }

        private void btnDelItem_R_Click(object sender, EventArgs e)
        {
            ItemDel();
        }

        private void tbxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 31 && (e.KeyChar < '0' || e.KeyChar > '9')) { e.Handled = true; }
        }

        private void gridList_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            ItemAdd();
        }

        private void ItemMove(string type)
        {
            SelectedElementCollection rows = gridSubList.GetSelectedRows();
            if (rows.Count != 1)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }

            int move = type == "Up" ? -1 : 1;//移动方向 Up 时-1 Down 时 +1

            GridRow row = rows[0] as GridRow;
            IView_Inside_DealWithItem item = row.DataItem as IView_Inside_DealWithItem;

            if (type == "Up" && row.RowIndex == 0) return;
            if (type == "Down" && row.RowIndex == row.GridPanel.Rows.Count - 1) return;

            GridRow otherRow = row.GridPanel.Rows[row.RowIndex + move] as GridRow;
            IView_Inside_DealWithItem otherItem = otherRow.DataItem as IView_Inside_DealWithItem;

            var tran = DBHelper.CIS.BeginTransaction();
            DBHelper.CIS.ExecuteTransaction(tran, d =>
            {
                tran.Update<OP_DearWithGroup_Detail>(OP_DearWithGroup_Detail._.No, item.No + move, OP_DearWithGroup_Detail._.ID == item.ID);
                tran.Update<OP_DearWithGroup_Detail>(OP_DearWithGroup_Detail._.No, otherItem.No - move, OP_DearWithGroup_Detail._.ID == otherItem.ID);
            });

            RefreshDetail();
            Application.DoEvents();
            gridSubList.PrimaryGrid.SetSelectedRows(row.RowIndex + move, 1, true);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            ItemMove("Up");
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            ItemMove("Down");
        }

        private void btnUp_R_Click(object sender, EventArgs e)
        {
            ItemMove("Up");
        }

        private void btnDown_R_Click(object sender, EventArgs e)
        {
            ItemMove("Down");
        }

        private void gridSubList_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            ItemDel();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string text = tbxSearch.Text.Trim();
            if (text.Length == 0)
                gridList.PrimaryGrid.DataSource = itemList;
            else
                gridList.PrimaryGrid.DataSource = itemList.Where(x => x.SearchCode.AsNotNullString().ToUpper().Contains(text.ToUpper()) ||
                    x.Name.AsNotNullString().Contains(text) ||
                    x.WubiCode.AsNotNullString().ToUpper().ToUpper().Contains(text.ToUpper())).ToList();
            Application.DoEvents();//处理消息队列 清除界面堵塞
            gridList.PrimaryGrid.ClearSelectedCells();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (GridRow row in this.gridSubList.PrimaryGrid.Rows)
            {
                string ID = row[0].Value.ToString();
                OP_DearWithGroup_Detail detail = new OP_DearWithGroup_Detail();
                detail.Price = row[2].Value.AsFloat(0);
                DBHelper.CIS.Update<OP_DearWithGroup_Detail>(detail, p => p.ID == ID);
            }
            AlertBox.Info("保存成功");
        }

    }
}
