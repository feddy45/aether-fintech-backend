using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modules.Authorization.Core.Dependencies;
using Modules.Authorization.DataAccess.DatabaseModels;
using Modules.Authorization.DataAccess.Entities;
using Modules.Shared.DependencyInjection;
using Modules.Shared.Models;

namespace Modules.Authorization.DataAccess;

public class AuthorizationDataAccessDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddDbContext<UsersDbContext>((serviceProvider, options) =>
            {
                var connectionString = serviceProvider.GetRequiredService<ConnectionString>();
                options.UseNpgsql(connectionString.Value);
            }
        );

        services.AddScoped<IUserReader, UserReader>();
        services.AddScoped<IJwtCreator, JwtCreator>();
        services.AddScoped<IPasswordChange, PasswordChange>();
        services.AddScoped<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
    }
}