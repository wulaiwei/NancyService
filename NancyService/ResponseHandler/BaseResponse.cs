// ------------------------------------------------------------------------------
// 项目名：NancyService
// 
// 文件名：BaseResponse.cs
// 
// 创建标识：吴来伟 2017-05-08 10:24
// 
// 修改标识：吴来伟2017-05-08 10:24
// 
// ------------------------------------------------------------------------------

using System;
using System.IO;
using System.Threading.Tasks;
using Nancy;
using NancyService.Model;
using NancyService.ResponseHandler.Business;
using NancyService.ResponseHandler.Model;
using Newtonsoft.Json;
using ServiceStack;

namespace NancyService.ResponseHandler
{
    public class BaseResponse<T> : Response
    {
        public BaseResponse(object model, ISerializer serializer, NancyContext context, string mediaType)
        {
            if (serializer == null) { throw new InvalidOperationException("Serializer not set"); }
            var responseModel = ResponseProvider.Success(model);

            this.ContentType = mediaType;
            this.Contents = this.BuildContent(serializer,responseModel);
        }
    }

    public class BaseResponse : BaseResponse<object>
    {
        public BaseResponse(object model, NancyContext context, ISerializer serializer,string mediaType) : base(model,serializer, context, mediaType)
        {
        }
    }
}