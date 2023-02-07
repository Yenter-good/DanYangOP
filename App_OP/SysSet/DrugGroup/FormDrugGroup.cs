using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;
using System.Text.RegularExpressions;
using DevComponents.DotNetBar.Controls;
using System.Drawing;
using Dos.ORM;

namespace App_OP
{
    public partial class FormDrugGroup : Form
    {
        public FormDrugGroup()
        {
            InitializeComponent();
        }

        List<OP_DrugGroup> groupList = new List<OP_DrugGroup>();//分类列表
        List<IView_HIS_DrugInfo> drugList = new List<IView_HIS_DrugInfo>();//HIS传来的药品信息列表
        List<IView_Inside_DrugDetail> relList = new List<IView_Inside_DrugDetail>();//明细表
        Node XYSelectNode;
        Node CYSelectNode;
        List<IView_HIS_DrugInfo> XYDrugInfo = new List<IView_HIS_DrugInfo>(); //全部西药
        List<IView_HIS_DrugInfo> CYDrugInfo = new List<IView_HIS_DrugInfo>(); //全部草药

        string[] WesternMedicineDept = System.Configuration.ConfigurationManager.AppSettings["WesternMedicineDept"].Split("|".ToCharArray());
        string[] HerbalMedicineDept = System.Configuration.ConfigurationManager.AppSettings["HerbalMedicineDept"].Split("|".ToCharArray());

        private void FormDrugGroup_Shown(object sender, EventArgs e)
        {
            InitData();
            InitUI();
            InitTree(treeDrugGroup, groupList.Where(x => x.DrugType == 1).ToList());//西药分类
            InitTree(treeHerbsGroup, groupList.Where(x => x.DrugType == 2).ToList());//草药分类
            InitDict();
        }

        #region 初始化操作
        private void InitData()
        {
            groupList = DBHelper.CIS.From<OP_DrugGroup>().Where(x => x.Owner == "*" || x.Owner == SysContext.RunSysInfo.user.ID || x.Owner == SysContext.RunSysInfo.currDept.Code).OrderBy(p => p.No).ToList();
            drugList = DBHelper.CIS.From<IView_HIS_DrugInfo>().ToList();
            relList = DBHelper.CIS.FromSql("select * from IView_Inside_DrugDetail where GroupID in ( select ID from OP_DrugGroup where Owner ='" +
                SysContext.RunSysInfo.currDept.Code + "' or Owner ='" + SysContext.RunSysInfo.user.ID + "' or Owner='*')").ToList<IView_Inside_DrugDetail>();
            XYDrugInfo = DBHelper.CIS.From<IView_HIS_DrugInfo>().Where(p => p.DrugDept.In(WesternMedicineDept)).ToList();
            CYDrugInfo = DBHelper.CIS.From<IView_HIS_DrugInfo>().Where(p => p.DrugDept.In(HerbalMedicineDept)).ToList();
        }

        private void RefreshGroup()
        {
            groupList = DBHelper.CIS.From<OP_DrugGroup>().Where(x => x.Owner == "*" || x.Owner == SysContext.RunSysInfo.user.ID || x.Owner == SysContext.RunSysInfo.currDept.Code).ToList();
        }

