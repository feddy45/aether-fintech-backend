using Microsoft.EntityFrameworkCore;
using Modules.Transfers.Core.Dependencies;
using Modules.Transfers.Core.Dtos;
using Modules.Transfers.DataAccess.DatabaseModels;

namespace Modules.Transfers.DataAccess;

internal class TransfersReader(TransfersDbContext dbContext) : ITransfersReader
{
    public async Task<TransferListDto> Read(Guid userId)
    {
        var transfers = await dbContext.Transfer
            .AsNoTracking()
            .OrderByDescending(t => t.Date)
            .Where(t => t.BankAccount.UserId == userId)
            .Select(transfer => new TransferDto(
                transfer.Id,
                transfer.Iban,
                transfer.Beneficiary,
                transfer.Amount,
                transfer.Date,
                transfer.Description,
                transfer.BankAccountId
            ))
            .ToListAsync();

        return new TransferListDto(transfers);
    }
}