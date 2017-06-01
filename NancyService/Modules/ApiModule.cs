using Nancy;
using NancyService.Extensions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyService.Modules
{
    /// <summary>
    /// API基础Module
    /// </summary>
    public class ApiModule: NancyModule
    {
        public ApiModule() : base("/api")
        {
            //执行之前
            Before += BeforeEvent;

            //执行之后
            After += AfterEvent;

            //异常
            OnError += ErrorEvent;
        }

        /// <summary>
        /// (返回null，继续处理;
        /// 返回Response对象，不再做要干的那件事，换做Response对象要干的事)
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private Response BeforeEvent(NancyContext ctx)
        {
            return null;
        }

        /// <summary>
        /// 处理之后要干的事。
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private void AfterEvent(NancyContext ctx)
        {
        }

        /// <summary>
        /// 异常事件
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private Response ErrorEvent(NancyContext ctx, Exception ex)
        {
            if (ex is UserFriendlyException)
            {
                ctx.NegotiationContext.StatusCode = HttpStatusCode.OK;
            }

            return null;
        }
    }
}