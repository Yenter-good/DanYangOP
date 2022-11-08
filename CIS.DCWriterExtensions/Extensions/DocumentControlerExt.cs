using System.Windows.Forms;

namespace DCSoft.Writer.Dom
{
    /// <summary>
    /// 扩展文档控制器
    /// </summary>
    public static class DocumentControlerExt
    {
        /// <summary>
        /// 判断是否可以插入指定文档的内容
        /// </summary>
        /// <param name="documentControler"></param>
        /// <param name="xTextDocument">文档</param>
        /// <param name="showToolTip">是否显示提示</param>
        /// <returns></returns>
        public static bool CanInsertDocument(this DocumentControler documentControler, XTextDocument xTextDocument, bool showToolTip)
        {
            XTextDocument ownerDocument = documentControler.Document;
            InsertDocumentWithCheckMRIDType insertDocumentWithCheckMRID = ownerDocument.Options.BehaviorOptions.InsertDocumentWithCheckMRID;
            if (insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.ForbitWhenFail || insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.WarringWhenFail || insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.PromptForbitWhenFail)
            {
                if (xTextDocument.Info.IsTemplate)
                {
                    return true;
                }
                if (!string.IsNullOrEmpty(ownerDocument.Info.MRID) && ownerDocument.Info.MRID != xTextDocument.Info.MRID)
                {
                    if (insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.ForbitWhenFail)
                    {
                        return false;
                    }
                    if (showToolTip)
                    {
                        string text = "";
                        if (insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.PromptForbitWhenFail)
                        {
                            text = ownerDocument.Options.BehaviorOptions.CustomPromptForbitCheckMRID;
                            if (string.IsNullOrEmpty(text))
                            {
                                text = "当前文档与要粘贴的内容的来源不是同一个病人,根据规范,禁止执行本次操作";
                            }
                            text = text.Replace("{0}", ownerDocument.Info.MRID).Replace("{1}", xTextDocument.Info.MRID);
                            documentControler.AppHost.UITools.ShowErrorMessageBox(ownerDocument.EditorControl, text);
                            MessageBox.Show(text, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        text = ownerDocument.Options.BehaviorOptions.CustomWarringCheckMRID;
                        if (string.IsNullOrEmpty(text))
                        {
                            text = "当前文档与要粘贴的内容的来源不是同一个病人,根据规范,不建议执行本次操作,是否继续";
                        }
                        text = text.Replace("{0}", ownerDocument.Info.MRID).Replace("{1}", xTextDocument.Info.MRID);
                        return MessageBox.Show(text, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                         == DialogResult.Yes;
                    }
                    return false;
                }
            }
            return true;
        }
    }
}
