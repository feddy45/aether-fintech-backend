using Modules.BankAccounts.Core.Dtos;

namespace Modules.BankAccounts.Core.Dependencies;

public interface IBankAccountsReader
{
    Task<BankAccountListDto> Read(Guid userId);
    Task<Dictionary<Guid, decimal>> GetBankAccountsBalance();
}