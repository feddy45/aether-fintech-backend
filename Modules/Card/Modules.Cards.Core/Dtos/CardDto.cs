namespace Modules.Cards.Core.Dtos;

public record CardDto(Guid Id, string number, string Description, DateTime ExpirationDate, float Balance);
