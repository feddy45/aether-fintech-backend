using LanguageExt;
using Modules.Cards.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Cards.Core;

public interface ICardBalanceChecker
{
    Task<Either<ErrorResult, CardBalanceCheckedDto>> CheckBalance(CardBalanceCheckDto checkDto);
}