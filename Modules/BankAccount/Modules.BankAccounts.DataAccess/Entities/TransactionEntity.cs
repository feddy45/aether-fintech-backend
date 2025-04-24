namespace Modules.BankAccount.DataAccess.Entities;

public record TransactionEntity
{
    public Guid Id { get; init; }
    public DateTime Date { get; init; }
    public string? Description { get; init; }
    public required string Type { get; init; }
    public decimal Amount { get; init; }
    public Guid BankAccountId { get; init; }
    public required BankAccountEntity BankAccount { get; init; }
}