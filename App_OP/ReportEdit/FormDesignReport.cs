using CIS.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIS.Model;
using DCSoft.Writer.Dom;
using DevComponents.DotNetBar;

namespace App_OP
{
    public partial class FormDesignReport : BaseForm
    {
        public FormDesignReport()
        {
            InitializeComponent();
            this.writerControl1.CommandControler = this.writerCommandControler1;
            this.writerCommandControler1.Start();
        }

        public string XMLID { get; set; }

        private void Init()
        {
            string xml = DBHelper.CIS.From<OP_Dic_Report>().Where(p => p.ID == XMLID).Select(p => p.XML).ToScalar<string>();
            if (xml == null || xml == "")
                return;
            this.writerControl1.XMLText = xml;
        }

        private void InitUI()
        {
            List<OP_Dic_ReportDataSource> list = DBHelper.CIS.From<OP_Dic_ReportDataSource>().OrderBy(p => p.Index).ToList();
            list.ForEach(p =>
            {
                ButtonItem item = new ButtonItem(p.ElementCode, p.ElementName);
                item.Click += button_Click;
                this.buttonItem9.SubItems.Add(item);
            });
        }
        private void FormDesignReport_Shown(object sender, EventArgs e)
        {
            Init();
            InitUI();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string xml = this.writerControl1.XMLTextUnFormatted;
            DBHelper.CIS.Update<OP_Dic_Report>(new Dictionary<Dos.ORM.Field, object> { { OP_Dic_Report._.XML, xml } }, p => p.ID == XMLID);
            AlertBox.Info("保存成功");
        }

        private void button_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement input = new XTextInputFieldElement();
            input.ID = (sender as ButtonItem).Name;
            input.Deleteable = false;
            writerControl1.ExecuteCommand("InsertInputField", false, input);
        }

        private void writerControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.contextMenuStrip1.Show(MousePosition);
        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.writerControl1.ExecuteCommand("ElementProperties", false, null);
        }
    }
}
