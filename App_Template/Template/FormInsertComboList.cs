using System;
using System.Windows.Forms;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;

namespace App_Template
{
    public partial class FormInsertComboList : CIS.Core.BaseForm
    {
        public FormInsertComboList()
        {
            InitializeComponent();
        }

        public XTextInputFieldElement input;

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string[] str = this.textBoxX2.Text.Split(this.textBoxX1.Text.ToCharArray());
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            field.FieldSettings.MultiSelect = this.checkBox1.Checked;
            field.FieldSettings.ListSource = new ListSourceInfo();
            field.FieldSettings.ListSource.Items = new ListItemCollection();
            foreach (var item in str)
            {
                ListItem list = new ListItem();
                list.Text = item;
                field.FieldSettings.ListSource.Items.Add(list);
            }
            input = field;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btnInsert_Click(null, null);
        }
    }
}
