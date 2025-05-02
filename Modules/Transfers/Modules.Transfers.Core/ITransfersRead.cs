using LanguageExt;
using Modules.Shared.Results;
using Modules.Transfers.Core.Dtos;

namespace Modules.Transfers.Core;

public interface ITransfersRead
{
    Task<Either<ErrorResult, TransferListDto>> Read(Guid userId);
}