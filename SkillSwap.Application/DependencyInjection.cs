using Microsoft.Extensions.DependencyInjection;
using SkillSwap.Application.Services.Authentification;

namespace SkillSwap.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddScoped<IAuthentificationService, AuthentificationService>();

        return services;
    }
}