using LanguageExt;
using Modules.Authorization.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Authorization.Core;

public interface IAuthenticator
{
    Task<Either<ErrorResult, LoginSuccessfulDto>> Authenticate(LoginUserDto user);
}