using System.Collections.Generic;

namespace CIS.Purview
{
    public class SysDeptDal
    {
        /// <summary>
        /// 获取有效的科室列表
        /// </summary>
        /// <returns></returns>
        public static List<CIS.Model.IView_Dept> GetValidDepts()
        {
            return CIS.Model.DBHelper.CIS.From<CIS.Model.IView_Dept>().Where(d => d.Status == 1).ToList();
        }
    }
}
