using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.BankAccounts.Core;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Api.Handlers;

internal static class BankAccountsHandler
{
    public static async Task<IResult> GetBankAccounts([FromServices] IBankAccountsRead accountsRead,
        HttpContext context)
    {
        var userIdString = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                           ?? context.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        if (userIdString == null) return Results.BadRequest("UserId not found in token");

        var result = await accountsRead.Read(Guid.Parse(userIdString));

        return result.Match(Results.Ok,
            err => err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            });
    }
}