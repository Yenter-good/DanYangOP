using System;
using System.Windows.Forms;

namespace CIS.Core
{
    public partial class BaseForm : DevComponents.DotNetBar.Office2007Form
    {
        //快捷键管理器
        private ShortcutKey ShortcutKey;

        public BaseForm()
        {
            InitializeComponent();
            ShortcutKey = new ShortcutKey();
        }

        private Control[] OffImeControl { get; set; }

        public void SetOffIme(params Control[] control)
        {
            OffImeControl = control;
        }

        private void BaseForm_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {

        }

            /// <summary>
            /// 初始化窗口内功能的快捷键
            /// </summary>
            /// <param name="shortcutKey"></param>
            protected virtual void InitializeShortcutKeys(ShortcutKey shortcutKey)
            {

            }

            protected override void OnLoad(EventArgs e)
            {
                //初始化窗口内功能的快捷键
                this.InitializeShortcutKeys(ShortcutKey);
                base.OnLoad(e);
            }
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                if (ShortcutKey.Raise(keyData))
                    return true;
                return base.ProcessCmdKey(ref msg, keyData);
            }

    }
}
