using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation
{
    class PrescriptionCirculationRequest
    {
        public string signData { get; set; }
        public string encType { get; set; }
        public string appId { get; set; }
        public string signType { get; set; }
        public string encData { get; set; }
        public string version { get; set; }
        public string timestamp { get; set; }
    }
}
