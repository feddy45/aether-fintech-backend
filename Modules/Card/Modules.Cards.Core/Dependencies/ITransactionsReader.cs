using Modules.Cards.Core.Dtos;

namespace Modules.Cards.Core.Dependencies;

public interface ITransactionsReader
{
    Task<TransactionListDto> Read(Guid cardId);
}