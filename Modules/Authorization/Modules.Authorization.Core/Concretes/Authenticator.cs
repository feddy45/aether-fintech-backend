using LanguageExt;
using Modules.Authorization.Core.Dependencies;
using Modules.Authorization.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Authorization.Core.Concretes;

public class Authenticator(IUserReader userReader, IJwtCreator jwtCreator) : IAuthenticator
{
    public async Task<Either<ErrorResult, LoginSuccessfulDto>> Authenticate(LoginUserDto user)
    {
        try
        {
            var dbUser = await userReader.Read(user);
            if (dbUser == null) return new GenericErrorResult("User not found");

            var token = await jwtCreator.CreateToken(dbUser);

            return new LoginSuccessfulDto(token);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}