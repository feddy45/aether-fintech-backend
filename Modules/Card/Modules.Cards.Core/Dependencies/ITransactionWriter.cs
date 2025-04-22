using LanguageExt;
using Modules.Cards.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Cards.Core.Dependencies;

public interface ITransactionWriter
{
    Task<Either<ErrorResult, CreatedTransactionDto>> Write(CreateTransactionDto request);
}