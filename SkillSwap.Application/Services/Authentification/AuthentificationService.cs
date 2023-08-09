using SkillSwap.Application.Common.Interface.Authentification;

namespace SkillSwap.Application.Services.Authentification;

public class AuthentificationService : IAuthentificationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthentificationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthentificationResult Login(string email, string password)
    {
        return new AuthentificationResult(
           Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token");
    }

    public AuthentificationResult Register(string firstname, string lastname, string email, string password)
    {
        //Check if user already exists
        //Create user (generate unique ID)
        //Create JWT token

        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstname, lastname);

        return new AuthentificationResult(
            Guid.NewGuid(),
            firstname,
            lastname,
            email,
            token);
    }
}