using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Prescription
{

    public class BeforePrescriptionAuditRequest
    {
        public string opter { get; set; }
        public string recer_sys_code { get; set; }
        public string msgid { get; set; }
        public string inf_time { get; set; }
        public Input input { get; set; }
        public string infno { get; set; }
        public string cainfo { get; set; }
        public string opter_type { get; set; }
        public string opter_name { get; set; }
        public string mdtrtarea_admvs { get; set; }
        public string signtype { get; set; }
        public string fixmedins_soft_fcty { get; set; }
        public string dev_safe_info { get; set; }
        public string insuplc_admdvs { get; set; }
        public string infver { get; set; }
        public string sign_no { get; set; }
        public string fixmedins_name { get; set; }
        public string fixmedins_code { get; set; }
        public string dev_no { get; set; }
    }

    public class Input
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public string syscode { get; set; }
        public string trig_scen { get; set; }
        public Patient_Dtos patient_dtos { get; set; }
        public string rule_ids { get; set; }
        public string task_id { get; set; }
    }

    public class Patient_Dtos
    {
        public string poolarea { get; set; }
        public string curr_mdtrt_id { get; set; }
        public string patn_id { get; set; }
        public string fsi_his_data_dto { get; set; }
        public Fsi_Encounter_Dtos fsi_encounter_dtos { get; set; }
        public string patn_name { get; set; }
        public string gend { get; set; }
        public string brdy { get; set; }
    }

    public class Fsi_Encounter_Dtos
    {
        public string out_setl_flag { get; set; }
        public string adm_date { get; set; }
        public string dscg_dept_name { get; set; }
        public string dscg_dept_codg { get; set; }
        public int setl_totlnum { get; set; }
        public string dscg_date { get; set; }
        public string wardno { get; set; }
        public string mdtrt_id { get; set; }
        public string adm_dept_name { get; set; }
        public string adm_dept_codg { get; set; }
        public string ownpay_amt { get; set; }
        public string fsi_operation_dtos { get; set; }
        public string medins_type { get; set; }
        public string medins_name { get; set; }
        public string med_mdtrt_type { get; set; }
        public string hifp_payamt { get; set; }
        public string ma_amt { get; set; }
        public string dscg_main_dise_name { get; set; }
        public string dscg_main_dise_codg { get; set; }
        public string medins_admdvs { get; set; }
        public string acct_payamt { get; set; }
        public string med_type { get; set; }
        public List<Fsi_Diagnose_Dtos> fsi_diagnose_dtos { get; set; }
        public string insutype { get; set; }
        public List<Fsi_Order_Dtos> fsi_order_dtos { get; set; }
        public string dr_codg { get; set; }
        public string selfpay_amt { get; set; }
        public string reim_flag { get; set; }
        public string medfee_sumamt { get; set; }
        public string medins_lv { get; set; }
        public string medins_id { get; set; }
        public string wardarea_codg { get; set; }
        public string bedno { get; set; }
        public string matn_stas { get; set; }
    }

    public class Fsi_Diagnose_Dtos
    {
        public string inout_dise_type { get; set; }
        public string dise_id { get; set; }
        public string dias_srt_no { get; set; }
        public string dise_name { get; set; }
        public string dise_date { get; set; }
        public string dise_codg { get; set; }
        public string maindise_flag { get; set; }
    }

    public class Fsi_Order_Dtos
    {
        public string drord_bhvr { get; set; }
        public string cnt { get; set; }
        public string hilist_lv { get; set; }
        public string sumamt { get; set; }
        public string lv2_hosp_item_pric { get; set; }
        public string ownpay_amt { get; set; }
        public string hilist_type { get; set; }
        public string hilist_pric { get; set; }
        public string hilist_name { get; set; }
        public string hilist_memo { get; set; }
        public string hilist_code { get; set; }
        public string spec_unt { get; set; }
        public string curr_drord_flag { get; set; }
        public string drord_dept_name { get; set; }
        public string drord_dept_codg { get; set; }
        public string grpno { get; set; }
        public string hosplist_name { get; set; }
        public string hosplist_code { get; set; }
        public string chrg_type { get; set; }
        public string drord_stop_date { get; set; }
        public string drord_dr_name { get; set; }
        public string drord_dr_codg { get; set; }
        public string hilist_dosform { get; set; }
        public string lv3_hosp_item_pric { get; set; }
        public string selfpay_amt { get; set; }
        public string long_drord_flag { get; set; }
        public string drord_begn_date { get; set; }
        public string spec { get; set; }
        public string lv1_hosp_item_pric { get; set; }
        public string rxno { get; set; }
        public string hosplist_dosform { get; set; }
        public string pric { get; set; }
        public string rx_id { get; set; }
        public string drord_dr_profttl { get; set; }
    }

}
