using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CIS.Model;

namespace App_OP.Record
{
    public partial class FormRecordSample : CIS.Core.BaseForm
    {
        public FormRecordSample()
        {
            InitializeComponent();
        }

        public FormRecord form;

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvTemplateSample.Rows)
            {
                item.Cells["Selected"].Value = this.cbxSelectAll.Checked;
            }
        }

        private void FormRecordSample_Shown(object sender, EventArgs e)
        {
            RecordDate tmp = form.GetRecordContext();
            List<OP_Dic_TemplateNode> dic = DBHelper.CIS.From<OP_Dic_TemplateNode>().ToList();
            foreach (OP_Dic_TemplateNode item in dic)
            {
                PropertyInfo propertyInfo = tmp.GetType().GetProperty(item.Code);
                if (propertyInfo != null)
                {
                    bool isNull = propertyInfo.GetValue(tmp, null).IsNull();
                    if (isNull) continue;
                    int index = this.dgvTemplateSample.Rows.Add();
                    Regex regex = new Regex(@"\%\%\%\$\$\$CIS999");
                    string[] str = regex.Split(propertyInfo.GetValue(tmp, null).ToString());
                    this.dgvTemplateSample.Rows[index].Cells["Context"].Value = item.Name + ":" + str[0];
                    this.dgvTemplateSample.Rows[index].Cells["XML"].Value = str[1];
                    this.dgvTemplateSample.Rows[index].Cells["ID"].Value = Guid.NewGuid().ToString();
                    this.dgvTemplateSample.Rows[index].Cells["Type"].Value = item.Code;

                }
            }
        }

        private void dgvTempleSample_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dgvTemplateSample.Rows[e.RowIndex].Cells["Selected"].Value = !Convert.ToBoolean(this.dgvTemplateSample.Rows[e.RowIndex].Cells["Selected"].Value);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.tbxMc.Text == "")
            {
                CIS.Core.AlertBox.Info("您未设置范文的名称,保存失败");
                return;
            }
            SaveTemplateSample();
        }

        private void SaveTemplateSample()
        {
            OP_TemplateSample template = new OP_TemplateSample();
            template.ID = Guid.NewGuid().ToString();
            if (this.cbxSharedToDept.Checked)
            {
                template.DeptCode = CIS.Core.SysContext.RunSysInfo.currDept.Code;
                template.UserID = "";
            }
            else
            {
                template.UserID = CIS.Core.SysContext.CurrUser.user.Code;
                template.DeptCode = "";
            }
            template.UpdateTime = DBHelper.ServerTime;
            template.SampleName = this.tbxMc.Text;
            template.ParentID = "";
            template.NodeType = 1;
            bool HasSelect = false;

            foreach (DataGridViewRow item in this.dgvTemplateSample.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Selected"].Value))
                {
                    HasSelect = true;
                    string Type = item.Cells["Type"].Value.ToString();
                    PropertyInfo propertyInfo = template.GetType().GetProperty(Type);
                    if (propertyInfo != null)
                        propertyInfo.SetValue(template, item.Cells["XML"].Value.ToString(), null);
                }
            }
            if (HasSelect)
            {
                DBHelper.CIS.Insert<OP_TemplateSample>(template);
                CIS.Core.AlertBox.Info("保存成功");
                this.Close();
            }
            else
                CIS.Core.AlertBox.Info("您未选中任何内容");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
