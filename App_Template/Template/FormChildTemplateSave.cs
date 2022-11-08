using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CIS.Model;

namespace App_Template
{
    public partial class FormChildTemplateSave : CIS.Core.BaseForm
    {
        public FormChildTemplateSave()
        {
            InitializeComponent();
        }

        public ChildTemplate form;
        public string SearchName;
        public string TypeName;

        private void FormChildTemplateSave_Shown(object sender, EventArgs e)
        {
            List<OP_Dic_TemplateNode> list = DBHelper.CIS.From<OP_Dic_TemplateNode>().OrderBy(p => p.No).ToList();
            this.comboBoxEx1.DataSource = list;
            this.textBox1.Text = SearchName;
            List<OP_Dic_TemplateNode> node = list.Where(p => p.Code == TypeName).ToList();
            if (node.Count != 0)
                this.comboBoxEx1.SelectedItem = node[0];
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            form.TemplateTypeCode = this.comboBoxEx1.SelectedValue.ToString();
            form.TemplateTypeCodeName = (this.comboBoxEx1.SelectedItem as OP_Dic_TemplateNode).Name;
            form.TemplateSearchName = this.textBox1.Text;
            form.SaveTemplate();
            this.Close();
            CIS.Core.AlertBox.Info("保存成功");
        }
    }
}
