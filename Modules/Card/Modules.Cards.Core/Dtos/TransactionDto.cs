namespace Modules.Cards.Core.Dtos;

public record TransactionDto(Guid Id, decimal Amount, DateTime Date, string Description, string Type, Guid CardId);