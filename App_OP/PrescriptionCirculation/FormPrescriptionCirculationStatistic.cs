using CIS.Core;
using CIS.Model;
using DevComponents.AdvTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App_OP.PrescriptionCirculation
{
    public partial class FormPrescriptionCirculationStatistic : BaseForm
    {
        private List<IView_HIS_DrugUsage> usage;
        private List<OP_Dic_Interval> interval;

        public FormPrescriptionCirculationStatistic()
        {
            InitializeComponent();
        }

        private void Init()
        {
            this.fcbDoctorName.DataSource = DBHelper.CIS.From<IView_User>().ToDataTable();
            this.fcbDoctorName.DisplayMember = nameof(IView_User.Name);
            this.fcbDoctorName.ValueMember = nameof(IView_User.Code);
            this.fcbDoctorName.FilterFields = new string[] { nameof(IView_User.SearchCode) };

            this.dtStartDate.Value = DateTime.Now.AddDays(-7);
            this.dtEndDate.Value = DateTime.Now;

            usage = DBHelper.CIS.From<IView_HIS_DrugUsage>().ToList();
            this.XY_colYF.DataSource = usage.Where(p => p.Type == "1").ToList();
            this.XY_colYF.DisplayMember = "Name";
            this.XY_colYF.ValueMember = "Code";

            interval = DBHelper.CIS.From<OP_Dic_Interval>().ToList();
            this.XY_colJG.DataSource = interval;
            this.XY_colJG.DisplayMember = "Name";
            this.XY_colJG.ValueMember = "Code";
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.treePatient.Nodes.Clear();

            var startDate = this.dtStartDate.Value.Start();
            var endDate = this.dtEndDate.Value.End();
            var doctorCode = this.fcbDoctorName.SelectedValue;

            var allPrescriptions = DBHelper.CIS.From<OP_PrescriptionCirculation>().Where(p => p.UpdateTime >= startDate && p.UpdateTime <= endDate && p.UserID == doctorCode).ToList();

            allPrescriptions.ForEach(p => p.UpdateTime = p.UpdateTime.Value.Date);
            allPrescriptions = allPrescriptions.OrderByDescending(p => p.UpdateTime).ThenBy(p => p.TreatmentNo).ToList();

            var dateGroups = allPrescriptions.GroupBy(p => p.UpdateTime).ToDictionary(key => key.Key.Value, value => value.ToList());

            foreach (var dateGroup in dateGroups)
            {
                var dt = dateGroup.Key;
                var prescriptions = dateGroup.Value;

                var node = new Node(dt.ToString("yyyy-MM-dd"));
                var patientGroups = prescriptions.GroupBy(p => p.TreatmentNo).ToDictionary(key => key.Key, value => value.ToList());

                foreach (var patientGroup in patientGroups)
                {
                    var treatmentNo = patientGroup.Key;
                    var patientName = patientGroup.Value.FirstOrDefault(p => p.TreatmentNo == treatmentNo)?.PatientName;
                    var currentPrescriptions = patientGroup.Value;

                    var patientNode = new Node(patientName + " " + treatmentNo);
                    int index = 1;
                    foreach (var prescription in currentPrescriptions)
                    {
                        string state = prescription.Status == 0 ? "未上传" : prescription.Status == 1 ? "上传完成" : prescription.Status == 2 ? "上传失败" : "撤回";

                        var prescriptionNode = new Node($"第{index++}张处方 状态:{state}");
                        prescriptionNode.Tag = prescription;
                        patientNode.Nodes.Add(prescriptionNode);
                    }

                    node.Nodes.Add(patientNode);
                }

                this.treePatient.Nodes.Add(node);
            }

            this.treePatient.ExpandAll();
        }

        private void FormPrescriptionCirculationStatistic_Shown(object sender, EventArgs e)
        {
            this.Init();
        }

        private void treePatient_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            this.dgvWesternMedicine.Rows.Clear();
            if (e.Node.Tag == null)
                return;

            var prescription = e.Node.Tag as OP_PrescriptionCirculation;

            var details = DBHelper.CIS.From<OP_PrescriptionCirculation_Detail>().Where(p => p.PrescriptionNo == prescription.PrescriptionNo).ToList();

            foreach (var detail in details)
            {
                var newRow = this.dgvWesternMedicine.Rows[this.dgvWesternMedicine.Rows.Add()];
                newRow.Cells[XY_colName.Index].Value = detail.ItemName;
                newRow.Cells[XY_colGG.Index].Value = detail.Specification;
                newRow.Cells[XY_colYL.Index].Value = detail.Amount;
                newRow.Cells[XY_colYLDW.Index].Value = detail.DosageUnit;
                newRow.Cells[XY_colYF.Index].Value = usage.FirstOrDefault(p => p.Code == detail.Usage)?.Name;
                newRow.Cells[XY_colJG.Index].Value = interval.FirstOrDefault(p => p.Code == detail.Frequency)?.Name;
                newRow.Cells[colDay.Index].Value = detail.Days;
                newRow.Cells[XY_colSL.Index].Value = detail.Number;
                newRow.Cells[XY_colGGDW.Index].Value = detail.PackingUnit;
                newRow.Cells[XY_colYPCD.Index].Value = detail.ProductionSites;

                newRow.Tag = detail;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var node = this.treePatient.SelectedNode;
            if (node == null || node.Tag == null)
                return;

            var prescription = node.Tag as OP_PrescriptionCirculation;
            Print.PrescriptionPrint(prescription.PrescriptionNo, prescription.PrescriptionCirculationNo, prescription.TreatmentNo);
        }
    }
}
