using System.Net;

namespace SkillSwap.Application.Common.Errors;

public class PasswordErrorException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

    public string ErrorMessage => "Invalid password.";
}