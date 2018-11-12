using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Server.Controllers
{
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        [Route("")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            
            if (exceptionFeature != null)
            {
                string routeWhereExceptionOccurred = exceptionFeature.Path;
                Exception exceptionThatOccurred = exceptionFeature.Error;

                return StatusCode(StatusCodes.Status500InternalServerError, new {
                    statusCode = "500",
                    message = exceptionThatOccurred.Message
                });
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}