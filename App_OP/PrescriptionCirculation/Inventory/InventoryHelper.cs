using CIS.Core;
using CIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.Inventory
{
    class InventoryHelper
    {
        private PrescriptionCirculationHandler _handler;

        public InventoryHelper()
        {
            _handler = new PrescriptionCirculationHandler();
        }

        public (bool pass, string msg) Handler(List<IView_PrescriptionCirculation_DrugInfo> drugs, OP_PrescriptionCirculation prescription, List<OP_PrescriptionCirculation_Detail> details)
        {
            var dt = DBHelper.CIS.FromSql($"select * from vtyb_mz_dj where jzh ='{prescription.TreatmentNo}'").ToDataTable();
            if (dt.Rows.Count == 0)
                return (false, "未找到指定病人的医保就诊id");

            InventoryRequest request = new InventoryRequest();
            request.fixmedinsCode = "H32118100064";
            request.fixmedinsName = "丹阳市中医院";
            request.mdtrtId = dt.Rows[0]["mdtrt_id"].ToString();
            request.medType = "11";
            request.iptOtpNo = prescription.TreatmentNo;
            request.otpIptFlag = "1";
            request.psnCertType = "01";
            request.psnNo = prescription.IDCard;
            request.patnName = prescription.PatientName;
            request.certno = prescription.IDCard;
            request.drCode = SysContext.CurrUser.user.HealthCareCode;
            request.prscDrName = SysContext.CurrUser.UserName;
            request.pharCode = SysContext.CurrUser.user.HealthCareCode;
            request.pharName = SysContext.CurrUser.UserName;
            request.mdtrtareaAdmvs = "321181";

            request.drugList = new List<DrugList>();
            foreach (var detail in details)
            {
                var drug = drugs.FirstOrDefault(p => p.CityCode == detail.ItemCode);
                DrugList list = new DrugList()
                {
                    drugCnt = detail.Number,
                    drugDosunt = detail.DosageUnit,
                    medListCodg = drug.CityCode,
                    sinDoscnt = (decimal)detail.Amount.Value,
                    sinDosunt = detail.DosageUnit
                };

                request.drugList.Add(list);
            }

            var url = SysContext.CurrUser.Params.OP_PrescriptionCirculation_Url;
            var response = _handler.Post<InventoryResponse>(request, url + "/pcs-manage/pcs/fixmedins/rxSetlStockQuery", "库存查询");
            if (response == null)
                return (false, "");
            else if (response.accept == "1")
                return (true, "");
            else if (response.accept == "0")
                return (false, "部分满足");
            else if (response.accept == "-1")
                return (false, "无满足库存");
            else
                return (false, response.msg);
        }
    }
}