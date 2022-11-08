using System;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.AdvTree;

namespace App_Template
{
    public partial class ChildTemplate : CIS.Core.BaseForm
    {
        public ChildTemplate()
        {
            InitializeComponent();
        }

        public string TemplateTypeCode;
        public string TemplateTypeCodeName;
        public string TemplateSearchName;

        protected override void InitializeShortcutKeys(CIS.Core.ShortcutKey shortcutKey)
        {
            shortcutKey.Set(Shortcut.CtrlS, () => templateDesignControl1_btnSave_Click(null, null), "保存");
        }

        private void ChildTemplate_Shown(object sender, EventArgs e)
        {
            this.templateDesignControl1.ShowElementTree = false;
            this.templateDesignControl1.ShowWordLib();
            this.templateDesignControl1.InsertVisible = true;
            this.childTemplateTree1.InitTemplate();
        }

        private void templateDesignControl1_btnSave_Click(object sender, EventArgs e)
        {
            if (this.childTemplateTree1.Tree.SelectedNode == null)
            {
                MessageBox.Show("未选择子模板,无法保存");
                return;
            }
            OP_SubTemplate template = (this.childTemplateTree1.Tree.SelectedNode.Tag as OP_SubTemplate);
            FormChildTemplateSave form = new FormChildTemplateSave();
            form.form = this;
            form.SearchName = template.SearchCode ?? "";
            form.TypeName = template.Tag ?? "";
            form.ShowDialog();
        }

        #region 模板操作

        /// <summary>
        /// 保存模版内容
        /// </summary>
        public void SaveTemplate()
        {

            Node node = this.childTemplateTree1.Tree.SelectedNode;
            if (node == null || node.Tag == null)
            {
                CIS.Core.AlertBox.Info("未选中子模板节点,无法保存");
                return;
            }
            if (node.Tag.GetType() == typeof(OP_SubTemplate))
            {
                string xml = this.templateDesignControl1.XMLText;
                if (this.templateDesignControl1.WriterControl.Document.Body.HasContentElement)
                {
                    OP_SubTemplate template = node.Tag as OP_SubTemplate;
                    template.Content = xml;
                    node.Tag = template;
                    template.Tag = TemplateTypeCode;
                    template.TagName = TemplateTypeCodeName;
                    template.SearchCode = TemplateSearchName;
                    DBHelper.CIS.Update<OP_SubTemplate>(template, p => p.ID == template.ID);
                }
            }
            else
            {
                CIS.Core.AlertBox.Info("请在模板节点编写模板");
            }
        }

        #endregion

        private void advTree1_AfterCellEdit(object sender, CellEditEventArgs e)
        {
            this.childTemplateTree1.UpdateTemplate(e.Cell.Parent, e.NewText);
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            this.childTemplateTree1.AddFolder();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            this.childTemplateTree1.AddTemplate();

        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            this.childTemplateTree1.DeleteTemplate();
        }

        private void childTemplateTree1_NodeMouseDown(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                OP_SubTemplate template = e.Node.Tag as OP_SubTemplate;
                this.templateDesignControl1.XMLText = template.Content;
            }
        }


        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.childTemplateTree1.EditTemplate();
        }
    }
}
