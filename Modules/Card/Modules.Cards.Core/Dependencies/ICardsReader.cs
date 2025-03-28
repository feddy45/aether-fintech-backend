using Modules.Cards.Core.Dtos;

namespace Modules.Cards.Core.Dependencies;

public interface ICardsReader
{
    Task<CardListDto> Read();
}