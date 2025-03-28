using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;

namespace Modules.Cards.DataAccess;

internal class CardsReader() : ICardsReader
{
    public Task<CardListDto> ReadAsync()
    {
        return Task.FromResult(new CardListDto([
            new CardDto(Guid.NewGuid(), "4111111111111111", "Visa Platinum", new DateTime(2025, 12, 31, 0,0,0,  kind:  DateTimeKind.Utc), 5000),
            new CardDto(Guid.NewGuid(), "5500000000000004", "MasterCard Gold", new DateTime(2028, 11, 30, 0,0,0,  kind:  DateTimeKind.Utc), 3000),
            new CardDto(Guid.NewGuid(), "340000000000009", "American Express", new DateTime(2026, 10, 31, 0,0,0,  kind:  DateTimeKind.Utc), 7000),
            new CardDto(Guid.NewGuid(), "6011000000000004", "Discover", new DateTime(2027, 09, 30, 0,0,0,  kind:  DateTimeKind.Utc), 7000),
            new CardDto(Guid.NewGuid(), "4111111111111112", "Visa Classic", new DateTime(2027, 06, 18, 0,0,0,  kind:  DateTimeKind.Utc), 1000)
        ]));
    }
}