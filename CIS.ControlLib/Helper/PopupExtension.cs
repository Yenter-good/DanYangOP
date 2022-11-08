using CIS.ControlLib.Controls;
using CIS.ControlLib.Helper.PopupStyle;
using CIS.ControlLib.Win32;
using CIS.ControlLib;
using System.Drawing;

namespace System.Windows.Forms
{
    public static class PopupExtension
    {
        /// <summary>
        /// 设置文本框过滤提示框
        /// 调用方式
        /// //只要继承了Textboxbase的控件支持
        ////new TextBox().ComboPopup(selectedItem =>
        ////{
        ////    //selectedItem为选中的对象
        ////    //选中后执行的代码
        ////}
        ////, v =>
        ////{
        ////    v.Size = new Size(100, 100); //设置显示的窗口大小 默认为textbox的宽度，高度为100
        ////    v.DataSource = null; //设置数据源
        ////    v.DisplayMember = ""; //设置显示的字段
        ////    v.ValueMember = ""; //设置值的字段
        ////    v.FilterFields = new string[] { }; //设置用于过滤的字段
        ////}, p => {
        ////    p.CanResize = true;//是否允许拉动窗口大小 默认不支持
        ////    p.BorderColor = Color.Gray; //设置窗口边框颜色 默认为蓝色
        ////    p.AutoClose = true;//设置是否自动关闭窗体 默认为true
        ////}
        ////,true //是否选择后设置textbox文本为选择的文本
        ////, PopupPosition.Bottom //设置窗口显示的位置 默认为文本框的左下角
        ////);
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="itemSelected">选中后发生</param>
        /// <param name="viewAction">可以设置筛选框的数据源，显示字段，与过滤字段</param>
        /// <param name="popupHostAction">可以设置显示窗口的边框样式与拖拽方式</param>
        /// <param name="appendText">是否设置选中后设置文本框文本</param>
        /// <param name="position">设置显示位置</param>
        public static void ComboPopup(this TextBoxBase textBox, Action<object> itemSelected, Action<ComboPopupView> viewAction, Action<PopupControlHost> popupHostAction, bool updateText = true, PopupPosition position = PopupPosition.Bottom)
        {
            var popupView = new ComboPopupView();
            (popupView as Control).Size = new Size(textBox.Width, 200);
            if (viewAction != null)
                viewAction(popupView);
            Popup<ComboPopupView>(textBox, popupView, itemSelected, popupHostAction, updateText, position);
        }
        //public static void ComboFindPopup(this TextBoxBase textBox, Action<object> itemSelected, Action<ComboFindPopupView> viewAction, Action<PopupControlHost> popupHostAction, bool updateText = true, PopupPosition position = PopupPosition.Bottom)
        //{
        //    var popupView = new ComboFindPopupView();
        //    (popupView as Control).Size = new Size(textBox.Width, 200);
        //    if (viewAction != null)
        //        viewAction(popupView);
        //    FindPopup<ComboFindPopupView>(textBox, popupView, itemSelected, popupHostAction, updateText, position);
        //}
        public static void GridPopup(this TextBoxBase textBox, Action<object> itemSelected, Action<GridPopupView> viewAction, Action<PopupControlHost> popupHostAction, bool updateText = true, PopupPosition position = PopupPosition.Bottom)
        {
            var popupView = new GridPopupView();
            (popupView as Control).Size = new Size(textBox.Width, 200);
            if (viewAction != null)
                viewAction(popupView);
            Popup<GridPopupView>(textBox, popupView, itemSelected, popupHostAction, updateText, position);

        }

        private static void Popup<TPopupView>(TextBoxBase textBox, TPopupView popupView, Action<object> itemSelected, Action<PopupControlHost> popupHostAction, bool updateText = true, PopupPosition position = PopupPosition.Bottom) where TPopupView : Control, IPopupFilterView
        {
            PopupControlHost popupHost = new PopupControlHost(popupView as Control);
            popupHost.BorderColor = Color.Gray;
            if (popupHostAction != null)
                popupHostAction(popupHost);
            bool isItemSelected = false;

            popupView.ItemSelected += (s, e) =>
            {
                isItemSelected = true;
                if (updateText)
                {
                    textBox.Text = popupView.SelectedText;
                    textBox.SelectAll();
                }
                if (itemSelected != null)
                {
                    itemSelected(popupView.SelectedItem);
                }
                if (popupHost.Visible)
                    popupHost.Close();
                isItemSelected = false;
            };

            textBox.TextChanged += (s, e) =>
            {
                if (isItemSelected) return;
                popupView.Filter(textBox.Text.Trim());
                if (popupView.Adaptive)
                {
                    Size size = popupView.CalcItemsSize();
                    popupView.Size = size;
                }
                //if (!popupHost.Visible)
                popupHost.Show(textBox, position);
            };
            textBox.KeyDown += (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                    case Keys.Up:
                    case Keys.PageUp:
                    case Keys.PageDown:
                    case Keys.Enter:
                        if (popupView.View != null && (popupView as Control).IsHandleCreated && popupHost.Visible)
                            UnsafeNativeMethods.SendMessage(popupView.View.Handle, (int)WinMsg.WM_KEYDOWN, (int)e.KeyCode, 0);
                        e.Handled = true;
                        break;
                    default:
                        break;
                }
            };
        }

        //private static void FindPopup<TPopupView>(TextBoxBase textBox, TPopupView popupView, Action<object> itemSelected, Action<PopupControlHost> popupHostAction, bool updateText = true, PopupPosition position = PopupPosition.Bottom) where TPopupView : Control, IFindPopupFilterView
        //{
        //    textBox.ReadOnly = true;
           
        //    PopupControlHost popupHost = new PopupControlHost(popupView as Control);
        //    popupHost.IngoreControl = textBox;
        //    popupHost.BorderColor = Color.Gray;
        //    popupHost.OpenFocused = true;
        //    if (popupHostAction != null)
        //        popupHostAction(popupHost);
        //    popupView.FilterTextChanged += (filterText) => {
        //        if (popupView.Adaptive)
        //        {
        //            popupView.Size = popupView.CalcItemsSize();
        //        }
        //    };
        //    popupView.ItemSelected += (s, e) =>
        //    {
        //        if (updateText)
        //        {
        //            textBox.Text = popupView.SelectedText;
        //            textBox.SelectAll();
        //        }
        //        if (itemSelected != null)
        //        {
        //            itemSelected(popupView.SelectedItem);
        //        }
        //        if (popupHost.Visible)
        //            popupHost.Close();
        //    };

        //    textBox.MouseClick += (s, e) =>
        //    {
        //        //popupView.Filter(textBox.Text.Trim());
        //        if (popupView.Adaptive)
        //        {
        //            Size size = popupView.CalcItemsSize();
        //            popupView.Size = size;
        //        }
        //        if (!popupHost.Visible)
        //            popupHost.Show(textBox, position);
        //        else
        //            popupHost.Close();
        //    };
        //    textBox.KeyDown += (s, e) => {
        //        if (e.KeyCode == Keys.Down)
        //        {
        //            if(!popupHost.Visible)
        //                popupHost.Show(textBox, position);
        //        }
        //    };
        //}
        
    }
}
