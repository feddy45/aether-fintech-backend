using Web.Api.Authentication;
using Web.Api.Handlers;
using Web.Api.Modules;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddJwtAuthentication(configuration);
builder.RegisterModules();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(
        new System.Text.Json.Serialization.JsonStringEnumConverter(System.Text.Json.JsonNamingPolicy.CamelCase)
    );
});

var app = builder.Build();

app.UseExceptionHandler(ExceptionHandler.HandleExceptions);
app.ConfigureModules();
app.MapEndpoints();
app.UseAuthentication();
app.UseAuthorization();

await app.RunAsync();