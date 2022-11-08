using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 体温单打印组件
    /// </summary>
	public class TemperaturePrintDocument : PrintDocument
	{
		private TemperatureDocument _Document = null;
		private int _PageIndex = 0;
        private int _SpecifyPageIndex = -1;
		[DefaultValue(-1)]
		public int SpecifyPageIndex
		{
			get
			{
                return this._SpecifyPageIndex;
			}
			set
			{
                this._SpecifyPageIndex = value;
			}
		}
		public TemperaturePrintDocument(TemperatureDocument document)
		{
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			this._Document = document;
		}
		protected override void OnBeginPrint(PrintEventArgs printEventArgs_0)
		{
			this._PageIndex = 0;
			this._Document.UpdateNumOfPage();
			base.OnBeginPrint(printEventArgs_0);
		}
		protected override void OnPrintPage(PrintPageEventArgs printPageEventArgs)
		{
			base.OnPrintPage(printPageEventArgs);
            if (this._SpecifyPageIndex >= 0)
			{
                this._PageIndex = this._SpecifyPageIndex;
			}
			int pageIndex = this._Document.PageIndex;
			this._Document.PageIndex = this._PageIndex;
			printPageEventArgs.Graphics.PageUnit = GraphicsUnit.Document;
			RectangleF bounds = this._Document.Bounds;
			this._Document.Left = (float)(printPageEventArgs.PageSettings.Margins.Left * 3);
			this._Document.Top = (float)(printPageEventArgs.PageSettings.Margins.Top * 3);
			this._Document.Width = (float)(printPageEventArgs.PageSettings.Bounds.Width * 3) - this._Document.Left - (float)(printPageEventArgs.PageSettings.Margins.Right * 3);
			this._Document.Height = (float)(printPageEventArgs.PageSettings.Bounds.Height * 3) - this._Document.Top - (float)(printPageEventArgs.PageSettings.Margins.Bottom * 3);
			this._Document.ViewMode = DocumentViewMode.Page;
			try
			{
				this._Document.Draw(printPageEventArgs.Graphics, new RectangleF(0f, 0f, 10000f, 10000f));
			}
			finally
			{
				this._Document.Bounds = bounds;
				this._Document.PageIndex = pageIndex;
			}
			this._PageIndex++;
            if (this._SpecifyPageIndex >= 0 || this._PageIndex >= this._Document.NumOfPages)
			{
				printPageEventArgs.HasMorePages = false;
			}
			else
			{
				printPageEventArgs.HasMorePages = true;
			}
		}
	}
}
