using System.Net;

namespace FLY.Business.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode statusCode {  get; private set; }

        public ApiException(HttpStatusCode statusCode, string message) : base(message)
        {
            this.statusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode, string message, Exception exception) : base(message, exception)
        {
            this.statusCode = statusCode;
        }
    }
}
