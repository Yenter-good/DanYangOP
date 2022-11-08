using System;
using CIS.Model;
using CIS.Core;

namespace App_OP
{
    public static class Journal
    {
        public static bool InsertJournal(string Diagnosis)
        {
            try
            {
                OP_Journal tmp = new OP_Journal();
                IView_HIS_Outpatients patient = (SysContext.Session[SysContext.Session_CurrPatient] as IView_HIS_Outpatients);
                tmp.Age = patient.Age;
                tmp.Birthday = patient.Birthday;
                tmp.CardNo = patient.CardNo;
                tmp.DeptCode = SysContext.RunSysInfo.currDept.Code;
                tmp.DeptName = SysContext.RunSysInfo.currDept.Name;
                tmp.DoctorName = SysContext.CurrUser.user.Name;
                tmp.DoctorNo = SysContext.CurrUser.user.Code;
                tmp.ID = Guid.NewGuid().ToString();
                tmp.OutpatientNo = patient.OutpatientNo;
                tmp.PatientAddress = patient.PatientAddress;
                tmp.PatientDiagnosis = Diagnosis;
                tmp.PatientID = patient.PatientID;
                tmp.PatientName = patient.PatientName;
                tmp.Sex = patient.Sex;
                tmp.UpdateDate = DateTime.Now;
                tmp.IDCard = patient.IDCard;
                tmp.Address = patient.Address;
                DBHelper.CIS.Delete<OP_Journal>(p => p.OutpatientNo == patient.OutpatientNo);
                DBHelper.CIS.Insert<OP_Journal>(tmp);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
