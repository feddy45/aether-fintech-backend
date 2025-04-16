using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Authorization.Core;
using Modules.Authorization.Core.Dtos;

namespace Modules.Authorization.Api.Handlers;

internal static class LoginHandler
{
    public static async Task<IResult> Login([FromServices] IAuthenticator authenticator, [FromBody] LoginUserDto user)
    {
        var result = await authenticator.Authenticate(user);

        return result.Match(
            token => Results.Ok(new { token }),
            _ => Results.Unauthorized()
        );
    }
}