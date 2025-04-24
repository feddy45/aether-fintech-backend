using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Modules.BankAccount.DataAccess.DatabaseModels;
using Modules.BankAccounts.Core.Dependencies;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccount.DataAccess;

internal class BankAccountsReader(BankAccountsDbContext dbContext) : IBankAccountsReader
{
    public async Task<BankAccountListDto> Read(Guid userId)
    {
        var bankAccountBalances = await GetBankAccountsBalance();
        
        var bankAccounts = await dbContext.BankAccount
            .AsNoTracking().Where(x => x.UserId == userId)
            .Select(bankAccount => new BankAccountDto(
                bankAccount.Id,
                bankAccount.Iban,
                bankAccount.Name,
                bankAccount.UserId,
                bankAccountBalances.GetValueOrDefault(bankAccount.Id, 0),
                bankAccount.CreatedAt
            ))
            .ToListAsync();

        return new BankAccountListDto(bankAccounts);
    }

    public async Task<Either<ErrorResult, BankAccountBalanceCheckedDto>> CheckBalance(
        BankAccountBalanceCheckDto checkDto)
    {
        var bankAccountsBalances = await GetBankAccountsBalance();

        return new BankAccountBalanceCheckedDto(bankAccountsBalances.GetValueOrDefault(checkDto.BankAccountId, 0) >=
                                                checkDto.Cost);
    }

    private async Task<Dictionary<Guid, decimal>> GetBankAccountsBalance()
    {
        return await dbContext.Transaction
            .AsNoTracking()
            .GroupBy(t => t.BankAccountId)
            .Select(g => new
            {
                CardId = g.Key,
                Amount = g.Sum(t => t.Amount)
            })
            .ToDictionaryAsync(x => x.CardId, x => x.Amount);
    }
}