namespace SkillSwap.Application.Services.Authentification;

public record AuthentificationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);
