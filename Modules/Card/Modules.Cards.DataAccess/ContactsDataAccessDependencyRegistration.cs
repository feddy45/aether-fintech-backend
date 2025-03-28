using Microsoft.Extensions.DependencyInjection;
using Modules.Cards.Core.Dependencies;
using Modules.Shared.DependencyInjection;

namespace Modules.Cards.DataAccess;

public class CardsDataAccessDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddScoped<ICardsReader, CardsReader>();
    }
}