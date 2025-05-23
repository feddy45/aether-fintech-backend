namespace Modules.BankAccounts.Core.Dtos;

public record BankAccountDto(
    Guid Id,
    string Iban,
    string Name,
    Guid UserId,
    decimal Balance,
    DateTime CreatedAt);