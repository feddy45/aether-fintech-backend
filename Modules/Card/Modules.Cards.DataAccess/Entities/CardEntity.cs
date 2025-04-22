namespace Modules.Cards.DataAccess.Entities;

public record CardEntity
{
    public Guid Id { get; init; }
    public required string CardNumber { get; init; }
    public required string Description { get; init; }
    public DateTime ExpirationDate { get; init; }
    public Guid UserId { get; init; }

    public ICollection<TransactionEntity> Transactions { get; init; } = new List<TransactionEntity>();
}