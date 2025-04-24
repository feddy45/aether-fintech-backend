using Microsoft.Extensions.DependencyInjection;
using Modules.BankAccounts.Core.Concretes;
using Modules.Shared.DependencyInjection;

namespace Modules.BankAccounts.Core;

public class BankAccountsCoreDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddScoped<IBankAccountsRead, BankAccountsRead>();
    }
}