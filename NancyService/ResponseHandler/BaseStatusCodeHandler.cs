// ------------------------------------------------------------------------------
// 项目名：NancyService
// 
// 文件名：BaseErrorHandler.cs
// 
// 创建标识：吴来伟 2017-05-08 22:40
// 
// 修改标识：吴来伟 2017-05-08 22:40
// 
// ------------------------------------------------------------------------------

using Nancy;
using Nancy.ErrorHandling;
using Nancy.ViewEngines;
using NancyService.ConfigurationSectionHandler.Model;
using System.Collections.Generic;
using System.Linq;

namespace NancyService.ResponseHandler
{
    public class BaseStatusCodeHandler : IStatusCodeHandler
    {
        public static IEnumerable<ErrorStatusCodeConfiguration> Checks { get; private set; } = new List<ErrorStatusCodeConfiguration>();

        private static readonly string _defaultError="/Error/error.html";

        /// <summary>
        /// 视图
        /// </summary>
        private readonly IViewRenderer _viewRenderer;
        public BaseStatusCodeHandler(IViewRenderer viewRenderer)
        {
            this._viewRenderer = viewRenderer;
        }

        /// <summary>
        /// 状态值为True 则执行Handle   为False则执行Response
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            var info = false;
            if (context.Response!=null)
            {
                return info;
            }

            if (context.NegotiationContext.StatusCode!=null)
            {
                info = (Checks.Any(x => x.HttpStatusCode == context.NegotiationContext.StatusCode)
                || context.NegotiationContext.StatusCode != HttpStatusCode.OK);
            }else
            {
                info = (Checks.Any(x => x.HttpStatusCode == statusCode)
              || statusCode != HttpStatusCode.OK);
            }

            return info;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="context"></param>
        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var errorStatusCodeConfiguration = Checks
                .FirstOrDefault(x => x.HttpStatusCode == statusCode);

            context.Response.ContentType = "text/html";
            context.Response.StatusCode = statusCode;
            var url = _defaultError;
            if (errorStatusCodeConfiguration!=null)
            {
                url = errorStatusCodeConfiguration?.Url;
            }
            var response = _viewRenderer.RenderView(context, url);

            context.Response = response;
        }

        #region 状态码更改
        public static void AddCode(ErrorStatusCodeConfiguration code)
        {
            AddCode(new List<ErrorStatusCodeConfiguration>() { code });
        }
        public static void AddCode(IEnumerable<ErrorStatusCodeConfiguration> code)
        {
            Checks = Checks.Union(code);
        }
        public static void RemoveCode(HttpStatusCode httpStatusCode)
        {
            var code = Checks.Where(x => x.HttpStatusCode == httpStatusCode).FirstOrDefault();
            RemoveCode(new List<ErrorStatusCodeConfiguration>() { code });
        }
        public static void RemoveCode(IEnumerable<ErrorStatusCodeConfiguration> code)
        {
            Checks = Checks.Except(code);
        }
        public static void Disable()
        {
            Checks = new List<ErrorStatusCodeConfiguration>();
        }

        #endregion
    }
}