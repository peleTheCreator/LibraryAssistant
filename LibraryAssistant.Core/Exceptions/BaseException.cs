using System;
using System.Net;

namespace LibraryAssistant.Core.Exceptions
{
    [Serializable]
    public class BaseException : Exception
    {
        public HttpStatusCode httpStatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public BaseException(string message) : base(message)
        {

        }

        public BaseException(HttpStatusCode code , string message, Exception exception) : base(message, exception)
        {
            code = httpStatusCode;
        }
        public BaseException(HttpStatusCode code, string message) : base(message)
        {
            httpStatusCode = code;
        }
    }
}
