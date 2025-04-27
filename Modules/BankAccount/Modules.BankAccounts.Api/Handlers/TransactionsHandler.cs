using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.BankAccounts.Core;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Api.Handlers;

internal static class TransactionsHandler
{
    public static async Task<IResult> GetTransactions([FromServices] ITransactionsRead transactionsRead,
        [FromRoute] Guid bankAccountId, [FromQuery] string? cards)
    {
        List<Guid> cardIds = new();

        if (cards is not null)
            cardIds = cards
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(x => Guid.Parse(x))
                .ToList();

        var result = await transactionsRead.Read(bankAccountId, cardIds);

        return result.Match(Results.Ok,
            err => err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            });
    }
}