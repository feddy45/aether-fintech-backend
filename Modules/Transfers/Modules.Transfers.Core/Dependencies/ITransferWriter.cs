using Modules.Transfers.Core.Dtos;

namespace Modules.Transfers.Core.Dependencies;

public interface ITransferWriter
{
    Task<CreatedTransferDto> Write(CreateTransferDto request);
}