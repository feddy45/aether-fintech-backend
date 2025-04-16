using Modules.Authorization.Api;
using Modules.Authorization.Core;
using Modules.Authorization.DataAccess;
using Modules.Shared.DependencyInjection;

namespace Web.Api.Modules;

public class AuthorizationModule : Module
{
    protected override IModuleDependencyRegistration[] DependencyRegistrations =>
    [
        new AuthorizationDataAccessDependencyRegistration(),
        new AuthorizationCoreDependencyRegistration()
    ];

    protected override IEndpointMapper[] EndpointMappers =>
    [
        new AuthorizationEndpointsMapper()
    ];
}