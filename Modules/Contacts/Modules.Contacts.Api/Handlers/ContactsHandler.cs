using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Contacts.Core;
using Modules.Shared.Results;

namespace Modules.Contacts.Api.Handlers;

internal static class ContactsHandler
{
    public static async Task<IResult> GetContacts([FromServices] IContactsRead contactsRead)
    {
        var result = await contactsRead.Read();

        return result.Match(Results.Ok,
            err => err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            });
    }
}