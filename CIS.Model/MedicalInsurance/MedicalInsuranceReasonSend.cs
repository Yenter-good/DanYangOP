using System.Collections.Generic;

namespace CIS.Model
{
    public class MedicalInsuranceReasonSend
    {
        public string code { get; set; }
        public string feedBackMsg { get; set; }
        public List<messages> messages { get; set; }
    }

    public class Message
    {
        public string uuid { get; set; }
        public string ruleId { get; set; }
        public string triggerLevel { get; set; }
        public int involvedCost { get; set; }
        public string content { get; set; }
        public string comments { get; set; }
        public string feedBackMsg { get; set; }
        public List<Encounterresult> encounterResults { get; set; }
    }

    public class Encounterresult
    {
        public string encounterId { get; set; }
        public string[] orderIds { get; set; }
    }

}
