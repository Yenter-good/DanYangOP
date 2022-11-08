using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CIS.ControlLib.Helper.PopupStyle
{
    [ToolboxItem(false)]
    public partial class ComboPopupView : UserControl,IPopupFilterView
    {
        /// <summary>
        /// 通过过滤词获取数据源
        /// </summary>
        public Func<string, DataTable> GetDataSource;
        private bool _AutoSizeToDisplay = true;
        public bool Adaptive
        {
            get { return _AutoSizeToDisplay; }
            set { _AutoSizeToDisplay = value; }
        }
        public bool DoubleClickedToSelect
        {
            get;
            set;
        }
        public DataTable DataSource
        {
            get { return this.dgvView.DataSource as DataTable; }
            set { this.dgvView.DataSource = value; }
        }

        /// <summary>
        /// 显示的成员字段
        /// </summary>
        public string DisplayMember
        { 
            get { return colDisplayText.DataPropertyName; }
            set { colDisplayText.DataPropertyName = value; }
        }
        /// <summary>
        /// 值的成员字段
        /// </summary>
        public string ValueMember
        {
            get;
            set;
        }
        /// <summary>
        /// 过滤字段
        /// </summary>
        public string[] FilterFields
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
                if (string.IsNullOrEmpty(DisplayMember) || !drv.Row.Table.Columns.Contains(DisplayMember))
                    return null;
                return drv[DisplayMember].AsString();
            }
        }

        public object SelectedValue
        {
            get
            {
                var drv = this.SelectedItem as DataRowView;
                if (drv == null) return null;
                if (string.IsNullOrEmpty(ValueMember) || !drv.Row.Table.Columns.Contains(ValueMember))
                    return null;
                return drv[ValueMember];
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
                    if (filterBuilder.Length > 0)
                        filterBuilder.Append("or");
                    filterBuilder.AppendFormat(" {0} like '%{1}%' ",FilterFields[i],filteText);
                }
                dv.RowFilter = filterBuilder.ToString();
            }

        }
        public Size CalcItemsSize()
        {
           int height = this.dgvView.Rows.GetRowsHeight(DataGridViewElementStates.Visible);
           height += this.dgvView.ColumnHeadersHeight;
           return new System.Drawing.Size(this.Width, height);
        }
        public ComboPopupView()
        {
            InitializeComponent();
            this.dgvView.AutoGenerateColumns = false;
        }

        private void dgvView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.DoubleClickedToSelect)
            {
                if (e.RowIndex < 0) return;
                if (ItemSelected != null)
                {
                    ItemSelected(this, EventArgs.Empty);
                }
            }
        }

        private void dgvView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.DoubleClickedToSelect)
            {
                if (e.RowIndex < 0) return;
                if (ItemSelected != null)
                {
                    ItemSelected(this, EventArgs.Empty);
                }
            }
        }

        private void dgvView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ItemSelected != null)
                {
                    ItemSelected(this, EventArgs.Empty);
                }
            }
        }



    }
}
