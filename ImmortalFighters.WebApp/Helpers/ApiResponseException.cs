using System;
using System.Runtime.Serialization;

namespace ImmortalFighters.WebApp.Helpers
{
    public class ApiResponseException : Exception
    {
        public int StatusCode { get; set; }
        public string ClientMessage { get; set; }

        public ApiResponseException()
        {
            StatusCode = 400;
            ClientMessage = "Tohle bude nějaká zlá chyba ...";
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
