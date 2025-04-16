using Microsoft.Extensions.DependencyInjection;
using Modules.Authorization.Core.Concretes;
using Modules.Shared.DependencyInjection;

namespace Modules.Authorization.Core;

public class AuthorizationCoreDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddScoped<IAuthenticator, Authenticator>();
        services.AddScoped<IPasswordChanger, PasswordChanger>();
    }
}