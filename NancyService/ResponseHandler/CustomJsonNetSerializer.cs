// ------------------------------------------------------------------------------
// 项目名：NancyService
// 
// 文件名：CustomJsonNetSerializer.cs
// 
// 创建标识：吴来伟 2017-05-08 17:52
// 
// 修改标识：吴来伟2017-05-08 17:52
// 
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using Nancy;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NancyService.ResponseHandler
{
    /// <summary>
    /// 重写序列化 Newtonsoft.Json
    /// </summary>
    public sealed class CustomJsonNetSerializer : JsonSerializer, ISerializer
    {
        public CustomJsonNetSerializer()
        {
            ContractResolver = new DefaultContractResolver();
            DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            DateFormatString = "yyyy-MM-dd HH:mm:ss";
            Formatting = Formatting.None;
            //忽略空项
            //NullValueHandling = NullValueHandling.Ignore;
        }

        public bool CanSerialize(string contentType)
        {
            return contentType.Equals("application/json", StringComparison.OrdinalIgnoreCase);
        }

        public void Serialize<TModel>(string contentType, TModel model, Stream outputStream)
        {
            using (var streamWriter = new StreamWriter(outputStream))
            using (var jsonWriter = new JsonTextWriter(streamWriter))
            {
                Serialize(jsonWriter, model);
            }
        }

        public IEnumerable<string> Extensions { get { yield return "json"; } }
    }
}