using System.Net;

namespace Movies.API.Exceptions
{
    public class MovieAPINotAvailableException : AppException
    {
        public MovieAPINotAvailableException(string message) : base(message, HttpStatusCode.ServiceUnavailable)
        {
        }
    }
}