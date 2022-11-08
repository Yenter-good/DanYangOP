using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace CIS.Purview
{
    /// <summary>
    /// 用户权限访问类
    /// 命名规范 系统模板前缀_参数名称
    /// </summary>
    public class UserAuthoritis
    {
        private string curUserId = null;
        private List<string> authorityCodes = new List<string>();
        private static BlockingCollection<string> codes = new BlockingCollection<string>();
        /// <summary>
        /// 选择用户
        /// </summary>
        /// <param name="userId"></param>
        public void Select(string userId)
        {
            if (curUserId != userId)
            {
                authorityCodes.Clear();
                authorityCodes = UserDal.GetAuthorityCodes(userId);
                curUserId = userId;
            }
        }
        /// <summary>
        /// 刷新用户参数信息
        /// </summary>
        public void Refresh()
        {
            authorityCodes.Clear();
        }
        /// <summary>
        /// 是否允许查看所有患者的门诊日志
        /// </summary>
        public bool OP_AllJourna { get { return HasAuthority(curUserId, "OP10001", "是否允许查看所有患者的门诊日志", "门诊"); } }
        /// <summary>
        /// 是否拥有毒麻权限
        /// </summary>
        public bool OP_PoisonousHemp { get { return HasAuthority(curUserId, "OP10002", "毒麻权限", "门诊"); } }
       
        /// <summary>
        /// 是否拥有权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        private bool HasAuthority(string userId, string code, string name, string category) 
        {
            if (userId == null) return false;
            if (authorityCodes.Contains(code))
            {
                return true;
            }
            else
            {
                if (!codes.Contains(code))
                {
                    if (!AuthorityDal.Exists(code))
                    {
                        AuthorityDal.Add(code, name, category);
                    }
                    codes.TryAdd(code);
                }
                return false;
            }
        }
    }
}
