using Modules.Authorization.Core.Dtos;

namespace Modules.Authorization.Core.Dependencies;

public interface IUserReader
{
    Task<UserDto?> Read(LoginUserDto loginUser);
}