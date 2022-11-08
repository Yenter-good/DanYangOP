namespace CIS.Core.Interceptors
{
    /// <summary>
    /// 结果对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataResult<T>
    {
        /// <summary>
        /// 成功后返回值
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// 操作结果是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 详细描述
        /// </summary>
        public string Detail { get; set; }

        internal DataResult()
        {
        }

        public DataResult GetResult()
        {
            if (this.Success)
                return DataResult.True(this.Message);
            else
                return DataResult.Fault(this.Message, this.Detail);
        }

    }
    public class PageResult<T> : DataResult<T>
    {

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; internal set; }
    }
    /// <summary>
    /// 结果对象
    /// </summary>
    public class DataResult
    {
        /// <summary>
        /// 操作结果是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 详细描述
        /// </summary>
        public string Detail { get; set; }

        private DataResult()
        {
        }
        public static DataResult Fault()
        {
            return new DataResult { Success = false, Message = "操作失败" };
        }
        public static DataResult Fault(string errorMessage)
        {
            return new DataResult { Success = false, Message = errorMessage };
        }
        public static DataResult Fault(string errorMessage, string errorDetail)
        {
            return new DataResult { Success = false, Message = errorMessage, Detail = errorDetail };
        }
        /// <summary>
        /// 正确结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DataResult True(string correctMessage = "操作成功")
        {
            return new DataResult { Success = true, Message = correctMessage };
        }

        /// <summary>
        /// 错误结果
        /// </summary>
        /// <param name="errorMessage">简要的错误信息</param>
        /// <param name="errorDetail">错误详细</param>
        /// <returns></returns>
        public static DataResult<T> Fault<T>(string errorMessage, string errorDetail = null, T errorData = default(T))
        {
            return new DataResult<T> { Value = errorData, Success = false, Message = errorMessage, Detail = errorDetail };
        }
        /// <summary>
        /// 正确结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DataResult<T> True<T>(T value, string correctMessage = "操作成功")
        {
            return new DataResult<T> { Success = true, Value = value, Message = correctMessage };
        }

        public static PageResult<T> PageFault<T>(string message, string detail = "")
        {
            return new PageResult<T>() { Success = false, Message = message, Detail = detail };
        }

        /// <summary>
        /// 正确结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static PageResult<T> PageTrue<T>(T value, int totalCount, string message = "操作成功", string detail = "")
        {
            return new PageResult<T> { Success = true, Value = value, Message = message, TotalCount = totalCount, Detail = detail };
        }

    }
}
