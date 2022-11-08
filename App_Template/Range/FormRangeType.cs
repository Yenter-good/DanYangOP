using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CIS.Model;
using CIS.Purview;
using CIS.Core;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.AdvTree;
using System.Linq;

namespace App_Template
{
    public partial class FormRangeType : CIS.Core.BaseForm
    {

        List<TP_RangeType> RTypeList = new List<TP_RangeType>();//值域类型表
        List<TP_Range> rangeList = new List<TP_Range>();//值域表
        List<TP_Range> HasRangeList = new List<TP_Range>();//当前值域

        public FormRangeType()
        {
            InitializeComponent();
            InitData();
            InitUI();
            InitTree();
        }

        /// <summary>
        /// 初始化数据绑定
        /// </summary>
        private void InitData()
        {
            RTypeList = DBHelper.CIS.From<TP_RangeType>().ToList();
            rangeList = DBHelper.CIS.From<TP_Range>().ToList();
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitUI()
        {
            var pCode = this.gridTPRange.PrimaryGrid.Columns["colEditRTypeCode"];
            pCode.EditorType = typeof(MyComboBox);
            pCode.EditorParams = new object[] { DBHelper.CIS.From<TP_RangeType>().ToList() };
        }

        /// <summary>
        /// 初始化树数据
        /// </summary>
        private void InitTree()
        {
            //创建树节点
            ROOT.Nodes.Clear();//清除所有子节点
            //节点赋值
            InitData();
            foreach (TP_RangeType RType in RTypeList)
            {
                //Node node = new Node();
                //if (RType.Name != null)
                //    node.Text = RType.Name.ToString();
                Node node = new Node();
                DevComponents.AdvTree.Cell colh1 = new DevComponents.AdvTree.Cell();
                DevComponents.AdvTree.Cell colh2 = new DevComponents.AdvTree.Cell();
                node.Cells.Add(colh1);
                node.Cells.Add(colh2);
                if (RType.Code != null) node.Cells[0].Text = RType.Code.ToString();
                if (RType.Name != null) node.Cells[1].Text = RType.Name.ToString();
                node.Tag = RType;
                ROOT.Nodes.Add(node);
            }
            Tree.SelectedNode = ROOT;

            Tree.ExpandAll();

        }

        /// <summary>
        /// 树的click事件：更改数据绑定
        /// </summary>
        private void advTree1_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (Tree.SelectedNode == ROOT)
                gridTPRange.PrimaryGrid.DataSource = null;
            else
            {
                if (e != null && e.Node.ToString() != "所有类型")
                {
                    TP_RangeType RType = e.Node.Tag as TP_RangeType;
                    HasRangeList.Clear();
                    //数据筛选
                    HasRangeList = rangeList.Where(x => x.RangeTypeCode == RType.Code).ToList();
                    gridTPRange.PrimaryGrid.DataSource = HasRangeList;

                }
                Application.DoEvents();
                this.gridTPRange.PrimaryGrid.SetSelectedRows(0, 1, true);
            }
        }
        
