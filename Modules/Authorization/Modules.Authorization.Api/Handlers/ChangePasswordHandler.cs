using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Authorization.Core.Dtos;

namespace Modules.Authorization.Api.Handlers;

internal static class ChangePasswordHandler
{
    public static async Task<IResult> ChangePassword([FromBody] LoginUserDto user)
    {
        return Results.Ok();
    }
}