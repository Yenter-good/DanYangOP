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

        List<TP_RangeType> RTypeList = new List<TP_RangeType>();//ֵ�����ͱ�
        List<TP_Range> rangeList = new List<TP_Range>();//ֵ���
        List<TP_Range> HasRangeList = new List<TP_Range>();//��ǰֵ��

        public FormRangeType()
        {
            InitializeComponent();
            InitData();
            InitUI();
            InitTree();
        }

        /// <summary>
        /// ��ʼ�����ݰ�
        /// </summary>
        private void InitData()
        {
            RTypeList = DBHelper.CIS.From<TP_RangeType>().ToList();
            rangeList = DBHelper.CIS.From<TP_Range>().ToList();
        }

        /// <summary>
        /// ��ʼ��������
        /// </summary>
        private void InitUI()
        {
            var pCode = this.gridTPRange.PrimaryGrid.Columns["colEditRTypeCode"];
            pCode.EditorType = typeof(MyComboBox);
            pCode.EditorParams = new object[] { DBHelper.CIS.From<TP_RangeType>().ToList() };
        }

        /// <summary>
        /// ��ʼ��������
        /// </summary>
        private void InitTree()
        {
            //�������ڵ�
            ROOT.Nodes.Clear();//��������ӽڵ�
            //�ڵ㸳ֵ
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
        /// ����click�¼����������ݰ�
        /// </summary>
        private void advTree1_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (Tree.SelectedNode == ROOT)
                gridTPRange.PrimaryGrid.DataSource = null;
            else
            {
                if (e != null && e.Node.ToString() != "��������")
                {
                    TP_RangeType RType = e.Node.Tag as TP_RangeType;
                    HasRangeList.Clear();
                    //����ɸѡ
                    HasRangeList = rangeList.Where(x => x.RangeTypeCode == RType.Code).ToList();
                    gridTPRange.PrimaryGrid.DataSource = HasRangeList;

                }
                Application.DoEvents();
                this.gridTPRange.PrimaryGrid.SetSelectedRows(0, 1, true);
            }
        }
        
        /// <summary>
        /// ���
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode.Text == "��������")
            {
                AlertBox.Error("��ѡ������������");
                return;
            }
            FormAddRange FormAddTPRange = new FormAddRange();
            FormAddTPRange.ShowDialog();
            btnRefresh_Click(null, null);
        }

        /// <summary>
        /// �༭
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridTPRange.PrimaryGrid.DataSource != null && gridTPRange.PrimaryGrid.Rows.Count > 0)
            {
                if (gridTPRange.PrimaryGrid.GetSelectedRows().Count < 1) { AlertBox.Info("����ѡ���У�"); return; }

                GridRow row = this.gridTPRange.GetSelectedRows()[0] as GridRow;
                TP_Range temp = row.DataItem as TP_Range;    //ʵ�����༭��                    
                FormAddRange FormAddTPRange = new FormAddRange(temp);
                FormAddTPRange.ShowDialog(); 
                btnRefresh_Click(null, null);
            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gridTPRange.PrimaryGrid.DataSource != null && gridTPRange.PrimaryGrid.Rows.Count > 0)
            {
                if (gridTPRange.PrimaryGrid.GetSelectedRows().Count <= 0) { AlertBox.Info("����ѡ���У�"); return; }
                SelectedElementCollection CurrentRows = this.gridTPRange.GetSelectedRows();
                GridRow CurrentRow = (GridRow)CurrentRows[0];
                string deleteCode = CurrentRow["colEditCode"].Value.ToString();
                try
                {
                    if (MsgBox.YesNo("ȷ��Ҫɾ��ô��") == DialogResult.Yes)
                    {
                        int deleteCount = RangeTypeDal.dbTPRangeDelete(deleteCode);
                        if (deleteCount == 0)
                        {
                            AlertBox.Info("����ɹ���");
                            btnRefresh_Click(null, null);
                        }
                        else AlertBox.Info("����ʧ�ܣ�");
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.OK(ex.Message);
                }
            }
        }


        /// <summary>
        /// ��������
        /// </summary>
        private void btnManager_Click(object sender, EventArgs e)
        {
            FormAddRangeType FormAddTPRangeType = new FormAddRangeType();
            FormAddTPRangeType.ShowDialog();
        }

        /// <summary>
        /// �޸�����
        /// </summary>
        private void advTree1_NodeDoubleClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e != null && e.Node.ToString() != "��������")
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
        /// ��������
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
                    //����ɸѡ
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