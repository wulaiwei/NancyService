using Nancy;
using NancyService.ConfigurationSectionHandler.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace NancyService.ConfigurationSectionHandler
{
    public class ErrorStatusCodeConfigurationSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            var propertyNodeList = section.SelectNodes("statusCodeHandlerResult");

            var propertyData = new List<ErrorStatusCodeConfiguration>();

            if (propertyNodeList == null) return null;
            foreach (XmlElement propertyNode in propertyNodeList)
            {
                var errorStatusCodeConfiguration = new ErrorStatusCodeConfiguration()
                {
                    HttpStatusCode= (HttpStatusCode)Enum.Parse(
                        typeof(HttpStatusCode), propertyNode.GetAttribute("statusCode")),

                    Message= propertyNode.GetAttribute("message"),
                    Url= propertyNode.GetAttribute("url"),
                };
                propertyData.Add(errorStatusCodeConfiguration);

            }

            return propertyData;
        }
    }
}