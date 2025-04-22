namespace Modules.Cards.DataAccess.Entities;

public record TransactionEntity
{
    public Guid Id { get; init; }
    public DateTime Date { get; init; }
    public string? Description { get; init; }
    public required string Type { get; init; }
    public decimal Amount { get; init; }
    public Guid CardId { get; init; }
    public required CardEntity Card { get; init; }
}