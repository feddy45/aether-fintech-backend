using Microsoft.EntityFrameworkCore;
using Modules.Transfers.Core.Dependencies;
using Modules.Transfers.Core.Dtos;
using Modules.Transfers.DataAccess.DatabaseModels;

namespace Modules.Transfers.DataAccess;

internal class TransfersReader(TransfersDbContext dbContext) : ITransfersReader
{
    public async Task<TransferListDto> Read()
    {
        var transfers = await dbContext.Transfer
            .AsNoTracking()
            .OrderByDescending(t => t.Date)
            .Select(transfer => new TransferDto(
                transfer.Id,
                transfer.Iban,
                transfer.Beneficiary,
                transfer.Amount,
                transfer.Date,
                transfer.Description,
                transfer.CardId
            ))
            .ToListAsync();

        return new TransferListDto(transfers);
    }
}