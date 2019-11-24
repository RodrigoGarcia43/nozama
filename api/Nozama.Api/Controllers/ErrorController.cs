using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ScientificEvents.Api.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var ex = feature.Error;

            return Problem(
                detail: ex.Message,
                statusCode: (int)HttpStatusCode.InternalServerError,
                title: "An internal server error has occurred."
            );
        }
    }
}
