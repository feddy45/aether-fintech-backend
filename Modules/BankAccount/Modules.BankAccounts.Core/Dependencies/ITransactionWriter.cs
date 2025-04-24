using LanguageExt;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Core.Dependencies;

public interface ITransactionWriter
{
    Task<Either<ErrorResult, CreatedTransactionDto>> Write(CreateTransactionDto request);
}