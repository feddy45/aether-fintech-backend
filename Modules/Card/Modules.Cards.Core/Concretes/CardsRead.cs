using LanguageExt;
using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;
using Modules.Cards.Core.Results;
using Modules.Shared.Results;

namespace Modules.Cards.Core.Concretes;

internal class CardsRead(ICardsReader cardsReader) : ICardsRead
{
    public async Task<Either<ErrorResult, CardListDto>> ReadAsync()
    {

        try
        {
            return await cardsReader.ReadAsync();
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}