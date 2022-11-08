using System;

namespace CIS.Model
{
    public class Prescription
    {
        public string ID { get; set; }
        public string TreatmentNo { get; set; }
        public string PatientID { get; set; }
        public string PrescriptionNo { get; set; }
        public string ItemType { get; set; }
        public int? No { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Specification { get; set; }
        public int? Number { get; set; }
        public string PackingUnit { get; set; }
        public decimal? Amount { get; set; }
        public string DosageUnit { get; set; }
        public string Usage { get; set; }
        public string Frequency { get; set; }
        public string SkinTestFlag { get; set; }
        public int? GroupNo { get; set; }
        public decimal? Price { get; set; }
        public string ExecuteDept { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int? Days { get; set; }
        public string ProductionSites { get; set; }
        public string DrugProperties { get; set; }
        public int? Doses { get; set; }
        public decimal? Total { get; set; }
        public decimal? PackingNumber { get; set; }
        public string DiagnosisName { get; set; }
        public string DeptName { get; set; }
        public string PatientName { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string DoctorName { get; set; }
        public string DoctorPhone { get; set; }
        public string PrescriptionType { get; set; }
        public string PayType { get; set; }
        public string ConditionSummary { get; set; }
        public string Explanation { get; set; }
        public string Specimen { get; set; }
        public string HerbalMedicineNum { get; set; }
        public int? IsAdditional { get; set; }
        public string AgentName { get; set; }
        public string AgentIDCard { get; set; }
        public string AgentAge { get; set; }
        public string AgentSex { get; set; }
        public string IDCard { get; set; }

        public string PatientPhone { get; set; }
        public string HerbsGroupName { get; set; }
        public string PatientAddress { get; set; }
        public string DrugPurpose { get; set; }
    }
}
