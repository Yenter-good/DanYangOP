using CIS.ControlLib.Helper.PopupStyle;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIS.ControlLib.Controls
{
    public class FindComboBox:DevComponents.DotNetBar.Controls.TextBoxX
    {
        private ComboFindPopupView popupView = new ComboFindPopupView();
        private PopupControlHost popupHost;

        /// <summary>
        /// 项目选择后事件
        /// </summary>
        public event EventHandler ItemSelected;

        public bool FocusOpen { get; set; }
        /// <summary>
        /// 显示的成员字段
        /// </summary>
        public string DisplayMember
        {
            get { return popupView.DisplayMember; }
            set { popupView.DisplayMember = value; }
        }
        /// <summary>
        /// 值的成员字段
        /// </summary>
        public string ValueMember
        {
            get { return popupView.ValueMember; }
            set { popupView.ValueMember = value; }
        }
        /// <summary>
        /// 过滤字段
        /// </summary>
        public string[] FilterFields
        {
            get { return popupView.FilterFields; }
            set { popupView.FilterFields = value; }
        }
        /// <summary>
        /// 获取选择的文本
        /// </summary>
        [Browsable(false)]
        public new string SelectedText { get; private set; }
        /// <summary>
        /// 获取选中的值
        /// </summary>
        [Browsable(false)]
        public string SelectedValue { get; private set; }
        /// <summary>
        /// 获取选中项对象
        /// </summary>
        [Browsable(false)]
        public System.Data.DataRowView SelectedItem { get; private set; }
        /// <summary>
        /// 获取或设置数据源
        /// </summary>
        [Browsable(false)]
        public System.Data.DataTable DataSource { get { return popupView.DataSource; } set { popupView.DataSource = value; } }
        /// <summary>
        /// 获取或设置窗口的最大限制
        /// </summary>
        public Size PopupMaximumSize { get { return popupView.MaximumSize; } set { popupView.MaximumSize = value; } }
        /// <summary>
        /// 获取或设置窗口的最小限制
        /// </summary>
        public Size PopupMinimumSize { get { return popupView.MinimumSize; } set { popupView.MinimumSize = value; } }
        private new bool ReadOnly { get { return true; } }
        /// <summary>
        /// 是否可以改变窗口大小
        /// </summary>
        public bool CanResizePopup { get { return popupHost.CanResize; } set { popupHost.CanResize = value; } }
        /// <summary>
        /// 是否显示窗口阴影
        /// </summary>
        public bool ShowPopupShadow { get { return popupHost.DropShadowEnabled; } set { popupHost.DropShadowEnabled = value; } }
        /// <summary>
        /// 获取或设置窗口边框宽度
        /// </summary>
        public Padding PopupBorderWidth { get { return popupHost.Padding; } set { popupHost.Padding = value; } }
        /// <summary>
        /// 获取或设置窗口边框颜色
        /// </summary>
        public Color PopupBorderColor { get { return popupHost.BorderColor; } set { popupHost.BorderColor = value; } }
        /// <summary>
        /// 获取或设置窗口的上下偏移量
        /// </summary>
        public int PopupOffSet { get; set; }
        public FindComboBox()
        {
            base.ReadOnly = true;
            this.PopupOffSet = 2;
            this.Cursor = Cursors.Arrow;
            popupHost = new PopupControlHost(popupView);
            popupHost.IngoreControl = this; //设置点击当前控件不会自动关闭窗口
            popupHost.OpenFocused = true; //设置显示窗口是获得焦点
            popupHost.Padding = new System.Windows.Forms.Padding(1); //设置窗口边框大小
            popupHost.BorderColor = Color.FromArgb(179, 199, 225); //设置窗口边框颜色
            popupView.DoubleClickedToSelect = false; //设置点击选择项目
            popupView.FilterTextBox.TextChanged += FilterTextBox_TextChanged;
            popupView.ItemSelected += popupView_ItemSelected;
        }

        void FilterTextBox_TextChanged(object sender, EventArgs e)
        {
            this.AdjustPopupLoactionAndSize();
        }

        void popupView_ItemSelected(object sender, EventArgs e)
        {
            this.SelectedText = popupView.SelectedText;
            this.SelectedValue = popupView.SelectedValue.AsString();
            this.SelectedItem = popupView.SelectedItem as System.Data.DataRowView;
            this.Text = popupView.SelectedText;
            if (this.Visible)
                popupHost.Close();
            if (this.ItemSelected != null)
            {
                this.ItemSelected(this, e);
            }
        }

        /// <summary>
        /// 矫正窗口位置和大小
        /// </summary>
        private void AdjustPopupLoactionAndSize()
        {
            var size = popupView.CalcItemsSize();
            var screen = Screen.GetWorkingArea(this);
            var pointTop = this.Parent.PointToScreen(this.Location);
            var pointBottom = new Point(pointTop.X, pointTop.Y + this.Height);
            if (popupView.MinimumSize.Width > 0 && size.Width < popupView.MinimumSize.Width)
            {
                size.Width = this.MinimumSize.Width;
            }
            if (popupView.MaximumSize.Width > 0 && size.Width > popupView.MaximumSize.Width)
            {
                size.Width = popupView.MaximumSize.Width;
            }
            if (popupView.MinimumSize.Height > 0 && size.Height < popupView.MinimumSize.Height)
            {
                size.Height = popupView.MinimumSize.Height;
            }
            if (popupView.MaximumSize.Height > 0 && size.Height > popupView.MaximumSize.Height)
            {
                size.Height = popupView.MaximumSize.Height;
            }
            if (size.Width > screen.Width)
                size.Width = screen.Width - 10;
            if (size.Height > screen.Height)
                size.Height = screen.Height - 10;
            if (size.Width <= 0)
                size.Width = this.Width-popupHost.Padding.Horizontal;
            if (size.Height <= 0)
                size.Height = 200;

            var bottomHeight = screen.Height - pointBottom.Y;
            if (size.Height > bottomHeight - this.PopupOffSet && size.Height > pointTop.Y - this.PopupOffSet)
            {
                if (pointTop.Y < bottomHeight)
                {
                    size.Height = bottomHeight - this.PopupOffSet;
                }
                else
                {
                    size.Height = pointTop.Y - this.PopupOffSet;
                }
            }
            
            popupView.Size = size;

            if (!popupView.UpOrDown)
            {
                popupHost.Location = new Point(pointTop.X, pointTop.Y - size.Height - this.PopupOffSet);
            }

        }
        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="forceUpdate">是否强制显示</param>
        public void ShowPopup(bool forceUpdate=false)
        {
            if (!forceUpdate && popupHost.Visible)
                return;
            var size = popupView.CalcItemsSize();
            var pointTop = this.Parent.PointToScreen(this.Location);
            var pointBottom = new Point(pointTop.X, pointTop.Y + this.Height);
            var screen = Screen.GetWorkingArea(this);
            var bottomHeight = screen.Height - pointBottom.Y;
            var rightWidth = screen.Width - pointTop.X;
            int positionX = 0;
            int positionY = 0;
            bool showUpOrDown = false;
            #region 防止大小超出边界

            if (popupView.MinimumSize.Width > 0 && size.Width < popupView.MinimumSize.Width)
            {
                size.Width = this.MinimumSize.Width;
            }
            if (popupView.MaximumSize.Width > 0 && size.Width > popupView.MaximumSize.Width)
            {
                size.Width = popupView.MaximumSize.Width;
            }
            if (popupView.MinimumSize.Height > 0 && size.Height < popupView.MinimumSize.Height)
            {
                size.Height = popupView.MinimumSize.Height;
            }
            if (popupView.MaximumSize.Height > 0 && size.Height > popupView.MaximumSize.Height)
            {
                size.Height = popupView.MaximumSize.Height;
            }
            if (size.Width > screen.Width)
                size.Width = screen.Width - 10;
            if (size.Height > screen.Height)
                size.Height = screen.Height - 10;
            if (size.Width <= 0)
                size.Width = this.Width - popupHost.Padding.Horizontal;
            if (size.Height <= 0)
                size.Height = 200;

            #endregion
            #region 计算X轴坐标和允许显示的宽度

            if (size.Width <= rightWidth )
            {
                positionX = pointTop.X;
            }
            else
            {
                positionX = pointTop.X -(size.Width - rightWidth);
            }
            #endregion
            #region 计算Y轴坐标和允许显示的高度
            
            if (size.Height <= bottomHeight - this.PopupOffSet)
            {
                positionY = pointBottom.Y + this.PopupOffSet;
            }
            else
            {
                if (size.Height <= pointTop.Y - this.PopupOffSet)
                {
                    positionY = pointTop.Y - size.Height - this.PopupOffSet;
                    showUpOrDown = true;
                }
                else
                {
                    if (pointTop.Y < bottomHeight)
                    {
                        positionY = pointBottom.Y + this.PopupOffSet;
                        size.Height = bottomHeight - this.PopupOffSet;
                    }
                    else
                    {
                        positionY = 0;
                        size.Height = pointTop.Y - this.PopupOffSet;
                        showUpOrDown = true;
                    }
                }
            }
            #endregion
            popupView.UpOrDown = !showUpOrDown;
            popupView.Size = size;
            popupHost.Show(new Point(positionX, positionY));

        }
        /// <summary>
        /// 重写鼠标点击事件
        /// 设置点击显示窗口
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            if (popupHost.Visible)
                popupHost.Close();
            else
            {
                popupView.FilterTextBox.Text = "";
                popupView.DefaultSelectedValue = this.SelectedValue;
                ShowPopup();
            }
            base.OnMouseClick(e);
        }
        /// <summary>
        /// 重写获得焦点时事件
        /// 设置获得焦点是否显示窗口
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotFocus(EventArgs e)
        {
            if (this.FocusOpen)
                this.ShowPopup();
            base.OnGotFocus(e);
        }
        /// <summary>
        /// 设置显示窗口快捷键(Down)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                popupView.FilterTextBox.Text = "";
                popupView.DefaultSelectedValue = this.SelectedValue;
                this.ShowPopup();
            }
            base.OnKeyDown(e);
        }

    }
}
