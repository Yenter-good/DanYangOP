using DevComponents.AdvTree;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace App_Sys
{
    /// <summary>
    /// 编辑模块
    /// </summary>
    public partial class FormModuleEdit:CIS.Core.DialogBase
    {
        private bool m_IsInsertOpration = false;
        private CIS.Model.Sys_Module _Module;

        public CIS.Model.Sys_Module Module
        {
            get { return _Module; }
        }
        public string PText {
            get
            {
                if (this.comboTree1.SelectedNode == null) return "";
                return this.comboTree1.SelectedNode.Text;
            }
        }
       
        public FormModuleEdit(string pCode)
        {
            this.InitializeComponent();

            _Module = new CIS.Model.Sys_Module();
            _Module.Code = Guid.NewGuid().ToString("N");
            _Module.PCode = pCode;
            _Module.Status = 1;
            this.BindCategoryTree(pCode);
            this.m_IsInsertOpration = true;
        }
        public FormModuleEdit(CIS.Model.Sys_Module module)
        {
            this.InitializeComponent();

            if (module == null)
                throw new ArgumentNullException("模块不能为null");
            _Module = module;
            this.m_IsInsertOpration = false;
            CIS.Utility.ControlHelper.SetValue<CIS.Model.Sys_Module>(this, _Module,false);
            this.BindCategoryTree(_Module.PCode);
            
            this.Modified = false;
        }
        /// <summary>
        /// 绑定分类下拉树
        /// </summary>
        /// <param name="defaultSelectedCode"></param>
        private void BindCategoryTree(string defaultSelectedCode)
        {
             var categroyTable = CIS.Model.DBHelper.CIS.FromSql("select CODE,TEXT,PCODE from sys_module where (RNO='' OR RNO IS NULL OR FNAME='' OR FNAME IS NULL) and status=1")
                .ToDataTable();
            List<CIS.Utility.TreeModel> models = new List<CIS.Utility.TreeModel>();
            foreach (DataRow dr in categroyTable.Rows)
            {
                CIS.Utility.TreeModel model = new CIS.Utility.TreeModel();
                model.Code = dr["CODE"].AsString();
                model.Text = dr["TEXT"].AsString();
                model.ParentCode = dr["PCODE"].AsString();
                model.Obj=dr["CODE"].AsString();
                models.Add(model);
            }
            CIS.Utility.TreeHelper.FillNodes(this.comboTree1, CIS.Utility.TreeHelper.CreateChildNodes(models,false, NodeFormat));
            if(defaultSelectedCode.IsNullOrWhiteSpace())
                return;
            var node = this.comboTree1.AdvTree.FindNodeByName(defaultSelectedCode);
            if(node!=null)
                this.comboTree1.SelectedNode=node;
        }
        /// <summary>
        /// 格式化节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="treeModel"></param>
        private void NodeFormat(Node node, CIS.Utility.TreeModel treeModel)
        { 
           
        }
        /// <summary>
        /// 验证数据
        /// </summary>
        /// <returns></returns>
        protected override bool Validate()
        {
            if (this.comboTree1.SelectedNode == null)
            {
                this.comboTree1.Focus();
                this.warningBox1.Text = "<b>警告</b> 请指定模块分类";
                this.warningBox1.AutoCloseTimeout = 2;
                this.warningBox1.Show();
                return false;
            }
            if (this.input_Text.Text.IsNullOrWhiteSpace())
            {
                this.input_Text.Focus();
                this.warningBox1.Text = "<b>警告</b> 模块名称不能为空";
                this.warningBox1.AutoCloseTimeout = 2;
                this.warningBox1.Show();
                return false;
            }
            if (this.input_RNO.Text.IsNullOrWhiteSpace())
            {
                this.input_RNO.Focus();
                this.warningBox1.Text = "<b>警告</b> 请输入程序集";
                this.warningBox1.AutoCloseTimeout = 2;
                this.warningBox1.Show();
                return false;
            }
            if (this.input_FName.Text.IsNullOrWhiteSpace())
            {
                this.input_FName.Focus();
                this.warningBox1.Text = "<b>警告</b> 请输入命名空间";
                this.warningBox1.AutoCloseTimeout = 2;
                this.warningBox1.Show();
                return false;
            }
            return base.Validate();
        }
        /// <summary>
        /// 保存失败后
        /// </summary>
        /// <param name="cancelReason"></param>
        protected override void OnOKingCancel(string cancelReason)
        {
            this.warningBox1.Text = cancelReason;
            this.warningBox1.AutoCloseTimeout = 0;
            this.warningBox1.Show();
        }
        private void FormModuleEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog =new OpenFileDialog())
            {
                fileDialog.DefaultExt = ".dll";
                fileDialog.Filter = "dll文件|*.dll|exe程序|*.exe";
                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (FormDLLBrowser dialog = new FormDLLBrowser())
                    {
                        dialog.Reflection(fileDialog.FileName);
                        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            this.input_FName.Text = dialog.FullName;
                            this.input_RNO.Text = dialog.Dll;
                            this.input_Text.Text = dialog.FormTitle;
                        }
                    }
                }
            }
           
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            this.Modified = true;
        }
        /// <summary>
        /// 保存时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormModuleEdit_OKing(object sender, CIS.Core.CancelEventArgsExt e)
        {
            CIS.Utility.ControlHelper.RefreshValue<CIS.Model.Sys_Module>(this, _Module);
            if (this.comboTree1.SelectedNode.Name != _Module.PCode)
            {
                _Module.PCode = this.comboTree1.SelectedNode.Name;
            }
            bool success = false;
            if (m_IsInsertOpration)
                success = CIS.Model.DBHelper.CIS.Insert<CIS.Model.Sys_Module>(_Module) > 0;
            else
                success = CIS.Model.DBHelper.CIS.Update<CIS.Model.Sys_Module>(_Module) > 0;
            e.Cancel = !success;
            e.CancelReason = m_IsInsertOpration?"插入失败":"更新失败";
        }
    }
}