        private void InitUI()
        {
            this.dgvXY.AutoGenerateColumns = false;
            this.dgvXYDetail.AutoGenerateColumns = false;
            this.dgvCY.AutoGenerateColumns = false;
            this.dgvCYDetail.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 初始化用法和间隔字典
        /// </summary>
        private void InitDict()
        {
            List<IView_HIS_DrugUsage> Usage = DBHelper.CIS.From<IView_HIS_DrugUsage>().ToList();
            this.XY_colYF.DataSource = Usage.Where(p => p.Type == "1").ToList();
            this.XY_colYF.DisplayMember = "Name";
            this.XY_colYF.ValueMember = "Code";
            this.CY_colYF.DataSource = Usage.Where(p => p.Type == "2").ToList();
            this.CY_colYF.DisplayMember = "Name";
            this.CY_colYF.ValueMember = "Code";

            List<OP_Dic_Interval> Interval = DBHelper.CIS.From<OP_Dic_Interval>().ToList();
            this.XY_colJG.DataSource = Interval;
            this.XY_colJG.DisplayMember = "Name";
            this.XY_colJG.ValueMember = "Code";
        }
        #endregion

        #region 中药，西药 公用部分
        private void MoveRow(DataGridView dgv, string UpOrDown)
        {
            if (dgv.SelectedRows.Count == 0)
                return;
            if (UpOrDown == "Up")
            {
                int rowIndex = dgv.SelectedRows[0].Index;  //得到当前选中行的索引     

                if (rowIndex == 0)
                {
                    MessageBox.Show("已经是第一行了!");
                    return;
                }

                List<object> list = new List<object>();
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    list.Add(dgv.SelectedRows[0].Cells[i].Value);   //把当前选中行的数据存入list数组中     
                }

                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dgv.Rows[rowIndex].Cells[j].Value = dgv.Rows[rowIndex - 1].Cells[j].Value;
                    dgv.Rows[rowIndex - 1].Cells[j].Value = list[j];
                }
                dgv.Rows[rowIndex - 1].Selected = true;
                dgv.Rows[rowIndex].Selected = false;
            }
            else
            {
                int rowIndex = dgv.SelectedRows[0].Index;  //得到当前选中行的索引     

                if (rowIndex == dgv.Rows.Count - 1)
                {
                    MessageBox.Show("已经是最后一行了!");
                    return;
                }

                List<object> list = new List<object>();
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    list.Add(dgv.SelectedRows[0].Cells[i].Value);   //把当前选中行的数据存入list数组中     
                }

                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dgv.Rows[rowIndex].Cells[j].Value = dgv.Rows[rowIndex + 1].Cells[j].Value;
                    dgv.Rows[rowIndex + 1].Cells[j].Value = list[j];
                }
                dgv.Rows[rowIndex + 1].Selected = true;
                dgv.Rows[rowIndex].Selected = false;
            }
        }

        private void InitTree(AdvTree tree, List<OP_DrugGroup> list)
        {
            foreach (Node node in tree.Nodes)
            {
                node.Nodes.Clear();
            }
            List<OP_DrugGroup> rootList = list.Where(x => x.ParentID == "0").OrderBy(x => x.No).ToList();

            foreach (OP_DrugGroup item in rootList)
            {
                Node node = new Node();
                node.Text = item.Name;
                node.Tag = item;
                if (item.GroupType == 0)
                {
                    if (tree.Name == "treeHerbsGroup")
                    {
                        nodeHerbsHospital.Nodes.Add(node);
                    }

                }
                else if (item.GroupType == 1)
                {
                    if (tree.Name == "treeHerbsGroup")
                    {
                        nodeHerbsDept.Nodes.Add(node);
                    }
                    else
                    {
                        nodeDept.Nodes.Add(node);
                    }

                }
                else
                {
                    if (tree.Name == "treeHerbsGroup")
                    {
                        nodeHerbsUser.Nodes.Add(node);
                    }
                    else
                    {
                        nodeUser.Nodes.Add(node);
                    }
                }
                CreateChildNode(node, item.ID);
            }
            tree.ExpandAll();
        }

        private void CreateChildNode(Node parentNode, string parentCode)
        {
            List<OP_DrugGroup> list = groupList.Where(x => x.ParentID == parentCode).OrderBy(x => x.No).ToList();
            if (list.Count < 1) return;
            foreach (OP_DrugGroup item in list)
            {
                Node node = new Node();
                node.Text = item.Name;
                node.Tag = item;
                parentNode.Nodes.Add(node);
                CreateChildNode(node, item.ID);
            }

        }

        private void GroupAdd(AdvTree tree, int type)
        {
            FormAddDGroup form = new FormAddDGroup();
            form.status = "add";
            Node node = tree.SelectedNode;
            if (node == null)
            {
                AlertBox.Error("请选中一个分类");
                return;
            }
            else if (node.TagString == "全院套餐" || node.TagString == "科室套餐" || node.TagString == "个人套餐")
            {
                if (node.TagString == "全院套餐")
                {
                    if (!SysContext.CurrUser.roleList.Any(p => p.Code == "admin"))
                    {
                        AlertBox.Info("全院套餐只有管理员可以更改");
                        return;
                    }
                }
                form.parentID = "0";
                form.drugType = type;
                form.type = node.TagString == "全院套餐" ? 0 : node.TagString == "科室套餐" ? 1 : 2;
            }
            else
            {
                OP_DrugGroup temp = node.Tag as OP_DrugGroup;
                if (relList.Where(x => x.GroupID == temp.ID).ToList().Count > 0)
                {
                    AlertBox.Error("该节点下有分类项目不可以再添加子节点！如有必要添加请先删除该节点后重新建立");
                    return;
                }

                form.parentID = temp.ID;
                form.drugType = type;
                form.type = (int)temp.GroupType;

            }
            form.ShowDialog();
            RefreshGroup();
            InitTree(tree, groupList.Where(x => x.DrugType == (tree.Name == "treeDrugGroup" ? 1 : 2)).ToList());
        }

        private void GroupEdit(AdvTree tree)
        {
            Node node = tree.SelectedNode;
            if (node == null)
            {
                AlertBox.Error("请选中一个分类");
                return;
            }

            if (node.Tag == null || node.Tag.GetType() != typeof(OP_DrugGroup)) return;
            if (node.Tag is OP_DrugGroup group)
            {
                if (group.GroupType == 0)
                {
                    if (!SysContext.CurrUser.roleList.Any(p => p.Code == "admin"))
                    {
                        AlertBox.Info("全院套餐只有管理员可以更改");
                        return;
                    }
                }
            }

            FormAddDGroup form = new FormAddDGroup();
            form.status = "edit";
            OP_DrugGroup temp = node.Tag as OP_DrugGroup;
            form.group = temp;
            form.parentID = temp.ID;
            form.ShowDialog();
            RefreshGroup();
            InitTree(tree, groupList.Where(x => x.DrugType == (tree.Name == "treeDrugGroup" ? 1 : 2)).ToList());
        }

        private void GroupDel(AdvTree tree)
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
            OP_DrugGroup temp = node.Tag as OP_DrugGroup;
            if (temp.GroupType == 0)
            {
                if (!SysContext.CurrUser.roleList.Any(p => p.Code == "admin"))
                {
                    AlertBox.Info("全院套餐只有管理员可以更改");
                    return;
                }
            }

            DelNodeHasDetail(node);//删除节点下项目明细

            int i = DBHelper.CIS.Delete<OP_DrugGroup>(temp);
            if (i > 0)
                AlertBox.Info("删除成功");
            else
                AlertBox.Error("删除失败");

            RefreshGroup();
            InitTree(tree, groupList.Where(x => x.DrugType == (tree.Name == "treeDrugGroup" ? 1 : 2)).ToList());
        }

        private void DelNodeHasDetail(Node parentNode)
        {
            OP_DrugGroup rootGroup = parentNode.Tag as OP_DrugGroup;
            DBHelper.CIS.Delete<OP_DrugGroup_Detail>(OP_DrugGroup_Detail._.GroupID == rootGroup.ID);

            foreach (Node node in parentNode.Nodes)
            {
                OP_DrugGroup temp = node.Tag as OP_DrugGroup;
                DBHelper.CIS.Delete<OP_DrugGroup_Detail>(OP_DrugGroup_Detail._.GroupID == temp.ID);
                DelNodeHasDetail(node);
            }
        }

        private void ImportYPToDGV(DataGridViewRow target, DataGridViewRow source, bool IsCYAndZL)
        {
            this.dgvXY.EndEdit();
            this.dgvCY.EndEdit();
            foreach (DataGridViewCell item in source.Cells)
            {
                try
                {
                    target.Cells[(item.OwningColumn.Name).Substring(0, item.OwningColumn.Name.Length - 1)].Value = item.Value;
                }
                catch
                {
                }
            }
            if (IsCYAndZL)
            {
                target.Cells["CY_colSL"].Value = "1";
                target.Cells["CY_colYF"].Value = "jf";
                target.Cells["CY_colTS"].Value = "1";
                return;
            }
            target.Cells["XY_colJG"].Value = SysContext.CurrUser.Params.OP_DefaultFrequency;
            target.Cells["XY_colYF"].Value = SysContext.CurrUser.Params.OP_DefaultUsage;
            target.Cells["XY_colTS"].Value = "1";
            target.Cells["XY_colSL"].Value = "1";
        }

        #endregion

        #region 西药组套分类维护
        private void btnDrugAddGroup_Click(object sender, EventArgs e)
        {
            GroupAdd(treeDrugGroup, 1);
        }

        private void btnDrugEditGroup_Click(object sender, EventArgs e)
        {
            GroupEdit(treeDrugGroup);
        }
        private void treeDrugGroup_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            GroupEdit(treeDrugGroup);
        }
        private void btnDrugDelGroup_Click(object sender, EventArgs e)
        {
            GroupDel(treeDrugGroup);
        }
        #endregion

        #region 中药膏方分类维护
        private void btnHerbsAddGroup_Click(object sender, EventArgs e)
        {
            GroupAdd(treeHerbsGroup, 2);
        }

        private void btnHerbsEditGroup_Click(object sender, EventArgs e)
        {
            GroupEdit(treeHerbsGroup);
        }
        private void treeHerbsGroup_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            GroupEdit(treeHerbsGroup);
        }
        private void btnHerbsDelGroup_Click(object sender, EventArgs e)
        {
            GroupDel(treeHerbsGroup);
        }
        #endregion

        #region 药品分组 右键菜单
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabDrug"])
                GroupAdd(treeDrugGroup, 1);
            else
                GroupAdd(treeHerbsGroup, 2);
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabDrug"])
                GroupEdit(treeDrugGroup);
            else
                GroupEdit(treeHerbsGroup);
        }

        private void btnDelGroup_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabMain.Tabs["tabDrug"])
                GroupDel(treeDrugGroup);
            else
                GroupDel(treeHerbsGroup);
        }
        #endregion

        #region 数据操作
        private bool XYValidate(DataGridViewRow source, out string msg)
        {
            string[] MustHaveDataColName = new string[] { "XY_colName", "XY_colSL", "XY_colYL", "XY_colYF", "XY_colJG", "XY_colTS" }; //必须有值得列
            string[] MustIntColName = new string[] { "XY_colTS" }; //必须是int的列
            string[] MustNumColName = new string[] { "XY_colSL", "XY_colYL" };
            string tmpMsg = "";
            foreach (DataGridViewCell item in source.Cells)
            {
                if (MustHaveDataColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || item.Value.ToString() == "")
                        tmpMsg = ",此处不能为空";
                }
                if (MustIntColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || !item.Value.AsInt().HasValue || item.Value.AsInt(0) <= 0)
                        tmpMsg = ",此处必须为整数且大于零";
                }
                if (MustNumColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || !item.Value.AsFloat().HasValue || item.Value.AsFloat(0) <= 0)
                        tmpMsg = ",此处必须为数字且大于零";
                }
                if (tmpMsg != "")
                {
                    source.DataGridView.CurrentCell = item;
                    this.dgvXY.BeginEdit(true);
                    msg = tmpMsg;
                    return false;
                }
            }
            if (source.Cells["XY_colYPID"].Value != null)
            {
                List<IView_HIS_DrugInfo> druginfo = XYDrugInfo.Where(p => p.DrugID == source.Cells["XY_colYPID"].Value.ToString()).ToList();
                if (druginfo[0].DrugName == source.Cells["XY_colName"].Value.ToString().Trim() && druginfo[0].Specification == source.Cells["XY_colGG"].Value.ToString())
                {
                    msg = "";
                    return true;
                }
            }

            source.DataGridView.CurrentCell = source.Cells["XY_colName"];
            this.dgvXY.BeginEdit(true);
            msg = ",名称和规格不匹配";
            return false;
        }

        private bool CYValidate(DataGridViewRow source, out string msg)
        {
            string[] MustHaveDataColName = new string[] { "CY_colName", "CY_colSL", "CY_colYL", "CY_colTS" }; //必须有值得列
            string[] MustIntColName = new string[] { "CY_colTS" }; //必须是int的列
            string[] MustNumColName = new string[] { "CY_colYL" };
            string tmpMsg = "";
            foreach (DataGridViewCell item in source.Cells)
            {
                if (MustHaveDataColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || item.Value.ToString() == "")
                        tmpMsg = ",此处不能为空";
                }
                if (MustIntColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || !Regex.IsMatch(item.Value.ToString(), @"^\d*$") || item.Value.AsInt(0) <= 0)
                        tmpMsg = ",此处必须为整数且大于零";
                }
                if (MustNumColName.Contains(item.OwningColumn.Name))
                {
                    if (item.Value == null || !item.Value.AsFloat().HasValue || item.Value.AsFloat(0) <= 0)
                        tmpMsg = ",此处必须为数字且大于零";
                }
                if (tmpMsg != "")
                {
                    source.DataGridView.CurrentCell = item;
                    this.dgvCY.BeginEdit(true);
                    msg = tmpMsg;
                    return false;
                }
            }

            List<IView_HIS_DrugInfo> druginfo = CYDrugInfo.Where(p => p.DrugID == source.Cells["CY_colYPID"].Value.ToString()).ToList();
            if (druginfo[0].DrugName != source.Cells["CY_colName"].Value.ToString() || druginfo[0].Specification != source.Cells["CY_colGG"].Value.ToString())
            {
                source.DataGridView.CurrentCell = source.Cells["CY_colName"];
                this.dgvCY.BeginEdit(true);
                msg = ",名称和规格不匹配";
                return false;
            }
            msg = "";
            return true;
        }

        private bool CheckTZ(DataGridViewSelectedRowCollection rows)
        {
            string[] MustCommonColName = new string[] { "XY_colYF", "XY_colJG", "XY_colTS" };
            string tmp = "";
            string msg = "";
            foreach (DataGridViewRow item in rows)
            {
                if (item.Cells["XY_colTZBH"].Value.AsString("0") != "0")
                {
                    AlertBox.Info("当前选择项已有同组项目,无法重新同组");
                    return false;
                }
                if (!XYValidate(item, out msg))
                {
                    AlertBox.Info("在指定位置有数据验证失败," + msg);
                    return false;
                }
            }

            foreach (DataGridViewRow item in rows)
            {
                if (tmp == "")
                    foreach (string item1 in MustCommonColName)
                        tmp += item.Cells[item1].Value.ToString();
                else
                {
                    string tmp1 = "";
                    foreach (string item1 in MustCommonColName)
                        tmp1 += item.Cells[item1].Value.ToString();
                    if (tmp != tmp1)
                    {
                        AlertBox.Info("同组项必须用法、间隔和天数相同");
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 画出同组项目之间的连线
        /// </summary>
        private void DrawTZLine()
        {
            string[] zbf = new string[] { "┓", "┫", "┛", "┃" };
            string currTZBH = "";
            for (int i = 0; i < this.dgvXY.Rows.Count; i++)
            {
                //得到当前处理行的同组编号和下一行的同组编号,如果已经是最后一行,那么下一行的同组编号为-1
                if (this.dgvXY.Rows[i].Cells["XY_colTZBH"].Value == null) continue;
                string currRowValue = this.dgvXY.Rows[i].Cells["XY_colTZBH"].Value.ToString();
                string nextRowValue = i != this.dgvXY.Rows.Count - 1 ? this.dgvXY.Rows[i + 1].Cells["XY_colTZBH"].Value == null ? "-1" : this.dgvXY.Rows[i + 1].Cells["XY_colTZBH"].Value.ToString() : "-1";

                if (currRowValue == "0")
                {
                    this.dgvXY.Rows[i].Cells["XY_colTZ"].Value = "";
                    continue;   //如果没有同组编号则跳过
                }

                //如果当前行等于上一次的同组编号并且已经是最后一行
                if (currRowValue == currTZBH && nextRowValue == "-1")
                {
                    this.dgvXY.Rows[i].Cells["XY_colTZ"].Value = zbf[2];
                    this.dgvXY.Rows[i].Cells["XY_colTZ"].Style.Alignment = DataGridViewContentAlignment.TopLeft;
                }
                //如果当前行不等于上一次的同组编号并且和下一行一样
                else if (currRowValue != currTZBH && nextRowValue == currRowValue)
                {
                    this.dgvXY.Rows[i].Cells["XY_colTZ"].Value = zbf[0];
                    this.dgvXY.Rows[i].Cells["XY_colTZ"].Style.Alignment = DataGridViewContentAlignment.BottomLeft;
                    currTZBH = currRowValue;
                }
                //如果当前行等于上一次的同组编号并且和下一行一样
                else if (currRowValue == currTZBH && nextRowValue == currRowValue)
                {
                    this.dgvXY.Rows[i].Cells["XY_colTZ"].Value = zbf[3];
                    this.dgvXY.Rows[i].Cells["XY_colTZ"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                //如果当前行等于上一次的同组编号并且和下一行不一样
                else if (currRowValue == currTZBH && nextRowValue != currRowValue)
                {
                    this.dgvXY.Rows[i].Cells["XY_colTZ"].Value = zbf[2];
                    this.dgvXY.Rows[i].Cells["XY_colTZ"].Style.Alignment = DataGridViewContentAlignment.TopLeft;
                }
            }
        }

        private void ColculateXYZJE(DataGridViewRow source)
        {
            double LSJ = source.Cells["XY_colLSJ"].Value.AsDouble(0);
            int SL = source.Cells["XY_colSL"].Value.AsInt(0);
            source.Cells["XY_colZJE"].Value = LSJ * SL;
        }

        private void ColculateCYZJE(DataGridViewRow source)
        {
            double LSJ = source.Cells["CY_colLSJ"].Value.AsDouble(0);
            int SL = source.Cells["CY_colSL"].Value.AsInt(0);
            source.Cells["CY_colZJE"].Value = LSJ * SL;
        }


        #endregion

        #region 西药操作
        private void btnXYUp_Click(object sender, EventArgs e)
        {
            MoveRow(this.dgvXY, "Up");
        }
        private void btnXYDown_Click(object sender, EventArgs e)
        {
            MoveRow(this.dgvXY, "Down");
        }
        private void btnGroup_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvXY.SelectedRows;
            if (rows.Count < 2)
                return;

            if (!CheckTZ(rows))
                return;

            int MaxTZBH = 0;
            foreach (DataGridViewRow item in this.dgvXY.Rows)
            {
                object tzbh = item.Cells["XY_colTZBH"].Value;
                if (tzbh.AsInt(0) > MaxTZBH)
                    MaxTZBH = tzbh.AsInt(0);
            }

            foreach (DataGridViewRow item in rows)
            {
                item.Cells["XY_colTZBH"].Value = MaxTZBH + 1;
                this.dgvXY.Rows.Remove(item);
                this.dgvXY.Rows.Insert(0, item);
            }
            DrawTZLine();
        }

        private void btnGroupCancel_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            DataGridViewSelectedRowCollection rows = this.dgvXY.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                string tmp = row.Cells["XY_colTZBH"].Value.AsString("0");
                if (!list.Contains(Convert.ToInt32(tmp)))
                    list.Add(Convert.ToInt32(tmp));
            }
            foreach (DataGridViewRow item in this.dgvXY.Rows)
            {
                string tmp = item.Cells["XY_colTZBH"].Value.AsString("0");
                if (list.Contains(Convert.ToInt32(tmp)))
                    item.Cells["XY_colTZBH"].Value = "0";
            }
            DrawTZLine();
        }

        private void btnGroupCollect_Click(object sender, EventArgs e)
        {
            (sender as ButtonItem).Expanded = true;
        }
        private void dgvXY_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (this.dgvXY.Rows[e.RowIndex].Cells[e.ColumnIndex].EditType == typeof(DataGridViewComboBoxExEditingControl))
                SendKeys.Send("{F4}");
        }

        private void treeDrugGroup_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            relList = DBHelper.CIS.FromSql("select * from IView_Inside_DrugDetail where GroupID in ( select ID from OP_DrugGroup where Owner ='" +
                SysContext.RunSysInfo.currDept.Code + "' or Owner ='" + SysContext.RunSysInfo.user.ID + "' or Owner='*') order by no").ToList<IView_Inside_DrugDetail>();
            if ((sender as AdvTree) == this.treeDrugGroup)
                XYSelectNode = e.Node;
            else
                CYSelectNode = e.Node;

            this.dgvXY.Rows.Clear();
            this.dgvCY.Rows.Clear();

            if (e.Node.Nodes.Count == 0)
            {
                if (e.Node.Tag == null) return;
                OP_DrugGroup group = e.Node.Tag as OP_DrugGroup;
                if (group == null) return;
                List<IView_Inside_DrugDetail> detail = relList.Where(p => p.GroupID == group.ID).ToList();
                if (detail.Count < 1) return;
                DataGridView dgv = group.DrugType == 2 ? this.dgvCY : this.dgvXY;

                int index = 0;

                foreach (IView_Inside_DrugDetail item in detail)
                {
                    index = dgv.Rows.Add();
                    foreach (DataGridViewColumn item1 in dgv.Columns)
                    {
                        var fileds = item.GetFields().ToList();
                        var filed = fileds.Find(p => p.Name == item1.DataPropertyName);
                        if (item.GetFields().Contains(filed))
                        {
                            dgv.Rows[index].Cells[item1.Name].Value = item.GetValues()[fileds.IndexOf(filed)];
                        }
                    }
                    if (dgv == this.dgvXY)
                        ColculateXYZJE(dgv.Rows[index]);
                    else
                        ColculateCYZJE(dgv.Rows[index]);
                }
                DrawTZLine();
            }
        }

        private void btnDrugAddItem_Click(object sender, EventArgs e)
        {
            if (XYSelectNode == null)
            {
                AlertBox.Info("未选择套餐节点");
                return;
            }
            if (XYSelectNode.Nodes.Count > 0)
            {
                AlertBox.Info("您选择的是分类节点,请重新选择");
                return;
            }
            this.dgvXY.EndEdit();
            string msg;
            foreach (DataGridViewRow item in this.dgvXY.Rows)
            {
                if (!XYValidate(item, out msg))
                {
                    AlertBox.Info("在指定位置有数据验证失败" + msg);
                    return;
                }
                ColculateXYZJE(item);
            }

            int index = this.dgvXY.Rows.Add();
            this.dgvXY.CurrentCell = this.dgvXY.Rows[index].Cells["XY_colName"];
            this.dgvXY.BeginEdit(true);
            //if (index != 0)
            //{
            //    OP_DrugGroup_Detail Prescription = CIS.Utility.ControlHelper.FillModel<OP_DrugGroup_Detail>(this.dgvXY.Rows[index - 1]);
            //    Prescription.GroupID = (XYSelectNode.Tag as OP_DrugGroup).ID;
            //    Prescription.Owner = (XYSelectNode.Tag as OP_DrugGroup).Owner;
            //    if (Prescription.ID == null)
            //    {
            //        Prescription.ID = Guid.NewGuid().ToString();
            //        this.dgvXY.Rows[index - 1].Cells["XY_colID"].Value = Prescription.ID;
            //        DBHelper.CIS.Insert<OP_DrugGroup_Detail>(Prescription);
            //    }
            //    else
            //        DBHelper.CIS.Update<OP_DrugGroup_Detail>(Prescription, p => p.ID == Prescription.ID);
            //}
        }

        private void dgvXY_Text_Changed(object sender, EventArgs e)
        {
            if (this.dgvXY.CurrentCell.OwningColumn.Name == "XY_colName")
            {
                string InputStr = (sender as TextBox).Text.ToUpper();
                if (InputStr == "")
                {
                    this.dgvXYDetail.Hide();
                    return;
                }
                List<IView_HIS_DrugInfo> Tmp = XYDrugInfo.Where(p => p.SearchCode.Contains(InputStr) || p.DrugName.Contains(InputStr)).ToList();
                this.dgvXYDetail.DataSource = Tmp;
                this.dgvXYDetail.Show();
            }
        }

        private void dgvXY_TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (this.dgvXY.CurrentCell.IsInEditMode && this.dgvXY.CurrentCell.OwningColumn.Name == "XY_colName")
                {
                    CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(this.dgvXYDetail.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_KEYDOWN, (int)e.KeyValue, 0);
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (this.dgvXY.CurrentCell.OwningRow.Index > 0 && e.KeyCode == Keys.Up)
                        this.dgvXY.CurrentCell = this.dgvXY.Rows[this.dgvXY.CurrentCell.OwningRow.Index - 1].Cells[this.dgvXY.CurrentCell.ColumnIndex];
                    else if (this.dgvXY.CurrentCell.OwningRow.Index < this.dgvXY.Rows.Count - 1 && e.KeyCode == Keys.Down)
                        this.dgvXY.CurrentCell = this.dgvXY.Rows[this.dgvXY.CurrentCell.OwningRow.Index + 1].Cells[this.dgvXY.CurrentCell.ColumnIndex];
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (this.dgvXY.CurrentCell.OwningColumn.Name == "XY_colName" && this.dgvXYDetail.Visible)
                {
                    if (this.dgvXYDetail.SelectedRows.Count == 0) return;
                    ImportYPToDGV(this.dgvXY.CurrentCell.OwningRow, this.dgvXYDetail.SelectedRows[0], false);
                    this.dgvXYDetail.Hide();
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (this.dgvXY.CurrentCell != null || this.dgvXY.CurrentCell.ColumnIndex < this.dgvXY.ColumnCount)
                    {
                        //循环到下一个可编辑的单元格内
                        DataGridViewCell cell = this.dgvXY.CurrentCell.OwningRow.Cells[this.dgvXY.CurrentCell.ColumnIndex + 1];
                        while (cell.ReadOnly)
                            cell = cell.OwningRow.Cells[cell.ColumnIndex + 1];
                        //如果单元格不可见并且可以回车换行并且换行点为最后一列则加一行
                        if (!cell.Visible && SysContext.CurrUser.Params.OP_Enter_Position == "最后一列" && SysContext.CurrUser.Params.OP_CanEnter)
                        {
                            btnDrugAddItem_Click(null, null);
                            return;
                        }

                        if (!cell.Visible) return;
                        this.dgvXY.CurrentCell = cell;
                        this.dgvXY.BeginEdit(true);
                    }
                }


                //if (this.dgvXY.CurrentCell.OwningColumn.Name == "XY_colName" && this.dgvXYDetail.Visible)
                //{
                //    if (this.dgvXYDetail.SelectedRows.Count == 0) return;
                //    ImportYPToDGV(this.dgvXY.CurrentCell.OwningRow, this.dgvXYDetail.SelectedRows[0], false);
                //    this.dgvXYDetail.Hide();
                //    e.SuppressKeyPress = false;
                //}
                //else
                //{
                //    if (this.dgvXY.CurrentCell != null || this.dgvXY.CurrentCell.ColumnIndex < this.dgvXY.ColumnCount)
                //    {
                //        this.dgvXY.CurrentCell = this.dgvXY.CurrentCell.OwningRow.Cells[this.dgvXY.CurrentCell.ColumnIndex + 1];
                //        this.dgvXY.BeginEdit(true);
                //    }
                //}
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.Left) && this.dgvXYDetail.Visible)
                this.dgvXYDetail.Hide();
        }

        private void btnXYSave_Click(object sender, EventArgs e)
        {
            this.dgvXY.EndEdit();
            string msg;
            if (this.dgvXY.Rows[this.dgvXY.Rows.Count - 1].Cells["XY_colName"].Value == null && this.dgvXY.Rows[this.dgvXY.Rows.Count - 1].Cells["XY_colGG"].Value == null)
                this.dgvXY.Rows.RemoveAt(this.dgvXY.Rows.Count - 1);
            if (this.dgvXY.Rows.Count == 0) return;
            foreach (DataGridViewRow item in this.dgvXY.Rows)
            {
                if (!XYValidate(item, out msg))
                {
                    AlertBox.Info("在指定位置有数据验证失败" + msg);
                    return;
                }
                ColculateXYZJE(item);
            }

            foreach (DataGridViewRow item in this.dgvXY.Rows)
            {
                OP_DrugGroup_Detail Prescription = CIS.Utility.ControlHelper.FillModel<OP_DrugGroup_Detail>(item);
                Prescription.GroupID = (XYSelectNode.Tag as OP_DrugGroup).ID;
                Prescription.Owner = (XYSelectNode.Tag as OP_DrugGroup).Owner;
                Prescription.No = item.Index;
                if (Prescription.ID == null)
                {
                    Prescription.ID = Guid.NewGuid().ToString();
                    item.Cells["XY_colID"].Value = Prescription.ID;
                    DBHelper.CIS.Insert<OP_DrugGroup_Detail>(Prescription);
                }
                else
                    DBHelper.CIS.Update<OP_DrugGroup_Detail>(Prescription, p => p.ID == Prescription.ID);
            }
            AlertBox.Info("保存成功");
            this.dgvXY.Rows.Clear();
        }

        private void btnXYDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvXY.SelectedRows;
            foreach (DataGridViewRow item in rows)
            {
                if (item.Cells["XY_colID"].Value != null)
                    DBHelper.CIS.Delete<OP_DrugGroup_Detail>(p => p.ID == item.Cells["XY_colID"].Value.ToString());
                this.dgvXY.Rows.Remove(item);
            }
        }
        #endregion

        #region 草药处方操作
        private void btnCYUp_Click(object sender, EventArgs e)
        {
            MoveRow(this.dgvCY, "Up");
        }

        private void btnCYDown_Click(object sender, EventArgs e)
        {
            MoveRow(this.dgvCY, "Down");

        }
        private void dgvCY_Text_Changed(object sender, EventArgs e)
        {
            if (this.dgvCY.CurrentCell.OwningColumn.Name == "CY_colName")
            {
                string InputStr = (sender as TextBox).Text.ToUpper();
                if (InputStr == "")
                {
                    this.dgvCYDetail.Hide();
                    return;
                }
                List<IView_HIS_DrugInfo> Tmp = CYDrugInfo.Where(p => p.SearchCode.Contains(InputStr) || p.DrugName.Contains(InputStr)).ToList();
                this.dgvCYDetail.DataSource = Tmp;
                this.dgvCYDetail.Show();
            }
        }

        private void btnCYAdd_Click(object sender, EventArgs e)
        {
            this.dgvCY.EndEdit();
            string msg;
            foreach (DataGridViewRow item in this.dgvCY.Rows)
            {
                if (!CYValidate(item, out msg))
                {
                    AlertBox.Info("在指定位置有数据验证失败" + msg);
                    return;
                }
                ColculateCYZJE(item);
            }
            int index = this.dgvCY.Rows.Add();
            this.dgvCY.CurrentCell = this.dgvCY.Rows[index].Cells["CY_colName"];
            Application.DoEvents();
            this.dgvCY.BeginEdit(true);
        }

        private void dgvCY_TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (this.dgvCY.CurrentCell.IsInEditMode && this.dgvCY.CurrentCell.OwningColumn.Name == "CY_colName")
                {
                    CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(this.dgvCYDetail.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_KEYDOWN, (int)e.KeyValue, 0);
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (this.dgvCY.CurrentCell.OwningRow.Index > 0 && e.KeyCode == Keys.Up)
                        this.dgvCY.CurrentCell = this.dgvCY.Rows[this.dgvCY.CurrentCell.OwningRow.Index - 1].Cells[this.dgvCY.CurrentCell.ColumnIndex];
                    else if (this.dgvCY.CurrentCell.OwningRow.Index < this.dgvCY.Rows.Count - 1 && e.KeyCode == Keys.Down)
                        this.dgvCY.CurrentCell = this.dgvCY.Rows[this.dgvCY.CurrentCell.OwningRow.Index + 1].Cells[this.dgvCY.CurrentCell.ColumnIndex];
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (this.dgvCY.CurrentCell.OwningColumn.Name == "CY_colName" && this.dgvCYDetail.Visible)
                {
                    if (this.dgvCYDetail.SelectedRows.Count == 0) return;
                    ImportYPToDGV(this.dgvCY.CurrentCell.OwningRow, this.dgvCYDetail.SelectedRows[0], true);
                    this.dgvCYDetail.Hide();
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (this.dgvCY.CurrentCell != null || this.dgvCY.CurrentCell.ColumnIndex < this.dgvCY.ColumnCount)
                    {
                        //循环到下一个可编辑的单元格内
                        DataGridViewCell cell = this.dgvCY.CurrentCell.OwningRow.Cells[this.dgvCY.CurrentCell.ColumnIndex + 1];
                        while (cell.ReadOnly)
                            cell = cell.OwningRow.Cells[cell.ColumnIndex + 1];
                        //如果单元格不可见并且可以回车换行并且换行点为最后一列则加一行
                        if (!cell.Visible)
                        {
                            btnCYAdd_Click(null, null);
                            return;
                        }

                        if (!cell.Visible) return;
                        this.dgvCY.CurrentCell = cell;
                        this.dgvCY.BeginEdit(true);
                    }
                }
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.Left) && this.dgvCYDetail.Visible)
                this.dgvCYDetail.Hide();
        }

        private void dgvCYDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvCYDetail.SelectedRows;
            if (rows.Count < 1)
                return;
            if (this.dgvCY.CurrentCell.OwningColumn.Name == "CY_colName" && this.dgvCYDetail.Visible)
            {
                ImportYPToDGV(this.dgvCY.CurrentCell.OwningRow, rows[0], true);
                this.dgvCYDetail.Hide();
            }
        }

        private void dgvCYDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dgvCY.CurrentCell.OwningColumn.Name == "CY_colName" && this.dgvCYDetail.Visible)
                    ImportYPToDGV(this.dgvCY.CurrentCell.OwningRow, this.dgvCYDetail.SelectedRows[0], true);
                this.dgvCYDetail.Hide();
            }
        }

        private void btnCYDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgvCY.SelectedRows;
            foreach (DataGridViewRow item in rows)
            {
                if (item.Cells["CY_colID"].Value != null)
                    DBHelper.CIS.Delete<OP_DrugGroup_Detail>(p => p.ID == item.Cells["CY_colID"].Value.ToString());
                this.dgvCY.Rows.Remove(item);
            }
        }

        private void btnCYSave_Click(object sender, EventArgs e)
        {
            this.dgvCY.EndEdit();
            string msg;
            if (this.dgvCY.Rows[this.dgvCY.Rows.Count - 1].Cells["CY_colName"].Value == null && this.dgvCY.Rows[this.dgvCY.Rows.Count - 1].Cells["CY_colGG"].Value == null)
                this.dgvCY.Rows.RemoveAt(this.dgvCY.Rows.Count - 1);
            if (this.dgvCY.Rows.Count == 0) return;
            foreach (DataGridViewRow item in this.dgvCY.Rows)
            {
                if (!CYValidate(item, out msg))
                {
                    AlertBox.Info("在指定位置有数据验证失败" + msg);
                    return;
                }
                ColculateCYZJE(item);
            }

            foreach (DataGridViewRow item in this.dgvCY.Rows)
            {
                OP_DrugGroup_Detail Prescription = CIS.Utility.ControlHelper.FillModel<OP_DrugGroup_Detail>(item);
                Prescription.GroupID = (CYSelectNode.Tag as OP_DrugGroup).ID;
                Prescription.Owner = (CYSelectNode.Tag as OP_DrugGroup).Owner;
                Prescription.No = item.Index;
                if (Prescription.ID == null)
                {
                    Prescription.ID = Guid.NewGuid().ToString();
                    item.Cells["CY_colID"].Value = Prescription.ID;
                    DBHelper.CIS.Insert<OP_DrugGroup_Detail>(Prescription);
                }
                else
                    DBHelper.CIS.Update<OP_DrugGroup_Detail>(Prescription, p => p.ID == Prescription.ID);
            }
            AlertBox.Info("保存成功");
            this.dgvCY.Rows.Clear();
        }
        private void dgvCY_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (this.dgvXY.Rows[e.RowIndex].Cells[e.ColumnIndex].EditType == typeof(DataGridViewComboBoxExEditingControl))
                    SendKeys.Send("{F4}");
            }
            catch
            {
            }

        }
        #endregion

        #region 行拖拽
        int selectionIdx;
        //下方为鼠标拖动表格事件  
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

            if ((e.Clicks < 2) && (e.Button == MouseButtons.Left) && e.RowIndex >= 0)
            {
                CIS.ControlLib.Controls.myDataGridView dgv = (sender as CIS.ControlLib.Controls.myDataGridView);
                dgv.DoDragDrop(dgv.Rows[e.RowIndex], DragDropEffects.Move);
            }
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            CIS.ControlLib.Controls.myDataGridView dgv = (sender as CIS.ControlLib.Controls.myDataGridView);
            int idx = GetRowFromPoint(e.X, e.Y, dgv);

            if (idx < 0) return;

            if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
            {
                DataGridViewRow row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                selectionIdx = idx;
                dgv.Rows.Remove(row);
                dgv.Rows.Insert(idx, row);
                dgv.ClearSelection();
                dgv.CurrentCell = row.Cells[1];
            }
        }
        //添加获取行坐标方法  
        private int GetRowFromPoint(int x, int y, CIS.ControlLib.Controls.myDataGridView dgv)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                Rectangle rec = dgv.GetRowDisplayRectangle(i, false);

                if (dgv.RectangleToScreen(rec).Contains(x, y))
                    return i;
            }

            return -1;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                selectionIdx = e.RowIndex;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //if ((dataGridViewX1.Rows.Count > 0) && (dataGridViewX1.SelectedRows.Count > 0) && (dataGridViewX1.SelectedRows[0].Index != selectionIdx))
            //{
            //    if (dataGridViewX1.Rows.Count <= selectionIdx)
            //        selectionIdx = dataGridViewX1.Rows.Count - 1;
            //    dataGridViewX1.Rows[selectionIdx].Selected = true;
            //    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[selectionIdx].Cells[0];
            //}
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        #endregion
    }
}
