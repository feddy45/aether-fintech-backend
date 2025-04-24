using Microsoft.EntityFrameworkCore;
using Modules.BankAccount.DataAccess.DatabaseModels;
using Modules.BankAccounts.Core.Dependencies;
using Modules.BankAccounts.Core.Dtos;

namespace Modules.BankAccount.DataAccess;

internal class BankAccountsReader(BankAccountsDbContext dbContext) : IBankAccountsReader
{
    public async Task<BankAccountListDto> Read(Guid userId)
    {
        var bankAccounts = await dbContext.BankAccount
            .AsNoTracking().Where(x => x.UserId == userId)
            .Select(bankAccount => new BankAccountDto(
                bankAccount.Id,
                bankAccount.Iban,
                bankAccount.Name,
                bankAccount.UserId,
                bankAccount.CreatedAt
            ))
            .ToListAsync();

        return new BankAccountListDto(bankAccounts);
    }
}