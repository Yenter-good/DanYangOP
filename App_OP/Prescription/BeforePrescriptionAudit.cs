using CIS.Core;
using CIS.Model;
using CIS.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace App_OP.Prescription
{
    internal class BeforePrescriptionAudit
    {
        private string _url = "";

        private Dictionary<string, string> _header;

        public BeforePrescriptionAudit()
        {
            _url = ConfigurationManager.AppSettings["MedicalInsurancePreAuditUrl"];

            _header = new Dictionary<string, string>();
            _header["_api_name"] = "hssServives";
            _header["_api_signature"] = "";
            _header["_api_version"] = "1.0.0";
            _header["_api_access_key"] = "";
            _header["_api_timestamp"] = "";
        }

        public BeforePrescriptionAuditRequest FillPatientInfo()
        {
            Random rnd = new Random();
            BeforePrescriptionAuditRequest result = new BeforePrescriptionAuditRequest();



            result.opter = "9999";
            result.recer_sys_code = "MBS_LOCAL";
            result.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            result.msgid = "H32118100064" + DateTime.Now.ToString("yyyyMMddHHmmss") + rnd.Next(1000, 9999).ToString();
            result.input = new Input();

            result.infno = "3101";
            result.cainfo = "04010e61427ba598244cf56ad70626404ea704ef965479313997a3d092c15280f5b5b29781e169e441b7cb1dddcf6cc14223a30db4bce627a953d250df231d8c5e1973b050f2fb1bd0a4d7340d0a85769b02728986e289d6602d48ee99f62d5f653b17a79508cfc7db9dfd3755167b27f178ed1e23c28346cfd35217e499747d3f";
            result.opter_type = "1";
            result.opter_name = "管理员";
            result.mdtrtarea_admvs = "321181";
            result.fixmedins_soft_fcty = "深圳九明珠信息科技有限公司";
            result.infver = "V1.0";
            result.fixmedins_name = "丹阳市中医院";
            result.fixmedins_code = "H32118100064";

            result.input.data = new Data();
            result.input.data.syscode = "3101";
            result.input.data.trig_scen = "5";
            result.input.data.task_id = Guid.NewGuid().ToString().Replace("-", "");

            result.input.data.patient_dtos = new Patient_Dtos();
            var patientdto = result.input.data.patient_dtos;
            patientdto.curr_mdtrt_id = SysContext.GetCurrPatient.OutpatientNo;
            patientdto.patn_name = SysContext.GetCurrPatient.PatientName;
            patientdto.gend = SysContext.GetCurrPatient.Sex == "男" ? "1" : SysContext.GetCurrPatient.Sex == "女" ? "2" : "9";
            patientdto.brdy = SysContext.GetCurrPatient.Birthday;

            patientdto.fsi_encounter_dtos = new Fsi_Encounter_Dtos();
            var encounter = patientdto.fsi_encounter_dtos;
            encounter.mdtrt_id = SysContext.GetCurrPatient.OutpatientNo;
            encounter.medins_id = "H32118100064";
            encounter.medins_name = "丹阳市中医院";
            encounter.medins_admdvs = "321181";
            encounter.medins_type = "1";
            encounter.medins_lv = "2";
            encounter.adm_date = SysContext.GetCurrPatient.RegisterTime.ToString("yyyy-MM-dd HH:mm:ss");
            encounter.dscg_date = SysContext.GetCurrPatient.RegisterTime.ToString("yyyy-MM-dd HH:mm:ss");
            encounter.dr_codg = SysContext.CurrUser.UserId;
            encounter.adm_dept_codg = SysContext.RunSysInfo.currDept.Code;
            encounter.adm_dept_name = SysContext.RunSysInfo.currDept.Name;
            encounter.med_mdtrt_type = "1";
            encounter.med_type = "21";
            encounter.matn_stas = "0";
            encounter.insutype = "390";
            encounter.reim_flag = "0";
            encounter.out_setl_flag = "1";
            encounter.dscg_dept_codg = SysContext.RunSysInfo.currDept.Code;
            encounter.dscg_dept_name = SysContext.RunSysInfo.currDept.Name;
            encounter.selfpay_amt = "0.00";
            encounter.setl_totlnum = 1;

            var dt = DBHelper.CIS.FromSql($"SELECT * FROM V_MZ_CIS WHERE  JZH='{SysContext.GetCurrPatient.OutpatientNo}'").ToDataTable();
            if (dt.Rows.Count != 0)
            {
                patientdto.poolarea = dt.Rows[0]["poolarea"].AsString("");
                encounter.insutype = dt.Rows[0]["insutype"].AsString("");
                encounter.reim_flag = dt.Rows[0]["reim_flag"].AsString("");
                encounter.out_setl_flag = dt.Rows[0]["out_setl_flag"].AsString("");
                patientdto.patn_id = dt.Rows[0]["patn_id"].AsString("");
            }

            return result;
        }

        public BeforePrescriptionAuditRequest FillDiagnosis(BeforePrescriptionAuditRequest request, List<OP_PatientDiagnosis> diagnosis)
        {
            request.input.data.patient_dtos.fsi_encounter_dtos.dscg_main_dise_codg = diagnosis.FirstOrDefault(p => p.IsMain == 1)?.Code;
            request.input.data.patient_dtos.fsi_encounter_dtos.dscg_main_dise_name = diagnosis.FirstOrDefault(p => p.IsMain == 1)?.Name;

            request.input.data.patient_dtos.fsi_encounter_dtos.fsi_diagnose_dtos = new List<Fsi_Diagnose_Dtos>();

            foreach (var item in diagnosis)
            {
                var dto = new Fsi_Diagnose_Dtos();
                dto.dise_id = item.ID;
                dto.inout_dise_type = "1";
                dto.maindise_flag = item.IsMain.ToString();
                dto.dias_srt_no = diagnosis.IndexOf(item).ToString();
                dto.dise_codg = item.Code;
                dto.dise_name = item.Name;
                dto.dise_date = item.UpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

                request.input.data.patient_dtos.fsi_encounter_dtos.fsi_diagnose_dtos.Add(dto);
            }

            return request;
        }

        public BeforePrescriptionAuditRequest FillPrescription(BeforePrescriptionAuditRequest request, IEnumerable<OP_Prescription_Detail> details, OP_Prescription prescription)
        {
            request.input.data.patient_dtos.fsi_encounter_dtos.fsi_order_dtos = new List<Fsi_Order_Dtos>();

            var itemCodes = string.Join("','", details.Select(p => p.ItemCode).ToArray());
            itemCodes = "'" + itemCodes + "'";
            var dt = DBHelper.CIS.FromSql($"SELECT * from V_MZ_HISLIST where hiscode in ({itemCodes})").ToDataTable();

            foreach (var detail in details)
            {
                Fsi_Order_Dtos dto = new Fsi_Order_Dtos();
                var rows = dt.Select($"hiscode = '{detail.ItemCode}'");
                if (rows.Length > 0)
                {
                    dto.hilist_code = rows[0]["hilist_code"].AsString("");
                    dto.hilist_name = rows[0]["hilist_name"].AsString("");
                    dto.hilist_lv = rows[0]["hilist_lv"].AsString("");
                    dto.hilist_pric = rows[0]["hilist_pric"].AsString("");
                    dto.hilist_type = rows[0]["hilist_type"].AsString("");
                    dto.chrg_type = rows[0]["chrg_type"].AsString("");
                }

                dto.rx_id = detail.PrescriptionNo;
                dto.rxno = prescription.HISInterface_PrescriptionNo.ToString();
                dto.long_drord_flag = "0";
                dto.drord_bhvr = "0";
                dto.hosplist_code = detail.ItemCode;
                dto.hosplist_name = detail.ItemName;
                dto.cnt = detail.Number.Value.ToString();
                dto.pric = detail.Price.ToString();
                dto.sumamt = detail.Total.ToString();
                dto.spec = detail.Specification;
                dto.spec_unt = detail.PackingUnit;
                dto.drord_dept_codg = SysContext.RunSysInfo.currDept.Code;
                dto.drord_dept_name = SysContext.RunSysInfo.currDept.Name;
                dto.drord_dr_codg = SysContext.CurrUser.UserId;
                dto.drord_dr_name = SysContext.CurrUser.UserName;
                dto.curr_drord_flag = "1";

                request.input.data.patient_dtos.fsi_encounter_dtos.fsi_order_dtos.Add(dto);
            }

            var totle = string.Format("{0:f2}", details.Sum(p => p.Total));
            request.input.data.patient_dtos.fsi_encounter_dtos.medfee_sumamt = totle;
            request.input.data.patient_dtos.fsi_encounter_dtos.ownpay_amt = totle;

            return request;
        }

        public BeforePrescriptionAuditResult Post(BeforePrescriptionAuditRequest request)
        {
            var json = SerializeHelper.BeginJsonSerializable(request);

            var timemap = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            _header["_api_timestamp"] = timemap;
            _header["_api_name"] = "hssServives";
            _header["_api_version"] = "1.0.0";
            _header["_api_signature"] = "";
            _header["_api_access_key"] = "";

            try
            {
                //System.IO.File.WriteAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "audit_request.txt"), json);

                json = HTTPHelper.HTTPPost(_url, json, _header, "application/json");

                var response = SerializeHelper.BeginJsonDeserialize<BeforePrescriptionAuditResponse>(json);

                //System.IO.File.WriteAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "audit_response.txt"), json);

                if (response.infcode == "0")
                {
                    if (response.output != null && response.output.result != null && response.output.result.Length > 0)
                    {
                        var result = new BeforePrescriptionAuditResult();
                        result.Success = false;
                        result.Errors = new List<BeforePrescriptionAuditErrorInfo>();
                        foreach (var error in response.output.result)
                        {
                            result.Errors.Add(new BeforePrescriptionAuditErrorInfo()
                            {
                                Content = error.vola_cont,
                                Legal = error.vola_evid,
                                Level = error.vola_bhvr_type.AsInt(0)
                            });
                        }
                        return result;
                    }
                    return new BeforePrescriptionAuditResult() { Success = true };
                }
                else
                    return new BeforePrescriptionAuditResult() { Success = true };
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("事前接口调用失败\r\n" + ex.Message);
                return null;
            }


            //var response = SerializeHelper.BeginJsonDeserialize<BeforePrescriptionAuditResponse>(result);
        }
    }

}
