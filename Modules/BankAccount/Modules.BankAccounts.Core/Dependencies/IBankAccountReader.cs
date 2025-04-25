using LanguageExt;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Core.Dependencies;

public interface IBankAccountReader
{
    Task<Either<ErrorResult, BankAccountDto>> Read(Guid bankAccountId);
    Task<Either<ErrorResult, BankAccountBalanceCheckedDto>> CheckBalance(BankAccountBalanceCheckDto checkDto);
}