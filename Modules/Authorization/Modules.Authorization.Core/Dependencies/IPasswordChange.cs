using Modules.Authorization.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Authorization.Core.Dependencies;

public interface IPasswordChange
{
    Task<Result<string>> ChangePassword(Guid userId, ChangePasswordDto changePassword);
}