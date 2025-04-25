using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.BankAccounts.Core;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Api.Handlers;

internal static class TransactionsHandler
{
    public static async Task<IResult> GetTransactions([FromServices] ITransactionsRead transactionsRead,
        [FromRoute] Guid bankAccountId, [FromQuery] Guid? cardId)
    {
        var result = await transactionsRead.Read(bankAccountId, cardId);

        return result.Match(Results.Ok,
            err => err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            });
    }
}