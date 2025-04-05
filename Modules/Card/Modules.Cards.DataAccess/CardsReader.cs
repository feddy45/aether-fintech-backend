using Microsoft.EntityFrameworkCore;
using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;
using Modules.Cards.DataAccess.DatabaseModels;

namespace Modules.Cards.DataAccess;

internal class CardsReader(CardsDbContext dbContext) : ICardsReader
{
    public async Task<CardListDto> Read()
    {
        var cards = await dbContext.Card
            .AsNoTracking()
            .Select(card => new CardDto(
                card.Id,
                card.CardNumber,
                card.Description,
                card.ExpirationDate,
                card.Amount
            ))
            .ToListAsync();

        return new CardListDto(cards);
    }
}