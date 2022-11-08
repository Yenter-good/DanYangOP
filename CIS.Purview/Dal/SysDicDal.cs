using CIS.Model;
using Dos.ORM;

namespace CIS.Purview
{
    public static class SysDicDal
    {
        #region

        /// <summary>
        /// 数据字典Delete
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public static int dbSysDicDelete(string Code)
        {
            DbTrans trans = DBHelper.CIS.BeginTransaction();
            try
            {
                //foreach (string code in Code)
                //{
                trans.Delete<Sys_Dic_Details>(Sys_Dic_Details._.Code == Code);
                //}

                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                return 1;
            }
            finally
            {
                trans.Close();
            }
            return 0;
        }

        #endregion
    }
}
