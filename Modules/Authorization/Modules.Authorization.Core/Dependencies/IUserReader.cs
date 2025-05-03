using LanguageExt;
using Modules.Authorization.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Authorization.Core.Dependencies;

public interface IUserReader
{
    Task<Either<ErrorResult, UserDto>> Read(LoginUserDto loginUser);
}