using LanguageExt;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Core;

public interface IBankAccountBalanceChecker
{
    Task<Either<ErrorResult, BankAccountBalanceCheckedDto>> CheckBalance(BankAccountBalanceCheckDto checkDto);
}