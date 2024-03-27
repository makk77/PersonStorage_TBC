using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace PersonStorage.API.Middlewares;

public class ExceptionHandler
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionHandler> logger;

    public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await Handler(context, ex);
        }
    }

    private async Task Handler(HttpContext context, Exception exception)
    {
        logger.LogError(exception, "ExceptionHandler");

        string titleText = "Internal Server Error.";
        string message = "Internal error occured. Connect to administrator";
        var traceId = Activity.Current?.Id ?? context?.TraceIdentifier;

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsync(
           JsonConvert.SerializeObject(
               new
               {
                   type = titleText,
                   title = titleText,
                   status = context.Response.StatusCode,
                   traceId = traceId,
                   errors = new
                   {
                       message = new string[] { message }
                   }
               }
          ));
    }
}
