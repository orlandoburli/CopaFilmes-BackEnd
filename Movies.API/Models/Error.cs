using System.Net;

namespace Movies.API.Models
{
    public class Error
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
