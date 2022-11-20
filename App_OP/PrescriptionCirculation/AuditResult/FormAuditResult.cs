using CIS.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App_OP.PrescriptionCirculation.AuditResult
{
    public partial class FormAuditResult : BaseForm
    {
        public FormAuditResult()
        {
            InitializeComponent();
        }

        internal void Init(AuditResultResponse response)
        {
            this.labelX2.Text = response.rxChkTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.textBoxX1.Text = response.rxChkOpnn;
        }
    }
}
