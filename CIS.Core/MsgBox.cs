namespace CIS.Core
{
    /// <summary>
    /// 消息提示框
    /// </summary>
    public static class MsgBox
    {
        public static void OK(string text)
        {
            System.Windows.Forms.MessageBox.Show(text, "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        public static System.Windows.Forms.DialogResult YesNo(string text)
        {
            return System.Windows.Forms.MessageBox.Show(text, "提示", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
        }

        public static System.Windows.Forms.DialogResult OKCancel(string text)
        {
            return System.Windows.Forms.MessageBox.Show(text, "提示", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button2);
        }

        public static System.Windows.Forms.DialogResult AbortRetryIgnore(string text)
        {
            return System.Windows.Forms.MessageBox.Show(text, "提示", System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, System.Windows.Forms.MessageBoxIcon.Information);
        }

        public static System.Windows.Forms.DialogResult RetryCancel(string text)
        {
            return System.Windows.Forms.MessageBox.Show(text, "提示", System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button2);
        }

        public static System.Windows.Forms.DialogResult YesNoCancel(string text)
        {
            return System.Windows.Forms.MessageBox.Show(text, "提示", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button3);
        }
    }
}