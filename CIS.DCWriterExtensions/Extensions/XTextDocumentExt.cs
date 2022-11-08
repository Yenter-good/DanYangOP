using System;

namespace DCSoft.Writer.Dom
{
    public static class XTextDocumentExt
    {
         /// <summary>
         /// 导入范文
         /// </summary>
         /// <param name="document"></param>
         /// <param name="sample">范文xml</param>
         /// <param name="updateContent"></param>
         /// <returns></returns>
         public static bool ImportSample(this XTextDocument document, string sample,bool updateContent=true)
         {
             //验证范文的有效性
             if (sample.IsNullOrWhiteSpace())
                 return false;
             XTextDocument sampleDocument = new XTextDocument();
             try
             {
                 sampleDocument.LoadFromString(sample, "xml");
             }
             catch { return false; }
             //记录内容是否发生变更
             bool hasContentChange = false;
             //判断文档是否在编辑器中
             bool hasEditorControl = document.EditorControl != null;
             //枚举文档正文中全部元素 替换
             document.Body.Enumerate((sender, args) => {
                 args.ExcludeCharElement = true;
                 args.ExcludeParagraphFlag = true;
                 //元素是否允许导入
                 if (CanImport(args.Element))
                 {
                     //获取范文中的元素
                     var sampleElement = sampleDocument.GetElementById(args.Element.ID);
                     if (sampleElement == null) return;
                     //如果当前元素为输入域
                     if (args.Element is XTextInputFieldElementBase)
                     {
                         //获取输入域
                         var inputField = args.Element as XTextInputFieldElementBase;
                         //变更输入域内容 
                         try
                         {
                             inputField.ContentBuilder.Clear();
                             inputField.ContentBuilder.AppendDocumentContent(sampleElement.CreateContentDocument(false), true, true, true, true);
                         }
                         catch
                         {
                             if (hasContentChange)
                             {
                                 var arg = new SetContainerTextArgs();
                                 arg.AccessFlags = DomAccessFlags.None;
                                 arg.DisablePermission = false;
                                 arg.LogUndo = true;
                                 arg.UpdateContent = false;
                                 arg.NewTextStyle = sampleElement.RuntimeStyle;
                                 arg.NewText = sampleElement.Text;
                                 inputField.SetEditorText(arg);
                             }
                             else
                             {
                                 inputField.SetInnerTextFast(sampleElement.Text);
                             }
                         }
                         //记录变更
                         inputField.Modified = true;
                         hasContentChange = true;
                     }
                         //如果当前元素为复选框元素
                     else if (args.Element is XTextCheckBoxElementBase)
                     {
                         if (sampleElement is XTextCheckBoxElementBase)
                         {
                             //替换内容
                             var checkBoxElement = args.Element as XTextCheckBoxElementBase;
                             checkBoxElement.EditorChecked = checkBoxElement.Checked;
                             //记录变更
                             checkBoxElement.Modified = true;
                             hasContentChange = true;
                         }
                     }
                 }
             });
             //判断内容是否发生变更
             if (hasContentChange)
             {
                 if (updateContent && hasEditorControl)
                     document.EditorRefreshView();
                 else
                     document.FixDomState();
                 document.Modified = true;
                 document.OnSelectionChanged();
                 document.OnDocumentContentChanged();
             }
             return hasContentChange;
         }
         /// <summary>
         /// 导出词语
         /// </summary>
         /// <param name="document">文档对象</param>
         /// <param name="inputFieldId">输入域编号</param>
         /// <param name="word">词语内容</param>
         /// <param name="format">格式</param>
         /// <param name="updateContent">是否更新界面</param>
         /// <returns></returns>
         public static bool ImportWord(this XTextDocument document, string inputFieldId, string word, string format="xml",bool updateContent =false)
         {
             var element = document.GetElementById(inputFieldId);
            if (element == null) return false;
            if (element is XTextInputFieldElementBase)
            {
                var inputField = element as XTextInputFieldElementBase;
                inputField.AppendXML(word, format);

                if (updateContent && document.EditorControl != null)
                    inputField.EditorRefreshView();
                inputField.Modified = true;
                document.Modified = true;
                document.OnSelectionChanged();
                document.OnDocumentContentChanged();
                return true;
            }
            return false;
         }
         /// <summary>
         /// 导出范文XML
         /// </summary>
         /// <param name="document"></param>
         /// <returns></returns>
         public static string ExportSample(this XTextDocument document)
         {
             var exportDocument = document.Clone(true) as XTextDocument;
             exportDocument.CommitUserTrace();
             exportDocument.Enumerate((sender, args) =>
             {
                 args.ExcludeCharElement = true;
                 args.ExcludeParagraphFlag = true;
                 if (CanImport(args.Element))
                     args.Element.Text = "";
             });
             return exportDocument.XMLTextUnFormatted;
         }

         /// <summary>
         /// 验证元素是否允许导入
         /// </summary>
         /// <param name="element"></param>
         /// <returns></returns>
         private static bool CanImport(XTextElement element)
         {
             if (element.IsLogicDeleted) return false;
             if (element.HasValueBindingEx()) return false;
             return true;
         }

        

    }
}
