using CIS.ControlLib.Helper.PopupStyle;
using CIS.ControlLib.Win32;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CIS.ControlLib.Controls
{
    public class ComboTokenEditor:DevComponents.DotNetBar.Controls.TokenEditor
    {
        private PopupControlHost m_PopupHost;
        private ComboPopupView _PopupView = null;

        public DataTable PopupDataSource
        {
            get { return _PopupView.DataSource; }
            set { _PopupView.DataSource = value; }
        }

        public string DisplayMember
        {
            get { return _PopupView.DisplayMember; }
            set { _PopupView.DisplayMember = value; }
        }

        public string ValueMember
        {
            get { return _PopupView.ValueMember; }
            set { _PopupView.ValueMember = value; }
        }

        public string[] FilterFields
        {
            get { return _PopupView.FilterFields; }
            set { _PopupView.FilterFields = value; }
        }

        public new bool EnablePopupResize
        {
            get { return m_PopupHost.CanResize; }
            set { m_PopupHost.CanResize = value; }
        }

        public Size PopupSize
        {
            get { return _PopupView.Size; }
            set { _PopupView.Size = value; }
        }


        public ComboTokenEditor()
        {
            this.EnterKeyValidatesToken = false;
            _PopupView = new ComboPopupView();
            _PopupView.Size = new System.Drawing.Size(this.Width, 200);
            _PopupView.ItemSelected += _PopupView_ItemSelected;
            m_PopupHost = new PopupControlHost(_PopupView);
            this.EditTextBox.TextChanged += EditTextBox_TextChanged;
            this.EditTextBox.KeyDown += EditTextBox_KeyDown;
        }

        void EditTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Enter:
                    if (_PopupView.View != null && (_PopupView as Control).IsHandleCreated && m_PopupHost.Visible)
                        UnsafeNativeMethods.SendMessage(_PopupView.View.Handle, (int)WinMsg.WM_KEYDOWN, (int)e.KeyCode, 0);
                    e.Handled = true;
                    break;
                default:
                    break;
            }
        }

        void _PopupView_ItemSelected(object sender, EventArgs e)
        {
            this.EditTextBox.ResetText();
            if(_PopupView.SelectedItem!=null)
                this.SelectedTokens.Add(new DevComponents.DotNetBar.Controls.EditToken(_PopupView.SelectedValue.AsString(),_PopupView.SelectedText));
            if (m_PopupHost.Visible)
                m_PopupHost.Close();
        }

        void EditTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.EditTextBox.Text.IsNullOrWhiteSpace()) return;
            _PopupView.Filter(this.EditTextBox.Text.Trim());
            if (!m_PopupHost.Visible)
                m_PopupHost.Show(this);
        }
    
        protected override void OnBeforeAutoCompletePopupOpen(System.ComponentModel.CancelEventArgs e)
        {
            //屏蔽自带的弹出窗口
            e.Cancel = true;
            base.OnBeforeAutoCompletePopupOpen(e);
        }
        
    }
}
