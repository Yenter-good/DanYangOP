using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dos.ORM
{
    /// <summary>
    /// dosORM扩展
    /// </summary>
    public static class DosORMExtension
    {
        /// <summary>
        /// 执行事物操作
        /// DBHelper.CIS.ExecuteTransaction(d=>{ 执行的事物操作 });
        /// </summary>
        /// <param name="dbSession"></param>
        /// <param name="action">执行事物的操作</param>
        /// <param name="log">是否记录日志</param>
        /// <returns>返回异常信息</returns>
        public static Exception ExecuteTransaction(this DbSession dbSession,DbTrans tran, Action<DbSession> action, bool log = true)
        {
            if (dbSession == null) return null;
            if (action == null) return null;
           
            Exception excption = null;
            try
            {
                action(dbSession);
                tran.Commit();
            }
            catch (Exception ex)
            {
                excption = ex;
                tran.Rollback();
                if (log)
                {
                    //待定
                    CIS.Utility.LogHelper.Error(ex.Message,"事务");
                }
               
            }
            finally
            {
                tran.Close();
            }
            return excption;
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="dbSession"></param>
        /// <param name="procName"></param>
        /// <param name="paramList"></param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteProcNonQuery(this DbSession dbSession, string procName, Dictionary<string, string> paramList)
        {
            ProcSection proc = dbSession.FromProc(procName);

            foreach (KeyValuePair<string, string> kv in paramList)
            {
                proc.AddInParameter("@" + kv.Key, DbType.String, kv.Value);
            }

            return proc.ExecuteNonQuery();
        }

        /// <summary>
        /// 执行存储过程返回List对象
        /// 存储过程的返回值必须为表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbSession"></param>
        /// <param name="procName"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public static List<T> ExecuteProcList<T>(this DbSession dbSession, string procName, Dictionary<string, string> paramList)
        {
            ProcSection proc = dbSession.FromProc(procName);

            foreach (KeyValuePair<string, string> kv in paramList)
            {
                proc.AddInParameter("@" + kv.Key, DbType.String, kv.Value);
            }

            return proc.ToList<T>();
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="paramList">参数列表  建议参数名称大写 即 Dictionary<string, string> paramList 中的Key大写 例如 dic.put("NAME",name)</param>
        /// <returns>DataSet</returns>
        public static  List<T> ExecuteProcListForXML<T> (this DbSession dbSession, string procName, Dictionary<string, string> paramList)
        {
            ProcSection proc = dbSession.FromProc(procName);
            proc.AddInParameter("@XML" ,DbType.String, BuildXml(paramList));
            return proc.ToList<T>();
        }

        //将参数构建成XML格式的字符串 注意区分大小写 建议大写
        private static string BuildXml(Dictionary<string, string> parameters)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<XMLTABLE>");
            foreach (KeyValuePair<string, string> entry in parameters)
            {
                if (entry.Key != null && entry.Key.Length > 0)
                {
                    builder.Append("<" + entry.Key + ">");
                    builder.Append(entry.Value);
                    builder.Append("</" + entry.Key + ">");
                }
            }
            builder.Append("</XMLTABLE>");
            return builder.ToString();
        }

    }

}
