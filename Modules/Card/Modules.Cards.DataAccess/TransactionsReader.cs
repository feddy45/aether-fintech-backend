using Microsoft.EntityFrameworkCore;
using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;
using Modules.Cards.DataAccess.DatabaseModels;

namespace Modules.Cards.DataAccess;

internal class TransactionsReader(CardsDbContext dbContext) : ITransactionsReader
{
    public Task<TransactionListDto> Read(Guid cardId)
    {
        var transactions = dbContext.Transaction
            .AsNoTracking()
            .Where(transaction => transaction.CardId == cardId)
            .OrderByDescending(t => t.Date)
            .Select(transaction => new TransactionDto(
                transaction.Id,
                transaction.Amount,
                transaction.Date,
                transaction.Description ?? string.Empty,
                transaction.Type,
                transaction.CardId
            ))
            .ToList();

        return Task.FromResult(new TransactionListDto(transactions));
    }
}