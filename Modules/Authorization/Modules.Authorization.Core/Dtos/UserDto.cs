namespace Modules.Authorization.Core.Dtos;

public record UserDto(Guid Id, string Username, string FirstName, string LastName, string Email, DateTime DateOfBirth);