using CIS.Core;
using CIS.Model;
using DevComponents.AdvTree;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace App_OP
{
    public partial class FormSelectDealWith : BaseForm
    {
        public FormSelectDealWith()
        {
            InitializeComponent();
        }

        public List<OP_Prescription> prescription;
        public List<OP_Prescription> result = new List<OP_Prescription>();
        List<OP_Dic_PrescriptionType> type;

        private void InitUI()
        {
            prescription = DBHelper.CIS.From<OP_Prescription>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo && (p.PrescriptionType == "1" || p.PrescriptionType == "3" || p.PrescriptionType == "9" || p.PrescriptionType == "5" || p.PrescriptionType == "6" || p.PrescriptionType == "2" || p.PrescriptionType == "7" || p.PrescriptionType == "8" || p.PrescriptionType == "11" || p.PrescriptionType == "12") && (p.Status == 1 || p.Status == 2)).ToList();

            List<OP_Prescription> WesternMedicine = prescription.Where(p => p.PrescriptionType != "2" && p.PrescriptionType != "9" && p.PrescriptionType != "11" && p.PrescriptionType != "12").ToList();
            List<OP_Prescription> HerbalMedicine = prescription.Where(p => p.PrescriptionType == "2").ToList();
            List<OP_Prescription> Item = prescription.Where(p => p.PrescriptionType == "9").ToList();
            List<OP_Prescription> inspection = DBHelper.CIS.From<OP_Prescription>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo && (p.PrescriptionType == "11" || p.PrescriptionType == "12") && (p.Status == 1 || p.Status == 2)).ToList();

            type = DBHelper.CIS.From<OP_Dic_PrescriptionType>().ToList();

            InitTree(inspection, 0);
            InitTree(HerbalMedicine, 1);
            InitTree(WesternMedicine, 2);
            InitTree(Item, 3);
        }

        private void InitTree(List<OP_Prescription> prescription, int ParentIndex)
        {
            foreach (OP_Prescription item in prescription)
            {
                Node node = new Node(type.Where(p => p.Code == item.PrescriptionType).First().Name);
                node.CheckBoxVisible = true;
                node.Tag = item;
                this.advTree1.Nodes[ParentIndex].Nodes.Add(node);
            }
        }

        private void FormSelectDealWith_Shown(object sender, EventArgs e)
        {
            InitUI();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            List<Node> nodes = this.advTree1.CheckedNodes;
            foreach (Node item in nodes)
                result.Add(item.Tag as OP_Prescription);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void advTree1_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.X > 60 && e.Node.CheckBoxVisible)
                e.Node.Checked = !e.Node.Checked;
            //this.Text = e.X.ToString();
        }
    }
}
