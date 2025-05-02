using LanguageExt;
using Modules.Shared.Results;
using Modules.Transfers.Core.Dependencies;
using Modules.Transfers.Core.Dtos;

namespace Modules.Transfers.Core.Concretes;

internal class TransfersRead(ITransfersReader transfersReader) : ITransfersRead
{
    public async Task<Either<ErrorResult, TransferListDto>> Read(Guid userId)
    {
        try
        {
            return await transfersReader.Read(userId);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}