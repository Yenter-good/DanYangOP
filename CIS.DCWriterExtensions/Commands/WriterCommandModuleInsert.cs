using DCSoft.Writer.Commands;
using DCSoft.Writer.Dom;
using System.IO;

namespace CIS.DCWriter.Commands
{
    partial class WriterCommandModuleExtension
    {
        /// <summary>
        /// 插入xml命令 会移除结尾的空白符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [WriterCommandDescription("InsertXMLExt", ReturnValueType = typeof(XTextElementList))]
        protected void InsertXMLExtCommand(object sender, WriterCommandEventArgs e)
        {
            //查询命令状态 用于同步界面按钮
            if (e.Mode == WriterCommandEventMode.QueryState)
            {
                //是否启用按钮
                e.Enabled = (e.DocumentControler != null && e.Document != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement)));
            }
            else
            {
                //执行命令时运行的方法
                if (e.Mode == WriterCommandEventMode.Invoke)
                {
                    this.InsertXML(e, false);
                }
            }
        }
        /// <summary>
        /// 插入XML
        /// </summary>
        /// <param name="args">命令参数</param>
        /// <param name="updateStyle">是否更新样式</param>
        private void InsertXML(WriterCommandEventArgs args, bool updateStyle)
        {
            args.Result = false;
            if (args.UIStartEditContent())
            {
                XTextDocument xTextDocument = null;
                if (args.Parameter is string)
                {
                    string text = (string)args.Parameter;
                    text = text.Trim();
                    if (!text.StartsWith("<"))
                    {
                        return;
                    }
                    StringReader stringReader = new StringReader((string)args.Parameter);
                    xTextDocument = (XTextDocument)args.Document.CreateElementByType(args.Document.GetType());
                    xTextDocument.Load(stringReader, "xml", true);
                    stringReader.Close();
                }
                else
                {
                    if (args.Parameter is Stream)
                    {
                        xTextDocument = (XTextDocument)args.Document.CreateElementByType(args.Document.GetType());
                        xTextDocument.Load((Stream)args.Parameter, "xml", true);
                    }
                    else
                    {
                        if (args.Parameter is TextReader)
                        {
                            xTextDocument = (XTextDocument)args.Document.CreateElementByType(args.Document.GetType());
                            xTextDocument.Load((TextReader)args.Parameter, "xml", true);
                        }
                    }
                }
                args.Result = this.InsertDocument(args, xTextDocument, updateStyle, true);
            }
        }
        /// <summary>
        /// 插入文档
        /// </summary>
        /// <param name="args"></param>
        /// <param name="xTextDocument">文档</param>
        /// <param name="updateStyle">是否更新样式</param>
        /// <param name="verify">是否验证是否可以插入</param>
        /// <returns></returns>
        private XTextElementList InsertDocument(WriterCommandEventArgs args, XTextDocument xTextDocument, bool updateStyle, bool verify)
        {
            if (xTextDocument == null || xTextDocument.Body == null || xTextDocument.Body.Elements.Count == 0
                || (xTextDocument.Body.Elements.Count == 1 && xTextDocument.Body.Elements[0].IsRedundant(true, true, true, true, true))
                || (verify && !args.DocumentControler.CanInsertDocument(xTextDocument, args.ShowUI)))
                return null;

            XTextElementList result;
            xTextDocument.FixDomState();
            XTextElementList xTextElementList = xTextDocument.Body.Elements.Clone();

            if (updateStyle)
            {
                //同步样式
                //xTextDocument.ContentStyles.Styles.Clear();
                //xTextDocument.ContentStyles.Default = args.Document.ContentStyles.Default;
                int currentContentStyle = args.Document.ContentStyles.GetStyleIndex(args.Document.CurrentStyleInfo.Content);
                int currentParagraphStyle = args.Document.ContentStyles.GetStyleIndex(args.Document.CurrentStyleInfo.Paragraph);
                xTextElementList.Enumerate((s, a) =>
                {
                    if (a.Element is XTextParagraphFlagElement)
                        a.Element.StyleIndex = currentParagraphStyle;
                    else
                        a.Element.StyleIndex = currentParagraphStyle;
                });
            }
            //导入元素
            args.Document.ImportElements(xTextElementList);
            //删除结尾段落符
            xTextElementList.DeleteRedundant(true, true, true, false, true);
            //插入元素
            if (xTextElementList.Count > 0)
            {
                args.DocumentControler.InsertElements(xTextElementList);
            }
            result = xTextElementList;
            return result;
        }

    }
}
