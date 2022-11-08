using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CIS.ControlLib.Helper.PopupStyle
{
    [ToolboxItem(false)]
    public partial class ComboFindPopupView : UserControl, IFindPopupFilterView
    {
       
        /// <summary>
        /// 通过过滤词获取数据源
        /// </summary>
        public Func<string, DataTable> GetDataSource;
        private bool _Adaptive = true;
        public bool Adaptive
        {
            get { return _Adaptive; }
            set { _Adaptive = value; }
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
        /// 获取或设置过滤框显示在上方还是下方
        /// </summary>
        public bool UpOrDown
        {
            get { return this.panel1.Dock == DockStyle.Top; }
            set
            {
                if (value)
                    this.panel1.Dock = DockStyle.Top;
                else
                    this.panel1.Dock = DockStyle.Bottom;
            }
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

        public TextBoxBase FilterTextBox
        {
            get
            {
                return this.txtFilter;
            }
        }

        public object DefaultSelectedValue
        {
            get;
            set;
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
            if (string.IsNullOrEmpty(this.txtFilter.Text.Trim()))
                dv.RowFilter = "";
            else
            {
                StringBuilder filterBuilder = new StringBuilder();
                for (int i = 0; i < FilterFields.Length; i++)
                {
                    if (filterBuilder.Length > 0)
                        filterBuilder.Append("or");
                    filterBuilder.AppendFormat(" {0} like '%{1}%' ", FilterFields[i], filteText);
                }
                dv.RowFilter = filterBuilder.ToString();
            }
        }

        public Size CalcItemsSize()
        {
           int height = this.dgvView.Rows.GetRowsHeight(DataGridViewElementStates.Visible);
           //height += this.dgvView.ColumnHeadersHeight;
           height += this.panel1.Height;
           return new System.Drawing.Size(this.Width, height);
        }

        public ComboFindPopupView()
        {
            InitializeComponent();

            this.dgvView.AutoGenerateColumns = false;
            ControlHelper.SetControlNoFocus(this.dgvView);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            //默认选中默认项目
            if (this.Visible && this.DefaultSelectedValue != null && !string.IsNullOrEmpty(this.ValueMember)
                && this.DataSource !=null && this.DataSource.Columns.Contains(this.ValueMember))
            {
                foreach (DataGridViewRow dgvr in this.dgvView.Rows)
                {
                    var drv = dgvr.DataBoundItem as DataRowView;
                    if (drv[ValueMember] == this.DefaultSelectedValue)
                    {
                        dgvr.Selected = true;
                        if (!dgvr.Displayed)
                            this.dgvView.FirstDisplayedScrollingRowIndex = dgvr.Index;
                        break;
                    }
                }
            }
           
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

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                e.Handled = true;
            Win32.UnsafeNativeMethods.SendMessage(this.dgvView.Handle, (int)Win32.WinMsg.WM_KEYDOWN, (int)e.KeyCode, 0);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            this.Filter(this.txtFilter.Text.Trim());
        }





    }
}
