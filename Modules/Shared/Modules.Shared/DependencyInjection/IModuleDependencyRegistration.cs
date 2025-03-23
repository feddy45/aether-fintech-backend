using Microsoft.Extensions.DependencyInjection;

namespace Modules.Shared.DependencyInjection;

public interface IModuleDependencyRegistration
{
    void Execute(IServiceCollection services);
}