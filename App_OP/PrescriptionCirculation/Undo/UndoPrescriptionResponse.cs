using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.Undo
{
    public class UndoPrescriptionResponse
    {
        /// <summary>
        /// 医保处方编号   
        /// </summary>
        public string hiRxno { get; set; }

        /// <summary>
        /// 医保处方状态编码  参考（rx_stas_codg） 
        /// </summary>
        public string rxStasCodg { get; set; }

        /// <summary>
        /// 医保处方状态名称   
        /// </summary>
        public string rxStasName { get; set; }

    }
}
