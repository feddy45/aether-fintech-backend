namespace Modules.Transfers.DataAccess.Entities;

public record TransferEntity
{
    public Guid Id { get; init; }
    public required string Iban { get; init; }
    public required string Beneficiary { get; init; }
    public DateTime Date { get; init; }
    public float Amount { get; init; }
    public required string Description { get; init; }
    public Guid CardId { get; init; }
}