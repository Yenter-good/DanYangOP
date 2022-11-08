using System;
using System.Windows.Forms;

namespace App_Sys
{
    /// <summary>
    /// 模块分类
    /// </summary>
    public partial class FormModuleCategoryEdit : DevComponents.DotNetBar.OfficeForm
    {
        private bool m_IsInsertOperation = false;
        private CIS.Model.Sys_Module _Category;
        private bool _Modified = false;
        /// <summary>
        /// 获取当前的分类实体
        /// </summary>
        public CIS.Model.Sys_Module Category
        {
            get { return _Category; }
            private set { _Category = value; }
        }
        /// <summary>
        /// 获取或设置内容是否发生改变
        /// </summary>
        public bool Modified
        {
            get { return _Modified; }
            set 
            {
                if (_Modified != value)
                    this.OnModifiedChanged(value);
                _Modified = value;
            }
        }
        public FormModuleCategoryEdit()
        {
            InitializeComponent();
            _Category = new CIS.Model.Sys_Module();
            _Category.Code = Guid.NewGuid().ToString("N");
            _Category.PCode = "";
            _Category.Status = 1;
            m_IsInsertOperation = true;
        }
        public FormModuleCategoryEdit(string pCode)
        {
            InitializeComponent();
            _Category = new CIS.Model.Sys_Module();
            _Category.Code = Guid.NewGuid().ToString("N");
            _Category.PCode = pCode;
            _Category.Status = 1;
            m_IsInsertOperation = true;
        }

        public FormModuleCategoryEdit(CIS.Model.Sys_Module category)
        {
            InitializeComponent();
            if (category == null)
                throw new ArgumentNullException("分类不能为null");
            if (category.Code.IsNullOrWhiteSpace())
                throw new ArgumentException("分类代码不能为空");
            _Category = category;
            m_IsInsertOperation = false;
            //初始化界面数据
            CIS.Utility.ControlHelper.SetValue<CIS.Model.Sys_Module>(this, category,false);
            this.Modified = false;
        }
        /// <summary>
        /// 修改属性发生改变后
        /// </summary>
        /// <param name="modified"></param>
        private void OnModifiedChanged(bool modified)
        {
            this.btnOK.Enabled = modified;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //支持Esc退出窗体
            if (keyData == Keys.Escape)
            {
                if (this.Modal)
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.input_Text.Text.IsNullOrWhiteSpace())
            {
                this.input_Text.Focus();
                this.warningBox1.Text = "分类名称不能为空";
                this.warningBox1.AutoCloseTimeout = 2;
                this.warningBox1.Show();
                return;
            }
            CIS.Utility.ControlHelper.RefreshValue<CIS.Model.Sys_Module>(this,_Category);

            bool success = false;
            if (m_IsInsertOperation)
            {
               success = CIS.Model.DBHelper.CIS.Insert<CIS.Model.Sys_Module>(_Category) > 0;
            }
            else
            {
               success = CIS.Model.DBHelper.CIS.Update<CIS.Model.Sys_Module>(_Category) > 0;
            }

            if (success)
            {
                if (this.Modal)
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                this.warningBox1.Text = m_IsInsertOperation ? "插入数据失败" : "保存数据失败";
                this.warningBox1.AutoCloseTimeout = 0;
                this.Show();
            }
        }
        //监听内容变化
        private void txt_TextChanged(object sender, EventArgs e)
        {
            this.Modified = true;
        }

        private void FormModuleCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                e.Handled = true;
            }
        }

    }
}
