namespace Modules.Authorization.Core.Dtos;

public record ChangePasswordDto(string OldPassword, string NewPassword);