// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。 
// 项目名：NancyService 
// 文件名：Bootstrapper.cs
// 创建标识：吴来伟 2017-04-28
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using NancyService.ResponseHandler;
using WorkData.Util;
using System.Configuration;
using NancyService.ConfigurationSectionHandler.Model;
using System.Collections.Generic;

namespace NancyService.Infrastructure
{
    public class Bootstrapper: DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            //替换默认序列化方式
            container.Register<ISerializer, CustomJsonNetSerializer>();

            //自定义状态码处理
            //var errorStatusCodeConfiguration = (List<ErrorStatusCodeConfiguration>)
            // ConfigurationManager.GetSection("errorStatusCodeConfig");

            //BaseStatusCodeHandler.AddCode(errorStatusCodeConfiguration);

            base.ApplicationStartup(container, pipelines);
        }


        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                var processors = new[]
                {
                    typeof(BaseProcessor)
                 };

                return NancyInternalConfiguration.WithOverrides(x => x.ResponseProcessors = processors);
            }
        }
    }
}