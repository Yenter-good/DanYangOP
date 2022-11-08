using CIS.Model;
using Dos.ORM;

namespace CIS.Purview
{
    public static class RangeTypeDal
    {
        #region

        /// <summary>
        /// 值域Delete
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public static int dbTPRangeDelete(string Code)
        {
            DbTrans trans = DBHelper.CIS.BeginTransaction();
            try
            {
                trans.Delete<TP_Range>(TP_Range._.Code == Code);

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
