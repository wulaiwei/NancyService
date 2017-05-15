// ------------------------------------------------------------------------------
// 项目名：NancyService
// 
// 文件名：BaseErrorHandler.cs
// 
// 创建标识：吴来伟 2017-05-08 22:40
// 
// 修改标识：吴来伟2017-05-08 22:40
// 
// ------------------------------------------------------------------------------

using Nancy;
using Nancy.ErrorHandling;
using Nancy.IO;
using Nancy.ViewEngines;
using NancyService.ConfigurationSectionHandler.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NancyService.ResponseHandler
{
    public class BaseStatusCodeHandler : IStatusCodeHandler
    {
        private static IEnumerable<ErrorStatusCodeConfiguration> _checks = new List<ErrorStatusCodeConfiguration>();
        public static IEnumerable<ErrorStatusCodeConfiguration> Checks { get { return _checks; } }

        private static readonly string _defaultError="/Error/error.html";

        /// <summary>
        /// 视图
        /// </summary>
        private IViewRenderer viewRenderer;
        public BaseStatusCodeHandler(IViewRenderer viewRenderer)
        {
            this.viewRenderer = viewRenderer;
        }

        /// <summary>
        /// 状态值为True 则执行Handle   为False则执行Response
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return (_checks.Any(x => x.HttpStatusCode == statusCode)||statusCode !=HttpStatusCode.OK);
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="context"></param>
        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var errorStatusCodeConfiguration = _checks.Where(x => x.HttpStatusCode == statusCode)
                .FirstOrDefault();

            context.Response.ContentType = "text/html";
            context.Response.StatusCode = statusCode;
            var url = _defaultError;
            if (errorStatusCodeConfiguration!=null)
            {
                url = errorStatusCodeConfiguration?.Url;
            }
            var response = viewRenderer.RenderView(context, url);

            context.Response = response;
        }

        #region 状态码更改
        public static void AddCode(ErrorStatusCodeConfiguration code)
        {
            AddCode(new List<ErrorStatusCodeConfiguration>() { code });
        }
        public static void AddCode(IEnumerable<ErrorStatusCodeConfiguration> code)
        {
            _checks = _checks.Union(code);
        }
        public static void RemoveCode(HttpStatusCode httpStatusCode)
        {
            var code = _checks.Where(x => x.HttpStatusCode == httpStatusCode).FirstOrDefault();
            RemoveCode(new List<ErrorStatusCodeConfiguration>() { code });
        }
        public static void RemoveCode(IEnumerable<ErrorStatusCodeConfiguration> code)
        {
            _checks = _checks.Except(code);
        }
        public static void Disable()
        {
            _checks = new List<ErrorStatusCodeConfiguration>();
        }

        #endregion
    }
}