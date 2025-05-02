using Modules.BankAccounts.Core.Enums;

namespace Modules.BankAccounts.Core.Dtos;

public record CreateTransactionDto(
    decimal Amount,
    DateTime Date,
    string Description,
    TransactionType Type,
    Guid BankAccountId);