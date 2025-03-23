using Modules.Shared.DependencyInjection;

namespace Web.Api.Modules;

public abstract class Module
{
    public virtual bool IsEnabled { get; } = true;
    public virtual int Order { get; } = 0;

    protected virtual IModuleDependencyRegistration[] DependencyRegistrations { get; } = [];
    protected virtual IEndpointMapper[] EndpointMappers { get; } = [];

    public virtual IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        foreach (var module in DependencyRegistrations)
        {
            module.Execute(builder.Services);
        }

        return builder.Services;
    }

    public virtual IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        foreach (var endpointMapper in EndpointMappers)
        {
            endpoints = endpointMapper.MapEndpoints(endpoints);
        }

        return endpoints;
    }

    public virtual WebApplication Configure(WebApplication app)
    {
        return app;
    }
}