using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.HealthRecords
{
    public class EncryptionResponse
    {
        public int status { get; set; }
        public string msg { get; set; }
        public Data data { get; set; }
        public long timestamps { get; set; }
    }

    public class Data
    {
        public string isEncrypt { get; set; }
        public string ivParameter { get; set; }
    }

}
