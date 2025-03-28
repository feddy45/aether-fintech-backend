using Modules.Cards.Api;
using Modules.Cards.Core;
using Modules.Cards.DataAccess;
using Modules.Shared.DependencyInjection;

namespace Web.Api.Modules;

public class CardsModule : Module
{
    protected override IModuleDependencyRegistration[] DependencyRegistrations =>
    [
        new CardsDataAccessDependencyRegistration(),
        new CardsCoreDependencyRegistration()
    ];

    protected override IEndpointMapper[] EndpointMappers =>
    [
        new CardsEndpointsMapper()
    ];
}