using Modules.Transfers.Core.Dependencies;
using Modules.Transfers.Core.Dtos;
using Modules.Transfers.DataAccess.DatabaseModels;
using Modules.Transfers.DataAccess.Entities;

namespace Modules.Transfers.DataAccess;

internal class TransferWriter(TransfersDbContext dbContext) : ITransferWriter
{
    public async Task<CreatedTransferDto> Write(CreateTransferDto request)
    {
        var newTransfer = new TransferEntity
        {
            Iban = request.Iban,
            Beneficiary = request.Beneficiary,
            Amount = request.Amount,
            Date = DateTime.UtcNow,
            Description = request.Description,
            BankAccountId = request.BankAccountId,
            TransactionId = request.TransactionId
        };

        dbContext.Add(newTransfer);
        await dbContext.SaveChangesAsync();

        return new CreatedTransferDto(newTransfer.Id);
    }
}