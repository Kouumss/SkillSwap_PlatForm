using SkillSwap.Application.Common.Errors;
using SkillSwap.Application.Common.Interface.Authentification;
using SkillSwap.Application.Common.Interfaces.Persistence;
using SkillSwap.Domain.Entities;

namespace SkillSwap.Application.Services.Authentification;

public class AuthentificationService : IAuthentificationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthentificationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthentificationResult Register(string firstname, string lastname, string email, string password)
    {
        // 1.Validate the user does not exists

        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailException();
        }

        // 2.Create user (generate unique ID)

        var user = new User
        {
            FirstName = firstname,
            LastName = lastname,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // 3.Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthentificationResult(user, token);
    }

    public AuthentificationResult Login(string email, string password)
    {
        // 1. Validate if the user exist;

        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new LoginErrorException();
        }
        // 2. Validate the password is correct.

        if (user.Password != password)
        {
            throw new PasswordErrorException();
        }
        // 3. Create JWT token.
        var token = _jwtTokenGenerator.GenerateToken(user);



        return new AuthentificationResult(user, token);
    }


}