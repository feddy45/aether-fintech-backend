using Modules.Transfers.Core.Dtos;

namespace Modules.Transfers.Core.Dependencies;

public interface ITransfersReader
{
    Task<TransferListDto> Read();
}