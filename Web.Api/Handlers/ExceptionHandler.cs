using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace Web.Api.Handlers;

public static class ExceptionHandler
{
    public static void HandleExceptions(IApplicationBuilder errorApp)
    {
        errorApp.Run(HandleException);
    }

    private static async Task HandleException(HttpContext context)
    {
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (exceptionHandlerFeature != null)
        {
            var exception = exceptionHandlerFeature.Error;

            var response = exception switch
            {
                _ => "Something bad happened!"
            };

            context.Response.ContentType = "plain/text";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(response);
        }
    }
}