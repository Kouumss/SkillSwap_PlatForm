using System.Net;

namespace SkillSwap.Application.Common.Errors;

public class LoginErrorException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

    public string ErrorMessage => "User with given email does not exist.";
}