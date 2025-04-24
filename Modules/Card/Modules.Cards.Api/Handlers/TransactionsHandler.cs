using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Cards.Core;
using Modules.Shared.Results;

namespace Modules.Cards.Api.Handlers;

internal static class TransactionsHandler
{
    public static async Task<IResult> GetTransactions([FromServices] ITransactionsRead transactionsRead,
        [FromRoute] Guid cardId)
    {
        var result = await transactionsRead.Read(cardId);

        return result.Match(Results.Ok,
            err => err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            });
    }
}