namespace Modules.Cards.Core.Dtos;

public record TransactionDto(Guid Id, string Amount, DateTime Date, string Description, string Type);