using Microsoft.Extensions.DependencyInjection;
using Modules.Shared.DependencyInjection;
using Modules.Transfers.Core.Concretes;

namespace Modules.Transfers.Core;

public class TransfersCoreDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddScoped<ITransferWrite, TransferWrite>();
        services.AddScoped<ITransfersRead, TransfersRead>();
    }
}