using System;
using System.Runtime.Serialization;

namespace BlazorProducts.Client.HttpInterceptor
{
    [Serializable]
    public class HttpResponseException : Exception
    {
        public HttpResponseException()
        {
            
        }

        public HttpResponseException(string message): base(message)
        {
            
        }

        public HttpResponseException(string message, Exception innerException): base(message, innerException)
        {
            
        }

        public HttpResponseException(SerializationInfo info, StreamingContext context): base(info, context)
        {
            
        }
    }
}