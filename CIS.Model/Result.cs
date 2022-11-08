namespace CIS.Model
{
    /// <summary>
    /// 结果对象
    /// </summary>
    /// <typeparam name="TValue">返回值类型</typeparam>
    public class Result<TValue> where TValue:class
    {
        /// <summary>
        /// 返回值状态 是否成功
        /// </summary>
        public bool Success { get; private set; }
        /// <summary>
        /// 返回值
        /// </summary>
        public TValue Value { get; private set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// 初始化结果对象
        /// </summary>
        /// <param name="value">返回结果值</param>
        /// <param name="success">是否成功</param>
        /// <param name="message">返回消息文本</param>
        public Result(TValue value,bool success=true,string message="")
        {
            Value = value;
            Message = message;
            Success = success;
        }
    }

}
