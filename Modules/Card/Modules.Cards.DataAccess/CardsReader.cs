using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;

namespace Modules.Cards.DataAccess;

internal class CardsReader() : ICardsReader
{
    public Task<CardListDto> ReadAsync()
    {
        return Task.FromResult(new CardListDto([
            new CardDto(new Guid("cf9e6485-db96-4942-a07c-65f106d47542"), "4111111111111111", "Visa Platinum", new DateTime(2025, 12, 31, 0,0,0,  kind:  DateTimeKind.Utc), 5000),
            new CardDto(new Guid("c39af9fe-604c-4354-b3cb-8f982e9d6007"), "5500000000000004", "MasterCard Gold", new DateTime(2028, 11, 30, 0,0,0,  kind:  DateTimeKind.Utc), 3000),
            new CardDto(new Guid("c5a8d57a-cd34-43cd-b199-6ac1e05a631a"), "340000000000009", "American Express", new DateTime(2026, 10, 31, 0,0,0,  kind:  DateTimeKind.Utc), 7000),
            new CardDto(new Guid("1c6cb34f-83a4-471f-8dc7-65505e0acfe4"), "6011000000000004", "Discover", new DateTime(2027, 09, 30, 0,0,0,  kind:  DateTimeKind.Utc), 7000),
            new CardDto(new Guid("20694efb-1182-4414-9885-e9e92eaf4d32"), "4111111111111112", "Visa Classic", new DateTime(2027, 06, 18, 0,0,0,  kind:  DateTimeKind.Utc), 1000)
        ]));
    }
}