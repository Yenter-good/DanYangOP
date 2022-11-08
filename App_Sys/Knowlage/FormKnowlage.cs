using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CIS.ControlLib.Controls;
using CIS.Model;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.Controls;

namespace App_Sys
{
    public partial class FormKnowlage : Form
    {
        public FormKnowlage()
        {
            InitializeComponent();
        }

        FilterList AddCategory = new FilterList();
        FilterList AddNode = new FilterList();
        FilterList AddSource = new FilterList();
        List<TP_RangeType> RangeType;
        List<TP_Range> Range;

        private void sbAddCategoty_MouseEnter(object sender, EventArgs e)
        {
            (sender as SymbolBox).SymbolColor = Color.FromArgb(255, 128, 0);
        }

        private void sbAddCategoty_MouseLeave(object sender, EventArgs e)
        {
            (sender as SymbolBox).SymbolColor = Color.FromArgb(21, 66, 200);
        }

        private void InitTree(NodeCollection Node, string ParentID, List<TP_KnowlageCategory> knowlage, List<TP_KnowlageNode> knowlageNode)
        {
            List<TP_KnowlageCategory> knowlageTmp = knowlage.Where(p => p.ParentCategotyCode == ParentID).ToList();
            if (knowlage.Count > 0)
            {
                foreach (TP_KnowlageCategory item in knowlageTmp)
                {
                    Node node = new Node(item.CategoryName);
                    node.Name = item.ID;
                    node.Tag = item;
                    node.ImageIndex = 0;
                    List<TP_KnowlageNode> knowlageNodeTmp = knowlageNode.Where(p => p.ID == item.NodeCode).ToList();
                    foreach (TP_KnowlageNode item1 in knowlageNodeTmp)
                    {
                        Node node1 = new Node(item1.Text);
                        node1.Name = item1.ID;
                        node1.Tag = item1;
                        node.Nodes.Add(node1);
                        node1.ImageIndex = 1;

                    }
                    Node.Add(node);
                    InitTree(node.Nodes, item.ID, knowlage, knowlageNode);
                }
            }
        }

        private void InitData()
        {
            List<TP_KnowlageCategory> knowlage = DBHelper.CIS.From<TP_KnowlageCategory>().ToList();
            List<TP_KnowlageNode> knowlageNode = DBHelper.CIS.From<TP_KnowlageNode>().ToList();
            InitTree(this.tvKnowlageNode.Nodes, "0", knowlage, knowlageNode);
        }

        private void InitSource()
        {
            RangeType = DBHelper.CIS.From<TP_RangeType>().ToList();
            Range = DBHelper.CIS.From<TP_Range>().ToList();
            this.AddSource.DataSource = RangeType;
            this.AddSource.DisplayMember = "Name";
            this.AddSource.ValueMember = "Code";
            this.AddSource.SearchMember = "SearchCode";
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {

        }

        private void FormKnowlage_Shown(object sender, EventArgs e)
        {
            InitData();
            InitSource();
            flyoutAddCategory.TargetControl = this.sbAddCategoty;
            flyoutAddCategory.Content = AddCategory;
            flyoutAddNode.TargetControl = this.sbAddKnowlageNode;
            flyoutAddNode.Content = AddNode;
            flyoutAddSource.TargetControl = this.btnSelectSource;
            flyoutAddSource.Content = AddSource;

            AddSource.ItemDoubleClick += AddSource_ItemDoubleClick;

        }

        void AddSource_ItemDoubleClick(object sender, FilterList.ListBoxItemClickEvent e)
        {
            this.tbxDataSource.Text = string.Format("{0}[{1}]", RangeType.Where(p => p.Code == e.ItemValue).Select(p => p.Name).First(), string.Join(",", Range.Where(p => p.RangeTypeCode == e.ItemValue).Select(p => p.Name).ToArray()));
            this.tbxDataSource.Tag = RangeType.Where(p => p.Code == e.ItemValue).Select(p => p.Code).First();
        }

        private void flyoutAddCategory_FlyoutShown(object sender, EventArgs e)
        {
            (sender as Flyout).Content.Focus();
        }

    }
}
