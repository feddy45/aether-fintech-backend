using LanguageExt;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Core;

public interface IBankAccountRead
{
    Task<Either<ErrorResult, BankAccountDto>> Read(Guid bankAccountId);
}