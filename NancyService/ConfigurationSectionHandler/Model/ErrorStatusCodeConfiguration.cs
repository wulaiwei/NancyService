using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyService.ConfigurationSectionHandler.Model
{
    /// <summary>
    /// ErrorStatusCodeConfiguration
    /// </summary>
    public class ErrorStatusCodeConfiguration
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

    }
}