        /// <summary>
        /// 添加
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode.Text == "所有类型")
            {
                AlertBox.Error("请选中左侧的类型项");
                return;
            }
            FormAddRange FormAddTPRange = new FormAddRange();
            FormAddTPRange.ShowDialog();
            btnRefresh_Click(null, null);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridTPRange.PrimaryGrid.DataSource != null && gridTPRange.PrimaryGrid.Rows.Count > 0)
            {
                if (gridTPRange.PrimaryGrid.GetSelectedRows().Count < 1) { AlertBox.Info("请先选中行！"); return; }

                GridRow row = this.gridTPRange.GetSelectedRows()[0] as GridRow;
                TP_Range temp = row.DataItem as TP_Range;    //实例化编辑行                    
                FormAddRange FormAddTPRange = new FormAddRange(temp);
                FormAddTPRange.ShowDialog(); 
                btnRefresh_Click(null, null);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gridTPRange.PrimaryGrid.DataSource != null && gridTPRange.PrimaryGrid.Rows.Count > 0)
            {
                if (gridTPRange.PrimaryGrid.GetSelectedRows().Count <= 0) { AlertBox.Info("请先选中行！"); return; }
                SelectedElementCollection CurrentRows = this.gridTPRange.GetSelectedRows();
                GridRow CurrentRow = (GridRow)CurrentRows[0];
                string deleteCode = CurrentRow["colEditCode"].Value.ToString();
                try
                {
                    if (MsgBox.YesNo("确定要删除么？") == DialogResult.Yes)
                    {
                        int deleteCount = RangeTypeDal.dbTPRangeDelete(deleteCode);
                        if (deleteCount == 0)
                        {
                            AlertBox.Info("保存成功！");
                            btnRefresh_Click(null, null);
                        }
                        else AlertBox.Info("保存失败！");
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.OK(ex.Message);
                }
            }
        }


        /// <summary>
        /// 新增类型
        /// </summary>
        private void btnManager_Click(object sender, EventArgs e)
        {
            FormAddRangeType FormAddTPRangeType = new FormAddRangeType();
            FormAddTPRangeType.ShowDialog();
        }

        /// <summary>
        /// 修改类型
        /// </summary>
        private void advTree1_NodeDoubleClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e != null && e.Node.ToString() != "所有类型")
            {
                TP_RangeType RType = DBHelper.CIS.From<TP_RangeType>().Where(TP_RangeType._.Code == e.Node.Cells[0].Text && TP_RangeType._.Status == 1).ToFirst<TP_RangeType>();
                if (RType != null)
                {
                    FormAddRangeType FormAddTPRangeType = new FormAddRangeType(RType);
                    FormAddTPRangeType.ShowDialog();
                }
                else
                {
                    TP_RangeType RTypeN = DBHelper.CIS.From<TP_RangeType>().Where(TP_RangeType._.Code == e.Node.Cells[0].Text && TP_RangeType._.Status == 0).ToFirst<TP_RangeType>();
                    FormAddRangeType FormAddTPRangeType = new FormAddRangeType(RTypeN);
                    FormAddTPRangeType.input_Description.Enabled = false;
                    FormAddTPRangeType.input_Search.Enabled = false;
                    FormAddTPRangeType.input_No.Enabled = false;
                    FormAddTPRangeType.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 树滚动条
        /// </summary>
        private void advTree1_Scroll(object sender, ScrollEventArgs e)
        {
            int ms = e.NewValue - e.OldValue;
            Tree.Top = Tree.Top - ms;
        }

        private void gridTPRange_RowClick(object sender, GridRowClickEventArgs e)
        {
            GridRow row = null;
            if (this.gridTPRange.PrimaryGrid.GetSelectedRows().Count > 0)
                row = this.gridTPRange.PrimaryGrid.GetSelectedRows()[0] as GridRow;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitData();
            InitTree();
            if (Tree.SelectedNode == ROOT)
                gridTPRange.PrimaryGrid.DataSource = null;
            else
            {
                if (Tree.SelectedNode != null)
                {
                    TP_RangeType RType = Tree.SelectedNode.Tag as TP_RangeType;
                    HasRangeList.Clear();
                    //数据筛选
                    HasRangeList = rangeList.Where(x => x.RangeTypeCode == RType.Code).ToList();

                    gridTPRange.PrimaryGrid.DataSource = HasRangeList;
                    gridTPRange.PrimaryGrid.ReadOnly = true;

                }
                Application.DoEvents();
                this.gridTPRange.PrimaryGrid.SetSelectedRows(0, 1, true);
            }
        }

        public class MyComboBox : GridComboBoxExEditControl
        {
            public MyComboBox(object Source)
            {
                this.DisplayMember = "Name";
                this.ValueMember = "Code";
                this.DataSource = Source;
            }

        }

        private void gridTPRange_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

    }
}