using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyService.Extensions.Exceptions
{
    [Serializable]
    public class NancyServiceException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        public NancyServiceException()
        {

        }

        /// <summary>
        /// Creates a new <see cref="NancyServiceException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public NancyServiceException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="NancyServiceException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public NancyServiceException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}