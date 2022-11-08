using System;
using System.Windows.Forms;

namespace App_Sys
{
    /// <summary>
    /// 模块分类
    /// </summary>
    public partial class FormSystemEdit : DevComponents.DotNetBar.OfficeForm
    {
        private bool m_IsInsertOperation = false;
        private CIS.Model.Sys_App _App;
        private bool _Modified = false;
        /// <summary>
        /// 获取当前的分类实体
        /// </summary>
        public CIS.Model.Sys_App App
        {
            get { return _App; }
            private set { _App = value; }
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
        public FormSystemEdit()
        {
            InitializeComponent();
            _App = new CIS.Model.Sys_App();
            _App.Code = Guid.NewGuid().ToString("N");
            _App.Status = 1;
            m_IsInsertOperation = true;
        }
        public FormSystemEdit(string pCode)
        {
            InitializeComponent();
            _App = new CIS.Model.Sys_App();
            _App.Code = Guid.NewGuid().ToString("N");
            _App.Status = 1;
            m_IsInsertOperation = true;
        }

        public FormSystemEdit(CIS.Model.Sys_App app)
        {
            InitializeComponent();
            if (app == null)
                throw new ArgumentNullException("系统对象不能为null");
            if (app.Code.IsNullOrWhiteSpace())
                throw new ArgumentException("系统代码不能为空");
            _App = app;
            m_IsInsertOperation = false;
            //初始化界面数据
            CIS.Utility.ControlHelper.SetValue<CIS.Model.Sys_App>(this, app, false);
            this.rbtnEnable.Checked = app.Status == 1;
            this.rbtnDisable.Checked = app.Status != 1;
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
            if (this.input_Name.Text.IsNullOrWhiteSpace())
            {
                this.input_Name.Focus();
                this.warningBox1.Text = "系统名称不能为空";
                this.warningBox1.AutoCloseTimeout = 2;
                this.warningBox1.Show();
                return;
            }
            CIS.Utility.ControlHelper.RefreshValue<CIS.Model.Sys_App>(this,_App);
            if (this.rbtnEnable.Checked && _App.Status!=1)
                _App.Status = 1;
            if (this.rbtnDisable.Checked && _App.Status ==1)
                _App.Status = 0;
            bool success = false;
            if (m_IsInsertOperation)
            {
                success = CIS.Model.DBHelper.CIS.Insert<CIS.Model.Sys_App>(_App) > 0;
            }
            else
            {
                success = CIS.Model.DBHelper.CIS.Update<CIS.Model.Sys_App>(_App) > 0;
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

        private void input_Status_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as DevComponents.DotNetBar.Controls.CheckBoxX;
            //if (cb.Checked != rbtnDisable.Checked)
            {
                this.Modified = true;
            }
        }

    }
}
