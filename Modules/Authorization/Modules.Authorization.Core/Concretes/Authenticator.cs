using LanguageExt;
using Modules.Authorization.Core.Dependencies;
using Modules.Authorization.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Authorization.Core.Concretes;

public class Authenticator(IUserReader userReader, IJwtCreator jwtCreator) : IAuthenticator
{
    public async Task<Either<ErrorResult, LoginSuccessfulDto>> Authenticate(LoginUserDto user)
    {
        var dbUserResult = await userReader.Read(user);

        return await dbUserResult.MatchAsync(
            async validUser =>
            {
                var token = await jwtCreator.CreateToken(validUser);
                return Either<ErrorResult, LoginSuccessfulDto>.Right(new LoginSuccessfulDto(token));
            },
            error => Task.FromResult(Either<ErrorResult, LoginSuccessfulDto>.Left(error)));
    }
}