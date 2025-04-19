using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Modules.Authorization.Api.Handlers;
using Modules.Shared.DependencyInjection;

namespace Modules.Authorization.Api;

public class AuthorizationEndpointsMapper : IEndpointMapper
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var authRoutes = endpoints.MapGroup("auth").WithTags("Authorization");

        authRoutes.MapPost("login", LoginHandler.Login).AllowAnonymous();
        authRoutes.MapPost("change-password", ChangePasswordHandler.ChangePassword).RequireAuthorization();

        return endpoints;
    }
}