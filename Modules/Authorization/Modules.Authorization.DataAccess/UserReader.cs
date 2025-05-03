using LanguageExt;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modules.Authorization.Core.Dependencies;
using Modules.Authorization.Core.Dtos;
using Modules.Authorization.DataAccess.DatabaseModels;
using Modules.Authorization.DataAccess.Entities;
using Modules.Shared.Results;

namespace Modules.Authorization.DataAccess;

internal class UserReader(UsersDbContext dbContext, IPasswordHasher<UserEntity> passwordHasher) : IUserReader
{
    public async Task<Either<ErrorResult, UserDto>> Read(LoginUserDto loginUser)
    {
        var user = await dbContext.User.FirstOrDefaultAsync(u => u.Username == loginUser.Username);
        if (user is null)
            return new GenericErrorResult("User not found");

        var result = passwordHasher.VerifyHashedPassword(user, user.Password, loginUser.Password);


        return result == PasswordVerificationResult.Success
            ? new UserDto(user.Id, user.Username, user.FirstName, user.LastName, user.Email, user.DateOfBirth)
            : new GenericErrorResult("Invalid password");
    }
}