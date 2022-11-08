using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CIS.ControlLib.Helper.PopupStyle
{
    [ToolboxItem(false)]

    public partial class GridPopupView : UserControl,IPopupFilterView
    {
        /// <summary>
        /// 通过过滤词获取数据源
        /// </summary>
        public Func<string, DataTable> GetDataSource;
        private DataTable _DataSource = null;
        private bool _AutoSizeToDisplay = true;
        public bool Adaptive
        {
            get { return _AutoSizeToDisplay; }
            set { _AutoSizeToDisplay = value; }
        }
        public bool ColumnHeaderVisible 
        {
            get { return this.dgvView.ColumnHeadersVisible;}
            set{this.dgvView.ColumnHeadersVisible=value;}
        }
        /// <summary>
        /// 获取或设置双击选择还是单击
        /// </summary>
        public bool DoubleClickedToSelect
        {
            get;
            set;
        }
       
        public DataTable DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }
        /// <summary>
        /// 设置显示的列
        /// 字段名称1|显示名称|大小(*自动);字段名称2|显示名称|大小(*自动)
        /// </summary>
        public string Columns
        { 
            get  ;
            set  ;
        }

        public string TextFiled
        {
            get;
            set;
        }
        public string KeyFiled
        {
            get;
            set;
        }
        public string[] FilterFields
        {
            get;
            set;
        }
        public string AppendSpellField
        {
            get;
            set;
        }
        public Control View
        {
            get { return this.dgvView; }
        }

        public string SelectedText
        {
            get
            {
                var drv = this.SelectedItem as DataRowView;
                if (drv == null) return null;
                if (string.IsNullOrEmpty(TextFiled) || !drv.Row.Table.Columns.Contains(TextFiled))
                    return null;
                return drv[TextFiled].AsString();
            }
        }

        public object SelectedValue
        {
            get
            {
                var drv = this.SelectedItem as DataRowView;
                if (drv == null) return null;
                if (string.IsNullOrEmpty(KeyFiled) || !drv.Row.Table.Columns.Contains(KeyFiled))
                    return null;
                return drv[KeyFiled];
            }
        }

        public object SelectedItem
        {
            get
            {
                if (this.dgvView.SelectedRows.Count > 0)
                    return this.dgvView.SelectedRows[0].DataBoundItem as DataRowView;
                return null;
            }
        }

        public event EventHandler ItemSelected;

        public void Filter(string filteText)
        {
            if (this.GetDataSource != null)
            {
                this.dgvView.DataSource = this.GetDataSource(filteText);
                return;
            }
            if (this.DataSource != null && this.dgvView.DataSource == null)
                this.dgvView.DataSource = this.DataSource;
            if (this.dgvView.DataSource == null) return;
            if (FilterFields == null || FilterFields.Length == 0) return;
            var dv = (this.dgvView.DataSource as DataTable).DefaultView;
            if (string.IsNullOrEmpty(filteText))
                dv.RowFilter = "";
            else
            {
                StringBuilder filterBuilder = new StringBuilder();
                for (int i = 0; i < FilterFields.Length; i++)
                {
                    if (!dv.Table.Columns.Contains(FilterFields[i])) continue;
                    if (filterBuilder.Length > 0)
                        filterBuilder.Append("or");
                    filterBuilder.AppendFormat(" {0} like '%{1}%' ",FilterFields[i],filteText);
                }
                dv.RowFilter = filterBuilder.ToString();
            }

        }
        private void OnSelect()
        {
            if (ItemSelected != null)
            {
                ItemSelected(this, EventArgs.Empty);
            }
        }

        public Size CalcItemsSize()
        {
            int height = this.dgvView.ColumnHeadersHeight;
            height += height;
            height += this.dgvView.Rows.GetRowsHeight(DataGridViewElementStates.Visible);
            int width = this.dgvView.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            width -= this.dgvView.GetColumnDisplayRectangle(this.dgvView.Columns.Count - 1, false).Width;
            width += SystemInformation.VerticalScrollBarWidth;
            return new Size(width, height);
        }
        private void AdjustColumns()
        {
            this.dgvView.Columns.Clear();
            if (string.IsNullOrWhiteSpace(this.Columns))
                return;
            string[] colSettings = this.Columns.Split(';');
            foreach (var setting in colSettings)
            {
                string[] colInfo = setting.Split('|');
                int size = colInfo[2].AsInt(0); //大小

                var dgvCol = new DataGridViewTextBoxColumn();
                dgvCol.DataPropertyName = colInfo[0]; //字段
                dgvCol.HeaderText = colInfo[1]; //显示名称
                if (size == 0)
                    dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                else
                    dgvCol.Width = size;
                this.dgvView.Columns.Add(dgvCol);
            }
            var fullColumn = new DataGridViewTextBoxColumn();
            fullColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvView.Columns.Add(fullColumn);
        }
        public GridPopupView()
        {
            InitializeComponent();
            this.dgvView.AutoGenerateColumns = false;
        }

        private void dgvView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.DoubleClickedToSelect)
            {
                if (e.RowIndex < 0) return;
                this.OnSelect();

            }
        }

        private void dgvView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.DoubleClickedToSelect)
            {
                if (e.RowIndex < 0) return;
                this.OnSelect();

            }
        }

        private void dgvView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.OnSelect();
            }
        }

        private void GridPopupView_Load(object sender, EventArgs e)
        {
            this.AdjustColumns();
            this.dgvView.DataSource = this.DataSource;
        }


    }
}
