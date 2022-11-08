using System.Collections.Generic;

namespace CIS.Model
{
    public class MedicalInsuranceDrugResult
    {
        public string code { get; set; }

        public string msg { get; set; }

        public List<messages> messages { get; set; }

        public string showflag { get; set; }
    }

    public class messages
    {
        public string ruleId { get; set; }

        public string triggerLevel { get; set; }

        public string involvedCost { get; set; }

        public string content { get; set; }

        public string comments { get; set; }

        public List<encounterResults> encounterResults { get; set; }

        public string uuid { get; set; }

        public string feedBackMsg { get; set; }

    }

    public class encounterResults
    {
        public string encounterId { get; set; }

        public List<string> orderIds { get; set; }
    }
}
