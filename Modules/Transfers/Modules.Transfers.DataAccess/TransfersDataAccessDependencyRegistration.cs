using Microsoft.Extensions.DependencyInjection;
using Modules.Shared.DependencyInjection;
using Modules.Transfers.Core.Dependencies;

namespace Modules.Transfers.DataAccess;

public class TransfersDataAccessDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddScoped<ITransferWriter, TransferWriter>();
    }
}