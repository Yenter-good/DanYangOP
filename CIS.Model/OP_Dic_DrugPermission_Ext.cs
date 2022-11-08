using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIS.Model
{
    public class OP_Dic_DrugPermission_Ext : OP_Dic_DrugPermission
    {
        public string DeptName { get; set; }
        public string DoctorName { get; set; }
        public string DrugSpecification { get; set; }
        public string DrugName { get; set; }
    }
}
