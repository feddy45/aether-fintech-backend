namespace Modules.Cards.Core.Dtos;

public record CardDto(Guid Id, string Number, string Description, DateTime ExpirationDate, decimal Balance);