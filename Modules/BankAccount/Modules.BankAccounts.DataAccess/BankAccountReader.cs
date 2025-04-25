using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Modules.BankAccount.DataAccess.DatabaseModels;
using Modules.BankAccounts.Core.Dependencies;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccount.DataAccess;

internal class BankAccountReader(BankAccountsDbContext dbContext, IBankAccountsReader accountsReader)
    : IBankAccountReader
{
    public async Task<Either<ErrorResult, BankAccountBalanceCheckedDto>> CheckBalance(
        BankAccountBalanceCheckDto checkDto)
    {
        var bankAccountsBalances = await accountsReader.GetBankAccountsBalance();

        return new BankAccountBalanceCheckedDto(bankAccountsBalances.GetValueOrDefault(checkDto.BankAccountId, 0) >=
                                                checkDto.Cost);
    }

    public async Task<Either<ErrorResult, BankAccountDto>> Read(Guid bankAccountId)
    {
        var bankAccountBalances = await accountsReader.GetBankAccountsBalance();

        var bankAccount = await dbContext.BankAccount
            .AsNoTracking().Where(x => x.Id == bankAccountId)
            .Select(bankAccount => new BankAccountDto(
                bankAccount.Id,
                bankAccount.Iban,
                bankAccount.Name,
                bankAccount.UserId,
                bankAccountBalances.GetValueOrDefault(bankAccount.Id, 0),
                bankAccount.CreatedAt
            )).FirstOrDefaultAsync();

        if (bankAccount == null) return new GenericErrorResult("Bank account not found");

        return bankAccount;
    }
}