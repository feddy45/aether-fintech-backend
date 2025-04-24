using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modules.BankAccount.DataAccess.DatabaseModels;
using Modules.BankAccounts.Core.Dependencies;
using Modules.Shared.DependencyInjection;
using Modules.Shared.Models;

namespace Modules.BankAccount.DataAccess;

public class BankAccountsDataAccessDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddDbContext<BankAccountsDbContext>((serviceProvider, options) =>
            {
                var connectionString = serviceProvider.GetRequiredService<ConnectionString>();
                options.UseNpgsql(connectionString.Value);
            }
        );

        services.AddScoped<IBankAccountsReader, BankAccountsReader>();
        services.AddScoped<ITransactionsReader, TransactionsReader>();
        services.AddScoped<ITransactionWriter, TransactionWriter>();
    }
}