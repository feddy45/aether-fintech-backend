namespace Modules.Contacts.DataAccess.Entities;

public record ContactEntity
{
    public Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Iban { get; init; }
    public Guid UserId { get; init; }
}