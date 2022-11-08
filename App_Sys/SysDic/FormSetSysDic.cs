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

namespace App_Sys
{
    public partial class FormSetSysDic : Form
    {

        List<Sys_Dic> dicList = new List<Sys_Dic>();//字典表
        List<Sys_Dic_Details> detailsList = new List<Sys_Dic_Details>();//字典明细表
        List<Sys_Dic_Details> dicHasDetails = new List<Sys_Dic_Details>();//当前字典的明细

        public FormSetSysDic()
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
            dicList = DBHelper.CIS.From<Sys_Dic>().ToList();
            detailsList = DBHelper.CIS.From<Sys_Dic_Details>().ToList();
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitUI()
        {
            var pCode = this.gridSysDicDetails.PrimaryGrid.Columns["colEditDicCode"];
            pCode.EditorType = typeof(MyComboBox);
            pCode.EditorParams = new object[] { DBHelper.CIS.From<Sys_Dic>().ToList() };
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
            foreach (Sys_Dic dic in dicList)
            {
                Node node = new Node();
                if (dic.Name != null)
                    node.Text = dic.Name.ToString();
                node.Tag = dic;
                ROOT.Nodes.Add(node);
            }
            if (Tree.SelectedNode == null)
                Tree.SelectedNode = ROOT;

            Tree.ExpandAll();

        }

        /// <summary>
        /// 树的click事件：更改数据绑定
        /// </summary>
        private void advTree1_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (Tree.SelectedNode == ROOT)
                gridSysDicDetails.PrimaryGrid.DataSource = null;
            else
            {
                if (e != null && e.Node.ToString() != "所有类别")
                {
                    Sys_Dic dic = e.Node.Tag as Sys_Dic;
                    dicHasDetails.Clear();
                    //数据筛选
                    dicHasDetails = detailsList.Where(x => x.DicCode == dic.Code).ToList();
                    gridSysDicDetails.PrimaryGrid.DataSource = dicHasDetails;

                }
                Application.DoEvents();
                this.gridSysDicDetails.PrimaryGrid.SetSelectedRows(0, 1, true);
            }
        }
        
        /// <summary>
        /// 添加
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode == ROOT || Tree.SelectedNode.ToString() == "所有类别")
            {
                AlertBox.Error("请选中左侧的字典项");
                return;
            }
            FormAddDicDetails FormAddDicDetails = new FormAddDicDetails();
            FormAddDicDetails.dic = Tree.SelectedNode.Tag as Sys_Dic;
            FormAddDicDetails.ShowDialog();
            btnRefresh_Click(null, null);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridSysDicDetails.PrimaryGrid.DataSource != null && gridSysDicDetails.PrimaryGrid.Rows.Count > 0)
            {
                if (gridSysDicDetails.PrimaryGrid.GetSelectedRows().Count < 1) { AlertBox.Info("请先选中行！"); return; }

                GridRow row = this.gridSysDicDetails.GetSelectedRows()[0] as GridRow;
                Sys_Dic_Details temp = row.DataItem as Sys_Dic_Details;    //实例化编辑行                    
                FormAddDicDetails FormAddDicDetails = new FormAddDicDetails(temp);
                FormAddDicDetails.ShowDialog(); 
                btnRefresh_Click(null, null);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gridSysDicDetails.PrimaryGrid.DataSource != null && gridSysDicDetails.PrimaryGrid.Rows.Count > 0)
            {
                if (gridSysDicDetails.PrimaryGrid.GetSelectedRows().Count <= 0) { AlertBox.Info("请先选中行！"); return; }
                SelectedElementCollection CurrentRows = this.gridSysDicDetails.GetSelectedRows();
                GridRow CurrentRow = (GridRow)CurrentRows[0];
                string deleteCode = CurrentRow["colEditCode"].Value.ToString();
                try
                {
                    if (MsgBox.YesNo("确定要删除么？") == DialogResult.Yes)
                    {
                        int deleteCount = SysDicDal.dbSysDicDelete(deleteCode);
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
        /// 新增类别
        /// </summary>
        private void btnManager_Click(object sender, EventArgs e)
        {
            FormAddDic FormAddDic = new FormAddDic();
            FormAddDic.ShowDialog();
        }

        /// <summary>
        /// 修改类别
        /// </summary>
        private void advTree1_NodeDoubleClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e != null && e.Node.ToString() != "所有类别")
            {
                Sys_Dic dic = DBHelper.CIS.From<Sys_Dic>().Where(Sys_Dic._.Name == e.Node.ToString() && Sys_Dic._.Style == 1).ToFirst<Sys_Dic>();
                if (dic != null)
                {
                    FormAddDic FormAddDic = new FormAddDic(dic);
                    FormAddDic.ShowDialog();
                }
                else AlertBox.Info(e.Node.ToString() + "类不允许修改！");
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

        private void gridSysDicDetails_RowClick(object sender, GridRowClickEventArgs e)
        {
            GridRow row = null;
            if (this.gridSysDicDetails.PrimaryGrid.GetSelectedRows().Count > 0)
                row = this.gridSysDicDetails.PrimaryGrid.GetSelectedRows()[0] as GridRow;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Node node = Tree.SelectedNode;
            InitData();
            InitTree();
            Tree.SelectedNode = node;
            if (Tree.SelectedNode == ROOT)
                gridSysDicDetails.PrimaryGrid.DataSource = null;
            else
            {
                if (Tree.SelectedNode != null)
                {
                    Sys_Dic dic = Tree.SelectedNode.Tag as Sys_Dic;
                    dicHasDetails.Clear();
                    //数据筛选
                    dicHasDetails = detailsList.Where(x => x.DicCode == dic.Code).ToList();

                    gridSysDicDetails.PrimaryGrid.DataSource = dicHasDetails;
                    gridSysDicDetails.PrimaryGrid.ReadOnly = true;

                }
                Application.DoEvents();
                this.gridSysDicDetails.PrimaryGrid.SetSelectedRows(0, 1, true);
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

        private void gridSysDicDetails_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

    }
}