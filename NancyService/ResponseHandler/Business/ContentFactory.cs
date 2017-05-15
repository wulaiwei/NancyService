// ------------------------------------------------------------------------------
// 项目名：NancyService
// 
// 文件名：ContentFactory.cs
// 
// 创建标识：吴来伟 2017-05-12 16:31
// 
// 修改标识：吴来伟2017-05-12 16:31
// 
// ------------------------------------------------------------------------------

using System;
using System.IO;
using Nancy;
using NancyService.ResponseHandler.Enum;

namespace NancyService.ResponseHandler.Business
{
    /// <summary>
    /// 内容工厂
    /// </summary>
    public static class ContentFactory
    {
        /// <summary>
        /// 构建内容
        /// </summary>
        /// <param name="response"></param>
        /// <param name="serializer"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Action<Stream> BuildContent(this Response response, ISerializer serializer, object model)
        {
            var contentType = response.ContentType;

            switch (GetResponseType(contentType))
            {
                case ResponseType.Xml:
                    response.Contents = GetXmlContents(model, serializer);
                    break;
                default:
                    response.Contents = GetJsonContents(model, serializer);
                    break;
            }
            return response.Contents;
        }

        /// <summary>
        /// 序列化json
        /// </summary>
        /// <param name="model"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        private static Action<Stream> GetJsonContents(object model, ISerializer serializer)
        {
            return stream => serializer.Serialize("application/json", model, stream);
        }

        /// <summary>
        /// 序列化json
        /// </summary>
        /// <param name="model"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        private static Action<Stream> GetXmlContents(object model, ISerializer serializer)
        {
            return stream => serializer.Serialize("application/xml", model, stream);
        }

        /// <summary>
        /// 构建ResponseType
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static ResponseType GetResponseType(string contentType)
        {
            var responseType = ResponseType.None;
            switch (contentType)
            {
                case "application/json":
                    responseType= ResponseType.Json;
                    break;
                case "application/xml":
                    responseType = ResponseType.Xml;
                    break;
            }
            return responseType;
        }

    }
}