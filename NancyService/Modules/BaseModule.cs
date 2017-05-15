// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。 
// 项目名：NancyService 
// 文件名：BaseModule.cs
// 创建标识：吴来伟 2017-04-28
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Xml.Schema;
using Nancy;
using WorkData.Util;

namespace NancyService.Modules
{
    public class BaseModule : NancyModule
    {
        public BaseModule(){
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
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}