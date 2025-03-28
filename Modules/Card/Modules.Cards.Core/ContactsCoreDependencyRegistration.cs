using Microsoft.Extensions.DependencyInjection;
using Modules.Cards.Core.Concretes;
using Modules.Shared.DependencyInjection;

namespace Modules.Cards.Core;

public class CardsCoreDependencyRegistration : IModuleDependencyRegistration
{
    public void Execute(IServiceCollection services)
    {
        services.AddScoped<ICardsRead, CardsRead>();
    }
}