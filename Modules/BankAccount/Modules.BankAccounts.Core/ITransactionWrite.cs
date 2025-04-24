using LanguageExt;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Core;

public interface ITransactionWrite
{
    Task<Either<ErrorResult, CreatedTransactionDto>> Write(CreateTransactionDto request);
}