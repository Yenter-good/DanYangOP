using System;
using Dos.ORM;

namespace CIS.Model
{
    public static class DBHelper
    {
        public static readonly DbSession CIS = new DbSession("CIS");
        public static readonly DbSession HIS = new DbSession("HIS");
        public static readonly DbSession PACS = new DbSession("PACS");
        public static readonly DbSession LIS = new DbSession("LIS");
        public static readonly DbSession PEIS = new DbSession("PEIS");
        public static readonly DbSession RIS = new DbSession("RIS");
        public static readonly DbSession HRP = new DbSession("HRP");
        public static readonly DbSession MR = new DbSession("MR");
        public static readonly DbSession HNIMIS = new DbSession("HNIMIS");
        public static readonly DbSession INTERFACE2 = new DbSession("INTERFACE2");
        public static readonly DbSession INTERFACE3 = new DbSession("INTERFACE3");

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        public static DateTime ServerTime { get { return CIS.FromSql("select getdate()").ToScalar<DateTime>(); } }


    }
}
