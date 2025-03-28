using LanguageExt;
using Modules.Cards.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Cards.Core;

public interface ICardsRead
{
    Task<Either<ErrorResult, CardListDto>> ReadAsync();
}