using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

namespace CIS.ControlLib.Controls
{
    /// <summary>
    /// 适用于少量数据
    /// </summary>
    public partial class FilterList : UserControl
    {

        public FilterList()
        {
            InitializeComponent();
        }

        public delegate void delegateItemClick(object sender, ListBoxItemClickEvent e);
        public event delegateItemClick ItemClick;
        public event delegateItemClick ItemDoubleClick;


        [Category("自定义属性")]
        [Description("指定列表内数据源用于显示的字段"), DefaultValue("")]
        public string DisplayMember
        {
            get { return this.listBoxAdv1.DisplayMember; }
            set { this.listBoxAdv1.DisplayMember = value; }
        }

        [Category("自定义属性")]
        [Description("指定列表内数据源实际的值"), DefaultValue("")]
        public string ValueMember
        {
            get { return this.listBoxAdv1.ValueMember; }
            set { this.listBoxAdv1.ValueMember = value; }
        }

        [Category("自定义属性")]
        [Description("指定过滤框将以哪个字段进行过滤"), DefaultValue("")]
        public string SearchMember
        { get; set; }

        public object DataSource 
        { get; set; }

        public void Bind<TItem>(List<TItem> list) where TItem : class
        {
 
        }

        private void FilterList_Load(object sender, EventArgs e)
        {
            this.listBoxAdv1.DataSource = DataSource;
            if (!this.IsDisposed && this.IsHandleCreated && this.Visible)
                this.textBoxX1.Focus();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxX1.Text == "" || DataSource == null)
            {
                this.listBoxAdv1.DataSource = DataSource;
                return;
            }
            List<object> list = new List<object>();
            string TextValue = this.textBoxX1.Text.Trim().ToUpper();

            foreach (var item in DataSource as IEnumerable)
            {
                PropertyInfo info = item.GetType().GetProperty(SearchMember ?? DisplayMember ?? "");
                if (info == null) continue;
                if (info.GetValue(item, null).ToString().Contains(TextValue))
                    list.Add(item);
            }

            if (list.Count == 0)
            {
                this.listBoxAdv1.DataSource = null;
                return;
            }
            this.listBoxAdv1.DataSource = list;
        }

        private void listBoxAdv1_ItemClick(object sender, EventArgs e)
        {
            if (this.ItemClick == null) return;
            if (ValueMember != "")
                this.ItemClick(this, new ListBoxItemClickEvent(this.listBoxAdv1.SelectedItem, this.listBoxAdv1.SelectedValue.ToString()));
            else
                this.ItemClick(this, new ListBoxItemClickEvent(this.listBoxAdv1.SelectedItem, ""));
        }
        private void listBoxAdv1_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.ItemDoubleClick == null) return;
            if (ValueMember != "")
                this.ItemDoubleClick(this, new ListBoxItemClickEvent(this.listBoxAdv1.SelectedItem, this.listBoxAdv1.SelectedValue.ToString()));
            else
                this.ItemDoubleClick(this, new ListBoxItemClickEvent(this.listBoxAdv1.SelectedItem, ""));
        }

        public class ListBoxItemClickEvent : EventArgs
        {
            public ListBoxItemClickEvent(object item, string item1)
            {
                Item = item;
                ItemValue = item1;
            }

            public object Item
            { get; set; }

            public string ItemValue
            { get; set; }
        }

        private void FilterList_VisibleChanged(object sender, EventArgs e)
        {

        }






    }
}
