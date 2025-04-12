using LanguageExt;
using Modules.Shared.Results;
using Modules.Transfers.Core.Dependencies;
using Modules.Transfers.Core.Dtos;

namespace Modules.Transfers.Core.Concretes;

internal class TransfersRead(ITransfersReader transfersReader) : ITransfersRead
{
    public async Task<Either<ErrorResult, TransferListDto>> Read()
    {
        try
        {
            return await transfersReader.Read();
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}