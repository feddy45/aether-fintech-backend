using LanguageExt;
using Modules.BankAccount.DataAccess.DatabaseModels;
using Modules.BankAccount.DataAccess.Entities;
using Modules.BankAccounts.Core.Dependencies;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccount.DataAccess;

internal class TransactionWriter(BankAccountsDbContext dbContext) : ITransactionWriter
{
    public async Task<Either<ErrorResult, CreatedTransactionDto>> Write(CreateTransactionDto request)
    {
        var bankAccount = dbContext.BankAccount.FirstOrDefault(c => c.Id == request.BankAccountId);
        if (bankAccount == null) return new GenericErrorResult("Bank account not found");

        var newTransfer = new TransactionEntity
        {
            Date = DateTime.UtcNow,
            Description = request.Description,
            Amount = request.Amount,
            Type = request.Type,
            BankAccountId = request.BankAccountId,
            BankAccount = bankAccount
        };

        dbContext.Add(newTransfer);
        await dbContext.SaveChangesAsync();

        return new CreatedTransactionDto(newTransfer.Id);
    }
}