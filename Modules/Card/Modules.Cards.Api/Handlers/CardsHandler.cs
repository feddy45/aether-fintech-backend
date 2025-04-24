using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Cards.Core;
using Modules.Shared.Results;

namespace Modules.Cards.Api.Handlers;

internal static class CardsHandler
{
    public static async Task<IResult> GetCards([FromQuery] Guid bankAccountId, [FromServices] ICardsRead cardsRead)
    {
        var result = await cardsRead.Read(bankAccountId);

        return result.Match(Results.Ok,
            err => err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            });
    }
}