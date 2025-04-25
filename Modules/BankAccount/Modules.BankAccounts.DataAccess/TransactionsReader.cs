using Microsoft.EntityFrameworkCore;
using Modules.BankAccount.DataAccess.DatabaseModels;
using Modules.BankAccounts.Core.Dependencies;
using Modules.BankAccounts.Core.Dtos;

namespace Modules.BankAccount.DataAccess;

internal class TransactionsReader(BankAccountsDbContext dbContext) : ITransactionsReader
{
    public Task<TransactionListDto> Read(Guid bankAccountId, Guid? cardId)
    {
        var transactionsQuery = dbContext.Transaction
            .AsNoTracking()
            .Where(transaction => transaction.BankAccountId == bankAccountId);

        if (cardId != null) transactionsQuery = transactionsQuery.Where(transaction => transaction.CardId == cardId);

        var transactions = transactionsQuery.OrderByDescending(t => t.Date)
            .Select(transaction => new TransactionDto(
                transaction.Id,
                transaction.Amount,
                transaction.Date,
                transaction.Description ?? string.Empty,
                transaction.Type,
                transaction.BankAccountId,
                transaction.CardId
            )).ToList();

        return Task.FromResult(new TransactionListDto(transactions));
    }
}