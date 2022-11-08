using DevComponents.DotNetBar.SuperGrid;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CIS.Utility
{
    public class ExcelHelper
    {
        /// <summary>
        /// 通过excel导入数据
        /// </summary>
        /// <param name="templateCells"></param>
        /// <param name="beforeUpload">上传之前</param>
        /// <param name="uploading">上传中</param>
        /// <param name="fileName">默认加载的文件路径</param>
        public void Import(List<XLSCell> templateCells, Action<CancelEventArgs> beforeUpload, Action<UploadEventArgs> uploading, string fileName = null)
        {
            using (FrmExcelImportDialog dialog = new FrmExcelImportDialog(templateCells, fileName))
            {
                dialog.BeforeUpload += (s, e) =>
                {
                    beforeUpload(e);
                };
                dialog.Uploading += (s, e) =>
                {
                    uploading(e);
                };
                dialog.ShowDialog();

            }
        }


        /// <summary>
        /// 保存Excel模板
        /// </summary>
        /// <param name="templateCells"></param>
        /// <param name="defalutFileName"></param>
        public static bool SaveTemplate(List<XLSCell> templateCells, string defalutFileName = "")
        {
            using (System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog())
            {
                dialog.Filter = "Excel文件|*.xls";
                dialog.DefaultExt = "xls";
                dialog.FileName = defalutFileName;
                dialog.AddExtension = true;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CreateXLSTemplate(templateCells, dialog.FileName);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 创建Excel模板
        /// </summary>
        /// <param name="data">模板表格</param>
        /// <param name="fileName">保存路径</param>
        /// <param name="sheetName">工作簿名称</param>
        public static void CreateXLSTemplate(List<XLSCell> templateCells, string fileName, string sheetName = "")
        {
            if (templateCells == null && templateCells.Count > 0)
                return;
            if (string.IsNullOrEmpty(sheetName))
                sheetName = "Sheet1";

            HSSFWorkbook workbook = new HSSFWorkbook();

            //设置单元格格式
            HSSFCellStyle style1 = (HSSFCellStyle)workbook.CreateCellStyle();
            style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            style1.BorderBottom = NPOI.SS.UserModel.CellBorderType.THIN;
            style1.BorderLeft = NPOI.SS.UserModel.CellBorderType.THIN;
            style1.BorderRight = NPOI.SS.UserModel.CellBorderType.THIN;
            style1.BorderTop = NPOI.SS.UserModel.CellBorderType.THIN;

            //设置必填项字体格式
            HSSFFont hearderRedFont = (HSSFFont)workbook.CreateFont();
            hearderRedFont.Color = HSSFColor.RED.index;
            style1.SetFont(hearderRedFont);

            HSSFFont hearderBlackFont = (HSSFFont)workbook.CreateFont();
            hearderBlackFont.Color = HSSFColor.BLACK.index;
            HSSFCellStyle style2 = (HSSFCellStyle)workbook.CreateCellStyle();
            style2.CloneStyleFrom(style1);
            style2.SetFont(hearderBlackFont);

            //创建工作簿
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(sheetName);
            //创建描述行
            HSSFRow reamrkRow = (HSSFRow)sheet.CreateRow(0);
            reamrkRow.CreateCell(0).SetCellValue("备注：红色字体标注的列为必填项,不可缺少");
            //合并单位格 方便显示备注信息
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, templateCells.Count - 1));
            //创建模板表头
            HSSFRow row = (HSSFRow)sheet.CreateRow(1);
            //填充表头内容
            for (int i = 0; i < templateCells.Count; i++)
            {
                row.CreateCell(i);

                row.Cells[i].SetCellType(NPOI.SS.UserModel.CellType.STRING);
                row.Cells[i].SetCellValue(templateCells[i].HeaderText);
                row.Cells[i].CellStyle = style1;

                if (!templateCells[i].AllowNull)
                    row.Cells[i].CellStyle = style1;
                else
                    row.Cells[i].CellStyle = style2;

            }
            //保存Excel
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                workbook.Write(fileStream);
            }
        }
        /// <summary>
        /// 加载Excel模板 
        /// </summary>
        /// <param name="fileName">Excel文件路径</param>
        /// <param name="sheetName">加载的工作簿名称</param>
        /// <param name="data">填充的数据模板样式</param>
        /// <returns>数据表</returns>
        public static KeyValuePair<System.Data.DataTable, Dictionary<int, string>> LoadExcelTemplateFile(string fileName, string sheetName, List<XLSCell> templateCells)
        {
            DataTable dt = CreateTable(templateCells);
            Dictionary<int, string> errorDict = new Dictionary<int, string>();

            using (FileStream fileStream = File.OpenRead(fileName))
            {
                HSSFWorkbook workBook = new HSSFWorkbook(fileStream);
                HSSFSheet sheet = (HSSFSheet)workBook.GetSheet(sheetName);
                if (sheet != null && sheet.LastRowNum > 1)
                {
                    HSSFRow headerRow = (HSSFRow)sheet.GetRow(1);
                    if (headerRow == null)
                    {
                        errorDict.Add(9999991, "与系统指定的Excel模板不相符,请使用系统程序生成Excel模板填充数据!!!");
                        return new KeyValuePair<DataTable, Dictionary<int, string>>(dt, errorDict);
                    }

                    Dictionary<string, int> colDict = new Dictionary<string, int>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (headerRow.Cells.Exists(h => h.StringCellValue.Trim().Equals(col.Caption)))
                        {
                            HSSFCell hearderCell = (HSSFCell)headerRow.Cells.Find(h => h.StringCellValue.Trim().Equals(col.Caption));
                            colDict.Add(col.ColumnName, hearderCell.ColumnIndex);
                        }
                    }

                    if (colDict.Count != dt.Columns.Count)
                    {
                        errorDict.Add(9999991, "与系统指定的Excel模板不相符,请使用系统程序生成Excel模板填充数据!!!");
                        return new KeyValuePair<DataTable, Dictionary<int, string>>(dt, errorDict);
                    }

                    for (int rowIndex = 2; rowIndex <= sheet.LastRowNum; rowIndex++)
                    {
                        HSSFRow bodyRow = (HSSFRow)sheet.GetRow(rowIndex);
                        if (bodyRow == null)
                            continue;
                        bool isError = false;
                        DataRow dataRow = dt.NewRow();
                        foreach (var colKey in colDict)
                        {
                            HSSFCell cell = (HSSFCell)bodyRow.GetCell(colKey.Value);
                            if (cell == null)
                            {
                                if (dt.Columns[colKey.Key].AllowDBNull)
                                {
                                    dataRow[colKey.Key] = DBNull.Value;
                                    continue;
                                }
                                else
                                {
                                    if (templateCells.Find(t => t.Name == colKey.Key).AllowDefault)
                                    {
                                        dataRow[colKey.Key] = templateCells.Find(t => t.Name == colKey.Key).DefaultValue;
                                        continue;
                                    }
                                    else
                                    {
                                        isError = true;
                                        errorDict.Add(bodyRow.RowNum, "【" + dt.Columns[colKey.Key].Caption + "】 数据不能为空");
                                        break;
                                    }
                                }
                            }
                            object value = null;
                            try
                            {
                                if (dt.Columns[colKey.Key].DataType == typeof(bool))
                                    value = Convert.ToBoolean(Convert.ToInt32(cell.ToString()));
                                else
                                    value = Convert.ChangeType(cell.ToString(), dt.Columns[colKey.Key].DataType);
                            }
                            catch
                            {
                                if (dt.Columns[colKey.Key].AllowDBNull)
                                    value = DBNull.Value;
                                else
                                {
                                    errorDict.Add(bodyRow.RowNum, "【" + dt.Columns[colKey.Key].Caption + "】 数据类型与系统指定" + dt.Columns[colKey.Key].DataType.ToString() + "不符合,不能相互转换");
                                    isError = true;
                                    break;
                                }
                            }
                            dataRow[colKey.Key] = value;
                        }
                        if (!isError)
                            dt.Rows.Add(dataRow);
                    }
                }
            }
            return new KeyValuePair<DataTable, Dictionary<int, string>>(dt, errorDict);
        }
        /// <summary>
        /// 在原excel模板文件添加错误日志信息
        /// </summary>
        /// <param name="fileName">Excel模板文件路径</param>
        /// <param name="errorDict">错误日志信息</param>
        public static void WriteErrorInfo(string fileName, Dictionary<int, string> errorDict)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            HSSFWorkbook workBook = new HSSFWorkbook(fileStream);
            fileStream.Close();

            HSSFSheet errorSheet = (HSSFSheet)workBook.GetSheet("错误日志");
            if (errorSheet != null)
            {
                workBook.RemoveSheetAt(workBook.GetSheetIndex(errorSheet));
                errorSheet = null;
            }

            errorSheet = (HSSFSheet)workBook.CreateSheet("错误日志");
            //添加表头
            HSSFRow errorHeader = (HSSFRow)errorSheet.CreateRow(0);
            errorHeader.CreateCell(0).SetCellValue("错误行号");
            errorHeader.CreateCell(1).SetCellValue("原因");
            int rowIndex = 1;
            foreach (var errorKey in errorDict)
            {
                HSSFRow errorRow = (HSSFRow)errorSheet.CreateRow(rowIndex);
                errorRow.CreateCell(0).SetCellValue(errorKey.Key);
                errorRow.CreateCell(1).SetCellValue(errorKey.Value);
                rowIndex++;
            }

            using (FileStream writeStream = new FileStream(fileName, FileMode.Create))
            {
                workBook.Write(writeStream);
            }

        }

        /// <summary>
        /// 设置DataTable可以允许为NULL
        /// </summary>
        /// <param name="data">数据表</param>
        private static void SetDataTableCanNull(DataTable data)
        {
            foreach (DataColumn col in data.Columns)
            {
                col.AllowDBNull = true;
            }
        }

        /// <summary>
        /// 通过模板单元信息创建数据表格
        /// </summary>
        /// <param name="tcells"></param>
        /// <returns></returns>
        private static System.Data.DataTable CreateTable(List<XLSCell> tcells)
        {
            DataTable data = new DataTable();
            foreach (var templateCell in tcells)
            {
                data.Columns.Add(new DataColumn { ColumnName = templateCell.Name, AllowDBNull = templateCell.AllowNull, Caption = templateCell.HeaderText, DataType = templateCell.DataType });
            }
            return data;
        }

        /// <summary>
        /// 导出Excel格式文件
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldList">数据表字段名-说明对应列表</param>
        /// <param name="fileName">文件名</param>
        public static void ExportXLS(System.Data.DataTable dataTable, System.Collections.Generic.Dictionary<string, string> fieldList, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet();
            // 行索引号
            int rowIndex = 0;
            IRow headerRow = sheet.CreateRow(rowIndex);
            int columnIndex = 0;
            // 创建表头
            foreach (var item in fieldList)
            {
                headerRow.CreateCell(columnIndex).SetCellValue(item.Value);
                columnIndex++;
            }

            rowIndex++;

            // 创建数据行
            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                IRow row = sheet.CreateRow(rowIndex);

                columnIndex = 0;
                foreach (var item in fieldList)
                {
                    if (!dataTable.Columns.Contains(item.Key))
                    {
                        row.CreateCell(columnIndex).SetCellValue("");
                    }
                    else
                    {
                        var column = dataTable.Columns[item.Key];

                        switch (column.DataType.ToString())
                        {
                            case "System.String":
                            default:
                                row.CreateCell(columnIndex).SetCellValue(dataTableRow[column].AsNotNullString());
                                break;

                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Decimal":
                            case "System.Double":
                                row.CreateCell(columnIndex).SetCellValue(dataTableRow[column].AsDouble(0));
                                break;
                        }
                    }
                    columnIndex++;
                }
                rowIndex++;
            }

            workbook.Write(ms);
            byte[] data = ms.ToArray();

            ms.Flush();
            ms.Close();

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }

        public static void ExportXLS(System.Data.DataTable dataTable, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet();
            // 行索引号
            int rowIndex = 0;
            IRow headerRow = sheet.CreateRow(rowIndex);
            int columnIndex = 0;
            // 创建表头
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                headerRow.CreateCell(columnIndex).SetCellValue(dataTable.Columns[i].ColumnName);
                columnIndex++;
            }

            rowIndex++;

            // 创建数据行
            foreach (DataRow dgvr in dataTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                columnIndex = 0;
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    switch (dataTable.Columns[i].DataType.ToString())
                    {
                        case "System.String":
                        default:
                            dataRow.CreateCell(columnIndex).SetCellValue(dgvr[i].AsNotNullString());
                            break;

                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Decimal":
                        case "System.Double":
                            dataRow.CreateCell(columnIndex).SetCellValue(dgvr[i].AsDouble(0));
                            break;
                    }
                    columnIndex++;
                }
                rowIndex++;
            }

            workbook.Write(ms);
            byte[] data = ms.ToArray();

            ms.Flush();
            ms.Close();

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }

        /// <summary>
        /// 导出Excel格式文件
        /// </summary>
        /// <param name="dataGridView">表格控件</param>
        /// <param name="fileName">文件名</param>
        public static void ExportXLS(DataGridView dataGridView, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);

            int columnIndex = 0;
            // 创建表头
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (dataGridView.Columns[i].Visible)
                {
                    headerRow.CreateCell(columnIndex).SetCellValue(dataGridView.Columns[i].HeaderText);
                    columnIndex++;
                }
            }

            // 行索引号
            int rowIndex = 1;

            // 写出数据
            foreach (DataGridViewRow dgvr in dataGridView.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                columnIndex = 0;
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    if (dataGridView.Columns[i].Visible)
                    {
                        switch (dataGridView.Columns[i].CellType.ToString())
                        {
                            case "System.String":
                            default:
                                dataRow.CreateCell(columnIndex).SetCellValue(dgvr.Cells[i].FormattedValue.AsNotNullString());
                                break;

                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Decimal":
                            case "System.Double":
                                dataRow.CreateCell(columnIndex).SetCellValue(dgvr.Cells[i].Value.AsDouble(0));
                                break;
                        }
                    }
                    columnIndex++;
                }
                rowIndex++;
            }

            workbook.Write(ms);
            byte[] data = ms.ToArray();

            ms.Flush();
            ms.Close();

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }
        /// <summary>
        /// 导出Excel格式文件
        /// </summary>
        /// <param name="dataGridView">表格控件</param>
        /// <param name="fileName">文件名</param>
        public static void ExportXLS(DevComponents.DotNetBar.SuperGrid.SuperGridControl dataGridView, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);

            int columnIndex = 0;
            // 创建表头
            for (int i = 0; i < dataGridView.PrimaryGrid.Columns.Count; i++)
            {
                if (dataGridView.PrimaryGrid.Columns[i].Visible)
                {
                    headerRow.CreateCell(columnIndex).SetCellValue(dataGridView.PrimaryGrid.Columns[i].HeaderText);
                    columnIndex++;
                }
            }

            // 行索引号
            int rowIndex = 1;

            // 写出数据
            foreach (GridRow dgvr in dataGridView.PrimaryGrid.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                columnIndex = 0;
                for (int i = 0; i < dataGridView.PrimaryGrid.Columns.Count; i++)
                {
                    if (dataGridView.PrimaryGrid.Columns[i].Visible)
                    {
                        //    switch (dataGridView.PrimaryGrid.Columns[i].DataType.ToString())
                        //    {
                        //case "System.String":
                        //default:
                        dataRow.CreateCell(columnIndex).SetCellValue(dgvr.Cells[i].FormattedValue.AsNotNullString());
                        //break;

                        //case "System.Int16":
                        //case "System.Int32":
                        //case "System.Int64":
                        //case "System.Decimal":
                        //case "System.Double":
                        //    dataRow.CreateCell(columnIndex).SetCellValue(dgvr.Cells[i].Value.AsDouble(0));
                        //    break;
                        //}
                        columnIndex++;
                    }
                }
                rowIndex++;
            }

            workbook.Write(ms);
            byte[] data = ms.ToArray();

            ms.Flush();
            ms.Close();

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }
    }

    /// <summary>
    /// Excel模板单元类
    /// </summary>
    public class XLSCell
    {
        private bool _AllowNull = true;
        private Type _DataType = typeof(string);
        private bool _AllowDefault = false;
        /// <summary>
        /// 标题
        /// </summary>
        public string HeaderText { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否允许空值
        /// </summary>
        public bool AllowNull
        {
            get { return _AllowNull; }
            set { _AllowNull = value; }
        }
        /// <summary>
        /// 数据类型
        /// </summary>
        public Type DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }
        /// <summary>
        /// 默认值
        /// </summary>
        public object DefaultValue { get; set; }
        /// <summary>
        /// 是否允许系统默认
        /// </summary>
        public bool AllowDefault
        {
            get { return _AllowDefault; }
            set { _AllowDefault = value; }
        }

    }

    /// <summary>
    /// 导入事件参数
    /// </summary>
    public class UploadEventArgs : EventArgs
    {
        private BackgroundWorker m_bgk = null;
        /// <summary>
        /// 上传的数据
        /// </summary>
        public DataTable Data { get; private set; }
        /// <summary>
        /// 报告进度
        /// </summary>
        public void ReportProgress(int percentProgress, object userState = null)
        {
            if (m_bgk == null || !m_bgk.WorkerReportsProgress) return;
            if (userState == null)
                m_bgk.ReportProgress(percentProgress);
            else
                m_bgk.ReportProgress(percentProgress, userState);
        }

        public UploadEventArgs(BackgroundWorker bgk, DataTable data)
        {
            m_bgk = bgk;
            this.Data = data;
        }
    }
}
