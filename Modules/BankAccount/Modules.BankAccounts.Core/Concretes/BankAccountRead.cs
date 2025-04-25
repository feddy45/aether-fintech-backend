using LanguageExt;
using Modules.BankAccounts.Core.Dependencies;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Core.Concretes;

internal class BankAccountRead(IBankAccountReader accountReader) : IBankAccountRead
{
    public async Task<Either<ErrorResult, BankAccountDto>> Read(Guid bankAccountId)
    {
        try
        {
            return await accountReader.Read(bankAccountId);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}