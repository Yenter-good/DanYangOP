namespace CIS.Model
{
    partial class Sys_Module
    {
        /// <summary>
        /// 判断是否为分类
        /// </summary>
        /// <returns></returns>
        public bool IsCategory()
        {
            return string.IsNullOrWhiteSpace(this.RNO) ||string.IsNullOrWhiteSpace(this.FName);
        }
    }
}
