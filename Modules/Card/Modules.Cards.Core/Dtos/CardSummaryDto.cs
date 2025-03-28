namespace Modules.Cards.Core.Dtos;

public record CardSummaryDto(Guid Id, string Number, string Description, DateTime ExpirationDate, float Balance);
