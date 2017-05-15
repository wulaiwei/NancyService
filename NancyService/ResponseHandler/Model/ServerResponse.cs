// ------------------------------------------------------------------------------
// 
// 项目名：NancyService
// 
// 文件名：ServerResponse.cs
// 
// 
// 
// 创建标识：吴来伟 2017-05-05 14:58
// 
// 
// 
// 修改标识：吴来伟2017-05-05 15:11
// 
// 
// 
// ------------------------------------------------------------------------------

namespace NancyService.ResponseHandler.Model
{
    /// <summary>
    ///     接口返回值
    /// </summary>
    public class ServerResponse
    {
        /// <summary>
        ///     状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        ///     描述信息
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    ///     响应消息类
    /// </summary>
    public class ServerResponse<T> : ServerResponse
        where T : class, new()
    {
        /// <summary>
        ///     业务数据对象
        /// </summary>
        public T Data { get; set; }
    }
}