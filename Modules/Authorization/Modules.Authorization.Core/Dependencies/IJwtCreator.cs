using Modules.Authorization.Core.Dtos;

namespace Modules.Authorization.Core.Dependencies;

public interface IJwtCreator
{
    Task<string> CreateToken(UserDto user);
}