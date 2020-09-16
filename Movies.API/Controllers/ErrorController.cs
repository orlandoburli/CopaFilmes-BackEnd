using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Exceptions;
using Movies.API.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        public ErrorController() : base()
        {

        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>().Error;

            var code = HttpStatusCode.InternalServerError;

            if (exception is AppException)
            {
                code = ((AppException)exception).HttpStatusCode;
            }

            return StatusCode((int)code, new Error() { Message = exception.Message, StatusCode = code });
        }

        [HttpPost]
        public IActionResult Post()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>().Error;

            var code = HttpStatusCode.InternalServerError;

            if (exception is AppException)
            {
                code = ((AppException)exception).HttpStatusCode;
            }

            return StatusCode((int)code, new Error() { Message = exception.Message, StatusCode = code });
        }
    }
}
