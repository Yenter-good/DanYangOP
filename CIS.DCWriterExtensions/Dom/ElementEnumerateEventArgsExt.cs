using DCSoft.Writer.Dom;
using System;

namespace CIS.DCWriter.Dom
{
    /// <summary>
    /// 遍历元素事件参数
    /// </summary>
    public class ElementEnumerateEventArgsExt:EventArgs
    {
        private bool _ReverseMode = false;
        private object _Parameter = null;
        internal bool _Cancel = false;
        internal bool _CancelChild = false;
        internal XTextContainerElement _Parent = null;
        internal XTextElement _Element = null;
        internal bool _ExcludeCharElement = false;
        internal bool _ExcludeParagraphFlag = false;
        private int _HandlerCount = 0;
        public bool ReverseMode
        {
            get
            {
                return this._ReverseMode;
            }
            set
            {
                this._ReverseMode = value;
            }
        }
        public object Parameter
        {
            get
            {
                return this._Parameter;
            }
            set
            {
                this._Parameter = value;
            }
        }
        public bool Cancel
        {
            get
            {
                return this._Cancel;
            }
            set
            {
                this._Cancel = value;
            }
        }
        public bool CancelChild
        {
            get
            {
                return this._CancelChild;
            }
            set
            {
                this._CancelChild = value;
            }
        }
        public XTextContainerElement Parent
        {
            get
            {
                return this._Parent;
            }
        }
        public XTextElement Element
        {
            get
            {
                return this._Element;
            }
        }
        public bool ExcludeCharElement
        {
            get
            {
                return this._ExcludeCharElement;
            }
            set
            {
                this._ExcludeCharElement = value;
            }
        }
        public bool ExcludeParagraphFlag
        {
            get
            {
                return this._ExcludeParagraphFlag;
            }
            set
            {
                this._ExcludeParagraphFlag = value;
            }
        }
        public int HandlerCount
        {
            get
            {
                return this._HandlerCount;
            }
        }
        internal void IncreaseHandlerCount()
        {
            this._HandlerCount++;
        }
    }
}
