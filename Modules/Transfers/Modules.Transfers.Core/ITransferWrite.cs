using LanguageExt;
using Modules.Shared.Results;
using Modules.Transfers.Core.Dtos;

namespace Modules.Transfers.Core;

public interface ITransferWrite
{
    Task<Either<ErrorResult, CreatedTransferDto>> Write(CreateTransferDto request);
}