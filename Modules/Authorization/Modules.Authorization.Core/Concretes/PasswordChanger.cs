using LanguageExt;
using Modules.Authorization.Core.Dependencies;
using Modules.Authorization.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Authorization.Core.Concretes;

public class PasswordChanger(IPasswordChange passwordChange) : IPasswordChanger
{
    public async Task<Either<ErrorResult, GenericSuccessResult>> ChangePassword(ChangePasswordDto changePassword)
    {
        try
        {
            var result = await passwordChange.ChangePassword(changePassword);

            return result.IsSuccess ? new GenericSuccessResult(result.Data) : new GenericErrorResult(result.Data);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}