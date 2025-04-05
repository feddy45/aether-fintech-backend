using Modules.Shared.Models;

namespace Web.Api.Modules;

public class ConnectionStringModule : Module
{
    public override IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddSingleton(new ConnectionString(connectionString!));

        return builder.Services;
    }
}