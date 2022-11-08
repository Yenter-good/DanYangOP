using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.AdvTree;
using CIS.Model;
using CIS.Purview;

namespace App_Template
{
    public partial class MainTemplate : CIS.Core.BaseForm
    {
        public MainTemplate()
        {
            InitializeComponent();
        }

        protected override void InitializeShortcutKeys(CIS.Core.ShortcutKey shortcutKey)
        {
            shortcutKey.Set(Shortcut.CtrlS, () => templateDesignControl1_btnSave_Click(null, null), "保存");
        }

        List<TP_Template> AllTemplate = new List<TP_Template>();

        private void MainTemplate_Shown(object sender, EventArgs e)
        {
            this.templateDesignControl1.ShowElement();
            InitUI(SysParams.GetTemplateHeaderAndFooter);
            AllTemplate = DBHelper.CIS.From<TP_Template>().ToList();
            InitTree();
            this.templateDesignControl1.ShowElementTree = true;
        }

        #region 模板操作
        /// <summary>
        /// 添加模板
        /// </summary>
        private void AddTemplate()
        {
            Node node = this.advTree1.SelectedNode;
            //this.templateDesignControl1.XMLText = "";
            if (node == null || node.Tag == null) return;
            Node newNode = new Node("请输入模板名称");
            newNode.ImageIndex = 1;
            newNode.Tag = new TP_Template();
            if (node.Tag.GetType() == typeof(TP_Template))
                node.Parent.Nodes.Add(newNode);
            else if ((node.Nodes.Count == 0 && node.Tag.GetType() == typeof(IView_Dept)) || (node.Nodes.Count != 0 && node.Nodes[0].Tag.GetType() == typeof(TP_Template)))
                node.Nodes.Add(newNode);
            else
            {
                CIS.Core.AlertBox.Info("请在科室下添加模板");
                return;
            }
            this.advTree1.SelectNode(newNode, eTreeAction.Code);
            newNode.BeginEdit();
        }

        /// <summary>
        /// 更新模板
        /// </summary>
        /// <param name="node"></param>
        private void UpdateTemplate(Node node, string newText)
        {
            TP_Template template = node.Tag as TP_Template;
            template.DeptLimit = (node.Parent.Tag as IView_Dept).Code;
            if (this.templateDesignControl1.WriterControl.Document.Body.HasContentElement)
                template.DocumentContent = this.templateDesignControl1.XMLText;
            template.DocumentID = Guid.NewGuid().ToString();
            template.Name = newText;
            template.No = node.Index;
            template.SpellCode = node.Text.GetSpell();
            template.Status = 1;
            template.WubiCode = node.Text.GetWBM();
            if (template.ID == null || template.ID == "")
            {
                template.ID = Guid.NewGuid().ToString();
                DBHelper.CIS.Insert<TP_Template>(template);
            }
            else
            {
                DBHelper.CIS.Update<TP_Template>(template, p => p.ID == template.ID);
            }
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        private void DeleteTemplate()
        {
            Node node = this.advTree1.SelectedNode;
            if (node == null) return;
            if (node.Tag.GetType() == typeof(TP_Template))
            {
                string ID = (node.Tag as TP_Template).ID;
                DBHelper.CIS.Delete<TP_Template>(p => p.ID == ID);
                node.Parent.Nodes.Remove(node);
            }
        }

        /// <summary>
        /// 保存模版内容
        /// </summary>
        private void SaveTemplate()
        {

            Node node = this.advTree1.SelectedNode;
            if (node == null) return;
            if (node.Tag.GetType() == typeof(TP_Template))
            {
                string xml = this.templateDesignControl1.XMLText;
                if (this.templateDesignControl1.WriterControl.Document.Body.HasContentElement)
                {
                    TP_Template template = node.Tag as TP_Template;
                    template.DocumentContent = xml;
                    node.Tag = template;
                    DBHelper.CIS.Update<TP_Template>(template, p => p.ID == template.ID);
                }
            }
            else
            {
                CIS.Core.AlertBox.Info("请在模板节点编写模板");
            }
        }

        /// <summary>
        /// 编辑模板
        /// </summary>
        private void EditTemplate()
        {
            Node node = this.advTree1.SelectedNode;
            if (node == null) return;
            if (node.Tag.GetType() == typeof(TP_Template))
                node.BeginEdit();
        }
        #endregion

        #region 初始化操作
        /// <summary>
        /// 初始化模板框架
        /// </summary>
        /// <param name="Headers"></param>
        public void InitUI(string Headers)
        {
            this.templateDesignControl1.XMLText = Headers;
        }

        /// <summary>
        /// 初始化模板树结构
        /// </summary>
        private void InitTree()
        {
            List<IView_Dept> dept = DBHelper.CIS.From<IView_Dept>().Where(p => p.Type == (int)DeptType.Outpatient || p.Type == (int)DeptType.ObservationWard || p.Type == (int)DeptType.Emergency).ToList();
            List<CIS.Utility.TreeModel1> list = new List<CIS.Utility.TreeModel1>();
            foreach (IView_Dept item in dept)
            {
                list.Add(new CIS.Utility.TreeModel1 { Code = (item.Code ?? "").Trim(), ParentCode = (item.PCode ?? "").Trim(), Text = item.Name.Trim(), Obj = item, Name = item.Code.Trim(), ImgIndex = 0 });
            }
            CIS.Utility.TreeHelper.CreateChildsNode(this.advTree1.Nodes[0].Nodes, "1", list, false, this.imageList1);
            this.advTree1.ExpandAll();
            Application.DoEvents();
            foreach (TP_Template item in AllTemplate)
            {
                string deptCode = item.DeptLimit.ToString().Trim();
                Node[] nodes = this.advTree1.Nodes.Find(deptCode, true);
                if (nodes.Length != 0)
                {
                    Node node = new Node(item.Name);
                    node.ImageIndex = 1;
                    node.Tag = item;
                    nodes[0].Nodes.Add(node);
                }
            }
        }
        #endregion

        #region 窗体事件
        private void advTree1_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag.GetType() == typeof(TP_Template))
            {
                string xml = (e.Node.Tag as TP_Template).DocumentContent;
                if (xml == null || xml == "")
                    this.templateDesignControl1.XMLText =SysParams.GetTemplateHeaderAndFooter ;
                else
                    this.templateDesignControl1.XMLText = xml;
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            AddTemplate();
        }

        private void advTree1_AfterCellEdit(object sender, CellEditEventArgs e)
        {
            UpdateTemplate(e.Cell.Parent, e.NewText);
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            EditTemplate();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            DeleteTemplate();
        }

        private void templateDesignControl1_btnSave_Click(object sender, EventArgs e)
        {
            SaveTemplate();
        }
        #endregion

        private void 增加模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTemplate();
        }

        private void 修改模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTemplate();
        }

        private void 删除模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTemplate();
        }

    }
}
