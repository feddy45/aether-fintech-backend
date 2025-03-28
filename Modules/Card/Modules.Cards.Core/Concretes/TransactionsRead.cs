using LanguageExt;
using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;
using Modules.Cards.Core.Results;
using Modules.Shared.Results;

namespace Modules.Cards.Core.Concretes;

internal class TransactionsRead(ITransactionsReader transactionsReader) : ITransactionsRead
{
    public async Task<Either<ErrorResult, TransactionListDto>> Read(Guid cardId)
    {

        try
        {
            return await transactionsReader.Read(cardId);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}