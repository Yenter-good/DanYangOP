using CIS.Core;
using CIS.Model;
using CIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.PreAudit
{
    class UploadPreAuditHelper
    {
        private Dictionary<string, string> _dept;
        private Dictionary<string, string> _doctor;
        private PrescriptionCirculationHandler _handler;

        public UploadPreAuditHelper()
        {
            _dept = new Dictionary<string, string>();
            _doctor = new Dictionary<string, string>();
            _handler = new PrescriptionCirculationHandler();
            _dept[SysContext.RunSysInfo.currDept.Code] = SysContext.RunSysInfo.currDept.Name;
            _dept[SysContext.CurrUser.UserId] = SysContext.CurrUser.UserName;
        }

        public UploadPreAuditResponse Handler(OP_PrescriptionCirculation prescription, List<OP_PrescriptionCirculation_Detail> details, List<IView_PrescriptionCirculation_DrugInfo> drugs, List<IView_HIS_DrugUsage> usages, List<OP_PatientDiagnosis> diagnosis, List<OP_Dic_Interval> interval)
        {
            UploadPreAuditRequest request = new UploadPreAuditRequest();

            request.mdtrtCertType = "2";
            request.mdtrtCertNo = SysContext.GetCurrPatient.IDCard;
            request.bizTypeCode = "01";

            request.insuPlcNo = "321181";

            request.hospRxno = prescription.PrescriptionNo.ToString();

            //var prescriptionType = (PrescriptionType)Convert.ToInt32(prescription.PrescriptionType);
            //if (prescriptionType == PrescriptionType.Normal)
            request.rxTypeCode = "1";
            //else if (prescriptionType == PrescriptionType.JingmaYi)
            //    request.rxTypeCode = "7";
            //else if (prescriptionType == PrescriptionType.Herbal)
            //    request.rxTypeCode = "2";

            request.prscTime = prescription.UpdateTime.Value;
            request.valiDays = 3;
            request.rxCotnFlag = "0";

            //if (prescriptionType == PrescriptionType.Herbal)
            //{
            //    request.rxDrugCnt = prescription.HerbalMedicineNum.Value;
            //    request.rxUsedWayCodg = "9";
            //    request.rxUsedWayName = prescription.ConditionSummary;
            //}
            //else
            request.rxDrugCnt = prescription.RecordNumber.Value;

            request.rxdrugdetail = this.BuildDetails(prescription, details, drugs, usages, interval);
            request.mdtrtinfo = this.BuildTreatment(prescription, diagnosis);
            request.diseinfo = this.BuildDiagnosis(diagnosis);
            request.valiEndTime = prescription.UpdateTime.Value.AddDays(3);

            var url = SysContext.CurrUser.Params.OP_PrescriptionCirculation_Url;
            return _handler.Post<UploadPreAuditResponse>(request, url + "/fixmedins/fixmedins/uploadChk", "上传预核检");
        }

        private List<rxdrugdetail> BuildDetails(OP_PrescriptionCirculation prescription, List<OP_PrescriptionCirculation_Detail> details, List<IView_PrescriptionCirculation_DrugInfo> drugs, List<IView_HIS_DrugUsage> usages, List<OP_Dic_Interval> interval)
        {
            List<rxdrugdetail> result = new List<rxdrugdetail>();

            foreach (var detail in details)
            {
                var drug = drugs.FirstOrDefault(p => p.CityCode == detail.ItemCode);
                rxdrugdetail model = new rxdrugdetail();

                model.medListCodg = drug?.CityCode;
                //model.fixmedinsHilistId = drug?.DrugID;

                var category = drug?.DrugCategory;
                model.rxItemTypeCode = category == "1" ? "11" : category == "6" ? "13" : "12";
                model.rxItemTypeName = category == "1" ? "西药" : category == "6" ? "中药饮片" : "中成药";
                model.drugProdname = drug.DrugName;
                model.drugGenname = drug.NickName;
                model.drugDosform = drug.DrugForm;
                model.drugSpec = drug.Specification;
                model.prdrName = drug.ProductionSites;
                model.medcWayCodg = detail.Usage;
                model.medcWayDscr = usages.FirstOrDefault(p => p.Code == detail.Usage)?.Name;
                if (model.medcWayDscr == null)
                    model.medcWayDscr = detail.Usage;

                model.medcDays = detail.Days.Value;
                model.sinDoscnt = (decimal)detail.Amount.Value;
                model.sinDosunt = detail.DosageUnit;
                model.usedFrquCodg = detail.Frequency;
                model.usedFrquName = interval.FirstOrDefault(p => p.Code == detail.Frequency)?.Name;
                model.drugTotlcnt = detail.Number.Value;
                model.drugTotlcntEmp = detail.PackingUnit;
                model.medcBegntime = prescription.UpdateTime.Value;
                model.medcEndtime = prescription.UpdateTime.Value.AddDays(detail.Days.Value);
                model.drugCnt = detail.Number.Value;
                model.hospApprFlag = "0";
                model.drugDosunt = detail.PackingUnit;

                result.Add(model);
            }
            return result;
        }

        private mdtrtinfo BuildTreatment(OP_PrescriptionCirculation prescription, List<OP_PatientDiagnosis> diagnosis)
        {
            mdtrtinfo result = new mdtrtinfo();

            result.fixmedinsCode = "H32118100064";
            result.fixmedinsName = "丹阳市中医院";
            result.medType = "12";
            result.iptOtpNo = SysContext.GetCurrPatient.OutpatientNo;
            result.otpIptFlag = "1";
            result.psnNo = SysContext.GetCurrPatient.CardNo;
            result.patnName = SysContext.GetCurrPatient.PatientName;
            result.psnCertType = "01";
            result.psnNo = SysContext.GetCurrPatient.IDCard;
            result.patnAge = SysContext.GetCurrPatient.Age.GetAge();
            result.gend = SysContext.GetCurrPatient.Sex == "男" ? "1" : SysContext.GetCurrPatient.Sex == "女" ? "2" : "9";
            result.prscDeptName = SysContext.RunSysInfo.currDept.Name;
            result.prscDeptCode = SysContext.RunSysInfo.currDept.Code;
            result.drCode = SysContext.CurrUser.user.HealthCareCode;
            result.prscDrName = SysContext.CurrUser.UserName;
            result.drDeptCode = SysContext.RunSysInfo.currDept.Code;
            result.drDeptName = SysContext.RunSysInfo.currDept.Name;
            result.mdtrtTime = prescription.UpdateTime.Value;
            result.spDiseFlag = "0";
            result.certno = SysContext.GetCurrPatient.IDCard;
            result.drProfttlCodg = SysContext.CurrUser.JobTitleCode;
            result.drProfttlName = SysContext.CurrUser.JobTitleName;


            var mainDiag = diagnosis.FirstOrDefault(p => p.IsMain == 1);
            result.maindiagCode = mainDiag?.Code;
            result.maindiagName = mainDiag?.Name;

            return result;
        }

        private List<diseinfo> BuildDiagnosis(List<OP_PatientDiagnosis> diagnosis)
        {
            List<diseinfo> result = new List<diseinfo>();

            int index = 1;
            foreach (var diag in diagnosis)
            {
                diseinfo info = new diseinfo();
                if (diag.IsHMDiagnosis != 1)
                {
                    if (diag.IsMain == 1)
                        info.diagType = "1";
                    else
                        info.diagType = "2";
                }
                else
                    info.diagType = "3";

                info.maindiagFlag = diag.IsMain.ToString();
                info.diagSrtNo = index++;
                info.diagCode = diag.Code;
                info.diagName = diag.Name;

                if (_dept.ContainsKey(diag.DeptCode))
                    info.diagDept = _dept[diag.DeptCode];
                else
                {
                    var name = DBHelper.CIS.From<IView_Dept>().Where(p => p.Code == diag.DeptCode).Select(p => p.Name).First<string>();
                    _dept[diag.DeptCode] = name;
                    info.diagDept = name;
                }
                info.diagDrNo = diag.DoctorCode;
                if (_doctor.ContainsKey(diag.DoctorCode))
                    info.diagDrName = _doctor[diag.DoctorCode];
                else
                {
                    var name = DBHelper.CIS.From<IView_User>().Where(p => p.Code == diag.DoctorCode).Select(p => p.Name).First<string>();
                    _doctor[diag.DoctorCode] = name;
                    info.diagDrName = name;
                }

                info.diagTime = diag.UpdateTime.Value;

                if (diag.Type == 1)
                {
                    info.tcmDiseCode = diag.Code;
                    info.tcmDiseName = diag.Name;
                }
                else if (diag.Type == 2)
                {
                    info.tcmsympCode = diag.Code;
                    info.tcmsymp = diag.Name;
                }

                result.Add(info);
            }

            return result;
        }
    }
}
