using LanguageExt;
using Modules.Cards.Core.Dependencies;
using Modules.Cards.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.Cards.Core.Concretes;

internal class TransactionWrite(ITransactionWriter transactionWriter) : ITransactionWrite
{
    public async Task<Either<ErrorResult, CreatedTransactionDto>> Write(CreateTransactionDto request)
    {
        try
        {
            return await transactionWriter.Write(request);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}