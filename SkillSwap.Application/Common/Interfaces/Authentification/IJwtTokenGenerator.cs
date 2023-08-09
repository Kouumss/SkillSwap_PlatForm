using SkillSwap.Domain.Entities;

namespace SkillSwap.Application.Common.Interface.Authentification;


public interface IJwtTokenGenerator {
    string GenerateToken(User user);
}
