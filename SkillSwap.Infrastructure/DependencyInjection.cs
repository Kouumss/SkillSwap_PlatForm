using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillSwap.Application.Common.Interface.Authentification;
using SkillSwap.Application.Common.Interfaces.Persistence;
using SkillSwap.Application.Common.Interfaces.Services;
using SkillSwap.Infrastructure.Authentification;
using SkillSwap.Infrastructure.Persistence;
using SkillSwap.Infrastructure.Services;

namespace SkillSwap.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
      ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeprovider, DateTimeProvider>();


        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
} 