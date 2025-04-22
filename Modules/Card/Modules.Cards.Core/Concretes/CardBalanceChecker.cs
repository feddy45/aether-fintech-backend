using LanguageExt;
using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Cards.Core.Concretes;

internal class CardBalanceChecker(ICardsReader cardsReader) : ICardBalanceChecker
{
    public async Task<Either<ErrorResult, CardBalanceCheckedDto>> CheckBalance(CardBalanceCheckDto checkDto)
    {
        try
        {
            return await cardsReader.CheckBalance(checkDto);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}