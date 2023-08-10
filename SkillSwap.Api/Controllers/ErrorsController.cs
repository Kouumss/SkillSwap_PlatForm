using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SkillSwap.Application.Common.Errors;

namespace SkillSwap.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            // Intercept the error.
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                // DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exist."),
                // LoginErrorException => (StatusCodes.Status401Unauthorized, "User with given email does not exist."),
                // PasswordErrorException => (StatusCodes.Status401Unauthorized, "Invalid password."),

                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured."),
            };
            
            // return the details of this error
            return Problem(statusCode: statusCode, title: message);
        }
    }
}
