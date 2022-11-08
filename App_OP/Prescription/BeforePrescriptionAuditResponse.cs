using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Prescription
{

    public class BeforePrescriptionAuditResponse
    {
        public string infcode { get; set; }
        public string inf_refmsgid { get; set; }
        public string refmsg_time { get; set; }
        public string respond_time { get; set; }
        public string enctype { get; set; }
        public string signtype { get; set; }
        public object err_msg { get; set; }
        public Output output { get; set; }
    }

    public class Output
    {
        public Result[] result { get; set; }
    }

    public class Result
    {
        public Judge_Result_Detail_Dtos[] judge_result_detail_dtos { get; set; }
        public string rule_id { get; set; }
        public string vola_evid { get; set; }
        public string mdtrt_id { get; set; }
        public string rule_name { get; set; }
        public string vola_amt_stas { get; set; }
        public string jr_id { get; set; }
        public string patn_id { get; set; }
        public string sev_deg { get; set; }
        public float vola_amt { get; set; }
        public string vola_bhvr_type { get; set; }
        public string vola_cont { get; set; }
    }

    public class Judge_Result_Detail_Dtos
    {
        public string vola_item_type { get; set; }
        public string mdtrt_id { get; set; }
        public string jrd_id { get; set; }
        public string patn_id { get; set; }
        public string rx_id { get; set; }
        public object vola_amt { get; set; }
    }

}
