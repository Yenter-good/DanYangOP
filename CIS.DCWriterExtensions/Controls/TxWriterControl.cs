namespace CIS.DCWriter.Controls
{
    /// <summary>
    /// 编辑器
    /// </summary>
    public class TxWriterControl : DCSoft.Writer.Controls.WriterControl
    {
        public TxWriterControl()
        {
            this.RegisterCode = "02324EA500000000000027000000E6B7B1E59CB3E4B99DE6988EE78FA0E4BFA1E681AFE7A791E68A80E69C89E99990E585ACE58FB88AAF15000000E4B99DE6988EE78FA0454D52E7BC96E8BE91E599A80400";
        }

        /// <summary>
        /// 获取选中的XML文本
        /// </summary>
        public string GetSelectionXMLText()
        {
            return this.Selection.CreateDocument(true).XMLTextUnFormatted;
        }
    }
}
