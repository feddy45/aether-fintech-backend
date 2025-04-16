namespace Modules.Authorization.DataAccess.Entities;

public record UserEntity
{
    public Guid Id { get; init; }
    public required string Username { get; init; }
    public required string Password { get; set; }
    public DateTime? LastLogin { get; init; }
    public DateTime DateOfBirth { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}