namespace Modules.Authorization.Core.Dtos;

public record ChangePasswordDto(string Username, string OldPassword, string NewPassword);