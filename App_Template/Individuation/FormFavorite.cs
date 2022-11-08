using CIS.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CIS.Model;
using DevComponents.AdvTree;

namespace App_Template
{
    public partial class FormFavorite : BaseForm
    {
        public FormFavorite()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.advTree1.Nodes[0].Nodes.Clear();
            InitData();
        }

        private void InitData()
        {
            List<TP_Favorite> list = new List<TP_Favorite>();

            if (this.tbxNickName.Text == "")
                list = DBHelper.CIS.From<TP_Favorite>().Where(p => p.UpdateTime >= (this.dtStartTime.Value.ToShortDateString() + " 00:00:00").AsDateTime() && p.UpdateTime <= (this.dtEndTime.Value.ToShortDateString() + " 23:59:59").AsDateTime()).ToList();
            else
                list = DBHelper.CIS.From<TP_Favorite>().Where(p => p.NickName == this.tbxNickName.Text).ToList();

            if (list.Count == 0)
            {
                AlertBox.Info("没有找到任何记录");
                return;
            }

            list = list.OrderByDescending(p => p.UpdateTime).ToList();

            foreach (TP_Favorite item in list)
            {
                Node node = new Node(item.NickName);
                node.Tag = item.XMLLink;
                this.advTree1.Nodes[0].Nodes.Add(node);
            }
        }

        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.Level != 0)
            {
                string xml = e.Node.Tag.ToString();
                if (xml != null)
                    this.txWriterControl1.XMLText = xml;
                this.txWriterControl1.SetZoomRate((float)1.25);
            }
        }

        private void FormFavorite_Shown(object sender, EventArgs e)
        {
            this.dtStartTime.Value = DateTime.Now.AddDays(-7);
            this.dtEndTime.Value = DateTime.Now;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand(DCSoft.Writer.StandardCommandNames.FilePrintPreview, true, null);
        }
    }
}
