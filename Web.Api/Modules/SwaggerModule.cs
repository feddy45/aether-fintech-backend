using Microsoft.OpenApi.Models;

namespace Web.Api.Modules;

public sealed class SwaggerModule : Module
{
    private const string AppName = "Aether Fintech Backend";
    private const string SwaggerPrefix = "api/v1/swagger";
    private const string TokenId = "apiToken";

    public override WebApplication Configure(WebApplication app)
    {
        app.UseSwagger(option => { option.RouteTemplate = $"{SwaggerPrefix}/{{documentName}}/swagger.json"; });
        app.UseSwaggerUI(x =>
        {
            x.SwaggerEndpoint($"/{SwaggerPrefix}/v1/swagger.json", $"{AppName} API");
            x.RoutePrefix = SwaggerPrefix;
        });
        app.UseDeveloperExceptionPage();

        return app;
    }

    public override IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(setup =>
        {
            setup.EnableAnnotations();
            setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Description = AppName,
                Title = $"{AppName} API",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = AppName
                }
            });

            setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return builder.Services;
    }

    public override IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/", () => Results.Redirect($"/{SwaggerPrefix}"))
            .AllowAnonymous()
            .ExcludeFromDescription();

        return endpoints;
    }
}