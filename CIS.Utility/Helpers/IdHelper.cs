﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIS.Utility.Helpers
{
    public static class IdHelper
    {
        /// <summary>  
        /// 根据GUID获取19位的唯一数字序列  
        /// </summary>  
        /// <returns></returns>  
        public static long GuidToLongID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
