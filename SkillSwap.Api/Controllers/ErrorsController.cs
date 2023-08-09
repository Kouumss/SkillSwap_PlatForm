using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SkillSwap.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            // Intercept the error.
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            // return the details of this error
            return Problem(title: exception?.Message, statusCode: 400);
        }
    }
}
