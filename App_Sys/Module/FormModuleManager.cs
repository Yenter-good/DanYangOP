using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using Dos.ORM;

namespace App_Sys
{
    public partial class FormModuleManager : CIS.Core.BaseForm
    {
        public FormModuleManager()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 模块实体转换为树节点
        /// </summary>
        /// <param name="modules"></param>
        /// <returns></returns>
        private List<CIS.Utility.TreeModel> ToTreeModel(List<CIS.Model.Sys_Module> modules)
        {
            List<CIS.Utility.TreeModel> models = new List<CIS.Utility.TreeModel>();
            foreach (var module in modules)
            {
                string pname = "";
                var parentModule = modules.Find(m => m.Code == module.PCode);
                if (parentModule != null)
                    pname = parentModule.Text;
                var model = this.GetTreeModel(module, pname);
                models.Add(model);
            }
            return models;
        }
        /// <summary>
        /// 通过模块实体和分类名称获取树节点实体
        /// </summary>
        /// <param name="module"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public CIS.Utility.TreeModel GetTreeModel(CIS.Model.Sys_Module module,string category)
        {
            return new CIS.Utility.TreeModel()
            {
                Code = module.Code
                ,
                Text = module.Text
                ,
                ParentCode = module.PCode
                ,
                Cells = new object[] { 
                            module.Text                  // 模块名称
                            ,category                       // 上级名称
                            ,module.RNO                  // 程序集
                            ,module.FName                // 命名空间
                            ,module.No                   // 排序
             }
             ,Obj=module
             ,Sort=module.No.GetValueOrDefault(0)
            };
        }
        /// <summary>
        /// 异步加载模块信息
        /// </summary>
        public void LoadModulesAsync()
        {
            //禁用控件
            this.pnlTool.Enabled = false;
            CIS.Utility.LoadHelper.LoadAsync<GridRow[]>(this.superGridControl1
                , () =>
                {
                    //获取有效的模块信息
                    var modules = CIS.Model.DBHelper.CIS.From<CIS.Model.Sys_Module>()
                        .Where(m => m.Status == 1)
                        .OrderBy(m=>m.No)
                        .ToList();
                    //转换为树节点数据
                    var models = this.ToTreeModel(modules);
                    //返回行集合
                    return CIS.Utility.TreeHelper.CreateGridRows(models, RowFormat);
                }
                , data => {
                    //加载所有行
                    CIS.Utility.TreeHelper.FillGrid(this.superGridControl1.PrimaryGrid, data);
                    this.superGridControl1.PrimaryGrid.ExpandAll();
                    //启用控件
                    this.pnlTool.Enabled=true;
                }
                );
        }
        /// <summary>
        /// 行格式化
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="model"></param>
        private void RowFormat(GridRow gr,CIS.Utility.TreeModel model)
        {
            var m = model.Obj as CIS.Model.Sys_Module;
            gr.Cells[0].CellStyles.Default.ImageIndex = m.IsCategory() ? 0 : 1;
        }

