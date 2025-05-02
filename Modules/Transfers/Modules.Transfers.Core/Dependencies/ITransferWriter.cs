using LanguageExt;
using Modules.Shared.Results;
using Modules.Transfers.Core.Dtos;

namespace Modules.Transfers.Core.Dependencies;

public interface ITransferWriter
{
    Task<Either<ErrorResult, CreatedTransferDto>> Write(CreateTransferDto request);
}