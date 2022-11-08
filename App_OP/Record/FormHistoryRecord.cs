using CIS.Core;
using CIS.Core.EventBroker;
using System;
using System.Windows.Forms;

namespace App_OP.Record
{
    public partial class FormHistoryRecord : BaseForm
    {
        private FormMain formMain;
        public FormHistoryRecord(FormMain _formMain)
        {
            InitializeComponent();
            formMain = _formMain;
        }

        public void InitDocument(string XML)
        {
            this.txWriterControl1.XMLText = XML;
        }

        private void FormHistoryRecord_Shown(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand(DCSoft.Writer.StandardCommandNames.FilePrintPreview, true, null);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.ImportXMLToRecode, Data = this.txWriterControl1.XMLText });
        }
    }
}