        /// <summary>
        /// 获取当前包含的所有模块的代码
        /// 包含本身
        /// </summary>
        /// <param name="gr"></param>
        /// <returns></returns>
        private List<string> GetAllCodes(GridRow gr)
        {
            if (gr == null) return null;
            var model = (gr.Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Module;
            if (model == null) return null;
            List<string> codes = new List<string>();
            codes.Add(model.Code);
            foreach (GridRow item in gr.Rows)
            {
                var childCodes = this.GetAllCodes(item);
                if (childCodes != null)
                    codes.AddRange(childCodes);
            }
            return codes;
        }
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pName"></param>
        private void AddCategory(string pCode, string pName)
        {
            using (FormModuleCategoryEdit dialog = new FormModuleCategoryEdit(pCode))
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.superGridControl1.PrimaryGrid.ClearSelectedRows();
                    CIS.Utility.TreeHelper.AddGridRow(this.superGridControl1.PrimaryGrid, this.GetTreeModel(dialog.Category, pName), RowFormat, true);
                    return;
                }
            }
        }      
        /// <summary>
        /// 插入模块
        /// </summary>
        /// <param name="pCode"></param>
        private void AddModule(string pCode)
        {
            using (FormModuleEdit dialog = new FormModuleEdit(pCode))
            {
                dialog.OK += (sender, e) => {
                    this.superGridControl1.PrimaryGrid.ClearSelectedRows();
                    CIS.Utility.TreeHelper.AddGridRow(this.superGridControl1.PrimaryGrid, this.GetTreeModel(dialog.Module, dialog.PText), RowFormat, true);

                };
                dialog.ShowDialog();
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="gr"></param>
        private void Edit(GridRow gr)
        {
            if (gr == null) return;
            var model = (gr.Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Module;
            if (model == null) return;
            if (model.IsCategory())
            {
                using (FormModuleCategoryEdit dialog = new FormModuleCategoryEdit(model))
                {
                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.superGridControl1.PrimaryGrid.ClearSelectedRows();
                        var ngr = CIS.Utility.TreeHelper.RefreshGridRow(gr, this.GetTreeModel(dialog.Category, gr.Cells[1].Value.AsNotNullString()), RowFormat);
                    }
                }
            }
            else
            {
                using (FormModuleEdit dialog = new FormModuleEdit(model))
                {
                    dialog.OK += (sender, e) =>
                    {
                        this.superGridControl1.PrimaryGrid.ClearSelectedRows();
                        var ngr = CIS.Utility.TreeHelper.RefreshGridRow(gr, this.GetTreeModel(dialog.Module, dialog.PText), RowFormat);
                    };
                    dialog.ShowDialog();

                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gr"></param>
        private void Delete(GridRow gr)
        {
            if (gr == null) return;
            var module = (gr.Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Module;
            if (module == null) return;

            if (gr.Rows.Count > 0)
            {
                if (CIS.Core.MsgBox.YesNo("删除{0},将会连同子数据一起删除,是否继续?".FormatWith(module.Text)) == System.Windows.Forms.DialogResult.No)
                    return;
            }
            else
            {
                if (CIS.Core.MsgBox.YesNo("是否删除{0}?".FormatWith(module.Text)) == System.Windows.Forms.DialogResult.No)
                    return;
            }
            var codes = this.GetAllCodes(gr);
            if (codes == null) return;
            //删除行
            if (CIS.Model.DBHelper.CIS.Delete<CIS.Model.Sys_Module>(m => m.Code.In(codes)) > 0)
            {
                CIS.Utility.TreeHelper.GridRowDelete(gr);
                CIS.Core.AlertBox.Info("<b>成功</b> 删除成功");
            }
            else
                CIS.Core.AlertBox.Error("<b>错误</b> 删除不成功");

        }

        private void FormModuleImport_Load(object sender, EventArgs e)
        {
            this.LoadModulesAsync();
        }

        private void superGridControl1_SelectionChanged(object sender, GridEventArgs e)
        {
            this.btnAddModule.Enabled  = this.superGridControl1.PrimaryGrid.Rows.Count > 0;
            var selectedRows = this.superGridControl1.GetSelectedRows();
            if (selectedRows == null || selectedRows.Count == 0)
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
            }
            else
            {
                this.btnEdit.Enabled = true;
                this.btnDelete.Enabled = true;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadModulesAsync();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string pCode = "";
            string pName = "";
            var selectedRows = this.superGridControl1.GetSelectedRows();
            if (selectedRows != null && selectedRows.Count > 0)
            {
                var model = (selectedRows[0].Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Module;
                if (model.IsCategory())
                {
                    pCode = model.Code;
                    pName = (selectedRows[0] as GridRow).Cells[1].Value.AsNotNullString();
                }
                else
                {
                    var parentRow = selectedRows[0].Parent as GridRow;
                    if (parentRow != null)
                    {
                        var parentModel = (parentRow.Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Module;
                        if (parentModel.IsCategory())
                        {
                            pCode = parentModel.Code;
                            pName = parentRow.Cells[1].Value.AsNotNullString();
                        }
                    }
                }
            }
            this.AddCategory(pCode, pName);

        }

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            string pCode = "";
            var selectedRows = this.superGridControl1.GetSelectedRows();
            if (selectedRows != null && selectedRows.Count > 0)
            {
               var model =  (selectedRows[0].Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Module;
               if (model.IsCategory())
                   pCode = model.Code;
               else
               {
                   var pRow = selectedRows[0].Parent as GridRow;
                   if (pRow == null) return;
                    var pModel = (pRow.Tag as CIS.Utility.TreeModel).Obj as CIS.Model.Sys_Module;
                    if (pModel.IsCategory())
                        pCode = pModel.Code;
                    else
                        return;
               }
            }
            if (pCode.IsNullOrEmpty()) return;
            this.AddModule(pCode);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedRows = this.superGridControl1.GetSelectedRows();
            if (selectedRows == null || selectedRows.Count == 0) return;
            this.Edit(selectedRows[0] as GridRow);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRows = this.superGridControl1.GetSelectedRows();
            if (selectedRows == null || selectedRows.Count == 0) return;
            this.Delete(selectedRows[0] as GridRow);
        }

        private void superGridControl1_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            this.Edit(e.GridCell.GridRow);
        }




    }
}
