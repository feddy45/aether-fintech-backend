using Modules.BankAccounts.Core.Enums;

namespace Modules.BankAccounts.Core.Dtos;

public record TransactionDto(
    Guid Id,
    decimal Amount,
    DateTime Date,
    string Description,
    TransactionType Type,
    Guid BankAccountId,
    Guid? CardId);