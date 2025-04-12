using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modules.Shared.DependencyInjection;
using Modules.Shared.Models;
using Modules.Transfers.Core.Dependencies;
using Modules.Transfers.DataAccess.DatabaseModels;

namespace Modules.Transfers.DataAccess;

public class TransfersDataAccessDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddDbContext<TransfersDbContext>((serviceProvider, options) =>
            {
                var connectionString = serviceProvider.GetRequiredService<ConnectionString>();
                options.UseNpgsql(connectionString.Value);
            }
        );

        services.AddScoped<ITransferWriter, TransferWriter>();
        services.AddScoped<ITransfersReader, TransfersReader>();
    }
}