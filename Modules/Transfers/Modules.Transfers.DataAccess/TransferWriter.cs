using LanguageExt;
using Modules.Shared.Results;
using Modules.Transfers.Core.Dependencies;
using Modules.Transfers.Core.Dtos;
using Modules.Transfers.DataAccess.DatabaseModels;
using Modules.Transfers.DataAccess.Entities;

namespace Modules.Transfers.DataAccess;

internal class TransferWriter(TransfersDbContext dbContext) : ITransferWriter
{
    public async Task<Either<ErrorResult, CreatedTransferDto>> Write(CreateTransferDto request)
    {
        var bankAccount = dbContext.BankAccount.FirstOrDefault(c => c.Id == request.BankAccountId);
        if (bankAccount == null) return new GenericErrorResult("Bank account not found");

        var newTransfer = new TransferEntity
        {
            Iban = request.Iban,
            Beneficiary = request.Beneficiary,
            Amount = request.Amount,
            Date = DateTime.UtcNow,
            Description = request.Description,
            BankAccountId = request.BankAccountId,
            TransactionId = request.TransactionId,
            BankAccount = bankAccount
        };

        dbContext.Add(newTransfer);
        await dbContext.SaveChangesAsync();

        return new CreatedTransferDto(newTransfer.Id);
    }
}