using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.BankAccounts.Core;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;
using Modules.Transfers.Core;
using Modules.Transfers.Core.Dtos;

namespace Modules.Mediator.Api.Handlers;

internal static class MediatorTransfersHandler
{
    public static async Task<IResult> CreateTransfer(
        [FromServices] ITransferWrite transferWrite,
        [FromServices] IBankAccountBalanceChecker bankAccountBalanceChecker,
        [FromServices] ITransactionWrite transactionWrite,
        [FromBody] CreateTransferDto request)
    {
        var balanceResult = await bankAccountBalanceChecker.CheckBalance(
            new BankAccountBalanceCheckDto(request.CardId, request.Amount)
        );

        return await balanceResult.MatchAsync(
            async cardBalanceCheck => await ManageCheckResultAsync(
                cardBalanceCheck, request, transactionWrite, transferWrite),
            err => Task.FromResult(err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            }));
    }

    private static async Task<IResult> ManageCheckResultAsync(
        BankAccountBalanceCheckedDto accountChecked,
        CreateTransferDto request,
        ITransactionWrite transactionWrite,
        ITransferWrite transferWrite)
    {
        if (!accountChecked.IsBalanceSufficent)
            return Results.BadRequest("Saldo insufficiente");

        var transactionResult = await transactionWrite.Write(new CreateTransactionDto(
            request.Amount,
            DateTime.UtcNow,
            request.Description,
            "transfer",
            request.CardId
        ));

        return await transactionResult.MatchAsync(
            async transaction =>
            {
                if (transaction == null)
                    return Results.BadRequest("Errore nella creazione della transazione");

                var result = await transferWrite.Write(request);
                return result.Match<IResult>(
                    _ => Results.Ok(),
                    err => err switch
                    {
                        GenericErrorResult error => Results.BadRequest(error.Message),
                        _ => Results.BadRequest()
                    });
            },
            err => Task.FromResult(err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            }));
    }
}