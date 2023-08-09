namespace SkillSwap.Application.Common.Interface.Authentification;


public interface IJwtTokenGenerator {
    string GenerateToken(Guid userId, string firstName, string lastName);
}
