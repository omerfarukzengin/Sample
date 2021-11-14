using System;
using System.Net;
using System.Runtime.Serialization;

namespace Sample.Shared.Exceptions
{
    [Serializable]
    public class AppException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.BadRequest;

        public AppException(string message) : base(message)
        {
        }
        protected AppException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
