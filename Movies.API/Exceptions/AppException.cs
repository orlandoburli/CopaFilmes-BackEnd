using System;
using System.Net;

namespace Movies.API.Exceptions
{
    public class AppException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }

        public AppException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
        }
    }
}