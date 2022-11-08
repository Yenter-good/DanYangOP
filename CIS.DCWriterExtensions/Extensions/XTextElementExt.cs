using System;

namespace DCSoft.Writer.Dom
{
    public static class XTextElementExt
    {
        /// <summary>
        /// 判断元素启用了绑定功能
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool HasValueBindingEx(this XTextElement element)
        {
            if (element is XTextContainerElement || element is XTextCheckBoxElementBase)
            {
                if (element is XTextContainerElement)
                {
                    var contianer = element as XTextContainerElement;
                    return contianer.HasValueBinding && contianer.ValueBinding.Enabled && !contianer.ValueBinding.IsEmptyBinding;
                }
                if (element is XTextCheckBoxElementBase)
                {
                    var checkBox = element as XTextCheckBoxElementBase;
                    return checkBox.ValueBinding != null && checkBox.ValueBinding.Enabled && !checkBox.ValueBinding.IsEmptyBinding;
                }
            }
            return false;
        }
        /// <summary>
        /// 获取元素所属的输入域对象
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XTextInputFieldElementBase GetOwnerInputField(this XTextElement element)
        {
            XTextInputFieldElementBase result;
            while (element != null)
            {
                if (element is XTextInputFieldElementBase)
                {
                    result = (XTextInputFieldElementBase)element;
                    return result;
                }
                element = element.Parent;
            }
            result = null;
            return result;
        }
        /// <summary>
        /// 获取元素的顶级输入域对象
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XTextInputFieldElementBase GetTopInputField(this XTextElement element)
        {
            XTextInputFieldElementBase result;
            while (element != null)
            {
                if (element.Parent is XTextInputFieldElementBase)
                    element = element.Parent;
                else
                    return (XTextInputFieldElementBase)element;
            }
            result = null;
            return result;
        }
        public static void AppendXML(this XTextInputFieldElementBase element, string xml, string format = "xml")
        {
            if (element.OwnerDocument == null) return;
            if (xml.IsNullOrWhiteSpace()) return;
            //element.ContentBuilder.Clear();
            element.ContentBuilder.AppendDocumentContentByString(xml, format, true, true, true, true);
        }
        public static void InsertXml(this XTextDocument document, string xml)
        {
            var current = document.CurrentElement;
            int pos = 0;
            if (current != null)
                pos = current.ElementIndex;
            var container = current.Parent;
            container.ContentBuilder.InsertDocumentContentByString(pos, xml, "xml", true, true, true, true);
        }
        /// <summary>
        /// 获取元素的所有父级对象集合
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XTextElementList GetAllParents(this XTextElement element)
        {
            if (element == null) throw new ArgumentNullException("element");
            XTextElementList xTextElementList = new XTextElementList();
            for (XTextContainerElement parent = element.Parent; parent != null; parent = parent.Parent)
            {
                xTextElementList.Add(parent);
            }
            return xTextElementList;
        }
        /// <summary>
        /// 获取元素的父级对象集合 除第一个内容元素为自身的之外
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XTextElementList GetParentsExceptIsFirstContentElement(this XTextElement element)
        {
            if (element == null) throw new ArgumentNullException("element");
            XTextElementList xTextElementList = new XTextElementList();
            for (XTextContainerElement parent = element.Parent; parent != null; parent = parent.Parent)
            {
                if (parent.FirstContentElement != element)
                {
                    xTextElementList.Add(parent);
                }
            }
            return xTextElementList;
        }
        /// <summary>
        /// 获取当前元素与指定元素相同的父级元素对象
        /// </summary>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        /// <returns></returns>
        public static XTextContainerElement GetSameParent(this XTextElement element1, XTextElement element2)
        {
            if (element1 == null) throw new ArgumentNullException("element1");
            if (element2 == null) throw new ArgumentNullException("element2");
            if (element1.Parent == element2.Parent) return element1.Parent;
            for (XTextElement xTextElement = element1; xTextElement != null; xTextElement = xTextElement.Parent)
            {
                for (XTextElement xTextElement2 = element2; xTextElement2 != null; xTextElement2 = xTextElement2.Parent)
                {
                    if (xTextElement == xTextElement2)
                        return (xTextElement as XTextContainerElement);
                }
            }
            return null;
        }
        /// <summary>
        /// 判断元素是否在标题行内
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsInHeaderRow(this XTextElement element)
        {
            for (XTextElement xTextElement = element; xTextElement != null; xTextElement = xTextElement.Parent)
            {
                if (xTextElement is XTextTableRowElement)
                {
                    XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextElement;
                    if (xTextTableRowElement.HeaderStyle)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 判断元素是否为指定形式的空白符
        /// </summary>
        /// <param name="element"></param>
        /// <param name="whiteSpace">空格符</param>
        /// <param name="tabSpace">制位符</param>
        /// <param name="paragraphFlag">段落符</param>
        /// <param name="pageBreak">分页符</param>
        /// <param name="lineBreak">换行符</param>
        /// <returns></returns>
        public static bool IsRedundant(this XTextElement element, bool whiteSpace, bool tabSpace, bool paragraphFlag, bool pageBreak, bool lineBreak)
        {
            if (element == null) return true;
            if (paragraphFlag && element is XTextParagraphFlagElement) return true;
            if (lineBreak && element is XTextLineBreakElement) return true;
            if (pageBreak && element is XTextPageBreakElement) return true;
            if (element is XTextCharElement)
            {
                char charValue = ((XTextCharElement)element).CharValue;
                if (whiteSpace && (charValue == ' ' || charValue == '\u3000')) return true;
                if (!tabSpace && charValue != '\t') return true;
            }
            return false;
        }


    }
}
