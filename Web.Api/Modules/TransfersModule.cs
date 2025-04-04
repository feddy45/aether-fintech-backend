using Modules.Shared.DependencyInjection;
using Modules.Transfers.Api;
using Modules.Transfers.Core;
using Modules.Transfers.DataAccess;

namespace Web.Api.Modules;

public class TransfersModule : Module
{
    protected override IModuleDependencyRegistration[] DependencyRegistrations =>
    [
        new TransfersCoreDependencyRegistration(),
        new TransfersDataAccessDependencyRegistration()
    ];

    protected override IEndpointMapper[] EndpointMappers =>
    [
        new TransfersEndpointsMapper()
    ];
}