using System.Collections.Concurrent;

namespace CIS.Purview
{
    /// <summary>
    /// 科室参数访问类
    /// 命名规范 系统模板前缀_参数名称
    /// </summary>
    public class DeptParams
    {
        private string curDeptId = null;
        private ConcurrentDictionary<string, string> paramValues = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// 选择科室
        /// </summary>
        /// <param name="deptId"></param>
        public void Select(string deptId)
        {
            if (curDeptId != deptId)
            {
                paramValues.Clear();
                curDeptId = deptId;
            }
        }
        /// <summary>
        /// 刷新科室参数信息
        /// </summary>
        public void Refresh()
        {
            paramValues.Clear();
        }
        
        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="code">参数编码</param>
        /// <param name="name">参数名称</param>
        /// <param name="descrption">描述文本</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        private string GetValue(string userId,string code, string name, string descrption, string defaultValue) 
        {
            if (userId == null) return defaultValue;
            string value = defaultValue;
            if (paramValues.ContainsKey(code))
            {
                paramValues.TryGetValue(code, out value);
                return value;
            }
            else
            {
                if (UserParameterDal.Exists(userId, code))
                {
                    value = UserParameterDal.Get(userId, code);
                }
                else
                {
                    UserParameterDal.Add(userId, code, name, descrption, value);
                }
                paramValues.TryAdd(code, value);
                return value;
            }
        }
    }
}
