using LanguageExt;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Core;

public interface IBankAccountsRead
{
    Task<Either<ErrorResult, BankAccountListDto>> Read(Guid userId);
}