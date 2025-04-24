using LanguageExt;
using Modules.BankAccounts.Core.Dependencies;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Core.Concretes;

internal class BankAccountBalanceChecker(IBankAccountsReader bankAccountReader) : IBankAccountBalanceChecker
{
    public async Task<Either<ErrorResult, BankAccountBalanceCheckedDto>> CheckBalance(
        BankAccountBalanceCheckDto checkDto)
    {
        try
        {
            return await bankAccountReader.CheckBalance(checkDto);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}