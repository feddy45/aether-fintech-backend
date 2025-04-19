using Web.Api.Authentication;
using Web.Api.Handlers;
using Web.Api.Modules;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddJwtAuthentication(configuration);
builder.RegisterModules();

var app = builder.Build();

app.UseExceptionHandler(ExceptionHandler.HandleExceptions);
app.ConfigureModules();
app.MapEndpoints();
app.UseAuthentication();
app.UseAuthorization();

await app.RunAsync();