using LanguageExt;
using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;
using Modules.Cards.DataAccess.DatabaseModels;
using Modules.Cards.DataAccess.Entities;
using Modules.Shared.Results;

namespace Modules.Cards.DataAccess;

internal class TransactionWriter(CardsDbContext dbContext) : ITransactionWriter
{
    public async Task<Either<ErrorResult, CreatedTransactionDto>> Write(CreateTransactionDto request)
    {
        var card = dbContext.Card.FirstOrDefault(c => c.Id == request.CardId);
        if (card == null) return new GenericErrorResult("Card not found");

        var newTransfer = new TransactionEntity
        {
            Date = DateTime.UtcNow,
            Description = request.Description,
            Amount = request.Amount,
            Type = request.Type,
            CardId = request.CardId,
            Card = card
        };

        dbContext.Add(newTransfer);
        await dbContext.SaveChangesAsync();

        return new CreatedTransactionDto(newTransfer.Id);
    }
}