using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Nancy;
using Owin;

namespace NancyService.Infrastructure
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseNancy();//增加Nancy 中间件到Owin管线；
            StaticConfiguration.DisableErrorTraces = false;
        }
    }
}