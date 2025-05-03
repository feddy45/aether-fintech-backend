using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Contacts.Core;
using Modules.Shared.Results;

namespace Modules.Contacts.Api.Handlers;

internal static class ContactsHandler
{
    public static async Task<IResult> GetContacts([FromServices] IContactsRead contactsRead,
        HttpContext context)
    {
        var userIdString = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                           ?? context.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        if (userIdString == null) return Results.BadRequest("UserId not found in token");

        var result = await contactsRead.Read(Guid.Parse(userIdString));

        return result.Match(Results.Ok,
            err => err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            });
    }
}