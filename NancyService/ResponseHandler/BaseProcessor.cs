// ------------------------------------------------------------------------------
// 项目名：NancyService
// 
// 文件名：BaseProcessor.csQQ
// 
// 创建标识：吴来伟 2017-05-08 12:05
// 
// 修改标识：吴来伟2017-05-08 12:05
// 
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Responses.Negotiation;

namespace NancyService.ResponseHandler
{
    /// <summary>
    /// 在Constructor简单的工作了它需要哪些串行器。
    /// ExtensionMapping指定在调用处理器的请求时可以使用哪个扩展名。
    /// 即如果您不能通过接受标题，您可以结束url .csv并处理器将被调用！
    /// CanProcess 检查是否可以处理请求。
    /// 最后Process简单地处理请求。
    /// </summary>
    public class BaseProcessor : IResponseProcessor
    {
        private readonly ISerializer _serializer;

        private readonly IEnumerable< MediaRange> _extensionMappings =
            new[] {
                #pragma warning disable 618
                     MediaRange.FromString("application/json"),
                     MediaRange.FromString("application/xml")
                #pragma warning restore 618
            };

        private const string MediaType = "application/json";

        public BaseProcessor(IEnumerable<Tuple<string, MediaRange>> extensionMappings, ISerializer serializer)
        {
            ExtensionMappings = extensionMappings;
            _serializer = serializer;
        }

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            var requestedContentTypeResult = _extensionMappings.Any(
                r => r.MatchesWithParameters(requestedMediaRange)) ?
                MatchResult.ExactMatch : MatchResult.NoMatch;

            return new ProcessorMatch
            {
                ModelResult = MatchResult.DontCare,
                RequestedContentTypeResult = MatchResult.ExactMatch
            };
        }

        public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            if (requestedMediaRange.ToString()== "text/html")
            {
                return new Response() {};
            }
            var info = new BaseResponse(
                model,
                context,
                this._serializer,
                MediaType);
            return info;
        }

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings { get; }
    }
}