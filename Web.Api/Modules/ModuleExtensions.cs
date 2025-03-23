namespace Web.Api.Modules;

public static class ModuleExtensions
{
    private static readonly List<Module> RegisteredModules = [];

    public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder)
    {
        var modules = DiscoverModules();
        foreach (var module in modules
                     .Where(m => m.IsEnabled)
                     .OrderBy(m => m.Order))
        {
            module.RegisterModule(builder);
            RegisteredModules.Add(module);
        }

        return builder;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var authorizedEndpoints = app.MapGroup("/nova/api").RequireAuthorization();

        foreach (var module in RegisteredModules) module.MapEndpoints(authorizedEndpoints);

        return app;
    }

    public static WebApplication ConfigureModules(this WebApplication app)
    {
        foreach (var module in RegisteredModules) module.Configure(app);

        return app;
    }

    private static IEnumerable<Module> DiscoverModules()
    {
        return typeof(Module).Assembly
            .GetTypes()
            .Where(p => p.IsClass && !p.IsAbstract && p.IsAssignableTo(typeof(Module)))
            .Select(Activator.CreateInstance)
            .Cast<Module>();
    }
}