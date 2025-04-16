using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Authorization.Core;
using Modules.Authorization.Core.Dtos;

namespace Modules.Authorization.Api.Handlers;

internal static class ChangePasswordHandler
{
    public static async Task<IResult> ChangePassword([FromServices] IPasswordChanger passwordChanger,
        [FromBody] ChangePasswordDto changePassword)
    {
        var result = await passwordChanger.ChangePassword(changePassword);

        return result.Match(
            token => Results.Ok(result),
            _ => Results.Unauthorized()
        );
    }
}