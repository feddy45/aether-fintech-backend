using Web.Api.Handlers;
using Web.Api.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterModules();

var app = builder.Build();

app.UseExceptionHandler(ExceptionHandler.HandleExceptions);
app.ConfigureModules();
app.MapEndpoints();

await app.RunAsync();