using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace AuthPlayGround
{
    public class HttpStatusCodeException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpStatusCodeException(HttpStatusCode httpStatusCode)
        {
            StatusCode = httpStatusCode;
        }

        public HttpStatusCodeException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            StatusCode = httpStatusCode;
        }

        public HttpStatusCodeException(HttpStatusCode httpStatusCode, Exception inner) : this(httpStatusCode, inner.ToString()) { }

        public HttpStatusCodeException(HttpStatusCode httpStatusCode, JObject errorObject) : this(httpStatusCode, errorObject.ToString())
        {
        }
    }
}
