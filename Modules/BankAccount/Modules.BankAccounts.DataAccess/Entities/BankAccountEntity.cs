namespace Modules.BankAccount.DataAccess.Entities;

public record BankAccountEntity
{
    public Guid Id { get; init; }
    public required string Iban { get; init; }
    public required string Name { get; init; }
    public Guid UserId { get; init; }
    public DateTime CreatedAt { get; init; }
    public ICollection<TransactionEntity> Transactions { get; init; } = new List<TransactionEntity>();
}