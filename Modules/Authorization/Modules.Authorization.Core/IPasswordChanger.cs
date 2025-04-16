using LanguageExt;
using Modules.Authorization.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Authorization.Core;

public interface IPasswordChanger
{
    Task<Either<ErrorResult, GenericSuccessResult>> ChangePassword(ChangePasswordDto changePassword);
}