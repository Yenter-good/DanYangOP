using System;
using System.Collections.Generic;
using System.Reflection;
using CIS.Model;
using CIS.Utility;
using DevComponents.AdvTree;
using CIS.Core;

namespace App_Template
{
    public partial class FormTemplateSampleSave : CIS.Core.BaseForm
    {
        public FormTemplateSampleSave()
        {
            InitializeComponent();
        }

        public OP_TemplateSample SelectNode;
        public Node resultNode;
        public string ParentNodeID;
        public List<OP_Dic_TemplateNode> TemplateNode;
        public RecordDate date;
        public Node Folder;
        List<OP_TemplateSample> PersonTree;
        List<OP_TemplateSample> OfficeTree;

        #region 初始化操作
        /// <summary>
        /// 初始化所属组树状图
        /// </summary>
        private void InitTree()
        {
            PersonTree = DBHelper.CIS.From<OP_TemplateSample>().Where(p => p.NodeType == 0 && p.DeptCode == "" && p.UserID == SysContext.CurrUser.user.Code).ToList();
            OfficeTree = DBHelper.CIS.From<OP_TemplateSample>().Where(p => p.NodeType == 0 && p.UserID == "" && p.DeptCode == SysContext.RunSysInfo.currDept.Code).ToList();
            OP_TemplateSample personTemplate = new OP_TemplateSample();
            OP_TemplateSample officeTemplate = new OP_TemplateSample();
            personTemplate.ID = "";
            personTemplate.SampleName = "个人";
            personTemplate.ParentID = "1";
            personTemplate.NodeType = 0;
            PersonTree.Insert(0, personTemplate);
            officeTemplate = personTemplate.Clone();
            officeTemplate.SampleName = "科室";
            OfficeTree.Insert(0, officeTemplate);
            List<TreeModel1> list = new List<TreeModel1>();
            if (SelectNode != null)
            {
                if (SelectNode.UserID == "")
                {
                    foreach (OP_TemplateSample item in OfficeTree)
                        list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.SampleName.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType ?? 0 });
                    this.checkBox1.Checked = true;
                }
                else
                {
                    foreach (OP_TemplateSample item in PersonTree)
                        list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.SampleName.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType ?? 0 });
                    this.checkBox1.Checked = false;
                }

                CIS.Utility.TreeHelper.CreateChildsNode(this.cbxOwnerFolder.AdvTree.Nodes, "1", list, false, null);

                this.cbxOwnerFolder.AdvTree.ExpandAll();
                this.cbxOwnerFolder.AdvTree.SelectedIndex = 0;
                Node[] nodes = this.cbxOwnerFolder.AdvTree.Nodes.Find(SelectNode.ParentID, true);
                if (nodes.Length != 0)
                    this.cbxOwnerFolder.AdvTree.SelectedNode = nodes[0];
            }
            else
            {
                foreach (OP_TemplateSample item in PersonTree)
                    list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.SampleName.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType ?? 0 });
                CIS.Utility.TreeHelper.CreateChildsNode(this.cbxOwnerFolder.AdvTree.Nodes, "1", list, false, null);
                this.cbxOwnerFolder.AdvTree.ExpandAll();
                this.cbxOwnerFolder.AdvTree.SelectedIndex = 0;
            }
        }

        private void InitName()
        {
            if (SelectNode != null)
                this.tbxName.Text = SelectNode.SampleName;
        }
        #endregion

        #region 窗体事件

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //if (Folder == null)
            //{
            //    CIS.Core.AlertBox.Info("请选择要保存到哪个文件夹下");
            //    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //    this.Close();
            //    return;
            //}
            OP_TemplateSample tmp = SelectNode == null ? new OP_TemplateSample() : SelectNode;
            string ParentID;
            if (Folder.Tag == null)
                ParentID = "";
            else
                ParentID = (Folder.Tag as OP_TemplateSample).ID;

            if (Folder.Text == "科室")
            {
                tmp.DeptCode = SysContext.RunSysInfo.currDept.Code;
                tmp.UserID = "";
            }
            else
            {
                tmp.UserID = SysContext.CurrUser.user.Code;
                tmp.DeptCode = "";
            }

            tmp.SampleName = this.tbxName.Text;
            tmp.ParentID = ParentID;
            tmp.UpdateTime = DBHelper.ServerTime;
            tmp.NodeType = 1;
            if (date != null)
            {
                foreach (OP_Dic_TemplateNode item in TemplateNode)
                {
                    PropertyInfo propertyInfo = date.GetType().GetProperty(item.Code);
                    PropertyInfo propertyInfo1 = tmp.GetType().GetProperty(item.Code);
                    if (propertyInfo != null && propertyInfo1 != null)
                        propertyInfo1.SetValue(tmp, propertyInfo.GetValue(date, null), null);
                }
            }
            List<string> deptCode = new List<string>();

            if (SelectNode == null)
            {
                tmp.ID = Guid.NewGuid().ToString();
                DBHelper.CIS.Insert<OP_TemplateSample>(tmp);
            }
            else
            {
                DBHelper.CIS.Update<OP_TemplateSample>(tmp, p => p.ID == tmp.ID);
            }
            AlertBox.Info("保存成功");

            Node result = new Node(this.tbxName.Text);
            result.Name = tmp.ID;
            result.Tag = tmp;
            resultNode = result;
            ParentNodeID = ParentID;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        #endregion

        private void FormTemplateSampleSave_Shown(object sender, EventArgs e)
        {
            InitTree(); InitName();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.cbxOwnerFolder.AdvTree.Nodes.Clear();
            List<TreeModel1> list = new List<TreeModel1>();
            if (this.checkBox1.Checked)
            {
                foreach (OP_TemplateSample item in OfficeTree)
                    list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.SampleName.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType ?? 0 });
            }
            else
            {
                foreach (OP_TemplateSample item in PersonTree)
                    list.Add(new CIS.Utility.TreeModel1 { Code = (item.ID ?? "").Trim(), ParentCode = (item.ParentID ?? "").Trim(), Text = item.SampleName.Trim(), Obj = item, Name = item.ID.Trim(), ImgIndex = item.NodeType ?? 0 });
            }
            CIS.Utility.TreeHelper.CreateChildsNode(this.cbxOwnerFolder.AdvTree.Nodes, "1", list, false, null);
            this.cbxOwnerFolder.AdvTree.ExpandAll();
            this.cbxOwnerFolder.AdvTree.SelectedIndex = 0;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
