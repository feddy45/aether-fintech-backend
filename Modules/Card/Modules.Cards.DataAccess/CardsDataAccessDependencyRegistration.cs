using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modules.Cards.Core.Dependencies;
using Modules.Cards.DataAccess.DatabaseModels;
using Modules.Shared.DependencyInjection;
using Modules.Shared.Models;

namespace Modules.Cards.DataAccess;

public class CardsDataAccessDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddDbContext<CardsDbContext>((serviceProvider, options) =>
            {
                var connectionString = serviceProvider.GetRequiredService<ConnectionString>();
                options.UseNpgsql(connectionString.Value);
            }
        );

        services.AddScoped<ICardsReader, CardsReader>();
        services.AddScoped<ITransactionsReader, TransactionsReader>();
        services.AddScoped<ITransactionWriter, TransactionWriter>();
    }
}