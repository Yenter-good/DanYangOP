using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.Inventory
{
    class InventoryResponse
    {
        /// <summary>
        /// 0:部分满足 1:全部满足 -1：无满足库存 -2：处方信息异常
        /// </summary>
        public string accept { get; set; }

        /// <summary>
        /// accept为 -2 时有对应提示   
        /// </summary>
        public string msg { get; set; }
    }
}
