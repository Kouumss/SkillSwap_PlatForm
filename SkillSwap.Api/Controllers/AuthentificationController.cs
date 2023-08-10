using Microsoft.AspNetCore.Mvc;
using SkillSwap.Application.Services.Authentification;
using SkillSwap.Contracts.Authentification;

namespace SkillSwap.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthentificationController : ControllerBase
{

    private readonly IAuthentificationService _authentificationService;

    public AuthentificationController(IAuthentificationService authentificationService)
    {
        _authentificationService = authentificationService;
    }


    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authentificationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthentificationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authentificationService.Login(

            request.Email,
            request.Password
        );

        var response = new AuthentificationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token
        );

        return Ok(response);
    }
}