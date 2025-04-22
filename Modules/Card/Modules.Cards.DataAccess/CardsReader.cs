using Microsoft.EntityFrameworkCore;
using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;
using Modules.Cards.DataAccess.DatabaseModels;

namespace Modules.Cards.DataAccess;

internal class CardsReader(CardsDbContext dbContext) : ICardsReader
{
    public async Task<CardListDto> Read()
    {
        var cardBalances = await dbContext.Transaction
            .AsNoTracking()
            .GroupBy(t => t.CardId)
            .Select(g => new
            {
                CardId = g.Key,
                Amount = g.Sum(t => t.Amount)
            })
            .ToDictionaryAsync(x => x.CardId, x => x.Amount);

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
}