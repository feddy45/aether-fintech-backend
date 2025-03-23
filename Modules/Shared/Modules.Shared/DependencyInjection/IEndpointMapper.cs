using Microsoft.AspNetCore.Routing;

namespace Modules.Shared.DependencyInjection;

public interface IEndpointMapper
{
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}