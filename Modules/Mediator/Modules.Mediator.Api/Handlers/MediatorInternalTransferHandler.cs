using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.BankAccounts.Core;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;
using Modules.Transfers.Core;
using Modules.Transfers.Core.Dtos;

namespace Modules.Mediator.Api.Handlers;

internal static class MediatorInternalTransferHandler
{
    public static async Task<IResult> CreateInternalTransfer(
        [FromServices] ITransferWrite transferWrite,
        [FromServices] IBankAccountBalanceChecker bankAccountBalanceChecker,
        [FromServices] ITransactionWrite transactionWrite,
        [FromServices] IBankAccountRead bankAccountRead,
        [FromBody] CreateInternalTransferDto request)
    {
        if (request.OriginBankAccountId == request.DestinationBankAccountId)
            return Results.BadRequest("Origin and destination bank accounts must be different");

        var balanceResult = await bankAccountBalanceChecker.CheckBalance(
            new BankAccountBalanceCheckDto(request.OriginBankAccountId, request.Amount)
        );

        return await balanceResult.MatchAsync(
            async accountBalanceCheck => await ManageInternalTransferCheckResult(
                accountBalanceCheck, request, transactionWrite, bankAccountRead, transferWrite),
            err => Task.FromResult(err switch
            {
                GenericErrorResult error => Results.BadRequest(error.Message),
                _ => Results.BadRequest()
            }));
    }

    private static async Task<IResult> ManageInternalTransferCheckResult(
        BankAccountBalanceCheckedDto accountChecked,
        CreateInternalTransferDto request,
        ITransactionWrite transactionWrite,
        IBankAccountRead bankAccountRead,
        ITransferWrite transferWrite)
    {
        if (!accountChecked.IsBalanceSufficent)
            return Results.BadRequest("Saldo insufficiente");

        var now = DateTime.UtcNow;

        return await TryWriteOriginTransaction(request, now, transactionWrite,
            async originTransaction =>
                await TryWriteDestinationTransaction(request, now, transactionWrite,
                    async _ =>
                        await CreateTransferAndReturnResult(
                            request,
                            bankAccountRead,
                            originTransaction,
                            transferWrite
                        )));
    }

    private static async Task<IResult> TryWriteOriginTransaction(
        CreateInternalTransferDto request,
        DateTime now,
        ITransactionWrite transactionWrite,
        Func<CreatedTransactionDto, Task<IResult>> onSuccess)
    {
        var originResult = await transactionWrite.Write(new CreateTransactionDto(
            request.Amount,
            now,
            request.Description,
            "transfer",
            request.OriginBankAccountId
        ));

        return await originResult.MatchAsync(onSuccess, err => Task.FromResult(Results.BadRequest(err.Message)));
    }

    private static async Task<IResult> TryWriteDestinationTransaction(
        CreateInternalTransferDto request,
        DateTime now,
        ITransactionWrite transactionWrite,
        Func<CreatedTransactionDto, Task<IResult>> onSuccess)
    {
        var destinationResult = await transactionWrite.Write(new CreateTransactionDto(
            request.Amount,
            now,
            request.Description,
            "income",
            request.DestinationBankAccountId
        ));

        return await destinationResult.MatchAsync(onSuccess, err => Task.FromResult(Results.BadRequest(err.Message)));
    }

    private static async Task<IResult> CreateTransferAndReturnResult(
        CreateInternalTransferDto request,
        IBankAccountRead bankAccountRead,
        CreatedTransactionDto originTransactionDto,
        ITransferWrite transferWrite)
    {
        var destinationBankAccount = await bankAccountRead.Read(request.DestinationBankAccountId);

        return await destinationBankAccount.MatchAsync<IResult>(
            async destinationAccount =>
            {
                var createTransferDto = new CreateTransferDto(
                    destinationAccount.Iban,
                    destinationAccount.Name,
                    request.Amount,
                    request.Description,
                    request.OriginBankAccountId,
                    originTransactionDto.Id
                );

                var transferResult = await transferWrite.Write(createTransferDto);

                return transferResult.Match<IResult>(
                    _ => Results.Ok(),
                    err => Results.BadRequest(err.Message)
                );
            },
            err => Task.FromResult(Results.BadRequest(err.Message))
        );
    }
}