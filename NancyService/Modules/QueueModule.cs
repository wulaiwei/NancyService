// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。 
// 项目名：NancyService 
// 文件名：UserModule.cs
// 创建标识：吴来伟 2017-04-24
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Nancy;
using Nancy.Responses.Negotiation;
using NancyService.Model;
using  Newtonsoft.Json;
using NancyService.ResponseHandler;
using NancyService.Util;


namespace NancyService.Modules
{
    public class QueueModule : BaseModule
    {
        /// <summary>
        /// 队列接口
        /// </summary>
        public QueueModule()
        {
            //查询
            Get["/Queue/Detail/{id:int}"] = p =>
            {
                var id = (int)p.id;
                using (var db = DbContext.CreateInstance())
                {
                    var info = db.Get<Queue>(id);
                    
                    return Response.AsJson(info);
                }
            };

            //查询
            Get["/Queue/Index"] = p =>
            {
                using (var db = DbContext.CreateInstance())
                {
                    var info = db.GetList<Queue>();

                    return info;
                }
            };

            //列表
            Get["/Queue/Code/{code}"] = p =>
            {
                var code= (string)p.code;
                var num = Totp.GenerateCode(code);

                return Negotiate.WithModel(num);
            };

            Get[@"/"] = _ => View["firstView/hellonancy"];
        }
    }
}