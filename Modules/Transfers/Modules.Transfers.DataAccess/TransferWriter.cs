using Modules.Transfers.Core.Dependencies;
using Modules.Transfers.Core.Dtos;

namespace Modules.Transfers.DataAccess;

internal class TransferWriter : ITransferWriter
{
    public Task<CreatedTransferDto> Write(CreateTransferDto request)
    {
        return Task.FromResult(new CreatedTransferDto(Guid.NewGuid()));
    }
}