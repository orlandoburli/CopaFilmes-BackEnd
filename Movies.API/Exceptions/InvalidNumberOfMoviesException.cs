using System.Net;

namespace Movies.API.Exceptions
{
    public class InvalidNumberOfMoviesException : AppException
    {
        public InvalidNumberOfMoviesException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
