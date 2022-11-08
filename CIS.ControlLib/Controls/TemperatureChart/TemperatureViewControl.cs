
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 体温单视图控件
    /// </summary>
    public class TemperatureViewControl : UserControl
    {
        private bool _ShowCrossLine = false;
        private bool _ShowTooltip = true;
        private DocumentViewMode _ViewMode = DocumentViewMode.Page;
        private int _CurrentPageIndex = 0;
        private TemperatureDocument _Document = null;
        private PageSettings _PageSettings = new PageSettings();
        private Color _PageBackColor = Color.White;
        private bool _AutoHeightWhenWidelyViewMode = true;
        private RectangleF _PageBounds = Rectangle.Empty;
        private Point _LastPoint = Point.Empty;
        private Point _CrossLinePoint = Point.Empty;
        private ToolTip _Tooltip = null;
        private bool _AllowDragValuePoint = false;
        private bool _IsDragging = false;
        private object _DragObject = null;


        private RectangleF _ValuePointEnterViewRect = RectangleF.Empty;
        private Point _ToolTipXY = Point.Empty;
        private YAxisInfo _ToolTipRule = null;
        private ViewParts? _EnterPart = null;

        private readonly object viewMouseEnterObject = new object();
        private readonly object viewMouseDownObject = new object();
        private readonly object viewMouseDoubleClickObject = new object();
        private readonly object viewMouseUpObject = new object();
        private readonly object viewDragDropObject = new object();
        public event EventHandler<ViewEventArgs> ViewMouseEnter
        {
            add { base.Events.AddHandler(viewMouseEnterObject, value); }
            remove { base.Events.RemoveHandler(viewMouseEnterObject, value); }
        }
        public event EventHandler<ViewMouseEventArgs> ViewClick
        {
            add { base.Events.AddHandler(viewMouseDownObject, value); }
            remove { base.Events.RemoveHandler(viewMouseDownObject, value); }
        }
        public event EventHandler<ViewMouseEventArgs> ViewDoubleClick
        {
            add { base.Events.AddHandler(viewMouseDoubleClickObject, value); }
            remove { base.Events.RemoveHandler(viewMouseDoubleClickObject, value); }
        }
        public event EventHandler<ViewMouseEventArgs> ViewUp
        {
            add { base.Events.AddHandler(viewMouseUpObject, value); }
            remove { base.Events.RemoveHandler(viewMouseUpObject, value); }
        }
        public event EventHandler<ViewDragEventArgs> ViewDragDrop
        {
            add { base.Events.AddHandler(viewDragDropObject, value); }
            remove { base.Events.RemoveHandler(viewDragDropObject, value); }
        }

        public TemperatureViewControl()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer
                    | ControlStyles.AllPaintingInWmPaint, true);
        }
        [Category("Behavior"), DefaultValue(false)]
        public bool AllowDragValuePoint
        {
            get { return this._AllowDragValuePoint; }
            set { this._AllowDragValuePoint = value; }
        }
        [Category("Behavior"), DefaultValue(false)]
        public bool ShowCrossLine
        {
            get
            {
                return this._ShowCrossLine;
            }
            set
            {
                if (this._ShowCrossLine != value)
                {
                    this._ShowCrossLine = value;
                    if (base.IsHandleCreated)
                    {
                        base.Invalidate();
                    }
                }
            }
        }
        [Category("Behavior"), DefaultValue(true)]
        public bool ShowTooltip
        {
            get
            {
                return this._ShowTooltip;
            }
            set
            {
                this._ShowTooltip = value;
            }
        }
        [Category("Layout"), DefaultValue(DocumentViewMode.Page)]
        public DocumentViewMode ViewMode
        {
            get
            {
                return this._ViewMode;
            }
            set
            {
                if (this._ViewMode != value)
                {
                    this.DrawCrossLine();
                    this._CrossLinePoint = Point.Empty;
                    this._ViewMode = value;
                    if (base.IsHandleCreated)
                    {
                        this.RefreshViewWithoutRefreshDataSource();
                    }
                }
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentPageIndex
        {
            get
            {
                return this.Document.PageIndex;
            }
            set
            {
                this.Document.PageIndex = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TemperatureDocument Document
        {
            get
            {
                if (this._Document == null)
                {
                    this._Document = new TemperatureDocument();
                }
                return this._Document;
            }
            set
            {
                this._Document = value;
                if (!string.IsNullOrEmpty(this.Document.ConfigXml))
                {
                    TemperatureDocumentConfig temperatureDocumentConfig = TemperatureDocumentConfig.LoadXML(this._Document.ConfigXml);
                    if (this._PageSettings == null)
                    {
                        this._PageSettings = new PageSettings();
                    }
                    if (temperatureDocumentConfig.PageSettings != null)
                    {
                        temperatureDocumentConfig.PageSettings.WriteTo(this._PageSettings);
                    }
                }
                if (base.IsHandleCreated)
                {
                    this.UpdateViewSize();
                }
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PageSettings PageSettings
        {
            get
            {
                return this._PageSettings;
            }
            set
            {
                this._PageSettings = value;
                if (!base.DesignMode)
                {
                    this.UpdateViewSize();
                }
            }
        }
        [Category("Appearance"), DefaultValue(typeof(Color), "White")]
        public Color PageBackColor
        {
            get
            {
                return this._PageBackColor;
            }
            set
            {
                this._PageBackColor = value;
            }
        }
        [Category("Layout"), DefaultValue(true)]
        public bool AutoHeightWhenWidelyViewMode
        {
            get
            {
                return this._AutoHeightWhenWidelyViewMode;
            }
            set
            {
                if (this._AutoHeightWhenWidelyViewMode != value)
                {
                    this._AutoHeightWhenWidelyViewMode = value;
                    if (base.IsHandleCreated)
                    {
                        this.RefreshViewWithoutRefreshDataSource();
                    }
                }
            }
        }
        private bool IsDesignMode
        {
            get
            {
                bool result;
                if (base.DesignMode)
                {
                    result = true;
                }
                else
                {
                    for (Control parent = base.Parent; parent != null; parent = parent.Parent)
                    {
                        if (parent.Site != null && parent.Site.DesignMode)
                        {
                            result = true;
                            return result;
                        }
                    }
                    result = false;
                }
                return result;
            }
        }
        protected override void OnLoad(EventArgs eventArgs)
        {
            base.OnLoad(eventArgs);
            if (!base.DesignMode)
            {
                this.UpdateState();
                this.UpdateViewSize();
            }
        }
        protected override void OnResize(EventArgs eventArgs)
        {
            base.OnResize(eventArgs);
            if (!base.DesignMode)
            {
                base.Invalidate();
                this.UpdateViewSize();
            }
        }
        public void RefreshView()
        {
            this.Document.RefreshDataSource();
            this.UpdateState();
            this.UpdateViewSize();
            this._CrossLinePoint = Point.Empty;
            base.Invalidate();
        }
        public void RefreshViewWithoutRefreshDataSource()
        {
            this.UpdateState();
            this.UpdateViewSize();
            this._CrossLinePoint = Point.Empty;
            base.Invalidate();
        }
        public void UpdateState()
        {
            if (this.Document != null)
            {
                this.Document.UpdateNumOfPage();
            }
        }
        private void UpdateViewSize()
        {
            if (base.IsHandleCreated && this.Document != null && !base.DesignMode)
            {
                if (this.ViewMode .HasFlag( DocumentViewMode.Page))
                {
                    using (Graphics graphics = base.CreateGraphics())
                    {
                        this._PageBounds = this._Document.SetBoundsCore(graphics, this.PageSettings);
                    }
                    this._PageBounds.Offset(10f, 10f);
                    if (this._PageBounds.Width + 20f < (float)base.ClientSize.Width)
                    {
                        this._PageBounds.X = 10f + ((float)base.ClientSize.Width - this._PageBounds.Width) / 2f;
                    }
                    this._Document.Left += this._PageBounds.Left;
                    this._Document.Top += this._PageBounds.Top;
                    Size size = new Size((int)this._PageBounds.Right + 10, (int)this._PageBounds.Bottom + 10);
                    if (base.AutoScrollMinSize != size)
                    {
                        base.AutoScrollMinSize = size;
                    }
                }
                else
                {
                    if (this.ViewMode .HasFlag( DocumentViewMode.Normal))
                    {
                        base.AutoScrollMinSize = new Size(1, 1);
                        this._Document.Left = 0f;
                        this._Document.Top = 0f;
                        this._Document.Width = (float)base.ClientSize.Width;
                        this._Document.Height = (float)base.ClientSize.Height;
                    }
                    else
                    {
                        if (this.ViewMode .HasFlag( DocumentViewMode.Widely))
                        {
                            this.Document.UpdateNumOfPage();
                            int days = this.Document.Days;
                            int tickTotalCount = this._Document.Ticks.Count * days;
                            float ruleTotalWidth = 0f;
                            float totalHeight = 0f;
                            using (Graphics graphics = base.CreateGraphics())
                            {
                                float width = graphics.MeasureString("HHHH", this.Font).Width;
                                foreach (YAxisInfo current in this.Document.YAxisInfos)
                                {
                                    if (!current.TextFlagMode)
                                    {
                                        float ruleWidth = width;
                                        if (!string.IsNullOrEmpty(current.Title))
                                        {
                                            ruleWidth = graphics.MeasureString(current.Title, this.Font).Width;
                                        }
                                        ruleWidth = Math.Max(ruleWidth, width);
                                        ruleTotalWidth += ruleWidth;
                                    }
                                }
                                float tickWidth = graphics.MeasureString("HH", this.Font).Width;
                                ruleTotalWidth += tickWidth * (float)tickTotalCount;
                                ruleTotalWidth *= 1.1f;
                                float lineHeight = this.Font.GetHeight(graphics) * 1.1f;
                                totalHeight = lineHeight * (float)(this.Document.HeaderLines.Count + this.Document.FooterLines.Count);
                                totalHeight += 500f;
                            }
                            this._Document.Left = 10f;
                            this._Document.Width = (float)((int)ruleTotalWidth);
                            this._Document.Height = (float)((int)totalHeight);
                            this._Document.Top = ((float)base.ClientSize.Height - this._Document.Height) / 2f;
                            if (this._Document.Top < 0f)
                            {
                                this._Document.Top = 10f;
                            }
                            Size size = new Size((int)this._Document.Right + 10, (int)this._Document.Bottom + 10);
                            if (this.AutoHeightWhenWidelyViewMode)
                            {
                                this._Document.Left = 0f;
                                this._Document.Top = 0f;
                                this._Document.Height = (float)(base.ClientSize.Height - 1);
                                size = new Size((int)this._Document.Right + 1, base.ClientSize.Height);
                            }
                            if (base.AutoScrollMinSize != size)
                            {
                                base.AutoScrollMinSize = size;
                            }
                        }
                    }
                }
            }
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (this.IsDesignMode)
            {
                using (StringFormat stringFormat = new StringFormat())
                {
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    pevent.Graphics.DrawString("体温单控件", this.Font, Brushes.Black, new RectangleF(0f, 0f, (float)base.ClientSize.Width, (float)base.ClientSize.Height), stringFormat);
                    return;
                }
            }
            this.DrawCrossLine();
            if (this.Document != null)
            {
                //重置画布位置
                pevent.Graphics.TranslateTransform((float)base.AutoScrollPosition.X, (float)base.AutoScrollPosition.Y);
                RectangleF rectangleF = pevent.ClipRectangle;
                rectangleF.Offset((float)(-(float)base.AutoScrollPosition.X), (float)(-(float)base.AutoScrollPosition.Y));
                this.Document.ViewMode = this.ViewMode;
                if (this.ViewMode .HasFlag( DocumentViewMode.Page))
                {
                    RectangleF rect = RectangleF.Intersect(this._PageBounds, rectangleF);
                    if (rect.IsEmpty)
                    {
                        return;
                    }
                    using (SolidBrush solidBrush = new SolidBrush(this.PageBackColor))
                    {
                        pevent.Graphics.FillRectangle(solidBrush, rect);
                    }
                    //绘制边框
                    pevent.Graphics.DrawRectangle(Pens.Black, this._PageBounds.Left, this._PageBounds.Top, this._PageBounds.Width, this._PageBounds.Height);
                    if (rectangleF.IntersectsWith(this._Document.Bounds))
                    {
                        this.Document.Font = this.Font;
                        this.Document.PageIndex = this.CurrentPageIndex;
                        //绘制体温单
                        this.Document.Draw(pevent.Graphics, rectangleF);
                    }
                }
                else
                {
                    if (rectangleF.IntersectsWith(this.Document.Bounds))
                    {
                        using (SolidBrush solidBrush = new SolidBrush(this.PageBackColor))
                        {
                            pevent.Graphics.FillRectangle(solidBrush, rectangleF);
                        }
                        this.Document.Font = this.Font;
                        this.Document.PageIndex = this.CurrentPageIndex;
                        //绘制体温单
                        this.Document.Draw(pevent.Graphics, rectangleF);
                    }
                }
            }
            this.DrawCrossLine();
        }
        /// <summary>
        /// 打印文档
        /// </summary>
        /// <param name="specifyPageIndex"></param>
        public void PrintDocument(int specifyPageIndex)
        {
            this.PrintDocument(specifyPageIndex, this.Document);
        }
        /// <summary>
        /// 打印黑白文档
        /// </summary>
        /// <param name="specifyPageIndex"></param>
        public void PrintBlackAndWhiteDocument(int specifyPageIndex)
        {
           this.PrintDocument(specifyPageIndex, GetBWDocument(this.Document));
        }
        /// <summary>
        /// 获取黑白文档对象
        /// </summary>
        /// <param name="td"></param>
        /// <returns></returns>
        public static TemperatureDocument GetBWDocument(TemperatureDocument td)
        {
            var document = td.Clone();
            document.BorderColor = GetBlackWhiteColor(document.BorderColor);
            document.BigSplitLineColor = GetBlackWhiteColor(document.BigSplitLineColor);
            document.GridHorizontalSplitLineColor = GetBlackWhiteColor(document.GridHorizontalSplitLineColor);
            document.GridLineColor = GetBlackWhiteColor(document.GridLineColor);
            document.GridVerticalSplitLineColor = GetBlackWhiteColor(document.GridVerticalSplitLineColor);
            document.GridVerticalSplitLineColor = GetBlackWhiteColor(document.GridVerticalSplitLineColor);
            document.ForeColor =GetBlackWhiteColor(document.ForeColor);
            foreach (var item in document.Ticks)
            {
                item.ForeColor = GetBlackWhiteColor(item.ForeColor);
            }
            foreach (var item in document.HeaderLines)
            {
                item.TextColor = GetBlackWhiteColor(item.TextColor);
                item.TitleForeColor = GetBlackWhiteColor(item.TitleForeColor);
            }
            foreach (var item in document.FooterLines)
            {
                item.TextColor = GetBlackWhiteColor(item.TextColor);
                item.TitleForeColor = GetBlackWhiteColor(item.TitleForeColor);                
            }
            foreach (var item in document.HeaderLabels)
            {
                item.ForeColor=GetBlackWhiteColor(item.ForeColor);
            }
            foreach (var item in document.YAxisInfos)
            {
                item.SymbolColor = GetBlackWhiteColor(item.SymbolColor);
            }
            return document;
        }
        /// <summary>
        /// 获取黑白色
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private static Color GetBlackWhiteColor(Color color)
        {
            if (color.A == 0 || color==Color.Empty || color==Color.Transparent)
                return color;
            if (color == Color.White)
                return color;
            return Color.Black;
        }

        private void PrintDocument(int specifyPageIndex,TemperatureDocument document)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.AllowCurrentPage = false;
                printDialog.AllowSelection = false;
                printDialog.AllowSomePages = false;
                if (printDialog.ShowDialog(this) == DialogResult.OK)
                {
                    using (TemperaturePrintDocument temperaturePrintDocument = new TemperaturePrintDocument(document))
                    {
                        if (specifyPageIndex >= 0)
                        {
                            temperaturePrintDocument.SpecifyPageIndex = specifyPageIndex;
                        }
                        temperaturePrintDocument.PrinterSettings = printDialog.PrinterSettings;
                        temperaturePrintDocument.DefaultPageSettings = this.PageSettings;
                        temperaturePrintDocument.Print();
                    }
                }
            }
        }
        

        public void LoadDocument(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            TemperatureDocument temperatureDocument = new TemperatureDocument();
            if (temperatureDocument.Load(stream))
            {
                this.Document = temperatureDocument;
                if (base.IsHandleCreated)
                {
                    this.UpdateState();
                    base.Invalidate();
                }
            }
        }
        public void SaveDocument(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (this.Document != null)
            {
                this.Document.Save(stream);
            }
        }
        private void DrawCrossLine()
        {
            if (this.ShowCrossLine && !this._CrossLinePoint.IsEmpty)
            {
                SimpleReversibleDrawer.DrawReversibleLine(base.Handle, 0, this._CrossLinePoint.Y, base.ClientSize.Width, this._CrossLinePoint.Y);
                SimpleReversibleDrawer.DrawReversibleLine(base.Handle, this._CrossLinePoint.X, 0, this._CrossLinePoint.X, base.ClientSize.Height);
            }
        }
        /// <summary>
        /// 设置提示信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        private void SetToolTip(string title, string message)
        {
            if (this._Tooltip == null)
            {
                this._Tooltip = new ToolTip();
            }
            this._Tooltip.ToolTipTitle = title;

            if (this._Tooltip.Active)
            {
                Point point = this.PointToClient(Cursor.Position);
                //RectangleF pointRect = new RectangleF(_ToolTipXY.X - 0.1f, _ToolTipXY.Y - 0.1f, 0.2f, 0.2f);
                if (!_ToolTipXY.IsEmpty && _ToolTipXY.Equals(point) && this._Tooltip.GetToolTip(this) == message)
                    return;
                _ToolTipXY = point;
            }
            this._Tooltip.SetToolTip(this, message);
        }
        /// <summary>
        /// 设置指定的数据标尺显示鼠标所在坐标的信息
        /// </summary>
        /// <param name="ruleValueFieldName"></param>
        public void SetRuleViewXYInfoVisible(string ruleValueFieldName)
        {
            if (string.IsNullOrEmpty(ruleValueFieldName))
            {
                this._ToolTipRule = null;
                this.SetToolTip(null, null);
                return;
            }
            if (this.Document.YAxisInfos.Exists(y => y.ValueFieldName == ruleValueFieldName))
                this._ToolTipRule = this.Document.YAxisInfos.Find(y => y.ValueFieldName == ruleValueFieldName);
            else
            {
                this._ToolTipRule = null;
                this.SetToolTip(null, null);                
            }
        }
   
        protected virtual void OnViewEnter(ViewEventArgs mevent)
        {
            if (base.Events[viewMouseEnterObject] != null)
            {
                base.Events[viewMouseEnterObject].DynamicInvoke(new object[] {this, mevent });
            }
        }
        protected virtual void OnViewClick(ViewMouseEventArgs mevent)
        {
            switch (mevent.Part)
            {
                case ViewParts.Grid:
                    if (this.AllowDragValuePoint && mevent.Object != null && mevent.Object is System.Collections.Generic.KeyValuePair<YAxisInfo, ValuePoint>)
                    {
                        var keyValue = (System.Collections.Generic.KeyValuePair<YAxisInfo, ValuePoint>)mevent.Object;
                        this._DragObject = keyValue;
                        this._IsDragging = true;
                        this.Cursor = Cursors.Hand;
                        if (keyValue.Key.TextFlagMode)
                        {
                            Point screenPoint = this.PointToScreen(new Point((int)Math.Ceiling(this.Document.GridRectangle.Left) + base.AutoScrollPosition.X, (int)Math.Ceiling(mevent.ViewY) + base.AutoScrollPosition.Y));
                            Cursor.Clip = new Rectangle(screenPoint.X, screenPoint.Y, (int)Math.Floor(this.Document.GridRectangle.Width), 1);
                        }
                        else
                        {
                            Point screenPoint = this.PointToScreen(new Point((int)mevent.ViewX + base.AutoScrollPosition.X, (int)Math.Ceiling(this.Document.GridRectangle.Top) + base.AutoScrollPosition.Y));
                            Cursor.Clip = new Rectangle(screenPoint.X, screenPoint.Y, 1, (int)Math.Floor(this.Document.GridRectangle.Height));
                        }
                        this.SetRuleViewXYInfoVisible(keyValue.Key.ValueFieldName);
                    }
                    break;
                case ViewParts.Rule:
                    var rule = mevent.Object as YAxisInfo;
                    if (rule.Visible && rule.ClickVisible)
                    {
                        rule.ValueVisible = !rule.ValueVisible;

                        this.Invalidate(new Rectangle((int)Math.Floor(rule.Left) + base.AutoScrollPosition.X
                            , (int)Math.Floor(rule.Top) + base.AutoScrollPosition.Y
                            , (int)Math.Ceiling(this.Document.Right - rule.Left)
                            , (int)Math.Ceiling(rule.Height) + 1));
                        return;
                    }
                    
                    break;
                case ViewParts.LineHeader:
                    break;
                case ViewParts.Header:
                    break;
                case ViewParts.UnKnow:
                    break;
                default:
                    break;
            }
            if (base.Events[viewMouseDownObject] != null)
            {
                base.Events[viewMouseDownObject].DynamicInvoke(new object[] { this,mevent});
            }
        }
        protected virtual void OnViewDoubleClick(ViewMouseEventArgs mevent)
        {
            if (base.Events[viewMouseDoubleClickObject] != null)
            {
                base.Events[viewMouseDoubleClickObject].DynamicInvoke(new object[] { this,mevent});
            }
        }
        protected virtual void OnViewMove(ViewMouseEventArgs mevent)
        {
            if (!this._ValuePointEnterViewRect.IsEmpty)
            {
                if (!this._ValuePointEnterViewRect.Contains(mevent.ViewX, mevent.ViewY))
                {
                    this._ValuePointEnterViewRect = RectangleF.Empty;
                }
            }
           
            switch (mevent.Part)
            {
                case ViewParts.Grid:
                    #region Grid...
                    //防止重复激发OnValuePointEnter
                    if (_ValuePointEnterViewRect.IsEmpty || !_ValuePointEnterViewRect.Contains(mevent.ViewX, mevent.ViewY))
                    {
                        foreach (YAxisInfo rule in this.Document.YAxisInfos)
                        {
                            if (!rule.ValueVisible)
                                continue;
                            foreach (ValuePoint valuePoint in rule.Values)
                            {
                                if (valuePoint.GetBound().Contains(mevent.ViewX, mevent.ViewY))
                                {
                                    #region 正常模式下数据点的提示

                                    if (this.ShowTooltip && this._ToolTipRule == null)
                                    {
                                        string caption = null;
                                        if (rule.TextFlagMode)
                                        {
                                            caption = string.Concat(
                                                new object[] { valuePoint.Time.ToString("yyyy-MM-dd HH:mm tt") 
                                            ," "
                                            ,valuePoint.Text}
                                                );
                                        }
                                        else
                                        {
                                            caption = string.Concat(new object[]
                                    {
                                        valuePoint.Time.ToString("yyyy-MM-dd HH:mm tt"),
                                        " ",
                                        rule.Title,
                                        " ",
                                        valuePoint.Value
                                    });
                                        }
                                        this.SetToolTip("提示", caption);
                                    }
                                    #endregion
                                    this._ValuePointEnterViewRect = valuePoint.GetBound();
                                    this.OnValuePointEnter(rule, valuePoint);
                                    break;
                                }
                            }
                        }
                    }
                    if (this._ToolTipRule != null)
                    {
                        DateTime time;
                        string text = null;
                        if (this._IsDragging && this._DragObject != null && this._DragObject is KeyValuePair<YAxisInfo, ValuePoint>)
                        {
                            var keyValue = ((KeyValuePair<YAxisInfo, ValuePoint>)this._DragObject);
                            time = keyValue.Value.Time;
                            if (keyValue.Key.TextFlagMode)
                            {
                                time = this.Document.GetTimeByX(mevent.ViewX);
                                text = keyValue.Value.Text;
                            }
                        }
                        else
                        {
                            time = this.Document.GetTimeByX(mevent.ViewX);
                        }
                        string message = null;
                        if (this._ToolTipRule.TextFlagMode)
                        {
                            message = string.Concat(new object[]{
                            "时间："
                            ,time 
                            ," "
                            ,text
                        });
                        }
                        else
                        {
                            message = string.Concat(new object[]{
                            "时间："
                            ,time
                            ,Environment.NewLine
                            ,"数值："
                            ,this.Document.GetValueByY(this._ToolTipRule,mevent.ViewY)
                        });
                        }
                        this.SetToolTip(this._ToolTipRule.Title, message);
                    }
                                        
                    #endregion
                    break;
                case ViewParts.Rule:
                    this.SetToolTip(null, null);
                    break;
                case ViewParts.LineHeader:
                    this.SetToolTip(null, null);
                    break;
                case ViewParts.Header:
                    this.SetToolTip(null, null);
                    break;
                case ViewParts.UnKnow:
                    this.SetToolTip(null, null);
                    break;
                default:
                    break;
            }
        }
        protected virtual void OnViewUp(ViewMouseEventArgs mevent)
        {
            switch (mevent.Part)
            {
                case ViewParts.Grid:
                    if (this.AllowDragValuePoint && this._IsDragging)
                    {
                        this._IsDragging = false;
                        Cursor.Clip = Screen.AllScreens[0].Bounds;
                        this.Cursor = Cursors.Default;
                        this.SetRuleViewXYInfoVisible(null);
                        var dragObj = (System.Collections.Generic.KeyValuePair<YAxisInfo, ValuePoint>)this._DragObject;
                        var point = new ValuePoint();
                        if (dragObj.Key.TextFlagMode)
                        {
                            point.Text = dragObj.Value.Text;
                            point.Time = this.Document.GetTimeByX(mevent.ViewX);
                        }
                        else
                        {
                            point.Time = dragObj.Value.Time ;
                            point.Value = this.Document.GetValueByY(dragObj.Key, mevent.ViewY);
                            point.Token = dragObj.Value.Token;
                            point.CutOff = dragObj.Value.CutOff;
                        }
                        this.OnViewDragDrop(new ViewDragEventArgs(ViewDragType.Point,this._DragObject, new System.Collections.Generic.KeyValuePair<YAxisInfo, ValuePoint>(dragObj.Key, point)));
                        this._DragObject = null;
                    }
                    break;
                case ViewParts.Rule:
                    break;
                case ViewParts.LineHeader:
                    break;
                case ViewParts.Header:
                    break;
                case ViewParts.UnKnow:
                    break;
                default:
                    break;
            }
            if (base.Events[viewMouseUpObject] != null)
            {
                base.Events[viewMouseUpObject].DynamicInvoke(new object[] {this,mevent });
            }
        }
        protected virtual void OnViewDragDrop(ViewDragEventArgs devent)
        {
            if (base.Events[viewDragDropObject] != null)
            {
                base.Events[viewDragDropObject].DynamicInvoke(new object[] { this,devent});
            }
        }
        protected virtual void OnValuePointEnter(YAxisInfo rule,ValuePoint point)
        {
            
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            this.DrawCrossLine();
            this._CrossLinePoint = Point.Empty;
            if (mevent.Button == MouseButtons.Left)
            {
                this._LastPoint = new Point(mevent.X, mevent.Y);


                float viewX =mevent.X-base.AutoScrollPosition.X;
                float viewY=mevent.Y -base.AutoScrollPosition.Y;
                foreach (var headerLabel in this.Document.HeaderLabels)
                {
                    if (headerLabel.GetBound().Contains(viewX, viewY))
                    {
                        this.OnViewClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.Header, headerLabel)); 
                        return;
                    }
                }
                 foreach (var line in this.Document.HeaderLines)
                {
                    if (line.GetBound().Contains(viewX, viewY))
                    {
                        if(line.GetTitleBound().Contains(viewX,viewY))
                            this.OnViewClick(new ViewMouseEventArgs(mevent.Button,mevent.Clicks,viewX,viewY,mevent.Delta, ViewParts.LineHeader,line)); 
                        else
                            this.OnViewClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineContent, line));
                        return;
                    }
                }
                 foreach (var rule in this.Document.Rules)
                 {
                     if (!rule.Visible)
                         continue;
                     if (rule.GetBound().Contains(viewX, viewY))
                     {
                         this.OnViewClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.Rule, rule));
                         return;
                     }
                 }
                 if (this.Document.GridRectangle.Contains(viewX, viewY))
                 {
                     YAxisInfo rule =null;
                     ValuePoint vp = this.Document.GetValuePointByXY(viewX, viewY, out rule);
                     object obj = null;
                     if (rule != null && vp != null)
                         obj = new System.Collections.Generic.KeyValuePair<YAxisInfo, ValuePoint>(rule, vp);
                     this.OnViewClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.Grid, obj));
                     return;
                 }
                foreach (var line in this.Document.FooterLines)
                {
                    if (line.GetBound().Contains(viewX, viewY))
                    {
                        if (line.GetTitleBound().Contains(viewX, viewY))
                            this.OnViewClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineHeader, line));
                        else
                            this.OnViewClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineContent, line));
                        return;
                    }
                }

                this.OnViewClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.UnKnow, null));
            }
        }
        protected override void OnMouseDoubleClick(MouseEventArgs mevent)
        {
            base.OnMouseDoubleClick(mevent);
            if (mevent.Button == MouseButtons.Left)
            {

                float viewX = mevent.X - base.AutoScrollPosition.X;
                float viewY = mevent.Y - base.AutoScrollPosition.Y;
                foreach (var headerLabel in this.Document.HeaderLabels)
                {
                    if (headerLabel.GetBound().Contains(viewX, viewY))
                    {
                        this.OnViewDoubleClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.Header, headerLabel));
                        return;
                    }
                }
                foreach (var line in this.Document.HeaderLines)
                {
                    if (line.GetBound().Contains(viewX, viewY))
                    {
                        if (line.GetTitleBound().Contains(viewX, viewY))
                            this.OnViewDoubleClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineHeader, line));
                        else
                            this.OnViewDoubleClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineContent, line));
                        return;
                    }
                }
                foreach (var rule in this.Document.Rules)
                {
                    if (!rule.Visible)
                        continue;
                    if (rule.GetBound().Contains(viewX, viewY))
                    {
                        this.OnViewDoubleClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.Rule, rule));
                        return;
                    }
                }
                if (this.Document.GridRectangle.Contains(viewX, viewY))
                {
                    YAxisInfo rule = null;
                    ValuePoint vp = this.Document.GetValuePointByXY(viewX, viewY, out rule);
                    object obj = null;
                    if (rule != null && vp != null)
                        obj = new System.Collections.Generic.KeyValuePair<YAxisInfo, ValuePoint>(rule, vp);
                    this.OnViewDoubleClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.Grid, obj));
                    return;
                }
                foreach (var line in this.Document.FooterLines)
                {
                    if (line.GetBound().Contains(viewX, viewY))
                    {
                        if (line.GetTitleBound().Contains(viewX, viewY))
                            this.OnViewDoubleClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineHeader, line));
                        else
                            this.OnViewDoubleClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineContent, line));
                        return;
                    }
                }

                this.OnViewDoubleClick(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.UnKnow, null));
            }
        }
        protected override void OnMouseLeave(EventArgs eventArgs)
        {
            base.OnMouseLeave(eventArgs);
            this.DrawCrossLine();
            this._CrossLinePoint = Point.Empty;
        }
        protected override void OnMouseWheel(MouseEventArgs mouseEventArgs)
        {
            base.OnMouseWheel(mouseEventArgs);
            this.DrawCrossLine();
            this._CrossLinePoint = Point.Empty;
        }
        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            base.OnMouseMove(mevent);

            if (mevent.Button == MouseButtons.Left && !this._LastPoint.IsEmpty && !this._IsDragging)
            {
                Point autoScrollPosition = base.AutoScrollPosition;
                autoScrollPosition.Offset(mevent.X - this._LastPoint.X, mevent.Y - this._LastPoint.Y);
                this._LastPoint = new Point(mevent.X, mevent.Y);
                base.AutoScrollPosition = new Point(-autoScrollPosition.X, -autoScrollPosition.Y);
            }
            else
            {
                if (this.ShowCrossLine && mevent.Button == MouseButtons.None && mevent.Delta == 0)
                {
                    this.DrawCrossLine();
                    this._CrossLinePoint = new Point(mevent.X, mevent.Y);
                    this.DrawCrossLine();
                }
                int viewX = mevent.X - base.AutoScrollPosition.X;
                int viewY = mevent.Y - base.AutoScrollPosition.Y;

                foreach (var headerLabel in this.Document.HeaderLabels)
                {
                    if (headerLabel.GetBound().Contains(viewX, viewY))
                    {
                        if (!this._EnterPart.HasValue || this._EnterPart.Value != ViewParts.Header)
                        {
                            this._EnterPart = ViewParts.Header;
                            this.OnViewEnter(new ViewEventArgs(ViewParts.Header,headerLabel)); 
                        }
                        this.OnViewMove(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.Header, headerLabel));
                        return;
                    }
                }
                foreach (var line in this.Document.HeaderLines)
                {
                    if (line.GetBound().Contains(viewX, viewY))
                    {
                        if (line.GetTitleBound().Contains(viewX, viewY))
                        {
                            if (!this._EnterPart.HasValue || this._EnterPart.Value != ViewParts.LineHeader)
                            {
                                this._EnterPart = ViewParts.LineHeader;
                                this.OnViewEnter(new ViewEventArgs(ViewParts.LineHeader, line));
                            }
                            this.OnViewMove(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineHeader, line));
                        }
                        else
                        {
                            if (!this._EnterPart.HasValue || this._EnterPart.Value != ViewParts.LineContent)
                            {
                                this._EnterPart = ViewParts.LineContent;
                                this.OnViewEnter(new ViewEventArgs(ViewParts.LineContent, line));
                            }
                            this.OnViewMove(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineContent, line));
                        }
                      
                        return;
                    }
                }
                foreach (var rule in this.Document.YAxisInfos)
                {
                    if (rule.GetBound().Contains(viewX, viewY))
                    {
                        if (!this._EnterPart.HasValue || this._EnterPart.Value != ViewParts.Rule)
                        {
                            this._EnterPart = ViewParts.Rule;
                            this.OnViewEnter(new ViewEventArgs(ViewParts.Rule,rule));
                        }
                        this.OnViewMove(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.Rule, rule));
                        return;
                    }
                }
                if (this.Document.GridRectangle.Contains(viewX, viewY))
                {
                    if (!this._EnterPart.HasValue || this._EnterPart.Value != ViewParts.Grid)
                    {
                        this._EnterPart = ViewParts.Grid;
                        this.OnViewEnter(new ViewEventArgs(ViewParts.Grid,null));
                    }

                    this.OnViewMove(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta,ViewParts.Grid,null));
                    return;
                }
                foreach (var line in this.Document.FooterLines)
                {
                    if (line.GetBound().Contains(viewX, viewY))
                    {
                        if (line.GetTitleBound().Contains(viewX, viewY))
                        {
                            if (!this._EnterPart.HasValue || this._EnterPart.Value != ViewParts.LineHeader)
                            {
                                this._EnterPart = ViewParts.LineHeader;
                                this.OnViewEnter(new ViewEventArgs(ViewParts.LineHeader, line));
                            }
                            this.OnViewMove(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineHeader, line));
                        }
                        else
                        {
                            if (!this._EnterPart.HasValue || this._EnterPart.Value != ViewParts.LineContent)
                            {
                                this._EnterPart = ViewParts.LineContent;
                                this.OnViewEnter(new ViewEventArgs(ViewParts.LineContent, line));
                            }
                            this.OnViewMove(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineContent, line));
                        } 
                        return;
                    }
                }
                if (!this._EnterPart.HasValue || this._EnterPart.Value != ViewParts.UnKnow)
                {
                    this._EnterPart = ViewParts.UnKnow;
                    this.OnViewEnter(new ViewEventArgs(ViewParts.UnKnow));
                }
                this.OnViewMove(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.UnKnow, null));
                
            }
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            this._LastPoint = Point.Empty;

            float viewX = mevent.X - base.AutoScrollPosition.X;
            float viewY = mevent.Y - base.AutoScrollPosition.Y;
            foreach (var headerLabel in this.Document.HeaderLabels)
            {
                if (headerLabel.GetBound().Contains(viewX, viewY))
                {
                    this.OnViewUp(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.Header, headerLabel));
                    return;
                }
            }
            foreach (var line in this.Document.HeaderLines)
            {
                if (line.GetBound().Contains(viewX, viewY))
                {
                    if (line.GetTitleBound().Contains(viewX, viewY))
                        this.OnViewUp(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineHeader, line));
                    else
                        this.OnViewUp(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineContent, line));
                    return;
                }
            }
            foreach (var rule in this.Document.Rules)
            {
                if (!rule.Visible)
                    continue;
                if (rule.GetBound().Contains(viewX, viewY))
                {
                    this.OnViewUp(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.Rule, rule));
                    return;
                }
            }
            if (this.Document.GridRectangle.Contains(viewX, viewY))
            {
                this.OnViewUp(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.Grid, null));
                return;
            }
            foreach (var line in this.Document.FooterLines)
            {
                if (line.GetBound().Contains(viewX, viewY))
                {
                    if (line.GetTitleBound().Contains(viewX, viewY))
                        this.OnViewUp(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineHeader, line));
                    else
                        this.OnViewUp(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.LineContent, line));
                    return;
                }
            }

            this.OnViewUp(new ViewMouseEventArgs(mevent.Button, mevent.Clicks, viewX, viewY, mevent.Delta, ViewParts.UnKnow, null));
        }
        protected override void Dispose(bool disposing)
        {
            if (this._Tooltip != null)
            {
                this._Tooltip.Dispose();
                this._Tooltip = null;
            }
            base.Dispose(disposing);
        }
    }
}
