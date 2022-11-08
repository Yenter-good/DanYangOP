using DevComponents.AdvTree;
using System;
using System.Data;
using System.Linq;

namespace App_Sys
{
    /// <summary>
    /// 编辑模块
    /// </summary>
    public partial class FormMenuEdit:CIS.Core.DialogBase
    {
        private bool m_Initialize = false;
        private bool m_IsInsertOpration = false;
        private CIS.Model.Sys_Menu _Menu;

        public CIS.Model.Sys_Menu SysMenu
        {
            get { return _Menu; }
        }
        public string PText {
            get
            {
                if (this.comboTree1.SelectedNode == null) return "";
                return this.comboTree1.SelectedNode.Text;
            }
        }
       
        public FormMenuEdit(string appCode,string pCode)
        {
            m_Initialize = true;
            if (appCode.IsNullOrWhiteSpace())
                throw new ArgumentNullException("系统编码不能为空");
            this.InitializeComponent();

            _Menu = new CIS.Model.Sys_Menu();
            _Menu.MenuCode = Guid.NewGuid().ToString("N");
            _Menu.MenuPCode = pCode.AsString("0");
            _Menu.AppCode = appCode;
            _Menu.Status = 1;
            this.InitSystem(appCode);
            this.InitCategory(appCode, pCode);
            this.m_IsInsertOpration = true;
            m_Initialize = false;
        }
        public FormMenuEdit(CIS.Model.Sys_Menu menu)
        {
            m_Initialize = true;
            this.InitializeComponent();

            if (menu == null)
                throw new ArgumentNullException("菜单对象不能为null");
            _Menu = menu;
            this.m_IsInsertOpration = false;
            CIS.Utility.ControlHelper.SetValue<CIS.Model.Sys_Menu>(this, _Menu,false);
            string pCode =null;
            if (CIS.Utility.TreeModel.IsRootNode(_Menu.MenuPCode))
                pCode = menuRootNode.Name;
            else
                pCode = _Menu.MenuPCode;
            this.InitSystem(_Menu.AppCode);
            this.InitCategory(_Menu.AppCode, pCode);
            this.cmbOpenStyle.SelectedIndex = _Menu.MenuOpenStyle.HasValue ? (int)_Menu.MenuOpenStyle.Value : -1;
            this.rbtnEnable.Checked = menu.Status == 1;
            this.rbtnDisable.Checked = menu.Status == 0;
            this.Modified = false;
            m_Initialize = false;
        }
        /// <summary>
        /// 绑定分类下拉树
        /// </summary>
        /// <param name="defaultSelectedCode"></param>
        private void InitSystem(string defaultSelectedCode)
        {

            this.input_AppCode.DataBind(CIS.Model.DBHelper.CIS.From<CIS.Model.Sys_App>()
                .Select(a => new { Code=a.Code, Name=a.Name })
                .Where(a=>a.Status==1)
                .ToList()
                , "Code", "Name",defaultSelectedCode);
        }
        /// <summary>
        /// 初始化分类
        /// </summary>
        /// <param name="appCode"></param>
        /// <param name="selectedMenuCode"></param>
        private void InitCategory(string appCode,string selectedMenuCode=null)
        {
            var models = CIS.Model.DBHelper.CIS.From<CIS.Model.Sys_Menu>()
                .Select(d => new { d.MenuCode, d.MenuPCode, d.Text, d.No })
                .Where(m => m.Status == 1 && m.AppCode == appCode)
                .ToList()
                .Select(m => new CIS.Utility.TreeModel { Code=m.MenuCode, ParentCode=m.MenuPCode, Sort=m.No.GetValueOrDefault(0), Text=m.Text, Obj=m })
                .ToList();

            this.comboTree1.AdvTree.BeginUpdate();
            this.menuRootNode.Nodes.Clear();
            this.menuRootNode.Nodes.AddRange( CIS.Utility.TreeHelper.CreateChildNodes(models,false, NodeFormat));
            this.comboTree1.AdvTree.EndUpdate();

            this.comboTree1.AdvTree.ExpandAll();
            if (selectedMenuCode.IsNullOrWhiteSpace())
                return;

            var node = this.comboTree1.AdvTree.FindNodeByName(selectedMenuCode);
            if (node != null)
                this.comboTree1.SelectedNode = node;
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
            if (this.input_AppCode.SelectedValue.AsNotNullString().IsNullOrEmpty())
            {
                this.input_AppCode.Focus();
                this.warningBox1.Text = "<b>警告</b> 请指定系统";
                this.warningBox1.AutoCloseTimeout = 2;
                this.warningBox1.Show();
                return false;
            }
            if (this.comboTree1.SelectedNode == null)
            {
                this.comboTree1.Focus();
                this.warningBox1.Text = "<b>警告</b> 请指定菜单分类";
                this.warningBox1.AutoCloseTimeout = 2;
                this.warningBox1.Show();
                return false;
            }
            if (this.input_Text.Text.IsNullOrWhiteSpace())
            {
                this.input_Text.Focus();
                this.warningBox1.Text = "<b>警告</b> 菜单名称不能为空";
                this.warningBox1.AutoCloseTimeout = 2;
                this.warningBox1.Show();
                return false;
            }
            //if (this.input_RNO.Text.IsNullOrWhiteSpace())
            //{
            //    this.input_RNO.Focus();
            //    this.warningBox1.Text = "<b>警告</b> 请输入程序集";
            //    this.warningBox1.AutoCloseTimeout = 2;
            //    this.warningBox1.Show();
            //    return false;
            //}
            //if (this.input_FName.Text.IsNullOrWhiteSpace())
            //{
            //    this.input_FName.Focus();
            //    this.warningBox1.Text = "<b>警告</b> 请输入命名空间";
            //    this.warningBox1.AutoCloseTimeout = 2;
            //    this.warningBox1.Show();
            //    return false;
            //}
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
            this.cmbOpenStyle.ItemHeight = 22;
            this.input_AppCode.ItemHeight = 22;

        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            using (FormModuleBrowser dialog =new FormModuleBrowser())
            {
                dialog.OK += (x, y) => {
                    if (dialog.Module == null) return;
                    this.input_Text.Text = dialog.Module.Text;
                    this.input_RNO.Text = dialog.Module.RNO;
                    this.input_FName.Text = dialog.Module.FName;
                };
                dialog.ShowDialog();
            }
           
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            if (m_Initialize) return;
            this.Modified = true;
        }
        /// <summary>
        /// 保存时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormModuleEdit_OKing(object sender, CIS.Core.CancelEventArgsExt e)
        {
            CIS.Utility.ControlHelper.RefreshValue<CIS.Model.Sys_Menu>(this, _Menu);
            _Menu.MenuPCode = _Menu.MenuPCode == "" ? "0" : _Menu.MenuPCode;
            if(_Menu.Status.AsBoolean()!=this.rbtnEnable.Checked)
                _Menu.Status = this.rbtnEnable.Checked ? 1 : 0;
            if ((this.comboTree1.SelectedNode.Name != _Menu.MenuPCode && this.comboTree1.SelectedNode!=menuRootNode)
                || (this.comboTree1.SelectedNode == menuRootNode && !CIS.Utility.TreeModel.IsRootNode(_Menu.MenuPCode)))
            {
                _Menu.MenuPCode = this.comboTree1.SelectedNode.Name == menuRootNode.Name ? "" : this.comboTree1.SelectedNode.Name;
            }
            CIS.Model.MenuOpenStyle? curOpenStyle = (CIS.Model.MenuOpenStyle?)(this.cmbOpenStyle.SelectedIndex == -1 ? null :(int?) this.cmbOpenStyle.SelectedIndex);
            if (curOpenStyle != _Menu.MenuOpenStyle)
            {
                _Menu.OpenStyle = curOpenStyle.HasValue?Enum.GetName(typeof(CIS.Model.MenuOpenStyle),curOpenStyle.Value):"";
            }

            bool success = false;
            if (m_IsInsertOpration)
                success = CIS.Model.DBHelper.CIS.Insert<CIS.Model.Sys_Menu>(_Menu) > 0;
            else
                success = CIS.Model.DBHelper.CIS.Update<CIS.Model.Sys_Menu>(_Menu,m=>m.MenuCode==_Menu.MenuCode) > 0;
            e.Cancel = !success;
            e.CancelReason = m_IsInsertOpration?"插入失败":"更新失败";
        }

        private void input_System_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Initialize) return;
            string appCode = this.input_AppCode.SelectedValue.AsNotNullString();
            if (!appCode.IsNullOrEmpty())
            {
                this.InitCategory(appCode);
            }
            this.Modified = true;
        }

        private void rbtnEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Initialize) return;
            this.Modified = true;
        }
    }
}
