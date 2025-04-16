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

        authRoutes.MapGet("login", LoginHandler.Login).AllowAnonymous();
        authRoutes.MapGet("change-password", ChangePasswordHandler.ChangePassword).RequireAuthorization();

        return endpoints;
    }
}