using System;
using System.Runtime.Serialization;

namespace ImmortalFighters.WebApp.Helpers
{
    public class ApiResponseException : Exception
    {
        public int HttpResponseCode { get; set; }
        public string ClientMessage { get; set; }

        public ApiResponseException()
        {
        }

        public ApiResponseException(string message) : base(message)
        {
        }

        public ApiResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
