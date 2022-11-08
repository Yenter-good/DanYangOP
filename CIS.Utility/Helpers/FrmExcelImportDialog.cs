using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
namespace CIS.Utility
{
    partial class FrmExcelImportDialog : Form
    {
        private static readonly object EVENT_UPLOAD_CLIKED = new object();
        private static readonly object EVENT_UPLOADING = new object();
        private string m_sheetname ="Sheet1";
        private List<XLSCell> m_cellinfo = null;
        /// <summary>
        /// 获取文件名称
        /// </summary>
        public string FileName { get { return this.txtFile.Text.Trim(); } }
        /// <summary>
        /// 上传数据事件之前后
        /// </summary>
        public event EventHandler<CancelEventArgs> BeforeUpload
        {
            add { base.Events.AddHandler(EVENT_UPLOAD_CLIKED, value); }
            remove { base.Events.RemoveHandler(EVENT_UPLOAD_CLIKED, value); }
        }
        /// <summary>
        /// 上传中
        /// </summary>
        public event EventHandler<UploadEventArgs> Uploading
        {
            add { base.Events.AddHandler(EVENT_UPLOADING, value); }
            remove { base.Events.RemoveHandler(EVENT_UPLOADING, value); }
        }
        /// <summary>
        /// 初始化导入界面
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="filename"></param>
        public FrmExcelImportDialog(List<XLSCell> cells,string filename=null)
        {
            InitializeComponent();

            this.dgvData.AutoGenerateColumns = false;

            if (cells == null)
                cells.ThrowIfArgumentIsNull("ETCell");
            m_cellinfo = cells;
            if (!filename.IsNullOrEmpty())
                m_sheetname = filename;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            //使用保存框下载excel模板文件
            ExcelHelper.SaveTemplate(this.m_cellinfo, m_sheetname);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (this.bgwUpload.IsBusy) return;
            using (OpenFileDialog dialog =new  OpenFileDialog())
            {
                dialog.Filter = "Excel文件|*.xls";
                dialog.DefaultExt = "xls";
                dialog.AddExtension = true;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtFile.Text = dialog.FileName;
                    this.pnlProgress.Visible = false;
                    //加载excel数据
                    LoadHelper.LoadAsync<KeyValuePair<System.Data.DataTable, Dictionary<int, string>>>(grpData, () =>
                    {
                        try
                        {
                            return ExcelHelper.LoadExcelTemplateFile(dialog.FileName, m_sheetname, m_cellinfo);
                        }
                        catch
                        {
                            MessageBox.Show("Excel模板文件已被占用,不能导入", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return new KeyValuePair<DataTable, Dictionary<int, string>>();
                        }
                    }, data =>
                    {
                        if (data.Key == null) return;
                        //验证是否与模板格式不一致
                        if (data.Value != null && data.Value.ContainsKey(9999991))
                        {
                            MessageBox.Show(data.Value[9999991], "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //绑定数据源
                        this.dgvData.DataSource = null;
                        this.dgvData.DataSource = data.Key;

                        this.grpData.Text = "导入数据预览({0}条)".FormatWith(this.dgvData.RowCount.ToString());
       
                    });
                }
            }
        }

        private void FrmExcelImportDialog_Load(object sender, EventArgs e)
        {
            //未指定模板信息则关闭窗体
            if (this.m_cellinfo == null || this.m_cellinfo.Count == 0)
            {
                MessageBox.Show("未指定excel模板信息!","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                if (this.Modal)
                    this.DialogResult = DialogResult.Cancel;
                else
                    this.Close();
            }

            //初始化预览界面
            this.dgvData.DataSource = null;
            this.dgvData.Columns.Clear();
            foreach (var item in this.m_cellinfo)
            {
                int colIndex = this.dgvData.Columns.Add(item.Name, item.HeaderText);
                this.dgvData.Columns[colIndex].DataPropertyName = item.Name;
            }
            this.dgvData.AutoResizeColumns();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.bgwUpload.IsBusy) return;

            if (this.Modal)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            else
                this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (this.bgwUpload.IsBusy) return;

            this.dgvData.EndEdit();
            //验证是否包含数据
            DataTable data = this.dgvData.DataSource as DataTable;
            if (data == null || data.Rows.Count == 0) return;
            data.AcceptChanges();

            //触发上传单击事件
            if (base.Events[EVENT_UPLOAD_CLIKED] != null)
            {
                CancelEventArgs cancelEvntArgs = new CancelEventArgs();
                base.Events[EVENT_UPLOAD_CLIKED].DynamicInvoke(this, cancelEvntArgs);
                if (cancelEvntArgs.Cancel)
                    return;
            }

            this.progressBar1.Value = 0;
            this.lbProgressStatus.Text = "上传中,请稍等...";
            this.pnlProgress.Visible = true;
            this.btnBrowse.Enabled = false;
            this.btnClose.Enabled = false;
            this.btnImport.Enabled = false;
            this.dgvData.ReadOnly = true;
            Application.DoEvents();
            System.Threading.Thread.Sleep(300);

            this.bgwUpload.RunWorkerAsync(data);
   
        }

        private void dgvData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.btnImport.Enabled = this.dgvData.RowCount > 0;
        }

        private void bgwUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            if (base.Events[EVENT_UPLOADING] != null)
            {
                base.Events[EVENT_UPLOADING].DynamicInvoke(this, new UploadEventArgs(sender as BackgroundWorker, e.Argument as DataTable));
            }
        }

        private void bgwUpload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwUpload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnBrowse.Enabled = true;
            this.btnClose.Enabled = true;
            this.dgvData.ReadOnly = false;
            this.progressBar1.Value = this.progressBar1.Maximum;
            this.lbProgressStatus.Text = "数据上传完毕.";
            Application.DoEvents();
        }

        private void FrmExcelImportDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (this.bgwUpload.IsBusy)
                {
                    MessageBox.Show("数据还在上传中,请稍后。");
                    e.Cancel = true;
                }
            }
        }




    }
}
