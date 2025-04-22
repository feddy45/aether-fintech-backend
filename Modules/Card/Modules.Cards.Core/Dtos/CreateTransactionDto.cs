namespace Modules.Cards.Core.Dtos;

public record CreateTransactionDto(decimal Amount, DateTime Date, string Description, string Type, Guid CardId);