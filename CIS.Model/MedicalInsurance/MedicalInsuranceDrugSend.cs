using System.Collections.Generic;

namespace CIS.Model
{
    public class MedicalInsuranceDrugSend
    {
        public patient patient { get; set; }
        public string clientIP { get; set; }
        public string clientMac { get; set; }
        public string hospitalID { get; set; }
        public string callType { get; set; }
        public string companyCode { get; set; }
        public string ruleIDs { get; set; }

    }

    public class encountersExt
    {
        public string doctorName { get; set; }
        public string admissionDateExt { get; set; }

        public string diseaseType { get; set; }

        public string diseaseName { get; set; }

        public string diseaseCode { get; set; }

        public string individualAccountCostAmt { get; set; }

        public string dischargeDeptID { get; set; }

        public string diagnosis { get; set; }

        public List<diagnoses> diagnoses { get; set; }

        public string encounterID { get; set; }

        public string selfCost { get; set; }

        public string admissionDeptID { get; set; }

        public List<ordersExt> ordersExt { get; set; }

        public string adminssionDepartmentName { get; set; }

        public string dischargeDepartmentName { get; set; }

        public string encounterTypeExt { get; set; }

        public string encounterScene { get; set; }

        public string insuranceCode { get; set; }

        public string assistanceCostAmt { get; set; }

        public string diagnosisCode { get; set; }

        public string cost { get; set; }

        public string specialDiseaseFlag { get; set; }

        public string roomNo { get; set; }

        public string bedNo { get; set; }

        public string dischargeDateExt { get; set; }

        public string doctorID { get; set; }

        public string costCount { get; set; }

        public string overallCostAmt { get; set; }

        public string deductibleCostAmt { get; set; }

        public string pregnantFlag { get; set; }

        public string deptID { get; set; }
    }

    public class ordersExt
    {
        public string doctorName { get; set; }
        public string deductibleCost { get; set; }

        public string startDateExt { get; set; }

        public string outId { get; set; }

        public string medicareDrugForm { get; set; }

        public string issueOrderDeptId { get; set; }

        public string groupCode { get; set; }

        public string specUnit { get; set; }

        public string selfCost { get; set; }

        public string amount { get; set; }

        public string orderType { get; set; }

        public string specification { get; set; }

        public string isRepeat { get; set; }

        public string prescriptionCode { get; set; }

        public string hospitalItemName { get; set; }

        public string hospitalItemCode { get; set; }

        public string detailTypeExt { get; set; }

        public string stopDateExt { get; set; }

        public string hospitalDrugForm { get; set; }

        public string issueOrderDeptName { get; set; }

        public string hospitalDrugFormCode { get; set; }

        public string cost { get; set; }

        public string doctorId { get; set; }

        public string medicareItemName { get; set; }

        public string medicareItemCode { get; set; }

        public string price { get; set; }
        public string transactionType { get; set; }
    }

    public class diagnoses
    {
        public string name { get; set; }

        public string code { get; set; }

    }

    public class patient
    {
        public string sex { get; set; }

        public List<encountersExt> encountersExt { get; set; }

        public string dobExt { get; set; }

        public string currEncounterID { get; set; }

        public string name { get; set; }

        public string cost { get; set; }

        public string patientID { get; set; }

        public string pregnantFlag { get; set; }
    }

}
