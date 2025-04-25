using LanguageExt;
using Modules.BankAccounts.Core.Dependencies;
using Modules.BankAccounts.Core.Dtos;
using Modules.Shared.Results;

namespace Modules.BankAccounts.Core.Concretes;

internal class TransactionsRead(ITransactionsReader transactionsReader) : ITransactionsRead
{
    public async Task<Either<ErrorResult, TransactionListDto>> Read(Guid bankAccountId, Guid? cardId)
    {
        try
        {
            return await transactionsReader.Read(bankAccountId, cardId);
        }
        catch (Exception e)
        {
            return new GenericErrorResult(e.Message);
        }
    }
}