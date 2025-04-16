using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modules.Authorization.Core.Dependencies;
using Modules.Authorization.Core.Dtos;
using Modules.Authorization.DataAccess.DatabaseModels;
using Modules.Authorization.DataAccess.Entities;
using Modules.Shared.Results;

namespace Modules.Authorization.DataAccess;

internal class PasswordChange(UsersDbContext dbContext, IPasswordHasher<UserEntity> passwordHasher) : IPasswordChange
{
    public async Task<Result<string>> ChangePassword(ChangePasswordDto changePassword)
    {
        var user = await dbContext.User.FirstOrDefaultAsync(u => u.Username == changePassword.Username);
        if (user is null)
            return new GenericErrorResult("User not found");

        var result = passwordHasher.VerifyHashedPassword(user, user.Password, changePassword.OldPassword);
        if (result != PasswordVerificationResult.Success)
            return new GenericErrorResult("Current password is incorrect");

        user.Password = passwordHasher.HashPassword(user, changePassword.NewPassword);
        await dbContext.SaveChangesAsync();

        return new GenericSuccessResult("Password changed");
    }
}