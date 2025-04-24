using Microsoft.EntityFrameworkCore;
using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;
using Modules.Cards.DataAccess.DatabaseModels;

namespace Modules.Cards.DataAccess;

internal class CardsReader(CardsDbContext dbContext) : ICardsReader
{
    public async Task<CardListDto> Read(Guid bankAccountId)
    {
        var cards = await dbContext.Card
            .AsNoTracking()
            .Where(c => c.BankAccountId == bankAccountId)
            .Select(card => new CardDto(
                card.Id,
                card.CardNumber,
                card.Description,
                card.ExpirationDate,
                0
            ))
            .ToListAsync();

        return new CardListDto(cards);
    }
}