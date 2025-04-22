using LanguageExt;
using Modules.Cards.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Cards.Core;

public interface ITransactionWrite
{
    Task<Either<ErrorResult, CreatedTransactionDto>> Write(CreateTransactionDto request);
}