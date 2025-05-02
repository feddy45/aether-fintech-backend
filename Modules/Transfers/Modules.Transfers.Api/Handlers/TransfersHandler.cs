using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Shared.Results;
using Modules.Transfers.Core;

namespace Modules.Transfers.Api.Handlers;

internal static class TransfersHandler
{
    public static async Task<IResult> GetTransfers([FromServices] ITransfersRead transfersRead, HttpContext context)
    {
        var userIdString = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                           ?? context.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        if (userIdString == null) return Results.BadRequest("UserId not found in token");
        var result = await transfersRead.Read(Guid.Parse(userIdString));

        return result.Match(Results.Ok,
            err => err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            });
    }
}