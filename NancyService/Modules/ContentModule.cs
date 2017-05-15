// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。 
// 项目名：NancyService 
// 文件名：ContentModule.cs
// 创建标识：吴来伟 2017-04-28
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace NancyService.Modules
{
    public class ContentModule : BaseModule
    {
        public ContentModule()
        {
            Get["/content/index"] = p =>
            {
                throw new Exception("safasdf");
                return View["Contnet/Index"];
             };
        }
    }
}