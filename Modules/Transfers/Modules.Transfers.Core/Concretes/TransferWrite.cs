using LanguageExt;
using Modules.Shared.Results;
using Modules.Transfers.Core.Dependencies;
using Modules.Transfers.Core.Dtos;

namespace Modules.Transfers.Core.Concretes;

internal class TransferWrite(ITransferWriter transferWriter) : ITransferWrite
{
    public async Task<Either<ErrorResult, CreatedTransferDto>> Write(CreateTransferDto request)
    {
        try
        {
            return await transferWriter.Write(request);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}