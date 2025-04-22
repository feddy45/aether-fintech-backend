using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;
using Modules.Cards.DataAccess.DatabaseModels;
using Modules.Shared.Results;

namespace Modules.Cards.DataAccess;

internal class CardsReader(CardsDbContext dbContext) : ICardsReader
{
    public async Task<CardListDto> Read()
    {
        var cardBalances = await GetBalanceByCards();

        var cards = await dbContext.Card
            .AsNoTracking()
            .Select(card => new CardDto(
                card.Id,
                card.CardNumber,
                card.Description,
                card.ExpirationDate,
                cardBalances.GetValueOrDefault(card.Id, 0)
            ))
            .ToListAsync();

        return new CardListDto(cards);
    }

    public async Task<Either<ErrorResult, CardBalanceCheckedDto>> CheckBalance(CardBalanceCheckDto checkDto)
    {
        var cardBalances = await GetBalanceByCards();

        return new CardBalanceCheckedDto(cardBalances.GetValueOrDefault(checkDto.CardId, 0) >= checkDto.Cost);
    }

    private async Task<Dictionary<Guid, decimal>> GetBalanceByCards()
    {
        return await dbContext.Transaction
            .AsNoTracking()
            .GroupBy(t => t.CardId)
            .Select(g => new
            {
                CardId = g.Key,
                Amount = g.Sum(t => t.Amount)
            })
            .ToDictionaryAsync(x => x.CardId, x => x.Amount);
    }
}