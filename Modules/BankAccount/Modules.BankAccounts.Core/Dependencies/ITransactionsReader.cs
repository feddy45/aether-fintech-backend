using Modules.BankAccounts.Core.Dtos;

namespace Modules.BankAccounts.Core.Dependencies;

public interface ITransactionsReader
{
    Task<TransactionListDto> Read(Guid bankAccountId, Guid? cardId);
}