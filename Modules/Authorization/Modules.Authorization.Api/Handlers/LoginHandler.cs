using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Authorization.Core;
using Modules.Authorization.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Authorization.Api.Handlers;

internal static class LoginHandler
{
    public static async Task<IResult> Login([FromServices] IAuthenticator authenticator, [FromBody] LoginUserDto user)
    {
        var result = await authenticator.Authenticate(user);

        return result.Match(
            token => Results.Ok(token),
            err => err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            });
    }
}