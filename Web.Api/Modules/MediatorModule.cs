using Modules.Mediator.Api;
using Modules.Shared.DependencyInjection;

namespace Web.Api.Modules;

public class MediatorModule : Module
{
    protected override IEndpointMapper[] EndpointMappers =>
    [
        new MediatorEndpointsMapper()
    ];
}