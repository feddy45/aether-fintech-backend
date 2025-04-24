using LanguageExt;
using Modules.BankAccounts.Core.Dependencies;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Core.Concretes;

internal class BankAccountsRead(IBankAccountsReader accountReader) : IBankAccountsRead
{
    public async Task<Either<ErrorResult, BankAccountListDto>> Read(Guid userId)
    {
        try
        {
            return await accountReader.Read(userId);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}