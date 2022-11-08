using CIS.DCWriter.Dom;

namespace DCSoft.Writer.Dom
{
    /// <summary>
    /// 扩展元素集合操作
    /// </summary>
    public static class XTextElementListExt
    {
        /// <summary>
        /// 删除结尾空白符
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="whiteSpace">移除空格符</param>
        /// <param name="tabSpace">移除制位符</param>
        /// <param name="paragraphFlag">移除段落符</param>
        /// <param name="pageBreak">移除分页符</param>
        /// <param name="lineBreak">移除换行符</param>
        /// <returns></returns>
        public static int DeleteRedundant(this XTextElementList elements, bool whiteSpace, bool tabSpace, bool paragraphFlag, bool pageBreak, bool lineBreak)
        {
            if (elements == null || elements.Count == 0) return 0;
            int num = 0;
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                if (!elements[i].IsRedundant(whiteSpace, tabSpace, paragraphFlag, pageBreak, lineBreak))
                    break;
                num++;
            }
            if (num > 0)
            {
                elements.RemoveRange(elements.Count - num, num);
            }

            return num;
        }
        /// <summary>
        /// 移除结尾自动创建的段落符
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static bool RemoveAutoCreateParagraphFlag(this XTextElementList elements)
        {
            if (elements != null && elements.Count > 0)
            {
                if (elements.LastElement is XTextParagraphFlagElement)
                {
                    XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)elements.LastElement;
                    if (xTextParagraphFlagElement.AutoCreate)
                    {
                        elements.RemoveAt(elements.Count - 1);
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 遍历元素操作
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="handler">操作委托</param>
        /// <param name="deeply">是否深度遍历子元素</param>
        public static void Enumerate(this XTextElementList elements, ElementEnumerateEventHandlerExt handler,bool deeply=true)
        {
            ElementEnumerateEventArgsExt args = new ElementEnumerateEventArgsExt();
            InnerEnumerate(elements, handler, args, deeply);
        }
        /// <summary>
        /// 遍历元素操作
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="handler"></param>
        /// <param name="args"></param>
        /// <param name="deeply"></param>
        private static void InnerEnumerate(XTextElementList elements, ElementEnumerateEventHandlerExt handler, ElementEnumerateEventArgsExt args, bool deeply)
        {
            foreach (XTextElement xTextElement in elements)
            {
                args._Element = xTextElement;
                args.CancelChild = false;
                handler(null, args);
                if (args.Cancel)
                {
                    break;
                }
                if (!args.CancelChild && deeply)
                {
                    if (xTextElement is XTextContainerElement)
                    {
                        InnerEnumerate(((XTextContainerElement)xTextElement).Elements, handler, args, deeply);
                        if (args.Cancel)
                        {
                            break;
                        }
                    }
                }
                args.CancelChild = false;
            }
        }
        
    }
}
