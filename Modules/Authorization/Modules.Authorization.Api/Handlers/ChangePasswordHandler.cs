using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Authorization.Core;
using Modules.Authorization.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Authorization.Api.Handlers;

internal static class ChangePasswordHandler
{
    public static async Task<IResult> ChangePassword([FromServices] IPasswordChanger passwordChanger,
        [FromBody] ChangePasswordDto changePassword, HttpContext context)
    {
        var userIdString = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                           ?? context.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        if (userIdString == null) return Results.BadRequest("UserId not found in token");

        var result = await passwordChanger.ChangePassword(Guid.Parse(userIdString), changePassword);

        return result.Match(
            token => Results.Ok(result),
            err => err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            });
    }
}