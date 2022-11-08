using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Data;
using System.Linq;

namespace App_Sys
{
    public partial class FormModuleBrowser : CIS.Core.DialogBase
    {
        /// <summary>
        /// 获取或设置仅能选择模块
        /// </summary>
        public bool OnlyModule { get; set; }
        /// <summary>
        /// 获取当前选择的模块实体
        /// </summary>
        public CIS.Model.Sys_Module Module
        {
            get
            {
                var selectedRows = this.superGridControl1.PrimaryGrid.GetSelectedRows();
                if(selectedRows!=null && selectedRows.Count>0)
                {
                    var module = (selectedRows[0].Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Module;
                    if (this.OnlyModule && module.IsCategory())
                        return null;
                    return module;
                }
                return null;
            }
        }

        public FormModuleBrowser()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 异步加载模块信息
        /// </summary>
        public void LoadModulesAsync()
        {
            CIS.Utility.LoadHelper.LoadAsync<GridRow[]>(this.superGridControl1
                , () =>
                {
                    //获取有效的模块信息
                    var treeModels = CIS.Model.DBHelper.CIS.From<CIS.Model.Sys_Module>()
                        .Where(m => m.Status == 1)
                        .OrderBy(m => m.No)
                        .ToList()
                        .Select(m => new CIS.Utility.TreeModel
                        {
                            Code = m.Code,
                            ParentCode = m.PCode,
                            Text = m.Text,
                            Obj = m,
                            Sort = m.No.GetValueOrDefault(0)
                            ,
                            Cells = new object[]{
                              m.Text                  // 模块名称
                            ,""                       // 上级名称
                            ,m.RNO                  // 程序集
                            ,m.FName                // 命名空间
                            ,m.No                   // 排序
                            }
                        }).ToList();
                    treeModels.AsParallel().ForAll(m =>
                    {
                        var pModel = treeModels.Find(tm => tm.Code == m.ParentCode);
                        if (pModel != null)
                            m.Cells[1] = pModel.Text;
                    });
                    //返回行集合
                    return CIS.Utility.TreeHelper.CreateGridRows(treeModels, RowFormat);
                }
                , data =>
                {
                    //加载所有行
                    CIS.Utility.TreeHelper.FillGrid(this.superGridControl1.PrimaryGrid, data);
                    this.superGridControl1.PrimaryGrid.ExpandAll();
                }
                );
        }
        /// <summary>
        /// 行格式化
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="model"></param>
        private void RowFormat(GridRow gr, CIS.Utility.TreeModel model)
        {
            var m = model.Obj as CIS.Model.Sys_Module;
            gr.Cells[0].CellStyles.Default.ImageIndex = m.IsCategory() ? 0 : 1;
        }
        protected override bool Validate()
        {
            var selectedRows = this.superGridControl1.PrimaryGrid.GetSelectedRows();
            if (selectedRows == null && selectedRows.Count == 0)
            {
                this.warningBox1.Text = "<b>警告</b> 请选择相应的模块";
                this.warningBox1.Show();
                return false;
            }
            else
            {
                if (this.OnlyModule)
                {
                    var module = (selectedRows[0].Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Module;
                    if (module.IsCategory())
                    {
                        this.warningBox1.Text = "<b>警告</b> 请选择相应的模块,而非分类";
                        this.warningBox1.Show();
                        return false;
                    }
                }
            }
            return true;
        }
        private void FormModuleBrowser_Load(object sender, EventArgs e)
        {
            this.LoadModulesAsync();
        }

        private void superGridControl1_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
        }

        private void superGridControl1_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            if (e.RowArea == RowArea.InCellExpand) return;
            this.btnOK.PerformClick();
        }

        private void superGridControl1_SelectionChanging(object sender, GridSelectionChangingEventArgs e)
        {

        }

        private void superGridControl1_SelectionChanged(object sender, GridEventArgs e)
        {
            this.Modified = false;
            var selectedRows = this.superGridControl1.PrimaryGrid.GetSelectedRows();
            if (selectedRows.Count > 0)
            {
                if (this.OnlyModule)
                {
                    var module = (selectedRows[0].Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Module;
                    if (module.IsCategory())
                        this.Modified = false;
                    else
                        this.Modified = true;
                }
                else
                    this.Modified = true;
            }
        }
    }
}
