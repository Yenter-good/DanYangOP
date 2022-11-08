using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation
{
    class PrescriptionCirculationResponse
    {
        public int code { get; set; }
        public string message { get; set; }
        public string encType { get; set; }
        public string encData { get; set; }
    }
}
