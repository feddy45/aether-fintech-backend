using LanguageExt;
using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Cards.Core.Concretes;

internal class CardsRead(ICardsReader cardsReader) : ICardsRead
{
    public async Task<Either<ErrorResult, CardListDto>> Read(Guid bankAccountId)
    {
        try
        {
            return await cardsReader.Read(bankAccountId);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}