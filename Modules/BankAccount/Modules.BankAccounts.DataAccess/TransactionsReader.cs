using Microsoft.EntityFrameworkCore;
using Modules.BankAccount.DataAccess.DatabaseModels;
using Modules.BankAccounts.Core.Dependencies;
using Modules.BankAccounts.Core.Dtos;

namespace Modules.BankAccount.DataAccess;

internal class TransactionsReader(BankAccountsDbContext dbContext) : ITransactionsReader
{
    public Task<TransactionListDto> Read(Guid bankAccountId, List<Guid> cards)
    {
        var transactionsQuery = dbContext.Transaction
            .AsNoTracking()
            .Where(transaction => transaction.BankAccountId == bankAccountId);

        if (cards.Count > 0)
            transactionsQuery = transactionsQuery.Where(transaction =>
                transaction.CardId != null && cards.Contains((Guid)transaction.CardId));

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