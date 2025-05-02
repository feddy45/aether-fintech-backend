using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.BankAccounts.Core;
using Modules.BankAccounts.Core.Dtos;
using Modules.BankAccounts.Core.Enums;
using Modules.Shared.Results;
using Modules.Transfers.Core;
using Modules.Transfers.Core.Dtos;

namespace Modules.Mediator.Api.Handlers;

internal static class MediatorBankTransferHandler
{
    public static async Task<IResult> CreateBankTransfer(
        [FromServices] ITransferWrite transferWrite,
        [FromServices] IBankAccountBalanceChecker bankAccountBalanceChecker,
        [FromServices] ITransactionWrite transactionWrite,
        [FromBody] CreateBankTransferDto request)
    {
        var balanceResult = await bankAccountBalanceChecker.CheckBalance(
            new BankAccountBalanceCheckDto(request.BankAccountId, request.Amount)
        );

        return await balanceResult.MatchAsync(
            async accountBalanceCheck => await ManageBankTransferCheckResult(
                accountBalanceCheck, request, transactionWrite, transferWrite),
            err => Task.FromResult(err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            }));
    }

    private static async Task<IResult> ManageBankTransferCheckResult(
        BankAccountBalanceCheckedDto accountChecked,
        CreateBankTransferDto request,
        ITransactionWrite transactionWrite,
        ITransferWrite transferWrite)
    {
        if (!accountChecked.IsBalanceSufficent)
            return Results.BadRequest("Saldo insufficiente");

        var transactionResult = await transactionWrite.Write(new CreateTransactionDto(
            request.Amount,
            DateTime.UtcNow,
            request.Description,
            TransactionType.Transfer,
            request.BankAccountId
        ));

        return await transactionResult.MatchAsync(
            async transaction =>
            {
                if (transaction == null)
                    return Results.BadRequest("Errore nella creazione della transazione");

                var createTransferDto = new CreateTransferDto(
                    request.Iban,
                    request.Beneficiary,
                    request.Amount,
                    request.Description,
                    request.BankAccountId,
                    transaction.Id
                );

                var result = await transferWrite.Write(createTransferDto);
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