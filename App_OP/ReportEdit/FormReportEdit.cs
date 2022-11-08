using DevComponents.AdvTree;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CIS.Model;
using CIS.Core;

namespace App_OP
{
    /// <summary>
    /// 编辑模块
    /// </summary>
    public partial class FormReportEdit : BaseForm
    {
        List<OP_Dic_Report> reportList;

        public OP_Dic_Report Report
        {
            get; set;
        }

        public OP_Dic_Report Result { get; set; }
        public FormReportEdit(OP_Dic_Report report)
        {
            Report = report;
            this.InitializeComponent();
        }

        private void FormMenuEdit_Load(object sender, EventArgs e)
        {
            reportList = DBHelper.CIS.From<OP_Dic_Report>().ToList();

            InitCategory(Report.ParentID);
            Init();
        }
        string[] openStyle = new string[] { "文档", "方法", "窗体", "对话框" };

        private void Init()
        {
            this.tbxItemName.Text = Report.ItemName;
            this.tbxAssembly.Text = Report.Assembly;
            this.tbxMethod.Text = Report.MethodName;
            this.tbxNameSpace.Text = Report.NameSpace;
            this.tbxNo.Text = Report.No.ToString();
            this.cbxOpenStyle.SelectedIndex = Array.IndexOf(openStyle, Report.Type);
            if (Report.Status == 0)
                this.rbtnEnable.Checked = true;
            else
                this.rbtnDisable.Checked = true;
        }

        private void InitCategory(string parentID)
        {
            var tmp = reportList
            .Select(m => new CIS.Utility.TreeModel1 { Code = m.ID, ParentCode = m.ParentID, Sort = m.No.GetValueOrDefault(0), Text = m.ItemName, Obj = m, Name = m.ID })
            .ToList();
            tmp.RemoveAll(p => p.Text == "报卡" && p.ParentCode == "");

            this.comboTree1.AdvTree.BeginUpdate();
            this.menuRootNode.Nodes.Clear();
            CIS.Utility.TreeHelper.CreateChildsNode(this.menuRootNode.Nodes, "", tmp, false);
            this.comboTree1.AdvTree.EndUpdate();

            this.comboTree1.AdvTree.ExpandAll();
            if (parentID == "")
                this.comboTree1.SelectedNode = this.menuRootNode;
            else
                this.comboTree1.SelectedNode = this.menuRootNode.Nodes.Find(parentID, true)[0];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.tbxItemName.Text == "")
                return;

            Result = new OP_Dic_Report();
            Result.ItemName = this.tbxItemName.Text;
            Result.Assembly = this.tbxAssembly.Text;
            Result.MethodName = this.tbxMethod.Text;
            Result.NameSpace = this.tbxNameSpace.Text;
            Result.No = this.tbxNo.Text.AsInt(0);
            Result.Type = this.cbxOpenStyle.SelectedIndex == -1 ? "" : openStyle[this.cbxOpenStyle.SelectedIndex];
            Result.Status = this.rbtnEnable.Checked ? 0 : 1;
            Result.ParentID = this.comboTree1.SelectedNode.Tag == null ? "" : (this.comboTree1.SelectedNode.Tag as OP_Dic_Report).ID;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
