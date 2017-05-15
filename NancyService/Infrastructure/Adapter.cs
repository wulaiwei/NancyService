﻿// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。 
// 项目名：NancyService 
// 文件名：Adapter.cs
// 创建标识：吴来伟 2017-04-27
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------
#region <USINGs>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Builder;

#endregion

namespace NancyService.Infrastructure
{

    /// <summary>
    /// Jexus/TinyFox OWIN适配器
    /// </summary>
    internal class Adapter
    {
        /*************************************
         * 这是一个比较完整的适配器示例
         * ***********************************/


        /// <summary>
        /// OWIN 应用程序委托
        /// </summary>
        static Func<IDictionary<string, object>, Task> _owinApp;


        /// <summary>
        /// 适配器构造函数
        /// </summary>
        public Adapter()
        {

            //实例化一个应用程序生成器
            var builder = new AppBuilder();



            // 为生成器添加一些参数
            // 因某些OWIN框架需要从该参数中得到一些初始化环境信息
            // 这些信息可以包括 如“owin版本”“服务器功”能等等
            var properties = builder.Properties;
            properties["owin.Version"] = "1.0";  // 只能是1.0

            var disposeSource = new CancellationTokenSource();
            properties["server.OnDispose"] = disposeSource.Token;

            Func<Task> svrInitCallback = null;
            Action<Func<Task>> init = (callback) => { svrInitCallback = callback; };
            properties["server.OnInit"] = init;
            //.......

            var capabilities = properties.ContainsKey("server.Capabilities") ? properties["server.Capabilities"] as IDictionary<string, object> : new Dictionary<string, object>();
            properties["server.Capabilities"] = capabilities;
            if (capabilities != null) capabilities["server.Name"] = "TinyFox";
            //capabilities["websocket.Version"] = "1.0";
            //......



            //实例化用户的启动类，并调用配置方法
            //如果用户启动类在其它的dll中，就需要通过反射找出这个类
            var startup = new Startup();
            startup.Configuration(builder);

            //构建OWIN应用并获取该应用的代理（委托）方法
            _owinApp = builder.Build();


            //要求应用程序域退出时，向本类发出通知
            AppDomain.CurrentDomain.DomainUnload += ((o, e) => { disposeSource.Cancel(); });

            //回调应用层初始化函数
            svrInitCallback?.Invoke().Wait();
        }


        /// <summary>
        /// *** Jexus/TinyFox所需要的关键函数 ***
        /// </summary>
        /// <param name="env">新请求的环境字典，具体内容参见OWIN标准</param>
        /// <returns>返回一个正在运行或已经完成的任务</returns>
        public Task OwinMain(IDictionary<string, object> env)
        {
            return _owinApp?.Invoke(env);
        }
    } //end class


} //end namespace
