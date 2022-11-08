using CIS.Model;
using Dos.ORM;

namespace CIS.Purview
{
    public static class DrugGroupDal
    {
        #region

        /// <summary>
        /// 值域Delete
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public static int dbDrugGroupDelete(string ID)
        {
            DbTrans trans = DBHelper.CIS.BeginTransaction();
            try
            {
                trans.Delete<OP_DrugGroup_Detail>(OP_DrugGroup_Detail._.ID == ID);

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

