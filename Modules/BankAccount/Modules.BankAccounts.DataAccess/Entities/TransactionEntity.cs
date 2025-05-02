using Modules.BankAccounts.Core.Enums;

namespace Modules.BankAccount.DataAccess.Entities;

public record TransactionEntity
{
    public Guid Id { get; init; }
    public DateTime Date { get; init; }
    public string? Description { get; init; }
    public required TransactionType Type { get; init; }
    public decimal Amount { get; init; }
    public Guid BankAccountId { get; init; }
    public Guid? CardId { get; init; }
    public required BankAccountEntity BankAccount { get; init; }
}