using LanguageExt;
using Modules.Cards.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Cards.Core;

public interface ITransactionsRead
{
    Task<Either<ErrorResult, TransactionListDto>> Read(Guid cardId);
}