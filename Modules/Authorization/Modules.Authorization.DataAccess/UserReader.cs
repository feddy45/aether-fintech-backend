using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modules.Authorization.Core.Dependencies;
using Modules.Authorization.Core.Dtos;
using Modules.Authorization.DataAccess.DatabaseModels;
using Modules.Authorization.DataAccess.Entities;

namespace Modules.Authorization.DataAccess;

internal class UserReader(UsersDbContext dbContext, IPasswordHasher<UserEntity> passwordHasher) : IUserReader
{
    public async Task<UserDto?> Read(LoginUserDto loginUser)
    {
        var user = await dbContext.User.FirstOrDefaultAsync(u => u.Username == loginUser.Username);
        if (user is null)
            return null;

        var result = passwordHasher.VerifyHashedPassword(user, user.Password, loginUser.Password);


        return result == PasswordVerificationResult.Success
            ? new UserDto(user.Id, user.Username, user.FirstName, user.LastName, user.DateOfBirth)
            : null;
    }
}