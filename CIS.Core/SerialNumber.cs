namespace CIS.Core
{
    /// <summary>
    /// 序列号
    /// </summary>
    public static class SerialNumber
    {
        public enum Type
        {
            /// <summary>
            /// 索引和前缀之间有一个点
            /// </summary>
            HavePoint = 0,

            /// <summary>
            /// 索引和前缀之间没有点
            /// </summary>
            NoPoint = 1
        }

        /// <summary>
        /// 生成节点型序列号 EMR00.04
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="prefix">前缀</param>
        /// <param name="parentCode">父节点</param>
        /// <param name="digit">位数</param>
        /// <returns></returns>
        public static string Generator(string tableName, string prefix, string parentCode, Type type, int digit = 2)
        {
            string tmp = prefix + parentCode;
            return Generator(tableName, tmp, type, digit);
        }

        /// <summary>
        /// 生成普通序列号
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="prefix">前缀</param>
        /// <param name="digit">位数</param>
        /// <returns></returns>
        public static string Generator(string tableName, string prefix, Type type, int digit = 6)
        {
            string tmp = CIS.Model.DBHelper.CIS.FromProc("CREATE_SEQUENCE").AddInParameter("@TABLENAME", System.Data.DbType.String, tableName).AddInParameter("@PREFIXED", System.Data.DbType.String, prefix).AddInParameter("@TYPE", System.Data.DbType.Int32, type).AddInParameter("@LEN", System.Data.DbType.Int32, digit).ToScalar().ToString();
            return tmp;
        }
    }
}