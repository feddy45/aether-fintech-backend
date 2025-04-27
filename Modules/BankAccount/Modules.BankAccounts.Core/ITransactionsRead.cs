using LanguageExt;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Core;

public interface ITransactionsRead
{
    Task<Either<ErrorResult, TransactionListDto>> Read(Guid bankAccountId, List<Guid> cards);
}