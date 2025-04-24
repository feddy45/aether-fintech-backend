namespace Modules.BankAccounts.Core.Dtos;

public record CreateTransactionDto(decimal Amount, DateTime Date, string Description, string Type, Guid BankAccountId);